Public Class frmDailyBookingForeCastReport


    Sub QueryMotherService()
        Try
            Dim SQL As String
            SQL = "Select Distinct Service From MotherSailingSchedule Where Continued=1 Order By Service"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboMotherService.DisplayMember = "Service"
            Me.cboMotherService.ValueMember = "Service"
            Me.cboMotherService.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "MotherSailingScheduleID"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select MotherSailingScheduleID,Vessel + '-' + MotherVesselNo as value "
        strSQL = strSQL & " From MotherSailingSchedule,vessel "
        strSQL &= "where MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID and  MotherSailingSchedule.Continued=1 And Service='" & Me.cboMotherService.Text & "'"
        strSQL &= " Order By Vessel_Code desc"
        'loadDataToObject(Me.cboVessel, strSQL, id, value)
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboVessel.DisplayMember = value
        Me.cboVessel.ValueMember = id
        Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim strSQL As String
            strSQL = "Select MotherSailingScheduleID,Vessel + '-' + MotherVesselNo as value "
            strSQL &= " From MotherSailingSchedule,vessel "
            strSQL &= "where MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID and  MotherSailingSchedule.Continued=1 And OceanETD='" & Me.dtpLeavingDate.Value.Date & "'"
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            Else
                MsgBox("there is No MotherSailingSchedule For The OceanETD :" & Me.dtpLeavingDate.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        On Error GoTo Err_named
        Dim Ves_ID As String
        If Me.cboVessel.Text = "" Then
            Return
        End If
        Dim Temp() As String
        Temp = Strings.Split(Me.cboVessel.Text, "-")
        Me.txtVoyNo.Text = Temp(Temp.Length - 1)
        Dim Vsl As String = ""
        For i As Integer = 0 To Temp.Length - 2
            Vsl &= Temp(i)
        Next
        Me.txtVesselName.Text = Vsl
        Me.txtETD.Text = Me.dtpLeavingDate.Value.Date
        Me.txtService.Text = Me.cboMotherService.Text

        Ves_ID = Me.cboVessel.SelectedValue.ToString
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        If Ves_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select OceanETD "
            strQuery &= "from MotherSailingSchedule "
            strQuery &= "Where MotherSailingScheduleID='" & Ves_ID & "' And MotherSailingSchedule.Continued=1 "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = table.Rows(0).Item("OceanETD").ToString
            End If
            '  query stranship
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmDailingBookingForeCastReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryMotherService()

    End Sub

    Private Sub cboMotherService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMotherService.SelectedIndexChanged
        QueryVessel()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim SQL As String
            SQL = "select Distinct destination,sum(SoLuong20GP) as [20GP],sum(SoLuong40GP) as [40GP],sum(SoLuong40HC) as [40HC],sum(SoLuong20RF) as [20RF],sum(SoLuong40RF) as [40RF],sum(SoLuong40RH) as [40RH],sum(SoLuong45HC) as [45HC] "
            'SQL &= " ,Market,Tranship,PortOfUnLoading,Destination,ETD,ETA,POL,Operator,Service "
            SQL &= " from (ContainerOutBoundNotify LEFT JOIN Market On ContainerOutBoundNotify.Market_ID=Market.Market_ID)"
            'SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " Where ContainerOutBoundNotify.Continued=1 And ContainerOutBoundNotify.Editable=1 And ContainerOutBoundNotify.MotherSailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' "
            SQL &= " Group By destination   Order By destination"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.DataGridView1.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class