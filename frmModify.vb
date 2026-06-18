Public Class frmModify
    Public mDataSetService As DataSet
    Dim con As OleDb.OleDbConnection
    Dim cmdSelect As OleDb.OleDbCommand
    Dim Adapter As OleDb.OleDbDataAdapter
    Private Sub frmSetbalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim id, value, strSQL As String
            ' lay cont vao cbopack
            'cbocontPack.Items.Clear()
            'id = "outboundContainersID"
            'value = "ContainerNo"
            'strSQL = "Select outboundcontainersid ,containerno From containertype where outboundid='" & gOutboundID & "'  "
            'loadDataToObject(Me.cbocontPack, strSQL, id, value)
            '-------------------------------------------
            Me.textbox1.Items.Clear()
            id = "table_name"
            value = "table_name"
           
            strSQL = "Select  table_name From INFORMATION_SCHEMA.TABLES  order by table_name "
        
            loadDataToObject(Me.textbox1, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSaveService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveService.Click
        Dim i As Integer
        Dim sql As String
        If Me.dgdShippingLines.RowCount = 0 Then
            Return
        End If
        sql = "select * from " & Me.textbox1.Text & " "
        Dim conOLE As New OleDb.OleDbConnection(strconn)

        conOLE.Open()
        Dim data As New OleDb.OleDbDataAdapter(sql, conOLE)

        Try
            If mDataSetService.HasChanges Then
                Dim NewDS As New DataSet
                NewDS = mDataSetService.GetChanges
                Dim buider As New System.Data.OleDb.OleDbCommandBuilder(data)
                data.TableMappings.Add("Table", mDataSetService.Tables("Service").TableName)
                i = data.Update(NewDS)
                mDataSetService.Clear()

            End If

            MsgBox("Records Updated= " & i)
            conOLE.Close()
            Me.Button2_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim sql As String
            'Me.dgdShippingLines.Rows.Clear()
            sql = "select * from " & Me.TextBox1.Text & " "
            '--------------------------------------------------------
            mDataSetService = New DataSet
            con = New OleDb.OleDbConnection(strconn)
            cmdSelect = New OleDb.OleDbCommand(sql, con)
            Adapter = New OleDb.OleDbDataAdapter(cmdSelect)
            con.Open()
            Adapter.Fill(mDataSetService, "Service")

            Me.dgdShippingLines.DataSource = mDataSetService.Tables("Service")
            InsertAutoNumberToGrid(Me.dgdShippingLines)
        Catch ex As Exception

        End Try
    End Sub
End Class