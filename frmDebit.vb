Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Windows.Forms
Public Class frmDebit
    Inherits System.Windows.Forms.Form
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer
    Dim rsShipperList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mTaxInvoiceId As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Public BillnumberIN As String
    Const strCustomerTaxSelect As String = "SELECT debitid, " & _
    "debit.customer_id, " & _
    "EnglishName, " & _
    "Address , " & _
    "TaxCode,Exchange, " & _
    "serialNo,billnumber,InvoiceNo, VAT,VATShow,[Dateinvoice],ref,chungtu,MethodPayment,directorSign,customerSign ,huy,lydohuy, " & _
 " debit.approve,debit.userid,debit.updatetime "


    Const strCustomerTaxOrder1 As String = _
           " ORDER BY SerialNo  Desc "
    Const strCustomerTaxOrder2 As String = _
        " ORDER BY debit.UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg, sql As String
        CheckData = True
        strMsg = ""
        Dim strtaxinvoiceId As String
        Dim ds As New DataSet
        ' kiem tra xem taxinvoice co trung ko
        If mStatus = "Add" Then
            sql = " select invoiceno from debit where invoiceno='" & Me.txtInvoiceNo.Text & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                DisplayMessage(True, "Số hóa đơn đã có !")
                'Return False
            End If
        End If

        If mStatus = "Add" Then
            strtaxinvoiceId = DefaultValue
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
        Me.dgdCus.Enabled = True
        reText(mStatus)
        Me.dgdTaxInvoice.Enabled = True
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub



    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Try


            Dim strQuery, strTaxInvoiceId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            If Me.txtVAT.Text = "" Then
                DisplayMessage(True, " Xin kiểm tra lại Thuế VAT!")
                Me.txtVAT.Focus()
                Return
            End If
            If Me.txtVATShow.Text = "" Then
                DisplayMessage(True, " Xin kiểm tra lại hiển thị Thuế VAT!")
                Me.txtVATShow.Focus()
                Return
            End If
            If Me.txtInvoiceNo.Text = "" Then
                DisplayMessage(True, " Xin kiểm tra lại số Hóa đơn!")
                Exit Sub
            End If
            If mStatus = "Edit" Then
                index = Me.dgdTaxInvoice.CurrentRow.Index

            End If
         

            If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
                Try
                    '  copyHistory("taxinvoice", "TaxInvoiceID", mTaxInvoiceId, "history")
                Catch ex As Exception

                End Try
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM debit "
                strQuery = strQuery & "WHERE debitID = '" & mTaxInvoiceId & "' AND debitID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("debitID").Value = NewId()
                    End If
                    strTaxInvoiceId = .Fields("debitID").Value
                    ' them branch
                    Try
                        .Fields("branch").Value = gBranch
                    Catch ex As Exception
                        DisplayMessage(True, "Branch cần được thêm vào Table Booking.")
                    End Try
                    '==============================================
                    .Fields("Customer_ID").Value = "{" + FindValueID(Me.cboCustomer, Me.cboCustomer.Text) + "}"
                    Try
                        .Fields("taxcode_").Value = Trim(Me.txtTax.Text)
                    Catch ex As Exception

                    End Try
                    Try
                        .Fields("tkno").Value = Trim(Me.txtTKNo.Text)
                        .Fields("tkco").Value = Trim(Me.txtTKco.Text)
                    Catch ex As Exception

                    End Try

                    ' .Fields("serialno").Value = Trim(Me.txtSerialNO.Text)
                    .Fields("invoiceno").Value = Trim(Me.txtInvoiceNo.Text)
                    .Fields("dateinvoice").Value = Trim(Me.dtpDate.Value.Date)
                    .Fields("methodpayment").Value = Me.cbomethodpayment.Text
                    Try
                        .Fields("vesselvoy").Value = Trim(Me.txtvesselvoy.Text)
                    Catch ex As Exception

                    End Try
                    Try
                        ' ghi bo phan
                        '.Fields("inbound").Value = Me.RadioIn.Checked
                        '.Fields("outbound").Value = Me.radioOut.Checked
                        '.Fields("logistics").Value = Me.chkLogistics.Checked
                        '.Fields("chuyenUSD").Value = Me.chkchuyenusd.Checked
                        Try
                            .Fields("tigiachuyen").Value = Trim(Me.txttigiachuyen.Text)
                        Catch ex As Exception
                            .Fields("tigiachuyen").Value = 0
                        End Try

                        .Fields("ref").Value = Trim(Me.txtref.Text)

                        .Fields("buss_place").Value = Trim(Me.txthancongno.Text)

                    Catch ex As Exception

                    End Try
                    .Fields("directorSign").Value = Trim(Me.txtDirSign.Text)
                    .Fields("customerSign").Value = Trim(Me.txtCusSign.Text)
                    .Fields("VAT").Value = Trim(Me.txtVAT.Text)
                    .Fields("VATshow").Value = Trim(Me.txtVATShow.Text)
                    .Fields("chungtu").Value = Trim(Me.txtChungtu.Text)
                    .Fields("Exchange").Value = Trim(Me.txtExchange.Text)
                    .Fields("billnumber").Value = Trim(Me.cbobillnumber.Text)
                    .Fields("thanhtoan").Value = Me.chkpay.Checked
                    .Fields("chiho").Value = Me.chkchiho.Checked
                    'them rieng cho SITC
                    '.Fields("int_id").Value = Trim(Me.cboINT_ID.Text)
                    '.Fields("vender_id").Value = Trim(Me.cboVender_ID.Text)
                    '.Fields("dep_cde").Value = Trim(Me.cboDEP_CDE.Text)
                    '.Fields("pre_cde").Value = Trim(Me.cboFre_CDE.Text)
                    '.Fields("dmbtr").Value = Trim(Me.cboDMBTR.Text)
                    '.Fields("xcitc").Value = Trim(Me.cboXSITC.Text)
                    '.Fields("ieflag").Value = Trim(Me.cboIE_flag.Text)
                    '.Fields("bl_cde").Value = Trim(Me.cboBL_CDE.Text)
                    '.Fields("car_bl_cde").Value = Trim(Me.cboCar_BL_CDE.Text)
                    '.Fields("im_cmpcde").Value = Trim(Me.cboIM_cmpcde.Text)
                    '.Fields("bus_type").Value = Trim(Me.cboBus_type.Text)
                    '.Fields("bus_codea").Value = Trim(Me.cboBus_CodeA.Text)
                    '.Fields("bus_codeb").Value = Trim(Me.cboBus_CodeB.Text)
                    '.Fields("reg_cde").Value = Trim(Me.cboReg_CDE.Text)
                    '.Fields("bus_date").Value = Trim(Me.cboBus_Date.Text)
                    ' .Fields("buss_place").Value = Trim(Me.cbobus_Place.Text)

                    '.Fields("PORT_CDE").Value = Trim(Me.cboPort_cde.Text)

                    .Fields("salecode").Value = Trim(Me.txtsale.Text)

                    '------------------------------------------
                    Try
                        .Fields("masterbill").Value = masterbill
                    Catch ex As Exception

                    End Try
                    ' luu vao so hoa don
                    'setOptionValue("frmtaxinvoice", "taxinvoice", "taxinvoice", "taxinvoiceSGN", "C", Me.txtInvoiceNo.Text.Replace("SGN", "").Replace("HPH", ""))
                    .Update()
                End With
                rs.Close()
                Me.dgdTaxInvoice.Enabled = True
                If mStatus = "Edit" Then
                    QueryShipper(" and SerialNo='" & Me.txtInvoiceNo.Text.Trim & "' ", , index)
                Else
                    QueryShipper()
                End If

            End If
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
            If Me.cbobillnumber.Text <> "" Then


                Dim i As Integer
                Dim strMesg As String = "Bạn có muốn thêm chi tiết vào Tax Invoice tự động từ Freight & Charges.!"
                If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    'them so lieu vao
                    ' tuy vao so dong
                    '----------------------------------------------------------------------
                    ' lay bl_id
                    'co strTaxInvoiceId
                    'stt= lay theo vong for
                    For i = 0 To Me.dgdCus.Rows.Count - 1
                        If Me.dgdCus.Item("checkprint", i).Value = True Then
                            ' ta bat dau them vao detail
                            strQuery = "SELECT top 1 * "
                            strQuery = strQuery & "FROM debitdetails "
                            strQuery = strQuery & " "
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                .AddNew()
                                .Fields("debitdetailsID").Value = NewId()


                                .Fields("debitID").Value = strTaxInvoiceId


                                'strTaxDetailId = .Fields("TaxDetailID").Value
                                'If i = 0 Then
                                .Fields("STT").Value = i + 1
                                'Else
                                '    .Fields("STT").Value = i
                                'End If
                                .Fields("freight_charge_obib").Value = "{" + Trim(Me.dgdCus.Item("blib_id", i).Value.ToString) + "}" '  lay BLIB_ID
                                .Fields("customeriddebit").Value = "{" + Trim(Me.dgdCus.Item("CustomerIDdebit", i).Value.ToString) + "}"
                                .Fields("clucidat").Value = Trim(Me.dgdCus.Item("itemsdebit", i).Value)
                                .Fields("itemid").Value = "{" + Trim(Me.dgdCus.Item("itemid", i).Value) + "}"
                                .Fields("items").Value = Trim(Me.dgdCus.Item("itemsdebit", i).Value)
                                '-------------------
                                .Fields("quantity").Value = CDbl(Me.dgdCus.Item("soluong", i).Value)

                                .Fields("unitPrice").Value = FormatNumber(Me.dgdCus.Item("unitprice", i).Value, 0)
                                '----------------------
                                .Fields("container_type").Value = Me.dgdCus.Item("CONTAINER_TYPEdebit", i).Value

                                .Fields("currency").Value = "VND" 'Me.dgdCus.Item("currencydebit", i).Value

                                .Fields("exchangeRate").Value = "1" 'Me.dgdCus.Item("exchangeRate", i).Value


                                .Fields("pricebantruocthue").Value = CDbl(Me.dgdCus.Item("thanhtien", i).Value)
                                .Fields("taxpriceban").Value = Me.dgdCus.Item("thue", i).Value




                                'If UCase(Me.dgdCus.Item("currencydebit", i).Value.ToString) = "USD" Then
                                '    '.Fields("thanhtien").Value = CDbl(Me.dgdCus.Item("pricedebit", i).Value) * CDbl(Me.txtExchange.Text.ToString)
                                '    .Fields("exchangeRate").Value = UCase(Trim(Me.txtExchange.Text))
                                'Else
                                '    '.Fields("thanhtien").Value = CDbl(Me.dgdCus.Item("pricedebit", i).Value)
                                '    .Fields("exchangeRate").Value = 1
                                'End If
                                'If UCase(Me.dgdCus.Item("currencydebit", i).Value.ToString) = "USD" Then
                                '    .Fields("priceban").Value = FormatNumber(CDbl(Me.dgdCus.Item("pricedebit", i).Value), 2) '* CDbl(Me.txtExchange.Text), 2)

                                'Else
                                '    .Fields("priceban").Value = FormatNumber(CDbl(Me.dgdCus.Item("pricedebit", i).Value), 2)

                                'End If
                                .Fields("priceban").Value = FormatNumber(CDbl(Me.dgdCus.Item("tong", i).Value), 2)

                                ' .Fields("loaitiente").Value = Me.dgdCus.Item("currency", i).Value.ToString
                                .Update()
                            End With
                            rs.Close()
                        End If
                    Next
                    '------------------------------------------------------------------------
                End If
            End If
            If mStatus = "Edit" Then
                QueryShipper(" and SerialNo='" & Me.txtInvoiceNo.Text.Trim & "' ", , index)
            Else
                QueryShipper()
            End If
            tongtaxinvoice()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        'Resume
    End Sub
    Public Sub getbill()
        Try

        Catch ex As Exception

        End Try
    End Sub
    Sub QueryBillnumber()
        Try

            Dim id, value, strSQL As String
            Me.cbobillnumber.Items.Clear()
            'If Me.radioOut.Checked = True Then


            '    'id = "bl_id"
            '    'value = "bl_no"
            '    'strSQL = "Select bl_id,  bl_no From billoflading  where continued=1 Order By bl_no "
            '    'loadDataToObject_(Me.cbobillnumber, strSQL, id, value)
            '    id = "blob_id"
            '    value = "mblmawb"
            '    strSQL = "Select blob_id, mblmawb From outbound  where continued=1 and branch like '%" & gBranch & "%' Order By mblmawb "
            '    loadDataToObject_(Me.cbobillnumber, strSQL, id, value)
            'ElseIf Me.RadioIn.Checked = True Then


            '    id = "blib_id"
            '    value = "hbl"
            '    strSQL = "Select blib_id,  hbl From inbound  where continued=1 and branch like '%" & gBranch & "%' Order By hbl "
            '    loadDataToObject_(Me.cbobillnumber, strSQL, id, value)
            'Else
            '    id = "blob_id"
            '    value = "ref"
            '    strSQL = "Select blob_id,  ref From logistics  where continued=1 and branch like '%" & gBranch & "%' Order By ref "
            '    loadDataToObject_(Me.cbobillnumber, strSQL, id, value)
            'End If
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim i As Integer
            'Dim strSQL As String = "Select bl_no From billoflading where Continued=1 Order By bl_no "
            'Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            'Dim dt As New DataTable
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            'Adapter.Fill(dt)

            '' lay so chuyen arrival
            'Dim oItems As PDSAListItemString
            'Me.cbobillnumber.Items.Clear()
            'oItems = New PDSAListItemString
            '' for lap het dt
            'For i = 0 To dt.Rows.Count - 1
            '    oItems.Value = IIf(gLang = "E", dt.Rows(i).Item("bl_no").ToString, dt.Rows(i).Item("bl_no").ToString)
            '    Me.cbobillnumber.Items.Add(oItems)
            'Next
            ''them so chuyen den
            'Dim strSQL1 As String = "Select blh_no From billoflading_house where Continued=1 Order By blh_no "
            'Dim dsDen As New DataSet
            'dsDen = ReadDataSet(strSQL1)
            'For i = 0 To dsDen.Tables(0).Rows.Count - 1
            '    oItems.Value = IIf(gLang = "E", dsDen.Tables(0).Rows(i).Item("blh_no").ToString, dsDen.Tables(0).Rows(i).Item("blh_no").ToString)
            '    Me.cbobillnumber.Items.Add(oItems)
            'Next

            '--------------------------
            'Me.txtVoyNo.DisplayMember = "VoyageNoonArrival"
            'Me.txtVoyNo.ValueMember = "VoyageNoonArrival"
            'Me.txtVoyNo.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryCustomer()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        Me.cboCustomer.Items.Clear()
        'id = "agency_id"
        'value = "agencyname"
        'strSQL = "Select agency_id,  agencyname From agency  where continued=1 Order By agencyname"
        'loadDataToObject_(Me.cboCustomer, strSQL, id, value)

        id = "Customer_id"
        value = "Company"
        strSQL = "Select Customer_id,  taxcode + '-' + company as company From customer  where continued=1 Order By company"
        loadDataToObject_(Me.cboCustomer, strSQL, id, value)

        'id = "Shippinglineid"
        'value = "Shippingline"
        'strSQL = "Select Shippinglineid,  Shippingline From Shippingline  where continued=1 Order By Shippingline "
        'loadDataToObject_(Me.cboCustomer, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListShipper_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        Me.groupThucthu.Visible = False
        Me.txtDirSign.Text = getUserName(strUserId)
        mTaxInvoiceId = DefaultValue
        Me.txttimBill.ReadOnly = False
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.GroupBox4.Visible = False
        Me.fraUpdate.Visible = False
        Me.txtVAT.Enabled = True
        Me.txtVAT.ReadOnly = False
        Me.txtVATShow.ReadOnly = False
        SetDefaultGrid(Me.dgdTaxInvoice, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        ' LoadComboFind(Me.cboFind, Me.dgdTaxInvoice)
        QueryCustomer()
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE SHIPPER", "CODE SHIPPER")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "SHIPPER", "SHIPPER")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "TAX", "TAX")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "E-MAIL", "E-MAIL")
        'Me.cboFind.Items.Add(oItems)
        QueryBillnumber()
        ' Me.cboFind.Text = objUserSetting.GetCParm("frmListShipper.cboFind", "SHIPPER")
        'mFilter = objUserSetting.GetCParm("frmListShipper.mFilter")
        'Me.txtSerialNO.Text = objUserSetting.GetCParm("frmListShipper.txtCODE")
        'Me.TxtName.Text = objUserSetting.GetCParm("frmListShipper.TxtName")
        'Me.txtName1.Text = objUserSetting.GetCParm("frmListShipper.txtNAME1")
        'Me.txtName2.Text = objUserSetting.GetCParm("frmListShipper.txtNAME2")
        'Me.txtName3.Text = objUserSetting.GetCParm("frmListShipper.txtNAME3")
        'Me.txtName4.Text = objUserSetting.GetCParm("frmListShipper.txtNAME4")
        'Me.txtInvoiceNo.Text = objUserSetting.GetCParm("frmListShipper.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmListShipper.txtWebsite")
        'Me.txtAddress.Text = objUserSetting.GetCParm("frmListShipper.txtEmail")
        'Me.txtCusSigned.Text = objUserSetting.GetCParm("frmListShipper.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmListShipper.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmListShipper.txtPERSONINCHARGE")

        'If Me.txtShipper.Text <> "" Then
        '    'QueryShipper("AND (SHIPPER_1 LIKE '%" & Me.txtShipper.Text & "%' OR SHIPPER_2 LIKE '%" & Me.txtShipper.Text & "%'  OR SHIPPER_3 LIKE '%" & Me.txtShipper.Text & "%' OR SHIPPER_4 LIKE '%" & Me.txtShipper.Text & "%' OR SHIPPER_5 LIKE '%" & Me.txtShipper.Text & "%' OR SHIPPER_6 LIKE '%" & Me.txtShipper.Text & "%') " & mFilter)
        'Else
        '    QueryShipper(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmListShipper.smnuDisplayCode")
        'Me.smnuDisplayNumOfTransaction.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayNumOfTransaction")
        'Me.smnuDisplayEmail.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayEmail")
        'Me.smnuDisplayWebsite.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayWebsite")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayaPPROVE")
        'Me.smnuDisplayRemarks.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayREMARKS")
        'Me.smnuDisplayTax.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayTax")
        'Me.smnuDisplayPersonInCharge.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplaYPERSONINCHARGE")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListShipper.smnuDisplayUpdateTime")
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
        Dim id, value, strSQL As String
        id = "tablename"
        value = "viewername"
        Me.cboIOL.Items.Clear()


        strSQL = "Select tablename,viewername From listdept order by viewername "
        loadDataToObject(Me.cboIOL, strSQL, id, value)
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
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmListShipper.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListShipper.txtSHIPPER", Me.txtShipper.Text)
        'objUserSetting.SetCParm("frmListShipper.txtCODE", Me.txtSerialNO.Text)
        'objUserSetting.SetCParm("frmListShipper.txtNAME", Me.TxtName.Text)
        'objUserSetting.SetCParm("frmListShipper.txtNAME1", Me.txtName1.Text)
        'objUserSetting.SetCParm("frmListShipper.txtNAME2", Me.txtName2.Text)
        'objUserSetting.SetCParm("frmListShipper.txtNAME3", Me.txtName3.Text)
        'objUserSetting.SetCParm("frmListShipper.txtNAME4", Me.txtName4.Text)
        'objUserSetting.SetCParm("frmListShipper.txtNAME5", Me.txtInvoiceNo.Text)
        'objUserSetting.SetCParm("frmListSHIPPER.mFilter", mFilter)

        'objUserSetting.SetCParm("frmListShipper.txtTAX", Me.txtTax.Text)
        'objUserSetting.SetCParm("frmListShipper.txtEMAIL", Me.txtAddress.Text)
        'objUserSetting.SetCParm("frmListShipper.txtWEBSITE", Me.txtCusSigned.Text)
        'objUserSetting.SetCParm("frmListShipper.txtREMARKS", Me.txtRemarks.Text)
        'objUserSetting.SetCParm("frmListShipper.txtPERSONINCHARGE", Me.txtPersonInCharge.Text)





        'objUserSetting.SetBParm("frmListShipper.smnuDisplayName", Me.smnuDisplayName.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayCode", Me.smnuDisplayCode.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayNumOfTransaction", Me.smnuDisplayNumOfTransaction.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayEmail", Me.smnuDisplayEmail.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayWebsite", Me.smnuDisplayWebsite.Checked)

        'objUserSetting.SetBParm("frmListShipper.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayRemarks", Me.smnuDisplayRemarks.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayTax", Me.smnuDisplayTax.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayPersonInCharge", Me.smnuDisplayPersonInCharge.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListShipper.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)

        'Me.cmdCancel_Click(eventSender, eventArgs)

        gSComboBillTaxInvoice = ""

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryShipper(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryShipper = strCustomerTaxSelect
        MakeQueryShipper = MakeQueryShipper & ",tkno,tkco,tk311,tk511,salecode,inbound,outbound,logistics,thucthu,ngaythucthu,chuyenUSD,(SELECT  top 1 clucidat  FROM debitdetails  WHERE debitdetails.debitId = debit.debitid and continued=1 ) as details, (SELECT count(*) FROM debitdetails  WHERE debitdetails.debitId = debit.debitid and continued=1 ) AS Rowno "

        MakeQueryShipper = MakeQueryShipper & ", (select sum(pricebantruocthue) from debitdetails where debitdetails.debitId = debit.debitid and continued=1 ) as thanhtiensauthue,thanhtoan,chiho , vesselvoy FROM debit left join customer on debit.customer_id=customer.customer_id "

        ' MakeQueryShipper = MakeQueryShipper & ", (select sum(pricebantruocthue+(pricebantruocthue*taxpriceban/100)) from taxdetail where taxdetail.taxinvoiceId = taxinvoice.taxinvoiceid and continued=1 ) as thanhtiensauthue,thanhtoan,chiho , vesselvoy FROM taxinvoice left join customer on taxinvoice.customer_id=customer.customer_id "

        MakeQueryShipper = MakeQueryShipper & " WHERE (debitid = '" & DefaultValue & "') "

        MakeQueryShipper = MakeQueryShipper & "OR ("
        MakeQueryShipper = MakeQueryShipper & " debit.Continued = 1 "
        MakeQueryShipper = MakeQueryShipper & ") and (debit.branch like '%" & gBranch & "%') and customer.continued=1 "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryShipper = MakeQueryShipper & argCriteria
        End If

        'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
        'If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
        MakeQueryShipper = MakeQueryShipper & " order by invoiceno desc "
        'End If
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
                strSQL = "Select count(*) From debit "
                Dim dtSer As New DataTable
                dtSer = ReadTable(strSQL)

                Seri = CDbl(dtSer.Rows(0).Item(0).ToString) + 1
                CodeShipper = Seri
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try



        Catch ex As Exception

        End Try
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

    Public Sub ApproveShipper()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdTaxInvoice.CurrentRow.Index
        Dim strQueryShipperList As String
        If Not UserRight("smnuother", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))

        Else
            strQueryShipperList = "Select * from debit where" + " debitid= '" & Me.dgdTaxInvoice.Item("debitid", index).Value.ToString & "'"
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
        Dim cmd As New ADODB.Command
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        strQuery = "Select count(*) cnt from debitdetails WHERE debitid = '" & Me.dgdTaxInvoice.Item("debitid", index).Value.ToString & "'  "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)

        rs.Close()
        strQuery = "Select * from debit WHERE debitid = '" & Me.dgdTaxInvoice.Item("debitid", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, "Sorry, The Tax invoice can not be removed.")
            Exit Sub
        End If
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Tax invoice can not be removed. There are transactions that relate to detail.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdTaxInvoice.Item("Approve", index)) Then
            If Me.dgdTaxInvoice.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        'If Not IsNothing(Me.dgdTaxInvoice.Item("Editable", index)) Then
        '    If Not Me.dgdTaxInvoice.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("smnuother", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the debit: " & Me.dgdTaxInvoice.Item("serialNo", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from taxinvoice where" + " taxinvoiceId= '" & Me.dgdTaxInvoice.Item("debitID", index).Value.ToString & "'"
                'rsShipperList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsShipperList.Fields("continued").Value = 0
                'rsShipperList.Update()
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from debit where debitId= '" & Me.dgdTaxInvoice.Item("debitid", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                ' rsShipperList.Requery()

                'rsShipperList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub


    Function checkSumTacDetailPhieuthu(ByVal cusId As String, ByVal taxinvoiceId As String) As Boolean
        ' truyen vao cusid va billnumber tu taxdetails
        ' sum lai thanhtien 
        Dim sql As String
        Dim dssumTaxdetail As New DataSet
        Dim TaxdetailTong As Double
        sql = "select * from debitdetails where debitid= '" & taxinvoiceId & "' and continued=1 "

    End Function
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click

    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Tax invoice "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Tax invoice -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Tax invoice -> Add."
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
        Me.dgdTaxInvoice.DataSource = ds.Tables("ShipperList")
        If Me.dgdTaxInvoice.Enabled = False Then
            Me.dgdTaxInvoice.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default

        If Me.dgdTaxInvoice.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        ''------------vị trí BM
        'If location > 0 And location <= Me.dgdTaxInvoice.Rows.Count And Me.dgdTaxInvoice.Rows.Count > 0 And mStatus = "Edit" Then
        '    Me.dgdTaxInvoice.Rows(location).Selected = True
        '    Me.dgdTaxInvoice.CurrentCell = Me.dgdTaxInvoice.Rows(location).Cells(1)
        'End If
        'if mstatus=""
        '--------------------
        Dim i As Integer
        Dim texts() As String



        For i = 0 To Me.dgdTaxInvoice.RowCount - 1
            If Me.dgdTaxInvoice.Item("details", i).Value.ToString <> "" Then
                texts = Me.dgdTaxInvoice.Item("details", i).Value.ToString.Split(".")
                If texts.Length > 1 Then
                    Me.dgdTaxInvoice.Item("details", i).Value = texts(1)
                Else

                End If

            End If
            If UCase(Me.dgdTaxInvoice.Item("huy", i).Value.ToString) = "TRUE" Then
                Me.dgdTaxInvoice.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                Me.dgdTaxInvoice.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Me.dgdTaxInvoice.Rows(i).DefaultCellStyle.SelectionForeColor = Color.Blue
            End If
        Next
        InsertAutoNumberToGrid(Me.dgdTaxInvoice)
        tongtaxinvoice()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    Public Sub queryTuDen()
        Try
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim ds As New DataSet
            '----------------
            Dim MakeQueryShipper As String

            MakeQueryShipper = strCustomerTaxSelect
            MakeQueryShipper = MakeQueryShipper & ",tkno,tkco,tk311,tk511,salecode,inbound,outbound,logistics,thucthu,ngaythucthu,chuyenUSD,(SELECT  top 1 clucidat  FROM debitdetails  WHERE debitdetails.debitId = debit.debitid and continued=1 ) as details, (SELECT count(*) FROM debitdetails  WHERE debitdetails.debitId = debit.debitid and continued=1 ) AS Rowno "
            MakeQueryShipper = MakeQueryShipper & ", (select sum(pricebantruocthue) from debitdetails where debitdetails.debitId = debit.debitid and continued=1 ) as thanhtiensauthue,thanhtoan,chiho , vesselvoy FROM debit left join customer on debit.customer_id=customer.customer_id "
            MakeQueryShipper = MakeQueryShipper & "WHERE (debitid = '" & DefaultValue & "') "

            MakeQueryShipper = MakeQueryShipper & "OR ("
            MakeQueryShipper = MakeQueryShipper & " debit.Continued = 1 "
            MakeQueryShipper = MakeQueryShipper & ") and (convert(datetime,dateinvoice) between '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "') and ( debit.branch like '%" & gBranch & "%' )order by invoiceno desc"

            Dim CmdSelect As New SqlClient.SqlCommand(MakeQueryShipper, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Con.Open()
            Adapter.Fill(ds, "ShipperList")
            oTable = ds.Tables(0)
            'hien thi ra grid 
            Me.dgdTaxInvoice.DataSource = ds.Tables("ShipperList")
            If Me.dgdTaxInvoice.Enabled = False Then
                Me.dgdTaxInvoice.Enabled = True
            End If

            Me.Cursor = System.Windows.Forms.Cursors.Default

            If Me.dgdTaxInvoice.RowCount() = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            End If
            ''------------vị trí BM
            'If location > 0 And location <= Me.dgdTaxInvoice.Rows.Count And Me.dgdTaxInvoice.Rows.Count > 0 And mStatus = "Edit" Then
            '    Me.dgdTaxInvoice.Rows(location).Selected = True
            '    Me.dgdTaxInvoice.CurrentCell = Me.dgdTaxInvoice.Rows(location).Cells(1)
            'End If
            'if mstatus=""
            '--------------------
            Dim i As Integer
            Dim texts() As String



            For i = 0 To Me.dgdTaxInvoice.RowCount - 1
                If Me.dgdTaxInvoice.Item("details", i).Value.ToString <> "" Then
                    texts = Me.dgdTaxInvoice.Item("details", i).Value.ToString.Split(".")
                    If texts.Length > 1 Then
                        Me.dgdTaxInvoice.Item("details", i).Value = texts(1)
                    Else

                    End If

                End If
                If UCase(Me.dgdTaxInvoice.Item("huy", i).Value.ToString) = "TRUE" Then
                    Me.dgdTaxInvoice.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgdTaxInvoice.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    Me.dgdTaxInvoice.Rows(i).DefaultCellStyle.SelectionForeColor = Color.Blue
                End If
            Next
            InsertAutoNumberToGrid(Me.dgdTaxInvoice)
            tongtaxinvoice()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Me.RefreshToolStripMenuItem.Enabled = True
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed
        '   Me.dgdPort.Columns.Item("Port").Visible = Me.smnuDisplayName.Checked
        Me.dgdTaxInvoice.Columns.Item("company").Visible = Me.smnutencongty.Checked
        Me.dgdTaxInvoice.Columns.Item("address").Visible = Me.smnudiachi.Checked

        Me.dgdTaxInvoice.Columns.Item("serialno").Visible = Me.smnuquyenso.Checked
        Me.dgdTaxInvoice.Columns.Item("details").Visible = Me.smnuchitiethoadon.Checked
        Me.dgdTaxInvoice.Columns.Item("chungtu").Visible = Me.smnuchungtukemtheo.Checked

        Me.dgdTaxInvoice.Columns.Item("ref").Visible = Me.smnuref.Checked
        '----------------------
        Me.dgdTaxInvoice.Columns.Item("vatshow").Visible = Me.smnuhienthivat.Checked
        Me.dgdTaxInvoice.Columns.Item("dateinvoice").Visible = Me.smnungayphathanh.Checked

        Me.dgdTaxInvoice.Columns.Item("dateinvoice").Visible = Me.smnungayphathanh.Checked
        Me.dgdTaxInvoice.Columns.Item("MethodPayment").Visible = Me.smnuphuongthucthanhtoan.Checked
        Me.dgdTaxInvoice.Columns.Item("vesselvoy").Visible = Me.smnutentausochuyen.Checked
        Me.dgdTaxInvoice.Columns.Item("DirectorSign").Visible = Me.smnunguoilap.Checked
        Me.dgdTaxInvoice.Columns.Item("CustomerSign").Visible = Me.smnukhachhang.Checked
        Me.dgdTaxInvoice.Columns.Item("chuyenUSD").Visible = Me.smnucusd.Checked
        Me.dgdTaxInvoice.Columns.Item("RowNo").Visible = Me.smnusodonghoadon.Checked

        Me.dgdTaxInvoice.Columns.Item("userid").Visible = Me.smnuuserupdate.Checked
        Me.dgdTaxInvoice.Columns.Item("updatetime").Visible = Me.smnudateupdate.Checked
        Me.dgdTaxInvoice.Columns.Item("huy").Visible = Me.smnuhuy.Checked
        Me.dgdTaxInvoice.Columns.Item("lydohuy").Visible = Me.smnulydohuy.Checked

        Me.dgdTaxInvoice.Columns.Item("salecode").Visible = Me.smnusale.Checked

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
        dgdTaxInvoice.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdTaxInvoice.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdTaxInvoice.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        'fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdTaxInvoice.Height + dgdTaxInvoice.Top '+ 100

        ' Me.txtShipper.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10



        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10


        cmdOK.Left = Me.txtCusSign.Left
        cmdCancel.Left = Me.cmdOK.Left + 100

        'cmdFind.Left = Me.txtShipper.Left + Me.txtShipper.Width + 10
        'txtShipper.Width = Me.Width - 297

        Exit Sub
Err:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    Private Sub dgdShipper_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdTaxInvoice.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdTaxInvoice.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdTaxInvoice.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdTaxInvoice.Columns(ColIndex).Name = "Approve" And Me.dgdTaxInvoice.CurrentCellAddress().Y = index Then
            Call ApproveShipper()
            'QueryShipper(mFilter, , index)
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdShipper_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdTaxInvoice.CellContentDoubleClick

    End Sub

    Private Sub dgdTaxInvoice_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdTaxInvoice.CellMouseUp
        Try
            Dim tong As Double = 0
            If Me.dgdTaxInvoice.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgdTaxInvoice.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumselect.Text = FormatNumber(tong.ToString, 0)
            Catch ex As Exception

            End Try

            'Dim selectedRowCount As Integer = _
            '     Me.dgddebitGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If selectedRowCount = 0 Then
            '    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            '    Return
            'End If
            'If selectedRowCount > 0 Then
            '    Dim sb As New System.Text.StringBuilder()
            '    Dim i As Integer
            '    For i = 0 To selectedRowCount - 1

            '        tong += CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit_lc", Me.dgdCreditGrid.SelectedRows(i).Index).ToString)
            '    Next i
            'End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgdShipper_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdTaxInvoice.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryShipper("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdTaxInvoice)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdShipper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdTaxInvoice.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdTaxInvoice.SelectedRows(i).Index)
                Next i
            End If

            QueryShipper()
        End If
    End Sub




    'Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
    '        Me.cboFind.SelectedIndex = 0
    '        Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
    '    End If
    'End Sub




    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString

            '  Me.txtSerialNO.Text = Me.dgdTaxInvoice.Item("serialno", index).Value.ToString
            Me.txtInvoiceNo.Text = Me.dgdTaxInvoice.Item("invoiceno", index).Value.ToString
            Me.dtpDate.Value = Me.dgdTaxInvoice.Item("dateinvoice", index).Value.ToString

            Me.cboCustomer.Text = FindIDValue(Me.cboCustomer, Me.dgdTaxInvoice.Item("Customer_ID", index).Value.ToString)
            Me.txtAddress.Text = Me.dgdTaxInvoice.Item("address", index).Value.ToString
            Me.txtTax.Text = Me.dgdTaxInvoice.Item("taxcode", index).Value.ToString
            Me.cbomethodpayment.Text = Me.dgdTaxInvoice.Item("methodpayment", index).Value.ToString
            Me.txtCusSign.Text = Me.dgdTaxInvoice.Item("customersign", index).Value.ToString
            Me.txtDirSign.Text = Me.dgdTaxInvoice.Item("Directorsign", index).Value.ToString
            Me.txtVAT.Text = Me.dgdTaxInvoice.Item("VAT", index).Value.ToString
            Me.txtVATShow.Text = Me.dgdTaxInvoice.Item("VATShow", index).Value.ToString
            Me.txtChungtu.Text = Me.dgdTaxInvoice.Item("chungtu", index).Value.ToString
            Me.txtExchange.Text = Me.dgdTaxInvoice.Item("Exchange", index).Value.ToString
            Try
                Me.txtvesselvoy.Text = Me.dgdTaxInvoice.Item("vesselvoy", index).Value.ToString
            Catch ex As Exception

            End Try
            Me.cbobillnumber.Text = Me.dgdTaxInvoice.Item("billnumber", index).Value.ToString
            Me.chkpay.Checked = Me.dgdTaxInvoice.Item("thanhtoan", index).Value
            Me.chkchiho.Checked = Me.dgdTaxInvoice.Item("chiho", index).Value


            Try
                'Me.RadioIn.Checked = Me.dgdTaxInvoice.Item("inbound", index).Value
                'Me.radioOut.Checked = Me.dgdTaxInvoice.Item("outbound", index).Value

                'Me.chkLogistics.Checked = Me.dgdTaxInvoice.Item("logistics", index).Value
                'Me.chkchuyenusd.Checked = Me.dgdTaxInvoice.Item("chuyenUSD", index).Value

            Catch ex As Exception

            End Try

            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from taxinvoice where taxinvoiceid='" & mTaxInvoiceId & "'" 'mTaxInvoiceId
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                'them rieng cho SITC
                Me.txttigiachuyen.Text = ds.Tables(0).Rows(0).Item("tigiachuyen").ToString 'Me.dgdTaxInvoice.Item("tigiachuyen", index).Value.ToString
                Me.txtref.Text = ds.Tables(0).Rows(0).Item("ref").ToString
                Me.txthancongno.Text = ds.Tables(0).Rows(0).Item("buss_place").ToString

                Me.cboINT_ID.Text = ds.Tables(0).Rows(0).Item("int_id").ToString
                Me.cboVender_ID.Text = ds.Tables(0).Rows(0).Item("vender_id").ToString
                Me.cboDEP_CDE.Text = ds.Tables(0).Rows(0).Item("dep_cde").ToString
                Me.cboFre_CDE.Text = ds.Tables(0).Rows(0).Item("pre_cde").ToString

                Me.cboDMBTR.Text = ds.Tables(0).Rows(0).Item("dmbtr").ToString
                Me.cboXSITC.Text = ds.Tables(0).Rows(0).Item("xcitc").ToString

                Me.cboIE_flag.Text = ds.Tables(0).Rows(0).Item("ieflag").ToString
                Me.cboBL_CDE.Text = ds.Tables(0).Rows(0).Item("bl_cde").ToString
                Me.cboCar_BL_CDE.Text = ds.Tables(0).Rows(0).Item("car_bl_cde").ToString
                Me.cboIM_cmpcde.Text = ds.Tables(0).Rows(0).Item("im_cmpcde").ToString

                Me.cboBus_type.Text = ds.Tables(0).Rows(0).Item("bus_type").ToString
                Me.cboBus_CodeA.Text = ds.Tables(0).Rows(0).Item("bus_codea").ToString

                Me.cboBus_CodeB.Text = ds.Tables(0).Rows(0).Item("bus_codeb").ToString

                Me.cboReg_CDE.Text = ds.Tables(0).Rows(0).Item("reg_cde").ToString
                Me.cboBus_Date.Text = ds.Tables(0).Rows(0).Item("bus_date").ToString

                Me.cbobus_Place.Text = ds.Tables(0).Rows(0).Item("buss_place").ToString
                Me.cboPort_cde.Text = ds.Tables(0).Rows(0).Item("PORT_CDE").ToString
                Me.txtsale.Text = ds.Tables(0).Rows(0).Item("salecode").ToString

                masterbill = ds.Tables(0).Rows(0).Item("masterbill").ToString
                Try
                    Me.txtTKNo.Text = ds.Tables(0).Rows(0).Item("TKno").ToString

                    Me.txtTKco.Text = ds.Tables(0).Rows(0).Item("TKCo").ToString
                Catch ex As Exception

                End Try
            End If

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

    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdTaxInvoice.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdTaxInvoice, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnutaxinvoivedetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub txtShipper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            Me.cmdFind.PerformClick()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Try


            If mStatus = "Normal" And UserRight("smnuother", "Add") Then
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mTaxInvoiceId = DefaultValue
                mStatus = "Add"
                reText(mStatus)
                ' xoa trang d kieu de them moi vao

                ' lay so hoa don
                Dim sohoadon As String
                Dim sohoadonke As Integer = 0
                Dim sql As String


                Me.txtInvoiceNo.Text = gBranch + "000"


                Me.cboCustomer.Text = ""
                Me.txtAddress.Text = ""
                Me.cbomethodpayment.Text = ""
                Me.txtTax.Text = ""
                Me.txtCusSign.Text = ""
                Me.txtDirSign.Text = ""
                Me.cbobillnumber.Text = ""
                Me.txtDirSign.Text = getUserName(strUserId)
                '----------------------------------------
                ' Me.txtInvoiceNo.Text = CodeShipper()
                'Dim Len As Integer = CStr(CodeShipper() + 1).Length
                'Me.txtCode.Text = "S"
                'For i As Integer = 1 To 7 - Len
                '    Me.txtCode.Text &= "0"
                'Next
                'Me.txtCode.Text &= CStr(CodeShipper() + 1)
                ' Me.cboINT_ID.Text = ""
                Me.cboVender_ID.Text = ""
                ' Me.cboDEP_CDE.Text = ""
                Me.cboFre_CDE.Text = ""

                'Me.cboDMBTR.Text = ""
                Me.cboXSITC.Text = "N"

                ' Me.cboIE_flag.Text = ""
                Me.cboBL_CDE.Text = ""
                Me.cboCar_BL_CDE.Text = ""
                Me.cboIM_cmpcde.Text = ""

                Me.cboBus_type.Text = ""
                Me.cboBus_CodeA.Text = ""

                Me.cboBus_CodeB.Text = ""
                ' Me.cboReg_CDE.Text = ""
                Me.cboBus_Date.Text = ""

                Me.cbobus_Place.Text = ""
                Me.dgdCus.Enabled = False
                Me.dgdCus.Rows.Clear()
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try



    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
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

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub ChangeDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeDetailToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdTaxInvoice.RowCount = 0 Then
            Return
        End If
        ' Me.dgdCus.Enabled = False
        Dim index As Integer = Me.dgdTaxInvoice.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdTaxInvoice.Item("Approve", index).Value
            ' EditTable = Me.dgdTaxInvoice.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And UserRight("smnuother", "Edit") Then
                Me.dgdTaxInvoice.Height = 306
                Me.dgdTaxInvoice.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mTaxInvoiceId = Me.dgdTaxInvoice.Item("debitID", index).Value.ToString
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
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Dim selectedRowCount As Integer = _
       Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdTaxInvoice.SelectedRows(i).Index)
                DeleteTaxInvoiceDOC(Me.dgdTaxInvoice.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryShipper(" " & mFilter)
    End Sub

    Public Sub DeleteTaxInvoiceDOC(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        Dim cmd As New ADODB.Command
        Dim cmdin As New ADODB.Command
        Dim cmdlog As New ADODB.Command

        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position


        'If Not IsNothing(Me.dgdTaxInvoice.Item("Editable", index)) Then
        '    If Not Me.dgdTaxInvoice.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("smnuother", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            'strMesg = "Delete the TaxInvoice: " & Me.dgdTaxInvoice.Item("serialNo", index).Value.ToString
            'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            'strQueryCommodityList = "Select * from taxinvoice where" + " taxinvoiceId= '" & Me.dgdTaxInvoice.Item("debitID", index).Value.ToString & "'"
            'rsShipperList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rsShipperList.Fields("continued").Value = 0
            'rsShipperList.Update()
            'cmd.let_ActiveConnection(strconn)
            'cmd.CommandText = "delete from taxinvoice where taxinvoiceId= '" & Me.dgdTaxInvoice.Item("InvoiceNo", index).Value.ToString & "' "

            'cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' lay toan bo cac phi debit ma co so HD = voi Me.dgdTaxInvoice.Item("InvoiceNo", index).Value.ToString
            ' rsShipperList.Requery()
            'rs.Fields("PayCheck").Value = True
            'rs.Fields("ngay").Value = Me.dtpDate.Value.Date.ToString.Replace("12:00:00 AM", "")
            'rs.Fields("Ngayhoadon").Value = Me.txtInvoiceNo.Text
            'rsShipperList.Close()
            '-----------------------------------------------------
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "update outboundfreight set  paycheck=0,ngay='',ngayhoadon='' ,approve=0 where Ngayhoadon like  '%" & Me.dgdTaxInvoice.Item("InvoiceNo", index).Value.ToString & "%' "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)


            cmdin.let_ActiveConnection(strconn)
            cmdin.CommandText = "update inboundfreight set  paycheck=0,ngay='',ngayhoadon='' ,approve=0  where Ngayhoadon like  '%" & Me.dgdTaxInvoice.Item("InvoiceNo", index).Value.ToString & "%' "

            cmdin.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            cmdlog.let_ActiveConnection(strconn)
            cmdlog.CommandText = "update logisticsfreight set  paycheck=0,ngay='',ngayhoadon='' ,approve=0  where Ngayhoadon like  '%" & Me.dgdTaxInvoice.Item("InvoiceNo", index).Value.ToString & "%' "

            cmdlog.Execute(, , ADODB.CommandTypeEnum.adCmdText)





            'blnUpdated = True
            'End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub


    'Private Sub smnuSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSelect.Click
    '    '        On Error GoTo Err_Renamed
    '    '        VB6.ShowForm(frmTaxDetail, VB6.FormShowConstants.Modeless, Me)
    '    '        Exit Sub
    '    'Err_Renamed:
    '    '        MsgBox(msgErr(Me, Err.Description))
    'End Sub

    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged
        ' lay ra dia chi ma so thue
        Dim CusID, sql, add, tax As String
        CusID = FindValueID(Me.cboCustomer, Me.cboCustomer.Text)
        If CusID = "" Then
            Return
        End If
        ' dataset
        Dim ds As New DataSet
        sql = "select * from Customer where Customer_id='" & CusID & "' and continued=1 "
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            add = ds.Tables(0).Rows(0).Item("Address").ToString
            tax = ds.Tables(0).Rows(0).Item("TaxCode").ToString
        End If
        Me.txtAddress.Text = add
        Me.txtTax.Text = tax
    End Sub

    Private Sub txtVAT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVAT.KeyPress
        If e.KeyChar.ToString = "." Or e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = "0"
        End If

    End Sub

    Private Sub txtVAT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVAT.TextChanged

    End Sub

    Private Sub InputDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDetailsToolStripMenuItem.Click
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdTaxInvoice.SelectedRows.Count > 0 Then
            Dim index As Integer = Me.dgdTaxInvoice.CurrentRow.Index
            gSearchID = Me.dgdTaxInvoice.Item("debitID", index).Value.ToString
            BillnumberIN = Me.dgdTaxInvoice.Item("billnumber", index).Value.ToString
            gSForm = Me.Name
            '
            SearchCombo()
            'Me.Close()
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click

    End Sub

    Private Sub txtTax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTax.Leave
        ' lay ra dia chi ma so thue
        Dim CusID, sql, add, tax As String
        'CusID = FindValueID(Me.cboCustomer, Me.cboCustomer.Text)
        ' dataset
        Dim ds As New DataSet
        sql = "select * from Customer where taxcode='" & Me.txtTax.Text.Trim & "' and continued=1 "
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            add = ds.Tables(0).Rows(0).Item("Address").ToString
            tax = ds.Tables(0).Rows(0).Item("TaxCode").ToString
            Me.cboCustomer.Text = ds.Tables(0).Rows(0).Item("taxcode").ToString + "-" + ds.Tables(0).Rows(0).Item("company").ToString
        End If
        Me.txtAddress.Text = add
        Me.txtTax.Text = tax
    End Sub

    Private Sub txtTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTax.TextChanged

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.QueryBillnumber()
        Me.QueryCustomer()
        Me.QueryShipper(mFilter)
    End Sub

    Private Sub StaticiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaticiToolStripMenuItem.Click
        frmInvoiceStatistics.Show()
    End Sub
    Dim masterbill As String
    Public Sub getDebitCustomer(ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal TableFreightDept As String, ByVal TableFreightDeptID As String)
        Try
            ' ta lay thong tin tu feedebit va feecredit
            ' chu yeu lay tu feedebit
            ' dieu kien phai co ti gia truoc
            Dim dsfeeDebit As New DataSet
            Dim id, value, strQuery As String
            masterbill = ""
            'If Me.RadioOther.Checked = True Then
            'Else


            '    Dim bl_id As String
            '    Dim i As Integer
            If Me.txtExchange.Text = "" Then
                Me.txtExchange.Text = "1"
            End If
            If Me.txtExchange.Text = "" Then
                DisplayMessage(True, "Xin kiểm tra lại Tỉ giá USD.")
                Return
            End If
            Me.cboCus.Items.Clear()
            Me.cboCus.Text = ""
            Me.dgdCus.Enabled = True
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from " & TableFreightDept & " left join Customer on " & TableFreightDept & ".customerid=customer.customer_id  where " & TableFreightDeptID & " = '" & hbl & "' and DebitCredit='Debit' order by dateupdate "
            ds = ReadDataSet(sql)
            id = "Customerid"
            value = "Company"
            If ds.Tables(0).Rows.Count > 0 Then
                loadDataToObject(Me.cboCus, sql, id, value)
            End If
            'lay thogn tin khach hang debit
            '    ' co so blh_no (Outbound) va MBL (Inbound) ta lay ref (Fileno(Containeroutboundnotify)-Outbound) va ref (ref(BillofladingIB)-Inbound)

            '    Me.txtChungtu.Text = Me.cbobillnumber.Text
            '    ' lay Ref
            '    Dim sqlRef As String = ""
            '    Dim dsRef As New DataSet
            '    If Me.RadioIn.Checked = True Then
            '        sqlRef = "select hBL as MBL from inbound where hbl='" & Me.cbobillnumber.Text & "' "
            '    ElseIf Me.radioOut.Checked = True Then
            '        sqlRef = "select MBLMawb as MBL from outbound where MBLMawb='" & Me.cbobillnumber.Text & "' "
            '    ElseIf Me.chkLogistics.Checked = True Then
            '        sqlRef = "select ref as MBL from logistics where ref='" & Me.cbobillnumber.Text & "' "

            '    End If
            '    If sqlRef = "" Then
            '        Me.txtChungtu.Text = ""
            '    Else
            '        dsRef = ReadDataSet(sqlRef)
            '        If dsRef.Tables(0).Rows.Count > 0 Then
            '            Me.txtChungtu.Text = Me.cbobillnumber.Text ' + "     (MBL/MAWB: " + dsRef.Tables(0).Rows(0).Item("MBL").ToString + ")"
            '        End If
            '    End If

            '    ' lay bl_id
            '    Dim sql As String
            '    Dim dsBillID, dsBillHouseID, dsBillIBID As DataSet
            '    'kiem tra masterbill,housebill,billimport
            '    If Me.radioOut.Checked = True Then
            '        sql = "select * from outbound where mblmawb='" & Me.cbobillnumber.Text.Trim & "' and continued=1 "
            '        dsBillIBID = ReadDataSet(sql)
            '        If dsBillIBID.Tables(0).Rows.Count > 0 Then
            '            bl_id = dsBillIBID.Tables(0).Rows(0).Item("blob_id").ToString
            '            Try
            '                Me.txtvesselvoy.Text = dsBillIBID.Tables(0).Rows(0).Item("vessel").ToString & "/" & dsBillIBID.Tables(0).Rows(0).Item("voyage").ToString
            '                masterbill = dsBillIBID.Tables(0).Rows(0).Item("mblcarrier").ToString
            '                Me.txtsale.Text = dsBillIBID.Tables(0).Rows(0).Item("salecode").ToString
            '            Catch ex As Exception

            '            End Try
            '        Else
            '            ' DisplayMessage(True, "Xin kiểm tra lại số Bill.")
            '            Return
            '        End If
            '        'sql = "select * from freight_charge_ib where continued=1 and blib_id='" & bl_id & "'  and priceban <>0 "
            '        sql = "select *,taxcode + '-' + company as company1 from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id  where outboundid='" & bl_id & "' and debitcredit='Debit'"
            '        dsfeeDebit = ReadDataSet(sql)
            '        id = "customerid"
            '        value = "company1"
            '        If dsfeeDebit.Tables(0).Rows.Count > 0 Then
            '            Me.cboCus.Items.Clear()
            '            loadDataToObjectNoClear(Me.cboCus, sql, id, value)
            '            ' lay tax
            '            Me.txtVAT.Text = dsfeeDebit.Tables(0).Rows(0).Item("taxprice").ToString
            '            '-------------------
            '        End If
            '        InsertAutoNumberToGrid(Me.dgdCus)
            '    End If

            '    If Me.RadioIn.Checked = True Then

            '        sql = "select * from inbound where hbl='" & Me.cbobillnumber.Text.Trim & "' and continued=1 "
            '        dsBillIBID = ReadDataSet(sql)
            '        If dsBillIBID.Tables(0).Rows.Count > 0 Then
            '            bl_id = dsBillIBID.Tables(0).Rows(0).Item("blib_id").ToString
            '            Try
            '                Me.txtvesselvoy.Text = dsBillIBID.Tables(0).Rows(0).Item("vessel").ToString & "/" & dsBillIBID.Tables(0).Rows(0).Item("voyage").ToString
            '                masterbill = dsBillIBID.Tables(0).Rows(0).Item("mbl").ToString
            '                Me.txtsale.Text = dsBillIBID.Tables(0).Rows(0).Item("salecode").ToString
            '            Catch ex As Exception

            '            End Try
            '        Else
            '            ' DisplayMessage(True, "Xin kiểm tra lại số Bill.")
            '            Return
            '        End If


            '        'sql = "select * from freight_charge_ib where continued=1 and blib_id='" & bl_id & "'  and priceban <>0 "
            '        sql = "select *,taxcode + '-' + company as company1 from inboundfreight left join customer on inboundfreight.customerid=customer.customer_id  where inboundid='" & bl_id & "' and debitcredit='Debit'"
            '        dsfeeDebit = ReadDataSet(sql)
            '        id = "customerid"
            '        value = "company1"
            '        If dsfeeDebit.Tables(0).Rows.Count > 0 Then
            '            Me.cboCus.Items.Clear()

            '            loadDataToObjectNoClear(Me.cboCus, sql, id, value)

            '            Me.txtVAT.Text = dsfeeDebit.Tables(0).Rows(0).Item("taxprice").ToString
            '        End If
            '    End If
            '    If Me.chkLogistics.Checked = True Then

            '        sql = "select * from logistics where ref='" & Me.cbobillnumber.Text.Trim & "' and continued=1 "
            '        dsBillIBID = ReadDataSet(sql)
            '        If dsBillIBID.Tables(0).Rows.Count > 0 Then
            '            Try
            '                Me.txtvesselvoy.Text = CDate(Getdate()).Year.ToString & "/" & "1111" 'dsBillIBID.Tables(0).Rows(0).Item("vessel").ToString & "/" & dsBillIBID.Tables(0).Rows(0).Item("voyage").ToString
            '                masterbill = dsBillIBID.Tables(0).Rows(0).Item("mblcarrier").ToString
            '                Me.txtsale.Text = dsBillIBID.Tables(0).Rows(0).Item("salecode").ToString
            '            Catch ex As Exception

            '            End Try
            '            bl_id = dsBillIBID.Tables(0).Rows(0).Item("blob_id").ToString
            '        Else
            '            ' DisplayMessage(True, "Xin kiểm tra lại số Bill.")
            '            Return
            '        End If


            '        'sql = "select * from freight_charge_ib where continued=1 and blib_id='" & bl_id & "'  and priceban <>0 "
            '        sql = "select *,taxcode + '-' + company as company1 from logisticsfreight left join customer on logisticsfreight.customerid=customer.customer_id  where logisticsid='" & bl_id & "' and debitcredit='Debit'"
            '        dsfeeDebit = ReadDataSet(sql)
            '        id = "customerid"
            '        value = "company1"
            '        If dsfeeDebit.Tables(0).Rows.Count > 0 Then
            '            Me.cboCus.Items.Clear()

            '            loadDataToObjectNoClear(Me.cboCus, sql, id, value)
            '            Me.txtVAT.Text = dsfeeDebit.Tables(0).Rows(0).Item("taxprice").ToString

            '        End If
            '    End If


            'End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' lay so bill query tat ca cac phi usd (feedebit va tru di tax )nhan voi tigia
            ' lay so bill query tat cac cac phi VND - tax vnd 
            ' luu y tuong ung voi tung dong o feedebit
            ' lay dong thu 1
            'SELECT     AgencyName, Charge_Code, SUM(priceDebit) AS Expr1, SUM(priceCredit) AS Expr2, Currency
            'FROM         handlingOutbound
            'WHERE     (continued = 1) AND (Bl_ID = 'f90f79fa-13b4-4514-8618-54650167c960') AND (Currency = 'USD')
            'GROUP BY AgencyName, Charge_Code, Currency


        Catch ex As Exception

        End Try
    End Sub
    Private Sub cbobillnumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbobillnumber.Leave



    End Sub

    Private Sub cbobillnumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbobillnumber.SelectedIndexChanged
        Try
            If Me.cboIOL.Text.Trim = "Agency-Export" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound", "BLOB_ID", "OutboundFreight", "OutboundID")
            End If
            If Me.cboIOL.Text.Trim = "Agency-Import" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound", "BLIB_ID", "InboundFreight", "InboundID")
            End If

            If Me.cboIOL.Text.Trim = "Oversea-Sea-Import" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaSeaimport", "BLIB_ID", "InboundFreight", "InboundID")

            End If
            If Me.cboIOL.Text.Trim = "Oversea-Sea-Export" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaSeaExport", "BLOB_ID", "OutboundFreight", "OutboundID")

            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Import" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaAirImport", "BLIB_ID", "InboundFreight", "InboundID")


            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Export" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaAirExport", "BLOB_ID", "OutboundFreight", "OutboundID")


            End If
            If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_ACSSeaExport", "BLOB_ID", "OutboundFreight", "OutboundID")



            End If

            If Me.cboIOL.Text.Trim = "Logistics-Customs" Then

                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics", "BLOB_ID", "LogisticsFreight", "LogisticsID")


            End If
            If Me.cboIOL.Text.Trim = "Domestic-Truck" Then
                getDebitCustomer(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics_Truck", "BLOB_ID", "LogisticsFreight", "LogisticsID")



            End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        Dim dsfeeDebitUSD As DataSet
        Dim i, j, k, l As Integer
        Dim cus As String = ""
        Dim cus_() As String
        Dim notsame As Boolean = False
        ' xac  dinh khach hang
        ' duyet luoi du lieu
        ' kiem tra neu lon hon 2 dong, neu khac cus thi thong bao chon lai
        'Me.cboCus.Items.Clear()
        Me.txtInvoiceNo.Text = Me.cbobillnumber.Text
        If Me.dgdCus.Rows.Count > 0 Then
            ' co du lieu bat dau kiem tra da check dong nao chua
            For i = 0 To Me.dgdCus.Rows.Count - 1
                If Me.dgdCus.Item("checkprint", i).Value = True Then
                    cus += Me.dgdCus.Item("CustomerIDDebit", i).Value.ToString + "$"
                    Try
                        Me.txtVAT.Text = Me.dgdCus.Item("thue", i).Value.ToString
                        Me.txtVATShow.Text = Me.dgdCus.Item("thue", i).Value.ToString
                    Catch ex As Exception

                    End Try
                Else

                End If
            Next
            If cus = "" Then
                Return
            End If
            cus = cus.Remove(cus.Length - 1, 1)
            ' lay xong du lieu cus ta bat dau kiem tra khac nhau.
            cus_ = cus.Split("$")
            For j = 0 To cus_.Length - 2
                For k = j + 1 To cus_.Length - 1
                    If cus_(j).ToString <> cus_(k).ToString Then
                        notsame = True
                    End If
                Next
            Next
            If notsame = True Then
                DisplayMessage(True, "Lô hàng này có hơn 1 khách hàng cần thu tiền mà bạn đã check .")
                Me.cboCustomer.Text = ""

                Return
            End If
            ' xu ly cus, dua xuong
            Dim sqlc As String
            Dim dsc As New DataSet
            sqlc = " select * from customer where customer_id='" & cus_(0).ToString & "'"
            dsc = ReadDataSet(sqlc)
            If dsc.Tables(0).Rows.Count > 0 Then
                Me.cboCustomer.Text = dsc.Tables(0).Rows(0).Item("taxcode").ToString + "-" + dsc.Tables(0).Rows(0).Item("company").ToString
            End If


        Else
            DisplayMessage(True, "Lô hàng này chưa có input freight hay charges .")
        End If






        'sql = "select AgencyName, Charge_Code, SUM(priceDebit) AS priceDebit, Currency,tax from handlingOutbound where continued=1 and bl_id='" & bl_id & "' and currency='USD' and pricedebit <>0 group by AgencyName, Charge_Code, Currency,tax "
        'dsfeeDebitUSD = ReadDataSet(sql)
        ' '' co nhieu dong neu co nhieu feedebit
        ''Me.dgdCus.Rows.Clear()
        'Me.dgdCus.DataSource = dsfeeDebitUSD.Tables(0)
        'If dsfeeDebitUSD.Tables(0).Rows.Count > 0 Then
        '    'Me.dgdCus.DataSource = dsfeeDebitUSD.Tables(0)
        '    'If dsfeeDebitUSD.Tables(0).Rows.Count > 1 Then

        '    '    DisplayMessage(True, "Lô hàng này có hơn 1 khách hàng cần thu tiền.")
        '    '    Return
        '    'Else


        '    '    For i = 0 To dsfeeDebitUSD.Tables(0).Rows.Count - 1
        '    '        ' lay so lieu dong dau cua feedebit
        '    '        ' lay ten dai ly, khachhang,carrier

        '    '    Next
        '    'End If
        'End If
    End Sub

    Private Sub cboCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.TextChanged
        ' lay ra dia chi ma so thue
        Dim CusID, sql, add, tax As String
        CusID = FindValueID(Me.cboCustomer, Me.cboCustomer.Text)
        ' dataset
        If CusID = "" Then
            Return
        End If
        Dim ds As New DataSet
        sql = "select * from Customer where Customer_id='" & CusID & "' and continued=1 "
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            add = ds.Tables(0).Rows(0).Item("Address").ToString
            tax = ds.Tables(0).Rows(0).Item("TaxCode").ToString
        End If
        Me.txtAddress.Text = add
        Me.txtTax.Text = tax
    End Sub

    Private Sub cbobillnumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbobillnumber.TextChanged
        'If Me.RadioOther.Checked = True Then
        'Else

        '    cbobillnumber_Leave(sender, e)
        'End If

        ' ta lay thong tin tu feedebit va feecredit
        ' chu yeu lay tu feedebit
        ' dieu kien phai co ti gia truoc
        'Dim bl_id As String
        'Dim i As Integer
        'If Me.txtExchange.Text.Length = 0 Then
        '    DisplayMessage(True, "Xin kiểm tra lại Tỉ giá USD.")
        '    Return
        'End If
        'Me.txtChungtu.Text = Me.cbobillnumber.Text
        '' lay bl_id
        'Dim sql As String
        'Dim dsBillID As DataSet
        'sql = "select bl_id from billoflading where bl_no='" & Me.cbobillnumber.Text.Trim & "' and continued=1 "
        'dsBillID = ReadDataSet(sql)
        'If dsBillID.Tables(0).Rows.Count > 0 Then
        '    bl_id = dsBillID.Tables(0).Rows(0).Item("bl_id").ToString

        'Else
        '    DisplayMessage(True, "Xin kiểm tra lại số Bill.")
        '    Return
        'End If


        '' lay so bill query tat ca cac phi usd (feedebit va tru di tax )nhan voi tigia
        '' lay so bill query tat cac cac phi VND - tax vnd 
        '' luu y tuong ung voi tung dong o feedebit
        '' lay dong thu 1
        ''SELECT     AgencyName, Charge_Code, SUM(priceDebit) AS Expr1, SUM(priceCredit) AS Expr2, Currency
        ''FROM         handlingOutbound
        ''WHERE     (continued = 1) AND (Bl_ID = 'f90f79fa-13b4-4514-8618-54650167c960') AND (Currency = 'USD')
        ''GROUP BY AgencyName, Charge_Code, Currency
        'Dim dsfeeDebitUSD As DataSet
        'sql = "select AgencyName, Charge_Code, SUM(priceDebit) AS priceDebit, Currency,tax from handlingOutbound where continued=1 and bl_id='" & bl_id & "'  and pricedebit <>0 group by AgencyName, Charge_Code, Currency,tax "
        'dsfeeDebitUSD = ReadDataSet(sql)
        ' '' co nhieu dong neu co nhieu feedebit
        ''Me.dgdCus.Rows.Clear()
        'Me.dgdCus.DataSource = dsfeeDebitUSD.Tables(0)
        'InsertAutoNumberToGrid(Me.dgdCus)
        'If dsfeeDebitUSD.Tables(0).Rows.Count > 0 Then
        '    'Me.dgdCus.DataSource = dsfeeDebitUSD.Tables(0)
        '    'If dsfeeDebitUSD.Tables(0).Rows.Count > 1 Then

        '    '    DisplayMessage(True, "Lô hàng này có hơn 1 khách hàng cần thu tiền.")
        '    '    Return
        '    'Else


        '    '    For i = 0 To dsfeeDebitUSD.Tables(0).Rows.Count - 1
        '    '        ' lay so lieu dong dau cua feedebit
        '    '        ' lay ten dai ly, khachhang,carrier

        '    '    Next
        '    'End If
        'End If
    End Sub

    Private Sub XToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XToolStripMenuItem.Click

    End Sub

    Private Sub radioOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.QueryBillnumber()
    End Sub

    Private Sub RadioIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.QueryBillnumber()
    End Sub

    Private Sub RadioOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.cbobillnumber.Text = ""
        Me.txtChungtu.Text = ""
        Me.cbobillnumber.Items.Clear()
        Me.dgdCus.DataSource = Nothing
    End Sub

    Private Sub XToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XToolStripMenuItem1.Click
        ' lay so lieu tren taxdetail cong lai het -> VND dua vao cong thanh 1 dong
        ' lay tacinvoiceID
        Dim idex As Integer
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdTaxInvoice.Rows.Count > 0 Then
            Dim selectedRowCount As Integer = _
                         Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then


                idex = Me.dgdTaxInvoice.SelectedRows(0).Index
                If selectedRowCount > 0 Then
                    '   InsertPhieuthu(idex)
                Else
                    Return
                End If
                ' mo formphieuthudebit
                gSFormTaxInvoice = Me.Name
                gSComboBillTaxInvoice = Me.dgdTaxInvoice.Item("debitid", idex).Value.ToString
                Dim frm As New frmPhieuthu
                frm.ShowDialog(Me)
                gSComboBillTaxInvoice = ""
                'Me.QueryShipper(" " & mFilter)
            End If
        End If
    End Sub

    Private Sub XemPhiếuThuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XemPhiếuThuToolStripMenuItem.Click
        ' mo formphieuthu
        Dim idex As Integer
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdTaxInvoice.Rows.Count > 0 Then
            Dim selectedRowCount As Integer = _
                         Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                idex = Me.dgdTaxInvoice.SelectedRows(0).Index
                If selectedRowCount > 0 Then
                    gSFormTaxInvoice = Me.Name
                    gSComboBillTaxInvoice = Me.dgdTaxInvoice.Item("debitid", idex).Value.ToString
                    Dim frm As New frmPhieuthu
                    frm.ShowDialog(Me)
                    gSComboBillTaxInvoice = ""
                Else
                    Return
                End If
            End If

        End If


    End Sub

    Private Sub txtChungtu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChungtu.TextChanged

    End Sub

    Private Sub HủyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HủyToolStripMenuItem.Click
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Me.GroupBox4.Visible = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try



            Dim chk As Integer
            chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            Dim selectedRowCount As Integer = _
           Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            Dim f As Integer = 0
            If selectedRowCount = 1 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    AddHuy(Me.dgdTaxInvoice.SelectedRows(i).Index)
                    f = 1
                Next i
            End If
            'If f = 1 Then frmMain.LoadData()
            'If mFilter = "" Then
            '    DisplayMessage(True, "Xin chọn Lọc thông tin để lấy dữ liệu.")
            '    Return
            'Else

            '    Me.QueryDepartment(mFilter)
            'End If
            DisplayMessage(True, "OK")
            Me.RefreshToolStripMenuItem_Click(sender, e)
            Me.GroupBox4.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Public Sub AddHuy(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean

        Dim strMesg As String
        Dim bm As Short

        strQueryCommodityList = "Select * from debit where" + " debitID= '" & Me.dgdTaxInvoice.Item("debitID", index).Value.ToString & "'"
        rs.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        rs.Fields("huy").Value = Me.chkHuy.Checked
        rs.Fields("lydohuy").Value = Me.txtLydohuy.Text
        rs.Update()

        rs.Requery()

        rs.Close()

        'End If
        ' End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, msgErr(Me, Err.Description))
    End Sub
    Public Sub addPayCheck(ByVal index As Integer, ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal TableFreightDept As String, ByVal TableFreightDeptID As String)
        Try


            Dim customer, itemsdebit, quantitydebit, bill As String
            Dim i As Integer
            Dim sqlI As String
            Dim dsI As New DataSet
            Dim rs As New ADODB.Recordset

            If Me.dgdCus.Item("Checkprint", index).Value = "True" Then
                ' insert vao 
                Try
                    ' lay customer,itemsdebit,quantitydebit

                    bill = Me.dgdCus.Item("hbl", index).Value
                    customer = Me.dgdCus.Item("CustomerIDdebit", index).Value
                    itemsdebit = Me.dgdCus.Item("itemsdebit", index).Value
                    ' quantitydebit = Me.dgdCus.Item("quantitydebit", index).Value

                    sqlI = " select * from " & TableFreightDept & " where " & TableFreightDeptID & "='" & Me.dgdCus.Item("freightid", index).Value & "'" 'hbl='" & bill & "' and CustomerIDDebit" & i & "='" & customer & "' and itemsdebit" & i & " LIKE N'%" & itemsdebit & "%' and quantitydebit" & i & "='" & quantitydebit & "' "
                    rs.Open(sqlI, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If Not rs.EOF Then

                        rs.Fields("PayCheck").Value = True
                        rs.Fields("ngay").Value = Me.dtpDate.Value.Date.ToString.Replace("12:00:00 AM", "")
                        rs.Fields("Ngayhoadon").Value = Me.txtInvoiceNo.Text
                        rs.Fields("approve").Value = True
                        rs.Update()
                    End If

                    'rs.Update()

                    'rs.Requery()

                    rs.Close()






                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
                '-------------------



                Try



                Catch ex As Exception

                End Try
            Else
                Try
                    ' lay customer,itemsdebit,quantitydebit

                    bill = Me.dgdCus.Item("hbl", index).Value
                    customer = Me.dgdCus.Item("CustomerIDdebit", index).Value
                    itemsdebit = Me.dgdCus.Item("itemsdebit", index).Value
                    '  quantitydebit = Me.dgdCus.Item("quantitydebit", index).Value

                    sqlI = "select * from " & TableFreightDept & " where " & TableFreightDeptID & "='" & Me.dgdCus.Item("freightid", index).Value & "'" 'hbl='" & bill & "' and CustomerIDDebit" & i & "='" & customer & "' and itemsdebit" & i & " LIKE N'%" & itemsdebit & "%' and quantitydebit" & i & "='" & quantitydebit & "' "
                    rs.Open(sqlI, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If Not rs.EOF Then

                        rs.Fields("PayCheck").Value = False
                        rs.Fields("ngay").Value = "" 'Me.dtpDate.Value.Date.ToString.Replace("12:00:00 AM", "")
                        rs.Fields("Ngayhoadon").Value = "" 'Me.txtSophieuthu.Text
                        rs.Fields("approve").Value = False
                        rs.Update()
                    End If

                    'rs.Update()

                    'rs.Requery()

                    rs.Close()






                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
                '-------------------

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub addPayCheck_AllDebit(ByVal index As Integer, ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal TableFreightDept As String, ByVal TableFreightDeptID As String)
        Try

            Dim customer, itemsdebit, quantitydebit, bill As String
            Dim i As Integer
            Dim sqlI As String
            Dim dsI As New DataSet
            Dim rs As New ADODB.Recordset

            If Me.dgdCus1.Item("Checkprint1", index).Value = "True" Then
                ' insert vao 
                Try
                    ' lay customer,itemsdebit,quantitydebit

                    bill = Me.dgdCus1.Item("hbl1", index).Value
                    customer = Me.dgdCus1.Item("CustomerIDdebit1", index).Value
                    itemsdebit = Me.dgdCus1.Item("itemsdebit1", index).Value
                    ' quantitydebit = Me.dgdCus.Item("quantitydebit", index).Value

                    sqlI = " select * from " & TableFreightDept & " where " & TableFreightDeptID & "='" & Me.dgdCus1.Item("freightid1", index).Value & "'" 'hbl='" & bill & "' and CustomerIDDebit" & i & "='" & customer & "' and itemsdebit" & i & " LIKE N'%" & itemsdebit & "%' and quantitydebit" & i & "='" & quantitydebit & "' "
                    rs.Open(sqlI, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If Not rs.EOF Then

                        'rs.Fields("PayCheck").Value = True
                        rs.Fields("ngay").Value = Me.dtpDate.Value.Date.ToString.Replace("12:00:00 AM", "")
                        rs.Fields("Ngayhoadon").Value = Me.txtInvoiceNo.Text.Trim
                        rs.Update()
                    End If

                    'rs.Update()

                    'rs.Requery()

                    rs.Close()



                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
                '-------------------



                Try
                    'If Trim(Me.dgdCus.Item("currencydebit", index).Value) <> "VND" Then
                    '    giatruocthue += Me.dgdCus.Item("Pricetruocthuedebit", index).Value * Me.txtTigia.Text.Trim
                    '    Me.txtsotien.Text += Me.dgdCus.Item("Pricedebit", index).Value '* Me.txtTigia.Text.Trim
                    'Else
                    'giatruocthue += CDbl(Me.dgdCus.Item("Pricetruocthuedebit", index).Value)
                    'Me.txtsotien.Text += CDbl(Me.dgdCus.Item("Pricedebit", index).Value)
                    'End If


                Catch ex As Exception

                End Try
            Else
                Try
                    ' lay customer,itemsdebit,quantitydebit

                    bill = Me.dgdCus1.Item("hbl1", index).Value
                    customer = Me.dgdCus1.Item("CustomerIDdebit1", index).Value
                    itemsdebit = Me.dgdCus1.Item("itemsdebit1", index).Value
                    '  quantitydebit = Me.dgdCus.Item("quantitydebit", index).Value

                    sqlI = " select * from " & TableFreightDept & " where " & TableFreightDeptID & "='" & Me.dgdCus1.Item("freightid1", index).Value & "'" 'hbl='" & bill & "' and CustomerIDDebit" & i & "='" & customer & "' and itemsdebit" & i & " LIKE N'%" & itemsdebit & "%' and quantitydebit" & i & "='" & quantitydebit & "' "
                    rs.Open(sqlI, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If Not rs.EOF Then

                        ' rs.Fields("PayCheck").Value = False
                        rs.Fields("ngay").Value = "" 'Me.dtpDate.Value.Date.ToString.Replace("12:00:00 AM", "")
                        rs.Fields("Ngayhoadon").Value = "" 'Me.txtSophieuthu.Text
                        rs.Update()
                    End If

                    'rs.Update()

                    'rs.Requery()

                    rs.Close()


                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
                '-------------------

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Addthucthu(ByVal index As Integer)
        Try


            Dim rs As New ADODB.Recordset
            Dim strQuery, strQueryCommodityList As String
            Dim blnEmpty, blnEOF As Boolean

            Dim strMesg As String
            Dim bm As Short

            strQueryCommodityList = "Select * from debit where" + " debitID= '" & Me.dgdTaxInvoice.Item("debitID", index).Value.ToString & "'"
            rs.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Try
                rs.Fields("thucthu").Value = Me.txtthucthu.Text
            Catch ex As Exception
                rs.Fields("thucthu").Value = 0
            End Try

            rs.Fields("ngaythucthu").Value = Me.txtNgaythucthu.Text
            rs.Update()

            rs.Requery()

            rs.Close()

            'End If
            ' End If
        Catch ex As Exception
            DisplayMessage(True, msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.GroupBox4.Visible = False
    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub
    Private Sub GroupBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseMove, GroupBox4.MouseMove
        If Mdown Then
            Me.GroupBox4.Left = (e.X - X) + Me.GroupBox4.Left
            Me.GroupBox4.Top = (e.Y - Y) + Me.GroupBox4.Top
        End If
    End Sub

    Private Sub GroupBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox4.Left = (e.X - X) + Me.GroupBox4.Left
            Me.GroupBox4.Top = (e.Y - Y) + Me.GroupBox4.Top
        End If
    End Sub

    Private Sub fraUpdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.Enter

    End Sub

    Private Sub BáoCáoThuếToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BáoCáoThuếToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If LoginSucceeded = True Then
                Dim form As New frmBaocaoThue 'frmPrintInboundCoversheet_OverseaAirImport 'frmViewHistory 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            '  VB6.ShowForm(frmBaocaoThue, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        ' SOA()
    End Sub
    Public Sub getFreight(ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal TableFreightDept As String, ByVal TableFreightDeptID As String, ByVal tableFreightID As String)
        Try

            Dim i As Integer
            Dim sqlC As String
            Dim dsC As New DataSet
            Dim sql As String
            Dim sqli As String
            Dim dsi As New DataSet
            Dim ds As New DataSet
            Dim rowtang As Integer = 0
            'Me.cboCus.Items.Clear()
            'If Me.RadioOther.Checked = True Then
            '    Exit Sub
            'End If
            'If FindValueID(Me.cboCus, Me.cboCus.Text) = "" Then
            '    Me.dgdCus.Rows.Clear()
            '    Exit Sub
            'End If
            'Try

            sql = " select * from " & TableFreightDept & " left join " & TableDept & " on " & TableFreightDept & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where " & TableDeptID & " ='" & FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text) & "' and " & TableFreightDept & ".customerid='" & FindValueID(Me.cboCus, Me.cboCus.Text) & "' and debitcredit='Debit' order by " & TableFreightDept & ".stt "
            ds = ReadDataSet(sql)
            'Catch ex As Exception
            '    DisplayMessage(True, Err.Description)
            'End Try

            Me.dgdCus.Rows.Clear()

            If ds.Tables(0).Rows.Count > 0 Then
                ' kiem tra co phai tau cua SITC ko





                Me.txtref.Text = ds.Tables(0).Rows(0).Item("ref").ToString

                '--------------------------------------
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    Me.dgdCus.Rows.Add(1) ' dung chung blib_id
                    Me.dgdCus.Item("blib_id", rowtang).Value = ds.Tables(0).Rows(i).Item(TableDeptID).ToString
                    Me.dgdCus.Item("freightid", rowtang).Value = ds.Tables(0).Rows(i).Item(TableFreightDeptID).ToString
                    Me.dgdCus.Item("CustomerIDdebit", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString

                    Try
                        Me.dgdCus.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Catch ex As Exception
                        Me.dgdCus.Item("hbl", rowtang).Value = ""
                    End Try
                    Try
                        Me.dgdCus.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    Catch ex As Exception
                        Me.dgdCus.Item("hbl", rowtang).Value = ""
                    End Try

                    ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                    ''dsC = ReadDataSet(sqlC)
                    ''If dsC.Tables(0).Rows.Count > 0 Then
                    ''    Me.dgdCus.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                    ''End If
                    sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                    dsi = ReadDataSet(sqli)
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' Me.dgdCus.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                        Me.dgdCus.Item("Itemsdebit", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                    End If
                    Me.dgdCus.Item("itemid", rowtang).Value = ds.Tables(0).Rows(i).Item("itemid").ToString



                    'Me.dgdCus.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString

                    Me.dgdCus.Item("CONTAINER_TYPEdebit", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERTYPE").ToString
                    Me.dgdCus.Item("soluong", rowtang).Value = ds.Tables(0).Rows(i).Item("Quantity").ToString
                    Dim dongiaVAT As Double = 0

                    Dim tongVATVND As Double = 0
                    Try
                        If UCase(ds.Tables(0).Rows(i).Item("Currency").ToString.Trim) = "USD" Then
                            dongiaVAT = CDbl(ds.Tables(0).Rows(i).Item("unitprice_").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)


                            Me.dgdCus.Item("unitprice", rowtang).Value = System.Math.Truncate(dongiaVAT) '- (dongiaVAT * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1)
                            Me.dgdCus.Item("thanhtien", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("price_").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)) ' * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString))


                        Else

                            Me.dgdCus.Item("unitprice", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("unitprice_").ToString)) '- (Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString)) * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100)
                            Me.dgdCus.Item("thanhtien", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("price_").ToString)) ' * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString))

                        End If

                    Catch ex As Exception
                        Me.dgdCus.Item("unitprice", rowtang).Value = "0" 'CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                    End Try

                    'PA1=  Me.dgdCus.Item("thanhtien", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 0)

                    Me.dgdCus.Item("thue", rowtang).Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
                    'Me.dgdCus.Item("tienthue", rowtang).Value = ds.Tables(0).Rows(i).Item("pricethue").ToString
                    ' Me.dgdCus.Item("tong", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) - (CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100))
                    Me.dgdCus.Item("noteDebit", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                    Me.dgdCus.Item("paycheckDebit", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                    'Me.dgdCus.Item("chiho", rowtang).Value = ds.Tables(0).Rows(i).Item("chiho").ToString
                    rowtang += 1
                Next






            End If


            InsertAutoNumberToGrid(Me.dgdCus)
        Catch ex As Exception
            Me.dgdCus.Rows.Clear()
        End Try
    End Sub
    Public Sub getFreight_DOM(ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal TableFreightDept As String, ByVal TableFreightDeptID As String, ByVal tableFreightID As String)
        Try

            Dim i As Integer
            Dim sqlC As String
            Dim dsC As New DataSet
            Dim sql As String
            Dim sqli As String
            Dim dsi As New DataSet
            Dim ds As New DataSet
            Dim rowtang As Integer = 0
            'Me.cboCus.Items.Clear()
            'If Me.RadioOther.Checked = True Then
            '    Exit Sub
            'End If
            'If FindValueID(Me.cboCus, Me.cboCus.Text) = "" Then
            '    Me.dgdCus.Rows.Clear()
            '    Exit Sub
            'End If
            'Try

            sql = " select * from " & TableFreightDept & " left join " & TableDept & " on " & TableFreightDept & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where " & TableDeptID & " ='" & FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text) & "' and customerid='" & FindValueID(Me.cboCus, Me.cboCus.Text) & "' and debitcredit='Debit' order by " & TableFreightDept & ".stt "
            ds = ReadDataSet(sql)
            'Catch ex As Exception
            '    DisplayMessage(True, Err.Description)
            'End Try

            Me.dgdCus.Rows.Clear()

            If ds.Tables(0).Rows.Count > 0 Then
                ' kiem tra co phai tau cua SITC ko





                Me.txtref.Text = ds.Tables(0).Rows(0).Item("ref").ToString

                '--------------------------------------
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    Me.dgdCus.Rows.Add(1) ' dung chung blib_id
                    Me.dgdCus.Item("blib_id", rowtang).Value = ds.Tables(0).Rows(i).Item(TableDeptID).ToString
                    Me.dgdCus.Item("freightid", rowtang).Value = ds.Tables(0).Rows(i).Item(TableFreightDeptID).ToString
                    Me.dgdCus.Item("CustomerIDdebit", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString

                    Try
                        Me.dgdCus.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Catch ex As Exception
                        Me.dgdCus.Item("hbl", rowtang).Value = ""
                    End Try
                    Try
                        Me.dgdCus.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    Catch ex As Exception
                        Me.dgdCus.Item("hbl", rowtang).Value = ""
                    End Try

                    ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                    ''dsC = ReadDataSet(sqlC)
                    ''If dsC.Tables(0).Rows.Count > 0 Then
                    ''    Me.dgdCus.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                    ''End If
                    sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                    dsi = ReadDataSet(sqli)
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' Me.dgdCus.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                        Me.dgdCus.Item("Itemsdebit", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                    End If


                    Me.dgdCus.Item("itemid", rowtang).Value = ds.Tables(0).Rows(i).Item("itemid").ToString

                    'Me.dgdCus.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString

                    Me.dgdCus.Item("CONTAINER_TYPEdebit", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERTYPE").ToString
                    Me.dgdCus.Item("soluong", rowtang).Value = ds.Tables(0).Rows(i).Item("Quantity").ToString
                    Dim dongiaVAT As Double = 0

                    Dim tongVATVND As Double = 0
                    Try
                        If UCase(ds.Tables(0).Rows(i).Item("Currency").ToString.Trim) = "VND" Then
                            dongiaVAT = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 0) ' / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 0)
                            dongiaVAT += dongiaVAT * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100

                            Me.dgdCus.Item("unitprice", rowtang).Value = System.Math.Truncate(dongiaVAT) '- (dongiaVAT * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1)

                            'Else

                            '    Me.dgdCus.Item("unitprice", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString)) '- (Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString)) * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100)

                        End If

                    Catch ex As Exception
                        Me.dgdCus.Item("unitprice", rowtang).Value = "0" 'CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                    End Try

                    'PA1=  Me.dgdCus.Item("thanhtien", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 0)
                    Me.dgdCus.Item("thanhtien", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("price").ToString)) ' * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString))

                    Me.dgdCus.Item("thue", rowtang).Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
                    'Me.dgdCus.Item("tienthue", rowtang).Value = ds.Tables(0).Rows(i).Item("pricethue").ToString
                    ' Me.dgdCus.Item("tong", rowtang).Value = System.Math.Truncate(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) - (CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100))
                    Me.dgdCus.Item("noteDebit", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                    Me.dgdCus.Item("paycheckDebit", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                    'Me.dgdCus.Item("chiho", rowtang).Value = ds.Tables(0).Rows(i).Item("chiho").ToString
                    rowtang += 1
                Next






            End If


            InsertAutoNumberToGrid(Me.dgdCus)
        Catch ex As Exception
            Me.dgdCus.Rows.Clear()
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Add vao luoi

        Try
            ' Add vao luoi
            Try


                'Me.cboCus.Items.Clear()

                If FindValueID(Me.cboCus, Me.cboCus.Text) = "" Then
                    Me.dgdCus.Rows.Clear()
                    Exit Sub
                End If
                If Me.cboIOL.Text.Trim = "Agency-Export" Then
                    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound", "BLOB_ID", "OutboundFreight", "OutboundFreightID", "OutboundID")
                End If
                If Me.cboIOL.Text.Trim = "Agency-Import" Then
                    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound", "BLIB_ID", "InboundFreight", "InboundFreightID", "InboundID")
                    'gethbl("HBL", "Inbound", "BLIB_ID")
                End If

                'If Me.cboIOL.Text.Trim = "Oversea-Sea-Import" Then
                '    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaSeaimport", "BLIB_ID", "InboundFreight", "InboundFreightID", "InboundID")

                'End If
                'If Me.cboIOL.Text.Trim = "Oversea-Sea-Export" Then

                '    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaSeaExport", "BLOB_ID", "OutboundFreight", "OutboundFreightID", "OutboundID")

                'End If
                If Me.cboIOL.Text.Trim = "ACS-Air-Import" Then
                    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaAirImport", "BLIB_ID", "InboundFreight", "InboundFreightID", "InboundID")


                End If
                If Me.cboIOL.Text.Trim = "ACS-Air-Export" Then
                    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaAirExport", "BLOB_ID", "OutboundFreight", "OutboundFreightID", "OutboundID")


                End If
                'If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then

                '    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_ACSSeaExport", "BLOB_ID", "OutboundFreight", "OutboundFreightID", "OutboundID")


                'End If

                If Me.cboIOL.Text.Trim = "Logistics-Customs" Then
                    getFreight(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics", "BLOB_ID", "LogisticsFreight", "LogisticsFreightID", "LogisticsID")


                End If
                'If Me.cboIOL.Text.Trim = "Domestic-Truck" Then
                '    getFreight_DOM(FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics_Truck", "BLOB_ID", "LogisticsFreight", "LogisticsFreightID", "LogisticsID")


                'End If








                InsertAutoNumberToGrid(Me.dgdCus)
            Catch ex As Exception
                Me.dgdCus.Rows.Clear()
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboCus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus.SelectedIndexChanged

    End Sub

    Private Sub chkLogistics_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.QueryBillnumber()
    End Sub

    Private Sub dgdCus_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCus.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCus.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCus.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        Me.dgdCus.Rows(index).Selected = True
        Me.dgdCus.CurrentCell = Me.dgdCus.Rows(index).Cells(1)
        Me.dgdCus.EndEdit()
        If Me.dgdCus.Columns(ColIndex).Name = "CheckPrint" And Me.dgdCus.CurrentCellAddress().Y = index Then
            '  Call add(index)
            If Me.cboIOL.Text.Trim = "Agency-Export" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound", "BLOB_ID", "OutboundFreight", "OutboundFreightID")
            End If


            If Me.cboIOL.Text.Trim = "Agency-Import" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound", "BLIB_ID", "InboundFreight", "InboundFreightID")
            End If

            If Me.cboIOL.Text.Trim = "Oversea-Sea-Import" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaSeaimport", "BLIB_ID", "InboundFreight", "InboundFreightID")

            End If
            If Me.cboIOL.Text.Trim = "Oversea-Sea-Export" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaSeaExport", "BLOB_ID", "OutboundFreight", "OutboundFreightID")

            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Import" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaAirImport", "BLIB_ID", "InboundFreight", "InboundFreightID")


            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Export" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaAirExport", "BLOB_ID", "OutboundFreight", "OutboundFreightID")


            End If
            If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_ACSSeaExport", "BLOB_ID", "OutboundFreight", "OutboundFreightID")



            End If

            If Me.cboIOL.Text.Trim = "Logistics-Customs" Then

                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics", "BLOB_ID", "LogisticsFreight", "LogisticsFreightID")


            End If
            If Me.cboIOL.Text.Trim = "Domestic-Truck" Then
                addPayCheck(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics_Truck", "BLOB_ID", "LogisticsFreight", "LogisticsFreightID")



            End If




            'QueryShipper(mFilter, , index)
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Public Sub add(ByVal index As Integer)

        'Me.txtsotien.Text = giasauthue
    End Sub

    Private Sub HóaĐơnThườngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HóaĐơnThườngToolStripMenuItem.Click
        On Error GoTo Err

        Dim index As Integer
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdTaxInvoice.Rows.Count > 0 Then
            index = Me.dgdTaxInvoice.CurrentRow.Index
        Else
            Exit Sub
        End If
        gTaxInvoiceID = Me.dgdTaxInvoice.Item("debitID", index).Value.ToString.Trim


        'VB6.ShowForm(frmRptBillInBound, VB6.FormShowConstants.Modal, Me)

        '   Dim frm As New frmPrintVAT
        '  frm.Show()
        If LoginSucceeded = True Then
            Dim form As New frmPrintDebit 'frmPrintInboundCoversheet_OverseaAirImport 'frmViewHistory 'frmInbound 'frmQuotationTico
            form.MdiParent = frmMain
            form.Show()
        End If

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub HóaĐơnXuấtKhẩuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HóaĐơnXuấtKhẩuToolStripMenuItem.Click
        On Error GoTo Err

        Dim index As Integer
        Dim chk As Integer
        chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdTaxInvoice.Rows.Count > 0 Then
            index = Me.dgdTaxInvoice.CurrentRow.Index
        Else
            Exit Sub
        End If
        gTaxInvoiceID = Me.dgdTaxInvoice.Item("debitID", index).Value.ToString.Trim


        'VB6.ShowForm(frmRptBillInBound, VB6.FormShowConstants.Modal, Me)

        Dim frm As New frmPrintVAT_Xuatkhau
        frm.Show()


        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub AttachListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttachListToolStripMenuItem.Click
        Try


            Dim index As Integer
            Dim chk As Integer
            chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdTaxInvoice.Rows.Count > 0 Then
                index = Me.dgdTaxInvoice.CurrentRow.Index
            Else
                Exit Sub
            End If

            gTaxInvoiceID = Me.dgdTaxInvoice.Item("debitID", index).Value.ToString.Trim
            gTaxInvoice_cusID = Me.dgdTaxInvoice.Item("Customer_ID", index).Value.ToString.Trim
            gSohoadon = Me.dgdTaxInvoice.Item("invoiceno", index).Value.ToString.Trim
            'VB6.ShowForm(frmRptBillInBound, VB6.FormShowConstants.Modal, Me)

            Dim frm As New frmPrintVAT_Attach
            frm.Show()




        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ' lay customerid
            'tim kiem trong outbound/inbound/logistics order by
            ' show 1 group the hien cac phi debit
            Me.GroupBox3.BringToFront()
            Me.dgdCus1.Rows.Clear()
            If Me.cboCustomer.Text = "" Then
                Exit Sub
            End If
            Dim cusid As String = FindValueID(Me.cboCustomer, Me.cboCustomer.Text)
            Dim i As Integer
            Dim sqlC As String
            Dim dsC As New DataSet
            Dim sql As String
            Dim sqli As String
            Dim dsi As New DataSet
            Dim ds As New DataSet
            Dim rowtang As Integer = 0
            'Me.cboCus.Items.Clear()

            Try

                sql = " select * from inboundfreight left join inbound on inboundfreight.inboundid= inbound.blib_id where customerid='" & FindValueID(Me.cboCustomer, Me.cboCustomer.Text) & "' and debitcredit='Debit' order by hbl "
                ds = ReadDataSet(sql)
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try



            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    Me.dgdCus1.Rows.Add(1) ' dung chung blib_id
                    Me.dgdCus1.Item("blib_id1", rowtang).Value = ds.Tables(0).Rows(i).Item("inboundid").ToString
                    Me.dgdCus1.Item("freightid1", rowtang).Value = ds.Tables(0).Rows(i).Item("inboundfreightid").ToString
                    Me.dgdCus1.Item("CustomerIDdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString
                    Me.dgdCus1.Item("sohoadon", rowtang).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                    Me.dgdCus1.Item("etaetd1", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                    Me.dgdCus1.Item("hbl1", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                    ''dsC = ReadDataSet(sqlC)
                    ''If dsC.Tables(0).Rows.Count > 0 Then
                    ''    Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                    ''End If
                    sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                    dsi = ReadDataSet(sqli)
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                        Me.dgdCus1.Item("Itemsdebit1", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                    End If




                    'Me.dgdcus1.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString

                    Me.dgdCus1.Item("CONTAINER_TYPEdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERTYPE").ToString
                    Me.dgdCus1.Item("soluong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("Quantity").ToString, 2)
                    Try
                        Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                    Catch ex As Exception
                        Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                    End Try

                    Me.dgdCus1.Item("thanhtien1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 2)
                    Me.dgdCus1.Item("thue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("taxprice").ToString, 2)
                    Me.dgdCus1.Item("tienthue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricethue").ToString, 2)
                    Me.dgdCus1.Item("tong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                    Me.dgdCus1.Item("noteDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                    Me.dgdCus1.Item("paycheckDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                    rowtang += 1
                Next

            Else
                ' hang xuat

                sql = " select * from outboundfreight left join outbound on outboundfreight.outboundid= outbound.blob_id where customerid='" & FindValueID(Me.cboCustomer, Me.cboCustomer.Text) & "' and debitcredit='Debit' order by mblmawb "
                ds = ReadDataSet(sql)

                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1



                        Me.dgdCus1.Rows.Add(1) ' dung chung blib_id
                        Me.dgdCus1.Item("blib_id1", rowtang).Value = ds.Tables(0).Rows(i).Item("outboundid").ToString
                        Me.dgdCus1.Item("CustomerIDdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString
                        Me.dgdCus1.Item("freightid1", rowtang).Value = ds.Tables(0).Rows(i).Item("outboundfreightid").ToString
                        Me.dgdCus1.Item("etaetd1", rowtang).Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString
                        Me.dgdCus1.Item("hbl1", rowtang).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                        ''dsC = ReadDataSet(sqlC)
                        ''If dsC.Tables(0).Rows.Count > 0 Then
                        ''    Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                        ''End If
                        Me.dgdCus1.Item("sohoadon", rowtang).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                        sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                        dsi = ReadDataSet(sqli)
                        If dsi.Tables(0).Rows.Count > 0 Then
                            ' Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                            Me.dgdCus1.Item("Itemsdebit1", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                        End If

                        Me.dgdCus1.Item("soluong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("Quantity").ToString, 2)
                        Try
                            Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                        Catch ex As Exception
                            Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                        End Try


                        'Me.dgdcus1.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString
                        Me.dgdCus1.Item("CONTAINER_TYPEdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERtYPE").ToString
                        'Me.dgdcus1.Item("CONTAINER_TYPEdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CONTAINER_TYPEdebit1").ToString
                        'Me.dgdcus1.Item("QuantityDebit", rowtang).Value = ds.Tables(0).Rows(0).Item("QuantityDebit1").ToString
                        Me.dgdCus1.Item("thanhtien1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 2)
                        Me.dgdCus1.Item("thue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("taxprice").ToString, 2)
                        Me.dgdCus1.Item("tienthue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricethue").ToString, 2)
                        Me.dgdCus1.Item("tong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                        Me.dgdCus1.Item("noteDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                        Me.dgdCus1.Item("paycheckDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                        rowtang += 1
                    Next
                Else
                    '' logistics
                    'sql = " select * from logistics where blob_id ='" & FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text) & "'"
                    'ds = ReadDataSet(sql)
                    sql = " select * from logisticsfreight left join logistics on logisticsfreight.logisticsid= logistics.blob_id where customerid='" & FindValueID(Me.cboCustomer, Me.cboCustomer.Text) & "' and debitcredit='Debit' order by ref "
                    ds = ReadDataSet(sql)

                    If ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1



                            Me.dgdCus1.Rows.Add(1) ' dung chung blib_id
                            Me.dgdCus1.Item("blib_id1", rowtang).Value = ds.Tables(0).Rows(i).Item("logisticsid").ToString
                            Me.dgdCus1.Item("CustomerIDdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString
                            Me.dgdCus1.Item("etaetd1", rowtang).Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString
                            Me.dgdCus1.Item("freightid1", rowtang).Value = ds.Tables(0).Rows(i).Item("logisticsfreightid").ToString
                            Me.dgdCus1.Item("hbl1", rowtang).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                            Me.dgdCus1.Item("sohoadon", rowtang).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                            ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                            ''dsC = ReadDataSet(sqlC)
                            ''If dsC.Tables(0).Rows.Count > 0 Then
                            ''    Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                            ''End If
                            sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                            dsi = ReadDataSet(sqli)
                            If dsi.Tables(0).Rows.Count > 0 Then
                                ' Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                                Me.dgdCus1.Item("Itemsdebit1", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                            End If

                            Me.dgdCus1.Item("soluong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("Quantity").ToString, 2)
                            Try
                                Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                            Catch ex As Exception
                                Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                            End Try


                            'Me.dgdcus1.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString
                            Me.dgdCus1.Item("CONTAINER_TYPEdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERTYPE").ToString
                            'Me.dgdcus1.Item("CONTAINER_TYPEdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CONTAINER_TYPEdebit1").ToString
                            'Me.dgdcus1.Item("QuantityDebit", rowtang).Value = ds.Tables(0).Rows(0).Item("QuantityDebit1").ToString
                            Me.dgdCus1.Item("thanhtien1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 2)
                            Me.dgdCus1.Item("thue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("taxprice").ToString, 2)
                            Me.dgdCus1.Item("tienthue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricethue").ToString, 2)
                            Me.dgdCus1.Item("tong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                            Me.dgdCus1.Item("noteDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                            Me.dgdCus1.Item("paycheckDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                            rowtang += 1
                        Next





                    End If

                End If
            End If

            InsertAutoNumberToGrid(Me.dgdCus1)



            Me.GroupBox3.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub dgdCus1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCus1.CellContentClick
        Try

            Dim ColIndex, RowIndex As Integer
            ' Xác định vị trí row trong grid
            If Me.dgdCus1.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdCus1.CurrentRow.Index
            If Me.txtInvoiceNo.Text = "" Then
                DisplayMessage(True, "Số Hóa đơn rỗng.!")
                Exit Sub
            End If
            ColIndex = e.ColumnIndex()
            RowIndex = e.RowIndex
            If ColIndex < 0 Then
                Return
            End If
            Me.dgdCus1.Rows(index).Selected = True
            Me.dgdCus1.CurrentCell = Me.dgdCus1.Rows(index).Cells(1)
            Me.dgdCus1.EndEdit()
            If Me.dgdCus1.Columns(ColIndex).Name = "CheckPrint1" And Me.dgdCus1.CurrentCellAddress().Y = index Then
                ' update /''invoiceno = so hoa don 
                If Me.cboIOL.Text.Trim = "Agency-Export" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound", "BLOB_ID", "OutboundFreight", "OutboundID")
                End If


                If Me.cboIOL.Text.Trim = "Agency-Import" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound", "BLIB_ID", "InboundFreight", "InboundID")
                End If

                If Me.cboIOL.Text.Trim = "Oversea-Sea-Import" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaSeaimport", "BLIB_ID", "InboundFreight", "InboundID")

                End If
                If Me.cboIOL.Text.Trim = "Oversea-Sea-Export" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaSeaExport", "BLOB_ID", "OutboundFreight", "OutboundID")

                End If
                If Me.cboIOL.Text.Trim = "ACS-Air-Import" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Inbound_OverseaAirImport", "BLIB_ID", "InboundFreight", "InboundID")


                End If
                If Me.cboIOL.Text.Trim = "ACS-Air-Export" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_OverseaAirExport", "BLOB_ID", "OutboundFreight", "OutboundID")


                End If
                If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Outbound_ACSSeaExport", "BLOB_ID", "OutboundFreight", "OutboundID")



                End If

                If Me.cboIOL.Text.Trim = "Logistics-Customs" Then

                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics", "BLOB_ID", "LogisticsFreight", "LogisticsID")


                End If
                If Me.cboIOL.Text.Trim = "Domestic-Truck" Then
                    addPayCheck_AllDebit(index, FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text), "Logistics_Truck", "BLOB_ID", "LogisticsFreight", "LogisticsID")



                End If


            End If



        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub add1(ByVal index As Integer)


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Me.GroupBox3.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox3.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox3.MouseMove
        If Mdown Then
            Me.GroupBox3.Left = (e.X - X) + Me.GroupBox3.Left
            Me.GroupBox3.Top = (e.Y - Y) + Me.GroupBox3.Top
        End If
    End Sub

    Private Sub GroupBox3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox3.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox3.Left = (e.X - X) + Me.GroupBox3.Left
            Me.GroupBox3.Top = (e.Y - Y) + Me.GroupBox3.Top
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            ' lay customerid
            'tim kiem trong outbound/inbound/logistics order by
            ' show 1 group the hien cac phi debit
            Me.dgdCus1.Rows.Clear()
            Dim cusid As String = FindValueID(Me.cboCustomer, Me.cboCustomer.Text)
            Dim i As Integer
            Dim sqlC As String
            Dim dsC As New DataSet
            Dim sql As String
            Dim sqli As String
            Dim dsi As New DataSet
            Dim ds As New DataSet
            Dim rowtang As Integer = 0
            'Me.cboCus.Items.Clear()

            Try

                sql = " select * from inboundfreight left join inbound on inboundfreight.inboundid= inbound.blib_id where customerid='" & FindValueID(Me.cboCustomer, Me.cboCustomer.Text) & "' and debitcredit='Debit' and (convert(datetime,eta) between '" & Me.dtpfrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "')  order by hbl "
                ds = ReadDataSet(sql)
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try



            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    Me.dgdCus1.Rows.Add(1) ' dung chung blib_id
                    Me.dgdCus1.Item("blib_id1", rowtang).Value = ds.Tables(0).Rows(i).Item("inboundid").ToString
                    Me.dgdCus1.Item("freightid1", rowtang).Value = ds.Tables(0).Rows(i).Item("inboundfreightid").ToString
                    Me.dgdCus1.Item("CustomerIDdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString
                    Me.dgdCus1.Item("sohoadon", rowtang).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                    Me.dgdCus1.Item("etaetd1", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                    Me.dgdCus1.Item("hbl1", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                    ''dsC = ReadDataSet(sqlC)
                    ''If dsC.Tables(0).Rows.Count > 0 Then
                    ''    Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                    ''End If
                    sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                    dsi = ReadDataSet(sqli)
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                        Me.dgdCus1.Item("Itemsdebit1", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                    End If




                    'Me.dgdcus1.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString

                    Me.dgdCus1.Item("CONTAINER_TYPEdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERTYPE").ToString
                    Me.dgdCus1.Item("soluong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("Quantity").ToString, 2)
                    Try
                        Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                    Catch ex As Exception
                        Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                    End Try

                    Me.dgdCus1.Item("thanhtien1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 2)
                    Me.dgdCus1.Item("thue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("taxprice").ToString, 2)
                    Me.dgdCus1.Item("tienthue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricethue").ToString, 2)
                    Me.dgdCus1.Item("tong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                    Me.dgdCus1.Item("noteDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                    Me.dgdCus1.Item("paycheckDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                    rowtang += 1
                Next

            Else
                ' hang xuat

                sql = " select * from outboundfreight left join outbound on outboundfreight.outboundid= outbound.blob_id where customerid='" & FindValueID(Me.cboCustomer, Me.cboCustomer.Text) & "' and debitcredit='Debit' and (convert(datetime,sailingdate) between '" & Me.dtpfrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "') order by mblmawb "
                ds = ReadDataSet(sql)

                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1



                        Me.dgdCus1.Rows.Add(1) ' dung chung blib_id
                        Me.dgdCus1.Item("blib_id1", rowtang).Value = ds.Tables(0).Rows(i).Item("outboundid").ToString
                        Me.dgdCus1.Item("CustomerIDdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString
                        Me.dgdCus1.Item("freightid1", rowtang).Value = ds.Tables(0).Rows(i).Item("outboundfreightid").ToString
                        Me.dgdCus1.Item("etaetd1", rowtang).Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString
                        Me.dgdCus1.Item("hbl1", rowtang).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Me.dgdCus1.Item("sohoadon", rowtang).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                        ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                        ''dsC = ReadDataSet(sqlC)
                        ''If dsC.Tables(0).Rows.Count > 0 Then
                        ''    Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                        ''End If
                        sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                        dsi = ReadDataSet(sqli)
                        If dsi.Tables(0).Rows.Count > 0 Then
                            ' Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                            Me.dgdCus1.Item("Itemsdebit1", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                        End If

                        Me.dgdCus1.Item("soluong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("Quantity").ToString, 2)
                        Try
                            Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                        Catch ex As Exception
                            Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                        End Try


                        'Me.dgdcus1.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString
                        Me.dgdCus1.Item("CONTAINER_TYPEdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERtYPE").ToString
                        'Me.dgdcus1.Item("CONTAINER_TYPEdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CONTAINER_TYPEdebit1").ToString
                        'Me.dgdcus1.Item("QuantityDebit", rowtang).Value = ds.Tables(0).Rows(0).Item("QuantityDebit1").ToString
                        Me.dgdCus1.Item("thanhtien1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 2)
                        Me.dgdCus1.Item("thue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("taxprice").ToString, 2)
                        Me.dgdCus1.Item("tienthue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricethue").ToString, 2)
                        Me.dgdCus1.Item("tong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                        Me.dgdCus1.Item("noteDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                        Me.dgdCus1.Item("paycheckDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                        rowtang += 1
                    Next
                Else
                    '' logistics
                    'sql = " select * from logistics where blob_id ='" & FindValueID(Me.cbobillnumber, Me.cbobillnumber.Text) & "'"
                    'ds = ReadDataSet(sql)
                    sql = " select * from logisticsfreight left join logistics on logisticsfreight.logisticsid= logistics.blob_id where customerid='" & FindValueID(Me.cboCustomer, Me.cboCustomer.Text) & "' and debitcredit='Debit' and (convert(datetime,sailingdate) between '" & Me.dtpfrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "') order by ref "
                    ds = ReadDataSet(sql)

                    If ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1



                            Me.dgdCus1.Rows.Add(1) ' dung chung blib_id
                            Me.dgdCus1.Item("blib_id1", rowtang).Value = ds.Tables(0).Rows(i).Item("logisticsid").ToString
                            Me.dgdCus1.Item("CustomerIDdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CustomerID").ToString
                            Me.dgdCus1.Item("etaetd1", rowtang).Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString
                            Me.dgdCus1.Item("freightid1", rowtang).Value = ds.Tables(0).Rows(i).Item("logisticsfreightid").ToString
                            Me.dgdCus1.Item("hbl1", rowtang).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                            Me.dgdCus1.Item("sohoadon", rowtang).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                            ''sqlC = " select * from customer where customer_id='" & ds.Tables(0).Rows(0).Item("CustomerIDdebit1").ToString & "'"
                            ''dsC = ReadDataSet(sqlC)
                            ''If dsC.Tables(0).Rows.Count > 0 Then
                            ''    Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString
                            ''End If
                            sqli = " select * from charge where charge_id='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "'"
                            dsi = ReadDataSet(sqli)
                            If dsi.Tables(0).Rows.Count > 0 Then
                                ' Me.dgdcus1.Item("customer", rowtang).Value = dsC.Tables(0).Rows(0).Item("company").ToString

                                Me.dgdCus1.Item("Itemsdebit1", rowtang).Value = dsi.Tables(0).Rows(0).Item("charge").ToString

                            End If

                            Me.dgdCus1.Item("soluong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("Quantity").ToString, 2)
                            Try
                                Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                            Catch ex As Exception
                                Me.dgdCus1.Item("unitprice1", rowtang).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)

                            End Try


                            'Me.dgdcus1.Item("CURRENCYdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CURRENCYdebit1").ToString
                            Me.dgdCus1.Item("CONTAINER_TYPEdebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("CONTAINERTYPE").ToString
                            'Me.dgdcus1.Item("CONTAINER_TYPEdebit", rowtang).Value = ds.Tables(0).Rows(0).Item("CONTAINER_TYPEdebit1").ToString
                            'Me.dgdcus1.Item("QuantityDebit", rowtang).Value = ds.Tables(0).Rows(0).Item("QuantityDebit1").ToString
                            Me.dgdCus1.Item("thanhtien1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 2)
                            Me.dgdCus1.Item("thue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("taxprice").ToString, 2)
                            Me.dgdCus1.Item("tienthue1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("pricethue").ToString, 2)
                            Me.dgdCus1.Item("tong1", rowtang).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                            Me.dgdCus1.Item("noteDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("Note").ToString
                            Me.dgdCus1.Item("paycheckDebit1", rowtang).Value = ds.Tables(0).Rows(i).Item("payCheck").ToString
                            rowtang += 1
                        Next





                    End If

                End If
            End If

            InsertAutoNumberToGrid(Me.dgdCus1)



            Me.GroupBox3.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub ViewHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHistoryToolStripMenuItem.Click
        Try
            Try


                Dim sqlkt As String
                Dim dskt As New DataSet
                Dim Approve, EditTable, UsrRight As Boolean

                'kiểm tra xem Grid có dữ liệu không

                If Me.dgdTaxInvoice.RowCount = 0 Then
                    DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                    Return
                End If
                Dim index As Integer = Me.dgdTaxInvoice.CurrentRow.Index


                If index >= 0 Then



                    gViewHistory = Me.dgdTaxInvoice.Item("debitID", index).Value.ToString

                    frmViewHistory.Show()

                End If

            Catch ex As Exception
                MsgBox(msgErr(Me, Err.Description))
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If Me.cboIOL.Text.Trim = "Agency-Import" Then 'ok
                gethbl_Search("HBL", "Inbound", "BLIB_ID")
            End If
            If Me.cboIOL.Text.Trim = "Agency-Export" Then 'ok
                gethbl_Search("MBLMAWB", "Outbound", "BLOB_ID")
            End If
            'If Me.cboIOL.Text.Trim = "Oversea-Sea-Import" Then
            '    gethbl_Search("HBL", "Inbound_OverseaSeaimport", "BLIB_ID")
            'End If
            'If Me.cboIOL.Text.Trim = "Oversea-Sea-Export" Then
            '    gethbl_Search("MBLMAWB", "Outbound_OverseaSeaExport", "BLOB_ID")
            'End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Import" Then 'ok
                gethbl_Search("HBL", "Inbound_OverseaAirImport", "BLIB_ID")
            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Export" Then 'ok
                gethbl_Search("MBLMAWB", "Outbound_OverseaAirExport", "BLOB_ID")
            End If
            'If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
            '    gethbl_Search("MBLMAWB", "Outbound_ACSSeaExport", "BLOB_ID")
            'End If

            If Me.cboIOL.Text.Trim = "Logistics-Customs" Then 'ok
                gethbl_Search("MBLMAWB", "Logistics", "BLOB_ID")
            End If
            'If Me.cboIOL.Text.Trim = "Domestic-Truck" Then
            '    gethbl_Search("MBLMAWB", "Logistics_Truck", "BLOB_ID")
            'End If
            'If Me.RadioIn.Checked = True Then
            '    sql = "select * from inbound where hbl like '%" & Me.txttimBill.Text & "%' "
            '    ds = ReadDataSet(sql)
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        Me.cbobillnumber.Text = ds.Tables(0).Rows(0).Item("hbl").ToString
            '    End If
            'End If
            'If Me.radioOut.Checked = True Then
            '    sql = "select * from outbound where mblmawb like '%" & Me.txttimBill.Text & "%' "
            '    ds = ReadDataSet(sql)
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        Me.cbobillnumber.Text = ds.Tables(0).Rows(0).Item("mblmawb").ToString
            '    End If
            'End If
            'If Me.chkLogistics.Checked = True Then
            '    sql = "select * from logistics where ref like '%" & Me.txttimBill.Text & "%' "
            '    ds = ReadDataSet(sql)
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        Me.cbobillnumber.Text = ds.Tables(0).Rows(0).Item("ref").ToString
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ThựcThuNgàyThựcThuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuthucthu.Click
        Try
            Dim chk As Integer
            chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            Dim index As Integer = Me.dgdTaxInvoice.CurrentRow.Index
            Me.txtthucthu.Text = Me.dgdTaxInvoice.Item("thucthu", index).Value.ToString
            Me.txtNgaythucthu.Text = Me.dgdTaxInvoice.Item("ngaythucthu", index).Value.ToString
            Me.groupThucthu.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            queryTuDen()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try


            If Me.txtthucthu.Text = "" Then
                Exit Sub
            End If
            Dim chk As Integer
            chk = Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            Dim selectedRowCount As Integer = _
           Me.dgdTaxInvoice.Rows.GetRowCount(DataGridViewElementStates.Selected)
            Dim f As Integer = 0
            If selectedRowCount = 1 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    Addthucthu(Me.dgdTaxInvoice.SelectedRows(i).Index)
                    f = 1
                Next i
            End If
            'If f = 1 Then frmMain.LoadData()
            'If mFilter = "" Then
            '    DisplayMessage(True, "Xin chọn Lọc thông tin để lấy dữ liệu.")
            '    Return
            'Else

            '    Me.QueryDepartment(mFilter)
            'End If
            DisplayMessage(True, "OK")
            Me.RefreshToolStripMenuItem_Click(sender, e)
            Me.groupThucthu.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Me.groupThucthu.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub groupThucthu_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupThucthu.Enter

    End Sub
    Private Sub groupThucthu_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles groupThucthu.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub groupThucthu_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles groupThucthu.MouseMove
        If Mdown Then
            Me.groupThucthu.Left = (e.X - X) + Me.groupThucthu.Left
            Me.groupThucthu.Top = (e.Y - Y) + Me.groupThucthu.Top
        End If
    End Sub

    Private Sub groupThucthu_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles groupThucthu.MouseUp
        If Mdown Then
            Mdown = False
            Me.groupThucthu.Left = (e.X - X) + Me.groupThucthu.Left
            Me.groupThucthu.Top = (e.Y - Y) + Me.groupThucthu.Top
        End If
    End Sub
    Public Function chuyenNgay(ByVal chuoi As String) As String
        Try
            Dim ngay As String
            Dim thang As String
            Dim nam As String
            Dim ngayok, thangsosanh As String
            If chuoi = "" Then
                Exit Function
            Else
                If chuoi.Trim.Length = 6 Then
                    ngay = chuoi.Substring(0, 2)
                    thang = chuoi.Substring(2, 2)
                    nam = chuoi.Substring(4, 2)
                ElseIf chuoi.Trim.Length <> 11 Then

                    DisplayMessage(True, "Xim kiểm tra lại ngày !")
                    Return chuoi
                Else
                    Return chuoi
                    Exit Function
                End If
                ' lay thang
                Select Case UCase(thang)   ' 
                    Case "01"   '
                        thangsosanh = "JAN"
                    Case "02"   '
                        thangsosanh = "FEB"
                    Case "03" 'Or "MAR"   '
                        thangsosanh = "MAR"
                    Case "04" 'Or "APR"   '
                        thangsosanh = "APR"
                    Case "05" 'Or "MAY"   '
                        thangsosanh = "MAY"
                    Case "06" 'Or "JUN"   '
                        thangsosanh = "JUN"
                    Case "07" 'Or "JUL"   '
                        thangsosanh = "JUL"
                    Case "08" ' Or "AUG"   '
                        thangsosanh = "AUG"
                    Case "09" 'Or "SEP"   '
                        thangsosanh = "SEP"

                    Case "10" ' Or "OCT"   '
                        thangsosanh = "OCT"

                    Case "11" ' Or "NOV"   '
                        thangsosanh = "NOV"
                    Case "12" 'Or "DEC"   '
                        thangsosanh = "DEC"



                End Select
                '-----------------------
            End If
            ngayok = ngay + "-" + thangsosanh + "-" + "20" + nam

            Return ngayok
        Catch ex As Exception

        End Try
    End Function
    Private Sub txtNgaythucthu_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNgaythucthu.Leave
        Try
            Try
                Me.txtNgaythucthu.Text = chuyenNgay(Me.txtNgaythucthu.Text)
            Catch ex As Exception

            End Try
            ' Me.txtweek.Text = WeekOfYear(CDate(Me.txtdate2.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNgaythucthu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNgaythucthu.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub
    Public Sub tongtaxinvoice()
        Try
            Dim i As Integer
            Dim tongthanhtien As Double = 0
            Dim tongthucthu As Double = 0

            If Me.dgdTaxInvoice.Rows.Count > 0 Then
                For i = 0 To Me.dgdTaxInvoice.Rows.Count - 1
                    Try
                        tongthanhtien += Me.dgdTaxInvoice.Item("thanhtiensauthue", i).Value.ToString

                    Catch ex As Exception

                    End Try
                    Try
                        tongthucthu += Me.dgdTaxInvoice.Item("thucthu", i).Value.ToString

                    Catch ex As Exception

                    End Try

                Next
            End If

            Me.TXTTONGCONG.Text = FormatNumber(tongthanhtien.ToString, 0)
            Me.txttongthucthu.Text = FormatNumber(tongthucthu.ToString, 0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdTaxInvoice_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgdTaxInvoice.MouseMove
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Try
                Dim i, j As Integer
                For i = 0 To Me.dgdCus.Rows.Count - 1
                    Me.dgdCus.Item("checkprint", i).Value = True
                Next
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnutencongty.Click
        Try
            Me.smnutencongty.Checked = Not Me.smnutencongty.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub smnudiachi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnudiachi.Click
        Try
            Me.smnudiachi.Checked = Not Me.smnudiachi.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuquyenso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuquyenso.Click
        Try
            Me.smnuquyenso.Checked = Not Me.smnuquyenso.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuchitiethoadon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuchitiethoadon.Click
        Try
            Me.smnuchitiethoadon.Checked = Not Me.smnuchitiethoadon.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuchungtukemtheo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuchungtukemtheo.Click
        Try
            Me.smnuchungtukemtheo.Checked = Not Me.smnuchungtukemtheo.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuref.Click
        Try
            Me.smnuref.Checked = Not Me.smnuref.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HiểnThịVATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuhienthivat.Click
        Try
            Me.smnuhienthivat.Checked = Not Me.smnuhienthivat.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnungayphathanh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnungayphathanh.Click
        Try
            Me.smnungayphathanh.Checked = Not Me.smnungayphathanh.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuphuongthucthanhtoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuphuongthucthanhtoan.Click
        Try
            Me.smnuphuongthucthanhtoan.Checked = Not Me.smnuphuongthucthanhtoan.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnutentausochuyen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnutentausochuyen.Click
        Try
            Me.smnutentausochuyen.Checked = Not Me.smnutentausochuyen.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnunguoilap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnunguoilap.Click
        Try
            Me.smnunguoilap.Checked = Not Me.smnunguoilap.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnukhachhang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnukhachhang.Click
        Try
            Me.smnukhachhang.Checked = Not Me.smnukhachhang.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnucusd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnucusd.Click
        Try
            Me.smnucusd.Checked = Not Me.smnucusd.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnusodonghoadon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnusodonghoadon.Click
        Try
            Me.smnusodonghoadon.Checked = Not Me.smnusodonghoadon.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuuserupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuuserupdate.Click
        Try
            Me.smnuuserupdate.Checked = Not Me.smnuuserupdate.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnudateupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnudateupdate.Click
        Try
            Me.smnudateupdate.Checked = Not Me.smnudateupdate.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuhuy.Click
        Try
            Me.smnuhuy.Checked = Not Me.smnuhuy.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnulydohuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnulydohuy.Click
        Try
            Me.smnulydohuy.Checked = Not Me.smnulydohuy.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ApproveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApproveToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmApproveHoadon, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnusale.Click
        Try
            Me.smnusale.Checked = Not Me.smnusale.Checked
            UpdateFrame()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub gethbl(ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String)
        Try
            Dim id, strsql, value As String
            id = TableDeptID
            value = hbl
            Me.cbobillnumber.Items.Clear()


            strsql = "Select " & TableDeptID & "," & hbl & " From " & TableDept & " where branch like '%" & gBranch & "%' and Continued=1 order by " & hbl & " "
            loadDataToObject(Me.cbobillnumber, strsql, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub gethbl_Search(ByVal hbl As String, ByVal TableDept As String, ByVal TableDeptID As String)
        Try
            Dim id, strsql, value As String
            id = TableDeptID
            value = hbl
            Me.cbobillnumber.Items.Clear()


            strsql = "Select " & TableDeptID & "," & hbl & " From " & TableDept & " where branch like '%" & gBranch & "%' and Continued=1 and " & hbl & " like '%" & Me.txttimBill.Text & "%' order by " & hbl & " "
            loadDataToObject(Me.cbobillnumber, strsql, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cboIOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIOL.SelectedIndexChanged
        Try
            If Me.cboIOL.Text.Trim = "Agency-Import" Then
                gethbl("HBL", "Inbound", "BLIB_ID")
            End If
            If Me.cboIOL.Text.Trim = "Agency-Export" Then
                gethbl("MBLMAWB", "Outbound", "BLOB_ID")
            End If
            If Me.cboIOL.Text.Trim = "Oversea-Sea-Import" Then
                gethbl("HBL", "Inbound_OverseaSeaimport", "BLIB_ID")
            End If
            If Me.cboIOL.Text.Trim = "Oversea-Sea-Export" Then
                gethbl("MBLMAWB", "Outbound_OverseaSeaExport", "BLOB_ID")
            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Import" Then
                gethbl("HBL", "Inbound_OverseaAirImport", "BLIB_ID")
            End If
            If Me.cboIOL.Text.Trim = "ACS-Air-Export" Then
                gethbl("MBLMAWB", "Outbound_OverseaAirExport", "BLOB_ID")
            End If
            If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
                gethbl("MBLMAWB", "Outbound_ACSSeaExport", "BLOB_ID")
            End If

            If Me.cboIOL.Text.Trim = "Logistics-Customs" Then
                gethbl("MBLMAWB", "Logistics", "BLOB_ID")
            End If
            If Me.cboIOL.Text.Trim = "Domestic-Truck" Then
                gethbl("MBLMAWB", "Logistics_Truck", "BLOB_ID")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class