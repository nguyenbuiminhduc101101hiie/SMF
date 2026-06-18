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
Public Class frmNhatkysuachua
    Inherits System.Windows.Forms.Form
    Dim QuyenHan As String
    Dim strUser As String

    Dim index As Integer = 0
    Dim rsCustomerList As New ADODB.Recordset
    Dim mStatus, mFilter, mCommondityStatus, mPICStatus, mSaleStatus, mCusRptStatus As String
    Public blnUpdated As Boolean
    Public mNhatKySuaChuaID As String
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

    Dim PortPOLPOD As String
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try


            Dim strQuery, strSale, strCustomer_Id, pName As String
            Dim rs As New ADODB.Recordset
            Dim rsSale As New ADODB.Recordset
            Dim index As Integer

            '---------------  
            Dim seri As Integer
            Dim temp As String
            If mStatus = "Add" Then
                'seri = CDbl(getCusID()) + 1
                'For h As Integer = seri.ToString.Length To 5
                '    temp &= "0"
                'Next
                'temp &= seri
                'Me.txtCustomer_Code.Text = temp
            End If


            '------------------
            If (mStatus = "Add" Or mStatus = "Edit") Then

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM nhatKySuachua "
                strQuery = strQuery & "WHERE nhatKySuachuaID = '" & mNhatKySuaChuaID & "' AND nhatkysuachuaID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("nhatKySuachuaID").Value = NewId()

                    End If
                    .Fields("CustomerID").Value = "{" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "}"

                    .Fields("thietbiID").Value = "{" & FindValueID(Me.cbosoxe, Me.cbosoxe.Text) & "}"

                    .Fields("chinhanh").Value = Me.cboBookingOffice.Text
                    .Fields("so").Value = Me.txtso.Text

                    .Fields("ngay").Value = ddMMMyyyy(Me.dtpNgay.Value.Date)
                    .Fields("thoigian").Value = Me.txtthoigian.Text


                    .Fields("litdau").Value = Me.txtlitdau.Text
                    .Fields("tinhtrang").Value = Me.txttinhtrang.Text


                    .Fields("tenphi").Value = Me.txttenphi.Text
                    .Fields("soluong").Value = Me.txtsoluong.Text
                    .Fields("dongia").Value = Me.txtdongia.Text
                    .Fields("thue").Value = Me.txtthue.Text
                    .Fields("thanhtien").Value = Me.txtthanhtien.Text
                    .Fields("chietkhau").Value = Me.txtchietkhau.Text




                    .Update()
                    DisplayMessage(True, "Lưu thành công.!")

                End With
                rs.Close()
                '===================================================================
                'Dim cmd1 As New ADODB.Command
                'Dim strconn1, strServer1, strUserName1, strPassword1, strDatabase1 As String
                'strServer1 = "vietnamforwarder.com"hvbg m
                'strUserName1 = "admin"
                'strPassword1 = "qwe123!@#"
                'strDatabase1 = "smf"
                'strconn1 = "Provider=sqloledb;Data Source='" & strServer1 & "'; User ID='" & strUserName1 & "'; password='" & strPassword1 & "'; Initial Catalog='" & strDatabase1 & "'"
                'Try

                '    cmd1.let_ActiveConnection(strconn1)
                '    cmd1.CommandText = "INSERT customer"
                '    cmd1.CommandText = cmd1.CommandText & "(TaxCode,Company,Address,Addresstiengviet) "
                '    cmd1.CommandText = cmd1.CommandText & "VALUES ('" & Me.txtTaxCode.Text & "','" & Me.txtCompany.Text & "','" & Me.txtAddress.Text & "','" & Me.txtAddresstiengviet.Text & "') "
                '    'Debug.Print cmd.CommandText
                '    cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                'Catch ex As Exception
                '    'DisplayMessage(True, Err.Description)
                'End Try
                '============================================================================

                'If mStatus = "Edit" Then
                QueryBookingAgent(, , index)
                'End If
                ' Me.fraUpdate.Visible = False
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
    Private Function MakeQueryCustomer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomer = " Select nhatkysuachuaID,thietbiID,nhatkysuachua.customerid,chinhanh,so,ngay,thoigian,litdau,tinhtrang,tenphi,soluong,dongia,thue,thanhtien,chietkhau,nhatkysuachua.userupdate,nhatkysuachua.dateupdate,nhatkysuachua.approve,nhatkysuachua.continued,nhatkysuachua.editable from nhatkysuachua left join customer on nhatkysuachua.customerid=customer.customer_id left join dmdaukeo on dmdaukeo.dmdaukeoid=nhatkysuachua.thietbiid "

        MakeQueryCustomer = MakeQueryCustomer & " WHERE  nhatkysuachua.continued=1 "
        '        MakeQueryCustomer = MakeQueryCustomer & ""
       

        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCustomer = MakeQueryCustomer & argCriteria
        End If
        'If index = 1 Then ' 
        MakeQueryCustomer = MakeQueryCustomer & " order by so "
        'ElseIf index = 15 Then ' 
        '    MakeQueryCustomer = MakeQueryCustomer & strDateOfCustomerOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    Public Function GETSALECODE(ByVal USERNAME As String) As String

        Dim strQuery, _SALECODE As String
        Dim RSSALECODE As New ADODB.Recordset
        strQuery = "SELECT SALECODE FROM SALE WHERE USR='" & USERNAME & "'"
        RSSALECODE.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not RSSALECODE.EOF Then
            _SALECODE = RSSALECODE.Fields("SALECODE").Value.ToString
        Else
            _SALECODE = ""
        End If
        RSSALECODE.Close()
        Return _SALECODE
    End Function

    Private Sub QueryBookingAgent(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
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
        Me.dgdContianerOutboundNotify.DataSource = ds.Tables("CustomerList")
        If Me.dgdContianerOutboundNotify.Enabled = False Then
            Me.dgdContianerOutboundNotify.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default

        '------------vị trí BM
        'If location > 0 And location <= Me.dgdCustomer.Rows.Count And Me.dgdCustomer.Rows.Count > 0 Then
        '    Me.dgdCustomer.Rows(location).Selected = True
        '    Me.dgdCustomer.CurrentCell = Me.dgdCustomer.Rows(location).Cells(2)
        'End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & ", bạn nên dùng menu View để hiển thị hết toàn bộ thông tin trong Bảng dữ liệu, ")
        'Resume
    End Sub
    Private Sub frmBookingAgent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim id, value, strQuery As String
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 Order by company "
            Me.cboCompany.Items.Clear()
            loadDataToObject(Me.cboCompany, strQuery, id, value)
            '-SALES

          
        
            '----------------




            QueryVoy()

            QueryVessel()
            '-------------------

            SetDefaultGrid(Me.dgdContianerOutboundNotify, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'SetDefaultGrid(Me.dgdCountMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

            'SetDefaultGrid(Me.dgdBookingContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'SetDefaultGrid(Me.dgdBookingContainerAll, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            mStatus = "Normal"
            blnUpdated = False

            '  Me.GroupBox5.Visible = False

            mNhatKySuaChuaID = DefaultValue
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.fraUpdate.Visible = False








            mFilter = objUserSetting.GetCParm("frmContainerOutBoundNotify.mFilter")

            If gOptCurProfile <> "CSCL_IOB" Then
                objProfile.Profile(gOptCurProfile, Me.Name, "Get")
            End If



            Me.Height = CShort(ctrFrmMain.Height * 0.9)
            Me.Width = CShort(ctrFrmMain.Width * 0.85)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            screenbkH = frmMain.Height
            screenbkV = frmMain.Width
            ReFormat()
            '----set mau nen,fra
            Me.BackColor = gMaunen

            Dim sql As String
            Dim ds As New DataSet
            sql = "select optionvalue from [Option] where optioncode='EmailServer' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' Me.txtSMTP.Text = ds.Tables(0).Rows(0).Item("optionvalue").ToString
            End If
            '---------------
         
          

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Booking (Logistics)"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Booking (Logistics)  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Booking (Logistics) -> Add."
        End If

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

        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdOK.Top = fraUpdate.Bottom + cmdOK.Height - 22
        'cmdCancel.Top = fraUpdate.Bottom + cmdOK.Height - 22
        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10

        'cmdFind.Left = Me.txtContainerOutboundNotify.Left + Me.txtContainerOutboundNotify.Width + 10
        'txtContainerOutboundNotify.Width = Me.Width - 400

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try

            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            reText(mStatus)
            Me.dgdContianerOutboundNotify.Enabled = True


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
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
        If Not IsNothing(Me.dgdContianerOutboundNotify.Item("Editable", index)) Then
            If Not Me.dgdContianerOutboundNotify.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmBookingAgent", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Booking: " & Me.dgdContianerOutboundNotify.Item("gmd_bookingno", index).Value.ToString
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
                cmd.CommandText = "delete from bookingagent where BookingAgentID= '" & Me.dgdContianerOutboundNotify.Item("BookingAgentID", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
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
            Me.QueryBookingAgent()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try

            Try
                Dim id, value, strQuery As String
                id = "customer_id"
                value = "company"
                strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 Order by company "
                Me.cboCompany.Items.Clear()
                loadDataToObject(Me.cboCompany, strQuery, id, value)
                '-SALES
            Catch ex As Exception

            End Try
            Dim chk As Integer
            chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If

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
                If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmnhatkysuachua", "Edit") Then
                    If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                        index = Me.dgdContianerOutboundNotify.CurrentRow.Index
                    End If
                    mNhatKySuaChuaID = Me.dgdContianerOutboundNotify.Item("bookingagentid", index).Value.ToString.Trim
                    Me.cmdOK.Enabled = True
                    mStatus = "Edit"
                    Me.fraUpdate.Visible = True
                    Me.dgdContianerOutboundNotify.Enabled = True
                    ReFormat()
                    SetMenu((False))

                    RefreshData(index)


                Else
                    DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
                End If
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString

            ' hien thi lcl
            Dim bookingno As String
            If index < 0 Then
                Return
            End If

            ' bookingno = Me.dgdContianerOutboundNotify.Item("bookingno", index).Value.ToString
            Dim sql As String
            Dim ds As New DataSet

            sql = "select * from BookingAgent where BookingAgentID='" & mNhatKySuaChuaID & "' and continued=1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    '----------------------------------------------
                    '.Fields("bookingOffice").Value = Me.cboBookingOffice.Text
                    '.Fields("contactPerson").Value = Me.txtcontactperson.Text
                    '.Fields("Remarks_").Value = Me.TXTREMARKS.Text
                    '.Fields("TranshipmentPort").Value = Me.TXTTRANSHIPMENTPORT.Text
                    '.Fields("CutOffTime").Value = Me.TXTCUTOFFTIME.Text
                    '.Fields("Type_").Value = Me.TXTTYPE.Text
                    '.Fields("ForStuffing").Value = Me.txtforstuffing.Text
                   

                    Me.txtso.Text = ds.Tables(0).Rows(0).Item("so").ToString
                    Me.txttinhtrang.Text = ds.Tables(0).Rows(0).Item("tinhtrang").ToString
               
                   
                   



             



















                Catch ex As Exception

                End Try
            End If
            '----------------------
            QueryVessel()
            ' hien thi booking edi------------------------------------




        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub
    Sub QueryVessel()
        On Error GoTo Err_Renamed
        'Dim id, value, strSQL As String
        'id = "gmd_vessel"
        'value = "gmd_vessel"
        ''strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        'strSQL = "Select distinct gmd_vessel  "
        'strSQL = strSQL & " From bookingagent order by gmd_vessel " '
        'loadDataToObject(Me.txtgmd_vessel, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem.Click
        Try

            If mStatus = "Normal" And UserRight("frmBookingAgent", "Add") Then
                ' Me.txtCustomer.Enabled = True

                Me.fraUpdate.Visible = True
                Me.dgdContianerOutboundNotify.Enabled = False
                ReFormat()
                SetMenu((False))

                mNhatKySuaChuaID = DefaultValue

                mStatus = "Add"
                reText(mStatus)

                '------------
                'Me.cboRepresentative.Text = ""

                'Me.txtgmd_bookingnoCarrier.Text = ""
                'Me.txtgmd_bookingno.Text = ""
                'Me.txtgmd_bookingnoCarrier.Text = ""

                'Me.txtgmd_shipper.Text = ""

                '' Me.txtgmd_consignee.Text = ""
                'Me.txtgmd_vessel.Text = ""
                'Me.txtgmd_voy.Text = ""

                'Me.txtgmd_etd.Text = ""
                '  Me.txtgmd_eta.Text = ""

                ' Me.txtgmd_timeofstuffing.Text = ""

                'Me.txtgmd_placeofstuffing.Text = ""

                'Me.txtgmd_portofloading.Text = ""


                'Me.txtgmd_portofdischarge.Text = ""

                '' Me.txtgmd_placeofdelivery.Text = ""
                'Me.txtgmd_noofcontainerorpackage.Text = ""
                'Me.txtgmd_description.Text = ""

                'Me.TXTgmd_gw.Text = ""
                'Me.TXTgmd_cbm.Text = ""

                '  Me.txtgmd_specialrequest.Text = ""

                ' Me.txtgmd_servicerequired.Text = ""


                'Me.txtgmd_pickupat.Text = ""
                'Me.txtgmd_othertermsconditions.Text = ""
                'Me.txtgmd_paymentterm.Text = ""

                'Me.txtgmd_freightrate.Text = ""
                'Me.txtgmd_dropoffat.Text = ""
                'Me.txtgmd_hblno.Text = ""
                'Me.txtgmd_noofbl.Text = ""

                'Me.txtgmd_contact.Text = ""

                ' Me.txtgmd_closingtime.Text = ""
                'Me.txtgmd_status.Text = ""
                'Me.txtgmd_salecode.Text = ""
                Me.cboBookingOffice.Text = ""
                Me.txtso.Text = ""
                Me.txttinhtrang.Text = ""
                Me.cbosoxe.Text = ""
                Me.cboCompany.Text = ""
                Me.txtthoigian.Text = ""
                Me.txtlitdau.Text = ""
                Me.txttinhtrang.Text = ""
                Me.txttenphi.Text = ""
                Me.txtsoluong.Text = "0"
                Me.txtdongia.Text = "0"

                Me.txtthue.Text = "0"
                Me.txtthanhtien.Text = "0"
                Me.txtchietkhau.Text = "0"


            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Try
                gNameForm = Me.Name
                VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
                If frmFilter.strQuery <> "Cancel" Then
                    mFilter = frmFilter.strQuery
                    QueryBookingAgent("  " & mFilter)
                End If
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub QueryVoy()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "DMDAUKEOID"
        value = "maxe"
        Me.cbosoxe.Items.Clear()
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select DMDAUKEOID, maxe  "
        strSQL = strSQL & " From dmdaukeo order by maxe " '
        loadDataToObject(Me.cbosoxe, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub txtgmd_vessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub smnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuPrint.Click
        Try

            Dim chk As Integer
            chk = Me.dgdContianerOutboundNotify.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdContianerOutboundNotify.RowCount > 0 Then
                Dim index As Integer = Me.dgdContianerOutboundNotify.CurrentRow.Index
                gPrintBookingAgentID = Me.dgdContianerOutboundNotify.Item("BookingAgentID", index).Value.ToString





                'VB6.ShowForm(frmPrintBookingAgent, VB6.FormShowConstants.Modal, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmPrintBookingAgent
                    form.MdiParent = frmMain
                    form.Show()
                End If

            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub cboCompany_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompany.Leave
        Try

            'Dim id, value, strSQL As String
            'Me.cboRepresentative.Items.Clear()
            'id = "PIC"
            'value = "PIC"
            'strSQL = "Select Customer_ID,PIC From PIC where Customer_ID='" & FindValueID(Me.cboCompany, Me.cboCompany.Text) & "' and Continued=1 Order By PIC"
            'loadDataToObject(Me.cboRepresentative, strSQL, id, value)


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompany.SelectedIndexChanged

    End Sub

    Private Sub tbcCongTy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcCongTy.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim TempHouseBill As TextBox
            TempHouseBill = Nothing
            'For i As Integer = 0 To arrHouseBill.Length - 2
            '    If arrHouseBill(i).Focused = True Then
            '        TempHouseBill = arrHouseBill(i)
            '        Exit For
            '    End If
            'Next
            'If TempHouseBill Is Nothing Then
            '    MsgBox("You Have to Focus a House Bill Text box")
            '    Return
            'End If
            Dim thanghientai, thangsosanh As String
            thanghientai = CDate(Getdate()).Date.Month
            Try
                Select Case UCase(thanghientai)   ' 
                    Case "1"   '
                        thangsosanh = "01"
                    Case "2"   '
                        thangsosanh = "02"
                    Case "3" 'Or "MAR"   '
                        thangsosanh = "03"
                    Case "4" 'Or "APR"   '
                        thangsosanh = "04"
                    Case "5" 'Or "MAY"   '
                        thangsosanh = "05"
                    Case "6" 'Or "JUN"   '
                        thangsosanh = "06"
                    Case "7" 'Or "JUL"   '
                        thangsosanh = "07"
                    Case "8" ' Or "AUG"   '
                        thangsosanh = "08"
                    Case "9" 'Or "SEP"   '
                        thangsosanh = "09"

                    Case "10" ' Or "OCT"   '
                        thangsosanh = "10"

                    Case "11" ' Or "NOV"   '
                        thangsosanh = "11"
                    Case "12" 'Or "DEC"   '
                        thangsosanh = "12"



                End Select
            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
            '-----
            Dim nam As String
            nam = CDate(Getdate()).Year.ToString
            '-------------
            Dim so As String
            Dim sql As String
            Dim ds As New DataSet
            sql = "select count(*) as so from bookingagent "
            ds = ReadDataSet(sql)
            Try
                so = (CInt(ds.Tables(0).Rows(0).Item("so").ToString) + 1).ToString
            Catch ex As Exception
                so = "0"
            End Try

            Dim sokhong As String
            If CInt(so) < 10 Then
                sokhong = "000"
            ElseIf CInt(so) > 9 And CInt(so) < 100 Then
                sokhong = "00"
            ElseIf CInt(so) > 99 And CInt(so) < 1000 Then
                sokhong = "0"
            ElseIf CInt(so) > 999 And CInt(so) < 10000 Then
                sokhong = "0"

            End If

            'Me.txtgmd_bookingno.Text = Me.cbobranch.Text + Me.cbotat.Text + nam.ToString.Replace("20", "") + thangsosanh + sokhong + so.ToString 'Me.cbobranch.Text + Me.cbotat.Text + nam.ToString + thangsosanh.ToString + sokhong + so.ToString
            'Me.txtgmd_bookingnoCarrier.Text = Me.cbobranch.Text + Me.cbotat.Text + nam.ToString.Replace("20", "") + thangsosanh + sokhong + so.ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim id, value, strQuery As String
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,taxcode + '-' + company as company from customer where CONTINUED=1 and company like '%" & Me.TextBox1.Text.Trim & "%' Order by company "
            Me.cboCompany.Items.Clear()
            loadDataToObject(Me.cboCompany, strQuery, id, value)
            '-SALES
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbonhanVienChungTu_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbotrangthai_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

   
    

   

  

    

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Try
            'If mStatus = "Normal" Or mStatus = "Edit" Then
            '    Me.GroupBox1.BringToFront()
            '    Me.GroupBox1.Visible = True
            '    Me.txtRefInbound.Text = Me.txtgmd_bookingno.Text
            '    Me.txtrefoutbound.Text = Me.txtgmd_bookingno.Text
            '    Me.txtrefLogistics.Text = Me.txtgmd_bookingno.Text
            'Else
            '    DisplayMessage(True, "Bạn cần lưu trước khi tạo Ref.!")
            '    Exit Sub
            'End If



        Catch ex As Exception

        End Try
    End Sub

  

   

    Private Sub cmdShowPort_Click(sender As Object, e As EventArgs)
        Try
            'Me.GPort.BringToFront()
            'PortPOLPOD = "POL"
            'Me.GPort.Visible = True
            'Me.GPort.Text = "Select POL"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdshowportPOD_Click(sender As Object, e As EventArgs)
        Try
            'Me.GPort.BringToFront()
            'PortPOLPOD = "POD"
            'Me.GPort.Visible = True
            'Me.GPort.Text = "Select POD"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortAdd_Click(sender As Object, e As EventArgs)
        Try
            'Dim strQuery As String
            'Dim rs As New ADODB.Recordset
            'strQuery = "SELECT * "
            'strQuery = strQuery & "FROM Port "
            'strQuery = strQuery & "WHERE port_code = '" & Me.txtGPortCode.Text.Trim & "' " ' "
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'With rs
            '    If rs.EOF Then
            '        .AddNew()
            '        .Fields("Port_Id").Value = NewId()

            '    End If
            '    .Fields("Port_Code").Value = Me.txtGPortCode.Text
            '    .Fields("Port").Value = UCase(Trim(Me.txtgportName.Text))
            '    .Fields("show").Value = True

            '    '.Fields("Continued").Value = 1
            '    .Update()
            'End With
            'rs.Close()
            'Me.cmdPortSearch_Click(sender, e)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdPortSearch_Click(sender As Object, e As EventArgs)
        Try
            Try
                'Dim sql As String
                'Dim ds As New DataSet
                'If Me.txtGPortCode.Text <> "" And Me.txtgportName.Text = "" Then
                '    sql = "select port_id,port_code,port from port where port_code like '%" & Me.txtGPortCode.Text & "%'  order by port_code    "
                'ElseIf Me.txtGPortCode.Text = "" And Me.txtgportName.Text <> "" Then
                '    'or port like '%" & txtgportName.Text & "%'
                '    sql = "select port_id,port_code,port from port where port like '%" & Me.txtgportName.Text & "%'  order by port_code   "
                'ElseIf Me.txtGPortCode.Text = "" And Me.txtgportName.Text = "" Then
                '    sql = "select port_id,port_code,port from port order by port_code  "
                'ElseIf Me.txtGPortCode.Text <> "" And Me.txtgportName.Text <> "" Then
                '    sql = "select port_id,port_code,port from port where port_code like '%" & Me.txtGPortCode.Text & "%'  and port like '%" & Me.txtgportName.Text & "%' order by port_code    "
                'End If
                'ds = ReadDataSet(sql)
                'Me.DataGridView4.DataSource = ds.Tables(0)
                'InsertAutoNumberToGrid(Me.DataGridView4)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPortExit_Click(sender As Object, e As EventArgs)
        Try
            ' Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdselectPort_Click(sender As Object, e As EventArgs)
        Try
            'If Me.DataGridView4.RowCount = 0 Then
            '    DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            '    Return
            'End If
            'Dim index As Integer = Me.DataGridView4.CurrentRow.Index

            ''Try
            ''    Me.txtNoDebit.Text = "DN-" + Me.txtRef.Text
            ''    Me.txtNoCredit.Text = "CN-" + Me.txtRef.Text
            ''Catch ex As Exception

            ''End Try

            'If index >= 0 Then
            '    If PortPOLPOD = "POL" Then
            '        Me.cbopolcode.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
            '        Me.txtgmd_portofloading.Text = Me.DataGridView4.Item("port", index).Value.ToString
            '    ElseIf PortPOLPOD = "POD" Then
            '        Me.cbopodcode.Text = Me.DataGridView4.Item("port_code", index).Value.ToString
            '        Me.txtgmd_portofdischarge.Text = Me.DataGridView4.Item("port", index).Value.ToString

            '    End If


            'End If
            'Me.GPort.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopolcode_Leave(sender As Object, e As EventArgs)
        Try
            'Dim sql As String
            'Dim ds As New DataSet
            'sql = "select port from port where port_code='" & Me.cbopolcode.Text & "'"
            'ds = ReadDataSet(sql)
            'If ds.Tables(0).Rows.Count > 0 Then
            '    Me.txtgmd_portofloading.Text = ds.Tables(0).Rows(0).Item("port").ToString
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopolcode_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbopodcode_Leave(sender As Object, e As EventArgs)
        Try
            'Dim sql As String
            'Dim ds As New DataSet
            'sql = "select port from port where port_code='" & Me.cbopodcode.Text & "'"
            'ds = ReadDataSet(sql)
            'If ds.Tables(0).Rows.Count > 0 Then
            '    Me.txtgmd_portofdischarge.Text = ds.Tables(0).Rows(0).Item("port").ToString
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbopodcode_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GPort_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_MouseDown(sender As Object, e As MouseEventArgs)
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Public Sub tongthanhtien()
        Try
            Me.txtthanhtien.Text = CDbl(Me.txtsoluong.Text) * CDbl(Me.txtdongia.Text) + CDbl(Me.txtthue.Text) - CDbl(Me.txtchietkhau.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtsoluong_TextChanged(sender As Object, e As EventArgs) Handles txtsoluong.TextChanged
        Try
            tongthanhtien()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdongia_TextChanged(sender As Object, e As EventArgs) Handles txtdongia.TextChanged
        Try
            tongthanhtien()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtthue_TextChanged(sender As Object, e As EventArgs) Handles txtthue.TextChanged
        Try
            tongthanhtien()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtchietkhau_TextChanged(sender As Object, e As EventArgs) Handles txtchietkhau.TextChanged
        Try
            tongthanhtien()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtthanhtien_TextChanged(sender As Object, e As EventArgs) Handles txtthanhtien.TextChanged

    End Sub
End Class