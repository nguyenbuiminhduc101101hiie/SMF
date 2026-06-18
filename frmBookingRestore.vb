Public Class frmBookingRestore

    Dim oTable As New DataTable
    Dim mFilter As String
    Dim BKNo As String = ""
    Private Sub QueryContainerOutboundNotify(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        'On Error GoTo Err_Renamed
        '        Dim strQuery As String
        '        '-------------
        '        Dim Con As New SqlClient.SqlConnection(strconnDG)
        '        Dim ds As New DataSet
        '        '----------------
        '        'If IsNothing(argCriteria) Then
        '        '    strQuery = MakeQueryContainerOutboundNotify()
        '        'Else
        '        '    strQuery = MakeQueryContainerOutboundNotify(argCriteria, index)
        '        'End If
        '        strQuery = "SELECT ContainerOutBoundNotifyId,BookingNo,ServiceContract,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,Representative,ContainerOutBoundNotify.Commondity ,ServiceFeeder,PortOfUnLoading, Destination, mak.Market_ID,mak.Market,TruckCompany,ReceiptContainer, Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, SailingSchedule.ETD as ETD,Tranship,PortOfLoading,MotherSailingSchedule.MotherSailingScheduleID, "
        '        strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  "
        '        strQuery = strQuery + " OceanVessel.Vessel as OceanVessel,MotherSailingSchedule.MotherVesselNo as OceanVessel_VoyNo,MotherSailingSchedule.OceanETD as OceanETD, SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify.Remarks as Remarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
        '        strQuery = strQuery + " BookingDate,BookingPerson,"
        '        strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,"
        '        strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime   "

        '        strQuery = strQuery + " From (((((((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
        '        strQuery = strQuery + " left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        '        strQuery = strQuery + "left JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) " & _
        '                              " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
        '                              " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
        '                              " LEFT JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=ContainerOutboundNotify.MotherSailingScheduleID) " & _
        '                              " LEFT JOIN Vessel as OceanVessel On MotherSailingSchedule.MotherVesselID=OceanVessel.Vessel_ID) "

        '        strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 0 "
        '        If argCriteria <> "" Then
        '            strQuery = strQuery + argCriteria
        '        End If
        '        strQuery &= " Order By updateTime DESC"
        '        Con.Open()
        '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '        '-----------------
        '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '        ' Con.Open()
        '        Adapter.Fill(ds, "ContainerOutboundNotifyList")
        '        oTable = ds.Tables(0)
        '        'hien thi ra grid 
        '        Me.dgdContianerOutboundNotify.DataSource = ds.Tables("ContainerOutboundNotifyList")
        '        If Me.dgdContianerOutboundNotify.Enabled = False Then
        '            Me.dgdContianerOutboundNotify.Enabled = True
        '        End If

        '        Me.Cursor = System.Windows.Forms.Cursors.Default
        '        If oTable.Rows.Count > 0 Then
        '            Me.dgdContianerOutboundNotify.Columns.Item("BookingNo").ToolTipText = "Hiện có:" + CStr(Me.dgdContianerOutboundNotify.RowCount()) + " ContainerOutboundNotifys."
        '        End If
        '        If Me.dgdContianerOutboundNotify.RowCount() = 0 Then
        '            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        '        End If
        '        '------------vị trí BM
        '        If location >= 0 And location <= Me.dgdContianerOutboundNotify.Rows.Count And Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
        '            Me.dgdContianerOutboundNotify.Rows(location).Selected = True
        '            Me.dgdContianerOutboundNotify.CurrentCell = Me.dgdContianerOutboundNotify.Rows(location).Cells("BookingNo")
        '        End If
        '        '--------------------
        '        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
        'Resume
        '--------------------------------
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
        'strQuery = "SELECT ContainerOutBoundNotifyId,BookingNo,ServiceContract,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,Representative,ContainerOutBoundNotify.Commondity ,weekofyear,ServiceFeeder,PortOfUnLoading, Destination, mak.Market_ID,mak.Market,TruckCompany,ReceiptContainer, Vessel.Vessel as Pre_Vessel,SailingSchedule.VoyNo as PreVoyNo, SailingSchedule.ETD as ETD,Tranship,PortOfLoading,MotherSailingSchedule.MotherSailingScheduleID, "
        'strQuery = strQuery + " ContainerOutBoundNotify.SailingScheduleID as SailingScheduleID, SailingSchedule.Vessel_Id as Vessel_Id,  "
        'strQuery = strQuery + " OceanVessel.Vessel as OceanVessel,MotherSailingSchedule.MotherVesselNo as OceanVessel_VoyNo,MotherSailingSchedule.OceanETD as OceanETD, SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
        'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
        'strQuery = strQuery + " CONTAINEROUTBOUNDNOTIFY.Delay, CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,"
        'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime   "

        'strQuery = strQuery + " From (((((((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
        'strQuery = strQuery + " left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        'strQuery = strQuery + "left JOIN Vessel on Vessel.Vessel_ID = SailingSchedule.Vessel_ID) " & _
        '                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
        '                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
        '                      " LEFT JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=ContainerOutboundNotify.MotherSailingScheduleID) " & _
        '                      " LEFT JOIN Vessel as OceanVessel On MotherSailingSchedule.MotherVesselID=OceanVessel.Vessel_ID) "

        'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 0 and wait=0 "
        strQuery = strQuery + " select * From ContainerOutBoundNotify LEFT JOIN BookingCancelLog On BookingCancelLog.BookingNo=ContainerOutBoundNotify.BooKingNo " 'left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
        ' strQuery = strQuery + " ) "
        'strQuery = strQuery + ") " & _
        '                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
        '                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
        '                      " ) " & _
        '                      " ) " & _
        '    " LEFT JOIN BookingCancelLog On BookingCancelLog.BookingNo=ContainerOutBoundNotify.BooKingNo) "

        strQuery = strQuery + " WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 0 and wait=0 "
        '  strQuery &= " " & Filter()

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
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdContianerOutboundNotify.DataSource = ds.Tables("ContainerOutboundNotifyList")
        If Me.dgdContianerOutboundNotify.Enabled = False Then
            Me.dgdContianerOutboundNotify.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
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
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmBookingRestore_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmContainerOutBoundNotify.mFilter = " And BookingNo='" & BKNo & "'"
        frmContainerOutBoundNotify.QueryContainerOutboundNotify(frmContainerOutBoundNotify.mFilter)
        SetDefaultGrid(Me.dgdContianerOutboundNotify, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub


    Private Sub frmBookingRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'QueryContainerOutboundNotify()
        Reformat()
    End Sub
    Sub Reformat()
        Try
            Me.dgdContianerOutboundNotify.Height = Me.Height - 100 - Me.cmdRestore.Height
            Me.dgdContianerOutboundNotify.Width = Me.Width - 30

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Try
            gNameForm = "frmContainerOutBoundNotify"
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerOutboundNotify(" " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestore.Click
        Try
            'If Me.txtNewBookingNo.Text = "" Then
            '    DisplayMessage(True, "The code not allow NULL value")
            'End If
            'Dim i As Integer = 0
            'i = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            Dim rs As New ADODB.Recordset
            Dim index As Integer = Me.dgdContianerOutboundNotify.SelectedRows(0).Index
            Dim strQuery As String
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM ContainerOutBoundNotify "
            strQuery = strQuery & "WHERE BookingNo = '" & Me.dgdContianerOutboundNotify.Item("BookingNo", index).value.tostring.trim & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then

                If MsgBox("This code had already in database, restore Anyway ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    rs.Close()
                    Return
                End If
            End If
            rs.Close()
            BKNo = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim
            strQuery = "Update ContainerOutboundnotify set Continued=1,BC='OK' ,editable=1 Where BookingNo='" & BKNo & "'"
            strQuery &= " And Continued=0"

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQuery
            cmd.ExecuteNonQuery()
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'With rs
            '    rs.Fields("Continued").Value = 1
            '    .Update()
            'End With
            Me.cmdRestore.Enabled = False
            QueryContainerOutboundNotify(" " & mFilter)
            'frmContainerOutBoundNotify.QueryContainerOutboundNotify()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContianerOutboundNotify_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContianerOutboundNotify.CellMouseClick
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return
            End If
            If IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) Then
                Return
            End If
            Dim Index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Dim mBkNo As String
            mBkNo = Me.dgdContianerOutboundNotify.Item("BookingNo", Index).Value.ToString
            Dim SQL As String = "Select Customer,DateCancel From BookingCancelLog Where BookingNo='" & mBkNo & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt Is Nothing Then
                Me.dgdContianerOutboundNotify.Rows(Index).Cells("BookingNo").ToolTipText = "No Customer And Cancel date info"
                Return
            End If
            If dt.Rows.Count = 0 Then
                Me.dgdContianerOutboundNotify.Rows(Index).Cells("BookingNo").ToolTipText = "No Customer And Cancel date info"
                Return
            End If

            For i As Integer = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                Me.dgdContianerOutboundNotify.Rows(Index).Cells(i).ToolTipText = "Customer :" & dt.Rows(0).Item("Customer").ToString & Chr(13) & Chr(10) & "Date Cancel :" & dt.Rows(0).Item("DateCancel").ToString
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContianerOutboundNotify_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdContianerOutboundNotify.RowStateChanged
        Try
            Dim i As Integer = 0
            i = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If i = 1 Then
                Me.cmdRestore.Enabled = True
            Else
                Me.cmdRestore.Enabled = False
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdContianerOutboundNotify, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdContianerOutboundNotify_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContianerOutboundNotify.CellContentClick

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
End Class