Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmJOBOut
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = True
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\JOB.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer '= Me.dgdStatement.RowCount - 1
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            'sqlC = " select * from customer where customer_id='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'"
            'dsC = ReadDataSet(sqlC)
            'If dsC.Tables(0).Rows.Count > 0 Then
            '    cus = dsC.Tables(0).Rows(0).Item("company").ToString
            '    add = dsC.Tables(0).Rows(0).Item("address").ToString
            '    tel = dsC.Tables(0).Rows(0).Item("tel").ToString
            '    fax = dsC.Tables(0).Rows(0).Item("fax").ToString
            '    taxcode = dsC.Tables(0).Rows(0).Item("taxcode").ToString
            'End If
            'ws.Range("b4").Value2 = cus
            'ws.Range("b5").Value2 = "Add :" + add
            'ws.Range("b6").Value2 = "Tel: " + tel + " Fax: " + fax
            'ws.Range("b7").Value2 = "Taxcode :" + taxcode

            'ws.Range("h4").Value2 = Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h6").Value2 = Me.dtpto.Value.Date.ToOADate - Me.dtpFrom.Value.Date.ToOADate  'Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h7").Value2 = Me.dtpFrom.Value.Date.ToString.Replace("12:00:00 AM", "") + "     " + Me.dtpto.Value.Date.ToString.Replace("12:00:00 AM", "")
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 8
            Dim ds As New DataSet
            Dim sql As String
            Dim i As Integer = 0
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            sql = " select * from inbound where ref='" & Me.cboMBL.Text & "' order by dateUpdate  "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                If Me.chkSale.Checked = True Then
                    ws.Range("f1").Value2 = "JOB SALE"
                End If
                ws.Range("a1").Value2 = ds.Tables(0).Rows(0).Item("ref").ToString

                ws.Range("a25").Value2 = ds.Tables(0).Rows(0).Item("agencyname").ToString
                ws.Range("a3").Value2 = ds.Tables(0).Rows(0).Item("vessel").ToString + " / " + ds.Tables(0).Rows(0).Item("voyage").ToString
                ws.Range("b3").Value2 = ds.Tables(0).Rows(0).Item("sailingdate").ToString
                ws.Range("c3").Value2 = ds.Tables(0).Rows(0).Item("ETA").ToString

                ws.Range("d3").Value2 = ds.Tables(0).Rows(0).Item("shippingline").ToString
                '--------------------------


                'For j = 1 To 9
                '    If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                '        kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                '        kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                '        khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                '    End If

                'Next
                '-------------------------------


                ws.Range("i3").Value2 = ds.Tables(0).Rows(0).Item("POL").ToString

                ws.Range("k3").Value2 = ds.Tables(0).Rows(0).Item("DEST").ToString
                ws.Range("l3").Value2 = ds.Tables(0).Rows(0).Item("salecode").ToString

                If UCase(ds.Tables(0).Rows(0).Item("LCL").ToString) = "TRUE" Then
                    ws.Range("m3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                    ws.Range("n3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("consol").ToString) = "TRUE" Then
                    ws.Range("l3").Value2 = "x"
                End If
                ws.Range("a5").Value2 = ds.Tables(0).Rows(0).Item("MBL").ToString
                '-------------------dem bill house
                Dim dsH As New DataSet
                Dim sqlH As String
                sqlH = " select count(*) as sl from inbound where ref='" & Me.cboMBL.Text & "' and continued=1  "
                dsH = ReadDataSet(sqlH)
                If dsH.Tables(0).Rows.Count > 0 Then

                    ws.Range("b5").Value2 = dsH.Tables(0).Rows(0).Item("sl").ToString
                End If

                ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("importCY").ToString
                ws.Range("e5").Value2 = ds.Tables(0).Rows(0).Item("kho").ToString




                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lay tung house

                    If UCase(ds.Tables(0).Rows(i).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(i).Item("containerno1").ToString + " " + ds.Tables(0).Rows(i).Item("seal1").ToString + " " + ds.Tables(0).Rows(i).Item("type1").ToString + " " + ds.Tables(0).Rows(i).Item("containerno2").ToString + " " + ds.Tables(0).Rows(i).Item("seal2").ToString + " " + ds.Tables(0).Rows(i).Item("type2").ToString + " " + ds.Tables(0).Rows(i).Item("containerno3").ToString + " " + ds.Tables(0).Rows(i).Item("seal3").ToString + " " + ds.Tables(0).Rows(i).Item("type3").ToString + " " + ds.Tables(0).Rows(i).Item("containerno4").ToString + " " + ds.Tables(0).Rows(i).Item("seal4").ToString + " " + ds.Tables(0).Rows(i).Item("type4").ToString + " " + ds.Tables(0).Rows(i).Item("containerno5").ToString + " " + ds.Tables(0).Rows(i).Item("seal5").ToString + " " + ds.Tables(0).Rows(i).Item("type5").ToString + " " + ds.Tables(0).Rows(i).Item("containerno6").ToString + " " + ds.Tables(0).Rows(i).Item("seal6").ToString + " " + ds.Tables(0).Rows(i).Item("type6").ToString + " " + ds.Tables(0).Rows(i).Item("containerno7").ToString + " " + ds.Tables(0).Rows(i).Item("seal7").ToString + " " + ds.Tables(0).Rows(i).Item("type7").ToString + " " + ds.Tables(0).Rows(i).Item("containerno8").ToString + " " + ds.Tables(0).Rows(i).Item("seal8").ToString + " " + ds.Tables(0).Rows(i).Item("type8").ToString + " " + ds.Tables(0).Rows(i).Item("containerno9").ToString + " " + ds.Tables(0).Rows(i).Item("seal9").ToString + " " + ds.Tables(0).Rows(i).Item("type9").ToString


                    Else
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("saycontainer").ToString '"" 'ds.Tables(0).Rows(0).Item("saycontainer").ToString 'ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString


                    End If



                    ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString

                    ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("shipper").ToString
                    ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    ';ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    TKiena = 0
                    TKga = 0
                    TKhoia = 0
                    kien = 0
                    kg = 0
                    khoi = 0
                    For j = 1 To 9
                        If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                            kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                        End If
                        If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                            kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                        End If
                        If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                            khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                        End If


                    Next
                    TKiena += kien
                    TKga += kg
                    TKhoia += khoi

                    TKien += kien
                    TKg += kg
                    TKhoi += khoi
                    ws.Range("e" + CStr(tang)).Value2 = FormatNumber(kien.ToString, 0) + "  " + ds.Tables(0).Rows(i).Item("pkgs").ToString '
                    ws.Range("f" + CStr(tang)).Value2 = FormatNumber(kg.ToString, 2) + " KGS "

                    ws.Range("g" + CStr(tang)).Value2 = FormatNumber(khoi.ToString, 2) + " CBM "
                    If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("h" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("type1").ToString '
                    End If


                    tang += 1
                Next
                '''''' kiem tra sale
                Dim item As String
                Dim sqlK As String
                Dim dsK As New DataSet
                Dim sqlK1 As String
                Dim dsK1 As New DataSet
                Dim rowtang As Integer = 0
                Me.DataGridView1.Rows.Clear()
                If Me.chkSale.Checked = True Then
                    For j = 0 To ds.Tables(0).Rows.Count - 1


                        For i = 1 To 10
                            If ds.Tables(0).Rows(j).Item("Quantitydebit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1) '------------------------
                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" '
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString '---------------------------
                                ' kiem tra ---like  N'%" & Me.txtCompany.Text.Trim & "%'
                                sqlK = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString & "%' and show='TRUE' "
                                dsK = ReadDataSet(sqlK)
                                If dsK.Tables(0).Rows.Count > 0 Then

                                    If UCase(ds.Tables(0).Rows(j).Item("currencydebit" + CStr(i)).ToString) = "USD" Then
                                        If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        Else
                                            'ws.Range("j" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("deUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        End If

                                    Else
                                        If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osusd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        Else
                                            'ws.Range("k" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("devnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        End If

                                    End If
                                    rowtang += 1
                                    tangP += 1
                                End If


                                '----------------end kiem tra
                            End If
                            If ds.Tables(0).Rows(j).Item("Quantitycredit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1)
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString '---------------------------

                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" ''
                                sqlK1 = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(j).Item("Itemstruocthuecredit" + CStr(i)).ToString & "%' and show='TRUE' "
                                dsK1 = ReadDataSet(sqlK1)
                                If dsK1.Tables(0).Rows.Count > 0 Then
                                    If UCase(ds.Tables(0).Rows(j).Item("currencycredit" + CStr(i)).ToString) = "USD" Then
                                        If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osvnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        Else
                                            'ws.Range("l" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("creUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        End If

                                    Else
                                        If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        Else

                                            'ws.Range("m" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("creVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        End If

                                    End If
                                    rowtang += 1
                                    tangP += 1
                                End If
                            End If

                        Next
                    Next

                Else
                    For j = 0 To ds.Tables(0).Rows.Count - 1


                        For i = 1 To 10
                            If ds.Tables(0).Rows(j).Item("Quantitydebit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1) '------------------------
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString '---------------------------

                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" '

                                If UCase(ds.Tables(0).Rows(j).Item("currencydebit" + CStr(i)).ToString) = "USD" Then
                                    If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("deUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        ' ws.Range("j" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    End If

                                Else
                                    If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osusd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("devnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        'ws.Range("k" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    End If

                                End If
                                rowtang += 1
                                tangP += 1
                            End If
                            If ds.Tables(0).Rows(j).Item("Quantitycredit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1)
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString '---------------------------


                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" ''
                                If UCase(ds.Tables(0).Rows(j).Item("currencycredit" + CStr(i)).ToString) = "USD" Then
                                    If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osvnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        'ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("creUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        ' ws.Range("l" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    End If

                                Else
                                    If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        ' ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("creVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        'ws.Range("m" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    End If

                                End If
                                rowtang += 1
                                tangP += 1
                            End If


                        Next
                    Next

                End If


            End If
            InsertAutoNumberToGrid(Me.DataGridView1)
            ' xoa ----
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from tamjob  "
            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            '-----------------------
            'insert to table
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim l As Integer
            For l = 0 To Me.DataGridView1.Rows.Count - 1
                If IsNothing(Me.DataGridView1.Item("item", l).Value) = False Then


                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM tamJOB "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("item").Value = Me.DataGridView1.Item("item", l).Value
                        .Fields("deusd").Value = IIf(IsNothing(Me.DataGridView1.Item("deusd", l).Value) = True, 0, Me.DataGridView1.Item("deusd", l).Value)
                        .Fields("devnd").Value = IIf(IsNothing(Me.DataGridView1.Item("devnd", l).Value) = True, 0, Me.DataGridView1.Item("devnd", l).Value)

                        .Fields("creusd").Value = IIf(IsNothing(Me.DataGridView1.Item("creusd", l).Value) = True, 0, Me.DataGridView1.Item("creusd", l).Value)
                        .Fields("crevnd").Value = IIf(IsNothing(Me.DataGridView1.Item("crevnd", l).Value) = True, 0, Me.DataGridView1.Item("crevnd", l).Value)

                        .Fields("osusd").Value = IIf(IsNothing(Me.DataGridView1.Item("osusd", l).Value) = True, 0, Me.DataGridView1.Item("osusd", l).Value)
                        .Fields("osvnd").Value = IIf(IsNothing(Me.DataGridView1.Item("osvnd", l).Value) = True, 0, Me.DataGridView1.Item("osvnd", l).Value)



                        .Update()
                        rs.Close()
                        '-----------------------------------
                    End With
                End If
            Next
            '-----chen vao excel
            Dim sqlp As String
            Dim dsp As New DataSet
            Dim p As Integer
            Dim r As Integer = 0
            Dim tangD As Integer = 9
            sqlp = " select item,sum(deusd) as deusd,sum(devnd) as devnd,sum(creusd) as creusd,sum(crevnd) as crevnd,sum(osusd) as osDe,sum(osvnd) as osCre  from tamjob group by item "
            dsp = ReadDataSet(sqlp)
            If dsp.Tables(0).Rows.Count > 0 Then
                For p = 0 To dsp.Tables(0).Rows.Count - 1
                    ws.Range("i" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("item").ToString '
                    ws.Range("j" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("deusd").ToString '
                    ws.Range("k" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("devnd").ToString '

                    ws.Range("l" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("creusd").ToString '
                    ws.Range("m" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("crevnd").ToString '

                    ws.Range("n" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("osde").ToString '
                    ws.Range("o" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("oscre").ToString '
                    tangD += 1
                Next
            End If



            '---------------
            ws.Range("f3").Value2 = FormatNumber(TKg.ToString, 2) + " KGS" ' tong sokg s.Tables(0).Rows(0).Item("carrier").ToString
            ws.Range("g3").Value2 = FormatNumber(TKhoi.ToString, 2) + " CBM"

            ws.Range("c28").Value2 = "=sum(j9:j" + CStr(tangD - 1) + ")"

            ws.Range("d28").Value2 = "=sum(k9:k" + CStr(tangD - 1) + ")"

            ws.Range("e28").Value2 = "=sum(l9:l" + CStr(tangD - 1) + ")"
            ws.Range("f28").Value2 = "=sum(m9:m" + CStr(tangD - 1) + ")"

            Dim tongUSD As Double = 0
            Dim tongVND As Double = 0


            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\JOB " & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmdOKH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKH.Click
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = True
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\JOB.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer '= Me.dgdStatement.RowCount - 1
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            'sqlC = " select * from customer where customer_id='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'"
            'dsC = ReadDataSet(sqlC)
            'If dsC.Tables(0).Rows.Count > 0 Then
            '    cus = dsC.Tables(0).Rows(0).Item("company").ToString
            '    add = dsC.Tables(0).Rows(0).Item("address").ToString
            '    tel = dsC.Tables(0).Rows(0).Item("tel").ToString
            '    fax = dsC.Tables(0).Rows(0).Item("fax").ToString
            '    taxcode = dsC.Tables(0).Rows(0).Item("taxcode").ToString
            'End If
            'ws.Range("b4").Value2 = cus
            'ws.Range("b5").Value2 = "Add :" + add
            'ws.Range("b6").Value2 = "Tel: " + tel + " Fax: " + fax
            'ws.Range("b7").Value2 = "Taxcode :" + taxcode

            'ws.Range("h4").Value2 = Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h6").Value2 = Me.dtpto.Value.Date.ToOADate - Me.dtpFrom.Value.Date.ToOADate  'Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h7").Value2 = Me.dtpFrom.Value.Date.ToString.Replace("12:00:00 AM", "") + "     " + Me.dtpto.Value.Date.ToString.Replace("12:00:00 AM", "")
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 8
            Dim ds As New DataSet
            Dim sql As String
            Dim i As Integer = 0
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            sql = " select * from inbound where hbl='" & Me.cboHBL.Text & "' order by dateUpdate "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                If Me.chkSale.Checked = True Then
                    ws.Range("f1").Value2 = "JOB SALE"
                End If
                ws.Range("a1").Value2 = ds.Tables(0).Rows(0).Item("ref").ToString

                ws.Range("a25").Value2 = ds.Tables(0).Rows(0).Item("agencyname").ToString
                ws.Range("a3").Value2 = ds.Tables(0).Rows(0).Item("vessel").ToString + " / " + ds.Tables(0).Rows(0).Item("voyage").ToString
                ws.Range("b3").Value2 = ds.Tables(0).Rows(0).Item("sailingdate").ToString
                ws.Range("c3").Value2 = ds.Tables(0).Rows(0).Item("ETA").ToString

                ws.Range("d3").Value2 = ds.Tables(0).Rows(0).Item("shippingline").ToString
                '--------------------------


                'For j = 1 To 9
                '    If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                '        kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                '        kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                '        khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                '    End If

                'Next
                '-------------------------------


                ws.Range("i3").Value2 = ds.Tables(0).Rows(0).Item("POL").ToString

                ws.Range("k3").Value2 = ds.Tables(0).Rows(0).Item("DEST").ToString
                ws.Range("l3").Value2 = ds.Tables(0).Rows(0).Item("salecode").ToString

                If UCase(ds.Tables(0).Rows(0).Item("LCL").ToString) = "TRUE" Then
                    ws.Range("m3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                    ws.Range("n3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("consol").ToString) = "TRUE" Then
                    ws.Range("l3").Value2 = "x"
                End If
                ws.Range("a5").Value2 = ds.Tables(0).Rows(0).Item("MBL").ToString
                '-------------------dem bill house
                Dim dsH As New DataSet
                Dim sqlH As String
                sqlH = " select count(*) as sl from inbound where mbl='" & Me.cboMBL.Text & "' and continued=1  "
                dsH = ReadDataSet(sqlH)
                If dsH.Tables(0).Rows.Count > 0 Then

                    ws.Range("b5").Value2 = dsH.Tables(0).Rows(0).Item("sl").ToString
                End If

                ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("importCY").ToString
                ws.Range("e5").Value2 = ds.Tables(0).Rows(0).Item("kho").ToString
                ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString
                kien = 0
                kg = 0
                khoi = 0



                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lay tung house
                    If UCase(ds.Tables(0).Rows(i).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(i).Item("containerno1").ToString + " " + ds.Tables(0).Rows(i).Item("seal1").ToString + " " + ds.Tables(0).Rows(i).Item("type1").ToString + " " + ds.Tables(0).Rows(i).Item("containerno2").ToString + " " + ds.Tables(0).Rows(i).Item("seal2").ToString + " " + ds.Tables(0).Rows(i).Item("type2").ToString + " " + ds.Tables(0).Rows(i).Item("containerno3").ToString + " " + ds.Tables(0).Rows(i).Item("seal3").ToString + " " + ds.Tables(0).Rows(i).Item("type3").ToString + " " + ds.Tables(0).Rows(i).Item("containerno4").ToString + " " + ds.Tables(0).Rows(i).Item("seal4").ToString + " " + ds.Tables(0).Rows(i).Item("type4").ToString + " " + ds.Tables(0).Rows(i).Item("containerno5").ToString + " " + ds.Tables(0).Rows(i).Item("seal5").ToString + " " + ds.Tables(0).Rows(i).Item("type5").ToString + " " + ds.Tables(0).Rows(i).Item("containerno6").ToString + " " + ds.Tables(0).Rows(i).Item("seal6").ToString + " " + ds.Tables(0).Rows(i).Item("type6").ToString + " " + ds.Tables(0).Rows(i).Item("containerno7").ToString + " " + ds.Tables(0).Rows(i).Item("seal7").ToString + " " + ds.Tables(0).Rows(i).Item("type7").ToString + " " + ds.Tables(0).Rows(i).Item("containerno8").ToString + " " + ds.Tables(0).Rows(i).Item("seal8").ToString + " " + ds.Tables(0).Rows(i).Item("type8").ToString + " " + ds.Tables(0).Rows(i).Item("containerno9").ToString + " " + ds.Tables(0).Rows(i).Item("seal9").ToString + " " + ds.Tables(0).Rows(i).Item("type9").ToString


                    Else
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("saycontainer").ToString '"" 'ds.Tables(0).Rows(0).Item("saycontainer").ToString 'ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString


                    End If
                    ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString

                    ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("shipper").ToString
                    ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    ';ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    TKiena = 0
                    TKga = 0
                    TKhoia = 0
                    kien = 0
                    kg = 0
                    khoi = 0

                    For j = 1 To 9
                        If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                            kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                        End If
                        If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                            kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                        End If
                        If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                            khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                        End If


                    Next
                    TKiena += kien
                    TKga += kg
                    TKhoia += khoi

                    TKien += kien
                    TKg += kg
                    TKhoi += khoi
                    ws.Range("e" + CStr(tang)).Value2 = FormatNumber(TKiena.ToString, 0) + "  " + ds.Tables(0).Rows(i).Item("pkgs").ToString '
                    ws.Range("f" + CStr(tang)).Value2 = FormatNumber(TKga.ToString, 2) + " KGS "

                    ws.Range("g" + CStr(tang)).Value2 = FormatNumber(TKhoia.ToString, 2) + " CBM "
                    If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("h" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("type1").ToString '
                    End If


                    tang += 1
                Next
                '''''' kiem tra sale
                Dim item As String
                Dim sqlK As String
                Dim dsK As New DataSet
                Dim sqlK1 As String
                Dim dsK1 As New DataSet
                Dim rowtang As Integer = 0
                Me.DataGridView1.Rows.Clear()
                If Me.chkSale.Checked = True Then
                    For j = 0 To ds.Tables(0).Rows.Count - 1


                        For i = 1 To 10
                            If ds.Tables(0).Rows(j).Item("Quantitydebit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1) '------------------------
                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" '
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString '---------------------------
                                ' kiem tra ---like  N'%" & Me.txtCompany.Text.Trim & "%'
                                sqlK = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString & "%' and show='TRUE' "
                                dsK = ReadDataSet(sqlK)
                                If dsK.Tables(0).Rows.Count > 0 Then

                                    If UCase(ds.Tables(0).Rows(j).Item("currencydebit" + CStr(i)).ToString) = "USD" Then
                                        If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        Else
                                            'ws.Range("j" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("deUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        End If

                                    Else
                                        If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osusd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        Else
                                            'ws.Range("k" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("devnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        End If

                                    End If
                                    rowtang += 1
                                    tangP += 1
                                End If


                                '----------------end kiem tra
                            End If
                            If ds.Tables(0).Rows(j).Item("Quantitycredit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1)
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString '---------------------------

                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" ''
                                sqlK1 = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString & "%' and show='TRUE' "
                                dsK1 = ReadDataSet(sqlK1)
                                If dsK1.Tables(0).Rows.Count > 0 Then
                                    If UCase(ds.Tables(0).Rows(j).Item("currencycredit" + CStr(i)).ToString) = "USD" Then
                                        If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osvnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        Else
                                            'ws.Range("l" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("creUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        End If

                                    Else
                                        If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                            'ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("osVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        Else

                                            'ws.Range("m" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                            Me.DataGridView1.Item("creVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString
                                        End If

                                    End If
                                    rowtang += 1
                                    tangP += 1
                                End If
                            End If

                        Next
                    Next

                Else
                    For j = 0 To ds.Tables(0).Rows.Count - 1


                        For i = 1 To 10
                            If ds.Tables(0).Rows(j).Item("Quantitydebit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1) '------------------------
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString '---------------------------

                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" '

                                If UCase(ds.Tables(0).Rows(j).Item("currencydebit" + CStr(i)).ToString) = "USD" Then
                                    If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString
                                        'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("deUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        ' ws.Range("j" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    End If

                                Else
                                    If UCase(ds.Tables(0).Rows(j).Item("OSdebit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osusd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        'ws.Range("n" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("devnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

                                        'ws.Range("k" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricedebit" + CStr(i)).ToString '
                                    End If

                                End If
                                rowtang += 1
                                tangP += 1
                            End If
                            If ds.Tables(0).Rows(j).Item("Quantitycredit" + CStr(i)).ToString.Trim <> "" Then
                                Me.DataGridView1.Rows.Add(1)
                                Me.DataGridView1.Item("item", rowtang).Value = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString '---------------------------


                                'ws.Range("i" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("Itemscredit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")" ''
                                If UCase(ds.Tables(0).Rows(j).Item("currencycredit" + CStr(i)).ToString) = "USD" Then
                                    If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osvnd", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        'ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("creUSD", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        ' ws.Range("l" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    End If

                                Else
                                    If UCase(ds.Tables(0).Rows(j).Item("OSCredit" + CStr(i)).ToString) = "TRUE" Then
                                        Me.DataGridView1.Item("osVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        ' ws.Range("o" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    Else
                                        Me.DataGridView1.Item("creVND", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + CStr(i)).ToString

                                        'ws.Range("m" + CStr(tangP)).Value2 = ds.Tables(0).Rows(j).Item("pricecredit" + CStr(i)).ToString '
                                    End If

                                End If
                                rowtang += 1
                                tangP += 1
                            End If


                        Next
                    Next

                End If


            End If
            InsertAutoNumberToGrid(Me.DataGridView1)
            ' xoa ----
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from tamjob  "
            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            '-----------------------
            'insert to table
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim l As Integer
            For l = 0 To Me.DataGridView1.Rows.Count - 1
                If IsNothing(Me.DataGridView1.Item("item", l).Value) = False Then


                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM tamJOB "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("item").Value = Me.DataGridView1.Item("item", l).Value
                        .Fields("deusd").Value = IIf(IsNothing(Me.DataGridView1.Item("deusd", l).Value) = True, 0, Me.DataGridView1.Item("deusd", l).Value)
                        .Fields("devnd").Value = IIf(IsNothing(Me.DataGridView1.Item("devnd", l).Value) = True, 0, Me.DataGridView1.Item("devnd", l).Value)

                        .Fields("creusd").Value = IIf(IsNothing(Me.DataGridView1.Item("creusd", l).Value) = True, 0, Me.DataGridView1.Item("creusd", l).Value)
                        .Fields("crevnd").Value = IIf(IsNothing(Me.DataGridView1.Item("crevnd", l).Value) = True, 0, Me.DataGridView1.Item("crevnd", l).Value)

                        .Fields("osusd").Value = IIf(IsNothing(Me.DataGridView1.Item("osusd", l).Value) = True, 0, Me.DataGridView1.Item("osusd", l).Value)
                        .Fields("osvnd").Value = IIf(IsNothing(Me.DataGridView1.Item("osvnd", l).Value) = True, 0, Me.DataGridView1.Item("osvnd", l).Value)



                        .Update()
                        rs.Close()
                        '-----------------------------------
                    End With
                End If
            Next
            '-----chen vao excel
            Dim sqlp As String
            Dim dsp As New DataSet
            Dim p As Integer
            Dim r As Integer = 0
            Dim tangD As Integer = 9
            sqlp = " select item,sum(deusd) as deusd,sum(devnd) as devnd,sum(creusd) as creusd,sum(crevnd) as crevnd,sum(osusd) as osDe,sum(osvnd) as osCre  from tamjob group by item "
            dsp = ReadDataSet(sqlp)
            If dsp.Tables(0).Rows.Count > 0 Then
                For p = 0 To dsp.Tables(0).Rows.Count - 1
                    ws.Range("i" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("item").ToString '
                    ws.Range("j" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("deusd").ToString '
                    ws.Range("k" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("devnd").ToString '

                    ws.Range("l" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("creusd").ToString '
                    ws.Range("m" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("crevnd").ToString '

                    ws.Range("n" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("osde").ToString '
                    ws.Range("o" + CStr(tangD)).Value2 = dsp.Tables(0).Rows(p).Item("oscre").ToString '
                    tangD += 1
                Next
            End If



            '---------------
            ws.Range("f3").Value2 = FormatNumber(TKg.ToString, 2) + " KGS" ' tong sokg s.Tables(0).Rows(0).Item("carrier").ToString
            ws.Range("g3").Value2 = FormatNumber(TKhoi.ToString, 2) + " CBM"

            ws.Range("c28").Value2 = "=sum(j9:j" + CStr(tangD - 1) + ")"

            ws.Range("d28").Value2 = "=sum(k9:k" + CStr(tangD - 1) + ")"

            ws.Range("e28").Value2 = "=sum(l9:l" + CStr(tangD - 1) + ")"
            ws.Range("f28").Value2 = "=sum(m9:m" + CStr(tangD - 1) + ")"

            Dim tongUSD As Double = 0
            Dim tongVND As Double = 0


            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\JOB " & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub

    Private Sub frmJOBIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id, value, strSQL As String
        Me.cboMBL.Items.Clear()
        id = "ref"
        value = "ref"
        strSQL = "Select distinct ref,ref From outbound where Continued=1 "
        loadDataToObject(Me.cboMBL, strSQL, id, value)
        'loadDataToObject(Me.txtOPL, strSQL, id, value)
        'loadDataToObject(Me.txtPOD, strSQL, id, value)
        'id = "blob_id"
        'value = "hbl"
        'Me.cboHBL.Items.Clear()
        'strSQL = "Select distinct blib_id,hbl From outbound where Continued=1 "
        'loadDataToObject(Me.cboHBL, strSQL, id, value)
        SetDefaultGrid(Me.DataGridView1, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.BackColor = gMaunen
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = True
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\OCEANINBOUND.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer '= Me.dgdStatement.RowCount - 1
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            'sqlC = " select * from customer where customer_id='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'"
            'dsC = ReadDataSet(sqlC)
            'If dsC.Tables(0).Rows.Count > 0 Then
            '    cus = dsC.Tables(0).Rows(0).Item("company").ToString
            '    add = dsC.Tables(0).Rows(0).Item("address").ToString
            '    tel = dsC.Tables(0).Rows(0).Item("tel").ToString
            '    fax = dsC.Tables(0).Rows(0).Item("fax").ToString
            '    taxcode = dsC.Tables(0).Rows(0).Item("taxcode").ToString
            'End If
            'ws.Range("b4").Value2 = cus
            'ws.Range("b5").Value2 = "Add :" + add
            'ws.Range("b6").Value2 = "Tel: " + tel + " Fax: " + fax
            'ws.Range("b7").Value2 = "Taxcode :" + taxcode

            'ws.Range("h4").Value2 = Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h6").Value2 = Me.dtpto.Value.Date.ToOADate - Me.dtpFrom.Value.Date.ToOADate  'Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h7").Value2 = Me.dtpFrom.Value.Date.ToString.Replace("12:00:00 AM", "") + "     " + Me.dtpto.Value.Date.ToString.Replace("12:00:00 AM", "")
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 8
            Dim ds As New DataSet
            Dim sql As String
            Dim i As Integer = 0
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            sql = " select * from outbound where ref='" & Me.cboMBL.Text & "' order by dateUpdate  "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                ws.Range("a1").Value2 = ds.Tables(0).Rows(0).Item("ref").ToString

                ws.Range("b1").Value2 = ds.Tables(0).Rows(0).Item("agencyname").ToString
                ws.Range("a3").Value2 = ds.Tables(0).Rows(0).Item("vessel").ToString + " / " + ds.Tables(0).Rows(0).Item("voyage").ToString
                ws.Range("b3").Value2 = ds.Tables(0).Rows(0).Item("sailingdate").ToString
                ws.Range("c3").Value2 = ds.Tables(0).Rows(0).Item("ETA").ToString

                ws.Range("d3").Value2 = ds.Tables(0).Rows(0).Item("shippingline").ToString
                '--------------------------


                'For j = 1 To 9
                '    If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                '        kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                '        kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                '        khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                '    End If

                'Next
                '-------------------------------


                ws.Range("i3").Value2 = ds.Tables(0).Rows(0).Item("POL").ToString

                ws.Range("k3").Value2 = ds.Tables(0).Rows(0).Item("DEST").ToString
                ws.Range("l3").Value2 = ds.Tables(0).Rows(0).Item("salecode").ToString

                If UCase(ds.Tables(0).Rows(0).Item("LCL").ToString) = "TRUE" Then
                    ws.Range("m3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                    ws.Range("n3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("consol").ToString) = "TRUE" Then
                    ws.Range("l3").Value2 = "x"
                End If
                ws.Range("a5").Value2 = ds.Tables(0).Rows(0).Item("MBLcarrier").ToString
                '-------------------dem bill house
                Dim dsH As New DataSet
                Dim sqlH As String
                sqlH = " select count(*) as sl from inbound where ref='" & Me.cboMBL.Text & "' and continued=1  "
                dsH = ReadDataSet(sqlH)
                If dsH.Tables(0).Rows.Count > 0 Then

                    ws.Range("b5").Value2 = dsH.Tables(0).Rows(0).Item("sl").ToString
                End If

                ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("importCY").ToString
                ' ws.Range("e5").Value2 = ds.Tables(0).Rows(0).Item("kho").ToString
                ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("saycontainer").ToString 'ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString
                kien = 0
                kg = 0
                khoi = 0



                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lay tung house




                    ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblmawb").ToString

                    ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("shipper").ToString
                    ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    ';ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    TKiena = 0
                    TKga = 0
                    TKhoia = 0
                    kien = 0
                    kg = 0
                    khoi = 0
                    ' co blib_id
                    Dim cont As String
                    Dim sqlw As String
                    Dim dsw As New DataSet
                    sqlw = "select * from containertype where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                    dsw = ReadDataSet(sqlw)
                    '---------------
                    If dsw.Tables(0).Rows.Count > 0 Then


                        For j = 0 To dsw.Tables(0).Rows.Count - 1
                            Try
                                kien += dsw.Tables(0).Rows(j).Item("sokien").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                kg += dsw.Tables(0).Rows(j).Item("sokg").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                khoi += dsw.Tables(0).Rows(j).Item("sokhoi").ToString
                            Catch ex As Exception

                            End Try
                            cont += dsw.Tables(0).Rows(j).Item("containerno").ToString + "; "

                        Next
                    End If

                    TKiena += kien
                    TKga += kg
                    TKhoia += khoi
                    TKien += kien
                    TKg += kg
                    TKhoi += khoi
                    '=------------
                    If UCase(ds.Tables(0).Rows(i).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("i5").Value2 = cont 'ds.Tables(0).Rows(i).Item("containerno1").ToString + " " + ds.Tables(0).Rows(i).Item("seal1").ToString + " " + ds.Tables(0).Rows(i).Item("type1").ToString + " " + ds.Tables(0).Rows(i).Item("containerno2").ToString + " " + ds.Tables(0).Rows(i).Item("seal2").ToString + " " + ds.Tables(0).Rows(i).Item("type2").ToString + " " + ds.Tables(0).Rows(i).Item("containerno3").ToString + " " + ds.Tables(0).Rows(i).Item("seal3").ToString + " " + ds.Tables(0).Rows(i).Item("type3").ToString + " " + ds.Tables(0).Rows(i).Item("containerno4").ToString + " " + ds.Tables(0).Rows(i).Item("seal4").ToString + " " + ds.Tables(0).Rows(i).Item("type4").ToString + " " + ds.Tables(0).Rows(i).Item("containerno5").ToString + " " + ds.Tables(0).Rows(i).Item("seal5").ToString + " " + ds.Tables(0).Rows(i).Item("type5").ToString + " " + ds.Tables(0).Rows(i).Item("containerno6").ToString + " " + ds.Tables(0).Rows(i).Item("seal6").ToString + " " + ds.Tables(0).Rows(i).Item("type6").ToString + " " + ds.Tables(0).Rows(i).Item("containerno7").ToString + " " + ds.Tables(0).Rows(i).Item("seal7").ToString + " " + ds.Tables(0).Rows(i).Item("type7").ToString + " " + ds.Tables(0).Rows(i).Item("containerno8").ToString + " " + ds.Tables(0).Rows(i).Item("seal8").ToString + " " + ds.Tables(0).Rows(i).Item("type8").ToString + " " + ds.Tables(0).Rows(i).Item("containerno9").ToString + " " + ds.Tables(0).Rows(i).Item("seal9").ToString + " " + ds.Tables(0).Rows(i).Item("type9").ToString


                    Else
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("saycontainer").ToString '"" 'ds.Tables(0).Rows(0).Item("saycontainer").ToString 'ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString


                    End If
                    '--------------------------------
                    ws.Range("e" + CStr(tang)).Value2 = FormatNumber(TKiena.ToString, 0) + "  " + ds.Tables(0).Rows(i).Item("pkgs").ToString '
                    ws.Range("f" + CStr(tang)).Value2 = FormatNumber(TKga.ToString, 2) + " KGS "

                    ws.Range("g" + CStr(tang)).Value2 = FormatNumber(TKhoia.ToString, 2) + " CBM "
                    'If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                    '    ws.Range("h" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("type1").ToString '
                    'End If
                    ' TIEP OCEAN
                    ws.Range("i" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("bl_type").ToString '
                    'ws.Range("k" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("nhanlenh").ToString '
                    'ws.Range("m" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("nguoinhanlenh").ToString '
                    'ws.Range("n" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("ngaynhanlenh").ToString '
                    tang += 1
                Next



            End If
            ws.Range("e3").Value2 = TKien.ToString
            ws.Range("f3").Value2 = FormatNumber(TKg.ToString, 2) + " KGS" ' tong sokg s.Tables(0).Rows(0).Item("carrier").ToString
            ws.Range("g3").Value2 = FormatNumber(TKhoi.ToString, 2) + " CBM"



            Dim tongUSD As Double = 0
            Dim tongVND As Double = 0


            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\OceanOutbound " & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = True
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\OCEANINBOUND.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer '= Me.dgdStatement.RowCount - 1
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            'sqlC = " select * from customer where customer_id='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'"
            'dsC = ReadDataSet(sqlC)
            'If dsC.Tables(0).Rows.Count > 0 Then
            '    cus = dsC.Tables(0).Rows(0).Item("company").ToString
            '    add = dsC.Tables(0).Rows(0).Item("address").ToString
            '    tel = dsC.Tables(0).Rows(0).Item("tel").ToString
            '    fax = dsC.Tables(0).Rows(0).Item("fax").ToString
            '    taxcode = dsC.Tables(0).Rows(0).Item("taxcode").ToString
            'End If
            'ws.Range("b4").Value2 = cus
            'ws.Range("b5").Value2 = "Add :" + add
            'ws.Range("b6").Value2 = "Tel: " + tel + " Fax: " + fax
            'ws.Range("b7").Value2 = "Taxcode :" + taxcode

            'ws.Range("h4").Value2 = Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h6").Value2 = Me.dtpto.Value.Date.ToOADate - Me.dtpFrom.Value.Date.ToOADate  'Getdate().ToString.Replace("12:00:00 AM", "")
            'ws.Range("h7").Value2 = Me.dtpFrom.Value.Date.ToString.Replace("12:00:00 AM", "") + "     " + Me.dtpto.Value.Date.ToString.Replace("12:00:00 AM", "")
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 8
            Dim ds As New DataSet
            Dim sql As String
            Dim i As Integer = 0
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            sql = " select * from inbound where hbl='" & Me.cboHBL.Text & "' order by dateUpdate "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                ws.Range("a1").Value2 = ds.Tables(0).Rows(0).Item("ref").ToString

                ws.Range("a25").Value2 = ds.Tables(0).Rows(0).Item("agencyname").ToString
                ws.Range("a3").Value2 = ds.Tables(0).Rows(0).Item("vessel").ToString + " / " + ds.Tables(0).Rows(0).Item("voyage").ToString
                ws.Range("b3").Value2 = ds.Tables(0).Rows(0).Item("sailingdate").ToString
                ws.Range("c3").Value2 = ds.Tables(0).Rows(0).Item("ETA").ToString

                ws.Range("d3").Value2 = ds.Tables(0).Rows(0).Item("shippingline").ToString
                '--------------------------


                'For j = 1 To 9
                '    If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                '        kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                '        kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                '    End If
                '    If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                '        khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                '    End If

                'Next
                '-------------------------------


                ws.Range("i3").Value2 = ds.Tables(0).Rows(0).Item("POL").ToString

                ws.Range("k3").Value2 = ds.Tables(0).Rows(0).Item("DEST").ToString
                ws.Range("l3").Value2 = ds.Tables(0).Rows(0).Item("salecode").ToString

                If UCase(ds.Tables(0).Rows(0).Item("LCL").ToString) = "TRUE" Then
                    ws.Range("m3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                    ws.Range("n3").Value2 = "x"
                End If
                If UCase(ds.Tables(0).Rows(0).Item("consol").ToString) = "TRUE" Then
                    ws.Range("l3").Value2 = "x"
                End If
                ws.Range("a5").Value2 = ds.Tables(0).Rows(0).Item("MBL").ToString
                '-------------------dem bill house
                Dim dsH As New DataSet
                Dim sqlH As String
                sqlH = " select count(*) as sl from inbound where mbl='" & Me.cboMBL.Text & "' and continued=1  "
                dsH = ReadDataSet(sqlH)
                If dsH.Tables(0).Rows.Count > 0 Then

                    ws.Range("b5").Value2 = dsH.Tables(0).Rows(0).Item("sl").ToString
                End If

                ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("importCY").ToString
                ws.Range("e5").Value2 = ds.Tables(0).Rows(0).Item("kho").ToString
                ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString
                kien = 0
                kg = 0
                khoi = 0



                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lay tung house
                    If UCase(ds.Tables(0).Rows(i).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(i).Item("containerno1").ToString + " " + ds.Tables(0).Rows(i).Item("seal1").ToString + " " + ds.Tables(0).Rows(i).Item("type1").ToString + " " + ds.Tables(0).Rows(i).Item("containerno2").ToString + " " + ds.Tables(0).Rows(i).Item("seal2").ToString + " " + ds.Tables(0).Rows(i).Item("type2").ToString + " " + ds.Tables(0).Rows(i).Item("containerno3").ToString + " " + ds.Tables(0).Rows(i).Item("seal3").ToString + " " + ds.Tables(0).Rows(i).Item("type3").ToString + " " + ds.Tables(0).Rows(i).Item("containerno4").ToString + " " + ds.Tables(0).Rows(i).Item("seal4").ToString + " " + ds.Tables(0).Rows(i).Item("type4").ToString + " " + ds.Tables(0).Rows(i).Item("containerno5").ToString + " " + ds.Tables(0).Rows(i).Item("seal5").ToString + " " + ds.Tables(0).Rows(i).Item("type5").ToString + " " + ds.Tables(0).Rows(i).Item("containerno6").ToString + " " + ds.Tables(0).Rows(i).Item("seal6").ToString + " " + ds.Tables(0).Rows(i).Item("type6").ToString + " " + ds.Tables(0).Rows(i).Item("containerno7").ToString + " " + ds.Tables(0).Rows(i).Item("seal7").ToString + " " + ds.Tables(0).Rows(i).Item("type7").ToString + " " + ds.Tables(0).Rows(i).Item("containerno8").ToString + " " + ds.Tables(0).Rows(i).Item("seal8").ToString + " " + ds.Tables(0).Rows(i).Item("type8").ToString + " " + ds.Tables(0).Rows(i).Item("containerno9").ToString + " " + ds.Tables(0).Rows(i).Item("seal9").ToString + " " + ds.Tables(0).Rows(i).Item("type9").ToString


                    Else
                        ws.Range("i5").Value2 = ds.Tables(0).Rows(0).Item("saycontainer").ToString '"" 'ds.Tables(0).Rows(0).Item("saycontainer").ToString 'ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString


                    End If

                    ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString

                    ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("shipper").ToString
                    ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    ';ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    TKiena = 0
                    TKga = 0
                    TKhoia = 0
                    kien = 0
                    kg = 0
                    khoi = 0

                    For j = 1 To 9
                        If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString <> "" Then
                            kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString)
                        End If
                        If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString <> "" Then
                            kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString)
                        End If
                        If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString <> "" Then
                            khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString)
                        End If


                    Next
                    TKiena += kien
                    TKga += kg
                    TKhoia += khoi
                    TKien += kien
                    TKg += kg
                    TKhoi += khoi
                    ws.Range("e" + CStr(tang)).Value2 = FormatNumber(TKiena.ToString, 0) + "  " + ds.Tables(0).Rows(i).Item("pkgs").ToString '
                    ws.Range("f" + CStr(tang)).Value2 = FormatNumber(TKga.ToString, 2) + " KGS "

                    ws.Range("g" + CStr(tang)).Value2 = FormatNumber(TKhoia.ToString, 2) + " CBM "
                    If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                        ws.Range("h" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("type1").ToString '
                    End If
                    ' TIEP OCEAN
                    ws.Range("i" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("bl_type").ToString '
                    ws.Range("k" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("nhanlenh").ToString '
                    ws.Range("m" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("nguoinhanlenh").ToString '
                    ws.Range("n" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("ngaynhanlenh").ToString '

                    tang += 1
                Next



            End If
            ws.Range("e3").Value2 = TKien.ToString
            ws.Range("f3").Value2 = FormatNumber(TKg.ToString, 2) + " KGS" ' tong sokg s.Tables(0).Rows(0).Item("carrier").ToString
            ws.Range("g3").Value2 = FormatNumber(TKhoi.ToString, 2) + " CBM"



            Dim tongUSD As Double = 0
            Dim tongVND As Double = 0


            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\OceanInbound " & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub
End Class