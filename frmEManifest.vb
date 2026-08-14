Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DevExpress.Pdf.Native.BouncyCastle.Asn1.X509
Imports Excel
Imports System.Data.OleDb
Public Class frmEManifest


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'If Me.chkopt1.Checked = True Then
            '    opt1()
            'End If
            'If Me.chkopt2.Checked = True Then

            '    opt2()
            'End If

            If Me.chkd.Checked = True Then

                optd()
            End If

            If Me.chkcocnew.Checked = True Then

                opt_newCOC()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub opt_newCOC()
        Try
            Dim app As Application
            Dim i As Integer = 0
            Try

                Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                Dim path As String
                app = New Application()
                app.Visible = False
                Dim dsdata As New DataSet
                Dim workbooks As Workbooks
                workbooks = app.Workbooks
                Dim workbook As _Workbook


                path = StartupPath & "\MANIFEST_new.xlsx"

                workbook = workbooks.Open(path)



                Dim sheets As Sheets
                sheets = workbook.Worksheets
                Dim ws As _Worksheet
                ws = sheets.Item(4)
                If ws Is Nothing Then
                    app.Quit()

                    Return
                End If
                Dim DongCongThuc As Integer = 9
                Dim DongHienTai As Integer = 11
                Dim donghientaiF As Integer = DongHienTai
                Dim BillId As String
                Dim n As Integer
                Dim dem As Integer = 0
                Dim BillNo As String = ""
                Dim market As String = ""
                ' lay ten khach hang
                Dim sqlC As String
                Dim cus, add, tel, fax, taxcode As String
                Dim dsC As New DataSet
                Dim j As Integer

                Dim tangP As Integer = 9
                Dim tang As Integer = 26
                Dim ds As New DataSet
                Dim sql As String


                Dim stt As Integer = 1
                Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
                Dim kien As Double = 0
                Dim kg As Double = 0
                Dim khoi As Double = 0
                Dim hbl As String
                '-----------8/8/17
                Dim tangct As Integer = 4
                Dim tangcont As Integer = 7
                Dim bientang As Integer = 0
                '----------------------------
                Dim sqlContainer As String
                Dim dsContainer As New DataSet
                If Me.chkjob.Checked = True Then
                    sql = "select * from inbound where ref='" & gEManifestNew & "' order by stt" 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,''"

                Else
                    sql = "select * from inbound where blib_id='" & gInboundID & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,''"

                End If








                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    ' hien thi thong tin co ban
                    ' ban moi 8/8/17
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Try
                            ws.Range("a" + CStr(tangct + bientang)).Value2 = (i + 1)
                        Catch ex As Exception

                        End Try
                        Try
                            ws.Range("b" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("sohoso").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            ws.Range("c" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("namdangkyhoso").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            ws.Range("d" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("chucnangcuachungtu").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            ws.Range("e" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("nguoiguihang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                        Catch ex As Exception

                        End Try

                        'ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("tentau").ToString
                        ' F G H: TAXCODE#company#ADDRESS from customer via inbound.customerid_showtc
                        Dim showtcFG As String = ""
                        Try
                            Dim cusIdShowTC As String = ds.Tables(0).Rows(i).Item("customerid_showtc").ToString
                            If cusIdShowTC <> "" AndAlso cusIdShowTC <> "{}" Then
                                sqlC = "select taxcode, company, address from customer where customer_id='" & cusIdShowTC & "'"
                                dsC = ReadDataSet(sqlC)
                                If dsC.Tables(0).Rows.Count > 0 Then
                                    Dim taxC As String = dsC.Tables(0).Rows(0).Item("taxcode").ToString
                                    Dim companyC As String = dsC.Tables(0).Rows(0).Item("company").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                                    Dim addressC As String = dsC.Tables(0).Rows(0).Item("address").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                                    showtcFG = taxC & "#" & companyC & "#" & addressC
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            ws.Range("f" + CStr(tangct + bientang)).Value2 = showtcFG
                        Catch ex As Exception
                        End Try
                        Try
                            ws.Range("g" + CStr(tangct + bientang)).Value2 = showtcFG
                        Catch ex As Exception
                        End Try
                        Try
                            ws.Range("h" + CStr(tangct + bientang)).Value2 = showtcFG
                        Catch ex As Exception
                        End Try


                        Dim canggiaohang() As String
                        Dim cangxephang() As String
                        Dim cangdohang() As String
                        Try
                            ' Column I left blank intentionally
                            ws.Range("i" + CStr(tangct + bientang)).Value2 = ""
                        Catch ex As Exception

                        End Try

                        Try
                            canggiaohang = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString.Split("-")
                            ws.Range("j" + CStr(tangct + bientang)).Value2 = canggiaohang(0)
                        Catch ex As Exception

                        End Try

                        Try
                            cangxephang = ds.Tables(0).Rows(i).Item("cangxephang").ToString.Split("-") '
                            ws.Range("k" + CStr(tangct + bientang)).Value2 = cangxephang(0)

                        Catch ex As Exception

                        End Try
                        Try
                            cangdohang = ds.Tables(0).Rows(i).Item("cangdohang").ToString.Split("-") '

                            ws.Range("l" + CStr(tangct + bientang)).Value2 = cangdohang(0)
                        Catch ex As Exception

                        End Try

                        Try
                            ws.Range("m" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("diadiemgiaohang").ToString '


                            If ds.Tables(0).Rows(i).Item("gflc").ToString = "F" Then
                                ws.Range("n" + CStr(tangct + bientang)).Value2 = "CY/CY"
                            Else
                                ws.Range("n" + CStr(tangct + bientang)).Value2 = "CFS/ CFS"
                            End If

                            ws.Range("o" + CStr(tangct + bientang)).Value2 = "'" + ds.Tables(0).Rows(i).Item("sovandon").ToString '

                            Try
                                WriteEManifestDate(ws, "p", tangct + bientang, ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDon"))

                            Catch ex As Exception

                            End Try
                            Try
                                ws.Range("q" + CStr(tangct + bientang)).Value2 = "'" + ds.Tables(0).Rows(i).Item("sovandongoc").ToString '

                            Catch ex As Exception

                            End Try
                            If Me.chkjob.Checked = True Then
                                Try
                                    hbl = ds.Tables(0).Rows(i).Item("soVanDonGoc").ToString
                                Catch ex As Exception
                                    DisplayMessage(True, "Chưa có số vận đơn gốc ở tab Emanifest")
                                    app.Quit()
                                End Try

                            Else
                                hbl = ds.Tables(0).Rows(i).Item("hbl").ToString
                            End If

                            Try
                                WriteEManifestDate(ws, "r", tangct + bientang, ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDongoc"))

                            Catch ex As Exception

                            End Try
                            Try
                                WriteEManifestDate(ws, "s", tangct + bientang, ds.Tables(0).Rows(i).Item("ngaykhoihanh"))

                            Catch ex As Exception

                            End Try
                            ws.Range("t" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
                            '
                            Dim tongtrongluong As Double = 0
                            Dim pkgskhac, loaikien As String
                            sqlContainer = " select * from containerrepair where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' "
                            dsContainer = ReadDataSet(sqlContainer)
                            If dsContainer.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dsContainer.Tables(0).Rows.Count - 1


                                    Try
                                        tongtrongluong += CDbl(dsContainer.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        pkgskhac += UCase(dsContainer.Tables(0).Rows(j).Item("type").ToString.Trim.Split("-")(1)) + ";"

                                    Catch ex As Exception

                                    End Try
                                Next

                            End If

                            If gBranch = "HAN" Then
                                ' lay check


                                Try

                                    pkgskhac = pkgskhac.Remove(pkgskhac.Length - 1, 1)
                                    Dim tachpkgs() As String = pkgskhac.Split(";")
                                    Dim icheck As Integer
                                    For icheck = 0 To tachpkgs.Length - 1
                                        If tachpkgs(0) = tachpkgs(icheck) Then
                                            Try
                                                Dim tlk() As String
                                                tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
                                                ws.Range("u" + CStr(tangct + bientang)).Value2 = tlk(0) 'ds.Tables(0).Rows(i).Item("loaikien").ToString
                                                ' ws.Range("b22").Value2 = tlk(0)
                                            Catch ex As Exception
                                                'ws.Range("b22").Value2 = ""
                                                ws.Range("u" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
                                            End Try
                                        Else

                                            ws.Range("u" + CStr(tangct + bientang)).Value2 = "PK"
                                            Exit For
                                        End If
                                    Next


                                    '''''''''''''''''''''
                                Catch ex As Exception

                                End Try




                            Else
                                Try
                                    Dim tlk() As String
                                    tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
                                    ws.Range("u" + CStr(tangct + bientang)).Value2 = tlk(0) 'ds.Tables(0).Rows(i).Item("loaikien").ToString
                                    ' ws.Range("b22").Value2 = tlk(0)
                                Catch ex As Exception
                                    'ws.Range("b22").Value2 = ""
                                    ws.Range("u" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
                                End Try

                            End If





                            ws.Range("v" + CStr(tangct + bientang)).Cells.NumberFormat = "@"
                            'ws.Range("v" + CStr(tangct + bientang)).Cells.FillRight()
                            ws.Range("v" + CStr(tangct + bientang)).Value2 = tongtrongluong

                            ws.Range("W" + CStr(tangct + bientang)).Value2 = "KGM"
                            ws.Range("x" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("ghichu").ToString '












                        Catch ex As Exception

                        End Try

                        sqlContainer = " select * from containerrepair where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                        dsContainer = ReadDataSet(sqlContainer)
                        If dsContainer.Tables(0).Rows.Count > 0 Then
                            For j = 0 To dsContainer.Tables(0).Rows.Count - 1
                                'If dsContainer.Tables(0).Rows.Count > 3 Then
                                '    bientang += 1
                                'End If
                                'ws.Rows(tangcont + bientang).insert()
                                ws.Range("b" + CStr(tangcont + bientang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '


                                If dsContainer.Tables(0).Rows(j).Item("descriptionContainer").ToString <> "" Then
                                    ws.Range("c" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("descriptionContainer").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ") '

                                Else
                                    ws.Range("c" + CStr(tangcont + bientang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ") '

                                End If
                                ws.Range("d" + CStr(tangcont + bientang)).Cells.NumberFormat = "@"
                                '   ws.Range("d" + CStr(tangcont + bientang)).Cells.FillRight()
                                ws.Range("d" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString

                                ws.Range("e" + CStr(tangcont + bientang)).Cells.NumberFormat = "@"
                                ' ws.Range("e" + CStr(tangcont + bientang)).Cells.FillRight()
                                ws.Range("e" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString
                                ws.Range("f" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString
                                ws.Range("g" + CStr(tangcont + bientang)).Value2 = "'" + dsContainer.Tables(0).Rows(j).Item("seal").ToString
                                tangcont += 1
                            Next

                        End If



                        tangcont += 2
                        tangct = tangcont
                        tangcont += 3
                        ws.Range("b6:g6").Copy()
                        ws.Range("b" + (tangcont - 1).ToString + ":g" + (tangcont - 1).ToString).PasteSpecial(Excel.XlPasteType.xlPasteAll)

                        ws.Range("A3:x3").Copy()
                        ws.Range("A" + (tangct - 1).ToString + ":x" + (tangct - 1).ToString).PasteSpecial(Excel.XlPasteType.xlPasteAll)


                    Next
                End If
                ws.Range("b" + (tangcont - 1).ToString + ":g" + (tangcont - 1).ToString).Delete()
                ws.Range("A" + (tangct - 1).ToString + ":x" + (tangct - 1).ToString).Delete()

                ' sum

                ' Dim path As String = ""
                ' path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SITC\" + hbl + "_" & Now.Second & ".xlsx")
                'If path = "" Then



                '------------------------------
                path = PromptEManifestSavePath(hbl)
                If path = "" Then
                    Return
                End If
                '------------------------------
                Dim format1 As String


                workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
                DisplayMessage(True, "File name : " & path & " saved.")




            Catch ex As Exception
                MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
                MsgBox(Err.Description + "/" + i)
                Return
            Finally
                app.Quit()
            End Try
        Catch ex As Exception

        End Try
    End Sub
    'Public Sub opt_newCOC()
    '    Try
    '         Dim app As Application
    '        Try

    '            Dim Alpha(As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    '            Dim path As String
    '            app = New Application()
    '            app.Visible = False
    '            Dim dsdata As New DataSet
    '            Dim workbooks As Workbooks
    '            workbooks = app.Workbooks
    '            Dim workbook As _Workbook


    '            path = StartupPath & "\MANIFEST_new.xlsx"

    '            workbook = workbooks.Open(path)



    '            Dim sheets As Sheets
    '            sheets = workbook.Worksheets
    '            Dim ws As _Worksheet
    '            ws = sheets.Item(4)
    '            If ws Is Nothing Then
    '                app.Quit()

    '                Return
    '            End If
    '            Dim DongCongThuc As Integer = 9
    '            Dim DongHienTai As Integer = 11
    '            Dim donghientaiF As Integer = DongHienTai
    '            Dim BillId As String
    '            Dim n As Integer
    '            Dim dem As Integer = 0
    '            Dim BillNo As String = ""
    '            Dim market As String = ""
    '            ' lay ten khach hang
    '            Dim sqlC As String
    '            Dim cus, add, tel, fax, taxcode As String
    '            Dim dsC As New DataSet
    '            Dim j As Integer

    '            Dim tangP As Integer = 9
    '            Dim tang As Integer = 26
    '            Dim ds As New DataSet
    '            Dim sql As String
    '            Dim i As Integer = 0

    '            Dim stt As Integer = 1
    '            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
    '            Dim kien As Double = 0
    '            Dim kg As Double = 0
    '            Dim khoi As Double = 0
    '            Dim hbl As String
    '            '-----------8/8/17
    '            Dim tangct As Integer = 4
    '            Dim tangcont As Integer = 7
    '            Dim bientang As Integer = 0
    '            '----------------------------
    '            Dim sqlContainer As String
    '            Dim dsContainer As New DataSet

    '            sql = "select * from inbound where ref='" & gEManifestNew & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,''"








    '            ds = ReadDataSet(sql)
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                ' hien thi thong tin co ban
    '                ' ban moi 8/8/17
    '                For i = 0 To ds.Tables(0).Rows.Count - 1
    '                    Try
    '                        ws.Range("a" + CStr(tangct + bientang)).Value2 = (i + 1)
    '                    Catch ex As Exception

    '                    End Try
    '                    Try
    '                        ws.Range("b" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("sohoso").ToString
    '                    Catch ex As Exception

    '                    End Try
    '                    Try
    '                        ws.Range("c" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("namdangkyhoso").ToString
    '                    Catch ex As Exception

    '                    End Try

    '                    Try
    '                        ws.Range("d" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("chucnangcuachungtu").ToString
    '                    Catch ex As Exception

    '                    End Try
    '                    Try
    '                        ws.Range("e" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("nguoiguihang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
    '                    Catch ex As Exception

    '                    End Try

    '                    'ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("tentau").ToString
    '                    Try
    '                        ws.Range("f" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
    '                    Catch ex As Exception

    '                    End Try
    '                    Try
    '                        ws.Range("g" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("notify1").ToString
    '                    Catch ex As Exception

    '                    End Try
    '                    Try
    '                        ws.Range("h" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("notify2").ToString
    '                    Catch ex As Exception

    '                    End Try


    '                    Dim cangchuyentai(As String
    '                    Dim canggiaohang(As String
    '                    Dim cangxephang() As String
    '                    Dim cangdohang() As String
    '                    Try
    '                        cangchuyentai = ds.Tables(0).Rows(i).Item("cangchuyentai").ToString.Split("-")
    '                        ws.Range("i" + CStr(tangct + bientang)).Value2 = cangchuyentai(0) ' code
    '                        ' ws.Range("b11").Value2 = cangchuyentai(1) 'ds.Tables(0).Rows(i).Item("nguoiguihang").ToString
    '                    Catch ex As Exception

    '                    End Try

    '                    Try
    '                        canggiaohang = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString.Split("-")
    '                        ws.Range("j" + CStr(tangct + bientang)).Value2 = canggiaohang(0)
    '                    Catch ex As Exception

    '                    End Try

    '                    Try
    '                        cangxephang = ds.Tables(0).Rows(i).Item("cangxephang").ToString.Split("-") '
    '                        ws.Range("k" + CStr(tangct + bientang)).Value2 = cangxephang(0)

    '                    Catch ex As Exception

    '                    End Try
    '                    Try
    '                        cangdohang = ds.Tables(0).Rows(i).Item("cangdohang").ToString.Split("-") '

    '                        ws.Range("l" + CStr(tangct + bientang)).Value2 = cangdohang(0)
    '                    Catch ex As Exception

    '                    End Try

    '                    Try
    '                        ws.Range("m" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("diadiemgiaohang").ToString '


    '                        ws.Range("n" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("loaihang").ToString '

    '                        ws.Range("o" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("sovandon").ToString '

    '                        Try
    '                            ws.Range("p" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDon").ToString.Replace("-", "/") '

    '                        Catch ex As Exception

    '                        End Try
    '                        ws.Range("q" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("sovandongoc").ToString '
    '                        hbl = ds.Tables(0).Rows(i).Item("sovandongoc").ToString
    '                        Try
    '                            ws.Range("r" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDongoc").ToString.Replace("-", "/") '

    '                        Catch ex As Exception

    '                        End Try
    '                        Try
    '                            ws.Range("s" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("ngaykhoihanh").ToString.Replace("-", "/") '

    '                        Catch ex As Exception

    '                        End Try
    '                        ws.Range("t" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
    '                        '


    '                        Try
    '                            Dim tlk() As String
    '                            tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
    '                            ws.Range("u" + CStr(tangct + bientang)).Value2 = tlk(0) 'ds.Tables(0).Rows(i).Item("loaikien").ToString
    '                            ' ws.Range("b22").Value2 = tlk(0)
    '                        Catch ex As Exception
    '                            'ws.Range("b22").Value2 = ""
    '                            ws.Range("u" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
    '                        End Try


    '                        Dim tongtrongluong As Double = 0
    '                        sqlContainer = " select * from containerrepair where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'"
    '                        dsContainer = ReadDataSet(sqlContainer)
    '                        If dsContainer.Tables(0).Rows.Count > 0 Then
    '                            For j = 0 To dsContainer.Tables(0).Rows.Count - 1


    '                                Try
    '                                    tongtrongluong += CDbl(dsContainer.Tables(0).Rows(j).Item("sokg").ToString)
    '                                Catch ex As Exception

    '                                End Try


    '                            Next

    '                        End If
    '                        ws.Range("v" + CStr(tangct + bientang)).Value2 = tongtrongluong
    '                        ws.Range("W" + CStr(tangct + bientang)).Value2 = "KGM"
    '                        ws.Range("x" + CStr(tangct + bientang)).Value2 = ds.Tables(0).Rows(i).Item("ghichu").ToString '












    '                    Catch ex As Exception

    '                    End Try

    '                    sqlContainer = " select * from containerrepair where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' "
    '                    dsContainer = ReadDataSet(sqlContainer)
    '                    If dsContainer.Tables(0).Rows.Count > 0 Then
    '                        For j = 0 To dsContainer.Tables(0).Rows.Count - 1
    '                            'If dsContainer.Tables(0).Rows.Count > 3 Then
    '                            '    bientang += 1
    '                            'End If
    '                            'ws.Rows(tangcont + bientang).insert()
    '                            ws.Range("b" + CStr(tangcont + bientang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
    '                            ws.Range("c" + CStr(tangcont + bientang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ") '


    '                            ws.Range("d" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString

    '                            ws.Range("e" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString
    '                            ws.Range("f" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString
    '                            ws.Range("g" + CStr(tangcont + bientang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString
    '                            tangcont += 1
    '                        Next

    '                    End If
    '                    tangcont += 2
    '                    tangct = tangcont
    '                    tangcont += 3

    '                Next
    '            End If
    '            ' sum

    '            ' Dim path As String = ""
    '            ' path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SITC\" + hbl + "_" & Now.Second & ".xlsx")
    '            'If path = "" Then



    '            '------------------------------
    '            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + hbl + "_" & Now.Second & ".xlsx"
    '            'End If
    '            '------------------------------
    '            Dim format1 As String


    '            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
    '            DisplayMessage(True, "File name : " & path & " saved.")




    '        Catch ex As Exception
    '            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
    '            MsgBox(Err.Description)
    '            Return
    '        Finally
    '            app.Quit()
    '        End Try
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Public Sub opt1() ' XUAT SOC
        Dim app As Application
        Try

            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = False

            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook


            path = StartupPath & "\EMANIFEST.xlsx"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(3)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 10
            Dim ds As New DataSet
            Dim sql, HBL As String
            Dim i As Integer = 0

            Dim stt As Integer = 1
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            '-----------
            Dim sqlContainer As String
            Dim dsContainer As New DataSet

            '  sql = "select * from inbound where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate>= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate<= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "





            sql = "select * from " & gPrintInbound & " where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,''"








            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    HBL = ds.Tables(0).Rows(i).Item("sovandon").ToString
                    ws.Range("B6").Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
                    Try
                        Dim tlk() As String
                        tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
                        ws.Range("B7").Value2 = tlk(0)
                    Catch ex As Exception
                        'ws.Range("b22").Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
                    End Try















                    sqlContainer = " select * from containerrepair where inboundid='" & gEManifest & "'"
                    dsContainer = ReadDataSet(sqlContainer)
                    If dsContainer.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dsContainer.Tables(0).Rows.Count - 1
                            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sovandon").ToString '
                            ws.Range("B" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("shipper").ToString '
                            ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString '
                            ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("notify").ToString '
                            ws.Range("f" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString '
                            ws.Range("g" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString '
                            ws.Range("h" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
                            ws.Range("i" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString + " (" + dsContainer.Tables(0).Rows(j).Item("sokien").ToString + " " + dsContainer.Tables(0).Rows(j).Item("type").ToString + ")" '
                            ws.Range("j" + CStr(tang)).Value2 = "0" 'ds.Tables(0).Rows(i).Item("description").ToString + " (" + dsContainer.Tables(0).Rows(j).Item("sokien").ToString + ")" '
                            ws.Range("k" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString '
                            ws.Range("l" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString '
                            ws.Range("o" + CStr(tang)).Value2 = "KGM" 'dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString '
                            ws.Range("p" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("podcode").ToString '
                            ws.Range("q" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("podcode").ToString '
                            ws.Range("r" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("polcode").ToString '
                            ws.Range("s" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("polcode").ToString '

                            ws.Range("u" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("podcode").ToString '
                            ws.Range("v" + CStr(tang)).Value2 = IIf(dsContainer.Tables(0).Rows(j).Item("containertype").ToString Like "*40*", "Container 40", dsContainer.Tables(0).Rows(j).Item("containertype").ToString) '
                            ws.Range("w" + CStr(tang)).Value2 = "CM3"


                            '---------------
                            'ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
                            'ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ") '


                            'ws.Range("c" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString
                            'ws.Range("d" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString
                            'ws.Range("e" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString
                            'ws.Range("f" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString
                            tang += 1
                        Next

                    End If





                    ' stt += 1
                Next
            End If
            ' sum

            ' Dim path As String = ""
            'path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + hbl + "_" & Now.Second & ".xlsx")
            'If path = "" Then
            path = PromptEManifestSavePath(HBL)
            If path = "" Then
                Return
            End If
            'End If
            '------------------------------
            Dim format1 As String
            '  path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + hbl + "_" & Now.Second & ".xlsx"
            'If app.Version = "11.0" Then
            '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
            'ElseIf (app.Version = "12.0") Then
            '    format1 = Excel.XlFileFormat.xlExcel7 ';   
            'End If
            ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
            DisplayMessage(True, "File name : " & path & " saved.")

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub
    'Public Sub optd(' XUAT SOC
    '    Dim app As Application
    '    Try

    '        Dim Alpha(As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    '        Dim path As String
    '        app = New Application()
    '        app.Visible = False
    '        Dim dsdata As New DataSet
    '        Dim workbooks As Workbooks
    '        workbooks = app.Workbooks
    '        Dim workbook As _Workbook


    '        path = StartupPath & "\EMANIFEST.xlsx"

    '        workbook = workbooks.Open(path)



    '        Dim sheets As Sheets
    '        sheets = workbook.Worksheets
    '        Dim ws As _Worksheet
    '        ws = sheets.Item("Dangerous goods manifest")
    '        If ws Is Nothing Then
    '            app.Quit()

    '            Return
    '        End If
    '        Dim DongCongThuc As Integer = 9
    '        Dim DongHienTai As Integer = 11
    '        Dim donghientaiF As Integer = DongHienTai
    '        Dim BillId As String
    '        Dim n As Integer
    '        Dim dem As Integer = 0
    '        Dim BillNo As String = ""
    '        Dim market As String = ""
    '        ' lay ten khach hang
    '        Dim sqlC As String
    '        Dim cus, add, tel, fax, taxcode As String
    '        Dim dsC As New DataSet
    '        Dim j As Integer

    '        Dim tangP As Integer = 9
    '        Dim tang As Integer = 14
    '        Dim ds As New DataSet
    '        Dim sql As String
    '        Dim i As Integer = 0

    '        Dim stt As Integer = 1
    '        Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
    '        Dim kien As Double = 0
    '        Dim kg As Double = 0
    '        Dim khoi As Double = 0
    '        Dim hbl As String
    '        '-----------
    '        Dim sqlContainer As String
    '        Dim dsContainer As New DataSet

    '        sql = "select * from " & gPrintInbound & " where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate>= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate<= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "








    '        ds = ReadDataSet(sql)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            ' hien thi thong tin co ban
    '            For i = 0 To ds.Tables(0).Rows.Count - 1
    '                Try
    '                    ws.Range("b3").Value2 = ds.Tables(0).Rows(i).Item("sohoso").ToString
    '                Catch ex As Exception

    '                End Try
    '                Try
    '                    ws.Range("b4").Value2 = ds.Tables(0).Rows(i).Item("namdangkyhoso").ToString
    '                Catch ex As Exception

    '                End Try

    '                Try
    '                    ws.Range("b5").Value2 = ds.Tables(0).Rows(i).Item("chucnangcuachungtu").ToString
    '                Catch ex As Exception

    '                End Try
    '                'Try
    '                '    ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("nguoiguihang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
    '                'Catch ex As Exception

    '                'End Try

    '                ''ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("tentau").ToString
    '                'Try
    '                '    ws.Range("b7").Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
    '                'Catch ex As Exception

    '                'End Try
    '                'Try
    '                '    ws.Range("b8").Value2 = ds.Tables(0).Rows(i).Item("notify1").ToString
    '                'Catch ex As Exception

    '                'End Try
    '                'Try
    '                '    ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("notify2").ToString
    '                'Catch ex As Exception

    '                'End Try


    '                Dim cangchuyentai() As String
    '                Dim canggiaohang() As String
    '                Dim cangxephang(As String
    '                Dim cangdohang(As String
    '                'Try
    '                '    cangchuyentai = ds.Tables(0).Rows(i).Item("cangchuyentai").ToString.Split("-")
    '                '    ws.Range("b10").Value2 = cangchuyentai(0) ' code
    '                '    ' ws.Range("b11").Value2 = cangchuyentai(1'ds.Tables(0).Rows(i).Item("nguoiguihang").ToString
    '                'Catch ex As Exception

    '                'End Try

    '                'Try
    '                '    canggiaohang = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString.Split("-")
    '                '    ws.Range("b11").Value2 = canggiaohang(0)
    '                'Catch ex As Exception

    '                'End Try

    '                Try
    '                    cangxephang = ds.Tables(0).Rows(i).Item("cangxephang").ToString.Split("-") '
    '                    ws.Range("b6").Value2 = cangxephang(0)

    '                Catch ex As Exception

    '                End Try
    '                Try
    '                    cangdohang = ds.Tables(0).Rows(i).Item("cangdohang").ToString.Split("-"'

    '                    ws.Range("b7").Value2 = cangdohang(0)
    '                Catch ex As Exception

    '                End Try

    '                Try

    '                    ws.Range("b8").Value2 = ds.Tables(0).Rows(i).Item("d_thongtinbosung").ToString
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("d_noiky").ToString
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    ws.Range("b10").Value2 = ds.Tables(0).Rows(i).Item("d_ngayky").ToString
    '                Catch ex As Exception

    '                End Try

    '                Try

    '                    ws.Range("b11").Value2 = ds.Tables(0).Rows(i).Item("d_nguoiky").ToString
    '                Catch ex As Exception

    '                End Try

    '                'Try
    '                '    ws.Range("b14").Value2 = ds.Tables(0).Rows(i).Item("diadiemgiaohang").ToString '


    '                '    ws.Range("b15").Value2 = ds.Tables(0).Rows(i).Item("loaihang").ToString '

    '                '    ws.Range("b16").Value2 = ds.Tables(0).Rows(i).Item("sovandon").ToString '
    '                '    hbl = ds.Tables(0).Rows(i).Item("sovandon").ToString
    '                '    Try
    '                '        ws.Range("b17").Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDon").ToString.Replace("-", "/") '

    '                '    Catch ex As Exception

    '                '    End Try
    '                '    ws.Range("b18").Value2 = ds.Tables(0).Rows(i).Item("sovandongoc").ToString '
    '                '    Try
    '                '        ws.Range("b19").Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDongoc").ToString.Replace("-", "/") '

    '                '    Catch ex As Exception

    '                '    End Try
    '                '    Try
    '                '        ws.Range("b20").Value2 = ds.Tables(0).Rows(i).Item("ngaykhoihanh").ToString.Replace("-", "/") '

    '                '    Catch ex As Exception

    '                '    End Try
    '                '    ws.Range("b21").Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
    '                '    Try
    '                '        Dim tlk() As String
    '                '        tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
    '                '        ws.Range("b22").Value2 = tlk(0)
    '                '    Catch ex As Exception
    '                '        ws.Range("b22").Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
    '                '    End Try

    '                '    ws.Range("b23").Value2 = ds.Tables(0).Rows(i).Item("ghichu").ToString '
    '                'Catch ex As Exception

    '                'End Try


    '                'Dim cangden() As String
    '                'Try
    '                '    cangden = ds.Tables(0).Rows(i).Item("cangden").ToString.Split("-")
    '                '    ws.Range("b8").Value2 = cangden(1)
    '                'Catch ex As Exception

    '                'End Try


    '                'ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("thoigianden").ToString
    '                'ws.Range("b10").Value2 = ds.Tables(0).Rows(i).Item("hohieu").ToString




    '                'ws.Range("b12").Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString

    '                '  ws.Range("b9").Value2 = cangchuyentai(0) ' ten

    '                'ws.Range("b11").Value2 = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString ' hang xuat















    '                'ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("salecode").ToString
    '                'ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblmawb").ToString
    '                'ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblcarrier").ToString
    '                ' ten khach hang tu customer
    '                ' truong hop cont khong theo luoi
    '                'sqlContainer = " select * from inbound where inboundid='" & gEManifest & "'"
    '                'dsContainer = ReadDataSet(sqlContainer)
    '                sqlContainer = " select * from containerrepair where inboundid='" & gEManifest & "'"
    '                dsContainer = ReadDataSet(sqlContainer)
    '                If dsContainer.Tables(0).Rows.Count > 0 Then
    '                    For j = 0 To dsContainer.Tables(0).Rows.Count - 1
    '                        hbl = ds.Tables(0).Rows(i).Item("hbl").ToString
    '                        ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString ' tuong duong voi sovandon
    '                        ws.Range("b" + CStr(tang)).Value2 = "" ' ki hieu container 


    '                        ws.Range("c" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokien").ToString '
    '                        ws.Range("d" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containertype").ToString

    '                        ws.Range("f" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString 'dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString


    '                        ws.Range("g" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_soun").ToString
    '                        ws.Range("h" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_nhomhang").ToString
    '                        ws.Range("i" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_nhomphuso").ToString
    '                        ws.Range("j" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_diembocchay").ToString
    '                        ws.Range("k" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_onhiembien").ToString
    '                        ws.Range("l" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString
    '                        ws.Range("m" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_vitrixephang").ToString
    '                        ws.Range("n" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString




    '                        ws.Range("o" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString

    '                        ws.Range("p" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString

    '                        tang += 1
    '                    Next

    '                End If

    '                ''If ds.Tables(0).Rows.Count > 0 Then
    '                ''    For j = 1 To 46
    '                ''        If ds.Tables(0).Rows(i).Item("containerno" + j.ToString).ToString <> "" Then
    '                ''            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
    '                ''            ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString '
    '                ''        End If



    '                ''        ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sokg" + j.ToString).ToString
    '                ''        ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sokhoi" + j.ToString).ToString
    '                ''        ws.Range("e" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("containerno" + j.ToString).ToString
    '                ''        ws.Range("f" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("seal" + j.ToString).ToString
    '                ''        tang += 1
    '                ''    Next

    '                ''End If



    '                ' stt += 1
    '            Next
    '        End If
    '        ' sum

    '        ' Dim path As String = ""
    '        'path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + hbl + "_" & Now.Second & ".xlsx")
    '        'If path = "" Then
    '        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments+ "\SMF\_Danger_" + hbl + "_" & Now.Second & ".xlsx"
    '        'End If
    '        '------------------------------
    '        Dim format1 As String
    '        '  path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments+ "\" + hbl + "_" & Now.Second & ".xlsx"
    '        'If app.Version = "11.0" Then
    '        '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
    '        'ElseIf (app.Version = "12.0") Then
    '        '    format1 = Excel.XlFileFormat.xlExcel7 ';   
    '        'End If
    '        ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

    '        workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
    '        DisplayMessage(True, "File name : " & path & " saved.")
    '        '----------
    '        'Dim xlApp As New Excel.Application
    '        'Dim xlWorkBook As Excel.Workbook
    '        'Dim xlWorkSheet As Excel.Worksheet
    '        ''~~> Save As file
    '        'xlWorkBook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,, , , )

    '        ''~~> Close the file
    '        'xlWorkBook.Close()
    '        '--------------------------------------------------------

    '    Catch ex As Exception
    '        MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
    '        MsgBox(Err.Description)
    '        Return
    '    Finally
    '        app.Quit()
    '    End Try
    'End Sub
    Public Sub optd() ' XUAT SOC
        Dim app As Application
        Try

            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = False
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook


            path = StartupPath & "\MANIFEST_new.xlsx"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item("Dangerous goods manifest")
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 14
            Dim ds As New DataSet
            Dim sql As String
            Dim i As Integer = 0

            Dim stt As Integer = 1
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            Dim hbl As String
            '-----------
            Dim sqlContainer As String
            Dim dsContainer As New DataSet

            sql = "select * from " & gPrintInbound & " where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate>= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate<= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "








            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        ws.Range("b3").Value2 = ds.Tables(0).Rows(i).Item("sohoso").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        ws.Range("b4").Value2 = ds.Tables(0).Rows(i).Item("namdangkyhoso").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        ws.Range("b5").Value2 = ds.Tables(0).Rows(i).Item("chucnangcuachungtu").ToString
                    Catch ex As Exception

                    End Try
                    'Try
                    '    ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("nguoiguihang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                    'Catch ex As Exception

                    'End Try

                    ''ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("tentau").ToString
                    'Try
                    '    ws.Range("b7").Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    ws.Range("b8").Value2 = ds.Tables(0).Rows(i).Item("notify1").ToString
                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("notify2").ToString
                    'Catch ex As Exception

                    'End Try


                    Dim cangchuyentai() As String
                    Dim canggiaohang() As String
                    Dim cangxephang() As String
                    Dim cangdohang() As String
                    'Try
                    '    cangchuyentai = ds.Tables(0).Rows(i).Item("cangchuyentai").ToString.Split("-")
                    '    ws.Range("b10").Value2 = cangchuyentai(0) ' code
                    '    ' ws.Range("b11").Value2 = cangchuyentai(1) 'ds.Tables(0).Rows(i).Item("nguoiguihang").ToString
                    'Catch ex As Exception

                    'End Try

                    'Try
                    '    canggiaohang = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString.Split("-")
                    '    ws.Range("b11").Value2 = canggiaohang(0)
                    'Catch ex As Exception

                    'End Try

                    Try
                        cangxephang = ds.Tables(0).Rows(i).Item("cangxephang").ToString.Split("-") '
                        ws.Range("b6").Value2 = cangxephang(0)

                    Catch ex As Exception

                    End Try
                    Try
                        cangdohang = ds.Tables(0).Rows(i).Item("cangdohang").ToString.Split("-") '

                        ws.Range("b7").Value2 = cangdohang(0)
                    Catch ex As Exception

                    End Try

                    Try

                        ws.Range("b8").Value2 = ds.Tables(0).Rows(i).Item("d_thongtinbosung").ToString
                    Catch ex As Exception

                    End Try
                    Try

                        ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("d_noiky").ToString
                    Catch ex As Exception

                    End Try
                    Try

                        ws.Range("b10").Value2 = ds.Tables(0).Rows(i).Item("d_ngayky").ToString
                    Catch ex As Exception

                    End Try

                    Try

                        ws.Range("b11").Value2 = ds.Tables(0).Rows(i).Item("d_nguoiky").ToString
                    Catch ex As Exception

                    End Try

                    'Try
                    '    ws.Range("b14").Value2 = ds.Tables(0).Rows(i).Item("diadiemgiaohang").ToString '


                    '    ws.Range("b15").Value2 = ds.Tables(0).Rows(i).Item("loaihang").ToString '

                    '    ws.Range("b16").Value2 = ds.Tables(0).Rows(i).Item("sovandon").ToString '
                    '    hbl = ds.Tables(0).Rows(i).Item("sovandon").ToString
                    '    Try
                    '        ws.Range("b17").Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDon").ToString.Replace("-", "/"'

                    '    Catch ex As Exception

                    '    End Try
                    '    ws.Range("b18").Value2 = ds.Tables(0).Rows(i).Item("sovandongoc").ToString '
                    '    Try
                    '        ws.Range("b19").Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDongoc").ToString.Replace("-", "/") '

                    '    Catch ex As Exception

                    '    End Try
                    '    Try
                    '        ws.Range("b20").Value2 = ds.Tables(0).Rows(i).Item("ngaykhoihanh").ToString.Replace("-", "/") '

                    '    Catch ex As Exception

                    '    End Try
                    '    ws.Range("b21").Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
                    '    Try
                    '        Dim tlk(As String
                    '        tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
                    '        ws.Range("b22").Value2 = tlk(0)
                    '    Catch ex As Exception
                    '        ws.Range("b22").Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
                    '    End Try

                    '    ws.Range("b23").Value2 = ds.Tables(0).Rows(i).Item("ghichu").ToString '
                    'Catch ex As Exception

                    'End Try


                    'Dim cangden() As String
                    'Try
                    '    cangden = ds.Tables(0).Rows(i).Item("cangden").ToString.Split("-")
                    '    ws.Range("b8").Value2 = cangden(1)
                    'Catch ex As Exception

                    'End Try


                    'ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("thoigianden").ToString
                    'ws.Range("b10").Value2 = ds.Tables(0).Rows(i).Item("hohieu").ToString




                    'ws.Range("b12").Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString

                    '  ws.Range("b9").Value2 = cangchuyentai(0' ten

                    'ws.Range("b11").Value2 = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString ' hang xuat















                    'ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("salecode").ToString
                    'ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    'ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblcarrier").ToString
                    ' ten khach hang tu customer
                    ' truong hop cont khong theo luoi
                    'sqlContainer = " select * from inbound where inboundid='" & gEManifest & "'"
                    'dsContainer = ReadDataSet(sqlContainer)
                    sqlContainer = " select * from containerrepair where inboundid='" & gEManifest & "'"
                    dsContainer = ReadDataSet(sqlContainer)
                    If dsContainer.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dsContainer.Tables(0).Rows.Count - 1
                            hbl = ds.Tables(0).Rows(i).Item("hbl").ToString
                            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString ' tuong duong voi sovandon
                            ws.Range("b" + CStr(tang)).Value2 = "" ' ki hieu container 


                            ws.Range("c" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokien").ToString '
                            ws.Range("d" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containertype").ToString

                            ws.Range("f" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString 'dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString


                            ws.Range("g" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_soun").ToString
                            ws.Range("h" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_nhomhang").ToString
                            ws.Range("i" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_nhomphuso").ToString
                            ws.Range("j" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_diembocchay").ToString
                            ws.Range("k" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_onhiembien").ToString
                            ws.Range("l" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString
                            ws.Range("m" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("d_vitrixephang").ToString
                            ws.Range("n" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString




                            ws.Range("o" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString

                            ws.Range("p" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString

                            tang += 1
                        Next

                    End If

                    ''If ds.Tables(0).Rows.Count > 0 Then
                    ''    For j = 1 To 46
                    ''        If ds.Tables(0).Rows(i).Item("containerno" + j.ToString).ToString <> "" Then
                    ''            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
                    ''            ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString '
                    ''        End If



                    ''        ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sokg" + j.ToString).ToString
                    ''        ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sokhoi" + j.ToString).ToString
                    ''        ws.Range("e" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("containerno" + j.ToString).ToString
                    ''        ws.Range("f" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("seal" + j.ToString).ToString
                    ''        tang += 1
                    ''    Next

                    ''End If



                    ' stt += 1
                Next
            End If
            ' sum

            ' Dim path As String = ""
            'path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments+ "\SMF\" + hbl + "_" & Now.Second & ".xlsx")
            'If path = "" Then
            path = PromptEManifestSavePath(hbl)
            If path = "" Then
                Return
            End If
            'End If
            '------------------------------
            Dim format1 As String
            '  path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + hbl + "_" & Now.Second & ".xlsx"
            'If app.Version = "11.0" Then
            '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
            'ElseIf (app.Version = "12.0") Then
            '    format1 = Excel.XlFileFormat.xlExcel7 ';   
            'End If
            ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
            DisplayMessage(True, "File name : " & path & " saved.")
            '----------
            'Dim xlApp As New Excel.Application
            'Dim xlWorkBook As Excel.Workbook
            'Dim xlWorkSheet As Excel.Worksheet
            ''~~> Save As file
            'xlWorkBook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,, , , )

            ''~~> Close the file
            'xlWorkBook.Close()
            '--------------------------------------------------------

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub
    Public Sub opt2()
        Dim app As Application
        Try

            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = False
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook


            path = StartupPath & "\EMANIFEST.xlsx"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(4)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
            Dim donghientaiF As Integer = DongHienTai
            Dim BillId As String
            Dim n As Integer
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            ' lay ten khach hang
            Dim sqlC As String
            Dim cus, add, tel, fax, taxcode As String
            Dim dsC As New DataSet
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 26
            Dim ds As New DataSet
            Dim sql As String
            Dim i As Integer = 0

            Dim stt As Integer = 1
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            Dim hbl As String
            '-----------
            Dim sqlContainer As String
            Dim dsContainer As New DataSet

            sql = "select * from " & gPrintInbound & " where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,''"








            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        ws.Range("b3").Value2 = ds.Tables(0).Rows(i).Item("sohoso").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        ws.Range("b4").Value2 = ds.Tables(0).Rows(i).Item("namdangkyhoso").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        ws.Range("b5").Value2 = ds.Tables(0).Rows(i).Item("chucnangcuachungtu").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("nguoiguihang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                    Catch ex As Exception

                    End Try

                    'ws.Range("b6").Value2 = ds.Tables(0).Rows(i).Item("tentau").ToString
                    Try
                        ws.Range("b7").Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ")
                    Catch ex As Exception

                    End Try
                    Try
                        ws.Range("b8").Value2 = ds.Tables(0).Rows(i).Item("notify1").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("notify2").ToString
                    Catch ex As Exception

                    End Try


                    Dim cangchuyentai() As String
                    Dim canggiaohang() As String
                    Dim cangxephang() As String
                    Dim cangdohang() As String
                    Try
                        cangchuyentai = ds.Tables(0).Rows(i).Item("cangchuyentai").ToString.Split("-")
                        ws.Range("b10").Value2 = cangchuyentai(0) ' code
                        ' ws.Range("b11").Value2 = cangchuyentai(1) 'ds.Tables(0).Rows(i).Item("nguoiguihang").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        canggiaohang = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString.Split("-")
                        ws.Range("b11").Value2 = canggiaohang(0)
                    Catch ex As Exception

                    End Try

                    Try
                        cangxephang = ds.Tables(0).Rows(i).Item("cangxephang").ToString.Split("-") '
                        ws.Range("b12").Value2 = cangxephang(0)

                    Catch ex As Exception

                    End Try
                    Try
                        cangdohang = ds.Tables(0).Rows(i).Item("cangdohang").ToString.Split("-") '

                        ws.Range("b13").Value2 = cangdohang(0)
                    Catch ex As Exception

                    End Try

                    Try
                        ws.Range("b14").Value2 = ds.Tables(0).Rows(i).Item("diadiemgiaohang").ToString '


                        ws.Range("b15").Value2 = ds.Tables(0).Rows(i).Item("loaihang").ToString '

                        ws.Range("b16").Value2 = ds.Tables(0).Rows(i).Item("sovandon").ToString '
                        hbl = ds.Tables(0).Rows(i).Item("sovandon").ToString
                        Try
                            ws.Range("b17").Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDon").ToString.Replace("-", "/") '

                        Catch ex As Exception

                        End Try
                        'ws.Range("b18").Value2 = ds.Tables(0).Rows(i).Item("sovandongoc").ToString '
                        Try
                            ws.Range("b18").Value2 = ds.Tables(0).Rows(i).Item("sovandongoc").ToString '

                        Catch ex As Exception

                        End Try
                        Try
                            ws.Range("b19").Value2 = ds.Tables(0).Rows(i).Item("ngayPhatHanhVanDongoc").ToString.Replace("-", "/") '

                        Catch ex As Exception

                        End Try
                        Try
                            ws.Range("b20").Value2 = ds.Tables(0).Rows(i).Item("ngaykhoihanh").ToString.Replace("-", "/") '

                        Catch ex As Exception

                        End Try
                        ws.Range("b21").Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
                        Try
                            Dim tlk() As String
                            tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
                            ws.Range("b22").Value2 = tlk(0)
                        Catch ex As Exception
                            ws.Range("b22").Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
                        End Try

                        ws.Range("b23").Value2 = ds.Tables(0).Rows(i).Item("ghichu").ToString '
                    Catch ex As Exception

                    End Try


                    'Dim cangden() As String
                    'Try
                    '    cangden = ds.Tables(0).Rows(i).Item("cangden").ToString.Split("-")
                    '    ws.Range("b8").Value2 = cangden(1)
                    'Catch ex As Exception

                    'End Try


                    'ws.Range("b9").Value2 = ds.Tables(0).Rows(i).Item("thoigianden").ToString
                    'ws.Range("b10").Value2 = ds.Tables(0).Rows(i).Item("hohieu").ToString




                    'ws.Range("b12").Value2 = ds.Tables(0).Rows(i).Item("nguoinhanhang").ToString

                    '  ws.Range("b9").Value2 = cangchuyentai(0' ten

                    'ws.Range("b11").Value2 = ds.Tables(0).Rows(i).Item("cangGiaohang").ToString ' hang xuat















                    'ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("salecode").ToString
                    'ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    'ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblcarrier").ToString
                    ' ten khach hang tu customer
                    ' truong hop cont khong theo luoi
                    'sqlContainer = " select * from inbound where inboundid='" & gEManifest & "'"
                    'dsContainer = ReadDataSet(sqlContainer)
                    sqlContainer = " select * from containerrepair where inboundid='" & gEManifest & "'"
                    dsContainer = ReadDataSet(sqlContainer)
                    If dsContainer.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dsContainer.Tables(0).Rows.Count - 1

                            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
                            ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ") '


                            ws.Range("c" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString
                            ws.Range("d" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString
                            ws.Range("e" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString
                            ws.Range("f" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString
                            tang += 1
                        Next

                    End If

                    ''If ds.Tables(0).Rows.Count > 0 Then
                    ''    For j = 1 To 46
                    ''        If ds.Tables(0).Rows(i).Item("containerno" + j.ToString).ToString <> "" Then
                    ''            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
                    ''            ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString '
                    ''        End If



                    ''        ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sokg" + j.ToString).ToString
                    ''        ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("sokhoi" + j.ToString).ToString
                    ''        ws.Range("e" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("containerno" + j.ToString).ToString
                    ''        ws.Range("f" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("seal" + j.ToString).ToString
                    ''        tang += 1
                    ''    Next

                    ''End If



                    ' stt += 1
                Next
            End If
            ' sum

            ' Dim path As String = ""
            'path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + hbl + "_" & Now.Second & ".xlsx")
            'If path = "" Then
            path = PromptEManifestSavePath(hbl)
            If path = "" Then
                Return
            End If
            'End If
            '------------------------------
            Dim format1 As String
            '  path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments+ "\" + hbl + "_" & Now.Second & ".xlsx"
            'If app.Version = "11.0" Then
            '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
            'ElseIf (app.Version = "12.0"Then
            '    format1 = Excel.XlFileFormat.xlExcel7 ';   
            'End If
            ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
            DisplayMessage(True, "File name : " & path & " saved.")
            '----------
            'Dim xlApp As New Excel.Application
            'Dim xlWorkBook As Excel.Workbook
            'Dim xlWorkSheet As Excel.Worksheet
            ''~~> Save As file
            'xlWorkBook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,, , , )

            ''~~> Close the file
            'xlWorkBook.Close()
            '--------------------------------------------------------

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub

    Private Const EManifestSaveFolderParmId As String = "frmEManifest.LastSaveFolder"

    Private Function GetEManifestSaveFolder() As String
        Dim defaultFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SMF"
        Try
            If objUserSetting IsNot Nothing Then
                Dim saved As String = CStr(objUserSetting.GetCParm(EManifestSaveFolderParmId, ""))
                If saved IsNot Nothing AndAlso saved.Trim().Length > 0 AndAlso IO.Directory.Exists(saved) Then
                    Return saved
                End If
            End If
        Catch
        End Try
        Return defaultFolder
    End Function

    Private Sub SaveEManifestSaveFolder(ByVal folder As String)
        Try
            If objUserSetting Is Nothing OrElse folder Is Nothing OrElse folder.Trim().Length = 0 Then
                Return
            End If
            objUserSetting.SetCParm(EManifestSaveFolderParmId, folder)
            objUserSetting.SaveParm()
        Catch
        End Try
    End Sub

    Private Function PromptEManifestSavePath(ByVal hblNo As String) As String
        Try
            Dim safeHbl As String = ""
            If hblNo IsNot Nothing Then
                safeHbl = hblNo.Replace("\", "").Replace("/", "")
            End If
            Dim fileName As String = "MNF_" & safeHbl & ".xlsx"
            Dim folder As String = GetEManifestSaveFolder()

            If Not IO.Directory.Exists(folder) Then
                Try
                    IO.Directory.CreateDirectory(folder)
                Catch
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                End Try
            End If

            Dim dlg As New SaveFileDialog()
            dlg.InitialDirectory = folder
            dlg.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            dlg.FileName = fileName
            dlg.OverwritePrompt = True

            If dlg.ShowDialog(Me) <> DialogResult.OK Then
                Return ""
            End If

            Dim selectedPath As String = dlg.FileName
            SaveEManifestSaveFolder(IO.Path.GetDirectoryName(selectedPath))
            Return selectedPath
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub WriteEManifestDate(ByVal ws As _Worksheet, ByVal col As String, ByVal row As Integer, ByVal raw As Object)
        Dim formatted As String = FormatEManifestDate(raw)
        If formatted = "" Then
            Return
        End If
        Dim rng As Range = ws.Range(col & row.ToString())
        ' Force text so Excel template date format (dd/MMM/yyyy) cannot show JAN/FEB/...
        rng.NumberFormat = "@"
        rng.Value2 = formatted
    End Sub

    Private Function FormatEManifestDate(ByVal raw As Object) As String
        Try
            If raw Is Nothing OrElse IsDBNull(raw) Then
                Return ""
            End If

            Dim d As Date
            If TypeOf raw Is Date Then
                Return CDate(raw).ToString("dd/MM/yyyy")
            End If

            Dim s As String = raw.ToString().Trim()
            If s = "" Then
                Return ""
            End If

            Dim months() As String = {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"}
            Dim normalized As String = s.ToUpperInvariant().Replace("-", "/")
            For idx As Integer = 0 To 11
                If normalized.IndexOf(months(idx), StringComparison.Ordinal) >= 0 Then
                    Dim mm As String = (idx + 1).ToString().PadLeft(2, "0"c)
                    normalized = normalized.Replace(months(idx), mm)
                    Exit For
                End If
            Next

            If Date.TryParseExact(normalized, New String() {"dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy"}, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, d) Then
                Return d.ToString("dd/MM/yyyy")
            End If
            If Date.TryParse(s, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AllowWhiteSpaces, d) Then
                Return d.ToString("dd/MM/yyyy")
            End If
            If Date.TryParse(s, d) Then
                Return d.ToString("dd/MM/yyyy")
            End If

            Return normalized
        Catch ex As Exception
            Try
                Return raw.ToString().Trim().ToUpperInvariant().Replace("-", "/").Replace("JAN", "01").Replace("FEB", "02").Replace("MAR", "03").Replace("APR", "04").Replace("MAY", "05").Replace("JUN", "06").Replace("JUL", "07").Replace("AUG", "08").Replace("SEP", "09").Replace("OCT", "10").Replace("NOV", "11").Replace("DEC", "12")
            Catch
                Return ""
            End Try
        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEManifest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
