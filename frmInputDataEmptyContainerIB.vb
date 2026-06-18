Imports System.IO
Imports System.Globalization
Public Class frmInputDataEmptyContainerIB

    Public shd As String
    Public i As Integer
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdBroswser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBroswser.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtFilename.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Sub InsertContainerMNG(ByVal oTable As DataTable, ByVal BLNO As String, ByVal i As Integer, ByVal CargoIB_ID As String)
        Try
            Dim SQL, trang As String
            trang = ""
            SQL = "select * from ContainerManagerment WHERE cONTAINER_NO ='" & oTable.Rows(i).Item("F3").ToString.Trim & "' AND BL_NO_Inbound = '" & BLNO & "' AND CONTINUED=1 "
            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                rs.AddNew()
                rs.Fields("ContainerManagementID").Value = NewId()
            End If
            With rs
                '''''''''''''''''''''''''''''''''''''''''
                .Fields("BL_NO_Inbound").Value = BLNO 'ws.Range("B" & i).Value.ToString
                .Fields("Container_No").Value = oTable.Rows(i).Item("F3").ToString.Trim.Replace(" ", "")
                .Fields("FullOrEmpty").Value = oTable.Rows(i).Item("F4").ToString
                .Fields("CTN_SIZE_TYPE").Value = Strings.Replace(oTable.Rows(i).Item("F5").ToString, "'", "").Trim
                .Fields("POL_CODE").Value = oTable.Rows(i).Item("F9").ToString

                .Fields("CargoIB_ID").Value = CargoIB_ID

                '.Fields("Vessel_Inbound").Value = Me.cboVessel.Text.Trim
                '.Fields("VoyNo_Inbound").Value = Me.txtVoyNo.Text.Trim
                '.Fields("Arrival_Date").Value = Me.dtpETA.Value.Date
                .Fields("DisCharge_Date").Value = .Fields("Arrival_Date").Value
                '.Fields("ImportCY").Value = oTable.Rows(i).Item("F2").ToString
                Dim arr() As String = {"SoundContainer", "ToBeInSpected", "DamageContainer", "FullImport", "FullToConsignee", "FullExport", "EmptyToShipper", "EmptyContainerReposit"}
                For j As Integer = 0 To arr.Length - 1
                    .Fields(arr(j)).Value = 0
                Next
                '.Fields("EmptyCY").Value = Me.CBOicdpORT.Text
                '.Fields("ImportCY").Value = Me.CBOicdpORT.Text
                '.Fields("FinalICD").Value = Me.CBOicdpORT.Text
                .Fields("SoundContainer").Value = 1
                .Fields("FactOfDelDate").Value = .Fields("Arrival_Date").Value
                .Fields("FactOfReDelDate").Value = .Fields("Arrival_Date").Value
                .Update()
            End With
            rs.Close()



        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function GetCode(ByVal Table As String) As String
        Try
            Dim SQL As String
            SQL = "select Count(*) From " & Table
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 1
            End If
            Return dt.Rows(0).Item(0) + 1
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function CheckEsist(ByVal Table As String, ByVal col As String, ByVal rang As String, ByVal ID As String) As String
        Try
            Dim SQL As String
            SQL = "select " & ID & " From " & Table & " Where Continued=1 and " & col & "='" & rang & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Dim TempID As String = NewId()
                SQL = "Insert Into " & Table & "(" & ID & "," & Table & "_Code," & col & ") Values('" & TempID & "','" & GetCode(Table) & "','" & rang & "')"
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
                cmd.CommandType = CommandType.Text
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
                Return TempID
            End If
            Return "{" & dt.Rows(0).Item(0).ToString & "}"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Return ""
    End Function

    Function CheckContainer(ByVal ContainerNo As String, ByVal Type As String) As String
        Try
            Dim SQL, tare As String
            ContainerNo = ContainerNo.Replace(" ", "")
            SQL = "select CTN_ID From Container Where Container_no='" & ContainerNo & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            '--- 
            If Type = "20GP" Then
                tare = "2250"
            ElseIf Type = "40GP" Then
                tare = "6650"
            ElseIf Type = "40HC" Then
                tare = "3890"
            ElseIf Type = "40RH" Then
                tare = "5100"
            ElseIf Type = "20RF" Then
                tare = "3030"
            ElseIf Type = "20OT" Then
                tare = 2580
            ElseIf Type = "40OT" Then
                tare = 4290
            ElseIf Type = "20FR" Then
                tare = 2290
            ElseIf Type = "40FR" Then
                tare = 5870
            Else
                tare = 0
            End If
            '----
            If dt.Rows.Count = 0 Then
                Dim TempID As String = NewId()
                SQL = "Insert Into container(CTN_ID,Container_No,CTN_SIZE_TYPE,netweight) Values('" & TempID & "','" & ContainerNo & "','" & Type & "','" & tare & "')"
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
                cmd.CommandType = CommandType.Text
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
                Return TempID
            End If
            Return "{" & dt.Rows(0).Item(0).ToString & "}"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Return ""
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtFilename.Text.Trim = "" Then
            MsgBox("Click Browse to select The file to import")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Enter the sheet Name that you want import")
            Return
        End If
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
        Try

            'open excel File
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFilename.Text
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text.Trim)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            Dim strConnE As String
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            Conn = New OleDb.OleDbConnection(strConnE)
            'Conn.Open()
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] " 'Where F11<>''
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File

            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            Dim Currow As Integer = 8



            Currow = 1 ' dòng bắt đầu lấy dữ liệu
            For i As Integer = 10 To 1370 Step 6



                Dim TempBLID, TempBLID1 As String
                SQL = "Select * from chicilontoanha " 'Where BLIB_NO='" & BLNO & "'AND CONTINUED=1
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                rs.AddNew() '
                TempBLID = NewId() '  INSERT BILL

                rs.Fields("ID").Value = TempBLID ' 

                rs.Fields("Matoanha").Value = Currow.ToString & " " & UCase(ws.Range("A" & i).Value.ToString) & " " & UCase(ws.Range("F" & i).Value.ToString)

                rs.Fields("type").Value = "AIR"

                'End If
                If Not ws.Range("c" & i).Value Is Nothing Then
                    rs.Fields("tentoanha").Value = UCase(ws.Range("A" & i).Value.ToString) & " " & UCase(ws.Range("F" & i).Value.ToString) & " VI TRI " & UCase(ws.Range("D" & i).Value.ToString)
                End If

                If Not ws.Range("d" & i).Value Is Nothing Then
                    rs.Fields("tentiengviet").Value = UCase(ws.Range("A" & i).Value.ToString) & " " & UCase(ws.Range("F" & i).Value.ToString) & " VI TRI " & UCase(ws.Range("D" & i).Value.ToString)
                End If

                If Not ws.Range("e" & i).Value Is Nothing Then
                    rs.Fields("diachi").Value = ws.Range("B" & i).Value.ToString
                End If



                If Not ws.Range("f" & i).Value Is Nothing Then
                    rs.Fields("quan").Value = ws.Range("B" & i).Value.ToString
                End If
                If Not ws.Range("g" & i).Value Is Nothing Then
                    rs.Fields("thangmay").Value = ""
                End If

                If Not ws.Range("h" & i).Value Is Nothing Then
                    rs.Fields("sotang").Value = ""
                End If

                If Not ws.Range("i" & i).Value Is Nothing Then
                    rs.Fields("luuluongnguoi").Value = ""
                End If


                rs.Fields("thanhpho").Value = ws.Range("B" & i).Value.ToString





                Currow += 1
                rs.Update()
                rs.Close()

            Next




            MsgBox("Complete : " & oTable.Rows.Count - 1 & " Containers")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
            app = Nothing
            Dim Pro() As Process
            Pro = Process.GetProcessesByName("EXCEL")
            If Pro.Length > 0 Then
                Pro(0).Kill()
            End If

            Conn.Close()
            Conn = Nothing
            'Conn.Dispose()
        End Try
    End Sub

    Private Sub frmInputDataListEquipMentControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txtFilename.Text.Trim = "" Then
            MsgBox("Click Browse to select The file to import")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Enter the sheet Name that you want import")
            Return
        End If
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
        Try

            'open excel File
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFilename.Text
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text.Trim)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            Dim strConnE As String
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            Conn = New OleDb.OleDbConnection(strConnE)
            'Conn.Open()
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] " 'Where F11<>''
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File

            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            Dim Currow As Integer = 8
            'While IsNothing(ws.Range("A" & Currow).Value)
            '    Currow += 1
            'End While
            'While Not (UCase(ws.Range("A" & Currow).Value.ToString) Like "*NO.*")
            '    Currow += 1
            'End While


            Currow = 1 ' dòng bắt đầu lấy dữ liệu
            For i As Integer = 6 To oTable.Rows.Count - 1

                'BLNO = ws.Range("B" & Currow).Value.ToString.Trim

                'If BLNO = "DITTO" Then
                '    BLNO = BLNOTemp
                'Else
                '    BLNO = ws.Range("B" & Currow).Value.ToString.Trim
                'End If

                'BLNOTemp = BLNO
                If Currow = 120 Then
                    DisplayMessage(True, "")
                End If
                If Not ws.Range("d" & i).Value Is Nothing Then


                    Dim TempBLID, TempBLID1 As String
                    SQL = "Select * from chicilonkhachhang Where tencongty  like N'%" & ws.Range("d" & i).Value.ToString & "%' "
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If rs.EOF Then
                        rs.AddNew() '
                        TempBLID = NewId() '  INSERT BILL

                        rs.Fields("ID").Value = TempBLID ' 


                        rs.Fields("Makhachhang").Value = Currow
                        'End If
                        If Not ws.Range("d" & i).Value Is Nothing Then
                            rs.Fields("tencongty").Value = ws.Range("d" & i).Value.ToString
                        End If
                        If Not ws.Range("e" & i).Value Is Nothing Then
                            rs.Fields("nguoilienhe").Value = ws.Range("e" & i).Value.ToString
                        End If
                        If Not ws.Range("i" & i).Value Is Nothing Then
                            rs.Fields("dienthoai").Value = ws.Range("i" & i).Value.ToString
                        End If
                        If Not ws.Range("j" & i).Value Is Nothing Then
                            rs.Fields("fax").Value = ws.Range("j" & i).Value.ToString
                        End If
                        Currow += 1
                        rs.Update()

                    End If
                    rs.Close()
                End If

            Next




            MsgBox("Complete : " & oTable.Rows.Count - 1 & " Containers")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
            app = Nothing
            Dim Pro() As Process
            Pro = Process.GetProcessesByName("EXCEL")
            If Pro.Length > 0 Then
                Pro(0).Kill()
            End If

            Conn.Close()
            Conn = Nothing
            'Conn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.txtFilename.Text.Trim = "" Then
            MsgBox("Click Browse to select The file to import")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Enter the sheet Name that you want import")
            Return
        End If
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
        Try

            'open excel File
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFilename.Text
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text.Trim)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            Dim strConnE As String
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            Conn = New OleDb.OleDbConnection(strConnE)
            'Conn.Open()
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] " 'Where F11<>''
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File

            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            Dim Currow As Integer = 8
            'While IsNothing(ws.Range("A" & Currow).Value)
            '    Currow += 1
            'End While
            'While Not (UCase(ws.Range("A" & Currow).Value.ToString) Like "*NO.*")
            '    Currow += 1
            'End While
            Dim sohopdongcu, sohopdongmoi, hopdongid, hopdongmoiid, toanhaid, khachhangid, kenhid, hopdongcu, hopdongtoanhaid As String
            Dim nguoiphutrachid As String = "7a7914b0-d88d-4855-9cf2-d5670a00427a"
            Currow = 1 ' dòng bắt đầu lấy dữ liệu
            For i = 1 To oTable.Rows.Count - 1
                'If sohopdongcu <> ws.Range("b" & i).Value.ToString Then
                If i = 44 Then


                    DisplayMessage(True, "")
                End If
                shd = ws.Range("b" & i).Value.ToString
                ' lay dong dau
                '----------------------------------------------------
                ' chen vo Hop dong lay Toa nha
                SQL = "Select * from chicilontoanha where tentoanha like N'%" & ws.Range("f" & i).Value.ToString & "%' and diachi like N'%" & ws.Range("g" & i).Value.ToString & "%' "
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                If Not rs.EOF Then
                    toanhaid = rs.Fields("ID").Value
                End If

                rs.Close()
                '----------lay Khachhang
                If Not ws.Range("d" & i).Value Is Nothing Then


                    SQL = "Select * from chicilonkhachhang Where tencongty  like N'%" & ws.Range("d" & i).Value.ToString & "%' "
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If Not rs.EOF Then
                        'rs.AddNew() '
                        khachhangid = rs.Fields("ID").Value 'NewId() '  INSERT BILL
                        rs.Close()
                    Else
                        khachhangid = DefaultValue
                    End If
                Else
                    khachhangid = DefaultValue
                End If
                '------------------------------------------------------------------
                ''' lay kenh
                ''' 
                SQL = "Select * from chicilonkenh Where Makenh like N'%" & ws.Range("c" & i).Value.ToString & "%'"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then


                    rs.AddNew() '
                    kenhid = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = kenhid ' 

                    If Not ws.Range("c" & i).Value Is Nothing Then
                        rs.Fields("Makenh").Value = ws.Range("c" & i).Value.ToString

                        'End If

                        rs.Fields("tenkenh").Value = ws.Range("c" & i).Value.ToString
                    End If
                    rs.Update()
                End If
                kenhid = rs.Fields("ID").Value

                rs.Close()
                '--------------------------------------------------------
                ' chen vo hop dong

                SQL = "Select * from chicilonhopdong Where sohopdong='" & ws.Range("b" & i).Value.ToString & "'"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then


                    rs.AddNew() '
                    hopdongid = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = hopdongid ' 

                    rs.Fields("BranchID").Value = "{a03618f9-f928-4d5a-ab74-831ac4815f8c}" ' 
                    rs.Fields("DepartmentID").Value = "{ae15d64c-867a-4dd7-8303-24a1c0c00d8e}"
                    rs.Fields("officeID").Value = "{36fc6e1d-8a70-48c0-bf81-83771f21a832}"
                    If Not ws.Range("b" & i).Value Is Nothing Then
                        rs.Fields("sohopdong").Value = ws.Range("b" & i).Value.ToString
                        'sohopdongcu = ws.Range("b" & i).Value.ToString
                    End If
                    'End If
                    'rs.Fields("loaihopdong").Value = kenhid ' 


                    'If Not ws.Range("c" & i).Value Is Nothing Then
                    '    rs.Fields("tenkenh").Value = ws.Range("c" & i).Value.ToString
                    'End If



                    rs.Fields("kenhid").Value = kenhid

                    rs.Fields("khachhangid").Value = khachhangid ' 


                    If Not ws.Range("e" & i).Value Is Nothing Then
                        rs.Fields("tenchucvunguoikyhopdong").Value = ws.Range("e" & i).Value.ToString
                    End If



                    If Not ws.Range("k" & i).Value Is Nothing Then
                        rs.Fields("NguoiLienHe").Value = ws.Range("k" & i).Value.ToString
                    End If

                    'If Not ws.Range("l" & i).Value Is Nothing Then
                    '    rs.Fields("sophong").Value = ws.Range("l" & i).Value.ToString
                    'End If
                    'If Not ws.Range("n" & i).Value Is Nothing Then
                    '    rs.Fields("thangmay").Value = ws.Range("n" & i).Value.ToString
                    'End If
                    'If Not ws.Range("o" & i).Value Is Nothing Then
                    '    rs.Fields("block").Value = ws.Range("o" & i).Value.ToString
                    'End If
                    'If Not ws.Range("p" & i).Value Is Nothing Then
                    '    rs.Fields("dientichsan").Value = ws.Range("P" & i).Value.ToString
                    'End If
                    'If Not ws.Range("q" & i).Value Is Nothing Then
                    '    rs.Fields("luongnguoi").Value = ws.Range("Q" & i).Value.ToString
                    'End If
                    If Not ws.Range("r" & i).Value Is Nothing Then
                        If UCase(ws.Range("r" & i).Value.ToString) = "CHỜ PHỤ LỤC" Or ws.Range("r" & i).Value.ToString = "" Then
                            rs.Fields("ngaybatdau").Value = ""
                        Else
                            rs.Fields("ngaybatdau").Value = ws.Range("R" & i).Value.ToString
                        End If

                    Else
                        rs.Fields("ngaybatdau").Value = ""
                    End If

                    If Not ws.Range("s" & i).Value Is Nothing Then
                        If UCase(ws.Range("s" & i).Value.ToString) = "CHỜ PHỤ LỤC" Or ws.Range("s" & i).Value.ToString = "" Then
                            rs.Fields("ngayketthuc").Value = ""
                        Else
                            rs.Fields("ngayketthuc").Value = ws.Range("s" & i).Value.ToString
                        End If


                    Else
                        rs.Fields("ngayketthuc").Value = ""
                    End If
                    If Not ws.Range("u" & i).Value Is Nothing Then
                        rs.Fields("phuongthucthanhtoan").Value = ws.Range("u" & i).Value.ToString
                    End If

                    If Not ws.Range("t" & i).Value Is Nothing Then
                        rs.Fields("sonamhopdong").Value = ws.Range("t" & i).Value.ToString
                    End If
                    'If ws.Range("x" & i).Value Is Nothing Then
                    '    If Not ws.Range("w" & i).Value Is Nothing Then
                    rs.Fields("Songaythongbaohethan").Value = 90
                    '    End If

                    'Else
                    '    If Not ws.Range("w" & i).Value Is Nothing Then
                    '        rs.Fields("DonGiaThangUSDLCD").Value = ws.Range("w" & i).Value.ToString
                    '    End If

                    'End If
                    'If Not ws.Range("w" & i).Value Is Nothing Then
                    '    rs.Fields("DonGiaThangUSDLCD").Value = ws.Range("w" & i).Value.ToString
                    'End If
                    If Not ws.Range("v" & i).Value Is Nothing Then
                        rs.Fields("SoluongtheoHDLCD").Value = ws.Range("v" & i).Value.ToString
                    End If
                    If Not ws.Range("w" & i).Value Is Nothing Then
                        rs.Fields("SoluongtheoHDPANO").Value = ws.Range("w" & i).Value.ToString
                    End If
                    If Not ws.Range("x" & i).Value Is Nothing Then
                        rs.Fields("SOluongthuclapLCD").Value = ws.Range("x" & i).Value.ToString
                    End If
                    If Not ws.Range("y" & i).Value Is Nothing Then
                        rs.Fields("SOluongthuclappano").Value = ws.Range("y" & i).Value.ToString
                    End If
                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                    End If
                    If Not ws.Range("at" & i).Value Is Nothing Then
                        rs.Fields("ngayhoantatlap").Value = ws.Range("at" & i).Value.ToString
                    End If
                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("motavitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                Else
                    ' neu da co hopdong
                    hopdongid = rs.Fields("ID").Value.ToString

                End If

                rs.Update()
                rs.Close()
                '-----------------

                'End If
                ' van con giu hongdongid, toanhaid


                SQL = "Select * from chicilonhopdongtoanha " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                rs.AddNew() '
                hopdongtoanhaid = NewId() '  INSERT BILL

                rs.Fields("ID").Value = hopdongtoanhaid ' 

                rs.Fields("hopdongid").Value = hopdongid
                rs.Fields("toanhaid").Value = toanhaid

                If Not ws.Range("h" & i).Value Is Nothing Then
                    rs.Fields("khuvuc").Value = ws.Range("h" & i).Value.ToString
                End If

                If Not ws.Range("k" & i).Value Is Nothing Then
                    rs.Fields("nguoilienhe").Value = ws.Range("k" & i).Value.ToString
                End If
                'If Not ws.Range("k" & i).Value Is Nothing Then
                '    rs.Fields("nguoilienhe").Value = ws.Range("k" & i).Value.ToString
                'End If

                If Not ws.Range("l" & i).Value Is Nothing Then
                    rs.Fields("sophong").Value = ws.Range("l" & i).Value.ToString
                End If
                If Not ws.Range("m" & i).Value Is Nothing Then
                    rs.Fields("sotang").Value = ws.Range("m" & i).Value.ToString
                End If
                If Not ws.Range("n" & i).Value Is Nothing Then
                    rs.Fields("thangmay").Value = ws.Range("n" & i).Value.ToString
                End If
                If Not ws.Range("o" & i).Value Is Nothing Then
                    rs.Fields("block").Value = ws.Range("o" & i).Value.ToString
                End If
                If Not ws.Range("p" & i).Value Is Nothing Then
                    rs.Fields("dientichsan").Value = ws.Range("P" & i).Value.ToString
                End If
                If Not ws.Range("q" & i).Value Is Nothing Then
                    rs.Fields("luongnguoi").Value = ws.Range("Q" & i).Value.ToString
                End If

                If Not ws.Range("v" & i).Value Is Nothing Then
                    rs.Fields("soluongtheohdlcd").Value = ws.Range("v" & i).Value.ToString
                End If

                If Not ws.Range("w" & i).Value Is Nothing Then
                    rs.Fields("soluongtheohdpano").Value = ws.Range("w" & i).Value.ToString
                End If
                If Not ws.Range("x" & i).Value Is Nothing Then
                    rs.Fields("SOluongthuclapLCD").Value = ws.Range("x" & i).Value.ToString
                End If

                If Not ws.Range("y" & i).Value Is Nothing Then
                    rs.Fields("SOluongthuclappano").Value = ws.Range("y" & i).Value.ToString
                End If



                rs.Update()
                rs.Close()
                ' ta can cu vao hopdongtoanhaid ta them vao chitietlap dat
                'panoda
                If ws.Range("b" & i).Value.ToString = "52/05/2010" Then



                    'DisplayMessage(True, "")
                End If
                Dim chitietiD As String
                If Not ws.Range("z" & i).Value Is Nothing Then


                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{6c703f4a-836a-4c88-96b9-ec6e55432f98}"
                    rs.Fields("loaithietbi").Value = "PANO"
                    If Not ws.Range("z" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("z" & i).Value.ToString
                    End If

                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If


                    rs.Update()
                    rs.Close()
                End If


                '-------------------------------------------------------------

                ' ta can cu vao hopdongtoanhaid ta them vao chitietlap dat
                'panonhom
                'Dim chitietiD As String
                If Not ws.Range("AA" & i).Value Is Nothing Then


                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{802f7338-d34b-41d6-b550-676e3fc7c520}"
                    rs.Fields("loaithietbi").Value = "PANO"
                    If Not ws.Range("AA" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AA" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()

                End If

                '-------------------------------------------------------------

                ' ta can cu vao hopdongtoanhaid ta them vao chitietlap dat
                'panodien
                'Dim chitietiD As String
                If Not ws.Range("AB" & i).Value Is Nothing Then
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{cd38ff79-3117-42cc-b487-c9254aad94b1}"
                    rs.Fields("loaithietbi").Value = "PANO"
                    If Not ws.Range("AB" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AB" & i).Value.ToString
                    End If




                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()

                End If

                '-------------------------------------------------------------


                '-------------------------------------------------------------

                ' ta can cu vao hopdongtoanhaid ta them vao chitietlap dat
                'lcd 10'
                'Dim chitietiD As String
                If Not ws.Range("AC" & i).Value Is Nothing Then


                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{ea37685f-917d-4edb-af78-be8c6e29b826}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AC" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AC" & i).Value.ToString
                    End If


                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()
                End If


                '-------------------------------------------------------------
                '-------------------------------------------------------------

                ' ta can cu vao hopdongtoanhaid ta them vao chitietlap dat
                'lcd 17' bus
                'Dim chitietiD As String
                If Not ws.Range("AD" & i).Value Is Nothing Then
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{d5036745-b344-41fe-9708-8a6b094360d1}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AD" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AD" & i).Value.ToString
                    End If


                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If



                    rs.Update()
                    rs.Close()
                End If
                If Not ws.Range("AE" & i).Value Is Nothing Then


                    'lcd 17' TC
                    'Dim chitietiD As String
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{b9ef0e30-5959-49a6-8137-dd46f4f3f1a6}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AE" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AE" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                End If
                'lcd 17'DC
                'Dim chitietiD As String
                If Not ws.Range("Af" & i).Value Is Nothing Then




                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{88f0f714-9fa5-4cad-9a08-afc033b304b9}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AF" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AF" & i).Value.ToString
                    End If




                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()
                End If

                'lcd 17 tm
                'Dim chitietiD As String
                If Not ws.Range("Ag" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{adff2fb1-4a72-4669-843f-1a9f08b85a0d}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AG" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AG" & i).Value.ToString
                    End If


                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                End If

                If Not ws.Range("Ah" & i).Value Is Nothing Then



                    'lcd 17 dm
                    'Dim chitietiD As String
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{712c1c71-c066-42c4-9977-ce556959c5fa}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AH" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AH" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If


                    rs.Update()
                    rs.Close()
                End If
                If Not ws.Range("Ai" & i).Value Is Nothing Then



                    'lcd 19------------------------------------------------------------------------------------------------------------------------
                    'Dim chitietiD As String
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{9dc33019-2cca-4bdb-8721-040d41770cce}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AI" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AI" & i).Value.ToString
                    End If





                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                    '----------------------------------------------------------------------------------------------------------------------------------------
                End If
                If Not ws.Range("Aj" & i).Value Is Nothing Then



                    'lcd 20------------------------------------------------------------------------------------------------------------------------
                    'Dim chitietiD As String
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{1ce32f83-69b7-4b36-a7ce-bf9e2ab0567b}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("Aj" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Aj" & i).Value.ToString
                    End If





                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()
                    '----------------------------------------------------------------------------------------------------------------------------------------
                End If
                If Not ws.Range("Ak" & i).Value Is Nothing Then



                    'lcd 24------------------------------------------------------------------------------------------------------------------------
                    'Dim chitietiD As String
                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{93e0c40d-047d-4bf0-bd0c-5819f3921058}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("Ak" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Ak" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If


                    rs.Update()
                    rs.Close()
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------
                'lcd 26------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String
                If Not ws.Range("Al" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{e29a851b-72d4-429a-b5a2-765d60656ff0}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("Al" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Al" & i).Value.ToString
                    End If




                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------
                '----------------------------------------------------------------------------------------------------------------------------------------
                'lcd 32------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String
                If Not ws.Range("Am" & i).Value Is Nothing Then


                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{883234d8-6b93-4508-9a85-853603a8cf11}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("Am" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Am" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------
                '----------------------------------------------------------------------------------------------------------------------------------------
                'lcd 32LG------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String
                If Not ws.Range("An" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{87c1122f-5be6-4110-ab6a-d4690c0ce70b}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AN" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AN" & i).Value.ToString
                    End If




                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------

                'lcd 42------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String

                If Not ws.Range("Ao" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{663b47c7-2c4d-4947-a923-3522b56884b1}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("Ao" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Ao" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                    '----------------------------------------------------------------------------------------------------------------------------------------
                End If
                'lcd 42LG------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String
                If Not ws.Range("Ap" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{c79d28c7-8a54-4e6e-b35c-aba1f10903da}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("AP" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("AP" & i).Value.ToString
                    End If





                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                End If
                '----------------------------------------------------------------------------------------------------------------------------------------
                '47inch------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String
                If Not ws.Range("Aq" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{e36158d2-cfb0-4620-ae65-a77d5a00c98e}"
                    rs.Fields("loaithietbi").Value = "LCD"
                    If Not ws.Range("Aq" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Aq" & i).Value.ToString
                    End If




                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If
                    rs.Update()
                    rs.Close()
                End If
                'lcd daudoc------------------------------------------------------------------------------------------------------------------------
                'Dim chitietiD As String
                If Not ws.Range("Ar" & i).Value Is Nothing Then



                    SQL = "Select * from chicilonchitietthuclaphopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                    rs.AddNew() '
                    chitietiD = NewId() '  INSERT BILL

                    rs.Fields("ID").Value = chitietiD
                    rs.Fields("hopdongtoanhaid").Value = hopdongtoanhaid ' 

                    rs.Fields("thietbiid").Value = "{a9753d37-af86-4013-9035-b7256c8367ba}"
                    rs.Fields("loaithietbi").Value = "DDT"
                    If Not ws.Range("Ar" & i).Value Is Nothing Then
                        rs.Fields("soluongthuclap").Value = ws.Range("Ar" & i).Value.ToString
                    End If



                    If Not ws.Range("as" & i).Value Is Nothing Then
                        rs.Fields("ghichu").Value = ws.Range("as" & i).Value.ToString
                        If Not ws.Range("at" & i).Value Is Nothing Then
                            rs.Fields("ghichu").Value += ";  " + ws.Range("at" & i).Value.ToString
                        End If
                    End If


                    If Not ws.Range("au" & i).Value Is Nothing Then
                        rs.Fields("vitrilap").Value = ws.Range("au" & i).Value.ToString
                    End If

                    rs.Update()
                    rs.Close()
                    '----------------------------------------------------------------------------------------------------------------------------------------
                End If



                ' tu day ta chen vo thuclap
                '----------------------------------
                'SQL = "Select * from chicilonchitietthuclaphopdonghopdong " 'Where sohopdong='" & sohopdongcu & "'AND CONTINUED=1"
                'rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                'rs.AddNew() '
                'hopdongtoanhaid = NewId() '  INSERT BILL

                'rs.Fields("ID").Value = hopdongtoanhaid ' 

                'rs.Fields("hopdongid").Value = hopdongid
                'rs.Fields("toanhaid").Value = toanhaid

                'If Not ws.Range("h" & i).Value Is Nothing Then
                '    rs.Fields("khuvuc").Value = ws.Range("h" & i).Value.ToString
                'End If
                '-----------------------------------







                Currow += 1
            Next




            MsgBox("Complete : " & oTable.Rows.Count - 1 & " Containers")
        Catch ex As Exception
            DisplayMessage(True, Err.Description + shd + i)
        Finally
            app.Quit()
            app = Nothing
            Dim Pro() As Process
            Pro = Process.GetProcessesByName("EXCEL")
            If Pro.Length > 0 Then
                Pro(0).Kill()
            End If

            Conn.Close()
            Conn = Nothing
            'Conn.Dispose()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.txtFilename.Text.Trim = "" Then
            MsgBox("Click Browse to select The file to import")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Enter the sheet Name that you want import")
            Return
        End If
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
        Try

            'open excel File
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFilename.Text
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text.Trim)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            '''''''''''''''''''''''''''''''''''''''''''
            'Dim strConnE As String
            'strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            'Conn = New OleDb.OleDbConnection(strConnE)
            ''Conn.Open()
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] " 'Where F11<>''
            'Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            'Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            'Dim oTable As New DataTable
            'Adapter.Fill(oTable)
            ''Me.DataGridView1.DataSource = oTable
            ''open Excel File

            ''Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            'Dim Currow As Integer = 8



            'Currow = 1 ' dòng bắt đầu lấy dữ liệu
            'Dim ds As New DataSet
            'Dim sql1, khid, cot As String
            'Dim ngaybd, ngaykt, sl As String
            ''cot = "bv"
            'ngaybd = ws.Range(cot + "4").Value.ToString
            'ngaykt = ws.Range(cot + "5").Value.ToString

            'sql1 = "Select * from chicilonkhachhang  Where tencongty='" & ws.Range(cot + "3").Value.ToString & "' AND CONTINUED=1"
            'ds = ReadDataSet(sql1)
            'Dim toanhaid, nvID As String

            'nvID = "{" + "60948002-18b2-4cb8-bcbf-a1ad52593bf6" + "}"
            'If ds.Tables(0).Rows.Count > 0 Then
            '    khid = ds.Tables(0).Rows(0).Item("id").ToString
            'End If

            For i As Integer = 400 To 999

                'If Not ws.Range(cot & i).Value Is Nothing Then
                ' lay id ta nha
                'Dim sqltn As String
                'Dim dstn As New DataSet

                'sqltn = "select id from chicilontoanha where tentoanha='" & ws.Range("c" & i).Value.ToString & "' and continued=1"
                'dstn = ReadDataSet(sqltn)
                'toanhaid = "{" + dstn.Tables(0).Rows(0).Item("id").ToString + "}"

                ''-------------------
                'Dim sql2, tnpnID As String
                'Dim ds2 As New DataSet
                'sql2 = " select chicilontoanhapano.id  as tnpnID from chicilontoanhapano where  toanhaid= '" & toanhaid & "' and chicilontoanhapano.continued=1 "

                'ds2 = ReadDataSet(sql2)
                'If ds2.Tables(0).Rows.Count > 0 Then
                '    tnpnID = "{" + ds2.Tables(0).Rows(0).Item("tnpnid").ToString + "}"
                'End If

                Dim TempBLID, TempBLID1 As String
                SQL = "Select * from bookingonline " '  Where id='" & ws.Range("c" & i).Value.ToString & "' AND CONTINUED=1"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If rs.EOF Then
                rs.AddNew() '
                TempBLID = NewId() '  INSERT BILL

                'rs.Fields("ID").Value = TempBLID ' 




                'rs.Fields("nhanvienid").Value = nvID
                'rs.Fields("KhachhangID").Value = "{" + khid + "}"
                'rs.Fields("toanhaPanoID").Value = tnpnID
                ''End If

                'rs.Fields("ngaybatdau").Value = ngaybd
                'rs.Fields("ngayketthuc").Value = ngaykt
                'rs.Fields("price").Value = "0"

                '  rs.Fields("Matoanha").Value = Currow

                'rs.Fields("type").Value = ws.Range("b" & i).Value.ToString

                'End If
                'If Not ws.Range("v" & i).Value Is Nothing Then
                rs.Fields("autonumber1").Value = i.ToString
                rs.Fields("continued").Value = 1
                'End If
                'rs.Fields("ghichu").Value = ""
                'If Not ws.Range("p" & i).Value Is Nothing Then
                '    rs.Fields("loai").Value = "Lighting"
                'End If
                'If Not ws.Range("o" & i).Value Is Nothing Then
                '    rs.Fields("loai").Value = "Normal"
                'End If

                'If Not ws.Range("m" & i).Value Is Nothing Then
                '    rs.Fields("vitri").Value = "Indise"
                'End If
                'If Not ws.Range("n" & i).Value Is Nothing Then
                '    rs.Fields("vitri").Value = "Outside"
                'End If







                ' Currow += 1
                rs.Update()
                rs.Close()

                'Else



                'End If



            Next




            'MsgBox("Complete : " & oTable.Rows.Count - 1 & " Containers")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
            app = Nothing
            Dim Pro() As Process
            Pro = Process.GetProcessesByName("EXCEL")
            If Pro.Length > 0 Then
                Pro(0).Kill()
            End If

            Conn.Close()
            Conn = Nothing
            'Conn.Dispose()
        End Try


    End Sub
    Function getCusID() As String
        Dim strSQL As String
        strSQL = "select count (*) as ID from customer "
        Dim dtSer As New DataTable
        dtSer = ReadTable(strSQL)
        Return CInt(dtSer.Rows(0).Item(0).ToString)


    End Function
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.txtFilename.Text.Trim = "" Then
            MsgBox("Click Browse to select The file to import")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Enter the sheet Name that you want import")
            Return
        End If
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
        Try

            'open excel File
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFilename.Text
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text.Trim)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            Dim strConnE As String
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            Conn = New OleDb.OleDbConnection(strConnE)
            'Conn.Open()
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] " 'Where F11<>''
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File

            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            Dim Currow As Integer = 8

            Currow = 1 ' dòng bắt đầu lấy dữ liệu
            Dim ds As New DataSet
            Dim sql1 As String
            For i As Integer = 1 To 8270
                If IsNothing(ws.Range("a" & i).Value) = False Then
                    ' tach chuoi


                    'If ws.Range("a" & i).Value.ToString = "-" And ws.Range("b" & i).Value.ToString = "-" And ws.Range("c" & i).Value.ToString = "-" Then

                    'Else


                    '----------------------------
                    Me.Text = i.ToString
                    Dim seri As Integer
                    Dim temp As String = ""

                    seri = CDbl(getCusID()) + 1
                    For h As Integer = seri.ToString.Length To 5
                        temp &= "0"
                    Next
                    temp &= seri
                    '=======================================
                    Dim TempBLID, TempBLID1 As String
                    SQL = "Select top 1 * from customer " ' Where taxcode='" & ws.Range("a" & i).Value.ToString.Trim & "'"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    'If rs.EOF Then
                    rs.AddNew() '
                    TempBLID = NewId() '  INSERT BILL

                    rs.Fields("customer_id").Value = TempBLID ' 
                    rs.Fields("customer_code").Value = temp '
                    rs.Fields("maincode").Value = "KH-HPH"
                    rs.Fields("taxCode").Value = ws.Range("a" & i).Value.ToString.Trim
                    'End If


                    rs.Fields("EnglishName").Value = ws.Range("b" & i).Value


                    Dim tam1 As String = ws.Range("d" & i).Value.ToString.Replace("TONG CONG TY", "").Replace("CONG TY CO PHAN", "").Replace("CONG TY CP DV GN VT ", "").Replace("CONG TY CP DAU TU", "").Replace("CONG TY CP", "").Replace("CONG TY TNHH", "").Replace("CHI NHANH", "").Replace("CN", "").Replace("CTY TNHH", "").Replace("CTY", "").Replace("DNTN", "").Replace("CO PHAN", "").Replace("XI NGHIEP", "")

                    rs.Fields("company").Value = tam1.Trim

                    ' rs.Fields("Remarks_sale").Value = ws.Range("f" & i).Value
                    ' rs.Fields("tel").Value = ws.Range("g" & i).Value
                    '  rs.Fields("fax").Value = ws.Range("e" & i).Value

                    'rs.Fields("sotaikhoan").Value = ""
                    'rs.Fields("district").Value = ws.Range("n" & i).Value
                    Try
                        rs.Fields("addresstiengviet").Value = ws.Range("c" & i).Value
                        rs.Fields("address").Value = ws.Range("c" & i).Value
                    Catch ex As Exception

                    End Try


                    rs.Fields("branch").Value = "HPH"



                    '  Currow += 1
                    rs.Update()
                    rs.Close()
                    'End If
                End If


            Next




            MsgBox("Complete : " & oTable.Rows.Count - 1 & " Containers")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
            app = Nothing
            Dim Pro() As Process
            Pro = Process.GetProcessesByName("EXCEL")
            If Pro.Length > 0 Then
                Pro(0).Kill()
            End If

            Conn.Close()
            Conn = Nothing
            'Conn.Dispose()
        End Try



    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Me.txtFilename.Text.Trim = "" Then
            MsgBox("Click Browse to select The file to import")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Enter the sheet Name that you want import")
            Return
        End If
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
        Try

            'open excel File
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = Me.txtFilename.Text
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text.Trim)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''
            Dim strConnE As String
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFilename.Text & "; Extended Properties=""Excel 8.0;HDR=no;"""
            Conn = New OleDb.OleDbConnection(strConnE)
            'Conn.Open()
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] " 'Where F11<>''
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File

            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            Dim Currow As Integer = 8
            'While IsNothing(ws.Range("A" & Currow).Value)
            '    Currow += 1
            'End While
            'While Not (UCase(ws.Range("A" & Currow).Value.ToString) Like "*NO.*")
            '    Currow += 1
            'End While


            Currow = 1 ' dòng bắt đầu lấy dữ liệu
            Dim ds As New DataSet
            Dim sql1 As String
            For i As Integer = 6 To 424
                'BLNO = ws.Range("B" & Currow).Value.ToString.Trim
                '  lay id toa nha
                sql1 = "Select * from chicilontoanha  Where tentoanha='" & ws.Range("c" & i).Value.ToString & "' AND CONTINUED=1"
                ds = ReadDataSet(sql1)
                Dim toanhaid As String


                If ds.Tables(0).Rows.Count > 0 Then
                    toanhaid = ds.Tables(0).Rows(0).Item("id").ToString
                End If
                'If BLNO = "DITTO" Then
                '    BLNO = BLNOTemp
                'Else
                '    BLNO = ws.Range("B" & Currow).Value.ToString.Trim
                'End If

                'BLNOTemp = BLNO
                Dim TempBLID, TempBLID1 As String
                SQL = "Select * from chicilontoanhapano   Where toanhaid='" & toanhaid & "' AND CONTINUED=1"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If rs.EOF Then
                'rs.AddNew() '
                TempBLID = NewId() '  INSERT BILL

                'rs.Fields("ID").Value = TempBLID ' 

                'rs.Fields("toanhaid").Value = "{" + toanhaid + "}" '           
                'End If

                'rs.Fields("thietbiid").Value = "{001f6797-7d07-4c4b-8890-029fc352662b}" '    

                '  rs.Fields("Matoanha").Value = Currow

                'rs.Fields("type").Value = ws.Range("b" & i).Value.ToString

                'End If
                'If Not ws.Range("j" & i).Value Is Nothing Then
                rs.Fields("giatien").Value = ws.Range("q" & i).Value.ToString
                'End If

                'If Not ws.Range("p" & i).Value Is Nothing Then
                '    rs.Fields("loai").Value = "Lighting"
                'End If
                'If Not ws.Range("o" & i).Value Is Nothing Then
                '    rs.Fields("loai").Value = "Normal"
                'End If

                'If Not ws.Range("m" & i).Value Is Nothing Then
                '    rs.Fields("vitri").Value = "Indise"
                'End If
                'If Not ws.Range("n" & i).Value Is Nothing Then
                '    rs.Fields("vitri").Value = "Outside"
                'End If







                Currow += 1
                rs.Update()
                rs.Close()

            Next




            MsgBox("Complete : " & oTable.Rows.Count - 1 & " Containers")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
            app = Nothing
            Dim Pro() As Process
            Pro = Process.GetProcessesByName("EXCEL")
            If Pro.Length > 0 Then
                Pro(0).Kill()
            End If

            Conn.Close()
            Conn = Nothing
            'Conn.Dispose()
        End Try



    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim fr As StreamReader
        Try
            fr = New StreamReader(Me.txtFilename.Text)
            Dim temp As String

            temp = fr.ReadLine()


            While Not temp Like "the end"
                ' xu ly dong 1
                If temp <> "" Then
                    '
                    Dim ctemp() As String = temp.Split(" ")
                    sql = "Select * from port   Where port_code="" AND CONTINUED=1"
                    rs.Open(sql, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If rs.EOF Then
                        rs.AddNew() '
                    End If
                End If

                temp = fr.ReadLine()




            End While
        Catch ex As Exception

        End Try
    End Sub
End Class