Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmRptTranShipMentEDI

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

            path = StartupPath & "\TranShipMent.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If

            Dim n As Integer = dsdata.Tables(0).Rows.Count

            Dim repeatCon(n \ 2) As Integer
            Dim PosRepeatCon As Integer = 0
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
            Dim CountRepeatCon As Integer = 0
            Dim dem As Integer = 0
            Dim BillNo As String = ""
            For i As Integer = 0 To n - 1
                BillNo = dsdata.Tables(0).Rows(i).Item("F8").ToString.Trim


                For k As Integer = 0 To 12

                    If PosRepeatCon > 0 Then
                        If i = repeatCon(CountRepeatCon) Then
                            ws.Range(Alpha(k) & 11 + dem).Cells.Font.ColorIndex = 3
                            If k = 12 Then
                                CountRepeatCon += 1
                            End If
                        End If
                    End If

                    If k >= 2 And k <= 9 Then
                        If k = 2 Then

                            If Strings.Left(dsdata.Tables(0).Rows(i).Item("F" & k + 1), 2) = "20" Then
                                ws.Range("C" & 11 + dem).Value2 = 1
                            Else
                                ws.Range("D" & 11 + dem).Value2 = 1
                            End If
                            ws.Range("E" & 11 + dem).Value2 = Strings.Right(dsdata.Tables(0).Rows(i).Item("F" & k + 1), 2)
                            k = 10
                        End If
                    End If

                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        ws.Range(Alpha(k) & 11 + dem).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1)
                    End If
                Next

                dem += 1
            Next

            ws.Range("B8").Value2 = Me.txtSlotUser.Text
            ws.Range("B5").Value2 = tempvessel(0)
            ws.Range("E5").Value2 = tempvessel(1)
            ws.Range("B6").Value2 = CDate(tempvessel(2)).Date
            ws.Range("B7").Value2 = dsdata.Tables(0).Rows(0).Item("ICDPort") & " - " & dsdata.Tables(0).Rows(0).Item("POD")

            path = "c:\TRanShipMent" & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

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


    Sub QueryBill()
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
            strQuery &= " POL as F11, BLIB_NO as F12, GROSSWEIGHT As F13 "
            strQuery &= "from ((cargoibEDI LEFT JOIN BillofladingibEDI on cargoibEDI.blib_id=BillofladingibEDI.BLIB_ID)"
            strQuery &= "LEFT JOIN container on cargoibEDI.CTN_ID=Container.CTN_ID)"
            strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillofladingibEDI.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text & " and transit='" & transit & "' Order by BillofladingibEDI.STT,cargoibEDI.STT "
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
            Dim SQL As String = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data from BillofladingibEDI where Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text
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
        QueryBill()
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
