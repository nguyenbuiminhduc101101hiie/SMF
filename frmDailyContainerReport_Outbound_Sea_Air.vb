Public Class frmDailyContainerReport_Outbound_Sea_Air
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Me.DataGridView1.Rows.Clear()



            weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb")




        Catch ex As Exception

        End Try
    End Sub
    Public Sub weeklyreport_(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal hbl As String)
        Try
            Dim currow As Integer
            ' kiem tra neu co du lieu yhi moi add
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            Dim date1, date2 As String
            date1 = ddMMMyyyy(Me.DateTimePicker1.Value.Date)
            date2 = ddMMMyyyy(Me.DateTimePicker2.Value.Date)
            ''' hang air
            sql = "select *,containertype.ghichucontainer as ghichu_cont from Outbound_OverseaAirExport left join containertype  on containertype.outboundId=Outbound_OverseaAirExport.BLOB_ID where (convert(datetime,datereport) between '" & date1 & "' and '" & date2 & "')  "
            'End If
            ds = ReadDataSet(sql)
            Dim m As Integer
            Dim itang As Integer = 1
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung voi moi lo ta tim sont
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lap bill

                    'Me.DataGridView1.Rows.Add(1)
                    'currow = DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    '  Me.DataGridView1.Item("no", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                    Try
                        Me.DataGridView1.Item("week", currow).Value = WeekOfYear(CDate(ds.Tables(0).Rows(i).Item("datereport").ToString)) ' ds.Tables(0).Rows(i).Item("gflc").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Outbound_Sea_Air_id", currow).Value = ds.Tables(0).Rows(i).Item("blob_id").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("MOT", currow).Value = "AIR"
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("PIC", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("LOT", currow).Value = ds.Tables(0).Rows(i).Item("lot").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("REF", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("BILL", currow).Value = ds.Tables(0).Rows(i).Item("MBLMAWB").ToString
                    Catch ex As Exception

                    End Try
                    Dim icont As Integer
                    Dim pks As Double = 0
                    Dim kgs As Double = 0
                    Dim cbm As Double = 0

                    For icont = 0 To ds.Tables(0).Rows.Count - 1
                        Try
                            pks += ds.Tables(0).Rows(icont).Item("sokien").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            kgs += ds.Tables(0).Rows(icont).Item("sokg").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            cbm += ds.Tables(0).Rows(icont).Item("sokhoi").ToString
                        Catch ex As Exception

                        End Try


                    Next


                    Try
                        Me.DataGridView1.Item("PKG", currow).Value = FormatNumber(pks, 3) + " " + ds.Tables(0).Rows(i).Item("type").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("POL", currow).Value = ds.Tables(0).Rows(i).Item("polCode").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Destination_ETA", currow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ContMBL", currow).Value = ds.Tables(0).Rows(i).Item("MBL").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("status", currow).Value = ds.Tables(0).Rows(i).Item("tinhtrang").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("danhapkho", currow).Value = ds.Tables(0).Rows(i).Item("danhapkho").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("daxuatkho", currow).Value = ds.Tables(0).Rows(i).Item("daxuatkho").ToString
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("AND0", currow).Value = ds.Tables(0).Rows(i).Item("ngayan").ToString + "/" + ds.Tables(0).Rows(i).Item("ngayan").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("note", currow).Value = ds.Tables(0).Rows(i).Item("ghichu_cont").ToString
                    Catch ex As Exception

                    End Try
                    '------------------------------------------
                    Try
                        Me.DataGridView1.Item("VSLAIRLINES", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString
                    Catch ex As Exception

                    End Try

                    '------------------------------------------
                    Try
                        Me.DataGridView1.Item("VoyFlight", currow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                    Catch ex As Exception

                    End Try
                    'itang += 1
                Next



            End If

            '------------------------------
            ''' hang air
            sql = "select *,containertype.ghichucontainer as ghichu_cont from   outbound left join containertype on containertype.outboundId=Outbound.BLoB_ID where (convert(datetime,datereport) between '" & date1 & "' and '" & date2 & "')  "
            'End If
            ds = ReadDataSet(sql)
            m = 0
            itang = 1
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung voi moi lo ta tim sont
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lap bill

                    'Me.DataGridView1.Rows.Add(1)
                    'currow = DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    ' Me.DataGridView1.Item("no", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                    Try
                        Me.DataGridView1.Item("week", currow).Value = WeekOfYear(CDate(ds.Tables(0).Rows(i).Item("datereport").ToString)) ' ds.Tables(0).Rows(i).Item("gflc").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Outbound_Sea_Air_id", currow).Value = ds.Tables(0).Rows(i).Item("blob_id").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("MOT", currow).Value = "SEA"
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("PIC", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("LOT", currow).Value = ds.Tables(0).Rows(i).Item("lot").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("REF", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("BILL", currow).Value = ds.Tables(0).Rows(i).Item("MBLMAWB").ToString
                    Catch ex As Exception

                    End Try
                    Dim icont As Integer
                    Dim pks As Double = 0
                    Dim kgs As Double = 0
                    Dim cbm As Double = 0

                    For icont = 0 To ds.Tables(0).Rows.Count - 1
                        Try
                            pks += ds.Tables(0).Rows(icont).Item("sokien").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            kgs += ds.Tables(0).Rows(icont).Item("sokg").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            cbm += ds.Tables(0).Rows(icont).Item("sokhoi").ToString
                        Catch ex As Exception

                        End Try


                    Next


                    Try
                        Me.DataGridView1.Item("PKG", currow).Value = FormatNumber(pks, 3) + " " + ds.Tables(0).Rows(i).Item("type").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("POL", currow).Value = ds.Tables(0).Rows(i).Item("polCode").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Destination_ETA", currow).Value = ds.Tables(0).Rows(i).Item("ETA").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ContMBL", currow).Value = ds.Tables(0).Rows(i).Item("containerNo").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("status", currow).Value = ds.Tables(0).Rows(i).Item("tinhtrang").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("danhapkho", currow).Value = ds.Tables(0).Rows(i).Item("danhapkho").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("daxuatkho", currow).Value = ds.Tables(0).Rows(i).Item("daxuatkho").ToString
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("AND0", currow).Value = ds.Tables(0).Rows(i).Item("ngayan").ToString + "/" + ds.Tables(0).Rows(i).Item("ngayan").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("note", currow).Value = ds.Tables(0).Rows(i).Item("ghichu_cont").ToString
                    Catch ex As Exception

                    End Try
                    '------------------------------------------
                    Try
                        Me.DataGridView1.Item("VSLAIRLINES", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString
                    Catch ex As Exception

                    End Try

                    '------------------------------------------
                    Try
                        Me.DataGridView1.Item("VoyFlight", currow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                    Catch ex As Exception

                    End Try
                    'itang += 1
                Next



            End If
            ' dua cac phi vao



            '=================================================================================================================
            '=================================================================================================================
            '------------------------

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
    End Sub
    Dim moutboundContainerID As String
    Dim mStatusContainer As String
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Try

            If mStatusContainer = "Normal" And UserRight("mnuOutbound", "Add") Then

                Me.Button49.Enabled = True
                '--------------

                Me.txtContainerNo.Enabled = True

                Me.txtType.Enabled = True

                Me.txtSeal.Enabled = True


                Me.txtsoKien.Enabled = True


                Me.txttype_.Enabled = True


                Me.txtsoKg.Enabled = True


                '  Me.txtChargeA.Enabled = True



                Me.txtCBM.Enabled = True
                '---------------------------

                moutboundContainerID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                mStatusContainer = "Add"
                Me.txtContainerNo.Text = ""
                Me.txtType.Text = ""
                Me.txtSeal.Text = ""
                Me.txtsoKg.Text = ""
                Me.txtsoKien.Text = ""
                Me.txtCBM.Text = ""
                Me.txtnetweight.Text = ""
                txtngayan.Text = ""
                txtngaydo.Text = ""
                Me.txtdanhapkho.Text = ""
                Me.txtdaxuatkho.Text = ""
                Me.txtghichuContainer.Text = ""



            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDataContainer(ByVal index As Integer)
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from containertype where OutboundContainersID='" & moutboundContainerID & "'"

            ds = ReadDataSet(sql)
            Try


            Catch ex As Exception

            End Try

            Me.txtContainerNo.Text = ds.Tables(0).Rows(0).Item("containerno").ToString ';Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.txtType.Text = ds.Tables(0).Rows(0).Item("containertype").ToString 'Me.dgdContainers.Item("containertype", index).Value.ToString


            Me.txtSeal.Text = ds.Tables(0).Rows(0).Item("seal").ToString ' Me.dgdContainers.Item("seal", index).Value.ToString


            Me.txtsoKien.Text = ds.Tables(0).Rows(0).Item("sokien").ToString 'Me.dgdContainers.Item("sokien", index).Value.ToString


            Me.txttype_.Text = ds.Tables(0).Rows(0).Item("type").ToString 'Me.dgdContainers.Item("type", index).Value.ToString


            Me.txtsoKg.Text = ds.Tables(0).Rows(0).Item("sokg").ToString 'Me.dgdContainers.Item("sokg", index).Value.ToString


            'Me.txtChargeA.Text = Me.dgdContainers.Item("kgavailable", index).Value.ToString



            Me.txtCBM.Text = ds.Tables(0).Rows(0).Item("sokhoi").ToString ' Me.dgdContainers.Item("sokhoi", index).Value.ToString


            Try
                Me.cbotinhtrang.Text = ds.Tables(0).Rows(0).Item("tinhtrang").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtdanhapkho.Text = ds.Tables(0).Rows(0).Item("danhapkho").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtdaxuatkho.Text = ds.Tables(0).Rows(0).Item("daxuatkho").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtngayan.Text = ds.Tables(0).Rows(0).Item("ngayan").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtngaydo.Text = ds.Tables(0).Rows(0).Item("ngaydo").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtghichuContainer.Text = ds.Tables(0).Rows(0).Item("ghichucontainer").ToString
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim vitri As Integer
            'kiểm tra xem Grid có dữ liệu không

            If Me.dgdContainers.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdContainers.CurrentRow.Index
            vitri = index
            If index >= 0 Then

                If mStatusContainer = "Normal" And UserRight("mnuOutbound", "Edit") Then

                    Me.Button49.Enabled = True
                    moutboundContainerID = Me.dgdContainers.Item("OutboundContainersID", index).Value.ToString
                    mStatusContainer = "Edit"
                    Me.dgdContainers.Enabled = False
                    RefreshDataContainer(index)

                    'Me.QueryContainer()
                    Me.txtContainerNo.Enabled = True

                    Me.txtType.Enabled = True

                    Me.txtSeal.Enabled = True


                    Me.txtsoKien.Enabled = True


                    Me.txttype_.Enabled = True


                    Me.txtsoKg.Enabled = True


                    'Me.txtChargeA.Enabled = True



                    Me.txtCBM.Enabled = True



                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim moutboundID As String
    Sub QueryContainer(Optional ByVal location As Integer = 0)
        Try
            Dim ds As New DataSet
            Dim sql As String = "Select  Outboundcontainersid,Outboundid,containerno,containertype,type,descriptionContainer,seal,sokien,netweight,sokg,sokhoi,nhietdo,thonggio,tinhtrang,danhapkho,daxuatkho,ngayan,ngaydo,ghichucontainer "
            sql &= " From Containertype "
            sql &= "Where " & _
                   " outboundID='" & moutboundID & "'  "
            ds = ReadDataSet(sql)
            Me.dgdContainers.DataSource = ds.Tables(0)


            '--------------------
            'Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdContainers)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click

        Try
            If Me.dgdContainers.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.dgdContainers.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRowContainer(Me.dgdContainers.SelectedRows(i).Index)
                Next i
            End If
            Me.QueryContainer()
            ' sent qua manifest

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Deleterowcontainer(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi





        'che tam vi chua co quan he voi Dulieu khac


        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnuOutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container: " & Me.dgdContainers.Item("containerNo", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then

                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from containertype where OutboundContainersID= '" & Me.dgdContainers.Item("OutboundContainersID", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmDailyContainerReport_Inbound_Sea_Air_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mStatusContainer = "Normal"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        Try
            ' Me.txtContainerNo1.Text = ""
            Me.txtContainerNo.Enabled = False
            ' Me.txtType1.Text = ""
            Me.txtType.Enabled = False

            ' Me.txtSeal1.Text = ""
            Me.txtSeal.Enabled = False

            'Me.txtsoKien1.Text = ""
            Me.txtsoKien.Enabled = False

            ' Me.txtPackages.Text = ""
            Me.txttype_.Enabled = False

            ' Me.txtsoKg1.Text = ""
            Me.txtsoKg.Enabled = False

            'Me.txtChargeA.Text = ""
            'Me.txtChargeA.Enabled = False


            ' Me.txtCBM1.Text = ""
            Me.txtCBM.Enabled = False

            mStatusContainer = "Normal"
            Me.Button49.Enabled = False
            Me.dgdContainers.Enabled = True

            'Me.GroupBox6.Enabled = False
            'Me.GroupBox9.Enabled = False
            'Me.GroupBox10.Enabled = False
            ' Me.GroupBox1.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim vitri As Integer
            If Me.DataGridView1.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.DataGridView1.CurrentRow.Index
            vitri = index



            Me.GroupBox1.Visible = True
            Me.GroupBox1.BringToFront()


            'Try
            '    Me.txtNoDebit.Text = "DN-" + Me.txtRef.Text
            '    Me.txtNoCredit.Text = "CN-" + Me.txtRef.Text
            'Catch ex As Exception

            'End Try

            If index >= 0 Then

                If UserRight("mnuOutbound", "Edit") Then

                    '
                    'SetMenu((False))

                    moutboundID = Me.DataGridView1.Item("Outbound_Sea_Air_id", index).Value.ToString
                End If
            End If
            '
            Me.txtContainerNo.Text = ""
            Me.txtType.Text = ""
            Me.txtSeal.Text = ""
            Me.txtsoKg.Text = ""
            Me.txtsoKien.Text = ""
            Me.txtCBM.Text = ""
            Me.txtnetweight.Text = ""
            txtngayan.Text = ""
            txtngaydo.Text = ""
            Me.txtdanhapkho.Text = ""
            Me.txtdaxuatkho.Text = ""
            Me.txtghichuContainer.Text = ""

            QueryContainer()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset


                If mStatusContainer = "Add" Or mStatusContainer = "Edit" Then
                    Try
                        copyHistory("containertype", "outboundcontainersid", moutboundContainerID, "history")
                    Catch ex As Exception

                    End Try
                    ' them container
                    '=========='
                    strQuery = "Select * From containertype Where outboundcontainersid='" & moutboundContainerID & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("OutboundContainersID").Value = NewId()
                        End If

                        .Fields("OutboundID").Value = getID(moutboundID)

                        ' them denger

                        '-------------------------------container
                        .Fields("ContainerNo").Value = Me.txtContainerNo.Text
                        '------------------------------------------
                        .Fields("containertype").Value = Me.txtType.Text
                        .Fields("type").Value = Me.txttype_.Text
                        '--------------------------------------------------------------------------------
                        .Fields("seal").Value = Me.txtSeal.Text
                        '------------------------------------------------------------------------------------
                        .Fields("sokien").Value = Me.txtsoKien.Text
                        .Fields("netweight").Value = Me.txtnetweight.Text
                        '-------------------------------------------------------------------------------
                        .Fields("sokg").Value = Me.txtsoKg.Text
                        '---------------------------------------------------------------------
                        .Fields("sokhoi").Value = Me.txtCBM.Text
                        ' .Fields("kgavailable").Value = Me.txtChargeA.Text
                        ' .Fields("path").Value = Me.cboduongdan.Text


                        '==========================================


                        '   .Fields("contdatravedaily").Value = Me.chkContDaTraVeDaiLy.Checked
                        '   .Fields("ngayCDTVDL").Value = Me.txtNgayCDTVDL.Text
                        '---them de tinh credit cho Dai ly


                        '--------------------------------------------------------------




                        Try
                            .Fields("tinhtrang").Value = Me.cbotinhtrang.Text
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("danhapkho").Value = Me.txtdanhapkho.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("daxuatkho").Value = Me.txtdaxuatkho.Text
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("ngayan").Value = Me.txtngayan.Text
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("ngaydo").Value = Me.txtngaydo.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("ghichucontainer").Value = Me.txtghichuContainer.Text
                        Catch ex As Exception

                        End Try
                        .Update()
                    End With
                    rs.Close()

                End If
                mStatusContainer = "Normal"
                Me.Button49.Enabled = False
                Me.dgdContainers.Enabled = True
                Button50_Click(sender, e)
                Me.QueryContainer()


            Catch ex As Exception

            End Try


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ' Me.txtContainerNo1.Text = ""
            Me.txtContainerNo.Enabled = False
            ' Me.txtType1.Text = ""
            Me.txtType.Enabled = False

            ' Me.txtSeal1.Text = ""
            Me.txtSeal.Enabled = False

            'Me.txtsoKien1.Text = ""
            Me.txtsoKien.Enabled = False

            ' Me.txtPackages.Text = ""
            Me.txttype_.Enabled = False

            ' Me.txtsoKg1.Text = ""
            Me.txtsoKg.Enabled = False

            'Me.txtChargeA.Text = ""
            'Me.txtChargeA.Enabled = False


            ' Me.txtCBM1.Text = ""
            Me.txtCBM.Enabled = False

            mStatusContainer = "Normal"
            Me.Button49.Enabled = False
            Me.dgdContainers.Enabled = True

            'Me.GroupBox6.Enabled = False
            'Me.GroupBox9.Enabled = False
            'Me.GroupBox10.Enabled = False
            Me.GroupBox1.Visible = False
            Me.Button9_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button105_Click(sender As Object, e As EventArgs) Handles Button105.Click
        Try
            Me.txtdanhapkho.Text = ddMMMyyyy(Me.DateTimePicker16.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button104_Click(sender As Object, e As EventArgs) Handles Button104.Click
        Try
            Me.txtdaxuatkho.Text = ddMMMyyyy(Me.DateTimePicker16.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button107_Click(sender As Object, e As EventArgs) Handles Button107.Click
        Try
            Me.txtngayan.Text = ddMMMyyyy(Me.DateTimePicker16.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button106_Click(sender As Object, e As EventArgs) Handles Button106.Click
        Try
            Me.txtngaydo.Text = ddMMMyyyy(Me.DateTimePicker16.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBox1.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox1_MouseEnter(sender As Object, e As EventArgs) Handles GroupBox1.MouseEnter

    End Sub

    Private Sub GroupBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles GroupBox1.MouseMove
        If Mdown Then
            Me.GroupBox1.Left = (e.X - X) + Me.GroupBox1.Left
            Me.GroupBox1.Top = (e.Y - Y) + Me.GroupBox1.Top
        End If
    End Sub

    Private Sub GroupBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles GroupBox1.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox1.Left = (e.X - X) + Me.GroupBox1.Left
            Me.GroupBox1.Top = (e.Y - Y) + Me.GroupBox1.Top
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class