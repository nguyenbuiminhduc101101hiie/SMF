Public Class frmInputDataFullContainerIB


    'giống y như File frmInputDataEmptyContainerIB.vb Chỉ khác phần thêm bill.có thêm rs.Fields("TranSit").Value = 1  (Hàng trung chuyển)
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select Vessel from Vessel Where Continued=1 Order by Vessel"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If Me.cboVessel.Items.Count > 0 Then
                Me.cboVessel.Items.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cboVessel.Items.Add(dt.Rows(i).Item("Vessel").ToString)
            Next
            If Me.cboVessel.Items.Count > 0 Then
                Me.cboVessel.SelectedIndex = 0
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
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
            Dim SQL As String
            SQL = "select * from ContainerManagerment"
            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                .AddNew()
                .Fields("ContainerManagementID").Value = NewId()
                '''''''''''''''''''''''''''''''''''''''''

                .Fields("BL_NO_Inbound").Value = BLNO 'ws.Range("B" & i).Value.ToString

                .Fields("Container_No").Value = oTable.Rows(i).Item("F3").ToString.Trim
                .Fields("FullOrEmpty").Value = oTable.Rows(i).Item("F4").ToString
                .Fields("CTN_SIZE_TYPE").Value = Strings.Replace(oTable.Rows(i).Item("F5").ToString, "'", "").Trim
                .Fields("POL_CODE").Value = oTable.Rows(i).Item("F9").ToString

                .Fields("CargoIB_ID").Value = CargoIB_ID

                .Fields("Vessel_Inbound").Value = Me.cboVessel.Text.Trim
                .Fields("VoyNo_Inbound").Value = Me.txtVoyNo.Text.Trim
                .Fields("Arrival_Date").Value = Me.dtpETA.Value.Date
                .Fields("DisCharge_Date").Value = .Fields("Arrival_Date").Value
                '.Fields("ImportCY").Value = oTable.Rows(i).Item("F2").ToString
                Dim arr() As String = {"SoundContainer", "ToBeInSpected", "DamageContainer", "FullImport", "FullToConsignee", "FullExport", "EmptyToShipper", "EmptyContainerReposit"}
                For j As Integer = 0 To arr.Length - 1
                    .Fields(arr(j)).Value = 0
                Next
                '.Fields("SoundContainer").Value = 1
                '.Fields("FactOfDelDate").Value = .Fields("Arrival_Date").Value
                '.Fields("FactOfReDelDate").Value = .Fields("Arrival_Date").Value
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
            Dim SQL As String
            SQL = "select CTN_ID From Container Where Container_no='" & ContainerNo & "' And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Dim TempID As String = NewId()
                SQL = "Insert Into container(CTN_ID,Container_No,CTN_SIZE_TYPE) Values('" & TempID & "','" & ContainerNo & "','" & Type & "')"
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
        Dim Conn As New OleDb.OleDbConnection
        Dim app As Excel.Application
        Dim BLNO, BLNOTemp As String
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
            Dim SQL As String = "select * from [" & Me.txtSheetName.Text.Trim & "$] Where F11<>''"
            Dim cmd As New OleDb.OleDbCommand(SQL, Conn)
            Dim Adapter As New OleDb.OleDbDataAdapter(cmd)
            Dim oTable As New DataTable
            Adapter.Fill(oTable)
            'Me.DataGridView1.DataSource = oTable
            'open Excel File

            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim rs As New ADODB.Recordset

            Dim Currow As Integer = 8
            While IsNothing(ws.Range("A" & Currow).Value)
                Currow += 1
            End While
            While Not (UCase(ws.Range("A" & Currow).Value.ToString) Like "*NO*")
                Currow += 1
            End While


            Currow += 1 ' dòng bắt đầu lấy dữ liệu
            For i As Integer = 1 To oTable.Rows.Count - 1

                BLNO = ws.Range("B" & Currow).Value.ToString.Trim

                If BLNO = "DITTO" Then
                    BLNO = BLNOTemp
                Else
                    BLNO = ws.Range("B" & Currow).Value.ToString.Trim
                End If

                BLNOTemp = BLNO
                Dim TempBLID, TempBLID1 As String
                SQL = "Select * from BillOfLadingIB Where BLIB_NO='" & BLNO & "'AND CONTINUED=1"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    rs.AddNew() '
                    TempBLID = NewId() '  INSERT BILL

                    rs.Fields("BLIB_ID").Value = TempBLID '           
                End If

                Dim ShipperID, ConsigneeID, NotifyID As String
                ShipperID = CheckEsist("Shipper", "Shipper_1", Me.txtShipperName.Text.Trim, "Shipper_ID")
                ConsigneeID = CheckEsist("Consignee", "Consignee_1", Me.txtConsignee.Text.Trim, "Consignee_ID")
                NotifyID = CheckEsist("Notify", "Notify_1", Me.txtNotify.Text.Trim, "Notify_ID")

                TempBLID = rs.Fields("BLIB_ID").Value
                rs.Fields("BLIB_NO").Value = BLNO '                         
                rs.Fields("Shipper_ID").Value = ShipperID '                     
                rs.Fields("CONSIGNEE_ID").Value = ConsigneeID
                rs.Fields("Notify_ID").Value = NotifyID
                rs.Fields("POL").Value = ws.Range("I" & Currow).Value.ToString
                rs.Fields("POD").Value = ws.Range("K" & Currow).Value.ToString
                rs.Fields("DEST").Value = ws.Range("L" & Currow).Value.ToString
                rs.Fields("ETA").Value = Me.dtpETA.Value.Date
                rs.Fields("ICDPort").Value = Me.CBOicdpORT.Text.Trim
                rs.Fields("Vessel").Value = Me.cboVessel.Text.Trim
                'rs.Fields("VesselCode").Value = Me.txtVesselCo.Text.Trim
                rs.Fields("Voyage").Value = Me.txtVoyNo.Text.Trim
                rs.Fields("transit").Value = 1
                rs.Update()
                rs.Close()
                'rs.Fields("BL_NOIB").Value = BLNO
                SQL = "select * from CargoIb Where ctn_id='" & CheckContainer(oTable.Rows(i).Item("F3").ToString, Strings.Replace(oTable.Rows(i).Item("F5").ToString, "'", "")) & "' and BLIB_ID='" & TempBLID & "'"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                Dim CargoIB_ID As String
                If rs.EOF Then
                    rs.AddNew() 'INSERT CARGOIB
                    CargoIB_ID = NewId()
                    rs.Fields("CARGOIB_ID").Value = CargoIB_ID
                End If
                CargoIB_ID = rs.Fields("CARGOIB_ID").Value()
                rs.Fields("BLIB_ID").Value = TempBLID
                rs.Fields("CTN_ID").Value = CheckContainer(oTable.Rows(i).Item("F3").ToString, Strings.Replace(oTable.Rows(i).Item("F5").ToString, "'", ""))
                rs.Fields("Container_Type").Value = Strings.Replace(oTable.Rows(i).Item("F5").ToString, "'", "")
                rs.Fields("CARRIERKIND").Value = oTable.Rows(i).Item("F6").ToString

                rs.Update()

                'InsertContainerMNG(oTable, BLNO, i, CargoIB_ID) 'insert Container Managerment


                Currow += 1
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
        QueryVessel()
    End Sub
End Class