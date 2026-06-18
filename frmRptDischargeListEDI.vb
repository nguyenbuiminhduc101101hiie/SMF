Public Class frmRptDischargeListEDI
    Dim dt As New DataTable
    Sub QueryDischargeList()
        Try
            Dim strQuery As String
            strQuery = "SELECT CONTAINER_NO ,CONTAINER_TYPE ,SEAL,POL,DEST,BLIB_NO,SEAL,POL,DEST,BLIB_NO,VESSEL,VOYAGE,ETA ,ICDPORT,"
            strQuery &= "QUANTITY20GP=CASE  CONTAINER_TYPE WHEN '20GP' THEN 1 END,"
            strQuery &= "QUANTITY40GP=CASE  CONTAINER_TYPE WHEN '40GP' THEN 1 END,"
            strQuery &= "QUANTITY20RF=CASE  CONTAINER_TYPE WHEN '20RF' THEN 1 END,"
            strQuery &= "QUANTITY40RH=CASE  CONTAINER_TYPE WHEN '40RH' THEN 1 END,"
            strQuery &= "QUANTITY40HC=CASE  CONTAINER_TYPE WHEN '40HC' THEN 1 END,"
            strQuery &= "QUANTITY40RF=CASE  CONTAINER_TYPE WHEN '40RF' THEN 1 END "
            strQuery &= "FROM ((BILLOFLADINGIBEDI INNER JOIN CARGOIB ON BILLOFLADINGIBEDI.BLIB_ID=CARGOIB.BLIB_ID) "
            strQuery &= " INNER JOIN CONTAINER ON CONTAINER.CTN_ID = CARGOIB.CTN_ID) "
            strQuery &= " WHERE BILLOFLADINGIBEDI.BLIB_ID='" & gBillInboundID & "' Order By BILLOFLADINGIBEDI.STT,CargoIB.STT"
            Dim conn As New SqlClient.SqlConnection(strconnDG)
            conn.Open()
            Dim cmdselect As New SqlClient.SqlCommand(strQuery, conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdselect)
            If Not IsNothing(dt) Then
                dt.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub frmRptDischargeListEDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim rpt As New ReportDischargeList
            'QueryDischargeList()

            'rpt.SetDataSource(dt)
            'Me.CrystalReportViewer1.ReportSource = rpt
            'Me.CrystalReportViewer1.Refresh()
            'Me.CrystalReportViewer1.Show()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
End Class