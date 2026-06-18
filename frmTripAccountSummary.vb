Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmTripAccountSummaryOutbound

    Dim path As String
    Dim tempvessel() As String
    Private connstring As String
    Dim dsdata As New DataSet
    Dim dsdataOceanFreight As New DataSet
    Dim dsFee As New DataSet
    Dim dsBillNumber As New DataSet
    Dim ds As New DataSet
    Dim dsTHC_DHC, dsDHC As New DataSet
    'Dim collectColor As Integer = 7
    'Dim PrepaidColor As Integer = 5
    'Sub QueryCROSSTab()
    '    Dim sql As String
    '    sql = "TRANSFORM Freight_charge_ib.unitprice  "
    '    sql = sql + " SELECT  BillOfLadingIb.BLIB_ID as F0,POR AS F1,POL AS F2,POD AS F3,DEST AS F4,BLIB_NO AS F5 "
    '    sql = sql + " FROM  BillOfLadingIb inner join Freight_charge_ib on BillOfLadingIb.BLIB_ID=Freight_charge_ib.BLIB_Id "
    '    sql = sql + " Where  Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text & " "
    '    sql = sql + " PIVOT  Freight_charge_ib.items; "
    '    Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '    Conn.Open()
    '    Dim cmdSelect As New SqlClient.SqlCommand(sql, Conn)
    '    Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '    Dim ds As New DataSet
    '    Adapter.Fill(ds)
    '    Me.DataGridView1.DataSource = ds.Tables(0)

    'End Sub

    Sub QueryContainer(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Container_type,Count(container_Type) as SoLuong from Cargo"
            strSQL &= " where cargo.BL_ID='" & BillId.Trim & "' And Cargo.Continued=1 Group by Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableContainer").Rows.Count > 0 Then
                ds.Tables("oTableContainer").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableContainer"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryLHC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(Amount * Quantity*exchange),Prepaid_Collect, payable_at_id "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code like 'LHC'  AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By Prepaid_Collect, payable_at_id " 'Or Charge_Code Like '%THC%'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryDHC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(Amount * Quantity*exchange),Prepaid_Collect, payable_at_id "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code like 'DHC'  and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By Prepaid_Collect, payable_at_id " 'Or Charge_Code Like '%THC%'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsDHC) Then
                dsDHC.Clear()
            End If
            AdapterFee.Fill(dsDHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryDHC_THCHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(Amount * Quantity*tigia) "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (Charge_Code like '%LHC%' Or Charge_Code Like '%DHC%') and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) " 'Or Charge_Code Like '%THC%'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub SetExcelValue()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\TripAccountSummaryDHC.xls"

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
            Dim DongHienTai As Integer = 10
            Dim BillId As String
            Dim n As Integer = dsdata.Tables(0).Rows.Count
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            For i As Integer = 0 To n - 1
                'If i = 8 Then
                '    MsgBox(" ")
                'End If

                BillId = dsdata.Tables(0).Rows(i).Item("F0").ToString.Trim

                BillNo = dsdata.Tables(0).Rows(i).Item("F1").ToString.Trim
                If BillNo = "HOWTN4AT613" Then
                    DisplayMessage(True, "")
                End If

                market = QueryMarket(BillId)
                If BillNo Like "*SGNLTK*" Then
                    QueryPriceSYRIA(BillId)
                Else
                    If UCase(market) Like "EUR" Then 'Or UCase(market) Like "MED" Then
                        QueryPriceEUR(BillId)
                    ElseIf UCase(market) Like "MID" Then
                        QueryPriceEUR(BillId)
                    ElseIf UCase(market) Like "AUS" Then
                        QueryPriceAUS(BillId)
                    ElseIf UCase(market) Like "SEA" Then
                        QueryPriceSEA(BillId)
                    ElseIf UCase(market) Like "MED" Then
                        QueryPriceMED(BillId)
                    ElseIf UCase(market) Like "IND" Then
                        QueryPriceIND(BillId)
                    ElseIf UCase(market) Like "CHI" Then
                        QueryPriceCHI(BillId)
                    ElseIf UCase(market) Like "HKG" Then
                        QueryPriceHKG(BillId)
                    ElseIf UCase(market) Like "SCA" Then
                        QueryPriceSCA(BillId)
                    ElseIf UCase(market) Like "AFR" Then
                        QueryPriceAFR(BillId)
                    ElseIf UCase(market) Like "WUS" Then
                        QueryPriceUSA(BillId)
                    ElseIf UCase(market) Like "EUS" Then
                        QueryPriceUSA(BillId)
                    ElseIf UCase(market) Like "CAN" Then
                        QueryPriceCAN(BillId)
                    End If
                End If
                'ws.Range("G" & 11 + i).Value2 = Me.txtCommission.Text
                Dim tam As String
                For P As Integer = 0 To dsFee.Tables(0).Rows.Count - 1

                    If dsFee.Tables(0).Rows(P).Item("Fee").ToString.Trim.Length > 0 Then
                        If UCase(dsFee.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And dsFee.Tables(0).Rows(P).Item("port_code").ToString.Trim Like "VNSGN" Then
                            ws.Range("I" & DongHienTai).Value2 = dsFee.Tables(0).Rows(P).Item("Fee").ToString
                            ws.Range("J" & DongHienTai).Value = 0
                        Else
                            ' kiem tra loai tru cac phu phi khong dua vao bao cao
                            'tam = ws.Range("I" & DongHienTai).Value2
                            'If tam = "" Or tam Is Nothing Then
                            ws.Range("J" & DongHienTai).Value2 = dsFee.Tables(0).Rows(P).Item("Fee").ToString
                            ws.Range("I" & DongHienTai).Value = 0
                            'End If


                        End If
                    End If

                Next
                ' xoa phi doi lap
                If ws.Range("I" & DongHienTai).Value <> 0 Then
                    ws.Range("J" & DongHienTai).Value2 = 0

                End If


                For k As Integer = 0 To 2
                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        ws.Range(Alpha(k) & DongHienTai).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                    End If
                Next
                ws.Range("T" & DongHienTai).Value2 = dsdata.Tables(0).Rows(i).Item("servicecontract").ToString
                QueryContainer(BillId)
                Dim CurType As String = " "
                For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                    Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                    'If Type = "20GP" Then
                    '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40GP" Then
                    '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "20RF" Then
                    '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40RF" Then
                    '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40HC" Then
                    '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40RH" Then
                    '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'Else
                    '    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'End If 
                    If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                        CurType &= "," & Strings.Right(Type, 2)
                    End If
                    CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                    ws.Range("F" & DongHienTai).Value2 = CurType
                    If Strings.Left(Type, 2) = "20" Then
                        ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    Else
                        ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    End If

                Next

                For P As Integer = 0 To dsdataOceanFreight.Tables(0).Rows.Count - 1
                    If dsdata.Tables(0).Rows(i).Item("F0").ToString = dsdataOceanFreight.Tables(0).Rows(P).Item("F0").ToString Then
                        If UCase(dsdataOceanFreight.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString) = "PREPAID" And dsdataOceanFreight.Tables(0).Rows(P).Item("port_code").ToString.Trim Like "VN*" Then
                            ws.Range("G" & DongHienTai).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                        Else
                            ws.Range("H" & DongHienTai).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                        End If
                    End If
                Next
                Dim Temp As String = Strings.Replace(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim(), "%", "")
                ws.Range("O" & DongHienTai).Value2 = Temp & "%"
                ws.Range("P" & DongCongThuc).Copy(ws.Range("P" & DongHienTai))  '"=(K" & DongHienTai & "+ L" & DongHienTai & ")* Q" & DongHienTai
                If UCase(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim) = "A" Then
                    ws.Range("O" & DongHienTai).Value2 = ""
                    ws.Range("P" & DongHienTai).Value2 = "=(D" & DongHienTai & " + E" & DongHienTai & ")*15 "
                End If

                QueryLHC(BillId)
                If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1

                        If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "PREPAID" And getPortCodeFromPortID(dsTHC_DHC.Tables(0).Rows(j).Item("payable_at_id").ToString, BillId) = True Then
                            ws.Range("K" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                        Else
                            ws.Range("L" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                            'ws.Range("K" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString
                        End If
                        ws.Range("M" & DongCongThuc).Copy(ws.Range("M" & DongHienTai))
                    Next
                End If
                QueryDHC(BillId) ' in ra cot N---------------------------------------------
                If dsDHC.Tables(0).Rows.Count > 0 Then
                    ws.Range("N" & DongHienTai).Value2 = dsDHC.Tables(0).Rows(0).Item("Fee").ToString
                End If


                '-------------
                Temp = Strings.Replace(dsdata.Tables(0).Rows(i).Item("Tax").ToString.Trim(), "%", "")
                ws.Range("Q" & DongHienTai).Value2 = Temp & "%"
                ws.Range("R" & DongCongThuc).Copy(ws.Range("R" & DongHienTai)) '"=Sum(K" & DongHienTai & ":N" & DongHienTai & ")* S" & DongHienTai
                'Net
                'ws.Range("AA" & DongHienTai).Value2 = "=if(Count(O" & DongHienTai & ">=1,O" & DongHienTai & " +Q" & DongHienTai & "+R" & DongHienTai & "-W" & DongHienTai & "-Z" & DongHienTai & ",-W" & DongHienTai & "-Z" & DongHienTai & ") + T" & DongHienTai & "-U" & DongHienTai

                ws.Range("S" & DongCongThuc).Copy(ws.Range("S" & DongHienTai))  '"=if(Count(K" & DongHienTai & ")>=1,K" & DongHienTai & " +M" & DongHienTai & "+N" & DongHienTai & "-R" & DongHienTai & "-T" & DongHienTai & ",-R" & DongHienTai & "-T" & DongHienTai & ")+O" & DongHienTai & " -P" & DongHienTai
                'dem += 1
                DongHienTai += 1
            Next

            ws.Range("K3").Value2 = Me.cboThang.Text & " / " & Me.cboNam.Text
            'Me.DataGridView1.DataSource = dsdata.Tables(0)
            ws.Range("k2").Value2 = tempvessel(0) & " " & tempvessel(1)
            ' hien thi phi DHC if la prepaid


            'ws.Range("G6").Value2 = CDate(tempvessel(2)).Date

            path = "c:\TripAccountSummary" & strUserId & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueHistory()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\TripAccountSummary.xls"

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
            Dim DongHienTai As Integer = 10
            Dim BillId As String
            Dim n As Integer = dsdata.Tables(0).Rows.Count
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            Dim market As String = ""
            For i As Integer = 0 To n - 1
                'If i = 8 Then
                '    MsgBox(" ")
                'End If

                BillId = dsdata.Tables(0).Rows(i).Item("F0").ToString.Trim

                BillNo = dsdata.Tables(0).Rows(i).Item("F1").ToString.Trim
                market = QueryMarket(BillId)
                If UCase(market) Like "EUR" Or UCase(market) Like "MED" Then
                    QueryPriceEURHistory(BillId)
                ElseIf UCase(market) Like "AUS" Then
                    QueryPriceAUSHistory(BillId)
                ElseIf UCase(market) Like "SEA" Then
                    QueryPriceSEAHistory(BillId)
                Else
                    QueryPriceHistory(BillId)
                End If
                'ws.Range("G" & 11 + i).Value2 = Me.txtCommission.Text

                For P As Integer = 0 To dsFee.Tables(0).Rows.Count - 1

                    If dsFee.Tables(0).Rows(P).Item("Fee").ToString.Trim.Length > 0 Then
                        If UCase(dsFee.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                            ws.Range("I" & DongHienTai).Value2 = dsFee.Tables(0).Rows(P).Item("Fee").ToString
                        Else
                            ' kiem tra loai tru cac phu phi khong dua vao bao cao
                            ws.Range("J" & DongHienTai).Value2 = dsFee.Tables(0).Rows(P).Item("Fee").ToString

                        End If
                    End If

                Next



                For k As Integer = 0 To 2
                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        ws.Range(Alpha(k) & DongHienTai).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                    End If
                Next
                ws.Range("R" & DongHienTai).Value2 = dsdata.Tables(0).Rows(i).Item("servicecontract").ToString
                QueryContainer(BillId)
                Dim CurType As String = " "
                For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                    Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                    'If Type = "20GP" Then
                    '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40GP" Then
                    '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "20RF" Then
                    '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40RF" Then
                    '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40HC" Then
                    '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40RH" Then
                    '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'Else
                    '    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'End If 
                    If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                        CurType &= "," & Strings.Right(Type, 2)
                    End If
                    CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                    ws.Range("F" & DongHienTai).Value2 = CurType
                    If Strings.Left(Type, 2) = "20" Then
                        ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    Else
                        ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    End If

                Next

                For P As Integer = 0 To dsdataOceanFreight.Tables(0).Rows.Count - 1
                    If dsdata.Tables(0).Rows(i).Item("F0").ToString = dsdataOceanFreight.Tables(0).Rows(P).Item("F0").ToString Then
                        If UCase(dsdataOceanFreight.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                            ws.Range("G" & DongHienTai).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                        Else
                            ws.Range("H" & DongHienTai).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                        End If
                    End If
                Next
                Dim Temp As String = Strings.Replace(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim(), "%", "")
                ws.Range("M" & DongHienTai).Value2 = Temp & "%"
                ws.Range("N" & DongCongThuc).Copy(ws.Range("N" & DongHienTai))  '"=(K" & DongHienTai & "+ L" & DongHienTai & ")* Q" & DongHienTai
                If UCase(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim) = "A" Then
                    ws.Range("M" & DongHienTai).Value2 = ""
                    ws.Range("N" & DongHienTai).Value2 = "15" '"=(D" & DongHienTai & " + E" & DongHienTai & ")*15 "
                End If

                QueryDHC_THCHistory(BillId)
                If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    'For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                    'If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                    'ws.Range("O" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                    '' Else
                    'ws.Range("P" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                    ws.Range("K" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString
                    ws.Range("L" & DongCongThuc).Copy(ws.Range("L" & DongHienTai))
                    ' End If
                    ' Next
                End If
                Temp = Strings.Replace(dsdata.Tables(0).Rows(i).Item("Tax").ToString.Trim(), "%", "")
                ws.Range("O" & DongHienTai).Value2 = Temp & "%"
                ws.Range("P" & DongCongThuc).Copy(ws.Range("P" & DongHienTai)) '"=Sum(K" & DongHienTai & ":N" & DongHienTai & ")* S" & DongHienTai
                'Net
                'ws.Range("AA" & DongHienTai).Value2 = "=if(Count(O" & DongHienTai & ">=1,O" & DongHienTai & " +Q" & DongHienTai & "+R" & DongHienTai & "-W" & DongHienTai & "-Z" & DongHienTai & ",-W" & DongHienTai & "-Z" & DongHienTai & ") + T" & DongHienTai & "-U" & DongHienTai

                ws.Range("Q" & DongCongThuc).Copy(ws.Range("Q" & DongHienTai))  '"=if(Count(K" & DongHienTai & ")>=1,K" & DongHienTai & " +M" & DongHienTai & "+N" & DongHienTai & "-R" & DongHienTai & "-T" & DongHienTai & ",-R" & DongHienTai & "-T" & DongHienTai & ")+O" & DongHienTai & " -P" & DongHienTai
                'dem += 1
                DongHienTai += 1
            Next

            ws.Range("K3").Value2 = Me.cboThang.Text & " / " & Me.cboNam.Text
            'Me.DataGridView1.DataSource = dsdata.Tables(0)
            ws.Range("k2").Value2 = tempvessel(0) & " " & tempvessel(1)

            'ws.Range("G6").Value2 = CDate(tempvessel(2)).Date

            path = "c:\TripAccountSummary" & strUserId & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    '    Sub InsertExcel()
    '        connstring = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    '"Data Source=" & path & ";Extended Properties=""Excel 8.0;HDR=NO;"""
    '        Dim pram As OleDbParameter
    '        Dim dr As DataRow
    '        Dim olecon As OleDbConnection
    '        Dim olecomm As OleDbCommand
    '        Dim olecomm1 As OleDbCommand
    '        Dim oleadpt As OleDbDataAdapter
    '        Dim ds As DataSet
    '        Try
    '            olecon = New OleDbConnection
    '            olecon.ConnectionString = connstring
    '            olecomm = New OleDbCommand
    '            olecomm.CommandText = "Select F1, F2, F3, F4,F5,F6,F7, F8, F9, F10,F11,F12, F13, F14, F15, F16,F17,F18,F19, F20, F21, F22,F23,F24,F25,F26 from [Sheet1$]"
    '            olecomm.Connection = olecon
    '            olecomm1 = New OleDbCommand
    '            olecomm1.CommandText = "Insert into [Sheet1$] " & _
    '            "(F1, F2, F3, F4,F5,F6,F7, F8, F9, F10,F11,F12, F13, F14, F15, F16,F17,F18,F19, F20, F21, F22,F23,F24,F25,F26)" & _
    '            " values (@F1, @F2, @F3, @F4,@F5,@F6,@F7, @F8, @F9, @F10,@F11,@F12, @F13, @F14, @F15, @F16,@F17,@F18,@F19, @F20, @F21, @F22,@F23,@F24,@F25,@F26)"
    '            olecomm1.Connection = olecon
    '            pram = olecomm1.Parameters.Add("@F1", OleDbType.VarChar)
    '            pram.SourceColumn = "F1"
    '            pram = olecomm1.Parameters.Add("@F2", OleDbType.VarChar)
    '            pram.SourceColumn = "F2"
    '            pram = olecomm1.Parameters.Add("@F3", OleDbType.VarChar)
    '            pram.SourceColumn = "F3"
    '            pram = olecomm1.Parameters.Add("@F4", OleDbType.VarChar)
    '            pram.SourceColumn = "F4"
    '            pram = olecomm1.Parameters.Add("@F5", OleDbType.VarChar)
    '            pram.SourceColumn = "F5"
    '            pram = olecomm1.Parameters.Add("@F6", OleDbType.VarChar)
    '            pram.SourceColumn = "F6"

    '            For i As Integer = 7 To 26
    '                pram = olecomm1.Parameters.Add("@F" & i, OleDbType.UnsignedInt)
    '                pram.SourceColumn = "F" & i
    '            Next
    '            oleadpt = New OleDbDataAdapter(olecomm)
    '            ds = New DataSet
    '            olecon.Open()
    '            oleadpt.Fill(ds, "Sheet1")
    '            If IsNothing(ds) = False Then
    '                For k As Integer = 0 To dsdata.Tables(0).Rows.Count - 1
    '                    dr = ds.Tables(0).NewRow
    '                    For j As Integer = 1 To 26
    '                        If j <> 7 Then
    '                            dr.Item("F" & j) = dsdata.Tables(0).Rows(k).Item("F" & j)
    '                        End If
    '                    Next
    '                    ds.Tables(0).Rows.Add(dr)
    '                Next
    '                'Me.DataGridView1.DataSource = ds.Tables(0)
    '                oleadpt = New OleDbDataAdapter
    '                oleadpt.InsertCommand = olecomm1
    '                Dim i As Integer = oleadpt.Update(ds, "Sheet1")
    '                MessageBox.Show(i & " row affected")
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        Finally
    '            olecon.Close()
    '            olecon = Nothing
    '            olecomm = Nothing
    '            oleadpt = Nothing
    '            ds = Nothing
    '            dr = Nothing
    '            pram = Nothing
    '        End Try
    '    End Sub

    Sub QueryPrice(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB' And Charge_Code <> 'LHC'  And Charge_Code<>'SSP' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*tigia),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB' And Charge_Code<>'LHC' And Charge_Code <> 'DHC'  And Charge_Code<>'SSP' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceEUR(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' "

            'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or  Charge_Code='STS' or Charge_Code='TMF' or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "EUR", "EUR", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceSYRIA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or  Charge_Code='SSP' or Charge_Code='WRS' or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SYRIA", "SYRIA", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceCAN(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND Charge_Code<>'DHC' AND Charge_Code <> 'LHC' AND Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "CAN", "CAN", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceMED(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 AND (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or Charge_Code='STS' or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "MED", "MED", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceUSA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 AND Charge_Code<>'DHC' AND Charge_Code<>'LHC' AND Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "USA", "USA", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceAFR(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND (Charge_Code='OWS' or Charge_Code='PCS' or Charge_Code='DIB' ) and  CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'

            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "AFR", "AFR", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceSCA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND (Charge_Code='OWS' or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SCA", "SCA", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceEURHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*tigia),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency ) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB'   And Charge_Code<>'DHC' And Charge_Code<>'SSP'  AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceEURTigia(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity),port_code "
            strQuery &= " From (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join port on Freight_Charge_Master.payable_at_id=port.port_id"
            strQuery &= " Where  BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB' And Charge_Code<>'LHC'  And Charge_Code<>'DHC' And Charge_Code<>'SSP' Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceCHI(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF'  or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "CHI", "CHI", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceHKG(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS'or  Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "HKG", "HKG", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceSEA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            '' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SEA", "SEA", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceIND(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And( Charge_Code='OWS' or  Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "IND", "IND", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceSEAHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*tigia ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB' And Charge_Code<>'LHC'  And Charge_Code<>'DHC'  And Charge_Code<>'SSP' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceSEATigia(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity),port_code"
            strQuery &= " From (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB' And Charge_Code<>'LHC'  And Charge_Code<>'SSP' And Charge_Code<>'DHC' Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceAUS(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code = 'BAF'  or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            'And Charge_Code<>'LHC'  And Charge_Code<>'DHC'And Charge_Code<>'SSP' And Charge_Code<>'PSC' And Charge_Code<>'LLO'  
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "AUS", "AUS", "C")
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceAUSHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*tigia), port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' And FREIGHT_CHARGE_Master.Continued=1 And Charge_Code <> 'DCB' And Charge_Code<>'OCB'   And Charge_Code<>'DHC'And Charge_Code<>'SSP' And Charge_Code<>'PSC' And Charge_Code<>'LLO'  AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Function QueryMarket(ByVal billID As String) As String
        Try
            Dim strQuery As String
            Dim ds As New DataSet
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select marketcode "
            strQuery &= " From (BillOfLading inner join containeroutboundnotify on BillOfLading.containeroutboundnotifyid=containeroutboundnotify.containeroutboundnotifyid) inner join market on containeroutboundnotify.market_id=market.market_id "
            strQuery &= " Where BL_ID='" & billID & "' and billoflading.continued=1 "
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'If dsBillNumber.Tables(0).Rows.Count > 0 Then
            '    dsBillNumber.Tables(0).Rows.Clear()
            'End If
            Adapter.Fill(ds, "Market")
            Return ds.Tables(0).Rows(0).Item("marketcode").ToString.Trim

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function
    Sub QueryBill()
        Try
            Dim strQuery As String

            strQuery = "Select distinct BillOfLading.BL_ID as F0,BL_NO AS F1,PORT_OF_LOADING_CODE AS F2,PORT_OF_DISCHARGE_CODE AS F3,billoflading.servicecontract,Commission,BillOfLading.TAX "
            strQuery &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strQuery &= " Where SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And BillOfLading.Continued=1 order by billoflading.bl_no "
            'strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyNo='" & tempvessel(1) & "' And BillOfLading.Continued=1 And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text & " Order by BL_NO "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If dsdata.Tables(0).Rows.Count > 0 Then
                dsdata.Tables(0).Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables(0))
            strQuery = "Select FREIGHT_CHARGE_Master.BL_ID as F0,OceanFreight=sum(Amount*Quantity*exchange) ,PREPAID_COLLECT,port_code "
            strQuery &= " from (((((BillOfLading LEFT JOIN FREIGHT_CHARGE_Master on FREIGHT_CHARGE_Master.BL_ID=BillOfLading.BL_ID) "
            strQuery &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN CHARGE On Charge.Charge_Id=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency)   inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " where (CHARGE.Charge_Code like'%OCB%' Or Charge_Code Like '%DCB%') And FREIGHT_CHARGE_Master.Continued=1 And SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY) " 'And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text
            strQuery &= " Group By FREIGHT_CHARGE_Master.BL_ID, PREPAID_COLLECT,port_code "
            Dim cmdSelectOceanFreight As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterOceanFreight As New SqlClient.SqlDataAdapter(cmdSelectOceanFreight)
            If dsdataOceanFreight.Tables(0).Rows.Count > 0 Then
                dsdataOceanFreight.Tables(0).Rows.Clear()
            End If
            AdapterOceanFreight.Fill(dsdataOceanFreight.Tables(0))

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryBillHistory()
        Try
            Dim strQuery As String

            strQuery = "Select distinct BillOfLading.BL_ID as F0,BL_NO AS F1,PORT_OF_LOADING_CODE AS F2,PORT_OF_DISCHARGE_CODE AS F3,Commission,BillOfLading.TAX "
            strQuery &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strQuery &= " Where SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And BillOfLading.Continued=1 order by billoflading.bl_no "
            'strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyNo='" & tempvessel(1) & "' And BillOfLading.Continued=1 And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text & " Order by BL_NO "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If dsdata.Tables(0).Rows.Count > 0 Then
                dsdata.Tables(0).Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables(0))
            strQuery = "Select FREIGHT_CHARGE_Master.BL_ID as F0,OceanFreight=sum(Amount*Quantity*tigia) ,PREPAID_COLLECT,port_code "
            strQuery &= " from (((((BillOfLading LEFT JOIN FREIGHT_CHARGE_Master on FREIGHT_CHARGE_Master.BL_ID=BillOfLading.BL_ID) "
            strQuery &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN CHARGE On Charge.Charge_Id=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " where (CHARGE.Charge_Code like'%OCB%' Or Charge_Code Like '%DCB%') and FREIGHT_CHARGE_Master.Continued=1 And SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY) " 'And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text
            strQuery &= " Group By FREIGHT_CHARGE_Master.BL_ID, PREPAID_COLLECT,port_code "
            Dim cmdSelectOceanFreight As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterOceanFreight As New SqlClient.SqlDataAdapter(cmdSelectOceanFreight)
            If dsdataOceanFreight.Tables(0).Rows.Count > 0 Then
                dsdataOceanFreight.Tables(0).Rows.Clear()
            End If
            AdapterOceanFreight.Fill(dsdataOceanFreight.Tables(0))

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct SailingSchedule.SailingScheduleID as Id, Vessel +' - '+ VoyNo + ' - ' + convert(nvarchar,ETD)  as data "
            SQL &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            SQL &= " where BillOfLading.Continued=1 And day(ETD)=" & Me.cboday.Text & " And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            'ds.Tables.Add()
            'If ds.Tables(0).Rows.Count > 0 Then
            '    ds.Tables(0).Rows.Clear()
            'End If
            Adapter.Fill(ds)
            Me.cboVessel.Text = ""
            Me.cboVessel.DataSource = ds.Tables(0)
            Me.cboVessel.DisplayMember = "data"
            Me.cboVessel.ValueMember = "ID"
            'Me.cboVessel.Items.Clear()
            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            'Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            ' Next
        Catch ex As Exception

        End Try
    End Sub

    'Sub QueryETA()
    '    Try
    '        Dim SQL As String = "Select ETA from BillOfLading where BLIB_ID='" & gBillInboundID & "' And Continued=1 And Vessel=" & Me.cboVessel.Text.Trim & "Voyage=" & Me.cboSoChuyen.Text.Trim
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        Dim ds As New DataSet
    '        Adapter.Fill(ds)

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub frmTripAccountOutbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboNam.Text = Now.Year
            Me.cboThang.Text = Now.Month
            dsFee.Clear()
            dsdata.Clear()
            dsdataOceanFreight.Clear()
            ds.Tables.Clear()
            ds.Tables.Add("oTableContainer")
            dsFee.Tables.Add()
            dsdata.Tables.Add()
            dsdataOceanFreight.Tables.Add()
            For i As Integer = 2000 To 2050
                Me.cboNam.Items.Add(i)
            Next

            'QueryBill()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cboThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboThang.SelectedIndexChanged, cboday.SelectedIndexChanged
        Me.cboVessel.Text = ""
        QueryVessel()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            tempvessel = Strings.Split(Me.cboVessel.Text, " - ")
            If Me.RadioEPre.Checked = True Then
                QueryBill()
                SetExcelValue()
            Else
                QueryBillHistory()
                SetExcelValueHistory()
            End If

        Catch ex As Exception

        End Try

        'InsertExcel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub


    Private Sub cboNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNam.SelectedIndexChanged

        QueryVessel()
    End Sub


End Class