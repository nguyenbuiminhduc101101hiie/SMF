Imports System.Windows.Forms.DateTimePicker

Public Class frmTongchi
    '--service
    Public mDataSetService As DataSet
    Dim con As OleDb.OleDbConnection
    Dim cmdSelect As OleDb.OleDbCommand
    Dim Adapter As OleDb.OleDbDataAdapter
    Private Sub frmSetbalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim sql As String
            sql = "select * from othercredit "
            '--------------------------------------------------------
            mDataSetService = New DataSet
            con = New OleDb.OleDbConnection(strconn)
            cmdSelect = New OleDb.OleDbCommand(sql, con)
            Adapter = New OleDb.OleDbDataAdapter(cmdSelect)
            con.Open()
            Adapter.Fill(mDataSetService, "Service")

            Me.dgdShippingLines.DataSource = mDataSetService.Tables("Service")

            InsertAutoNumberToGrid(Me.dgdShippingLines)

            'Dim col As New CalendarColumn()
            'Me.dgdShippingLines.Columns.Add("from", "From")
            'Me.dgdShippingLines.RowCount = 5
            'Dim row As DataGridViewRow
            'For Each row In Me.dgdShippingLines.Rows
            '    row.Cells(0).Value = DateTime.Now
            'Next row

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSaveService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveService.Click
        Dim i As Integer
        Dim sql As String
        If Me.dgdShippingLines.RowCount = 0 Then
            Return
        End If
        sql = "select * from othercredit "
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
            frmSetbalance_Load(sender, e)
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

    Private Sub dgdShippingLines_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdShippingLines.CellContentClick
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdShippingLines_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdShippingLines.CellLeave
        Try
            Dim index As Integer = Me.dgdShippingLines.CurrentRow.Index
            Try
                Me.dgdShippingLines.Item("sotien", index).Value = Me.dgdShippingLines.Item("dongia", index).Value * Me.dgdShippingLines.Item("sl", index).Value
                Me.dgdShippingLines.Item("dongia", index).Value = Me.dgdShippingLines.Item("dongia", index).Value
                Me.dgdShippingLines.Item("sl", index).Value = Me.dgdShippingLines.Item("sl", index).Value
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdShippingLines_CellStyleContentChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellStyleContentChangedEventArgs) Handles dgdShippingLines.CellStyleContentChanged
       
    End Sub

    Private Sub dgdShippingLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdShippingLines.CellValueChanged
        Try
            Dim index As Integer = Me.dgdShippingLines.CurrentRow.Index
            Try
                Me.dgdShippingLines.Item("sotien", index).Value = Me.dgdShippingLines.Item("dongia", index).Value * Me.dgdShippingLines.Item("sl", index).Value
                Me.dgdShippingLines.Item("dongia", index).Value = Me.dgdShippingLines.Item("dongia", index).Value
                Me.dgdShippingLines.Item("sl", index).Value = Me.dgdShippingLines.Item("sl", index).Value
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class