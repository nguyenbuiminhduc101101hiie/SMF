Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptFreightNoteOutboundoTher

    Dim otable, OtablePrice As DataTable
    Dim OtableFreight As New DataSet
    Dim dscurr As New DataSet
    Sub QueryPriceBill()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Currency,Fee as UnitPrice,Quantity,Charge_Code From FreightNoteother "
        strQuery &= "Where FreightNoteother.BL_NO='" & gBillNoRpt & "' And FreightNoteother.Continued=1 "

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(OtablePrice) Then
            OtablePrice.Clear()
        End If
        Adapter.Fill(ds, "PriceBill")
        OtablePrice = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Sub QueryBill()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select BL_NO,Vessel.VESSEL,SailingSchedule.VoyNo as VoyNo,SailingSchedule.ETD as ETD ,PORT_OF_DISCHARGE_NAME as POD,PORT_OF_LOADING_NAME as POL ,SailingSchedule.VoyNo as VoyAge,PLACE_OF_DESTINATION_NAME as Dest  "
        strQuery &= "from (((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID) "
        strQuery &= " LEFT JOIN Vessel On Sailingschedule.Vessel_Id=Vessel.Vessel_ID )"
        strQuery &= "Where BL_ID='" & gBillOfLadingRpt & "' And BillOfLading.Continued=1"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(otable) Then
            otable.Clear()
        End If
        Adapter.Fill(ds, "CargoDesc")
        otable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Sub QueryFreight()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim i As Integer
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select Charge_Code as Items,CURRENCY, Fee as Amount, Charge_Code,Fee,Quantity as Unit,Currency"
        strQuery &= " From FreightNoteOther "
        strQuery &= " where Continued=1 And BL_NO='" & gBillNoRpt.Trim & "'"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(OtableFreight.Tables(0)) Then
            OtableFreight.Tables(0).Clear()
        End If
        Adapter.Fill(OtableFreight.Tables(0))
        For i = 0 To OtableFreight.Tables(0).Rows.Count - 1
            OtableFreight.Tables(0).Rows(i).Item(2) = "USD"
        Next
        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '    Function QueryPrice() As DataTable
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim ds As New DataSet
    '        strQuery = "select Container_Type,Freight_Charge_Master.CURRENCY,sum(unitpricesale*EXCHANGE) as Amount,Sum(Quantity*unitpricesale*EXCHANGE) as Total,QUANTITY as Unit ,Charge_Code "
    '        strQuery &= " from (Freight_Charge_Master LEFT JOIN Charge On Charge.CHARGE_ID=Freight_Charge_Master.CHARGE_ID) INNER JOIN CURRENCY ON Freight_Charge_Master.CURRENCY=CURRENCY.CURRENCY "
    '        strQuery &= " where Freight_Charge_Master.Continued=1 And PrePaid_Collect='" & IIf(frmListBaseMaster.chkPrepaid.Checked, frmListBaseMaster.chkPrepaid.Text, frmListBaseMaster.chkCollect.Text)
    '        strQuery &= "' And BL_ID='" & gBillOfLadingRpt & "' And Charge.Charge_Code <> 'OCB' and  Charge.Charge_Code <> 'ODB' "
    '        strQuery &= "Group by Container_Type,Freight_Charge_Master.CURRENCY,Quantity,Charge_Code "

    '        Dim dt As New DataTable
    '        dt = ReadTable(strQuery)
    '        Return dt
    '        '--------------------
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        Exit Function
    'Err_Renamed:
    '        DisplayMessage(True, Err.Description)
    '    End Function
    '    Sub QueryCargo(ByRef dt As DataTable)
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim ds As New DataSet
    '        strQuery = "Select * from FREIGHT_CHARGE_Master Where BL_ID='"
    '        strQuery &= gBillOfLadingRpt & "' And Continued=1"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        Con.Open()
    '        If Not IsNothing(dt) Then
    '            dt.Clear()
    '        End If
    '        Adapter.Fill(ds, "CargoDesc")
    '        dt = ds.Tables(0)

    '        'hien thi ra grid 
    '        '--------------------
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        Exit Sub
    'Err_Renamed:
    '        DisplayMessage(True, Err.Description)
    '    End Sub
    Public Function QueryCurr(ByVal curr As String) As Double
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select exchange "
            strQuery &= " From currency "
            strQuery &= " Where currency='" & curr & "'"
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)

            AdapterFee.Fill(dscurr)
            Return dscurr.Tables(0).Rows(0).Item("exchange")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function
    Private Sub frmRptfreightNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        'Dim rpt As New d
        'gBillOfLadingRpt = "61437E9E-4AEA-42CA-86CE-1E411AA055B2"
        '-------------
        Dim rpt As New ReportDocument
        Dim strReportName As String
        Dim strQuery As String

        'QueryPriceBill() 'Query Các phụ phí của Bill,đổ vào OtablePrice

        'Dim oTableFee As New DataTable
        'oTableFee = QueryPrice() 'query các loại phụ phí khác OCB Và ODB của container

        'Dim CountFee As Integer = oTableFee.Rows.Count + OtablePrice.Rows.Count

        'If CountFee <= 10 Then 'nếu só phụ phí nhỏ hơn 10
        strReportName = "ReportFreightNoteOutbound"
        'ElseIf CountFee >= 11 And CountFee <= 21 Then '10 < phụ phí < 21
        'strReportName = "ReportFreightNoteOutbound20"
        'Else 'nếu các phụ phi lớn hơn 21
        'strReportName = "ReportFreightNoteOutbound30"
        'End If
        ' ten Report


        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rpt.Load(strReportPath)
        '--------------
        OtableFreight.Tables.Clear()
        OtableFreight.Tables.Add()
        QueryBill()
        'QueryFreight()

        'rpt.SetDataSource(OtableFreight.Tables(0))
        Dim mms, tax, bl, Vessel, POL, POD, DEST, Cargo As TextObject

        Dim Temp(), Result As String
        Dim tempTextObject As TextObject
        mms = rpt.ReportDefinition.ReportObjects("MESSRS")
        Result = frmListBaseMaster.txtMessrs.Text
        Temp = Strings.Split(Result, Chr(13))
        Result = ""
        For j As Integer = 0 To Temp.Length - 1

            Result &= Temp(j)
            For k As Integer = Temp(j).Length To mms.Width \ 10
                Result &= " "
            Next

        Next
        mms.Text = Result


        tax = rpt.ReportDefinition.ReportObjects("TAX")
        tax.Text = frmListBaseMaster.txtTaxCode.Text

        If otable.Rows.Count > 0 Then
            bl = rpt.ReportDefinition.ReportObjects("BL_NO")
            bl.Text = frmListBaseMaster.txtTaxCode.Text
            'xuong dong cua description
            Vessel = rpt.ReportDefinition.ReportObjects("vessel")
            Vessel.Text = otable.Rows(0).Item("vessel").ToString + " / " + otable.Rows(0).Item("VoyNo").ToString + " / " + CDate(otable.Rows(0).Item("ETD").ToString).Date

            POL = rpt.ReportDefinition.ReportObjects("POL")
            POL.Text = otable.Rows(0).Item("POL").ToString

            POD = rpt.ReportDefinition.ReportObjects("POD")
            POD.Text = otable.Rows(0).Item("POD").ToString

            DEST = rpt.ReportDefinition.ReportObjects("Dest")
            DEST.Text = otable.Rows(0).Item("DEST")
        End If



        Dim DTotal As Double = 0
        'If OtableFreight.Tables(0).Rows.Count > 0 Then
        '    Dim Unit As TextObject
        '    unit=rpt.ReportDefinition.ReportObjects(""
        'End If
        'Dim DTotalOcean As Double = 0
        'For j As Integer = 0 To OtableFreight.Tables(0).Rows.Count - 1
        '    DTotalOcean += Strings.FormatNumber(OtableFreight.Tables(0).Rows(j).Item("Amount"), 2)
        'Next
        Dim i As Integer
        Dim Count As Integer = 0
        QueryPriceBill()
        For i = 1 To OtablePrice.Rows.Count
            Count += 1
            Dim Item, Type, Currency, UnitPrice, Quantity, total As TextObject
            Item = rpt.ReportDefinition.ReportObjects("Item" & i + 1)
            Item.Text = OtablePrice.Rows(i - 1).Item("Charge_Code").ToString

            'Type = rpt.ReportDefinition.ReportObjects("BL_Type" & i + 1)
            'Type.Text = "B/L"
            Currency = rpt.ReportDefinition.ReportObjects("Cur" & i + 1)
            Currency.Text = OtablePrice.Rows(i - 1).Item("Currency").ToString

            UnitPrice = rpt.ReportDefinition.ReportObjects("UnitFreight" & i + 1)
            UnitPrice.Text = FormatString2(OtablePrice.Rows(i - 1).Item("UnitPrice").ToString)
            If Currency.Text <> "USD" Then
                UnitPrice.Text = FormatString2(UnitPrice.Text)
                Currency.Text = "USD"
            End If
            Quantity = rpt.ReportDefinition.ReportObjects("Unit" & i + 1)
            Quantity.Text = OtablePrice.Rows(i - 1).Item("Quantity").ToString

            total = rpt.ReportDefinition.ReportObjects("ToTal" & i + 1)
            'total.Text = FormatString2(OtablePrice.Rows(i - 1).Item("UnitPrice") * OtablePrice.Rows(i - 1).Item("Quantity"))
            total.Text = FormatString2(CDbl(UnitPrice.Text) * CDbl(Quantity.Text))
            DTotal += FormatString2(Strings.FormatNumber(total.Text, 2))

        Next



        'For j As Integer = 0 To oTableFee.Rows.Count - 1
        '    i = j + Count + 1
        '    Dim Item, Type, Currency, UnitPrice, Quantity, total As TextObject
        '    Item = rpt.ReportDefinition.ReportObjects("Item" & i + 1)
        '    Item.Text = oTableFee.Rows(j).Item("Charge_Code").ToString

        '    Type = rpt.ReportDefinition.ReportObjects("BL_Type" & i + 1)
        '    Type.Text = oTableFee.Rows(j).Item("Container_Type").ToString
        '    Currency = rpt.ReportDefinition.ReportObjects("Cur" & i + 1)
        '    Currency.Text = oTableFee.Rows(j).Item("CURRENCY").ToString

        '    UnitPrice = rpt.ReportDefinition.ReportObjects("UnitFreight" & i + 1)
        '    UnitPrice.Text = oTableFee.Rows(j).Item("Amount").ToString
        '    If Currency.Text <> "USD" Then
        '        UnitPrice.Text = FormatString2(CDbl(UnitPrice.Text))
        '        Currency.Text = "USD"
        '    End If
        '    Quantity = rpt.ReportDefinition.ReportObjects("Unit" & i + 1)
        '    Quantity.Text = oTableFee.Rows(j).Item("Unit").ToString

        '    total = rpt.ReportDefinition.ReportObjects("ToTal" & i + 1)
        '    'total.Text = FormatString2(oTableFee.Rows(j).Item("Total")) '* oTableFee.Rows(i - 1).Item("Quantity")
        '    total.Text = FormatString2(CDbl(UnitPrice.Text) * CDbl(Quantity.Text))
        '    DTotal += FormatString2(Strings.FormatNumber(total.Text, 2))

        'Next

        Dim reportTotal As TextObject
        reportTotal = rpt.ReportDefinition.ReportObjects("Reporttotal")
        reportTotal.Text = Strings.FormatNumber(frmFreightNoteother.txtToTal.Text, 2)
        'For k As Integer = 0 To OtableFreight.Tables(0).Rows.Count - 1
        '    DTotal += OtableFreight.Tables(0).Rows(k).Item("ToTal")
        'Next
        'If OtableFreight.Tables(0).Rows.Count > 0 Then
        '    reportTotal.Text = Strings.FormatNumber(DTotal, 2)
        'Else
        '    reportTotal.Text = FormatString2(DTotal)
        'End If
        Dim dt As New DataTable
        Dim dte As TextObject
        dte = rpt.ReportDefinition.ReportObjects("Date")
        Dim dat As Date
        dat = Now
        dte.Text = dat.Date

        'Formatting paper
        Dim mymargins = rpt.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        'rpt.PrintOptions.ApplyPageMargins(mymargins)
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rpt.Refresh()
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.Show()
        Exit Sub
Err:
        DisplayMessage(True, Err.Description)
    End Sub

End Class