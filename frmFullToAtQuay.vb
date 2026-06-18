Public Class frmFullToAtQuay
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try

                Dim TempHouseBill As TextBox
                TempHouseBill = Nothing
                'For i As Integer = 0 To arrHouseBill.Length - 2
                '    If arrHouseBill(i).Focused = True Then
                '        TempHouseBill = arrHouseBill(i)
                '        Exit For
                '    End If
                'Next
                'If TempHouseBill Is Nothing Then
                '    MsgBox("You Have to Focus a House Bill Text box")
                '    Return
                'End If
                Dim thanghientai, thangsosanh As String
                thanghientai = CDate(Getdate()).Date.Month
                Try
                    Select Case UCase(thanghientai)   ' 
                        Case "1"   '
                            thangsosanh = "01"
                        Case "2"   '
                            thangsosanh = "02"
                        Case "3" 'Or "MAR"   '
                            thangsosanh = "03"
                        Case "4" 'Or "APR"   '
                            thangsosanh = "04"
                        Case "5" 'Or "MAY"   '
                            thangsosanh = "05"
                        Case "6" 'Or "JUN"   '
                            thangsosanh = "06"
                        Case "7" 'Or "JUL"   '
                            thangsosanh = "07"
                        Case "8" ' Or "AUG"   '
                            thangsosanh = "08"
                        Case "9" 'Or "SEP"   '
                            thangsosanh = "09"

                        Case "10" ' Or "OCT"   '
                            thangsosanh = "10"

                        Case "11" ' Or "NOV"   '
                            thangsosanh = "11"
                        Case "12" 'Or "DEC"   '
                            thangsosanh = "12"



                    End Select
                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
                '-----
                Dim nam As String
                nam = CDate(Getdate()).Year.ToString
                '-------------
                Dim so As String = GetBookingNumberFromDB()
                Dim sokhong As String
                If CInt(so) < 10 Then
                    sokhong = "000"
                ElseIf CInt(so) > 9 And CInt(so) < 100 Then
                    sokhong = "00"
                ElseIf CInt(so) > 99 And CInt(so) < 1000 Then
                    sokhong = "0"
                ElseIf CInt(so) > 999 And CInt(so) < 10000 Then
                    sokhong = "0"

                End If
                '  Me.txtRef.Text = Me.cbobranch.Text + Me.cbotat.Text + nam.ToString + thangsosanh.ToString + sokhong + so.ToString
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select check_,inboundContainersid,inboundid,containerno,containertype,mbl,hbl,mblexport,hblexport,ngayofo,ngaydso,bairong from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where ifd=0 and dco=0 and emm=0 and dso=0 and ofo=1 and oeo=0 and bff=0 and convert(datetime,ngayofo) ='" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "'  AND nvocc=1 "
            ds = ReadDataSet(sql)
            Me.lblcontExport.Text = "Hiện có " + ds.Tables(0).Rows.Count.ToString + " Containers đang trạng thái Cont.Full to at Quay."

            Me.DataGridView2.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.DataGridView2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim sql, id, value, strSQL As String
            Dim ds As New DataSet
            If Me.chkand.Checked = True Then
                sql = " select check_,inboundContainersid,inboundid,containerno,containertype,ngaydso,mbl,hbl from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where ifd=0 and dco=0 and emm=0 and dso=1 and ofo=0 and oeo=0 and bff=0  and convert(datetime,ngaydso) <= '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and nvocc=1  and containerno like '%" & Me.txtContainer.Text & "%' "

            Else
                sql = " select check_,inboundContainersid,inboundid,containerno,containertype,ngaydso,mbl,hbl from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where ifd=0 and dco=0 and emm=0 and dso=1 and ofo=0 and oeo=0 and bff=0  and convert(datetime,ngaydso) <= '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and nvocc=1 "


                ' sql = " select check_,inboundContainersid,inboundid,containerno,containertype,ngaydso,mbl,hbl from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where ifd=0 and dco=0 and emm=0 and dso=1 and ofo=0 and oeo=0 and bff=0  and convert(datetime,ngayemptytoshipper) <= '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and nvocc=1  "

                '   sql = " select check_,inboundContainersid,inboundid,containerno,containertype,ngayemptytoshipper,mbl,hbl from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where  contdaytaicang=0 and contdatravedaily=0 and contdaydangtrenduong=0 and contRongTaiBai=0 and emptytoshipper=1 and convert(datetime,ngayemptytoshipper) <= '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and nvocc=1  "

            End If
            ds = ReadDataSet(sql)
            Me.DataGridView1.DataSource = ds.Tables(0)
            Me.lblcontRong.Text = "Hiện có " + ds.Tables(0).Rows.Count.ToString + " Containers đang trạng thái giao rỗng cho Shipper (DSO)."
            InsertAutoNumberToGrid(Me.DataGridView1)


            ''
            Me.cbohblexport.Items.Clear()
            id = "blob_id"
            value = "mblmawb"
            strSQL = "Select  blob_id,mblmawb from outbound order by mblmawb "
            loadDataToObject(Me.cbohblexport, strSQL, id, value)
            '-----------------------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ' THEM
            '=========='
            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            Dim i As Integer
            If Me.cbohblexport.Text = "" Then
                DisplayMessage(True, "HBL(export) ?")
                Me.cbohblexport.Focus()
                Exit Sub
            End If


            For i = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Item("checkadd", i).Value.ToString = "True" Then
                    strQuery = "Select top 1 * From containerrepair Where inboundcontainersid='" & Me.DataGridView1.Item("InboundContainersID", i).Value.ToString & "' "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If Not rs.EOF Then



                            .Fields("ngayofo").Value = Me.DateTimePicker1.Value.Date
                            .Fields("ifd").Value = "False"
                            .Fields("dco").Value = "False"
                            .Fields("emm").Value = "False"
                            .Fields("dso").Value = "False"
                            .Fields("ofo").Value = "True"
                            .Fields("oeo").Value = "False"
                            .Fields("bff").Value = "False"
                            .Fields("hblexport").Value = Me.cbohblexport.Text
                            .Fields("mblexport").Value = Me.cboMBLexport.Text
                            .Update()
                        End If
                    End With
                    rs.Close()
                End If
            Next
            ' kiem tra tung dong cua row, neu =check= true thi lay ra inboundcontainersid, -> update cont
            Button6_Click(sender, e)

            Button2_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Try
                ' THEM
                '=========='
                Dim rs As New ADODB.Recordset
                Dim strQuery As String
                Dim i As Integer
                For i = 0 To Me.DataGridView2.Rows.Count - 1
                    If Me.DataGridView2.Item("checkdel", i).Value.ToString = "True" Then
                        strQuery = "Select top 1 * From containerrepair Where inboundcontainersid='" & Me.DataGridView2.Item("InboundContainersID_", i).Value.ToString & "' "
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs
                            If Not rs.EOF Then
                                .Fields("ngayofo").Value = ""
                                .Fields("ifd").Value = "False"
                                .Fields("dco").Value = "False"
                                .Fields("emm").Value = "False"
                                .Fields("dso").Value = "True"
                                .Fields("ofo").Value = "False"
                                .Fields("oeo").Value = "False"
                                .Fields("bff").Value = "False"
                                .Fields("hblexport").Value = ""
                                .Fields("mblexport").Value = ""
                                .Update()
                            End If
                        End With
                        rs.Close()
                    End If
                Next
                ' kiem tra tung dong cua row, neu =check= true thi lay ra inboundcontainersid, -> update cont
                Button6_Click(sender, e)

                Button2_Click(sender, e)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Try
                If Me.DataGridView2.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                ExportExecel(Me.DataGridView2, Me)
                'SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select check_,inboundContainersid,inboundid,containerno,containertype,mbl,hbl,ngaycdtc,ngaycddtd,bairong from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where controngtaibai= 0 and contdaytaicang=0 and contdatravedaily=0 and contdaydangtrenduong=1 and convert(datetime,ngaycddtd) ='" & Me.DateTimePicker1.Value.Date & "' AND nvocc=1 "
            ds = ReadDataSet(sql)
            Me.lblcontExport.Text = "Hiện có " + ds.Tables(0).Rows.Count.ToString + " Containers đang trạng thái Cont. đầy - khách hàng nhận hàng."

            Me.DataGridView2.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.DataGridView2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            Dim i As Integer
            Dim id, value, strSQL As String

            For i = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Item("checkadd", i).Value.ToString = "True" Then
                    ' Me.DataGridView1.Item("InboundContainersID", i).Value.ToString

                    ''
                    Me.cbohblexport.Items.Clear()
                    id = "blob_id"
                    value = "mblmawb"
                    strSQL = "Select  blob_id,mblmawb from outbound left join containertype on outbound.blob_id=containertype.outboundid where containerno = '" & Me.DataGridView1.Item("containerno", i).Value.ToString & "' order by mblmawb "
                    loadDataToObject(Me.cbohblexport, strSQL, id, value)

                    ''
                    Me.cboMBLexport.Items.Clear()
                    id = "blob_id"
                    value = "mblcarrier"
                    strSQL = "Select  blob_id,mblcarrier from outbound left join containertype on outbound.blob_id=containertype.outboundid where containerno = '" & Me.DataGridView1.Item("containerno", i).Value.ToString & "' order by mblcarrier "
                    loadDataToObject(Me.cboMBLexport, strSQL, id, value)



                    '-----------------------------------------------
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class