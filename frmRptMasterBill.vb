Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptMasterBill
    '------------------
    Dim PayableAt As String = ""
    Public oTableBillOfLading As DataTable
    Public dsBillOfLading As New DataSet
    Public rptName As String
    '------------------
    Public oTableDetailBillOfLading As DataTable
    Public dsDetailBillOfLading As New DataSet
    '--------------------------------
    Public oTableCustomerInfo As DataTable
    Public dsCustomerInfo As New DataSet

    Public oTableCargoDesc, oTableCargoMarks, oTableCargoReMarks As DataTable
    Public dsCargoDesc, dsCargoMarks, dsCargoRemarks As New DataSet
    Public rptDocument As Object

    Const strDetailBillOfLadingSelect As String = "SELECT Distinct " & _
"Container.Container_No,CTN_CARGO_MEASUREMENT,UNIT_MEASUREMENT," & _
       "Container.CTN_SIZE_TYPE ,SealNo, " & _
       "Amount, " & _
       "Kind, " & _
       "Gross, " & _
       "Unit_Gross, HS_Code, temperature_setting,vent "

    Const strCustomerInfo As String = "Select Shipper.Shipper_1, " & _
    "Shipper.Shipper_2 , Shipper.Shipper_3,Shipper.Shipper_4," & _
        "Shipper.Shipper_5 , " & _
        "Shipper.Shipper_6 , Shipper.Remarks as ShipperRemarks," & _
    "Consignee.Consignee_1, " & _
        "Consignee.Consignee_2 , Consignee.Consignee_3,Consignee.Consignee_4," & _
        "Consignee.Consignee_5 , " & _
        "Consignee.Consignee_6 , Consignee.Remarks as ConsigneeRemarks," & _
    "Notify.Notify_1 , " & _
        "Notify.Notify_2, Notify.Notify_3,Notify.Notify_4," & _
        "Notify.Notify_5, " & _
        "Notify.Notify_6 , Notify.Remarks as NotifyRemarks "


    Const strBillOfLadingSelect As String = "SELECT BillOfLading.BL_Id as BillOfLadingId,BillOfLading.telex, " & _
"Vessel.Vessel As Pre_Vessel,Sailingschedule.VoyNo as Pre_VoyNo, " & _
    "BillOfLading.ServiceContract As ServiceContract, " & _
"PLACE_OF_RECEIPT_NAME, BL_CY_CFS_ITEM," & _
       "Port_Of_Loading_Name,PLACE_OF_DESTINATION_NAME, " & _
       "Port_Of_Discharge_Name, " & _
       "Place_Of_Delivery_Name, " & _
       "PLACE_OF_DESTINATION_NAME, " & _
       "DESCRIPTIONFORSHIPPER, " & _
       "REVENUETON, ToTalContainer,PreightCharges," & _
       "EXCHANGE_RATE, " & _
      "PrepaidAt,PREPAID_OR_COLLECT, " & _
       "PAYABLE_AT, " & _
       "PLACE_OF_BL_ISSUE_NAME, " & _
     "DATE_OF_ISSUE,Load_Date, Note," & _
       "TOTALPREPAID_IN, " & _
       "NO_OF_ORIGINAL_BL, NO_OF_COPY_BL, notShowDes,BL_ClauseText ,SCAC_CODE, Payable_at_text,AGENCYNAME "

    Public Function tim(ByVal l As Integer, ByVal r As Integer, ByVal dt As DataTable, ByVal FielID As String, ByVal key As String) As Integer

        If Math.Abs(l - r) = 1 Or (l + r \ 2) = l Or (l + r) \ 2 = r Then
            If key Like "*" & dt.Rows(l).Item(FielID) & "*" Then
                Return l

            ElseIf key Like "*" & dt.Rows(r).Item(FielID) & "*" Then
                Return r
            Else : Return -1

            End If
        End If
        Dim t As String
        t = UCase(dt.Rows((l + r) \ 2).Item(FielID).ToString)

        If t Like "*" & key & "*" Then
            Return (l + r) \ 2 'dt.Rows((l + r) \ 2).Item(FielID).ToString
        End If
        If Strings.StrComp(key, UCase(dt.Rows((l + r) \ 2).Item(FielID).ToString)) = 1 Then
            Return tim((l + r) \ 2, r, dt, FielID, key)
        End If
        Return tim(l, (l + r) \ 2, dt, FielID, key)

    End Function


    Public Sub PrintRpt(ByVal BLTYPE As String)
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
        If rptName = "Data" Then
            If BLTYPE = "BILL OF LADING" Then
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptHouseBillData"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptHouseBillData"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptHouseBillDataMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptHouseBillDataDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptHouseBillDataNotify"
                Else
                    strReportName = "rptHouseBillData"
                End If
                ' ten Report--------------

                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------
            ElseIf BLTYPE = "N.C. BILL OF LADING" Then
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillData"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillData"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillDataMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillDataDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillDataNotify"
                Else
                    strReportName = "rptNCHouseBillData"
                End If
                ' ten Report--------------

                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------

            ElseIf BLTYPE = "C.U. BILL OF LADING" Then
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillData"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillData"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillDataMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillDataDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillDataNotify"
                Else
                    strReportName = "rptCUHouseBillData"
                End If
                ' ten Report--------------

                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------

            ElseIf BLTYPE = "SEAWAY BILL" Then
                'rptDocument = New rptSeaWayBillData
                ' ten Report--------------
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptSeaWayBillData"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptSeaWayBillData"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptSeaWayBillDataMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptSeaWayBillDataDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptSeaWayBillDataNotify"
                Else
                    strReportName = "rptSeaWayBillData"
                End If


                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------
            ElseIf BLTYPE = "RICH SHIPPING" Then
                'rptDocument = New rptRichShippingData
                ' ten Report--------------
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptRichShippingData"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptRichShippingData"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptRichShippingDataMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptRichShippingDataDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptRichShippingDataNotify"
                Else
                    strReportName = "rptRichShippingData"
                End If
                'strReportName = "rptRichShippingData"
                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------


            Else
                Return
            End If
        Else
            'rptDocument = New ReportDocument
            ' ten Report--------------
            If BLTYPE = "BILL OF LADING" Or BLTYPE = "INSTRUCTION" Then
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptMasterBill"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptMasterBill"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptMasterBillMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptMasterBillDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptMasterBillNotify"
                Else
                    strReportName = "rptMasterBill"
                End If
                ' ten report
                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------
            ElseIf BLTYPE = "N.C. BILL OF LADING" Then
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBill"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBill"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptNCHouseBillNotify"
                Else
                    strReportName = "rptNCHouseBill"
                End If
                ' ten Report--------------

                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------

            ElseIf BLTYPE = "C.U. BILL OF LADING" Then
                If Me.cboAttach.Text = "" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBill"
                ElseIf Me.cboAttach.Text = "ALL" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBill"
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillMarks"
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillDescription"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    strReportName = "rptCUHouseBillNotify"
                Else
                    strReportName = "rptCUHouseBill"
                End If
                ' ten Report--------------

                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDocument.Load(strReportPath)
                '----------------------------
                '

            End If
        End If
        Dim CountText() As String = {"NIL", "ONE(1)", "TWO(2)", "THREE(3)", "FOUR(4)", "FIVE(5)", "SIX(6)", "SEVEN(7)", "EIGHT(8)", "NINE(9)", "TEN(10)"}
        ' ten Report
        'strReportName = "RptMasterBill"

        QueryCustomerInfo()
        QueryBillOfLading()
        QueryDetailBillOfLading()
        QueryCargoMarks()

        QueryCargoDescription()

        Dim BillNo As TextObject
        BillNo = rptDocument.ReportDefinition.ReportObjects("BillNo")
        BillNo.Text = gBillNoRpt


        If UCase(rptName) <> "DATA" Then
            If BLTYPE = "RICH SHIPPING" Then
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

        '-----Dua du lieu vao report
        If rptName <> "Data" Then

            'rptDocument.ReportDefinition.ReportObjects("TEXT26").ObjectFormat.EnableSuppress = False
            If UCase(BLTYPE) = "INSTRUCTION" Then
                'rptDocument.ReportDefinition.ReportObjects("TEXT26").ObjectFormat.EnableSuppress = True
                BillNo.Text = ""
            End If
            If UCase(BLTYPE) = "RICH SHIPPING" Then
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
            BiLLType.Text = BLTYPE
        End If





        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4

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





        If oTableCustomerInfo.Rows.Count > 0 Then

            Dim TempShipper, TempConsignee, TempNotify As String
            '-------------------------- che tam de thu tach shipper
            'TempShipper = oTableCustomerInfo.Rows(0).Item("Shipper_1").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_2").ToString & "                                                                                                                             "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_3").ToString & "                                                                                                                            "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_4").ToString & "                                                                                                                            "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("Shipper_5").ToString & "                                                                                                                            "
            'TempShipper &= oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString


            'Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            'Shipper_1.Text = Strings.Replace(TempShipper, "*", "")
            ' ------------------------het che tam

            Shipper_1 = rptDocument.ReportDefinition.ReportObjects("Shipper_1")
            Shipper_1.Text = oTableCustomerInfo.Rows(0).Item("Shipper_1").ToString
            Shipper_2 = rptDocument.ReportDefinition.ReportObjects("Shipper_2")
            Shipper_2.Text = oTableCustomerInfo.Rows(0).Item("Shipper_2").ToString
            Shipper_3 = rptDocument.ReportDefinition.ReportObjects("Shipper_3")
            Shipper_3.Text = oTableCustomerInfo.Rows(0).Item("Shipper_3").ToString
            Shipper_4 = rptDocument.ReportDefinition.ReportObjects("Shipper_4")
            Shipper_4.Text = oTableCustomerInfo.Rows(0).Item("Shipper_4").ToString
            Shipper_5 = rptDocument.ReportDefinition.ReportObjects("Shipper_5")
            Shipper_5.Text = Strings.Replace(oTableCustomerInfo.Rows(0).Item("Shipper_5").ToString, "*", "")
            Shipper_6 = rptDocument.ReportDefinition.ReportObjects("Shipper_6")
            Shipper_6.Text = Strings.Replace(oTableCustomerInfo.Rows(0).Item("ShipperRemarks").ToString, "*", "")

            'TempConsignee = oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString & "                                                                                                                         "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_2").ToString & "                                                                                                                         "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_3").ToString & "                                                                                                                        "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_4").ToString & "                                                                                                                         "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("Consignee_5").ToString & "                                                                                                                        "
            'TempConsignee &= oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString

            'Consignee_1 = rptDocument.ReportDefinition.ReportObjects("Consignee_1")
            'Consignee_1.Text = Strings.Replace(TempConsignee, "*", "") 'oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString

            Consignee_1 = rptDocument.ReportDefinition.ReportObjects("Consignee_1")
            Consignee_1.Text = oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString
            Consignee_2 = rptDocument.ReportDefinition.ReportObjects("Consignee_2")
            Consignee_2.Text = oTableCustomerInfo.Rows(0).Item("Consignee_2").ToString
            Consignee_3 = rptDocument.ReportDefinition.ReportObjects("Consignee_3")
            Consignee_3.Text = oTableCustomerInfo.Rows(0).Item("Consignee_3").ToString
            Consignee_4 = rptDocument.ReportDefinition.ReportObjects("Consignee_4")
            Consignee_4.Text = oTableCustomerInfo.Rows(0).Item("Consignee_4").ToString
            Consignee_5 = rptDocument.ReportDefinition.ReportObjects("Consignee_5")
            Consignee_5.Text = Strings.Replace(oTableCustomerInfo.Rows(0).Item("Consignee_5").ToString, "*", "")
            Consignee_6 = rptDocument.ReportDefinition.ReportObjects("Consignee_6")
            Consignee_6.Text = Strings.Replace(oTableCustomerInfo.Rows(0).Item("ConsigneeRemarks").ToString, "*", "")

            'TempNotify = oTableCustomerInfo.Rows(0).Item("Notify_1").ToString & "                                                                                                                               "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_2").ToString & "                                                                                                                              "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_3").ToString & "                                                                                                                              "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_4").ToString & "                                                                                                                              "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("Notify_5").ToString & "                                                                                                                              "
            'TempNotify &= oTableCustomerInfo.Rows(0).Item("NotifyRemarks").ToString

            'Notify_1 = rptDocument.ReportDefinition.ReportObjects("Notify_1")
            'Notify_1.Text = Strings.Replace(TempNotify, "*", "")

            Notify_1 = rptDocument.ReportDefinition.ReportObjects("Notify_1")
            Notify_1.Text = oTableCustomerInfo.Rows(0).Item("Notify_1").ToString
            Notify_2 = rptDocument.ReportDefinition.ReportObjects("Notify_2")
            Notify_2.Text = oTableCustomerInfo.Rows(0).Item("Notify_2").ToString
            Notify_3 = rptDocument.ReportDefinition.ReportObjects("Notify_3")
            Notify_3.Text = oTableCustomerInfo.Rows(0).Item("Notify_3").ToString
            Notify_4 = rptDocument.ReportDefinition.ReportObjects("Notify_4")
            Notify_4.Text = oTableCustomerInfo.Rows(0).Item("Notify_4").ToString
            Notify_5 = rptDocument.ReportDefinition.ReportObjects("Notify_5")
            Notify_5.Text = Strings.Replace(oTableCustomerInfo.Rows(0).Item("Notify_5").ToString, "*", "")
            Notify_6 = rptDocument.ReportDefinition.ReportObjects("Notify_6")
            Notify_6.Text = Strings.Replace(oTableCustomerInfo.Rows(0).Item("NotifyRemarks").ToString, "*", "")
        End If



        Dim ContainerNo1, BL_No1 As TextObject


        Dim Amount1, Kind1 As TextObject


        Dim Gross1, UnitGross1 As TextObject

        Dim Meas1 As TextObject

        Dim SealNo1 As TextObject

        Dim BillAttach, AmountAttach, GrossAttach, MeasAttach, TitleAmount, TitleDesc, DescAttach, TitleGross, TitleMeas, TitleContainer, TotalContainer, OtotalP, OtotalG, OtotalC As TextObject
        Dim TitleNotify2, TitleNotify3 As TextObject


        Dim AttckNotify2_, AttckNotify3_ As TextObject
        ' an shipping marks va dua vao desriotion
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
        QueryNotify(dtNotify, "Notify2_ID")
        rptDocument.ReportDefinition.ReportObjects("attachnotify").ObjectFormat.EnableSuppress = True
        If dtNotify.Rows.Count > 0 Then
            'rptDocument.ReportDefinition.ReportObjects("attachnotify").ObjectFormat.EnableSuppress = False
            'Notify_1.Text = "1/ " + Notify_1.Text
            Notify_6.Text = Notify_6.Text + " (See Attach Notify 2)"
            DisplayMessage(True, "Notice: See attach Notify ")
        End If
        QueryNotify(dtNotify3, "Notify3_ID")
        '----------------- mo ta hang hoa
        Description = rptDocument.ReportDefinition.ReportObjects("Description1")
        Dim Temp(), Result As String
        Result = ""
        If oTableCargoDesc.Rows.Count > 0 Then
            Dim tempTextObject As TextObject
            Result = oTableCargoDesc.Rows(0).Item("Description").ToString
            ' che ngay 11/10/07
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
            For K As Integer = 0 To Temp.Length - 1
                Temp(K) = Temp(K).Replace(Chr(10), "")
            Next
            Result = ""

            For j As Integer = 0 To Temp.Length - 1
                Result &= Temp(j)
                For k As Integer = Temp(j).Length To Description.Width \ 10
                    Result &= " "
                Next
            Next
            'Description.Text = Result
        End If
        '-- nkiem tra descriptionco in hay ko notsHOWDes.
        If oTableBillOfLading.Rows(0).Item("notShowDes").ToString = "True" Then
            Result = ""
        End If
        If oTableBillOfLading.Rows.Count > 0 Then
            Temp = Strings.Split(oTableBillOfLading.Rows(0).Item("Note").ToString, Chr(13))
            For j As Integer = 0 To Temp.Length - 1
                notetemp &= Temp(j)
                For k As Integer = Temp(j).Length To Description.Width \ 10
                    notetemp &= " "
                Next
            Next
            ' THEM NGAY ONBOARD
            notetemp &= "                                          "



            'Result &= "CLEAN ON BOARD                                                "
            NoteStr = notetemp
            NoteStr &= UCase(VB6.Format(oTableBillOfLading.Rows(0).Item("Load_Date").ToString, "MMMM dd,yyyy")) + "                                                  "
            NoteStr &= "FREIGHT " + oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString + "                                                "
            '  hs code

            If Me.chkHSCode.Checked = True Then
                If oTableDetailBillOfLading.Rows(0).Item("HS_CODE").ToString <> "" Then
                    NoteStr &= "                                                                   "
                    NoteStr &= " - HS CODE : " & oTableDetailBillOfLading.Rows(0).Item("HS_CODE").ToString
                End If
            End If

            If Me.chkSCACCode.Checked = True Then
                If oTableBillOfLading.Rows(0).Item("SCAC_Code").ToString <> "" Then
                    NoteStr &= "                                                                   "
                    NoteStr &= " - SCAC : " & oTableBillOfLading.Rows(0).Item("SCAC_Code").ToString
                End If
            End If
            If Me.chkHBL.Checked = True Then
                If GetHouseBillNo(gBillOfLadingRpt) <> "" Then
                    NoteStr &= "                                                                   "
                    NoteStr &= " - H B/L : " & GetHouseBillNo(gBillOfLadingRpt)
                End If
            End If

            rptDocument.ReportDefinition.ReportObjects("PreightCharges1").ObjectFormat.EnableSuppress = True
            If Me.chkViewFreight.Checked = True Then
                rptDocument.ReportDefinition.ReportObjects("PreightCharges1").ObjectFormat.EnableSuppress = False
            End If
            '  temp
            'If oTableDetailBillOfLading.Rows(0).Item("temperature_setting").ToString <> "" Then
            '    Result &= "                                                                   "
            '    Result &= " - Temp : " & oTableDetailBillOfLading.Rows(0).Item("temperature_setting").ToString
            'End If
            ''  vent
            'If oTableDetailBillOfLading.Rows(0).Item("vent").ToString <> "" Then
            '    Result &= "                                                                   "
            '    Result &= " - Vent : " & oTableDetailBillOfLading.Rows(0).Item("vent").ToString
            'End If

            NoteStr &= "                                                                                        "
            NoteStr &= oTableBillOfLading.Rows(0).Item("BL_Clausetext").ToString

        End If
        'thêm ngày 05-11-2007 cho Shippingmarks lên ngay sau Container cuối cùng
        Dim TempTextObj As TextObject
        '------------------------

        If oTableDetailBillOfLading.Rows.Count > 0 Then

            Dim i As Integer
            Dim SoContainer As Integer = 14
            Dim CountContainer As Integer = IIf(oTableDetailBillOfLading.Rows.Count > SoContainer, SoContainer, oTableDetailBillOfLading.Rows.Count)
            Dim ContainerAttach As Integer = oTableDetailBillOfLading.Rows.Count - SoContainer
            Dim Attach As Boolean = False

            '----------
            For Count As Integer = 0 To CountContainer - 1
                ContainerNo1 = rptDocument.ReportDefinition.ReportObjects("ContainerNo" & Count + 1)
                ContainerNo1.Text = IIf(oTableDetailBillOfLading.Rows(Count).Item("Container_No").ToString.Trim <> "", oTableDetailBillOfLading.Rows(Count).Item("Container_No").ToString.Trim & " / ", "")
                SealNo1 = rptDocument.ReportDefinition.ReportObjects("SealNo" & Count + 1)
                SealNo1.Text = oTableDetailBillOfLading.Rows(Count).Item("SealNo").ToString.Trim
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
                Amount1.Text = oTableDetailBillOfLading.Rows(i).Item("Amount").ToString 'Amount(0)
                'totalP += CInt(Amount1.Text)

                Kind1 = rptDocument.ReportDefinition.ReportObjects("Kind" & i + 1)
                Kind1.Text = oTableDetailBillOfLading.Rows(i).Item("Kind").ToString 'Kind(0)


                If oTableDetailBillOfLading.Rows(i).Item("Gross").ToString.Trim <> "" Then
                    Gross1 = rptDocument.ReportDefinition.ReportObjects("Gross" & i + 1)
                    Gross1.Text = FormatString(CDbl(oTableDetailBillOfLading.Rows(i).Item("Gross").ToString))
                    'TotalG += CDbl(Gross1.Text)
                End If


                UnitGross1 = rptDocument.ReportDefinition.ReportObjects("UnitGross" & i + 1)
                UnitGross1.Text = oTableDetailBillOfLading.Rows(i).Item("Unit_Gross").ToString 'UnitGross(0))

                Meas1 = rptDocument.ReportDefinition.ReportObjects("Meas" & i + 1)
                Meas1.Text = FormatString(CDbl(oTableDetailBillOfLading.Rows(i).Item("CTN_CARGO_MEASUREMENT").ToString)) & " CBM" 'Meas(0))
                'totalC += CDbl(oTableDetailBillOfLading.Rows(i).Item("CTN_CARGO_MEASUREMENT").ToString)
            Next
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                totalP += CInt(oTableDetailBillOfLading.Rows(i).Item("Amount").ToString)
                TotalG += FormatString(CDbl(CDbl(oTableDetailBillOfLading.Rows(i).Item("Gross").ToString)))
                totalC += FormatString(CDbl(oTableDetailBillOfLading.Rows(i).Item("CTN_CARGO_MEASUREMENT").ToString))
            Next
            ' hien thi total
            If Me.chkViewTotal.Checked = True Then
                rptDocument.ReportDefinition.ReportObjects("totalP").ObjectFormat.EnableSuppress = False
                rptDocument.ReportDefinition.ReportObjects("totalG").ObjectFormat.EnableSuppress = False
                rptDocument.ReportDefinition.ReportObjects("totalC").ObjectFormat.EnableSuppress = False
                OtotalP = rptDocument.ReportDefinition.ReportObjects("totalP")
                OtotalP.Text = CStr(totalP) + " " + Kind1.Text
                OtotalG = rptDocument.ReportDefinition.ReportObjects("totalG")
                OtotalG.Text = CStr(FormatString(TotalG)) + " " + UnitGross1.Text
                OtotalC = rptDocument.ReportDefinition.ReportObjects("totalC")
                OtotalC.Text = CStr(FormatString(totalC)) + " CBM"
            Else
                rptDocument.ReportDefinition.ReportObjects("totalP").ObjectFormat.EnableSuppress = True
                rptDocument.ReportDefinition.ReportObjects("totalG").ObjectFormat.EnableSuppress = True
                rptDocument.ReportDefinition.ReportObjects("totalC").ObjectFormat.EnableSuppress = True
            End If
            If UCase(rptName) <> "DATA" Then
                If Me.chkViewNote.Checked = True Then
                    'rptDocument.ReportDefinition.ReportObjects("text17").ObjectFormat.EnableSuppress = False
                    'rptDocument.ReportDefinition.ReportObjects("text18").ObjectFormat.EnableSuppress = False
                    'rptDocument.ReportDefinition.ReportObjects("text23").ObjectFormat.EnableSuppress = False
                Else
                    'rptDocument.ReportDefinition.ReportObjects("text17").ObjectFormat.EnableSuppress = True
                    'rptDocument.ReportDefinition.ReportObjects("text18").ObjectFormat.EnableSuppress = True
                    'rptDocument.ReportDefinition.ReportObjects("text23").ObjectFormat.EnableSuppress = True
                End If
            End If

            'shipping marks
            'If oTableCargoMarks.Rows.Count > 0 Then
            '    Dim CargoMarks As TextObject
            '    CargoMarks = rptDocument.ReportDefinition.ReportObjects("ShippingMarks")
            '    CargoMarks.Text = oTableCargoMarks.Rows(0).Item("Marks").ToString

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
                If ResultMarks.Trim <> "" Then
                    CargoMarks.Text = "SHIPPING MARKS: " & ResultMarks & "    "
                Else
                    CargoMarks.Text = ""
                End If

                ' dua vao phia sau cua Desription

                Result = Result + "                                        " + CargoMarks.Text
                Result &= NoteStr
                Description.Text = Result 'CargoMarks.Text &= GetHouseBillNo(gBillOfLadingRpt)
            End If
            Dim CY_CFS, AGENCYNAME As TextObject
            CY_CFS = rptDocument.ReportDefinition.ReportObjects("CY_CFS")
            CY_CFS.Text = oTableBillOfLading.Rows(0).Item("BL_CY_CFS_ITEM").ToString
            '---------------------------------------------------------------------------------------------
            AGENCYNAME = rptDocument.ReportDefinition.ReportObjects("agencyname")
            'AGENCYNAME.Text = oTableBillOfLading.Rows(0).Item("agencyname").ToString
            Dim agencyt As String = ""
            Dim agencyt1() As String = Strings.Split(oTableBillOfLading.Rows(0).Item("agencyname").ToString, Chr(13))

            For CountA As Integer = 0 To agencyt1.Length - 1
                agencyt &= agencyt1(CountA).Replace(Chr(10), "")
                For CountSpacea As Integer = agencyt1(CountA).Length To AGENCYNAME.Width \ 10
                    agencyt &= " "
                Next
            Next
            AGENCYNAME.Text = agencyt
            'For j As Integer = 0 To Temp.Length - 1
            '    Result &= Temp(j)
            '    For k As Integer = Temp(j).Length To Description.Width \ 10
            '        Result &= " "
            '    Next
            'Next
            '''''''''''''''''''--
            ' Attach container
            Dim AttachContainer As TextObject
            AttachContainer = rptDocument.ReportDefinition.ReportObjects("AttachContainer")
            If ContainerAttach > 0 Then
                DisplayMessage(True, "See attach Container!")
            End If
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
                    BL_No1.Text = gBillNoRpt


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

                    TotalContainer.Text = "ToTal : " & oTableDetailBillOfLading.Rows.Count & " Containers"

                    Dim kind, gross, meas As String
                    For j As Integer = 0 To oTableDetailBillOfLading.Rows.Count - 1
                        TempContainer &= j + 1 & ")" & oTableDetailBillOfLading.Rows(j).Item("Container_No").ToString.Trim() & " / " & oTableDetailBillOfLading.Rows(j).Item("CTN_SIZE_TYPE").ToString.Trim()
                        TempContainer &= " / " & oTableDetailBillOfLading.Rows(j).Item("SealNo").ToString.Trim() & "                             "
                        TempAmount &= oTableDetailBillOfLading.Rows(j).Item("Amount").ToString.Trim()
                        TempAmount &= " " & oTableDetailBillOfLading.Rows(j).Item("Kind").ToString.Trim() & "                           "
                        kind = oTableDetailBillOfLading.Rows(j).Item("Kind").ToString.Trim()
                        TempGross &= FormatString(CDbl(oTableDetailBillOfLading.Rows(j).Item("Gross").ToString))
                        TempGross &= " " & oTableDetailBillOfLading.Rows(j).Item("Unit_Gross").ToString & "                            "

                        gross = oTableDetailBillOfLading.Rows(j).Item("Unit_Gross").ToString()

                        TempMeas &= FormatString(CDbl(oTableDetailBillOfLading.Rows(j).Item("CTN_CARGO_MEASUREMENT").ToString)) & " CBM" & "                                "

                    Next

                    AttachContainer.Text = TempContainer + " Total : "
                    AmountAttach.Text = TempAmount + CStr(totalP) + " " + kind
                    GrossAttach.Text = TempGross + CStr(TotalG) + " " + gross
                    MeasAttach.Text = TempMeas + CStr(totalC) + " " + "CBM"

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

                        'AttachContainer.Text &= "   * SHIPPING MARKS: " & ResultMarks
                    End If
                    '-----cho an het
                    For i = 0 To CountContainer - 1


                        Amount1 = rptDocument.ReportDefinition.ReportObjects("Amount" & i + 1)
                        Amount1.Text = ""


                        Kind1 = rptDocument.ReportDefinition.ReportObjects("Kind" & i + 1)
                        Kind1.Text = ""


                        If oTableDetailBillOfLading.Rows(i).Item("Gross").ToString.Trim <> "" Then
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
                    CargoMarks.Text = ""
                ElseIf Me.cboAttach.Text = "SHIPPING MARKS" And Me.chkPrintAttachList.Checked = True Then
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    BL_No1.Text = gBillNoRpt
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

                        'AttachContainer.Text &= "   * SHIPPING MARKS: " & ResultMarks
                        'CargoMarks.Text = "SHIPPING MARKS: Attach list"
                        'rptDocument.ReportDefinition.ReportObjects("ShippingMarks").ObjectFormat.EnableSuppress = True
                    End If
                ElseIf Me.cboAttach.Text = "DESCRIPTION" And Me.chkPrintAttachList.Checked = True Then
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    BL_No1.Text = gBillNoRpt
                    DescAttach.Text = Result
                    Description.Text = "  Attach list"
                ElseIf Me.cboAttach.Text = "NOTIFY" And Me.chkPrintAttachList.Checked = True Then
                    BL_No1 = rptDocument.ReportDefinition.ReportObjects("BL_NO1")
                    BL_No1.Text = gBillNoRpt


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
        If CheckAttach(Result, 30, 16) = True Then
            DisplayMessage(True, "See attach Description!")
        End If
        '        '----cac chi tiet
        If oTableBillOfLading.Rows.Count > 0 Then

            TotalContainer = rptDocument.ReportDefinition.ReportObjects("TotalContainer")
            TotalContainer.Text = oTableBillOfLading.Rows(0).Item("ToTalContainer").ToString
            '---------------
            Dim PreightCharges As TextObject
            PreightCharges = rptDocument.ReportDefinition.ReportObjects("PreightCharges1")
            Dim TempPrei(), ResultPrei As String
            Dim tempTextObjectPrei As TextObject
            ResultPrei = Me.oTableBillOfLading.Rows(0).Item("PreightCharges").ToString
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
            ServiceContract = rptDocument.ReportDefinition.ReportObjects("ServiceContract")
            If oTableBillOfLading.Rows(0).Item("ServiceContract").ToString <> "" Then
                ServiceContract.Text = " S/C: " + oTableBillOfLading.Rows(0).Item("ServiceContract").ToString
            Else
                ServiceContract.Text = ""
            End If


            Dim PreCarriageVessel, OceanVesselName As TextObject
            PreCarriageVessel = rptDocument.ReportDefinition.ReportObjects("Pre_Vessel")
            PreCarriageVessel.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString


            Dim PreCarriageVoyNo, VoyNo As TextObject
            PreCarriageVoyNo = rptDocument.ReportDefinition.ReportObjects("Pre_VoyNo")
            PreCarriageVoyNo.Text = "V." + oTableBillOfLading.Rows(0).Item("Pre_VoyNo").ToString

            If Me.chkMoveVessel.Checked = True Then
                PreCarriageVessel.Text = ""
                PreCarriageVoyNo.Text = ""
                OceanVesselName = rptDocument.ReportDefinition.ReportObjects("OceanVesselName")
                OceanVesselName.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString
                VoyNo = rptDocument.ReportDefinition.ReportObjects("VoyNo")
                VoyNo.Text = "V." + oTableBillOfLading.Rows(0).Item("Pre_VoyNo").ToString
            End If


            Dim PlaceOfReceipt As TextObject
            PlaceOfReceipt = rptDocument.ReportDefinition.ReportObjects("PlaceOfReceipt")
            PlaceOfReceipt.Text = oTableBillOfLading.Rows(0).Item("Place_Of_Receipt_Name").ToString



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

            Dim RevenueTons As TextObject
            RevenueTons = rptDocument.ReportDefinition.ReportObjects("RevenueTons")
            Dim ResultRen As String
            Dim tempren() As String
            tempren = Split(oTableBillOfLading.Rows(0).Item("REVENUETON").ToString, Chr(13))
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
            Rate.Text = oTableBillOfLading.Rows(0).Item("EXCHANGE_RATE").ToString
            If UCase(oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString) = "COLLECT" Then
                Dim Collect As TextObject
                Collect = rptDocument.ReportDefinition.ReportObjects("Collect")
                Collect.Text = oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString
            Else

                Dim Prepaid As TextObject
                Prepaid = rptDocument.ReportDefinition.ReportObjects("Prepaid")
                Prepaid.Text = oTableBillOfLading.Rows(0).Item("PREPAID_OR_COLLECT").ToString
            End If



            Dim PrepaidAt As TextObject
            PrepaidAt = rptDocument.ReportDefinition.ReportObjects("PrepaidAt")
            PrepaidAt.Text = TSName(oTableBillOfLading.Rows(0).Item("PREPAIDAT").ToString)

            Dim PayableAt As TextObject
            PayableAt = rptDocument.ReportDefinition.ReportObjects("PayableAt")
            PayableAt.Text = TSName(oTableBillOfLading.Rows(0).Item("Payable_At").ToString)

            ' hien thi destination
            If oTableBillOfLading.Rows(0).Item("Payable_At_text").ToString.Trim <> "" Then
                PayableAt.Text = oTableBillOfLading.Rows(0).Item("Payable_At_text").ToString
            End If
            Dim PlaceOfIssue As TextObject
            PlaceOfIssue = rptDocument.ReportDefinition.ReportObjects("PlaceOfIssue")
            PlaceOfIssue.Text = oTableBillOfLading.Rows(0).Item("PLACE_OF_BL_ISSUE_NAME").ToString

            Dim DateOfIssue As TextObject
            DateOfIssue = rptDocument.ReportDefinition.ReportObjects("DateOfIssue")
            DateOfIssue.Text = VB6.Format(oTableBillOfLading.Rows(0).Item("Date_Of_Issue").ToString, "MMMM dd,yyyy")

            Dim LoadDate As TextObject
            LoadDate = rptDocument.ReportDefinition.ReportObjects("LoadDate")
            LoadDate.Text = VB6.Format(oTableBillOfLading.Rows(0).Item("Load_Date").ToString, "MMMM dd,yyyy")

            Dim TotalPrepaidIn As TextObject
            TotalPrepaidIn = rptDocument.ReportDefinition.ReportObjects("TotalPrepaidIn")
            TotalPrepaidIn.Text = TSName(oTableBillOfLading.Rows(0).Item("TOTALPREPAID_IN").ToString)

            Dim NoOfOrigineBL As TextObject
            Dim Num As Integer
            Num = CInt(IIf(oTableBillOfLading.Rows(0).Item("NO_OF_ORIGINAL_BL").ToString <> "", oTableBillOfLading.Rows(0).Item("NO_OF_ORIGINAL_BL").ToString, -1))
            NoOfOrigineBL = rptDocument.ReportDefinition.ReportObjects("NoOfOrigineBL")
            If Num <> -1 Then
                NoOfOrigineBL.Text = CountText(Num)
            Else
                NoOfOrigineBL.Text = ""
            End If
            If UCase(oTableBillOfLading.Rows(0).Item("telex").ToString) = "T" Or UCase(oTableBillOfLading.Rows(0).Item("telex").ToString) = "W" Then
                NoOfOrigineBL.Text = "NIL"

            End If
        End If
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
        'Formatting paper
        rptDocument.ReportDefinition.ReportObjects("ShippingMarks").ObjectFormat.EnableSuppress = True
        rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4
        If Me.chkDefaultMargin.Checked = False Then


            Dim mymargins = rptDocument.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM

            rptDocument.PrintOptions.ApplyPageMargins(mymargins)
        Else
            Dim mymargins = rptDocument.PrintOptions.PageMargins
            mymargins.topMargin = 400
            mymargins.bottomMargin = 400
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM

            rptDocument.PrintOptions.ApplyPageMargins(mymargins)
        End If

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


    Private Sub frmRptMasterBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.cboBillType.Left = Me.Width - 50 - Me.cboBillType.Width
        Me.chkViewNote.Checked = True
        PrintRpt("BILL OF LADING")
    End Sub

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM (((BillOfLading LEFT JOIN Shipper On BillOfLading.Shipper_ID=Shipper.Shipper_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Consignee On Consignee.Consignee_ID=BillOfLading.Consignee_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Notify On Notify.Notify_ID=BillOfLading.Notify_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLading.BL_ID= '" & gBillOfLadingRpt & "' And BillOfLading.Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function


    Private Function MakeQueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryDetailBillOfLading = strDetailBillOfLadingSelect
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " FROM ((Cargo LEFT JOIN Container On Cargo.CTN_ID=Container.CTN_ID) "

        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN SEAL On Cargo.SEAL_ID=SEAL.SEAL_ID) "

        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "WHERE "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "Cargo.BL_Id = '" & gBillOfLadingRpt & "' And Cargo.Continued=1 "
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = strBillOfLadingSelect
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM ((((BillOfLading left join ContainerOutboundNotify on BillOfLading.ContainerOutboundNotifyid=ContainerOutboundNotify.ContainerOutboundNotifyid )"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " Left join SailingSchedule on ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID ) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " left join Vessel on Vessel.Vessel_ID=SailingSchedule.Vessel_Id) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN BL_Clause On BL_Clause.BL_ClauseID=BillOfLading.BL_ClauseID)"
        MakeQueryBillOfLading = MakeQueryBillOfLading & "WHERE (BillOfLading.BL_ID = '" & gBillOfLadingRpt & "') "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "And ("
        MakeQueryBillOfLading = MakeQueryBillOfLading & "BillOfLading.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Function GetHouseBillNo(ByVal ID As String) As String
        Try
            Dim SQL As String
            SQL = "select Upper(BLH_NO)as BLH_No From HouseColoBillInfo Where BL_ID='" & ID & "' And Continued=1 And BLH_NO <>''"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Dim Temp As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                Temp &= dt.Rows(i).Item("BLH_NO").ToString & " , "
            Next
            If Temp.Length > 0 Then
                Temp = Temp.Remove(Temp.Length - 2, 1)
            End If
            Return Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
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

    Sub QueryNotify(ByRef dt As DataTable, ByVal NotifyID As String)
        Dim strQuery As String
        strQuery = " Select top 1 Notify.Notify_1 ,Notify.Notify_2, Notify.Notify_3,Notify.Notify_4,Notify.Notify_5,Notify.Notify_6, Notify.Remarks as NotifyRemarks "
        strQuery &= " From (BillOfLading LEFT JOIN Notify On BillOfLading." & NotifyID & "=Notify.Notify_ID) "
        strQuery &= " Where BillofLading.Continued=1 And BL_ID='" & gBillOfLadingRpt & "' And  Notify.Notify_ID <>'" & DefaultValue & "'"

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
        strQuery = "Select Description from CARGO_DESCRIPTION Where BL_ID='" & gBillOfLadingRpt & "' "
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
        strQuery = "Select MARKS from CARGO_MARKS Where BL_ID='" & gBillOfLadingRpt & "'"
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
        strQuery = "Select CARGO_REMARKS from CARGO_Remarks Where BL_ID='" & gBillOfLadingRpt & "' "
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

    Private Sub cboBillType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillType.SelectedIndexChanged
        'If rptName = "Data" Then
        '    Return
        'End If
        'Me.Close()
        'frmListBaseMaster.mnuBillOfLadingdata_Click(sender, e)
        'PrintRpt(Me.cboBillType.Text.Trim)
    End Sub

    
    Private Sub chkPrintAttachList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintAttachList.CheckedChanged
        'Me.Close()
        'frmListBaseMaster.mnuBillOfLadingdata_Click(sender, e)
        'PrintRpt(Me.cboBillType.Text.Trim)
    End Sub

    Private Sub cboAttach_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAttach.SelectedIndexChanged
        'PrintRpt(Me.cboBillType.Text.Trim)
    End Sub

    Private Sub cmdrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefresh.Click
        PrintRpt(Me.cboBillType.Text.Trim)
    End Sub
End Class