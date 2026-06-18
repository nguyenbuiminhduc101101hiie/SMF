Imports System.Globalization
Public Class frmListCargoIBEDI

    Dim mStatus, mStatusp As String
    Dim mCargoIBEDI_ID, CtainerID, BillID, FreightChargeID As String
    Dim oTableDetailBillOfLading, oTablePrice As DataTable
    Public Transit As Integer
    Dim load As Boolean
    Dim mFilter As String

    Const strDetailBILLOFLADINGIBEDISelect As String = "SELECT DISTINCT CargoIBEDI.BLIB_Id, BILLOFLADINGIBEDI.BLIB_NO as BLIB_No, CargoIBEDI.CargoIBEDI_ID," & _
           "Container.Container_No,CTN_SIZE_TYPE,CargoIBEDI.SEAL,CargoIBEDI.Amount,CargoIBEDI.KIND,CargoIBEDI.GrossWeight,CargoIBEDI.GrossUnit," & _
           "CargoIBEDI.Meas,CargoIBEDI.MeasUnit,CargoIBEDI.RECEIVEDATE,CargoIBEDI.WEEK,CARRIERKIND,Note,RECEIVEKIND," & _
           "CargoIBEDI.STT,CargoIBEDI.Continued, " & _
           "CargoIBEDI.Editable, " & _
           "CargoIBEDI.Approve, " & _
           "CargoIBEDI.UserId, " & _
           "CargoIBEDI.Updatetime "
    Const strDetailBillOfLadingOrder1 As String = _
             " ORDER BY BLIB_NO ,CargoIBEDI.STT  "
    Const strDetailBillOfLadingOrder2 As String = _
        " ORDER BY CargoIBEDI.UpdateTime,CargoIBEDI.STT  "

    Const strPriceSelect As String = "SELECT DISTINCT " & _
" FREIGHT_CHARGE_IBEDI.FREIGHT_CHARGE_IBEDI as FREIGHT_CHARGES_ID, FREIGHT_CHARGE_IBEDI.BLIB_ID, " & _
"FREIGHT_CHARGE_IBEDI.Currency as Currency, " & _
                " FREIGHT_CHARGE_IBEDI.PrePaid_Collect, Items," & _
          " CONTAINER_TYPE as CONTAINERTYPE,UnitPrice,POP_Code, " & _
           "FREIGHT_CHARGE_IBEDI.Continued, " & _
           "FREIGHT_CHARGE_IBEDI.Editable, " & _
          "FREIGHT_CHARGE_IBEDI.Approve, " & _
          "FREIGHT_CHARGE_IBEDI.UserId, " & _
          "FREIGHT_CHARGE_IBEDI.Updatetime "

    Const strPriceOrder As String = _
        " ORDER BY FREIGHT_CHARGE_IBEDI.UpdateTime Desc "

    Sub QueryBill_NO()
        On Error GoTo Err_Renamed

        Dim id As String = "BLIB_ID"
        Dim value As String = "BLIB_No"
        On Error GoTo Err_Renamed
        Dim strSQL As String

        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select BLIB_ID ,BLIB_No From BILLOFLADINGIBEDI where Continued=1 And Transit=" & Transit & " Order By BLIB_NO desc"
        loadDataToObject(Me.cboBillofLading, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryContainerNO()
        On Error GoTo Err_Renamed

        Dim id As String = "CTN_ID"
        Dim value As String = "CONTAINER_NO"
        Dim strSQL As String
        strSQL = "Select CTN_ID,CONTAINER_NO From Container Where Continued=1 Order By Updatetime Desc"
        loadDataToObject(Me.cboCTN_NO, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub Queryport(ByRef Cbo As Object, Optional ByVal id As String = "Port_ID", Optional ByVal value As String = "Port_Code", Optional ByVal rang As String = "")
        On Error GoTo Err_Renamed
        'Dim strSQL As String
        'strSQL = "Select Port_Code,Port_ID From Port where Continued=1 And Port_Code like '%" & rang & "%'Order By Port_Code desc"
        'loadDataToObject(Cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryItems()
        On Error GoTo ERR_NAMED
        'Dim id As String = "CHARGE_ID"
        'Dim value As String = "CHARGE_CODE"
        'Dim strQuery As String = "Select CHARGE_ID,CHARGE_CODE from CHARGE where CONTINUED=1"
        'loadDataToObject(Me.txtItems, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryContainer()
        On Error GoTo Err_Renamed
        Dim id As String = "BLIB_ID"
        Dim value As String = "Container_TYPE"
        If Me.cboBillofLading.Items.Count = 0 Then
            Return
        End If
        Dim strSQL As String
        strSQL = "Select DISTINCT BLIB_ID,Container_TYPE From CargoIBEDI Where Continued=1 "
        strSQL &= " And BLIB_ID='" & BillID & "' Order By Container_TYPE Desc"
        loadDataToObject(Me.cboContainerType, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Function MakeQueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryDetailBillOfLading = strDetailBILLOFLADINGIBEDISelect
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " FROM ((CargoIBEDI LEFT JOIN Container On CargoIBEDI.CTN_ID=Container.CTN_ID) "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN BILLOFLADINGIBEDI On CargoIBEDI.BLIB_ID=BILLOFLADINGIBEDI.BLIB_ID) "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " Where (CargoIBEDI.BLIB_ID = '" & DefaultValue & "') "

        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "OR ("
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "CargoIBEDI.Continued = 1 "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & ") And Transit=" & Transit & "  "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & strDetailBillOfLadingOrder1
        ElseIf index = 14 Then ' 
            MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & strDetailBillOfLadingOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Function MakeQueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed
        'BillID = "{" + BillID + "}"
        MakeQueryPrice = strPriceSelect

        MakeQueryPrice = MakeQueryPrice & " FROM FREIGHT_CHARGE_IBEDI  "
        MakeQueryPrice = MakeQueryPrice & "WHERE ((FREIGHT_CHARGE_IBEDI.BLIB_Id = '" & BillID & "') "

        MakeQueryPrice = MakeQueryPrice & "And ("
        MakeQueryPrice = MakeQueryPrice & " FREIGHT_CHARGE_IBEDI.Continued = 1 "
        MakeQueryPrice = MakeQueryPrice & "))"
        If argCriteria <> "" Then
            MakeQueryPrice = MakeQueryPrice & argCriteria
        End If
        MakeQueryPrice = MakeQueryPrice & strPriceOrder

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub QueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        If Me.cboBillofLading.Items.Count = 0 Then
            Return
        End If
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPrice()
        Else
            strQuery = MakeQueryPrice(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTablePrice) Then
            oTablePrice.Clear()
        End If
        Me.dgdPrice.Columns.Item("FREIGHT_CHARGES_ID").Visible = False
        Adapter.Fill(ds, "PriceList")
        oTablePrice = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPrice.DataSource = ds.Tables("PriceList")
        If Me.dgdPrice.Enabled = False Then
            Me.dgdPrice.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        'If oTablePrice.Rows.Count > 0 Then
        '    Me.dgdPrice.Columns.Item("BillOfLadingId").ToolTipText = "Hiện có:" + CStr(Me.dgdPrice.RowCount()) + " Prices."
        'End If
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdPrice.Rows.Count And Me.dgdPrice.Rows.Count > 0 Then
            Me.dgdPrice.Rows(location).Selected = True
        End If
        InsertAutoNumberToGrid(Me.dgdPrice)
        '--------------------
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub QueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryDetailBillOfLading()
        Else
            strQuery = MakeQueryDetailBillOfLading(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableDetailBillOfLading) Then
            oTableDetailBillOfLading.Clear()
        End If
        Adapter.Fill(ds, "DetailBillOfLadingList")
        oTableDetailBillOfLading = ds.Tables(0)
        'hien thi ra grid 


        Me.dgdDetailBillOfLading.DataSource = ds.Tables("DetailBillOfLadingList")
        If Me.dgdDetailBillOfLading.Enabled = False Then
            Me.dgdDetailBillOfLading.Enabled = True
        End If


        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableDetailBillOfLading.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading.Columns.Item("Bill_no").ToolTipText = "Hiện có:" + CStr(Me.dgdDetailBillOfLading.RowCount()) + " Containers."
            SetMenu(True)
        End If
        Me.txtTotalGrossW.Text = FormatString(totalGross())
        Me.txtTotalPackage.Text = FormatString(totalPackage())
        Me.txtTotalVolime.Text = FormatString(totalVolume())
        'If Me.dgdDetailBillOfLading.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        'End If 
        '------------vị trí BM
        If location > 0 And location <= Me.dgdDetailBillOfLading.Rows.Count And Me.dgdDetailBillOfLading.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading.Rows(location).Selected = True
            Me.dgdDetailBillOfLading.CurrentCell = Me.dgdDetailBillOfLading.Rows(location).Cells(2)
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading)
        Me.UpdateFrame()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Public Function totalGross() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading) Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                total = total + IIf(Len(oTableDetailBillOfLading.Rows(i).Item("GrossWeight").ToString.Trim) <= 0, 0, oTableDetailBillOfLading.Rows(i).Item("GrossWeight"))
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Public Function totalVolume() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading) Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                total = total + IIf(oTableDetailBillOfLading.Rows(i).Item("MEAS").ToString.Trim.Length <= 0, 0, oTableDetailBillOfLading.Rows(i).Item("MEAS"))
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Public Function totalPackage() As Integer
        On Error GoTo Err_Renamed
        Dim i, total As Integer
        total = 0
        If Not IsNothing(oTableDetailBillOfLading) Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                total = total + IIf(oTableDetailBillOfLading.Rows(i).Item("Amount").ToString.Trim.Length <= 0, 0, oTableDetailBillOfLading.Rows(i).Item("Amount"))
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.smnuInsert.Enabled = argVisible
        Me.smnuEdit.Enabled = argVisible
        Me.smnuDelete.Enabled = argVisible
        Me.smnuDisplay.Enabled = argVisible
        Me.smnuExit.Enabled = argVisible
        Me.smnuExportExcel.Enabled = argVisible
        Me.smnuSearch.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed
        Me.dgdDetailBillOfLading.Columns.Item("CargoIBEDI_Id").Visible = False

        Me.dgdDetailBillOfLading.Columns.Item("Container_NO").Visible = Me.smnuDisplayContainersId.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Seal").Visible = Me.smnuDisplaySealNo.Checked
        Me.dgdDetailBillOfLading.Columns.Item("ContainerType").Visible = Me.smnuDisplayContainerType.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Amount").Visible = Me.smnuDisplayAmount.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Kind").Visible = Me.smnuDisplayKind.Checked
        Me.dgdDetailBillOfLading.Columns.Item("GrossWEIGHT").Visible = Me.smnuDisplayGross.Checked
        Me.dgdDetailBillOfLading.Columns.Item("GrossUnit").Visible = Me.smnuDisplayUnitGross.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Meas").Visible = Me.smnuDisplayMeas.Checked
        Me.dgdDetailBillOfLading.Columns.Item("MeasUNIT").Visible = Me.smnuDisplayUnitMeas.Checked
        Me.dgdDetailBillOfLading.Columns.Item("RECEIVEDATE").Visible = Me.smnuDisplayReceiveDate.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Week").Visible = Me.smnuDisplayWeek.Checked
        Me.dgdDetailBillOfLading.Columns.Item("CARRIERKIND").Visible = Me.smnuDisplayCarrierKind.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Note").Visible = Me.smnuDisplayNote.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        Me.dgdDetailBillOfLading.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdDetailBillOfLading.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        '''''''''''''''''''''''''''''''''''''''''''''''''

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        Me.cboCTN_NO.Text = Me.dgdDetailBillOfLading.Item("Container_NO", index).Value.ToString.Trim
        Me.txtSealNo.Text = Me.dgdDetailBillOfLading.Item("Seal", index).Value.ToString.Trim
        Me.txtContainerType.Text = Me.dgdDetailBillOfLading.Item("ContainerType", index).Value.ToString.Trim
        Me.txtAmount.Text = Me.dgdDetailBillOfLading.Item("Amount", index).Value.ToString.Trim

        kind = Me.dgdDetailBillOfLading.Item("Kind", index).Value.ToString.Trim
        If kind = "Package" Or kind Like "Carton*" Or kind = "Drum" Or kind = "Unit" Or kind = "Bag" Then
            Me.chkStandard.Checked = True
            Me.cboKind.Text = kind
        Else
            Me.chkOther.Checked = True
            Me.txtKind.Text = kind
        End If
        Me.txtReceiVeKind.Text = Me.dgdDetailBillOfLading.Item("RECEIVEKIND", index).Value.ToString.Trim
        Me.txtCarrierKind.Text = Me.dgdDetailBillOfLading.Item("CARRIERKIND", index).Value.ToString.Trim
        Me.txtGross.Text = Me.dgdDetailBillOfLading.Item("GrossWeight", index).Value.ToString.Trim
        Me.cboUnitGross.Text = Me.dgdDetailBillOfLading.Item("GrossUnit", index).Value.ToString.Trim
        Me.txtMeas.Text = Me.dgdDetailBillOfLading.Item("Meas", index).Value.ToString.Trim
        Me.cboUnitVolume.Text = Me.dgdDetailBillOfLading.Item("MeasUnit", index).Value.ToString.Trim
        Me.DateTimePicker.Text = Me.dgdDetailBillOfLading.Item("ReceiveDate", index).Value.ToString.Trim
        Me.txtWeek.Text = Me.dgdDetailBillOfLading.Item("Week", index).Value.ToString.Trim

        Me.txtNote.Text = Me.dgdDetailBillOfLading.Item("Note", index).Value.ToString.Trim
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & "RefreshData")
    End Sub

    Private Sub frmListCargoIBEDI_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        On Error GoTo Err
        Exit Sub
        'ReFormat()
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCargoIBEDI_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error GoTo Err
        Exit Sub
        'ReFormat()
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCargoIBEDI_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed


        objUserSetting.SetCParm("frmListCargoIBEDI.txtFCommodity", Me.txtSHIPPERNAME.Text)
        '-------------
        objUserSetting.SetCParm("frmListCargoIBEDI.txtContainerNo", Me.cboCTN_NO.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.txtSealNo", Me.txtSealNo.Text)

        objUserSetting.SetCParm("frmListCargoIBEDI.cboContainerType", Me.txtContainerType.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.txtAmount", Me.txtAmount.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.txtkind", Me.txtKind.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.cboKind", Me.cboKind.Text)

        objUserSetting.SetCParm("frmListCargoIBEDI.txtGross", Me.txtGross.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.cboUnitGross", Me.cboUnitGross.Text)

        objUserSetting.SetCParm("frmListCargoIBEDI.txtMeas", Me.txtMeas.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.cboUnitVolume", Me.cboUnitVolume.Text)
        objUserSetting.SetCParm("frmListCargoIBEDI.txtWeek", Me.txtWeek.Text)

        objUserSetting.SetCParm("frmListCargoIBEDI.txtNote", Me.txtNote.Text)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayAmount", Me.smnuDisplayAmount.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        'objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayBillOfLading", Me.smnuDisplayBillOfLading.Checked)


        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayContainersId", Me.smnuDisplayContainersId.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayContainerType", Me.smnuDisplayContainerType.Checked)

        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayGross", Me.smnuDisplayGross.Checked)

        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayKind", Me.smnuDisplayKind.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayMeas", Me.smnuDisplayMeas.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayNote", Me.smnuDisplayNote.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayReceiveDate", Me.smnuDisplayReceiveDate.Checked)

        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplaySealNo", Me.smnuDisplaySealNo.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayUnitGross", Me.smnuDisplayUnitGross.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayUnitMeas", Me.smnuDisplayUnitMeas.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayWeek", Me.smnuDisplayWeek.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListCargoIBEDI.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCargoIBEDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mStatusp = "Normal"
        load = True
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        SetDefaultGrid(Me.dgdDetailBillOfLading, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdPrice, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        ''-------------CboKind
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "PACKAGE", "PACKAGE")
        Me.cboKind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "CARTONS", "CARTONS")
        Me.cboKind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "DRUM", "DRUM")
        Me.cboKind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "UNIT", "UNIT")
        Me.cboKind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "BAG", "BAG")
        Me.cboKind.Items.Add(oItems)
        ''-------------
        ''-----Gross weight

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Kgs", "Kgs")
        Me.cboUnitGross.Items.Add(oItems)
        '--------------Meas
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "CBM", "CBM")
        Me.cboUnitVolume.Items.Add(oItems)

        QueryBill_NO()

        QueryContainerNO()

        'QueryDetailBillOfLading()

        Me.txtSHIPPERNAME.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtFCommodity")
        '-------------
        Me.cboCTN_NO.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtContainerNo")
        Me.txtSealNo.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtSealNo")

        Me.txtContainerType.Text = objUserSetting.GetCParm("frmListCargoIBEDI.cboContainerType")
        Me.txtAmount.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtAmount")
        Me.txtKind.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtkind")
        Me.cboKind.Text = objUserSetting.GetCParm("frmListCargoIBEDI.cboKind")

        Me.txtGross.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtGross")
        Me.cboUnitGross.Text = objUserSetting.GetCParm("frmListCargoIBEDI.cboUnitGross")


        Me.txtMeas.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtMeas")
        Me.cboUnitVolume.Text = objUserSetting.GetCParm("frmListCargoIBEDI.cboUnitVolume")
        Me.txtWeek.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtWeek")

        Me.txtNote.Text = objUserSetting.GetCParm("frmListCargoIBEDI.txtNote")


        Me.smnuDisplayAmount.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayAmount")
        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayApprove")
        ' Me.smnuDisplayBillOfLading.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayBillOfLading")
        Me.smnuDisplayContainersId.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayContainersId")
        Me.smnuDisplayContainerType.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayContainerType")

        Me.smnuDisplayGross.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayGross")

        Me.smnuDisplayKind.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayKind")
        Me.smnuDisplayMeas.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayMeas")
        Me.smnuDisplayNote.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayNote")
        Me.smnuDisplayReceiveDate.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayReceiveDate")
        Me.smnuDisplaySealNo.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplaySealNo")
        Me.smnuDisplayUnitGross.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayUnitGross")
        Me.smnuDisplayUnitMeas.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayUnitMeas")
        Me.smnuDisplayWeek.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayWeek")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListCargoIBEDI.smnuDisplayUpdateTime")

        ReFormat()
        UpdateFrame()

        Me.Cursor = Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(tabcargo.Visible, 540, 540)) Then
        '    Me.Height = IIf(tabcargo.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If 
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0

        Me.Width = frmMain.Width - 8
        Me.Height = frmMain.Height - 10 - Me.Top
        'Me.fraTotal.Left = Me.Width - fraTotal.Width - 20

        'MsgBox(Me.Width)
        'If Me.Width > 800 Then
        '    Me.Height = frmMain.Height - 10 - Me.Top
        '    dgdDetailBillOfLading.Height = Me.Height - 60 - IIf(TabCargo.Visible, 100 + TabCargo.Height + 110, 40) '> 7000
        'Else
        '    Me.Height = frmMain.Height - 10 - Me.Top
        '    dgdDetailBillOfLading.Height = Me.Height - 110 - IIf(TabCargo.Visible, TabCargo.Height + 85, +100) ' < 7000
        'End If
        If Me.fraCargo.Visible = True Then
            Me.dgdDetailBillOfLading.Height = Me.fraCargo.Top - Me.dgdDetailBillOfLading.Top - 10
        Else
            Me.dgdDetailBillOfLading.Height = Me.Height - Me.dgdDetailBillOfLading.Top - Me.MenuStrip.Height - Me.cboBillofLading.Height - 10
        End If

        dgdDetailBillOfLading.Width = (Me.Width - 35)
        Me.fraCargo.Width = Me.dgdDetailBillOfLading.Width

        Me.TabCargo.Width = Me.fraCargo.Width - 20
        Me.dgdPrice.Width = Me.TabCargo.Width - 30
        Me.fraCargoGoods.Width = Me.TabCargo.Width - 20

        'Me.cmdOK.Left = fraTotal.Left
        'Me.cmdCancel.Left = Me.cmdOK.Left + Me.cmdOK.Width + 20

        'cmdCancel.Top = tabcargo.Bottom - cmdOK.Height - 5

        'cmdFind.Left = Me.txtContainer.Left + Me.txtContainer.Width + 10
        'txtContainer.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Detail Cargo InBound "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Detail Cargo InBound-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Detail Cargo InBound-> Add."
        End If
    End Sub

    Private Sub smnuInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuInsert.Click

        On Error GoTo Err_Renamed

        If mStatus = "Normal" And UserRight("frmInputDataInBound", "Add") Then
            SetMenu(False)
            mCargoIBEDI_ID = DefaultValue
            mStatus = "Add"
            Me.TabCargo.Visible = True
            ReFormat()
            Me.dgdDetailBillOfLading.Enabled = False
            reText(mStatus)
            Me.cmdOK.Enabled = True
            Me.cboCTN_NO.Text = ""
            Me.txtSealNo.Text = ""
            Me.txtAmount.Text = "0"
            Me.txtGross.Text = "0"
            Me.txtMeas.Text = "0"
            Me.txtWeek.Text = ""
            Me.txtNote.Text = ""

        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Not IsNothing(oTableDetailBillOfLading) Then
            Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
            Dim indexBill As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
            'QueryPrice(, index, )
            Approve = Me.dgdDetailBillOfLading.Item("Approve", index).Value
            EditTable = Me.dgdDetailBillOfLading.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmInputDataInbound", "Edit") Then
                Me.dgdDetailBillOfLading.Enabled = False
                Me.TabCargo.Visible = True
                Me.fraCargo.Visible = True

                ReFormat()

                mCargoIBEDI_ID = Me.dgdDetailBillOfLading.Item("CargoIBEDI_Id", index).Value.ToString
                'mCargoMarks_ID = Me.dgdDetailBillOfLading.Item("CargoMarks_Id", index).Value.ToString
                'mCargoRemarks_ID = Me.dgdDetailBillOfLading.Item("CargoRemarks_Id", index).Value.ToString

                mStatus = "Edit"
                reText(mStatus)
                SetMenu(False)
                RefreshData(index)

                Me.fraCargoGoods.Enabled = True
                ' chua biet query gia tu dau
                'QueryPrice(" And Container_type='" & Me.cboContainerType.Text.Trim & "'", index)

                Me.cmdOK.Enabled = True
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Else
            DisplayMessage(True, "No item in the Grid.")
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, "No item in the Grid.")
    End Sub

    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strBillOfLadingId As String

        Dim rs As New ADODB.Recordset
        Dim strSQL As String
        strSQL = "Select * From CargoIBEDI where CTN_ID='" & CtainerID & "' And BLIB_ID='" & BillID & "' And Continued=1 And CargoIBEDI_ID <>'" & mCargoIBEDI_ID & "'"
        rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            strMsg = "This Container had already had in this Bill! "
            DisplayMessage(True, strMsg)
            CheckData = False

        End If
        strBillOfLadingId = DefaultValue


        If Len(Me.cboCTN_NO.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Container No. is invalid."
            Me.cboCTN_NO.Focus()

        End If

        If Len(Me.txtAmount.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Amount is invalid. "
            Me.txtAmount.Focus()

        End If
        If Me.chkStandard.Checked Then
            If Me.cboKind.FindStringExact(Me.cboKind.Text) = -1 Then
                CheckData = False
                strMsg = strMsg & "The Kind is invalid."

            End If
        ElseIf Me.chkOther.Checked Then
            If Len(Me.txtKind.Text) = 0 Then
                CheckData = False
                strMsg = strMsg & "The Kind is invalid."

            End If
        End If
        If Me.chkStandard.Checked = False And Me.chkOther.Checked = False Then
            CheckData = False
            strMsg = strMsg & "The Kind is invalid. "

        End If
        If Len(Me.txtGross.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Gross is invalid."
            Me.txtGross.Focus()

        End If
        If Me.cboUnitGross.FindStringExact(Me.cboUnitGross.Text) = -1 Then
            CheckData = False
            strMsg = strMsg & "The Unit Gross is invalid."
            Me.cboUnitGross.Focus()

        End If
        If Len(Me.txtMeas.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Meas is invalid."
            Me.txtMeas.Focus()

        End If

        If Me.cboUnitVolume.FindStringExact(Me.cboUnitVolume.Text) = -1 Then
            CheckData = False
            strMsg = strMsg & "The Unit Volume is invalid. Please check again."
            Me.cboUnitVolume.Focus()

        End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Public Function WeekOfYear(ByVal dpt As Object) As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        If dpt.ToString <> "" Then
            WeekOfYear = myCal.GetWeekOfYear(CDate(dpt.Text), myCWR, myFirstDOW)
        Else
            WeekOfYear = 0
        End If

        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function

    Sub QueryBILLOFLADINGIBEDI(ByRef dt As DataTable)
        On Error GoTo Err
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------

        'strQuery = "Select Vessel.Vessel,VOYAGE,BLIB_NO, ETA,DisChargeDate, POL,ICDPort From (BILLOFLADINGIBEDI LEFT JOIN Vessel On Vessel.Vessel_ID=BILLOFLADINGIBEDI.VESSEL_ID)"
        'strQuery &= " Where BLIB_ID='" & BillID & "' And BILLOFLADINGIBEDI.Continued=1"
        'strQuery = MakeQueryDetailBillOfLading(argCriteria, index)
        'End If
        'strQuery
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------

        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(dt)

        Exit Sub
Err:
    End Sub

    Sub InsertContainerMNG()
        On Error GoTo Err
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim dt As New DataTable
        'lay du lieu trong bang Billoflading IB de vao dt
        strQuery = "select Top 1 * from BILLOFLADINGIBEDI Where Continued=1 And BLIB_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "'"
        QueryBillInfo(dt, strQuery)
        strQuery = "SELECT Top 1 * "
        strQuery = strQuery & "FROM ContainerManagerment  Where CargoIBEDI_ID='" & mCargoIBEDI_ID & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        With rs
            If mStatus = "Add" Then
                .AddNew()
                .Fields("ContainerManagementID").Value = NewId()
                .Fields("CargoIBEDI_ID").Value = mCargoIBEDI_ID
                .Fields("BL_NO_Inbound").Value = dt.Rows(0).Item("BLIB_NO").ToString
                .Fields("TS_AHR").Value = dt.Rows(0).Item("POL").ToString
                .Fields("Vessel_Inbound").Value = dt.Rows(0).Item("Vessel").ToString
                .Fields("VoyNo_Inbound").Value = dt.Rows(0).Item("VOYAGE")
                .Fields("Arrival_Date").Value = dt.Rows(0).Item("ETA").ToString
                .Fields("DisCharge_Date").Value = dt.Rows(0).Item("DisChargeDate")
                .Fields("SoundContainer").Value = False
                .Fields("ToBeInSpected").Value = False
                .Fields("DamageContainer").Value = False
                .Fields("FullImport").Value = False
                .Fields("FullToConsignee").Value = False
                .Fields("FullExport").Value = False
                .Fields("EmptyToShipper").Value = False
                .Fields("EmptyContainerReposit").Value = False
                .Fields("ICDPort").Value = dt.Rows(0).Item("ICDPort")
                .Fields("ImportCY").Value = dt.Rows(0).Item("ICDPort").ToString 'ICDPort
            End If
            .Fields("Container_No").Value = Me.cboCTN_NO.Text.Trim
            .Fields("CTN_SIZE_TYPE").Value = Me.txtContainerType.Text.Trim

            .Update()
        End With
        rs.Close()

        Exit Sub
Err:

    End Sub

    Sub InsertContainerMNG(ByVal mCargoIBEDI_ID As String, ByVal BL_NO_Inbound As String, ByVal POL As String, ByVal Vessel As String, ByVal VoyNo As String, ByVal ETA As Date, ByVal ICDPort As String, ByVal mStatus As String, ByVal ContainerNo As String, ByVal ContainerType As String)
        On Error GoTo Err
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim dt As New DataTable
        'lay du lieu trong bang Billoflading IB de vao dt
        strQuery = "select Top 1 * from BILLOFLADINGIBEDI Where Continued=1 And BLIB_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "'"
        QueryBillInfo(dt, strQuery)
        If dt.Rows.Count = 0 Then
            DisplayMessage(True, "Bill No Is invalid check again please!")
            Return
        End If
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM ContainerManagerment  Where BL_NO_Inbound='" & Me.cboBillofLading.Text.Trim & "' and Container_No ='" & Me.cboCTN_NO.Text.ToString.Trim & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            With rs
                .AddNew()
                .Fields("ContainerManagementID").Value = NewId()
                .Fields("CargoIBEDI_ID").Value = mCargoIBEDI_ID
                .Fields("BL_NO_Inbound").Value = dt.Rows(0).Item("BLIB_NO").ToString '
                .Fields("TS_AHR").Value = dt.Rows(0).Item("POL").ToString 'POL
                .Fields("Vessel_Inbound").Value = dt.Rows(0).Item("VESSEL").ToString ' Vessel
                .Fields("VoyNo_Inbound").Value = dt.Rows(0).Item("VOYAGE").ToString 'VoyNo
                .Fields("Arrival_Date").Value = dt.Rows(0).Item("ETA").ToString ' ETA
                .Fields("DisCharge_Date").Value = dt.Rows(0).Item("DisChargeDate").ToString ' ETA ' lay chung voi Arrival date
                .Fields("SoundContainer").Value = False
                .Fields("ToBeInSpected").Value = False
                .Fields("DamageContainer").Value = False
                .Fields("FullImport").Value = False
                .Fields("FullToConsignee").Value = False
                .Fields("FullExport").Value = False
                .Fields("EmptyToShipper").Value = False
                .Fields("EmptyContainerReposit").Value = False
                .Fields("ICDPort").Value = dt.Rows(0).Item("ICDPort").ToString 'ICDPort
                .Fields("ImportCY").Value = dt.Rows(0).Item("ICDPort").ToString 'ICDPort
                '.Fields("FullOrEmpty").Value = FULLORMT
                .Fields("Container_No").Value = Me.cboCTN_NO.Text.Trim 'ContainerNo
                .Fields("CTN_SIZE_TYPE").Value = Me.txtContainerType.Text.Trim 'ContainerType

                .Update()
            End With
        End If
        rs.Close()

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryBillInfo(ByRef dt As DataTable, ByVal strSQL As String)
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
        Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
        Try
            Conn.Open()
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Conn.Close()
            Conn.Dispose()
            Conn = Nothing
            cmd.Dispose()
            cmd = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Sub



    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        Dim indexBill As Integer
        If Me.dgdDetailBillOfLading.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading.CurrentRow.Index
            indexBill = Me.dgdDetailBillOfLading.CurrentRow.Index
        End If
        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            If mStatus = "Edit" Then
                CopyValues("CargoIBEDI", "CargoIBEDI_Id", mCargoIBEDI_ID)
            End If

            'thêm vào cargo 

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CargoIBEDI "
            strQuery = strQuery & "WHERE CargoIBEDI_Id = '" & mCargoIBEDI_ID & "' AND CargoIBEDI_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoIBEDI_ID").Value = NewId()
                    .Fields("BLIB_Id").Value = "{" & BillID & "}"
                    '.Fields("PACKAGES_ID").Value = "{" & FindValueID(Me.cboPackages, Me.cboPackages.Text) & "}"
                End If
                mCargoIBEDI_ID = .Fields("CargoIBEDI_Id").Value
                .Fields("CTN_ID").Value = "{" & CtainerID & "}"
                .Fields("SEAL").Value = UCase(Trim(Me.txtSealNo.Text))
                .Fields("Amount").Value = Me.txtAmount.Text

                .Fields("CONTAINER_TYPE").Value = Trim(Me.txtContainerType.Text)

                If Me.chkStandard.Checked Then
                    .Fields("Kind").Value = Trim(Me.cboKind.Text)
                Else
                    If Me.chkOther.Checked Then
                        .Fields("Kind").Value = Trim(Me.txtKind.Text)
                    End If
                End If
                .Fields("GrossWEIGHT").Value = Trim(Me.txtGross.Text)
                .Fields("GrossUnit").Value = Trim(Me.cboUnitGross.Text)

                .Fields("MEAS").Value = Trim(Me.txtMeas.Text)
                .Fields("MEASUNIT").Value = Trim(Me.cboUnitVolume.Text)
                .Fields("RECEIVEDATE").Value = CDate(Trim(Me.DateTimePicker.Text))
                .Fields("Week").Value = Trim(WeekOfYear(Me.DateTimePicker))

                .Fields("CARRIERKIND").Value = Trim(Me.txtCarrierKind.Text)
                .Fields("RECEIVEKIND").Value = Trim(Me.txtReceiVeKind.Text)

                .Fields("Note").Value = Trim(Me.txtNote.Text)
                .Update()

            End With

            rs.Close()
            InsertContainerMNG()
            '-----------------
            Me.dgdDetailBillOfLading.Enabled = True

            Me.fraCargoGoods.Enabled = True

            Me.TabCargo.Visible = False


            mStatus = "Normal"
        End If
        QueryDetailBillOfLading("And CargoIBEDI.BLIB_ID='" & BillID & "'", , index)
        ReFormat()
        SetMenu((True))

        reText(mStatus)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboBillofLading_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillofLading.Leave
        On Error GoTo Err_Renamed
        Dim strSql, Port_code As String
        If Me.cboBillofLading.Items.Count = 0 Then
            Return
        End If
        Me.cboBillofLading.Text = Trim(UCase(Me.cboBillofLading.Text))
        strSql = "Select BLIB_No as BLIB_No From BILLOFLADINGIBEDI Where Continued=1"
        If Me.cboBillofLading.FindStringExact(Me.cboBillofLading.Text) = -1 Then
            Me.cboBillofLading.Text = FindBetter_new("BLIB_No", strSql, Me.cboBillofLading.Text)
            If Me.cboBillofLading.FindStringExact(Me.cboBillofLading.Text) = -1 Then
                DisplayMessage(True, "The bill is invalid, please check and correct it.")
                Me.cboBillofLading.Focus()
            End If
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboBillofLading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillofLading.SelectedIndexChanged
        On Error GoTo Err
        Dim Bill_ID As String
        Bill_ID = FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text)
        QueryDetailBillOfLading(" And CargoIBEDI.BLIB_ID='" & Bill_ID & "'", 14)
        If Bill_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "select SHIPPER_1,Shipper.Shipper_ID" & _
            " from (SHIPPER LEFT JOIN  BILLOFLADINGIBEDI ON BILLOFLADINGIBEDI.Shipper_ID=Shipper.Shipper_ID) " & _
            "  where BLIB_ID='" & Bill_ID & "'"

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Bill")

            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.txtSHIPPERNAME.Text = table.Rows(0).Item("SHIPPER_1")
                BillID = Bill_ID
            End If
        End If
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.TabCargo.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdDetailBillOfLading.Enabled = True
        Me.cmdOK.Enabled = False
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub TabCargo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCargo.SelectedIndexChanged
        On Error GoTo Err_named
        If TabCargo.SelectedIndex = 1 Then
            If Not UserRight("frmInputDataInbound", "Execute") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                TabCargo.SelectedIndex = 0
                Exit Sub
            Else
                Dim index As Integer
                If (Me.dgdDetailBillOfLading.RowCount > 0) Then
                    index = Me.dgdDetailBillOfLading.CurrentRow.Index
                    QueryContainer()
                    QueryPrice(" And Container_Type='" & Me.cboContainerType.Text.Trim & "'", index, )
                End If
            End If

        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub TabCargo_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCargo.VisibleChanged

        On Error GoTo Err
        TabCargo.SelectedIndex = 0
        Me.fraTotal.Visible = Me.TabCargo.Visible
        Me.fraCargo.Visible = Me.TabCargo.Visible
        Me.cboBillofLading.Enabled = Not Me.TabCargo.Visible
        Me.cmdCancel.Visible = Me.TabCargo.Visible
        Me.cmdOK.Visible = Me.TabCargo.Visible
        If TabCargo.Visible = True Then
            ReFreshFreight(False)
            load = False
            QueryContainer()
            QueryPrice(" And Container_Type ='" & Me.cboContainerType.Text.Trim & "'")
            Dim cbo As Object
            cbo = Me.txtPrepaidCollect
            'Queryport(cbo)
            'QueryItems()
        End If
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryDetailBillofLadingList As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        strQuery = "Select count(*) cnt from FREIGHT_CHARGE_IBEDI WHERE BLIB_Id = '" & Me.dgdDetailBillOfLading.Item("BL_ID", index).Value.ToString & "' And Continued=1 And Container_type='" & Me.dgdDetailBillOfLading.Item("ContainerType", index).Value.ToString.Trim & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The Containers can not be removed. There are transactions that relate to this Container(FreightCharge).")
            Exit Sub
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading.Item("Approve", index)) Then
            If Me.dgdDetailBillOfLading.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading.Item("Editable", index)) Then
            If Not Me.dgdDetailBillOfLading.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmInputDataInBound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container No: " & Me.dgdDetailBillOfLading.Item("Container_NO", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillofLadingList = "Select * from CargoIBEDI where" + " CargoIBEDI_Id= '" & Me.dgdDetailBillOfLading.Item("CargoIBEDI_Id", index).Value.ToString & "'"
                rs.Open(strQueryDetailBillofLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                Me.dgdDetailBillOfLading.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdDetailBillOfLading.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub smnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
 Me.dgdDetailBillOfLading.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdDetailBillOfLading.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryDetailBillOfLading(" And CargoIBEDI.BLIB_ID='" & BillID & "'")
    End Sub

    Private Sub chkOther_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOther.CheckedChanged
        Me.chkStandard.Checked = Not Me.chkOther.Checked()
        If Me.chkStandard.Checked Then
            Me.lblKind.Visible = True
            Me.cboKind.Visible = True
            Me.lblKind.Visible = False
            Me.txtKind.Visible = False
        End If
        If Me.chkOther.Checked Then
            Me.lblKind.Visible = True
            Me.txtKind.Visible = True

            Me.cboKind.Visible = False
        End If
    End Sub

    Private Sub chkStandard_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStandard.CheckedChanged
        Me.chkOther.Checked = Not Me.chkStandard.Checked
        If Me.chkStandard.Checked Then
            Me.lblKind.Visible = True
            Me.cboKind.Visible = True
            Me.txtKind.Visible = False
        End If
        If Me.chkOther.Checked Then
            Me.lblKind.Visible = True
            Me.txtKind.Visible = True
            Me.cboKind.Visible = False
        End If

    End Sub

    Private Sub cboCTN_NO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCTN_NO.Leave
        On Error GoTo Err_Renamed
        Dim strSql, Port_code As String
        Me.cboCTN_NO.Text = Trim(UCase(Me.cboCTN_NO.Text))
        strSql = "Select container_no as container_no From container Where Continued=1"
        If Me.cboCTN_NO.FindStringExact(Me.cboCTN_NO.Text) = -1 Then
            Me.cboCTN_NO.Text = FindBetter_new("container_no", strSql, Me.cboCTN_NO.Text)
            If Me.cboCTN_NO.FindStringExact(Me.cboCTN_NO.Text) = -1 Then
                DisplayMessage(True, "The Port is invalid, please check and correct it.")
                Me.cboCTN_NO.Focus()
            End If
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboCTN_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCTN_NO.SelectedIndexChanged
        On Error GoTo Err_Named
        Dim ContainerID As String
        ContainerID = FindValueID(Me.cboCTN_NO, Me.cboCTN_NO.Text)
        If ContainerID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable

            '----------------
            strQuery = "select * from Container where CTN_ID='" & ContainerID & "'"

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            Adapter.Fill(dset, "Container")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                CtainerID = table.Rows(0).Item("CTN_ID").ToString
                Me.txtContainerType.Text = table.Rows(0).Item("CTN_SIZE_TYPE").ToString

            End If
            ''''''''''''''''''''''''''''''''''''''''

        End If
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuDisplayApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub
    Private Sub smnuDisplayRecieveKind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayReceiveKind.Click
        Me.smnuDisplayReceiveKind.Checked = Not Me.smnuDisplayReceiveKind.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCarrierKind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayCarrierKind.Click
        Me.smnuDisplayCarrierKind.Checked = Not Me.smnuDisplayCarrierKind.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayContainersId_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayContainersId.Click
        Me.smnuDisplayContainersId.Checked = Not Me.smnuDisplayContainersId.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayContainerType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayContainerType.Click
        Me.smnuDisplayContainerType.Checked = Not Me.smnuDisplayContainerType.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayGross_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayGross.Click
        Me.smnuDisplayGross.Checked = Not Me.smnuDisplayGross.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayKind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayKind.Click
        Me.smnuDisplayKind.Checked = Not Me.smnuDisplayKind.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayMeas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayMeas.Click
        Me.smnuDisplayMeas.Checked = Not Me.smnuDisplayMeas.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayNote.Click
        Me.smnuDisplayNote.Checked = Not Me.smnuDisplayNote.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayReceiveDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayReceiveDate.Click
        Me.smnuDisplayReceiveDate.Checked = Not Me.smnuDisplayReceiveDate.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplaySealNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplaySealNo.Click
        Me.smnuDisplaySealNo.Checked = Not Me.smnuDisplaySealNo.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUnitGross_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUnitGross.Click
        Me.smnuDisplayUnitGross.Checked = Not Me.smnuDisplayUnitGross.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUnitMeas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUnitMeas.Click
        Me.smnuDisplayUnitMeas.Checked = Not Me.smnuDisplayUnitMeas.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUserId_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayAmount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayAmount.Click
        Me.smnuDisplayAmount.Checked = Not Me.smnuDisplayAmount.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayWeek.Click
        Me.smnuDisplayWeek.Checked = Not Me.smnuDisplayWeek.Checked
        UpdateFrame()
    End Sub

    Private Sub DateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker.ValueChanged
        Me.txtWeek.Text = WeekOfYear(Me.DateTimePicker)
    End Sub

    Public Sub ApproveDetailBillOfLading()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
        Dim strQueryDetailBillOfLadingList As String
        If Not Me.dgdDetailBillOfLading.Item("Editable", index).Value Or Not UserRight("frmInputDataInbound", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryDetailBillOfLading(mFilter, , index)
        Else
            strQueryDetailBillOfLadingList = "Select * from CargoIBEDI where" + " CargoIBEDI_Id= '" & Me.dgdDetailBillOfLading.Item("CargoIBEDI_Id", index).Value.ToString & "' And Continued=1"
            rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdDetailBillOfLading_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDetailBillOfLading.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.BindingContext(oTableDetailBillOfLading).Position
        On Error GoTo Err_Renamed
        If Me.dgdDetailBillOfLading.Rows.Count <= 0 Then
            Return
        End If
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdDetailBillOfLading.Columns(ColIndex).Name) = "APPROVE" And Me.dgdDetailBillOfLading.CurrentCellAddress().Y = index Then
            Call ApproveDetailBillOfLading()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboContainerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContainerType.SelectedIndexChanged
        On Error GoTo Err_Named
        Dim Bill As String
        Bill = FindValueID(Me.cboContainerType, Me.cboContainerType.Text).Trim
        If Bill <> "" Then
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            Dim strSQL As String = "select Count(Container_TYPE) As Num,Container_Type from CargoIBEDI "
            strSQL &= " Where BLIB_ID='" & Bill & "' And Continued=1 "
            strSQL &= " And Container_Type='" & Me.cboContainerType.Text.Trim & "' Group By Container_TYPE "
            Dim CmdSelect As New SqlClient.SqlCommand(strSQL, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Unit")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.txtUnit.Text = table.Rows(0).Item("Num").ToString
            End If

            Dim index As Integer
            If Me.dgdDetailBillOfLading.Rows.Count > 0 Then
                index = Me.dgdDetailBillOfLading.CurrentRow.Index
            End If
            QueryPrice("And Container_Type='" & Me.cboContainerType.Text.Trim & "'", index)
        End If
        Exit Sub
Err_Named:
        DisplayMessage(True, Err.Description & "Container Type")
    End Sub

    Sub ReFreshFreight(ByVal b As Boolean)
        On Error GoTo Err_named
        'Me.cboContainerType.Enabled = b
        Me.txtItems.Enabled = b
        Me.txtCurrency.Enabled = b
        Me.txtUnitPrice.Enabled = b
        Me.txtPrepaidCollect.Enabled = b
        Me.cmdOKP.Enabled = b
        Me.txtPrepaidCollect.Enabled = b
        Me.txtPOP.Enabled = b
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAdd.Click
        On Error GoTo Err_named
        mStatusp = "Add"
        FreightChargeID = DefaultValue
        ReFreshFreight(True)

        'Me.cmdOKP.Text = "Add"
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEdit.Click
        On Error GoTo Errname
        Dim index As Integer

        If Me.oTablePrice.Rows.Count > 0 Then
            index = Me.dgdPrice.CurrentRow.Index
        Else
            Exit Sub
        End If
        If Not IsNothing(Me.dgdPrice.Item("ApproveP", index).Value) And UserRight("frmListBillOfLadingMaster", "Edit") Then
            If Me.dgdPrice.Item("ApproveP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        mStatusp = "Edit"
        Me.cboContainerType.Enabled = True
        ReFreshFreight(True)
        FreightChargeID = Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString
        Me.txtPrepaidCollect.Text = Me.dgdPrice.Item("Prepaid_Collect", index).Value.ToString.Trim
        Me.txtItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
        Me.txtCurrency.Text = Me.dgdPrice.Item("Currency", index).Value.ToString
        Me.txtUnitPrice.Text = Me.dgdPrice.Item("AMOUNTP", index).Value.ToString
        Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString

        Exit Sub
Errname:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowP(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        If Not IsNothing(Me.dgdPrice.Item("ApproveP", index).Value) Then
            If Me.dgdPrice.Item("ApproveP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPrice.Item("EditableP", index).Value) Then
            If Not Me.dgdPrice.Item("EditableP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmInputDataInbound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Detail of Price: " & Me.dgdPrice.Item("Items", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from FREIGHT_CHARGE_IBEDI where FREIGHT_CHARGE_IBEDI='" & Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                Me.dgdPrice.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdPrice.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()

            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub ctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel.Click
        Dim selectedRowCount As Integer = _
  Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowP(Me.dgdPrice.SelectedRows(i).Index)
            Next i
        End If
        Dim index As Integer = 0
        If Me.dgdDetailBillOfLading.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading.CurrentRow.Index
        End If
        QueryPrice(" And Container_Type='" & Me.txtContainerType.Text.Trim & "'", index, )
    End Sub

    Public Sub ApprovePrice()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim rs As New ADODB.Recordset
        Dim index As Integer = Me.dgdPrice.CurrentRow.Index
        Dim strQuery As String
        If Not Me.dgdPrice.Item("EditableP", index).Value Or Not UserRight("frmInputDataInbound", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPrice(" And Container_Type='" & Me.cboContainerType.Text.Trim & "'", index)
        Else
            ' strQuery = "Select * from FREIGHT_CHARGE_Master where" + " BillOfLadingId= '" & oTablePrice.Rows(index).Item("BillOfLadingId").ToString & "' AND Cargo_ID='" & oTablePrice.Rows(index).Item("Cargo_ID").ToString & "' AND Items='" & oTablePrice.Rows(index).Item("Items").ToString & "'"
            strQuery = "select * from FREIGHT_CHARGE_IBEDI where FREIGHT_CHARGE_IBEDI='" & Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPrice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPrice.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        'MsgBox(Me.dgdPrice.CurrentCellAddress.X)
        If Me.dgdPrice.CurrentCellAddress.X = 10 And Me.dgdPrice.CurrentCellAddress().Y = RowIndex Then
            Call ApprovePrice()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOKP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKP.Click
        On Error GoTo Err_Renamed
        If mStatusp = "Add" Or mStatusp = "Edit" Then


            If Len(Me.txtCurrency.Text) = 0 Then
                DisplayMessage(True, "The Currency is invalid. ")
                Me.txtCurrency.Focus()
                Exit Sub
            End If
            If Len(Me.txtUnitPrice.Text) = 0 Then
                DisplayMessage(True, "The Price is invalid. ")
                Me.txtCurrency.Focus()
                Exit Sub
            End If
            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.dgdPrice.RowCount > 0 Then
                index = Me.dgdPrice.CurrentRow.Index()
            End If

            Dim indexBill As Integer
            If Me.dgdDetailBillOfLading.RowCount = 0 Then
                Return
            End If

            indexBill = Me.dgdDetailBillOfLading.CurrentRow.Index

            'If indexBill >= 0 Then
            '    Cargo_ID = Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString
            'Else
            '    'Cargo_ID = DefaultValue
            '    Exit Sub
            'End If
            strQuery = "Select * from FREIGHT_CHARGE_IBEDI where Items='" & Me.txtItems.Text.Trim & "'"
            strQuery = strQuery & " and BLIB_id='" & BillID & "' And Continued=1 And Container_Type='" & Me.cboContainerType.Text.Trim & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            If Not rs.EOF And mStatusp = "Add" Then
                DisplayMessage(True, "This Item Had Added ")
                Exit Sub
            End If
            rs.Close()
            strQuery = "Select * from FREIGHT_CHARGE_IBEDI where FREIGHT_CHARGE_IBEDI='" & FreightChargeID & "'And Continued=1 "
            ' strQuery = strQuery & " And BL_ID='" & BillID & "'"

            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


            With rs
                If mStatusp = "Add" Then
                    .AddNew()
                    .Fields("FREIGHT_CHARGE_IBEDI").Value = NewId()
                    Dim temp As String

                    'temp = "{" & Trim(Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString) & "}"

                    '.Fields("CTN_ID").Value = "{" & Me.dgdDetailBillOfLading.Item("Container_ID", indexBill).Value.ToString & "}"
                    .Fields("BLIB_ID").Value = "{" & BillID & "}"

                End If


                .Fields("Items").Value = Me.txtItems.Text.Trim
                .Fields("Quantity").Value = Me.txtUnit.Text.Trim

                .Fields("CONTAINER_TYPE").Value = Me.cboContainerType.Text
                .Fields("POP_code").Value = Me.txtPOP.Text
                .Fields("Prepaid_collect").Value = Me.txtPrepaidCollect.Text
                .Fields("Currency").Value = Me.txtCurrency.Text
                .Fields("UnitPrice").Value = Me.txtUnitPrice.Text
                .Update()
            End With
            rs.Close()
            '-----------------

            'mStatusP = "Normal"
            ReFreshFreight(False)
            Me.dgdPrice.Enabled = True
            mStatusp = "Normal"
            Me.cmdOKP.Enabled = False
            QueryPrice(" And Container_Type='" & Me.cboContainerType.Text.Trim & "'", indexBill)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelP.Click
        On Error GoTo Err_named
        ReFreshFreight(False)
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        Me.Close()

    End Sub



    Private Sub cboPOP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub txtTotalVolime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalVolime.TextChanged

    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryDetailBillOfLading("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdDetailBillOfLading.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdDetailBillOfLading, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdDetailBillOfLading_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDetailBillOfLading.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading)
    End Sub

    Private Sub dgdPrice_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPrice.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdPrice)
    End Sub
End Class
