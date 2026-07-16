Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Text.RegularExpressions
'---------------------
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Net.WebRequest
Imports System.Net.WebClient
Imports System.Net
Imports System.IO
Public Class frmInbound_OverseaAirImport

    Inherits System.Windows.Forms.Form
    Public vitri As Integer
    Dim rsPortList As New ADODB.Recordset
    Dim mStatus, mFilter, mStatusHinh, mHinhID, mStatusContainer, mInboundContainerID, mStatusTheodoi, mStatusCashLoan As String
    Dim mStatusDebit, mStatusCredit, mdebitID, mCreditID, mTheodoiid, mCashLoanID As String

    Public blnUpdated As Boolean
    Public mInboundID As String
    Public mFlag As Integer = 0
    Public mText1 As String = ""
    Public mText2 As String = ""
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer
    Dim oTblEquip, otblHinh As New DataTable
    Const strCarrierSelect As String = "SELECT * "
    '" indate,outdate,currency,[20gp],[40gp],[40hc],[45hc],[20rf],[40rf],[40rh],[20ot],[40ot],[20fr],[40fr],cbm,ratedetail.remarks, " & _
    '"ratedetail.Continued, " & _
    '"ratedetail.Editable, " & _
    '"ratedetail.UserId, " & _
    '"ratedetail.Updatetime "

    '
    Dim PortPOLPOD As String
    Const strCarrierOrder1 As String = _
           " ORDER BY shippingline  "

    Sub QueryCombo()
        Try
            Dim id, value, strSQL As String
            Me.cboMBL.Items.Clear()
            id = "ref"
            value = "ref"
            If UCase(gDepartment) = "SALE" Then
                strSQL = "Select distinct ref From inbound_OverseaAirImport where  salecode='" & gSaleCode & "' and branch like '%" & gBranch & "%' and Continued=1 "
            Else
                If UCase(gDepartment) = "CUSTOMER" Or UCase(gDepartment) = "DOCUMENT" Then
                    strSQL = "Select distinct ref From inbound_OverseaAirImport where  branch like '%" & gBranch & "%' and Continued=1  "
                Else
                    strSQL = "Select distinct ref From inbound_OverseaAirImport where  branch like '%" & gBranch & "%' and Continued=1 "
                End If

            End If

            loadDataToObject(Me.cboMBL, strSQL, id, value)
            'loadDataToObject(Me.txtOPL, strSQL, id, value)
            'loadDataToObject(Me.txtPOD, strSQL, id, value)
            id = "blib_id"
            value = "hbl"
            Me.cboCopyHBL.Items.Clear()
            Me.cboCopyHBLFrom.Items.Clear()

            strSQL = "Select distinct blib_id,hbl From inbound_OverseaAirImport  where branch like '%" & gBranch & "%' and Continued=1 "
            loadDataToObject(Me.cboCopyHBL, strSQL, id, value)
            loadDataToObject(Me.cboCopyHBLFrom, strSQL, id, value)
            '----------------------------------------------
            Me.cboops.Items.Clear()
            id = "usr"
            value = "usr"
            strSQL = "Select  usr from userlist order by usr "
            loadDataToObject(Me.cboops, strSQL, id, value)
            '-----------------------------------------------
            Me.cboCY.Items.Clear()
            id = "terminalName"
            value = "terminalName"
            strSQL = "Select terminalName From terminal where Continued=1 Order By terminalName "
            loadDataToObject(Me.cboCY, strSQL, id, value)
            Me.cboCarrier.Items.Clear()
            id = "company"
            value = "company"
            strSQL = "Select company From customer where (maincode='Shipping' or maincode like '%Agent%') and Continued=1 Order By company "
            loadDataToObject(Me.cboCarrier, strSQL, id, value)
            Me.cboagency.Items.Clear()
            id = "Agency_Id"
            value = "AgencyName"
            Dim strQuery As String = "Select Agency_Id,AgencyName from agency where CONTINUED=1 Order by agencyname"
            loadDataToObject(Me.cboagency, strQuery, id, value)
            Me.cboShipper.Items.Clear()
            id = "shipper"
            value = "shipper"
            strQuery = "Select distinct Shipper from inbound_OverseaAirImport where CONTINUED=1 Order by shipper "
            loadDataToObject(Me.cboShipper, strQuery, id, value)

            'id = "consignee"
            'value = "consignee"
            'strQuery = "Select distinct consignee from inbound_OverseaAirImport where CONTINUED=1 Order by consignee "
            'loadDataToObject(Me.cboConsignee, strQuery, id, value)

            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where CONTINUED=1 Order by company "
            loadDataToObject(Me.cboConsignee, strQuery, id, value)


            Me.cboNotify.Items.Clear()
            id = "notify"
            value = "notify"
            strQuery = "Select distinct notify from inbound_OverseaAirImport where CONTINUED=1 Order by notify "
            loadDataToObject(Me.cboNotify, strQuery, id, value)

            Me.cboSale.Items.Clear()
            id = "salecode"
            value = "salecode"
            strQuery = "Select salecode from sale where CONTINUED=1 Order by salecode "
            loadDataToObject(Me.cboSale, strQuery, id, value)

            id = "id"
            value = "Name"
            strQuery = "Select id, Name from Header_Tarif where type ='Debit' Order by Name "
            Me.cbotarifheader.Items.Clear()
            loadDataToObject(Me.cbotarifheader, strQuery, id, value)

            id = "id"
            value = "Name"
            strQuery = "Select id, Name from Header_Tarif where type ='Credit' Order by Name "
            Me.cbotarifheader_Credit.Items.Clear()
            loadDataToObject(Me.cbotarifheader_Credit, strQuery, id, value)

            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,shortname as company from customer where CONTINUED=1 Order by company "
            Me.cbocusdebit.Items.Clear()
            Me.cbocuscredit.Items.Clear()
            Me.cboCustomer.Items.Clear()




            loadDataToObject(Me.cbocusdebit, strQuery, id, value)
            loadDataToObject(Me.cbocuscredit, strQuery, id, value)
            loadDataToObject(Me.cboCustomer, strQuery, id, value)


            '-----------------------------------------
            '-------------------------------------rieng cho glory


            '--------------------------------------------------

            ' them com

            Me.cboitemdebit.Items.Clear()

            '----------

            '---------------------
            Dim id_ As String
            Dim value_ As String
            Dim strQuery_ As String
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code from charge where CONTINUED=1 Order by charge_code "



            loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)
            loadDataToObject(Me.cboitemdebit, strQuery_, id_, value_)





            id = "charge"
            value = "charge"
            strQuery = "Select charge from charge where CONTINUED=1 Order by charge "

            Me.cboPOL.Items.Clear()
            id = "port_code"
            value = "port_code"
            strQuery = "Select  port_code from port  Order by port_code "
            loadDataToObject(Me.cboPOL, strQuery, id, value)
            loadDataToObject(Me.cbopodCode, strQuery, id, value)
            '-----------------
            Me.txtPOL.Items.Clear()
            id = "POL"
            value = "POL"
            strQuery = "Select distinct POL from inbound_OverseaAirImport where CONTINUED=1 Order by POL "
            loadDataToObject(Me.txtPOL, strQuery, id, value)

            Me.txtPOD.Items.Clear()
            id = "POd"
            value = "POd"
            strQuery = "Select distinct POd from inbound_OverseaAirImport where CONTINUED=1 Order by POd "
            loadDataToObject(Me.txtPOD, strQuery, id, value)


            Me.txtDel.Items.Clear()
            id = "del"
            value = "del"
            strQuery = "Select distinct del from inbound_OverseaAirImport where CONTINUED=1 Order by del "
            loadDataToObject(Me.txtDel, strQuery, id, value)

            Me.txtDest.Items.Clear()
            id = "dest"
            value = "dest"
            strQuery = "Select distinct dest from inbound_OverseaAirImport where CONTINUED=1 Order by dest "
            loadDataToObject(Me.txtDest, strQuery, id, value)



            'strSQL = "Select Currency  from Currency"
            'Dim tbl As New DataSet
            'tbl = ReadDataSet(strSQL)
            'Me.cboUnit.Items.Clear()
            'For i As Integer = 0 To tbl.Tables(0).Rows.Count - 1
            '    Me.cboUnit.Items.Add(tbl.Tables(0).Rows(i).Item("Currency"))
            'Next
            'If Me.cboUnit.Items.Count > 0 Then
            '    Me.cboUnit.SelectedIndex = 0
            'End If
            'quotationNo
            '  Me.cboquotationNo.Items.Clear()
            id = "quotationid"
            value = "quotationNo"
            If UCase(gDepartment) = "SALE" Then
                strQuery = "Select quotationid,quotationNo from quotation where salename ='" & strUserId & "' and branch like '%" & gBranch & "%' AND (quotationNo like '%IS%' or quotationNo like '%IN%') and approve=1  order by quotationNo "
            Else
                strQuery = "Select quotationid,quotationNo from quotation where branch like '%" & gBranch & "%'  AND (quotationNo like '%IS%' or quotationNo like '%IN%') and salename='" & Me.cboSale.Text & "' and approve=1  order by quotationNo "
            End If

            ' loadDataToObject(Me.cboquotationNo, strQuery, id, value)
            ' load agent
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 and maincode like '%agent%' Order by company "
            Me.cboAgent.Items.Clear()

            loadDataToObject(Me.cboAgent, strQuery, id, value)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SI()

        Try
            Dim id, value, strQuery As String
            ' Me.cboquotationNo.Items.Clear()
            id = "quotationid"
            value = "quotationNo"
            If UCase(gDepartment) = "SALE" Then
                strQuery = "Select quotationid,quotationNo from quotation where salename ='" & strUserId & "' and branch like '%" & gBranch & "%' AND (quotationNo like '%IS%' or quotationNo like '%IN%') order by quotationNo "
            Else
                strQuery = "Select quotationid,quotationNo from quotation where branch like '%" & gBranch & "%'  AND (quotationNo like '%IS%' or quotationNo like '%IN%') and salename='" & Me.cboSale.Text & "' order by quotationNo "
            End If

            '  loadDataToObject(Me.cboquotationNo, strQuery, id, value)

        Catch ex As Exception

        End Try
    End Sub
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        'Dim strMsg As String
        'CheckData = True
        'strMsg = ""
        'Dim strServiceId As String
        'If mStatus = "Add" Then
        '    strServiceId = DefaultValue

        '    Dim rs As New ADODB.Recordset
        '    Dim strquery As String
        '    strquery = "SELECT * "
        '    strquery = strquery & "FROM sERVICE "
        '    strquery = strquery & "WHERE Servicename = '" & Me.txtServicename.Text & "' And Continued=1"
        '    rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '    If Not rs.EOF Then
        '        CheckData = False
        '        rs.Close()
        '        DisplayMessage(True, "This Service had already in database")
        '        Exit Function
        '    End If
        'End If
        'If Len(Me.txtServicename.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Name is invalid. Please check again."
        'End If
        'If strMsg <> "" Then
        '    DisplayMessage(True, strMsg)
        'End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Public Sub allCus()
        Try
            Dim id, value, strQuery As String
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 Order by company "
            Me.cbocusdebit.Items.Clear()
            Me.cbocuscredit.Items.Clear()




            loadDataToObject(Me.cbocusdebit, strQuery, id, value)
            loadDataToObject(Me.cbocuscredit, strQuery, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Try


            Me.TabControl1.Visible = False
            ReFormat()

            Me.cmdOK.Enabled = False
            Me.cmdOKAll.Enabled = False
            mStatus = "Normal"
            reText(mStatus)
            Me.dgdHBL.Enabled = True
            Me.TabControl1.Enabled = False

            Dim cmd As New ADODB.Command


            Try
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from billonline where id= '" & mInboundID & "' and userupdate='" & strUserId & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
        'Me.Close()


    End Sub



    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Try


            Dim strQuery, strCarrierId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            'If Me.chkfcl.Checked = False And Me.chklcl.Checked = False And Me.chkconsol.Checked = False And Me.chkair.Checked = False Then
            '    DisplayMessage(True, "Kiểm tra loại hàng FCL,LCL,Consol.!")
            '    Exit Sub
            'End If
            If Me.CBOStatus.Text = "" Then
                DisplayMessage(True, "Status.?")
                Me.CBOStatus.Focus()
                Exit Sub
            End If
            If Me.cboCarrier.Text = "" Then
                DisplayMessage(True, "Carrier.?")
                Me.cboCarrier.Focus()
                Exit Sub
            End If
            If mStatus = "Edit" Then
                index = Me.dgdHBL.CurrentRow.Index
            End If
            If Me.txteta.Text = "" Then
                DisplayMessage(True, "ETA ?")
                Exit Sub
            End If
            If Me.cboitemSITC.Text = "" Then
                DisplayMessage(True, "Items ?")
                Me.cboitemSITC.Focus()
                Exit Sub
            End If

            'If Me.txteta.Text.ToString.Trim.Length = 11 Then
            'Else
            '    DisplayMessage(True, "ETD, ETA (dd-MMM-yyyy)")
            '    Exit Sub
            'End If

            'If Me.txtetd.Text.ToString.Trim.Length = 11 Then
            'Else
            '    DisplayMessage(True, "ETD, ETA (dd-MMM-yyyy)")
            '    Exit Sub
            'End If

            'If Me.txtDateTimeOfArrivalDeparture.MaskFull = False Then
            '    DisplayMessage(True, "Xin kiểm tra thời gian đến (E-Manifest)! ")
            '    ' Exit Sub
            'End If

            'If Me.txtdateOfMasterBill.MaskFull = False Then
            '    DisplayMessage(True, "Xin kiểm tra ngày phát hành Vận đơn gốc! ")
            '    'Exit Sub
            'End If

            'If Me.txtDateOfBillOfLading.MaskFull = False Then
            '    DisplayMessage(True, "Xin kiểm tra ngày phát hành Vận đơn! ")
            '    ' Exit Sub
            'End If


            'If Me.txtDepartureDate.MaskFull = False Then
            '    DisplayMessage(True, "Xin kiểm tra ngày khởi hành ! ")
            '    ' Exit Sub
            'End If
            If UserRight("inbound_OverseaAirImport", "Edit") Then


                If (mStatus = "Add" Or mStatus = "Edit") Then
                    Try
                        copyHistory("inbound_OverseaAirImport", "blib_id", mInboundID, "history")
                    Catch ex As Exception

                    End Try
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM inbound_OverseaAirImport "
                    strQuery = strQuery & "WHERE BLIB_ID = '" & mInboundID & "' and continued=1 "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("BLIB_ID").Value = NewId()
                        End If
                        strCarrierId = .Fields("BLIB_ID").Value
                        Try

                            Try
                                .Fields("pic_report").Value = Me.txtpic_report.Text
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("lot").Value = Me.txtlot.Text
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("canghangkhong").Value = Me.txtcanghangkhong.Text
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("benuyquyen").Value = Me.txtbenuyquyen.Text
                            Catch ex As Exception

                            End Try


                            Try
                                .Fields("volumndebit").Value = Me.txtvolumnDebit.Text
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("quotationNo").Value = Me.txtquotation.Text.Trim
                            Catch ex As Exception

                            End Try

                            ' them DO
                            Try
                                .Fields("DO_kinhgui").Value = Me.txtDO_Kinhgui.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("DO_Consignee").Value = Me.txtDO_Consignee.Text.Trim
                            Catch ex As Exception

                            End Try
                            ' them arrival
                            Try
                                .Fields("arrival_kinhgui").Value = Me.txtArrival_kinhgui.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("arrival_tau").Value = Me.txtArrival_tau.Text.Trim
                            Catch ex As Exception

                            End Try


                            Try
                                .Fields("arrival_chuyen").Value = Me.txtarrival_chuyen.Text.Trim
                            Catch ex As Exception

                            End Try


                            Try
                                .Fields("arrival_POL").Value = Me.txtarrival_pol.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("arrival_POd").Value = Me.txtarrival_pod.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("arrival_ETA").Value = Me.txtarrival_eta.Text.Trim
                            Catch ex As Exception

                            End Try


                            Try
                                .Fields("arrival_hbl").Value = Me.txtarrival_hbl.Text.Trim
                            Catch ex As Exception

                            End Try



                            Try
                                .Fields("arrival_mbl").Value = Me.txtarrival_mbl.Text.Trim
                            Catch ex As Exception

                            End Try


                            'Try
                            '    .Fields("arrival_soContSeal").Value = Me.txtarrival_socontseal.Text.Trim
                            'Catch ex As Exception

                            'End Try


                            Try
                                .Fields("arrival_soluong").Value = Me.txtarrival_soluong.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("arrival_chitiethanghoa").Value = Me.txtarrival_chitiethanghoa.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("arrival_trongluong").Value = Me.txtarrival_trongluong.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("arrival_khoiluong").Value = Me.txtarrival_khoiluong.Text.Trim
                            Catch ex As Exception

                            End Try

                            'Try
                            '    .Fields("arrival_BillType").Value = Me.txtarrival_billtype.Text.Trim
                            'Catch ex As Exception

                            'End Try


                            Try
                                .Fields("arrival_phi").Value = Me.txtarrival_phi.Text.Trim
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("arrival_tongcong").Value = Me.txtArrival_tongcong.Text.Trim
                            Catch ex As Exception

                            End Try



                            '---------------------------------

                            ' them agentID
                            Try
                                .Fields("agentid").Value = "{" + FindValueID(Me.cboAgent, Me.cboAgent.Text) + "}"
                            Catch ex As Exception

                            End Try
                            '-----------------------
                            Try
                                .Fields("InvoiceRequestDate").Value = ddMMMyyyy(CDate(Me.TXTInvoiceRequestDate.Text).Date)
                            Catch ex As Exception
                                DisplayMessage(True, Err.Description + " (InvoiceRequestDate) ")
                                .Fields("InvoiceRequestDate").Value = ""
                            End Try
                            '---------------
                            Try
                                .Fields("datereport").Value = ddMMMyyyy(Me.dtpDateReport.Value.Date)
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("cargo_ready").Value = ddMMMyyyy(Me.dtp_cargo_ready.Value.Date)
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("closing").Value = ddMMMyyyy(Me.dtp_closing.Value.Date)
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("status").Value = Me.CBOStatus.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("ops").Value = Me.cboops.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("polCode").Value = Me.cboPOL.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("podCode").Value = Me.cbopodCode.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                ' sitc
                                .Fields("itemSITC").Value = Me.cboitemSITC.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("email").Value = Me.cboemail.Text.Trim
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("TKHQ").Value = Me.TXTTKHQ.Text.Trim
                            Catch ex As Exception

                            End Try
                            '.Fields("sohoso").Value = Me.txtsohoso.Text.Trim
                            '.Fields("namdangkyhoso").Value = Me.txtnamdangky.Text.Trim

                            '.Fields("chucNangCuaChungTu").Value = Me.cboDocumentFunction.Text.Trim
                            '.Fields("loaichuyendi").Value = Me.cboLoaichuyendi.Text.Trim
                            '.Fields("tentau").Value = Me.txtNameOfShip.Text.Trim
                            '.Fields("soIMO").Value = Me.txtIMONumber.Text.Trim
                            '.Fields("thoiGianDen").Value = Me.txtDateTimeOfArrivalDeparture.Text.Trim
                            '.Fields("hohieu").Value = Me.txtCallSign.Text.Trim
                            '.Fields("nguoiGuiHang").Value = Me.txtconsigner.Text.Trim
                            '.Fields("nguoiNhanHang").Value = Me.txtconsignee_Manifest.Text.Trim

                            '.Fields("cangden").Value = Me.cbocangDen.Text.Trim
                            '.Fields("cangChuyentai").Value = Me.cboportOftransit.Text.Trim
                            '.Fields("cangGiaohang").Value = Me.cboPortOfDestination.Text.Trim
                            '.Fields("cangXephang").Value = Me.cboPortOfLoad.Text.Trim
                            '.Fields("cangDoHang").Value = Me.cboPortOfUnload.Text.Trim
                            '.Fields("soVanDon").Value = Me.txtBillOfLading.Text.Trim
                            '.Fields("ngayPhatHanhVanDon").Value = Me.txtDateOfBillOfLading.Text.Trim
                            '.Fields("soVanDonGoc").Value = Me.txtMasterBillNumber.Text.Trim
                            '.Fields("ngayPhatHanhVanDonGoc").Value = Me.txtdateOfMasterBill.Text.Trim
                            '.Fields("ngayKhoiHanh").Value = Me.txtDepartureDate.Text.Trim
                            '.Fields("tongSoKienLoaiKien").Value = Me.txtNumberAndKindOfPackage.Text.Trim
                            '.Fields("hscode").Value = Me.txthscode.Text.Trim

                            ' them e-manifest 
                            '.Fields("notify1").Value = Me.txtnotify1.Text.Trim
                            '.Fields("notify2").Value = Me.txtnotify2.Text.Trim
                            '.Fields("diadiemgiaohang").Value = Me.txtdiadiemgiaohang.Text.Trim
                            '.Fields("loaihang").Value = Me.txtloaihang.Text.Trim
                            '.Fields("ghichu").Value = Me.txtghichu.Text.Trim


                            '-----------------------
                        Catch ex As Exception

                        End Try
                        ' .Fields("tigia").Value = Me.txttigia.Text.Trim
                        .Fields("LCL").Value = Me.chklcl.Checked
                        .Fields("FCL").Value = Me.chkfcl.Checked
                        .Fields("Consol").Value = Me.chkconsol.Checked
                        '  .Fields("clockcredit").Value = Me.chkClockCredit.Checked
                        .Fields("air").Value = Me.chkair.Checked

                        ' them tong
                        '.Fields("tongsoluong").Value = Me.txttongsoluong.Text
                        '.Fields("tongsoluong1").Value = Me.txttongsoluong1.Text
                        '.Fields("tongsoluong2").Value = Me.txttongsoluong2.Text
                        '.Fields("loai").Value = Me.loai.Text
                        '.Fields("loai1").Value = Me.loai1.Text
                        '.Fields("loai2").Value = Me.loai2.Text
                        '.Fields("tongkien").Value = Me.tongkien.Text
                        '.Fields("tongkg").Value = Me.tongkg.Text
                        '.Fields("tongkhoi").Value = Me.tongkhoi.Text

                        '-------------------
                        ' add cach tinh com
                        '----------------------------------18-may-2013
                        'ItemCom


                        '-------------------------------------------------------------------------------------------
                        .Fields("bkkcomm").Value = IIf(Me.txtBKKComm.Text = "", 0, Me.txtBKKComm.Text)
                        .Fields("kho").Value = Me.txtKho.Text
                        .Fields("makho").Value = Me.txtMaKho.Text
                        .Fields("ManifestDate").Value = Me.txtManifest.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("sentHPGDate").Value = Me.txtSentHPG.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("closeFile").Value = Me.chkClose.Checked '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("nhanlenh").Value = Me.chkNhanlenh.Checked
                        .Fields("ngaynhanlenh").Value = Me.txtNgayNhanlenh.Text
                        .Fields("nguoinhanlenh").Value = Me.txtNguoinhanlenh.Text


                        .Fields("Mbl").Value = Me.txtMBL.Text
                        .Fields("hbl").Value = Me.txtHBL.Text
                        .Fields("ref").Value = Me.txtRef.Text
                        .Fields("CY_CFS_ITEM").Value = Me.txtTerms.Text
                        .Fields("bl_type").Value = Me.txtBL_Type.Text

                        .Fields("vessel").Value = Me.txtVessel.Text
                        .Fields("voyage").Value = Me.txtVoyage.Text
                        .Fields("ETA").Value = ddMMMyyyy(CDate(Me.txteta.Text))

                        .Fields("SAILINGDATE").Value = ddMMMyyyy(CDate(Me.txtetd.Text))
                        .Fields("pol").Value = Me.txtPOL.Text
                        .Fields("pod").Value = Me.txtPOD.Text
                        .Fields("del").Value = Me.txtDel.Text
                        .Fields("dest").Value = Me.txtDest.Text

                        .Fields("importCy").Value = Me.cboCY.Text
                        .Fields("shippingline").Value = Me.cboCarrier.Text
                        .Fields("salecode").Value = Me.cboSale.Text
                        .Fields("AgencyName").Value = Me.txtAgencyName.Text

                        .Fields("shipper").Value = Me.txtShipper.Text

                        .Fields("consignee").Value = Me.txtConsignee.Text
                        .Fields("notify").Value = Me.txtNotify.Text

                        .Fields("ShippingMARKS").Value = Me.txtShippingMarks.Text
                        .Fields("DESCRIPTION").Value = Me.txtDescription.Text
                        '   .Fields("pkgs").Value = Me.txtPackages.Text
                        .Fields("saycontainer").Value = Me.txtSaycontainer.Text
                        .Fields("kgavailable").Value = Me.txtChargeA.Text

                        '---------------------------------
                        .Fields("remarks").Value = Me.txtRemarks.Text
                        .Fields("paidreceived").Value = Me.txtPaidReceived.Text
                        '--------------------------




                        '--------------------------------------
                        .Fields("nodebit").Value = Me.txtNoDebit.Text

                        .Fields("nocredit").Value = Me.txtNoCredit.Text
                        .Fields("sogiayuyquyen").Value = Me.txtsoguq.Text




                        Try


                            .Fields("customerid_showtc").Value = "{" + FindValueID(Me.cboCustomer, Me.cboCustomer.Text) + "}"

                        Catch ex As Exception
                            .Fields("customerid_showtc").Value = DefaultValue
                        End Try















                        .Update()
                    End With
                    rs.Close()
                    '===================================================================
                    Dim cmd1 As New ADODB.Command
                    Dim strconn1, strServer1, strUserName1, strPassword1, strDatabase1 As String
                    strServer1 = "vietnamforwarder.com"
                    strUserName1 = "admin"
                    strPassword1 = "qwe123!@#"
                    strDatabase1 = "smf"
                    strconn1 = "Provider=sqloledb;Data Source='" & strServer1 & "'; User ID='" & strUserName1 & "'; password='" & strPassword1 & "'; Initial Catalog='" & strDatabase1 & "'"
                    Try
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM trackingsea "
                        strQuery = strQuery & "WHERE MBL = '" & Me.txtMBL.Text & "' and HBL='" & Me.txtHBL.Text & "'  "
                        rs.Open(strQuery, strconn1, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs
                            'If Not rs.EOF Then
                            '    rs.MoveFirst()
                            'End If

                            'While Not rs.EOF


                            If rs.EOF Then
                                .AddNew()
                                .Fields("trackingseaID").Value = NewId()

                                'strCarrierId = .Fields("BLOB_ID").Value
                                .Fields("mbl").Value = Me.txtMBL.Text
                                .Fields("hbl").Value = Me.txtHBL.Text
                                .Fields("eta").Value = Me.txteta.Text
                                .Fields("etd").Value = Me.txtetd.Text
                                .Fields("inbound_OverseaAirImport").Value = "1"
                                .Fields("customer").Value = "SITC"
                                .Fields("ngayps").Value = Me.txtetd.Text
                                .Fields("shipper").Value = Me.txtShipper.Text
                                .Fields("consignee").Value = Me.txtConsignee.Text
                                .Fields("carrier").Value = Me.cboCarrier.Text
                                .Fields("noidung").Value = "POL/ETD : " + Me.txtPOL.Text + "/" + Me.txtetd.Text + "<br>" + "POD/ETA : " + Me.txtPOD.Text + "/" + Me.txteta.Text  ' lay etd,eta, pol, pod

                                '.Fields("trackingdate").Value = Getdate()
                                .Update()
                                'rs.MoveNext()
                                'rs.MoveNext()
                            Else
                                .Fields("eta").Value = Me.txteta.Text
                                .Fields("etd").Value = Me.txtetd.Text
                                .Fields("ngayps").Value = Me.txtetd.Text
                                .Fields("shipper").Value = Me.txtShipper.Text
                                .Fields("consignee").Value = Me.txtConsignee.Text
                                .Fields("carrier").Value = Me.cboCarrier.Text
                                .Update()
                                ' rs.MoveNext()
                            End If
                            ' End While
                        End With
                        'cmd1.let_ActiveConnection(strconn1)
                        'cmd1.CommandText = "INSERT into trackingsea"
                        'cmd1.CommandText = cmd1.CommandText & "(mbl,hbl,inbound_OverseaAirImport,carrier,customer,ngayps,shipper,consignee,etd,eta) "
                        'cmd1.CommandText = cmd1.CommandText & "VALUES ('" & Me.txtMBLCarrier.Text & "','" & Me.txtMBLMAWB.Text & "','0','" & Me.cboCarrier.Text & "','SITC','" & Me.txtetd.Text & "','" & Me.txtShipper.Text & "','" & Me.txtConsignee.Text & "','" & Me.txtetd.Text & "','" & Me.txteta.Text & "') "
                        ''Debug.Print cmd.CommandText
                        'cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    Catch ex As Exception
                        'DisplayMessage(True, Err.Description)
                    End Try
                    '============================================================================
                    Me.dgdHBL.Enabled = True
                    'fraUpdate chỉ visible khi thêm hay sửa thành công
                    Me.TabControl1.Visible = False
                    ReFormat()
                    Me.cmdOK.Enabled = False
                    Me.cmdOKAll.Enabled = False
                    'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
                    mFilter = " and ref ='" & Me.txtRef.Text & "' "
                    QueryPort(mFilter, , index)
                    mStatus = "Normal"
                    reText(mStatus)
                    blnUpdated = True
                    Me.TabControl1.Enabled = False
                End If

                Dim cmd As New ADODB.Command


                Try
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "delete from billonline where id= '" & mInboundID & "' and userupdate='" & strUserId & "' "

                    cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                Catch ex As Exception

                End Try
            Else
                DisplayMessage(True, "Bạn cần được phân quyền.!")
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

        'Resume
    End Sub

    Private Sub frmListPort_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        Me.cmdOKHinh.Enabled = False
        Me.ButtonX1.Enabled = False
        '================================
        mStatusCashLoan = "Normal"
        mCashLoanID = DefaultValue
        '=============================================
        mStatus = "Normal"
        mStatusHinh = "Normal"
        mStatusContainer = "Normal"
        mStatusDebit = "Normal"
        mStatusCredit = "Normal"
        '-----------------------------------
        mStatusTheodoi = "Normal"
        mTheodoiid = DefaultValue
        '--------------------------------------------
        blnUpdated = False
        SetDefaultGrid(Me.dgdHBL, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mInboundID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdPort)
        Me.QueryUserReport()
        QueryCombo()

        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "TAX", "TAX")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "E-MAIL", "E-MAIL")
        'Me.cboFind.Items.Add(oItems)

        'Me.cboFind.Text = objUserSetting.GetCParm("frmListPort.cboFind", "NAME")
        'mFilter = objUserSetting.GetCParm("frmListPort.mFilter")
        'Me.txtPortCode.Text = objUserSetting.GetCParm("frmListPort.txtCODE")
        'Me.TxtPortName.Text = objUserSetting.GetCParm("frmListPort.txtPortName")
        'Me.txtTel.Text = objUserSetting.GetCParm("frmListPort.txtTel")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmListPort.txtFax")
        'Me.txtAddress.Text = objUserSetting.GetCParm("frmListPort.txtAddress")
        'Me.txtCountry.Text = objUserSetting.GetCParm("frmListPort.txtCountry")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmListPort.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmListPort.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmListPort.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmListPort.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmListPort.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmListPort.txtPERSONINCHARGE")

        'If Me.txtPort.Text <> "" Then
        '    QueryPort("AND Port LIKE '" & MakeFilter(Me.txtPort.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryPort(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If
        'If mFlag = 0 Then
        '    QueryShipper()
        'Else
        '    QueryShipper("  and " & mText1 & " like N'%" & mText2 & "%'")
        'End If
        mFlag = 0
        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmListPort.smnuDisplayCode")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayFax")
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayAddress")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayaPPROVE")
        'Me.smnuDisplayCountry.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayCountry")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayUpdateTime")
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        'Me.SelectToolStripMenuItem.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        SetDefaultGrid(Me.dgdHBL, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.BackColor = gMaunen
        Me.TabControl1.BackColor = gMauFra
        Me.TabPage1.BackColor = gMauFra
        'Me.TabPage2.BackColor = gMauFra
        'Me.TabPage3.BackColor = gMauFra
        '  Me.Containers.BackColor = gMauFra
        'If UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "ACCOUNT" Then
        '    Me.TabPage3.Text = "Credit (Administrator)"
        '    Me.TabPage6.Text = "Credit (sale)"
        '    Me.chkClockCredit.Visible = True
        '    ' EnableControl(True)
        'Else
        '    Me.TabPage3.Text = "..."
        '    Me.TabPage6.Text = "Credit (sale)"
        '    Me.chkClockCredit.Visible = False
        '    ' EnableControl(False)
        'End If
        Me.cmdCancel_Click(eventSender, eventArgs)
        Me.Button50_Click(eventSender, eventArgs)
        '-------------

        'QueryPort_(Me.cboPortOfDestination)
        'QueryPort_(Me.cboPortOfLoad)
        'QueryPort_(Me.cboportOftransit)
        'QueryPort_(Me.cboPortOfUnload)
        'QueryPort_(Me.cbocangDen)

        Me.cmdcancel_debit_Click(eventSender, eventArgs)
        Me.cmdcancel_credit_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub EnableControl(ByVal Value As Boolean)
        Try
            Dim ctr As Control
            'For Each ctr In Me.TabPage3.Controls
            '    ctr.Visible = Value
            'Next
            'For Each ctr In Me.tbcContainer.Controls
            '    ctr.Enabled = Value
            'Next
            'For Each ctr In Me.tbcGhiChu.Controls
            '    ctr.Enabled = Value
            'Next
            'Me.txtBookingNo.Enabled = True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmListPort_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'SetDefaultGrid(Me.dgdPort, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'objUserSetting.SetCParm("frmListPort.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListPort.txtPort", Me.txtPort.Text)
        'objUserSetting.SetCParm("frmListPort.txtCODE", Me.txtPortCode.Text)
        'objUserSetting.SetCParm("frmListPort.txtPortName", Me.TxtPortName.Text)
        'objUserSetting.SetCParm("frmListPort.txtTel", Me.txtTel.Text)
        'objUserSetting.SetCParm("frmListPort.txtFax", Me.txtFax.Text)
        'objUserSetting.SetCParm("frmListPort.txtAddress", Me.txtAddress.Text)
        'objUserSetting.SetCParm("frmListPort.txtCountry", Me.txtCountry.Text)

        'objUserSetting.SetCParm("frmListPort.mFilter", mFilter)

        'objUserSetting.SetBParm("frmListPort.smnuDisplayName", Me.smnuDisplayName.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayCode", Me.smnuDisplayCode.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayTel", Me.smnuDisplayTel.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayFax", Me.smnuDisplayFax.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

        'objUserSetting.SetBParm("frmListPort.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

        'objUserSetting.SetBParm("frmListPort.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryPort(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        ' sql = " select blib_id,REF,MBL,HBL,shipper,consignee,notify,approve,editable,continued,userupdate ,DateUpdate  from inbound_OverseaAirImport where mbl='" & Me.cboMBL.Text & "' order by dateupdate desc "
        If UCase(gDepartment) = "SALE" Then
            MakeQueryPort = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate "
            ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
            MakeQueryPort = MakeQueryPort & " FROM inbound_OverseaAirImport "
            MakeQueryPort = MakeQueryPort & "WHERE  " '(ref = '" & Me.cboMBL.Text & "')

            'MakeQueryPort = MakeQueryPort & "OR ("
            MakeQueryPort = MakeQueryPort & " (Continued = 1) and (salecode='" & gSaleCode & "') and (branch like '%" & gBranch & "%') "
            'MakeQueryPort = MakeQueryPort & ") "
            If Not IsNothing(argCriteria) And argCriteria.Trim <> "" Then
                MakeQueryPort = MakeQueryPort & argCriteria
            End If
            MakeQueryPort = MakeQueryPort + "order by dateupdate  "
        Else
            If UCase(gDepartment) = "CUSTOMER" Or UCase(gDepartment) = "DOCUMENT" Then
                MakeQueryPort = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate "
                ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                MakeQueryPort = MakeQueryPort & " FROM inbound_OverseaAirImport "
                MakeQueryPort = MakeQueryPort & "WHERE  " '(ref = '" & Me.cboMBL.Text & "')

                'MakeQueryPort = MakeQueryPort & "OR ("
                MakeQueryPort = MakeQueryPort & " (Continued = 1) and (branch like '%" & gBranch & "%') "
                'MakeQueryPort = MakeQueryPort & ") "
                If Not IsNothing(argCriteria) And argCriteria.Trim <> "" Then
                    MakeQueryPort = MakeQueryPort & argCriteria
                End If
                MakeQueryPort = MakeQueryPort + "order by dateupdate  "
            Else
                MakeQueryPort = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate "
                ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                MakeQueryPort = MakeQueryPort & " FROM inbound_OverseaAirImport "
                MakeQueryPort = MakeQueryPort & "WHERE  " '(ref = '" & Me.cboMBL.Text & "')

                'MakeQueryPort = MakeQueryPort & "OR ("
                MakeQueryPort = MakeQueryPort & " (Continued = 1) and (branch like '%" & gBranch & "%') "
                'MakeQueryPort = MakeQueryPort & ") "
                If Not IsNothing(argCriteria) And argCriteria.Trim <> "" Then
                    MakeQueryPort = MakeQueryPort & argCriteria
                End If
                MakeQueryPort = MakeQueryPort + "order by dateupdate  "

            End If

        End If

        'If index = 1 Then ' 
        '    MakeQueryPort = MakeQueryPort & strPortOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryPort = MakeQueryPort & strPortOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodePort() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Port_Code) as CountNo from Port", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    '    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
    '        On Error GoTo Err_Renamed
    '        If mStatus = "Normal" And UserRight("mnuInbound", "Add") Then
    '            'Me.txtServicename.Enabled = True
    '            Me.dgdPort.Enabled = False
    '            Me.fraUpdate.Visible = True
    '            ReFormat()
    '            SetMenu((False))
    '            mInboundID = DefaultValue
    '            mStatus = "Add"
    '            reText(mStatus)
    '            'Me.txtPortCode.Text = 
    '        Else
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Public Sub ApprovePort()
    '        On Error GoTo Err_Renamed
    '        Dim Approve As Boolean
    '        ' Xác định vị trí row trong grid
    '        Dim index As Integer = Me.dgdPort.CurrentRow.Index
    '        Dim strQueryPortList As String
    '        'If Not Me.dgdPort.Item("Editable", index).Value Or Not UserRight("mnuInbound", "Approve") Then
    '        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
    '        '    QueryPort(mFilter, , index)
    '        'Else
    '        '    strQueryPortList = "Select * from shippingline where" + " shippinglineid= '" & Me.dgdPort.Item("shippinglineid", index).Value.ToString & "'"
    '        '    rsPortList.Open(strQueryPortList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        '    Approve = Not rsPortList.Fields("Approve").Value
    '        '    rsPortList.Update("Approve", Approve)
    '        '    rsPortList.Close()
    '        'End If
    '        'QueryPort(mFilter, , index)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Public Sub DeleteRow(ByVal index As Integer)
    '        On Error GoTo Err_Renamed
    '        Dim rs As New ADODB.Recordset
    '        Dim strQuery, strQueryCommodityList As String
    '        Dim blnEmpty, blnEOF As Boolean
    '        ' Xác định vị trí row trong grid
    '        'Dim index As Integer = Me.BindingContext(oTable).Position
    '        'strQuery = "Select count(*) cnt from BillOfLading WHERE Port_Id = '" & Me.dgdPort.Item("Port_Id", index).Value.ToString & "'  "
    '        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        'blnEmpty = (rs.Fields("cnt").Value = 0)

    '        'rs.Close()
    '        'strQuery = "Select * from ratedetail WHERE serviceid = '" & Me.dgdPort.Item("serviceId", index).Value.ToString & "'  "
    '        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        'blnEOF = rs.EOF
    '        'rs.Close()
    '        'If Not blnEOF Then
    '        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, The Port can not be removed.", "Cảng Này Không Thể Xoá"))
    '        '    Exit Sub
    '        'End If
    '        'chư có ràng buộc
    '        'If Not blnEmpty Then
    '        '    DisplayMessage(True, "The Port can not be removed. There are transactions that relate to this customer.")
    '        '    Exit Sub
    '        'End If
    '        'If Not IsNothing(Me.dgdPort.Item("Approve1", index)) Then
    '        '    If Me.dgdPort.Item("Approve1", index).Value Then
    '        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
    '        '        Exit Sub
    '        '    End If
    '        'End If
    '        'If Not IsNothing(Me.dgdPort.Item("Editable1", index)) Then
    '        '    If Not Me.dgdPort.Item("Editable1", index).Value Then
    '        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
    '        '        Exit Sub
    '        '    End If
    '        'End If
    '        'Dim strMesg As String
    '        'Dim bm As Short
    '        'If Not UserRight("frmRateDetail", "Delete") Then
    '        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
    '        'Else
    '        '    strMesg = "Delete the Rate: " & Me.dgdPort.Item("INdate", index).Value.ToString
    '        '    If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
    '        '        strQueryCommodityList = "Select * from RateDetail where" + " RateDetailId= '" & Me.dgdPort.Item("RateDetailID", index).Value.ToString & "'"
    '        '        rsPortList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        '        rsPortList.Fields("continued").Value = 0
    '        '        rsPortList.Update()

    '        '        rsPortList.Requery()
    '        '        'Me.dgdPort.Rows(index).DefaultCellStyle.ForeColor = Color.White
    '        '        'Me.dgdPort.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
    '        '        rsPortList.Close()
    '        '        blnUpdated = True
    '        '    End If
    '        'End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        ' Dim selectedRowCount As Integer = _
        'Me.dgdPort.Rows.GetRowCount(DataGridViewElementStates.Selected)
        ' If selectedRowCount > 0 Then
        '     Dim sb As New System.Text.StringBuilder()
        '     Dim i As Integer
        '     For i = 0 To selectedRowCount - 1
        '         DeleteRow(Me.dgdPort.SelectedRows(i).Index)
        '     Next i
        ' End If
        ' Me.QueryPort(mFilter)
    End Sub
    'Private Sub smnuDisplayCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayCode.Checked = Not Me.smnuDisplayCode.Checked
    '    UpdateFrame()
    'End Sub
    'Public Sub smnuDisplayName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayName.Checked = Not Me.smnuDisplayName.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayApprove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayAddress_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayAddress.Checked = Not Me.smnuDisplayAddress.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayFax_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayFax.Checked = Not Me.smnuDisplayFax.Checked
    '    UpdateFrame()
    'End Sub


    'Public Sub smnuDisplayCountry_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayCountry.Checked = Not Me.smnuDisplayCountry.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayUpdateTime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayUserId_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '    UpdateFrame()
    'End Sub



    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "ACS Air Import "
        ElseIf mStatus = "Edit" Then
            Me.Text = "ACS Air Import -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "ACS Air Import -> Add."
        End If

    End Sub


    '==========Query==========

    Private Sub QueryPort(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------

        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPort()
        Else
            strQuery = MakeQueryPort(argCriteria, index)
        End If
        'ds = ReadDataSet(strQuery)

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "PortList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        'Me.dgdHBL.DataSource = oTables("PortList")
        Me.dgdHBL.DataSource = ds.Tables("PortList")
        If Me.dgdHBL.Enabled = False Then
            Me.dgdHBL.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdHBL.Rows.Count And Me.dgdHBL.Rows.Count > 0 Then
            Me.dgdHBL.Rows(location).Selected = True
            Me.dgdHBL.CurrentCell = Me.dgdHBL.Rows(location).Cells(2)
        End If
        '--------------------
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default

        InsertAutoNumberToGrid(Me.dgdHBL)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    '============Miscelanous==========


    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        'Me.dgdPort.Columns.Item("Port_Id").Visible = False
        'Me.dgdPort.Columns.Item("Port_Code").Visible = True  'Me.smnuDisplayCode.Checked
        'Me.dgdPort.Columns.Item("Port").Visible = Me.smnuDisplayName.Checked
        'Me.dgdPort.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
        'Me.dgdPort.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
        'Me.dgdPort.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
        'Me.dgdPort.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
        'Me.dgdPort.Columns.Item("OverW20").Visible = Me.smnuOrverW20.Checked
        'Me.dgdPort.Columns.Item("OverW40").Visible = Me.smnuOrverW40.Checked
        'Me.dgdPort.Columns.Item("IG").Visible = Me.smnuIG.Checked
        'Me.dgdPort.Columns.Item("Tradecode").Visible = Me.smnuTradecode.Checked

        'Me.dgdPort.Columns.Item("Editable").Visible = False
        'Me.dgdPort.Columns.Item("Continued").Visible = False
        'Me.dgdPort.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        'Me.dgdPort.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
        'Me.dgdPort.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdPort.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        If (Me.Height < IIf(TabControl1.Visible, 540, 540)) Then
            Me.Height = IIf(TabControl1.Visible, 540, 540)
        End If
        If Me.Width < 700 Then
            Me.Width = 700
        End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 10
        dgdHBL.Width = (Me.Width - Me.GroupBox1.Width - Me.cmdOK.Width - 30)
        If Me.Width > 610 Then
            dgdHBL.Height = Me.Height - 40 - IIf(TabControl1.Visible, TabControl1.Height + 35, 10) '> 7000
        Else
            dgdHBL.Height = Me.Height - 90 - IIf(TabControl1.Visible, TabControl1.Height + 5, 10) ' < 7000
        End If
        TabControl1.Width = (Me.Width - 30)
        TabControl1.Top = dgdHBL.Height + dgdHBL.Top + 30
        'If gNhom Like "COCA" Then
        '    Me.dgdContainers.Left = Me.GroupBox6.Left
        '    Me.dgdContainers.Width = Me.TabControl1.Width - 30

        'End If
        'Me.txtPort.Width = Me.Width - 300

        ''Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        ''Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        ''Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdFind.Left = Me.txtPort.Left + Me.txtPort.Width + 10
        'txtPort.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdPort_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        On Error GoTo Err_Renamed
        'Dim ColIndex, RowIndex As Integer
        '' Xác định vị trí row trong grid
        'If Me.dgdPort.RowCount = 0 Then
        '    Return
        'End If
        'Dim index As Integer = Me.dgdPort.CurrentRow.Index

        'ColIndex = e.ColumnIndex()
        'RowIndex = e.RowIndex
        'If ColIndex < 0 Then
        '    Return
        'End If
        'If Me.dgdPort.Columns(ColIndex).Name = "Approve" And Me.dgdPort.CurrentCellAddress().Y = index Then
        '    Call ApprovePort()
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub dgdPort_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Dim selectedRowCount As Integer = _
        'Me.dgdPort.Rows.GetRowCount(DataGridViewElementStates.Selected)
        'If e.KeyCode = Keys.Delete Then
        '    If selectedRowCount > 0 Then
        '        Dim sb As New System.Text.StringBuilder()
        '        Dim i As Integer
        '        For i = 0 To selectedRowCount - 1
        '            DeleteRow(Me.dgdPort.SelectedRows(i).Index)
        '        Next i
        '    End If

        '    QueryPort(mFilter)
        'End If
    End Sub









    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from inbound_OverseaAirImport where blib_id='" & mInboundID & "' and continued=1"

            ds = ReadDataSet(sql)



            Try
                Me.txtpic_report.Text = ds.Tables(0).Rows(0).Item("pic_report").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtlot.Text = ds.Tables(0).Rows(0).Item("lot").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtcanghangkhong.Text = ds.Tables(0).Rows(0).Item("canghangkhong").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtbenuyquyen.Text = ds.Tables(0).Rows(0).Item("benuyquyen").ToString


            Catch ex As Exception

            End Try


            Try
                Me.txtvolumnDebit.Text = ds.Tables(0).Rows(0).Item("volumndebit").ToString


            Catch ex As Exception

            End Try
            Try
                Me.txtquotation.Text = ds.Tables(0).Rows(0).Item("quotationNo").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtsoguq.Text = ds.Tables(0).Rows(0).Item("sogiayuyquyen").ToString
            Catch ex As Exception

            End Try
            ' DO
            Try
                Me.txtDO_Kinhgui.Text = ds.Tables(0).Rows(0).Item("DO_kinhgui").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtDO_Consignee.Text = ds.Tables(0).Rows(0).Item("DO_Consignee").ToString
            Catch ex As Exception

            End Try
            ' show arival

            Try
                Me.txtArrival_kinhgui.Text = ds.Tables(0).Rows(0).Item("arrival_kinhgui").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtArrival_tau.Text = ds.Tables(0).Rows(0).Item("arrival_tau").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtarrival_chuyen.Text = ds.Tables(0).Rows(0).Item("arrival_chuyen").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtarrival_pol.Text = ds.Tables(0).Rows(0).Item("arrival_POL").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtarrival_pod.Text = ds.Tables(0).Rows(0).Item("arrival_POd").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtarrival_eta.Text = ds.Tables(0).Rows(0).Item("arrival_ETA").ToString
            Catch ex As Exception

            End Try


            Try
                Me.txtarrival_hbl.Text = ds.Tables(0).Rows(0).Item("arrival_hbl").ToString
            Catch ex As Exception

            End Try



            Try
                Me.txtarrival_mbl.Text = ds.Tables(0).Rows(0).Item("arrival_mbl").ToString
            Catch ex As Exception

            End Try


            'Try
            '    Me.txtarrival_socontseal.Text = ds.Tables(0).Rows(0).Item("arrival_soContSeal").ToString
            'Catch ex As Exception

            'End Try


            Try
                Me.txtarrival_soluong.Text = ds.Tables(0).Rows(0).Item("arrival_soluong").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtarrival_chitiethanghoa.Text = ds.Tables(0).Rows(0).Item("arrival_chitiethanghoa").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtarrival_trongluong.Text = ds.Tables(0).Rows(0).Item("arrival_trongluong").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtarrival_khoiluong.Text = ds.Tables(0).Rows(0).Item("arrival_khoiluong").ToString
            Catch ex As Exception

            End Try

            'Try
            '    Me.txtarrival_billtype.Text = ds.Tables(0).Rows(0).Item("arrival_BillType").ToString
            'Catch ex As Exception

            'End Try


            Try
                Me.txtarrival_phi.Text = ds.Tables(0).Rows(0).Item("arrival_phi").ToString
            Catch ex As Exception

            End Try

            Try
                Me.txtArrival_tongcong.Text = ds.Tables(0).Rows(0).Item("arrival_tongcong").ToString
            Catch ex As Exception

            End Try

            '-------------------------
            '---------------
            Try
                Me.cboCustomer.Text = FindIDValue(Me.cboCustomer, ds.Tables(0).Rows(0).Item("customerid_showtc").ToString)
            Catch ex As Exception

            End Try
            '----------------------
            ' ngay 30-jun-2014
            Try
                Me.cboAgent.Text = FindIDValue(Me.cboAgent, ds.Tables(0).Rows(0).Item("agentid").ToString)
            Catch ex As Exception

            End Try
            Try
                Me.cboitemSITC.Text = ds.Tables(0).Rows(0).Item("itemSITC").ToString
            Catch ex As Exception

            End Try
            Try
                Me.CBOStatus.Text = ds.Tables(0).Rows(0).Item("status").ToString
            Catch ex As Exception

            End Try
            Try
                Me.cboops.Text = ds.Tables(0).Rows(0).Item("ops").ToString
            Catch ex As Exception

            End Try
            Try
                Me.cboPOL.Text = ds.Tables(0).Rows(0).Item("polcode").ToString
            Catch ex As Exception

            End Try
            Try
                Me.cbopodCode.Text = ds.Tables(0).Rows(0).Item("podcode").ToString
            Catch ex As Exception

            End Try
            Try
                Me.TXTInvoiceRequestDate.Text = ds.Tables(0).Rows(0).Item("InvoiceRequestDate").ToString
            Catch ex As Exception

            End Try
            '-----27-07-2013
            Try
                Me.cboemail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            Catch ex As Exception

            End Try
            Try
                Me.TXTTKHQ.Text = ds.Tables(0).Rows(0).Item("TKHQ").ToString
            Catch ex As Exception

            End Try
            Try
                Me.dtpDateReport.Value = ds.Tables(0).Rows(0).Item("datereport").ToString
            Catch ex As Exception

            End Try
            Try
                Me.dtp_cargo_ready.Value = ds.Tables(0).Rows(0).Item("cargo_ready").ToString
            Catch ex As Exception

            End Try
            Try
                Me.dtp_closing.Value = ds.Tables(0).Rows(0).Item("closing").ToString
            Catch ex As Exception

            End Try
            'Me.txtsohoso.Text = ds.Tables(0).Rows(0).Item("sohoso").ToString
            'Me.txtnamdangky.Text = ds.Tables(0).Rows(0).Item("namdangkyhoso").ToString
            'Me.cboDocumentFunction.Text = ds.Tables(0).Rows(0).Item("chucNangCuaChungTu").ToString
            'Me.cboLoaichuyendi.Text = ds.Tables(0).Rows(0).Item("loaichuyendi").ToString
            'Me.txtNameOfShip.Text = ds.Tables(0).Rows(0).Item("tentau").ToString
            'Me.txtIMONumber.Text = ds.Tables(0).Rows(0).Item("soIMO").ToString
            'Me.txtDateTimeOfArrivalDeparture.Text = ds.Tables(0).Rows(0).Item("thoiGianDen").ToString
            'Me.txtCallSign.Text = ds.Tables(0).Rows(0).Item("hohieu").ToString

            'Me.txtconsigner.Text = ds.Tables(0).Rows(0).Item("nguoiGuiHang").ToString
            'Me.txtconsignee_Manifest.Text = ds.Tables(0).Rows(0).Item("nguoiNhanHang").ToString
            'Me.cbocangDen.Text = ds.Tables(0).Rows(0).Item("cangden").ToString

            'Me.cboportOftransit.Text = ds.Tables(0).Rows(0).Item("cangChuyentai").ToString 'FindIDValue(Me.cboportOftransit, ds.Tables(0).Rows(0).Item("cangChuyentai").ToString)
            'Me.cboPortOfDestination.Text = ds.Tables(0).Rows(0).Item("cangGiaohang").ToString 'FindIDValue(Me.cboPortOfDestination, ds.Tables(0).Rows(0).Item("cangGiaohang").ToString)
            'Me.cboPortOfLoad.Text = ds.Tables(0).Rows(0).Item("cangXephang").ToString 'FindIDValue(Me.cboPortOfLoad, ds.Tables(0).Rows(0).Item("cangXephang").ToString)
            'Me.cboPortOfUnload.Text = ds.Tables(0).Rows(0).Item("cangDoHang").ToString 'FindIDValue(Me.cboPortOfLoad, ds.Tables(0).Rows(0).Item("cangDoHang").ToString)




            'Me.txtBillOfLading.Text = ds.Tables(0).Rows(0).Item("soVanDon").ToString
            'Me.txtDateOfBillOfLading.Text = ds.Tables(0).Rows(0).Item("ngayPhatHanhVanDon").ToString

            'Me.txtMasterBillNumber.Text = ds.Tables(0).Rows(0).Item("soVanDonGoc").ToString

            'Me.txtdateOfMasterBill.Text = ds.Tables(0).Rows(0).Item("ngayPhatHanhVanDonGoc").ToString
            'Me.txtDepartureDate.Text = ds.Tables(0).Rows(0).Item("ngayKhoiHanh").ToString

            'Me.txtNumberAndKindOfPackage.Text = ds.Tables(0).Rows(0).Item("tongSoKienLoaiKien").ToString

            'Me.txthscode.Text = ds.Tables(0).Rows(0).Item("hscode").ToString

            ' them e-manifest 12/08/2013
            'Me.txtnotify1.Text = ds.Tables(0).Rows(0).Item("notify1").ToString
            'Me.txtnotify2.Text = ds.Tables(0).Rows(0).Item("notify2").ToString
            'Me.txtdiadiemgiaohang.Text = ds.Tables(0).Rows(0).Item("diadiemgiaohang").ToString
            'Me.txtloaihang.Text = ds.Tables(0).Rows(0).Item("loaihang").ToString

            'Me.txtghichu.Text = ds.Tables(0).Rows(0).Item("ghichu").ToString
            '----------------------------------18-may-2013

            ' them tong
            'Me.txttongsoluong.Text = ds.Tables(0).Rows(0).Item("tongsoluong").ToString
            'Me.txttongsoluong1.Text = ds.Tables(0).Rows(0).Item("tongsoluong1").ToString
            'Me.txttongsoluong2.Text = ds.Tables(0).Rows(0).Item("tongsoluong2").ToString



            'Me.loai.Text = ds.Tables(0).Rows(0).Item("loai").ToString
            'Me.loai1.Text = ds.Tables(0).Rows(0).Item("loai1").ToString
            'Me.loai2.Text = ds.Tables(0).Rows(0).Item("loai2").ToString

            'Me.tongkien.Text = ds.Tables(0).Rows(0).Item("tongkien").ToString
            'Me.tongkg.Text = ds.Tables(0).Rows(0).Item("tongkg").ToString

            'Me.tongkhoi.Text = ds.Tables(0).Rows(0).Item("tongkhoi").ToString

            '-------------------



            Me.chkfcl.Checked = ds.Tables(0).Rows(0).Item("FCL").ToString
            Me.chklcl.Checked = ds.Tables(0).Rows(0).Item("LCL").ToString
            Me.chkconsol.Checked = ds.Tables(0).Rows(0).Item("Consol").ToString
            Me.chkair.Checked = ds.Tables(0).Rows(0).Item("air").ToString()




            Me.txtBKKComm.Text = ds.Tables(0).Rows(0).Item("bkkcomm").ToString
            Me.txtManifest.Text = ds.Tables(0).Rows(0).Item("ManifestDate").ToString
            Me.txtSentHPG.Text = ds.Tables(0).Rows(0).Item("sentHPGDate").ToString
            Me.chkClose.Checked = ds.Tables(0).Rows(0).Item("closeFile").ToString
            '  Me.txttigia.Text = ds.Tables(0).Rows(0).Item("tigia").ToString

            'Me.txtPackages.Text = ds.Tables(0).Rows(0).Item("pkgs").ToString

            Me.txtKho.Text = ds.Tables(0).Rows(0).Item("Kho").ToString
            Me.txtMaKho.Text = ds.Tables(0).Rows(0).Item("maKho").ToString

            Me.chkNhanlenh.Checked = ds.Tables(0).Rows(0).Item("nhanlenh").ToString
            Me.txtNgayNhanlenh.Text = ds.Tables(0).Rows(0).Item("ngaynhanlenh").ToString
            Me.txtNguoinhanlenh.Text = ds.Tables(0).Rows(0).Item("nguoinhanlenh").ToString
            Me.txtMBL.Text = ds.Tables(0).Rows(0).Item("MBL").ToString
            Me.txtHBL.Text = ds.Tables(0).Rows(0).Item("HBL").ToString
            Me.txtRef.Text = ds.Tables(0).Rows(0).Item("ref").ToString
            Me.txtTerms.Text = ds.Tables(0).Rows(0).Item("CY_CFS_ITEM").ToString
            Me.txtBL_Type.Text = ds.Tables(0).Rows(0).Item("bl_type").ToString

            Me.txtVessel.Text = ds.Tables(0).Rows(0).Item("vessel").ToString
            Me.txtVoyage.Text = ds.Tables(0).Rows(0).Item("voyage").ToString
            Me.txteta.Text = ds.Tables(0).Rows(0).Item("ETA").ToString

            Me.txtetd.Text = ds.Tables(0).Rows(0).Item("SAILINGDATE").ToString
            Me.txtPOL.Text = ds.Tables(0).Rows(0).Item("pol").ToString
            Me.txtPOD.Text = ds.Tables(0).Rows(0).Item("pod").ToString
            Me.txtDel.Text = ds.Tables(0).Rows(0).Item("del").ToString
            Me.txtDest.Text = ds.Tables(0).Rows(0).Item("dest").ToString

            Me.cboCY.Text = ds.Tables(0).Rows(0).Item("importCy").ToString
            Me.cboCarrier.Text = ds.Tables(0).Rows(0).Item("shippingline").ToString
            Me.cboSale.Text = ds.Tables(0).Rows(0).Item("salecode").ToString
            Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("AgencyName").ToString

            Me.txtShipper.Text = ds.Tables(0).Rows(0).Item("shipper").ToString

            Me.txtConsignee.Text = ds.Tables(0).Rows(0).Item("consignee").ToString

            Me.txtNotify.Text = ds.Tables(0).Rows(0).Item("notify").ToString

            Me.txtShippingMarks.Text = ds.Tables(0).Rows(0).Item("ShippingMARKS").ToString
            Me.txtDescription.Text = ds.Tables(0).Rows(0).Item("DESCRIPTION").ToString
            Me.txtSaycontainer.Text = ds.Tables(0).Rows(0).Item("saycontainer").ToString

            Me.txtChargeA.Text = ds.Tables(0).Rows(0).Item("kgavailable").ToString
            '-------------------------- 
            Me.txtRemarks.Text = ds.Tables(0).Rows(0).Item("remarks").ToString
            Me.txtPaidReceived.Text = ds.Tables(0).Rows(0).Item("PaidReceived").ToString
            '-------------------------------container


            '--------------------------------------------------------------------------------
            '------pay






            '--------------
            '---------------------------------------------debit
            Try
                Me.txtNoDebit.Text = ds.Tables(0).Rows(0).Item("nodebit").ToString
                Me.txtNoCredit.Text = ds.Tables(0).Rows(0).Item("nocredit").ToString
            Catch ex As Exception

            End Try







































        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    'Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub frmListPort_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strPortId, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM port "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("Port_Id").Value = NewId()
    '                .Fields("Port_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("Port").Value = UCase(Trim(rs.Fields("portname").Value))
    '                .Fields("Tel").Value = ""
    '                .Fields("Fax").Value = ""
    '                .Fields("Address").Value = ""
    '                .Fields("Country").Value = UCase(Trim(rs.Fields("countrycode").Value))
    '                .Fields("Continued").Value = 1
    '                .Update()
    '            End With
    '            rs.MoveNext()
    '        End While
    '        rs1.Close()
    '        rs.Close()

    '        'không cần sắp xếp

    '        'If mStatus = "Edit" Then
    '        '    QueryPort(, 1)
    '        'Else
    '        '    QueryPort(, 15)
    '        'End If

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    'Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
    '    Try
    '        gNameForm = Me.Name
    '        VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
    '        If frmFilter.strQuery <> "Cancel" Then
    '            mFilter = frmFilter.strQuery
    '            QueryPort("  " & mFilter)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(msgErr(Me, ex.Message))
    '    End Try
    'End Sub



    Private Sub smnuSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.dgdPort.SelectedRows.Count > 0 Then
        '    Dim index As Integer = Me.dgdPort.CurrentRow.Index
        '    gSearchID = Me.dgdPort.Item("Port_ID", index).Value.ToString
        '    gSearchCode = Me.dgdPort.Item("Port_Code", index).Value.ToString
        '    SearchCombo()
        '    Me.Close()
        'End If
    End Sub



    Private Sub txtPortCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UpdateOrverWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        'VB6.ShowForm(frmEditPortInfo, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    'Private Sub OrverW20ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuOrverW20.Checked = Not Me.smnuOrverW20.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuOrverW40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuOrverW40.Checked = Not Me.smnuOrverW40.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuIG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuIG.Checked = Not Me.smnuIG.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuTradecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuTradecode.Checked = Not Me.smnuTradecode.Checked
    '    UpdateFrame()
    'End Sub


    '-----port of loading
    Public Sub QueryPort_(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_Code"
        value = "Port"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Code,Port_code + '-' + Port as Port From Port where show=1 and Continued=1 Order By Port_code "
        loadDataToObject(combo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryShippingline()
        'On Error GoTo Err_Renamed
        'Dim id, value, strSQL As String
        'id = "shippinglineid"
        'value = "shippingline"
        'strSQL = "Select shippinglineid, shippingline From shippingline  Order By shippingline"
        'loadDataToObject(Me.cbounit, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim strSQL, lServiceId As String
            'lServiceId = FindValueID(Me.cboService, Me.cboService.Text)

            'strSQL = "Select * from service  where serviceid='" & lServiceId & "' and continued=1 "
            'Dim tbl As New DataSet
            'tbl = ReadDataSet(strSQL)
            'If tbl.Tables(0).Rows.Count > 0 Then
            '    Me.txtAddress.Text = tbl.Tables(0).Rows(0).Item("pol_code").ToString
            '    Me.txtFax.Text = tbl.Tables(0).Rows(0).Item("pod_code").ToString
            '    Me.txtTel.Text = tbl.Tables(0).Rows(0).Item("shippingline").ToString
            'End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Shared Function CheckNumber(ByVal number As String) As Boolean

        Return Regex.IsMatch(number, "^\d+$")

    End Function

    Private Sub dgdHBL_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdHBL.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right AndAlso e.RowIndex >= 0 Then
                Me.dgdHBL.CurrentCell = Me.dgdHBL.Rows(e.RowIndex).Cells(e.ColumnIndex)

            End If
        Catch ex As Exception

        End Try
    End Sub















    Private Sub dgdPort_ColumnHeaderMouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdHBL.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdHBL)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try



            Dim sqlkt As String
            Dim dskt As New DataSet
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không

            If Me.dgdHBL.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            'Try
            '    Me.txtNoDebit.Text = "DN-" + Me.txtRef.Text
            '    Me.txtNoCredit.Text = "CN-" + Me.txtRef.Text
            'Catch ex As Exception

            'End Try

            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            vitri = index
            If index >= 0 Then
                Approve = Me.dgdHBL.Item("Approve", index).Value
                EditTable = Me.dgdHBL.Item("Editable", index).Value
                If mStatus = "Normal" And EditTable And UserRight("inbound_OverseaAirImport", "Edit") Then
                    'Me.dgdPort.Height = 306
                    'Me.dgdPort.Enabled = False
                    'Me.txtPortCode.Enabled = False
                    Me.TabControl1.Visible = True
                    ReFormat()
                    'SetMenu((False))

                    mInboundID = Me.dgdHBL.Item("BLIB_ID", index).Value.ToString

                    '' lay id de kiem tra
                    sqlkt = "select * from billonline where id='" & mInboundID & "'"
                    dskt = ReadDataSet(sqlkt)
                    If dskt.Tables(0).Rows.Count > 0 Then
                        DisplayMessage(True, " Sorry,the proccess requires an access rigth to carry out, User:  " + dskt.Tables(0).Rows(0).Item("userupdate").ToString)
                        Exit Sub

                    End If
                    ' insertvao billonline   
                    Me.TabControl1.Enabled = True
                    Dim strQuery As String
                    Dim rs As New ADODB.Recordset
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM billonline  "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("editid").Value = NewId()

                        .Fields("id").Value = "{" + mInboundID + "}"
                        .Update()

                    End With
                    rs.Close()

                    '-------------------

                    Me.cmdOK.Enabled = True
                    Me.cmdOKAll.Enabled = True
                    Me.dgdHBL.Enabled = False

                    mStatus = "View"
                    reText(mStatus)
                    RefreshData(index)
                    Me.QueryHinhanh()
                    Me.Querythemhinh()
                    QueryContainer()

                    Querydebit()
                    QueryCredit()
                    Querytheodoi()
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
            profit()
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Public Sub profit()
        Try
            Dim i, j As Integer
            Dim tongdebittruocthue As Double
            Dim tongdebittruocthueusd As Double
            For i = 0 To Me.dgddebitGrid.Rows.Count - 1
                Try
                    If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "USD" Then
                        tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) * CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
                    Else
                        tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value)
                    End If

                Catch ex As Exception

                End Try

                If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "VND" Then
                    tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) / CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
                Else
                    tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value)
                End If

            Next

            Dim tongcredittruocthue As Double
            Dim tongcredittruocthueusd As Double
            For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
                Try
                    If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "USD" Then
                        tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) * CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
                    Else
                        tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value)
                    End If

                Catch ex As Exception

                End Try
                Try
                    If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "VND" Then
                        tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
                    Else
                        tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value)
                    End If

                Catch ex As Exception

                End Try
            Next






            Try
                Me.txttongthu.Text = FormatNumber(tongdebittruocthue.ToString, 0)
                Me.txttongthuusd.Text = FormatNumber(tongdebittruocthueusd.ToString, 2)
            Catch ex As Exception

            End Try
            Try
                Me.txttongchi.Text = FormatNumber(tongcredittruocthue.ToString, 0)
                Me.txttongchiusd.Text = FormatNumber(tongcredittruocthueusd.ToString, 2)

            Catch ex As Exception

            End Try
            Try
                Me.txtprofit.Text = FormatNumber(tongdebittruocthue - tongcredittruocthue, 0)
                Me.txtprofitusd.Text = FormatNumber(tongdebittruocthueusd - tongcredittruocthueusd, 2)

            Catch ex As Exception

            End Try

        Catch ex As Exception

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

        If Not IsNothing(Me.dgdHBL.Item("Approve", index)) Then
            If Me.dgdHBL.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdHBL.Item("Editable", index)) Then
            If Not Me.dgdHBL.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the HBL: " & Me.dgdHBL.Item("HBL", index).Value.ToString
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
                cmd.CommandText = "delete from inbound_OverseaAirImport where BLib_Id= '" & Me.dgdHBL.Item("blib_id", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.dgdHBL.Rows.Count = 0 Then
            Return
        End If


        Dim selectedRowCount As Integer = _
             Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdHBL.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryPort()
        '"And BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "'")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        Dim ds As New DataSet
        If UCase(gDepartment) = "SALE" Then
            sql = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate  from inbound_OverseaAirImport where (ref='" & Me.cboMBL.Text & "') and (salecode='" & gSaleCode & "') and (branch like '%" & gBranch & "%') order by dateupdate  "

        Else
            sql = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate  from inbound_OverseaAirImport where (ref='" & Me.cboMBL.Text & "') and (branch like '%" & gBranch & "%')  order by dateupdate  "

        End If
        ds = ReadDataSet(sql)
        Me.dgdHBL.DataSource = ds.Tables(0)
        mFilter = " and ref = '" & Me.cboMBL.Text & "' "
        InsertAutoNumberToGrid(Me.dgdHBL)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtShipper.Text = Me.cboShipper.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtConsignee.Text = Me.cboConsignee.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtNotify.Text = Me.cboNotify.Text
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim sql As String
        Dim ds As New DataSet
        sql = "select * from agency where agencyname='" & Me.cboagency.Text & "'"
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("agencyname").ToString + vbCrLf
            Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("Address").ToString + vbCrLf
            If ds.Tables(0).Rows(0).Item("agencyname").ToString <> "" Then
                Me.txtAgencyName.Text += "Tel: " + ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                Me.txtAgencyName.Text += "Fax : " + ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
            End If

        Else
            DisplayMessage(True, "Please check again.!")
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.txtetd.Text = ddMMMyyyy(Me.dtpETD.Value.Date)
        Dim month, day As Integer
        Dim months, days As String
        month = Me.dtpETD.Value.Month
        If month < 10 Then
            months = "0" + month.ToString
        Else
            months = month.ToString
        End If
        day = Me.dtpETD.Value.Day
        If day < 10 Then
            days = "0" + day.ToString
        Else
            days = day.ToString
        End If
        'Me.txtDateOfBillOfLading.Text = days & "-" & months & "-" & Me.dtpETD.Value.Year.ToString
        'Me.txtdateOfMasterBill.Text = Me.txtDateOfBillOfLading.Text
        'Me.txtDepartureDate.Text = Me.txtDateOfBillOfLading.Text


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.txteta.Text = ddMMMyyyy(Me.dtpETA.Value.Date)
    End Sub
























    Public Sub ApproveIB()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not UserRight("inbound_OverseaAirImport", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from inbound_OverseaAirImport where" + " blib_id= '" & Me.dgdHBL.Item("blib_id", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub dgdHBL_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdHBL.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdHBL.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdHBL.Columns(ColIndex).Name) = "APPROVE" And Me.dgdHBL.CurrentCellAddress.Y = RowIndex Then
            Call ApproveIB()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
        End If
        If UCase(Me.dgdHBL.Columns(ColIndex).Name) = "INVOICEREQUEST" And Me.dgdHBL.CurrentCellAddress.Y = RowIndex Then
            Call CheckInvoiceRequest()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
        End If
        If UCase(Me.dgdHBL.Columns(ColIndex).Name) = "DEBITISSUED" And Me.dgdHBL.CurrentCellAddress.Y = RowIndex Then
            Call CheckDebitIssued()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
        End If

        If UCase(Me.dgdHBL.Columns(ColIndex).Name) = "INVOICEISSUED" And Me.dgdHBL.CurrentCellAddress.Y = RowIndex Then
            Call CheckInvoiceIssued()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
        End If
        If UCase(Me.dgdHBL.Columns(ColIndex).Name) = "PAID" And Me.dgdHBL.CurrentCellAddress.Y = RowIndex Then
            Call CheckPaid()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryPort("and Ref='" & Me.dgdHBL.Item("ref", index).Value.ToString & "'")
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub CheckInvoiceRequest()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String

        strQueryDetailBillOfLading_HouseList = "Select * from inbound_OverseaAirImport where" + " BLiB_ID= '" & Me.dgdHBL.Item("BLiB_ID", index).Value.ToString & "'"
        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Approve = Not rs.Fields("InvoiceRequest").Value
        rs.Update("InvoiceRequest", Approve)
        rs.Close()

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub CheckDebitIssued()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String

        strQueryDetailBillOfLading_HouseList = "Select * from inbound_OverseaAirImport where" + " BLiB_ID= '" & Me.dgdHBL.Item("BLiB_ID", index).Value.ToString & "'"
        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Approve = Not rs.Fields("DebitIssued").Value
        rs.Update("DebitIssued", Approve)
        rs.Close()

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub CheckInvoiceIssued()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String

        strQueryDetailBillOfLading_HouseList = "Select * from inbound_OverseaAirImport where" + " BLiB_ID= '" & Me.dgdHBL.Item("BLiB_ID", index).Value.ToString & "'"
        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Approve = Not rs.Fields("InvoiceIssued").Value
        rs.Update("InvoiceIssued", Approve)
        rs.Close()

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub CheckPaid()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String

        strQueryDetailBillOfLading_HouseList = "Select * from inbound_OverseaAirImport where" + " BLiB_ID= '" & Me.dgdHBL.Item("BLiB_ID", index).Value.ToString & "'"
        rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Approve = Not rs.Fields("Paid").Value
        rs.Update("Paid", Approve)
        rs.Close()

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub cmdOKAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKAll.Click
        Try


            Dim strQuery, strCarrierId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            Dim i As Integer
            If Me.chkfcl.Checked = False And Me.chklcl.Checked = False And Me.chkconsol.Checked = False And Me.chkair.Checked = False Then
                DisplayMessage(True, "Kiểm tra loại hàng FCL,LCL,Consol.!")
                Exit Sub
            End If
            If mStatus = "Edit" Then
                index = Me.dgdHBL.CurrentRow.Index
            End If
            ' ta lay toan bo hbl cua mbl
            If Me.txteta.Text = "" Then
                DisplayMessage(True, "ETA ?")
                Exit Sub
            End If
            Dim sql, strMesg As String
            Dim ds As New DataSet
            sql = "select blib_id from inbound_OverseaAirImport where ref='" & Me.cboMBL.Text & "' "
            ds = ReadDataSet(sql)
            strMesg = " Chú ý các Bill House sẽ được copy dữ liệu. Bạn thật sự muốn làm ?"
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then


                If ds.Tables(0).Rows.Count > 0 Then

                    For i = 0 To ds.Tables(0).Rows.Count - 1


                        If (mStatus = "Add" Or mStatus = "Edit") Then
                            strQuery = "SELECT * "
                            strQuery = strQuery & "FROM inbound_OverseaAirImport "
                            strQuery = strQuery & "WHERE BLIB_ID = '" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' and continued=1 "
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                If rs.EOF Then
                                    .AddNew()
                                    .Fields("BLIB_ID").Value = NewId()
                                End If
                                strCarrierId = .Fields("BLIB_ID").Value
                                ' them tong
                                Try
                                    '.Fields("loaiChungtu").Value = Me.txtnamdangky.Text.Trim
                                    '.Fields("chucNangCuaChungTu").Value = Me.cboDocumentFunction.Text.Trim
                                    '.Fields("loaichuyendi").Value = Me.cboLoaichuyendi.Text.Trim
                                    '.Fields("tentau").Value = Me.txtNameOfShip.Text.Trim
                                    '.Fields("soIMO").Value = Me.txtIMONumber.Text.Trim
                                    '.Fields("thoiGianDen").Value = Me.txtDateTimeOfArrivalDeparture.Text.Trim
                                    '.Fields("hohieu").Value = Me.txtCallSign.Text.Trim
                                    '.Fields("nguoiGuiHang").Value = Me.txtconsigner.Text.Trim
                                    '.Fields("nguoiNhanHang").Value = Me.txtconsignee_Manifest.Text.Trim
                                    '.Fields("cangChuyentai").Value = Me.cboportOftransit.Text.Trim
                                    '.Fields("cangGiaohang").Value = Me.cboPortOfDestination.Text.Trim
                                    '.Fields("cangXephang").Value = Me.cboPortOfLoad.Text.Trim
                                    '.Fields("cangDoHang").Value = Me.cboPortOfUnload.Text.Trim
                                    '.Fields("soVanDon").Value = Me.txtBillOfLading.Text.Trim
                                    '.Fields("ngayPhatHanhVanDon").Value = Me.txtDateOfBillOfLading.Text.Trim
                                    '.Fields("soVanDonGoc").Value = Me.txtMasterBillNumber.Text.Trim
                                    '.Fields("ngayPhatHanhVanDonGoc").Value = Me.txtdateOfMasterBill.Text.Trim
                                    '.Fields("ngayKhoiHanh").Value = Me.txtDepartureDate.Text.Trim
                                    '.Fields("tongSoKienLoaiKien").Value = Me.txtNumberAndKindOfPackage.Text.Trim
                                    '.Fields("hscode").Value = Me.txthscode.Text.Trim

                                    ' them e-manifest 
                                    '.Fields("notify1").Value = Me.txtnotify1.Text.Trim
                                    '.Fields("notify2").Value = Me.txtnotify2.Text.Trim
                                    '.Fields("diadiemgiaohang").Value = Me.txtdiadiemgiaohang.Text.Trim
                                    '.Fields("loaihang").Value = Me.txtloaihang.Text.Trim
                                    '.Fields("ghichu").Value = Me.txtghichu.Text.Trim


                                    '-----------------------
                                Catch ex As Exception

                                End Try
                                '.Fields("tongsoluong").Value = Me.txttongsoluong.Text
                                '.Fields("tongsoluong1").Value = Me.txttongsoluong1.Text
                                '.Fields("tongsoluong2").Value = Me.txttongsoluong2.Text
                                '.Fields("loai").Value = Me.loai.Text
                                '.Fields("loai1").Value = Me.loai1.Text
                                '.Fields("loai2").Value = Me.loai2.Text
                                '.Fields("tongkien").Value = Me.tongkien.Text
                                '.Fields("tongkg").Value = Me.tongkg.Text
                                '.Fields("tongkhoi").Value = Me.tongkhoi.Text

                                '-------------------
                                '.Fields("nhanlenh").Value = Me.chkNhanlenh.Checked
                                '.Fields("ngaynhanlenh").Value = Me.txtNgayNhanlenh.Text
                                '.Fields("nguoinhanlenh").Value = Me.txtNguoinhanlenh.Text
                                .Fields("LCL").Value = Me.chklcl.Checked
                                .Fields("FCL").Value = Me.chkfcl.Checked
                                .Fields("Consol").Value = Me.chkconsol.Checked
                                .Fields("air").Value = Me.chkair.Checked
                                ' .Fields("clockcredit").Value = Me.chkClockCredit.Checked
                                .Fields("bkkcomm").Value = IIf(Me.txtBKKComm.Text = "", 0, Me.txtBKKComm.Text)
                                .Fields("kho").Value = Me.txtKho.Text
                                ' add cach tinh com
                                'ItemCom

                                '-------------------------------------------------------------------
                                '.Fields("hbl").Value = Me.txtHBL.Text
                                '.Fields("ref").Value = Me.txtRef.Text
                                .Fields("CY_CFS_ITEM").Value = Me.txtTerms.Text
                                .Fields("bl_type").Value = Me.txtBL_Type.Text

                                .Fields("vessel").Value = Me.txtVessel.Text
                                .Fields("voyage").Value = Me.txtVoyage.Text
                                .Fields("ETA").Value = Me.txteta.Text

                                .Fields("SAILINGDATE").Value = Me.txtetd.Text
                                .Fields("pol").Value = Me.txtPOL.Text
                                .Fields("pod").Value = Me.txtPOD.Text
                                .Fields("del").Value = Me.txtDel.Text
                                .Fields("dest").Value = Me.txtDest.Text

                                .Fields("importCy").Value = Me.cboCY.Text
                                .Fields("shippingline").Value = Me.cboCarrier.Text
                                .Fields("salecode").Value = Me.cboSale.Text
                                .Fields("AgencyName").Value = Me.txtAgencyName.Text

                                .Fields("shipper").Value = Me.txtShipper.Text

                                .Fields("consignee").Value = Me.txtConsignee.Text
                                .Fields("notify").Value = Me.txtNotify.Text
                                .Fields("saycontainer").Value = Me.txtSaycontainer.Text
                                .Fields("ShippingMARKS").Value = Me.txtShippingMarks.Text
                                .Fields("DESCRIPTION").Value = Me.txtDescription.Text
                                '--------------------------
                                .Fields("kgavailable").Value = Me.txtChargeA.Text
                                '.Fields("pkgs").Value = Me.txtPackages.Text


                                '-----------
                                .Fields("nodebit").Value = Me.txtNoDebit.Text

                                .Fields("nocredit").Value = Me.txtNoCredit.Text













                                .Update()
                            End With
                            rs.Close()
                        End If
                    Next

                End If
            End If
            Me.dgdHBL.Enabled = True
            'fraUpdate chỉ visible khi thêm hay sửa thành công
            ReFormat()

            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            'mFilter = " order by shippingline desc "
            QueryPort(mFilter, , index)
            mStatus = "Normal"
            blnUpdated = True

            Me.cmdOK.Enabled = False
            Me.cmdOKAll.Enabled = False

            Dim cmd As New ADODB.Command


            Try
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from billonline where id= '" & mInboundID & "' and userupdate='" & strUserId & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

        'Resume
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKCopy.Click
        If Me.chkbill.Checked = True Then
            CopyHBL_AIR("inbound_OverseaAirImport", "blib_id", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "blib_id", FindValueID(Me.cboCopyHBLFrom, Me.cboCopyHBLFrom.Text))
            CopyContainers("containerRepair", "inboundID", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "inboundid", FindValueID(Me.cboCopyHBLFrom, Me.cboCopyHBLFrom.Text))
        End If
        If Me.chkfreight.Checked = True Then
            CopyHBLFreight("Inboundfreight", "inboundid", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "inboundid", FindValueID(Me.cboCopyHBLFrom, Me.cboCopyHBLFrom.Text))

        End If
        'If Me.chkbill.Checked = True And Me.chkfreight.Checked = True Then
        '    CopyHBL("inbound_OverseaAirImport", "blib_id", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "blib_id", FindValueID(Me.cboCopyHBLFrom, Me.cboCopyHBLFrom.Text))
        '    CopyHBLFreight("Inboundfreight_OverseaAirImport", "inbound_OverseaAirImportid", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "inbound_OverseaAirImportid", FindValueID(Me.cboCopyHBLFrom, Me.cboCopyHBLFrom.Text))

        'End If
        Me.QueryPort()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitCopy.Click
        Me.GroupBox3.Visible = False
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

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

    Private Sub CopyFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromToolStripMenuItem.Click
        Me.GroupBox3.Visible = True
        Dim id, value, strSQL As String
        Try
            id = "blib_id"
            value = "hbl"
            Me.cboCopyHBL.Items.Clear()
            Me.cboCopyHBLFrom.Items.Clear()

            strSQL = "Select distinct blib_id,hbl From inbound_OverseaAirImport  where branch like '%" & gBranch & "%' and Continued=1 order by hbl "
            loadDataToObject(Me.cboCopyHBL, strSQL, id, value)
            loadDataToObject(Me.cboCopyHBLFrom, strSQL, id, value)
            '----------------------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportXlsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportXlsToolStripMenuItem.Click
        Try
            If Me.dgdHBL.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.dgdHBL, Me)
            'SetMenu(True)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.QueryCombo()
    End Sub

    Private Sub ArriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArriToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString

            ' co ginbound_OverseaAirImportid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Approve. ??? !")
                    Exit Sub
                End If
            End If

            gPrintInbound = "inbound_OverseaAirImport"
            If LoginSucceeded = True Then
                Dim form As New frmPrintArrival_OverseaAirImport
                Form.MdiParent = frmMain
                Form.Show()
            End If
            '  VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOToolStripMenuItem.Click

        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            Dim sqlcus As String
            Dim dscus As New DataSet
            sqlcus = "select * from Inbound_OverseaAirImport where blib_id='" & Me.dgdHBL.Item("BLib_ID", index).Value.ToString & "' "
            dscus = ReadDataSet(sqlcus)
            If dscus.Tables(0).Rows.Count > 0 Then
                gInboundID_Consignee = dscus.Tables(0).Rows(0).Item("customerid_showtc").ToString
            End If

            ' co ginbound_OverseaAirImportid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If


            If LoginSucceeded = True Then
                Dim form As New frmPrintDO_OverseaAirImport
                Form.MdiParent = frmMain
                Form.Show()
            End If

            ' VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DebitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        ' lay toan bo khach hang cua debit
        Dim id, value, strquery As String
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Me.cboCusDebitIn.Text = ""
        Me.cboCusDebitIn.Items.Clear()
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            ' co ginbound_OverseaAirImportid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            ' lay toan bo cus add vao cbo
            id = "CustomerID"
            value = "company"
            strquery = "Select CustomerID,no_ + '$' + company as company from inboundfreight left join customer on inboundfreight.CustomerID=customer.customer_id where inboundid='" & gInboundID & "'  and debitcredit='Debit' "

            loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)






        End If


        Me.GroupBox4.Visible = True



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            gDebitInbound = "Inbound_OverseaAirImport"
            ' If Me.CHKUSd.Checked = False Then
            Try
                gInboundDebitNote = Me.cboCusDebitIn.Text.Split("$")(0)
            Catch ex As Exception
                gInboundDebitNote = Me.cboCusDebitIn.Text.Split("$")(0)
            End Try
            gSqlDebitInbound = "select * from inboundfreight left join charge on charge.charge_id=inboundfreight.itemid where inboundid='" & gInboundID & "' and customerid='" & gInboundCusID & "' and debitcredit='Debit' and no_ = '" & gInboundDebitNote & "'  and os=0 " ' os=thu ho

            gSqlDebitInbound_thuho = "select * from inboundfreight left join charge on charge.charge_id=inboundfreight.itemid where inboundid='" & gInboundID & "' and customerid='" & gInboundCusID & "' and debitcredit='Debit' and no_ = '" & gInboundDebitNote & "'  and os=1  " ' os=thu ho

            If Me.CHKUSd.Checked = False Then
                If LoginSucceeded = True Then
                    Dim form As New frmReportDebitusd
                    Form.MdiParent = frmMain
                    Form.Show()
                End If
                '   VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
            Else
                If LoginSucceeded = True Then
                    Dim form As New frmReportDebitNguyente
                    Form.MdiParent = frmMain
                    Form.Show()
                End If
                '  VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
            End If


        End If
    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.GroupBox4.Visible = False
    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub DebitToolStripMenuItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DebitToolStripMenuItem.MouseDown

    End Sub

    Private Sub DebitToolStripMenuItem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DebitToolStripMenuItem.MouseMove

    End Sub

    Private Sub DebitToolStripMenuItem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DebitToolStripMenuItem.MouseUp

    End Sub

    Private Sub GroupBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox4.MouseMove
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

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            gInboundCusID = FindValueID(Me.cboCusCreditIn, Me.cboCusCreditIn.Text)
            gCusID = FindValueID(Me.cboCusCreditIn, Me.cboCusCreditIn.Text)
            gPrintInbound = "Inbound_OverseaAirImport"
            gCreditInbound = "Inbound_OverseaAirImport"
            ' If Me.RadioButton1.Checked = True Then
            'VB6.ShowForm(frmReportCredit, VB6.FormShowConstants.Modal, Me)
            Try
                gInboundCreditNote = Me.cboCusCreditIn.Text.Split("-")(0)
            Catch ex As Exception
                gInboundCreditNote = Me.cboCusCreditIn.Text.Split("-")(0)
            End Try
            gSqlCreditinbound = "select * from inboundfreight left join charge on charge.charge_id=inboundfreight.itemid where inboundid='" & gInboundID & "' and customerid='" & gInboundCusID & "' and debitcredit='Credit'  and os=0 " ' os=thu ho

            gSqlcreditInbound_thuho = "select * from inboundfreight left join charge on charge.charge_id=inboundfreight.itemid where inboundid='" & gInboundID & "' and customerid='" & gInboundCusID & "' and debitcredit='Credit'  and os=1 " ' os=thu ho


            If Me.RadioButton1.Checked = True Then
                If LoginSucceeded = True Then
                    Dim form As New frmReportCredit 'frmReportCreditNguyenTe
                    Form.MdiParent = frmMain
                    Form.Show()
                End If
                ' VB6.ShowForm(, VB6.FormShowConstants.Modal, Me) ' vnd
            Else
                If LoginSucceeded = True Then
                    Dim form As New frmReportCredit
                    Form.MdiParent = frmMain
                    Form.Show()
                End If
                ' VB6.ShowForm(, VB6.FormShowConstants.Modal, Me) ' usd
            End If
            'If Me.RadioButton1.Checked = True Then
            '    VB6.ShowForm(frmReportCredit_OverseaAirImport, VB6.FormShowConstants.Modal, Me)
            'Else
            '    VB6.ShowForm(frmReportCreditNguyenTe_OverseaAirImport, VB6.FormShowConstants.Modal, Me)
            'End If

        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.GroupBox5.Visible = False
    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub GroupBox5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox5_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseMove
        If Mdown Then
            Me.GroupBox5.Left = (e.X - X) + Me.GroupBox5.Left
            Me.GroupBox5.Top = (e.Y - Y) + Me.GroupBox5.Top
        End If
    End Sub

    Private Sub GroupBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox5.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox5.Left = (e.X - X) + Me.GroupBox5.Left
            Me.GroupBox5.Top = (e.Y - Y) + Me.GroupBox5.Top
        End If
    End Sub

    Private Sub CreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        ' lay toan bo khach hang cua debit
        Dim id, value, strquery As String
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Me.cboCusCreditIn.Items.Clear()
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            ' co ginbound_OverseaAirImportid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            ' lay toan bo cus add vao cbo
            '-------------------------
            id = "CustomerID"
            value = "company"
            strquery = "Select CustomerID,no_ + '-' + company as company from INboundfreight left join customer on inboundfreight.CustomerID=customer.customer_id where inboundid='" & gInboundID & "'  and debitcredit='Credit' "

            loadDataToObjectNoClear(Me.cboCusCreditIn, strquery, id, value)


        End If


        Me.GroupBox5.Visible = True



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
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
    Private Function MakeQueryShipper(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        If UCase(gDepartment) = "SALE" Then
            MakeQueryShipper = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate "
            'Sql = " select blob_id,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shipper,consignee,notify,nodebit,nocredit,approve,editable,continued,userupdate ,DateUpdate  from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' order by dateupdate desc "

            MakeQueryShipper = MakeQueryShipper & " from Inbound_OverseaAirImport WHERE  "

            MakeQueryShipper = MakeQueryShipper & "("
            MakeQueryShipper = MakeQueryShipper & " Continued = 1 "
            MakeQueryShipper = MakeQueryShipper & ") and (salecode = '" & gSaleCode & "') and (branch like '%" & gBranch & "%') "
            If Not IsNothing(argCriteria) And argCriteria <> "" Then
                MakeQueryShipper = MakeQueryShipper & argCriteria
            End If

            'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
            If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
                MakeQueryShipper = MakeQueryShipper & " order by dateupdate  "
            End If
        Else
            If UCase(gDepartment) = "CUSTOMER" Or UCase(gDepartment) = "DOCUMENT" Then
                MakeQueryShipper = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,datereport,nocredit,approve,editable,continued,userupdate ,DateUpdate "
                'Sql = " select blob_id,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shipper,consignee,notify,nodebit,nocredit,approve,editable,continued,userupdate ,DateUpdate  from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' order by dateupdate desc "

                MakeQueryShipper = MakeQueryShipper & " from Inbound_OverseaAirImport WHERE  "

                MakeQueryShipper = MakeQueryShipper & "("
                MakeQueryShipper = MakeQueryShipper & " Continued = 1 "
                MakeQueryShipper = MakeQueryShipper & ") and (branch like '%" & gBranch & "%') "
                If Not IsNothing(argCriteria) And argCriteria <> "" Then
                    MakeQueryShipper = MakeQueryShipper & argCriteria
                End If

                'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
                If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
                    MakeQueryShipper = MakeQueryShipper & " order by dateupdate  "
                End If
            Else
                MakeQueryShipper = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate "
                'Sql = " select blob_id,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shipper,consignee,notify,nodebit,nocredit,approve,editable,continued,userupdate ,DateUpdate  from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' order by dateupdate desc "

                MakeQueryShipper = MakeQueryShipper & " from Inbound_OverseaAirImport WHERE  "

                MakeQueryShipper = MakeQueryShipper & "("
                MakeQueryShipper = MakeQueryShipper & " Continued = 1 "
                MakeQueryShipper = MakeQueryShipper & ") and (branch like '%" & gBranch & "%') "
                If Not IsNothing(argCriteria) And argCriteria <> "" Then
                    MakeQueryShipper = MakeQueryShipper & argCriteria
                End If

                'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
                If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
                    MakeQueryShipper = MakeQueryShipper & " order by dateupdate  "
                End If
            End If

        End If

        '    
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    Public Sub sumTotal()
        On Error GoTo Err_Renamed
        Dim tongkien, tongkg, tongkhoi As Double
        tongkien = 0
        tongkg = 0
        tongkhoi = 0
        'If Me.txtsoKien1.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien1.Text)
        'End If
        'If Me.txtsoKien2.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien2.Text)
        'End If

        'If Me.txtsoKien3.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien3.Text)
        'End If

        'If Me.txtsoKien4.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien4.Text)
        'End If

        'If Me.txtsoKien5.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien5.Text)
        'End If

        'If Me.txtsoKien6.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien6.Text)
        'End If

        'If Me.txtsoKien7.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien7.Text)
        'End If


        'If Me.txtsoKien8.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien8.Text)
        'End If

        'If Me.txtsoKien9.Text.ToString.Trim <> "" Then
        '    tongkien += CDbl(Me.txtsoKien9.Text)
        'End If
        'Me.txtTongKien.Text = FormatNumber(tongkien.ToString)



        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub
    Public Sub QueryShipper(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim sumVN, sumUSD As Double
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
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "ShipperList")
        oTable = ds.Tables(0)
        'ds = ReadDataSet(strQuery)
        'hien thi ra grid 
        Me.dgdHBL.DataSource = ds.Tables("ShipperList")
        '------------vị trí BM
        If vitri > 0 And vitri <= Me.dgdHBL.Rows.Count And Me.dgdHBL.Rows.Count > 0 Then
            Me.dgdHBL.Rows(vitri).Selected = True
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdHBL)





        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub





    Private Sub cmdJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJOB.Click
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmJOBIn, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub cmdCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCal.Click
        Try
            Dim i, j As Integer
            Dim kien, kg, khoi As Double
            kien = 0
            kg = 0
            khoi = 0

            If Me.cboMBL.Text = "" Then

            Else
                Dim sql As String
                Dim ds As New DataSet
                sql = " select * from containerrepair where inbound_OverseaAirImportid='" & mInboundID & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then

                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Try
                            kien += ds.Tables(0).Rows(i).Item("sokien").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            kg += ds.Tables(0).Rows(i).Item("sokg").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            khoi += ds.Tables(0).Rows(i).Item("sokhoi").ToString
                        Catch ex As Exception

                        End Try

                    Next
                End If
                Me.txtTongKien.Text = FormatNumber(kien.ToString, 2)
                Me.txtTongKg.Text = FormatNumber(kg.ToString, 2)
                Me.txtTongKhoi.Text = FormatNumber(khoi.ToString, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
            gInboundCusID = FindValueID(Me.cboCantruDeCre, Me.cboCantruDeCre.Text)


            Dim unitprice1, unitprice2, unitprice3, unitprice4, unitprice5, unitprice6, unitprice7, unitprice8, unitprice9, unitprice10 As Object
            VB6.ShowForm(frmReportCanTruOut_OverseaAirImport, VB6.FormShowConstants.Modal, Me) ' frmReportCantruOut nhung that cht dung cho Inbound
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.GroupBox12.Visible = False
    End Sub

    Private Sub CấnTrừDeCreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CấnTrừDeCreToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        ' lay toan bo khach hang cua debit
        Dim id, value, strquery As String
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Me.cboCantruDeCre.Items.Clear()
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
            ' co ginbound_OverseaAirImportid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            ' lay toan bo cus add vao cbo
            '------------------------------------------
            ' lay toan bo cus add vao cbo
            id = "CustomerID"
            value = "company"
            strquery = "Select CustomerID,company from inboundfreight left join customer on inboundfreight.CustomerID=customer.customer_id where inboundid='" & gInboundID & "'  and debitcredit='Debit' "

            loadDataToObjectNoClear(Me.cboCantruDeCre, strquery, id, value)

        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gInboundID = Me.dgdHBL.Item("BLIB_ID", index).Value.ToString

            ' lay toan bo cus add vao cbo
            '----------------------------------
            id = "CustomerID"
            value = "company"
            strquery = "Select CustomerID,company from inboundfreight left join customer on inboundfreight.CustomerID=customer.customer_id where inboundid='" & gInboundID & "'  and debitcredit='Credit' "

            loadDataToObjectNoClear(Me.cboCantruDeCre, strquery, id, value)


        End If

        Me.GroupBox12.Visible = True



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub GroupBox12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox12.Enter

    End Sub

    Private Sub GroupBox12_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox12.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox12_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox12.MouseMove

        If Mdown Then
            Me.GroupBox12.Left = (e.X - X) + Me.GroupBox12.Left
            Me.GroupBox12.Top = (e.Y - Y) + Me.GroupBox12.Top
        End If
    End Sub

    Private Sub GroupBox12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox12.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox12.Left = (e.X - X) + Me.GroupBox12.Left
            Me.GroupBox12.Top = (e.Y - Y) + Me.GroupBox12.Top
        End If
    End Sub

    Private Sub cboItemsDebit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsDebit1, Me.cboItemsDebit1.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit1.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit1.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try

    End Sub


    Private Sub cboItemsDebit1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit2_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit2, Me.cboItemsdebit2.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit2.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit2.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit3_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit3, Me.cboItemsdebit3.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit3.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit3.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit4_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit4, Me.cboItemsdebit4.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit4.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit4.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit5_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit5, Me.cboItemsdebit5.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit5.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit5.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit6_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit6, Me.cboItemsdebit6.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit6.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit6.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit7_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit7, Me.cboItemsdebit7.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit7.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit7.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit8_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit8, Me.cboItemsdebit8.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit8.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit8.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit9_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        '' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit9, Me.cboItemsdebit9.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit9.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit9.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit10_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit10, Me.cboItemsdebit10.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit10.Text = ds.Tables(0).Rows(0).Item("tarifffclIB").ToString
        '        Else
        '            Me.txtUnitPriceDebit10.Text = ds.Tables(0).Rows(0).Item("tarifflclIB").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsCredit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff

    End Sub

    Private Sub cboItemsCredit1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub QueryHinhanh(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select path as [File_path] from smf_hinh inner join Inbound_OverseaAirImport on Inbound_OverseaAirImport.BLIB_ID=smf_hinh.BLOB_ID where Inbound_OverseaAirImport.BLIB_ID= '" & mInboundID & "'  "
            otblHinh = ReadTable(sql)
            Me.dgdHinh.DataSource = otblHinh


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default
            InsertAutoNumberToGrid(Me.dgdHinh)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub Querythemhinh(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select hinhid,blob_ID,path "
            sql &= " From smf_hinh "
            sql &= "Where " & _
                   " blob_id='" & mInboundID & "'  "
            oTblEquip = ReadTable(sql)
            Me.dgdThemhinh.DataSource = oTblEquip

            'If location > 0 And location <= Me.dgdchitietthuclap.Rows.Count And Me.dgdchitietthuclap.Rows.Count > 0 Then
            '    Me.dgdchitietthuclap.Rows(location).Selected = True
            '    Me.dgdchitietthuclap.CurrentCell = Me.dgdchitietthuclap.Rows(location).Cells(3)
            'End If
            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdThemhinh)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ThToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThToolStripMenuItem.Click
        Try
            If mStatusHinh = "Normal" Then


                mHinhID = DefaultValue
                mStatusHinh = "Add"
                Me.cmdOKHinh.Enabled = True
                Me.cmdCancelHinh.Enabled = True
                Me.ButtonX1.Enabled = True

            Else
                DisplayMessage(True, "Sorry, the proccess requires an access rigth to carry out.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub XóaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XóaToolStripMenuItem1.Click
        Dim chk As Integer
        chk = Me.dgdThemhinh.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Dim selectedRowCount As Integer = _
       Me.dgdThemhinh.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim f As Integer = 0
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowHinh(Me.dgdThemhinh.SelectedRows(i).Index)
                f = 1
            Next i
        End If
        'If f = 1 Then frmMain.LoadData()
        Me.Querythemhinh()
        Me.QueryHinhanh()
    End Sub
    Public Sub DeleteRowHinh(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strMesg, strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean

        Dim cmd As New ADODB.Command

        strMesg = "Bạn muốn xóa hình : " & Me.dgdThemhinh.Item("path", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from smf_hinh where hinhID= '" & Me.dgdThemhinh.Item("hinhid", index).Value.ToString & "' "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOKHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKHinh.Click
        Try
            Dim sl As Integer
            Dim sql As String
            Dim ds As New DataSet
            Dim strQuery, strEmployeeID, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            If Me.dgdThemhinh.RowCount > 0 Then
                index = Me.dgdThemhinh.CurrentRow.Index
            End If
            'If mID = DefaultValue Then
            '    DisplayMessage(True, "Bạn chưa lưu chứng từ.!, nên không thể thêm hình ảnh.")
            '    Return
            'End If
            'kiem tra so luong theo HD
            If mStatusHinh = "Add" Then

            End If
            'lay so lieu tu Option
            Dim value As String
            Dim rsO As New ADODB.Recordset
            value = "0"
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [option] "
            strQuery = strQuery & "WHERE frmName = 'frm' and OptionCode='PicturePath' And Continued=1 "
            rsO.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rsO
                If Not rsO.EOF Then
                    value = .Fields("optionvalue").Value
                End If

            End With
            rsO.Close()
            ''---------------------------------
            Dim values() As String
            values = value.Split(";")
            value = values(0)
            If mStatusHinh = "Add" Then

                '=========='
                strQuery = "Select * From smf_hinh Where hinhID='" & mHinhID & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("hinhid").Value = NewId()
                    End If
                    mHinhID = .Fields("hinhID").Value.ToString

                    .Fields("blob_ID").Value = getID(mInboundID)


                    .Fields("path").Value = value + Me.cboduongdan.Text

                    .Update()
                End With
                rs.Close()


                Querythemhinh(index)
                Me.QueryHinhanh()

                'QueryEmployee(, 1, 0)
                Me.dgdThemhinh.Enabled = True
                Me.cmdOKHinh.Enabled = False
                Me.ButtonX1.Enabled = False
                'Me.cmdCancelEquipment.Enabled = False
                mStatusHinh = "Normal"

            End If
            '----------------------------------hienthiben luoi hopdong


            '------------------------------------------------------------------
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdCancelHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelHinh.Click
        mStatusHinh = "Normal"
        Me.dgdThemhinh.Enabled = True
        Me.cmdOKHinh.Enabled = False
    End Sub

    Private Sub PICHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PICHinh.Click
        Try
            Dim index As Integer = Me.dgdHinh.CurrentRow.Index
            gHinh = Me.dgdHinh.Item("file_path", index).Value.ToString
            frmHinh.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdHinh_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdHinh.CellContentClick
        Try


            'Dim dd As String
            'Dim chk, index As Integer
            'chk = Me.dgdHinh.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If chk = 0 Then
            '    'DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để xem hình.")
            '    'Return
            'End If
            'index = Me.dgdHinh.CurrentRow.Index

            'dd = Me.dgdHinh.Item(0, index).Value.ToString
            'If dd <> "" Then
            '    Try
            '        Process.Start("""" & dd & """")
            '    Catch
            '        MessageBox.Show("No application is set up for this file. Please go to option settings and choose an editor for this file.", "No Default Application")
            '    End Try
            '    'Me.PICHinh.ImageLocation = dd
            '    'Me.PICHinh.SizeMode = PictureBoxSizeMode.Zoom
            '    'Me.PICHinh.Show()
            '    'Me.PICHinh.Load(dd)
            'End If
        Catch ex As Exception
            DisplayMessage(True, "Xin kiểm tra lại Server.")
        End Try
    End Sub

















    Private Sub cboItemsCredit3_save_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




























































































    Private Sub txtNgayCredit10_save_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    '----chia nguoc 













    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset


            If mStatusContainer = "Add" Or mStatusContainer = "Edit" Then
                Try
                    copyHistory("containerrepair", "inboundcontainersid", mInboundContainerID, "history")
                Catch ex As Exception

                End Try
                ' them container
                '=========='
                strQuery = "Select * From containerrepair Where inboundcontainersid='" & mInboundContainerID & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("inboundContainersID").Value = NewId()
                    End If

                    .Fields("inboundID").Value = getID(mInboundID)
                    '-------------------------------container
                    .Fields("ContainerNo").Value = Me.txtContainerNo.Text
                    '------------------------------------------
                    .Fields("containertype").Value = Me.txtType.Text
                    .Fields("type").Value = Me.txttype_.Text
                    '--------------------------------------------------------------------------------
                    .Fields("seal").Value = Me.txtSeal.Text
                    '------------------------------------------------------------------------------------
                    .Fields("sokien").Value = Me.txtsoKien.Text

                    '-------------------------------------------------------------------------------
                    .Fields("sokg").Value = Me.txtsoKg.Text
                    '---------------------------------------------------------------------
                    .Fields("sokhoi").Value = Me.txtCBM.Text
                    .Fields("chargeable").Value = Me.txtChargeA.Text
                    ' .Fields("path").Value = Me.cboduongdan.Text
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
                        .Fields("ghichu").Value = Me.txtghichuContainer.Text
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
            ' sent qua manifest
            Try
                Dim kien As Double = 0
                Dim pkgs As String
                Dim i As Integer

                If Me.dgdContainers.Rows.Count > 0 Then
                    For i = 0 To Me.dgdContainers.Rows.Count - 1
                        Try
                            kien += CDbl(Me.dgdContainers.Item("sokien", i).Value.ToString)
                        Catch ex As Exception

                        End Try
                        Try
                            pkgs = Me.dgdContainers.Item("type", 0).Value.ToString
                        Catch ex As Exception

                        End Try
                    Next


                End If
                '  Me.txtNumberAndKindOfPackage.Text = kien.ToString + ", " + pkgs

            Catch ex As Exception

            End Try
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            If index >= 0 Then
                If mStatusContainer = "Normal" And UserRight("inbound_OverseaAirImport", "Add") Then

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

                    mInboundContainerID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusContainer = "Add"

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không

            If Me.dgdContainers.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdContainers.CurrentRow.Index
            vitri = index
            If index >= 0 Then

                If mStatusContainer = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.Button49.Enabled = True
                    mInboundContainerID = Me.dgdContainers.Item("inboundContainersID", index).Value.ToString
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

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
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
                    Deleterowcontainer(Me.dgdContainers.SelectedRows(i).Index)
                Next i
            End If
            Me.QueryContainer()
            ' sent qua manifest
            Try
                Dim kien As Double = 0
                Dim pkgs As String
                Dim i As Integer

                If Me.dgdContainers.Rows.Count > 0 Then
                    For i = 0 To Me.dgdContainers.Rows.Count - 1
                        Try
                            kien += CDbl(Me.dgdContainers.Item("sokien", i).Value.ToString)
                        Catch ex As Exception

                        End Try
                        Try
                            pkgs = Me.dgdContainers.Item("type", 0).Value.ToString
                        Catch ex As Exception

                        End Try
                    Next


                End If
                ' Me.txtNumberAndKindOfPackage.Text = kien.ToString + ", " + pkgs

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub QueryContainer(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select inboundcontainersid,inboundid,containerno,containertype,type,seal,sokien,sokg,sokhoi,tinhtrang,danhapkho,daxuatkho,ngayan,ngaydo,ghichu "
            sql &= ",chargeable From Containerrepair "
            sql &= "Where " & _
                   " inboundID='" & mInboundID & "'  "
            oTblEquip = ReadTable(sql)
            Me.dgdContainers.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdContainers)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
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
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container: " & Me.dgdContainers.Item("containerNo", index).Value.ToString
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
                cmd.CommandText = "delete from containerrepair where inboundcontainersid= '" & Me.dgdContainers.Item("INboundContainersID", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub RefreshDataContainer(ByVal index As Integer)
        Try

            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from containerrepair where InboundContainersID='" & mInboundContainerID & "'"

            ds = ReadDataSet(sql)


            Me.txtContainerNo.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.txtType.Text = Me.dgdContainers.Item("containertype", index).Value.ToString


            Me.txtSeal.Text = Me.dgdContainers.Item("seal", index).Value.ToString


            Me.txtsoKien.Text = Me.dgdContainers.Item("sokien", index).Value.ToString


            Me.txttype_.Text = Me.dgdContainers.Item("type", index).Value.ToString


            Me.txtsoKg.Text = Me.dgdContainers.Item("sokg", index).Value.ToString


            Me.txtChargeA.Text = Me.dgdContainers.Item("chargeable", index).Value.ToString



            Me.txtCBM.Text = Me.dgdContainers.Item("sokhoi", index).Value.ToString
            If ds.Tables(0).Rows.Count > 0 Then



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
                    Me.txtghichuContainer.Text = ds.Tables(0).Rows(0).Item("ghichu").ToString
                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub QueryPort(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_Code"
        value = "Port"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 Order By Port desc"
        loadDataToObject(combo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub TabPage9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub txtVessel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVessel.Leave
        Try
            ' Me.txtNameOfShip.Text = Me.txtVessel.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtShipper_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  Me.txtconsigner.Text = Me.txtShipper.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtConsignee_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ' Me.txtconsignee_Manifest.Text = Me.txtConsignee.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHBL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHBL.Leave
        Try
            '  Me.txtBillOfLading.Text = Me.txtHBL.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMBL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMBL.Leave
        Try
            'Me.txtMasterBillNumber.Text = Me.txtMBL.Text
        Catch ex As Exception

        End Try
    End Sub




    Private Sub EManifestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EManifestToolStripMenuItem.Click
        Try
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
                ' co ginbound_OverseaAirImportid ta la bien close
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                    Else
                        DisplayMessage(True, "Lô hàng chưa Approve.!")
                        Exit Sub
                    End If
                End If

                gEManifest = gInboundID


                ' VB6.ShowForm(frmEManifest_OverseaAirImport, VB6.FormShowConstants.Modal, Me)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        Try
            Try
                'allCus()
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusDebit = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdok_debit.Enabled = True
                    '--------------

                    Me.cbocusdebit.Enabled = True

                    Me.cboitemdebit.Enabled = True

                    Me.txtcurrdebit.Enabled = True


                    Me.txtunitdebit.Enabled = True


                    Me.txtquantitydebit.Enabled = True


                    Me.txtunitpricedebit.Enabled = True
                    Me.txtpricenotaxdebit.Enabled = True
                    Me.txtexdebit.Enabled = True
                    Me.txttaxdebit.Enabled = True
                    Me.txtpricetaxdebit.Enabled = True
                    Me.txtpricedebit.Enabled = True
                    Me.txtremarksdebit.Enabled = True
                    Me.chkosdebit.Enabled = True
                    Me.chkpaydebit.Enabled = True
                    Me.txtinvoicedebit.Enabled = True
                    '  Me.txtChargeA.Enabled = True
                    Me.txtinvoicenodebit.Enabled = True

                    Try
                        Me.txtstt.Text = Me.dgddebitGrid.RowCount
                    Catch ex As Exception

                    End Try

                    '---------------------------

                    mdebitID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusDebit = "Add"
                    Me.txtexdebit.Text = getCur("USD")
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDatadebitgrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.cbocusdebit.Text = Me.dgddebitGrid.Item("company_debit", index).Value.ToString
            Me.cboitemdebit.Text = Me.dgddebitGrid.Item("item_debit", index).Value.ToString
            Me.txtcurrdebit.Text = Me.dgddebitGrid.Item("currency_debit", index).Value.ToString


            Me.txtunitdebit.Text = Me.dgddebitGrid.Item("containertype_debit", index).Value.ToString


            Me.txtquantitydebit.Text = Me.dgddebitGrid.Item("quantity_debit", index).Value.ToString


            Me.txtunitpricedebit.Text = Me.dgddebitGrid.Item("unitprice_debit", index).Value.ToString
            Me.txtpricenotaxdebit.Text = Me.dgddebitGrid.Item("pricetruocthue_debit", index).Value.ToString

            Me.txtpricenotaxvnddebit.Text = Me.dgddebitGrid.Item("pricenotaxvnd_debit", index).Value.ToString



            Me.txtexdebit.Text = Me.dgddebitGrid.Item("tigia_debit", index).Value.ToString
            Me.txttaxdebit.Text = Me.dgddebitGrid.Item("taxprice_debit", index).Value.ToString
            Me.txtpricetaxdebit.Text = Me.dgddebitGrid.Item("pricethue_debit", index).Value.ToString
            Me.txtpricedebit.Text = Me.dgddebitGrid.Item("price_debit", index).Value.ToString

            Me.txtremarksdebit.Text = Me.dgddebitGrid.Item("note_debit", index).Value.ToString

            Me.chkosdebit.Checked = Me.dgddebitGrid.Item("Os_debit", index).Value.ToString
            Me.chkpaydebit.Checked = Me.dgddebitGrid.Item("paycheck_debit", index).Value.ToString
            Me.chkshowArrival.Checked = Me.dgddebitGrid.Item("showarrival", index).Value.ToString
            Me.chkagent.Checked = Me.dgddebitGrid.Item("agent", index).Value.ToString

            Me.txtinvoicedebit.Text = Me.dgddebitGrid.Item("ngay_debit", index).Value.ToString

            '  Me.txtChargeA.Enabled = True
            Me.txtinvoicenodebit.Text = Me.dgddebitGrid.Item("ngayhoadon_debit", index).Value.ToString
            Me.txthancongno.Text = Me.dgddebitGrid.Item("hancongno", index).Value.ToString
            Try
                Me.txtstt.Text = Me.dgddebitGrid.Item("stt_debit", index).Value.ToString
            Catch ex As Exception

            End Try

            Try
                Me.chkShowVND.Checked = Me.dgddebitGrid.Item("showvnd", index).Value.ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtdebitno.Text = Me.dgddebitGrid.Item("no_", index).Value.ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtunitpricedebit_.Text = Me.dgddebitGrid.Item("unitprice_debit_", index).Value.ToString
                Me.txtpricedebit_.Text = Me.dgddebitGrid.Item("price_debit_", index).Value.ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtdongiatruocthueVND.Text = FormatNumber(Me.dgddebitGrid.Item("dongiatruocthueVND", index).Value.ToString, 0)
            Catch ex As Exception
                Me.txtdongiatruocthueVND.Text = 0
            End Try

            Try
                Me.txtthanhtientruocthueVND.Text = FormatNumber(Me.dgddebitGrid.Item("thanhtientruocthueVND", index).Value.ToString, 0)
            Catch ex As Exception
                Me.txtthanhtientruocthueVND.Text = 0
            End Try


            Try
                Me.txttienthueVND.Text = FormatNumber(Me.dgddebitGrid.Item("tienthueVND", index).Value.ToString, 0)
            Catch ex As Exception
                Me.txttienthueVND.Text = 0
            End Try
            Try
                Me.txtthanhtiensauthueVND.Text = FormatNumber(Me.dgddebitGrid.Item("thanhtiensauthueVND", index).Value.ToString, 0)
            Catch ex As Exception
                Me.txtthanhtiensauthueVND.Text = 0
            End Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshCashloan(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.txtPurposes.Text = Me.dgdcashloan.Item("column3", index).Value.ToString
            Me.txtDateOfLoan.Text = Me.dgdcashloan.Item("column4", index).Value.ToString
            Me.cbocurrency.Text = Me.dgdcashloan.Item("column5", index).Value.ToString
            Me.txtdateOfRepayment.Text = Me.dgdcashloan.Item("column6", index).Value.ToString
            Me.txtCapital.Text = Me.dgdcashloan.Item("column7", index).Value.ToString
            Me.txtlower.Text = Me.dgdcashloan.Item("column8", index).Value.ToString
            Me.txtCashLoanDetails.Text = Me.dgdcashloan.Item("column9", index).Value.ToString




        Catch ex As Exception

        End Try
    End Sub
    Private Sub EditToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem2.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không
            allCus()
            If Me.dgddebitGrid.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
            Approve = Me.dgddebitGrid.Item("Approvedebit", index).Value
            vitri = index
            If index >= 0 Then

                If mStatusDebit = "Normal" And Not Approve And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdok_debit.Enabled = True

                    mdebitID = Me.dgddebitGrid.Item("inboundfreightID_debit", index).Value.ToString
                    mStatusDebit = "Edit"

                    RefreshDatadebitgrid(index)

                    'Me.QueryContainer()
                    Me.cbocusdebit.Enabled = True

                    Me.cboitemdebit.Enabled = True

                    Me.txtcurrdebit.Enabled = True


                    Me.txtunitdebit.Enabled = True


                    Me.txtquantitydebit.Enabled = True


                    Me.txtunitpricedebit.Enabled = True
                    Me.txtpricenotaxdebit.Enabled = True
                    Me.txtexdebit.Enabled = True
                    Me.txttaxdebit.Enabled = True
                    Me.txtpricetaxdebit.Enabled = True
                    Me.txtpricedebit.Enabled = True
                    Me.txtremarksdebit.Enabled = True
                    Me.chkosdebit.Enabled = True
                    Me.chkpaydebit.Enabled = True
                    Me.txtinvoicedebit.Enabled = True
                    '  Me.txtChargeA.Enabled = True
                    Me.txtinvoicenodebit.Enabled = True

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem2.Click
        Try
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.dgddebitGrid.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    Deleterowdebit(Me.dgddebitGrid.SelectedRows(i).Index)
                Next i
            End If
            Me.Querydebit()
        Catch ex As Exception

        End Try
    End Sub
    Sub Querydebit(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select inboundid,inboundfreightid,customerid,itemid,taxcode + '-' + company as company,charge_code as item,currency,containertype,unitprice,unitprice_, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price,price_, note, quantity, paycheck, os, ngay, ngayhoadon, tigia,dongiatruocthueVND,thanhtientruocthueVND,tienthueVND,thanhtiensauthueVND  "
            sql &= " , userupdate,dateupdate,inboundfreight.approve,showarrival,soNgayCongNo,daily ,inboundfreight.stt,showvnd,no_ From inboundfreight left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
            sql &= "Where " & _
                   " inboundid='" & mInboundID & "'  and debitcredit='Debit'"
            oTblEquip = ReadTable(sql)
            Me.dgddebitGrid.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgddebitGrid)
            profit()
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Public Sub Deleterowdebit(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi


        If Not IsNothing(Me.dgddebitGrid.Item("Approvedebit", index)) Then
            If Me.dgddebitGrid.Item("Approvedebit", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If


        'che tam vi chua co quan he voi Dulieu khac


        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Debit: " & Me.dgddebitGrid.Item("item_debit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                copyHistory("INboundfreight", "INboundfreightid", Me.dgddebitGrid.Item("INboundfreightid_debit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from Inboundfreight where inboundfreightid= '" & Me.dgddebitGrid.Item("inboundfreightid_debit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleteRowCashLoan(ByVal index As Integer)
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
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Cash Loan: " & Me.dgdcashloan.Item("column3", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then

                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from notify where cl1= '" & Me.dgdcashloan.Item("column1", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub cmdok_debit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdcancel_debit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdnguocdebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim tam As Double = 0
            'Try
            '    tam = CDbl(txtpricedebit.Text)
            'Catch ex As Exception

            'End Try
            'Dim txtpricetaxdebit_, txtpricenotaxvnddebit_, txtpricenotaxdebit_, txtunitpricedebit_ As Double
            ''  Me.txtquantitycredit.Text = 1
            'txtpricetaxdebit_ = FormatNumber(tam - (CDbl(txtpricedebit.Text) / ((CDbl(Me.txttaxdebit.Text / 100)) + 1)), 4)
            'txtpricenotaxvnddebit_ = FormatNumber(tam - CDbl(txtpricetaxdebit_), 4)
            'txtpricenotaxdebit_ = FormatNumber(CDbl(txtpricenotaxvnddebit_) / CDbl(Me.txtexdebit.Text), 4)
            'txtunitpricedebit_ = FormatNumber(txtpricenotaxdebit_ / CDbl(Me.txtquantitydebit.Text), 4)
            'Me.txtunitpricedebit.Text = FormatNumber(txtunitpricedebit_, 4)
            'Dim tam As Double = 0
            'Try
            '    tam = CDbl(txtpricenotaxvnddebit.Text)
            'Catch ex As Exception

            'End Try
            'Me.txtquantitydebit.Text = 1
            'Me.txtpricenotaxdebit.Text = FormatNumber((CDbl(txtpricedebit.Text) / ((CDbl(Me.txttaxdebit.Text / 100)) + 1)) / CDbl(Me.txtexdebit.Text), 2)
            'Me.txtunitpricedebit.Text = FormatNumber(Me.txtpricenotaxdebit.Text, 2)



            'Me.txtpricenotaxvnddebit.Text = tam ' FormatNumber(CDbl(Me.txtpricedebit.Text) / (CDbl(Me.txttaxdebit.Text) / 100 + 1), 0)
            'txtpricetaxdebit.Text = FormatNumber(CDbl(Me.txtpricenotaxvnddebit.Text) * CDbl(Me.txttaxdebit.Text) / 100, 0)
            'Me.txtpricedebit.Text = FormatNumber(Me.txtpricedebit.Text, 0)
            Dim VAT As Double
            Dim giasauthue As Double = CDbl(Me.txtpricedebit.Text)
            Dim thue As Double = CDbl(Me.txtpricetaxdebit.Text)
            Dim giatruocthue As Double
            Dim nguyentetruocthue As Double = 0
            Dim nguyentedongia As Double = 0
            giatruocthue = giasauthue - thue

            VAT = FormatNumber(((giasauthue - giatruocthue) / giatruocthue) * 100, 2)
            Me.txttaxdebit.Text = VAT
            Me.txtpricenotaxvnddebit.Text = FormatNumber(System.Math.Round(CDbl(giatruocthue)), 0)
            Me.txtpricetaxdebit.Text = FormatNumber(System.Math.Round(CDbl(Me.txtpricetaxdebit.Text)), 0)
            Me.txtpricenotaxvnddebit.Text = FormatNumber(CDbl(Me.txtpricedebit.Text) - CDbl(Me.txtpricetaxdebit.Text), 0)
            nguyentetruocthue = CDbl(Me.txtpricenotaxvnddebit.Text) / CDbl(Me.txtexdebit.Text)
            nguyentedongia = nguyentetruocthue / CDbl(Me.txtquantitydebit.Text)
            Me.txtunitpricedebit.Text = FormatNumber(nguyentedongia, 4)

            Me.txtpricetaxdebit.Text = FormatNumber(thue, 0)

            Me.txtpricenotaxvnddebit.Text = FormatNumber(giatruocthue, 0)
            Me.txtpricedebit.Text = FormatNumber(giasauthue, 0)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricedebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.chkmanual.Checked = False Then
                Me.txtunitpricedebit.Text = FormatNumber(Me.txtunitpricedebit.Text, 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricedebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtexdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkmanual.Checked = False Then
                Me.txtpricenotaxvnddebit.Text = FormatNumber(CDbl(Me.txtpricenotaxdebit.Text) * CDbl(Me.txtexdebit.Text), 0)
                txttaxdebit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttaxdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkmanual.Checked = False Then

                Me.txtpricetaxdebit.Text = FormatNumber(CDbl(Me.txtpricenotaxdebit.Text) * CDbl(Me.txtexdebit.Text) * CDbl(Me.txttaxdebit.Text) / 100, 0) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)


                Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtpricetaxdebit.Text) + CDbl(Me.txtpricenotaxvnddebit.Text), 0)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem2.Click
        Try
            Try
                allCus()
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusCredit = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdok_credit.Enabled = True
                    '--------------

                    Me.cbocuscredit.Enabled = True

                    Me.cboitemcredit.Enabled = True

                    Me.txtcurrcredit.Enabled = True


                    Me.txtunitcredit.Enabled = True


                    Me.txtquantitycredit.Enabled = True


                    Me.txtunitpricecredit.Enabled = True
                    Me.txtpricenotaxcredit.Enabled = True
                    Me.txtexcredit.Enabled = True
                    Me.txttaxcredit.Enabled = True
                    Me.txtpricetaxcredit.Enabled = True
                    Me.txtpricecredit.Enabled = True
                    Me.txtremarkscredit.Enabled = True
                    Me.chkoscredit.Enabled = True
                    Me.chkpaycredit.Enabled = True
                    Me.txtinvoicecredit.Enabled = True
                    '  Me.txtChargeA.Enabled = True
                    Me.txtinvoicenocredit.Enabled = True



                    '---------------------------

                    mCreditID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
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
    Private Sub RefreshDataCreditgrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.cbocuscredit.Text = Me.dgdCreditGrid.Item("company_Credit", index).Value.ToString
            Me.cboitemcredit.Text = Me.dgdCreditGrid.Item("item_Credit", index).Value.ToString
            Me.txtcurrcredit.Text = Me.dgdCreditGrid.Item("currency_Credit", index).Value.ToString


            Me.txtunitcredit.Text = Me.dgdCreditGrid.Item("containertype_Credit", index).Value.ToString


            Me.txtquantitycredit.Text = Me.dgdCreditGrid.Item("quantity_Credit", index).Value.ToString


            Me.txtunitpricecredit.Text = Me.dgdCreditGrid.Item("unitprice_Credit", index).Value.ToString
            Me.txtpricenotaxcredit.Text = Me.dgdCreditGrid.Item("pricetruocthue_Credit", index).Value.ToString

            Me.txtpricenotaxvndcredit.Text = Me.dgdCreditGrid.Item("pricenotaxvnd_Credit", index).Value.ToString



            Me.txtexcredit.Text = Me.dgdCreditGrid.Item("tigia_Credit", index).Value.ToString
            Me.txttaxcredit.Text = Me.dgdCreditGrid.Item("taxprice_Credit", index).Value.ToString
            Me.txtpricetaxcredit.Text = Me.dgdCreditGrid.Item("pricethue_Credit", index).Value.ToString
            Me.txtpricecredit.Text = Me.dgdCreditGrid.Item("price_Credit", index).Value.ToString

            Me.txtremarkscredit.Text = Me.dgdCreditGrid.Item("note_Credit", index).Value.ToString
            Try
                Me.chkdntt.Checked = Me.dgdCreditGrid.Item("dntt", index).Value.ToString
            Catch ex As Exception

            End Try
            Me.chkoscredit.Checked = Me.dgdCreditGrid.Item("Os_Credit", index).Value.ToString
            Me.chkpaycredit.Checked = Me.dgdCreditGrid.Item("paycheck_Credit", index).Value.ToString
            Me.chkagent_credit.Checked = Me.dgdCreditGrid.Item("agent_credit", index).Value.ToString

            Me.txtinvoicecredit.Text = Me.dgdCreditGrid.Item("ngay_Credit", index).Value.ToString

            '  Me.txtChargeA.Enabled = True
            Me.txtinvoicenocredit.Text = Me.dgdCreditGrid.Item("ngayhoadon_Credit", index).Value.ToString
            Me.chkShowVND_Credit.Checked = Me.dgdCreditGrid.Item("showvnd_credit", index).Value.ToString
            Try
                Me.txtcreditNo.Text = Me.dgdCreditGrid.Item("creditno", index).Value.ToString
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub EditToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem3.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không
            allCus()
            If Me.dgdCreditGrid.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
            Approve = Me.dgdCreditGrid.Item("ApproveCredit", index).Value
            vitri = index
            If index >= 0 Then

                If mStatusCredit = "Normal" And Not Approve And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdok_credit.Enabled = True

                    mCreditID = Me.dgdCreditGrid.Item("inboundfreightID_credit", index).Value.ToString
                    mStatusCredit = "Edit"

                    RefreshDataCreditgrid(index)

                    'Me.QueryContainer()
                    Me.cbocuscredit.Enabled = True

                    Me.cboitemcredit.Enabled = True

                    Me.txtcurrcredit.Enabled = True


                    Me.txtunitcredit.Enabled = True


                    Me.txtquantitycredit.Enabled = True


                    Me.txtunitpricecredit.Enabled = True
                    Me.txtpricenotaxcredit.Enabled = True
                    Me.txtexcredit.Enabled = True
                    Me.txttaxcredit.Enabled = True
                    Me.txtpricetaxcredit.Enabled = True
                    Me.txtpricecredit.Enabled = True
                    Me.txtremarkscredit.Enabled = True
                    Me.chkoscredit.Enabled = True
                    Me.chkpaycredit.Enabled = True
                    Me.txtinvoicecredit.Enabled = True
                    '  Me.txtChargeA.Enabled = True
                    Me.txtinvoicenocredit.Enabled = True

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem3.Click
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
    End Sub
    Sub QueryCredit(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select boss,ktt,dntt,inboundid,inboundfreightid,customerid,itemid,taxcode + '-' + company as company,charge_code as item,currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, tigia,other "
            sql &= " , userupdate,dateupdate,inboundfreight.approve,daily,showvnd,no_ From inboundfreight left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
            sql &= "Where " & _
                   " inboundid='" & mInboundID & "'  and debitcredit='Credit'"
            oTblEquip = ReadTable(sql)
            Me.dgdCreditGrid.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdCreditGrid)
            profit()
            ' doi mau do neu other=1
            Dim i As Integer
            For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
                If Me.dgdCreditGrid.Item("other", i).Value = "True" Then
                    Me.dgdCreditGrid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Me.dgdCreditGrid.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If
            Next
            'End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
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
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Credit: " & Me.dgdCreditGrid.Item("item_Credit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                copyHistory("INboundfreight", "INboundfreightid", Me.dgdCreditGrid.Item("inboundfreightid_credit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from Inboundfreight where inboundfreightid= '" & Me.dgdCreditGrid.Item("inboundfreightid_credit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdcancel_credit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdok_credit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtunitpricecredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtunitpricecredit.Text = FormatNumber(Me.txtunitpricecredit.Text, 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricecredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricenotaxcredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 4)
                txtexcredit_TextChanged(sender, e)
                txttaxcredit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdnguoccredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim tam As Double = 0
            'Try
            '    tam = CDbl(txtpricecredit.Text)
            'Catch ex As Exception

            'End Try
            'Dim txtpricetaxcredit_, txtpricenotaxvndcredit_, txtpricenotaxcredit_, txtunitpricecredit_ As Double
            ''  Me.txtquantitycredit.Text = 1
            'txtpricetaxcredit_ = FormatNumber(tam - (CDbl(txtpricecredit.Text) / ((CDbl(Me.txttaxcredit.Text / 100)) + 1)), 4)
            'txtpricenotaxvndcredit_ = FormatNumber(tam - CDbl(txtpricetaxcredit_), 4)
            'txtpricenotaxcredit_ = FormatNumber(CDbl(txtpricenotaxvndcredit_) / CDbl(Me.txtexcredit.Text), 4)
            'txtunitpricecredit_ = FormatNumber(txtpricenotaxcredit_ / CDbl(Me.txtquantitycredit.Text), 4)
            'Me.txtunitpricecredit.Text = FormatNumber(txtunitpricecredit_, 4)
            'Dim tam As Double = 0
            'Try
            '    tam = CDbl(txtpricenotaxvndcredit.Text)
            'Catch ex As Exception

            'End Try
            'Me.txtquantitycredit.Text = 1
            'Me.txtpricenotaxcredit.Text = (CDbl(txtpricecredit.Text) / ((CDbl(Me.txttaxcredit.Text / 100)) + 1)) / CDbl(Me.txtexcredit.Text)
            'Me.txtunitpricecredit.Text = Me.txtpricenotaxcredit.Text

            'Me.txtpricenotaxvndcredit.Text = tam ' FormatNumber(CDbl(Me.txtpricecredit.Text) / (CDbl(Me.txttaxcredit.Text) / 100 + 1), 0)
            'txtpricetaxcredit.Text = FormatNumber(CDbl(Me.txtpricenotaxvndcredit.Text) * CDbl(Me.txttaxcredit.Text) / 100, 0)
            'Me.txtpricecredit.Text = FormatNumber(Me.txtpricecredit.Text, 0)
            Dim VAT As Double
            Dim giasauthue As Double = CDbl(Me.txtpricecredit.Text)
            Dim thue As Double = CDbl(Me.txtpricetaxcredit.Text)
            Dim giatruocthue As Double
            Dim nguyentetruocthue As Double = 0
            Dim nguyentedongia As Double = 0
            giatruocthue = giasauthue - thue

            VAT = FormatNumber(((giasauthue - giatruocthue) / giatruocthue) * 100, 2)
            Me.txttaxcredit.Text = VAT
            Me.txtpricenotaxvndcredit.Text = FormatNumber(System.Math.Round(CDbl(giatruocthue)), 0)
            Me.txtpricetaxcredit.Text = FormatNumber(System.Math.Round(CDbl(Me.txtpricetaxcredit.Text)), 0)
            Me.txtpricenotaxvndcredit.Text = FormatNumber(CDbl(Me.txtpricecredit.Text) - CDbl(Me.txtpricetaxcredit.Text), 0)
            nguyentetruocthue = CDbl(Me.txtpricenotaxvndcredit.Text) / CDbl(Me.txtexcredit.Text)
            nguyentedongia = nguyentetruocthue / CDbl(Me.txtquantitycredit.Text)
            Me.txtunitpricecredit.Text = FormatNumber(nguyentedongia, 4)

            Me.txtpricetaxcredit.Text = FormatNumber(thue, 0)

            Me.txtpricenotaxvndcredit.Text = FormatNumber(giatruocthue, 0)
            Me.txtpricecredit.Text = FormatNumber(giasauthue, 0)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtexcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricenotaxvndcredit.Text = FormatNumber(CDbl(Me.txtpricenotaxcredit.Text) * CDbl(Me.txtexcredit.Text), 0)
                txttaxcredit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttaxcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricetaxcredit.Text = FormatNumber(CDbl(Me.txtpricenotaxcredit.Text) * CDbl(Me.txtexcredit.Text) * CDbl(Me.txttaxcredit.Text) / 100, 0) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)


                Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtpricetaxcredit.Text) + CDbl(Me.txtpricenotaxvndcredit.Text), 0)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label238_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricedebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricedebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage12.Click

    End Sub

    Private Sub txtKho_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKho.TextChanged

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitemdebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboitemdebit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AddToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem3.Click
        Try
            Try
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusTheodoi = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdoktheodoi.Enabled = True
                    '--------------

                    Me.cboitems.Enabled = True
                    Me.txtRemarks_theodoi.Enabled = True
                    Me.txtTimer.Enabled = True
                    Me.txtValidUser.Enabled = True


                    'Me.txtunitpricecredit.Enabled = True
                    'Me.txtpricenotaxcredit.Enabled = True



                    '---------------------------

                    mTheodoiid = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusTheodoi = "Add"

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem4.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không

            If Me.dgdtheodoi.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdtheodoi.CurrentRow.Index
            vitri = index
            If index >= 0 Then

                If mStatusTheodoi = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdoktheodoi.Enabled = True

                    mTheodoiid = Me.dgdtheodoi.Item("theodoilohanginboundtid", index).Value.ToString
                    mStatusTheodoi = "Edit"

                    RefreshDatatheodoigrid(index)

                    'Me.QueryContainer()
                    Me.cboitems.Enabled = True


                    Me.txtRemarks_theodoi.Enabled = True
                    Me.txtTimer.Enabled = True
                    Me.txtValidUser.Enabled = True


                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDatatheodoigrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.cboitems.Text = Me.dgdtheodoi.Item("items", index).Value.ToString

            Me.txtRemarks_theodoi.Text = Me.dgdtheodoi.Item("remarks", index).Value.ToString
            Me.txtTimer.Text = Me.dgdtheodoi.Item("timer", index).Value.ToString

            Try
                Me.txtngaychungtu.Text = Me.dgdtheodoi.Item("ngaychungtu", index).Value.ToString

                Me.txtbangoc.Text = Me.dgdtheodoi.Item("bangoc", index).Value.ToString
                Me.chkinTheodoi.Checked = Me.dgdtheodoi.Item("intheodoi", index).Value
                Me.txtValidUser.Text = Me.dgdtheodoi.Item("validuser", index).Value.ToString
            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem4.Click
        Try
            If Me.dgdtheodoi.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.dgdtheodoi.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleterowTheodoi(Me.dgdtheodoi.SelectedRows(i).Index)
                Next i
            End If
            Me.Querytheodoi()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub DeleterowTheodoi(ByVal index As Integer)
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
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete theo dõi : " & Me.dgdtheodoi.Item("items", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then

                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from theodoilohanginbound_OverseaAirImport where theodoilohanginbound_OverseaAirImportid= '" & Me.dgdtheodoi.Item("theodoilohanginbound_OverseaAirImportid", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub Querytheodoi(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select inboundid,theodoilohanginboundid,items,remarks,timer,validUser,dateupdate,userupdate,ngaychungtu,bangoc,intheodoi "
            sql &= " From theodoilohanginbound  "
            sql &= "Where " & _
                   " inboundid='" & mInboundID & "' order by dateupdate desc "
            oTblEquip = ReadTable(sql)
            Me.dgdtheodoi.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdtheodoi)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub QueryCashloan(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select cl1 as column1,cl2 as column2,cl3 as column3,cl4 as column4,cl5 as column5,cl6 as column6,cl7 as column7,cl8 as column8,cl9 as column9 "
            sql &= " From notify  "
            sql &= "Where " & _
                   " cl2='" & mInboundID & "'  "
            oTblEquip = ReadTable(sql)
            Me.dgdcashloan.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdcashloan)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub


    Private Sub cmdoktheodoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoktheodoi.Click
        Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset


                If mStatusTheodoi = "Add" Or mStatusTheodoi = "Edit" Then
                    Try
                        copyHistory("theodoilohanginbound", "theodoilohanginboundid", mTheodoiid, "history")
                    Catch ex As Exception

                    End Try
                    ' them container
                    '=========='
                    strQuery = "Select * From theodoilohanginbound Where theodoilohanginboundid='" & mTheodoiid & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("theodoilohanginboundid").Value = NewId()
                            .Fields("inboundID").Value = getID(mInboundID)
                        End If


                        '-------------------------------container

                        .Fields("items").Value = Me.cboitems.Text
                        .Fields("remarks").Value = Me.txtRemarks_theodoi.Text
                        .Fields("timer").Value = Me.txtTimer.Text
                        .Fields("validuser").Value = Me.txtValidUser.Text
                        Try
                            .Fields("ngaychungtu").Value = Me.txtngaychungtu.Text
                            .Fields("bangoc").Value = "Oversea Air Import, Hawb: " + Me.txtHBL.Text
                            .Fields("intheodoi").Value = Me.chkinTheodoi.Checked

                        Catch ex As Exception

                        End Try



                        .Update()
                    End With
                    rs.Close()

                End If
                mStatusTheodoi = "Normal"
                Me.cmdoktheodoi.Enabled = False
                cmdcanceltheodoi_Click(sender, e)
                Me.Querytheodoi()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcanceltheodoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcanceltheodoi.Click
        Try
            Me.cboitems.Enabled = False

            Me.txtRemarks_theodoi.Enabled = False

            Me.txtTimer.Enabled = False


            mStatusTheodoi = "Normal"
            Me.cmdoktheodoi.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgdHBL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgdHBL.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
                If hti.Type = DataGridViewHitTestType.Cell Then
                    If Not dgdHBL.Rows(hti.RowIndex).Selected Then
                        dgdHBL.ClearSelection()
                        dgdHBL.Rows(hti.RowIndex).Selected = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub QueryUserReport()
        Try
            Dim id As String = "usrID"
            Dim value As String = "UsrDP"
            Dim strQuery As String = "select UsrID,Usr as UsrDP from UserList where discontinued=0"
            loadDataToObject(Me.cboUser, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselect.Click
        Try
            Me.txtValidUser.Text += Me.cboUser.Text + ","
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem5.Click
        Try


            Dim sqlkt As String
            Dim dskt As New DataSet
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không

            If Me.dgdHBL.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            vitri = index
            'Try
            '    Me.txtNoDebit.Text = "DN-" + Me.txtRef.Text
            '    Me.txtNoCredit.Text = "CN-" + Me.txtRef.Text
            'Catch ex As Exception

            'End Try

            If index >= 0 Then
                Approve = Me.dgdHBL.Item("Approve", index).Value
                EditTable = Me.dgdHBL.Item("Editable", index).Value
                If mStatus = "Normal" And Not Approve And EditTable And UserRight("inbound_OverseaAirImport", "View") Then
                    'Me.dgdPort.Height = 306
                    'Me.dgdPort.Enabled = False
                    'Me.txtPortCode.Enabled = False
                    Me.TabControl1.Visible = True
                    ReFormat()
                    'SetMenu((False))

                    mInboundID = Me.dgdHBL.Item("BLIB_ID", index).Value.ToString

                    '' lay id de kiem tra
                    sqlkt = "select * from billonline where id='" & mInboundID & "'"
                    dskt = ReadDataSet(sqlkt)
                    If dskt.Tables(0).Rows.Count > 0 Then
                        DisplayMessage(True, " Sorry,the proccess requires an access rigth to carry out, User:  " + dskt.Tables(0).Rows(0).Item("userupdate").ToString)
                        Exit Sub

                    End If
                    ' insertvao billonline   
                    Me.TabControl1.Enabled = True
                    Dim strQuery As String
                    Dim rs As New ADODB.Recordset
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM billonline  "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("editid").Value = NewId()

                        .Fields("id").Value = "{" + mInboundID + "}"
                        .Update()

                    End With
                    rs.Close()

                    '-------------------

                    Me.cmdOK.Enabled = True
                    Me.cmdOKAll.Enabled = True
                    Me.dgdHBL.Enabled = False

                    mStatus = "Edit"
                    reText(mStatus)
                    RefreshData(index)
                    Me.QueryHinhanh()
                    Me.Querythemhinh()
                    QueryContainer()

                    Querydebit()
                    QueryCredit()
                    Querytheodoi()
                    QueryCashloan()
                    SI()
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
            profit()
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub

    Private Sub cbocusdebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from customer where company = '" & Me.cbocusdebit.Text & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    Me.txthancongno.Text = ds.Tables(0).Rows(0).Item("hancongno").ToString
                Catch ex As Exception

                End Try
                If ds.Tables(0).Rows(0).Item("Remarks_sale").ToString <> "" Then


                    DisplayMessage(True, ds.Tables(0).Rows(0).Item("Remarks_sale").ToString)
                End If

            End If
            '------------
            Try
                Try

                    Dim i, j As Integer
                    Dim currow, lap As Integer
                    ' Dim sql As String
                    Me.GroupBox8.Visible = True
                    ' Dim ds As New DataSet
                    Me.dgdref.Rows.Clear()
                    'Agency-Import
                    'Agency-Export
                    'Domestic-Rail
                    'Domestic-Truck
                    'Domestic-Customs
                    'Oversea-Sea - Import
                    'Oversea-Sea - Export
                    'Oversea-Air - Import
                    'Oversea-Air - Export
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'  AND department='Oversea-Air-Import' and '" & Me.dtpDateReport.Value.Date & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE'  order by charge_code "
                    ds = ReadDataSet(sql)

                    If ds.Tables(0).Rows.Count > 0 Then
                        ' them vao luoi

                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            lap = ds.Tables(0).Rows(i).Item("lanlap").ToString
                            For j = 1 To lap
                                Me.dgdref.Rows.Add(1)
                                currow = Me.dgdref.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.dgdref.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.dgdref.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.dgdref.Item("no", currow).Value = ds.Tables(0).Rows(i).Item("no").ToString
                                Me.dgdref.Item("charge", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                                Me.dgdref.Item("tu", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                Me.dgdref.Item("den", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                Me.dgdref.Item("value", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                Me.dgdref.Item("indate", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                Me.dgdref.Item("outdate", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString


                                Me.dgdref.Item("unit", currow).Value = ds.Tables(0).Rows(i).Item("unit").ToString
                                Me.dgdref.Item("cur", currow).Value = ds.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdref.Item("exchange", currow).Value = ds.Tables(0).Rows(i).Item("exchange").ToString

                            Next


                        Next

                    End If
                    ' show all
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where no='TEMPLETE' AND department='Oversea-Air-Import' "
                    ds = ReadDataSet(sql)

                    If ds.Tables(0).Rows.Count > 0 Then
                        ' them vao luoi
                        'Me.GroupBox2.Visible = True
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            lap = ds.Tables(0).Rows(i).Item("lanlap").ToString
                            For j = 1 To lap
                                Me.dgdref.Rows.Add(1)
                                currow = Me.dgdref.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.dgdref.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.dgdref.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.dgdref.Item("no", currow).Value = ds.Tables(0).Rows(i).Item("no").ToString
                                Me.dgdref.Item("charge", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                                Me.dgdref.Item("tu", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                Me.dgdref.Item("den", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                Me.dgdref.Item("value", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                Me.dgdref.Item("indate", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                Me.dgdref.Item("outdate", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString


                                Me.dgdref.Item("unit", currow).Value = ds.Tables(0).Rows(i).Item("unit").ToString
                                Me.dgdref.Item("cur", currow).Value = ds.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdref.Item("exchange", currow).Value = ds.Tables(0).Rows(i).Item("exchange").ToString

                            Next


                        Next

                    End If
                    InsertAutoNumberToGrid(Me.dgdref)
                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

 

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Me.txtShipper.Text = Me.cboShipper.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.txtConsignee.Text = Me.cboConsignee.Text

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.txtNotify.Text = Me.cboNotify.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcode.Click
        Try

            Dim id, value, strSQL As String
            Me.cboCustomerShipper.Items.Clear()
            Me.cboCustomerShipper.Text = ""
            id = "Customer_id"
            value = "Company"
            strSQL = "Select Customer_id,  company From customer  where company like '%" & Me.txtcode.Text.Trim & "%' and continued=1 Order By company"
            loadDataToObject_(Me.cboCustomerShipper, strSQL, id, value)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdchonShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdchonShipper.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from customer where company like N'%" & Me.cboCustomerShipper.Text & "%'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If Me.cboSCN.Text = "Shipper" Then

                    Me.txtShipper.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    Me.txtShipper.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                        Me.txtShipper.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                        Me.txtShipper.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    End If
                ElseIf Me.cboSCN.Text = "Consignee" Then
                    Me.txtConsignee.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    Me.txtConsignee.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                        Me.txtConsignee.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                        Me.txtConsignee.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    End If
                ElseIf Me.cboSCN.Text = "Notify" Then
                    Me.txtNotify.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    Me.txtNotify.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                        Me.txtNotify.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                        Me.txtNotify.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    End If

                ElseIf Me.cboSCN.Text Like "*Agent*" Then
                    Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                        Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                        Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    End If

                End If
            Else
                DisplayMessage(True, "Please check again.!")
            End If
            If Me.cboSCN.Text = "Consignee" Then
                ' lay toan bo email tu PIC
                Dim sqlemail As String
                Dim id, value As String
                id = "PIC_id"
                value = "email"
                Try
                    sqlemail = "select * from PIC where customer_id='" & FindValueID(Me.cboCustomerShipper, Me.cboCustomerShipper.Text) & "' "
                    loadDataToObject(Me.cboemail, sqlemail, id, value)
                Catch ex As Exception

                End Try


            End If
        Catch ex As Exception

        End Try
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
    Private Sub txtetd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtetd.Leave
        Try
            ' truyen 011113

            '  Me.txtetd.Text = Me.dtpETD.Value.Date
            Dim month, day As Integer
            Dim months, days As String
            month = CDate(Me.txtetd.Text).Month
            If month < 10 Then
                months = "0" + month.ToString
            Else
                months = month.ToString
            End If
            day = CDate(Me.txtetd.Text).Day
            If day < 10 Then
                days = "0" + day.ToString
            Else
                days = day.ToString
            End If
            'Me.txtDateOfBillOfLading.Text = days & "-" & months & "-" & CDate(Me.txtetd.Text).Year
            'Me.txtdateOfMasterBill.Text = Me.txtDateOfBillOfLading.Text
            'Me.txtDepartureDate.Text = Me.txtDateOfBillOfLading.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtetd_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtetd.MaskInputRejected
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txteta_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txteta.Leave
        Try
            Me.txteta.Text = chuyenNgay(Me.txteta.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txteta_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txteta.MaskInputRejected
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTimer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTimer.Leave
        Try
            Me.txtTimer.Text = chuyenNgay(Me.txtTimer.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTimer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimer.TextChanged

    End Sub

    Private Sub CoverSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CoverSheetToolStripMenuItem.Click
        Try

            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString


                If LoginSucceeded = True Then
                    Dim form As New frmPrintInboundCoversheet_OverseaAirImport
                    Form.MdiParent = frmMain
                    Form.Show()
                End If

                '  VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub JobProfitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobProfitToolStripMenuItem.Click
        Try
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString

                '  inbound_OverseaAirImport()
                gPrintInbound = "inbound_OverseaAirImport"
                If LoginSucceeded = True Then
                    Dim form As New frmPrintInboundJobprofit
                    Form.MdiParent = frmMain
                    Form.Show()
                End If
                '  VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricenotaxvnddebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try

            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtSFileName.Text = Me.OpenFileDialog1.FileName
            End If
            If Me.txtSFileName.Text = "" Then
                DisplayMessage(True, "Please input file path.")
                Me.txtSFileName.Focus()
                Exit Sub
            End If
            'lay so lieu tu Option
            Dim value As String
            Dim strQuery As String

            Dim rsO As New ADODB.Recordset
            value = "0"
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [option] "
            strQuery = strQuery & "WHERE frmName = 'frm' and OptionCode='PicturePath' And Continued=1 "
            rsO.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rsO
                If Not rsO.EOF Then
                    value = .Fields("optionvalue").Value
                End If

            End With
            rsO.Close()
            ''---------------------------------
            Dim values() As String
            values = value.Split(";")
            Dim user, pass, ftp As String
            user = values(1)
            pass = values(2)
            ftp = values(3)


            Try
                Dim fileName As String = Me.txtSFileName.Text
                Dim toUpload As New FileInfo(fileName)
                Dim client As New WebClient
                ' lay username va pass

                Dim nc As New NetworkCredential(user, pass)

                Dim addy As Uri
                addy = New Uri(ftp & toUpload.Name.ToString())


                client.Credentials = nc
                Try
                    Dim arrReturn As Byte() = client.UploadFile(addy.ToString(), fileName) '//This Line Throwing error
                    MessageBox.Show("File Uploaded Sucessfully")
                    Me.cboduongdan.Text = toUpload.Name.ToString()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem.Click
        Try
            DisplayMessage(True, "Sorry, sẽ cập nhật theo yêu cầu.!")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem1.Click
        Try
            DisplayMessage(True, "Sorry, sẽ cập nhật theo yêu cầu.!")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtquantitydebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtpricedebit_.Text = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) * CDbl(Me.txtquantitydebit.Text), 3)



        Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit.Text) * CDbl(Me.txtquantitydebit.Text), 3)
        txttaxdebit_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub txtquantitycredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtShipper_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShipper.Leave
        Try
            Try
                ' Me.txtconsigner.Text = Me.txtShipper.Text
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtShipper_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipper.TextChanged

    End Sub

    Private Sub txtConsignee_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsignee.Leave
        Try
            ' Me.txtconsignee_Manifest.Text = Me.txtConsignee.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtConsignee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsignee.TextChanged

    End Sub

    Private Sub ArrivalDOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gPrintArrivalDOAuthorizedID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
                ' co ginbound_OverseaAirImportid ta la bien close
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from inbound_OverseaAirImport where blib_id='" & gPrintArrivalDOAuthorizedID & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                    Else
                        DisplayMessage(True, "Lô hàng chưa close.!")
                        Exit Sub
                    End If
                End If
                VB6.ShowForm(frmPrintArrivalDOAuthorizedSITC, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtinvoicedebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub ApproveDebitNote()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not UserRight("inbound_OverseaAirImport", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from inboundfreight where" + " inboundfreightid= '" & Me.dgddebitGrid.Item("inboundfreightid_debit", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub dgddebitGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgddebitGrid.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgddebitGrid.Columns(ColIndex).Name) = "APPROVEDEBIT" And Me.dgddebitGrid.CurrentCellAddress.Y = RowIndex Then
            Call ApproveDebitNote()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.Querydebit()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTKHQ.TextChanged

    End Sub

    Private Sub Label41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboPOL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPOL.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select port from port where port_code='" & Me.cboPOL.Text & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtPOL.Text = ds.Tables(0).Rows(0).Item("port").ToString
                ' Me.cboPortOfLoad.Text = Me.cboPOL.Text + "-" + Me.txtPOL.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboPOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPOL.SelectedIndexChanged

    End Sub

    Private Sub cbopodCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbopodCode.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select port from port where port_code='" & Me.cbopodCode.Text & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtPOD.Text = ds.Tables(0).Rows(0).Item("port").ToString
                'Me.cboPortOfUnload.Text = Me.cbopodCode.Text + "-" + Me.txtPOD.Text
                'Me.cboPortOfDestination.Text = Me.cbopodCode.Text + "-" + Me.txtPOD.Text

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopodCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbopodCode.SelectedIndexChanged

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sql, strQuery As String
            Dim ds As New DataSet
            Dim cmd As New ADODB.Command
            Dim rs As New ADODB.Recordset
            ' sql = "select * from outboundfreight where quotationid='" & FindValueID(Me.cboquotationNo, Me.cboquotationNo.Text) & "' "
            'sql = "Select outboundid,outboundfreightid,customerid,itemid,company,charge as item,currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, tigia "
            'sql &= " From outboundfreight left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
            'sql &= "Where " & _
            '       " quotationid='" & FindValueID(Me.cboquotationNo, Me.cboquotationNo.Text) & "'  and debitcredit='Debit'"

            'ds = ReadDataSet(sql)
            'If ds.Tables(0).Rows.Count > 0 Then
            '    Me.dgddebitGrid.DataSource = ds.Tables(0)
            'End If
            ' 
            '------------------------
            'cmd.let_ActiveConnection(strconn)
            'cmd.CommandText = "update Outboundfreight set outboundid= '" & mOutboundID & "' where quotationid='" & FindValueID(Me.cboquotationNo, Me.cboquotationNo.Text) & "' "

            'cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            '-------------
            ' kiem tra
           
            '---------------------------------

           
            '-----------------

            Me.Querydebit()
            InsertAutoNumberToGrid(Me.dgddebitGrid)
            Me.QueryCredit()
            InsertAutoNumberToGrid(Me.dgdCreditGrid)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtShippingMarks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShippingMarks.Leave
        Try
            ' Me.txtghichu.Text = Me.txtShippingMarks.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtShippingMarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShippingMarks.TextChanged

    End Sub

    Private Sub txtDel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDel.Leave
        Try
            ' Me.txtdiadiemgiaohang.Text = Me.txtDel.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDel.SelectedIndexChanged

    End Sub

    Private Sub TabPage7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage7.Click

    End Sub

    Private Sub AddToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem4.Click
        Try
            Try
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusCashLoan = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdOKcashLoan.Enabled = True
                    '--------------




                    '---------------------------

                    mCashLoanID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusCashLoan = "Add"
                    Me.txtCashLoanDetails.Text = "Ref #" + Me.txtRef.Text + "  BL #" + Me.txtHBL.Text

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem6.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không

            If Me.dgdcashloan.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdcashloan.CurrentRow.Index
            vitri = index
            If index >= 0 Then

                If mStatusCashLoan = "Normal" And UserRight("inbound_OverseaAirImport", "Edit") Then

                    Me.cmdOKcashLoan.Enabled = True

                    mCashLoanID = Me.dgdcashloan.Item("Column1", index).Value.ToString
                    mStatusCashLoan = "Edit"

                    RefreshCashloan(index)

                    'Me.QueryContainer()


                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem5.Click
        Try
            If Me.dgdcashloan.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.dgdcashloan.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRowCashLoan(Me.dgdcashloan.SelectedRows(i).Index)
                Next i
            End If
            Me.QueryCashloan()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKcashLoan.Click
        Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset



                '-----------------------------------

                If mStatusCashLoan = "Add" Or mStatusCashLoan = "Edit" Then
                    Try
                        copyHistory("notify", "cl1", mCashLoanID, "history")
                    Catch ex As Exception

                    End Try
                    ' them container
                    '=========='
                    strQuery = "Select * From notify Where cl1='" & mCashLoanID & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("cl1").Value = NewId()
                            .Fields("cl2").Value = getID(mInboundID)
                        End If


                        '-------------------------------container

                        .Fields("cl3").Value = Me.txtPurposes.Text
                        .Fields("cl4").Value = Me.txtDateOfLoan.Text
                        .Fields("cl5").Value = Me.cbocurrency.Text
                        .Fields("cl6").Value = Me.txtdateOfRepayment.Text
                        .Fields("cl7").Value = Me.txtCapital.Text
                        .Fields("cl8").Value = Me.txtlower.Text
                        .Fields("cl9").Value = Me.txtCashLoanDetails.Text
                        .Fields("notify_code").Value = "1"
                        .Update()
                    End With
                    rs.Close()

                End If
                mStatusCashLoan = "Normal"
                Me.cmdOKcashLoan.Enabled = False
                Me.cmdcancelCashloan_Click(sender, e)
                Me.QueryCashloan()
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelCashloan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelCashloan.Click
        Try
            mStatusCashLoan = "Normal"
            Me.cmdOKcashLoan.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCapital_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapital.Leave
        Try
            Me.txtlower.Text = VNumberToWord(Me.txtCapital.Text.ToString, Me.cbocurrency.Text)
            Me.txtCashLoanDetails.Text += "  ," + Me.cbocurrency.Text + " " + Me.txtCapital.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCapital.TextChanged

    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            If Me.dgdcashloan.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdcashloan.CurrentRow.Index
            vitri = index
            If index >= 0 Then


                gPrintCashLoanID = Me.dgdcashloan.Item("Column1", index).Value.ToString

            End If

            If gPrintCashLoanID <> "" Then
                VB6.ShowForm(FrmExportcashLoan, VB6.FormShowConstants.Modeless, Me)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        Try
            Try


                Dim sqlkt As String
                Dim dskt As New DataSet
                Dim Approve, EditTable, UsrRight As Boolean

                'kiểm tra xem Grid có dữ liệu không

                If Me.dgdHBL.RowCount = 0 Then
                    DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                    Return
                End If
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                vitri = index


                If index >= 0 Then



                    gViewHistory = Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    If LoginSucceeded = True Then
                        Dim form As New frmViewHistory
                        Form.MdiParent = frmMain
                        Form.Show()
                    End If
                    '    .Show()

                End If

            Catch ex As Exception
                MsgBox(msgErr(Me, Err.Description))
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHBL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHBL.TextChanged
        Try
            ' Me.txtBillOfLading.Text = Me.txtHBL.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMBL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMBL.TextChanged
        Try
            ' Me.txtMasterBillNumber.Text = Me.txtMBL.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcurrdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If UCase(Me.txtcurrdebit.Text) = "VND" Then
                DisplayMessage(True, "Xin lỗi, SMF chỉ chấp nhận Nguyên tệ (VND thể hiện phía sau.)")
                Me.txtcurrdebit.Text = "USD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcurrcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If UCase(Me.txtcurrcredit.Text) = "VND" Then
                DisplayMessage(True, "Xin lỗi, SMF chỉ chấp nhận Nguyên tệ (VND thể hiện phía sau.)")
                Me.txtcurrcredit.Text = "USD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgddebitGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            Dim tong As Double = 0
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgddebitGrid.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect.Text = FormatNumber(tong.ToString)
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
    Public Sub ApproveCreditNote()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not UserRight("inbound_OverseaAirImport", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from inboundfreight where" + " inboundfreightid = '" & Me.dgdCreditGrid.Item("inboundfreightid_credit", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub dgdCreditGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCreditGrid.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdCreditGrid.Columns(ColIndex).Name) = "APPROVECREDIT" And Me.dgdCreditGrid.CurrentCellAddress.Y = RowIndex Then
            Call ApproveCreditNote()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryCredit()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdCreditGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            Dim tong As Double = 0
            If Me.dgdCreditGrid.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgdCreditGrid.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect1.Text = FormatNumber(tong.ToString)
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

    Private Sub cboitemcredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ' ;lay gia tien
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from charge where charge_id='" & FindValueID(Me.cboitemcredit, Me.cboitemcredit.Text) & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then

                Me.txtunitcredit.Text = ds.Tables(0).Rows(0).Item("unit").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitemcredit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label262_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkmanual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricenotaxdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricetaxdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricenotaxcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricenotaxvndcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpricetaxcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboSale_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSale.Leave
        Try
            SI()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboSale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSale.SelectedIndexChanged
        Try
            SI()
        Catch ex As Exception

        End Try
    End Sub
    Public Function profitAm(ByVal ref As String) As Double
        Try
            ' tong thu
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            Dim tongthu As Double = 0
            Dim tongchi As Double = 0
            sql = "select * from inbound_OverseaAirImport left join inbound_OverseaAirImportfreight on inbound_OverseaAirImport.blib_id=inbound_OverseaAirImportfreight.inbound_OverseaAirImportid where ref='" & ref & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        If ds.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                            tongthu += ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString
                        End If
                        If ds.Tables(0).Rows(i).Item("debitcredit").ToString = "Credit" Then
                            tongchi += ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString
                        End If
                    Catch ex As Exception

                    End Try
                Next

            End If
            Return tongthu - tongchi
        Catch ex As Exception

        End Try
    End Function
    Private Sub Button18_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            Dim i As Integer
            For i = 0 To Me.dgdHBL.RowCount - 1
                If profitAm(Me.dgdHBL.Item("ref", i).Value.ToString) = 0 Then
                    Me.dgdHBL.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    ' Me.dgdHBL.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                If profitAm(Me.dgdHBL.Item("ref", i).Value.ToString) < 0 Then
                    Me.dgdHBL.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    ' Me.dgdHBL.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GiấyRútHàngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GiấyRútHàngToolStripMenuItem.Click
        Try
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
                gRef_CVRH = Me.dgdHBL.Item("ref", index).Value.ToString



                VB6.ShowForm(frmGiayRutHang, VB6.FormShowConstants.Modal, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DSKHRútHàngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DSKHRútHàngToolStripMenuItem.Click
        Try
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
                gRef_CVRH = Me.dgdHBL.Item("ref", index).Value.ToString



                VB6.ShowForm(frmDSKH, VB6.FormShowConstants.Modal, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAgent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAgent.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from customer where customer_id ='" & FindValueID(Me.cboAgent, Me.cboAgent.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("address").ToString + vbCrLf
                Me.txtAgencyName.Text += "Tel: " + ds.Tables(0).Rows(0).Item("tel").ToString + "  Fax: " + ds.Tables(0).Rows(0).Item("fax").ToString


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAgent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgent.SelectedIndexChanged
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from customer where customer_id ='" & FindValueID(Me.cboAgent, Me.cboAgent.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("address").ToString + vbCrLf
                Me.txtAgencyName.Text += "Tel: " + ds.Tables(0).Rows(0).Item("tel").ToString + "  Fax: " + ds.Tables(0).Rows(0).Item("fax").ToString

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewFileToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdHinh.CurrentRow.Index
            Dim tenfile As String
            Dim path As String
            path = getOptionValue("frm", "SchedulePath", "SchedulePath", "SchedulePath", "C")
            If index >= 0 Then

                tenfile = Me.dgdHinh.Item("File_path", index).Value.ToString
                Try
                    Process.Start("""" & tenfile & """")
                Catch
                    MessageBox.Show("No application is set up for this file. Please go to option settings and choose an editor for this file.", "No Default Application")
                End Try

                '
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,shortname as company From customer where continued=1 and company like '%" & Me.txtfindCustomer.Text & "%' or taxcode like '%" & Me.txtfindCustomer.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cboCustomer, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkClose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClose.CheckedChanged

    End Sub

    Private Sub chkClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkClose.KeyDown
        Try
            Dim dau As Boolean
            dau = Me.chkClose.Checked
            If UserRight("inbound_OverseaAirImport", "Execute") = True Then
                ' Me.chkClose.Checked = Not dau

            Else


                Me.chkClose.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkClose_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkClose.MouseDown
        Try
            Dim dau As Boolean
            dau = Me.chkClose.Checked
            If UserRight("inbound_OverseaAirImport", "Execute") = True Then
                ' Me.chkClose.Checked = Not dau

            Else


                Me.chkClose.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HouseCargoManifestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HouseCargoManifestToolStripMenuItem.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GToolStripMenuItem.Click
        Try
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
                ' co ginbound_OverseaAirImportid ta la bien close
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from inbound_OverseaAirImport where blib_id='" & gInboundID & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                    Else
                        DisplayMessage(True, "Lô hàng chưa Approve.!")
                        Exit Sub
                    End If
                End If

                gGiayUyquyen = gInboundID

                If LoginSucceeded = True Then
                    Dim form As New frmPrintDOExcel
                    Form.MdiParent = frmMain
                    Form.Show()
                End If
                '   VB6.ShowForm(, VB6.FormShowConstants.Modal, Me)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtContainerNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContainerNo.Leave
        Try
            Try

                DisplayMessage(True, CheckContainerNumber(Me.txtContainerNo.Text))
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtContainerNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContainerNo.TextChanged

    End Sub
    Private Sub gport_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GPort.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub gport_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GPort.MouseMove
        If Mdown Then
            Me.GPort.Left = (e.X - X) + Me.GPort.Left
            Me.GPort.Top = (e.Y - Y) + Me.GPort.Top
        End If
    End Sub

    Private Sub gport_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GPort.MouseUp
        If Mdown Then
            Mdown = False
            Me.GPort.Left = (e.X - X) + Me.GPort.Left
            Me.GPort.Top = (e.Y - Y) + Me.GPort.Top
        End If
    End Sub

    Private Sub cmdShowPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowPort.Click
        Try
            Me.GPort.BringToFront()
            PortPOLPOD = "POL"
            Me.GPort.Visible = True
            Me.GPort.Text = "Select POL"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortExit.Click
        Try
            Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdselectPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectPort.Click
        Try
            If Me.DataGridView4.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.DataGridView4.CurrentRow.Index
            vitri = index
            'Try
            '    Me.txtNoDebit.Text = "DN-" + Me.txtRef.Text
            '    Me.txtNoCredit.Text = "CN-" + Me.txtRef.Text
            'Catch ex As Exception

            'End Try

            If index >= 0 Then
                If PortPOLPOD = "POL" Then
                    Me.cboPOL.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.txtPOL.Text = Me.DataGridView4.Item("port", index).Value.ToString
                ElseIf PortPOLPOD = "POD" Then
                    Me.cbopodCode.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.txtPOD.Text = Me.DataGridView4.Item("port", index).Value.ToString

                End If


            End If
            Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortSearch.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If Me.txtGPortCode.Text <> "" And Me.txtgportName.Text = "" Then
                sql = "select port_id,port_code,port from port where port_code like '%" & Me.txtGPortCode.Text & "%'  order by port_code    "
            ElseIf Me.txtGPortCode.Text = "" And Me.txtgportName.Text <> "" Then
                'or port like '%" & txtgportName.Text & "%'
                sql = "select port_id,port_code,port from port where port like '%" & Me.txtgportName.Text & "%'  order by port_code   "
            ElseIf Me.txtGPortCode.Text = "" And Me.txtgportName.Text = "" Then
                sql = "select port_id,port_code,port from port order by port_code  "
            ElseIf Me.txtGPortCode.Text <> "" And Me.txtgportName.Text <> "" Then
                sql = "select port_id,port_code,port from port where port_code like '%" & Me.txtGPortCode.Text & "%'  and port like '%" & Me.txtgportName.Text & "%' order by port_code    "
            End If
            ds = ReadDataSet(sql)
            Me.DataGridView4.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.DataGridView4)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortAdd.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Port "
            strQuery = strQuery & "WHERE port_code = '" & Me.txtGPortCode.Text.Trim & "' " ' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Port_Id").Value = NewId()

                End If
                .Fields("Port_Code").Value = Me.txtGPortCode.Text
                .Fields("Port").Value = UCase(Trim(Me.txtgportName.Text))
                .Fields("show").Value = True

                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()
            Me.cmdPortSearch_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdshowportPOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowportPOD.Click
        Try
            Me.GPort.BringToFront()
            PortPOLPOD = "POD"
            Me.GPort.Visible = True
            Me.GPort.Text = "Select POD"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Try
            TXTInvoiceRequestDate.Text = ddMMMyyyy(Me.DateTimePicker1.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        Try
            Me.txtArrival_kinhgui.Text = Me.txtConsignee.Text
            Me.txtArrival_tau.Text = Me.txtVessel.Text
            Me.txtarrival_chuyen.Text = Me.txtVoyage.Text
            Me.txtarrival_pol.Text = Me.txtPOL.Text
            Me.txtarrival_pod.Text = Me.txtPOD.Text
            Me.txtarrival_eta.Text = Me.txteta.Text

            Me.txtarrival_hbl.Text = Me.txtHBL.Text
            Me.txtarrival_mbl.Text = Me.txtMBL.Text
            ' lay cont va seal
            Dim i As Integer
            Dim cont As String
            Dim sl As Double = 0
            Dim soluong As String
            Dim loai As String
            Dim trongluong As Double = 0
            Dim sokhoi As Double = 0

            For i = 0 To Me.dgdContainers.RowCount - 1
                Try
                    cont += Me.dgdContainers.Item("containerNo", i).Value.ToString + "/" + Me.dgdContainers.Item("seal", i).Value.ToString + ";" + Chr(13)

                Catch ex As Exception

                End Try

                Try
                    sl += CDbl(Me.dgdContainers.Item("sokien", i).Value.ToString)

                Catch ex As Exception

                End Try
                Try
                    loai = Me.dgdContainers.Item("type", i).Value.ToString
                Catch ex As Exception

                End Try
                Try
                    trongluong += CDbl(Me.dgdContainers.Item("sokg", i).Value.ToString)

                Catch ex As Exception

                End Try
                Try
                    sokhoi += CDbl(Me.dgdContainers.Item("sokhoi", i).Value.ToString)

                Catch ex As Exception

                End Try
            Next
            ' Me.txtarrival_socontseal.Text = cont
            Me.txtarrival_soluong.Text = FormatNumber(sl, 0) + " " + loai
            '---
            Me.txtarrival_chitiethanghoa.Text = Me.txtDescription.Text

            Me.txtarrival_trongluong.Text = FormatNumber(trongluong.ToString, 3)
            Me.txtarrival_khoiluong.Text = FormatNumber(sokhoi.ToString, 3)
            ' Me.txtarrival_billtype.Text = Me.txtBL_Type.Text

            ' lay phi
            Dim chuoi As String = ""

            For i = 0 To Me.dgddebitGrid.RowCount - 1
                Try
                    If Me.dgddebitGrid.Item("ShowArrival", i).Value.ToString = "True" Then
                        chuoi += (i + 1).ToString + "/ " + Me.dgddebitGrid.Item("Item_debit", i).Value.ToString + "_" + Me.dgddebitGrid.Item("currency_debit", i).Value.ToString + "_" + FormatNumber(CDbl(Me.dgddebitGrid.Item("unitprice_debit", i).Value.ToString), 3) + "_" + Me.dgddebitGrid.Item("containertype_debit", i).Value.ToString + "_" + "$" + FormatNumber(CDbl(Me.dgddebitGrid.Item("unitprice_debit", i).Value.ToString) * CDbl(Me.dgddebitGrid.Item("quantity_debit", i).Value.ToString), 3) + "_" + "$" + FormatNumber((CDbl(Me.dgddebitGrid.Item("unitprice_debit", i).Value.ToString) * CDbl(Me.dgddebitGrid.Item("quantity_debit", i).Value.ToString)) * CDbl(Me.dgddebitGrid.Item("taxprice_Debit", i).Value.ToString) / 100, 3) + "_" + "$" + FormatNumber((CDbl(Me.dgddebitGrid.Item("unitprice_debit", i).Value.ToString) * CDbl(Me.dgddebitGrid.Item("quantity_debit", i).Value.ToString)) + ((CDbl(Me.dgddebitGrid.Item("unitprice_debit", i).Value.ToString) * CDbl(Me.dgddebitGrid.Item("quantity_debit", i).Value.ToString) * CDbl(Me.dgddebitGrid.Item("taxprice_Debit", i).Value.ToString)) / 100), 3) + Chr(10) + Chr(13) + vbCrLf


                    End If
                Catch ex As Exception

                End Try

            Next

            Me.txtarrival_phi.Text = chuoi
            '  do
            Me.txtDO_Kinhgui.Text = "HẢI QUAN " + Me.cboCY.Text + Chr(10) + Chr(13) + vbCrLf
            Me.txtDO_Consignee.Text = Me.txtConsignee.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.dgddebitGrid.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    Removerowdebit(Me.dgddebitGrid.SelectedRows(i).Index)
                Next i
            End If
            Me.Querydebit()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Removerowdebit(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi


        If Not IsNothing(Me.dgddebitGrid.Item("Approvedebit", index)) Then
            If Me.dgddebitGrid.Item("Approvedebit", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If


        'che tam vi chua co quan he voi Dulieu khac


        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Debit: " & Me.dgddebitGrid.Item("item_debit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                copyHistory("INboundfreight", "INboundfreightid", Me.dgddebitGrid.Item("INboundfreightid_debit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "update  inbound_OverseaAirImportfreight set inbound_OverseaAirImportid='" & DefaultValue & "' where inbound_OverseaAirImportfreightid= '" & Me.dgddebitGrid.Item("inbound_OverseaAirImportfreightid_debit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RemoveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem1.Click
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
                    RemoverowCredit(Me.dgdCreditGrid.SelectedRows(i).Index)
                Next i
            End If
            Me.QueryCredit()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub RemoverowCredit(ByVal index As Integer)
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
        If Not UserRight("inbound_OverseaAirImport", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Credit: " & Me.dgdCreditGrid.Item("item_Credit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                copyHistory("INboundfreight", "INboundfreightid", Me.dgdCreditGrid.Item("inbound_OverseaAirImportfreightid_credit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "update  inbound_OverseaAirImportfreight set inbound_OverseaAirImportid='" & DefaultValue & "' where inbound_OverseaAirImportfreightid= '" & Me.dgdCreditGrid.Item("inbound_OverseaAirImportfreightid_credit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox8_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub GroupBox8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Mdown Then
            Me.GroupBox8.Left = (e.X - X) + Me.GroupBox8.Left
            Me.GroupBox8.Top = (e.Y - Y) + Me.GroupBox8.Top
        End If
    End Sub

    Private Sub GroupBox8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Mdown Then
            Mdown = False
            Me.GroupBox8.Left = (e.X - X) + Me.GroupBox8.Left
            Me.GroupBox8.Top = (e.Y - Y) + Me.GroupBox8.Top
        End If
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbocuscredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            cbocuscredit_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocuscredit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.GroupBox8_credit.Visible = False
        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub cmdok_debit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok_debit.Click
        Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset
                ' kiem tra han cong no tien
                Dim sql As String
                Dim ds As New DataSet
                Dim tong As Double = 0
                If CDbl(Me.txtexdebit.Text) <= 1 Then
                    DisplayMessage(True, "Xin nhập tỉ giá hiện tại.")
                    Me.txtexdebit.Focus()
                    Exit Sub
                End If
                If Me.txtexdebit.Text = "1" Or Me.txtexdebit.Text = "" Then
                    DisplayMessage(True, "Xin nhập tỉ giá.")
                    Me.txtexdebit.Focus()
                    Exit Sub
                End If
                tong = tienCongno(FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text), "A")

                sql = "select * from customer where customer_id = '" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'"
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then

                    Try
                        If tong >= CDbl(ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString) Then
                            DisplayMessage(True, "Hạn công nợ đã vượt quá.!")
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try

                End If
                '-----------------------------------

                If mStatusDebit = "Add" Or mStatusDebit = "Edit" Then
                    Try
                        copyHistory("Inboundfreight", "Inboundfreightid", mdebitID, "history")
                    Catch ex As Exception

                    End Try
                    ' them container
                    '=========='
                    strQuery = "Select * From Inboundfreight Where Inboundfreightid='" & mdebitID & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("inboundfreightID").Value = NewId()
                            .Fields("inboundID").Value = getID(mInboundID)
                        End If


                        '-------------------------------container
                        .Fields("customerid").Value = "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"
                        .Fields("itemid").Value = "{" + FindValueID(Me.cboitemdebit, Me.cboitemdebit.Text) + "}"
                        .Fields("currency").Value = Me.txtcurrdebit.Text
                        .Fields("containertype").Value = Me.txtunitdebit.Text
                        .Fields("unitprice").Value = Me.txtunitpricedebit.Text
                        .Fields("quantity").Value = Me.txtquantitydebit.Text
                        '.Fields("pricetruocthue").Value = Me.txtpricenotaxdebit.Text
                        '.Fields("pricenotaxvnd").Value = Me.txtpricenotaxvnddebit.Text


                        .Fields("taxprice").Value = Me.txttaxdebit.Text
                        '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text
                        .Fields("price").Value = Me.txtpricedebit.Text
                        .Fields("note").Value = Me.txtremarksdebit.Text
                        .Fields("os").Value = Me.chkosdebit.Checked
                        .Fields("paycheck").Value = Me.chkpaydebit.Checked
                        .Fields("showarrival").Value = Me.chkshowArrival.Checked
                        .Fields("daily").Value = Me.chkagent.Checked

                        .Fields("ngay").Value = Me.txtinvoicedebit.Text
                        .Fields("ngayhoadon").Value = Me.txtinvoicenodebit.Text
                        .Fields("tigia").Value = Me.txtexdebit.Text
                        .Fields("debitcredit").Value = "Debit"
                        .Fields("songaycongno").Value = Me.txthancongno.Text
                        Try
                            .Fields("stt").Value = Me.txtstt.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("showvnd").Value = Me.chkShowVND.Checked
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("no_").Value = Me.txtdebitno.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("unitprice_").Value = Me.txtunitpricedebit_.Text 'CDbl(Me.txtunitpricedebit.Text) / ((CDbl(Me.txttaxdebit.Text) / 100) + 1)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("price_").Value = Me.txtpricedebit_.Text 'CDbl(Me.txtpricedebit.Text) / ((CDbl(Me.txttaxdebit.Text) / 100) + 1)
                        Catch ex As Exception

                        End Try
                        ' them dongiatruocthueVND chua nhan sl
                        ' them dongiatruocthueVND chua nhan sl
                        Try
                            If Me.txtcurrdebit.Text.Trim <> "VND" Then
                                .Fields("dongiatruocthueVND").Value = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) * CDbl(Me.txtexdebit.Text), 0)
                            Else
                                .Fields("dongiatruocthueVND").Value = FormatNumber(Me.txtunitpricedebit_.Text, 0)
                            End If

                        Catch ex As Exception

                        End Try

                        Try
                            If Me.txtcurrdebit.Text.Trim <> "VND" Then
                                .Fields("thanhtientruocthueVND").Value = FormatNumber((.Fields("dongiatruocthueVND").Value) * CDbl(.Fields("quantity").Value), 0)  'FormatNumber(CDbl(Me.txtpricedebit_.Text) * CDbl(Me.txtexdebit.Text), 0)
                            Else
                                .Fields("thanhtientruocthueVND").Value = FormatNumber((.Fields("dongiatruocthueVND").Value) * CDbl(.Fields("quantity").Value), 0)  'FormatNumber(CDbl(Me.txtpricedebit_.Text) * CDbl(Me.txtexdebit.Text), 0)
                            End If

                        Catch ex As Exception

                        End Try

                        Try
                            If Me.txtcurrdebit.Text.Trim <> "VND" Then
                                .Fields("tienthueVND").Value = FormatNumber(CDbl(.Fields("thanhtientruocthueVND").Value) * CDbl(.Fields("taxprice").Value) / 100, 0) 'FormatNumber((CDbl(Me.txtpricedebit.Text) - CDbl(Me.txtpricedebit_.Text)) * CDbl(Me.txtexdebit.Text), 0)
                            Else
                                .Fields("tienthueVND").Value = FormatNumber(CDbl(.Fields("thanhtientruocthueVND").Value) * CDbl(.Fields("taxprice").Value) / 100, 0) ' FormatNumber((CDbl(Me.txtpricedebit.Text) - CDbl(Me.txtpricedebit_.Text)), 0)
                            End If

                        Catch ex As Exception

                        End Try

                        Try
                            If Me.txtcurrdebit.Text.Trim <> "VND" Then
                                .Fields("thanhtiensauthueVND").Value = FormatNumber(CDbl(.Fields("thanhtientruocthueVND").Value) * ((CDbl(.Fields("taxprice").Value) / 100) + 1), 0) 'FormatNumber((CDbl(Me.txtpricedebit.Text)) * CDbl(Me.txtexdebit.Text), 0)
                            Else
                                .Fields("thanhtiensauthueVND").Value = FormatNumber(CDbl(.Fields("thanhtientruocthueVND").Value) * ((CDbl(.Fields("taxprice").Value) / 100) + 1), 0)
                            End If

                        Catch ex As Exception

                        End Try
                        .Update()


                        If CDbl(rs.Fields("thanhtientruocthueVND").Value.ToString) + CDbl(rs.Fields("tienthueVND").Value.ToString) <> CDbl(rs.Fields("thanhtiensauthueVND").Value.ToString) Then
                            DisplayMessage(True, "Xin kiểm tra lại tiền thuế trong phần hóa đơn.!")
                        End If

                    End With
                    rs.Close()

                End If
                mStatusDebit = "Normal"
                Me.cmdok_debit.Enabled = False
                Me.cmdcancel_debit_Click(sender, e)
                Me.Querydebit()
                checkTigia()
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
            profit()
        Catch ex As Exception

        End Try
        'Try
        '    Try
        '        Dim strQuery As String
        '        Dim rs As New ADODB.Recordset
        '        ' kiem tra han cong no tien
        '        Dim sql As String
        '        Dim ds As New DataSet
        '        Dim tong As Double = 0
        '        If CDbl(Me.txtexdebit.Text) <= 1 Then
        '            DisplayMessage(True, "Xin nhập tỉ giá hiện tại.")
        '            Me.txtexdebit.Focus()
        '            Exit Sub
        '        End If
        '        If Me.txtexdebit.Text = "1" Or Me.txtexdebit.Text = "" Then
        '            DisplayMessage(True, "Xin nhập tỉ giá.")
        '            Me.txtexdebit.Focus()
        '            Exit Sub
        '        End If
        '        tong = tienCongno(FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text), "A")

        '        sql = "select * from customer where customer_id = '" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'"
        '        ds = ReadDataSet(sql)
        '        If ds.Tables(0).Rows.Count > 0 Then

        '            Try
        '                If tong >= CDbl(ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString) Then
        '                    DisplayMessage(True, "Hạn công nợ đã vượt quá.!")
        '                    Exit Sub
        '                End If
        '            Catch ex As Exception

        '            End Try

        '        End If
        '        '-----------------------------------

        '        If mStatusDebit = "Add" Or mStatusDebit = "Edit" Then
        '            Try
        '                copyHistory("Inboundfreight", "Inboundfreightid", mdebitID, "history")
        '            Catch ex As Exception

        '            End Try
        '            ' them container
        '            '=========='
        '            strQuery = "Select * From Inboundfreight Where Inboundfreightid='" & mdebitID & "'"
        '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '            With rs
        '                If rs.EOF Then
        '                    .AddNew()
        '                    .Fields("inboundfreightID").Value = NewId()
        '                    .Fields("inboundID").Value = getID(mInboundID)
        '                End If


        '                '-------------------------------container
        '                .Fields("customerid").Value = "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"
        '                .Fields("itemid").Value = "{" + FindValueID(Me.cboitemdebit, Me.cboitemdebit.Text) + "}"
        '                .Fields("currency").Value = Me.txtcurrdebit.Text
        '                .Fields("containertype").Value = Me.txtunitdebit.Text
        '                .Fields("unitprice").Value = Me.txtunitpricedebit.Text
        '                .Fields("quantity").Value = Me.txtquantitydebit.Text
        '                '.Fields("pricetruocthue").Value = Me.txtpricenotaxdebit.Text
        '                '.Fields("pricenotaxvnd").Value = Me.txtpricenotaxvnddebit.Text


        '                .Fields("taxprice").Value = Me.txttaxdebit.Text
        '                '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text
        '                .Fields("price").Value = Me.txtpricedebit.Text
        '                .Fields("note").Value = Me.txtremarksdebit.Text
        '                .Fields("os").Value = Me.chkosdebit.Checked
        '                .Fields("paycheck").Value = Me.chkpaydebit.Checked
        '                .Fields("showarrival").Value = Me.chkshowArrival.Checked
        '                .Fields("daily").Value = Me.chkagent.Checked

        '                .Fields("ngay").Value = Me.txtinvoicedebit.Text
        '                .Fields("ngayhoadon").Value = Me.txtinvoicenodebit.Text
        '                .Fields("tigia").Value = Me.txtexdebit.Text
        '                .Fields("debitcredit").Value = "Debit"
        '                .Fields("songaycongno").Value = Me.txthancongno.Text
        '                Try
        '                    .Fields("stt").Value = Me.txtstt.Text
        '                Catch ex As Exception

        '                End Try

        '                Try
        '                    .Fields("showvnd").Value = Me.chkShowVND.Checked
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    .Fields("no_").Value = Me.txtdebitno.Text
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    .Fields("unitprice_").Value = Me.txtunitpricedebit_.Text 'CDbl(Me.txtunitpricedebit.Text) / ((CDbl(Me.txttaxdebit.Text) / 100) + 1)
        '                Catch ex As Exception

        '                End Try
        '                Try
        '                    .Fields("price_").Value = Me.txtpricedebit_.Text 'CDbl(Me.txtpricedebit.Text) / ((CDbl(Me.txttaxdebit.Text) / 100) + 1)
        '                Catch ex As Exception

        '                End Try
        '                ' them dongiatruocthueVND chua nhan sl
        '                Try
        '                    If Me.txtcurrdebit.Text.Trim <> "VND" Then
        '                        .Fields("dongiatruocthueVND").Value = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) * CDbl(Me.txtexdebit.Text), 0)
        '                    Else
        '                        .Fields("dongiatruocthueVND").Value = FormatNumber(Me.txtunitpricedebit_.Text, 0)
        '                    End If

        '                Catch ex As Exception

        '                End Try

        '                Try
        '                    If Me.txtcurrdebit.Text.Trim <> "VND" Then
        '                        .Fields("thanhtientruocthueVND").Value = FormatNumber(CDbl(Me.txtpricedebit_.Text) * CDbl(Me.txtexdebit.Text), 0)
        '                    Else
        '                        .Fields("thanhtientruocthueVND").Value = FormatNumber(Me.txtpricedebit_.Text, 0)
        '                    End If

        '                Catch ex As Exception

        '                End Try

        '                Try
        '                    If Me.txtcurrdebit.Text.Trim <> "VND" Then
        '                        .Fields("tienthueVND").Value = FormatNumber((CDbl(Me.txtpricedebit.Text) - CDbl(Me.txtpricedebit_.Text)) * CDbl(Me.txtexdebit.Text), 0)
        '                    Else
        '                        .Fields("tienthueVND").Value = FormatNumber((CDbl(Me.txtpricedebit.Text) - CDbl(Me.txtpricedebit_.Text)), 0)
        '                    End If

        '                Catch ex As Exception

        '                End Try

        '                Try
        '                    If Me.txtcurrdebit.Text.Trim <> "VND" Then
        '                        .Fields("thanhtiensauthueVND").Value = FormatNumber((CDbl(Me.txtpricedebit.Text)) * CDbl(Me.txtexdebit.Text), 0)
        '                    Else
        '                        .Fields("thanhtiensauthueVND").Value = FormatNumber((CDbl(Me.txtpricedebit.Text)), 0)
        '                    End If

        '                Catch ex As Exception

        '                End Try
        '                .Update()
        '                If CDbl(rs.Fields("thanhtientruocthueVND").Value.ToString) + CDbl(rs.Fields("tienthueVND").Value.ToString) <> CDbl(rs.Fields("thanhtiensauthueVND").Value.ToString) Then
        '                    DisplayMessage(True, "Xin kiểm tra lại tiền thuế trong phần hóa đơn.!")
        '                End If
        '            End With
        '            rs.Close()

        '        End If
        '        mStatusDebit = "Normal"
        '        Me.cmdok_debit.Enabled = False
        '        Me.cmdcancel_debit_Click(sender, e)
        '        Me.Querydebit()
        '        checkTigia()
        '    Catch ex As Exception
        '        DisplayMessage(True, Err.Description)
        '    End Try
        '    profit()
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub checkTigia()
        Try
            'Dim i As Integer
            'Dim tich, sotim As Double
            'Dim tong As Double = 0
            'For i = 0 To Me.dgddebitGrid.RowCount - 1
            '    Try
            '        tong += CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value.ToString)
            '    Catch ex As Exception

            '    End Try
            'Next

            'For i = 0 To Me.dgddebitGrid.RowCount - 1
            '    Try
            '        sotim = tong / CDbl(Me.dgddebitGrid.RowCount - 1)
            '    Catch ex As Exception
            '    End Try
            '    If sotim = CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value.ToString) Then

            '    Else
            '        DisplayMessage(True, "Kiểm tra lại ti giá.!")
            '    End If
            'Next



        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancel_debit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel_debit.Click
        Try
            ' Me.cbocusdebit.Enabled = False

            Me.cboitemdebit.Enabled = False

            Me.txtcurrdebit.Enabled = False


            Me.txtunitdebit.Enabled = False


            Me.txtquantitydebit.Enabled = False


            Me.txtunitpricedebit.Enabled = False
            Me.txtpricenotaxdebit.Enabled = False
            Me.txtexdebit.Enabled = False
            Me.txttaxdebit.Enabled = False
            Me.txtpricetaxdebit.Enabled = False
            Me.txtpricedebit.Enabled = False
            Me.txtremarksdebit.Enabled = False
            Me.chkosdebit.Enabled = False
            Me.chkpaydebit.Enabled = False
            Me.txtinvoicedebit.Enabled = False
            '  Me.txtChargeA.Enabled = True
            Me.txtinvoicenodebit.Enabled = False
            mStatusDebit = "Normal"
            Me.cmdok_debit.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtquantitydebit_Leave(sender As Object, e As EventArgs) Handles txtquantitydebit.Leave
        Try
            txtquantitydebit_TextChanged_1(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtquantitydebit_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantitydebit.TextChanged
        Try
            Try
                'If Me.chkmanual.Checked = False Then
                '    Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit.Text) * CDbl(Me.txtquantitydebit.Text), 3)
                '    ' txtexdebit_TextChanged(sender, e)
                '    ' txttaxdebit_TextChanged(sender, e)
                'End If
                If Me.chkmanual.Checked = False Then

                    Me.txtpricedebit_.Text = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) * CDbl(Me.txtquantitydebit.Text), 3)



                    Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit.Text) * CDbl(Me.txtquantitydebit.Text), 3)
                    txttaxdebit_SelectedIndexChanged(sender, e)
                    ' txttaxdebit_TextChanged(sender, e)
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricedebit_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                If Me.chkmanual.Checked = False Then
                    Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit.Text) * CDbl(Me.txtquantitydebit.Text), 3)
                    'txtexdebit_TextChanged(sender, e)
                    ' txttaxdebit_TextChanged(sender, e)
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button47_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        Try
            ' cbocusdebit_SelectedIndexChanged(sender, e)
            Try
                Try

                    Dim i, j As Integer
                    Dim currow, lap As Integer
                    Dim sql As String
                    Me.GroupBox8.Visible = True
                    Dim ds As New DataSet
                    Me.dgdref.Rows.Clear()
                    'Agency-Import
                    'Agency-Export
                    'Domestic-Rail
                    'Domestic-Truck
                    'Domestic-Customs
                    'Oversea-Sea - Import
                    'Oversea-Sea - Export
                    'Oversea-Air - Import
                    'Oversea-Air - Export
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'  AND department='ACS-Air-Import' and '" & ddMMMyyyy(Me.dtpDateReport.Value.Date) & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE' order by charge_code "
                    ds = ReadDataSet(sql)

                    If ds.Tables(0).Rows.Count > 0 Then
                        ' them vao luoi

                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            lap = ds.Tables(0).Rows(i).Item("lanlap").ToString
                            For j = 1 To lap
                                Me.dgdref.Rows.Add(1)
                                currow = Me.dgdref.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.dgdref.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.dgdref.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.dgdref.Item("no", currow).Value = ds.Tables(0).Rows(i).Item("no").ToString
                                Me.dgdref.Item("charge", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                                Me.dgdref.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                                Me.dgdref.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString
                                Me.dgdref.Item("tu", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                Me.dgdref.Item("den", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                Me.dgdref.Item("value", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                Me.dgdref.Item("indate", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                Me.dgdref.Item("outdate", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString


                                Me.dgdref.Item("unit", currow).Value = ds.Tables(0).Rows(i).Item("unit").ToString
                                Me.dgdref.Item("cur", currow).Value = ds.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdref.Item("exchange", currow).Value = ds.Tables(0).Rows(i).Item("exchange").ToString

                            Next


                        Next

                    End If
                    ' show all
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where no='TEMPLETE' AND department='ACS-Air-Import' "
                    ds = ReadDataSet(sql)

                    If ds.Tables(0).Rows.Count > 0 Then
                        ' them vao luoi
                        'Me.GroupBox2.Visible = True
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            lap = ds.Tables(0).Rows(i).Item("lanlap").ToString
                            For j = 1 To lap
                                Me.dgdref.Rows.Add(1)
                                currow = Me.dgdref.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.dgdref.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.dgdref.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.dgdref.Item("no", currow).Value = ds.Tables(0).Rows(i).Item("no").ToString
                                Me.dgdref.Item("charge", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                                Me.dgdref.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                                Me.dgdref.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString
                                Me.dgdref.Item("tu", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                Me.dgdref.Item("den", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                Me.dgdref.Item("value", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                Me.dgdref.Item("indate", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                Me.dgdref.Item("outdate", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString


                                Me.dgdref.Item("unit", currow).Value = ds.Tables(0).Rows(i).Item("unit").ToString
                                Me.dgdref.Item("cur", currow).Value = ds.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdref.Item("exchange", currow).Value = ds.Tables(0).Rows(i).Item("exchange").ToString

                            Next


                        Next

                    End If
                    InsertAutoNumberToGrid(Me.dgdref)
                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button28_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Try


            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,taxcode + '-' + company as company From customer where continued=1 and company like '%" & Me.TextBox1.Text & "%' or taxcode like '%" & Me.TextBox1.Text & "%'  order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocusdebit, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)  
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button48_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        Try
            ' cbocuscredit_SelectedIndexChanged(sender, e)
            Try
                Try
                    Try

                        Dim i, j As Integer
                        Dim currow, lap As Integer
                        Dim sql As String
                        Me.GroupBox8_credit.Visible = True
                        Me.GroupBox8_credit.BringToFront()

                        Dim ds As New DataSet
                        Me.DataGridView5.Rows.Clear()
                        'Agency-Import
                        'Agency-Export
                        'Domestic-Rail
                        'Domestic-Truck
                        'Domestic-Customs
                        'Oversea-Sea - Import
                        'Oversea-Sea - Export
                        'Oversea-Air - Import
                        'Oversea-Air - Export
                        sql = "select * from banggialogisticshopdong_cost left join charge on banggialogisticshopdong_cost.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text) & "'  AND department='ACS-Air-Import' and '" & ddMMMyyyy(Me.dtpDateReport.Value.Date) & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE' order by charge_code "
                        ds = ReadDataSet(sql)

                        If ds.Tables(0).Rows.Count > 0 Then
                            ' them vao luoi

                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                lap = ds.Tables(0).Rows(i).Item("lanlap").ToString
                                For j = 1 To lap
                                    Me.DataGridView5.Rows.Add(1)
                                    currow = Me.DataGridView5.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView5.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView5.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView5.Item("no_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("no").ToString
                                    Me.DataGridView5.Item("charge_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString

                                    Me.DataGridView5.Item("pol_", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView5.Item("pod_", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                                    Me.DataGridView5.Item("tu_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                    Me.DataGridView5.Item("den_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                    Me.DataGridView5.Item("value_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                    Me.DataGridView5.Item("indate_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                    Me.DataGridView5.Item("outdate_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString


                                    Me.DataGridView5.Item("unit_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("unit").ToString
                                    Me.DataGridView5.Item("cur_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("currency").ToString
                                    Me.DataGridView5.Item("exchange_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("exchange").ToString

                                Next


                            Next

                        End If
                        ' show all
                        sql = "select * from banggialogisticshopdong_cost left join charge on banggialogisticshopdong_cost.itemid=charge.charge_id where no='TEMPLETE' AND department='ACS-Air-Import' "
                        ds = ReadDataSet(sql)

                        If ds.Tables(0).Rows.Count > 0 Then
                            ' them vao luoi
                            'Me.GroupBox2.Visible = True
                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                lap = ds.Tables(0).Rows(i).Item("lanlap").ToString
                                For j = 1 To lap
                                    Me.DataGridView5.Rows.Add(1)
                                    currow = Me.DataGridView5.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView5.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView5.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView5.Item("no_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("no").ToString
                                    Me.DataGridView5.Item("pol_", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView5.Item("pod_", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                                    Me.DataGridView5.Item("charge_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                                    Me.DataGridView5.Item("tu_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                    Me.DataGridView5.Item("den_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                    Me.DataGridView5.Item("value_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                    Me.DataGridView5.Item("indate_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                    Me.DataGridView5.Item("outdate_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString


                                    Me.DataGridView5.Item("unit_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("unit").ToString
                                    Me.DataGridView5.Item("cur_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("currency").ToString
                                    Me.DataGridView5.Item("exchange_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("exchange").ToString

                                Next


                            Next

                        End If
                        InsertAutoNumberToGrid(Me.DataGridView5)
                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try


            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,taxcode + '-' + company as company From customer where continued=1 and company like '%" & Me.TextBox2.Text & "%' or taxcode like '%" & Me.TextBox2.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocuscredit, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)  
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitcredit_Leave(sender As Object, e As EventArgs) Handles txtunitcredit.Leave
        Try
            'lay so cbm
            If UCase(Me.txtunitcredit.Text) Like "*CBM*" Then
                If CDbl(Me.dgdContainers.Item("sokhoi", 0).Value.ToString) < 1 Then
                    Me.txtquantitycredit.Text = 1
                Else
                    Me.txtquantitycredit.Text = Me.dgdContainers.Item("sokhoi", 0).Value.ToString
                End If
            End If

            'lay so cbm
            If UCase(Me.txtunitcredit.Text) Like "*KGS*" Then
                If CDbl(Me.dgdContainers.Item("chargeable", 0).Value.ToString) < 1 Then
                    Me.txtquantitycredit.Text = 1
                Else
                    Me.txtquantitycredit.Text = Me.dgdContainers.Item("chargeable", 0).Value.ToString
                End If
            End If
            If UCase(Me.txtunitcredit.Text) <> "KGS" And UCase(Me.txtunitcredit.Text) <> "CBM" Then

                Me.txtquantitycredit.Text = 1

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitcredit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitcredit.SelectedIndexChanged
        Try
            Try
                'lay so cbm
                If UCase(Me.txtunitcredit.Text) Like "*CBM*" Then
                    If CDbl(Me.dgdContainers.Item("sokhoi", 0).Value.ToString) < 1 Then
                        Me.txtquantitycredit.Text = 1
                    Else
                        Me.txtquantitycredit.Text = Me.dgdContainers.Item("sokhoi", 0).Value.ToString
                    End If
                End If

                'lay so cbm
                If UCase(Me.txtunitcredit.Text) Like "*KGS*" Then
                    If CDbl(Me.dgdContainers.Item("chargeable", 0).Value.ToString) < 1 Then
                        Me.txtquantitycredit.Text = 1
                    Else
                        Me.txtquantitycredit.Text = Me.dgdContainers.Item("chargeable", 0).Value.ToString
                    End If
                End If
                If UCase(Me.txtunitcredit.Text) <> "KGS" And UCase(Me.txtunitcredit.Text) <> "CBM" Then

                    Me.txtquantitycredit.Text = 1

                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitdebit_Leave(sender As Object, e As EventArgs) Handles txtunitdebit.Leave
        Try
            'lay so cbm
            If UCase(Me.txtunitdebit.Text) Like "*CBM*" Then
                If CDbl(Me.dgdContainers.Item("sokhoi", 0).Value.ToString) < 1 Then
                    Me.txtquantitydebit.Text = 1
                Else
                    Me.txtquantitydebit.Text = Me.dgdContainers.Item("sokhoi", 0).Value.ToString
                End If
            End If

            'lay so cbm
            If UCase(Me.txtunitdebit.Text) Like "*KGS*" Then
                If CDbl(Me.dgdContainers.Item("chargeable", 0).Value.ToString) < 1 Then
                    Me.txtquantitydebit.Text = 1
                Else
                    Me.txtquantitydebit.Text = Me.dgdContainers.Item("chargeable", 0).Value.ToString
                End If
            End If
            If UCase(Me.txtunitdebit.Text) <> "KGS" And UCase(Me.txtunitdebit.Text) <> "CBM" Then

                Me.txtquantitydebit.Text = 1

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitdebit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitdebit.SelectedIndexChanged
        Try
            'lay so cbm
            If UCase(Me.txtunitdebit.Text) Like "*CBM*" Then
                If CDbl(Me.dgdContainers.Item("sokhoi", 0).Value.ToString) < 1 Then
                    Me.txtquantitydebit.Text = 1
                Else
                    Me.txtquantitydebit.Text = Me.dgdContainers.Item("sokhoi", 0).Value.ToString
                End If
            End If

            'lay so cbm
            If UCase(Me.txtunitdebit.Text) Like "*KGS*" Then
                If CDbl(Me.dgdContainers.Item("chargeable", 0).Value.ToString) < 1 Then
                    Me.txtquantitydebit.Text = 1
                Else
                    Me.txtquantitydebit.Text = Me.dgdContainers.Item("chargeable", 0).Value.ToString
                End If
            End If
            If UCase(Me.txtunitdebit.Text) <> "KGS" And UCase(Me.txtunitdebit.Text) <> "CBM" Then

                Me.txtquantitydebit.Text = 1
            
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdok_credit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok_credit.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            If CDbl(Me.txtexcredit.Text) <= 1 Then
                DisplayMessage(True, "Xin nhập tỉ giá hiện tại.")
                Me.txtexcredit.Focus()
                Exit Sub
            End If
            If Me.txtexcredit.Text = "1" Or Me.txtexcredit.Text = "" Then
                DisplayMessage(True, "Xin nhập tỉ giá.")
                Me.txtexcredit.Focus()
                Exit Sub
            End If

            If mStatusCredit = "Add" Or mStatusCredit = "Edit" Then
                Try
                    copyHistory("Inboundfreight", "Inboundfreightid", mCreditID, "history")
                Catch ex As Exception

                End Try
                ' them container
                '=========='
                strQuery = "Select * From inboundfreight Where inboundfreightid='" & mCreditID & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("inboundfreightID").Value = NewId()
                        .Fields("inboundID").Value = getID(mInboundID)
                    End If


                    '-------------------------------container
                    .Fields("customerid").Value = "{" + FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text) + "}"
                    .Fields("itemid").Value = "{" + FindValueID(Me.cboitemcredit, Me.cboitemcredit.Text) + "}"
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

                    Try
                        .Fields("dntt").Value = Me.chkdntt.Checked
                    Catch ex As Exception

                    End Try
                    .Fields("paycheck").Value = Me.chkpaycredit.Checked
                    .Fields("daily").Value = Me.chkagent_credit.Checked
                    .Fields("ngay").Value = Me.txtinvoicecredit.Text
                    .Fields("ngayhoadon").Value = Me.txtinvoicenocredit.Text
                    .Fields("tigia").Value = Me.txtexcredit.Text
                    .Fields("debitcredit").Value = "Credit"

                    .Fields("showvnd").Value = Me.chkShowVND_Credit.Checked
                    .Fields("no_").Value = Me.txtcreditNo.Text
                    .Update()
                End With
                rs.Close()

            End If
            mStatusCredit = "Normal"
            Me.cmdok_credit.Enabled = False
            Me.cmdcancel_credit_Click(sender, e)
            Me.QueryCredit()
            profit()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdcancel_credit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel_credit.Click
        Try
            Me.cbocuscredit.Enabled = False

            Me.cboitemcredit.Enabled = False

            Me.txtcurrcredit.Enabled = False


            Me.txtunitcredit.Enabled = False


            Me.txtquantitycredit.Enabled = False


            Me.txtunitpricecredit.Enabled = False
            Me.txtpricenotaxcredit.Enabled = False
            Me.txtexcredit.Enabled = False
            Me.txttaxcredit.Enabled = False
            Me.txtpricetaxcredit.Enabled = False
            Me.txtpricecredit.Enabled = False
            Me.txtremarkscredit.Enabled = False
            Me.chkoscredit.Enabled = False
            Me.chkpaycredit.Enabled = False
            Me.txtinvoicecredit.Enabled = False
            '  Me.txtChargeA.Enabled = True
            Me.txtinvoicenocredit.Enabled = False
            mStatusCredit = "Normal"
            Me.cmdok_credit.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button30_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Try
            QueryCredit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button26_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Try
            Shell("C:\WINDOWS\system32\calc.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtquantitycredit_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantitycredit.TextChanged
        Try
            Try
                If Me.chkManualCredit.Checked = False Then
                    Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 3)
                    ' txtexcredit_TextChanged(sender, e)
                    ' txttaxcredit_TextChanged(sender, e)
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage13.Click

    End Sub

    Private Sub Button51_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Try

            If Me.DataGridView5.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If


            Dim index As Integer = Me.DataGridView5.CurrentRow.Index
            Try
                Me.cboitemcredit.Text = Me.DataGridView5.Item("charge_CREDIT", index).Value.ToString
                Me.txtexcredit.Text = Me.DataGridView5.Item("exchange_CREDIT", index).Value.ToString
                Me.txtunitpricecredit.Text = Me.DataGridView5.Item("value_CREDIT", index).Value.ToString
                Me.txtunitpricecredit.Text = Me.DataGridView5.Item("value_CREDIT", index).Value.ToString
                Me.txtcurrcredit.Text = Me.DataGridView5.Item("cur_CREDIT", index).Value.ToString
                Me.txtunitcredit.Text = Me.DataGridView5.Item("unit_CREDIT", index).Value.ToString
            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button45_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        Try

            If Me.dgdref.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If


            Dim index As Integer = Me.dgdref.CurrentRow.Index
            Try
                Me.cboitemdebit.Text = Me.dgdref.Item("charge", index).Value.ToString
                Me.txtexdebit.Text = Me.dgdref.Item("exchange", index).Value.ToString
                Me.txtunitpricedebit.Text = Me.dgdref.Item("value", index).Value.ToString
                Me.txtunitpricedebit.Text = Me.dgdref.Item("value", index).Value.ToString
                Me.txtcurrdebit.Text = Me.dgdref.Item("cur", index).Value.ToString
                Me.txtunitdebit.Text = Me.dgdref.Item("unit", index).Value.ToString
            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button46_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        Try
            Me.GroupBox8.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocusdebit_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocusdebit.SelectedIndexChanged
        Try
            '  cbocusdebit_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocuscredit_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocuscredit.SelectedIndexChanged
        Try
            cbocuscredit_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricecredit_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitpricecredit.TextChanged
        Try
            Try
                If Me.chkManualCredit.Checked = False Then
                    Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 3)
                    '  txtexcredit_TextChanged(sender, e)
                    ' txttaxcredit_TextChanged(sender, e)
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button92_Click(sender As Object, e As EventArgs) Handles Button92.Click
        Try
            If LoginSucceeded = True Then
                gSQLShowDetails = "select * from quotationtico left join quotationticodetails on quotationtico.QuotationTicoID=quotationticodetails.QuotationTicoID where no='" & Me.txtquotation.Text & "' "
                Dim form As New frmShowDetails 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage10_Click(sender As Object, e As EventArgs) Handles TabPage10.Click

    End Sub

    Private Sub txtvolumnDebit_TextChanged(sender As Object, e As EventArgs) Handles txtvolumnDebit.TextChanged

    End Sub

    Private Sub Button19_Click_1(sender As Object, e As EventArgs) Handles Button19.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If UCase(gDepartment) = "SALE" Then
                sql = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate  from inbound_OverseaAirImport where (hbl='" & Me.txtHBL.Text & "') and (salecode='" & gSaleCode & "') and (branch like '%" & gBranch & "%') order by dateupdate  "

            Else
                sql = " select blib_id,stuff(ref,1,7,'') as [order],air,fcl,lcl,status,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,nhanlenh,closeFile,REF,MBL,HBL,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate  from inbound_OverseaAirImport where (hbl='" & Me.txtHBL.Text & "') and (branch like '%" & gBranch & "%')  order by dateupdate  "

            End If
            ds = ReadDataSet(sql)
            Me.dgdHBL.DataSource = ds.Tables(0)
            ' mFilter = " and ref = '" & Me.cboMBL.Text & "' "
            InsertAutoNumberToGrid(Me.dgdHBL)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttaxdebit_Leave(sender As Object, e As EventArgs) Handles txttaxdebit.Leave
        txttaxdebit_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub txttaxdebit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txttaxdebit.SelectedIndexChanged
        Try
            If Me.chkmanual.Checked = False Then

                'Me.txtpricedebit_.Text = FormatNumber(CDbl(Me.txtpricedebit_.Text) * (CDbl(Me.txttaxdebit.Text) / 100) + 1, 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)
                Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtpricedebit_.Text) * ((CDbl(Me.txttaxdebit.Text) / 100) + 1), 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)
                Me.txtunitpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) * ((CDbl(Me.txttaxdebit.Text) / 100) + 1), 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)



            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtunitpricedebit__TextChanged(sender As Object, e As EventArgs) Handles txtunitpricedebit_.TextChanged
        Try
            txtquantitydebit_TextChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricedebit__TextChanged(sender As Object, e As EventArgs) Handles txtpricedebit_.TextChanged

    End Sub

    Private Sub Button94_Click(sender As Object, e As EventArgs) Handles Button94.Click
        Try
            Me.GroupQuotation.Visible = True
            Me.GroupQuotation.BringToFront()
            Dim id, value, strSQL As String
            id = "QuotationTicoID"
            value = "no"

            Me.txtnoQuotation.Items.Clear()
            Me.txtnoQuotation.Text = ""
            strSQL = "Select  QuotationTicoID,no From QuotationTico  where continued =1 and approve=1 and  userupdate='" & Me.cboSale.Text & "' and cusID='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'  "
            loadDataToObject(Me.txtnoQuotation, strSQL, id, value)
            Me.txtnoQuotation.Text = Me.txtquotation.Text

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button95_Click(sender As Object, e As EventArgs) Handles Button95.Click
        Try
            Try
                ' Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Dim strSQL As String
                Dim ds As New DataSet

                strSQL = "select quotationTicoDetails.*,quotationTicoDetailsID,QuotationTico.quotationticoid,cusid,items,itemsid,price,cur,quantity,unitprice,type,textshow,vat,priceincvat,remarks_phi "
                strSQL &= " From QuotationTico left join quotationTicoDetails on QuotationTico.QuotationTicoID=quotationTicoDetails.QuotationTicoID "
                strSQL &= " Where (no ='" & Me.txtnoQuotation.Text & "' )  and continued=1 and approve =1 order by stt "
                'Conn.Open()
                'Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
                'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
                'If Not IsNothing(oTablePIC) Then
                '    oTablePIC.Clear()
                'End If
                'Adapter.Fill(oTablePIC)
                'Me.dgdPIC.DataSource = oTablePIC
                ' nap vao luoi
                ds = ReadDataSet(strSQL)
                Dim i, currow As Integer
                Me.dgdPIC.Rows.Clear()
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdPIC.Rows.Add(1)
                        currow = dgdPIC.RowCount - 1
                        Me.dgdPIC.Item("check", currow).Value = False
                        Me.dgdPIC.Item("stt", currow).Value = ds.Tables(0).Rows(i).Item("stt").ToString
                        Me.dgdPIC.Item("QuotationTicoDetailsID", currow).Value = ds.Tables(0).Rows(i).Item("QuotationTicoDetailsID").ToString
                        Me.dgdPIC.Item("QuotationTicoID_", currow).Value = ds.Tables(0).Rows(i).Item("quotationticoid").ToString
                        Me.dgdPIC.Item("cusid_Q", currow).Value = ds.Tables(0).Rows(i).Item("cusid").ToString
                        Me.dgdPIC.Item("items_q", currow).Value = ds.Tables(0).Rows(i).Item("items").ToString
                        Me.dgdPIC.Item("itemsid_q", currow).Value = ds.Tables(0).Rows(i).Item("itemsid").ToString
                        Me.dgdPIC.Item("price_q", currow).Value = ds.Tables(0).Rows(i).Item("price").ToString
                        Me.dgdPIC.Item("unitprice_q", currow).Value = ds.Tables(0).Rows(i).Item("unitprice").ToString
                        Me.dgdPIC.Item("currency_q", currow).Value = ds.Tables(0).Rows(i).Item("cur").ToString

                        Me.dgdPIC.Item("quantity_q", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString


                        Me.dgdPIC.Item("type_q", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                        Me.dgdPIC.Item("textshow", currow).Value = ds.Tables(0).Rows(i).Item("textshow").ToString
                        Me.dgdPIC.Item("vat_q", currow).Value = ds.Tables(0).Rows(i).Item("vat").ToString
                        Me.dgdPIC.Item("priceincvat_q", currow).Value = ds.Tables(0).Rows(i).Item("priceincvat").ToString
                        Me.dgdPIC.Item("remarks_phi_q", currow).Value = ds.Tables(0).Rows(i).Item("remarks_phi").ToString

                        ' dat gia tri vao luoi cua Air
                        Me.dgdPIC.Item("air_min", currow).Value = ds.Tables(0).Rows(i).Item("air_min").ToString
                        Me.dgdPIC.Item("air_normal", currow).Value = ds.Tables(0).Rows(i).Item("air_normal").ToString
                        Me.dgdPIC.Item("air_45", currow).Value = ds.Tables(0).Rows(i).Item("air_45").ToString
                        Me.dgdPIC.Item("air_100", currow).Value = ds.Tables(0).Rows(i).Item("air_100").ToString
                        Me.dgdPIC.Item("air_300", currow).Value = ds.Tables(0).Rows(i).Item("air_300").ToString
                        Me.dgdPIC.Item("air_500", currow).Value = ds.Tables(0).Rows(i).Item("air_500").ToString
                        Me.dgdPIC.Item("air_1000", currow).Value = ds.Tables(0).Rows(i).Item("air_1000").ToString

                        Me.dgdPIC.Item("air_awb", currow).Value = ds.Tables(0).Rows(i).Item("air_awb").ToString
                        Me.dgdPIC.Item("air_xray", currow).Value = ds.Tables(0).Rows(i).Item("air_xray").ToString
                        Me.dgdPIC.Item("air_ams", currow).Value = ds.Tables(0).Rows(i).Item("air_ams").ToString

                        Me.dgdPIC.Item("air_fsc", currow).Value = ds.Tables(0).Rows(i).Item("air_fsc").ToString
                        Me.dgdPIC.Item("air_ssc", currow).Value = ds.Tables(0).Rows(i).Item("air_ssc").ToString
                        Me.dgdPIC.Item("sea_air", currow).Value = ds.Tables(0).Rows(i).Item("sea_air").ToString



                        currow += 1
                    Next
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button93_Click(sender As Object, e As EventArgs) Handles Button93.Click
        Try
            Dim i As Integer
            For i = 0 To Me.dgddebitGrid1.RowCount - 1
                If Me.dgddebitGrid1.Item("checkSP", i).Value = True Then
                    Try
                        Try
                            Dim strQuery As String
                            Dim rs As New ADODB.Recordset
                            '
                            'If CDbl(Me.txtexdebit.Text) <= 1 Then
                            '    DisplayMessage(True, "Xin nhập tỉ giá hiện tại.")
                            '    Me.txtexdebit.Focus()
                            '    Exit Sub
                            'End If
                            'If Me.txtexdebit.Text = "1" Or Me.txtexdebit.Text = "" Then
                            '    DisplayMessage(True, "Xin nhập tỉ giá.")
                            '    Me.txtexdebit.Focus()
                            '    Exit Sub
                            'End If
                            ' kiem tra han cong no tien
                            Dim sql As String
                            Dim ds As New DataSet
                            Dim tong As Double = 0
                            tong = tienCongno(Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString, "A")

                            sql = "select * from customer where customer_id = '" & Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString & "'"
                            ds = ReadDataSet(sql)
                            If ds.Tables(0).Rows.Count > 0 Then

                                Try
                                    If tong >= CDbl(ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString) Then
                                        DisplayMessage(True, "Hạn công nợ đã vượt quá.!")
                                        Exit Sub
                                    End If
                                Catch ex As Exception

                                End Try

                            End If
                            '-----------------------------------


                            ' them container
                            '=========='
                            strQuery = "Select * From Inboundfreight " 'Where Inboundfreightid='" & mdebitID & "'
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                'If rs.EOF Then
                                .AddNew()
                                .Fields("InboundfreightID").Value = NewId()
                                .Fields("InboundID").Value = getID(mInboundID)
                                'End If


                                '-------------------------------container
                                'If Me.dgddebitGrid1.Item("customerid_debit1", i).Value Like "*{*" Then
                                ' .Fields("customerid").Value = Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString  ' "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"

                                'Else
                                .Fields("customerid").Value = "{" + Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString + "}" ' "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"

                                'End If
                                'If Me.dgddebitGrid1.Item("itemsid_q", i).Value Like "*{*" Then
                                '  .Fields("itemid").Value = Me.dgddebitGrid1.Item("itemsid_q", i).Value.ToString
                                'Else

                                .Fields("itemid").Value = "{" + Me.dgddebitGrid1.Item("itemid_debit1", i).Value.ToString + "}"
                                'End If

                                ' lay vat tu unit cua cgarge
                                Dim vat As Double
                                'Dim sqlvat As String
                                'Dim dsvat As New DataSet
                                'sqlvat = "select * from charge where charge_id='" & Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString & "' "
                                'dsvat = ReadDataSet(sqlvat)
                                'If dsvat.Tables(0).Rows.Count > 0 Then
                                '    Try
                                '        vat = CDbl(dsvat.Tables(0).Rows(0).Item("unit").ToString)
                                '    Catch ex As Exception
                                '        vat = 0
                                '    End Try
                                'End If
                                '-------
                                .Fields("currency").Value = Me.dgddebitGrid1.Item("currency_debit1", i).Value

                                .Fields("taxprice").Value = Me.dgddebitGrid1.Item("taxprice_debit1", i).Value.ToString
                                vat = CDbl(Me.dgddebitGrid1.Item("taxprice_debit1", i).Value.ToString)
                                .Fields("containertype").Value = Me.dgddebitGrid1.Item("containertype_debit1", i).Value ' Me.txtunitdebit.Text

                                .Fields("unitprice").Value = CDbl(Me.dgddebitGrid1.Item("unitprice_debit1", i).Value) * ((vat / 100) + 1)
                                '  .Fields("unitprice").Value = Me.dgddebitGrid1.Item("unitprice_debit1", i).Value ' Me.txtunitpricedebit.Text
                                .Fields("quantity").Value = Me.dgddebitGrid1.Item("quantity_debit1", i).Value 'Me.txtquantitydebit.Text
                                .Fields("debitcredit").Value = Me.dgddebitGrid1.Item("debitcredit", i).Value


                                '  .Fields("container").Value = Me.cboContainer.Text


                                ' Me.txttaxdebit.Text
                                '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text


                                .Fields("note").Value = Me.dgddebitGrid1.Item("note_debit1", i).Value 'Me.txtremarksdebit.Text

                                .Fields("os").Value = False
                                .Fields("paycheck").Value = False
                                ' .Fields("showarrival").Value = True
                                .Fields("daily").Value = False

                                .Fields("ngay").Value = ""
                                .Fields("ngayhoadon").Value = ""
                                .Fields("tigia").Value = Me.dgddebitGrid1.Item("tigia_debit1", i).Value.ToString  ' getCur("USD") 'Me.txtexdebit.Text
                                '  .Fields("debitcredit").Value = "Debit"
                                .Fields("songaycongno").Value = ""
                                Try
                                    .Fields("stt").Value = (i + 1).ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("showvnd").Value = False
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("freedem").Value = "0"
                                Catch ex As Exception
                                    .Fields("freedem").Value = "0"
                                End Try
                                Try
                                    .Fields("freedet").Value = "0"
                                Catch ex As Exception
                                    .Fields("freedet").Value = "0"
                                End Try
                                Try
                                    .Fields("no_").Value = ""
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("f1").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("f2").Value = "0"
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("t1").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("t2").Value = "0"
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("p1").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("p2").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("level").Value = "0"
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("unitprice_").Value = CDbl(Me.dgddebitGrid1.Item("unitprice_debit1", i).Value) 'CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit1", i).Value) / CDbl(Me.dgddebitGrid1.Item("quantity_debit1", i).Value)
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("price_").Value = Me.dgddebitGrid1.Item("pricetruocthue_debit1", i).Value
                                Catch ex As Exception

                                End Try

                                'If Me.dgddebitGrid1.Item("currency_debit1", i).Value.ToString = "VND" Then
                                .Fields("price").Value = CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit1", i).Value) * ((vat / 100) + 1) '* ((vat / 100) + 1)Me.dgdPIC.Item("priceincvat_q", i).Value ' Me.txtpricedebit.Text

                                'Else
                                '.Fields("price").Value = CDbl(Me.dgddebitGrid1.Item("price_debit1", i).Value) / CDbl(Me.dgddebitGrid1.Item("tigia_debit1", i).Value) ' tigia_debit1 ' Me.dgdPIC.Item("priceincvat_q", i).Value ' Me.txtpricedebit.Text

                                'End If
                                .Update()
                            End With
                            rs.Close()


                            mStatusDebit = "Normal"
                            Me.cmdok_debit.Enabled = False
                            Me.cmdcancel_debit_Click(sender, e)
                            Me.Querydebit()
                            Me.QueryCredit()
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                        profit()
                        'profit_theonguyente()
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception

        End Try
        'Try
        '    Dim i As Integer
        '    For i = 0 To Me.dgdPIC.RowCount - 1
        '        If Me.dgdPIC.Item("check", i).Value = True Then
        '            Try
        '                Try
        '                    Dim strQuery As String
        '                    Dim rs As New ADODB.Recordset
        '                    '
        '                    'If CDbl(Me.txtexdebit.Text) <= 1 Then
        '                    '    DisplayMessage(True, "Xin nhập tỉ giá hiện tại.")
        '                    '    Me.txtexdebit.Focus()
        '                    '    Exit Sub
        '                    'End If
        '                    'If Me.txtexdebit.Text = "1" Or Me.txtexdebit.Text = "" Then
        '                    '    DisplayMessage(True, "Xin nhập tỉ giá.")
        '                    '    Me.txtexdebit.Focus()
        '                    '    Exit Sub
        '                    'End If
        '                    ' kiem tra han cong no tien
        '                    Dim sql As String
        '                    Dim ds As New DataSet
        '                    Dim tong As Double = 0
        '                    tong = tienCongno(Me.dgdPIC.Item("cusid_Q", i).Value, "A")

        '                    sql = "select * from customer where customer_id = '" & Me.dgdPIC.Item("cusid_Q", i).Value & "'"
        '                    ds = ReadDataSet(sql)
        '                    If ds.Tables(0).Rows.Count > 0 Then

        '                        Try
        '                            If tong >= CDbl(ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString) Then
        '                                DisplayMessage(True, "Hạn công nợ đã vượt quá.!")
        '                                Exit Sub
        '                            End If
        '                        Catch ex As Exception

        '                        End Try

        '                    End If
        '                    '-----------------------------------


        '                    ' them container
        '                    '=========='
        '                    strQuery = "Select * From Inboundfreight " 'Where Inboundfreightid='" & mdebitID & "'
        '                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '                    With rs
        '                        'If rs.EOF Then
        '                        .AddNew()
        '                        .Fields("inboundfreightID").Value = NewId()
        '                        .Fields("inboundID").Value = getID(mInboundID)
        '                        'End If


        '                        '-------------------------------container
        '                        .Fields("customerid").Value = "{" + Me.dgdPIC.Item("cusid_Q", i).Value + "}" ' "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"
        '                        .Fields("itemid").Value = "{" + Me.dgdPIC.Item("itemsid_q", i).Value + "}"
        '                        ' lay vat tu unit cua cgarge
        '                        Dim vat As Double
        '                        Dim sqlvat As String
        '                        Dim dsvat As New DataSet
        '                        sqlvat = "select * from charge where charge_id='" & Me.dgdPIC.Item("itemsid_q", i).Value & "' "
        '                        dsvat = ReadDataSet(sqlvat)
        '                        If dsvat.Tables(0).Rows.Count > 0 Then
        '                            Try
        '                                vat = CDbl(dsvat.Tables(0).Rows(0).Item("unit").ToString)
        '                            Catch ex As Exception
        '                                vat = 0
        '                            End Try
        '                        End If
        '                        '-------
        '                        .Fields("currency").Value = Me.dgdPIC.Item("currency_q", i).Value


        '                        .Fields("containertype").Value = Me.dgdPIC.Item("type_q", i).Value ' Me.txtunitdebit.Text


        '                        .Fields("unitprice").Value = Me.dgdPIC.Item("unitprice_q", i).Value ' Me.txtunitpricedebit.Text
        '                        .Fields("quantity").Value = Me.dgdPIC.Item("quantity_q", i).Value 'Me.txtquantitydebit.Text



        '                        '  .Fields("container").Value = Me.cboContainer.Text

        '                        .Fields("taxprice").Value = vat ' Me.dgdPIC.Item("vat_q", i).Value ' Me.txttaxdebit.Text
        '                        '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text

        '                        .Fields("price").Value = Me.dgdPIC.Item("priceincvat_q", i).Value * ((vat / 100) + 1) 'Me.dgdPIC.Item("priceincvat_q", i).Value ' Me.txtpricedebit.Text

        '                        .Fields("note").Value = Me.dgdPIC.Item("remarks_phi_q", i).Value 'Me.txtremarksdebit.Text

        '                        .Fields("os").Value = False
        '                        .Fields("paycheck").Value = False
        '                        .Fields("showarrival").Value = True
        '                        .Fields("daily").Value = False

        '                        .Fields("ngay").Value = ""
        '                        .Fields("ngayhoadon").Value = ""
        '                        .Fields("tigia").Value = getCur("USD") 'Me.txtexdebit.Text
        '                        .Fields("debitcredit").Value = "Debit"
        '                        .Fields("songaycongno").Value = ""
        '                        Try
        '                            .Fields("stt").Value = (i + 1).ToString
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            .Fields("showvnd").Value = False
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            .Fields("freedem").Value = "0"
        '                        Catch ex As Exception
        '                            .Fields("freedem").Value = "0"
        '                        End Try
        '                        Try
        '                            .Fields("freedet").Value = "0"
        '                        Catch ex As Exception
        '                            .Fields("freedet").Value = "0"
        '                        End Try
        '                        Try
        '                            .Fields("no_").Value = Me.txtdebitno.Text
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            .Fields("f1").Value = "0"
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            .Fields("f2").Value = "0"
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            .Fields("t1").Value = "0"
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            .Fields("t2").Value = "0"
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            .Fields("p1").Value = "0"
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            .Fields("p2").Value = "0"
        '                        Catch ex As Exception

        '                        End Try

        '                        Try
        '                            .Fields("level").Value = "0"
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            .Fields("unitprice_").Value = Me.dgdPIC.Item("unitprice_q", i).Value
        '                        Catch ex As Exception

        '                        End Try
        '                        Try
        '                            .Fields("price_").Value = Me.dgdPIC.Item("priceincvat_q", i).Value
        '                        Catch ex As Exception

        '                        End Try


        '                        .Update()
        '                    End With
        '                    rs.Close()


        '                    mStatusDebit = "Normal"
        '                    Me.cmdok_debit.Enabled = False
        '                    Me.cmdcancel_debit_Click(sender, e)
        '                    Me.Querydebit()
        '                Catch ex As Exception
        '                    DisplayMessage(True, Err.Description)
        '                End Try
        '                profit()
        '                ' profit_theonguyente()
        '            Catch ex As Exception

        '            End Try
        '        End If
        '    Next
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub GroupQuotation_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupQuotation.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupQuotation_MouseMove(sender As Object, e As MouseEventArgs) Handles GroupQuotation.MouseMove
        If Mdown Then
            Me.GroupQuotation.Left = (e.X - X) + Me.GroupQuotation.Left
            Me.GroupQuotation.Top = (e.Y - Y) + Me.GroupQuotation.Top
        End If
    End Sub

    Private Sub GroupQuotation_MouseUp(sender As Object, e As MouseEventArgs) Handles GroupQuotation.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupQuotation.Left = (e.X - X) + Me.GroupQuotation.Left
            Me.GroupQuotation.Top = (e.Y - Y) + Me.GroupQuotation.Top
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Try
            Me.GroupQuotation.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button98_Click(sender As Object, e As EventArgs) Handles Button98.Click
        Try
            Me.GroupBox22.Visible = True
            Me.GroupBox22.BringToFront()
            Dim id, value, strSQL As String
            id = "QuotationID"
            value = "quotationNo"

            Me.cboBKNo_Shipment_pro.Items.Clear()
            Me.cboBKNo_Shipment_pro.Text = ""
            strSQL = "Select  QuotationID,quotationNo + '/'+ Quotation_sale.salename +'/'+ company as quotationNo From Quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id  where Quotation_sale.continued =1 and Quotation_sale.approve=1   and dept='Inbound' and quotation_sale.customer_id ='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "' and closed_sp=0 order by Quotation_sale.dateupdate  " ' "
            loadDataToObject(Me.cboBKNo_Shipment_pro, strSQL, id, value)
            ' Me.txtnoQuotation.Text = Me.txtquotation.Text

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button101_Click(sender As Object, e As EventArgs) Handles Button101.Click
        Try
            Dim dsdebit1 As New DataSet
            Dim dscredit1 As New DataSet
            Dim sql As String = "Select inboundid,inboundfreightid,customerid,itemid,debitcredit,taxcode + '-' + company as company,charge_code as item,currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, tigia,vitri "
            sql &= " From inboundfreight_sale left join customer on inboundfreight_sale.customerid=customer.customer_id  left join charge on inboundfreight_sale.itemid=charge.charge_id "
            sql &= "Where " & _
                   " quotationid='" & FindValueID(Me.cboBKNo_Shipment_pro, Me.cboBKNo_Shipment_pro.Text) & "'   order by charge_code " 'and debitcredit='Debit'
            dsdebit1 = ReadDataSet(sql)
            Me.dgddebitGrid1.DataSource = dsdebit1.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GroupBox22_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBox22.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox22_MouseMove(sender As Object, e As MouseEventArgs) Handles GroupBox22.MouseMove
        If Mdown Then
            Me.GroupBox6.Left = (e.X - X) + Me.GroupBox6.Left
            Me.GroupBox6.Top = (e.Y - Y) + Me.GroupBox6.Top
        End If
    End Sub

    Private Sub GroupBox22_MouseUp(sender As Object, e As MouseEventArgs) Handles GroupBox22.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox22.Left = (e.X - X) + Me.GroupBox22.Left
            Me.GroupBox22.Top = (e.Y - Y) + Me.GroupBox22.Top
        End If
    End Sub
    Private Sub Button99_Click(sender As Object, e As EventArgs) Handles Button99.Click
        Try
            Me.GroupBox22.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        Try
            Dim i As Integer
            For i = 0 To Me.dgddebitGrid1.RowCount - 1
                If Me.dgddebitGrid1.Item("checkSP", i).Value = True Then
                    Try
                        Try
                            Dim strQuery As String
                            Dim rs As New ADODB.Recordset
                            '
                            'If CDbl(Me.txtexdebit.Text) <= 1 Then
                            '    DisplayMessage(True, "Xin nhập tỉ giá hiện tại.")
                            '    Me.txtexdebit.Focus()
                            '    Exit Sub
                            'End If
                            'If Me.txtexdebit.Text = "1" Or Me.txtexdebit.Text = "" Then
                            '    DisplayMessage(True, "Xin nhập tỉ giá.")
                            '    Me.txtexdebit.Focus()
                            '    Exit Sub
                            'End If
                            ' kiem tra han cong no tien
                            Dim sql As String
                            Dim ds As New DataSet
                            Dim tong As Double = 0
                            tong = tienCongno(Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString, "A")

                            sql = "select * from customer where customer_id = '" & Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString & "'"
                            ds = ReadDataSet(sql)
                            If ds.Tables(0).Rows.Count > 0 Then

                                Try
                                    If tong >= CDbl(ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString) Then
                                        DisplayMessage(True, "Hạn công nợ đã vượt quá.!")
                                        Exit Sub
                                    End If
                                Catch ex As Exception

                                End Try

                            End If
                            '-----------------------------------


                            ' them container
                            '=========='
                            strQuery = "Select * From Inboundfreight " 'Where Inboundfreightid='" & mdebitID & "'
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                'If rs.EOF Then
                                .AddNew()
                                .Fields("InboundfreightID").Value = NewId()
                                .Fields("InboundID").Value = getID(mInboundID)
                                'End If


                                '-------------------------------container
                                'If Me.dgddebitGrid1.Item("customerid_debit1", i).Value Like "*{*" Then
                                ' .Fields("customerid").Value = Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString  ' "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"

                                'Else
                                .Fields("customerid").Value = "{" + Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString + "}" ' "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"

                                'End If
                                'If Me.dgddebitGrid1.Item("itemsid_q", i).Value Like "*{*" Then
                                '  .Fields("itemid").Value = Me.dgddebitGrid1.Item("itemsid_q", i).Value.ToString
                                'Else

                                .Fields("itemid").Value = "{" + Me.dgddebitGrid1.Item("itemid_debit1", i).Value.ToString + "}"
                                'End If

                                ' lay vat tu unit cua cgarge
                                Dim vat As Double
                                'Dim sqlvat As String
                                'Dim dsvat As New DataSet
                                'sqlvat = "select * from charge where charge_id='" & Me.dgddebitGrid1.Item("customerid_debit1", i).Value.ToString & "' "
                                'dsvat = ReadDataSet(sqlvat)
                                'If dsvat.Tables(0).Rows.Count > 0 Then
                                '    Try
                                '        vat = CDbl(dsvat.Tables(0).Rows(0).Item("unit").ToString)
                                '    Catch ex As Exception
                                '        vat = 0
                                '    End Try
                                'End If
                                ''-------
                                .Fields("currency").Value = Me.dgddebitGrid1.Item("currency_debit1", i).Value
                                .Fields("taxprice").Value = Me.dgddebitGrid1.Item("taxprice_debit1", i).Value.ToString
                                vat = CDbl(Me.dgddebitGrid1.Item("taxprice_debit1", i).Value.ToString)


                                .Fields("containertype").Value = Me.dgddebitGrid1.Item("containertype_debit1", i).Value ' Me.txtunitdebit.Text


                                ' Me.txtunitpricedebit.Text
                                .Fields("quantity").Value = Me.dgddebitGrid1.Item("quantity_debit1", i).Value 'Me.txtquantitydebit.Text
                                .Fields("debitcredit").Value = Me.dgddebitGrid1.Item("debitcredit", i).Value


                                '  .Fields("container").Value = Me.cboContainer.Text


                                ' Me.dgddebitGrid1.Item("unitprice_debit1", i).Value gia truoc thue
                                '   .Fields("unitprice").Value  gia sau theu cua credit


                                .Fields("unitprice").Value = CDbl(Me.dgddebitGrid1.Item("unitprice_debit1", i).Value) * ((vat / 100) + 1)


                                '------------------------------
                                ' Me.txttaxdebit.Text
                                '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text
                                If Me.dgddebitGrid1.Item("currency_debit1", i).Value.ToString = "VND" Then
                                    .Fields("price").Value = Me.dgddebitGrid1.Item("price_debit1", i).Value  '* ((vat / 100) + 1) * ((vat / 100) + 1)Me.dgdPIC.Item("priceincvat_q", i).Value ' Me.txtpricedebit.Text

                                Else
                                    .Fields("price").Value = CDbl(Me.dgddebitGrid1.Item("price_debit1", i).Value) / CDbl(Me.dgddebitGrid1.Item("tigia_debit1", i).Value) ' tigia_debit1 ' Me.dgdPIC.Item("priceincvat_q", i).Value ' Me.txtpricedebit.Text

                                End If

                                .Fields("note").Value = Me.dgddebitGrid1.Item("note_debit1", i).Value 'Me.txtremarksdebit.Text

                                .Fields("os").Value = False
                                .Fields("paycheck").Value = False
                                ' .Fields("showarrival").Value = True
                                .Fields("daily").Value = False

                                .Fields("ngay").Value = ""
                                .Fields("ngayhoadon").Value = ""
                                .Fields("tigia").Value = Me.dgddebitGrid1.Item("tigia_debit1", i).Value.ToString  ' getCur("USD") 'Me.txtexdebit.Text
                                '  .Fields("debitcredit").Value = "Debit"
                                .Fields("songaycongno").Value = ""
                                Try
                                    .Fields("stt").Value = (i + 1).ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("showvnd").Value = False
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("freedem").Value = "0"
                                Catch ex As Exception
                                    .Fields("freedem").Value = "0"
                                End Try
                                Try
                                    .Fields("freedet").Value = "0"
                                Catch ex As Exception
                                    .Fields("freedet").Value = "0"
                                End Try
                                Try
                                    .Fields("no_").Value = ""
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("f1").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("f2").Value = "0"
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("t1").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("t2").Value = "0"
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("p1").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("p2").Value = "0"
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("level").Value = "0"
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("unitprice_").Value = CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit1", i).Value) / CDbl(Me.dgddebitGrid1.Item("quantity_debit1", i).Value)
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("price_").Value = Me.dgddebitGrid1.Item("pricetruocthue_debit1", i).Value
                                Catch ex As Exception

                                End Try


                                .Update()
                            End With
                            rs.Close()


                            mStatusDebit = "Normal"
                            Me.cmdok_debit.Enabled = False
                            Me.cmdcancel_debit_Click(sender, e)
                            Me.Querydebit()
                            Me.QueryCredit()
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                        profit()
                        'profit_theonguyente()
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcurrdebit_Leave(sender As Object, e As EventArgs) Handles txtcurrdebit.Leave
        Try
            Me.txtexdebit.Text = getCur(Me.txtcurrdebit.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcurrdebit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtcurrdebit.SelectedIndexChanged
        Try
            Me.txtexdebit.Text = getCur(Me.txtcurrdebit.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetChargeableFromContainerGrid(ByVal blobId As String, ByVal containerInfo As String) As Double
        Try
            Dim j As Integer
            Dim tongChargeable As Double = 0
            Dim found As Boolean = False

            For j = 0 To Me.dgdContainers.Rows.Count - 1
                If Me.dgdContainers.Rows(j).IsNewRow Then Continue For

                Dim contBlobId As String = ""
                Try
                    contBlobId = Me.dgdContainers.Item("INboundID", j).Value.ToString.Trim
                Catch ex As Exception
                    Continue For
                End Try

                If UCase(contBlobId) <> UCase(blobId) Then Continue For

                Dim contKey As String = Me.dgdContainers.Item("containerNo", j).Value.ToString.Trim & "-" & Me.dgdContainers.Item("containerType", j).Value.ToString.Trim
                Dim chargeable As Double = 0
                Try
                    chargeable = CDbl(Me.dgdContainers.Item("chargeable", j).Value.ToString)
                Catch ex As Exception
                    chargeable = 0
                End Try

                If containerInfo <> "" Then
                    If UCase(contKey) = UCase(containerInfo) OrElse UCase(containerInfo) Like "*" & UCase(Me.dgdContainers.Item("containerNo", j).Value.ToString.Trim) & "*" Then
                        Return chargeable
                    End If
                Else
                    tongChargeable += chargeable
                    found = True
                End If
            Next

            If containerInfo = "" And found Then
                Return tongChargeable
            End If
        Catch ex As Exception

        End Try

        Return -1
    End Function

    Private Sub UpdateDebitQuantityFromContainer(ByVal inboundfreightId As String, ByVal qty As Double)
        Dim strQuery As String
        Dim rs As New ADODB.Recordset

        Try
            copyHistory("Inboundfreight", "Inboundfreightid", inboundfreightId, "history")
        Catch ex As Exception

        End Try

        strQuery = "SELECT * FROM inboundfreight WHERE inboundfreightid='" & inboundfreightId & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        With rs
            If rs.EOF Then
                rs.Close()
                Exit Sub
            End If

            Dim unitprice_ As Double = 0
            Dim unitprice As Double = 0
            Dim taxprice As Double = 0
            Dim tigia As Double = 0
            Dim currency As String = ""

            Try
                unitprice_ = CDbl(.Fields("unitprice_").Value)
            Catch ex As Exception
            End Try
            Try
                unitprice = CDbl(.Fields("unitprice").Value)
            Catch ex As Exception
            End Try
            Try
                taxprice = CDbl(.Fields("taxprice").Value)
            Catch ex As Exception
            End Try
            Try
                tigia = CDbl(.Fields("tigia").Value)
            Catch ex As Exception
            End Try
            Try
                currency = .Fields("currency").Value.ToString.Trim
            Catch ex As Exception
            End Try

            .Fields("quantity").Value = qty
            .Fields("price_").Value = FormatNumber(unitprice_ * qty, 3)
            .Fields("price").Value = FormatNumber(unitprice * qty, 3)

            Try
                If currency <> "VND" Then
                    .Fields("dongiatruocthueVND").Value = FormatNumber(unitprice_ * tigia, 0)
                Else
                    .Fields("dongiatruocthueVND").Value = FormatNumber(unitprice_, 0)
                End If
            Catch ex As Exception

            End Try

            Try
                .Fields("thanhtientruocthueVND").Value = FormatNumber(CDbl(.Fields("dongiatruocthueVND").Value) * qty, 0)
            Catch ex As Exception

            End Try

            Try
                .Fields("tienthueVND").Value = FormatNumber(CDbl(.Fields("thanhtientruocthueVND").Value) * taxprice / 100, 0)
            Catch ex As Exception

            End Try

            Try
                .Fields("thanhtiensauthueVND").Value = FormatNumber(CDbl(.Fields("thanhtientruocthueVND").Value) * ((taxprice / 100) + 1), 0)
            Catch ex As Exception

            End Try

            .Update()
            .Close()
        End With
    End Sub

    Private Sub Button115_Click(sender As Object, e As EventArgs) Handles Button115.Click
        Try
            If Me.dgddebitGrid.Rows.Count = 0 Then
                DisplayMessage(True, "Không có dữ liệu debit.")
                Exit Sub
            End If

            If Me.dgdContainers.Rows.Count = 0 Then
                DisplayMessage(True, "Không có dữ liệu container.")
                Exit Sub
            End If

            If ConfirmMessage(True, "Bạn có muốn update Quantity (KGS) theo Container?") <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            Dim i As Integer
            Dim updatedCount As Integer = 0

            For i = 0 To Me.dgddebitGrid.Rows.Count - 1
                If Me.dgddebitGrid.Rows(i).IsNewRow Then Continue For

                Try
                    If UCase(Me.dgddebitGrid.Item("containertype_debit", i).Value.ToString.Trim) <> "KGS" Then Continue For
                Catch ex As Exception
                    Continue For
                End Try

                Try
                    If Me.dgddebitGrid.Item("approveDebit", i).Value Then Continue For
                Catch ex As Exception

                End Try

                Dim blobId As String = mInboundID
                Try
                    blobId = Me.dgddebitGrid.Item("inboundid_debit", i).Value.ToString.Trim
                Catch ex As Exception

                End Try

                Dim qty As Double = GetChargeableFromContainerGrid(blobId, "")
                If qty < 0 Then Continue For
                If qty < 1 Then qty = 1

                Try
                    UpdateDebitQuantityFromContainer(Me.dgddebitGrid.Item("inboundfreightid_debit", i).Value.ToString, qty)
                    updatedCount += 1
                Catch ex As Exception

                End Try
            Next

            Me.Querydebit()
            profit()
            DisplayMessage(True, "Đã update " & updatedCount.ToString & " dòng debit KGS.")
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Sub ImportFreightFromTarif(ByVal tarifCombo As ComboBox, ByVal isDebit As Boolean)
        Try
            If mInboundID = "" Or mInboundID = DefaultValue Then
                DisplayMessage(True, "Xin chọn inbound trước.")
                Exit Sub
            End If
            If tarifCombo.Text.Trim = "" Then
                DisplayMessage(True, "Xin chọn Header Tarif.")
                tarifCombo.Focus()
                Exit Sub
            End If

            Dim headerId As String = FindValueID(tarifCombo, tarifCombo.Text)
            If headerId = "" Then
                DisplayMessage(True, "Header Tarif không hợp lệ.")
                Exit Sub
            End If

            Dim dsHeader As DataSet = ReadDataSet("Select customer_id From Header_Tarif Where id = '" & headerId.Replace("'", "''") & "'")
            If dsHeader.Tables(0).Rows.Count = 0 Then
                DisplayMessage(True, "Không tìm thấy Header Tarif.")
                Exit Sub
            End If
            Dim customerId As String = dsHeader.Tables(0).Rows(0).Item("customer_id").ToString()

            Dim dsDetail As DataSet = ReadDataSet("Select * From Deatail_Tarif Where id_header = '" & headerId.Replace("'", "''") & "'")
            If dsDetail.Tables(0).Rows.Count = 0 Then
                DisplayMessage(True, "Không có chi tiết trong Header Tarif này.")
                Exit Sub
            End If

            If ConfirmMessage(True, "Tạo " & dsDetail.Tables(0).Rows.Count.ToString() & " phí từ Tarif?") <> MsgBoxResult.Ok Then Exit Sub

            Dim rs As New ADODB.Recordset
            rs.Open("Select * From inboundfreight", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            Dim i As Integer
            For i = 0 To dsDetail.Tables(0).Rows.Count - 1
                Dim dr As DataRow = dsDetail.Tables(0).Rows(i)

                rs.AddNew()
                rs.Fields("inboundfreightID").Value = NewId()
                rs.Fields("inboundID").Value = getID(mInboundID)
                rs.Fields("customerid").Value = getID(customerId)
                rs.Fields("debitcredit").Value = If(isDebit, "Debit", "Credit")
                rs.Fields("itemid").Value = getID(dr.Item("itemid").ToString())
                rs.Fields("currency").Value = dr.Item("currency").ToString()
                rs.Fields("containertype").Value = dr.Item("unit").ToString()
                rs.Fields("quantity").Value = dr.Item("qty").ToString()
                rs.Fields("taxprice").Value = dr.Item("vat").ToString()
                rs.Fields("tigia").Value = dr.Item("tigia").ToString()

                Try
                    rs.Fields("unitprice_").Value = dr.Item("unitprice").ToString()
                Catch ex As Exception
                End Try
                Try
                    rs.Fields("unitprice").Value = dr.Item("unitprice_incvat").ToString()
                Catch ex As Exception
                End Try
                Try
                    rs.Fields("price_").Value = dr.Item("totalamount").ToString()
                Catch ex As Exception
                End Try
                Try
                    rs.Fields("pricetruocthue").Value = dr.Item("totalamount").ToString()
                Catch ex As Exception
                End Try

                rs.Update()
            Next
            rs.Close()

            If isDebit Then
                Me.Querydebit()
            Else
                Me.QueryCredit()
            End If
            profit()
            DisplayMessage(True, "Đã tạo " & dsDetail.Tables(0).Rows.Count.ToString() & " phí.")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button117_Click(sender As Object, e As EventArgs) Handles Button117.Click
        ImportFreightFromTarif(Me.cbotarifheader_Credit, False)
    End Sub

    Private Sub Button116_Click(sender As Object, e As EventArgs) Handles Button116.Click
        ImportFreightFromTarif(Me.cbotarifheader, True)
    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click

    End Sub

    Private Sub txtcurrcredit_Leave(sender As Object, e As EventArgs) Handles txtcurrcredit.Leave
        Try
            Me.txtexcredit.Text = getCur(Me.txtcurrcredit.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcurrcredit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtcurrcredit.SelectedIndexChanged
        Try
            Me.txtexcredit.Text = getCur(Me.txtcurrcredit.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgddebitGrid_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgddebitGrid.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgddebitGrid.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgddebitGrid.Columns(ColIndex).Name) = "APPROVEDEBIT" And Me.dgddebitGrid.CurrentCellAddress.Y = RowIndex Then
            Call ApproveDebitNote()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.Querydebit()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdCreditGrid_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgdCreditGrid.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCreditGrid.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdCreditGrid.Columns(ColIndex).Name) = "APPROVECREDIT" And Me.dgdCreditGrid.CurrentCellAddress.Y = RowIndex Then
            Call ApproveCreditNote()
            'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
            Me.QueryCredit()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button102_Click(sender As Object, e As EventArgs) Handles Button102.Click
        Try
            Me.GroupBox23.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button103_Click(sender As Object, e As EventArgs) Handles Button103.Click
        Try
            Me.GroupBox23.BringToFront()
            Me.GroupBox23.Visible = True
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

    Private Sub Button112_Click(sender As Object, e As EventArgs) Handles Button112.Click
        Try
            If LoginSucceeded Then
             
                VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Try
            If LoginSucceeded Then

                VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Try
            If LoginSucceeded Then

                VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyToCreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToCreditToolStripMenuItem.Click
        Try
            If Me.dgddebitGrid.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim rs As New ADODB.Recordset
            Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
            Dim sql, strQuery As String
            Dim ds As New DataSet
            vitri = index
            If index >= 0 Then
                'Co mLogisticsID
                mdebitID = Me.dgddebitGrid.Item("inboundfreightid_debit", index).Value.ToString
                sql = "select * from inboundfreight where inboundfreightID='" & mdebitID & "' and debitcredit='Debit'"
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    strQuery = "Select * From inboundfreight "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("inboundfreightID").Value = NewId()
                        .Fields("inboundID").Value = getID(mInboundID)



                        '-------------------------------container
                        .Fields("customerid").Value = "{" + ds.Tables(0).Rows(0).Item("customerid").ToString + "}" '"{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"
                        .Fields("itemid").Value = "{" + ds.Tables(0).Rows(0).Item("itemid").ToString + "}" '"{" + FindValueID(Me.cboitemdebit, Me.cboitemdebit.Text) + "}"
                        .Fields("currency").Value = ds.Tables(0).Rows(0).Item("currency").ToString ' Me.txtcurrdebit.Text
                        .Fields("containertype").Value = ds.Tables(0).Rows(0).Item("containertype").ToString 'Me.txtunitdebit.Text
                        .Fields("unitprice").Value = ds.Tables(0).Rows(0).Item("unitprice").ToString 'Me.txtunitpricedebit.Text
                        .Fields("quantity").Value = ds.Tables(0).Rows(0).Item("quantity").ToString 'Me.txtquantitydebit.Text
                        '.Fields("pricetruocthue").Value = Me.txtpricenotaxdebit.Text
                        '.Fields("pricenotaxvnd").Value = Me.txtpricenotaxvnddebit.Text


                        .Fields("taxprice").Value = ds.Tables(0).Rows(0).Item("taxprice").ToString 'Me.txttaxdebit.Text
                        '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text
                        .Fields("price").Value = ds.Tables(0).Rows(0).Item("price").ToString 'Me.txtpricedebit.Text
                        .Fields("note").Value = ds.Tables(0).Rows(0).Item("note").ToString 'Me.txtremarksdebit.Text
                        .Fields("os").Value = ds.Tables(0).Rows(0).Item("os").ToString 'Me.chkosdebit.Checked
                        .Fields("paycheck").Value = ds.Tables(0).Rows(0).Item("paycheck").ToString ' Me.chkpaydebit.Checked
                        .Fields("showvnd").Value = ds.Tables(0).Rows(0).Item("showvnd").ToString 'Me.chkShowVND.Checked ' doi lai la Inv
                        .Fields("ngay").Value = ds.Tables(0).Rows(0).Item("ngay").ToString 'Me.txtinvoicedebit.Text
                        .Fields("ngayhoadon").Value = ds.Tables(0).Rows(0).Item("ngayhoadon").ToString 'Me.txtinvoicenodebit.Text
                        .Fields("tigia").Value = ds.Tables(0).Rows(0).Item("tigia").ToString 'Me.txtexdebit.Text
                        .Fields("debitcredit").Value = "Credit"
                        .Fields("songaycongno").Value = ds.Tables(0).Rows(0).Item("songaycongno").ToString 'Me.txthancongno.Text
                        Try
                            .Fields("stt").Value = ds.Tables(0).Rows(0).Item("stt").ToString 'Me.txtstt.Text
                        Catch ex As Exception

                        End Try

                        .Update()
                        DisplayMessage(True, "Copy OK .!")
                    End With
                    rs.Close()
                    Me.QueryCredit()
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub
End Class