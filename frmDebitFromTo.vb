Public Class frmDebitFromTo

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
            If Me.ComboBox2.Text = "Agency-Import" Then
                debitfromto_("", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")
            End If
            If Me.ComboBox2.Text = "Agency-Export" Then
                debitfromto_("", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
            End If

            If Me.ComboBox2.Text = "Oversea-Sea-Import" Then
                debitfromto_("", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")
            End If

            If Me.ComboBox2.Text = "Oversea-Sea-Export" Then
                debitfromto_("", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
            End If
            If Me.ComboBox2.Text = "ACS-Air-Import" Then
              
                debitfromto_("", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")

            End If

            If Me.ComboBox2.Text = "ACS-Air-Export" Then
                debitfromto_("", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
            End If
            If Me.ComboBox2.Text = "Domestic-Truck" Then
                debitfromto("", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")

            End If

            If Me.ComboBox2.Text = "Logistics-Customs" Then
                debitfromto("", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")

            End If


           

        Catch ex As Exception

        End Try
    End Sub
    Public Sub debitfromto(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal customerid As String, ByVal date_ As String)

        Try
            Try
                Dim currow As Integer
                ' kiem tra neu co du lieu yhi moi add
                Dim sql As String
                Dim ds As New DataSet
                Dim i As Integer
                sql = "select distinct " & TableDeptID & " from " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid where CONVERT(DATETIME,datereport) between '" & Me.DateTimePicker1.Value.Date & "' and '" & Me.DateTimePicker2.Value.Date & "'  and customerid='" & customerid & "'  order by " & TableDeptID & " "
                ds = ReadDataSet(sql)
                Dim m As Integer
                Try
                    For m = 1 To 7
                        Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                    Next
                Catch ex As Exception

                End Try
                Try
                    For m = 7 To 15
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
                Dim fOtherFee_ As Boolean = True
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    thue_ = 0
                    'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
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


                        tinhtam_ = 0
                        sumOF_ = 0
                        sumLocal_ = 0
                        sql = "select * from " & TableDept & " where " & TableDeptID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' "

                        dsdetails = ReadDataSet(sql)

                        Me.DataGridView1.Rows.Add(1)
                        currow = DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib







                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.DataGridView1.Item("no", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                        Me.DataGridView1.Item("date_", currow).Value = dsdetails.Tables(0).Rows(0).Item(date_).ToString

                      
                        Try
                            Me.DataGridView1.Item("masterbill", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblcarrier").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("masterbill", currow).Value = dsdetails.Tables(0).Rows(0).Item("MBL").ToString
                        End Try
                        Try
                            Me.DataGridView1.Item("housebill", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblmawb").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("housebill", currow).Value = dsdetails.Tables(0).Rows(0).Item("HBL").ToString
                        End Try


                        ' lay cus tu 
                        Dim sqlc As String
                        Dim dsc As New DataSet
                        'sqlc = " select * from customer where customer_id= '" & ds.Tables(0).Rows(i).Item("customerid_showtc").ToString & "' "
                        'dsc = ReadDataSet(sqlc)
                        'If dsc.Tables(0).Rows.Count > 0 Then
                        '    Me.DataGridView1.Item("CUSTOMER", currow).Value = dsc.Tables(0).Rows(0).Item("company").ToString
                        'End If

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

                        sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
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
                                If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*20*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                    cont20 += 1
                                End If

                                If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*40*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                    cont40 += 1
                                End If

                                If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40HC*") Then
                                    cont40hc += 1
                                End If

                                If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*20RF*") Then
                                    cont20rf += 1
                                End If

                                If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40RF*") Then
                                    cont40rf += 1
                                End If
                            Next

                        End If
                        If dsdetails.Tables(0).Rows(0).Item("FCL").ToString = True Then
                            '
                            Dim Scont As String
                            If cont20 > 0 Then
                                Scont = cont20.ToString + "x20DC;"
                            End If
                            If cont40 > 0 Then
                                Scont += cont40.ToString + "x40DC;"
                            End If
                            If cont40hc > 0 Then
                                Scont += cont40hc.ToString + "x40HC;"
                            End If
                            If cont20rf > 0 Then
                                Scont += cont20rf.ToString + "x20RF;"
                            End If

                            If cont40rf > 0 Then
                                Scont += cont40rf.ToString + "x40RF;"
                            End If

                            Me.DataGridView1.Item("volume", currow).Value = Scont


                        ElseIf dsdetails.Tables(0).Rows(0).Item("LCL").ToString = True Then

                            Me.DataGridView1.Item("volume", currow).Value = khoi.ToString + " CBM"
                        End If

                        Me.DataGridView1.Item("destination", currow).Value = dsdetails.Tables(0).Rows(0).Item("POD").ToString
                        Me.DataGridView1.Item("shippingline", currow).Value = dsdetails.Tables(0).Rows(0).Item("shippingline").ToString


                        'DEBIT============================================================================================
                        '==================================================================================================
                        ' CUOC
                       
                        ' THUCHIEN
                      
                        sqlf_ = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid=charge.charge_id where " & tableFreightID & " ='" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "' AND Debitcredit='Debit' and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' "

                        dsf_ = ReadDataSet(sqlf_)
                        If dsf_.Tables(0).Rows.Count > 0 Then
                            For if__ = 0 To dsf_.Tables(0).Rows.Count - 1
                                fOtherFee_ = True
                                tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("pricenotaxvnd").ToString) / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)
                                'CUOC
                                'If dsf_.Tables(0).Rows(if__).Item("containertype").ToString Like "*20*" And Not (UCase(dsf_.Tables(0).Rows(if__).Item("containertype").ToString) Like "*RF*") Then
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "OF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    'freight20_ += tinhtam_
                                    sumOF_ += tinhtam_
                                    fOtherFee_ = False
                                End If
                                'End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*THC*" Then ' Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightTHC_ += tinhtam_

                                    fOtherFee_ = False
                                End If


                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*EBS*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightEBS_ += tinhtam_

                                    fOtherFee_ = False
                                End If

                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightSEALFEE_ += tinhtam_

                                    fOtherFee_ = False
                                End If

                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*CFS*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightCFS_ += tinhtam_

                                    fOtherFee_ = False
                                End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*BILL*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*B/L FEE*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*DOC*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightDOCFEE_ += tinhtam_

                                    fOtherFee_ = False
                                End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*TELEX*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "**" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightTELEX_ += tinhtam_

                                    fOtherFee_ = False
                                End If




                                If fOtherFee_ = True Then
                                    FREIGHTOtherFee_ += tinhtam_
                                End If
                                thue_ += CDbl(dsf_.Tables(0).Rows(if__).Item("pricethue").ToString) / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                            Next

                        End If
                        ' dua cac phi vao
                        Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(sumOF_, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Me.DataGridView1.Item("cfsusd", currow).Value = FormatNumber(freightCFS_, 3)

                        Me.DataGridView1.Item("ebsusd", currow).Value = FormatNumber(freightEBS_, 3)

                        Me.DataGridView1.Item("thcusd", currow).Value = FormatNumber(freightTHC_, 3)
                        Me.DataGridView1.Item("sealusd", currow).Value = FormatNumber(freightSEALFEE_, 3)
                        Me.DataGridView1.Item("blusd", currow).Value = FormatNumber(freightDOCFEE_, 3)
                        Me.DataGridView1.Item("TELEXusd", currow).Value = FormatNumber(freightTELEX_, 3)
                        Me.DataGridView1.Item("OTHERusd", currow).Value = FormatNumber(FREIGHTOtherFee_, 3)
                    Next

                End If
                ' tog
                Dim tongof As Double = 0
                Dim tongebs As Double = 0
                Dim tongthc As Double = 0
                Dim tongseal As Double = 0
                Dim tongcfs As Double = 0
                Dim tongbill As Double = 0
                Dim tongtelex As Double = 0
                Dim tongotherfee As Double = 0
                Dim it As Integer
                For it = 0 To Me.DataGridView1.RowCount - 1
                    Try
                        tongof += Me.DataGridView1.Item("ofusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongebs += Me.DataGridView1.Item("ebsusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongthc += Me.DataGridView1.Item("thcusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongseal += Me.DataGridView1.Item("sealusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongcfs += Me.DataGridView1.Item("cfsusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongbill += Me.DataGridView1.Item("blusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongtelex += Me.DataGridView1.Item("telexusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongotherfee += Me.DataGridView1.Item("otherusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                Next
                ' ghi vao
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                Me.DataGridView1.Item("shippingline", currow).Value = "Total"
                Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(tongof, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                Me.DataGridView1.Item("cfsusd", currow).Value = FormatNumber(tongcfs, 3)

                Me.DataGridView1.Item("ebsusd", currow).Value = FormatNumber(tongebs, 3)

                Me.DataGridView1.Item("thcusd", currow).Value = FormatNumber(tongthc, 3)
                Me.DataGridView1.Item("sealusd", currow).Value = FormatNumber(tongseal, 3)
                Me.DataGridView1.Item("blusd", currow).Value = FormatNumber(tongbill, 3)
                Me.DataGridView1.Item("TELEXusd", currow).Value = FormatNumber(tongtelex, 3)
                Me.DataGridView1.Item("OTHERusd", currow).Value = FormatNumber(tongotherfee, 3)
                '-
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Pink
                Me.DataGridView1.Item("shippingline", currow).Value = "VAT"
                Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(thue_, 3)
                '-
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Red
                Me.DataGridView1.Item("shippingline", currow).Value = "Grand Total"
                Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(thue_ + tongof + tongebs + tongthc + tongcfs + tongseal + tongbill + tongtelex + tongotherfee, 3)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub debitfromto_(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal customerid As String, ByVal date_ As String)

        Try
            Try
                Dim currow As Integer
                ' kiem tra neu co du lieu yhi moi add
                Dim sql As String
                Dim ds As New DataSet
                Dim i As Integer
                sql = "select distinct " & TableDeptID & " from " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid where CONVERT(DATETIME,datereport) between '" & Me.DateTimePicker1.Value.Date & "' and '" & Me.DateTimePicker2.Value.Date & "'  and customerid='" & customerid & "'  order by " & TableDeptID & " "
                ds = ReadDataSet(sql)
                Dim m As Integer
                Try
                    For m = 1 To 7
                        Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                    Next
                Catch ex As Exception

                End Try
                Try
                    For m = 7 To 15
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
                Dim fOtherFee_ As Boolean = True
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    thue_ = 0
                    'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
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


                        tinhtam_ = 0
                        sumOF_ = 0
                        sumLocal_ = 0
                        sql = "select * from " & TableDept & " where " & TableDeptID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' "

                        dsdetails = ReadDataSet(sql)

                        Me.DataGridView1.Rows.Add(1)
                        currow = DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib







                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.DataGridView1.Item("no", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                        Me.DataGridView1.Item("date_", currow).Value = dsdetails.Tables(0).Rows(0).Item(date_).ToString


                        Try
                            Me.DataGridView1.Item("masterbill", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblcarrier").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("masterbill", currow).Value = dsdetails.Tables(0).Rows(0).Item("MBL").ToString
                        End Try
                        Try
                            Me.DataGridView1.Item("housebill", currow).Value = dsdetails.Tables(0).Rows(0).Item("mblmawb").ToString
                        Catch ex As Exception
                            Me.DataGridView1.Item("housebill", currow).Value = dsdetails.Tables(0).Rows(0).Item("HBL").ToString
                        End Try


                        ' lay cus tu 
                        Dim sqlc As String
                        Dim dsc As New DataSet
                        'sqlc = " select * from customer where customer_id= '" & ds.Tables(0).Rows(i).Item("customerid_showtc").ToString & "' "
                        'dsc = ReadDataSet(sqlc)
                        'If dsc.Tables(0).Rows.Count > 0 Then
                        '    Me.DataGridView1.Item("CUSTOMER", currow).Value = dsc.Tables(0).Rows(0).Item("company").ToString
                        'End If

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

                        sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
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
                                If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*20*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                    cont20 += 1
                                End If

                                If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*40*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                    cont40 += 1
                                End If

                                If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40HC*") Then
                                    cont40hc += 1
                                End If

                                If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*20RF*") Then
                                    cont20rf += 1
                                End If

                                If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40RF*") Then
                                    cont40rf += 1
                                End If
                            Next

                        End If
                        If dsdetails.Tables(0).Rows(0).Item("FCL").ToString = True Then
                            '
                            Dim Scont As String
                            If cont20 > 0 Then
                                Scont = cont20.ToString + "x20DC;"
                            End If
                            If cont40 > 0 Then
                                Scont += cont40.ToString + "x40DC;"
                            End If
                            If cont40hc > 0 Then
                                Scont += cont40hc.ToString + "x40HC;"
                            End If
                            If cont20rf > 0 Then
                                Scont += cont20rf.ToString + "x20RF;"
                            End If

                            If cont40rf > 0 Then
                                Scont += cont40rf.ToString + "x40RF;"
                            End If

                            Me.DataGridView1.Item("volume", currow).Value = Scont


                        ElseIf dsdetails.Tables(0).Rows(0).Item("LCL").ToString = True Then

                            Me.DataGridView1.Item("volume", currow).Value = khoi.ToString + " CBM"
                        End If

                        Me.DataGridView1.Item("destination", currow).Value = dsdetails.Tables(0).Rows(0).Item("POD").ToString
                        Me.DataGridView1.Item("shippingline", currow).Value = dsdetails.Tables(0).Rows(0).Item("shippingline").ToString


                        'DEBIT============================================================================================
                        '==================================================================================================
                        ' CUOC

                        ' THUCHIEN

                        sqlf_ = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid=charge.charge_id where " & tableFreightID & " ='" & dsdetails.Tables(0).Rows(0).Item(TableDeptID).ToString & "' AND Debitcredit='Debit' and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' "

                        dsf_ = ReadDataSet(sqlf_)
                        If dsf_.Tables(0).Rows.Count > 0 Then
                            For if__ = 0 To dsf_.Tables(0).Rows.Count - 1
                                fOtherFee_ = True
                                'tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("pricenotaxvnd").ToString) / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                If UCase(dsf_.Tables(0).Rows(if__).Item("currency").ToString) = "USD" Then
                                    tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("PRICE").ToString) ' / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                Else
                                    tinhtam_ = CDbl(dsf_.Tables(0).Rows(if__).Item("PRICE").ToString) / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                End If








                                'CUOC
                                'If dsf_.Tables(0).Rows(if__).Item("containertype").ToString Like "*20*" And Not (UCase(dsf_.Tables(0).Rows(if__).Item("containertype").ToString) Like "*RF*") Then
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "OF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    'freight20_ += tinhtam_
                                    sumOF_ += tinhtam_
                                    fOtherFee_ = False
                                End If
                                'End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*THC*" Then ' Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightTHC_ += tinhtam_

                                    fOtherFee_ = False
                                End If


                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*EBS*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightEBS_ += tinhtam_

                                    fOtherFee_ = False
                                End If

                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightSEALFEE_ += tinhtam_

                                    fOtherFee_ = False
                                End If

                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*CFS*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*SEAL*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightCFS_ += tinhtam_

                                    fOtherFee_ = False
                                End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*BILL*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*B/L FEE*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*DOC*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightDOCFEE_ += tinhtam_

                                    fOtherFee_ = False
                                End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*TELEX*" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "**" Then 'Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*OCEANFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*O.F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AF*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A/F*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*AIRFREIGHT*" Or UCase(dsf_.Tables(0).Rows(if__).Item("charge_code").ToString) Like "*A.F*" Then
                                    freightTELEX_ += tinhtam_

                                    fOtherFee_ = False
                                End If




                                If fOtherFee_ = True Then
                                    FREIGHTOtherFee_ += tinhtam_
                                End If
                                If UCase(dsf_.Tables(0).Rows(if__).Item("currency").ToString) = "USD" Then
                                    thue_ += tinhtam_ * CDbl(dsf_.Tables(0).Rows(if__).Item("taxprice").ToString) / 100

                                Else
                                    thue_ += tinhtam_ * CDbl(dsf_.Tables(0).Rows(if__).Item("taxprice").ToString) / 100 / CDbl(dsf_.Tables(0).Rows(if__).Item("tigia").ToString)

                                End If
                               
                            Next

                        End If
                        ' dua cac phi vao
                        Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(sumOF_, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Me.DataGridView1.Item("cfsusd", currow).Value = FormatNumber(freightCFS_, 3)

                        Me.DataGridView1.Item("ebsusd", currow).Value = FormatNumber(freightEBS_, 3)

                        Me.DataGridView1.Item("thcusd", currow).Value = FormatNumber(freightTHC_, 3)
                        Me.DataGridView1.Item("sealusd", currow).Value = FormatNumber(freightSEALFEE_, 3)
                        Me.DataGridView1.Item("blusd", currow).Value = FormatNumber(freightDOCFEE_, 3)
                        Me.DataGridView1.Item("TELEXusd", currow).Value = FormatNumber(freightTELEX_, 3)
                        Me.DataGridView1.Item("OTHERusd", currow).Value = FormatNumber(FREIGHTOtherFee_, 3)
                    Next

                End If
                ' tog
                Dim tongof As Double = 0
                Dim tongebs As Double = 0
                Dim tongthc As Double = 0
                Dim tongseal As Double = 0
                Dim tongcfs As Double = 0
                Dim tongbill As Double = 0
                Dim tongtelex As Double = 0
                Dim tongotherfee As Double = 0
                Dim it As Integer
                For it = 0 To Me.DataGridView1.RowCount - 1
                    Try
                        tongof += Me.DataGridView1.Item("ofusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongebs += Me.DataGridView1.Item("ebsusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongthc += Me.DataGridView1.Item("thcusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongseal += Me.DataGridView1.Item("sealusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongcfs += Me.DataGridView1.Item("cfsusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongbill += Me.DataGridView1.Item("blusd", it).Value.ToString
                    Catch ex As Exception

                    End Try

                    Try
                        tongtelex += Me.DataGridView1.Item("telexusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongotherfee += Me.DataGridView1.Item("otherusd", it).Value.ToString
                    Catch ex As Exception

                    End Try
                Next
                ' ghi vao
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                Me.DataGridView1.Item("shippingline", currow).Value = "Total"
                Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(tongof, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
                Me.DataGridView1.Item("cfsusd", currow).Value = FormatNumber(tongcfs, 3)

                Me.DataGridView1.Item("ebsusd", currow).Value = FormatNumber(tongebs, 3)

                Me.DataGridView1.Item("thcusd", currow).Value = FormatNumber(tongthc, 3)
                Me.DataGridView1.Item("sealusd", currow).Value = FormatNumber(tongseal, 3)
                Me.DataGridView1.Item("blusd", currow).Value = FormatNumber(tongbill, 3)
                Me.DataGridView1.Item("TELEXusd", currow).Value = FormatNumber(tongtelex, 3)
                Me.DataGridView1.Item("OTHERusd", currow).Value = FormatNumber(tongotherfee, 3)
                '-
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Pink
                Me.DataGridView1.Item("shippingline", currow).Value = "VAT"
                Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(thue_, 3)
                '-
                Me.DataGridView1.Rows.Add(1)
                currow = DataGridView1.RowCount - 2
                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Red
                Me.DataGridView1.Item("shippingline", currow).Value = "Grand Total"
                Me.DataGridView1.Item("ofusd", currow).Value = FormatNumber(thue_ + tongof + tongebs + tongthc + tongcfs + tongseal + tongbill + tongtelex + tongotherfee, 3)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
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
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id, company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.TextBox2.Text & "%' or taxcode like '%" & Me.TextBox2.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocus, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDebitFromTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            querycombo()
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