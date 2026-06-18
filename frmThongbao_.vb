Public Class frmThongbao_

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If LoginSucceeded = True Then
                Me.dgdthongbao.Rows.Clear()
                If ComboBox1.Text = "All" Then
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    ' If frmMain.AlarmToolStripMenuItem.Checked = True Then
                    alarmReportRecording()
                    alarmReportBooking1()

                    alarmReportQuotation()
                    checkAlarmRecording()


                    alarmReport_theodoilohang()
                    alarmReport_theodoilohanginbound()
                    alarmReport_theodoilohanglogistics()
                    '----------
                    checkAlarm1()

                End If
                If Me.ComboBox1.Text = "Export" Then
                    alarmReport_theodoilohang()
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    checkAlarm1()
                End If
                If Me.ComboBox1.Text = "Import" Then
                    alarmReport_theodoilohanginbound()
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    checkAlarm1()
                End If
                If Me.ComboBox1.Text = "Logistics" Then
                    alarmReport_theodoilohanglogistics()
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    checkAlarm1()
                End If
                If Me.ComboBox1.Text = "KPIs" Then
                    checkAlarmRecording()
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    checkAlarm1()
                End If
                If Me.ComboBox1.Text = "Booking" Then
                    alarmReportBooking1()
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    checkAlarm1()
                End If

                If Me.ComboBox1.Text = "Quotation" Then
                    alarmReportQuotation()
                    alarmBirthday()
                    alarmSentToDoc()
                    alarmReport1()
                    checkAlarm1()
                End If


                ' checkAlarmConnecting1()
                InsertAutoNumberToGrid(Me.dgdthongbao)

                'End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub alarmSentToDoc()
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim currow As Integer
            Dim i As Integer
            sql = "select * from bookingagent where nhanvienchungtu like '%" & strUserId & "%'  and trangthai='CHO XU LY' order by convert(datetime,bookingdate) desc " 'and month(BOOKINGDATE)='" & CDate(Getdate()).Month & "'  and year(BOOKINGDATE)='" & CDate(Getdate()).Year & "'
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dgdthongbao.Rows.Add(1)
                    currow = dgdthongbao.RowCount - 2
                    ' hien thi noi dung bill Ib
                    dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Red
                    dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                    Try
                        dgdthongbao.Item("id", currow).Value = ds.Tables(0).Rows(i).Item("bookingagentID").ToString
                    Catch ex As Exception

                    End Try

                    dgdthongbao.Item("department", currow).Value = "Booking : " + ds.Tables(0).Rows(i).Item("bophan").ToString + "/" + ds.Tables(0).Rows(i).Item("dateupdate").ToString
                    dgdthongbao.Item("message", currow).Value = "Số Booking (Ref.) : " + ds.Tables(0).Rows(i).Item("gmd_bookingno").ToString + "/ " + vbCrLf + "Người liên hệ: " + ds.Tables(0).Rows(i).Item("contactPerson").ToString + "/ " + vbCrLf + " Nội dung: " + vbCrLf + ds.Tables(0).Rows(i).Item("sent").ToString + "/" + vbCrLf + "Trạng thái: " + ds.Tables(0).Rows(i).Item("TRANGTHAI").ToString + "/" + vbCrLf + "Ngày Booking: " + ds.Tables(0).Rows(i).Item("BOOKINGDATE").ToString + "/" + vbCrLf + "NV nhập:" + ds.Tables(0).Rows(i).Item("userupdate").ToString
                    currow += 1
                Next

            End If



        Catch ex As Exception

        End Try
    End Sub
    Public Sub alarmReportRecording()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim currow As Integer
            Dim i, j, k, ngay, thang As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            If UCase(gDepartment) = "MANAGEMENT" Then
                sql1 = "Select * From recording  left join customer on recording.customerid=customer.customer_id where done=0  and recording.continued=1 " '((day(limitedBooking)= '" & CDate(Getdate()).Day & "' and month(limitedBooking)= '" & CDate(Getdate()).Month & "' and year(limitedBooking)= '" & CDate(Getdate()).Year & "')) and continued=1 "

            Else
                sql1 = "Select * From recording  left join customer on recording.customerid=customer.customer_id where done=0 and salecode='" & strUserId & "'  and recording.continued=1 " '((day(limitedBooking)= '" & CDate(Getdate()).Day & "' and month(limitedBooking)= '" & CDate(Getdate()).Month & "' and year(limitedBooking)= '" & CDate(Getdate()).Year & "')) and continued=1 "

            End If
            ds1 = ReadDataSet(sql1)
            For k = 0 To 0


                If ds1.Tables(0).Rows.Count > 0 Then




                    For i = 0 To ds1.Tables(0).Rows.Count - 1
                        textA = " Alarm from : " + "Recording (KPIs) : " + "(" + ds1.Tables(0).Rows(i).Item("salecode").ToString.Trim + ")" + "(No. : " + ds1.Tables(0).Rows(i).Item("no").ToString.Trim + ")"
                        textb = "*/ " + ds1.Tables(0).Rows(i).Item("Company").ToString.Trim + " :  " + ds1.Tables(0).Rows(i).Item("meetingOutcomes").ToString.Trim + "(" + ds1.Tables(0).Rows(i).Item("date1").ToString.Trim + ")" + " -> " + ds1.Tables(0).Rows(i).Item("followUpIssue").ToString.Trim + "(" + ds1.Tables(0).Rows(i).Item("date2").ToString.Trim + ")" + vbCrLf
                        dgdthongbao.Rows.Add(1)
                        currow = dgdthongbao.RowCount - 2
                        ' hien thi noi dung bill Ib
                        dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        dgdthongbao.Item("department", currow).Value = textA
                        dgdthongbao.Item("message", currow).Value = textb
                    Next
                    ' If textA <> "" Then
                    'Dim frm As New frmThongbao
                    'frm.txtnoidung.Text = textA
                    'frm.Show()
                    'textA += "--------------------------------------------------------------------" + vbCrLf
                    'frmMain.ListThongbao.Text += vbCrLf + vbCrLf + textA + vbCrLf + vbCrLf


                    'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                    'DisplayMessage(True, textA)
                    'End If
                    'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                    'Return dt1.Rows(i).Item("optionvalue").ToString.Trim

                End If
            Next






        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub alarmBirthday()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim currow As Integer
            Dim i, j, k, ngay, thang, nam As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).AddDays(1).Day
            thang = CDate(Getdate()).AddDays(1).Month
            nam = CDate(Getdate()).AddDays(1).Year

            

            sql1 = "Select * From customer where day(birthday)='" & ngay & "' and month(birthday)='" & thang & "' and year(birthday)='" & nam & "'and  continued=1 " '((day(limitedBooking)= '" & CDate(Getdate()).Day & "' and month(limitedBooking)= '" & CDate(Getdate()).Month & "' and year(limitedBooking)= '" & CDate(Getdate()).Year & "')) and continued=1 "


            ds1 = ReadDataSet(sql1)
          

                If ds1.Tables(0).Rows.Count > 0 Then




                    For i = 0 To ds1.Tables(0).Rows.Count - 1
                    textA = " Alarm from : " + "Sales : " + "(" + ds1.Tables(0).Rows(i).Item("salename").ToString.Trim + ")" ' + "(No. : " + ds1.Tables(0).Rows(i).Item("no").ToString.Trim + ")"
                    textb = "Happy Birthday :  " + ds1.Tables(0).Rows(i).Item("Company").ToString.Trim + vbCrLf
                        dgdthongbao.Rows.Add(1)
                        currow = dgdthongbao.RowCount - 2
                        ' hien thi noi dung bill Ib
                    dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.White
                    dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        dgdthongbao.Item("department", currow).Value = textA
                        dgdthongbao.Item("message", currow).Value = textb
                    Next
                   

                End If







        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function checkAlarmConnecting() As String
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA As String
            Dim i, ngay, thang As Integer
            ngay = CDate(Getdate()).Day


            Dim textB As String
            SQL = " Select * From billoflading_house where date_of_issue <> '' and  continued=1"
            Dim dt2 As New DataTable
            dt2 = ReadTable(SQL)

            If dt2.Rows.Count = 0 Then
                'Return ""
            Else
                Dim C As Integer
                C = getOptionValue("frmthongbao", "OB", "Connecting", "Connecting", "C")
                Dim ts As Date = CDate(Getdate())
                For i = 0 To dt2.Rows.Count - 1 'CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim)


                    If ts.Date = CDate(dt2.Rows(i).Item("date_of_issue").ToString.Trim).Date.AddDays(C) Then
                        textB += dt2.Rows(i).Item("blh_no").ToString.Trim + vbCrLf
                    End If

                Next
                Dim t1, t2 As String
                If textB <> "" Then
                    t1 = " Thông báo từ OutBound : " + vbCrLf
                    t2 = "Những lô hàng này đã đến cảng chuyển tải ! " + vbCrLf + textB
                    Dim frm As New frmThongbao
                    frm.txtnoidung.Text = t1 + t2
                    frm.Show()


                    'DisplayMessage(True, )
                End If

                'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Public Sub alarmReport_theodoilohang()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim i, j, k, ngay, currow, thang As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            sql1 = "Select * From theodoilohang where day(timer)= '" & CDate(Getdate()).Day & "' and month(timer)= '" & CDate(Getdate()).Month & "' and year(timer)= '" & CDate(Getdate()).Year & "' and validuser like '%" & strUserName & "%'  "
            ds1 = ReadDataSet(sql1)
            For k = 0 To ds1.Tables(0).Rows.Count - 1


                'listUser = ds1.Tables(0).Rows(k).Item("validuser").ToString
                'If ds1.Tables(0).Rows.Count > 0 Then

                '    Dim list() As String
                '    listUser = listUser.Trim
                '    listUser = listUser.Remove(listUser.Length - 1, 1)
                '    list = listUser.Split(",")
                '    For j = 0 To list.Length - 1

                '        If UCase(strUserId) = UCase(list(j)) Then


                '            'SQL = " Select * From theodoilohanginbound  where theodoilohanginboundid='" & ds1.Tables(0).Rows(k).Item("theodoilohanginboundid").ToString & "' and day(timer)= '" & CDate(Getdate()).Day & "' and month(timer)= '" & CDate(Getdate()).Month & "' and year(timer)= '" & CDate(Getdate()).Year & "' and validuser like '%" & list(j).ToString & "%'   "
                '            'Dim dt1 As New DataTable
                '            'dt1 = ReadTable(SQL)
                '            Dim sqlbill As String
                '            Dim dsbill As New DataSet

                '            'If dt1.Rows.Count = 0 Then
                '            '    'Return ""
                '            'Else
                '            '    For i = 0 To dt1.Rows.Count - 1
                'sqlbill = "select * from inbound left join theodoilohanginbound on inbound.blib_id=theodoilohanginbound.inboundid where blib_id= '" & ds1.Tables(0).Rows(k).Item("inboundid").ToString & "' "
                'dsbill = ReadDataSet(sqlbill)
                '            If dsbill.Tables(0).Rows.Count > 0 Then
                '                Try
                textA = Getdate() + ": " + ds1.Tables(0).Rows(k).Item("bangoc").ToString.Trim + ": " + ds1.Tables(0).Rows(k).Item("items").ToString.Trim + " " + vbCrLf
                textb = ds1.Tables(0).Rows(k).Item("remarks").ToString.Trim + vbCrLf '+ " với  " + dt1.Rows(i).Item("company").ToString.Trim + " : " + vbCrLf + dt1.Rows(i).Item("remarks").ToString.Trim 

                '                        Catch ex As Exception

                'End Try
                'End If

                '    Next
                If textb <> "" Then

                    'Dim frm As New frmThongbao
                    'frm.txtnoidung.Text = textA
                    'frm.ShowDialog()
                    'textA += vbCrLf + "--------------------------------------------------------------------" + vbCrLf
                    'frmMain.ListThongbao.Text += textA + vbCrLf + vbCrLf
                    dgdthongbao.Rows.Add(1)
                    currow = dgdthongbao.RowCount - 2
                    ' hien thi noi dung bill Ib
                    dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Black
                    dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                    dgdthongbao.Item("department", currow).Value = textA
                    dgdthongbao.Item("message", currow).Value = textb
                    'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                    'DisplayMessage(True, textA)
                End If
                'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
                '                End If

                '            End If
                'Next

                'End If
            Next


        Catch ex As Exception
            '  DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub alarmReport_theodoilohanginbound()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim i, j, k, ngay, currow, thang As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            sql1 = "Select * From theodoilohanginbound where day(timer)= '" & CDate(Getdate()).Day & "' and month(timer)= '" & CDate(Getdate()).Month & "' and year(timer)= '" & CDate(Getdate()).Year & "' and validuser like '%" & strUserName & "%'  "
            ds1 = ReadDataSet(sql1)
            For k = 0 To ds1.Tables(0).Rows.Count - 1


                'listUser = ds1.Tables(0).Rows(k).Item("validuser").ToString
                'If ds1.Tables(0).Rows.Count > 0 Then

                '    Dim list() As String
                '    listUser = listUser.Trim
                '    listUser = listUser.Remove(listUser.Length - 1, 1)
                '    list = listUser.Split(",")
                '    For j = 0 To list.Length - 1

                '        If UCase(strUserId) = UCase(list(j)) Then


                '            'SQL = " Select * From theodoilohanginbound  where theodoilohanginboundid='" & ds1.Tables(0).Rows(k).Item("theodoilohanginboundid").ToString & "' and day(timer)= '" & CDate(Getdate()).Day & "' and month(timer)= '" & CDate(Getdate()).Month & "' and year(timer)= '" & CDate(Getdate()).Year & "' and validuser like '%" & list(j).ToString & "%'   "
                '            'Dim dt1 As New DataTable
                '            'dt1 = ReadTable(SQL)
                '            Dim sqlbill As String
                '            Dim dsbill As New DataSet

                '            'If dt1.Rows.Count = 0 Then
                '            '    'Return ""
                '            'Else
                '            '    For i = 0 To dt1.Rows.Count - 1
                'sqlbill = "select * from inbound left join theodoilohanginbound on inbound.blib_id=theodoilohanginbound.inboundid where blib_id= '" & ds1.Tables(0).Rows(k).Item("inboundid").ToString & "' "
                'dsbill = ReadDataSet(sqlbill)
                '            If dsbill.Tables(0).Rows.Count > 0 Then
                '                Try
                textA = Getdate() + ": " + ds1.Tables(0).Rows(k).Item("bangoc").ToString.Trim + ": " + ds1.Tables(0).Rows(k).Item("items").ToString.Trim + " " + vbCrLf
                textb = ds1.Tables(0).Rows(k).Item("remarks").ToString.Trim + vbCrLf '+ " với  " + dt1.Rows(i).Item("company").ToString.Trim + " : " + vbCrLf + dt1.Rows(i).Item("remarks").ToString.Trim 

                '                        Catch ex As Exception

                'End Try
                'End If

                '    Next
                If textb <> "" Then

                    'Dim frm As New frmThongbao
                    'frm.txtnoidung.Text = textA
                    'frm.ShowDialog()
                    'textA += vbCrLf + "--------------------------------------------------------------------" + vbCrLf
                    'frmMain.ListThongbao.Text += textA + vbCrLf + vbCrLf
                    dgdthongbao.Rows.Add(1)
                    currow = dgdthongbao.RowCount - 2
                    ' hien thi noi dung bill Ib
                    dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Black
                    dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                    dgdthongbao.Item("department", currow).Value = textA
                    dgdthongbao.Item("message", currow).Value = textb
                    'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                    'DisplayMessage(True, textA)
                End If
                'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
                '                End If

                '            End If
                'Next

                'End If
            Next


        Catch ex As Exception
            'DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub alarmReport_theodoilohanglogistics()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim i, j, k, ngay, currow, thang As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            sql1 = "Select * From theodoilohanglogistics where day(timer)= '" & CDate(Getdate()).Day & "' and month(timer)= '" & CDate(Getdate()).Month & "' and year(timer)= '" & CDate(Getdate()).Year & "' and validuser like '%" & strUserName & "%'  "
            ds1 = ReadDataSet(sql1)
            For k = 0 To ds1.Tables(0).Rows.Count - 1


                'listUser = ds1.Tables(0).Rows(k).Item("validuser").ToString
                'If ds1.Tables(0).Rows.Count > 0 Then

                '    Dim list() As String
                '    listUser = listUser.Trim
                '    listUser = listUser.Remove(listUser.Length - 1, 1)
                '    list = listUser.Split(",")
                '    For j = 0 To list.Length - 1

                '        If UCase(strUserId) = UCase(list(j)) Then


                '            'SQL = " Select * From theodoilohanginbound  where theodoilohanginboundid='" & ds1.Tables(0).Rows(k).Item("theodoilohanginboundid").ToString & "' and day(timer)= '" & CDate(Getdate()).Day & "' and month(timer)= '" & CDate(Getdate()).Month & "' and year(timer)= '" & CDate(Getdate()).Year & "' and validuser like '%" & list(j).ToString & "%'   "
                '            'Dim dt1 As New DataTable
                '            'dt1 = ReadTable(SQL)
                '            Dim sqlbill As String
                '            Dim dsbill As New DataSet

                '            'If dt1.Rows.Count = 0 Then
                '            '    'Return ""
                '            'Else
                '            '    For i = 0 To dt1.Rows.Count - 1
                'sqlbill = "select * from inbound left join theodoilohanginbound on inbound.blib_id=theodoilohanginbound.inboundid where blib_id= '" & ds1.Tables(0).Rows(k).Item("inboundid").ToString & "' "
                'dsbill = ReadDataSet(sqlbill)
                '            If dsbill.Tables(0).Rows.Count > 0 Then
                '                Try
                textA = Getdate() + ": " + ds1.Tables(0).Rows(k).Item("bangoc").ToString.Trim + ": " + ds1.Tables(0).Rows(k).Item("items").ToString.Trim + " " + vbCrLf
                textb = ds1.Tables(0).Rows(k).Item("remarks").ToString.Trim + vbCrLf '+ " với  " + dt1.Rows(i).Item("company").ToString.Trim + " : " + vbCrLf + dt1.Rows(i).Item("remarks").ToString.Trim 

                '                        Catch ex As Exception

                'End Try
                'End If

                '    Next
                If textb <> "" Then

                    'Dim frm As New frmThongbao
                    'frm.txtnoidung.Text = textA
                    'frm.ShowDialog()
                    'textA += vbCrLf + "--------------------------------------------------------------------" + vbCrLf
                    'frmMain.ListThongbao.Text += textA + vbCrLf + vbCrLf
                    dgdthongbao.Rows.Add(1)
                    currow = dgdthongbao.RowCount - 2
                    ' hien thi noi dung bill Ib
                    dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Black
                    dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                    dgdthongbao.Item("department", currow).Value = textA
                    dgdthongbao.Item("message", currow).Value = textb
                    'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                    'DisplayMessage(True, textA)
                End If
                'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
                '                End If

                '            End If
                'Next

                'End If
            Next


        Catch ex As Exception
            ' DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub alarmReportBooking1()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim currow As Integer
            Dim i, j, k, ngay, thang As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            sql1 = "Select * From containerOutboundNotify_sale  where (( month(hano_date)= '" & CDate(Getdate()).Month & "' and year(hano_date)= '" & CDate(Getdate()).Year & "')) and continued=1 " ' (day(limitedBooking)= '" & CDate(Getdate()).Day & "' and
            ds1 = ReadDataSet(sql1)
            For k = 0 To 0


                If ds1.Tables(0).Rows.Count > 0 Then


                    textA = " Alarm from : " + "Booking Department : "

                    For i = 0 To ds1.Tables(0).Rows.Count - 1
                        textb += "***" + ds1.Tables(0).Rows(i).Item("BookingNo").ToString.Trim + "- Vessel: " + ds1.Tables(0).Rows(i).Item("vessel").ToString.Trim + " - VoyNo: " + vbCrLf + ds1.Tables(0).Rows(i).Item("voyno").ToString.Trim + " - POL/POD: " + vbCrLf + ds1.Tables(0).Rows(i).Item("hano_pol").ToString.Trim + "/" + ds1.Tables(0).Rows(i).Item("hano_pod").ToString.Trim + " / Sales: " + ds1.Tables(0).Rows(i).Item("salecode").ToString.Trim + vbCrLf
                    Next
                    If textA <> "" Then
                        'Dim frm As New frmThongbao
                        'frm.txtnoidung.Text = textA
                        'frm.Show()
                        'textA += "--------------------------------------------------------------------" + vbCrLf
                        'frmMain.ListThongbao.Text += vbCrLf + vbCrLf + textA + vbCrLf + vbCrLf
                        dgdthongbao.Rows.Add(1)
                        currow = dgdthongbao.RowCount - 2
                        ' hien thi noi dung bill Ib
                        dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        dgdthongbao.Item("department", currow).Value = textA
                        dgdthongbao.Item("message", currow).Value = textb

                        'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                        'DisplayMessage(True, textA)
                    End If
                    'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                    'Return dt1.Rows(i).Item("optionvalue").ToString.Trim

                End If
            Next






        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub alarmReportQuotation()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim currow As Integer
            Dim i, j, k, ngay, thang As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            sql1 = "Select * From QuotationTico  where (( month(ngay)= '" & CDate(Getdate()).Month & "' and year(ngay)= '" & CDate(Getdate()).Year & "')) and continued=1 " ' (day(limitedBooking)= '" & CDate(Getdate()).Day & "' and
            ds1 = ReadDataSet(sql1)
            For k = 0 To 0


                If ds1.Tables(0).Rows.Count > 0 Then


                    textA = " Alarm from : " + "Sales Department : "

                    For i = 0 To ds1.Tables(0).Rows.Count - 1
                        textb += "***" + ds1.Tables(0).Rows(i).Item("no").ToString.Trim + "- Sales: " + ds1.Tables(0).Rows(i).Item("sale").ToString.Trim + " - Volume: " + vbCrLf + ds1.Tables(0).Rows(i).Item("volume").ToString.Trim + " - POL/POD: " + vbCrLf + ds1.Tables(0).Rows(i).Item("pol").ToString.Trim + "/" + ds1.Tables(0).Rows(i).Item("podel").ToString.Trim + vbCrLf
                    Next
                    If textA <> "" Then
                        'Dim frm As New frmThongbao
                        'frm.txtnoidung.Text = textA
                        'frm.Show()
                        'textA += "--------------------------------------------------------------------" + vbCrLf
                        'frmMain.ListThongbao.Text += vbCrLf + vbCrLf + textA + vbCrLf + vbCrLf
                        dgdthongbao.Rows.Add(1)
                        currow = dgdthongbao.RowCount - 2
                        ' hien thi noi dung bill Ib
                        dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        dgdthongbao.Item("department", currow).Value = textA
                        dgdthongbao.Item("message", currow).Value = textb

                        'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                        'DisplayMessage(True, textA)
                    End If
                    'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                    'Return dt1.Rows(i).Item("optionvalue").ToString.Trim

                End If
            Next






        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function checkAlarm1() As String
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA As String
            Dim i, ngay, thang, currow As Integer
            ngay = CDate(Getdate()).Day
            SQL = " Select * From (customerReport left join userlist on customerreport.userid=userlist.usr) left join customer on customer.customer_id=customerReport.customer_id  where day(visitdate)= '" & CDate(Getdate()).Day & "' and month(visitdate)= '" & CDate(Getdate()).Month & "' and year(visitdate)= '" & CDate(Getdate()).Year & "' and customerreport.continued=1 and customer.continued=1 and customer.branch like '%" & gBranch & "%' "
            Dim dt1 As New DataTable
            dt1 = ReadTable(SQL)
            textA = " Alarm from : " + vbCrLf
            If dt1.Rows.Count = 0 Then
                'Return ""
            Else
                For i = 0 To dt1.Rows.Count - 1
                    textA += dt1.Rows(i).Item("name").ToString.Trim + " with  " + dt1.Rows(i).Item("company").ToString.Trim + " : " + vbCrLf + dt1.Rows(i).Item("remarks").ToString.Trim + vbCrLf + vbCrLf + vbCrLf
                    textA += "--------------------------------------------------------------------" + vbCrLf
                Next
                If textA <> "" Then
                    'Dim frm As New frmThongbao
                    'frm.txtnoidung.Text = textA
                    'frm.ShowDialog()
                    'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                    'DisplayMessage(True, textA)
                End If
                'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
            End If
            '-----------------------------------
            'If CDate(Getdate()).Day = 1 Or CDate(Getdate()).Day = 15 Or CDate(Getdate()).Day = 7 Or CDate(Getdate()).Day = 22 Or CDate(Getdate()).Day = 30 Then
            '    DisplayMessage(True, "The System have to service, please contact us (Tel: 0908 349 945)")
            'End If
            Dim textB As String
            SQL = " Select * From outbound where ETA <> '' and  continued=1 and branch like '%" & gBranch & "%' "
            Dim dt2 As New DataTable
            dt2 = ReadTable(SQL)
            Dim t1, t2 As String
            Dim ts As Date
            If dt2.Rows.Count = 0 Then
                'Return ""
            Else
                Dim C, k As Integer
                C = getOptionValue("frmthongbao", "OB", "Arrivaldate", "Arrivaldate", "C")
                For k = 0 To C
                    textB = ""
                    ts = CDate(Getdate()).AddDays(k)
                    For i = 0 To dt2.Rows.Count - 1 'CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim)


                        If ts.Date = CDate(dt2.Rows(i).Item("eta").ToString.Trim).Date Then
                            textB += "- " + dt2.Rows(i).Item("mblmawb").ToString.Trim + vbCrLf
                            textB += "- " + dt2.Rows(i).Item("shipper").ToString.Trim + vbCrLf
                            textB += "- " + dt2.Rows(i).Item("salecode").ToString.Trim + vbCrLf
                            textB += "- " + dt2.Rows(i).Item("saycontainer").ToString.Trim + vbCrLf
                        End If

                    Next

                    If textB <> "" Then
                        t1 = Getdate() + ":  Alarm from OutBound : " + vbCrLf
                        t2 = "(Những lô hàng này còn) " + k.ToString + " (ngày nữa sẽ đến!) " + vbCrLf + textB
                        'Dim frm As New frmThongbao
                        'frm.txtnoidung.Text = t1 + t2
                        'frm.ShowDialog()
                        't2 += vbCrLf + "--------------------------------------------------------------------" + vbCrLf
                        'frmMain.ListThongbao.Text += t1 + t2 + vbCrLf + vbCrLf


                        dgdthongbao.Rows.Add(1)
                        currow = dgdthongbao.RowCount - 2
                        ' hien thi noi dung bill Ib
                        dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(-95281)
                        dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        dgdthongbao.Item("department", currow).Value = t1
                        dgdthongbao.Item("message", currow).Value = t2



                        'DisplayMessage(True, )
                    End If
                Next

            End If

            Dim textc As String
            SQL = " Select * From inbound where ETA <> '' and  continued=1 and branch like '%" & gBranch & "%'"
            Dim dt3 As New DataTable
            dt3 = ReadTable(SQL)
            Dim t13, t23 As String
            Dim ts3 As Date
            If dt3.Rows.Count = 0 Then
                'Return ""
            Else
                Dim C, k As Integer
                C = getOptionValue("frmthongbao", "OB", "Arrivaldate", "Arrivaldate", "C")
                For k = 0 To C
                    textc = ""
                    ts3 = CDate(Getdate()).AddDays(k)
                    For i = 0 To dt3.Rows.Count - 1 'CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim)


                        If ts3.Date = CDate(dt3.Rows(i).Item("eta").ToString.Trim).Date Then
                            textc += "- " + dt3.Rows(i).Item("hbl").ToString.Trim + vbCrLf
                            textc += "- " + dt3.Rows(i).Item("consignee").ToString.Trim + vbCrLf
                            textc += "- " + dt3.Rows(i).Item("salecode").ToString.Trim + vbCrLf
                            textc += "- " + dt3.Rows(i).Item("saycontainer").ToString.Trim + vbCrLf
                        End If

                    Next

                    If textc <> "" Then
                        t13 = Getdate() + ":  Alarm from InBound : " + vbCrLf
                        t23 = "(Những lô hàng này còn) " + k.ToString + " (ngày nữa sẽ đến!) " + vbCrLf + textc
                        'Dim frm As New frmThongbao
                        'frm.txtnoidung.Text = t1 + t2
                        'frm.ShowDialog()
                        't23 += vbCrLf + "--------------------------------------------------------------------" + vbCrLf
                        ' frmMain.ListThongbao.Text += t13 + t23 + vbCrLf + vbCrLf

                        dgdthongbao.Rows.Add(1)
                        currow = dgdthongbao.RowCount - 2
                        ' hien thi noi dung bill Ib
                        dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(-95281)
                        dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        dgdthongbao.Item("department", currow).Value = t13
                        dgdthongbao.Item("message", currow).Value = t23

                        'DisplayMessage(True, )
                    End If
                Next

            End If
            '-------------------------------------------------

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function checkAlarmRecording() As String
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim i, k, j, ngay, thang, currow As Integer
            ngay = CDate(Getdate()).Day
            Dim ds1 As New DataSet
            SQL = " Select * From (recording left join userlist on recording.userupdate=userlist.usr)  where ((day(ngaythongbao)= '" & CDate(Getdate()).Day & "' and month(ngaythongbao)= '" & CDate(Getdate()).Month & "' and year(ngaythongbao)= '" & CDate(Getdate()).Year & "') or Daily= 1 ) and recording.continued=1    "
            Dim dt1 As New DataTable
            ds1 = ReadDataSet(SQL)
            textA = " Alarm from (Recording): " + vbCrLf
            If ds1.Tables(0).Rows.Count = 0 Then
                'Return ""
            Else
                For ij As Integer = 0 To ds1.Tables(0).Rows.Count - 1


                    listUser = ds1.Tables(0).Rows(ij).Item("sentuser").ToString
                    Dim list() As String
                    listUser = listUser.Trim
                    listUser = listUser.Remove(listUser.Length - 1, 1)
                    list = listUser.Split(",")
                    For j = 0 To list.Length - 1

                        If UCase(strUserId) = UCase(list(j)) Then
                            'For i = 0 To ds1.Tables(0).Rows.Count - 1

                            textb += ds1.Tables(0).Rows(ij).Item("salecode").ToString.Trim + " with  " + getUserName(strUserId) + " : " + vbCrLf + ds1.Tables(0).Rows(ij).Item("meetingOutcomes").ToString.Trim + vbCrLf + " Follow Up Issue : " + vbCrLf + ds1.Tables(0).Rows(ij).Item("followUpIssue").ToString.Trim + vbCrLf + vbCrLf
                            ' textA += vbCrLf + "--------------------------------------------------------------------" + vbCrLf
                            ' Next
                            If textb <> "" Then
                                'Dim frm As New frmThongbao
                                'frm.txtnoidung.Text = textA
                                'frm.ShowDialog()
                                'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                                'DisplayMessage(True, textA)
                                dgdthongbao.Rows.Add(1)
                                currow = dgdthongbao.RowCount - 2
                                ' hien thi noi dung bill Ib
                                dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Yellow
                                dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                                dgdthongbao.Item("department", currow).Value = textA
                                dgdthongbao.Item("message", currow).Value = textb


                                ' frmMain.ListThongbao.Text += textA + vbCrLf + vbCrLf
                            End If

                            textb = ""
                        End If
                    Next
                Next
                'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
            End If

            '-----------------------------------
            'If CDate(Getdate()).Day = 1 Or CDate(Getdate()).Day = 15 Or CDate(Getdate()).Day = 7 Or CDate(Getdate()).Day = 22 Or CDate(Getdate()).Day = 30 Then
            '    DisplayMessage(True, "The System have to service, please contact us (Tel: 0908 349 945)")
            'End If
            'Dim textB As String
            'SQL = " Select * From billoflading_house where arrivaldate <> '' and  continued=1"
            'Dim dt2 As New DataTable
            'dt2 = ReadTable(SQL)
            'Dim t1, t2 As String
            'Dim ts As Date
            'If dt2.Rows.Count = 0 Then
            '    'Return ""
            'Else
            '    Dim C, k As Integer
            '    C = getOptionValue("frmthongbao", "OB", "Arrivaldate", "Arrivaldate", "C")
            '    For k = 0 To C
            '        textB = ""
            '        ts = CDate(Getdate()).AddDays(k)
            '        For i = 0 To dt2.Rows.Count - 1 'CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim)


            '            If ts.Date = CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim).Date Then
            '                textB += dt2.Rows(i).Item("blh_no").ToString.Trim + vbCrLf
            '            End If

            '        Next

            '        If textB <> "" Then
            '            t1 = " Thông báo từ OutBound : " + vbCrLf
            '            t2 = "Những lô hàng này còn " + k.ToString + " ngày nữa sẽ đến! " + vbCrLf + textB
            '            Dim frm As New frmThongbao
            '            frm.txtnoidung.Text = t1 + t2
            '            frm.Show()


            '            'DisplayMessage(True, )
            '        End If
            '    Next

            'End If

        Catch ex As Exception
            '  DisplayMessage(True, Err.Description)
        End Try
    End Function
    Public Sub alarmReport1()
        Try
            '-------------lay ngay sinh nhan vien
            Dim SQL, textA, textb, listUser As String
            Dim i, j, k, ngay, thang, currow As Integer
            Dim sql1 As String
            Dim ds1 As New DataSet
            ngay = CDate(Getdate()).Day
            sql1 = "Select * From (customerReport left join userlist on customerreport.userid=userlist.usr) left join customer on customer.customer_id=customerReport.customer_id  where ((day(visitdate)= '" & CDate(Getdate()).Day & "' and month(visitdate)= '" & CDate(Getdate()).Month & "' and year(visitdate)= '" & CDate(Getdate()).Year & "') or daily=1) and customerreport.continued=1   and customer.continued=1 and customer.branch like '%" & gBranch & "%' "
            ds1 = ReadDataSet(sql1)
            For k = 0 To ds1.Tables(0).Rows.Count - 1


                listUser = ds1.Tables(0).Rows(k).Item("validuser").ToString
                If ds1.Tables(0).Rows.Count > 0 Then
                    If listUser = "" Then
                        'SQL = " Select * From (customerReport left join userlist on customerreport.userid=userlist.usr) left join customer on customer.customer_id=customerReport.customer_id  where day(visitdate)= '" & CDate(Getdate()).Day & "' and month(visitdate)= '" & CDate(Getdate()).Month & "' and year(visitdate)= '" & CDate(Getdate()).Year & "' and customerreport.continued=1"
                        'Dim dt1 As New DataTable
                        'dt1 = ReadTable(SQL)
                        'textA = " Thông báo từ : " + vbCrLf
                        'If dt1.Rows.Count = 0 Then
                        '    'Return ""
                        'Else
                        '    For i = 0 To dt1.Rows.Count - 1
                        '        textA += dt1.Rows(i).Item("name").ToString.Trim + " với khách hàng  " + dt1.Rows(i).Item("company").ToString.Trim + " : " + vbCrLf + dt1.Rows(i).Item("remarks").ToString.Trim + vbCrLf
                        '    Next
                        '    If textA <> "" Then
                        '        Dim frm As New frmThongbao
                        '        frm.txtnoidung.Text = textA
                        '        frm.ShowDialog()
                        '        'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                        '        'DisplayMessage(True, textA)
                        '    End If
                        '    'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                        '    'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
                        'End If
                    Else
                        Dim list() As String
                        listUser = listUser.Trim
                        listUser = listUser.Remove(listUser.Length - 1, 1)
                        list = listUser.Split(",")
                        For j = 0 To list.Length - 1

                            If UCase(strUserId) = UCase(list(j)) Then


                                SQL = " Select * From (customerReport left join userlist on customerreport.userid=userlist.usr) left join customer on customer.customer_id=customerReport.customer_id  where ((day(visitdate)= '" & CDate(Getdate()).Day & "' and month(visitdate)= '" & CDate(Getdate()).Month & "' and year(visitdate)= '" & CDate(Getdate()).Year & "') or daily=1) and validuser like '%" & list(j).ToString & "%' and customerreport.continued=1  and customer.continued=1  "
                                Dim dt1 As New DataTable
                                dt1 = ReadTable(SQL)
                                textA = Getdate() + ":  Alarm from Report (Customer): " + vbCrLf
                                If dt1.Rows.Count = 0 Then
                                    'Return ""
                                Else
                                    For i = 0 To dt1.Rows.Count - 1
                                        textb += dt1.Rows(i).Item("name").ToString.Trim + " with  " + dt1.Rows(i).Item("company").ToString.Trim + " : " + vbCrLf + dt1.Rows(i).Item("remarks").ToString.Trim + vbCrLf
                                    Next
                                    If textb <> "" Then
                                        'Dim frm As New frmThongbao
                                        'frm.txtnoidung.Text = textA
                                        'frm.ShowDialog()
                                        dgdthongbao.Rows.Add(1)
                                        currow = dgdthongbao.RowCount - 2
                                        ' hien thi noi dung bill Ib
                                        dgdthongbao.Rows(currow).DefaultCellStyle.BackColor = Color.Brown
                                        dgdthongbao.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                        dgdthongbao.Item("department", currow).Value = textA
                                        dgdthongbao.Item("message", currow).Value = textb



                                        'VB6.ShowForm(frmThongbao, VB6.FormShowConstants.Modal, Me)
                                        'DisplayMessage(True, textA)
                                    End If
                                    'DisplayMessage(True, " Happy birthday Mr./Ms./Mrs. ( " + dt1.Rows(i).Item("Name").ToString.Trim + " )")
                                    'Return dt1.Rows(i).Item("optionvalue").ToString.Trim
                                End If
                            End If
                        Next

                    End If


                Else

                End If

            Next
            '-----------------------------------
            'If CDate(Getdate()).Day = 1 Or CDate(Getdate()).Day = 15 Or CDate(Getdate()).Day = 7 Or CDate(Getdate()).Day = 22 Or CDate(Getdate()).Day = 30 Then
            '    DisplayMessage(True, "The System have to service, please contact us (Tel: 0908 349 945)")
            'End If
            'Dim textB As String
            'SQL = " Select * From billoflading where arrivaldate <> '' and  continued=1"
            'Dim dt2 As New DataTable
            'dt2 = ReadTable(SQL)
            'Dim t1, t2 As String
            'Dim ts As Date
            'If dt2.Rows.Count = 0 Then
            '    'Return ""
            'Else
            '    Dim C, k As Integer
            '    C = getOptionValue("frmthongbao", "OB", "Arrivaldate", "Arrivaldate", "C")
            '    For k = 0 To C
            '        textB = ""
            '        ts = CDate(Getdate()).AddDays(k)
            '        For i = 0 To dt2.Rows.Count - 1 'CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim)


            '            If ts.Date = CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim).Date Then
            '                textB += dt2.Rows(i).Item("bl_no").ToString.Trim + vbCrLf
            '            End If

            '        Next

            '        If textB <> "" Then
            '            t1 = " Thông báo từ OutBound : " + vbCrLf
            '            t2 = "Những lô hàng này còn " + k.ToString + " ngày nữa sẽ đến! " + vbCrLf + textB
            '            Dim frm As New frmThongbao
            '            frm.txtnoidung.Text = t1 + t2
            '            frm.ShowDialog()


            '            'DisplayMessage(True, )
            '        End If
            '    Next

            'End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmThongbao__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetDefaultGrid(Me.dgdthongbao, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsTruckingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogisticsTruckingToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                gNhom = "LOGISTICS-CUSTOMS"

                Dim form As New frmLogistics 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()
                ' gNhom = "AGENCY-EXPORT"

                gtext = "Export (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                ' Dim frm As New frmOutbound
                ' frm.Show()

                If LoginSucceeded = True Then
                    Dim form As New frmOutbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If

                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Try

            If LoginSucceeded Then

                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HideẨnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideẨnToolStripMenuItem.Click
        Try
            Dim chk As Integer
            Dim mId As String
            Dim sql As String
            Dim ds As New DataSet
            Dim cmd As New ADODB.Command
            chk = Me.dgdthongbao.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If

            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.dgdthongbao.Rows.Count > 0 Then
                index = Me.dgdthongbao.CurrentRow.Index
            Else
                Exit Sub
            End If

            If index >= 0 Then
                Mid = Me.dgdthongbao.Item("id", index).Value.ToString.Trim
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "update  bookingagent set trangthai='DA NHAN' where BookingAgentID= '" & mId & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            End If
            Button5_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
End Class