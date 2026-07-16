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
'--------------------------------
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports System.Windows.Forms
Imports _DCubeNoGimbalLock
Public Class frmOutbound
    Inherits System.Windows.Forms.Form
    Public vitri As Integer
    Dim rsPortList As New ADODB.Recordset
    Dim mStatus, mFilter, mStatusHinh, mStatuspackage As String
    Public blnUpdated As Boolean
    Public mID, mOutboundID, mHinhID, mdebitid, mCreditId, mLogisticsID, mStatusTheodoi, mStatusCashLoan As String

    Dim mStatusContainer, mStatusDebit, mStatusCredit, mOutboundContainerID, mOutbounddebitID, mOutcreditID, mTheodoiid, mOutboundPackageID, mCashLoanID As String

    '-------------
    Public mFlag As Integer = 0
    Public mText1 As String = ""
    Public mText2 As String = ""
    '------------------
    Dim oTblEquip, otblHinh As New DataTable
    Public oTable As DataTable
    Public ds As New DataSet
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer
    Const strCarrierSelect As String = "SELECT * "
    '" indate,outdate,currency,[20gp],[40gp],[40hc],[45hc],[20rf],[40rf],[40rh],[20ot],[40ot],[20fr],[40fr],cbm,ratedetail.remarks, " & _
    '"ratedetail.Continued, " & _
    '"ratedetail.Editable, " & _
    '"ratedetail.UserId, " & _
    '"ratedetail.Updatetime "
    Dim PortPOLPOD As String

    Const strCarrierOrder1 As String =
           " ORDER BY shippingline  "

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
            Me.cboops.Items.Clear()
            id = "usr"
            value = "usr"
            strSQL = "Select  usr from userlist order by usr "
            loadDataToObject(Me.cboops, strSQL, id, value)
            '-----------------------------------------------
            Me.cboMBLCarrier.Items.Clear()
            id = "ref"
            value = "ref"
            If UCase(gDepartment) = "SALE" Then
                strSQL = "Select distinct ref From Outbound where salecode='" & gSaleCode & "' and branch like '%" & gBranch & "%' and Continued=1  and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' )  "
            Else
                If UCase(gDepartment) = "CUSTOMER" Or UCase(gDepartment) = "DOCUMENT" Then
                    strSQL = "Select distinct ref From Outbound where  branch like '%" & gBranch & "%' and Continued=1  and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' )  "
                Else
                    strSQL = "Select distinct ref From Outbound where   Continued=1   " 'branch like '%" & gBranch & "%'
                End If

            End If

            loadDataToObject(Me.cboMBLCarrier, strSQL, id, value)
            'loadDataToObject(Me.txtOPL, strSQL, id, value)
            'loadDataToObject(Me.txtPOD, strSQL, id, value)
            id = "blob_id"
            value = "MBLMAWB"
            Me.cboCopyHBL.Items.Clear()
            Me.cboMBLTo.Items.Clear()

            strSQL = "Select distinct blob_id,MBLMAWB From Outbound where branch like '%" & gBranch & "%' and Continued=1     "
            loadDataToObject(Me.cboCopyHBL, strSQL, id, value)
            loadDataToObject(Me.cboMBLTo, strSQL, id, value)

            '------------

            '-----------------------------------------------
            id = "blob_id"
            value = "HBLHAWB"
            Me.txtHBLHAWB.Items.Clear()
            strSQL = "Select distinct blob_id,HBLHAWB,dateupdate From Outbound where Continued=1    order by dateUpdate desc "
            loadDataToObject(Me.txtHBLHAWB, strSQL, id, value)
            '------------------------
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
            strQuery = "Select distinct Shipper from outbound where CONTINUED=1    Order by shipper "
            loadDataToObject(Me.cboShipper, strQuery, id, value)

            'id = "consignee"
            'value = "consignee"
            'strQuery = "Select distinct consignee from outbound where CONTINUED=1    Order by consignee "
            'loadDataToObject(Me.cboConsignee, strQuery, id, value)

            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where CONTINUED=1 Order by company "
            loadDataToObject(Me.cboConsignee, strQuery, id, value)


            Me.cboNotify.Items.Clear()
            id = "notify"
            value = "notify"
            strQuery = "Select distinct notify from outbound where CONTINUED=1    Order by notify "
            loadDataToObject(Me.cboNotify, strQuery, id, value)

            Me.cboSale.Items.Clear()
            id = "salecode"
            value = "salecode"
            strQuery = "Select salecode from sale where CONTINUED=1 Order by salecode "
            loadDataToObject(Me.cboSale, strQuery, id, value)

            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,shortname as company from customer where CONTINUED=1 Order by company "
            Me.cbocusdebit.Items.Clear()
            Me.cbocuscredit.Items.Clear()
            Me.cboCustomer.Items.Clear()
            '----- cus Pack
            Me.cboCusPackage.Items.Clear()
            loadDataToObject(Me.cboCusPackage, strQuery, id, value)
            '---------------------

            loadDataToObject(Me.cboCustomer, strQuery, id, value)
            loadDataToObject(Me.cbocusdebit, strQuery, id, value)

            loadDataToObject(Me.cbocuscredit, strQuery, id, value)

            '----------
            Me.cboitemdebit.Items.Clear()
            Me.cboitemcredit.Items.Clear()















            id = "charge"
            value = "charge"
            strQuery = "Select charge from charge where CONTINUED=1 Order by charge "




            '---------------------
            Dim id_ As String
            Dim value_ As String
            Dim strQuery_ As String
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code + '/' + dvt  + '/' + charge as charge_code from charge where CONTINUED=1 Order by charge_code "



            loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)
            loadDataToObject(Me.cboitemdebit, strQuery_, id_, value_)







            ' them port vao cbo
            Me.txtPOL.Items.Clear()
            id = "POL"
            value = "POL"
            strQuery = "Select distinct POL from outbound where CONTINUED=1    Order by POL "
            loadDataToObject(Me.txtPOL, strQuery, id, value)

            Me.txtPOD.Items.Clear()
            id = "POd"
            value = "POd"
            strQuery = "Select distinct POd from outbound where CONTINUED=1    Order by POd "
            loadDataToObject(Me.txtPOD, strQuery, id, value)
            '---------------
            Me.cbopodcode.Items.Clear()
            Me.cbopolcode.Items.Clear()
            id = "port_code"
            value = "port_code"
            strQuery = "Select port_code,port from port where CONTINUED=1 and show=1 Order by port_code "
            loadDataToObject(Me.cbopodcode, strQuery, id, value)
            loadDataToObject(Me.cbopolcode, strQuery, id, value)
            '------------------------

            Me.txtPOR.Items.Clear()
            id = "POr"
            value = "POr"
            strQuery = "Select distinct POr from outbound where CONTINUED=1    Order by POr "
            loadDataToObject(Me.txtPOR, strQuery, id, value)

            Me.txtDel.Items.Clear()
            id = "del"
            value = "del"
            strQuery = "Select distinct del from outbound where CONTINUED=1    Order by del "
            loadDataToObject(Me.txtDel, strQuery, id, value)

            Me.txtDest.Items.Clear()
            id = "dest"
            value = "dest"
            strQuery = "Select distinct dest from outbound where CONTINUED=1    Order by dest "
            loadDataToObject(Me.txtDest, strQuery, id, value)


            '----------------------------------------------
            ' Me.cboitems.Items.Clear()
            id = "items"
            value = "items"
            strQuery = "Select distinct items from theodoilohang order by items "
            loadDataToObject_(Me.cboitems, strQuery, id, value)
            'quotationNo

            ' Me.cboquotationNo.Items.Clear()
            id = "quotationid"
            value = "quotationNo"
            If UCase(gDepartment) = "SALE" Then
                strQuery = "Select quotationid,quotationNo from quotation where salename ='" & strUserId & "' and branch like '%" & gBranch & "%' AND (quotationNo like '%ES%' or quotationNo like '%EN%') and approve=1 order by quotationNo "
            Else
                strQuery = "Select quotationid,quotationNo from quotation  where branch like '%" & gBranch & "%' AND (quotationNo like '%ES%' or quotationNo like '%EN%') and approve=1  order by quotationNo "
            End If

            '  loadDataToObject(Me.cboquotationNo, strQuery, id, value)

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
            ' load agent
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 and maincode like '%agent%' Order by company "
            Me.cboagent.Items.Clear()

            loadDataToObject(Me.cboagent, strQuery, id, value)
            '----------------------------
            'id = "customer_id"
            'value = "company"
            'strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 Order by company "
            'Me.cboCompany.Items.Clear()
            'loadDataToObject(Me.cboCompany, strQuery, id, value)
            '--------------------------
            'containeroutboundnotify
            '----------------------------
            id = "gmd_bookingno"
            value = "gmd_bookingno"
            strQuery = "Select gmd_bookingno from bookingagent " 'where CONTINUED=1 Order by company "
            Me.txtBKNo.Items.Clear()
            loadDataToObject(Me.txtBKNo, strQuery, id, value)

            id = "inboundcontainersID"
            value = "containerno"
            Me.txtContainerNo1.Items.Clear()
            strSQL = "Select  inboundcontainersID,containerno From containerrepair   order by containerno  "
            loadDataToObject(Me.txtContainerNo1, strSQL, id, value)
            '--------------------------
            Me.cbotransit.Items.Clear()
            id = "transit"
            value = "transit"
            strQuery = "Select distinct transit from outbound where CONTINUED=1    Order by transit "
            loadDataToObject(Me.cbotransit, strQuery, id, value)


            'Try
            '    Me.cbooRef.Items.Clear()
            '    id = "ref"
            '    value = "ref"
            '    strQuery = "Select distinct ref from logistics where CONTINUED=1 Order by ref "
            '    loadDataToObject(Me.cbooRef, strQuery, id, value)
            'Catch ex As Exception

            'End Try




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SI()

        Try
            Dim id, value, strQuery As String
            '  Me.cboquotationNo.Items.Clear()
            id = "ContainerOutboundNotifyID"
            value = "bkcarrier"
            'If UCase(gDepartment) = "SALE" Then
            '    strQuery = "Select quotationid,quotationNo from quotation where salename ='" & strUserId & "' and branch like '%" & gBranch & "%' AND (quotationNo like '%IS%' or quotationNo like '%IN%') order by quotationNo "
            'Else
            strQuery = "Select ContainerOutboundNotifyID,bkcarrier from ContainerOutboundNotify where branch like '%" & gBranch & "%'   and continued=1 order by bkcarrier "
            'End If

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
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Try


            Me.TabControl1.Visible = False
            ReFormat()

            mStatus = "Normal"
            reText(mStatus)
            Me.cmdOK.Enabled = False
            Me.cmdOKAll.Enabled = False


            Me.dgdHBL.Enabled = True
            Me.TabControl1.Enabled = False
            'Me.Close()  
            Dim cmd As New ADODB.Command
            Try
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from billonline where id= '" & mOutboundID & "' and userupdate='" & strUserId & "'"

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try

            ' xoa billonline

            '-------------------------
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub



    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Try


            Dim strQuery, strCarrierId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            'If Me.txtSayContainer.Text.Length > 50 Then
            '    DisplayMessage(True, "Xin lưu ý , (Say Container) tối đa 50 ký tự.! ")
            'End If

            If Me.CBOStatus.Text = "" Then
                DisplayMessage(True, "Status.?")
                Me.CBOStatus.Focus()
                Exit Sub
            End If

            'If Me.cboCarrier.Text = "" Then
            '    DisplayMessage(True, "Carrier.?")
            '    Me.cboCarrier.Focus()
            '    Exit Sub
            'End If
            'If Me.chkfcl.Checked = False And Me.chklcl.Checked = False And Me.chkconsol.Checked = False Then
            '    DisplayMessage(True, "Kiểm tra loại hàng FCL,LCL,Consol.!")
            '    'Exit Sub
            'End If
            If mStatus = "Edit" Then
                index = Me.dgdHBL.CurrentRow.Index
            End If
            If Me.txtETA.Text = "" Or Me.txtETD.Text = "" Then
                DisplayMessage(True, "ETD, ETA ?")
                Exit Sub
            End If
            'If Me.txteta.Text.ToString.Trim.Length = 11 Then
            'Else
            '    DisplayMessage(True, "ETD, ETA (dd-MMM-yyyy)")
            '    ' Exit Sub
            'End If

            'If Me.txtetd.Text.ToString.Trim.Length = 11 Then
            'Else
            '    DisplayMessage(True, "ETD, ETA (dd-MMM-yyyy)")
            '    'Exit Sub
            'End If
            'If Me.cboitemSITC.Text = "" Then
            '    DisplayMessage(True, "Items ?")
            '    Exit Sub
            'End If
            ' kiem tra teu va cbm
            If IsNumeric(txttongteu.Text) = False Then
                DisplayMessage(True, "Xin kiểm tra Total Teu ! ")
                Exit Sub
            End If
            If IsNumeric(txttongcbm.Text) = False Then
                DisplayMessage(True, "Xin kiểm tra Total CBM ! ")
                Exit Sub
            End If
            '0000000000000000000
            If UserRight("mnuOutbound", "Edit") Then



                If (mStatus = "Add" Or mStatus = "Edit") Then
                    Try
                        copyHistory("Outbound", "BLOB_ID", mOutboundID, "history")
                    Catch ex As Exception

                    End Try
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM Outbound "
                    strQuery = strQuery & "WHERE BLOB_ID = '" & mOutboundID & "' and continued=1 "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("BLOB_ID").Value = NewId()
                        End If
                        strCarrierId = .Fields("BLOB_ID").Value
                        Try
                            .Fields("lot").Value = Me.txtlot.Text
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("shipperother").Value = Me.txtshipperOther.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("shipperother").Value = Me.txtshipperOther.Text
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("consigneeother").Value = Me.txtconsigneeOther.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("notifyother").Value = Me.txtnotifyOther.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("agencynameOther").Value = Me.txtAgencyNameOther.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("agencynamesi").Value = Me.txtagencyNameSI.Text
                        Catch ex As Exception

                        End Try
                        'Try

                        '    .Fields("Oref").Value = Me.cbooRef.Text
                        'Catch ex As Exception

                        'End Try
                        Try
                            .Fields("MVessel").Value = Me.txtMVessel.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("MVoy").Value = Me.txtMVoy.Text
                        Catch ex As Exception

                        End Try




                        ' them booking
                        Try
                            .Fields("quotationNo").Value = Me.txtquotation.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("transit").Value = Me.cbotransit.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("ngayhabai").Value = Me.txtngayhabai.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("NVOCC").Value = Me.chksoccoc.Checked
                        Catch ex As Exception

                        End Try


                        ' luu tru tong teu,tongcbm

                        Try
                            .Fields("oprcode").Value = Me.txtoprcode.Text.Trim
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("ngayhttthq").Value = Me.txtngayHTTTHQ.Text.Trim
                        Catch ex As Exception

                        End Try
                        Try

                            .Fields("tongteu").Value = Me.txttongteu.Text.Trim
                        Catch ex As Exception

                        End Try

                        Try

                            .Fields("tongcbm").Value = Me.txttongcbm.Text.Trim
                        Catch ex As Exception

                        End Try

                        '------------------------------------


                        '.Fields("cboBookingOffice").Value = Me.cboBookingOffice.Text
                        '.Fields("txtcontactperson").Value = Me.txtcontactperson.Text
                        'Try
                        '    .Fields("CustomerID").Value = "{" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "}"
                        'Catch ex As Exception
                        '    .Fields("CustomerID").Value = DefaultValue
                        'End Try

                        '.Fields("cboRepresentative").Value = Me.cboRepresentative.Text
                        '.Fields("txtgmd_placeofstuffing").Value = Me.txtgmd_placeofstuffing.Text
                        '.Fields("dtpBookingdate").Value = Me.dtpBookingdate.Text
                        '.Fields("TXTTRANSHIPMENTPORT").Value = Me.TXTTRANSHIPMENTPORT.Text
                        '.Fields("TXTCUTOFFTIME").Value = Me.TXTCUTOFFTIME.Text
                        '.Fields("TXTCUTOFFcargo").Value = Me.TXTCUTOFFCARGO.Text
                        '.Fields("TXTCUTOFFsi").Value = Me.TXTCUTOFFSI.Text
                        '.Fields("txtthongtinlienhe").Value = Me.txtthongtinlienhe.Text
                        '.Fields("TXTTYPE").Value = Me.TXTTYPE.Text


                        '.Fields("txtgmd_noofcontainerorpackage").Value = Me.txtgmd_noofcontainerorpackage.Text
                        '.Fields("TXTgmd_gw").Value = Me.TXTgmd_gw.Text
                        '.Fields("TXTgmd_cbm").Value = Me.TXTgmd_cbm.Text
                        '---------------------------------------------------------
                        ' .Fields("attachlist").Value = Me.txtAttachList.Text
                        '.Fields("tigia").Value = Me.txttigia.Text
                        Try
                            .Fields("status").Value = Me.CBOStatus.Text
                        Catch ex As Exception

                        End Try
                        .Fields("RF").Value = Me.CHKrf.Checked
                        '--------22-jun
                        .Fields("tkhq").Value = Me.txttkhq.Text
                        '-------------------------
                        ' them agentID
                        Try
                            .Fields("agentid").Value = "{" + FindValueID(Me.cboagent, Me.cboagent.Text) + "}"
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("InvoiceRequestDate").Value = ddMMMyyyy(CDate(Me.TXTInvoiceRequestDate.Text).Date)
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description + " (InvoiceRequestDate) ")
                            .Fields("InvoiceRequestDate").Value = ""
                        End Try
                        Try
                            .Fields("datereport").Value = ddMMMyyyy(Me.dtpDateReport.Value.Date)
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                        Try ' them sitc
                            .Fields("podcode").Value = Me.cbopodcode.Text

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("ops").Value = Me.cboops.Text

                        Catch ex As Exception

                        End Try
                        Try ' them sitc
                            .Fields("polcode").Value = Me.cbopolcode.Text

                        Catch ex As Exception

                        End Try
                        Try ' them sitc
                            .Fields("itemSITC").Value = Me.cboitemSITC.Text

                        Catch ex As Exception

                        End Try
                        '.Fields("clockcredit").Value = Me.chkClockCredit.Checked
                        ' them tong
                        Try
                            .Fields("prepaidat").Value = Me.txtprepaidAt.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("totalprepaidin").Value = Me.txttotalprepaidIn.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("revenuetons").Value = Me.txtrevenueTons.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("cbmforcom").Value = Me.txtcbmForCom.Text
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

                        .Fields("tongsoluong").Value = Me.txttongsoluong.Text
                        .Fields("tongsoluong1").Value = Me.txttongsoluong1.Text
                        .Fields("tongsoluong2").Value = Me.txttongsoluong2.Text
                        .Fields("loai").Value = Me.loai.Text
                        .Fields("loai1").Value = Me.loai1.Text
                        .Fields("loai2").Value = Me.loai2.Text
                        .Fields("tongkien").Value = Me.tongkien.Text
                        .Fields("tongkg").Value = Me.tongkg.Text
                        .Fields("tongkhoi").Value = Me.tongkhoi.Text

                        '-------------------

                        .Fields("LCL").Value = Me.chklcl.Checked
                        .Fields("FCL").Value = Me.chkfcl.Checked
                        .Fields("Consol").Value = Me.chkconsol.Checked
                        .Fields("air").Value = Me.chkair.Checked
                        ' add cach tinh com



                        ' hang air
                        .Fields("AirportDeparture").Value = Me.txtAirportDeparture.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("RefNumber").Value = Me.txtRefNumber.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        Try
                            .Fields("currency_").Value = Me.txtCurrency.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        Catch ex As Exception

                        End Try
                        .Fields("ppd1").Value = Me.txtPPD1.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("ppd2").Value = Me.txtPPD2.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("coll2").Value = Me.txtCOLL2.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("coll1").Value = Me.txtCOLL1.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("AirPortDes").Value = Me.txtAirPortDes.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("fv1").Value = Me.txtFV1.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("fv2").Value = Me.txtFV2.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("fd2").Value = Me.txtFD2.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("fd1").Value = Me.txtFD1.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("Handling").Value = Me.txtHandling.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("rcp").Value = Me.txtRCP.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("gw").Value = Me.txtGW.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("commondity").Value = Me.txtCommodity.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airChargeAbleWeight").Value = Me.txtChargeAbleWeight.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        '---------------dimension
                        .Fields("dimension").Value = Me.txtdimension.Text
                        '------------------------------------
                        .Fields("RateCharge").Value = Me.txtRateCharge.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("total").Value = Me.txtTotal.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("nature").Value = Me.txtNature.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("wcprepaid").Value = Me.txtWCPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("wccollect").Value = Me.txtWCCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("vprepaid").Value = Me.txtVPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("vcollect").Value = Me.txtVCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("totalprepaid").Value = Me.txtTotalPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("Totalcollect").Value = Me.txtTotalCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString


                        .Fields("taxprepaid").Value = Me.txtTaxPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("taxcollect").Value = Me.txtTaxCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("TotalAgentPrepaid").Value = Me.txtTotalAgentPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("TotalAgentCollect").Value = Me.txtTotalAgentCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("TotalCarrierPrepaid").Value = Me.txtTotalCarrierPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("TotalCarrierCollect").Value = Me.txtTotalCarrierCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("CurrRates").Value = Me.txtCurrRates.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("ChargesDest").Value = Me.txtChargesDest.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("DatePlace").Value = Me.txtDatePlace.Text '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("hisagent").Value = Me.txtHisAgent.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        '0------------------------------------------------
                        .Fields("nhanlenh").Value = Me.chkNhanlenh.Checked
                        .Fields("ngaynhanlenh").Value = Me.txtNgayNhanlenh.Text
                        .Fields("nguoinhanlenh").Value = Me.txtNguoinhanlenh.Text

                        .Fields("ManifestDate").Value = Me.txtManifest.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("sentHPGDate").Value = Me.txtSentHPG.Text '= ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("closeFile").Value = Me.chkClose.Checked '= ds.Tables(0).Rows(0).Item("").ToString

                        .Fields("MBLCarrier").Value = Me.txtMBLCarrier.Text
                        .Fields("MBLMAWB").Value = Me.txtMBLMAWB.Text
                        .Fields("HBLHAWB").Value = Me.txtHBLHAWB.Text
                        .Fields("BKNo").Value = Me.txtBKNo.Text
                        .Fields("ref").Value = Me.txtRef.Text

                        .Fields("CY_CFS_ITEM").Value = Me.txtCYCFS.Text
                        .Fields("bl_type").Value = Me.txtBL_Type.Text

                        .Fields("vessel").Value = Me.txtVessel.Text
                        .Fields("voyage").Value = Me.txtVoyage.Text
                        .Fields("ETA").Value = Me.txteta.Text

                        .Fields("SAILINGDATE").Value = Me.txtetd.Text
                        .Fields("pol").Value = Me.txtPOL.Text
                        .Fields("poR").Value = Me.txtPOR.Text

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
                        .Fields("saycontainer").Value = Me.txtSayContainer.Text
                        .Fields("ShippingMARKS").Value = Me.txtShippingMarks.Text
                        .Fields("DESCRIPTION").Value = Me.txtDescription.Text
                        '--------------------------
                        .Fields("FreightAmount").Value = Me.txtFreightAmount.Text
                        .Fields("FreightAmountSI").Value = Me.txtFreightAmountSI.Text
                        .Fields("FreightPayableAt").Value = Me.txtFreightPayableAt.Text

                        .Fields("PlaceAndDate").Value = Me.txtPlaceAndDate.Text
                        .Fields("NumberOfOriginal").Value = Me.txtNumberOfOriginal.Text

                        ''
                        .Fields("Prepaid").Value = Me.txtPP.Text
                        .Fields("Collect").Value = Me.txtCC.Text

                        .Fields("OnboardDate").Value = Me.txtOnboardDate.Text
                        .Fields("ShipperRef").Value = Me.txtShipperRef.Text
                        '---------------------------------
                        .Fields("remarks").Value = Me.txtRemarks.Text
                        .Fields("paidreceived").Value = Me.txtPaidReceived.Text
                        '--------------------------
                        '''----air

                        .Fields("airIssuingCarrier").Value = Me.txtairIssuingCarrier.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airAgentIATACode").Value = Me.txtairAgentIATACode.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airAccountNo").Value = Me.txtairAccountNo.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("AirTo1").Value = Me.txtAirTo1.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("AirByFirstCarrier").Value = Me.txtAirByFirstCarrier.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("Airto2").Value = Me.txtAirto2.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airby1").Value = Me.txtairby1.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airto3").Value = Me.txtairto3.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airby2").Value = Me.txtairby2.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airCHGSCode").Value = Me.txtairCHGSCode.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airDecCarrier").Value = Me.txtairDecCarrier.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("AirDecCus").Value = Me.txtAirDecCus.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airAmountOfInsurance").Value = Me.txtairAmountOfInsurance.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airSCI").Value = Me.txtairSCI.Text ' Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("AirOtherPC").Value = Me.txtAirOtherPC.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("airflightVoy2").Value = Me.txtFV2.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        '  .Fields("AirFlightDate").Value = Me.dtpAirFlightDate.Text ' = Me.ds.Tables(0).Rows(0).Item("").ToString
                        .Fields("ChargeAbleWeight").Value = Me.txtChargeAbleWeight.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                        ''' '---------------- 
                        .Fields("pkgs").Value = Me.txtPackages.Text
                        '-------------------------------container


                        '-----------
                        '-------------------
                        .Fields("nodebit").Value = Me.txtNoDebit.Text

                        .Fields("nocredit").Value = Me.txtNoCredit.Text






                        ''' '------------------
                        ' them CO
                        .Fields("co5").Value = Me.txtco1.Text
                        .Fields("co6").Value = Me.txtco2.Text
                        .Fields("co7").Value = Me.txtco3.Text
                        .Fields("co8").Value = Me.txtco4.Text
                        .Fields("co9").Value = Me.txtco5.Text
                        .Fields("co10").Value = Me.txtco6.Text
                        .Fields("co11").Value = Me.txtco7.Text
                        .Fields("co12").Value = Me.txtco8.Text
                        .Fields("CoissuedIN").Value = Me.txtcoIssuedIn.Text

                        .Fields("mau").Value = Me.cbocfrColor.BackColor.ToArgb

                        '0------------------------


                        Try


                            .Fields("customerid_showtc").Value = "{" + FindValueID(Me.cboCustomer, Me.cboCustomer.Text) + "}"

                        Catch ex As Exception
                            .Fields("customerid_showtc").Value = DefaultValue
                        End Try
                        'them FCR
                        Try
                            .Fields("shipper_FCR").Value = Me.txtshipper_FCR.Text

                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("consignee_FCR").Value = Me.txtConsignee_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("notify_FCR").Value = Me.txtNotify_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("REF_FCR").Value = Me.TXTREF_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("Date_FCR").Value = Me.txtDate_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("POR_FCR").Value = Me.txtPOR_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("PODEL_FCR").Value = Me.TXTPODEL_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("Pkgs_FCR").Value = Me.txtPkgs_FCR.Text

                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("GW_FCR").Value = Me.txtGW_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("CBM_FCR").Value = Me.txtCBM_FCR.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("description_FRC").Value = Me.txtdescription_FRC.Text

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("shippingMarks_FCR").Value = Me.txtshippingMarks_FCR.Text

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("remarks_FCR").Value = Me.txtshippingMarks_FCR.Text

                        Catch ex As Exception

                        End Try
                        ''-------------- other agent
                        '.Fields("OtherDebit1").Value = Me.OtherDebit1.Text
                        '.Fields("OtherDebit2").Value = Me.OtherDebit2.Text

                        '.Fields("OtherDebit3").Value = Me.OtherDebit3.Text
                        '.Fields("OtherDebit4").Value = Me.OtherDebit4.Text
                        '.Fields("OtherDebit5").Value = Me.OtherDebit5.Text
                        '.Fields("OtherDebit6").Value = Me.OtherDebit6.Text
                        '.Fields("OtherDebit7").Value = Me.OtherDebit7.Text
                        '.Fields("OtherDebit8").Value = Me.OtherDebit8.Text
                        '.Fields("OtherDebit9").Value = Me.OtherDebit9.Text
                        '.Fields("OtherDebit10").Value = Me.OtherDebit10.Text
                        '.Fields("OtherDebit11").Value = Me.OtherDebit11.Text
                        '.Fields("OtherDebit12").Value = Me.OtherDebit12.Text


                        ''----------------------------------------------------'-------------- other agent
                        'Try
                        '    .Fields("OtherDebit1").Value = Me.OtherDebit1.Text
                        '    .Fields("OtherDebit2").Value = Me.OtherDebit2.Text

                        '    .Fields("OtherDebit3").Value = Me.OtherDebit3.Text
                        '    .Fields("OtherDebit4").Value = Me.OtherDebit4.Text
                        '    .Fields("OtherDebit5").Value = Me.OtherDebit5.Text
                        '    .Fields("OtherDebit6").Value = Me.OtherDebit6.Text
                        '    .Fields("OtherDebit7").Value = Me.OtherDebit7.Text
                        '    .Fields("OtherDebit8").Value = Me.OtherDebit8.Text
                        '    .Fields("OtherDebit9").Value = Me.OtherDebit9.Text
                        '    .Fields("OtherDebit10").Value = Me.OtherDebit10.Text
                        '    .Fields("OtherDebit11").Value = Me.OtherDebit11.Text
                        '    .Fields("OtherDebit12").Value = Me.OtherDebit12.Text
                        'Catch ex As Exception

                        'End Try

                        '.Fields("nhom").Value = gNhom

                        '----------------------------------------------------
                        .Update()
                    End With
                    rs.Close()
                    '===================================================================
                    'Dim cmd1 As New ADODB.Command
                    'Dim strconn1, strServer1, strUserName1, strPassword1, strDatabase1 As String
                    'strServer1 = "vietnamforwarder.com"
                    'strUserName1 = "admin"
                    'strPassword1 = "qwe123!@#"
                    'strDatabase1 = "smf"
                    'strconn1 = "Provider=sqloledb;Data Source='" & strServer1 & "'; User ID='" & strUserName1 & "'; password='" & strPassword1 & "'; Initial Catalog='" & strDatabase1 & "'"
                    'Try
                    '    strQuery = "SELECT * "
                    '    strQuery = strQuery & "FROM trackingsea "
                    '    strQuery = strQuery & "WHERE MBL = '" & Me.txtMBLCarrier.Text & "' and HBL='" & Me.txtMBLMAWB.Text & "'  "
                    '    rs.Open(strQuery, strconn1, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    '    With rs
                    '        'If Not rs.EOF Then
                    '        '    rs.MoveFirst()
                    '        'End If

                    '        'While Not rs.EOF


                    '        If rs.EOF Then
                    '            .AddNew()
                    '            .Fields("trackingseaID").Value = NewId()

                    '            'strCarrierId = .Fields("BLOB_ID").Value
                    '            .Fields("mbl").Value = Me.txtMBLCarrier.Text
                    '            .Fields("hbl").Value = Me.txtMBLMAWB.Text
                    '            .Fields("eta").Value = Me.txteta.Text
                    '            .Fields("etd").Value = Me.txtetd.Text
                    '            .Fields("inbound").Value = "0"
                    '            .Fields("customer").Value = "SITC"
                    '            .Fields("ngayps").Value = Me.txtetd.Text
                    '            .Fields("shipper").Value = Me.txtShipper.Text
                    '            .Fields("consignee").Value = Me.txtConsignee.Text
                    '            .Fields("carrier").Value = Me.cboCarrier.Text
                    '            .Fields("noidung").Value = "POL/ETD : " + Me.txtPOL.Text + "/" + Me.txtetd.Text + "<br>" + "POD/ETA : " + Me.txtPOD.Text + "/" + Me.txteta.Text  ' lay etd,eta, pol, pod

                    '            '.Fields("trackingdate").Value = Getdate()
                    '            .Update()
                    '            'rs.MoveNext()
                    '            'rs.MoveNext()
                    '        Else
                    '            .Fields("eta").Value = Me.txteta.Text
                    '            .Fields("etd").Value = Me.txtetd.Text
                    '            .Fields("ngayps").Value = Me.txtetd.Text
                    '            .Fields("shipper").Value = Me.txtShipper.Text
                    '            .Fields("consignee").Value = Me.txtConsignee.Text
                    '            .Fields("carrier").Value = Me.cboCarrier.Text
                    '            .Update()
                    '            ' rs.MoveNext()
                    '        End If
                    '        ' End While
                    '    End With
                    '    'cmd1.let_ActiveConnection(strconn1)
                    '    'cmd1.CommandText = "INSERT into trackingsea"
                    '    'cmd1.CommandText = cmd1.CommandText & "(mbl,hbl,inbound,carrier,customer,ngayps,shipper,consignee,etd,eta) "
                    '    'cmd1.CommandText = cmd1.CommandText & "VALUES ('" & Me.txtMBLCarrier.Text & "','" & Me.txtMBLMAWB.Text & "','0','" & Me.cboCarrier.Text & "','SITC','" & Me.txtetd.Text & "','" & Me.txtShipper.Text & "','" & Me.txtConsignee.Text & "','" & Me.txtetd.Text & "','" & Me.txteta.Text & "') "
                    '    ''Debug.Print cmd.CommandText
                    '    'cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    'Catch ex As Exception
                    '    'DisplayMessage(True, Err.Description)
                    'End Try
                    '============================================================================
                    Me.dgdHBL.Enabled = True
                    'fraUpdate chỉ visible khi thêm hay sửa thành công
                    Me.TabControl1.Visible = False
                    ReFormat()

                    'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
                    mFilter = " and ref ='" & Me.txtRef.Text & "' "
                    QueryPort(mFilter, , index)
                    mStatus = "Normal"
                    Me.cmdOK.Enabled = False
                    Me.cmdOKAll.Enabled = False
                    reText(mStatus)
                    blnUpdated = True
                    Me.TabControl1.Enabled = False

                End If


                'Me.Close()
                Dim cmd As New ADODB.Command
                Try
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "delete from billonline where id= '" & mOutboundID & "' and userupdate='" & strUserId & "'"

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
        Try
            ' Me.Button24.Visible = True
            ' set cho TICO
            Me.Text = gtext

            ' Me.GroupBox9.Visible = gStatus
            Me.GroupBox18.Visible = Me.chkRF.Checked
            '------------------------------
            SI()
            Try
                mainCube = New _DCubeNoGimbalLock.Math3D.Cube(100, 200, 75)
                drawOrigin = New Point(PictureBox1.Width / 2, PictureBox1.Height / 2)
            Catch ex As Exception

            End Try
            Me.ButtonX1.Enabled = False
            Me.cmdOKHinh.Enabled = False
            mStatus = "Normal"
            mStatusHinh = "Normal"
            mStatusContainer = "Normal"
            mStatuspackage = "Normal"
            '--------------------------200813
            mStatusDebit = "Normal"
            mStatusCredit = "Normal"
            '-----------------------------------
            mStatusTheodoi = "Normal"
            mTheodoiid = DefaultValue
            '--------------------------------------------
            '================================
            mStatusCashLoan = "Normal"
            mCashLoanID = DefaultValue
            '=============================================
            Me.Button20.Visible = True
            blnUpdated = False
            SetDefaultGrid(Me.dgdHBL, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            mOutboundID = DefaultValue
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'Me.fraUpdate.Visible = False
            'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
            'LoadComboFind(Me.cboFind, Me.dgdPort)
            mID = DefaultValue
            QueryCombo()
            QueryUserReport()
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
            Me.BackColor = gMaunen
            Me.TabControl1.BackColor = gMauFra
            Me.TabPage1.BackColor = gMauFra

            Me.Containers.BackColor = gMauFra
            '  Me.TabPage4.BackColor = gMauFra
            'Me.TabPage5.BackColor = gMauFra
            Me.TabPage6.BackColor = gMauFra
            'If UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "ACCOUNT" Then
            '    Me.TabPage3.Text = "Credit (Administrator)"
            '    Me.TabPage8.Text = "Credit (sale)"
            '    Me.chkClockCredit.Visible = True
            '    ' EnableControl(True)
            'Else
            '    Me.TabPage3.Text = "..."
            '    Me.TabPage8.Text = "Credit (sale)"
            '    Me.chkClockCredit.Visible = False
            '' '' '' ''If UCase(gDepartment) = "DOCUMENT" Or UCase(gDepartment) = "OPERATION" Then
            '' '' '' ''    Me.TabPage3.Text = "Credit (Administrator)"
            '' '' '' ''    Me.TabPage6.Text = "Credit (sale)"
            '' '' '' ''    Me.chkClockCredit.Visible = True
            '' '' '' ''    EnableControl(False)
            '' '' '' ''Else
            '' '' '' ''    Me.TabPage3.Text = "..."
            '' '' '' ''    Me.TabPage6.Text = "Credit (sale)"
            '' '' '' ''    Me.chkClockCredit.Visible = False
            '' '' '' ''    EnableControl(True)
            '' '' '' ''End If
            'End If
            '------------
            'If UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "ACCOUNT" Then

            '    Me.txttaxmd.Width = 62
            '    Me.txttaxmd1.Width = 62
            '    Me.txttaxduthieu.Width = 62
            '    Me.txttaxduthieu1.Width = 62
            '    ' Me.txtcomsale.Width = 62
            '    txtPricetruComCus.Width = 62
            '    txtPricetruComCus1.Width = 62

            '    Me.txtcongty.Width = 62
            '    Me.txtcongty1.Width = 62

            '    Me.Label165.Visible = True
            '    Me.Label213.Visible = True

            '    Me.Label156.Visible = True
            '    Me.Label223.Visible = True

            '    Me.Label155.Visible = True

            '    Me.Label222.Visible = True

            '    ' Me.Label151.Visible = True
            '    Me.Label152.Visible = True
            '    Me.Label215.Visible = True

            'Else
            '    Me.txttaxmd.Width = 0
            '    Me.txttaxmd1.Width = 0
            '    Me.txttaxduthieu.Width = 0
            '    Me.txttaxduthieu1.Width = 0
            '    ' Me.txtcomsale.Width = 62
            '    txtPricetruComCus.Width = 0
            '    txtPricetruComCus1.Width = 0

            '    Me.txtcongty.Width = 0
            '    Me.txtcongty1.Width = 0

            '    Me.Label165.Visible = False
            '    Me.Label213.Visible = False
            '    Me.Label156.Visible = False
            '    Me.Label223.Visible = False

            '    Me.Label155.Visible = False

            '    Me.Label222.Visible = False

            '    ' Me.Label151.Visible = True
            '    Me.Label152.Visible = False
            '    Me.Label215.Visible = False



            'End If

            '------------------------
            Me.cmdCancel_Click(eventSender, eventArgs)
            '-------------



        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Sub EnableControl(ByVal Value As Boolean)
        Try
            Dim ctr As Control
            For Each ctr In Me.TabPage14.Controls ' DEBIT
                ctr.Visible = Value
            Next
            For Each ctr In Me.TabPage15.Controls ' CREDIT
                ctr.Visible = Value
            Next
            For Each ctr In Me.TabPage8.Controls ' CREDIT
                ctr.Visible = Value
            Next
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
        ' sql = " select BLOB_ID,REF,MBL,HBL,shipper,consignee,notify,approve,editable,continued,userupdate ,DateUpdate  from inbound where mbl='" & Me.cboMBL.Text & "' order by dateupdate desc "
        If UCase(gDepartment) = "SALE" Then
            MakeQueryPort = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC "
            ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
            MakeQueryPort = MakeQueryPort & " FROM Outbound "
            MakeQueryPort = MakeQueryPort & "WHERE  " ' (ref = '" & Me.cboMBLCarrier.Text & "')

            'MakeQueryPort = MakeQueryPort & "OR ("
            MakeQueryPort = MakeQueryPort & " (Continued = 1) and (salecode='" & gSaleCode & "') and (branch like '%" & gBranch & "%')  and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' )  "
            'MakeQueryPort = MakeQueryPort & ") "
            If Not IsNothing(argCriteria) And argCriteria.Trim <> "" Then
                MakeQueryPort = MakeQueryPort & argCriteria
            End If
            MakeQueryPort = MakeQueryPort + "order by dateupdate desc "
        Else
            If UCase(gDepartment) = "CUSTOMER" Or UCase(gDepartment) = "DOCUMENT" Then
                MakeQueryPort = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC "
                ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                MakeQueryPort = MakeQueryPort & " FROM Outbound "
                MakeQueryPort = MakeQueryPort & "WHERE  " ' (ref = '" & Me.cboMBLCarrier.Text & "')

                'MakeQueryPort = MakeQueryPort & "OR ("
                MakeQueryPort = MakeQueryPort & " (Continued = 1) and (branch like '%" & gBranch & "%') and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' )   "
                'MakeQueryPort = MakeQueryPort & ") "
                If Not IsNothing(argCriteria) And argCriteria.Trim <> "" Then
                    MakeQueryPort = MakeQueryPort & argCriteria
                End If
                MakeQueryPort = MakeQueryPort + "order by dateupdate desc "
            Else
                MakeQueryPort = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC "
                ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                MakeQueryPort = MakeQueryPort & " FROM Outbound "
                MakeQueryPort = MakeQueryPort & "WHERE  " ' (ref = '" & Me.cboMBLCarrier.Text & "')

                'MakeQueryPort = MakeQueryPort & "OR ("
                MakeQueryPort = MakeQueryPort & " (Continued = 1)  and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' )  " 'and (branch like '%" & gBranch & "%') 
                'MakeQueryPort = MakeQueryPort & ") "
                If Not IsNothing(argCriteria) And argCriteria.Trim <> "" Then
                    MakeQueryPort = MakeQueryPort & argCriteria
                End If
                MakeQueryPort = MakeQueryPort + "order by dateupdate desc "
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
    '        If mStatus = "Normal" And UserRight("mnuOutbound", "Add") Then
    '            'Me.txtServicename.Enabled = True
    '            Me.dgdPort.Enabled = False
    '            Me.fraUpdate.Visible = True
    '            ReFormat()
    '            SetMenu((False))
    '            mOutboundID = DefaultValue
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
    '        'If Not Me.dgdPort.Item("Editable", index).Value Or Not UserRight("mnuOutbound", "Approve") Then
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
            Me.Text = gtext
        ElseIf mStatus = "Edit" Then
            Me.Text = gtext + " -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = gtext + " -> Add."
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
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "PortList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdHBL.DataSource = ds.Tables("PortList")
        If Me.dgdHBL.Enabled = False Then
            Me.dgdHBL.Enabled = True
        End If
        '------------vị trí BM
        vitri = 0
        'If vitri >= 0 And vitri <= Me.dgdHBL.Rows.Count And Me.dgdHBL.Rows.Count > 0 Then
        '    Me.dgdHBL.Rows(vitri).Selected = True
        '    Me.dgdHBL.CurrentCell = Me.dgdHBL.Rows(vitri).Cells(2)
        'End If
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

        'Resume
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
            sql = " select * from oUTbound where BLOB_ID='" & mOutboundID & "' and continued=1"

            ds = ReadDataSet(sql)
            '    lay tong teu.tongcbm
            Try
                Me.txtlot.Text = ds.Tables(0).Rows(0).Item("lot").ToString


            Catch ex As Exception

            End Try
            Try
                Me.txtshipperOther.Text = ds.Tables(0).Rows(0).Item("shipperOther").ToString


            Catch ex As Exception

            End Try


            Try
                Me.txtconsigneeOther.Text = ds.Tables(0).Rows(0).Item("consigneeOther").ToString


            Catch ex As Exception

            End Try


            Try
                Me.txtnotifyOther.Text = ds.Tables(0).Rows(0).Item("notifyOther").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtAgencyNameOther.Text = ds.Tables(0).Rows(0).Item("agencynameOther").ToString


            Catch ex As Exception

            End Try


            Try
                Me.txtagencyNameSI.Text = ds.Tables(0).Rows(0).Item("agencynamesi").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtMVessel.Text = ds.Tables(0).Rows(0).Item("mvessel").ToString


            Catch ex As Exception

            End Try

            'Try
            '    Me.cbooRef.Text = ds.Tables(0).Rows(0).Item("oref").ToString

            'Catch ex As Exception

            'End Try
            Try
                Me.txtMVoy.Text = ds.Tables(0).Rows(0).Item("mvoy").ToString


            Catch ex As Exception

            End Try


            Try
                Me.txtquotation.Text = ds.Tables(0).Rows(0).Item("quotationNo").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtngayhabai.Text = ds.Tables(0).Rows(0).Item("ngayhabai").ToString


            Catch ex As Exception

            End Try
            Try
                Me.cbotransit.Text = ds.Tables(0).Rows(0).Item("transit").ToString


            Catch ex As Exception

            End Try
            Try
                Me.chksoccoc.Checked = ds.Tables(0).Rows(0).Item("NVOCC").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txtoprcode.Text = ds.Tables(0).Rows(0).Item("oprcode").ToString


            Catch ex As Exception

            End Try

            Try
                Me.txttongteu.Text = ds.Tables(0).Rows(0).Item("tongteu").ToString

                Me.txttongcbm.Text = ds.Tables(0).Rows(0).Item("tongcbm").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtngayHTTTHQ.Text = ds.Tables(0).Rows(0).Item("ngayhttthq").ToString
            Catch ex As Exception

            End Try
            Try
                Me.dtp_closing.Value = ds.Tables(0).Rows(0).Item("closing").ToString
            Catch ex As Exception

            End Try
            Try
                Me.dtp_cargo_ready.Value = ds.Tables(0).Rows(0).Item("cargo_ready").ToString
            Catch ex As Exception

            End Try

            '-----------------------------
            ' booking
            '.Fields("cboBookingOffice").Value = Me..Text
            '.Fields("txtcontactperson").Value = Me.txtcontactperson.Text
            '.Fields("CustomerID").Value = "{" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "}"
            '.Fields("cboRepresentative").Value = Me.cboRepresentative.Text
            '.Fields("txtgmd_placeofstuffing").Value = Me.txtgmd_placeofstuffing.Text
            '.Fields("dtpBookingdate").Value = Me.dtpBookingdate.Text
            '.Fields("TXTTRANSHIPMENTPORT").Value = Me.TXTTRANSHIPMENTPORT.Text
            '.Fields("TXTCUTOFFTIME").Value = Me.TXTCUTOFFTIME.Text
            '.Fields("TXTCUTOFFcargo").Value = Me.TXTCUTOFFCARGO.Text
            '.Fields("TXTCUTOFFsi").Value = Me.TXTCUTOFFSI.Text
            '.Fields("txtthongtinlienhe").Value = Me.txtthongtinlienhe.Text
            '.Fields("TXTTYPE").Value = Me.TXTTYPE.Text
            '.Fields("txtgmd_noofcontainerorpackage").Value = Me.txtgmd_noofcontainerorpackage.Text
            '.Fields("TXTgmd_gw").Value = Me.TXTgmd_gw.Text
            '.Fields("TXTgmd_cbm").Value = Me.TXTgmd_cbm.Text




            '------otherdebit agent
            Me.CHKrf.Checked = ds.Tables(0).Rows(0).Item("rf").ToString
            Me.OtherDebit1.Text = ds.Tables(0).Rows(0).Item("OtherDebit1").ToString
            Me.OtherDebit2.Text = ds.Tables(0).Rows(0).Item("OtherDebit2").ToString
            Me.OtherDebit3.Text = ds.Tables(0).Rows(0).Item("OtherDebit3").ToString
            Me.OtherDebit4.Text = ds.Tables(0).Rows(0).Item("OtherDebit4").ToString

            Me.OtherDebit5.Text = ds.Tables(0).Rows(0).Item("OtherDebit5").ToString

            Me.OtherDebit6.Text = ds.Tables(0).Rows(0).Item("OtherDebit6").ToString
            Me.OtherDebit7.Text = ds.Tables(0).Rows(0).Item("OtherDebit7").ToString
            Me.OtherDebit8.Text = ds.Tables(0).Rows(0).Item("OtherDebit8").ToString

            Me.OtherDebit9.Text = ds.Tables(0).Rows(0).Item("OtherDebit9").ToString
            Me.OtherDebit10.Text = ds.Tables(0).Rows(0).Item("OtherDebit10").ToString
            Me.OtherDebit11.Text = ds.Tables(0).Rows(0).Item("OtherDebit11").ToString
            Me.OtherDebit12.Text = ds.Tables(0).Rows(0).Item("OtherDebit12").ToString
            '---------------
            'them FCR
            Try
                Me.txtshipper_FCR.Text = ds.Tables(0).Rows(0).Item("shipper_FCR").ToString

            Catch ex As Exception

            End Try


            Try
                Me.txtConsignee_FCR.Text = ds.Tables(0).Rows(0).Item("consignee_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtNotify_FCR.Text = ds.Tables(0).Rows(0).Item("notify_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.TXTREF_FCR.Text = ds.Tables(0).Rows(0).Item("REF_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtDate_FCR.Text = ds.Tables(0).Rows(0).Item("Date_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtPOR_FCR.Text = ds.Tables(0).Rows(0).Item("POR_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.TXTPODEL_FCR.Text = ds.Tables(0).Rows(0).Item("PODEL_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtPkgs_FCR.Text = ds.Tables(0).Rows(0).Item("Pkgs_FCR").ToString

            Catch ex As Exception

            End Try


            Try
                Me.txtGW_FCR.Text = ds.Tables(0).Rows(0).Item("GW_FCR").Value

            Catch ex As Exception

            End Try

            Try
                Me.txtCBM_FCR.Text = ds.Tables(0).Rows(0).Item("CBM_FCR").ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtdescription_FRC.Text = ds.Tables(0).Rows(0).Item("description_FRC").ToString

            Catch ex As Exception

            End Try

            Try
                Me.txtshippingMarks_FCR.Text = ds.Tables(0).Rows(0).Item("shippingMarks_FCR").ToString

            Catch ex As Exception

            End Try
            Try
                Me.txtshippingMarks_FCR.Text = ds.Tables(0).Rows(0).Item("remarks_FCR").ToString

            Catch ex As Exception

            End Try








            Try
                Me.cboCustomer.Text = FindIDValue(Me.cboCustomer, ds.Tables(0).Rows(0).Item("customerid_showtc").ToString)
            Catch ex As Exception

            End Try
            '----------------------
            Try
                Me.TXTInvoiceRequestDate.Text = ds.Tables(0).Rows(0).Item("InvoiceRequestDate").ToString
            Catch ex As Exception

            End Try
            Try
                Me.CBOStatus.Text = ds.Tables(0).Rows(0).Item("status").ToString
            Catch ex As Exception

            End Try
            ' ngay 30-jun-2014
            Try
                Me.cboagent.Text = FindIDValue(Me.cboagent, ds.Tables(0).Rows(0).Item("agentid").ToString)
            Catch ex As Exception

            End Try
            Try
                Me.cbopodcode.Text = ds.Tables(0).Rows(0).Item("podcode").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtcbmForCom.Text = ds.Tables(0).Rows(0).Item("cbmforcom").ToString
            Catch ex As Exception

            End Try
            Try
                Me.cboops.Text = ds.Tables(0).Rows(0).Item("ops").ToString
            Catch ex As Exception

            End Try
            Try
                Me.cbopolcode.Text = ds.Tables(0).Rows(0).Item("polcode").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtrevenueTons.Text = ds.Tables(0).Rows(0).Item("revenueTons").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txttotalprepaidIn.Text = ds.Tables(0).Rows(0).Item("totalprepaidIn").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txtprepaidAt.Text = ds.Tables(0).Rows(0).Item("prepaidAt").ToString
            Catch ex As Exception

            End Try

            '--------22-jun
            Try
                Me.dtpDateReport.Value = ds.Tables(0).Rows(0).Item("datereport").ToString
            Catch ex As Exception

            End Try
            Try
                Me.txttkhq.Text = ds.Tables(0).Rows(0).Item("tkhq").ToString
            Catch ex As Exception
                Me.txttkhq.Text = ""
            End Try

            '-------------------------
            Try
                Me.cboitemSITC.Text = ds.Tables(0).Rows(0).Item("itemsiTc").ToString
            Catch ex As Exception

            End Try
            Me.txtNoDebit.Text = ds.Tables(0).Rows(0).Item("nodebit").ToString
            Me.txtNoCredit.Text = ds.Tables(0).Rows(0).Item("nocredit").ToString

            ' them tong
            Me.txttongsoluong.Text = ds.Tables(0).Rows(0).Item("tongsoluong").ToString
            Me.txttongsoluong1.Text = ds.Tables(0).Rows(0).Item("tongsoluong1").ToString
            Me.txttongsoluong2.Text = ds.Tables(0).Rows(0).Item("tongsoluong2").ToString



            Me.loai.Text = ds.Tables(0).Rows(0).Item("loai").ToString
            Me.loai1.Text = ds.Tables(0).Rows(0).Item("loai1").ToString
            Me.loai2.Text = ds.Tables(0).Rows(0).Item("loai2").ToString

            Me.tongkien.Text = ds.Tables(0).Rows(0).Item("tongkien").ToString
            Me.tongkg.Text = ds.Tables(0).Rows(0).Item("tongkg").ToString

            Me.tongkhoi.Text = ds.Tables(0).Rows(0).Item("tongkhoi").ToString


            ' hang Air
            '''----air

            Me.txtairIssuingCarrier.Text = ds.Tables(0).Rows(0).Item("airIssuingCarrier").ToString
            Me.txtairAgentIATACode.Text = ds.Tables(0).Rows(0).Item("airAgentIATACode").ToString
            Me.txtairAccountNo.Text = ds.Tables(0).Rows(0).Item("airAccountNo").ToString
            Me.txtAirTo1.Text = ds.Tables(0).Rows(0).Item("AirTo1").ToString
            Me.txtAirByFirstCarrier.Text = ds.Tables(0).Rows(0).Item("AirByFirstCarrier").ToString
            Me.txtAirto2.Text = ds.Tables(0).Rows(0).Item("Airto2").ToString
            Me.txtairby1.Text = ds.Tables(0).Rows(0).Item("airby1").ToString
            Me.txtairto3.Text = ds.Tables(0).Rows(0).Item("airto3").ToString
            Me.txtairby2.Text = ds.Tables(0).Rows(0).Item("airby2").ToString
            Me.txtairCHGSCode.Text = ds.Tables(0).Rows(0).Item("airCHGSCode").ToString
            Me.txtairDecCarrier.Text = ds.Tables(0).Rows(0).Item("airDecCarrier").ToString
            Me.txtAirDecCus.Text = ds.Tables(0).Rows(0).Item("AirDecCus").ToString
            Me.txtairAmountOfInsurance.Text = ds.Tables(0).Rows(0).Item("airAmountOfInsurance").ToString
            Me.txtairSCI.Text = ds.Tables(0).Rows(0).Item("airSCI").ToString
            Me.txtAirOtherPC.Text = ds.Tables(0).Rows(0).Item("AirOtherPC").ToString
            Me.txtFV2.Text = ds.Tables(0).Rows(0).Item("fv2").ToString

            Me.txtChargeAbleWeight.Text = ds.Tables(0).Rows(0).Item("ChargeAbleWeight").ToString



            ''' '----------------
            Me.txtAirportDeparture.Text = ds.Tables(0).Rows(0).Item("AirportDeparture").ToString
            Me.txtRefNumber.Text = ds.Tables(0).Rows(0).Item("RefNumber").ToString
            Try
                Me.txtCurrency.Text = ds.Tables(0).Rows(0).Item("currency_").ToString
            Catch ex As Exception

            End Try

            Me.txtPPD1.Text = ds.Tables(0).Rows(0).Item("ppd1").ToString
            Me.txtPPD2.Text = ds.Tables(0).Rows(0).Item("ppd2").ToString
            Me.txtCOLL2.Text = ds.Tables(0).Rows(0).Item("coll2").ToString
            Me.txtCOLL1.Text = ds.Tables(0).Rows(0).Item("coll1").ToString
            Me.txtAirPortDes.Text = ds.Tables(0).Rows(0).Item("AirPortDes").ToString
            Me.txtFV1.Text = ds.Tables(0).Rows(0).Item("fv1").ToString
            Me.txtFV2.Text = ds.Tables(0).Rows(0).Item("fv2").ToString
            Me.txtFD2.Text = ds.Tables(0).Rows(0).Item("fd2").ToString
            Me.txtFD1.Text = ds.Tables(0).Rows(0).Item("fd1").ToString
            Me.txtHandling.Text = ds.Tables(0).Rows(0).Item("Handling").ToString
            Me.txtRCP.Text = ds.Tables(0).Rows(0).Item("rcp").ToString
            Me.txtGW.Text = ds.Tables(0).Rows(0).Item("gw").ToString
            Me.txtCommodity.Text = ds.Tables(0).Rows(0).Item("commondity").ToString
            Me.txtChargeAbleWeight.Text = ds.Tables(0).Rows(0).Item("airChargeAbleWeight").ToString


            ' Me.txttigia.Text = ds.Tables(0).Rows(0).Item("tigia").ToString



            Me.txtRateCharge.Text = ds.Tables(0).Rows(0).Item("RateCharge").ToString
            Me.txtTotal.Text = ds.Tables(0).Rows(0).Item("total").ToString
            Me.txtNature.Text = ds.Tables(0).Rows(0).Item("nature").ToString
            Me.txtWCPrepaid.Text = ds.Tables(0).Rows(0).Item("wcprepaid").ToString
            Me.txtWCCollect.Text = ds.Tables(0).Rows(0).Item("wccollect").ToString
            Me.txtVPrepaid.Text = ds.Tables(0).Rows(0).Item("vprepaid").ToString
            Me.txtVCollect.Text = ds.Tables(0).Rows(0).Item("vcollect").ToString

            Me.txtTotalPrepaid.Text = ds.Tables(0).Rows(0).Item("Totalprepaid").ToString
            Me.txtTotalCollect.Text = ds.Tables(0).Rows(0).Item("Totalcollect").ToString


            Me.txtTaxPrepaid.Text = ds.Tables(0).Rows(0).Item("taxprepaid").ToString
            Me.txtTaxCollect.Text = ds.Tables(0).Rows(0).Item("taxcollect").ToString

            Me.txtTotalAgentPrepaid.Text = ds.Tables(0).Rows(0).Item("TotalAgentPrepaid").ToString
            Me.txtTotalAgentCollect.Text = ds.Tables(0).Rows(0).Item("TotalAgentCollect").ToString

            Me.txtTotalCarrierPrepaid.Text = ds.Tables(0).Rows(0).Item("TotalCarrierPrepaid").ToString
            Me.txtTotalCarrierCollect.Text = ds.Tables(0).Rows(0).Item("TotalCarrierCollect").ToString

            Me.txtCurrRates.Text = ds.Tables(0).Rows(0).Item("CurrRates").ToString
            Me.txtChargesDest.Text = ds.Tables(0).Rows(0).Item("ChargesDest").ToString

            Me.txtDatePlace.Text = ds.Tables(0).Rows(0).Item("DatePlace").ToString
            Me.txtHisAgent.Text = ds.Tables(0).Rows(0).Item("hisagent").ToString

            '------------------------------------
            Me.chkfcl.Checked = ds.Tables(0).Rows(0).Item("FCL").ToString
            Me.chklcl.Checked = ds.Tables(0).Rows(0).Item("LCL").ToString
            Me.chkconsol.Checked = ds.Tables(0).Rows(0).Item("Consol").ToString
            ' Me.chkClockCredit.Checked = ds.Tables(0).Rows(0).Item("clockcredit").ToString
            Me.chkair.Checked = ds.Tables(0).Rows(0).Item("air").ToString
            Me.txtMBLCarrier.Text = ds.Tables(0).Rows(0).Item("MBLCarrier").ToString

            Me.txtManifest.Text = ds.Tables(0).Rows(0).Item("ManifestDate").ToString
            Me.txtSentHPG.Text = ds.Tables(0).Rows(0).Item("sentHPGDate").ToString
            Me.chkClose.Checked = ds.Tables(0).Rows(0).Item("closeFile").ToString

            Me.chkNhanlenh.Checked = ds.Tables(0).Rows(0).Item("nhanlenh").ToString
            Me.txtNgayNhanlenh.Text = ds.Tables(0).Rows(0).Item("ngaynhanlenh").ToString
            Me.txtNguoinhanlenh.Text = ds.Tables(0).Rows(0).Item("nguoinhanlenh").ToString

            Me.txtMBLMAWB.Text = ds.Tables(0).Rows(0).Item("MBLMAWB").ToString
            Me.txtHBLHAWB.Text = ds.Tables(0).Rows(0).Item("HBLhAWB").ToString
            Me.txtBKNo.Text = ds.Tables(0).Rows(0).Item("bkno").ToString

            Me.txtRef.Text = ds.Tables(0).Rows(0).Item("ref").ToString
            Me.txtCYCFS.Text = ds.Tables(0).Rows(0).Item("CY_CFS_ITEM").ToString
            Me.txtBL_Type.Text = ds.Tables(0).Rows(0).Item("bl_type").ToString

            Me.txtVessel.Text = ds.Tables(0).Rows(0).Item("vessel").ToString
            Me.txtVoyage.Text = ds.Tables(0).Rows(0).Item("voyage").ToString
            Me.txteta.Text = ds.Tables(0).Rows(0).Item("ETA").ToString

            Me.txtetd.Text = ds.Tables(0).Rows(0).Item("SAILINGDATE").ToString
            Me.txtPOL.Text = ds.Tables(0).Rows(0).Item("pol").ToString
            Me.txtPOR.Text = ds.Tables(0).Rows(0).Item("poR").ToString


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
            Me.txtSayContainer.Text = ds.Tables(0).Rows(0).Item("saycontainer").ToString
            Me.txtShippingMarks.Text = ds.Tables(0).Rows(0).Item("ShippingMARKS").ToString
            Me.txtDescription.Text = ds.Tables(0).Rows(0).Item("DESCRIPTION").ToString
            '---------------
            Me.txtFreightAmount.Text = ds.Tables(0).Rows(0).Item("freightAmount").ToString
            Me.txtFreightAmountSI.Text = ds.Tables(0).Rows(0).Item("freightAmountSI").ToString
            Me.txtFreightPayableAt.Text = ds.Tables(0).Rows(0).Item("FreightPayableAt").ToString

            Me.txtNumberOfOriginal.Text = ds.Tables(0).Rows(0).Item("NumberOfOriginal").ToString
            Me.txtPlaceAndDate.Text = ds.Tables(0).Rows(0).Item("placeanddate").ToString
            '--------------
            Me.txtPP.Text = ds.Tables(0).Rows(0).Item("Prepaid").ToString
            Me.txtCC.Text = ds.Tables(0).Rows(0).Item("Collect").ToString
            Me.txtOnboardDate.Text = ds.Tables(0).Rows(0).Item("OnboardDate").ToString
            Me.txtShipperRef.Text = ds.Tables(0).Rows(0).Item("shipperRef").ToString
            '-------------------------- 
            Me.txtRemarks.Text = ds.Tables(0).Rows(0).Item("remarks").ToString
            Me.txtPaidReceived.Text = ds.Tables(0).Rows(0).Item("PaidReceived").ToString




            Me.txtPackages.Text = ds.Tables(0).Rows(0).Item("pkgs").ToString
            ''-------------------------------container
            ''' '------------------


            Me.txtco1.Text = ds.Tables(0).Rows(0).Item("co5").ToString
            Me.txtco2.Text = ds.Tables(0).Rows(0).Item("co6").ToString
            Me.txtco3.Text = ds.Tables(0).Rows(0).Item("co7").ToString
            Me.txtco4.Text = ds.Tables(0).Rows(0).Item("co8").ToString

            Me.txtco5.Text = ds.Tables(0).Rows(0).Item("co9").ToString

            Me.txtco6.Text = ds.Tables(0).Rows(0).Item("co10").ToString

            Me.txtco7.Text = ds.Tables(0).Rows(0).Item("co11").ToString

            Me.txtco8.Text = ds.Tables(0).Rows(0).Item("co12").ToString
            Me.txtcoIssuedIn.Text = ds.Tables(0).Rows(0).Item("CoissuedIN").ToString

            'Try
            '    Me.cbocfrColor.BackColor = Color.FromArgb(CInt(ds.Tables(0).Rows(0).Item("mau").ToString))
            'Catch ex As Exception
            '    Me.cbocfrColor.BackColor = Color.Black
            'End Try

            'Me.txtShipper.ForeColor = Me.cbocfrColor.BackColor
            '0------------------------
            'Me.cboBookingOffice.Text = ds.Tables(0).Rows(0).Item("cboBookingOffice").ToString
            'Me.txtcontactperson.Text = ds.Tables(0).Rows(0).Item("txtcontactperson").ToString
            'Me.cboCompany.Text = FindIDValue(Me.cboCompany, ds.Tables(0).Rows(0).Item("CustomerID").ToString)
            'Me.cboRepresentative.Text = ds.Tables(0).Rows(0).Item("cboRepresentative").ToString
            'Me.txtgmd_placeofstuffing.Text = ds.Tables(0).Rows(0).Item("txtgmd_placeofstuffing").ToString
            'Try
            '    Me.dtpBookingdate.Value = ds.Tables(0).Rows(0).Item("dtpBookingdate").ToString
            'Catch ex As Exception

            'End Try

            'Me.TXTTRANSHIPMENTPORT.Text = ds.Tables(0).Rows(0).Item("TXTTRANSHIPMENTPORT").ToString
            'Me.TXTCUTOFFTIME.Text = ds.Tables(0).Rows(0).Item("TXTCUTOFFTIME").ToString
            'Me.TXTCUTOFFCARGO.Text = ds.Tables(0).Rows(0).Item("TXTCUTOFFCARGO").ToString
            'Me.TXTCUTOFFSI.Text = ds.Tables(0).Rows(0).Item("TXTCUTOFFSI").ToString
            'Me.txtthongtinlienhe.Text = ds.Tables(0).Rows(0).Item("txtthongtinlienhe").ToString
            'Me.TXTTYPE.Text = ds.Tables(0).Rows(0).Item("TXTTYPE").ToString
            'Me.txtgmd_noofcontainerorpackage.Text = ds.Tables(0).Rows(0).Item("txtgmd_noofcontainerorpackage").ToString

            'Me.TXTgmd_gw.Text = ds.Tables(0).Rows(0).Item("TXTgmd_gw").ToString
            'Me.TXTgmd_cbm.Text = ds.Tables(0).Rows(0).Item("TXTgmd_cbm").ToString


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






    Private Sub txtPortCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UpdateOrverWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        'VB6.ShowForm(frmEditPortInfo, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    '-----port of loading
    Public Sub QueryPort(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_Code"
        value = "Port"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 Order By Port "
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


            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không
            Dim sqlkt As String
            Dim dskt As New DataSet

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
                If mStatus = "Normal" And EditTable And UserRight("mnuOutbound", "View") Then
                    'Me.dgdPort.Height = 306
                    'Me.dgdPort.Enabled = False
                    'Me.txtPortCode.Enabled = False
                    Me.TabControl1.Visible = True
                    ReFormat()
                    'SetMenu((False))

                    mOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

                    '' lay id de kiem tra
                    sqlkt = "select * from billonline where id='" & mOutboundID & "'"
                    dskt = ReadDataSet(sqlkt)
                    If dskt.Tables(0).Rows.Count > 0 Then
                        DisplayMessage(True, " Sorry,the proccess requires an access rigth to carry out, User:  " + dskt.Tables(0).Rows(0).Item("userupdate").ToString)
                        Exit Sub

                    End If
                    Me.TabControl1.Enabled = True
                    ' insertvao billonline
                    Dim strQuery As String
                    Dim rs As New ADODB.Recordset
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM billonline  "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("editid").Value = NewId()
                        .Fields("id").Value = "{" + mOutboundID + "}"
                        .Update()

                    End With
                    rs.Close()

                    '-------------------
                    mStatus = "View"
                    Me.cmdOK.Enabled = True
                    Me.cmdOKAll.Enabled = True
                    Me.dgdHBL.Enabled = False
                    '---------------------------
                    reText(mStatus)
                    RefreshData(index)
                    QueryHinhanh()
                    Querythemhinh()
                    QueryContainer()
                    Querydebit()
                    QueryCredit()
                    Querytheodoi()
                    QueryPackage()
                    showcontPack()
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
            profit()
            Button21_Click(sender, e)
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
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
        If Not UserRight("mnuOutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the : " & Me.dgdHBL.Item("MBLMAWB", index).Value.ToString
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
                cmd.CommandText = "delete from Outbound where BLOB_ID= '" & Me.dgdHBL.Item("BLOB_ID", index).Value.ToString & "' "

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


        Dim selectedRowCount As Integer =
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
            sql = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC  from Outbound where salecode='" & gSaleCode & "' and ref='" & Me.cboMBLCarrier.Text & "' and (branch like '%" & gBranch & "%')    order by dateupdate "
            ds = ReadDataSet(sql)
            Me.dgdHBL.DataSource = ds.Tables(0)
            mFilter = " and ref = '" & Me.cboMBLCarrier.Text & "' "
            InsertAutoNumberToGrid(Me.dgdHBL)
        Else
            sql = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC  from Outbound where ref='" & Me.cboMBLCarrier.Text & "'  order by dateupdate " 'and (branch like '%" & gBranch & "%')   
            ds = ReadDataSet(sql)
            Me.dgdHBL.DataSource = ds.Tables(0)
            mFilter = " and ref = '" & Me.cboMBLCarrier.Text & "' "
            InsertAutoNumberToGrid(Me.dgdHBL)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.txteta.Text = ddMMMyyyy(Me.dtpETA.Value.Date)
    End Sub

    Public Sub ApproveDebitNote()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not UserRight("mnuOutbound", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from outboundfreight where" + " outboundfreightid= '" & Me.dgddebitGrid.Item("outboundfreightid_debit", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveCreditNote()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not UserRight("mnuOutbound", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from outboundfreight where" + " outboundfreightid= '" & Me.dgdCreditGrid.Item("outboundfreightid_credit", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveIB()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not UserRight("mnuOutbound", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from outbound where" + " BLOB_ID= '" & Me.dgdHBL.Item("BLOB_ID", index).Value.ToString & "'"
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

        strQueryDetailBillOfLading_HouseList = "Select * from outbound where" + " BLOB_ID= '" & Me.dgdHBL.Item("BLOB_ID", index).Value.ToString & "'"
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

        strQueryDetailBillOfLading_HouseList = "Select * from outbound where" + " BLOB_ID= '" & Me.dgdHBL.Item("BLOB_ID", index).Value.ToString & "'"
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

        strQueryDetailBillOfLading_HouseList = "Select * from outbound where" + " BLOB_ID= '" & Me.dgdHBL.Item("BLOB_ID", index).Value.ToString & "'"
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

        strQueryDetailBillOfLading_HouseList = "Select * from outbound where" + " BLOB_ID= '" & Me.dgdHBL.Item("BLOB_ID", index).Value.ToString & "'"
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
            If Me.txtETA.Text = "" Or Me.txtETD.Text = "" Then
                DisplayMessage(True, "ETD, ETA ?")
                Exit Sub
            End If
            Dim sql, strMesg As String
            Dim ds As New DataSet
            If Me.txtETA.Text = "" Or Me.txtETD.Text = "" Then
                DisplayMessage(True, "ETD, ETA ?")
                Exit Sub
            End If
            sql = "select BLOB_ID from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' "
            ds = ReadDataSet(sql)
            strMesg = " Chú ý các Bill sẽ được copy dữ liệu. Bạn thật sự muốn làm ?"
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then


                If ds.Tables(0).Rows.Count > 0 Then

                    For i = 0 To ds.Tables(0).Rows.Count - 1


                        If (mStatus = "Add" Or mStatus = "Edit") Then
                            strQuery = "SELECT * "
                            strQuery = strQuery & "FROM Outbound "
                            strQuery = strQuery & "WHERE BLOB_ID = '" & ds.Tables(0).Rows(i).Item("BLOB_ID").ToString & "' and continued=1 "
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                If rs.EOF Then
                                    .AddNew()
                                    .Fields("BLOB_ID").Value = NewId()
                                End If
                                strCarrierId = .Fields("BLOB_ID").Value
                                ' them tong
                                .Fields("tongsoluong").Value = Me.txttongsoluong.Text
                                .Fields("tongsoluong1").Value = Me.txttongsoluong1.Text
                                .Fields("tongsoluong2").Value = Me.txttongsoluong2.Text
                                .Fields("loai").Value = Me.loai.Text
                                .Fields("loai1").Value = Me.loai1.Text
                                .Fields("loai2").Value = Me.loai2.Text
                                .Fields("tongkien").Value = Me.tongkien.Text
                                .Fields("tongkg").Value = Me.tongkg.Text
                                .Fields("tongkhoi").Value = Me.tongkhoi.Text

                                '-------------------
                                '--------22-jun
                                .Fields("tkhq").Value = Me.txttkhq.Text
                                '-------------------------


                                '---------------------
                                .Fields("AirportDeparture").Value = Me.txtAirportDeparture.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("RefNumber").Value = Me.txtRefNumber.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("currency").Value = Me.txtCurrency.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("ppd1").Value = Me.txtPPD1.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("ppd2").Value = Me.txtPPD2.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("coll2").Value = Me.txtCOLL2.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("coll1").Value = Me.txtCOLL1.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("AirPortDes").Value = Me.txtAirPortDes.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("fv1").Value = Me.txtFV1.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("fv2").Value = Me.txtFV2.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("fd2").Value = Me.txtFD2.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("fd1").Value = Me.txtFD1.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("Handling").Value = Me.txtHandling.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("rcp").Value = Me.txtRCP.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("gw").Value = Me.txtGW.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("commondity").Value = Me.txtCommodity.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airChargeAbleWeight").Value = Me.txtChargeAbleWeight.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                '---------------dimension
                                .Fields("dimension").Value = Me.txtdimension.Text
                                '------------------------------------
                                .Fields("RateCharge").Value = Me.txtRateCharge.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("total").Value = Me.txtTotal.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("nature").Value = Me.txtNature.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("wcprepaid").Value = Me.txtWCPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("wccollect").Value = Me.txtWCCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("vprepaid").Value = Me.txtVPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("vcollect").Value = Me.txtVCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("totalprepaid").Value = Me.txtTotalPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("Totalcollect").Value = Me.txtTotalCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("taxprepaid").Value = Me.txtTaxPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("taxcollect").Value = Me.txtTaxCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                                .Fields("TotalAgentPrepaid").Value = Me.txtTotalAgentPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("TotalAgentCollect").Value = Me.txtTotalAgentCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                                .Fields("TotalCarrierPrepaid").Value = Me.txtTotalCarrierPrepaid.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("TotalCarrierCollect").Value = Me.txtTotalCarrierCollect.Text '= ds.Tables(0).Rows(0).Item("").ToString

                                .Fields("CurrRates").Value = Me.txtCurrRates.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("ChargesDest").Value = Me.txtChargesDest.Text '= ds.Tables(0).Rows(0).Item("").ToString

                                .Fields("DatePlace").Value = Me.txtDatePlace.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                '----------------------------------------
                                .Fields("ManifestDate").Value = Me.txtManifest.Text ' = ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("sentHPGDate").Value = Me.txtSentHPG.Text '= ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("closeFile").Value = Me.chkClose.Checked '= ds.Tables(0).Rows(0).Item("").ToString

                                .Fields("LCL").Value = Me.chklcl.Checked
                                .Fields("FCL").Value = Me.chkfcl.Checked
                                .Fields("Consol").Value = Me.chkconsol.Checked
                                .Fields("air").Value = Me.chkair.Checked

                                '.Fields("hbl").Value = Me.txtHBL.Text
                                '.Fields("ref").Value = Me.txtRef.Text
                                .Fields("CY_CFS_ITEM").Value = Me.txtCYCFS.Text
                                .Fields("bl_type").Value = Me.txtBL_Type.Text

                                .Fields("vessel").Value = Me.txtVessel.Text
                                .Fields("voyage").Value = Me.txtVoyage.Text
                                .Fields("ETA").Value = Me.txtETA.Text

                                .Fields("SAILINGDATE").Value = Me.txtETD.Text
                                .Fields("pol").Value = Me.txtPOL.Text
                                .Fields("poR").Value = Me.txtPOR.Text
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
                                '--------------------------
                                .Fields("FreightAmount").Value = Me.txtFreightAmount.Text

                                .Fields("FreightPayableAt").Value = Me.txtFreightPayableAt.Text

                                .Fields("PlaceAndDate").Value = Me.txtPlaceAndDate.Text
                                .Fields("NumberOfOriginal").Value = Me.txtNumberOfOriginal.Text
                                '=========
                                .Fields("Prepaid").Value = Me.txtPP.Text
                                .Fields("Collect").Value = Me.txtCC.Text

                                .Fields("OnboardDate").Value = Me.txtOnboardDate.Text
                                .Fields("ShipperRef").Value = Me.txtShipperRef.Text

                                '---------------------------------
                                .Fields("remarks").Value = Me.txtRemarks.Text
                                .Fields("paidreceived").Value = Me.txtPaidReceived.Text
                                '--------------------------
                                '''----air

                                .Fields("airIssuingCarrier").Value = Me.txtairIssuingCarrier.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airAgentIATACode").Value = Me.txtairAgentIATACode.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airAccountNo").Value = Me.txtairAccountNo.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("AirTo1").Value = Me.txtAirTo1.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("AirByFirstCarrier").Value = Me.txtAirByFirstCarrier.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("Airto2").Value = Me.txtAirto2.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airby1").Value = Me.txtairby1.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airto3").Value = Me.txtairto3.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airby2").Value = Me.txtairby2.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airCHGSCode").Value = Me.txtairCHGSCode.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airDecCarrier").Value = Me.txtairDecCarrier.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("AirDecCus").Value = Me.txtAirDecCus.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airAmountOfInsurance").Value = Me.txtairAmountOfInsurance.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airSCI").Value = Me.txtairSCI.Text ' Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("AirOtherPC").Value = Me.txtAirOtherPC.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("airflightVoy2").Value = Me.txtFV2.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                '.Fields("AirFlightDate").Value = Me.dtpAirFlightDate.Text ' = Me.ds.Tables(0).Rows(0).Item("").ToString
                                .Fields("ChargeAbleWeight").Value = Me.txtChargeAbleWeight.Text '= Me.ds.Tables(0).Rows(0).Item("").ToString
                                ''' '----------------
                                .Fields("pkgs").Value = Me.txtPackages.Text
                                ''-------------------------------container







                                '-----------
                                '-------------------
                                .Fields("nodebit").Value = Me.txtNoDebit.Text

                                .Fields("nocredit").Value = Me.txtNoCredit.Text




                                '------------------------------------------------------------------------------------

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
            Me.cmdOK.Enabled = False
            Me.cmdOKAll.Enabled = False
            blnUpdated = True

            Me.TabControl1.Enabled = False


            'Me.Close()
            Dim cmd As New ADODB.Command
            Try
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from billonline where id= '" & mOutboundID & "' and userupdate='" & strUserId & "'"

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

        'Resume
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKCopy.Click
        Try

            Dim strQuery As String
            Dim outboundID_ As String
            Dim rsBillOfLadingHouse As New ADODB.Recordset
            If UCase(Me.txtNewBill.Text.Trim) = UCase(Me.cboCopyHBL.Text.Trim) Then
                DisplayMessage(True, "please check new bill. !")
                Me.txtNewBill.Focus()
                Exit Sub
            End If
            If Me.chknewbill.Checked = True Then
                If Me.txtNewBill.Text.Trim = "" Then
                    DisplayMessage(True, "Bill No. ?")
                    Me.txtNewBill.Focus()
                    Exit Sub
                End If
                strQuery = "SELECT * FROM Outbound WHERE mblmawb ='" & Me.txtNewBill.Text.Trim & "' and continued=1 "
                rsBillOfLadingHouse.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If CheckData() Then
                ' nếu không trùng ta ghi vào csdl và set discontinued=0
                If rsBillOfLadingHouse.EOF Then


                    With rsBillOfLadingHouse
                        ' them House bill 1
                        If rsBillOfLadingHouse.EOF Then
                            .AddNew()
                            .Fields("BLoB_ID").Value = NewId()


                            outboundID_ = .Fields("BLoB_ID").Value
                            '-----------------------10-may-2013

                            '-----------------------------------------
                            ' them branch
                            Try
                                .Fields("branch").Value = gBranch
                            Catch ex As Exception
                                DisplayMessage(True, "Branch cần được thêm vào Table Outbound.")
                            End Try
                            '==============================================


                            .Fields("mblmawb").Value = Me.txtNewBill.Text.Trim









                            .Fields("nhom").Value = gNhom










                            .Update()
                        End If
                    End With
                    rsBillOfLadingHouse.Close()

                Else
                    ' DisplayMessage(True, "Bill " + arrHouseBill(i).Text + " đã có.")
                    rsBillOfLadingHouse.Close()
                End If
                Try
                    CopyHBLOutAll("Outbound", "BLOB_ID", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "BLOB_ID", outboundID_)
                    CopyContainersAll("containerType", "outboundID", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "outboundid", outboundID_)
                    CopyHBLFreightall("oUTboundfreight", "outboundid", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "outboundid", outboundID_)

                Catch ex As Exception

                End Try
                'End If
            Else
                If Me.chkbill.Checked = True Then
                    CopyHBLOut("Outbound", "BLOB_ID", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "BLOB_ID", FindValueID(Me.cboMBLTo, Me.cboMBLTo.Text))
                    CopyContainers("containerType", "outboundID", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "outboundid", FindValueID(Me.cboMBLTo, Me.cboMBLTo.Text))

                End If
                If Me.chkfreight.Checked = True Then
                    CopyHBLFreight("oUTboundfreight", "outboundid", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "outboundid", FindValueID(Me.cboMBLTo, Me.cboMBLTo.Text))

                End If
                CopyHBLOut("Outbound", "BLOB_ID", FindValueID(Me.cboCopyHBL, Me.cboCopyHBL.Text), "BLOB_ID", FindValueID(Me.cboMBLTo, Me.cboMBLTo.Text))


            End If
            Me.QueryPort()
        Catch ex As Exception

        End Try


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
            id = "blob_id"
            value = "MBLMAWB"
            Me.cboCopyHBL.Items.Clear()
            Me.cboMBLTo.Items.Clear()

            strSQL = "Select distinct blob_id,MBLMAWB From Outbound where branch like '%" & gBranch & "%' and Continued=1  order by mblmawb "
            loadDataToObject(Me.cboCopyHBL, strSQL, id, value)
            loadDataToObject(Me.cboMBLTo, strSQL, id, value)

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
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString


            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            VB6.ShowForm(frmPrintBillAIROriginal, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DebitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If



            VB6.ShowForm(frmBillCargomanifest, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try

            If Me.chkagentonbehaft.Checked Then
                Dim chk As Integer
                chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If chk = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If

                '-------------------------------
                If Me.dgdHBL.RowCount > 0 Then
                    Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                    gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
                    gOutboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
                    gCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
                    gRefOutbound = Me.dgdHBL.Item("ref", index).Value.ToString
                    ' luu print 
                    '------------------------
                    Dim cmd As New ADODB.Command
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "update Outbound set printdebit= '1' where BLOB_ID='" & gOutboundID & "'   "

                    cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    '-----------------
                    gDebitOutbound = "Outbound"
                    gSqlDebitOutbound = "select * from outboundfreight left join charge on charge.charge_id=outboundfreight.itemid where outboundid='" & gOutboundID & "' and customerid='" & gOutboundCusID & "' and debitcredit='Debit' and no_='" & cboCusDebitIn.Text.Split("$")(0) & "' " ' os=thu ho

                    'If Me.CHKVND.Checked = True Then

                    '    'VB6.ShowForm(frmReportdebitOutUSD, VB6.FormShowConstants.Modal, Me)
                    '    If LoginSucceeded = True Then
                    '        Dim form As New frmReportdebitOutUSD 'frmInbound 'frmQuotationTico
                    '        form.MdiParent = frmMain
                    '        form.Show()
                    '    End If
                    'ElseIf Me.CHKUSd.Checked = True Then
                    anAgentInbound = Me.chkagentonbehaft.Checked
                    If LoginSucceeded = True Then
                        Dim form As New frmReportdebitOutUSD_Agent_GroupRef 'frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    ' VB6.ShowForm(frmReportdebitOutUSD_Agent, VB6.FormShowConstants.Modal, Me)

                    'ElseIf Me.chkagentonbehaft.Checked = True Then
                    'VB6.ShowForm(frmReportdebitOutUSD_Agent_Customer, VB6.FormShowConstants.Modal, Me) ' la agent onbehaft

                    ' End If
                End If
            Else
                Dim chk As Integer
                chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If chk = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If

                '-------------------------------
                If Me.dgdHBL.RowCount > 0 Then
                    Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                    gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
                    gOutboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
                    gCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
                    ' luu print 
                    '------------------------
                    Dim cmd As New ADODB.Command
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "update Outbound set printdebit= '1' where BLOB_ID='" & gOutboundID & "'   "

                    cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    '-----------------
                    gDebitOutbound = "Outbound"
                    gSqlDebitOutbound = "select * from outboundfreight left join charge on charge.charge_id=outboundfreight.itemid where outboundid='" & gOutboundID & "' and customerid='" & gOutboundCusID & "' and debitcredit='Debit' and no_='" & cboCusDebitIn.Text.Split("$")(0) & "' " ' os=thu ho
                    '  anAgentInbound = Me.chkagentonbehaft.Checked
                    If Me.CHKVND.Checked = True Then

                        'VB6.ShowForm(frmReportdebitOutUSD, VB6.FormShowConstants.Modal, Me)
                        If LoginSucceeded = True Then
                            Dim form As New frmReportdebitOutUSD 'frmInbound 'frmQuotationTico
                            form.MdiParent = frmMain
                            form.Show()
                        End If
                    ElseIf Me.CHKUSd.Checked = True Then
                        If LoginSucceeded = True Then
                            Dim form As New frmReportdebitOutUSD_Agent 'frmInbound 'frmQuotationTico
                            form.MdiParent = frmMain
                            form.Show()
                        End If
                        ' VB6.ShowForm(frmReportdebitOutUSD_Agent, VB6.FormShowConstants.Modal, Me)

                    ElseIf Me.chkagentonbehaft.Checked = True Then
                        'VB6.ShowForm(frmReportdebitOutUSD_Agent_Customer, VB6.FormShowConstants.Modal, Me) ' la agent onbehaft

                    End If
                End If
            End If

        Catch ex As Exception

        End Try
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
        Try
            If CHKRef_credit.Checked = True Then

                Dim chk As Integer
                chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If chk = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If
                If Me.dgdHBL.RowCount > 0 Then
                    Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                    gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
                    gRefOutbound = Me.dgdHBL.Item("ref", index).Value.ToString

                    gOutboundCusID = FindValueID(Me.cboCusCreditIn, Me.cboCusCreditIn.Text)
                    gCusID = FindValueID(Me.cboCusCreditIn, Me.cboCusCreditIn.Text)
                    gCreditOutbound = "Outbound"
                    'If Me.CHKRef_credit.Checked = True Then
                    '    If LoginSucceeded = True Then
                    '        Dim form As New frmReportCreditOut 'frmInbound 'frmQuotationTico
                    '        form.MdiParent = frmMain
                    '        form.Show()
                    '    End If
                    '    ' VB6.ShowForm(frmReportCreditOut, VB6.FormShowConstants.Modal, Me)
                    'ElseIf Me.CHKVND_credit.Checked = True Then
                    If LoginSucceeded = True Then
                        Dim form As New frmReportCreditOut 'frmReportCreditOut_VND_ref 'frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    '    ' VB6.ShowForm(frmReportCreditOut_VND, VB6.FormShowConstants.Modal, Me)
                    'End If

                End If
            Else
                Dim chk As Integer
                chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If chk = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If
                If Me.dgdHBL.RowCount > 0 Then
                    Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                    gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
                    gOutboundCusID = FindValueID(Me.cboCusCreditIn, Me.cboCusCreditIn.Text)
                    gCusID = FindValueID(Me.cboCusCreditIn, Me.cboCusCreditIn.Text)
                    gCreditOutbound = "Outbound"
                    If Me.CHKRef_credit.Checked = True Then
                        If LoginSucceeded = True Then
                            Dim form As New frmReportCreditOut 'frmInbound 'frmQuotationTico
                            form.MdiParent = frmMain
                            form.Show()
                        End If
                        ' VB6.ShowForm(frmReportCreditOut, VB6.FormShowConstants.Modal, Me)
                    ElseIf Me.CHKVND_credit.Checked = True Then
                        If LoginSucceeded = True Then
                            Dim form As New frmReportCreditOut 'frmReportCreditOut_VND 'frmInbound 'frmQuotationTico
                            form.MdiParent = frmMain
                            form.Show()
                        End If
                        ' VB6.ShowForm(frmReportCreditOut_VND, VB6.FormShowConstants.Modal, Me)
                    End If

                End If
            End If

        Catch ex As Exception

        End Try

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
        'If UCase(gDepartment) = "DOCUMENT" Or UCase(gDepartment) = "OPERATION" Then
        '    'Me.TabPage3.Text = "Credit (Administrator)"
        '    'Me.TabPage6.Text = "Credit (sale)"
        '    ' Me.chkClockCredit.Visible = True
        '    DisplayMessage(True, "Bạn không có quyền.!")
        '    Exit Sub

        'End If
        Dim id, value, strquery As String
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        Me.cboCusDebitIn.Text = ""
        Me.cboCusDebitIn.Items.Clear()

        '------------------------------
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' co goutboundid ta la bien close
            Dim sqlc As String
            Dim dsc As New DataSet
            sqlc = "select * from outbound where blob_id='" & gOutboundID & "' "
            dsc = ReadDataSet(sqlc)
            If dsc.Tables(0).Rows.Count > 0 Then
                If dsc.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If
            ' lay toan bo cus add vao cbo
            id = "CustomerID"
            value = "company"
            strquery = "Select CustomerID,company from outboundfreight left join customer on outboundfreight.CustomerID=customer.customer_id where outboundid='" & gOutboundID & "'  and debitcredit='Debit' "

            loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ' hien thi printdebit
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where BLOB_ID='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.chkprint.Checked = ds.Tables(0).Rows(0).Item("printdebit").ToString
            End If
            ''-------------------
            'id = "CustomerIDdebit2"
            'value = "company"
            'strquery = "Select CustomerIDdebit2,company from outbound left join customer on outbound.CustomerIDdebit2=customer.customer_id where BLOB_ID='" & gOutboundID & "'  and QuantityDebit2 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit3"
            'value = "company"
            'strquery = "Select CustomerIDdebit3,company from outbound  left join customer on outbound.CustomerIDdebit3=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit3 <> ''  "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)



            ''-------------------
            'id = "CustomerIDdebit4"
            'value = "company"
            'strquery = "Select CustomerIDdebit4,company from outbound left join customer on outbound.CustomerIDdebit4=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit4 <> ''  "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit5"
            'value = "company"
            'strquery = "Select CustomerIDdebit5,company from outbound left join customer on outbound.CustomerIDdebit5=customer.customer_id where BLOB_ID='" & gOutboundID & "'and QuantityDebit5 <> ''  "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)

            ''-------------------
            'id = "CustomerIDdebit6"
            'value = "company"
            'strquery = "Select CustomerIDdebit6,company from outbound left join customer on outbound.CustomerIDdebit6=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit6 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit7"
            'value = "company"
            'strquery = "Select CustomerIDdebit7,company from outbound left join customer on outbound.CustomerIDdebit7=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit7 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)

            ''-------------------
            'id = "CustomerIDdebit8"
            'value = "company"
            'strquery = "Select CustomerIDdebit8,company from outbound left join customer on outbound.CustomerIDdebit8=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit8 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)


            ''-------------------
            'id = "CustomerIDdebit9"
            'value = "company"
            'strquery = "Select CustomerIDdebit9,company from outbound left join customer on outbound.CustomerIDdebit9=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit9 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)


            ''-------------------
            'id = "CustomerIDdebit10"
            'value = "company"
            'strquery = "Select CustomerIDdebit10,company from outbound left join customer on outbound.CustomerIDdebit10=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit10 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)

            ''-------------------
            'id = "CustomerIDdebit11"
            'value = "company"
            'strquery = "Select CustomerIDdebit11,company from outbound left join customer on outbound.CustomerIDdebit11=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit11 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)


            ''-------------------
            'id = "CustomerIDdebit12"
            'value = "company"
            'strquery = "Select CustomerIDdebit12,company from outbound left join customer on outbound.CustomerIDdebit12=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit12 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)


            ''-------------------
            'id = "CustomerIDdebit13"
            'value = "company"
            'strquery = "Select CustomerIDdebit13,company from outbound left join customer on outbound.CustomerIDdebit13=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit13 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit14"
            'value = "company"
            'strquery = "Select CustomerIDdebit14,company from outbound left join customer on outbound.CustomerIDdebit14=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit14 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit15"
            'value = "company"
            'strquery = "Select CustomerIDdebit15,company from outbound left join customer on outbound.CustomerIDdebit15=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit15 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit16"
            'value = "company"
            'strquery = "Select CustomerIDdebit16,company from outbound left join customer on outbound.CustomerIDdebit16=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit16 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit17"
            'value = "company"
            'strquery = "Select CustomerIDdebit17,company from outbound left join customer on outbound.CustomerIDdebit17=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit17 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit18"
            'value = "company"
            'strquery = "Select CustomerIDdebit18,company from outbound left join customer on outbound.CustomerIDdebit18=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit18 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit19"
            'value = "company"
            'strquery = "Select CustomerIDdebit19,company from outbound left join customer on outbound.CustomerIDdebit19=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit19 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)
            ''-------------------
            'id = "CustomerIDdebit20"
            'value = "company"
            'strquery = "Select CustomerIDdebit20,company from outbound left join customer on outbound.CustomerIDdebit20=customer.customer_id where BLOB_ID='" & gOutboundID & "' and QuantityDebit20 <> '' "

            'loadDataToObjectNoClear(Me.cboCusDebitIn, strquery, id, value)









        End If

        Me.GroupBox4.BringToFront()
        Me.GroupBox4.Visible = True



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CreditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem1.Click
        On Error GoTo Err_Renamed
        ' lay toan bo khach hang cua debit
        'If UCase(gDepartment) = "DOCUMENT" Or UCase(gDepartment) = "OPERATION" Then
        '    'Me.TabPage3.Text = "Credit (Administrator)"
        '    'Me.TabPage6.Text = "Credit (sale)"
        '    ' Me.chkClockCredit.Visible = True
        '    DisplayMessage(True, "Bạn không có quyền.!")
        '    Exit Sub

        'End If
        Me.GroupBox5.BringToFront()
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
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
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
            strquery = "Select CustomerID,company from outboundfreight left join customer on outboundfreight.CustomerID=customer.customer_id where outboundid='" & gOutboundID & "'  and debitcredit='Credit' "

            loadDataToObjectNoClear(Me.cboCusCreditIn, strquery, id, value)

        End If

        Me.GroupBox5.BringToFront()
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
            MakeQueryShipper = " select blob_id,stuff(ref,1,4,'') as [order], air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC "
            'Sql = " select blob_id,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shipper,consignee,notify,nodebit,nocredit,approve,editable,continued,userupdate ,DateUpdate  from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' order by dateupdate desc "

            MakeQueryShipper = MakeQueryShipper & " from outbound WHERE   salecode='" & gSaleCode & "' and "

            MakeQueryShipper = MakeQueryShipper & " "
            MakeQueryShipper = MakeQueryShipper & " (Continued = 1) and (branch like '%" & gBranch & "%') and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' ) "
            MakeQueryShipper = MakeQueryShipper & " "
            If Not IsNothing(argCriteria) And argCriteria <> "" Then
                MakeQueryShipper = MakeQueryShipper & argCriteria
            End If

            'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
            If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
                MakeQueryShipper = MakeQueryShipper & " order by dateupdate desc "
            End If
            '    
        Else
            If UCase(gDepartment) = "CUSTOMER" Or UCase(gDepartment) = "DOCUMENT" Then
                MakeQueryShipper = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit, REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC "
                'Sql = " select blob_id,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shipper,consignee,notify,nodebit,nocredit,approve,editable,continued,userupdate ,DateUpdate  from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' order by dateupdate desc "

                MakeQueryShipper = MakeQueryShipper & " from outbound WHERE   "

                MakeQueryShipper = MakeQueryShipper & " "
                MakeQueryShipper = MakeQueryShipper & " (Continued = 1) and (branch like '%" & gBranch & "%') and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' ) "
                MakeQueryShipper = MakeQueryShipper & " "
                If Not IsNothing(argCriteria) And argCriteria <> "" Then
                    MakeQueryShipper = MakeQueryShipper & argCriteria
                End If

                'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
                If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
                    MakeQueryShipper = MakeQueryShipper & " order by dateupdate desc "
                End If
            Else
                MakeQueryShipper = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit, REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC "
                'Sql = " select blob_id,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shipper,consignee,notify,nodebit,nocredit,approve,editable,continued,userupdate ,DateUpdate  from Outbound where mblCarrier='" & Me.cboMBLCarrier.Text & "' order by dateupdate desc "

                MakeQueryShipper = MakeQueryShipper & " from outbound WHERE   "

                MakeQueryShipper = MakeQueryShipper & " "
                MakeQueryShipper = MakeQueryShipper & " (Continued = 1) and (gFLC='" & gFLC & "' ) and (gSC='" & gSC & "' ) " 'and (branch like '%" & gBranch & "%')
                MakeQueryShipper = MakeQueryShipper & " "
                If Not IsNothing(argCriteria) And argCriteria <> "" Then
                    MakeQueryShipper = MakeQueryShipper & argCriteria
                End If

                'MakeQueryShipper = MakeQueryShipper & strCustomerTaxOrder1
                If mStatus = "Add" Or mStatus = "Edit" Or mStatus = "Normal" Then
                    MakeQueryShipper = MakeQueryShipper & " order by dateupdate desc "
                End If
            End If

        End If

        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
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
        'hien thi ra grid 
        Me.dgdHBL.DataSource = ds.Tables("ShipperList")
        '------------vị trí BM
        vitri = 0
        If vitri >= 0 And vitri <= Me.dgdHBL.Rows.Count And Me.dgdHBL.Rows.Count > 0 Then
            Me.dgdHBL.Rows(vitri).Selected = True
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdHBL)





        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    Private Sub BillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmBillVINPAC, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillContructionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillContructionToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            gPrintOutbound = "Outbound"
            If LoginSucceeded = True Then
                Dim form As New frmBillInstruction 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            ' VB6.ShowForm(frmBillInstruction, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub BillUnitedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmBillUnited, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillHEADWINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmBillHEADWIN, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmJOBOut, VB6.FormShowConstants.Modeless, Me)
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

            If Me.cboMBLCarrier.Text = "" Then

            Else
                Dim sql As String
                Dim ds As New DataSet
                sql = " select * from oUTbound where MBLCARRIER='" & Me.cboMBLCarrier.Text & "' and continued=1"
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then

                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        For j = 1 To 10
                            If ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString.Trim <> "" Then
                                kien += CDbl(ds.Tables(0).Rows(i).Item("sokien" + CStr(j)).ToString.Trim)
                            End If
                        Next
                        For j = 1 To 10
                            If ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString.Trim <> "" Then
                                kg += CDbl(ds.Tables(0).Rows(i).Item("sokg" + CStr(j)).ToString.Trim)
                            End If
                        Next
                        For j = 1 To 10
                            If ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString.Trim <> "" Then
                                khoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi" + CStr(j)).ToString.Trim)
                            End If
                        Next


                    Next
                End If
                Me.txtTongKien.Text = FormatNumber(kien.ToString, 2)
                Me.txtTongKg.Text = FormatNumber(kg.ToString, 2)
                Me.txtTongKhoi.Text = FormatNumber(khoi.ToString, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub BillZirconToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmBillZircon, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        ' lay toan bo khach hang cua debit
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
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
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
            strquery = "Select CustomerID,company from OUTboundfreight left join customer on OUTboundfreight.CustomerID=customer.customer_id where OUTboundid='" & gOutboundID & "'  and debitcredit='Debit' "

            loadDataToObjectNoClear(Me.cboCantruDeCre, strquery, id, value)

        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' lay toan bo cus add vao cbo
            '----------------------------------
            id = "CustomerID"
            value = "company"
            strquery = "Select CustomerID,company from OUTboundfreight left join customer on OUTboundfreight.CustomerID=customer.customer_id where OUTboundid='" & gOutboundID & "'  and debitcredit='Credit' "

            loadDataToObjectNoClear(Me.cboCantruDeCre, strquery, id, value)


        End If

        Me.GroupBox12.Visible = True



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))

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
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            gOutboundCusID = FindValueID(Me.cboCantruDeCre, Me.cboCantruDeCre.Text)


            Dim unitprice1, unitprice2, unitprice3, unitprice4, unitprice5, unitprice6, unitprice7, unitprice8, unitprice9, unitprice10 As Object
            VB6.ShowForm(frmReportCanTru, VB6.FormShowConstants.Modal, Me)
        End If
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

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.GroupBox12.Visible = False
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try
            If Me.txtBKNo.Text = "" Then
                Exit Sub
            End If
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from bookingagent where gmd_bookingno='" & Me.txtBKNo.Text.Trim & "' and continued =1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtVessel.Text = ds.Tables(0).Rows(0).Item("carrier").ToString
                Me.txtVoyage.Text = ds.Tables(0).Rows(0).Item("voyNo").ToString
                Me.txtETD.Text = ds.Tables(0).Rows(0).Item("etd").ToString.Replace("12:00:00 AM", "")
                Me.txtETA.Text = ds.Tables(0).Rows(0).Item("eta").ToString.Replace("12:00:00 AM", "")
                Me.txtPOR.Text = ds.Tables(0).Rows(0).Item("portofloading").ToString
                Me.txtPOL.Text = ds.Tables(0).Rows(0).Item("portofloading").ToString
                Me.txtPOD.Text = ds.Tables(0).Rows(0).Item("portofUnloading").ToString
                Me.txtDest.Text = ds.Tables(0).Rows(0).Item("destination").ToString
                Me.txtDel.Text = ds.Tables(0).Rows(0).Item("portofUnloading").ToString
                Me.cboSale.Text = ds.Tables(0).Rows(0).Item("SALECODE").ToString

            End If



        Catch ex As Exception

        End Try
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
        '            Me.txtUnitPriceDebit1.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit1.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit2.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit2.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit3.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit3.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit4.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit4.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit5.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit5.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit6.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit6.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit7.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit7.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '            Me.txtUnitPriceDebit8.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit8.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
        '        End If

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboItemsdebit8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboItemsdebit9_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        ' kiem tra hang FCL,LCL
        ' lay phi tariff
        'Try


        '    Dim sql As String
        '    Dim ds As New DataSet

        '    sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit9, Me.cboItemsdebit9.Text) & "%' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        If Me.chkFCL.Checked = True Then
        '            Me.txtUnitPriceDebit9.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '        Else
        '            Me.txtUnitPriceDebit9.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
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
        '    Try


        '        Dim sql As String
        '        Dim ds As New DataSet

        '        sql = "select * from charge where charge like N'%" & FindValueID(Me.cboItemsdebit10, Me.cboItemsdebit10.Text) & "%' "
        '        ds = ReadDataSet(sql)
        '        If ds.Tables(0).Rows.Count > 0 Then
        '            If Me.chkFCL.Checked = True Then
        '                Me.txtUnitPriceDebit10.Text = ds.Tables(0).Rows(0).Item("tarifffcl").ToString
        '            Else
        '                Me.txtUnitPriceDebit10.Text = ds.Tables(0).Rows(0).Item("tarifflcl").ToString
        '            End If

        '        End If
        '    Catch ex As Exception

        '    End Try
    End Sub

    Private Sub cboItemsdebit10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub QueryHinhanh(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select path as [File_path] from smf_hinh inner join Outbound on outbound.BLOB_ID=smf_hinh.BLOB_ID where outbound.BLOB_ID= '" & mOutboundID & "'  "
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
            sql &= "Where " &
                   " blob_id='" & mOutboundID & "'  "
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
        Dim selectedRowCount As Integer =
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

                    .Fields("blob_ID").Value = getID(mOutboundID)


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
        Me.ButtonX1.Enabled = False
        Me.cmdOKHinh.Enabled = False
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

    Private Sub PICHinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PICHinh.Click

        Try
            Dim index As Integer = Me.dgdHinh.CurrentRow.Index
            gHinh = Me.dgdHinh.Item("file_path", index).Value.ToString
            frmHinh.Show()
        Catch ex As Exception

        End Try

    End Sub





    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset


            If mStatusContainer = "Add" Or mStatusContainer = "Edit" Then
                Try
                    copyHistory("containertype", "outboundcontainersid", mOutboundContainerID, "history")
                Catch ex As Exception

                End Try
                ' them container
                '=========='
                strQuery = "Select * From containertype Where outboundcontainersid='" & mOutboundContainerID & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("outboundContainersID").Value = NewId()
                    End If

                    .Fields("outboundID").Value = getID(mOutboundID)
                    '-------------------------------container

                    .Fields("ContainerNo").Value = Me.txtContainerNo1.Text
                    '------------------------------------------
                    .Fields("containertype").Value = Me.txtType1.Text
                    .Fields("type").Value = Me.txtPackages.Text
                    '--------------------------------------------------------------------------------
                    .Fields("seal").Value = Me.txtSeal1.Text
                    '------------------------------------------------------------------------------------
                    .Fields("sokien").Value = Me.txtsoKien1.Text
                    .Fields("netweight").Value = Me.txtnetweight.Text
                    '-------------------------------------------------------------------------------
                    .Fields("sokg").Value = Me.txtsoKg1.Text
                    '---------------------------------------------------------------------
                    .Fields("sokhoi").Value = Me.txtCBM1.Text
                    ' .Fields("kgavailable").Value = Me.txtChargeA.Text
                    ' .Fields("path").Value = Me.cboduongdan.Text
                    ' luu tinh khoi
                    If Me.txtdai.Text = "" Then
                        Me.txtdai.Text = 0
                    End If

                    If Me.txtrong.Text = "" Then
                        Me.txtrong.Text = 0
                    End If
                    If Me.txtcao.Text = "" Then
                        Me.txtcao.Text = 0
                    End If

                    If Me.txtCaoPalet.Text = "" Then
                        Me.txtCaoPalet.Text = 0
                    End If

                    .Fields("dai").Value = FormatNumber(Me.txtdai.Text, 3)
                    .Fields("rong").Value = FormatNumber(Me.txtrong.Text, 3)
                    .Fields("cao").Value = FormatNumber(Me.txtcao.Text, 3)
                    .Fields("caopalet").Value = FormatNumber(Me.txtCaoPalet.Text, 3)
                    Try
                        .Fields("tongkhoiavailable").Value = FormatNumber((CDbl(Me.txtrong.Text) * CDbl(Me.txtdai.Text) * CDbl(Me.txtcao.Text)) - CDbl(Me.txtCaoPalet.Text), 3)
                    Catch ex As Exception

                    End Try

                    .Fields("nhietdo").Value = Me.txttemp.Text
                    .Fields("thonggio").Value = Me.txtvent.Text
                    .Fields("descriptionContainer").Value = Me.txtDescriptionContainer.Text

                    .Update()

                End With
                rs.Close()
                checkContainerSOCxuat(txtContainerNo1.Text)
            End If
            mStatusContainer = "Normal"
            Me.Button49.Enabled = False
            Button50_Click(sender, e)
            Me.QueryContainer()
            ' kiem tra container nay co phai hang SOC hay ko
            ' neu phai thi them ngayCDTVDL

            demTongTeuCBM()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub demTongTeuCBM()
        Try
            Dim i As Integer
            Dim tongteu As Double = 0
            Dim tongcbm As Double = 0
            For i = 0 To Me.dgdContainers.RowCount - 1
                Try
                    If Me.dgdContainers.Item("containertype", i).Value.ToString Like "*20*" Then
                        Try
                            tongteu += 1
                        Catch ex As Exception

                        End Try
                    End If
                    If Me.dgdContainers.Item("containertype", i).Value.ToString Like "*40*" Then
                        Try
                            tongteu += 2
                        Catch ex As Exception

                        End Try
                    End If
                    Try
                        tongcbm += CDbl(Me.dgdContainers.Item("sokhoi", i).Value.ToString)
                    Catch ex As Exception

                    End Try

                Catch ex As Exception

                End Try
            Next
            Me.txttongcbm.Text = tongcbm.ToString
            Me.txttongteu.Text = tongteu.ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Sub checkDeleteContainerSOCxuat(ByVal cont As String)
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            sql = "select * from containerrepair where containerno='" & cont & "' and contdatravedaily=1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count = 1 Then
                strQuery = "Select * From containerrepair Where inboundcontainersid='" & ds.Tables(0).Rows(0).Item("inboundContainersID").ToString & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs




                    .Fields("contdatravedaily").Value = False
                    .Fields("ngayCDTVDL").Value = ""
                    '---them de tinh credit cho Dai ly




                    .Update()
                End With
                rs.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub checkContainerSOCxuat(ByVal cont As String)
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            sql = "select * from containerrepair where containerno='" & cont & "' and controngtaibai=1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count = 1 Then
                strQuery = "Select * From containerrepair Where inboundcontainersid='" & ds.Tables(0).Rows(0).Item("inboundContainersID").ToString & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs




                    .Fields("contdatravedaily").Value = False
                    .Fields("ngayCDTVDL").Value = ""
                    '---them de tinh credit cho Dai ly




                    .Update()
                End With
                rs.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click
        Try
            ' Me.txtContainerNo1.Text = ""
            Me.txtContainerNo1.Enabled = False
            ' Me.txtType1.Text = ""
            Me.txtType1.Enabled = False

            ' Me.txtSeal1.Text = ""
            Me.txtSeal1.Enabled = False

            'Me.txtsoKien1.Text = ""
            Me.txtsoKien1.Enabled = False

            ' Me.txtPackages.Text = ""
            Me.txtPackages.Enabled = False

            ' Me.txtsoKg1.Text = ""
            Me.txtsoKg1.Enabled = False

            'Me.txtChargeA.Text = ""
            'Me.txtChargeA.Enabled = False


            ' Me.txtCBM1.Text = ""
            Me.txtCBM1.Enabled = False

            mStatusContainer = "Normal"
            Me.Button49.Enabled = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            If index >= 0 Then
                If mStatusContainer = "Normal" And UserRight("mnuOutbound", "Edit") Then

                    Me.Button49.Enabled = True
                    '--------------

                    Me.txtContainerNo1.Enabled = True

                    Me.txtType1.Enabled = True

                    Me.txtSeal1.Enabled = True


                    Me.txtsoKien1.Enabled = True


                    Me.txtPackages.Enabled = True


                    Me.txtsoKg1.Enabled = True


                    '  Me.txtChargeA.Enabled = True



                    Me.txtCBM1.Enabled = True
                    '---------------------------

                    mOutboundContainerID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusContainer = "Add"

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDataContainer(ByVal index As Integer)
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from containertype where outboundContainersID='" & mOutboundContainerID & "'"

            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtnetweight.Text = ds.Tables(0).Rows(0).Item("netweight").ToString
            End If

            Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.txtType1.Text = Me.dgdContainers.Item("containertype", index).Value.ToString


            Me.txtSeal1.Text = Me.dgdContainers.Item("seal", index).Value.ToString


            Me.txtsoKien1.Text = Me.dgdContainers.Item("sokien", index).Value.ToString


            Me.txtPackages.Text = Me.dgdContainers.Item("type", index).Value.ToString


            Me.txtsoKg1.Text = Me.dgdContainers.Item("sokg", index).Value.ToString


            'Me.txtChargeA.Text = Me.dgdContainers.Item("kgavailable", index).Value.ToString



            Me.txtCBM1.Text = Me.dgdContainers.Item("sokhoi", index).Value.ToString
            Me.txtdai.Text = Me.dgdContainers.Item("dai", index).Value.ToString

            Me.txtrong.Text = Me.dgdContainers.Item("rong", index).Value.ToString
            Me.txtcao.Text = Me.dgdContainers.Item("cao", index).Value.ToString
            Me.txtCaoPalet.Text = Me.dgdContainers.Item("caopalet", index).Value.ToString
            Me.TextBox2.Text = Me.dgdContainers.Item("tongkhoiavailable", index).Value.ToString
            Me.txtvent.Text = Me.dgdContainers.Item("thonggio", index).Value.ToString

            Me.txttemp.Text = Me.dgdContainers.Item("nhietdo", index).Value.ToString
            Me.txtDescriptionContainer.Text = Me.dgdContainers.Item("descriptionContainer", index).Value.ToString


        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDataPack(ByVal index As Integer)
        Try
            Me.cboCusPackage.Text = FindIDValue(Me.cboCusPackage, Me.dgdpackage.Item("cusid", index).Value.ToString)

            Me.cbocontPack.Text = FindIDValue(Me.cbocontPack, Me.dgdpackage.Item("contid", index).Value.ToString)


            Me.txtsoluongkien.Text = Me.dgdpackage.Item("soluongkien", index).Value.ToString
            Me.txtdaikien.Text = Me.dgdpackage.Item("daikien", index).Value.ToString
            Me.txtrongkien.Text = Me.dgdpackage.Item("rongkien", index).Value.ToString
            Me.txtcaokien.Text = Me.dgdpackage.Item("caokien", index).Value.ToString
            Me.txtsaiso.Text = Me.dgdpackage.Item("saiso", index).Value.ToString
            Me.txtmeas.Text = Me.dgdpackage.Item("tongkhoikien", index).Value.ToString
            Me.txtloaikien.Text = Me.dgdpackage.Item("loaikien", index).Value.ToString
            Me.txtghichukien.Text = Me.dgdpackage.Item("ghichu", index).Value.ToString
            Me.txtlocationPack.Text = Me.dgdpackage.Item("vitripack", index).Value.ToString
            Me.txtweightPack.Text = Me.dgdpackage.Item("weight", index).Value.ToString

            Me.chkxepChong.Checked = Me.dgdpackage.Item("xepchong", index).Value

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDatatheodoigrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString

            Me.cboitems.Text = Me.dgdtheodoi.Item("items", index).Value.ToString

            Me.txtRemarks_theodoi.Text = Me.dgdtheodoi.Item("remarks", index).Value.ToString
            Me.txtTimer.Text = Me.dgdtheodoi.Item("timer", index).Value.ToString
            Me.txtValidUser.Text = Me.dgdtheodoi.Item("validuser", index).Value.ToString
            '--------

            Try
                Me.txtngaychungtu.Text = Me.dgdtheodoi.Item("ngaychungtu", index).Value.ToString

                Me.txtbangoc.Text = Me.dgdtheodoi.Item("bangoc", index).Value.ToString
                Me.chkinTheodoi.Checked = Me.dgdtheodoi.Item("intheodoi", index).Value
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshDatadebitgrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString


            ''-------------- other agent
            '.Fields("OtherDebit1").Value = Me.OtherDebit1.Text
            '.Fields("OtherDebit2").Value = Me.OtherDebit2.Text

            '.Fields("OtherDebit3").Value = Me.OtherDebit3.Text
            '.Fields("OtherDebit4").Value = Me.OtherDebit4.Text
            '.Fields("OtherDebit5").Value = Me.OtherDebit5.Text
            '.Fields("OtherDebit6").Value = Me.OtherDebit6.Text
            '.Fields("OtherDebit7").Value = Me.OtherDebit7.Text
            '.Fields("OtherDebit8").Value = Me.OtherDebit8.Text
            '.Fields("OtherDebit9").Value = Me.OtherDebit9.Text
            '.Fields("OtherDebit10").Value = Me.OtherDebit10.Text
            '.Fields("OtherDebit11").Value = Me.OtherDebit11.Text
            '.Fields("OtherDebit12").Value = Me.OtherDebit12.Text


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
            Me.chkAgent.Checked = Me.dgddebitGrid.Item("Agent_debit", index).Value.ToString

            Me.txtinvoicedebit.Text = Me.dgddebitGrid.Item("ngay_debit", index).Value.ToString

            '  Me.txtChargeA.Enabled = True
            Me.txtinvoicenodebit.Text = Me.dgddebitGrid.Item("ngayhoadon_debit", index).Value.ToString
            Me.txthancongno.Text = Me.dgddebitGrid.Item("hancongno", index).Value.ToString
            Me.cbocusdebit.Text = Me.dgddebitGrid.Item("company_debit", index).Value
            Try
                Me.txtstt.Text = Me.dgddebitGrid.Item("stt_debit", index).Value.ToString
            Catch ex As Exception

            End Try
            Try
                Me.chkShowVND.Checked = Me.dgddebitGrid.Item("showvnd", index).Value.ToString
            Catch ex As Exception

            End Try

            Me.cboContainer.Text = Me.dgddebitGrid.Item("containerdebit", index).Value.ToString
            Me.txtfreeDEM.Text = Me.dgddebitGrid.Item("freedemdebit", index).Value.ToString
            Me.txtfreeDET.Text = Me.dgddebitGrid.Item("freedetdebit", index).Value.ToString
            Me.txtunitpricedebit_.Text = Me.dgddebitGrid.Item("unitprice_debit_", index).Value.ToString
            Me.txtpricedebit_.Text = Me.dgddebitGrid.Item("price_debit_", index).Value.ToString
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
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub RefreshDataCreditgrid(ByVal index As Integer)
        Try
            '  Me.txtContainerNo1.Text = Me.dgdContainers.Item("containerno", index).Value.ToString


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
            Me.cbocuscredit.Text = Me.dgdCreditGrid.Item("company_Credit", index).Value.ToString
            Me.cbocontainerCredit.Text = Me.dgdCreditGrid.Item("containercredit", index).Value.ToString
            Me.txtfreedemcredit.Text = Me.dgdCreditGrid.Item("freedemcredit", index).Value.ToString
            Me.txtfreedetcredit.Text = Me.dgdCreditGrid.Item("freedetcredit", index).Value.ToString
            Me.chkShowVND_Credit.Checked = Me.dgdCreditGrid.Item("showvnd_credit", index).Value.ToString
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

                If mStatusContainer = "Normal" And UserRight("mnuoutbound", "Edit") Then

                    Me.Button49.Enabled = True
                    mOutboundContainerID = Me.dgdContainers.Item("outboundContainersID", index).Value.ToString
                    mStatusContainer = "Edit"

                    RefreshDataContainer(index)

                    'Me.QueryContainer()
                    Me.txtContainerNo1.Enabled = True

                    Me.txtType1.Enabled = True

                    Me.txtSeal1.Enabled = True


                    Me.txtsoKien1.Enabled = True


                    Me.txtPackages.Enabled = True


                    Me.txtsoKg1.Enabled = True


                    'Me.txtChargeA.Enabled = True



                    Me.txtCBM1.Enabled = True

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


            Dim selectedRowCount As Integer =
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
            demTongTeuCBM()
        Catch ex As Exception

        End Try

    End Sub
    Sub QueryContainer(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select outboundcontainersid,outboundid,containerno,containertype,descriptionContainer,type,seal,sokien,netweight,sokg,sokhoi,dai,rong,cao,caopalet,tongkhoiavailable,nhietdo,thonggio "
            sql &= " From Containertype "
            sql &= "Where " &
                   " outboundID='" & mOutboundID & "'  "
            oTblEquip = ReadTable(sql)
            Me.dgdContainers.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdContainers)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub QueryPackage_(Optional ByVal location As Integer = 0)
        Try
            ' Try
            Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
            sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
            sql &= "Where " &
                   " freighttariff.outboundID='" & mOutboundID & "'  and contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"
            oTblEquip = ReadTable(sql)
            'Catch ex As Exception
            'Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
            'sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
            'sql &= "Where " & _
            '       " freighttariff.outboundID='" & mOutboundID & "'  "
            'oTblEquip = ReadTable(sql)
            ' End Try


            Me.dgdpackage.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdpackage)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub QueryPackage(Optional ByVal location As Integer = 0)
        Try
            ' Try
            'Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
            'sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
            'sql &= "Where " & _
            '       " freighttariff.outboundID='" & mOutboundID & "'  and contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"
            'oTblEquip = ReadTable(sql)
            'Catch ex As Exception
            Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
            sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
            sql &= "Where " &
                   " freighttariff.outboundID='" & mOutboundID & "'  "
            oTblEquip = ReadTable(sql)
            ' End Try


            Me.dgdpackage.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdpackage)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub Querydebit(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select outboundid,outboundfreightid,customerid,itemid,company + '-' + taxcode as company,container,freedem,freedet,charge_code + '/' + dvt  + '/' + charge as item,currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, tigia, dongiatruocthueVND,thanhtientruocthueVND,tienthueVND,thanhtiensauthueVND "
            sql &= " ,outboundfreight.approve,userupdate,dateupdate,songaycongno,daily,outboundfreight.stt,showvnd,unitprice_,price_ From outboundfreight left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
            sql &= "Where " &
                   " outboundid='" & mOutboundID & "'  and debitcredit='Debit'"
            oTblEquip = ReadTable(sql)
            Me.dgddebitGrid.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgddebitGrid)
            Me.profit()
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub Querytheodoi(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select outboundid,theodoilohangid,items,remarks,timer,validUser,dateupdate,userupdate,ngaychungtu,bangoc,intheodoi "
            sql &= " From theodoilohang  "
            sql &= "Where " &
                   " outboundid='" & mOutboundID & "' order by dateupdate desc "
            oTblEquip = ReadTable(sql)
            Me.dgdtheodoi.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdtheodoi)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub QueryCredit(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select boss,ktt,dntt,outboundid,outboundfreightid,customerid,itemid,company + '-' + taxcode as company,container,freedem,freedet,charge_code + '/' + dvt  + '/' + charge as item,currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, tigia, other "
            sql &= "  ,outboundfreight.approve,userupdate,dateupdate,daily,showvnd  From outboundfreight left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
            sql &= "Where " &
                   " outboundid='" & mOutboundID & "'  and debitcredit='Credit'"
            oTblEquip = ReadTable(sql)
            Me.dgdCreditGrid.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdCreditGrid)
            Me.profit()
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
        If Not UserRight("mnuoutbound", "Delete") Then
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
                cmd.CommandText = "delete from containertype where outboundContainersID= '" & Me.dgdContainers.Item("outboundContainersID", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleterowPack(ByVal index As Integer)
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
        If Not UserRight("mnuoutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Package: " & Me.dgdpackage.Item("customer", index).Value.ToString
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
                cmd.CommandText = "delete from freighttariff where freighttariffId= '" & Me.dgdpackage.Item("packID", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
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
        If Not UserRight("mnuoutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Debit: " & Me.dgddebitGrid.Item("item_debit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then

                copyHistory("outboundfreight", "outboundfreightid", Me.dgddebitGrid.Item("outboundfreightid_debit", index).Value.ToString, "history")



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
                cmd.CommandText = "delete from outboundfreight where outboundfreightid= '" & Me.dgddebitGrid.Item("outboundfreightid_debit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
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
        If Not UserRight("mnuoutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Credit: " & Me.dgdCreditGrid.Item("item_Credit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                copyHistory("outboundfreight", "outboundfreightid", Me.dgdCreditGrid.Item("outboundfreightid_credit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from outboundfreight where outboundfreightid= '" & Me.dgdCreditGrid.Item("outboundfreightid_credit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub




    Private Sub EditDebitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' refesh debit
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
                Approve = Me.dgdHBL.Item("Approve", index).Value
                EditTable = Me.dgdHBL.Item("Editable", index).Value
                If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnuOutbound", "Edit") Then
                    'Me.dgdPort.Height = 306
                    'Me.dgdPort.Enabled = False
                    'Me.txtPortCode.Enabled = False
                    'Me.fraUpdate.Visible = True
                    'ReFormat()
                    'SetMenu((False))
                    '' lay id de kiem tra
                    mOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
                    sqlkt = "select * from billonline where id='" & mOutboundID & "'"
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

                        .Fields("id").Value = "{" + mOutboundID + "}"
                        .Update()

                    End With
                    rs.Close()

                    '-------------------
                    Me.cmdOK.Enabled = False
                    Me.cmdOKAll.Enabled = False




                    ' Me.cmdOKAll.Enabled = True
                    Me.dgdHBL.Enabled = False

                    mStatus = "Edit"
                    reText(mStatus)

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
            'report()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub EditCreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                Approve = Me.dgdHBL.Item("Approve", index).Value
                EditTable = Me.dgdHBL.Item("Editable", index).Value
                If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnuOutbound", "Edit") Then
                    'Me.dgdPort.Height = 306
                    'Me.dgdPort.Enabled = False
                    'Me.txtPortCode.Enabled = False
                    'Me.fraUpdate.Visible = True
                    'ReFormat()
                    'SetMenu((False))
                    mOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
                    sqlkt = "select * from billonline where id='" & mOutboundID & "'"
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

                        .Fields("id").Value = "{" + mOutboundID + "}"
                        .Update()

                    End With
                    rs.Close()

                    '-------------------



                    Me.cmdOK.Enabled = False
                    Me.cmdOKAll.Enabled = False



                    ' Me.cmdOKAll.Enabled = True
                    Me.dgdHBL.Enabled = False

                    mStatus = "Edit"
                    reText(mStatus)
                    'RefreshDatacredit(index)
                    'QueryHinhanh()
                    'Querythemhinh()
                    'QueryContainer()
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
            ' report()
        Catch ex As Exception

        End Try
    End Sub





    Private Sub BillZimexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmPrintBillTramsmodal, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillTransmodalCargoReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmPrintBillTramsmodalCargo, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillUSPacificTransportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString




            VB6.ShowForm(frmPrintBillUS, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdok_debit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancel_debit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        Try
            Try
                Dim approvedebitnote As Boolean
                ' allCus()
                Me.cboContainer.Text = ""
                addluoicont()
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'vitri = index
                'If index >= 0 Then
                '    approvedebitnote = Me.dgddebitGrid.Item("Approvedebit", index).Value
                'End If
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusDebit = "Normal" And UserRight("mnuOutbound", "Edit") Then

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

                    mdebitid = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusDebit = "Add"
                    Me.txtexdebit.Text = getCur("USD")
                Else
                    DisplayMessage(True, "You are in " + mStatusDebit)
                    'DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem2.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không
            allCus()
            addluoicont()
            If Me.dgddebitGrid.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
            Approve = Me.dgddebitGrid.Item("Approvedebit", index).Value
            vitri = index
            If index >= 0 Then

                If mStatusDebit = "Normal" And Not Approve And UserRight("mnuoutbound", "Edit") Then

                    Me.cmdok_debit.Enabled = True

                    mdebitid = Me.dgddebitGrid.Item("outboundfreightID_debit", index).Value.ToString
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
                    DisplayMessage(True, "You are in " + mStatusCredit + "/ Approve status.")

                    '   DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelToolStripMenuItem.Click
        Try
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer =
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

    Private Sub cmdok_debit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok_debit.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            ' kiem tra han cong no tien
            Dim sql As String
            Dim ds As New DataSet
            Dim tong As Double = 0
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
            If Me.txtexdebit.Text = "1" Or Me.txtexdebit.Text = "" Then
                DisplayMessage(True, "Xin nhập tỉ giá.")
                Me.txtexdebit.Focus()
                Exit Sub
            End If
            If mStatusDebit = "Add" Or mStatusDebit = "Edit" Then
                Try
                    copyHistory("outboundfreight", "outboundfreightid", mdebitid, "history")
                Catch ex As Exception

                End Try
                ' them container
                '=========='
                strQuery = "Select * From outboundfreight Where outboundfreightid='" & mdebitid & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("outboundfreightID").Value = NewId()
                        .Fields("outboundID").Value = getID(mOutboundID)
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
                    ' .Fields("pricethue").Value = Me.txtpricetaxdebit.Text
                    .Fields("price").Value = Me.txtpricedebit.Text
                    .Fields("note").Value = Me.txtremarksdebit.Text
                    .Fields("os").Value = Me.chkosdebit.Checked
                    .Fields("paycheck").Value = Me.chkpaydebit.Checked
                    .Fields("daily").Value = Me.chkAgent.Checked
                    .Fields("ngay").Value = Me.txtinvoicedebit.Text
                    .Fields("ngayhoadon").Value = Me.txtinvoicenodebit.Text
                    .Fields("tigia").Value = Me.txtexdebit.Text
                    .Fields("debitcredit").Value = "Debit"
                    .Fields("soNgayCongNo").Value = Me.txthancongno.Text
                    Try
                        .Fields("stt").Value = Me.txtstt.Text
                    Catch ex As Exception

                    End Try
                    .Fields("showvnd").Value = Me.chkShowVND.Checked
                    .Fields("container").Value = Me.cboContainer.Text
                    Try
                        .Fields("freedem").Value = Me.txtfreeDEM.Text
                    Catch ex As Exception
                        .Fields("freedem").Value = "0"
                    End Try
                    Try
                        .Fields("freedet").Value = Me.txtfreeDET.Text
                    Catch ex As Exception
                        .Fields("freedet").Value = "0"
                    End Try

                    Try
                        .Fields("unitprice_").Value = Me.txtunitpricedebit_.Text
                    Catch ex As Exception

                    End Try
                    Try
                        .Fields("price_").Value = Me.txtpricedebit_.Text
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
            profit()
            profit_theonguyente()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub addluoicont()
        Try
            Dim i As Integer
            Dim tongcbm As Double = 0
            Dim tongkgs As Double = 0
            Dim giatri As Double = 0
            ' debitnoixuat
            If Me.dgdContainers.Rows.Count > 0 Then
                Me.cboContainer.Items.Clear()
                Me.cbocontainerCredit.Items.Clear()



                For i = 0 To Me.dgdContainers.Rows.Count - 1
                    addcont(Me.cboContainer, Me.dgdContainers.Item("containerNo", i).Value.ToString + "-" + Me.dgdContainers.Item("containerType", i).Value.ToString)
                    addcont(Me.cbocontainerCredit, Me.dgdContainers.Item("containerNo", i).Value.ToString + "-" + Me.dgdContainers.Item("containerType", i).Value.ToString)

                    'Try
                    '    tongcbm += Me.dgdContainers.Item("sokhoi", i).Value.ToString
                    'Catch ex As Exception

                    'End Try


                    'Try
                    '    tongkgs += Me.dgdContainers.Item("sokg", i).Value.ToString
                    'Catch ex As Exception

                    'End Try


                Next
                'giatri = tongcbm
                'tongkgs = tongkgs / 1000
                'If tongcbm > tongkgs Then
                '    giatri = tongcbm
                'Else
                '    giatri = tongkgs
                'End If
            End If
            'If Me.txtunitdebit.Text = "CBM" Then
            '    Me.txtquantitydebit.Text = giatri
            'Else
            '    Me.txtquantitydebit.Text = 1
            'End If

            'If Me.txtunitcredit.Text = "CBM" Then
            '    Me.txtquantitycredit.Text = giatri
            'Else
            '    Me.txtquantitycredit.Text = 1
            'End If


        Catch ex As Exception

        End Try
    End Sub
    Public Sub addcont(ByVal cbo As Object, ByVal socont As String)
        Try

            Dim oItem As PDSAListItemString
            oItem = New PDSAListItemString
            oItem.Value = Trim(socont)
            oItem.ID = Trim(socont)

            cbo.Items.Add(oItem)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtunitpricedebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunitpricedebit.Leave
        Try
            If Me.chkmanual.Checked = False Then
                Me.txtunitpricedebit.Text = FormatNumber(Me.txtunitpricedebit.Text, 2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricedebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitpricedebit.TextChanged
        Try
            If Me.chkmanual.Checked = False Then
                Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit.Text) * CDbl(Me.txtquantitydebit.Text), 3)
                'txtexdebit_TextChanged(sender, e)
                'txttaxdebit_TextChanged(sender, e)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttaxdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkmanual.Checked = False Then
                '  Me.txtpricetaxdebit.Text = FormatNumber(CDbl(Me.txtpricenotaxdebit.Text) * CDbl(Me.txttaxdebit.Text) / 100, 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)


                Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtpricetaxdebit.Text) + CDbl(Me.txtpricenotaxvnddebit.Text), 3)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricetaxdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricetaxdebit.TextChanged

    End Sub

    Private Sub cmdnguocdebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnguocdebit.Click
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



            'Me.txtpricenotaxvnddebit.Text = tam 'FormatNumber(CDbl(Me.txtpricedebit.Text) / (CDbl(Me.txttaxdebit.Text) / 100 + 1), 0)
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

    Private Sub txtexdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtexdebit.TextChanged
        Try
            'If Me.chkmanual.Checked = False Then
            '    Me.txtpricenotaxvnddebit.Text = FormatNumber(CDbl(Me.txtpricenotaxdebit.Text), 3)
            '    txttaxdebit_TextChanged(sender, e)
            'End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub profit_theonguyente()
        Try
            Dim i, j As Integer
            Dim tongdebittruocthue As Double
            Dim tongdebittruocthuevnd As Double
            For i = 0 To Me.dgddebitGrid.Rows.Count - 1
                Try
                    If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "USD" Then
                        '    tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) * CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
                        'Else
                        tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit_", i).Value)
                    End If

                Catch ex As Exception

                End Try

                If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "VND" Then
                    '    tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) / CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
                    'Else
                    tongdebittruocthuevnd += CDbl(Me.dgddebitGrid.Item("price_debit_", i).Value)
                End If

            Next

            Dim tongcredittruocthue As Double
            Dim tongcredittruocthuevnd As Double
            For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
                Try
                    If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "USD" Then
                        '    tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) * CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
                        'Else
                        tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / ((CDbl(Me.dgdCreditGrid.Item("taxprice_credit", i).Value) / 100) + 1)
                    End If

                Catch ex As Exception

                End Try
                Try
                    If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "VND" Then
                        '    tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
                        'Else
                        tongcredittruocthuevnd += (CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / ((CDbl(Me.dgdCreditGrid.Item("taxprice_credit", i).Value) / 100) + 1))
                    End If

                Catch ex As Exception

                End Try
            Next
            Try

                Me.txttotaldebitusd.Text = FormatNumber(tongdebittruocthue.ToString, 2)
            Catch ex As Exception

            End Try
            Try
                Me.txttotalcreditusd.Text = FormatNumber(tongcredittruocthue.ToString, 2)
            Catch ex As Exception

            End Try

            Try
                Me.txttotaldebitvnd.Text = FormatNumber(tongdebittruocthuevnd.ToString, 2)
            Catch ex As Exception

            End Try
            Try
                Me.txttotalcreditvnd.Text = FormatNumber(tongcredittruocthuevnd.ToString, 2)
            Catch ex As Exception

            End Try
            Try
                Me.txtprofittotalusd.Text = FormatNumber(CDbl(tongdebittruocthue) - CDbl(tongcredittruocthue), 2)
            Catch ex As Exception

            End Try

            Try
                Me.txtprofittotalvnd.Text = FormatNumber(CDbl(tongdebittruocthuevnd) - CDbl(tongcredittruocthuevnd), 2)
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
        'Try
        '    Dim i, j As Integer
        '    Dim tongdebittruocthue As Double
        '    Dim tongdebittruocthuevnd As Double
        '    For i = 0 To Me.dgddebitGrid.Rows.Count - 1
        '        Try
        '            If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "USD" Then
        '                '    tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) * CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
        '                'Else
        '                tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value)
        '            End If

        '        Catch ex As Exception

        '        End Try

        '        If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "VND" Then
        '            '    tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) / CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
        '            'Else
        '            tongdebittruocthuevnd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value)
        '        End If

        '    Next

        '    Dim tongcredittruocthue As Double
        '    Dim tongcredittruocthuevnd As Double
        '    For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
        '        Try
        '            If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "USD" Then
        '                '    tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) * CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
        '                'Else
        '                tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value)
        '            End If

        '        Catch ex As Exception

        '        End Try
        '        Try
        '            If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "VND" Then
        '                '    tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
        '                'Else
        '                tongcredittruocthuevnd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value)
        '            End If

        '        Catch ex As Exception

        '        End Try
        '    Next
        '    Try

        '        Me.txttotaldebitusd.Text = FormatNumber(tongdebittruocthue.ToString, 2)
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        Me.txttotalcreditusd.Text = FormatNumber(tongcredittruocthue.ToString, 2)
        '    Catch ex As Exception

        '    End Try

        '    Try
        '        Me.txttotaldebitvnd.Text = FormatNumber(tongdebittruocthuevnd.ToString, 2)
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        Me.txttotalcreditvnd.Text = FormatNumber(tongcredittruocthuevnd.ToString, 2)
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        Me.txtprofittotalusd.Text = FormatNumber(CDbl(tongdebittruocthue) - CDbl(tongcredittruocthue), 2)
        '    Catch ex As Exception

        '    End Try

        '    Try
        '        Me.txtprofittotalvnd.Text = FormatNumber(CDbl(tongdebittruocthuevnd) - CDbl(tongcredittruocthuevnd), 2)
        '    Catch ex As Exception

        '    End Try

        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub AddToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem2.Click
        Try
            Try
                'allCus()
                Me.cbocontainerCredit.Text = ""
                addluoicont()
                Dim ApproveCreditNote As Boolean
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'vitri = index
                'If index >= 0 Then
                '    ApproveCreditNote = Me.dgdCreditGrid.Item("ApproveCredit", index).Value
                'End If
                If mStatusCredit = "Normal" And UserRight("mnuOutbound", "Edit") Then

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

                    mCreditId = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusCredit = "Add"
                    Me.txtexcredit.Text = getCur("USD")
                Else
                    DisplayMessage(True, "You are in " + mStatusCredit + "/ Approve status.")
                    ' DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

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
            addluoicont()
            If Me.dgdCreditGrid.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.dgdCreditGrid.CurrentRow.Index
            Approve = Me.dgdCreditGrid.Item("ApproveCredit", index).Value
            vitri = index
            If index >= 0 Then

                If mStatusCredit = "Normal" And Not Approve And UserRight("mnuoutbound", "Edit") Then

                    Me.cmdok_credit.Enabled = True

                    mCreditId = Me.dgdCreditGrid.Item("outboundfreightID_credit", index).Value.ToString
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
                    DisplayMessage(True, "You are in " + mStatusCredit + "/ Approve status.")
                    ' DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem2.Click
        Try
            If Me.dgdCreditGrid.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer =
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

    Private Sub cmdcancel_credit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel_credit.Click
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

    Private Sub cmdok_credit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok_credit.Click
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
                    copyHistory("outboundfreight", "outboundfreightid", mCreditId, "history")
                Catch ex As Exception

                End Try
                ' them container
                '=========='
                strQuery = "Select * From outboundfreight Where outboundfreightid='" & mCreditId & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("outboundfreightID").Value = NewId()
                        .Fields("outboundID").Value = getID(mOutboundID)
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
                    .Fields("container").Value = Me.cbocontainerCredit.Text
                    Try
                        .Fields("freedem").Value = Me.txtfreedemcredit.Text
                    Catch ex As Exception
                        .Fields("freedem").Value = "0"
                    End Try
                    Try
                        .Fields("freedet").Value = Me.txtfreedetcredit.Text
                    Catch ex As Exception
                        .Fields("freedet").Value = "0"
                    End Try
                    .Fields("showvnd").Value = Me.chkShowVND_Credit.Checked
                    .Update()
                End With
                rs.Close()

            End If
            mStatusCredit = "Normal"
            Me.cmdok_credit.Enabled = False
            Me.cmdcancel_credit_Click(sender, e)
            Me.QueryCredit()
            profit()
            profit_theonguyente()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricecredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtunitpricecredit.Leave
        Try
            Try
                Dim strMesg As String
                ' dem so luong hbl
                Dim sql As String
                Dim slhbl As Integer = 0
                Dim ds As New DataSet
                If Me.txtRef.Text <> "" Then
                    sql = "select Count(*) as dem from outbound where ref ='" & Me.txtRef.Text.Trim & "' "
                    ds = ReadDataSet(sql)
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            slhbl = CInt(ds.Tables(0).Rows(0).Item("dem").ToString)
                        Catch ex As Exception
                            slhbl = 1
                        End Try

                    End If
                Else
                    slhbl = 1
                End If

                If Me.chklcl.Checked = True Then
                    strMesg = "Bạn muốn chia theo số lượng " + slhbl.ToString + " HBL.?"
                    If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                        If txtcurrcredit.Text.Trim <> "VND" Then
                            Me.txtunitpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) / slhbl, 3)
                        Else
                            Me.txtunitpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) / slhbl, 0)

                        End If

                    End If
                Else

                End If
            Catch ex As Exception

            End Try
            ' If Me.chkManualCredit.Checked = False Then
            'Me.txtunitpricecredit.Text = FormatNumber(Me.txtunitpricecredit.Text, 2)
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricecredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitpricecredit.TextChanged
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 3)
                'txtexcredit_TextChanged(sender, e)
                'txttaxcredit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricenotaxdebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricenotaxdebit.TextChanged

    End Sub

    Private Sub cmdnguoccredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnguoccredit.Click
        Try
            'Dim tam As Double = 0
            'Try
            '    tam = CDbl(txtpricecredit.Text)
            'Catch ex As Exception

            'End Try
            'Dim txtpricetaxcredit_, txtpricenotaxvndcredit_, txtpricenotaxcredit_, txtunitpricecredit_ As Double

            'txtpricetaxcredit_ = FormatNumber(tam - (CDbl(txtpricecredit.Text) / ((CDbl(Me.txttaxcredit.Text / 100)) + 1)), 4)
            'txtpricenotaxvndcredit_ = FormatNumber(tam - CDbl(txtpricetaxcredit_), 4)
            'txtpricenotaxcredit_ = FormatNumber(CDbl(txtpricenotaxvndcredit_) / CDbl(Me.txtexcredit.Text), 4)
            'txtunitpricecredit_ = FormatNumber(txtpricenotaxcredit_ / CDbl(Me.txtquantitycredit.Text), 4)
            'Me.txtunitpricecredit.Text = FormatNumber(txtunitpricecredit_, 4)
            ' lay gia co thue- thue= gia truoc thue
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

    Private Sub txtexcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtexcredit.TextChanged
        Try
            'If Me.chkManualCredit.Checked = False Then
            '    Me.txtpricenotaxvndcredit.Text = FormatNumber(CDbl(Me.txtpricenotaxcredit.Text), 3)
            '    txttaxcredit_TextChanged(sender, e)
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricenotaxvnddebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricenotaxvnddebit.TextChanged

    End Sub

    Private Sub txtpricenotaxvndcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricenotaxvndcredit.TextChanged

    End Sub

    Private Sub txttaxcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricetaxcredit.Text = FormatNumber(CDbl(Me.txtpricenotaxcredit.Text) * CDbl(Me.txttaxcredit.Text) / 100, 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)


                Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtpricetaxcredit.Text) + CDbl(Me.txtpricenotaxvndcredit.Text), 3)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage14.Click

    End Sub

    Private Sub txteta_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txteta.Leave
        Try
            Me.txteta.Text = ddMMMyyyy(Me.txteta.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txteta_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txteta.MaskInputRejected

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitemdebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboitemdebit.Leave
        Try
            ' ;lay gia tien
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from charge where charge_id='" & FindValueID(Me.cboitemdebit, Me.cboitemdebit.Text) & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                'Me.txtquantitydebit.Text = 1
                'If Me.chkfcl.Checked = True Then
                '    Me.txtunitpricedebit.Text = ds.Tables(0).Rows(0).Item("tariffFCL").ToString
                'End If
                'If Me.chklcl.Checked = True Then
                '    Me.txtunitpricedebit.Text = ds.Tables(0).Rows(0).Item("tariffLCL").ToString
                'End If
                Me.txtunitdebit.Text = ds.Tables(0).Rows(0).Item("unit").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitemdebit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboitemdebit.SelectedIndexChanged

    End Sub

    Private Sub cboitemdebit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboitemdebit.TextChanged

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.txtShipper.Text = Me.cboShipper.Text
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.txtConsignee.Text = Me.cboConsignee.Text '  Me.txtNotify.Text = Me.cboNotify.Text
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.txtNotify.Text = Me.cboNotify.Text ' Me.txtConsignee.Text = Me.cboConsignee.Text
    End Sub

    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click


    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoktheodoi.Click
        Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset


                If mStatusTheodoi = "Add" Or mStatusTheodoi = "Edit" Then
                    Try
                        copyHistory("theodoilohang", "theodoilohangid", mTheodoiid, "history")
                    Catch ex As Exception

                    End Try
                    ' them container
                    '=========='
                    strQuery = "Select * From theodoilohang Where theodoilohangid='" & mTheodoiid & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("theodoilohangid").Value = NewId()
                            .Fields("outboundID").Value = getID(mOutboundID)
                        End If


                        '-------------------------------container

                        .Fields("items").Value = Me.cboitems.Text
                        .Fields("remarks").Value = Me.txtRemarks_theodoi.Text
                        .Fields("timer").Value = Me.txtTimer.Text
                        .Fields("validuser").Value = Me.txtValidUser.Text
                        Try
                            .Fields("ngaychungtu").Value = Me.txtngaychungtu.Text
                            .Fields("bangoc").Value = Me.txtbangoc.Text
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



    Private Sub AddToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem3.Click
        Try
            Try
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusTheodoi = "Normal" And UserRight("mnuOutbound", "Edit") Then

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

                If mStatusTheodoi = "Normal" And UserRight("mnuoutbound", "Edit") Then

                    Me.cmdoktheodoi.Enabled = True

                    mTheodoiid = Me.dgdtheodoi.Item("theodoilohangid", index).Value.ToString
                    mStatusTheodoi = "Edit"

                    RefreshDatatheodoigrid(index)

                    'Me.QueryContainer()
                    Me.cboitems.Enabled = True

                    Me.txtValidUser.Enabled = True
                    Me.txtRemarks_theodoi.Enabled = True
                    Me.txtTimer.Enabled = True


                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem3.Click
        Try
            If Me.dgdtheodoi.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer =
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
        If Not UserRight("mnuoutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Theo dõi : " & Me.dgdtheodoi.Item("items", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then

                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from theodoilohang where theodoilohangid= '" & Me.dgdtheodoi.Item("theodoilohangid", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
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

    Private Sub Button19_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            ' sql = " select * from Outboundfreight WHERE bookingid='" & FindValueID(Me.cboquotationNo, Me.cboquotationNo.Text) & "'  "
            ' ds = ReadDataSet(sql)

            ' If ds.Tables(0).Rows.Count > 0 Then
            'If ds.Tables(0).Rows(0).Item("outboundid").ToString <> DefaultValue Then
            '    DisplayMessage(True, "Shipment Profit đã được Get vào HBL !")
            '    Exit Sub
            'End If
            'If "{" + ds.Tables(0).Rows(0).Item("bookingid").ToString + "}" <> DefaultValue Then
            'DisplayMessage(True, "Booking (Debit) đã được thêm vào HBL.")
            'Exit Sub
            ' End If
            ' End If
            '---------------------------------


            '-----------------
            ' otherdebit1-12 tu containeroutboundnotify

            '------otherdebit agent
            '------------------------------------------------

            Me.Querydebit()
            InsertAutoNumberToGrid(Me.dgddebitGrid)
            Me.QueryCredit()
            InsertAutoNumberToGrid(Me.dgdCreditGrid)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub BookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try

                Dim chk As Integer
                chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If chk = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If
                If Me.dgdHBL.RowCount > 0 Then
                    Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                    gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString



                    If LoginSucceeded = True Then
                        Dim form As New frmBooking 'frmPrintBillSEAOriginal 'frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    '  VB6.ShowForm(frmBooking, VB6.FormShowConstants.Modal, Me)
                End If


            Catch ex As Exception
                MsgBox(msgErr(Me, Err.Description))
            End Try
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


            Dim Approve, EditTable, UsrRight As Boolean
            Me.TabControl1.BringToFront()
            'kiểm tra xem Grid có dữ liệu không
            Dim sqlkt As String
            Dim dskt As New DataSet

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
                If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnuOutbound", "Edit") Then
                    'Me.dgdPort.Height = 306
                    'Me.dgdPort.Enabled = False
                    'Me.txtPortCode.Enabled = False
                    Me.TabControl1.Visible = True
                    ReFormat()
                    'SetMenu((False))

                    mOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

                    '' lay id de kiem tra
                    sqlkt = "select * from billonline where id='" & mOutboundID & "'"
                    dskt = ReadDataSet(sqlkt)
                    If dskt.Tables(0).Rows.Count > 0 Then
                        DisplayMessage(True, "Sorry, Lô hàng được khóa bởi User : " + dskt.Tables(0).Rows(0).Item("userupdate").ToString)
                        Exit Sub

                    End If
                    Me.TabControl1.Enabled = True
                    ' insertvao billonline
                    Dim strQuery As String
                    Dim rs As New ADODB.Recordset
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM billonline  "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("editid").Value = NewId()
                        .Fields("id").Value = "{" + mOutboundID + "}"
                        .Update()

                    End With
                    rs.Close()

                    '-------------------
                    mStatus = "Edit"
                    Me.cmdOK.Enabled = True
                    Me.cmdOKAll.Enabled = True
                    Me.dgdHBL.Enabled = False
                    '---------------------------
                    reText(mStatus)
                    RefreshData(index)
                    QueryHinhanh()
                    Querythemhinh()
                    QueryContainer()
                    Querydebit()
                    QueryCredit()
                    Querytheodoi()
                    QueryPackage()
                    showcontPack()
                    QueryCashloan()
                    SI()
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
            profit()
            profit_theonguyente()
            Button21_Click(sender, e)
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Public Sub showcontPack()
        Try
            ' show con
            Dim id, value, strSQL As String
            ' lay cont vao cbopack
            cbocontPack.Items.Clear()
            id = "outboundContainersID"
            value = "ContainerNo"
            strSQL = "Select outboundcontainersid ,containerno From containertype where outboundid='" & mOutboundID & "'  "
            loadDataToObject(Me.cbocontPack, strSQL, id, value)
            '  loadDataToObject(Me.cbocont3d, strSQL, id, value)
            '---------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Function showcontPackUsed() As Double
        Try
            Try
                Dim sql As String
                Dim cbm As Double
                Dim ds As New DataSet
                Dim i As Integer
                cbm = 0
                sql = "select * from freighttariff where contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1


                        Try
                            cbm += ds.Tables(0).Rows(i).Item("tongkhoikien").ToString

                        Catch ex As Exception

                        End Try
                    Next
                End If
                Return cbm
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Function
    Public Function showcontChuviUsed() As Double
        Try
            Try
                Dim sql As String
                Dim cbm As Double
                Dim ds As New DataSet
                Dim i As Integer
                Dim chuvixepchong As Double = 0
                Dim chuviKhongxepchong As Double = 0
                cbm = 0
                sql = "select * from freighttariff where contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1

                        If ds.Tables(0).Rows(i).Item("xepchong").ToString = "True" Then
                            chuvixepchong += (CDbl(ds.Tables(0).Rows(i).Item("daikien").ToString) + CDbl(ds.Tables(0).Rows(i).Item("rongkien").ToString)) * 2
                        Else
                            chuviKhongxepchong += (CDbl(ds.Tables(0).Rows(i).Item("daikien").ToString) + CDbl(ds.Tables(0).Rows(i).Item("rongkien").ToString)) * 2

                        End If
                        Try
                            cbm += ds.Tables(0).Rows(i).Item("tongkhoikien").ToString

                        Catch ex As Exception

                        End Try
                    Next
                End If
                Me.txtchuviXepChongused.Text = FormatNumber(chuviKhongxepchong, 3)
                Me.txtchuviKhongXepChongused.Text = FormatNumber(chuvixepchong, 3)
                Me.txtchuviremain.Text = FormatNumber(CDbl(Me.txtchuviavailable.Text) - CDbl(Me.txtchuviXepChongused.Text))
                Return cbm
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Function
    Private Sub cmdcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcode.Click
        Try

            Dim id, value, strSQL As String
            Me.cboCustomerShipper.Items.Clear()
            Me.cboCustomerShipper.Text = ""
            id = "Customer_id"
            value = "Company"
            strSQL = "Select Customer_id,  company From customer  where company like '%" & Me.txtcode.Text.Trim & "%'  and continued=1 Order By company" ' and maincode like '%" & Me.cboSCN.Text & "%'
            loadDataToObject_(Me.cboCustomerShipper, strSQL, id, value)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdchonShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdchonShipper.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from customer where company='" & Me.cboCustomerShipper.Text & "'"
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocusdebit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocusdebit.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            ' Dim tong As Double = 0
            'tong = tienCongno(FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text), "A")

            sql = "select * from customer where customer_id = '" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    Me.txthancongno.Text = ds.Tables(0).Rows(0).Item("hancongno").ToString
                Catch ex As Exception

                End Try
                If ds.Tables(0).Rows(0).Item("Remarks_sale").ToString <> "" Then

                    DisplayMessage(True, ds.Tables(0).Rows(0).Item("Remarks_sale").ToString)
                End If
                'Try
                '    If tong >= CDbl(ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString) Then
                '        DisplayMessage(True, "Hạn công nợ đã vượt quá.!")
                '        Exit Sub
                '    End If
                'Catch ex As Exception

                'End Try

            End If
        Catch ex As Exception

        End Try
        Try
            Try
                Try

                    Dim i, j As Integer
                    Dim currow, lap As Integer
                    Dim sql As String
                    Me.GroupBox16.Visible = True
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
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'  AND department='Agency-Export' and '" & ddMMMyyyy(Me.dtpDateReport.Value.Date) & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE' order by charge_code "
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
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where no='TEMPLETE' AND department='Agency-Export' "
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

    Private Sub cbocusdebit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocusdebit.SelectedIndexChanged

    End Sub
    Public Sub profit()
        Try
            Dim i, j As Integer
            Dim tongdebittruocthue As Double
            Dim tongdebittruocthueusd As Double
            For i = 0 To Me.dgddebitGrid.Rows.Count - 1
                Try
                    If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "USD" Then
                        tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit_", i).Value) * CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
                    Else
                        tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit_", i).Value)
                    End If

                Catch ex As Exception

                End Try

                If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "VND" Then
                    tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit_", i).Value) / CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
                Else
                    tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit_", i).Value)
                End If

            Next

            Dim tongcredittruocthue As Double
            Dim tongcredittruocthueusd As Double
            For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
                Try
                    If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "USD" Then
                        tongcredittruocthue += (CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / ((CDbl(Me.dgdCreditGrid.Item("taxprice_credit", i).Value) / 100) + 1)) * CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
                    Else
                        tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / ((CDbl(Me.dgdCreditGrid.Item("taxprice_credit", i).Value) / 100) + 1)
                    End If

                Catch ex As Exception

                End Try
                Try
                    If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "VND" Then
                        tongcredittruocthueusd += (CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / ((CDbl(Me.dgdCreditGrid.Item("taxprice_credit", i).Value) / 100) + 1)) / CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
                    Else
                        tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / ((CDbl(Me.dgdCreditGrid.Item("taxprice_credit", i).Value) / 100) + 1)
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
        'Try
        '    Dim i, j As Integer
        '    Dim tongdebittruocthue As Double
        '    Dim tongdebittruocthueusd As Double
        '    For i = 0 To Me.dgddebitGrid.Rows.Count - 1
        '        Try
        '            If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "USD" Then
        '                tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) * CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
        '            Else
        '                tongdebittruocthue += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value)
        '            End If

        '        Catch ex As Exception

        '        End Try

        '        If UCase(Me.dgddebitGrid.Item("currency_debit", i).Value) = "VND" Then
        '            tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value) / CDbl(Me.dgddebitGrid.Item("tigia_debit", i).Value)
        '        Else
        '            tongdebittruocthueusd += CDbl(Me.dgddebitGrid.Item("price_debit", i).Value)
        '        End If

        '    Next

        '    Dim tongcredittruocthue As Double
        '    Dim tongcredittruocthueusd As Double
        '    For i = 0 To Me.dgdCreditGrid.Rows.Count - 1
        '        Try
        '            If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "USD" Then
        '                tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) * CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
        '            Else
        '                tongcredittruocthue += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value)
        '            End If

        '        Catch ex As Exception

        '        End Try
        '        Try
        '            If UCase(Me.dgdCreditGrid.Item("currency_credit", i).Value) = "VND" Then
        '                tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value) / CDbl(Me.dgdCreditGrid.Item("tigia_credit", i).Value)
        '            Else
        '                tongcredittruocthueusd += CDbl(Me.dgdCreditGrid.Item("price_credit", i).Value)
        '            End If

        '        Catch ex As Exception

        '        End Try
        '    Next






        '    Try
        '        Me.txttongthu.Text = FormatNumber(tongdebittruocthue.ToString, 0)
        '        Me.txttongthuusd.Text = FormatNumber(tongdebittruocthueusd.ToString, 2)
        '    Catch ex As Exception

        '    End Try
        '    Try
        '        Me.txttongchi.Text = FormatNumber(tongcredittruocthue.ToString, 0)
        '        Me.txttongchiusd.Text = FormatNumber(tongcredittruocthueusd.ToString, 2)

        '    Catch ex As Exception

        '    End Try
        '    Try
        '        Me.txtprofit.Text = FormatNumber(tongdebittruocthue - tongcredittruocthue, 0)
        '        Me.txtprofitusd.Text = FormatNumber(tongdebittruocthueusd - tongcredittruocthueusd, 2)

        '    Catch ex As Exception

        '    End Try
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub chkprint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkprint.CheckedChanged

    End Sub

    Private Sub txtetd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtetd.Leave
        Try
            Me.txtetd.Text = chuyenNgay(Me.txtetd.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtetd_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtetd.MaskInputRejected

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
                gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString



                If LoginSucceeded = True Then
                    Dim form As New frmPrintOutboundCoversheet 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '  VB6.ShowForm(frmPrintOutboundCoversheet, VB6.FormShowConstants.Modal, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub JobProfitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobProfitToolStripMenuItem.Click
        Try
            If UCase(gDepartment) = "DOCUMENT" Or UCase(gDepartment) = "OPERATION" Then
                'Me.TabPage3.Text = "Credit (Administrator)"
                'Me.TabPage6.Text = "Credit (sale)"
                ' Me.chkClockCredit.Visible = True
                'DisplayMessage(True, "Bạn không có quyền.!")
                'Exit Sub

            End If
            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString


                gPrintOutbound = "Outbound"
                gDebitOutbound = "Outbound"
                If LoginSucceeded = True Then
                    Dim form As New frmPrintOutboundJobprofit 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '  VB6.ShowForm(frmPrintOutboundJobprofit, VB6.FormShowConstants.Modal, Me)
            End If
        Catch ex As Exception

        End Try
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

    Private Sub ExportEDI95BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportEDI95BToolStripMenuItem.Click
        Try

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

    Private Sub txtquantitydebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantitydebit.TextChanged
        'Try
        '    If Me.chkmanual.Checked = False Then
        '        Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit.Text) * CDbl(Me.txtquantitydebit.Text), 3)
        '        ' txtexdebit_TextChanged(sender, e)
        '        ' txttaxdebit_TextChanged(sender, e)
        '    End If

        'Catch ex As Exception

        'End Try
        Try
            Try
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

    Private Sub txtquantitycredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquantitycredit.TextChanged
        Try
            If Me.chkManualCredit.Checked = False Then
                Me.txtpricecredit.Text = FormatNumber(CDbl(Me.txtunitpricecredit.Text) * CDbl(Me.txtquantitycredit.Text), 3)
                'txtexcredit_TextChanged(sender, e)
                'txttaxcredit_TextChanged(sender, e)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtContainerNo1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtContainerNo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgdContainers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainers.CellContentClick

    End Sub

    Private Sub txtCaoPalet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCaoPalet.TextChanged

    End Sub

    Private Sub txtType1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtType1.SelectedIndexChanged
        Try
            If Me.txtType1.Text = "20DC" Then
                Me.txtdai.Text = "5.898"
                Me.txtrong.Text = "2.352"
                Me.txtcao.Text = "2.395"

            End If

            If Me.txtType1.Text = "40DC" Then
                Me.txtdai.Text = "12.032"
                Me.txtrong.Text = "2.350"
                Me.txtcao.Text = "2.392"

            End If
            If Me.txtType1.Text = "40HC" Then
                Me.txtdai.Text = "12.023"
                Me.txtrong.Text = "2.532"
                Me.txtcao.Text = "2.698"

            End If
            If Me.txtType1.Text = "40RH" Then
                Me.txtrong.Text = "2.296"
                Me.txtcao.Text = " 2,521"
                Me.txtdai.Text = "11.572"



            End If
            If Me.txtType1.Text = "45HC" Then
                Me.txtrong.Text = "2.352"
                Me.txtcao.Text = "2.698"
                Me.txtdai.Text = "13.556"

            End If

            If Me.txtType1.Text = "20RF" Then
                Me.txtrong.Text = "2.286"
                Me.txtcao.Text = "2.265"
                Me.txtdai.Text = "5.485"

            End If

            If Me.txtType1.Text = "40RF" Then
                Me.txtrong.Text = "2.291"
                Me.txtcao.Text = "2.225"
                Me.txtdai.Text = "11.558"

            End If
            If Me.txtType1.Text = "20OT" Then
                Me.txtrong.Text = "2.348"
                Me.txtcao.Text = "2.360"
                Me.txtdai.Text = "5.900"

            End If


            If Me.txtType1.Text = "40OT" Then
                Me.txtrong.Text = "2.348"
                Me.txtcao.Text = "2.360"
                Me.txtdai.Text = "12.034"

            End If

            If Me.txtType1.Text = "20FR" Then
                Me.txtrong.Text = "2.347"
                Me.txtcao.Text = "2.259"
                Me.txtdai.Text = "5.883"

            End If

            If Me.txtType1.Text = "40FR" Then
                Me.txtrong.Text = "2.347"
                Me.txtcao.Text = "1.954"
                Me.txtdai.Text = "11.650"

            End If



            '20FR
            '40FR







        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            showcontPack()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocontPack_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocontPack.Leave
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                If Me.cbocontPack.Text = "" Then
                    Exit Sub
                End If
                sql = "select * from containertype where outboundContainersID='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    Try
                        Me.txtavailablecbm.Text = FormatNumber(ds.Tables(0).Rows(0).Item("tongkhoiavailable").ToString, 3)

                    Catch ex As Exception

                    End Try
                End If
                ' goi ham tinh usde
                Me.txtusedCBM.Text = FormatNumber(showcontPackUsed(), 3)
                Try
                    Me.txtremainCBM.Text = FormatNumber(CDbl(Me.txtavailablecbm.Text) - CDbl(Me.txtusedCBM.Text), 3)

                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
                sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
                sql &= "Where " &
                       " freighttariff.outboundID='" & mOutboundID & "'  and contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"
                oTblEquip = ReadTable(sql)
                Me.dgdpackage.DataSource = oTblEquip


                '--------------------
                Me.Cursor = System.Windows.Forms.Cursors.Default

                InsertAutoNumberToGrid(Me.dgdpackage)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
            showcontChuviUsed()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocontPack.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocontPack.TextChanged
        Try
            Dim sql As String
            Dim ds As New DataSet
            If Me.cbocontPack.Text = "" Then
                Exit Sub
            End If
            sql = "select * from containertype where outboundContainersID='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    Me.txtavailablecbm.Text = FormatNumber(ds.Tables(0).Rows(0).Item("tongkhoiavailable").ToString, 3)
                    Try
                        Me.txtchuviavailable.Text = (CDbl(ds.Tables(0).Rows(0).Item("dai").ToString) + CDbl(ds.Tables(0).Rows(0).Item("rong").ToString)) * 2

                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                End Try
            End If
            ' goi ham tinh usde

            Me.txtusedCBM.Text = FormatNumber(showcontPackUsed(), 3)
            Try
                Me.txtremainCBM.Text = FormatNumber(CDbl(Me.txtavailablecbm.Text) - CDbl(Me.txtusedCBM.Text), 3)

            Catch ex As Exception

            End Try
            Try
                sql = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
                sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
                sql &= "Where " &
                       " freighttariff.outboundID='" & mOutboundID & "'  and contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"
                oTblEquip = ReadTable(sql)
                Me.dgdpackage.DataSource = oTblEquip


                '--------------------
                Me.Cursor = System.Windows.Forms.Cursors.Default

                InsertAutoNumberToGrid(Me.dgdpackage)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
            showcontChuviUsed()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage9.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdpackage.CellContentClick

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim i As Integer

            If mStatuspackage = "Edit" Then
                ' them container
                '=========='
                strQuery = "Select * From freighttariff Where freighttariffid='" & mOutboundPackageID & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("freighttariffid").Value = NewId()
                    End If

                    .Fields("outboundID").Value = getID(mOutboundID)
                    '-------------------------------container
                    .Fields("contid").Value = "{" + FindValueID(Me.cbocontPack, Me.cbocontPack.Text) + "}"
                    '------------------------------------------
                    .Fields("cusid").Value = "{" + FindValueID(Me.cboCusPackage, Me.cboCusPackage.Text) + "}"


                    '------------------------------------------------------------------------------------
                    .Fields("soluongkien").Value = Me.txtsoluongkien.Text

                    '-------------------------------------------------------------------------------

                    '---------------------------------------------------------------------

                    ' .Fields("kgavailable").Value = Me.txtChargeA.Text
                    ' .Fields("path").Value = Me.cboduongdan.Text
                    ' luu tinh khoi
                    If Me.txtdaikien.Text = "" Then
                        Me.txtdaikien.Text = 0
                    End If

                    If Me.txtrongkien.Text = "" Then
                        Me.txtrongkien.Text = 0
                    End If
                    If Me.txtcaokien.Text = "" Then
                        Me.txtcaokien.Text = 0
                    End If

                    If Me.txtsaiso.Text = "" Then
                        Me.txtsaiso.Text = 0
                    End If

                    .Fields("daikien").Value = FormatNumber(Me.txtdaikien.Text, 3)
                    .Fields("rongkien").Value = FormatNumber(Me.txtrongkien.Text, 3)
                    .Fields("caokien").Value = FormatNumber(Me.txtcaokien.Text, 3)
                    .Fields("saiso").Value = FormatNumber(Me.txtsaiso.Text, 3)
                    Try
                        .Fields("tongkhoikien").Value = (CDbl(Me.txtrongkien.Text) + (CDbl(Me.txtsaiso.Text))) * (CDbl(Me.txtdaikien.Text) + (CDbl(Me.txtsaiso.Text))) * (CDbl(Me.txtcaokien.Text) + (CDbl(Me.txtsaiso.Text)))
                    Catch ex As Exception

                    End Try
                    .Fields("xepchong").Value = Me.chkxepChong.Checked


                    .Fields("loaikien").Value = Me.txtloaikien.Text
                    .Fields("ghichu").Value = Me.txtghichukien.Text
                    .Fields("vitri").Value = Me.txtlocationPack.Text
                    .Fields("weight").Value = Me.txtweightPack.Text

                    .Update()
                End With
                rs.Close()
                If kiemtraFull() = True Then
                    DisplayMessage(True, "xin kiểm tra lại thông số kích thước.!")

                End If
            End If
            ' them tung kien
            If mStatuspackage = "Add" Then
                ' them container
                '=========='
                For i = 0 To CDbl(Me.txtsoluongkien.Text) - 1


                    strQuery = "Select * From freighttariff "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("freighttariffid").Value = NewId()
                        .Fields("outboundID").Value = getID(mOutboundID)
                        '-------------------------------container
                        .Fields("contid").Value = "{" + FindValueID(Me.cbocontPack, Me.cbocontPack.Text) + "}"
                        '------------------------------------------
                        .Fields("cusid").Value = "{" + FindValueID(Me.cboCusPackage, Me.cboCusPackage.Text) + "}"


                        '------------------------------------------------------------------------------------
                        .Fields("soluongkien").Value = "1"

                        '-------------------------------------------------------------------------------

                        '---------------------------------------------------------------------

                        ' .Fields("kgavailable").Value = Me.txtChargeA.Text
                        ' .Fields("path").Value = Me.cboduongdan.Text
                        ' luu tinh khoi
                        If Me.txtdaikien.Text = "" Then
                            Me.txtdaikien.Text = 0
                        End If

                        If Me.txtrongkien.Text = "" Then
                            Me.txtrongkien.Text = 0
                        End If
                        If Me.txtcaokien.Text = "" Then
                            Me.txtcaokien.Text = 0
                        End If

                        If Me.txtsaiso.Text = "" Then
                            Me.txtsaiso.Text = 0
                        End If

                        .Fields("daikien").Value = FormatNumber(Me.txtdaikien.Text, 3)
                        .Fields("rongkien").Value = FormatNumber(Me.txtrongkien.Text, 3)
                        .Fields("caokien").Value = FormatNumber(Me.txtcaokien.Text, 3)
                        .Fields("saiso").Value = FormatNumber(Me.txtsaiso.Text, 3)
                        Try
                            .Fields("tongkhoikien").Value = (CDbl(Me.txtrongkien.Text) + (CDbl(Me.txtsaiso.Text))) * (CDbl(Me.txtdaikien.Text) + (CDbl(Me.txtsaiso.Text))) * (CDbl(Me.txtcaokien.Text) + (CDbl(Me.txtsaiso.Text)))
                        Catch ex As Exception

                        End Try
                        .Fields("xepchong").Value = Me.chkxepChong.Checked


                        .Fields("loaikien").Value = Me.txtloaikien.Text
                        .Fields("ghichu").Value = Me.txtghichukien.Text
                        .Fields("vitri").Value = Me.txtlocationPack.Text
                        .Fields("weight").Value = Me.txtweightPack.Text

                        .Update()
                    End With
                    rs.Close()
                    If kiemtraFull() = True Then
                        DisplayMessage(True, "Hệ thống không cho phép thêm kiện hàng.!")
                        Exit For
                    End If
                Next
            End If
            '--------------------------
            mStatuspackage = "Normal"
            Me.Button22.Enabled = False
            Button21_Click(sender, e)
            Me.QueryPackage_()
            Me.cbocontPack_Leave(sender, e)
            ' kiem tra 
            kiemtraFull()
            '-----------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Function kiemtraFull() As Boolean
        Try
            ' lay so cont trong freighttariff , lay toan bo kien
            Dim sql As String
            Dim i As Integer
            Dim daiCont As Double = 0
            Dim rongCont As Double = 0
            Dim caoCont As Double = 0
            Dim khoiCont As Double = 0
            Dim chuviCont As Double = 0

            Dim daiTongKien As Double = 0
            Dim rongTongKien As Double = 0
            Dim caoTongKien As Double = 0
            Dim khoitongKien As Double = 0
            Dim chuvitongkien As Double = 0


            Dim ds As New DataSet
            ' lay dai,rong,cao cua cont
            Dim sqlCont As String
            Dim dsCont As New DataSet
            sqlCont = "select * from containertype where outboundcontainersid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"
            dsCont = ReadDataSet(sqlCont)
            If dsCont.Tables(0).Rows.Count > 0 Then
                daiCont = dsCont.Tables(0).Rows(0).Item("dai").ToString
                rongCont = dsCont.Tables(0).Rows(0).Item("rong").ToString
                caoCont = dsCont.Tables(0).Rows(0).Item("cao").ToString
                khoiCont = dsCont.Tables(0).Rows(0).Item("tongkhoiavailable").ToString
                chuviCont = (CDbl(dsCont.Tables(0).Rows(0).Item("dai").ToString) + CDbl(dsCont.Tables(0).Rows(0).Item("rong").ToString)) * 2

            End If

            '----------------------------------
            sql = " select * from freighttariff where contid='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"

            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i).Item("xepchong").ToString = "True" Then
                        chuvitongkien += (CDbl(ds.Tables(0).Rows(i).Item("daikien").ToString) + CDbl(ds.Tables(0).Rows(i).Item("rongkien").ToString) + CDbl(ds.Tables(0).Rows(i).Item("saiso").ToString)) * 2
                        khoitongKien += CDbl(ds.Tables(0).Rows(i).Item("tongkhoikien").ToString)
                    Else
                        khoitongKien += CDbl(ds.Tables(0).Rows(i).Item("tongkhoikien").ToString)
                    End If
                Next
            End If

            If ds.Tables(0).Rows(0).Item("xepchong").ToString = "True" Then
                If chuviCont <= chuvitongkien Then
                    DisplayMessage(True, "Lưu ý : mặt sàn các kiện hàng đã lắp đầy Container.!")
                    Return True
                End If
            Else
                ' khoi cont da tru palet
                If khoiCont <= khoitongKien Then
                    DisplayMessage(True, "Lưu ý : thể tích các kiện hàng đã lắp đầy Container.!")
                    Return True
                End If
            End If
            ' kiem tra
            Return False
        Catch ex As Exception

        End Try
    End Function
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Try

            mStatuspackage = "Normal"
            Me.Button22.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem4.Click
        Try
            Try
                'Dim index As Integer = Me.dgdpackage.CurrentRow.Index
                'If index >= 0 Then
                If mStatuspackage = "Normal" And UserRight("mnuOutbound", "Edit") Then

                    Me.Button22.Enabled = True
                    '--------------




                    '---------------------------

                    mOutboundPackageID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatuspackage = "Add"

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
            Try
                Dim Approve, EditTable, UsrRight As Boolean

                'kiểm tra xem Grid có dữ liệu không

                If Me.dgdpackage.RowCount = 0 Then
                    DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                    Return
                End If
                Dim index As Integer = Me.dgdpackage.CurrentRow.Index
                vitri = index
                If index >= 0 Then

                    If mStatuspackage = "Normal" And UserRight("mnuoutbound", "Edit") Then

                        Me.Button22.Enabled = True
                        mOutboundPackageID = Me.dgdpackage.Item("packid", index).Value.ToString
                        mStatuspackage = "Edit"

                        RefreshDataPack(index)

                        'Me.QueryContainer()
                        'Me.txtContainerNo1.Enabled = True

                        'Me.txtType1.Enabled = True

                        'Me.txtSeal1.Enabled = True


                        'Me.txtsoKien1.Enabled = True


                        'Me.txtPackages.Enabled = True


                        'Me.txtsoKg1.Enabled = True


                        'Me.txtChargeA.Enabled = True



                        'Me.txtCBM1.Enabled = True

                    Else
                        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem4.Click
        Try
            Try
                If Me.dgdpackage.Rows.Count = 0 Then
                    Return
                End If


                Dim selectedRowCount As Integer =
                     Me.dgdpackage.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If selectedRowCount = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If
                If selectedRowCount > 0 Then
                    Dim sb As New System.Text.StringBuilder()
                    Dim i As Integer
                    For i = 0 To selectedRowCount - 1
                        DeleterowPack(Me.dgdpackage.SelectedRows(i).Index)
                    Next i
                End If
                Me.QueryPackage_()
                Me.cbocontPack_Leave(sender, e)
                kiemtraFull()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip7_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip7.Opening

    End Sub
    Private mainCube As Object

    '----------------------

    Private drawOrigin As Point



    Private Sub Render()
        mainCube.RotateX = CSng(tX.Value)
        mainCube.RotateY = CSng(tY.Value)
        mainCube.RotateZ = CSng(tZ.Value)

        pictureBox1.Image = mainCube.DrawCube(drawOrigin)
    End Sub

    Private Sub tX_Scroll(ByVal sender As Object, ByVal e As EventArgs)
        Me.Refresh()
    End Sub

    Private Sub tY_Scroll(ByVal sender As Object, ByVal e As EventArgs)
        Me.Refresh()
    End Sub

    Private Sub tZ_Scroll(ByVal sender As Object, ByVal e As EventArgs)
        Me.Refresh()
    End Sub



    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        Render()
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("http://vckicks.110mb.com/")
    End Sub

    Private Sub chWires_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.DrawWires = chWires.Checked
        Me.Refresh()
    End Sub

    Private Sub chFront_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.FillFront = chFront.Checked
        Me.Refresh()
    End Sub

    Private Sub chBack_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.FillBack = chBack.Checked
        Me.Refresh()
    End Sub

    Private Sub chLeft_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.FillLeft = chLeft.Checked
        Me.Refresh()
    End Sub

    Private Sub chRight_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.FillRight = chRight.Checked
        Me.Refresh()
    End Sub

    Private Sub chTop_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.FillTop = chTop.Checked
        Me.Refresh()
    End Sub

    Private Sub chBottom_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        mainCube.FillBottom = chBottom.Checked
        Me.Refresh()
    End Sub
    '-------------------------
    Public zoom As Double = 50
    Public xCao As Double = 0
    Public yDai As Double = 0
    Public zRong As Double = 0
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Try
            tX.Value = 0
            tY.Value = 0
            tZ.Value = 0

            chWires.Checked = True
            chFront.Checked = False
            chBack.Checked = False
            chLeft.Checked = False
            chRight.Checked = False
            chTop.Checked = False
            chBottom.Checked = False
            ' lay cont
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from containertype where outboundContainersID='" & FindValueID(Me.cbocontPack, Me.cbocontPack.Text) & "'"
            ds = ReadDataSet(sql)


            Try
                zoom = CDbl(Me.cbozoom.Text)
            Catch ex As Exception

            End Try

            If ds.Tables(0).Rows.Count > 0 Then
                xCao = CDbl(ds.Tables(0).Rows(0).Item("cao").ToString) * zoom
                yDai = CDbl(ds.Tables(0).Rows(0).Item("dai").ToString) * zoom
                zRong = CDbl(ds.Tables(0).Rows(0).Item("rong").ToString) * zoom
            End If

            mainCube = New _DCubeNoGimbalLock.Math3D.Cube(zRong, xCao, yDai)
            ''Start over
            ''Me.Refresh()
            Render()
            'Me.PictureBox2.Width = zRong
            'Me.PictureBox2.Height = yDai
            'Me.PictureBox3.Width = yDai
            'Me.PictureBox3.Height = zRong
            'Me.PictureBox2.Image = Nothing
            'Me.PictureBox3.Image = Nothing
            'Me.PictureBox1.Visible = True
            'Me.PictureBox1.Refresh()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub tX_Scroll_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tX.Scroll
        'Try
        Render()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub tY_Scroll_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tY.Scroll
        'Try
        Render()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub tZ_Scroll_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tZ.Scroll
        'Try
        Render()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub chWires_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chWires.CheckedChanged
        Try
            mainCube.DrawWires = chWires.Checked
        Catch ex As Exception

        End Try

        Try
            Render()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chFront_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chFront.CheckedChanged
        Try
            mainCube.FillFront = chFront.Checked
        Catch ex As Exception

        End Try

        Try
            Render()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chBack_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chBack.CheckedChanged
        Try
            mainCube.FillBack = chBack.Checked

            Render()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chLeft_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chLeft.CheckedChanged
        Try
            mainCube.fillleft = chLeft.Checked

            Render()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chRight_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chRight.CheckedChanged
        Try
            mainCube.fillright = chRight.Checked

            Render()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chTop_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chTop.CheckedChanged
        Try
            mainCube.filltop = chTop.Checked

            Render()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chBottom_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chBottom.CheckedChanged
        Try
            mainCube.fillbottom = chBottom.Checked

            Render()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gFilling_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gFilling.Enter

    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Try
            Me.GroupBox13.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Try
            Me.GroupBox13.BringToFront()
            Me.GroupBox13.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox13_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox13.Enter

    End Sub

    Private Sub GroupBox13_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox13.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox13_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox13.MouseMove
        If Mdown Then
            Me.GroupBox13.Left = (e.X - X) + Me.GroupBox13.Left
            Me.GroupBox13.Top = (e.Y - Y) + Me.GroupBox13.Top
        End If
    End Sub

    Private Sub GroupBox13_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox13.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox13.Left = (e.X - X) + Me.GroupBox13.Left
            Me.GroupBox13.Top = (e.Y - Y) + Me.GroupBox13.Top
        End If
    End Sub
    Public pcx As Integer = 20
    Public pcarray(100) As PictureBox
    Private Sub View3DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles View3DToolStripMenuItem.Click
        Try
            Try
                Dim i, c As Integer
                Dim xcaoKien, ydaikien, zRongkien As Double
                Dim ds As New DataSet
                'Dim arr As System.Windows.Forms.PictureBox() = New PictureBox
                Try
                    zoom = Me.cbozoom.Text
                Catch ex As Exception
                    zoom = 50
                End Try
                Dim cube1 As Object

                '-----------------------
                'Try
                Dim ea, ea1 As Object
                ' PictureBox2_Paint(sender, ea)
                'PictureBox3_Paint(sender, ea1)


                '    Dim x As Integer = 10, y As Integer = 10
                '    Dim wid As Integer = 150, hgt As Integer = 75
                '    Dim g As Object
                '    g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                '    g.FillRectangle(Brushes.AliceBlue, x, y, wid, hgt)
                '    g.DrawRectangle(Pens.Black, x, y, wid, hgt)
                '    'y += hgt + 10
                '    'g.FillEllipse(Brushes.LightGoldenrodYellow, x, y, wid, hgt)
                '    'g.DrawEllipse(Pens.Black, x, y, wid, hgt)
                '    'y += hgt + 10
                '    'g.DrawLine(Pens.Black, x, y, x + wid, y + hgt)

                '    'y = 10
                '    'x += wid + 10
                '    'g.DrawArc(Pens.Black, x, y, wid, hgt, -30, 270)
                '    'y += hgt + 10
                '    'g.DrawPie(Pens.Black, x, y, wid, hgt, -30, 270)
                '    'y += hgt + 10

                '    Dim big_font As New Font("Comic Sans MS", 60, FontStyle.Bold, GraphicsUnit.Pixel)
                '    g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                '    g.DrawString("Hello!", big_font, Brushes.Black, x, y)
                'Catch ex As Exception
                '    MsgBox(msgErr(Me, ex.Message))
                'End Try
                '----------------------------

            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        If Mdown Then
            Me.PictureBox2.Left = (e.X - X) + Me.PictureBox2.Left
            Me.PictureBox2.Top = (e.Y - Y) + Me.PictureBox2.Top
        End If
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        If Mdown Then
            Mdown = False
            Me.PictureBox2.Left = (e.X - X) + Me.PictureBox2.Left
            Me.PictureBox2.Top = (e.Y - Y) + Me.PictureBox2.Top
        End If
    End Sub
    Private Sub PictureBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        If Mdown Then
            Me.PictureBox3.Left = (e.X - X) + Me.PictureBox3.Left
            Me.PictureBox3.Top = (e.Y - Y) + Me.PictureBox3.Top
        End If
    End Sub

    Private Sub PictureBox3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseUp
        If Mdown Then
            Mdown = False
            Me.PictureBox3.Left = (e.X - X) + Me.PictureBox3.Left
            Me.PictureBox3.Top = (e.Y - Y) + Me.PictureBox3.Top
        End If
    End Sub
    Public xp As Integer = 0
    Public yp As Integer = 0

    Public wid As Integer = 150
    Public hgt As Integer = 75

    Public xp1 As Integer = 0
    Public yp1 As Integer = 0
    Public wid1 As Integer = 150
    Public hgt1 As Integer = 75
    '---------
    Public mau As System.Drawing.Brush = Brushes.AliceBlue
    Public maupen As System.Drawing.Pen = Pens.Black

    Public mau1 As System.Drawing.Brush = Brushes.AliceBlue
    Public maupen1 As System.Drawing.Pen = Pens.Black


    Private Sub PictureBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        Try

            Dim i, c As Integer
            '---------------------------
            c = 1
            If Me.dgdpackage.Rows.Count <= 0 Then
                Exit Sub
            End If

            For i = 0 To Me.dgdpackage.RowCount - 2
                If Me.dgdpackage.Item("view", i).Value = True Then

                    'inquotation(Me.cboCode1.Text, Me.dgdpackage.Item("cusid", i).Value.ToString, Me.dgdQuotation.Item("proposal", i).Value.ToString, Me.dgdQuotation.Item("salecode", i).Value.ToString)

                    Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
                    sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
                    sql &= "Where " &
                           " freighttariff.freighttariffid='" & Me.dgdpackage.Item("packid", i).Value.ToString & "'  "

                    ds = ReadDataSet(sql)
                    If ds.Tables(0).Rows.Count > 0 Then
                        xp += 0
                        yp += 0 'CDbl(ds.Tables(0).Rows(0).Item("daikien").ToString) * zoom

                        hgt = CDbl(ds.Tables(0).Rows(0).Item("daikien").ToString) * zoom
                        wid = CDbl(ds.Tables(0).Rows(0).Item("rongkien").ToString) * zoom

                    End If

                    'cube1 = New _DCubeNoGimbalLock.Math3D.Cube(zRongkien, xcaoKien, ydaikien)
                    ''Start over
                    ''Me.Refresh()
                    'cube1.RotateX = CSng(tX.Value)
                    'cube1.RotateY = CSng(tY.Value)
                    'cube1.RotateZ = CSng(tZ.Value)
                    'pcarray(c) = New PictureBox
                    'pcarray(c).BackColor = Color.Transparent
                    'pcarray(c).Image = cube1.DrawCube(drawOrigin)
                    'PictureBox2.Image = pcarray(c).Image
                    'Dim ea As Object
                    'PictureBox2_Paint(sender, ea)
                    'PictureBox3_Paint(sender, ea)
                    'Me.PictureBox2.Refresh()
                    'Me.PictureBox3.Refresh()
                    Dim g As Graphics = e.Graphics
                    g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                    g.FillRectangle(mau, xp, yp, wid, hgt)
                    g.DrawRectangle(maupen, xp, yp, wid, hgt)
                    c += 1
                End If




            Next
            '=====================






            'y += hgt + 10
            'g.FillEllipse(Brushes.LightGoldenrodYellow, x, y, wid, hgt)
            'g.DrawEllipse(Pens.Black, x, y, wid, hgt)
            'y += hgt + 10
            'g.DrawLine(Pens.Black, x, y, x + wid, y + hgt)

            'y = 10
            'x += wid + 10
            'g.DrawArc(Pens.Black, x, y, wid, hgt, -30, 270)
            'y += hgt + 10
            'g.DrawPie(Pens.Black, x, y, wid, hgt, -30, 270)
            'y += hgt + 10

            'Dim big_font As New Font("Comic Sans MS", 60, FontStyle.Bold, GraphicsUnit.Pixel)
            '        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
            '    g.DrawString("Hello!", big_font, Brushes.Black, x, y)
            'Me.PictureBox2.Refresh()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub PictureBox3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox3.Paint
        Try

            Dim i, c As Integer
            '---------------------------
            If Me.dgdpackage.Rows.Count <= 0 Then
                Exit Sub
            End If
            c = 1

            For i = 0 To Me.dgdpackage.RowCount - 2
                If Me.dgdpackage.Item("view", i).Value = True Then

                    'inquotation(Me.cboCode1.Text, Me.dgdpackage.Item("cusid", i).Value.ToString, Me.dgdQuotation.Item("proposal", i).Value.ToString, Me.dgdQuotation.Item("salecode", i).Value.ToString)

                    Dim sql As String = "Select freighttariffid,freighttariff.outboundid,contid,cusid,company as customer,containerno as container,soluongkien,daikien,rongkien,caokien,saiso,loaikien,ghichu,tongkhoikien,xepchong,weight,vitri "
                    sql &= " From freighttariff left join customer on freighttariff.cusid=customer.customer_id left join containertype on freighttariff.contid=containertype.outboundContainersID "
                    sql &= "Where " &
                           " freighttariff.freighttariffid='" & Me.dgdpackage.Item("packid", i).Value.ToString & "'  "

                    ds = ReadDataSet(sql)
                    If ds.Tables(0).Rows.Count > 0 Then
                        xp1 += 0
                        yp1 = zRong - CDbl(ds.Tables(0).Rows(0).Item("caokien").ToString) * zoom '+ (xCao - CDbl(ds.Tables(0).Rows(0).Item("caokien").ToString) * zoom)

                        hgt1 = CDbl(ds.Tables(0).Rows(0).Item("caokien").ToString) * zoom
                        wid1 = CDbl(ds.Tables(0).Rows(0).Item("rongkien").ToString) * zoom

                    End If

                    'cube1 = New _DCubeNoGimbalLock.Math3D.Cube(zRongkien, xcaoKien, ydaikien)
                    ''Start over
                    ''Me.Refresh()
                    'cube1.RotateX = CSng(tX.Value)
                    'cube1.RotateY = CSng(tY.Value)
                    'cube1.RotateZ = CSng(tZ.Value)
                    'pcarray(c) = New PictureBox
                    'pcarray(c).BackColor = Color.Transparent
                    'pcarray(c).Image = cube1.DrawCube(drawOrigin)
                    'PictureBox2.Image = pcarray(c).Image
                    'Dim ea As Object
                    ''PictureBox2_Paint(sender, ea)
                    'PictureBox3_Paint(sender, ea)
                    'Me.PictureBox2.Refresh()
                    'Me.PictureBox3.Refresh()
                    Dim g As Graphics = e.Graphics
                    g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                    g.FillRectangle(Brushes.AliceBlue, xp1, yp1, wid1, hgt1)
                    g.DrawRectangle(Pens.Black, xp1, yp1, wid1, hgt1)
                    c += 1
                End If




            Next
            '=====================







            'y += hgt + 10
            'g.FillEllipse(Brushes.LightGoldenrodYellow, x, y, wid, hgt)
            'g.DrawEllipse(Pens.Black, x, y, wid, hgt)
            'y += hgt + 10
            'g.DrawLine(Pens.Black, x, y, x + wid, y + hgt)

            'y = 10
            'x += wid + 10
            'g.DrawArc(Pens.Black, x, y, wid, hgt, -30, 270)
            'y += hgt + 10
            'g.DrawPie(Pens.Black, x, y, wid, hgt, -30, 270)
            'y += hgt + 10

            'Dim big_font As New Font("Comic Sans MS", 60, FontStyle.Bold, GraphicsUnit.Pixel)
            '        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
            '    g.DrawString("Hello!", big_font, Brushes.Black, x, y)
            '  Me.PictureBox3.Refresh()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Try
            If Me.dgdpackage.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.dgdpackage, Me)
            'SetMenu(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage10.Click

    End Sub

    Private Sub FormCOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormCOToolStripMenuItem.Click
        Try

            Dim chk As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

                ' co goutboundid ta la bien close
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from outbound where blob_id='" & gOutboundID & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                    Else
                        DisplayMessage(True, "Lô hàng chưa close.!")
                        Exit Sub
                    End If
                End If
                If LoginSucceeded = True Then
                    Dim form As New frmPrintCO 'frmPrintBillSEAOriginal 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '   VB6.ShowForm(frmPrintCO, VB6.FormShowConstants.Modal, Me)
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub cbopodcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbopodcode.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select port from port where port_code='" & Me.cbopodcode.Text & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtPOD.Text = ds.Tables(0).Rows(0).Item("port").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopodcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbopodcode.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopolcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbopolcode.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select port from port where port_code='" & Me.cbopolcode.Text & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtPOL.Text = ds.Tables(0).Rows(0).Item("port").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopolcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbopolcode.SelectedIndexChanged

    End Sub

    Private Sub cmdOKcashLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKcashLoan.Click
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
                            .Fields("cl2").Value = getID(mOutboundID)
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
    Sub QueryCashloan(Optional ByVal location As Integer = 0)
        Try
            Dim sql As String = "Select cl1 as column1,cl2 as column2,cl3 as column3,cl4 as column4,cl5 as column5,cl6 as column6,cl7 as column7,cl8 as column8,cl9 as column9 "
            sql &= " From notify  "
            sql &= "Where " &
                   " cl2='" & mOutboundID & "'  "
            oTblEquip = ReadTable(sql)
            Me.dgdcashloan.DataSource = oTblEquip


            '--------------------
            Me.Cursor = System.Windows.Forms.Cursors.Default

            InsertAutoNumberToGrid(Me.dgdcashloan)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Private Sub cmdcancelCashloan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelCashloan.Click
        Try
            mStatusCashLoan = "Normal"
            Me.cmdOKcashLoan.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem5.Click
        Try
            Try
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusCashLoan = "Normal" And UserRight("mnuOutbound", "Edit") Then

                    Me.cmdOKcashLoan.Enabled = True
                    '--------------




                    '---------------------------

                    mCashLoanID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusCashLoan = "Add"
                    Me.txtCashLoanDetails.Text = "Ref #" + Me.txtRef.Text + "  BL #" + Me.txtMBLMAWB.Text

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem7.Click
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

                If mStatusCashLoan = "Normal" And UserRight("mnuOutbound", "Edit") Then

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

    Private Sub DeleteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem5.Click
        Try
            If Me.dgdcashloan.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer =
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
        If Not UserRight("mnuoutbound", "Delete") Then
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

    Private Sub txtCapital_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapital.Leave
        Try
            Me.txtlower.Text = VNumberToWord(Me.txtCapital.Text.ToString, Me.cbocurrency.Text)
            Me.txtCashLoanDetails.Text += "  ," + Me.cbocurrency.Text + " " + Me.txtCapital.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCapital.TextChanged

    End Sub

    Private Sub txtpricecredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpricecredit.Leave
        Try
            'If Me.txtpricecredit.Text Like "*=*" Then
            '    Dim tach() As String
            '    If Me.txtpricecredit.Text Like "*" Then

            '    End If
            '    tach = Me.txtpricecredit.Text.Split("")

            '    Me.txtpricecredit.Text = ""
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricecredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricecredit.TextChanged

    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Try
            Shell("C:\WINDOWS\system32\calc.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception

        End Try
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



                    gViewHistory = Me.dgdHBL.Item("BLoB_ID", index).Value.ToString
                    If LoginSucceeded = True Then
                        Dim form As New frmViewHistory 'frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    ' frmViewHistory.Show()

                End If

            Catch ex As Exception
                MsgBox(msgErr(Me, Err.Description))
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub dgddebitGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgddebitGrid.CellContentClick
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

    Private Sub dgddebitGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgddebitGrid.MouseUp
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

    Private Sub dgdCreditGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgdCreditGrid.MouseUp
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

    Private Sub dgdCreditGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCreditGrid.CellContentClick
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

    Private Sub cboitemcredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboitemcredit.Leave
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

    Private Sub cboitemcredit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboitemcredit.SelectedIndexChanged

    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.txtfindCus.Text & "%' or taxcode like '%" & Me.txtfindCus.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocusdebit, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub allCus()
        Try
            Dim id, value, strQuery As String
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where CONTINUED=1 Order by company "
            Me.cbocusdebit.Items.Clear()
            Me.cbocuscredit.Items.Clear()




            loadDataToObject(Me.cbocusdebit, strQuery, id, value)
            loadDataToObject(Me.cbocuscredit, strQuery, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.TextBox1.Text & "%' or taxcode like '%" & Me.TextBox1.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocuscredit, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricenotaxcredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricenotaxcredit.TextChanged

    End Sub

    Private Sub cbocfrColor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocfrColor.Leave
        Try
            Me.txtShipper.ForeColor = Me.cbocfrColor.BackColor
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocfrColor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbocfrColor.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cbocfrColor.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub cbocfrColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocfrColor.SelectedIndexChanged
        Try
            Me.txtShipper.ForeColor = Me.cbocfrColor.BackColor
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
            sql = "select * from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid where ref='" & ref & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        If ds.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                            tongthu += ds.Tables(0).Rows(i).Item("price").ToString
                        End If
                        If ds.Tables(0).Rows(i).Item("debitcredit").ToString = "Credit" Then
                            tongchi += ds.Tables(0).Rows(i).Item("price").ToString
                        End If
                    Catch ex As Exception

                    End Try
                Next

            End If
            Return tongthu - tongchi
        Catch ex As Exception

        End Try
    End Function
    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
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

    Private Sub cboagent_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboagent.Leave
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from customer where customer_id ='" & FindValueID(Me.cboagent, Me.cboagent.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                '  Me.txtAgencyName.Text += "Tel: " + ds.Tables(0).Rows(0).Item("tel").ToString + "  Fax: " + ds.Tables(0).Rows(0).Item("fax").ToString

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboagent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboagent.SelectedIndexChanged
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from customer where customer_id ='" & FindValueID(Me.cboagent, Me.cboagent.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                '    Me.txtAgencyName.Text += "Tel: " + ds.Tables(0).Rows(0).Item("tel").ToString + "  Fax: " + ds.Tables(0).Rows(0).Item("fax").ToString
                '--------------------------------------- SOC
                'Me.txtfreeDEM.Text = ds.Tables(0).Rows(0).Item("priceDEM").ToString
                'Me.txtfreedemcredit.Text = ds.Tables(0).Rows(0).Item("priceDEM").ToString
                'Me.txtfreeDET.Text = ds.Tables(0).Rows(0).Item("priceDET").ToString
                'Me.txtfreedetcredit.Text = ds.Tables(0).Rows(0).Item("priceDET").ToString

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

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Try
            QueryCredit()
        Catch ex As Exception

        End Try
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
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkClose.KeyDown
        Try
            Dim dau As Boolean
            dau = Me.chkClose.Checked
            If UserRight("mnuOutbound", "Execute") = True Then
                ' Me.chkClose.Checked = Not dau

            Else


                Me.chkClose.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkClose_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkClose.Leave
        'Try
        '    If UserRight("mnuOutbound", "Execute") = True Then

        '    Else
        '        DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!!")
        '        Me.chkClose.Checked = Not Me.chkClose.Checked
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub chkClose_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkClose.MouseClick
        Try
            'If UserRight("mnuOutbound", "Execute") = True Then

            'Else
            '    DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!!")
            '    Me.chkClose.Checked = Not Me.chkClose.Checked
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkClose_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkClose.MouseDown
        Try
            Dim dau As Boolean
            dau = Me.chkClose.Checked
            If UserRight("mnuOutbound", "Execute") = True Then
                ' Me.chkClose.Checked = Not dau

            Else


                Me.chkClose.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BillToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            VB6.ShowForm(frmPrintSEAOriginalCGL, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
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

    Private Sub cmdshowportPOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowportPOD.Click
        Try
            Try
                Me.GPort.BringToFront()
                PortPOLPOD = "POD"
                Me.GPort.Visible = True
                Me.GPort.Text = "Select POD"
            Catch ex As Exception

            End Try
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
                    Me.cbopolcode.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.txtPOL.Text = Me.DataGridView4.Item("port", index).Value.ToString
                ElseIf PortPOLPOD = "POD" Then
                    Me.cbopodcode.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.txtPOD.Text = Me.DataGridView4.Item("port", index).Value.ToString

                End If


            End If
            Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPortExit.Click
        Try
            Me.GPort.Visible = False
        Catch ex As Exception

        End Try
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


    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            Try
                If Me.dgddebitGrid.Rows.Count = 0 Then
                    Return
                End If


                Dim selectedRowCount As Integer =
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
        If Not UserRight("mnuoutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Remove the Debit: " & Me.dgddebitGrid.Item("item_debit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then

                copyHistory("outboundfreight", "outboundfreightid", Me.dgddebitGrid.Item("outboundfreightid_debit", index).Value.ToString, "history")



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
                cmd.CommandText = "update  outboundfreight set outboundid ='" & DefaultValue & "' where outboundfreightid= '" & Me.dgddebitGrid.Item("outboundfreightid_debit", index).Value.ToString & "' "

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


            Dim selectedRowCount As Integer =
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
    Public Sub removerowCredit(ByVal index As Integer)
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
        If Not UserRight("mnuoutbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Credit: " & Me.dgdCreditGrid.Item("item_Credit", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()
                copyHistory("outboundfreight", "outboundfreightid", Me.dgdCreditGrid.Item("outboundfreightid_credit", index).Value.ToString, "history")

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "update  outboundfreight set outboundid='" & DefaultValue & "' where outboundfreightid= '" & Me.dgdCreditGrid.Item("outboundfreightid_credit", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        Try
            Me.TXTInvoiceRequestDate.Text = ddMMMyyyy(Me.DateTimePicker1.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BillROMAVLINESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            VB6.ShowForm(frmPrintBillSEAROMAV, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillTheJanelGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            VB6.ShowForm(frmPrintBillSEAJanel, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillBIFAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If

            VB6.ShowForm(frmPrintBillSEABIFA, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        Try
            Me.txtshipper_FCR.Text = Me.txtShipper.Text
            Me.txtConsignee_FCR.Text = Me.txtConsignee.Text
            Me.txtNotify_FCR.Text = Me.txtNotify.Text
            Me.TXTREF_FCR.Text = Me.txtRef.Text
            Me.txtDate_FCR.Text = Me.txteta.Text
            Me.txtPOR_FCR.Text = Me.txtPOR.Text
            Me.TXTPODEL_FCR.Text = Me.txtDel.Text
            Me.txtdescription_FRC.Text = Me.txtDescription.Text
            Me.txtshippingMarks_FCR.Text = Me.txtShippingMarks.Text
            Me.txtremarks_FCR.Text = Me.txtRemarks.Text
            ' the hien kg/khoi
            Dim i As Integer
            Dim kien, kg, khoi As Double
            kien = 0
            kg = 0
            khoi = 0

            For i = 0 To Me.dgdContainers.RowCount - 1
                Try
                    kien += CDbl(Me.dgdContainers.Item("sokien", i).Value.ToString)
                Catch ex As Exception

                End Try

                Try
                    kg += CDbl(Me.dgdContainers.Item("sokg", i).Value.ToString)
                Catch ex As Exception

                End Try

                Try
                    khoi += CDbl(Me.dgdContainers.Item("sokhoi", i).Value.ToString)
                Catch ex As Exception

                End Try



            Next
            Me.txtPkgs_FCR.Text = kien.ToString
            Me.txtGW_FCR.Text = kg.ToString
            Me.txtCBM_FCR.Text = khoi.ToString



        Catch ex As Exception

        End Try
    End Sub

    Private Sub ForwardersCargoReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardersCargoReceiptToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString
            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If


            If LoginSucceeded = True Then
                Dim form As New frmBillFCR 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            ' VB6.ShowForm(frmBillFCR, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        Try
            ' cbocusdebit_SelectedIndexChanged(sender, e)
            Try
                Try

                    Dim i, j As Integer
                    Dim currow, lap As Integer
                    Dim sql As String
                    Me.GroupBox16.Visible = True
                    Me.GroupBox16.BringToFront()

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
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "'  AND department='Agency-Export' and '" & ddMMMyyyy(Me.dtpDateReport.Value.Date) & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE' order by charge_code "
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
                                Me.dgdref.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("poD").ToString

                                Me.dgdref.Item("vat", currow).Value = ds.Tables(0).Rows(i).Item("vat").ToString
                                Me.dgdref.Item("remarks_selling", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString

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
                    sql = "select * from banggialogisticshopdong left join charge on banggialogisticshopdong.itemid=charge.charge_id where no='TEMPLETE' AND department='Agency-Export' "
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
                                Me.dgdref.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("poD").ToString
                                Me.dgdref.Item("vat", currow).Value = ds.Tables(0).Rows(i).Item("vat").ToString
                                Me.dgdref.Item("tu", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                Me.dgdref.Item("den", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                Me.dgdref.Item("value", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                Me.dgdref.Item("indate", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                Me.dgdref.Item("outdate", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString
                                Me.dgdref.Item("remarks_selling", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString


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

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        Try
            Me.GroupBox16.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        Try

            If Me.dgdref.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If


            Dim index As Integer = Me.dgdref.CurrentRow.Index
            Try
                Me.cboitemdebit.Text = Me.dgdref.Item("charge", index).Value.ToString
                Me.txtexdebit.Text = Me.dgdref.Item("exchange", index).Value.ToString
                Me.txtunitpricedebit_.Text = Me.dgdref.Item("value", index).Value.ToString
                'Me.txtunitpricedebit.Text = Me.dgdref.Item("value", index).Value.ToString
                Me.txtcurrdebit.Text = Me.dgdref.Item("cur", index).Value.ToString
                Me.txtunitdebit.Text = Me.dgdref.Item("unit", index).Value.ToString
                Me.txttaxdebit.Text = Me.dgdref.Item("vat", index).Value.ToString
                ' Me.txttaxdebit.Text = "10"
            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox16_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox16.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox16_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox16.MouseMove
        If Mdown Then
            Me.GroupBox16.Left = (e.X - X) + Me.GroupBox16.Left
            Me.GroupBox16.Top = (e.Y - Y) + Me.GroupBox16.Top
        End If
    End Sub

    Private Sub GroupBox16_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox16.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox16.Left = (e.X - X) + Me.GroupBox16.Left
            Me.GroupBox16.Top = (e.Y - Y) + Me.GroupBox16.Top
        End If
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        Try
            '  cbocuscredit_SelectedIndexChanged(sender, e)
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
                        sql = "select * from banggialogisticshopdong_cost left join charge on banggialogisticshopdong_cost.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text) & "'  AND department='Agency-Export' and '" & ddMMMyyyy(Me.dtpDateReport.Value.Date) & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE' order by charge_code "
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
                                    Me.DataGridView5.Item("remarks_buying", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString

                                Next


                            Next

                        End If
                        ' show all
                        sql = "select * from banggialogisticshopdong_cost left join charge on banggialogisticshopdong_cost.itemid=charge.charge_id where no='TEMPLETE' AND department='Agency-Export' "
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
                                    Me.DataGridView5.Item("charge_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                                    Me.DataGridView5.Item("pol_", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView5.Item("pod_", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                                    Me.DataGridView5.Item("tu_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("tu" + j.ToString).ToString
                                    Me.DataGridView5.Item("den_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("den" + j.ToString).ToString
                                    Me.DataGridView5.Item("value_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("giatri" + j.ToString).ToString
                                    Me.DataGridView5.Item("indate_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("indate").ToString
                                    Me.DataGridView5.Item("outdate_CREDIT", currow).Value = ds.Tables(0).Rows(i).Item("outdate").ToString
                                    Me.DataGridView5.Item("remarks_buying", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString

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

    Private Sub cbocuscredit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbocuscredit.Leave
        Try
            Try
                Try

                    Dim i, j As Integer
                    Dim currow, lap As Integer
                    Dim sql As String
                    Me.GroupBox8_credit.Visible = True
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
                    sql = "select * from banggialogisticshopdong_cost left join charge on banggialogisticshopdong_cost.itemid=charge.charge_id where customerid='" & FindValueID(Me.cbocuscredit, Me.cbocuscredit.Text) & "'  AND department='Agency-Export' and '" & ddMMMyyyy(Me.dtpDateReport.Value.Date) & "'  between convert(datetime,indate) and convert(datetime,outdate) and no <> 'TEMPLETE' order by charge_code "
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
                    sql = "select * from banggialogisticshopdong_cost left join charge on banggialogisticshopdong_cost.itemid=charge.charge_id where no='TEMPLETE' AND department='Agency-Export' "
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
    End Sub

    Private Sub cbocuscredit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbocuscredit.SelectedIndexChanged

    End Sub

    Private Sub Button52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button52.Click
        Try
            Me.GroupBox8_credit.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button51.Click
        Try
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
                    Me.txttaxcredit.Text = "10"
                Catch ex As Exception

                End Try



            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GroupBox8_credit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox8_credit.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox8_credit_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox8_credit.MouseMove
        If Mdown Then
            Me.GroupBox8_credit.Left = (e.X - X) + Me.GroupBox8_credit.Left
            Me.GroupBox8_credit.Top = (e.Y - Y) + Me.GroupBox8_credit.Top
        End If
    End Sub

    Private Sub GroupBox8_credit_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox8_credit.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox8_credit.Left = (e.X - X) + Me.GroupBox8_credit.Left
            Me.GroupBox8_credit.Top = (e.Y - Y) + Me.GroupBox8_credit.Top
        End If
    End Sub
    Private Sub GroupBox8_credit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox8_credit.Enter

    End Sub

    Private Sub txtunitdebit_Leave(sender As Object, e As EventArgs) Handles txtunitdebit.Leave
        Try
            addQuantitydebit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitdebit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitdebit.SelectedIndexChanged
        Try
            'lay so cbm
            'If UCase(Me.txtunitdebit.Text) Like "*CBM*" Then
            '    If CDbl(Me.dgdContainers.Item("sokhoi", 0).Value.ToString) < 1 Then
            '        Me.txtquantitydebit.Text = 1
            '    Else
            '        Me.txtquantitydebit.Text = Me.dgdContainers.Item("sokhoi", 0).Value.ToString
            '    End If
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttaxdebit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttaxdebit.SelectedIndexChanged
        Try
            If Me.chkmanual.Checked = False Then

                'Me.txtpricedebit_.Text = FormatNumber(CDbl(Me.txtpricedebit_.Text) * (CDbl(Me.txttaxdebit.Text) / 100) + 1, 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)
                Me.txtpricedebit.Text = FormatNumber(CDbl(Me.txtpricedebit_.Text) * ((CDbl(Me.txttaxdebit.Text) / 100) + 1), 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)
                Me.txtunitpricedebit.Text = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) * ((CDbl(Me.txttaxdebit.Text) / 100) + 1), 3) '+ CDbl(Me.txtPriceTruocthueDebit1.Text) * CDbl(Me.txtTigiadebit1.Text)



            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub addQuantitydebit()
        Try
            Dim i As Integer
            Dim tongcbm As Double = 0
            Dim tongkgs As Double = 0
            Dim giatri As Double = 0
            ' debitnoixuat
            If Me.dgdContainers.Rows.Count > 0 Then
                '  Me.cboContainer.Items.Clear()
                'Me.cbocontainerCredit.Items.Clear()



                For i = 0 To Me.dgdContainers.Rows.Count - 1
                    Try
                        ' addcont(Me.cboContainer, Me.dgdContainers.Item("containerNo", i).Value.ToString + "-" + Me.dgdContainers.Item("containerType", i).Value.ToString)

                    Catch ex As Exception

                    End Try

                    Try
                        ' addcont(Me.cbocontainerCredit, Me.dgdContainers.Item("containerNo", i).Value.ToString + "-" + Me.dgdContainers.Item("containerType", i).Value.ToString)

                    Catch ex As Exception

                    End Try

                    Try
                        tongcbm += Me.dgdContainers.Item("sokhoi", i).Value.ToString
                    Catch ex As Exception

                    End Try


                    Try
                        tongkgs += Me.dgdContainers.Item("sokg", i).Value.ToString
                    Catch ex As Exception

                    End Try


                Next
                giatri = tongcbm
                tongkgs = tongkgs / 1000
                If tongcbm > tongkgs Then
                    giatri = tongcbm
                Else
                    giatri = tongkgs
                End If
            End If
            If Me.txtunitdebit.Text = "CBM" Then
                If giatri < 1 Then
                    giatri = 1
                End If
                Me.txtquantitydebit.Text = giatri
            Else
                Me.txtquantitydebit.Text = 1
            End If

            'If Me.txtunitcredit.Text = "CBM" Then
            '    Me.txtquantitycredit.Text = giatri
            'Else
            '    Me.txtquantitycredit.Text = 1
            'End If


        Catch ex As Exception

        End Try
    End Sub
    Public Sub addQuantitycredit()
        Try
            Dim i As Integer
            Dim tongcbm As Double = 0
            Dim tongkgs As Double = 0
            Dim giatri As Double = 0
            ' debitnoixuat
            If Me.dgdContainers.Rows.Count > 0 Then
                '  Me.cboContainer.Items.Clear()
                'Me.cbocontainerCredit.Items.Clear()



                For i = 0 To Me.dgdContainers.Rows.Count - 1
                    Try
                        ' addcont(Me.cboContainer, Me.dgdContainers.Item("containerNo", i).Value.ToString + "-" + Me.dgdContainers.Item("containerType", i).Value.ToString)

                    Catch ex As Exception

                    End Try

                    Try
                        ' addcont(Me.cbocontainerCredit, Me.dgdContainers.Item("containerNo", i).Value.ToString + "-" + Me.dgdContainers.Item("containerType", i).Value.ToString)

                    Catch ex As Exception

                    End Try

                    Try
                        tongcbm += Me.dgdContainers.Item("sokhoi", i).Value.ToString
                    Catch ex As Exception

                    End Try


                    Try
                        tongkgs += Me.dgdContainers.Item("sokg", i).Value.ToString
                    Catch ex As Exception

                    End Try


                Next
                giatri = tongcbm
                tongkgs = tongkgs / 1000
                If tongcbm > tongkgs Then
                    giatri = tongcbm
                Else
                    giatri = tongkgs
                End If
            End If
            'If Me.txtunitdebit.Text = "CBM" Then
            '    Me.txtquantitydebit.Text = giatri
            'Else
            '    Me.txtquantitydebit.Text = 1
            'End If

            If Me.txtunitcredit.Text = "CBM" Then
                If giatri < 1 Then
                    giatri = 1
                End If
                Me.txtquantitycredit.Text = giatri
            Else
                Me.txtquantitycredit.Text = 1
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtunitcredit_Leave(sender As Object, e As EventArgs) Handles txtunitcredit.Leave
        Try
            addQuantitycredit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitcredit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitcredit.SelectedIndexChanged
        Try
            'lay so cbm
            'If UCase(Me.txtunitcredit.Text) Like "*CBM*" Then
            '    If CDbl(Me.dgdContainers.Item("sokhoi", 0).Value.ToString) < 1 Then
            '        Me.txtquantitycredit.Text = 1
            '    Else
            '        Me.txtquantitycredit.Text = Me.dgdContainers.Item("sokhoi", 0).Value.ToString
            '    End If
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox17_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox17.Enter

    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        Try
            Me.GroupBox17.BringToFront()
            Me.GroupBox17.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        Try
            Me.GroupBox17.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OtherDebit3.Leave
        Try
            Me.OtherDebit3.Text = FormatNumber(Me.OtherDebit3.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherDebit3.TextChanged
        Try
            Try
                Me.OtherDebit5.Text = FormatNumber(CDbl(Me.OtherDebit3.Text) * CDbl(Me.OtherDebit4.Text), 2)
            Catch ex As Exception

            End Try
            Try
                Me.OtherDebit4.Text = FormatNumber(Me.OtherDebit4.Text, 2)
            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OtherDebit4.Leave
        Try
            Me.OtherDebit4.Text = FormatNumber(Me.OtherDebit4.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherDebit4.TextChanged
        Try
            Try
                Me.OtherDebit5.Text = FormatNumber(CDbl(Me.OtherDebit3.Text) * CDbl(Me.OtherDebit4.Text), 2)
            Catch ex As Exception

            End Try

            Try
                Me.OtherDebit3.Text = FormatNumber(Me.OtherDebit3.Text, 2)
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OtherDebit9.Leave
        Try
            Me.OtherDebit9.Text = FormatNumber(Me.OtherDebit9.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherDebit9.TextChanged
        Try
            Try
                Try
                    Me.OtherDebit11.Text = FormatNumber(CDbl(Me.OtherDebit10.Text) * CDbl(Me.OtherDebit9.Text), 2)
                Catch ex As Exception

                End Try
                Try
                    Me.OtherDebit10.Text = FormatNumber(Me.OtherDebit10.Text, 2)
                Catch ex As Exception

                End Try


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OtherDebit10.Leave
        Try
            Me.OtherDebit10.Text = FormatNumber(Me.OtherDebit10.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherDebit10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherDebit10.TextChanged
        Try
            Try
                Try
                    Me.OtherDebit11.Text = FormatNumber(CDbl(Me.OtherDebit10.Text) * CDbl(Me.OtherDebit9.Text), 2)
                Catch ex As Exception

                End Try

                Try
                    Me.OtherDebit9.Text = FormatNumber(Me.OtherDebit9.Text, 2)
                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricedebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpricedebit.TextChanged

    End Sub

    Private Sub GroupBox18_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox18.Enter

    End Sub

    Private Sub CHKrf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKrf.CheckedChanged
        Try
            Me.GroupBox18.Visible = Me.CHKrf.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtunitpricedebit__Leave(sender As Object, e As EventArgs) Handles txtunitpricedebit_.Leave
        Try
            Dim strMesg As String
            ' dem so luong hbl
            Dim sql As String
            Dim slhbl As Integer = 0
            Dim ds As New DataSet
            If Me.txtRef.Text <> "" Then
                sql = "select Count(*) as dem from outbound where ref ='" & Me.txtRef.Text.Trim & "' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    Try
                        slhbl = CInt(ds.Tables(0).Rows(0).Item("dem").ToString)
                    Catch ex As Exception
                        slhbl = 1
                    End Try

                End If
            Else
                slhbl = 1
            End If

            If Me.chklcl.Checked = True Then
                strMesg = "Bạn muốn chia theo số lượng " + slhbl.ToString + " HBL.?"
                If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    If txtcurrdebit.Text.Trim <> "VND" Then
                        Me.txtunitpricedebit_.Text = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) / slhbl, 3)
                    Else
                        Me.txtunitpricedebit_.Text = FormatNumber(CDbl(Me.txtunitpricedebit_.Text) / slhbl, 0)

                    End If

                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitpricedebit__TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunitpricedebit_.TextChanged
        Try
            txtquantitydebit_TextChanged(sender, e)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EmanifestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmanifestToolStripMenuItem.Click
        Try
            Try
                Try
                    Dim chk As Integer
                    chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                    If chk = 0 Then
                        DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                        Return
                    End If
                    If Me.dgdHBL.RowCount > 0 Then
                        Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                        gOutboundID = Me.dgdHBL.Item("BLob_ID", index).Value.ToString
                        ' co ginboundid ta la bien close
                        Dim sql As String
                        Dim ds As New DataSet
                        sql = "select * from outbound where blob_id='" & gOutboundID & "' "
                        ds = ReadDataSet(sql)
                        If ds.Tables(0).Rows.Count > 0 Then
                            If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                            Else
                                DisplayMessage(True, "Lô hàng chưa Approve.!")
                                Exit Sub
                            End If
                        End If

                        gEManifest = gOutboundID
                        gPrintOutbound = "Outbound"

                        VB6.ShowForm(frmManifest_out, VB6.FormShowConstants.Modal, Me)
                    End If


                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtContainerNo1_Leave1(sender As Object, e As EventArgs) Handles txtContainerNo1.Leave
        Try
            Try
                If CheckContainerNumber(Me.txtContainerNo1.Text) = "Container Number is OK!" Then
                Else

                    DisplayMessage(True, CheckContainerNumber(Me.txtContainerNo1.Text))
                End If

            Catch ex As Exception
                ' DisplayMessage(True, Err.Description)
            End Try
            ' DisplayMessage(True, CheckContainerNumber(Me.txtContainerNo1.Text))
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtContainerNo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtContainerNo1.SelectedIndexChanged

    End Sub

    Private Sub PackingListToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SOCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SOCToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If
            gPrintOutbound = "Outbound"
            If LoginSucceeded = True Then
                Dim form As New frmPrintBillSEAOriginal 'frmPrintBillSEAOriginal 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            '   VB6.ShowForm(frmPrintBillSEAOriginal, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub COCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COCToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdHBL.RowCount > 0 Then
            Dim index As Integer = Me.dgdHBL.CurrentRow.Index
            gOutboundID = Me.dgdHBL.Item("BLOB_ID", index).Value.ToString

            ' co goutboundid ta la bien close
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                Else
                    DisplayMessage(True, "Lô hàng chưa Approve.!")
                    Exit Sub
                End If
            End If
            gPrintOutbound = "Outbound"
            If LoginSucceeded = True Then
                Dim form As New frmPrintBillSEAOriginal 'frmPrintBillSEAOriginal 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            '   VB6.ShowForm(frmPrintBillSEAOriginal, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button19_Click_2(sender As Object, e As EventArgs) Handles Button19.Click
        Try
            Me.txtngayhabai.Text = ddMMMyyyy(Me.DateTimePicker2.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        Try
            If LoginSucceeded = True Then
                gSQLShowDetails = "select * from bookingagent where gmd_bookingno='" & Me.txtBKNo.Text & "' "
                Dim form As New frmShowDetails 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
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

    Private Sub Label178_Click(sender As Object, e As EventArgs) Handles Label178.Click

    End Sub

    Private Sub chkpaydebit_CheckedChanged(sender As Object, e As EventArgs) Handles chkpaydebit.CheckedChanged

    End Sub

    Private Sub chkpaydebit_KeyDown(sender As Object, e As KeyEventArgs) Handles chkpaydebit.KeyDown
        Try
            Dim dau As Boolean
            dau = Me.chkpaydebit.Checked
            If UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "ACCOUNTING" Then

            Else
                Me.chkpaydebit.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!! (Bạn không có quyền tick .!)")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkpaydebit_MouseDown(sender As Object, e As MouseEventArgs) Handles chkpaydebit.MouseDown
        Try
            Dim dau As Boolean
            dau = Me.chkpaydebit.Checked
            If UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "ACCOUNTING" Then

            Else
                Me.chkpaydebit.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!! (Bạn không có quyền tick .!)")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkpaycredit_CheckedChanged(sender As Object, e As EventArgs) Handles chkpaycredit.CheckedChanged

    End Sub

    Private Sub chkpaycredit_MouseDown(sender As Object, e As MouseEventArgs) Handles chkpaycredit.MouseDown
        Try
            Dim dau As Boolean
            dau = Me.chkpaycredit.Checked
            If UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "ACCOUNTING" Then

            Else
                Me.chkpaycredit.Checked = dau

                DisplayMessage(True, "Sorry,the proccess requires an access rigth to carry out.!!! (Bạn không có quyền tick .!)")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpricedebit__TextChanged(sender As Object, e As EventArgs) Handles txtpricedebit_.TextChanged

    End Sub

    Private Sub ManifestConsolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManifestConsolToolStripMenuItem.Click
        Try

            Dim chk As Integer
            Dim ref As String
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim i As Integer
            chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdHBL.RowCount > 0 Then
                Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                ref = Me.dgdHBL.Item("ref", index).Value.ToString.Trim

                ' co goutboundid ta la bien close
                Dim sql As String
                Dim ds As New DataSet
                Dim kien As Double = 0
                Dim loaikien As String
                Dim container As String
                Dim kg As Double = 0
                Dim khoi As Double = 0
                Dim j As Integer

                ' ''sql = "select * from outbound where blob_id='" & gOutboundID & "' "
                ' ''ds = ReadDataSet(sql)
                ' ''If ds.Tables(0).Rows.Count > 0 Then
                ' ''    If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                ' ''    Else
                ' ''        DisplayMessage(True, "Lô hàng chưa Approve.!")
                ' ''        Exit Sub
                ' ''    End If
                ' ''End If
                ' xoa table manifestconsol
                Dim cmd As New ADODB.Command
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from manifestconsol  "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                '--- them du lieu vao
                sql = "select * from outbound where ref ='" & ref & "'  ORDER BY MBLMAWB DESC "

                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM manifestconsol "
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs

                            .AddNew()

                            .Fields("id").Value = NewId()
                            ''-------------------------
                            ''-------------------------
                            If UCase(ds.Tables(0).Rows(i).Item("shipperother").ToString) Like "*VESTAL*" Then
                                .Fields("hbl").Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString + "A"
                            Else
                                .Fields("hbl").Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                            End If
                            ' .Fields("hbl").Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                            If ds.Tables(0).Rows(i).Item("shipperother").ToString.Trim = "" Then
                                .Fields("shipper").Value = ds.Tables(0).Rows(i).Item("shipper").ToString
                            Else
                                .Fields("shipper").Value = ds.Tables(0).Rows(i).Item("shipperother").ToString
                            End If

                            If ds.Tables(0).Rows(i).Item("consigneeother").ToString.Trim = "" Then
                                .Fields("consignee").Value = ds.Tables(0).Rows(i).Item("consignee").ToString
                            Else
                                .Fields("consignee").Value = ds.Tables(0).Rows(i).Item("consigneeother").ToString
                            End If

                            If ds.Tables(0).Rows(i).Item("notifyother").ToString.Trim = "" Then
                                .Fields("notify").Value = ds.Tables(0).Rows(i).Item("notify").ToString
                            Else
                                .Fields("notify").Value = ds.Tables(0).Rows(i).Item("notifyother").ToString
                            End If

                            '   .Fields("consignee").Value = ds.Tables(0).Rows(i).Item("consignee").ToString

                            '  .Fields("notify").Value = ds.Tables(0).Rows(i).Item("notify").ToString

                            .Fields("shippingmarks").Value = ds.Tables(0).Rows(i).Item("shippingmarks").ToString


                            .Fields("description").Value = ds.Tables(0).Rows(i).Item("description").ToString


                            .Fields("destination").Value = ds.Tables(0).Rows(i).Item("dest").ToString


                            .Fields("pol").Value = ds.Tables(0).Rows(i).Item("pol").ToString
                            .Fields("pod").Value = ds.Tables(0).Rows(i).Item("pod").ToString

                            .Fields("vessel").Value = ds.Tables(0).Rows(i).Item("vessel").ToString

                            .Fields("voy").Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                            Dim bientam As String

                            Try
                                If ds.Tables(0).Rows(i).Item("agencynameSI").ToString.Trim <> "" Then
                                    .Fields("agencyname").Value = ds.Tables(0).Rows(i).Item("agencynameSI").ToString
                                    bientam = ds.Tables(0).Rows(i).Item("agencynameSI").ToString.Trim
                                Else
                                    .Fields("agencyname").Value = bientam
                                End If

                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("etd").Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString
                            Catch ex As Exception

                            End Try

                            ' ung voi moi hbl ta lay so kien,kg,khoi
                            kien = 0
                            kg = 0
                            khoi = 0
                            Dim sql1 As String
                            Dim ds1 As New DataSet
                            sql1 = "select * from containertype where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "' "
                            ds1 = ReadDataSet(sql1)
                            If ds1.Tables(0).Rows.Count > 0 Then
                                For j = 0 To ds1.Tables(0).Rows.Count - 1



                                    Try
                                        kien += CDbl(ds1.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kg += CDbl(ds1.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(ds1.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        loaikien = ds1.Tables(0).Rows(j).Item("type").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        container = ds1.Tables(0).Rows(j).Item("containerno").ToString + "/" + ds1.Tables(0).Rows(j).Item("seal").ToString + "/" + ds1.Tables(0).Rows(j).Item("containertype").ToString
                                    Catch ex As Exception

                                    End Try
                                Next
                            End If


                            Try
                                .Fields("KIEN").Value = FormatNumber(kien, 0)
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("KG").Value = FormatNumber(kg, 2)
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("KHOI").Value = FormatNumber(khoi, 2)
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("CONTAINER").Value = container
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("LOAIKIEN").Value = loaikien
                            Catch ex As Exception

                            End Try
                            .Update()
                            .Close()

                        End With

                    Next
                End If

                '-----------------------------------
                gPrintOutbound = "Outbound"
                If LoginSucceeded = True Then
                    Dim form As New frmManifestConsol  'frmPrintBillSEAOriginal 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '   VB6.ShowForm(frmPrintBillSEAOriginal, VB6.FormShowConstants.Modal, Me)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chknewbill_CheckedChanged(sender As Object, e As EventArgs) Handles chknewbill.CheckedChanged

    End Sub

    Private Sub GetHBLNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetHBLNoToolStripMenuItem.Click
        Try
            Me.txtNewBill.Text = ""
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
            Dim so As String = GetBookingNumberFromDB_hbl()
            Dim sokhong As String
            If CInt(so) < 10 Then
                sokhong = "0000"
            ElseIf CInt(so) > 9 And CInt(so) < 100 Then
                sokhong = "000"
            ElseIf CInt(so) > 99 And CInt(so) < 1000 Then
                sokhong = "00"
            ElseIf CInt(so) > 999 And CInt(so) < 10000 Then
                sokhong = "0"
            ElseIf CInt(so) > 9999 And CInt(so) < 100000 Then
                sokhong = ""
            End If




            Me.txtNewBill.Text = nam.Substring(2, 2) + thangsosanh + sokhong + so.ToString



        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCopyHBL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCopyHBL.SelectedIndexChanged

    End Sub

    Private Sub BiênBảnLàmHàngOPSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiênBảnLàmHàngOPSToolStripMenuItem.Click
        Try
            Try

                Dim chk As Integer
                Dim ref As String
                Dim strQuery As String
                Dim rs As New ADODB.Recordset
                Dim i As Integer
                chk = Me.dgdHBL.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If chk = 0 Then
                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                    Return
                End If
                If Me.dgdHBL.RowCount > 0 Then
                    Dim index As Integer = Me.dgdHBL.CurrentRow.Index
                    ref = Me.dgdHBL.Item("ref", index).Value.ToString.Trim

                    ' co goutboundid ta la bien close
                    Dim sql As String
                    Dim ds As New DataSet
                    Dim kien As Double = 0
                    Dim loaikien As String
                    Dim container As String
                    Dim kg As Double = 0
                    Dim khoi As Double = 0
                    Dim j As Integer

                    ' ''sql = "select * from outbound where blob_id='" & gOutboundID & "' "
                    ' ''ds = ReadDataSet(sql)
                    ' ''If ds.Tables(0).Rows.Count > 0 Then
                    ' ''    If ds.Tables(0).Rows(0).Item("closefile").ToString = "True" Then
                    ' ''    Else
                    ' ''        DisplayMessage(True, "Lô hàng chưa Approve.!")
                    ' ''        Exit Sub
                    ' ''    End If
                    ' ''End If
                    ' xoa table manifestconsol
                    Dim cmd As New ADODB.Command
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "delete from manifestconsol  "

                    cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    '--- them du lieu vao
                    sql = "select * from outbound where ref ='" & ref & "'  ORDER BY MBLMAWB DESC "

                    ds = ReadDataSet(sql)
                    If ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To ds.Tables(0).Rows.Count - 1
                            strQuery = "SELECT * "
                            strQuery = strQuery & "FROM manifestconsol "
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs

                                .AddNew()

                                .Fields("id").Value = NewId()
                                ''-------------------------
                                ''-------------------------

                                .Fields("hbl").Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                                .Fields("shipper").Value = ds.Tables(0).Rows(i).Item("shipper").ToString

                                .Fields("consignee").Value = ds.Tables(0).Rows(i).Item("consignee").ToString

                                .Fields("notify").Value = ds.Tables(0).Rows(i).Item("notify").ToString

                                .Fields("shippingmarks").Value = ds.Tables(0).Rows(i).Item("shippingmarks").ToString


                                .Fields("description").Value = ds.Tables(0).Rows(i).Item("description").ToString


                                .Fields("destination").Value = ds.Tables(0).Rows(i).Item("dest").ToString


                                .Fields("pol").Value = ds.Tables(0).Rows(i).Item("pol").ToString
                                .Fields("pod").Value = ds.Tables(0).Rows(i).Item("pod").ToString

                                .Fields("vessel").Value = ds.Tables(0).Rows(i).Item("vessel").ToString

                                .Fields("voy").Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                                Try
                                    .Fields("agencyname").Value = ds.Tables(0).Rows(i).Item("agencyname").ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    .Fields("etd").Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString
                                Catch ex As Exception

                                End Try

                                ' ung voi moi hbl ta lay so kien,kg,khoi
                                kien = 0
                                kg = 0
                                khoi = 0
                                Dim sql1 As String
                                Dim ds1 As New DataSet
                                sql1 = "select * from containertype where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "' "
                                ds1 = ReadDataSet(sql1)
                                If ds1.Tables(0).Rows.Count > 0 Then
                                    For j = 0 To ds1.Tables(0).Rows.Count - 1



                                        Try
                                            kien += CDbl(ds1.Tables(0).Rows(j).Item("sokien").ToString)
                                        Catch ex As Exception

                                        End Try
                                        Try
                                            kg += CDbl(ds1.Tables(0).Rows(j).Item("sokg").ToString)
                                        Catch ex As Exception

                                        End Try
                                        Try
                                            khoi += CDbl(ds1.Tables(0).Rows(j).Item("sokhoi").ToString)
                                        Catch ex As Exception

                                        End Try

                                        Try
                                            loaikien = ds1.Tables(0).Rows(j).Item("type").ToString
                                        Catch ex As Exception

                                        End Try
                                        Try
                                            container = ds1.Tables(0).Rows(j).Item("containerno").ToString + "/" + ds1.Tables(0).Rows(j).Item("seal").ToString + "/" + ds1.Tables(0).Rows(j).Item("containertype").ToString
                                        Catch ex As Exception

                                        End Try
                                    Next
                                End If


                                Try
                                    .Fields("KIEN").Value = FormatNumber(kien, 0)
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("KG").Value = FormatNumber(kg, 2)
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("KHOI").Value = FormatNumber(khoi, 2)
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("CONTAINER").Value = container
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("LOAIKIEN").Value = loaikien
                                Catch ex As Exception

                                End Try
                                .Update()
                                .Close()

                            End With

                        Next
                    End If

                    '-----------------------------------
                    gPrintOutbound = "Outbound"
                    If LoginSucceeded = True Then
                        Dim form As New frmBienbanlamhang  'frmPrintBillSEAOriginal 'frmInbound 'frmQuotationT
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    '   VB6.ShowForm(frmPrintBillSEAOriginal, VB6.FormShowConstants.Modal, Me)
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        Try
            Me.txtOnboardDate.Text = "SHIPPED ONBOARD : " + Me.txtVessel.Text + " " + Me.txtVoyage.Text + " " + Me.txtPOL.Text + " " + Me.txtetd.Text
        Catch ex As Exception

        End Try

        Try
            Me.txtPlaceAndDate.Text = Me.txtPOL.Text + "  " + Me.txtetd.Text
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtFreightAmount_Leave(sender As Object, e As EventArgs) Handles txtFreightAmount.Leave
        Try
            If UCase(Me.txtFreightAmount.Text) = "PREPAID" Then
                Me.txtFreightPayableAt.Text = Me.txtPOL.Text
                Me.txtPP.Text = "AS ARRANGED"
                Me.txtCC.Text = ""
            ElseIf UCase(Me.txtFreightAmount.Text) = "COLLECT" Then
                Me.txtFreightPayableAt.Text = Me.txtDest.Text
                Me.txtPP.Text = ""
                Me.txtCC.Text = "AS ARRANGED"""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFreightAmount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtFreightAmount.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        Try
            Me.txtshipperOther.Text = Me.txtShipper.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        Try
            Me.txtconsigneeOther.Text = Me.txtConsignee.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        Try
            Me.txtnotifyOther.Text = Me.txtNotify.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        Try
            Me.txtAgencyNameOther.Text = Me.txtAgencyName.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button54_Click(sender As Object, e As EventArgs) Handles Button54.Click
        Try
            Me.txtagencyNameSI.Text = Me.txtAgencyName.Text
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

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If UCase(gDepartment) = "SALE" Then
                sql = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC  from Outbound where salecode='" & gSaleCode & "' and mblmawb='" & Me.txtMBLMAWB.Text & "' and (branch like '%" & gBranch & "%')    order by dateupdate "
                ds = ReadDataSet(sql)
                Me.dgdHBL.DataSource = ds.Tables(0)
                '  mFilter = " and ref = '" & Me.cboMBLCarrier.Text & "' "
                InsertAutoNumberToGrid(Me.dgdHBL)
            Else
                sql = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,userupdate ,DateUpdate,NVOCC  from Outbound where mblmawb ='" & Me.txtMBLMAWB.Text & "'  order by dateupdate " 'and (branch like '%" & gBranch & "%')   
                ds = ReadDataSet(sql)
                Me.dgdHBL.DataSource = ds.Tables(0)
                ' mFilter = " and ref = '" & Me.cboMBLCarrier.Text & "' "
                InsertAutoNumberToGrid(Me.dgdHBL)
            End If
        Catch ex As Exception

        End Try
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
            strSQL = "Select  QuotationTicoID,no From QuotationTico  where continued =1 and approve=1  and userupdate='" & Me.cboSale.Text & "' and cusID='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "' "
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

                strSQL = "select stt,quotationTicoDetailsID,QuotationTico.quotationticoid,cusid,items,itemsid,price,cur,quantity,unitprice,type,textshow,vat,priceincvat,remarks_phi "
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
                        currow += 1
                    Next
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button92_Click(sender As Object, e As EventArgs) Handles Button92.Click
        Try
            Me.GroupQuotation.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button93_Click(sender As Object, e As EventArgs) Handles Button93.Click
        Try
            Dim i As Integer
            For i = 0 To Me.dgdPIC.RowCount - 1
                If Me.dgdPIC.Item("check", i).Value = True Then
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
                            tong = tienCongno(Me.dgdPIC.Item("cusid_Q", i).Value, "A")

                            sql = "select * from customer where customer_id = '" & Me.dgdPIC.Item("cusid_Q", i).Value & "'"
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
                            strQuery = "Select * From Outboundfreight " 'Where Inboundfreightid='" & mdebitID & "'
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                'If rs.EOF Then
                                .AddNew()
                                .Fields("outboundfreightID").Value = NewId()
                                .Fields("outboundID").Value = getID(mOutboundID)
                                'End If


                                '-------------------------------container
                                .Fields("customerid").Value = "{" + Me.dgdPIC.Item("cusid_Q", i).Value + "}" ' "{" + FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) + "}"
                                .Fields("itemid").Value = "{" + Me.dgdPIC.Item("itemsid_q", i).Value + "}"
                                ' lay vat tu unit cua cgarge
                                Dim vat As Double
                                Dim sqlvat As String
                                Dim dsvat As New DataSet
                                sqlvat = "select * from charge where charge_id='" & Me.dgdPIC.Item("itemsid_q", i).Value & "' "
                                dsvat = ReadDataSet(sqlvat)
                                If dsvat.Tables(0).Rows.Count > 0 Then
                                    Try
                                        vat = CDbl(dsvat.Tables(0).Rows(0).Item("unit").ToString)
                                    Catch ex As Exception
                                        vat = 0
                                    End Try
                                End If
                                '-------
                                .Fields("currency").Value = Me.dgdPIC.Item("currency_q", i).Value


                                .Fields("containertype").Value = Me.dgdPIC.Item("type_q", i).Value ' Me.txtunitdebit.Text


                                .Fields("unitprice").Value = Me.dgdPIC.Item("unitprice_q", i).Value ' Me.txtunitpricedebit.Text
                                .Fields("quantity").Value = Me.dgdPIC.Item("quantity_q", i).Value 'Me.txtquantitydebit.Text



                                '  .Fields("container").Value = Me.cboContainer.Text

                                .Fields("taxprice").Value = vat 'Me.dgdPIC.Item("vat_q", i).Value ' Me.txttaxdebit.Text
                                '.Fields("pricethue").Value = Me.txtpricetaxdebit.Text

                                .Fields("price").Value = Me.dgdPIC.Item("priceincvat_q", i).Value * ((vat / 100) + 1) ' Me.dgdPIC.Item("priceincvat_q", i).Value ' Me.txtpricedebit.Text

                                .Fields("note").Value = Me.dgdPIC.Item("remarks_phi_q", i).Value 'Me.txtremarksdebit.Text

                                .Fields("os").Value = False
                                .Fields("paycheck").Value = False
                                ' .Fields("showarrival").Value = True
                                .Fields("daily").Value = False

                                .Fields("ngay").Value = ""
                                .Fields("ngayhoadon").Value = ""
                                .Fields("tigia").Value = getCur("USD") 'Me.txtexdebit.Text
                                .Fields("debitcredit").Value = "Debit"
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
                                    .Fields("unitprice_").Value = Me.dgdPIC.Item("unitprice_q", i).Value
                                Catch ex As Exception

                                End Try
                                Try
                                    .Fields("price_").Value = Me.dgdPIC.Item("priceincvat_q", i).Value
                                Catch ex As Exception

                                End Try


                                .Update()
                            End With
                            rs.Close()


                            mStatusDebit = "Normal"
                            Me.cmdok_debit.Enabled = False
                            Me.cmdcancel_debit_Click(sender, e)
                            Me.Querydebit()
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                        profit()
                        profit_theonguyente()
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GroupBox6_MouseDown(sender As Object, e As MouseEventArgs) Handles GroupBox6.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GroupBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles GroupBox6.MouseMove
        If Mdown Then
            Me.GroupBox6.Left = (e.X - X) + Me.GroupBox6.Left
            Me.GroupBox6.Top = (e.Y - Y) + Me.GroupBox6.Top
        End If
    End Sub

    Private Sub GroupBox6_MouseUp(sender As Object, e As MouseEventArgs) Handles GroupBox6.MouseUp
        If Mdown Then
            Mdown = False
            Me.GroupBox6.Left = (e.X - X) + Me.GroupBox6.Left
            Me.GroupBox6.Top = (e.Y - Y) + Me.GroupBox6.Top
        End If
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
    Private Sub GroupQuotation_Enter(sender As Object, e As EventArgs) Handles GroupQuotation.Enter

    End Sub

    Private Sub Button96_Click(sender As Object, e As EventArgs) Handles Button96.Click
        Try
            Dim id_ As String
            Dim value_ As String
            Dim strQuery_ As String
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code + '/' + dvt  + '/' + charge as charge_code from charge where CONTINUED=1 and ( Charge_CODE like N'%" & Me.txtfindcharges.Text & "%' or Charge like N'%" & Me.txtfindcharges.Text & "%' or dvt like N'%" & Me.txtfindcharges.Text & "%' )Order by charge_code "



            ' loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)
            loadDataToObject(Me.cboitemdebit, strQuery_, id_, value_)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button97_Click(sender As Object, e As EventArgs) Handles Button97.Click
        Try
            Dim id_ As String
            Dim value_ As String
            Dim strQuery_ As String
            id_ = "charge_id"
            value_ = "charge_code"
            strQuery_ = "Select charge_id,charge_code + '/' + dvt  + '/' + charge as charge_code from charge where CONTINUED=1 and ( Charge_CODE like N'%" & Me.txtfindcharges_credit.Text & "%' or Charge like N'%" & Me.txtfindcharges_credit.Text & "%' or dvt like N'%" & Me.txtfindcharges_credit.Text & "%' )Order by charge_code "



            loadDataToObject(Me.cboitemcredit, strQuery_, id_, value_)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        Try
            Me.GroupBox6.Visible = True
            Me.GroupBox6.BringToFront()
            Dim id, value, strSQL As String
            id = "QuotationID"
            value = "quotationNo"

            Me.cboBKNo_Shipment_pro.Items.Clear()
            Me.cboBKNo_Shipment_pro.Text = ""
            strSQL = "Select  QuotationID,quotationNo + '/'+ Quotation_sale.salename +'/'+ company as quotationNo From Quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id  where Quotation_sale.continued =1 and Quotation_sale.approve=1   and dept='Outbound' and quotation_sale.customer_id='" & FindValueID(Me.cbocusdebit, Me.cbocusdebit.Text) & "' and closed_sp=0 order by Quotation_sale.dateupdate  " ' "
            loadDataToObject(Me.cboBKNo_Shipment_pro, strSQL, id, value)
            ' Me.txtnoQuotation.Text = Me.txtquotation.Text

        Catch ex As Exception

        End Try
    End Sub

    Private Function GetSokhoiFromContainerGrid(ByVal blobId As String, ByVal containerInfo As String) As Double
        Try
            Dim j As Integer
            Dim tongcbm As Double = 0
            Dim found As Boolean = False

            For j = 0 To Me.dgdContainers.Rows.Count - 1
                If Me.dgdContainers.Rows(j).IsNewRow Then Continue For

                Dim contBlobId As String = ""
                Try
                    contBlobId = Me.dgdContainers.Item("outboundID", j).Value.ToString.Trim
                Catch ex As Exception
                    Continue For
                End Try

                If UCase(contBlobId) <> UCase(blobId) Then Continue For

                Dim contKey As String = Me.dgdContainers.Item("containerNo", j).Value.ToString.Trim & "-" & Me.dgdContainers.Item("containerType", j).Value.ToString.Trim
                Dim sokhoi As Double = 0
                Try
                    sokhoi = CDbl(Me.dgdContainers.Item("sokhoi", j).Value.ToString)
                Catch ex As Exception
                    sokhoi = 0
                End Try

                If containerInfo <> "" Then
                    If UCase(contKey) = UCase(containerInfo) OrElse UCase(containerInfo) Like "*" & UCase(Me.dgdContainers.Item("containerNo", j).Value.ToString.Trim) & "*" Then
                        Return sokhoi
                    End If
                Else
                    tongcbm += sokhoi
                    found = True
                End If
            Next

            If containerInfo = "" And found Then
                Return tongcbm
            End If
        Catch ex As Exception

        End Try

        Return -1
    End Function

    Private Sub UpdateDebitQuantityFromContainer(ByVal outboundfreightId As String, ByVal qty As Double)
        Dim strQuery As String
        Dim rs As New ADODB.Recordset

        Try
            copyHistory("outboundfreight", "outboundfreightid", outboundfreightId, "history")
        Catch ex As Exception

        End Try

        strQuery = "SELECT * FROM outboundfreight WHERE outboundfreightid='" & outboundfreightId & "'"
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

            If ConfirmMessage(True, "Bạn có muốn update Quantity (CBM) theo Container?") <> MsgBoxResult.Ok Then
                Exit Sub
            End If

            Dim i As Integer
            Dim updatedCount As Integer = 0

            For i = 0 To Me.dgddebitGrid.Rows.Count - 1
                If Me.dgddebitGrid.Rows(i).IsNewRow Then Continue For

                Try
                    If UCase(Me.dgddebitGrid.Item("containertype_debit", i).Value.ToString.Trim) <> "CBM" Then Continue For
                Catch ex As Exception
                    Continue For
                End Try

                Try
                    If Me.dgddebitGrid.Item("approvedebit", i).Value Then Continue For
                Catch ex As Exception

                End Try

                Dim blobId As String = mOutboundID
                Try
                    blobId = Me.dgddebitGrid.Item("outboundid_debit", i).Value.ToString.Trim
                Catch ex As Exception

                End Try

                Dim containerInfo As String = ""
                Try
                    containerInfo = Me.dgddebitGrid.Item("containerdebit", i).Value.ToString.Trim
                Catch ex As Exception

                End Try

                Dim qty As Double = GetSokhoiFromContainerGrid(blobId, containerInfo)
                If qty < 0 Then Continue For
                If qty < 1 Then qty = 1

                Try
                    UpdateDebitQuantityFromContainer(Me.dgddebitGrid.Item("outboundfreightid_debit", i).Value.ToString, qty)
                    updatedCount += 1
                Catch ex As Exception

                End Try
            Next

            Me.Querydebit()
            profit()
            profit_theonguyente()
            DisplayMessage(True, "Đã update " & updatedCount.ToString & " dòng debit CBM.")
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Sub GroupBox6_Enter(sender As Object, e As EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        Try
            Dim dsdebit1 As New DataSet
            Dim dscredit1 As New DataSet
            Dim sql As String = "Select outboundid,outboundfreightid,customerid,itemid,debitcredit,taxcode + '-' + company as company,charge_code as item,currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, tigia,vitri "
            sql &= " From outboundfreight_sale left join customer on outboundfreight_sale.customerid=customer.customer_id  left join charge on outboundfreight_sale.itemid=charge.charge_id "
            sql &= "Where " &
                   " quotationid='" & FindValueID(Me.cboBKNo_Shipment_pro, Me.cboBKNo_Shipment_pro.Text) & "'   order by charge_code " 'and debitcredit='Debit'
            dsdebit1 = ReadDataSet(sql)
            Me.dgddebitGrid1.DataSource = dsdebit1.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        Try
            Me.GroupBox6.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click
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
                            strQuery = "Select * From Outboundfreight " 'Where Inboundfreightid='" & mdebitID & "'
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs
                                'If rs.EOF Then
                                .AddNew()
                                .Fields("OutboundfreightID").Value = NewId()
                                .Fields("OutboundID").Value = getID(mOutboundID)
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
                        profit_theonguyente()
                    Catch ex As Exception

                    End Try
                End If
            Next
        Catch ex As Exception

        End Try
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

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        Try
            Me.GroupBox7.BringToFront()
            Me.GroupBox7.Visible = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click
        Try

            Me.GroupBox7.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button112_Click(sender As Object, e As EventArgs) Handles Button112.Click
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'If LoginSucceeded = True Then
                '    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                '    frmMain.MdiParent = form
                '    form.Show()
                'End If
                VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button62_Click(sender As Object, e As EventArgs) Handles Button62.Click
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'If LoginSucceeded = True Then
                '    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                '    frmMain.MdiParent = form
                '    form.Show()
                'End If
                VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'If LoginSucceeded = True Then
                '    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                '    frmMain.MdiParent = form
                '    form.Show()
                'End If
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
                mdebitid = Me.dgddebitGrid.Item("outboundfreightid_debit", index).Value.ToString
                sql = "select * from outboundfreight where outboundfreightID='" & mdebitid & "' and debitcredit='Debit'"
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    strQuery = "Select * From outboundfreight "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("outboundfreightID").Value = NewId()
                        .Fields("outboundID").Value = getID(mOutboundID)



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
    Private Sub groupsearchContainer_MouseDown(sender As Object, e As MouseEventArgs) Handles groupsearchContainer.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub groupsearchContainer_MouseMove(sender As Object, e As MouseEventArgs) Handles groupsearchContainer.MouseMove
        If Mdown Then
            Me.groupsearchContainer.Left = (e.X - X) + Me.groupsearchContainer.Left
            Me.groupsearchContainer.Top = (e.Y - Y) + Me.groupsearchContainer.Top
        End If
    End Sub

    Private Sub groupsearchContainer_MouseUp(sender As Object, e As MouseEventArgs) Handles groupsearchContainer.MouseUp
        If Mdown Then
            Mdown = False
            Me.groupsearchContainer.Left = (e.X - X) + Me.groupsearchContainer.Left
            Me.groupsearchContainer.Top = (e.Y - Y) + Me.groupsearchContainer.Top
        End If
    End Sub
    Private Sub Button85_Click(sender As Object, e As EventArgs) Handles Button85.Click
        Try
            Dim id, value, strSQL As String
            id = "OutboundContainersID"
            value = "containerno"
            Me.cbocontainerNO.Items.Clear()


            strSQL = "Select  OutboundContainersID,containerno From containertype left join outbound on  outbound.BLOB_ID=containertype.outboundID   order by containerno desc"
            loadDataToObject(Me.cbocontainerNO, strSQL, id, value)
            Me.groupsearchContainer.Visible = True
            Me.groupsearchContainer.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub groupsearchContainer_Enter(sender As Object, e As EventArgs) Handles groupsearchContainer.Enter

    End Sub

    Private Sub Button111_Click(sender As Object, e As EventArgs) Handles Button111.Click
        Try
            Dim id, value, strSQL As String
            id = "OutboundContainersID"
            value = "containerno"
            Me.cbocontainerNO.Items.Clear()


            strSQL = "Select  OutboundContainersID,containerno From containertype left join outbound on  outbound.BLOB_ID=containertype.outboundID  where   containerno like '%" & Me.txtFContainer.Text & "%'  order by containerno desc"
            loadDataToObject(Me.cbocontainerNO, strSQL, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button109_Click(sender As Object, e As EventArgs) Handles Button109.Click
        Try

            Dim sql As String
            Dim ds As New DataSet
            If UCase(gDepartment) = "SALE" Then
                sql = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,outbound.userupdate ,outbound.DateUpdate,NVOCC  from Outbound left join containertype on outbound.blob_id=containertype.outboundid where salecode='" & gSaleCode & "'  and (branch like '%" & gBranch & "%')   and OutboundContainersID='" & FindValueID(Me.cbocontainerNO, Me.cbocontainerNO.Text) & "'  order by outbound.dateupdate "
                ds = ReadDataSet(sql)
                Me.dgdHBL.DataSource = ds.Tables(0)
                mFilter = " and ref = '" & Me.cboMBLCarrier.Text & "' "
                InsertAutoNumberToGrid(Me.dgdHBL)
            Else
                sql = " select blob_id,stuff(ref,1,4,'') as [order],air,fcl,lcl,consol,status,lot,InvoiceRequest,InvoiceRequestDate,DebitIssued,InvoiceIssued,Paid,closeFile,printdebit,REF,BKNo,MBLCarrier,MBLMAWB,HBLHAWB,shippingline,shipper,consignee,notify,nodebit,nocredit,datereport,approve,editable,continued,outbound.userupdate ,outbound.DateUpdate,NVOCC  from Outbound left join containertype on outbound.blob_id=containertype.outboundid  where OutboundContainersID='" & FindValueID(Me.cbocontainerNO, Me.cbocontainerNO.Text) & "' order by outbound.dateupdate " 'and (branch like '%" & gBranch & "%')   
                ds = ReadDataSet(sql)
                Me.dgdHBL.DataSource = ds.Tables(0)
                mFilter = " and ref = '" & Me.cboMBLCarrier.Text & "' "
                InsertAutoNumberToGrid(Me.dgdHBL)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button108_Click(sender As Object, e As EventArgs) Handles Button108.Click
        Me.groupsearchContainer.Visible = False
    End Sub
End Class




