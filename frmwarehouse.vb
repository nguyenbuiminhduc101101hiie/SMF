Public Class frmwarehouse
    '--service
    Public mDataSetService As DataSet
    Dim con As OleDb.OleDbConnection
    Dim cmdSelect As OleDb.OleDbCommand
    Dim Adapter As OleDb.OleDbDataAdapter
    Private Sub frmSetbalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.dgdShippingLines.AllowUserToAddRows = False
            Dim sql As String
            'sql = "select shippingline from shippingline order by shippingline"
            'Dim ds As New DataSet
            'ds = ReadDataSet(sql)
            'Dim tempdgvCB As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns("carrier"), DataGridViewComboBoxColumn)
            'tempdgvCB.DataSource = ds.Tables(0)
            'tempdgvCB.DisplayMember = "shippingline"
       
            'sql = "select ten from warehouse order by ten"
            'Dim ds As New DataSet
            'ds = ReadDataSet(sql)
            'Dim tempdgvCB As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns("warehouse"), DataGridViewComboBoxColumn)
            'tempdgvCB.DataSource = ds.Tables(0)
            'tempdgvCB.DisplayMember = "warehouse"



            sql = "select usr from userlist order by usr"
            Dim ds1 As New DataSet
            ds1 = ReadDataSet(sql)
            Dim tempdgvCB1 As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns("nhanvien"), DataGridViewComboBoxColumn)
            tempdgvCB1.DataSource = ds1.Tables(0)
            tempdgvCB1.DisplayMember = "usr"
            '  sql = "select TariffSeaFCLID,Destination,POL,MainPorts,Carrier,coLoader,Commodity,sERVICE,gp20,gp40,hc40,rf20,rf40,other,Surcharges,EFFECTIVE,t2,t3,t4,t5,t6,t7,cn,transittime,salesman,dateupdate,userupdate from tariffSeaFCLInbound  order by destination "
            sql = "select id,ten,diachi,dai,rong,cao,chucnang,nhanvien,thuetu,thueden,giatien,ghichu,userupdate,dateupdate from warehouse  order by ten "

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

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("ten", "Name")
            comboSource.Add("dai", "L")
            comboSource.Add("rong", "W")
            comboSource.Add("cao", "H")
            comboSource.Add("diachi", "Address")
            comboSource.Add("ghichu", "Remarks")


            ComboBox1.DataSource = New BindingSource(comboSource, Nothing)
            ComboBox1.DisplayMember = "Value"
            ComboBox1.ValueMember = "Key"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSaveService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveService.Click
        Dim i As Integer
        Dim sql As String
        ' kiem tra phan quyen
        If Not UserRight("frmvung", "Add") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))

            Exit Sub
        Else

        End If
        If Me.dgdShippingLines.RowCount = 0 Then
            Return
        End If
        ' sql = "select TariffSeaFCLID,Destination,POL,MainPorts,Carrier,coLoader,Commodity,sERVICE,gp20,gp40,hc40,rf20,rf40,other,Surcharges,EFFECTIVE,t2,t3,t4,t5,t6,t7,cn,transittime,salesman from tariffSeaFCLinbound "
        sql = "select id,ten,diachi,dai,rong,cao,chucnang,nhanvien,thuetu,thueden,giatien,ghichu,userupdate,dateupdate from warehouse  "

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim sql As String
            Me.dgdShippingLines.AllowUserToAddRows = True
            'Sql = "select shippingline from shippingline order by shippingline"
            'Dim ds As New DataSet
            'ds = ReadDataSet(Sql)
            'Dim tempdgvCB As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns("carrier"), DataGridViewComboBoxColumn)
            'tempdgvCB.DataSource = ds.Tables(0)
            'tempdgvCB.DisplayMember = "shippingline"
            'sql = "select ten from warehouse order by ten"
            'Dim ds As New DataSet
            'ds = ReadDataSet(sql)
            'Dim tempdgvCB As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns("warehouse"), DataGridViewComboBoxColumn)
            'tempdgvCB.DataSource = ds.Tables(0)
            'tempdgvCB.DisplayMember = "warehouse"



            sql = "select usr from userlist order by usr"
            Dim ds1 As New DataSet
            ds1 = ReadDataSet(sql)
            Dim tempdgvCB1 As DataGridViewComboBoxColumn = DirectCast(dgdShippingLines.Columns("nhanvien"), DataGridViewComboBoxColumn)
            tempdgvCB1.DataSource = ds1.Tables(0)
            tempdgvCB1.DisplayMember = "usr"

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Me.dgdShippingLines.AllowUserToAddRows = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Found As Boolean = False
        Dim StringToSearch As String = ""
        Dim ValueToSearchFor As String = Me.TextBox1.Text.Trim.ToLower
        Dim CurrentRowIndex As Integer = 0
        Try
            If Me.dgdShippingLines.Rows.Count = 0 Then
                CurrentRowIndex = 0
            Else
                CurrentRowIndex = dgdShippingLines.CurrentRow.Index + 1
            End If
            If CurrentRowIndex > dgdShippingLines.Rows.Count Then
                CurrentRowIndex = dgdShippingLines.Rows.Count - 1
            End If
            Dim cot, dong As Integer
            dong = 0
            If dgdShippingLines.Rows.Count > 0 Then
                For Each gRow As DataGridViewRow In dgdShippingLines.Rows

                    For cot = 1 To Me.dgdShippingLines.Columns.Count - 1


                        StringToSearch = gRow.Cells(cot).Value.ToString.Trim.ToLower
                        If StringToSearch Like "*" + LCase(Trim(TextBox1.Text)) + "*" Then
                            'Dim myCurrentCell As DataGridViewCell = gRow.Cells(4)
                            'Dim myCurrentPosition As DataGridViewCell = gRow.Cells(0)
                            'dgdShippingLines.CurrentCell = myCurrentCell
                            'CurrentRowIndex = dgdShippingLines.CurrentRow.Index
                            'Found = True
                            Me.dgdShippingLines.Rows(dong).DefaultCellStyle.ForeColor = Color.Red
                            Me.dgdShippingLines.Rows(dong).DefaultCellStyle.BackColor = Color.White
                        End If
                    Next
                    dong += 1
                    If Found Then Exit For
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            frmSetbalance_Load(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim sql As String
            'select id,ten,diachi,dai,rong,cao,chucnang,nhanvien,thuetu,thueden,thueden,giatien,ghichu,userupdate,dateupdate from warehouse  order by ten
            sql = "select id,ten,diachi,dai,rong,cao,chucnang,nhanvien,thuetu,thueden,giatien,ghichu,userupdate,dateupdate from warehouse  where " & DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key & " like '%" & Me.TextBox2.Text & "%' order by ten "
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

    Private Sub RightClickForDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightClickForDetailsToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.dgdShippingLines.CurrentRow.Index
            Me.txtSurcharges.Text = Me.dgdShippingLines.Item("ghichu", index).Value.ToString
            Me.GroupBox1.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try

            Dim index As Integer = Me.dgdShippingLines.CurrentRow.Index
            Me.dgdShippingLines.Item("ghichu", index).Value = Me.txtSurcharges.Text

            Me.dgdShippingLines.Focus()

            Me.cmdSaveService.Focus()
            Me.Button9_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Me.GroupBox1.Visible = False
        Catch ex As Exception

        End Try
    End Sub
End Class