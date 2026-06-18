Public Class frmHandlingChargeInboundTransit

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = " Select   distinct Vessel + '-' + VoyAge as Data,ETA "
            SQL &= " From BillOfLadingIB "
            SQL &= " Where BillOfLadingIB.Continued=1 and  TranSit=1 "
            SQL &= " And Convert(DateTime,ETA) +1 >'" & Me.dtpFromETA.Value.Date & "' And Convert(DateTime,ETA)-1 < '" & Me.dtpToETA.Value.Date & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryData()
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            Dim Temp() As String
            Temp = Me.cboVessel.Text.Split("-")
            If Temp.Length < 2 Then
                Return
            End If
            Dim SQL As String
            SQL = " Select BLIB_NO,Container_No,Container_Type as Type ,ETA "
            SQL &= " From (( BillOfLadingIB Left Join CargoIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID)"
            SQL &= " Left Join Container On Container.CTN_ID=CargoIB.CTN_ID)"
            SQL &= " Where BillOfLadingIB.Continued=1 And CargoIB.Continued=1 And TranSit=1 And Vessel='" & Temp(0) & "' And VoyAge='" & Temp(1) & "' "
            'SQL &= " And Convert(DateTime,ETA) +1 >'" & Me.dtpFromETA.Value.Date & "' And Convert(DateTime,ETA)-1 < '" & Me.dtpToETA.Value.Date & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Dim f As Double
            dt.Columns.Add("Fee", f.GetType())
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("Fee") = IIf(Me.txtFee.Text.Trim = "", 0, CDbl(Me.txtFee.Text.Trim))
            Next
            Me.dgdData.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdData)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtFee.Text.Trim = "" Then
            MsgBox("Fee Have to have a value")
            Return
        End If
        QueryData()
    End Sub


    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgdData, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmHandlingChargeInboundTransit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub dtpFromETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETA.ValueChanged
        QueryVessel()
    End Sub

    Private Sub dtpToETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETA.ValueChanged
        QueryVessel()
    End Sub
End Class