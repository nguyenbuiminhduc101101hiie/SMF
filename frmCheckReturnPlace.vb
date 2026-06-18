Public Class frmCheckReturnPlace

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "select SailingScheduleID as ID, Vessel + ' - ' + VoyNo as Data "
            SQL &= "from (SailingSchedule LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID ) where SailingSchedule.Continued=1 Order By Vessel,VoyNo"
            Dim oTable As New DataTable
            oTable = ReadTable(SQL)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.ValueMember = "ID"
            Me.cboVessel.DataSource = oTable
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryAddContainer(Optional ByVal Dk As String = "")
        Try
            Dim strQuery As String
            strQuery = "Select LOADINGPLANFORVESSELID,LOADINGPLANFORVESSEL.CTN_ID,BookingNo,Ventilation,ContainerOutboundNotify.Cold,Seal,Container_No,CTN_SIZE_TYPE, LOADINGPLANFORVESSEL.Delay,Cancel,DateOfSupplyEmptyContainer,PLACESUPPLYEMPTYCONTAINER,RETURNPLACE,ContainerOutboundNotify.CustomsLiquiDate,DelayDate, "
            strQuery &= "LOADINGPLANFORVESSEL.Continued,LOADINGPLANFORVESSEL.Editable,LOADINGPLANFORVESSEL.Approve,LOADINGPLANFORVESSEL.UserID,LOADINGPLANFORVESSEL.UpdateTime "
            strQuery &= " From ((LOADINGPLANFORVESSEL LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyid=LOADINGPLANFORVESSEL.ContainerOutboundNotifyid)"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID )"
            strQuery &= " Where LOADINGPLANFORVESSEL.Continued=1 And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            'If mContainerOutboundNotify <> DefaultValue Then
            '    strQuery &= " and LOADINGPLANFORVESSEL.ContainerOutboundNotifyid='" & mContainerOutboundNotify & " '"
            'End If
            If Dk <> "" Then
                strQuery &= Dk
            End If
            Dim oTable As New DataTable
            oTable = ReadTable(strQuery)
            'mContainerOutboundNotify = DefaultValue
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            '' Dim dt As New DataTable
            'If dsdata.Tables("dtContainerAdd").Rows.Count > 0 Then
            '    dsdata.Tables("dtContainerAdd").Rows.Clear()
            'End If
            'Adapter.Fill(dsdata.Tables("dtContainerAdd"))
            Me.dgdAddContainer.DataSource = oTable
            InsertAutoNumberToGrid(Me.dgdAddContainer)
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub frmCheckReturnPlace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        SetDefaultGrid(Me.dgdAddContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        QueryAddContainer()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdAddContainer.RowCount > 0 Then
                'SetMenu(False)
                Me.Cursor = Cursors.WaitCursor
                ExportExecel(Me.dgdAddContainer, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class