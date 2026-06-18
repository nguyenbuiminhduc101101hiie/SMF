Imports system.Data.Odbc
Imports System.IO
Imports System.Text
Imports System.Globalization
Public Class frmImportInboundData
    'để chạy đựơc phải bật chế độ multilanguage
    Dim FileName As String
    Dim Vessel, VoyNo, VesselCode As String
    Dim sailed As Date
    Dim POR, POL, POD, DEL, DEST, Shipper_ID, Consignee_ID, Notify_ID, DescriptionOfGoods, CargoMarks, ShipperName, ConsigneeName, NotifyName As String
    Dim BL_NO, BL_Type, CY, WeightUnit, ContainerID, BLIB_ID, CargoIb_ID, MeasUnit, CarryKind, Seal, ReceiveKind, Kind, FULLORMT As String
    Dim first As Boolean
    Dim ContainerKind() As String = {"20GP", "40GP", "20RF", "40RF", "40HC", "45HC", "40RH", "20OT", "40OT", "20FR", "40FR", "B/L", "B\L"}

    Public Transit As Integer
    Dim weight, Meas, Amount As Double
    Dim i As Integer = 0

    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Public Function CodeShipper() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(SHIPPER_Code) as CountNo from Shipper", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function

    Public Function CodeConsignee() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Consignee_code) as CountNo from Consignee", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function

    Public Function CodeNotify() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Notify_code) as CountNo from Notify", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Function WeekOfYear() As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        If Me.dtpETA.Text <> "" Then
            WeekOfYear = myCal.GetWeekOfYear(CDate(Me.dtpETA.Text), myCWR, myFirstDOW)
        Else
            WeekOfYear = 0
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function

    Sub InsertScheduleCheck(ByVal VesselCode As String, ByVal Vessel As String, ByVal Voyno As String)

        Try
            Dim SQL As String
            SQL = "Select Top 1 * from ScheduleCheck "
            SQL &= "Where Continued=1 And  VoyNo='" & Voyno & "'  AND day(ScheduleCheck.ETA)='" & Me.dtpETA.Value.Day & "' and month(ScheduleCheck.ETA)='" & Me.dtpETA.Value.Month & "' and year(ScheduleCheck.ETA)='" & Me.dtpETA.Value.Year & "'"
            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                With rs
                    .AddNew()
                    .Fields("SchedulecheckID").Value = NewId()
                    .Fields("VesselCodeInbound").Value = VesselCode
                    .Fields("Vesselinbound").Value = Vessel
                    .Fields("VoyNo").Value = Voyno
                    .Fields("ETA").Value = Me.dtpETA.Value
                    .Fields("Checked").Value = 0
                    .Update()
                End With
            End If
            rs.Close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description & " Insert ScheduleCheck")
        End Try
    End Sub
    
    Sub chiaCont(ByVal cont As String, ByRef amount As Double, ByRef kind As String)
        Dim amountstr As String = ""
        kind = ""
        amount = 0
        For i As Integer = 0 To cont.Length - 1
            If IsNumeric(cont(i)) Then
                amountstr &= cont(i)
            Else
                kind &= cont(i)
            End If
        Next
        If amountstr = "" Then
            amountstr = "0"
        End If
        amount = CDbl(amountstr)
    End Sub
    Function GetSTT(ByVal Vessel As String, ByVal VoyNo As String) As Double
        Try
            Dim strSQL As String = " select Num=case when Max(Stt) is null then 0 else max(stt) end  "
            strSQL &= " From BillOfLadingIb "
            strSQL &= "Where Vessel='" & Vessel & "' And VoyAge='" & VoyNo & "'"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            'If dt.Rows.Count > 0 Then
            '    If dt.Rows(0).Item("Num") <> "" Then
            Return dt.Rows(0).Item("Num")
            '    End If
            'End If
            'Return 0
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function GetCargoSTT(ByVal Vessel As String, ByVal VoyNo As String) As Double
        Try
            Dim strSQL As String = " select Num=case when Max(CargoIB.Stt) is null then 0 else max(CargoIB.stt) end  "
            strSQL &= " From (CargoIB INNER JOIN BillOfLadingIb On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID)"
            strSQL &= "Where Vessel='" & Vessel & "' And VoyAge='" & VoyNo & "'"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            'If dt.Rows.Count > 0 Then
            '    If dt.Rows(0).Item("Num") <> "" Then
            Return dt.Rows(0).Item("Num")
            '    End If
            'End If
            'Return 0
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub QueryInboundData()
        Dim CountBill, Imported As Double
        Dim ICDPort As String = "CAT LAI"
        Dim Con As OleDb.OleDbConnection
        Dim BLArr() As String
        Dim BLNO() As String
        Dim Count As Double 'tong so dong cua file 
        i = 0
        InsertScheduleCheck(Me.txtVesselCode.Text, Me.cboVessel.Text, Me.txtVoyNo.Text)

        Try
            Dim strConnExcel, sheet As String
            'strConn = "Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=" & FileName & ";"
            ' Dim Con As New OdbcConnection(strConn)
            Dim dt As New DataTable
            Dim CmdSelect As New OleDb.OleDbCommand
            'Dim CmdSelect As New OdbcCommand("SELECT * FROM [Sheet1$] ", Con)
            'Dim Adapter As New OdbcDataAdapter(CmdSelect)
            strConnExcel = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & FileName & "; Extended Properties=""Excel 8.0;HDR=no;"""

            Con = New OleDb.OleDbConnection(strConnExcel)
            Con.Open()
            If Len(Me.txtSheetName.Text.Trim) < 0 Then
                DisplayMessage(True, "Sheet name is invalid, please try again! ")
                Me.txtSheetName.Focus()
            End If
            Try
                CmdSelect = New OleDb.OleDbCommand("SELECT * FROM [" & Me.txtSheetName.Text.Trim & "$] ", Con)
            Catch ex As Exception
                DisplayMessage(True, "Sheet name is invalid, please try again! ")
                Con.Close()
                Exit Sub
            End Try

            Dim Adapter As New OleDb.OleDbDataAdapter(CmdSelect)
            Dim STT, STTCargo As Double
            STTCargo = GetCargoSTT(Me.cboVessel.Text.Trim, Me.txtVoyNo.Text.Trim) + 1
            STT = GetSTT(Me.cboVessel.Text.Trim, Me.txtVoyNo.Text.Trim) + 1

            Dim CmdCountBill As New OleDb.OleDbCommand("Select count(f1) as Num from [" & Me.txtSheetName.Text.Trim & "$] Where F1 like'%VESSEL%'", Con)
            Dim ApdapterCountBill As New OleDb.OleDbDataAdapter(CmdCountBill)
            Dim dtCountBill As New DataTable
            ApdapterCountBill.Fill(dtCountBill)

            'đếm số bill hiện có trong file
            If Not IsNothing(dtCountBill) Then
                CountBill = dtCountBill.Rows(0).Item("Num")
            End If

            ReDim BLArr(CountBill)
            ReDim BLNO(CountBill)


            'số dòng đã import 
            Imported = 0 'chưa import nên bằng 0
            If Not IsNothing(dt) Then
                dt.Clear()
            End If
            Adapter.Fill(dt)

            Dim temptable As New DataTable
            For j As Integer = 1 To 9
                temptable.Columns.Add(j.ToString)
            Next
            Vessel = ""
            VesselCode = ""
            VoyNo = ""
            Dim row As DataRow
            Dim strVIA As String
            Dim data As Boolean = False
            Count = dt.Rows.Count
            For k As Integer = 0 To Count - 1
                If dt.Rows(k).Item(0).ToString Like "*VESSEL*" Then
                    data = True
                    Exit For
                End If
            Next
            If data = False Then
                MsgBox("file Đã chọn không đúng , Hãy Chọn lại")
                Return
            End If
            '----- -----
            Me.GroupBox1.Visible = True
            Me.prbExport.Maximum = Count + 1
            For i = 0 To Count - 1 'chay toan bo file Excel
                System.Windows.Forms.Application.DoEvents()
                Me.prbExport.Value = i
                'If i = 30 Then
                '    MsgBox("30 ")
                'End If
                If i > 0 And i < Count - 1 Then
                    If dt.Rows(i + 1).Item(0).ToString Like "*VESSEL*" Then
                        data = Not data
                    End If
                End If

                If dt.Rows(i).Item(0).ToString Like "*VESSEL*" Then
                    If Vessel <> "" Then
                        Vessel = ""
                    End If
                    ' if dong dau co them VIA thi ta cat bo no di
                    If dt.Rows(i).Item(0).ToString Like "*VIA*" Then
                        strVIA = Mid(dt.Rows(i).Item(0).ToString, 1, dt.Rows(i).Item(0).ToString.IndexOf("VIA")).Trim
                    Else
                        strVIA = dt.Rows(i).Item(0).ToString.Trim
                    End If

                    If Vessel = "" And strVIA.Trim.Length > 0 Then
                        first = True
                        Dim tempvessel() As String
                        tempvessel = Strings.Split(strVIA, ":")
                        If tempvessel.Length >= 3 Then
                            'Vessel = Strings.Left(tempvessel(1).Trim, tempvessel(1).Length - 7).Trim
                            'Dim tempVoyno() As String

                            'tempVoyno = Strings.Split(tempvessel(2), "SAIL")
                            'VoyNo = Strings.Replace(tempVoyno(0).Trim, " ", "")
                            'VoyNo = Strings.Replace(VoyNo, "-", "")
                            'VoyNo = Strings.Replace(VoyNo, "_", "")
                            'VoyNo = Strings.Replace(VoyNo, "/", "")
                            'VoyNo = Strings.Replace(VoyNo, "\", "")
                            Vessel = Me.cboVessel.Text.Trim
                            VesselCode = Me.txtVesselCode.Text.Trim
                            VoyNo = Me.txtVoyNo.Text.Trim

                            sailed = tempvessel(tempvessel.Length - 1)


                        End If
                        Dim j As Integer = 0

                        If UCase(dt.Rows(i + 1).Item(0).ToString.Trim) Like "POR*" Then
                            j = i + 1
                        Else
                            j = i + 2
                        End If
                        ' lay noi ha bai ICD
                        If dt.Rows(j).Item(0) Like "*POR*" Then
                            Dim TempPort() As String
                            TempPort = Strings.Split(dt.Rows(j).Item(0), ":")
                            If TempPort.Length >= 5 Then
                                If TempPort.Length > 5 Then
                                    'CAT LAI , NEW PORT , SONG THAN ,PHUOC LONG ,TRANSIMEX, BIEN HOA, PHUC LONG  ,KHANH HOI  ,Z1,  VINATRAN , SADACO
                                    '''-lay du lieu tu csdl ra so sanh ICD
                                    Dim strSQL As String = " Select terminalName from terminal where continued=1 "
                                    Dim dtICD As New DataTable
                                    Dim n As Integer
                                    dtICD = ReadTable(strSQL)
                                    For n = 0 To dtICD.Rows.Count - 1
                                        If dtICD.Rows(n).Item("terminalname").ToString <> "" Then
                                            If TempPort(5).Trim Like "*" + dtICD.Rows(n).Item("terminalname").ToString + "*" Then
                                                ICDPort = dtICD.Rows(n).Item("terminalname").ToString
                                                Exit For
                                            Else
                                                ICDPort = "CAT LAI"
                                            End If
                                        End If
                                    Next
                                    ''' '---------------------------------------------------------
                                    '    If TempPort(5).Trim Like "*NEW PORT*" Or TempPort(5).Trim Like "*NEWPORT*" Then
                                    '        ICDPort = "NEW PORT"
                                    '    End If
                                    '    If TempPort(5).Trim Like "*SONG THAN*" Or TempPort(5).Trim Like "*SONGTHAN*" Then
                                    '        ICDPort = "SONG THAN"
                                    '    End If
                                    '    If TempPort(5).Trim Like "*PHUOC LONG*" Or TempPort(5).Trim Like "*PHUOCLONG*" Then
                                    '        ICDPort = "ICD PHUOC LONG"
                                    '    End If
                                    '    If TempPort(5).Trim Like "*PHUC LONG*" Or TempPort(5).Trim Like "*PHUCLONG*" Then
                                    '        ICDPort = "PHUC LONG"
                                    '    End If
                                    '    If TempPort(5).Trim Like "*KHANH HOI*" Or TempPort(5).Trim Like "*KHANHHOI*" Then
                                    '        ICDPort = "KHANH HOI"
                                    '    End If
                                    '    If TempPort(5).Trim Like "*TRANSIMEX*" Or TempPort(5).Trim Like "*TRANSIMEX*" Then
                                    '        ICDPort = "TRANSIMEX"
                                    '    End If
                                    '    If TempPort(5).Trim Like "*BIEN HOA*" Or TempPort(5).Trim Like "*BIENHOA*" Then
                                    '        ICDPort = "BIEN HOA"
                                    '    End If
                                End If
                                'If TempPort(4).Trim Like "*NEW PORT*" Or TempPort(4).Trim Like "*NEWPORT*" Then ' hoi lai bao nhieu Port                            DisplayMessage(True, TempPort(4) + TempPort(5))
                                '    ICDPort = "NEW PORT"
                                'ElseIf TempPort(4).Trim Like "*SONG THAN*" Or TempPort(4).Trim Like "*SONGTHAN*" Then
                                '    ICDPort = "SONG THAN"
                                'ElseIf TempPort(4).Trim Like "*PHUOC LONG*" Or TempPort(4).Trim Like "*PHUOCLONG*" Then
                                '    ICDPort = "ICD PHUOC LONG"
                                'ElseIf TempPort(4).Trim Like "*PHUC LONG*" Or TempPort(4).Trim Like "*PHUCLONG*" Then
                                '    ICDPort = "PHUC LONG"
                                'ElseIf TempPort(4).Trim Like "*KHANH HOI*" Or TempPort(4).Trim Like "*KHANHHOI*" Then
                                '    ICDPort = "KHANH HOI"
                                'ElseIf TempPort(4).Trim Like "*TRANSIMEX*" Or TempPort(4).Trim Like "*TRANSIMEX*" Then
                                '    ICDPort = "TRANSIMEX"
                                'ElseIf TempPort(4).Trim Like "*BIEN HOA*" Or TempPort(4).Trim Like "*BIENHOA*" Then
                                '    ICDPort = "BIEN HOA"
                                'Else
                                '    ICDPort = "CAT LAI"
                                'End If
                                '-------
                                '--------kiem tra xem co phai NPT

                                POR = Strings.Left(TempPort(1).Trim, TempPort(1).Trim.Length - 3).Trim
                                POL = Strings.Left(TempPort(2).Trim, TempPort(2).Trim.Length - 3).Trim
                                POD = Strings.Left(TempPort(3).Trim, TempPort(3).Trim.Length - 3).Trim
                                DEL = Strings.Left(TempPort(4).Trim, TempPort(4).Trim.Length - 4).Trim
                                If TempPort.Length = 5 Then
                                    DEST = ""
                                Else
                                    DEST = TempPort(5).Trim
                                End If

                            End If
                        End If
                    End If

                End If
                If data And i <> Count - 1 Then
                    row = temptable.NewRow
                    For j As Integer = 0 To 8
                        row(j) = dt.Rows(i).Item(j).ToString
                    Next
                    temptable.Rows.Add(row)

                Else


                    Dim rs As New ADODB.Recordset
                    Dim strQuery As String
                    Dim j As Integer = 0
                    Dim Pos As Integer = 0
                    Dim FreightPos As Integer = 0 'lưu vị trí bắt đầu chạy cũa Phí
                    While temptable.Rows(j).Item(3).ToString = ""
                        j += 1
                    End While
                    j += 3
                    FreightPos = j 'vị trí bắt đầu chạy của phí = j
                    BL_NO = temptable.Rows(j + 1).Item(0).ToString
                    '--- kiem tra lai ICD port co phai la NPT? 08/04/08
                    If UCase(BL_NO) Like "????NPT*" Then
                        If ICDPort = "NEW PORT" Then
                            ICDPort = "NEW PORT"
                        Else
                            ICDPort = ""
                        End If
                    End If
                    '-----------------------------------------
                    ' neu khong phai cua SGN thi ko cho phep import du lieu
                    If BL_NO Like "*SGN*" Or BL_NO Like "*PNH*" or BL_NO Like "*NPT*" Then

                    Else
                        DisplayMessage(True, "This system just for HCM City, please call 0908 349945 (Mr. Cao Hung), for more information.")
                    End If
                    '-----------------------
                    If first Then
                        strQuery = "Select * from BillOfLadingIB Where BLIB_NO='" & BL_NO & "' And Continued=1"

                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If Not rs.EOF Then
                            'MsgBox("This File had imported", MsgBoxStyle.Critical)

                            rs.Close()
                            temptable.Rows.Clear()
                            If i = Count - 1 Then
                                DisplayMessage(True, "File này đã import!")
                                Exit Sub
                            End If
                            MsgBox("Bill " & BL_NO & " Đã có Bill Trùng trong Dữ liệu Hãy kiểm tra lại Bill Này")
                            i -= 1
                            Continue For
                        End If
                        first = False
                        rs.Close()
                    End If
                    'đếm có bill đã imports
                    Imported += 1

                    CY = temptable.Rows(j + 2).Item(0).ToString
                    BL_Type = temptable.Rows(j + 4).Item(0).ToString.Trim
                    'Tinh Trang container
                    FULLORMT = "F"
                    If BL_NO Like "*E" Then 'If BL_Type.Length = 0 Or BL_NO Like "*E" Then
                        'dong thu 2 khac null
                        MsgBox("Bill số :" & Imported & " chứa container rỗng! vì số liệu Không chuẩn nên hãy kiểm tra lại bill này" & vbCrLf & " Ở Dòng thứ : " & i - temptable.Rows.Count)
                        FULLORMT = "E"
                        'BL_NO = temptable.Rows(j + 1).Item(0).ToString
                    End If

                    'Pos giữ lại Vị trí của BL-TYPe Chạy Hết Xuống Dứơi Cuối cùng để lấy Container
                    Pos = j + 5


                    Dim k As Integer  'bien chay de lay thong Description of goods var cargo Marks vi giong nhau ve vi tri dong
                    DescriptionOfGoods = ""
                    CargoMarks = ""
                    Dim getMarks As Boolean = True
                    For k = j + 1 To temptable.Rows.Count - 1
                        DescriptionOfGoods &= temptable.Rows(k).Item(2).ToString & Chr(13)
                        If temptable.Rows(k).Item(1).ToString Like "*/*/*" Then
                            getMarks = False
                        ElseIf getMarks = True Then
                            CargoMarks &= temptable.Rows(k).Item(1).ToString & Chr(13)
                        End If

                    Next


                    'them Vao Shipper Neu co Thi cap Nhat lai ten Con khong thi them

                    While temptable.Rows(j).Item(3).ToString.Trim = ""
                        j += 1
                    End While
                    If temptable.Rows(j).Item(3).ToString.Trim <> "" Then
                        ShipperName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")

                    End If




                    Dim RunRow As Integer = IIf(j + 25 > temptable.Rows.Count - 1, temptable.Rows.Count - 2, j + 20)
                    While j < RunRow
                        strQuery = "Select * from Shipper Where Continued=1 And Shipper_1 Like '%" & ShipperName & "%'"
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If temptable.Rows(j).Item(3).ToString.Trim Like "*1)*" Then
                            ShipperName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
                            If ShipperName(0) = ")" Then
                                ShipperName.Remove(0, 1)
                            End If

                            Dim S As Integer = j
                            Dim Value As Integer = 2
                            Dim Remarks As String = ""
                            With rs
                                'If rs.EOF Then
                                .AddNew()
                                .Fields("Shipper_ID").Value = NewId()
                                Dim Len As Integer = CStr(CodeNotify() + 1).Length
                                Dim Temp As String = "S"
                                For i As Integer = 0 To 7 - Len
                                    Temp &= "0"
                                Next

                                Temp &= CStr(CodeNotify() + 1)
                                Temp = Mid(Temp, 2, Temp.Length)
                                If Temp.Length > 8 Then
                                    Temp = Mid(Temp, 2, Temp.Length)
                                End If
                                .Fields("Shipper_Code").Value = Temp
                                'End If
                                For S = j To RunRow
                                    If temptable.Rows(S + 1).Item(3).ToString.Trim Like "*2)*" Then
                                        Exit For
                                    End If
                                    If Value <= 6 Then
                                        .Fields("Shipper_" & Value).Value = temptable.Rows(S + 1).Item(3).ToString
                                        Value += 1
                                    Else
                                        Remarks &= temptable.Rows(S + 1).Item(3).ToString
                                    End If
                                Next

                                .Fields("Shipper_1").Value = ShipperName
                                .Fields("REMARKS").Value = Remarks
                                .Update()
                            End With

                            j = S + 1
                        End If
                        Shipper_ID = rs.Fields("Shipper_ID").Value
                        rs.Close()
                        While temptable.Rows(j).Item(3).ToString.Trim = ""
                            j += 1
                        End While
                        'them Vao Consignee Neu co Thi cap Nhat lai ten Con khong thi them
                        If temptable.Rows(j).Item(3).ToString.Trim <> "" Then
                            ConsigneeName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
                        End If

                        strQuery = "Select * from Consignee Where Continued=1 And Consignee_1 Like '%" & ConsigneeName & "%'"
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If temptable.Rows(j).Item(3).ToString.Trim Like "*2)*" Then
                            ConsigneeName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
                            If ConsigneeName(0) = ")" Then
                                ConsigneeName.Remove(0, 1)
                            End If
                            Dim value As Integer = 2
                            Dim Remarks As String = ""
                            Dim C As Integer

                            With rs
                                'If rs.EOF Then
                                rs.AddNew()
                                .Fields("Consignee_ID").Value = NewId()
                                Dim Len As Integer = CStr(CodeNotify() + 1).Length
                                Dim Temp As String = "C"
                                For i As Integer = 0 To 7 - Len
                                    Temp &= "0"
                                Next
                                Temp &= CStr(CodeNotify() + 1)
                                Temp = Mid(Temp, 2, Temp.Length)
                                If Temp.Length > 8 Then
                                    Temp = Mid(Temp, 2, Temp.Length)
                                End If
                                .Fields("Consignee_Code").Value = Temp
                                ' End If

                                For C = j To RunRow
                                    If temptable.Rows(C + 1).Item(3).ToString.Trim Like "*3)*" Then
                                        Exit For
                                    End If
                                    If value <= 6 Then
                                        .Fields("Consignee_" & value).Value = temptable.Rows(C + 1).Item(3).ToString
                                        value += 1
                                    Else
                                        Remarks &= temptable.Rows(C + 1).Item(3).ToString
                                    End If
                                Next

                                .Fields("Consignee_1").Value = ConsigneeName
                                .Fields("Remarks").Value = Remarks
                                .Update()
                            End With

                            j = C + 1
                        End If
                        Consignee_ID = rs.Fields("Consignee_ID").Value
                        rs.Close()
                        While temptable.Rows(j).Item(3).ToString.Trim = ""
                            j += 1
                        End While


                        'them Vao Notify Neu co Thi cap Nhat lai ten Con khong thi them
                        If temptable.Rows(j).Item(3).ToString.Trim <> "" Then
                            NotifyName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
                        End If
                        strQuery = "Select * from Notify Where Continued=1 And Notify_1 Like '%" & NotifyName & "%'"
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If temptable.Rows(j).Item(3).ToString.Trim Like "*3)*" Then

                            NotifyName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
                            If NotifyName(0) = ")" Then
                                NotifyName.Remove(0, 1)
                            End If
                            Dim value As Integer = 2
                            Dim Remarks As String = ""
                            Dim N As Integer

                            With rs
                                'If rs.EOF Then
                                rs.AddNew()
                                .Fields("Notify_ID").Value = NewId()
                                Dim Len As Integer = CStr(CodeNotify() + 1).Length
                                Dim Temp As String = "N"
                                For i As Integer = 0 To 7 - Len
                                    Temp &= "0"
                                Next
                                Temp &= CStr(CodeNotify() + 1)
                                Temp = Mid(Temp, 2, Temp.Length)
                                If Temp.Length > 8 Then
                                    Temp = Mid(Temp, 2, Temp.Length)
                                End If
                                .Fields("Notify_Code").Value = Temp
                                'End If

                                For N = j To RunRow
                                    'If temptable.Rows(N).Item(3).ToString.Trim Like "*3)*" Then
                                    '    Exit For
                                    'End If
                                    If value <= 6 Then
                                        .Fields("Notify_" & value).Value = temptable.Rows(N + 1).Item(3).ToString
                                        value += 1
                                    Else
                                        Remarks &= temptable.Rows(N + 1).Item(3).ToString
                                    End If
                                Next

                                .Fields("Notify_1").Value = NotifyName
                                .Fields("Remarks").Value = Remarks
                                .Update()

                            End With

                            j = N
                        End If
                        Notify_ID = rs.Fields("Notify_ID").Value
                        rs.Close()
                    End While

                    strQuery = "Select * from BillOfLadingIB Where BLIB_NO='" & BL_NO.Trim & "' and Continued=1"

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then

                            .AddNew()
                            .Fields("BLIB_ID").Value = NewId()

                            .Fields("BLIB_NO").Value = BL_NO

                        End If
                        '-----13/07/07
                        'If UCase(DescriptionOfGoods) Like "*NEW PORT*" Or UCase(DescriptionOfGoods) Like "*NEWPORT*" Then
                        '    ICDPort = "NEW PORT"
                        'End If
                        '-----------
                        .Fields("SHIPPER_ID").Value = Shipper_ID
                        .Fields("CONSIGNEE_ID").Value = Consignee_ID
                        .Fields("NOTIFY_ID").Value = Notify_ID
                        .Fields("Vessel").Value = Vessel
                        .Fields("VesselCode").Value = VesselCode
                        .Fields("Voyage").Value = VoyNo
                        .Fields("CY_CFS_ITEM").Value = CY
                        .Fields("Marks").Value = CargoMarks
                        .Fields("BL_TYPE").Value = BL_Type
                        .Fields("DESCRIPTIONOFGOODS").Value = DescriptionOfGoods
                        .Fields("SAILINGDATE").Value = Strings.FormatDateTime(sailed, DateFormat.ShortDate)
                        .Fields("ICDPort").Value = ICDPort
                        .Fields("ETA").Value = Me.dtpETA.Value.Date
                        .Fields("WeekofYear").Value = WeekOfYear()
                        .Fields("POR").Value = POR
                        .Fields("POL").Value = POL
                        .Fields("POD").Value = POD
                        .Fields("DEL").Value = DEL
                        .Fields("DEST").Value = DEST
                        .Fields("TRANSIT").Value = Transit
                        .Fields("STT").Value = STT

                        STT += 1

                        .Update()
                        BLIB_ID = .Fields("BLIB_ID").Value
                        BLNO(Imported - 1) = BL_NO
                        BLArr(Imported - 1) = Strings.Replace(BLIB_ID, "}", "")
                        BLArr(Imported - 1) = Strings.Replace(BLArr(Imported - 1), "{", "")
                    End With
                    rs.Close()


                    'them vao Container Và Cargo 
                    'If BL_NO = "8MNLSGN0013E" Then
                    '    MsgBox("")
                    'End If
                    ' them cargo Marks(shipping marks)

                    For Containerpos As Integer = Pos To temptable.Rows.Count - 1
                        Dim rang As String
                        rang = temptable.Rows(Containerpos).Item(0).ToString
                        'Dim ContainerKind() As String = {"20GP", "40GP", "20RF", "40RF", "40HC", "45HC", "40RH", "20OT", "40OT", "20FR", "40FR"}
                        Dim TrueContainerKind As Boolean = False
                        For Kind As Integer = 0 To ContainerKind.Length - 1
                            If UCase(rang.Trim) Like "*" & ContainerKind(Kind) & "*" Then
                                TrueContainerKind = True
                                Exit For
                            End If
                        Next
                        ' them 260607
                        'If TrueContainerKind = False Then
                        '    Continue For
                        'End If
                        If temptable.Rows(Containerpos).Item(0).ToString.Trim.Length > 2 And (TrueContainerKind) Then
                            Dim tempcontainer() As String
                            tempcontainer = Strings.Split(temptable.Rows(Containerpos).Item(0).ToString.Trim, "/")
                            If tempcontainer.Length = 2 Then
                            Else
                                MsgBox("Container đinh dạng không chuẩn ở dòng thứ " & i - temptable.Rows.Count + Containerpos & " trong file có tên :" & FileName & vbCrLf & "                          hãy  Kiểm tra lại , dữ liệu có thể không chính xác")
                            End If
                            strQuery = "Select * from Container Where CONTAINER_NO='" & tempcontainer(0).Trim & "' And Continued=1"
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            If rs.EOF Then
                                rs.AddNew()
                                rs.Fields("CTN_ID").Value = NewId()
                            End If
                            With rs

                                .Fields("CONTAINER_NO").Value = tempcontainer(0).Trim
                                .Fields("CTN_SIZE_TYPE").Value = tempcontainer(1).Trim
                                If tempcontainer(1).Trim = "20GP" Then
                                    .Fields("NETWEIGHT").Value = 2250
                                ElseIf tempcontainer(1).Trim = "40GP" Then
                                    .Fields("NETWEIGHT").Value = 6650
                                ElseIf tempcontainer(1).Trim = "40HC" Then
                                    .Fields("NETWEIGHT").Value = 3890
                                ElseIf tempcontainer(1).Trim = "40RH" Then
                                    .Fields("NETWEIGHT").Value = 5100
                                ElseIf tempcontainer(1).Trim = "20RF" Then
                                    .Fields("NETWEIGHT").Value = 3030
                                    'ElseIf tempcontainer(1).Trim = "20OT" Then
                                    '    .Fields("NETWEIGHT").Value = 0
                                    'ElseIf tempcontainer(1).Trim = "20OT" Then
                                    '    .Fields("NETWEIGHT").Value = 0
                                    'ElseIf tempcontainer(1).Trim = "20OT" Then
                                    '    .Fields("NETWEIGHT").Value = 0
                                    'ElseIf tempcontainer(1).Trim = "20OT" Then
                                    '    .Fields("NETWEIGHT").Value = 0
                                Else
                                    .Fields("NETWEIGHT").Value = 0
                                End If
                                .Update()
                            End With

                            ContainerID = rs.Fields("CTN_ID").Value
                            rs.Close()

                            Dim Cargo(), mCargo_IB_ID As String
                            Cargo = Strings.Split(temptable.Rows(Containerpos).Item(1).ToString, "/")

                            strQuery = "Select * from CargoIB "
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            rs.AddNew()
                            mCargo_IB_ID = NewId()

                            rs.Fields("CargoIB_ID").Value = mCargo_IB_ID
                            rs.Fields("BLIB_ID").Value = BLIB_ID
                            rs.Fields("CTN_ID").Value = ContainerID
                            rs.Fields("Container_Type").Value = tempcontainer(1).Trim
                            rs.Fields("STT").Value = STTCargo
                            STTCargo += 1
                            ' rs.Fields("CARGOMARKS").Value = CargoMarks


                            Dim MeasCargo() As String
                            Dim Gross() As String
                            If Cargo.Length = 9 Then ' If Cargo.Length = 9 And BL_Type <> "" Then if la container rong thi ko dua vao csdl

                                Seal = IIf(Cargo(1).Trim.Length = 0, " ", Cargo(1).Trim)
                                CarryKind = IIf(Cargo(3).Trim.Length = 0, " ", Cargo(3).Trim)
                                ReceiveKind = IIf(Cargo(4).Trim.Length = 0, " ", Cargo(4).Trim)


                                Gross = Strings.Split(TrimSpace(Cargo(5)), " ")
                                'If Gross.Length = 2 Then
                                '    Amount = Gross(0)
                                '    Kind = Gross(1).Trim
                                'Else
                                chiaCont(TrimSpace(Cargo(5)), Amount, Kind)
                                'End If

                                'Dim WeightCargo() As String
                                weight = IIf(Strings.Left(Cargo(6).Trim, Cargo(6).Trim.Length - 3) = "", 0, Strings.FormatNumber(Strings.Left(Cargo(6).Trim, Cargo(6).Trim.Length - 3), 2))
                                WeightUnit = Strings.Right(Cargo(6).Trim, 3)


                                MeasCargo = Strings.Split(TrimSpace(Cargo(8)), " ")
                                If MeasCargo.Length = 2 Then
                                    Meas = MeasCargo(0)
                                    MeasUnit = MeasCargo(1).Trim
                                Else
                                    Meas = 0
                                    MeasUnit = ""
                                End If

                                'them Vào Cargo 
                                With rs
                                    .Fields("SEAL").Value = Seal
                                    .Fields("CARRIERKIND").Value = CarryKind
                                    .Fields("RECEIVEKIND").Value = ReceiveKind
                                    .Fields("AMOUNT").Value = Amount
                                    .Fields("KIND").Value = Kind
                                    .Fields("GROSSWEIGHT").Value = weight
                                    .Fields("GrossUnit").Value = WeightUnit
                                    .Fields("MEAS").Value = Meas
                                    .Fields("MEASUNIT").Value = MeasUnit
                                    .Fields("FullEmpty").Value = FULLORMT
                                End With
                                CargoIb_ID = rs.Fields("CargoIB_ID").Value
                                '--------------
                            ElseIf Cargo.Length = 8 Then

                                Seal = IIf(Cargo(1).Trim.Length = 0, " ", Cargo(1).Trim) ' SEAL
                                ReceiveKind = IIf(Cargo(2).Trim.Length = 0, " ", Cargo(2).Trim) ' FCL
                                CarryKind = IIf(Cargo(3).Trim.Length = 0, " ", Cargo(3).Trim) 'COC



                                Gross = Strings.Split(TrimSpace(Cargo(4)), " ") ' CONT , LOAI 

                                'If Gross.Length = 2 Then
                                '    Amount = Gross(0)
                                '    Kind = Gross(1).Trim
                                'Else
                                chiaCont(TrimSpace(Cargo(4)), Amount, Kind)
                                'End If

                                'Dim WeightCargo() As String
                                weight = IIf(Strings.Left(Cargo(5).Trim, Cargo(5).Trim.Length - 3) = "", 0, Strings.FormatNumber(Strings.Left(Cargo(5).Trim, Cargo(5).Trim.Length - 3), 2))
                                WeightUnit = Strings.Right(Cargo(5).Trim, 3)


                                MeasCargo = Strings.Split(TrimSpace(Cargo(7)), " ")
                                If MeasCargo.Length = 2 Then
                                    Meas = MeasCargo(0)
                                    MeasUnit = MeasCargo(1).Trim
                                Else
                                    Meas = 0
                                    MeasUnit = ""
                                End If

                                'them Vào Cargo 
                                With rs
                                    .Fields("SEAL").Value = Seal
                                    .Fields("CARRIERKIND").Value = CarryKind
                                    .Fields("RECEIVEKIND").Value = ReceiveKind
                                    .Fields("AMOUNT").Value = Amount
                                    .Fields("KIND").Value = Kind
                                    .Fields("GROSSWEIGHT").Value = weight
                                    .Fields("GrossUnit").Value = WeightUnit
                                    .Fields("MEAS").Value = Meas
                                    .Fields("MEASUNIT").Value = MeasUnit
                                End With
                                CargoIb_ID = rs.Fields("CargoIB_ID").Value
                            End If
                            '-------------
                            rs.Update()
                            rs.Close()
                            ' insert vao ContainerManagerment
                            If Transit = 0 Then
                                InsertContainerMNG(mCargo_IB_ID, BL_NO, POL, Vessel, VoyNo, Me.dtpETA.Value.Date, ICDPort, "Add", tempcontainer(0).Trim, tempcontainer(1).Trim)
                            End If

                            'chay tren bang Freight charge
                        End If
                    Next
                    'If BL_NO = "8SHASGN3BR409" Then
                    '    BL_NO = "8SHASGN3BR409"
                    'End If

                    For L As Integer = FreightPos To temptable.Rows.Count - 1
                        Dim rang As String
                        rang = temptable.Rows(L).Item(4).ToString

                        Dim TrueContainerKind As Boolean = False
                        For Kind As Integer = 0 To ContainerKind.Length - 1
                            If UCase(rang.Trim) Like "*" & ContainerKind(Kind) & "*" Then
                                TrueContainerKind = True
                                Exit For
                            End If
                        Next
                        If temptable.Rows(L).Item(4).ToString.Length > 0 And TrueContainerKind Then '(rang Like "*20GP*" Or rang Like "*40GP*" Or rang Like "*40HC*" Or rang Like "*20RF*" Or rang Like "*40RF*" Or rang Like "*40RH*" Or rang Like "*45HC*") Then
                            Dim tempfreight() As String
                            Dim pcb As String
                            If temptable.Rows(L).Item(4).ToString.Trim Like "*B/L*" Or temptable.Rows(L).Item(4).ToString.Trim Like "*B\L*" Then
                                tempfreight = Strings.Split(TrimSpace(temptable.Rows(L).Item(4).ToString.Trim.Replace("  ", " ")), " ")
                                If tempfreight.Length = 7 Then
                                    Dim freight() As String
                                    freight = Strings.Split(TrimSpace(temptable.Rows(L).Item(4).ToString.Trim.Replace("  ", " ")), " ")
                                    If freight.Length >= 5 Then
                                        strQuery = "Select * from PriceBillIB "
                                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                                        With rs
                                            .AddNew()
                                            .Fields("PriceBillIB_ID").Value = NewId()
                                            .Fields("BLIB_NO").Value = BL_NO
                                            .Fields("Quantity").Value = freight(0)
                                            .Fields("BillType").Value = freight(2).Trim
                                            .Fields("Items").Value = freight(3).Trim
                                            .Fields("Currency").Value = Strings.Left(freight(4).Trim, 3)
                                            .Fields("UnitPrice").Value = Strings.Right(freight(4).Trim, freight(4).Trim.Length - 3)
                                            .Fields("POP_Code").Value = temptable.Rows(L + 1).Item(8).ToString
                                            .Fields("PREPAID_COLLECT").Value = IIf(temptable.Rows(L).Item(7).ToString.Length > 0, "PREPAID", "COLLECT")

                                            pcb = IIf(temptable.Rows(L).Item(7).ToString.Trim.Length > 0, "PREPAID", "COLLECT")
                                            If pcb = "COLLECT" Then 'nếu COLLECT MÀ cảng trả tiền không phải ở Việt nam thì Trở Thành PREPAID
                                                Dim VNPort() As String = {"VNDAD", "VNHPH", "VNVUT", "VNSGN", "VNNHA", "VNNPT"}
                                                pcb = "PREPAID"
                                                For i As Integer = 0 To VNPort.Length - 1
                                                    If temptable.Rows(L + 1).Item(8).ToString.Trim Like "*" & VNPort(i) & "*" Then
                                                        pcb = "COLLECT"
                                                        Exit For
                                                    End If
                                                Next

                                                'If (temptable.Rows(L + 1).Item(8).ToString Like "*VNDAD*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNHPH*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNNHA*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNSGN*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNVUT*") Then
                                                '    PC = "COLLECT"
                                                'End If
                                            End If
                                            .Fields("PREPAID_COLLECT").Value = pcb
                                            .Update()
                                        End With
                                        rs.Close()
                                    End If
                                End If
                            Else
                                tempfreight = Strings.Split(temptable.Rows(L).Item(4).ToString.Trim, "/")
                                If tempfreight.Length > 1 Then
                                    Dim freight() As String
                                    Dim PC As String
                                    freight = Strings.Split(TrimSpace(tempfreight(0)), " ")
                                    If freight.Length = 5 Then
                                        strQuery = "Select * from FREIGHT_CHARGE_IB "
                                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                                        With rs
                                            .AddNew()
                                            .Fields("FREIGHT_CHARGE_IB").Value = NewId()
                                            .Fields("BLIB_ID").Value = BLIB_ID
                                            .Fields("Quantity").Value = freight(0)
                                            .Fields("CONTAINER_TYPE").Value = freight(2).Trim
                                            .Fields("Items").Value = IIf(UCase(freight(3).Trim) = "ALI", "OCB", freight(3).Trim)
                                            .Fields("CURRENCY").Value = Strings.Left(freight(4).Trim, 3)
                                            .Fields("UNITPRICE").Value = Strings.Right(freight(4).Trim, freight(4).Trim.Length - 3)
                                            .Fields("POP_CODE").Value = temptable.Rows(L + 1).Item(8).ToString

                                            PC = IIf(temptable.Rows(L).Item(7).ToString.Trim.Length > 0, "PREPAID", "COLLECT")
                                            If PC = "COLLECT" Then 'nếu COLLECT MÀ cảng trả tiền không phải ở Việt nam thì Trở Thành PREPAID
                                                Dim VNPort() As String = {"VNDAD", "VNHPH", "VNVUT", "VNSGN", "VNNHA", "VNNPT"}
                                                PC = "PREPAID"
                                                For i As Integer = 0 To VNPort.Length - 1
                                                    If temptable.Rows(L + 1).Item(8).ToString.Trim Like "*" & VNPort(i) & "*" Then
                                                        PC = "COLLECT"
                                                        Exit For
                                                    End If
                                                Next

                                                'If (temptable.Rows(L + 1).Item(8).ToString Like "*VNDAD*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNHPH*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNNHA*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNSGN*") Or (temptable.Rows(L + 1).Item(8).ToString Like "*VNVUT*") Then
                                                '    PC = "COLLECT"
                                                'End If
                                            End If

                                            .Fields("PREPAID_COLLECT").Value = PC

                                            .Update()

                                        End With
                                        rs.Close()
                                    End If
                                End If
                            End If '

                        End If
                    Next 'kết thúc thêm vào freight
                    temptable.Rows.Clear()
                    'Them Vao CSDL Bill Cuoi Cung
                    If data Then
                        Exit For
                    End If

                    'giam di mot dong vi i khi I dung thi Da qua Dong Co chu VESSEL
                    i -= 1

                End If 'kết thúc thêm vào một record

            Next

            Me.GroupBox1.Visible = False
            MsgBox("Imports Completed : import " & Imported & " Bills in " & CountBill & " Bills")
            Con.Close()
        Catch ex As Exception

            If Err.Number = 5 Then
                MsgBox("File Này Không có Sheet " & Me.txtSheetName.Text & " hay có lỗi trên Surcharges , Vui lòng check lại dòng thứ :" & i)
                MsgBox(Err.Description)
            Else
                MsgBox(Err.Description)
                MsgBox("lỗi dòng thứ " & i & " Sửa File excel đúng chuẩn rồi imports lại")
                MsgBox("nếu lỗi này tiếp tục xảy hãy tắt chương trình và  và imports lại")
            End If
            If IsNothing(BLArr) Then
                Return
            End If
            If BLArr.Length > 0 Then
                If MsgBox("Do you want to delete the Imported Bill", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    Dim Conn As New SqlClient.SqlConnection(strconnDG)
                    Conn.Open()
                    Dim Value As Double
                    Value = Count / CountBill
                    For i As Integer = 0 To BLArr.Length - 1

                        If IsNothing(BLArr(i)) Then
                            Exit For
                        End If
                        Application.DoEvents()
                        Me.prbExport.Value -= Value
                        Dim strDel As String
                        strDel = "delete From BillOfLadingIB Where BLIB_ID='" & BLArr(i) & "'"
                        Dim cmd As New SqlClient.SqlCommand("", Conn)
                        Try
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = strDel
                            cmd.ExecuteNonQuery()
                        Catch Er As Exception
                            MsgBox(Er.Message)
                        End Try
                        strDel = "delete from PRICEBILLIB where BLIB_NO='" & BLNO(i) & "'"

                        cmd = New SqlClient.SqlCommand("", Conn)
                        Try
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = strDel
                            cmd.ExecuteNonQuery()
                        Catch Er As Exception
                            MsgBox(Er.Message)
                        End Try
                    Next
                End If 'end of msgbox=yes
            End If 'end of BlArr.lenght>0
            Me.GroupBox1.Visible = False
        Finally
            Con.Close()
        End Try
        'Dim CountBill, Imported, STT As Double
        'Dim ICDPort As String = "CAT LAI"
        'Dim Con As OleDb.OleDbConnection
        'Dim BLArr() As String
        'Dim BLNO() As String
        'Dim Count As Double 'tong so dong cua file 
        'i = 0
        'Try
        '    Dim strConn, sheet As String
        '    'strConn = "Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=" & FileName & ";"
        '    ' Dim Con As New OdbcConnection(strConn)
        '    Dim dt As New DataTable
        '    Dim CmdSelect As New OleDb.OleDbCommand
        '    'Dim CmdSelect As New OdbcCommand("SELECT * FROM [Sheet1$] ", Con)
        '    'Dim Adapter As New OdbcDataAdapter(CmdSelect)
        '    strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & FileName & "; Extended Properties=""Excel 8.0;HDR=no;"""

        '    Con = New OleDb.OleDbConnection(strConn)
        '    Con.Open()
        '    If Len(Me.txtSheetName.Text.Trim) < 0 Then
        '        DisplayMessage(True, "Sheet name is invalid, please try again! ")
        '        Me.txtSheetName.Focus()
        '    End If
        '    Try
        '        CmdSelect = New OleDb.OleDbCommand("SELECT * FROM [" & Me.txtSheetName.Text.Trim & "$] ", Con)
        '    Catch ex As Exception
        '        DisplayMessage(True, "Sheet name is invalid, please try again! ")
        '        Con.Close()
        '        Exit Sub
        '    End Try

        '    Dim Adapter As New OleDb.OleDbDataAdapter(CmdSelect)

        '    Dim CmdCountBill As New OleDb.OleDbCommand("Select count(f1) as Num from [" & Me.txtSheetName.Text.Trim & "$] Where F1 like'%VESSEL%'", Con)
        '    Dim ApdapterCountBill As New OleDb.OleDbDataAdapter(CmdCountBill)
        '    Dim dtCountBill As New DataTable
        '    ApdapterCountBill.Fill(dtCountBill)

        '    'đếm số bill hiện có trong file
        '    If Not IsNothing(dtCountBill) Then
        '        CountBill = dtCountBill.Rows(0).Item("Num")
        '    End If

        '    ReDim BLArr(CountBill)
        '    ReDim BLNO(CountBill)


        '    'số dòng đã import 
        '    Imported = 0 'chưa import nên bằng 0
        '    If Not IsNothing(dt) Then
        '        dt.Clear()
        '    End If
        '    Adapter.Fill(dt)

        '    Dim temptable As New DataTable
        '    For j As Integer = 1 To 9
        '        temptable.Columns.Add(j.ToString)
        '    Next
        '    Vessel = ""
        '    VesselCode = ""
        '    VoyNo = ""
        '    Dim row As DataRow
        '    Dim strVIA As String
        '    Dim data As Boolean = False
        '    Count = dt.Rows.Count
        '    For k As Integer = 0 To Count - 1
        '        If dt.Rows(k).Item(0).ToString Like "*VESSEL*" Then
        '            data = True
        '            Exit For
        '        End If
        '    Next
        '    If data = False Then
        '        MsgBox("file Đã chọn không đúng , Hãy Chọn lại")
        '        Return
        '    End If
        '    '----- -----
        '    Me.GroupBox1.Visible = True
        '    Me.prbExport.Maximum = Count + 1
        '    For i = 0 To Count - 1 'chay toan bo file Excel
        '        System.Windows.Forms.Application.DoEvents()
        '        Me.prbExport.Value = i
        '        'If i = 30 Then
        '        '    MsgBox("30 ")
        '        'End If
        '        If i > 0 And i < Count - 1 Then
        '            If dt.Rows(i + 1).Item(0).ToString Like "*VESSEL*" Then
        '                data = Not data
        '            End If
        '        End If

        '        If dt.Rows(i).Item(0).ToString Like "*VESSEL*" Then
        '            If Vessel <> "" Then
        '                Vessel = ""
        '            End If

        '            ' if dong dau co them VIA thi ta cat bo no di
        '            If dt.Rows(i).Item(0).ToString Like "*VIA*" Then
        '                strVIA = Mid(dt.Rows(i).Item(0).ToString, 1, dt.Rows(i).Item(0).ToString.IndexOf("VIA")).Trim
        '            Else
        '                strVIA = dt.Rows(i).Item(0).ToString.Trim
        '            End If

        '            If Vessel = "" And strVIA.Trim.Length > 0 Then
        '                first = True
        '                Dim tempvessel() As String
        '                tempvessel = Strings.Split(strVIA, ":")
        '                If tempvessel.Length >= 3 Then
        '                    'Vessel = Strings.Left(tempvessel(1).Trim, tempvessel(1).Length - 7).Trim
        '                    'Dim tempVoyno() As String

        '                    'tempVoyno = Strings.Split(tempvessel(2), "SAIL")
        '                    'VoyNo = Strings.Replace(tempVoyno(0).Trim, " ", "")
        '                    'VoyNo = Strings.Replace(VoyNo, "-", "")
        '                    'VoyNo = Strings.Replace(VoyNo, "_", "")
        '                    'VoyNo = Strings.Replace(VoyNo, "/", "")
        '                    'VoyNo = Strings.Replace(VoyNo, "\", "")
        '                    Vessel = Me.cboVessel.Text.Trim
        '                    VesselCode = Me.txtVesselCode.Text.Trim
        '                    VoyNo = Me.txtVoyNo.Text.Trim

        '                    sailed = tempvessel(tempvessel.Length - 1)


        '                End If
        '                Dim j As Integer = 0

        '                If UCase(dt.Rows(i + 1).Item(0).ToString.Trim) Like "POR*" Then
        '                    j = i + 1
        '                Else
        '                    j = i + 2
        '                End If

        '                If dt.Rows(j).Item(0) Like "*POR*" Then
        '                    Dim TempPort() As String
        '                    TempPort = Strings.Split(dt.Rows(j).Item(0), ":")
        '                    If TempPort.Length > 5 Then
        '                        If TempPort(4).Trim Like "*NEW PORT*" Or TempPort(5).Trim Like "*NEW PORT*" Then ' hoi lai bao nhieu Port                            DisplayMessage(True, TempPort(4) + TempPort(5))
        '                            ICDPort = "NEW PORT"
        '                        ElseIf TempPort(4).Trim Like "*SONG THAN*" Or TempPort(5).Trim Like "*SONG THAN*" Then
        '                            ICDPort = "SONG THAN"
        '                        ElseIf TempPort(4).Trim Like "*PHUOC LONG*" Or TempPort(5).Trim Like "*PHUOC LONG*" Then
        '                            ICDPort = "PHUOC LONG"
        '                        ElseIf TempPort(4).Trim Like "*PHUC LONG*" Or TempPort(5).Trim Like "*PHUC LONG*" Then
        '                            ICDPort = "PHUC LONG"
        '                        ElseIf TempPort(4).Trim Like "*KHANH HOI*" Or TempPort(5).Trim Like "*KHANH HOI*" Then
        '                            ICDPort = "KHANH HOI"
        '                        ElseIf TempPort(4).Trim Like "*TRANSMEX*" Or TempPort(5).Trim Like "*TRANSMEX*" Then
        '                            ICDPort = "TRANSMEX"
        '                        ElseIf TempPort(4).Trim Like "*BIEN HOA*" Or TempPort(5).Trim Like "*BIEN HOA*" Then
        '                            ICDPort = "BIEN HOA"
        '                        Else
        '                            ICDPort = "CAT LAI"
        '                        End If
        '                        POR = Strings.Left(TempPort(1).Trim, TempPort(1).Trim.Length - 3).Trim
        '                        POL = Strings.Left(TempPort(2).Trim, TempPort(2).Trim.Length - 3).Trim
        '                        POD = Strings.Left(TempPort(3).Trim, TempPort(3).Trim.Length - 3).Trim
        '                        DEL = Strings.Left(TempPort(4).Trim, TempPort(4).Trim.Length - 4).Trim
        '                        DEST = (TempPort(5).Trim)
        '                    End If
        '                End If
        '            End If

        '        End If
        '        If data And i <> Count - 1 Then
        '            row = temptable.NewRow
        '            For j As Integer = 0 To 8
        '                row(j) = dt.Rows(i).Item(j).ToString
        '            Next
        '            temptable.Rows.Add(row)

        '        Else


        '            Dim rs As New ADODB.Recordset
        '            Dim strQuery As String
        '            Dim j As Integer = 0
        '            Dim Pos As Integer = 0
        '            Dim FreightPos As Integer = 0 'lưu vị trí bắt đầu chạy cũa Phí
        '            While temptable.Rows(j).Item(3).ToString = ""
        '                j += 1
        '            End While
        '            j += 3
        '            FreightPos = j 'vị trí bắt đầu chạy của phí = j
        '            BL_NO = temptable.Rows(j + 1).Item(0).ToString
        '            'If BL_NO Like "*NPT*" Then
        '            '    ICDPort = "NEW PORT"
        '            'End If
        '            If first Then
        '                strQuery = "Select * from BillOfLadingIB Where BLIB_NO='" & BL_NO & "' And Continued=1"
        '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                If Not rs.EOF Then
        '                    'MsgBox("This File had imported", MsgBoxStyle.Critical)

        '                    rs.Close()
        '                    temptable.Rows.Clear()
        '                    If i = Count - 1 Then
        '                        DisplayMessage(True, "File này đã import!")
        '                        Exit Sub
        '                    End If
        '                    MsgBox("Bill " & BL_NO & " Đã có Bill Trùng trong Dữ liệu Hãy kiểm tra lại Bill Này")
        '                    i -= 1
        '                    Continue For
        '                End If
        '                first = False
        '                rs.Close()
        '            End If
        '            'đếm có bill đã imports
        '            Imported += 1

        '            CY = temptable.Rows(j + 2).Item(0).ToString
        '            BL_Type = temptable.Rows(j + 4).Item(0).ToString.Trim
        '            'Tinh Trang container
        '            FULLORMT = "F"
        '            If BL_Type.Length = 0 Then
        '                'dong thu 2 khac null
        '                MsgBox("Bill số :" & Imported & " chứa container rỗng! vì số liệu Không chuẩn nên hãy kiểm tra lại bill này" & vbCrLf & " Ở Dòng thứ : " & i - temptable.Rows.Count)
        '                FULLORMT = "E"
        '                'BL_NO = temptable.Rows(j + 1).Item(0).ToString
        '            End If

        '            'Pos giữ lại Vị trí của BL-TYPe Chạy Hết Xuống Dứơi Cuối cùng để lấy Container
        '            Pos = j + 5


        '            Dim k As Integer  'bien chay de lay thong Description of goods var cargo Marks vi giong nhau ve vi tri dong
        '            DescriptionOfGoods = ""
        '            CargoMarks = ""
        '            Dim getMarks As Boolean = True
        '            For k = j + 1 To temptable.Rows.Count - 1
        '                DescriptionOfGoods &= temptable.Rows(k).Item(2).ToString & Chr(13)
        '                If temptable.Rows(k).Item(1).ToString Like "*/*/*" Then
        '                    getMarks = False
        '                ElseIf getMarks = True Then
        '                    CargoMarks &= temptable.Rows(k).Item(1).ToString & Chr(13)
        '                End If

        '            Next


        '            'them Vao Shipper Neu co Thi cap Nhat lai ten Con khong thi them

        '            While temptable.Rows(j).Item(3).ToString.Trim = ""
        '                j += 1
        '            End While
        '            If temptable.Rows(j).Item(3).ToString.Trim <> "" Then
        '                ShipperName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
        '            End If




        '            Dim RunRow As Integer = IIf(j + 25 > temptable.Rows.Count - 1, temptable.Rows.Count - 2, j + 20)
        '            While j < RunRow
        '                strQuery = "Select * from Shipper Where Continued=1 And Shipper_1 Like '%" & ShipperName & "%'"
        '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                If temptable.Rows(j).Item(3).ToString.Trim Like "*1)*" Then
        '                    ShipperName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
        '                    If ShipperName(0) = ")" Then
        '                        ShipperName.Remove(0, 1)
        '                    End If

        '                    Dim S As Integer = j
        '                    Dim Value As Integer = 2
        '                    Dim Remarks As String = ""
        '                    With rs
        '                        If rs.EOF Then
        '                            .AddNew()
        '                            .Fields("Shipper_ID").Value = NewId()
        '                            Dim Len As Integer = CStr(CodeNotify() + 1).Length
        '                            Dim Temp As String = "S"
        '                            For i As Integer = 0 To 7 - Len
        '                                Temp &= "0"
        '                            Next
        '                            Temp &= CStr(CodeNotify() + 1)
        '                            .Fields("Shipper_Code").Value = Temp
        '                        End If
        '                        For S = j To RunRow
        '                            If temptable.Rows(S + 1).Item(3).ToString.Trim Like "*2)*" Then
        '                                Exit For
        '                            End If
        '                            If Value <= 6 Then
        '                                .Fields("Shipper_" & Value).Value = temptable.Rows(S + 1).Item(3).ToString
        '                                Value += 1
        '                            Else
        '                                Remarks &= temptable.Rows(S + 1).Item(3).ToString
        '                            End If
        '                        Next

        '                        .Fields("Shipper_1").Value = ShipperName
        '                        .Fields("REMARKS").Value = Remarks
        '                        .Update()
        '                    End With

        '                    j = S + 1
        '                End If
        '                Shipper_ID = rs.Fields("Shipper_ID").Value
        '                rs.Close()
        '                While temptable.Rows(j).Item(3).ToString.Trim = ""
        '                    j += 1
        '                End While
        '                'them Vao Consignee Neu co Thi cap Nhat lai ten Con khong thi them
        '                If temptable.Rows(j).Item(3).ToString.Trim <> "" Then
        '                    ConsigneeName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
        '                End If

        '                strQuery = "Select * from Consignee Where Continued=1 And Consignee_1 Like '%" & ConsigneeName & "%'"
        '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                If temptable.Rows(j).Item(3).ToString.Trim Like "*2)*" Then
        '                    ConsigneeName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
        '                    If ConsigneeName(0) = ")" Then
        '                        ConsigneeName.Remove(0, 1)
        '                    End If
        '                    Dim value As Integer = 2
        '                    Dim Remarks As String = ""
        '                    Dim C As Integer

        '                    With rs
        '                        If rs.EOF Then
        '                            rs.AddNew()
        '                            .Fields("Consignee_ID").Value = NewId()
        '                            Dim Len As Integer = CStr(CodeNotify() + 1).Length
        '                            Dim Temp As String = "C"
        '                            For i As Integer = 0 To 7 - Len
        '                                Temp &= "0"
        '                            Next
        '                            Temp &= CStr(CodeNotify() + 1)
        '                            .Fields("Consignee_Code").Value = Temp
        '                        End If

        '                        For C = j To RunRow
        '                            If temptable.Rows(C + 1).Item(3).ToString.Trim Like "*3)*" Then
        '                                Exit For
        '                            End If
        '                            If value <= 6 Then
        '                                .Fields("Consignee_" & value).Value = temptable.Rows(C + 1).Item(3).ToString
        '                                value += 1
        '                            Else
        '                                Remarks &= temptable.Rows(C + 1).Item(3).ToString
        '                            End If
        '                        Next

        '                        .Fields("Consignee_1").Value = ConsigneeName
        '                        .Fields("Remarks").Value = Remarks
        '                        .Update()
        '                    End With

        '                    j = C + 1
        '                End If
        '                Consignee_ID = rs.Fields("Consignee_ID").Value
        '                rs.Close()
        '                While temptable.Rows(j).Item(3).ToString.Trim = ""
        '                    j += 1
        '                End While


        '                'them Vao Notify Neu co Thi cap Nhat lai ten Con khong thi them
        '                If temptable.Rows(j).Item(3).ToString.Trim <> "" Then
        '                    NotifyName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
        '                End If
        '                strQuery = "Select * from Notify Where Continued=1 And Notify_1 Like '%" & NotifyName & "%'"
        '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                If temptable.Rows(j).Item(3).ToString.Trim Like "*3)*" Then

        '                    NotifyName = Replace(Strings.Right(temptable.Rows(j).Item(3).ToString.Trim, temptable.Rows(j).Item(3).ToString.Length - 2), "'", """")
        '                    If NotifyName(0) = ")" Then
        '                        NotifyName.Remove(0, 1)
        '                    End If
        '                    Dim value As Integer = 2
        '                    Dim Remarks As String = ""
        '                    Dim N As Integer

        '                    With rs
        '                        If rs.EOF Then
        '                            rs.AddNew()
        '                            .Fields("Notify_ID").Value = NewId()
        '                            Dim Len As Integer = CStr(CodeNotify() + 1).Length
        '                            Dim Temp As String = "N"
        '                            For i As Integer = 0 To 7 - Len
        '                                Temp &= "0"
        '                            Next
        '                            Temp &= CStr(CodeNotify() + 1)
        '                            .Fields("Notify_Code").Value = Temp
        '                        End If

        '                        For N = j To RunRow
        '                            'If temptable.Rows(N).Item(3).ToString.Trim Like "*3)*" Then
        '                            '    Exit For
        '                            'End If
        '                            If value <= 6 Then
        '                                .Fields("Notify_" & value).Value = temptable.Rows(N + 1).Item(3).ToString
        '                                value += 1
        '                            Else
        '                                Remarks &= temptable.Rows(N + 1).Item(3).ToString
        '                            End If
        '                        Next

        '                        .Fields("Notify_1").Value = NotifyName
        '                        .Fields("Remarks").Value = Remarks
        '                        .Update()

        '                    End With

        '                    j = N
        '                End If
        '                Notify_ID = rs.Fields("Notify_ID").Value
        '                rs.Close()
        '            End While
        '            strQuery = "Select * from BillOfLadingIB Where BLIB_NO='" & BL_NO.Trim & "' and Continued=1"
        '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '            With rs
        '                If rs.EOF Then

        '                    .AddNew()
        '                    .Fields("BLIB_ID").Value = NewId()

        '                    .Fields("BLIB_NO").Value = BL_NO
        '                    '.Fields("STT").Value = STT + 1

        '                End If
        '                '-----13/07/07
        '                If UCase(DescriptionOfGoods) Like "*NEW PORT*" Or UCase(DescriptionOfGoods) Like "*NEWPORT*" Then
        '                    ICDPort = "NEW PORT"
        '                End If
        '                '-----------
        '                .Fields("SHIPPER_ID").Value = Shipper_ID
        '                .Fields("CONSIGNEE_ID").Value = Consignee_ID
        '                .Fields("NOTIFY_ID").Value = Notify_ID
        '                .Fields("Vessel").Value = Vessel
        '                .Fields("VesselCode").Value = VesselCode
        '                .Fields("Voyage").Value = VoyNo
        '                .Fields("CY_CFS_ITEM").Value = CY
        '                .Fields("Marks").Value = CargoMarks
        '                .Fields("BL_TYPE").Value = BL_Type
        '                .Fields("DESCRIPTIONOFGOODS").Value = DescriptionOfGoods
        '                .Fields("SAILINGDATE").Value = Strings.FormatDateTime(sailed, DateFormat.ShortDate)
        '                .Fields("ICDPort").Value = ICDPort
        '                .Fields("ETA").Value = Me.dtpETA.Value.Date
        '                .Fields("WeekofYear").Value = WeekOfYear()
        '                .Fields("POR").Value = POR
        '                .Fields("POL").Value = POL
        '                .Fields("POD").Value = POD
        '                .Fields("DEL").Value = DEL
        '                .Fields("DEST").Value = DEST
        '                '.Fields("Continued").Value = 1

        '                .Update()
        '                BLIB_ID = .Fields("BLIB_ID").Value
        '                BLNO(Imported - 1) = BL_NO
        '                BLArr(Imported - 1) = Strings.Replace(BLIB_ID, "}", "")
        '                BLArr(Imported - 1) = Strings.Replace(BLArr(Imported - 1), "{", "")
        '            End With
        '            rs.Close()


        '            'them vao Container Và Cargo 
        '            'If BL_NO = "8MNLSGN0013E" Then
        '            '    MsgBox("")
        '            'End If
        '            ' them cargo Marks(shipping marks)

        '            For Containerpos As Integer = Pos To temptable.Rows.Count - 1
        '                Dim rang As String
        '                rang = temptable.Rows(Containerpos).Item(0).ToString
        '                Dim ContainerKind() As String = {"20GP", "40GP", "20RF", "40RF", "40HC", "45HC", "40RH", "20OT", "40OT", "20FR", "40FR"}
        '                Dim TrueContainerKind As Boolean = False
        '                For Kind As Integer = 0 To ContainerKind.Length - 1
        '                    If UCase(rang.Trim) Like "*" & ContainerKind(Kind) & "*" Then
        '                        TrueContainerKind = True
        '                        Exit For
        '                    End If
        '                Next
        '                ' them 260607
        '                'If TrueContainerKind = False Then
        '                '    Continue For
        '                'End If
        '                If temptable.Rows(Containerpos).Item(0).ToString.Trim.Length > 2 And (TrueContainerKind) Then
        '                    Dim tempcontainer() As String
        '                    tempcontainer = Strings.Split(temptable.Rows(Containerpos).Item(0).ToString.Trim, "/")
        '                    If tempcontainer.Length = 2 Then
        '                    Else
        '                        MsgBox("Container đinh dạng không chuẩn ở dòng thứ " & i - temptable.Rows.Count + Containerpos & " trong file có tên :" & FileName & vbCrLf & "                          hãy  Kiểm tra lại , dữ liệu có thể không chính xác")
        '                    End If
        '                    strQuery = "Select * from Container Where CONTAINER_NO='" & tempcontainer(0).Trim & "' And Continued=1"
        '                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                    If rs.EOF Then
        '                        With rs
        '                            rs.AddNew()
        '                            .Fields("CTN_ID").Value = NewId()
        '                            .Fields("CONTAINER_NO").Value = tempcontainer(0).Trim
        '                            .Fields("CTN_SIZE_TYPE").Value = tempcontainer(1).Trim
        '                            If tempcontainer(1).Trim = "20GP" Then
        '                                .Fields("NETWEIGHT").Value = 2250
        '                            ElseIf tempcontainer(1).Trim = "40GP" Then
        '                                .Fields("NETWEIGHT").Value = 6650
        '                            ElseIf tempcontainer(1).Trim = "40HC" Then
        '                                .Fields("NETWEIGHT").Value = 3890
        '                            ElseIf tempcontainer(1).Trim = "40RH" Then
        '                                .Fields("NETWEIGHT").Value = 5100
        '                            ElseIf tempcontainer(1).Trim = "20RF" Then
        '                                .Fields("NETWEIGHT").Value = 3030
        '                                'ElseIf tempcontainer(1).Trim = "20OT" Then
        '                                '    .Fields("NETWEIGHT").Value = 0
        '                                'ElseIf tempcontainer(1).Trim = "20OT" Then
        '                                '    .Fields("NETWEIGHT").Value = 0
        '                                'ElseIf tempcontainer(1).Trim = "20OT" Then
        '                                '    .Fields("NETWEIGHT").Value = 0
        '                                'ElseIf tempcontainer(1).Trim = "20OT" Then
        '                                '    .Fields("NETWEIGHT").Value = 0
        '                            Else
        '                                .Fields("NETWEIGHT").Value = 0
        '                            End If
        '                            .Update()
        '                        End With
        '                    End If
        '                    ContainerID = rs.Fields("CTN_ID").Value
        '                    rs.Close()

        '                    Dim Cargo(), mCargo_IB_ID As String
        '                    Cargo = Strings.Split(temptable.Rows(Containerpos).Item(1).ToString, "/")

        '                    strQuery = "Select * from CargoIB "
        '                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                    rs.AddNew()
        '                    mCargo_IB_ID = NewId()
        '                    rs.Fields("CargoIB_ID").Value = mCargo_IB_ID
        '                    rs.Fields("BLIB_ID").Value = BLIB_ID
        '                    rs.Fields("CTN_ID").Value = ContainerID
        '                    rs.Fields("Container_Type").Value = tempcontainer(1).Trim
        '                    ' rs.Fields("CARGOMARKS").Value = CargoMarks


        '                    Dim MeasCargo() As String
        '                    Dim Gross() As String
        '                    If Cargo.Length = 9 Then ' If Cargo.Length = 9 And BL_Type <> "" Then if la container rong thi ko dua vao csdl

        '                        Seal = IIf(Cargo(1).Trim.Length = 0, " ", Cargo(1).Trim)
        '                        CarryKind = IIf(Cargo(3).Trim.Length = 0, " ", Cargo(3).Trim)
        '                        ReceiveKind = IIf(Cargo(4).Trim.Length = 0, " ", Cargo(4).Trim)


        '                        Gross = Strings.Split(TrimSpace(Cargo(5)), " ")
        '                        'If Gross.Length = 2 Then
        '                        '    Amount = Gross(0)
        '                        '    Kind = Gross(1).Trim
        '                        'Else
        '                        chiaCont(TrimSpace(Cargo(5)), Amount, Kind)
        '                        'End If

        '                        'Dim WeightCargo() As String
        '                        weight = IIf(Strings.Left(Cargo(6).Trim, Cargo(6).Trim.Length - 3) = "", 0, Strings.FormatNumber(Strings.Left(Cargo(6).Trim, Cargo(6).Trim.Length - 3), 2))
        '                        WeightUnit = Strings.Right(Cargo(6).Trim, 3)


        '                        MeasCargo = Strings.Split(TrimSpace(Cargo(8)), " ")
        '                        If MeasCargo.Length = 2 Then
        '                            Meas = MeasCargo(0)
        '                            MeasUnit = MeasCargo(1).Trim
        '                        Else
        '                            Meas = 0
        '                            MeasUnit = ""
        '                        End If

        '                        'them Vào Cargo 
        '                        With rs
        '                            .Fields("SEAL").Value = Seal
        '                            .Fields("CARRIERKIND").Value = CarryKind
        '                            .Fields("RECEIVEKIND").Value = ReceiveKind
        '                            .Fields("AMOUNT").Value = Amount
        '                            .Fields("KIND").Value = Kind
        '                            .Fields("GROSSWEIGHT").Value = weight
        '                            .Fields("GrossUnit").Value = WeightUnit
        '                            .Fields("MEAS").Value = Meas
        '                            .Fields("MEASUNIT").Value = MeasUnit
        '                        End With
        '                        CargoIb_ID = rs.Fields("CargoIB_ID").Value
        '                        '--------------
        '                    ElseIf Cargo.Length = 8 Then

        '                        Seal = IIf(Cargo(1).Trim.Length = 0, " ", Cargo(1).Trim) ' SEAL
        '                        ReceiveKind = IIf(Cargo(2).Trim.Length = 0, " ", Cargo(2).Trim) ' FCL
        '                        CarryKind = IIf(Cargo(3).Trim.Length = 0, " ", Cargo(3).Trim) 'COC



        '                        Gross = Strings.Split(TrimSpace(Cargo(4)), " ") ' CONT , LOAI 

        '                        'If Gross.Length = 2 Then
        '                        '    Amount = Gross(0)
        '                        '    Kind = Gross(1).Trim
        '                        'Else
        '                        chiaCont(TrimSpace(Cargo(4)), Amount, Kind)
        '                        'End If

        '                        'Dim WeightCargo() As String
        '                        weight = IIf(Strings.Left(Cargo(5).Trim, Cargo(5).Trim.Length - 3) = "", 0, Strings.FormatNumber(Strings.Left(Cargo(5).Trim, Cargo(5).Trim.Length - 3), 2))
        '                        WeightUnit = Strings.Right(Cargo(5).Trim, 3)


        '                        MeasCargo = Strings.Split(TrimSpace(Cargo(7)), " ")
        '                        If MeasCargo.Length = 2 Then
        '                            Meas = MeasCargo(0)
        '                            MeasUnit = MeasCargo(1).Trim
        '                        Else
        '                            Meas = 0
        '                            MeasUnit = ""
        '                        End If

        '                        'them Vào Cargo 
        '                        With rs
        '                            .Fields("SEAL").Value = Seal
        '                            .Fields("CARRIERKIND").Value = CarryKind
        '                            .Fields("RECEIVEKIND").Value = ReceiveKind
        '                            .Fields("AMOUNT").Value = Amount
        '                            .Fields("KIND").Value = Kind
        '                            .Fields("GROSSWEIGHT").Value = weight
        '                            .Fields("GrossUnit").Value = WeightUnit
        '                            .Fields("MEAS").Value = Meas
        '                            .Fields("MEASUNIT").Value = MeasUnit
        '                        End With
        '                        CargoIb_ID = rs.Fields("CargoIB_ID").Value
        '                    End If
        '                    '-------------
        '                    rs.Update()
        '                    rs.Close()
        '                    ' insert vao ContainerManagerment
        '                    InsertContainerMNG(mCargo_IB_ID, BL_NO, POL, Vessel, VoyNo, Me.dtpETA.Value.Date, ICDPort, "Add", tempcontainer(0).Trim, tempcontainer(1).Trim)
        '                    'chay tren bang Freight charge
        '                End If
        '            Next
        '            'If BL_NO = "8SHASGN3BR409" Then
        '            '    BL_NO = "8SHASGN3BR409"
        '            'End If

        '            For L As Integer = FreightPos To temptable.Rows.Count - 1
        '                Dim rang As String
        '                rang = temptable.Rows(L).Item(4).ToString
        '                If temptable.Rows(L).Item(4).ToString.Length > 0 And (rang Like "*20GP*" Or rang Like "*40GP*" Or rang Like "*40HC*" Or rang Like "*20RF*" Or rang Like "*40RF*" Or rang Like "*40RH*" Or rang Like "*45HC*") Then
        '                    Dim tempfreight() As String
        '                    If temptable.Rows(L).Item(4).ToString.Trim Like "*B/L*" Then
        '                        tempfreight = Strings.Split(temptable.Rows(L).Item(4).ToString.Trim, "/")
        '                        If tempfreight.Length = 3 Then
        '                            Dim freight() As String
        '                            freight = Strings.Split(TrimSpace(temptable.Rows(L).Item(4).ToString.Trim), " ")
        '                            If freight.Length >= 5 Then
        '                                strQuery = "Select * from PriceBillIB "
        '                                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                                With rs
        '                                    .AddNew()
        '                                    .Fields("PriceBillIB_ID").Value = NewId()
        '                                    .Fields("BLIB_NO").Value = BL_NO
        '                                    .Fields("Quantity").Value = freight(0)
        '                                    .Fields("BillType").Value = freight(2).Trim
        '                                    .Fields("Items").Value = freight(3).Trim
        '                                    .Fields("Currency").Value = Strings.Left(freight(4).Trim, 3)
        '                                    .Fields("UnitPrice").Value = Strings.Right(freight(4).Trim, freight(4).Trim.Length - 3)
        '                                    .Fields("POP_Code").Value = temptable.Rows(L + 1).Item(8).ToString
        '                                    .Fields("PREPAID_COLLECT").Value = IIf(temptable.Rows(L).Item(7).ToString.Length > 0, "PREPAID", "COLLECT")
        '                                    .Update()
        '                                End With
        '                                rs.Close()
        '                            End If
        '                        End If
        '                    Else
        '                        tempfreight = Strings.Split(temptable.Rows(L).Item(4).ToString.Trim, "/")
        '                        If tempfreight.Length > 1 Then
        '                            Dim freight() As String
        '                            freight = Strings.Split(TrimSpace(tempfreight(0)), " ")
        '                            If freight.Length = 5 Then
        '                                strQuery = "Select * from FREIGHT_CHARGE_IB "
        '                                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                                With rs
        '                                    .AddNew()
        '                                    .Fields("FREIGHT_CHARGE_IB").Value = NewId()
        '                                    .Fields("BLIB_ID").Value = BLIB_ID
        '                                    .Fields("Quantity").Value = freight(0)
        '                                    .Fields("CONTAINER_TYPE").Value = freight(2).Trim
        '                                    .Fields("Items").Value = freight(3).Trim
        '                                    .Fields("CURRENCY").Value = Strings.Left(freight(4).Trim, 3)
        '                                    .Fields("UNITPRICE").Value = Strings.Right(freight(4).Trim, freight(4).Trim.Length - 3)
        '                                    .Fields("POP_CODE").Value = temptable.Rows(L + 1).Item(8).ToString
        '                                    .Fields("PREPAID_COLLECT").Value = IIf(temptable.Rows(L).Item(7).ToString.Length > 0, "PREPAID", "COLLECT")
        '                                    .Update()

        '                                End With
        '                                rs.Close()
        '                            End If
        '                        End If
        '                    End If '

        '                End If
        '            Next 'kết thúc thêm vào freight
        '            temptable.Rows.Clear()
        '            'Them Vao CSDL Bill Cuoi Cung
        '            If data Then
        '                Exit For
        '            End If

        '            'giam di mot dong vi i khi I dung thi Da qua Dong Co chu VESSEL
        '            i -= 1

        '        End If 'kết thúc thêm vào một record

        '    Next

        '    Me.GroupBox1.Visible = False
        '    MsgBox("Imports Completed : import " & Imported & " Bills in " & CountBill & " Bills")
        '    Con.Close()
        'Catch ex As Exception

        '    If Err.Number = 5 Then
        '        MsgBox("File Này Không có " & Me.txtSheetName.Text)
        '        MsgBox(Err.Description)
        '    Else
        '        MsgBox(Err.Description)
        '        MsgBox("lỗi dòng thứ " & i & " Sửa File excel đúng chuẩn rồi imports lại")
        '        MsgBox("nếu lỗi này tiếp tục xảy hãy tắt chương trình và  và imports lại")
        '    End If
        '    If IsNothing(BLArr) Then
        '        Return
        '    End If
        '    If BLArr.Length > 0 Then
        '        If MsgBox("Do you want to delete the Imported Bill", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
        '            Dim Conn As New SqlClient.SqlConnection(strconnDG)
        '            Conn.Open()
        '            Dim Value As Double
        '            Value = Count / CountBill
        '            For i As Integer = 0 To BLArr.Length - 1

        '                If IsNothing(BLArr(i)) Then
        '                    Exit For
        '                End If
        '                Application.DoEvents()
        '                Me.prbExport.Value -= Value
        '                Dim strDel As String
        '                strDel = "delete From BillOfLadingIB Where BLIB_ID='" & BLArr(i) & "'"
        '                Dim cmd As New SqlClient.SqlCommand("", Conn)
        '                Try
        '                    cmd.CommandType = CommandType.Text
        '                    cmd.CommandText = strDel
        '                    cmd.ExecuteNonQuery()
        '                Catch Er As Exception
        '                    MsgBox(Er.Message)
        '                End Try
        '                strDel = "delete from PRICEBILLIB where BLIB_NO='" & BLNO(i) & "'"

        '                cmd = New SqlClient.SqlCommand("", Conn)
        '                Try
        '                    cmd.CommandType = CommandType.Text
        '                    cmd.CommandText = strDel
        '                    cmd.ExecuteNonQuery()
        '                Catch Er As Exception
        '                    MsgBox(Er.Message)
        '                End Try
        '            Next
        '        End If 'end of msgbox=yes
        '    End If 'end of BlArr.lenght>0
        '    Me.GroupBox1.Visible = False
        'Finally
        '    Con.Close()
        'End Try
    End Sub
    Sub InsertContainerMNG(ByVal mCargoIB_ID As String, ByVal BL_NO_Inbound As String, ByVal POL As String, ByVal Vessel As String, ByVal VoyNo As String, ByVal ETA As Date, ByVal ICDPort As String, ByVal mStatus As String, ByVal ContainerNo As String, ByVal ContainerType As String)
        On Error GoTo Err
        Dim strQuery, strQueryPartOf As String
        Dim rs, rsCheckPartOf As New ADODB.Recordset
        Dim dt As New DataTable
        'lay du lieu trong bang Billoflading IB de vao dt
        'If UCase(BL_NO_Inbound) Like "*PNH*" Then
        '    Return
        'End If
        '--- check part of
        strQueryPartOf = "SELECT * "
        strQueryPartOf = strQueryPartOf & "FROM ContainerManagerment  Where replace(voyno_inbound,' ','')  ='" & VoyNo.Trim & "' And Container_No ='" & ContainerNo & "' And Continued=1 and day(Arrival_Date)='" & ETA.Day & "' and month(Arrival_Date)='" & ETA.Month & "' and year(Arrival_Date)='" & ETA.Year & "'"
        rsCheckPartOf.Open(strQueryPartOf, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rsCheckPartOf.EOF Then
            'DisplayMessage(True, "Container : '" & ContainerNo & "' is Part Of Cont., or This Cont has inputed.")
            rsCheckPartOf.Close()
            Return
        End If
        rsCheckPartOf.Close()


        '----
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM ContainerManagerment  Where BL_NO_Inbound ='" & BL_NO_Inbound & "' And Container_No ='" & ContainerNo & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            rs.AddNew()
            rs.Fields("ContainerManagementID").Value = NewId()
        End If
        With rs
            'If mStatus = "Add" Then
            .Fields("CargoIB_ID").Value = mCargoIB_ID
            .Fields("BL_NO_Inbound").Value = BL_NO_Inbound
            .Fields("TS_AHR").Value = POL
            .Fields("Vessel_Inbound").Value = Vessel
            .Fields("VoyNo_Inbound").Value = VoyNo
            .Fields("Arrival_Date").Value = ETA
            .Fields("DisCharge_Date").Value = ETA ' lay chung voi Arrival date

            .Fields("SoundContainer").Value = 0
            .Fields("ToBeInSpected").Value = 0
            .Fields("DamageContainer").Value = 0
            .Fields("FullImport").Value = 0
            .Fields("FullToConsignee").Value = 0
            .Fields("FullExport").Value = 0
            .Fields("EmptyToShipper").Value = 0
            .Fields("EmptyContainerReposit").Value = 0
            .Fields("ICDPort").Value = ICDPort
            .Fields("ImportCY").Value = ICDPort
            .Fields("FinalICD").Value = .Fields("ImportCY").Value
            .Fields("FullOrEmpty").Value = FULLORMT

            If FULLORMT = "E" Then
                .Fields("SoundContainer").Value = 1
                .Fields("EMPTYCY").Value = ICDPort
                .Fields("finalICD").Value = ICDPort
                .Fields("FactOfDelDate").Value = ETA
                .Fields("FactOfReDelDate").Value = ETA
            Else
                .Fields("FullImport").Value = 1
                .Fields("IMPORTCY").Value = ICDPort
                .Fields("finalICD").Value = ICDPort

            End If

            .Fields("Container_No").Value = ContainerNo
            .Fields("CTN_SIZE_TYPE").Value = ContainerType
            .Update()
        End With

        rs.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryVessel()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strSQL As String = "Select Vessel,Vessel_Code From Vessel where Continued=1 Order By Vessel"
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim dt As New DataTable
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Adapter.Fill(dt)
            Me.cboVessel.DisplayMember = "Vessel"
            Me.cboVessel.ValueMember = "Vessel_Code"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmImportInboundData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err
        'Me.GroupBox1.Left = Me.Width / 2 - Me.GroupBox1.Width / 2
        'Me.GroupBox1.Top = Me.Height / 2 - Me.GroupBox1.Height / 2
        If Transit = 1 Then
            Me.Text = "Import database (Transit) "
        Else
            Me.Text = "Import database (Inbound)"
        End If
        QueryVessel()

        Exit Sub
Err:
    End Sub
    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        On Error GoTo Err
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileName = Me.OpenFileDialog1.FileName
            Me.txtFileName.Text = FileName
        End If
        Exit Sub
Err:
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If Me.txtFileName.Text = "" Then
            MsgBox("nhấp Browser Chon file trước khi Ok.")
            Return
        End If
        If Me.txtSheetName.Text = "" Then
            MsgBox("Nhập Vào tên Sheet trong file đã chọn.")
            Return
        End If
        QueryInboundData()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim frm As New MANIFEST
        frm.ShowDialog(Me)
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Me.txtVesselCode.Text = Me.cboVessel.SelectedValue.ToString
    End Sub
End Class