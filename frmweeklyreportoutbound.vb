Public Class frmweeklyreportoutbound
    Sub QueryCombo()
        Try
            Dim id, value, strSQL As String
            ' lay cont vao cbopack
            'cbocontPack.Items.Clear()
            'id = "outboundContainersID"
            'value = "ContainerNo"
            'strSQL = "Select outboundcontainersid ,containerno From containertype where outboundid='" & gOutboundID & "'  "
            'loadDataToObject(Me.cbocontPack, strSQL, id, value)
            '-------------------------------------------
            '----------------------------------------------
            Me.cboSale.Items.Clear()
            id = "salecode"
            value = "salecode"
            strSQL = "Select  salecode from sale order by salecode "
            loadDataToObject(Me.cboSale, strSQL, id, value)
            '-----------------------------------------------
            '------------



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -55281
            Dim i As Integer
            Me.DataGridView1.Rows.Clear()
            If UCase(Me.cboChinhanh.Text) = "ALL" Then
                'If Me.chkoutbound.Checked = True Then
                '    sql = "select * from outbound where convert(datetime,sailingdate) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                'End If
                ' If Me.chkinbound.Checked = True Then',agencyname,shippingline,vessel,voyage,salecode,eta
                sql = "select distinct ref from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and salecode='" & Me.cboSale.Text & "' "
                'End If
                'If Me.chkLogistics.Checked = True Then
                '    sql = "select * from logistics where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                'End If
            End If
            If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                'If Me.chkoutbound.Checked = True Then
                '    sql = "select * from outbound where convert(datetime,sailingdate) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '%" & Me.cboChinhanh.Text & "%'"
                'End If
                'If Me.chkinbound.Checked = True Then',agencyname,shippingline,vessel,voyage,salecode,eta
                sql = "select distinct ref from outbound where  convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '%" & Me.cboChinhanh.Text & "%' and salecode='" & Me.cboSale.Text & "' "
                'End If
                'If Me.chkLogistics.Checked = True Then
                '    sql = "select * from logistics where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                'End If
            End If
            Dim tongcont20 As Integer = 0
            Dim tongcont40 As Integer = 0
            Dim tongcbm As Double = 0
            ds = ReadDataSet(sql)
            Dim STT1 As Integer = 0
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung moi dong tga lay so lieu
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' moi ref ta lay toan bo thong tin (bao gom nhieu house)
                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2
                    ' thong tin refe 
                    Dim sqlshowRef As String
                    Dim dsshowref As New DataSet
                    sqlshowRef = "select * from outbound where ref ='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'"
                    dsshowref = ReadDataSet(sqlshowRef)
                    If dsshowref.Tables(0).Rows.Count > 0 Then
                        Me.DataGridView1.Item("Column1", currow).Value = STT1 + 1 'ds.Tables(0).Rows(i).Item("ref").ToString
                        Me.DataGridView1.Item("Column2", currow).Value = dsshowref.Tables(0).Rows(0).Item("ref").ToString 'ds.Tables(0).Rows(i).Item("ref").ToString 'ds.Tables(0).Rows(i).Item("bl_type").ToString
                        Me.DataGridView1.Item("Column3", currow).Value = dsshowref.Tables(0).Rows(0).Item("agencyname").ToString
                        Me.DataGridView1.Item("Column9", currow).Value = dsshowref.Tables(0).Rows(0).Item("shippingline").ToString

                        Me.DataGridView1.Item("Column10", currow).Value = dsshowref.Tables(0).Rows(0).Item("vessel").ToString
                        Me.DataGridView1.Item("Column11", currow).Value = dsshowref.Tables(0).Rows(0).Item("voyage").ToString

                        Me.DataGridView1.Item("Column12", currow).Value = dsshowref.Tables(0).Rows(0).Item("sailingdate").ToString

                        Me.DataGridView1.Item("Column13", currow).Value = dsshowref.Tables(0).Rows(0).Item("salecode").ToString

                    End If
                    '------------------------
                    'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 255)
                    'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White

                    '-------------------------so van don
                    Dim sqlbill As String
                    Dim dsbill As New DataSet
                    sqlbill = "select  * from outbound where ref ='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'  "
                    dsbill = ReadDataSet(sqlbill)
                    If dsbill.Tables(0).Rows.Count > 0 Then
                        Me.DataGridView1.Item("Column4", currow).Value = dsbill.Tables(0).Rows.Count.ToString
                    End If
                    '--------------------------------
                    'ta co so mblmawb, ta lay thong so container
                    Dim j, k As Integer
                    Dim sqlCont As String = ""
                    Dim dsCont As New DataSet
                    '---
                    Dim kg As Double = 0
                    Dim kien As Double = 0
                    Dim khoi As Double = 0
                    Dim cont As String = ""
                    Dim type As String = ""
                    Dim cont20 As Integer = 0
                    Dim cont40 As Integer = 0
                    '-------------------------------------
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from outbound where ref ='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dsref.Tables(0).Rows.Count - 1

                            ' hien thi noi dung bill Ib
                            'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                            sqlCont = "select * from containertype where outboundid='" & dsref.Tables(0).Rows(j).Item("blob_id").ToString & "'"
                            dsCont = ReadDataSet(sqlCont)
                            If dsCont.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dsCont.Tables(0).Rows(k).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dsCont.Tables(0).Rows(k).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dsCont.Tables(0).Rows(k).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        Dim T As String
                                        T = "*" & dsCont.Tables(0).Rows(k).Item("containerno").ToString & "*"
                                        If cont Like T Then
                                        Else

                                            cont += dsCont.Tables(0).Rows(k).Item("containerno").ToString & "/" ' & dsCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(j).Item("containertype").ToString & "; "

                                        End If
                                    Catch ex As Exception

                                    End Try
                                    type = dsCont.Tables(0).Rows(k).Item("type").ToString
                                    ' kiem tra cont 20
                                    If dsCont.Tables(0).Rows(k).Item("containertype").ToString Like "*20*" Then
                                        cont20 += 1
                                    End If
                                    If dsCont.Tables(0).Rows(k).Item("containertype").ToString Like "*40*" Then
                                        cont40 += 1
                                    End If
                                Next
                            End If

                        Next
                    End If
                    '-----------------------------

                    Me.DataGridView1.Item("Column5", currow).Value = cont20.ToString
                    Me.DataGridView1.Item("Column6", currow).Value = cont40.ToString
                    Me.DataGridView1.Item("Column7", currow).Value = khoi.ToString
                    ' them vao excel

                    Me.DataGridView1.Item("Column8", currow).Value = cont.ToString

                    tongcont20 += cont20
                    tongcont40 += cont40
                    tongcbm += khoi
                    STT1 += 1
                Next
            End If
            ' total thu
            Me.DataGridView1.Rows.Add(1)
            currow = Me.DataGridView1.RowCount - 2
            Me.DataGridView1.Item("Column4", currow).Value = "Total"

            Me.DataGridView1.Item("Column5", currow).Value = tongcont20.ToString
            Me.DataGridView1.Item("Column6", currow).Value = tongcont40.ToString
            Me.DataGridView1.Item("Column7", currow).Value = FormatNumber(tongcbm.ToString, 3)
            Try
                Me.DataGridView1.Item("Column8", currow).Value = FormatNumber(tongcont20 + tongcont40, 0).ToString & " Containers =" & FormatNumber(tongcont20 + (tongcont40 * 2), 0) + "Teu"

            Catch ex As Exception

            End Try
            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red





            '--------------------
            InsertAutoNumberToGrid(Me.DataGridView1)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Try
                If Me.DataGridView1.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                ExportExecel(Me.DataGridView1, Me)
                'SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmweeklyreportoutbound_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        QueryCombo()
        Try
            Me.cboChinhanh.Items.Clear()
            Me.cboChinhanh.Text = ""
            If gBranch = "" Then

                Me.cboChinhanh.Items.Add("ALL")
                Me.cboChinhanh.Items.Add("HCM")
                Me.cboChinhanh.Items.Add("HPH")

            ElseIf gBranch = "SGN" Then

                Me.cboChinhanh.Items.Add("HCM")

            ElseIf gBranch = "HPH" Then

                Me.cboChinhanh.Items.Add("HPH")

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class