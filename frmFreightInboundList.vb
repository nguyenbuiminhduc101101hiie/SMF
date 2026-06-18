'Imports Excel
Public Class frmFreightInboundList
    Dim ds As New DataSet
    Dim Path As String
    Dim dsTHC_DHC As New DataSet
    Dim Vessel, VoyNo As String
    Dim ETA As Date
    Dim dem As Integer = 0

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data "
            SQL &= "from BillOfLadingIB where Continued=1 And ETA >='" & Me.dtpFromETA.Value.Date & "' And ETA<='" & Me.dtpToETA.Value.Date & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            If Not IsNothing(ds) Then
                ds.Clear()
            End If
            Adapter.Fill(ds)
            Me.cboVessel.Items.Clear()
            Me.cboVessel.Text = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryInfo(ByVal Vessel As String, ByVal Voyno As String, ByVal ETA As Date)
        Try
            Dim strSQL As String
            strSQL = "Select BLIB_ID,BLIB_NO,Vessel + ' - ' + Voyage As F1,ETA as F2,BLIB_NO as F3,POL as F4,POD as F5"
            strSQL &= " from BillOfLadingIB Where Vessel='" & Vessel.Trim & "' And Voyage='" & Voyno.Trim & "' And ETA='" & ETA & "' And Continued=1  and transit=0 order by STT " 'or BLIB_NO LIKE '?PNHHCM%' or BLIB_NO LIKE '?PNHNPT%'
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBill").Rows.Count > 0 Then
                ds.Tables("oTableBill").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBill"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryContainer(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Container_type,Count(container_Type) as SoLuong from CargoIB"
            strSQL &= " where cargoib.BLIB_ID='" & BillId.Trim & "' Group by Container_type"
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

    Sub QueryPrice(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select PREPAID_COLLECT,Sum(UnitPrice*Quantity)as Fee from FREIGHT_CHARGE_IB "
            strSQL &= " where BLIB_ID='" & BillId.Trim & "' And Items <>'OCB' And CURRENCY='USD' and Items<>'THC' And Items<>'DHC' GROUP BY PREPAID_COLLECT"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFee").Rows.Count > 0 Then
                ds.Tables("oTableFee").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFee"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryFreight(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BLIB_ID,PREPAID_COLLECT,Sum(UnitPrice*Quantity) as OceanFreight from FREIGHT_CHARGE_IB "
            strSQL &= " where BLIB_ID='" & BillId.Trim & "' And (Items ='OCB' Or Items='ODB') And CURRENCY='USD' Group by BLIB_ID,PREPAID_COLLECT"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreight").Rows.Count > 0 Then
                ds.Tables("oTableFreight").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreight"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

#Region "31-10-2007"
    'Coi có bao nhiêu loại tiền tệ khác nhau
    Function QueryBillCurrency(ByVal BLNO As String) As Boolean
        Dim Temp As Boolean = False
        Try
            Dim SQL As String
            SQL = "select Distinct Currency From PriceBillIB Where BLIB_NO='" & BLNO & "' and PREPAID_COLLECT ='COLLECT' And continued=1"
            Dim ds As New DataSet
            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count <= 1 Then 'nếu có 0 hoặc 1 loại 
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryConCurrency(ByVal BLID As String) As Boolean
        Dim Temp As Boolean = False
        Try
            Dim SQL As String
            SQL = "select Distinct Currency From FREIGHT_CHARGE_IB Where BLIB_ID='" & BLID & "' and PREPAID_COLLECT ='COLLECT' And continued=1"
            Dim ds As New DataSet
            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count <= 1 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub QueryBillFeeOCB(ByVal BillNO As String)
        Try
            Dim strSQL As String
            strSQL = "Select BLIB_ID,PREPAID_COLLECT,Sum(UnitPrice*Quantity) as OceanFreight  "
            strSQL &= " From (PriceBillIB INNER JOIN BillOfLadingIB On PriceBillIB.BLIB_NO=BillOfLadingIB.BLIB_NO)"
            strSQL &= " where PriceBillIB.BLIB_No='" & BillNO.Trim & "' And (Items ='OCB' Or Items='ODB') And CURRENCY='USD' Group by BLIB_ID,PREPAID_COLLECT"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBillFeeOCB").Rows.Count > 0 Then
                ds.Tables("oTableBillFeeOCB").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBillFeeOCB"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryBillFeeoTher(ByVal BillNO As String)
        Try

            Dim strSQL As String
            strSQL = "Select PREPAID_COLLECT,Sum(UnitPrice*Quantity)as Fee from PriceBillIB "
            strSQL &= " where BLIB_NO='" & BillNO.Trim & "' And Items <>'OCB' And CURRENCY='USD' and Items<>'THC' And Items<>'DHC' GROUP BY PREPAID_COLLECT"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBillFeeoTher").Rows.Count > 0 Then
                ds.Tables("oTableBillFeeoTher").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBillFeeoTher"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
#End Region

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            Dim tempds As New DataSet
            tempds.Tables.Add("Vessel")
            tempds.Tables(0).Columns.Add("Vessel")
            tempds.Tables(0).Columns.Add("Voyno")
            tempds.Tables(0).Columns.Add("ETA")
            Me.dgdVesselCollection.Rows.Add(1)
            Dim Countdgd As Integer = Me.dgdVesselCollection.RowCount - 1
            Dim row As DataRow
            row = tempds.Tables(0).NewRow
            Dim tempvessel() As String
            tempvessel = Strings.Split(Me.cboVessel.Text, " - ")
            row("Vessel") = IIf(tempvessel.Length > 0, tempvessel(0), "")
            row("VoyNo") = IIf(tempvessel.Length > 1, tempvessel(1), "")
            row("ETA") = IIf(tempvessel.Length > 2, CDate(tempvessel(2)), "")
            Me.dgdVesselCollection.Item("Vesselgid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(0), "")
            Me.dgdVesselCollection.Item("VoyNogid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(1), "")
            Me.dgdVesselCollection.Item("ETAgid", Countdgd).Value = IIf(tempvessel.Length > 0, CDate(tempvessel(2)), "")
            InsertAutoNumberToGrid(Me.dgdVesselCollection)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Function QueryRepeatContainer(ByVal Vessel As String, ByVal VoyNo As String) As String
        Try
            Dim Temp As String = ""
            Dim strSQL As String
            strSQL = "select Container_No,CargoIB.BLIB_ID,BLIB_NO "
            strSQL &= " From ((CargoIB INNER JOIN Container On CargoIB.CTN_ID=Container.CTN_ID)"
            strSQL &= " INNER JOIN BillOfLadingIB On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID)"
            strSQL &= " Where CargoIB.Continued=1 and BillOfLadingIB.Continued=1 "
            strSQL &= " And Vessel='" & Vessel.Trim & "' And VOYAGE='" & VoyNo.Trim & "'"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            For k As Integer = 0 To dt.Rows.Count - 1

                For l As Integer = k + 1 To dt.Rows.Count - 1
                    'nếu Bill Có Rồi Ko Xét Nữa
                    If Temp Like "*" & dt.Rows(k).Item("BLIB_NO").ToString.Trim & "*" Or Temp Like "*" & dt.Rows(l).Item("BLIB_NO").ToString.Trim & "*" Then
                        Continue For
                    End If
                    If dt.Rows(k).Item("Container_No").ToString.Trim = dt.Rows(l).Item("Container_No").ToString.Trim Then
                        If dt.Rows(k).Item("BLIB_NO").ToString.Trim <> dt.Rows(l).Item("BLIB_NO").ToString.Trim Then
                            Temp &= "-" & dt.Rows(k).Item("BLIB_NO").ToString.Trim & "-" & dt.Rows(l).Item("BLIB_NO").ToString.Trim & "-"
                        End If
                    End If
                Next
            Next
            Return Temp
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Function

    Private Sub frmFreightInboundList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            ds.Tables.Clear()
            ds.Tables.Add("oTableFreight")
            ds.Tables.Add("oTableBillFeeOCB")
            ds.Tables.Add("oTableBillFeeoTher")
            ds.Tables.Add("oTableFee")
            ds.Tables.Add("oTableContainer")
            ds.Tables.Add("oTableBill")
            QueryVessel()
            SetDefaultGrid(Me.dgdVesselCollection, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    Sub SetExcelValueCommission()
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = StartupPath & "\InbounCommission.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim Note As Integer = 0
            Dim PC As Boolean = False
            Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            Dim Temp As String = ""
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETA = Me.dgdVesselCollection.Item("ETAGID", CountVessel).Value
                Temp = QueryRepeatContainer(Vessel, VoyNo)

                QueryInfo(Vessel, VoyNo, ETA)
                Dim BillID As String = ""
                Dim BLIB_NO As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                
                For i As Integer = 0 To n - 1
                    Note = 0
                    BillID = ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim
                    BLIB_NO = ds.Tables("oTableBill").Rows(i).Item("BLIB_NO").ToString.Trim
                    If Temp Like "*-" & BLIB_NO.Trim & "-*" Then
                        For TempCell As Integer = Asc("A") To Asc("U")
                            ws.Range(Chr(TempCell) & DongHienTai).Cells.Font.ColorIndex = 3
                        Next
                    End If
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 2 To 4
                    If ds.Tables("oTableBill").Rows(i).Item("F3").ToString.Length > 0 Then
                        ws.Range("A" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F3").ToString
                    End If
                    'Next
                    'insert container
                    Dim CurType As String = " "
                    QueryContainer(BillID)
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                        'If Type = "20GP" Then
                        '    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        'If ds.Tables("oTableContainer").Rows.Count - 1 > 0 Then
                        '    MsgBox("")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)

                        If Strings.Left(Type, 2) = "20" Then
                            ws.Range("C" & DongHienTai).Value2 += ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            ws.Range("D" & DongHienTai).Value2 += ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        End If
                        ws.Range("E" & DongHienTai).Value2 = CurType
                    Next
                    'Insert Cac Loai Phi
                    QueryPrice(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If UCase(ds.Tables("oTableFee").Rows(P).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
                            If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                            End If
                        Else 'phí là prepaid
                            If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                            End If
                        End If
                    Next

                    'insert OnceaFreight
                    QueryFreight(BillID)

                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString = "COLLECT" Then
                            Note += 1
                            ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            Dim Congthuc As String
                            Congthuc = "=H" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            ws.Range("P" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                            'thêm công thức vào Freight To Owner
                            ws.Range("Q" & DongHienTai).Value2 = "=(J" & DongHienTai & "+ K" & DongHienTai & "+ L" & DongHienTai & "+M" & DongHienTai & "+ O" & DongHienTai & ")-(N" & DongHienTai & "+ P" & DongHienTai & "+ R" & DongHienTai & ")"
                        Else
                            Note += 1
                            ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                            Dim Congthuc As String
                            Congthuc = "=F" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            ws.Range("P" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                            'thêm công thức vào Freight To Owner
                            ws.Range("Q" & DongHienTai).Value2 = "=(J" & DongHienTai & "+ K" & DongHienTai & "+ L" & DongHienTai & "+M" & DongHienTai & "+ O" & DongHienTai & ")-(N" & DongHienTai & "+ P" & DongHienTai & "+ R" & DongHienTai & ")"
                            '=(N8+O8+P8+Q8+S8)-(R8+T8+V8)
                        End If
                    Next


                    'Thêm 31-10-2007
                    'queryCác loại phụ phí của Bill
                    QueryBillFeeoTher(BLIB_NO)
                    For p As Integer = 0 To ds.Tables("oTableBillFeeoTher").Rows.Count - 1
                        If UCase(ds.Tables("oTableBillFeeoTher").Rows(p).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                            If ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("J" & DongHienTai).Value2 += ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE") 'K
                            End If
                        Else
                            If ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("L" & DongHienTai).Value2 += ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE")
                            End If
                        End If
                    Next

                    'Query OCB Của Bill
                    QueryBillFeeOCB(BLIB_NO)
                    For F As Integer = 0 To ds.Tables("oTableBillFeeOCB").Rows.Count - 1
                        If ds.Tables("oTableBillFeeOCB").Rows(F).Item("PREPAID_COLLECT").ToString = "COLLECT" Then
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableBillFeeOCB").Rows(F).Item("OceanFreight") 'J
                        Else
                            ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableBillFeeOCB").Rows(F).Item("OceanFreight")
                        End If
                    Next

                    If QueryBillCurrency(BLIB_NO) Or QueryConCurrency(BillID) Then
                        For TempRow As Integer = Asc("A") To Asc("S")
                            ws.Range(Chr(TempRow) & DongHienTai).Cells.Font.ColorIndex = 3
                        Next
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    QueryDHC_THC(BillID)
                    If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                            If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
                                If dsTHC_DHC.Tables(0).Rows(j).Item("FEE").ToString.Trim.Length > 0 Then
                                    ws.Range("O" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("FEE")
                                    ws.Range("N" & DongHienTai).Formula = "=O" & DongHienTai & " *7.5/100"
                                End If
                            Else 'phí là prepaid đưa vào phụ phí prepaid
                                If dsTHC_DHC.Tables(0).Rows(j).Item("FEE").ToString.Trim.Length > 0 Then
                                    ws.Range("G" & DongHienTai).Value2 += dsTHC_DHC.Tables(0).Rows(0).Item("FEE")
                                    ws.Range("K" & DongHienTai).Value2 += dsTHC_DHC.Tables(0).Rows(0).Item("FEE")
                                End If
                            End If
                        Next
                    End If
                    If Note = 2 And PC = False Then
                        PC = True
                    End If

                    'ws.Range("Q" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee
                    'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETA
                    ws.Range("U" & DongHienTai).Formula = "=P" & DongHienTai & " + T" & DongHienTai
                    DongHienTai += 1
                    ws.Range("A8", "U" & DongHienTai).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    ws.Range("A8", "U" & DongHienTai).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
                   
                Next
                'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
                'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETA
                'Dim C As Integer
                'For C = 0 To 16
                '    'If Alpha(C + 2) <> "Q" Then
                '    Dim Sum As String
                '    Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                '    ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                '    ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                '    'End If
                'Next
                'ws.Range("A" & DongHienTai, Alpha(C + 4) & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
            Next
            ' ws.Range("A8", "U" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)
            Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
            ws.Range("A" & DongHienTai).Value2 = "TOTAL "
            ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            For ToTal = Asc("C") To Asc("U")
                If UCase(Chr(ToTal)) = "E" Then
                    Continue For
                End If
                Dim Sum As String
                Sum = "=sum(" & Chr(ToTal) & 9 & ":" & Chr(ToTal) & DongHienTai - 1 & ")"
                ws.Range(Chr(ToTal) & DongHienTai).Formula = Sum
                ws.Range(Chr(ToTal) & DongHienTai).Cells.Font.Bold = 1
                'End If
            Next

            Path = "c:\InboundCommission" & Vessel & "-" & VoyNo & CDate(ETA) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            If pc Then
                MsgBox("there is a bill have 2 O/F (Prepaid , Collect) Please check again")
            End If
            MsgBox("Complete")
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPrice * Quantity),Prepaid_Collect "
            strQuery &= " From Freight_Charge_IB "
            strQuery &= " Where BLIB_ID='" & billID & "' and Continued=1 And (Items like '%DHC%' Or Items Like '%THC%') Group By Prepaid_Collect" ' and  Prepaid_Collect='COLLECT'" 'lấy  cả prepaid Và collect Prepaid cho vào phụ phí
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
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = StartupPath & "\FreightList.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ' app.a()
            Dim GRANDTOTAL(20) As Double
            Dim note As Integer = 0
            Dim Pc As Boolean = False
            Dim CurType As String
            Dim DongHienTai As Integer = 8 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            Dim Temp As String = ""
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETA = Me.dgdVesselCollection.Item("ETAGID", CountVessel).Value
                Temp = QueryRepeatContainer(Vessel, VoyNo)

                QueryInfo(Vessel, VoyNo, ETA)
                Dim BillID As String = ""
                Dim BLIB_NO As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1
                    note = 0
                    BillID = ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim
                    BLIB_NO = ds.Tables("oTableBill").Rows(i).Item("BLIB_NO").ToString.Trim
                    If Temp Like "*-" & BLIB_NO.Trim & "-*" Then
                        For TempCell As Integer = Asc("A") To Asc("S")
                            ws.Range(Chr(TempCell) & DongHienTai).Cells.Font.ColorIndex = 3
                        Next
                    End If
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    For k As Integer = 2 To 4
                        If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                            ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                        End If
                    Next
                    'insert container
                    CurType = " "
                    QueryContainer(BillID)
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                        'If Type = "20GP" Then
                        '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)

                        If Strings.Left(Type, 2) = "20" Then
                            ws.Range("F" & DongHienTai).Value2 += ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            ws.Range("G" & DongHienTai).Value2 += ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        End If
                        ws.Range("H" & DongHienTai).Value2 = CurType
                    Next
                    'Insert Cac Loai Phi
                    QueryPrice(BillID)
                    For p As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If UCase(ds.Tables("oTableFee").Rows(p).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                            If ds.Tables("oTableFee").Rows(p).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(p).Item("FEE") 'K
                            End If
                        Else
                            If ds.Tables("oTableFee").Rows(p).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(p).Item("FEE")
                            End If
                        End If
                    Next

                    'insert OnceaFreight
                    QueryFreight(BillID)
                    'If ds.Tables("oTableFreight").Rows.Count > 0 Then
                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString = "COLLECT" Then
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight") 'J
                            note += 1
                            Dim Congthuc As String
                            Congthuc = "=(I" & DongHienTai & " + K" & DongHienTai & ")*" & Me.txtHandingFee.Text & "/100"
                            ws.Range("P" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                            'thêm công thức vào NET
                            ws.Range("S" & DongHienTai).Value2 = "=(K" & DongHienTai & "+ L" & DongHienTai & "+ N" & DongHienTai & ")-(M" & DongHienTai & "+ P" & DongHienTai & "+ R" & DongHienTai & ")" ' "=N" & DongHienTai & "+ P" & DongHienTai & "- T" & DongHienTai '& "- R" & DongHienTai ' J
                        Else
                            note += 1
                            ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            Dim Congthuc As String
                            Congthuc = "=(I" & DongHienTai & " + K" & DongHienTai & ")*" & Me.txtHandingFee.Text & "/100"
                            ws.Range("P" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 

                            ' thêm công thức vào NET =(N7+P7+R7)-(Q7+T7+V7)
                            ws.Range("S" & DongHienTai).Value2 = "=(K" & DongHienTai & "+ L" & DongHienTai & "+ N" & DongHienTai & ")-(M" & DongHienTai & "+ P" & DongHienTai & "+ R" & DongHienTai & ")" ' "=N" & DongHienTai & "+ P" & DongHienTai & "- T" & DongHienTai '& "- R" & DongHienTai
                        End If
                        If note = 2 And Pc = False Then
                            Pc = True
                        End If
                    Next

                    'Thêm 31-10-2007
                    'queryCác loại phụ phí của Bill
                    QueryBillFeeoTher(BLIB_NO)
                    For p As Integer = 0 To ds.Tables("oTableBillFeeoTher").Rows.Count - 1
                        If UCase(ds.Tables("oTableBillFeeoTher").Rows(p).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                            If ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("J" & DongHienTai).Value2 += ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE") 'K
                            End If
                        Else
                            If ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("L" & DongHienTai).Value2 += ds.Tables("oTableBillFeeoTher").Rows(p).Item("FEE")
                            End If
                        End If
                    Next

                    'Query OCB Của Bill
                    QueryBillFeeOCB(BLIB_NO)
                    For F As Integer = 0 To ds.Tables("oTableBillFeeOCB").Rows.Count - 1
                        If ds.Tables("oTableBillFeeOCB").Rows(F).Item("PREPAID_COLLECT").ToString = "COLLECT" Then
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableBillFeeOCB").Rows(F).Item("OceanFreight") 'J
                        Else
                            ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableBillFeeOCB").Rows(F).Item("OceanFreight")
                        End If
                    Next

                    If QueryBillCurrency(BLIB_NO) Or QueryConCurrency(BillID) Then 'nếu phí có hai loại tiền tệ thì tô đỏ dòng đó
                        For TempRow As Integer = Asc("A") To Asc("S")
                            ws.Range(Chr(TempRow) & DongHienTai).Cells.Font.ColorIndex = 3
                        Next
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    QueryDHC_THC(BillID)
                    If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                            If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
                                If dsTHC_DHC.Tables(0).Rows(j).Item("FEE").ToString.Trim.Length > 0 Then
                                    ws.Range("N" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("FEE")
                                    ws.Range("M" & DongHienTai).Formula = "=N" & DongHienTai & "*7.5/100"
                                End If
                            Else 'phí là prepaid thì đưa vào phụ phí prepaid
                                If dsTHC_DHC.Tables(0).Rows(j).Item("FEE").ToString.Trim.Length > 0 Then
                                    ws.Range("J" & DongHienTai).Value2 += dsTHC_DHC.Tables(0).Rows(0).Item("FEE")
                                End If
                            End If
                        Next
                    End If



                            ws.Range("O" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee
                            ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                            ws.Range("B" & DongHienTai).Value2 = ETA
                            DongHienTai += 1
                    ws.Range("A8", "S" & DongHienTai).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    ws.Range("A8", "S" & DongHienTai).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
                   
                        Next
                        'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
                        ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                        ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                        ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                        'ws.Range("B" & DongHienTai).Value2 = ETA
                        Dim C As Integer
                        Dim TempC As Integer = 0
                        For C = Asc("F") To Asc("S")
                            If Chr(C) <> "O" Then
                                Dim Sum As String
                                Sum = "=sum(" & Chr(C) & SoDong & ":" & Chr(C) & DongHienTai - 1 & ")"
                                ws.Range(Chr(C) & DongHienTai).Cells.Font.Bold = 1
                                ws.Range(Chr(C) & DongHienTai).Formula = Sum
                                GRANDTOTAL(TempC) += ws.Range(Chr(C) & DongHienTai).Value
                                TempC += 1
                            End If
                        Next
                ws.Range("A" & DongHienTai, "S" & DongHienTai).Cells.BorderAround(1, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
                
            Next
            If Pc Then
                MsgBox("there is a bill have 2 O/F (Prepaid , Collect) Please check again")
            End If
            ws.Range("A8", "S" & DongHienTai - 1).BorderAround(1, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, 5)
            Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            For ToTal = 0 To 17
                If Alpha(ToTal + 5) <> "O" Then 'khong cong commission
                    Dim Sum As String
                    Sum = "=sum(" & Alpha(ToTal + 5) & 8 & ":" & Alpha(ToTal + 5) & DongHienTai - 1 & ")"
                    ws.Range(Alpha(ToTal + 5) & DongHienTai).Value = GRANDTOTAL(ToTal)
                End If
            Next

            Path = "c:\FreightList" & Vessel & "-" & VoyNo & CDate(ETA) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            MsgBox("Complete")
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            If Me.dgdVesselCollection.RowCount <= 0 Then
                Return
            End If
            If Me.txtHandingFee.Text = "" Then
                MsgBox("You must insert Handing fee (%)")
                Exit Sub
            End If
            If Me.chkFreightList.Checked = True Then
                SetExcelValue()
            Else
                SetExcelValueCommission()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpFromETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpToETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgdVesselCollection_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdVesselCollection.CellContentClick
        InsertAutoNumberToGrid(Me.dgdVesselCollection)
    End Sub

    Private Sub dgdVesselCollection_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdVesselCollection.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdVesselCollection)
    End Sub

    Private Sub cmdAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAll.Click
        For i As Integer = 0 To Me.cboVessel.Items.Count - 1
            Me.cboVessel.SelectedIndex = i
            cmdAdd_Click(sender, e)
        Next
    End Sub
End Class