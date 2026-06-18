Public Class frmViewChitietKhachhangChuaThanhToanChoCtyVND
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
    End Sub

    Private Sub frmViewChitietKHCTT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String
        Dim ds As New DataSet
        If gBl_IdChitiet = "" Or gAgencyNameChitiet = "" Then
            Me.dgdPort.DataSource = Nothing
            Return
        End If
        SetDefaultGrid(Me.dgdPort, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        sql = "select handlingInboundid,handlingInbound.blib_id,charge_code,checkprint,billofladingib.blib_no as blib_no , handlingInbound.agencyname,pricedebit,pricecredit,handlingInbound.tax as tax ,handlingInbound.currency as currency ,handlingInbound.remarks,thanhtoan,chungtu,ngaythanhtoan,soptpc,handlingInbound.userid,handlingInbound.updatetime,handlingInbound.approve,handlingInbound.editable,handlingInbound.continued FROM (handlingInbound left join billofladingib on handlingInbound.blib_id=billofladingib.blib_id ) "
        sql += " WHERE (handlingInbound.blib_id = '" & gBl_IdChitiet & "' and handlingInbound.agencyname like N'%" & gAgencyNameChitiet & "%' and  handlingInbound.continued=1 and pricedebit<>0 and pricecredit=0 and thanhtoan=0 and handlingInbound.currency ='VND')"
        ds = ReadDataSet(sql)
        Me.dgdPort.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.dgdPort.Rows.Count > 0 Then
                'SetMenu(False)
                ExportExecel(Me.dgdPort, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class