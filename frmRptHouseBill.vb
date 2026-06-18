Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptHouseBill
    '------------------
    '------------------
    Public RptName As String
    Public oTableBillOfLading_House As DataTable
    Public dsBillOfLading As New DataSet
    '------------------
    Public oTableDetailBillOfLading_House As DataTable
    Public dsDetailBillOfLading As New DataSet
    '--------------------------------
    Public oTableCustomerInfo As DataTable
    Public dsCustomerInfo As New DataSet

    Public oTableCargoDesc, oTableCargoMarks, oTableCargoReMarks As DataTable
    Public dsCargoDesc, dsCargoMarks, dsCargoRemarks As New DataSet
    Const strDetailBillOfLadingSelect As String = "SELECT Distinct " & _
"Container.Container_No,CTN_CARGO_MEASUREMENT,UNIT_MEASUREMENT," & _
       "Container.CTN_SIZE_TYPE ,SealNo, " & _
       "Amount, " & _
       "Kind, " & _
       "Gross, " & _
       "Unit_Gross,HS_Code, temperature_setting,vent "

    Const strCustomerInfo As String = "Select Shipper, " & _
    "" & _
        " " & _
        "" & _
    "Consignee, " & _
        "" & _
        " " & _
        "" & _
    "Notify " & _
        "" & _
        " " & _
        " "


    Const strBillOfLadingSelect As String = "SELECT BillOfLading_House.BL_Id as BillOfLading_HouseId, " & _
"containerOutboundNotify.carrier As Pre_Vessel,containerOutboundNotify.voyno as Pre_VoyNo, " & _
    "BillOfLading_House.ServiceContract As ServiceContract, " & _
"PLACE_OF_RECEIPT_NAME, BL_CY_CFS_ITEM," & _
       "Port_Of_Loading_Name,PLACE_OF_DESTINATION_NAME, " & _
       "Port_Of_Discharge_Name, LOAD_DATE," & _
       "Place_Of_Delivery_Name, " & _
       "PLACE_OF_DESTINATION_NAME, " & _
       "DESCRIPTIONFORSHIPPER, " & _
       "REVENUETON, ToTalContainer,PreightCharges," & _
       "EXCHANGE_RATE, " & _
      "PrepaidAt,PREPAID_OR_COLLECT, " & _
       "PAYABLE_AT, " & _
       "PLACE_OF_BL_ISSUE_NAME, " & _
     "DATE_OF_ISSUE, Note," & _
       "TOTALPREPAID_IN, " & _
       "NO_OF_ORIGINAL_BL, NO_OF_COPY_BL , notShowDes,BL_ClauseText ,SCAC_CODE "
    Public Sub PrintRpt(ByVal BLType As String)
        On Error GoTo Err_Renamed
        Dim rptDocument = New ReportDocument
        Dim strReportName As String
        Dim strQuery As String
        Dim CargoMarks As TextObject
        Dim totalP As Integer = 0
        Dim TotalG As Double = 0
        Dim totalC As Double = 0
        Dim NoteStr, notetemp As String
        Me.ReportViewer.ReportSource = Nothing
        'If RptName = "Data" Then

        '    If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptHouseBillData"
        '    ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptHouseBillData"
        '    ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptHouseBillData_Marks"
        '    ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptHouseBillDataDescription"
        '    ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptHouseBillDataNotify"
        '    Else
        '        strReportName = "rptHouseBillData"
        '    End If
        '    ' ten Report--------------

        '    Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        '    If Not IO.File.Exists(strReportPath) Then
        '        DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
        '        Exit Sub
        '    End If
        '    rptDocument.Load(strReportPath)
        '    '----------------------------

        'Else
        '    'rptDocument = New ReportDocument
        '    ' ten Report--------------
        '    If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptMasterBill"
        '    ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptMasterBill"
        '    ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptMasterBill_Marks"
        '    ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptMasterBill"
        '    ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
        '        strReportName = "rptMasterBill"
        '    Else
        '        strReportName = "rptMasterBill"
        '    End If
        '    '
        '    Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        '    If Not IO.File.Exists(strReportPath) Then
        '        DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
        '        Exit Sub
        '    End If

        '    '----------------------------
        'End If
        If Me.chkDraft.Checked = True Then
            strReportName = "rptHouseBillData_hinh"
        Else
            strReportName = "rptHouseBillData"
        End If
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        rptDocument.Load(strReportPath)
        ' an hinh
        'If Me.chkDraft.Checked = False Then
        '    rptDocument.ReportDefinition.ReportObjects("picture1").ObjectFormat.EnableSuppress = True
        'Else
        '    rptDocument.ReportDefinition.ReportObjects("picture1").ObjectFormat.EnableSuppress = False

        'End If
        '---------------
        Dim CountText() As String = {"NIL", "ONE(1)", "TWO(2)", "THREE(3)", "FOUR(4)", "FIVE(5)", "SIX(6)", "SEVEN(7)", "EIGHT(8)", "NINE(9)", "TEN(10)"}
        ' ten Report
        'strReportName = "RptMasterBill"

        QueryCustomerInfo()
        QueryBillOfLading_House()
        QueryDetailBillOfLading_House()
        QueryCargoMarks()
        ''--------------------
        QueryCargoRemarks()
        '------------------------------
        QueryCargoDescription()

        Dim BillNo, lBBill, BKNo As TextObject
        BillNo = rptDocument.ReportDefinition.ReportObjects("BillNo")
        BillNo.Text = gBillHouseNoRpt

        'BKNo = rptDocument.ReportDefinition.ReportObjects("txtbookingno")
        'BKNo.Text = oTableBillOfLading_House.Rows(0).Item("bookingno").ToString
        '-----------
        If UCase(RptName) <> "DATA" Then
            If BLType = "RICH SHIPPING" Then
                'rptDocument.ReportDefinition.ReportObjects("PT").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("txt1").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("txt2").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("txt3").ObjectFormat.EnableSuppress = True
            Else
                'rptDocument.ReportDefinition.ReportObjects("PT").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("txt1").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("txt2").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("txt3").ObjectFormat.EnableSuppress = False
            End If
            'rptDocument.ReportDefinition.ReportObjects("Picture3").ObjectFormat.EnableSuppress = True
            'rptDocument.ReportDefinition.ReportObjects("line10").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("line11").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("line9").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("line13").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("line12").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("line25").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("line26").ObjectFormat.EnableSuppress = True
            'rptDocument.ReportDefinition.ReportObjects("TEXT19").ObjectFormat.EnableSuppress = True
            'rptDocument.ReportDefinition.ReportObjects("TEXT22").ObjectFormat.EnableSuppress = True
        End If

        '-----------

        '-----Dua du lieu vao report
        If RptName <> "Data" Then

            'rptDocument.ReportDefinition.ReportObjects("Picture1").ObjectFormat.EnableSuppress = False
            If UCase(BLType) = "INSTRUCTION" Then
                'rptDocument.ReportDefinition.ReportObjects("Picture1").ObjectFormat.EnableSuppress = True

                BillNo.Text = oTableBillOfLading_House.Rows(0).Item("bookingno").ToString
                lBBill = rptDocument.ReportDefinition.ReportObjects("text22")
                lBBill.Text = "B/K No. "
            Else
                'lBBill = rptDocument.ReportDefinition.ReportObjects("text22")
                'lBBill.Text = "B/L No. "

            End If
            If UCase(BLType) = "RICH SHIPPING" Then
                'rptDocument.ReportDefinition.ReportObjects("Picture1").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("Picture3").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("line10").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("line11").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("line9").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("line13").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("line12").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("text8").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("line26").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("line25").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("TEXT19").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("TEXT22").ObjectFormat.EnableSuppress = False
                'BillNo.Text = ""
            End If
            Dim BiLLType As TextObject 'seaway bill hay billoflading 
            BiLLType = rptDocument.ReportDefinition.ReportObjects("txtBillType")
            BiLLType.Text = BLType
        End If






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
        Dim shipperTam, ConsigneeTam, NotifyTam As String
        Dim shipperTam1(), ConsigneeTam1(), NotifyTam1() As String




        If oTableCustomerInfo.Rows.Count > 0 Then

            Dim TempShipper, TempConsignee, TempNotify As String
            'TempShipper = oTableCustomerInfo.Rows(0).Item("Shipper_1").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_2").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_3").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_4").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_5").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString


            'Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            'Shipper_1.Text = Strings.Replace(TempShipper, "*", "")

            Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            '------ xuong hang
            shipperTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Shipper").ToString, Chr(13))
            For CountA As Integer = 0 To shipperTam1.Length - 1
                shipperTam &= shipperTam1(CountA).Replace(Chr(10), "")
                For CountSpacea As Integer = shipperTam1(CountA).Length To Shipper_1.Width \ 10
                    shipperTam &= " "
                Next
            Next
            Shipper_1.Text = shipperTam
            'TempConsignee = oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString & "                                                                                                                             "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_2").ToString & "                                                                                                                             "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_3").ToString & "                                                                                                                             "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_4").ToString & "                                                                                                                             "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_5").ToString & "                                                                                                                             "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString

            'Consignee_1 = rptDocument.ReportDefinition.ReportObjects("Consignee_1")
            'Consignee_1.Text = Strings.Replace(TempConsignee, "*", "") 'oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString

            Consignee_1 = rptDocument.ReportDefinition.ReportObjects("Consignee_1")
            '------ xuong hang
            ConsigneeTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Consignee").ToString, Chr(13))
            For CountA As Integer = 0 To ConsigneeTam1.Length - 1
                ConsigneeTam &= ConsigneeTam1(CountA).Replace(Chr(10), "")
                For CountSpacea As Integer = ConsigneeTam1(CountA).Length To Consignee_1.Width \ 10
                    ConsigneeTam &= " "
                Next
            Next
            Consignee_1.Text = ConsigneeTam



            'TempNotify = oTableCustomerInfo.Rows(0).Item("Notify_1").ToString & "                                                                                                                             "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_2").ToString & "                                                                                                                             "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_3").ToString & "                                                                                                                             "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_4").ToString & "                                                                                                                             "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_5").ToString & "                                                                                                                             "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("NotifyRemarks").ToString

            'Notify_1 = rptDocument.ReportDefinition.ReportObjects("Notify_1")
            'Notify_1.Text = Strings.Replace(TempNotify, "*", "")

            Notify_1 = rptDocument.ReportDefinition.ReportObjects("Notify_1")
            '------ xuong hang
            NotifyTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Notify").ToString, Chr(13))
            For CountA As Integer = 0 To NotifyTam1.Length - 1
                NotifyTam &= NotifyTam1(CountA).Replace(Chr(10), "")
                For CountSpacea As Integer = NotifyTam1(CountA).Length To Notify_1.Width \ 10
                    NotifyTam &= " "
                Next
            Next
            Notify_1.Text = NotifyTam

        End If



        Dim ContainerNo1, BL_No1 As TextObject


        Dim Amount1, Kind1 As TextObject


        Dim Gross1, UnitGross1 As TextObject

        Dim Meas1 As TextObject

        Dim SealNo1 As TextObject

        Dim BillAttach, agencyname, AmountAttach, GrossAttach, MeasAttach, TitleAmount, TitleDesc, DescAttach, TitleGross, TitleMeas, TitleContainer, TotalContainer, OtotalP, OtotalG, OtotalC As TextObject
        Dim TitleNotify2, TitleNotify3 As TextObject


        Dim AttckNotify2_, AttckNotify3_ As TextObject

        rptDocument.ReportDefinition.ReportObjects("ShippingMarks").ObjectFormat.EnableSuppress = False
        'BillAttach = rptDocument.ReportDefinition.ReportObjects("BillAttach")
        'BillAttach.Text = ""

        DescAttach = rptDocument.ReportDefinition.ReportObjects("DescAttach")
        DescAttach.Text = ""

        AmountAttach = rptDocument.ReportDefinition.ReportObjects("AmountAttach")
        AmountAttach.Text = ""

        GrossAttach = rptDocument.ReportDefinition.ReportObjects("GrossAttach")
        GrossAttach.Text = ""

        MeasAttach = rptDocument.ReportDefinition.ReportObjects("MeasAttach")
        MeasAttach.Text = ""

        TitleAmount = rptDocument.ReportDefinition.ReportObjects("TitleAmount")
        TitleAmount.Text = ""

        TitleGross = rptDocument.ReportDefinition.ReportObjects("TitleGross")
        TitleGross.Text = ""

        TitleMeas = rptDocument.ReportDefinition.ReportObjects("TitleMeas")
        TitleMeas.Text = ""

        TitleDesc = rptDocument.ReportDefinition.ReportObjects("TitleDesc")
        TitleDesc.Text = ""
        TitleContainer = rptDocument.ReportDefinition.ReportObjects("TitleContainer")
        TitleContainer.Text = ""
        TotalContainer = rptDocument.ReportDefinition.ReportObjects("TotalContainerNo")
        TotalContainer.Text = ""
        '--------------
        Dim dtNotify, dtNotify3 As New DataTable






        ' QueryNotify(dtNotify3, "Notify3_ID")

        '----------------- mo ta hang hoa
        Description = rptDocument.ReportDefinition.ReportObjects("Description1")

        Dim Temp(), Result As String
        Result = ""
        If oTableCargoDesc.Rows.Count > 0 Then
            Dim tempTextObject As TextObject
            Result = oTableCargoDesc.Rows(0).Item("Description").ToString
            'If dtNotify.Rows.Count > 0 And dtNotify3.Rows.Count > 0 Then
            '    Result += oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString + oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString + oTableCustomerInfo.Rows(0).Item("NotifyRemarks").ToString + dtNotify.Rows(0).Item("NotifyRemarks").ToString + dtNotify3.Rows(0).Item("NotifyRemarks").ToString
            'End If
            'If dtNotify.Rows.Count > 0 And dtNotify3.Rows.Count = 0 Then
            '    Result += oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString + oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString + oTableCustomerInfo.Rows(0).Item("NotifyRemarks").ToString + dtNotify.Rows(0).Item("NotifyRemarks").ToString
            'End If
            'If dtNotify.Rows.Count = 0 And dtNotify3.Rows.Count > 0 Then
            '    Result += oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString + oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString + dtNotify.Rows(0).Item("NotifyRemarks").ToString
            'End If
            'If dtNotify.Rows.Count = 0 And dtNotify3.Rows.Count = 0 Then
            '    Result += oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString + oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString + oTableCustomerInfo.Rows(0).Item("NotifyRemarks").ToString
            'End If

            Temp = Strings.Split(Result, Chr(13))
            Result = ""
            For K As Integer = 0 To Temp.Length - 1
                Temp(K) = Temp(K).Replace(Chr(10), "")

            Next
            For j As Integer = 0 To Temp.Length - 1

                Result &= Temp(j)
                For k As Integer = Temp(j).Length To Description.Width \ 10
                    Result &= " "
                Next

            Next

            'Description.Text = Result
        End If



        '-- nkiem tra descriptionco in hay ko notsHOWDes.
        If oTableBillOfLading_House.Rows(0).Item("notShowDes").ToString = "1" Then
            Result = ""
        End If

        '---
        ' agency name
        agencyname = rptDocument.ReportDefinition.ReportObjects("agencyname")
        Dim agencyt As String = ""
        Dim agencyt1() As String = Strings.Split(oTableBillOfLading_House.Rows(0).Item("agencyname").ToString, Chr(13))

        For CountA As Integer = 0 To agencyt1.Length - 1
            agencyt &= agencyt1(CountA).Replace(Chr(10), "")
            For CountSpacea As Integer = agencyt1(CountA).Length To agencyname.Width \ 10
                agencyt &= " "
            Next
        Next
        agencyname.Text = agencyt
        Dim note As Object

        note = rptDocument.ReportDefinition.ReportObjects("txtNote")
        If oTableBillOfLading_House.Rows.Count > 0 Then

            Temp = Strings.Split(oTableBillOfLading_House.Rows(0).Item("Note").ToString, Chr(13))
            For j As Integer = 0 To Temp.Length - 1
                notetemp &= Temp(j)
                For k As Integer = Temp(j).Length To Description.Width \ 10
                    notetemp &= " "
                Next
            Next
            note.text = notetemp
            'Result &= notetemp

            'Result &= vbCrLf
            Result &= oTableBillOfLading_House.Rows(0).Item("BL_ClauseText").ToString


            '  hs code
            If oTableDetailBillOfLading_House.Rows.Count > 0 Then
                If oTableDetailBillOfLading_House.Rows(0).Item("HS_CODE").ToString <> "" Then
                    NoteStr &= vbCrLf
                    NoteStr &= " - HS CODE : " & oTableDetailBillOfLading_House.Rows(0).Item("HS_CODE").ToString
                End If
            End If


            If oTableBillOfLading_House.Rows(0).Item("SCAC_Code").ToString <> "" Then
                NoteStr &= vbCrLf
                NoteStr &= " - SCAC : " & oTableBillOfLading_House.Rows(0).Item("SCAC_Code").ToString
            End If

            '  temp
            'If oTableDetailBillOfLading_House.Rows(0).Item("temperature_setting").ToString <> "" Then
            '    Result &= "                                                                   "
            '    Result &= " - Temp : " & oTableDetailBillOfLading_House.Rows(0).Item("temperature_setting").ToString
            'End If
            'If oTableDetailBillOfLading_House.Rows(0).Item("temperature_setting").ToString <> "..." Then
            '    Result &= "                                                                   "
            '    Result &= " - Temp : " & oTableDetailBillOfLading_House.Rows(0).Item("temperature_setting").ToString
            'End If
            '  vent
            'If oTableDetailBillOfLading_House.Rows(0).Item("vent").ToString <> "" Then
            '    Result &= "                                                                   "
            '    Result &= " - Vent : " & oTableDetailBillOfLading_House.Rows(0).Item("vent").ToString
            'End If
            rptDocument.ReportDefinition.ReportObjects("PreightCharges1").ObjectFormat.EnableSuppress = True
            If Me.chkviewfreight.Checked = True Then
                rptDocument.ReportDefinition.ReportObjects("PreightCharges1").ObjectFormat.EnableSuppress = False
            End If
        End If
        '------------------------

        'thêm ngày 05-11-2007 cho Shippingmarks lên ngay sau Container cuối cùng
        Dim TempTextObj, Remarks As TextObject
        ''''''''''''''''''''''''''''''''''''''''''''''
        If Result.Trim <> "" Then
            'If CheckAttach(Result, 30, 16) = True Then
            '    DisplayMessage(True, "See attach Description!")
            'End If

        End If

        If oTableDetailBillOfLading_House.Rows.Count > 0 Then

            Dim i As Integer
            Dim SoContainer As Integer = 13
            Dim CountContainer As Integer = IIf(oTableDetailBillOfLading_House.Rows.Count > SoContainer, SoContainer, oTableDetailBillOfLading_House.Rows.Count)
            Dim ContainerAttach As Integer = oTableDetailBillOfLading_House.Rows.Count - SoContainer

            '----------
            For Count As Integer = 0 To CountContainer - 1
                ContainerNo1 = rptDocument.ReportDefinition.ReportObjects("ContainerNo" & Count + 1)
                ContainerNo1.Text = IIf(oTableDetailBillOfLading_House.Rows(Count).Item("Container_No").ToString.Trim <> "", oTableDetailBillOfLading_House.Rows(Count).Item("Container_No").ToString.Trim & " / ", "")
                SealNo1 = rptDocument.ReportDefinition.ReportObjects("SealNo" & Count + 1)
                SealNo1.Text = oTableDetailBillOfLading_House.Rows(Count).Item("SealNo").ToString.Trim
            Next
            If CountContainer < SoContainer Then
                TempTextObj = rptDocument.ReportDefinition.ReportObjects("ContainerNo" & CountContainer + 1)
            Else
                TempTextObj = Nothing
            End If
            'description 
            Description.Text = Result
            For i = 0 To CountContainer - 1


                Amount1 = rptDocument.ReportDefinition.ReportObjects("Amount" & i + 1)
                Amount1.Text = FormatNumber(CDbl(oTableDetailBillOfLading_House.Rows(i).Item("Amount").ToString), 0) 'Amount(0)
                'totalP += CInt(Amount1.Text)

                Kind1 = rptDocument.ReportDefinition.ReportObjects("Kind" & i + 1)
                Kind1.Text = oTableDetailBillOfLading_House.Rows(i).Item("Kind").ToString 'Kind(0)


                If oTableDetailBillOfLading_House.Rows(i).Item("Gross").ToString.Trim <> "" Then
                    Gross1 = rptDocument.ReportDefinition.ReportObjects("Gross" & i + 1)
                    Gross1.Text = FormatNumber(CDbl(oTableDetailBillOfLading_House.Rows(i).Item("Gross").ToString), 2)
                    'TotalG += CDbl(Gross1.Text)
                End If


                UnitGross1 = rptDocument.ReportDefinition.ReportObjects("UnitGross" & i + 1)
                UnitGross1.Text = oTableDetailBillOfLading_House.Rows(i).Item("Unit_Gross").ToString 'UnitGross(0)

                Meas1 = rptDocument.ReportDefinition.ReportObjects("Meas" & i + 1)
                Meas1.Text = oTableDetailBillOfLading_House.Rows(i).Item("CTN_CARGO_MEASUREMENT").ToString & " CBM" 'Meas(0)
                'totalC += CDbl(oTableDetailBillOfLading_House.Rows(i).Item("CTN_CARGO_MEASUREMENT").ToString)
            Next
            For i = 0 To oTableDetailBillOfLading_House.Rows.Count - 1
                totalP += FormatNumber(CInt(oTableDetailBillOfLading_House.Rows(i).Item("Amount").ToString), 1)
                TotalG += FormatNumber(CDbl(CDbl(oTableDetailBillOfLading_House.Rows(i).Item("Gross").ToString)), 2)
                totalC += FormatNumber(CDbl(oTableDetailBillOfLading_House.Rows(i).Item("CTN_CARGO_MEASUREMENT").ToString), 2)
            Next
            'shipping marks
            'If oTableCargoMarks.Rows.Count > 0 Then
            '    Dim CargoMarks As TextObject
            '    CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
            '    CargoMarks.Text = oTableCargoMarks.Rows(0).Item("Marks").ToString

            'End If
            If Me.chkViewTotal.Checked = True Then
                rptDocument.ReportDefinition.ReportObjects("totalP").ObjectFormat.EnableSuppress = False
                rptDocument.ReportDefinition.ReportObjects("totalG").ObjectFormat.EnableSuppress = False
                rptDocument.ReportDefinition.ReportObjects("totalC").ObjectFormat.EnableSuppress = False
                OtotalP = rptDocument.ReportDefinition.ReportObjects("totalP")
                OtotalP.Text = CStr(FormatNumber(totalP, 0)) + " " + Kind1.Text
                OtotalG = rptDocument.ReportDefinition.ReportObjects("totalG")
                OtotalG.Text = CStr(FormatNumber(TotalG, 2)) + " " + UnitGross1.Text
                OtotalC = rptDocument.ReportDefinition.ReportObjects("totalC")
                OtotalC.Text = CStr(FormatNumber(totalC, 2)) + " CBM"
            Else
                rptDocument.ReportDefinition.ReportObjects("totalP").ObjectFormat.EnableSuppress = True
                rptDocument.ReportDefinition.ReportObjects("totalG").ObjectFormat.EnableSuppress = True
                rptDocument.ReportDefinition.ReportObjects("totalC").ObjectFormat.EnableSuppress = True
            End If
            If Me.cmdViewCBM.Checked = True Then
                rptDocument.ReportDefinition.ReportObjects("totalC").ObjectFormat.EnableSuppress = False
            Else
                rptDocument.ReportDefinition.ReportObjects("totalC").ObjectFormat.EnableSuppress = True
            End If

            'If UCase(RptName) <> "DATA" Then
            If Me.chkviewnote.Checked = True Then
                rptDocument.ReportDefinition.ReportObjects("txtnote").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("text18").ObjectFormat.EnableSuppress = False
                'rptDocument.ReportDefinition.ReportObjects("text23").ObjectFormat.EnableSuppress = False
            Else
                rptDocument.ReportDefinition.ReportObjects("txtnote").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("text18").ObjectFormat.EnableSuppress = True
                'rptDocument.ReportDefinition.ReportObjects("text23").ObjectFormat.EnableSuppress = True
            End If
            'End If

            If oTableCargoMarks.Rows.Count > 0 Then
                'Dim CargoMarks As TextObject
                'CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                Dim TempMarks() As String

                CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                If Not IsNothing(TempTextObj) Then
                    CargoMarks.Top = TempTextObj.Top + TempTextObj.Height + 100
                End If
                TempMarks = Strings.Split(oTableCargoMarks.Rows(0).Item("Marks").ToString, Chr(13))
                Dim ResultMarks As String = ""
                For CountMark As Integer = 0 To TempMarks.Length - 1
                    ResultMarks &= TempMarks(CountMark).Replace(Chr(10), "")
                    For CountSpace As Integer = 0 To CargoMarks.Width \ 10
                        ResultMarks &= " "
                    Next
                Next

                CargoMarks.Text = " " & ResultMarks
                '-----------------kiem tra neu khong neu khong in attach thi dua marks vao
                If Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                Else
                    'Result = Result + "                                        " + " " & ResultMarks & "    "
                End If

                Result &= NoteStr
                Result &= notetemp
                Description.Text = Result
            End If
            '-------------------------------------------------
            If oTableCargoReMarks.Rows.Count > 0 Then
                'Dim CargoMarks As TextObject
                'CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                Dim TempReMarks() As String

                Remarks = rptDocument.ReportDefinition.ReportObjects("txtReMarks")
                'If Not IsNothing(TempTextObj) Then
                '    CargoMarks.Top = TempTextObj.Top + TempTextObj.Height + 100
                'End If
                TempReMarks = Strings.Split(oTableCargoReMarks.Rows(0).Item("CARGO_REMARKS").ToString, Chr(13))
                Dim ResultReMarks As String = ""
                For CountMark As Integer = 0 To TempReMarks.Length - 1
                    ResultReMarks &= TempReMarks(CountMark).Replace(Chr(10), "")
                    For CountSpace As Integer = 0 To Remarks.Width \ 10
                        ResultReMarks &= " "
                    Next
                Next

                Remarks.Text = ResultReMarks

            End If
            '-----------------------------------------------------------
            Dim CY_CFS As TextObject
            CY_CFS = rptDocument.ReportDefinition.ReportObjects("CY_CFS")
            CY_CFS.Text = oTableBillOfLading_House.Rows(0).Item("BL_CY_CFS_ITEM").ToString
            '''''''''''''''''''--
            ' Attach container
            Dim AttachContainer As TextObject
            ' kiem tra description
            'If CheckAttach(Result, 30, 16) = True Then
            '    DisplayMessage(True, "See attach Description!")
            'End If


            AttachContainer = rptDocument.ReportDefinition.ReportObjects("AttachContainer")
            If ContainerAttach > 0 Or Me.chkPrintAttachList.Checked = True Or dtNotify.Rows.Count > 0 Or dtNotify.Rows.Count > 0 Then
                'Dim AttckNotify2_, AttckNotify3_ As TextObject

                If Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    For i = 1 To 5
                        AttckNotify2_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_" & i)
                        AttckNotify2_.Text = ""
                        AttckNotify3_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_" & i)
                        AttckNotify3_.Text = ""
                    Next
                    TitleNotify2 = rptDocument.ReportDefinition.ReportObjects("TitleNotify2")
                    TitleNotify2.Text = ""

                    TitleNotify3 = rptDocument.ReportDefinition.ReportObjects("TitleNotify3")
                    TitleNotify3.Text = ""
                    If dtNotify.Rows.Count > 0 Then
                        TitleNotify2.Text = "Notify 2"
                        AttckNotify2_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_1")
                        For K As Integer = 1 To 5
                            AttckNotify2_.Text += dtNotify.Rows(0).Item("Notify_" & K).ToString + "  "
                        Next
                        AttckNotify2_.Text &= dtNotify.Rows(0).Item("NotifyRemarks").ToString
                        AttckNotify2_.Text = Strings.Replace(AttckNotify2_.Text, "*", "")
                    End If
                    If dtNotify3.Rows.Count > 0 Then
                        TitleNotify3.Text = "Notify 3"
                        AttckNotify3_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_1")
                        For K As Integer = 1 To 5

                            AttckNotify3_.Text += dtNotify3.Rows(0).Item("Notify_" & K).ToString + "  "
                        Next
                        AttckNotify3_.Text &= dtNotify3.Rows(0).Item("NotifyRemarks").ToString
                        AttckNotify3_.Text = Strings.Replace(AttckNotify3_.Text, "*", "")
                    End If

                    MsgBox("This bill has Attach Container")
                    ContainerNo1 = rptDocument.ReportDefinition.ReportObjects("ContainerNo1")
                    ContainerNo1.Text = "Attach List"
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    If UCase(BLType) = "INSTRUCTION" Then
                        'rptDocument.ReportDefinition.ReportObjects("Picture1").ObjectFormat.EnableSuppress = True
                        BL_No1.Text = ""
                    Else

                        BL_No1.Text = gBillHouseNoRpt

                    End If


                    Dim TempContainer As String = ""
                    Dim TempGross As String = ""
                    Dim TempAmount As String = ""
                    Dim TempMeas As String = ""

                    'BillAttach.Text = "Attach List  Bill No:" & gBillNoRpt
                    DescAttach.Text = Result

                    TitleAmount.Text = "Amount "

                    TitleGross.Text = "Gross "

                    TitleMeas.Text = "Measurement "

                    TitleDesc.Text = "Description Of Goods "

                    TitleContainer.Text = "Marks & ContainerNo / Seal "

                    TotalContainer.Text = "ToTal : " & oTableDetailBillOfLading_House.Rows.Count & " Containers"

                    For j As Integer = 0 To oTableDetailBillOfLading_House.Rows.Count - 1
                        TempContainer &= j + 1 & ")" & oTableDetailBillOfLading_House.Rows(j).Item("Container_No").ToString.Trim() & " / " & oTableDetailBillOfLading_House.Rows(j).Item("CTN_SIZE_TYPE").ToString.Trim()
                        TempContainer &= " / " & oTableDetailBillOfLading_House.Rows(j).Item("SealNo").ToString.Trim() & "                             "
                        TempAmount &= FormatNumber(oTableDetailBillOfLading_House.Rows(j).Item("Amount").ToString.Trim(), 0)
                        TempAmount &= " " & oTableDetailBillOfLading_House.Rows(j).Item("Kind").ToString.Trim() & "                           "
                        TempGross &= FormatNumber(oTableDetailBillOfLading_House.Rows(j).Item("Gross").ToString, 2)
                        TempGross &= " " & oTableDetailBillOfLading_House.Rows(j).Item("Unit_Gross").ToString & "                            "
                        TempMeas &= FormatNumber(oTableDetailBillOfLading_House.Rows(j).Item("CTN_CARGO_MEASUREMENT").ToString, 2) & " CBM" & "                                "
                    Next
                    AttachContainer.Text = TempContainer
                    AmountAttach.Text = TempAmount
                    GrossAttach.Text = TempGross
                    MeasAttach.Text = TempMeas
                    'ahipping marks
                    If oTableCargoMarks.Rows.Count > 0 Then
                        'Dim CargoMarks As TextObject
                        'CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                        Dim TempMarks() As String
                        TempMarks = Strings.Split(oTableCargoMarks.Rows(0).Item("Marks").ToString, Chr(13))
                        Dim ResultMarks As String = " "
                        For CountMark As Integer = 0 To TempMarks.Length - 1
                            ResultMarks &= TempMarks(CountMark)
                            For CountSpace As Integer = 0 To AttachContainer.Width \ 10
                                ResultMarks &= " "
                            Next
                        Next

                        ' AttachContainer.Text &= "   * SHIPPING MARKS: " & ResultMarks
                    End If
                    '-----cho an het
                    For i = 0 To CountContainer - 1


                        Amount1 = rptDocument.ReportDefinition.ReportObjects("Amount" & i + 1)
                        Amount1.Text = ""


                        Kind1 = rptDocument.ReportDefinition.ReportObjects("Kind" & i + 1)
                        Kind1.Text = ""


                        If oTableDetailBillOfLading_House.Rows(i).Item("Gross").ToString.Trim <> "" Then
                            Gross1 = rptDocument.ReportDefinition.ReportObjects("Gross" & i + 1)
                            Gross1.Text = ""
                        End If


                        UnitGross1 = rptDocument.ReportDefinition.ReportObjects("UnitGross" & i + 1)
                        UnitGross1.Text = ""

                        Meas1 = rptDocument.ReportDefinition.ReportObjects("Meas" & i + 1)
                        Meas1.Text = ""

                    Next
                    For Count As Integer = 0 To CountContainer - 1
                        ContainerNo1 = rptDocument.ReportDefinition.ReportObjects("ContainerNo" & Count + 1)
                        ContainerNo1.Text = ""
                        SealNo1 = rptDocument.ReportDefinition.ReportObjects("SealNo" & Count + 1)
                        SealNo1.Text = ""
                    Next
                    ContainerNo1.Text = "Attach list"
                    Description.Text = ""
                    CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                    CargoMarks.Text = ""
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    BL_No1.Text = gBillHouseNoRpt
                    If oTableCargoMarks.Rows.Count > 0 Then
                        'Dim CargoMarks As TextObject
                        'CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
                        Dim TempMarks() As String
                        'TempMarks = Strings.Split(oTableCargoMarks.Rows(0).Item("Marks").ToString, Chr(13))
                        'Dim ResultMarks As String = " "
                        'For CountMark As Integer = 0 To TempMarks.Length - 1
                        '    ResultMarks &= TempMarks(CountMark)
                        '    For CountSpace As Integer = 0 To AttachContainer.Width \ 10
                        '        ResultMarks &= " "
                        '    Next
                        'Next
                        '------------------------------------------------------------
                        TempMarks = Strings.Split(oTableCargoMarks.Rows(0).Item("Marks").ToString, Chr(13))
                        Dim ResultMarks As String = ""
                        For CountMark As Integer = 0 To TempMarks.Length - 1
                            ResultMarks &= TempMarks(CountMark).Replace(Chr(10), "")
                            For CountSpace As Integer = 0 To CargoMarks.Width \ 10
                                ResultMarks &= " "
                            Next
                        Next

                        '-------------------------------------------------------------

                        AttachContainer.Text &= "     " & ResultMarks
                        CargoMarks.Text = " Attach list"
                        'rptDocument.ReportDefinition.ReportObjects("ShippingMarks").ObjectFormat.EnableSuppress = True
                    End If
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    BL_No1.Text = gBillHouseNoRpt
                    DescAttach.Text = Result
                    Description.Text = "  Attach list"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    BL_No1.Text = gBillHouseNoRpt


                    For i = 1 To 5
                        AttckNotify2_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_" & i)
                        AttckNotify2_.Text = ""
                        AttckNotify3_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_" & i)
                        AttckNotify3_.Text = ""
                    Next
                    TitleNotify2 = rptDocument.ReportDefinition.ReportObjects("TitleNotify2")
                    TitleNotify2.Text = ""

                    TitleNotify3 = rptDocument.ReportDefinition.ReportObjects("TitleNotify3")
                    TitleNotify3.Text = ""
                    If dtNotify.Rows.Count > 0 Then
                        TitleNotify2.Text = "Notify 2"
                        AttckNotify2_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify2_1")
                        For K As Integer = 1 To 5

                            AttckNotify2_.Text += dtNotify.Rows(0).Item("Notify_" & K).ToString + "  "
                        Next
                        AttckNotify2_.Text &= dtNotify.Rows(0).Item("NotifyRemarks").ToString
                        AttckNotify2_.Text = Strings.Replace(AttckNotify2_.Text, "*", "")
                    End If
                    If dtNotify3.Rows.Count > 0 Then
                        TitleNotify3.Text = "Notify 3"
                        AttckNotify3_ = rptDocument.ReportDefinition.ReportObjects("AttachNotify3_1")
                        For K As Integer = 1 To 5
                            AttckNotify3_.Text += dtNotify3.Rows(0).Item("Notify_" & K).ToString + "  "
                        Next
                        AttckNotify3_.Text &= dtNotify3.Rows(0).Item("NotifyRemarks").ToString
                        AttckNotify3_.Text = Strings.Replace(AttckNotify3_.Text, "*", "")
                    End If
                End If ' end of attach


            Else

            End If


        End If
        '        '----cac chi tiet
        If oTableBillOfLading_House.Rows.Count > 0 Then

            TotalContainer = rptDocument.ReportDefinition.ReportObjects("TotalContainer")
            TotalContainer.Text = oTableBillOfLading_House.Rows(0).Item("ToTalContainer").ToString
            '---------------
            Dim PreightCharges As TextObject
            PreightCharges = rptDocument.ReportDefinition.ReportObjects("PreightCharges1")
            Dim TempPrei(), ResultPrei As String
            Dim tempTextObjectPrei As TextObject
            ResultPrei = Me.oTableBillOfLading_House.Rows(0).Item("PreightCharges").ToString
            TempPrei = Strings.Split(ResultPrei, Chr(13))
            ResultPrei = ""

            For j As Integer = 0 To TempPrei.Length - 1

                ResultPrei &= TempPrei(j)
                For k As Integer = TempPrei(j).Length To PreightCharges.Width \ 10
                    ResultPrei &= " "
                Next

            Next
            PreightCharges.Text = ResultPrei

            Dim ServiceContract As TextObject
            'ServiceContract = rptDocument.ReportDefinition.ReportObjects("ServiceContract")
            'If oTableBillOfLading_House.Rows(0).Item("ServiceContract").ToString <> "" Then
            '    ServiceContract.Text = "S/C: " + oTableBillOfLading_House.Rows(0).Item("ServiceContract").ToString
            'Else
            '    ServiceContract.Text = ""
            'End If


            Dim PreCarriageVessel As TextObject
            PreCarriageVessel = rptDocument.ReportDefinition.ReportObjects("Pre_Vessel")
            PreCarriageVessel.Text = oTableBillOfLading_House.Rows(0).Item("Pre_Vessel").ToString


            Dim PreCarriageVoyNo As TextObject
            PreCarriageVoyNo = rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo")
            PreCarriageVoyNo.Text = oTableBillOfLading_House.Rows(0).Item("Pre_VoyNo").ToString

            Dim Mother As TextObject
            Mother = rptDocument.ReportDefinition.ReportObjects("OceanVesselName")
            Mother.Text = oTableBillOfLading_House.Rows(0).Item("mother").ToString


            Dim voyMother As TextObject
            voyMother = rptDocument.ReportDefinition.ReportObjects("VoyNo")
            voyMother.Text = oTableBillOfLading_House.Rows(0).Item("Voymother").ToString

            Dim PlaceOfReceipt As TextObject
            PlaceOfReceipt = rptDocument.ReportDefinition.ReportObjects("PlaceOfReceipt")
            PlaceOfReceipt.Text = oTableBillOfLading_House.Rows(0).Item("Place_Of_Receipt_Name").ToString



            Dim DescriptionShipper, marks As TextObject
            Dim des1(), des2() As String
            Dim destam, destam2 As String
            DescriptionShipper = rptDocument.ReportDefinition.ReportObjects("DescriptionShipper")
            'DescriptionShipper.Text = oTableBillOfLading_House.Rows(0).Item("DESCRIPTIONFORSHIPPER").ToString
            '--------------------------------------------------------------------------
            'Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            '------ xuong hang
            des1 = Strings.Split(oTableBillOfLading_House.Rows(0).Item("DESCRIPTIONFORSHIPPER").ToString, Chr(13))
            For CountA As Integer = 0 To des1.Length - 1
                destam &= des1(CountA).Replace(Chr(10), "")
                For CountSpacea As Integer = des1(CountA).Length To Shipper_1.Width \ 10
                    destam &= " "
                Next
            Next
            DescriptionShipper.Text = destam
            '-----------------------------------------------------------------------------

            'marks = rptDocument.ReportDefinition.ReportObjects("txtmarks")
            ''DescriptionShipper.Text = oTableBillOfLading_House.Rows(0).Item("DESCRIPTIONFORSHIPPER").ToString
            ''--------------------------------------------------------------------------
            ''Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            ''------ xuong hang
            'des2 = Strings.Split(oTableBillOfLading_House.Rows(0).Item("marks").ToString, Chr(13))
            'For CountA As Integer = 0 To des2.Length - 1
            '    destam2 &= des2(CountA).Replace(Chr(10), "")
            '    For CountSpacea As Integer = des2(CountA).Length To Shipper_1.Width \ 10
            '        destam2 &= " "
            '    Next
            'Next
            'marks.Text = destam2
            '-----------------------------------------------------------------------------


            Dim PortOfLoading As TextObject
            PortOfLoading = rptDocument.ReportDefinition.ReportObjects("PortOfLoading")
            PortOfLoading.Text = oTableBillOfLading_House.Rows(0).Item("Port_Of_Loading_Name").ToString

            Dim PortOfDischarge As TextObject
            PortOfDischarge = rptDocument.ReportDefinition.ReportObjects("PortOfDischarge")
            PortOfDischarge.Text = oTableBillOfLading_House.Rows(0).Item("Port_Of_Discharge_Name").ToString

            Dim PlaceOfDelivery As TextObject
            PlaceOfDelivery = rptDocument.ReportDefinition.ReportObjects("PlaceOfDelivery")
            PlaceOfDelivery.Text = oTableBillOfLading_House.Rows(0).Item("Place_Of_Delivery_Name").ToString

            Dim FinalDestination As TextObject
            FinalDestination = rptDocument.ReportDefinition.ReportObjects("FinalDestination")
            FinalDestination.Text = oTableBillOfLading_House.Rows(0).Item("PLACE_OF_DESTINATION_NAME").ToString

            Dim RevenueTons As TextObject
            RevenueTons = rptDocument.ReportDefinition.ReportObjects("RevenueTons")
            Dim ResultRen As String
            Dim tempren() As String
            tempren = Split(oTableBillOfLading_House.Rows(0).Item("REVENUETON").ToString, Chr(13))
            ResultRen = ""
            For j As Integer = 0 To tempren.Length - 1
                ResultRen &= tempren(j)
                For k As Integer = tempren(j).Length To RevenueTons.Width \ 10
                    ResultRen &= " "
                Next
            Next

            RevenueTons.Text = ResultRen

            Dim Rate As TextObject
            Rate = rptDocument.ReportDefinition.ReportObjects("Rate")
            Rate.Text = oTableBillOfLading_House.Rows(0).Item("EXCHANGE_RATE").ToString
            If UCase(oTableBillOfLading_House.Rows(0).Item("PREPAID_OR_COLLECT").ToString) = "COLLECT" Then
                Dim Collect As TextObject
                Collect = rptDocument.ReportDefinition.ReportObjects("Collect")
                Collect.Text = "X" '+ oTableBillOfLading_House.Rows(0).Item("PREPAID_OR_COLLECT").ToString
            ElseIf UCase(oTableBillOfLading_House.Rows(0).Item("PREPAID_OR_COLLECT").ToString) = "PREPAID" Then
                Dim Prepaid As TextObject
                Prepaid = rptDocument.ReportDefinition.ReportObjects("Prepaid")
                Prepaid.Text = "X" ' + oTableBillOfLading_House.Rows(0).Item("PREPAID_OR_COLLECT").ToString


            End If



            Dim PrepaidAt As TextObject
            PrepaidAt = rptDocument.ReportDefinition.ReportObjects("PrepaidAt")
            PrepaidAt.Text = TSName(oTableBillOfLading_House.Rows(0).Item("PREPAIDAT").ToString)

            Dim PayableAt As TextObject
            PayableAt = rptDocument.ReportDefinition.ReportObjects("PayableAt")
            PayableAt.Text = TSName(oTableBillOfLading_House.Rows(0).Item("Payable_At").ToString)

            Dim PlaceOfIssue As TextObject
            PlaceOfIssue = rptDocument.ReportDefinition.ReportObjects("PlaceOfIssue")
            PlaceOfIssue.Text = oTableBillOfLading_House.Rows(0).Item("PLACE_OF_BL_ISSUE_NAME").ToString

            Dim DateOfIssue As TextObject
            DateOfIssue = rptDocument.ReportDefinition.ReportObjects("DateOfIssue")
            If oTableBillOfLading_House.Rows(0).Item("Date_Of_Issue").ToString = "" Then
                DateOfIssue.Text = ""
            Else
                DateOfIssue.Text = VB6.Format(oTableBillOfLading_House.Rows(0).Item("Date_Of_Issue").ToString, "MMMM dd,yyyy")
            End If


            Dim LoadDate As TextObject
            LoadDate = rptDocument.ReportDefinition.ReportObjects("LoadDate")
            If oTableBillOfLading_House.Rows(0).Item("Load_Date").ToString = "" Then
                LoadDate.Text = ""

            Else

                LoadDate.Text = VB6.Format(oTableBillOfLading_House.Rows(0).Item("Load_Date").ToString, "MMMM dd,yyyy")
            End If

            Dim TotalPrepaidIn As TextObject
            TotalPrepaidIn = rptDocument.ReportDefinition.ReportObjects("TotalPrepaidIn")
            TotalPrepaidIn.Text = TSName(oTableBillOfLading_House.Rows(0).Item("TOTALPREPAID_IN").ToString)

            Dim NoOfOrigineBL As TextObject
            Dim Num As Integer
            Num = CInt(IIf(oTableBillOfLading_House.Rows(0).Item("NO_OF_ORIGINAL_BL").ToString <> "", oTableBillOfLading_House.Rows(0).Item("NO_OF_ORIGINAL_BL").ToString, -1))
            NoOfOrigineBL = rptDocument.ReportDefinition.ReportObjects("NoOfOrigineBL")
            'If gBillHouseNoRpt Like "CU70*" Then
            '    If Num <> -1 Then
            '        NoOfOrigineBL.Text = CountText(Num)
            '    Else
            '        NoOfOrigineBL.Text = ""
            '    End If
            'Else
            '    NoOfOrigineBL.Text = "NIL"
            'End If
            'If UCase(RptName) = "DATA" Then
            '    NoOfOrigineBL.Text = CountText(Num)
            'End If
            'If Me.chkthreenill.Checked = True Then
            If Num < 0 Then
                NoOfOrigineBL.Text = ""
            Else
                NoOfOrigineBL.Text = CountText(Num)

            End If


            'End If
        End If
        'hienthibooking
        Dim bk As Object
        bk = rptDocument.ReportDefinition.ReportObjects("txtbookingno")
        bk.Text = "" + oTableBillOfLading_House.Rows(0).Item("bookingno").ToString
        ' hien thi p/c
        If Me.chkViewPC.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("prepaid").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("collect").ObjectFormat.EnableSuppress = False
        Else
            rptDocument.ReportDefinition.ReportObjects("prepaid").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("collect").ObjectFormat.EnableSuppress = True
        End If
        If Me.chkDest.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("FinalDestination").ObjectFormat.EnableSuppress = False
        Else
            rptDocument.ReportDefinition.ReportObjects("FinalDestination").ObjectFormat.EnableSuppress = True

        End If
        '----------------------
        ' hien thi Surrendered
        Dim SHOW As Object
        'rptDocument.ReportDefinition.ReportObjects("txtSur").ObjectFormat.EnableSuppress = False
        If Me.ChkSur.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("txtSur").ObjectFormat.EnableSuppress = False
            ' HIENTHI

            SHOW = rptDocument.ReportDefinition.ReportObjects("TXTSUR")
            SHOW.Text = Me.cboBillType.Text
        Else
            rptDocument.ReportDefinition.ReportObjects("txtSur").ObjectFormat.EnableSuppress = True

        End If
        '----------------------
        '----------------------
        ' hien thi p/c
        If Me.chkMother.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("OceanVesselName").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("VoyNo").ObjectFormat.EnableSuppress = False
        Else
            rptDocument.ReportDefinition.ReportObjects("OceanVesselName").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("VoyNo").ObjectFormat.EnableSuppress = True
        End If
        '----------------------
        ' hien thi p/c
        If Me.chkfeeder.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("Pre_Vessel").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo").ObjectFormat.EnableSuppress = False
        Else
            rptDocument.ReportDefinition.ReportObjects("Pre_Vessel").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo").ObjectFormat.EnableSuppress = True
        End If
        '----------------------
        If UCase(BLType) = "INSTRUCTION" Then
            'rptDocument.ReportDefinition.ReportObjects("Picture1").ObjectFormat.EnableSuppress = True
            BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
            BL_No1.Text = ""
        Else
            BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
            BL_No1.Text = gBillHouseNoRpt

        End If

        If Me.chkDateIssue.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("DateOfIssue").ObjectFormat.EnableSuppress = False
            'rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo").ObjectFormat.EnableSuppress = False
        Else
            rptDocument.ReportDefinition.ReportObjects("DateOfIssue").ObjectFormat.EnableSuppress = True
            ' rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo").ObjectFormat.EnableSuppress = True
        End If
        '-------------------------------------
        ' an hien M.Vessel, CBM
        Dim m As Integer
        If Me.cmdViewCBM.Checked = False Then
            For m = 0 To 15 - 1
                rptDocument.ReportDefinition.ReportObjects("Meas" & m + 1).ObjectFormat.EnableSuppress = True
            Next
            rptDocument.ReportDefinition.ReportObjects("MeasAttach").ObjectFormat.EnableSuppress = True

        End If

        '        'DisplayMessage(True, rptDocument.PrintOptions.PageContentWidth())

        '        ' hien thi report
        ' an so cont /seal
        If Me.chkShowCont.Checked = True Then
            rptDocument.ReportDefinition.ReportObjects("containerno1").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("sealno1").ObjectFormat.EnableSuppress = False

            rptDocument.ReportDefinition.ReportObjects("containerno2").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("sealno2").ObjectFormat.EnableSuppress = False

            rptDocument.ReportDefinition.ReportObjects("containerno3").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("sealno3").ObjectFormat.EnableSuppress = False

            rptDocument.ReportDefinition.ReportObjects("containerno4").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("sealno4").ObjectFormat.EnableSuppress = False

            rptDocument.ReportDefinition.ReportObjects("containerno5").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("sealno5").ObjectFormat.EnableSuppress = False

            rptDocument.ReportDefinition.ReportObjects("containerno6").ObjectFormat.EnableSuppress = False
            rptDocument.ReportDefinition.ReportObjects("sealno6").ObjectFormat.EnableSuppress = False
        Else
            rptDocument.ReportDefinition.ReportObjects("containerno1").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("sealno1").ObjectFormat.EnableSuppress = True

            rptDocument.ReportDefinition.ReportObjects("containerno2").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("sealno2").ObjectFormat.EnableSuppress = True

            rptDocument.ReportDefinition.ReportObjects("containerno3").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("sealno3").ObjectFormat.EnableSuppress = True

            rptDocument.ReportDefinition.ReportObjects("containerno4").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("sealno4").ObjectFormat.EnableSuppress = True

            rptDocument.ReportDefinition.ReportObjects("containerno5").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("sealno5").ObjectFormat.EnableSuppress = True

            rptDocument.ReportDefinition.ReportObjects("containerno6").ObjectFormat.EnableSuppress = True
            rptDocument.ReportDefinition.ReportObjects("sealno6").ObjectFormat.EnableSuppress = True
        End If
        'Formatting paper
        'rptDocument.ReportDefinition.ReportObjects("ShippingMarks").ObjectFormat.EnableSuppress = True
        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4

        Dim mymargins = rptDocument.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rptDocument.PrintOptions.ApplyPageMargins(mymargins)
        'If frmMain.mnuReportOrientationPortrait.Checked Then
        rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        'Else
        '    rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        'End If
        rptDocument.Refresh()
        Me.ReportViewer.Refresh()
        Me.ReportViewer.ReportSource = rptDocument
        Me.ReportViewer.Show()

        rptDocument = Nothing
        Exit Sub
Err_Renamed:
        rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        'Else
        '    rptDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        'End If
        rptDocument.Refresh()
        Me.ReportViewer.Refresh()
        Me.ReportViewer.ReportSource = rptDocument
        Me.ReportViewer.Show()


        rptDocument = Nothing
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub QueryNotify(ByRef dt As DataTable, ByVal NotifyID As String)
        Dim strQuery As String
        strQuery = " Select Top 1 Notify.Notify_1 ,Notify.Notify_2, Notify.Notify_3,Notify.Notify_4,Notify.Notify_5,Notify.Notify_6,Notify.Remarks as NotifyRemarks "
        strQuery &= " From (BillOfLading_house LEFT JOIN Notify On BillOfLading_House." & NotifyID & "=Notify.Notify_ID) "
        strQuery &= " Where BillofLading_house.Continued=1 And BLH_ID='" & gBillOfLadingHouseRpt & "' And Notify.Notify_ID <>'" & DefaultValue & "'"

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

    Private Sub frmRptHouseBill_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.ReportViewer.Dispose()
    End Sub

    Private Sub frmRptMasterBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrintRpt("BILL OF LADING")
    End Sub

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM billOfLading_House "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLading_House.BLH_ID= '" & gBillOfLadingHouseRpt & "' And BillOfLading_House.Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function


    Private Function MakeQueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryDetailBillOfLading = strDetailBillOfLadingSelect
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " FROM ((Cargo_House LEFT JOIN Container On Cargo_House.CTN_ID=Container.CTN_ID) "

        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN SEAL On Cargo_House.SEAL_ID=SEAL.SEAL_ID) "

        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "WHERE "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "Cargo_House.BLH_Id = '" & gBillOfLadingHouseRpt & "' And Cargo_House.Continued=1 "
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = strBillOfLadingSelect
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " ,bookingno,agencyname,mother,voymother FROM ((((BillOfLading_House left join ContainerOutboundNotify on BillOfLading_House.ContainerOutboundNotifyid=ContainerOutboundNotify.ContainerOutboundNotifyid )"
        MakeQueryBillOfLading = MakeQueryBillOfLading & "left join SailingSchedule on ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " left join Vessel on Vessel.Vessel_ID=SailingSchedule.Vessel_Id) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN BL_Clause On BL_Clause.BL_ClauseID=BillOfLading_house.BL_ClauseID)"
        MakeQueryBillOfLading = MakeQueryBillOfLading & "WHERE (BillOfLading_House.BLH_ID = '" & gBillOfLadingHouseRpt & "') "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "And ("
        MakeQueryBillOfLading = MakeQueryBillOfLading & "BillOfLading_House.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub QueryBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
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
        If Not IsNothing(oTableBillOfLading_House) Then
            oTableBillOfLading_House.Clear()
        End If
        Adapter.Fill(dsBillOfLading, "BillOfLadingList")
        oTableBillOfLading_House = dsBillOfLading.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub QueryDetailBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
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
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            oTableDetailBillOfLading_House.Clear()
        End If
        Adapter.Fill(dsDetailBillOfLading, "DetailBillOfLadingList")
        oTableDetailBillOfLading_House = dsDetailBillOfLading.Tables(0)
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
        If Not IsNothing(oTableCargoDesc) Then
            oTableCargoDesc.Clear()
        End If
        Adapter.Fill(dsCargoDesc, "CargoDesc")
        oTableCargoDesc = dsCargoDesc.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCargoMarks(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select MARKS from CARGOHouse_MARKS Where BLH_ID='" & gBillOfLadingHouseRpt & "'"
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

    Sub QueryCargoRemarks(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select CARGO_REMARKS from CARGOHouse_Remarks Where BLH_ID='" & gBillOfLadingHouseRpt & "' "
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoReMarks) Then
            oTableCargoReMarks.Clear()
        End If
        Adapter.Fill(dsCargoRemarks, "CargoRemarks")
        oTableCargoReMarks = dsCargoRemarks.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub cboBillType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillType.SelectedIndexChanged, cboAttach.SelectedIndexChanged
        'PrintRpt(Me.cboBillType.Text.Trim)
    End Sub

    Private Sub chkPrintAttachList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintAttachList.CheckedChanged
        'PrintRpt(Me.cboBillType.Text.Trim)
    End Sub

    Private Sub cmdrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefresh.Click
        PrintRpt(Me.cboBillType.Text.Trim)
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer.Load

    End Sub
End Class