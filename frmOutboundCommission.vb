Imports Excel
Imports System.Data.OleDb

Public Class frmOutboundCommission
    Dim ds, dsMF, dsNoRich As New DataSet
    Dim Path As String
    Dim Vessel, VoyNo As String
    Dim ETD As Date
    Dim SailID As String
    Dim dem As Integer = 0
    Dim dsTHC_DHC, dsDHC, DSFee As New DataSet
    '--------------------------------------------------------------------
    Sub QueryLHC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(Amount * Quantity*exchange),Prepaid_Collect, payable_at_id "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code like 'LHC'  AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By Prepaid_Collect, payable_at_id " 'Or Charge_Code Like '%THC%'
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryDHC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(Amount * Quantity*exchange),Prepaid_Collect, payable_at_id "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code like 'DHC'  and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By Prepaid_Collect, payable_at_id " 'Or Charge_Code Like '%THC%'
            dsDHC = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceEUR(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' "

            'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or  Charge_Code='STS' or Charge_Code='TMF' or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "EUR", "EUR", "C")
            DSFee = ReadDataSet(strQuery)
            'Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            'Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            'If dsFee.Tables(0).Rows.Count > 0 Then
            '    dsFee.Tables(0).Rows.Clear()
            'End If
            'AdapterFee.Fill(dsFee.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceEURRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' "

            'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or  Charge_Code='STS' or Charge_Code='TMF' or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "EUR", "EUR", "C")
            DSFee = ReadDataSet(strQuery)
        
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceSYRIA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or  Charge_Code='SSP' or Charge_Code='WRS' or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SYRIA", "SYRIA", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceSYRIARich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or  Charge_Code='SSP' or Charge_Code='WRS' or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SYRIA", "SYRIA", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceCAN(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND Charge_Code<>'DHC' AND Charge_Code <> 'LHC' AND Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "CAN", "CAN", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceCANRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND Charge_Code<>'DHC' AND Charge_Code <> 'LHC' AND Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "CAN", "CAN", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceMED(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 AND (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or Charge_Code='STS' or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "MED", "MED", "C")
             DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceMEDRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 AND (Charge_Code='OWS' or Charge_Code='BAF' or Charge_Code='CAF'  or Charge_Code='STS' or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "MED", "MED", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceUSA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 AND Charge_Code<>'DHC' AND Charge_Code<>'LHC' AND Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "USA", "USA", "C")
            DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceUSARich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 AND Charge_Code<>'DHC' AND Charge_Code<>'LHC' AND Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "USA", "USA", "C")
             DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceAFR(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND (Charge_Code='OWS' or Charge_Code='PCS' or Charge_Code='DIB' ) and  CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'

            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "AFR", "AFR", "C")
             DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceAFRRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND (Charge_Code='OWS' or Charge_Code='PCS' or Charge_Code='DIB' ) and  CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'

            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "AFR", "AFR", "C")
             DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceSCA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND (Charge_Code='OWS' or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SCA", "SCA", "C")
            DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceSCARich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1  AND (Charge_Code='OWS' or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SCA", "SCA", "C")
            DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceCHI(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF'  or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "CHI", "CHI", "C")
             DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceCHIRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF'  or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "CHI", "CHI", "C")
          DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceHKG(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS'or  Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "HKG", "HKG", "C")
          DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceHKGRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS'or  Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "HKG", "HKG", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceSEA(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            '' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SEA", "SEA", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceSEARich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            '' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "SEA", "SEA", "C")
            DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub


    Sub QueryPriceIND(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And( Charge_Code='OWS' or  Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "IND", "IND", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryPriceINDRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange ),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where  BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And( Charge_Code='OWS' or  Charge_Code='BAF'  or Charge_Code='DIB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT,port_code " 'And Charge_Code <>'THC'
            ' 
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "IND", "IND", "C")
            DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceAUS(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(Amount*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code = 'BAF'  or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            'And Charge_Code<>'LHC'  And Charge_Code<>'DHC'And Charge_Code<>'SSP' And Charge_Code<>'PSC' And Charge_Code<>'LLO'  
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "AUS", "AUS", "C")
           DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub QueryPriceAUSRich(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select PREPAID_COLLECT,Fee=Sum(UnitPriceSale*Quantity*exchange),port_code "
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " Where BL_ID='" & billID & "' " 'And FREIGHT_CHARGE_Master.Continued=1 And (Charge_Code='OWS' or Charge_Code = 'BAF'  or Charge_Code='DIB') and CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By PREPAID_COLLECT, port_code " 'And Charge_Code <>'THC'
            'And Charge_Code<>'LHC'  And Charge_Code<>'DHC'And Charge_Code<>'SSP' And Charge_Code<>'PSC' And Charge_Code<>'LLO'  
            strQuery &= getOptionValue("frmTripAccountSummary", "OB", "AUS", "AUS", "C")
            DSFee = ReadDataSet(strQuery)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Function QueryMarket(ByVal billID As String) As String
        Try
            Dim strQuery As String
            Dim ds As New DataSet
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select marketcode "
            strQuery &= " From (BillOfLading inner join containeroutboundnotify on BillOfLading.containeroutboundnotifyid=containeroutboundnotify.containeroutboundnotifyid) inner join market on containeroutboundnotify.market_id=market.market_id "
            strQuery &= " Where BL_ID='" & billID & "' and billoflading.continued=1 "
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'If dsBillNumber.Tables(0).Rows.Count > 0 Then
            '    dsBillNumber.Tables(0).Rows.Clear()
            'End If
            Adapter.Fill(ds, "Market")
            Return ds.Tables(0).Rows(0).Item("marketcode").ToString.Trim

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function
    '--------------------------------------------------------------------
    Sub QueryVessel1()
        Try
            Dim SQL As String
            SQL = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETD)  as data "
            SQL &= "from BillOfLadingIB where Continued=1 And ETD >='" & Me.dtpFromETD.Value.Date & "' And ETD<='" & Me.dtpToETD.Value.Date & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            If Not IsNothing(ds) Then
                ds.Clear()
            End If
            Adapter.Fill(ds)
            Me.cboVessel.Items.Clear()
            Me.cboVessel.Text = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct SailingSchedule.SailingScheduleID as Id, Vessel +' - '+ VoyNo + ' - ' + convert(nvarchar,ETD)  as data "
            SQL &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            SQL &= " where BillOfLading.Continued=1 And ETD >='" & Me.dtpFromETD.Value.Date & "' And ETD<='" & Me.dtpToETD.Value.Date & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            'ds.Tables.Add()
            'If ds.Tables(0).Rows.Count > 0 Then
            '    ds.Tables(0).Rows.Clear()
            'End If
            Adapter.Fill(ds)
            Me.cboVessel.Text = ""
            Me.cboVessel.DataSource = ds.Tables(0)
            Me.cboVessel.DisplayMember = "data"
            Me.cboVessel.ValueMember = "ID"
            'Me.cboVessel.Items.Clear()
            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            'Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            ' Next
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryInfo(ByVal Vessel As String, ByVal Voyno As String, ByVal ETD As Date)
        Try
            Dim strSQL As String
            strSQL = "Select BillOfLading.BL_ID,BillOfLading.BL_No,Commission,BillOfLading.Tax,BillOfLading.PREPAID_OR_COLLECT,ContainerOutboundNotify.Salecode,payer,billoflading.servicecontract as servicecontract  "
            strSQL &= " from ((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strSQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL &= "Where BillOfLading.Continued=1 And SailingSchedule.SailingScheduleID='" & SailID & "' order by billoflading.bl_no "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBill").Rows.Count > 0 Then
                ds.Tables("oTableBill").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBill"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryContainer(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Container_type,Count(container_Type) as SoLuong from Cargo"
            strSQL &= " where cargo.BL_ID='" & BillId.Trim & "' And Cargo.Continued=1 Group by Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()

            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableContainer").Rows.Count > 0 Then
                ds.Tables("oTableContainer").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableContainer"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryPrice(ByVal BillId As String)
        Try
            Dim strSQL As String

            If checkbilluc(BillId) = False Then
                ' QueryPriceMF(BillId)
                strSQL = "Select PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*exchange)as Fee,port_code "
                strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
                strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code <>'OCB' And Charge_Code<>'ODB' And Charge_Code<>'LHC' And Charge_Code<>'DHC' And Charge_Code<>'THC' And Charge_Code<>'SSP' And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT,port_code "
            Else
                'QueryPriceMFUc(BillId)
                strSQL = "Select PREPAID_COLLECT,Sum(Amount*Quantity*exchange)as Fee,port_code "
                strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
                strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code ='BAF' and FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT, port_code "
            End If
           
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFee").Rows.Count > 0 Then
                ds.Tables("oTableFee").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFee"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryPriceHistory(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*tigia)as Fee,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code <>'OCB' And Charge_Code<>'ODB' And Charge_Code<>'LHC' And Charge_Code<>'DHC' And Charge_Code<>'THC' And Charge_Code<>'SSP' And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFee").Rows.Count > 0 Then
                ds.Tables("oTableFee").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFee"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryPriceMF(ByVal BillId As String)
        Try
            Dim strSQL As String
            If checkbilluc(BillId) = False Then
                ' QueryPriceMF(BillId)
                strSQL = "Select PREPAID_COLLECT,Sum(Amount*Quantity*exchange)as Fee,port_code "
                strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
                strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code <>'OCB' And Charge_Code<>'ODB' And Charge_Code<>'LHC' And Charge_Code<>'DHC' And Charge_Code<>'THC' And Charge_Code<>'SSP' And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT, port_code "
            Else
                'QueryPriceMFUc(BillId)
                strSQL = "Select PREPAID_COLLECT,Sum(Amount*Quantity*exchange)as Fee,port_code "
                strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
                strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code ='BAF' and FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT, port_code "
            End If

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFeeMF").Rows.Count > 0 Then
                ds.Tables("oTableFeeMF").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFeeMF"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryPriceMFUc(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select PREPAID_COLLECT,Sum(Amount*Quantity*exchange)as Fee,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code ='BAF' and FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT, port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFeeMF").Rows.Count > 0 Then
                ds.Tables("oTableFeeMF").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFeeMF"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryPriceMFHistory(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select PREPAID_COLLECT,Sum(Amount*Quantity*tigia)as Fee, port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code <>'OCB' And Charge_Code<>'ODB' And Charge_Code<>'LHC' And Charge_Code<>'DHC' And Charge_Code<>'THC' And Charge_Code<>'SSP' And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFeeMF").Rows.Count > 0 Then
                ds.Tables("oTableFeeMF").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFeeMF"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryFreightRich(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(Amount*Quantity*exchange) as OceanFreight,port_code "
            'strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*exchange) as OceanFreight,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreight").Rows.Count > 0 Then
                ds.Tables("oTableFreight").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreight"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryFreightNoRich(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*exchange) as OceanFreight,port_code "
            'strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*exchange) as OceanFreight,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreight").Rows.Count > 0 Then
                ds.Tables("oTableFreight").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreight"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryFreightHistory(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*tigia) as OceanFreight,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreight").Rows.Count > 0 Then
                ds.Tables("oTableFreight").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreight"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryFreightMF(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(Amount*Quantity*exchange) as OceanFreight,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreightMF").Rows.Count > 0 Then
                ds.Tables("oTableFreightMF").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreightMF"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryFreightMFHistory(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(Amount*Quantity*tigia) as OceanFreight,port_code "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreightMF").Rows.Count > 0 Then
                ds.Tables("oTableFreightMF").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreightMF"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            Dim tempds As New DataSet
            tempds.Tables.Add("Vessel")
            tempds.Tables(0).Columns.Add("Vessel")
            tempds.Tables(0).Columns.Add("Voyno")
            tempds.Tables(0).Columns.Add("ETD")
            Me.dgdVesselCollection.Rows.Add(1)
            Dim Countdgd As Integer = Me.dgdVesselCollection.RowCount - 1
            Dim row As DataRow
            row = tempds.Tables(0).NewRow
            Dim tempvessel() As String
            tempvessel = Strings.Split(Me.cboVessel.Text, " - ")
            row("Vessel") = IIf(tempvessel.Length > 0, tempvessel(0), "")
            row("VoyNo") = IIf(tempvessel.Length > 1, tempvessel(1), "")
            row("ETD") = IIf(tempvessel.Length > 2, CDate(tempvessel(2)), "")
            Me.dgdVesselCollection.Item("Vesselgid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(0), "")
            Me.dgdVesselCollection.Item("VoyNogid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(1), "")
            Me.dgdVesselCollection.Item("ETDgid", Countdgd).Value = IIf(tempvessel.Length > 0, CDate(tempvessel(2)), "")
            Me.dgdVesselCollection.Item("SailingScheduleID", Countdgd).Value = Me.cboVessel.SelectedValue.ToString
            InsertAutoNumberToGrid(Me.dgdVesselCollection)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub frmFreightInboundList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetDefaultGrid(Me.dgdVesselCollection, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            ds.Tables.Clear()
            ds.Tables.Add("oTableFreightMF")
            ds.Tables.Add("oTableFeeMF")
            ds.Tables.Add("oTableFreight")
            ds.Tables.Add("oTableFee")
            ds.Tables.Add("oTableContainer")
            ds.Tables.Add("oTableBill")

            QueryVessel()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    'Sub SetExcelValueCommission()
    '    Dim app As Application
    '    Try
    '        Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    '        app = New Application()
    '        app.Visible = True

    '        Dim workbooks As Workbooks
    '        workbooks = app.Workbooks
    '        Dim workbook As _Workbook

    '        Path = StartupPath & "\InbounCommission.xls"

    '        workbook = workbooks.Open(Path)



    '        Dim sheets As Sheets
    '        sheets = workbook.Worksheets
    '        Dim ws As _Worksheet
    '        ws = sheets.Item(1)
    '        If ws Is Nothing Then
    '            app.Quit()
    '            Return
    '        End If
    '        Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
    '        Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
    '        For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

    '            Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
    '            VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
    '            ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
    '            QueryInfo(Vessel, VoyNo, ETD)
    '            Dim BillID As String = ""
    '            Dim n As Integer = ds.Tables("oTableBill").Rows.Count
    '            SoDong = DongHienTai
    '            For i As Integer = 0 To n - 1

    '                BillID = ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim
    '                'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
    '                'Insert Bill Info
    '                'For k As Integer = 2 To 4
    '                If ds.Tables("oTableBill").Rows(i).Item("F3").ToString.Length > 0 Then
    '                    ws.Range("A" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F3").ToString
    '                End If
    '                'Next
    '                'insert container
    '                QueryContainer(BillID)
    '                For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
    '                    Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
    '                    If Type = "20GP" Then
    '                        ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40GP" Then
    '                        ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "20RF" Then
    '                        ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40RF" Then
    '                        ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40HC" Then
    '                        ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40RH" Then
    '                        ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    Else
    '                        ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    End If
    '                Next
    '                'Insert Cac Loai Phi
    '                QueryPrice(BillID)
    '                If ds.Tables("oTableFee").Rows.Count > 0 Then
    '                    If UCase(ds.Tables("oTableFee").Rows(0).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
    '                        If ds.Tables("oTableFee").Rows(0).Item("FEE").ToString.Trim.Length > 0 Then
    '                            ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                            ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                        End If
    '                    Else 'phí là prepaid
    '                        If ds.Tables("oTableFee").Rows(0).Item("FEE").ToString.Trim.Length > 0 Then
    '                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                            ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                        End If
    '                    End If
    '                End If
    '                'insert OnceaFreight
    '                QueryFreight(BillID)
    '                If ds.Tables("oTableFreight").Rows.Count > 0 Then
    '                    If ds.Tables("oTableFreight").Rows(0).Item("PREPAID_COLLECT").ToString = "COLLECT" Then
    '                        ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")
    '                        ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")
    '                        Dim Congthuc As String
    '                        Congthuc = "=L" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
    '                        ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
    '                        'thêm công thức vào Freight To Owner
    '                        ws.Range("S" & DongHienTai).Value2 = "=L" & DongHienTai & "+ M" & DongHienTai & "- R" & DongHienTai
    '                    Else
    '                        ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")
    '                        ws.Range("N" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")

    '                        Dim Congthuc As String
    '                        Congthuc = "=J" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
    '                        ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
    '                        'thêm công thức vào Freight To Owner
    '                        ws.Range("S" & DongHienTai).Value2 = "=J" & DongHienTai & "+ K" & DongHienTai & "- R" & DongHienTai
    '                    End If
    '                End If
    '                'ws.Range("Q" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee
    '                'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
    '                ws.Range("B" & DongHienTai).Value2 = ETD
    '                ws.Range("W" & DongHienTai).Formula = "=R" & DongHienTai & " + V" & DongHienTai
    '                DongHienTai += 1
    '                ws.Range("A8", "W" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
    '                ws.Range("A8", "W" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
    '            Next
    '            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
    '            'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
    '            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '            'ws.Range("B" & DongHienTai).Value2 = ETD
    '            'Dim C As Integer
    '            'For C = 0 To 16
    '            '    'If Alpha(C + 2) <> "Q" Then
    '            '    Dim Sum As String
    '            '    Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
    '            '    ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
    '            '    ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
    '            '    'End If
    '            'Next
    '            'ws.Range("A" & DongHienTai, Alpha(C + 4) & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
    '            DongHienTai += 1
    '        Next
    '        ' ws.Range("A8", "U" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)
    '        Dim ToTal As Integer
    '        ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
    '        ws.Range("A" & DongHienTai).Value2 = "TOTAL "
    '        ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '        ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '        For ToTal = 0 To 16
    '            ' If Alpha(ToTal + 5) <> "Q" Then
    '            Dim Sum As String
    '            Sum = "=sum(" & Alpha(ToTal + 2) & 9 & ":" & Alpha(ToTal + 2) & DongHienTai - 1 & ")"
    '            ws.Range(Alpha(ToTal + 2) & DongHienTai).Formula = Sum
    '            ws.Range(Alpha(ToTal + 2) & DongHienTai).Cells.Font.Bold = 1
    '            'End If
    '        Next

    '        Path = "c:\InboundCommission" & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

    '        workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

    '    Catch ex As Exception
    '        MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
    '        MsgBox(Err.Description)
    '        Return
    '    Finally
    '        app.Quit()
    '    End Try

    'End Sub

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPriceSale * Quantity*exchange),Prepaid_Collect,payable_at_id "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (charge_Code LIKE '%LHC%') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By Prepaid_Collect,payable_at_id "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Sub QueryDHC_THCHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPriceSale * Quantity*tigia),Prepaid_Collect "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (charge_Code LIKE '%LHC%') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group By Prepaid_Collect"
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    ' ham lay POL de report cho cuoc Prepaid
    Function GetPOL(ByVal BillID As String) As String
        Try
            '-----------------
            Dim kq As String = ""
            Dim rs As New ADODB.Recordset
            Dim SQL As String
            SQL = "Select  PORT_OF_LOADING_CODE  from  billoflading where billoflading.bl_id ='" & BillID & "' and continued=1 "
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                kq = rs.Fields("PORT_OF_LOADING_CODE").Value.ToString
                rs.Close()
                Return kq
            Else
                rs.Close()
                Return kq
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        '-----------------

    End Function
    Function checkbilluc(ByVal BillID As String) As Boolean
        Try
            '-----------------

            Dim rs As New ADODB.Recordset
            Dim SQL As String
            SQL = "Select  market.market as market  from  (billoflading inner join containeroutboundnotify on billoflading.containeroutboundnotifyid =containeroutboundnotify.containeroutboundnotifyid) inner join market on market.market_id=containeroutboundnotify.market_id  where billoflading.bl_id ='" & BillID & "' and market.continued=1 and market.marketcode='AUS'"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                rs.Close()
                Return True
            Else
                rs.Close()
                Return False
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
            '-----------------

    End Function
    Sub SetExcelValue()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim dsNoRich As New DataSet
            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\OutboundCommmissionDHC.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            Dim bl_no As String
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                QueryInfo(Vessel, VoyNo, ETD)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 0 To 6
                    '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                    '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                    '    End If
                    'Next
                    'insert container

                    ws.Range("A" & DongHienTai).Value2 = bl_no 'Vessel & " - " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    ws.Range("F" & DongHienTai).Value2 = IIf(UCase(ds.Tables("oTableBill").Rows(i).Item("PREPAID_OR_COLLECT").ToString.Trim) = "PREPAID", "P", "C")
                    ws.Range("Z" & DongHienTai).Value = ds.Tables("oTableBill").Rows(i).Item("Payer")
                    ws.Range("AA" & DongHienTai).Value = ds.Tables("oTableBill").Rows(i).Item("Servicecontract")

                    QueryContainer(BillID)
                    Dim CurType As String = " "
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                        'If Type = "20GP" Then
                        '    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                        ws.Range("E" & DongHienTai).Value2 = CurType
                        If Strings.Left(Type, 2) = "20" Then
                            ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        End If


                    Next

                    'Insert Cac Loai Phi MF
                    ' them cac phi china----------------------------------------------------------
                    ' kiem tra loai thi truong
                    '----------------------------
                    Dim market As String = ""
                    market = QueryMarket(BillID)
                    If bl_no Like "*SGNLTK*" Then
                        QueryPriceSYRIA(BillID)
                    Else
                        If UCase(market) Like "EUR" Then 'Or UCase(market) Like "MED" Then
                            QueryPriceEUR(BillID)
                        ElseIf UCase(market) Like "MID" Then
                            QueryPriceEUR(BillID)
                        ElseIf UCase(market) Like "AUS" Then
                            QueryPriceAUS(BillID)
                        ElseIf UCase(market) Like "SEA" Then
                            QueryPriceSEA(BillID)
                        ElseIf UCase(market) Like "MED" Then
                            QueryPriceMED(BillID)
                        ElseIf UCase(market) Like "IND" Then
                            QueryPriceIND(BillID)
                        ElseIf UCase(market) Like "CHI" Then
                            QueryPriceCHI(BillID)
                        ElseIf UCase(market) Like "HKG" Then
                            QueryPriceHKG(BillID)
                        ElseIf UCase(market) Like "SCA" Then
                            QueryPriceSCA(BillID)
                        ElseIf UCase(market) Like "AFR" Then
                            QueryPriceAFR(BillID)
                        ElseIf UCase(market) Like "WUS" Then
                            QueryPriceUSA(BillID)
                        ElseIf UCase(market) Like "EUS" Then
                            QueryPriceUSA(BillID)
                        ElseIf UCase(market) Like "CAN" Then
                            QueryPriceCAN(BillID)
                        End If
                    End If
                    '----------------------------------------------------
                    'QueryPriceMF(BillID)
                    For P As Integer = 0 To DSFee.Tables(0).Rows.Count - 1
                        If DSFee.Tables(0).Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(DSFee.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And UCase(DSFee.Tables(0).Rows(P).Item("port_code").ToString.Trim) = UCase(GetPOL(BillID)) Then
                                ws.Range("I" & DongHienTai).Value2 = DSFee.Tables(0).Rows(P).Item("FEE")
                                'ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "P"
                                ws.Range("J" & DongHienTai).Value = 0
                            Else
                                ws.Range("J" & DongHienTai).Value2 = DSFee.Tables(0).Rows(P).Item("FEE")
                                'ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "C"
                                ws.Range("I" & DongHienTai).Value = 0
                            End If

                        End If
                    Next
                    ' xoa phi doi lap
                    If ws.Range("I" & DongHienTai).Value <> 0 Then
                        ws.Range("J" & DongHienTai).Value2 = 0
                    End If

                    'Insert Cac Loai Phi RICH-------------------------------------------------
                    'kiem tra lai tung loai thi truong------------
                    market = QueryMarket(BillID)
                    If bl_no Like "*SGNLTK*" Then
                        QueryPriceSYRIARich(BillID)
                    Else
                        If UCase(market) Like "EUR" Then 'Or UCase(market) Like "MED" Then
                            QueryPriceEURRich(BillID)
                        ElseIf UCase(market) Like "MID" Then
                            QueryPriceEURRich(BillID)
                        ElseIf UCase(market) Like "AUS" Then
                            QueryPriceAUSRich(BillID)
                        ElseIf UCase(market) Like "SEA" Then
                            QueryPriceSEARich(BillID)
                        ElseIf UCase(market) Like "MED" Then
                            QueryPriceMEDRich(BillID)
                        ElseIf UCase(market) Like "IND" Then
                            QueryPriceINDRich(BillID)
                        ElseIf UCase(market) Like "CHI" Then
                            QueryPriceCHIRich(BillID)
                        ElseIf UCase(market) Like "HKG" Then
                            QueryPriceHKGRich(BillID)
                        ElseIf UCase(market) Like "SCA" Then
                            QueryPriceSCARich(BillID)
                        ElseIf UCase(market) Like "AFR" Then
                            QueryPriceAFRRich(BillID)
                        ElseIf UCase(market) Like "WUS" Then
                            QueryPriceUSARich(BillID)
                        ElseIf UCase(market) Like "EUS" Then
                            QueryPriceUSARich(BillID)
                        ElseIf UCase(market) Like "CAN" Then
                            QueryPriceCANRich(BillID)
                        End If
                    End If
                    '-------------------------

                    'QueryPrice(BillID)
                    For P As Integer = 0 To DSFee.Tables(0).Rows.Count - 1
                        If DSFee.Tables(0).Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(DSFee.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And UCase(DSFee.Tables(0).Rows(P).Item("port_code").ToString.Trim) = UCase(GetPOL(BillID)) Then
                                ws.Range("L" & DongHienTai).Value2 = DSFee.Tables(0).Rows(P).Item("FEE")
                            Else
                                ws.Range("M" & DongHienTai).Value2 = DSFee.Tables(0).Rows(P).Item("FEE")
                            End If

                        End If
                    Next


                    'insert OnceaFreight
                    'If bl_no Like "*AS301" Then
                    '    'DisplayMessage(True, "")
                    'End If
                    ' them phi OF cho China--------------------------------------------------------
                    QueryFreightMF(BillID)

                    For F As Integer = 0 To ds.Tables("oTableFreightMF").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreightMF").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And UCase(ds.Tables("oTableFreightMF").Rows(F).Item("port_code").ToString.Trim) = UCase(GetPOL(BillID)) Then
                            ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreightMF").Rows(F).Item("OceanFreight")

                        Else
                            ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreightMF").Rows(F).Item("OceanFreight")
                        End If
                    Next
                    'insert OnceaFreight
                    ' Rich
                    ' them phi OF chi Rich------------------------------------------------------------------
                    QueryFreightNoRich(BillID)

                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And UCase(ds.Tables("oTableFreight").Rows(F).Item("port_code").ToString.Trim) = UCase(GetPOL(BillID)) Then
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                        Else
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                        End If
                        'them phan cong
                        '--- kiem tra lai hong dong Rich
                        If ws.Range("Z" & DongHienTai).Value = "76000" Or ws.Range("Z" & DongHienTai).Value = "86000" Then
                            QueryFreightRich(BillID)
                            If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And ds.Tables("oTableFreight").Rows(F).Item("port_code").ToString.Trim Like "VN*" Then

                                ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                            Else
                                ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                            End If

                        Else
                            ws.Range("K" & DongHienTai).Value2 = CDbl(ws.Range("K" & DongHienTai).Value2) + CDbl(ws.Range("L" & DongHienTai).Value2) - CDbl(ws.Range("I" & DongHienTai).Value2)
                            ws.Range("L" & DongHienTai).Value2 = ws.Range("I" & DongHienTai).Value2
                        End If

                    Next
                    '-----------------------------------------------------------------------------------------------------------------------
                    'insert Commission
                    Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
                    ws.Range("N" & DongHienTai).Value2 = Temp & "%"
                    ws.Range("O" & DongHienTai).Formula = "=if(Count(G" & DongHienTai & ")>=1, G" & DongHienTai & " * N" & DongHienTai & ",K" & DongHienTai & "* N" & DongHienTai & ")"
                    If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
                        ws.Range("N" & DongHienTai).Value2 = ""
                        ws.Range("O" & DongHienTai).Value2 = 15 * (CDbl(ws.Range("C" & DongHienTai).Value2) + CDbl(ws.Range("D" & DongHienTai).Value2))
                    End If
                    'Inert THC/DHC LHC
                    QueryDHC_THC(BillID)
                    For P As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                        If dsTHC_DHC.Tables(0).Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(dsTHC_DHC.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And getPortCodeFromPortID(dsTHC_DHC.Tables(0).Rows(P).Item("payable_at_id").ToString.Trim, BillID) Then
                                ws.Range("P" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(P).Item("FEE")

                            Else
                                ws.Range("Q" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(P).Item("FEE")

                            End If
                            'nhân số phần trăm trong Cells R7
                            ws.Range("R" & DongHienTai).Value2 = "=" & dsTHC_DHC.Tables(0).Rows(P).Item("FEE") & "*" & ws.Range("R7").Value
                        End If
                    Next
                    ' them DHC
                    QueryDHC(BillID)
                    If dsDHC.Tables(0).Rows.Count > 0 Then
                        ws.Range("S" & DongHienTai).Value2 = dsDHC.Tables(0).Rows(0).Item("fee").ToString
                    End If

                    'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    '    ws.Range("P" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item(0)
                    'End If

                    'insert freight To Owner()
                    ws.Range("T" & DongHienTai).Formula = "=(G" & DongHienTai & "+I" & DongHienTai & ")-O" & DongHienTai & "+P" & DongHienTai

                    'Insert SaleName
                    ws.Range("U" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("Salecode").ToString.Trim
                    'Insert Different

                    'ws.Range("W" & DongHienTai).Value2 = "=k" & DongHienTai & "+L" & DongHienTai & "+M" & DongHienTai & "-G" & DongHienTai & "-I" & DongHienTai & "-J" & DongHienTai
                    ws.Range("X" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai
                    'insert Extra Charge
                    'ws.Range("V" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai & "-U" & DongHienTai & "-V" & DongHienTai


                    'insert renvenue
                    ws.Range("Y" & DongHienTai).Value2 = "=O" & DongHienTai & "+X" & DongHienTai

                    DongHienTai += 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                Dim C As Integer
                For C = 0 To 21
                    If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "R" Then
                        Dim Sum As String
                        Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                        ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                        ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                    End If
                Next
                'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                ' tru cac cot nhu sau j+=k-h ; k-=k-h
               
                DongHienTai += 1
            Next
            'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

            'SUM TOÀN BỘ FILE
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 10
            '    'If Alpha(ToTal + 7) <> "Q" Then
            '    Dim Sum As String
            '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
            '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
            '    'End If
            'Next

            Path = "c:\OutboundCommmissionDHC" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox(" Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueHistory()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\OutboundCommmission.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            Dim bl_no As String
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                QueryInfo(Vessel, VoyNo, ETD)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 0 To 6
                    '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                    '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                    '    End If
                    'Next
                    'insert container

                    ws.Range("A" & DongHienTai).Value2 = bl_no 'Vessel & " - " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    ws.Range("F" & DongHienTai).Value2 = IIf(UCase(ds.Tables("oTableBill").Rows(i).Item("PREPAID_OR_COLLECT").ToString.Trim) = "PREPAID", "P", "C")
                    ws.Range("Y" & DongHienTai).Value = ds.Tables("oTableBill").Rows(i).Item("Payer")
                    QueryContainer(BillID)
                    Dim CurType As String = " "
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                        'If Type = "20GP" Then
                        '    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                        ws.Range("E" & DongHienTai).Value2 = CurType
                        If Strings.Left(Type, 2) = "20" Then
                            ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        End If


                    Next
                    'thêm công thức vào teu
                    'Insert Cac Loai Phi MF

                    QueryPriceMFHistory(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFeeMF").Rows.Count - 1
                        If ds.Tables("oTableFeeMF").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableFeeMF").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And ds.Tables("oTableFeeMF").Rows(P).Item("port_code").ToString.Trim Like "VN*" Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFeeMF").Rows(P).Item("FEE")
                                'ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "P"
                            Else
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFeeMF").Rows(P).Item("FEE")
                                'ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "C"
                            End If

                        End If
                    Next

                    'Insert Cac Loai Phi RICH

                    QueryPriceHistory(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableFee").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And ds.Tables("oTableFee").Rows(P).Item("port_code").ToString.Trim Like "VN*" Then
                                'ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "P"
                            Else
                                'ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "C"
                            End If

                        End If
                    Next
                    'insert OnceaFreight
                    QueryFreightMFHistory(BillID)

                    For F As Integer = 0 To ds.Tables("oTableFreightMF").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreightMF").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And ds.Tables("oTableFreightMF").Rows(F).Item("port_code").ToString.Trim Like "VN*" Then
                            ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreightMF").Rows(F).Item("OceanFreight")

                        Else
                            ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreightMF").Rows(F).Item("OceanFreight")
                        End If
                    Next
                    'insert OnceaFreight
                    ' Rich
                    QueryFreightHistory(BillID)

                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And ds.Tables("oTableFreight").Rows(F).Item("port_code").ToString.Trim Like "VN*" Then

                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                        Else
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                        End If
                        'them phan cong

                        ws.Range("K" & DongHienTai).Value2 = CDbl(ws.Range("K" & DongHienTai).Value2) + CDbl(ws.Range("L" & DongHienTai).Value2) - CDbl(ws.Range("I" & DongHienTai).Value2)
                        ws.Range("L" & DongHienTai).Value2 = ws.Range("I" & DongHienTai).Value2
                    Next
                    'insert Commission
                    Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
                    ws.Range("N" & DongHienTai).Value2 = Temp & "%"
                    ws.Range("O" & DongHienTai).Formula = "=if(Count(G" & DongHienTai & ")>=1, G" & DongHienTai & " * N" & DongHienTai & ",K" & DongHienTai & "* N" & DongHienTai & ")"
                    If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
                        ws.Range("N" & DongHienTai).Value2 = ""
                        ws.Range("O" & DongHienTai).Value2 = 15 * (CDbl(ws.Range("C" & DongHienTai).Value2) + CDbl(ws.Range("D" & DongHienTai).Value2))
                    End If
                    'Inert THC/DHC LHC
                    QueryDHC_THCHistory(BillID)
                    For P As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                        If dsTHC_DHC.Tables(0).Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(dsTHC_DHC.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                                ws.Range("P" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(P).Item("FEE")

                            Else
                                ws.Range("Q" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(P).Item("FEE")

                            End If
                            'nhân số phần trăm trong Cells R7
                            ws.Range("R" & DongHienTai).Value2 = "=" & dsTHC_DHC.Tables(0).Rows(P).Item("FEE") & "*" & ws.Range("R7").Value
                        End If
                    Next
                    'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    '    ws.Range("P" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item(0)
                    'End If

                    'insert freight To Owner()
                    ws.Range("S" & DongHienTai).Formula = "=(G" & DongHienTai & "+I" & DongHienTai & ")-O" & DongHienTai & "+P" & DongHienTai

                    'Insert SaleName
                    ws.Range("T" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim
                    'Insert Different

                    'ws.Range("W" & DongHienTai).Value2 = "=k" & DongHienTai & "+L" & DongHienTai & "+M" & DongHienTai & "-G" & DongHienTai & "-I" & DongHienTai & "-J" & DongHienTai
                    ws.Range("W" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai
                    'insert Extra Charge
                    'ws.Range("V" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai & "-U" & DongHienTai & "-V" & DongHienTai


                    'insert renvenue
                    ws.Range("X" & DongHienTai).Value2 = "=O" & DongHienTai & "+W" & DongHienTai

                    DongHienTai += 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                Dim C As Integer
                For C = 0 To 21
                    If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "R" Then
                        Dim Sum As String
                        Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                        ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                        ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                    End If
                Next
                'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                ' tru cac cot nhu sau j+=k-h ; k-=k-h

                DongHienTai += 1
            Next
            'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

            'SUM TOÀN BỘ FILE
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 10
            '    'If Alpha(ToTal + 7) <> "Q" Then
            '    Dim Sum As String
            '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
            '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
            '    'End If
            'Next

            Path = "c:\OutboundCommmission" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox(" Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueAmendMent()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\OutboundCommissionAmendMent.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            Dim bl_no As String
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                QueryInfo(Vessel, VoyNo, ETD)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 0 To 6
                    '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                    '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                    '    End If
                    'Next
                    'insert container

                    ws.Range("A" & DongHienTai).Value2 = bl_no 'Vessel & " - " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    QueryContainer(BillID)
                    Dim CurType As String = " "
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                        'If Type = "20GP" Then
                        '    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                        ws.Range("E" & DongHienTai).Value2 = CurType
                        If Strings.Left(Type, 2) = "20" Then
                            ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        End If
                    Next
                    'thêm công thức vào teu
                    'Insert Cac Loai Phi
                    QueryPrice(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableFee").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "P"
                            Else
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "C"
                            End If

                        End If
                    Next


                    'insert OnceaFreight
                    QueryFreightRich(BillID)
                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                            ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            'Dim Congthuc As String
                            ''Congthuc = "=N" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                            ''thêm công thức vào NET
                            'ws.Range("U" & DongHienTai).Value2 = "=N" & DongHienTai & "+ O" & DongHienTai & "- R" & DongHienTai
                            'Else
                            '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            '    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            'Dim Congthuc As String
                            'Congthuc = "=M" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 

                            '' thêm công thức vào NET
                            'ws.Range("U" & DongHienTai).Value2 = "=-R" & DongHienTai
                        End If
                    Next

                    'insert Commission
                    Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
                    ws.Range("N" & DongHienTai).Value2 = Temp & "%"
                    ws.Range("O" & DongHienTai).Formula = "=if(Count(G" & DongHienTai & ")>=1, G" & DongHienTai & " * N" & DongHienTai & ",K" & DongHienTai & "* N" & DongHienTai & ")"
                    If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
                        ws.Range("N" & DongHienTai).Value2 = ""
                        ws.Range("O" & DongHienTai).Value2 = 15
                    End If
                    'Inert THC/DHC
                    'QueryDHC_THC(BillID)
                    'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    '    ws.Range("U" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item(0)
                    'End If

                    'insert freight To Owner()
                    ws.Range("P" & DongHienTai).Formula = "=(G" & DongHienTai & "+I" & DongHienTai & ")-O" & DongHienTai '& "+P" & DongHienTai

                    'Insert SaleName
                    ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

                    'Insert Different
                    ws.Range("T" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai & "-R" & DongHienTai & "-S" & DongHienTai
                    'ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

                    'insert renvenue
                    ws.Range("V" & DongHienTai).Value2 = "=O" & DongHienTai & "+T" & DongHienTai

                    DongHienTai += 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                Dim C As Integer
                For C = 0 To 18
                    If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "Q" Then
                        Dim Sum As String
                        Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                        ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                        ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                    End If
                Next
                'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
            Next
            'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

            'SUM TOÀN BỘ FILE
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 10
            '    'If Alpha(ToTal + 7) <> "Q" Then
            '    Dim Sum As String
            '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
            '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
            '    'End If
            'Next

            Path = "c:\OutboundCommissionAmendMent" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox(" Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueAmendMentHistory()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\OutboundCommissionAmendMent.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            Dim bl_no As String
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                QueryInfo(Vessel, VoyNo, ETD)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 0 To 6
                    '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                    '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                    '    End If
                    'Next
                    'insert container

                    ws.Range("A" & DongHienTai).Value2 = bl_no 'Vessel & " - " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    QueryContainer(BillID)
                    Dim CurType As String = " "
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                        'If Type = "20GP" Then
                        '    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                        ws.Range("E" & DongHienTai).Value2 = CurType
                        If Strings.Left(Type, 2) = "20" Then
                            ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        End If
                    Next
                    'thêm công thức vào teu
                    'Insert Cac Loai Phi
                    QueryPriceHistory(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableFee").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "P"
                            Else
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                                'ws.Range("J" & DongHienTai).Value2 = "C"
                            End If

                        End If
                    Next


                    'insert OnceaFreight
                    QueryFreightHistory(BillID)
                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                            ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            'Dim Congthuc As String
                            ''Congthuc = "=N" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                            ''thêm công thức vào NET
                            'ws.Range("U" & DongHienTai).Value2 = "=N" & DongHienTai & "+ O" & DongHienTai & "- R" & DongHienTai
                            'Else
                            '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            '    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            'Dim Congthuc As String
                            'Congthuc = "=M" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 

                            '' thêm công thức vào NET
                            'ws.Range("U" & DongHienTai).Value2 = "=-R" & DongHienTai
                        End If
                    Next

                    'insert Commission
                    Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
                    ws.Range("N" & DongHienTai).Value2 = Temp & "%"
                    ws.Range("O" & DongHienTai).Formula = "=if(Count(G" & DongHienTai & ")>=1, G" & DongHienTai & " * N" & DongHienTai & ",K" & DongHienTai & "* N" & DongHienTai & ")"
                    If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
                        ws.Range("N" & DongHienTai).Value2 = ""
                        ws.Range("O" & DongHienTai).Value2 = 15
                    End If
                    'Inert THC/DHC
                    'QueryDHC_THC(BillID)
                    'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    '    ws.Range("U" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item(0)
                    'End If

                    'insert freight To Owner()
                    ws.Range("P" & DongHienTai).Formula = "=(G" & DongHienTai & "+I" & DongHienTai & ")-O" & DongHienTai '& "+P" & DongHienTai

                    'Insert SaleName
                    ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

                    'Insert Different
                    ws.Range("T" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai & "-R" & DongHienTai & "-S" & DongHienTai
                    'ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

                    'insert renvenue
                    ws.Range("X" & DongHienTai).Value2 = "=O" & DongHienTai & "+T" & DongHienTai

                    DongHienTai += 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                Dim C As Integer
                For C = 0 To 18
                    If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "Q" Then
                        Dim Sum As String
                        Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                        ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                        ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                    End If
                Next
                'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
            Next
            'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

            'SUM TOÀN BỘ FILE
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 10
            '    'If Alpha(ToTal + 7) <> "Q" Then
            '    Dim Sum As String
            '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
            '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
            '    'End If
            'Next

            Path = "c:\OutboundCommissionAmendMent" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox(" Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try

            If Me.dgdVesselCollection.RowCount <= 0 Then
                Return
            End If
            If Me.chkIncludeTHC.Checked = True Then
                If Me.RadioEPre.Checked = True Then
                    SetExcelValueAmendMent()
                Else
                    SetExcelValueAmendMentHistory()
                End If

            Else
                If Me.RadioEPre.Checked = True Then
                    SetExcelValue()
                Else
                    SetExcelValueHistory()
                End If

            End If


            'If Me.txtHandingFee.Text = "" Then
            '    MsgBox("You must insert Handing fee (%)")
            '    Exit Sub
            'End If
            'If Me.chkFreightList.Checked = True Then
            '    
            'Else
            '    SetExcelValueCommission()
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpFromETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETD.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpToETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETD.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgdVesselCollection_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdVesselCollection.CellContentClick

    End Sub

    Private Sub dgdVesselCollection_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdVesselCollection.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdVesselCollection)
    End Sub
End Class