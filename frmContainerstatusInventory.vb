Public Class frmContainerstatusInventory


    Sub GetCountContainerManagerment()
        Try
            Dim SQL As String
            'SQL = " Select FinalICD,LEFT(CTN_SIZE_TYPE,2), "
            'SQL &= " (select Count(CTN_SIZE_TYPE) from ContainerManagerment Where Left(CTN_SIZE_TYPE,2)='20' ANd continued=1 And SoundContainer=1 ) as Quantity20,"
            'SQL &= " (select Count(CTN_SIZE_TYPE) from ContainerManagerment Where Left(CTN_SIZE_TYPE,2)='40' ANd continued=1 And SoundContainer=1 ) as Quantity40 "
            'SQL &= " from Containermanagerment Where Continued=1 "
            'SQL &= " Group By left(CTN_SIZE_TYPE,2),FinalICD "
            If Me.cboStatus.Text.Trim = "" Then
                Return
            End If
            'SQL = "select  FinalICD,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='20GP' And Continued=1 And SoundContainer=1) as Quantity20GP,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40GP' And Continued=1 And SoundContainer=1) as Quantity40GP,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40HC' And Continued=1 And SoundContainer=1) as Quantity40HC,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='45HC' And Continued=1 And SoundContainer=1) as Quantity45HC,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='20RF' And Continued=1 And SoundContainer=1) as Quantity20RF,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40RF' And Continued=1 And SoundContainer=1) as Quantity40RF,"
            'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent Where CTN_SIZE_TYPE='40RH' And Continued=1 And SoundContainer=1) as Quantity40RH "
            'SQL &= " from ContainerManagerMent "
            'SQL &= " Where Continued=1  Group By FinalICD  Order By FinalICD " 'And FinalICD='" & Me.cboEmptyContainerPlace.Text.Trim & "'"
            Dim dt As New DataTable
            Dim arr() As String = {"ContainerManagerMent.Continued", "SoundContainer", "ToBeInSpected", "DamageContainer", "FullImport", "FullToConsignee", "FullExport", "EmptyToShipper", "EmptyContainerReposit"}
            Dim CboIndex As Integer = Me.cboStatus.SelectedIndex ' index of combo

            SQL = "Select distinct FinalICD from ContainerManagerMent Where Continued=1 Order By FinalICD"
            dt = ReadTable(SQL)
            Dim oTable As New DataTable
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim Cmd As New SqlClient.SqlCommand()
            Dim Adapter As New SqlClient.SqlDataAdapter()
            For i As Integer = 0 To dt.Rows.Count - 1
                SQL = "select  distinct FinalICD ,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20GP' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date) ) as Quantity20GP,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40GP' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40GP,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40HC' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40HC,"

                'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40GP' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  ) as Quantity40GP,"
                'SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40HC' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (BL_NO_Outbound is Null Or BL_NO_Outbound=' ') And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  ) as Quantity40HC,"

                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='45HC' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity45HC,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20RF' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity20RF,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40RF' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40RF,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40RH' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40RH, "
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20OT' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity20OT,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40OT' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40OT,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='20FR' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo  and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity20FR,"
                SQL &= "(Select Count(CTN_SIZE_TYPE) From ContainerManagerMent,ScheduleCheck Where CTN_SIZE_TYPE='40FR' And ContainerManagerMent.Continued=1 And " & arr(CboIndex) & "=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "'  And (DateofOnboard is NULL or DateofOnboard = ' ')And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date)) as Quantity40FR "
                'SQL &= ",(Select Count(CTN_SIZE_TYPE)From ContainerManagerMent Where Continued=1  And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "') as Total "
                SQL &= " from ContainerManagerMent ,ScheduleCheck"
                SQL &= " Where ContainerManagerMent.Continued=1 And FinalICD='" & dt.Rows(i).Item("FinalICD").ToString & "' And (DateofOnboard is NULL or DateofOnboard = ' ') " 'And FinalICD='" & Me.cboEmptyContainerPlace.Text.Trim & "'"
                SQL &= " And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date) Order By FinalICD "
                'SQL &= " And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo Order By FinalICD "
                Cmd = New SqlClient.SqlCommand(SQL, Conn)
                Adapter = New SqlClient.SqlDataAdapter(Cmd)
                Adapter.Fill(oTable)
            Next
            Me.dgdCountMNG.DataSource = oTable

            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdCountMNG.RowCount - 1
                For s = 0 To Me.dgdCountMNG.ColumnCount - 1
                    If Me.dgdCountMNG.Item(s, t).Value.ToString = "0" Then
                        Me.dgdCountMNG.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
            'Quantity Of Container In Booking
            'SQL = "Select  EmptyContainerPlace,"
            'SQL &= "Sum(Soluong20GP) As Cont20GPBook,"
            'SQL &= "Sum(Soluong40GP)   As Cont40GPBook,"
            'SQL &= " Sum(Soluong40HC)  As Cont40HCBook,"
            'SQL &= " Sum(Soluong45HC)As Cont45HCBook,"
            'SQL &= " Sum(Soluong20RF)As Cont20RFBook,"
            'SQL &= " Sum(Soluong40RF)  As Cont40RFBook,"
            'SQL &= " Sum(Soluong40RH) As Cont40RHBook "
            'SQL &= " From ContainerOutboundNotify "
            'SQL &= " where Continued=1 And Editable=1 And SailingScheduleID='" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "' Group By EmptyContainerPlace Order By EmptyContainerPlace "
            'Dim dtBookingContainer As New DataTable
            'dtBookingContainer = ReadTable(SQL)
            'Me.dgdBookingContainer.DataSource = dtBookingContainer

            ''-------------
            'Dim n As Integer = 0
            'Dim k As Integer = 0
            'Dim l As Integer = 0
            'For k = 0 To Me.dgdCountMNG.RowCount - 1
            '    For l = 0 To Me.dgdBookingContainer.RowCount - 1
            '        If Me.dgdCountMNG.Item("FinalICD", k).Value.ToString.Trim = Me.dgdBookingContainer.Item("DataGridViewTextBoxColumn1", l).Value.ToString.Trim Then
            '            For n = 1 To 7
            '                Me.dgdCountMNG.Item(n, k).Value = CStr(CDbl(Me.dgdCountMNG.Item(n, k).Value.ToString()) - CDbl(Me.dgdBookingContainer.Item(n, l).Value.ToString()))
            '            Next

            '        End If
            '    Next

            'Next

            ''-------------
            'If MSTATUS = "Add" Then
            '    For k = 0 To Me.dgdCountMNG.RowCount - 1
            '        If Me.dgdCountMNG.Item("FinalICD", k).Value.ToString.Trim = Me.cboEmptyContainerPlace.Text.Trim Then
            '            If CDbl(Me.dgdCountMNG.Item("Quantity20GP", k).Value) < CDbl(Me.txtSoLuong20GP.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong20GP.Focus()
            '            End If
            '            If CDbl(Me.dgdCountMNG.Item("Quantity40GP", k).Value) < CDbl(Me.txtSoLuong40GP.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong40GP.Focus()
            '            End If
            '            If CDbl(Me.dgdCountMNG.Item("Quantity40HC", k).Value) < CDbl(Me.txtSoLuong40HC.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong40HC.Focus()
            '            End If
            '            If CDbl(Me.dgdCountMNG.Item("Quantity45HC", k).Value) < CDbl(Me.txtSoLuong45HC.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong45HC.Focus()
            '            End If
            '            If CDbl(Me.dgdCountMNG.Item("Quantity20RF", k).Value) < CDbl(Me.txtSoLuong20RF.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong20RF.Focus()
            '            End If
            '            If CDbl(Me.dgdCountMNG.Item("Quantity40RF", k).Value) < CDbl(Me.txtSoLuong40RF.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong40RF.Focus()
            '            End If
            '            If CDbl(Me.dgdCountMNG.Item("Quantity40RH", k).Value) < CDbl(Me.txtSoLuong40RH.Text) Then
            '                DisplayMessage(True, "Invalid quantity! please check again !")
            '                Me.txtSoLuong40RH.Focus()
            '            End If
            '        End If
            '    Next
            'ElseIf mStatus = "Edit" Then
            '    Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            '    For k = 0 To Me.dgdCountMNG.RowCount - 1 ' KIEM TRA LAI KHI REVICES MDOI mt cy
            '        If Me.dgdCountMNG.Item("FinalICD", k).Value.ToString.Trim = Me.cboEmptyContainerPlace.Text.Trim Then
            '            If Me.dgdContianerOutboundNotify.Item("EmptyContainerPlace", index).Value = Me.cboEmptyContainerPlace.Text.Trim Then


            '                If CDbl(Me.dgdCountMNG.Item("Quantity20GP", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("GP20", index).Value) < CDbl(Me.txtSoLuong20GP.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong20GP.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40GP", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("GP40", index).Value) < CDbl(Me.txtSoLuong40GP.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40GP.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40HC", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("HC40", index).Value) < CDbl(Me.txtSoLuong40HC.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40HC.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity45HC", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("HC45", index).Value) < CDbl(Me.txtSoLuong45HC.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong45HC.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity20RF", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("RF20", index).Value) < CDbl(Me.txtSoLuong20RF.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong20RF.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40RF", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("RF40", index).Value) < CDbl(Me.txtSoLuong40RF.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40RF.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40RH", k).Value) + CDbl(Me.dgdContianerOutboundNotify.Item("RH40", index).Value) < CDbl(Me.txtSoLuong40RH.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40RH.Focus()
            '                End If
            '            Else
            '                If CDbl(Me.dgdCountMNG.Item("Quantity20GP", k).Value) < CDbl(Me.txtSoLuong20GP.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong20GP.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40GP", k).Value) < CDbl(Me.txtSoLuong40GP.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40GP.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40HC", k).Value) < CDbl(Me.txtSoLuong40HC.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40HC.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity45HC", k).Value) < CDbl(Me.txtSoLuong45HC.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong45HC.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity20RF", k).Value) < CDbl(Me.txtSoLuong20RF.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong20RF.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40RF", k).Value) < CDbl(Me.txtSoLuong40RF.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40RF.Focus()
            '                End If
            '                If CDbl(Me.dgdCountMNG.Item("Quantity40RH", k).Value) < CDbl(Me.txtSoLuong40RH.Text) Then
            '                    DisplayMessage(True, "Invalid quantity! please check again !")
            '                    Me.txtSoLuong40RH.Focus()
            '                End If
            '            End If
            '        End If
            '    Next
            'End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmContainerstatusInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetCountContainerManagerment()
        SetDefaultGrid(Me.dgdCountMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        GetCountContainerManagerment()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Try
            If Me.dgdCountMNG.RowCount > 0 Then
                ExportExecel(Me.dgdCountMNG, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class