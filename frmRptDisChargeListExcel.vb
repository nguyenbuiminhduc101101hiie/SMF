Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmRptDisChargeListExcel



    Public transit As Integer
    Dim path As String
    Dim tempvessel() As String
    Private connstring As String
    Dim dsdata As New DataSet
    Dim dsdataOceanFreight As New DataSet
    Dim dsFee As New DataSet
    Dim collectColor As Integer = 7
    Dim PrepaidColor As Integer = 5
    Sub SetExcelValue()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\DisChargeList.xls"

            workbook = workbooks.Open(path)
            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet

            QueryBill(" And transit=0  And BLIB_NO  Not Like '%PNH%'  ")
            Dim CurType As String = ""
            For P As Integer = 1 To 3

                ws = sheets.Item(P)
                If ws Is Nothing Then
                    app.Quit()
                    Return
                End If
                Dim n As Integer = dsdata.Tables(0).Rows.Count
                Dim repeatCon(n \ 2) As Integer
                Dim PosRepeatCon As Integer = 0
                Dim DongHienTai As Integer = 11
                For ContainerPos As Integer = 0 To n - 1
                    For k As Integer = ContainerPos + 1 To n - 1
                        If dsdata.Tables(0).Rows(ContainerPos).Item("F1").ToString.Trim = dsdata.Tables(0).Rows(k).Item("F1").ToString.Trim Then
                            repeatCon(PosRepeatCon) = k
                            PosRepeatCon += 1
                            'repeatCon(PosRepeatCon) = ContainerPos
                            'PosRepeatCon += 1
                        End If
                    Next
                Next
                Dim dem As Integer = 0
                Dim BillNo As String = ""
                Dim CountRepeatCon As Integer = 0
                For i As Integer = 0 To n - 1
                    BillNo = dsdata.Tables(0).Rows(i).Item("F12").ToString.Trim


                    For k As Integer = 0 To 13
                        If PosRepeatCon > 0 Then
                            If i = repeatCon(CountRepeatCon) Then
                                ws.Range(Alpha(k) & DongHienTai).Cells.Font.ColorIndex = 3
                                If k = 13 Then
                                    CountRepeatCon += 1
                                End If
                            End If
                        End If

                        Dim Type As String = dsdata.Tables(0).Rows(i).Item("F3").ToString.Trim() 'Loại Container
                        Type = UCase(Type)
                        Dim Pos As Integer = 3
                        If Type = "20GP" Then
                            ws.Range(Alpha(Pos) & DongHienTai).Value2 = 1
                        ElseIf Type = "20RF" Then
                            ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 = 1
                        ElseIf Type = "40RF" Then
                            ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 = 1
                        ElseIf Type = "40GP" Then
                            ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 = 1
                        ElseIf Type = "40HC" Then
                            ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 = 1
                        ElseIf Type = "40RH" Then
                            ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 = 1
                        Else
                            ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 = 1
                        End If
                        'If k = 2 Then
                        '    CurType = Strings.Right(dsdata.Tables(0).Rows(i).Item("F" & k + 1), 2)
                        'End If
                        'If k >= 2 And k <= 9 Then
                        '    If k = 2 Then
                        '        ws.Range("C" & Donghientai).Value2 = Strings.Right(dsdata.Tables(0).Rows(i).Item("F" & k + 1), 2)
                        '        If Strings.Left(dsdata.Tables(0).Rows(i).Item("F" & k + 1), 2) = "20" Then
                        '            ws.Range("D" & Donghientai).Value2 = 1
                        '        Else
                        '            ws.Range("E" & Donghientai).Value2 = 1
                        '        End If
                        '        k = 10
                        '    End If

                        'End If
                        If (k < 3 Or k > 10) And dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                            ws.Range(Alpha(k) & DongHienTai).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1)

                            'ws.Range(Alpha(k) & Donghientai).Value2 &= ",HC"
                        End If
                    Next

                    'If dem = 76 Then
                    '    MsgBox("")
                    'End If
                    DongHienTai += 1
                Next

                ws.Range("B8").Value2 = Me.txtSlotUser.Text
                ws.Range("B5").Value2 = tempvessel(0)
                ws.Range("E5").Value2 = tempvessel(1)
                ws.Range("B6").Value2 = CDate(tempvessel(2)).Date
                If dsdata.Tables(0).Rows.Count > 0 Then
                    ws.Range("B7").Value2 = dsdata.Tables(0).Rows(0).Item("POD")
                End If
                If P = 2 Then
                    QueryBill(" And BLIB_NO  Like '%PNH%' ")
                ElseIf P = 3 Then
                    QueryTransit(1)
                End If

                'If dsdata.Tables(0).Rows.Count <= 0 Then
                '    Exit For
                'End If
            Next
            path = "c:\DisChargeList" & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            MsgBox("Completed")
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub


    Sub InsertExcel()
        connstring = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
"Data Source=" & path & ";Extended Properties=""Excel 8.0;HDR=NO;"""
        Dim pram As OleDbParameter
        Dim dr As DataRow
        Dim olecon As OleDbConnection
        Dim olecomm As OleDbCommand
        Dim olecomm1 As OleDbCommand
        Dim oleadpt As OleDbDataAdapter
        Dim ds As DataSet
        Try
            olecon = New OleDbConnection
            olecon.ConnectionString = connstring
            olecomm = New OleDbCommand
            olecomm.CommandText = "Select F1, F2, F3, F4,F5,F6,F7, F8, F9, F10,F11,F12, F13, F14, F15, F16,F17,F18,F19, F20, F21, F22,F23,F24,F25,F26 from [Sheet1$]"
            olecomm.Connection = olecon
            olecomm1 = New OleDbCommand
            olecomm1.CommandText = "Insert into [Sheet1$] " & _
            "(F1, F2, F3, F4,F5,F6,F7, F8, F9, F10,F11,F12, F13, F14, F15, F16,F17,F18,F19, F20, F21, F22,F23,F24,F25,F26)" & _
            " values (@F1, @F2, @F3, @F4,@F5,@F6,@F7, @F8, @F9, @F10,@F11,@F12, @F13, @F14, @F15, @F16,@F17,@F18,@F19, @F20, @F21, @F22,@F23,@F24,@F25,@F26)"
            olecomm1.Connection = olecon
            pram = olecomm1.Parameters.Add("@F1", OleDbType.VarChar)
            pram.SourceColumn = "F1"
            pram = olecomm1.Parameters.Add("@F2", OleDbType.VarChar)
            pram.SourceColumn = "F2"
            pram = olecomm1.Parameters.Add("@F3", OleDbType.VarChar)
            pram.SourceColumn = "F3"
            pram = olecomm1.Parameters.Add("@F4", OleDbType.VarChar)
            pram.SourceColumn = "F4"
            pram = olecomm1.Parameters.Add("@F5", OleDbType.VarChar)
            pram.SourceColumn = "F5"
            pram = olecomm1.Parameters.Add("@F6", OleDbType.VarChar)
            pram.SourceColumn = "F6"

            For i As Integer = 7 To 26
                pram = olecomm1.Parameters.Add("@F" & i, OleDbType.UnsignedInt)
                pram.SourceColumn = "F" & i
            Next
            oleadpt = New OleDbDataAdapter(olecomm)
            ds = New DataSet
            olecon.Open()
            oleadpt.Fill(ds, "Sheet1")
            If IsNothing(ds) = False Then
                For k As Integer = 0 To dsdata.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).NewRow
                    For j As Integer = 1 To 26
                        If j <> 7 Then
                            dr.Item("F" & j) = dsdata.Tables(0).Rows(k).Item("F" & j)
                        End If
                    Next
                    ds.Tables(0).Rows.Add(dr)
                Next
                'Me.DataGridView1.DataSource = ds.Tables(0)
                oleadpt = New OleDbDataAdapter
                oleadpt.InsertCommand = olecomm1
                Dim i As Integer = oleadpt.Update(ds, "Sheet1")
                MessageBox.Show(i & " row affected")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            olecon.Close()
            olecon = Nothing
            olecomm = Nothing
            oleadpt = Nothing
            ds = Nothing
            dr = Nothing
            pram = Nothing
        End Try
    End Sub


    Sub QueryBill(Optional ByVal DK As String = "")
        Try
            Dim strQuery As String

            strQuery = "select ICDPort,POD,container_no as F1,seal as F2,Container_type as F3,"
            strQuery &= "F4=case container_type when '20GP'  then 1 end,"
            strQuery &= "F5=case container_type when '40GP'  then 1 end ,"
            strQuery &= "F6=case container_type when '40HC'  then 1 end,"
            strQuery &= "F7=case container_type when '20RF'  then 1 end,"
            strQuery &= "F8=case container_type when '40RF'  then 1 end ,"
            strQuery &= "F9=case container_type when '40RH'  then 1 end,"
            strQuery &= "F10=case container_type when '45HC'  then 1 end,"
            strQuery &= " POL as F11, BLIB_NO as F12, GROSSWEIGHT As F13 ,"
            strQuery &= " ICDport as F14  "
            strQuery &= "from ((cargoib LEFT JOIN Billofladingib on cargoib.blib_id=Billofladingib.BLIB_ID)"
            strQuery &= "LEFT JOIN container on cargoib.CTN_ID=Container.CTN_ID)"
            strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text & DK & " and transit='" & transit & "' order by BillOfLadingIB.STT,CargoIB.STT "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If Not IsNothing(dsdata) Then
                dsdata.Clear()
            End If
            Adapter.Fill(dsdata)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryTransit(Optional ByVal TempTransit As String = "1")
        Try
            Dim strQuery As String

            strQuery = "select ICDPort,POD,container_no as F1,seal as F2,Container_type as F3,"
            strQuery &= "F4=case container_type when '20GP'  then 1 end,"
            strQuery &= "F5=case container_type when '40GP'  then 1 end ,"
            strQuery &= "F6=case container_type when '40HC'  then 1 end,"
            strQuery &= "F7=case container_type when '20RF'  then 1 end,"
            strQuery &= "F8=case container_type when '40RF'  then 1 end ,"
            strQuery &= "F9=case container_type when '40RH'  then 1 end,"
            strQuery &= "F10=case container_type when '45HC'  then 1 end,"
            strQuery &= " POL as F11, BLIB_NO as F12, GROSSWEIGHT As F13 ,"
            strQuery &= " ICDport as F14  "
            strQuery &= "from ((cargoib LEFT JOIN Billofladingib on cargoib.blib_id=Billofladingib.BLIB_ID)"
            strQuery &= "LEFT JOIN container on cargoib.CTN_ID=Container.CTN_ID)"
            strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text & " and transit='" & TempTransit & "' order by BillOfLadingIB.STT,CargoIB.STT "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If Not IsNothing(dsdata) Then
                dsdata.Clear()
            End If
            Adapter.Fill(dsdata)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryVessel()
        Try
            Dim SQL As String = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data from BillOfLadingIB where Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            Adapter.Fill(ds)
            Me.cboVessel.Items.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmTripAccountInbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboNam.Text = Now.Year
            Me.cboThang.Text = Now.Month
            For i As Integer = 2000 To 2050
                Me.cboNam.Items.Add(i)
            Next
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cboThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboThang.SelectedIndexChanged
        Me.cboVessel.Text = ""
        QueryVessel()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.cboVessel.Text = "" Then
            Return
        End If
        tempvessel = Strings.Split(Me.cboVessel.Text, " - ")

        SetExcelValue()
        'InsertExcel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub


    Private Sub cboNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNam.SelectedIndexChanged
        Me.cboVessel.Text = ""
        QueryVessel()

    End Sub


End Class