Public Class frmHouseProfitLoss

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim iuser As Integer
            Dim id, value, strSQL As String
            Me.cboMBL.Text = ""
            Me.cboMBL.Items.Clear()
            id = "blob_id"
            value = "mblmawb"
            ' 
            If gDepartment = "Sale" Then

                strSQL = "Select distinct blob_id,mblmawb From outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1 and salecode='" & strUserId & "' and branch like '%" & gBranch & "%'"
                loadDataToObject(Me.cboMBL, strSQL, id, value)
                Me.cboMBL.Enabled = True
            ElseIf gDepartment = "SaleManager" Then
                ' lay user
                ' luu y usrluon luon= salecode thi moi dung
                Dim sqluser As String
                Dim dsuser As New DataSet
                strSQL = "Select distinct blob_id,mblmawb From outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1 and  branch like '%" & gBranch & "%'"

                sqluser = "select * from userlist where manager1='" & strUserId & "' "

                dsuser = ReadDataSet(sqluser)
                If dsuser.Tables(0).Rows.Count > 0 Then
                    If dsuser.Tables(0).Rows.Count > 1 Then
                        For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                            If iuser = 0 Then
                                strSQL += " and (salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                            Else
                                strSQL += " or salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                            End If



                        Next
                    Else
                        For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                            strSQL += " and (salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                        Next
                    End If

                End If
                strSQL += ")"

                loadDataToObject(Me.cboMBL, strSQL, id, value)
                Me.cboMBL.Enabled = True
            Else
                If gDepartment = "CUSTOMER" Then
                    strSQL = "Select distinct blob_id,mblmawb From outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1  and branch like '%" & gBranch & "%' and userupdate ='" & strUserId & "'"
                    loadDataToObject(Me.cboMBL, strSQL, id, value)
                    Me.cboMBL.Enabled = True
                Else
                    strSQL = "Select distinct blob_id,mblmawb From outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and Continued=1  and branch like '%" & gBranch & "%' "
                    loadDataToObject(Me.cboMBL, strSQL, id, value)
                    Me.cboMBL.Enabled = True
                End If

                ' Me.cboMBL.Enabled = False
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim iuser As Integer
            Dim id, value, strSQL As String
            Me.cbohblIn.Text = ""
            Me.cbohblIn.Items.Clear()
            id = "blib_id"
            value = "hbl"
            ' 
            If gDepartment = "Sale" Then

                strSQL = "Select distinct blib_id,hbl From inbound where convert(datetime,datereport) between '" & Me.dtpin1.Value.Date & "' and '" & Me.dtpin2.Value.Date & "' and Continued=1 and salecode='" & strUserId & "' and branch like '%" & gBranch & "%'"
                loadDataToObject(Me.cbohblIn, strSQL, id, value)
                Me.cbohblIn.Enabled = True
            ElseIf gDepartment = "SaleManager" Then
                ' lay user
                ' luu y usrluon luon= salecode thi moi dung
                Dim sqluser As String
                Dim dsuser As New DataSet
                strSQL = "Select distinct blib_id,hbl From inbound where convert(datetime,datereport) between '" & Me.dtpin1.Value.Date & "' and '" & Me.dtpin2.Value.Date & "' and Continued=1 and  branch like '%" & gBranch & "%'"

                sqluser = "select * from userlist where manager1='" & strUserId & "' "

                dsuser = ReadDataSet(sqluser)
                If dsuser.Tables(0).Rows.Count > 0 Then
                    If dsuser.Tables(0).Rows.Count > 1 Then
                        For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                            If iuser = 0 Then
                                strSQL += " and (salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                            Else
                                strSQL += " or salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                            End If



                        Next
                    Else
                        For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                            strSQL += " and (salecode = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                        Next
                    End If

                End If
                strSQL += ")"

                loadDataToObject(Me.cbohblIn, strSQL, id, value)
                Me.cbohblIn.Enabled = True
            Else
                If gDepartment = "CUSTOMER" Then
                    strSQL = "Select distinct blib_id,hbl From inbound where convert(datetime,datereport) between '" & Me.dtpin1.Value.Date & "' and '" & Me.dtpin2.Value.Date & "' and Continued=1  and branch like '%" & gBranch & "%' and userupdate ='" & strUserId & "'"
                    loadDataToObject(Me.cbohblIn, strSQL, id, value)
                    Me.cbohblIn.Enabled = True
                Else
                    strSQL = "Select distinct blib_id,hbl From inbound where convert(datetime,datereport) between '" & Me.dtpin1.Value.Date & "' and '" & Me.dtpin2.Value.Date & "' and Continued=1  and branch like '%" & gBranch & "%' "
                    loadDataToObject(Me.cbohblIn, strSQL, id, value)
                    Me.cbohblIn.Enabled = True
                End If

                ' Me.cboMBL.Enabled = False
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' xuat
            gHouseProfitLossOutbound = FindValueID(Me.cboMBL, Me.cboMBL.Text)
            reportProfitLossOutbound.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            ' xuat
            gHouseProfitLossInbound = FindValueID(Me.cbohblIn, Me.cbohblIn.Text)
            reportProfitLoss.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Me.Close()
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