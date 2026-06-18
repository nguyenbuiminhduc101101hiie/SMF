Public Class frmRef_ChiphiPhanbo

    Dim mStatusCredit As String
    Dim oTblEquip, otblHinh As New DataTable
    Public mID, mOutboundID, mHinhID, mdebitid, mCreditId, mLogisticsID, mStatusTheodoi, mStatusCashLoan As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            ' tao table ref_credit
            Dim id, value, strSQL As String
            Dim ds As New DataSet

            '-----------------------------------------------
            id = "ref"
            value = "ref"
            Me.cboRef.Items.Clear()
            strSQL = "select distinct ref from ref_credit where ref like '%" & Me.txtref.Text & "%'  "
            loadDataToObject(Me.cboRef, strSQL, id, value)

        Catch ex As Exception

        End Try
    End Sub
    Sub QueryCredit(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select ref_creditid,ref,dntt,customerid,itemid,company + '-' + taxcode as company,charge_code as item,currency,containertype,unitprice,  taxprice,  price, note, quantity, os,   tigia "
            sql &= "  ,ref_credit.approve,userupdate,dateupdate,showvnd  From ref_credit left join customer on ref_credit.customerid=customer.customer_id  left join charge on ref_credit.itemid=charge.charge_id "
            sql &= "Where " & _
           " ref_creditid='" & mCreditId & "'  and debitcredit='Credit'"
            oTblEquip = ReadTable(sql)
            Me.dgdCreditGrid.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdCreditGrid)
            '  Me.profit()
            ' doi mau do neu other=1
            Dim i As Integer
            Try
                For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
                    If Me.dgdCreditGrid.Item("other", i).Value = "True" Then
                        Me.dgdCreditGrid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        Me.dgdCreditGrid.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    End If
                Next
            Catch ex As Exception

            End Try

            'End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Private Sub cmdok_credit_Click(sender As Object, e As EventArgs) Handles cmdok_credit.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset

            If Me.txtexcredit.Text = "1" Or Me.txtexcredit.Text = "" Then
                DisplayMessage(True, "Xin nhập tỉ giá.")
                Me.txtexcredit.Focus()
                Exit Sub
            End If


            If mStatusCredit = "Add" Or mStatusCredit = "Edit" Then
                Try
                    ' copyHistory("outboundfreight", "outboundfreightid", mCreditId, "history")
                Catch ex As Exception

                End Try
                ' them container
                '=========='
                strQuery = "Select * From ref_credit Where ref_creditid ='" & mCreditId & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("ref_creditid").Value = NewId()
                        '  .Fields("outboundID").Value = getID(mOutboundID)
                    End If
                    .Fields("ref").Value = Me.cboref_them.Text

                    '-------------------------------container
                    If FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text) Like "*{*" Then
                        .Fields("customerid").Value = FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text)
                    Else
                        .Fields("customerid").Value = "{" + FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text) + "}"
                    End If
                    If FindValueID(Me.cboitemcredit, Me.cboitemcredit.Text) Like "*{*" Then
                        .Fields("itemid").Value = FindValueID(Me.cboitemcredit, Me.cboitemcredit.Text)
                    Else
                        .Fields("itemid").Value = "{" + FindValueID(Me.cboitemcredit, Me.cboitemcredit.Text) + "}"
                    End If

                    .Fields("currency").Value = Me.txtcurrcredit.Text
                    .Fields("containertype").Value = Me.txtunitcredit.Text
                    .Fields("unitprice").Value = Me.txtunitpricecredit.Text
                    .Fields("quantity").Value = Me.txtquantitycredit.Text
                    '.Fields("pricetruocthue").Value = Me.txtpricenotaxcredit.Text
                    '.Fields("pricenotaxvnd").Value = Me.txtpricenotaxvndcredit.Text


                    .Fields("taxprice").Value = Me.txttaxcredit.Text
                    '.Fields("pricethue").Value = Me.txtpricetaxcredit.Text
                    .Fields("price").Value = Me.txtpricecredit.Text
                    .Fields("note").Value = Me.txtremarkscredit.Text
                    .Fields("os").Value = Me.chkoscredit.Checked
                    .Fields("paycheck").Value = Me.chkpaycredit.Checked
                    Try
                        .Fields("dntt").Value = Me.chkdntt.Checked
                    Catch ex As Exception

                    End Try
                    .Fields("daily").Value = Me.chkagent_credit.Checked
                    .Fields("ngay").Value = Me.txtinvoicecredit.Text
                    .Fields("ngayhoadon").Value = Me.txtinvoicenocredit.Text
                    .Fields("tigia").Value = Me.txtexcredit.Text
                    .Fields("debitcredit").Value = "Credit"
                    '   .Fields("container").Value = Me.cbocontainerCredit.Text

                    .Fields("showvnd").Value = Me.chkShowVND_Credit.Checked
                    .Update()
                End With
                rs.Close()

            End If
            mStatusCredit = "Normal"
            Me.cmdok_credit.Enabled = False
            Me.cmdcancel_credit_Click(sender, e)
            Me.cboRef.Text = Me.cboref_them.Text
            Me.Button2_Click(sender, e)
            ' Me.QueryCredit()
            '  profit()
            ' profit_theonguyente()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancel_credit_Click(sender As Object, e As EventArgs) Handles cmdcancel_credit.Click
        Try

            Me.Button3.Enabled = False
            Me.Button28.Enabled = False
            Me.chkManualCredit.Enabled = False
            Me.cboref_them.Enabled = False
            Me.TextBox1.Enabled = False
            Me.TextBox2.Enabled = False




            Me.cbocuscredit.Enabled = False

            Me.cboitemcredit.Enabled = False

            Me.txtcurrcredit.Enabled = False


            Me.txtunitcredit.Enabled = False


            Me.txtquantitycredit.Enabled = False


            Me.txtunitpricecredit.Enabled = False
            ' Me.txtpricenotaxcredit.Enabled = False
            Me.txtexcredit.Enabled = False
            Me.txttaxcredit.Enabled = False
            ' Me.txtpricetaxcredit.Enabled = False
            Me.txtpricecredit.Enabled = False
            Me.txtremarkscredit.Enabled = False
            Me.chkoscredit.Enabled = False
            Me.chkpaycredit.Enabled = False
            Me.txtinvoicecredit.Enabled = False
            '  Me.txtChargeA.Enabled = True
            Me.txtinvoicenocredit.Enabled = False

            mStatusCredit = "Normal"
            Me.cmdok_credit.Enabled = False
            chkShowVND_Credit.Enabled = False
            chkdntt.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If Me.cboRef.Text = "" Then
            Else
                Try
                    Dim sql As String = "Select ref_creditid,ref,ref_Da_phanbo,dntt,customerid,itemid,company + '-' + taxcode as company,charge_code as item,currency,containertype,unitprice,  taxprice,  price, note, quantity, os,   tigia "
                    sql &= "  ,ref_credit.approve,userupdate,dateupdate,showvnd  From ref_credit left join customer on ref_credit.customerid=customer.customer_id  left join charge on ref_credit.itemid=charge.charge_id "
                    sql &= "Where " & _
                           " ref='" & Me.cboRef.Text & "'  and debitcredit='Credit'"
                    oTblEquip = ReadTable(sql)
                    Me.dgdCreditGrid.DataSource = oTblEquip


                    '--------------------
                    Me.Cursor = System.Windows.Forms.Cursors.Default

                    InsertAutoNumberToGrid(Me.dgdCreditGrid)
                    '  Me.profit()
                    ' doi mau do neu other=1
                    Dim i As Integer
                    Try
                        For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
                            If Me.dgdCreditGrid.Item("other", i).Value = "True" Then
                                Me.dgdCreditGrid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                                Me.dgdCreditGrid.Rows(i).DefaultCellStyle.ForeColor = Color.White
                            End If
                        Next
                    Catch ex As Exception

                    End Try

                    'End If
                Catch ex As Exception
                    MsgBox(msgErr(Me, ex.Message))
                End Try

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ThêmPhíToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmPhíToolStripMenuItem.Click
        Try
            Try
                'allCus()
                '  addluoicont()
                Dim ApproveCreditNote As Boolean
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'vitri = index
                'If index >= 0 Then
                '    ApproveCreditNote = Me.dgdCreditGrid.Item("ApproveCredit", index).Value
                'End If
                If mStatusCredit = "Normal" And UserRight("smnuref_credit", "Edit") Then

                    Me.cmdok_credit.Enabled = True
                    '--------------

                    Me.cbocuscredit.Enabled = True

                    Me.cboitemcredit.Enabled = True

                    Me.txtcurrcredit.Enabled = True


                    Me.txtunitcredit.Enabled = True


                    Me.txtquantitycredit.Enabled = True


                    Me.txtunitpricecredit.Enabled = True
                    '   Me.txtpricenotaxcredit.Enabled = True
                    Me.txtexcredit.Enabled = True
                    Me.txttaxcredit.Enabled = True
                    ' Me.txtpricetaxcredit.Enabled = True
                    Me.txtpricecredit.Enabled = True
                    Me.txtremarkscredit.Enabled = True
                    Me.chkoscredit.Enabled = True
                    Me.chkpaycredit.Enabled = True
                    Me.txtinvoicecredit.Enabled = True
                    '  Me.txtChargeA.Enabled = True
                    Me.txtinvoicenocredit.Enabled = True
                    chkShowVND_Credit.Enabled = True

                    Me.Button3.Enabled = True
                    Me.Button28.Enabled = True
                    Me.chkManualCredit.Enabled = True
                    Me.cboref_them.Enabled = True
                    Me.TextBox1.Enabled = True
                    Me.TextBox2.Enabled = True

                    chkdntt.Enabled = True
                    '---------------------------

                    mCreditId = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusCredit = "Add"
                    Me.txtexcredit.Text = getCur("USD")
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub allCus()
        Try
            Dim id, value, strQuery As String
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where CONTINUED=1 Order by company "
            '   Me.cbocusdebit.Items.Clear()
            Me.cbocuscredit.Items.Clear()




            '   loadDataToObject(Me.cbocusdebit, strQuery, id, value)
            loadDataToObject(Me.cbocuscredit, strQuery, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDataCreditgrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Dim oItems As PDSAListItemString
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from ref_credit left join customer on ref_credit.customerid=customer.customer_id left join charge on ref_credit.itemid=charge.charge_id where ref_creditID='" & mCreditId & "' and ref_credit.continued=1"

            ds = ReadDataSet(sql)
            '    lay tong teu.tongcbm

            Try
                Me.cboref_them.Text = ds.Tables(0).Rows(0).Item("ref").ToString


            Catch ex As Exception

            End Try
            Try
                Me.cboitemcredit.Text = ds.Tables(0).Rows(0).Item("charge_code").ToString


            Catch ex As Exception

            End Try
            Try
                Me.cbocuscredit.Text = ds.Tables(0).Rows(0).Item("company").ToString + "-" + ds.Tables(0).Rows(0).Item("taxcode").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtcurrcredit.Text = ds.Tables(0).Rows(0).Item("currency").ToString 'Me.dgdCreditGrid.Item("currency_Credit", index).Value.ToString

            Catch ex As Exception

            End Try


            Try
                Me.txtunitcredit.Text = ds.Tables(0).Rows(0).Item("containertype").ToString 'Me.dgdCreditGrid.Item("containertype_Credit", index).Value.ToString
            Catch ex As Exception

            End Try



            Try
                Me.txtquantitycredit.Text = FormatNumber(ds.Tables(0).Rows(0).Item("quantity").ToString, 2)
            Catch ex As Exception

            End Try



            Try
                Me.txtunitpricecredit.Text = FormatNumber(ds.Tables(0).Rows(0).Item("unitprice").ToString, 2)
            Catch ex As Exception

            End Try


            Try
                Me.txtexcredit.Text = ds.Tables(0).Rows(0).Item("tigia").ToString 'Me.dgdCreditGrid.Item("tigia_Credit", index).Value.ToString
            Catch ex As Exception

            End Try



            Try
                Me.txttaxcredit.Text = ds.Tables(0).Rows(0).Item("taxprice").ToString 'Me.dgdCreditGrid.Item("taxprice_Credit", index).Value.ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtpricecredit.Text = FormatNumber(ds.Tables(0).Rows(0).Item("price").ToString, 2) 'Me.dgdCreditGrid.Item("price_Credit", index).Value.ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtremarkscredit.Text = ds.Tables(0).Rows(0).Item("note").ToString ' Me.dgdCreditGrid.Item("note_Credit", index).Value.ToString
            Catch ex As Exception

            End Try

            Try
                Me.chkdntt.Checked = ds.Tables(0).Rows(0).Item("dntt").ToString 'Me.dgdCreditGrid.Item("dntt", index).Value.ToString

            Catch ex As Exception

            End Try


            Try
                Me.chkShowVND_Credit.Checked = ds.Tables(0).Rows(0).Item("showvnd").ToString 'Me.dgdCreditGrid.Item("dntt", index).Value.ToString

            Catch ex As Exception

            End Try

            Try
                Me.chkoscredit.Checked = ds.Tables(0).Rows(0).Item("os").ToString 'Me.dgdCreditGrid.Item("Os_Credit", index).Value.ToString

            Catch ex As Exception

            End Try

            Try
                Me.chkpaycredit.Checked = ds.Tables(0).Rows(0).Item("paycheck").ToString 'Me.dgdCreditGrid.Item("paycheck_Credit", index).Value.ToString
            Catch ex As Exception

            End Try
            Try
                'Me.chkagent_credit.Checked = ds.Tables(0).Rows(0).Item("agent").ToString  'Me.dgdCreditGrid.Item("_credit", index).Value.ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtinvoicecredit.Text = ds.Tables(0).Rows(0).Item("ngay").ToString 'Me.dgdCreditGrid.Item("ngay_Credit", index).Value.ToString
            Catch ex As Exception

            End Try


            '  Me.txtChargeA.Enabled = True
            Try
                Me.txtinvoicenocredit.Text = ds.Tables(0).Rows(0).Item("ngayhoadon").ToString 'Me.dgdCreditGrid.Item("ngayhoadon_Credit", index).Value.ToString
            Catch ex As Exception

            End Try

            'Me.cbocuscredit.Text = Me.dgdCreditGrid.Item("company_Credit", index).Value.ToString
            'Me.cbocontainerCredit.Text = Me.dgdCreditGrid.Item("containercredit", index).Value.ToString
            'Me.txtfreedemcredit.Text = Me.dgdCreditGrid.Item("freedemcredit", index).Value.ToString
            'Me.txtfreedetcredit.Text = Me.dgdCreditGrid.Item("freedetcredit", index).Value.ToString
            'Me.chkShowVND_Credit.Checked = Me.dgdCreditGrid.Item("showvnd_credit", index).Value.ToString
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SửaPhíToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SửaPhíToolStripMenuItem.Click
        Try
            Try
                Dim Approve, EditTable, UsrRight As Boolean

                'kiểm tra xem Grid có dữ liệu không
                allCus()
                'addluoicont()
                If Me.dgdCreditGrid.RowCount = 0 Then
                    DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                    Return
                End If
                Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
                Approve = Me.dgdCreditGrid.Item("ApproveCredit", index).Value
                ' vitri = index
                If index >= 0 Then

                    If mStatusCredit = "Normal" And Not Approve And UserRight("smnuref_credit", "Edit") Then

                        Me.cmdok_credit.Enabled = True

                        mCreditId = Me.dgdCreditGrid.Item("ref_creditid", index).Value.ToString
                        mStatusCredit = "Edit"

                        RefreshDataCreditgrid(index)

                        'Me.QueryContainer()
                        Me.cbocuscredit.Enabled = True

                        Me.cboitemcredit.Enabled = True

                        Me.txtcurrcredit.Enabled = True


                        Me.txtunitcredit.Enabled = True


                        Me.txtquantitycredit.Enabled = True


                        Me.txtunitpricecredit.Enabled = True
                        ' Me.txtpricenotaxcredit.Enabled = True
                        Me.txtexcredit.Enabled = True
                        Me.txttaxcredit.Enabled = True
                        ' Me.txtpricetaxcredit.Enabled = True
                        Me.txtpricecredit.Enabled = True
                        Me.txtremarkscredit.Enabled = True
                        Me.chkoscredit.Enabled = True
                        Me.chkpaycredit.Enabled = True
                        Me.txtinvoicecredit.Enabled = True
                        '  Me.txtChargeA.Enabled = True
                        Me.txtinvoicenocredit.Enabled = True
                        Me.Button3.Enabled = True
                        Me.Button28.Enabled = True
                        Me.chkManualCredit.Enabled = True
                        Me.cboref_them.Enabled = True
                        Me.TextBox1.Enabled = True
                        Me.TextBox2.Enabled = True
                        chkdntt.Enabled = True
                        chkShowVND_Credit.Enabled = True
                    Else
                        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub DeleterowCredit(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi



        If Not IsNothing(Me.dgdCreditGrid.Item("Approvecredit", index)) Then
            If Me.dgdCreditGrid.Item("Approvecredit", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If


        'che tam vi chua co quan he voi Dulieu khac


        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("smnuref_credit", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Credit: " & Me.dgdCreditGrid.Item("item_Credit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                ' copyHistory("outboundfreight", "outboundfreightid", Me.dgdCreditGrid.Item("outboundfreightid_credit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from ref_credit where ref_creditID= '" & Me.dgdCreditGrid.Item("ref_creditid", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub XóaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XóaToolStripMenuItem.Click
        Try
            Try
                If Me.dgdCreditGrid.Rows.Count = 0 Then
                    Return
                End If


                Dim selectedRowCount As Integer = _
                     Me.dgdCreditGrid.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If selectedRowCount = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If
                If selectedRowCount > 0 Then
                    Dim sb As New System.Text.StringBuilder()
                    Dim i As Integer
                    For i = 0 To selectedRowCount - 1
                        DeleterowCredit(Me.dgdCreditGrid.SelectedRows(i).Index)
                    Next i
                End If
                Me.QueryCredit()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            Me.cbocuscredit.Items.Clear()
            strSQL = "Select customer_id,company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.TextBox1.Text & "%' or taxcode like '%" & Me.TextBox1.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocuscredit, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtquantitycredit_TextChanged(sender As Object, e As EventArgs) Handles txtquantitycredit.TextChanged
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 3)
                'txtexcredit_TextChanged(sender, e)
                'txttaxcredit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricecredit_TextChanged(sender As Object, e As EventArgs) Handles txtunitpricecredit.TextChanged
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 3)
                'txtexcredit_TextChanged(sender, e)
                'txttaxcredit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Try
                ' tao table ref_credit
                Dim id, value, strSQL As String
                Dim ds As New DataSet

                '-----------------------------------------------
                id = "ref_phanbo"
                value = "ref_phanbo"
                Me.cboref_them.Items.Clear()
                strSQL = "select distinct ref_phanbo from logistics where ref_phanbo like '%" & Me.TextBox2.Text & "%'  "
                loadDataToObjectNoClear(Me.cboref_them, strSQL, id, value)

                ' strSQL = "select distinct ref from inbound where ref like '%" & Me.TextBox2.Text & "%'  "
                'loadDataToObjectNoClear(Me.cboref_them, strSQL, id, value)


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim id_ As String
            Dim value_ As String
            Dim strQuery_ As String
            Me.cboitemcredit.Items.Clear()
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code from charge where CONTINUED=1 Order by charge_code "



            loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)
            ' loadDataToObject(Me.cboitemdebit, strQuery_, id_, value_)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmRef_ChiphiPhanbo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            mStatusCredit = "Normal"
            Dim id_, id, value As String
            Dim value_ As String
            Dim strQuery_, strSQL As String
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code from charge where CONTINUED=1 Order by charge_code "



            loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)




            id = "customer_id"
            value = "company"
            Me.cbocuscredit.Items.Clear()
            strSQL = "Select customer_id,company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.TextBox1.Text & "%' or taxcode like '%" & Me.TextBox1.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocuscredit, strSQL, id, value)


            Me.cboitemcredit.Items.Clear()
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code from charge where CONTINUED=1 Order by charge_code "



            loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)

            Me.cmdcancel_credit_Click(sender, e)



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            mStatusCredit = "Normal"
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdCreditGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdCreditGrid.CellContentClick

    End Sub

    Private Sub Pha6nBo63ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Pha6nBo63ToolStripMenuItem.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            'kiểm tra xem Grid có dữ liệu không
            'allCus()
            'addluoicont()
            If Me.dgdCreditGrid.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim sqlexport, sqlimport As String
            Dim dsexport As New DataSet
            Dim dsimport As New DataSet
            Dim ref_da_phanbo As String = ""
            Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
            Approve = Me.dgdCreditGrid.Item("ApproveCredit", index).Value
            ' vitri = index
            Dim ie, ii As Integer

            If index >= 0 Then

                If mStatusCredit = "Normal" And Not Approve And UserRight("smnuref_credit", "Execute") Then



                    mCreditId = Me.dgdCreditGrid.Item("ref_creditid", index).Value.ToString
                    ' lay gia tri thogn so
                    Dim sql As String
                    Dim ds As New DataSet
                    sql = " select * from ref_credit left join customer on ref_credit.customerid=customer.customer_id left join charge on ref_credit.itemid=charge.charge_id where ref_creditID='" & mCreditId & "' and ref_credit.continued=1"

                    ds = ReadDataSet(sql)
                    If ds.Tables(0).Rows.Count > 0 Then
                        'lay so ref de tim trong hang xuat truoc

                        sqlexport = "select * from logistics where ref_phanbo ='" & ds.Tables(0).Rows(0).Item("ref").ToString & "' "
                        dsexport = ReadDataSet(sqlexport)
                        If dsexport.Tables(0).Rows.Count > 0 Then
                            ' co du lieu
                            For ie = 0 To dsexport.Tables(0).Rows.Count - 1
                                'Ung voi moi HBL ta them credit
                                strQuery = "Select * From logisticsfreight "
                                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                                With rs
                                    'If rs.EOF Then
                                    .AddNew()
                                    .Fields("Logisticsfreightid").Value = NewId()
                                    .Fields("Logisticsid").Value = getID(dsexport.Tables(0).Rows(ie).Item("blob_id").ToString)
                                    ' End If


                                    '-------------------------------container
                                    .Fields("customerid").Value = getID(ds.Tables(0).Rows(0).Item("customerid").ToString)
                                    .Fields("itemid").Value = getID(ds.Tables(0).Rows(0).Item("itemid").ToString)
                                    .Fields("currency").Value = ds.Tables(0).Rows(0).Item("currency").ToString
                                    .Fields("containertype").Value = ds.Tables(0).Rows(0).Item("containertype").ToString
                                    .Fields("unitprice").Value = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("unitprice").ToString) / CDbl(dsexport.Tables(0).Rows.Count), 2)
                                    .Fields("quantity").Value = ds.Tables(0).Rows(0).Item("quantity").ToString
                                    '.Fields("pricetruocthue").Value = Me.txtpricenotaxcredit.Text
                                    '.Fields("pricenotaxvnd").Value = Me.txtpricenotaxvndcredit.Text


                                    .Fields("taxprice").Value = ds.Tables(0).Rows(0).Item("taxprice").ToString
                                    '.Fields("pricethue").Value = Me.txtpricetaxcredit.Text
                                    .Fields("price").Value = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("price").ToString) / CDbl(dsexport.Tables(0).Rows.Count), 2)

                                    Try
                                        .Fields("note").Value = ds.Tables(0).Rows(0).Item("note").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        .Fields("os").Value = ds.Tables(0).Rows(0).Item("os").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        .Fields("paycheck").Value = ds.Tables(0).Rows(0).Item("paycheck").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        .Fields("dntt").Value = ds.Tables(0).Rows(0).Item("dntt").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        .Fields("daily").Value = ds.Tables(0).Rows(0).Item("daily").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        .Fields("ngay").Value = ds.Tables(0).Rows(0).Item("ngay").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        .Fields("ngayhoadon").Value = ds.Tables(0).Rows(0).Item("ngayhoadon").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        .Fields("tigia").Value = ds.Tables(0).Rows(0).Item("tigia").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        .Fields("debitcredit").Value = ds.Tables(0).Rows(0).Item("debitcredit").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        .Fields("showvnd").Value = ds.Tables(0).Rows(0).Item("showvnd").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        ref_da_phanbo += ds.Tables(0).Rows(0).Item("ref").ToString + "; "
                                    Catch ex As Exception

                                    End Try
                                    .Update()
                                End With
                                rs.Close()
                                '--------------------------------------

                            Next
                            DisplayMessage(True, "Đã phân bổ : " + dsexport.Tables(0).Rows.Count.ToString + " lô.!")
                            Try
                                strQuery = "select * from ref_credit left join customer on ref_credit.customerid=customer.customer_id left join charge on ref_credit.itemid=charge.charge_id where ref_creditID='" & mCreditId & "' and ref_credit.continued=1 "
                                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                                With rs
                                    If Not rs.EOF Then
                                        '.AddNew()

                                        .Fields("ref_da_phanbo").Value = ref_da_phanbo
                                        .Update()
                                        .Close()
                                    End If
                                End With
                            Catch ex As Exception

                            End Try



                        Else
                            DisplayMessage(True, "Bạn chưa gán Ref.phân bổ cho các lô hàng.!")
                        End If
                    Else
                        ' truong hop ko co outbound thi chuyen sang inbound' 
                        'lay so ref de tim trong hang xuat truoc

                        'sqlimport = "select * from inbound where ref ='" & ds.Tables(0).Rows(0).Item("ref").ToString & "' "
                        'dsimport = ReadDataSet(sqlimport)
                        'If dsimport.Tables(0).Rows.Count > 0 Then
                        '    ' co du lieu
                        '    For ie = 0 To dsimport.Tables(0).Rows.Count - 1
                        '        'Ung voi moi HBL ta them credit
                        '        strQuery = "Select * From inboundfreight "
                        '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        '        With rs
                        '            'If rs.EOF Then
                        '            .AddNew()
                        '            .Fields("inboundfreightID").Value = NewId()
                        '            .Fields("inboundID").Value = getID(dsimport.Tables(0).Rows(ie).Item("blib_id").ToString)
                        '            ' End If


                        '            '-------------------------------container
                        '            .Fields("customerid").Value = getID(ds.Tables(0).Rows(0).Item("customerid").ToString)
                        '            .Fields("itemid").Value = getID(ds.Tables(0).Rows(0).Item("itemid").ToString)
                        '            .Fields("currency").Value = ds.Tables(0).Rows(0).Item("currency").ToString
                        '            .Fields("containertype").Value = ds.Tables(0).Rows(0).Item("containertype").ToString
                        '            .Fields("unitprice").Value = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("unitprice").ToString) / CDbl(dsimport.Tables(0).Rows.Count), 2)
                        '            .Fields("quantity").Value = ds.Tables(0).Rows(0).Item("quantity").ToString
                        '            '.Fields("pricetruocthue").Value = Me.txtpricenotaxcredit.Text
                        '            '.Fields("pricenotaxvnd").Value = Me.txtpricenotaxvndcredit.Text


                        '            .Fields("taxprice").Value = ds.Tables(0).Rows(0).Item("taxprice").ToString
                        '            '.Fields("pricethue").Value = Me.txtpricetaxcredit.Text
                        '            .Fields("price").Value = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("price").ToString) / CDbl(dsimport.Tables(0).Rows.Count), 2)

                        '            Try
                        '                .Fields("note").Value = ds.Tables(0).Rows(0).Item("note").ToString
                        '            Catch ex As Exception

                        '            End Try

                        '            Try
                        '                .Fields("os").Value = ds.Tables(0).Rows(0).Item("os").ToString
                        '            Catch ex As Exception

                        '            End Try

                        '            Try
                        '                .Fields("paycheck").Value = ds.Tables(0).Rows(0).Item("paycheck").ToString
                        '            Catch ex As Exception

                        '            End Try

                        '            Try
                        '                .Fields("dntt").Value = ds.Tables(0).Rows(0).Item("dntt").ToString
                        '            Catch ex As Exception

                        '            End Try
                        '            Try
                        '                .Fields("daily").Value = ds.Tables(0).Rows(ie).Item("daily").ToString
                        '            Catch ex As Exception

                        '            End Try
                        '            Try
                        '                .Fields("ngay").Value = ds.Tables(0).Rows(0).Item("ngay").ToString
                        '            Catch ex As Exception

                        '            End Try
                        '            Try
                        '                .Fields("ngayhoadon").Value = ds.Tables(0).Rows(0).Item("ngayhoadon").ToString
                        '            Catch ex As Exception

                        '            End Try
                        '            Try
                        '                .Fields("tigia").Value = ds.Tables(0).Rows(0).Item("tigia").ToString
                        '            Catch ex As Exception

                        '            End Try
                        '            Try
                        '                .Fields("debitcredit").Value = ds.Tables(0).Rows(0).Item("debitcredit").ToString
                        '            Catch ex As Exception

                        '            End Try

                        '            Try
                        '                .Fields("showvnd").Value = ds.Tables(0).Rows(3).Item("showvnd").ToString
                        '            Catch ex As Exception

                        '            End Try

                        '            .Update()
                        '        End With
                        '        rs.Close()
                        '        '--------------------------------------

                        '    Next
                        '    DisplayMessage(True, "Đã phân bổ : " + dsimport.Tables(0).Rows.Count.ToString + " lô.!")
                        'End If
                    End If

                    '-----------------------------------

                    '  RefreshDataCreditgrid(index)
                    Me.Button2_Click(sender, e)

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class