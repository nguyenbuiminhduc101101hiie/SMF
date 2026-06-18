Public Class frmViewChitietCongTyChuaTraTienVND


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
        sql = "select charge_code,checkPrint,billoflading_house.blh_no as bl_no , handlingoutbound.agencyname,pricedebit,pricecredit,handlingoutbound.tax as tax ,handlingoutbound.currency as currency ,thanhtoan,chungtu,ngaythanhtoan,soptpc,handlingoutbound.remarks,handlingoutbound.userid,handlingoutbound.updatetime,handlingoutbound.approve,handlingoutbound.editable,handlingoutbound.continued FROM (handlingoutbound left join billoflading_house on handlingoutbound.bl_id=billoflading_house.blh_id )"
        sql += " WHERE (handlingoutbound.bl_id = '" & gBl_IdChitiet & "' and handlingoutbound.agencyname like N'%" & gAgencyNameChitiet & "%' and  handlingoutbound.continued=1 and pricedebit=0 and pricecredit<>0 and thanhtoan=0 and handlingoutbound.currency ='VND')"
        ds = ReadDataSet(Sql)
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