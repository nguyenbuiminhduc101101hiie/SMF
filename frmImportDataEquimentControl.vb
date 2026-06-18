Imports system.Data.Odbc
Imports System.IO
Imports System.Text
Imports System.Globalization
Public Class frmImportDataEquimentControl
    'để chạy đựơc phải bật chế độ multilanguage
    Dim FileName As String
    Dim Vessel, VoyNo, VesselCode As String
    Dim sailed As Date
    Dim POR, POL, POD, DEL, DEST, Shipper_ID, Consignee_ID, Notify_ID, DescriptionOfGoods, CargoMarks, ShipperName, ConsigneeName, NotifyName As String
    Dim BL_NO, BL_Type, CY, WeightUnit, ContainerID, BLIB_ID, CargoIb_ID, MeasUnit, CarryKind, Seal, ReceiveKind, Kind, FULLORMT As String
    Dim first As Boolean
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
    Function TrimSpace(ByRef temp As String) As String
        Dim i As Integer = 0
        Dim value As String = ""
        temp = temp.Trim()
        Dim len As Integer = temp.Length
        i = InStr(temp, "  ")
        While i > 0
            temp = temp.Remove(i, 1)
            i = InStr(temp, "  ")
        End While
        Return temp
    End Function

    Function TrimAllSpace(ByRef temp As String) As String
        Dim i As Integer = 0
        Dim value As String = ""
        temp = temp.Trim()
        Dim len As Integer = temp.Length
        i = InStr(temp, " ")
        While i > 0
            temp = temp.Remove(i - 1, 1)
            i = InStr(temp, " ")
        End While
        Return temp
    End Function

    Function TrimMidLine(ByRef temp As String) As String
        Dim i As Integer = 0
        Dim value As String = ""
        temp = temp.Trim()
        Dim len As Integer = temp.Length
        i = InStr(temp, "-")
        While i > 0
            temp = temp.Remove(i - 1, 1)
            i = InStr(temp, "-")
        End While
        Return temp
    End Function
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
    Sub QueryInboundData()
        Dim CountBill, Imported As Double
        Dim ICDPort As String = "CAT LAI"
        Dim Con As OleDb.OleDbConnection
        Dim BLArr() As String
        Dim BLNO() As String
        Dim Count As Double 'tong so dong cua file 
        i = 0
        Try
            Dim strConnE, sheet As String
            'strConn = "Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=" & FileName & ";"
            ' Dim Con As New OdbcConnection(strConn)
            Dim dt As New DataTable
            Dim CmdSelect As New OleDb.OleDbCommand
            'Dim CmdSelect As New OdbcCommand("SELECT * FROM [Sheet1$] ", Con)
            'Dim Adapter As New OdbcDataAdapter(CmdSelect)
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & FileName & "; Extended Properties=""Excel 8.0;HDR=no;"""

            Con = New OleDb.OleDbConnection(strConnE)
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
            Dim STT As Integer

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

                        If dt.Rows(j).Item(0) Like "*POR*" Then
                            Dim TempPort() As String
                            TempPort = Strings.Split(dt.Rows(j).Item(0), ":")
                            If TempPort.Length > 5 Then
                                If TempPort(4).Trim Like "*NEW PORT*" Or TempPort(5).Trim Like "*NEW PORT*" Then ' hoi lai bao nhieu Port                            DisplayMessage(True, TempPort(4) + TempPort(5))
                                    ICDPort = "NEW PORT"
                                ElseIf TempPort(4).Trim Like "*SONG THAN*" Or TempPort(5).Trim Like "*SONG THAN*" Then
                                    ICDPort = "SONG THAN"
                                ElseIf TempPort(4).Trim Like "*PHUOC LONG*" Or TempPort(5).Trim Like "*PHUOC LONG*" Then
                                    ICDPort = "PHUOC LONG"
                                ElseIf TempPort(4).Trim Like "*PHUC LONG*" Or TempPort(5).Trim Like "*PHUC LONG*" Then
                                    ICDPort = "PHUC LONG"
                                ElseIf TempPort(4).Trim Like "*KHANH HOI*" Or TempPort(5).Trim Like "*KHANH HOI*" Then
                                    ICDPort = "KHANH HOI"
                                ElseIf TempPort(4).Trim Like "*TRANSMEX*" Or TempPort(5).Trim Like "*TRANSMEX*" Then
                                    ICDPort = "TRANSMEX"
                                ElseIf TempPort(4).Trim Like "*BIEN HOA*" Or TempPort(5).Trim Like "*BIEN HOA*" Then
                                    ICDPort = "BIEN HOA"
                                Else
                                    ICDPort = "CAT LAI"
                                End If
                                POR = Strings.Left(TempPort(1).Trim, TempPort(1).Trim.Length - 3).Trim
                                POL = Strings.Left(TempPort(2).Trim, TempPort(2).Trim.Length - 3).Trim
                                POD = Strings.Left(TempPort(3).Trim, TempPort(3).Trim.Length - 3).Trim
                                DEL = Strings.Left(TempPort(4).Trim, TempPort(4).Trim.Length - 4).Trim
                                DEST = (TempPort(5).Trim)
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
                    If UCase(BL_NO) Like "*ISSUE*DATE*" Then
                        BL_NO = temptable.Rows(j + 2).Item(0).ToString
                    End If
                    'If BL_NO Like "*NPT*" Then
                    '    ICDPort = "NEW PORT"
                    'End If
                    If first Then
                        strQuery = "Select * from ContainerManagerment Where BL_NO_Inbound='" & BL_NO & "' And Continued=1"
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
                    FULLORMT = "E"


                    'Pos giữ lại Vị trí của BL-TYPe Chạy Hết Xuống Dứơi Cuối cùng để lấy Container
                    Pos = j + 5




                    For Containerpos As Integer = Pos To temptable.Rows.Count - 1
                        Dim rang As String
                        rang = temptable.Rows(Containerpos).Item(0).ToString
                        Dim ContainerKind() As String = {"20GP", "40GP", "20RF", "40RF", "40HC", "45HC", "40RH", "20OT", "40OT", "20FR", "40FR"}
                        Dim TrueContainerKind As Boolean = False
                        For Kind As Integer = 0 To ContainerKind.Length - 1
                            If UCase(rang.Trim) Like "*" & ContainerKind(Kind) & "*" Then
                                TrueContainerKind = True
                                Exit For
                            End If
                        Next
                        'them(260607)
                        If TrueContainerKind = False Then
                            Continue For
                        End If
                        If temptable.Rows(Containerpos).Item(0).ToString.Trim.Length > 2 And (TrueContainerKind) Then
                            Dim tempcontainer() As String
                            tempcontainer = Strings.Split(temptable.Rows(Containerpos).Item(0).ToString.Trim, "/")
                            If tempcontainer.Length = 2 Then
                            Else
                                MsgBox("Container đinh dạng không chuẩn ở dòng thứ " & i - temptable.Rows.Count + Containerpos & " trong file có tên :" & FileName & vbCrLf & "                          hãy  Kiểm tra lại , dữ liệu có thể không chính xác")
                            End If


                            Dim Cargo(), mCargo_IB_ID As String

                            ' insert vao ContainerManagerment
                            InsertContainerMNG(mCargo_IB_ID, BL_NO, POL, Vessel, VoyNo, Me.dtpETA.Value.Date, ICDPort, "Add", tempcontainer(0).Trim, tempcontainer(1).Trim)
                            BLNO(Imported - 1) = BL_NO
                            BLArr(Imported - 1) = Strings.Replace(BLIB_ID, "}", "")
                            BLArr(Imported - 1) = Strings.Replace(BLArr(Imported - 1), "{", "")
                            'chay tren bang Freight charge
                        End If
                    Next

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
                MsgBox("File Này Không có " & Me.txtSheetName.Text)
                MsgBox(Err.Description)
            Else
                MsgBox(Err.Description)
                MsgBox("lỗi dòng thứ " & i & " Sửa File excel đúng chuẩn rồi imports lại")
                MsgBox("nếu lỗi này tiếp tục xảy hãy tắt chương trình và  và imports lại")
            End If
            If IsNothing(BLNO) Then
                Return
            End If
            If BLNO.Length > 0 Then
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
                        strDel = "delete From ContainerManagerment Where BL_NO_Inbound='" & BLNO(i) & "'"
                        Dim cmd As New SqlClient.SqlCommand("", Conn)
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

    End Sub
    Sub InsertContainerMNG(ByVal mCargoIB_ID As String, ByVal BL_NO_Inbound As String, ByVal POL As String, ByVal Vessel As String, ByVal VoyNo As String, ByVal ETA As Date, ByVal ICDPort As String, ByVal mStatus As String, ByVal ContainerNo As String, ByVal ContainerType As String)
        On Error GoTo Err
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim dt As New DataTable
        'lay du lieu trong bang Billoflading IB de vao dt

        strQuery = "SELECT * "
        strQuery = strQuery & "FROM ContainerManagerment  Where BL_NO_Inbound ='" & BL_NO_Inbound & "' And Container_No ='" & ContainerNo & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            With rs
                If mStatus = "Add" Then
                    .AddNew()
                    .Fields("ContainerManagementID").Value = NewId()
                    .Fields("CargoIB_ID").Value = mCargoIB_ID
                    .Fields("BL_NO_Inbound").Value = BL_NO_Inbound
                    .Fields("TS_AHR").Value = POL
                    .Fields("Vessel_Inbound").Value = Vessel
                    .Fields("VoyNo_Inbound").Value = VoyNo
                    .Fields("Arrival_Date").Value = ETA
                    .Fields("DisCharge_Date").Value = ETA ' lay chung voi Arrival date
                    .Fields("SoundContainer").Value = 1
                    .Fields("ToBeInSpected").Value = False
                    .Fields("DamageContainer").Value = False
                    .Fields("FullImport").Value = False
                    .Fields("FullToConsignee").Value = False
                    .Fields("FullExport").Value = False
                    .Fields("EmptyToShipper").Value = False
                    .Fields("EmptyContainerReposit").Value = False
                    .Fields("ICDPort").Value = ICDPort
                    .Fields("ImportCY").Value = ICDPort
                    .Fields("FullOrEmpty").Value = "E"

                End If
                .Fields("Container_No").Value = ContainerNo
                .Fields("CTN_SIZE_TYPE").Value = ContainerType
                .Update()
            End With
        End If
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