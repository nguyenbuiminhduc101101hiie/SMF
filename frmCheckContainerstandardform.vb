Imports System.IO
Imports System.Globalization
Public Class frmCheckContainerstandardform

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtFilename.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Function GetDemReduce(ByVal BLIB_NO As String, ByVal ContainerNO As String) As Double
        Try
            Dim SQL As String
            SQL = "select DemDays From DemDetReduce Where BLIB_NO='" & BLIB_NO.Trim & "' And Container_No='" & ContainerNO & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            Return dt.Rows(0).Item("DemDays")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function GetDetReduce(ByVal BLIB_NO As String, ByVal ContainerNO As String) As Double
        Try
            Dim SQL As String 'nếu dem giảm thi 1 det giảm 1 thi correction Redeldate phải giảm bàng tổng (dem,det)
            SQL = "select DemDays + DetDays as DetDays From DemDetReduce Where BLIB_NO='" & BLIB_NO.Trim & "' And Container_No='" & ContainerNO & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            Return dt.Rows(0).Item("DetDays")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub CheckContainerStatus(ByVal fname As String, ByVal sheet As String)
        Dim i, h As Integer
        Dim conn As New OleDb.OleDbConnection()
        Try

            'đếm số container có trong file
            Dim strConne As String
            Dim dt As New DataTable
            Dim CmdSelect As New OleDb.OleDbCommand
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & fname & "; Extended Properties=""Excel 8.0;HDR=no;"""
            conn = New OleDb.OleDbConnection(strConne)
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
            Dim row As Integer = 0
            Dim rs As New ADODB.Recordset
            '----GHI VAO FILE KIEM TRA
            Dim path As String

            Dim tempDir As String = System.Environment.GetEnvironmentVariable("TEMP") + ""
            path = tempDir + Now().ToString.Replace("-", "").Replace(":", "") + ".TXT"
            Dim fw As New StreamWriter(path, False)
            '-------------------------
            Try

                Dim SQL As String


                h = 0
                i = 3
                Dim EndOfFile As Boolean = True
                While (1)  'nếu chưa hết file thì tiếp tục chạy 
                    Me.pgbCheck.Value += 1

                    Dim containerNo, BLNO As String
                    If IsNothing(ws.Range("C" & i).Value) Then
                        Exit While
                    End If
                    containerNo = ws.Range("C" & i).Value
                    containerNo = Strings.Replace(containerNo, " ", "") '
                    Dim InDB As Boolean = False
                    InDB = True
                    SQL = "select * From CONTAINERMANAGERMENT where container_no = '" & containerNo & "' And (DateOfOnboard Is NULL or DateOfOnboard = ' ' ) and continued=1"
                    rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If Not rs.EOF Then


                            Dim CY, importcy As String
                            CY = ""
                            importcy = ""
                            Dim dtICD As New DataTable
                            dtICD = GetICD()
                            For R As Integer = 0 To dtICD.Rows.Count - 1
                                If UCase(dtICD.Rows(R).Item("Code")).ToString.Trim = UCase(ws.Range("B" & i).Value).ToString.Trim Then 'i là dòng của Excel,R là dòng của datatable
                                    CY = dtICD.Rows(R).Item("TerminalName").ToString
                                    'importcy = CY
                                    Exit For
                                End If
                            Next
                            If CY = "" Then
                                MsgBox("Check The ICD Again : [" & ws.Range("B" & i).Value & "]  Not In database")
                            End If


                            If ws.Range("F" & i).Value <> "" Then
                                .Fields("ConditionofContainerAT_MT_CYDetail").Value = ws.Range("F" & i).Value
                            End If
                            If ws.Range("G" & i).Value <> "" Then
                                .Fields("ConditionofContainerAT_MT_Out").Value = ws.Range("G" & i).Value
                            End If
                            Dim status() As String = {"fullimport", "fulltoconsignee", "soundcontainer", "emptytoshipper", "fullexport"}
                            Dim check As Boolean = True
                            If ws.Range("E" & i).Value <> "" Then
                                .Fields("code").Value = ws.Range("E" & i).Value
                            End If
                            Select Case ws.Range("E" & i).Value
                                Case "FIAQ"
                                    If .Fields("soundcontainer").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0

                                    ElseIf .Fields("fulltoconsignee").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0

                                    ElseIf .Fields("emptytoshipper").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    ElseIf .Fields("fullexport").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    Else
                                        .Fields("fullimport").Value = 1
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    End If

                                    '.Fields("Arrival_Date").Value = ws.Range("C" & i).Value
                                    .Fields("DisCharge_Date").Value = ws.Range("D" & i).Value

                                    .Fields("Arrival_date").Value = ws.Range("D" & i).Value
                                Case "STCO" '"FTCN" full to consinee
                                    If .Fields("soundcontainer").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0

                                    ElseIf .Fields("emptytoshipper").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0

                                    ElseIf .Fields("fullexport").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0

                                    Else
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 1
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    End If

                                    '.Fields("fulltoconsignee").Value = 1
                                    '.Fields("fullimport").Value = 0
                                    '.Fields("soundcontainer").Value = 0
                                    '.Fields("emptytoshipper").Value = 0
                                    '.Fields("fullexport").Value = 0
                                    '.Fields("EmptyExportQuay").Value = 0
                                    '---- kiem tra trang thai truoc do
                                    If .Fields("Arrival_Date").Value.ToString = "" Then
                                        fw.WriteLine("Please check another status for this container : " + containerNo)
                                    End If
                                    .Fields("FactOfDelDate").Value = ws.Range("D" & i).Value
                                    Dim dat As Date
                                    dat = ws.Range("D" & i).Value
                                    If Not IsNothing(dat) Then
                                        .Fields("CorrectionOfDELDate").Value = Date.FromOADate(dat.ToOADate - GetDemReduce(.Fields("BL_NO_Inbound").Value.ToString, containerNo)).Date
                                    Else
                                        .Fields("CorrectionOfDELDate").Value = .Fields("FactOfDelDate").Value
                                    End If

                                Case "RCVE" '"SC" ha rong ve bai
                                    .Fields("emptyCY").Value = CY
                                    .Fields("finalICD").Value = CY

                                    If .Fields("emptytoshipper").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                        ''''''riêng đối với SoundContainer
                                        .Fields("ConditionOfContainerAT_MT_CY").Value = "S"
                                        If ws.Range("F" & i).Value <> "" Then
                                            .Fields("ConditionOfContainerAT_MT_CYDetail").Value = ws.Range("F" & i).Value
                                        End If

                                    ElseIf .Fields("fullexport").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    Else
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 1
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    End If

                                    '.Fields("soundcontainer").Value = 1
                                    '.Fields("fullimport").Value = 0
                                    '.Fields("fulltoconsignee").Value = 0
                                    '.Fields("emptytoshipper").Value = 0
                                    '.Fields("fullexport").Value = 0
                                    '.Fields("EmptyExportQuay").Value = 0
                                    '.Fields("FactOfDelDate").Value = ws.Range("D" & i).Value
                                    '----kiem tra trang thai truoc do
                                    If .Fields("FactOfDelDate").Value.ToString = "" Then
                                        fw.WriteLine("Please check another status for this container : " + containerNo)
                                    End If
                                    '----kiem tra tra rong ve bai
                                    If .Fields("FactOfReDelDate").Value.ToString <> "" Then
                                        fw.WriteLine("Please check status of cotainer (It's Empty return.): " + containerNo + "     " + .Fields("FactOfReDelDate").Value.ToString)
                                    Else
                                        .Fields("FactOfReDelDate").Value = ws.Range("D" & i).Value
                                    End If


                                    Dim dat As Date
                                    dat = ws.Range("D" & i).Value
                                    If Not IsNothing(dat) Then
                                        .Fields("CorrectionOfReDELDate").Value = Date.FromOADate(dat.ToOADate - GetDetReduce(.Fields("BL_NO_Inbound").Value.ToString, containerNo)).Date
                                    Else
                                        .Fields("CorrectionOfReDELDate").Value = .Fields("FactOfReDelDate").Value
                                    End If

                                Case "STSH" '"ETS" empty to shipper
                                    .Fields("emptyCY").Value = CY
                                    .Fields("finalICD").Value = CY

                                    If .Fields("fullexport").Value = 1 Then
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    Else
                                        .Fields("fullimport").Value = 0
                                        .Fields("fulltoconsignee").Value = 0
                                        .Fields("soundcontainer").Value = 0
                                        .Fields("emptytoshipper").Value = 1
                                        .Fields("fullexport").Value = 0
                                        .Fields("EmptyExportQuay").Value = 0
                                    End If

                                    '.Fields("emptytoshipper").Value = 1
                                    '.Fields("fullimport").Value = 0
                                    '.Fields("fulltoconsignee").Value = 0
                                    '.Fields("soundcontainer").Value = 0
                                    '.Fields("fullexport").Value = 0
                                    '.Fields("EmptyExportQuay").Value = 0
                                    ' kiem tra trang thai truoc do
                                    If .Fields("Arrival_Date").Value.ToString = "" Or .Fields("FactOfDelDate").Value.ToString = "" Or .Fields("FactOfReDelDate").Value.ToString = "" Then
                                        fw.WriteLine("Please check another status for this container : " + containerNo)
                                    End If
                                    .Fields("DateOfEmptyContainerToShipper").Value = ws.Range("D" & i).Value
                                Case "RCVF" '"FEAQ" full export at Quay
                                    .Fields("ExportCY").Value = CY
                                    .Fields("finalICD").Value = CY
                                    ' kiem tra trang thai truoc do
                                    If .Fields("Arrival_Date").Value.ToString = "" Or .Fields("FactOfDelDate").Value.ToString = "" Or .Fields("FactOfReDelDate").Value.ToString = "" Or .Fields("DateOfEmptyContainerToShipper").Value.ToString = "" Then
                                        fw.WriteLine("Please check another status for this container : " + containerNo)
                                    End If
                                    .Fields("DateOfFullLoadContainerToCY").Value = ws.Range("D" & i).Value
                                    .Fields("fullexport").Value = 1
                                    .Fields("fullimport").Value = 0
                                    .Fields("fulltoconsignee").Value = 0
                                    .Fields("soundcontainer").Value = 0
                                    .Fields("emptytoshipper").Value = 0
                                    .Fields("EmptyExportQuay").Value = 0
                                Case "OB"
                                    .Fields("ExportCY").Value = CY
                                    .Fields("finalICD").Value = CY
                                    ' kiem tra trang thai truoc do
                                    If .Fields("Arrival_Date").Value.ToString = "" Or .Fields("FactOfDelDate").Value.ToString = "" Or .Fields("FactOfReDelDate").Value.ToString = "" Or .Fields("DateOfEmptyContainerToShipper").Value.ToString = "" Or .Fields("DateOfFullLoadContainerToCY").Value.ToString = "" Then
                                        fw.WriteLine("Please check another status for this container : " + containerNo)
                                    End If
                                    .Fields("DateOfOnBoard").Value = ws.Range("D" & i).Value
                                    .Fields("fullimport").Value = 0
                                    .Fields("fulltoconsignee").Value = 0
                                    .Fields("soundcontainer").Value = 0
                                    .Fields("emptytoshipper").Value = 0
                                    .Fields("fullexport").Value = 0
                                    .Fields("EmptyExportQuay").Value = 0
                                    ' cap nhat thong tin cont khi xuat hang
                                    If ws.Range("G" & i).Value <> "" Then
                                        .Fields("ConditionofContainerAT_MT_Out").Value = ws.Range("G" & i).Value
                                    End If
                            End Select


                            CY = ""
                            importcy = ""
                            h += 1
                            .Update()



                            Me.DataGridView1.Rows.Add(1)
                            Me.DataGridView1.Item("ContainerNo", row).Value = containerNo.ToString
                            Me.DataGridView1.Item("status", row).Value = "Checked"
                            Me.DataGridView1.Item("DateExe", row).Value = ws.Range("D" & i).Value
                            Me.DataGridView1.Item("Condition", row).Value = ws.Range("F" & i).Value
                            Me.DataGridView1.Item("statusCheck", row).Value = ws.Range("E" & i).Value
                            'Me.DataGridView1.
                            row += 1
                        Else
                            'DisplayMessage(True, containerNo)


                            Me.DataGridView1.Rows.Add(1)
                            Me.DataGridView1.Item("ContainerNo", row).Value = containerNo
                            Me.DataGridView1.Item("status", row).Value = "Not Checked"
                            'Me.DataGridView1.RefreshEdit()
                            Me.DataGridView1.Item("Condition", row).Value = ws.Range("F" & i).Value
                            Me.DataGridView1.Item("DateExe", row).Value = ws.Range("D" & i).Value
                            Me.DataGridView1.Item("statusCheck", row).Value = ws.Range("E" & i).Value
                            row += 1

                        End If

                    End With
                    rs.Close()
                    i += 1 'dòng thứ i của File
                End While
                InsertAutoNumberToGrid(Me.DataGridView1)
                MsgBox(h & " Container(s) Checked")
                Me.DataGridView1.Refresh()
                fw.Close()
            Catch ex As Exception
                MsgBox(Err.Description)
                DisplayMessage(True, "Hệ thống đang thử nghiệm., nếu có gì xin liên hệ tel: 0908 349945.")
            Finally
                Me.grbProcess.Visible = False
                app.Quit()
            End Try
        Catch ex As Exception
            'MsgBox(i)
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheck.Click
        If Me.DataGridView1.RowCount > 0 Then
            Me.DataGridView1.Rows.Clear()
        End If
        CheckContainerStatus(Me.txtFilename.Text, Me.txtSheetName.Text)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub frmCheckContainerstandardform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class