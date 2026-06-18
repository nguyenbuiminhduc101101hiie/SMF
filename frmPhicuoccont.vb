Public Class frmPhicuoccont
    Dim TongCong As Double = 0
    Public oTable As DataTable
    Dim mPhicuoccontid, mStatus As String

    Sub GetData(ByVal SQL As String, ByRef dt As DataTable)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Function GetSeriNo() As String
        Try
            Dim strSQL As String
            strSQL = "Select SeriesNo From PhieuThuTien Where PhieuThu_ID='" & DefaultValue & "'"
            Dim dtSer As New DataTable
            GetData(strSQL, dtSer)
            Dim Temp As String = ""
            Dim Seri As String
            Seri = CDbl(dtSer.Rows(0).Item(0)) + 1
            For i As Integer = Seri.ToString.Length To 6
                Temp &= "0"
            Next
            Temp &= Seri
            Return Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Sub frmPhicuoccont_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strSQL As String
            'If Me.dgdNoiDungThu.RowCount > 0 Then
            '    Me.dgdNoiDungThu.Rows.Clear()
            'End If
            '--------- lay thong tin phi 

            'lấy thông tin bill
            strSQL = " Select BLIB_NO,Consignee_1 + ' ' + Consignee_2 as Consignee,Vessel + ' - ' + voyage + ' - ' + Replace(Convert(nvarchar,ETA),'12:00AM','') as vessel "
            strSQL &= " From (BillOfLadingIB Left JOIN Consignee On Consignee.CONSIGNEE_ID=BillOfLadingIB.CONSIGNEE_ID)"
            strSQL &= " Where BillOfLadingIB.BLIB_ID='" & gBillInboundID & "' And BillOfLadingIB.Continued=1"
            Dim dt As New DataTable
            GetData(strSQL, dt)
            If dt.Rows.Count > 0 Then
                Me.txtBLNo.Text = dt.Rows(0).Item("BLIB_NO").ToString
                Me.txtTenKhachHang.Text = dt.Rows(0).Item("Consignee").ToString
                Me.txtDiaChi.Text = dt.Rows(0).Item("Vessel").ToString
            End If
            'lấy thông tin cargo
            'strSQL = "select distinct Container_Type as Data "
            'strSQL &= " From CargoIB "
            'strSQL &= " Where CargoIB.BLIB_ID='" & gBillInboundID & "' And CargoIB.Continued=1"
            'GetData(strSQL, dt)
            'Me.cboLoaiContainer.Items.Clear()
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    If dt.Rows(i).Item("data").ToString Like "*20*" Then
            '        If Me.cboLoaiContainer.FindStringExact("20") = -1 Then
            '            Me.cboLoaiContainer.Items.Add("20")
            '        End If
            '    Else
            '        If Me.cboLoaiContainer.FindStringExact("40") = -1 Then
            '            Me.cboLoaiContainer.Items.Add("40")
            '        End If
            '    End If
            'Next
            Me.cmdThem.Enabled = False
            QUERYPHICUOCCONT(Me.txtBLNo.Text.Trim)

            strSQL = " Select Container_no,Container_Type "
            strSQL &= " From (CargoIB INNER JOIN Container On Container.CTN_ID=CargoIB.CTN_ID)"
            strSQL &= " where CargoIB.Continued=1 And CargoIB.BLIB_ID='" & gBillInboundID & "'"
            Dim table As New DataTable
            table = ReadTable(strSQL)
            Me.cboContainer.DisplayMember = "Container_No"
            Me.cboContainer.ValueMember = "Container_Type"
            Me.cboContainer.DataSource = table
            If Me.cboContainer.Items.Count > 0 Then
                Me.cboContainer.SelectedItem = 0
            End If
            SetDefaultGrid(Me.dgdNoiDungThu, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'If dt.Rows.Count > 0 Then
            'Me.cboLoaiContainer.DisplayMember = "Data"
            'Me.cboLoaiContainer.ValueMember = "Data"
            'Me.cboLoaiContainer.DataSource = dt
            'cboLoaiContainer_SelectedIndexChanged(sender, e)
            'Me.txtSoLuong.Text = frmListBaseIB.dgdBillOfLading.Item("QuantityOfContainer", frmListBaseIB.dgdBillOfLading.CurrentRow.Index).Value.ToString
            Me.cboContainer.Text = ""
            Me.cboLoaiContainer.Text = ""
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboLoaiContainer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboContainer.Leave
        'If Me.cboLoaiContainer.Text Like "*20*" Then
        '    Me.txtSoTien.Text = "300000"
        'Else
        '    Me.txtSoTien.Text = "600000"
        'End If
        tinhtongcong()
    End Sub

    Private Sub cboContainer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContainer.SelectedIndexChanged
        Try
            'Dim strSQL As String
            'strSQL = "select Count(Container_type) as Num "
            'strSQL &= " From CargoIB "
            'strSQL &= " Where CargoIB.Container_Type like'%" & Me.cboLoaiContainer.Text & "%' And CargoIB.BLIB_ID='" & gBillInboundID & "' And CargoIb.Continued=1"
            'Dim dt As New DataTable
            'GetData(strSQL, dt)
            'If dt.Rows.Count > 0 Then
            '    Me.txtSoLuong.Text = dt.Rows(0).Item("Num").ToString
            'End If
            Me.cboLoaiContainer.Text = Me.cboContainer.SelectedValue.ToString
            'If Me.cboLoaiContainer.Text Like "*20*" Then
            '    Me.txtSoTien.Text = "300000"
            'Else
            '    Me.txtSoTien.Text = "600000"
            'End If
            tinhtongcong()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub txtSoLuong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoLuong.TextChanged, txtSoTien.TextChanged
        Try
            Me.txtTongTien.Text = FormatString(CDbl(IIf(Me.txtSoLuong.Text <> "", Me.txtSoLuong.Text, 0)) * CDbl(IIf(Me.txtSoTien.Text <> "", Me.txtSoTien.Text, 0)))
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Public Sub QUERYPHICUOCCONT(ByVal billID As String)
        Try
            If billID = "" Then
                Return
            End If
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim ds As New DataSet
            'Dim billno As String = ""
            '----------------
            ''Dim strQuery As String
            'Dim rs As New ADODB.Recordset
            'strQuery = " Select * from BillOfLadingib where BLIB_ID='" & billId & "'"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'With rs
            '    If Not .EOF Then
            '        billno = .Fields("blib_no").Value
            '    End If
            'End With
            'rs.Close()
            '-----------------
            strQuery = " select * from phicuoccont where BLIB_NO='" & Me.txtBLNo.Text.Trim & "' AND CONTINUED=1"
            Con.Open()
            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ' Con.Open()
            Adapter.Fill(ds, "Phicuoccont")
            oTable = ds.Tables(0)
            'hien thi ra grid 
            Me.dgdNoiDungThu.DataSource = ds.Tables("Phicuoccont")

            Me.Cursor = System.Windows.Forms.Cursors.Default
            If Me.dgdNoiDungThu.RowCount() = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        Try
            '----------

            '----------- 
            Dim strQuery, strID As String
            strID = ""
            Dim index As Integer
            If Me.dgdNoiDungThu.RowCount > 0 Then
                index = Me.dgdNoiDungThu.CurrentRow.Index
                strID = Me.dgdNoiDungThu.Item("phicuoccontid", index).Value.ToString
            End If
            Dim rs As New ADODB.Recordset
            TongCong = 0
            If mStatus = "Normal" Then
                Return
            End If
            If mStatus = "Edit" Then
                strQuery = "select * from phicuoccont where phicuoccontid='" & strID & "' and continued=1"
            Else
                strQuery = "select * from phicuoccont where continued=1"
            End If
            If mStatus = "Add" Then
                For i As Integer = 0 To Me.dgdNoiDungThu.Rows.Count - 1
                    If Me.dgdNoiDungThu.Item("Container_No", i).Value.ToString.Trim = Me.cboContainer.Text.Trim Then
                        MsgBox("Container này đã có trong cơ sở dữ liệu")
                        Return
                    End If
                Next
            End If
            If mStatus = "Edit" Then
                CopyValues("phicuoccont", "phicuoccontid", strID)
            End If
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If mStatus = "Add" Then
                    .AddNew()
                    .Fields("phicuoccontid").Value = NewId()
                End If
                strID = .Fields("phicuoccontid").Value
                .Fields("BLIB_NO").Value = gBillNoInBound
                .Fields("tenkhachhang").Value = Me.txtTenKhachHang.Text
                .Fields("diachi").Value = Me.txtDiaChi.Text
                .Fields("hinhthucthanhtoan").Value = Me.txtHinhThucThanhToan.Text
                .Fields("NoiDung").Value = Me.txtNoiDungthu.Text
                .Fields("Tennguoitra").Value = Me.TXTTENntc.Text
                .Fields("cmndnguoitra").Value = Me.txtcmndntc.Text
                .Fields("Tennguoilay").Value = Me.txttennlc.Text
                .Fields("cmndnguoilay").Value = Me.txtcmndnlc.Text
                .Fields("dalayCUOC").Value = IIf(Me.chkdalay.Checked, "Đã lấy cược", "Chưa lấy lại cược")
                .Fields("Container_No").Value = Me.cboContainer.Text
                .Fields("loaicont").Value = Me.cboLoaiContainer.Text
                .Fields("soluong").Value = Me.txtSoLuong.Text

                .Fields("donvitinh").Value = Me.txtDonVitinh.Text

                .Fields("sotien").Value = Me.txtSoTien.Text
                .Fields("thanhtien").Value = Me.txtTongTien.Text
                ' .Fields("tongcong").Value = Me.txttongcong.Text

                .Update()
            End With
            rs.Close()
            mStatus = "Normal"
            QUERYPHICUOCCONT(Me.txtBLNo.Text.Trim)
            'Dim TempSeri As Double
            'frmRPTphieuThuTien.data = False
            'frmRPTphieuThuTien.ShowDialog(Me)
            Me.cmdThem.Enabled = False
            Me.cmdAll.Enabled = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        mStatus = "Normal"
        Me.Close()

    End Sub

    'Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.dgdNoiDungThu.RowCount = 0 Then
    '            MsgBox("nhấn Nút thêm để thêm dòng vào lứơi rồi mới Print đựơc")
    '            Return
    '        End If
    '        Dim strQuery As String
    '        Dim rs As New ADODB.Recordset
    '        strQuery = " Select * from PhieuThuTien where BLIB_NO='" & gBillNoInBound & "'"
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        With rs
    '            If .EOF Then
    '                .AddNew()
    '                .Fields("Phieuthu_ID").Value = NewId()
    '                .Fields("BLIB_NO").Value = gBillNoInBound
    '                .Fields("SeriesNo").Value = Me.txtSeriesNo.Text
    '            End If
    '            .Fields("TongCong").Value = Me.txtTongCong.Text
    '            .Update()
    '        End With
    '        rs.Close()
    '        frmRPTphieuThuTien.data = True
    '        frmRPTphieuThuTien.ShowDialog(Me)
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    Private Sub tinhtongcong()
        Try
            TongCong = Me.txtTongTien.Text
            If Me.dgdNoiDungThu.RowCount = 0 Then
                Return
            End If
            For j As Integer = 0 To Me.dgdNoiDungThu.RowCount - 1
                TongCong += CDbl(Me.dgdNoiDungThu.Item("ThanhTien", j).Value.ToString)
                Me.dgdNoiDungThu.Item("Stt", j).Value = j + 1
            Next


            'Me.txtTongCong.Text = TongCong

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed

        Me.txtBLNo.Text = Me.dgdNoiDungThu.Item("Blib_no", index).Value.ToString
        Me.txtTenKhachHang.Text = Me.dgdNoiDungThu.Item("tenkhachhang", index).Value.ToString
        Me.txtDiaChi.Text = Me.dgdNoiDungThu.Item("diachi", index).Value.ToString
        Me.txtHinhThucThanhToan.Text = Me.dgdNoiDungThu.Item("hinhthucthanhtoan", index).Value.ToString
        Me.txtNoiDungthu.Text = Me.dgdNoiDungThu.Item("noidungthu", index).Value.ToString
        Me.TXTTENntc.Text = Me.dgdNoiDungThu.Item("tennguoitra", index).Value.ToString
        Me.txtcmndntc.Text = Me.dgdNoiDungThu.Item("cmndnguoitra", index).Value.ToString

        Me.txttennlc.Text = Me.dgdNoiDungThu.Item("tennguoilay", index).Value.ToString
        Me.txtcmndnlc.Text = Me.dgdNoiDungThu.Item("cmndnguoilay", index).Value.ToString

        Me.cboLoaiContainer.Text = Me.dgdNoiDungThu.Item("loaicont", index).Value.ToString
        Me.txtSoLuong.Text = Me.dgdNoiDungThu.Item("soluong", index).Value.ToString

        Me.txtDonVitinh.Text = Me.dgdNoiDungThu.Item("donvitinh", index).Value.ToString

        Me.txtSoTien.Text = Me.dgdNoiDungThu.Item("sotien", index).Value.ToString
        Me.txtTongTien.Text = Me.dgdNoiDungThu.Item("thanhtien", index).Value.ToString
        'Me.txttongcong.Text = Me.dgdNoiDungThu.Item("tong", index).Value.ToString

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub cmdOkReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkReport.Click
        Try
            If Me.dgdNoiDungThu.RowCount = 0 Then
                Return
            End If

            frmRPTphicuoccont.data = False
            frmRPTphicuoccont.ShowDialog(Me)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub dgdNoiDungThu_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdNoiDungThu.CellContentClick

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim index As Integer
            If Me.dgdNoiDungThu.RowCount > 0 Then
                index = Me.dgdNoiDungThu.CurrentRow.Index
            Else
                Exit Sub
            End If
            mStatus = "Edit"
            Me.cmdThem.Enabled = True
            mPhicuoccontid = Me.dgdNoiDungThu.Item("phicuoccontid", index).Value.ToString

            Me.txtBLNo.Text = Me.dgdNoiDungThu.Item("Blib_no", index).Value.ToString
            Me.txtTenKhachHang.Text = Me.dgdNoiDungThu.Item("tenkhachhang", index).Value.ToString
            Me.txtDiaChi.Text = Me.dgdNoiDungThu.Item("diachi", index).Value.ToString
            Me.txtHinhThucThanhToan.Text = Me.dgdNoiDungThu.Item("hinhthucthanhtoan", index).Value.ToString
            Me.txtNoiDungthu.Text = Me.dgdNoiDungThu.Item("noidung", index).Value.ToString
            Me.TXTTENntc.Text = Me.dgdNoiDungThu.Item("tennguoitra", index).Value.ToString
            Me.txtcmndntc.Text = Me.dgdNoiDungThu.Item("cmndnguoitra", index).Value.ToString

            Me.txttennlc.Text = Me.dgdNoiDungThu.Item("tennguoilay", index).Value.ToString
            Me.txtcmndnlc.Text = Me.dgdNoiDungThu.Item("cmndnguoilay", index).Value.ToString
            Me.chkdalay.Checked = IIf(Me.dgdNoiDungThu.Item("DALAYCUOC", index).Value = "Đã lấy cược", True, False)
            Me.cboContainer.Text = Me.dgdNoiDungThu.Item("Container_no", index).Value.ToString
            Me.cboLoaiContainer.Text = Me.dgdNoiDungThu.Item("loaicont", index).Value.ToString
            Me.txtSoLuong.Text = Me.dgdNoiDungThu.Item("soluong", index).Value.ToString

            Me.txtDonVitinh.Text = Me.dgdNoiDungThu.Item("donvitinh", index).Value.ToString

            Me.txtSoTien.Text = Me.dgdNoiDungThu.Item("sotien", index).Value.ToString
            Me.txtTongTien.Text = Me.dgdNoiDungThu.Item("thanhtien", index).Value.ToString
            '  Me.txtTongCong.Text = Me.dgdNoiDungThu.Item("tong", index).Value.ToString
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        Dim index As Integer = Me.dgdNoiDungThu.CurrentRow.Index
        If index < 0 Then
            Return
        End If
        If Not IsNothing(Me.dgdNoiDungThu.Item("Approve", index).Value) Then
            If Me.dgdNoiDungThu.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdNoiDungThu.Item("Editable", index).Value) Then
            If Not Me.dgdNoiDungThu.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        strMesg = "Xóa loại Container : " & Me.dgdNoiDungThu.Item("Container_NO", index).Value.ToString & " hay không ?"
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            strQueryCommodityList = "Select * from phicuoccont where" + " phicuoccontid= '" & Me.dgdNoiDungThu.Item("phicuoccontid", index).Value.ToString & "'"
            rs.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("continued").Value = 0
            rs.Update()
            rs.Close()
        End If
        Me.QUERYPHICUOCCONT(Me.txtBLNo.Text.Trim)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click, mnuNew.Click
        mStatus = "Add"
        Me.cmdThem.Enabled = True
        Me.cmdAll.Enabled = True
        cboContainer_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboLoaiContainer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiContainer.SelectedIndexChanged

    End Sub

    Private Sub cboLoaiContainer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiContainer.TextChanged
        Try
            Dim ContainerLanh() As String = {"RF", "RH"}
            Dim Cold As Boolean = False
            Dim rs As New ADODB.Recordset
            Dim strQuery, tien As String
            ' lay so lieu tu Option
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [option] "
            strQuery = strQuery & "WHERE frmName = 'frmPhicuoccont1' and OptionCode='" & Me.cboLoaiContainer.Text.Trim & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If Not rs.EOF Then
                    tien = .Fields("optionvalue").Value
                End If

            End With
            rs.Close()
            Me.txtSoTien.Text = tien
            '---------------
            'For i As Integer = 0 To ContainerLanh.Length - 1
            '    If Me.cboLoaiContainer.Text.Trim Like "*" & ContainerLanh(i) & "*" Then
            '        Cold = True
            '        Exit For
            '    End If
            'Next
            'If Cold = True Then
            '    If Me.cboLoaiContainer.Text Like "*20*" Then
            '        Me.txtSoTien.Text = "2000000"
            '    Else
            '        Me.txtSoTien.Text = "4000000"
            '    End If
            'Else
            '    If Me.cboLoaiContainer.Text Like "*20*" Then
            '        Me.txtSoTien.Text = "300000"
            '    Else
            '        Me.txtSoTien.Text = "600000"
            '    End If
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAll.Click
        Try
            '----------
            Dim j As Integer = 0
            Dim i As Integer = 0
            Dim sotien As Double
            Dim rsSoCont, rsTien As New ADODB.Recordset
            '-----------  
            Dim rs As New ADODB.Recordset
            Dim so, loaicont As String
            Dim strQuery, strSQL, strID As String
            strID = ""
            Dim index As Integer
           
            '-----------------

            strSQL = " Select Container_no,Container_Type "
            strSQL &= " From (CargoIB INNER JOIN Container On Container.CTN_ID=CargoIB.CTN_ID)"
            strSQL &= " where CargoIB.Continued=1 And CargoIB.BLIB_ID='" & gBillInboundID & "'"
            rsSoCont.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            For j = 0 To Me.cboContainer.Items.Count - 1


                If Not rsSoCont.EOF Then
                    so = rsSoCont.Fields("Container_no").Value.ToString
                    rsSoCont.MoveNext()
                End If



                If Me.dgdNoiDungThu.RowCount > 0 Then
                    index = Me.dgdNoiDungThu.CurrentRow.Index
                    strID = Me.dgdNoiDungThu.Item("phicuoccontid", index).Value.ToString
                End If


                TongCong = 0
                If mStatus = "Normal" Then
                    Return
                End If
                If mStatus = "Edit" Then
                    strQuery = "select * from phicuoccont where phicuoccontid='" & strID & "' and continued=1"
                Else
                    strQuery = "select * from phicuoccont where continued=1"
                End If
                For i = 0 To Me.dgdNoiDungThu.Rows.Count - 1
                    If UCase(Me.dgdNoiDungThu.Item("Container_No", i).Value.ToString.Trim) = UCase(so) Then
                        MsgBox("Container này đã có trong cơ sở dữ liệu")
                        Return
                    End If
                Next
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If mStatus = "Add" Then
                        .AddNew()
                        .Fields("phicuoccontid").Value = NewId()
                    End If
                    strID = .Fields("phicuoccontid").Value
                    .Fields("BLIB_NO").Value = gBillNoInBound
                    .Fields("tenkhachhang").Value = Me.txtTenKhachHang.Text
                    .Fields("diachi").Value = Me.txtDiaChi.Text
                    .Fields("hinhthucthanhtoan").Value = Me.txtHinhThucThanhToan.Text
                    .Fields("NoiDung").Value = Me.txtNoiDungthu.Text
                    .Fields("Tennguoitra").Value = Me.TXTTENntc.Text
                    .Fields("cmndnguoitra").Value = Me.txtcmndntc.Text
                    .Fields("Tennguoilay").Value = Me.txttennlc.Text
                    .Fields("cmndnguoilay").Value = Me.txtcmndnlc.Text
                    .Fields("dalayCUOC").Value = IIf(Me.chkdalay.Checked, "Đã lấy cược", "Chưa lấy lại cược")

                    loaicont = QueryLoaiCont(so)

                    .Fields("Container_No").Value = so
                    .Fields("loaicont").Value = loaicont

                    .Fields("soluong").Value = 1
                    .Fields("donvitinh").Value = Me.txtDonVitinh.Text
                    'If loaicont Like "*20*" Then
                    '    If loaicont Like "*RH*" Or loaicont Like "*RF*" Then
                    '        sotien = 1000000
                    '    Else
                    '        sotien = 300000
                    '    End If
                    'Else
                    '    If loaicont Like "*RH*" Or loaicont Like "*RF*" Then
                    '        sotien = 2000000
                    '    Else
                    '        sotien = 600000
                    '    End If
                    'End If
                    ' lay so lieu tu Option
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM [option] "
                    strQuery = strQuery & "WHERE frmName = 'frmPhicuoccont1' and OptionCode='" & loaicont & "' And Continued=1"
                    rsTien.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rsTien
                        If Not rsTien.EOF Then
                            sotien = .Fields("optionvalue").Value
                        End If

                    End With
                    rsTien.Close()
                    .Fields("sotien").Value = sotien
                    .Fields("thanhtien").Value = sotien * 1
                    ' .Fields("tongcong").Value = Me.txttongcong.Text

                    .Update()
                End With
                rs.Close()
                QUERYPHICUOCCONT(Me.txtBLNo.Text.Trim)
            Next

            mStatus = "Normal"
            rsSoCont.Close()
            Me.cmdThem.Enabled = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Function QueryLoaiCont(ByVal SoCont As String) As String
        Dim rsLoaicont As New ADODB.Recordset
        rsLoaicont.Open("select * from Container where CONTAINER_NO ='" & SoCont & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Return rsLoaicont.Fields("CTN_SIZE_TYPE").Value
    End Function

    Private Sub cmdDalayAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDalayAll.Click
        Try


            Dim strQuery, dl As String
            Dim rs As New ADODB.Recordset
            If Me.dgdNoiDungThu.RowCount = 0 Or Me.txtBLNo.Text = "" Then
                Return
            End If


            'strQuery = "update phicuoccont set tennguoilay='" & Me.txttennlc.Text.Trim & "' ,cmndnguoilay='" & Me.txtcmndnlc.Text.Trim & "', dalaycuoc='" & dl & "' where BLIB_No='" & Me.txtBLNo.Text.Trim & "' and continued=1"
            strQuery = "select * from phicuoccont where BLIB_No='" & Me.txtBLNo.Text.Trim & "' and continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            While Not rs.EOF
                With rs
                    .Fields("tennguoilay").Value = Me.txttennlc.Text.Trim
                    .Fields("cmndnguoilay").Value = Me.txtcmndnlc.Text.Trim
                    .Fields("dalaycuoc").Value = "Đã lấy cược"
                    .Update()

                End With
                rs.MoveNext()
            End While
            rs.Close()
            mStatus = "Normal"
            QUERYPHICUOCCONT(Me.txtBLNo.Text.Trim)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class