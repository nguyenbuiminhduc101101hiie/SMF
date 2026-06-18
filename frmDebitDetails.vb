Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Windows.Forms
Public Class frmDebitDetails

    Inherits System.Windows.Forms.Form

    Dim rsShipperList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mTaxDetailId As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Dim gtaxInvoiceIDBack As String
    Const strCustomerTaxSelect As String = "SELECT debitId,debitdetailsID, " & _
    "STT,clucidat,soluong,dongia,exchangeRate,thanhtien,loaitiente, " & _
     " continued,userid,updatetime,approve,editable "


    Const strCustomerTaxOrder1 As String = _
           " ORDER BY STT  Desc "
    Const strCustomerTaxOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg, sql As String
        CheckData = True
        strMsg = ""

        Dim ds As New DataSet
        ' kiem tra xem taxinvoice co trung ko
        If mStatus = "Add" Then
            sql = " select STT from debitdetails where STT='" & Me.txtSTT.Text & "' and continued=1 and debitid= '" & gtaxInvoiceIDBack & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                DisplayMessage(True, "Số thứ tự đã có !")
                Return False
            End If
        End If

        If Len(Me.txtSTT.Text) = 0 Then
            'CheckData = False
            'strMsg = strMsg & "Xin kiểm tra lại số thứ tự!"
        End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdTaxDetail.Enabled = True
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtShipper.Text)
        If Me.txtShipper.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtShipper.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdTaxDetail)

        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Try


            Dim strQuery, strTaxDetailId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            If Me.txtSTT.Text = "" Then
                DisplayMessage(True, " Xin kiểm tra lại Số thứ tự!")
                ' Return
            End If
            If mStatus = "Edit" Then
                index = Me.dgdTaxDetail.CurrentRow.Index

            End If

            If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
                Try
                    '  copyHistory("taxdetail", "TaxdetailID", mTaxDetailId, "history")
                Catch ex As Exception

                End Try
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM debitdetails "
                strQuery = strQuery & "WHERE debitdetailsID = '" & mTaxDetailId & "' AND debitdetailsid <> '" & DefaultValue & "' and continued=1 "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("debitdetailsID").Value = NewId()
                        '' them moi rieng le thi no se ko thuoc freight_chage_ibob
                        .Fields("freight_charge_obib").Value = DefaultValue '"{" + UCase(Trim(Me.dgdCus.Item("freight_charge_obib", i).Value.ToString)) + "}"
                        .Fields("customeriddebit").Value = DefaultValue '"{" + UCase(Trim(Me.dgdCus.Item("customeriddebit", i).Value.ToString)) + "}"

                    End If



                    If gtaxInvoiceIDBack Like "*{*" Then
                        .Fields("debitID").Value = gtaxInvoiceIDBack
                    Else
                        .Fields("debitID").Value = "{" + gtaxInvoiceIDBack + "}"
                    End If


                    'strTaxDetailId = .Fields("TaxDetailID").Value
                    'If i = 0 Then
                    Try
                        .Fields("STT").Value = Me.txtSTT.Text
                    Catch ex As Exception
                        .Fields("STT").Value = 0
                    End Try

                    'Else
                    '    .Fields("STT").Value = i
                    'End If
                    .Fields("clucidat").Value = Trim(Me.txtKhoanmuc.Text)
                    Try
                        .Fields("itemid").Value = "{" + FindValueID(Me.txtKhoanmuc, Me.txtKhoanmuc.Text) + "}"

                    Catch ex As Exception

                    End Try
                    .Fields("items").Value = Trim(Me.txtKhoanmuc.Text)

                    Try
                        .Fields("quantity").Value = Trim(Me.txtsoluong.Text)
                    Catch ex As Exception
                        .Fields("quantity").Value = 0
                    End Try


                    .Fields("container_type").Value = Me.txtDVT.Text
                    Try
                        .Fields("unitPrice").Value = Me.txtdongia.Text
                    Catch ex As Exception
                        .Fields("unitPrice").Value = 0
                    End Try

                    .Fields("currency").Value = Me.cboTT.Text

                    Try
                        .Fields("pricebantruocthue").Value = Trim(Me.txtPrice.Text)
                    Catch ex As Exception
                        .Fields("pricebantruocthue").Value = 0
                    End Try
                    Try
                        .Fields("pricebantruocthue").Value = Trim(Me.txtPrice.Text)
                    Catch ex As Exception
                        .Fields("pricebantruocthue").Value = 0
                    End Try
                    Try
                        .Fields("taxpriceban").Value = Me.txtVAT.Text
                    Catch ex As Exception
                        .Fields("taxpriceban").Value = 0
                    End Try
                    Try
                        .Fields("taxpriceban").Value = Me.txtVAT.Text
                    Catch ex As Exception
                        .Fields("taxpriceban").Value = 0
                    End Try
                    Try
                        .Fields("priceban").Value = Me.txtthanhtienUSD.Text
                    Catch ex As Exception
                        .Fields("priceban").Value = 0
                    End Try
                    Try
                        .Fields("exchangeRate").Value = Trim(Me.txtExchangerate.Text)
                    Catch ex As Exception
                        .Fields("exchangeRate").Value = 0
                    End Try



                    .Update()
                End With
                rs.Close()
                Me.dgdTaxDetail.Enabled = True

                QueryShipper(mFilter)


            End If
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

        'Resume
    End Sub
    Sub QueryCharges()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "charge_id"
        value = "charge"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select charge_id,charge From charge where Continued=1 Order By charge "
        'If Me.cboCompany.Items.Count = 0 Then
        loadDataToObject(Me.txtKhoanmuc, strSQL, id, value)
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListShipper_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        'Me.txtVAT.Enabled = True
        mStatus = "Normal"
        blnUpdated = False
        mTaxDetailId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        ' khoi tai exchange=1
        If Me.txtExchangerate.Text = "" Then
            Me.txtExchangerate.Text = "1"
        End If

        SetDefaultGrid(Me.dgdTaxDetail, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        LoadComboFind(Me.cboFind, Me.dgdTaxDetail)

        QueryCharges()

        Me.cboFind.Text = objUserSetting.GetCParm("frmTaxDetail.cboFind", "SHIPPER")
        mFilter = objUserSetting.GetCParm("frmtaxDetail.mFilter")

        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If
        gtaxInvoiceIDBack = gSearchID
        ' lay serial va invoice tu taxinvoice
        Dim ds As New DataSet
        Dim sql As String = "select * from debit where debitid= '" & gSearchID & "'"
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then

            Me.txtSerialNO.Text = ds.Tables(0).Rows(0).Item("SerialNo").ToString
            Me.txtInvoiceNo.Text = ds.Tables(0).Rows(0).Item("InvoiceNo").ToString
        Else
            DisplayMessage(True, "Kiểm tra lại Invoice !")
        End If

        Me.QueryShipper()
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        reText("Normal")
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub frmListShipper_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed



        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryShipper(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryShipper = "select * "
        MakeQueryShipper = MakeQueryShipper & "  "
        MakeQueryShipper = MakeQueryShipper & " FROM debitdetails  "
        MakeQueryShipper = MakeQueryShipper & "WHERE (debitid = '" & gtaxInvoiceIDBack & "') "

        MakeQueryShipper = MakeQueryShipper & " and  ("
        MakeQueryShipper = MakeQueryShipper & " Continued = 1 "
        MakeQueryShipper = MakeQueryShipper & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryShipper = MakeQueryShipper & argCriteria
        End If

        'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
        If mStatus = "Add" Then
            MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder2
        End If
        '    
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    '==========Menu==========
    Public Function CodeShipper() As Integer
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim Temp As String = "S"
            Dim Seri As Integer
            Try
                Dim strSQL As String
                strSQL = "Select Shipper_CODE From Shipper Where Shipper_ID='" & DefaultValue & "'"
                Dim dtSer As New DataTable
                dtSer = ReadTable(strSQL)

                Seri = CDbl(dtSer.Rows(0).Item(0).ToString) + 1
                For i As Integer = Seri.ToString.Length To 6
                    Temp &= "0"
                Next
                Temp &= Seri
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try

            ''''cập nhật số seri torng DB
            strQuery = "select* from Shipper Where Shipper_ID='" & DefaultValue & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Shipper_Code").Value = Seri
            rs.Update()
            rs.Close()

            Me.txtSerialNO.Text = Temp 'cập nhật Seri tren text box Sau mỗi lần thêm
            'Me.cmdThem.Enabled = True
            'Me.txtSeriesNo.Text = GetSeriNo()
        Catch ex As Exception

        End Try
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

    Public Sub ApproveShipper()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdTaxDetail.CurrentRow.Index
        Dim strQueryShipperList As String
        If Not Me.dgdTaxDetail.Item("Editable", index).Value Or Not UserRight("frmTaxDetail", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))

        Else
            strQueryShipperList = "Select * from debitdetails where" + " debitdetailsID= '" & Me.dgdTaxDetail.Item("debitdetailsId", index).Value.ToString & "'"
            rsShipperList.Open(strQueryShipperList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsShipperList.Fields("Approve").Value
            rsShipperList.Update("Approve", Approve)
            rsShipperList.Close()
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position


        If Not IsNothing(Me.dgdTaxDetail.Item("Approve", index)) Then
            If Me.dgdTaxDetail.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdTaxDetail.Item("Editable", index)) Then
            If Not Me.dgdTaxDetail.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("smnuother", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Xóa số thứ tự : " & Me.dgdTaxDetail.Item("STT", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from debitdetails where" + " debitdetailsId= '" & Me.dgdTaxDetail.Item("debitdetailsid", index).Value.ToString & "'"
                rsShipperList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsShipperList.Fields("continued").Value = 0
                rsShipperList.Update()

                rsShipperList.Requery()

                rsShipperList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub



    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click

    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Tax Details (" + Me.txtSerialNO.Text + " - " + Me.txtInvoiceNo.Text + ")" + "  Lưu ý : VAT được tính trên Hóa đơn, không input trong Details"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Tax Details -> Edit. (" + Me.txtSerialNO.Text + " - " + Me.txtInvoiceNo.Text + ")" + "  Lưu ý : VAT được tính trên Hóa đơn, không input trong Details"
        ElseIf mStatus = "Add" Then
            Me.Text = "Tax Details -> Add. (" + Me.txtSerialNO.Text + " - " + Me.txtInvoiceNo.Text + ")" + "  Lưu ý : VAT được tính trên Hóa đơn, không input trong Details"
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

    '==========Query==========

    Public Sub QueryShipper(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryShipper()
        Else
            strQuery = MakeQueryShipper(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "ShipperList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdTaxDetail.DataSource = ds.Tables("ShipperList")
        If Me.dgdTaxDetail.Enabled = False Then
            Me.dgdTaxDetail.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default

        If Me.dgdTaxDetail.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        ''------------vị trí BM
        'If location > 0 And location <= Me.dgdTaxInvoice.Rows.Count And Me.dgdTaxInvoice.Rows.Count > 0 And mStatus = "Edit" Then
        '    Me.dgdTaxInvoice.Rows(location).Selected = True
        '    Me.dgdTaxInvoice.CurrentCell = Me.dgdTaxInvoice.Rows(location).Cells(1)
        'End If
        'if mstatus=""
        '--------------------
        InsertAutoNumberToGrid(Me.dgdTaxDetail)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed


        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(fraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(fraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.dgdTaxDetail.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            Me.dgdTaxDetail.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            Me.dgdTaxDetail.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        'fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = Me.dgdTaxDetail.Height + Me.dgdTaxDetail.Top '+ 100

        Me.txtShipper.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10



        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10
        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        cmdFind.Left = Me.txtShipper.Left + Me.txtShipper.Width + 10
        txtShipper.Width = Me.Width - 297

        Exit Sub
Err:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    Private Sub dgdShipper_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdTaxDetail.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdTaxDetail.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdTaxDetail.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdTaxDetail.Columns(ColIndex).Name = "Approve" And Me.dgdTaxDetail.CurrentCellAddress().Y = index Then
            Call ApproveShipper()
            QueryShipper(mFilter, , index)
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdShipper_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdTaxDetail.CellContentDoubleClick

    End Sub


    Private Sub dgdShipper_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdTaxDetail.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryShipper("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdTaxDetail)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdShipper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdTaxDetail.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdTaxDetail.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdTaxDetail.SelectedRows(i).Index)
                Next i
            End If

            QueryShipper()
        End If
    End Sub




    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
        If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
            Me.cboFind.SelectedIndex = 0
            Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
        End If
    End Sub




    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString


            Me.txtSTT.Text = Me.dgdTaxDetail.Item("stt", index).Value.ToString

            Me.txtKhoanmuc.Text = Me.dgdTaxDetail.Item("clucidat", index).Value.ToString
            Me.txtDVT.Text = Me.dgdTaxDetail.Item("Container_type", index).Value.ToString
            Me.txtsoluong.Text = Me.dgdTaxDetail.Item("quantity", index).Value.ToString
            Me.txtdongia.Text = Me.dgdTaxDetail.Item("unitprice", index).Value.ToString
            Me.cboTT.Text = Me.dgdTaxDetail.Item("currency", index).Value.ToString
            Me.txtVAT.Text = Me.dgdTaxDetail.Item("taxpriceban", index).Value.ToString
            If Me.dgdTaxDetail.Item("ExchangeRate", index).Value.ToString = "" Then
                Me.txtExchangerate.Text = 1 'Me.dgdTaxDetail.Item("ExchangeRate", index).Value.ToString
            Else
                Me.txtExchangerate.Text = Me.dgdTaxDetail.Item("ExchangeRate", index).Value.ToString
            End If

            Me.txtthanhtienUSD.Text = Me.dgdTaxDetail.Item("priceban", index).Value.ToString
            'If UCase(Me.cboTT.Text) = "USD" Then
            Try
                Me.txtthanhtienUSD.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text)) * CDbl(Me.txtVAT.Text) / 100

            Catch ex As Exception

            End Try
            Try
                Me.txtThanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100

            Catch ex As Exception

            End Try
            'Else

            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub



    Private Sub frmListShipper_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub

    'Private Sub smnuDisplayTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayTax.Checked = Not Me.smnuDisplayTax.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayPersonInCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayPersonInCharge.Checked = Not Me.smnuDisplayPersonInCharge.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("smnuother", "Add") Then
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mTaxDetailId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            ' xoa trang d kieu de them moi vao

            Me.txtSTT.Text = ""
            Me.txtKhoanmuc.Text = ""
            Me.txtsoluong.Text = ""
            Me.txtdongia.Text = ""
            Me.txtVAT.TabIndex = "0"
            Me.txtThanhtien.Text = "0"
            'Me.txtExchangerate.Text = ""

        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        Exit Sub
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdTaxDetail.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdTaxDetail, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnutaxinvoivedetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSelect.Click
        'If Me.dgdTaxDetail.SelectedRows.Count > 0 Then
        'Dim index As Integer = Me.dgdTaxDetail.CurrentRow.Index
        gSearchID = gtaxInvoiceIDBack
        gSForm = Me.Name

        SearchCombo()
        Me.Close()
        'End If
    End Sub

    Private Sub txtShipper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipper.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryShipper("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub ChangeDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeDetailToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Me.dgdTaxDetail.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdTaxDetail.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdTaxDetail.Item("Approve", index).Value
            EditTable = Me.dgdTaxDetail.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("smnuother", "Edit") Then
                Me.dgdTaxDetail.Height = 306
                Me.dgdTaxDetail.Enabled = False
                Me.txtVAT.Enabled = True
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mTaxDetailId = Me.dgdTaxDetail.Item("debitdetailsID", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub DelateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelateToolStripMenuItem.Click
        Dim selectedRowCount As Integer = _
       Me.dgdTaxDetail.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdTaxDetail.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryShipper(" " & mFilter)
    End Sub







    Private Sub txtVAT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSTT.KeyPress
        If e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = "0"
        End If

    End Sub

    Private Sub txtdongia_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdongia.Leave

    End Sub


    Private Sub txtdongia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdongia.TextChanged
        Try
            Me.txtPrice.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text)
            'Me.txtthanhtienUSD.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text)) * CDbl(Me.txtVAT.Text) / 100
            'Me.txtThanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboTT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTT.Leave

        If Me.txtsoluong.Text = "" Or Me.txtdongia.Text = "" Or Me.txtExchangerate.Text = "" Then
            Return
        End If
        If CDbl(Me.txtsoluong.Text) >= 1 And Me.txtdongia.Text <> "" Then

            Me.txtThanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100

            'Me.txtThanhtien.Text = CStr(CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text))

            Me.txtTienchu.Text = VNumberToWord(CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100, "VND")


        End If


    End Sub

    Private Sub cboTT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTT.SelectedIndexChanged

    End Sub

    Private Sub txtThanhtien_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtThanhtien.TextChanged
        Me.txtTienchu.Text = VNumberToWord(CDbl(Me.txtThanhtien.Text), "VND")
    End Sub

    Private Sub txtSTT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSTT.Leave
        'Dim textK As String = "*" + Me.txtKhoanmuc.Text + "*"

        'If mStatus = "Add" Then
        '    Me.txtKhoanmuc.Text = "B/L: " + frmTaxInvoice.BillnumberIN + ". "
        'End If
    End Sub

    Private Sub txtSTT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSTT.TextChanged
        'Dim textK As String = "*" + Me.txtKhoanmuc.Text + "*"

        'If mStatus = "Add" Then
        '    Me.txtKhoanmuc.Text = "B/L: " + frmTaxInvoice.BillnumberIN + ". "
        'End If
    End Sub

    Private Sub fraUpdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.Enter

    End Sub

    Private Sub txtsoluong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsoluong.TextChanged
        Try
            Me.txtthanhtienUSD.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text)) * CDbl(Me.txtVAT.Text) / 100
            Me.txtThanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100
            Try
                Me.txtPrice.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtExchangerate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExchangerate.TextChanged

    End Sub

    Private Sub txtVAT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVAT.TextChanged

        'Try
        '    Me.txtthanhtienUSD.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text)) * CDbl(Me.txtVAT.Text) / 100
        '    Me.txtThanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub txtPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice.TextChanged
        Try
            Me.txtthanhtienUSD.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text)) * CDbl(Me.txtVAT.Text) / 100
            Me.txtThanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text) + (CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) * CDbl(Me.txtExchangerate.Text)) * CDbl(Me.txtVAT.Text) / 100

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' co so hoa don ta lay toan bo
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outboundfreight where  ngayhoadon='" & Me.txtInvoiceNo.Text.Trim & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count <= 0 Then
                sql = "select * from inboundfreight  where ngayhoadon='" & Me.txtInvoiceNo.Text.Trim & "'"
                ds = ReadDataSet(sql)
            End If

            If ds.Tables(0).Rows.Count <= 0 Then
                sql = "select * from logisticsfreight  where  ngayhoadon='" & Me.txtInvoiceNo.Text.Trim & "'"
                ds = ReadDataSet(sql)

            End If
            Dim i As Integer
            Dim dg, sl, thue, tt, tg, tientruocthue, tienthue As Double
            dg = 0
            thue = 0
            tt = 0
            tientruocthue = 0
            tienthue = 0
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dg = CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString)
                    tg = CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
                    sl = CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString)
                    thue = CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString)

                    tientruocthue += dg * sl * tg
                    'tienthue += tientruocthue * thue / 100

                    ' tt += tientruocthue ' tienthue
                Next
            End If
            Me.txtsoluong.Text = "1"
            Me.txtdongia.Text = FormatNumber(tientruocthue.ToString, 2)
            Me.txtPrice.Text = FormatNumber(tientruocthue, 2)
            Me.txtVAT.Text = thue
            Me.txtthanhtienUSD.Text = FormatNumber(tientruocthue + (tientruocthue * thue / 100), 2)
            Me.txtThanhtien.Text = FormatNumber(tientruocthue + (tientruocthue * thue / 100), 2)
        Catch ex As Exception

        End Try
    End Sub
End Class