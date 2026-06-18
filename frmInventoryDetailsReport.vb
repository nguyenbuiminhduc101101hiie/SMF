Public Class frmInventoryDetailsReport

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub dem(ByVal location As String)
        Try
            Try
                Dim sql As String
                Dim i, ic As Integer
                Dim ds As New DataSet
                Dim sqlc As String
                Dim dsc As New DataSet

              


                Dim location_ As String = ""
                Dim currow As Integer
                'If Me.chkall.Checked = True Then
                '    sql = "select distinct socont from containerstatus "

                'Else
                sql = "select distinct socont from containerstatus   "

                'End If
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Dim trung As Integer = 0
                        ' ung voi moi cont, lay ngay lon nhat
                        sqlc = " select top 5 * from containerstatus left join container on containerstatus.socont=container.container_no where convert(datetime,status_date) <= '" & Me.DateTimePicker1.Value.Date & "' and socont='" & ds.Tables(0).Rows(i).Item("socont").ToString & "' "
                        sqlc += "  order by convert(datetime,status_date) desc "
                        dsc = ReadDataSet(sqlc)
                        If dsc.Tables(0).Rows.Count > 0 Then
                            ' kiem tra 5 dong sau cung lay ra neu co 2 lam fulim thi bao loi
                            For ic = 0 To dsc.Tables(0).Rows.Count - 1
                                If UCase(dsc.Tables(0).Rows(ic).Item("status").ToString) = "FULIM" Then
                                    trung += 1
                                End If

                            Next
                            If trung > 1 Then
                                DisplayMessage(True, "Kiem tra lai container :" + dsc.Tables(0).Rows(ic).Item("socont").ToString)
                                GoTo next_
                            End If
                            Me.DataGridView1.Rows.Add(1)
                            currow = DataGridView1.RowCount - 2
                            For ic = 0 To dsc.Tables(0).Rows.Count - 1


                                Me.DataGridView1.Item("seg", currow).Value = (currow + 1).ToString
                                Me.DataGridView1.Item("location", currow).Value = dsc.Tables(0).Rows(ic).Item("location").ToString
                                Me.DataGridView1.Item("container", currow).Value = dsc.Tables(0).Rows(ic).Item("socont").ToString
                                Me.DataGridView1.Item("size", currow).Value = dsc.Tables(0).Rows(ic).Item("ctn_size_type").ToString
                          
                                If dsc.Tables(0).Rows(ic).Item("opr").ToString <> "" Then
                                    Me.DataGridView1.Item("opr", currow).Value = dsc.Tables(0).Rows(ic).Item("opr").ToString
                                End If



                           
                                If dsc.Tables(0).Rows(ic).Item("FL").ToString <> "" Then
                                    Me.DataGridView1.Item("FE", currow).Value = dsc.Tables(0).Rows(ic).Item("FL").ToString
                                End If





                                If UCase(dsc.Tables(0).Rows(ic).Item("status").ToString) = "FULIM" Then
                                    Me.DataGridView1.Item("fulim", currow).Value = dsc.Tables(0).Rows(ic).Item("status_date").ToString
                                    ' Me.DataGridView1.Item("depot", currow).Value = dsc.Tables(0).Rows(ic).Item("depot").ToString
                                End If

                                If UCase(dsc.Tables(0).Rows(ic).Item("status").ToString) = "TRIMP" Then
                                    Me.DataGridView1.Item("trimp", currow).Value = dsc.Tables(0).Rows(ic).Item("status_date").ToString
                                    '  Me.DataGridView1.Item("depot", currow).Value = dsc.Tables(0).Rows(ic).Item("depot").ToString
                                End If
                                If UCase(dsc.Tables(0).Rows(ic).Item("status").ToString) = "TREXP" Then
                                    Me.DataGridView1.Item("trexp", currow).Value = dsc.Tables(0).Rows(ic).Item("status_date").ToString
                                    ' Me.DataGridView1.Item("loading", currow).Value = dsc.Tables(0).Rows(ic).Item("loading").ToString

                                End If
                                If UCase(dsc.Tables(0).Rows(ic).Item("status").ToString) = "FULEX" Then
                                    Me.DataGridView1.Item("fulex", currow).Value = dsc.Tables(0).Rows(ic).Item("status_date").ToString
                                    '  Me.DataGridView1.Item("loading", currow).Value = dsc.Tables(0).Rows(ic).Item("loading").ToString


                                End If
                                If dsc.Tables(0).Rows(ic).Item("depot").ToString <> "" Then
                                    Me.DataGridView1.Item("depot", currow).Value = dsc.Tables(0).Rows(ic).Item("depot").ToString
                                End If
                                If dsc.Tables(0).Rows(ic).Item("FL").ToString <> "" Then
                                    Me.DataGridView1.Item("FE", currow).Value = dsc.Tables(0).Rows(ic).Item("FL").ToString
                                End If
                                If dsc.Tables(0).Rows(ic).Item("LOADING").ToString <> "" Then
                                    Me.DataGridView1.Item("LOADING", currow).Value = dsc.Tables(0).Rows(ic).Item("LOADING").ToString
                                End If
                            Next
                            ' cont40FRMT += 1



                        End If
next_:
                    Next
                End If



                ' ghi vao luo



            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.DataGridView1.Rows.Clear()
            'If Me.chkall.Checked = True Then
            '    dem("VNSGN")
            '    dem("VNHPH")
            '    dem("VNHAN")
            '    dem("VNDAD")
            'Else
            dem("")
            'End If
        Catch ex As Exception

        End Try
    End Sub
End Class