Public Class frmExpress_Zone

    Private Sub frmExpress_Zone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryPort()
        Dim sql As String

        Dim ds As New DataSet
        sql = " select * from express_zone order by code,pwd "
        ds = ReadDataSet(sql)
        Me.dgdview.DataSource = ds.Tables(0)
        InsertAutoNumberToGrid(Me.dgdview)
    End Sub
    Sub QueryPort()
        Try
            Dim id As String = "shippingline"
            Dim value As String = "shippingline"
            Dim strQuery As String = "select * from shippingline order by shippingline "
            loadDataToObject(Me.cboPWD, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim strQuery, strCurrencyId, pName As String
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM EXPRESS_ZONE "
            strQuery = strQuery & "WHERE code = '" & Me.cboCode.Text & "' AND  pwd='" & Me.cboPWD.Text & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("id").Value = NewId()
                End If
              
                .Fields("code").Value = UCase(Trim(Me.cboCode.Text))
                .Fields("pwd").Value = UCase(Trim(Me.cboPWD.Text))
                .Fields("ttime").Value = Me.txtTT.Text


            
                .Update()
            End With
            rs.Close()
            Button3_Click(sender, e)
            '------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub dgdview_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdview.CellContentClick

    End Sub

    Private Sub dgdview_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdview.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdview)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        QueryPort()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql As String
        Dim ds As New DataSet
        sql = " select * from express_zone where pwd='" & Me.cboPWD.Text.Trim & "' order by code,pwd "
        ds = ReadDataSet(Sql)
        Me.dgdview.DataSource = ds.Tables(0)
        InsertAutoNumberToGrid(Me.dgdview)
    End Sub
End Class