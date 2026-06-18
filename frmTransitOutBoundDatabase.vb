Public Class frmTransitOutBoundDatabase
    Dim SQL As String
    Dim mFilter As String




    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        Dim strBillOfLadingSelect As String = " SELECT BillOfLadingIb.BLIB_Id," & _
                 "BillOfLadingIb.BLIB_NO as BLIB_NO, " & _
                  "Shipper.SHIPPER_1  as ShipperName, " & _
                 "Consignee.CONSIGNEE_1  as ConsigneeName, REF," & _
                 "Notify.NOTIFY_1  as NotifyName,  " & _
                 "Vessel,VesselCode," & _
                 "VoyAge," & _
                 "CY_CFS_ITEM ,SAILINGDATE , ETA, VIA, " & _
                 "POR, " & _
                 "POL , " & _
                 "POD ,  " & _
                 "DEL, " & _
                 "DEST,  " & _
                 "LC_NO,ICDPort,BL_Type, WeekOfYear ," & _
                 "DESCRIPTIONOFGOODS,DESCRIPTIONFORSHIPPER,MARKS,DisChargeDate, " & _
                 "BillOfLadingIb.Editable as Editable, " & _
                 "BillOfLadingIb.Continued as Continued, " & _
                 "BillOfLadingIb.Approve as Approve, " & _
                 "BillOfLadingIb.UserId as UserId, " & _
                 "BillOfLadingIb.Updatetime as Updatetime "
        MakeQueryBillOfLading = strBillOfLadingSelect

        MakeQueryBillOfLading = MakeQueryBillOfLading & ",((select Count(*) From Cargoib where Cargoib.BLIB_ID=BillOfLadingIb.BLIB_ID And CargoIb.continued=1 and BillOfLadingIb.continued=1 and Transit=1) + (select Count(*) From bltransitoutbound where bltransitoutbound.BLIB_ID=BillOfLadingIb.BLIB_ID And bltransitoutbound.continued=1 and BillOfLadingIb.continued=1 and Transit=1)) As QuantityOfContainer "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLadingIb left join Shipper on BillOfLadingIb.Shipper_Id=Shipper.Shipper_Id ) left join Consignee on BillOfLadingIb.Consignee_Id=Consignee.Consignee_Id ) left join Notify  on BillOfLadingIb.Notify_Id=Notify.Notify_id )  "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " BillOfLadingIb.Continued = 1 And Transit=1 " 'And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "'"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " "
        If argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If
        MakeQueryBillOfLading = MakeQueryBillOfLading & " Order By BLIB_NO ASC "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & strBillOfLadingOrder2


        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Sub QueryTransitDataBase(Optional ByVal Range As String = "")
        Try
            'SQL = "Select * from BillOfLadingIb Where Continued=1 And TranSit=1 "
            'SQL &= " And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "' Order By BLIB_NO"
            SQL = MakeQueryBillOfLading(Range)
            Dim dt1 As New DataTable
            dt1 = ReadTable(SQL)
            Me.dgdBillOfLading.DataSource = dt1
            'Dim countcontainer As Double = 0

            'For i As Integer = 0 To dt1.Rows.Count - 1
            '    countcontainer += CDbl(dt1.Rows(i).Item("QuantityOfContainer").ToString)
            'Next
            'Me.lblTotalTransitOutbound.Text = dt1.Rows.Count & " Bill(s) And " & countcontainer & " Container(s)"
            Me.BL_ID.Visible = False
            InsertAutoNumberToGrid(Me.dgdBillOfLading)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub mnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryTransitDataBase("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub mnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportExcel.Click
        Try
            If Me.dgdBillOfLading.RowCount > 0 Then
                'SetMenu(False)
                Me.Cursor = Cursors.WaitCursor
                ExportExecel(Me.dgdBillOfLading, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmTransitOutBoundDatabase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDefaultGrid(Me.dgdBillOfLading, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub
End Class