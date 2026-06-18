Imports Excel
Imports System.Globalization

Public Class frmInputLoadingPlanForVessel
    Dim dsdata As New DataSet
    Dim path As String = ""
    'Dim   dsdata.Tables.Add("oTable") As New DataTable
    'Dim otableallBooking As New DataTable
    'Dim oTableLoadingPlan As New DataTable
    'Dim oTableOutbound As New DataTable
    Dim mContainerOutboundNotify, mLoadingPlanVesselId As String
    Dim TypeBeforeEdit As String
    Dim ContainerNoBeforeEdit As String

    Dim blnUpdated As Boolean

    Dim mStatus, mFilter As String

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
        'dgdContianerOutboundNotify.Width = Me.Width - 30 - Me.dgdDelayInfo.Width
        If Me.Width > 610 Then
            Me.panBooking.Height = Me.Height - Me.cmdCancel.Height - 40 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            Me.panBooking.Height = Me.Height - 90 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        Me.dgdDelayInfo.Height = Me.panBooking.Height - 30
        Me.dgdContianerOutboundNotify.Height = Me.dgdDelayInfo.Height

        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdContianerOutboundNotify.Height + dgdContianerOutboundNotify.Top
        Me.panBooking.Width = Me.Width - 10
        Me.dgdDelayInfo.Height = Me.dgdContianerOutboundNotify.Height
        'Me.txtContainerOutboundNotify.Width = Me.Width - 300

        'me.txtCompany.Width = Me.fraUpdate.Width - me.txtCompany.Left - 10
        'me.txtCuctomsLiquiDate.Width = Me.fraUpdate.Width - me.txtCuctomsLiquiDate.Left - 10
        'me.txtCompany.Width = Me.fraUpdate.Width -me.txtRepresentative.Left - 10

        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOk.Left = cmdCancel.Left - cmdOk.Width - 10
        'cmdOk.Top = fraUpdate.Bottom + cmdOk.Height
        'cmdCancel.Top = fraUpdate.Bottom + cmdOk.Height
        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10

        'cmdFind.Left = Me.txtContainerOutboundNotify.Left + Me.txtContainerOutboundNotify.Width + 10
        'txtContainerOutboundNotify.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub chkNull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNull.CheckedChanged
        Try
            Me.txtDateOfSupplyMtContainer.Enabled = Not Me.chkNull.Checked

            If Me.chkNull.Checked = False Then
                Me.txtDateOfSupplyMtContainer.Text = Me.dtpDateOfSupplyMTContainer.Text
            Else
                Me.txtDateOfSupplyMtContainer.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfSupplyMTContainer.ValueChanged
        Try
            Me.txtDateOfSupplyMtContainer.Text = Me.dtpDateOfSupplyMTContainer.Value.Date
        Catch ex As Exception

        End Try
    End Sub

    Const strContainerOutboundNotifySelect As String = "SELECT " & _
   "ContainerOutBoundNotifyId, " & _
   "BookingNo, " & _
   "ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company,  " & _
   "ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, " & _
   " SoLuong45HC,SoLuong20RF,SoLuong40RF,SoLuong40RH," & _
   " SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong20OT,SoLuong40OT,SoLuong20FR,SoLuong40FR,Ventilation as Vent,Cold ,Tranship, " & _
   "PortOfUnLoading,CONTAINEROUTBOUNDNOTIFY.Destination as Dest, PackingWay, FullReturnContainerPlace," & _
    "CONTAINEROUTBOUNDNOTIFY.Approve as Approve, " & _
    "CONTAINEROUTBOUNDNOTIFY.Continued as Continued, " & _
    "CONTAINEROUTBOUNDNOTIFY.Editable as Editable, " & _
    "CONTAINEROUTBOUNDNOTIFY.UserId as UserId, " & _
    "CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime "


    Const strContainerOutboundNotifyOrder1 As String = _
           " ORDER BY BookingNo  Desc "
    Const strContainerOutboundNotifyOrder2 As String = _
        " ORDER BY UpdateTime Desc "

    Private Function MakeQueryContainerOutboundNotify(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryContainerOutboundNotify = strContainerOutboundNotifySelect
        MakeQueryContainerOutboundNotify &= ", (Select Count(*) From LoadingplanForVessel Where LoadingplanForVessel.ContainerOutboundNotifyID=ContainerOutBoundNotify.ContainerOutboundNotifyID and LoadingplanForVessel.Continued=1 ) as TotalContainer "
        MakeQueryContainerOutboundNotify &= ",(Select Sum(Soluong20GP+soluong40GP+soluong40HC+soluong45HC+Soluong20RF+soluong40RF+soluong40RH) From ContainerOutboundNotify as Booking Where ContainerOutboundNotify.ContainerOutboundNotifyID=Booking.ContainerOutboundNotifyID) as TotalBookingContainer "
        MakeQueryContainerOutboundNotify &= ", SupplyOrder=case (select Count(*) From [Order] Where [Order].BookingNo=ContainerOutboundNotify.BookingNo and [Order].Continued=1) when 0 then 0 else 1 end "
        MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & "  From ((ContainerOutBoundNotify lEFT JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
        MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & " lEFT JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & " WHERE "

        MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & "CONTAINEROUTBOUNDNOTIFY.Continued = 1 and  CONTAINEROUTBOUNDNOTIFY.editable = 1 "

        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & argCriteria
        End If

        MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & strContainerOutboundNotifyOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryContainerOutboundNotify = MakeQueryContainerOutboundNotify & strContainerOutboundNotifyOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub QueryContainerOutboundNotify(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryContainerOutboundNotify()
        Else
            strQuery = MakeQueryContainerOutboundNotify(argCriteria, index)
        End If
        'strQuery = "SELECT ContainerOutBoundNotifyId,BookingNo,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax, "
        'strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, "
        'strQuery = strQuery + " SailingSchedule.OceanVesselVoyNo as OceanVessel_VoyNo, Sell_Way,ContainerOutBoundNotify.SaleName,  ServiceContract,    CONTAINEROUTBOUNDNOTIFY.Market,  Representative ,  SoLuong20GP,    SoLuong40GP,     SoLuong40HC, "
        'strQuery = strQuery + " SoLuong45HC,   SoLuong20RF,SoLuong40RF,  SoLuong40RH, SaleCode,ServiceFeeder,LocalCargo,EmptyMoving,TransiteCargo,SOC,PayMentTerm,SlotExchange,FOBCargo,FirstSendDate,SecondSendDate,ThirdSendDate,SupplyDate,  SpencialEquipment, Cold ,Ventilation, EmptyContainerPlace,  PackingWay, CustomsLiquiDate, ClosingTime, Tranship, LeavingDate, "
        'strQuery = strQuery + " PortOfUnLoading, Destination,  ContainerOutBoundNotify.Remarks as Remarks,MaxWMainPort,MaxWLocal,ContactUs,BookingPerson,BookingDate,  CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,"
        'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime "
        'strQuery = strQuery + " From (((ContainerOutBoundNotify inner JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
        'strQuery = strQuery + " inner JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        'strQuery = strQuery + "inner JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) "
        'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 "
        'If argCriteria <> "" Then
        '    strQuery = strQuery + argCriteria
        'End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        If dsdata.Tables("oTable").Rows.Count > 0 Then
            dsdata.Tables("oTable").Rows.Clear()
        End If
        Adapter.Fill(dsdata.Tables("oTable"))

        'hien thi ra grid 
        Me.dgdContianerOutboundNotify.DataSource = dsdata.Tables("oTable")
        If Me.dgdContianerOutboundNotify.Enabled = False And Me.fraUpdate.Visible = False Then
            Me.dgdContianerOutboundNotify.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If dsdata.Tables("oTable").Rows.Count > 0 Then
            Me.dgdContianerOutboundNotify.Columns.Item("BookingNo").ToolTipText = "Hiện có:" + CStr(Me.dgdContianerOutboundNotify.RowCount()) + " ContainerOutboundNotifys."
        End If
        If Me.dgdContianerOutboundNotify.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        Me.dgdContianerOutboundNotify.Columns("ContainerOutBoundNotifyId").Visible = False
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdContianerOutboundNotify.Rows.Count And Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            Me.dgdContianerOutboundNotify.Rows(location).Selected = True
            ' Me.dgdContianerOutboundNotify.CurrentCell = Me.dgdContianerOutboundNotify.Rows(location).Cells(5)
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
            If Me.dgdContianerOutboundNotify.Item("TotalContainer", t).Value > Me.dgdContianerOutboundNotify.Item("TotalBookingContainer", t).Value Then
                'Me.dgdContianerOutboundNotify.Rows(t).DefaultCellStyle.BackColor = Color.Green
                'Me.dgdContianerOutboundNotify.Rows(t).DefaultCellStyle.BackColor = Color.White
                Me.dgdContianerOutboundNotify.Rows(t).DefaultCellStyle.ForeColor = Color.Black
            End If
            For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
                    Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
       
        Exit Sub
Err_Renamed:
        MsgBox("No data in the Grid !")
        'Resume
    End Sub

    Sub QueryDelayContainer(Optional ByVal range As String = "")
        Try
            Dim strQuery As String
            strQuery = "Select  BookingNo,Seal,Container_No,CTN_SIZE_TYPE, LOADINGPLANFORVESSEL.Delay,DelayDate ,Cancel"
            strQuery &= " From ((LOADINGPLANFORVESSEL LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyid=LOADINGPLANFORVESSEL.ContainerOutBoundNotifyID)"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID )"
            strQuery &= " Where LOADINGPLANFORVESSEL.Continued=1 and (LOADINGPLANFORVESSEL.delay=1 or cancel=1)" & IIf(range.Trim.Length > 0, range, "")
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet

            Adapter.Fill(ds)
            Me.dgdDelayInfo.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.dgdDelayInfo)
            '---- so 0 thanh mau trang
            'Dim t, s As Integer
            'For t = 0 To Me.dgdDelayInfo.RowCount - 1
            '    For s = 0 To Me.dgdDelayInfo.ColumnCount - 1
            '        If Me.dgdDelayInfo.Item(s, t).Value.ToString = "0" Then
            '            Me.dgdDelayInfo.Item(s, t).Style.ForeColor = mcbkColor
            '        End If
            '    Next
            'Next
            '----------
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryAddContainer(Optional ByVal Dk As String = "")
        Try
            Dim strQuery As String
            strQuery = "Select LOADINGPLANFORVESSELID,LOADINGPLANFORVESSEL.CTN_ID,BookingNo,LOADINGPLANFORVESSEL.vent as Ventilation,LOADINGPLANFORVESSEL.Cold,Seal,Container_No,CTN_SIZE_TYPE, LOADINGPLANFORVESSEL.Weight,LOADINGPLANFORVESSEL.Delay,Cancel,DateOfSupplyEmptyContainer,PLACESUPPLYEMPTYCONTAINER,RETURNPLACE,returndate,DelayDate,customClear, "
            strQuery &= "LOADINGPLANFORVESSEL.Continued,LOADINGPLANFORVESSEL.Editable,LOADINGPLANFORVESSEL.Approve,LOADINGPLANFORVESSEL.UserID,LOADINGPLANFORVESSEL.UpdateTime "
            strQuery &= " From ((LOADINGPLANFORVESSEL LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyid=LOADINGPLANFORVESSEL.ContainerOutboundNotifyid)"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID )"
            strQuery &= " Where LOADINGPLANFORVESSEL.Continued=1 "
            If mContainerOutboundNotify <> DefaultValue Then
                strQuery &= " and LOADINGPLANFORVESSEL.ContainerOutboundNotifyid='" & mContainerOutboundNotify & " '"
            End If
            If Dk <> "" Then
                strQuery &= Dk
            End If
            'mContainerOutboundNotify = DefaultValue
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            ' Dim dt As New DataTable
            If dsdata.Tables("dtContainerAdd").Rows.Count > 0 Then
                dsdata.Tables("dtContainerAdd").Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables("dtContainerAdd"))
            Me.dgdAddContainer.DataSource = dsdata.Tables("dtContainerAdd")
            InsertAutoNumberToGrid(Me.dgdAddContainer)
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdAddContainer.RowCount - 1
                For s = 0 To Me.dgdAddContainer.ColumnCount - 1
                    If Me.dgdAddContainer.Item(s, t).Value.ToString = "0" Then
                        Me.dgdAddContainer.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
            '------------------
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub
    Function GetContainer(ByVal BookingID As String) As String
        Try
            Dim SQL As String
            SQL = "Select Container_No "
            SQL &= " From (LoadingPlanForVessel LEFT JOIN Container On Container.CTN_ID=LoadingPlanForVessel.CTN_ID)"
            SQL &= " Where LoadingPlanForVessel.ContaineroutboundNotifyID='" & BookingID & "' and LoadingPlanForVessel.Continued=1 "
            Dim ds As New DataSet
            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""
            End If
            Dim Temp As String = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Temp &= ds.Tables(0).Rows(i).Item("Container_No").ToString & " ,"
            Next
            If Temp.Length > 0 Then
                Temp = Temp.Remove(Temp.Length - 1, 1)
            End If
            Return Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub QueryLoadContainer(Optional ByVal range As String = "")
        Try
            Dim strQuery As String
            strQuery = "select * from container where continued=1 " & IIf(range.Trim.Length > 0, range.Trim, "")

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet

            Adapter.Fill(ds)

            If ds.Tables(0).Rows.Count = 0 Then
                DisplayMessage(True, "Bãi Không Có loại Container" & Me.cboContainerType.Text)
            End If
            Me.cboContainerNo.DisplayMember = "Container_No"
            Me.cboContainerNo.ValueMember = "CTN_ID"
            Me.cboContainerNo.DataSource = ds.Tables(0)
            Me.cboContainerNo.Text = Me.cboContainerNo.SelectedText

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub Queryvessel()
        Try
            Dim strQuery As String

            strQuery = "select distinct Vessel + ' - ' + VoyNo + ' - ' + Replace(Convert(nvarchar,ETD),'12:00AM','') as data,SailingSchedule.SailingScheduleID, ETD "
            strQuery &= " From ((ContainerOutboundNotify LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingscheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strQuery &= " Where ContainerOutboundNotify.continued=1 order by ETD"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            Adapter.Fill(ds)
            'Me.cboVesselVoyNoETD.Items.Clear()

            Me.cboVesselVoyNoETD.DataSource = ds.Tables(0)
            Me.cboVesselVoyNoETD.DisplayMember = "data"
            Me.cboVesselVoyNoETD.ValueMember = "SailingScheduleID"
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Sub QueryLoadingPlan(Optional ByVal Dk As String = "")
        Try
            Dim strQuery As String
            strQuery = "Select Distinct BookingNo,COMPANY,DateOfSupplyEmptyContainer,PLACESUPPLYEMPTYCONTAINER,Container_No,Seal,CTN_SIZE_TYPE, LOADINGPLANFORVESSEL.Cold,LOADINGPLANFORVESSEL.vent as Ventilation,Tranship,PortOfUnLoading,ContainerOutBoundNotify.PortOfLoading,PackingWay,RETURNPLACE,"
            strQuery &= "Delay= case LOADINGPLANFORVESSEL.delay when 1 then 'DELAY' end ,Cancel=case Cancel when 1 then 'Cancel' end , LOADINGPLANFORVESSEL.ContainerOutboundNotifyID "
            strQuery &= " From (((((LOADINGPLANFORVESSEL LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyid=LOADINGPLANFORVESSEL.ContainerOutboundNotifyid)"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID )"
            strQuery &= "LEFT JOIN Customer On Customer.Customer_ID=ContainerOutboundNotify.Customer_ID)"
            strQuery &= "LEFT JOIN BillOfLading On ContainerOutBoundNotify.ContainerOutBoundNotifyID=BillOfLAding.ContainerOutBoundNotifyID)"
            strQuery &= " LEFT JOIN Shipper On Shipper.Shipper_ID=BillOfLading.Shipper_ID )"
            strQuery &= " Where LOADINGPLANFORVESSEL.Continued=1 and ContainerOutboundNotify.sailingscheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "' And LOADINGPLANFORVESSEL.Delay=0 And Cancel=0"
            strQuery &= " And Container_No " & Dk & " in ( Select Container_No "
            strQuery &= " From (((Cargo LEFT JOIN BillOfLading On BillOfLading.BL_ID=Cargo.BL_ID )"
            strQuery &= " LEFT JOIN ContainerOutboundNotify on ContainerOutboundNotify.ContainerOutboundNotifyid=BillOfLading.ContainerOutboundNotifyid)"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=Cargo.CTN_ID )"
            strQuery &= " Where Cargo.Continued=1 and ContainerOutboundNotify.sailingscheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "')"

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            ' Dim dt As New DataTable
            If dsdata.Tables("oTableLoadingPlan").Rows.Count > 0 Then
                dsdata.Tables("oTableLoadingPlan").Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables("oTableLoadingPlan"))
        Catch ex As Exception

        End Try


    End Sub

    'Sub QueryOutboundData()
    '    Try
    '        Dim strQuery As String
    '        strQuery = "Select cargo.CTN_ID,BookingNo,Seal,Container_No,CTN_SIZE_TYPE, LOADINGPLANFORVESSEL.ContainerOutboundNotifyID "
    '        strQuery &= " From (((Cargo LEFT JOIN BillOfLading On BillOfLading.BL_ID=Cargo.BL_ID )"
    '        strQuery &= " LEFT JOIN ContainerOutboundNotify on ContainerOutboundNotify.ContainerOutboundNotifyid=BillOfLading.ContainerOutboundNotifyid)"
    '        strQuery &= " LEFT JOIN Container On Container.CTN_ID=Cargo.CTN_ID )"
    '        strQuery &= " Where Cargo.Continued=1 and ContainerOutboundNotify.sailingscheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "' Order by BookingNo"
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        ' Dim dt As New DataTable
    '        If oTableOutbound.Rows.Count > 0 Then
    '            oTableOutbound.Rows.Clear()
    '        End If
    '        Adapter.Fill(oTableOutbound)
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Public Sub QueryICD(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Code"
        value = "TerminalName"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Code,TerminalName From Terminal where Continued=1 Order By Code desc"
        loadDataToObject(combo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmInputLoadingPlanForVessel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mContainerOutboundNotify = DefaultValue
            mLoadingPlanVesselId = DefaultValue
            dsdata.Tables.Clear()
            Me.cmdFind.Visible = False
            dsdata.Tables.Add("oTable")
            dsdata.Tables.Add("oTableLoadingPlan")
            dsdata.Tables.Add("dtContainerAdd")
            dsdata.Tables.Add("oTableOutbound")
            SetMenu(True)
            QueryLoadContainer()
            Queryvessel()
            QueryICD(Me.cboPlaceOfSupplyMTContainer)
            QueryICD(Me.cboReturnPlace)
            SetDefaultGrid(Me.dgdAddContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdContianerOutboundNotify, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdDelayInfo, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'QueryContainerOutboundNotify()
            'QueryDelayContainer()
            Me.fraUpdate.Visible = False
            ' QueryAddContainer()

            ReFormat()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            mFilter = " And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "'"
            Me.QueryContainerOutboundNotify(" " & mFilter)
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu(True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Me.dgdContianerOutboundNotify.Enabled = argVisible
        Me.cboVesselVoyNoETD.Enabled = argVisible
        Me.txtContainerOutboundNotify.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Function CheckData(ByVal index As Integer) As Boolean
        Try
            Dim GP20, GP40, RF20, RF40, RH40, HC40, HC45 As Integer
            'GP20 = GP40 = RF20 = RF40 = RH40 = HC40 = HC45 = 0
            For i As Integer = 0 To Me.dgdAddContainer.Rows.Count - 1
                If Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "20GP" Then
                    GP20 += 1
                ElseIf Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "40GP" Then
                    GP40 += 1
                ElseIf Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "20RF" Then
                    RF20 += 1
                ElseIf Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "40RF" Then
                    RF40 += 1
                ElseIf Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "40RH" Then
                    RH40 += 1
                ElseIf Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "40HC" Then
                    HC40 += 1
                ElseIf Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = "HC45" Then
                    HC45 += 1
                End If
            Next
            Dim temp As Boolean
            Dim t As Integer = 1

            If mStatus = "Edit" Then 'And TypeBeforeEdit = Me.cboContainerType.Text
                t = 0
                TypeBeforeEdit = ""
            End If

            If Me.cboContainerType.Text.Trim = "20GP" Then
                GP20 += t
                temp = GP20 <= Me.dgdContianerOutboundNotify.Item("Soluong20GP", index).Value
            ElseIf Me.cboContainerType.Text.Trim = "40GP" Then
                GP40 += t
                temp = GP40 <= Me.dgdContianerOutboundNotify.Item("Soluong40GP", index).Value
            ElseIf Me.cboContainerType.Text.Trim = "20RF" Then
                RF20 += t
                temp = (RF20 <= Me.dgdContianerOutboundNotify.Item("Soluong20RF", index).Value)
            ElseIf Me.cboContainerType.Text.Trim = "40RF" Then
                RF40 += t
                temp = (RF40 <= Me.dgdContianerOutboundNotify.Item("Soluong40RF", index).Value)
            ElseIf Me.cboContainerType.Text.Trim = "40RH" Then
                RH40 += t
                temp = (RH40 <= Me.dgdContianerOutboundNotify.Item("Soluong40RH", index).Value)
            ElseIf Me.cboContainerType.Text.Trim = "40HC" Then
                HC40 += t
                temp = (HC40 <= Me.dgdContianerOutboundNotify.Item("Soluong40HC", index).Value)
            ElseIf Me.cboContainerType.Text.Trim = "45HC" Then
                HC45 += t
                temp = (HC45 <= Me.dgdContianerOutboundNotify.Item("Soluong45HC", index).Value)
            End If

            Return temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim strQuery, strLOADINGPLANFORVESSELID, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Else
                Return
            End If
            'If mLoadingPlanId = DefaultValue Then
            '    For i As Integer = 0 To Me.dgdAddContainer.RowCount - 1 'kiểm tra container trùng 
            '        If Me.cboContainerNo.Text.Trim = Me.dgdAddContainer.Item("Container_NoAdd", i).Value.ToString.Trim Then
            '            MsgBox("This Container was Added")
            '            Exit Sub
            '        End If
            '    Next
            'End If
            If Me.cboContainerNo.Text = "" Then
                DisplayMessage(True, "Số Container không đựơc trống , hãy nhập só container")
                Return
            End If
            'If CheckData(index) = False Then
            '    DisplayMessage(True, "Hãy chắc chắn Số lựơng Loại Container " & Me.cboContainerType.Text & " Phù hợp Với số lựơng đã Book")
            '    Return
            'End If
            Dim rsCheck As New ADODB.Recordset
            Dim strCheck As String

            Dim rsDelay As New ADODB.Recordset
            Dim strDelay As String
            'kiểm tra nếu container trùng container delay
            strDelay = "select * from LOADINGPLANFORVESSEL where delay=1 And CTN_ID='" & Me.cboContainerNo.SelectedValue.ToString & "' And Continued=1"
            rsDelay.Open(strDelay, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rsDelay.EOF Then
                With rsDelay
                    .Fields("delay").Value = 0
                    .Update()
                End With
                QueryDelayContainer()
            End If
            rsDelay.Close()

            'kiểm tra không trùng container luu y them vao kiem tra tren 1 tau luon va thng bao , neu cont da ton tai tren 1 chuyen nao do
            'tim tat ca cac booking cua tat cac cac tau co ngay di tu ngay hien tai



            '----
            If mStatus = "Add" Then
                strCheck = "Select * from (LOADINGPLANFORVESSEL inner join ContainerOutBoundNotify on LOADINGPLANFORVESSEL.ContainerOutBoundNotifyID =ContainerOutBoundNotify.ContainerOutBoundNotifyID )inner join sailingschedule on "
                strCheck &= " ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID where  SailingSchedule.ETD >= GETDATE() and LOADINGPLANFORVESSEL.Continued=1 And LOADINGPLANFORVESSEL.CTN_ID='" & Me.cboContainerNo.SelectedValue.ToString & "'"
                rsCheck.Open(strCheck, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rsCheck.EOF Then
                    MsgBox("This Container was Added in the booking no. :" & rsCheck.Fields("bookingno").Value.ToString)
                    rsCheck.Close()
                    Exit Sub
                End If
                rsCheck.Close()
            ElseIf mStatus = "Edit" Then

                Dim pos As Integer
                pos = Me.dgdAddContainer.CurrentRow.Index
                For i As Integer = 0 To Me.dgdAddContainer.RowCount - 1
                    If Me.dgdAddContainer.Item("Container_NoAdd", i).Value.ToString.Trim = Me.cboContainerNo.Text.Trim And i <> pos Then
                        MsgBox("This Container was Added in This booking")
                        'rsCheck.Close()
                        Exit Sub
                    End If
                Next
            End If


            If (mStatus = "Edit" Or mStatus = "Add") Then
                If mStatus = "Edit" Then
                    CopyValues("LOADINGPLANFORVESSEL", "LOADINGPLANFORVESSELID", mLoadingPlanVesselId)
                End If
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM LOADINGPLANFORVESSEL "
                strQuery = strQuery & "WHERE LOADINGPLANFORVESSELID = '" & mLoadingPlanVesselId & "' AND LOADINGPLANFORVESSELID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("LOADINGPLANFORVESSELID").Value = NewId()
                        .Fields("ContainerOutBoundNotifyId").Value = "{" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyID", index).Value.ToString & "}"
                    End If
                    strLOADINGPLANFORVESSELID = .Fields("LOADINGPLANFORVESSELID").Value

                    .Fields("RETURNPLACE").Value = Me.cboReturnPlace.Text

                    .Fields("CTN_ID").Value = "{" & Me.cboContainerNo.SelectedValue.ToString & "}"
                    .Fields("SEAL").Value = Me.txtSeal.Text
                    .Fields("Weight").Value = Me.txtWeight.Text
                    .Fields("cold").Value = Me.txtCold.Text
                    .Fields("vent").Value = Me.txtVent.Text
                    .Fields("Delay").Value = IIf(Me.chkDelay.Checked, 1, 0)
                    If Me.chkDelay.Checked = True Then
                        .Fields("DelayDate").Value = Me.dtpDelayDate.Value.Date
                    Else
                        .Fields("DelayDate").Value = ""
                    End If
                    .Fields("Cancel").Value = IIf(Me.chkCancel.Checked, 1, 0)

                    '.Fields("RETURNPLACE").Value = UCase(Trim(Me.cboReturnPlace.Text))
                    .Fields("RETURNDATE").Value = Me.txtReturnDate.Text   'UCase(Trim(Me.cboReturnPlace.Text))
                    .Fields("CustomClear").Value = Me.chkCustomClear.Checked

                    .Fields("PLACESUPPLYEMPTYCONTAINER").Value = UCase(Trim(Me.cboPlaceOfSupplyMTContainer.Text))
                    .Fields("DateOfSupplyEmptyContainer").Value = IIf(Me.chkNull.Checked, "", Me.txtDateOfSupplyMtContainer.Text)


                    .Update()

                End With
                rs.Close()
                'Me.dgdContianerOutboundNotify.Enabled = True
                QueryAddContainer()
                QueryDelayContainer()
                'mFilter = " And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "'"
                'Me.QueryContainerOutboundNotify(" " & mFilter, , index)
                mLoadingPlanVesselId = DefaultValue
                TypeBeforeEdit = ""
                ReFormat()
                'SetMenu((True))
                SetAddContainerItem(False)
                mStatus = "Normal"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboContainerNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboContainerNo.Leave
        Dim strSql As String
        strSql = "Select Container_No  From Container Where Continued=1 And CTN_SIZE_TYPE='" & Me.cboContainerType.Text.Trim & "'"
        If Me.cboContainerNo.FindStringExact(Me.cboContainerNo.Text) = -1 And Me.cboContainerNo.Text <> "" Then
            'Me.cboContainerNo.Text = FindBetter_new("Container_No", strSql, Me.cboContainerNo.Text)
            If Me.cboContainerNo.FindStringExact(Me.cboContainerNo.Text) = -1 Then
                DisplayMessage(True, "The Container is invalid, please check and correct it.")
                Me.cboContainerNo.Focus()
            End If
        End If
    End Sub

    Private Sub cboContainerNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContainerNo.SelectedIndexChanged
        '        On Error GoTo Err_Named
        '        Dim ContainerID As String
        '        ContainerID = Me.cboContainerNo.SelectedValue.ToString
        '        If ContainerID <> "" Then
        '            Dim strQuery As String
        '            '-------------
        '            Dim Con As New SqlClient.SqlConnection(strconnDG)
        '            Dim dset As New DataSet
        '            'Dim table As New DataTable

        '            '----------------
        '            strQuery = "select * from Container where CTN_ID='" & ContainerID & "'"

        '            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        '            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '            '-----------------

        '            'If Not IsNothing(oTable) Then
        '            '    oTable.Clear()
        '            'End If
        '            Adapter.Fill(dset, "Bill")
        '            ' table = dset.Tables("Bill")
        '            If dset.Tables(0).Rows.Count > 0 Then
        '                'CtainerID = table.Rows(0).Item("CTN_ID").ToString
        '                Me.cboContainerType.Text = dset.Tables(0).Rows(0).Item("CTN_SIZE_TYPE").ToString
        '                'Reefer_Degree()
        '            End If

        '            ''''''''''''''''''''''''''''''''''''''''

        '        End If
        '        Exit Sub
        'Err_Named:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub RefreshData(ByVal index As Integer)
        Try
            ' mLoadingPlanId = Me.dgdAddContainer.Item("LOADINGPLANFORVESSELID", index).Value.ToString
            Me.cboContainerType.Text = Me.dgdAddContainer.Item("CTN_SIZE_TYPE", index).Value.ToString.Trim
            Me.cboContainerNo.Text = Me.dgdAddContainer.Item("Container_NoAdd", index).Value.ToString
            Me.txtWeight.Text = Me.dgdAddContainer.Item("Weight", index).Value.ToString
            Me.txtCold.Text = Me.dgdAddContainer.Item("Cold", index).Value.ToString
            Me.txtVent.Text = Me.dgdAddContainer.Item("vent", index).Value.ToString

            Me.txtSeal.Text = Me.dgdAddContainer.Item("sealAdd", index).Value.ToString
            If Me.dgdAddContainer.Item("DateOfSupplyEmptyContainer", index).Value.ToString.Trim = "" Then
                Me.chkNull.Checked = True
            Else
                Me.chkNull.Checked = False
                Me.dtpDateOfSupplyMTContainer.Text = CDate(Me.dgdAddContainer.Item("DateOfSupplyEmptyContainer", index).Value)
            End If
            Me.cboPlaceOfSupplyMTContainer.Text = Me.dgdAddContainer.Item("PLACESUPPLYEMPTYCONTAINER", index).Value.ToString
            Me.cboReturnPlace.Text = Me.dgdAddContainer.Item("ReturnPlace", index).Value.ToString
            Me.chkDelay.Checked = Me.dgdAddContainer.Item("DelayAdd", index).Value
            Me.chkCustomClear.Checked = Me.dgdAddContainer.Item("CustomClear", index).Value
            If Me.chkDelay.Checked = True Then
                Me.dtpDelayDate.Text = Me.dgdAddContainer.Item("DelayDate", index).Value
            End If
            Me.txtReturnDate.Text = Me.dgdAddContainer.Item("returndate", index).Value
            Me.chkCancel.Checked = Me.dgdAddContainer.Item("CancelAdd", index).Value
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If dsdata.Tables("oTable").Rows.Count > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Else
                Exit Sub
            End If

            If index >= 0 Then
                Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
                EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value
                If Not Approve And EditTable And UserRight("frmInputLoadingPlanForVessel", "Edit") And Not Me.dgdContianerOutboundNotify.Rows(index).DefaultCellStyle.ForeColor = Color.White Then

                    Me.dgdContianerOutboundNotify.Height = 306
                    Me.dgdContianerOutboundNotify.Enabled = True
                    'Me.txtBookingNo.Enabled = False
                    Me.fraUpdate.Visible = True
                    ReFormat()
                    SetMenu((False))
                    mContainerOutboundNotify = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
                    ' mLoadingPlanId = Me.dgdContianerOutboundNotify.Item("LOADINGPLANFORVESSELID", index).Value.ToString
                    QueryAddContainer()
                    SetAddContainerItem(False)

                Else
                    DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    'Private Sub dgdAddContainer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdAddContainer.CellClick
    '    Try
    '        Dim index As Integer
    '        index = Me.dgdAddContainer.CurrentRow.Index
    '        If index < 0 Then
    '            Exit Sub
    '        End If
    '        RefreshData(index)
    '        mLoadingPlanId = Me.dgdAddContainer.Item("LOADINGPLANFORVESSELID", index).Value.ToString
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub dgdAddContainer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdAddContainer.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        Dim index As Integer
        If dsdata.Tables("dtContainerAdd").Rows.Count > 0 Then
            index = Me.dgdAddContainer.CurrentRow.Index
        Else
            Exit Sub
        End If
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdAddContainer.Columns(ColIndex).Name = "ApproveAdd" And Me.dgdAddContainer.CurrentCellAddress().Y = index Then
            Call ApproveAddContainer()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboVesselVoyNoETD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVesselVoyNoETD.SelectedIndexChanged
        Try
            Dim strQuery, strQueryCont As String
            strQuery = "select Count(BookingNo) as Booking from containeroutboundNotify "
            strQuery &= " Where SailingScheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "' And Continued=1"
            strQuery &= "group by SailingScheduleID"

            'strQueryCont = "select Count(ContainerNo) as Container from Loadingplanforvessel "
            'strQueryCont &= " Where SailingScheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "' And Continued=1"
            'strQueryCont &= "group by SailingScheduleID"


            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet

            Adapter.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtContainerOutboundNotify.Text = ds.Tables(0).Rows(0).Item("Booking").ToString & " Booking"
                QueryContainerOutboundNotify(" and containeroutboundnotify.SailingScheduleID= '" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "'")
                QueryDelayContainer()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ApproveContainerOutboundNotify()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If dsdata.Tables("oTable").Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        End If

        Dim strQueryContainerOutboundNotifyList As String
        If Not Me.dgdContianerOutboundNotify.Item("Editable", index).Value Or Not UserRight("frmContainerOutBoundNotify", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            'QueryContainerOutboundNotify(, , index)
        Else
            Dim rsContainerOutboundNotifyList As New ADODB.Recordset
            strQueryContainerOutboundNotifyList = "Select * from ContainerOutboundNotify where" + " ContainerOutBoundNotifyId= '" & dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "'"
            rsContainerOutboundNotifyList.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsContainerOutboundNotifyList.Fields("Approve").Value
            rsContainerOutboundNotifyList.Update("Approve", Approve)
            rsContainerOutboundNotifyList.Close()
        End If
        QueryContainerOutboundNotify(" and containeroutboundnotify.SailingScheduleID= '" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "'", 1, index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveAddContainer()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If dsdata.Tables("oTable").Rows.Count > 0 Then
            index = Me.dgdAddContainer.CurrentRow.Index
        End If

        Dim strQueryContainerOutboundNotifyList As String
        If Not Me.dgdContianerOutboundNotify.Item("EditableAdd", index).Value Or Not UserRight("frmInputLoadingPlanForVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            'QueryContainerOutboundNotify(, , index)
        Else
            Dim rsAddContainer As New ADODB.Recordset
            strQueryContainerOutboundNotifyList = "Select * from LOADINGPLANFORVESSEL where" + " LOADINGPLANFORVESSELid= '" & Me.dgdAddContainer.Item("LOADINGPLANFORVESSELID", index).Value.ToString & "'"
            rsAddContainer.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsAddContainer.Fields("Approve").Value
            rsAddContainer.Update("Approve", Approve)
            rsAddContainer.Close()
        End If
        QueryAddContainer()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdContianerOutboundNotify_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContianerOutboundNotify.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        Dim index As Integer
        If dsdata.Tables("oTable").Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdContianerOutboundNotify.CurrentCellAddress.X = 15 And Me.dgdContianerOutboundNotify.CurrentCellAddress().Y = index Then
            Call ApproveContainerOutboundNotify()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        Me.Close()
    End Sub

    Sub SetAddContainerItem(ByVal value As Boolean)
        Try
            Me.cboContainerNo.Enabled = value
            Me.cboContainerType.Enabled = value
            Me.cmdOk.Enabled = value
            ' Me.cmdCancel.Enabled = value
            Me.txtSeal.Enabled = value
            Me.txtWeight.Enabled = value
            Me.dtpDateOfSupplyMTContainer.Enabled = value
            Me.cboReturnPlace.Enabled = value
            Me.cboPlaceOfSupplyMTContainer.Enabled = value
            Me.chkDelay.Enabled = value
            Me.chkCancel.Enabled = value
            Me.dtpReturnDate.Enabled = value
            Me.chkCustomClear.Enabled = value
            Me.dtpDelayDate.Enabled = value
            ' Me.dtpDelayDate.Enabled = value
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ctmAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmAdd.Click
        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Try
            If Me.fraUpdate.Visible = True Then
                Dim CountColdContainer As Integer = 0
                CountColdContainer += Me.dgdContianerOutboundNotify.Item("Soluong20RF", index).Value
                CountColdContainer += Me.dgdContianerOutboundNotify.Item("Soluong40RF", index).Value
                CountColdContainer += Me.dgdContianerOutboundNotify.Item("Soluong40RH", index).Value
                If CountColdContainer > 0 Then
                    Me.txtCold.Text = Me.dgdContianerOutboundNotify.Item("BookingCold", index).Value.ToString
                    Me.txtVent.Text = Me.dgdContianerOutboundNotify.Item("BookingVent", index).Value.ToString
                Else
                    Me.txtCold.Text = ""
                    Me.txtVent.Text = ""

                End If
            End If
            Me.cboReturnPlace.Text = Me.dgdContianerOutboundNotify.Item("FullReturnContainerPlace", index).Value.ToString

            SetAddContainerItem(True)
            mLoadingPlanVesselId = DefaultValue
            TypeBeforeEdit = ""
            mStatus = "Add"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub ctmEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        'TypeBeforeEdit = ""
        Dim index As Integer
        If Me.dgdAddContainer.RowCount > 0 Then
            index = Me.dgdAddContainer.CurrentRow.Index
        Else
            Exit Sub
        End If
        If index >= 0 Then
            Approve = Me.dgdAddContainer.Item("ApproveAdd", index).Value
            EditTable = Me.dgdAddContainer.Item("EditableAdd", index).Value
            If Not Approve And EditTable And UserRight("frmInputLoadingPlanForVessel", "Edit") Then
                mLoadingPlanVesselId = Me.dgdAddContainer.Item("LOADINGPLANFORVESSELID", index).Value.ToString
                ' Me.txtBillOfLadingId.Text = Me.dgdBillOfLading.Item("BL_No", index).Value.ToString
                mStatus = "Edit"
                RefreshData(index)
                Me.fraUpdate.Visible = True
                SetAddContainerItem(True)
                TypeBeforeEdit = Me.cboContainerType.Text.Trim
                ContainerNoBeforeEdit = Me.cboContainerNo.Text.Trim

            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        SetAddContainerItem(True)
        '---------

    End Sub
    Sub UpdateWaitBooking(ByVal ID As String)
        Try
            Dim SQL As String
            SQL = " Update ContainerOutboundNotify Set Wait=0 Where ContainerOutboundNotifyID='" & ID & "' "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub UpdateBookingWaiting(ByVal BookingNo As String)
        Try
            'kiểm tra nếu tất cả các container cancel đều dc xoá hết
            For i As Integer = 0 To Me.dgdAddContainer.RowCount - 1
                If Me.dgdAddContainer.Item("CancelAdd", i).Value = 1 Then
                    Return
                End If
            Next

            'nếu ko con container bị cancel nữa thì cập nhật waiting =0
            Dim SQL As String
            SQL = " Update ContainerOutboundNotify "
            SQL &= " Set Wait=0 "
            SQL &= " Where BookingNo='" & BookingNo & "W' "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub ctmDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmDelete.Click
        Dim strMesg, strQuery As String
        Dim bm As Short
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If Me.dgdAddContainer.RowCount > 0 Then
            index = Me.dgdAddContainer.CurrentRow.Index
        Else
            Exit Sub
        End If
        If Not UserRight("frmInputLoadingPlanForVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container: " & Me.dgdAddContainer.Item("Container_NoAdd", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from LOADINGPLANFORVESSEL where" + " LOADINGPLANFORVESSELID= '" & Me.dgdAddContainer.Item("LOADINGPLANFORVESSELID", index).Value.ToString & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()
                rs.Requery()
                Me.dgdAddContainer.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdAddContainer.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                blnUpdated = True
                UpdateBookingWaiting(Me.dgdAddContainer.Item("BooKingContainerNo", index).Value.ToString.Trim)
            End If
        End If
        QueryAddContainer(" " + mFilter)
        If Me.dgdAddContainer.Rows.Count = 0 Then
            UpdateWaitBooking(mContainerOutboundNotify)
        End If
    End Sub

    Private Sub cboContainerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContainerType.SelectedIndexChanged
        Try
            'Dim strQuery As String
            'mLoadingPlanId = DefaultValue
            'strQuery = "select * from container where continued=1"
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'Dim dt As New DataTable
            'If dt.Rows.Count > 0 Then
            '    dt.Rows.Clear()
            'End If
            'Adapter.Fill(dt)
            'If dt.Rows.Count > 0 Then
            '    Me.cboContainerType.Text = dt.Rows(0).Item("CTN_SIZE_TYPE").ToString
            'End If
            QueryLoadContainer(" And CTN_SIZE_TYPE='" & Me.cboContainerType.Text.Trim & "'")
            'Dim Type As Integer = 0
            'For i As Integer = 0 To Me.dgdAddContainer.Rows.Count - 1
            '    If Me.dgdAddContainer.Item("CTN_SIZE_TYPE", i).Value.ToString = Me.cboContainerType.Text.Trim Then
            '        Type += 1
            '    End If
            'Next
            'For j As Integer = 0 To Me.dgdContianerOutboundNotify.Columns.Count - 1
            '    If Me.dgdContianerOutboundNotify.Columns(j).HeaderText = Me.cboContainerType.Text Then
            '        If Type >= Me.dgdContianerOutboundNotify.Item(j, Me.dgdContianerOutboundNotify.CurrentRow.Index).Value Then
            '            DisplayMessage(True, "Loại container này đã đủ số lựơng trong Booking")
            '            Me.cboContainerType.SelectedIndex = IIf(Me.cboContainerType.SelectedIndex + 1 > Me.cboContainerType.Items.Count, Me.cboContainerType.SelectedIndex - 1, Me.cboContainerType.SelectedIndex + 1)
            '        End If
            '    End If
            'Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdAddContainer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdAddContainer.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdAddContainer)
    End Sub


    Private Sub dgdAddContainer_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdAddContainer.RowsAdded
        Try
            Me.txtQuantity.Text = Me.dgdAddContainer.RowCount
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuExportLoadingPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportLoadingPlan.Click
        Dim App As Excel.Application

        Try
            App = New Application()
            'App.Visible = True
            Dim Trung As Boolean = False
            Me.SaveFileDialog1.FileName = Strings.Replace(Me.cboVesselVoyNoETD.Text, " - ", "")
            Me.SaveFileDialog1.FileName = Strings.Replace(Me.SaveFileDialog1.FileName, ":", "")
            If Me.SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                QueryLoadingPlan(" Not ")
                If dsdata.Tables("oTableLoadingPlan").Rows.Count = 0 Then
                    QueryLoadingPlan()
                    Trung = True
                    MsgBox("Container Đã Trùng khớp")
                    'Else
                    '    Me.SaveFileDialog1.FileName &= "Delay"
                End If
                If Trung = False Then
                    MsgBox("Container chưa khớp")
                End If
                'Me.SaveFileDialog1.FileName &= ".xls"
                'Dim workbooks As Workbooks
                Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

                Dim workbooks As Workbooks
                workbooks = App.Workbooks
                Dim workbook As _Workbook

                path = StartupPath & "\LoadingContainerList.xls"

                workbook = workbooks.Open(path)
                Dim sheets As Sheets
                sheets = workbook.Worksheets
                Dim ws As _Worksheet
                ws = sheets.Item(1)
                If ws Is Nothing Then
                    App.Quit()

                    Return
                End If
                'hien thi excel len 
                App.Visible = True
                Dim DongHientai As Integer = 8
                Dim CotHienTai As Integer
                Dim POD As String = ""
                Dim n As Integer = dsdata.Tables("oTableLoadingPlan").Rows.Count
                For i As Integer = 0 To n - 1
                    ws.Range("A" & DongHientai).Value2 = i + 1
                    CotHienTai = 0
                    For j As Integer = 0 To 11
                        'If Alpha(j + 1) = "C" Then
                        '    Dim BookingNo As String
                        '    Dim ContainerNo As String
                        '    BookingNo = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("BookingNo").ToString.Trim
                        '    ContainerNo = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("Container_no").ToString.Trim
                        '    QueryShipper(BookingNo, ContainerNo)
                        '    ws.Range("C" & DongHientai).Value2 = dsdata.Tables("Shipper").Rows(0).Item(0)
                        'Else
                        ws.Range(Alpha(j + 1) & DongHientai).Value2 = dsdata.Tables("oTableLoadingPlan").Rows(i).Item(CotHienTai)

                        CotHienTai += 1
                        'CotHienTai += 1
                        'End If
                    Next
                    Dim Check() As String
                    Check = Strings.Split(POD, dsdata.Tables("oTableLoadingPlan").Rows(i).Item("PortOfUnLoading").ToString.Trim)
                    If Check.Length = 1 Then
                        POD &= dsdata.Tables("oTableLoadingPlan").Rows(i).Item("PortOfUnLoading").ToString & " , "
                    End If
                    ws.Range("O" & DongHientai + i).Value2 = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("Delay")
                    ws.Range("P" & DongHientai + i).Value2 = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("Cancel")
                    DongHientai += 1
                    ws.Range("C3").Value2 = dsdata.Tables("oTableLoadingPlan").Rows(0).Item("PortOfLoading") & " (" & Me.cboVesselVoyNoETD.Text & ")"
                Next
                ws.Range("C4").Value2 = POD
                path = Me.SaveFileDialog1.FileName
                workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            App.Quit()
            App = Nothing
        End Try
    End Sub

   

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                Me.QueryAddContainer("  " & mFilter)
                Me.fraUpdate.Visible = True
                ReFormat()
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdContianerOutboundNotify_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContianerOutboundNotify.CellMouseClick
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Dim TextContainer As String
            TextContainer = GetContainer(Me.dgdContianerOutboundNotify.Item("ContaineroutboundNotifyID", index).Value.ToString)
            If TextContainer = "" Then
                Return
            End If
            Me.dgdContianerOutboundNotify.CurrentCell.ToolTipText = TextContainer

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContianerOutboundNotify_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContianerOutboundNotify.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
    End Sub

    Private Sub dgdDelayInfo_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDelayInfo.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDelayInfo)
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        Try
            Dim index As Integer
            If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Else
                Return
            End If
            gBookingNo = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim
            Dim frm As New frmContainerPackingList
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub chkDelay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelay.CheckedChanged
        Me.dtpDelayDate.Enabled = Me.chkDelay.Checked
    End Sub
    Sub QueryLoadingPlanALLContainer(Optional ByVal Dk As String = "")
        Try
            Dim strQuery As String
            strQuery = "Select Distinct BookingNo,COMPANY,DateOfSupplyEmptyContainer,PLACESUPPLYEMPTYCONTAINER,Container_No,Seal,CTN_SIZE_TYPE, Cold,Ventilation,Tranship,PortOfUnLoading,ContainerOutBoundNotify.PortOfLoading,PackingWay,RETURNPLACE,"
            strQuery &= "Delay= case LOADINGPLANFORVESSEL.delay when 1 then 'DELAY' end ,Cancel=case Cancel when 1 then 'Cancel' end , LOADINGPLANFORVESSEL.ContainerOutboundNotifyID "
            strQuery &= " From (((((LOADINGPLANFORVESSEL LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyid=LOADINGPLANFORVESSEL.ContainerOutboundNotifyid)"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID )"
            strQuery &= "LEFT JOIN Customer On Customer.Customer_ID=ContainerOutboundNotify.Customer_ID)"
            strQuery &= "LEFT JOIN BillOfLading On ContainerOutBoundNotify.ContainerOutBoundNotifyID=BillOfLAding.ContainerOutBoundNotifyID)"
            strQuery &= " LEFT JOIN Shipper On Shipper.Shipper_ID=BillOfLading.Shipper_ID )"
            strQuery &= " Where LOADINGPLANFORVESSEL.Continued=1 and ContainerOutboundNotify.sailingscheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "' " & Dk 'And Delay=0 And Cancel=0"
            'strQuery &= " And Container_No " & Dk & " in ( Select Container_No "
            'strQuery &= " From (((Cargo LEFT JOIN BillOfLading On BillOfLading.BL_ID=Cargo.BL_ID )"
            'strQuery &= " LEFT JOIN ContainerOutboundNotify on ContainerOutboundNotify.ContainerOutboundNotifyid=BillOfLading.ContainerOutboundNotifyid)"
            'strQuery &= " LEFT JOIN Container On Container.CTN_ID=Cargo.CTN_ID )"
            'strQuery &= " Where Cargo.Continued=1 and ContainerOutboundNotify.sailingscheduleID='" & Me.cboVesselVoyNoETD.SelectedValue.ToString & "')"

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            ' Dim dt As New DataTable
            If dsdata.Tables("oTableLoadingPlan").Rows.Count > 0 Then
                dsdata.Tables("oTableLoadingPlan").Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables("oTableLoadingPlan"))
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Sub
    Private Sub smnuLoadingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuLoadingList.Click
        Dim App As Excel.Application

        Try
            App = New Application()
            'App.Visible = True
            Dim Trung As Boolean = False
            Me.SaveFileDialog1.FileName = Strings.Replace(Me.cboVesselVoyNoETD.Text, " - ", "")
            Me.SaveFileDialog1.FileName = Strings.Replace(Me.SaveFileDialog1.FileName, ":", "")
            If Me.SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'QueryLoadingPlan(" Not ")
                'If dsdata.Tables("oTableLoadingPlan").Rows.Count = 0 Then

                'Trung = True
                'MsgBox("Container Đã Trùng khớp")
                'Else
                '    Me.SaveFileDialog1.FileName &= "Delay"
                'End If
                'If Trung = False Then
                '    MsgBox("Container chưa khớp")
                'End If
                'Me.SaveFileDialog1.FileName &= ".xls"
                'Dim workbooks As Workbooks
                Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

                Dim workbooks As Workbooks
                workbooks = App.Workbooks
                Dim workbook As _Workbook

                path = StartupPath & "\LoadingList.xls"

                workbook = workbooks.Open(path)
                Dim sheets As Sheets
                sheets = workbook.Worksheets
                Dim ws As _Worksheet
                Dim DK() As String = {" And LOADINGPLANFORVESSEL.Delay=0 And LOADINGPLANFORVESSEL.Cancel=0 ", " And (LOADINGPLANFORVESSEL.Delay=1 Or LOADINGPLANFORVESSEL.Cancel=1)"}
                For CountSheet As Integer = 1 To 2
                    QueryLoadingPlanALLContainer(DK(CountSheet - 1))
                    ws = sheets.Item(CountSheet)

                    If ws Is Nothing Then
                        App.Quit()
                        Return
                    End If
                    'hien thi excel len 
                    App.Visible = True
                    Dim DongHientai As Integer = 8
                    Dim CotHienTai As Integer
                    Dim POD As String = ""
                    Dim n As Integer = dsdata.Tables("oTableLoadingPlan").Rows.Count
                    For i As Integer = 0 To n - 1
                        ws.Range("A" & DongHientai).Value2 = i + 1
                        CotHienTai = 4
                        For j As Integer = 0 To 7
                            'If Alpha(j + 1) = "C" Then
                            '    Dim BookingNo As String
                            '    Dim ContainerNo As String
                            '    BookingNo = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("BookingNo").ToString.Trim
                            '    ContainerNo = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("Container_no").ToString.Trim
                            '    QueryShipper(BookingNo, ContainerNo)
                            '    ws.Range("C" & DongHientai).Value2 = dsdata.Tables("Shipper").Rows(0).Item(0)
                            'Else
                            ws.Range(Alpha(j + 1) & DongHientai).Value2 = dsdata.Tables("oTableLoadingPlan").Rows(i).Item(CotHienTai)

                            CotHienTai += 1
                            'CotHienTai += 1
                            'End If
                        Next
                        Dim Check() As String
                        Check = Strings.Split(POD, dsdata.Tables("oTableLoadingPlan").Rows(i).Item("PortOfUnLoading").ToString.Trim)
                        If Check.Length = 1 Then
                            POD &= dsdata.Tables("oTableLoadingPlan").Rows(i).Item("PortOfUnLoading").ToString & " , "
                        End If
                        ws.Range("K" & DongHientai + i).Value2 = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("Delay")
                        ws.Range("L" & DongHientai + i).Value2 = dsdata.Tables("oTableLoadingPlan").Rows(i).Item("Cancel")
                        DongHientai += 1
                        ws.Range("C3").Value2 = dsdata.Tables("oTableLoadingPlan").Rows(0).Item("PortOfLoading") & " (" & Me.cboVesselVoyNoETD.Text & ")"
                    Next

                    ws.Range("C4").Value2 = POD

                Next
                path = Me.SaveFileDialog1.FileName
                workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            App.Quit()
            App = Nothing
        End Try
    End Sub

    Private Sub LoadingFormForPortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadingFormForPortToolStripMenuItem.Click
        frmRptLoadingFormForPort.Show()
    End Sub

    Private Sub LoadingFormForShangHaiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadingFormForShangHaiToolStripMenuItem.Click
        frmLoadingFormForShangHai.Show()
    End Sub

    Private Sub ctmFindBookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmFindBookingNo.Click
        Me.grpSearch.BringToFront()
        Me.grpSearch.Visible = True

    End Sub

    Private Sub cmdCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelSearch.Click
        Me.grpSearch.Visible = False
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return
            End If
            FindCombo(Me.txtBookingNoSearch.Text, "BookingNo", Me.dgdContianerOutboundNotify)
            Me.grpSearch.Visible = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub PreViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreViewToolStripMenuItem.Click
        On Error GoTo Err
        Dim index As Integer
        If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If
        gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        VB6.ShowForm(frmRptSupplyEmptyContainer, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
    End Sub


    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Try
            Dim index As Integer
            If Me.fraUpdate.Visible = True Then
                Dim CountColdContainer As Integer = 0
                Me.dgdContianerOutboundNotify.Enabled = False
                If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                    index = Me.dgdContianerOutboundNotify.CurrentRow.Index
                Else
                    Return
                End If

                CountColdContainer += Me.dgdContianerOutboundNotify.Item("Soluong20RF", index).Value
                CountColdContainer += Me.dgdContianerOutboundNotify.Item("Soluong40RF", index).Value
                CountColdContainer += Me.dgdContianerOutboundNotify.Item("Soluong40RH", index).Value
                If CountColdContainer > 0 Then
                    Me.txtCold.Text = Me.dgdContianerOutboundNotify.Item("BookingCold", index).Value.ToString
                    Me.txtVent.Text = Me.dgdContianerOutboundNotify.Item("BookingVent", index).Value.ToString
                Else
                    Me.txtCold.Text = ""
                    Me.txtVent.Text = ""
                End If
            Else
                Me.dgdContianerOutboundNotify.Enabled = True
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        
    End Sub

    Private Sub dtpReturnDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnDate.ValueChanged
        Try
            Me.txtReturnDate.Text = Me.dtpReturnDate.Value.Date
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkNull2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNull2.CheckedChanged
        Try
            Me.txtReturnDate.Enabled = Not Me.chkNull2.Checked

            If Me.chkNull2.Checked = False Then
                Me.txtReturnDate.Text = Me.dtpReturnDate.Text
            Else
                Me.txtReturnDate.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub InputDataLoadingFormForPortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDataLoadingFormForPortToolStripMenuItem.Click
        frmInputDataLoadingFormForPort.ShowDialog()
    End Sub

    Private Sub smnuLoadingCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuLoadingCheck.Click
        LoadingCheck.ShowDialog()
    End Sub
End Class