Public Class frmRealMTContainer


    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select Vessel + ' - '+ VoyNo + ' - ' + replace(Convert(nvarchar,ETD),'12:00AM','') as Data,SailingScheduleID as ID "
            SQL &= " From SailingSchedule LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID "
            SQL &= " Where SailingSchedule.Continued=1 "
            SQL &= " Order By ETD DESC"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.ValueMember = "ID"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmRealMTContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetCountContainerManagerment()
        QueryVessel()
        SetDefaultGrid(Me.dgdBookingContainerAll, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdBookingContainerVessel, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdCountMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub
    Sub GetCountContainerManagerment()
        Try
            Dim SQL As String
            'SQL = " Select EmptyCY,LEFT(CTN_SIZE_TYPE,2), "
            'SQL &= " (select Count(CTN_SIZE_TYPE) from ContainerManagerment Where Left(CTN_SIZE_TYPE,2)='20' ANd continued=1 And SoundContainer=1 ) as Quantity20,"
            'SQL &= " (select Count(CTN_SIZE_TYPE) from ContainerManagerment Where Left(CTN_SIZE_TYPE,2)='40' ANd continued=1 And SoundContainer=1 ) as Quantity40 "
            'SQL &= " from Containermanagerment Where Continued=1 "
            'SQL &= " Group By left(CTN_SIZE_TYPE,2),EmptyCY "
            'If Me.cboVessel.Text.Trim = "" Then
            '    Return False
            'End If
            'SQL = "select  EmptyCY,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='20GP' And Continued=1 And SoundContainer=1) as Quantity20GP,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40GP' And Continued=1 And SoundContainer=1) as Quantity40GP,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40HC' And Continued=1 And SoundContainer=1) as Quantity40HC,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='45HC' And Continued=1 And SoundContainer=1) as Quantity45HC,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='20RF' And Continued=1 And SoundContainer=1) as Quantity20RF,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40RF' And Continued=1 And SoundContainer=1) as Quantity40RF,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40RH' And Continued=1 And SoundContainer=1) as Quantity40RH "
            'SQL &= " from ContainerManagerMent "
            'SQL &= " Where Continued=1  Group By EmptyCY  Order By EmptyCY " 'And EmptyCY='" & Me.cboEmptyContainerPlace.Text.Trim & "'"

            'Me.txtSoLuong20GP.ForeColor = Color.Black
            'Me.txtSoLuong40GP.ForeColor = Color.Black
            'Me.txtSoLuong40HC.ForeColor = Color.Black
            'Me.txtSoLuong45HC.ForeColor = Color.Black
            'Me.txtSoLuong20RF.ForeColor = Color.Black
            'Me.txtSoLuong40RF.ForeColor = Color.Black
            'Me.txtSoLuong40RH.ForeColor = Color.Black

            'thêm 22-11-2007 hiển thị ngày cập nhật cuối cùng của container rỗng
            SQL &= "select Max(UpdateTime) as LastUpdate From ContainerManagerMent Where SoundContainer=1 And Continued=1"
            Dim dtUpdate As New DataTable
            dtUpdate = ReadTable(SQL)
            If dtUpdate.Rows.Count > 0 Then
                Me.lblSoundContainerLastupdate.Text = "Sound Container Last Update : " & dtUpdate.Rows(0).Item(0).ToString
            End If

            SQL = "Select Max(UpdateTime) as LastSupply From LoadingPlanForVessel Where Continued=1"
            Dim dtSupply As New DataTable
            dtSupply = ReadTable(SQL)
            If dtSupply.Rows.Count > 0 Then
                Me.lblContainerLastSupply.Text = "Sound Container Last Supply : " & dtSupply.Rows(0).Item(0).ToString
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dt As New DataTable
            SQL = "Select distinct finalICD from ContainerManagerMent Where Continued=1"
            dt = ReadTable(SQL)
            Dim oTable As New DataTable
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim Cmd As New SqlClient.SqlCommand()
            Dim Adapter As New SqlClient.SqlDataAdapter()
            For i As Integer = 0 To dt.Rows.Count - 1
                SQL = "select  distinct FinalICD ,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20GP' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity20GP,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40GP' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40GP,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40HC' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40HC,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='45HC' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity45HC,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20RF' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity20RF,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40RF' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40RF,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40RH' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40RH "
                'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20OT' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo) as Quantity20OT,"
                'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40OT' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo) as Quantity40OT,"
                'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20FR' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo) as Quantity20FR,"
                'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40FR' And ContainerManagerMent.Continued=1 And Soundcontainer=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo) as Quantity40FR "
                'SQL &= ",(Select Count(CTN_SIZE_TYPE)From ContainerManagerMent Where Continued=1  And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "') as Total "
                SQL &= " from ContainerManagerMent ,ScheduleCheck"
                SQL &= " Where ContainerManagerMent.Continued=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ') " 'And FinalICD='" & Me.cboEmptyContainerPlace.Text.Trim & "'"
                SQL &= " And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date) Order By FinalICD "

                Cmd = New SqlClient.SqlCommand(SQL, Conn)
                Adapter = New SqlClient.SqlDataAdapter(Cmd)
                Adapter.Fill(oTable)
            Next
            'Me.dgdToTalMT.DataSource = oTable.Copy
            Me.dgdCountMNG.DataSource = oTable
            '---cong depot3 va cat lai
            'For i As Integer = 0 To oTable.Rows.Count - 1 'duyệt hết các dòng của BookingContainer
            '    For j As Integer = 0 To oTable.Rows.Count - 1
            '        If oTable.Rows(j).Item("PlaceSupplyEmptyContainer").ToString = dtBookingContainer.Rows(i).Item("EmptyContainerPlace") Then
            '            For Col As Integer = 0 To oTable.Columns.Count - 1 'duyệt hết tất cả các cột củ bookingconatiner
            '                If dtBookingContainer.Columns(Col).ColumnName Like "*" & dtLoadingPlan.Rows(j).Item("CTN_SIZE_TYPE").ToString & "*" Then
            '                    dtBookingContainer.Rows(i).Item(Col) &= " (" & dtLoadingPlan.Rows(j).Item("Quantity").ToString & ")"
            '                End If
            '            Next
            '        End If
            '    Next
            'Next


            '-------------------
            '----toan bo tau
            'Quantity Of Container In Booking
            SQL = "Select  EmptyContainerPlace,"
            SQL &= "convert(nvarchar,Sum(Soluong20GP)) As Cont20GPBook,"
            SQL &= "convert(nvarchar,Sum(Soluong40GP))   As Cont40GPBook,"
            SQL &= " convert(nvarchar,Sum(Soluong40HC))  As Cont40HCBook,"
            SQL &= " convert(nvarchar,Sum(Soluong45HC))As Cont45HCBook,"
            SQL &= " convert(nvarchar,Sum(Soluong20RF))As Cont20RFBook,"
            SQL &= " convert(nvarchar,Sum(Soluong40RF))  As Cont40RFBook,"
            SQL &= " convert(nvarchar,Sum(Soluong40RH)) As Cont40RHBook "
            SQL &= " From ContainerOutboundNotify INNER JOIN SAILINGSCHEDULE ON  ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
            SQL &= " where ContainerOutboundNotify.Continued=1   And SailingSchedule.ETD >= GETDATE() "
            SQL &= "  " ' And (Select Count(*) From [Order] Where ContainerOutboundNotify.BookingNo=[Order].BookingNo And [Order].Continued=1)<>0
            SQL &= " Group By EmptyContainerPlace Order By EmptyContainerPlace "
            ''" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "' Group By EmptyContainerPlace Order By EmptyContainerPlace "
            Dim dtBookingContainerAll As New DataTable
            dtBookingContainerAll = ReadTable(SQL)
            'Me.dgdBookingContainerAll.DataSource = dtBookingContainerAll
            '--------------1 tau 
            'Quantity Of Container In Booking

            'Dim SailingID As String = FindValueID(Me.cboVessel, Me.cboVessel.Text)
            'SQL = "Select  EmptyContainerPlace,"
            'SQL &= "convert(nvarchar,Sum(Soluong20GP)) As Cont20GPBook,"
            'SQL &= "convert(nvarchar,Sum(Soluong40GP))   As Cont40GPBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong40HC))  As Cont40HCBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong45HC))As Cont45HCBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong20RF))As Cont20RFBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong40RF))  As Cont40RFBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong40RH)) As Cont40RHBook "

            'SQL &= " From ContainerOutboundNotify  "
            'SQL &= " where Continued=1  and SailingScheduleid='" & SailingID & " ' Group By EmptyContainerPlace Order By EmptyContainerPlace "
            ''--------------------
            'Dim dtBookingContainer As New DataTable
            'dtBookingContainer = ReadTable(SQL)

            '''''Query Số container đã booking (trong loading plan)
            Dim dtLoadingPlan As DataTable
            SQL = "select PlaceSupplyEmptyContainer,"
            SQL &= " CTN_SIZE_TYPE, count(CTN_SIZE_TYPE) as Quantity "
            SQL &= " from (((LoadingPlanforvessel LEFT JOIN Container On LoadingPlanforvessel.CTN_ID=Container.CTN_ID)"
            SQL &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=LoadingPlanForVessel.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
            SQL &= " where SailingSchedule.ETD >=GetDate() And LoadingPlanForVessel.Continued=1 And ContainerOutboundNotify.Continued=1"
            SQL &= " Group by PlaceSupplyEmptyContainer,CTN_SIZE_TYPE"
            SQL &= " Order by PlaceSupplyEmptyContainer"
            dtLoadingPlan = ReadTable(SQL)
            'Me.dgdContSupply.DataSource = dtLoadingPlan
            For i As Integer = 0 To dtBookingContainerAll.Rows.Count - 1 'duyệt hết các dòng của BookingContainer
                For j As Integer = 0 To dtLoadingPlan.Rows.Count - 1
                    If dtLoadingPlan.Rows(j).Item("PlaceSupplyEmptyContainer").ToString = dtBookingContainerAll.Rows(i).Item("EmptyContainerPlace") Then
                        For Col As Integer = 0 To dtBookingContainerAll.Columns.Count - 1 'duyệt hết tất cả các cột củ bookingconatiner
                            If dtBookingContainerAll.Columns(Col).ColumnName Like "*" & dtLoadingPlan.Rows(j).Item("CTN_SIZE_TYPE").ToString & "*" Then
                                dtBookingContainerAll.Rows(i).Item(Col) &= " (" & dtLoadingPlan.Rows(j).Item("Quantity").ToString & ")"
                            End If
                        Next
                    End If
                Next
            Next
            Me.dgdBookingContainerAll.DataSource = dtBookingContainerAll



            'không trừ cho số container đã booking nữa
            'For i As Integer = 0 To oTable.Rows.Count - 1 'duyệt hết các dòng của BookingContainer
            '    For j As Integer = 0 To dtLoadingPlan.Rows.Count - 1
            '        If dtLoadingPlan.Rows(j).Item("PlaceSupplyEmptyContainer").ToString = oTable.Rows(i).Item("FinalICD") Then
            '            For Col As Integer = 0 To oTable.Columns.Count - 1 'duyệt hết tất cả các cột của ContainerManegerment 
            '                If oTable.Columns(Col).ColumnName Like "*" & dtLoadingPlan.Rows(j).Item("CTN_SIZE_TYPE").ToString & "*" Then
            '                    oTable.Rows(i).Item(Col) -= dtLoadingPlan.Rows(j).Item("Quantity")
            '                End If
            '            Next
            '        End If
            '    Next
            'Next
            'Me.dgdCountMNG.DataSource = oTable






            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdCountMNG.RowCount - 1
                For s = 0 To Me.dgdCountMNG.ColumnCount - 1
                    If Me.dgdCountMNG.Item(s, t).Value.ToString = "0" Then
                        Me.dgdCountMNG.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next

            '---- so 0 thanh mau trang

            For t = 0 To Me.dgdBookingContainerAll.RowCount - 1
                For s = 0 To Me.dgdBookingContainerAll.ColumnCount - 1
                    If Me.dgdBookingContainerAll.Item(s, t).Value.ToString = "0" Then
                        Me.dgdBookingContainerAll.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub GetContainerBooking()
        Try
            Dim SQL As String
            '-------------------
            '----toan bo tau
            'Quantity Of Container In Booking
            SQL = "Select  EmptyContainerPlace,"
            SQL &= "convert(nvarchar,Sum(Soluong20GP)) As Cont20GPBook,"
            SQL &= "convert(nvarchar,Sum(Soluong40GP))   As Cont40GPBook,"
            SQL &= " convert(nvarchar,Sum(Soluong40HC))  As Cont40HCBook,"
            SQL &= " convert(nvarchar,Sum(Soluong45HC))As Cont45HCBook,"
            SQL &= " convert(nvarchar,Sum(Soluong20RF))As Cont20RFBook,"
            SQL &= " convert(nvarchar,Sum(Soluong40RF))  As Cont40RFBook,"
            SQL &= " convert(nvarchar,Sum(Soluong40RH)) As Cont40RHBook "
            SQL &= " From ContainerOutboundNotify INNER JOIN SAILINGSCHEDULE ON  ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
            SQL &= " where ContainerOutboundNotify.Continued=1   and ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'" '"And SailingSchedule.ETD >= GETDATE() "
            SQL &= " Group By EmptyContainerPlace Order By EmptyContainerPlace "
            ''" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "' Group By EmptyContainerPlace Order By EmptyContainerPlace "
            Dim dtBookingContainerAll As New DataTable
            dtBookingContainerAll = ReadTable(SQL)
            'Me.dgdBookingContainerAll.DataSource = dtBookingContainerAll
            '--------------1 tau 
            'Quantity Of Container In Booking

            'Dim SailingID As String = FindValueID(Me.cboVessel, Me.cboVessel.Text)
            'SQL = "Select  EmptyContainerPlace,"
            'SQL &= "convert(nvarchar,Sum(Soluong20GP)) As Cont20GPBook,"
            'SQL &= "convert(nvarchar,Sum(Soluong40GP))   As Cont40GPBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong40HC))  As Cont40HCBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong45HC))As Cont45HCBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong20RF))As Cont20RFBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong40RF))  As Cont40RFBook,"
            'SQL &= " convert(nvarchar,Sum(Soluong40RH)) As Cont40RHBook "

            'SQL &= " From ContainerOutboundNotify  "
            'SQL &= " where Continued=1  and SailingScheduleid='" & SailingID & " ' Group By EmptyContainerPlace Order By EmptyContainerPlace "
            ''--------------------
            'Dim dtBookingContainer As New DataTable
            'dtBookingContainer = ReadTable(SQL)

            '''''Query Số container đã booking (trong loading plan)
            Dim dtLoadingPlan As DataTable
            SQL = "select PlaceSupplyEmptyContainer,"
            SQL &= " CTN_SIZE_TYPE, count(CTN_SIZE_TYPE) as Quantity "
            SQL &= " from (((LoadingPlanforvessel LEFT JOIN Container On LoadingPlanforvessel.CTN_ID=Container.CTN_ID)"
            SQL &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=LoadingPlanForVessel.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
            SQL &= " where LoadingPlanForVessel.Continued=1 And ContainerOutboundNotify.Continued=1 and ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'" '"'SailingSchedule.ETD >=GetDate() And 
            SQL &= " Group by PlaceSupplyEmptyContainer,CTN_SIZE_TYPE"
            SQL &= " Order by PlaceSupplyEmptyContainer"
            dtLoadingPlan = ReadTable(SQL)
            'Me.dgdContSupply.DataSource = dtLoadingPlan
            For i As Integer = 0 To dtBookingContainerAll.Rows.Count - 1 'duyệt hết các dòng của BookingContainer
                For j As Integer = 0 To dtLoadingPlan.Rows.Count - 1
                    If dtLoadingPlan.Rows(j).Item("PlaceSupplyEmptyContainer").ToString = dtBookingContainerAll.Rows(i).Item("EmptyContainerPlace") Then
                        For Col As Integer = 0 To dtBookingContainerAll.Columns.Count - 1 'duyệt hết tất cả các cột củ bookingconatiner
                            If dtBookingContainerAll.Columns(Col).ColumnName Like "*" & dtLoadingPlan.Rows(j).Item("CTN_SIZE_TYPE").ToString & "*" Then
                                dtBookingContainerAll.Rows(i).Item(Col) &= " (" & dtLoadingPlan.Rows(j).Item("Quantity").ToString & ")"
                            End If
                        Next
                    End If
                Next
            Next
            Me.dgdBookingContainerVessel.DataSource = dtBookingContainerAll


            'For i As Integer = 0 To oTable.Rows.Count - 1 'duyệt hết các dòng của BookingContainer
            '    For j As Integer = 0 To dtLoadingPlan.Rows.Count - 1
            '        If dtLoadingPlan.Rows(j).Item("PlaceSupplyEmptyContainer").ToString = oTable.Rows(i).Item("FinalICD") Then
            '            For Col As Integer = 0 To oTable.Columns.Count - 1 'duyệt hết tất cả các cột của ContainerManegerment 
            '                If oTable.Columns(Col).ColumnName Like "*" & dtLoadingPlan.Rows(j).Item("CTN_SIZE_TYPE").ToString & "*" Then
            '                    oTable.Rows(i).Item(Col) -= dtLoadingPlan.Rows(j).Item("Quantity")
            '                End If
            '            Next
            '        End If
            '    Next
            'Next
            'Me.dgdCountMNG.DataSource = oTable


            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdBookingContainerVessel.RowCount - 1
                For s = 0 To Me.dgdBookingContainerVessel.ColumnCount - 1
                    If Me.dgdBookingContainerVessel.Item(s, t).Value.ToString = "0" Then
                        Me.dgdBookingContainerVessel.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        GetContainerBooking()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdBookingContainerVessel.RowCount > 0 Then
                'SetMenu(False)
                ExportExecel(Me.dgdBookingContainerVessel, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdCountMNG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCountMNG.CellContentClick

    End Sub

    Private Sub dgdCountMNG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdCountMNG.Click
        Dim t, s As Integer
        For t = 0 To Me.dgdCountMNG.RowCount - 1
            For s = 0 To Me.dgdCountMNG.ColumnCount - 1
                If Me.dgdCountMNG.Item(s, t).Value.ToString = "0" Then
                    Me.dgdCountMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub dgdBookingContainerAll_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBookingContainerAll.CellContentClick
        Dim t, s As Integer
        For t = 0 To Me.dgdBookingContainerAll.RowCount - 1
            For s = 0 To Me.dgdBookingContainerAll.ColumnCount - 1
                If Me.dgdBookingContainerAll.Item(s, t).Value.ToString = "0" Then
                    Me.dgdBookingContainerAll.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub dgdBookingContainerVessel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBookingContainerVessel.CellContentClick

    End Sub

    Private Sub dgdBookingContainerVessel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdBookingContainerVessel.Click
        Dim t, s As Integer
        For t = 0 To Me.dgdBookingContainerVessel.RowCount - 1
            For s = 0 To Me.dgdBookingContainerVessel.ColumnCount - 1
                If Me.dgdBookingContainerVessel.Item(s, t).Value.ToString = "0" Then
                    Me.dgdBookingContainerVessel.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub cmdrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefresh.Click
        GetCountContainerManagerment()
    End Sub
End Class