'Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmTripAccountInbound
    Public transit As Integer
    Dim path As String
    Dim tempvessel() As String
    Private connstring As String
    Dim dsdata As New DataSet
    Dim dsdataOceanFreight As New DataSet
    Dim dsFee As New DataSet
    Dim dsTHC_DHC As New DataSet
    Dim dsContainer As New DataSet
    Dim collectColor As Integer = 7
    Dim PrepaidColor As Integer = 5
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

    Sub QueryContainer20(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Container_type,Count(container_Type) as SoLuong from CargoIB"
            strSQL &= " where cargoIB.BLIB_ID='" & BillId.Trim & "' And CargoIB.Continued=1 And Container_Type Like '%20%' Group by Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If dsdata.Tables("oTableContainer").Rows.Count > 0 Then
                dsdata.Tables("oTableContainer").Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables("oTableContainer"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryContainer(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Container_type,Count(container_Type) as SoLuong from CargoIB"
            strSQL &= " where cargoIB.BLIB_ID='" & BillId.Trim & "' And CargoIB.Continued=1  Group by Container_type,CargoIB.STT"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If Not IsNothing(dsContainer) Then
                dsContainer.Tables.Clear()
            End If
            dsContainer.Tables.Add("oTableContainer")
            Adapter.Fill(dsContainer.Tables("oTableContainer"))
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

            path = StartupPath & "\TripAccountInbound.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim note As Integer = 0
            Dim pc As Boolean = False

            Dim n As Integer = dsdata.Tables(0).Rows.Count
            'Dim range As Object 'Range 

            Dim arr(n, 20) As Double
            Dim CurType As String = ""
            Dim arrS(n, 7) As String
            Dim OceanFreightarr(n) As Double
            Dim dem As Integer = 0
            Dim CurRow As Integer = 9
            Dim BLIB_No As String = ""
            Dim Temp As String = ""
            Temp = QueryRepeatContainer(tempvessel(0), tempvessel(1))
            For i As Integer = 0 To n - 1
                'If i = 8 Then
                '    MsgBox(" ")
                'End If
                note = 0
                'BillNo = dsdata.Tables(0).Rows(i).Item("F5").ToString.Trim

                QueryContainer(dsdata.Tables(0).Rows(i).Item("F0").ToString.Trim)
                BLIB_No = dsdata.Tables(0).Rows(i).Item("F1").ToString.Trim
                If BLIB_No Like "*0702" Then
                    'DisplayMessage(True, "")
                End If

                   
                If Temp Like "*-" & BLIB_No.Trim & "-*" Then
                    For TempCell As Integer = Asc("A") To Asc("Q")
                        ws.Range(Chr(TempCell) & CurRow).Cells.Font.ColorIndex = 3
                    Next
                End If
                CurType = " "
                For CountContainer As Integer = 0 To dsContainer.Tables("oTableContainer").Rows.Count - 1
                    Dim Type As String = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                    'If Type = "20GP" Then
                    '    ws.Range("D" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40GP" Then
                    '    ws.Range("E" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "20RF" Then
                    '    ws.Range("F" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40RF" Then
                    '    ws.Range("G" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40HC" Then
                    '    ws.Range("H" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'ElseIf Type = "40RH" Then
                    '    ws.Range("I" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'Else
                    '    ws.Range("J" & CurRow).Value2 = dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    'End If
                    'If dsContainer.Tables("oTableContainer").Rows.Count - 1 > 0 Then
                    '    MsgBox("")
                    'End If
                    If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                        CurType &= "," & Strings.Right(Type, 2)
                    End If
                    CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)

                    If Strings.Left(Type, 2) = "20" Then
                        ws.Range("D" & CurRow).Value2 += dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    Else
                        ws.Range("E" & CurRow).Value2 += dsContainer.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                    End If
                    ws.Range("F" & CurRow).Value2 = CurType
                Next


                'Dim Collect As Integer = 
                QueryPrice(dsdata.Tables(0).Rows(i).Item("F0").ToString)

                'ws.Range("P" & CurRow + i).Value2 = Me.txtCommission.Text

                If dsFee.Tables(0).Rows.Count > 0 Then
                    ' For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsfee.table(0)
                    'If dsFee.Tables(0).Rows(k).Item("BLIB_ID").ToString = dsdata.Tables(0).Rows(i).Item("F0").ToString Then
                    'For j As Integer = 8 To 26
                    'If dsFee.Tables(0).Rows(k).Item("F" & j).ToString.Trim.Length > 0 Then
                    '    ws.Range(Alpha(j - 1) & 11 + dem).Value2 = dsFee.Tables(0).Rows(k).Item("F" & j).ToString
                    'End If
                    'Next
                    'End If
                    ' Next

                    For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1
                        If UCase(dsFee.Tables(0).Rows(k).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                            ws.Range("I" & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("Fee").ToString
                            'If dsFee.Tables(0).Rows(k).Item("Currency").ToString <> "USD" Then
                            '    DisplayMessage(True, "Bill : " + BLIB_No + " have other Currency., please check it !")
                            '    'ws.Range("I" & CurRow).d()
                            'End If
                        Else
                            ws.Range("J" & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("Fee").ToString
                            If dsFee.Tables(0).Rows(k).Item("Currency").ToString <> "USD" Then
                                DisplayMessage(True, "Bill : " + BLIB_No + " have other Currency., please check it !")
                                'ws.Range("I" & CurRow).d()
                            End If
                        End If
                    Next
                End If
                ws.Range("M" & CurRow).Value2 = Me.txtCommission.Text
                'commisson
                ws.Range("N" & CurRow).Formula = "=(sum(G" & CurRow & ":H" & CurRow & ")" & "*M" & CurRow & ")/100"

                For k As Integer = 0 To 2
                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        'arrS(dem, k) = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                        ws.Range(Alpha(k) & CurRow).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                    End If
                Next

                For P As Integer = 0 To dsdataOceanFreight.Tables(0).Rows.Count - 1
                    If dsdata.Tables(0).Rows(i).Item("F0").ToString = dsdataOceanFreight.Tables(0).Rows(P).Item("F0").ToString Then
                        'OceanFreightarr(dem) = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                        'If dsdata.Tables(0).Rows(i).Item("F0").ToString = "2bd6a904-22f4-48a0-a7f7-252e67b6d79a" Then
                        '    MsgBox("")
                        'End If
                        If UCase(dsdataOceanFreight.Tables(0).Rows(P).Item("Prepaid_Collect").ToString) = "PREPAID" Then
                            ws.Range("G" & CurRow).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                            'them net
                            ws.Range("Q" & CurRow).Formula = "=(H" & CurRow & "+ J" & CurRow & "+ L" & CurRow & ")-(K" & CurRow & "+ N" & CurRow & ")" '=(H8+J8+L8)-(K8+N8)
                            note += 1
                            'If dsdataOceanFreight.Tables(0).Rows(P).Item("Currency").ToString <> "USD" Then
                            '    DisplayMessage(True, "Bill : " + BLIB_No + " have other Currency., please check it !")
                            '    'ws.Range("I" & CurRow).d()
                            'End If
                        Else
                            ws.Range("H" & CurRow).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                            'them net
                            ws.Range("Q" & CurRow).Formula = "=(H" & CurRow & "+ J" & CurRow & "+ L" & CurRow & ")-(K" & CurRow & "+ N" & CurRow & ")" '=(H8+J8+L8)-(K8+N8)
                            note += 1
                            If dsdataOceanFreight.Tables(0).Rows(P).Item("Currency").ToString <> "USD" Then
                                DisplayMessage(True, "Bill : " + BLIB_No + " have other Currency., please check it !")
                                'ws.Range("I" & CurRow).d()
                            End If
                        End If
                    End If
                Next
                QueryDHC_THC(dsdata.Tables(0).Rows(i).Item("F0").ToString)
                If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    'For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                    'If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                    'ws.Range("O" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                    '' Else
                    'ws.Range("P" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                    If dsTHC_DHC.Tables(0).Rows(0).Item("Currency").ToString <> "USD" And dsTHC_DHC.Tables(0).Rows(0).Item("prepaid_collect").ToString = "COLLECT" Then

                        DisplayMessage(True, "Bill : " + BLIB_No + " have other Currency (in LHC charge)., please check it !")
                        'ws.Range("I" & CurRow).d()

                    End If
                    ws.Range("L" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString

                    ws.Range("K" & CurRow).Formula = "=L" & CurRow & " *7.5/100"

                    ' End If
                    ' Next
                End If
                If note = 2 And pc = False Then
                    pc = True
                End If

                CurRow += 1
                dem += 1
            Next

            ' ws.Range("G3").Value2 = Me.cboThang.Text & " / " & Me.cboNam.Text
            'Me.DataGridView1.DataSource = dsdata.Tables(0)
            ws.Range("G3").Value2 = tempvessel(0) & " - " & tempvessel(1)
            'ws.Range("E6").Value2 = tempvessel(1)
            ws.Range("G4").Value2 = CDate(tempvessel(2)).Date

            path = "c:\TripAccountInbound" & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            If pc Then
                MsgBox("there is a bill have 2 O/F(prepaid , Collect) please check again")
            End If
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

    'Function QueryPrice1(ByVal billID As String) As Integer
    '    Try
    '        Dim strQuery As String
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,"
    '        strQuery &= "BLIB_ID,"
    '        strQuery &= "F8=case items when 'BAF' then UnitPrice*Quantity end ," 'BAF
    '        strQuery &= "F9=case items when 'WRS' then UnitPrice*Quantity end," 'WRS
    '        strQuery &= "F10=case items when 'CAF' then UnitPrice*Quantity end," 'CAF
    '        strQuery &= "F11=case items when 'DIB' then UnitPrice*Quantity end," 'DIB
    '        strQuery &= "F12=case items when 'DDC' then UnitPrice*Quantity end," 'DDC
    '        strQuery &= "F13=case items when 'LHC' then UnitPrice*Quantity end," 'LHC
    '        strQuery &= "F14=case items when 'MAF' then UnitPrice*Quantity end," 'MAF
    '        strQuery &= "F15=case items when 'ACC' then UnitPrice*Quantity end," 'ACC
    '        strQuery &= "F16=case items when 'BKC' then UnitPrice*Quantity end," 'BKC
    '        strQuery &= "F17=case items when 'ERS' then UnitPrice*Quantity end," 'ERS
    '        strQuery &= "F18=case items when 'PTC' then UnitPrice*Quantity end," 'PTC
    '        strQuery &= "F19=case items when 'PSS' then UnitPrice*Quantity end," 'PSS
    '        strQuery &= "F20=case items when 'COD' then UnitPrice*Quantity end," 'COD
    '        strQuery &= "F21=case items when 'ASC' then UnitPrice*Quantity end," 'ACS
    '        strQuery &= "F22=case items when 'PCF' then UnitPrice*Quantity end," 'PCF
    '        strQuery &= "F23=case items when 'OIB' then UnitPrice*Quantity end," 'OIB
    '        strQuery &= "F24=case items when 'ARB' then UnitPrice*Quantity end," 'ARB
    '        strQuery &= "F25=case items when 'RSC' then UnitPrice*Quantity end," 'RSC
    '        strQuery &= "F26=case items when 'ORC' then UnitPrice*Quantity end" 'ORC
    '        strQuery &= " From Freight_Charge_IB "
    '        strQuery &= " Where BLIB_ID='" & billID & "' And Continued=1 and PREPAID_COLLECT='COLLECT'"
    '        Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
    '        Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
    '        If Not IsNothing(dsFee) Then
    '            dsFee.Clear()
    '        End If
    '        AdapterFee.Fill(dsFee)
    '        Return dsFee.Tables(0).Rows(0).Item("flag")
    '    Catch ex As Exception

    '    End Try

    'End Function
    Sub QueryPrice(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPrice * Quantity), Currency "
            strQuery &= " From Freight_Charge_IB "
            strQuery &= " Where BLIB_ID='" & billID & "' and Continued=1 And Items<>'OCB' and Items <> 'THC' And Items <> 'DHC'Group By Prepaid_Collect, currency "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsFee) Then
                dsFee.Clear()
            End If
            AdapterFee.Fill(dsFee)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPrice * Quantity), currency, prepaid_collect  "
            strQuery &= " From Freight_Charge_IB "
            strQuery &= " Where BLIB_ID='" & billID & "' and Continued=1 And (Items like '%DHC%' Or Items Like '%THC%') and Prepaid_Collect='COLLECT' group by currency,prepaid_collect "
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
    'Sub QueryBill1()
    '    Try
    '        Dim strQuery As String

    '        strQuery = "Select distinct BillOfLadingIb.BLIB_ID as F0,POR AS F1,POL AS F2,POD AS F3,DEST AS F4,BLIB_NO AS F5 "
    '        strQuery &= " From BillOfLadingIb "
    '        strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text & " Order by BLIB_NO "
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        If Not IsNothing(dsdata) Then
    '            dsdata.Clear()
    '        End If
    '        Adapter.Fill(dsdata)
    '        strQuery = "Select FREIGHT_CHARGE_IB.BLIB_ID as F0,UnitPrice*Quantity as OceanFreight "
    '        strQuery &= " from (BillOfLadingIb LEFT JOIN FREIGHT_CHARGE_IB on FREIGHT_CHARGE_IB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
    '        strQuery &= " where items like'%OCB%' and PREPAID_COLLECT='COLLECT' And CURRENCY='USD' and FREIGHT_CHARGE_IB.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
    '        Dim cmdSelectOceanFreight As New SqlClient.SqlCommand(strQuery, Conn)
    '        Dim AdapterOceanFreight As New SqlClient.SqlDataAdapter(cmdSelectOceanFreight)
    '        If Not IsNothing(dsdataOceanFreight) Then
    '            dsdataOceanFreight.Clear()
    '        End If
    '        AdapterOceanFreight.Fill(dsdataOceanFreight)

    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '    End Try
    'End Sub

    Sub QueryBill()
        Try
            Dim strQuery As String

            strQuery = "Select  BillOfLadingIb.BLIB_ID as F0,POL AS F2,POD AS F3,DEST AS F4,BLIB_NO AS F1 "
            strQuery &= " From BillOfLadingIb "
            strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And  (BLIB_NO Not LIKE '%PNH%') Order by STT "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If Not IsNothing(dsdata) Then
                dsdata.Clear()
            End If
            Adapter.Fill(dsdata)
            strQuery = "Select FREIGHT_CHARGE_IB.BLIB_ID as F0,sum(UnitPrice*Quantity) as OceanFreight,Prepaid_Collect, currency "
            strQuery &= " from (BillOfLadingIb LEFT JOIN FREIGHT_CHARGE_IB on FREIGHT_CHARGE_IB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
            strQuery &= " where (items like'%OCB%' Or items like'%ODB%') and FREIGHT_CHARGE_IB.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
            strQuery &= " group by Prepaid_collect,FREIGHT_CHARGE_IB.BLIB_ID, currency "
            Dim cmdSelectOceanFreight As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterOceanFreight As New SqlClient.SqlDataAdapter(cmdSelectOceanFreight)
            If Not IsNothing(dsdataOceanFreight) Then
                dsdataOceanFreight.Clear()
            End If
            AdapterOceanFreight.Fill(dsdataOceanFreight)

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    Sub QueryVessel()
        Try
            Dim SQL As String = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data from BillOfLadingIB where Continued=1 And day(ETA)=" & Me.cboDay.Text & " And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            Adapter.Fill(ds)
            Me.cboVessel.Items.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
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
    Private Sub frmTripAccountInbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboNam.Text = Now.Year
            Me.cboThang.Text = Now.Month
            'dsdata.Tables.Clear()
            '            dsdata.Tables.Add("oTableContainer")

            For i As Integer = 2000 To 2050
                Me.cboNam.Items.Add(i)
            Next

            'QueryBill()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cboThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboThang.SelectedIndexChanged, cboDay.SelectedIndexChanged
        Me.cboVessel.Text = ""
        QueryVessel()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.cboVessel.Text = "" Then
            Return
        End If
        tempvessel = Strings.Split(Me.cboVessel.Text, " - ")

        QueryBill()
        SetExcelValue()
        'InsertExcel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub


    Private Sub cboNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNam.SelectedIndexChanged
        Me.cboVessel.Text = ""
        QueryVessel()

    End Sub
End Class