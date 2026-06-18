Public Class frmKPIs

    Private Sub frmKPIs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '--------------ring
            Dim id, value, strSQL As String
            Me.cbosale.Items.Clear()
            id = "sale_id"
            value = "salecode"
            strSQL = "Select sale_id,salecode From sale order by salecode "
            loadDataToObject(Me.cbosale, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' them cot theo from to
            Dim socot As Integer

            socot = CInt(Me.cbotoweek.Text) - CInt(Me.cbofromweek.Text)
            Me.DataGridView1.Columns.Clear()
            Me.DataGridView1.Rows.Clear()
            ' chen cot len luoi
            Dim i As Integer
            Me.DataGridView1.Columns.Add("KPIs", "KPIs")
            For i = 0 To socot
                Me.DataGridView1.Columns.Add((CInt(Me.cbofromweek.Text) + i).ToString, "Week " + (CInt(Me.cbofromweek.Text) + i).ToString + "/" + Me.cboyear.Text)
            Next

            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 0).Value = "1.Visit"
            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 1).Value = "2.Tel Call"

            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 2).Value = "3.FTF Time"
            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 3).Value = "4.Proposol"

            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 4).Value = "5.Win Proposol"

            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 5).Value = "6.Qualify Prospect"

            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 6).Value = "7.Commitment"


            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 7).Value = "8.New Trader"


            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Item("KPIs", 8).Value = "9.New Account"











            ' ung voi tung name Cot ta them
            Dim sql As String
            Dim ds As New DataSet
            Dim dong As Integer
            Dim countDs, k As Integer

            For i = 0 To socot
                sql = "select kpi,count(*) as tong,sum(thoigian) as thoigian from recording where week='" & (CInt(Me.cbofromweek.Text) + i).ToString & "' and year ='" & Me.cboyear.Text & "' and salecode='" & Me.cbosale.Text & "' group by kpi order by kpi "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    ' kiem tra ten cot
                    countDs = ds.Tables(0).Rows.Count
                    If Me.DataGridView1.Columns(i + 1).Name = (CInt(Me.cbofromweek.Text) + i).ToString Then
                        For k = 0 To countDs - 1


                            For dong = 0 To 8
                                ' neu co so lieu
                                If ds.Tables(0).Rows(k).Item("kpi").ToString Like (dong + 1).ToString + "*" Then
                                    If UCase(ds.Tables(0).Rows(k).Item("kpi").ToString) Like "*TIME*" Then
                                        Me.DataGridView1.Item((CInt(Me.cbofromweek.Text) + i).ToString, dong).Value = ds.Tables(0).Rows(k).Item("thoigian").ToString

                                    Else
                                        Me.DataGridView1.Item((CInt(Me.cbofromweek.Text) + i).ToString, dong).Value = ds.Tables(0).Rows(k).Item("tong").ToString

                                    End If

                                Else

                                End If

                            Next
                        Next
                    End If

                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class