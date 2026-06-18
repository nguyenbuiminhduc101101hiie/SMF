Public Class frmSeaArrival

    Private Sub frmSeaArrival_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' load combo 
            Dim id, value, strSQL As String
            id = "blib_id"
            value = "hbl"
            Me.cboHBL.Items.Clear()


            strSQL = "Select distinct blib_id,hbl From inbound  where branch like '%" & gBranch & "%' and Continued=1 "
            loadDataToObject(Me.cboHBL, strSQL, id, value)
            '-------------------------




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            ' view so lieu theo id cua cboHBL
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound where blib_id ='" & FindValueID(Me.cboHBL, Me.cboHBL.Text) & "' "
            ds = ReadDataSet(sql)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtarrival_pod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtarrival_pod.TextChanged

    End Sub

    Private Sub txtarrival_hbl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtarrival_hbl.TextChanged

    End Sub
End Class