Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptBillInBound
    '------------------
    Dim Vessel, VoyAge As String
    Public oTableBillOfLading As DataTable
    Public dsBillOfLading As New DataSet
    '------------------
    Public oTableDetailBillOfLading As DataTable
    Public dsDetailBillOfLading As New DataSet
    '--------------------------------
    Public oTableCustomerInfo As DataTable
    Public dsCustomerInfo As New DataSet

    Public oTableCargoDesc, oTableCargoMarks, oTableCargoReMarks As DataTable
    Public dsCargoDesc, dsCargoMarks, dsCargoRemarks As New DataSet
    Public oTableCountContainerType As New DataTable
    Public Pre_Col As String = ""
    Const strDetailBillOfLadingSelect As String = "SELECT Distinct " & _
"Container.Container_No,MEAS,MEASUNIT," & _
       "Container.CTN_SIZE_TYPE ,Seal, " & _
       "Amount, " & _
       "Kind, " & _
       "GrossWeight, " & _
       "GrossUnit  "

    Const strCustomerInfo As String = "Select Shipper, " & _
    "" & _
        "" & _
        "" & _
    "Consignee, " & _
        "" & _
        " " & _
        " " & _
    "Notify " & _
        "" & _
        " " & _
        "  "


    Const strBillOfLadingSelect As String = "SELECT BillOfLadingIB.BLIB_Id as BillOfLadingId, " & _
"Vessel, Voyage as voyno," & _
   "CY_CFS_ITEM as BL_CY_CFS_ITEM,POR," & _
       "POL as Port_Of_Loading_Name," & _
       "POD as Port_Of_Discharge_Name, " & _
       "DEL as Place_Of_Delivery_Name, " & _
       "Dest as PLACE_OF_DESTINATION_NAME, " & _
       "DESCRIPTIONFORSHIPPER,LC_NO," & _
       " DESCRIPTIONOFGOODS,Marks," & _
     "SAILINGDATE as Load_Date "

    Sub QueryPre_Col()
        Try
            'Dim strPre_Col As String = "Select Distinct PREPAID_COLLECT From Freight_Charge_IB where BLIB_ID='" & gBillInboundID & "' And Continued=1"
            Dim strPre_Col As String = "Select Distinct PREPAID_COLLECT From Freight_Charge_IB where BLIB_ID='" & gBillInboundID & "' And Continued=1 And Items<>'THC' And Items<>'DHC'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim cmd As New SqlClient.SqlCommand(strPre_Col, Conn)
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            If dt.Rows.Count > 0 Then
                dt.Clear()
            End If
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count = 2 Then
                    Pre_Col = "COLLECT"
                ElseIf dt.Rows(0).Item(0).ToString.Trim = "PREPAID" Then
                    Pre_Col = "PREPAID"
                Else
                    Pre_Col = "COLLECT"
                End If
            Else
                Pre_Col = "PREPAID"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Function CheckLCLCargo() As Boolean
        Try
            Dim SQL As String
            SQL = "select Top 1 Container_No "
            SQL &= " From ((CargoIb Inner Join BillOfLadingIb On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
            SQL &= " INNER Join Container On Container.CTN_ID=CargoIb.CTN_ID)"
            SQL &= " Where Vessel='" & Vessel & "' And VoyAge='" & VoyAge & "' And CargoIB.Continued=1 And BLIB_NO <>'" & gBillNoInBound & "'"
            SQL &= " And Container_No In "
            SQL &= "(Select Container_No From ((CargoIb Inner Join BillOfLadingIb On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
            SQL &= " INNER Join Container On Container.CTN_ID=CargoIb.CTN_ID) Where BLIB_NO='" & gBillNoInBound & "' And CargoIB.continued=1) "
            SQL &= " And (select count(*) from (Freight_Charge_IB LEFT JOIN BillOfLadingIB On Freight_Charge_IB.BLIB_ID=BillOfLadingIB.BLIB_ID) Where BLIB_No='" & gBillNoInBound & "')=0"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub PrintRPTO()
        On Error GoTo Err_Renamed
        Dim strReportName As String
        Dim strQuery As String
        Dim rptDocument As New ReportDocument

        '------------
        '-------------
        QueryCustomerInfo()
        QueryBillOfLading()
        QueryDetailBillOfLading()
        QueryPre_Col()
        '---------
        ' ten Report
        If oTableDetailBillOfLading.Rows.Count > 15 Or Me.chkAttachDescription.Checked = True Then
            strReportName = "ReportBILLOFLADINGO"
        Else
            strReportName = "ReportBILLOFLADINGnoatO"
        End If

        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rptDocument.Load(strReportPath)

        '-----Dua du lieu vao report
        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4

        Dim PrePaid_collect As TextObject
        If Pre_Col = "PREPAID" Then
            PrePaid_collect = rptDocument.ReportDefinition.ReportObjects("Prepaid")
        Else
            PrePaid_collect = rptDocument.ReportDefinition.ReportObjects("Collect")
        End If
        PrePaid_collect.Text = Pre_Col

        '---Dua vao shipper,Consignee,Notify
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

        ' Mo ta Hang hoa
        Dim Description As TextObject
        Dim BillNo As TextObject
        BillNo = rptDocument.ReportDefinition.ReportObjects("BillNo")
        BillNo.Text = gBillNoInBound
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
            Shipper_6.Text = oTableCustomerInfo.Rows(0).Item("Shipper_6").ToString

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
            Consignee_6.Text = oTableCustomerInfo.Rows(0).Item("Consignee_6").ToString

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
            Notify_6.Text = oTableCustomerInfo.Rows(0).Item("Notify_6").ToString
        End If



        Dim ContainerNo1 As TextObject
        Dim ContainerNo2 As TextObject
        Dim ContainerNo3 As TextObject
        Dim ContainerNo4 As TextObject
        Dim ContainerNo5 As TextObject
        Dim ContainerNo6 As TextObject
        Dim ContainerNo7 As TextObject
        Dim ContainerNo8 As TextObject
        Dim ContainerNo9 As TextObject
        Dim ContainerNo10 As TextObject
        Dim ContainerNo11 As TextObject
        Dim ContainerNo12 As TextObject
        Dim ContainerNo13 As TextObject
        Dim ContainerNo14 As TextObject
        Dim ContainerNo15 As TextObject
        Dim ContainerNo16 As TextObject
        Dim ContainerNo17 As TextObject
        Dim ContainerNo18 As TextObject
        Dim ContainerNo19 As TextObject
        Dim ContainerNo20 As TextObject
        Dim ContainerNo(20) As String

        Dim Amount1, Kind1 As TextObject
        Dim Amount2, Kind2 As TextObject
        Dim Amount3, Kind3 As TextObject
        Dim Amount4, Kind4 As TextObject
        Dim Amount5, Kind5 As TextObject
        Dim Amount6, Kind6 As TextObject
        Dim Amount7, Kind7 As TextObject
        Dim Amount8, Kind8 As TextObject
        Dim Amount9, Kind9 As TextObject
        Dim Amount10, Kind10 As TextObject
        Dim Amount11, Kind11 As TextObject
        Dim Amount12, Kind12 As TextObject
        Dim Amount13, Kind13 As TextObject
        Dim Amount14, Kind14 As TextObject
        Dim Amount15, Kind15 As TextObject
        Dim Amount16, Kind16 As TextObject
        Dim Amount17, Kind17 As TextObject
        Dim Amount18, Kind18 As TextObject
        Dim Amount19, Kind19 As TextObject
        Dim Amount20, Kind20 As TextObject
        Dim Amount(20), Kind(20) As String

        Dim Gross1, UnitGross1 As TextObject
        Dim Gross2, UnitGross2 As TextObject
        Dim Gross3, UnitGross3 As TextObject
        Dim Gross4, UnitGross4 As TextObject
        Dim Gross5, UnitGross5 As TextObject
        Dim Gross6, UnitGross6 As TextObject
        Dim Gross7, UnitGross7 As TextObject
        Dim Gross8, UnitGross8 As TextObject
        Dim Gross9, UnitGross9 As TextObject
        Dim Gross10, UnitGross10 As TextObject
        Dim Gross11, UnitGross11 As TextObject
        Dim Gross12, UnitGross12 As TextObject
        Dim Gross13, UnitGross13 As TextObject
        Dim Gross14, UnitGross14 As TextObject
        Dim Gross15, UnitGross15 As TextObject
        Dim Gross16, UnitGross16 As TextObject
        Dim Gross17, UnitGross17 As TextObject
        Dim Gross18, UnitGross18 As TextObject
        Dim Gross19, UnitGross19 As TextObject
        Dim Gross20, UnitGross20 As TextObject
        Dim Gross(20), UnitGross(20) As String
        Dim Meas1 As TextObject
        Dim Meas2 As TextObject
        Dim Meas3 As TextObject
        Dim Meas4 As TextObject
        Dim Meas5 As TextObject
        Dim Meas6 As TextObject
        Dim Meas7 As TextObject
        Dim Meas8 As TextObject
        Dim Meas9 As TextObject
        Dim Meas10 As TextObject
        Dim Meas11 As TextObject
        Dim Meas12 As TextObject
        Dim Meas13 As TextObject
        Dim Meas14 As TextObject
        Dim Meas15 As TextObject
        Dim Meas16 As TextObject
        Dim Meas17 As TextObject
        Dim Meas18 As TextObject
        Dim Meas19 As TextObject
        Dim Meas20 As TextObject
        Dim Meas(20) As String
        Dim SealNo1 As TextObject
        Dim SealNo2 As TextObject
        Dim SealNo3 As TextObject
        Dim SealNo4 As TextObject
        Dim SealNo5 As TextObject
        Dim SealNo6 As TextObject
        Dim SealNo7 As TextObject
        Dim SealNo8 As TextObject
        Dim SealNo9 As TextObject
        Dim SealNo10 As TextObject
        Dim SealNo11 As TextObject
        Dim SealNo12 As TextObject
        Dim SealNo13 As TextObject
        Dim SealNo14 As TextObject
        Dim SealNo15 As TextObject
        Dim SealNo16 As TextObject
        Dim SealNo17 As TextObject
        Dim SealNo18 As TextObject
        Dim SealNo19 As TextObject
        Dim SealNo20 As TextObject
        Dim SealNo(20) As String
        Dim SoContainer As Integer = 15

        Dim dbMeas As Double = 0

        Dim dbGross As Double = 0
       
        If oTableDetailBillOfLading.Rows.Count > 0 Then
            Dim i As Integer
            Dim N As Integer = IIf(oTableDetailBillOfLading.Rows.Count - 1 > SoContainer, SoContainer, oTableDetailBillOfLading.Rows.Count - 1)
            Dim k As Integer = oTableDetailBillOfLading.Rows.Count - 1 - N
            'xư ly các contanier nhiều hơn số container giới hiện thi trên bill 
            If k > 0 Or Me.chkAttachDescription.Checked = True Then
                Dim AttachContainer, BL_NO1, AttachTitle, ToTalAttachContainer As TextObject
                Dim strAttachContainer As String = ""
                'AttachTitle = rptDocument.ReportDefinition.ReportObjects("attachTitle")
                'AttachTitle.Text = "Attach Container"
                BL_NO1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                BL_NO1.Text = gBillNoInBound
                MsgBox("This bill has attach container ")
                Me.chkAttachDescription.Visible = True
                ToTalAttachContainer = rptDocument.ReportDefinition.ReportObjects("ToTalAttachContainer")
                ToTalAttachContainer.Text = "Total : " & oTableDetailBillOfLading.Rows.Count & " Containers "
                For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                    If i <= 8 Then
                        strAttachContainer &= "(0"
                    Else
                        strAttachContainer &= "("

                    End If
                    strAttachContainer &= i + 1 & ")   " & oTableDetailBillOfLading.Rows(i).Item("Container_No").ToString.Trim
                    strAttachContainer &= "                  " & oTableDetailBillOfLading.Rows(i).Item("CTN_SIZE_TYPE").ToString.Trim & "                  "
                    strAttachContainer &= oTableDetailBillOfLading.Rows(i).Item("Seal").ToString.Trim & "                                                                "
                    dbGross += IIf(oTableDetailBillOfLading.Rows(i).Item("GrossWeight").ToString.Trim.Length > 0, oTableDetailBillOfLading.Rows(i).Item("GrossWeight"), 0)
                    dbMeas += IIf(oTableDetailBillOfLading.Rows(i).Item("Meas").ToString.Trim.Length > 0, oTableDetailBillOfLading.Rows(i).Item("Meas"), 0)
                Next
                'For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                '    strAttachContainer &= i + 1 & ") " & oTableDetailBillOfLading.Rows(i).Item("Container_No").ToString.Trim
                '    strAttachContainer &= " / " & oTableDetailBillOfLading.Rows(i).Item("CTN_SIZE_TYPE").ToString.Trim & " / "
                '    strAttachContainer &= oTableDetailBillOfLading.Rows(i).Item("Seal").ToString.Trim & "                                                                                "
                '    dbGross += oTableDetailBillOfLading.Rows(i).Item("GrossWeight")
                '    dbMeas += oTableDetailBillOfLading.Rows(i).Item("MEAS")
                'Next
                AttachContainer = rptDocument.ReportDefinition.ReportObjects("ContainerAttach")
                AttachContainer.Text = strAttachContainer
                ContainerNo1 = rptDocument.ReportDefinition.ReportObjects("ContainerNo1")
                ContainerNo1.Text = "Attach List"

            Else


                For i = 0 To N
                    Dim type As TextObject

                    type = rptDocument.ReportDefinition.ReportObjects("Type" & i + 1)
                    type.Text = " / " & oTableDetailBillOfLading.Rows(i).Item("CTN_SIZE_TYPE").ToString.Trim & " / "

                    ContainerNo(i) = oTableDetailBillOfLading.Rows(i).Item("Container_No").ToString.Trim
                    SealNo(i) = oTableDetailBillOfLading.Rows(i).Item("Seal").ToString.Trim
                Next
                ContainerNo1 = rptDocument.ReportDefinition.ReportObjects("ContainerNo1")
                ContainerNo1.Text = ContainerNo(0)
                ContainerNo2 = rptDocument.ReportDefinition.ReportObjects("ContainerNo2")
                ContainerNo2.Text = ContainerNo(1)
                ContainerNo3 = rptDocument.ReportDefinition.ReportObjects("ContainerNo3")
                ContainerNo3.Text = ContainerNo(2)
                ContainerNo4 = rptDocument.ReportDefinition.ReportObjects("ContainerNo4")
                ContainerNo4.Text = ContainerNo(3)
                ContainerNo5 = rptDocument.ReportDefinition.ReportObjects("ContainerNo5")
                ContainerNo5.Text = ContainerNo(4)
                ContainerNo6 = rptDocument.ReportDefinition.ReportObjects("ContainerNo6")
                ContainerNo6.Text = ContainerNo(5)

                ContainerNo7 = rptDocument.ReportDefinition.ReportObjects("ContainerNo7")
                ContainerNo7.Text = ContainerNo(6)
                ContainerNo8 = rptDocument.ReportDefinition.ReportObjects("ContainerNo8")
                ContainerNo8.Text = ContainerNo(7)
                ContainerNo9 = rptDocument.ReportDefinition.ReportObjects("ContainerNo9")
                ContainerNo9.Text = ContainerNo(8)

                ContainerNo10 = rptDocument.ReportDefinition.ReportObjects("ContainerNo10")
                ContainerNo10.Text = ContainerNo(9)
                ContainerNo11 = rptDocument.ReportDefinition.ReportObjects("ContainerNo11")
                ContainerNo11.Text = ContainerNo(10)
                ContainerNo12 = rptDocument.ReportDefinition.ReportObjects("ContainerNo12")
                ContainerNo12.Text = ContainerNo(11)
                ContainerNo13 = rptDocument.ReportDefinition.ReportObjects("ContainerNo13")
                ContainerNo13.Text = ContainerNo(12)
                ContainerNo14 = rptDocument.ReportDefinition.ReportObjects("ContainerNo14")
                ContainerNo14.Text = ContainerNo(13)

                ContainerNo15 = rptDocument.ReportDefinition.ReportObjects("ContainerNo15")
                ContainerNo15.Text = ContainerNo(14)
                ContainerNo16 = rptDocument.ReportDefinition.ReportObjects("ContainerNo16")
                ContainerNo16.Text = ContainerNo(15)
                '---SealNo
                SealNo1 = rptDocument.ReportDefinition.ReportObjects("SealNo1")
                SealNo1.Text = SealNo(0)
                SealNo2 = rptDocument.ReportDefinition.ReportObjects("SealNo2")
                SealNo2.Text = SealNo(1)
                SealNo3 = rptDocument.ReportDefinition.ReportObjects("SealNo3")
                SealNo3.Text = SealNo(2)
                SealNo4 = rptDocument.ReportDefinition.ReportObjects("SealNo4")
                SealNo4.Text = SealNo(3)
                SealNo5 = rptDocument.ReportDefinition.ReportObjects("SealNo5")
                SealNo5.Text = SealNo(4)
                SealNo6 = rptDocument.ReportDefinition.ReportObjects("SealNo6")
                SealNo6.Text = SealNo(5)

                SealNo7 = rptDocument.ReportDefinition.ReportObjects("SealNo7")
                SealNo7.Text = SealNo(6)
                SealNo8 = rptDocument.ReportDefinition.ReportObjects("SealNo8")
                SealNo8.Text = SealNo(7)
                SealNo9 = rptDocument.ReportDefinition.ReportObjects("SealNo9")
                SealNo9.Text = SealNo(8)

                SealNo10 = rptDocument.ReportDefinition.ReportObjects("SealNo10")
                SealNo10.Text = SealNo(9)
                SealNo11 = rptDocument.ReportDefinition.ReportObjects("SealNo11")
                SealNo11.Text = SealNo(10)
                SealNo12 = rptDocument.ReportDefinition.ReportObjects("SealNo12")
                SealNo12.Text = SealNo(11)
                SealNo13 = rptDocument.ReportDefinition.ReportObjects("SealNo13")
                SealNo13.Text = SealNo(12)
                SealNo14 = rptDocument.ReportDefinition.ReportObjects("SealNo14")
                SealNo14.Text = SealNo(13)

                SealNo15 = rptDocument.ReportDefinition.ReportObjects("SealNo15")
                SealNo15.Text = SealNo(14)
                SealNo16 = rptDocument.ReportDefinition.ReportObjects("SealNo16")
                SealNo16.Text = SealNo(15)
                '------------Amount
                For i = 0 To N
                    Amount(i) = oTableDetailBillOfLading.Rows(i).Item("Amount").ToString
                    Kind(i) = oTableDetailBillOfLading.Rows(i).Item("Kind").ToString
                    dbGross += oTableDetailBillOfLading.Rows(i).Item("GrossWeight")
                    UnitGross(i) = oTableDetailBillOfLading.Rows(i).Item("GrossUnit").ToString
                    dbMeas += oTableDetailBillOfLading.Rows(i).Item("MEAS")

                Next

                Amount1 = rptDocument.ReportDefinition.ReportObjects("Amount1")
                Amount1.Text = Amount(0)
                Amount2 = rptDocument.ReportDefinition.ReportObjects("Amount2")
                Amount2.Text = Amount(1)
                Amount3 = rptDocument.ReportDefinition.ReportObjects("Amount3")
                Amount3.Text = Amount(2)
                Amount4 = rptDocument.ReportDefinition.ReportObjects("Amount4")
                Amount4.Text = Amount(3)
                Amount5 = rptDocument.ReportDefinition.ReportObjects("Amount5")
                Amount5.Text = Amount(4)
                Amount6 = rptDocument.ReportDefinition.ReportObjects("Amount6")
                Amount6.Text = Amount(5)

                Amount7 = rptDocument.ReportDefinition.ReportObjects("Amount7")
                Amount7.Text = Amount(6)
                Amount8 = rptDocument.ReportDefinition.ReportObjects("Amount8")
                Amount8.Text = Amount(7)
                Amount9 = rptDocument.ReportDefinition.ReportObjects("Amount9")
                Amount9.Text = Amount(8)

                Amount10 = rptDocument.ReportDefinition.ReportObjects("Amount10")
                Amount10.Text = Amount(9)
                Amount11 = rptDocument.ReportDefinition.ReportObjects("Amount11")
                Amount11.Text = Amount(10)
                Amount12 = rptDocument.ReportDefinition.ReportObjects("Amount12")
                Amount12.Text = Amount(11)
                Amount13 = rptDocument.ReportDefinition.ReportObjects("Amount13")
                Amount13.Text = Amount(12)
                Amount14 = rptDocument.ReportDefinition.ReportObjects("Amount14")
                Amount14.Text = Amount(13)

                Amount15 = rptDocument.ReportDefinition.ReportObjects("Amount15")
                Amount15.Text = Amount(14)
                Amount16 = rptDocument.ReportDefinition.ReportObjects("Amount16")
                Amount16.Text = Amount(15)
                '-----Kind
                Kind1 = rptDocument.ReportDefinition.ReportObjects("Kind1")
                Kind1.Text = Kind(0)
                Kind2 = rptDocument.ReportDefinition.ReportObjects("Kind2")
                Kind2.Text = Kind(1)
                Kind3 = rptDocument.ReportDefinition.ReportObjects("Kind3")
                Kind3.Text = Kind(2)
                Kind4 = rptDocument.ReportDefinition.ReportObjects("Kind4")
                Kind4.Text = Kind(3)
                Kind5 = rptDocument.ReportDefinition.ReportObjects("Kind5")
                Kind5.Text = Kind(4)
                Kind6 = rptDocument.ReportDefinition.ReportObjects("Kind6")
                Kind6.Text = Kind(5)

                Kind7 = rptDocument.ReportDefinition.ReportObjects("Kind7")
                Kind7.Text = Kind(6)
                Kind8 = rptDocument.ReportDefinition.ReportObjects("Kind8")
                Kind8.Text = Kind(7)
                Kind9 = rptDocument.ReportDefinition.ReportObjects("Kind9")
                Kind9.Text = Kind(8)

                Kind10 = rptDocument.ReportDefinition.ReportObjects("Kind10")
                Kind10.Text = Kind(9)
                Kind11 = rptDocument.ReportDefinition.ReportObjects("Kind11")
                Kind11.Text = Kind(10)
                Kind12 = rptDocument.ReportDefinition.ReportObjects("Kind12")
                Kind12.Text = Kind(11)
                Kind13 = rptDocument.ReportDefinition.ReportObjects("Kind13")
                Kind13.Text = Kind(12)
                Kind14 = rptDocument.ReportDefinition.ReportObjects("Kind14")
                Kind14.Text = Kind(13)

                Kind15 = rptDocument.ReportDefinition.ReportObjects("Kind15")
                Kind15.Text = Kind(14)
                Kind16 = rptDocument.ReportDefinition.ReportObjects("Kind16")
                Kind16.Text = Kind(15)
                '----Gross
            End If
            Gross1 = rptDocument.ReportDefinition.ReportObjects("Gross1")


            Gross1.Text = FormatString(dbGross)
            '---UnitGross
            UnitGross1 = rptDocument.ReportDefinition.ReportObjects("UnitGross1")
            UnitGross1.Text = UnitGross(0)

            '---Meas
            Meas1 = rptDocument.ReportDefinition.ReportObjects("Meas1")

            Meas1.Text = FormatString(dbMeas)

            Dim CY_CFS As TextObject
            CY_CFS = rptDocument.ReportDefinition.ReportObjects("CY_CFS")
            CY_CFS.Text = oTableBillOfLading.Rows(0).Item("BL_CY_CFS_ITEM").ToString

        End If
        '        '----cac chi tiet
        If oTableBillOfLading.Rows.Count > 0 Then

            Description = rptDocument.ReportDefinition.ReportObjects("Description1")
            Dim Temp(), Result As String
            Dim tempTextObject As TextObject
            Result = oTableBillOfLading.Rows(0).Item("DESCRIPTIONOFGOODS").ToString
            Temp = Strings.Split(Result, Chr(13))
            QueryCountContainer()
            Result = ""
            If CheckLCLCargo() = True Then
                Result = " Part Of "
            End If
            If oTableCountContainerType.Rows.Count > 0 Then
                For i As Integer = 0 To oTableCountContainerType.Rows.Count - 1
                    Result &= IIf(oTableCountContainerType.Rows(i).Item("Num") < 9, "0" & oTableCountContainerType.Rows(i).Item("Num").ToString, oTableCountContainerType.Rows(i).Item("Num").ToString) & " X " & oTableCountContainerType.Rows(i).Item("Container_Type").ToString
                    Result &= " & "
                Next
                Result = Result.Remove(Result.Length - 2)
                If oTableCountContainerType.Rows.Count = 1 Then
                    Result &= " CONTAINER ONLY                                                                                                                                                        "
                Else
                    Result &= "                                                                                                                                                                         "
                End If
            Else
                Result = ""
            End If
            Description = rptDocument.ReportDefinition.ReportObjects("Description1")
            If Me.chkAttachDescription.Checked = True Then
                Description.Text = Result
                Result = ""
                Description = rptDocument.ReportDefinition.ReportObjects("Description2")
            End If

            For j As Integer = 0 To Temp.Length - 1

                Result &= Temp(j)
                If Temp(j).Trim.Length > 0 Then
                    For k As Integer = Temp(j).Length To Description.Width \ 10
                        Result &= " "
                    Next
                End If
            Next
            Description.Text = Result




            Dim CargoMarks As TextObject
            CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
            CargoMarks.Text = oTableBillOfLading.Rows(0).Item("Marks").ToString



            '---------------




            'Dim PreCarriageVessel As TextObject
            'PreCarriageVessel = rptDocument.ReportDefinition.ReportObjects("Pre_Vessel")
            'PreCarriageVessel.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString


            'Dim PreCarriageVoyNo As TextObject
            'PreCarriageVoyNo = rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo")
            'PreCarriageVoyNo.Text = oTableBillOfLading.Rows(0).Item("Pre_VoyNo").ToString

            Dim PlaceOfReceipt As TextObject
            PlaceOfReceipt = rptDocument.ReportDefinition.ReportObjects("PlaceOfReceipt")
            PlaceOfReceipt.Text = oTableBillOfLading.Rows(0).Item("POR").ToString

            Dim OceanVesselName As TextObject
            OceanVesselName = rptDocument.ReportDefinition.ReportObjects("OceanVesselName")
            OceanVesselName.Text = oTableBillOfLading.Rows(0).Item("Vessel").ToString

            Dim VoyNo As TextObject
            VoyNo = rptDocument.ReportDefinition.ReportObjects("VoyNo")
            VoyNo.Text = oTableBillOfLading.Rows(0).Item("VoyNo").ToString

            Dim DescriptionShipper As TextObject
            DescriptionShipper = rptDocument.ReportDefinition.ReportObjects("DescriptionShipper")
            DescriptionShipper.Text = oTableBillOfLading.Rows(0).Item("DESCRIPTIONFORSHIPPER").ToString

            Dim PortOfLoading As TextObject
            PortOfLoading = rptDocument.ReportDefinition.ReportObjects("PortOfLoading")
            PortOfLoading.Text = oTableBillOfLading.Rows(0).Item("Port_Of_Loading_Name").ToString

            Dim PortOfDischarge As TextObject
            PortOfDischarge = rptDocument.ReportDefinition.ReportObjects("PortOfDischarge")
            PortOfDischarge.Text = oTableBillOfLading.Rows(0).Item("Port_Of_Discharge_Name").ToString

            Dim PlaceOfDelivery As TextObject
            PlaceOfDelivery = rptDocument.ReportDefinition.ReportObjects("PlaceOfDelivery")
            PlaceOfDelivery.Text = oTableBillOfLading.Rows(0).Item("Place_Of_Delivery_Name").ToString

            Dim FinalDestination As TextObject
            FinalDestination = rptDocument.ReportDefinition.ReportObjects("FinalDestination")
            FinalDestination.Text = oTableBillOfLading.Rows(0).Item("PLACE_OF_DESTINATION_NAME").ToString

            Dim LoadDate As TextObject
            LoadDate = rptDocument.ReportDefinition.ReportObjects("LoadDate")
            LoadDate.Text = VB6.Format(oTableBillOfLading.Rows(0).Item("LOAD_DATE").ToString, "MMMM dd,yyyy")
            ' prepaid collect
            'If UCase(oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString) = "COLLECT" Then
            '    Dim Collect As TextObject
            '    Collect = rptDocument.ReportDefinition.ReportObjects("Collect")
            '    Collect.Text = oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString
            'Else

            '    Dim Prepaid As TextObject
            '    Prepaid = rptDocument.ReportDefinition.ReportObjects("Prepaid")
            '    Prepaid.Text = oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString
            'End If


        End If
        '        'DisplayMessage(True, rptDocument.PrintOptions.PageContentWidth())

        '        ' hien thi report
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.ReportSource = rptDocument
        'Formatting paper
        Dim mymargins = rptDocument.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rptDocument.PrintOptions.ApplyPageMargins(mymargins)
        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rptDocument.Refresh()
        Me.CrystalReportViewer1.Show()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub PrintRPT()
        On Error GoTo Err_Renamed
        Dim strReportName As String
        Dim strQuery As String
        Dim rptDocument As New ReportDocument

        '------------
        '-------------
        QueryCustomerInfo()
        QueryBillOfLading()
        QueryDetailBillOfLading()
        'QueryPre_Col()
        '---------
        ' ten Report
        If oTableDetailBillOfLading.Rows.Count > 15 Or Me.chkAttachDescription.Checked = True Then
            strReportName = "rptformlabel"
        Else
            strReportName = "rptformlabel"
        End If

        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rptDocument.Load(strReportPath)

        '-----Dua du lieu vao report
        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4
        Dim ik As Integer

        Dim marks, volumn, PrePaid_collect, hbl, mbl, ref, carrier, shipper, consignee, notify, ControlingAgent, mother, etamother, pod, pol, dest, CY_CFS_ITEM As TextObject
        '-------
        Dim sqlhbl As String
        Dim dshbl As New DataSet
        sqlhbl = "select * from billofladingib where mbl='" & gMBL & "' "
        dshbl = ReadDataSet(sqlhbl)
        Dim il As Integer
        Dim hbl1 As String

        If dshbl.Tables(0).Rows.Count > 0 Then
            For il = 0 To dshbl.Tables(0).Rows.Count - 1
                hbl1 += dshbl.Tables(0).Rows(il).Item("hbl").ToString + "; "

            Next
        End If

        '--------------
        hbl = rptDocument.ReportDefinition.ReportObjects("hbl")
        hbl.Text = hbl1
        'If oTableBillOfLading.Rows.Count > 0 Then
        '    For ik = 0 To oTableBillOfLading.Rows.Count - 1
        '        hbl.Text += oTableBillOfLading.Rows(ik).Item("hbl").ToString
        '    Next
        'End If


        mbl = rptDocument.ReportDefinition.ReportObjects("mbl")
        mbl.Text = oTableBillOfLading.Rows(0).Item("mbl").ToString

        ref = rptDocument.ReportDefinition.ReportObjects("refno")
        ref.Text = oTableBillOfLading.Rows(0).Item("ref").ToString

        carrier = rptDocument.ReportDefinition.ReportObjects("carrier")
        carrier.Text = oTableBillOfLading.Rows(0).Item("shippingline").ToString


        shipper = rptDocument.ReportDefinition.ReportObjects("shipper_1")
        shipper.Text = oTableBillOfLading.Rows(0).Item("shipper").ToString


        consignee = rptDocument.ReportDefinition.ReportObjects("consignee_1")
        consignee.Text = oTableBillOfLading.Rows(0).Item("consignee").ToString

        ControlingAgent = rptDocument.ReportDefinition.ReportObjects("ControlingAgent")
        ControlingAgent.Text = oTableBillOfLading.Rows(0).Item("AgencyName").ToString

        mother = rptDocument.ReportDefinition.ReportObjects("mother")
        mother.Text = oTableBillOfLading.Rows(0).Item("vessel").ToString + "     " + oTableBillOfLading.Rows(0).Item("voyage").ToString


        etamother = rptDocument.ReportDefinition.ReportObjects("etamother")
        etamother.Text = oTableBillOfLading.Rows(0).Item("eta").ToString.Replace("12:00:00 AM", "")

        pod = rptDocument.ReportDefinition.ReportObjects("pod")
        pod.Text = oTableBillOfLading.Rows(0).Item("pod").ToString

        pol = rptDocument.ReportDefinition.ReportObjects("pol")
        pol.Text = oTableBillOfLading.Rows(0).Item("pol").ToString


        dest = rptDocument.ReportDefinition.ReportObjects("dest")
        dest.Text = oTableBillOfLading.Rows(0).Item("dest").ToString

        CY_CFS_ITEM = rptDocument.ReportDefinition.ReportObjects("movement")
        CY_CFS_ITEM.Text = oTableBillOfLading.Rows(0).Item("CY_CFS_ITEM").ToString

        ' oTableDetailBillOfLading 
        Dim i As Integer
        Dim cargo As String

        If oTableDetailBillOfLading.Rows.Count > 0 Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                cargo += oTableDetailBillOfLading.Rows(i).Item("container_no").ToString + " x " + oTableDetailBillOfLading.Rows(i).Item("container_type").ToString + "," + oTableDetailBillOfLading.Rows(i).Item("amount").ToString + "" + oTableDetailBillOfLading.Rows(i).Item("kind").ToString + "," + oTableDetailBillOfLading.Rows(i).Item("grossweight").ToString + "KGS" + "," + oTableDetailBillOfLading.Rows(i).Item("meas").ToString + "CBM ;    "
            Next
        End If
        volumn = rptDocument.ReportDefinition.ReportObjects("volumn")
        volumn.Text = cargo 'oTableBillOfLading.Rows(0).Item("CY_CFS_ITEM").ToString


        marks = rptDocument.ReportDefinition.ReportObjects("remarks")
        marks.Text = oTableBillOfLading.Rows(0).Item("marks").ToString


        'If Pre_Col = "PREPAID" Then
        '    PrePaid_collect = rptDocument.ReportDefinition.ReportObjects("Prepaid")
        'Else
        '    PrePaid_collect = rptDocument.ReportDefinition.ReportObjects("Collect")
        'End If
        'PrePaid_collect.Text = Pre_Col

        '---Dua vao shipper,Consignee,Notify
       
        '        'DisplayMessage(True, rptDocument.PrintOptions.PageContentWidth())

        '        ' hien thi report
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.ReportSource = rptDocument
        'Formatting paper
        Dim mymargins = rptDocument.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rptDocument.PrintOptions.ApplyPageMargins(mymargins)
        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rptDocument.Refresh()
        Me.CrystalReportViewer1.Show()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmRptMasterBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.chkAttachDescription.Visible = False
        If gInboundBLOriginal = "1" Then
            PrintRPTO()
        Else
            PrintRPT()
        End If

        'Resume
    End Sub

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM BillOfLadingIB  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLadingIB.BLIB_ID= '" & gBillInboundID & "' And BillOfLadingIB.Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function


    Private Function MakeQueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryDetailBillOfLading = " select * "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " FROM (CargoIB LEFT JOIN Container On CargoIB.CTN_ID=Container.CTN_ID) "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " WHERE "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "CargoIB.BLIB_Id = '" & gBillInboundID & "' And CargoIB.Continued=1 "
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = " select * "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "  FROM BillOfLadingIb  "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE (BillOfLadingIB.blib_id = '" & gBillInboundID & "') "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "And ("
        MakeQueryBillOfLading = MakeQueryBillOfLading & "BillOfLadingIB.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Sub QueryCountContainer()
        Try
            Dim strQuery As String
            strQuery = " Select Container_Type,Count(Container_type) as Num From CargoIB"
            strQuery &= " Where BLIB_ID='" & gBillInboundID & "' And Continued=1 Group By Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If oTableCountContainerType.Rows.Count > 0 Then
                oTableCountContainerType.Rows.Clear()
            End If
            Adapter.Fill(oTableCountContainerType)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
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

        If oTableBillOfLading.Rows.Count > 0 Then
            'Vessel = oTableBillOfLading.Rows(0).Item("Vessel").ToString
            'VoyAge = oTableBillOfLading.Rows(0).Item("VoyNo").ToString
        End If

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub QueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryDetailBillOfLading()
        Else
            strQuery = MakeQueryDetailBillOfLading(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableDetailBillOfLading) Then
            oTableDetailBillOfLading.Clear()
        End If
        Adapter.Fill(dsDetailBillOfLading, "DetailBillOfLadingList")
        oTableDetailBillOfLading = dsDetailBillOfLading.Tables(0)
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

    Private Sub chkAttachDescription_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAttachDescription.CheckedChanged
        'PrintRPT()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If gInboundBLOriginal = "1" Then
            PrintRPTO()
        Else
            PrintRPT()
        End If
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class