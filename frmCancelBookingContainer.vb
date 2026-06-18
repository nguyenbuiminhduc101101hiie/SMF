Public Class frmCancelBookingContainer

    Public BookingId As String = DefaultValue
    Public WaitBookingNo As String = ""
    Sub CountContainer()
        Try
            Dim obj() As TextBox = {Me.txtSoLuong20GP, Me.txtSoLuong20RF, Me.txtSoLuong40GP, Me.txtSoLuong40HC, Me.txtSoLuong40RF, Me.txtSoLuong40RH, Me.txtSoLuong45HC}
            For j As Integer = 0 To obj.Length - 1
                obj(j).Text = "0"
            Next
            For i As Integer = 0 To Me.dgdLoadingPlanData.RowCount - 1
                If Me.dgdLoadingPlanData.Item("Cancel", i).Value = 0 Then
                    For j As Integer = 0 To obj.Length - 1
                        If UCase(obj(j).Name) Like "*" & UCase(Me.dgdLoadingPlanData.Item("Container_Type", i).Value.ToString.Trim) Then
                            Dim Temp As Double = 0
                            Temp = CDbl(obj(j).Text)

                            obj(j).Text = Temp + 1
                            Exit For
                        End If
                    Next
                End If

            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryLoadingPlanInfo(Optional ByVal agr As String = "")
        Try
            Dim SQL As String
            SQL = " Select LOADINGPLANFORVESSELID, ContainerOutboundNotify.bookingNo,Container.Container_No as ContainerNo,Container.CTN_SIZE_TYPE as Container_type,LOADINGPLANFORVESSEL.Cancel"
            SQL &= " From ((LOADINGPLANFORVESSEL LEFT JOIN  ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=LOADINGPLANFORVESSEL.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID) "
            SQL &= " where LOADINGPLANFORVESSEL.Continued=1 and ContainerOutboundNotify.ContainerOutboundNotifyID='" & BookingId & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdLoadingPlanData.DataSource = dt
            CountContainer()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function GetContainerRowCount(ByVal Type As String) As Integer
        Try
            Dim Count As Integer = 0
            For i As Integer = 0 To Me.dgdLoadingPlanData.RowCount - 1
                If UCase(Me.dgdLoadingPlanData.Item("Container_Type", i).Value.ToString.Trim) = UCase(Type.Trim) Then
                    Count += 1
                End If
            Next
            Return Count
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function CopyBooking(ByVal OldBookingID As String) As Boolean
        Try
            Dim SQL As String
            SQL = "select * from containerOutboundNotify Where ContainerOutboundNotifyID= '" & OldBookingID & "' And Continued=1 "

            Dim rsold As New ADODB.Recordset
            rsold.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rsold.EOF Then
                Return False
            End If

            Dim rs As New ADODB.Recordset
            SQL = "select Top 1 * from ContainerOutboundNotify Where BookingNo='" & WaitBookingNo.Trim & "' And Wait=1"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                rs.AddNew()
                rs.Fields("ContainerOutBoundNotifyId").Value = NewId()
                rs.Fields("BookingNo").Value = WaitBookingNo.Trim
            End If

            For i As Integer = 0 To rs.Fields.Count - 1
                If UCase(rs.Fields(i).Name) = "CONTAINEROUTBOUNDNOTIFYID" Or UCase(rs.Fields(i).Name) = "BOOKINGNO" Then
                    Continue For
                End If
                With rs
                    .Fields(i).Value = rsold.Fields(i).Value
                End With
            Next
            With rs
                .Fields("SoLuong20GP").Value = GetContainerRowCount("20GP") - CInt(IIf(Me.txtSoLuong20GP.Text <> "", Me.txtSoLuong20GP.Text, 0))
                .Fields("SoLuong40GP").Value = GetContainerRowCount("40GP") - CInt(IIf(Me.txtSoLuong40GP.Text <> "", Me.txtSoLuong40GP.Text, 0))
                .Fields("SoLuong40HC").Value = GetContainerRowCount("40HC") - CInt(IIf(Me.txtSoLuong40HC.Text <> "", Me.txtSoLuong40HC.Text, 0))
                .Fields("SoLuong45HC").Value = GetContainerRowCount("45HC") - CInt(IIf(Me.txtSoLuong45HC.Text <> "", Me.txtSoLuong45HC.Text, 0))
                .Fields("SoLuong20RF").Value = GetContainerRowCount("20RF") - CInt(IIf(Me.txtSoLuong20RF.Text <> "", Me.txtSoLuong20RF.Text, 0))
                .Fields("SoLuong40RF").Value = GetContainerRowCount("40RF") - CInt(IIf(Me.txtSoLuong40RF.Text <> "", Me.txtSoLuong40RF.Text, 0))
                .Fields("SoLuong40RH").Value = GetContainerRowCount("40RH") - CInt(IIf(Me.txtSoLuong40RH.Text <> "", Me.txtSoLuong40RH.Text, 0))

                .Fields("Wait").Value = 1
                .Fields("Continued").Value = 0
                .Fields("BC").Value = "CL"
            End With


            rs.Update()
            rs.Close()
            rsold.Close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)

        End Try
    End Function
    Private Sub frmCancelBookingContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryLoadingPlanInfo()
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub
    Sub UpdateBooking()
        Try
            WaitBookingNo &= "W"
            CopyBooking(BookingId)

            Dim SQL As String
            SQL = "select * from containerOutboundNotify Where ContainerOutboundNotifyID= '" & BookingId & "' And Continued=1 "

            Dim rsold As New ADODB.Recordset
            rsold.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rsold.EOF Then
                Return
            End If
            With rsold
                .Fields("SoLuong20GP").Value = IIf(Me.txtSoLuong20GP.Text <> "", Me.txtSoLuong20GP.Text, 0)
                .Fields("SoLuong40GP").Value = IIf(Me.txtSoLuong40GP.Text <> "", Me.txtSoLuong40GP.Text, 0)
                .Fields("SoLuong40HC").Value = IIf(Me.txtSoLuong40HC.Text <> "", Me.txtSoLuong40HC.Text, 0)
                .Fields("SoLuong45HC").Value = IIf(Me.txtSoLuong45HC.Text <> "", Me.txtSoLuong45HC.Text, 0)
                .Fields("SoLuong20RF").Value = IIf(Me.txtSoLuong20RF.Text <> "", Me.txtSoLuong20RF.Text, 0)
                .Fields("SoLuong40RF").Value = IIf(Me.txtSoLuong40RF.Text <> "", Me.txtSoLuong40RF.Text, 0)
                .Fields("SoLuong40RH").Value = IIf(Me.txtSoLuong40RH.Text <> "", Me.txtSoLuong40RH.Text, 0)

                .Fields("SoLuong20OT").Value = IIf(Me.txtSoLuong20OT.Text <> "", Me.txtSoLuong20OT.Text, 0)

                .Fields("SoLuong40OT").Value = IIf(Me.txtSoLuong40OT.Text <> "", Me.txtSoLuong40OT.Text, 0)

                .Fields("SoLuong20FR").Value = IIf(Me.txtSoLuong20FR.Text <> "", Me.txtSoLuong20FR.Text, 0)

                .Fields("SoLuong40FR").Value = IIf(Me.txtSoLuong40FR.Text <> "", Me.txtSoLuong40FR.Text, 0)
                .Update()
            End With
            rsold.Close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub UpdateLoadingPlan()
        Try
            Dim SQL As String
            SQL = "select * from LOADINGPLANFORVESSEL Where ContainerOutboundNotifyID= '" & BookingId & "' And Continued=1 "

            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                Return
            End If
            With rs
                For i As Integer = 0 To Me.dgdLoadingPlanData.RowCount - 1
                    .MoveFirst()
                    While Not .EOF
                        If "{" & UCase(Me.dgdLoadingPlanData.Item("LOADINGPLANFORVESSELID", i).Value.ToString.Trim) & "}" = UCase(.Fields("LOADINGPLANFORVESSELID").Value.ToString.Trim) Then
                            .Fields("Cancel").Value = Me.dgdLoadingPlanData.Item("Cancel", i).Value
                            .Update()
                        End If
                        .MoveNext()
                    End While
                Next
            End With
            rs.Close()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            UpdateBooking()
            UpdateLoadingPlan()
            Me.Close()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdLoadingPlanData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdLoadingPlanData.CellContentClick
        Try
            If Me.dgdLoadingPlanData.RowCount = 0 Then
                Return
            End If
            Dim Colindex As Integer
            Dim RowIndex As Integer
            Colindex = e.ColumnIndex()
            RowIndex = e.RowIndex
            If Colindex < 0 Then
                Return
            End If
            If Me.dgdLoadingPlanData.Columns(Colindex).Name = "Cancel" And Me.dgdLoadingPlanData.CurrentCellAddress().Y = RowIndex Then
                Me.dgdLoadingPlanData.CurrentCell.Value = Not Me.dgdLoadingPlanData.CurrentCell.Value
                CountContainer()
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub dgdLoadingPlanData_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdLoadingPlanData.RowValidated

    End Sub
End Class