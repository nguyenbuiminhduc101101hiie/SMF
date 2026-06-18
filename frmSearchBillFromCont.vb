Public Class frmSearchBillFromCont

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            sql = "select Ref,mblcarrier as MBL,mblmawb as HBL,hblhawb as HBLHAWB,containerno as [Container No.],Shipper,Consignee from containertype left join outbound on outbound.blob_id=containertype.outboundid where containerno like '%" & Me.txtcontainerNo.Text & "%' "
            ds = ReadDataSet(sql)
            Me.DataGridView1.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.DataGridView1)
            If ds.Tables(0).Rows.Count = 0 Then
                '-----------inbound
                sql = "select Ref,MBL,HBL,containerno as [Container No.],Shipper,Consignee from containerrepair left join  inbound on inbound.blib_id=containerrepair.inboundid where containerno like '%" & Me.txtcontainerNo.Text & "%' "
                ds = ReadDataSet(sql)
                Me.DataGridView1.DataSource = ds.Tables(0)
                InsertAutoNumberToGrid(Me.DataGridView1)
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                '-----------logistics
                sql = "select Ref,mblcarrier as MBL, mblmawb as HBL ,containerno as [Container No.] from containerlogistics   left join  logistics on logistics.blob_id=containerlogistics.outboundID where containerno like '%" & Me.txtcontainerNo.Text & "%' "
                ds = ReadDataSet(sql)
                Me.DataGridView1.DataSource = ds.Tables(0)
                InsertAutoNumberToGrid(Me.DataGridView1)
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.DataGridView1, Me)
            'SetMenu(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class