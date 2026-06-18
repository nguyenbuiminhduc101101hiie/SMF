Imports Excel
Public Class frmTranShipmentCargoManifest
    Dim ds As New DataSet
    Public transit As Integer
    Dim Vessel, VoyNo As String
    Dim ETA As Date
    Dim Path As String
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
            If Not IsNothing(ds) Then
                ds.Clear()
            End If
            Adapter.Fill(ds)
            'Me.cboVessel.Items.Clear()
            Me.cboVessel.Text = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryBillInfo(ByVal Vessel As String, ByVal Voyno As String, ByVal ETA As Date)
        Try
            Dim strSQL As String
            strSQL = "Select ICDPort,POL as F1,BLIB_NO as F2,POD ,Container_No as F4,Seal as F5,Container_Type as F6,GROSSWEIGHT as F7,DESCRIPTIONOFGOODS as F8,AMOUNT  as F9 ,KIND"
            strSQL &= " from ((BillOfLadingIB LEFT JOIN CargoIB on CargoIB.BLIB_ID = BillOfLadingIB.BLIB_ID) "
            strSQL &= " LEFT JOIN Container On CargoIb .CTN_ID=Container.CTN_ID) "
            strSQL &= " Where Vessel='" & Vessel.Trim & "' And Voyage='" & Voyno.Trim & "' And ETA='" & ETA & "' And BillOfLadingIB.Continued=1 And BLIB_No Like'%" & IIf(Me.cboPOD.Text = "ALL", "", Me.cboPOD.Text) & "%' and transit='" & transit & "' Order by BillOfladingIB.STT,CargoIB.STT"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBill").Rows.Count > 0 Then
                ds.Tables("oTableBill").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBill"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub frmTranShipmentCargoManifest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ds.Tables.Add("oTableBill")
            QueryVessel()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub dtpFromETA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFromETA.TextChanged
    '    Try
    '        QueryVessel()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub dtpFromETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub dtpToETA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpToETA.TextChanged
    '    Try
    '        QueryVessel()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub dtpToETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Sub SetExcelValue()
        Dim app As Application
        Try
            app = New Application()
            app.Visible = True
            QueryBillInfo(Vessel, VoyNo, ETA)
            Dim BillNo As String = ""
            Dim n As Integer = ds.Tables("oTableBill").Rows.Count
            If n = 0 Then
                DisplayMessage(True, Vessel & " - " & VoyNo & " Không có bill Đi " & Me.cboPOD.Text)
                Exit Sub
            End If
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook
            Path = StartupPath & "\TranShipeMentCargoManiFest.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 20 ' dòng hiên hành Dang Xét
            Dim CountBill As Integer = 0 'dong bắt đầu của một tàu mới
            Dim DongBillDau As Integer = 0
            Dim NoKg As Double = 0
            BillNo = ds.Tables("oTableBill").Rows(0).Item("F2").ToString.Trim

            DongBillDau = DongHienTai


            Dim repeatCon(n \ 2) As Integer
            Dim PosRepeatCon As Integer = 0
            For ContainerPos As Integer = 0 To n - 1
                For k As Integer = ContainerPos + 1 To n - 1
                    If ds.Tables(0).Rows(ContainerPos).Item("F4").ToString.Trim = ds.Tables(0).Rows(k).Item("F4").ToString.Trim Then
                        repeatCon(PosRepeatCon) = k
                        PosRepeatCon += 1
                        'repeatCon(PosRepeatCon) = ContainerPos
                        'PosRepeatCon += 1
                    End If
                Next
            Next
            Dim CountRepeatCon As Integer = 0
            For i As Integer = 0 To n - 1

                If BillNo = ds.Tables("oTableBill").Rows(i).Item("F2").ToString.Trim Then
                    CountBill += 1 'đếm số container trên 1 bill
                    NoKg += ds.Tables("oTableBill").Rows(i).Item("F9")
                Else
                    BillNo = ds.Tables("oTableBill").Rows(i).Item("F2").ToString.Trim
                    NoKg = ds.Tables("oTableBill").Rows(i).Item("F9")
                    CountBill = 1
                End If
                'Insert Bill Info tren 1 dong
                For k As Integer = 0 To 8

                    If PosRepeatCon > 0 Then
                        If i = repeatCon(CountRepeatCon) Then
                            ws.Range(Alpha(k) & DongHienTai).Cells.Font.ColorIndex = 3
                            If k = 8 Then
                                CountRepeatCon += 1
                            End If
                        End If
                    End If

                    If Alpha(k) = "C" Then
                        ws.Range("C" & DongHienTai).Value2 = i + 1
                    ElseIf Alpha(k) = "H" And CountBill > 1 Then
                        Continue For
                    ElseIf Alpha(k) = "I" Then
                        'If CountBill = 1 Then
                        ws.Range(Alpha(k) & DongHienTai - CountBill + 1).Value2 = NoKg & ds.Tables("oTableBill").Rows(i).Item("KIND").ToString
                        'End If
                    Else
                        If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                            ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Trim
                            If k = 7 Then
                                Dim temp() As String
                                temp = Strings.Split(ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Trim, Chr(13))
                                Dim Description As String = ""
                                For j As Integer = 0 To temp.Length - 1
                                    If Not (UCase(temp(j).Trim) Like "*SHIPPER*LOAD*COUNT*SEAL*") Then
                                        Description &= temp(j)
                                    End If
                                Next
                                ws.Range(Alpha(k) & DongHienTai).Value2 = Description
                            End If
                        End If
                    End If
                Next
                'ws.Range("Q" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee

                DongHienTai += 1

            Next
            ws.Range("B5").Value2 = Vessel
            ws.Range("D5").Value2 = VoyNo
            ws.Range("B6").Value2 = ETA

            ws.Range("H4").Value2 = ds.Tables("oTableBill").Rows(0).Item("F1").ToString.Trim
            ws.Range("H5").Value2 = ds.Tables("oTableBill").Rows(0).Item("POD").ToString.Trim
            ws.Range("H6").Value2 = ds.Tables("oTableBill").Rows(0).Item("ICDPort").ToString.Trim
            ws.Range("H7").Value2 = Me.txtBL_NO.Text.Trim

            ws.Range("A19", "I" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            ws.Range("A19", "I" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
            ws.Range("A19", "I" & DongHienTai).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center


            Path = "c:\TranShipeMentCargoManiFest" & Vessel & "-" & VoyNo & CDate(ETA) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            If Me.txtBL_NO.Text = "" Then
                MsgBox("Chưa nhập Số bill Kiểm tra lại")
                Return
            End If
            If Me.cboPOD.Text = "" Then
                MsgBox("Hãy chọn một trong các POD")
                Return
            End If
            Dim tempVessel() As String
            tempVessel = Strings.Split(Me.cboVessel.Text, " - ")
            Vessel = IIf(tempVessel.Length > 0, tempVessel(0).Trim, "")
            VoyNo = IIf(tempVessel.Length > 1, tempVessel(1).Trim, "")
            ETA = IIf(tempVessel.Length > 2, CDate(tempVessel(2).Trim), "")
            SetExcelValue()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class