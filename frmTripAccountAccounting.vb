'Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Structure FeePos
    Public Items As String
    Public Pos As String
End Structure
Public Class frmTripAccountAccounting

    Dim ArrPos(100) As FeePos
    Dim CountFee As Integer 'đếm số phí hiện có
    Dim path As String
    Dim tempvessel() As String
    Private connstring As String
    Dim dsdata As New DataSet
    Dim dsTHC_DHC As New DataSet
    Dim dsdataOceanFreight As New DataSet
    Dim dsFee As New DataSet
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
    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPrice * Quantity) "
            strQuery &= " From Freight_Charge_IB "
            strQuery &= " Where BLIB_ID='" & billID & "' and Continued=1 And (Items like '%DHC%' Or Items Like '%THC%') and Prepaid_Collect='COLLECT'"
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
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            path = StartupPath & "\TripAccountAccounting.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If

            Dim n As Integer = dsdata.Tables(0).Rows.Count
            'Dim range As Object 'Range 

            Dim arr(n, 20) As Double
            Dim arrS(n, 7) As String
            Dim OceanFreightarr(n) As Double
            Dim CurRow As Integer = 11
            Dim BillNo As String = ""
            CountFee = 0
            Dim TempRepeatBill As String
            TempRepeatBill = QueryRepeatContainer(tempvessel(0), tempvessel(1))
            For i As Integer = 0 To n - 1
                'If i = 8 Then
                '    MsgBox(" ")
                'End If

                BillNo = dsdata.Tables(0).Rows(i).Item("F5").ToString.Trim
                If TempRepeatBill Like "*-" & BillNo.Trim & "-*" Then
                    For TempCell As Integer = Asc("A") To Asc("Z")
                        ws.Range(Chr(TempCell) & CurRow).Cells.Font.ColorIndex = 3
                    Next
                End If

                Dim Collect As Integer = QueryPrice(dsdata.Tables(0).Rows(i).Item("F0").ToString)

                ws.Range("I" & CurRow).Value2 = Me.txtCommission.Text

                If dsFee.Tables(0).Rows.Count > 0 Then
                    For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsfee.table(0)

                        'che ngày 2-11-2007 cho xuất Tất cảc Các Fee có trong Freight_Charge_IB
                        'If dsFee.Tables(0).Rows(k).Item("BLIB_ID").ToString = dsdata.Tables(0).Rows(i).Item("F0").ToString Then
                        '    For j As Integer = 10 To 28
                        '        If dsFee.Tables(0).Rows(k).Item("F" & j - 2).ToString.Trim.Length > 0 Then
                        '            ws.Range(Alpha(j - 1) & 11 + dem).Value2 = dsFee.Tables(0).Rows(k).Item("F" & j - 2).ToString
                        '        End If
                        '    Next
                        'End If
                        Dim Insert As Boolean = True
                        'CountFee = 0
                        For TempPos As Integer = 0 To CountFee - 1
                            If dsFee.Tables(0).Rows(k).Item("Items").ToString.Trim.ToUpper() = ArrPos(TempPos).Items Then
                                ws.Range(ArrPos(TempPos).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                                Insert = False
                                Exit For
                            End If
                        Next
                        If Insert Then
                            ArrPos(CountFee).Items = dsFee.Tables(0).Rows(k).Item("Items").ToString.Trim.ToUpper()
                            ArrPos(CountFee).Pos = Alpha(Asc("J") + CountFee - 65)
                            ws.Range(ArrPos(CountFee).Pos & 7).Value2 = ArrPos(CountFee).Items
                            ws.Range(ArrPos(CountFee).Pos & 8).Value2 = "USD"
                            ws.Range(ArrPos(CountFee).Pos & 9).Value2 = "FL" & CountFee + 1
                            ws.Range(ArrPos(CountFee).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                            CountFee += 1
                        End If
                    Next

                End If

                For k As Integer = 0 To 4
                    Dim temp As String
                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        'arrS(dem, k) = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                        If k = 0 Then
                            temp = Mid(BillNo, 2, 3)
                        ElseIf k = 1 Then
                            temp = Mid(BillNo, 2, 3)
                        ElseIf k = 2 Then
                            temp = Mid(BillNo, 5, 3)
                        Else
                            temp = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                        End If
                        ws.Range(Alpha(k) & CurRow).Value2 = temp 'dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                    End If
                Next

                For P As Integer = 0 To dsdataOceanFreight.Tables(0).Rows.Count - 1
                    If dsdata.Tables(0).Rows(i).Item("F0").ToString = dsdataOceanFreight.Tables(0).Rows(P).Item("F0").ToString Then
                        'OceanFreightarr(dem) = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                        ws.Range("F" & CurRow).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")

                    End If

                Next
                QueryDHC_THC(dsdata.Tables(0).Rows(i).Item("F0").ToString)
                If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    'For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                    'If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then

                    'Else
                    ws.Range("H" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString

                    ws.Range("G" & CurRow).Formula = "=H" & CurRow & " *7.5/100"
                    'End If
                    'Next
                End If
                CurRow += 1
            Next

            ws.Range("B4").Value2 = Me.cboThang.Text & " / " & Me.cboNam.Text
            'Me.DataGridView1.DataSource = dsdata.Tables(0)
            ws.Range("B6").Value2 = tempvessel(0)
            ws.Range("E6").Value2 = tempvessel(1)

            ws.Range("G6").Value2 = CDate(tempvessel(2)).Date

            path = "c:\TripAccountAccounting" & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )

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

    'Che Ngày 2-11-2007 Thay bàng hàm khác Xuất Toàn bộ Items Không giớn hạn
    'Function QueryPrice(ByVal billID As String) As Integer
    '    Try
    '        Dim strQuery As String
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,"
    '        strQuery &= "BLIB_ID,"
    '        strQuery &= "F8=case items when 'BAF' then UnitPrice end ," 'BAF
    '        strQuery &= "F9=case items when 'WRS' then UnitPrice end," 'WRS
    '        strQuery &= "F10=case items when 'CAF' then UnitPrice end," 'CAF
    '        strQuery &= "F11=case items when 'DIB' then UnitPrice end," 'DIB
    '        strQuery &= "F12=case items when 'DDC' then UnitPrice end," 'DDC
    '        strQuery &= "F13=case items when 'LHC' then UnitPrice end," 'LHC
    '        strQuery &= "F14=case items when 'MAF' then UnitPrice end," 'MAF
    '        strQuery &= "F15=case items when 'ACC' then UnitPrice end," 'ACC
    '        strQuery &= "F16=case items when 'BKC' then UnitPrice end," 'BKC
    '        strQuery &= "F17=case items when 'ERS' then UnitPrice end," 'ERS
    '        strQuery &= "F18=case items when 'PTC' then UnitPrice end," 'PTC
    '        strQuery &= "F19=case items when 'PSS' then UnitPrice end," 'PSS
    '        strQuery &= "F20=case items when 'COD' then UnitPrice end," 'COD
    '        strQuery &= "F21=case items when 'ASC' then UnitPrice end," 'ACS
    '        strQuery &= "F22=case items when 'PCF' then UnitPrice end," 'PCF
    '        strQuery &= "F23=case items when 'OIB' then UnitPrice end," 'OIB
    '        strQuery &= "F24=case items when 'ARB' then UnitPrice end," 'ARB
    '        strQuery &= "F25=case items when 'RSC' then UnitPrice end," 'RSC
    '        strQuery &= "F26=case items when 'ORC' then UnitPrice end" 'ORC
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


    'Thêm 2-11-2007 Xuất toàn bộ Phí
    Function QueryPrice(ByVal billID As String) As Integer
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,"
            strQuery &= "Items,FEE=sum(UnitPrice*QuanTity) "
            strQuery &= " From Freight_Charge_IB "
            strQuery &= " Where BLIB_ID='" & billID & "' And Continued=1 and PREPAID_COLLECT='COLLECT' And Items <>'OCB' And Items<>'ODB' And Items<>'THC' And Items<>'DHC' "
            strQuery &= " Group By Items,Prepaid_Collect "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsFee) Then
                dsFee.Clear()
            End If
            AdapterFee.Fill(dsFee)
            Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception

        End Try

    End Function
    Sub QueryBill()
        Try
            Dim strQuery As String

            strQuery = "Select  BillOfLadingIb.BLIB_ID as F0,POR AS F1,POL AS F2,POD AS F3,DEST AS F4,BLIB_NO AS F5 "
            strQuery &= " From BillOfLadingIb "
            strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And (BLIB_NO Not LIKE '%PNH%') Order by BillOfLadingIB.STT "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If Not IsNothing(dsdata) Then
                dsdata.Clear()
            End If
            Adapter.Fill(dsdata)
            strQuery = "Select FREIGHT_CHARGE_IB.BLIB_ID as F0,UnitPrice as OceanFreight "
            strQuery &= " from (BillOfLadingIb LEFT JOIN FREIGHT_CHARGE_IB on FREIGHT_CHARGE_IB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
            strQuery &= " where (items like'%OCB%' Or items like'%ODB%') and PREPAID_COLLECT='COLLECT' and FREIGHT_CHARGE_IB.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
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
            Dim SQL As String = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data from BillOfLadingIB where Continued=1 And day(ETA)=" & Me.cboday.Text & " And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
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