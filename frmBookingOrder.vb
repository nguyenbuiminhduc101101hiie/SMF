Public Class frmBookingOrder

    Dim mFilter As String = ""
    Dim oTableBooking As New DataTable
    Dim SelectedIndex As Integer
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
    Sub QueryContainerOutboundNotify(Optional ByVal argCriteria = "")
        Try
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
            strQuery = "SELECT ContainerOutBoundNotifyId,BookingNo,ServiceContract,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,Representative,ContainerOutBoundNotify.Commondity ,ServiceFeeder,PortOfUnLoading, Destination, mak.Market_ID,mak.Market,TruckCompany,ReceiptContainer, Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, SailingSchedule.ETD as ETD,Tranship,PortOfLoading,MotherSailingSchedule.MotherSailingScheduleID, "
            strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  "
            strQuery = strQuery + " OceanVessel.Vessel as OceanVessel,MotherSailingSchedule.MotherVesselNo as OceanVessel_VoyNo,MotherSailingSchedule.OceanETD as OceanETD, SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace, PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify.Remarks as Remarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
            strQuery = strQuery + " BookingDate,BookingPerson,"
            strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,lockorder, "
            strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime   "

            strQuery = strQuery + " From (((((((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
            strQuery = strQuery + " left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
            strQuery = strQuery + "left JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) " & _
                                  " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                                  " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
                                  " LEFT JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=ContainerOutboundNotify.MotherSailingScheduleID) " & _
                                  " LEFT JOIN Vessel as OceanVessel On MotherSailingSchedule.MotherVesselID=OceanVessel.Vessel_ID) "

            strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 and BookingNo not in (select bookingno from CONTAINEROUTBOUNDNOTIFY where delay=1 and continued=0 )"
            If argCriteria <> "" Then
                strQuery = strQuery + argCriteria
            End If
            strQuery &= "Order By BookingNo"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Con)
            If oTableBooking.Rows.Count > 0 Then
                oTableBooking.Rows.Clear()
            End If
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Adapter.Fill(oTableBooking)
            InsertAutoNumberToGrid(Me.dgdSplitContainer)
        Catch ex As Exception

        End Try
    End Sub

    Sub ShowfraSplit()
        Try
            'Dim index As Integer
            'index = Me.lbBookingNo.SelectedIndex
            'If otablebooking.rows(index).RowCount > 0 Then
            '    index = otablebooking.rows(index).CurrentRow.Index
            'Else
            '    Exit Sub
            'End If
            If oTableBooking.Rows.Count = 0 Then
                Return
            End If

            Me.txtRemarksBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Remarks").ToString
            Me.txtNguoiDaiDienNhanConatiner.Text = oTableBooking.Rows(SelectedIndex).Item("ReceiptContainer").ToString
            'Me.txtCMNDSplit.Text = otablebooking.rows(index).Item("CMND", index).Value.ToString()
            Me.txtBookingCompany.Text = oTableBooking.Rows(SelectedIndex).Item("Company").ToString()
            Me.txtCompanyOrder.Text = Me.txtBookingCompany.Text
            Me.txtBookingReceiptContainer.Text = oTableBooking.Rows(SelectedIndex).Item("ReceiptContainer").ToString()
            Me.txtNguoiDaiDienNhanConatiner.Text = Me.txtBookingReceiptContainer.Text
            Me.txtSupplydepotBooking.Text = oTableBooking.Rows(SelectedIndex).Item("EmptyContainerPlace").ToString()

            Me.txt20GPBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong20GP").ToString()
            Me.txt40GPBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong40GP").ToString()
            Me.txt20RFBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong20RF").ToString()
            Me.txt40RFBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong40RF").ToString()
            Me.txt40HCBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong40HC").ToString()
            Me.txt45HCBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong45HC").ToString()
            Me.txt40RHBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong40RH").ToString()
            Me.txt20OTBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong20OT").ToString()

            Me.txt40OTBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong40OT").ToString()

            Me.txt20FRBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong20FR").ToString()
            Me.txt40FRBooking.Text = oTableBooking.Rows(SelectedIndex).Item("Soluong40FR").ToString()

            '------------------- lay booking dua sang order
            Me.cboSupplyDepotOrder.Text = Me.txtSupplydepotBooking.Text
            Dim Place As String = oTableBooking.Rows(SelectedIndex).Item("SupplyOrderPlace").ToString().Trim
            If (UCase(gDepartment) = "BOOKING" And Place = "OFFICE") Or (UCase(gDepartment) = "TERMINAL" And Place = "TERMINAL") Or (UCase(gDepartment) = "MANAGEMENT") Then
                Me.txtQuanTity20gp.Enabled = False
                Me.txt20GP.Enabled = False

                Me.txtQuanTity40GP.Enabled = False
                Me.TXT40GP.Enabled = False

                Me.txtQuanTity40HC.Enabled = False
                Me.txt40HC.Enabled = False

                Me.txtQuanTity45HC.Enabled = False
                Me.txt45HC.Enabled = False

                Me.txtQuanTity20RF.Enabled = False
                Me.txt20RF.Enabled = False

                Me.txtQuanTity40RF.Enabled = False
                Me.txt40RF.Enabled = False

                Me.txtQuanTity40RH.Enabled = False
                Me.txt40RH.Enabled = False

                Me.txtQuanTity20OT.Enabled = False
                Me.txt20OT.Enabled = False

                Me.txtQuanTity40OT.Enabled = False
                Me.txt40OT.Enabled = False

                Me.txtQuanTity20FR.Enabled = False
                Me.TXT20FR.Enabled = False

                Me.txtQuanTity40FR.Enabled = False
                Me.TXT40FR.Enabled = False

                Me.txtMainBookingNo.Text = oTableBooking.Rows(SelectedIndex).Item("BookingNo").ToString.Trim
                Me.txtSubBookingNo.Text = Me.txtMainBookingNo.Text
                gBookingID = oTableBooking.Rows(SelectedIndex).Item("ContainerOutBoundNotifyId").ToString.Trim

                Dim strSQL As String
                strSQL = "select ReceiptContainer, CMND, "
                strSQL &= " GP20=CASE  WHEN SoLuong20GP > 0 THEN '20GP' END,"
                strSQL &= " GP40= CASE WHEN SoLuong40GP > 0 THEN '40GP' END,"
                strSQL &= " HC40=CASE  WHEN SoLuong40HC > 0 THEN '40HC' END,"
                strSQL &= " HC45= CASE WHEN SoLuong45HC > 0 THEN '45HC' END,"
                strSQL &= " RF20= CASE WHEN SoLuong20RF > 0 THEN '20RF' END,"
                strSQL &= " RF40=CASE  WHEN SoLuong40RF > 0 THEN '40RF' END,"
                strSQL &= " RH40= CASE WHEN SoLuong40RH > 0 THEN '40RH' END,"
                strSQL &= " OT20= CASE WHEN SoLuong20OT > 0 THEN '20OT' END,"
                strSQL &= " OT40= CASE WHEN SoLuong40OT > 0 THEN '40OT' END,"

                strSQL &= " FR20= CASE WHEN SoLuong20FR > 0 THEN '20FR' END,"
                strSQL &= " FR40= CASE WHEN SoLuong40FR > 0 THEN '40FR' END,"

                strSQL &= " SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong45HC,SoLuong20RF,SoLuong40RF,SoLuong40RH, SoLuong20OT,SoLuong40OT,SoLuong20FR,SoLuong40FR "
                strSQL &= " from ContainerOutboundNotify "
                strSQL &= " Where BookingNo ='" & Me.txtMainBookingNo.Text & "' And Continued=1"
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
                Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
                Dim dt As New DataTable
                Adapter.Fill(dt)
                If dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("SoLuong20GP") > 0 Then
                        Me.txtQuanTity20gp.Enabled = True
                        Me.txt20GP.Enabled = True
                        Me.txtQuanTity20gp.Text = dt.Rows(0).Item("SoLuong20GP")
                    End If

                    If dt.Rows(0).Item("SoLuong40GP") > 0 Then
                        Me.txtQuanTity40GP.Enabled = True
                        Me.TXT40GP.Enabled = True
                        Me.txtQuanTity40GP.Text = dt.Rows(0).Item("SoLuong40GP")
                    End If

                    If dt.Rows(0).Item("SoLuong40HC") > 0 Then
                        Me.txtQuanTity40HC.Enabled = True
                        Me.txt40HC.Enabled = True
                        Me.txtQuanTity40HC.Text = dt.Rows(0).Item("SoLuong40HC")
                    End If

                    If dt.Rows(0).Item("SoLuong45HC") > 0 Then
                        Me.txtQuanTity45HC.Enabled = True
                        Me.txt45HC.Enabled = True
                        Me.txtQuanTity45HC.Text = dt.Rows(0).Item("SoLuong45HC")
                    End If

                    If dt.Rows(0).Item("SoLuong20RF") > 0 Then
                        Me.txtQuanTity20RF.Enabled = True
                        Me.txt20RF.Enabled = True
                        Me.txtQuanTity20RF.Text = dt.Rows(0).Item("SoLuong20RF")
                    End If

                    If dt.Rows(0).Item("SoLuong40RF") > 0 Then
                        Me.txtQuanTity40RF.Enabled = True
                        Me.txt40RF.Enabled = True
                        Me.txtQuanTity40RF.Text = dt.Rows(0).Item("SoLuong40RF")
                    End If
                    If dt.Rows(0).Item("SoLuong40RH") > 0 Then
                        Me.txtQuanTity40RH.Enabled = True
                        Me.txt40RH.Enabled = True
                        Me.txtQuanTity40RH.Text = dt.Rows(0).Item("SoLuong40RH")
                    End If

                    If dt.Rows(0).Item("SoLuong20OT") > 0 Then
                        Me.txtQuanTity20OT.Enabled = True
                        Me.txt20OT.Enabled = True
                        Me.txtQuanTity20OT.Text = dt.Rows(0).Item("SoLuong20OT")
                    End If

                    If dt.Rows(0).Item("SoLuong40OT") > 0 Then
                        Me.txtQuanTity40OT.Enabled = True
                        Me.txt40OT.Enabled = True
                        Me.txtQuanTity40OT.Text = dt.Rows(0).Item("SoLuong40OT")
                    End If

                    If dt.Rows(0).Item("SoLuong20FR") > 0 Then
                        Me.txtQuanTity20FR.Enabled = True
                        Me.TXT20FR.Enabled = True
                        Me.txtQuanTity20FR.Text = dt.Rows(0).Item("SoLuong20FR")
                    End If


                    If dt.Rows(0).Item("SoLuong40FR") > 0 Then
                        Me.txtQuanTity40FR.Enabled = True
                        Me.TXT40FR.Enabled = True
                        Me.txtQuanTity40FR.Text = dt.Rows(0).Item("SoLuong40FR")
                    End If


                    Me.txtNguoiDaiDienNhanConatiner.Text = dt.Rows(0).Item("ReceiptContainer").ToString
                    Me.txtCMNDSplit.Text = dt.Rows(0).Item("CMND").ToString
                End If
                ' hien thi thong tin nguoi nhan cont

                'Me.fraReportSplitBooking.Visible = True
                'Me.fraReportSplitBooking.BringToFront()
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                DisplayMessage(True, "The Supply Order is supplied by """ & Place & """")
                Me.Close()
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function checkorder() As String
        Try
            Dim strQuery As String = ""
            Dim msg As String = ""
            Dim CountSplit As Integer 'số container đã cấp
            Dim TempCon As Integer = 0
            strQuery = "select  OrderDate,Daidien,CMND, sum(SoLuong45HC) as SoLuong45HC,  sum(SoLuong20RF) as  SoLuong20RF,"
            strQuery &= "sum(SoLuong40RF) as SoLuong40RF,  sum(SoLuong40RF) as SoLuong40RH,"
            strQuery &= "sum(SoLuong20GP) as SoLuong40RF,   sum(SoLuong40GP) as  SoLuong40GP, sum(SoLuong40HC) as SoLuong40HC , sum(SoLuong20OT) as SoLuong20OT, sum(SoLuong40OT) as SoLuong40OT, sum(SoLuong20FR) as SoLuong20FR, sum(SoLuong40FR) as SoLuong40FR "
            strQuery &= " From [Order] "
            strQuery &= " Where BookingNo='" & Me.txtMainBookingNo.Text.Trim & "' Group by BookingNo,OrderDate,Daidien,CMND "
            Dim TYPE() As String = {"SoLuong45HC", "SoLuong20RF", "SoLuong40RF", "SoLuong20GP", "SoLuong40GP", "SoLuong40HC", "SoLuong40RH", "SoLuong20OT", "SoLuong40OT", "SoLuong20FR", "SoLuong40FR"}
            'Dim Col() As String = {"HC45", "RF20", "RF40", "GP20", "GP40", "HC40", "RH40"}
            Dim text() As TextBox = {Me.txtQuanTity45HC, Me.txtQuanTity20RF, Me.txtQuanTity40RF, Me.txtQuanTity20gp, Me.txtQuanTity40GP, Me.txtQuanTity40HC, Me.txtQuanTity40RH, Me.txtQuanTity20OT, Me.txtQuanTity40OT, Me.txtQuanTity20FR, Me.txtQuanTity40FR}

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count > 0 Then
                msg = "Số Booking : " + Me.txtMainBookingNo.Text + " đã được cấp lệnh vào ngày " + dt.Rows(0).Item("Orderdate").ToString
            End If
            For i As Integer = 0 To TYPE.Length - 1
                If dt.Rows.Count > 0 Then
                    TempCon = dt.Rows(0).Item(TYPE(i))
                End If
                CountSplit = TempCon + CInt(IIf(text(i).Text <> "", text(i).Text, 0))
            Next
            If dt.Rows.Count > 0 Then
                msg = msg + " với số lượng : " + CStr(CountSplit)
            End If
            Return msg

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function CheckContainerCount() As Boolean
        Try
            Dim strQuery As String
            strQuery = "select   sum(SoLuong45HC) as SoLuong45HC,  sum(SoLuong20RF) as  SoLuong20RF,"
            strQuery &= "sum(SoLuong40RF) as SoLuong40RF,"
            strQuery &= "sum(SoLuong20GP) as SoLuong20GP,   sum(SoLuong40GP) as  SoLuong40GP, sum(SoLuong40HC) as SoLuong40HC ,  sum(SoLuong40RH) as SoLuong40RH, sum(SoLuong20OT) as SoLuong20OT, sum(SoLuong40OT) as SoLuong40OT, sum(SoLuong20FR) as SoLuong20FR, sum(SoLuong40FR) as SoLuong40FR "
            strQuery &= " From [Order] "
            strQuery &= " Where BookingNo='" & Me.txtMainBookingNo.Text.Trim & "' and Continued=1 Group by BookingNo"
            Dim TYPE() As String = {"SoLuong45HC", "SoLuong20RF", "SoLuong40RF", "SoLuong20GP", "SoLuong40GP", "SoLuong40HC", "SoLuong40RH", "SoLuong20OT", "SoLuong40OT", "SoLuong20FR", "SoLuong40FR"}
            'Dim Col() As String = {"Soluong45", "Soluong20", "Soluong40", "GP20", "GP40", "HC40", "RH40"}
            Dim text() As TextBox = {Me.txtQuanTity45HC, Me.txtQuanTity20RF, Me.txtQuanTity40RF, Me.txtQuanTity20gp, Me.txtQuanTity40GP, Me.txtQuanTity40HC, Me.txtQuanTity40RH, Me.txtQuanTity20OT, Me.txtQuanTity40OT, Me.txtQuanTity20FR, Me.txtQuanTity40FR}
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            adapter.Fill(dt)
            'If checkorder() <> "" Then
            '    DisplayMessage(True, checkorder())
            'End If
            For i As Integer = 0 To TYPE.Length - 1
                Dim CountSplit As Integer 'số container đã cấp
                Dim CountCon As Integer 'số container của booking
                Dim TempCon As Integer = 0
                If dt.Rows.Count > 0 Then
                    TempCon = dt.Rows(0).Item(TYPE(i))
                End If
                Dim index As Integer = Me.lbBookingNo.SelectedIndex
                CountSplit = TempCon + CInt(IIf(text(i).Text <> "", text(i).Text, 0))
                CountCon = oTableBooking.Rows(index).Item(TYPE(i))
                If CountSplit > CountCon Then
                    MsgBox("The Supply Container Is more than Book Container")
                    Return False
                End If
            Next
            'End If
            Return True

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function SaveSplitData() As Boolean
        Try
            If CheckContainerCount() = False Then
                Return False
            End If
            'lưu vào CSDL
            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            strQuery = "Select * from [Order] where OrderNo='" & Me.txtSubBookingNo.Text.Trim & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                rs.Close()
                DisplayMessage(True, "This Order number has been Supplied ,Please check Again")
                Return False
            End If
            With rs
                .AddNew()
                .Fields("BookingNo").Value = Me.txtMainBookingNo.Text
                .Fields("OrderNo").Value = Me.txtSubBookingNo.Text
                .Fields("DaiDien").Value = Me.txtNguoiDaiDienNhanConatiner.Text
                .Fields("Tel").Value = Me.txttellenh.Text
                .Fields("CMND").Value = Me.txtCMNDSplit.Text
                .Fields("Remarks").Value = Me.txtRemarksSplit.Text
                .Fields("SupplyDepot").Value = Me.cboSupplyDepotOrder.Text
                .Fields("SoLuong20GP").Value = IIf(Me.txtQuanTity20gp.Text <> "", Me.txtQuanTity20gp.Text, 0)
                .Fields("SoLuong40GP").Value = IIf(Me.txtQuanTity40GP.Text <> "", Me.txtQuanTity40GP.Text, 0)
                .Fields("SoLuong20RF").Value = IIf(Me.txtQuanTity20RF.Text <> "", Me.txtQuanTity20RF.Text, 0)
                .Fields("SoLuong40RF").Value = IIf(Me.txtQuanTity40RF.Text <> "", Me.txtQuanTity40RF.Text, 0)
                .Fields("SoLuong40HC").Value = IIf(Me.txtQuanTity40HC.Text <> "", Me.txtQuanTity40HC.Text, 0)
                .Fields("SoLuong45HC").Value = IIf(Me.txtQuanTity45HC.Text <> "", Me.txtQuanTity45HC.Text, 0)
                .Fields("SoLuong40RH").Value = IIf(Me.txtQuanTity40RH.Text <> "", Me.txtQuanTity40RH.Text, 0)
                .Fields("SoLuong20OT").Value = IIf(Me.txtQuanTity20OT.Text <> "", Me.txtQuanTity20OT.Text, 0)


                .Fields("SoLuong40OT").Value = IIf(Me.txtQuanTity40OT.Text <> "", Me.txtQuanTity40OT.Text, 0)

                .Fields("SoLuong20FR").Value = IIf(Me.txtQuanTity20FR.Text <> "", Me.txtQuanTity20FR.Text, 0)

                .Fields("SoLuong40FR").Value = IIf(Me.txtQuanTity40FR.Text <> "", Me.txtQuanTity40FR.Text, 0)




                .Fields("OrderDate").Value = Me.dtpOrderDate.Value.Date
                .Fields("ExpireDate").Value = Me.dtpExpireate.Value.Date
                .Fields("Company").Value = Me.txtCompanyOrder.Text.Trim
                If Me.chkGetContainer.Checked = True Then
                    .Fields("GetContainerDate").Value = Me.dtpGetContainerDate.Value.Date
                    .Fields("GetContainer").Value = 1
                Else
                    .Fields("GetContainer").Value = 0
                End If

                .Update()
            End With
            rs.Close()
            QuerySplitOrder()
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function SaveSplitUpdateData(ByVal index As Integer) As Boolean
        Try
            'If CheckContainerCount() = False Then
            '    Return False
            'End If
            If checkDate() = False Then
                DisplayMessage(True, "Date is Invalid,Please check again!")
                Return False
            End If
            If index < 0 Then
                Return False
            End If
            Dim OrderNO As String = Me.dgdSplitContainer.Item("OrderNoOrder", index).Value.ToString.Trim
            'lưu vào CSDL
            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            strQuery = "Select * from [Order] where OrderNo='" & OrderNO & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                Return False
            End If
            With rs
                '.AddNew()
                .Fields("BookingNo").Value = Me.txtMainBookingNo.Text
                .Fields("OrderNo").Value = Me.txtSubBookingNo.Text
                .Fields("DaiDien").Value = Me.txtNguoiDaiDienNhanConatiner.Text
                .Fields("Tel").Value = Me.txttellenh.Text
                .Fields("CMND").Value = Me.txtCMNDSplit.Text
                .Fields("Remarks").Value = Me.txtRemarksSplit.Text
                .Fields("SoLuong20GP").Value = IIf(Me.txtQuanTity20gp.Text <> "", Me.txtQuanTity20gp.Text, 0)
                .Fields("SoLuong40GP").Value = IIf(Me.txtQuanTity40GP.Text <> "", Me.txtQuanTity40GP.Text, 0)
                .Fields("SoLuong20RF").Value = IIf(Me.txtQuanTity20RF.Text <> "", Me.txtQuanTity20RF.Text, 0)
                .Fields("SoLuong40RF").Value = IIf(Me.txtQuanTity40RF.Text <> "", Me.txtQuanTity40RF.Text, 0)
                .Fields("SoLuong40HC").Value = IIf(Me.txtQuanTity40HC.Text <> "", Me.txtQuanTity40HC.Text, 0)
                .Fields("SoLuong45HC").Value = IIf(Me.txtQuanTity45HC.Text <> "", Me.txtQuanTity45HC.Text, 0)
                .Fields("SoLuong40RH").Value = IIf(Me.txtQuanTity40RH.Text <> "", Me.txtQuanTity40RH.Text, 0)

                .Fields("SoLuong20OT").Value = IIf(Me.txtQuanTity20OT.Text <> "", Me.txtQuanTity20OT.Text, 0)

                .Fields("SoLuong40OT").Value = IIf(Me.txtQuanTity40OT.Text <> "", Me.txtQuanTity40OT.Text, 0)
                .Fields("SoLuong20FR").Value = IIf(Me.txtQuanTity20FR.Text <> "", Me.txtQuanTity20FR.Text, 0)
                .Fields("SoLuong40FR").Value = IIf(Me.txtQuanTity40FR.Text <> "", Me.txtQuanTity40FR.Text, 0)


                .Fields("OrderDate").Value = Me.dtpOrderDate.Value.Date
                .Fields("ExpireDate").Value = Me.dtpExpireate.Value.Date
                .Fields("Company").Value = Me.txtCompanyOrder.Text.Trim
                If Me.chkGetContainer.Checked = True Then
                    .Fields("GetContainerDate").Value = Me.dtpGetContainerDate.Value.Date
                    .Fields("GetContainer").Value = 1
                Else
                    .Fields("GetContainer").Value = 0
                End If

                .Update()
            End With
            rs.Close()
            QuerySplitOrder()
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Public Function checkDate() As Boolean

        Dim CountDay As Integer 'số ngày Dc phép cấp lệnh trứơc closingtime
        CountDay = CDate(oTableBooking.Rows(Me.lbBookingNo.SelectedIndex).Item("dateClosing2").ToString.Trim).Date.ToOADate - Me.dtpOrderDate.Value.Date.ToOADate
        If CountDay > CDbl(Me.txtValidOrder.Text) + CDbl(Me.txtTerminalValidOrder.Text) Then 'ngày closing time- ngay hiện tại lớn hơn số ngày dc phép cấp lệnh thì ko cho cấp
            Return False
        End If
        Return True
    End Function
    Private Sub cmdOkSplitBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkSplitBooking.Click
        Try
            If Me.txtQuanTity20gp.Text = "" And Me.txtQuanTity20RF.Text = "" And Me.txtQuanTity40GP.Text = "" And Me.txtQuanTity40HC.Text = "" And Me.txtQuanTity40RF.Text = "" And Me.txtQuanTity40RH.Text = "" And Me.txtQuanTity45HC.Text = "" And Me.txtQuanTity20OT.Text = "" And Me.txtQuanTity40OT.Text = "" And Me.txtQuanTity20FR.Text = "" And Me.txtQuanTity40FR.Text = "" Then
                DisplayMessage(True, "Please check again, Quantity is invalid!")
                Return
            End If
            If Me.txtCMNDSplit.Text = "" Or Me.txttellenh.Text = "" Then
                DisplayMessage(True, "Please check again, the ID Card or Telephone is invalid!")
                Return
            End If
            If checkDate() = False Then
                DisplayMessage(True, "Please check again Expire Date is Invalid!")
                Return
            End If
            If Me.chkSave.Checked = False Then ' nếu Nút "Don't Save" không Check
                If SaveSplitData() = False Then
                    DisplayMessage(True, "If you want Print anyway Please check (Don't Save)")
                    Return
                End If
            End If
            gBookingNo = Me.txtSubBookingNo.Text
            If gBookingNo = "" Then
                If (MsgBox("Chưa Có Sub Booking No Có muốn nhập Sub Booking No không ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                    Return
                End If
            End If
            frmRptSubBooking.data = False
            frmRptSubBooking.ShowDialog()
            'Me.fraReportSplitBooking.Visible = False
            'Me.txtQuanTity20gp.Text = ""
            'Me.txtQuanTity20RF.Text = ""
            'Me.txtQuanTity40GP.Text = ""
            'Me.txtQuanTity40HC.Text = ""
            'Me.txtQuanTity40RF.Text = ""
            'Me.txtQuanTity40RH.Text = ""
            'Me.txtQuanTity45HC.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub cmdOkData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkData.Click

    '    Try
    '        If Me.txtCMNDSplit.Text = "" Or Me.txttellenh.Text = "" Then
    '            DisplayMessage(True, "Please check again, the ID Card or Telephone is invalid!")
    '            Return
    '        End If
    '        If checkDate() = False Then
    '            DisplayMessage(True, "Please check again Expire Date is Invalid!")
    '            Return
    '        End If
    '        If Me.chkSave.Checked = False Then ' nếu Nút "Don't Save" không Check
    '            If SaveSplitData() = False Then
    '                DisplayMessage(True, "If you want Print anyway Please check (Don't Save)")
    '                Return
    '            End If
    '        End If
    '        gBookingNo = Me.txtSubBookingNo.Text
    '        If gBookingNo = "" Then
    '            If (MsgBox("Chưa Có Sub Booking No. .Bạn có muốn nhập Sub Booking No. không ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
    '                Return
    '            End If
    '        End If
    '        frmRptSubBooking.data = True
    '        frmRptSubBooking.ShowDialog()
    '        'Me.fraReportSplitBooking.Visible = False
    '        Me.txtQuanTity20gp.Text = ""
    '        Me.txtQuanTity20RF.Text = ""
    '        Me.txtQuanTity40GP.Text = ""
    '        Me.txtQuanTity40HC.Text = ""
    '        Me.txtQuanTity40RF.Text = ""
    '        Me.txtQuanTity40RH.Text = ""
    '        Me.txtQuanTity45HC.Text = ""
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Sub ReSetContainer()
        Try
            Me.txtQuanTity20gp.Text = ""
            Me.txtQuanTity20RF.Text = ""
            Me.txtQuanTity40GP.Text = ""
            Me.txtQuanTity40HC.Text = ""
            Me.txtQuanTity40RF.Text = ""
            Me.txtQuanTity40RH.Text = ""
            Me.txtQuanTity45HC.Text = ""
            Me.txtQuanTity20OT.Text = ""
            Me.txtQuanTity40OT.Text = ""
            Me.txtQuanTity20FR.Text = ""
            Me.txtQuanTity40FR.Text = ""


            Me.txt20GPBooking.Text = ""
            Me.txt40GPBooking.Text = ""
            Me.txt20RFBooking.Text = ""
            Me.txt40RFBooking.Text = ""
            Me.txt40HCBooking.Text = ""
            Me.txt45HCBooking.Text = ""
            Me.txt40RHBooking.Text = ""
            Me.txt20OTBooking.Text = ""
            Me.txt40OTBooking.Text = ""
            Me.txt20FRBooking.Text = ""

            Me.txt40FRBooking.Text = ""




        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdCancelSplitBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelSplitBooking.Click
        'Me.fraReportSplitBooking.Visible = False
        ReSetContainer()

        Me.Close()
    End Sub

    Sub QuerySplitOrder()
        Try
            'Dim Index As Integer = Me.lbBookingNo.SelectedIndex
            If oTableBooking.Rows.Count = 0 Then
                Return
            End If
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strQuery As String
            strQuery = " select BookingNo,OrderNo, COMPANY,DaiDien,tel,CMND,OrderDate,SupplyDepot,GetContainer,GetContainerDate,ExpireDate,Soluong20GP,Soluong40GP,Soluong20RF,Soluong40RF,Soluong40HC,Soluong45HC,Soluong40RH,Soluong20OT,Soluong40OT,Soluong20FR,Soluong40FR, "
            strQuery &= " Remarks,userid, updatetime From [Order] "
            strQuery &= " where BookingNo='" & oTableBooking.Rows(SelectedIndex).Item("BookingNo").ToString.Trim & "' And Continued=1 " '& mFilter
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdSplitContainer.DataSource = dt
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdSplitContainer.RowCount - 1
                For s = 0 To Me.dgdSplitContainer.ColumnCount - 1
                    If Me.dgdSplitContainer.Item(s, t).Value.ToString = "0" Then
                        Me.dgdSplitContainer.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    'Private Sub fraReportSplitBooking_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.fraReportSplitBooking.Visible = True Then
    '            QuerySplitOrder()
    '        End If
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try

    'End Sub

    Private Sub dgdSplitContainer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSplitContainer.CellClick
        Try
            Dim index As Integer
            If Me.dgdSplitContainer.RowCount = 0 Or IsNothing(Me.dgdSplitContainer.CurrentRow) Then
                Return
            End If
            index = Me.dgdSplitContainer.CurrentRow.Index
            Me.chkSave.Checked = True
            Me.cboSupplyDepotOrder.Text = Me.dgdSplitContainer.Item("Supplydepot", index).Value.ToString
            Me.txtCompanyOrder.Text = Me.dgdSplitContainer.Item("CompanyOrder", index).Value.ToString
            Me.txtCMNDSplit.Text = Me.dgdSplitContainer.Item("CMNDORDER", index).Value.ToString
            Me.txtNguoiDaiDienNhanConatiner.Text = Me.dgdSplitContainer.Item("Daidien", index).Value.ToString
            Me.txttellenh.Text = Me.dgdSplitContainer.Item("tel", index).Value.ToString
            Me.txtSubBookingNo.Text = Me.dgdSplitContainer.Item("OrderNoOrder", index).Value.ToString
            Me.txtRemarksSplit.Text = Me.dgdSplitContainer.Item("RemarksOrder", index).Value.ToString
            Me.dtpOrderDate.Value = Me.dgdSplitContainer.Item("OrderDate", index).Value
            Me.chkGetContainer.Checked = Me.dgdSplitContainer.Item("getContainer", index).Value
            If Me.dgdSplitContainer.Item("getContainerDATE", index).Value.ToString <> "" Then
                Me.dtpGetContainerDate.Value = Me.dgdSplitContainer.Item("getContainerDATE", index).Value
            End If
            Me.txtQuanTity20gp.Text = IIf(Me.dgdSplitContainer.Item("Order20GP", index).Value = 0, "", Me.dgdSplitContainer.Item("Order20GP", index).Value)
            Me.txtQuanTity40GP.Text = IIf(Me.dgdSplitContainer.Item("Order40GP", index).Value = 0, "", Me.dgdSplitContainer.Item("Order40GP", index).Value)
            Me.txtQuanTity20RF.Text = IIf(Me.dgdSplitContainer.Item("Order20RF", index).Value = 0, "", Me.dgdSplitContainer.Item("Order20RF", index).Value)
            Me.txtQuanTity40RF.Text = IIf(Me.dgdSplitContainer.Item("Order40RF", index).Value = 0, "", Me.dgdSplitContainer.Item("Order40RF", index).Value)
            Me.txtQuanTity40HC.Text = IIf(Me.dgdSplitContainer.Item("Order40HC", index).Value = 0, "", Me.dgdSplitContainer.Item("Order40HC", index).Value)
            Me.txtQuanTity45HC.Text = IIf(Me.dgdSplitContainer.Item("Order45HC", index).Value = 0, "", Me.dgdSplitContainer.Item("Order45HC", index).Value)
            Me.txtQuanTity40RH.Text = IIf(Me.dgdSplitContainer.Item("Order40RH", index).Value = 0, "", Me.dgdSplitContainer.Item("Order40RH", index).Value)

            Me.txtQuanTity20OT.Text = IIf(Me.dgdSplitContainer.Item("Order20OT", index).Value = 0, "", Me.dgdSplitContainer.Item("Order20OT", index).Value)

            Me.txtQuanTity40OT.Text = IIf(Me.dgdSplitContainer.Item("Order40OT", index).Value = 0, "", Me.dgdSplitContainer.Item("Order40OT", index).Value)

            Me.txtQuanTity20FR.Text = IIf(Me.dgdSplitContainer.Item("Order20FR", index).Value = 0, "", Me.dgdSplitContainer.Item("Order20FR", index).Value)

            Me.txtQuanTity40FR.Text = IIf(Me.dgdSplitContainer.Item("Order40FR", index).Value = 0, "", Me.dgdSplitContainer.Item("Order40FR", index).Value)



            Me.txtQuanTity20gp.Enabled = False
            Me.txt20GP.Enabled = False

            Me.txtQuanTity40GP.Enabled = False
            Me.TXT40GP.Enabled = False

            Me.txtQuanTity40HC.Enabled = False
            Me.txt40HC.Enabled = False

            Me.txtQuanTity45HC.Enabled = False
            Me.txt45HC.Enabled = False

            Me.txtQuanTity20RF.Enabled = False
            Me.txt20RF.Enabled = False

            Me.txtQuanTity40RF.Enabled = False
            Me.txt40RF.Enabled = False

            Me.txtQuanTity40RH.Enabled = False
            Me.txt40RH.Enabled = False

            Me.txtQuanTity20OT.Enabled = False
            Me.TXT20OT.Enabled = False


            Me.txtQuanTity40OT.Enabled = False
            Me.TXT40OT.Enabled = False

            Me.txtQuanTity40FR.Enabled = False
            Me.TXT20FR.Enabled = False

            Me.txtQuanTity40FR.Enabled = False
            Me.TXT40FR.Enabled = False



            If txtQuanTity20gp.Text <> "" Then
                Me.txtQuanTity20gp.Enabled = True
                Me.txt20GP.Enabled = True
            End If

            If txtQuanTity40GP.Text <> "" Then
                Me.txtQuanTity40GP.Enabled = True
                Me.TXT40GP.Enabled = True
            End If
            If txtQuanTity40HC.Text <> "" Then
                Me.txtQuanTity40HC.Enabled = True
                Me.txt40HC.Enabled = True
            End If
            If txtQuanTity45HC.Text <> "" Then
                Me.txtQuanTity45HC.Enabled = True
                Me.txt45HC.Enabled = True
                'Me.txtQuanTity45HC.Text = dt.Rows(0).Item("SoLuong45HC")
            End If
            If txtQuanTity20RF.Text <> "" Then
                Me.txtQuanTity20RF.Enabled = True
                Me.txt20RF.Enabled = True
                'Me.txtQuanTity20RF.Text = dt.Rows(0).Item("SoLuong45HC")
            End If
            If txtQuanTity40RF.Text <> "" Then
                Me.txtQuanTity40RF.Enabled = True
                Me.txt40RF.Enabled = True
                'Me.txtQuanTity40RF.Text = dt.Rows(0).Item("SoLuong40RF")
            End If
            If txtQuanTity40RH.Text <> "" Then
                Me.txtQuanTity40RH.Enabled = True
                Me.txt40RH.Enabled = True
                'Me.txtQuanTity40RH.Text = dt.Rows(0).Item("SoLuong40RH")
            End If


            If txtQuanTity20OT.Text <> "" Then
                Me.txtQuanTity20OT.Enabled = True
                Me.TXT20OT.Enabled = True
                'Me.txtQuanTity40RH.Text = dt.Rows(0).Item("SoLuong40RH")
            End If
            If txtQuanTity40OT.Text <> "" Then
                Me.txtQuanTity40OT.Enabled = True
                Me.TXT40OT.Enabled = True
                'Me.txtQuanTity40RH.Text = dt.Rows(0).Item("SoLuong40RH")
            End If

            If txtQuanTity20FR.Text <> "" Then
                Me.txtQuanTity20FR.Enabled = True
                Me.TXT20FR.Enabled = True
                'Me.txtQuanTity40RH.Text = dt.Rows(0).Item("SoLuong40RH")
            End If


            If txtQuanTity40FR.Text <> "" Then
                Me.txtQuanTity40FR.Enabled = True
                Me.TXT40FR.Enabled = True
                'Me.txtQuanTity40RH.Text = dt.Rows(0).Item("SoLuong40RH")
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub dtpOrderDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOrderDate.ValueChanged
        Me.dtpExpireate.Value = Me.dtpOrderDate.Value.AddDays(2)
    End Sub

    Sub UpdateBookingValidOrder(ByVal BookingNo As String)
        Try
            Dim SQL As String
            'SQL = " Update BookingValidOrder "
            'SQL &= " Set ValidOrder='" & Math.Abs(GetTerminalValidOrder(BookingNo) - CDbl(Me.txtValidOrder.Text)) & " "
            'SQL &= " Where BookingNo='" & BookingNo.Trim & "'"
            SQL = "Select Top 1 * from BookingValidOrder Where BookingNo='" & BookingNo.Trim & "' and continued=1"
            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BookingValidOrderID").Value = NewId()
                    .Fields("BookingNo").Value = BookingNo.Trim
                End If
                .Fields("ValidOrder").Value = Math.Abs(GetTerminalValidOrder(BookingNo) - CDbl(Me.txtValidOrder.Text))
                .Update()
            End With
            rs.Close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdGetCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetCont.Click
        If Me.dgdSplitContainer.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdSplitContainer.CurrentRow.Index

        'UpdateBookingValidOrder(Me.txtSearchBookingNo.Text.Trim)
        Me.SaveSplitUpdateData(index) 'update sau khi check get cont


    End Sub
    Private Sub frmBookingOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'QueryContainerOutboundNotify()
        'Me.lbBookingNo.DisplayMember = "BookingNo"
        'Me.lbBookingNo.DataSource = oTableBooking
        'ShowfraSplit()
        'QuerySplitOrder()

        'For i As Integer = 0 To oTableBooking.Rows.Count - 1

        'Next
        Me.txtSearchBookingNo.Visible = True
        Me.cmdViewBookingNumber.Visible = True
        Me.Label4.Visible = True

        QueryICD(Me.cboSupplyDepotOrder)
        SetDefaultGrid(Me.dgdSplitContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            gNameForm = "frmContainerOutboundNotify"
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerOutboundNotify(" " & mFilter)
                Me.lbBookingNo.DisplayMember = "BookingNo"

                Me.lbBookingNo.DataSource = oTableBooking

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub lbBookingNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBookingNo.SelectedIndexChanged
        Try
            If oTableBooking.Rows.Count = 0 Then
                Return
            End If


            SelectedIndex = Me.lbBookingNo.SelectedIndex
            'Dim ClosingTime As String
            'ClosingTime = CDate(oTableBooking.Rows(SelectedIndex).Item("dateClosing2")) & " "
            'ClosingTime = ClosingTime.Trim
            Dim Curdate As Date
            Curdate = GetServerDate()
            QuerySplitOrder()
            Dim day As Integer = CDate(oTableBooking.Rows(SelectedIndex).Item("dateClosing2").ToString.Trim).Date.ToOADate - Curdate.Date.ToOADate
            Me.txtSearchBookingNo.Text = oTableBooking.Rows(SelectedIndex).Item("bookingno").ToString.Trim
            Me.txtValidOrder.Text = GetBookingValidOrder(Me.txtSearchBookingNo.Text.Trim)
            Me.txtTerminalValidOrder.Text = GetTerminalValidOrder(Me.txtSearchBookingNo.Text.Trim)
            If day < 0 Then
                Me.txtSubBookingNo.Enabled = False
                Me.txtRemarksSplit.Enabled = False
                Me.cmdOkSplitBooking.Enabled = False
                Me.GrpOrderContainer.Enabled = False
                Me.grpBookingContainer.Enabled = False
                Me.GrpBookingInfo.Enabled = False
                Me.GrpOrderInfo.Enabled = False
                Return
            ElseIf day = 0 Then
                Dim ClosingTime, NowTime As Integer
                NowTime = IIf(Curdate.ToString Like "*PM*", Curdate.Hour + 12, Curdate.Hour)
                ClosingTime = CInt(Strings.Replace(UCase(oTableBooking.Rows(SelectedIndex).Item("Gio2").ToString.Trim), "H", ""))
                If ClosingTime <= NowTime Then
                    Me.txtSubBookingNo.Enabled = False
                    Me.txtRemarksSplit.Enabled = False
                    Me.cmdOkSplitBooking.Enabled = False
                    Me.GrpOrderContainer.Enabled = False
                    Me.grpBookingContainer.Enabled = False
                    Me.GrpBookingInfo.Enabled = False
                    Me.GrpOrderInfo.Enabled = False
                    Return
                Else
                    Me.txtSubBookingNo.Enabled = True
                    Me.txtRemarksSplit.Enabled = True
                    Me.cmdOkSplitBooking.Enabled = True
                    Me.GrpOrderContainer.Enabled = True
                    Me.grpBookingContainer.Enabled = True
                    Me.GrpBookingInfo.Enabled = True
                    Me.GrpOrderInfo.Enabled = True
                End If
            Else
                Me.txtSubBookingNo.Enabled = True
                Me.txtRemarksSplit.Enabled = True
                Me.cmdOkSplitBooking.Enabled = True
                Me.GrpOrderContainer.Enabled = True
                Me.grpBookingContainer.Enabled = True
                Me.GrpBookingInfo.Enabled = True
                Me.GrpOrderInfo.Enabled = True
            End If

            ReSetContainer()
            ShowfraSplit()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim strMesg As String = "Are you sure !?"
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                If Me.dgdSplitContainer.RowCount = 0 Then
                    Return
                End If
                Dim rs As New ADODB.Recordset

                Dim index As Integer
                index = Me.dgdSplitContainer.CurrentRow.Index
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim strQuery As String = "Update [Order] Set Continued=0 where OrderNo='" & Me.dgdSplitContainer.Item("OrderNoOrder", index).Value.ToString.Trim & "'"
                Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strQuery
                cmd.ExecuteNonQuery()
                QuerySplitOrder()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Function GetTerminalValidOrder(ByVal BookingNo As String) As Double
        Try
            Dim SQL As String
            SQL = " Select ValidOrder "
            SQL &= " From (Terminal INNER JOIN ContainerOutboundNotify On Terminal.TermiNalName=ContainerOutboundNotify.EmptyContainerPlace) "
            SQL &= " Where BookingNo='" & BookingNo.Trim & "' And Terminal.Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            If dt.Rows(0).Item(0).ToString.Trim = "" Then
                Return 0
            End If
            Return CDbl(dt.Rows(0).Item(0))
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function GetBookingValidOrder(ByVal bookingNo As String) As Double
        Try
            Dim SQL As String
            SQL = "Select ValidOrder "
            SQL &= " From bookingValidorder "
            SQL &= " Where bookingNo='" & bookingNo.Trim & "' And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            If dt.Rows(0).Item(0).ToString.Trim = "" Then
                Return 0
            End If
            Return CDbl(dt.Rows(0).Item(0))
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function checkOdered(ByVal BookingNo As String) As String
        Try
            '-----------------

            Dim rs As New ADODB.Recordset
            Dim SQL, bk As String
            If UCase(BookingNo) Like "*R?" Then
                BookingNo = BookingNo.Substring(0, BookingNo.Length - 2)
            End If
            If UCase(BookingNo) Like "*R" Then
                BookingNo = BookingNo.Substring(0, BookingNo.Length - 1)
            End If

            SQL = "Select  bookingno  from  [order]  where bookingno like'" & BookingNo & "%' and continued=1"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then

                bk = rs.Fields("bookingno").Value.ToString
                rs.Close()
                Return bk
            Else
                rs.Close()
                Return ""
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        '-----------------

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewBookingNumber.Click
        Try
            If Me.txtSearchBookingNo.Text.Trim = "" Then
                MsgBox("Have to Input a booking Number")
                Return
            End If

           


            QueryContainerOutboundNotify(" And BookingNo='" & Me.txtSearchBookingNo.Text.Trim & "'")

            'thêm vào List
            Me.lbBookingNo.DisplayMember = "BookingNo"
            Me.lbBookingNo.DataSource = oTableBooking
            Me.cmdOkSplitBooking.Enabled = True
            If oTableBooking.Rows.Count = 0 Then
                MsgBox("Check This Booking Number again ")
                Me.cmdOkSplitBooking.Enabled = False
                Return
            End If

            If oTableBooking.Rows(0).Item("lockorder") = 1 Then
                MsgBox("Booking is lock, please contact with Booking Dept! ")
                Me.cmdOkSplitBooking.Enabled = False
                Return
            End If
            '---thong bao booking da doi lenh
            If checkOdered(Me.txtSearchBookingNo.Text.Trim) <> "" Then
                DisplayMessage(True, "Booking " + checkOdered(Me.txtSearchBookingNo.Text.Trim) + "  (ordered), please check again! ")
            End If

            '---------------------------------
            SelectedIndex = Me.lbBookingNo.SelectedIndex
            'Dim ClosingTime As String
            'ClosingTime = CDate(oTableBooking.Rows(SelectedIndex).Item("dateClosing2")) & " "
            'ClosingTime = ClosingTime.Trim
            Dim Curdate As Date
            Curdate = GetServerDate()
            Dim day As Integer = CDate(oTableBooking.Rows(SelectedIndex).Item("dateClosing2").ToString.Trim).Date.ToOADate - Curdate.Date.ToOADate

            'thêm 12-12-2007  validorder kiểm tra đã tới ngày dc phép cấp lệnh chưa
            Me.txtValidOrder.Text = GetBookingValidOrder(Me.txtSearchBookingNo.Text.Trim)
            Me.txtTerminalValidOrder.Text = GetTerminalValidOrder(Me.txtSearchBookingNo.Text.Trim)
            If day < 0 Then
                Me.txtSubBookingNo.Enabled = False
                Me.txtRemarksSplit.Enabled = False
                Me.cmdOkSplitBooking.Enabled = False
                Me.GrpOrderContainer.Enabled = False
                Me.grpBookingContainer.Enabled = False
                Me.GrpBookingInfo.Enabled = False
                Me.GrpOrderInfo.Enabled = False
                MsgBox("Please check closing time! ")
                Return
            ElseIf day = 0 Then
                Dim ClosingTime, NowTime As Integer
                NowTime = IIf(Curdate.ToString Like "*PM*", Curdate.Hour + 12, Curdate.Hour)
                ClosingTime = CInt(Strings.Replace(UCase(oTableBooking.Rows(SelectedIndex).Item("Gio2").ToString.Trim), "H", ""))
                If ClosingTime <= NowTime Then
                    Me.txtSubBookingNo.Enabled = False
                    Me.txtRemarksSplit.Enabled = False
                    Me.cmdOkSplitBooking.Enabled = False
                    Me.GrpOrderContainer.Enabled = False
                    Me.grpBookingContainer.Enabled = False
                    Me.GrpBookingInfo.Enabled = False
                    Me.GrpOrderInfo.Enabled = False
                    Return
                Else
                    Me.txtSubBookingNo.Enabled = True
                    Me.txtRemarksSplit.Enabled = True

                    Me.cmdOkSplitBooking.Enabled = True
                    Me.GrpOrderContainer.Enabled = True
                    Me.grpBookingContainer.Enabled = True
                    Me.GrpBookingInfo.Enabled = True
                    Me.GrpOrderInfo.Enabled = True
                End If
            Else
                Me.txtSubBookingNo.Enabled = True
                Me.txtRemarksSplit.Enabled = True
                Me.cmdOkSplitBooking.Enabled = True
                Me.GrpOrderContainer.Enabled = True
                Me.grpBookingContainer.Enabled = True
                Me.GrpBookingInfo.Enabled = True
                Me.GrpOrderInfo.Enabled = True
            End If

            ReSetContainer()
            ShowfraSplit()
            QuerySplitOrder()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtValidOrder_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValidOrder.Leave
        If Me.txtValidOrder.Text.Trim = "" Then
            Me.txtValidOrder.Text = "0"
        End If

    End Sub
    Private Sub txtTerminalValidOrder_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTerminalValidOrder.Leave
        If Me.txtTerminalValidOrder.Text.Trim = "" Then
            Me.txtTerminalValidOrder.Text = "0"
        End If
    End Sub
End Class
