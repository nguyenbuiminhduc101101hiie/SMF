Public Class frmCheckContainerMTMoving

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
            Dim row As Integer = 0
            Dim rs As New ADODB.Recordset
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
                    SQL = "select * From CONTAINERMANAGERMENT where container_no = '" & containerNo & "' And (DateOfOnboard Is NULL or DateOfOnboard = '' ) and continued=1"
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
                            Dim MovingDate As Date
                            MovingDate = ws.Range("D" & i).Value


                            Dim status() As String = {"fullimport", "fulltoconsignee", "soundcontainer", "emptytoshipper", "fullexport"}
                            Dim check As Boolean = True
                            'nếu trạng thái container hiện tại khác sound
                            'có thể là input trễ, container đã chuyển qua 1 trạng thái kác, không có input
                            If .Fields("soundcontainer").Value = 0 Then
                                MsgBox("This Container :" & containerNo & " Is not Sound status , please check again")
                                i += 1
                                Me.DataGridView1.Rows.Add(1)
                                Me.DataGridView1.Item("ContainerNo", row).Value = containerNo.ToString
                                Me.DataGridView1.Item("status", row).Value = "not Checked"
                                Me.DataGridView1.Item("DateExe", row).Value = ws.Range("D" & i).Value
                                Me.DataGridView1.Item("Condition", row).Value = ws.Range("F" & i).Value
                                Me.DataGridView1.Item("statusCheck", row).Value = ws.Range("E" & i).Value
                                'Me.DataGridView1.
                                row += 1
                                rs.Close()
                                Continue While
                            End If

                            .Fields("MTMovingCY").Value = CY
                            .Fields("MTMovingDate").Value = MovingDate.Date
                            .Fields("FinalICD").Value = CY
                            .Fields("ConditionOfContainerAT_MT_CYDetail").Value = ws.Range("F" & i).Value



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
            Catch ex As Exception
                MsgBox(Err.Description)
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

    Private Sub frmCheckContainerMTMoving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class