Public Class frmCantruCongnoInbound
    'Public dsdataBookingInfor As New DataSet
    Dim t1usd, t1vnd, t2usd, t2vnd As Double
    Sub QueryAgency()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        Me.cboagencyname.Items.Clear()
        'id = "agency_id"
        'value = "agencyname"
        'strSQL = "Select agency_id,  agencyname From agency  where continued=1 Order By agencyname"
        'loadDataToObject_(Me.cboagencyname, strSQL, id, value)

        id = "Customer_id"
        value = "Company"
        strSQL = "Select Customer_id,  company From customer  where continued=1 Order By company"
        loadDataToObject_(Me.cboagencyname, strSQL, id, value)

        'id = "Shippinglineid"
        'value = "Shippingline"
        'strSQL = "Select Shippinglineid,  Shippingline From Shippingline  where continued=1 Order By Shippingline "
        'loadDataToObject_(Me.cboagencyname, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim sql, sqlF As String
            Dim i, j, k As Integer
            Dim ds As New DataSet
            Dim dsF, dsFVND, dsFC, dsFCVND As New DataSet
            ' khai bao bien fee
            Dim feeDebit, feeDebitVND, FeeCredit, feeCreditVND, FeeTax, FeeTaxVND, Commission, CommissionVND, CommissionTax, CommissionTaxVND As Double
            ' lay tat cac chung tu (bill) den thoi diem hien tai theo ngay tau chay
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            '--------------------
            t1usd = 0
            t1vnd = 0
            t2usd = 0
            t2vnd = 0
            '---------------------------
            If Me.cboagencyname.Text = "" Then
                Me.dgData.Rows.Clear()
                Me.dgddata1.Rows.Clear()
                Exit Sub
            End If
            sql = " select handlingInbound.agencyname,handlingInbound.blib_id,blib_no,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingIb.blIb_id=handlingInbound.blib_id where handlingInbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlinginbound.currency ='USD'  and handlinginbound.agencyname like N'%" & Me.cboagencyname.Text.Trim & "%' group by handlinginbound.agencyname,handlinginbound.blib_id,blib_no,Eta,handlinginbound.currency order by eta "

            'Else
            'sql = "select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,sum(pricedebit) as pricedebit,date_of_issue,handlingoutbound.currency from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' group by handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,handlingoutbound.currency order by date_of_issue"
            'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            'End If

            ds = ReadDataSet(sql)

            If ds.Tables(0).Rows.Count > 0 Then
                ' ta lay tung bill  tuong ung voi 
                Me.dgData.Rows.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1 ' lay ra tung bill
                    Me.dgData.Rows.Add(1)
                    Dim CurRow As Integer = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Item("bl_id", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_id").ToString
                    Me.dgData.Item("tenkhachhang", CurRow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString
                    Me.dgData.Item("billno", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgData.Item("billnophu", CurRow).Value = "" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgData.Item("fileno", CurRow).Value = "" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file

                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgData.Item("volumn", CurRow).Value = "" 'sl
                    '-------------------------

                    Me.dgData.Item("date_of_issue", CurRow).Value = ds.Tables(0).Rows(i).Item("Eta").ToString

                    Me.dgData.Item("salename", CurRow).Value = "" 'dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgData.Item("phaithu", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgData.Item("currency", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString


                    'Me.dgData.Item("voyage", CurRow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString


                    ' voi bill thu 1 ta lay ra freight
                    ' feedebit USD 
                    ' feedebit VND
                    'sqlF = " select * from handlingInbound where blib_id='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' and continued=1 and Currency='USD'"
                    'dsF = ReadDataSet(sqlF)
                    'If dsF.Tables(0).Rows.Count > 0 Then
                    '    ' Mo 1 vong for lap gia sau do ghi vao
                    '    For j = 0 To dsF.Tables(0).Rows.Count - 1
                    '        feeDebit += CDbl(dsF.Tables(0).Rows(j).Item("pricedebit").ToString)
                    '        FeeCredit += CDbl(dsF.Tables(0).Rows(j).Item("pricecredit").ToString)
                    '        FeeTax += CDbl(dsF.Tables(0).Rows(j).Item("Tax").ToString)
                    '    Next
                    '    Me.dgData.Item("feedebit", CurRow).Value = feeDebit
                    '    Me.dgData.Item("feecredit", CurRow).Value = FeeCredit
                    '    Me.dgData.Item("feetax", CurRow).Value = FeeTax
                    'Else
                    '    Me.dgData.Item("feedebit", CurRow).Value = 0
                    '    Me.dgData.Item("feecredit", CurRow).Value = 0
                    '    Me.dgData.Item("feetax", CurRow).Value = 0

                    'End If



                Next

                InsertAutoNumberToGrid(Me.dgData)

                Me.dgData.Refresh()
                Me.dgData.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgData.RowCount - 2
                Me.dgData.Item("volumn", SumRow).Value = "Amount"
                For row = 0 To Me.dgData.Rows.Count - 3

                    tam += CDbl(Me.dgData.Item("phaithu", row).Value)


                Next
                Me.dgData.Item("phaithu", SumRow).Value = tam
                t1usd = tam
            Else
                Me.dgData.Rows.Clear()
            End If
            '-------------
            luoidata21()
            '----------------------------------------------
            'Dim sql, sqlF As String
            'Dim i, j, k As Integer
            'Dim ds As New DataSet
            'Dim dsF, dsFVND, dsFC, dsFCVND As New DataSet
            '' khai bao bien fee
            'Dim feeDebit, feeDebitVND, FeeCredit, feeCreditVND, FeeTax, FeeTaxVND, Commission, CommissionVND, CommissionTax, CommissionTaxVND As Double
            ' lay tat cac chung tu (bill) den thoi diem hien tai theo ngay tau chay
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            If Me.cboagencyname.Text = "" Then
                Me.dgData.Rows.Clear()
                Me.dgddata1.Rows.Clear()
                Exit Sub
            End If
            sql = " select handlingInbound.agencyname,handlingInbound.blib_id,blib_no,sum(pricecredit) as pricecredit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingIb.blIb_id=handlingInbound.blib_id where handlingInbound.continued=1 and pricedebit=0 and pricecredit<>0 and thanhtoan=0 and handlinginbound.currency ='USD'  and handlinginbound.agencyname like N'%" & Me.cboagencyname.Text.Trim & "%' group by handlinginbound.agencyname,handlinginbound.blib_id,blib_no,Eta,handlinginbound.currency order by eta "

            'Else
            'sql = "select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,sum(pricedebit) as pricedebit,date_of_issue,handlingoutbound.currency from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' group by handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,handlingoutbound.currency order by date_of_issue"
            'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            'End If

            ds = ReadDataSet(sql)

            If ds.Tables(0).Rows.Count > 0 Then
                ' ta lay tung bill  tuong ung voi 
                Me.DataGridView1.Rows.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1 ' lay ra tung bill
                    Me.DataGridView1.Rows.Add(1)
                    Dim CurRow As Integer = Me.DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn1", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_id").ToString
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn2", CurRow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn3", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn4", CurRow).Value = "" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn5", CurRow).Value = ds.Tables(0).Rows(i).Item("Eta").ToString 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file

                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn6", CurRow).Value = "" 'sl
                    '-------------------------

                    Me.DataGridView1.Item("DataGridViewTextBoxColumn7", CurRow).Value = ""

                    Me.DataGridView1.Item("DataGridViewTextBoxColumn8", CurRow).Value = "" 'dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.DataGridView1.Item("DataGridViewTextBoxColumn9", CurRow).Value = ds.Tables(0).Rows(i).Item("PriceCredit").ToString

                    Me.DataGridView1.Item("DataGridViewTextBoxColumn10", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString


                    'Me.dgData.Item("voyage", CurRow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString


                    ' voi bill thu 1 ta lay ra freight
                    ' feedebit USD 
                    ' feedebit VND
                    'sqlF = " select * from handlingInbound where blib_id='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' and continued=1 and Currency='USD'"
                    'dsF = ReadDataSet(sqlF)
                    'If dsF.Tables(0).Rows.Count > 0 Then
                    '    ' Mo 1 vong for lap gia sau do ghi vao
                    '    For j = 0 To dsF.Tables(0).Rows.Count - 1
                    '        feeDebit += CDbl(dsF.Tables(0).Rows(j).Item("pricedebit").ToString)
                    '        FeeCredit += CDbl(dsF.Tables(0).Rows(j).Item("pricecredit").ToString)
                    '        FeeTax += CDbl(dsF.Tables(0).Rows(j).Item("Tax").ToString)
                    '    Next
                    '    Me.dgData.Item("feedebit", CurRow).Value = feeDebit
                    '    Me.dgData.Item("feecredit", CurRow).Value = FeeCredit
                    '    Me.dgData.Item("feetax", CurRow).Value = FeeTax
                    'Else
                    '    Me.dgData.Item("feedebit", CurRow).Value = 0
                    '    Me.dgData.Item("feecredit", CurRow).Value = 0
                    '    Me.dgData.Item("feetax", CurRow).Value = 0

                    'End If



                Next

                InsertAutoNumberToGrid(Me.DataGridView1)

                Me.DataGridView1.Refresh()
                Me.DataGridView1.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.DataGridView1.RowCount - 2
                Me.DataGridView1.Item("DataGridViewTextBoxColumn8", SumRow).Value = "Amount"
                For row = 0 To Me.DataGridView1.Rows.Count - 3

                    tam += CDbl(Me.DataGridView1.Item("DataGridViewTextBoxColumn9", row).Value)


                Next
                Me.DataGridView1.Item("DataGridViewTextBoxColumn9", SumRow).Value = tam
                t2usd = tam
            Else
                Me.DataGridView1.Rows.Clear()
            End If
            '-------------
            luoidata22()

            t1usd = t1usd - t2usd
            t1vnd = t1vnd - t2vnd
            Me.txtsum1USD.Text = FormatNumber(t1usd, 2, TriState.True) 'FormatString2(t1usd)
            Me.txtsum1VND.Text = FormatNumber(t1vnd, 2, TriState.True) 'FormatString2(t1vnd)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub luoidata22()
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            '    sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,sum(pricedebit) as pricedebit,date_of_issue,handlingoutbound.currency from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='VND' group by handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,handlingoutbound.currency order by date_of_issue "

            'Else
            '    sql = "select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,sum(pricedebit) as pricedebit,date_of_issue,handlingoutbound.currency from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='VND' group by handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,handlingoutbound.currency order by date_of_issue"
            '    'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            'End If
            sql = " select handlingInbound.agencyname,handlingInbound.blib_id,blib_no,sum(pricecredit) as pricecredit,eta,handlinginbound.currency from billofladingib left join handlinginbound on billofladingib.blib_id=handlinginbound.blib_id where handlinginbound.continued=1 and pricedebit=0 and pricecredit<>0 and thanhtoan=0 and handlinginbound.currency ='VND'  and handlinginbound.agencyname like N'%" & Me.cboagencyname.Text.Trim & "%' group by handlinginbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency order by eta "


            ds = ReadDataSet(sql)

            If ds.Tables(0).Rows.Count > 0 Then
                ' ta lay tung bill  tuong ung voi 
                Me.DataGridView2.Rows.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1 ' lay ra tung bill
                    Me.DataGridView2.Rows.Add(1)
                    Dim CurRow As Integer = Me.DataGridView2.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn11", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_id").ToString
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn12", CurRow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn13", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn14", CurRow).Value = "" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn15", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString 'dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file

                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn16", CurRow).Value = ""
                    'sl
                    '-------------------------

                    Me.DataGridView2.Item("DataGridViewTextBoxColumn17", CurRow).Value = ""
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn18", CurRow).Value = ""

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.DataGridView2.Item("DataGridViewTextBoxColumn19", CurRow).Value = ds.Tables(0).Rows(i).Item("PriceCredit").ToString

                    Me.DataGridView2.Item("DataGridViewTextBoxColumn20", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString


                    'Me.dgData.Item("voyage", CurRow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString


                    ' voi bill thu 1 ta lay ra freight
                    ' feedebit USD 
                    ' feedebit VND
                    'sqlF = " select * from handlingInbound where blib_id='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' and continued=1 and Currency='USD'"
                    'dsF = ReadDataSet(sqlF)
                    'If dsF.Tables(0).Rows.Count > 0 Then
                    '    ' Mo 1 vong for lap gia sau do ghi vao
                    '    For j = 0 To dsF.Tables(0).Rows.Count - 1
                    '        feeDebit += CDbl(dsF.Tables(0).Rows(j).Item("pricedebit").ToString)
                    '        FeeCredit += CDbl(dsF.Tables(0).Rows(j).Item("pricecredit").ToString)
                    '        FeeTax += CDbl(dsF.Tables(0).Rows(j).Item("Tax").ToString)
                    '    Next
                    '    Me.dgData.Item("feedebit", CurRow).Value = feeDebit
                    '    Me.dgData.Item("feecredit", CurRow).Value = FeeCredit
                    '    Me.dgData.Item("feetax", CurRow).Value = FeeTax
                    'Else
                    '    Me.dgData.Item("feedebit", CurRow).Value = 0
                    '    Me.dgData.Item("feecredit", CurRow).Value = 0
                    '    Me.dgData.Item("feetax", CurRow).Value = 0

                    'End If



                Next

                InsertAutoNumberToGrid(Me.DataGridView2)

                Me.DataGridView2.Refresh()
                Me.DataGridView2.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.DataGridView2.RowCount - 2
                Me.DataGridView2.Item("DataGridViewTextBoxColumn18", SumRow).Value = "Amount"
                For row = 0 To Me.DataGridView2.Rows.Count - 3

                    tam += CDbl(Me.DataGridView2.Item("DataGridViewTextBoxColumn19", row).Value)


                Next
                Me.DataGridView2.Item("DataGridViewTextBoxColumn19", SumRow).Value = tam
                t2vnd = tam
            Else
                Me.DataGridView2.Rows.Clear()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Public Sub luoidata21()
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            '    sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,sum(pricedebit) as pricedebit,date_of_issue,handlingoutbound.currency from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='VND' group by handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,handlingoutbound.currency order by date_of_issue "

            'Else
            '    sql = "select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,sum(pricedebit) as pricedebit,date_of_issue,handlingoutbound.currency from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='VND' group by handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,handlingoutbound.currency order by date_of_issue"
            '    'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            'End If
            sql = " select handlingInbound.agencyname,handlingInbound.blib_id,blib_no,sum(pricedebit) as pricedebit,eta,handlinginbound.currency from billofladingib left join handlinginbound on billofladingib.blib_id=handlinginbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlinginbound.currency ='VND'  and handlinginbound.agencyname like N'%" & Me.cboagencyname.Text.Trim & "%' group by handlinginbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency order by eta "


            ds = ReadDataSet(sql)

            If ds.Tables(0).Rows.Count > 0 Then
                ' ta lay tung bill  tuong ung voi 
                Me.dgddata1.Rows.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1 ' lay ra tung bill
                    Me.dgddata1.Rows.Add(1)
                    Dim CurRow As Integer = Me.dgddata1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgddata1.Item("bl_id1", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_id").ToString
                    Me.dgddata1.Item("tenkhachhang1", CurRow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString
                    Me.dgddata1.Item("billno1", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgddata1.Item("billnophu1", CurRow).Value = "" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgddata1.Item("fileno1", CurRow).Value = "" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file

                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgddata1.Item("volumn1", CurRow).Value = "" 'sl
                    '-------------------------

                    Me.dgddata1.Item("date_of_issue1", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString

                    Me.dgddata1.Item("salename1", CurRow).Value = "" 'dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgddata1.Item("phaithu1", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgddata1.Item("currency1", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString


                    'Me.dgData.Item("voyage", CurRow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString


                    ' voi bill thu 1 ta lay ra freight
                    ' feedebit USD 
                    ' feedebit VND
                    'sqlF = " select * from handlingInbound where blib_id='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' and continued=1 and Currency='USD'"
                    'dsF = ReadDataSet(sqlF)
                    'If dsF.Tables(0).Rows.Count > 0 Then
                    '    ' Mo 1 vong for lap gia sau do ghi vao
                    '    For j = 0 To dsF.Tables(0).Rows.Count - 1
                    '        feeDebit += CDbl(dsF.Tables(0).Rows(j).Item("pricedebit").ToString)
                    '        FeeCredit += CDbl(dsF.Tables(0).Rows(j).Item("pricecredit").ToString)
                    '        FeeTax += CDbl(dsF.Tables(0).Rows(j).Item("Tax").ToString)
                    '    Next
                    '    Me.dgData.Item("feedebit", CurRow).Value = feeDebit
                    '    Me.dgData.Item("feecredit", CurRow).Value = FeeCredit
                    '    Me.dgData.Item("feetax", CurRow).Value = FeeTax
                    'Else
                    '    Me.dgData.Item("feedebit", CurRow).Value = 0
                    '    Me.dgData.Item("feecredit", CurRow).Value = 0
                    '    Me.dgData.Item("feetax", CurRow).Value = 0

                    'End If



                Next

                InsertAutoNumberToGrid(Me.dgddata1)

                Me.dgddata1.Refresh()
                Me.dgddata1.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgddata1.RowCount - 2
                Me.dgddata1.Item("volumn1", SumRow).Value = "Amount"
                For row = 0 To Me.dgddata1.Rows.Count - 3

                    tam += CDbl(Me.dgddata1.Item("phaithu1", row).Value)


                Next
                Me.dgddata1.Item("phaithu1", SumRow).Value = tam
                t1vnd = tam
            Else
                Me.dgddata1.Rows.Clear()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCantruCongnoInbound_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        QueryAgency()
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.BackColor = gMaunen
        Me.TabPage1.BackColor = gMauFra
        Me.TabPage2.BackColor = gMauFra
        Me.TabPage3.BackColor = gMauFra
        Me.TabPage4.BackColor = gMauFra
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class