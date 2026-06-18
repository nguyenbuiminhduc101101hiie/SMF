Public Class frmImportTariff

    Private Sub frmImportTariff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        On Error GoTo Err
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtFileName.Text = Me.OpenFileDialog1.FileName
        End If
        Exit Sub
Err:
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Function GetMarketID(ByVal MarketCode As String) As String
        Try
            Dim SQL As String
            SQL = "select * from Market Where MarketCode='" & MarketCode & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return "{" & dt.Rows(0).Item("Market_ID").ToString & "}"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return ""
        End Try
    End Function

    Function CheckExist(ByVal ws As Excel._Worksheet, ByVal CurRow As Integer) As Boolean
        Try
            Dim SQL As String
            SQL = "select ContainerType,Rate,Unit "
            SQL &= "from ((FreightTariff INNER JOIN Market On Market.Market_ID=FreightTariff.Market_ID) "
            SQL &= " LEFT JOIN Freight On Freight.FreightTariffID=FreightTariff.FreightTariffID)"
            SQL &= " Where FreightTariff.Continued=1 And Market.MarketCode='" & ws.Range("A" & CurRow).Value & "' "
            SQL &= " And [Date]='" & ws.Range("C" & CurRow).Value & "' And (DateExp='" & ws.Range("D" & CurRow).Value & "'  or DateExp is null)  And (TariffRef='" & ws.Range("E" & CurRow).Value & "' Or TariffRef Is Null) "
            SQL &= " And POL='" & ws.Range("F" & CurRow).Value & "' And POD='" & ws.Range("G" & CurRow).Value & "' And UpdateDate='" & ws.Range("B" & CurRow).Value & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return True
            End If
            Dim Unit As String
            Unit = ws.Range("O" & CurRow).Value
            Dim Type(7) As String
            Dim Pos(7) As String
            Dim count As Integer = 0
            For i As Integer = Asc("H") To Asc("N")
                If Not IsNothing(ws.Range(Chr(i) & CurRow).Value) Then
                    If ws.Range(Chr(i) & CurRow).Value > 0 Then
                        Pos(count) = ws.Range(Chr(i) & CurRow).Value
                        Type(count) = ws.Range(Chr(i) & 1).Value 'dòng đầu tiên trong file
                        count += 1
                    End If
                End If
            Next

            'trừơng hợp sửa
            Dim TypeChange As Boolean = False '
            Dim DongGiongNhau As Integer = 0
            For i As Integer = 0 To dt.Rows.Count - 1

                For j As Integer = 0 To count - 1
                    If dt.Rows(i).Item("ContainerType") = Type(j) Then
                        TypeChange = True
                        If dt.Rows(i).Item("Rate") = Pos(j) And dt.Rows(i).Item("Unit") = ws.Range("O" & CurRow).Value Then
                            DongGiongNhau += 1
                        End If
                    End If
                Next
            Next
            If DongGiongNhau <> dt.Rows.Count Then
                Return True
            End If
            If TypeChange = False Then
                Return True
            End If
            Return False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}

            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFileName.Text

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim CurRow As Integer = 2

            Dim rsTariff As New ADODB.Recordset
            Dim rsFreight As New ADODB.Recordset
            Dim SQLTariff, SQLFreight As String
            SQLTariff = "select * from FreightTariff where continued=1 "
            SQLFreight = "Select * from Freight where continued=1"
            Dim MarketID As String
            Dim Type() As String = {"20GP", "40GP", "40HC", "20RF", "40RF", "45HC", "40RH"}



            '---------------
            Dim seri As Integer
            Dim temp As String
            SQLTariff = "select * from customer  "

            For CurRow = 2 To 676
                ' kiem tra
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from customer " 'where taxcode='" & ws.Range("e" & CurRow).Value.ToString.Trim & "' "
                ds = ReadDataSet(sql)
                'If ds.Tables(0).Rows.Count > 0 Then

                'Else
                rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rsTariff
                    .AddNew()
                    .Fields("customer_id").Value = NewId()
                    '.Fields("maincode").Value = ""
                    '---------------  

                    seri = 0
                    temp = ""
                    seri = CDbl(frmListCustomer.getCusID()) + 1
                    For h As Integer = seri.ToString.Length To 5
                        temp &= "0"
                    Next
                    temp &= seri

                    .Fields("customer_code").Value = temp


                    .Fields("kpis").Value = "Regular"
                    .Fields("branch").Value = "SGN"
                    .Fields("maincode").Value = "Customer"
                    .Fields("type").Value = "1"
                    ' CurRow += 1
                    '------------------


                    .Fields("englishname").Value = ws.Range("c" & CurRow).Value
                    .Fields("company").Value = ws.Range("c" & CurRow).Value
                    .Fields("shortname").Value = ws.Range("a" & CurRow).Value
                    .Fields("taxcode").Value = ws.Range("f" & CurRow).Value
                    .Fields("tel").Value = ""
                    .Fields("cothue").Value = 1
                    'If ws.Range("a" & CurRow).Value Like "*TEL*" Then

                    'Else
                    ' While Not IsNothing(ws.Range("A" & CurRow).Value)
                    .Fields("addresstiengviet").Value = ws.Range("e" & CurRow).Value + Chr(13) ' + ws.Range("c" & CurRow).Value + Chr(13) + ws.Range("d" & CurRow).Value + Chr(13)
                    .Fields("address").Value = ws.Range("e" & CurRow).Value + Chr(13) ' + ws.Range("c" & CurRow).Value + Chr(13) + ws.Range("d" & CurRow).Value + Chr(13)


                    'CurRow += 1

                    ' .Fields("tel").Value = ws.Range("e" & CurRow).Value
                    ' .Fields("fax").Value = ws.Range("f" & CurRow).Value
                    ' .Fields("attn").Value = ws.Range("g" & CurRow).Value
                    'CurRow += 1
                    'End If


                    'If ws.Range("a" & CurRow).Value Like "*TEL*" Then

                    '    .Fields("tel").Value = ws.Range("a" & CurRow).Value.ToString.Replace("TEL", "")
                    'End If
                    'CurRow += 1
                    '  End While
                    '



                    .Update()
                End With
                rsTariff.Close()


            Next



            'While Not IsNothing(ws.Range("A" & CurRow).Value)
            '    If CheckExist(ws, CurRow) = False Then 'nếu dòng đã có trong CS dữ liệu thì không thêm nữa
            '        CurRow += 1
            '        Continue While
            '    End If
            '    MarketID = GetMarketID(ws.Range("A" & CurRow).Value.ToString.Trim)
            '    If MarketID = "" Then 'nếu market ko đúng thì bỏ qua 1 dòng
            '        MsgBox("Market Code is invalid,Check again please Error Rows: " & CurRow)
            '        CurRow += 1
            '        Continue While
            '    End If
            '    Dim mFreightTariffID As String = ""
            '    rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            '    With rsTariff
            '        .AddNew()
            '        .Fields("FreightTariffID").Value = NewId()
            '        mFreightTariffID = .Fields("FreightTariffID").Value
            '        .Fields("Market_ID").Value = MarketID
            '        .Fields("Date").Value = ws.Range("C" & CurRow).Value
            '        .Fields("DateExp").Value = ws.Range("D" & CurRow).Value
            '        .Fields("TariffRef").Value = ws.Range("E" & CurRow).Value
            '        .Fields("DateRef").Value = ws.Range("C" & CurRow).Value 'bằng ngày áp dụng 
            '        .Fields("POL").Value = ws.Range("F" & CurRow).Value
            '        .Fields("POD").Value = ws.Range("G" & CurRow).Value
            '        .Update()
            '    End With
            '    rsTariff.Close()


            '    Dim Pos As Integer = 0
            '    rsFreight.Open(SQLFreight, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            '    With rsFreight
            '        For i As Integer = Asc("H") To Asc("N")
            '            If Not IsNothing(ws.Range(Chr(i) & CurRow).Value) Then
            '                If ws.Range(Chr(i) & CurRow).Value > 0 Then
            '                    .AddNew()
            '                    .Fields("FreightID").Value = NewId()
            '                    .Fields("FreightTariffID").Value = "{" & mFreightTariffID.Replace("}", "").Replace("{", "") & "}"
            '                    .Fields("ContainerType").Value = Type(Pos)
            '                    .Fields("Rate").Value = ws.Range(Chr(i) & CurRow).Value
            '                    .Fields("Unit").Value = ws.Range("O" & CurRow).Value
            '                    .Update()
            '                End If
            '            End If
            '            pos+=1
            '        Next
            '    End With
            '    rsFreight.Close()
            '    CurRow += 1
            'End While

            MsgBox("Complete import :" & CurRow & " rows")
        Catch ex As Exception
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}

            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFileName.Text

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim CurRow As Integer = 2

            Dim rsTariff As New ADODB.Recordset
            Dim rsFreight As New ADODB.Recordset
            Dim SQLTariff, SQLFreight As String
            SQLTariff = "select * from port  "

            For CurRow = 1 To 3576
                rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rsTariff
                    .AddNew()
                    .Fields("port_id").Value = NewId()
                    '.Fields("maincode").Value = ""
                    .Fields("port").Value = ws.Range("b" & CurRow).Value



                    .Fields("port_code").Value = ws.Range("a" & CurRow).Value
                    .Fields("ig").Value = "AIR"
                    '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



                    '.Fields("address").Value = ws.Range("c" & CurRow).Value
                    '.Fields("tel").Value = ws.Range("d" & CurRow).Value
                    '.Fields("fax").Value = ws.Range("e" & CurRow).Value
                    '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



                    .Update()
                End With
                rsTariff.Close()
            Next



         

            MsgBox("Complete import :" & CurRow & " rows")
        Catch ex As Exception
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim app As Excel.Application
        ' Try
        'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}

        'app = New Excel.Application()
        'app.Visible = False

        'Dim workbooks As Excel.Workbooks
        'workbooks = app.Workbooks
        'Dim workbook As Excel._Workbook

        'Dim path As String = Me.txtFileName.Text

        'workbook = workbooks.Open(path)



        'Dim sheets As Excel.Sheets
        'sheets = workbook.Worksheets
        'Dim ws As Excel._Worksheet
        'ws = sheets.Item(Me.txtSheetName.Text)
        'If ws Is Nothing Then
        '    app.Quit()

        '    Return
        'End If
        Dim CurRow As Integer = 2

        Dim rsTariff As New ADODB.Recordset
        Dim rsFreight As New ADODB.Recordset
        Dim SQLTariff, SQLFreight As String
        SQLTariff = "select * from ref_LC_AGENCYIMPORT  "

        For CurRow = 1001 To 10000
            rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rsTariff
                .AddNew()
                .Fields("id").Value = NewId()
                '.Fields("maincode").Value = ""
                .Fields("autonumber").Value = CurRow



                .Fields("continued").Value = True
                ' .Fields("ig").Value = "AIR"
                '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



                '.Fields("address").Value = ws.Range("c" & CurRow).Value
                '.Fields("tel").Value = ws.Range("d" & CurRow).Value
                '.Fields("fax").Value = ws.Range("e" & CurRow).Value
                '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



                .Update()
            End With
            rsTariff.Close()
        Next


        '    SQLTariff = "select * from ref_CC_AGENCYIMPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next

        '    SQLTariff = "select * from ref_FC_AGENCYEXPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next


        '    SQLTariff = "select * from ref_FC_AGENCYIMPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next

        '    SQLTariff = "select * from ref_FS_AGENCYEXPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next
        '    SQLTariff = "select * from ref_FS_AGENCYIMPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next
        '    SQLTariff = "select * from ref_LC_AGENCYEXPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next

        '    SQLTariff = "select * from ref_LC_AGENCYIMPORT  "

        '    For CurRow = 1 To 1000
        '        rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        With rsTariff
        '            .AddNew()
        '            .Fields("id").Value = NewId()
        '            '.Fields("maincode").Value = ""
        '            .Fields("autonumber").Value = CurRow



        '            .Fields("continued").Value = True
        '            ' .Fields("ig").Value = "AIR"
        '            '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



        '            '.Fields("address").Value = ws.Range("c" & CurRow).Value
        '            '.Fields("tel").Value = ws.Range("d" & CurRow).Value
        '            '.Fields("fax").Value = ws.Range("e" & CurRow).Value
        '            '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



        '            .Update()
        '        End With
        '        rsTariff.Close()
        '    Next

        '    MsgBox("Complete import :" & CurRow & " rows")
        'Catch ex As Exception
        '    MsgBox(Err.Description)
        '    Return
        'Finally
        '    app.Quit()
        'End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim i As Integer
            Dim CurRow As Integer = 2
            Dim rsTariff As New ADODB.Recordset
            Dim rsFreight As New ADODB.Recordset
            Dim SQLTariff, SQLFreight As String
            Try




                SQLTariff = "select * from " & Me.ComboBox1.Text & "  "

                For i = CInt(Me.txtfrom.Text) To CInt(Me.txtto.Text)
                    rsTariff.Open(SQLTariff, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rsTariff
                        .AddNew()
                        .Fields("id").Value = NewId()
                        '.Fields("maincode").Value = ""
                        .Fields("autonumber").Value = i



                        .Fields("continued").Value = True
                        ' .Fields("ig").Value = "AIR"
                        '.Fields("bizname").Value = ws.Range("b" & CurRow).Value



                        '.Fields("address").Value = ws.Range("c" & CurRow).Value
                        '.Fields("tel").Value = ws.Range("d" & CurRow).Value
                        '.Fields("fax").Value = ws.Range("e" & CurRow).Value
                        '.Fields("taxcode").Value = ws.Range("f" & CurRow).Value



                        .Update()
                    End With
                    rsTariff.Close()
                Next

            Catch ex As Exception

            End Try





        Catch ex As Exception

        End Try
    End Sub
End Class