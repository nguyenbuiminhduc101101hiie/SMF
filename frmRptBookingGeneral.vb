Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptBookingGeneral
    Dim oTableContainer As New DataTable
    Const strContainerSelect = "Select ContainerManagerMent.Container_No,CTN_SIZE_TYPE,Vessel_Inbound,VoyNo_Inbound," & _
    "Arrival_Date As ETA,BL_NO_Inbound,CargoIB.GROSSWEIGHT As WeightIB,CargoIB.MEAS As MeasIB" & _
     ",BL_NO_Outbound,Vessel_Outbound,VoyNo_Outbound,Cargo.GROSS As WeightOB,Cargo.CTN_CARGO_MEASUREMENT As MeasOB," & _
      "BillOflading.Load_Date As ETDOB, OceanVessel,OceanVoyno as OceanVesselVoyNo,OceanETD, " & _
      " soundContainer=case when soundContainer=1 then 'Y' end" & _
",TobeInSpected=case when TobeInSpected =1 then 'Y' end" & _
",DamageContainer=case when DamageContainer =1 then 'Y' end" & _
",FullImport=case when FullImport =1 then 'Y' end" & _
",FullToConsignee=case when FullToConsignee =1 then 'Y' end" & _
",FullExport=case when FullExport =1 then 'Y' end" & _
",EmptyToShipper=case when EmptyToShipper =1 then 'Y' end" & _
",EmptyContainerReposit=case when EmptyContainerReposit =1 then 'Y' end "

    Function MakeQueryContainer(Optional ByVal argCriteria As String = "") As String
        On Error GoTo Err_Renamed
        MakeQueryContainer = strContainerSelect
        MakeQueryContainer = MakeQueryContainer & " From (((ContainerManagerMent Left JOIN CargoIB  on ContainerManagerMent.CargoIB_ID=CargoIB.CargoIB_ID)"
        MakeQueryContainer = MakeQueryContainer & " LEFT JOIN BillOfLading On BillOfLading.BL_NO=BL_NO_Outbound) "
        MakeQueryContainer = MakeQueryContainer & " LEFT JOIN Cargo On ContainerManagerMent.Cargo_ID=Cargo.Cargo_ID )"
        MakeQueryContainer = MakeQueryContainer & " WHERE "
        MakeQueryContainer = MakeQueryContainer & " ContainerManagerMent.Continued = 1 And ContainerManagerMent.Container_No='" & frmRptGeneral.cboContainer_No.Text.Trim & "'"
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryContainer = MakeQueryContainer & argCriteria
        End If
        'ElseIf index = 15 Then ' 
        '    MakeQueryContainer = MakeQueryContainer & strContainerOutboundNotifyOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Sub QueryContainer(Optional ByVal argCriteria As String = "")
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryContainer()
        Else
            strQuery = MakeQueryContainer(argCriteria)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Not IsNothing(oTableContainer) Then
            oTableContainer.Clear()
        End If
        Adapter.Fill(oTableContainer)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmRptBookingGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim rpt As New 
        '-------------
        Dim rpt As New ReportDocument
        Dim strReportName As String
        Dim strQuery As String
        ' ten Report
        strReportName = "ReportGeneral"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rpt.Load(strReportPath)
        '--------------
        QueryContainer()
        rpt.SetDataSource(oTableContainer)
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.Show()

    End Sub
End Class