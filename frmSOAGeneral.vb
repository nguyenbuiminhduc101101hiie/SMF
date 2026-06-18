Public Class frmSOAGeneral

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SOA(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal customerid As String, ByVal date_ As String, ByVal nhom As String)
        Try
            Try
                Dim currow As Integer
                ' kiem tra neu co du lieu yhi moi add
                Dim sql As String
                Dim ds As New DataSet
                Dim i As Integer
                Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
                Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
                sql = "select distinct " & TableDeptID & " from " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'  and " & tableFreight & ".customerid='" & customerid & "'  and nhom='" & nhom & "' order by " & TableDeptID & " "
                ds = ReadDataSet(sql)
                Dim m As Integer
                Try
                    For m = 1 To 6
                        Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                    Next
                Catch ex As Exception

                End Try
                Try
                    For m = 6 To 12
                        Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Pink
                    Next
                Catch ex As Exception

                End Try


                Try

                Catch ex As Exception

                End Try
                Dim sqlf_ As String
                Dim dsf_ As New DataSet
                Dim if__ As Integer
                Dim freight20_ As Double = 0
                Dim freight40_ As Double = 0
                Dim freight40hc_ As Double = 0
                Dim freight20rf_ As Double = 0
                Dim freight40rf_ As Double = 0
                Dim freightlcl_ As Double = 0
                '=---------
                Dim freightDOOR_ As Double = 0
                '----------
                Dim freightthc20_ As Double = 0
                Dim freightthc40_ As Double = 0
                Dim freightTHCLCL_ As Double = 0
                Dim freightSEALFEE_ As Double = 0
                Dim freightCFS_ As Double = 0
                Dim freightEBS_ As Double = 0
                Dim freightCIC_ As Double = 0
                Dim freightDDC_ As Double = 0
                Dim freightDEMDET_ As Double = 0
                Dim freightADDCHARGE_ As Double = 0
                Dim freightDOCFEE_ As Double = 0
                Dim freightTELEX_ As Double = 0
                Dim FREIGHTOtherFee_ As Double = 0
                Dim FreightProfitShare As Double = 0
                Dim freightINV_ As String = ""
                Dim freightCLN_ As Double = 0
                Dim freightTHC_ As Double = 0
                Dim thue_ As Double = 0

                Dim tinhtam_ As Double = 0
                Dim sumOF_ As Double = 0
                Dim sumLocal_ As Double = 0
                ' 
                Dim dsdetails As New DataSet

                ' bienotherfee
                Dim fOtherFee_ As Boolean = 0
                Dim id As String
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Item("invoiceno", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        ' lay tung id
                        ' sql = "select * from " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid where CONVERT(DATETIME,datereport) between '" & Me.DateTimePicker1.Value.Date & "' and '" & Me.DateTimePicker2.Value.Date & "'  and customerid='" & customerid & "' and  " & TableDeptID & " ='" & ds.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
                        freight20_ = 0
                        freight40_ = 0
                        freight40hc_ = 0
                        freight20rf_ = 0
                        freight40rf_ = 0
                        freightlcl_ = 0
                        '=---------
                        freightDOOR_ = 0
                        '----------
                        freightthc20_ = 0
                        freightthc40_ = 0
                        freightTHCLCL_ = 0
                        freightSEALFEE_ = 0
                        freightCFS_ = 0
                        freightEBS_ = 0
                        freightCIC_ = 0
                        freightDDC_ = 0
                        freightDEMDET_ = 0
                        freightADDCHARGE_ = 0
                        freightDOCFEE_ = 0
                        freightTELEX_ = 0
                        FREIGHTOtherFee_ = 0
                        FreightProfitShare = 0
                        freightINV_ = ""
                        freightCLN_ = 0
                        freightTHC_ = 0
                        thue_ = 0

                        tinhtam_ = 0
                        sumOF_ = 0
                        sumLocal_ = 0
                        sql = "select * from " & TableDept & " where " & TableDeptID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and nhom='" & nhom & "'  "

                        dsdetails = ReadDataSet(sql)

                        Me.DataGridView1.Rows.Add(1)
                        currow = DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Try
                            id = dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString
                        Catch ex As Exception

                        End Try


                        Try
                            Me.DataGridView1.Item("FLC_", currow).Value = dsdetails.Tables(0).Rows(0).Item("gflc").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.DataGridView1.Item("gsc_", currow).Value = dsdetails.Tables(0).Rows(0).Item("gsc").ToString
                        Catch ex As Exception

                        End Try

                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.DataGridView1.Item("no", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                        Try
                            Me.DataGridView1.Item("invoiceno", currow).Value = dsdetails.Tables(0).Rows(0).Item("Invoiceno").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("ref", currow).Value = dsdetails.Tables(0).Rows(0).Item("ref").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            Me.DataGridView1.Item("mblmawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblcarrier").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("mblmawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("MBL").ToString
                        End Try
                        Try
                            Me.DataGridView1.Item("hblhawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblmawb").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("hblhawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("HBL").ToString
                        End Try

                        'socont

                        '----------------------------------------
                        Try
                            Me.DataGridView1.Item("ngaytkhq", currow).Value = dsdetails.Tables(0).Rows(0).Item("ngayhttthq").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            Me.DataGridView1.Item("ngaytkhq", currow).Value = dsdetails.Tables(0).Rows(0).Item("ngaydangkytokhai").ToString

                        Catch ex As Exception

                        End Try


                        Try
                            Me.DataGridView1.Item("tkhq", currow).Value = dsdetails.Tables(0).Rows(0).Item("tkhq").ToString

                        Catch ex As Exception

                        End Try







                        Try
                            Me.DataGridView1.Item("soxe", currow).Value = dsdetails.Tables(0).Rows(0).Item("voyage").ToString

                        Catch ex As Exception

                        End Try




                        Try
                            Me.DataGridView1.Item("datereport", currow).Value = dsdetails.Tables(0).Rows(0).Item("datereport").ToString

                        Catch ex As Exception

                        End Try


                        Try
                            Me.DataGridView1.Item("DiaDiemNhanTraHang", currow).Value = dsdetails.Tables(0).Rows(0).Item("diadiemnhanhang").ToString + "/" + dsdetails.Tables(0).Rows(0).Item("diadiemgiaohang").ToString

                        Catch ex As Exception

                        End Try

                        '-----------------------------


                        Try
                            Me.DataGridView1.Item("dest", currow).Value = dsdetails.Tables(0).Rows(0).Item("POD").ToString

                        Catch ex As Exception

                        End Try

                     
                        ' lay cus tu 
                        'Dim sqlc As String
                        'Dim dsc As New DataSet
                        ''sqlc = " select * from customer where customer_id= '" & ds.Tables(0).Rows(i).Item("customerid_showtc").ToString & "' "
                        ''dsc = ReadDataSet(sqlc)
                        ''If dsc.Tables(0).Rows.Count > 0 Then
                        ''    Me.DataGridView1.Item("CUSTOMER", currow).Value = dsc.Tables(0).Rows(0).Item("company").ToString
                        ''End If

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
                        Dim socont As String = ""
                        '-------------------

                        sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
                        dscont = ReadDataSet(sqlcont)
                        If dscont.Tables(0).Rows.Count > 0 Then
                            For ic = 0 To dscont.Tables(0).Rows.Count - 1
                                'Try
                                '    kien += CDbl(dscont.Tables(0).Rows(ic).Item("sokien").ToString)
                                'Catch ex As Exception

                                'End Try

                                'Try
                                '    kgs += CDbl(dscont.Tables(0).Rows(ic).Item("sokg").ToString)
                                'Catch ex As Exception

                                'End Try

                                'Try
                                '    khoi += CDbl(dscont.Tables(0).Rows(ic).Item("sokhoi").ToString)
                                'Catch ex As Exception

                                'End Try
                                'If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*20*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                '    cont20 += 1
                                'End If

                                'If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*40*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                '    cont40 += 1
                                'End If

                                'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40HC*") Then
                                '    cont40hc += 1
                                'End If

                                'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*20RF*") Then
                                '    cont20rf += 1
                                'End If

                                'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40RF*") Then
                                '    cont40rf += 1
                                'End If
                                socont += dscont.Tables(0).Rows(ic).Item("containerno").ToString + " "
                            Next

                        End If
                        'If dsdetails.Tables(0).Rows(0).Item("FCL").ToString = True Then
                        '    '
                        '    Dim Scont As String
                        '    If cont20 > 0 Then
                        '        Scont = cont20.ToString + "x20DC;"
                        '    End If
                        '    If cont40 > 0 Then
                        '        Scont += cont40.ToString + "x40DC;"
                        '    End If
                        '    If cont40hc > 0 Then
                        '        Scont += cont40hc.ToString + "x40HC;"
                        '    End If
                        '    If cont20rf > 0 Then
                        '        Scont += cont20rf.ToString + "x20RF;"
                        '    End If

                        '    If cont40rf > 0 Then
                        '        Scont += cont40rf.ToString + "x40RF;"
                        '    End If

                        '    '  Me.DataGridView1.Item("volume", currow).Value = Scont


                        'ElseIf dsdetails.Tables(0).Rows(0).Item("LCL").ToString = True Then

                        '    Me.DataGridView1.Item("volume", currow).Value = khoi.ToString + " CBM"
                        'End If

                        'Me.DataGridView1.Item("destination", currow).Value = dsdetails.Tables(0).Rows(0).Item("POD").ToString
                        'Me.DataGridView1.Item("shippingline", currow).Value = dsdetails.Tables(0).Rows(0).Item("shippingline").ToString

                        Try
                            Me.DataGridView1.Item("socont", currow).Value = socont

                        Catch ex As Exception

                        End Try
                        'DEBIT============================================================================================
                        '==================================================================================================
                        ' CUOC

                        ' THUCHIEN

                        sqlf_ = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid=charge.charge_id where " & tableFreightID & " ='" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "'  and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and paycheck=0  and os=0 "

                        dsf_ = ReadDataSet(sqlf_)
                        Dim tongdebit As Double = 0
                        Dim tongcredit As Double = 0
                        Dim invoicenocredit As String = ""
                        Dim invoicenodebit As String = ""
                        Dim ghichu As String = ""
                        If dsf_.Tables(0).Rows.Count > 0 Then
                            For if__ = 0 To dsf_.Tables(0).Rows.Count - 1

                                'fOtherFee_ = False 
                                If Me.chkVND.Checked = True Then
                                    If dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "VND" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) ' / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    ElseIf dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "USD" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) * CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    End If
                                Else
                                    If dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "USD" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) ' / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    ElseIf dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "VND" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    End If
                                End If


                                If dsf_.Tables(0).Rows(if__).Item("DebitCredit").ToString = "Debit" Then
                                    Try
                                        tongdebit += tinhtam_
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        invoicenodebit += dsf_.Tables(0).Rows(if__).Item("ngayhoadon").ToString + ";"
                                    Catch ex As Exception

                                    End Try

                                ElseIf dsf_.Tables(0).Rows(if__).Item("DebitCredit").ToString = "Credit" Then
                                    Try
                                        tongcredit += tinhtam_
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        invoicenocredit += dsf_.Tables(0).Rows(if__).Item("ngayhoadon").ToString + ";"
                                    Catch ex As Exception

                                    End Try
                                End If
                                Try
                                    ghichu += dsf_.Tables(0).Rows(if__).Item("note").ToString + "/"
                                Catch ex As Exception

                                End Try

                            Next

                        End If
                        Try
                            Me.DataGridView1.Item("description", currow).Value = ghichu

                        Catch ex As Exception

                        End Try
                        ' dua cac phi vao
                        Me.DataGridView1.Item("debit", currow).Value = FormatNumber(tongdebit, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Me.DataGridView1.Item("credit", currow).Value = FormatNumber(tongcredit, 3)
                        Me.DataGridView1.Item("invoiceno", currow).Value = invoicenocredit
                        Me.DataGridView1.Item("gmdinvoiceno", currow).Value = invoicenodebit
                        If tongdebit - tongcredit > 0 Then
                            Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", currow).Value = FormatNumber(tongdebit - tongcredit, 3)
                        ElseIf tongdebit - tongcredit < 0 Then
                            Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", currow).Value = FormatNumber(IIf(tongdebit - tongcredit < 0, (tongdebit - tongcredit) * (-1), tongdebit - tongcredit), 3)

                        End If
                        Me.DataGridView1.Item("gmdprofit", currow).Value = FormatNumber(P_profit(tableFreight, tableFreightID, id), 3)

                    Next

                End If


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SOA_Bkno(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal customerid As String, ByVal date_ As String, ByVal nhom As String)
        Try
            Try
                Dim currow As Integer
                ' kiem tra neu co du lieu yhi moi add
                Dim sql As String
                Dim ds As New DataSet
                Dim i As Integer
                Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
                Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
                sql = "select distinct " & TableDeptID & " from " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'  and " & tableFreight & ".customerid='" & customerid & "'  and nhom='" & nhom & "' and  bkno='" & Me.cboBKNo.Text & "' order by " & TableDeptID & " "
                ds = ReadDataSet(sql)
                Dim m As Integer
                Try
                    For m = 1 To 6
                        Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                    Next
                Catch ex As Exception

                End Try
                Try
                    For m = 6 To 12
                        Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Pink
                    Next
                Catch ex As Exception

                End Try


                Try

                Catch ex As Exception

                End Try
                Dim sqlf_ As String
                Dim dsf_ As New DataSet
                Dim if__ As Integer
                Dim freight20_ As Double = 0
                Dim freight40_ As Double = 0
                Dim freight40hc_ As Double = 0
                Dim freight20rf_ As Double = 0
                Dim freight40rf_ As Double = 0
                Dim freightlcl_ As Double = 0
                '=---------
                Dim freightDOOR_ As Double = 0
                '----------
                Dim freightthc20_ As Double = 0
                Dim freightthc40_ As Double = 0
                Dim freightTHCLCL_ As Double = 0
                Dim freightSEALFEE_ As Double = 0
                Dim freightCFS_ As Double = 0
                Dim freightEBS_ As Double = 0
                Dim freightCIC_ As Double = 0
                Dim freightDDC_ As Double = 0
                Dim freightDEMDET_ As Double = 0
                Dim freightADDCHARGE_ As Double = 0
                Dim freightDOCFEE_ As Double = 0
                Dim freightTELEX_ As Double = 0
                Dim FREIGHTOtherFee_ As Double = 0
                Dim FreightProfitShare As Double = 0
                Dim freightINV_ As String = ""
                Dim freightCLN_ As Double = 0
                Dim freightTHC_ As Double = 0
                Dim thue_ As Double = 0

                Dim tinhtam_ As Double = 0
                Dim sumOF_ As Double = 0
                Dim sumLocal_ As Double = 0
                ' 
                Dim dsdetails As New DataSet

                ' bienotherfee
                Dim fOtherFee_ As Boolean = 0
                Dim id As String
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Item("invoiceno", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        ' lay tung id
                        ' sql = "select * from " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid where CONVERT(DATETIME,datereport) between '" & Me.DateTimePicker1.Value.Date & "' and '" & Me.DateTimePicker2.Value.Date & "'  and customerid='" & customerid & "' and  " & TableDeptID & " ='" & ds.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
                        freight20_ = 0
                        freight40_ = 0
                        freight40hc_ = 0
                        freight20rf_ = 0
                        freight40rf_ = 0
                        freightlcl_ = 0
                        '=---------
                        freightDOOR_ = 0
                        '----------
                        freightthc20_ = 0
                        freightthc40_ = 0
                        freightTHCLCL_ = 0
                        freightSEALFEE_ = 0
                        freightCFS_ = 0
                        freightEBS_ = 0
                        freightCIC_ = 0
                        freightDDC_ = 0
                        freightDEMDET_ = 0
                        freightADDCHARGE_ = 0
                        freightDOCFEE_ = 0
                        freightTELEX_ = 0
                        FREIGHTOtherFee_ = 0
                        FreightProfitShare = 0
                        freightINV_ = ""
                        freightCLN_ = 0
                        freightTHC_ = 0
                        thue_ = 0

                        tinhtam_ = 0
                        sumOF_ = 0
                        sumLocal_ = 0
                        sql = "select * from " & TableDept & " where " & TableDeptID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and nhom='" & nhom & "'  "

                        dsdetails = ReadDataSet(sql)

                        Me.DataGridView1.Rows.Add(1)
                        currow = DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Try
                            id = dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString
                        Catch ex As Exception

                        End Try






                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.DataGridView1.Item("no", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                        Try
                            Me.DataGridView1.Item("invoiceno", currow).Value = dsdetails.Tables(0).Rows(0).Item("Invoiceno").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("ref", currow).Value = dsdetails.Tables(0).Rows(0).Item("ref").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            Me.DataGridView1.Item("mblmawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblcarrier").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("mblmawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("MBL").ToString
                        End Try
                        Try
                            Me.DataGridView1.Item("hblhawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblmawb").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("hblhawb", currow).Value = dsdetails.Tables(0).Rows(0).Item("HBL").ToString
                        End Try



                        '----------------------------------------
                        Try
                            Me.DataGridView1.Item("ngaytkhq", currow).Value = dsdetails.Tables(0).Rows(0).Item("ngayhttthq").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            Me.DataGridView1.Item("ngaytkhq", currow).Value = dsdetails.Tables(0).Rows(0).Item("ngaydangkytokhai").ToString

                        Catch ex As Exception

                        End Try


                        Try
                            Me.DataGridView1.Item("tkhq", currow).Value = dsdetails.Tables(0).Rows(0).Item("tkhq").ToString

                        Catch ex As Exception

                        End Try













                        '-----------------------------


                        Try
                            Me.DataGridView1.Item("dest", currow).Value = dsdetails.Tables(0).Rows(0).Item("POD").ToString

                        Catch ex As Exception

                        End Try


                        ' lay cus tu 
                        'Dim sqlc As String
                        'Dim dsc As New DataSet
                        ''sqlc = " select * from customer where customer_id= '" & ds.Tables(0).Rows(i).Item("customerid_showtc").ToString & "' "
                        ''dsc = ReadDataSet(sqlc)
                        ''If dsc.Tables(0).Rows.Count > 0 Then
                        ''    Me.DataGridView1.Item("CUSTOMER", currow).Value = dsc.Tables(0).Rows(0).Item("company").ToString
                        ''End If

                        '' kiem tra cont
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

                        'sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
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
                        'If dsdetails.Tables(0).Rows(0).Item("FCL").ToString = True Then
                        '    '
                        '    Dim Scont As String
                        '    If cont20 > 0 Then
                        '        Scont = cont20.ToString + "x20DC;"
                        '    End If
                        '    If cont40 > 0 Then
                        '        Scont += cont40.ToString + "x40DC;"
                        '    End If
                        '    If cont40hc > 0 Then
                        '        Scont += cont40hc.ToString + "x40HC;"
                        '    End If
                        '    If cont20rf > 0 Then
                        '        Scont += cont20rf.ToString + "x20RF;"
                        '    End If

                        '    If cont40rf > 0 Then
                        '        Scont += cont40rf.ToString + "x40RF;"
                        '    End If

                        '    Me.DataGridView1.Item("volume", currow).Value = Scont


                        'ElseIf dsdetails.Tables(0).Rows(0).Item("LCL").ToString = True Then

                        '    Me.DataGridView1.Item("volume", currow).Value = khoi.ToString + " CBM"
                        'End If

                        'Me.DataGridView1.Item("destination", currow).Value = dsdetails.Tables(0).Rows(0).Item("POD").ToString
                        'Me.DataGridView1.Item("shippingline", currow).Value = dsdetails.Tables(0).Rows(0).Item("shippingline").ToString


                        'DEBIT============================================================================================
                        '==================================================================================================
                        ' CUOC

                        ' THUCHIEN

                        sqlf_ = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid=charge.charge_id where " & tableFreightID & " ='" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "'  and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and paycheck=0 "

                        dsf_ = ReadDataSet(sqlf_)
                        Dim tongdebit As Double = 0
                        Dim tongcredit As Double = 0
                        Dim invoicenocredit As String = ""
                        Dim invoicenodebit As String = ""
                        Dim ghichu As String = ""
                        If dsf_.Tables(0).Rows.Count > 0 Then
                            For if__ = 0 To dsf_.Tables(0).Rows.Count - 1

                                'fOtherFee_ = False 
                                If Me.chkVND.Checked = True Then
                                    If dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "VND" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) ' / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    ElseIf dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "USD" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) * CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    End If
                                Else
                                    If dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "USD" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) ' / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    ElseIf dsf_.Tables(0).Rows(if__).Item("Currency").ToString = "VND" Then
                                        tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("price").ToString) / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                    End If
                                End If


                                If dsf_.Tables(0).Rows(if__).Item("DebitCredit").ToString = "Debit" Then
                                    Try
                                        tongdebit += tinhtam_
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        invoicenodebit += dsf_.Tables(0).Rows(if__).Item("ngayhoadon").ToString + ";"
                                    Catch ex As Exception

                                    End Try

                                ElseIf dsf_.Tables(0).Rows(if__).Item("DebitCredit").ToString = "Credit" Then
                                    Try
                                        tongcredit += tinhtam_
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        invoicenocredit += dsf_.Tables(0).Rows(if__).Item("ngayhoadon").ToString + ";"
                                    Catch ex As Exception

                                    End Try
                                End If
                                Try
                                    ghichu += dsf_.Tables(0).Rows(if__).Item("note").ToString + "/"
                                Catch ex As Exception

                                End Try

                            Next

                        End If
                        Try
                            Me.DataGridView1.Item("description", currow).Value = ghichu

                        Catch ex As Exception

                        End Try
                        ' dua cac phi vao
                        Me.DataGridView1.Item("debit", currow).Value = FormatNumber(tongdebit, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Me.DataGridView1.Item("credit", currow).Value = FormatNumber(tongcredit, 3)
                        Me.DataGridView1.Item("invoiceno", currow).Value = invoicenocredit
                        Me.DataGridView1.Item("gmdinvoiceno", currow).Value = invoicenodebit
                        If tongdebit - tongcredit > 0 Then
                            Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", currow).Value = FormatNumber(tongdebit - tongcredit, 3)
                        ElseIf tongdebit - tongcredit < 0 Then
                            Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", currow).Value = FormatNumber(IIf(tongdebit - tongcredit < 0, (tongdebit - tongcredit) * (-1), tongdebit - tongcredit), 3)

                        End If
                        Me.DataGridView1.Item("gmdprofit", currow).Value = FormatNumber(P_profit(tableFreight, tableFreightID, id), 3)

                    Next

                End If


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Me.DataGridView1.Rows.Clear()

            'Agency(-Import)
            'Agency(-Export)
            'Domestic(-Rail)
            'Domestic(-Truck)
            'Logistics(-Customs)
            'Oversea(-Sea - Import)
            'Oversea(-Sea - Export)
            'ACS(-Air - Import)
            'ACS(-Air - Export)
            'ACS(-Sea - Export)
            If Me.chkVND.Checked = True Then

                gUSDVNDSoa = "VND"
            Else

                gUSDVNDSoa = "USD"
            End If



            If Me.chkYamato.Checked = True Then
                Me.DataGridView1.Columns("AMOUNTCOLLECTBYGMDUSD").Visible = False
                Me.DataGridView1.Columns("AMOUNTPAIDBYGMDUSD").Visible = False
                Me.DataGridView1.Columns("GMDINVOICENO").Visible = False
                'Me.DataGridView1.Columns("GMDprofit").Visible = False
            Else
                Me.DataGridView1.Columns("AMOUNTCOLLECTBYGMDUSD").Visible = True
                Me.DataGridView1.Columns("AMOUNTPAIDBYGMDUSD").Visible = True
                Me.DataGridView1.Columns("GMDINVOICENO").Visible = True
                'Me.DataGridView1.Columns("GMDprofit").Visible = True
            End If
            If Me.chkall.Checked = True Then

                SOA("Agency-Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "Agency-Import")
                ' SOA("COC-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "COC-IMPORT")



                SOA("Agency-Export", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "Agency-Export")
                ' SOA("COC-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "COC-EXPORT")




                SOA("ACS-Air-Import", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "ACS-Air-Import")


                SOA("ACS-Air-Export", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "ACS-Air-Export")

                SOA("LOGISTICS-CUSTOMS", "Logistics", "blob_id", "containerlogistics", "outboundID", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "LOGISTICS-CUSTOMS")


            Else
                If UCase(Me.ComboBox2.Text) = "AGENCY-IMPORT" Then
                    SOA("Agency-Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "Agency-Import")

                End If

                'If Me.ComboBox2.Text = "COC-IMPORT" Then
                '    SOA("COC-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "COC-IMPORT")

                'End If


                If UCase(Me.ComboBox2.Text) = "AGENCY-EXPORT" Then
                    SOA("AGENCY-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "AGENCY-EXPORT")

                End If
                'If Me.ComboBox2.Text = "COC-EXPORT" Then
                '    SOA("COC-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "COC-EXPORT")


                'End If


                If UCase(Me.ComboBox2.Text) = "ACS-AIR-IMPORT" Then
                    SOA("ACS-AIR-IMPORT", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "ACS-AIR-IMPORT")


                End If
                If UCase(Me.ComboBox2.Text) = "ACS-AIR-EXPORT" Then
                    SOA("ACS-AIR-EXPORT", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "ACS-AIR-EXPORT")

                End If
                If UCase(Me.ComboBox2.Text) = "LOGISTICS-CUSTOMS" Then
                    SOA("LOGISTICS-CUSTOMS", "Logistics", "blob_id", "containerlogistics", "outboundID", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "LOGISTICS-CUSTOMS")

                End If


            End If

            ' tog
            Dim tdebit As Double = 0
            Dim tcredit As Double = 0


            Dim amount1 As Double = 0
            Dim amount2 As Double = 0

            Dim profit As Double = 0

            Dim it As Integer

            For it = 0 To Me.DataGridView1.RowCount - 1
                Try
                    tdebit += Me.DataGridView1.Item("debit", it).Value.ToString
                Catch ex As Exception

                End Try

                Try
                    tcredit += Me.DataGridView1.Item("credit", it).Value.ToString
                Catch ex As Exception

                End Try
                Try
                    amount1 += Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", it).Value.ToString
                Catch ex As Exception

                End Try
                Try
                    amount2 += Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", it).Value.ToString
                Catch ex As Exception

                End Try

                Try
                    profit += Me.DataGridView1.Item("gmdprofit", it).Value.ToString
                Catch ex As Exception

                End Try


            Next
            ' ghi vao
            Dim currow As Integer
            Me.DataGridView1.Rows.Add(1)
            currow = DataGridView1.RowCount - 2
            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
            Me.DataGridView1.Item("DESCRIPTION", currow).Value = "Total"
            Me.DataGridView1.Item("debit", currow).Value = FormatNumber(tdebit, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
            Me.DataGridView1.Item("credit", currow).Value = FormatNumber(tcredit, 3)

            Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", currow).Value = FormatNumber(amount1, 3)

            Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", currow).Value = FormatNumber(amount2, 3)
            Try

                Me.DataGridView1.Item("gmdprofit", currow).Value = FormatNumber(profit, 3)
            Catch ex As Exception

            End Try


            '-




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.TextBox2.Text & "%' or taxcode like '%" & Me.TextBox2.Text & "%' and continued=1 order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocus, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub querycombo()
        Try
            Dim id_, id As String
            Dim value_, value As String
            Dim strQuery_, strQuery, strSQL As String


            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where CONTINUED=1 Order by company "
            Me.cbocus.Items.Clear()
            loadDataToObject(Me.cbocus, strQuery, id, value)

            id = "tablename"
            value = "viewername"
            Me.ComboBox2.Items.Clear()


            strSQL = "Select tablename,viewername From listdept order by viewername "
            loadDataToObject(Me.ComboBox2, strSQL, id, value)


            id = "BookingAgentID"
            value = "gmd_bookingno"
            strQuery = "Select BookingAgentID,gmd_bookingno  from bookingagent  Order by gmd_bookingno "
            Me.cboBKNo.Items.Clear()
            loadDataToObject(Me.cboBKNo, strQuery, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSOAGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            querycombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            ' xoatable
            '---------------------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim sqldebit, strQuery As String
            Dim CmdSelect As New SqlClient.SqlCommand(sqldebit, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from frmPrintSOAGeneral  "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            '' them
            Dim rs As New ADODB.Recordset
            Dim i As Integer
            Dim tongdebit As Double = 0
            Dim tongcredit As Double = 0
            Try
                gSOACus = FindValueID(cbocus, cbocus.Text)
            Catch ex As Exception

            End Try

            If Me.DataGridView1.RowCount > 0 Then

                For i = 0 To Me.DataGridView1.RowCount - 3

                    Try
                        tongdebit += CDbl(Me.DataGridView1.Item("debit", i).Value)
                        tongcredit += CDbl(Me.DataGridView1.Item("credit", i).Value)
                    Catch ex As Exception

                    End Try
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM frmPrintSOAGeneral "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()


                        '-------------------------
                        .Fields("no").Value = Me.DataGridView1.Item("no", i).Value

                        .Fields("invoiceno").Value = Me.DataGridView1.Item("invoiceno", i).Value

                        .Fields("mblmawb").Value = Me.DataGridView1.Item("mblmawb", i).Value

                        .Fields("hblhawb").Value = Me.DataGridView1.Item("hblhawb", i).Value
                        .Fields("dest").Value = Me.DataGridView1.Item("dest", i).Value
                        .Fields("description").Value = Me.DataGridView1.Item("description", i).Value
                        Try
                            .Fields("debit").Value = Me.DataGridView1.Item("debit", i).Value
                        Catch ex As Exception
                            .Fields("debit").Value = 0
                        End Try
                        Try
                            .Fields("credit").Value = Me.DataGridView1.Item("credit", i).Value
                        Catch ex As Exception
                            .Fields("credit").Value = 0
                        End Try
                        Try
                            .Fields("AMOUNTCOLLECTBYGMDUSD").Value = Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", i).Value
                        Catch ex As Exception
                            .Fields("AMOUNTCOLLECTBYGMDUSD").Value = 0
                        End Try
                        Try
                            .Fields("AMOUNTPAIDBYGMDUSD").Value = Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", i).Value
                        Catch ex As Exception
                            .Fields("AMOUNTPAIDBYGMDUSD").Value = 0
                        End Try

                        .Fields("GMDINVOICENO").Value = Me.DataGridView1.Item("GMDINVOICENO", i).Value
                        Try
                            .Fields("GMDPROFIT").Value = Me.DataGridView1.Item("GMDPROFIT", i).Value
                        Catch ex As Exception
                            .Fields("GMDPROFIT").Value = 0
                        End Try




                        .Update()
                    End With
                    rs.Close()
                Next
            End If
            '  ds.Tables.Add(dtdebit)
            '  frmPrintSOAGeneral.Show()
            If LoginSucceeded = True Then
                Dim form As New frmPrintSOAGeneral 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
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

    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        Try
            ' load so ref vao, where bo phan
            'If Me.chkall.Checked = True Then
            '    ' lay ref 
            'Else

            'End If

            '-------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub layref(ByVal cusid As String, ByVal dept As String, ByVal deptFreight As String)
        Try
            'Dim sql As String
            'Dim ds As New DataSet(sql)
            'sql = "select ref from " & dept & " left join " & deptFreight & " on   where  "

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try

            Try
                Me.DataGridView1.Rows.Clear()

                'Agency(-Import)
                'Agency(-Export)
                'Domestic(-Rail)
                'Domestic(-Truck)
                'Logistics(-Customs)
                'Oversea(-Sea - Import)
                'Oversea(-Sea - Export)
                'ACS(-Air - Import)
                'ACS(-Air - Export)
                'ACS(-Sea - Export)
                If Me.chkVND.Checked = True Then

                    gUSDVNDSoa = "VND"
                Else

                    gUSDVNDSoa = "USD"
                End If



                If Me.chkYamato.Checked = True Then
                    Me.DataGridView1.Columns("AMOUNTCOLLECTBYGMDUSD").Visible = False
                    Me.DataGridView1.Columns("AMOUNTPAIDBYGMDUSD").Visible = False
                    Me.DataGridView1.Columns("GMDINVOICENO").Visible = False
                    'Me.DataGridView1.Columns("GMDprofit").Visible = False
                Else
                    Me.DataGridView1.Columns("AMOUNTCOLLECTBYGMDUSD").Visible = True
                    Me.DataGridView1.Columns("AMOUNTPAIDBYGMDUSD").Visible = True
                    Me.DataGridView1.Columns("GMDINVOICENO").Visible = True
                    'Me.DataGridView1.Columns("GMDprofit").Visible = True
                End If
                If Me.chkall.Checked = True Then

                    SOA_Bkno("Agency-Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "Agency-Import")
                    ' SOA("COC-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "COC-IMPORT")



                    SOA_Bkno("Agency-Export", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "Agency-Export")
                    ' SOA("COC-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "COC-EXPORT")




                    SOA_Bkno("ACS-Air-Import", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "ACS-Air-Import")


                    SOA_Bkno("ACS-Air-Export", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "ACS-Air-Export")

                    SOA_Bkno("LOGISTICS-CUSTOMS", "Logistics", "blob_id", "containertype", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "LOGISTICS-CUSTOMS")


                Else
                    If UCase(Me.ComboBox2.Text) = "AGENCY-IMPORT" Then
                        SOA_Bkno("Agency-Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "Agency-Import")

                    End If

                    'If Me.ComboBox2.Text = "COC-IMPORT" Then
                    '    SOA("COC-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "COC-IMPORT")

                    'End If


                    If UCase(Me.ComboBox2.Text) = "AGENCY-EXPORT" Then
                        SOA_Bkno("AGENCY-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "AGENCY-EXPORT")

                    End If
                    'If Me.ComboBox2.Text = "COC-EXPORT" Then
                    '    SOA("COC-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "COC-EXPORT")


                    'End If


                    If UCase(Me.ComboBox2.Text) = "ACS-AIR-IMPORT" Then
                        SOA_Bkno("ACS-AIR-IMPORT", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "ACS-AIR-IMPORT")


                    End If
                    If UCase(Me.ComboBox2.Text) = "ACS-AIR-EXPORT" Then
                        SOA_Bkno("ACS-AIR-EXPORT", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "ACS-AIR-EXPORT")

                    End If
                    If UCase(Me.ComboBox2.Text) = "LOGISTICS-CUSTOMS" Then
                        SOA_Bkno("LOGISTICS-CUSTOMS", "Logistics", "blob_id", "containertype", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "LOGISTICS-CUSTOMS")

                    End If


                End If

                ' tog
                Dim tdebit As Double = 0
                Dim tcredit As Double = 0


                Dim amount1 As Double = 0
                Dim amount2 As Double = 0

                Dim profit As Double = 0

                Dim it As Integer

                For it = 0 To Me.DataGridView1.RowCount - 1
                    Try
                        tdebit += Me.DataGridView1.Item("debit", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tcredit += Me.DataGridView1.Item("credit", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        amount1 += Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        amount2 += Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        profit += Me.DataGridView1.Item("gmdprofit", it).Value.ToString
                    Catch ex As Exception

                    End Try


                Next
                ' ghi vao
                Dim currow As Integer
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                Me.DataGridView1.Item("DESCRIPTION", currow).Value = "Total"
                Me.DataGridView1.Item("debit", currow).Value = FormatNumber(tdebit, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                Me.DataGridView1.Item("credit", currow).Value = FormatNumber(tcredit, 3)

                Me.DataGridView1.Item("AMOUNTCOLLECTBYGMDUSD", currow).Value = FormatNumber(amount1, 3)

                Me.DataGridView1.Item("AMOUNTPAIDBYGMDUSD", currow).Value = FormatNumber(amount2, 3)
                Try

                    Me.DataGridView1.Item("gmdprofit", currow).Value = FormatNumber(profit, 3)
                Catch ex As Exception

                End Try


                '-




            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class