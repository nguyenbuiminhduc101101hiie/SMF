Public Class frmBookingReport
    Dim QuyenHan As String
    Dim strUser As String

    Dim index As Integer = 0
    Dim rsCustomerList As New ADODB.Recordset
    Dim mStatus, mFilter, mCommondityStatus, mPICStatus, mSaleStatus, mCusRptStatus As String
    Public blnUpdated As Boolean
    Public mBookingAgentId As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Dim oTableMarket, otableCusID As New DataTable
    Dim oTablePIC As New DataTable
    Dim oTableCommondity As New DataTable
    Dim oTableSaleDetail As New DataTable
    Dim oTableCusReport As New DataTable

    Dim mCustomerCommondity As String
    Dim mCustomerPIC As String
    Dim mSaleID As String
    Dim mCusReportID As String
    ' buyer
    Dim mCusBuyerID As String
    Dim mCusBuyerStatus As String
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer
    Dim Total As Double
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            QueryBookingAgent()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub QueryBookingAgent(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCustomer()
        Else
            strQuery = MakeQueryCustomer(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "CustomerList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdContianerOutboundNotify.DataSource = ds.Tables("CustomerList")
        If Me.dgdContianerOutboundNotify.Enabled = False Then
            Me.dgdContianerOutboundNotify.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default

        '------------vị trí BM
        'If location > 0 And location <= Me.dgdCustomer.Rows.Count And Me.dgdCustomer.Rows.Count > 0 Then
        '    Me.dgdCustomer.Rows(location).Selected = True
        '    Me.dgdCustomer.CurrentCell = Me.dgdCustomer.Rows(location).Cells(2)
        'End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdContianerOutboundNotify)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & ", bạn nên dùng menu View để hiển thị hết toàn bộ thông tin trong Bảng dữ liệu, ")
        'Resume
    End Sub
    Private Function MakeQueryCustomer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        If Me.CHKSOC.Checked = True Then
            If Me.chkall.Checked = True Then
                MakeQueryCustomer = " Select bookingagentid,customerid, nvocc,gmd_noofcontainerorpackage,Remarks_,company,gmd_bookingno,bophan,trangthai,nhanvienchungtu,bookingdate,bookingAgent.editable,bookingAgent.approve,bookingAgent.continued,bookingAgent.dateupdate,bookingAgent.userupdate from bookingAgent left join Customer on BookingAgent.Customerid=customer.customer_id "

                MakeQueryCustomer = MakeQueryCustomer & " WHERE   bookingOffice like '%" & Me.ComboBox1.Text & "%' and "
                '        MakeQueryCustomer = MakeQueryCustomer & ""
                MakeQueryCustomer = MakeQueryCustomer & " bookingagent.Continued = 1  and trangthai='" & Me.cbotrangthai.Text & "' and nvocc=1 "

                If Me.chkall.Checked = True Then

                Else
                    MakeQueryCustomer = MakeQueryCustomer & "   "
                End If
                MakeQueryCustomer = MakeQueryCustomer & " and convert(datetime,BOOKINGDATE) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "'   "

                ' lay so lieu tu Option
            Else
                MakeQueryCustomer = " Select bookingagentid,customerid, nvocc,gmd_noofcontainerorpackage,Remarks_,company,gmd_bookingno,bophan,trangthai,nhanvienchungtu,bookingdate,bookingAgent.editable,bookingAgent.approve,bookingAgent.continued,bookingAgent.dateupdate,bookingAgent.userupdate from bookingAgent left join Customer on BookingAgent.Customerid=customer.customer_id "

                MakeQueryCustomer = MakeQueryCustomer & " WHERE  "
                '        MakeQueryCustomer = MakeQueryCustomer & ""
                MakeQueryCustomer = MakeQueryCustomer & " bookingagent.Continued = 1  and bookingOffice like '%" & Me.ComboBox1.Text & "%' and trangthai='" & Me.cbotrangthai.Text & "' and nvocc=1 "

                If Me.chkall.Checked = True Then

                Else
                    MakeQueryCustomer = MakeQueryCustomer & " and bophan like '%" & Me.ComboBox2.Text & "%'   "
                End If
                MakeQueryCustomer = MakeQueryCustomer & " and convert(datetime,BOOKINGDATE) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "'   "

                ' lay so lieu tu Option
            End If
        End If

        If Me.CHKCOC.Checked = True Then
            If Me.chkall.Checked = True Then
                MakeQueryCustomer = " Select bookingagentid,customerid, nvocc,gmd_noofcontainerorpackage,Remarks_,company,gmd_bookingno,bophan,trangthai,nhanvienchungtu,bookingdate,bookingAgent.editable,bookingAgent.approve,bookingAgent.continued,bookingAgent.dateupdate,bookingAgent.userupdate from bookingAgent left join Customer on BookingAgent.Customerid=customer.customer_id "

                MakeQueryCustomer = MakeQueryCustomer & " WHERE   bookingOffice like '%" & Me.ComboBox1.Text & "%' and "
                '        MakeQueryCustomer = MakeQueryCustomer & ""
                MakeQueryCustomer = MakeQueryCustomer & " bookingagent.Continued = 1  and trangthai='" & Me.cbotrangthai.Text & "' and nvocc=0 "

                If Me.chkall.Checked = True Then

                Else
                    MakeQueryCustomer = MakeQueryCustomer & "   "
                End If
                MakeQueryCustomer = MakeQueryCustomer & " and convert(datetime,BOOKINGDATE) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "'   "

                ' lay so lieu tu Option
            Else
                MakeQueryCustomer = " Select bookingagentid,customerid, nvocc,gmd_noofcontainerorpackage,Remarks_,company,gmd_bookingno,bophan,trangthai,nhanvienchungtu,bookingdate,bookingAgent.editable,bookingAgent.approve,bookingAgent.continued,bookingAgent.dateupdate,bookingAgent.userupdate from bookingAgent left join Customer on BookingAgent.Customerid=customer.customer_id "

                MakeQueryCustomer = MakeQueryCustomer & " WHERE  "
                '        MakeQueryCustomer = MakeQueryCustomer & ""
                MakeQueryCustomer = MakeQueryCustomer & " bookingagent.Continued = 1  and bookingOffice like '%" & Me.ComboBox1.Text & "%' and trangthai='" & Me.cbotrangthai.Text & "' and nvocc=0 "

                If Me.chkall.Checked = True Then

                Else
                    MakeQueryCustomer = MakeQueryCustomer & " and bophan like '%" & Me.ComboBox2.Text & "%'   "
                End If
                MakeQueryCustomer = MakeQueryCustomer & " and convert(datetime,BOOKINGDATE) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "'   "

                ' lay so lieu tu Option
            End If
        End If

        If Me.chlallsoccoc.Checked = True Then
            If Me.chkall.Checked = True Then
                MakeQueryCustomer = " Select bookingagentid,customerid, nvocc,gmd_noofcontainerorpackage,Remarks_,company,gmd_bookingno,bophan,trangthai,nhanvienchungtu,bookingdate,bookingAgent.editable,bookingAgent.approve,bookingAgent.continued,bookingAgent.dateupdate,bookingAgent.userupdate from bookingAgent left join Customer on BookingAgent.Customerid=customer.customer_id "

                MakeQueryCustomer = MakeQueryCustomer & " WHERE   bookingOffice like '%" & Me.ComboBox1.Text & "%' and "
                '        MakeQueryCustomer = MakeQueryCustomer & ""
                MakeQueryCustomer = MakeQueryCustomer & " bookingagent.Continued = 1  and trangthai='" & Me.cbotrangthai.Text & "' "

                If Me.chkall.Checked = True Then

                Else
                    MakeQueryCustomer = MakeQueryCustomer & "   "
                End If
                MakeQueryCustomer = MakeQueryCustomer & " and convert(datetime,BOOKINGDATE) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "'   "

                ' lay so lieu tu Option
            Else
                MakeQueryCustomer = " Select bookingagentid,customerid, nvocc,gmd_noofcontainerorpackage,Remarks_,company,gmd_bookingno,bophan,trangthai,nhanvienchungtu,bookingdate,bookingAgent.editable,bookingAgent.approve,bookingAgent.continued,bookingAgent.dateupdate,bookingAgent.userupdate from bookingAgent left join Customer on BookingAgent.Customerid=customer.customer_id "

                MakeQueryCustomer = MakeQueryCustomer & " WHERE  "
                '        MakeQueryCustomer = MakeQueryCustomer & ""
                MakeQueryCustomer = MakeQueryCustomer & " bookingagent.Continued = 1  and bookingOffice like '%" & Me.ComboBox1.Text & "%' and trangthai='" & Me.cbotrangthai.Text & "' "

                If Me.chkall.Checked = True Then

                Else
                    MakeQueryCustomer = MakeQueryCustomer & " and bophan like '%" & Me.ComboBox2.Text & "%'  "
                End If
                MakeQueryCustomer = MakeQueryCustomer & " and convert(datetime,BOOKINGDATE) between '" & ddMMMyyyy(Me.DateTimePicker1.Value.Date) & "' and '" & ddMMMyyyy(Me.DateTimePicker2.Value.Date) & "'   "

                ' lay so lieu tu Option
            End If
        End If



        Dim strQuery, value As String
        Dim rs As New ADODB.Recordset
        'value = "0"
        'strQuery = "SELECT * "
        'strQuery = strQuery & "FROM [option] "
        'strQuery = strQuery & "WHERE frmName = 'frmListCustomer' and OptionCode='PermissionCustomer' And Continued=1 "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'With rs
        '    If Not rs.EOF Then
        '        value = .Fields("optionvalue").Value
        '    End If

        'End With
        'rs.Close()
        '---------------------------------
        'If value = "1" Then
        '    If UCase(gDepartment) <> "OUTBOUND" And UCase(gDepartment) <> "MANAGEMENT" And UCase(gDepartment) <> "BOOKING" And UCase(gDepartment) <> "ACCOUNT" And UCase(gDepartment) <> "OPERATION" And UCase(gDepartment) <> "SALE MANAGEMENT" Then
        '        MakeQueryCustomer = MakeQueryCustomer & " And gmd_salecode='" & UCase(GETSALECODE(strUser)).Trim & "' and (gmd_branch like '%" & gBranch & "%') "
        '    End If
        'End If

        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCustomer = MakeQueryCustomer & argCriteria
        End If
        'If index = 1 Then ' 
        MakeQueryCustomer = MakeQueryCustomer & " order by convert(datetime,bookingdate) desc "
        'ElseIf index = 15 Then ' 
        '    MakeQueryCustomer = MakeQueryCustomer & strDateOfCustomerOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.dgdContianerOutboundNotify, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class