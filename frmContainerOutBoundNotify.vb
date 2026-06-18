Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Globalization
'Imports Excel
Imports System.Data.OleDb
Imports System.Windows.Forms

Imports System.Net.Mail
Imports System.Net
Imports System.Drawing
Imports System.IO
'Imports System.Web.Mail
Imports System.Net.Mail.Attachment
'----------------
''Imports Excel
''Imports system.Data.OleDb
'Imports System
'Imports System.Data
'Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared



Public Class frmContainerOutBoundNotify


    'Inherits System.Windows.Forms.Form
    Dim fraSplitMDown As Boolean = False
    Dim x, y As Integer 'vị trí fraSplit
    Dim ContainerLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsContainerOutboundNotifyList As New ADODB.Recordset
    Public mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mIDOLD As String = DefaultValue
    Public mIDNEW As String = DefaultValue
    Public mContainerOutboundNotifyId As String = DefaultValue
    Public BookingId As String = DefaultValue
    Dim CustomerID, Vessel_id As String
    Dim RowCopy As DataRow
    Dim Wait As Integer
    Dim dtp As Boolean
    Dim glockorder As Integer = 0
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet



    Public Shared HiddenTabs As New List(Of TabPage)()
    Public Shared Visibletabs As New List(Of TabPage)()
    Public Shared Function ShowTab(tab_ As TabPage, show_tab As Boolean)
        Dim r, a As Object
        Select Case show_tab
            Case True
                If Visibletabs.Contains(tab_) = False Then Visibletabs.Add(tab_)
                If HiddenTabs.Contains(tab_) = True Then HiddenTabs.Remove(tab_)
            Case False
                If HiddenTabs.Contains(tab_) = False Then HiddenTabs.Add(tab_)
                If Visibletabs.Contains(tab_) = True Then Visibletabs.Remove(tab_)
        End Select
        For Each r In HiddenTabs
            Try
                Dim TC As TabControl = r.Parent
                If TC.Contains(r) = True Then TC.TabPages.Remove(r)
            Catch ex As Exception

            End Try
        Next
        For Each a In Visibletabs
            Try
                Dim TC As TabControl = a.Parent
                If TC.Contains(a) = False Then TC.TabPages.Add(a)
            Catch ex As Exception

            End Try
        Next
    End Function

    Private Function CheckEdit() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckEdit = True
        strMsg = ""
        Dim strContainerOutboundNotifyId As String
        Dim rs As New ADODB.Recordset
        strQuery = "SELECT * "
        strQuery = strQuery & "from ContainerOutboundNotify_sale "
        strQuery = strQuery & "WHERE BookingNo = '" & Me.txtBookingNo.Text & "' And Continued=1  And Editable=0 and ContainerOutboundnotifyid='" & mContainerOutboundNotifyId & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            CheckEdit = False
            rs.Close()
            DisplayMessage(True, "This Booking is not editing!.")
            Return False
        End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        rs.Close()
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg, BookingNumber As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strContainerOutboundNotifyId As String

        'If Me.txtBookingNo.Text = "" Then
        '    CheckData = False
        '    DisplayMessage(True, "The code not allow NULL value")
        'End If
        If mStatus = "Add" Then
            Dim rs As New ADODB.Recordset
            'BookingNumber = "%" + CheckBillNumber(Me.txtBookingNo.Text)
            BookingNumber = Me.txtBookingNo.Text
            strQuery = "SELECT * "
            strQuery = strQuery & "from ContainerOutboundNotify_sale "
            strQuery = strQuery & "WHERE (BookingNo like '" & BookingNumber & "') And Continued=1 And ContainerOutboundNotifyID <> '" & mContainerOutboundNotifyId & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                CheckData = False
                rs.Close()
                DisplayMessage(True, "This Booking number had already in database, please check again!")
                Return CheckData
            End If
            rs.Close()

        End If
       

        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Public Sub QueryPort(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_Code"
        value = "Port"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 and show=1 Order By Port desc"
        loadDataToObject(combo, strSQL, id, value)



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub QueryICD(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Code"
        value = "TerminalName"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Code,TerminalName From Terminal where Continued=1 Order By Code desc"
        loadDataToObject(combo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryCustomer()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Customer_ID"
        value = "Company"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Customer_ID,Company From Customer where Continued=1 Order By Company desc"
        'If Me.cboCompany.Items.Count = 0 Then
        loadDataToObject(Me.cboCompany, strSQL, id, value)


        Me.CBOFROM.Items.Clear()
        Me.CBOTO.Items.Clear()
        id = "Port_Code"
        value = "Port_Code"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Code From Port where Continued=1 and show=1 Order By Port_Code desc"
        loadDataToObject(CBOFROM, strSQL, id, value)
        loadDataToObject(CBOTO, strSQL, id, value)
        'End If
        Me.cbofrom_hano.Items.Clear()
        id = "NickName"
        value = "NickName"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select NickName From userlist  Order By NickName desc"
        loadDataToObject(cbofrom_hano, strSQL, id, value)


        Me.cboAirportofDeparture.Items.Clear()
        id = "hanoAir_AirportofDeparture"
        value = "hanoAir_AirportofDeparture"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select distinct hanoAir_AirportofDeparture  "
        strSQL = strSQL & " from ContainerOutboundNotify_sale order by hanoAir_AirportofDeparture " '
        loadDataToObject(Me.cboAirportofDeparture, strSQL, id, value)
     
        Me.cboAirportofdestination.Items.Clear()
        id = "hanoAir_AirportofDestination"
        value = "hanoAir_AirportofDestination"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select distinct hanoAir_AirportofDestination  "
        strSQL = strSQL & " from ContainerOutboundNotify_sale order by hanoAir_AirportofDestination " '
        loadDataToObject(Me.cboAirportofdestination, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Sub queryEmail()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "email"
    '        value = "email"
    '        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
    '        strSQL = "Select email,email From customer where Continued=1 Order By email desc"
    '        'If Me.cboCompany.Items.Count = 0 Then
    '        loadDataToObject(Me.cboemail, strSQL, id, value)
    '        'End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    Sub QueryCommondity()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Commondity"
        value = "Commondity"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Commondity From Commondity where Continued=1 Order By Commondity desc"
        'If Me.cboCompany.Items.Count = 0 Then
        loadDataToObject(Me.cboCommodity, strSQL, id, value)
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryShipperRefNo()
        '        On Error GoTo Err_Renamed
        '        Dim id, value, strSQL As String
        '        id = "CustomerCode"
        '        value = "CustomerCode"
        '        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        '        strSQL = "Select CustomerCode From VVIP where Continued=1 Order By CustomerCode desc"
        '        'If Me.cboCompany.Items.Count = 0 Then
        '        loadDataToObject(Me.cboShipperRefNo, strSQL, id, value)
        '        'End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryVVIPCode()
        On Error GoTo Err_Renamed
        'Dim id, value, strSQL As String
        'id = "VVIPCode"
        'value = "VVIPCode"
        ''strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        'strSQL = "Select VVIPCode From VVIP where Continued=1 Order By VVIPCode desc"
        ''If Me.cboCompany.Items.Count = 0 Then
        'loadDataToObject(Me.cboVIPCode, strSQL, id, value)
        ''End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "vessel"
        value = "vessel"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select distinct vessel  "
        strSQL = strSQL & " from ContainerOutboundNotify_sale order by vessel " '
        loadDataToObject(Me.cboVessel, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryVoy()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "voyno"
        value = "voyno"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select distinct voyno  "
        strSQL = strSQL & " from ContainerOutboundNotify_sale order by voyno " '
        loadDataToObject(Me.txtPreVoyNo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryVesselEdit()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL = strSQL & " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1  and ETD='" & Me.dtpetd.Value.Date & "' Order By Vessel_Code desc" '
        loadDataToObject(Me.cboVessel, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QuerySale()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Sale_ID"
        value = "SaleCode"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Sale_ID,SaleCode From Sale where    Continued=1 Order By SaleName ASC"
        loadDataToObject(Me.cbosale, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryPresentative(ByVal cusid As String)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "PIC"
        value = "PIC"
        strSQL = "Select Customer_ID,PIC From PIC where Customer_ID='" & cusid & "' and Continued=1 Order By PIC"
        loadDataToObject(Me.cboRepresentative, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryShippingline()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "shippinglineid"
        value = "shippingline"
        strSQL = "Select shippinglineid, shippingline From shippingline  Order By shippingline"
        loadDataToObject(Me.cbocarrier, strSQL, id, value)
        'loadDataToObject(Me.cbomastercoloader, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub






    Private Sub frmContainerOutBoundNotify_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try


            Me.dtpetd.Enabled = True
            SetDefaultGrid(Me.dgdContianerOutboundNotify, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'SetDefaultGrid(Me.dgdCountMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'SetDefaultGrid(Me.dgdSplitContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'SetDefaultGrid(Me.dgdBookingContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'SetDefaultGrid(Me.dgdBookingContainerAll, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            mStatus = "Normal"
            blnUpdated = False

            '  Me.GroupBox5.Visible = False
            Wait = 0
            mContainerOutboundNotifyId = DefaultValue
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.fraUpdate.Visible = False
            Me.fraReportSplitBooking.Visible = False

            'lấy số lựơng cont 20 và 40 trong containerr managerment hiện thị ra
            'GetCountContainerManagerment()
            'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
            'LoadComboFind(Me.cboFind, Me.dgdContianerOutboundNotify)
            'Me.chkCheckOrder.Checked = False
            ' queryEmail()
            QuerySale()



            QueryShippingline()
            '----load du lieu tab Format EDI Booking
            QueryShipperRefNo()
            QueryVVIPCode()
            '-------------
            Dim combo As New Object
            combo = Me.cbopod
            If combo.Items.Count = 0 Then
                QueryPort(combo)
            End If
            combo = Me.cbopol
            If combo.Items.Count = 0 Then
                QueryPort(combo)
            End If
            ' nap du lieu TS Code port
            combo = Me.cbopot
            If combo.Items.Count = 0 Then
                QueryPort(combo)
            End If
            combo = Me.cboPOR
            If combo.Items.Count = 0 Then
                QueryPort(combo)
            End If

            combo = Me.cboPORAir
            If combo.Items.Count = 0 Then
                QueryPort(combo)
            End If


            QueryVessel()
            QueryVoy()
            ''-----port of loading
            'combo = Me.cbopol
            'If Me.cbopol.Items.Count = 0 Then
            '    QueryPort(combo)
            'End If

            ' queryBookingPerson()
            QueryCustomer()
            QueryCommondity()
            'Me.cboFind.Text = objUserSetting.GetCParm("frmContainerOutBoundNotify.cboFind", "Company")
            mFilter = objUserSetting.GetCParm("frmContainerOutBoundNotify.mFilter")

            If gOptCurProfile <> "CSCL_IOB" Then
                objProfile.Profile(gOptCurProfile, Me.Name, "Get")
            End If


            dtp = False
            Me.Height = CShort(ctrFrmMain.Height * 0.9)
            Me.Width = CShort(ctrFrmMain.Width * 0.85)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            screenbkH = frmMain.Height
            screenbkV = frmMain.Width
            ReFormat()
            '----set mau nen,fra
            Me.BackColor = gMaunen
            Me.tabpageinformation.BackColor = gMauFra

            Me.tabPageFCL.BackColor = gMauFra
            'Me.cmdBookingEDIClear.BackColor = gMauFra
            Dim sql As String
            Dim ds As New DataSet
            sql = "select optionvalue from [Option] where optioncode='EmailServer' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' Me.txtSMTP.Text = ds.Tables(0).Rows(0).Item("optionvalue").ToString
            End If
            Try


            Catch ex As Exception

            End Try

            monthlyBooking(CDate(Getdate()))
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Public Sub monthlyBooking(ByVal ngay As Date)
        Try
            Dim currow As Integer = 0
            Dim i As Integer
            Dim dem As Integer
            ' show boooking trong thang
            Me.dgdContianerOutboundNotify.Rows.Clear()
            Try
                Dim strQuery As String
                ' hang nhap
                If UCase(gDepartment) = "SALE" Or UCase(gDepartment) = "CUSTOMER" Then


                    'strQuery = "SELECT ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],fileno,BookingNo,ServiceContract,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,ContainerOutBoundNotify.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl, "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY.Delay,CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime   "

                    'strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4 , shippingmarks,descriptionofgood From (((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "" & _
                    '                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                    '                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
                    '                      "  " & _
                    '                      "  "

                    'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 And Wait=0 and sale.salecode= '" & gSaleCode & "' and (CONTAINEROUTBOUNDNOTIFY.branch like '%" & gBranch & "%') "
                    strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fileno,fcl_lcl_air,BookingNo,bkcarrier,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "    "
                    strQuery = strQuery + " "
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1 And (ContainerOutBoundNotify_sale.branch like '%" & gBranch & "%')  AND (sale.salecode= '" & gSaleCode & "')"

                Else
                    strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fileno,fcl_lcl_air,BookingNo,bkcarrier,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "    "
                    strQuery = strQuery + " "
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1 And (ContainerOutBoundNotify_sale.branch like '%" & gBranch & "%') "

                End If
                strQuery += "  and (Month(eta)='" & CDate(ngay).Month & "')  and (year(eta)='" & CDate(ngay).Year & "') and iol='Inbound' order by convert(integer,fileno) desc "
                ds = ReadDataSet(strQuery)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdContianerOutboundNotify.Rows.Add(1)
                        currow = Me.dgdContianerOutboundNotify.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                        Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", currow).Value = ds.Tables(0).Rows(i).Item("ContainerOutBoundNotifyId").ToString
                        Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString

                        Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString
                        ' lay thong tin quotation
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Try
                            If ds.Tables(0).Rows(i).Item("quotationID").ToString <> "" Then
                                sqlq = "select * from quotation_sale where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "

                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try
                        'Try
                        '    sqlq = "select * from outbound where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        Try
                            If ds.Tables(0).Rows(i).Item("docid").ToString <> "" Then


                                sqlq = "select * from inbound_sale where blib_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try

                        '--------------------------------------------------------------------

                        'Try
                        '    sqlq = "select * from logistics where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        '----------------------------------
                        Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                        Me.dgdContianerOutboundNotify.Item("fcl_lcl_Air", currow).Value = ds.Tables(0).Rows(i).Item("fcl_lcl_Air").ToString
                        Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                        Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                        Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                        Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                        Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                        Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                        Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString
                        dem += 1
                        dem += 1
                    Next
                End If
                '----------------------------------------
                '-- hang xuat     
                If UCase(gDepartment) = "SALE" Or UCase(gDepartment) = "CUSTOMER" Then


                    'strQuery = "SELECT ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],fileno,BookingNo,ServiceContract,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,ContainerOutBoundNotify.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl, "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY.Delay,CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime   "

                    'strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4 , shippingmarks,descriptionofgood From (((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "" & _
                    '                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                    '                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
                    '                      "  " & _
                    '                      "  "

                    'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 And Wait=0 and sale.salecode= '" & gSaleCode & "' and (CONTAINEROUTBOUNDNOTIFY.branch like '%" & gBranch & "%') "
                    'strQuery = "SELECT freehand,quotationid,docid,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,fileno,BookingNo,ServiceContract,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,ContainerOutBoundNotify_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "
                    strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fcl_lcl_air,fileno,BookingNo,bkcarrier,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "    "
                    strQuery = strQuery + " "
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + "   From (((ContainerOutBoundNotify_Sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1   and (ContainerOutBoundNotify_sale.branch like '%" & gBranch & "%')  AND (sale.salecode= '" & gSaleCode & "')"

                Else
                    strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],eta,etd,iol,fcl_lcl_air,fileno,BookingNo,bkcarrier,ServiceContract,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "    "
                    strQuery = strQuery + " "
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + "  From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1  and (ContainerOutBoundNotify_sale.branch like '%" & gBranch & "%') "

                End If
                strQuery += "  and (Month(etd)='" & CDate(ngay).Month & "')  and (year(etd)='" & CDate(ngay).Year & "') and iol='Outbound' order by convert(integer,fileno) desc "
                ds = ReadDataSet(strQuery)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdContianerOutboundNotify.Rows.Add(1)
                        currow = Me.dgdContianerOutboundNotify.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                        Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", currow).Value = ds.Tables(0).Rows(i).Item("ContainerOutBoundNotifyId").ToString
                        Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString

                        Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString


                        ' lay thong tin quotation
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Try
                            If ds.Tables(0).Rows(i).Item("quotationid").ToString <> "" Then

                                sqlq = "select * from quotation_sale where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try
                        Try
                            If ds.Tables(0).Rows(i).Item("docid").ToString <> "" Then

                                sqlq = "select * from outbound_sale where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try

                        'Try
                        '    sqlq = "select * from inbound where blib_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        'Try
                        '    sqlq = "select * from logistics where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        '----------------------------------
                        Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                        Me.dgdContianerOutboundNotify.Item("fcl_lcl_Air", currow).Value = ds.Tables(0).Rows(i).Item("fcl_lcl_Air").ToString
                        Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                        Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                        Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                        Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                        Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                        Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                        Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString
                        dem += 1
                    Next
                End If

                ''logistic
                If UCase(gDepartment) = "SALE" Or UCase(gDepartment) = "CUSTOMER" Then


                    'strQuery = "SELECT ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],fileno,BookingNo,ServiceContract,ContainerOutBoundNotify.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,ContainerOutBoundNotify.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl, "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY.Delay,CONTAINEROUTBOUNDNOTIFY.Approve as Approve, CONTAINEROUTBOUNDNOTIFY.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY.Updatetime as UpdateTime   "

                    'strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4 , shippingmarks,descriptionofgood From (((ContainerOutBoundNotify left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "" & _
                    '                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
                    '                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
                    '                      "  " & _
                    '                      "  "

                    'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 1 And Wait=0 and sale.salecode= '" & gSaleCode & "' and (CONTAINEROUTBOUNDNOTIFY.branch like '%" & gBranch & "%') "
                    strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fcl_lcl_air,fileno,BookingNo,bkcarrier,ServiceContract,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "    "
                    strQuery = strQuery + " "
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1 and (ContainerOutBoundNotify_sale.branch like '%" & gBranch & "%')  AND (sale.salecode= '" & gSaleCode & "' ) "

                Else
                    'strQuery = "SELECT freehand,quotationid,docid,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],fileno,iol,BookingNo,ServiceContract,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,ContainerOutBoundNotify_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,ContainerOutBoundNotify_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "
                    '  strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,fileno,BookingNo,bkcarrier,ServiceContract,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                    strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fcl_lcl_air,fileno,BookingNo,bkcarrier,ServiceContract,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "

                    strQuery = strQuery + "  "
                    strQuery = strQuery + "    "
                    strQuery = strQuery + " "
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1 and (ContainerOutBoundNotify_sale.branch like '%" & gBranch & "%') "

                End If
                strQuery += "  and (Month(etd)='" & CDate(ngay).Month & "')  and (year(etd)='" & CDate(ngay).Year & "') and iol='Logistics' order by convert(integer,fileno) desc "
                ds = ReadDataSet(strQuery)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdContianerOutboundNotify.Rows.Add(1)
                        currow = Me.dgdContianerOutboundNotify.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                        Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", currow).Value = ds.Tables(0).Rows(i).Item("ContainerOutBoundNotifyId").ToString
                        Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString

                        Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString

                        ' lay thong tin quotation
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Try

                            If ds.Tables(0).Rows(i).Item("quotationid").ToString <> "" Then
                                sqlq = "select * from quotation_sale where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try
                        'Try
                        '    sqlq = "select * from outbound where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        'Try
                        '    sqlq = "select * from inbound where blib_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        Try
                            If ds.Tables(0).Rows(i).Item("docid").ToString <> "" Then

                                sqlq = "select * from logistics where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                                End If
                            End If

                        Catch ex As Exception

                        End Try

                        '----------------------------------

                        Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                        Me.dgdContianerOutboundNotify.Item("fcl_lcl_Air", currow).Value = ds.Tables(0).Rows(i).Item("fcl_lcl_Air").ToString
                        Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                        Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                        Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                        Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                        Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                        Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                        Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString


                        dem += 1
                    Next
                End If









                'Me.dgdContianerOutboundNotify.DataSource = ds.Tables(0)
                '  Me.lblTotal.Text = "Total : " + (dem).ToString + " Booking in " + CDate(ngay).ToString("MMM")
            Catch ex As Exception

            End Try

            ' dem 
            Dim fcl As Integer = 0
            Dim lcl As Integer = 0
            Dim air As Integer = 0
            Dim logistics As Integer = 0
            Dim consol As Integer = 0
            For i = 0 To Me.dgdContianerOutboundNotify.RowCount - 2

                If UCase(Me.dgdContianerOutboundNotify.Item("FCL_LCL_Air", i).Value.ToString) = "FCL" Then
                    fcl += 1
                End If

                If UCase(Me.dgdContianerOutboundNotify.Item("FCL_LCL_Air", i).Value.ToString) = "LCL" Then
                    lcl += 1
                End If

                If UCase(Me.dgdContianerOutboundNotify.Item("FCL_LCL_Air", i).Value.ToString) = "AIR" Then
                    air += 1
                End If

                If UCase(Me.dgdContianerOutboundNotify.Item("FCL_LCL_Air", i).Value.ToString) = "LOGISTICS (CUSTOMS,TRUCKING)" Then
                    logistics += 1
                End If

                If UCase(Me.dgdContianerOutboundNotify.Item("FCL_LCL_Air", i).Value.ToString) = "CONSOL BOX" Then
                    consol += 1
                End If
            Next


            Me.lblTotal.Text = "Total : " + (dem).ToString + " Booking in " + CDate(ngay).ToString("MMM") + "    " + "FCL : " + fcl.ToString + " / LCL : " + lcl.ToString + " / Air : " + air.ToString '+ " / Logistics : " + logistics.ToString + " / Consol :" + consol.ToString

            InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub monthlyBookingCancel(ByVal ngay As Date)
        Try
            Dim currow As Integer = 0
            Dim i As Integer
            Dim dem As Integer
            ' show boooking trong thang
            Me.dgdContianerOutboundNotify.Rows.Clear()
            Try
                Dim strQuery As String
                ' hang nhap
                If UCase(gDepartment) = "SALE" Or UCase(gDepartment) = "CUSTOMER" Then


                    'strQuery = "SELECT CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],fileno,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl, "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    'strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4 , shippingmarks,descriptionofgood From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "" & _
                    '                      " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                    '                      " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                    '                      "  " & _
                    '                      "  "

                    'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0 and sale.salecode= '" & gSaleCode & "' and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "
                    strQuery = "SELECT freehand,CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],iol,fileno,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4, shippingmarks,descriptionofgood  From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%')  " 'AND sale.salecode= '" & gSaleCode & "'


                Else
                    strQuery = "SELECT freehand,CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],fileno,iol,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4, shippingmarks,descriptionofgood  From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "

                End If
                strQuery += "  and (Month(eta)='" & CDate(ngay).Month & "')  and (year(etd)='" & CDate(ngay).Year & "') and iol='Inbound' order by convert(integer,fileno) desc "
                ds = ReadDataSet(strQuery)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdContianerOutboundNotify.Rows.Add(1)
                        currow = Me.dgdContianerOutboundNotify.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                        Me.dgdContianerOutboundNotify.Item("CONTAINEROUTBOUNDNOTIFYId", currow).Value = ds.Tables(0).Rows(i).Item("CONTAINEROUTBOUNDNOTIFYId").ToString
                        Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString
                        Me.dgdContianerOutboundNotify.Item("MarKet_ID", currow).Value = ds.Tables(0).Rows(i).Item("MarKet_ID").ToString
                        Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString
                        ' lay thong tin quotation
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Try
                            sqlq = "select * from quotation where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                            End If
                        Catch ex As Exception

                        End Try
                        'Try
                        '    sqlq = "select * from outbound where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        Try
                            sqlq = "select * from inbound where blib_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                            End If
                        Catch ex As Exception

                        End Try

                        'Try
                        '    sqlq = "select * from logistics where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        '----------------------------------
                        Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                        Me.dgdContianerOutboundNotify.Item("fcllcl", currow).Value = ds.Tables(0).Rows(i).Item("fcllcl").ToString
                        Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                        Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                        Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("PortOfLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfLoading").ToString
                        Me.dgdContianerOutboundNotify.Item("PortOfUnLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfUnLoading").ToString
                        Me.dgdContianerOutboundNotify.Item("Destination", currow).Value = ds.Tables(0).Rows(i).Item("Destination").ToString
                        Me.dgdContianerOutboundNotify.Item("quantity", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                        Me.dgdContianerOutboundNotify.Item("type", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                        Me.dgdContianerOutboundNotify.Item("gw", currow).Value = ds.Tables(0).Rows(i).Item("gw").ToString
                        Me.dgdContianerOutboundNotify.Item("volumn", currow).Value = ds.Tables(0).Rows(i).Item("volumn").ToString
                        Me.dgdContianerOutboundNotify.Item("Commondity", currow).Value = ds.Tables(0).Rows(i).Item("Commondity").ToString
                        Me.dgdContianerOutboundNotify.Item("descriptionOfGood", currow).Value = ds.Tables(0).Rows(i).Item("descriptionOfGood").ToString
                        Me.dgdContianerOutboundNotify.Item("SaleCode", currow).Value = ds.Tables(0).Rows(i).Item("SaleCode").ToString
                        Me.dgdContianerOutboundNotify.Item("SaleName", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
                        Me.dgdContianerOutboundNotify.Item("BookingDate", currow).Value = ds.Tables(0).Rows(i).Item("BookingDate").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                        Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                        Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                        Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                        Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString
                        Me.dgdContianerOutboundNotify.Item("freehand", currow).Value = ds.Tables(0).Rows(i).Item("freehand").ToString


                        dem += 1
                    Next
                End If
                '----------------------------------------
                '-- hang xuat
                If UCase(gDepartment) = "SALE" Or UCase(gDepartment) = "CUSTOMER" Then


                    'strQuery = "SELECT CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],fileno,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl, "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    'strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4 , shippingmarks,descriptionofgood From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "" & _
                    '                      " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                    '                      " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                    '                      "  " & _
                    '                      "  "

                    'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0 and sale.salecode= '" & gSaleCode & "' and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "
                    strQuery = "SELECT freehand,CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],iol,fileno,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4, shippingmarks,descriptionofgood  From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') " ' AND sale.salecode= '" & gSaleCode & "'

                Else
                    strQuery = "SELECT freehand,CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],fileno,iol,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4, shippingmarks,descriptionofgood  From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "

                End If
                strQuery += "  and (Month(etd)='" & CDate(ngay).Month & "')  and (year(etd)='" & CDate(ngay).Year & "') and iol='Outbound' order by convert(integer,fileno) desc "
                ds = ReadDataSet(strQuery)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdContianerOutboundNotify.Rows.Add(1)
                        currow = Me.dgdContianerOutboundNotify.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                        Me.dgdContianerOutboundNotify.Item("CONTAINEROUTBOUNDNOTIFYId", currow).Value = ds.Tables(0).Rows(i).Item("CONTAINEROUTBOUNDNOTIFYId").ToString
                        Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString
                        Me.dgdContianerOutboundNotify.Item("MarKet_ID", currow).Value = ds.Tables(0).Rows(i).Item("MarKet_ID").ToString
                        Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString

                        ' lay thong tin quotation
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Try
                            sqlq = "select * from quotation where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            sqlq = "select * from outbound where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                            End If
                        Catch ex As Exception

                        End Try

                        'Try
                        '    sqlq = "select * from inbound where blib_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        'Try
                        '    sqlq = "select * from logistics where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        '----------------------------------


                        Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                        Me.dgdContianerOutboundNotify.Item("fcllcl", currow).Value = ds.Tables(0).Rows(i).Item("fcllcl").ToString
                        Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                        Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                        Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("PortOfLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfLoading").ToString
                        Me.dgdContianerOutboundNotify.Item("PortOfUnLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfUnLoading").ToString
                        Me.dgdContianerOutboundNotify.Item("Destination", currow).Value = ds.Tables(0).Rows(i).Item("Destination").ToString
                        Me.dgdContianerOutboundNotify.Item("quantity", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                        Me.dgdContianerOutboundNotify.Item("type", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                        Me.dgdContianerOutboundNotify.Item("gw", currow).Value = ds.Tables(0).Rows(i).Item("gw").ToString
                        Me.dgdContianerOutboundNotify.Item("volumn", currow).Value = ds.Tables(0).Rows(i).Item("volumn").ToString
                        Me.dgdContianerOutboundNotify.Item("Commondity", currow).Value = ds.Tables(0).Rows(i).Item("Commondity").ToString
                        Me.dgdContianerOutboundNotify.Item("descriptionOfGood", currow).Value = ds.Tables(0).Rows(i).Item("descriptionOfGood").ToString
                        Me.dgdContianerOutboundNotify.Item("SaleCode", currow).Value = ds.Tables(0).Rows(i).Item("SaleCode").ToString
                        Me.dgdContianerOutboundNotify.Item("SaleName", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
                        Me.dgdContianerOutboundNotify.Item("BookingDate", currow).Value = ds.Tables(0).Rows(i).Item("BookingDate").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                        Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                        Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                        Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                        Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString
                        Try
                            Me.dgdContianerOutboundNotify.Item("freehand", currow).Value = ds.Tables(0).Rows(i).Item("freehand").ToString
                        Catch ex As Exception

                        End Try

                        dem += 1
                    Next
                End If

                ''logistic
                If UCase(gDepartment) = "SALE" Or UCase(gDepartment) = "CUSTOMER" Then


                    'strQuery = "SELECT CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],fileno,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl, "
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    'strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    'strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    'strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    'strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4 , shippingmarks,descriptionofgood From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    'strQuery = strQuery + "  "
                    'strQuery = strQuery + "" & _
                    '                      " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                    '                      " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                    '                      "  " & _
                    '                      "  "

                    'strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0 and sale.salecode= '" & gSaleCode & "' and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "
                    strQuery = "SELECT freehand,CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],iol,fileno,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4, shippingmarks,descriptionofgood  From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%')  " 'AND sale.salecode= '" & gSaleCode & "'

                Else
                    strQuery = "SELECT freehand,CONTAINEROUTBOUNDNOTIFYId,stuff(fileno,1,3,'') as [order],fileno,iol,BookingNo,ServiceContract,CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,Representative,CONTAINEROUTBOUNDNOTIFY_sale.Commondity ,weekofyear,ServiceFeeder,shippingline,PortOfUnLoading, Destination, mak.Market_ID,mak.MarketCode,TruckCompany,ReceiptContainer, carrier,voyno,capacity,slot,  ETD,ETA,Tranship,VIA2,VIA3,VIA4,PortOfLoading,quantity,gw,volumn,CONTAINEROUTBOUNDNOTIFY_sale.type,quantity1,type1,quantity2,type2,shipper,consignee,notify,sr,br,type_,mbl,hbl,connvsl,voy,etdts,bkcarrier,fcllcl,  "
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "  SoLuong20GP,  W20GP,  SoLuong40GP, W40GP,    SoLuong40HC,W40HC,SoLuong45HC, W45HC,  SoLuong20RF,W20RF,SoLuong40RF,W40RF,  SoLuong40RH,W40RH,SoLuong20OT,W20OT,SoLuong40OT,W40OT,SoLuong20FR,W20FR,SoLuong40FR,W40FR,SoLuongCBM,WCBM,Cold ,Ventilation,SpencialEquipment,LocalCargo,EmptyMoving,TransiteCargo,SOC,SlotExchange,FOBCargo,MaxWMainPort,MaxWLocal, EmptyContainerPlace,NgayCapCont ,PackingWay,CustomsLiquiDate,FullReturnContainerPlace,Gio1,AMPM1,DateClosing1,Gio2,AMPM2,DateClosing2,GioBD,AMPMBD,BD,FirstSendDate,SecondSendDate,ThirdSendDate,limitedBooking,ContactUs,CONTAINEROUTBOUNDNOTIFY_sale.Remarks as Remarks,SpecialRemarks,SupplyOrderPlace,PayMentTerm,Sale.Sale_ID,Sale.SaleCode,Sale.SaleName,    "
                    strQuery = strQuery + " BookingDate,BookingPerson,BC,"
                    strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Delay,CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,lockorder,"
                    strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                    strQuery = strQuery + " , cont1,cont2,cont3,cont4,seal1,seal2,seal3,seal4, shippingmarks,descriptionofgood  From (((CONTAINEROUTBOUNDNOTIFY_sale left JOIN Customer on CONTAINEROUTBOUNDNOTIFY_sale.Customer_ID=Customer.Customer_ID)"
                    strQuery = strQuery + "  "
                    strQuery = strQuery + "" & _
                                          " left JOIN Market mak on mak.MarKet_ID = CONTAINEROUTBOUNDNOTIFY_sale.Market_ID) " & _
                                          " left JOIN Sale on Sale.Sale_ID = CONTAINEROUTBOUNDNOTIFY_sale.Sale_ID )" & _
                                          "  " & _
                                          "  "
                    strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 0 And Wait=0  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "

                End If
                strQuery += "  and (Month(etd)='" & CDate(ngay).Month & "') and (year(etd)='" & CDate(ngay).Year & "')  and iol='Logistics' order by convert(integer,fileno) desc "
                ds = ReadDataSet(strQuery)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdContianerOutboundNotify.Rows.Add(1)
                        currow = Me.dgdContianerOutboundNotify.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                        Me.dgdContianerOutboundNotify.Item("CONTAINEROUTBOUNDNOTIFYId", currow).Value = ds.Tables(0).Rows(i).Item("CONTAINEROUTBOUNDNOTIFYId").ToString
                        Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString
                        Me.dgdContianerOutboundNotify.Item("MarKet_ID", currow).Value = ds.Tables(0).Rows(i).Item("MarKet_ID").ToString
                        Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString


                        ' lay thong tin quotation
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Try
                            sqlq = "select * from quotation where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                            End If
                        Catch ex As Exception

                        End Try
                        'Try
                        '    sqlq = "select * from outbound where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        'Try
                        '    sqlq = "select * from inbound where blib_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                        '    dsq = ReadDataSet(sqlq)
                        '    If dsq.Tables(0).Rows.Count > 0 Then
                        '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        Try
                            sqlq = "select * from logistics where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                            End If
                        Catch ex As Exception

                        End Try

                        '----------------------------------


                        Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                        Me.dgdContianerOutboundNotify.Item("fcllcl", currow).Value = ds.Tables(0).Rows(i).Item("fcllcl").ToString
                        Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                        Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                        Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("PortOfLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfLoading").ToString
                        Me.dgdContianerOutboundNotify.Item("PortOfUnLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfUnLoading").ToString
                        Me.dgdContianerOutboundNotify.Item("Destination", currow).Value = ds.Tables(0).Rows(i).Item("Destination").ToString
                        Me.dgdContianerOutboundNotify.Item("quantity", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                        Me.dgdContianerOutboundNotify.Item("type", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                        Me.dgdContianerOutboundNotify.Item("gw", currow).Value = ds.Tables(0).Rows(i).Item("gw").ToString
                        Me.dgdContianerOutboundNotify.Item("volumn", currow).Value = ds.Tables(0).Rows(i).Item("volumn").ToString
                        Me.dgdContianerOutboundNotify.Item("Commondity", currow).Value = ds.Tables(0).Rows(i).Item("Commondity").ToString
                        Me.dgdContianerOutboundNotify.Item("descriptionOfGood", currow).Value = ds.Tables(0).Rows(i).Item("descriptionOfGood").ToString
                        Me.dgdContianerOutboundNotify.Item("SaleCode", currow).Value = ds.Tables(0).Rows(i).Item("SaleCode").ToString
                        Me.dgdContianerOutboundNotify.Item("SaleName", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
                        Me.dgdContianerOutboundNotify.Item("BookingDate", currow).Value = ds.Tables(0).Rows(i).Item("BookingDate").ToString.Replace("12:00:00 AM", "")
                        Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                        Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                        Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                        Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                        Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString
                        Try
                            Me.dgdContianerOutboundNotify.Item("freehand", currow).Value = ds.Tables(0).Rows(i).Item("freehand").ToString
                        Catch ex As Exception

                        End Try
                        dem += 1
                    Next
                End If









                'Me.dgdContianerOutboundNotify.DataSource = ds.Tables(0)
                Me.lblTotal.Text = "Total : " + (dem).ToString + " Booking (Cancel) in " + CDate(ngay).ToString("MMM")
            Catch ex As Exception

            End Try
            InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmContainerOutBoundNotify_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListVVIP_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtContainerOutboundNotify", Me.txtContainerOutboundNotify.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtBookingNo", Me.txtBookingNo.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtCompany", Me.cboCompany.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtRepresentative", Me.cboRepresentative.Text)

        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtEmptyContainerPlace", Me.cboEmptyContainerPlace.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtVentilation", Me.txtVentilation.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtCold", Me.txtCold.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.mFilter", mFilter)

        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtPackingWay", Me.txtPackingWay.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtRemarks", Me.txtRemarks.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtMaxWMainPort", Me.txtMWMP.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtMaxWLocal", Me.txtMWL.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtContactUs", Me.txtContactUs.Text)

        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtCuctomsLiquiDate", Me.txtCustomsLiquidate.Text)


        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtVessel", Me.cboVessel.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.cboTranship", Me.cbotranship.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.cobDestination", Me.cboDestination.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.dtpLeavingDate", Me.dtpLeavingDate.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.cboPortOfUnLoading", Me.cboPortOfUnLoading.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.cboBookingPerSon", Me.cboBookingPerson.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.dtpBookingDate", Me.dtpBookingDate.Text)
        'objUserSetting.SetCParm("frmContainerOutBoundNotify.txtSpenCialEquipment", Me.txtSpencialEquipment.Text)

        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong20GP", Me.txtSoLuong20GP.Text)
        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong40GP", Me.txtSoLuong40GP.Text)
        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong40HC", Me.txtSoLuong40HC.Text)
        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong45HC", Me.txtSoLuong45HC.Text)
        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong20RF", Me.txtSoLuong20RF.Text)
        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong40RF", Me.txtSoLuong40RF.Text)
        'objUserSetting.setCParm("frmContainerOutBoundNotify.txtSoLuong40RH", Me.txtSoLuong40RH.Text)


        'GetCountContainerManagerment()
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========Menu==========
    Public Function CodeContainerOutboundNotify() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(ContainerOutboundNotify_Code) as CountNo from ContainerOutboundNotify_sale", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function

    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

    Public Sub insert()
        '------------------
        Me.cboVessel.Text = ""

        Me.cbopot.Text = ""
        Me.cbopol.Text = ""
        Me.cboCompany.Text = ""
        Me.cboRepresentative.Text = ""
        Me.cboCommodity.Text = ""
        Me.cbopod.Text = ""
        'Me.cboDestination.Text = ""
        Me.cboPOR.Text = ""

        Me.txtPreVoyNo.Text = ""

        '----

        'Me.txtVia3.Text = ""







        'Me.txtAMPM2.Text = ""


    End Sub

    Public Sub ApproveContainerOutboundNotify()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        ' If Me.oTable.Rows.Count > 0 Then
        index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        '  End If

        Dim strQueryContainerOutboundNotifyList As String
        If Not UserRight("mnuCustomerService", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryContainerOutboundNotify(mFilter, , index)
        Else
            strQueryContainerOutboundNotifyList = "Select * from ContainerOutboundNotify_sale where" + " ContainerOutBoundNotifyId= '" & dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "'"
            rsContainerOutboundNotifyList.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsContainerOutboundNotifyList.Fields("Approve").Value
            rsContainerOutboundNotifyList.Update("Approve", Approve)
            rsContainerOutboundNotifyList.Close()
        End If
        QueryContainerOutboundNotify(mFilter, , index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    
    Public Sub Revised(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean

        ' Xét Quyền Xoá
        strQuery = "Select top 1 BL_NO from BillOfLading WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "'  And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = rs.EOF
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The Booking can not be removed. There are transactions that relate to Bill of lading.")
            Exit Sub
        End If



        strQuery = "Select * from ContainerOutboundNotify_sale WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, "Sorry, The Booking can not be removed.")
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Approve", index)) Then
            If Me.dgdContianerOutboundNotify.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Editable", index)) Then
            If Not Me.dgdContianerOutboundNotify.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnuCustomerService", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Cancel the ContainerOutboundNotify: " & Me.dgdContianerOutboundNotify.Item("Company", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Update ContainerOutboundNotify Set Continued=0,BC='RD' where" + " BookingNo= '" & Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim & "' And Continued=1"
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim cmd As New SqlClient.SqlCommand(strQueryCommodityList, Conn)
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strQueryCommodityList
                cmd.ExecuteNonQuery()
                Conn.Close()
                Conn.Dispose()
                cmd.Dispose()

                'rsContainerOutboundNotifyList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsContainerOutboundNotifyList.Fields("continued").Value = 0
                'rsContainerOutboundNotifyList.Update()

                'rsContainerOutboundNotifyList.Requery()
                'Me.dgdContianerOutboundNotify.Rows(index).DefaultCellStyle.ForeColor = Color.White
                'Me.dgdContianerOutboundNotify.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsContainerOutboundNotifyList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

#Region "ViewMenuStrip"
#End Region

#Region "Xuly"
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Booking "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Booking -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Booking -> Add."
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

    End Sub

    '==========Query==========

    Public Sub QueryContainerOutboundNotify(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        Try


            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim ds As New DataSet
            Dim currow As Integer = 0
            Dim i As Integer
            '----------------
            'If IsNothing(argCriteria) Then
            '    strQuery = MakeQueryContainerOutboundNotify()
            'Else
            '    strQuery = MakeQueryContainerOutboundNotify(argCriteria, index)
            'End If
            Me.dgdContianerOutboundNotify.Rows.Clear()
            If UCase(gDepartment) = "SALE" Then


                strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fileno,fcl_lcl_air,BookingNo,bkcarrier,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                strQuery = strQuery + "  "
                strQuery = strQuery + "    "
                strQuery = strQuery + " "
                strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                strQuery = strQuery + "  "
                strQuery = strQuery + "" & _
                                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                      "  " & _
                                      "  "

                strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1   and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') and (sale.salecode= '" & gSaleCode & "' ) "
                If argCriteria <> "" Then
                    strQuery = strQuery + argCriteria
                End If
            ElseIf UCase(gDepartment) = "CUSTOMER" Then


                strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fileno,fcl_lcl_air,BookingNo,bkcarrier,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                strQuery = strQuery + "  "
                strQuery = strQuery + "    "
                strQuery = strQuery + " "
                strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                strQuery = strQuery + "  "
                strQuery = strQuery + "" & _
                                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                      "  " & _
                                      "  "

                strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1  and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') and (sale.salecode= '" & gSaleCode & "' ) "
                If argCriteria <> "" Then
                    strQuery = strQuery + argCriteria
                End If
            Else
                strQuery = "SELECT  quotationid,docid,CONTAINEROUTBOUNDNOTIFY_sale.sale_id,ContainerOutBoundNotifyId,stuff(fileno,1,3,'') as [order],iol,eta,etd,fileno,fcl_lcl_air,BookingNo,bkcarrier,ContainerOutBoundNotify_sale.Customer_ID as Customer_Id , Customer.Company as Company, Customer.Address as address, Customer.Tel as Telephone, Customer.Fax as Fax,customer.email as email,  "
                strQuery = strQuery + "  "
                strQuery = strQuery + "    "
                strQuery = strQuery + " "
                strQuery = strQuery + "  CONTAINEROUTBOUNDNOTIFY_sale.Approve as Approve, CONTAINEROUTBOUNDNOTIFY_sale.Continued as Continued,  CONTAINEROUTBOUNDNOTIFY_sale.Editable as Editable,"
                strQuery = strQuery + "CONTAINEROUTBOUNDNOTIFY_sale.UserId as UserId,  CONTAINEROUTBOUNDNOTIFY_sale.Updatetime as UpdateTime   "

                strQuery = strQuery + "   From (((ContainerOutBoundNotify_sale left JOIN Customer on ContainerOutBoundNotify_sale.Customer_ID=Customer.Customer_ID)"
                strQuery = strQuery + "  "
                strQuery = strQuery + "" & _
                                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify_sale.Market_ID) " & _
                                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify_sale.Sale_ID )" & _
                                      "  " & _
                                      "  "
                strQuery = strQuery + "WHERE CONTAINEROUTBOUNDNOTIFY_sale.Continued = 1   and (CONTAINEROUTBOUNDNOTIFY_sale.branch like '%" & gBranch & "%') "
                If argCriteria <> "" Then
                    strQuery = strQuery + argCriteria
                End If
            End If
            strQuery += " order by convert(integer,fileno) desc "
            ds = ReadDataSet(strQuery)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgdContianerOutboundNotify.Rows.Add(1)
                    currow = Me.dgdContianerOutboundNotify.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
                    Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                    Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
                    Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", currow).Value = ds.Tables(0).Rows(i).Item("ContainerOutBoundNotifyId").ToString
                    Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString

                    Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString

                    ' lay thong tin quotation
                    Dim sqlq As String
                    Dim dsq As New DataSet
                    Try

                        If ds.Tables(0).Rows(i).Item("quotationid").ToString <> "" Then
                            sqlq = "select * from quotation_sale where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                    'Try
                    '    sqlq = "select * from outbound where blob_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                    '    dsq = ReadDataSet(sqlq)
                    '    If dsq.Tables(0).Rows.Count > 0 Then
                    '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    'Try
                    '    sqlq = "select * from inbound where blib_id like '%" & ds.Tables(0).Rows(i).Item("docid").ToString & "%' "
                    '    dsq = ReadDataSet(sqlq)
                    '    If dsq.Tables(0).Rows.Count > 0 Then
                    '        Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    Try
                        If ds.Tables(0).Rows(i).Item("docid").ToString <> "" Then

                            sqlq = "select * from logistics where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try

                    '----------------------------------

                    Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
                    Me.dgdContianerOutboundNotify.Item("fcl_lcl_Air", currow).Value = ds.Tables(0).Rows(i).Item("fcl_lcl_Air").ToString
                    Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
                    Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
                    Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
                    Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
                    Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
                    Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
                    Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
                    Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
                    Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString


                    ' dem += 1
                Next
            End If
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        For i = 0 To ds.Tables(0).Rows.Count - 1
            '            Me.dgdContianerOutboundNotify.Rows.Add(1)
            '            currow = Me.dgdContianerOutboundNotify.RowCount - 2
            '            ' hien thi noi dung bill Ib
            '            Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.BackColor = Color.White
            '            Me.dgdContianerOutboundNotify.Rows(currow).DefaultCellStyle.ForeColor = Color.Blue
            '            Me.dgdContianerOutboundNotify.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString
            '            Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", currow).Value = ds.Tables(0).Rows(i).Item("ContainerOutBoundNotifyId").ToString
            '            Me.dgdContianerOutboundNotify.Item("Customer_ID", currow).Value = ds.Tables(0).Rows(i).Item("Customer_ID").ToString
            '            Me.dgdContianerOutboundNotify.Item("MarKet_ID", currow).Value = ds.Tables(0).Rows(i).Item("MarKet_ID").ToString
            '            Me.dgdContianerOutboundNotify.Item("Sale_ID", currow).Value = ds.Tables(0).Rows(i).Item("Sale_ID").ToString

            '            Me.dgdContianerOutboundNotify.Item("BookingNo", currow).Value = ds.Tables(0).Rows(i).Item("BookingNo").ToString
            '            ' lay thong tin quotation
            '            Dim sqlq As String
            '            Dim dsq As New DataSet
            '            Try
            '                sqlq = "select * from quotation where quotationID = '" & ds.Tables(0).Rows(i).Item("quotationID").ToString & "' "
            '                dsq = ReadDataSet(sqlq)
            '                If dsq.Tables(0).Rows.Count > 0 Then
            '                    Me.dgdContianerOutboundNotify.Item("quotationno", currow).Value = dsq.Tables(0).Rows(0).Item("quotationno").ToString
            '                End If
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                sqlq = "select * from outbound where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
            '                dsq = ReadDataSet(sqlq)
            '                If dsq.Tables(0).Rows.Count > 0 Then
            '                    Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
            '                End If
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                sqlq = "select * from inbound where blib_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
            '                dsq = ReadDataSet(sqlq)
            '                If dsq.Tables(0).Rows.Count > 0 Then
            '                    Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
            '                End If
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                sqlq = "select * from logistics where blob_id = '" & ds.Tables(0).Rows(i).Item("docid").ToString & "' "
            '                dsq = ReadDataSet(sqlq)
            '                If dsq.Tables(0).Rows.Count > 0 Then
            '                    Me.dgdContianerOutboundNotify.Item("ref", currow).Value = dsq.Tables(0).Rows(0).Item("ref").ToString
            '                End If
            '            Catch ex As Exception

            '            End Try
            '            '----------------------------------
            '            Me.dgdContianerOutboundNotify.Item("fcllcl", currow).Value = ds.Tables(0).Rows(i).Item("fcllcl").ToString
            '            Me.dgdContianerOutboundNotify.Item("bkcarrier", currow).Value = ds.Tables(0).Rows(i).Item("bkcarrier").ToString
            '            Me.dgdContianerOutboundNotify.Item("Company", currow).Value = ds.Tables(0).Rows(i).Item("Company").ToString
            '            Me.dgdContianerOutboundNotify.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("etd").ToString.Replace("12:00:00 AM", "")
            '            Me.dgdContianerOutboundNotify.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString.Replace("12:00:00 AM", "")
            '            Me.dgdContianerOutboundNotify.Item("PortOfLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfLoading").ToString
            '            Me.dgdContianerOutboundNotify.Item("PortOfUnLoading", currow).Value = ds.Tables(0).Rows(i).Item("PortOfUnLoading").ToString
            '            Me.dgdContianerOutboundNotify.Item("Destination", currow).Value = ds.Tables(0).Rows(i).Item("Destination").ToString
            '            Me.dgdContianerOutboundNotify.Item("quantity", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
            '            Me.dgdContianerOutboundNotify.Item("type", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
            '            Me.dgdContianerOutboundNotify.Item("gw", currow).Value = ds.Tables(0).Rows(i).Item("gw").ToString
            '            Me.dgdContianerOutboundNotify.Item("volumn", currow).Value = ds.Tables(0).Rows(i).Item("volumn").ToString
            '            Me.dgdContianerOutboundNotify.Item("Commondity", currow).Value = ds.Tables(0).Rows(i).Item("Commondity").ToString
            '            Me.dgdContianerOutboundNotify.Item("descriptionOfGood", currow).Value = ds.Tables(0).Rows(i).Item("descriptionOfGood").ToString
            '            Me.dgdContianerOutboundNotify.Item("SaleCode", currow).Value = ds.Tables(0).Rows(i).Item("SaleCode").ToString
            '            Me.dgdContianerOutboundNotify.Item("SaleName", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
            '            Me.dgdContianerOutboundNotify.Item("BookingDate", currow).Value = ds.Tables(0).Rows(i).Item("BookingDate").ToString.Replace("12:00:00 AM", "")
            '            Me.dgdContianerOutboundNotify.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString
            '            Me.dgdContianerOutboundNotify.Item("UserId", currow).Value = ds.Tables(0).Rows(i).Item("UserId").ToString
            '            Me.dgdContianerOutboundNotify.Item("UpdateTime", currow).Value = ds.Tables(0).Rows(i).Item("UpdateTime").ToString
            '            Me.dgdContianerOutboundNotify.Item("editable", currow).Value = ds.Tables(0).Rows(i).Item("editable").ToString
            '            Me.dgdContianerOutboundNotify.Item("iol", currow).Value = ds.Tables(0).Rows(i).Item("iol").ToString

            '            Try
            '                Me.dgdContianerOutboundNotify.Item("freehand", currow).Value = ds.Tables(0).Rows(i).Item("freehand").ToString
            '            Catch ex As Exception

            '            End Try
            '        Next
            '    End If
            '    'Con.Open()
            '    'Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            '    'Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '    ''-----------------
            '    ''Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            '    '' Con.Open()
            '    'Adapter.Fill(ds, "ContainerOutboundNotifyList")
            '    'oTable = ds.Tables(0)
            '    ''hien thi ra grid 
            '    'Me.dgdContianerOutboundNotify.DataSource = ds.Tables("ContainerOutboundNotifyList")
            '    'If Me.dgdContianerOutboundNotify.Enabled = False Then
            '    '    Me.dgdContianerOutboundNotify.Enabled = True
            '    'End If

            '    'Me.Cursor = System.Windows.Forms.Cursors.Default
            '    'If oTable.Rows.Count > 0 Then
            '    '    Me.dgdContianerOutboundNotify.Columns.Item("BookingNo").ToolTipText = "Hiện có:" + CStr(Me.dgdContianerOutboundNotify.RowCount()) + " ContainerOutboundNotifys."
            '    'End If
            '    'If Me.dgdContianerOutboundNotify.RowCount() = 0 Then
            '    '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            '    'End If

            '    InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
            '    '---- so 0 thanh mau trang
            '    Dim t, s As Integer
            '    'For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
            '    '    For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
            '    '        If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
            '    '            Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
            '    '        End If
            '    '    Next
            '    'Next
            '    '------------vị trí BM
            '    If location >= 0 And location <= Me.dgdContianerOutboundNotify.Rows.Count And Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            '        Me.dgdContianerOutboundNotify.Rows(location).Selected = True
            '        Me.dgdContianerOutboundNotify.CurrentCell = Me.dgdContianerOutboundNotify.Rows(location).Cells("BookingNo")
            '    End If
            '    '--------------------
            '    Me.lblTotal.Text = ""
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

        'Resume
    End Sub

    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.smnuSearch.Enabled = argVisible
        Me.smnuEdit.Enabled = argVisible
        Me.mnuRestore.Enabled = argVisible
        Me.DelayToolStripMenuItem.Enabled = argVisible
        Me.smnuRefesh.Enabled = True
        Me.smnuPrint.Enabled = True

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(fraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(fraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = screenbkH - 10 - Me.Top
        Me.Width = screenbkV - 8
        dgdContianerOutboundNotify.Width = (Me.Width - 30)
        If Me.Width > 610 Then
            dgdContianerOutboundNotify.Height = Me.Height - Me.cmdCancel.Height - 70 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdContianerOutboundNotify.Height = Me.Height - 120 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdContianerOutboundNotify.Height + dgdContianerOutboundNotify.Top

        ' Me.txtContainerOutboundNotify.Width = Me.Width - 400

        'me.txtCompany.Width = Me.fraUpdate.Width - me.txtCompany.Left - 10
        'me.txtCuctomsLiquiDate.Width = Me.fraUpdate.Width - me.txtCuctomsLiquiDate.Left - 10
        'me.txtCompany.Width = Me.fraUpdate.Width -me.txtRepresentative.Left - 10

        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        cmdOK.Top = fraUpdate.Bottom + cmdOK.Height - 22
        cmdCancel.Top = fraUpdate.Bottom + cmdOK.Height - 22
        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10

        'cmdFind.Left = Me.txtContainerOutboundNotify.Left + Me.txtContainerOutboundNotify.Width + 10
        'txtContainerOutboundNotify.Width = Me.Width - 400

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdContianerOutboundNotify_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        If Me.dgdContianerOutboundNotify.Rows.Count = 0 Then
            Return
        End If
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdContianerOutboundNotify.Columns(ColIndex).Name = "Approve" And Me.dgdContianerOutboundNotify.CurrentCellAddress().Y = index Then
            Call ApproveContainerOutboundNotify()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdContianerOutboundNotify_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryContainerOutboundNotify("", index)
        '        End If
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
            For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
                    Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdContianerOutboundNotify_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim selectedRowCount As Integer = _
       Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdContianerOutboundNotify.SelectedRows(i).Index)
                Next i
            End If

            QueryContainerOutboundNotify()
        End If
    End Sub


    Public Sub RefreshBookingEDI(ByVal BookingID As String)
        ' Dim rs As New ADODB.Recordset
        'Dim strQuery As String
        'strQuery = "SELECT * "
        'strQuery = strQuery & "FROM BookingEDI "
        'strQuery = strQuery & "WHERE ContainerOutboundNotifyID = '" & BookingID & "' and continued=1"
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'If Not rs.EOF Then
        '    Me.txtBookingOtherRef.Text = rs.Fields("BookingOtherRef").Value
        '    Me.cboShipperRefNo.Text = rs.Fields("ShipperRefNo").Value
        '    Me.txtBLNo.Text = rs.Fields("BLNo").Value
        '    Me.txtPO.Text = rs.Fields("PO").Value
        '    Me.cboVIPCode.Text = rs.Fields("VIPCode").Value
        '    Me.txtCargoDescription.Text = rs.Fields("CargoDescription").Value
        '    Me.txtCommodityEDI.Text = rs.Fields("CommodityEDI").Value
        '    Me.txtShipperName.Text = rs.Fields("ShipperName").Value
        '    Me.txtConsigneeName.Text = rs.Fields("ConsigneeName").Value
        '    Me.txtNotifyName.Text = rs.Fields("NotifyName").Value
        '    Me.cboBookingstatus.Text = rs.Fields("BookingStatus").Value
        '    Me.txtBookingOffice.Text = rs.Fields("BookingOffice").Value
        '    Me.txtBookingArea.Text = rs.Fields("BookingArea").Value
        '    Me.txtUserID.Text = rs.Fields("BookingUserID").Value

        'Else
        '    ClsBookingEDI()
        'End If
        'rs.Close()

    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString

            ' hien thi lcl
            Dim bookingno, bkID As String
            If index < 0 Then
                Return
            End If

            bookingno = Me.dgdContianerOutboundNotify.Item("bookingno", index).Value.ToString
            bkID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
            Dim sql As String
            Dim ds As New DataSet

            sql = "select * from ContainerOutboundNotify_sale where ContainerOutBoundNotifyId='" & bkID & "' and continued=1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    '--------------------------------
                    Me.cboIOL.Text = ds.Tables(0).Rows(0).Item("IOL").ToString
                    Me.txtBookingNo.Text = ds.Tables(0).Rows(0).Item("BookingNo").ToString
                    Me.txtBKcarrier.Text = ds.Tables(0).Rows(0).Item("bkcarrier").ToString


                    Me.cboCompany.Text = FindIDValue(Me.cboCompany, ds.Tables(0).Rows(0).Item("Customer_ID").ToString)

                    Me.cboRepresentative.Text = ds.Tables(0).Rows(0).Item("attn").ToString


                    Me.cbofrom_hano.Text = ds.Tables(0).Rows(0).Item("hano_from").ToString

                    Me.dtphano_date.Value = ds.Tables(0).Rows(0).Item("hano_date").ToString

                    Me.cboCommodity.Text = ds.Tables(0).Rows(0).Item("hano_Commodity").ToString
                    Me.cboFLA.Text = ds.Tables(0).Rows(0).Item("fcl_lcl_air").ToString
                    '------------------


                    Me.txtdelivery.Text = ds.Tables(0).Rows(0).Item("hano_delivery").ToString
                    Me.cboPOR.Text = ds.Tables(0).Rows(0).Item("hano_POR").ToString
                    Me.cbopol.Text = ds.Tables(0).Rows(0).Item("hano_POl").ToString
                    Me.cbopot.Text = ds.Tables(0).Rows(0).Item("hano_POt").ToString
                    Me.cbopod.Text = ds.Tables(0).Rows(0).Item("hano_POd").ToString
                    '----------------------------
                    Me.cboVessel.Text = ds.Tables(0).Rows(0).Item("vessel").ToString
                    Me.txtPreVoyNo.Text = ds.Tables(0).Rows(0).Item("voyno").ToString

                    '---------------------
                    Me.dtpETA.Value = ds.Tables(0).Rows(0).Item("eta").ToString
                    Me.dtpetd.Value = ds.Tables(0).Rows(0).Item("etd").ToString

                 
                    Me.cbocarrier.Text = ds.Tables(0).Rows(0).Item("carrier").ToString

                    Me.cbosale.Text = FindIDValue(Me.cbosale, ds.Tables(0).Rows(0).Item("Sale_ID").ToString)
                    Me.txtSaleName.Text = ds.Tables(0).Rows(0).Item("SaleName").ToString

                    Me.txtpaymentTerm.Text = ds.Tables(0).Rows(0).Item("hano_Payment").ToString
                    Me.txtclosingSIAFR.Text = ds.Tables(0).Rows(0).Item("hano_Closing").ToString
                    Me.txtClosingDelivery.Text = ds.Tables(0).Rows(0).Item("hano_Closingdelivery").ToString
                    Me.txtWCP.Text = ds.Tables(0).Rows(0).Item("hano_WeightCBMPKG").ToString


                    Me.txtQuantity.Text = ds.Tables(0).Rows(0).Item("hanoFCL_Quality").ToString

                    Me.txtRemarks.Text = ds.Tables(0).Rows(0).Item("Remarks").ToString ' FCL

                    Me.txtdelivery.Text = ds.Tables(0).Rows(0).Item("hano_delivery").ToString ' FCL
                    Me.txtCFSWH.Text = ds.Tables(0).Rows(0).Item("hanoLCL_CFSWH").ToString ' FCL
                    Me.txtAdd.Text = ds.Tables(0).Rows(0).Item("hanoLCL_Add").ToString ' FCL
                    Me.txtVNACCSCODE.Text = ds.Tables(0).Rows(0).Item("hanoLCL_VNACCSCODE").ToString ' FCL
                    Me.txtwhpic.Text = ds.Tables(0).Rows(0).Item("hanoLCL_WHPIC").ToString
                    Me.txtbookingPIC.Text = ds.Tables(0).Rows(0).Item("hanoLCL_BookingPIC").ToString
                    Me.txtRemarksLCL.Text = ds.Tables(0).Rows(0).Item("remarksLCL").ToString

                    '----
                    Me.txtAIRlines.Text = ds.Tables(0).Rows(0).Item("hanoAir_AIRlines").ToString
                    Me.cboAirportofDeparture.Text = ds.Tables(0).Rows(0).Item("hanoAir_AirportofDeparture").ToString
                    Me.cboAirportofdestination.Text = ds.Tables(0).Rows(0).Item("hanoAir_AirportofDestination").ToString
                    Me.txtshipperConsignee.Text = ds.Tables(0).Rows(0).Item("hanoAir_ShipperConsignee").ToString
                    Me.txtDescriptionofgoods.Text = ds.Tables(0).Rows(0).Item("hanoAir_Descriptionofgoods").ToString
                    Me.txtFreightrateterm.Text = ds.Tables(0).Rows(0).Item("hanoAir_Freightrateterm").ToString
                    Me.txtMAWBHAWB.Text = ds.Tables(0).Rows(0).Item("hanoAIr_MAWBHAWBNo").ToString
                    Me.txtRoutingVoyage.Text = ds.Tables(0).Rows(0).Item("hanoAir_RoutingVoyage").ToString
                    Me.txtFlighttime.Text = ds.Tables(0).Rows(0).Item("hanoAIr_Flighttime").ToString
                    Me.txtCutoffdatetime.Text = ds.Tables(0).Rows(0).Item("hanoAir_Cutoffdatetime").ToString
                    Me.txtDeliverycontactat.Text = ds.Tables(0).Rows(0).Item("hanoAir_Deliverycontactat").ToString
                    Me.txtmornning.Text = ds.Tables(0).Rows(0).Item("hanoAir_Morning").ToString
                    Me.txtafternoon.Text = ds.Tables(0).Rows(0).Item("hanoAir_Afternoon").ToString
                    'Me.chkCheckOrder.Checked = ds.Tables(0).Rows(0).Item("lockorder").ToString
                    ' glockorder = ds.Tables(0).Rows(0).Item("lockorder").ToString

                    'Me.cboservice.Text = ds.Tables(0).Rows(0).Item("OceanService").tostring
                    'Me.cboVessel.Text = FindIDValue(Me.cboVessel, ds.Tables(0).Rows(0).Item("SailingScheduleID").tostring)
                    Me.cboPORAir.Text = ds.Tables(0).Rows(0).Item("hanoAir_Placeofreceipt").ToString
                    Me.txtremarksAir.Text = ds.Tables(0).Rows(0).Item("remarksAir").ToString

                Catch ex As Exception

                End Try
            End If
            '----------------------
            '  QueryVessel()
            ' hien thi booking edi------------------------------------

            RefreshBookingEDI(mContainerOutboundNotifyId) '


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub



    Private Sub frmContainerOutBoundNotify_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region












    '    Public Function WeekOfYear() As Integer
    '        On Error GoTo Err_Renamed
    '        Dim myCI As New CultureInfo("en-US")
    '        Dim myCal As Calendar = myCI.Calendar
    '        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
    '        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
    '        If Me.dtpBookingDate.Value.ToString <> "" Then
    '            WeekOfYear = myCal.GetWeekOfYear(CDate(Me.dtpLeavingDate.Text), myCWR, myFirstDOW)
    '        Else
    '            WeekOfYear = 0
    '        End If
    '        Exit Function
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Function
    Public Sub themShipDoc()

    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            'ShowTab(Me.tabpageinformation, True)
            'ShowTab(Me.tabPageFCL, True)
            'ShowTab(Me.TabPagelcl, True)
            'ShowTab(Me.TabPageAir, True)



            Dim strQuery, strMesg As String
            Dim rs As New ADODB.Recordset
            Dim ShipID As String = DefaultValue
            Dim DocID As String = DefaultValue
            If Me.cboIOL.Text = "" Then
                DisplayMessage(True, "Please check Department.(In/Out/Log)!")
                Exit Sub
            End If

            strMesg = "Department : " & Me.cboIOL.Text + " ?"
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            Dim sql1 As String
            Dim ds1 As New DataSet

            sql1 = " select * from sale where salecode like N'" & Me.cbosale.Text & "'"
            ds1 = ReadDataSet(sql1)
            If ds1.Tables(0).Rows.Count = 0 Then
                DisplayMessage(True, "Please check Sale Man.!")
                Exit Sub
            End If


            If Me.txtBookingNo.Text = "" Then
                DisplayMessage(True, "Please check Booking No.!")
                Exit Sub
            End If
            If (mStatus = "Add") Then



                Try
                    ' them vao shipment profit/Documnt
                    ' them vao shipment
                    Try


                        '  .Fields("Customer_ID").Value = "{" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "}"

                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM quotation_sale "
                        'strQuery = strQuery & "WHERE quotationid = '" & mQuotationId & "'  "
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs
                            '  If rs.EOF Then
                            .AddNew()

                            ShipID = NewId()
                            .Fields("quotationid").Value = ShipID
                            .Fields("docid").Value = DocID
                            ' End If
                            'them service term

                            Try
                                .Fields("customer_id").Value = "{" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "}"
                            Catch ex As Exception
                                .Fields("customer_id").Value = DefaultValue
                            End Try

                            .Fields("bookingno").Value = Me.txtBookingNo.Text

                            If Me.cboIOL.Text = "Inbound" Then
                                .Fields("quotationNo").Value = gBranch + "S_I" + Me.txtBookingNo.Text.Replace("B", "")
                            End If
                            If Me.cboIOL.Text = "Outbound" Then
                                .Fields("quotationNo").Value = gBranch + "S_E" + Me.txtBookingNo.Text.Replace("B", "")
                            End If

                            If Me.cboIOL.Text = "Logistics" Then
                                .Fields("quotationNo").Value = gBranch + "S_L" + Me.txtBookingNo.Text.Replace("B", "")
                            End If

                            ' them branch
                            Try
                                .Fields("branch").Value = gBranch
                            Catch ex As Exception
                                DisplayMessage(True, "Branch cần được thêm vào Table Booking.")
                            End Try
                            '==============================================


                            '.Fields("Subject").Value = Me.txtsubject.Text
                            '.Fields("o1").Value = Me.txto1.Text
                            '.Fields("o2").Value = Me.txto2.Text
                            '.Fields("o3").Value = Me.txto3.Text
                            '.Fields("o4").Value = Me.txto4.Text


                            '.Fields("terms").Value = Me.txtterms.Text
                            '.Fields("validdate").Value = Me.txtvaliddate.Text


                            '.Fields("type").Value = Me.cboType.Text

                            Try
                                .Fields("pol").Value = Me.cbopol.Text
                            Catch ex As Exception

                            End Try


                            Try
                                .Fields("pod").Value = Me.cbopod.Text
                            Catch ex As Exception

                            End Try


                            '.Fields("transittime").Value = Me.txtTransittime.Text

                            '.Fields("transitport").Value = Me.cboTransitPort.Text
                            Try
                                .Fields("shippingline").Value = Me.cbocarrier.Text
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("salename").Value = Me.cbosale.Text
                            Catch ex As Exception

                            End Try



                            '.Fields("frequency").Value = Me.txtFrequency.Text

                            '.Fields("remarks").Value = Me.txtRemarks.Text


                            '.Fields("routing").Value = Me.txtroutingcode.Text
                            '.Fields("subject").Value = Me.txtxsitc.Text

                            '.Fields("mastercoloader").Value = Me.cbomastercoloader.Text




                            .Update()
                        End With
                        rs.Close()

                    Catch ex As Exception

                    End Try

                Catch ex As Exception

                End Try
            End If

            '-----------------------------------------
            Dim strContainerOutboundNotifyId, pName As String
            ' Dim rs As New ADODB.Recordset
            Dim i As Integer
            Dim index As Integer = -1
            ' kiem tra code thanh pho va code nuoc
            Dim taxcode(), kq1, kq11, kq22, kq2, KQ3, KQ4 As String

            kq11 = ""
            kq22 = ""



            ' 
            Dim sql As String
            Dim ds As New DataSet

            'sql = " select * from customer where company like N'%" & Me.cboCompany.Text.Trim & "%'"
            'ds = ReadDataSet(sql)
            'If ds.Tables(0).Rows.Count = 0 Then
            '    DisplayMessage(True, "Please check Company.!")
            '    Exit Sub
            'End If
            '' kiem tra sale
         

            '---------------------------------------------------
            If (mStatus = "Add" Or mStatus = "Edit" Or mStatus = "RV") Then
                If mStatus = "Edit" Or mStatus = "RV" Then
                    'CopyValues("ContainerOutboundNotify", "ContainerOutBoundNotifyId", mContainerOutboundNotifyId)
                End If
                strQuery = "SELECT * "
                strQuery = strQuery & "from ContainerOutboundNotify_sale "
                strQuery = strQuery & "WHERE ContainerOutBoundNotifyId = '" & mContainerOutboundNotifyId & "' AND ContainerOutBoundNotifyId <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If mStatus = "Add" Then
                        .AddNew()
                        .Fields("ContainerOutBoundNotifyId").Value = NewId()
                        mFilter = " And ContainerOutboundNotify.BookingNo='" & Me.txtBookingNo.Text.Trim & "'"
                        .Fields("quotationID").Value = ShipID
                        .Fields("docID").Value = DocID
                    End If

                    strContainerOutboundNotifyId = .Fields("ContainerOutBoundNotifyId").Value
                    mIDNEW = strContainerOutboundNotifyId
                    BookingId = strContainerOutboundNotifyId
                    ' them branch
                    Try
                        .Fields("branch").Value = gBranch
                    Catch ex As Exception
                        DisplayMessage(True, "Branch cần được thêm vào Table Booking.")
                    End Try
                    '==============================================


                    'Try
                    '    .Fields("mastercoloader").Value = Me.cbomastercoloader.Text
                    'Catch ex As Exception

                    'End Try
                    Try
                        .Fields("iol").Value = Me.cboIOL.Text
                    Catch ex As Exception

                    End Try







                    .Fields("bkcarrier").Value = Me.txtBKcarrier.Text



                    '-----------------------
                    If mStatus = "Add" Then
                        .Fields("BookingNo").Value = Me.txtBookingNo.Text '"W" + CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString


                    ElseIf mStatus = "Edit" Then
                        '   .Fields("BookingNo").Value = Me.txtBookingNo.Text
                    End If

                    .Fields("Customer_ID").Value = "{" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "}"
                    '.Fields("SailingScheduleID").Value = "{" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "}"

                    .Fields("ATTN").Value = Me.cboRepresentative.Text
                    '----------
                    .Fields("carrier").Value = Trim(Me.cbocarrier.Text)
                    .Fields("ETD").Value = Me.dtpetd.Value.Date
                    .Fields("ETA").Value = Me.dtpETA.Value.Date
                    .Fields("vessel").Value = Me.cboVessel.Text.Trim
                    .Fields("VOYNO").Value = Me.txtPreVoyNo.Text.Trim
                    .Fields("Sale_ID").Value = "{" & FindValueID(Me.cbosale, Me.cbosale.Text.Trim) & "}"
                    .Fields("SaleName").Value = Me.txtSaleName.Text.Trim
                    .Fields("SaleCode").Value = Me.cbosale.Text.Trim



                    ' .Fields("lichtau").Value = Me.cboVessel.Text.Trim + Me.txtPreVoyNo.Text.Trim + Me.dtpetd.Value.Date
                    .Fields("hano_delivery").Value = Me.txtdelivery.Text.Trim
                    .Fields("hano_Commodity").Value = Me.cboCommodity.Text.Trim
                    '---------------
                    .Fields("hano_from").Value = Me.cbofrom_hano.Text.Trim

                    .Fields("hano_date").Value = ddMMMyyyy(Me.dtphano_date.Value.Date)

                    .Fields("hano_Closing").Value = Me.txtclosingSIAFR.Text.Trim

                    .Fields("hano_Closingdelivery").Value = Me.txtClosingDelivery.Text.Trim

                    .Fields("hanoFCL_Quality").Value = Me.txtQuantity.Text.Trim

                    .Fields("hano_WeightCBMPKG").Value = Me.txtWCP.Text.Trim

                    .Fields("hano_POR").Value = Me.cboPOR.Text.Trim
                    Try
                        .Fields("hano_PORCode").Value = Me.cboPOR.Text.Trim.ToString.Split("-")(1)
                    Catch ex As Exception

                    End Try

                    .Fields("hano_POL").Value = Me.cbopol.Text.Trim
                    Try
                        .Fields("hano_POLCode").Value = Me.cbopol.Text.Trim.ToString.Split("-")(1)
                    Catch ex As Exception

                    End Try

                    .Fields("hano_POT").Value = Me.cbopot.Text.Trim
                    Try
                        .Fields("hano_POTCode").Value = Me.cbopot.Text.Trim.ToString.Split("-")(1)
                    Catch ex As Exception

                    End Try
                    .Fields("hano_POD").Value = Me.cbopod.Text.Trim
                    Try
                        .Fields("hano_PODCode").Value = Me.cbopod.Text.Trim.ToString.Split("-")(1)
                    Catch ex As Exception

                    End Try

                    .Fields("hanoAir_Placeofreceipt").Value = Me.cboPORAir.Text.Trim

                    .Fields("hano_Payment").Value = Me.txtpaymentTerm.Text.Trim

                    .Fields("hanoLCL_Consolidator").Value = "HANOTRANS"
                    .Fields("hanoLCL_CFSWH").Value = Me.txtCFSWH.Text.Trim
                    .Fields("hanoLCL_Add").Value = Me.txtAdd.Text.Trim
                    .Fields("hanoLCL_VNACCSCODE").Value = Me.txtVNACCSCODE.Text.Trim
                    .Fields("hanoLCL_WHPIC").Value = Me.txtwhpic.Text.Trim


                    .Fields("hanoLCL_BookingPIC").Value = Me.txtbookingPIC.Text.Trim

                    .Fields("hanoAir_AIRlines").Value = Me.txtAIRlines.Text.Trim

                    .Fields("hanoAir_AirportofDeparture").Value = Me.cboAirportofDeparture.Text.Trim
                    .Fields("hanoAir_AirportofDestination").Value = Me.cboAirportofdestination.Text.Trim

                    .Fields("hanoAir_ShipperConsignee").Value = Me.txtshipperConsignee.Text.Trim

                    .Fields("hanoAir_Descriptionofgoods").Value = Me.txtDescriptionofgoods.Text.Trim

                    .Fields("hanoAir_Freightrateterm").Value = Me.txtFreightrateterm.Text.Trim

                    .Fields("hanoAIr_MAWBHAWBNo").Value = Me.txtMAWBHAWB.Text.Trim
                    .Fields("hanoAir_RoutingVoyage").Value = Me.txtRoutingVoyage.Text.Trim

                    .Fields("hanoAIr_Flighttime").Value = Me.txtFlighttime.Text.Trim

                    .Fields("hanoAir_Cutoffdatetime").Value = Me.txtCutoffdatetime.Text.Trim
                    .Fields("hanoAir_Deliverycontactat").Value = Me.txtDeliverycontactat.Text.Trim
                    .Fields("hanoAir_Morning").Value = Me.txtmornning.Text.Trim

                    .Fields("hanoAir_Afternoon").Value = Me.txtafternoon.Text.Trim

                    .Fields("remarksFCL").Value = Me.txtRemarks.Text.Trim
                    .Fields("remarksLCL").Value = Me.txtRemarksLCL.Text.Trim
                    .Fields("remarksAir").Value = Me.txtremarksAir.Text.Trim
                    .Fields("FCL_LCL_Air").Value = Me.cboFLA.Text.Trim

                    '---------------------------------------
                    .Update()
                    DisplayMessage(True, "Saving is OK!")
                End With
                rs.Close()
                Me.dgdContianerOutboundNotify.Enabled = True
                If mFilter = "" Then

                End If
                If mStatus = "RV" Then
                    setEditable(mContainerOutboundNotifyId)
                    ' kiem tra xem booking nay co EDI hay ko
                    'checkBookingEDI(mIDOLD, mIDNEW)
                    'mFilter = " and BookingNo= '" + Me.txtBookingNo.Text + "' "
                End If

                If mStatus = "Edit" Or mStatus = "RV" Then
                    'mFilter = " and BookingNo= '" + Me.txtBookingNo.Text + "' "
                    'QueryContainerOutboundNotify(mFilter, , index)
                    Me.Button1_Click_1(sender, e)
                Else
                    Me.Button1_Click_1(sender, e)
                    ' QueryContainerOutboundNotify(mFilter, , index)
                End If
                Me.fraUpdate.Visible = False

                ReFormat()
                SetMenu((True))
                mStatus = "Normal"
                reText(mStatus)
                blnUpdated = True
                dtp = False
                'If Me.chkBookingOnlineInfo.Checked = True Then
                '    Dim temp As String
                '    temp = "Booking Đặt qua mạng của quý khách đã đựơc hoàn thành với số booking là :"
                '    temp &= Me.txtBookingNo.Text & " xin quý khách hãy kiểm tra lại trên trang web: http://www.cscl.com.vn/cscl.aspx "
                '    SendMail("Booking@cscl-vn.com", Me.txtBookingOnlineEmail.Text, "Booking Confirm infomation", temp)
                '    'cập nhật lại số booking trong booking online
                '    strQuery = "select * from BOOKINGONLINE Where BookingOnlineNo='" & Me.txtBookingOnlineNo.Text & "' And Continued=1"
                '    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                '    If Not rs.EOF Then
                '        rs.Fields("BookingNo").Value = Me.txtBookingNo.Text
                '        rs.Update()
                '    End If
                '    rs.Close()
                'End If
            End If
            ' monthlyBooking()
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Public Sub checkBookingEDI(ByVal IDOLD As String, ByVal IDNEW As String)
        Dim strQuery, strQueryA, strMesg As String
        Dim Edit As Boolean
        Dim rs, rsA As New ADODB.Recordset
        IDOLD = "{" + IDOLD + "}"
        IDNEW = "{" + IDNEW + "}"
        strQuery = "Select * from BookingEDI where" + " ContainerOutBoundNotifyId= '" & IDOLD & "' and continued=1 "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then ' neu co edi

            strMesg = "Do you want to copy EDI ?"
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryA = "Update bookingedi Set ContainerOutBoundNotifyId='" & mIDNEW & "' where Continued=1"
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim cmd As New SqlClient.SqlCommand(strQueryA, Conn)
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strQueryA
                cmd.ExecuteNonQuery()
                Conn.Close()
                Conn.Dispose()
                cmd.Dispose()
            End If
        End If
        rs.Close()
    End Sub
    Public Sub setEditable(ByVal ID As String)
        Dim strQueryContainerOutboundNotifyList As String
        Dim Edit As Boolean
        Dim rsEdit As New ADODB.Recordset
        ID = "{" + ID + "}"
        strQueryContainerOutboundNotifyList = "Select * from ContainerOutboundNotify_sale where" + " ContainerOutBoundNotifyId= '" & ID & "'"
        rsEdit.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Edit = Not rsEdit.Fields("Editable").Value
        rsEdit.Update("Editable", Edit)
        rsEdit.Close()
        '-------
        rsEdit.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        rsEdit.Update("BC", "RD")
        rsEdit.Close()
        '---------
        rsEdit.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Edit = Not rsEdit.Fields("Editable").Value
        rsEdit.Update("CONTINUED", 0)
        rsEdit.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdContianerOutboundNotify.Enabled = True

        dtp = False
        'ShowTab(Me.tabpageinformation, True)
        'ShowTab(Me.tabPageFCL, True)
        'ShowTab(Me.TabPagelcl, True)
        'ShowTab(Me.TabPageAir, True)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Public Sub queryBookingPerson()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "usr"
    '        value = "name"
    '        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
    '        strSQL = "Select usr,name From userlist where  disContinued=0 Order By usr desc"
    '        'If Me.cboCompany.Items.Count = 0 Then
    '        loadDataToObject(Me.cboBookingPerson, strSQL, id, value)
    '        'End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub






    Private Sub cboCompany_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedValueChanged
        On Error GoTo Err_named
        Dim CompanyID As String
        'If mStatus = "Edit" Then
        '    Return
        'End If
        CompanyID = FindValueID(Me.cboCompany, Me.cboCompany.Text)
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & CompanyID & "'", 14)
        If CompanyID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select * from Customer Where Customer_ID='" & CompanyID & "' And Continued=1 "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Bill")

            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                CustomerID = table.Rows(0).Item("Customer_ID").ToString
                QueryPresentative(CustomerID)
            End If
            'Me.txtBillOFLading_HouseId.Text = BillID
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub cboVessel_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboVessel.MouseDoubleClick
        On Error GoTo Err_named
        Dim Ves_ID As String
        'Ves_ID = FindValueID(Me.cboVessel, Me.cboVessel.Text)
        ''MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        '' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        'If Ves_ID <> "" Then
        '    Dim strQuery As String
        '    '-------------
        '    Dim Con As New SqlClient.SqlConnection(strconnDG)
        '    Dim dset As New DataSet
        '    Dim table As New DataTable
        '    '----------------
        '    strQuery = "Select VoyNo,ETD "
        '    strQuery &= "from SailingSchedule "
        '    strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

        '    Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        '    Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '    '-----------------

        '    'If Not IsNothing(oTable) Then
        '    '    oTable.Clear()
        '    'End If
        '    Adapter.Fill(dset, "Vessel")

        '    table = dset.Tables(0)
        '    If table.Rows.Count > 0 Then
        '        'Vessel_id = table.Rows(0).Item("SailingScheduleID").ToString
        '        Me.txtPreVoyNo.Text = table.Rows(0).Item("VoyNo").ToString
        '        Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString


        '    End If
        '    '  query stranship
        '    Dim sqlstranship, id, value As String
        '    id = "Port_Code"
        '    value = "Port"
        '    sqlstranship = "Select Port_Code,Port + '-' + Port_Code as Port From ETASchedule inner join Port on ETASchedule.PortID=Port.Port_ID where SailingScehduleID='" & Ves_ID & "' and ETASchedule.Continued=1 Order By Port desc"
        '    loadDataToObject(Me.cbotranship, sqlstranship, id, value)


        'End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Function CheckTranshipPort(ByVal SailingScheduleID As String, ByVal MotherSailingScheduleID As String) As Boolean
        Try
            Dim SQL As String
            If SailingScheduleID.ToString = "" Or MotherSailingScheduleID.ToString = "" Then
                DisplayMessage(True, "Please check Transite Port and POD of Mother again!")
                Return False
            End If
            SQL = "select PortID From ETASchedule "
            SQL &= "Where SailingScehduleID='" & SailingScheduleID & "' And Continued=1 "
            SQL &= " And PortID In  (Select PortID from MotherTranShip Where MotherSailingScheduleID='" & MotherSailingScheduleID & "' And Continued=1)"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                Return True
            End If
            DisplayMessage(True, "The Feeder Tranship ports invalid (with Mother Vessel),please check again!")
            Return False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedValueChanged
        '        On Error GoTo Err_named
        '        Dim Ves_ID As String
        '        If Me.cboVessel.Text = "" Then
        '            Return
        '        End If
        '        'GetCountContainerManagerment()
        '        Ves_ID = FindValueID(Me.cboVessel, Me.cboVessel.Text)
        '        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        '        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        '        If Ves_ID <> "" Then
        '            Dim strQuery As String
        '            '-------------
        '            Dim Con As New SqlClient.SqlConnection(strconnDG)
        '            Dim dset As New DataSet
        '            Dim table As New DataTable
        '            '----------------
        '            strQuery = "Select VoyNo,ETD,ETD-7 as NgayCapCont,Capacity,Slot "
        '            strQuery &= "from SailingSchedule "
        '            strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

        '            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        '            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '            '-----------------

        '            'If Not IsNothing(oTable) Then
        '            '    oTable.Clear()
        '            'End If
        '            Adapter.Fill(dset, "Vessel")

        '            table = dset.Tables(0)
        '            If table.Rows.Count > 0 Then
        '                'Vessel_id = table.Rows(0).Item("SailingScheduleID").ToString
        '                Me.txtPreVoyNo.Text = table.Rows(0).Item("VoyNo").ToString
        '                Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString
        '                'Me.dtplimitedbooking.Value = table.Rows(0).Item("limited").ToString
        '                Me.DTPNgayCapCont.Text = table.Rows(0).Item("Ngaycapcont").ToString
        '                Me.txtFeederCapacity.Text = table.Rows(0).Item("Capacity").ToString
        '                Me.txtFeederSlot.Text = table.Rows(0).Item("Slot").ToString
        '            End If
        '            '  query stranship
        '            Dim sqlstranship, id, value As String
        '            'id = "Port_Code"
        '            'value = "Port"
        '            'sqlstranship = "Select Port_Code,Port + '-' + Port_Code as Port From ETASchedule inner join Port on ETASchedule.PortID=Port.Port_ID where SailingScehduleID='" & Ves_ID & "' and ETASchedule.Continued=1 Order By Port desc"
        '            'loadDataToObject(Me.cbotranship, sqlstranship, id, value)

        '            'strQuery = "select mothersailingschedule.MotherSailingScheduleID,Vessel + '-' + MotherVesselNo as value "
        '            'strQuery &= " from  ((mothersailingschedule INNER JOIN MotherTranShip On MotherSailingSchedule.MotherSailingScheduleID=MotherTranShip.MotherSailingScheduleID)"
        '            'strQuery &= " INNER JOIN Vessel On Vessel.Vessel_ID=MotherVesseLID)"
        '            'strQuery &= " where MotherTranship.PortID In "
        '            'strQuery &= " (Select PortID From ETASchedule Where ETASchedule.Continued=1 And SailingScehduleID='" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "')"
        '            'strQuery &= " and MotherTranship.Continued=1"
        '            'loadDataToObject(Me.cboOceanVessel, strQuery, id, value)
        '        End If
        '        Exit Sub
        'Err_named:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cboOceanVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_named
    '        Dim Ves_ID As String

    '        Ves_ID = FindValueID(Me.cboVessel, Me.cboVessel.Text)
    '        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
    '        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
    '        If Ves_ID <> "" Then
    '            Dim strQuery As String
    '            '-------------
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Dim dset As New DataSet
    '            Dim table As New DataTable
    '            '----------------
    '            strQuery = "Select * from Vessel Where Vessel_ID='" & Ves_ID & "' And Continued=1 "

    '            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '            '-----------------

    '            'If Not IsNothing(oTable) Then
    '            '    oTable.Clear()
    '            'End If
    '            Adapter.Fill(dset, "Vessel")

    '            table = dset.Tables(0)

    '        End If
    '        Exit Sub
    'Err_named:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub smnuSupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSupply.Click
        On Error GoTo Err

        Dim index As Integer
        Dim chk As Integer
        chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If
        'If Me.dgdContianerOutboundNotify.Item("Editable", index).Value = 0 Then
        '    DisplayMessage(True, "This not the Final Edit Booking, You have to select the Final edit Booking")
        '    Return
        'End If
        gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        ' VB6.ShowForm(frmRptSupplyEmptyContainer, VB6.FormShowConstants.Modeless, Me)
        If UCase(Me.dgdContianerOutboundNotify.Item("fcl_lcl_air", index).Value.ToString) = "FCL" Then
            If LoginSucceeded = True Then
                Dim form As New frmRptSupplyEmptyContainer 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        End If
        If UCase(Me.dgdContianerOutboundNotify.Item("fcl_lcl_air", index).Value.ToString) = "LCL" Then
            If LoginSucceeded = True Then
                Dim form As New frmRptSupplyEmptyContainerLCL 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        End If


        If UCase(Me.dgdContianerOutboundNotify.Item("fcl_lcl_air", index).Value.ToString) = "AIR" Then
            If LoginSucceeded = True Then
                Dim form As New frmRptSupplyEmptyContainerAir 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        End If

        Exit Sub
Err:

    End Sub


    Private Sub mnuDataSupplyMTCntainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        Dim index As Integer
        If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If
        gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        VB6.ShowForm(frmRptDataSupplyContainerNotify, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
    End Sub

    Private Sub cbosale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.cbosale.Text = "" Then
                Return
            End If
            If Me.cbosale.SelectedIndex = -1 Then
                Return
            End If
            If FindValueID(Me.cbosale, Me.cbosale.Text.Trim) = "" Then
                MsgBox("Sale Này Không Có trong Cơ Sở Dữ Liệu")
            End If
            Dim SQL As String
            SQL = "select * from Sale Where Sale_ID='" & FindValueID(Me.cbosale, Me.cbosale.Text.Trim) & "'"
            Dim dt As New DataTable
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Adapter.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.txtSaleName.Text = dt.Rows(0).Item("SaleName").ToString
            Else

            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub mnuSupplyContainerOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        Dim index As Integer
        If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If
        ShowfraSplit()
        'Me.txtRemarksSplit.Text = Me.txtRemarks.Text
        'Me.txtNguoiDaiDienNhanConatiner.Text = Me.txtReceiptContainer.Text
        'Me.txtCMNDSplit.Text = Me.txtCMND.Text

        'Dim Place As String = Me.dgdContianerOutboundNotify.Item("SupplyOrderPlace", index).Value.ToString().Trim
        'If (UCase(gDepartment) = "BOOKING" And Place = "OFFICE") Or (UCase(gDepartment) = "TERMINAL" And Place = "TERMINAL") Then
        '    gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        '    Me.fraReportSplitBooking.Visible = True
        '    'VB6.ShowForm(frmSupplyContainerOrder, VB6.FormShowConstants.Modal, Me)
        'Else
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
        '    DisplayMessage(True, "The Supply Order is supplied by """ & Place & """")
        'End If
        Exit Sub
Err:
    End Sub

    Private Sub mnuSupplyContainerOderData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        Dim index As Integer
        If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If
        ShowfraSplit()
        'Me.txtRemarksSplit.Text = Me.txtRemarks.Text
        'Me.txtNguoiDaiDienNhanConatiner.Text = Me.txtReceiptContainer.Text
        'Me.txtCMNDSplit.Text = Me.txtCMND.Text

        'Dim Place As String = Me.dgdContianerOutboundNotify.Item("SupplyOrderPlace", index).Value.ToString().Trim
        'If (UCase(gDepartment) = "BOOKING" And Place = "OFFICE") Or (UCase(gDepartment) = "TERMINAL" And Place = "TERMINAL") Then
        '    gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
        '    'VB6.ShowForm(frmRptDataLenhCapContainer, VB6.FormShowConstants.Modal, Me)
        '    Me.fraReportSplitBooking.Visible = True
        'Else
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
        '    DisplayMessage(True, "The Supply Order is supplied by """ & Place & """")
        'End If
        Exit Sub
Err:
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click

    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdContianerOutboundNotify, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub









    Private Sub smnuComPany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuComPany.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboCompany.Name
            Dim frm As New frmListCustomer
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuTranship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuTranship.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cbopot.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortUploading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortUploading.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cbopod.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub cxtsmnuDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuDestination.Click
    '    Try
    '        gSForm = Me.Name
    '        gSCombo = Me.cboDestination.Name
    '        Dim frm As New frmListPort
    '        frm.ShowDialog(Me)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub dtpBookingDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            dtp = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ShowfraSplit()
        Try
            Dim index As Integer
            If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Else
                Exit Sub
            End If


            Me.txtRemarksSplit.Text = Me.dgdContianerOutboundNotify.Item("Remarks", index).Value.ToString
            Me.txtNguoiDaiDienNhanConatiner.Text = Me.dgdContianerOutboundNotify.Item("ReceiptContainer", index).Value.ToString
            'Me.txtCMNDSplit.Text = Me.dgdContianerOutboundNotify.Item("CMND", index).Value.ToString()
            Me.txtBookingCompany.Text = Me.dgdContianerOutboundNotify.Item("Company", index).Value.ToString()
            Me.txtCompanyOrder.Text = Me.txtBookingCompany.Text
            Me.txtBookingReceiptContainer.Text = Me.dgdContianerOutboundNotify.Item("ReceiptContainer", index).Value.ToString()
            Me.txtNguoiDaiDienNhanConatiner.Text = Me.txtBookingReceiptContainer.Text




            Dim Place As String = Me.dgdContianerOutboundNotify.Item("SupplyOrderPlace", index).Value.ToString().Trim


            Me.txtMainBookingNo.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString.Trim
            Me.txtSubBookingNo.Text = Me.txtMainBookingNo.Text
            gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString.Trim

            Dim strSQL As String
            strSQL = "select ReceiptContainer, CMND, "
            strSQL &= " GP20=CASE  WHEN SoLuong20GP > 0 THEN '20GP' END,"
            strSQL &= " GP40= CASE WHEN SoLuong40GP > 0 THEN '40GP' END,"
            strSQL &= " HC40=CASE  WHEN SoLuong40HC > 0 THEN '40HC' END,"
            strSQL &= " HC45= CASE WHEN SoLuong45HC > 0 THEN '45HC' END,"
            strSQL &= " RF20= CASE WHEN SoLuong20RF > 0 THEN '20RF' END,"
            strSQL &= " RF40=CASE  WHEN SoLuong40RF > 0 THEN '40RF' END,"
            strSQL &= " RH40= CASE WHEN SoLuong40RH > 0 THEN '40RH' END,"
            strSQL &= " SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong45HC,SoLuong20RF,SoLuong40RF,SoLuong40RH "
            strSQL &= " from ContainerOutboundNotify_sale "
            strSQL &= " Where BookingNo ='" & Me.txtMainBookingNo.Text & "' And Continued=1"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            If dt.Rows.Count > 0 Then


                Me.txtNguoiDaiDienNhanConatiner.Text = dt.Rows(0).Item("ReceiptContainer").ToString
                Me.txtCMNDSplit.Text = dt.Rows(0).Item("CMND").ToString
            End If
            ' hien thi thong tin nguoi nhan cont

            Me.fraReportSplitBooking.Visible = True
            Me.fraReportSplitBooking.BringToFront()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub mnuSplitSupplyContainerOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub





    Private Sub cmdOkSplitBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkSplitBooking.Click
        Try
            If Me.txtCMNDSplit.Text = "" Or Me.txttellenh.Text = "" Then
                DisplayMessage(True, "Please check again, the ID Card or Telephone is invalid!")
                Return
            End If


            gBookingNo = Me.txtSubBookingNo.Text
            If gBookingNo = "" Then
                If (MsgBox("Chưa Có Sub Booking No Có muốn nhập Sub Booking No không ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                    Return
                End If
            End If
            frmRptSubBooking.data = False
            frmRptSubBooking.ShowDialog()
            'Me.fraReportSplitBooking.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdOkData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkData.Click
        Try
            If Me.txtCMNDSplit.Text = "" Or Me.txttellenh.Text = "" Then
                DisplayMessage(True, "Please check again, the ID Card or Telephone is invalid!")
                Return
            End If


            gBookingNo = Me.txtSubBookingNo.Text
            If gBookingNo = "" Then
                If (MsgBox("Chưa Có Sub Booking No. .Bạn có muốn nhập Sub Booking No. không ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                    Return
                End If
            End If
            frmRptSubBooking.data = True
            frmRptSubBooking.ShowDialog()
            'Me.fraReportSplitBooking.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelSplitBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelSplitBooking.Click
        Me.fraReportSplitBooking.Visible = False

    End Sub

    Private Sub mnuBookingCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmBookingCancel.ShowDialog()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub



    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub dgdContianerOutboundNotify_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        For t = 0 To Me.dgdContianerOutboundNotify.RowCount - 1
            For s = 0 To Me.dgdContianerOutboundNotify.ColumnCount - 1
                If Me.dgdContianerOutboundNotify.Item(s, t).Value.ToString = "0" Then
                    Me.dgdContianerOutboundNotify.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub dgdContianerOutboundNotify_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

    End Sub

    Private Sub dgdContianerOutboundNotify_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs)
        Try

            Dim i As Integer
            i = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)

            If i = 1 Then
                Me.CopyToolStripMenuItem.Enabled = True
                Me.BookingReviceToolStripMenuItem.Enabled = True
                Me.DelayToolStripMenuItem.Enabled = True
            Else
                Me.CopyToolStripMenuItem.Enabled = False
                Me.DelayToolStripMenuItem.Enabled = True
                Me.BookingReviceToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancelCopyPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            RowCopy = Nothing

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub mnuRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRestore.Click
        Dim frm As New frmBookingRestore
        If UCase(gDepartment) = "MANAGEMENT" Then 'Or UCase(gDepartment) = "BOOKING"
            frm.Show()
        Else
            DisplayMessage(True, "Note: You are not permission, please contact your Admin.")
            'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            '    frm.Show()
            'End If
        End If
    End Sub



    Private Sub mnuViewBookingOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewBookingOnline.Click
        Try

            frmBookingOnline.Show()
            'Dim frm As New frmBookingOnline
            'frm.Show()
            'frm.Dispose()
            'frm = Nothing
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QuerySplitOrder()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strQuery As String
            strQuery = " select BookingNo,OrderNo,cOMPANY,DaiDien,tel,CMND,OrderDate,GetContainer,GetContainerDate,ExpireDate,Soluong20GP,Soluong40GP,Soluong20RF,Soluong40RF,Soluong40HC,Soluong45HC,Soluong40RH, "
            strQuery &= " Remarks,userid, updatetime From [Order] "
            strQuery &= " where BookingNo='" & Me.dgdContianerOutboundNotify.Item("BookingNo", Me.dgdContianerOutboundNotify.CurrentRow.Index).Value.ToString.Trim & "' And Continued=1"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdSplitContainer.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub fraReportSplitBooking_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraReportSplitBooking.VisibleChanged
        Try
            If Me.fraReportSplitBooking.Visible = True Then
                QuerySplitOrder()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub dgdSplitContainer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSplitContainer.CellClick
        Try
            Dim index As Integer
            If Me.dgdSplitContainer.RowCount = 0 Or IsNothing(Me.dgdSplitContainer.CurrentRow) Then
                Return
            End If
            index = Me.dgdSplitContainer.CurrentRow.Index
            Me.chkSave.Checked = True
            Me.txtCMNDSplit.Text = Me.dgdSplitContainer.Item("CMNDORDER", index).Value.ToString
            Me.txtNguoiDaiDienNhanConatiner.Text = Me.dgdSplitContainer.Item("Daidien", index).Value.ToString
            Me.txttellenh.Text = Me.dgdSplitContainer.Item("tel", index).Value.ToString
            Me.txtSubBookingNo.Text = Me.dgdSplitContainer.Item("OrderNoOrder", index).Value.ToString
            Me.txtRemarksSplit.Text = Me.dgdSplitContainer.Item("RemarksOrder", index).Value.ToString
            Me.dtpOrderDate.Value = Me.dgdSplitContainer.Item("OrderDate", index).Value
            Me.chkGetContainer.Checked = Me.dgdSplitContainer.Item("getContainer", index).Value
            If Me.dgdSplitContainer.Item("getContainerDATE", index).Value.ToString <> "" Then
                Me.dtpGetContainerDate.Value = Me.dgdSplitContainer.Item("getContainerDATE", index).Value
            End If




        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdSplitContainer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSplitContainer.CellContentClick

    End Sub

    'Private Sub lblFraSplitMove_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblFraSplitMove.MouseDown
    '    Me.fraSplitMDown = True
    '    x = e.X
    '    y = e.Y
    'End Sub

    'Private Sub lblFraSplitMove_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblFraSplitMove.MouseMove
    '    If fraSplitMDown = True Then
    '        Dim rect As New Drawing.Rectangle
    '        rect = Me.fraReportSplitBooking.ClientRectangle
    '    End If
    'End Sub

    'Private Sub lblFraSplitMove_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblFraSplitMove.MouseUp
    '    Me.fraSplitMDown = False
    'End Sub



    Private Sub mnuBooKingSupplyOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBooKingSupplyOrder.Click

    End Sub







    Private Sub dtpOrderDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOrderDate.ValueChanged
        Me.dtpExpireate.Value = Me.dtpOrderDate.Value.AddDays(2)
    End Sub



    Private Sub mnuBookingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Function getCusID() As String
        Dim strSQL As String
        strSQL = "select count (*) as ID from ContainerOutboundNotify_sale "
        Dim dtSer As New DataTable
        dtSer = ReadTable(strSQL)
        Return CInt(dtSer.Rows(0).Item(0).ToString) + 1


    End Function
    Private Sub smnuNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuNew.Click


    End Sub
    Public Sub ClsBookingEDI()
        'Me.txtBookingOtherRef.Text = ""
        'Me.cboShipperRefNo.Text = ""
        'Me.txtBLNo.Text = ""
        'Me.txtPO.Text = ""
        'Me.cboVIPCode.Text = ""
        'Me.txtCargoDescription.Text = ""
        'Me.txtCommodityEDI.Text = ""

        'Me.txtShipperName.Text = ""
        'Me.txtConsigneeName.Text = ""
        'Me.txtNotifyName.Text = ""
        'Me.cboBookingstatus.Text = ""
        'Me.txtBookingOffice.Text = ""
        'Me.txtBookingArea.Text = ""
        'Me.txtUserID.Text = ""

    End Sub
    Private Sub smnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerOutboundNotify("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCancel.Click
        'Dim chk As Integer
        'chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        'If chk = 0 Then
        '    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
        '    Return
        'End If
        'Wait = 0
        ''If checkSupply() = True And checkSupplyContainer() = True Then
        ''    MsgBox("Note : This Booking Already Supplied Order and Container !")
        ''    Wait = 1
        ''End If

        ''If checkSupply() = True And checkSupplyContainer() = False Then
        ''    MsgBox("Note : This Booking Already Supplied Order !")
        ''    'Return
        ''End If

        'If Me.dgdContianerOutboundNotify.RowCount = 0 Then
        '    Return
        'End If

        'Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        'If index < 0 Then
        '    Return
        'End If


        If Me.dgdContianerOutboundNotify.Rows.Count = 0 Then
            Return
        End If


        Dim selectedRowCount As Integer = _
             Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdContianerOutboundNotify.SelectedRows(i).Index)
            Next i
        End If

    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi





        'che tam vi chua co quan he voi Dulieu khac

        If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Approve", index)) Then
            If Me.dgdContianerOutboundNotify.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        'If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Editable", index)) Then
        '    If Not Me.dgdContianerOutboundNotify.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnuCustomerService", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Booking No.: " & Me.dgdContianerOutboundNotify.Item("bookingno", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from ContainerOutboundNotify_sale where ContainerOutboundNotifyID= '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub BookingReviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookingReviceToolStripMenuItem.Click
        Try


            Dim i As Integer = 0
            i = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If i = 1 Then
                Dim index As Integer = Me.dgdContianerOutboundNotify.SelectedRows(0).Index
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim strSQL As String
                mIDOLD = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString.Trim
                strSQL = "Select * from ContainerOutboundNotify_sale "
                strSQL &= " Where ContainerOutboundNotifyID='" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString.Trim & "'"
                strSQL &= " And Continued=1"
                Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
                Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
                Dim dt As New DataTable
                Adapter.Fill(dt)
                If dt.Rows.Count > 0 Then
                    RowCopy = dt.Rows(0)
                End If

            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ChangeDetailToolStripMenuItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ChangeDetailToolStripMenuItem.Click
        On Error GoTo Err_Renamed

        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        Dim chk As Integer
        chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        EnableControl(False)

        ' thêm 07-12-2007 thông báo chỉ dc xem đối với những booking đã cấp lệnh

        If checkDoBill() = True Then
            DisplayMessage(True, "Please contact with Outbound dept.")
            'Return
        End If
        If Me.dgdContianerOutboundNotify.SelectedRows.Count = 0 Then
            Return
        End If
        'If CheckEdit() = False Then
        '    Return
        'End If
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
            EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value
            If EditTable = False Then
                DisplayMessage(True, "This Booking is not editing!.")
                Return
            End If
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnuCustomerService", "Edit") And Not Me.dgdContianerOutboundNotify.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdContianerOutboundNotify.Height = 306
                Me.dgdContianerOutboundNotify.Enabled = False
                'Me.txtBookingNo.Enabled = False


                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString

                '---- edit ghi lai trang thai edit
                'mStatus = "Add"
                mStatus = "RV"
                reText(mStatus)
                Me.cboCompany_SelectedValueChanged(eventSender, eventArgs)
                RefreshData(index)
                '07-12-2007 bookingdate lấy ngày server


                dtp = True
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub mnuReportdaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoginSucceeded Then
            VB6.ShowForm(frmRptBooking, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub mnuReportManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BookingSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DailyOutboundBookingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub EnableControl(ByVal Value As Boolean)
        Try
            Dim ctr As Control
            'For Each ctr In Me.tbcCongTy.Controls
            '    ctr.Enabled = Value
            'Next
            'For Each ctr In Me.tbcContainer.Controls
            '    ctr.Enabled = Value
            'Next
            'For Each ctr In Me.tbcGhiChu.Controls
            '    ctr.Enabled = Value
            'Next
            'Me.txtBookingNo.Enabled = True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtBookingNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookingNo.Leave
        Dim temp As String
        CloseZoom(Me.txtBookingNo)
        temp = Me.txtBookingNo.Text.Trim
        If temp Like "*R" Then
            temp = temp.Substring(0, temp.Length - 2)
        End If
        If temp Like "*R?" Then
            temp = temp.Substring(0, temp.Length - 3)
        End If
        'Me.txtBLNo.Text = temp
    End Sub

    Private Sub txtBookingNo_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBookingNo.MouseDoubleClick
        OpenZoom(Me.txtBookingNo)
    End Sub

    Private Sub txtBookingNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookingNo.TextChanged
        Try
            If mStatus = "Add" Or mStatus = "Normal" Then
                Return
            End If
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            If UCase(Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString) = UCase(Me.txtBookingNo.Text) Then
                EnableControl(False)
            Else
                EnableControl(True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboEmptyContainerPlace_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'GetCountContainerManagerment()
    End Sub





    Private Sub DelayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelayToolStripMenuItem.Click
        Try
            Try
                Dim url As String = "https://youtu.be/iOfpmi48o-Q"

                Process.Start(url)
            Catch ex As Exception

            End Try
            'QueryNextVessel()
            'Me.grpDelayBooking.SendToBack()
            'Me.grpDelayBooking.BringToFront()

            'Me.grpDelayBooking.Visible = True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Function checkSupplyContainer() As Boolean
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim index As Integer
        If mStatus = "Add" Then
            checkSupplyContainer = False
        Else
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return False
            End If
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            If index < 0 Then
                Return False
            End If
            strQuery = "Select * from LOADINGPLANFORVESSEL WHERE ContainerOutBoundNotifyID = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString.Trim & "' and continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                rs.Close()
                Return False
            Else
                rs.Close()
                Return True
            End If

        End If
    End Function
    Function checkSupply() As Boolean
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim index As Integer
        If mStatus = "Add" Then
            checkSupply = False
        Else
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return False
            End If
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            If index < 0 Then
                Return False
            End If
            strQuery = "Select Orderno from [Order] WHERE bookingno = '" & Me.dgdContianerOutboundNotify.Item("Bookingno", index).Value.ToString.Trim & "' and continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                rs.Close()
                Return False
            Else
                rs.Close()
                Return True
            End If

        End If
    End Function

    Function checkDoBill() As Boolean
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim index As Integer
        If mStatus = "Add" Then
            checkDoBill = False
        Else
            If Me.dgdContianerOutboundNotify.RowCount = 0 Then
                Return False
            End If
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            If index < 0 Then
                Return False
            End If
            strQuery = "Select ContainerOutBoundNotifyId from [billoflading] WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString.Trim & "' and continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                rs.Close()
                Return False
            Else
                rs.Close()
                Return True
            End If

        End If
    End Function


    Private Sub cmdOkDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Or IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) Then
                Return
            End If
            Dim i As Integer
            i = Me.dgdContianerOutboundNotify.CurrentRow.Index

            Dim rs As New ADODB.Recordset
            Dim Temprs As New ADODB.Recordset
            Dim strQuery As String
            strQuery = "SELECT  * "
            strQuery = strQuery & "from ContainerOutboundNotify_sale "
            strQuery = strQuery & "WHERE  ContainerOutBoundNotifyID= '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", i).Value.ToString & "' And Continued=1"



            Temprs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            'strQuery = "SELECT  * "
            'strQuery = strQuery & "from ContainerOutboundNotify_sale "
            'strQuery = strQuery & "WHERE  ContainerOutBoundNotifyID= '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", i).Value.ToString & "' "


            strQuery = "select Top 1 * from ContainerOutboundNotify_sale"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not Temprs.EOF Then
                With rs
                    .AddNew()
                    .Fields("ContainerOutboundNotifyID").Value = NewId()
                    '---------------
                    .Fields("BookingNo").Value = Temprs.Fields("BookingNo").Value

                    .Fields("Customer_ID").Value = Temprs.Fields("Customer_ID").Value

                    '.Fields("OceanVessel_Id").Value = "{" & FindValueID(Me.cboOceanVessel, Me.cboOceanVessel.Text) & "}"

                    .Fields("Sale_ID").Value = Temprs.Fields("Sale_ID").Value
                    .Fields("SaleName").Value = Temprs.Fields("SaleName").Value
                    .Fields("SaleCode").Value = Temprs.Fields("SaleCode").Value

                    .Fields("Representative").Value = Temprs.Fields("Representative").Value

                    .Fields("ReceiptContainer").Value = Temprs.Fields("ReceiptContainer").Value



                    .Fields("ServiceContract").Value = Temprs.Fields("ServiceContract").Value
                    'If Temprs.Fields("Market_ID").Value.ToString.Trim <> "" Then
                    .Fields("Market_ID").Value = Temprs.Fields("Market_ID").Value
                    'End If

                    .Fields("Cold").Value = Temprs.Fields("Cold").Value
                    .Fields("CustomsLiquiDate").Value = Temprs.Fields("CustomsLiquiDate").Value
                    .Fields("PackingWay").Value = Temprs.Fields("PackingWay").Value

                    .Fields("SoLuong20GP").Value = Temprs.Fields("SoLuong20GP").Value
                    .Fields("SoLuong40GP").Value = Temprs.Fields("SoLuong40GP").Value
                    .Fields("SoLuong40HC").Value = Temprs.Fields("SoLuong40HC").Value
                    .Fields("SoLuong45HC").Value = Temprs.Fields("SoLuong45HC").Value
                    .Fields("SoLuong20RF").Value = Temprs.Fields("SoLuong20RF").Value
                    .Fields("SoLuong40RF").Value = Temprs.Fields("SoLuong40RF").Value
                    .Fields("SoLuong40RH").Value = Temprs.Fields("SoLuong40RH").Value

                    .Fields("W20GP").Value = Temprs.Fields("W20GP").Value
                    .Fields("W40GP").Value = Temprs.Fields("W40GP").Value
                    .Fields("W40HC").Value = Temprs.Fields("W40HC").Value
                    .Fields("W45HC").Value = Temprs.Fields("W45HC").Value
                    .Fields("W20RF").Value = Temprs.Fields("W20RF").Value
                    .Fields("W40RF").Value = Temprs.Fields("W40RF").Value
                    .Fields("W40RH").Value = Temprs.Fields("W40RH").Value
                    'SpencialEquipment
                    .Fields("SpencialEquipment").Value = Temprs.Fields("SpencialEquipment").Value
                    .Fields("Commondity").Value = Temprs.Fields("Commondity").Value

                    .Fields("Tranship").Value = Temprs.Fields("Tranship").Value
                    .Fields("LeavingDate").Value = Temprs.Fields("LeavingDate").Value

                    .Fields("PortOfUnLoading").Value = Temprs.Fields("PortOfUnLoading").Value
                    .Fields("Destination").Value = Temprs.Fields("Destination").Value

                    .Fields("BookingPerson").Value = Temprs.Fields("BookingPerson").Value
                    .Fields("BookingDate").Value = Temprs.Fields("LeavingDate").Value
                    .Fields("WeekOfYear").Value = Temprs.Fields("WeekOfYear").Value

                    .Fields("Ventilation").Value = Temprs.Fields("Ventilation").Value
                    .Fields("EmptyContainerPlace").Value = Temprs.Fields("EmptyContainerPlace").Value
                    .Fields("Ngaycapcont").Value = Temprs.Fields("Ngaycapcont").Value

                    .Fields("FullReturnContainerPlace").Value = Temprs.Fields("FullReturnContainerPlace").Value

                    .Fields("Remarks").Value = Temprs.Fields("Remarks").Value
                    .Fields("MaxWMainPort").Value = Temprs.Fields("MaxWMainPort").Value
                    .Fields("MaxWLocal").Value = Temprs.Fields("MaxWLocal").Value
                    .Fields("ContactUs").Value = Temprs.Fields("ContactUs").Value

                    ' them moi
                    .Fields("ServiceFeeder").Value = Temprs.Fields("ServiceFeeder").Value
                    .Fields("LocalCargo").Value = Temprs.Fields("LocalCargo").Value
                    .Fields("EmptyMoving").Value = Temprs.Fields("EmptyMoving").Value

                    .Fields("TransiteCargo").Value = Temprs.Fields("TransiteCargo").Value

                    .Fields("SOC").Value = Temprs.Fields("SOC").Value
                    .Fields("SlotExchange").Value = Temprs.Fields("SlotExchange").Value
                    .Fields("FOBCargo").Value = Temprs.Fields("FOBCargo").Value
                    .Fields("PaymentTerm").Value = Temprs.Fields("PaymentTerm").Value

                    If Temprs.Fields("FirstSendDate").Value.ToString.Length > 0 Then
                        .Fields("FirstSendDate").Value = Temprs.Fields("FirstSendDate").Value
                    Else
                        .Fields("FirstSendDate").Value = Nothing
                    End If

                    If Temprs.Fields("SecondSendDate").Value.ToString.Length > 0 Then
                        .Fields("SecondSendDate").Value = Temprs.Fields("SecondSendDate").Value
                    Else
                        .Fields("SecondSendDate").Value = Nothing
                    End If

                    If Temprs.Fields("ThirdSendDate").Value.ToString.Length > 0 Then
                        .Fields("ThirdSendDate").Value = Temprs.Fields("ThirdSendDate").Value
                    Else
                        .Fields("ThirdSendDate").Value = Nothing
                    End If
                    .Fields("SupplyOrderPlace").Value = Temprs.Fields("SupplyOrderPlace").Value


                    .Fields("Gio1").Value = Temprs.Fields("Gio1").Value
                    .Fields("Gio2").Value = Temprs.Fields("Gio2").Value
                    .Fields("AMPM1").Value = Temprs.Fields("AMPM1").Value
                    .Fields("AMPM2").Value = Temprs.Fields("AMPM2").Value
                    .Fields("DateClosing1").Value = Temprs.Fields("DateClosing1").Value
                    .Fields("DateClosing2").Value = Temprs.Fields("DateClosing2").Value
                    .Fields("GioBD").Value = Temprs.Fields("GioBD").Value
                    .Fields("AMPMBD").Value = Temprs.Fields("AMPMBD").Value
                    .Fields("BD").Value = Temprs.Fields("BD").Value

                    .Fields("TruckCompany").Value = Temprs.Fields("TruckCompany").Value
                    .Fields("PortOfLoading").Value = Temprs.Fields("PortOfLoading").Value
                    .Fields("limitedBooking").Value = Temprs.Fields("limitedBooking").Value

                    .Fields("BC").Value = "OK"

                    '---------------
                    .Update()
                End With
                Temprs.Close()
                rs.Close()
                strQuery = "SELECT  * "
                strQuery = strQuery & "from ContainerOutboundNotify_sale "
                strQuery = strQuery & "WHERE  ContainerOutBoundNotifyID= '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", i).Value.ToString & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    'RowCopy = rs.GetRows(0)
                    rs.Fields("BC").Value = "CL"
                    rs.Fields("Continued").Value = 0
                    rs.Fields("Delay").Value = 1
                    rs.Update()


                End If
                rs.Close()
            End If
            'Me.fraCopyPaste.Visible = False

            'Revised(Me.dgdContianerOutboundNotify.CurrentRow.Index)
            QueryContainerOutboundNotify(mFilter)
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub



    Private Sub mnuReportBookingSummaryFeeder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReportBookingSummary
        If UCase(gDepartment) = "MANAGEMENT" Then
            frm.Show()
        Else
            DisplayMessage(True, "Invalid!")

        End If
    End Sub

    Private Sub mnuDailyBookingReportFeeder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReportDailyBookingReport
        If UCase(gDepartment) = "MANAGEMENT" Then
            frm.Show()
        Else
            DisplayMessage(True, "Invalid!")
        End If
    End Sub

    Private Sub mnuReportBookingSummaryMother_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReportBookingSummary_Mother
        If UCase(gDepartment) = "MANAGEMENT" Then
            frm.Show()
        Else
            DisplayMessage(True, "Invalid!")

        End If
    End Sub

    Private Sub mnuDailyBookingReportMother_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReportDailyBookingReport_Mother
        If UCase(gDepartment) = "MANAGEMENT" Then
            frm.Show()
        Else
            DisplayMessage(True, "Invalid!")
        End If
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed

        Dim chk As Integer
        chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        'Me.chkDalayLenh.Checked = checkSupply()
        'thêm 07-12-2007 thông báo chỉ dc xem đối với những booking đã cấp lệnh
        'If Me.chkDalayLenh.Checked = True Then
        '    If MsgBox("This Booking was supplied Order, you can view only") = MsgBoxResult.Cancel Then
        '        Return
        '    End If
        'End If
        'If checkSupply() = True And checkSupplyContainer() = True Then
        '    MsgBox("This Booking Already Supplied Order and Container !")

        'End If
        'If checkSupply() = True And checkSupplyContainer() = False Then
        '    MsgBox("This Booking Already Supplied Order !")
        '    'Return
        'End If
        'If checkDoBill() = True Then
        '    DisplayMessage(True, "Please contact with Outbound dept.")
        '    'Return
        'End If
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
            index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            'QueryRouting(index)

            Approve = Me.dgdContianerOutboundNotify.Item("Approve", index).Value
            EditTable = Me.dgdContianerOutboundNotify.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnuCustomerService", "Edit") Then
                ' kiem tra cho edit hay khong
                If UCase(gDepartment) = "MANAGEMENT" Then

                Else
                    If Me.dgdContianerOutboundNotify.Item("UserId", index).Value.ToString.Trim = strUserId Then
                    Else
                        DisplayMessage(True, "Sorry, Bạn không có quyền edit.! ")
                        Exit Sub
                    End If
                End If

                If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                    index = Me.dgdContianerOutboundNotify.CurrentRow.Index
                End If
                mContainerOutboundNotifyId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString.Trim
                Me.cmdOK.Enabled = True
                mStatus = "Edit"
                Me.fraUpdate.Visible = True
                Me.dgdContianerOutboundNotify.Enabled = True
                ReFormat()
                SetMenu((False))
                Me.smnuPrint.Enabled = True
                RefreshData(index)
                'reText(mStatus)
                If Me.dgdContianerOutboundNotify.Item("fcl_lcl_air", index).Value.ToString.Trim = "FCL" Then
                    Dim ctr As Control
                    For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                        ctr.Visible = True
                    Next

                    For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                        ctr.Visible = False
                    Next
                    For Each ctr In Me.TabPageAir.Controls ' DEBIT
                        ctr.Visible = False
                    Next
                End If

                If Me.dgdContianerOutboundNotify.Item("fcl_lcl_air", index).Value.ToString.Trim = "LCL" Then
                    Dim ctr As Control
                    For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                        ctr.Visible = False
                    Next

                    For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                        ctr.Visible = True
                    Next
                    For Each ctr In Me.TabPageAir.Controls ' DEBIT
                        ctr.Visible = False
                    Next
                End If

                If UCase(Me.dgdContianerOutboundNotify.Item("fcl_lcl_air", index).Value.ToString.Trim) = "AIR" Then
                    Dim ctr As Control
                    For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                        ctr.Visible = False
                    Next

                    For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                        ctr.Visible = False
                    Next
                    For Each ctr In Me.TabPageAir.Controls ' DEBIT
                        ctr.Visible = True
                    Next
                End If



                ' EnableControl(True)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub




    Private Sub dtpLeavingDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpetd.Leave
        Try
            'Dim strSQL As String
            'strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            'strSQL &= " From SailingSchedule,vessel "
            'strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "'"
            'strSQL &= "Order By Vessel_Code desc"
            'Dim dt As New DataTable
            'dt = ReadTable(strSQL)
            'If dt.Rows.Count > 0 Then
            '    Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            '    QueryVesselEdit()
            'Else
            '    MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
            '    Return
            'End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpetd.ValueChanged

    End Sub



    Private Sub cmdBookingCancelLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        If index < 0 Then
            Return
        End If
        DeleteRow(index)
        Me.Button1_Click_1(sender, e)
        '  Me.QueryContainerOutboundNotify(mFilter)
    End Sub

    Private Sub tbcCongTy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabpageinformation.Click

    End Sub



    Private Sub BookingDailyReport1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDailyBookingReport1.Show()
    End Sub






    Private Sub mnuBookingDailyReportMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDailyBookingReport2.Show()
    End Sub

    Private Sub BookingSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBookingSummaryExcel.Show()
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        Try
            QueryPresentative(FindValueID(Me.cboCompany, Me.cboCompany.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fraUpdate_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fraUpdate.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.cmdCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuRefesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuRefesh.Click
        QueryCustomer()
        QueryCommondity()

        QueryVessel()
        QueryContainerOutboundNotify(mFilter)
        QuerySale()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        If Me.dgdContianerOutboundNotify.RowCount = 1 Then
            Return
        End If
        Me.grpCopyBooking.BringToFront()
        Me.grpCopyBooking.Visible = True
        Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
        Me.txtBookingNoOld.Text = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value
    End Sub
    Private Sub cmdCancelCopyBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelcopybooking.Click
        Me.grpCopyBooking.Visible = False
    End Sub
    Function CheckCopyBooking(ByVal BookingNo As String) As Boolean
        Try
            Dim SQL As String
            SQL = "select Count(*) from ContainerOutboundNotify_sale Where BookingNo='" & BookingNo & "' And Continued=1 and Editable=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0) > 0 Then
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    'Private Sub cmdCheckcopyBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckcopyBooking.Click
    '    Try
    '        If CheckCopyBooking(Me.txtBookingNoNew.Text) = False Then
    '            MsgBox("The new booking No is Invalid or already in database, Input another please")
    '            Return
    '        Else
    '            MsgBox("This Booking Is Valid")
    '        End If
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub
    Function CopyBooking(ByVal OldBookingID As String) As Boolean
        Try
            Dim INDEX As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Dim SQL As String


            SQL = "select * from ContainerOutboundNotify_sale Where ContainerOutboundNotifyID= '" & OldBookingID & "' And Continued=1 "

            Dim rsold As New ADODB.Recordset
            rsold.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rsold.EOF Then
                Return False
            End If

            Dim rs As New ADODB.Recordset
            SQL = "select Top 1 * from ContainerOutboundNotify_sale"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.AddNew()
            rs.Fields("ContainerOutBoundNotifyId").Value = NewId()
            rs.Fields("BookingNo").Value = Me.txtBookingNoNew.Text
            For i As Integer = 0 To rs.Fields.Count - 1
                If UCase(rs.Fields(i).Name) = "CONTAINEROUTBOUNDNOTIFYID" Or UCase(rs.Fields(i).Name) = "BOOKINGNO" Then
                    Continue For
                End If
                With rs
                    .Fields(i).Value = rsold.Fields(i).Value
                End With
            Next
            rs.Update()
            rs.Close()

            rsold.Close()
            mFilter = " and bookingno= '" + Me.txtBookingNoNew.Text + "' "
            QueryContainerOutboundNotify(mFilter)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)

        End Try
    End Function
    Private Sub cmdOkCopyBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkCopyBooking.Click
        Try
            If CheckCopyBooking(Me.txtBookingNoNew.Text) = False Then
                MsgBox("The new booking No is Invalid or already in database, Input another please")
                Return
            End If
            Dim i As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            CopyBooking(Me.dgdContianerOutboundNotify.Item("ContainerOutboundNotifyID", i).Value.ToString)
            Me.grpCopyBooking.Visible = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)


        End Try
    End Sub

    Private Sub smnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuPrint.Click
    End Sub

    Private Sub cmdGetBookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.txtBookingNo.Text = GetBookingNumberFromDB() 'lấy booking No tring BookingNumber ra

            '
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdGetBLNoCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetBLNoCopy.Click
        Me.txtBookingNoNew.Text = CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString
    End Sub

    Private Sub RealMTContToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RealMTContToolStripMenuItem.Click
        Dim frm As New frmRealMTContainer

        frm.Show()

    End Sub

    Private Sub mnuRealContainerVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRealContainerVessel.Click
        Dim frm As New frmBookingVessel
        frm.Show()

    End Sub




    Private Sub GetBLNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetBLNoToolStripMenuItem.Click
        Try

            Dim TempBookingNo As TextBox
            'If Me.txtBookingRestoreNewo.Focused = True Then
            '    TempBookingNo = Me.txtBookingRestoreNewo
            'End If

            If TempBookingNo Is Nothing Then
                MsgBox("You Have to Focus The New booking No. Text box")
                Return
            End If
            TempBookingNo.Text &= GetBookingNumberFromDB()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub BookingDailyListOfContainersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDailyBookingReport1.Show()
    End Sub

    Private Sub BookingMarketDailyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDailyBookingReport2.Show()
    End Sub

    Private Sub BookingSummaryWeekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBookingSummaryExcel.Show()
    End Sub



    Private Sub txtServiceContract_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub








































#Region "zoom"
    'Private Sub txtW20GP_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW20GP)
    'End Sub

    'Private Sub txtW20GP_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW20GP, 12, 50, 40)
    'End Sub

    'Private Sub txtW40GP_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW40GP)
    'End Sub

    'Private Sub txtW40GP_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW40GP, 12, 50, 40)
    'End Sub

    'Private Sub txtW40HC_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW40HC)
    'End Sub

    'Private Sub txtW40HC_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW40HC, 12, 50, 40)
    'End Sub

    'Private Sub txtW45HC_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW45HC)
    'End Sub

    'Private Sub txtW45HC_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW45HC, 12, 50, 40)
    'End Sub

    'Private Sub txtW20RF_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW20RF)
    'End Sub

    'Private Sub txtW20RF_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW20RF, 12, 50, 40)
    'End Sub

    'Private Sub txtW40RF_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW40RF)
    'End Sub

    'Private Sub txtW40RF_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW40RF, 12, 50, 40)
    'End Sub

    'Private Sub txtW40RH_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CloseZoom(Me.txtW40RH)
    'End Sub

    'Private Sub txtW40RH_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    OpenZoom(Me.txtW40RH, 12, 50, 40)
    'End Sub

    'Private Sub txtMWL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMWL.Leave
    '    CloseZoom(Me.txtMWL)
    'End Sub

    'Private Sub txtMWL_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMWL.MouseDoubleClick
    '    OpenZoom(Me.txtMWL, 12, 195, 40)
    'End Sub

    'Private Sub txtMWMP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMWMP.Leave
    '    CloseZoom(Me.txtMWMP)
    'End Sub

    'Private Sub txtMWMP_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMWMP.MouseDoubleClick
    '    OpenZoom(Me.txtMWMP, 12, 195, 40)
    'End Sub

    'Private Sub txtSpecialRemarks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpecialRemarks.Leave
    '    CloseZoom(Me.txtSpecialRemarks)
    'End Sub

    'Private Sub txtSpecialRemarks_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpecialRemarks.MouseDoubleClick
    '    OpenZoom(Me.txtSpecialRemarks, 12)
    'End Sub

    'Private Sub txtPaymentTerm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaymentTerm.Leave
    '    CloseZoom(Me.txtPaymentTerm)
    'End Sub

    'Private Sub txtPaymentTerm_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPaymentTerm.MouseDown
    '    OpenZoom(Me.txtPaymentTerm, 12)
    'End Sub
#End Region
    Private Sub smnureportgraphbooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmGraphBooking, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ChartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmCharting, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub fraUpdate_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged

    End Sub

    Private Sub mnubookingwaiting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmBookingWaiting, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CancelContainerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelContainerToolStripMenuItem.Click
        Try
            If Me.dgdContianerOutboundNotify.RowCount = 0 Or IsNothing(Me.dgdContianerOutboundNotify.CurrentRow) Then
                Return
            End If
            Dim i As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            frmCancelBookingContainer.BookingId = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", i).Value.ToString
            frmCancelBookingContainer.WaitBookingNo = Me.dgdContianerOutboundNotify.Item("BookingNo", i).Value.ToString
            frmCancelBookingContainer.ShowDialog(Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub mnuBookingSummaryWeekChina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmBookingSummaryExcel_Customize, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    'Private Sub chkCheckOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Not UserRight("mnuCustomerService", "Approve") Then
    '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '    ElseIf Me.chkCheckOrder.Checked = True Then
    '        glockorder = 1
    '    Else
    '        glockorder = 0
    '    End If
    'End Sub


    Private Sub mnuReportbookingUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmbookingEWDailyReport, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BookingSummaryMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBookingSummaryExcelMonth.Show()
    End Sub
    Private Sub cbotranship_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbopot.SelectedIndexChanged

    End Sub

    Private Sub cmdBookingEDIOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' lay booking ID , sau do them vao booking edi
        '        On Error GoTo Err_Renamed
        '        Dim strQuery, strContainerOutboundNotifyId, pName As String
        '        Dim rs As New ADODB.Recordset
        '        '
        '        If mContainerOutboundNotifyId = DefaultValue Or mContainerOutboundNotifyId = "" Then
        '            mContainerOutboundNotifyId = BookingId
        '        End If

        '        If mContainerOutboundNotifyId = DefaultValue Or mContainerOutboundNotifyId = "" Then
        '            DisplayMessage(True, "Booking is not OK!, Have to click OK button ! ")
        '            Return
        '        End If
        '        If mContainerOutboundNotifyId Like "{*" Or mContainerOutboundNotifyId Like "*}" Then
        '        Else

        '            mContainerOutboundNotifyId = "{" + mContainerOutboundNotifyId + "}"
        '        End If
        '        If CheckDataEDI() Then
        '            If mStatus = "Edit" Or mStatus = "RV" Then
        '                ' kiem tra lai
        '                'CopyValues("BookingEDI", "ContainerOutBoundNotifyId", mContainerOutboundNotifyId)
        '            End If
        '            strQuery = "SELECT * "
        '            strQuery = strQuery & "FROM BookingEDI "
        '            strQuery = strQuery & "WHERE ContainerOutBoundNotifyId = '" & mContainerOutboundNotifyId & "' AND continued=1 "
        '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '            With rs
        '                If rs.EOF Then
        '                    .AddNew()
        '                    .Fields("BookingEDIID").Value = NewId()

        '                End If

        '                .Fields("ContainerOutBoundNotifyId").Value = mContainerOutboundNotifyId
        '                .Fields("BookingOtherRef").Value = Me.txtBookingOtherRef.Text
        '                .Fields("ShipperRefNo").Value = Me.cboShipperRefNo.Text.Trim
        '                .Fields("PO").Value = Me.txtPO.Text
        '                .Fields("BLNo").Value = Me.txtBLNo.Text.Trim
        '                .Fields("VIPCode").Value = Me.cboVIPCode.Text.Trim
        '                .Fields("CargoDescription").Value = Me.txtCargoDescription.Text.Trim
        '                .Fields("CommodityEDI").Value = Me.txtCommodityEDI.Text.Trim
        '                .Fields("ShipperName").Value = Me.txtShipperName.Text.Trim
        '                .Fields("ConsigneeName").Value = Me.txtConsigneeName.Text.Trim
        '                .Fields("NotifyName").Value = Me.txtNotifyName.Text.Trim
        '                .Fields("BookingStatus").Value = Me.cboBookingstatus.Text.Trim
        '                .Fields("BookingOffice").Value = Me.txtBookingOffice.Text.Trim
        '                .Fields("BookingArea").Value = Me.txtBookingArea.Text.Trim
        '                .Fields("BookingUserID").Value = Me.txtUserID.Text.Trim
        '                .Update()
        '                DisplayMessage(True, "Saving is complete.!")
        '            End With
        '            rs.Close()
        '        End If


        '        Exit Sub
        'Err_Renamed:
        '        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub cmdBookingEDIDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' xoa Bookinh EDI
        Dim strQueryCommodityList As String = "Update BookingEDI Set Continued=0 where  ContainerOutBoundNotifyID= '" & mContainerOutboundNotifyId & "' And Continued=1"

        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Conn.Open()
        Dim cmd As New SqlClient.SqlCommand(strQueryCommodityList, Conn)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = strQueryCommodityList
        cmd.ExecuteNonQuery()
        Conn.Close()
        Conn.Dispose()
        cmd.Dispose()
        'pin --------
        RefreshBookingEDI(mContainerOutboundNotifyId)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClsBookingEDI()
    End Sub
    Sub QueryContainerType(ByVal BookingID As String)
        Try
            Dim strSQL As String
            strSQL = "Select * "
            strSQL &= " from ContainerOutboundNotify_sale "
            strSQL &= " where Containeroutboundnotifyid='" & BookingID & "'  and continued=1"
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
    Sub QueryContainer(ByVal BookingID As String)
        Try
            Dim strSQL As String
            strSQL = "Select * "
            strSQL &= " from loadingplanforvessel "
            strSQL &= " where Containeroutboundnotifyid='" & BookingID & "' and continued=1 "
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
    Sub SetExcelValue()
        'Dim app As Application
        'Dim Path As String
        'Try
        '    Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        '    Dim dsNoRich As New DataSet
        '    app = New Application()
        '    app.Visible = True

        '    Dim workbooks As Workbooks
        '    workbooks = app.Workbooks
        '    Dim workbook As _Workbook
        '    '------
        '    SaveFileDialog.InitialDirectory = "C:\"
        '    SaveFileDialog.Filter = "Notepad files (*.txt)|*.txt|All files (*.*)|*.*"
        '    SaveFileDialog.FileName = gBillNoRpt
        '    If SaveFileDialog.ShowDialog = DialogResult.OK Then
        '        Path = SaveFileDialog.FileName
        '    Else
        '        Return
        '    End If
        '    '------
        '    workbook = workbooks.Open(Path)

        '    Dim sheets As Sheets
        '    Dim bl_no As String
        '    sheets = workbook.Worksheets
        '    Dim ws As _Worksheet
        '    ws = sheets.Item(1)
        '    If ws Is Nothing Then
        '        app.Quit()
        '        Return
        '    End If
        '    Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
        '    ws.Range("A" & DongHienTai).Value2 = bl_no 'Vessel & " - " & VoyNo
        '    ws.Range("B" & DongHienTai).Value2 = ETD
        '    ws.Range("F" & DongHienTai).Value2 = IIf(UCase(ds.Tables("oTableBill").Rows(i).Item("PREPAID_OR_COLLECT").ToString.Trim) = "PREPAID", "P", "C")

        '    ' dem loai cont trong booking trong truong hop co nhieu hon 2 loai cont, EDI se them 1 dong tuong ung nam ke tiep 
        '    QueryContainerType(mContainerOutboundNotifyId)


        '    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
        '        Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim





        '    Next
        '    ' lay so cont tu loading confirm
        '    QueryContainer(mContainerOutboundNotifyId)
        '    For P As Integer = 0 To ds.Tables("oTableFeeMF").Rows.Count - 1
        '        If ds.Tables("oTableFeeMF").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
        '            If UCase(ds.Tables("oTableFeeMF").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" And ds.Tables("oTableFeeMF").Rows(P).Item("port_code").ToString.Trim Like "VN*" Then
        '                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFeeMF").Rows(P).Item("FEE")
        '                'ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
        '                'ws.Range("J" & DongHienTai).Value2 = "P"
        '            Else
        '                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFeeMF").Rows(P).Item("FEE")
        '                'ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
        '                'ws.Range("J" & DongHienTai).Value2 = "C"
        '            End If
        '        End If
        '    Next


        '    ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1

        '    ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
        '    ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
        '    DongHienTai += 1





        '    workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        'Catch ex As Exception
        '    MsgBox(" Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
        '    MsgBox(Err.Description)
        '    Return
        'Finally
        '    app.Quit()
        'End Try

    End Sub
    Private Sub smnuBookingEDIFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' xuat EDI theo tung Booking
        frmExportBookingEDI.Show()

    End Sub

    Private Sub txtBookingOtherRef_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'If CheckBookingRef(Me.txtBookingOtherRef.Text.Trim) = False Then
        '    DisplayMessage(True, "Please check Booking No. !")

        '    Return
        'End If
    End Sub

    Private Sub txtBookingOtherRef_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Function CheckBookingRef(ByVal txtObj As String) As Boolean
        Try
            Dim SQL As String
            SQL = "select Top 1 BookingNo from ContainerOutboundNotify_sale Where bookingno ='" & txtObj & "' And Continued=1 "
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

#Region "ContainerSpecial"


    Private Sub txtSoLuong20OT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chb20OT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo err_renamed
        '        Me.txtSoLuong20OT.Enabled = Me.chb20OT.Checked
        '        Me.txtW20OT.Enabled = Me.chb20OT.Checked
        '        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
        '            Return
        '        End If
        '        Dim index As Integer
        '        index = Me.dgdContianerOutboundNotify.CurrentRow.Index

        '        Me.txtSoLuong20OT.Text = IIf(Me.chb20OT.Checked = False, "0", Me.dgdContianerOutboundNotify.Item("OT20", index).Value.ToString)
        '        Exit Sub
        'err_renamed:
        '        'MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub chb40OT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo err_renamed
        '        Me.txtSoLuong40OT.Enabled = Me.chb40OT.Checked
        '        Me.txtW40OT.Enabled = Me.chb40OT.Checked
        '        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
        '            Return
        '        End If
        '        Dim index As Integer
        '        index = Me.dgdContianerOutboundNotify.CurrentRow.Index

        '        Me.txtSoLuong40OT.Text = IIf(Me.chb40OT.Checked = False, "0", Me.dgdContianerOutboundNotify.Item("OT40", index).Value.ToString)
        '        Exit Sub
        'err_renamed:
        'MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub chb20FR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo err_renamed
        '        Me.txtSoLuong20FR.Enabled = Me.chb20FR.Checked
        '        Me.txtW20FR.Enabled = Me.chb20FR.Checked
        '        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
        '            Return
        '        End If
        '        Dim index As Integer
        '        index = Me.dgdContianerOutboundNotify.CurrentRow.Index

        '        Me.txtSoLuong20FR.Text = IIf(Me.chb20FR.Checked = False, "0", Me.dgdContianerOutboundNotify.Item("FR20", index).Value.ToString)
        '        Exit Sub
        'err_renamed:
        'MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub chb40FR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo err_renamed
        '        Me.txtSoLuong40FR.Enabled = Me.chb40FR.Checked
        '        Me.txtW40FR.Enabled = Me.chb40FR.Checked
        '        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
        '            Return
        '        End If
        '        Dim index As Integer
        '        index = Me.dgdContianerOutboundNotify.CurrentRow.Index

        '        Me.txtSoLuong40FR.Text = IIf(Me.chb40FR.Checked = False, "0", Me.dgdContianerOutboundNotify.Item("FR40", index).Value.ToString)
        '        Exit Sub
        'err_renamed:
        '        'MsgBox(msgErr(Me, Err.Description))
    End Sub

#End Region


    Private Sub CheckBox18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo err_renamed
        '        Me.txtSoLuongCBM.Enabled = Me.chbCBM.Checked
        '        Me.txtWCBM.Enabled = Me.chbCBM.Checked
        '        If Me.dgdContianerOutboundNotify.RowCount = 0 Then
        '            Return
        '        End If
        '        Dim index As Integer
        '        index = Me.dgdContianerOutboundNotify.CurrentRow.Index

        '        Me.txtSoLuongCBM.Text = IIf(Me.chbCBM.Checked = False, "0", Me.dgdContianerOutboundNotify.Item("CBM", index).Value.ToString)
        '        Exit Sub
        'err_renamed:
        '        'MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub tbcContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgdContianerOutboundNotify_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContianerOutboundNotify.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        If Me.dgdContianerOutboundNotify.Rows.Count = 0 Then
            Return
        End If
        'If Me.oTable.Rows.Count > 0 Then
        '    index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        'Else
        '    Exit Sub
        'End If
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdContianerOutboundNotify.Columns(ColIndex).Name = "Approve" And Me.dgdContianerOutboundNotify.CurrentCellAddress().Y = index Then
            Call ApproveContainerOutboundNotify()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdContianerOutboundNotify_ColumnHeaderMouseClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContianerOutboundNotify.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
    End Sub

    Private Sub txtGio1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtGio1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'lcl
        'If Me.txtSoLuongCBM.Text <> "0" And Me.txtSoLuongCBM.Text <> "" Then
        '    If Me.txtGio1.Text = "" Then
        '        DisplayMessage(True, "Xin kiểm tra lại.! CBM ")
        '    End If
        'ElseIf Me.txtSoLuongCBM.Text = "0" Then
        '    If Me.txtGio1.Text.Trim <> "" Then
        '        DisplayMessage(True, "Xin kiểm tra lại.! CBM ")
        '    End If

        'End If
    End Sub

    Private Sub txtGio2_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtGio2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''fcl

    End Sub

    Private Sub tbcGhiChu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabPageFCL.Click

    End Sub

    Private Sub dtpbd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtgio1_Leave1(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtgio1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtgio1_Leave2(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Me.txtSoLuongCBM.Text <> "0" And Me.txtSoLuongCBM.Text <> "" Then
        '    If Me.txtgio1.Text.Trim = "" Then
        '        DisplayMessage(True, "Xin kiểm tra lại Closing Time của CBM. ")
        '    End If
        'ElseIf Me.txtSoLuongCBM.Text = "0" Then
        '    If Me.txtgio1.Text.Trim <> "" Then
        '        DisplayMessage(True, "Xin kiểm tra lại Closing Time của CBM.  ")
        '    End If

        'End If
    End Sub

    Private Sub txtgio1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtgio2_Leave1(ByVal sender As Object, ByVal e As System.EventArgs)
        'If (Me.txtSoLuong20GP.Text <> "0" And Me.txtSoLuong20GP.Text <> "") And (Me.txtSoLuong40GP.Text <> "0" And Me.txtSoLuong40GP.Text <> "") And (Me.txtSoLuong40HC.Text <> "0" And Me.txtSoLuong40HC.Text <> "") And (Me.txtSoLuong45HC.Text <> "0" And Me.txtSoLuong45HC.Text <> "") And (Me.txtSoLuong20RF.Text <> "0" And Me.txtSoLuong20RF.Text <> "") And (Me.txtSoLuong40RF.Text <> "0" And Me.txtSoLuong40RF.Text <> "") And (Me.txtSoLuong40RH.Text <> "0" And Me.txtSoLuong40RH.Text <> "") And (Me.txtSoLuong20OT.Text <> "0" And Me.txtSoLuong20OT.Text <> "") And (Me.txtSoLuong40OT.Text <> "0" And Me.txtSoLuong40OT.Text <> "") And (Me.txtSoLuong20FR.Text <> "0" And Me.txtSoLuong20FR.Text <> "") And (Me.txtSoLuong40FR.Text <> "0" And Me.txtSoLuong40FR.Text <> "") Then
        '    If Me.txtgio2.Text.Trim = "" Then
        '        DisplayMessage(True, "Xin kiểm tra lại Closing Time của FCL. ")
        '    End If
        'ElseIf (Me.txtSoLuong20GP.Text = "0" And Me.txtSoLuong40GP.Text = "0" And Me.txtSoLuong40HC.Text = "0" And Me.txtSoLuong45HC.Text = "0" And Me.txtSoLuong20RF.Text = "0" And Me.txtSoLuong40RF.Text = "0" And Me.txtSoLuong40RH.Text = "0" And Me.txtSoLuong20OT.Text = "0" And Me.txtSoLuong40OT.Text = "0" And txtSoLuong20FR.Text = "0" And Me.txtSoLuong40FR.Text = "0") Then
        '    If Me.txtgio2.Text.Trim <> "" Then
        '        DisplayMessage(True, "Xin kiểm tra lại Closing Time của FCL.  ")
        '    End If

        'End If
    End Sub

    Private Sub txtgio2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SentEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        Try
        '            'Dim sql As String
        '            'Dim ds As New DataSet
        '            'sql = "select optionvalue from [Option] where optioncode='EmailServer' "
        '            'ds = ReadDataSet(sql)
        '            'If ds.Tables(0).Rows.Count > 0 Then
        '            '    Me.txtSMTP.Text = ds.Tables(0).Rows(0).Item("optionvalue").ToString
        '            'End If
        '            'Me.GroupBox5.Visible = True
        '            Try
        '                Dim chk As Integer
        '                chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        '                If chk = 0 Then
        '                    DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
        '                    Return
        '                End If


        '                Dim index As Integer
        '                If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
        '                    index = Me.dgdContianerOutboundNotify.CurrentRow.Index
        '                Else
        '                    Exit Sub
        '                End If
        '                'Capture the image of this button including the cursor.
        '                'Dim filePath As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\SCapture" + CDate(Getdate()).Second.ToString + ".png"
        '                'Dim img As Image = SCapture.Control(Control.MousePosition, True)
        '                'Dim img As Image = SCapture.Window(Me.Handle, False)
        '                'Save the captured image.
        '                'img.Save(filePath, Drawing.Imaging.ImageFormat.Png)
        '                'Also display the captured image in a PictureBox.
        '                'DisplayMessage(True, img.ToString)
        '                '---
        '                Try
        '                    Dim emailto As String = Me.dgdContianerOutboundNotify.Item("email", index).Value.ToString.Trim()
        '                    Dim objOutlook As Outlook.Application
        '3:                  Dim objEmail As Outlook.MailItem
        '4:
        '5:                  objOutlook = CType(CreateObject("Outlook.Application"), Outlook.Application)
        '6:                  objEmail = objOutlook.CreateItem(Outlook.OlItemType.olMailItem)
        '7:
        '8:                  Dim body As String
        '9:                  'Gets First word in TextBox

        '11:
        '12:                 body = "" & "" & "," & vbCrLf & vbCrLf
        '                    '13:             body += "Please find attached purchase order number " & txtPONumber.Text & "." & vbCrLf & vbCrLf
        '                    '14:             body += "Please confirm lead time." & vbCrLf & vbCrLf
        '                    '15:             body += "Thanks and Best Regards," & vbCrLf & cmbBuyer.SelectedItem.ToString
        '16:
        '17:                 With objEmail
        '                        '18:                 .Subject = "Purchase Order " & txtPONumber.Text
        '19:                     .To = emailto.ToString
        '                        '20:                 .Body = body
        '21:                     '.Attachments.Add(filePath)
        '22:                     .Display(True)
        '23:                 End With
        '24:             Catch ex As Exception
        '25:                 MsgBox("Unable to generate automatic email. Please create the email manually.", MsgBoxStyle.Information, "Error!")
        '                End Try

        '                '----------------

        '            Catch ex As Exception
        '                'Show a MessageBox if the capture of image failed.
        '                MessageBox.Show("Failed to capture the control!" _
        '                & Environment.NewLine & ex.Message, "Capture Error!", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End Try
        '        Catch ex As Exception

        '        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' Me.GroupBox5.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try


        '    Dim chk As Integer
        '    chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        '    If chk = 0 Then
        '        DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
        '        Return
        '    End If
        '    Dim selectedRowCount As Integer = _
        '   Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
        '    Dim f As Integer = 0
        '    Dim diachi, noidung, MySqlID As String
        '    '----------lay quyen truy cap hop dong

        '    Dim chuoi, sqlo As String
        '    If LoginSucceeded = False Then
        '        Return
        '    End If
        '    If Me.txtfrom.Text = "" Then
        '        DisplayMessage(True, "From ?")
        '        Exit Sub
        '    End If

        '    If Me.txtpass.Text = "" Then
        '        DisplayMessage(True, "Password ?")
        '        Exit Sub
        '    End If
        '    If Me.txtSMTP.Text = "" Then
        '        DisplayMessage(True, "SMTP ?")
        '        Exit Sub
        '    End If

        '    'Dim rsPQ As New ADODB.Recordset
        '    'sqlo = "select optionvalue from [Option] where optioncode='EmailServer' "

        '    'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
        '    'If Not rsPQ.EOF Then
        '    '    chuoi = rsPQ.Fields("optionvalue").Value.ToString
        '    'End If
        '    'rsPQ.Close()
        '    '----------------------------------

        '    Dim chuoi1 As String
        '    If LoginSucceeded = False Then
        '        Return
        '    End If

        '    'sqlo = "select optionvalue from [Option] where optioncode='NoidungEmailXacNhan' "

        '    'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
        '    'If Not rsPQ.EOF Then
        '    '    chuoi1 = rsPQ.Fields("optionvalue").Value.ToString
        '    'End If
        '    'rsPQ.Close()


        '    Dim email, smtp, pass, port As String
        '    Dim tach() As String
        '    'If Me.txtSMTP.Text = "" Then
        '    '    tach = chuoi.Split(";")
        '    'Else




        '    Dim smtp_() As String
        '    smtp_ = Me.txtSMTP.Text.Split(";")

        '    tach = (Me.txtfrom.Text.Trim + ";" + smtp_(0).ToString + ";" + Me.txtpass.Text + ";" + smtp_(1).ToString).Split(";")


        '    'End If

        '    email = Me.txtname.Text + " <" + tach(0) + ">"
        '    smtp = tach(1)
        '    pass = tach(2)
        '    port = tach(3)
        '    Dim noidungemail As String
        '    Dim dem As Integer
        '    If selectedRowCount > 0 Then
        '        Dim sb As New System.Text.StringBuilder()
        '        Dim i As Integer
        '        Dim ten As String
        '        For i = 0 To selectedRowCount - 1
        '            ' chon thong tin theo index

        '            diachi = Me.cboemail.Text 'Me.dgdContianerOutboundNotify.Item("Email", Me.dgdContianerOutboundNotify.SelectedRows(i).Index).Value.ToString
        '            If diachi <> "" Then


        '                ten = Me.dgdContianerOutboundNotify.Item("company", Me.dgdContianerOutboundNotify.SelectedRows(i).Index).Value.ToString + " ( Tel: " + Me.dgdContianerOutboundNotify.Item("telephone", Me.dgdContianerOutboundNotify.SelectedRows(i).Index).Value.ToString + ") "

        '                'MySqlID = chuoi1 + Me.dgdContianerOutboundNotify.Item("id", Me.dgdContianerOutboundNotify.SelectedRows(i).Index).Value.ToString
        '                noidungemail = Me.txtNoidungEmail.Text.ToString 'noidungemail = Me.txtKinhgui.Text + " " + ten + " " + Me.txtNoidungEmail.Text.ToString
        '                If diachi <> "" Then

        '                    SendMailMessage(email, diachi, "", "", Me.txtSubject.Text, noidungemail)
        '                    'updateSendEmail(Me.dgdkhachhang.Item("id", Me.dgdHopdong.SelectedRows(i).Index).Value.ToString)
        '                    'Sleep(10)
        '                    System.Threading.Thread.Sleep(CInt(Me.txtGiay.Text))
        '                    dem += 1
        '                End If

        '                f = 1
        '            End If
        '        Next i

        '    End If
        'Catch ex As Exception
        '    DisplayMessage(True, Err.Description)
        'End Try
    End Sub
    Public Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String)
        'Try


        '    ' Instantiate a new instance of MailMessage
        '    Dim mMailMessage As New MailMessage()

        '    ' Set the sender address of the mail message
        '    mMailMessage.From = New MailAddress(from)
        '    ' Set the recepient address of the mail message
        '    mMailMessage.To.Add(New MailAddress(recepient))

        '    ' Check if the bcc value is nothing or an empty string
        '    If Not bcc Is Nothing And bcc <> String.Empty Then
        '        ' Set the Bcc address of the mail message
        '        mMailMessage.Bcc.Add(New MailAddress(bcc))
        '    End If

        '    ' Check if the cc value is nothing or an empty value
        '    If Not cc Is Nothing And cc <> String.Empty Then
        '        ' Set the CC address of the mail message
        '        mMailMessage.CC.Add(New MailAddress(cc))
        '    End If

        '    ' Set the subject of the mail message
        '    mMailMessage.Subject = subject
        '    ' Set the body of the mail message
        '    mMailMessage.Body = body

        '    ' Set the format of the mail message body as HTML
        '    mMailMessage.IsBodyHtml = True
        '    ' Set the priority of the mail message to normal
        '    mMailMessage.Priority = MailPriority.Normal
        '    'mMailMessage.
        '    If Me.txtFileName.Text <> "" Then
        '        Dim attach As New Attachment(Me.txtFileName.Text)


        '        mMailMessage.Attachments.Add(attach)

        '    End If


        '    '----------lay quyen truy cap hop dong
        '    Dim chuoi, sqlo As String
        '    If LoginSucceeded = False Then
        '        Return
        '    End If
        '    Dim sql As String
        '    Dim ds As New DataSet
        '    sql = "select optionvalue from [Option] where optioncode='EmailServer' "
        '    ds = ReadDataSet(sql)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Me.txtSMTP.Text = ds.Tables(0).Rows(0).Item("optionvalue").ToString
        '    End If
        '    'Dim rsPQ As New ADODB.Recordset
        '    'sqlo = "select optionvalue from [Option] where optioncode='EmailServer' "

        '    'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
        '    'If Not rsPQ.EOF Then
        '    '    chuoi = rsPQ.Fields("optionvalue").Value.ToString
        '    'End If
        '    'rsPQ.Close()
        '    '----------------------------------

        '    Dim chuoi1 As String
        '    If LoginSucceeded = False Then
        '        Return
        '    End If

        '    'sqlo = "select optionvalue from [Option] where optioncode='NoidungEmailXacNhan' "

        '    'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
        '    'If Not rsPQ.EOF Then
        '    '    chuoi1 = rsPQ.Fields("optionvalue").Value.ToString
        '    'End If
        '    'rsPQ.Close()


        '    Dim email, smtp, pass, port As String
        '    Dim tach() As String
        '    'If Me.txtSMTP.Text = "" Then
        '    '    tach = chuoi.Split(";")
        '    'Else
        '    Dim smtp_() As String
        '    smtp_ = Me.txtSMTP.Text.Split(";")

        '    tach = (Me.txtfrom.Text.Trim + ";" + smtp_(0).ToString + ";" + Me.txtpass.Text + ";" + smtp_(1).ToString).Split(";")
        '    'End If

        '    email = Me.txtname.Text + " <" + tach(0) + ">"
        '    smtp = tach(1)
        '    pass = tach(2)
        '    port = tach(3)
        '    ' Instantiate a new instance of SmtpClient
        '    Dim mSmtpClient As New SmtpClient()
        '    ' Send the mail message
        '    mSmtpClient.Host = smtp
        '    mSmtpClient.Port = CInt(port)
        '    If txttimeout.Text <> "" Then
        '        mSmtpClient.Timeout = CInt(txttimeout.Text)
        '    End If


        '    'If UCase(smtp) = "SMTP.GMAIL.COM" Then
        '    If chkSsl.Checked = True Then
        '        mSmtpClient.EnableSsl = True
        '    End If

        '    'End If

        '    mSmtpClient.Credentials = New System.Net.NetworkCredential(email, pass)


        '    mSmtpClient.Send(mMailMessage)
        '    DisplayMessage(True, "Send items .1")

        'Catch ex As Exception
        '    DisplayMessage(True, Err.Description)
        'End Try




    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo Err
        '        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            Me.txtFileName.Text = Me.OpenFileDialog1.FileName
        '        End If
        '        Exit Sub
        'Err:
    End Sub

    Private Sub cmdReviewHTML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub fraCopyPaste_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PieChartsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PieChartsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub sentEmail_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sentEmail.Opening

    End Sub

    Private Sub BookingSITCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim index As Integer
            Dim chk As Integer
            chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Else
                Exit Sub
            End If
            If Me.dgdContianerOutboundNotify.Item("Editable", index).Value = 0 Then
                DisplayMessage(True, "This not the Final Edit Booking, You have to select the Final edit Booking")
                Return
            End If
            gPrintBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
            VB6.ShowForm(frmPrintBookingSITC, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox29_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthToolStripMenuItem.Click
        Try
            monthlyBooking(CDate(Getdate()))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'If Me.CheckBox18.Checked = True Then
            '    monthlyBookingCancel(Me.DateTimePicker9.Value.Date)
            '    '  Me.lblTotal.Text = "Total : " + (dem).ToString + " Books in (Cancel)" + CDate(Getdate()).ToString("MMM")
            'Else
            monthlyBooking(Me.DateTimePicker9.Value.Date)
            '    '  Me.lblTotal.Text = "Total : " + (dem).ToString + " Books in " + CDate(Getdate()).ToString("MMM")
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
            If index < 0 Then
                Return
            End If
            Dim frm As String
            booking_quotation = Me.dgdContianerOutboundNotify.Item("BookingNo", index).Value.ToString

            frm = Me.dgdContianerOutboundNotify.Item("IOL", index).Value.ToString
            ' kiem tra trong shipment co chua
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from quotation where bookingno='" & booking_quotation & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                DisplayMessage(True, "Booking đã được thêm vào Shipment Profit.!")
                ' Exit Sub
            End If
            '--------------------------------------

            If frm = "Outbound" Then
                VB6.ShowForm(frmQuotation, VB6.FormShowConstants.Modeless, Me)


            ElseIf frm = "Inbound" Then
                VB6.ShowForm(frmQuotationInbound, VB6.FormShowConstants.Modeless, Me)
            ElseIf frm = "Logistics" Then
                VB6.ShowForm(frmQuotationLogistics, VB6.FormShowConstants.Modeless, Me)

            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim pol, pod As String
            Try
                pol = Me.CBOFROM.Text.Remove(0, 2)
            Catch ex As Exception
                pol = ""
            End Try



            Try
                pod = Me.CBOTO.Text.Remove(0, 2)
            Catch ex As Exception
                pod = ""
            End Try
            Me.txtBookingNo.Text = pol + pod + CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookingConfirmAirToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim index As Integer
            Dim chk As Integer
            chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdContianerOutboundNotify.Rows.Count > 0 Then
                index = Me.dgdContianerOutboundNotify.CurrentRow.Index
            Else
                Exit Sub
            End If
            'If Me.dgdContianerOutboundNotify.Item("Editable", index).Value = 0 Then
            '    DisplayMessage(True, "This not the Final Edit Booking, You have to select the Final edit Booking")
            '    Return
            'End If
            gBookingID = Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString
            ' VB6.ShowForm(frmRptSupplyEmptyContainer, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmRptSupplyEmptyContainer_air 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBOFROM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOFROM.SelectedIndexChanged
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from port where port_code='" & Me.CBOFROM.Text & "' "
            ds = ReadDataSet(sql)
            Try
                Me.cbopol.Text = ds.Tables(0).Rows(0).Item("port").ToString + "-" + ds.Tables(0).Rows(0).Item("port_code").ToString
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBOTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOTO.SelectedIndexChanged
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from port where port_code='" & Me.CBOTO.Text & "' "
            ds = ReadDataSet(sql)
            Try
                Me.cbopod.Text = ds.Tables(0).Rows(0).Item("port").ToString + "-" + ds.Tables(0).Rows(0).Item("port_code").ToString
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblPortOfUnLoading_Click(sender As Object, e As EventArgs) Handles lblPortOfUnLoading.Click

    End Sub

    Private Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged

    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPageAir.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim id, value, strSQL As String
            id = "Customer_ID"
            value = "Company"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select Customer_ID,Company From Customer where Continued= 1 and (company like '%" & Me.TextBox30.Text & "%' or taxcode like '%" & Me.TextBox30.Text & "%' ) Order By Company desc"
            'If Me.cboCompany.Items.Count = 0 Then
            loadDataToObject(Me.cboCompany, strSQL, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboPOR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPOR.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'If LoginSucceeded = True Then
                '    Dim form As New frmListPort 'frmInbound 'frmQuotationTico
                '    form.MdiParent = Me
                '    form.show()
                'End If

                VB6.ShowForm(frmListPort, VB6.FormShowConstants.Modeless, Me)
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'If LoginSucceeded = True Then
                '    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                '    frmMain.MdiParent = form
                '    form.Show()
                'End If
                VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'If LoginSucceeded = True Then
            '    Dim form As New frmListPort 'frmInbound 'frmQuotationTico
            '    form.MdiParent = Me
            '    form.show()
            'End If

            VB6.ShowForm(frmListPort, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'If LoginSucceeded = True Then
            '    Dim form As New frmListPort 'frmInbound 'frmQuotationTico
            '    form.MdiParent = Me
            '    form.show()
            'End If

            VB6.ShowForm(frmListPort, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'If LoginSucceeded = True Then
            '    Dim form As New frmListPort 'frmInbound 'frmQuotationTico
            '    form.MdiParent = Me
            '    form.show()
            'End If

            VB6.ShowForm(frmListPort, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim id, value, strSQL As String
            Me.cboPOR.Items.Clear()
            id = "Port_Code"
            value = "Port"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 and show=1 and (port_code like '%" & Me.txtpor.Text & "%' or port like '%" & Me.txtpor.Text & "%' )  Order By Port desc"
            loadDataToObject(cboPOR, strSQL, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim id, value, strSQL As String
            Me.cbopol.Items.Clear()
            id = "Port_Code"
            value = "Port"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 and show=1 and (port_code like '%" & Me.txtpol.Text & "%' or port like '%" & Me.txtpol.Text & "%') Order By Port desc"
            loadDataToObject(cbopol, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim id, value, strSQL As String
            Me.cbopot.Items.Clear()
            id = "Port_Code"
            value = "Port"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 and show=1 and (port_code like '%" & Me.txtpot.Text & "%'  or port like '%" & Me.txtpot.Text & "%') Order By Port desc"
            loadDataToObject(cbopot, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim id, value, strSQL As String
            Me.cbopod.Items.Clear()
            id = "Port_Code"
            value = "Port"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 and show=1 and ( port_code like '%" & Me.txtpod.Text & "%'  or port like '%" & Me.txtpod.Text & "%' )Order By Port desc"
            loadDataToObject(cbopod, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'If LoginSucceeded = True Then
            '    Dim form As New frmListPort 'frmInbound 'frmQuotationTico
            '    form.MdiParent = Me
            '    form.show()
            'End If

            VB6.ShowForm(frmListPort, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            Try
                Dim id, value, strSQL As String
                Me.cboPORAir.Items.Clear()
                id = "Port_Code"
                value = "Port"
                'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
                strSQL = "Select Port_Code,Port + '-' + Port_Code as Port From Port where Continued=1 and show=1 and (port_code like '%" & Me.txtporAir.Text & "%' or port like '%" & Me.txtporAir.Text & "%' )  Order By Port desc"
                loadDataToObject(cboPORAir, strSQL, id, value)

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Try
            Dim id, value, strsql As String
            Me.cboAirportofDeparture.Items.Clear()
            id = "hanoAir_AirportofDeparture"
            value = "hanoAir_AirportofDeparture"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strSQL = "Select distinct hanoAir_AirportofDeparture  "
            strsql = strsql & " from ContainerOutboundNotify_sale where  hanoAir_AirportofDeparture like '%" & Me.txtdeparture.Text & "%' order by hanoAir_AirportofDeparture " '
            loadDataToObject(Me.cboAirportofDeparture, strSQL, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Try
            Dim id, value, strsql As String
            Me.cboAirportofdestination.Items.Clear()
            id = "hanoAir_AirportofDestination"
            value = "hanoAir_AirportofDestination"
            'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
            strsql = "Select distinct hanoAir_AirportofDestination  "
            strsql = strsql & " from ContainerOutboundNotify_sale where  hanoAir_AirportofDestination like '%" & Me.txtdestination.Text & "%' order by hanoAir_AirportofDestination " '
            loadDataToObject(Me.cboAirportofdestination, strsql, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FCLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FCLToolStripMenuItem.Click
        Try


            ' Me.chkDalayLenh.Checked = checkSupply()
            If mStatus = "Normal" And UserRight("mnuCustomerService", "Add") Then
                Me.txtBookingNo.Enabled = True
                Dim bookingnumber As String = CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString
                '   Me.txtBookingNo.Text = bookingnumber
                Me.fraUpdate.Visible = True
                Me.dgdContianerOutboundNotify.Enabled = True
                ReFormat()
                SetMenu((False))
                Me.smnuPrint.Enabled = True
                mContainerOutboundNotifyId = DefaultValue
                mStatus = "Add"
                glockorder = 0
                '07-12-2007 lấy ngày server cho bookingdate

                reText(mStatus)
                Try
                    ' Me.txtBookingNo.Text = "W" + CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString

                Catch ex As Exception

                End Try

                insert()

                ''' xoa trang edi de them moi
                ClsBookingEDI()
                ' 
                'ShowTab(Me.tabpageinformation, True)
                'ShowTab(Me.tabPageFCL, True)
                'ShowTab(Me.TabPagelcl, False)
                'ShowTab(Me.TabPageAir, False)
                Dim ctr As Control
                For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                    ctr.Visible = True
                Next

                For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                    ctr.Visible = False
                Next
                For Each ctr In Me.TabPageAir.Controls ' DEBIT
                    ctr.Visible = False
                Next
                ' xoa thong tin cu

                For Each ctr In Me.tabpageinformation.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If
                Next
                For Each ctr In Me.TabPageAir.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If
                Next
                Me.cboFLA.Text = "FCL"
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LCLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LCLToolStripMenuItem.Click
        Try
            ' Me.chkDalayLenh.Checked = checkSupply()
            If mStatus = "Normal" And UserRight("mnuCustomerService", "Add") Then
                Me.txtBookingNo.Enabled = True
                Dim bookingnumber As String = CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString
                '   Me.txtBookingNo.Text = bookingnumber
                Me.fraUpdate.Visible = True
                Me.dgdContianerOutboundNotify.Enabled = True
                ReFormat()
                SetMenu((False))
                Me.smnuPrint.Enabled = True
                mContainerOutboundNotifyId = DefaultValue
                mStatus = "Add"
                glockorder = 0
                '07-12-2007 lấy ngày server cho bookingdate

                reText(mStatus)
                Try
                    ' Me.txtBookingNo.Text = "W" + CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString

                Catch ex As Exception

                End Try

                insert()

                ''' xoa trang edi de them moi
                ClsBookingEDI()
                ' 
                'ShowTab(Me.tabpageinformation, True)
                'ShowTab(Me.tabPageFCL, False)
                'ShowTab(Me.TabPagelcl, True)
                'ShowTab(Me.TabPageAir, False)
                Dim ctr As Control
                For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                    ctr.Visible = False
                Next

                For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                    ctr.Visible = True
                Next
                For Each ctr In Me.TabPageAir.Controls ' DEBIT
                    ctr.Visible = False
                Next
                ' xoa thong tin cu

                For Each ctr In Me.tabpageinformation.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If
                Next
                For Each ctr In Me.TabPageAir.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If
                Next
                Me.cboFLA.Text = "LCL"
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AirToolStripMenuItem.Click
        Try
            If mStatus = "Normal" And UserRight("mnuCustomerService", "Add") Then
                Me.txtBookingNo.Enabled = True
                Dim bookingnumber As String = CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString
                '   Me.txtBookingNo.Text = bookingnumber
                Me.fraUpdate.Visible = True
                Me.dgdContianerOutboundNotify.Enabled = True
                ReFormat()
                SetMenu((False))
                Me.smnuPrint.Enabled = True
                mContainerOutboundNotifyId = DefaultValue
                mStatus = "Add"
                glockorder = 0
                '07-12-2007 lấy ngày server cho bookingdate

                reText(mStatus)
                Try
                    ' Me.txtBookingNo.Text = "W" + CDate(Getdate()).ToString("yy") + CDate(Getdate()).ToString("MM") + getCusID().ToString

                Catch ex As Exception

                End Try

                insert()

                ''' xoa trang edi de them moi
                ClsBookingEDI()
                ' 
                'ShowTab(Me.tabpageinformation, True)
                'ShowTab(Me.tabPageFCL, False)
                'ShowTab(Me.TabPagelcl, False)
                'ShowTab(Me.TabPageAir, True)
                Dim ctr As Control
                For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                    ctr.Visible = False
                Next

                For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                    ctr.Visible = False
                Next
                For Each ctr In Me.TabPageAir.Controls ' DEBIT
                    ctr.Visible = True
                Next

                ' xoa thong tin cu

                For Each ctr In Me.tabpageinformation.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.tabPageFCL.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.TabPagelcl.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If
                Next
                For Each ctr In Me.TabPageAir.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If
                Next
                Me.cboFLA.Text = "AIR"

            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Sub EnableControl(ByVal Value As Boolean)
    '    Try
    '        Dim ctr As Control
    '        For Each ctr In Me.TabPage14.Controls ' DEBIT
    '            ctr.Visible = Value
    '        Next
    '        For Each ctr In Me.TabPage15.Controls ' CREDIT
    '            ctr.Visible = Value
    '        Next
    '        For Each ctr In Me.TabPage8.Controls ' CREDIT
    '            ctr.Visible = Value
    '        Next
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub
    Dim PortPOLPOD As String
    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        Try
            Me.GPort.BringToFront()
            PortPOLPOD = "POL"
            Me.GPort.Visible = True
            Me.GPort.Text = "Select POL"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortAdd_Click(sender As Object, e As EventArgs) Handles cmdPortAdd.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Port "
            strQuery = strQuery & "WHERE port_code = '" & Me.txtGPortCode.Text.Trim & "' " ' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Port_Id").Value = NewId()

                End If
                .Fields("Port_Code").Value = Me.txtGPortCode.Text
                .Fields("Port").Value = UCase(Trim(Me.txtgportName.Text))
                .Fields("show").Value = True

                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()
            Me.cmdPortSearch_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortSearch_Click(sender As Object, e As EventArgs) Handles cmdPortSearch.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If Me.txtGPortCode.Text <> "" And Me.txtgportName.Text = "" Then
                sql = "select port_id,port_code,port from port where port_code like '%" & Me.txtGPortCode.Text & "%'  order by port_code    "
            ElseIf Me.txtGPortCode.Text = "" And Me.txtgportName.Text <> "" Then
                'or port like '%" & txtgportName.Text & "%'
                sql = "select port_id,port_code,port from port where port like '%" & Me.txtgportName.Text & "%'  order by port_code   "
            ElseIf Me.txtGPortCode.Text = "" And Me.txtgportName.Text = "" Then
                sql = "select port_id,port_code,port from port order by port_code  "
            ElseIf Me.txtGPortCode.Text <> "" And Me.txtgportName.Text <> "" Then
                sql = "select port_id,port_code,port from port where port_code like '%" & Me.txtGPortCode.Text & "%'  and port like '%" & Me.txtgportName.Text & "%' order by port_code    "
            End If
            ds = ReadDataSet(sql)
            Me.DataGridView4.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.DataGridView4)
        Catch ex As Exception

        End Try
    End Sub
    Public vitri As Integer
    Private Sub cmdselectPort_Click(sender As Object, e As EventArgs) Handles cmdselectPort.Click
        Try
            If Me.DataGridView4.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.DataGridView4.CurrentRow.Index
            vitri = index
            'Try
            '    Me.txtNoDebit.Text = "DN-" + Me.txtRef.Text
            '    Me.txtNoCredit.Text = "CN-" + Me.txtRef.Text
            'Catch ex As Exception

            'End Try

            If index >= 0 Then
                If PortPOLPOD = "POL" Then
                    Me.cbopol.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.txtpol.Text = Me.DataGridView4.Item("port", index).Value.ToString
                    Me.CBOFROM.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                ElseIf PortPOLPOD = "POD" Then
                    Me.CBOTO.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.cbopod.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
                    Me.txtpod.Text = Me.DataGridView4.Item("port", index).Value.ToString

                End If


            End If
            Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            Me.GPort.BringToFront()
            PortPOLPOD = "POD"
            Me.GPort.Visible = True
            Me.GPort.Text = "Select POD"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortExit_Click(sender As Object, e As EventArgs) Handles cmdPortExit.Click
        Try
            Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GPort_Enter(sender As Object, e As EventArgs) Handles GPort.Enter

    End Sub
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true

    Private Sub GPort_MouseDown(sender As Object, e As MouseEventArgs) Handles GPort.MouseDown
        x = e.X
        y = e.Y
        Mdown = True
    End Sub

    Private Sub GPort_MouseMove(sender As Object, e As MouseEventArgs) Handles GPort.MouseMove
        If Mdown Then
            Me.GPort.Left = (e.X - x) + Me.GPort.Left
            Me.GPort.Top = (e.Y - y) + Me.GPort.Top
        End If
    End Sub

    Private Sub GPort_MouseUp(sender As Object, e As MouseEventArgs) Handles GPort.MouseUp
        If Mdown Then
            Mdown = False
            Me.GPort.Left = (e.X - x) + Me.GPort.Left
            Me.GPort.Top = (e.Y - y) + Me.GPort.Top
        End If
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerOutboundNotify("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class