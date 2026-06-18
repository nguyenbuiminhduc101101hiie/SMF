Imports Excel
Public Class frmSaleSerCharge

    Dim mStatus, mFilter, tarrif, sale, Special, tarrif1, sale1, Special1 As String
    Dim mStatusF As String
    Dim mFreightSaleID As String
    Dim oTableF As New DataSet
    Dim userupdateTarrif, userupdateSale, userupdatespecial, dateUpdateTarrif, dateUpdateSale, dateupdatespecial As String
    Public mContainerOutboundNotifyId, khachhang As String
    Public oTable As DataSet
    Public Function GETSALECODE(ByVal USERNAME As String) As String

        Dim strQuery, _SALECODE As String
        Dim RSSALECODE As New ADODB.Recordset
        strQuery = "SELECT SALECODE FROM SALE WHERE USR='" & USERNAME & "'"
        RSSALECODE.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not RSSALECODE.EOF Then
            _SaleCode = RSSALECODE.Fields("SALECODE").Value.ToString
        Else
            _SALECODE = ""
        End If
        RSSALECODE.Close()
        Return _SALECODE
    End Function
    Public Sub QueryContainerOutboundNotify(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery, SALECODE As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        'If IsNothing(argCriteria) Then
        '    strQuery = MakeQueryContainerOutboundNotify()
        'Else
        '    strQuery = MakeQueryContainerOutboundNotify(argCriteria, index)
        'End If
        SALECODE = GETSALECODE(strUserId.Trim)
        If UCase(gDepartment) = "OUTBOUND" Or UCase(gDepartment) = "MANAGEMENT" Or UCase(gDepartment) = "BOOKING" Or UCase(gDepartment) = "ACCOUNT" Or UCase(gDepartment) = "OPERATION" Or UCase(gDepartment) = "SALE MANAGEMENT" Then
            strQuery = "SELECT CONTAINEROUTBOUNDNOTIFY.ContainerOutBoundNotifyId,fileno,BookingNo,bl_no,(select count(*) from freightsale where containeroutboundnotify.containeroutboundnotifyid=freightsale.containeroutboundnotifyid and continued=1 ) as Quantity ,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,Commondity as Commondity, "
            strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, "
            strQuery = strQuery + " Sell_Way,Sale.Sale_ID,Sale.SaleName,  CONTAINEROUTBOUNDNOTIFY.ServiceContract,mak.Market_ID,mak.Market,  Representative ,  SoLuong20GP,    SoLuong40GP,     SoLuong40HC, "
            strQuery = strQuery + " SoLuong45HC,   SoLuong20RF,SoLuong40RF,  SoLuong40RH,SoLuong20OT,SoLuong40OT,SoLuong20FR,SoLuong40FR ,SoluongCBM,Sale.SaleCode,ServiceFeeder,LocalCargo,EmptyMoving,TransiteCargo,SOC,PayMentTerm,SlotExchange,FOBCargo,FirstSendDate,SecondSendDate,ThirdSendDate,SupplyDate,  SpencialEquipment, Cold ,Ventilation, EmptyContainerPlace,  PackingWay, CustomsLiquiDate, ClosingTime, Tranship, LeavingDate, "
            strQuery = strQuery + " PortOfLoading,PortOfUnLoading, Destination,  ContainerOutBoundNotify.Remarks as Remarks,MaxWMainPort,MaxWLocal,ContactUs,BookingPerson,BookingDate,CloseTime,  CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,"
            strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime, shippingline "
            strQuery = strQuery + " ,(select sum(convert(float, freight)) from freightsale where chargecode='OF' and unit='USD' and freightsale.CONTAINEROUTBOUNDNOTIFYID=CONTAINEROUTBOUNDNOTIFY.CONTAINEROUTBOUNDNOTIFYid ) as BuyFreight,(select sum(convert(float, freightsale)) from freightsale where chargecode='OF' and unit='USD' and freightsale.CONTAINEROUTBOUNDNOTIFYID=CONTAINEROUTBOUNDNOTIFY.CONTAINEROUTBOUNDNOTIFYid ) as SaleFreight From (((((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
            strQuery = strQuery + " left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
            strQuery = strQuery + "left JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) " & _
                                  " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                                  " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID ) left join billoflading on containeroutboundnotify.CONTAINEROUTBOUNDNOTIFYID=billoflading.CONTAINEROUTBOUNDNOTIFYID "
            strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 and CONTAINEROUTBOUNDNOTIFY.Editable=1  "
            If argCriteria <> "" Then
                strQuery = strQuery + argCriteria
            End If
        Else
            strQuery = "SELECT CONTAINEROUTBOUNDNOTIFY.ContainerOutBoundNotifyId,fileno,BookingNo,bl_no,(select count(*) from freightsale where containeroutboundnotify.containeroutboundnotifyid=freightsale.containeroutboundnotifyid and continued=1 ) as Quantity ,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,Commondity as Commondity, "
            strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, "
            strQuery = strQuery + " Sell_Way,Sale.Sale_ID,Sale.SaleName,  CONTAINEROUTBOUNDNOTIFY.ServiceContract,mak.Market_ID,mak.Market,  Representative ,  SoLuong20GP,    SoLuong40GP,     SoLuong40HC, "
            strQuery = strQuery + " SoLuong45HC,   SoLuong20RF,SoLuong40RF,  SoLuong40RH, SoLuong20OT,SoLuong40OT,SoLuong20FR,SoLuong40FR ,SoluongCBM,Sale.SaleCode,ServiceFeeder,LocalCargo,EmptyMoving,TransiteCargo,SOC,PayMentTerm,SlotExchange,FOBCargo,FirstSendDate,SecondSendDate,ThirdSendDate,SupplyDate,  SpencialEquipment, Cold ,Ventilation, EmptyContainerPlace,  PackingWay, CustomsLiquiDate, ClosingTime, Tranship, LeavingDate, "
            strQuery = strQuery + " PortOfLoading,PortOfUnLoading, Destination,  ContainerOutBoundNotify.Remarks as Remarks,MaxWMainPort,MaxWLocal,ContactUs,BookingPerson,BookingDate,CloseTime,  CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,"
            strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime,shippingline "

            strQuery = strQuery + " ,(select sum(convert(float, freight)) from freightsale where chargecode='OF' and unit='USD' and freightsale.CONTAINEROUTBOUNDNOTIFYID=CONTAINEROUTBOUNDNOTIFY.CONTAINEROUTBOUNDNOTIFYid ) as BuyFreight,(select sum(convert(float, freightsale)) from freightsale where chargecode='OF' and unit='USD' and freightsale.CONTAINEROUTBOUNDNOTIFYID=CONTAINEROUTBOUNDNOTIFY.CONTAINEROUTBOUNDNOTIFYid ) as SaleFreight From (((((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
            strQuery = strQuery + " left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
            strQuery = strQuery + "left JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) " & _
                                  " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                                  " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID ) left join billoflading on containeroutboundnotify.CONTAINEROUTBOUNDNOTIFYID=billoflading.CONTAINEROUTBOUNDNOTIFYID "
            strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 and CONTAINEROUTBOUNDNOTIFY.Editable=1 and sale.salecode='" & SALECODE & "'  "
            If argCriteria <> "" Then
                strQuery = strQuery + argCriteria
            End If

        End If


        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "ContainerOutboundNotifyList")
        oTable = ds
        'hien thi ra grid 
        Me.dgdContianerOutboundNotify.DataSource = ds.Tables("ContainerOutboundNotifyList")
        If Me.dgdContianerOutboundNotify.Enabled = False Then
            Me.dgdContianerOutboundNotify.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Tables("ContainerOutboundNotifyList").Rows.Count > 0 Then
            Me.dgdContianerOutboundNotify.Columns.Item("BookingNo").ToolTipText = "Hiện có:" + CStr(Me.dgdContianerOutboundNotify.RowCount()) + " ContainerOutboundNotifys."
        End If
        If Me.dgdContianerOutboundNotify.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdContianerOutboundNotify.Rows.Count And Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            Me.dgdContianerOutboundNotify.Rows(location).Selected = True
            Me.dgdContianerOutboundNotify.CurrentCell = Me.dgdContianerOutboundNotify.Rows(location).Cells("BookingNo")
        End If
        '--------------------

        '--------------------
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
            For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
                    Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmSaleSerCharge_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CheckLockBooking()
        Dim Conn As New SqlClient.SqlConnection()
        Try
            Dim strConn As String
            strConn = "Data Source='" & strServer & "'; User ID='lock'; password='lock'; Initial Catalog='" & strDatabase & "'"
            Conn = New SqlClient.SqlConnection(strConn)
            Conn.Open()
            Dim SQL As String
            SQL = " Update FreightSale Set Approve=1"
            SQL &= " Where ContaineroutboundNotifyID "
            SQL &= " In (Select ContainerOutboundNotifyID "
            SQL &= " from ContainerOutboundNotify Inner Join SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
            SQL &= " where ETD-'" & GetServerDate().Date & "'<=1)"
            Dim cmd As New SqlClient.SqlCommand("", Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            conn.close()
        End Try
    End Sub

    Private Sub frmSaleSerCharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        Me.txtServicetermPOL.Enabled = True
        Me.txtServiceTermPOD.Enabled = True
        Me.txtRemain.ReadOnly = True
        Me.txtprofit.ReadOnly = True
        mStatus = "Normal"
        mStatusF = "Normal"
        userupdateTarrif = ""
        userupdateSale = ""
        dateUpdateTarrif = ""
        dateUpdateSale = ""
        mContainerOutboundNotifyId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'CheckLockBooking()
        Me.tab.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdContianerOutboundNotify)


        'Me.cboFind.Text = objUserSetting.GetCParm("frmContainerOutBoundNotify.cboFind", "Company")

        'If Me.txtContainerOutboundNotify.Text <> "" Then
        '    QueryContainerOutboundNotify("AND BookingNo LIKE '" & MakeFilter(Me.txtContainerOutboundNotify.Text) & "' " & mFilter, , 15)
        'Else
        'QueryContainerOutboundNotify()
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        Me.smnuDisplayRepresentative.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayRepresentative")
        Me.smnuDisplayBookingPerson.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayBookingPerson")
        Me.smnuDisplayBookingDate.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayBookingPerson")
        Me.smnuDisplayDestination.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayDestination")
        Me.smnuDisplayLeavingDate.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayLeavingDate")
        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayAPPROVE")
        Me.smnuDisplayRemarks.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayREMARKS")
        Me.smnuDisplayPortOfUnLoading.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayPortOfUnLoading")
        Me.smnuDisplayClosingTime.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayClosingTime")
        Me.smnuDisplayEmptyConatinerPlace.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayEmptyContainerPlace")
        Me.smnuDisplayPackingWay.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayPackingWay")
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayUpdateTime")

        UpdateFrame()
        QueryCombo()
        QueryCustomer()
        SetDefaultGrid(Me.dgdContianerOutboundNotify, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdFreight, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOKF.Enabled = False
        ReFormat()

        '----set mau nen,fra
        Me.BackColor = gMaunen
        Me.tab.BackColor = gMauFra
        Me.TabPage2.BackColor = gMauFra
       
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryCustomer()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Customer_ID"
        value = "Company"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Customer_ID,Company From Customer where Continued=1 Order By Company asc"
        'If Me.cboCompany.Items.Count = 0 Then
        loadDataToObject(Me.cboNote, strSQL, id, value)
        loadDataToObject(Me.cbonote1, strSQL, id, value)
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        Me.dgdContianerOutboundNotify.Columns.Item("ContainerOutBoundNotifyId").Visible = False
        Me.dgdContianerOutboundNotify.Columns.Item("Representative").Visible = Me.smnuDisplayRepresentative.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("BookingPerson").Visible = Me.smnuDisplayBookingPerson.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("BookingDate").Visible = Me.smnuDisplayBookingDate.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Destination").Visible = Me.smnuDisplayDestination.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("LeavingDate").Visible = Me.smnuDisplayLeavingDate.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("PackingWay").Visible = Me.smnuDisplayPackingWay.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("EmptyContainerPlace").Visible = Me.smnuDisplayEmptyConatinerPlace.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("PortOfUnLoading").Visible = Me.smnuDisplayPortOfUnLoading.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("ClosingTime").Visible = Me.smnuDisplayClosingTime.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Editable").Visible = False
        Me.dgdContianerOutboundNotify.Columns.Item("Continued").Visible = False
        Me.dgdContianerOutboundNotify.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Remarks").Visible = Me.smnuDisplayRemarks.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Me.dgdContianerOutboundNotify.Columns.Item("BookingNo").Visible = Me.smnuDisplayBookingNo.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Company").Visible = Me.smnuDisplayCompany.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Address").Visible = Me.smnuDisplayAddres.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Telephone").Visible = Me.smnuDisplayTelephone.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("RF20").Visible = True 'Me.smnuDisplayContainer.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("RF40").Visible = True  'Me.smnuDisplayContainer.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("GP20").Visible = True 'Me.smnuDisplayContainer.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("GP40").Visible = True 'Me.smnuDisplayContainer.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("HC40").Visible = True 'Me.smnuDisplayContainer.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("HC45").Visible = True 'Me.smnuDisplayContainer.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("RH40").Visible = True 'Me.smnuDisplayContainer.Checked

        Me.dgdContianerOutboundNotify.Columns.Item("Cold").Visible = Me.smnuDisplayCold.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("CustomsLiquiDate").Visible = Me.smnuDisplayCustomsLiquiDate.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Ventilation").Visible = Me.smnuDisplayVentilation.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("SpecialEquipment").Visible = Me.smnuDisplaySpencialEquipment.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Tranship").Visible = Me.smnuDisplayTranship.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Pre_Vessel").Visible = Me.smnuDisplayVessel.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Market").Visible = Me.smnuDisplayMarket.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("ServiceContract").Visible = Me.smnuDisplayServiceContract.Checked
        Me.dgdContianerOutboundNotify.Columns.Item("Sell_Way").Visible = Me.smnuDisplaySellWay.Checked

        Me.dgdContianerOutboundNotify.Refresh()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

#Region "ViewMenuStrip"
    Private Sub smnuDisplayNguoiDaiDien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRepresentative.Click
        Me.smnuDisplayRepresentative.Checked = Not Me.smnuDisplayRepresentative.Checked
        UpdateFrame()

    End Sub

    Private Sub smnuDisplayNgayGuiBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBookingDate.Click
        Me.smnuDisplayBookingDate.Checked = Not Me.smnuDisplayBookingDate.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNguoiGuiBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBookingPerson.Click
        Me.smnuDisplayBookingPerson.Checked = Not Me.smnuDisplayBookingPerson.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayDichCuoiCung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDestination.Click
        Me.smnuDisplayDestination.Checked = Not Me.smnuDisplayDestination.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNgayDi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayLeavingDate.Click
        Me.smnuDisplayLeavingDate.Checked = Not Me.smnuDisplayLeavingDate.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCangDoHang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPortOfUnLoading.Click
        Me.smnuDisplayPortOfUnLoading.Checked = Not Me.smnuDisplayPortOfUnLoading.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayThoiHanChotHaBai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayClosingTime.Click
        Me.smnuDisplayClosingTime.Checked = Not Me.smnuDisplayClosingTime.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNoilayContainerRong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayEmptyConatinerPlace.Click
        Me.smnuDisplayEmptyConatinerPlace.Checked = Not Me.smnuDisplayEmptyConatinerPlace.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPhuongAnLamHang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPackingWay.Click
        Me.smnuDisplayPackingWay.Checked = Not Me.smnuDisplayPackingWay.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRemarks.Click
        Me.smnuDisplayRemarks.Checked = Not Me.smnuDisplayRemarks.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub
    Private Sub smnuDisplayBookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBookingNo.Click
        Me.smnuDisplayBookingNo.Checked = Not Me.smnuDisplayBookingNo.Checked
        UpdateFrame()

    End Sub

    Private Sub smnuDisplayCongty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCompany.Click
        Me.smnuDisplayCompany.Checked = Not Me.smnuDisplayCompany.Checked()
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayDiaChi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayAddres.Click
        Me.smnuDisplayAddres.Checked = Not Me.smnuDisplayAddres.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTelephone.Click
        Me.smnuDisplayTelephone.Checked = Not Me.smnuDisplayTelephone.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFax.Click
        Me.smnuDisplayFax.Checked = Not Me.smnuDisplayFax.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNhietDoLanh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCold.Click
        Me.smnuDisplayCold.Checked = Not Me.smnuDisplayCold.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayHaCangThanhLyHQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCustomsLiquiDate.Click
        Me.smnuDisplayCustomsLiquiDate.Checked = Not Me.smnuDisplayCustomsLiquiDate.Checked
        UpdateFrame()

    End Sub

    Private Sub smnuDisplayThongGio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayVentilation.Click
        Me.smnuDisplayVentilation.Checked = Not Me.smnuDisplayVentilation.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplaySpencialEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySpencialEquipment.Click
        Me.smnuDisplaySpencialEquipment.Checked = Not Me.smnuDisplaySpencialEquipment.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayChuyenTai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTranship.Click
        Me.smnuDisplayTranship.Checked = Not Me.smnuDisplayTranship.Checked
        UpdateFrame()

    End Sub

    Private Sub smnuDisplaySellWay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySellWay.Click
        Me.smnuDisplaySellWay.Checked = Not Me.smnuDisplaySellWay.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMarket.Click
        Me.smnuDisplayMarket.Checked = Not Me.smnuDisplayMarket.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayServiceContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayServiceContract.Click
        Me.smnuDisplayServiceContract.Checked = Not Me.smnuDisplayServiceContract.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayXuatTrenTau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayVessel.Click
        Me.smnuDisplayVessel.Checked = Not Me.smnuDisplayVessel.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayContainer.Click
        Me.smnuDisplayContainer.Checked = Not Me.smnuDisplayContainer.Checked
        UpdateFrame()
    End Sub
#End Region

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
        dgdContianerOutboundNotify.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdContianerOutboundNotify.Height = Me.Height - Me.cmdCancel.Height - 50 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdContianerOutboundNotify.Height = Me.Height - 70 - IIf(tab.Visible, tab.Height + 5, 40) ' < 7000
        End If

        Me.fraUpdate.Width = (Me.Width - 30)
        Me.fraUpdate.Top = dgdContianerOutboundNotify.Height + dgdContianerOutboundNotify.Top
        Me.fraUpdate.Height = Me.Height - 100
        Me.txtContainerOutboundNotify.Width = Me.Width - 300
        Me.dgdFreight.Width = Me.Width - 50
        'me.txtCompany.Width = Me.fraUpdate.Width - me.txtCompany.Left - 10
        'me.txtCuctomsLiquiDate.Width = Me.fraUpdate.Width - me.txtCuctomsLiquiDate.Left - 10
        'me.txtCompany.Width = Me.fraUpdate.Width -me.txtRepresentative.Left - 10

        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdOK.Top = fraUpdate.Bottom + cmdOK.Height
        'cmdCancel.Top = fraUpdate.Bottom + cmdOK.Height
        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10

        cmdFind.Left = Me.txtContainerOutboundNotify.Left + Me.txtContainerOutboundNotify.Width + 10
        txtContainerOutboundNotify.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmSaleSerCharge_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ' ReFormat()
    End Sub

    Private Sub frmSaleSerCharge_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'ReFormat()
    End Sub

    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Sale Surcharge "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Sale Surcharge -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Sale Surcharge -> Add."
        End If

    End Sub

    Function CheckExist() As Boolean
        Try
            Dim tbl As New DataSet
            Dim strSql As String = "Select * From FreightSale where ContainerOutBoundNotifyId='" & mContainerOutboundNotifyId & "' and continued=1 "
            tbl = ReadDataSet(strSql)
            If tbl.Tables(0).Rows.Count = 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Sub ReFreshData(ByVal index As Integer)
        Try
            'if IsDBNull(Me.dgdContianerOutboundNotify.Item("PortOfUnLoading", index).Value) = False Then
            Me.txtPOD.Text = Me.dgdContianerOutboundNotify.Item("PortOfUnLoading", index).Value
            'End If
            Me.txtBookingNo.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value
            Me.txtfileno.Text = Me.dgdContianerOutboundNotify.Item("fileno", index).Value
            Me.txtServiceContract.Text = Me.dgdContianerOutboundNotify.Item("ServiceContract", index).Value
            Me.txtPOL.Text = Me.dgdContianerOutboundNotify.Item("PortOfLoading", index).Value




            'If IsDBNull(Me.dgdContianerOutboundNotify.Item("Tranship", index).Value) = False Then
            Me.txtOPL.Text = Me.dgdContianerOutboundNotify.Item("Tranship", index).Value
            'End If
            'If IsDBNull(Me.dgdContianerOutboundNotify.Item("Destination", index).Value) = False Then
            Me.txtFDEST.Text = Me.dgdContianerOutboundNotify.Item("Destination", index).Value
            'End If
            'If IsDBNull(Me.dgdContianerOutboundNotify.Item("Company", index).Value) = False Then
            Me.txtCusName.Text = Me.dgdContianerOutboundNotify.Item("Company", index).Value
            'End If
            'If IsDBNull(Me.dgdContianerOutboundNotify.Item("ServiceContract", index).Value) = False Then
            Me.txtETD.Text = Me.dgdContianerOutboundNotify.Item("leavingDate", index).Value
            Me.txtServiceContract.Text = Me.dgdContianerOutboundNotify.Item("ServiceContract", index).Value
            'End If
            Me.txtremarksBooking.Text = Me.dgdContianerOutboundNotify.Item("remarks", index).Value
            If IsDBNull(Me.dgdContianerOutboundNotify.Item("Commodity", index).Value) = False Then
                Me.txtCommondity.Text = Me.dgdContianerOutboundNotify.Item("Commodity", index).Value
            Else
                Me.txtCommondity.Text = ""
            End If
            Me.txtBLNo.Text = Me.dgdContianerOutboundNotify.Item("billno", index).Value.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryCombo()
        Try
            Dim id, value, strSQL As String
            'id = "Port_ID"
            'value = "Port"
            'strSQL = "Select Port_ID,Port From Port where Continued=1 Order By Port desc"
            'loadDataToObject(Me.txtFDEST, strSQL, id, value)
            'loadDataToObject(Me.txtOPL, strSQL, id, value)
            'loadDataToObject(Me.txtPOD, strSQL, id, value)

            'id = "Commondity_ID"
            'value = "Commondity"
            'strSQL = "Select Commondity_ID,Commondity From Commondity where Continued=1 Order By Commondity desc"
            'loadDataToObject(Me.txtCommondity, strSQL, id, value)

            id = "Charge_ID"
            value = "Charge_Code"
            strSQL = "Select * From Charge where Continued=1 Order By Charge_Code asc"
            loadDataToObject(Me.cboCharge, strSQL, id, value)

            strSQL = "Select Currency  from Currency"
            Dim tbl As New DataSet
            tbl = ReadDataSet(strSQL)
            Me.cboUnit.Items.Clear()
            For i As Integer = 0 To tbl.Tables(0).Rows.Count - 1
                Me.cboUnit.Items.Add(tbl.Tables(0).Rows(i).Item("Currency"))
            Next
            If Me.cboUnit.Items.Count > 0 Then
                Me.cboUnit.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryKind(ByVal index As Integer)
        Try
            Dim oItems As PDSAListItemString
            Me.cboKind.Items.Clear()
            For i As Integer = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                Dim st As String = Me.dgdContianerOutboundNotify.Columns(i).DataPropertyName
                Dim st1 As String = dgdContianerOutboundNotify.Columns(i).Name

                If UCase(st) Like "*SOLUONG*" Then
                    Dim s As String = Me.dgdContianerOutboundNotify.Item(st1, index).Value.ToString
                    If s <> "0" Then
                        Dim num As Integer = 0
                        Dim strF As String = Me.dgdContianerOutboundNotify.Columns(i).HeaderText
                        Dim tbl As New DataSet
                        tbl = ReadDataSet("Select count(*) as cnt From FreightSale where Kind='" & strF & "' and ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1")
                        If tbl.Tables(0).Rows.Count > 0 Then
                            num = tbl.Tables(0).Rows(0)("cnt")
                        End If
                        oItems = New PDSAListItemString
                        oItems.ID = (CInt(s) - num).ToString
                        oItems.Value = strF
                        Me.cboKind.Items.Add(oItems)
                    End If
                End If
            Next
            oItems = New PDSAListItemString
            oItems.ID = "B/L"
            oItems.Value = "B/L"
            Me.cboKind.Items.Add(oItems)
            If Me.cboKind.Items.Count > 0 Then
                Me.cboKind.Enabled = True
                Me.cboKind.SelectedIndex = 0
            Else
                Me.cboKind.Enabled = False

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        Dim index As Integer
        Dim Approve, EditTable, UsrRight As Boolean
        If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) = True Or Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If

        index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        'Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
        'EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value

        If mStatus = "Normal" And UserRight("frmSaleSerCharge", "Add") Then
            If CheckExist() = True Then
                MsgBox("This Booking had Freight, Please click Menu Edit! ")
                Return
            End If
            Me.fraUpdate.Visible = True
            Me.dgdContianerOutboundNotify.Enabled = False
            ReFormat()
            SetMenu((False))
            mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
            mStatus = "Add"
            reText(mStatus)
            Me.txtBookingNo.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value
            ReFreshData(index)
            Me.txtPOL.Text = "VNSGN"
            ReFormat()
            QueryKind(index)
            QueryGrid()
            Me.cmdOKF.Enabled = False
            Me.cmdOk_Click(sender, e)
            'Me.smnuEdit_Click(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Function CheckData() As Boolean
        Try
            Dim msg As String = ""
            If msg <> "" Then
                MsgBox(msg)
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strContainerOutboundNotifyId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = -1

        If Me.dgdContianerOutboundNotify.RowCount > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Surcharge "
            strQuery = strQuery & "WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "' AND ContainerOutBoundNotifyId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Surcharge_ID").Value = NewId()
                End If
                .Fields("ContainerOutBoundNotifyId").Value = "{" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "}"
                .Fields("BookingNo").Value = Me.txtBookingNo.Text.Trim
                '.Fields("CusName").Value = Me.txtCusName.Text.Trim
                '.Fields("POL").Value = Me.txtPOL.Text.Trim
                '.Fields("OPL_ID").Value = Me.txtOPL.Text
                '.Fields("POD_ID").Value = Me.txtPOD.Text
                '.Fields("FDEST_ID").Value = Me.txtFDEST.Text
                '.Fields("Commondity_ID").Value = Me.txtCommondity.Text
                '.Fields("CanvasCode").Value = Me.txtCanvasCode.Text.Trim
                '.Fields("SaleCode").Value = Me.dgdContianerOutboundNotify.Item("SaleCode", index).Value
                '.Fields("ServiceContract").Value = Me.txtServiceContract.Text.Trim
                .Update()

            End With
            rs.Close()
            Me.dgdContianerOutboundNotify.Enabled = True
            'Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            reText(mStatus)
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdContianerOutboundNotify.Enabled = True
        QueryContainerOutboundNotify(" " & mFilter)
        'Me.cmdCancelF_Click(sender, e)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim index As Integer
        Dim Approve, EditTable, UsrRight As Boolean
        If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) = True Or Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If

        index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        khachhang = Me.dgdContianerOutboundNotify.Item("company", index).Value.ToString.Trim
        Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
        EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value
        If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmSaleSerCharge", "Add") Then
            If Me.dgdContianerOutboundNotify.Item("Quantity", index).Value.ToString = "0" Then
                MsgBox("Booking này chưa có Freight. Vui lòng Insert")
                Return
            End If
            Me.fraUpdate.Visible = True
            Me.dgdContianerOutboundNotify.Enabled = False
            ReFormat()
            SetMenu((False))
            mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString

            Dim tbl As New DataSet
            'Dim strSql As String = "Select BookingNo,POL, por1.Port as POD,por2.Port as OPL,por3.Port as FDEST,commondity,canvasCode,SaleCode,CusName,ServiceContract  " & _
            '                       "From (((Surcharge LEFT JOIN Port por1 ON por1.Port_ID=Surcharge.POD_ID) " & _
            '                       "LEFT JOIN Port por2 ON por2.Port_ID=Surcharge.OPL_ID) " & _
            '                       "LEFT JOIN Port por3 ON por3.Port_ID=Surcharge.FDEST_ID) " & _
            '                       "Left JOIN Commondity ON Commondity.Commondity_ID=Surcharge.Commondity_ID " & _
            '                       "Where ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and Surcharge.continued=1 "
            'Dim strSql As String = "Select * from Surcharge Where ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and Surcharge.continued=1 "
            'tbl = ReadDataSet(strSql)
            'If tbl.Tables(0).Rows.Count > 0 Then
            '    Me.txtBookingNo.Text = tbl.Tables(0).Rows(0).Item("BookingNo").ToString
            '    Me.txtCanvasCode.Text = tbl.Tables(0).Rows(0).Item("CanvasCode").ToString
            '    Me.txtCusName.Text = tbl.Tables(0).Rows(0).Item("CusName").ToString
            '    Me.txtPOL.Text = tbl.Tables(0).Rows(0).Item("POL").ToString
            '    Me.txtCommondity.Text = tbl.Tables(0).Rows(0).Item("Commondity_id").ToString
            '    Me.txtFDEST.Text = tbl.Tables(0).Rows(0).Item("FDEST_id").ToString
            '    Me.txtOPL.Text = tbl.Tables(0).Rows(0).Item("OPL_id").ToString
            '    Me.txtPOD.Text = tbl.Tables(0).Rows(0).Item("POD_id").ToString
            '    Me.txtServiceContract.Text = tbl.Tables(0).Rows(0).Item("ServiceContract").ToString
            'End If
            ReFreshData(index)
            mStatus = "Add"
            reText(mStatus)
            ReFormat()
            QueryKind(index)
            QueryGrid()
            fRemainProfit()
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        Me.Close()
    End Sub

    Sub ReFreshFreight(ByVal index As Integer)
        Try
            Me.cboCharge.Text = Me.dgdFreight.Item("ChargeCode", index).Value
            'Me.txtCharge.Text = Me.dgdFreight.Item("Charge", index).Value.ToString

            Me.cboUnit.Text = Me.dgdFreight.Item("Unit", index).Value.ToString
            Me.cboKind.Text = Me.dgdFreight.Item("Kind", index).Value.ToString
            Me.TXTSpecialFreight.Text = Me.dgdFreight.Item("FreightSpecial", index).Value




            Me.txtFreightBuyTruocthue.Text = Me.dgdFreight.Item("FreightTruocthue", index).Value.ToString
            Me.txtTaxFreightbuy.Text = Me.dgdFreight.Item("TaxFreight", index).Value.ToString
            Me.txtFreight.Text = Me.dgdFreight.Item("Freight", index).Value.ToString

            Me.txtFreightSaleTruocthue.Text = Me.dgdFreight.Item("FreightsaleTruocthue", index).Value.ToString
            Me.txtTaxFreightSale.Text = Me.dgdFreight.Item("TaxFreightsale", index).Value.ToString
            Me.txtFreightSale.Text = Me.dgdFreight.Item("FreightSale", index).Value.ToString





            Me.txtRemarks.Text = Me.dgdFreight.Item("RemarksSurcharge", index).Value.ToString
            Me.cboNote.Text = Me.dgdFreight.Item("Note", index).Value.ToString
            Me.txtremarkscredit.Text = Me.dgdFreight.Item("Remarkscredit", index).Value.ToString
            Me.cbonote1.Text = Me.dgdFreight.Item("Note1", index).Value.ToString
            Me.txtServicetermPOL.Text = Me.dgdFreight.Item("ServiceTermPOL", index).Value.ToString
            Me.txtServicetermPOD.Text = Me.dgdFreight.Item("ServiceTermPOD", index).Value.ToString
            Me.txtpayterm.Text = Me.dgdFreight.Item("PayTerm", index).Value.ToString
            Me.txtpaytermSale.Text = Me.dgdFreight.Item("PayTermsale", index).Value.ToString
            Me.txttax.Text = Me.dgdFreight.Item("tax", index).Value.ToString
            tarrif = Me.txtFreight.Text
            sale = Me.txtFreightSale.Text
            Special = Me.TXTSpecialFreight.Text

            'Me.txtpaytermSpecial.Text = Me.dgdFreight.Item("PayTermspecial", index).Value.ToString
            If Me.dgdFreight.Item("commisionCus", index).Value.ToString = "" Then
                Me.txtcom.Text = ""
            Else

                Me.txtcom.Text = Me.dgdFreight.Item("commisionCus", index).Value.ToString
            End If







        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtAdd.Click
        Try
            mFreightSaleID = DefaultValue
            Me.txtFreightSale.Text = "0"
            Me.txtFreight.Text = "0"
            Me.TXTSpecialFreight.Text = "0"

            tarrif = Me.txtFreight.Text
            sale = Me.txtFreightSale.Text
            Special = Me.TXTSpecialFreight.Text

            mStatusF = "Add"
            cmdOKF.Enabled = True
            reText(mStatusF)
            Me.dgdFreight.Enabled = False
            Me.cboKind.Enabled = True
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtEdit.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.dgdFreight.RowCount > 0 Then
                index = Me.dgdFreight.CurrentRow.Index
            Else
                Exit Sub
            End If
            Approve = Me.dgdFreight.Item("ApproveF", index).Value
            EditTable = Me.dgdFreight.Item("EditableF", index).Value
            If mStatusF = "Normal" And Not Approve And EditTable And UserRight("frmSaleSerCharge", "Edit") And Not Me.dgdFreight.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.cmdOKF.Enabled = True
                mStatusF = "Edit"
                mFreightSaleID = Me.dgdFreight.Item("FreightSale_ID", index).Value.ToString
                ReFreshFreight(index)
                Me.dgdFreight.Enabled = False
                reText(mStatusF)
                Me.cboKind.Enabled = True
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtDelete.Click
        Try
            Dim index As Integer
            If IsNothing(Me.dgdFreight.CurrentRow) = True Then
                Return
            End If
            index = Me.dgdFreight.CurrentRow.Index
            Dim strQuery As String
            strQuery = "select * from FreightSale where FreightSale_ID='" & Me.dgdFreight.Item("FreightSale_ID", index).Value.ToString & "' And Continued=1"
            Dim rs As New ADODB.Recordset
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 0
            rs.Update()
            rs.Close()
            QueryGrid()
            QueryKind(index)
            QueryContainerOutboundNotify(" " & mFilter)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function CheckDataFreight() As Boolean
        Try
            Dim msg As String = ""
            Dim tbl As New DataSet

            'If Me.lblCount.Text = "-1" Then
            '    MsgBox("Booking không có Container")
            '    Return False
            'End If

            Dim strSql As String = "Select count(*) cnt from FreightSale where Kind='" & Me.cboKind.Text & "' and Charge='" & Me.cboCharge.Text & "' and ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1"
            tbl = ReadDataSet("Select count(*) cnt from FreightSale where Kind='" & Me.cboKind.Text & "' and ChargeCode='" & Me.cboCharge.Text & "' and ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1")
            If tbl.Tables(0).Rows(0).Item("cnt") > 0 And mStatusF = "Add" Then
                'msg &= "Phí của loại Container này đã tồn tại"
            End If

            'If Me.lblCount.Text = "0" And msg = "" Then
            '    msg &= "Hết Container cho loại này"
            'End If


            'If msg = "" And IsNumeric(Me.txtFreightSale.Text.Trim) = False Then
            '    msg &= "The Freight (Sale) is invalid"
            'End If

            'If msg = "" And IsNumeric(Me.TXTSpecialFreight.Text.Trim) = False Then
            '    msg &= "The Freight (Special) is invalid"
            'End If

            'If msg = "" And IsNumeric(Me.txtFreight.Text.Trim) = False Then
            '    msg &= "The Freight (S/C) is invalid"
            'End If
            If Me.txtServiceContract.Text = "" Then
                If Me.txtpayterm.Text = "" Then
                    msg &= "The Payterm is invalid !"
                End If

            End If
            If msg <> "" Then
                MsgBox(msg)
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmdOKF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKF.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.txtFreight.Text = "" Or Me.txtFreightSale.Text = "" Or Me.txtpayterm.Text = "" Or Me.txtpaytermSale.Text = "" Then
                DisplayMessage(True, "Xin kiểm tra lại Giá mua và giá bán hay phương thức thanh toán!")
                Return
            End If
            If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            End If

            If CheckDataFreight() And (mStatusF = "Add" Or mStatusF = "Edit") Then
                If mStatus = "Edit" Then
                    CopyValues("FreightSale", "FreightSale_Id", mFreightSaleID)

                End If
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM FreightSale "
                strQuery = strQuery & "WHERE FreightSale_Id = '" & mFreightSaleID & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("FreightSale_ID").Value = NewId()
                    End If
                    .Fields("ContainerOutBoundNotifyId").Value = "{" & mContainerOutboundNotifyId & "}"
                    .Fields("ChargeCode").Value = Me.cboCharge.Text.Trim
                    '.Fields("Charge").Value = Me.txtCharge.Text.Trim
                    .Fields("Unit").Value = Me.cboUnit.Text.Trim
                    .Fields("Kind").Value = Me.cboKind.Text.Trim

                    '---------------------
                    .Fields("pricecredittruocthue").Value = Me.txtFreightBuyTruocthue.Text.Trim
                    .Fields("taxpricecredit").Value = Me.txtTaxFreightbuy.Text.Trim
                    .Fields("Freight").Value = Me.txtFreight.Text.Trim

                    '---------------------------------------------------
                    .Fields("pricedebittruocthue").Value = Me.txtFreightSaleTruocthue.Text.Trim
                    .Fields("taxpricedebit").Value = Me.txtTaxFreightSale.Text.Trim
                    .Fields("FreightSale").Value = Me.txtFreightSale.Text.Trim

                    '----------------------------------------------------------------------------------





                    .Fields("FreightSpecial").Value = Me.TXTSpecialFreight.Text.Trim
                    .Fields("ServiceTermPOL").Value = Me.txtServiceTermPOL.Text
                    .Fields("ServiceTermPOD").Value = Me.txtServiceTermPOD.Text
                    .Fields("PayTerm").Value = Me.txtpayterm.Text
                    .Fields("PayTermsale").Value = Me.txtpaytermSale.Text
                    '.Fields("PayTermspecial").Value = Me.txtpaytermSpecial.Text
                    .Fields("commisionCus").Value = Me.txtcom.Text
                    .Fields("tax").Value = Me.txttax.Text

                    If userupdateTarrif <> "" Then
                        .Fields("UserUpdateTarrif").Value = userupdateTarrif
                        .Fields("DateUpdateTarrif").Value = dateUpdateTarrif
                    ElseIf userupdateSale <> "" Then
                        .Fields("UserUpdatesale").Value = userupdateSale
                        .Fields("DateUpdatesale").Value = dateUpdateSale
                    ElseIf userupdatespecial <> "" Then
                        .Fields("UserUpdatespecial").Value = userupdatespecial
                        .Fields("DateUpdatespecial").Value = dateupdatespecial
                    End If
                    .Fields("Note").Value = Me.cboNote.Text.Trim
                    .Fields("Note1").Value = Me.cbonote1.Text.Trim
                    .Fields("Remarks").Value = Me.txtRemarks.Text.Trim
                    .Fields("Remarkscredit").Value = Me.txtremarkscredit.Text.Trim
                    .Update()
                End With
                rs.Close()
                Me.cmdOKF.Enabled = False
                Me.dgdFreight.Enabled = True
                QueryContainerOutboundNotify(" " & mFilter)

                QueryGrid()
                'If mStatusF = "Add" Then
                '    Dim int As Integer = FindValueID(Me.cboKind, Me.cboKind.Text.Trim)
                '    Dim st As String = Me.cboKind.Text.Trim
                '    Dim pos As Integer = Me.cboKind.SelectedIndex

                '    Me.cboKind.Items.RemoveAt(pos)
                '    Dim oItems As PDSAListItemString
                '    oItems = New PDSAListItemString
                '    oItems.ID = int - 1
                '    oItems.Value = st
                '    Me.cboKind.Items.Add(oItems)
                '    Me.cboKind.SelectedIndex = pos
                'End If

                'Me.dgdContianerOutboundNotify.Enabled = True
                'Me.fraUpdate.Visible = False
                'ReFormat()
                'SetMenu((True))
                'mStatus = "Normal"
                'reText(mStatus)
            End If
            mStatusF = "Normal"
            Me.dgdFreight.Enabled = True
            Me.cmdOKF.Enabled = False
            fRemainProfit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function fRemainProfit() As String
        Try
            Dim msg As String = ""
            Dim tblsaleUSD, tblsaleVND, tblCongNoUSD, tblCongNoVND As New DataSet
            Dim sumVND, sumsaleUSD, sumBuyUSD, sumCongNoVND, sumCongNoUSD, totalUSD, totalVND, remainUSD, comUSD, TaxUsd As Double
            Dim i, j As Integer
            'If Me.lblCount.Text = "-1" Then
            '    MsgBox("Booking không có Container")
            '    Return False
            'End If

            Dim strSqlSaleUSD As String = "Select * from FreightSale where ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1 and unit='USD'"
            tblsaleUSD = ReadDataSet(strSqlSaleUSD)
            ' lay com,remain ra

            For i = 0 To tblsaleUSD.Tables(0).Rows.Count - 1
                If tblsaleUSD.Tables(0).Rows(i).Item("commisionCus").ToString.Trim <> "" Then
                    comUSD += CDbl(tblsaleUSD.Tables(0).Rows(i).Item("commisionCus").ToString)
                End If

                Next


            For i = 0 To tblsaleUSD.Tables(0).Rows.Count - 1
                If tblsaleUSD.Tables(0).Rows(i).Item("tax").ToString.Trim <> "" Then
                    TaxUsd += CDbl(tblsaleUSD.Tables(0).Rows(i).Item("tax").ToString)
                End If

            Next


            'Dim strSqlSaleVND As String = "Select * from FreightSale where ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1 and unit='VND'"
            'tblsaleVND = ReadDataSet(strSqlSaleVND)
            ' cong USD
            For i = 0 To tblsaleUSD.Tables(0).Rows.Count - 1
                If tblsaleUSD.Tables(0).Rows(i).Item("freightsale").ToString.Trim <> "" Then
                    sumsaleUSD += CDbl(tblsaleUSD.Tables(0).Rows(i).Item("freightsale").ToString)
                End If

            Next
            For i = 0 To tblsaleUSD.Tables(0).Rows.Count - 1
                If tblsaleUSD.Tables(0).Rows(i).Item("freight").ToString.Trim <> "" Then
                    sumBuyUSD += CDbl(tblsaleUSD.Tables(0).Rows(i).Item("freight").ToString)
                End If

            Next
            Me.txtRemain.Text = "USD " + FormatString(comUSD - comUSD * TaxUsd / 100)
            Me.txtprofit.Text = "USD " + FormatString(sumsaleUSD - sumBuyUSD - (comUSD - comUSD * TaxUsd / 100))
            ' cong VNDu
            'For i = 0 To tblsaleVND.Tables(0).Rows.Count - 1
            '    sumVND += CDbl(tblsaleVND.Tables(0).Rows(i).Item("freightsale").ToString)
            'Next
            ' lay du lieu ben cong no
            'Dim strSqlCNUSD As String = "Select * from congnokh where ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1 and loaitiente='USD'"
            'tblCongNoUSD = ReadDataSet(strSqlCNUSD)

            'Dim strSqlCNVND As String = "Select * from congnokh where ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1 and loaitiente='VND'"
            'tblCongNoVND = ReadDataSet(strSqlCNVND)
            '' cong USD
            'For i = 0 To tblCongNoUSD.Tables(0).Rows.Count - 1
            '    sumCongNoUSD += CDbl(tblCongNoUSD.Tables(0).Rows(i).Item("sotien").ToString)
            'Next
            '' cong VND
            'For i = 0 To tblCongNoVND.Tables(0).Rows.Count - 1
            '    sumCongNoVND += CDbl(tblCongNoVND.Tables(0).Rows(i).Item("sotien").ToString)
            'Next
            'totalUSD = sumsaleUSD - sumBuyUSD

            'totalVND = sumVND - sumCongNoVND
            'Me.txtsotienKHTra.Text = "VND (" + FormatString(totalVND) + ")"
            'Me.txtsotienKHNo.Text = "USD (" + FormatString(totalUSD) + ")"
            Return ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmdCancelF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelF.Click
        On Error GoTo Err_Renamed
        ' Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatusF = "Normal"
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdContianerOutboundNotify.Enabled = True
        Me.cmdOKF.Enabled = False
        Me.dgdFreight.Enabled = True
        'Me.cmdCancel_Click(sender, e)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCharge.SelectedIndexChanged
        Try
            'If FindValueID(Me.cboCharge, Me.cboCharge.Text.Trim) = "" Then
            '    Return
            'End If
            'Dim tbl As New DataSet
            'tbl = ReadDataSet("Select * From Charge where continued=1 and Charge_ID='" & FindValueID(Me.cboCharge, Me.cboCharge.Text.Trim) & "'")
            'If tbl.Tables(0).Rows.Count > 0 Then
            '    Me.txtCharge.Text = tbl.Tables(0).Rows(0)("Charge")
            'End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboKind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKind.SelectedIndexChanged
        Try
            If Me.cboKind.SelectedIndex = -1 Then
                Return
            End If
            ' goi ham hien thi so luong cont tuonh ung tung loai cont cua tung bokking
            getSoluong()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub getSoluong()
        Try
            Dim tbl As New DataSet
            tbl = ReadDataSet("Select * From ContainerOutBoundNotify where continued=1 and ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "'")
            If tbl.Tables(0).Rows.Count > 0 Then
                If Me.cboKind.Text = "20GP" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong20gp").ToString + " Cont"
                End If
                If Me.cboKind.Text = "40GP" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong40gp").ToString + " Cont"
                End If
                If Me.cboKind.Text = "40HC" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong40HC").ToString + " Cont"
                End If

                If Me.cboKind.Text = "45HC" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong45HC").ToString + " Cont"
                End If
                If Me.cboKind.Text = "20RF" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong20RF").ToString + " Cont"
                End If
                If Me.cboKind.Text = "40RF" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong40RF").ToString + " Cont"
                End If
                If Me.cboKind.Text = "40RH" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong40RH").ToString + " Cont"


                End If

                If Me.cboKind.Text = "20OT" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong20OT").ToString + " Cont"
                End If
                If Me.cboKind.Text = "40OT" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong40OT").ToString + " Cont"
                End If


                If Me.cboKind.Text = "20FR" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong20FR").ToString + " Cont"
                End If
                If Me.cboKind.Text = "40FR" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("Soluong40FR").ToString + " Cont"
                End If
                If Me.cboKind.Text = "CBM" Then
                    Me.lblSoluong.Text = tbl.Tables(0).Rows(0).Item("SoluongCBM").ToString + " CBM"
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub QueryGrid()
        Try
            Dim tbl As New DataSet
            tbl = ReadDataSet("Select * From FreightSale where continued=1 and ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "'")
            Me.dgdFreight.DataSource = tbl.Tables(0)
            InsertAutoNumberToGrid(Me.dgdFreight)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) = True Then
                Return
            End If
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Dim tbl As DataSet
            Dim strSql As String = ""

            tbl = New DataSet
            strSql = "Select BookingNo,POL, por1.Port as POD,por2.Port as OPL,por3.Port as FDEST,commondity,canvasCode,SaleCode,CusName,ServiceContract  " & _
                    "From (((Surcharge LEFT JOIN Port por1 ON por1.Port_ID=Surcharge.POD_ID) " & _
                    "LEFT JOIN Port por2 ON por2.Port_ID=Surcharge.OPL_ID) " & _
                    "LEFT JOIN Port por3 ON por3.Port_ID=Surcharge.FDEST_ID) " & _
                    "Left JOIN Commondity ON Commondity.Commondity_ID=Surcharge.Commondity_ID " & _
                    "Where ContainerOutBoundNotifyID='" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyID", index).Value.ToString & "' and Surcharge.continued=1 "
            tbl = ReadDataSet(strSql)
            If tbl.Tables(0).Rows.Count = 0 Then
                Return
            End If

            Dim app As Application
            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Dim path As String = CurDir() & "\FREIGHT INPUT FORM.xls"

            workbook = workbooks.Open(path)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If

            Dim i, j As Integer
            Dim nRow As Integer = 3

            Dim cell As String = "F"
            Dim arrCol As String()
            Dim nCol As Integer = 0

            ws.Range("D1").Value = tbl.Tables(0).Rows(0)("BookingNo")
            ws.Range("D2").Value = tbl.Tables(0).Rows(0)("CusName")
            ws.Range("D3").Value = tbl.Tables(0).Rows(0)("POL")
            ws.Range("D4").Value = tbl.Tables(0).Rows(0)("OPL")
            ws.Range("D5").Value = tbl.Tables(0).Rows(0)("POD")
            ws.Range("D6").Value = tbl.Tables(0).Rows(0)("FDEST")

            ws.Range("D8").Value = tbl.Tables(0).Rows(0)("Commondity")
            ws.Range("D9").Value = tbl.Tables(0).Rows(0)("ServiceContract")
            ws.Range("D10").Value = tbl.Tables(0).Rows(0)("CanvasCode")
            ws.Range("D11").Value = tbl.Tables(0).Rows(0)("SaleCode")

            Dim tmp As Integer = 13
            ReDim arrCol(Me.dgdContianerOutboundNotify.RowCount - 1)

            For i = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                Dim st As String = Me.dgdContianerOutboundNotify.Columns(i).DataPropertyName
                Dim st1 As String = dgdContianerOutboundNotify.Columns(i).Name

                If UCase(st) Like "*SOLUONG*" Then
                    Dim s As String = Me.dgdContianerOutboundNotify.Item(st1, index).Value.ToString
                    If s <> "0" Then
                        Dim strF As String = Me.dgdContianerOutboundNotify.Columns(i).HeaderText
                        cell = SetCell(cell)
                        ws.Range(cell & tmp).Insert(4)
                        ws.Range(cell & tmp).Value2 = strF
                        arrCol(nCol) = cell
                        nCol += 1
                    End If
                End If
            Next
            If i > 0 Then
                cell = SetCell(cell)
                ws.Range(cell & tmp).Delete(4)
            End If

            '================= Complete ====================
            Dim d As Date = CDate(Getdate())
            path = "c:\" & "FREIGHT INPUT FORM" & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
            path = ProccessString(path)
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            Me.Cursor = Cursors.Default

            MsgBox("Complete")
            app.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuPrint.Click

    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = "frmContainerOutBoundNotify" 'Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerOutboundNotify("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub txtContainerOutboundNotify_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContainerOutboundNotify.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdFind.PerformClick()
        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Try
            If FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" And Me.txtContainerOutboundNotify.Text.Trim <> "" Then
                FindCombo(Me.txtContainerOutboundNotify.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdContianerOutboundNotify)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ApproveContainerOutboundNotify()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If Me.dgdContianerOutboundNotify.RowCount > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        End If
        Dim rs As New ADODB.Recordset
        Dim strQueryContainerOutboundNotifyList As String
        If Not Me.dgdContianerOutboundNotify.Item("Editable", index).Value Or Not UserRight("frmSaleSerCharge", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryContainerOutboundNotify(mFilter, , index)
        Else
            strQueryContainerOutboundNotifyList = "Select * from ContainerOutboundNotify where" + " ContainerOutBoundNotifyId= '" & dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "'"
            rs.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryContainerOutboundNotify(mFilter, , index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdContianerOutboundNotify_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContianerOutboundNotify.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Exit Sub
        End If
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdContianerOutboundNotify.CurrentCellAddress.X = 58 And Me.dgdContianerOutboundNotify.CurrentCellAddress().Y = index Then
            Call ApproveContainerOutboundNotify()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub ApproveFreight()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If Me.dgdFreight.RowCount > 0 Then
            index = Me.dgdFreight.CurrentRow.Index
        End If
        Dim rs As New ADODB.Recordset
        Dim strQueryContainerOutboundNotifyList As String
        If Not Me.dgdFreight.Item("EditableF", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryContainerOutboundNotifyList = "Select * from FreightSale where" + " FreightSale_ID= '" & dgdFreight.Item("FreightSale_ID", index).Value.ToString & "'"
            rs.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryGrid()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub dgdFreight_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdFreight.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        If Me.dgdFreight.RowCount = 0 Then
            Exit Sub
        End If
        Dim index As Integer = Me.dgdFreight.CurrentRow.Index
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If

        If Me.dgdFreight.Columns(ColIndex).Name = "ApproveF" And Me.dgdFreight.CurrentCellAddress().Y = index Then
            Call ApproveFreight()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PrintOneOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintOneOnlyToolStripMenuItem.Click
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        frmReportSaleSurcharge.ALL = False
        frmReportSaleSurcharge.SailingID = Me.dgdContianerOutboundNotify.Item("SailingScheduleID", index).Value.ToString()
        frmReportSaleSurcharge.BookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString()
        frmReportSaleSurcharge.ShowDialog()
    End Sub

    Private Sub PrintVesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVesselToolStripMenuItem.Click
        Try
            If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) = True Then
                Return
            End If
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyID", index).Value.ToString
            'If CheckExist() = False Then
            '    Return
            'End If
            Dim frm As New FrmPrintALLSaleSurcharge
            'frm = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyID", index).Value.ToString
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtServiceTermPOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceTermPOL.TextChanged

    End Sub

    Private Sub txtFreight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreight.KeyPress
        If e.KeyChar.ToString = "." Or e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtFreight_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreight.Leave
        If Me.txtFreight.Text.Trim <> tarrif Then
            userupdateTarrif = strUserName
            dateUpdateTarrif = Getdate()
            userupdateSale = ""
            dateUpdateSale = ""
            userupdatespecial = ""
            dateupdatespecial = ""

        End If
    End Sub

    Private Sub txtFreightSale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreightSale.KeyPress
        If e.KeyChar.ToString = "." Or e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtFreightSale_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreightSale.Leave
        If Me.txtFreightSale.Text.Trim <> sale Then
            userupdateSale = strUserName
            dateUpdateSale = Getdate()
            userupdateTarrif = ""
            dateUpdateTarrif = ""
            userupdatespecial = ""
            dateupdatespecial = ""

        End If
    End Sub

#Region "Thêm 04-10-2007"

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If
        Me.grpCopy.BringToFront()
        Me.grpCopy.Visible = True
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Me.txtFromBookingNo.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value
    End Sub

    Private Sub cmdCancelCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelCopy.Click
        Try
            Me.grpCopy.Visible = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContianerOutboundNotify_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgdContianerOutboundNotify.MouseClick
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
            For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
                    Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub dgdContianerOutboundNotify_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdContianerOutboundNotify.RowStateChanged
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return
            End If
            Dim Count As Integer = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If Count = 1 Then 'nếu chọn đúng 1 dòng thì hiện menu copy lên ngựơc lại thì tắt
                Me.CopyToolStripMenuItem.Enabled = True
            Else
                Me.CopyToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Function CheckFreight(ByVal BookingID As String) As Boolean ' kiểm tra booking đã có freight chưa nếu có trả về False chưa có trả về true
        Try
            Dim SQL As String
            SQL = "select count(*) from FreightSale Where ContainerOutboundNotifyID='" & BookingID & "' And Continued=1"
            Dim Tempds As New DataSet
            Tempds = ReadDataSet(SQL)
            If Tempds.Tables(0).Rows.Count > 0 Then
                If Tempds.Tables(0).Rows(0).Item(0) > 0 Then ' nếu đã có freight
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Function

    Function CopyFreight(ByVal FromBookingID As String, ByVal ToBookingID As String) As Boolean
        Try
            Dim SQL As String
            SQL = "Select * from FreightSale Where ContainerOutboundNotifyID='" & FromBookingID & "' And Continued=1 "
            Dim rsFromBooking As New ADODB.Recordset
            rsFromBooking.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rsFromBooking.EOF Then
                MsgBox("Chưa có Phí")
                Return False
            End If
            rsFromBooking.MoveFirst()
            Dim rsToBooking As New ADODB.Recordset
            SQL = "Select Top 1 * From FreightSale"
            rsToBooking.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            While Not rsFromBooking.EOF
                With rsToBooking
                    .AddNew()
                    .Fields("FreightSale_ID").Value = NewId()
                    .Fields("ContainerOutboundNotifyID").Value = "{" & ToBookingID & "}"
                    For i As Integer = 0 To rsFromBooking.Fields.Count - 1
                        If UCase(.Fields(i).Name) = "FREIGHTSALE_ID" Or UCase(.Fields(i).Name) = "CONTAINEROUTBOUNDNOTIFYID" Then
                            Continue For
                        End If
                        .Fields(i).Value = rsFromBooking.Fields(i).Value
                    Next
                    .Update()
                End With
                rsFromBooking.MoveNext()
            End While
            rsToBooking.Close()
            rsFromBooking.Close()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Return True
    End Function

    Private Sub cmdOkCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkCopy.Click
        Try
            Dim SQL As String
            SQL = "select ContainerOutboundNotifyID from Containeroutboundnotify Where Continued=1 and Editable=1 And BookingNo='" & Me.txtTpBookingNo.Text & "'"
            Dim ds As New DataSet
            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("the To Booking No is Invalid, Or Not In data base , check Again Please")
                Return
            End If
            Dim FromBookingID, ToBookingID As String
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            FromBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutboundNotifyID", index).Value.ToString

            ToBookingID = ds.Tables(0).Rows(0).Item(0).ToString
            CopyFreight(FromBookingID, ToBookingID)
            QueryContainerOutboundNotify("  " & mFilter)
            mStatus = "Edit"
            cmdOk_Click(sender, e)
            mStatus = "Normal"
            Me.grpCopy.Visible = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

#End Region


    Private Sub cmdExitTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitTag.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdContianerOutboundNotify.Enabled = True
        QueryContainerOutboundNotify(" " & mFilter)
        'Me.cmdCancelF_Click(sender, e)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txtFreightSale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightSale.TextChanged

    End Sub

    Private Sub TXTSpecialFreight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSpecialFreight.KeyPress
        If e.KeyChar.ToString = "." Or e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TXTSpecialFreight_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSpecialFreight.Leave
        If Me.TXTSpecialFreight.Text.Trim <> Special Then
            userupdatespecial = strUserName
            dateupdatespecial = Getdate()
            userupdateTarrif = ""
            dateUpdateTarrif = ""
            userupdateSale = ""
            dateUpdateSale = ""

        End If
    End Sub

    Private Sub TXTSpecialFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSpecialFreight.TextChanged

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        QueryContainerOutboundNotify(mFilter)
        Me.QueryCombo()
        Me.QueryCustomer()
        Me.QueryGrid()

    End Sub

    Private Sub dgdFreight_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdFreight.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdFreight)
    End Sub

    Private Sub CreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem.Click
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If

        frmRPTDebitCreditAgent.ShowDialog()
    End Sub

    Private Sub DebitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitToolStripMenuItem.Click
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If

        frmRPTDebitCreditcus.ShowDialog()
    End Sub

    Private Sub CreditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem1.Click
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If

        frmRPTDebitCreditAgent.ShowDialog()
    End Sub

    Private Sub txtFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreight.TextChanged

    End Sub

    Private Sub txtcom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcom.KeyPress
        If e.KeyChar.ToString = "." Or e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = ""
        End If

    End Sub

    Private Sub txtcom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcom.TextChanged
        'If Me.txtcom.Text <> "" And Me.txttax.Text <> "" Then
        '    Me.txtRemain.Text = FormatString(CDbl(Me.txtcom.Text) - CDbl(Me.txtcom.Text) * CDbl(Me.txttax.Text) / 100)
        'Else
        '    Me.txtRemain.Text = "0"
        'End If
    End Sub

    Private Sub txttax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttax.KeyPress
        If e.KeyChar.ToString = "1" Or e.KeyChar.ToString = "2" Or e.KeyChar.ToString = "3" Or e.KeyChar.ToString = "4" Or e.KeyChar.ToString = "5" Or e.KeyChar.ToString = "6" Or e.KeyChar.ToString = "7" Or e.KeyChar.ToString = "8" Or e.KeyChar.ToString = "9" Or e.KeyChar.ToString = "0" Or e.KeyChar.ToString = "" Then
            'Me.txtsotien.Text += e.KeyChar.ToString
        Else
            e.KeyChar = "0"
        End If

    End Sub

    Private Sub txttax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.TextChanged
        'If Me.txtcom.Text <> "" And Me.txttax.Text <> "" Then
        '    Me.txtRemain.Text = FormatString(CDbl(Me.txtcom.Text) - CDbl(Me.txtcom.Text) * CDbl(Me.txttax.Text) / 100)
        'Else
        '    Me.txttax.Text = "0"
        'End If
    End Sub

    Private Sub txtRemain_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemain.TextChanged
        'If Me.txtcom.Text <> "" And Me.txttax.Text <> "" And Me.txtRemain.Text <> "" Then
        '    Me.txtprofit.Text = FormatString(CDbl(Me.txtcom.Text) - CDbl(Me.txtcom.Text) * CDbl(Me.txttax.Text) / 100)
        'Else
        '    Me.txtRemain.Text = "0"
        'End If
    End Sub

    Private Sub ExportAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAllToolStripMenuItem.Click
        Try
            If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                'SetMenu(False)
                ExportExecel(Me.dgdContianerOutboundNotify, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub DebitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitToolStripMenuItem1.Click

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub txtFreightBuyTruocthue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightBuyTruocthue.TextChanged
        Try
            Me.txtFreight.Text = CStr(CDbl(Me.txtFreightBuyTruocthue.Text) + CDbl(Me.txtTaxFreightbuy.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTaxFreightbuy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxFreightbuy.TextChanged
        Try
            Me.txtFreight.Text = CStr(CDbl(Me.txtFreightBuyTruocthue.Text) + CDbl(Me.txtTaxFreightbuy.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFreightSaleTruocthue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightSaleTruocthue.TextChanged
        Try
            Me.txtFreightSale.Text = CStr(CDbl(Me.txtFreightSaleTruocthue.Text) + CDbl(Me.txtTaxFreightSale.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTaxFreightSale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxFreightSale.TextChanged
        Try
            Me.txtFreightSale.Text = CStr(CDbl(Me.txtFreightSaleTruocthue.Text) + CDbl(Me.txtTaxFreightSale.Text))
        Catch ex As Exception

        End Try
    End Sub
End Class