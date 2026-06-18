Public Class frmEditETAInbound

    Function CheckBoardingAgent(ByVal Vessel As String, ByVal VoyNo As String, ByVal CompareETA As Date) As Boolean
        Try
            Dim SQL As String
            SQL = "Select Top 1 * "
            SQL &= " from BoardingAgent "
            SQL &= " Where Continued=1 and Vessel='" & Vessel & "' And VoyageNoOnArrival='" & VoyNo & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Dim BoardingDateAD, ETAIBDate As Date
            If dt.Rows(0).Item("DateOfBerthAD").ToString.Trim = "" Then 'nếu không có ngày ETA
                Return False
            End If
            If dt.Rows(0).Item("ApproveETA") = 1 Then 'nếu approve ETA =1 thì hai ETAIb dc phép khác ETA Boarding Agent
                Return True
            End If

            BoardingDateAD = CDate(dt.Rows(0).Item("DateOfArrivalAD").ToString) ' ngay tau den thong thuong =dateofberthad
            ETAIBDate = CompareETA

            If BoardingDateAD.Day <> ETAIBDate.Day Or BoardingDateAD.Month <> ETAIBDate.Month Or BoardingDateAD.Year <> ETAIBDate.Year Then 'nếu ngày ETA Inbound khác ETA trong Boarding Agent
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub UpdateContainerMNG(ByVal Vessel As String, ByVal VoyNo As String)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()

            Dim strSQL As String
            strSQL = " Update ContainerManagerment set Arrival_Date='" & Me.dtpETA.Value.Date & "' ,DisCharge_Date='" & Me.dtpETA.Value.Date & "' "
            strSQL &= " where  Continued=1 And Vessel_Inbound='" & Vessel.Trim & "' And VoyNo_Inbound='" & VoyNo.Trim & "'"
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub UpdateSchedule(ByVal Vessel As String, ByVal VoyNo As String)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()

            Dim strSQL As String
            strSQL = " Update ScheduleCheck set ETA='" & Me.dtpETA.Value.Date & "' "
            strSQL &= " where  Continued=1 And Vesselinbound='" & Vessel.Trim & "' And VoyNo='" & VoyNo.Trim & "'"
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryVessel()
        Try
            Dim oTableVessel As New DataTable
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select Distinct Vessel + ' - ' +  VOYAGE as data"
            strSQL &= " From BillOfLadingIB Where Continued=1 Order by DATA "
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            If oTableVessel.Rows.Count > 0 Then
                oTableVessel.Rows.Clear()
            End If
            Adapter.Fill(oTableVessel)
            Me.cboVessel.DisplayMember = "data"
            Me.cboVessel.DataSource = oTableVessel
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub UpdateETA()
        Try
            Dim temp() As String
            temp = Strings.Split(Me.cboVessel.Text, " - ")
            If temp.Length < 2 Then
                DisplayMessage(True, "vessel Is not in database")
                Return
            End If
            'If CheckBoardingAgent(temp(0).Trim, temp(1).Trim, Me.dtpETA.Value.Date) = False Then
            '    MsgBox("ETA is Invalid, Contact boarding Agent deparment for more infomation")
            '    'Return
            'End If


            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strSQL As String
            strSQL = " Update BillOfLadingIB set ETA='" & Me.dtpETA.Value.Date & "'"
            'temp(0)=vessel ,Temp(1)=VoyAge
            strSQL &= " where  Continued=1 And Vessel='" & temp(0).Trim & "' And VoyAge='" & temp(1).Trim & "'"
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            Dim i As Integer
            i = cmd.ExecuteNonQuery()

            'UpdateContainerMNG(temp(0), temp(1))
            'UpdateSchedule(temp(0), temp(1))
            MsgBox("Updated!!!")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmEditETAInbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        UpdateETA()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try

            Dim temp() As String
            temp = Strings.Split(Me.cboVessel.Text, " - ")

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select distinct ETA as data"
            strSQL &= " From BillOfLadingIB "
            'temp(0)=vessel ,Temp(1)=VoyAge
            strSQL &= " where  Continued=1 And Vessel='" & temp(0).Trim & "' And VoyAge='" & temp(1).Trim & "'"

            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dtpETA.Text = dt.Rows(0).Item("data")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class