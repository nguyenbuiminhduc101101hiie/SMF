Imports Excel
Public Class frmActualFreight




    Dim mStatus, mFilter, tarrif, sale, Special, tarrif1, sale1, Special1 As String
    Dim mStatusF As String
    Dim mFreightSaleID As String
    Dim oTableF As New DataSet
    Dim userupdateTarrif, userupdateSale, userupdatespecial, dateUpdateTarrif, dateUpdateSale, dateupdatespecial As String
    Public ActualFreightBookingNo As String
    Public oTable As DataSet

    Public Sub QueryContainerOutboundNotify(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        'If IsNothing(argCriteria) Then
        '    strQuery = MakeQueryContainerOutboundNotify()
        'Else
        '    strQuery = MakeQueryContainerOutboundNotify(argCriteria, index)
        'End If
        strQuery = "SELECT distinct ContainerOutBoundNotify.ContainerOutBoundNotifyID,ContainerOutBoundNotify.BookingNo,ActualFreightID,ActualFreight.Freight,Com ,ActualFreight.Tax,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,Commondity as Commondity, "
        strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, "
        strQuery = strQuery + " Sell_Way,Sale.Sale_ID,Sale.SaleName,  ServiceContract,mak.Market_ID,mak.Market,  Representative ,  SoLuong20GP,    SoLuong40GP,     SoLuong40HC, "
        strQuery = strQuery + " SoLuong45HC,   SoLuong20RF,SoLuong40RF,  SoLuong40RH, Sale.SaleCode,ServiceFeeder,LocalCargo,EmptyMoving,TransiteCargo,SOC,PayMentTerm,SlotExchange,FOBCargo,FirstSendDate,SecondSendDate,ThirdSendDate,SupplyDate,  SpencialEquipment, Cold ,Ventilation, EmptyContainerPlace,  PackingWay, CustomsLiquiDate, ClosingTime, Tranship, LeavingDate, "
        strQuery = strQuery + " PortOfLoading,PortOfUnLoading, Destination,  ContainerOutBoundNotify.Remarks as Remarks,MaxWMainPort,MaxWLocal,ContactUs,BookingPerson,BookingDate,CloseTime,  CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,"
        strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime ,FreightSale.Note "

        strQuery = strQuery + " From (((((((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
        strQuery = strQuery + " left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        strQuery = strQuery + "left JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) " & _
                              " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                              " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID) "
        strQuery = strQuery + " Left Join ActualFreight On ActualFreight.BookingNo=ContainerOutboundNotify.BookingNO) "
        strQuery = strQuery + " Left Join FreightSale On FreightSale.ContainerOutBoundNotifyID=ContainerOutBoundNotify.ContainerOutBoundNotifyID)"
        strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 and CONTAINEROUTBOUNDNOTIFY.Editable=1 "
        If argCriteria <> "" Then
            strQuery = strQuery + argCriteria
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
                If Not IsNothing(Me.dgdContianerOutboundNotify.Item(s, t).Value) Then
                    If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
                        Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                End If

            Next
        Next
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmActualFreight_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Sub CheckLockBooking()
    '    Dim Conn As New SqlClient.SqlConnection()
    '    Try
    '        Dim strConn As String
    '        strConn = "Data Source='" & strServer & "'; User ID='lock'; password='lock'; Initial Catalog='" & strDatabase & "'"
    '        Conn = New SqlClient.SqlConnection(strConn)
    '        Conn.Open()
    '        Dim SQL As String
    '        SQL = " Update FreightSale Set Approve=1"
    '        SQL &= " Where ActualFreightID "
    '        SQL &= " In (Select ActualFreightID "
    '        SQL &= " from ContainerOutboundNotify Inner Join SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
    '        SQL &= " where ETD-'" & GetServerDate().Date & "'<=1)"
    '        Dim cmd As New SqlClient.SqlCommand("", Conn)
    '        cmd.CommandType = CommandType.Text
    '        cmd.CommandText = SQL
    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    Finally
    '        Conn.Close()
    '    End Try
    'End Sub

    Private Sub frmActualFreight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        'Me.txtServiceTermPOL.Enabled = True
        'Me.txtServiceTermPOD.Enabled = True
        mStatus = "Normal"
        'mStatusF = "Normal"
        userupdateTarrif = ""
        userupdateSale = ""
        dateUpdateTarrif = ""
        dateUpdateSale = ""
        ActualFreightBookingNo = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'CheckLockBooking()
        'Me.tab.Visible = False
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

        'Me.smnuDisplayRepresentative.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayRepresentative")
        'Me.smnuDisplayBookingPerson.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayBookingPerson")
        'Me.smnuDisplayBookingDate.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayBookingPerson")
        'Me.smnuDisplayDestination.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayDestination")
        'Me.smnuDisplayLeavingDate.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayLeavingDate")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayAPPROVE")
        'Me.smnuDisplayRemarks.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayREMARKS")
        'Me.smnuDisplayPortOfUnLoading.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayPortOfUnLoading")
        'Me.smnuDisplayClosingTime.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayClosingTime")
        'Me.smnuDisplayEmptyConatinerPlace.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayEmptyContainerPlace")
        'Me.smnuDisplayPackingWay.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayPackingWay")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmContainerOutBoundNotify.smnuDisplayUpdateTime")

        'UpdateFrame()
        'QueryCombo()
        'QueryCustomer()
        SetDefaultGrid(Me.dgdContianerOutboundNotify, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdFreight, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        'Me.cmdOKF.Enabled = False
        ReFormat()

        Exit Sub
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Sub QueryCustomer()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Customer_ID"
    '        value = "Company"
    '        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
    '        strSQL = "Select Customer_ID,Company From Customer where Continued=1 Order By Company asc"
    '        'If Me.cboCompany.Items.Count = 0 Then
    '        loadDataToObject(Me.cboNote, strSQL, id, value)
    '        'End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Private Sub UpdateFrame()
    '        On Error GoTo Err_Renamed

    '        Me.dgdContianerOutboundNotify.Columns.Item("ActualFreightID").Visible = False
    '        Me.dgdContianerOutboundNotify.Columns.Item("Representative").Visible = Me.smnuDisplayRepresentative.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("BookingPerson").Visible = Me.smnuDisplayBookingPerson.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("BookingDate").Visible = Me.smnuDisplayBookingDate.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Destination").Visible = Me.smnuDisplayDestination.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("LeavingDate").Visible = Me.smnuDisplayLeavingDate.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("PackingWay").Visible = Me.smnuDisplayPackingWay.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("EmptyContainerPlace").Visible = Me.smnuDisplayEmptyConatinerPlace.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("PortOfUnLoading").Visible = Me.smnuDisplayPortOfUnLoading.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("ClosingTime").Visible = Me.smnuDisplayClosingTime.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Editable").Visible = False
    '        Me.dgdContianerOutboundNotify.Columns.Item("Continued").Visible = False
    '        Me.dgdContianerOutboundNotify.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Remarks").Visible = Me.smnuDisplayRemarks.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

    '        Me.dgdContianerOutboundNotify.Columns.Item("BookingNo").Visible = Me.smnuDisplayBookingNo.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Company").Visible = Me.smnuDisplayCompany.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Address").Visible = Me.smnuDisplayAddres.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Telephone").Visible = Me.smnuDisplayTelephone.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("RF20").Visible = True 'Me.smnuDisplayContainer.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("RF40").Visible = True  'Me.smnuDisplayContainer.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("GP20").Visible = True 'Me.smnuDisplayContainer.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("GP40").Visible = True 'Me.smnuDisplayContainer.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("HC40").Visible = True 'Me.smnuDisplayContainer.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("HC45").Visible = True 'Me.smnuDisplayContainer.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("RH40").Visible = True 'Me.smnuDisplayContainer.Checked

    '        Me.dgdContianerOutboundNotify.Columns.Item("Cold").Visible = Me.smnuDisplayCold.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("CustomsLiquiDate").Visible = Me.smnuDisplayCustomsLiquiDate.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Ventilation").Visible = Me.smnuDisplayVentilation.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("SpecialEquipment").Visible = Me.smnuDisplaySpencialEquipment.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Tranship").Visible = Me.smnuDisplayTranship.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Pre_Vessel").Visible = Me.smnuDisplayVessel.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Market").Visible = Me.smnuDisplayMarket.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("ServiceContract").Visible = Me.smnuDisplayServiceContract.Checked
    '        Me.dgdContianerOutboundNotify.Columns.Item("Sell_Way").Visible = Me.smnuDisplaySellWay.Checked

    '        Me.dgdContianerOutboundNotify.Refresh()
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '#Region "ViewMenuStrip"
    '    Private Sub smnuDisplayNguoiDaiDien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayRepresentative.Checked = Not Me.smnuDisplayRepresentative.Checked
    '        UpdateFrame()

    '    End Sub

    '    Private Sub smnuDisplayNgayGuiBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayBookingDate.Checked = Not Me.smnuDisplayBookingDate.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNguoiGuiBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayBookingPerson.Checked = Not Me.smnuDisplayBookingPerson.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayDichCuoiCung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayDestination.Checked = Not Me.smnuDisplayDestination.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNgayDi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayLeavingDate.Checked = Not Me.smnuDisplayLeavingDate.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCangDoHang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPortOfUnLoading.Checked = Not Me.smnuDisplayPortOfUnLoading.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayThoiHanChotHaBai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayClosingTime.Checked = Not Me.smnuDisplayClosingTime.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNoilayContainerRong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayEmptyConatinerPlace.Checked = Not Me.smnuDisplayEmptyConatinerPlace.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPhuongAnLamHang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPackingWay.Checked = Not Me.smnuDisplayPackingWay.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayRemarks.Checked = Not Me.smnuDisplayRemarks.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '        UpdateFrame()
    '    End Sub
    '    Private Sub smnuDisplayBookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayBookingNo.Checked = Not Me.smnuDisplayBookingNo.Checked
    '        UpdateFrame()

    '    End Sub

    '    Private Sub smnuDisplayCongty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCompany.Checked = Not Me.smnuDisplayCompany.Checked()
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayDiaChi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayAddres.Checked = Not Me.smnuDisplayAddres.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayTelephone.Checked = Not Me.smnuDisplayTelephone.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayFax.Checked = Not Me.smnuDisplayFax.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNhietDoLanh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCold.Checked = Not Me.smnuDisplayCold.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayHaCangThanhLyHQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCustomsLiquiDate.Checked = Not Me.smnuDisplayCustomsLiquiDate.Checked
    '        UpdateFrame()

    '    End Sub

    '    Private Sub smnuDisplayThongGio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayVentilation.Checked = Not Me.smnuDisplayVentilation.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplaySpencialEquipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplaySpencialEquipment.Checked = Not Me.smnuDisplaySpencialEquipment.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayChuyenTai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayTranship.Checked = Not Me.smnuDisplayTranship.Checked
    '        UpdateFrame()

    '    End Sub

    '    Private Sub smnuDisplaySellWay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplaySellWay.Checked = Not Me.smnuDisplaySellWay.Checked
    '        UpdateFrame()
    '    End Sub


    '    Private Sub smnuDisplayMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayMarket.Checked = Not Me.smnuDisplayMarket.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayServiceContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayServiceContract.Checked = Not Me.smnuDisplayServiceContract.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayXuatTrenTau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayVessel.Checked = Not Me.smnuDisplayVessel.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayContainer.Checked = Not Me.smnuDisplayContainer.Checked
    '        UpdateFrame()
    '    End Sub
    '#End Region

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
            dgdContianerOutboundNotify.Height = Me.Height - 70 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If

        Me.fraUpdate.Width = (Me.Width - 30)
        Me.fraUpdate.Top = dgdContianerOutboundNotify.Height + dgdContianerOutboundNotify.Top

        Me.txtContainerOutboundNotify.Width = Me.Width - 300

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

    Private Sub frmActualFreight_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ' ReFormat()
    End Sub

    Private Sub frmActualFreight_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
            Me.Text = "Actual Freight "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Actual Freight -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Actual Freight -> Add."
        End If

    End Sub

    Function CheckExist() As Boolean
        Try
            Dim tbl As New DataSet
            Dim strSql As String = "Select * From FreightSale where ActualFreightID='" & ActualFreightBookingNo & "' and continued=1 "
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
            If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Freight", index).Value) Then
                Me.txtFreight.Text = Me.dgdContianerOutboundNotify.Item("Freight", index).Value.ToString
            Else
                Me.txtFreight.Text = "0"
            End If
            If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Com", index).Value) Then
                Me.txtCom.Text = Me.dgdContianerOutboundNotify.Item("Com", index).Value.ToString
            Else
                Me.txtCom.Text = "0"
            End If
            If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Tax", index).Value) Then
                Me.txtTax.Text = Me.dgdContianerOutboundNotify.Item("Tax", index).Value.ToString
            Else
                Me.txtTax.Text = "0"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Sub QueryCombo()
    '    Try
    '        Dim id, value, strSQL As String
    '        'id = "Port_ID"
    '        'value = "Port"
    '        'strSQL = "Select Port_ID,Port From Port where Continued=1 Order By Port desc"
    '        'loadDataToObject(Me.txtFDEST, strSQL, id, value)
    '        'loadDataToObject(Me.txtOPL, strSQL, id, value)
    '        'loadDataToObject(Me.txtPOD, strSQL, id, value)

    '        'id = "Commondity_ID"
    '        'value = "Commondity"
    '        'strSQL = "Select Commondity_ID,Commondity From Commondity where Continued=1 Order By Commondity desc"
    '        'loadDataToObject(Me.txtCommondity, strSQL, id, value)

    '        id = "Charge_ID"
    '        value = "Charge_Code"
    '        strSQL = "Select * From Charge where Continued=1 Order By Charge_Code asc"
    '        loadDataToObject(Me.cboCharge, strSQL, id, value)

    '        strSQL = "Select Currency  from Currency"
    '        Dim tbl As New DataSet
    '        tbl = ReadDataSet(strSQL)
    '        Me.cboUnit.Items.Clear()
    '        For i As Integer = 0 To tbl.Tables(0).Rows.Count - 1
    '            Me.cboUnit.Items.Add(tbl.Tables(0).Rows(i).Item("Currency"))
    '        Next
    '        If Me.cboUnit.Items.Count > 0 Then
    '            Me.cboUnit.SelectedIndex = 0
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Sub QueryKind(ByVal index As Integer)
    '    Try
    '        Dim oItems As PDSAListItemString
    '        Me.cboKind.Items.Clear()
    '        For i As Integer = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
    '            Dim st As String = Me.dgdContianerOutboundNotify.Columns(i).DataPropertyName
    '            Dim st1 As String = dgdContianerOutboundNotify.Columns(i).Name

    '            If UCase(st) Like "*SOLUONG*" Then
    '                Dim s As String = Me.dgdContianerOutboundNotify.Item(st1, index).Value.ToString
    '                If s <> "0" Then
    '                    Dim num As Integer = 0
    '                    Dim strF As String = Me.dgdContianerOutboundNotify.Columns(i).HeaderText
    '                    Dim tbl As New DataSet
    '                    tbl = ReadDataSet("Select count(*) as cnt From FreightSale where Kind='" & strF & "' and ContainerOutBoundNotifyID='" & mContainerOutboundNotifyId & "' and continued=1")
    '                    If tbl.Tables(0).Rows.Count > 0 Then
    '                        num = tbl.Tables(0).Rows(0)("cnt")
    '                    End If
    '                    oItems = New PDSAListItemString
    '                    oItems.ID = (CInt(s) - num).ToString
    '                    oItems.Value = strF
    '                    Me.cboKind.Items.Add(oItems)
    '                End If
    '            End If
    '        Next
    '        oItems = New PDSAListItemString
    '        oItems.ID = "B/L"
    '        oItems.Value = "B/L"
    '        Me.cboKind.Items.Add(oItems)
    '        If Me.cboKind.Items.Count > 0 Then
    '            Me.cboKind.Enabled = True
    '            Me.cboKind.SelectedIndex = 0
    '        Else
    '            Me.cboKind.Enabled = False

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    '    Private Sub smnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim index As Integer
    '        Dim Approve, EditTable, UsrRight As Boolean
    '        If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) = True Or Me.dgdContianerOutboundNotify.RowCount = 0 Then
    '            Return
    '        End If

    '        index = Me.dgdContianerOutboundNotify.CurrentRow.Index
    '        mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
    '        'Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
    '        'EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value

    '        If mStatus = "Normal" And UserRight("frmActualFreight", "Add") Then
    '            If CheckExist() = True Then
    '                MsgBox("This Booking had Freight, Please click Menu Edit! ")
    '                Return
    '            End If
    '            Me.fraUpdate.Visible = True
    '            Me.dgdContianerOutboundNotify.Enabled = False
    '            ReFormat()
    '            SetMenu((False))
    '            mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
    '            mStatus = "Add"
    '            reText(mStatus)
    '            'Me.txtBookingNo.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value
    '            ReFreshData(index)
    '            'Me.txtPOL.Text = "VNSGN"
    '            ReFormat()
    '            QueryKind(index)
    '            QueryGrid()
    '            Me.cmdOKF.Enabled = False
    '            Me.cmdOk_Click(sender, e)
    '            'Me.smnuEdit_Click(sender, e)
    '        Else
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

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
        Dim strQuery, strActualFreightID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = -1

        If Me.dgdContianerOutboundNotify.RowCount > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            CopyValues("ActualFreight", "BookingNo", Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim)
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM ActualFreight "
            strQuery = strQuery & "WHERE BookingNo = '" & Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim & "' AND ActualFreightID <> '" & DefaultValue & "' And Continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("ActualFreightID").Value = NewId()
                End If
                .Fields("BookingNo").Value = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim

                .Fields("Freight").Value = Me.txtFreight.Text.Trim
                .Fields("Com").Value = Me.txtCom.Text.Trim
                .Fields("Tax").Value = Me.txtTax.Text.Trim
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
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            reText(mStatus)
            QueryContainerOutboundNotify(" " & mFilter)
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

        ActualFreightBookingNo = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString
        Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
        EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value
        If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmActualFreight", "Add") Then
            'If Me.dgdContianerOutboundNotify.Item("Quantity", index).Value.ToString = "0" Then
            '    MsgBox("Booking này chưa có Freight. Vui lòng Insert")
            '    Return
            'End If
            Me.fraUpdate.Visible = True
            Me.dgdContianerOutboundNotify.Enabled = False
            ReFormat()
            SetMenu((False))
            ActualFreightBookingNo = Me.dgdContianerOutboundNotify.Item("Bookingno", index).Value.ToString

            Dim tbl As New DataSet
            'Dim strSql As String = "Select BookingNo,POL, por1.Port as POD,por2.Port as OPL,por3.Port as FDEST,commondity,canvasCode,SaleCode,CusName,ServiceContract  " & _
            '                       "From (((Surcharge LEFT JOIN Port por1 ON por1.Port_ID=Surcharge.POD_ID) " & _
            '                       "LEFT JOIN Port por2 ON por2.Port_ID=Surcharge.OPL_ID) " & _
            '                       "LEFT JOIN Port por3 ON por3.Port_ID=Surcharge.FDEST_ID) " & _
            '                       "Left JOIN Commondity ON Commondity.Commondity_ID=Surcharge.Commondity_ID " & _
            '                       "Where ActualFreightID='" & ActualFreightBookingNo & "' and Surcharge.continued=1 "
            'Dim strSql As String = "Select * from Surcharge Where ActualFreightID='" & ActualFreightBookingNo & "' and Surcharge.continued=1 "
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
            mStatus = "Edit"
            reText(mStatus)
            ReFormat()
            'QueryKind(index)
            'QueryGrid()
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

    'Sub ReFreshFreight(ByVal index As Integer)
    '    Try
    '        Me.cboCharge.Text = Me.dgdFreight.Item("ChargeCode", index).Value
    '        'Me.txtCharge.Text = Me.dgdFreight.Item("Charge", index).Value.ToString

    '        Me.cboUnit.Text = Me.dgdFreight.Item("Unit", index).Value.ToString
    '        Me.cboKind.Text = Me.dgdFreight.Item("Kind", index).Value.ToString
    '        Me.TXTSpecialFreight.Text = Me.dgdFreight.Item("FreightSpecial", index).Value
    '        Me.txtFreight.Text = Me.dgdFreight.Item("Freight", index).Value
    '        Me.txtFreightSale.Text = Me.dgdFreight.Item("FreightSale", index).Value
    '        Me.txtRemarks.Text = Me.dgdFreight.Item("RemarksSurcharge", index).Value.ToString
    '        Me.cboNote.Text = Me.dgdFreight.Item("Note", index).Value.ToString
    '        Me.txtServiceTermPOL.Text = Me.dgdFreight.Item("ServiceTermPOL", index).Value.ToString
    '        Me.txtServiceTermPOD.Text = Me.dgdFreight.Item("ServiceTermPOD", index).Value.ToString
    '        Me.txtpayterm.Text = Me.dgdFreight.Item("PayTerm", index).Value.ToString
    '        tarrif = Me.txtFreight.Text
    '        sale = Me.txtFreightSale.Text
    '        Special = Me.TXTSpecialFreight.Text
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cxtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtAdd.Click
    '    Try
    '        mFreightSaleID = DefaultValue
    '        Me.txtFreightSale.Text = "0"
    '        Me.txtFreight.Text = "0"
    '        Me.TXTSpecialFreight.Text = "0"

    '        tarrif = Me.txtFreight.Text
    '        sale = Me.txtFreightSale.Text
    '        Special = Me.TXTSpecialFreight.Text

    '        mStatusF = "Add"
    '        cmdOKF.Enabled = True
    '        reText(mStatusF)
    '        Me.dgdFreight.Enabled = False
    '        Me.cboKind.Enabled = True
    '    Catch ex As Exception
    '        MsgBox(msgErr(Me, ex.Message))
    '    End Try
    'End Sub

    'Private Sub cxtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtEdit.Click
    '    Try
    '        Dim Approve, EditTable, UsrRight As Boolean
    '        Dim index As Integer
    '        If Me.dgdFreight.RowCount > 0 Then
    '            index = Me.dgdFreight.CurrentRow.Index
    '        Else
    '            Exit Sub
    '        End If
    '        Approve = Me.dgdFreight.Item("ApproveF", index).Value
    '        EditTable = Me.dgdFreight.Item("EditableF", index).Value
    '        If mStatusF = "Normal" And Not Approve And EditTable And UserRight("frmActualFreight", "Edit") And Not Me.dgdFreight.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
    '            Me.cmdOKF.Enabled = True
    '            mStatusF = "Edit"
    '            mFreightSaleID = Me.dgdFreight.Item("FreightSale_ID", index).Value.ToString
    '            ReFreshFreight(index)
    '            Me.dgdFreight.Enabled = False
    '            reText(mStatusF)
    '            Me.cboKind.Enabled = True
    '        Else
    '            DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
    '        End If


    '    Catch ex As Exception
    '        MsgBox(msgErr(Me, ex.Message))
    '    End Try
    'End Sub

    'Private Sub cxtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtDelete.Click
    '    Try
    '        Dim index As Integer
    '        If IsNothing(Me.dgdFreight.CurrentRow) = True Then
    '            Return
    '        End If
    '        index = Me.dgdFreight.CurrentRow.Index
    '        Dim strQuery As String
    '        strQuery = "select * from FreightSale where FreightSale_ID='" & Me.dgdFreight.Item("FreightSale_ID", index).Value.ToString & "' And Continued=1"
    '        Dim rs As New ADODB.Recordset
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        rs.Fields("Continued").Value = 0
    '        rs.Update()
    '        rs.Close()
    '        'QueryGrid()
    '        'QueryKind(index)
    '        QueryContainerOutboundNotify(" " & mFilter)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Function CheckDataFreight() As Boolean
    '    Try
    '        Dim msg As String = ""
    '        Dim tbl As New DataSet

    '        'If Me.lblCount.Text = "-1" Then
    '        '    MsgBox("Booking không có Container")
    '        '    Return False
    '        'End If

    '        Dim strSql As String = "Select count(*) cnt from FreightSale where Kind='" & Me.cboKind.Text & "' and Charge='" & Me.cboCharge.Text & "' and ActualFreightID='" & ActualFreightBookingNo & "' and continued=1"
    '        tbl = ReadDataSet("Select count(*) cnt from FreightSale where Kind='" & Me.cboKind.Text & "' and ChargeCode='" & Me.cboCharge.Text & "' and ActualFreightID='" & ActualFreightBookingNo & "' and continued=1")
    '        If tbl.Tables(0).Rows(0).Item("cnt") > 0 And mStatusF = "Add" Then
    '            msg &= "Phí của loại Container này đã tồn tại"
    '        End If

    '        'If Me.lblCount.Text = "0" And msg = "" Then
    '        '    msg &= "Hết Container cho loại này"
    '        'End If


    '        If msg = "" And IsNumeric(Me.txtFreightSale.Text.Trim) = False Then
    '            msg &= "The Freight (Sale) is invalid"
    '        End If

    '        If msg = "" And IsNumeric(Me.TXTSpecialFreight.Text.Trim) = False Then
    '            msg &= "The Freight (Special) is invalid"
    '        End If

    '        If msg = "" And IsNumeric(Me.txtFreight.Text.Trim) = False Then
    '            msg &= "The Freight (S/C) is invalid"
    '        End If
    '        If Me.txtServiceContract.Text = "" Then
    '            If Me.txtpayterm.Text = "" Then
    '                msg &= "The Payterm is invalid !"
    '            End If

    '        End If
    '        If msg <> "" Then
    '            MsgBox(msg)
    '            Return False
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Function

    'Private Sub cmdOKF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim strQuery As String
    '        Dim rs As New ADODB.Recordset
    '        Dim index As Integer = -1

    '        If Me.dgdContianerOutboundNotify.RowCount > 0 Then
    '            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
    '        End If

    '        If CheckDataFreight() And (mStatusF = "Add" Or mStatusF = "Edit") Then
    '            If mStatus = "Edit" Then
    '                CopyValues("FreightSale", "FreightSale_Id", mFreightSaleID)

    '            End If
    '            strQuery = "SELECT * "
    '            strQuery = strQuery & "FROM FreightSale "
    '            strQuery = strQuery & "WHERE FreightSale_Id = '" & mFreightSaleID & "'"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            With rs
    '                If rs.EOF Then
    '                    .AddNew()
    '                    .Fields("FreightSale_ID").Value = NewId()
    '                End If
    '                .Fields("ActualFreightID").Value = "{" & ActualFreightBookingNo & "}"
    '                .Fields("ChargeCode").Value = Me.cboCharge.Text.Trim
    '                '.Fields("Charge").Value = Me.txtCharge.Text.Trim
    '                .Fields("Unit").Value = Me.cboUnit.Text.Trim
    '                .Fields("Kind").Value = Me.cboKind.Text.Trim
    '                .Fields("Freight").Value = CDbl(Me.txtFreight.Text.Trim)
    '                .Fields("FreightSale").Value = CDbl(Me.txtFreightSale.Text.Trim)
    '                .Fields("FreightSpecial").Value = CDbl(Me.TXTSpecialFreight.Text.Trim)
    '                .Fields("ServiceTermPOL").Value = Me.txtServiceTermPOL.Text
    '                .Fields("ServiceTermPOD").Value = Me.txtServiceTermPOD.Text
    '                .Fields("PayTerm").Value = Me.txtpayterm.Text
    '                If userupdateTarrif <> "" Then
    '                    .Fields("UserUpdateTarrif").Value = userupdateTarrif
    '                    .Fields("DateUpdateTarrif").Value = dateUpdateTarrif
    '                ElseIf userupdateSale <> "" Then
    '                    .Fields("UserUpdatesale").Value = userupdateSale
    '                    .Fields("DateUpdatesale").Value = dateUpdateSale
    '                ElseIf userupdatespecial <> "" Then
    '                    .Fields("UserUpdatespecial").Value = userupdatespecial
    '                    .Fields("DateUpdatespecial").Value = dateupdatespecial
    '                End If
    '                .Fields("Note").Value = Me.cboNote.Text.Trim
    '                .Fields("Remarks").Value = Me.txtRemarks.Text.Trim
    '                .Update()
    '            End With
    '            rs.Close()
    '            Me.cmdOKF.Enabled = False
    '            Me.dgdFreight.Enabled = True
    '            QueryContainerOutboundNotify(" " & mFilter)

    '            QueryGrid()
    '            'If mStatusF = "Add" Then
    '            '    Dim int As Integer = FindValueID(Me.cboKind, Me.cboKind.Text.Trim)
    '            '    Dim st As String = Me.cboKind.Text.Trim
    '            '    Dim pos As Integer = Me.cboKind.SelectedIndex

    '            '    Me.cboKind.Items.RemoveAt(pos)
    '            '    Dim oItems As PDSAListItemString
    '            '    oItems = New PDSAListItemString
    '            '    oItems.ID = int - 1
    '            '    oItems.Value = st
    '            '    Me.cboKind.Items.Add(oItems)
    '            '    Me.cboKind.SelectedIndex = pos
    '            'End If

    '            'Me.dgdContianerOutboundNotify.Enabled = True
    '            'Me.fraUpdate.Visible = False
    '            'ReFormat()
    '            'SetMenu((True))
    '            'mStatus = "Normal"
    '            'reText(mStatus)
    '        End If
    '        mStatusF = "Normal"
    '        Me.dgdFreight.Enabled = True
    '        Me.cmdOKF.Enabled = False
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    '    Private Sub cmdCancelF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        ' Me.fraUpdate.Visible = False
    '        ReFormat()
    '        SetMenu((True))
    '        mStatusF = "Normal"
    '        mStatus = "Normal"
    '        reText(mStatus)
    '        Me.dgdContianerOutboundNotify.Enabled = True
    '        Me.cmdOKF.Enabled = False
    '        Me.dgdFreight.Enabled = True
    '        'Me.cmdCancel_Click(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    'Private Sub cboCharge_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        'If FindValueID(Me.cboCharge, Me.cboCharge.Text.Trim) = "" Then
    '        '    Return
    '        'End If
    '        'Dim tbl As New DataSet
    '        'tbl = ReadDataSet("Select * From Charge where continued=1 and Charge_ID='" & FindValueID(Me.cboCharge, Me.cboCharge.Text.Trim) & "'")
    '        'If tbl.Tables(0).Rows.Count > 0 Then
    '        '    Me.txtCharge.Text = tbl.Tables(0).Rows(0)("Charge")
    '        'End If
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cboKind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.cboKind.SelectedIndex = -1 Then
    '            Return
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Sub QueryGrid()
    '    Try
    '        Dim tbl As New DataSet
    '        tbl = ReadDataSet("Select * From FreightSale where continued=1 and ActualFreightID='" & ActualFreightBookingNo & "'")
    '        Me.dgdFreight.DataSource = tbl.Tables(0)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click


        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdContianerOutboundNotify, Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        If Not Me.dgdContianerOutboundNotify.Item("Editable", index).Value Or Not UserRight("frmActualFreight", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryContainerOutboundNotify(mFilter, , index)
        Else
            strQueryContainerOutboundNotifyList = "Select * from ActualFreight where" + " ActualFreightID= '" & dgdContianerOutboundNotify.Item("ActualFreightID", index).Value.ToString & "'"
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
        If UCase(Me.dgdContianerOutboundNotify.Columns(ColIndex).Name) = "APPROVE" And Me.dgdContianerOutboundNotify.CurrentCellAddress().Y = index Then
            Call ApproveContainerOutboundNotify()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Sub ApproveFreight()
    '        On Error GoTo Err_Renamed
    '        Dim Approve As Boolean
    '        ' Xác định vị trí row trong grid
    '        Dim index As Integer
    '        If Me.dgdFreight.RowCount > 0 Then
    '            index = Me.dgdFreight.CurrentRow.Index
    '        End If
    '        Dim rs As New ADODB.Recordset
    '        Dim strQueryContainerOutboundNotifyList As String
    '        If Not Me.dgdFreight.Item("EditableF", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '        Else
    '            strQueryContainerOutboundNotifyList = "Select * from FreightSale where" + " FreightSale_ID= '" & dgdFreight.Item("FreightSale_ID", index).Value.ToString & "'"
    '            rs.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            Approve = Not rs.Fields("Approve").Value
    '            rs.Update("Approve", Approve)
    '            rs.Close()
    '        End If
    '        QueryGrid()
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Private Sub dgdFreight_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        Dim ColIndex, RowIndex As Integer
    '        ' Xác định vị trí row trong grid
    '        On Error GoTo Err_Renamed
    '        If Me.dgdFreight.RowCount = 0 Then
    '            Exit Sub
    '        End If
    '        Dim index As Integer = Me.dgdFreight.CurrentRow.Index
    '        ColIndex = e.ColumnIndex()
    '        RowIndex = e.RowIndex
    '        If ColIndex < 0 Then
    '            Return
    '        End If

    '        If Me.dgdFreight.Columns(ColIndex).Name = "ApproveF" And Me.dgdFreight.CurrentCellAddress().Y = index Then
    '            Call ApproveFreight()
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub PrintOneOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        frmReportSaleSurcharge.ALL = False
        frmReportSaleSurcharge.SailingID = Me.dgdContianerOutboundNotify.Item("SailingScheduleID", index).Value.ToString()
        frmReportSaleSurcharge.BookingID = Me.dgdContianerOutboundNotify.Item("ActualFreightID", index).Value.ToString()
        frmReportSaleSurcharge.ShowDialog()
    End Sub

    Private Sub PrintVesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) = True Then
                Return
            End If
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            ActualFreightBookingNo = Me.dgdContianerOutboundNotify.Item("ActualFreightID", index).Value.ToString
            'If CheckExist() = False Then
            '    Return
            'End If
            Dim frm As New FrmPrintALLSaleSurcharge
            'frm = Me.dgdContianerOutboundNotify.Item("ActualFreightID", index).Value.ToString
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtServiceTermPOL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub txtFreight_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.txtFreight.Text.Trim <> tarrif Then
    '        userupdateTarrif = strUserName
    '        dateUpdateTarrif = Getdate()
    '        userupdateSale = ""
    '        dateUpdateSale = ""
    '        userupdatespecial = ""
    '        dateupdatespecial = ""

    '    End If
    'End Sub

    'Private Sub txtFreightSale_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.txtFreightSale.Text.Trim <> sale Then
    '        userupdateSale = strUserName
    '        dateUpdateSale = Getdate()
    '        userupdateTarrif = ""
    '        dateUpdateTarrif = ""
    '        userupdatespecial = ""
    '        dateupdatespecial = ""

    '    End If
    'End Sub

    '#Region "Thêm 04-10-2007"

    '    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
    '            Return
    '        End If
    '        Me.grpCopy.BringToFront()
    '        Me.grpCopy.Visible = True
    '        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
    '        Me.txtFromBookingNo.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value
    '    End Sub

    '    Private Sub cmdCancelCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelCopy.Click
    '        Try
    '            Me.grpCopy.Visible = False
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '    End Sub

    '    Private Sub dgdContianerOutboundNotify_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgdContianerOutboundNotify.MouseClick
    '        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
    '        '---- so 0 thanh mau trang
    '        Dim t, s As Integer
    '        For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
    '            For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
    '                If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
    '                    Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
    '                End If
    '            Next
    '        Next
    '    End Sub

    '    Private Sub dgdContianerOutboundNotify_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdContianerOutboundNotify.RowStateChanged
    '        Try
    '            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
    '                Return
    '            End If
    '            Dim Count As Integer = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
    '            If Count = 1 Then 'nếu chọn đúng 1 dòng thì hiện menu copy lên ngựơc lại thì tắt
    '                Me.CopyToolStripMenuItem.Enabled = True
    '            Else
    '                Me.CopyToolStripMenuItem.Enabled = False
    '            End If
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '    End Sub

    '    Function CheckFreight(ByVal BookingID As String) As Boolean ' kiểm tra booking đã có freight chưa nếu có trả về False chưa có trả về true
    '        Try
    '            Dim SQL As String
    '            SQL = "select count(*) from FreightSale Where ActualFreightID='" & BookingID & "' And Continued=1"
    '            Dim Tempds As New DataSet
    '            Tempds = ReadDataSet(SQL)
    '            If Tempds.Tables(0).Rows.Count > 0 Then
    '                If Tempds.Tables(0).Rows(0).Item(0) > 0 Then ' nếu đã có freight
    '                    Return False
    '                End If
    '            End If
    '            Return True
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try

    '    End Function

    '    Function CopyFreight(ByVal FromBookingID As String, ByVal ToBookingID As String) As Boolean
    '        Try
    '            Dim SQL As String
    '            SQL = "Select * from FreightSale Where ActualFreightID='" & FromBookingID & "' And Continued=1 "
    '            Dim rsFromBooking As New ADODB.Recordset
    '            rsFromBooking.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            If rsFromBooking.EOF Then
    '                MsgBox("Chưa có Phí")
    '                Return False
    '            End If
    '            rsFromBooking.MoveFirst()
    '            Dim rsToBooking As New ADODB.Recordset
    '            SQL = "Select Top 1 * From FreightSale"
    '            rsToBooking.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            While Not rsFromBooking.EOF
    '                With rsToBooking
    '                    .AddNew()
    '                    .Fields("FreightSale_ID").Value = NewId()
    '                    .Fields("ActualFreightID").Value = "{" & ToBookingID & "}"
    '                    For i As Integer = 0 To rsFromBooking.Fields.Count - 1
    '                        If UCase(.Fields(i).Name) = "FREIGHTSALE_ID" Or UCase(.Fields(i).Name) = "ActualFreightID" Then
    '                            Continue For
    '                        End If
    '                        .Fields(i).Value = rsFromBooking.Fields(i).Value
    '                    Next
    '                    .Update()
    '                End With
    '                rsFromBooking.MoveNext()
    '            End While
    '            rsToBooking.Close()
    '            rsFromBooking.Close()
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '        Return True
    '    End Function

    '    Private Sub cmdOkCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkCopy.Click
    '        Try
    '            Dim SQL As String
    '            SQL = "select ActualFreightID from Containeroutboundnotify Where Continued=1 and Editable=1 And BookingNo='" & Me.txtTpBookingNo.Text & "'"
    '            Dim ds As New DataSet
    '            ds = ReadDataSet(SQL)
    '            If ds.Tables(0).Rows.Count = 0 Then
    '                MsgBox("the To Booking No is Invalid, Or Not In data base , check Again Please")
    '                Return
    '            End If
    '            Dim FromBookingID, ToBookingID As String
    '            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
    '            FromBookingID = Me.dgdContianerOutboundNotify.Item("ActualFreightID", index).Value.ToString

    '            ToBookingID = ds.Tables(0).Rows(0).Item(0).ToString
    '            CopyFreight(FromBookingID, ToBookingID)
    '            QueryContainerOutboundNotify("  " & mFilter)
    '            mStatus = "Edit"
    '            cmdOk_Click(sender, e)
    '            mStatus = "Normal"
    '            Me.grpCopy.Visible = False
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '    End Sub

    '#End Region


    '    Private Sub cmdExitTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Me.fraUpdate.Visible = False
    '        ReFormat()
    '        SetMenu((True))
    '        mStatus = "Normal"
    '        reText(mStatus)
    '        Me.dgdContianerOutboundNotify.Enabled = True
    '        QueryContainerOutboundNotify(" " & mFilter)
    '        'Me.cmdCancelF_Click(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub txtFreightSale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    '    Private Sub TXTSpecialFreight_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        If Me.TXTSpecialFreight.Text.Trim <> Special Then
    '            userupdatespecial = strUserName
    '            dateupdatespecial = Getdate()
    '            userupdateTarrif = ""
    '            dateUpdateTarrif = ""
    '            userupdateSale = ""
    '            dateUpdateSale = ""

    '        End If
    '    End Sub

    '    Private Sub TXTSpecialFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        QueryContainerOutboundNotify(mFilter)
    End Sub

    Private Sub txtFreight_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreight.Leave
        If Not IsNumeric(Me.txtFreight.Text) Then
            MsgBox("You can Input Number Only")
            Me.txtFreight.Focus()
        End If
    End Sub

    Private Sub txtFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreight.TextChanged
        If Not IsNumeric(Me.txtFreight.Text) Then
            MsgBox("You can Input Number Only")
        End If
    End Sub

    Private Sub txtCom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCom.Leave, txtTax.Leave
        If Not IsNumeric(Me.txtCom.Text) Then
            MsgBox("You can Input Number Only")
            Me.txtCom.Focus()
        End If
    End Sub

    Private Sub txtCom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCom.TextChanged, txtTax.TextChanged
        If Not IsNumeric(Me.txtCom.Text) Then
            MsgBox("You can Input Number Only")
        End If
    End Sub

    Private Sub grpLeavingDateInfo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpLeavingDateInfo.Enter, grpRemarks.Enter

    End Sub

    Private Sub cmdLeavingDateCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeavingDateCancel.Click
        Me.grpLeavingDateInfo.Visible = False
    End Sub

    Private Sub cmdLeavingDateOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeavingDateOk.Click
        QueryContainerOutboundNotify(" And convert(dateTime,Leavingdate)>='" & Me.dtpfromLeavingDate.Value.Date & " 00:00:00' " & " And convert(dateTime,Leavingdate)<='" & Me.dtpToLeavingDate.Value.Date & " 23:59:00' ")
        Me.grpLeavingDateInfo.Visible = False
    End Sub

    Private Sub FromLeavingDateToLeavingDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromLeavingDateToLeavingDateToolStripMenuItem.Click
        Me.grpLeavingDateInfo.Visible = True
    End Sub

    Private Sub SaleSurchargeRemarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleSurchargeRemarksToolStripMenuItem.Click
        Me.grpRemarks.Visible = True
    End Sub

    Private Sub cmdRemarksOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemarksOK.Click
        QueryContainerOutboundNotify(" And upper(FreightSale.Note) like '%" & UCase(Me.txtRemarks.Text.Trim) & "%'")
        Me.grpRemarks.Visible = False
    End Sub

    Private Sub cmdRemarkCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemarkCancel.Click
        Me.grpRemarks.Visible = False
    End Sub

    Private Sub cmdLeavingDateRemarksCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeavingDateRemarksCancel.Click
        Me.grpLeavingDateRemarks.Visible = False
    End Sub

    Private Sub cmdLeavingDateRemarksOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeavingDateRemarksOk.Click
        If Me.txtLeavingDateRemarks.Text.Trim = "" Then
            QueryContainerOutboundNotify(" And convert(dateTime,Leavingdate)>='" & Me.dtpFromLeavingDateRemarks.Value.Date & " 00:00:00' " & " And convert(dateTime,Leavingdate)<='" & Me.dtpLeavingDateRemarks.Value.Date & " 23:59:00' ")
        Else
            QueryContainerOutboundNotify(" And upper(FreightSale.Note) like '%" & UCase(Me.txtLeavingDateRemarks.Text.Trim) & "%'" & " And convert(dateTime,Leavingdate)>='" & Me.dtpFromLeavingDateRemarks.Value.Date & " 00:00:00' " & " And convert(dateTime,Leavingdate)<='" & Me.dtpLeavingDateRemarks.Value.Date & " 23:59:00' ")
        End If
        Me.grpLeavingDateRemarks.Visible = False
    End Sub

    Private Sub LeavingDateRemarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeavingDateRemarksToolStripMenuItem.Click
        Me.grpLeavingDateRemarks.Visible = True
    End Sub

    Private Sub dgdContianerOutboundNotify_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContianerOutboundNotify.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
    End Sub

    Private Sub dgdContianerOutboundNotify_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContianerOutboundNotify.RowHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
    End Sub
End Class
