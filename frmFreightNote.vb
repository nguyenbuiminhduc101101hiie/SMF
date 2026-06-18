Public Class frmFreightNote

    Dim strQuery As String
    Dim rs As New ADODB.Recordset

    Private Sub frmFreightNote_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CursorChanged
        Me.Cursor = Cursors.Default
    End Sub
    Sub QueryShippingline()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "shippinglineid"
        value = "shippingline"
        strSQL = "Select shippinglineid, shippingline From shippingline  Order By shippingline"
        loadDataToObject(Me.cboShippingLines, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmFreightNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        Me.txtBL_NO.Text = gBillNoInBound
        QueryShippingline()

        strQuery = "SELECT * "
        strQuery = strQuery & "FROM FREIGHTNOTE "
        strQuery = strQuery & "WHERE BLIB_NO = '" & gBillNoInBound & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            With rs
                Me.txtTax.Text = .Fields("TAX").Value
                'Me.txtMESSRS.Text = .Fields("MESSRS").Value
            End With
        End If
        Me.txtMESSRS.Text = ""
        strQuery = "Select * from (Consignee INNER JOIN BillOfLaDingIb On BillOfLadingIb.Consignee_id=Consignee.Consignee_ID) "
        strQuery &= " Where BLIB_NO='" & gBillNoInBound & "' And BillOfLaDingIb.Continued=1"
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
        Dim dt As New DataTable
        Adapter.Fill(dt)
        If dt.Rows.Count > 0 Then
            Me.txtMESSRS.Text &= dt.Rows(0).Item("Consignee_1").ToString
            Me.txtMESSRS.Text &= dt.Rows(0).Item("Consignee_2").ToString
            Me.txtMESSRS.Text &= dt.Rows(0).Item("Consignee_3").ToString
            Me.txtMESSRS.Text &= dt.Rows(0).Item("Consignee_4").ToString
            Me.txtMESSRS.Text &= dt.Rows(0).Item("Consignee_5").ToString
            Me.txtMESSRS.Text &= dt.Rows(0).Item("Consignee_6").ToString
            ' 
            Me.cboShippingLines.Text = dt.Rows(0).Item("shippingline").ToString
        End If
        rs.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err
        Me.txtBL_NO.Text = gBillNoInBound
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM FREIGHTNOTE "
        strQuery = strQuery & "WHERE BLIB_NO = '" & gBillNoInBound & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        With rs
            If rs.EOF Then
                .AddNew()
                .Fields("FreightNoteID").Value = NewId()
                .Fields("BLIB_NO").Value = gBillNoInBound
            End If
            .Fields("TAX").Value = Me.txtTax.Text
            .Fields("MESSRS").Value = Me.txtMESSRS.Text

            .Update()
        End With

        rs.Close()
        Me.Hide()
        VB6.ShowForm(frmRptfreightNote, VB6.FormShowConstants.Modal, Me)
        Me.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err
        Me.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class