Public Class frmPhieuThuTien
    Dim TongCong As Double = 0
    Dim oTablePhieuThuTien As New DataTable
    Dim mStatus As String
    Dim PhieuThuTien_ID As String

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
    Sub Refreshdata(ByVal Index As Integer)
        Try

            Me.txtNoiDungthu.Text = Me.dgdNoiDungThu.Item("NoiDung", Index).Value.ToString
            Me.txtSeriesNo.Text = Me.dgdNoiDungThu.Item("SeriesNo", Index).Value.ToString
            'Me.txtTongCong.Text = Me.dgdNoiDungThu.Item("Total", Index).Value.ToString
            Me.txtTenKhachHang.Text = Me.dgdNoiDungThu.Item("TenKhachHang", Index).Value.ToString
            Me.txtDiaChi.Text = Me.dgdNoiDungThu.Item("DiaChi", Index).Value.ToString
            Me.txtMaSoThue.Text = Me.dgdNoiDungThu.Item("MaSoThue", Index).Value.ToString

            Me.txtHinhThucThanhToan.Text = Me.dgdNoiDungThu.Item("HinhThucThanhToan", Index).Value.ToString
            Me.cboLoaiContainer.Text = Me.dgdNoiDungThu.Item("LoaiContainer", Index).Value.ToString
            Me.txtSoLuong.Text = Me.dgdNoiDungThu.Item("SoLuong", Index).Value.ToString

            Me.cbodonvitinh.Text = Me.dgdNoiDungThu.Item("DonViTinh", Index).Value.ToString
            Me.txtSoTien.Text = Me.dgdNoiDungThu.Item("DonGia", Index).Value.ToString
            Me.txtTongTien.Text = Me.dgdNoiDungThu.Item("ThanhTien", Index).Value.ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryPhieuThuTien()
        Try
            Dim strQuery As String
            strQuery = "Select * from PhieuThuTien Where Continued=1 And BLIB_NO='" & gBillNoInBound & "'"
            oTablePhieuThuTien = ReadTable(strQuery)
            Me.dgdNoiDungThu.DataSource = oTablePhieuThuTien
            InsertAutoNumberToGrid(Me.dgdNoiDungThu)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function TongTien()
        Try
            TongCong = 0
            For j As Integer = 0 To Me.dgdNoiDungThu.RowCount - 1
                TongCong += CDbl(IIf(Me.dgdNoiDungThu.Item("ThanhTien", j).Value.ToString = "", "0", Me.dgdNoiDungThu.Item("ThanhTien", j).Value.ToString))
                'Me.dgdNoiDungThu.Item("Stt", j).Value = j + 1
            Next
            Me.txtTongCong.Text = TongCong
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Function
    Function GetSeriNo() As String
        Try
            Dim strSQL As String
            strSQL = "Select SeriesNo From PhieuThuTien Where PhieuThu_ID='" & DefaultValue & "'"
            Dim dtSer As New DataTable
            GetData(strSQL, dtSer)
            Dim Temp As String = ""
            Dim Seri As String
            Seri = CDbl(dtSer.Rows(0).Item(0).ToString) + 1
            For i As Integer = Seri.ToString.Length To 6
                Temp &= "0"
            Next
            Temp &= Seri
            Return Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Sub frmPhieuThuTien_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.cmdSave.Enabled = True Then
                If MsgBox("Do you Want to save", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cmdSave_Click(sender, e)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub frmPhieuThuTien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mStatus = "Normal"
            PhieuThuTien_ID = DefaultValue
            Dim strSQL As String
            'If Me.dgdNoiDungThu.RowCount > 0 Then
            '    Me.dgdNoiDungThu.Rows.Clear()
            'End If
            Me.txtDiaChi.Text = ""
            Me.txtSoLuong.Text = 0
            Me.txtMaSoThue.Text = ""
            Me.txtHinhThucThanhToan.Text = ""
            SetDefaultGrid(Me.dgdNoiDungThu, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            'lấy thông tin bill
            strSQL = " Select BLIB_NO,Consignee_1 + ' ' + Consignee_2 as Consignee "
            strSQL &= " From (BillOfLadingIB Left JOIN Consignee On Consignee.CONSIGNEE_ID=BillOfLadingIB.CONSIGNEE_ID)"
            strSQL &= " Where BillOfLadingIB.BLIB_ID='" & gBillInboundID & "' And BillOfLadingIB.Continued=1"
            Dim dt As New DataTable
            GetData(strSQL, dt)
            If dt.Rows.Count > 0 Then
                Me.txtBLNo.Text = dt.Rows(0).Item("BLIB_NO").ToString
                Me.txtTenKhachHang.Text = dt.Rows(0).Item("Consignee").ToString
            End If
            'lấy thông tin cargo
            strSQL = "select distinct Container_Type as Data "
            strSQL &= " From CargoIB "
            strSQL &= " Where CargoIB.BLIB_ID='" & gBillInboundID & "' And CargoIB.Continued=1"
            GetData(strSQL, dt)
            Me.cboLoaiContainer.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                If Me.cboLoaiContainer.FindStringExact(dt.Rows(i).Item("data").ToString) = -1 Then
                    Me.cboLoaiContainer.Items.Add(dt.Rows(i).Item("data").ToString)
                End If
                
            Next
            If Me.cboLoaiContainer.Items.Count > 0 Then
                Me.cboLoaiContainer.SelectedIndex = 0
            End If

            Me.txtSeriesNo.Text = ""
            QueryPhieuThuTien()
            'If dt.Rows.Count > 0 Then
            'Me.cboLoaiContainer.DisplayMember = "Data"
            'Me.cboLoaiContainer.ValueMember = "Data"
            'Me.cboLoaiContainer.DataSource = dt
            'cboLoaiContainer_SelectedIndexChanged(sender, e)
            'Me.txtSoLuong.Text = frmListBaseIB.dgdBillOfLading.Item("QuantityOfContainer", frmListBaseIB.dgdBillOfLading.CurrentRow.Index).Value.ToString

            'End If
            'tính ra tổng cộng tiền của 1 bill
            'For j As Integer = 0 To Me.dgdNoiDungThu.RowCount - 1
            '    TongCong += CDbl(Me.dgdNoiDungThu.Item("ThanhTien", j).Value.ToString)
            '    'Me.dgdNoiDungThu.Item("Stt", j).Value = j + 1
            'Next
            'Me.txtTongCong.Text = TongCong
            TongTien()
            'Me.cmdThem.Enabled = True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboLoaiContainer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoaiContainer.Leave
        Me.txtSoTien.Text = FormatNumber(Me.txtSoTien.Text, 0)
        Me.txtTongTien.Text = FormatNumber(Me.txtTongTien.Text, 0)
        Me.txtTongCong.Text = FormatNumber(Me.txtTongCong.Text, 0)
    End Sub

    Private Sub cboLoaiContainer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoaiContainer.SelectedIndexChanged
        Try
            Dim strSQL As String
            strSQL = "select Count(Container_type) as Num "
            strSQL &= " From CargoIB "
            strSQL &= " Where CargoIB.Container_Type like'%" & Me.cboLoaiContainer.Text & "%' And CargoIB.BLIB_ID='" & gBillInboundID & "' And CargoIb.Continued=1"
            Dim dt As New DataTable
            GetData(strSQL, dt)
            If dt.Rows.Count > 0 Then
                Me.txtSoLuong.Text = dt.Rows(0).Item("Num").ToString
            End If
            If Me.cboLoaiContainer.Text Like "*R*" Then
                If Me.cboLoaiContainer.Text Like "20*" Then
                    Me.txtSoTien.Text = "20"
                    Me.cbodonvitinh.Text = "USD"
                Else
                    Me.txtSoTien.Text = "30"
                    Me.cbodonvitinh.Text = "USD"
                End If
            Else
                If Me.cboLoaiContainer.Text Like "20*" Then
                    Me.txtSoTien.Text = "25000"
                Else
                    Me.txtSoTien.Text = "45000"
                End If
            End If

          
        Catch ex As Exception
            'DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtSoLuong_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoLuong.Leave
        Me.txtSoTien.Text = FormatNumber(Me.txtSoTien.Text, 0)
        Me.txtTongTien.Text = FormatNumber(Me.txtTongTien.Text, 0)
        Me.txtTongCong.Text = FormatNumber(Me.txtTongCong.Text, 0)
    End Sub


    Private Sub txtSoLuong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoLuong.TextChanged, txtSoTien.TextChanged
        Try

            Me.txtTongTien.Text = FormatString(CDbl(IIf(Me.txtSoLuong.Text <> "", Me.txtSoLuong.Text, 0)) * CDbl(IIf(Me.txtSoTien.Text <> "", Me.txtSoTien.Text, 0)))
        Catch ex As Exception
            'DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        Try

            If Me.txtSeriesNo.Text.Trim = "" Then
                MsgBox("please, input Series No.!")
                Return
            End If
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            strQuery = " Select * from PhieuThuTien " 'where PhieuThu_ID='" & PhieuThuTien_ID & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs

                .AddNew()
                .Fields("Phieuthu_ID").Value = NewId()
                .Fields("BLIB_NO").Value = gBillNoInBound

                .Fields("NoiDungThu").Value = Me.txtNoiDungthu.Text
                .Fields("SeriesNo").Value = Me.txtSeriesNo.Text
                .Fields("TongCong").Value = Me.txtTongCong.Text

                .Fields("TenKhachHang").Value = Me.txtTenKhachHang.Text
                .Fields("DiaChi").Value = Me.txtDiaChi.Text
                .Fields("MaSoThue").Value = Me.txtMaSoThue.Text

                .Fields("HinhThucThanhToan").Value = Me.txtHinhThucThanhToan.Text
                .Fields("LoaiContainer").Value = Me.cboLoaiContainer.Text
                .Fields("SoLuong").Value = Me.txtSoLuong.Text

                .Fields("DonViTinh").Value = Me.cbodonvitinh.Text
                .Fields("DonGia").Value = Me.txtSoTien.Text
                .Fields("ThanhTien").Value = Me.txtTongTien.Text
                .Update()
            End With
            rs.Close()
            Me.cmdSave.Enabled = False
            QueryPhieuThuTien()
            '''''cập nhật số seri torng DB
            'strQuery = "select* from PhieuThuTien Where PhieuThu_ID='" & DefaultValue & "'"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rs.Fields("SeriesNo").Value = GetSeriNo()
            'rs.Update()
            'rs.Close()

            'frmRPTphieuThuTien.data = False
            'frmRPTphieuThuTien.ShowDialog(Me)
            'Me.txtSeriesNo.Text = GetSeriNo() 'cập nhật Seri tren text box Sau mỗi lần thêm
            'TongCong = 0
            'Me.dgdNoiDungThu.Rows.Add(1)
            'Dim index As Integer = Me.dgdNoiDungThu.RowCount - 1

            'Me.dgdNoiDungThu.Item("LoaiKiemDinh", i).Value = Me.cboLoaiContainer.Text
            'Me.dgdNoiDungThu.Item("DonViTinh", i).Value = Me.cbodonvitinh.Text
            'Me.dgdNoiDungThu.Item("sotien", i).Value = Me.txtSoTien.Text
            'Me.dgdNoiDungThu.Item("SoLuong", i).Value = Me.txtSoLuong.Text
            'Me.dgdNoiDungThu.Item("ThanhTien", i).Value = Me.txtTongTien.Text
            'Me.dgdNoiDungThu.Item("NoiDung", i).Value = Me.txtNoiDungthu.Text

            'Me.dgdNoiDungThu.Item("NoiDungThu", index).Value = Me.txtNoiDungthu.Text
            'Me.dgdNoiDungThu.Item("SeriesNo", index).Value = Me.txtSeriesNo.Text
            'Me.dgdNoiDungThu.Item("TongCong", index).Value = Me.txtTongCong.Text
            'Me.dgdNoiDungThu.Item("TenKhachHang", index).Value = Me.txtTenKhachHang.Text
            'Me.dgdNoiDungThu.Item("DiaChi", index).Value = Me.txtDiaChi.Text
            'Me.dgdNoiDungThu.Item("MaSoThue", index).Value = Me.txtMaSoThue.Text

            'Me.dgdNoiDungThu.Item("HinhThucThanhToan", index).Value = Me.txtHinhThucThanhToan.Text
            'Me.dgdNoiDungThu.Item("LoaiContainer", index).Value = Me.cboLoaiContainer.Text
            'Me.dgdNoiDungThu.Item("SoLuong", index).Value = Me.txtSoLuong.Text

            'Me.dgdNoiDungThu.Item("DonViTinh", index).Value = Me.cbodonvitinh.Text
            'Me.dgdNoiDungThu.Item("DonGia", index).Value = Me.txtSoTien.Text
            'Me.dgdNoiDungThu.Item("ThanhTien", index).Value = Me.txtTongTien.Text

            TongTien()
            'For j As Integer = 0 To Me.dgdNoiDungThu.RowCount - 1
            '    TongCong += CDbl(Me.dgdNoiDungThu.Item("ThanhTien", j).Value.ToString)
            '    'Me.dgdNoiDungThu.Item("Stt", j).Value = j + 1
            'Next
            'Me.txtTongCong.Text = TongCong

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub dgdNoiDungThu_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdNoiDungThu.CellClick
        Try

            If Me.dgdNoiDungThu.RowCount = 0 Then
                Return
            End If
            If Me.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) = 0 Then
                Return
            End If
            Dim Index As Integer = Me.dgdNoiDungThu.SelectedRows(0).Index
            PhieuThuTien_ID = Me.dgdNoiDungThu.Item("PhieuThu_ID", Index).Value.ToString.Trim
            Refreshdata(Index)
            'Me.cmdThem.Enabled = False
            Me.cmdSave.Enabled = True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

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

    Private Sub dgdNoiDungThu_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdNoiDungThu.RowsRemoved
        Try
            'TongCong = 0
            'For j As Integer = 0 To Me.dgdNoiDungThu.RowCount - 1
            '    TongCong += CDbl(Me.dgdNoiDungThu.Item("ThanhTien", j).Value.ToString)
            'Next
            'Me.txtTongCong.Text = TongCong

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdOkReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkReport.Click
        Try
            If Me.dgdNoiDungThu.RowCount = 0 Then
                MsgBox("nhấn Nút thêm để thêm dòng vào lứơi rồi mới Print đựơc")
                Return
            End If
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            'Dim TempSeri As Double


            'strQuery = "select* from PhieuThuTien Where PhieuThu_ID='" & DefaultValue & "'"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rs.Fields("SeriesNo").Value = GetSeriNo()
            'rs.Update()
            'rs.Close()

            frmRPTphieuThuTien.data = False
            frmRPTphieuThuTien.ShowDialog(Me)
            'Me.txtSeriesNo.Text = GetSeriNo()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            ''''cập nhật số seri torng DB
            strQuery = "select* from PhieuThuTien Where PhieuThu_ID='" & DefaultValue & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("SeriesNo").Value = GetSeriNo()
            rs.Update()
            rs.Close()

            'frmRPTphieuThuTien.data = False
            'frmRPTphieuThuTien.ShowDialog(Me)
            Me.txtSeriesNo.Text = GetSeriNo() 'cập nhật Seri tren text box Sau mỗi lần thêm
            Me.cmdThem.Enabled = True
            Me.txtSeriesNo.Text = GetSeriNo()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'If Me.dgdNoiDungThu.RowCount = 0 Then
            '    MsgBox("nhấn Nút thêm để thêm dòng vào lứơi rồi mới Print đựơc")
            '    Return
            'End If
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            strQuery = " Select * from PhieuThuTien where PhieuThu_ID='" & PhieuThuTien_ID & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs

                '.AddNew()
                '.Fields("Phieuthu_ID").Value = NewId()
                .Fields("BLIB_NO").Value = gBillNoInBound

                .Fields("NoiDungThu").Value = Me.txtNoiDungthu.Text
                .Fields("SeriesNo").Value = Me.txtSeriesNo.Text
                .Fields("TongCong").Value = Me.txtTongCong.Text

                .Fields("TenKhachHang").Value = Me.txtTenKhachHang.Text
                .Fields("DiaChi").Value = Me.txtDiaChi.Text
                .Fields("MaSoThue").Value = Me.txtMaSoThue.Text

                .Fields("HinhThucThanhToan").Value = Me.txtHinhThucThanhToan.Text
                .Fields("LoaiContainer").Value = Me.cboLoaiContainer.Text
                .Fields("SoLuong").Value = Me.txtSoLuong.Text

                .Fields("DonViTinh").Value = Me.cbodonvitinh.Text
                .Fields("DonGia").Value = Me.txtSoTien.Text
                .Fields("ThanhTien").Value = Me.txtTongTien.Text
                .Update()
            End With
            rs.Close()
            Me.cmdSave.Enabled = False
            QueryPhieuThuTien()
            TongTien()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdNoiDungThu_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdNoiDungThu.CellContentClick

    End Sub

    Private Sub ctmDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmDel.Click
        Try
            If Me.dgdNoiDungThu.RowCount = 0 Then
                Return
            End If
            If Me.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) = 0 Then
                Return
            End If
            Dim Index As Integer = Me.dgdNoiDungThu.SelectedRows(0).Index

            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            strQuery = "select * from PhieuThuTien Where PhieuThu_ID='" & Me.dgdNoiDungThu.Item("PhieuThu_ID", Index).Value.ToString.Trim & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 0 'GetSeriNo()
            rs.Update()
            rs.Close()
            QueryPhieuThuTien()
            TongTien()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'dgdNoiDungThu_CellClick(sender, e)
    End Sub

    Private Sub mnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dgdNoiDungThu_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdNoiDungThu.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdNoiDungThu)
    End Sub

    Private Sub dgdNoiDungThu_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdNoiDungThu.RowStateChanged
        Try
            If Me.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) = 0 Then
                Me.cmdOkReport.Enabled = False
            Else
                Me.cmdOkReport.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdNoiDungThu_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdNoiDungThu.RowLeave

    End Sub

    Private Sub txtSoTien_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoTien.Leave
        Me.txtSoTien.Text = FormatNumber(Me.txtSoTien.Text, 0)
        Me.txtTongTien.Text = FormatNumber(Me.txtTongTien.Text, 0)
        Me.txtTongCong.Text = FormatNumber(Me.txtTongCong.Text, 0)
    End Sub

    Private Sub cmdAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAll.Click
        mnuNew_Click(sender, e)
        For i As Integer = 0 To Me.cboLoaiContainer.Items.Count - 1
            Me.cboLoaiContainer.SelectedIndex = i

            cmdThem_Click(sender, e)
        Next
    End Sub
End Class