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
Public Class frmQuyettoannhienlieu

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Function getTongXDLogisticsfreight(ByVal cusid As String, ByVal tu As Date, ByVal den As Date, ByVal debitcredit As String, ByVal pay As Boolean, ByVal codeXangDau As Boolean)
        Try
            Dim tong As Double = 0
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            If Me.ComboBox1.Text = "" Then
                DisplayMessage(True, "Xin chọn Bracnch !")
                Exit Function
            End If
            ' lay tong tien cua freightlogistics
            Dim sql As String
            Dim ds As New DataSet
            If codeXangDau = True Then
                sql = "select * from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join charge on charge.charge_id= logisticsfreight.itemid where customerid='" & FindValueID(Me.cbocustomer, Me.cbocustomer.Text) & "' and debitcredit='" & debitcredit & "'  and convert(datetime,datereport) between '" & tu & "' and '" & den & "' and ref like '%" & Me.ComboBox1.Text & "%' and paycheck='" & pay & "' and charge_code='PXD' "

                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        'If ds.Tables(0).Rows(i).Item("currency").ToString.Trim = "VND" Then
                        tong += CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString) ' neu la phi Xang dau thi tong la quantity
                        'Else
                        '  tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
                        'End If

                    Next
                End If

            Else
                sql = "select * from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid where customerid='" & FindValueID(Me.cbocustomer, Me.cbocustomer.Text) & "' and debitcredit='" & debitcredit & "'  and convert(datetime,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' paycheck='" & pay & "'  "

                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        If ds.Tables(0).Rows(i).Item("currency").ToString.Trim = "VND" Then
                            tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
                        Else
                            tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
                        End If

                    Next
                End If



            End If






            Return tong
        Catch ex As Exception

        End Try
    End Function
    Function getTongXDPhieutamungXD(ByVal cusid As String, ByVal tu As Date, ByVal den As Date)
        Try
            Dim tong As Double = 0
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text

            ' lay tong tien cua freightlogistics
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from phieutamungxangdau where customerid='" & FindValueID(Me.cbocustomer, Me.cbocustomer.Text) & "' and convert(datetime,ngaytamung) between '" & tu & "' and '" & den & "' "

            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    tong += CDbl(ds.Tables(0).Rows(i).Item("soluong").ToString) 'CDbl(ds.Tables(0).Rows(i).Item("dongia").ToString) * 


                Next
            End If






            Return tong
        Catch ex As Exception

        End Try
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.DataGridView1.Rows.Clear()


            weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "mblmawb")
           

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
                    'tong1 += CDbl(Me.DataGridView1.Item("Column9", itong).Value)
                    'tong2 += CDbl(Me.DataGridView1.Item("Column10", itong).Value)
                    'tong3 += CDbl(Me.DataGridView1.Item("Column11", itong).Value)
                    'tong4 += CDbl(Me.DataGridView1.Item("Column16", itong).Value)
                    'tong5 += CDbl(Me.DataGridView1.Item("Column17", itong).Value)
                    'tong6 += CDbl(Me.DataGridView1.Item("Column18", itong).Value)
                    'tong7 += CDbl(Me.DataGridView1.Item("profit", itong).Value)
                Catch ex As Exception

                End Try


            Next
            'Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tong1.ToString, 2)
            'Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tong2.ToString, 2)
            'Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(tong3.ToString, 2)
            'Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tong4.ToString, 2)
            'Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tong5.ToString, 2)
            'Me.DataGridView1.Item("Column18", currow).Value = FormatNumber(tong6.ToString, 2)
            'Me.DataGridView1.Item("profit", currow).Value = FormatNumber(tong7.ToString, 2)
            'Me.DataGridView1.Item("hbl", currow).Value = "Total"
            Dim sodudauky As Double = 0
            Dim nldanhan As Double = 0
            Dim nltieuthu As Double = 0
            Dim nlsuachua As Double = 0
            Dim nltoncuoiky As Double = 0
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            sodudauky = getTongXDPhieutamungXD(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate("01-Jan-2000"), CDate(NGAY1)) - getTongXDLogisticsfreight(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate("01-jan-2000"), CDate(NGAY1), "Credit", True, True)
            nldanhan = getTongXDPhieutamungXD(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate(NGAY1), CDate(NGAY2))
            nltieuthu = getTongXDLogisticsfreight(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate(NGAY1), CDate(NGAY2), "Credit", True, True)

            Me.TextBox3.Text = FormatNumber(nldanhan, 0)
            Me.TextBox2.Text = FormatNumber(sodudauky, 0)
            Me.txtnltieuthu.Text = FormatNumber(nltieuthu, 0)

            nltoncuoiky = sodudauky - nldanhan + nltieuthu + nlsuachua
            Me.txtnltoncuoiky.Text = FormatNumber(nltoncuoiky, 0)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub weeklyreport_(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal hbl As String)
        Try
            Dim currow As Integer
            ' kiem tra neu co du lieu yhi moi add
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer

            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text

            sql = "select distinct blob_id from " & TableDept & " left join  " & tableFreight & " on " & tableFreight & ".Logisticsid = " & TableDept & ".blob_id  where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocustomer, Me.cbocustomer.Text) & "'   " 'and nhom like 'COC%'

            'Else
            'sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

            'End If
            ds = ReadDataSet(sql)
            Dim m As Integer
            Try
              
            Catch ex As Exception

            End Try

            Dim tigiadebit As Double = 0
            Dim itang As Integer = 1
            Dim sqlchitiet As String
            Dim dschitiet As New DataSet
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung voi moi lo ta tim sont
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lap bill
                    ' ung voi moi lo hang ta lay chi tiet
                    sqlchitiet = "select * from logistics where blob_id='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "' "
                    dschitiet = ReadDataSet(sqlchitiet)
                    If dschitiet.Tables(0).Rows.Count > 0 Then
                        '-----------------------------------
                        'Me.DataGridView1.Rows.Add(1)
                        'currow = DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.DataGridView1.Rows.Add(1)
                        currow = DataGridView1.RowCount - 2
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                        Me.DataGridView1.Item("Column1", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                        Try
                            Me.DataGridView1.Item("loaihinh", currow).Value = dschitiet.Tables(0).Rows(0).Item("voyage").ToString
                            'End If
                        Catch ex As Exception
                        End Try
                        Try
                            Me.DataGridView1.Item("datereport", currow).Value = dschitiet.Tables(0).Rows(0).Item("datereport").ToString
                            'End If
                        Catch ex As Exception

                        End Try



                     
                        Try
                            Me.DataGridView1.Item("Column5", currow).Value = dschitiet.Tables(0).Rows(0).Item("mbl").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("Column5", currow).Value = dschitiet.Tables(0).Rows(0).Item("mblcarrier").ToString
                        End Try

                        Try
                            Me.DataGridView1.Item("Column6", currow).Value = dschitiet.Tables(0).Rows(0).Item("hbl").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("Column6", currow).Value = dschitiet.Tables(0).Rows(0).Item("mblmawb").ToString
                        End Try
                        Try
                            Me.DataGridView1.Item("pol", currow).Value = dschitiet.Tables(0).Rows(0).Item("pol").ToString + ds.Tables(0).Rows(i).Item("AirportDeparture").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("pol", currow).Value = dschitiet.Tables(0).Rows(0).Item("pol").ToString
                        End Try

                        Try
                            Me.DataGridView1.Item("pod", currow).Value = dschitiet.Tables(0).Rows(0).Item("pod").ToString + ds.Tables(0).Rows(i).Item("AirPortDes").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("pod", currow).Value = dschitiet.Tables(0).Rows(0).Item("pod").ToString
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
                        Dim socont, soseal As String
                        '-------------------
                        socont = ""
                        soseal = ""
                        sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & dschitiet.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
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
                                socont += dscont.Tables(0).Rows(ic).Item("containerno").ToString
                                soseal += dscont.Tables(0).Rows(ic).Item("seal").ToString
                                If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*20*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                    cont20 += 1
                                End If

                                If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*40*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                    cont40 += 1
                                End If

                            
                            Next

                        End If
                        Me.DataGridView1.Item("socont", currow).Value = socont
                        Me.DataGridView1.Item("soseal", currow).Value = soseal

                        If dschitiet.Tables(0).Rows(0).Item("FCL").ToString = True Then
                            '
                            If cont20 > 0 Then
                                Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString ' + " x 20GP"

                            End If
                            If cont40 > 0 Then
                                Me.DataGridView1.Item("Column8", currow).Value += cont40.ToString ' + " x 40GP; "
                            End If
                          


                        ElseIf dschitiet.Tables(0).Rows(0).Item("LCL").ToString = True Then

                            Me.DataGridView1.Item("lcl", currow).Value = khoi.ToString + " CBM"
                        End If

                        '---------------------
                        ' client
                        Dim sqlcus As String
                        Dim dscus As New DataSet
                        Try
                            If dschitiet.Tables(0).Rows(0).Item("customerid_showtc").ToString <> "" Then
                                sqlcus = "select * from customer where customer_id='" & dschitiet.Tables(0).Rows(0).Item("customerid_showtc").ToString & "' "
                                dscus = ReadDataSet(sqlcus)
                                If dscus.Tables(0).Rows.Count > 0 Then
                                    Me.DataGridView1.Item("client", currow).Value = dscus.Tables(0).Rows(0).Item("company").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try

                        '---------------

                        '' client
                        'Dim sqlagent As String
                        'Dim dsagent As New DataSet
                        'Try
                        '    If ds.Tables(0).Rows(i).Item("agentid").ToString <> "" Then
                        '        sqlagent = "select * from customer where customer_id='" & ds.Tables(0).Rows(i).Item("agentid").ToString & "' "
                        '        dsagent = ReadDataSet(sqlagent)
                        '        If dsagent.Tables(0).Rows.Count > 0 Then
                        '            Me.DataGridView1.Item("Column4", currow).Value = dsagent.Tables(0).Rows(0).Item("company").ToString
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

                        Dim k As Integer
                        '--------------------------------
                        Dim otherdebit As Double = 0
                        Dim othercredit As Double = 0
                        Dim tongdebitthue As Double = 0
                        Dim tongcreditthuecoV As Double = 0
                        Dim tongcreditthuekhongV As Double = 0

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
                        Dim giatiensauthue As Double = 0

                        '-------------------------------
                        If Me.chkVND.Checked = True Then

                            Dim sqlF As String
                            Dim dsF As New DataSet
                            sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id  where " & tableFreightID & " ='" & dschitiet.Tables(0).Rows(0).Item(TableDeptID).ToString & "'  " 'and daily=0
                            dsF = ReadDataSet(sqlF)
                            If dsF.Tables(0).Rows.Count > 0 Then
                                tongindebit = 0
                                tongincredit = 0
                                tongindebitvnd = 0
                                tongincreditvnd = 0
                                tongdebitthue = 0


                                For k = 0 To dsF.Tables(0).Rows.Count - 1
                                    Try
                                        If dsF.Tables(0).Rows(k).Item("currency").ToString = "VND" Then
                                            giatientruocthue = dsF.Tables(0).Rows(k).Item("price").ToString / ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)
                                            giatiensauthue = dsF.Tables(0).Rows(k).Item("price").ToString '/ ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)

                                        Else
                                            giatientruocthue = (dsF.Tables(0).Rows(k).Item("price").ToString * dsF.Tables(0).Rows(k).Item("tigia").ToString) / ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)
                                            giatiensauthue = (dsF.Tables(0).Rows(k).Item("price").ToString * dsF.Tables(0).Rows(k).Item("tigia").ToString) '/ ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)


                                        End If

                                    Catch ex As Exception

                                    End Try
                                    ' theo tung phi debit
                                    If dsF.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then


                                        ' khogn su dung debit
                                    End If
                                    ' credit
                                    If dsF.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "LUONG" Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item("LUONG", currow).Value += CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PTA" Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item("PTA", currow).Value += CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PCA" Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item("PCA", currow).Value += CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PCD" Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item("PCD", currow).Value += CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PBX" Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item("PBX", currow).Value += CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PXD" Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item("PXD", currow).Value += CDbl(dsF.Tables(0).Rows(k).Item("quantity").ToString) 'CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If


                                        'If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) Like "*TRUCKING*" Then
                                        '    ' lay price truoc thue
                                        '    Try
                                        '        If dsF.Tables(0).Rows(k).Item("taxprice").ToString = "0" Then
                                        '            Me.DataGridView1.Item("thuengoaiKHONGv", currow).Value += CDbl(giatiensauthue)
                                        '        Else
                                        '            Me.DataGridView1.Item("thuengoaicov", currow).Value += CDbl(giatiensauthue)
                                        '        End If


                                        '    Catch ex As Exception

                                        '    End Try

                                        'End If

                                        '''' neu khac thi goi la other
                                        If Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "LUONG" And Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PTA" And Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PCA" And Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PBX" And Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PCD" And Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) = "PXD" And Not UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) Like "*TRUCKING*" Then
                                            ' lay price truoc thue
                                            Try
                                                othercredit += CDbl(giatiensauthue)

                                            Catch ex As Exception

                                            End Try

                                        End If
                                        'Try
                                        '    If dsF.Tables(0).Rows(k).Item("taxprice").ToString = "0" Then
                                        '        tongcreditthuekhongV += giatiensauthue
                                        '    Else
                                        '        tongcreditthuecoV += giatiensauthue
                                        '    End If
                                        '    ' * CDbl(dsF.Tables(0).Rows(k).Item("taxprice").ToString) / 100) 'CDbl(dsF.Tables(0).Rows(k).Item("pricethue").ToString) / CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)

                                        'Catch ex As Exception

                                        'End Try
                                        Try
                                            tongcredit += CDbl(giatientruocthue)
                                            tongcreditvnd += CDbl(giatientruocthue) '* CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)
                                        Catch ex As Exception

                                        End Try

                                    End If
                                Next



                            End If



                            Me.DataGridView1.Item("chikhac", currow).Value = FormatNumber(othercredit, 2)
                            'Me.DataGridView1.Item("tracking_phaithu", currow).Value = FormatNumber(tongdebitthue, 2)
                            'Me.DataGridView1.Item("khac_phaithu", currow).Value = FormatNumber(otherdebit, 2)
                            'Me.DataGridView1.Item("thuengoaicov", currow).Value = FormatNumber(Me.DataGridView1.Item("thuengoaicov", currow).Value, 2)
                            'Me.DataGridView1.Item("thuengoaikhongv", currow).Value = FormatNumber(Me.DataGridView1.Item("thuengoaikhongv", currow).Value, 2)


                            Me.DataGridView1.Item("LUONG", currow).Value = FormatNumber(Me.DataGridView1.Item("LUONG", currow).Value, 2)

                            Me.DataGridView1.Item("PTA", currow).Value = FormatNumber(Me.DataGridView1.Item("PTA", currow).Value, 2)
                            Me.DataGridView1.Item("PCA", currow).Value = FormatNumber(Me.DataGridView1.Item("PCA", currow).Value, 2)

                            Me.DataGridView1.Item("PCD", currow).Value = FormatNumber(Me.DataGridView1.Item("PCD", currow).Value, 2)

                            Me.DataGridView1.Item("PBX", currow).Value = FormatNumber(Me.DataGridView1.Item("PBX", currow).Value, 2)

                            Me.DataGridView1.Item("PXD", currow).Value = FormatNumber(Me.DataGridView1.Item("PXD", currow).Value, 2)



                        Else
                            ' truong USD khong tinh o day



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
            id = "customer_id"
            value = "company"
            Me.cbocustomer.Items.Clear()


            strSQL = "Select customer_id,company From customer order by company "
            loadDataToObject(Me.cbocustomer, strSQL, id, value)
            ' Me.Label4.Text = "WEEKLY REPORT (Các phí thu hộ và chi hộ tính riêng.)"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub JobDetailsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobDetailsToolStripMenuItem.Click

    End Sub
End Class