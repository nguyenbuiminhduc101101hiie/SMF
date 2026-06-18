Public Class frmDOMReport

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.DataGridView1.Rows.Clear()


            'weeklyreport("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid")


            'weeklyreport("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid")


            'weeklyreport("Oversea-Sea-Export Shipments", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid")

            'weeklyreport("Oversea-Sea-Import Shipments", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid")



            'weeklyreport("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid")

            ''If Me.ComboBox2.Text = "ACS-Air-Export" Then
            'weeklyreport("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid")
            ''End If

            'If Me.ComboBox2.Text = "Domestic-Truck" Then
            weeklyreport("Domestic-Truck Shipments", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
            'End If
            'If Me.ComboBox2.Text = "Logistics-Customs" Then
            '  weeklyreport("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
            '  End If
          

        Catch ex As Exception

        End Try
    End Sub
    Public Sub weeklyreport(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String)
        Try
            Dim currow As Integer
            ' kiem tra neu co du lieu yhi moi add
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            sql = "select * from " & TableDept & "  where CONVERT(DATETIME,datereport) between '" & Me.DateTimePicker1.Value.Date & "' and '" & Me.DateTimePicker2.Value.Date & "' and ref like '%" & Me.ComboBox1.Text & "%' order by convert(datetime,datereport)  "
            ds = ReadDataSet(sql)
            Dim m As Integer
            For m = 15 To 17
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
            Next
            For m = 18 To 29
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Pink
            Next

            For m = 30 To 41
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LightGray
            Next
            For m = 42 To 42
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LightBlue
            Next

            For m = 43 To 43
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LightGreen
            Next

            For m = 45 To 45
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.YellowGreen
            Next
            For m = 46 To 46
                Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LemonChiffon
            Next
            Try

            Catch ex As Exception

            End Try
            Dim sqlc As String
            Dim dsc As New DataSet
            Dim sqlt As String
            Dim dst As New DataSet
            Dim it As Integer
            Dim idetails As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                ' Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    sqlc = "select distinct container from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " where " & tableFreightID & " = '" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  order by container "
                    dsc = ReadDataSet(sqlc)
                    If dsc.Tables(0).Rows.Count > 0 Then
                        For it = 0 To dsc.Tables(0).Rows.Count - 1
                            ' lay noi dung 1 cont
                            sqlt = "select * from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id = " & tableFreight & ".itemid where " & tableFreightID & " = '" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  and container='" & dsc.Tables(0).Rows(it).Item("container").ToString & "' order by container  "
                            dst = ReadDataSet(sqlt)
                            If dst.Tables(0).Rows.Count > 0 Then

                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib

                                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                                Me.DataGridView1.Item("seg", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                                Me.DataGridView1.Item("picsale", currow).Value = dst.Tables(0).Rows(0).Item("salecode").ToString

                                Me.DataGridView1.Item("ngaydonghang", currow).Value = dst.Tables(0).Rows(0).Item("ngaydonghang").ToString







                              
                                Me.DataGridView1.Item("VesselVoy", currow).Value = dst.Tables(0).Rows(0).Item("vessel").ToString + "-" + dst.Tables(0).Rows(0).Item("voyage").ToString
                                Me.DataGridView1.Item("ngaydi", currow).Value = dst.Tables(0).Rows(0).Item("sailingdate").ToString
                                Me.DataGridView1.Item("billno", currow).Value = dst.Tables(0).Rows(0).Item("mblcarrier").ToString
                                Dim sqlkh As String
                                Dim dskh As New DataSet
                                If dst.Tables(0).Rows(0).Item("customerid_showtc").ToString = "" Then

                                Else
                                    sqlkh = "select * from customer where customer_id= '" & dst.Tables(0).Rows(0).Item("customerid_showtc").ToString & "'"
                                    dskh = ReadDataSet(sqlkh)
                                    If dskh.Tables(0).Rows.Count > 0 Then
                                        Me.DataGridView1.Item("khachhang", currow).Value = dskh.Tables(0).Rows(0).Item("company").ToString
                                    End If
                                End If

                                Dim tach() As String
                                Try
                                    tach = dst.Tables(0).Rows(0).Item("container").ToString.Split("-")
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("contno", currow).Value = tach(0)
                                Catch ex As Exception

                                End Try
                                Try
                                    If tach(1) Like "*20*" Then
                                        Me.DataGridView1.Item("gp20", currow).Value = "1"
                                    ElseIf tach(1) Like "*40*" Then
                                        Me.DataGridView1.Item("gp40", currow).Value = "1"
                                    End If
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("pol", currow).Value = dst.Tables(0).Rows(0).Item("pol").ToString
                                Me.DataGridView1.Item("pod", currow).Value = dst.Tables(0).Rows(0).Item("pod").ToString
                                Dim otherfeeCredit_TruckNoiDi As Double = 0
                                Dim otherfeeCredit_TruckNoiDen As Double = 0
                                Dim rev As Double = 0
                                Dim totalcost As Double = 0
                                Dim tamFreight As Double = 0
                                ' LAP VONG LAP
                                Dim il As Integer
                                For IL = 0 To dst.Tables(0).Rows.Count - 1

                                    tamFreight = CDbl(dst.Tables(0).Rows(il).Item("price").ToString)
                                    If dst.Tables(0).Rows(il).Item("DebitCredit").ToString = "Credit" And dst.Tables(0).Rows(il).Item("Dept").ToString = "TRUCK_NOIDI" Then

                                        Dim other As Boolean = True

                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*OF*" Or UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*O/F*" Or UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*OCEAN FREIGHT*" Then
                                            Dim sqlcusOF As String
                                            Dim dscusOF As New DataSet
                                            sqlcusOF = "select * from customer where customer_id='" & dst.Tables(0).Rows(il).Item("customerid").ToString & "'"
                                            dscusOF = ReadDataSet(sqlcusOF)
                                            If dscusOF.Tables(0).Rows.Count > 0 Then
                                                Me.DataGridView1.Item("vendorOF", currow).Value = dscusOF.Tables(0).Rows(0).Item("company").ToString
                                            End If
                                            Me.DataGridView1.Item("invOF", currow).Value = dst.Tables(0).Rows(il).Item("ngayhoadon").ToString
                                            Try
                                                Me.DataGridView1.Item("giaOF", currow).Value = tamFreight
                                            Catch ex As Exception

                                            End Try

                                            Me.DataGridView1.Item("OFGMD3", currow).Value = tamFreight * 30 / 100

                                            other = False
                                        End If

                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*TRUCKING*" Then
                                            Dim sqlcusTK As String
                                            Dim dscusTK As New DataSet
                                            sqlcusTK = "select * from customer where customer_id='" & dst.Tables(0).Rows(il).Item("customerid").ToString & "'"
                                            dscusTK = ReadDataSet(sqlcusTK)
                                            If dscusTK.Tables(0).Rows.Count > 0 Then
                                                Me.DataGridView1.Item("TruckingVendor", currow).Value = dscusTK.Tables(0).Rows(0).Item("company").ToString
                                            End If
                                            Me.DataGridView1.Item("canglayCont", currow).Value = dst.Tables(0).Rows(i).Item("POL").ToString

                                            Me.DataGridView1.Item("diemdongtrahang", currow).Value = dst.Tables(0).Rows(i).Item("DiemDongTraHangNoiXuat").ToString
                                            Me.DataGridView1.Item("cangha", currow).Value = dst.Tables(0).Rows(i).Item("POd").ToString
                                            Me.DataGridView1.Item("giaTrucking", currow).Value = tamFreight
                                            other = False
                                        End If

                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*LO/LO*" Or UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*LO/LO*" Then

                                            Me.DataGridView1.Item("LOLO", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*RUTRUOT*" Then 'Or UCase(dst.Tables(0).Rows(i).Item("charge_code").ToString) Like "*LO/LO*" Then

                                            Me.DataGridView1.Item("RUTRUOT", currow).Value = tamFreight
                                            other = False
                                        End If

                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*KIEMDEM*" Then 'Or UCase(dst.Tables(0).Rows(i).Item("charge_code").ToString) Like "*LO/LO*" Then

                                            Me.DataGridView1.Item("KIEMDEM", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*VSC*" Or UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*CLEAN*" Then

                                            Me.DataGridView1.Item("VSC", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*COMMISSION*" Then ' Or UCase(dst.Tables(0).Rows(i).Item("charge_code").ToString) Like "*CLEAN*" Then

                                            Me.DataGridView1.Item("Commission", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If other = True Then
                                            otherfeeCredit_TruckNoiDi += tamFreight
                                        End If
                                    End If ' credit- truck noidi


                                    If dst.Tables(0).Rows(il).Item("DebitCredit").ToString = "Credit" And dst.Tables(0).Rows(il).Item("Dept").ToString = "TRUCK_NOIDEN" Then

                                        Dim other As Boolean = True


                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*TRUCKING*" Then
                                            Dim sqlcusTK As String
                                            Dim dscusTK As New DataSet
                                            sqlcusTK = "select * from customer where customer_id='" & dst.Tables(0).Rows(il).Item("customerid").ToString & "'"
                                            dscusTK = ReadDataSet(sqlcusTK)
                                            If dscusTK.Tables(0).Rows.Count > 0 Then
                                                Me.DataGridView1.Item("TruckingVendor_", currow).Value = dscusTK.Tables(0).Rows(0).Item("company").ToString
                                            End If
                                            Me.DataGridView1.Item("canglayCont_", currow).Value = dst.Tables(0).Rows(il).Item("POd").ToString

                                            Me.DataGridView1.Item("diemdongtrahang_", currow).Value = dst.Tables(0).Rows(il).Item("DiemDongTraHangNoiXuat").ToString
                                            Me.DataGridView1.Item("cangha_", currow).Value = dst.Tables(0).Rows(il).Item("POd").ToString
                                            Me.DataGridView1.Item("giaTrucking_", currow).Value = tamFreight
                                            other = False
                                        End If

                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*LO/LO*" Or UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*LO/LO*" Then

                                            Me.DataGridView1.Item("LOLO_", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*RUTRUOT*" Then 'Or UCase(dst.Tables(0).Rows(i).Item("charge_code").ToString) Like "*LO/LO*" Then

                                            Me.DataGridView1.Item("RUTRUOT_", currow).Value = tamFreight
                                            other = False
                                        End If

                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*KIEMDEM*" Then 'Or UCase(dst.Tables(0).Rows(i).Item("charge_code").ToString) Like "*LO/LO*" Then

                                            Me.DataGridView1.Item("KIEMDEM_", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*VSC*" Or UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*CLEAN*" Then

                                            Me.DataGridView1.Item("VSC_", currow).Value = tamFreight
                                            other = False
                                        End If
                                        If UCase(dst.Tables(0).Rows(il).Item("charge_code").ToString) Like "*COMMISSION*" Then ' Or UCase(dst.Tables(0).Rows(i).Item("charge_code").ToString) Like "*CLEAN*" Then

                                            Me.DataGridView1.Item("Commission_", currow).Value = tamFreight
                                            other = False
                                        End If

                                        If other = True Then
                                            otherfeeCredit_TruckNoiDen += tamFreight
                                        End If
                                    End If ' credit- truck noidi
                                    If dst.Tables(0).Rows(il).Item("DebitCredit").ToString = "Credit" Then
                                        Try
                                            totalcost += tamFreight
                                        Catch ex As Exception

                                        End Try

                                    End If
                                    If dst.Tables(0).Rows(il).Item("DebitCredit").ToString = "Debit" Then
                                        Try
                                            rev += tamFreight
                                        Catch ex As Exception

                                        End Try

                                    End If


                                Next

                                Me.DataGridView1.Item("KHAC", currow).Value = otherfeeCredit_TruckNoiDI

                                Me.DataGridView1.Item("KHAC_", currow).Value = otherfeeCredit_TruckNoiDen
                                Me.DataGridView1.Item("totalcost", currow).Value = totalcost

                                Me.DataGridView1.Item("rev", currow).Value = rev
                                Me.DataGridView1.Item("totalrev", currow).Value = rev
                                Me.DataGridView1.Item("pltotal", currow).Value = rev - totalcost
                            End If
                            '----------------
                        
                        Next

                    End If


                    ' dua cac phi vao
                  
                Next

            End If

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
            Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Me.Label4.Text = "DOM WEEKLY REPORT (inclued VAT)"
            'id = "tablename"
            'value = "viewername"
            'Me.ComboBox2.Items.Clear()


            'strSQL = "Select tablename,viewername From listdept order by viewername "
            'loadDataToObject(Me.ComboBox2, strSQL, id, value)
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
End Class