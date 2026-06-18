Imports system.Data.Odbc
Imports System.IO

Public Class frmListBooKingData
    Public ConnectionString, FileName As String
    Dim voyno As String = ""
    Dim vessel As String = ""
    Dim ETD As String = ""

    Private Function QueryBookingData(ByRef otable As DataTable) As Boolean
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        strQuery = "Select * from BookingData Where Vessel like'%" & vessel & "%' And VoyAge like'%" & voyno & "%' and Continued=1"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Con.Open()

        Adapter.Fill(ds, "BookingData")
        otable = ds.Tables(0)
        If otable.Rows.Count > 0 Then
            If MsgBox("This File Had Imported Do you want Continued...", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                otable.Rows.Clear()
                Return False
            End If
            otable.Rows.Clear()
        End If
        Return True
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function


    Public Function ConnectoExcel(ByVal File As String) As DataTable
        ConnectionString = "Driver={Microsoft Excel Driver (*.xls)};DriverId=790;" & _
  "Dbq=" & FileName & ";"
        Dim Con As New OdbcConnection(ConnectionString)
        Dim CmdSelect As New OdbcCommand("SELECT * FROM [Sheet1$] where f7 like '%VNSGN%'", Con)
        Dim Cmdselect2 As New OdbcCommand(" SELECT * FROM [Sheet1$] ", Con)
        Dim Adapter As New OdbcDataAdapter(CmdSelect)
        Dim Adapter2 As New OdbcDataAdapter(Cmdselect2)
        Dim Dt, result, temp As New DataTable
        Try
            Con.Open()
            vessel = ""
            voyno = ""
            Adapter.Fill(Dt)
            Adapter2.Fill(temp)

            Dim row As DataRow


            If temp.Rows.Count > 0 Then

                Dim F1, F2 As Boolean
                F1 = F2 = False 'chua tim thay vessel va ETD
                row = temp.Rows(0)
                Dim j As Integer = 0
                While row IsNot Nothing
                    If row(0).ToString.Length > 1 Then
                        If row(0).ToString Like "*VSL/VOY*" Then
                            Dim f() As String
                            f = Strings.Split(row(1).ToString, "/")
                            vessel = f(0).ToString
                            voyno = f(1)
                            F1 = True 'tim thay vessel,voyno
                        End If
                        If row(0) Like "*ETD*" Then
                            ETD = row(1).ToString.Trim
                            F2 = True 'tim thay ETD
                        End If
                        If F1 And F2 Then
                            Exit While
                        End If
                    End If

                    j += 1
                    If j = temp.Rows.Count Then
                        MsgBox("File Không Đúng chuẩn , Chắc chắn là file đã chọn là đúng ")
                        Return Nothing
                    End If
                    row = temp.Rows(j)
                End While
            End If
            If vessel = "" And voyno = "" Then
                MsgBox("File Không Đúng chuẩn , Chắc chắn là file đã chọn là đúng ")
                Return Nothing
            End If
            If QueryBookingData(result) Then
                '  Dim dem As Integer = 0
                If Dt.Rows(0).Item(4).ToString = "" Then
                    MsgBox("Dữ liệu chưa chuẩn , xin vui lòng vào File " & FileName & " Format lại cột WGT ! WGT Phải là Number  ", MsgBoxStyle.Exclamation)
                    Return Nothing
                End If
                For i As Integer = 0 To Dt.Rows.Count - 1

                    row = result.NewRow()
                    row("ETD") = ETD.ToString
                    row("VESSEL") = vessel.ToString
                    row("VoyAge") = voyno.ToString
                    row("BL_NO") = Dt.Rows(i).Item(0)
                    row("Container_No") = Dt.Rows(i).Item(1)
                    row("F_E") = Dt.Rows(i).Item(2)
                    row("CTN_ZISE") = Dt.Rows(i).Item(3)
                    row("Weight") = CDbl(Dt.Rows(i).Item(4))
                    row("OPR") = Dt.Rows(i).Item(5)
                    row("POL") = Dt.Rows(i).Item(6)
                    row("OPL") = Dt.Rows(i).Item(7)
                    row("OPD") = Dt.Rows(i).Item(8)
                    row("POD") = Dt.Rows(i).Item(9)
                    row("DG_REF") = Dt.Rows(i).Item(10)
                    row("Carrier") = Dt.Rows(i).Item(11)
                    row("ETA1") = Dt.Rows(i).Item(12).ToString
                    row("Vessel2") = Dt.Rows(i).Item(13)
                    row("ETA2") = Dt.Rows(i).Item(14).ToString
                    row("Service") = Dt.Rows(i).Item(15)
                    result.Rows.Add(row)
                Next

                Return result
            End If

            Return Nothing
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("Có thể file không co sheet1, hay sửa tên sheet Import thành Sheet1")
            Else
                MessageBox.Show(ex.Message())
            End If

            Return Nothing
        Finally
            Con.Close()
        End Try
    End Function

    
    Sub TrimSpace(ByRef temp As String)
        Dim i As Integer = 0
        Dim value As String = ""
        Dim len As Integer = temp.Length
        i = InStr(temp, "  ")
        While i <> 0
            temp = temp.Remove(i, 1)

            i = InStr(temp, "  ")

        End While
    End Sub

    Public Function getdata(ByVal file As String) As DataTable
        Try
            Dim fr As New StreamReader(file)
            Dim Tempdata As String = ""
            Dim tempVessel As String = ""
            Dim i As Integer = 0
            Dim f() As String
            file = file.Trim()
            file = Mid(file, 1, file.Length - 4)
            f = Split(file, " ")
            voyno = ""
            voyno = f(f.Length - 1)
            vessel = ""
            If f.Length < 2 Then
                MsgBox("File Không Đúng chuẩn , Chắc chắn là file đã chọn là đúng ")
                Return Nothing
            End If
            For k As Integer = 0 To f.Length - 2
                vessel &= f(k) & " "
            Next
            vessel = vessel.Trim()
            Dim dt As New DataTable
            If QueryBookingData(dt) = False Then
                Return Nothing
            End If

            Dim row As DataRow
            Dim a() As String
            Dim dem As Integer = 0
            While Not fr.EndOfStream
                Tempdata = fr.ReadLine
                If InStr(Tempdata, "=") <> 0 Then
                    Tempdata &= fr.ReadLine()
                End If
                Tempdata = Strings.Replace(Tempdata, "=", " ")
                Tempdata = Strings.Replace(Tempdata, "!", " ")

                TrimSpace(Tempdata)
                Tempdata.Trim()
                a = Strings.Split(Tempdata, " ")
                If (i = 0) Then
                    ETD = a(0)
                End If
                If a.Length >= 11 Then
                    Dim data As Integer = a.Length - 1


                    If (UCase(a(data - 3).Trim) Like "*VNSGN*") Then

                        row = dt.NewRow()

                        row("Weight") = Strings.FormatNumber(a(data).Trim, 2)

                        row("POD") = a(data - 2).Trim

                        row("POL") = (a(data - 3).Trim)
                        ' row("O_DEST") = a(data - 4).Trim
                        row("OPD") = a(data - 5).Trim

                        row("OPL") = (a(data - 6).Trim)
                        row("F_E") = a(data - 7).Trim
                        row("CTN_ZISE") = a(data - 8).Trim

                        row("Container_No") = (a(data - 9).Trim)

                        row("BL_NO") = a(data - 10).Trim

                        row("VoyAge") = voyno

                        row("Vessel") = vessel
                        row("ETD") = ETD

                        dt.Rows.Add(row)


                    End If

                End If
                Tempdata = ""
                i += 1
            End While
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("Vessel").ToString = "" And dt.Rows(0).Item("VoyAge").ToString = "" Then
                    MsgBox("File Không Đúng chuẩn , Chắc chắn là file đã chọn là đúng ")
                    Return Nothing
                End If
            Else
                MsgBox("File Không Đúng chuẩn , Chắc chắn là file đã chọn là đúng ")
                Return Nothing
            End If
            Return dt
        Catch ex As Exception
            MsgBox(Err.Description)
            Return Nothing
        End Try
    End Function

    Sub InsertData(ByVal dt As DataTable)
        Try
            Dim rs, rsMNG As New ADODB.Recordset
            Dim row As DataRow
            Dim StrQuery As String
            If dt Is Nothing Then
                Return
            End If
            If vessel = "" And voyno = "" Then
                Return
            End If
            StrQuery = "SELECT * "
            StrQuery = StrQuery & " FROM BooKingData where Vessel='" & vessel & "' And VoyAge='" & voyno & "'"
            rs.Open(StrQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Dim tempvessel, tempVoyno, tempETD, tempCTN_No As String
            tempETD = ""
            Dim check As Boolean = True
            If rs.EOF Then
                check = False
            End If

            Me.prbExport.Maximum = dt.Rows.Count + 1
            Dim i As Integer = 0
            Dim cnt As Double = 100 / dt.Rows.Count
            Dim ncnt As Double = cnt

            For Each row In dt.Rows
                System.Windows.Forms.Application.DoEvents()
                Me.prbExport.Value = i + 1
                i = i + 1
                Me.Label5.Text = CInt(ncnt) & " %"
                ncnt += cnt
                If check Then
                    rs.MoveFirst()
                    While Not rs.EOF
                        If row("Container_No").ToString = rs.Fields("Container_No").Value And row("BL_NO").ToString = rs.Fields("BL_NO").Value Then
                            Continue For
                        End If
                        rs.MoveNext()
                    End While
                End If
                With rs
                    .AddNew()
                    .Fields("BookingDataID").Value = NewId()
                    If row("ETD").ToString <> "" Then
                        .Fields("ETD").Value = row("ETD").ToString
                        tempETD = row("ETD").ToString
                    End If

                    .Fields("Vessel").Value = row("Vessel").ToString
                    tempvessel = row("Vessel").ToString
                    .Fields("VoyAge").Value = row("VoyAge").ToString
                    tempVoyno = row("VoyAge").ToString
                    .Fields("BL_NO").Value = row("BL_NO").ToString
                    .Fields("Container_No").Value = row("Container_No").ToString
                    tempCTN_No = row("Container_No").ToString
                    .Fields("F_E").Value = row("F_E").ToString
                    .Fields("CTN_ZISE").Value = row("CTN_ZISE").ToString
                    .Fields("Weight").Value = Strings.FormatNumber(row("Weight"), 2)

                    .Fields("OPR").Value = row("OPR").ToString
                    .Fields("POL").Value = row("POL").ToString
                    .Fields("OPL").Value = row("OPL").ToString
                    .Fields("OPD").Value = row("OPD").ToString
                    .Fields("POD").Value = row("POD").ToString
                    .Fields("DG_REF").Value = row("DG_REF").ToString
                    .Fields("Carrier").Value = row("Carrier").ToString
                    .Fields("ETA1").Value = row("ETA1").ToString
                    .Fields("Vessel2").Value = row("Vessel2").ToString

                    .Fields("ETA2").Value = row("ETA2").ToString
                    .Fields("Service").Value = row("Service").ToString
                    .Update()

                End With
                Dim strSQL As String
                strSQL = "Select * from ContainerManagerment Where Container_No='" & tempCTN_No & "' And Continued=1  Order by updateTime DESC"
                rsMNG.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rsMNG.EOF Then
                    rsMNG.MoveFirst()
                    With rsMNG

                        .Fields("OceanVessel").Value = tempvessel
                        .Fields("OceanVoyno").Value = tempVoyno
                        .Fields("OceanETD").Value = tempETD
                        .Update()
                    End With
                End If

                rsMNG.Close()

            Next
            Me.GroupBox1.Visible = False
            MsgBox("Success")
            QueryVessel()
            rs.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Sub QueryVessel()
        Try
            Dim value As String = "Data"
            Dim strQuery As String = "Select DISTINCT Vessel + ' - ' + VoyAge as Data from BooKingData where CONTINUED=1 Order by data ASC "
            Dim oAdapter As OleDb.OleDbDataAdapter
            Dim oTable As DataTable = New DataTable
            oAdapter = New OleDb.OleDbDataAdapter(strQuery, strconn)
            oAdapter.Fill(oTable)
            If oTable.Rows.Count > 0 Then
                Dim row As DataRow
                Me.cboVessel.Items.Clear()
                For Each row In oTable.Rows
                    Me.cboVessel.Items.Add(row(value))
                Next
                Me.cboVessel.Text = oTable.Rows(0).Item(value)
            End If

        Catch oExcept As Exception
            MessageBox.Show(oExcept.Message)
        End Try


    End Sub

    Private Sub BooKingData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            QueryVessel()
            ReFormat()
            SetDefaultGrid(Me.dgdBookingData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try
            Dim temp() As String
            temp = Strings.Split(Me.cboVessel.Text, " - ")
            Dim VesselName As String = temp(0)
            Dim Voy As String = temp(1)
            Dim strQuery As String = "Select DISTINCT BL_NO from BooKingData where CONTINUED=1 And Vessel Like'" & VesselName & "%'"
            strQuery &= " And VoyAge Like '%" & Voy & "%'"
            Dim oAdapter As OleDb.OleDbDataAdapter
            Dim oTable As DataTable = New DataTable
            oAdapter = New OleDb.OleDbDataAdapter(strQuery, strconn)
            oAdapter.Fill(oTable)
            If oTable.Rows.Count <= 0 Then
                Return
            End If
            Dim row As DataRow
            Me.lbBillNo.Items.Clear()

            For Each row In oTable.Rows
                Me.lbBillNo.Items.Add(row("BL_NO").ToString.Trim)
            Next
            'Me.cboVessel.Text = oTable.Rows(0).Item(value)
        Catch oExcept As Exception
            MessageBox.Show(oExcept.Message)
        End Try
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < 705 Or Me.Height >= 705) Then
        '    Me.Height = 732
        'End If
        'If (Me.Width < 910 Or Me.Width > 910) Then
        '    Me.Width = 910
        'End If
        Dim space As Integer = 2
        'Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        'Me.Left = 0
        'Me.Height = frmMain.Height - 10 - Me.Top
        'Me.Width = frmMain.Width - 8
        Me.dgdBookingData.Width = (Me.Width - 50 - Me.lbBillNo.Width)
        Me.dgdBookingData.Left = Me.lbBillNo.Width + lbBillNo.Left + 20

        'Me.txtPOL.Top = Me.Bottom - Me.txtPOL.Height - 100

        'Me.lblPOL.Top = Me.txtPOL.Top
        'Me.txtETA2.Top = Me.txtPOL.Top - Me.txtETA2.Height - space
        'Me.lblETA2.Top = Me.txtETA2.Top
        'Me.txtvessel2.Top = Me.txtETA2.Top - Me.txtvessel2.Height - space
        'Me.lblvessel2.Top = Me.txtvessel2.Top
        'Me.txtETA1.Top = Me.txtvessel2.Top - Me.txtETA1.Height - space
        'Me.lblETA1.Top = Me.txtETA1.Top
        'Me.txtCarrier.Top = Me.txtETA1.Top - Me.txtCarrier.Height - space
        'Me.lblCarrier.Top = Me.txtCarrier.Top
        'Me.txtContainer_No.Top = Me.txtCarrier.Top - Me.txtContainer_No.Height - space
        'Me.lblcontainer_no.Top = Me.txtContainer_No.Top

        'Me.txtOPL.Top = Me.txtPOL.Top
        'Me.lblOPL.Top = Me.txtOPL.Top

        'Me.txtOPD.Top = Me.txtOPL.Top - Me.txtOPD.Height - space
        'Me.lblOPD.Top = Me.txtOPD.Top

        'Me.txtOPR.Top = Me.txtOPD.Top - Me.txtOPR.Height - space
        'Me.lblOPR.Top = Me.txtOPR.Top

        'Me.txtPOD.Top = Me.txtOPR.Top - Me.txtPOD.Height - space
        'Me.lblPOD.Top = Me.txtPOD.Top

        'Me.txtETD.Top = Me.txtPOD.Top - Me.txtETD.Height - space
        'Me.lblETD.Top = Me.txtETD.Top

        'Me.txtService.Top = Me.txtETD.Top - Me.txtService.Height - space
        'Me.lblService.Top = Me.txtService.Top


        'Me.txtF_E.Top = Me.txtService.Top - Me.txtF_E.Height - space
        'Me.lblF_E.Top = Me.txtF_E.Top

        'Me.txtWeight.Top = Me.txtF_E.Top
        'Me.lblWeight.Top = Me.txtWeight.Top

        'Me.txtSize.Top = Me.txtF_E.Top - Me.txtSize.Height - space
        'Me.lblSIZE.Top = Me.txtSize.Top

        'Me.txtDG_REF.Top = Me.txtSize.Top
        'Me.lblDG_REF.Top = Me.txtDG_REF.Top

        'Me.lbBillNo.Height = Me.txtContainer_No.Top - Me.cmdFind.Height - Me.txtBL_NO.Height - 100
        Me.dgdBookingData.Height = Me.lbBillNo.Height + 25
        ' Me.cmdFind.Top = Me.txtContainer_No.Top - Me.cmdFind.Height - 10
        'Me.txtBL_NO.Top = Me.lbBillNo.Bottom + 2
        'Me.lblBL_NO.Top = Me.txtBL_NO.Top
        'Me.cmdFind.Top = Me.txtBL_NO.Bottom + 2

        'Me.GroupBox1.Left = Me.Width / 2 - Me.GroupBox1.Width / 2
        'Me.GroupBox1.Top = Me.Height / 2 - Me.GroupBox1.Height / 2

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub lbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBillNo.SelectedIndexChanged
        Try
            Dim billno As String
            billno = Me.lbBillNo.SelectedItem.ToString.Trim
            Me.txtBL_NO.Text = billno
            Dim strSQL As String
            strSQL = "Select * from BookingData where BL_NO like'%" & billno & "%' And Continued=1"
            Dim oAdapter As OleDb.OleDbDataAdapter
            Dim oTable As DataTable = New DataTable
            oAdapter = New OleDb.OleDbDataAdapter(strSQL, strconn)
            oAdapter.Fill(oTable)
            If oTable.Rows.Count <= 0 Then
                Return
            End If
            Me.dgdBookingData.DataSource = oTable
            RefreshData(0)
            InsertAutoNumberToGrid(Me.dgdBookingData)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub RefreshData(ByVal index As Integer)
        Try
            Me.txtBL_NO.Text = Me.dgdBookingData.Item("BL_NO", index).Value.ToString
            Me.txtContainer_No.Text = Me.dgdBookingData.Item("ContainerNo", index).Value.ToString
            Me.txtF_E.Text = Me.dgdBookingData.Item("F_E", index).Value.ToString
            Me.txtSize.Text = Me.dgdBookingData.Item("CTN_SIZE", index).Value.ToString
            Me.txtWeight.Text = Me.dgdBookingData.Item("Weight", index).Value.ToString
            Me.txtOPR.Text = Me.dgdBookingData.Item("OPR", index).Value.ToString
            Me.txtPOL.Text = Me.dgdBookingData.Item("POL", index).Value.ToString
            Me.txtOPL.Text = Me.dgdBookingData.Item("OPL", index).Value.ToString
            Me.txtOPD.Text = Me.dgdBookingData.Item("DEST", index).Value.ToString
            Me.txtPOD.Text = Me.dgdBookingData.Item("POD", index).Value.ToString
            Me.txtDG_REF.Text = Me.dgdBookingData.Item("DG_REF", index).Value.ToString
            Me.txtCarrier.Text = Me.dgdBookingData.Item("Carrier", index).Value.ToString
            Me.txtETA1.Text = Me.dgdBookingData.Item("ETA", index).Value.ToString
            Me.txtvessel2.Text = Me.dgdBookingData.Item("VesselName", index).Value.ToString 'Me.dgdBookingData.Item("Vessel2", index).Value.ToString
            Me.txtETA2.Text = Me.dgdBookingData.Item("ETA2", index).Value.ToString
            Me.txtETD.Text = Me.dgdBookingData.Item("ETD1", index).Value.ToString
            Me.txtService.Text = Me.dgdBookingData.Item("Service", index).Value.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdBookingData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBookingData.CellContentClick
        Try
            Dim index As Integer
            If Me.dgdBookingData.Rows.Count > 0 Then
                index = Me.dgdBookingData.CurrentRow.Index
            Else
                Return
            End If
            RefreshData(index)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Try
            If Me.lbBillNo.FindStringExact(Me.txtBL_NO.Text.Trim) = -1 Then

                Dim temp() As String
                temp = Strings.Split(Me.cboVessel.Text, " - ")
                Dim VesselName As String = temp(0)
                Dim Voy As String = temp(1)
                Dim strQuery As String = "Select DISTINCT BL_NO from BooKingData where CONTINUED=1 And Vessel Like'%" & VesselName & "%'"
                strQuery &= " And VoyAge Like '%" & Voy & "%' And BL_NO Like'%" & Me.txtBL_NO.Text & "%'"
                Dim oAdapter As OleDb.OleDbDataAdapter
                Dim oTable As DataTable = New DataTable
                oAdapter = New OleDb.OleDbDataAdapter(strQuery, strconn)
                oAdapter.Fill(oTable)
                If oTable.Rows.Count <= 0 Then
                    MsgBox("Số bill Không tồn tại ")
                    Return
                End If
                Me.txtBL_NO.Text = oTable.Rows(0).Item("BL_NO").ToString
                Me.lbBillNo.SelectedIndex = Me.lbBillNo.FindStringExact(Me.txtBL_NO.Text.Trim)
            Else
                Me.lbBillNo.SelectedIndex = Me.lbBillNo.FindStringExact(Me.txtBL_NO.Text.Trim)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImport.Click
        On Error GoTo Err
        'If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    FileName = Me.OpenFileDialog1.FileName
        '    If FileName = "" Then
        '        MsgBox("Tên file không hợp lệ")
        '        Return
        '    End If
        '    Dim f() As String
        '    f = Strings.Split(FileName, "\")

        '    Dim dt As New DataTable

        '    Me.mnuExit.Enabled = False
        '    Me.GroupBox1.Visible = True
        '    Me.prbExport.Style = ProgressBarStyle.Marquee

        '    If Me.OpenFileDialog1.FilterIndex = 2 Then
        '        dt = getdata(f(f.Length - 1))
        '    Else
        '        dt = ConnectoExcel(f(f.Length - 1))
        '    End If
        '    If IsNothing(dt) Then
        '        MsgBox("File Không Đúng chuẩn , Chắc chắn là file đã chọn là đúng ")
        '        Me.GroupBox1.Visible = False
        '        Me.mnuExit.Enabled = True
        '        Return
        '    End If

        '    Me.prbExport.Style = ProgressBarStyle.Blocks
        '    InsertData(dt)
        '    Me.mnuExit.Enabled = True
        '    Me.GroupBox1.Visible = False
        'End If
        frmImportConnectingVessel.ShowDialog()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListBooKingData_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ' ReFormat()

    End Sub

    Private Sub frmListBooKingData_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' ReFormat()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdBookingData.RowCount > 0 Then
                Me.mnuExit.Enabled = False
                ExportExecel(Me.dgdBookingData, Me)
                Me.mnuExit.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdBookingData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBookingData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdBookingData)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.GroupBox1.Visible = False
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        QueryVessel()
    End Sub
End Class