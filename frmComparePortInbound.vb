Imports Excel
Public Class frmComparePortInbound
    Dim Vessel, Voyno, ETA As String
    Dim ds As New DataSet
    Dim path As String
    Dim DifInbound, DifPort As Integer

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data "
            SQL &= "from BillOfLadingIB where Continued=1 And ETA >='" & Me.dtpFromETA.Value.Date & "' And ETA<='" & Me.dtpToETA.Value.Date & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            ds.Tables.Add()
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Rows.Clear()
            End If
            Adapter.Fill(ds.Tables(0))
            Me.cboVessel.Items.Clear()
            Me.cboVessel.Text = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtpFromETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpToETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub
    Sub Reformat()
        Try
            Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
            Me.Left = 0
            'Me.Width = frmMain.Width - 50
            Me.Height = frmMain.Height - 100
            'Me.dgdInboundData.Height = 400
            'Me.dgdPortData.Height = 400
        Catch ex As Exception
            MsgBox(Err.Description & "Reformat Compare Port Inbound")
        End Try
    End Sub
    Private Sub frmComparePortInbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ds.Tables.Clear()
            ds.Tables.Add("InboundData")
            ds.Tables.Add("PortData")
            DifInbound = 0
            DifPort = 0

            SetDefaultGrid(Me.dgdInboundData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdPortData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            If Me.dgdInboundData.RowCount > 0 Then
                Me.dgdInboundData.DataSource = ds.Tables("InboundData")
                'Me.lblCountContainerInbound.Text = ""
            End If
            If Me.dgdPortData.RowCount > 0 Then
                Me.dgdPortData.DataSource = ds.Tables("PortData")
                'Me.lblCountContainerPort.Text = ""
            End If
            QueryVessel()
            Reformat()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Me.txtFileName.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtFileName.Text = "" Or Me.txtSheetName.Text = "" Or Me.cboVessel.Text = "" Then
            Return
        End If
        Dim ConExcel As OleDb.OleDbConnection
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Try
            DifInbound = 0
            DifPort = 0
            Dim TempVessel() As String
            TempVessel = Strings.Split(Me.cboVessel.Text, " - ")
            Vessel = TempVessel(0)
            Voyno = TempVessel(1)
            Dim strConnE As String ', sheet
            'Dim dt As New DataTable
            'lấy dữ liệu của Excel Vào datatable
            strConnE = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " & Me.txtFileName.Text.Trim & "; Extended Properties=""Excel 8.0;HDR=no;"""
            ConExcel = New OleDb.OleDbConnection(strConnE)
            ConExcel.Open()
            Dim CmdSelect As New OleDb.OleDbCommand
            CmdSelect = New OleDb.OleDbCommand("SELECT F3,F4,F5,F6,F7,F8,F9,F10 FROM [" & Me.txtSheetName.Text.Trim & "$] where F6 <>'' and F6 not like'%POD%'Order by F3 ASC", ConExcel)
            Dim Adapter As New OleDb.OleDbDataAdapter(CmdSelect)

            ds.Tables("PortData").Columns.Clear()
            If ds.Tables("PortData").Rows.Count > 0 Then
                ds.Tables("PortData").Rows.Clear()
            End If

            Adapter.Fill(ds.Tables("PortData"))
            Me.dgdPortData.DataSource = ds.Tables("PortData")
            Dim PortCountRow As Integer = Me.dgdPortData.RowCount
            Me.GroupBox2.Text = PortCountRow & " trong Sheet : " & Me.txtSheetName.Text

            'lấy dữ liệu trong Database vao datatable (inbound)
            Con.Open()
            Dim strQuery As String
            strQuery = "Select Container_No,POR,POL,POD,Dest,Container_type,GROSSWEIGHT "
            strQuery &= " From ((CargoIB LEFT JOIN BillOfLadingIb On Cargoib.BLIB_ID=BillofLadingib.BLIB_ID)"
            strQuery &= " LEFT JOIN Container On CargoIb.CTN_ID=Container.CTN_ID)"
            strQuery &= " Where CargoIb.Continued=1 And Vessel='" & Vessel & "' And VoyAge='" & Voyno & "' And BillOfLadingIb.Continued=1 Order By Container_No ASC"
            Dim InboundSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim InboundAdapter As New SqlClient.SqlDataAdapter(InboundSelect)
            If ds.Tables("InboundData").Rows.Count > 0 Then
                ds.Tables("InboundData").Rows.Clear()
            End If
            InboundAdapter.Fill(ds.Tables("InboundData"))
            Me.dgdInboundData.DataSource = ds.Tables("InboundData")
            Dim inboundCountRow As Integer = Me.dgdInboundData.RowCount
            ' kiểm tra container trùng bên hàng nhập

            'kiểm tra container Không trùng giữa hai Grid
            For i As Integer = 0 To inboundCountRow - 1
                Dim j As Integer = 0
                For j = 0 To PortCountRow - 1
                    If Me.dgdInboundData.Item(0, i).Value.ToString.Trim = Me.dgdPortData.Item(0, j).Value.ToString.Trim Then
                        Exit For
                    End If
                Next
                If j = PortCountRow Then
                    DifInbound += 1
                    Me.dgdInboundData.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                End If
            Next

            'kiển tra dữ liệu port có container khác inbound
            For j As Integer = 0 To PortCountRow - 1
                Dim i As Integer = 0
                For i = 0 To inboundCountRow - 1
                    If Me.dgdInboundData.Item(0, i).Value.ToString.Trim = Me.dgdPortData.Item(0, j).Value.ToString.Trim Then
                        Exit For
                    End If
                Next
                If i = inboundCountRow Then
                    DifPort += 1
                    Me.dgdPortData.Rows(j).DefaultCellStyle.ForeColor = Color.Blue
                End If
            Next
            'gán số thứ tự cho grid Inbounddata
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For i As Integer = 0 To inboundCountRow - 1                              '
                ' gán thứ tự chó grid                                                '
                Me.dgdInboundData.Rows(i).HeaderCell.Value = (i + 1).ToString        '
            Next                                                                     '
            ' gán số thứ tự cho Grid Port                                            '
            For i As Integer = 0 To PortCountRow - 1                                 '
                ' gán thứ tự chó grid                                                '
                Me.dgdPortData.Rows(i).HeaderCell.Value = (i + 1).ToString           '   
            Next                                                                     '
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Col As Integer = 0 To Me.dgdInboundData.Columns.Count - 1
                Me.dgdInboundData.Columns(Col).SortMode = DataGridViewColumnSortMode.NotSortable
                Me.dgdPortData.Columns(Col).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            If DifPort + DifInbound = 0 Then
                MsgBox("dữ liệu đã trùng khớp giữa Inbound Và Port")
            ElseIf DifInbound = inboundCountRow Then
                MsgBox("dữ lữ hoàn toàn không khớp , hãy chắc chắn là File đã chọn để so sánh là đúng")
            Else
                MsgBox("Dữ liệu chưa trùng khớp Hãy nhấn Export Để biết toàn bộ số container không trùng")
            End If

            Dim CountRepeatCon As Integer = 0
            For i As Integer = 0 To inboundCountRow - 1
                Dim j As Integer = i + 1
                If j = inboundCountRow Then
                    Exit For
                End If
                ''gán số thức tự cho grid
                'Me.dgdInboundData.Rows(i).HeaderCell.Value = i + 1

                While Me.dgdInboundData.Item(0, j).Value.ToString.Trim = Me.dgdInboundData.Item(0, i).Value.ToString.Trim
                    Me.dgdInboundData.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    CountRepeatCon += 1
                    j += 1
                End While
            Next
            Me.GroupBox1.Text = inboundCountRow & " Containers trong Manifest có " & CountRepeatCon & " Container trùng"
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            If Not IsNothing(ConExcel) Then
                ConExcel.Close()
                ConExcel = Nothing
            End If
        End Try
    End Sub
    Sub SetExcelValue(ByVal dgd As DataGridView)
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = False

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            'path = StartupPath & "\.xls"

            workbook = workbooks.Add()

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim n As Integer = dgd.RowCount
            Dim Dongbatdau As Integer = 3
            Dim DongHientai As Integer = 0

            If dgd.Name = Me.dgdInboundData.Name Then
                If DifInbound = False Then
                    Return
                End If
            End If

            For i As Integer = 0 To n - 1
                If dgd.Rows(i).DefaultCellStyle.ForeColor = Color.Blue Then
                    For col As Integer = 0 To dgd.Columns.Count - 1
                        ws.Range(Alpha(col + 1) & DongHientai + Dongbatdau).Font.ColorIndex = 5
                        ws.Range(Alpha(col + 1) & DongHientai + Dongbatdau).Value2 = dgd.Item(col, i).Value
                    Next
                    ws.Range("A" & DongHientai + Dongbatdau).Value2 = DongHientai
                    DongHientai += 1
                End If
            Next
            'ws.Range("B8").Value2 = Me.txtSlotUser.Text
            'ws.Range("B5").Value2 = tempvessel(0)
            'ws.Range("E5").Value2 = tempvessel(1)
            'ws.Range("B6").Value2 = CDate(tempvessel(2)).Date
            'ws.Range("B7").Value2 = ds.Tables(0).Rows(0).Item("ICDPort") & " - " & ds.Tables(0).Rows(0).Item("POD")

            path = "c:\CompareData" & Vessel & "-" & Voyno & " " & Now.Date & Now.Minute & Now.Second & ".xls"

            'workbook.Save()
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            MsgBox("Completed " & DongHientai & " Containers")
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub cmdExportExcelInbound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcelInbound.Click
        Try
            If Me.dgdInboundData.RowCount = 0 Then
                Return
            End If
            SetExcelValue(Me.dgdInboundData)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdExportExcelPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcelPort.Click
        Try
            If Me.dgdPortData.RowCount = 0 Then
                Return
            End If
            SetExcelValue(Me.dgdPortData)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
End Class