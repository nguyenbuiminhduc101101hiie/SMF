Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmJobIBPrint

    Private Sub frmjobIBPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim id, value, strSQL As String
            Me.cboMBL.Items.Clear()
            id = "ref"
            value = "ref"
            strSQL = "Select distinct ref,ref From inbound where Continued=1 "
            loadDataToObject(Me.cboMBL, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

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

            path = StartupPath & "\JOBprint.xls"

            workbook = workbooks.Open(path)

            'Dim pathsave As String = ""
            'pathsave = OpenDlg(" " & " .xls")

            '"c:\" & stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"

            'If pathsave = "" Then
            '    Exit Sub
            'End If


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
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 11
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

                ws.Range("e2").Value2 = ds.Tables(0).Rows(0).Item("ref").ToString

                ws.Range("c4").Value2 = ds.Tables(0).Rows(0).Item("agencyname").ToString

                ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("vessel").ToString
                ' ws.Range("b3").Value2 = ds.Tables(0).Rows(0).Item("sailingdate").ToString

                ws.Range("f6").Value2 = ds.Tables(0).Rows(0).Item("voyage").ToString

                ws.Range("c6").Value2 = ds.Tables(0).Rows(0).Item("ETA").ToString

                ws.Range("e1").Value2 = ds.Tables(0).Rows(0).Item("shippingline").ToString
                '--------------------------



                '-------------------------------


                ws.Range("c7").Value2 = ds.Tables(0).Rows(0).Item("POL").ToString

                ws.Range("f7").Value2 = ds.Tables(0).Rows(0).Item("pod").ToString
                'ws.Range("l3").Value2 = ds.Tables(0).Rows(0).Item("salecode").ToString

                'If UCase(ds.Tables(0).Rows(0).Item("LCL").ToString) = "TRUE" Then
                '    ws.Range("m3").Value2 = "x"
                'End If
                'If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                '    ws.Range("n3").Value2 = "x"
                'End If
                'If UCase(ds.Tables(0).Rows(0).Item("consol").ToString) = "TRUE" Then
                '    ws.Range("l3").Value2 = "x"
                'End If
                ws.Range("h4").Value2 = ds.Tables(0).Rows(0).Item("MBL").ToString
                '-------------------dem bill house
                Dim dsH As New DataSet
                Dim sqlH As String
                sqlH = " select count(*) as sl from inbound where ref='" & Me.cboMBL.Text & "' and continued=1  "
                dsH = ReadDataSet(sqlH)
                If dsH.Tables(0).Rows.Count > 0 Then

                    'ws.Range("b5").Value2 = dsH.Tables(0).Rows(0).Item("sl").ToString
                End If

                'ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("importCY").ToString
                'ws.Range("e5").Value2 = ds.Tables(0).Rows(0).Item("kho").ToString


                Dim k As Integer

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lay tung house

                    ' If UCase(ds.Tables(0).Rows(i).Item("FCL").ToString) = "TRUE" Then
                    For k = 1 To 46
                        ' If ds.Tables(0).Rows(i).Item("containerno" + k.ToString).ToString <> ds.Tables(0).Rows(i).Item("containerno" + k.ToString).ToString Then
                         ' End If

                    Next


                    'Else
                    'ws.Range("h5").Value2 = ds.Tables(0).Rows(0).Item("saycontainer").ToString '"" 'ds.Tables(0).Rows(0).Item("saycontainer").ToString 'ds.Tables(0).Rows(0).Item("containerno1").ToString + " " + ds.Tables(0).Rows(0).Item("seal1").ToString + " " + ds.Tables(0).Rows(0).Item("type1").ToString + " " + ds.Tables(0).Rows(0).Item("containerno2").ToString + " " + ds.Tables(0).Rows(0).Item("seal2").ToString + " " + ds.Tables(0).Rows(0).Item("type2").ToString + " " + ds.Tables(0).Rows(0).Item("containerno3").ToString + " " + ds.Tables(0).Rows(0).Item("seal3").ToString + " " + ds.Tables(0).Rows(0).Item("type3").ToString + " " + ds.Tables(0).Rows(0).Item("containerno4").ToString + " " + ds.Tables(0).Rows(0).Item("seal4").ToString + " " + ds.Tables(0).Rows(0).Item("type4").ToString + " " + ds.Tables(0).Rows(0).Item("containerno5").ToString + " " + ds.Tables(0).Rows(0).Item("seal5").ToString + " " + ds.Tables(0).Rows(0).Item("type5").ToString + " " + ds.Tables(0).Rows(0).Item("containerno6").ToString + " " + ds.Tables(0).Rows(0).Item("seal6").ToString + " " + ds.Tables(0).Rows(0).Item("type6").ToString + " " + ds.Tables(0).Rows(0).Item("containerno7").ToString + " " + ds.Tables(0).Rows(0).Item("seal7").ToString + " " + ds.Tables(0).Rows(0).Item("type7").ToString + " " + ds.Tables(0).Rows(0).Item("containerno8").ToString + " " + ds.Tables(0).Rows(0).Item("seal8").ToString + " " + ds.Tables(0).Rows(0).Item("type8").ToString + " " + ds.Tables(0).Rows(0).Item("containerno9").ToString + " " + ds.Tables(0).Rows(0).Item("seal9").ToString + " " + ds.Tables(0).Rows(0).Item("type9").ToString


                    'End If



                    ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString

                    ws.Range("k" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("bl_type").ToString
                    Try
                        Dim tach() As String
                        tach = ds.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))
                        ws.Range("e" + CStr(tang)).Value2 = tach(0)
                    Catch ex As Exception

                    End Try



                    ';ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                    TKiena = 0
                    TKga = 0
                    TKhoia = 0
                    kien = 0
                    kg = 0
                    khoi = 0
                    ' lay so kien,kg,khoi
                    Dim sql1 As String
                    Dim ds1 As New DataSet
                    sql1 = "select * from inbound left join containerrepair on containerrepair.inboundid=inbound.blib_id where hbl='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "' "
                    ds1 = ReadDataSet(sql1)
                    If ds1.Tables(0).Rows.Count > 0 Then
                        For j = 0 To ds1.Tables(0).Rows.Count - 1
                            If ds1.Tables(0).Rows(j).Item("sokien").ToString <> "" Then
                                kien += CDbl(ds1.Tables(0).Rows(j).Item("sokien").ToString)
                            End If
                            If ds1.Tables(0).Rows(j).Item("sokg").ToString <> "" Then
                                kg += CDbl(ds1.Tables(0).Rows(j).Item("sokg").ToString)
                            End If
                            If ds1.Tables(0).Rows(j).Item("sokhoi").ToString <> "" Then
                                khoi += CDbl(ds1.Tables(0).Rows(j).Item("sokhoi").ToString)
                            End If
                            ws.Range("h5").Value2 += ds1.Tables(0).Rows(j).Item("containerno").ToString + " " + ds1.Tables(0).Rows(j).Item("seal").ToString + " " + ds1.Tables(0).Rows(j).Item("type").ToString ' + " " + ds.Tables(0).Rows(i).Item("containerno2").ToString + " " + ds.Tables(0).Rows(i).Item("seal2").ToString + " " + ds.Tables(0).Rows(i).Item("type2").ToString + " " + ds.Tables(0).Rows(i).Item("containerno3").ToString + " " + ds.Tables(0).Rows(i).Item("seal3").ToString + " " + ds.Tables(0).Rows(i).Item("type3").ToString + " " + ds.Tables(0).Rows(i).Item("containerno4").ToString + " " + ds.Tables(0).Rows(i).Item("seal4").ToString + " " + ds.Tables(0).Rows(i).Item("type4").ToString + " " + ds.Tables(0).Rows(i).Item("containerno5").ToString + " " + ds.Tables(0).Rows(i).Item("seal5").ToString + " " + ds.Tables(0).Rows(i).Item("type5").ToString + " " + ds.Tables(0).Rows(i).Item("containerno6").ToString + " " + ds.Tables(0).Rows(i).Item("seal6").ToString + " " + ds.Tables(0).Rows(i).Item("type6").ToString + " " + ds.Tables(0).Rows(i).Item("containerno7").ToString + " " + ds.Tables(0).Rows(i).Item("seal7").ToString + " " + ds.Tables(0).Rows(i).Item("type7").ToString + " " + ds.Tables(0).Rows(i).Item("containerno8").ToString + " " + ds.Tables(0).Rows(i).Item("seal8").ToString + " " + ds.Tables(0).Rows(i).Item("type8").ToString + " " + ds.Tables(0).Rows(i).Item("containerno9").ToString + " " + ds.Tables(0).Rows(i).Item("seal9").ToString + " " + ds.Tables(0).Rows(i).Item("type9").ToString



                        Next
                    End If
                    '---------------------------
                    ' ws.Range("j" + CStr(tang)).Value2 = FormatNumber(khoi.ToString, 3)
                    TKiena += kien
                    TKga += kg
                    TKhoia += khoi

                    TKien += kien
                    TKg += kg
                    TKhoi += khoi
                    ws.Range("g" + CStr(tang)).Value2 = FormatNumber(kien.ToString, 0) '+ "  " + ds.Tables(0).Rows(i).Item("pkgs").ToString '
                    ws.Range("h" + CStr(tang)).Value2 = FormatNumber(kg.ToString, 3)

                    ws.Range("i" + CStr(tang)).Value2 = FormatNumber(khoi.ToString, 3)

                    'If UCase(ds.Tables(0).Rows(0).Item("FCL").ToString) = "TRUE" Then
                    '    ws.Range("h" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("type1").ToString '
                    'End If


                    tang += 1
                Next
                '''''' kiem tra sale
                Dim item As String
                Dim sqlK As String
                Dim dsK As New DataSet
                Dim sqlK1 As String
                Dim dsK1 As New DataSet
                Dim rowtang As Integer = 0




            End If


            ws.Range("h6").Value2 = TKien.ToString
            ws.Range("h7").Value2 = TKg.ToString
            ws.Range("j6").Value2 = TKhoi.ToString


            Dim tangD As Integer = 9

            'For j = 0 To ds.Tables(0).Rows.Count - 1


            '    For i = 1 To 10
            '        If ds.Tables(0).Rows(j).Item("Quantitydebit" + CStr(i)).ToString.Trim <> "" Then
            '            ws.Range("i" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("Itemsdebit" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")"
            '            ws.Range("j" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("currencydebit" + CStr(i)).ToString
            '            ws.Range("k" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString

            '            ws.Range("l" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + CStr(i)).ToString * tigia(ds.Tables(0).Rows(j).Item("currencydebit" + CStr(i)).ToString, CDate(ds.Tables(0).Rows(0).Item("ETA").ToString).Date)

            '            tangD += 1
            '        End If
            '    Next
            'Next

            'For j = 0 To ds.Tables(0).Rows.Count - 1


            '    For i = 1 To 10
            '        If ds.Tables(0).Rows(j).Item("QuantityCREDIT" + CStr(i)).ToString.Trim <> "" Then
            '            ws.Range("i" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("ItemsCREDIT" + CStr(i)).ToString + " (" + ds.Tables(0).Rows(j).Item("hbl").ToString + ")"
            '            ws.Range("j" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("currencyCREDIT" + CStr(i)).ToString
            '            ws.Range("M" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("pricetruocthueCREDIT" + CStr(i)).ToString

            '            ws.Range("N" + CStr(tangD)).Value2 = ds.Tables(0).Rows(j).Item("pricetruocthueCREDIT" + CStr(i)).ToString * tigia(ds.Tables(0).Rows(j).Item("currencyCREDIT" + CStr(i)).ToString, CDate(ds.Tables(0).Rows(0).Item("ETA").ToString).Date)

            '            tangD += 1
            '        End If
            '    Next
            'Next
            ''End If





            Dim tongUSD As Double = 0
            Dim tongVND As Double = 0


            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + Me.cboMBL.Text + " " + Now.Second.ToString & ".xls"

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
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class