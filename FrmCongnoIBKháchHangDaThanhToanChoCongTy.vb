Public Class FrmCongnoIBKháchHangDaThanhToanChoCongTy
    Public dsdataBookingInfor As New DataSet


    Public Function QueryHBL(ByVal bl_id As String) As String
        Try
            Dim strQuery As String
            Dim ds As New DataSet
            Dim count As String = ""
            strQuery = "Select blh_no  "
            strQuery &= " from billoflading_house where bl_id ='" & bl_id & "' and continued=1  "
            ds = ReadDataSet(strQuery)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    count += ds.Tables(0).Rows(i).Item("blh_no") + ","
                Next
            End If

            Return count


        Catch ex As Exception
            MsgBox(Err.Description)
            Return "No Bill"
        End Try
    End Function
    Public Function QueryFileNo(ByVal bl_id As String) As String
        Try
            Dim strQuery As String
            Dim ds As New DataSet
            Dim count As String = ""
            strQuery = "Select fileNo  "
            strQuery &= " from containerOutboundNotify where containerOutboundNotifyid=(select containerOutboundNotifyID from billoflading where bl_id ='" & bl_id & "' and continued=1)  "
            ds = ReadDataSet(strQuery)
            If ds.Tables(0).Rows.Count > 0 Then
                'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                count += ds.Tables(0).Rows(0).Item("fileno")
                'Next
            End If

            Return count


        Catch ex As Exception
            MsgBox(Err.Description)
            Return "No Bill"
        End Try
    End Function
    Sub QueryBookingInfor(ByVal bl_id As String)
        Try
            Dim strQuery As String

            strQuery = "Select * "
            strQuery &= " from ContainerOutboundNotify where ContainerOutboundNotifyid in(select ContainerOutboundNotifyid from billoflading  where bl_id='" & bl_id & "' and continued=1)  "

            dsdataBookingInfor = ReadDataSet(strQuery)

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Public Sub luoidata1()
        Try
            Dim sql, sqlF As String
            Dim i, j, k As Integer
            Dim ds As New DataSet
            Dim dsF, dsFVND, dsFC, dsFCVND As New DataSet
            ' khai bao bien fee
            Dim feeDebit, feeDebitVND, FeeCredit, feeCreditVND, FeeTax, FeeTaxVND, Commission, CommissionVND, CommissionTax, CommissionTaxVND As Double
            ' lay tat cac chung tu (bill) den thoi diem hien tai theo ngay tau chay
            If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
                sql = " select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='VND' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "

            Else
                sql = "select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where ETA between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='VND' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "
                'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            End If

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
                    Me.dgddata1.Item("ref1", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgddata1.Item("billnophu1", CurRow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString '"" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgddata1.Item("ref1", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString '"" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file
                    Me.dgddata1.Item("fileno1", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgddata1.Item("descriptionofgoods1", CurRow).Value = ds.Tables(0).Rows(i).Item("descriptionofgoods").ToString
                    '-------------------------

                    Me.dgddata1.Item("eta1", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString.Replace("12:00:00 AM", "")

                    Me.dgddata1.Item("salename1", CurRow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString ' cho them sau dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgddata1.Item("phaithu1", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgddata1.Item("currency1", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString






                Next

                InsertAutoNumberToGrid(Me.dgddata1)

                Me.dgddata1.Refresh()
                Me.dgddata1.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgddata1.RowCount - 2
                Me.dgddata1.Item("descriptionofgoods1", SumRow).Value = "Amount"
                For row = 0 To Me.dgddata1.Rows.Count - 3

                    tam += CDbl(Me.dgddata1.Item("phaithu1", row).Value)


                Next
                Me.dgddata1.Item("phaithu1", SumRow).Value = tam
            Else
                Me.dgddata1.Rows.Clear()
            End If
            '-------------
            'luoidata1()


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub luoidata3()
        Try
            Dim sql, sqlF As String
            Dim i, j, k As Integer
            Dim ds As New DataSet
            Dim dsF, dsFVND, dsFC, dsFCVND As New DataSet
            ' khai bao bien fee
            Dim feeDebit, feeDebitVND, FeeCredit, feeCreditVND, FeeTax, FeeTaxVND, Commission, CommissionVND, CommissionTax, CommissionTaxVND As Double
            ' lay tat cac chung tu (bill) den thoi diem hien tai theo ngay tau chay
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            '    sql = " select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='VND' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "

            'Else
            sql = "select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where ETA between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='VND' and customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "
            'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            'End If

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
                    Me.dgddata1.Item("ref1", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgddata1.Item("billnophu1", CurRow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString '"" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgddata1.Item("ref1", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString '"" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file
                    Me.dgddata1.Item("fileno1", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgddata1.Item("descriptionofgoods1", CurRow).Value = ds.Tables(0).Rows(i).Item("descriptionofgoods").ToString
                    '-------------------------

                    Me.dgddata1.Item("eta1", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString.Replace("12:00:00 AM", "")

                    Me.dgddata1.Item("salename1", CurRow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString ' cho them sau dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgddata1.Item("phaithu1", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgddata1.Item("currency1", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString






                Next

                InsertAutoNumberToGrid(Me.dgddata1)

                Me.dgddata1.Refresh()
                Me.dgddata1.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgddata1.RowCount - 2
                Me.dgddata1.Item("descriptionofgoods1", SumRow).Value = "Amount"
                For row = 0 To Me.dgddata1.Rows.Count - 3

                    tam += CDbl(Me.dgddata1.Item("phaithu1", row).Value)


                Next
                Me.dgddata1.Item("phaithu1", SumRow).Value = tam
            Else
                Me.dgddata1.Rows.Clear()
            End If
            '-------------
            'luoidata1()


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub luoidata2()
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
            ' sql = " select handlingInbound.agencyname,handlingInbound.blib_id,blib_no,sum(pricedebit) as pricedebit,eta,handlinginbound.currency from billofladingib left join handlinginbound on billofladingib.blib_id=handlinginbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlinginbound.currency ='VND'  and handlinginbound.agencyname like N'%" & Me.cboagencyname.Text.Trim & "%' group by handlinginbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency order by eta "


            ' If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            sql = " select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='VND' and customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "

            'Else
            '    sql = "select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where ETA between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='VND' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "
            'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            ' End If

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
                    Me.dgddata1.Item("ref1", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgddata1.Item("billnophu1", CurRow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString '"" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgddata1.Item("ref1", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString '"" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file
                    Me.dgddata1.Item("fileno1", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgddata1.Item("descriptionofgoods1", CurRow).Value = ds.Tables(0).Rows(i).Item("descriptionofgoods").ToString
                    '-------------------------

                    Me.dgddata1.Item("eta1", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString.Replace("12:00:00 AM", "")

                    Me.dgddata1.Item("salename1", CurRow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString ' cho them sau dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgddata1.Item("phaithu1", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgddata1.Item("currency1", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString






                Next

                InsertAutoNumberToGrid(Me.dgddata1)

                Me.dgddata1.Refresh()
                Me.dgddata1.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgddata1.RowCount - 2
                Me.dgddata1.Item("descriptionofgoods1", SumRow).Value = "Amount"
                For row = 0 To Me.dgddata1.Rows.Count - 3

                    tam += CDbl(Me.dgddata1.Item("phaithu1", row).Value)


                Next
                Me.dgddata1.Item("phaithu1", SumRow).Value = tam
            Else
                Me.dgddata1.Rows.Clear()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim sql, sqlF As String
            Dim i, j, k As Integer
            Dim ds As New DataSet
            Dim dsF, dsFVND, dsFC, dsFCVND As New DataSet
            ' khai bao bien fee
            Dim feeDebit, feeDebitVND, FeeCredit, feeCreditVND, FeeTax, FeeTaxVND, Commission, CommissionVND, CommissionTax, CommissionTaxVND As Double
            ' lay tat cac chung tu (bill) den thoi diem hien tai theo ngay tau chay
            If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
                sql = " select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='USD' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "

            Else
                sql = "select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where ETA between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='USD' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "
                'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

            End If

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
                    Me.dgData.Item("ref", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgData.Item("billnophu", CurRow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString '"" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgData.Item("ref", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString '"" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file
                    Me.dgData.Item("fileno", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgData.Item("DesciptionOfGoods", CurRow).Value = ds.Tables(0).Rows(i).Item("descriptionofgoods").ToString
                    '-------------------------

                    Me.dgData.Item("eta", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString.Replace("12:00:00 AM", "")

                    Me.dgData.Item("salename", CurRow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString ' cho them sau dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgData.Item("phaithu", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgData.Item("currency", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString






                Next

                InsertAutoNumberToGrid(Me.dgData)

                Me.dgData.Refresh()
                Me.dgData.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgData.RowCount - 2
                Me.dgData.Item("DesciptionOfGoods", SumRow).Value = "Amount"
                For row = 0 To Me.dgData.Rows.Count - 3

                    tam += CDbl(Me.dgData.Item("phaithu", row).Value)


                Next
                Me.dgData.Item("phaithu", SumRow).Value = tam
            Else
                Me.dgData.Rows.Clear()
            End If
            '-------------
            luoidata1()


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Sub
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

    Private Sub cmdexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexcel.Click
        Try
            If Me.dgData.RowCount > 0 Then

                ExportExecel(Me.dgData, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmProfitInbound_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDefaultGrid(Me.dgData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgddata1, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        QueryAgency()
        Me.BackColor = gMaunen
        Me.TabPage1.BackColor = gMauFra
        Me.TabPage2.BackColor = gMauFra
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.dgData.RowCount > 0 Then

                ExportExecel(Me.dgddata1, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
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
            If Me.cboagencyname.Text = "" Then
                Me.dgData.Rows.Clear()
                Me.dgddata1.Rows.Clear()
                Exit Sub
            End If
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            sql = " select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='USD' and customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "

            'Else
            '    sql = "select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where ETA between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='USD' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "
            '    'sql = " select handlingoutbound.agencyname,handlingoutbound.bl_id,bl_no,date_of_issue,sum(pricedebit) as pricedebit,handlingoutbound.currency,charge_code from billoflading left join handlingoutbound on billoflading.bl_id=handlingoutbound.bl_id where date_of_issue between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlingoutbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingoutbound.currency ='USD' order by date_of_issue "

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
                    Me.dgData.Item("ref", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgData.Item("billnophu", CurRow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString '"" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgData.Item("ref", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString '"" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file
                    Me.dgData.Item("fileno", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgData.Item("DesciptionOfGoods", CurRow).Value = ds.Tables(0).Rows(i).Item("descriptionofgoods").ToString
                    '-------------------------

                    Me.dgData.Item("eta", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString.Replace("12:00:00 AM", "")

                    Me.dgData.Item("salename", CurRow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString ' cho them sau dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgData.Item("phaithu", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgData.Item("currency", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString






                Next

                InsertAutoNumberToGrid(Me.dgData)

                Me.dgData.Refresh()
                Me.dgData.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgData.RowCount - 2
                Me.dgData.Item("DesciptionOfGoods", SumRow).Value = "Amount"
                For row = 0 To Me.dgData.Rows.Count - 3

                    tam += CDbl(Me.dgData.Item("phaithu", row).Value)


                Next
                Me.dgData.Item("phaithu", SumRow).Value = tam
            Else
                Me.dgData.Rows.Clear()
            End If
            '-------------
            luoidata2()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub XemChiTiếtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XemChiTiếtToolStripMenuItem.Click

        gBl_IdChitiet = ""
        gAgencyNameChitiet = ""
        If Me.dgData.Rows.Count < 2 Then
            Return
        End If
        Dim selectedRowCount As Integer = _
           Me.dgData.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim index As Integer = Me.dgData.CurrentRow.Index
        'If selectedRowCount = 1 Then
        '    'Dim sb As New System.Text.StringBuilder()
        '    Dim i As Integer
        '    For i = 0 To selectedRowCount - 1
        gBl_IdChitiet = Me.dgData.Item("bl_id", index).Value.ToString
        gAgencyNameChitiet = Me.dgData.Item("tenkhachhang", index).Value.ToString

        'Next i
        'End If
        Dim frm As New frmViewChitietKhachhangDaThanhToanChoCty
        frm.ShowDialog()
    End Sub

    Private Sub XemChiTiếtToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XemChiTiếtToolStripMenuItem1.Click
        gBl_IdChitiet = ""
        gAgencyNameChitiet = ""
        If Me.dgddata1.Rows.Count < 2 Then
            Return
        End If
        Dim selectedRowCount As Integer = _
           Me.dgddata1.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim index As Integer = Me.dgddata1.CurrentRow.Index
        'If selectedRowCount = 1 Then
        '    'Dim sb As New System.Text.StringBuilder()
        '    Dim i As Integer
        '    For i = 0 To selectedRowCount - 1
        gBl_IdChitiet = Me.dgddata1.Item("bl_id1", index).Value.ToString
        gAgencyNameChitiet = Me.dgddata1.Item("tenkhachhang1", index).Value.ToString

        'Next i
        'End If
        Dim frm As New frmViewChitietKhachhangDaThanhToanChoCtyVND
        frm.ShowDialog()
    End Sub



   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim sql, sqlF As String
            Dim i, j, k As Integer
            Dim ds As New DataSet
            Dim dsF, dsFVND, dsFC, dsFCVND As New DataSet
            ' khai bao bien fee
            Dim feeDebit, feeDebitVND, FeeCredit, feeCreditVND, FeeTax, FeeTaxVND, Commission, CommissionVND, CommissionTax, CommissionTaxVND As Double
            ' lay tat cac chung tu (bill) den thoi diem hien tai theo ngay tau chay
            'If Me.chkToanbo.Checked = True Then 'bl_no,date_of_issue,sum(pricedebit),handlingoutbound.currency,charge_code
            '    sql = " select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='USD' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "

            'Else
            If Me.cboagencyname.Text = "" Then
                Exit Sub
            End If
            sql = "select handlingInbound.agencyname,handlinginbound.blib_id,blib_no,mbl,hbl,salecode,ref,descriptionofgoods,sum(pricedebit) as pricedebit,ETA,handlingInbound.currency from billofladingIB left join handlingInbound on billofladingib.blib_id=handlingInbound.blib_id where ETA between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and handlinginbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=1 and handlingInbound.currency ='USD' and customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' group by handlingInbound.agencyname,handlinginbound.blib_id,blib_no,eta,handlinginbound.currency,mbl,hbl,salecode,descriptionofgoods,ref order by eta "
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
                    Me.dgData.Item("ref", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    '-- lay tong so van don phu

                    'ws.Range("D" & CurRow).Value2 = "'" + QueryHBL(dsdataBookingInfor.Tables(0).Rows(0).Item("fileno").ToString) ' so hbl
                    Me.dgData.Item("billnophu", CurRow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString '"" 'QueryHBL(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so hbl


                    '----------------------------------------------------------------------------------------
                    Me.dgData.Item("ref", CurRow).Value = ds.Tables(0).Rows(i).Item("ref").ToString '"" 'QueryFileNo(ds.Tables(0).Rows(i).Item("bl_id").ToString) ' so file
                    Me.dgData.Item("fileno", CurRow).Value = ds.Tables(0).Rows(i).Item("blib_no").ToString
                    '----------------------------------------------------
                    'QueryBookingInfor(ds.Tables(0).Rows(i).Item("bl_id").ToString)
                    'volumn
                    'Dim sl As String = ""
                    'sl = IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20gp").ToString + " x 20GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40gp").ToString + " x 40GP ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40HC").ToString + " x 40HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong45HC").ToString + " x 45HC ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20RF").ToString + " x 20RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RF").ToString + " x 40RF ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40RH").ToString + " x 40RH ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20OT").ToString + " x 20OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40OT").ToString + " x 40OT ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong20FR").ToString + " x 20FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluong40FR").ToString + " x 40FR ") + IIf(dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString = 0, "", dsdataBookingInfor.Tables(0).Rows(0).Item("soluongCBM").ToString + " x CBM ")
                    Me.dgData.Item("DesciptionOfGoods", CurRow).Value = ds.Tables(0).Rows(i).Item("descriptionofgoods").ToString
                    '-------------------------

                    Me.dgData.Item("eta", CurRow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString.Replace("12:00:00 AM", "")

                    Me.dgData.Item("salename", CurRow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString ' cho them sau dsdataBookingInfor.Tables(0).Rows(0).Item("salename").ToString

                    'Me.dgData.Item("charge_code", CurRow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                    Me.dgData.Item("phaithu", CurRow).Value = ds.Tables(0).Rows(i).Item("pricedebit").ToString

                    Me.dgData.Item("currency", CurRow).Value = ds.Tables(0).Rows(i).Item("currency").ToString






                Next

                InsertAutoNumberToGrid(Me.dgData)

                Me.dgData.Refresh()
                Me.dgData.Rows.Add(1)
                Dim row As Integer
                Dim tam As Double = 0
                Dim SumRow As Integer = Me.dgData.RowCount - 2
                Me.dgData.Item("DesciptionOfGoods", SumRow).Value = "Amount"
                For row = 0 To Me.dgData.Rows.Count - 3

                    tam += CDbl(Me.dgData.Item("phaithu", row).Value)


                Next
                Me.dgData.Item("phaithu", SumRow).Value = tam
            Else
                Me.dgData.Rows.Clear()
            End If
            '-------------
            luoidata3()


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Sub

End Class