Public Class frmSearchQuotationCode

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If Me.chkonly.Checked = True Then
                sql = "select * from logisticsquotationCost where ((convert(datetime,tu) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "') or  (convert(datetime,den) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "')) and service like '%" & Me.cbosale.Text & "%'"
            Else
                sql = "select * from logisticsquotationCost where (convert(datetime,tu) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "') or  (convert(datetime,den) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "') "
            End If
            ds = ReadDataSet(sql)
            Me.dgdShippingLines.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.dgdShippingLines)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If Me.dgdShippingLines.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.dgdShippingLines, Me)
        Catch ex As Exception

        End Try
    End Sub
End Class