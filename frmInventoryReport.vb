Public Class frmInventoryReport

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
                Dim i As Integer
                Dim ds As New DataSet
                Dim sqlc As String
                Dim dsc As New DataSet

                Dim cont20FI_VNSGN, cont20FI_VNHAN, cont20FI_VNHPH, cont20FI_VNDAD As Integer
                Dim cont40FI_VNSGN, cont40FI_VNHAN, cont40FI_VNHPH, cont40FI_VNDAD As Integer
                Dim cont40HCFI_VNSGN, cont40HCFI_VNHPH, cont40HCFI_VNHAN, cont40HCFI_VNDAD As Integer
                Dim cont45HCFI_VNSGN, cont45HCFI_VNHPH, cont45HCFI_VNHAN, cont45HCFI_VNDAD As Integer

                Dim cont20TI_VNSGN, cont20TI_VNHPH, cont20TI_VNHAN, cont20TI_VNDAD As Integer
                Dim cont40TI_VNSGN, cont40TI_VNHPH, cont40TI_VNHAN, cont40TI_VNDAD As Integer
                Dim cont40HCTI_VNSGN, cont40HCTI_VNHPH, cont40HCTI_VNHAN, cont40HCTI_VNDAD As Integer
                Dim cont45HCTI_VNSGN, cont45HCTI_VNHPH, cont45HCTI_VNHAN, cont45HCTI_VNDAD As Integer

                Dim cont20TE_VNSGN, cont20TE_VNHPH, cont20TE_VNHAN, cont20TE_VNDAD As Integer
                Dim cont40TE_VNSGN, cont40TE_VNHPH, cont40TE_VNHAN, cont40TE_VNDAD As Integer
                Dim cont40HCTE_VNSGN, cont40HCTE_VNHPH, cont40HCTE_VNHAN, cont40HCTE_VNDAD As Integer
                Dim cont45HCTE_VNSGN, cont45HCTE_VNHPH, cont45HCTE_VNHAN, cont45HCTE_VNDAD As Integer

                Dim cont20FE_VNSGN, cont20FE_VNHPH, cont20FE_VNHAN, cont20FE_VNDAD As Integer
                Dim cont40FE_VNSGN, cont40FE_VNHPH, cont40FE_VNHAN, cont40FE_VNDAD As Integer
                Dim cont40HCFE_VNSGN, cont40HCFE_VNHPH, cont40HCFE_VNHAN, cont40HCFE_VNDAD As Integer
                Dim cont45HCFE_VNSGN, cont45HCFE_VNHPH, cont45HCFE_VNHAN, cont45HCFE_VNDAD As Integer

                Dim cont20GPMT_VNSGN, cont20GPMT_VNHPH, cont20GPMT_VNHAN, cont20GPMT_VNDAD As Integer
                Dim cont40GPMT_VNSGN, cont40GPMT_VNHPH, cont40GPMT_VNHAN, cont40GPMT_VNDAD As Integer
                Dim cont40HCMT_VNSGN, cont40HCMT_VNHPH, cont40HCMT_VNHAN, cont40HCMT_VNDAD As Integer
                Dim cont45HCMT_VNSGN, cont45HCMT_VNHPH, cont45HCMT_VNHAN, cont45HCMT_VNDAD As Integer

                Dim cont20RFMT_VNSGN, cont20RFMT_VNHPH, cont20RFMT_VNHAN, cont20RFMT_VNDAD As Integer

                Dim cont40RFMT_VNSGN, cont40RFMT_VNHPH, cont40RFMT_VNHAN, cont40RFMT_VNDAD As Integer

                Dim cont20OTMT_VNSGN, cont20OTMT_VNHPH, cont20OTMT_VNHAN, cont20OTMT_VNDAD As Integer
                Dim cont40OTMT_VNSGN, cont40OTMT_VNHPH, cont40OTMT_VNHAN, cont40OTMT_VNDAD As Integer

                Dim cont20FRMT_VNSGN, cont20FRMT_VNHPH, cont20FRMT_VNHAN, cont20FRMT_VNDAD As Integer
     
                Dim cont40FRMT_VNSGN, cont40FRMT_VNHPH, cont40FRMT_VNHAN, cont40FRMT_VNDAD As Integer
                Dim TOTAL20_VNSGN, TOTAL20_VNHPH, TOTAL20_VNHAN, TOTAL20_VNDAD As Integer
                Dim TOTAL40_VNSGN, TOTAL40_VNHPH, TOTAL40_VNHAN, TOTAL40_VNDAD As Integer
                Dim TOTALHC_VNSGN, TOTALHC_VNHPH, TOTALHC_VNHAN, TOTALHC_VNDAD As Integer
                Dim TOTAL45_VNSGN, TOTAL45_VNHPH, TOTAL45_VNHAN, TOTAL45_VNDAD As Integer


                Dim location_ As String = ""

                'If Me.chkall.Checked = True Then
                '    sql = "select distinct socont from containerstatus "

                'Else
                sql = "select distinct socont from containerstatus   "

                'End If
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        ' ung voi moi cont, lay ngay lon nhat
                        sqlc = " select * from containerstatus left join container on containerstatus.socont=container.container_no where convert(datetime,status_date) <= '" & Me.DateTimePicker1.Value.Date & "' and socont='" & ds.Tables(0).Rows(i).Item("socont").ToString & "' "
                        sqlc += " and convert(datetime,status_date) in (select max(convert(datetime,status_date)) from containerstatus where socont='" & ds.Tables(0).Rows(i).Item("socont").ToString & "'  )"
                        dsc = ReadDataSet(sqlc)
                        If dsc.Tables(0).Rows.Count > 0 Then
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "20GP" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulIm" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20FI_VNSGN += 1
                                        Case "VNHPH"
                                            cont20FI_VNHPH += 1
                                        Case "VNHAN"
                                            cont20FI_VNHAN += 1
                                        Case "VNDAD"
                                            cont20FI_VNDAD += 1


                                    End Select



                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrImp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20TI_VNSGN += 1
                                        Case "VNHPH"
                                            cont20TI_VNHPH += 1
                                        Case "VNHAN"
                                            cont20TI_VNHAN += 1
                                        Case "VNDAD"
                                            cont20TI_VNDAD += 1


                                    End Select

                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrExp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20TE_VNSGN += 1
                                        Case "VNHPH"
                                            cont20TE_VNHPH += 1
                                        Case "VNHAN"
                                            cont20TE_VNHAN += 1
                                        Case "VNDAD"
                                            cont20TE_VNDAD += 1


                                    End Select


                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulEx" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20FE_VNSGN += 1
                                        Case "VNHPH"
                                            cont20FE_VNHPH += 1
                                        Case "VNHAN"
                                            cont20FE_VNHAN += 1
                                        Case "VNDAD"
                                            cont20FE_VNDAD += 1


                                    End Select
                                    '  cont20FE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20GPMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont20GPMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont20GPMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont20GPMT_VNDAD += 1


                                    End Select
                                    'cont20GPMT += 1
                                End If



                                'Dim cont20FI As Integer = 0
                                'Dim cont40FI As Integer = 0
                                'Dim cont40HCFI As Integer = 0
                                'Dim cont45HCFI As Integer = 0
                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "40GP" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulIm" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40FI_VNSGN += 1
                                        Case "VNHPH"
                                            cont40FI_VNHPH += 1
                                        Case "VNHAN"
                                            cont40FI_VNHAN += 1
                                        Case "VNDAD"
                                            cont40FI_VNDAD += 1


                                    End Select
                                    'cont40FI += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrImp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40TI_VNSGN += 1
                                        Case "VNHPH"
                                            cont40TI_VNHPH += 1
                                        Case "VNHAN"
                                            cont40TI_VNHAN += 1
                                        Case "VNDAD"
                                            cont40TI_VNDAD += 1


                                    End Select

                                    'cont40TI += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrExp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40TE_VNSGN += 1
                                        Case "VNHPH"
                                            cont40TE_VNHPH += 1
                                        Case "VNHAN"
                                            cont40TE_VNHAN += 1
                                        Case "VNDAD"
                                            cont40TE_VNDAD += 1


                                    End Select

                                    ' cont40TE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulEx" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40FE_VNSGN += 1
                                        Case "VNHPH"
                                            cont40FE_VNHPH += 1
                                        Case "VNHAN"
                                            cont40FE_VNHAN += 1
                                        Case "VNDAD"
                                            cont40FE_VNDAD += 1


                                    End Select


                                    ' cont40FE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40GPMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont40GPMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont40GPMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont40GPMT_VNDAD += 1


                                    End Select
                                    ' cont40GPMT += 1
                                End If



                                'Dim cont20FI As Integer = 0
                                'Dim cont40FI As Integer = 0
                                'Dim cont40HCFI As Integer = 0
                                'Dim cont45HCFI As Integer = 0
                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "40HC" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulIm" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40HCFI_VNSGN += 1
                                        Case "VNHPH"
                                            cont40HCFI_VNHPH += 1
                                        Case "VNHAN"
                                            cont40HCFI_VNHAN += 1
                                        Case "VNDAD"
                                            cont40HCFI_VNDAD += 1


                                    End Select
                                    'cont40HCFI += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrImp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40HCTI_VNSGN += 1
                                        Case "VNHPH"
                                            cont40HCTI_VNHPH += 1
                                        Case "VNHAN"
                                            cont40HCTI_VNHAN += 1
                                        Case "VNDAD"
                                            cont40HCTI_VNDAD += 1


                                    End Select
                                    ' cont40HCTI += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrExp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40HCTE_VNSGN += 1
                                        Case "VNHPH"
                                            cont40HCTE_VNHPH += 1
                                        Case "VNHAN"
                                            cont40HCTE_VNHAN += 1
                                        Case "VNDAD"
                                            cont40HCTE_VNDAD += 1


                                    End Select

                                    'cont40HCTE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulEx" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40HCFE_VNSGN += 1
                                        Case "VNHPH"
                                            cont40HCFE_VNHPH += 1
                                        Case "VNHAN"
                                            cont40HCFE_VNHAN += 1
                                        Case "VNDAD"
                                            cont40HCFE_VNDAD += 1


                                    End Select
                                    'cont40HCFE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40HCMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont40HCMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont40HCMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont40HCMT_VNDAD += 1


                                    End Select
                                    'cont40HCMT += 1
                                End If



                                'Dim cont20FI As Integer = 0
                                'Dim cont40FI As Integer = 0
                                'Dim cont40HCFI As Integer = 0
                                'Dim cont45HCFI As Integer = 0
                            End If



                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "45HC" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulIm" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont45HCFI_VNSGN += 1
                                        Case "VNHPH"
                                            cont45HCFI_VNHPH += 1
                                        Case "VNHAN"
                                            cont45HCFI_VNHAN += 1
                                        Case "VNDAD"
                                            cont45HCFI_VNDAD += 1


                                    End Select
                                    'cont45HCFI += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrImp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont45HCTI_VNSGN += 1
                                        Case "VNHPH"
                                            cont45HCTI_VNHPH += 1
                                        Case "VNHAN"
                                            cont45HCTI_VNHAN += 1
                                        Case "VNDAD"
                                            cont45HCTI_VNDAD += 1


                                    End Select
                                    ' cont45HCTI += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "TrExp" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont45HCTE_VNSGN += 1
                                        Case "VNHPH"
                                            cont45HCTE_VNHPH += 1
                                        Case "VNHAN"
                                            cont45HCTE_VNHAN += 1
                                        Case "VNDAD"
                                            cont45HCTE_VNDAD += 1


                                    End Select
                                    'cont45HCTE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "FulEx" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont45HCFE_VNSGN += 1
                                        Case "VNHPH"
                                            cont45HCFE_VNHPH += 1
                                        Case "VNHAN"
                                            cont45HCFE_VNHAN += 1
                                        Case "VNDAD"
                                            cont45HCFE_VNDAD += 1


                                    End Select
                                    ' cont45HCFE += 1
                                End If
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont45HCMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont45HCMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont45HCMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont45HCMT_VNDAD += 1


                                    End Select
                                    'cont45HCMT += 1
                                End If

                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "20RF" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20RFMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont20RFMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont20RFMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont20RFMT_VNDAD += 1


                                    End Select

                                    ' cont20RFMT += 1
                                End If


                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "40RF" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40RFMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont40RFMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont40RFMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont40RFMT_VNDAD += 1


                                    End Select
                                    'cont40RFMT += 1
                                End If
                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "20OT" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20OTMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont20OTMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont20OTMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont20OTMT_VNDAD += 1


                                    End Select
                                    ' cont20OTMT += 1
                                End If
                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "40OT" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40OTMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont40OTMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont40OTMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont40OTMT_VNDAD += 1


                                    End Select
                                    'cont40OTMT += 1
                                End If
                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "20FR" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont20FRMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont20FRMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont20FRMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont20FRMT_VNDAD += 1


                                    End Select
                                    ' cont20FRMT += 1
                                End If
                            End If
                            If dsc.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString = "40FR" Then
                                If dsc.Tables(0).Rows(0).Item("STATUS").ToString = "MT" Then
                                    Select Case dsc.Tables(0).Rows(0).Item("LOCATION").ToString
                                        Case "VNSGN"
                                            cont40FRMT_VNSGN += 1
                                        Case "VNHPH"
                                            cont40FRMT_VNHPH += 1
                                        Case "VNHAN"
                                            cont40FRMT_VNHAN += 1
                                        Case "VNDAD"
                                            cont40FRMT_VNDAD += 1


                                    End Select
                                    ' cont40FRMT += 1
                                End If
                            End If

                        End If
                    Next
                End If



                ' ghi vao luo
                Dim currow As Integer
                Me.DataGridView1.Rows.Add(4)
                currow = DataGridView1.RowCount - 2

                'cont20FI_VNSGN
                Me.DataGridView1.Item("location", 0).Value = "VNSGN"
                Me.DataGridView1.Rows(0).DefaultCellStyle.ForeColor = Color.Red
                Me.DataGridView1.Item("location", 1).Value = "VNHPH"
                Me.DataGridView1.Rows(1).DefaultCellStyle.ForeColor = Color.Blue
                Me.DataGridView1.Item("location", 2).Value = "VNHAN"
                Me.DataGridView1.Rows(2).DefaultCellStyle.ForeColor = Color.Yellow
                Me.DataGridView1.Item("location", 3).Value = "VNDAD"
                Me.DataGridView1.Rows(3).DefaultCellStyle.ForeColor = Color.Purple


                Me.DataGridView1.Item("fulim20", 0).Value = IIf(cont20FI_VNSGN = 0, "", cont20FI_VNSGN)
                Me.DataGridView1.Item("fulim20", 1).Value = IIf(cont20FI_VNHPH = 0, "", cont20FI_VNHPH)
                Me.DataGridView1.Item("fulim20", 2).Value = IIf(cont20FI_VNHAN = 0, "", cont20FI_VNHAN)
                Me.DataGridView1.Item("fulim20", 3).Value = IIf(cont20FI_VNDAD = 0, "", cont20FI_VNDAD)

                Me.DataGridView1.Item("fulim40", 0).Value = IIf(cont40FI_VNSGN = 0, "", cont40FI_VNSGN)
                Me.DataGridView1.Item("fulim40", 1).Value = IIf(cont40FI_VNHPH = 0, "", cont40FI_VNHPH)
                Me.DataGridView1.Item("fulim40", 2).Value = IIf(cont40FI_VNHAN = 0, "", cont40FI_VNHAN)
                Me.DataGridView1.Item("fulim40", 3).Value = IIf(cont40FI_VNDAD = 0, "", cont40FI_VNDAD)

                Me.DataGridView1.Item("fulimHC", 0).Value = IIf(cont40HCFI_VNSGN = 0, "", cont40HCFI_VNSGN)
                Me.DataGridView1.Item("fulimHC", 1).Value = IIf(cont40HCFI_VNHPH = 0, "", cont40HCFI_VNHPH)
                Me.DataGridView1.Item("fulimHC", 2).Value = IIf(cont40HCFI_VNHAN = 0, "", cont40HCFI_VNHAN)
                Me.DataGridView1.Item("fulimHC", 3).Value = IIf(cont40HCFI_VNDAD = 0, "", cont40HCFI_VNDAD)



                Me.DataGridView1.Item("fulim45", 0).Value = IIf(cont45HCFI_VNSGN = 0, "", cont45HCFI_VNSGN)
                Me.DataGridView1.Item("fulim45", 1).Value = IIf(cont45HCFI_VNHPH = 0, "", cont45HCFI_VNHPH)
                Me.DataGridView1.Item("fulim45", 2).Value = IIf(cont45HCFI_VNHAN = 0, "", cont45HCFI_VNHAN)
                Me.DataGridView1.Item("fulim45", 3).Value = IIf(cont45HCFI_VNDAD = 0, "", cont45HCFI_VNDAD)

                Me.DataGridView1.Item("trimp20", 0).Value = IIf(cont20TI_VNSGN = 0, "", cont20TI_VNSGN)
                Me.DataGridView1.Item("trimp20", 1).Value = IIf(cont20TI_VNHPH = 0, "", cont20TI_VNHPH)
                Me.DataGridView1.Item("trimp20", 2).Value = IIf(cont20TI_VNHAN = 0, "", cont20TI_VNHAN)
                Me.DataGridView1.Item("trimp20", 3).Value = IIf(cont20TI_VNDAD = 0, "", cont20TI_VNDAD)


                Me.DataGridView1.Item("trimp40", 0).Value = IIf(cont40TI_VNSGN = 0, "", cont40TI_VNSGN)
                Me.DataGridView1.Item("trimp40", 1).Value = IIf(cont40TI_VNHPH = 0, "", cont40TI_VNHPH)
                Me.DataGridView1.Item("trimp40", 2).Value = IIf(cont40TI_VNHAN = 0, "", cont40TI_VNHAN)
                Me.DataGridView1.Item("trimp40", 3).Value = IIf(cont40TI_VNDAD = 0, "", cont40TI_VNDAD)


                Me.DataGridView1.Item("trimpHC", 0).Value = IIf(cont40HCTI_VNSGN = 0, "", cont40HCTI_VNSGN)
                Me.DataGridView1.Item("trimpHC", 1).Value = IIf(cont40HCTI_VNHPH = 0, "", cont40HCTI_VNHPH)
                Me.DataGridView1.Item("trimpHC", 2).Value = IIf(cont40HCTI_VNHAN = 0, "", cont40HCTI_VNHAN)
                Me.DataGridView1.Item("trimpHC", 3).Value = IIf(cont40HCTI_VNDAD = 0, "", cont40HCTI_VNDAD)

                Me.DataGridView1.Item("trimp45", 0).Value = IIf(cont45HCTI_VNSGN = 0, "", cont45HCTI_VNSGN)
                Me.DataGridView1.Item("trimp45", 1).Value = IIf(cont45HCTI_VNHPH = 0, "", cont45HCTI_VNHPH)
                Me.DataGridView1.Item("trimp45", 2).Value = IIf(cont45HCTI_VNHAN = 0, "", cont45HCTI_VNHAN)
                Me.DataGridView1.Item("trimp45", 3).Value = IIf(cont45HCTI_VNDAD = 0, "", cont45HCTI_VNDAD)

                Me.DataGridView1.Item("trexp20", 0).Value = IIf(cont20TE_VNSGN = 0, "", cont20TE_VNSGN)
                Me.DataGridView1.Item("trexp20", 1).Value = IIf(cont20TE_VNHPH = 0, "", cont20TE_VNHPH)
                Me.DataGridView1.Item("trexp20", 2).Value = IIf(cont20TE_VNHAN = 0, "", cont20TE_VNHAN)
                Me.DataGridView1.Item("trexp20", 3).Value = IIf(cont20TE_VNDAD = 0, "", cont20TE_VNDAD)

                Me.DataGridView1.Item("trexp40", 0).Value = IIf(cont40TE_VNSGN = 0, "", cont40TE_VNSGN)
                Me.DataGridView1.Item("trexp40", 1).Value = IIf(cont40TE_VNHPH = 0, "", cont40TE_VNHPH)
                Me.DataGridView1.Item("trexp40", 2).Value = IIf(cont40TE_VNHAN = 0, "", cont40TE_VNHAN)
                Me.DataGridView1.Item("trexp40", 3).Value = IIf(cont40TE_VNDAD = 0, "", cont40TE_VNDAD)

                Me.DataGridView1.Item("trexpHC", 0).Value = IIf(cont40HCTE_VNSGN = 0, "", cont40HCTE_VNSGN)
                Me.DataGridView1.Item("trexpHC", 1).Value = IIf(cont40HCTE_VNHPH = 0, "", cont40HCTE_VNHPH)
                Me.DataGridView1.Item("trexpHC", 2).Value = IIf(cont40HCTE_VNHAN = 0, "", cont40HCTE_VNHAN)
                Me.DataGridView1.Item("trexpHC", 3).Value = IIf(cont40HCTE_VNDAD = 0, "", cont40HCTE_VNDAD)

                Me.DataGridView1.Item("trexp45", 0).Value = IIf(cont45HCTE_VNSGN = 0, "", cont45HCTE_VNSGN)
                Me.DataGridView1.Item("trexp45", 1).Value = IIf(cont45HCTE_VNHPH = 0, "", cont45HCTE_VNHPH)
                Me.DataGridView1.Item("trexp45", 2).Value = IIf(cont45HCTE_VNHAN = 0, "", cont45HCTE_VNHAN)
                Me.DataGridView1.Item("trexp45", 3).Value = IIf(cont45HCTE_VNDAD = 0, "", cont45HCTE_VNDAD)

                Me.DataGridView1.Item("fulex20", 0).Value = IIf(cont20FE_VNSGN = 0, "", cont20FE_VNSGN)
                Me.DataGridView1.Item("fulex20", 1).Value = IIf(cont20FE_VNHPH = 0, "", cont20FE_VNHPH)
                Me.DataGridView1.Item("fulex20", 2).Value = IIf(cont20FE_VNHAN = 0, "", cont20FE_VNHAN)
                Me.DataGridView1.Item("fulex20", 3).Value = IIf(cont20FE_VNDAD = 0, "", cont20FE_VNDAD)

                Me.DataGridView1.Item("fulex40", 0).Value = IIf(cont40FE_VNSGN = 0, "", cont40FE_VNSGN)
                Me.DataGridView1.Item("fulex40", 1).Value = IIf(cont40FE_VNHPH = 0, "", cont40FE_VNHPH)
                Me.DataGridView1.Item("fulex40", 2).Value = IIf(cont40FE_VNHAN = 0, "", cont40FE_VNHAN)
                Me.DataGridView1.Item("fulex40", 3).Value = IIf(cont40FE_VNDAD = 0, "", cont40FE_VNDAD)


                Me.DataGridView1.Item("fulexHC", 0).Value = IIf(cont40HCFE_VNSGN = 0, "", cont40HCFE_VNSGN)
                Me.DataGridView1.Item("fulexHC", 1).Value = IIf(cont40HCFE_VNHPH = 0, "", cont40HCFE_VNHPH)
                Me.DataGridView1.Item("fulexHC", 2).Value = IIf(cont40HCFE_VNHAN = 0, "", cont40HCFE_VNHAN)
                Me.DataGridView1.Item("fulexHC", 3).Value = IIf(cont40HCFE_VNDAD = 0, "", cont40HCFE_VNDAD)

                Me.DataGridView1.Item("fulex45", 0).Value = IIf(cont45HCFE_VNSGN = 0, "", cont45HCFE_VNSGN)
                Me.DataGridView1.Item("fulex45", 1).Value = IIf(cont45HCFE_VNHPH = 0, "", cont45HCFE_VNHPH)
                Me.DataGridView1.Item("fulex45", 2).Value = IIf(cont45HCFE_VNHAN = 0, "", cont45HCFE_VNHAN)
                Me.DataGridView1.Item("fulex45", 3).Value = IIf(cont45HCFE_VNDAD = 0, "", cont45HCFE_VNDAD)


                Me.DataGridView1.Item("mtgp20", 0).Value = IIf(cont20GPMT_VNSGN = 0, "", cont20GPMT_VNSGN)
                Me.DataGridView1.Item("mtgp20", 1).Value = IIf(cont20GPMT_VNHPH = 0, "", cont20GPMT_VNHPH)
                Me.DataGridView1.Item("mtgp20", 2).Value = IIf(cont20GPMT_VNHAN = 0, "", cont20GPMT_VNHAN)
                Me.DataGridView1.Item("mtgp20", 3).Value = IIf(cont20GPMT_VNDAD = 0, "", cont20GPMT_VNDAD)
               

                Me.DataGridView1.Item("mtgp40", 0).Value = IIf(cont40GPMT_VNSGN = 0, "", cont40GPMT_VNSGN)
                Me.DataGridView1.Item("mtgp40", 1).Value = IIf(cont40GPMT_VNHPH = 0, "", cont40GPMT_VNHPH)
                Me.DataGridView1.Item("mtgp40", 2).Value = IIf(cont40GPMT_VNHAN = 0, "", cont40GPMT_VNHAN)
                Me.DataGridView1.Item("mtgp40", 3).Value = IIf(cont40GPMT_VNDAD = 0, "", cont40GPMT_VNDAD)

                Me.DataGridView1.Item("mtgphc", 0).Value = IIf(cont40HCMT_VNSGN = 0, "", cont40HCMT_VNSGN)
                Me.DataGridView1.Item("mtgphc", 1).Value = IIf(cont40HCMT_VNHPH = 0, "", cont40HCMT_VNHPH)
                Me.DataGridView1.Item("mtgphc", 2).Value = IIf(cont40HCMT_VNHAN = 0, "", cont40HCMT_VNHAN)
                Me.DataGridView1.Item("mtgphc", 3).Value = IIf(cont40HCMT_VNDAD = 0, "", cont40HCMT_VNDAD)

                Me.DataGridView1.Item("mtgp45hc", 0).Value = IIf(cont45HCMT_VNSGN = 0, "", cont45HCMT_VNSGN)
                Me.DataGridView1.Item("mtgp45hc", 1).Value = IIf(cont45HCMT_VNHPH = 0, "", cont45HCMT_VNHPH)
                Me.DataGridView1.Item("mtgp45hc", 2).Value = IIf(cont45HCMT_VNHAN = 0, "", cont45HCMT_VNHAN)
                Me.DataGridView1.Item("mtgp45hc", 3).Value = IIf(cont45HCMT_VNDAD = 0, "", cont45HCMT_VNDAD)

                Me.DataGridView1.Item("mtrf20", 0).Value = IIf(cont20RFMT_VNSGN = 0, "", cont20RFMT_VNSGN)
                Me.DataGridView1.Item("mtrf20", 1).Value = IIf(cont20RFMT_VNHPH = 0, "", cont20RFMT_VNHPH)
                Me.DataGridView1.Item("mtrf20", 2).Value = IIf(cont20RFMT_VNHAN = 0, "", cont20RFMT_VNHAN)
                Me.DataGridView1.Item("mtrf20", 3).Value = IIf(cont20RFMT_VNDAD = 0, "", cont20RFMT_VNDAD)
               
                Me.DataGridView1.Item("mtrf40", 0).Value = IIf(cont40RFMT_VNSGN = 0, "", cont40RFMT_VNSGN)
                Me.DataGridView1.Item("mtrf40", 1).Value = IIf(cont40RFMT_VNHPH = 0, "", cont40RFMT_VNHPH)
                Me.DataGridView1.Item("mtrf40", 2).Value = IIf(cont40RFMT_VNHAN = 0, "", cont40RFMT_VNHAN)
                Me.DataGridView1.Item("mtrf40", 3).Value = IIf(cont40RFMT_VNDAD = 0, "", cont40RFMT_VNDAD)


                Me.DataGridView1.Item("mtot20", 0).Value = IIf(cont20OTMT_VNSGN = 0, "", cont20OTMT_VNSGN)
                Me.DataGridView1.Item("mtot20", 1).Value = IIf(cont20OTMT_VNHPH = 0, "", cont20OTMT_VNHPH)
                Me.DataGridView1.Item("mtot20", 2).Value = IIf(cont20OTMT_VNHAN = 0, "", cont20OTMT_VNHAN)
                Me.DataGridView1.Item("mtot20", 3).Value = IIf(cont20OTMT_VNDAD = 0, "", cont20OTMT_VNDAD)

                Me.DataGridView1.Item("mtot40", 0).Value = IIf(cont40OTMT_VNSGN = 0, "", cont40OTMT_VNSGN)
                Me.DataGridView1.Item("mtot40", 1).Value = IIf(cont40OTMT_VNHPH = 0, "", cont40OTMT_VNHPH)
                Me.DataGridView1.Item("mtot40", 2).Value = IIf(cont40OTMT_VNHAN = 0, "", cont40OTMT_VNHAN)
                Me.DataGridView1.Item("mtot40", 3).Value = IIf(cont40OTMT_VNDAD = 0, "", cont40OTMT_VNDAD)

                Me.DataGridView1.Item("mtfr20", 0).Value = IIf(cont20FRMT_VNSGN = 0, "", cont20FRMT_VNSGN)
                Me.DataGridView1.Item("mtfr20", 1).Value = IIf(cont20FRMT_VNHPH = 0, "", cont20FRMT_VNHPH)
                Me.DataGridView1.Item("mtfr20", 2).Value = IIf(cont20FRMT_VNHAN = 0, "", cont20FRMT_VNHAN)
                Me.DataGridView1.Item("mtfr20", 3).Value = IIf(cont20FRMT_VNDAD = 0, "", cont20FRMT_VNDAD)

                Me.DataGridView1.Item("mtfr40", 0).Value = IIf(cont40FRMT_VNSGN = 0, "", cont40FRMT_VNSGN)
                Me.DataGridView1.Item("mtfr40", 1).Value = IIf(cont40FRMT_VNHPH = 0, "", cont40FRMT_VNHPH)
                Me.DataGridView1.Item("mtfr40", 2).Value = IIf(cont40FRMT_VNHAN = 0, "", cont40FRMT_VNHAN)
                Me.DataGridView1.Item("mtfr40", 3).Value = IIf(cont40FRMT_VNDAD = 0, "", cont40FRMT_VNDAD)


                TOTAL20_VNSGN = cont20FI_VNSGN + cont20TI_VNSGN + cont20TE_VNSGN + cont20FE_VNSGN + cont20GPMT_VNSGN + cont20RFMT_VNSGN + cont20OTMT_VNSGN + cont20FRMT_VNSGN
                TOTAL40_VNSGN = cont40FI_VNSGN + cont40TI_VNSGN + cont40TE_VNSGN + cont40FE_VNSGN + cont40GPMT_VNSGN + cont40RFMT_VNSGN + cont40OTMT_VNSGN + cont40FRMT_VNSGN
                TOTALHC_VNSGN = cont40HCFI_VNSGN + cont40HCTI_VNSGN + cont40HCTE_VNSGN + cont40HCFE_VNSGN + cont40HCMT_VNSGN '+ cont40HCMT_VNSGN '+ cont40OTMT_VNSGN + cont40FRMT_VNSGN
                TOTAL45_VNSGN = cont45HCFI_VNSGN + cont45HCTI_VNSGN + cont45HCTE_VNSGN + cont45HCFE_VNSGN + cont45HCMT_VNSGN '+ cont45HCMT_VNSGN + cont45HCMT_VNSGN + cont45FRMT_VNSGN

                TOTAL20_VNHPH = cont20FI_VNHPH + cont20TI_VNHPH + cont20TE_VNHPH + cont20FE_VNHPH + cont20GPMT_VNHPH + cont20RFMT_VNHPH + cont20OTMT_VNHPH + cont20FRMT_VNHPH
                TOTAL40_VNHPH = cont40FI_VNHPH + cont40TI_VNHPH + cont40TE_VNHPH + cont40FE_VNHPH + cont40GPMT_VNHPH + cont40RFMT_VNHPH + cont40OTMT_VNHPH + cont40FRMT_VNHPH
                TOTALHC_VNHPH = cont40HCFI_VNHPH + cont40HCTI_VNHPH + cont40HCTE_VNHPH + cont40HCFE_VNHPH + cont40HCMT_VNHPH '+ cont40RFMT_VNHPH + cont40OTMT_VNHPH + cont40FRMT_VNHPH
                TOTAL45_VNHPH = cont45HCFI_VNHPH + cont45HCTI_VNHPH + cont45HCTE_VNHPH + cont45HCFE_VNHPH + cont45HCMT_VNHPH ' + cont45RFMT_VNHPH + cont45OTMT_VNHPH + cont45FRMT_VNHPH


                TOTAL20_VNHAN = cont20FI_VNHAN + cont20TI_VNHAN + cont20TE_VNHAN + cont20FE_VNHAN + cont20GPMT_VNHAN + cont20RFMT_VNHAN + cont20OTMT_VNHAN + cont20FRMT_VNHAN
                TOTAL40_VNHAN = cont40FI_VNHAN + cont40TI_VNHAN + cont40TE_VNHAN + cont40FE_VNHAN + cont40GPMT_VNHAN + cont40RFMT_VNHAN + cont40OTMT_VNHAN + cont40FRMT_VNHAN
                TOTALHC_VNHAN = cont40HCFI_VNHAN + cont40HCTI_VNHAN + cont40HCTE_VNHAN + cont40HCFE_VNHAN + cont40HCMT_VNHAN '+ cont40RFMT_VNHAN + cont40OTMT_VNHAN + cont40FRMT_VNHAN
                TOTAL45_VNHAN = cont45HCFI_VNHAN + cont45HCTI_VNHAN + cont45HCTE_VNHAN + cont45HCFE_VNHAN + cont45HCMT_VNHAN '+ cont45RFMT_VNHAN + cont45OTMT_VNHAN + cont45FRMT_VNHAN

                TOTAL20_VNDAD = cont20FI_VNDAD + cont20TI_VNDAD + cont20TE_VNDAD + cont20FE_VNDAD + cont20GPMT_VNDAD + cont20RFMT_VNDAD + cont20OTMT_VNDAD + cont20FRMT_VNDAD
                TOTAL40_VNDAD = cont40FI_VNDAD + cont40TI_VNDAD + cont40TE_VNDAD + cont40FE_VNDAD + cont40GPMT_VNDAD + cont40RFMT_VNDAD + cont40OTMT_VNDAD + cont40FRMT_VNDAD
                TOTALHC_VNDAD = cont40HCFI_VNDAD + cont40HCTI_VNDAD + cont40HCTE_VNDAD + cont40HCFE_VNDAD + cont40HCMT_VNDAD '+ cont40RFMT_VNDAD + cont40OTMT_VNDAD + cont40FRMT_VNDAD
                TOTAL45_VNDAD = cont45HCFI_VNDAD + cont45HCTI_VNDAD + cont45HCTE_VNDAD + cont45HCFE_VNDAD + cont45HCMT_VNDAD '+ cont45RFMT_VNDAD + cont45OTMT_VNDAD + cont45FRMT_VNDAD

                Me.DataGridView1.Item("TOTAL20", 0).Value = IIf(TOTAL20_VNSGN = 0, "", TOTAL20_VNSGN)
                Me.DataGridView1.Item("TOTAL40", 0).Value = IIf(TOTAL40_VNSGN = 0, "", TOTAL40_VNSGN)
                Me.DataGridView1.Item("TOTALHC", 0).Value = IIf(TOTALHC_VNSGN = 0, "", TOTALHC_VNSGN)
                Me.DataGridView1.Item("TOTAL45", 0).Value = IIf(TOTAL45_VNSGN = 0, "", TOTAL45_VNSGN)

                Me.DataGridView1.Item("TOTAL20", 1).Value = IIf(TOTAL20_VNHPH = 0, "", TOTAL20_VNHPH)
                Me.DataGridView1.Item("TOTAL40", 1).Value = IIf(TOTAL40_VNHPH = 0, "", TOTAL40_VNHPH)
                Me.DataGridView1.Item("TOTALHC", 1).Value = IIf(TOTALHC_VNHPH = 0, "", TOTALHC_VNHPH)
                Me.DataGridView1.Item("TOTAL45", 1).Value = IIf(TOTAL45_VNHPH = 0, "", TOTAL45_VNHPH)

                Me.DataGridView1.Item("TOTAL20", 2).Value = IIf(TOTAL20_VNHAN = 0, "", TOTAL20_VNHAN)
                Me.DataGridView1.Item("TOTAL40", 2).Value = IIf(TOTAL40_VNHAN = 0, "", TOTAL40_VNHAN)
                Me.DataGridView1.Item("TOTALHC", 2).Value = IIf(TOTALHC_VNHAN = 0, "", TOTALHC_VNHAN)
                Me.DataGridView1.Item("TOTAL45", 2).Value = IIf(TOTAL45_VNHAN = 0, "", TOTAL45_VNHAN)

                Me.DataGridView1.Item("TOTAL20", 3).Value = IIf(TOTAL20_VNDAD = 0, "", TOTAL20_VNDAD)
                Me.DataGridView1.Item("TOTAL40", 3).Value = IIf(TOTAL40_VNDAD = 0, "", TOTAL40_VNDAD)
                Me.DataGridView1.Item("TOTALHC", 3).Value = IIf(TOTALHC_VNDAD = 0, "", TOTALHC_VNDAD)
                Me.DataGridView1.Item("TOTAL45", 3).Value = IIf(TOTAL45_VNDAD = 0, "", TOTAL45_VNDAD)
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