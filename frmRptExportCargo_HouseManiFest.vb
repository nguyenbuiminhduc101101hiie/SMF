Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptExportCargo_HouseManiFest
    '------------------
    Public oTableBillOfLading As DataTable
    Public dsBillOfLading As New DataSet
    '------------------
    Public oTableCargoInfo As DataTable
    Public dsCargoInfo As New DataSet
    '------------------
    Public oTableCustomerInfo As DataTable
    Public dsCustomerInfo As New DataSet
    '------------------
    Public oTableCargoMarks As DataTable
    Public dsCargoMarks As New DataSet
    '------------------
    Public oTableCargoDescription As DataTable
    Public dsCargoDescription As New DataSet
    '------------------
    Public oTableFreightCharge As DataTable
    Public dsFreightCharge As New DataSet

    Public oTableUnit, oTablePrice As DataTable

    Const strFreightCharge As String = "Select DISTINCT Charge.Charge_Code as Item," & _
    "FREIGHT_CHARGE_House.CURRENCY as CURRENCY, " & _
    "FREIGHT_CHARGE_House.Container_Type as ContainerType,Unit," & _
    "FREIGHT_CHARGE_House.PREPAID_COLLECT,PAYER_CODE,POP," & _
    " FREIGHT_CHARGE_House.AMOUNT as UnitPrice  "

    Const strCustomerInfo As String = "Select Shipper.Shipper_1, " & _
    "Shipper.Shipper_2 , Shipper.Shipper_3,Shipper.Shipper_4," & _
        "Shipper.Shipper_5 , " & _
        "Shipper.Shipper_6 ,shipper.remarks as sr, " & _
    "Consignee.Consignee_1, " & _
        "Consignee.Consignee_2 , Consignee.Consignee_3,Consignee.Consignee_4," & _
        "Consignee.Consignee_5 , " & _
        "Consignee.Consignee_6 ,consignee.remarks as cr, " & _
    "Notify.Notify_1 , " & _
        "Notify.Notify_2, Notify.Notify_3,Notify.Notify_4," & _
        "Notify.Notify_5, " & _
        "Notify.Notify_6 , notify.remarks as nr "


    Const strBillOfLadingSelect As String = "SELECT BillOfLading_House.BLH_Id as BillOfLadingId,BillOfLading_House.BL_ID,BL_NO,BillOfLading_House.BLH_NO , " & _
"Vessel.Vessel As Pre_Vessel,SailingSchedule.VoyNo as Pre_VoyNo, " & _
    "ContainerOutboundNotify.ServiceContract As ServiceContract, " & _
    "billoflading_house.load_date as SailingDate," & _
    "BillOfLading_House.PLACE_OF_RECEIPT_NAME, BillOfLading_House.BL_CY_CFS_ITEM As Clause," & _
    "BillOfLading_House.PLACE_OF_RECEIPT_CODE," & _
    "BillOfLading_House.PLACE_OF_RECEIPT_CODE," & _
    "BillOfLading_House.Port_Of_Discharge_CODE," & _
    "BillOfLading_House.Place_Of_Delivery_CODE," & _
    "BillOfLading_House.PLACE_OF_DESTINATION_CODE," & _
    "BillOfLading_House.Port_Of_Loading_Code," & _
    "BillOfLading_House.Port_Of_Loading_Name,BillOfLading_House.PLACE_OF_DESTINATION_NAME, " & _
       "BillOfLading_House.Port_Of_Discharge_Name, " & _
       "BillOfLading_House.Place_Of_Delivery_Name, " & _
       "BillOfLading_House.PLACE_OF_DESTINATION_NAME, " & _
       "BillOfLading_House.DESCRIPTIONFORSHIPPER, " & _
       "BillOfLading_House.REVENUETON, BillOfLading_House.ToTalContainer,BillOfLading_House.PreightCharges," & _
       "BillOfLading_House.EXCHANGE_RATE, BillOfLading_House.BL_TYPE, " & _
      "BillOfLading_House.PrepaidAt,BillOfLading_House.PREPAID_OR_COLLECT As FClause, BillOfLading_House.SCAC_CODE,BillOfLading_House.CANVASSERCODE, " & _
       "BillOfLading_House.PAYABLE_AT, BillOfLading_House.TRANSFER_PORT1,BillOfLading_House.TRANSFER_PORT2,BillOfLading_House.TRANSFER_PORT3,BillOfLading_House.TRANSFER_PORT4," & _
       "BillOfLading_House.PLACE_OF_BL_ISSUE_NAME, BillOfLading_House.Port_Of_Loading_Code as Port_From,BillOfLading_House.PLACE_OF_DESTINATION_CODE as Port_To," & _
     "BillOfLading_House.DATE_OF_ISSUE, " & _
       "BillOfLading_House.TOTALPREPAID_IN, " & _
       "BillOfLading_House.NO_OF_ORIGINAL_BL, BillOfLading_House.NO_OF_COPY_BL "
    Const strCargo As String = "Select Container.CONTAINER_NO,Seal.SealNo,Container_Type as CTN_SIZE_TYPE," & _
    "Amount,Kind,Cargo_House.Vent,CARGO_GROSS_WEIGHT,GROSS,UNIT_GROSS,CARGO_RECEVING_DATE,Note,CTN_CARGO_MEASUREMENT,ReeferDegree,TEMPERATURE_SETTING "

    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = strBillOfLadingSelect
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading_House left join ContainerOutboundNotify on BillOfLading_House.ContainerOutboundNotifyid=ContainerOutboundNotify.ContainerOutboundNotifyid )"
        MakeQueryBillOfLading = MakeQueryBillOfLading & "left join SailingSchedule on ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " left join Vessel on Vessel.Vessel_ID=SailingSchedule.Vessel_Id) left join billoflading on billoflading.bl_id=billoflading_house.bl_id "

        MakeQueryBillOfLading = MakeQueryBillOfLading & "WHERE (BillOfLading_House.BLH_ID = '" & gBillOfLadingHouseRpt & "') "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "And ("
        MakeQueryBillOfLading = MakeQueryBillOfLading & "BillOfLading_House.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading() & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function MakeQueryCargo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryCargo = strCargo
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryCargo = MakeQueryCargo & " FROM ((Cargo_House left join Container on Cargo_House.CTN_ID=Container.CTN_ID )"
        MakeQueryCargo = MakeQueryCargo & "left join Seal on Cargo_House.Seal_ID=Seal.Seal_ID ) "
        'MakeQueryCargo = MakeQueryCargo() & " left join Vessel on Vessel.Vessel_ID=NotifyVessel.Vessel_Id) "

        MakeQueryCargo = MakeQueryCargo & "WHERE (Cargo_House.BLH_ID = '" & gBillOfLadingHouseRpt & "') "
        MakeQueryCargo = MakeQueryCargo & "And ("
        MakeQueryCargo = MakeQueryCargo & "Cargo_House.Continued = 1 "
        MakeQueryCargo = MakeQueryCargo & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCargo = MakeQueryCargo() & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function MakeQueryFreightCharge(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryFreightCharge = strFreightCharge
        'MakeQueryFreightCharge = MakeQueryFreightCharge & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryFreightCharge = MakeQueryFreightCharge & " FROM (FREIGHT_CHARGE_House left join Charge on Charge.Charge_ID=FREIGHT_CHARGE_House.Charge_ID) "
        'MakeQueryFreightCharge = MakeQueryFreightCharge & " "
        'MakeQueryFreightCharge = MakeQueryFreightCharge & " "
        MakeQueryFreightCharge = MakeQueryFreightCharge & "WHERE (FREIGHT_CHARGE_House.BLH_ID = '" & gBillOfLadingHouseRpt & "') "
        MakeQueryFreightCharge = MakeQueryFreightCharge & "And ("
        MakeQueryFreightCharge = MakeQueryFreightCharge & "FREIGHT_CHARGE_House.Continued = 1 "
        MakeQueryFreightCharge = MakeQueryFreightCharge & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryFreightCharge = MakeQueryFreightCharge & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM (((BillOfLading_House LEFT JOIN Shipper On BillOfLading_House.Shipper_ID=Shipper.Shipper_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Consignee On Consignee.Consignee_ID=BillOfLading_House.Consignee_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Notify On Notify.Notify_ID=BillOfLading_House.Notify_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLading_House.BLH_ID= '" & gBillOfLadingHouseRpt & "' And BillOfLading_House.Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Sub QueryCargoMarks(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select MARKS from CARGOHOUSE_MARKS Where BLH_ID='" & gBillOfLadingHouseRpt & "'"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoMarks) Then
            oTableCargoMarks.Clear()
        End If
        Adapter.Fill(dsCargoMarks, "CargoMarks")
        oTableCargoMarks = dsCargoMarks.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryUnit(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select CTN_SIZE_TYPE as type,Count(CTN_SIZE_TYPE) as Num from (container LEFT JOIN Cargo_House on Cargo_House.CTN_ID=Container.CTN_ID) where Cargo_House.BLH_ID='" & gBillOfLadingHouseRpt & "' Group by CTN_SIZE_TYPE"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableUnit) Then
            oTableUnit.Clear()
        End If
        Adapter.Fill(ds, "CargoMarks")
        oTableUnit = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCargoDescription(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Description from CARGOHouse_DESCRIPTION Where BLH_ID='" & gBillOfLadingHouseRpt & "' "
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoDescription) Then
            oTableCargoDescription.Clear()
        End If
        Adapter.Fill(dsCargoDescription, "CargoDesc")
        oTableCargoDescription = dsCargoDescription.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub QueryFreightCharge(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryFreightCharge()
        Else
            strQuery = MakeQueryFreightCharge(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableFreightCharge) Then
            oTableFreightCharge.Clear()
        End If
        Adapter.Fill(dsFreightCharge, "BillOfLadingList")
        oTableFreightCharge = dsFreightCharge.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
   

    Private Sub QueryCargo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCargo()
        Else
            strQuery = MakeQueryCargo(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoInfo) Then
            oTableCargoInfo.Clear()
        End If
        Adapter.Fill(dsCargoInfo, "BillOfLadingList")
        oTableCargoInfo = dsCargoInfo.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub QueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryBillOfLading()
        Else
            strQuery = MakeQueryBillOfLading(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableBillOfLading) Then
            oTableBillOfLading.Clear()
        End If
        Adapter.Fill(dsBillOfLading, "BillOfLadingList")
        oTableBillOfLading = dsBillOfLading.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub QueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCustomerInfo()
        Else
            strQuery = MakeQueryCustomerInfo(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCustomerInfo) Then
            oTableCustomerInfo.Clear()
        End If
        Adapter.Fill(dsCustomerInfo, "BillOfLadingList")
        oTableCustomerInfo = dsCustomerInfo.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub


    Sub QueryNotify(ByRef dt As DataTable, ByVal NotifyID As String)
        Dim strQuery As String
        strQuery = " Select top 1 Notify.Notify_1 ,Notify.Notify_2, Notify.Notify_3,Notify.Notify_4,Notify.Notify_5,Notify.Notify_6, remarks "
        strQuery &= " From (BillOfLading_House LEFT JOIN Notify On BillOfLading_House." & NotifyID & "=Notify.Notify_ID) "
        strQuery &= " Where BillofLading_House.Continued=1 And BLH_ID='" & gBillOfLadingHouseRpt & "' And Notify.Notify_ID <>'" & DefaultValue & "'"

        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
        Dim Adapter As New SqlClient.SqlDataAdapter(cmd)

        Try
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()
            Adapter.Dispose()
            Conn = Nothing
            cmd = Nothing
            Adapter = Nothing
        End Try
    End Sub

    Private Sub frmRptExportCargoManiFest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        Dim strReportName As String
        Dim strQuery As String
        Dim rptDocument As New ReportDocument
        ' ten Report
        strReportName = "ReportHX-ExportCargo_House"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rptDocument.Load(strReportPath)
        '-----------------
        QueryCustomerInfo()
        QueryBillOfLading()
        QueryCargo()
        QueryFreightCharge()
        QueryCargoMarks()
        QueryUnit()

        QueryCargoDescription()
        Dim Shipper_1 As TextObject
        Dim Shipper_2 As TextObject
        Dim Shipper_3 As TextObject
        Dim Shipper_4 As TextObject
        Dim Shipper_5 As TextObject
        Dim Shipper_6 As TextObject
        Dim Consignee_1 As TextObject
        Dim Consignee_2 As TextObject
        Dim Consignee_3 As TextObject
        Dim Consignee_4 As TextObject
        Dim Consignee_5 As TextObject
        Dim Consignee_6 As TextObject

        Dim Notify_1 As TextObject
        Dim Notify_2 As TextObject
        Dim Notify_3 As TextObject
        Dim Notify_4 As TextObject
        Dim Notify_5 As TextObject
        Dim Notify_6 As TextObject
        If oTableCustomerInfo.Rows.Count > 0 Then

            Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            Shipper_1.Text = oTableCustomerInfo.Rows(0).Item("Shipper_1").ToString
            Shipper_2 = rptDocument.ReportDefinition.ReportObjects("Shipper_2")
            Shipper_2.Text = oTableCustomerInfo.Rows(0).Item("Shipper_2").ToString
            Shipper_3 = rptDocument.ReportDefinition.ReportObjects("Shipper_3")
            Shipper_3.Text = oTableCustomerInfo.Rows(0).Item("Shipper_3").ToString
            Shipper_4 = rptDocument.ReportDefinition.ReportObjects("Shipper_4")
            Shipper_4.Text = oTableCustomerInfo.Rows(0).Item("Shipper_4").ToString
            Shipper_5 = rptDocument.ReportDefinition.ReportObjects("Shipper_5")
            Shipper_5.Text = oTableCustomerInfo.Rows(0).Item("Shipper_5").ToString
            Shipper_6 = rptDocument.ReportDefinition.ReportObjects("Shipper_6")
            Shipper_6.Text = oTableCustomerInfo.Rows(0).Item("sr").ToString

            Consignee_1 = rptDocument.ReportDefinition.ReportObjects("Consignee_1")
            Consignee_1.Text = oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString
            Consignee_2 = rptDocument.ReportDefinition.ReportObjects("Consignee_2")
            Consignee_2.Text = oTableCustomerInfo.Rows(0).Item("Consignee_2").ToString
            Consignee_3 = rptDocument.ReportDefinition.ReportObjects("Consignee_3")
            Consignee_3.Text = oTableCustomerInfo.Rows(0).Item("Consignee_3").ToString
            Consignee_4 = rptDocument.ReportDefinition.ReportObjects("Consignee_4")
            Consignee_4.Text = oTableCustomerInfo.Rows(0).Item("Consignee_4").ToString
            Consignee_5 = rptDocument.ReportDefinition.ReportObjects("Consignee_5")
            Consignee_5.Text = oTableCustomerInfo.Rows(0).Item("Consignee_5").ToString
            Consignee_6 = rptDocument.ReportDefinition.ReportObjects("Consignee_6")
            Consignee_6.Text = oTableCustomerInfo.Rows(0).Item("cr").ToString

            Notify_1 = rptDocument.ReportDefinition.ReportObjects("Notify_1")
            Notify_1.Text = oTableCustomerInfo.Rows(0).Item("Notify_1").ToString
            Notify_2 = rptDocument.ReportDefinition.ReportObjects("Notify_2")
            Notify_2.Text = oTableCustomerInfo.Rows(0).Item("Notify_2").ToString
            Notify_3 = rptDocument.ReportDefinition.ReportObjects("Notify_3")
            Notify_3.Text = oTableCustomerInfo.Rows(0).Item("Notify_3").ToString
            Notify_4 = rptDocument.ReportDefinition.ReportObjects("Notify_4")
            Notify_4.Text = oTableCustomerInfo.Rows(0).Item("Notify_4").ToString
            Notify_5 = rptDocument.ReportDefinition.ReportObjects("Notify_5")
            Notify_5.Text = oTableCustomerInfo.Rows(0).Item("Notify_5").ToString
            Notify_6 = rptDocument.ReportDefinition.ReportObjects("Notify_6")
            Notify_6.Text = oTableCustomerInfo.Rows(0).Item("nr").ToString

            Dim ServiceContract, shipperREFH As TextObject
            shipperREFH = rptDocument.ReportDefinition.ReportObjects("shipperREFH")
            shipperREFH.Text = oTableBillOfLading.Rows(0).Item("bl_no").ToString

            ServiceContract = rptDocument.ReportDefinition.ReportObjects("ServiceContract")
            ServiceContract.Text = oTableBillOfLading.Rows(0).Item("ServiceContract").ToString

            Dim Sailing As TextObject
            Sailing = rptDocument.ReportDefinition.ReportObjects("SailingDate")
            Sailing.Text = oTableBillOfLading.Rows(0).Item("SailingDate").ToString.Trim '<> "", Strings.FormatDateTime(oTableBillOfLading.Rows(0).Item("SailingDate").ToString, DateFormat.ShortDate), "")

            Dim Clause As TextObject
            Clause = rptDocument.ReportDefinition.ReportObjects("Clause")
            Clause.Text = oTableBillOfLading.Rows(0).Item("Clause").ToString

            Dim BL_Type As TextObject
            BL_Type = rptDocument.ReportDefinition.ReportObjects("BLTYPE")
            BL_Type.Text = oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString

            Dim SCACCode As TextObject
            SCACCode = rptDocument.ReportDefinition.ReportObjects("SCACCode")
            SCACCode.Text = oTableBillOfLading.Rows(0).Item("SCAC_CODE").ToString

            Dim FClause As TextObject
            FClause = rptDocument.ReportDefinition.ReportObjects("FClause")
            FClause.Text = oTableBillOfLading.Rows(0).Item("FClause").ToString

            Dim CANVASSERCODE As TextObject
            CANVASSERCODE = rptDocument.ReportDefinition.ReportObjects("CANVASSERCODE")
            CANVASSERCODE.Text = oTableBillOfLading.Rows(0).Item("CANVASSERCODE").ToString


            If Me.oTableCargoInfo.Rows.Count > 0 Then
                For k As Integer = 0 To Me.oTableCargoInfo.Rows.Count - 1
                    Dim REF, V As Boolean
                    REF = False
                    V = False
                    If Me.oTableCargoInfo.Rows(k).Item("TEMPERATURE_SETTING").ToString <> "" Then
                        Dim RefDegree As TextObject
                        RefDegree = rptDocument.ReportDefinition.ReportObjects("REFDegree")
                        RefDegree.Text = Me.oTableCargoInfo.Rows(k).Item("TEMPERATURE_SETTING").ToString
                    End If
                    If oTableCargoInfo.Rows(k).Item("Vent").ToString <> "" Then
                        Dim Vent As TextObject
                        Vent = rptDocument.ReportDefinition.ReportObjects("Vent")
                        Vent.Text = oTableCargoInfo.Rows(k).Item("Vent").ToString
                    End If
                    If REF And V Then
                        Exit For
                    End If
                Next
            End If


            Dim PortFrom As TextObject
            PortFrom = rptDocument.ReportDefinition.ReportObjects("PortFrom")
            PortFrom.Text = oTableBillOfLading.Rows(0).Item("Port_From").ToString

            Dim PortTo As TextObject
            PortTo = rptDocument.ReportDefinition.ReportObjects("PortTo")
            PortTo.Text = oTableBillOfLading.Rows(0).Item("Port_To").ToString


            Dim BL_NO As TextObject
            BL_NO = rptDocument.ReportDefinition.ReportObjects("BL_NO")
            BL_NO.Text = oTableBillOfLading.Rows(0).Item("BLH_NO")

            Dim vessel As TextObject
            vessel = rptDocument.ReportDefinition.ReportObjects("Vessel_VoyNo")
            vessel.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString & "  -  " & oTableBillOfLading.Rows(0).Item("Pre_VoyNo").ToString

            Dim receiport As TextObject
            receiport = rptDocument.ReportDefinition.ReportObjects("POR")
            receiport.Text = oTableBillOfLading.Rows(0).Item("PLACE_OF_RECEIPT_NAME").ToString
            receiport.Text &= "  -  " & oTableBillOfLading.Rows(0).Item("PLACE_OF_RECEIPT_CODE").ToString

            Dim portLoading As TextObject
            portLoading = rptDocument.ReportDefinition.ReportObjects("POL")
            portLoading.Text = oTableBillOfLading.Rows(0).Item("Port_Of_Loading_Name").ToString
            portLoading.Text &= "  -  " & oTableBillOfLading.Rows(0).Item("Port_Of_Loading_Code").ToString

            Dim PortDisCharge As TextObject
            PortDisCharge = rptDocument.ReportDefinition.ReportObjects("POD")
            PortDisCharge.Text = oTableBillOfLading.Rows(0).Item("Port_Of_Discharge_Name").ToString
            PortDisCharge.Text &= "  -  " & oTableBillOfLading.Rows(0).Item("Port_Of_Discharge_Code").ToString

            Dim Delivery As TextObject
            Delivery = rptDocument.ReportDefinition.ReportObjects("DEL")
            Delivery.Text = oTableBillOfLading.Rows(0).Item("Place_Of_Delivery_Name").ToString
            Delivery.Text &= "  -  " & oTableBillOfLading.Rows(0).Item("Place_Of_Delivery_Code").ToString

            Dim Destination As TextObject
            Destination = rptDocument.ReportDefinition.ReportObjects("DEST")
            Destination.Text = oTableBillOfLading.Rows(0).Item("PLACE_OF_DESTINATION_NAME").ToString
            Destination.Text &= "  -  " & oTableBillOfLading.Rows(0).Item("PLACE_OF_DESTINATION_CODE").ToString

            Dim Transport1 As TextObject
            Transport1 = rptDocument.ReportDefinition.ReportObjects("VIA1")
            Transport1.Text = oTableBillOfLading.Rows(0).Item("TRANSFER_PORT1").ToString

            Dim Transport2 As TextObject
            Transport2 = rptDocument.ReportDefinition.ReportObjects("VIA2")
            Transport2.Text = oTableBillOfLading.Rows(0).Item("TRANSFER_PORT2").ToString


            Dim Transport3 As TextObject
            Transport3 = rptDocument.ReportDefinition.ReportObjects("VIA3")
            Transport3.Text = oTableBillOfLading.Rows(0).Item("TRANSFER_PORT3").ToString


            Dim Transport4 As TextObject
            Transport4 = rptDocument.ReportDefinition.ReportObjects("VIA4")
            Transport4.Text = oTableBillOfLading.Rows(0).Item("TRANSFER_PORT4").ToString

            'Dim ShipperREF_H, ShipperREF_C As TextObject
            'ShipperREF_H = rptDocument.ReportDefinition.ReportObjects("ShipperREFH")
            'ShipperREF_H.Text = Shipper_H

            'ShipperREF_C = rptDocument.ReportDefinition.ReportObjects("ShipperREFC")
            'ShipperREF_C.Text = Shipper_C
        End If
        Dim Description As TextObject
        Dim Temp(), Result As String
        Result = ""
        Description = rptDocument.ReportDefinition.ReportObjects("Description1")
        If oTableCargoDescription.Rows.Count > 0 Then
            Dim tempTextObject As TextObject
            Result = oTableCargoDescription.Rows(0).Item("Description").ToString
            Temp = Strings.Split(Result, Chr(13))
            Result = ""
            For j As Integer = 0 To Temp.Length - 1

                Result &= Temp(j)
                For k As Integer = Temp(j).Length To Description.Width \ 10
                    Result &= " "
                Next

            Next

        End If

        'If oTableCargoMarks.Rows.Count > 0 Then
        '    Dim ShippingMarks As TextObject
        '    ShippingMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
        '    ShippingMarks.Text = oTableCargoMarks.Rows(0).Item("Marks").ToString
        'End If

        Dim ContainerNo, SealNo, ContainerType, Kg, Kind, CMB, GrossWeight, Receidate, Note As TextObject
        Dim DToTalKg As Double = 0
        Dim DTotalGross As Double = 0
        Dim DTotalCMB As Double = 0
        'for De in thong ti Cagro

        Dim SoContainer As Integer = 19
        Dim CountContainer As Integer = IIf(oTableCargoInfo.Rows.Count > SoContainer, SoContainer, oTableCargoInfo.Rows.Count)
        Dim ContainerAttach As Integer = oTableCargoInfo.Rows.Count - SoContainer

        Dim BillAttach, AmountAttach, GrossAttach, MeasAttach, DescAttach, TitleDesc, TitleAmount, TitleGross, TitleMeas, TitleContainer, TotalContainer As TextObject

        Dim TitleNotify2, TitleNotify3 As TextObject

        TitleNotify2 = rptDocument.ReportDefinition.ReportObjects("TitleNotify2")
        TitleNotify2.Text = ""

        TitleNotify3 = rptDocument.ReportDefinition.ReportObjects("TitleNotify3")
        TitleNotify3.Text = ""
        Dim AttckNotify2_, AttckNotify3_ As TextObject
        For i As Integer = 1 To 6
            AttckNotify2_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_" & i)
            AttckNotify2_.Text = ""
            AttckNotify3_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_" & i)
            AttckNotify3_.Text = ""
        Next

        BillAttach = rptDocument.ReportDefinition.ReportObjects("BillAttach")
        BillAttach.Text = ""

        AmountAttach = rptDocument.ReportDefinition.ReportObjects("AmountAttach")
        AmountAttach.Text = ""

        GrossAttach = rptDocument.ReportDefinition.ReportObjects("GrossAttach")
        GrossAttach.Text = ""

        MeasAttach = rptDocument.ReportDefinition.ReportObjects("MeasAttach")
        MeasAttach.Text = ""

        DescAttach = rptDocument.ReportDefinition.ReportObjects("DescAttach")
        DescAttach.Text = ""

        TitleAmount = rptDocument.ReportDefinition.ReportObjects("TitleAmount")
        TitleAmount.Text = ""

        TitleDesc = rptDocument.ReportDefinition.ReportObjects("TitleDesc")
        TitleDesc.Text = ""

        TitleGross = rptDocument.ReportDefinition.ReportObjects("TitleGross")
        TitleGross.Text = ""

        TitleMeas = rptDocument.ReportDefinition.ReportObjects("TitleMeas")
        TitleMeas.Text = ""

        TitleContainer = rptDocument.ReportDefinition.ReportObjects("TitleContainer")
        TitleContainer.Text = ""


        TotalContainer = rptDocument.ReportDefinition.ReportObjects("TotalContainerNo")
        TotalContainer.Text = ""

        Dim dtNotify, dtNotify3 As New DataTable
        QueryNotify(dtNotify, "Notify2_ID")
        QueryNotify(dtNotify3, "Notify3_ID")

        Dim Item, POP, Cur, ConType, UnitP, Unit, PrePaid, Collect, ToTal As TextObject

        Dim DToTalPre As Double = 0
        Dim DToTalCol As Double = 0
        Dim DToTalPrice As Double = 0
        Dim ValidFeeCount As Integer = 16 'số phí tối đa của một bill nếu lớn hơn 16 sẽ attach
        Dim FactCountFee As Integer 'số phí thực tế của 1 bill
        Dim popo As TextObject
        Dim textPopo As String = ""

        FactCountFee = oTableFreightCharge.Rows.Count
        Dim CurrentCountFee As Integer = 0
        For j As Integer = 0 To oTableFreightCharge.Rows.Count - 1

            Item = rptDocument.ReportDefinition.ReportObjects("Item" & j + 1)
            Item.Text = oTableFreightCharge.Rows(j).Item("Item").ToString.Trim

            'Item = rptDocument.ReportDefinition.ReportObjects("Item" & j + 1 - dem)
            'Item.Text = oTableFreightCharge.Rows(j).Item("Item").ToString.Trim
            If oTableFreightCharge.Rows(j).Item("POP").ToString <> "" Then
                textPopo = oTableFreightCharge.Rows(j).Item("POP").ToString
            End If
            Cur = rptDocument.ReportDefinition.ReportObjects("CURRENCY" & j + 1)
            Cur.Text = oTableFreightCharge.Rows(j).Item("CURRENCY").ToString.Trim


            ConType = rptDocument.ReportDefinition.ReportObjects("CargoConType" & j + 1)
            ConType.Text = oTableFreightCharge.Rows(j).Item("ContainerType").ToString.Trim

            Unit = rptDocument.ReportDefinition.ReportObjects("UNIT" & j + 1)
            Dim row As DataRow
            Dim ConNum As Integer = 0
            For Each row In oTableUnit.Rows
                If UCase(ConType.Text.Trim) = UCase(row.Item("Type")) Then
                    Unit.Text = row.Item("NUM").ToString
                    ConNum = row.Item("NUM")
                End If
            Next

            UnitP = rptDocument.ReportDefinition.ReportObjects("Price" & j + 1)
            UnitP.Text = Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice"), 2)

            If UCase(oTableFreightCharge.Rows(j).Item("PREPAID_COLLECT").ToString).Trim = "POP.O" Then

                POP = rptDocument.ReportDefinition.ReportObjects("POPO" & j + 1)
                POP.Text = Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * ConNum, 2)
            Else
                If UCase(oTableFreightCharge.Rows(j).Item("PREPAID_COLLECT").ToString).Trim = "COLLECT" Then
                    Collect = rptDocument.ReportDefinition.ReportObjects("PortTo" & j + 1)
                    Collect.Text = Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * ConNum, 2)
                    DToTalCol += Strings.FormatNumber(Collect.Text)
                Else
                    PrePaid = rptDocument.ReportDefinition.ReportObjects("PortFrom" & j + 1)
                    PrePaid.Text = Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * ConNum, 2)
                    DToTalPre += Strings.FormatNumber(PrePaid.Text)
                End If
            End If

            ToTal = rptDocument.ReportDefinition.ReportObjects("ToTal" & j + 1)
            ToTal.Text = Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * ConNum, 2)
            DToTalPrice += Strings.FormatNumber(ToTal.Text)
            'chu xu ly POP
            CurrentCountFee += 1
        Next

        Dim TempFee As String = "" 'chuỗi nối các phí Attach
        Dim AttItem As TextObject
        AttItem = rptDocument.ReportDefinition.ReportObjects("AttItem")

        Dim AttCur As TextObject
        AttCur = rptDocument.ReportDefinition.ReportObjects("AttCur")

        Dim AttType As TextObject
        AttType = rptDocument.ReportDefinition.ReportObjects("AttType")

        Dim AttUPrice As TextObject
        AttUPrice = rptDocument.ReportDefinition.ReportObjects("AttUPrice")

        Dim AttU As TextObject
        AttU = rptDocument.ReportDefinition.ReportObjects("AttU")

        Dim AttPOPO As TextObject
        AttPOPO = rptDocument.ReportDefinition.ReportObjects("AttPOPO")

        Dim AttPOPC As TextObject
        AttPOPC = rptDocument.ReportDefinition.ReportObjects("AttPOPC")

        Dim AttPOPP As TextObject
        AttPOPP = rptDocument.ReportDefinition.ReportObjects("AttPOPP")

        Dim AtttOTAL As TextObject
        AtttOTAL = rptDocument.ReportDefinition.ReportObjects("AtttOTAL")

        If CurrentCountFee = 15 Then
            AttItem.Text = "Item            "
            AttCur.Text = "Currency      "
            AttType.Text = "Type        "
            AttUPrice.Text = "Unit Price        "
            AttU.Text = "Unit       "
            AttPOPO.Text = "POP.O   "
            AttPOPC.Text = "POP.C   "
            AttPOPP.Text = "POP.P   "
            AtttOTAL.Text = "Total  "

        Else
            AttItem.Text = ""
            AttCur.Text = ""
            AttType.Text = ""
            AttUPrice.Text = ""
            AttU.Text = ""
            AttPOPO.Text = ""
            AttPOPC.Text = ""
            AttPOPP.Text = ""
            AtttOTAL.Text = ""
        End If


        If ContainerAttach > 0 Or dtNotify.Rows.Count > 0 Or dtNotify3.Rows.Count > 0 Then

            For j As Integer = CurrentCountFee To oTableFreightCharge.Rows.Count - 1


                AttItem.Text &= oTableFreightCharge.Rows(j).Item("Item").ToString.Trim & "              "

                'If oTableFreightCharge.Rows(j).Item("POP").ToString <> "" Then
                '    textPopo = oTableFreightCharge.Rows(j).Item("POP").ToString
                'End If

                AttCur.Text &= oTableFreightCharge.Rows(j).Item("CURRENCY").ToString.Trim & "              "


                AttType.Text &= oTableFreightCharge.Rows(j).Item("ContainerType").ToString.Trim & "              "


                AttUPrice.Text &= oTableFreightCharge.Rows(j).Item("UnitPrice").ToString.Trim & "              "


                AttU.Text &= oTableFreightCharge.Rows(j).Item("Quantity").ToString.Trim & "              "


                If UCase(oTableFreightCharge.Rows(j).Item("PREPAID_COLLECT").ToString).Trim = "POP.O" Then

                    AttPOPO.Text &= Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * Unit.Text, 2) & "       "

                Else
                    If UCase(oTableFreightCharge.Rows(j).Item("PREPAID_COLLECT").ToString).Trim = "COLLECT" Then

                        AttPOPC.Text &= Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * Unit.Text, 2) & "       "

                        DToTalCol += Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * Unit.Text, 2)
                    Else

                        AttPOPP.Text &= Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * Unit.Text, 2) & "       "
                        DToTalPre += Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * Unit.Text, 2)
                    End If
                End If

                'ToTal = rptDocument.ReportDefinition.ReportObjects("ToTal" & j + 1)
                'ToTal.Text = Strings.FormatNumber(oTableFreightCharge.Rows(j).Item("UnitPrice") * Unit.Text, 2)
                DToTalPrice += DToTalCol + DToTalPre

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''



            If dtNotify.Rows.Count > 0 Then
                TitleNotify2.Text = "Notify 2"
                For K As Integer = 1 To 5
                    AttckNotify2_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_" & K)
                    AttckNotify2_.Text = dtNotify.Rows(0).Item("Notify_" & K).ToString
                Next

                Dim AttckNotify2_6 As TextObject
                AttckNotify2_6 = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_6")
                AttckNotify2_6.Text = dtNotify.Rows(0).Item("remarks").ToString
            End If
            If dtNotify3.Rows.Count > 0 Then
                TitleNotify3.Text = "Notify 3"
                For k As Integer = 1 To 5
                    AttckNotify3_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_" & k)
                    AttckNotify3_.Text = dtNotify3.Rows(0).Item("Notify_" & k).ToString
                Next
                Dim AttckNotify3_6 As TextObject
                AttckNotify3_6 = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_6")
                AttckNotify3_6.Text = dtNotify3.Rows(0).Item("remarks").ToString
            End If


            MsgBox("This bill has Attach Container")
            Dim AttachContainer As TextObject
            AttachContainer = rptDocument.ReportDefinition.ReportObjects("AttachContainer")
            Dim TempContainer As String = ""
            Dim TempGross As String = ""
            Dim TempAmount As String = ""
            Dim TempMeas As String = ""

            ' Dim BillAttach, AmountAttach, GrossAttach, MeasAttach, TitleAmount, TitleGross, TitleMeas, TitleContainer, TotalContainer As TextObject
            'BillAttach = rptDocument.ReportDefinition.ReportObjects("BillAttach")
            BillAttach.Text = "Attach List From Bill Of Lading :" & gBillHouseNoRpt

            'AmountAttach = rptDocument.ReportDefinition.ReportObjects("AmountAttach")

            'GrossAttach = rptDocument.ReportDefinition.ReportObjects("GrossAttach")

            'MeasAttach = rptDocument.ReportDefinition.ReportObjects("MeasAttach")

            'TitleAmount = rptDocument.ReportDefinition.ReportObjects("TitleAmount")

            DescAttach.Text = Result

            TitleAmount.Text = "Amount "

            TitleDesc.Text = "Description"

            'TitleGross = rptDocument.ReportDefinition.ReportObjects("TitleGross")
            TitleGross.Text = "Gross "

            'TitleMeas = rptDocument.ReportDefinition.ReportObjects("TitleMeas")
            TitleMeas.Text = "Measurement "

            'TitleContainer = rptDocument.ReportDefinition.ReportObjects("TitleContainer")
            TitleContainer.Text = "ContainerNo / Seal / Type "


            'TotalContainer = rptDocument.ReportDefinition.ReportObjects("TotalContainerNo")
            TotalContainer.Text = "ToTal : " & oTableCargoInfo.Rows.Count & " Containers"

            For j As Integer = 0 To oTableCargoInfo.Rows.Count - 1
                TempContainer &= j + 1 & ")" & oTableCargoInfo.Rows(j).Item("Container_No").ToString.Trim()
                TempContainer &= " / " & oTableCargoInfo.Rows(j).Item("SealNo").ToString.Trim()
                TempContainer &= " / " & oTableCargoInfo.Rows(j).Item("CTN_SIZE_TYPE").ToString.Trim() & "                             "
                TempAmount &= oTableCargoInfo.Rows(j).Item("Amount").ToString.Trim()
                TempAmount &= " " & oTableCargoInfo.Rows(j).Item("Kind").ToString.Trim() & "                           "
                TempGross &= oTableCargoInfo.Rows(j).Item("GROSS").ToString
                TempGross &= " " & oTableCargoInfo.Rows(j).Item("Unit_Gross").ToString & "                            "
                TempMeas &= FormatString(oTableCargoInfo.Rows(j).Item("CTN_CARGO_MEASUREMENT")) & "                                "
            Next
            AttachContainer.Text = TempContainer
            AmountAttach.Text = TempAmount
            GrossAttach.Text = TempGross
            MeasAttach.Text = TempMeas

            If oTableCargoMarks.Rows.Count > 0 Then
                'Dim CargoMarks As TextObject
                'CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                Dim TempMarks() As String
                TempMarks = Strings.Split(oTableCargoMarks.Rows(0).Item("Marks").ToString, Chr(13))
                Dim ResultMarks As String = ".............................                                           "
                For CountMark As Integer = 0 To TempMarks.Length - 1
                    ResultMarks &= TempMarks(CountMark)
                    For CountSpace As Integer = 0 To AttachContainer.Width \ 10
                        ResultMarks &= " "
                    Next
                Next

                AttachContainer.Text &= ResultMarks
            End If
        Else

            For i As Integer = 0 To oTableCargoInfo.Rows.Count - 1

                ContainerNo = rptDocument.ReportDefinition.ReportObjects("Container" & i + 1)
                ContainerNo.Text = oTableCargoInfo.Rows(i).Item("CONTAINER_NO").ToString

                SealNo = rptDocument.ReportDefinition.ReportObjects("Seal" & i + 1)
                SealNo.Text = oTableCargoInfo.Rows(i).Item("SealNo").ToString

                ContainerType = rptDocument.ReportDefinition.ReportObjects("ContainerType" & i + 1)
                ContainerType.Text = oTableCargoInfo.Rows(i).Item("CTN_SIZE_TYPE").ToString

                Kg = rptDocument.ReportDefinition.ReportObjects("Kg" & i + 1)
                Kg.Text = Strings.FormatNumber(oTableCargoInfo.Rows(i).Item("Amount"), 2)
                DToTalKg += Strings.FormatNumber(Kg.Text)

                Kind = rptDocument.ReportDefinition.ReportObjects("Kind" & i + 1)
                Kind.Text = oTableCargoInfo.Rows(i).Item("Kind").ToString

                GrossWeight = rptDocument.ReportDefinition.ReportObjects("Gross" & i + 1)
                GrossWeight.Text = Strings.FormatNumber(oTableCargoInfo.Rows(i).Item("GROSS"), 2)
                DTotalGross += Strings.FormatNumber(GrossWeight.Text)

                Receidate = rptDocument.ReportDefinition.ReportObjects("ReceiDate" & i + 1)
                If oTableCargoInfo.Rows(i).Item("CARGO_RECEVING_DATE").ToString <> "" Then
                    Receidate.Text = Strings.FormatDateTime(oTableCargoInfo.Rows(i).Item("CARGO_RECEVING_DATE").ToString, DateFormat.ShortDate)
                End If

                'Receidate = rptDocument.ReportDefinition.ReportObjects("ReceiDate" & i + 1)
                'Receidate.Text = Strings.FormatDateTime(oTableCargoInfo.Rows(i).Item("CARGO_RECEVING_DATE").ToString, DateFormat.ShortDate)

                Note = rptDocument.ReportDefinition.ReportObjects("Note" & i + 1)
                Note.Text = oTableCargoInfo.Rows(i).Item("Note").ToString

                CMB = rptDocument.ReportDefinition.ReportObjects("CMB" & i + 1)
                CMB.Text = FormatString(oTableCargoInfo.Rows(i).Item("CTN_CARGO_MEASUREMENT"))
                DTotalCMB += Strings.FormatNumber(CMB.Text)
            Next

            'description
            Description.Text = Result
            If oTableCargoMarks.Rows.Count > 0 Then
                'Dim CargoMarks As TextObject
                'CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                Dim TempMarks() As String
                Dim CargoMarks As TextObject
                CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                TempMarks = Strings.Split(oTableCargoMarks.Rows(0).Item("Marks").ToString, Chr(13))
                Dim ResultMarks As String = ""
                For CountMark As Integer = 0 To TempMarks.Length - 1
                    ResultMarks &= TempMarks(CountMark)
                    For CountSpace As Integer = 0 To CargoMarks.Width \ 10
                        ResultMarks &= " "
                    Next
                Next

                CargoMarks.Text = ResultMarks
            End If

        End If
        Dim TotalKg As TextObject
        TotalKg = rptDocument.ReportDefinition.ReportObjects("ToTalKg")
        TotalKg.Text = Strings.FormatNumber(DToTalKg, 2)

        Dim TotalGross As TextObject
        TotalGross = rptDocument.ReportDefinition.ReportObjects("TotalGW")
        TotalGross.Text = Strings.FormatNumber(DTotalGross, 2)




        If oTableFreightCharge.Rows.Count > 0 Then
            popo = rptDocument.ReportDefinition.ReportObjects("POPO")
            popo.Text = textPopo.ToString
        End If
        Dim ToTalPrePaid, ToTalCollect, ToTalPreight, ToTalCMB As TextObject

        ToTalPrePaid = rptDocument.ReportDefinition.ReportObjects("TOTALPREPAID")
        ToTalPrePaid.Text = Strings.FormatNumber(DToTalPre, 2)

        ToTalCollect = rptDocument.ReportDefinition.ReportObjects("TOTALCOLLECT")
        ToTalCollect.Text = Strings.FormatNumber(DToTalCol, 2)

        ToTalPreight = rptDocument.ReportDefinition.ReportObjects("TOTALFREIGHT")
        ToTalPreight.Text = Strings.FormatNumber(DToTalPrice, 2)

        ToTalCMB = rptDocument.ReportDefinition.ReportObjects("TOTALCBM")
        ToTalCMB.Text = Strings.FormatNumber(DTotalCMB, 2)

        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.ReportSource = rptDocument
        'Formatting paper
        Dim mymargins = rptDocument.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rptDocument.PrintOptions.ApplyPageMargins(mymargins)
        'If frmMain.mnuReportOrientationPortrait.Checked Then
        '    rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        'Else
        rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        'End If
        rptDocument.Refresh()
        Me.CrystalReportViewer1.Show()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

End Class