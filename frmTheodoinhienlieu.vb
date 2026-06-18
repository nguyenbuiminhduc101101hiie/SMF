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
Public Class frmTheodoinhienlieu

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Function getTongXDLogisticsfreight(ByVal soxe As String, ByVal tu As Date, ByVal den As Date, ByVal debitcredit As String, ByVal pay As Boolean, ByVal codeXangDau As Boolean)
        Try
            Dim tong As Double = 0
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            If Me.ComboBox1.Text = "" Then
                '  DisplayMessage(True, "Xin chọn Branch !")
                '  Exit Function
            End If
            ' lay tong tien cua freightlogistics
            Dim sql As String
            Dim ds As New DataSet
            'If codeXangDau = True Then
            sql = "select * from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join charge on charge.charge_id= logisticsfreight.itemid where voyage='" & soxe & "'  and debitcredit='" & debitcredit & "'  and convert(datetime,datereport) between '" & tu & "' and '" & den & "' and ref like '%" & Me.ComboBox1.Text & "%' and paycheck='" & pay & "' and charge_code='PXD' "

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

            'Else
            '    sql = "select * from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid where customerid='" & FindValueID(Me.cbocustomer, Me.cbocustomer.Text) & "' and debitcredit='" & debitcredit & "'  and convert(datetime,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' paycheck='" & pay & "'  "

            '    ds = ReadDataSet(sql)
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        For i = 0 To ds.Tables(0).Rows.Count - 1
            '            If ds.Tables(0).Rows(i).Item("currency").ToString.Trim = "VND" Then
            '                tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
            '            Else
            '                tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
            '            End If

            '        Next
            '    End If



            'End If






            Return tong
        Catch ex As Exception

        End Try
    End Function
    Function getTongXDPhieutamungXD(ByVal soxe As String, ByVal tu As Date, ByVal den As Date)
        Try
            Dim tong As Double = 0
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text

            ' lay tong tien cua freightlogistics
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from phieutamungxangdau left join dmdaukeo on dmdaukeo.dmdaukeoid=phieutamungxangdau.dmdaukeoid where convert(datetime,ngaytamung) between '" & tu & "' and '" & den & "' and maxe='" & soxe & "' "

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


            ' weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "mblmawb")


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
            Dim i As Integer
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from dmdaukeo "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' moi dau keo, ta lay thong tin freoigth tu dau den ngay1
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' so xe thu 1
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    Me.DataGridView1.Item("Column1", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                    Me.DataGridView1.Item("laixe", currow).Value = ds.Tables(0).Rows(i).Item("laixe").ToString
                    Me.DataGridView1.Item("soxe", currow).Value = ds.Tables(0).Rows(i).Item("maxe").ToString
                    Me.DataGridView1.Item("nldauky", currow).Value = IIf(getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-Jan-2000"), CDate(NGAY1)) - getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-jan-2000"), CDate(NGAY1), "Credit", True, True) = 0, "", getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-Jan-2000"), CDate(NGAY1)) - getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-jan-2000"), CDate(NGAY1), "Credit", True, True))
                    Me.DataGridView1.Item("nltieuthu", currow).Value = IIf(getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2), "Credit", True, True) = 0, "", getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2), "Credit", True, True))
                    Me.DataGridView1.Item("nldanhan", currow).Value = IIf(getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2)) = 0, "", getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2)))
                    Me.DataGridView1.Item("nlcuoiky", currow).Value = IIf(CDbl(getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-Jan-2000"), CDate(NGAY1)) - getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-jan-2000"), CDate(NGAY1), "Credit", True, True)) - CDbl(getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2), "Credit", True, True)) + CDbl(getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2))) = 0, "", CDbl(getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-Jan-2000"), CDate(NGAY1)) - getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate("01-jan-2000"), CDate(NGAY1), "Credit", True, True)) - CDbl(getTongXDLogisticsfreight(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2), "Credit", True, True)) + CDbl(getTongXDPhieutamungXD(ds.Tables(0).Rows(i).Item("maxe").ToString, CDate(NGAY1), CDate(NGAY2))))
                Next
            End If

            'sodudauky = getTongXDPhieutamungXD(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate("01-Jan-2000"), CDate(NGAY1)) - getTongXDLogisticsfreight(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate("01-jan-2000"), CDate(NGAY1), "Credit", True, True)
            'nldanhan = getTongXDPhieutamungXD(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate(NGAY1), CDate(NGAY2))
            'nltieuthu = getTongXDLogisticsfreight(FindValueID(Me.cbocustomer, Me.cbocustomer.Text), CDate(NGAY1), CDate(NGAY2), "Credit", True, True)

            'Me.TextBox3.Text = FormatNumber(nldanhan, 0)
            'Me.TextBox2.Text = FormatNumber(sodudauky, 0)
            'Me.txtnltieuthu.Text = FormatNumber(nltieuthu, 0)

            'nltoncuoiky = sodudauky - nldanhan + nltieuthu + nlsuachua
            'Me.txtnltoncuoiky.Text = FormatNumber(nltoncuoiky, 0)
            ' kiem neu luoi >1 thi co du lieu
            Try

                Dim cmd As New ADODB.Command
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from salesReportChart  "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try

            Try
                'duyet luoi
                Dim strQuery As String
                Dim rs As New ADODB.Recordset
                'Dim i As Integer
                For i = 0 To Me.DataGridView1.Rows.Count - 3
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM salesReportChart "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("id").Value = NewId()




                        Try
                            .Fields("stt").Value = i + 1
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("sanpham").Value = Me.DataGridView1.Item("soxe", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("soluong").Value = Me.DataGridView1.Item("nlcuoiky", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        .Update()
                        rs.Close()
                    End With

                Next

            Catch ex As Exception

            End Try
            ' lay  salesreportchart nhom lai voi sanpham
            Try

                Dim cmd1 As New ADODB.Command
                cmd1.let_ActiveConnection(strconn)
                cmd1.CommandText = "delete from salesReportChartshow  "

                cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset
                ' Dim i As Integer
                Dim sqln As String
                Dim dsn As New DataSet
                sqln = "select sanpham,sum(soluong) as tong from salesreportchart group by sanpham "
                dsn = ReadDataSet(sqln)
                If dsn.Tables(0).Rows.Count > 0 Then
                    For i = 0 To dsn.Tables(0).Rows.Count - 1
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM salesReportChartshow "

                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs

                            .AddNew()
                            .Fields("id").Value = NewId()




                            Try
                                .Fields("stt").Value = i + 1
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("sanpham").Value = dsn.Tables(0).Rows(i).Item("sanpham").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("soluong").Value = dsn.Tables(0).Rows(i).Item("tong").ToString
                            Catch ex As Exception

                            End Try
                            .Update()
                            rs.Close()
                        End With
                    Next
                End If
            Catch ex As Exception

            End Try
            ' lay salesreportchartshow

            Dim dss As New DataSet
            dss = ReadDataSet("set dateformat dmy select * from salesreportchartshow")
            ChartControl1.DataSource = dss.Tables(0)
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
        'TODO: This line of code loads data into the 'FDIDataSet2.salesreportchartshow' table. You can move, or remove it, as needed.
        '   Me.SalesreportchartshowTableAdapter.Fill(Me.FDIDataSet2.salesreportchartshow)
        Try
            '  Button1_Click(sender, e)
            'Dim id, value, strSQL, strQuery As String
            'id = "customer_id"
            'value = "company"
            'Me.cbocustomer.Items.Clear()


            'strSQL = "Select customer_id,company From customer order by company "
            'loadDataToObject(Me.cbocustomer, strSQL, id, value)
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