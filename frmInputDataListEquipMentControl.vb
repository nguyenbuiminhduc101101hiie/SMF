Public Class frmInputDataListEquipMentControl
    'dữ lid6ẹu đã đựơc nhập bên hàng nhập , bên đây chỉ check lại trạng thái từ dữ liệu đã có 

    'Sub QueryVessel()
    '    Try
    '        Dim SQL As String
    '        SQL = "Select Vessel from Vessel Where Continued=1 Order by Vessel"
    '        Dim dt As New DataTable
    '        dt = ReadTable(SQL)
    '        If Me.cboVessel.Items.Count > 0 Then
    '            Me.cboVessel.Items.Clear()
    '        End If
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Me.cboVessel.Items.Add(dt.Rows(i).Item("Vessel").ToString)
    '        Next
    '        If Me.cboVessel.Items.Count > 0 Then
    '            Me.cboVessel.SelectedIndex = 0
    '        End If
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub
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

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Try
            If Me.txtFilename.Text.Trim = "" Then
                MsgBox("Click Browse to select The file to import")
                Return
            End If
            If Me.txtSheetName.Text.Trim = "" Then
                MsgBox("Enter the sheet Name that you want import")
                Return
            End If
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
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] Where F13<>''"
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File


            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}



            ''
            Dim Currow As Integer = 8
            While IsNothing(ws.Range("A" & Currow).Value)
                Currow += 1
            End While
            While Not (UCase(ws.Range("A" & Currow).Value.ToString) Like "*NO*")
                Currow += 1
            End While
            Currow += 1 ' dòng bắt đầu lấy dữ liệu
            Dim BLNO, ContainerNo As String
            BLNO = ws.Range("B" & Currow).Value.ToString

            Dim checkContainer As Integer = 0
            Dim rs As New ADODB.Recordset



            For i As Integer = 1 To oTable.Rows.Count - 1
                ContainerNo = oTable.Rows(i).Item("F3").ToString
                SQL = "select * from ContainerManagerment Where Continued=1 And BL_NO_Inbound='" & BLNO & "' And Container_No='" & ContainerNo & "'"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    MsgBox("DataError,Container :" & ContainerNo & " And BL:" & BLNO & " Not In database", MsgBoxStyle.Critical, "Data Error")
                    rs.Close()
                    Continue For
                End If
                With rs

                    '.Fields("ContainerManagementID").Value = NewId()
                    '''''''''''''''''''''''''''''''''''''''''
                    'một file chỉ có một bill

                    'If UCase(ws.Range("B" & Currow).Value.ToString.Trim) = "DITTO" Then
                    '    .Fields("BL_NO_Inbound").Value = BLNO 'ws.Range("B" & i).Value.ToString
                    'Else
                    '    BLNO = ws.Range("B" & Currow).Value.ToString
                    '    .Fields("BL_NO_Inbound").Value = BLNO
                    'End If
                    '.Fields("Container_No").Value = 
                    '.Fields("FullOrEmpty").Value = oTable.Rows(i).Item("F4").ToString
                    '.Fields("CTN_SIZE_TYPE").Value = oTable.Rows(i).Item("F5").ToString
                    '.Fields("POL_CODE").Value = oTable.Rows(i).Item("F9").ToString
                    '.Fields("Vessel_Inbound").Value = Me.cboVessel.Text.Trim
                    '.Fields("VoyNo_Inbound").Value = Me.txtVoyNo.Text.Trim
                    '.Fields("Arrival_Date").Value = Me.dtpETA.Value.Date
                    '.Fields("DisCharge_Date").Value = .Fields("Arrival_Date").Value
                    '.Fields("ImportCY").Value = oTable.Rows(i).Item("F2").ToString

                    Dim arr() As String = {"SoundContainer", "ToBeInSpected", "DamageContainer", "FullImport", "FullToConsignee", "FullExport", "EmptyToShipper", "EmptyContainerReposit"}
                    For j As Integer = 0 To arr.Length - 1
                        .Fields(arr(j)).Value = 0
                    Next
                    .Fields("SoundContainer").Value = 1
                    .Fields("FactOfDelDate").Value = .Fields("Arrival_Date").Value
                    .Fields("FactOfReDelDate").Value = .Fields("Arrival_Date").Value
                    .Update()
                    checkContainer += 1
                End With
                rs.Close()
                Currow += 1
            Next

            MsgBox("Complete : " & checkContainer & " Containers Checked")
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
        'QueryVessel()
    End Sub
End Class