Public Class frmShipmentFollowDO
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -65281
            Dim i As Integer
         
            Me.DataGridView1.Rows.Clear()
            If UCase(gBranch) = "" Then
              
                sql = "select * from inbound where ref='" & Me.cboref.Text & "' and  convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
               
            Else

               
                sql = "select * from inbound where  ref='" & Me.cboref.Text & "' and (convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "') and branch like '%" & gBranch & "%'"
                
            End If


            ds = ReadDataSet(sql)
            '' hang nhap

            If ds.Tables(0).Rows.Count > 0 Then
                ' ung moi dong tga lay so lieu
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    mau -= 100
                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                    Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'ds.Tables(0).Rows(i).Item("ref").ToString
                    Me.DataGridView1.Item("Column2", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString 'ds.Tables(0).Rows(i).Item("bl_type").ToString
               
                   
                    Me.DataGridView1.Item("Column3", currow).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    Me.DataGridView1.Item("Column4", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Me.DataGridView1.Item("Column5", currow).Value = ds.Tables(0).Rows(i).Item("bl_type").ToString
                    Me.DataGridView1.Item("Column6", currow).Value = ds.Tables(0).Rows(i).Item("consignee").ToString


                    '' lay thong tin shipper
                    'Dim sqlShipper As String
                    'Dim dsShipper As New DataSet
                    'If ds.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                    '    sqlShipper = "select * from customer where company like '%" & ds.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                    '    dsShipper = ReadDataSet(sqlShipper)
                    '    If dsShipper.Tables(0).Rows.Count > 0 Then
                    '        Me.DataGridView1.Item("Column4", currow).Value = dsShipper.Tables(0).Rows(0).Item("company").ToString
                    '        Me.DataGridView1.Item("Column5", currow).Value = dsShipper.Tables(0).Rows(0).Item("address").ToString
                    '        Me.DataGridView1.Item("Column6", currow).Value = dsShipper.Tables(0).Rows(0).Item("tel").ToString
                    '        Me.DataGridView1.Item("Column7", currow).Value = dsShipper.Tables(0).Rows(0).Item("fax").ToString



                    '    Else
                    '        Dim s() As String
                    '        s = ds.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                    '        Try
                    '            Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                    '        Catch ex As Exception

                    '        End Try
                    '        Try
                    '            Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                    '        Catch ex As Exception

                    '        End Try
                    '        Try
                    '            Me.DataGridView1.Item("Column6", currow).Value = s(3)
                    '        Catch ex As Exception

                    '        End Try
                    '        Try
                    '            Me.DataGridView1.Item("Column7", currow).Value = s(4)
                    '        Catch ex As Exception

                    '        End Try

                    '    End If
                    'End If

                    'Me.DataGridView1.Item("Column8", currow).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString & "/" & ds.Tables(0).Rows(i).Item("tkhq").ToString
                    'ta co so mblmawb, ta lay thong so container
                    Dim j As Integer
                    Dim sqlCont As String = ""
                    Dim dsCont As New DataSet
                    '---
                    Dim kg As Double = 0
                    Dim kien As Double = 0
                    Dim khoi As Double = 0
                    Dim cont As String = ""
                    Dim type As String = ""
                    Dim cont20 As Integer = 0
                    Dim cont40 As Integer = 0

                    sqlCont = "select * from containerrepair where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                    dsCont = ReadDataSet(sqlCont)
                    If dsCont.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dsCont.Tables(0).Rows.Count - 1
                            Try
                                kg += CDbl(dsCont.Tables(0).Rows(j).Item("sokg").ToString)
                            Catch ex As Exception

                            End Try
                            Try
                                kien += CDbl(dsCont.Tables(0).Rows(j).Item("sokien").ToString)
                            Catch ex As Exception

                            End Try
                            Try
                                khoi += CDbl(dsCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                            Catch ex As Exception

                            End Try

                            Try
                                cont += dsCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                            Catch ex As Exception

                            End Try
                            type = dsCont.Tables(0).Rows(j).Item("type").ToString
                            'dme(soluong)
                            If dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                cont20 += 1
                            Else
                                cont40 += 1
                            End If
                            ' 
                        Next
                    End If
                    ' them vao excel
                    Me.DataGridView1.Item("Column7", currow).Value = FormatNumber(kg.ToString, 3) 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                    Me.DataGridView1.Item("Column8", currow).Value = FormatNumber(khoi.ToString, 3) 'FormatNumber(kien.ToString, 0) & " " & type


                    'Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                    'Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                    'Me.DataGridView1.Item("Column13", currow).Value = cont
                    ''---------------------------------------------------

                    ''truong hop hang xuat
                    'Me.DataGridView1.Item("Column15", currow).Value = ds.Tables(0).Rows(i).Item("importCy").ToString
                    'Me.DataGridView1.Item("Column16", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString
                    'Me.DataGridView1.Item("Column17", currow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString

                    'Me.DataGridView1.Item("Column19", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString
                    'Me.DataGridView1.Item("Column20", currow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                    'Me.DataGridView1.Item("Column21", currow).Value = ds.Tables(0).Rows(i).Item("description").ToString
                    ' ngay tau di den
                    'Try
                    '    Me.DataGridView1.Item("Column22", currow).Value = CDate(ds.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(ds.Tables(0).Rows(i).Item("eta").ToString).Date

                    'Catch ex As Exception

                    'End Try
                    '--- phi da thu
                    Dim sqlPhi As String = ""
                    Dim dsphi As New DataSet
                    Dim k As Integer
                    Dim tenphi As String = ""
                    Dim tongthuUSD As Double = 0
                    Dim tongthuVND As Double = 0
                    Dim tongchiUSD As Double = 0
                    sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' "
                    dsphi = ReadDataSet(sqlPhi)
                    If dsphi.Tables(0).Rows.Count > 0 Then
                        For k = 0 To dsphi.Tables(0).Rows.Count - 1
                            If dsphi.Tables(0).Rows(k).Item("currency").ToString = "USD" Then
                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                    tongthuUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                    tongthuVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)

                                End If
                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                    tongchiUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)

                                End If
                            End If

                            tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                        Next
                    End If
                    Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuVND.ToString, 2)
                    Me.DataGridView1.Item("Column10", currow).Value = ds.Tables(0).Rows(i).Item("nguoinhanlenh").ToString & " / " & ds.Tables(0).Rows(i).Item("ngaynhanlenh").ToString
                    '-------------------------------------------
                    Me.DataGridView1.Item("Column11", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                    Me.DataGridView1.Item("Column12", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString & "/" & ds.Tables(0).Rows(i).Item("voyage").ToString


                    '---
                    '----------------------------------

                Next
            End If

            '--------------------------------------------------------------------------------------------------------------------
            ' logistics
            ' lay total
            'Dim tongcont20, tongcont40 As Integer
            'Dim tongthu, tongchi As Double
            Dim tongkg, tongcbm, tongthu As Double
            tongkg = 0
            tongcbm = 0
            tongthu = 0


            Dim it As Integer = 0
            For it = 0 To Me.DataGridView1.RowCount - 1
                tongkg += CDbl(Me.DataGridView1.Item("Column7", it).Value)
                tongcbm += CDbl(Me.DataGridView1.Item("Column8", it).Value)
                tongthu += CDbl(Me.DataGridView1.Item("Column9", it).Value)

            Next
            Me.DataGridView1.Item("Column6", currow + 1).Value = "Total"
            Me.DataGridView1.Item("Column7", currow + 1).Value = FormatNumber(tongkg.ToString, 3)
            Me.DataGridView1.Item("Column8", currow + 1).Value = FormatNumber(tongcbm.ToString, 3)
            Me.DataGridView1.Item("Column9", currow + 1).Value = FormatNumber(tongthu.ToString, 2)
            'Me.DataGridView1.Item("Column10", currow + 1).Value = FormatNumber(tongchi.ToString, 2)


            '--------------------
            InsertAutoNumberToGrid(Me.DataGridView1)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Try
                If Me.DataGridView1.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                ExportExecel(Me.DataGridView1, Me)
                'SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim id, value, strSQL As String
            'Me.cboMBL.Items.Clear()
            'id = "mbl"
            'value = "MBL"
            'strSQL = "Select distinct MBL,MBL From inbound where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1 "
            'loadDataToObject(Me.cboMBL, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Try
                Dim iuser As Integer
                Dim id, value, strSQL As String
                Me.cboref.Text = ""
                Me.cboref.Items.Clear()
                id = "ref"
                value = "ref"
                ' 
                If gDepartment = "Sale" Then

                    strSQL = "Select distinct ref,ref From inbound where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1 and salecode='" & strUserId & "' and branch like '%" & gBranch & "%' "
                    loadDataToObject(Me.cboref, strSQL, id, value)
                    Me.cboref.Enabled = True
                ElseIf gDepartment = "SaleManager" Then
                    ' lay user
                    ' luu y usrluon luon= salecode thi moi dung
                    Dim sqluser As String
                    Dim dsuser As New DataSet
                    strSQL = "Select distinct ref,ref From inbound where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1  and branch like '%" & gBranch & "%' "

                    sqluser = "select * from userlist where manager1='" & strUserId & "' "

                    dsuser = ReadDataSet(sqluser)
                    If dsuser.Tables(0).Rows.Count > 0 Then
                        If dsuser.Tables(0).Rows.Count > 1 Then
                            For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                If iuser = 0 Then
                                    strSQL += " and (salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                Else
                                    strSQL += " or salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                End If



                            Next
                        Else
                            For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                strSQL += " and (salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                            Next
                        End If

                    End If
                    strSQL += ")"

                    loadDataToObject(Me.cboref, strSQL, id, value)
                    Me.cboref.Enabled = True
                Else
                    strSQL = "Select distinct ref,ref From inbound where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1  and branch like '%" & gBranch & "%' "
                    loadDataToObject(Me.cboref, strSQL, id, value)
                    Me.cboref.Enabled = True
                    'Me.cboRef.Enabled = False
                End If


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class