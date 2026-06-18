Public Class frmBangketamung
    Dim SetTime As Integer
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMilliseconds(300000)
    Private Sub frmBangketamung_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim id, value, strquery As String
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where maincode='Personal' and CONTINUED=1 Order by company "
            ' Me.cbocusdebit.Items.Clear()

            Me.txtnguoidenghi.Items.Clear()





            ' loadDataToObject(Me.cbocusdebit, strQuery, id, value)

            loadDataToObject(Me.txtnguoidenghi, strquery, id, value)
            '-------------------------------------------
            tmrCountdown.Interval = 500
            TargetDT = DateTime.Now.Add(CountDownFrom)
            tmrCountdown.Start()
            DisplayMessage(True, "Bạn cần chọn khoảng thời gian phù hợp, mặc định la ngày hiện hành.!")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub queryGrid() 'ByVal tabledep As String, ByVal tabledepID As String, ByVal tabledepFreight As String, ByVal tabledepfreightID As String, ByVal linkID As String
        Try
            Dim oTblEquip, otblHinh As New DataTable
            'Dim sql As String
            'Dim ds As New DataSet
            'sql = "select * from phieudenghitamung where mbl='" & Me.cbombl.Text & "' order by hbl "
            'ds = ReadDataSet(sql)
            'Me.DataGridView1.DataSource = ds.Tables(0)
            'InsertAutoNumberToGrid(Me.DataGridView1)
            Try
                Dim sql As String
                If Me.chkallday.Checked = True Then
                    sql = "Select HienTruongTamUngID,sodenghi,sotiencredit,lydokhongduyet,duyet,price,price-tienhoanung  as duthieu,khongduyet,nguoidenghi,company,charge as  Item,tienhoanung,dahoanung,ngaydenghi,bophan,mbl,hbl,currency,hientruongtamung.approve,userupdate,dateupdate "

                    sql &= "  From hientruongtamung left join customer on hientruongtamung.customerid=customer.customer_id  left join charge on hientruongtamung.itemid=charge.charge_id "

                    If Me.chktatca.Checked = True Then
                        If Me.CheckBox1.Checked = True Then
                            sql &= "Where " & _
                                                 " duyet=1 and price > 0 "

                        Else
                            sql &= "Where " & _
                                                 "  duyet=0 and price > 0 "

                        End If
                    Else
                        If Me.CheckBox1.Checked = True Then
                            sql &= "Where " & _
                                                 " nguoidenghiid like '%" & FindValueID(Me.txtnguoidenghi, Me.txtnguoidenghi.Text) & "%'  and duyet=1 and price > 0 "

                        Else
                            sql &= "Where " & _
                                                 " nguoidenghiid like '%" & FindValueID(Me.txtnguoidenghi, Me.txtnguoidenghi.Text) & "%'   and duyet=0  and price > 0"

                        End If
                    End If

                Else
                    sql = "Select HienTruongTamUngID,sodenghi,lydokhongduyet,sotiencredit,duyet,price,price-tienhoanung - sotiencredit as duthieu,khongduyet,nguoidenghi,company,charge as Item,tienhoanung,dahoanung,ngaydenghi,bophan,mbl,hbl,currency,hientruongtamung.approve,userupdate,dateupdate "
                    sql &= "   From hientruongtamung left join customer on hientruongtamung.customerid=customer.customer_id  left join charge on hientruongtamung.itemid=charge.charge_id "

                    If Me.chktatca.Checked = True Then
                        If Me.CheckBox1.Checked = True Then
                            sql &= "Where " & _
                                                 " convert(datetime,ngaydenghi) between '" & ddMMMyyyy(Me.dtpNgaydenghitu.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpden.Value.Date) & "' and duyet=1 and price > 0 "

                        Else
                            sql &= "Where " & _
                                                 " convert(datetime,ngaydenghi) between '" & ddMMMyyyy(Me.dtpNgaydenghitu.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpden.Value.Date) & "'  and duyet=0 and price > 0 "

                        End If
                    Else
                        If Me.CheckBox1.Checked = True Then
                            sql &= "Where " & _
                                                 " nguoidenghiid like '%" & FindValueID(Me.txtnguoidenghi, Me.txtnguoidenghi.Text) & "%' and convert(datetime,ngaydenghi) between '" & ddMMMyyyy(Me.dtpNgaydenghitu.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpden.Value.Date) & "' and duyet=1 and price > 0 "

                        Else
                            sql &= "Where " & _
                                                 " nguoidenghiid like '%" & FindValueID(Me.txtnguoidenghi, Me.txtnguoidenghi.Text) & "%' and convert(datetime,ngaydenghi) between '" & ddMMMyyyy(Me.dtpNgaydenghitu.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpden.Value.Date) & "'  and duyet=0 and price > 0 "

                        End If
                    End If

                End If



                oTblEquip = ReadTable(Sql)
                Me.DataGridView2.DataSource = oTblEquip


                '--------------------
                Me.Cursor = System.Windows.Forms.Cursors.Default

                InsertAutoNumberToGrid(Me.DataGridView2)
                ' Me.profit()
                ' doi mau do neu other=1
                'Dim i As Integer
                'Try
                '    For i = 0 To Me.DataGridView2.Rows.Count - 1
                '        If Me.DataGridView2.Item("other", i).Value = "True" Then
                '            Me.DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                '            Me.DataGridView2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                '        End If
                '    Next
                'Catch ex As Exception

                'End Try

                'End If
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub queryGrid_file() 'ByVal tabledep As String, ByVal tabledepID As String, ByVal tabledepFreight As String, ByVal tabledepfreightID As String, ByVal linkID As String
        Try
            Dim oTblEquip, otblHinh As New DataTable
            'Dim sql As String
            'Dim ds As New DataSet
            'sql = "select * from phieudenghitamung where mbl='" & Me.cbombl.Text & "' order by hbl "
            'ds = ReadDataSet(sql)
            'Me.DataGridView1.DataSource = ds.Tables(0)
            'InsertAutoNumberToGrid(Me.DataGridView1)
            Try
                Dim sql As String

                sql = "Select HienTruongTamUngID,sodenghi,lydokhongduyet,duyet,price,khongduyet,nguoidenghi,company,charge as Item,tienhoanung,dahoanung,ngaydenghi,bophan,mbl,hbl,currency,hientruongtamung.approve,userupdate,dateupdate "

                sql &= "   From hientruongtamung left join customer on hientruongtamung.customerid=customer.customer_id  left join charge on hientruongtamung.itemid=charge.charge_id where sodenghi like '%" & Me.txtfile.Text & "%' and price > 0 "

               




                oTblEquip = ReadTable(sql)
                Me.DataGridView2.DataSource = oTblEquip


                '--------------------
                Me.Cursor = System.Windows.Forms.Cursors.Default

                InsertAutoNumberToGrid(Me.DataGridView2)
                ' Me.profit()
                ' doi mau do neu other=1
                'Dim i As Integer
                'Try
                '    For i = 0 To Me.DataGridView2.Rows.Count - 1
                '        If Me.DataGridView2.Item("other", i).Value = "True" Then
                '            Me.DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                '            Me.DataGridView2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                '        End If
                '    Next
                'Catch ex As Exception

                'End Try

                'End If
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            queryGrid()
            Dim i, j, k As Integer
            Dim tongtamung, tonghoanung, tongcredit, tongduthieu As Double
            For i = 0 To Me.DataGridView2.RowCount - 1
                Try
                    tongtamung += CDbl(Me.DataGridView2.Item("price_credit_", i).Value)
                Catch ex As Exception

                End Try
                Try
                    tonghoanung += CDbl(Me.DataGridView2.Item("tienhoanung_", i).Value)
                Catch ex As Exception

                End Try

                Try
                    tongduthieu += CDbl(Me.DataGridView2.Item("duthieu", i).Value)
                Catch ex As Exception

                End Try

                Try
                    tongcredit += CDbl(Me.DataGridView2.Item("sotienCredit", i).Value)
                Catch ex As Exception

                End Try
            Next
            Me.txtTongTamung.Text = FormatNumber(tongtamung.ToString, 0)
            Me.txttonghoanung.Text = FormatNumber(tonghoanung.ToString, 0)
            Me.txttiendu.Text = FormatNumber(tongduthieu.ToString, 0)
            Me.txttongcredit.Text = FormatNumber(tongcredit.ToString, 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If Me.DataGridView2.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.DataGridView2, Me)
            'SetMenu(True)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Checkpay()
        Try


            Dim paycheck As Boolean
            Dim rs As New ADODB.Recordset
            ' Xác định vị trí row trong grid
            Dim index As Integer = Me.DataGridView2.CurrentRow.Index
            Dim strQueryDetailBillOfLading_HouseList As String
            ' check
            Dim ds As New DataSet
            Dim sql As String
            sql = "select * from hientruongtamung where HienTruongTamUngID= '" & Me.DataGridView2.Item("HienTruongTamUngID", index).Value.ToString & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                strQueryDetailBillOfLading_HouseList = "Select * from hientruongtamung where" + " HienTruongTamUngID= '" & Me.DataGridView2.Item("HienTruongTamUngID", index).Value.ToString & "'"
                rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                paycheck = Not rs.Fields("DUYET").Value
                rs.Update("duyet", paycheck)
                rs.Update("note", CDate(Getdate()).Date)
                rs.Close()
                'Else
                '    Try
                '        strQueryDetailBillOfLading_HouseList = "Select * from outboundfreight where" + " outboundfreightID= '" & Me.dgddebitGrid.Item("debitid", index).Value.ToString & "'"
                '        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                '        paycheck = Not rs.Fields("paycheck").Value
                '        rs.Update("paycheck", paycheck)
                '        rs.Update("ngay", Me.dtpngaythanhtoan.Value.Date)
                '        rs.Close()
                '    Catch ex As Exception
                '        rs.Close()
                '        strQueryDetailBillOfLading_HouseList = "Select * from logisticsfreight where" + " logisticsfreightID= '" & Me.dgddebitGrid.Item("debitid", index).Value.ToString & "'"
                '        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                '        paycheck = Not rs.Fields("paycheck").Value
                '        rs.Update("paycheck", paycheck)
                '        rs.Update("ngay", Me.dtpngaythanhtoan.Value.Date)
                '        rs.Close()
                '    End Try


            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Public Sub CheckKhongDuyet()
        Try


            Dim paycheck As Boolean
            Dim rs As New ADODB.Recordset
            ' Xác định vị trí row trong grid
            Dim index As Integer = Me.DataGridView2.CurrentRow.Index
            Dim strQueryDetailBillOfLading_HouseList As String
            ' check
            Dim ds As New DataSet
            Dim sql As String
            sql = "select * from hientruongtamung where HienTruongTamUngID= '" & Me.DataGridView2.Item("HienTruongTamUngID", index).Value.ToString & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                strQueryDetailBillOfLading_HouseList = "Select * from hientruongtamung where" + " HienTruongTamUngID= '" & Me.DataGridView2.Item("HienTruongTamUngID", index).Value.ToString & "'"
                rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                paycheck = Not rs.Fields("khongDUYET").Value
                rs.Update("khongduyet", paycheck)
                rs.Update("lydokhongduyet", Me.DataGridView2.Item("lydokhongduyet", index).Value.ToString)
                rs.Close()
                'Else
                '    Try
                '        strQueryDetailBillOfLading_HouseList = "Select * from outboundfreight where" + " outboundfreightID= '" & Me.dgddebitGrid.Item("debitid", index).Value.ToString & "'"
                '        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                '        paycheck = Not rs.Fields("paycheck").Value
                '        rs.Update("paycheck", paycheck)
                '        rs.Update("ngay", Me.dtpngaythanhtoan.Value.Date)
                '        rs.Close()
                '    Catch ex As Exception
                '        rs.Close()
                '        strQueryDetailBillOfLading_HouseList = "Select * from logisticsfreight where" + " logisticsfreightID= '" & Me.dgddebitGrid.Item("debitid", index).Value.ToString & "'"
                '        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                '        paycheck = Not rs.Fields("paycheck").Value
                '        rs.Update("paycheck", paycheck)
                '        rs.Update("ngay", Me.dtpngaythanhtoan.Value.Date)
                '        rs.Close()
                '    End Try


            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub



    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            Try
                Dim ColIndex, RowIndex As Integer
                ' Xác định vị trí row trong grid
                If Me.DataGridView2.RowCount = 0 Then
                    Return
                End If
                Dim index As Integer = Me.DataGridView2.CurrentRow.Index

                ColIndex = e.ColumnIndex()
                RowIndex = e.RowIndex
                If ColIndex < 0 Then
                    Return
                End If
                If UCase(Me.DataGridView2.Columns(ColIndex).Name) = "DUYET" And Me.DataGridView2.CurrentCellAddress.Y = RowIndex Then
                    Call Checkpay()
                    'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
                    'Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
                End If
                If UCase(Me.DataGridView2.Columns(ColIndex).Name) = "KHONGDUYET" And Me.DataGridView2.CurrentCellAddress.Y = RowIndex Then
                    Call CheckKhongDuyet()
                    'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
                    'Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Me.Button1_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles tmrCountdown.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        If ts.TotalMilliseconds > 0 Then
            lblTime.Text = ts.ToString("mm\:ss")
        Else
            lbltime.Text = "00:00"

            tmrCountdown.Interval = 500
            TargetDT = DateTime.Now.Add(CountDownFrom)
            tmrCountdown.Start()
            '  MessageBox.Show("Done")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Me.Button1_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            queryGrid_file()
        Catch ex As Exception

        End Try
    End Sub
End Class