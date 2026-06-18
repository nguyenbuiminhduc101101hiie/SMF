Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptfreightNote
    Dim otable, oTableFreight As DataTable
    Dim oTableBillPrice As New DataTable
    Dim oTableCountContainer As New DataTable
    Dim dsTHC_DHC As New DataSet


    Sub QueryBill()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select BLIB_NO ,VESSEL,POD,POL,VoyAge + ' - ETA: ' + replace(convert(nvarchar,ETA),'12:00AM','') as Voyage,DESCRIPTIONOFGOODS   "
        strQuery &= "from BillOfLadingIB Where BLIB_ID='"
        strQuery &= gBillInboundID & "' And BillOfLadingIB.Continued=1"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(otable) Then
            otable.Clear()
        End If
        Adapter.Fill(ds, "Bill")
        otable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCountContainer()
        Try
            Dim strSQL As String
            strSQL = "Select Container_Type ,Count(Container_type) as Num"
            strSQL &= " From CargoIB"
            strSQL &= " Where Continued=1 And BLIB_ID='" & gBillInboundID & "'"
            strSQL &= " Group By Container_Type"
            'Dim dt As New DataTable
            oTableCountContainer = ReadTable(strSQL)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select *  "
            strQuery &= " From Freight_Charge_IB  "
            strQuery &= " Where BLIB_ID='" & billID & "' and Freight_Charge_IB.Continued=1 and PREPAID_COLLECTsale ='COLLECT' order by items "
            'Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            'Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            'If Not IsNothing(dsTHC_DHC.Tables(0)) Then
            '    dsTHC_DHC.Tables(0).Clear()
            'End If
            'AdapterFee.Fill(dsTHC_DHC.Tables(0))
            dsTHC_DHC = ReadDataSet(strQuery)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryFreight()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select * from FreightNote Where BLIB_NO='"
        strQuery &= gBillNoInBound & "'"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableFreight) Then
            oTableFreight.Clear()
        End If
        Adapter.Fill(ds, "Freight")
        oTableFreight = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Sub QueryCargo(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select sum(Pricesale * Quantity) as Freight,Currency from FREIGHT_CHARGE_IB Where BLIB_ID='"
        strQuery &= gBillInboundID & "' And Continued=1 And PREPAID_COLLECTsale='COLLECT' Group By Currency"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "Cargo")
        dt = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryBillPrice()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select sum(unitprice) as BillPrice,Currency,items from PriceBillIB where BLIB_NO='"
        strQuery &= gBillNoInBound.Trim & "' And Continued=1 And PREPAID_COLLECT='COLLECT' Group By Currency,items"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableBillPrice) Then
            oTableBillPrice.Clear()
        End If
        Adapter.Fill(ds, "price")
        oTableBillPrice = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmRptfreightNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        'Dim rpt As New 
        '-------------
        Dim rpt As New ReportDocument
        Dim strReportName As String
        Dim strQuery As String
        ' ten Report
        strReportName = "ReportFreightNote"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rpt.Load(strReportPath)
        '--------------
        Dim mymargins
        'Dim strReportName As String
        '-------------
        ' ten Report
        'strReportName = "ReportFreightNote"
        'Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        'If Not IO.File.Exists(strReportPath) Then
        '    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
        '    Exit Sub
        'End If
        'rpt.Load(strReportPath)
        '-----------
        QueryBill()
        QueryFreight()
        QueryBillPrice()
        QueryCountContainer()
        Dim mms, tax, bl, Vessel, POL, POD, Cargo, DOFee As TextObject
        If oTableFreight.Rows.Count > 0 Then

            Dim Temp(), Result As String
            Dim tempTextObject As TextObject
            mms = rpt.ReportDefinition.ReportObjects("MESSRS")
            Result = oTableFreight.Rows(0).Item("MESSRS").ToString
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
            tax.Text = oTableFreight.Rows(0).Item("TAX").ToString

        End If

        QueryDHC_THC(gBillInboundID)
        ' gan du lieu freightnote inbound vao luoi 
        rpt.SetDataSource(dsTHC_DHC.Tables(0))
        Dim Currency(10) As String
        Dim Amount(10) As Double
        Dim CountCurrency As Integer = 0

        Dim RoadTax, TitleRoadTax As TextObject
        'RoadTax = rpt.ReportDefinition.ReportObjects("Roadtax")

        'currency = rpt.ReportDefinition.ReportObjects("Currency")
        'TitleRoadTax = rpt.ReportDefinition.ReportObjects("TitleRoadTax")
        'RoadTax.Text = ""
        'TitleRoadTax.Text = ""
        Dim THC_DHC As Double
        'nếu trong manifest có thì hiện thị
        'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
        '    'TitleRoadTax.Text = "THE THC/DHC IS : "
        '    'THC_DHC = CDbl(IIf(dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString.Trim <> "", dsTHC_DHC.Tables(0).Rows(0).Item("Fee"), 0))
        '    'RoadTax.Text = FormatString2(THC_DHC) & " " & dsTHC_DHC.Tables(0).Rows(0).Item("Currency").ToString.Trim
        '    'Currency(CountCurrency) = dsTHC_DHC.Tables(0).Rows(0).Item("Currency").ToString.Trim
        '    'Amount(CountCurrency) = THC_DHC
        '    'CountCurrency += 1
        'End If
        'nếu trong frmfreightnote có nhập thì hiển thị Data trong frmfreirghtnote chứ không phải CSDL
        'If (frmFreightNote.txtRoadTax.Text.Trim.Length > 0 And frmFreightNote.txtRoadTax.Text.Trim <> "0") Then
        '    'CountCurrency = 0
        '    'TitleRoadTax.Text = "THE THC/DHC IS : "
        '    'RoadTax.Text = FormatString2(CDbl(IIf(frmFreightNote.txtRoadTax.Text <> "", frmFreightNote.txtRoadTax.Text, 0))) & " " & frmFreightNote.txtCurrency.Text
        '    'Currency(CountCurrency) = frmFreightNote.txtCurrency.Text 'dsTHC_DHC.Tables(0).Rows(0).Item("Currency").ToString.Trim
        '    'Amount(CountCurrency) = CDbl(IIf(frmFreightNote.txtRoadTax.Text <> "", frmFreightNote.txtRoadTax.Text, 0))
        '    'CountCurrency += 1
        'End If


        If otable.Rows.Count > 0 Then
            bl = rpt.ReportDefinition.ReportObjects("BL_NO")
            bl.Text = otable.Rows(0).Item("BLIB_NO").ToString

            'xuong dong cua description
            Cargo = rpt.ReportDefinition.ReportObjects("Cargo")
            Dim Temp(), Result As String
            Dim tempTextObject As TextObject
            Result = ""
            'Result = otable.Rows(0).Item("DESCRIPTIONOFGOODS").ToString
            For j As Integer = 0 To oTableCountContainer.Rows.Count - 1
                Result &= oTableCountContainer.Rows(j).Item("Num").ToString & " X " & oTableCountContainer.Rows(j).Item("Container_Type").ToString & Chr(13)
            Next
            'If oTableCountContainer.Rows.Count > 1 Then
            '    Result = Strings.Replace(Result, " Container Only ", "")
            'End If
            Temp = Strings.Split(Result, Chr(13))
            Result = ""

            For j As Integer = 0 To Temp.Length - 1
                If j = 28 Then
                    j = 28
                End If
                Result &= Temp(j)
                If Temp(j).Trim.Length > 0 Then
                    For k As Integer = Temp(j).Length To Cargo.Width \ 10
                        Result &= " "
                    Next
                End If
            Next

            Cargo.Text = otable.Rows(0).Item("DESCRIPTIONOFGOODS").ToString

            Dim VoyNo As TextObject
            'VoyNo = rpt.ReportDefinition.ReportObjects("VoyNo")
            'VoyNo.Text = otable.Rows(0).Item("VoyAge").ToString

            Vessel = rpt.ReportDefinition.ReportObjects("vessel")
            Vessel.Text = otable.Rows(0).Item("vessel").ToString & " V." & otable.Rows(0).Item("VoyAge").ToString

            POL = rpt.ReportDefinition.ReportObjects("POL")
            POL.Text = otable.Rows(0).Item("POL").ToString

            POD = rpt.ReportDefinition.ReportObjects("POD")
            POD.Text = otable.Rows(0).Item("POD").ToString
        End If
        Dim dt As New DataTable
        QueryCargo(dt)
        Dim row As DataRow
        Dim d As Double = 0
       
        ' Dim CountAmount As Integer = 0

        Dim freight As TextObject
        'freight = rpt.ReportDefinition.ReportObjects("OceanFreight")

        'For Each row In dt.Rows
        '    freight.Text &= row("Freight").ToString & " " & row("Currency").ToString & " + "

        '    Dim i As Integer
        '    For i = 0 To CountCurrency - 1
        '        If UCase(row("Currency").ToString).Trim = UCase(Currency(i)).Trim Then
        '            Amount(i) += row("Freight")
        '            Exit For
        '        End If
        '    Next
        '    If i = CountCurrency Then
        '        Currency(CountCurrency) = row("Currency").ToString
        '        Amount(CountCurrency) = row("Freight")
        '        CountCurrency += 1
        '    End If

        '    'Currency(CountCurrency) = row("Currency").ToString
        '    'Amount(CountCurrency) = row("Freight")
        '    'CountCurrency += 1
        'Next

        'If freight.Text.Length > 2 Then
        '    freight.Text = freight.Text.Remove(freight.Text.Length - 2)
        'End If


        'If dt.Rows.Count > 0 Then
        '    freight.Text &= dt.Rows(0).Item("CURRENCY").ToString.Trim
        'End If
        'Phí Bill'
        Dim TitleBillFee, BillFee As TextObject
        'TitleBillFee = rpt.ReportDefinition.ReportObjects("TitleBillFee")
        'BillFee = rpt.ReportDefinition.ReportObjects("BillFee")
        'BillFee.Text = ""
        'If oTableBillPrice.Rows.Count > 0 Then
        '    TitleBillFee.Text = ""
        'Else
        '    TitleBillFee.Text = ""
        'End If

        'For Each row In oTableBillPrice.Rows
        '    TitleBillFee.Text = row("Items").ToString + " "
        '    BillFee.Text &= row("BillPrice").ToString & " " & row("Currency").ToString & " + "
        '    Dim i As Integer
        '    For i = 0 To CountCurrency - 1
        '        If UCase(row("Currency").ToString).Trim = UCase(Currency(i)).Trim Then
        '            Amount(i) += FormatNumber(CDbl(row("BillPrice")), 2)
        '            Exit For
        '        End If
        '    Next
        '    If i = CountCurrency Then
        '        CountCurrency += 1
        '        Currency(CountCurrency) = row("Currency").ToString
        '        Amount(CountCurrency) = FormatNumber(CDbl(row("BillPrice")), 2)
        '    End If
        'Next
        ' in phi bill
        Dim phibill, shipping As String
        shipping = frmFreightNote.cboShippingLines.Text
        phibill = getOptionValue("frmFreightNote", "IB", "DOFee", shipping, "N")
        DOFee = rpt.ReportDefinition.ReportObjects("text1")
        DOFee.Text = phibill
        '--------------------------
        'TitleBillFee.Text += ":"
        'If BillFee.Text.Length > 2 Then
        '    BillFee.Text = BillFee.Text.Remove(BillFee.Text.Length - 2)
        'End If
        'Dim Total As TextObject
        'Total = rpt.ReportDefinition.ReportObjects("Total")
        'For i As Integer = 0 To CountCurrency - 1
        '    Total.Text &= FormatNumber(CDbl(Amount(i)), 2) & " " & Currency(i) & " + "
        'Next
        'If Total.Text.Trim.Length > 2 Then
        '    Total.Text = Total.Text.Remove(Total.Text.Length - 2)
        'End If
        Dim dte As TextObject
        dte = rpt.ReportDefinition.ReportObjects("Date")
        Dim dat As Date
        dat = Now
        dte.Text = dat.Date
        Me.CrystalReportViewer1.ReportSource = rpt
        'Formatting paper
        'Formatting paper

        mymargins = rpt.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rpt.PrintOptions.ApplyPageMargins(mymargins)


        'rpt.PrintOptions.ApplyPageMargins(mymargins)
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rpt.Refresh()
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.Show()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class