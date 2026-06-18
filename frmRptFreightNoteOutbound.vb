Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptFreightNoteOutbound

    Dim otable, OtablePrice As DataTable
    Dim OtableFreight As New DataSet
    Dim dscurr As New DataSet
    Sub QueryPriceBill()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Currency,UnitPrice,DebitPrice,Quantity,Charge_Code,Type='' From PriceBillMaster "
        strQuery &= " LEFT JOIN Charge On Charge.Charge_ID=PriceBillMaster.Charge_ID "
        strQuery &= "Where PriceBillMaster.BL_ID='" & gBillOfLadingRpt & "' AND POP LIKE 'VNSGN' And PriceBillMaster.Continued=1 And PriceBillMaster.PrePaid_Collect='PREPAID'"

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

        ' thêm Phần charge của freight note other,nếu là in other
        If FreightnoteotherFN = True Then
            strQuery = " Select Currency,Fee as debitPrice,Quantity,Charge_Code,Type "
            strQuery &= " From FreightNoteOther "
            strQuery &= " where Continued=1 And BL_NO='" & gBillNoRpt & "' Order By Type DESC"

            CmdSelect = New SqlClient.SqlCommand(strQuery, Con)
            Adapter = New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            Adapter.Fill(OtablePrice)

        End If
        FreightnoteotherFN = False
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        Me.Cursor = System.Windows.Forms.Cursors.Default
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
        strQuery = "select Items='Ocean Freight',Container_Type,Freight_Charge_Master.CURRENCY, EXCHANGE ,sum(unitpricesale*EXCHANGE) as Amount,Sum(Quantity*unitpricesale*EXCHANGE) as Total,QUANTITY as Unit "
        strQuery &= " from ((Freight_Charge_Master LEFT JOIN Charge On Charge.CHARGE_ID=Freight_Charge_Master.CHARGE_ID) INNER JOIN CURRENCY ON Freight_Charge_Master.CURRENCY=CURRENCY.CURRENCY ) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
        strQuery &= " where Freight_Charge_Master.Continued=1 And upper(PrePaid_Collect)='" & UCase(IIf(chkPrepaidFN, "Prepaid", "Collect"))
        strQuery &= "' And port_code like 'VNSGN' and BL_ID='" & gBillOfLadingRpt & "' And (Charge.Charge_Code LIKE '%OF%' Or Charge.Charge_Code LIKE '%ODB%') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
        strQuery &= "Group by Container_Type,Freight_Charge_Master.CURRENCY,Quantity,EXCHANGE "

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
    Function QuantityOfHouse() As Integer
        Try
            Dim SQL, TF, TE, strQuery As String
            Dim i As Integer
            strQuery = "select count (*) as slh from billoflading_house "
            strQuery &= " where BL_ID='" & gBillOfLadingRpt & "' and continued=1 "
            Dim dt1 As New DataTable
            dt1 = ReadTable(strQuery)
            If dt1.Rows.Count = 0 Then
                Return 0
            Else
                Return CInt(dt1.Rows(i).Item("slh").ToString)
            End If
            '----
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    Function QueryPrice() As DataTable
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select Container_Type,Freight_Charge_Master.CURRENCY,  EXCHANGE ,sum(unitpricesale*EXCHANGE) as Amount,Sum(Quantity*unitpricesale*EXCHANGE) as Total,QUANTITY as Unit ,Charge_Code "
        strQuery &= " from ((Freight_Charge_Master LEFT JOIN Charge On Charge.CHARGE_ID=Freight_Charge_Master.CHARGE_ID) INNER JOIN CURRENCY ON Freight_Charge_Master.CURRENCY=CURRENCY.CURRENCY ) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
        strQuery &= " where Freight_Charge_Master.Continued=1 And upper(PrePaid_Collect)='" & UCase(IIf(chkPrepaidFN, "Prepaid", "Collect"))
        strQuery &= "' And port_code like 'VNSGN' and  BL_ID='" & gBillOfLadingRpt & "' And Charge.Charge_Code <> 'OF' and  Charge.Charge_Code <> 'ODB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
        strQuery &= "Group by Container_Type,Freight_Charge_Master.CURRENCY,Quantity,Charge_Code,EXCHANGE "

        Dim dt As New DataTable
        dt = ReadTable(strQuery)
        Return dt
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    Sub QueryCargo(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select * from FREIGHT_CHARGE_Master Where BL_ID='"
        strQuery &= gBillOfLadingRpt & "' And Continued=1"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "CargoDesc")
        dt = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
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
        ' xac dinh co in house Bill hay khong
        Me.chkCheckHBLFee.Checked = frmListBaseMaster.chkHBL.Checked
        '------------------
        QueryPriceBill() 'Query Các phụ phí của Bill,đổ vào OtablePrice

        Dim oTableFee As New DataTable
        oTableFee = QueryPrice() 'query các loại phụ phí khác OCB Và ODB của container

        Dim CountFee As Integer = oTableFee.Rows.Count + OtablePrice.Rows.Count

        If CountFee < 10 Then 'nếu só phụ phí nhỏ hơn 10
            strReportName = "ReportFreightNoteOutbound"
        ElseIf CountFee >= 10 And CountFee <= 21 Then '10 < phụ phí < 21
            strReportName = "ReportFreightNoteOutbound20"
        Else 'nếu các phụ phi lớn hơn 21
            strReportName = "ReportFreightNoteOutbound30"
        End If
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
        QueryFreight()

        rpt.SetDataSource(OtableFreight.Tables(0))
        Dim mms, tax, bl, Vessel, POL, POD, DEST, Cargo, billfee, TTM, TTH, SLH, BillFeeH As TextObject
       
        Dim Temp(), Result As String
        Dim tempTextObject As TextObject
        mms = rpt.ReportDefinition.ReportObjects("MESSRS")
        Result = Messrs 'frmListBaseMaster.txtMessrs.Text
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
        tax.Text = taxcode 'frmListBaseMaster.txtTaxCode.Text
        
        If otable.Rows.Count > 0 Then
            bl = rpt.ReportDefinition.ReportObjects("BL_NO")
            bl.Text = billnumberFN 'frmListBaseMaster.txtBillNumber.Text
            bl.Text += GetHouseNumber(billnumberFN)
            'xuong dong cua description
            Vessel = rpt.ReportDefinition.ReportObjects("vessel")
            Vessel.Text = otable.Rows(0).Item("vessel").ToString + " / " + otable.Rows(0).Item("VoyNo").ToString + " / " + otable.Rows(0).Item("ETD").ToString

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
        For i = 1 To OtablePrice.Rows.Count
            Count += 1
            Dim Item, Type, Currency, UnitPrice, Quantity, total As TextObject
            Item = rpt.ReportDefinition.ReportObjects("Item" & i + 1)
            Item.Text = OtablePrice.Rows(i - 1).Item("Charge_Code").ToString

            Type = rpt.ReportDefinition.ReportObjects("BL_Type" & i + 1)
            If OtablePrice.Rows(i - 1).Item("Type").ToString.Trim = "" Then
                Type.Text = "B/L"
            Else
                Type.Text = OtablePrice.Rows(i - 1).Item("Type").ToString.Trim
            End If

            Currency = rpt.ReportDefinition.ReportObjects("Cur" & i + 1)
            Currency.Text = OtablePrice.Rows(i - 1).Item("Currency").ToString

            UnitPrice = rpt.ReportDefinition.ReportObjects("UnitFreight" & i + 1)
           
            UnitPrice.Text = FormatString2(OtablePrice.Rows(i - 1).Item("DebitPrice"))


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

      

        For j As Integer = 0 To oTableFee.Rows.Count - 1
            i = j + Count + 1
            Dim Item, Type, Currency, UnitPrice, Quantity, total As TextObject
            Item = rpt.ReportDefinition.ReportObjects("Item" & i + 1)
            Item.Text = oTableFee.Rows(j).Item("Charge_Code").ToString

            Type = rpt.ReportDefinition.ReportObjects("BL_Type" & i + 1)
            Type.Text = oTableFee.Rows(j).Item("Container_Type").ToString
            Currency = rpt.ReportDefinition.ReportObjects("Cur" & i + 1)
            Currency.Text = oTableFee.Rows(j).Item("CURRENCY").ToString

            UnitPrice = rpt.ReportDefinition.ReportObjects("UnitFreight" & i + 1)
            UnitPrice.Text = oTableFee.Rows(j).Item("Amount").ToString
            If Currency.Text <> "USD" Then
                UnitPrice.Text = FormatString2(CDbl(UnitPrice.Text))
                Currency.Text = "USD"
            End If
            Quantity = rpt.ReportDefinition.ReportObjects("Unit" & i + 1)
            Quantity.Text = oTableFee.Rows(j).Item("Unit").ToString

            total = rpt.ReportDefinition.ReportObjects("ToTal" & i + 1)
            'total.Text = FormatString2(oTableFee.Rows(j).Item("Total")) '* oTableFee.Rows(i - 1).Item("Quantity")
            total.Text = FormatString2(CDbl(UnitPrice.Text) * CDbl(Quantity.Text))
            DTotal += FormatString2(Strings.FormatNumber(total.Text, 2))

        Next

        Dim reportTotal As TextObject
        reportTotal = rpt.ReportDefinition.ReportObjects("Reporttotal")
        For k As Integer = 0 To OtableFreight.Tables(0).Rows.Count - 1
            DTotal += OtableFreight.Tables(0).Rows(k).Item("ToTal")
        Next
        If OtableFreight.Tables(0).Rows.Count > 0 Then
            reportTotal.Text = Strings.FormatNumber(DTotal, 2)
        Else
            reportTotal.Text = FormatString2(DTotal)
        End If
        Dim dt As New DataTable
        Dim dte As TextObject
        dte = rpt.ReportDefinition.ReportObjects("Date")
        Dim dat As Date
        dat = Now
        dte.Text = dat.Date
        ' lay billfee tu option table
        Dim txtbillfee As String
        txtbillfee = getOptionValue("frmRptFreightNoteOutbound", "OB", "2", "billfee", "N")
        billfee = rpt.ReportDefinition.ReportObjects("txtbillfee")
        billfee.Text = txtbillfee

        '-------------------
        'tinh so luong HBlva thanh ten Mbl
        TTM = rpt.ReportDefinition.ReportObjects("text31")
        TTM.Text = txtbillfee ' thong thuong tin chi 1 master B/L
        'tinh(Master)
        If frmListBaseMaster.chkMBL.Checked = True Then
            ' hien thi len report
            rpt.ReportDefinition.ReportObjects("text3").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("box1").ObjectFormat.EnableSuppress = False

            rpt.ReportDefinition.ReportObjects("line4").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("line5").ObjectFormat.EnableSuppress = False


            rpt.ReportDefinition.ReportObjects("line2").ObjectFormat.EnableSuppress = False

            rpt.ReportDefinition.ReportObjects("line6").ObjectFormat.EnableSuppress = False

            rpt.ReportDefinition.ReportObjects("line12").ObjectFormat.EnableSuppress = False

            rpt.ReportDefinition.ReportObjects("text5").ObjectFormat.EnableSuppress = False

            rpt.ReportDefinition.ReportObjects("txtbillfee").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("text9").ObjectFormat.EnableSuppress = False

            rpt.ReportDefinition.ReportObjects("text31").ObjectFormat.EnableSuppress = False
            ' xuat ket qua
        Else
            ' hien thi len report
            rpt.ReportDefinition.ReportObjects("text3").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("box1").ObjectFormat.EnableSuppress = True

            rpt.ReportDefinition.ReportObjects("line4").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("line5").ObjectFormat.EnableSuppress = True


            rpt.ReportDefinition.ReportObjects("line2").ObjectFormat.EnableSuppress = True

            rpt.ReportDefinition.ReportObjects("line6").ObjectFormat.EnableSuppress = True

            rpt.ReportDefinition.ReportObjects("line12").ObjectFormat.EnableSuppress = True

            rpt.ReportDefinition.ReportObjects("text5").ObjectFormat.EnableSuppress = True

            rpt.ReportDefinition.ReportObjects("txtbillfee").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("text9").ObjectFormat.EnableSuppress = True

            rpt.ReportDefinition.ReportObjects("text31").ObjectFormat.EnableSuppress = True
        End If

        '-------------------------------------------------
        'tinh house
        If Me.chkCheckHBLFee.Checked = True Then
            ' hien thi len report
            rpt.ReportDefinition.ReportObjects("text10").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("text4").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("text7").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("text8").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("box2").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("line14").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("line15").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("line13").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("line16").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("line28").ObjectFormat.EnableSuppress = False
            rpt.ReportDefinition.ReportObjects("text30").ObjectFormat.EnableSuppress = False
            ' xuat ket qua

            SLH = rpt.ReportDefinition.ReportObjects("text10")
            SLH.Text = QuantityOfHouse()
            ' hien ra phi bill
            BillFeeH = rpt.ReportDefinition.ReportObjects("text7")
            BillFeeH.Text = txtbillfee
            ' tinh thanh tien
            TTH = rpt.ReportDefinition.ReportObjects("text30")
            TTH.Text = FormatNumber(CDbl(CInt(SLH.Text) * CInt(BillFeeH.Text)), 0, TriState.True)

        Else
            ' hien thi len report
            rpt.ReportDefinition.ReportObjects("text10").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("text4").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("text7").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("text8").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("box2").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("line14").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("line15").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("line13").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("line16").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("line28").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("text30").ObjectFormat.EnableSuppress = True
        End If

        '-----------------------------------

        'Formatting paper
        Dim mymargins = rpt.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rpt.PrintOptions.ApplyPageMargins(mymargins)
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

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        frmRptfreightNote_Load(sender, e)
    End Sub
End Class