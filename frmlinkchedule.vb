Imports System.Windows.Forms.DateTimePicker
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Net.WebRequest
Imports System.Net.WebClient
Imports System.Net
Imports System.IO
Public Class frmlinkchedule
    '--service
    Public mDataSetService As DataSet
    Dim con As OleDb.OleDbConnection
    Dim cmdSelect As OleDb.OleDbCommand
    Dim Adapter As OleDb.OleDbDataAdapter
    Private Sub frmSetbalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim sql As String
            sql = "select * from linkSchedule where remarks like '%" & Me.txtremarks.Text & "%' "
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
            sql = "select shippingline from shippingline order by shippingline"
            Dim ds As New DataSet
            ds = ReadDataSet(sql)
            Dim tempdgvCB As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns(3), DataGridViewComboBoxColumn)
            tempdgvCB.DataSource = ds.Tables(0)
            tempdgvCB.DisplayMember = "shippingline"
            ' CType(Me.dgdShippingLines.Columns(3), DataGridViewComboBoxColumn).DataSource = ds.Tables(0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSaveService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveService.Click
        Dim i As Integer
        Dim sql As String
        If Me.dgdShippingLines.RowCount = 0 Then
            Return
        End If
        sql = "select * from linkSchedule where remarks like '%" & Me.txtremarks.Text & "%' "
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Me.dgdShippingLines.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.dgdShippingLines, Me)
            'SetMenu(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DownloadFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadFileToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdShippingLines.CurrentRow.Index
            Dim tenfile As String
            Dim path As String
            path = getOptionValue("frm", "SchedulePath", "SchedulePath", "SchedulePath", "C")
            If index >= 0 Then

                tenfile = path + Me.dgdShippingLines.Item("file", index).Value.ToString
                Try
                    Process.Start("""" & tenfile & """")
                Catch
                    MessageBox.Show("No application is set up for this file. Please go to option settings and choose an editor for this file.", "No Default Application")
                End Try

                '
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try

            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtSFileName.Text = Me.OpenFileDialog1.FileName
            End If
            If Me.txtSFileName.Text = "" Then
                DisplayMessage(True, "Please input file path.")
                Me.txtSFileName.Focus()
                Exit Sub
            End If
            'lay so lieu tu Option
            Dim value As String
            Dim strQuery As String

            Dim rsO As New ADODB.Recordset
            value = "0"
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [option] "
            strQuery = strQuery & "WHERE frmName = 'frm' and OptionCode='PicturePath' And Continued=1 "
            rsO.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rsO
                If Not rsO.EOF Then
                    value = .Fields("optionvalue").Value
                End If

            End With
            rsO.Close()
            ''---------------------------------
            Dim values() As String
            values = value.Split(";")
            Dim user, pass, ftp As String
            user = values(1)
            pass = values(2)
            ftp = values(3)


            Try
                Dim fileName As String = Me.txtSFileName.Text
                Dim toUpload As New FileInfo(fileName)
                Dim client As New WebClient
                ' lay username va pass

                Dim nc As New NetworkCredential(user, pass)

                Dim addy As Uri
                addy = New Uri(ftp & toUpload.Name.ToString())


                client.Credentials = nc
                Try
                    Dim arrReturn As Byte() = client.UploadFile(addy.ToString(), fileName) '//This Line Throwing error
                    MessageBox.Show("File Uploaded Sucessfully")
                    Me.cboduongdan.Text = toUpload.Name.ToString()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CopyFromPathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromPathToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdShippingLines.CurrentRow.Index
            Dim tenfile As String
            Dim path As String
            ' path = getOptionValue("frm", "SchedulePath", "SchedulePath", "SchedulePath", "C")
            If index >= 0 Then

                Me.dgdShippingLines.Item("file", index).Value = Me.cboduongdan.Text
               

                '
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim sql As String
            sql = "select * from linkSchedule where remarks like '%" & Me.txtremarks.Text & "%' "
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

    Private Sub dgdShippingLines_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdShippingLines.CellContentClick

    End Sub
  
End Class