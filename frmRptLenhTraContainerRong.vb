Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmRptLenhTraContainerRong
    Dim otableBill, oTableFreight As DataTable
    Dim oTableAmountContainer As New DataTable

    Sub QueryAmountcontainer()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select container_type,Amount= Count(Container_type) from CargoIb "
        strQuery &= " Where BLIB_ID='" & gBillInboundID & " '"
        strQuery &= " And CargoIb.Continued=1 And Container_type like '%" & IIf(frmEmptyContainer.chkAll.Checked = True, "", frmEmptyContainer.cboContainerType.Text.Trim) & "%' group by Container_type"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableAmountContainer) Then
            oTableAmountContainer.Clear()
        End If
        Adapter.Fill(ds, "AmountContainer")
        oTableAmountContainer = ds.Tables(0)

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryBill()
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select BLIB_NO,VESSEL,VoyAge,Shipper.Shipper_1,Consignee.Consignee_1,Notify.Notify_1  "
        strQuery &= "from (((BillOfLadingIB "
        strQuery &= " LEFT JOIN Shipper On Shipper.Shipper_ID=BillOfLadingIB.Shipper_ID)"
        strQuery &= " LEFT JOIN Consignee On Consignee.Consignee_ID=BillOfLadingIb.Consignee_ID) "
        strQuery &= " LEFT JOIN Notify On Notify.Notify_ID = BillOfLadingIB.Notify_ID) "
        strQuery &= " Where BLIB_ID='"
        strQuery &= gBillInboundID & "' And BillOfLadingIB.Continued=1"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(otableBill) Then
            otableBill.Clear()
        End If
        Adapter.Fill(ds, "CargoDesc")
        otableBill = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub Queryinfo(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select * from EMPTYCONTAINER Where BLIB_NO='"
        strQuery &= gBillNoInBound & "'"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "CargoDesc")
        dt = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Sub QueryCargo(ByRef otable As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Container_No,Container_Type,Seal from (CARGOIB LEFT JOIN Container on CargoIB.CTN_ID=Container.CTN_ID) Where BLIB_ID='"
        strQuery &= gBillInboundID & "' ANd CargoIB.Continued=1 And Container_type like '%" & IIf(frmEmptyContainer.chkAll.Checked = True, "", frmEmptyContainer.cboContainerType.Text.Trim) & "%' Order By Container_type ASC"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(otable) Then
            otable.Clear()
        End If
        Adapter.Fill(ds, "CargoDesc")
        otable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmRptfreightNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        'Dim rpt As New 
        Dim CountContainer As Integer = frmEmptyContainer.dgdContainerNo.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim temp As String
        Dim AttachContainer, BL_NO1, AttachTitle, ToTalAttachContainer As TextObject
        Dim container As TextObject

        If CountContainer = 0 Then
            MsgBox("You must Select The row in the Grid To Print")
            Return
        End If
       
        '-------------
        Dim rpt As New ReportDocument
        Dim strReportName As String
        Dim strQuery As String
        ' ten Report
        strReportName = "ReportLenhTraRong"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rpt.Load(strReportPath)

        QueryBill()

        Dim dt As New DataTable

        Dim Emptyport, Emptyport1, Chu, TenTau, BL_NO, userid As TextObject
        BL_NO = rpt.ReportDefinition.ReportObjects("BL_NO")
        BL_NO.Text = gBillNoInBound
        If otableBill.Rows.Count > 0 Then


            Chu = rpt.ReportDefinition.ReportObjects("Shipper")
            If UCase(ChuHang) = "SHIPPER" Then
                Chu.Text = otableBill.Rows(0).Item("Shipper_1").ToString
            Else
                If UCase(ChuHang) = "CONSIGNEE" Then
                    Chu.Text = otableBill.Rows(0).Item("Consignee_1").ToString
                Else
                    Chu.Text = otableBill.Rows(0).Item("Notify_1").ToString
                End If
            End If
            TenTau = rpt.ReportDefinition.ReportObjects("Vessel")
            TenTau.Text = otableBill.Rows(0).Item("VESSEL").ToString & " - " & otableBill.Rows(0).Item("VoyAge").ToString

        End If
        Queryinfo(dt)
        If dt.Rows.Count > 0 Then

            Emptyport = rpt.ReportDefinition.ReportObjects("EMPTYPORT")
            Emptyport.Text = dt.Rows(0).Item("EMPTYPORT").ToString

            Emptyport1 = rpt.ReportDefinition.ReportObjects("EmptyPort1")
            Emptyport1.Text = Emptyport.Text 'dt.Rows(0).Item("EMPTYPORT").ToString

            Dim ngaycapcang, ngaylayhang, ngayharong As TextObject
            ngaycapcang = rpt.ReportDefinition.ReportObjects("CapNgayCang")
            ngaycapcang.Text = CDate(dt.Rows(0).Item("NGAYCAPCANG").ToString)

            ngaylayhang = rpt.ReportDefinition.ReportObjects("ngaylayhang")
            ngaylayhang.Text = CDate(dt.Rows(0).Item("ngaylayhang").ToString)

            ngayharong = rpt.ReportDefinition.ReportObjects("ngayharong")
            ngayharong.Text = CDate(dt.Rows(0).Item("ngayharong").ToString)

            userid = rpt.ReportDefinition.ReportObjects("txtuser")
            userid.Text = strUserName
        End If

        'QueryCargo(dt)
        'QueryAmountcontainer()
        'Dim amount As TextObject
        'amount = rpt.ReportDefinition.ReportObjects("Amount")
        'amount.Text = dt.Rows.Count & "Containers " &
        'If oTableAmountContainer.Rows.Count > 0 Then
        Dim amount As TextObject
        amount = rpt.ReportDefinition.ReportObjects("Amount")
        amount.Text = " "
        Dim Type(7) As String
        Dim Count As Integer = 0
        Dim Quantity(7) As Double


        For P As Integer = 0 To CountContainer - 1
            Dim index As Integer = frmEmptyContainer.dgdContainerNo.SelectedRows(P).Index
            Dim ContType As String
            ContType = frmEmptyContainer.dgdContainerNo.Item("Container_Type", index).Value.ToString.Trim
            Dim Repeat As Boolean = False
            For T As Integer = 0 To Count - 1
                If UCase(ContType) = UCase(Type(T)) Then
                    Quantity(T) += 1
                    Repeat = True
                    Exit For
                End If
            Next
            If Repeat = False Then
                Type(Count) = ContType
                Quantity(Count) = 1
                Count += 1
            End If
        Next
        'Dim row As DataRow
        For C As Integer = 0 To Count - 1
            amount.Text &= Quantity(C) & " X " & Type(C) & "    "
        Next
        'End If

        'If dt.Rows.Count > 0 Then


        Dim row As DataRow

        Dim i As Integer
        Dim N As Integer = IIf(CountContainer - 1 > 19, 19, CountContainer - 1)
        Dim k As Integer = CountContainer - 1 - N
        'xư ly các contanier nhiều hơn số container giới hiện thi trên bill 
        If k > 0 Then

            Dim strAttachContainer As String = ""
            MsgBox("Lưu ý : mỗi lần in chỉ cho phép tối đa 20 containers!, Bạn đã chọn đến " & CountContainer & " cotainers, vì vậy số containers thứ 21 đến " & CountContainer & " còn lại sẽ không được in ra! ")

            'Return
            'AttachTitle = rpt.ReportDefinition.ReportObjects("attachTitle")
            'AttachTitle.Text = "Attach Container"
            'BL_NO1 = rpt.ReportDefinition.ReportObjects("BL_NO1")
            'BL_NO1.Text = gBillNoInBound

            'ToTalAttachContainer = rpt.ReportDefinition.ReportObjects("ToTalAttachContainer")
            'ToTalAttachContainer.Text = "ToTal :" & k

            'For k = N + 1 To CountContainer - 1
            '    Dim index As Integer = frmEmptyContainer.dgdContainerNo.SelectedRows(k).Index
            '    strAttachContainer &= "(" & k + 1 & ")  " & frmEmptyContainer.dgdContainerNo.Item("ContainerNo", index).Value.ToString.Trim & "  /   " & frmEmptyContainer.dgdContainerNo.Item("Container_Type", index).Value.ToString
            '    strAttachContainer &= "                                                                                     "
            '    'strAttachContainer &= " / " & dt.Rows(k).Item("CTN_SIZE_TYPE").ToString.Trim & " / "
            '    'strAttachContainer &= dt.Rows(k).Item("Seal").ToString.Trim
            'Next
            'AttachContainer = rpt.ReportDefinition.ReportObjects("ContainerAttach")
            'AttachContainer.Text = strAttachContainer
        End If

        If frmEmptyContainer.chkAttachlist.Checked = False Then

            For i = 0 To N
                Dim index As Integer = frmEmptyContainer.dgdContainerNo.SelectedRows(i).Index
                temp = "container" & i + 1
                container = rpt.ReportDefinition.ReportObjects(temp)
                container.Text = frmEmptyContainer.dgdContainerNo.Item("ContainerNo", index).Value.ToString.Trim & "  /   " & frmEmptyContainer.dgdContainerNo.Item("Container_Type", index).Value.ToString
                ' container.Text = 'dt.Rows(i).Item("Container_No") & " / " & dt.Rows(i).Item("Container_Type")
            Next
            'End If
        Else ' chi in chu Attach list trong lenh
            container = rpt.ReportDefinition.ReportObjects("container1")
            container.Text = "See Attach List"



        End If ''' attach list



        Dim dat As Date
        dat = Now
        Dim d, m, y As TextObject
        d = rpt.ReportDefinition.ReportObjects("Day")
        d.Text = dat.Day

        m = rpt.ReportDefinition.ReportObjects("Month")
        m.Text = dat.Month

        y = rpt.ReportDefinition.ReportObjects("Year")
        y.Text = dat.Year
        Me.CrystalReportViewer1.ReportSource = rpt
        'Formatting paper
        Dim mymargins = rpt.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        'rpt.PrintOptions.ApplyPageMargins(mymargins)
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rpt.Refresh()

        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.Show()


        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

End Class