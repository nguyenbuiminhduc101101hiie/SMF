Public Class frmDetailContainerIB

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim sql As String
        Dim ds As New DataSet
        Dim i As Integer
        sql = " select * from containerrepair left join inbound  on inbound.blib_id=containerrepair.inboundid where convert(datetime,eta) between '" & Me.DateTimePicker1.Value.Date & "' and '" & Me.DateTimePicker2.Value.Date & "' order by convert(datetime,sailingdate)"
        ds = ReadDataSet(sql)
        'Me.dgdData.DataSource = ds.Tables(0)
        Me.dgdData.Rows.Clear()
        Dim rowtang As Integer = 0
        Dim j As Integer
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1



                ' ad
                Me.dgdData.Rows.Add(1)
                Me.dgdData.Item("ref", rowtang).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                Me.dgdData.Item("mbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                Me.dgdData.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                Me.dgdData.Item("ETD", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                Me.dgdData.Item("consignee", rowtang).Value = ds.Tables(0).Rows(i).Item("consignee").ToString


                Me.dgdData.Item("containers", rowtang).Value = ds.Tables(0).Rows(i).Item("ContainerNo").ToString
                Me.dgdData.Item("type", rowtang).Value = ds.Tables(0).Rows(i).Item("Containertype").ToString
                Me.dgdData.Item("seal", rowtang).Value = ds.Tables(0).Rows(i).Item("seal").ToString



                Me.dgdData.Item("tongkien", rowtang).Value = ds.Tables(0).Rows(i).Item("sokien").ToString
                Me.dgdData.Item("tongkg", rowtang).Value = ds.Tables(0).Rows(i).Item("sokg").ToString
                Me.dgdData.Item("tongkhoi", rowtang).Value = ds.Tables(0).Rows(i).Item("sokhoi").ToString
                'kiem tra
                If ds.Tables(0).Rows(i).Item("fcl").ToString = "True" Then
                    Me.dgdData.Item("goodstype", rowtang).Value = "FCL"
                End If
                If ds.Tables(0).Rows(i).Item("lcl").ToString = "True" Then
                    Me.dgdData.Item("goodstype", rowtang).Value = "LCL"
                End If
                If ds.Tables(0).Rows(i).Item("air").ToString = "True" Then
                    Me.dgdData.Item("goodstype", rowtang).Value = "AIR"
                End If
                If ds.Tables(0).Rows(i).Item("consol").ToString = "True" Then
                    Me.dgdData.Item("goodstype", rowtang).Value = "Consol"
                End If

                '----------------

                rowtang += 1





            Next

        End If
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

    Private Sub frmDetailContainerIB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDefaultGrid(Me.dgdData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Dim id, value, strSQL As String


        id = "blib_id"
        value = "hbl"
        Me.cboHBL.Items.Clear()
        strSQL = "Select distinct blib_id,hbl,dateupdate From inbound where Continued=1 order by hbl "
        loadDataToObject(Me.cboHBL, strSQL, id, value)

        id = "mbl"
        value = "mbl"
        Me.cboMBL.Items.Clear()
        strSQL = "Select distinct mbl From inbound where Continued=1 order by mbl "
        loadDataToObject(Me.cboMBL, strSQL, id, value)


        id = "ref"
        value = "ref"
        Me.cboref.Items.Clear()
        strSQL = "Select distinct ref From inbound where Continued=1 order by ref "
        loadDataToObject(Me.cboref, strSQL, id, value)





        id = "inboundcontainersid"
        value = "Containerno"
        Me.cbocontainers.Items.Clear()
        strSQL = "Select distinct inboundcontainersid,Containerno From containerrepair order by containerno  "
        loadDataToObject(Me.cbocontainers, strSQL, id, value)




        Me.BackColor = gMaunen
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Me.cboHBL.Text = "" Then
                Exit Sub
            End If
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            sql = "select * from containerrepair left join inbound  on inbound.blib_id=containerrepair.inboundid where hbl like '%" & Me.cboHBL.Text & "%' order by hbl"
            ds = ReadDataSet(sql)
            'Me.dgdData.DataSource = ds.Tables(0)
            Me.dgdData.Rows.Clear()
            Dim rowtang As Integer = 0
            Dim j As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    ' ad
                    Me.dgdData.Rows.Add(1)
                    Me.dgdData.Item("ref", rowtang).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Me.dgdData.Item("mbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    Me.dgdData.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Me.dgdData.Item("ETD", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                    Me.dgdData.Item("consignee", rowtang).Value = ds.Tables(0).Rows(i).Item("consignee").ToString


                    Me.dgdData.Item("containers", rowtang).Value = ds.Tables(0).Rows(i).Item("ContainerNo").ToString
                    Me.dgdData.Item("type", rowtang).Value = ds.Tables(0).Rows(i).Item("Containertype").ToString
                    Me.dgdData.Item("seal", rowtang).Value = ds.Tables(0).Rows(i).Item("seal").ToString



                    Me.dgdData.Item("tongkien", rowtang).Value = ds.Tables(0).Rows(i).Item("sokien").ToString
                    Me.dgdData.Item("tongkg", rowtang).Value = ds.Tables(0).Rows(i).Item("sokg").ToString
                    Me.dgdData.Item("tongkhoi", rowtang).Value = ds.Tables(0).Rows(i).Item("sokhoi").ToString
                    'kiem tra
                    If ds.Tables(0).Rows(i).Item("fcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "FCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("lcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "LCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("air").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "AIR"
                    End If
                    If ds.Tables(0).Rows(i).Item("consol").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "Consol"
                    End If

                    '----------------

                    rowtang += 1





                Next

            End If
            InsertAutoNumberToGrid(Me.dgdData)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If Me.cboMBL.Text = "" Then
                Exit Sub
            End If
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            sql = " select * from containerrepair left join inbound  on inbound.blib_id=containerrepair.inboundid where mbl LIKE '%" & Me.cboMBL.Text & "%' order by mbl"
            ds = ReadDataSet(sql)
            'Me.dgdData.DataSource = ds.Tables(0)
            Me.dgdData.Rows.Clear()
            Dim rowtang As Integer = 0
            Dim j As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    ' ad
                    Me.dgdData.Rows.Add(1)
                    Me.dgdData.Item("ref", rowtang).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Me.dgdData.Item("mbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    Me.dgdData.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Me.dgdData.Item("ETD", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                    Me.dgdData.Item("consignee", rowtang).Value = ds.Tables(0).Rows(i).Item("consignee").ToString


                    Me.dgdData.Item("containers", rowtang).Value = ds.Tables(0).Rows(i).Item("ContainerNo").ToString
                    Me.dgdData.Item("type", rowtang).Value = ds.Tables(0).Rows(i).Item("Containertype").ToString
                    Me.dgdData.Item("seal", rowtang).Value = ds.Tables(0).Rows(i).Item("seal").ToString



                    Me.dgdData.Item("tongkien", rowtang).Value = ds.Tables(0).Rows(i).Item("sokien").ToString
                    Me.dgdData.Item("tongkg", rowtang).Value = ds.Tables(0).Rows(i).Item("sokg").ToString
                    Me.dgdData.Item("tongkhoi", rowtang).Value = ds.Tables(0).Rows(i).Item("sokhoi").ToString
                    'kiem tra
                    If ds.Tables(0).Rows(i).Item("fcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "FCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("lcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "LCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("air").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "AIR"
                    End If
                    If ds.Tables(0).Rows(i).Item("consol").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "Consol"
                    End If

                    '----------------

                    rowtang += 1





                Next

            End If
            InsertAutoNumberToGrid(Me.dgdData)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Me.dgdData.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.dgdData, Me)
            'SetMenu(True)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If Me.cbocontainers.Text = "" Then
                Exit Sub
            End If
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            sql = " select * from containerrepair left join inbound  on inbound.blib_id=containerrepair.inboundid where containerno like '%" & Me.cbocontainers.Text & "%' order by containerno "
            ds = ReadDataSet(sql)
            'Me.dgdData.DataSource = ds.Tables(0)
            Me.dgdData.Rows.Clear()
            Dim rowtang As Integer = 0
            Dim j As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    ' ad
                    Me.dgdData.Rows.Add(1)
                    Me.dgdData.Item("ref", rowtang).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Me.dgdData.Item("mbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    Me.dgdData.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Me.dgdData.Item("ETD", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                    Me.dgdData.Item("consignee", rowtang).Value = ds.Tables(0).Rows(i).Item("consignee").ToString


                    Me.dgdData.Item("containers", rowtang).Value = ds.Tables(0).Rows(i).Item("ContainerNo").ToString
                    Me.dgdData.Item("type", rowtang).Value = ds.Tables(0).Rows(i).Item("Containertype").ToString
                    Me.dgdData.Item("seal", rowtang).Value = ds.Tables(0).Rows(i).Item("seal").ToString



                    Me.dgdData.Item("tongkien", rowtang).Value = ds.Tables(0).Rows(i).Item("sokien").ToString
                    Me.dgdData.Item("tongkg", rowtang).Value = ds.Tables(0).Rows(i).Item("sokg").ToString
                    Me.dgdData.Item("tongkhoi", rowtang).Value = ds.Tables(0).Rows(i).Item("sokhoi").ToString
                    'kiem tra
                    If ds.Tables(0).Rows(i).Item("fcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "FCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("lcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "LCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("air").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "AIR"
                    End If
                    If ds.Tables(0).Rows(i).Item("consol").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "Consol"
                    End If

                    '----------------

                    rowtang += 1





                Next

            End If
            InsertAutoNumberToGrid(Me.dgdData)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If Me.cboref.Text = "" Then
                Exit Sub
            End If
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            sql = "select * from containerrepair left join inbound  on inbound.blib_id=containerrepair.inboundid where ref like '%" & Me.cboref.Text & "%' order by ref"
            ds = ReadDataSet(sql)
            'Me.dgdData.DataSource = ds.Tables(0)
            Me.dgdData.Rows.Clear()
            Dim rowtang As Integer = 0
            Dim j As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    ' ad
                    Me.dgdData.Rows.Add(1)
                    Me.dgdData.Item("ref", rowtang).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Me.dgdData.Item("mbl", rowtang).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    Me.dgdData.Item("hbl", rowtang).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Me.dgdData.Item("ETD", rowtang).Value = ds.Tables(0).Rows(i).Item("eta").ToString
                    Me.dgdData.Item("consignee", rowtang).Value = ds.Tables(0).Rows(i).Item("consignee").ToString


                    Me.dgdData.Item("containers", rowtang).Value = ds.Tables(0).Rows(i).Item("ContainerNo").ToString
                    Me.dgdData.Item("type", rowtang).Value = ds.Tables(0).Rows(i).Item("Containertype").ToString
                    Me.dgdData.Item("seal", rowtang).Value = ds.Tables(0).Rows(i).Item("seal").ToString



                    Me.dgdData.Item("tongkien", rowtang).Value = ds.Tables(0).Rows(i).Item("sokien").ToString
                    Me.dgdData.Item("tongkg", rowtang).Value = ds.Tables(0).Rows(i).Item("sokg").ToString
                    Me.dgdData.Item("tongkhoi", rowtang).Value = ds.Tables(0).Rows(i).Item("sokhoi").ToString
                    'kiem tra
                    If ds.Tables(0).Rows(i).Item("fcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "FCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("lcl").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "LCL"
                    End If
                    If ds.Tables(0).Rows(i).Item("air").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "AIR"
                    End If
                    If ds.Tables(0).Rows(i).Item("consol").ToString = "True" Then
                        Me.dgdData.Item("goodstype", rowtang).Value = "Consol"
                    End If

                    '----------------

                    rowtang += 1





                Next

            End If
            InsertAutoNumberToGrid(Me.dgdData)
        Catch ex As Exception

        End Try
    End Sub
End Class