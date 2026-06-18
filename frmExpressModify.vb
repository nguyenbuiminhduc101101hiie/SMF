Public Class frmExpressModify
    Dim xcu, ycu As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Public Sub loadCombo()
        Try
            Dim id, value, strSQL As String
            Dim cost, sell As String
            cost = "cost"
            sell = "sell"
            Me.cboCode.Items.Clear()
            id = "code"
            value = "code"
            strSQL = "Select distinct code,code,effdate From express_rate where code like '%" & cost & "%'   order by code,effdate "
            loadDataToObject(Me.cboCode, strSQL, id, value)

            '---------------------------------
            Me.cboCode1.Items.Clear()
            id = "code"
            value = "code"
            strSQL = "Select distinct code,code,effdate From express_rate where code like '%" & sell & "%'  order by code,effdate "
            loadDataToObject(Me.cboCode1, strSQL, id, value)

         
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Me.dgDVIEW.Rows.Clear()
            Dim i, j, ir As Integer
            sql = " select express_rate.*,express_zone.code,express_zone.pwd from express_rate left join express_zone on express_rate.zoneid=express_zone.id where express_rate.code='" & Me.cboCode.Text & "' order by doc,weight,express_zone.code "
            ds = ReadDataSet(sql)
            ir = 0
            For i = 0 To CInt(ds.Tables(0).Rows.Count / 22) - 1

                'If i Mod 8 = 0 Then
                Me.dgDVIEW.Rows.Add(1)
                Me.dgDVIEW.Item("weight", i).Value = ds.Tables(0).Rows(ir).Item("weight").ToString
                'End If

                For j = 1 To 22
                    'If ds.Tables(0).Rows(ir).Item("CODE").ToString = Me.dgDVIEW.Item(Alpha(j - 1), i).Value.ToString Then
                    Me.dgDVIEW.Item(Alpha(j - 1), i).Value = FormatNumber(ds.Tables(0).Rows(ir).Item("price").ToString, 2)
                    ir += 1
                    ' End If

                Next
            Next
            ' Me.DGDvIEW.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.DGDvIEW)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmExpressModify_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadCombo()
    End Sub

    Private Sub cmdOK1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Me.dgdview1.Rows.Clear()
            Dim i, j, ir As Integer
            sql = " select express_rate.*,express_zone.code,express_zone.pwd from express_rate left join express_zone on express_rate.zoneid=express_zone.id where express_rate.code='" & Me.cboCode1.Text & "' order by doc,weight,express_zone.code "
            ds = ReadDataSet(sql)
            ir = 0
            For i = 0 To CInt(ds.Tables(0).Rows.Count / 22) - 1 '8

                'If i Mod 8 = 0 Then
                Me.dgdview1.Rows.Add(1)
                Me.dgdview1.Item("weight1", i).Value = ds.Tables(0).Rows(ir).Item("weight").ToString
                'End If

                For j = 1 To 22 '8
                    Me.dgdview1.Item(Alpha1(j - 1), i).Value = FormatNumber(ds.Tables(0).Rows(ir).Item("price").ToString, 2)
                    ir += 1
                Next
            Next
            ' Me.DGDvIEW.DataSource = ds.Tables(0)
            InsertAutoNumberToGrid(Me.dgdview1)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim cmd As New ADODB.Command
            Dim strMesg As String
            If Me.cboCode.Text = "" Then

            Else
                strMesg = "Delete the Rate : " & Me.cboCode.Text
                If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "delete from express_rate where code= '" & Me.cboCode.Text.ToString.Trim & "' "
                    cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    DisplayMessage(True, "Complete.!")
                    loadCombo()
                    Me.Button1_Click(sender, e)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim cmd As New ADODB.Command
            Dim strMesg As String
            If Me.cboCode.Text = "" Then

            Else
                strMesg = "Delete the Rate : " & Me.cboCode1.Text
                If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    cmd.let_ActiveConnection(strconn)
                    cmd.CommandText = "delete from express_rate where code= '" & Me.cboCode1.Text.ToString.Trim & "' "
                    cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                    DisplayMessage(True, "Complete.!")
                    loadCombo()
                    Me.cmdOK1_Click(sender, e)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If Me.dgDVIEW.RowCount > 0 Then

                ExportExecel(Me.dgDVIEW, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If Me.dgdview1.RowCount > 0 Then

                ExportExecel(Me.dgdview1, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgDVIEW_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDVIEW.CellContentClick, dgDVIEW.CellClick
        Try
            Me.dgdview1.Rows(xcu).Cells(ycu).Style.BackColor = Color.White
            If Me.dgDVIEW.Rows.Count > 0 And Me.dgdview1.Rows.Count > 0 Then
                Me.dgdview1.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
            End If
            xcu = e.RowIndex
            ycu = e.ColumnIndex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdview1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdview1.CellContentClick, dgdview1.CellClick
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class