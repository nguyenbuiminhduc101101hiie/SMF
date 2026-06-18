Imports System.IO
Imports System.Globalization


Public Class frmImportInboundEDI

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtFileName.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Function GetContainerID(ByVal Containerno As String) As String
        Try
            Containerno = Containerno.Trim
            Dim SQL As String
            SQL = "select Top 1 CTN_ID From Container Where Container_No='" & Containerno & "' And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return dt.Rows(0).Item("CTN_ID").ToString()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function GetBLID(ByVal BLNO As String) As String
        Try
            Dim SQL As String
            SQL = "select Top 1 BLIB_ID From BillOfLadingIBEDI Where BLIB_NO='" & BLNO & "' And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return dt.Rows(0).Item("BLIB_ID").ToString()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Vessel_Code"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Vessel_Code,Vessel as value "
        strSQL = strSQL & " From vessel where Continued=1 Order By Vessel "
        'loadDataToObject(Me.cboVessel, strSQL, id, value)
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboVessel.DisplayMember = value
        Me.cboVessel.ValueMember = id
        Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtFileName.Text = "" Then
            Return
        End If
        If File.Exists(Me.txtFileName.Text) = False Then
            MsgBox("The file dose not exists, check again")
            Return
        End If
        '-------------------record 10--------------------
        Dim VesselCode, Vessel, VoyNo As String

        'record 12----------------------------------------
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim fr As StreamReader
        Try
            fr = New StreamReader(Me.txtFileName.Text)
            Dim temp As String = fr.ReadLine()

            If Not (UCase(temp) Like "*00:IFCSUM:MANIFEST*") Then
                MsgBox("File format is invalid,choose another file")

                Return
            End If
            temp = fr.ReadLine()
            'Dim TempVessel() As String
            'temp = temp.Replace("'", "")
            'TempVessel = Strings.Split(temp, ":")
            'record 10
            VesselCode = Me.cboVessel.SelectedValue.ToString
            Vessel = Me.cboVessel.Text
            VoyNo = Me.txtVoyNo.Text.Replace(" ", "")

            temp = fr.ReadLine()
            temp = temp.Replace("'", "")
            temp = temp.Replace("?", "")
            Dim InsertAllContainer As Boolean = False
            Dim CountBill As Integer = 0
            While Not temp Like "99:*" 'trong khi chưa kết thúc Manifest


                'record 12-----------------------------------------------------------------------
                Dim BLNO, BLID, PORCode, POR, POLCode, POL, CY, PrepaidCollect, LoadDate, QuanCode, DateIssue, Currency, ExChangeRate As String
                Dim MFiling, NofVCC, ScacCode, TradeCode, BLOtherREF, BLType, PayableAt, NumOfCopy, NoOfOriginal, CustomerCLean, SlotShare, UsMode As String



                Dim Record12() As String

                Record12 = temp.Split(":")
                BLNO = Record12(1)
                PORCode = Record12(5) ' ts code
                POR = Record12(6) ' ten 
                POLCode = Record12(7)
                POL = Record12(8)
                If Record12(9) = "11" Then
                    CY = "CY - CY"
                ElseIf Record12(9) = "12" Then
                    CY = "CY - CFS"
                ElseIf Record12(9) = "13" Then
                    CY = "CY - DOOR"
                ElseIf Record12(9) = "14" Then
                    CY = "CY-TACKLE"
                ElseIf Record12(9) = "15" Then
                    CY = "CY-FIO"
                ElseIf Record12(9) = "16" Then
                    CY = "CY-LIO"
                ElseIf Record12(9) = "17" Then
                    CY = "CY-LO"
                ElseIf Record12(9) = "18" Then
                    CY = "CY-FI"
                ElseIf Record12(9) = "19" Then
                    CY = "CY-FO"
                ElseIf Record12(9) = "1R" Then
                    CY = "CY-RAMP"
                Else
                    MsgBox("CY: record 12  Value Invalid in b/L No." & BLNO & vbCrLf & "Write Down B/L No. And Edit again")
                End If
                PrepaidCollect = IIf(Record12(10) = "P", "PREPAID", "COLLECT")
                LoadDate = Record12(11)
                QuanCode = Record12(12)
                DateIssue = Record12(13)
                Currency = Record12(14)
                ExChangeRate = Record12(15)
                MFiling = Record12(16)
                NofVCC = Record12(17)
                ScacCode = Record12(18)
                TradeCode = Record12(19)
                BLOtherREF = Record12(20)
                BLType = Record12(21)
                PayableAt = Record12(22)
                'bộ file 23 PrepaidCollect
                NumOfCopy = Record12(24)

                NoOfOriginal = Record12(25)
                CustomerCLean = Record12(26)
                SlotShare = Record12(27)
                UsMode = Record12(28) ' luu y 1 so manifest cu ko cp filed USMode

                'record 13 
                temp = fr.ReadLine()
                Dim Record13() As String
                temp = temp.Replace("'", "")
                Record13 = temp.Split(":")
                Dim PODCode, POD, DELCode, DEL, DESTCode, DEST, POICode, POI, VIA1, VIA2, VIA3, VIA4 As String
                PODCode = Record13(1)
                POD = Record13(2)
                DELCode = Record13(3)
                DEL = Record13(1)
                DESTCode = Record13(4)
                DEST = Record13(5)
                POICode = Record13(6)
                POI = Record13(7)
                VIA1 = Record13(8)
                VIA2 = Record13(9)
                VIA3 = Record13(10)
                VIA4 = Record13(11)
                temp = fr.ReadLine().Replace("'", "")
                While temp Like "14:*" 'bỏ record 14 routing
                    temp = fr.ReadLine().Replace("'", "")
                End While

                'record 15 Phí Container Và Bill
                Dim Record15() As String
                If GetBLID(BLNO) <> "" Then
                    DisplayMessage(True, "Please check B/L : " + BLNO)
                    While Not temp Like "12:*"
                        temp = fr.ReadLine().Replace("'", "")
                    End While
                    If temp = "12:*" Then
                        BLID = NewId()
                    Else
                        DisplayMessage(True, "The System is stop, please check your EDI Manifest!")
                        Return
                    End If
                    'Return
                Else
                    BLID = NewId()
                End If

                While temp Like "15:*"
                    Record15 = temp.Split(":")
                    Dim ChargeCode, charge, PayableAtCode, PayableAt15, ContainerQuantity, Currency15, UnitPrice, UnitOfQuantity, SumUnitPriceQuantity, Prepadicollect As String
                    Dim ContainerType, PayerCode, IGCode As String
                    ChargeCode = Record15(1)
                    charge = Record15(2)
                    PayableAtCode = Record15(3)
                    PayableAt15 = Record15(4)
                    ContainerQuantity = Record15(5)
                    Currency15 = Record15(6)
                    UnitPrice = Record15(7)
                    UnitOfQuantity = Record15(8)
                    SumUnitPriceQuantity = Record15(9)
                    Record15(10) = UCase(Record15(10))
                    If Record15(10) = "O" Then
                        Prepadicollect = "POP.O"
                    ElseIf Record15(10) = "P" Then
                        Prepadicollect = "PREPAID"
                    ElseIf Record15(10) = "C" Then
                        Prepadicollect = "COLLECT"
                    Else
                        MsgBox(" Prepaid - Collect, Invalid Field 11 of Record 15  ,B/L No.:" & BLNO)
                    End If
                    ContainerType = Record15(11)
                    PayerCode = Record15(12)
                    IGCode = Record15(13)
                    'insert databse here
                    'BLID = "{" & GetBLID(BLNO) & "}"
                    'If BLID = "{}" Then
                    '---them blib_id

                    'End If
                    If temp Like "*99BL:*" Then 'phí Bill
                        strQuery = "Select * from PriceBillIB Where BLIB_NO='" & BLNO & "' And Continued=1 and Items='" & ChargeCode & "'"
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If rs.EOF Then
                            With rs
                                .Fields("PriceBillIB_ID").Value = NewId()
                                .Fields("BLIB_NO").Value = BLNO
                                .Fields("Items").Value = ChargeCode
                                .Fields("Currency").Value = Currency15
                                .Fields("UnitPrice").Value = UnitPrice
                                .Fields("Quantity").Value = ContainerQuantity
                                .Fields("PREPAID_COLLECT").Value = PrepaidCollect
                                .Fields("POP_Code").Value = PayableAtCode
                                '.Fields("BillType").Value= 'không có dữ liệu
                                .Update()
                            End With
                        End If
                        rs.Close()
                    Else 'Phí Container
                        strQuery = "Select * from FREIGHT_CHARGE_IB Where BLIB_ID='" & BLID & "' And Continued=1 and Items='" & ChargeCode & "'"
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If rs.EOF Then
                            With rs
                                .AddNew()
                                .Fields("FREIGHT_CHARGE_IB").Value = NewId()
                                .Fields("BLIB_ID").Value = BLID
                                .Fields("Items").Value = ChargeCode
                                .Fields("CURRENCY").Value = Currency15
                                .Fields("CONTAINER_TYPE").Value = ContainerType
                                .Fields("UNITPRICE").Value = UnitPrice
                                .Fields("PREPAID_COLLECT").Value = PrepaidCollect
                                .Fields("POP_Code").Value = PayableAtCode
                                .Fields("Quantity").Value = ContainerQuantity
                                .Update()
                            End With
                        End If
                        rs.Close()

                    End If
                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End While

                'record 16
                Dim Record16() As String
                'temp=fr.ReadLine().Replace("'","")'che vì đã đọc ở trên While
                Record16 = temp.Split(":")
                Dim Shipper_ID, ShipperCode, S1, s2, s3, s4, s5, SRemarks As String
                ShipperCode = Record16(1)
                S1 = Record16(2)
                s2 = Record16(3)
                s3 = Record16(4)
                s4 = Record16(5)
                s5 = Record16(6)
                'SRemarks = Record16(7)
                'Insert Databese Here
                'check Insert Shipper
                strQuery = "Select * from Shipper Where Shipper_Code='" & ShipperCode & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    rs.AddNew()
                    rs.Fields("Shipper_ID").Value = NewId()

                    rs.Fields("Shipper_Code").Value = ShipperCode
                    rs.Fields("Shipper_1").Value = S1
                    rs.Fields("Shipper_2").Value = s2
                    rs.Fields("Shipper_3").Value = s3
                    rs.Fields("Shipper_3").Value = s4
                    rs.Fields("Shipper_5").Value = s5
                    rs.Update()
                End If
                Shipper_ID = rs.Fields("Shipper_ID").Value.ToString
                rs.Close()

                'record 17
                Dim Record17() As String
                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                Record17 = temp.Split(":")
                Dim Consignee_ID, ConsigneeCode, c1, c2, c3, c4, c5, CRemarks As String
                ConsigneeCode = Record17(1)
                c1 = Record17(2)
                c2 = Record17(3)
                c3 = Record17(4)
                c4 = Record17(5)
                c5 = Record17(6)
                'CRemarks = Record16(7)
                'Insert Databese Here
                'check Insert Consignee
                strQuery = "Select * from Consignee Where Consignee_Code='" & ConsigneeCode & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    rs.AddNew()
                    rs.Fields("Consignee_ID").Value = NewId()

                    rs.Fields("Consignee_Code").Value = ConsigneeCode
                    rs.Fields("Consignee_1").Value = c1
                    rs.Fields("Consignee_2").Value = c2
                    rs.Fields("Consignee_3").Value = c3
                    rs.Fields("Consignee_3").Value = c4
                    rs.Fields("Consignee_5").Value = c5
                    rs.Update()
                End If
                Consignee_ID = rs.Fields("Consignee_ID").Value.ToString
                rs.Close()

                'record 18
                Dim Record18() As String
                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                Record18 = temp.Split(":")

                Dim Notify_ID, NotifyCode, N1, n2, n3, n4, n5, NRemarks As String
                NotifyCode = Record18(1)
                N1 = Record18(2)
                n2 = Record18(3)
                n3 = Record18(4)
                n4 = Record18(5)
                n5 = Record18(6)
                'NRemarks = Record16(7)
                'Insert Databese Here
                'check Insert Notify
                strQuery = "Select * from Notify Where Notify_Code='" & NotifyCode & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If rs.EOF Then
                    rs.AddNew()
                    rs.Fields("Notify_ID").Value = NewId()

                    rs.Fields("Notify_Code").Value = NotifyCode
                    rs.Fields("Notify_1").Value = N1
                    rs.Fields("Notify_2").Value = n2
                    rs.Fields("Notify_3").Value = n3
                    rs.Fields("Notify_3").Value = n4
                    rs.Fields("Notify_5").Value = n5
                    rs.Update()
                End If
                Notify_ID = rs.Fields("Notify_ID").Value.ToString
                rs.Close()


                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                If temp Like "19:*" Then
                    'record 19
                    Dim Record19() As String 'Notify_2
                    temp = fr.ReadLine().Replace("'", "")
                    Record19 = temp.Split(":")
                    Dim Notify2_ID, Notify2Code, N21, n22, n23, n24, n25, N2Remarks As String
                    Notify2Code = Record18(1)
                    N21 = Record19(2)
                    n22 = Record19(3)
                    n23 = Record19(4)
                    n24 = Record19(5)
                    n25 = Record19(6)
                    'N2Remarks = Record16(7)
                    'Insert Databese Here
                    'check Insert Notify2
                    strQuery = "Select * from Notify Where Notify_Code='" & Notify2Code & "' And Continued=1"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If rs.EOF Then
                        rs.AddNew()
                        rs.Fields("Notify_ID").Value = NewId()

                        rs.Fields("Notify_Code").Value = Notify2Code
                        rs.Fields("Notify_1").Value = N21
                        rs.Fields("Notify_2").Value = n22
                        rs.Fields("Notify_3").Value = n23
                        rs.Fields("Notify_3").Value = n24
                        rs.Fields("Notify_5").Value = n25
                        rs.Update()
                    End If
                    Notify2_ID = rs.Fields("Notify_ID").Value.ToString
                    rs.Close()



                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End If
                If temp Like "20:*" Then
                    'record 19
                    Dim Record20() As String 'Notify_3
                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                    Record20 = temp.Split(":")
                    Dim Notify3_ID, Notify3Code, N31, n32, n33, n34, n35, N3Remarks As String
                    Notify3Code = Record18(1)
                    N31 = Record20(2)
                    n32 = Record20(3)
                    n33 = Record20(4)
                    n34 = Record20(5)
                    n35 = Record20(6)
                    'NRemarks = Record16(7)
                    'Insert Databese Here
                    'check Insert Notify3
                    strQuery = "Select * from Notify Where Notify_Code='" & Notify3Code & "' And Continued=1"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If rs.EOF Then
                        rs.AddNew()
                        rs.Fields("Notify_ID").Value = NewId()

                        rs.Fields("Notify_Code").Value = Notify3Code
                        rs.Fields("Notify_1").Value = N31
                        rs.Fields("Notify_2").Value = n32
                        rs.Fields("Notify_3").Value = n33
                        rs.Fields("Notify_3").Value = n34
                        rs.Fields("Notify_5").Value = n35
                        rs.Update()
                    End If
                    Notify3_ID = rs.Fields("Notify_ID").Value.ToString
                    rs.Close()


                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End If
                If temp Like "21:*" Then
                    'record 21
                    Dim Record21() As String
                    Record21 = temp.Split(":")
                    Dim BLClauseText, BLClauseCode As String
                    BLClauseCode = Record21(1)
                    BLClauseText = Record21(2)
                    'Insert Databese Here

                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End If
                While temp Like "23:*" 'chưa rõ cách lấy
                    'record 23

                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End While

                'record 41
                Dim CommodityGroup, Commodity, KindCode, Kind, Tariff, HS_Code As String
                Dim Record41() As String
                Record41 = temp.Split(":")
                CommodityGroup = Record41(2)
                Commodity = Record41(3)
                'field 5 Vitrí 4  bỏ tổng số Packet
                KindCode = Record41(5)
                Kind = Record41(6)
                Tariff = Record41(11)
                HS_Code = Record41(12)

                'record 44
                Dim Record44() As String
                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                Record44 = temp.Split(":")
                Dim CargoMarks As String
                CargoMarks = Record44(1)
                'insert Database here

                'record 47
                Dim Record47() As String
                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                Record47 = temp.Split(":")
                Dim Desc As String 'chưa rõ cách lấy
                Desc = Record47(1)
                'insert Database here

                'record 48
                Dim Record48() As String
                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                Record48 = temp.Split(":")
                Dim CargoRemarks As String 'chưa rõ cách lấy
                CargoRemarks = Record48(1)
                'insert Database here

                'record 51
                Dim Record51() As String
                temp = fr.ReadLine().Replace("'", "")
                temp = temp.Replace("?", "")
                Record51 = temp.Split(":")
                Dim CargoSeq, ContainerNo, SealNo, ContainerType51, CTN_status, Amount, Gross, NetWight, CBM As String
                Dim TempID, TempSetting, MinTemp, MaxTemp, Vent, ShipperOwnUnit, CargoReceiveDate, Seal1, Seal2, Seal3, Seal4, Seal5, Seal6, Seal7, Seal8, Seal9 As String
                While temp Like "51:*"
                    CargoSeq = Record51(1)
                    ContainerNo = Record51(2)
                    SealNo = Record51(3)
                    ContainerType51 = Record51(4)
                    CTN_status = Record51(5)
                    Amount = Record51(6)
                    Gross = Record51(7)
                    NetWight = Record51(8)
                    CBM = Record51(9)
                    TempID = Record51(10)
                    TempSetting = Record51(11)
                    MinTemp = Record51(12)
                    MaxTemp = Record51(13)
                    Vent = Record51(14)
                    ShipperOwnUnit = Record51(15)
                    CargoReceiveDate = Record51(16)
                    Seal1 = Record51(17)
                    Seal2 = Record51(18)
                    Seal3 = Record51(19)
                    Seal4 = Record51(20)
                    Seal5 = Record51(21)
                    Seal6 = Record51(22)
                    Seal7 = Record51(23)
                    Seal8 = Record51(24)
                    'Seal9 = Record51(25)
                    'Insert Database Here
                    Dim ContainerID As String
                    ContainerID = "{" & GetContainerID(ContainerNo) & "}"
                    Dim InsertContainer As Boolean = True
                    If ContainerID = "{}" Then 'không có container trong DB
                        'If MsgBox("Container :" & ContainerNo & "  Not in Database, Do you Want Insert It in to Container For B/L:" & BLNO, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        InsertContainer = True
                        ContainerID = DefaultValue
                        'Else : InsertContainer = False
                        'End If
                    Else
                        InsertContainer = False

                    End If
                    If InsertContainer = True Then
                        If ContainerID = DefaultValue Then
                            strQuery = "Select Top 1 * from Container Where   Continued=1 "
                            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            rs.AddNew()
                            rs.Fields("CTN_ID").Value = NewId()
                            ContainerID = rs.Fields("CTN_ID").Value.ToString
                            rs.Fields("CTN_SIZE_TYPE").Value = ContainerType51
                            rs.Fields("Container_No").Value = ContainerNo.Trim
                            If ContainerType51 = "20GP" Then
                                rs.Fields("NETWEIGHT").Value = 2250
                            ElseIf ContainerType51 = "40GP" Then
                                rs.Fields("NETWEIGHT").Value = 6650
                            ElseIf ContainerType51 = "40HC" Then
                                rs.Fields("NETWEIGHT").Value = 3890
                            ElseIf ContainerType51 = "40RH" Then
                                rs.Fields("NETWEIGHT").Value = 5100
                            ElseIf ContainerType51 = "20RF" Then
                                rs.Fields("NETWEIGHT").Value = 3030

                            Else
                                rs.Fields("NETWEIGHT").Value = 0
                            End If

                            rs.Update()
                            rs.Close()
                        End If
                    End If


                    strQuery = "Select Top 1 * from CargoIB Where BLIB_ID='" & BLID & "' And Continued=1 and CTN_ID='" & ContainerID & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    If rs.EOF Then
                        With rs
                            .AddNew()
                            .Fields("CARGOIB_ID").Value = NewId()
                            .Fields("BLIB_ID").Value = BLID
                            .Fields("CTN_ID").Value = ContainerID
                            .Fields("SEAL").Value = SealNo
                            '.Fields("CARRIERKIND").Value=
                            .Fields("AMOUNT").Value = Amount
                            .Fields("KIND").Value = Kind
                            .Fields("Container_Type").Value = ContainerType51
                            '.Fields("RECEIVEKIND").Value=
                            .Fields("GROSSWEIGHT").Value = Gross
                            .Fields("GrossUnit").Value = "KGS"
                            .Fields("MEAS").Value = CBM
                            .Fields("MEASUNIT").Value = "CBM"
                            .Fields("RECEIVEDATE").Value = Now()
                            '.Fields("WEEK").Value=
                            '.Fields("NOTE").Value=
                            '.Fields("STT").Value=
                            .Update()
                        End With
                    End If
                    rs.Close()


                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End While
                While temp Like "61:*"
                    temp = fr.ReadLine().Replace("'", "")
                    temp = temp.Replace("?", "")
                End While
                '--xac dinh ICD Port khi tau cap
                Dim ICDPort As String
                If DEST Like "*NEW PORT*" Or DEST Like "*NEWPORT*" Then ' hoi lai bao nhieu Port                            DisplayMessage(True, TempPort(4) + TempPort(5))
                    ICDPort = "NEW PORT"
                ElseIf DEST Like "*SONG THAN*" Or DEST Like "*SONGTHAN*" Then
                    ICDPort = "SONG THAN"
                ElseIf DEST Like "*PHUOC LONG*" Or DEST Like "*PHUOCLONG*" Then
                    ICDPort = "ICD PHUOC LONG"
                ElseIf DEST Like "*PHUC LONG*" Or DEST Like "*PHUCLONG*" Then
                    ICDPort = "PHUC LONG"
                ElseIf DEST Like "*KHANH HOI*" Or DEST Like "*KHANHHOI*" Then
                    ICDPort = "KHANH HOI"
                ElseIf DEST Like "*TRANSIMEX*" Or DEST Like "*TRANSIMEX*" Then
                    ICDPort = "TRANSIMEX"
                ElseIf DEST Like "*BIEN HOA*" Or DEST Like "*BIENHOA*" Then
                    ICDPort = "BIEN HOA"
                Else
                    ICDPort = "CAT LAI"
                End If

                If UCase(BLNO) Like "????NPT*" Then
                    If ICDPort = "NEW PORT" Then
                        ICDPort = "NEW PORT"
                    Else
                        ICDPort = ""
                    End If
                End If
                '---------------------------------
                'Insert Database Bill
                strQuery = "select Top 1 * from BillOfLadingIB Where Continued=1 and BLIB_NO='" & BLNO & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    rs.Close()
                    Continue While
                End If
                With rs
                    .AddNew()

                    .Fields("BLIB_ID").Value = BLID
                    .Fields("BLIB_NO").Value = BLNO
                    .Fields("SHIPPER_ID").Value = Shipper_ID
                    .Fields("CONSIGNEE_ID").Value = Consignee_ID
                    .Fields("REF").Value = "'"
                    .Fields("NOTIFY_ID").Value = Notify_ID
                    .Fields("CY_CFS_ITEM").Value = CY
                    .Fields("BL_TYPE").Value = BLType
                    .Fields("MARKS").Value = CargoMarks
                    .Fields("DESCRIPTIONOFGOODS").Value = Desc
                    .Fields("DESCRIPTIONFORSHIPPER").Value = ""
                    .Fields("LC_NO").Value = ""
                    .Fields("VESSEL").Value = Vessel
                    .Fields("VesselCode").Value = VesselCode
                    .Fields("VOYAGE").Value = VoyNo
                    .Fields("SAILINGDATE").Value = Me.dtpETA.Value
                    .Fields("ETA").Value = Me.dtpETA.Value.Date
                    .Fields("VIA").Value = VIA1
                    .Fields("POR").Value = POR
                    .Fields("POL").Value = POL
                    .Fields("POD").Value = POD
                    .Fields("DEL").Value = DEL
                    .Fields("DEST").Value = DEST
                    .Fields("DisChargeDate").Value = Me.dtpETA.Value
                    .Fields("ICDPort").Value = ICDPort
                    .Fields("ImportCY").Value = ICDPort
                    .Fields("WEEKOFYEAR").Value = WeekOfYear()
                    .Fields("TranSit").Value = 0
                    .Fields("STT").Value = 1

                    .Update()
                End With
                rs.Close()
                CountBill += 1
            End While
            If CountBill > 0 Then
                MsgBox(CountBill & " Bills Imported")

            Else
                MsgBox("This file was Imported Or Empty, Check To Correct It")

            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            fr.Close()
        End Try
    End Sub
    Public Function WeekOfYear() As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        If Me.dtpETA.Text <> "" Then
            WeekOfYear = myCal.GetWeekOfYear(CDate(Me.dtpETA.Text), myCWR, myFirstDOW)
        Else
            WeekOfYear = 0
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub frmImportInboundEDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryICD(Me.cboICDPort)
        QueryVessel()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileName.TextChanged

    End Sub
End Class