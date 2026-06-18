'Option Strict Off
'Option Explicit On
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.ReportSource
'Imports CrystalDecisions.Shared
'Imports System
'Imports VB = Microsoft.VisualBasic

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




Public Class frmListCustomer

   

    Inherits System.Windows.Forms.Form
    Dim QuyenHan As String
    Dim strUser As String

    Dim index As Integer = 0
    Dim rsCustomerList As New ADODB.Recordset
    Dim mStatus, mFilter, mCommondityStatus, mPICStatus, mSaleStatus, mCusRptStatus As String
    Public blnUpdated As Boolean
    Public mCustomer_Id As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Dim oTableMarket, otableCusID As New DataTable
    Dim oTablePIC As New DataTable
    Dim oTableCommondity As New DataTable
    Dim oTableSaleDetail As New DataTable
    Dim oTableCusReport As New DataTable

    Dim mCustomerCommondity As String
    Dim mCustomerPIC As String
    Dim mSaleID As String
    Dim mCusReportID As String
    ' buyer
    Dim mCusBuyerID As String
    Dim mCusBuyerStatus As String
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer
    Dim Total As Double
    ' Const strDateOfCustomerSelect As String = "SELECT " & _
    ' "Customer_ID, " & _
    ' "Customer_Code, " & _
    ' "Company , Address,Tel,Fax,Email,ATTN, " & _
    '"Approve, " & _
    ' "Continued, " & _
    ' "Editable, " & _
    ' "UserId, " & _
    ' "Updatetime "

    Const strDateOfCustomerSelect As String = "SELECT Distinct Customer.Customer_ID,Customer_Code,MainCode,VIPCode,TaxCode,EnglishName,COMPANY,BIZName,Address, " & _
    " Tel,customer.FAX,Email,Web,Nationality,Province,Country,Type,Industry,Remarks_Customer,Remarks_sale, " & _
    " AccountPotantial,SaleName,ATTN,QuyenHan, Customer.ApprovePayer," & _
    " Customer.Approve,Customer.Continued,Customer.Editable,Customer.UserID,Customer.Updatetime "

    Const strDateOfCustomerOrder1 As String = _
           " ORDER BY Customer_Code  Desc "
    Const strDateOfCustomerOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strCustomer_Id As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtCustomer_Code.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Customer "
                strQuery = strQuery & "WHERE Customer_Code = '" & Me.txtCustomer_Code.Text & "' And Continued=1 "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    CheckData = False

                    DisplayMessage(True, IIf(gLang = "E", "This code had already in database", "Mã Này Đã Có Trong Cơ Sở Dữ Liệu"))
                End If
                rs.Close()
            End If
        End If
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                'If Me.txtTaxCode.Text = "" Then
                '    CheckData = False
                '    DisplayMessage(True, IIf(gLang = "E", "The Tax code not allow NULL value", "Mã Số Thuế Không Đựơc để Rỗng"))
                'End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Customer "
                strQuery = strQuery & "WHERE taxcode = '" & Me.txtTaxCode.Text & "' And Continued=1 "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    'CheckData = False

                    'DisplayMessage(True, IIf(gLang = "E", "This Tax code had already in database", "Mã Số Thuế Này Đã Có Trong Cơ Sở Dữ Liệu"))
                End If
                rs.Close()
            End If
        End If
        If mStatus = "Add" Then
            If Me.txtCustomer_Code.Text = "" Then
                CheckData = False
                DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
            End If
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Customer "
            strQuery = strQuery & "WHERE company like  N'%" & Me.txtCompany.Text.Trim & "%' And Continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                Dim strMesg As String
                strMesg = "Tên khách hàng này gần giống tên khách hàng trong CSDL. Bạn có muốn thêm không ?"
                If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    CheckData = True
                Else
                    CheckData = False
                End If

                '  DisplayMessage(True, IIf(gLang = "E", "Tên khách hàng này gần giống tên khách hàng trong CSDL, Xin vui lòng đổi lại tên khác.", "Mã Này Đã Có Trong Cơ Sở Dữ Liệu"))
            End If
            rs.Close()
        End If
        'If Len(Me.cobTemperatureId.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Name is invalid. Please check again."
        'End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    Sub QueryUserReport()
        Try
            Dim id As String = "usrID"
            Dim value As String = "UsrDP"
            Dim strQuery As String = "select UsrID,Usr as UsrDP from UserList where discontinued=0"
            loadDataToObject(Me.cboUser, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryMarket()
        Try
            Dim id As String = "Market_ID"
            Dim value As String = "data"
            Dim strQuery As String = "select Market_id,MarketCode + ' - ' + Market as data from Market where continued=1"
            loadDataToObject(Me.cboMarket, strquery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryPIC()
        Try
            Dim id As String = "PIC_ID"
            Dim value As String = "data"
            Dim strQuery As String = "select PIC_ID,PIC as data from Agency where continued=1"
            loadDataToObject(Me.txtPic, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryCommondity()
        Try
            Dim id As String = "Commondity_ID"
            Dim value As String = "data"
            Dim strQuery As String = "select Commondity_id,Commondity as data from Commondity where continued=1"
            loadDataToObject(Me.cboCommondity, strQuery, id, value)
            loadDataToObject(Me.cboCommodity, strQuery, id, value)




            id = "district"
            value = "district"
            Dim SQLqUAN As String
            SQLqUAN = "select distinct district  from customer where continued=1"

            loadDataToObject(Me.cboQuan, SQLqUAN, id, value)
            loadDataToObject(Me.cboquan1, SQLqUAN, id, value)

            id = "PROVINCE"
            value = "PROVINCE"
            Dim SQLPROVINCE As String
            SQLqUAN = "select distinct PROVINCE  from customer where continued=1"

            loadDataToObject(Me.txtProvince, SQLqUAN, id, value)
            loadDataToObject(Me.txtProvince1, SQLqUAN, id, value)


            id = "COUNTRY"
            value = "COUNTRY"
            Dim SQLCOUNTRY As String
            SQLqUAN = "select distinct COUNTRY  from customer where continued=1"

            loadDataToObject(Me.txtCountry, SQLqUAN, id, value)



        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryPort(ByRef cbo As ComboBox)
        Try
            Dim id As String = "Port_ID"
            Dim value As String = "Port"
            Dim strQuery As String = "select * from Port where continued=1 order by port "
            loadDataToObject(cbo, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryAgency()
        Try
            Dim id As String = "Agency_ID"
            Dim value As String = "AgencyName"
            Dim strQuery As String = "select Agency_ID,AgencyName from Agency where continued=1"
            loadDataToObject(Me.cboAgency, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'On Error GoTo Err_Renamed
        'Dim strFilter As String
        'strFilter = MakeFilter(Me.txtCustomer.Text)
        'If Me.txtCustomer.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
        '    FindCombo(Me.txtCustomer.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdCustomer)
        '    '    Select Case Me.cboFind.Text
        '    '        Case "Customer Code"
        '    '            QueryCustomer("AND ( Customer_Code LIKE '" & strFilter & "') " & mFilter)
        '    '            'Me.dgdCustomer.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
        '    '        Case "Company"
        '    '            QueryCustomer("AND (Company LIKE '" & strFilter & "')" & mFilter)
        '    '            UpdateFrame()
        '    '    End Select
        '    'Else
        '    '    QueryCustomer(mFilter)
        'End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Function QueryToolTipText(ByVal CustomerID) As String
        Try
            Dim SQL As String
            SQL = "select PIC,DirectLine From PIC Where Customer_ID='" & CustomerID & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Dim Temp As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                Temp &= dt.Rows(i).Item("Pic").ToString & "   " & dt.Rows(i).Item("DirectLine").ToString & Chr(10)
            Next
            If Temp.Length > 0 Then
                Temp = Temp.Remove(Temp.Length - 1, 1)
            End If
            Return Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Function

    Private Sub frmListCustomer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            txtCustomerRemarks.Visible = True
            Me.txtAccountNo.Visible = True
            Total = 0
            mStatus = "Normal"
            mCommondityStatus = "Normal"
            mPICStatus = "Normal"
            mSaleStatus = "Normal"
            blnUpdated = False
            mCustomer_Id = DefaultValue
            mSaleID = DefaultValue
            strUser = strUserId.Trim
            'If UCase(gDepartment.Trim) = "MANAGEMENT" Then
            '    Me.smnuExportFilter.Visible = True
            'Else
            '    Me.smnuExportFilter.Visible = False
            'End If
            If UCase(gDepartment.Trim) = "BOOKING" Then
                QuyenHan = "BOOKING"
            Else
                QuyenHan = strUserId.Trim
            End If
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.fraUpdate.Visible = False
            'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
            'Dim oItems As PDSAListItemString
            'Me.cboFind.Items.Clear()
            'oItems = New PDSAListItemString
            'oItems.Value = IIf(gLang = "E", "Customer Code", "Customer Code")
            'Me.cboFind.Items.Add(oItems)

            'oItems = New PDSAListItemString
            'oItems.Value = IIf(gLang = "E", "Company", "Company")
            'Me.cboFind.Items.Add(oItems)
            ' LoadComboFind(Me.cboFind, Me.dgdCustomer)

            '  Me.cboFind.Text = objUserSetting.GetCParm("frmListCustomer.cboFind", "DateOfCustomer")
            mFilter = objUserSetting.GetCParm("frmListCustomer.mFilter")
            'Me.txtCustomer_Code.Text = objUserSetting.GetCParm("frmListCustomer.txtCustomer_Code")

            'If Me.txtCustomer.Text <> "" Then
            '    QueryCustomer("AND Customer_Code LIKE '" & MakeFilter(Me.txtCompany.Text) & "' " & mFilter, , 15)
            'Else
            '    QueryCustomer(mFilter, , 15)
            'End If
            'QueryCustomer()
            QueryCommondity()
            QueryMarket()
            QueryPort(Me.cboPOL)
            QueryPort(Me.cboPOD)
            QueryAgency()
            QuerySaleDetail()
            QueryUser()
            QueryUserReport()
            QueryCustomerReport()
            'QueryCustomerBuyer()
            Querycombo()
            'QueryPIC()
            If gOptCurProfile <> "CSCL_IOB" Then
                objProfile.Profile(gOptCurProfile, Me.Name, "Get")
            End If
            'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayAddress")
            'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayTel")
            'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayFax")
            'Me.smnuDisplayATTN.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayATTN")
            'Me.smnuDisplayEmail.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayEmail")
            'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayAPPROVE")
            'Me.smnuDisplayCompany.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayCompany")
            'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayUserId")
            'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListCustomer.smnuDisplayUpdateTime")
            Me.fraUpdate.Visible = False
            UpdateFrame()


            Me.Height = CShort(ctrFrmMain.Height * 0.9)
            Me.Width = CShort(ctrFrmMain.Width * 0.85)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            SetDefaultGrid(Me.dgdCommondity, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdCusReport, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdCustomer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdMarket, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdPIC, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdSale, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdBuyer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
            ReFormat()
            '----set mau nen,fra
            Me.BackColor = gMaunen
            Me.tabBaseinfo.BackColor = gMauFra
            Me.tabMarketInfo.BackColor = gMauFra
            Me.TabPage1.BackColor = gMauFra
            Me.TabPage2.BackColor = gMauFra
            Me.tabPIC.BackColor = gMauFra
            Me.TabSaleDetail.BackColor = gMauFra

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
       

    End Sub
    Private Sub frmListCustomer_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        ' objUserSetting.SetCParm("frmListCustomer.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmListCustomer.Company", Me.txtCompany.Text)
        '   objUserSetting.SetCParm("frmListCustomer.txtCustomer", Me.txtCustomer.Text)
        objUserSetting.SetCParm("frmListCustomer.Company", Me.txtCompany.Text)
        objUserSetting.SetCParm("frmListCustomer.txteMAIL", Me.txtEmail.Text)
        objUserSetting.SetCParm("frmListCustomer.txtAddress", Me.txtAddress.Text)
        objUserSetting.SetCParm("frmListCustomer.txtTel", Me.txtTel.Text)
        objUserSetting.SetCParm("frmListCustomer.txtFax", Me.txtFax.Text)
        objUserSetting.SetCParm("frmListCustomer.txtATTN", Me.txtATTN.Text)


        objUserSetting.SetCParm("frmListCustomer.mFilter", mFilter)

        objUserSetting.SetBParm("frmListCustomer.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayTel", Me.smnuDisplayTel.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayFax", Me.smnuDisplayFax.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayATTN", Me.smnuDisplayATTN.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayeMAIL", Me.smnuDisplayEmail.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayCompany", Me.smnuDisplayCompany.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        objUserSetting.SetBParm("frmListCustomer.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListCustomer.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Function GETSALECODE(ByVal USERNAME As String) As String

        Dim strQuery, _SALECODE As String
        Dim RSSALECODE As New ADODB.Recordset
        strQuery = "SELECT SALECODE FROM SALE WHERE USR='" & USERNAME & "'"
        RSSALECODE.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not RSSALECODE.EOF Then
            _SaleCode = RSSALECODE.Fields("SALECODE").Value.ToString
        Else
            _SALECODE = ""
        End If
        RSSALECODE.Close()
        Return _SALECODE
    End Function
    '==========MakeQuery==========

    Private Function MakeQueryCustomer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomer = strDateOfCustomerSelect
        MakeQueryCustomer = MakeQueryCustomer & " ,birthday,kpis,shortname,addressTiengviet,tilecom,hancongno,sotaikhoan,district, ngaythem,new,pic,commodity,trafic,sea,air,imp,exp,contentofreport,PHUPHICOURIER,pricedem,pricedet,cur From ((((Customer LEFT JOIN CustomerMarket On CustomerMarket.Customer_ID=Customer.Customer_ID)"
        MakeQueryCustomer = MakeQueryCustomer & " LEFT JOIN Market On Market.Market_id=CustomerMarket.Market_ID) "
        MakeQueryCustomer = MakeQueryCustomer & " LEFT JOIN CustomerCommondity On CustomerCommondity.Customer_ID=Customer.Customer_ID) "
        MakeQueryCustomer = MakeQueryCustomer & " LEFT JOIN Commondity On Commondity.Commondity_ID=CustomerCommondity.Commondity_ID) "
        MakeQueryCustomer = MakeQueryCustomer & " WHERE  "
        '        MakeQueryCustomer = MakeQueryCustomer & ""
        MakeQueryCustomer = MakeQueryCustomer & " Customer.Continued = 1 "
        ' lay so lieu tu Option
        Dim strQuery, value As String
        Dim rs As New ADODB.Recordset
        value = "0"
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM [option] "
        strQuery = strQuery & "WHERE frmName = 'frmListCustomer' and OptionCode='PermissionCustomer' And Continued=1 "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        With rs
            If Not rs.EOF Then
                value = .Fields("optionvalue").Value
            End If

        End With
        rs.Close()
        '---------------------------------
        If value = "1" Then
            If UCase(gDepartment) <> "OUTBOUND" And UCase(gDepartment) <> "MANAGEMENT" And UCase(gDepartment) <> "BOOKING" And UCase(gDepartment) <> "ACCOUNT" And UCase(gDepartment) <> "OPERATION" And UCase(gDepartment) <> "SALE MANAGEMENT" And UCase(gDepartment) <> "DOCUMENT" Then
                MakeQueryCustomer = MakeQueryCustomer & " And salename='" & UCase(GETSALECODE(strUser)).Trim & "' and (branch like '%" & gBranch & "%') "
            End If
        End If

        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCustomer = MakeQueryCustomer & argCriteria
        End If
        'If index = 1 Then ' 
        MakeQueryCustomer = MakeQueryCustomer & " order by Customer_code "
        'ElseIf index = 15 Then ' 
        '    MakeQueryCustomer = MakeQueryCustomer & strDateOfCustomerOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function

    Private Function MakeQueryFilter(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryFilter = strDateOfCustomerSelect
        MakeQueryFilter = MakeQueryFilter & " ,kpis,birthday,shortname,addressTiengviet From Customer"
        MakeQueryFilter = MakeQueryFilter & " WHERE Customer_ID IN  " & _
                                                "(Select Customer.Customer_ID " & _
                                                "From ((((((Customer Left JOIN CustomerMarket on CustomerMarket.Customer_ID=Customer.Customer_ID) " & _
                                                "LEFT JOIN Market on CustomerMarket.Market_ID=Market.Market_ID) " & _
                                                "LEFT JOIN CustomerCommondity on Customer.Customer_ID=CustomerCommondity.Customer_ID) " & _
                                                "LEFT JOIN Commondity on CustomerCommondity.Commondity_ID=Commondity.Commondity_ID) " & _
                                                "LEFT JOIN DESTINATION ON DESTINATION.Market_ID=Market.Market_ID) " & _
                                                "LEFT JOIN PIC ON PIC.Customer_ID=Customer.Customer_ID )" & _
  "LEFT JOIN BUYER ON BUYER.Customer_ID=Customer.Customer_ID " & _
                                                "Where Customer.continued=1 " & argCriteria & _
                                                ")"


        MakeQueryFilter = MakeQueryFilter & ""
        ' MakeQueryFilter = MakeQueryFilter & " and Continued = 1 "
        'If QuyenHan <> "BOOKING" Then
        'MakeQueryFilter = MakeQueryFilter & " And QuyenHan='" & QuyenHan & "' "
        'End If

        'If index = 1 Then ' 
        '    MakeQueryCustomer = MakeQueryCustomer & strDateOfCustomerOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryCustomer = MakeQueryCustomer & strDateOfCustomerOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function

    '==========Menu==========
    'Public Function CodeDateOfCustomer() As Integer
    '    Dim rsCount As New ADODB.Recordset
    '    Dim code As Integer
    '    rsCount.Open("select Count(Customer_Code) as CountNo from Customer", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    code = rsCount.Fields("CountNo").Value
    '    Return code
    'End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("mnumarketingsale", "Add") Then
            ' Me.txtCustomer.Enabled = True
            Me.txtCustomer_Code.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdCustomer.Enabled = False
            ReFormat()
            SetMenu((False))
            SetPicItem(False)
            SetCommondityItem(False)
            SetSaleItem(False)
            SetCusRptItem(False)
            mCustomer_Id = DefaultValue
            QueryCustomerMarket()
            QueryCustomerCommondity()
            QueryCustomerPIC()
            QuerySaleDetail()
            QueryCustomerReport()
            mStatus = "Add"
            reText(mStatus)
            Me.chkSale.Checked = False
            Me.chkSale_CheckedChanged(eventSender, eventArgs)
         
            Me.txtCustomer_Code.Text = ""
            Me.cboSale.Text = ""
            Me.txtMainCode.Text = ""
            Me.cbokpis.Text = ""

            Me.txtshortname.Text = ""
            Me.txtCompany.Text = ""
            Me.txtEnglishName.Text = ""
            Me.txtEmail.Text = ""
            Me.txtFax.Text = ""
            Me.txtTel.Text = ""
            Me.txtAddresstiengviet.Text = ""
            Me.txtAddress.Text = ""
            Me.ATTN.ToolTipText = ""
            txtTaxCode.Text = ""
            txtRemarks.Text = ""
            txtAccountNo.Text = ""
            Dim ctr As Control
            For Each ctr In Me.Controls ' DEBIT
                If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                    ctr.Text = ""
                End If
            Next


            'Me.txtCustomer.Text = Me.txtCustomer.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Function getCusID() As String
        Dim strSQL As String
        strSQL = "select count (*) as ID from customer "
        Dim dtSer As New DataTable
        dtSer = ReadTable(strSQL)
        Return CInt(dtSer.Rows(0).Item(0).ToString)


    End Function
    Function getCusID_byNumber() As String
        Dim strSQL As String
        Dim ds As New DataSet
        Dim code As Integer
        Dim tam As String
        strSQL = "select customer_code from customer where updatetime in ( select max(updatetime) from customer )  "
        ds = ReadDataSet(strSQL)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim sql1 As String
            tam = ds.Tables(0).Rows(0).Item("customer_code").ToString
            'tam = tam.Replace("0", "")
            Try
                code = CInt(tam)
            Catch ex As Exception
                code = tam
            End Try

        End If

        Return CInt(code)


    End Function
    Sub QueryCustomerMarket()
        Try
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select CustomerMarket_Id,MarketCode,Market,Customer_Code,EnglishName,COMPANY , exim,country_MARKET, port "
            strSQL &= " From ((CustomerMarket LEFT JOIN Customer on Customer.Customer_ID=CustomerMarket.Customer_ID) "
            strSQL &= " LEFT JOIN Market on CustomerMarket.Market_ID=Market.Market_ID)"
            strSQL &= " Where CustomerMarket.continued=1 And CustomerMarket.Customer_ID='" & mCustomer_Id & "'"
            'Conn.Open()
            'Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'If Not IsNothing(oTableMarket) Then
            '    'oTableMarket.Clear()
            'End If
            'Adapter.Fill(oTableMarket)
            otableCusID = ReadTable(strSQL)
            Me.dgdMarket.DataSource = otableCusID

        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub QueryCustomerCommondity()
        Try
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select CustomerCommondity.CustomerCommondity_ID,Commondity.Commondity_ID,Commondity,Commondity.Remarks as CommondityRemarks,CustomerCommondity.Remarks as CustomerCommondityRemarks,Customer_Code,From_Date,To_Date,Season,Min_tueMonth,AVG_tueMonth,Max_tueMonth,EnglishName,COMPANY "
            strSQL &= " From ((CustomerCommondity LEFT JOIN Customer on Customer.Customer_ID=CustomerCommondity.Customer_ID) "
            strSQL &= " LEFT JOIN Commondity on CustomerCommondity.Commondity_ID=Commondity.Commondity_ID)"
            strSQL &= " Where CustomerCommondity.continued=1 And CustomerCommondity.Customer_ID='" & mCustomer_Id & "'"
            'Conn.Open()
            'Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'If Not IsNothing(oTableCommondity) Then
            '    'oTableCommondity.Clear()
            'End If
            'Adapter.Fill(oTableCommondity)
            oTableCommondity = ReadTable(strSQL)
            Me.dgdCommondity.DataSource = oTableCommondity
            InsertAutoNumberToGrid(Me.dgdCommondity)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub QueryCustomerPIC()
        Try
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select PIC_ID,pic.PIC,Pos,DirectLine,pic.Fax,Customer_Code,EnglishName,COMPANY,pic.email,hp  "
            strSQL &= " From (PIC LEFT JOIN Customer on Customer.Customer_ID=PIC.Customer_ID) "
            strSQL &= " Where PIC.continued=1 And PIC.Customer_ID='" & mCustomer_Id & "'"
            'Conn.Open()
            'Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'If Not IsNothing(oTablePIC) Then
            '    'oTablePIC.Clear()
            'End If
            'Adapter.Fill(oTablePIC)
            oTablePIC = ReadTable(strSQL)
            Me.dgdPIC.DataSource = oTablePIC
            InsertAutoNumberToGrid(Me.dgdPIC)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Public Sub ApproveCustomer()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCustomer.CurrentRow.Index
        Dim strQueryCustomerList As String
        If Not Me.dgdCustomer.Item("Editable", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryCustomer(, , index)
        Else
            strQueryCustomerList = "Select * from Customer where" + " Customer_Id= '" & dgdCustomer.Item("Customer_Id", index).Value.ToString & "'"
            rsCustomerList.Open(strQueryCustomerList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsCustomerList.Fields("Approve").Value
            rsCustomerList.Update("Approve", Approve)
            rsCustomerList.Close()
        End If
        QueryCustomer(mFilter, , index)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Public Sub ApproveCustomerPayer()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCustomer.CurrentRow.Index
        Dim strQueryCustomerList As String
        If Not Me.dgdCustomer.Item("Editable", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryCustomer(, , index)
        Else
            strQueryCustomerList = "Select * from Customer where" + " Customer_Id= '" & dgdCustomer.Item("Customer_Id", index).Value.ToString & "'"
            rsCustomerList.Open(strQueryCustomerList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsCustomerList.Fields("ApprovePayer").Value
            rsCustomerList.Update("ApprovePayer", Approve)
            rsCustomerList.Close()
        End If
        QueryCustomer(mFilter, , index)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub ApproveBuyerA()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdBuyer.CurrentRow.Index
        Dim rs As New ADODB.Recordset
        Dim strQueryCustomerList As String
        If Not Me.dgdBuyer.Item("editableBuyer", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryCustomerList = "Select * from buyer where" + " buyerId= '" & dgdBuyer.Item("buyerid", index).Value.ToString & "'"
            rs.Open(strQueryCustomerList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Me.QueryCustomerBuyer(index)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub ApproveSale()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdSale.CurrentRow.Index
        Dim rs As New ADODB.Recordset
        Dim strQueryCustomerList As String
        If Not Me.dgdSale.Item("SaleEditable", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryCustomerList = "Select * from Booking where" + " Booking_Id= '" & dgdSale.Item("SaleDetail_ID", index).Value.ToString & "'"
            rs.Open(strQueryCustomerList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QuerySaleDetail(index)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        Dim cmd As New ADODB.Command
        strQuery = "Select count(*) cnt from taxinvoice WHERE Customer_Id = '" & Me.dgdCustomer.Item("Customer_Id", index).Value.ToString & "'  "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)

        rs.Close()
        'strQuery = "Select * from Customer WHERE Customer_Id = '" & Me.dgdCustomer.Item("Customer_Id", index).Value.ToString & "' And UserId='DBO'"
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEOF = rs.EOF
        'rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, The Customer can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
        '    Exit Sub
        'End If
        'che tam vi chua co quan he voi Dulieu khac

        If Not blnEmpty Then
            DisplayMessage(True, "The Customer can not be removed. There are transactions that relate to this customer.")
            Exit Sub
        End If

        If Not IsNothing(Me.dgdCustomer.Item("Approve", index).Value) Then
            If Me.dgdCustomer.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdCustomer.Item("Editable", index).Value) Then
            If Not Me.dgdCustomer.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnumarketingsale", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Customer : " & Me.dgdCustomer.Item("Customer_Code", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Customer where" + " Customer_Id= '" & Me.dgdCustomer.Item("Customer_Id", index).Value.ToString & "'"
                rsCustomerList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsCustomerList.Fields("continued").Value = 0
                rsCustomerList.Update()
                rsCustomerList.Requery()
                Me.dgdCustomer.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdCustomer.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsCustomerList.Close()
                blnUpdated = True
                'cmd.let_ActiveConnection(strconn)
                'cmd.CommandText = "delete from Customer where" + " Customer_Id= '" & Me.dgdCustomer.Item("Customer_Id", index).Value.ToString & "'"

                'cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdCustomer.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdCustomer.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryCustomer(mFilter)
    End Sub

#Region "ViewMenuStrip"


    Private Sub smnuDisplayCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCompany.Click
        Me.smnuDisplayCompany.Checked = Not Me.smnuDisplayCompany.Checked
        UpdateFrame()

    End Sub


    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub



    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub
    Private Sub smnuDisplayAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayAddress.Click
        Me.smnuDisplayAddress.Checked = Not Me.smnuDisplayAddress.Checked
        UpdateFrame()

    End Sub


    Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
        Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayEmail.Click
        Me.smnuDisplayEmail.Checked = Not Me.smnuDisplayEmail.Checked
        UpdateFrame()
    End Sub
    Private Sub smnuDisplayFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFax.Click
        Me.smnuDisplayFax.Checked = Not Me.smnuDisplayFax.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayATTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayATTN.Click
        Me.smnuDisplayATTN.Checked = Not Me.smnuDisplayATTN.Checked
        UpdateFrame()
    End Sub
#End Region

#Region "Xuly"
    Function CheckBooking(ByVal index As Integer) As Boolean
        Try
            Dim tbl As DataTable
            tbl = ReadTable("Select SaleName,QuyenHan From Customer where Customer_ID='" & Me.dgdCustomer.Item("Customer_ID", index).Value.ToString & "'")
            If tbl.Rows.Count = 0 Then
                Return False
            End If
            If UCase(tbl.Rows(0).Item("SaleName")) = UCase(strUser) Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Me.dgdCustomer.Rows.Count = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            Return
        End If

        Dim index As Integer = Me.dgdCustomer.CurrentRow.Index
        If index >= 0 Then

            Approve = Me.dgdCustomer.Item("Approve", index).Value
            EditTable = Me.dgdCustomer.Item("Editable", index).Value

            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") Then
                'If QuyenHan = "BOOKING" Then
                '    If CheckBooking(index) = False Then
                '        MsgBox("Booking chỉ có thể thay đổi thông tin về khách hàng của mình")
                '        Return
                '    End If
                'End If
                Me.dgdCustomer.Height = 306
                'Me.txtCustomer_Code.Enabled = False
                Me.dgdCustomer.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", index).Value.ToString
                SetPicItem(False)
                SetCommondityItem(False)
                SetSaleItem(False)
                SetCusRptItem(False)
                QueryCustomerMarket()
                QueryCustomerCommondity()
                QueryCustomerPIC()
                QuerySaleDetail()
                QueryCustomerReport()
                Me.QueryCustomerBuyer()
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
                Me.chkSale_CheckedChanged(eventSender, eventArgs)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "List Of Customer"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Customer  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Customer -> Add."
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========Query==========

    Private Sub QueryCustomer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCustomer()
        Else
            strQuery = MakeQueryCustomer(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "CustomerList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdCustomer.DataSource = ds.Tables("CustomerList")
        If Me.dgdCustomer.Enabled = False Then
            Me.dgdCustomer.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdCustomer.Columns.Item("Customer_Code").ToolTipText = "Hiện có:" + CStr(Me.dgdCustomer.RowCount()) + " Customers."
        End If
        If Me.dgdCustomer.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        'If location > 0 And location <= Me.dgdCustomer.Rows.Count And Me.dgdCustomer.Rows.Count > 0 Then
        '    Me.dgdCustomer.Rows(location).Selected = True
        '    Me.dgdCustomer.CurrentCell = Me.dgdCustomer.Rows(location).Cells(2)
        'End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdCustomer)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & ", bạn nên dùng menu View để hiển thị hết toàn bộ thông tin trong Bảng dữ liệu, ")
        'Resume
    End Sub

    Private Sub QueryFilterData(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryFilter()
        Else
            strQuery = MakeQueryFilter(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "CustomerList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdCustomer.DataSource = ds.Tables("CustomerList")
        If Me.dgdCustomer.Enabled = False Then
            Me.dgdCustomer.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdCustomer.Rows.Count And Me.dgdCustomer.Rows.Count > 0 Then
            Me.dgdCustomer.Rows(location).Selected = True
            Me.dgdCustomer.CurrentCell = Me.dgdCustomer.Rows(location).Cells(3)
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdCustomer.Columns.Item("Customer_Code").ToolTipText = "Hiện có:" + CStr(Me.dgdCustomer.RowCount()) + " Customers."
        End If
        If Me.dgdCustomer.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        Me.dgdCustomer.Columns.Item("Address").Visible = True
        Me.dgdCustomer.Columns.Item("ATTN").Visible = True
        Me.dgdCustomer.Columns.Item("Email").Visible = True
        Me.dgdCustomer.Columns.Item("Tel").Visible = True
        Me.dgdCustomer.Columns.Item("Fax").Visible = True

        Me.dgdCustomer.Columns.Item("Customer_Id").Visible = False
        Me.dgdCustomer.Columns.Item("Company").Visible = True

        Me.dgdCustomer.Columns.Item("Editable").Visible = False
        Me.dgdCustomer.Columns.Item("Continued").Visible = False
        Me.dgdCustomer.Columns.Item("Approve").Visible = True

        Me.dgdCustomer.Columns.Item("UserId").Visible = True
        Me.dgdCustomer.Columns.Item("UpdateTime").Visible = True

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - Me.Top - 10
        Me.Width = frmMain.Width - 8
        dgdCustomer.Width = (Me.Width - 30)
        If Me.Width > 610 Then
            dgdCustomer.Height = Me.Height - 150 - IIf(fraUpdate.Visible, fraUpdate.Height - Me.cmdCancel.Height - 10, 5) '> 7000
        Else
            dgdCustomer.Height = Me.Height - 200 - IIf(fraUpdate.Visible, fraUpdate.Height - Me.cmdCancel.Height - 10, 38) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdCustomer.Bottom + 10
        'Me.fraUpdate.Top = Me.dgdContainerMNG.Bottom + 10

        'Me.fraUpdate.Width = (Me.Width - 25)

        '  Me.txtCustomer.Width = Me.Width - 300

        'cmdOK.Top = Me.fraUpdate.Bottom
        'cmdCancel.Top = cmdOK.Top

        ' cmdFind.Left = Me.txtCustomer.Left + Me.txtCustomer.Width + 10
        ' txtCustomer.Width = Me.Width - 297

        Exit Sub
Err:
        DisplayMessage(True, Err.Description)

    End Sub

    Private Sub dgdCustomer_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCustomer.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCustomer.RowCount = 0 Then
            Return
        End If
        index = Me.dgdCustomer.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdCustomer.Columns(ColIndex).Name = "Approve" And Me.dgdCustomer.CurrentCellAddress().Y = index Then
            Call ApproveCustomer()
        ElseIf Me.dgdCustomer.Columns(ColIndex).Name = "ApprovePayer" And Me.dgdCustomer.CurrentCellAddress().Y = index Then
            ApproveCustomerPayer()

        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdCustomer_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdCustomer.CellMouseClick
        Try
            If Me.dgdCustomer.RowCount = 0 Then
                Return
            End If
            Dim Index As Integer = Me.dgdCustomer.CurrentRow.Index
            Dim ToolTipText As String
            ToolTipText = QueryToolTipText(Me.dgdCustomer.Item("Customer_ID", Index).Value.ToString)
            If ToolTipText.Trim = "" Then
                Return
            End If
            Me.dgdCustomer.CurrentCell.ToolTipText = ToolTipText
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdCustomer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdCustomer.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryCustomer("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdCustomer)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdCustomer.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdCustomer.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdCustomer.SelectedRows(i).Index)
                Next i
            End If

            QueryCustomer()
        End If
    End Sub
    'Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
    '        Me.cboFind.SelectedIndex = 0
    '        Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
    '    End If
    'End Sub

    Private Sub RefreshData(ByVal index As Integer)
        Try

      
            Dim oItems As PDSAListItemString

            Try
                Me.txtbirthday.Text = Me.dgdCustomer.Item("birthday", index).Value.ToString
            Catch ex As Exception

            End Try

            '--------------------
            Me.txttilecom.Text = Me.dgdCustomer.Item("tilecom", index).Value.ToString
            '-----------------
            Me.txtAccountNo.Text = Me.dgdCustomer.Item("sotaikhoan", index).Value.ToString
            Me.txthancongno.Text = Me.dgdCustomer.Item("hancongno", index).Value.ToString

            Me.cboQuan.Text = Me.dgdCustomer.Item("district", index).Value.ToString
            Me.dtpAdd.Value = Me.dgdCustomer.Item("ngaythem", index).Value.ToString
            Me.chkNew.Checked = Me.dgdCustomer.Item("newadd", index).Value
            Me.txtPICAdd.Text = Me.dgdCustomer.Item("PICAdd", index).Value.ToString

            Me.txtCommodity.Text = Me.dgdCustomer.Item("commodityadd", index).Value.ToString
            Me.txtTrafic.Text = Me.dgdCustomer.Item("trafic", index).Value.ToString
            Me.txtSea.Text = Me.dgdCustomer.Item("sea", index).Value.ToString
            Me.txtAir.Text = Me.dgdCustomer.Item("air", index).Value.ToString

            Me.txtIMP.Text = Me.dgdCustomer.Item("imp", index).Value.ToString
            Me.txtexp.Text = Me.dgdCustomer.Item("exp", index).Value.ToString
            Me.txtContentOfReport.Text = Me.dgdCustomer.Item("contentofreport", index).Value.ToString

            '---------------------------
            Me.txtTaxCode.Text = Me.dgdCustomer.Item("TaxCode", index).Value.ToString
            Me.txtCustomer_Code.Text = Me.dgdCustomer.Item("Customer_Code", index).Value.ToString
            Me.txtCompany.Text = Me.dgdCustomer.Item("Company", index).Value.ToString
            Me.txtEmail.Text = Me.dgdCustomer.Item("Email", index).Value.ToString
            Me.txtAddress.Text = Me.dgdCustomer.Item("Address", index).Value.ToString
            Me.txtAddresstiengviet.Text = Me.dgdCustomer.Item("Addresstiengviet", index).Value.ToString


            Me.txtTel.Text = Me.dgdCustomer.Item("Tel", index).Value.ToString
            Me.txtFax.Text = Me.dgdCustomer.Item("Fax", index).Value.ToString
            Me.txtATTN.Text = Me.dgdCustomer.Item("ATTN", index).Value.ToString
            Me.txtEnglishName.Text = Me.dgdCustomer.Item("EnglishName", index).Value.ToString
            Me.txtBIZname.Text = Me.dgdCustomer.Item("BIZName", index).Value.ToString
            Me.txtWeb.Text = Me.dgdCustomer.Item("Web", index).Value.ToString
            Me.txtNationality.Text = Me.dgdCustomer.Item("Nationality", index).Value.ToString
            Me.txtProvince.Text = Me.dgdCustomer.Item("Province", index).Value.ToString
            Me.txtCountry.Text = Me.dgdCustomer.Item("Country", index).Value.ToString
            Me.cboDepartment.Text = Me.dgdCustomer.Item("Type", index).Value.ToString
            Me.txtIndustry.Text = Me.dgdCustomer.Item("Industry", index).Value.ToString
            Me.txtCustomerRemarks.Text = Me.dgdCustomer.Item("Remarks_Customer", index).Value.ToString
            Me.txtRemarks.Text = Me.dgdCustomer.Item("Remarks_sale", index).Value.ToString
            Me.txtAccountPotantial.Text = Me.dgdCustomer.Item("AccountPotantial", index).Value.ToString
            Me.txtSale.Text = Me.dgdCustomer.Item("salename", index).Value.ToString
            '''''''''''12-9-2007
            Me.txtMainCode.Text = Me.dgdCustomer.Item("MainCode", index).Value.ToString
            Me.txtphuphiCourier.Text = Me.dgdCustomer.Item("phuphicourier", index).Value.ToString
            Me.txtVipCode.Text = Me.dgdCustomer.Item("VipCode", index).Value.ToString
            If Me.dgdCustomer.Item("SaleName", index).Value.ToString = "" Then
                Me.chkSale.Checked = False
                Me.txtSale.Text = ""
            Else
                Me.chkSale.Checked = True
                Me.cboSale.Text = Me.dgdCustomer.Item("SaleName", index).Value.ToString
            End If
            Me.cbokpis.Text = Me.dgdCustomer.Item("kpis", index).Value.ToString
            Me.txtshortname.Text = Me.dgdCustomer.Item("shortname", index).Value.ToString
            Try
                Me.txtpriceDEM.Text = Me.dgdCustomer.Item("pricedem", index).Value.ToString
                Me.txtPriceDET.Text = Me.dgdCustomer.Item("pricedet", index).Value.ToString
            Catch ex As Exception

            End Try
            Try
                Me.cboCur.Text = Me.dgdCustomer.Item("cur", index).Value.ToString
            Catch ex As Exception

            End Try


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Private Sub frmListCustomer_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try

        
            Dim strQuery, strSale, strCustomer_Id, pName As String
            Dim rs As New ADODB.Recordset
            Dim rsSale As New ADODB.Recordset
            Dim index As Integer
            If Me.txtMainCode.Text = "" Then
                DisplayMessage(True, "Xin lưu ý, Main Code không được rỗng. ")
                Return
            End If
            If Me.dgdCustomer.Rows.Count > 0 Then
                index = Me.dgdCustomer.CurrentRow.Index
            End If
            If Me.txtCompany.Text Like "*-*" Then
                DisplayMessage(True, "Xin lưu ý, Company không được có kí tự '-'.! ")
                ' Return
            End If
            If Me.txtCompany.Text Like "*'*" Then
                DisplayMessage(True, "Xin lưu ý, Company không được có kí tự '.! ")
                Return
            End If
            If Me.txtEnglishName.Text Like "*'*" Then
                DisplayMessage(True, "Xin lưu ý, Company không được có kí tự '.! ")
                Return
            End If


            If Me.txtTaxCode.Text.ToString.Length > 14 Then
                DisplayMessage(True, "Xin lưu ý, Tax code không đúng .! ")
                Return
            End If
            If Me.cbokpis.Text = "" Then
                DisplayMessage(True, "Xin lưu ý, Status không đúng .! ")
                Return
            End If
            '---------------  
            Dim seri As Integer
            Dim temp As String
            If mStatus = "Add" Then
                seri = CDbl(getCusID_byNumber()) + 1
                For h As Integer = seri.ToString.Length To 5
                    temp &= "0"
                Next
                temp &= seri
                Me.txtCustomer_Code.Text = temp
            End If
            If mStatus = "Add" Then
                Try
                    Dim sqlmst As String
                    Dim dsmst As New DataSet
                    sqlmst = "select * from customer where taxcode='" & Me.txtTaxCode.Text.Trim & "' "
                    dsmst = ReadDataSet(sqlmst)
                    If dsmst.Tables(0).Rows.Count > 0 Then
                        DisplayMessage(True, "MST đã có trong hệ thống.!")
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
            End If


            '------------------
            If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
                Try
                    copyHistory("Customer", "Customer_Id", mCustomer_Id, "history")
                Catch ex As Exception

                End Try
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Customer "
                strQuery = strQuery & "WHERE Customer_Id = '" & mCustomer_Id & "' AND Customer_Id <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("Customer_Id").Value = NewId()
                        '  strCustomer_Id = .Fields("Customer_Id").Value
                        'If UCase(gDepartment) = "SALE" Then

                        'End If
                    End If
                    'If Me.chkSale.Checked = True Then
                    'strSale = "Select * from Sale where usr='" & Me.cboSale.Text.Trim & "' and continued=1"
                    'rsSale.Open(strSale, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    'If Not rsSale.EOF Then
                    Try
                        .Fields("birthday").Value = Me.txtbirthday.Text
                    Catch ex As Exception

                    End Try

                    .Fields("SALENAME").Value = Me.cboSale.Text.Trim
                    .Fields("shortName").Value = Me.txtshortname.Text.Trim
                    '        End If
                    'rsSale.Close()
                    'Else
                    '.Fields("SALENAME").Value = ""
                    'End If
                    .Fields("district").Value = Me.cboQuan.Text
                    .Fields("QuyenHan").Value = UCase(QuyenHan.Trim)
                    .Fields("hancongno").Value = Me.txthancongno.Text
                    ' them branch
                    Try
                        .Fields("branch").Value = gBranch
                    Catch ex As Exception
                        DisplayMessage(True, "Branch cần được thêm vào Table Customer.")
                    End Try
                    '==============================================
                    '-------------------081013
                    .Fields("tilecom").Value = Me.txttilecom.Text
                    '-------------------
                    strCustomer_Id = .Fields("Customer_Id").Value
                    '-------------
                    .Fields("ngaythem").Value = Me.dtpAdd.Value '= Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("new").Value = Me.chkNew.Checked '= Me.dgdCustomer.Item("", index).Value
                    .Fields("PIC").Value = Me.txtPICAdd.Text '= Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("sotaikhoan").Value = Me.txtAccountNo.Text
                    .Fields("commodity").Value = Me.txtCommodity.Text '= Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("trafic").Value = Me.txtTrafic.Text ' = Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("sea").Value = Me.txtSea.Text '= Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("air").Value = Me.txtAir.Text '= Me.dgdCustomer.Item("", index).Value.ToString

                    .Fields("imp").Value = Me.txtIMP.Text '= Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("exp").Value = Me.txtexp.Text '= Me.dgdCustomer.Item("", index).Value.ToString
                    .Fields("contentofreport").Value = Me.txtContentOfReport.Text '= Me.dgdCustomer.Item("", index).Value.ToString
                    '------------------------------
                    .Fields("Fax").Value = Me.txtFax.Text
                    .Fields("Email").Value = Me.txtEmail.Text
                    .Fields("ATTN").Value = Me.txtATTN.Text


                    .Fields("Addresstiengviet").Value = Me.txtAddresstiengviet.Text
                    .Fields("Address").Value = Me.txtAddress.Text
                    .Fields("Tel").Value = Me.txtTel.Text
                    .Fields("Customer_Code").Value = Me.txtCustomer_Code.Text
                    .Fields("Company").Value = Me.txtCompany.Text
                    .Fields("EnglishName").Value = Me.txtEnglishName.Text
                    .Fields("BIZName").Value = Me.txtBIZname.Text
                    .Fields("Web").Value = Me.txtWeb.Text
                    .Fields("Nationality").Value = Me.txtNationality.Text
                    .Fields("Province").Value = Me.txtProvince.Text
                    .Fields("Customer_Code").Value = Me.txtCustomer_Code.Text
                    .Fields("Country").Value = Me.txtCountry.Text
                    .Fields("Type").Value = Me.cboDepartment.Text
                    .Fields("Industry").Value = Me.txtIndustry.Text
                    .Fields("Remarks_Customer").Value = Me.txtCustomerRemarks.Text ' doi lai dung lam bien theo doi cong no ve freight
                    .Fields("Remarks_sale").Value = Me.txtRemarks.Text
                    .Fields("AccountPotantial").Value = Me.txtAccountPotantial.Text
                    .Fields("MainCode").Value = Me.txtMainCode.Text
                    .Fields("VIPCode").Value = Me.txtVipCode.Text
                    .Fields("TaxCode").Value = Me.txtTaxCode.Text
                    .Fields("phuphicourier").Value = Me.txtphuphiCourier.Text
                    .Fields("kpis").Value = Me.cbokpis.Text
                    'try
                    Try
                        .Fields("priceDEM").Value = Me.txtpriceDEM.Text
                    Catch ex As Exception

                    End Try
                    Try
                        .Fields("priceDET").Value = Me.txtPriceDET.Text
                    Catch ex As Exception

                    End Try

                    .Fields("cur").Value = Me.cboCur.Text
                    .Update()

                End With
                rs.Close()
                '===================================================================
                Dim cmd1 As New ADODB.Command
                Dim strconn1, strServer1, strUserName1, strPassword1, strDatabase1 As String
                strServer1 = "vietnamforwarder.com"
                strUserName1 = "admin"
                strPassword1 = "qwe123!@#"
                strDatabase1 = "smf"
                strconn1 = "Provider=sqloledb;Data Source='" & strServer1 & "'; User ID='" & strUserName1 & "'; password='" & strPassword1 & "'; Initial Catalog='" & strDatabase1 & "'"
                Try

                    cmd1.let_ActiveConnection(strconn1)
                    cmd1.CommandText = "INSERT customer"
                    cmd1.CommandText = cmd1.CommandText & "(TaxCode,Company,Address,Addresstiengviet) "
                    cmd1.CommandText = cmd1.CommandText & "VALUES ('" & Me.txtTaxCode.Text & "','" & Me.txtCompany.Text & "','" & Me.txtAddress.Text & "','" & Me.txtAddresstiengviet.Text & "') "
                    'Debug.Print cmd.CommandText
                    cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                Catch ex As Exception
                    'DisplayMessage(True, Err.Description)
                End Try
                '============================================================================
                Me.dgdCustomer.Enabled = True
                'If mStatus = "Edit" Then
                QueryCustomer(" AND CUSTOMER_CODE='" & Me.txtCustomer_Code.Text & "'", , index)
                'End If
                Me.fraUpdate.Visible = False
                ReFormat()
                SetMenu((True))
                mStatus = "Normal"
                reText(mStatus)
                blnUpdated = True
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdCustomer.Enabled = True
        Exit Sub

Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub fraUpdate1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '    Me.fraUpdate.Visible = Me.fraUpdate1.Visible
        '    Me.cmdCancel.Visible = Me.fraUpdate1.Visible
        '    Me.cmdOK.Visible = Me.fraUpdate1.Visible
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub fraUpdate_VisibleChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Try
            Me.fraUpdate.Visible = Me.fraUpdate.Visible
            Me.cmdCancel.Visible = Me.fraUpdate.Visible
            Me.cmdOK.Visible = Me.fraUpdate.Visible
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdMarketOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMarketOk.Click
        Try
            Dim strQuery, strCustomer_Id, pName As String
            Dim rs As New ADODB.Recordset
            Dim mCUSTOMERMARKET As String
            Dim index As Integer
            If mCustomer_Id = DefaultValue Then
                MsgBox("Please input Customer")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            'If (Me.dgdMarket.RowCount > 0) Then
            '    index = Me.dgdMarket.CurrentRow.Index
            '    mCUSTOMERMARKET = Me.dgdMarket.Item("CUSTOMERMARKET_ID", index).Value.ToString
            'Else
            mCUSTOMERMARKET = DefaultValue
            'End If

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CUSTOMERMARKET "
            strQuery = strQuery & "WHERE CUSTOMER_ID = '" & mCustomer_Id & "' AND Market_Id = '" & FindValueID(Me.cboMarket, Me.cboMarket.Text) & "' and continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                MsgBox("This record has already in database")
                Exit Sub
            End If
            rs.Close()

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CUSTOMERMARKET "
            strQuery = strQuery & "WHERE CustomerMarket_Id = '" & mCUSTOMERMARKET & "' AND CustomerMarket_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CUSTOMERMARKET_ID").Value = NewId()
                    .Fields("Customer_ID").Value = "{" & mCustomer_Id & "}"
                    .Fields("exim").Value = Me.cboExIm.Text
                    .Fields("country_MARKET").Value = Me.txtMarketCountry.Text
                    .Fields("port").Value = Me.txtmarketPort.Text
                End If
                .Fields("Market_ID").Value = "{" & FindValueID(Me.cboMarket, Me.cboMarket.Text) & "}"
                .Update()
            End With
            rs.Close()

            QueryCustomerMarket()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCommondityOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCommondityOk.Click
        Try
            If mCommondityStatus = "Add" Or mCommondityStatus = "Edit" Then

                Dim strQuery, strCustomer_Id, pName As String
                Dim rs As New ADODB.Recordset
                Dim index As Integer
                'If (Me.dgdCommondity.RowCount > 0) Then
                '    index = Me.dgdCommondity.CurrentRow.Index
                '    mCustomerCommondity = Me.dgdMarket.Item("CustomerCommondity_ID", index).Value.ToString
                'Else

                'End If
                If Me.dgdCommondity.RowCount > 0 Then
                    index = Me.dgdCommondity.CurrentRow.Index
                End If
                If IsNumeric(Me.txtMinTue.Text.Trim) = False Then
                    MsgBox("The Min (Tue/month) is invalid")
                    Return
                End If
                If IsNumeric(Me.txtMaxTue.Text.Trim) = False Then
                    MsgBox("The Max (Tue/month) is invalid")
                    Return
                End If
                If IsNumeric(Me.txtAveTue.Text.Trim) = False Then
                    MsgBox("The Ave (Tue/month) is invalid")
                    Return
                End If

                'If mCommondityStatus = "Add" Then
                '    strQuery = "SELECT * "
                '    strQuery = strQuery & "FROM CustomerCommondity "
                '    strQuery = strQuery & "WHERE Customer_id = '" & mCustomer_Id & "' AND Commondity_ID = '" & FindValueID(Me.cboCommondity, Me.cboCommondity.Text) & "' and continued=1 "
                '    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                '    If Not rs.EOF Then
                '        MsgBox("This record has already in database")
                '        Exit Sub
                '    End If
                '    rs.Close()
                'End If


                strQuery = "SELECT * "
                strQuery = strQuery & "FROM CustomerCommondity "
                strQuery = strQuery & "WHERE CustomerCommondity_Id = '" & mCustomerCommondity & "' AND CustomerCommondity_Id <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If mCommondityStatus = "Add" Then
                        .AddNew()
                        .Fields("CustomerCommondity_ID").Value = NewId()
                        .Fields("Customer_ID").Value = "{" & mCustomer_Id & "}"
                    End If
                    .Fields("Commondity_ID").Value = "{" & FindValueID(Me.cboCommondity, Me.cboCommondity.Text) & "}"
                    .Fields("Remarks").Value = Me.txtCommondityRemarks.Text.Trim
                    .Fields("Season").Value = Me.txtSeason.Text
                    .Fields("Min_tueMonth").Value = CDbl(Me.txtMinTue.Text.Trim)
                    .Fields("Max_tueMonth").Value = CDbl(Me.txtMaxTue.Text.Trim)
                    .Fields("Avg_tueMonth").Value = CDbl(Me.txtAveTue.Text.Trim)

                    If Me.chkFrom.Checked = True Then
                        .Fields("From_Date").Value = Me.dtpFromDate.Value.Date
                    Else
                        .Fields("From_Date").Value = Nothing
                    End If

                    If Me.chkTo.Checked = True Then
                        .Fields("To_Date").Value = Me.dtpToDate.Value.Date
                    Else
                        .Fields("To_Date").Value = Nothing
                    End If

                    .Update()
                End With
                rs.Close()

                QueryCustomerCommondity()
                SetCommondityItem(False)
                mCommondityStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdPICOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPICOk.Click
        Try
            If mPICStatus = "Add" Or mPICStatus = "Edit" Then

                Dim strQuery, strCustomer_Id, pName As String
                Dim rs As New ADODB.Recordset

                'If (Me.dgdPIC.RowCount > 0) Then
                '    index = Me.dgdPIC.CurrentRow.Index
                '    mCustomerPIC = Me.dgdPIC.Item("PIC_ID", index).Value.ToString
                'Else

                'End If

                'strQuery = "SELECT * "
                'strQuery = strQuery & "FROM PIC "
                'strQuery = strQuery & "WHERE Customer_id = '" & mCustomer_Id & "' AND PIC liek'%" & me. & "%' "
                'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If Not rs.EOF Then
                '    MsgBox("This record has already in database")
                '    Exit Sub
                'End If
                'rs.Close()

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM PIC "
                strQuery = strQuery & "WHERE PIC_Id = '" & mCustomerPIC & "' AND PIC_Id <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        .AddNew()
                        .Fields("PIC_ID").Value = NewId()
                        .Fields("Customer_ID").Value = "{" & mCustomer_Id & "}"
                    End If
                    .Fields("PIC").Value = Me.txtPic.Text.Trim
                    '.Fields("Agency_ID").Value = "{" & FindValueID(Me.txtPic, Me.txtPic.Text) & "}"
                    .Fields("Pos").Value = Me.txtPICPos.Text.Trim
                    .Fields("fax").Value = Me.txtPICFax.Text.Trim
                    .Fields("DirectLine").Value = Me.txtPICDirectLine.Text.Trim
                    .Fields("EMail").Value = Me.txtEmailP.Text.Trim
                    .Fields("hp").Value = Me.txthP.Text.Trim
                    .Update()
                End With
                rs.Close()

                QueryCustomerPIC()
                SetPicItem(False)
                mPICStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub DeleteMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMarket.Click
        Try
            Dim index As Integer
            If Me.dgdMarket.RowCount > 0 Then
                index = Me.dgdMarket.CurrentRow.Index
            Else
                Exit Sub
            End If
            Dim strQuery As String
            Dim strMesg As String = "Delete the Market : " & Me.dgdMarket.Item("market", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then



                strQuery = "select * from CustomerMarket where CustomerMarket_ID='" & Me.dgdMarket.Item("CustomerMarket_ID", index).Value.ToString & "' And Continued=1"
                Dim rs As New ADODB.Recordset
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("Continued").Value = 0
                rs.Update()
                rs.Close()
                QueryCustomerMarket()
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub AddCommondity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCommondity.Click
        Try
            If mCustomer_Id = DefaultValue Then
                MsgBox("Please input Customer")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            mCustomerCommondity = DefaultValue
            mCommondityStatus = "Add"
            SetCommondityItem(True)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub EditCommondity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCommondity.Click
        Try
            Dim index As Integer
            If Me.dgdCommondity.RowCount = 0 Then
                Return
            End If
            SetCommondityItem(True)
            mCommondityStatus = "Edit"
            mCustomerCommondity = Me.dgdCommondity.Item("CustomerCommondity_ID", index).Value.ToString
            Me.cboCommondity.Text = FindIDValue(Me.cboCommondity, Me.dgdCommondity.Item("Commondity_ID", index).Value.ToString.Trim)
            Me.txtCommondityRemarks.Text = Me.dgdCommondity.Item("CustomerCommondityRemarks", index).Value.ToString.Trim
            Me.txtMinTue.Text = Me.dgdCommondity.Item("MinTueMonth", index).Value.ToString.Trim
            Me.txtMaxTue.Text = Me.dgdCommondity.Item("MaxTueMonth", index).Value.ToString.Trim
            Me.txtAveTue.Text = Me.dgdCommondity.Item("AvgTueMonth", index).Value.ToString.Trim
            Me.txtSeason.Text = Me.dgdCommondity.Item("Season", index).Value.ToString.Trim


            If IsDBNull(Me.dgdCommondity.Item("FromDate", index).Value) = False Then
                Me.dtpFromDate.Value = Me.dgdCommondity.Item("FromDate", index).Value
                Me.chkFrom.Checked = True
            Else
                Me.chkFrom.Checked = False
            End If

            If IsDBNull(Me.dgdCommondity.Item("ToDate", index).Value) = False Then
                Me.dtpToDate.Value = Me.dgdCommondity.Item("ToDate", index).Value
                Me.chkTo.Checked = True
            Else
                Me.chkTo.Checked = False
            End If

            Me.chkFrom_CheckedChanged(sender, e)
            Me.chkTo_CheckedChanged(sender, e)

        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub DeleteCommondtiy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCommondtiy.Click
        Try
            Dim index As Integer
            If Me.dgdCommondity.RowCount > 0 Then
                index = Me.dgdCommondity.CurrentRow.Index
            Else
                Exit Sub
            End If
            Dim strQuery As String
            Dim strMesg As String = "Delete the Commodity : " & Me.dgdCommondity.Item("commondity", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
               

                strQuery = "select * from CustomerCommondity where CustomerCommondity_ID='" & Me.dgdCommondity.Item("CustomerCommondity_ID", index).Value.ToString & "' And Continued=1"
                Dim rs As New ADODB.Recordset
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("Continued").Value = 0
                rs.Update()
                rs.Close()
                QueryCustomerCommondity()
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub AddPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPIC.Click
        Try
            If mCustomer_Id = DefaultValue Then
                MsgBox("Please input Customer")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            mCustomerPIC = DefaultValue
            SetPicItem(True)
            mPICStatus = "Add"
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub EditPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPIC.Click
        Try
            Dim index As Integer
            If Me.dgdPIC.RowCount > 0 Then
                index = Me.dgdPIC.CurrentRow.Index
            Else
                Exit Sub
            End If
            SetPicItem(True)
            mPICStatus = "Edit"
            mCustomerPIC = Me.dgdPIC.Item("PIC_ID", index).Value.ToString
            'Me.cboAgency.Text = FindIDValue(Me.cboAgency, Me.dgdPIC.Item("Agency_ID", index).Value.ToString.Trim)
            Me.txtPic.Text = Me.dgdPIC.Item("PIC", index).Value.ToString.Trim
            Me.txtPICPos.Text = Me.dgdPIC.Item("POS", index).Value.ToString.Trim
            Me.txtPICFax.Text = Me.dgdPIC.Item("PICfax", index).Value.ToString.Trim
            Me.txtEmailP.Text = Me.dgdPIC.Item("emailp", index).Value.ToString.Trim
            Me.txthP.Text = Me.dgdPIC.Item("hp", index).Value.ToString.Trim
            Me.txtPICDirectLine.Text = Me.dgdPIC.Item("DirectLine", index).Value.ToString.Trim

        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub SetPicItem(ByVal value As Boolean)
        Try
            ' Me.cboAgency.Enabled = value
            Me.txtPICDirectLine.Enabled = value
            Me.txtPic.Enabled = value
            Me.cmdPICOk.Enabled = value
            Me.cmdPICCancel.Enabled = value
            Me.txtPICPos.Enabled = value
            Me.txtEmailP.Enabled = value
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub SetCommondityItem(ByVal value As Boolean)
        Try
            Me.cboCommondity.Enabled = value
            Me.txtCommondityRemarks.Enabled = value
            Me.cmdCommondityOk.Enabled = value
            Me.cmdCommondityCancel.Enabled = value
            Me.dtpFromDate.Enabled = value
            Me.dtpToDate.Enabled = value
            Me.txtSeason.Enabled = value
            Me.txtMinTue.Enabled = value
            Me.txtMaxTue.Enabled = value
            Me.txtAveTue.Enabled = value
            Me.chkFrom.Enabled = value
            Me.chkTo.Enabled = value

            Me.txtMinTue.Text = 0
            Me.txtMaxTue.Text = 0
            Me.txtAveTue.Text = 0
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub DeletePIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePIC.Click
        Dim index As Integer
        If Me.dgdPIC.RowCount > 0 Then
            index = Me.dgdPIC.CurrentRow.Index
        Else
            Exit Sub
        End If
        Dim strQuery As String
        Dim strMesg As String = "Delete the PIC : " & Me.dgdPIC.Item("PIC", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
       
            strQuery = "select * from PIC where PIC_ID='" & Me.dgdPIC.Item("PIC_ID", index).Value.ToString & "' And Continued=1"
            Dim rs As New ADODB.Recordset
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 0
            rs.Update()
            rs.Close()
            QueryCustomerPIC()
        End If
    End Sub

    Private Sub cmdCommondityCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCommondityCancel.Click
        mCommondityStatus = "Normal"
        SetCommondityItem(False)
    End Sub

    Private Sub cmdPICCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPICCancel.Click
        SetPicItem(False)
        mPICStatus = "Normal"
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryCustomer("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            ' chon 1 customer de view toan bo cac chi tiet

            If Me.dgdCustomer.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdCustomer, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSelect.Click
        If Me.dgdCustomer.SelectedRows.Count > 0 Then
            Dim index As Integer = Me.dgdCustomer.CurrentRow.Index
            gSearchID = Me.dgdCustomer.Item("Customer_Id", index).Value.ToString
            SearchCombo()
            Me.Close()
        End If
    End Sub

    Private Sub smnuFilterData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuFilterData.Click
        Try
            gNameForm = "filter"
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryFilterData("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub chkFrom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFrom.CheckedChanged
        Try
            Me.dtpFromDate.Enabled = Me.chkFrom.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkTo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTo.CheckedChanged
        Try
            Me.dtpToDate.Enabled = Me.chkTo.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'If Me.dgdCustomer.RowCount = 0 Then
            '    Return
            'End If
            'Dim _index As Integer = Me.dgdCustomer.CurrentRow.Index
            'Dim strSql As String
            'mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", _index).Value.ToString

            'strSql = MakeQueryCustomer(" and Customer.Customer_ID='" & mCustomer_Id & "'")
            'Dim tbl As DataTable
            'tbl = ReadTable(strSql)

            'strSql = "select distinct(CustomerCommondity.Commondity_ID),CustomerCommondity.CustomerCommondity_ID,Commondity,Commondity.Remarks as CommondityRemarks,CustomerCommondity.Remarks as CustomerCommondityRemarks,Customer_Code,From_Date,To_Date,Season,Min_tueMonth,AVG_tueMonth,Max_tueMonth,EnglishName,COMPANY "
            'strSql &= " From ((CustomerCommondity LEFT JOIN Customer on Customer.Customer_ID=CustomerCommondity.Customer_ID) "
            'strSql &= " LEFT JOIN Commondity on CustomerCommondity.Commondity_ID=Commondity.Commondity_ID)"
            'strSql &= " Where CustomerCommondity.continued=1 And CustomerCommondity.Customer_ID='" & mCustomer_Id & "'"
            'Dim tblCommondity As New DataTable

            'tblCommondity = ReadTable(strSql)

            'Dim tblPic As New DataTable
            'strSql = "select PIC_ID,PIC,Pos,DirectLine,Customer_Code,EnglishName,COMPANY "
            'strSql &= " From (PIC LEFT JOIN Customer on Customer.Customer_ID=PIC.Customer_ID) "
            'strSql &= " Where PIC.continued=1 And PIC.Customer_ID='" & mCustomer_Id & "'"
            'tblPic = ReadTable(strSql)

            'Dim tblMarket As New DataTable
            'strSql = "select CustomerMarket_Id,MarketCode,Market,Customer_Code,EnglishName,COMPANY "
            'strSql &= " From ((CustomerMarket LEFT JOIN Customer on Customer.Customer_ID=CustomerMarket.Customer_ID) "
            'strSql &= " LEFT JOIN Market on CustomerMarket.Market_ID=Market.Market_ID)"
            'strSql &= " Where CustomerMarket.continued=1 And CustomerMarket.Customer_ID='" & mCustomer_Id & "'"
            'tblMarket = ReadTable(strSql)

            'Dim tblDestination As New DataTable
            'strSql = "select CustomerMarket_Id,CustomerMarket.Market_ID,Dest "
            'strSql &= " From ((CustomerMarket LEFT JOIN Market on CustomerMarket.Market_ID=Market.Market_ID) "
            'strSql &= " INNER JOIN DESTINATION on DESTINATION.Market_ID=Market.Market_ID)"
            'strSql &= " Where CustomerMarket.continued=1 AND DESTINATION.continued=1 and Market.continued=1 And CustomerMarket.Customer_ID='" & mCustomer_Id & "'"
            'tblDestination = ReadTable(strSql)

            'Dim tblSeason As New DataTable
            'strSql = "select Season,From_Date,To_Date,Sum(Min_tueMonth) as Min_tueMonth,Sum(AVG_tueMonth) as AVG_tueMonth,Sum(Max_tueMonth) as Max_tueMonth "
            'strSql &= " From ((CustomerCommondity LEFT JOIN Customer on Customer.Customer_ID=CustomerCommondity.Customer_ID) "
            'strSql &= " LEFT JOIN Commondity on CustomerCommondity.Commondity_ID=Commondity.Commondity_ID) "
            'strSql &= " Where CustomerCommondity.continued=1 And CustomerCommondity.Customer_ID='" & mCustomer_Id & "' "
            'strSql &= " Group by Season,From_Date,To_Date "
            'tblSeason = ReadTable(strSql)

            'Dim TableSaleDetail As New DataTable
            'strSql = "Select Booking_ID,Customer_ID,por1.Port as POD,por2.Port as POL,AgencyName, " & _
            '         "SL20GPOwner,SL40GPOwner,SL40HCOwner,SL45HCOwner,SL20RFOwner,SL40RFOwner,SL40RHOwner,SL20OTOwner,SL40OTOwner,SL20FROwner,SL40FROwner,SLCBMOwner," & _
            '         "SL20GPSale,SL40GPSale,SL40HCSale,SL45HCSale,SL20RFSale,SL40RFSale,SL40RHSale,SL20OTSale,SL40OTSale,SL20FRSale,SL40FRSale,SLCBMSale," & _
            '         "Validate,bk.UPDATETIME "
            'strSql &= "from ((Booking bk INNER JOIN Port por1 ON por1.Port_ID=bk.POD_ID) " & _
            '         "INNER JOIN Port por2 ON por2.Port_ID=bk.POD_ID) " & _
            '         "INNER JOIN Agency ON Agency.Agency_ID=bk.Agency_ID " & _
            '         "Where Customer_ID='" & mCustomer_Id & "' And bk.Continued=1"
            'TableSaleDetail = ReadTable(strSql)

            'Dim TableCusRpt As New DataTable
            'strSql = "Select * From CustomerReport Where customer_id='" & mCustomer_Id & "' and continued=1"
            'TableCusRpt = ReadTable(strSql)

            'Dim frm As New frmReportCustomer
            'frm.oTable = tbl

            'frm.oTablePic = tblPic
            'frm.oTableCommondity = tblCommondity
            'frm.oTableMarket = tblMarket
            'frm.oTableDestination = tblDestination
            'frm.oTableSeason = tblSeason
            'frm.oTableSaleDetail = TableSaleDetail
            'frm.oTableCusRpt = TableCusRpt
            'frm.Show(Me)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdMarket_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdMarket.CellContentClick

    End Sub

    Private Sub dgdMarket_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdMarket.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdMarket)
    End Sub

    Private Sub dgdCommondity_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCommondity.CellContentClick

    End Sub

    Private Sub dgdCommondity_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdCommondity.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdCommondity)
    End Sub

    Private Sub dgdPIC_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPIC.CellContentClick

    End Sub

    Private Sub dgdPIC_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPIC.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdPIC)
    End Sub

    Sub SetSaleItem(ByVal value As Boolean)
        Try
            Dim ctr As Control
            For Each ctr In Me.grpOwner.Controls
                If Strings.Left(ctr.Name, 5) <> "Label" Then
                    ctr.Enabled = value
                Else
                    Dim i As Integer = 0
                End If
            Next

            For Each ctr In Me.grpSale.Controls
                If Strings.Left(ctr.Name, 5) <> "Label" Then
                    ctr.Enabled = value
                End If
            Next

            Me.dtpValidate.Enabled = value
            Me.chkvalidate.Enabled = value
            Me.txtSaleRemarks.Enabled = value
            Me.txtSCNO.Enabled = value
            Me.cboCurrency.Enabled = value
            Me.txtCommisson.Enabled = value
            Me.cboPOD.Enabled = value
            Me.cboPOL.Enabled = value
            Me.cboAgency.Enabled = value
            Me.cmdSaleOk.Enabled = value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ctmnuSaleAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuSaleAdd.Click
        Try
            If mCustomer_Id = DefaultValue Then
                MsgBox("Please input Customer")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            mSaleID = DefaultValue
            mSaleStatus = "Add"
            SetSaleItem(True)

            Dim ctr As Control
            For Each ctr In Me.grpOwner.Controls
                If Strings.Left(ctr.Name, 3) = "txt" Then
                    ctr.Text = ""
                ElseIf Strings.Left(ctr.Name, 3) = "chk" Then
                    CType(ctr, CheckBox).Checked = False
                End If
            Next

            For Each ctr In Me.grpSale.Controls
                If Strings.Left(ctr.Name, 3) = "txt" Then
                    ctr.Text = ""
                ElseIf Strings.Left(ctr.Name, 3) = "chk" Then
                    CType(ctr, CheckBox).Checked = False
                End If
            Next
            SetCheck(sender, e)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ctmnuSaleEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuSaleEdit.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.dgdSale.RowCount > 0 Then
                index = Me.dgdSale.CurrentRow.Index
            Else
                Exit Sub
            End If
            Approve = Me.dgdSale.Item("SaleApprove", index).Value
            EditTable = Me.dgdSale.Item("SaleEditable", index).Value
            If mSaleStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") And Not Me.dgdSale.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                SetSaleItem(True)
                mSaleStatus = "Edit"
                mSaleID = Me.dgdSale.Item("SaleDetail_ID", index).Value.ToString
                Me.cboPOD.Text = Me.dgdSale.Item("POD", index).Value
                Me.cboPOL.Text = Me.dgdSale.Item("POL", index).Value
                Me.cboAgency.Text = Me.dgdSale.Item("Agency", index).Value

                If IsDBNull(Me.dgdSale.Item("SL20GPOwner", index).Value) = False Then
                    Me.txt20GPOwner.Text = Me.dgdSale.Item("SL20GPOwner", index).Value
                    Me.chk20GPOwner.Checked = True
                Else
                    Me.txt20GPOwner.Text = ""
                    Me.chk20GPOwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40GPOwner", index).Value) = False Then
                    Me.txt40GPOwner.Text = Me.dgdSale.Item("SL40GPOwner", index).Value
                    Me.chk40GPOwner.Checked = True
                Else
                    Me.txt40GPOwner.Text = ""
                    Me.chk40GPOwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40HCOwner", index).Value) = False Then
                    Me.txt40HCOwner.Text = Me.dgdSale.Item("SL40HCOwner", index).Value
                    Me.chk40HCOwner.Checked = True
                Else
                    Me.txt40HCOwner.Text = ""
                    Me.chk40HCOwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL45HCOwner", index).Value) = False Then
                    Me.txt45HCOwner.Text = Me.dgdSale.Item("SL45HCOwner", index).Value
                    Me.chk45HCOwner.Checked = True
                Else
                    Me.txt45HCOwner.Text = ""
                    Me.chk45HCOwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL20RFOwner", index).Value) = False Then
                    Me.txt20RFOwner.Text = Me.dgdSale.Item("SL20RFOwner", index).Value
                    Me.chk20RFOwner.Checked = True
                Else
                    Me.txt20RFOwner.Text = ""
                    Me.chk20RFOwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40RFOwner", index).Value) = False Then
                    Me.txt40RFOwner.Text = Me.dgdSale.Item("SL40RFOwner", index).Value
                    Me.chk40RFOwner.Checked = True
                Else
                    Me.txt40RFOwner.Text = ""
                    Me.chk40RFOwner.Checked = False
                End If
                If IsDBNull(Me.dgdSale.Item("SL40RHOwner", index).Value) = False Then
                    Me.txt40RHOwner.Text = Me.dgdSale.Item("SL40RHOwner", index).Value
                    Me.chk40RHOwner.Checked = True
                Else
                    Me.txt40RHOwner.Text = ""
                    Me.chk40RHOwner.Checked = False
                End If



                If IsDBNull(Me.dgdSale.Item("SL20OTOwner", index).Value) = False Then
                    Me.txt20OTOwner.Text = Me.dgdSale.Item("SL20OTOwner", index).Value
                    Me.chk20OTOwner.Checked = True
                Else
                    Me.txt20OTOwner.Text = ""
                    Me.chk20OTOwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40OTOwner", index).Value) = False Then
                    Me.txt40OTOwner.Text = Me.dgdSale.Item("SL40OTOwner", index).Value
                    Me.chk40OTOwner.Checked = True
                Else
                    Me.txt40OTOwner.Text = ""
                    Me.chk40OTOwner.Checked = False
                End If
                If IsDBNull(Me.dgdSale.Item("SL20FROwner", index).Value) = False Then
                    Me.txt20FROwner.Text = Me.dgdSale.Item("SL20FROwner", index).Value
                    Me.chk20FROwner.Checked = True
                Else
                    Me.txt20FROwner.Text = ""
                    Me.chk20FROwner.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40FROwner", index).Value) = False Then
                    Me.txt40FROwner.Text = Me.dgdSale.Item("SL40FROwner", index).Value
                    Me.chk40FROwner.Checked = True
                Else
                    Me.txt40FROwner.Text = ""
                    Me.chk40FROwner.Checked = False
                End If


                If IsDBNull(Me.dgdSale.Item("SLCBMOwner", index).Value) = False Then
                    Me.txtCBMOwner.Text = Me.dgdSale.Item("SLCBMOwner", index).Value
                    Me.chkCBMOwner.Checked = True
                Else
                    Me.txtCBMOwner.Text = ""
                    Me.chkCBMOwner.Checked = False
                End If



                '-----------------

                If IsDBNull(Me.dgdSale.Item("SL20GPSale", index).Value) = False Then
                    Me.txt20GPSale.Text = Me.dgdSale.Item("SL20GPSale", index).Value
                    Me.chk20GPSale.Checked = True
                Else
                    Me.txt20GPSale.Text = ""
                    Me.chk20GPSale.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40GPSale", index).Value) = False Then
                    Me.txt40GPSale.Text = Me.dgdSale.Item("SL40GPSale", index).Value
                    Me.chk40GPSale.Checked = True
                Else
                    Me.txt40GPSale.Text = ""
                    Me.chk40GPSale.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40HCSale", index).Value) = False Then
                    Me.txt40HCSale.Text = Me.dgdSale.Item("SL40HCSale", index).Value
                    Me.chk40HCSale.Checked = True
                Else
                    Me.txt40HCSale.Text = ""
                    Me.chk40HCSale.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL45HCSale", index).Value) = False Then
                    Me.txt45HCSale.Text = Me.dgdSale.Item("SL45HCSale", index).Value
                    Me.chk45HCSale.Checked = True
                Else
                    Me.txt45HCSale.Text = ""
                    Me.chk45HCSale.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL20RFSale", index).Value) = False Then
                    Me.txt20RFSale.Text = Me.dgdSale.Item("SL20RFSale", index).Value
                    Me.chk20RFSale.Checked = True
                Else
                    Me.txt20RFSale.Text = ""
                    Me.chk20RFSale.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40RFSale", index).Value) = False Then
                    Me.txt40RFSale.Text = Me.dgdSale.Item("SL40RFSale", index).Value
                    Me.chk40RFSale.Checked = True
                Else
                    Me.txt40RFSale.Text = ""
                    Me.chk40RFSale.Checked = False
                End If
                If IsDBNull(Me.dgdSale.Item("SL40RHSale", index).Value) = False Then
                    Me.txt40RHSale.Text = Me.dgdSale.Item("SL40RHSale", index).Value
                    Me.chk40RHSale.Checked = True
                Else
                    Me.txt40RHSale.Text = ""
                    Me.chk40RHSale.Checked = False
                End If


                If IsDBNull(Me.dgdSale.Item("SL20OTSale", index).Value) = False Then
                    Me.txt20OTSale.Text = Me.dgdSale.Item("SL20OTSale", index).Value
                    Me.chk20OTSale.Checked = True
                Else
                    Me.txt20OTSale.Text = ""
                    Me.chk20OTSale.Checked = False
                End If

                If IsDBNull(Me.dgdSale.Item("SL40OTSale", index).Value) = False Then
                    Me.txt40OTSale.Text = Me.dgdSale.Item("SL40OTSale", index).Value
                    Me.chk40OTSale.Checked = True
                Else
                    Me.txt40OTSale.Text = ""
                    Me.chk40OTSale.Checked = False
                End If


                If IsDBNull(Me.dgdSale.Item("SL20FRSale", index).Value) = False Then
                    Me.txt20FRSale.Text = Me.dgdSale.Item("SL20FRSale", index).Value
                    Me.chk20FRSale.Checked = True
                Else
                    Me.txt20FRSale.Text = ""
                    Me.chk20FRSale.Checked = False
                End If
                If IsDBNull(Me.dgdSale.Item("SL40FRSale", index).Value) = False Then
                    Me.txt40FRSale.Text = Me.dgdSale.Item("SL40FRSale", index).Value
                    Me.chk40FRSale.Checked = True
                Else
                    Me.txt40FRSale.Text = ""
                    Me.chk40FRSale.Checked = False
                End If
                If IsDBNull(Me.dgdSale.Item("SLCBMSale", index).Value) = False Then
                    Me.txtCBMSale.Text = Me.dgdSale.Item("SLCBMSale", index).Value
                    Me.chkCBMSale.Checked = True
                Else
                    Me.txtCBMSale.Text = ""
                    Me.chkCBMSale.Checked = False
                End If




                If IsDBNull(Me.dgdSale.Item("Validate", index).Value) = False Then
                    Me.dtpValidate.Value = Me.dgdSale.Item("Validate", index).Value
                    Me.chkvalidate.Checked = True
                Else
                    Me.chkvalidate.Checked = False
                End If
                Me.txtSell.Text = Me.dgdSale.Item("sell", index).Value
                Me.txtbuy.Text = Me.dgdSale.Item("buy", index).Value


                Me.txtSCNO.Text = Me.dgdSale.Item("SCNO", index).Value
                Me.txtSaleRemarks.Text = Me.dgdSale.Item("Remarks", index).Value
                Me.cboCurrency.Text = Me.dgdSale.Item("Currency", index).Value.ToString.Trim
                Me.txtCommisson.Text = Me.dgdSale.Item("Commisson", index).Value.ToString.Trim
                Me.chkBooking.Checked = Me.dgdSale.Item("Booking", index).Value
                SetCheck(sender, e)
                Calculate()
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub QuerySaleDetail(Optional ByVal Location As Integer = 0)
        Try
            Dim strSQL As String
            strSQL = "Select Booking_ID, " & _
                     "Customer_ID, " & _
                     "por1.Port as POD, " & _
                     "por2.Port as POL, " & _
                     "AgencyName, " & _
                     "SL20GPOwner, " & _
                     "SL40GPOwner," & _
                     "SL40HCOwner," & _
                     "SL45HCOwner," & _
                     "SL20RFOwner," & _
                     "SL40RFOwner," & _
                        "SL40RHOwner," & _
                    "SL20OTOwner," & _
                     "SL40OTOwner," & _
                     "SL20FROwner," & _
                     "SL40FROwner," & _
                     "SLCBMOwner," & _
                     "SL20GPSale," & _
                     "SL40GPSale," & _
                     "SL40HCSale," & _
                     "SL45HCSale," & _
                     "SL20RFSale," & _
                     "SL40RFSale," & _
 "SL40RHSale," & _
"SL20OTSale," & _
                     "SL40OTSale," & _
                     "SL20FRSale," & _
                     "SL40FRSale," & _
                      "SLCBMSale," & _
                     "Validate," & _
                     "Currency," & _
                     "Commission," & _
                     "SCNO," & _
                     "Remarks," & _
                     "Status," & _
                     "bk.editable," & _
                     "bk.continued," & _
                     "bk.approve," & _
                     "bk.userid," & _
                     "bk.updatetime "

            strSQL &= ", sell,buy from ((Booking bk INNER JOIN Port por1 ON por1.Port_ID=bk.POD_ID) " & _
                     "INNER JOIN Port por2 ON por2.Port_ID=bk.POL_ID) " & _
                     "INNER JOIN Agency ON Agency.Agency_ID=bk.Agency_ID " & _
                     "Where Customer_ID='" & mCustomer_Id & "' And bk.Continued=1"
            oTableSaleDetail = ReadTable(strSQL)
            Me.dgdSale.DataSource = oTableSaleDetail
            'If oTable.Rows.Count > 0 Then
            '    Me.dgdsale.Columns.Item("BL_No").ToolTipText = "Hiện có:" + CStr(Me.dgdsale.RowCount()) + " Bills."
            'End If
            'If Me.dgdSale.RowCount() = 0 Then
            '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            'End If
            '------------vị trí BM
            If Location > 0 And Location <= Me.dgdSale.Rows.Count And Me.dgdSale.Rows.Count > 0 Then
                Me.dgdSale.Rows(Location).Selected = True
                Me.dgdSale.CurrentCell = Me.dgdSale.Rows(Location).Cells(3)
            End If
            InsertAutoNumberToGrid(Me.dgdSale)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ctmnuSaleDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuSaleDelete.Click
        Try


            Dim index As Integer
            If Me.dgdSale.RowCount > 0 Then
                index = Me.dgdSale.CurrentRow.Index
            Else
                Exit Sub
            End If
            Dim strQuery As String
            strQuery = "select * from SaleDetail where SaleDetail_ID='" & Me.dgdSale.Item("SaleDetail_ID", index).Value.ToString & "' And Continued=1"
            Dim rs As New ADODB.Recordset
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 0
            rs.Update()
            rs.Close()
            QuerySaleDetail()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdSale_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdSale.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdSale)
    End Sub

    Function CheckDataSale() As Boolean
        Try
            Dim msg As String = ""
            If FindValueID(Me.cboPOD, Me.cboPOD.Text.Trim) = "" Then
                msg &= "The POD is invalid"
            End If

            If FindValueID(Me.cboPOL, Me.cboPOL.Text.Trim) = "" Then
                msg &= "The POL is invalid"
            End If

            If FindValueID(Me.cboAgency, Me.cboAgency.Text.Trim) = "" Then
                msg &= "The Agency is invalid"
            End If
            '--------------------------
            If Me.chk20GPOwner.Checked = True Then
                If IsNumeric(Me.txt20GPOwner.Text.Trim) = False Then
                    msg &= "The 20 GP is invalid"
                End If
            End If

            If Me.chk40GPOwner.Checked = True Then
                If IsNumeric(Me.txt40GPOwner.Text.Trim) = False Then
                    msg &= "The 40 GP is invalid"
                End If
            End If

            If Me.chk40HCOwner.Checked = True Then
                If IsNumeric(Me.txt40HCOwner.Text.Trim) = False Then
                    msg &= "The 40 HC GP is invalid"
                End If
            End If

            If Me.chk45HCOwner.Checked = True Then
                If IsNumeric(Me.txt45HCOwner.Text.Trim) = False Then
                    msg &= "The 45 HC is invalid"
                End If
            End If

            If Me.chk20RFOwner.Checked = True Then
                If IsNumeric(Me.txt20RFOwner.Text.Trim) = False Then
                    msg &= "The 20 RF is invalid"
                End If
            End If

            If Me.chk40RFOwner.Checked = True Then
                If IsNumeric(Me.txt40RFOwner.Text.Trim) = False Then
                    msg &= "The 40 RF is invalid"
                End If
            End If
            If Me.chk40RHOwner.Checked = True Then
                If IsNumeric(Me.txt40RHOwner.Text.Trim) = False Then
                    msg &= "The 40 RH is invalid"
                End If
            End If

            If Me.chk20OTOwner.Checked = True Then
                If IsNumeric(Me.txt20OTOwner.Text.Trim) = False Then
                    msg &= "The 20 OT is invalid"
                End If
            End If

            If Me.chk40OTOwner.Checked = True Then
                If IsNumeric(Me.txt40OTOwner.Text.Trim) = False Then
                    msg &= "The 40 OT is invalid"
                End If
            End If

            If Me.chk20FROwner.Checked = True Then
                If IsNumeric(Me.txt20FROwner.Text.Trim) = False Then
                    msg &= "The 20 FR is invalid"
                End If
            End If
            If Me.chk40FROwner.Checked = True Then
                If IsNumeric(Me.txt40FROwner.Text.Trim) = False Then
                    msg &= "The 40 FR is invalid"
                End If
            End If
            If Me.chkCBMOwner.Checked = True Then
                If IsNumeric(Me.txtCBMOwner.Text.Trim) = False Then
                    msg &= "The CBM is invalid"
                End If
            End If

            '========================

            If Me.chk20GPSale.Checked = True Then
                If IsNumeric(Me.txt20GPSale.Text.Trim) = False Then
                    msg &= "The 20 GP is invalid"
                End If
            End If

            If Me.chk40GPSale.Checked = True Then
                If IsNumeric(Me.txt40GPSale.Text.Trim) = False Then
                    msg &= "The 40 GP is invalid"
                End If
            End If

            If Me.chk40HCSale.Checked = True Then
                If IsNumeric(Me.txt40HCSale.Text.Trim) = False Then
                    msg &= "The 40 HC GP is invalid"
                End If
            End If
            If Me.chk45HCSale.Checked = True Then
                If IsNumeric(Me.txt45HCSale.Text.Trim) = False Then
                    msg &= "The 45 HC GP is invalid"
                End If
            End If

            If Me.chk20RFSale.Checked = True Then
                If IsNumeric(Me.txt20RFSale.Text.Trim) = False Then
                    msg &= "The 20 RF is invalid"
                End If
            End If
            If Me.chk40RFSale.Checked = True Then
                If IsNumeric(Me.txt40RFSale.Text.Trim) = False Then
                    msg &= "The 40 RF is invalid"
                End If
            End If
            If Me.chk40RHSale.Checked = True Then
                If IsNumeric(Me.txt40RHSale.Text.Trim) = False Then
                    msg &= "The 40 RH is invalid"
                End If
            End If





            If Me.chk20OTSale.Checked = True Then
                If IsNumeric(Me.txt20OTSale.Text.Trim) = False Then
                    msg &= "The 20 OT is invalid"
                End If
            End If

            If Me.chk40OTSale.Checked = True Then
                If IsNumeric(Me.txt40OTSale.Text.Trim) = False Then
                    msg &= "The 40 OT is invalid"
                End If
            End If

            If Me.chk20FRSale.Checked = True Then
                If IsNumeric(Me.txt20FRSale.Text.Trim) = False Then
                    msg &= "The 20 FR is invalid"
                End If
            End If
            If Me.chk40FRSale.Checked = True Then
                If IsNumeric(Me.txt40FRSale.Text.Trim) = False Then
                    msg &= "The 40 FR is invalid"
                End If
            End If
            If Me.chkCBMSale.Checked = True Then
                If IsNumeric(Me.txtCBMSale.Text.Trim) = False Then
                    msg &= "The CBM is invalid"
                End If
            End If


            If IsNumeric(Me.txtCommisson.Text.Trim) = False Then
                msg &= "The Commission is invalid"
            End If

            If msg <> "" Then
                MsgBox(msg)
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdSaleOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaleOk.Click
        Try
            If CheckDataSale() And (mSaleStatus = "Add" Or mSaleStatus = "Edit") Then
                Dim index As Integer = 0
                If Me.dgdSale.RowCount > 0 Then
                    If Not IsNothing(Me.dgdSale.CurrentRow) Then
                        index = Me.dgdSale.CurrentRow.Index
                    Else
                        Exit Sub
                    End If
                End If
                Dim strQuery As String
                Dim rs As New ADODB.Recordset

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Booking "
                strQuery = strQuery & "WHERE Booking_Id = '" & mSaleID & "' AND Booking_Id <> '" & DefaultValue & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        .AddNew()
                        .Fields("Booking_ID").Value = NewId()
                        .Fields("Customer_ID").Value = "{" & mCustomer_Id & "}"
                    End If
                    .Fields("POD_ID").Value = "{" & FindValueID(Me.cboPOD, Me.cboPOD.Text.Trim) & "}"
                    .Fields("POL_ID").Value = "{" & FindValueID(Me.cboPOL, Me.cboPOL.Text.Trim) & "}"
                    .Fields("Agency_ID").Value = "{" & FindValueID(Me.cboAgency, Me.cboAgency.Text.Trim) & "}"

                    If Me.chk20GPOwner.Checked = True Then
                        .Fields("SL20GPOwner").Value = CDbl(Me.txt20GPOwner.Text.Trim)
                    Else
                        .Fields("SL20GPOwner").Value = Nothing
                    End If

                    If Me.chk40GPOwner.Checked = True Then
                        .Fields("SL40GPOwner").Value = CDbl(Me.txt40GPOwner.Text.Trim)
                    Else
                        .Fields("SL40GPOwner").Value = Nothing
                    End If

                    If Me.chk40HCOwner.Checked = True Then
                        .Fields("SL40HCOwner").Value = CDbl(Me.txt40HCOwner.Text.Trim)
                    Else
                        .Fields("SL40HCOwner").Value = Nothing
                    End If

                    If Me.chk45HCOwner.Checked = True Then
                        .Fields("SL45HCOwner").Value = CDbl(Me.txt45HCOwner.Text.Trim)
                    Else
                        .Fields("SL45HCOwner").Value = Nothing
                    End If

                    If Me.chk20RFOwner.Checked = True Then
                        .Fields("SL20RFOwner").Value = CDbl(Me.txt20RFOwner.Text.Trim)
                    Else
                        .Fields("SL20RFOwner").Value = Nothing
                    End If

                    If Me.chk40RFOwner.Checked = True Then
                        .Fields("SL40RFOwner").Value = CDbl(Me.txt40RFOwner.Text.Trim)
                    Else
                        .Fields("SL40RFOwner").Value = Nothing
                    End If

                    If Me.chk40RHOwner.Checked = True Then
                        .Fields("SL40RHOwner").Value = CDbl(Me.txt40RHOwner.Text.Trim)
                    Else
                        .Fields("SL40RHOwner").Value = Nothing
                    End If

                    If Me.chk20OTOwner.Checked = True Then
                        .Fields("SL20OTOwner").Value = CDbl(Me.txt20OTOwner.Text.Trim)
                    Else
                        .Fields("SL20OTOwner").Value = Nothing
                    End If


                    If Me.chk40OTOwner.Checked = True Then
                        .Fields("SL40OTOwner").Value = CDbl(Me.txt40OTOwner.Text.Trim)
                    Else
                        .Fields("SL40OTOwner").Value = Nothing
                    End If


                    If Me.chk20FROwner.Checked = True Then
                        .Fields("SL20FROwner").Value = CDbl(Me.txt20FROwner.Text.Trim)
                    Else
                        .Fields("SL20FROwner").Value = Nothing
                    End If

                    If Me.chk40FROwner.Checked = True Then
                        .Fields("SL40FROwner").Value = CDbl(Me.txt40FROwner.Text.Trim)
                    Else
                        .Fields("SL40FROwner").Value = Nothing
                    End If


                    If Me.chkCBMOwner.Checked = True Then
                        .Fields("SLCBMOwner").Value = CDbl(Me.txtCBMOwner.Text.Trim)
                    Else
                        .Fields("SLCBMOwner").Value = Nothing
                    End If
                    '------------

                    If Me.chk20GPSale.Checked = True Then
                        .Fields("SL20GPSale").Value = CDbl(Me.txt20GPSale.Text.Trim)
                    Else
                        .Fields("SL20GPSale").Value = Nothing
                    End If

                    If Me.chk40GPSale.Checked = True Then
                        .Fields("SL40GPSale").Value = CDbl(Me.txt40GPSale.Text.Trim)
                    Else
                        .Fields("SL40GPSale").Value = Nothing
                    End If

                    If Me.chk40HCSale.Checked = True Then
                        .Fields("SL40HCSale").Value = CDbl(Me.txt40HCSale.Text.Trim)
                    Else
                        .Fields("SL40HCSale").Value = Nothing
                    End If

                    If Me.chk45HCSale.Checked = True Then
                        .Fields("SL45HCSale").Value = CDbl(Me.txt45HCSale.Text.Trim)
                    Else
                        .Fields("SL45HCSale").Value = Nothing
                    End If

                    If Me.chk20RFSale.Checked = True Then
                        .Fields("SL20RFSale").Value = CDbl(Me.txt20RFSale.Text.Trim)
                    Else
                        .Fields("SL20RFSale").Value = Nothing
                    End If

                    If Me.chk40RFSale.Checked = True Then
                        .Fields("SL40RFSale").Value = CDbl(Me.txt40RFSale.Text.Trim)
                    Else
                        .Fields("SL40RFSale").Value = Nothing
                    End If
                    If Me.chk40RHSale.Checked = True Then
                        .Fields("SL40RHSale").Value = CDbl(Me.txt40RHSale.Text.Trim)
                    Else
                        .Fields("SL40RHSale").Value = Nothing
                    End If

                    If Me.chk20OTSale.Checked = True Then
                        .Fields("SL20OTSale").Value = CDbl(Me.txt20OTSale.Text.Trim)
                    Else
                        .Fields("SL20OTSale").Value = Nothing
                    End If
                    If Me.chk40OTSale.Checked = True Then
                        .Fields("SL40OTSale").Value = CDbl(Me.txt40OTSale.Text.Trim)
                    Else
                        .Fields("SL40OTSale").Value = Nothing
                    End If

                    If Me.chk20FRSale.Checked = True Then
                        .Fields("SL20FRSale").Value = CDbl(Me.txt20FRSale.Text.Trim)
                    Else
                        .Fields("SL20FRSale").Value = Nothing
                    End If
                    If Me.chk40FRSale.Checked = True Then
                        .Fields("SL40FRSale").Value = CDbl(Me.txt40FRSale.Text.Trim)
                    Else
                        .Fields("SL40FRSale").Value = Nothing
                    End If

                    If Me.chkCBMSale.Checked = True Then
                        .Fields("SLCBMSale").Value = CDbl(Me.txtCBMSale.Text.Trim)
                    Else
                        .Fields("SLCBMSale").Value = Nothing
                    End If

                    If Me.chkvalidate.Checked = True Then
                        .Fields("Validate").Value = Me.dtpValidate.Value.Date
                    Else
                        .Fields("Validate").Value = Nothing
                    End If
                    .Fields("sell").Value = Me.txtSell.Text.Trim
                    .Fields("buy").Value = Me.txtbuy.Text.Trim

                    .Fields("SCNO").Value = Me.txtSCNO.Text.Trim
                    .Fields("Remarks").Value = Me.txtSaleRemarks.Text.Trim
                    .Fields("Currency").Value = Me.cboCurrency.Text.Trim
                    .Fields("Commission").Value = Me.txtCommisson.Text.Trim

                    .Fields("Status").Value = Me.chkBooking.Checked
                    .Update()
                End With
                rs.Close()
                QuerySaleDetail(index)
                SetSaleItem(False)
                mSaleStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdSaleCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaleCancel.Click
        SetSaleItem(False)
        mSaleStatus = "Normal"
    End Sub

    'Private Sub txtCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            Me.cmdFind.PerformClick()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub chk20GPOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPOwner.CheckedChanged
        Me.txt20GPOwner.Enabled = Me.chk20GPOwner.Checked
        Calculate()
    End Sub

    Private Sub chk40GPOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPOwner.CheckedChanged
        Me.txt40GPOwner.Enabled = Me.chk40GPOwner.Checked
        Calculate()
    End Sub

    Private Sub chk40HCOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40HCOwner.CheckedChanged
        Me.txt40HCOwner.Enabled = Me.chk40HCOwner.Checked
        Calculate()
    End Sub

    Private Sub chk20RFOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20RFOwner.CheckedChanged
        Me.txt20RFOwner.Enabled = Me.chk20RFOwner.Checked
        Calculate()
    End Sub

    Private Sub chk40RFOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RFOwner.CheckedChanged
        Me.txt40RFOwner.Enabled = Me.chk40RFOwner.Checked
        Calculate()
    End Sub

    Private Sub chk45HCOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45HCOwner.CheckedChanged
        Me.txt45HCOwner.Enabled = Me.chk45HCOwner.Checked
        Calculate()
    End Sub

    Private Sub chk40OTOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40OTOwner.CheckedChanged
        Me.txt40OTOwner.Enabled = Me.chk40OTOwner.Checked
        Calculate()
    End Sub

    Private Sub chk20FROwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20FROwner.CheckedChanged
        Me.txt20FROwner.Enabled = Me.chk20FROwner.Checked
        Calculate()
    End Sub




    Private Sub chk20GPSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPSale.CheckedChanged
        Me.txt20GPSale.Enabled = Me.chk20GPSale.Checked
    End Sub

    Private Sub chk40GPSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPSale.CheckedChanged
        Me.txt40GPSale.Enabled = Me.chk40GPSale.Checked
    End Sub

    Private Sub chk40HCSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40HCSale.CheckedChanged
        Me.txt40HCSale.Enabled = Me.chk40HCSale.Checked
    End Sub

    Private Sub chk20RFSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20RFSale.CheckedChanged
        Me.txt20RFSale.Enabled = Me.chk20RFSale.Checked
    End Sub

    Private Sub chk40RFSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RFSale.CheckedChanged
        Me.txt40RFSale.Enabled = Me.chk40RFSale.Checked
    End Sub

    Private Sub chk40RHSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RHSale.CheckedChanged
        Me.txt40RHSale.Enabled = Me.chk40RHSale.Checked
    End Sub





    Private Sub chkvalidate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkvalidate.CheckedChanged
        Me.dtpValidate.Enabled = Me.chkvalidate.Checked
    End Sub

    Sub SetCheck(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20GPOwner_CheckedChanged(sender, e)
        Me.chk40GPOwner_CheckedChanged(sender, e)
        Me.chk40HCOwner_CheckedChanged(sender, e)
        Me.chk45HCOwner_CheckedChanged(sender, e)
        Me.chk20RFOwner_CheckedChanged(sender, e)
        Me.chk40RFOwner_CheckedChanged(sender, e)
        Me.chk40RHOwner_CheckedChanged(sender, e)

        Me.chk20OTOwner_CheckedChanged(sender, e)
        Me.chk40OTOwner_CheckedChanged(sender, e)

        Me.chk20FROwner_CheckedChanged(sender, e)
        Me.chk40FROwner_CheckedChanged(sender, e)
        Me.chkCBMOwner_CheckedChanged(sender, e)



        Me.chk20GPSale_CheckedChanged(sender, e)
        Me.chk40GPSale_CheckedChanged(sender, e)
        Me.chk40HCSale_CheckedChanged(sender, e)
        Me.chk45HCSale_CheckedChanged(sender, e)
        Me.chk20RFSale_CheckedChanged(sender, e)
        Me.chk40RFSale_CheckedChanged(sender, e)
        Me.chk40RHSale_CheckedChanged(sender, e)

        Me.chk20OTSale_CheckedChanged(sender, e)
        Me.chk40OTSale_CheckedChanged(sender, e)
        Me.chk20FRSale_CheckedChanged(sender, e)
        Me.chk40FRSale_CheckedChanged(sender, e)
        Me.chkCBMSale_CheckedChanged(sender, e)
        Me.chkvalidate_CheckedChanged(sender, e)
    End Sub

    Private Sub dgdSale_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSale.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdSale.RowCount = 0 Then
            Return
        End If
        index = Me.dgdSale.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdSale.CurrentCellAddress.X = 29 And Me.dgdSale.CurrentCellAddress().Y = index Then
            Call ApproveSale()
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Sub Calculate()
        Try
            Dim sum As Double = 0.0
            'If Me.chk20GPOwner.Checked = True Then
            '    If IsNumeric(Me.txt20GPOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt20GPOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk40GPOwner.Checked = True Then
            '    If IsNumeric(Me.txt40GPOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt40GPOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk40HCOwner.Checked = True Then
            '    If IsNumeric(Me.txt40HCOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt40HCOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk45HCOwner.Checked = True Then
            '    If IsNumeric(Me.txt45HCOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt45HCOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk20RFOwner.Checked = True Then
            '    If IsNumeric(Me.txt20RFOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt20RFOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk40RFOwner.Checked = True Then
            '    If IsNumeric(Me.txt40RFOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt40RFOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk40OTOwner.Checked = True Then
            '    If IsNumeric(Me.txt40OTOwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt40OTOwner.Text.Trim)
            '    End If
            'End If

            'If Me.chk20FROwner.Checked = True Then
            '    If IsNumeric(Me.txt20FROwner.Text.Trim) = True Then
            '        sum += CDbl(Me.txt20FROwner.Text.Trim)
            '    End If
            'End If
            'Me.txtTotal.Text = sum
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txt20GPOwner_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt20GPOwner.Leave
        Calculate()
    End Sub

    Private Sub txt20RFOwner_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt20RFOwner.Leave
        Calculate()
    End Sub

    Private Sub txt40GPOwner_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt40GPOwner.Leave
        Calculate()
    End Sub

    Private Sub txt40HCOwner_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt40HCOwner.Leave
        Calculate()
    End Sub

    Private Sub txt40RFOwner_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt40RFOwner.Leave
        Calculate()
    End Sub

    Private Sub txt45GPOwner_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt45HCOwner.Leave
        Calculate()
    End Sub
    Sub SetBuyerRptItem(ByVal value As Boolean)
        Try
            Me.txtbuyer.Enabled = value
            Me.txtAddressBuyer.Enabled = value
            Me.txtTelBuyer.Enabled = value

            Me.txtemailbuyer.Enabled = value
            Me.txtwebsitebuyer.Enabled = value
            Me.cbocountry.Enabled = value
            Me.cboCommodity.Enabled = value
            Me.GroupBox1.Enabled = value



            Me.cmdOKBuyer.Enabled = value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SetCusRptItem(ByVal value As Boolean)
        Try
            Me.dtpVisitDate.Enabled = value
            Me.txtRemarksR.Enabled = value
            Me.cmdOkReport.Enabled = value
            Me.chkDaily.Enabled = value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuCusRptAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuCusRptAdd.Click
        Try
            If mCustomer_Id = DefaultValue Then
                MsgBox("Please input Customer")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            mCusReportID = DefaultValue
            mCusRptStatus = "Add"
            SetCusRptItem(True)

        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtsmnuCusRptEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuCusRptEdit.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.dgdCusReport.RowCount > 0 Then
                index = Me.dgdCusReport.CurrentRow.Index
            Else
                Exit Sub
            End If
            Approve = Me.dgdCusReport.Item("ApproveR", index).Value
            EditTable = Me.dgdCusReport.Item("EditableR", index).Value
            If Not Approve And UserRight("mnumarketingsale", "Edit") Then
                SetCusRptItem(True)
                mCusRptStatus = "Edit"
                mCusReportID = Me.dgdCusReport.Item("CusReport_ID", index).Value.ToString
                Me.dtpVisitDate.Value = Me.dgdCusReport.Item("VisitDate", index).Value
                Me.txtRemarksR.Text = Me.dgdCusReport.Item("RemarksR", index).Value
                Me.txtValidUser.Text = Me.dgdCusReport.Item("validuser", index).Value
                Me.chkDaily.Checked = Me.dgdCusReport.Item("daily", index).Value

            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtsmnuCusRptDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuCusRptDelete.Click
        Dim index As Integer
        If Me.dgdCusReport.RowCount > 0 Then
            index = Me.dgdCusReport.CurrentRow.Index
        Else
            Exit Sub
        End If
        Dim strQuery As String
        Dim strMesg As String = "Delete the Report : " & Me.dgdCusReport.Item("visitdate", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
           

            strQuery = "select * from CustomerReport where CusReport_ID='" & Me.dgdCusReport.Item("CusReport_ID", index).Value.ToString & "' And Continued=1"
            Dim rs As New ADODB.Recordset
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 0
            rs.Update()
            rs.Close()
            Me.QueryCustomerReport()
        End If
    End Sub

    Sub QueryCustomerReport(Optional ByVal Location As Integer = 0)
        Try
            Dim strSQL As String
            strSQL = "Select CusReport_ID, " & _
                     "Customer_ID, " & _
                     "VisitDate,daily," & _
                     "Remarks,validuser," & _
                     "editable," & _
                     "continued," & _
                     "approve," & _
                     "userid," & _
                     "updatetime "

            strSQL &= "From CustomerReport where Customer_ID='" & mCustomer_Id & "' and continued=1"
            oTableCusReport = ReadTable(strSQL)
            Me.dgdCusReport.DataSource = oTableCusReport
            'If oTable.Rows.Count > 0 Then
            '    Me.dgdsale.Columns.Item("BL_No").ToolTipText = "Hiện có:" + CStr(Me.dgdsale.RowCount()) + " Bills."
            'End If
            'If Me.dgdSale.RowCount() = 0 Then
            '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            'End If
            '------------vị trí BM
            If Location > 0 And Location <= Me.dgdCusReport.Rows.Count And Me.dgdCusReport.Rows.Count > 0 Then
                Me.dgdCusReport.Rows(Location).Selected = True
                Me.dgdCusReport.CurrentCell = Me.dgdCusReport.Rows(Location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdCusReport)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub QueryCustomerBuyer(Optional ByVal Location As Integer = 0)
        Try
            Dim strSQL As String
            strSQL = "Select BuyerID, " & _
                     "Customer_ID, " & _
                     "Buyer,consigneeshipper," & _
                     "Address,tel,buyer.fax,email,website,country,pic1name,pic1pos,pic1tel,pic1email,commodity," & _
                     "editable," & _
                     "continued," & _
                     "approve," & _
                     "userid," & _
                     "updatetime "

            strSQL &= "From Buyer where Customer_ID='" & mCustomer_Id & "' and continued=1"
            oTableCusReport = ReadTable(strSQL)
            Me.dgdBuyer.DataSource = oTableCusReport
            InsertAutoNumberToGrid(Me.dgdBuyer)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdOkReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkReport.Click
        Try
            If (mCusRptStatus = "Add" Or mCusRptStatus = "Edit") Then
                Try
                    copyHistory("CustomerReport", "CusReport_Id", mCusReportID, "history")
                Catch ex As Exception

                End Try
                Dim index As Integer = 0
                If Me.dgdCusReport.RowCount > 0 Then
                    If Not IsNothing(Me.dgdCusReport.CurrentRow) Then
                        index = Me.dgdCusReport.CurrentRow.Index
                    Else
                        Exit Sub
                    End If
                End If
                Dim strQuery As String
                Dim rs As New ADODB.Recordset

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM CustomerReport "
                strQuery = strQuery & "WHERE CusReport_Id = '" & mCusReportID & "' AND CusReport_Id <> '" & DefaultValue & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        .AddNew()
                        .Fields("CusReport_ID").Value = NewId()
                        .Fields("Customer_ID").Value = "{" & mCustomer_Id & "}"
                    End If
                    .Fields("VisitDate").Value = Me.dtpVisitDate.Value.Date.Date
                    .Fields("daily").Value = Me.chkDaily.Checked
                    .Fields("Remarks").Value = Me.txtRemarksR.Text.Trim
                    .Fields("Validuser").Value = Me.txtValidUser.Text.Trim

                    .Update()
                End With
                rs.Close()
                QueryCustomerReport(index)
                SetCusRptItem(False)
                mCusRptStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancelReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelReport.Click
        SetCusRptItem(False)
        mCusRptStatus = "Normal"
    End Sub

    Sub QueryUser()
        Try
            Dim id As String = "Sale_ID"
            Dim value As String = "salecode"
            Dim strQuery As String = "select sale_ID,salecode from sale where continued=1 order by salecode "
            loadDataToObject(Me.cboSale, strQuery, id, value)
            loadDataToObject(Me.cbosale1, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub Querycombo()
        Try
            Dim id As String = "industryid"
            Dim value As String = "industry"
            Dim strQuery As String = "select industryid,industry from industry order by industry "
            loadDataToObject(Me.txtIndustry, strQuery, id, value)
            loadDataToObject(Me.txtIndustry1, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cboSale_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSale.SelectedIndexChanged
        Try
            If FindValueID(Me.cboSale, Me.cboSale.Text.Trim) = "" Then
                Return
            End If
            Dim tbl As DataTable
            tbl = ReadTable("Select Name From UserList Where usr='" & Me.cboSale.Text.Trim & "' and Discontinued=0")
            If tbl.Rows.Count > 0 Then
                Me.txtSale.Text = tbl.Rows(0).Item("Name")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSale.CheckedChanged
        'Me.cboSale.Enabled = Me.chkSale.Checked
    End Sub


    Private Sub chk20OTOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20OTOwner.CheckedChanged
        Me.txt20OTOwner.Enabled = Me.chk20OTOwner.Checked
        Calculate()
    End Sub

    Private Sub chk40FROwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40FROwner.CheckedChanged
        Me.txt40FROwner.Enabled = Me.chk40FROwner.Checked
        Calculate()
    End Sub

    Private Sub chkCBMOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCBMOwner.CheckedChanged
        Me.txtCBMOwner.Enabled = Me.chkCBMOwner.Checked
        Calculate()
    End Sub

    Private Sub chk45HCSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45HCSale.CheckedChanged
        Me.txt45HCSale.Enabled = Me.chk45HCSale.Checked
    End Sub

    Private Sub chk20OTSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20OTSale.CheckedChanged
        Me.txt20OTSale.Enabled = Me.chk20OTSale.Checked
    End Sub

    Private Sub chk40OTSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40OTSale.CheckedChanged
        Me.txt40OTSale.Enabled = Me.chk40OTSale.Checked
    End Sub

    Private Sub chk20FRSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20FRSale.CheckedChanged
        Me.txt20FRSale.Enabled = Me.chk20FRSale.Checked
    End Sub

    Private Sub chk40FRSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40FRSale.CheckedChanged
        Me.txt40FRSale.Enabled = Me.chk40FRSale.Checked
    End Sub

    Private Sub chkCBMSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCBMSale.CheckedChanged
        Me.txtCBMSale.Enabled = Me.chkCBMSale.Checked
    End Sub

    Private Sub chkBooking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBooking.CheckedChanged

    End Sub

    Private Sub chk40RHOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RHOwner.CheckedChanged
        Me.txt40RHOwner.Enabled = Me.chk40RHOwner.Checked
        Calculate()
    End Sub

    Private Sub WithMarketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdCustomer.RowCount = 0 Then
                Return
            End If
            Dim _index As Integer = Me.dgdCustomer.CurrentRow.Index
            Dim strSql As String
            mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", _index).Value.ToString
            ' thng tin co ban cua Cus
            strSql = MakeQueryCustomer(" and Customer.Customer_ID='" & mCustomer_Id & "'")
            Dim tbl As DataTable
            tbl = ReadTable(strSql)

            Dim tblMarket As New DataTable
            strSql = "select CustomerMarket_Id,MarketCode,Market,Customer_Code,EnglishName,COMPANY "
            strSql &= " From ((CustomerMarket LEFT JOIN Customer on Customer.Customer_ID=CustomerMarket.Customer_ID) "
            strSql &= " LEFT JOIN Market on CustomerMarket.Market_ID=Market.Market_ID)"
            strSql &= " Where CustomerMarket.continued=1 And CustomerMarket.Customer_ID='" & mCustomer_Id & "'"
            tblMarket = ReadTable(strSql)
            ' add vao report-------------------------------
            ' add report--------------------------------------
            'Dim frm As New frmReportCusMarket
            'frm.oTable = tbl
            'frm.oTableMarket = tblMarket
            'frm.Show(Me)
            '--------------------------------------------------
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub WithCommodityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdCustomer.RowCount = 0 Then
                Return
            End If
            Dim _index As Integer = Me.dgdCustomer.CurrentRow.Index
            Dim strSql As String
            mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", _index).Value.ToString

            strSql = MakeQueryCustomer(" and Customer.Customer_ID='" & mCustomer_Id & "'")
            Dim tbl As DataTable
            tbl = ReadTable(strSql)

            strSql = "select distinct(CustomerCommondity.Commondity_ID),CustomerCommondity.CustomerCommondity_ID,Commondity,Commondity.Remarks as CommondityRemarks,CustomerCommondity.Remarks as CustomerCommondityRemarks,Customer_Code,From_Date,To_Date,Season,Min_tueMonth,AVG_tueMonth,Max_tueMonth,EnglishName,COMPANY "
            strSql &= " From ((CustomerCommondity LEFT JOIN Customer on Customer.Customer_ID=CustomerCommondity.Customer_ID) "
            strSql &= " LEFT JOIN Commondity on CustomerCommondity.Commondity_ID=Commondity.Commondity_ID)"
            strSql &= " Where CustomerCommondity.continued=1 And CustomerCommondity.Customer_ID='" & mCustomer_Id & "'"
            Dim tblCommondity As New DataTable

            tblCommondity = ReadTable(strSql)

            ' add report
            ' add report--------------------------------------
            Dim frm As New frmReportCusCommodity
            frm.oTable = tbl
            frm.oTablecOMMODITY = tblCommondity
            frm.Show(Me)
            '--------------------------------------------------

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub WithPICToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdCustomer.RowCount = 0 Then
                Return
            End If
            Dim _index As Integer = Me.dgdCustomer.CurrentRow.Index
            Dim strSql As String
            mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", _index).Value.ToString

            strSql = MakeQueryCustomer(" and Customer.Customer_ID='" & mCustomer_Id & "'")
            Dim tbl As DataTable
            tbl = ReadTable(strSql)



            Dim tblPic As New DataTable
            strSql = "select PIC_ID,PIC,Pos,DirectLine,Customer_Code,EnglishName,COMPANY "
            strSql &= " From (PIC LEFT JOIN Customer on Customer.Customer_ID=PIC.Customer_ID) "
            strSql &= " Where PIC.continued=1 And PIC.Customer_ID='" & mCustomer_Id & "'"
            tblPic = ReadTable(strSql)

            'add report
            ' add report--------------------------------------
            Dim frm As New frmReportCusPIC
            frm.oTable = tbl
            frm.oTablePIC = tblPic
            frm.Show(Me)
            '--------------------------------------------------

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub WithSaleDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdCustomer.RowCount = 0 Then
                Return
            End If
            Dim _index As Integer = Me.dgdCustomer.CurrentRow.Index
            Dim strSql As String
            mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", _index).Value.ToString

            strSql = MakeQueryCustomer(" and Customer.Customer_ID='" & mCustomer_Id & "'")
            Dim tbl As DataTable
            tbl = ReadTable(strSql)



            Dim TableSaleDetail As New DataTable
            strSql = "Select Booking_ID,Customer_ID,por1.Port as POD,por2.Port as POL,AgencyName, " & _
                     "SL20GPOwner,SL40GPOwner,SL40HCOwner,SL45HCOwner,SL20RFOwner,SL40RFOwner,SL40RHOwner,SL20OTOwner,SL40OTOwner,SL20FROwner,SL40FROwner,SLCBMOwner," & _
                     "SL20GPSale,SL40GPSale,SL40HCSale,SL45HCSale,SL20RFSale,SL40RFSale,SL40RHSale,SL20OTSale,SL40OTSale,SL20FRSale,SL40FRSale,SLCBMSale," & _
                     "Validate,bk.UPDATETIME "
            strSql &= "from ((Booking bk INNER JOIN Port por1 ON por1.Port_ID=bk.POD_ID) " & _
                     "INNER JOIN Port por2 ON por2.Port_ID=bk.POL_ID) " & _
                     "INNER JOIN Agency ON Agency.Agency_ID=bk.Agency_ID " & _
                     "Where Customer_ID='" & mCustomer_Id & "' And bk.Continued=1"
            TableSaleDetail = ReadTable(strSql)

            ' add report--------------------------------------
            Dim frm As New frmReportCusSaleDetail
            frm.oTable = tbl
            frm.oTableSaleDetail = TableSaleDetail
            frm.Show(Me)
            '--------------------------------------------------

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub WithWeeklyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdCustomer.RowCount = 0 Then
                Return
            End If
            Dim _index As Integer = Me.dgdCustomer.CurrentRow.Index
            Dim strSql As String
            mCustomer_Id = Me.dgdCustomer.Item("Customer_Id", _index).Value.ToString

            strSql = MakeQueryCustomer(" and Customer.Customer_ID='" & mCustomer_Id & "'")
            Dim tbl As DataTable
            tbl = ReadTable(strSql)



            Dim TableCusRpt As New DataTable
            strSql = "Select * From CustomerReport Where customer_id='" & mCustomer_Id & "' and continued=1"
            TableCusRpt = ReadTable(strSql)

            ' add report--------------------------------------
            Dim frm As New frmCusWeeklyreport
            frm.oTable = tbl
            frm.oTableweeklyreport = TableCusRpt
            frm.Show(Me)
            '--------------------------------------------------


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdExportMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportMarket.Click
        Try
            If Me.dgdMarket.RowCount > 0 Then

                ExportExecel(Me.dgdMarket, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdExportCommodity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportCommodity.Click
        Try
            If Me.dgdCommondity.RowCount > 0 Then

                ExportExecel(Me.dgdCommondity, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdExportPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportPIC.Click
        Try
            If Me.dgdPIC.RowCount > 0 Then

                ExportExecel(Me.dgdPIC, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdExportSaleDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportSaleDetail.Click
        Try
            If Me.dgdSale.RowCount > 0 Then

                ExportExecel(Me.dgdSale, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdExportReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportReport.Click
        Try
            If Me.dgdCusReport.RowCount > 0 Then

                ExportExecel(Me.dgdCusReport, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            If mCustomer_Id = DefaultValue Then
                MsgBox("Please input Customer")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            mCusBuyerID = DefaultValue
            mCusBuyerStatus = "Add"
            SetBuyerRptItem(True)
            '  set ""
            Me.txtbuyer.Text = ""
            Me.txtAddressBuyer.Text = ""
            Me.txtTelBuyer.Text = ""
            Me.txtemailbuyer.Text = ""
            Me.txtwebsitebuyer.Text = ""
            Me.cbocountry.Text = ""
            Me.txtPICBuyer.Text = ""


            Me.txtPICPosBuyer.Text = ""
            Me.txtTelPosBuyer.Text = ""
            Me.txtEmailPosBuyer.Text = ""

            Me.txtemailbuyer.Text = ""
            Me.cboCommodity.Text = ""

        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.dgdBuyer.RowCount > 0 Then
                index = Me.dgdBuyer.CurrentRow.Index
            Else
                Exit Sub
            End If
            Approve = Me.dgdBuyer.Item("Approvebuyer", index).Value
            EditTable = Me.dgdBuyer.Item("Editablebuyer", index).Value
            If Not Approve And UserRight("mnumarketingsale", "Edit") Then
                SetBuyerRptItem(True)
                mCusBuyerStatus = "Edit"
                mCusBuyerID = Me.dgdBuyer.Item("buyerid", index).Value.ToString
                ' Me.dtpVisitDate.Value = Me.dgdCusReport.Item("VisitDate", index).Value
                'Me.txtRemarksR.Text = Me.dgdCusReport.Item("RemarksR", index).Value
                ' show du lieu
                Me.txtbuyer.Text = Me.dgdBuyer.Item("buyer", index).Value.ToString
                Me.txtAddressBuyer.Text = Me.dgdBuyer.Item("addressbuyer", index).Value.ToString
                Me.txtTelBuyer.Text = Me.dgdBuyer.Item("telbuyer", index).Value.ToString
                Me.txtemailbuyer.Text = Me.dgdBuyer.Item("emailbuyer", index).Value.ToString
                Me.txtwebsitebuyer.Text = Me.dgdBuyer.Item("website", index).Value.ToString
                Me.cbocountry.Text = Me.dgdBuyer.Item("countrybuyer", index).Value.ToString
                Me.txtPICBuyer.Text = Me.dgdBuyer.Item("pic1name", index).Value.ToString
                Me.txtBuyerFax.Text = Me.dgdBuyer.Item("buyerfax", index).Value.ToString

                Me.txtPICPosBuyer.Text = Me.dgdBuyer.Item("pic1pos", index).Value.ToString
                Me.txtTelPosBuyer.Text = Me.dgdBuyer.Item("pic1tel", index).Value.ToString

                Me.txtEmailPosBuyer.Text = Me.dgdBuyer.Item("pic1email", index).Value.ToString
                Me.cboCommodity.Text = Me.dgdBuyer.Item("commodity", index).Value.ToString
                Me.chkConsigneeShipper.Checked = Me.dgdBuyer.Item("consigneeshipper", index).Value.ToString

            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim index As Integer
        If Me.dgdBuyer.RowCount > 0 Then
            index = Me.dgdBuyer.CurrentRow.Index
        Else
            Exit Sub
        End If
        Dim strMesg As String = "Delete the Buyer : " & Me.dgdBuyer.Item("Buyer", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then


            If Not Me.dgdBuyer.Item("approveBuyer", index).Value Then


                If Not Me.dgdBuyer.Item("editableBuyer", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then

                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Else
                    Dim strQuery As String
                    strQuery = "select * from buyer where buyerid='" & Me.dgdBuyer.Item("buyerid", index).Value.ToString & "' And Continued=1"
                    Dim rs As New ADODB.Recordset
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    rs.Fields("Continued").Value = 0
                    rs.Update()
                    rs.Close()
                End If
            Else
                DisplayMessage(True, IIf(gLang = "E", "Dữ liệu đã được Approve, xin liên hệ với Admin!", "Bạn cần được cấp quyền."))
            End If
        End If
        Me.QueryCustomerBuyer()
    End Sub

    Private Sub cmdOKBuyer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKBuyer.Click
        Try
            If (mCusBuyerStatus = "Add" Or mCusBuyerStatus = "Edit") Then
                Dim index As Integer = 0
                If Me.dgdBuyer.RowCount > 0 Then
                    If Not IsNothing(Me.dgdBuyer.CurrentRow) Then
                        index = Me.dgdBuyer.CurrentRow.Index
                    Else
                        Exit Sub
                    End If
                End If
                Dim strQuery As String
                Dim rs As New ADODB.Recordset

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM buyer "
                strQuery = strQuery & "WHERE buyerId = '" & mCusBuyerID & "' AND buyerId <> '" & DefaultValue & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        .AddNew()
                        .Fields("BuyerID").Value = NewId()
                        .Fields("Customer_ID").Value = "{" & mCustomer_Id & "}"
                    End If

                    .Fields("Buyer").Value = Me.txtbuyer.Text.Trim
                    .Fields("ADDRESS").Value = Me.txtAddressBuyer.Text.Trim
                    .Fields("TEL").Value = Me.txtTelBuyer.Text.Trim
                    .Fields("fax").Value = Me.txtBuyerFax.Text.Trim
                    .Fields("EMAIL").Value = Me.txtemailbuyer.Text.Trim
                    .Fields("website").Value = Me.txtwebsitebuyer.Text.Trim
                    .Fields("country").Value = Me.cbocountry.Text.Trim

                    .Fields("pic1name").Value = Me.txtPICBuyer.Text.Trim
                    .Fields("pic1Pos").Value = Me.txtPICPosBuyer.Text.Trim
                    .Fields("pic1Tel").Value = Me.txtTelPosBuyer.Text.Trim
                    .Fields("pic1Email").Value = Me.txtEmailPosBuyer.Text.Trim
                    .Fields("commodity").Value = Me.cboCommodity.Text.Trim
                    Try
                        .Fields("consigneeShipper").Value = Me.chkConsigneeShipper.Checked
                    Catch ex As Exception

                    End Try


                    '.Fields("VisitDate").Value = Me.dtpVisitDate.Value.Date.Date
                    '.Fields("Remarks").Value = Me.txtRemarksR.Text.Trim

                    .Update()
                End With
                rs.Close()
                Me.QueryCustomerBuyer(index)
                SetBuyerRptItem(False)
                mCusBuyerStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SetBuyerRptItem(False)

        mCusBuyerStatus = "Normal"
    End Sub

    Private Sub dgdBuyer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBuyer.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdBuyer.RowCount = 0 Then
            Return
        End If
        index = Me.dgdBuyer.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdBuyer.Columns(ColIndex).Name) = "APPROVEBUYER" And Me.dgdBuyer.CurrentCellAddress().Y = index Then
            Call ApproveBuyerA()
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdCusReport_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCusReport.CellContentClick

    End Sub

    Private Sub cmdExportXLSBuyer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportXLSBuyer.Click
        Try
            If Me.dgdBuyer.RowCount > 0 Then

                ExportExecel(Me.dgdBuyer, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselect.Click
        Me.txtValidUser.Text += Me.cboUser.Text + ","
    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    

    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmReportSale, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstyleJV.CheckedChanged

    End Sub

    Private Sub TextBox52_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox71_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox82_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label148_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label183_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label185_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tabBaseinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabBaseinfo.Click

    End Sub

    Private Sub SentEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SentEmailToolStripMenuItem.Click
        Me.GroupBox8.BringToFront()
        Me.GroupBox8.Visible = True


        If Me.dgdCustomer.Rows.Count = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            Return
        End If

        Dim index As Integer = Me.dgdCustomer.CurrentRow.Index
        If index >= 0 Then
            Me.txtemailnguoinhan.Text = Me.dgdCustomer.Item("email", index).Value.ToString
        End If
    End Sub

    

    

    Private Sub cmdSent_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
   
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.GroupBox8.Visible = False
    End Sub

    Private Sub cmdReviewHTML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtSFileName.Text = Me.OpenFileDialog1.FileName
            End If
            If Me.txtSFileName.Text = "" Then
                DisplayMessage(True, "Please input file path.")
                Me.txtSFileName.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim strQuery, strSale, strCustomer_Id, pName As String
            Dim rs As New ADODB.Recordset

            Dim index As Integer





            strQuery = "SELECT * "
            strQuery = strQuery & "FROM class "
            strQuery = strQuery & "WHERE username = '" & strUserId & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("class_id").Value = NewId()

                    'If UCase(gDepartment) = "SALE" Then

                    'End If
                End If

                .Fields("t1").Value = Me.txtname.Text.Trim
                .Fields("t2").Value = Me.txtSubject.Text.Trim
                .Fields("t3").Value = Me.txtKinhgui.Text.Trim

                .Fields("t4").Value = Me.txtGiay.Text.Trim


                .Fields("t5").Value = Me.txtemailnguoigui.Text.Trim

                .Fields("t6").Value = Me.txtsmtp.Text.Trim
                .Fields("t7").Value = Me.txtpass.Text.Trim
                .Fields("t8").Value = Me.txtport.Text.Trim
                .Fields("username").Value = strUserId

                '-------------------081013
                .Update()

            End With
            rs.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from class where username='" & strUserId & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txtname.Text = ds.Tables(0).Rows(0).Item("t1").ToString
                Me.txtSubject.Text = ds.Tables(0).Rows(0).Item("t2").ToString
                Me.txtKinhgui.Text = ds.Tables(0).Rows(0).Item("t3").ToString

                Me.txtGiay.Text = ds.Tables(0).Rows(0).Item("t4").ToString


                Me.txtemailnguoigui.Text = ds.Tables(0).Rows(0).Item("t5").ToString

                Me.txtsmtp.Text = ds.Tables(0).Rows(0).Item("t6").ToString
                Me.txtpass.Text = ds.Tables(0).Rows(0).Item("t7").ToString
                Me.txtport.Text = ds.Tables(0).Rows(0).Item("t8").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HisrotyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HisrotyToolStripMenuItem.Click
        Try
            Try


                Dim sqlkt As String
                Dim dskt As New DataSet
                Dim Approve, EditTable, UsrRight As Boolean

                'kiểm tra xem Grid có dữ liệu không

                If Me.dgdCustomer.RowCount = 0 Then
                    DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                    Return
                End If
                Dim index As Integer = Me.dgdCustomer.CurrentRow.Index
              

                If index >= 0 Then



                    gViewHistory = Me.dgdCustomer.Item("Customer_ID", index).Value.ToString

                    frmViewHistory.Show()

                End If

            Catch ex As Exception
                MsgBox(msgErr(Me, Err.Description))
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.txtEnglishName.Text = Me.txtCompany.Text
            Me.txtAddress.Text = Me.txtAddresstiengviet.Text
        Catch ex As Exception

        End Try
    End Sub
    Public Sub AmountMonth()
        Try
            Dim tong As Double = 0
            Try
                tong += CDbl(txtfrevolCourier.Text)
            Catch ex As Exception

            End Try

            Try
                tong += CDbl(txtfrevollogistics.Text)
            Catch ex As Exception

            End Try

            Try
                tong += CDbl(txtFreVolAirfreight.Text)
            Catch ex As Exception

            End Try


            Try
                tong += CDbl(txtfrevolseafreight.Text)
            Catch ex As Exception

            End Try

            Try
                tong += CDbl(txtfrevolothers.Text)
            Catch ex As Exception

            End Try












            txtfrevolamount.Text = tong





        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtfrevolCourier_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfrevolCourier.TextChanged
        Try
            AmountMonth()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtfrevollogistics_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfrevollogistics.TextChanged
        Try
            AmountMonth()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFreVolAirfreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreVolAirfreight.TextChanged
        Try
            AmountMonth()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtfrevolseafreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfrevolseafreight.TextChanged
        Try
            AmountMonth()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtfrevolothers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfrevolothers.TextChanged
        Try
            AmountMonth()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim MakeQueryCustomer As String
            MakeQueryCustomer = strDateOfCustomerSelect
            MakeQueryCustomer = MakeQueryCustomer & " ,kpis,shortname,addressTiengviet,tilecom,hancongno,sotaikhoan,district, ngaythem,new,pic,commodity,trafic,sea,air,imp,exp,contentofreport,PHUPHICOURIER From ((((Customer LEFT JOIN CustomerMarket On CustomerMarket.Customer_ID=Customer.Customer_ID)"
            MakeQueryCustomer = MakeQueryCustomer & " LEFT JOIN Market On Market.Market_id=CustomerMarket.Market_ID) "
            MakeQueryCustomer = MakeQueryCustomer & " LEFT JOIN CustomerCommondity On CustomerCommondity.Customer_ID=Customer.Customer_ID) "
            MakeQueryCustomer = MakeQueryCustomer & " LEFT JOIN Commondity On Commondity.Commondity_ID=CustomerCommondity.Commondity_ID) "
            MakeQueryCustomer = MakeQueryCustomer & " WHERE  "
            '        MakeQueryCustomer = MakeQueryCustomer & ""
            MakeQueryCustomer = MakeQueryCustomer & " Customer.Continued = 1 "
            ' lay so lieu tu Option
            Dim strQuery, value As String
            Dim rs As New ADODB.Recordset
            value = "0"
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [option] "
            strQuery = strQuery & "WHERE frmName = 'frmListCustomer' and OptionCode='PermissionCustomer' And Continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If Not rs.EOF Then
                    value = .Fields("optionvalue").Value
                End If

            End With
            rs.Close()
            '---------------------------------
            If value = "1" Then
                If UCase(gDepartment) <> "OUTBOUND" And UCase(gDepartment) <> "MANAGEMENT" And UCase(gDepartment) <> "BOOKING" And UCase(gDepartment) <> "ACCOUNT" And UCase(gDepartment) <> "OPERATION" And UCase(gDepartment) <> "SALE MANAGEMENT" Then
                    MakeQueryCustomer = MakeQueryCustomer & " And salename='" & UCase(GETSALECODE(strUser)).Trim & "' and (branch like '%" & gBranch & "%') "
                End If
            End If

            'If Not IsNothing(argCriteria) And argCriteria <> "" Then
            If Me.cbosale1.Text <> "" Then
                MakeQueryCustomer = MakeQueryCustomer & " and salename = '" & Me.cbosale1.Text & "'"
            End If
            If Me.txtMainCode1.Text <> "" Then
                MakeQueryCustomer = MakeQueryCustomer & " and maincode = '" & Me.txtMainCode1.Text & "'"
            End If

            If Me.cboquan1.Text <> "" Then
                MakeQueryCustomer = MakeQueryCustomer & " and district = '" & Me.cboquan1.Text & "'"
            End If

            If Me.txtProvince1.Text <> "" Then
                MakeQueryCustomer = MakeQueryCustomer & " and Province = '" & Me.txtProvince1.Text & "'"
            End If
            If Me.txtIndustry1.Text <> "" Then
                MakeQueryCustomer = MakeQueryCustomer & " and Industry = '" & Me.txtIndustry1.Text & "'"
            End If

            If Me.cbokpis.Text <> "" Then
                MakeQueryCustomer = MakeQueryCustomer & " and kpis = '" & Me.cbokpis1.Text & "'"
            End If



            ' MakeQueryCustomer = MakeQueryCustomer & " and salename = '" & Me.cbosale1.Text & "' and maincode ='" & Me.txtMainCode1.Text & "' and district = '" & Me.cboquan1.Text & "' and Province= '" & Me.txtProvince1.Text & "' and industry  = '" & Me.txtIndustry1.Text & "' and kpis = '" & Me.cbokpis.Text & "'  "
            'End If
            'If index = 1 Then ' 
            MakeQueryCustomer = MakeQueryCustomer & " order by Customer_code "

            '==================================================
            ' Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim ds As New DataSet
            '----------------
            'If IsNothing(argCriteria) Then
            '    strQuery = MakeQueryCustomer()
            'Else
            '    strQuery = MakeQueryCustomer(argCriteria, index)
            'End If
            Con.Open()
            Dim CmdSelect As New SqlClient.SqlCommand(MakeQueryCustomer, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ' Con.Open()
            Adapter.Fill(ds, "CustomerList")
            oTable = ds.Tables(0)
            'hien thi ra grid 
            Me.dgdCustomer.DataSource = ds.Tables("CustomerList")
            If Me.dgdCustomer.Enabled = False Then
                Me.dgdCustomer.Enabled = True
            End If

            Me.Cursor = System.Windows.Forms.Cursors.Default
            If oTable.Rows.Count > 0 Then
                Me.dgdCustomer.Columns.Item("Customer_Code").ToolTipText = "Hiện có:" + CStr(Me.dgdCustomer.RowCount()) + " Customers."
            End If
            If Me.dgdCustomer.RowCount() = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            End If
            '------------vị trí BM
            'If location > 0 And location <= Me.dgdCustomer.Rows.Count And Me.dgdCustomer.Rows.Count > 0 Then
            '    Me.dgdCustomer.Rows(location).Selected = True
            '    Me.dgdCustomer.CurrentCell = Me.dgdCustomer.Rows(location).Cells(2)
            'End If
            '--------------------
            InsertAutoNumberToGrid(Me.dgdCustomer)
            '==========================================================



        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbirthday_Leave(sender As Object, e As EventArgs) Handles txtbirthday.Leave
        Try
            If Me.txtbirthday.Text.Length = 11 Then

            Else
                DisplayMessage(True, "Ngày Birthday không đúng định dạng (dd-MMM-yyyy).!")
                Me.txtbirthday.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbirthday_TextChanged(sender As Object, e As EventArgs) Handles txtbirthday.TextChanged

    End Sub

    Private Sub cmdSent_Click_2(sender As Object, e As EventArgs) Handles cmdSent.Click
        Try

            ' '' ''Dim Smtp_Server As New SmtpClient
            ' '' ''Dim e_mail As New MailMessage()
            ' '' ''Smtp_Server.UseDefaultCredentials = False
            ' '' ''Smtp_Server.Credentials = New Net.NetworkCredential(Me.txtemailnguoigui.Text, Me.txtpass.Text)
            ' '' ''Smtp_Server.Port = Me.txtport.Text
            ' '' ''Smtp_Server.EnableSsl = Me.chkSsl.Checked
            ' '' ''Smtp_Server.Host = Me.txtsmtp.Text

            ' '' ''e_mail = New MailMessage()
            ' '' ''e_mail.From = New MailAddress(Me.txtemailnguoigui.Text)
            ' '' ''e_mail.To.Add(Me.txtemailnguoinhan.Text)
            ' '' ''e_mail.Subject = Me.txtSubject.Text
            ' '' ''e_mail.IsBodyHtml = False
            ' '' ''e_mail.Body = Me.txtNoidungEmail.Text
            ' '' ''Smtp_Server.Send(e_mail)
            ' '' ''MsgBox("Mail Sent")

            Dim chk As Integer
            chk = Me.dgdCustomer.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            Dim selectedRowCount As Integer = _
           Me.dgdCustomer.Rows.GetRowCount(DataGridViewElementStates.Selected)
            Dim f As Integer = 0
            Dim diachi, noidung, MySqlID As String
            ''----------lay quyen truy cap hop dong

            Dim chuoi, sqlo As String
            'If LoginSucceeded = False Then
            '    Return
            'End If
            'Dim rsPQ As New ADODB.Recordset
            'sqlo = "select optionvalue from [Option] where optioncode='EmailServer' "

            'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
            'If Not rsPQ.EOF Then
            '    chuoi = rsPQ.Fields("optionvalue").Value.ToString
            'End If
            'rsPQ.Close()
            ''----------------------------------

            Dim chuoi1 As String
            'If LoginSucceeded = False Then
            '    Return
            'End If

            'sqlo = "select optionvalue from [Option] where optioncode='NoidungEmailXacNhan' "

            'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
            'If Not rsPQ.EOF Then
            '    chuoi1 = rsPQ.Fields("optionvalue").Value.ToString
            'End If
            'rsPQ.Close()


            '   Dim email, smtp, pass, port As String
            Dim tach() As String

            '   Me.txtemailnguoigui.Text += ";" + Me.txtsmtp.Text + ";" + Me.txtpass.Text + ";" + Me.txtport
            'If Me.txtemailnguoigui.Text = "" Then
            '    tach = chuoi.Split(";")
            'Else
            '    tach = Me.txtemailnguoigui.Text.Split(";")
            'End If

            gemail = Me.txtemailnguoigui.Text.Trim
            gsmtp = Me.txtsmtp.Text.Trim
            gpass = Me.txtpass.Text.Trim
            gport = Me.txtport.Text.Trim

            Dim noidungemail As String

            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                Dim ten As String
                For i = 0 To selectedRowCount - 1
                    ' chon thong tin theo index
                    diachi = Me.dgdCustomer.Item("Email", Me.dgdCustomer.SelectedRows(i).Index).Value.ToString
                    ten = Me.dgdCustomer.Item("company", Me.dgdCustomer.SelectedRows(i).Index).Value.ToString '+ " ( Tel: " + Me.dgdCustomer.Item("company", Me.dgdCustomer.SelectedRows(i).Index).Value.ToString + ") "

                    MySqlID = chuoi1 + Me.dgdCustomer.Item("Customer_ID", Me.dgdCustomer.SelectedRows(i).Index).Value.ToString
                    noidungemail = Me.txtKinhgui.Text + " " + ten + " " + Chr(13) + Chr(10) + Me.txtNoidungEmail.Text.ToString
                    If diachi <> "" Then

                        SendMailMessage_cus(gemail, diachi, "", "", Me.txtSubject.Text, noidungemail, Me.txtSFileName.Text)
                        'updateSendEmail(Me.dgdkhachhang.Item("id", Me.dgdHopdong.SelectedRows(i).Index).Value.ToString)
                        'Sleep(10)
                        System.Threading.Thread.Sleep(CInt(Me.txtGiay.Text))
                    End If

                    f = 1
                Next i
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub SendMailMessage_cus(ByVal from As String, ByVal recepient As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String, ByVal Attachfile As String)
        Try


            ' Instantiate a new instance of MailMessage
            Dim mMailMessage As New MailMessage()

            ' Set the sender address of the mail message
            mMailMessage.From = New MailAddress(from)
            ' Set the recepient address of the mail message
            mMailMessage.To.Add(New MailAddress(recepient))

            ' Check if the bcc value is nothing or an empty string
            If Not bcc Is Nothing And bcc <> String.Empty Then
                ' Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(New MailAddress(bcc))
            End If

            ' Check if the cc value is nothing or an empty value
            If Not cc Is Nothing And cc <> String.Empty Then
                ' Set the CC address of the mail message
                mMailMessage.CC.Add(New MailAddress(cc))
            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = subject
            ' Set the body of the mail message
            mMailMessage.Body = body

            ' Set the format of the mail message body as HTML
            If chkhtml.Checked = True Then
                mMailMessage.IsBodyHtml = True
            Else
                mMailMessage.IsBodyHtml = False
            End If

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal
            'mMailMessage.
            '----------lay quyen truy cap hop dong
            Dim chuoi, sqlo As String
            If LoginSucceeded = False Then
                Return
            End If
            'Dim rsPQ As New ADODB.Recordset
            'sqlo = "select optionvalue from [Option] where optioncode='EmailServer' "

            'rsPQ.Open(sqlo, CSCLEnv.CSCLConn, , , ADODB.CommandTypeEnum.adCmdText)
            'If Not rsPQ.EOF Then
            '    chuoi = rsPQ.Fields("optionvalue").Value.ToString
            'End If
            'rsPQ.Close()

            '----------------------------------
            Dim email, smtp, pass, port As String
            Dim tach() As String
            'If frmListCustomer.txtemailnguoigui.Text = "" Then
            '    tach = chuoi.Split(";")
            'Else
            '    tach = frmListCustomer.txtemailnguoigui.Text.Split(";")
            'End If
            If Attachfile = "" Then

            Else
                If FileExists_cus(Attachfile) Then _
                 mMailMessage.Attachments.Add(New Mail.Attachment(Attachfile))

            End If
            email = gemail 'frmListCustomer.txtemailnguoigui.Text.Trim '+ " <" + Me.txtemailnguoigui.Text + ">"
            smtp = gsmtp 'frmListCustomer.txtsmtp.Text.Trim
            pass = gpass 'frmListCustomer.txtpass.Text.Trim
            port = gport 'frmListCustomer.txtport.Text.Trim
            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient()
            ' Send the mail message
            mSmtpClient.Host = smtp
            mSmtpClient.Port = CInt(port)
            If txttimeout.Text <> "" Then
                mSmtpClient.Timeout = CInt(txttimeout.Text)
            End If


            'If UCase(smtp) = "SMTP.GMAIL.COM" Then
            If chkSsl.Checked = True Then
                mSmtpClient.EnableSsl = True
            End If

            'End If
            mSmtpClient.UseDefaultCredentials = False
            mSmtpClient.Credentials = New System.Net.NetworkCredential(email, pass)

            Try
                mSmtpClient.Send(mMailMessage)
                DisplayMessage(True, "Đã gửi email.!")
                TextBox1.Text += " " + recepient + Chr(13) + Chr(10)
            Catch ex As Exception

                DisplayMessage(True, ex.ToString())

            End Try




        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try




    End Sub
    Private Function FileExists_cus(ByVal FileFullPath As String) _
 As Boolean
        If Trim(FileFullPath) = "" Then Return False

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function
    Private Sub cmdSent_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtSFileName.Text = Me.OpenFileDialog1.FileName
            End If
            If Me.txtSFileName.Text = "" Then
                DisplayMessage(True, "Please input file path.")
                Me.txtSFileName.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Try
            Dim strQuery, strSale, strCustomer_Id, pName As String
            Dim rs As New ADODB.Recordset

            Dim index As Integer





            strQuery = "SELECT * "
            strQuery = strQuery & "FROM class "
            strQuery = strQuery & "WHERE username = '" & strUserId & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("class_id").Value = NewId()

                    'If UCase(gDepartment) = "SALE" Then

                    'End If
                End If

                .Fields("t1").Value = Me.txtname.Text.Trim
                .Fields("t2").Value = Me.txtSubject.Text.Trim
                .Fields("t3").Value = Me.txtKinhgui.Text.Trim

                .Fields("t4").Value = Me.txtGiay.Text.Trim


                .Fields("t5").Value = Me.txtemailnguoigui.Text.Trim

                .Fields("t6").Value = Me.txtsmtp.Text.Trim
                .Fields("t7").Value = Me.txtpass.Text.Trim
                .Fields("t8").Value = Me.txtport.Text.Trim
                .Fields("username").Value = strUserId

                '-------------------081013
                .Update()

            End With
            rs.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX3_Click_1(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from class where username='" & strUserId & "'"
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.txtname.Text = ds.Tables(0).Rows(0).Item("t1").ToString
                    Me.txtSubject.Text = ds.Tables(0).Rows(0).Item("t2").ToString
                    Me.txtKinhgui.Text = ds.Tables(0).Rows(0).Item("t3").ToString

                    Me.txtGiay.Text = ds.Tables(0).Rows(0).Item("t4").ToString


                    Me.txtemailnguoigui.Text = ds.Tables(0).Rows(0).Item("t5").ToString

                    Me.txtsmtp.Text = ds.Tables(0).Rows(0).Item("t6").ToString
                    Me.txtpass.Text = ds.Tables(0).Rows(0).Item("t7").ToString
                    Me.txtport.Text = ds.Tables(0).Rows(0).Item("t8").ToString
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Try
                Me.GroupBox8.Visible = False
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdReviewHTML_Click_1(sender As Object, e As EventArgs) Handles cmdReviewHTML.Click

    End Sub
End Class