Public Class frmTransitContainerOut
    Dim SQL As String

    Function QueryBillOfLading(Optional ByVal agr As String = "") As DataTable
        Try
            'If Vessel = "" Or VoyNo = "" Then
            '    Return
            'End If
            SQL = "Select CargoIB.Container_Type ,Count(CargoIB.Container_type) as Quantity"
            SQL &= " From (BLTransitOutbound INNER JOIN CargoIB On CargoIB.CargoIB_ID=BLTransitOutBound.CargoIB_ID)"
            SQL &= " Where BLTransitOutbound.Continued=1 " & agr
            SQL &= " Group By CargoIB.Container_type "
            Dim oTableBill As New DataTable
            oTableBill = ReadTable(SQL)


            SQL = "Select Count(Container_Type) as ToTal,Container_Type "
            SQL &= " From ((CargoIB INNER JOIN BillOfLadingIB On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID)"
            SQL &= " LEFT JOIN BLTransitOutbound On BLTransitOutbound.CargoIB_ID=CargoIB.cargoIB_ID)"
            SQL &= " Where cargoIB.Continued=1 Or (CargoIB.Continued=0 and CargoIB.CargoIB_ID In (Select CargoIB_ID From BLTransitOutbound))  " & agr
            SQL &= " Group By CargoIB.Container_Type "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            oTableBill.Columns.Add("ToTal_In_Out")
            For i As Integer = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To oTableBill.Rows.Count - 1
                    If dt.Rows(i).Item("Container_type").ToString = oTableBill.Rows(j).Item("Container_Type").ToString Then
                        oTableBill.Rows(j).Item("ToTal_In_Out") = dt.Rows(i).Item("ToTal")
                        Exit For
                    End If
                Next
            Next
            'Dim CountBillNo As Integer
            'Dim billNo As String = ""
            'For i As Integer = 0 To oTablebill.Rows.Count - 1
            '    If billNo <> oTablebill.Rows(i).Item("BLIB_NO").ToString.Trim Then
            '        billNo = oTablebill.Rows(i).Item("BLIB_NO").ToString.Trim
            '        CountBillNo += 1
            '    End If
            'Next
            Me.dgdData.DataSource = oTableBill
            InsertAutoNumberToGrid(Me.dgdData)
            Return oTableBill
            'Me.lblTotalTransitBill.Text = CountBillNo & " Bill(s) And " & oTablebill.Rows.Count & " Container(s)"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cdmCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdData.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdData, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdData.CellContentClick

    End Sub

    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

    Private Sub cmdAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAll.Click
        QueryBillOfLading()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim arg As String
        arg = " And convert(DateTime,VesselOutETD) +1 >'" & Me.dtpFromETD.Value.Date & "' And Convert(DateTime,VesselOutETD) -1 < '" & Me.dtpToETD.Value.Date & "'"
        QueryBillOfLading(arg)
    End Sub

    Private Sub frmTransitContainerOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class