Public Class frmCheckContainerManagerment
    Dim ExcelDt As New DataTable
    'Dim oTableContainer As New DataTable
    Private Sub frmCheckContainerManagerment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grbProcess.Visible = False
        Me.txtSheetName.Text = "Sheet1"
        SetDefaultGrid(Me.DataGridView1, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim ConnExcel As New OleDb.OleDbConnection()

        Try
            If Me.txtFilename.Text = "" Then
                MsgBox("The file name is invalid")
                Return
            End If
            If Me.txtSheetName.Text = "" Then
                MsgBox("This sheet Not belong to the file")
                Return
            End If

            Dim File As String = Me.OpenFileDialog1.FileName
            Dim strConnE, sheet As String
            Dim dt As New DataTable
            Dim CmdSelect As New OleDb.OleDbCommand
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & File & "; Extended Properties=""Excel 8.0;HDR=no;"""
            ConnExcel = New OleDb.OleDbConnection(strConnE)
            ConnExcel.Open()
            Dim strQuery As String
            If Me.chkPhucLong.Checked = False Then
                strQuery = "Select F1 As ICD,F4 as SoContainer ,F8 as PhuongAn,F12 as NgayThucHien,F13 as GioThucHien  From [" & Me.txtSheetName.Text.Trim & "$] Where F4<>'' And F4<>'socont'"
            Else
                strQuery = "Select F2 as SoContainer ,F5 as NgayThucHien  From [" & Me.txtSheetName.Text.Trim & "$] Where  F3<>'' And F3<>'Size'"
            End If
            Dim CmdExcel As New OleDb.OleDbCommand(strQuery, ConnExcel)
            Dim ApdapterExcel As New OleDb.OleDbDataAdapter(CmdExcel)
            ExcelDt.Clear()
            ApdapterExcel.Fill(ExcelDt) 'lấy dữ liệu trên Excel

            Me.DataGridView1.DataSource = ExcelDt
            InsertAutoNumberToGrid(Me.DataGridView1)

        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            ConnExcel.Close()
        End Try
    End Sub
    Public Sub Check(ByVal ExcelDt As DataTable)

       
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtFilename.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub chkPhucLong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhucLong.CheckedChanged
        If Me.chkPhucLong.Checked = True Then
            Me.GroupBox1.Enabled = True
        Else
            Me.GroupBox1.Enabled = False
        End If
    End Sub

    Sub CheckContainerStatus(ByVal fname As String, ByVal sheet As String)
        Dim i, h As Integer
        Dim conn As New OleDb.OleDbConnection()
        Try
            

            'đếm số container có trong file
            Dim strConnE As String
            Dim dt As New DataTable
            Dim CmdSelect As New OleDb.OleDbCommand
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & fname & "; Extended Properties=""Excel 8.0;HDR=no;"""
            conn = New OleDb.OleDbConnection(strConnE)
            conn.Open()
            Dim CmdCountBill As New OleDb.OleDbCommand("Select count(*) as Num from [" & Me.txtSheetName.Text.Trim & "$] Where F2<>''", conn)
            Dim ApdapterCountBill As New OleDb.OleDbDataAdapter(CmdCountBill)
            Dim dtCountContainer As New DataTable
            ApdapterCountBill.Fill(dtCountContainer)
            Dim CountContainer As String
            If Not IsNothing(dtCountContainer) Then
                CountContainer = dtCountContainer.Rows(0).Item("Num")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            conn.Close()
            Me.grbProcess.Visible = True
            Me.grbProcess.BringToFront()

            Me.pgbCheck.Value = 0
            Me.pgbCheck.Maximum = CountContainer + 2

            'If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            Dim app As New Excel.Application
            Dim Workbooks As Excel.Workbooks
            Workbooks = app.Workbooks
            Dim workbook As Excel.Workbook
            workbook = Workbooks.Open(fname)
            Dim sheets As Excel.Sheets
            sheets = workbook.Sheets
            Dim ws As Excel.Worksheet
            ws = sheets.Item(sheet)
            Dim count As Integer = 1
            Dim rs As New ADODB.Recordset
            Dim rsdepot As New ADODB.Recordset
            Try

                Dim SQL As String

                Dim CY() As String = {"CL", "ICD PL", "NP", "PL", "SADACO", "Z1", "VNT"}
                Dim CYdayDu() As String = {"CAT LAI", "PHUOC LONG", "NEW PORT", "PHUC LONG", "SADACO", "Z1", "VINATRANS"}
                h = 0
                i = 6
                Dim EndOfFile As Boolean = True
                While (1)  'nếu chưa hết file thì tiếp tục chạy 
                    Me.pgbCheck.Value += 1
                    'For Check As Integer = 1 To 28 'chạy trên một dòng xem dữ liệu có rỗng hay không
                    '    If Not IsNothing(ws.Range(Alpha(Check) & i).Value) Then
                    '        EndOfFile = False
                    '        Exit For
                    '    End If
                    'Next
                    'If EndOfFile = True Then
                    '    Exit While
                    'End If
                    Dim containerNo, BLNO As String
                    If IsNothing(ws.Range("B" & i).Value) Then
                        Exit While
                    End If
                    If IsNothing(ws.Range("C" & i).Value) Then
                        i += 1
                        Continue While
                    End If
                    containerNo = ws.Range("B" & i).Value

                    containerNo = Strings.Replace(containerNo, " ", "") '
                    BLNO = Strings.Replace(ws.Range("C" & i).Value.ToString, " ", "")


                    'If containerNo = "CCLU3903630" Then
                    '    DisplayMessage(True, "")
                    'End If

                    'BLNO = ws.Range("C" & i).Value  '
                    Dim InDB As Boolean = False
                    'For j As Integer = 0 To oTableContainer.Rows.Count - 1
                    'If containerNo Like oTableContainer.Rows(j).Item("Container_no").ToString.Trim Then
                    'If BLNO.Trim = oTableContainer.Rows(j).Item("BL_NO_INBOUND").ToString.Trim Then
                    InDB = True
                    SQL = "select * From CONTAINERMANAGERMENT where container_no = '" & containerNo & "' And BL_NO_Inbound='" & BLNO & "'"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("containermanagementid").Value = NewId()
                            .Fields("cargo_id").Value = DefaultValue
                            .Fields("cargoib_id").Value = DefaultValue
                            .Fields("bl_no_inbound").Value = BLNO 'ws.Range("C" & i).Value
                            .Fields("container_no").Value = containerNo 'ws.Range("B" & i).Value

                            .Fields("fullorempty").Value = ws.Range("F" & i).Value
                            .Fields("ts_ahr").Value = ws.Range("G" & i).Value
                            .Fields("POL_Code").Value = ws.Range("G" & i).Value
                            .Fields("vessel_inbound").Value = ws.Range("H" & i).Value
                            .Fields("voyno_inbound").Value = ws.Range("I" & i).Value
                            .Fields("arrival_date").Value = ws.Range("J" & i).Value
                            .Fields("discharge_date").Value = ws.Range("J" & i).Value


                        End If

                        Dim emptycy, importcy As String
                        emptycy = ""
                        importcy = ""
                        '----------------
                        Dim sqlDepot As String
                        If Not ws.Range("Q" & i).Value Is Nothing Then
                            sqlDepot = "select * From terminal where Code = '" & ws.Range("Q" & i).Value.ToString & "' And continued=1"
                            rsdepot.Open(sqlDepot, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            If Not rsdepot.EOF Then
                                emptycy = rsdepot.Fields("TerminalName").Value.ToString
                            End If
                            rsdepot.Close()
                        Else
                            emptycy = ""
                        End If

                        If Not ws.Range("L" & i).Value Is Nothing Then
                            sqlDepot = "select * From terminal where Code = '" & ws.Range("L" & i).Value.ToString & "' And continued=1"
                            rsdepot.Open(sqlDepot, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            If Not rsdepot.EOF Then
                                rsdepot.Fields("TerminalName").Value.ToString()
                            End If
                            rsdepot.Close()
                        Else

                            importcy = ""
                        End If

                        '-----------------
                        .Fields("conditionOfcontainerAt_MT_CY").Value = ws.Range("O" & i).Value
                        .Fields("ctn_size_type").Value = ws.Range("D" & i).Value.ToString.Replace("'", "").Trim & ws.Range("E" & i).Value.ToString.Trim
                        .Fields("factofdeldate").Value = ws.Range("M" & i).Value
                        .Fields("factofredeldate").Value = ws.Range("N" & i).Value
                        .Fields("emptyCY").Value = emptycy
                        .Fields("importcy").Value = importcy
                        .Fields("dateofemptycontainertoshipper").Value = ws.Range("S" & i).Value
                        .Fields("vanningdate").Value = ws.Range("T" & i).Value
                        .Fields("dateoffullloadcontainertocy").Value = ws.Range("U" & i).Value
                        .Fields("exportcy").Value = ws.Range("V" & i).Value
                        .Fields("dateofonboard").Value = ws.Range("W" & i).Value
                        If emptycy <> "" Then
                            .Fields("finalICD").Value = emptycy
                        Else
                            .Fields("finalICD").Value = importcy
                        End If

                        .Fields("ICDPort").Value = importcy
                        .Fields("Vessel_Outbound").Value = ws.Range("X" & i).Value

                        .Fields("Voyno_Outbound").Value = ws.Range("Y" & i).Value

                        If IsNothing(ws.Range("M" & i).Value) And IsNothing(ws.Range("N" & i).Value) And IsNothing(ws.Range("S" & i).Value) And IsNothing(ws.Range("U" & i).Value) And IsNothing(ws.Range("W" & i).Value) Then
                            .Fields("fullimport").Value = 1
                            .Fields("fulltoconsignee").Value = 0
                            .Fields("soundcontainer").Value = 0
                            .Fields("emptytoshipper").Value = 0
                            .Fields("fullexport").Value = 0
                        End If
                        If Not IsNothing(ws.Range("M" & i).Value) And IsNothing(ws.Range("N" & i).Value) And IsNothing(ws.Range("S" & i).Value) And IsNothing(ws.Range("U" & i).Value) And IsNothing(ws.Range("W" & i).Value) Then
                            .Fields("fulltoconsignee").Value = 1
                            .Fields("fullimport").Value = 0

                            .Fields("soundcontainer").Value = 0
                            .Fields("emptytoshipper").Value = 0
                            .Fields("fullexport").Value = 0
                        End If
                        If Not IsNothing(ws.Range("M" & i).Value) And Not IsNothing(ws.Range("N" & i).Value) And IsNothing(ws.Range("S" & i).Value) And IsNothing(ws.Range("U" & i).Value) And IsNothing(ws.Range("W" & i).Value) Then
                            .Fields("soundcontainer").Value = 1
                            .Fields("fullimport").Value = 0
                            .Fields("fulltoconsignee").Value = 0

                            .Fields("emptytoshipper").Value = 0
                            .Fields("fullexport").Value = 0
                        End If
                        If Not IsNothing(ws.Range("M" & i).Value) And Not IsNothing(ws.Range("N" & i).Value) And Not IsNothing(ws.Range("S" & i).Value) And IsNothing(ws.Range("U" & i).Value) And IsNothing(ws.Range("W" & i).Value) Then
                            .Fields("emptytoshipper").Value = 1
                            .Fields("fullimport").Value = 0
                            .Fields("fulltoconsignee").Value = 0
                            .Fields("soundcontainer").Value = 0

                            .Fields("fullexport").Value = 0
                        End If

                        If Not IsNothing(ws.Range("M" & i).Value) And Not IsNothing(ws.Range("N" & i).Value) And Not IsNothing(ws.Range("S" & i).Value) And Not IsNothing(ws.Range("U" & i).Value) And IsNothing(ws.Range("W" & i).Value) Then
                            .Fields("fullexport").Value = 1
                            .Fields("ExportCy").Value = IIf(ws.Range("V" & i).Value <> "", ws.Range("V" & i).Value, "CAT LAI")
                            .Fields("finalICD").Value = IIf(ws.Range("V" & i).Value <> "", ws.Range("V" & i).Value, "CAT LAI")
                            .Fields("fullimport").Value = 0
                            .Fields("fulltoconsignee").Value = 0
                            .Fields("soundcontainer").Value = 0
                            .Fields("emptytoshipper").Value = 0

                        End If
                        If Not IsNothing(ws.Range("M" & i).Value) And Not IsNothing(ws.Range("N" & i).Value) And Not IsNothing(ws.Range("S" & i).Value) And Not IsNothing(ws.Range("U" & i).Value) And Not IsNothing(ws.Range("W" & i).Value) Then
                            .Fields("fullimport").Value = 0
                            .Fields("fulltoconsignee").Value = 0
                            .Fields("soundcontainer").Value = 0
                            .Fields("emptytoshipper").Value = 0
                            .Fields("fullexport").Value = 0
                        End If


                        emptycy = ""
                        importcy = ""
                        h += 1
                        .Update()

                    End With
                    rs.Close()
                    i += 1 'dòng thứ i của File
                End While

                MsgBox(h & " Container(s) Checked")

            Catch ex As Exception
                MsgBox(Err.Description)
            Finally
                Me.grbProcess.Visible = False
                app.Quit()
            End Try


            'Me.DataGridView1.DataSource = dt 'ds.Tables("Notify")
            'Dim strSQL As String
            'strSQL = "select * from containermanagerment "
            'Dim conn As New SqlClient.SqlConnection(strconnDG)
            'conn.Open()

            'Dim cmd As New SqlClient.SqlCommand(strSQL, conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            'Dim cmdBD As New SqlClient.SqlCommandBuilder(Adapter)
            'Adapter.Update(oTableContainer)
            'Return
            'ExcelAdapter.Fill(dt)
            'Me.DataGridView1.DataSource = dt
            'Dim Code As String
            'Dim Pt As Double = CodeCount("Notify") + 1

            'Dim Sql As String
            'Dim ID As String
            'For i = 1 To Me.DataGridView1.RowCount - 1
            '    '    'If i = 549 Then
            '    '    '    MsgBox("")
            '    '    'End If

            '    '    'Dim Len As Integer = CStr(Pt).Length
            '    '    'Code = "S"
            '    '    'For k As Integer = 0 To 6 - Len
            '    '    '    Code &= "0"
            '    '    'Next
            '    '    'Code &= CStr(Pt)
            '    'If Me.DataGridView1("F2", i).Value.ToString.Trim.Length < 3 Then
            '    '    Continue For
            '    'End If

            '    ID = newid()

            '    Sql = "Insert Into Customer(Customer_ID,Customer_Code,COMPANY,EnglishName,Address,Tel,Fax) "
            '    Sql &= "  Values ('{" & ID & "}',N'" & IIf(Me.DataGridView1("F2", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F2", i).Value.ToString, "'", ""), "") & "'"
            '    Sql &= ",N'" & IIf(Me.DataGridView1("F3", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F3", i).Value.ToString, "'", ""), "") & "'"
            '    Sql &= ",N'" & IIf(Me.DataGridView1("F4", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F4", i).Value.ToString, "'", ""), "") & "'"
            '    Sql &= ",N'" & IIf(Me.DataGridView1("F6", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F6", i).Value.ToString, "'", ""), "") & "'"
            '    Sql &= ",N'" & IIf(Me.DataGridView1("F7", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F7", i).Value.ToString, "'", ""), "") & "'"
            '    Sql &= ",N'" & IIf(Me.DataGridView1("F8", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F8", i).Value.ToString, "'", ""), "") & "')"
            '    'Return
            '    ' Sql &= ",'" & IIf(Me.DataGridView1("F6", i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F7", i).Value.ToString, "'", ""), "") & "')"
            '    'If i = 23 Then
            '    '    MsgBox(Sql)
            '    'End If
            '    'Pt += 1
            '    Dim SqlCmd As New SqlClient.SqlCommand(Sql, SqlConn)
            '    SqlCmd.CommandType = CommandType.Text
            '    SqlCmd.CommandText = Sql
            '    SqlCmd.ExecuteNonQuery()
            '    For j As Integer = 10 To 33
            '        If Me.DataGridView1("F" & j, i).Value.ToString.Trim.Length = 0 Then
            '            j += 2
            '            Continue For
            '        End If
            '        Sql = " Insert Into PIC (Customer_ID,PIC,DirectLine)"
            '        Sql &= " Values ('{" & ID & "}'"
            '        Sql &= ",N'" & IIf(Me.DataGridView1("F" & j, i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F" & j, i).Value.ToString, "'", ""), "") & "'"
            '        j += 2
            '        Sql &= ",N'" & IIf(Me.DataGridView1("F" & j, i).Value.ToString <> "", Strings.Replace(Me.DataGridView1("F" & j, i).Value.ToString, "'", ""), "") & "')"

            '        SqlCmd = New SqlClient.SqlCommand(Sql, SqlConn)
            '        SqlCmd.CommandType = CommandType.Text
            '        SqlCmd.CommandText = Sql
            '        SqlCmd.ExecuteNonQuery()
            '    Next

            'Next
            'MsgBox("complete")
            'End If
            ' Me.DataGridView1.DataSource = oTableContainer
        Catch ex As Exception
            'MsgBox(i)
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheck.Click


        CheckContainerStatus(Me.txtFilename.Text, Me.txtSheetName.Text)
        'đoạn lấy dữ liệu trong CSDL
        'Dim strQuery As String
        'Dim rs As New ADODB.Recordset
        'Dim ConnExcel As New OleDb.OleDbConnection()

        'Try

        '    Dim Sound, FullExport, MTShipper, FCNs As Integer

        '    For i As Integer = 0 To ExcelDt.Rows.Count - 1

        '        strQuery = " Select Top 1 FinalICD,Container_No,SoundContainer,ToBeInSpected,DamageContainer,FullImport,FullToConsignee,FullExport,EmptyToShipper,EmptyExportQuay,EmptyContainerReposit,"
        '        strQuery &= " FactOfDelDate,FactOfReDelDate,VanningDate,DateOfEmptyContainerToShipper,FullOrEmpty "
        '        strQuery &= " from ContainerManagerment Where Continued=1 And Container_No='" & Strings.Replace(ExcelDt.Rows(i).Item("SoContainer").ToString.Trim, " ", "") & "' And (DateOfOnboard Is NULL Or DateOfOnboard='')"
        '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '        'F4 Container_no,
        '        Dim dat As Date
        '        Dim temp As String

        '        If Me.chkPhucLong.Checked = False Then 'file của Cát Lái ,New Port

        '            temp = ExcelDt.Rows(i).Item("NgayThucHien") & " " & ExcelDt.Rows(i).Item("GioThucHien")
        '            dat = temp
        '            If Not rs.EOF Then
        '                'F11 Date
        '                'temp = Replace(ExcelDt.Rows(i).Item("F11").ToString, "-", "/") & ExcelDt.Rows(i).Item("F12").ToString
        '                Sound = 0
        '                FullExport = 0
        '                MTShipper = 0
        '                FCNs = 0
        '                If ExcelDt.Rows(i).Item("ICD").ToString.Trim = "CTL" Then
        '                    rs.Fields("FinalICD").Value = "CAT LAI"
        '                ElseIf ExcelDt.Rows(i).Item("ICD").ToString.Trim = "TCA" Then
        '                    rs.Fields("FinalICD").Value = "NEW PORT"
        '                End If

        '                Select Case ExcelDt.Rows(i).Item("PhuongAn").ToString.Trim
        '                    Case "DORU" 'container đầy tại bãi ,chuẩn bị xuất
        '                        FullExport = 1
        '                        rs.Fields("DateOfFullLoadContainerToCY").Value = dat
        '                        'rs.Fields("VanningDate").Value = dat
        '                    Case "CAPR", "CXLA" 'giao container rỗng cho khách hàng
        '                        MTShipper = 1
        '                        rs.Fields("DateOfEmptyContainerToShipper").Value = dat
        '                    Case "GTHA" 'giao container đầy cho khách hàng
        '                        FCNs = 1
        '                        rs.Fields("FactOfDelDate").Value = dat
        '                    Case "NHAR" ' sau khi khách hàng lầy hàng xong trả rỗng về bãi
        '                        Sound = 1
        '                        rs.Fields("FactOfReDelDate").Value = dat
        '                        'rs.Fields("FullOrEmpty").Value = "E"
        '                        If ExcelDt.Rows(i).Item("ICD").ToString.Trim = "CTL" Then
        '                            rs.Fields("EmptyCy").Value = "CAT LAI"
        '                        ElseIf ExcelDt.Rows(i).Item("ICD").ToString.Trim = "TCA" Then
        '                            rs.Fields("EmptyCy").Value = "NEW PORT"
        '                        End If
        '                    Case "RURU" 'khách hàng lấy hàng tại bãi không đem container về
        '                        Sound = 1
        '                        rs.Fields("FactOfDelDate").Value = dat
        '                        rs.Fields("FactOfReDelDate").Value = dat

        '                        If ExcelDt.Rows(i).Item("ICD").ToString.Trim = "CTL" Then
        '                            rs.Fields("EmptyCy").Value = "CAT LAI"
        '                        ElseIf ExcelDt.Rows(i).Item("ICD").ToString.Trim = "TCA" Then
        '                            rs.Fields("EmptyCy").Value = "NEW PORT"
        '                        End If


        '                    Case Else
        '                        rs.Close()
        '                        Continue For
        '                End Select


        '                rs.Fields("SoundContainer").Value = Sound
        '                rs.Fields("FullToConsignee").Value = FCNs
        '                rs.Fields("FullExport").Value = FullExport
        '                rs.Fields("EmptyToShipper").Value = MTShipper
        '                rs.Fields("EmptyContainerReposit").Value = 0
        '                rs.Fields("ToBeInSpected").Value = 0
        '                rs.Fields("DamageContainer").Value = 0
        '                rs.Fields("FullImport").Value = 0
        '                rs.Fields("EmptyExportQuay").Value = 0


        '                Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = mbkColor
        '                'Me.DataGridView1.Rows(i).DefaultCellStyle.SelectionForeColor = Color.Blue

        '                rs.Update()
        '            End If
        '        Else 'File Của Phuc Long
        '            If Not rs.EOF Then
        '                dat = ExcelDt.Rows(i).Item("NgayThucHien")
        '                rs.Fields("FinalICD").Value = "PHUC LONG"
        '                rs.Fields("SoundContainer").Value = IIf(Me.chkSoundContainer.Checked, 1, 0)
        '                rs.Fields("FullToConsignee").Value = IIf(Me.chkFullToConsignee.Checked, 1, 0)
        '                rs.Fields("FullExport").Value = IIf(Me.chkFullExportAtQuay.Checked, 1, 0)
        '                rs.Fields("EmptyToShipper").Value = IIf(Me.chkEmptyToShipper.Checked, 1, 0)
        '                rs.Fields("EmptyExportQuay").Value = IIf(Me.chkEmptyExpotAtQuay.Checked, 1, 0)
        '                rs.Fields("EmptyContainerReposit").Value = IIf(Me.chkEmptyForRepostioned.Checked, 1, 0)
        '                rs.Fields("ToBeInSpected").Value = IIf(Me.chkToBeInspected.Checked, 1, 0)
        '                rs.Fields("DamageContainer").Value = IIf(Me.chkDamage.Checked, 1, 0)
        '                rs.Fields("FullImport").Value = IIf(Me.chkFullImports.Checked, 1, 0)
        '                rs.Fields("EmptyCy").Value = "PHUC LONG"
        '                If Me.chkSoundContainer.Checked = True Then
        '                    rs.Fields("FactOfReDelDate").Value = dat
        '                    'rs.Fields("FullOrEmpty").Value = "E"
        '                End If

        '                If Me.chkFullToConsignee.Checked = True Then
        '                    rs.Fields("FactOfDelDate").Value = dat
        '                    'rs.Fields("FullOrEmpty").Value = "F"
        '                End If

        '                If Me.chkFullExportAtQuay.Checked = True Then
        '                    rs.Fields("DateOfFullLoadContainerToCY").Value = dat
        '                    'rs.Fields("FullOrEmpty").Value = "F"
        '                End If

        '                If Me.chkEmptyToShipper.Checked = True Then
        '                    rs.Fields("DateOfEmptyContainerToShipper").Value = dat
        '                    'rs.Fields("FullOrEmpty").Value = "E"
        '                End If

        '                If Me.chkFullImports.Checked = True Then
        '                    'rs.Fields("DateOfFullLoadContainerToCY").Value = dat
        '                    'rs.Fields("FullOrEmpty").Value = "F"
        '                End If
        '                Me.DataGridView1.Rows(i).DefaultCellStyle.ForeColor = mbkColor
        '                rs.Update()
        '            End If
        '        End If
        '        rs.Close()

        '    Next
        '    MsgBox("Complete")

        'Catch ex As Exception
        '    MsgBox(Err.Description)
        'Finally
        '    ConnExcel.Close()
        'End Try

    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    
End Class