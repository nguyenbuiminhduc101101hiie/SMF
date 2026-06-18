Public Class frmVitri

    Private Sub cbonhakho_Leave(sender As Object, e As EventArgs) Handles cbonhakho.Leave
        Try
            Dim id As String
            Dim value As String
            Dim strQuery As String

    

            id = "ten"
            value = "ten_"
            strQuery = "select ten,ten +'('+ convert(varchar(50),dai) +',' + convert(varchar(50),rong) + ',' + convert(varchar(50),cao) + ')'  as ten_ from vung where warehouse='" & FindValueID(Me.cbonhakho, Me.cbonhakho.Text) & "'   "
            loadDataToObject(Me.cbovung, strQuery, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbonhakho.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmVitri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' load toan bo len combo
            Dim id As String
            Dim value As String
            Dim strQuery As String

            id = "ten"
            value = "ten_"
            strQuery = "select ten,ten +'('+ convert(varchar(50),dai) +',' + convert(varchar(50),rong) + ',' + convert(varchar(50),cao) + ')'  as ten_ from warehouse   "
            loadDataToObject(Me.cbonhakho, strQuery, id, value)

            id = "ten"
            value = "ten_"
            strQuery = "select ten,ten +'('+ convert(varchar(50),dai) +',' + convert(varchar(50),rong) + ',' + convert(varchar(50),cao) + ')'  as ten_ from vung   "
            loadDataToObject(Me.cbovung, strQuery, id, value)

            id = "ten"
            value = "ten_"
            strQuery = "select ten,ten +'('+ convert(varchar(50),dai) +',' + convert(varchar(50),rong) + ',' + convert(varchar(50),cao) + ')'  as ten_ from day   "
            loadDataToObject(Me.cboday, strQuery, id, value)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbovung_Leave(sender As Object, e As EventArgs) Handles cbovung.Leave
        Try
            Dim id As String
            Dim value As String
            Dim strQuery As String
            Me.cboday.Text = ""


            id = "ten"
            value = "ten_"
            strQuery = "select ten,ten +'('+ convert(varchar(50),dai) +',' + convert(varchar(50),rong) + ',' + convert(varchar(50),cao) + ')'  as ten_ from day  where vung like '%" & FindValueID(Me.cbovung, Me.cbovung.Text) & "%'  "
            loadDataToObject(Me.cboday, strQuery, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbovung_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbovung.SelectedIndexChanged
        Try
            Dim id As String
            Dim value As String
            Dim strQuery As String
            Me.cboday.Text = ""


            id = "ten"
            value = "ten_"
            strQuery = "select ten,ten +'('+ convert(varchar(50),dai) +',' + convert(varchar(50),rong) + ',' + convert(varchar(50),cao) + ')'  as ten_ from day  where vung like '%" & FindValueID(Me.cbovung, Me.cbovung.Text) & "%'  "
            loadDataToObject(Me.cboday, strQuery, id, value)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboday_Leave(sender As Object, e As EventArgs) Handles cboday.Leave
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboday_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboday.SelectedIndexChanged
        Try
            Dim dem, i, currow As Integer
            Me.DataGridView1.Rows.Clear()
            Dim ds As New DataSet
            Dim makequeryport As String
            makequeryport = "select id,day,ten,dai,rong,cao,tinhtrang,vitri,ghichu from vitri  where day like '%" & FindValueID(Me.cboday, Me.cboday.Text) & "%' "

            ds = ReadDataSet(makequeryport)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    'Me.dgdPort.Rows(currow).DefaultCellStyle.BackColor = Color.White
                    'Me.dgdPort.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                    Me.DataGridView1.Item("id", currow).Value = ds.Tables(0).Rows(i).Item("id").ToString
                    Me.DataGridView1.Item("day", currow).Value = ds.Tables(0).Rows(i).Item("day").ToString
                    Me.DataGridView1.Item("ten", currow).Value = ds.Tables(0).Rows(i).Item("ten").ToString
                    Me.DataGridView1.Item("dai", currow).Value = ds.Tables(0).Rows(i).Item("dai").ToString
                    Me.DataGridView1.Item("rong", currow).Value = ds.Tables(0).Rows(i).Item("rong").ToString
                    Me.DataGridView1.Item("cao", currow).Value = ds.Tables(0).Rows(i).Item("cao").ToString
                    Me.DataGridView1.Item("tinhtrang", currow).Value = ds.Tables(0).Rows(i).Item("tinhtrang").ToString
                    Me.DataGridView1.Item("ghichu", currow).Value = ds.Tables(0).Rows(i).Item("ghichu").ToString
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdedit_Click(sender As Object, e As EventArgs) Handles cmdedit.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class