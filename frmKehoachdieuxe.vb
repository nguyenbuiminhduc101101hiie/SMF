Public Class frmKehoachdieuxe

    Dim mStatus As String
    Dim mKeHoachID As String
    Sub QueryCombo()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        Me.cbobooking.Items.Clear()
        Me.cbobookingCHon.Items.Clear()
        id = "bookingagentid"
        value = "gmd_bookingno"
        strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select bookingagentid, gmd_bookingno + ' - ' + company +' - ' + gmd_placeofstuffing + ' - ' + gmd_portofloading + ' - ' + gmd_portofdischarge + ' - ' + gmd_noofcontainerorpackage + ' - ' + gmd_etd as gmd_bookingno from  bookingagent left join customer on bookingagent.customerid=customer.customer_id  "
        strSQL = strSQL & " order by gmd_bookingno " '
        '   loadDataToObject(Me.cbobooking, strSQL, id, value)
        loadDataToObject(Me.cbobookingCHon, strSQL, id, value)
        '----------
        Me.cboBienso.Items.Clear()
        Me.cbobienso_tim.Items.Clear()
        id = "dmdaukeoid"
        value = "maxe"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select dmdaukeoid, maxe  from  dmdaukeo  "
        strSQL = strSQL & " order by maxe " '
        loadDataToObject(Me.cboBienso, strSQL, id, value)
        loadDataToObject(Me.cbobienso_tim, strSQL, id, value)

        '----------
        Me.cboRomooc.Items.Clear()
        id = "dmmoocid"
        value = "mamooc"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select dmmoocid, mamooc  from  dmmooc  "
        strSQL = strSQL & " order by mamooc" '
        loadDataToObject(Me.cboRomooc, strSQL, id, value)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim id, value, strSQL As String
            Me.cbobooking.Items.Clear()

            id = "bookingagentid"
            value = "gmd_bookingno"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select bookingagentid, gmd_bookingno + ' - ' + company +' - ' + gmd_placeofstuffing + ' - ' + gmd_portofloading + ' - ' + gmd_portofdischarge + ' - ' + gmd_noofcontainerorpackage + ' - ' + gmd_etd as gmd_bookingno from  bookingagent left join customer on bookingagent.customerid=customer.customer_id  where convert(datetime,gmd_etd) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "' and  bookingagentid not in (select bookingid from kehoachdieuxe)"
            strSQL = strSQL & " order by gmd_bookingno " '
            loadDataToObject(Me.cbobooking, strSQL, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' MO TA SU KIEN NEU DA DIEU XE CHO BOOKING CU THE, THI KO CHO DIEU TIEP
            Dim sql As String
            Dim ds As New DataSet
            If Me.cbobooking.Text = "" Then
                DisplayMessage(True, "No Booking .!, Please check again.")
                Exit Sub

            End If
            sql = "select * from kehoachdieuxe left join dmdaukeo on kehoachdieuxe.dmdaukeoid=dmdaukeo.dmdaukeoid where bookingid='" & FindValueID(Me.cbobooking, Me.cbobooking.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                DisplayMessage(True, "Booking này đã được lên kế họach với xe : " + ds.Tables(0).Rows(0).Item("maxe").ToString + ", vào ngày " + ds.Tables(0).Rows(0).Item("ngay").ToString)
            End If
            '---------------------------------------------------------------------------
            Me.cbobookingCHon.Text = Me.cbobooking.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmKehoachdieuxe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mStatus = "Normal"
            mKeHoachID = DefaultValue
            Button1_Click(sender, e)
            QueryCombo()
            Me.Button7_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Try


                Dim strQuery, strSale, strCustomer_Id, pName As String
                Dim rs As New ADODB.Recordset
                Dim rsSale As New ADODB.Recordset
                Dim index As Integer

                '---------------  
                Dim seri As Integer
                Dim temp As String


                '------------------
                If (mStatus = "Add" Or mStatus = "Edit") Then

                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM kehoachdieuxe "
                    strQuery = strQuery & "WHERE id = '" & mKeHoachID & "' AND id <> '" & DefaultValue & "' "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("id").Value = NewId()

                        End If
                        .Fields("bookingid").Value = "{" & FindValueID(Me.cbobookingCHon, Me.cbobookingCHon.Text) & "}"

                        .Fields("dmdaukeoid").Value = "{" & FindValueID(Me.cboBienso, Me.cboBienso.Text) & "}"
                        .Fields("dmmoocid").Value = "{" & FindValueID(Me.cboRomooc, Me.cboRomooc.Text) & "}"





                        .Fields("ngay").Value = ddMMMyyyy(Me.dtpNgay.Value.Date)

                        .Fields("gio").Value = Me.cbogio.Text
                        .Fields("ghichu").Value = Me.txtghichu.Text

                        '--------------








                        .Update()

                    End With
                    rs.Close()





                    mStatus = "Normal"
                    reText(mStatus)
                    Me.DataGridView1.Enabled = True
                    Me.Button6_Click(sender, e)
                End If
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            QueryCombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim sql As String
            Dim i, currow As Integer
            Dim ds As New DataSet
            Me.DataGridView1.Rows.Clear()
            sql = "select *,kehoachdieuxe.ghichu as ghichu_ from kehoachdieuxe left join dmdaukeo on kehoachdieuxe.dmdaukeoid=dmdaukeo.dmdaukeoid left join dmmooc on kehoachdieuxe.dmmoocid=dmmooc.dmmoocid left join bookingagent on kehoachdieuxe.bookingid=bookingagent.bookingagentid left join customer on bookingagent.customerid=customer.customer_id  left join logistics on bookingagent.gmd_bookingno=logistics.BKNo where convert(datetime,ngay)  between  '" & ddMMMyyyy(Me.dtpNgaykehoach.Value) & "'  and '" & ddMMMyyyy(Me.dtpNgaykehoach1.Value) & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1


                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.LightYellow
                    Me.DataGridView1.Item("id", currow).Value = ds.Tables(0).Rows(i).Item("id").ToString
                    Me.DataGridView1.Item("status", currow).Value = ds.Tables(0).Rows(i).Item("status").ToString

                    Me.DataGridView1.Item("gmd_bookingno", currow).Value = ds.Tables(0).Rows(i).Item("gmd_bookingno").ToString

                    Me.DataGridView1.Item("company", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString
                    Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofloading").ToString

                    Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofdischarge").ToString

                    Me.DataGridView1.Item("gmd_salecode", currow).Value = ds.Tables(0).Rows(i).Item("gmd_salecode").ToString



                    Me.DataGridView1.Item("maxe", currow).Value = ds.Tables(0).Rows(i).Item("maxe").ToString
                    Me.DataGridView1.Item("mamooc", currow).Value = ds.Tables(0).Rows(i).Item("mamooc").ToString
                    Me.DataGridView1.Item("ngay", currow).Value = ds.Tables(0).Rows(i).Item("ngay").ToString
                    Me.DataGridView1.Item("gio", currow).Value = ds.Tables(0).Rows(i).Item("gio").ToString
                    Me.DataGridView1.Item("ghichu", currow).Value = ds.Tables(0).Rows(i).Item("ghichu_").ToString
                    Try
                        ' them so cont tu logistics vao luoi
                        Dim sqlcont As String
                        Dim dscont As New DataSet
                        Dim j As Integer
                        Dim cont As String = ""
                        If ds.Tables(0).Rows(0).Item("BLOB_ID").ToString = "" Then
                        Else
                            sqlcont = "select * from containerlogistics where outboundID='" & ds.Tables(0).Rows(0).Item("BLOB_ID").ToString & "' "
                            dscont = ReadDataSet(sqlcont)
                            If dscont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dscont.Tables(0).Rows.Count - 1
                                    cont += dscont.Tables(0).Rows(j).Item("containerno").ToString + "/"
                                Next
                            End If
                        End If

                        Me.DataGridView1.Item("socontainer", currow).Value = cont
                    Catch ex As Exception

                    End Try
                    Me.DataGridView1.Item("userid", currow).Value = ds.Tables(0).Rows(i).Item("userid").ToString

                    Me.DataGridView1.Item("updatetime", currow).Value = ds.Tables(0).Rows(i).Item("updatetime").ToString

                    Me.DataGridView1.Item("approve", currow).Value = ds.Tables(0).Rows(i).Item("approve").ToString

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Kế hoạch điều xe"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Kế hoạch điều xe  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Kế hoạch điều xe -> Add."
        End If

    End Sub
    Private Sub ThêmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmToolStripMenuItem.Click
        Try
            If mStatus = "Normal" And UserRight("frmKehoachdieuxe", "Add") Then
                ' Me.txtCustomer.Enabled = True


                'Me.DataGridView1.Enabled = False



                mKeHoachID = DefaultValue

                mStatus = "Add"
                reText(mStatus)


                Me.cbobookingCHon.Enabled = True
                Me.cboBienso.Enabled = True
                Me.cboRomooc.Enabled = True
                Me.dtpNgay.Enabled = True
                Me.cbogio.Enabled = True

                Me.Button3.Enabled = True
                '------------



            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            mStatus = "Normal"
            Me.DataGridView1.Enabled = True
            Me.cbobookingCHon.Enabled = False
            Me.cboBienso.Enabled = False
            Me.cboRomooc.Enabled = False
            Me.dtpNgay.Enabled = False
            Me.cbogio.Enabled = False
            Me.Button3.Enabled = False

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString

            ' hien thi lcl
            Dim bookingno As String
            If index < 0 Then
                Return
            End If

            ' bookingno = Me.dgdContianerOutboundNotify.Item("bookingno", index).Value.ToString
            Dim sql As String
            Dim ds As New DataSet

            sql = "select *,kehoachdieuxe.ghichu as ghichu_ from kehoachdieuxe left join dmdaukeo on kehoachdieuxe.dmdaukeoid=dmdaukeo.dmdaukeoid left join dmmooc on kehoachdieuxe.dmmoocid=dmmooc.dmmoocid left join bookingagent on kehoachdieuxe.bookingid=bookingagent.bookingagentid left join customer on bookingagent.customerid=customer.customer_id  where id='" & mKeHoachID & "' and kehoachdieuxe.continued=1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    '----------------------------------------------
                    '.Fields("bookingOffice").Value = Me.cboBookingOffice.Text
                    '.Fields("contactPerson").Value = Me.txtcontactperson.Text
                    '.Fields("Remarks_").Value = Me.TXTREMARKS.Text
                    '.Fields("TranshipmentPort").Value = Me.TXTTRANSHIPMENTPORT.Text
                    '.Fields("CutOffTime").Value = Me.TXTCUTOFFTIME.Text
                    '.Fields("Type_").Value = Me.TXTTYPE.Text
                    '.Fields("ForStuffing").Value = Me.txtforstuffing.Text
                    Try
                        Me.cbobookingCHon.Text = FindIDValue(Me.cbobookingCHon, ds.Tables(0).Rows(0).Item("bookingid").ToString)
                    Catch ex As Exception

                    End Try

                    Try
                        Me.cboBienso.Text = FindIDValue(Me.cboBienso, ds.Tables(0).Rows(0).Item("dmdaukeoid").ToString)
                    Catch ex As Exception

                    End Try


                    Try
                        Me.cboRomooc.Text = FindIDValue(Me.cboRomooc, ds.Tables(0).Rows(0).Item("dmmoocid").ToString)
                    Catch ex As Exception

                    End Try

                    Try
                        Me.dtpNgay.Text = ds.Tables(0).Rows(0).Item("ngay").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.cbogio.Text = ds.Tables(0).Rows(0).Item("gio").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.txtghichu.Text = ds.Tables(0).Rows(0).Item("ghichu_").ToString
                    Catch ex As Exception

                    End Try


                Catch ex As Exception

                End Try
            End If
            '----------------------

            ' hien thi booking edi------------------------------------




        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub
    Private Sub SửaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SửaToolStripMenuItem.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.DataGridView1.Rows.Count > 0 Then
                index = Me.DataGridView1.CurrentRow.Index
            Else
                Exit Sub
            End If
            If index >= 0 Then
                Approve = Me.DataGridView1.Item("Approve", index).Value
                '  EditTable = Me.DataGridView1.Item("Editable", index).Value
                If mStatus = "Normal" And Not Approve And UserRight("frmKehoachdieuxe", "Edit") Then
                    ' Me.txtCustomer.Enabled = True


                    Me.DataGridView1.Enabled = False



                    mKeHoachID = Me.DataGridView1.Item("id", index).Value

                    mStatus = "Edit"
                    reText(mStatus)


                    Me.cbobookingCHon.Enabled = True
                    Me.cboBienso.Enabled = True
                    Me.cboRomooc.Enabled = True
                    Me.dtpNgay.Enabled = True
                    Me.cbogio.Enabled = True

                    Me.Button3.Enabled = True
                    '------------
                    RefreshData(index)


                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If



        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi





        'che tam vi chua co quan he voi Dulieu khac

        If Not IsNothing(Me.DataGridView1.Item("Approve", index)) Then
            If Me.DataGridView1.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If

        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmKehoachdieuxe", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the : " & Me.DataGridView1.Item("gmd_bookingno", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from kehoachdieuxe where id= '" & Me.DataGridView1.Item("id", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub XóaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XóaToolStripMenuItem.Click
        Try
            If Me.DataGridView1.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.DataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.DataGridView1.SelectedRows(i).Index)
                Next i
            End If
            Me.Button6_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Leave(sender As Object, e As EventArgs) Handles Button2.Leave

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Try
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Try
                Dim sql As String
                Dim i, currow As Integer
                Dim ds As New DataSet
                Me.DataGridView1.Rows.Clear()
                sql = "select *,kehoachdieuxe.ghichu as ghichu_ from kehoachdieuxe left join dmdaukeo on kehoachdieuxe.dmdaukeoid=dmdaukeo.dmdaukeoid left join dmmooc on kehoachdieuxe.dmmoocid=dmmooc.dmmoocid left join bookingagent on kehoachdieuxe.bookingid=bookingagent.bookingagentid left join customer on bookingagent.customerid=customer.customer_id  left join logistics on bookingagent.gmd_bookingno=logistics.BKNo order by convert(datetime,ngay) desc "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1


                        Me.DataGridView1.Rows.Add(1)
                        currow = DataGridView1.RowCount - 2
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.LightYellow
                        Me.DataGridView1.Item("id", currow).Value = ds.Tables(0).Rows(i).Item("id").ToString
                        Me.DataGridView1.Item("status", currow).Value = ds.Tables(0).Rows(i).Item("status").ToString

                        Me.DataGridView1.Item("gmd_bookingno", currow).Value = ds.Tables(0).Rows(i).Item("gmd_bookingno").ToString

                        Me.DataGridView1.Item("company", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString
                        Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofloading").ToString

                        Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofdischarge").ToString

                        Me.DataGridView1.Item("gmd_salecode", currow).Value = ds.Tables(0).Rows(i).Item("gmd_salecode").ToString



                        Me.DataGridView1.Item("maxe", currow).Value = ds.Tables(0).Rows(i).Item("maxe").ToString
                        Me.DataGridView1.Item("mamooc", currow).Value = ds.Tables(0).Rows(i).Item("mamooc").ToString
                        Me.DataGridView1.Item("ngay", currow).Value = ds.Tables(0).Rows(i).Item("ngay").ToString
                        Me.DataGridView1.Item("gio", currow).Value = ds.Tables(0).Rows(i).Item("gio").ToString
                        Me.DataGridView1.Item("ghichu", currow).Value = ds.Tables(0).Rows(i).Item("ghichu_").ToString
                        Try
                            ' them so cont tu logistics vao luoi
                            Dim sqlcont As String
                            Dim dscont As New DataSet
                            Dim j As Integer
                            Dim cont As String = ""
                            If ds.Tables(0).Rows(0).Item("BLOB_ID").ToString = "" Then
                            Else
                                sqlcont = "select * from containerlogistics where outboundID='" & ds.Tables(0).Rows(0).Item("BLOB_ID").ToString & "' "
                                dscont = ReadDataSet(sqlcont)
                                If dscont.Tables(0).Rows.Count > 0 Then
                                    For j = 0 To dscont.Tables(0).Rows.Count - 1
                                        cont += dscont.Tables(0).Rows(j).Item("containerno").ToString + "/"
                                    Next
                                End If
                            End If

                            Me.DataGridView1.Item("socontainer", currow).Value = cont
                        Catch ex As Exception

                        End Try
                        Me.DataGridView1.Item("userid", currow).Value = ds.Tables(0).Rows(i).Item("userid").ToString

                        Me.DataGridView1.Item("updatetime", currow).Value = ds.Tables(0).Rows(i).Item("updatetime").ToString

                        Me.DataGridView1.Item("approve", currow).Value = ds.Tables(0).Rows(i).Item("approve").ToString

                    Next
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Try
                Try
                    Dim sql As String
                    Dim i, currow As Integer
                    Dim ds As New DataSet
                    Me.DataGridView1.Rows.Clear()
                    sql = "select *,kehoachdieuxe.ghichu as ghichu_ from kehoachdieuxe left join dmdaukeo on kehoachdieuxe.dmdaukeoid=dmdaukeo.dmdaukeoid left join dmmooc on kehoachdieuxe.dmmoocid=dmmooc.dmmoocid left join bookingagent on kehoachdieuxe.bookingid=bookingagent.bookingagentid left join customer on bookingagent.customerid=customer.customer_id  left join logistics on bookingagent.gmd_bookingno=logistics.BKNo where dmdaukeo.maxe='" & Me.cbobienso_tim.Text & "' order by convert(datetime,ngay) desc "
                    ds = ReadDataSet(sql)
                    If ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1


                            Me.DataGridView1.Rows.Add(1)
                            currow = DataGridView1.RowCount - 2
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.LightYellow
                            Me.DataGridView1.Item("id", currow).Value = ds.Tables(0).Rows(i).Item("id").ToString
                            Me.DataGridView1.Item("status", currow).Value = ds.Tables(0).Rows(i).Item("status").ToString

                            Me.DataGridView1.Item("gmd_bookingno", currow).Value = ds.Tables(0).Rows(i).Item("gmd_bookingno").ToString

                            Me.DataGridView1.Item("company", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString
                            Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofloading").ToString

                            Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofdischarge").ToString

                            Me.DataGridView1.Item("gmd_salecode", currow).Value = ds.Tables(0).Rows(i).Item("gmd_salecode").ToString



                            Me.DataGridView1.Item("maxe", currow).Value = ds.Tables(0).Rows(i).Item("maxe").ToString
                            Me.DataGridView1.Item("mamooc", currow).Value = ds.Tables(0).Rows(i).Item("mamooc").ToString
                            Me.DataGridView1.Item("ngay", currow).Value = ds.Tables(0).Rows(i).Item("ngay").ToString
                            Me.DataGridView1.Item("gio", currow).Value = ds.Tables(0).Rows(i).Item("gio").ToString
                            Me.DataGridView1.Item("ghichu", currow).Value = ds.Tables(0).Rows(i).Item("ghichu_").ToString
                            Try
                                ' them so cont tu logistics vao luoi
                                Dim sqlcont As String
                                Dim dscont As New DataSet
                                Dim j As Integer
                                Dim cont As String = ""
                                If ds.Tables(0).Rows(0).Item("BLOB_ID").ToString = "" Then
                                Else
                                    sqlcont = "select * from containerlogistics where outboundID='" & ds.Tables(0).Rows(0).Item("BLOB_ID").ToString & "' "
                                    dscont = ReadDataSet(sqlcont)
                                    If dscont.Tables(0).Rows.Count > 0 Then
                                        For j = 0 To dscont.Tables(0).Rows.Count - 1
                                            cont += dscont.Tables(0).Rows(j).Item("containerno").ToString + "/"
                                        Next
                                    End If
                                End If

                                Me.DataGridView1.Item("socontainer", currow).Value = cont
                            Catch ex As Exception

                            End Try
                            Me.DataGridView1.Item("userid", currow).Value = ds.Tables(0).Rows(i).Item("userid").ToString

                            Me.DataGridView1.Item("updatetime", currow).Value = ds.Tables(0).Rows(i).Item("updatetime").ToString

                            Me.DataGridView1.Item("approve", currow).Value = ds.Tables(0).Rows(i).Item("approve").ToString

                        Next
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            Dim sql As String
            Dim i, currow As Integer
            Dim ds As New DataSet
            Me.DataGridView1.Rows.Clear()
            sql = "select *,kehoachdieuxe.ghichu as ghichu_ from kehoachdieuxe left join dmdaukeo on kehoachdieuxe.dmdaukeoid=dmdaukeo.dmdaukeoid left join dmmooc on kehoachdieuxe.dmmoocid=dmmooc.dmmoocid left join bookingagent on kehoachdieuxe.bookingid=bookingagent.bookingagentid left join customer on bookingagent.customerid=customer.customer_id  left join logistics on bookingagent.gmd_bookingno=logistics.BKNo where convert(datetime,ngay)  between  '" & ddMMMyyyy(Me.dtpNgaykehoach.Value) & "'  and '" & ddMMMyyyy(Me.dtpNgaykehoach1.Value) & "' and dmdaukeo.maxe='" & Me.cbobienso_tim.Text & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1


                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.LightYellow
                    Me.DataGridView1.Item("id", currow).Value = ds.Tables(0).Rows(i).Item("id").ToString
                    Me.DataGridView1.Item("status", currow).Value = ds.Tables(0).Rows(i).Item("status").ToString

                    Me.DataGridView1.Item("gmd_bookingno", currow).Value = ds.Tables(0).Rows(i).Item("gmd_bookingno").ToString

                    Me.DataGridView1.Item("company", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString
                    Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofloading").ToString

                    Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("gmd_portofdischarge").ToString

                    Me.DataGridView1.Item("gmd_salecode", currow).Value = ds.Tables(0).Rows(i).Item("gmd_salecode").ToString



                    Me.DataGridView1.Item("maxe", currow).Value = ds.Tables(0).Rows(i).Item("maxe").ToString
                    Me.DataGridView1.Item("mamooc", currow).Value = ds.Tables(0).Rows(i).Item("mamooc").ToString
                    Me.DataGridView1.Item("ngay", currow).Value = ds.Tables(0).Rows(i).Item("ngay").ToString
                    Me.DataGridView1.Item("gio", currow).Value = ds.Tables(0).Rows(i).Item("gio").ToString
                    Me.DataGridView1.Item("ghichu", currow).Value = ds.Tables(0).Rows(i).Item("ghichu_").ToString
                    Try
                        ' them so cont tu logistics vao luoi
                        Dim sqlcont As String
                        Dim dscont As New DataSet
                        Dim j As Integer
                        Dim cont As String = ""
                        If ds.Tables(0).Rows(0).Item("BLOB_ID").ToString = "" Then
                        Else
                            sqlcont = "select * from containerlogistics where outboundID='" & ds.Tables(0).Rows(0).Item("BLOB_ID").ToString & "' "
                            dscont = ReadDataSet(sqlcont)
                            If dscont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dscont.Tables(0).Rows.Count - 1
                                    cont += dscont.Tables(0).Rows(j).Item("containerno").ToString + "/"
                                Next
                            End If
                        End If

                        Me.DataGridView1.Item("socontainer", currow).Value = cont
                    Catch ex As Exception

                    End Try
                    Me.DataGridView1.Item("userid", currow).Value = ds.Tables(0).Rows(i).Item("userid").ToString

                    Me.DataGridView1.Item("updatetime", currow).Value = ds.Tables(0).Rows(i).Item("updatetime").ToString

                    Me.DataGridView1.Item("approve", currow).Value = ds.Tables(0).Rows(i).Item("approve").ToString

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            Dim ds As New DataSet
            Dim sql As String
            Dim cmd1 As New ADODB.Command
            Dim i As Integer
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from Printkehoachdieuxe  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' sau khi xoa ta them vao

            ' Sql = "select * from logisticsfreight left join charge on charge.charge_id=logisticsfreight.itemid where logisticsid='" & gLogisticsID & "' and customerid='" & gLogisticsCusID & "' and debitcredit='Debit' and os=0 and showdebit=0 and daudebit=0 " ' os=thu ho

            ' lay so lieu debitnote ghi vao tamdebit
            'thong so 
            'gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            'gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            ' ds = ReadDataSet(Sql)
            'Dim i As Integer
            Dim thanhtien1 As Double = 0

            Dim strQuery1 As String
            Dim rs1 As New ADODB.Recordset
            '
            If Me.DataGridView1.Rows.Count > 0 Then


                For i = 0 To Me.DataGridView1.Rows.Count - 2


                    strQuery1 = "SELECT * "
                    strQuery1 = strQuery1 & "FROM Printkehoachdieuxe "
                    rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()

                        .Fields("cot1").Value = Me.DataGridView1.Item("gmd_bookingno", i).Value
                        .Fields("cot2").Value = Me.DataGridView1.Item("status", i).Value
                        .Fields("cot3").Value = Me.DataGridView1.Item("Company", i).Value

                        .Fields("cot4").Value = Me.DataGridView1.Item("pol", i).Value

                        .Fields("cot5").Value = Me.DataGridView1.Item("pod", i).Value
                        .Fields("cot6").Value = Me.DataGridView1.Item("maxe", i).Value

                        .Fields("cot7").Value = Me.DataGridView1.Item("mamooc", i).Value
                        .Fields("cot8").Value = Me.DataGridView1.Item("ngay", i).Value

                        .Fields("cot9").Value = Me.DataGridView1.Item("gio", i).Value

                        .Fields("cot10").Value = Me.DataGridView1.Item("socontainer", i).Value
                        '  .Fields("cot11").Value = Me.DataGridView1.Item("gmd_noofcontainer", i).Value

                        .Fields("cot11").Value = Me.DataGridView1.Item("gmd_noofcontainerorpackage", i).Value
                        .Fields("cot12").Value = Me.DataGridView1.Item("gmd_salecode", i).Value

                        .Fields("cot13").Value = Me.DataGridView1.Item("ghichu", i).Value
                        .Fields("cot14").Value = Me.DataGridView1.Item("approve", i).Value
                        .Fields("cot15").Value = Me.DataGridView1.Item("userid", i).Value
                        .Fields("cot16").Value = Me.DataGridView1.Item("updatetime", i).Value



                        .Update()
                        .Close()
                    End With
                Next
            End If


            'If LoginSucceeded = True Then
            '    Dim form As New frmPrintKeHoachDieuXe
            '    form.MdiParent = frmMain
            '    form.Show()
            'End If
        Catch ex As Exception

        End Try
    End Sub
End Class