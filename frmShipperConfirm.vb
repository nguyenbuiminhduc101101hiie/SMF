Imports System.Windows.Forms
Public Class frmShipperConfirm

    Dim oTableHouseBill As New DataTable
    Dim oTableColo As New DataTable
    Dim IntShipper_H As Integer = 0
    Dim Intshipper_C As Integer = 0

    Private Sub QueryBillOfLading_house(ByRef dt As DataTable, ByVal strQuery As String)
        On Error GoTo Err_Renamed

        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If dt.Rows.Count > 0 Then
            dt.Rows.Clear()
        End If
        Adapter.Fill(dt)
        'oTableHouseBill = ds.Tables(0)
        Me.Cursor = Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub


    Sub QueryShipperREF(Optional ByVal id As String = "BLH_ID", Optional ByVal value As String = "BLH_NO")
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select BLH_NO,BL_ID from HouseCoLoBillInfo Where BL_ID='" & gBillOfLadingRpt & "' And Continued=1 And BLH_NO<>''"

        loadDataToObject(Me.cboShipperREF_H, strSQL, "BL_ID", "BLH_NO")
        strSQL = "Select COLOBILL,BL_ID from HouseColoBillInfo Where BL_ID='" & gBillOfLadingRpt & "' And Continued=1 And COLOBILL<>''"
        loadDataToObject(Me.cboShipperREF_C, strSQL, "BL_ID", "COLOBILL")
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmShipperConfirm_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CursorChanged
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmShipperConfirm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IntShipper_H = 0
        Intshipper_C = 0
        SetDefaultGrid(Me.dgdShipperREF_C, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdShipperREF_H, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.cboShipperREF_C.Text = ""
        Me.cboShipperREF_H.Text = ""
        QueryShipperREF()

        QueryBillOfLading_house(oTableHouseBill, "Select BLH_NO,BL_ID from HouseCoLoBillInfo Where BL_ID='" & gBillOfLadingRpt & "' And Continued=1 And BLH_NO<>''")
        QueryBillOfLading_house(oTableColo, "Select COLOBILL,BL_ID from HouseColoBillInfo Where BL_ID='" & gBillOfLadingRpt & "' And Continued=1 And COLOBILL<>''")
        Me.txtBL_NO.Text = gBillNoRpt
        Me.dgdShipperREF_H.Rows.Clear()
        Me.dgdShipperREF_C.Rows.Clear()


    End Sub

    Private Sub cmdAdd_H_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd_H.Click
        On Error GoTo Err_Renamed
        Dim row As DataRow

        For Each row In oTableHouseBill.Rows
            If (UCase(row.Item("BLH_NO").ToString) = Me.cboShipperREF_H.Text) Then
                Me.dgdShipperREF_H.Rows.Add(1)
                'Me.dgdShipperREF_H.Item("HBL_NO", IntShipper_H).Value = row.Item("BL_NO").ToString
                Me.dgdShipperREF_H.Item("HBLH_NO", IntShipper_H).Value = row.Item("BLH_NO").ToString
                IntShipper_H += 1
                'oTableHouseBill.Rows.Remove(row)
                Me.cboShipperREF_H.Items.Remove(row.Item("BLH_NO"))
            End If
        Next
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdAdd_C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd_C.Click
        On Error GoTo Err_Renamed
        Dim row As DataRow
        For Each row In oTableColo.Rows
            If (UCase(row.Item("COLOBILL").ToString) = Me.cboShipperREF_C.Text) Then
                Me.dgdShipperREF_C.Rows.Add(1)
                'Me.dgdShipperREF_C.Item("CBL_NO", Intshipper_C).Value = row.Item("BL_NO").ToString
                Me.dgdShipperREF_C.Item("CBLH_NO", Intshipper_C).Value = row.Item("COLOBILL").ToString
                Intshipper_C += 1
                Me.cboShipperREF_C.Items.Remove(row.Item("COLOBILL"))
            End If
        Next
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Shipper_H = ""
        Shipper_C = ""
        For i As Integer = 0 To Me.dgdShipperREF_H.Rows.Count - 1
            If Me.dgdShipperREF_H.Item("HBLH_NO", i).Value <> "" Then
                Shipper_H &= Me.dgdShipperREF_H.Item("HBLH_NO", i).Value & " \ "
            End If

        Next
        For j As Integer = 0 To Me.dgdShipperREF_C.Rows.Count - 1
            If Me.dgdShipperREF_C.Item("CBLH_NO", j).Value <> "" Then
                Shipper_C &= Me.dgdShipperREF_C.Item("CBLH_NO", j).Value & " \ "
            End If
        Next
        VB6.ShowForm(frmRptExportCargoManiFest, VB6.FormShowConstants.Modal, Me)
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuDel_H_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel_H.Click
        On Error GoTo Err_Renamed
        If Me.dgdShipperREF_H.Rows.Count > 0 Then
            Dim index As Integer
            index = Me.dgdShipperREF_H.CurrentRow.Index
            Me.dgdShipperREF_H.Rows.RemoveAt(index)
            IntShipper_H -= 1
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuDel_C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel_C.Click
        On Error GoTo Err_Renamed
        If Me.dgdShipperREF_C.Rows.Count > 0 Then
            Dim index As Integer
            index = Me.dgdShipperREF_C.CurrentRow.Index
            Me.dgdShipperREF_C.Rows.RemoveAt(index)
            Intshipper_C -= 1
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class