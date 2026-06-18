Public Class frmListContainerArrival
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Try
                If Me.DataGridView2.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                ExportExecel(Me.DataGridView2, Me)
                'SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                sql = "select inboundContainersid,inboundid,containerno,containertype,mbl,hbl,ngayIFD,ngayDCO,ngayEMM,ngayDSO,ngayOFO,ngayOEO,ngayBFF,refexport,billexport,vesselexport from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where (hbl like '%" & Me.txthbl.Text.Trim & "%') and nvocc=1 and IFD=1 "
                ds = ReadDataSet(sql)
                Me.lblcontExport.Text = "Hiện có " + ds.Tables(0).Rows.Count.ToString + " Containers."

                Me.DataGridView2.DataSource = ds.Tables(0)
                InsertAutoNumberToGrid(Me.DataGridView2)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Try
                Try
                    Dim sql As String
                    Dim ds As New DataSet
                    sql = "select inboundContainersid,inboundid,containerno,containertype,mbl,hbl,ngayIFD,ngayDCO,ngayEMM,ngayDSO,ngayOFO,ngayOEO,ngayBFF,refexport,billexport,vesselexport from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where nvocc=1 and IFD=1 "
                    ds = ReadDataSet(sql)
                    Me.lblcontExport.Text = "Hiện có " + ds.Tables(0).Rows.Count.ToString + " Containers."

                    Me.DataGridView2.DataSource = ds.Tables(0)
                    InsertAutoNumberToGrid(Me.DataGridView2)
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                sql = "select inboundContainersid,inboundid,containerno,containertype,mbl,hbl,ngayIFD,ngayDCO,ngayEMM,ngayDSO,ngayOFO,ngayOEO,ngayBFF,refexport,billexport,vesselexport from containerrepair left join inbound on inbound.blib_id=containerrepair.inboundid where (mbl like '%" & Me.txtBill.Text.Trim & "%') and nvocc=1 and IFD=1 "
                ds = ReadDataSet(sql)
                Me.lblcontExport.Text = "Hiện có " + ds.Tables(0).Rows.Count.ToString + " Containers."

                Me.DataGridView2.DataSource = ds.Tables(0)
                InsertAutoNumberToGrid(Me.DataGridView2)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class