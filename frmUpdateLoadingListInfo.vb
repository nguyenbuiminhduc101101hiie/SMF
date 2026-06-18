Public Class frmUpdateLoadingListInfo


    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL = strSQL & " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 Order By Vessel_Code desc"
        'loadDataToObject(Me.cboVessel, strSQL, id, value)
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboVessel.DisplayMember = value
        Me.cboVessel.ValueMember = id
        Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            'Dim strSQL As String
            'strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            'strSQL &= " From SailingSchedule,vessel "
            'strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD='" & Me.dtpLeavingDate.Value.Date & "'"
            'strSQL &= "Order By Vessel_Code desc"
            'Dim dt As New DataTable
            'dt = ReadTable(strSQL)
            'If dt.Rows.Count > 0 Then
            '    Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            'Else
            '    MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
            '    Return
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        On Error GoTo Err_named
        Dim Ves_ID As String
        If Me.cboVessel.Text = "" Then
            Return
        End If
        Ves_ID = Me.cboVessel.SelectedValue.ToString
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        If Ves_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select ETD "
            strQuery &= "from SailingSchedule "
            strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString
            End If
            '  query stranship
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmUpdateLoadingListInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub
    'chưa kiểm tra vì chưa có loading list comfirm
    Sub UpdateContainerMNG()

        Dim Vessel, VoyNo As String
        Dim TempVessel() As String
        TempVessel = Strings.Split(Me.cboVessel.Text.Trim, "-")
        If TempVessel.Length < 2 Then
            MsgBox("Vessel - Voyno is Invalid,Please check again")
            Return
        End If
        Vessel = TempVessel(0)
        VoyNo = TempVessel(1)
        If Me.txtFilename.Text = "" Then
            MsgBox("The file name is invalid")
            Return
        End If
        If Me.txtSheetName.Text = "" Then
            MsgBox("This sheet Not belong to the file")
            Return
        End If

        Dim App As New Excel.Application
        Try

            App = New Excel.Application()
            'Else
            'app = Proc(0)x
            App.Visible = False
            Dim workbooks As Excel.Workbooks
            workbooks = App.Workbooks
            Dim workbook As Excel._Workbook
            Dim Path As String
            Path = Me.txtFilename.Text

            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text)
            If ws Is Nothing Then
                App.Quit()
                Return
            End If

            Dim strQuery As String
            
            Dim Count As Integer = 0
            'Dim Adapter As New OleDb.OleDbDataAdapter(CmdSelect)
            'Adapter.Fill(dt)

            Dim CurRow As Integer = 1
            While 1
                If Not IsNothing(ws.Range("B" & CurRow).Value) Then
                    If UCase(ws.Range("B" & CurRow).Value) Like "*B/L NUMBER*" Then
                        'If ws.Range("B" & CurRow + 1).Value = "" Then
                        Exit While
                    End If
                End If
                If CurRow > 20 Then
                    Exit While
                End If
                CurRow += 1
            End While
            CurRow += 2
            While Not IsNothing(ws.Range("B" & CurRow).Value)
                If IsNothing(ws.Range("C" & CurRow).Value) Then
                    CurRow += 1
                    Continue While
                End If
               
                Dim BLNO, ContainerNo, OceanVessel, OceanVoyNo As String
                BLNO = ws.Range("B" & CurRow).Value
                ContainerNo = ws.Range("C" & CurRow).Value
                Dim POD As String = ws.Range("K" & CurRow).Value

                strQuery = "select * from ContainerManagerment Where Continued=1  And Container_no='" & ContainerNo.Trim & "'  and bl_no_outbound is  null"

                Dim rs As New ADODB.Recordset
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    MsgBox("Data Error , Container No :" & ContainerNo & " Not in Database, please check Transite cargo. ")

                    rs.Close()
                    CurRow += 1
                    Continue While
                End If

                Count += 1
                With rs
                    .Fields("Vessel_Outbound").Value = Vessel
                    .Fields("VoyNo_Outbound").Value = VoyNo
                    .Fields("BL_NO_Outbound").Value = BLNO
                   
                    .Fields("Port_Of_Discharge").Value = POD
                    .Fields("ETD").Value = Me.dtpLeavingDate.Value.Date
                    .Update()
                End With
                rs.Close()


                
                CurRow += 1
            End While
            MsgBox("Complete " & Count & " Container Updated")
        Catch ex As Exception

            If Err.Description Like "Invalid index*" Then
                MsgBox("File Không có Sheet này , Xin Kiểm Tra Lại")
                Return
            End If
            DisplayMessage(True, Err.Description)
        Finally
            App.Quit()
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        UpdateContainerMNG()
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
End Class