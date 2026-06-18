Public Class frmListLocalPic
    Inherits System.Windows.Forms.Form

    Dim rsPicLocalList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mPicLocalId As String

    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strPicLocalSelect As String = "SELECT * " ' & _
    '   "PicLocalID, " & _
    '   "PicName, " & _
    '   "PicLocal , " & _
    '       "NATIONALITY , " & _
    '   "SHIPPING_LINE, " & _
    '   "CALL_SIGN , " & _
    '   "BUILD , " & _
    '"CLASS , " & _
    '   "PUMP_CAPACITY , " & _
    '   "SDWT, " & _
    '   "GRT, " & _
    '   "NRT, " & _
    '   "LOA, " & _
    '   "BM, " & _
    '   "DRAFT, " & _
    '   "TEL, " & _
    '   "FAX, " & _
    '   "TELEX, " & _
    '   "MOBILE, " & _
    '   "EMAIL, " & _
    '    "Approve, " & _
    '    "Continued, " & _
    '   "Editable, " & _
    '   "UserId, " & _
    '   "Updatetime "


    Const strPicLocalOrder1 As String = _
           " ORDER BY PicName  Desc "
    Const strPicLocalOrder2 As String = _
        " ORDER BY UpdateTime Desc "


    Private Sub frmListPicLocal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mPicLocalId = DefaultValue
        SetDefaultGrid(Me.dgdPicLocal, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdPicLocal)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'Me.cboFind.Text = objUserSetting.GetCParm("frmListPicLocal.cboFind", "NAME")
        mFilter = objUserSetting.GetCParm("frmListPicLocal.mFilter")
        'Me.txtPicLocalCode.Text = objUserSetting.GetCParm("frmListPicLocal.txtPicLocalCode")
        'Me.txtPicLocalName.Text = objUserSetting.GetCParm("frmListPicLocal.txtPicLocalName")
        'Me.txtNATIONALITY.Text = objUserSetting.GetCParm("frmListPicLocal.txtNATIONALITY")
        ''Me.txtVoyage.Text = objUserSetting.GetCParm("frmListPicLocal.txtVoyage")
        'Me.txtCallSign.Text = objUserSetting.GetCParm("frmListPicLocal.txtCallSign")
        'Me.txtTELEX.Text = objUserSetting.GetCParm("frmListPicLocal.txtTELEX")
        'Me.txtBUILD.Text = objUserSetting.GetCParm("frmListPicLocal.txtBUILD")
        'Me.txtClass.Text = objUserSetting.GetCParm("frmListPicLocal.txtClass")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmListPicLocal.txtEmail")
        'Me.txtMobile.Text = objUserSetting.GetCParm("frmListPicLocal.txtMOBILE")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmListPicLocal.txtEMAIL")
        'Me.txtPUMP_CAPACITY.Text = objUserSetting.GetCParm("frmListPicLocal.txtPUMP_CAPACITY")
        ''Me.txtGRT.Text = objUserSetting.GetCParm("frmListPicLocal.txtGRT")
        ''Me.txtNRT.Text = objUserSetting.GetCParm("frmListPicLocal.txtNRT")
        'Me.txtSDWT.Text = objUserSetting.GetCParm("frmListPicLocal.txtSDWT")
        'Me.txtLOA.Text = objUserSetting.GetCParm("frmListPicLocal.txtLOA")
        'Me.txtDRAFT.Text = objUserSetting.GetCParm("frmListPicLocal.txtDRAFT")
        'Me.txtBM.Text = objUserSetting.GetCParm("frmListPicLocal.txtTEL")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmListPicLocal.txtFax")
        ''Me.txtShippingLine.Text = objUserSetting.GetCParm("frmListPicLocal.txtSHIPPING_LINE")
        'If Me.txtPicLocal.Text <> "" Then
        '    QueryPicLocal("AND PicLocal LIKE '" & MakeFilter(Me.txtPicLocal.Text) & "' " & mFilter, , )
        'Else
        '    QueryPicLocal(mFilter, , )
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If


        ' Me.smnuDisplayVOYAGE.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayVOYAGE")
        'Me.smnuDisplayNATIONALITY.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayNATIONALITY")
        'Me.smnuDisplayCALL_SIGN.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayCALL_SIGN")
        'Me.smnuDisplayBUILD.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayBUILD")
        'Me.smnuDisplayCLASS.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayCLASS")
        'Me.smnuDisplayPUMP_CAPACITY.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayPUMP_CAPACITY")
        'Me.smnuDisplaySDWT.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplaySDWT")
        'Me.smnuDisplayGRT.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayGRT")
        'Me.smnuDisplayNRT.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayNRT")
        'Me.smnuDisplayLOA.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayLOA")
        'Me.smnuDisplayBM.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayBM")
        'Me.smnuDisplayDRAFT.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayDRAFT")
        'Me.smnuDisplayTEL.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayTEL")
        'Me.smnuDisplayFAX.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayFAX")
        'Me.smnuDisplayTELEX.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayTELEX")
        'Me.smnuDisplayMOBIL.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayMOBIL")
        'Me.smnuDisplayEMAIL.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayEMAIL")
        'Me.smnuDisplayAPPROVE.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayAPPROVE")

        'Me.smnuDisplayUSERID.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayUserId")
        'Me.smnuDisplayUPDATETIME.Checked = objUserSetting.GetBParm("frmListPicLocal.smnuDisplayUpdateTime")
        'UpdateFrame()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        'SetWidth()
        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub ReFormat()
        On Error GoTo Err
        Dim rong As Integer
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(FraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(FraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        If Not CheckRez(800, 600) Then
            rong = 50
        Else
            rong = 0
        End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.dgdPicLocal.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            Me.dgdPicLocal.Height = Me.Height - cmdOk.Height - 10 - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            Me.dgdPicLocal.Height = Me.Height - cmdOk.Height - 10 - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = Me.dgdPicLocal.Height + Me.dgdPicLocal.Top '+ 100
        'cmdCancel.Top = Me.FraUpdate.Bottom + 10
        'Me.cmdOK.Top = Me.cmdCancel.Top
        'cmdCancel.Left = Me.FraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdFind.Left = Me.txtPicLocal.Left + Me.txtPicLocal.Width + 10
        'Me.txtPicLocal.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    'Public Sub SetWidth()
    '    '-------cot 1

    '    'Me.txtPicLocal.Width = Me.Width - 300
    '    'Me.TxtPicLocalName.Width = Me.fraUpdate.Width - Me.TxtPicLocalName.Left - Me.lblTELEX.Width - Me.txtTELEX.Width - 120
    '    'Me.lblTELEX.Left = Me.TxtPicLocalName.Right + 10
    '    'Me.txtTELEX.Left = Me.lblTELEX.Right + 3

    '    'Me.txtNATIONALITY.Width = Me.txtNATIONALITY.Right - Me.txtNATIONALITY.Left

    '    'Me.lblCALLSIGN.Left = Me.TxtPicLocalName.Right - Me.txtCallSign.Width - 3 - Me.lblCALLSIGN.Width

    '    'Me.txtCallSign.Left = Me.TxtPicLocalName.Right - Me.txtCallSign.Width
    '    'Me.txtCallSign.Width = Me.txtCallSign.Right - Me.txtCallSign.Left

    '    'Me.LBLCLASS.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLCLASS.Width
    '    'Me.txtClass.Left = Me.txtCallSign.Left

    '    'Me.lblMOBILE.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblMOBILE.Width
    '    'Me.txtMOBILE.Left = Me.txtTELEX.Left

    '    'Me.LBLGRT.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLGRT.Width
    '    'Me.txtGRT.Left = Me.txtClass.Left


    '    'Me.LBLEMAIL.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.LBLEMAIL.Width
    '    'Me.txtEMAIL.Left = Me.txtTELEX.Left

    '    'Me.lblTell.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblTell.Width
    '    'Me.txtTell.Left = Me.txtTELEX.Left

    '    'Me.LBLSDWT.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLSDWT.Width
    '    'Me.txtSDWT.Left = Me.txtCallSign.Left

    '    'Me.lbldraft.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.lbldraft.Width
    '    'Me.txtDRAFT.Left = Me.txtCallSign.Left

    '    'Me.lblShippingLine.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.lblShippingLine.Width
    '    'Me.txtShippingLine.Left = Me.txtCallSign.Left

    '    'Me.lblFAX.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblFAX.Width
    '    'Me.txtFax.Left = Me.txtTELEX.Left

    '    '----

    'End Sub
    '    Private Sub UpdateFrame()
    '        On Error GoTo Err_Renamed

    '        Me.dgdPicLocal.Columns.Item("PicLocalID").Visible = False

    '        'Me.dgdPicLocal.Columns.Item("Voyage").Visible = Me.smnuDisplayVOYAGE.Checked
    '        Me.dgdPicLocal.Columns.Item("Nationality").Visible = Me.smnuDisplayNATIONALITY.Checked
    '        Me.dgdPicLocal.Columns.Item("Call_Sign").Visible = Me.smnuDisplayCALL_SIGN.Checked
    '        Me.dgdPicLocal.Columns.Item("Build").Visible = Me.smnuDisplayBUILD.Checked
    '        Me.dgdPicLocal.Columns.Item("Class1").Visible = Me.smnuDisplayCLASS.Checked
    '        Me.dgdPicLocal.Columns.Item("Pump_Capacity").Visible = Me.smnuDisplayPUMP_CAPACITY.Checked
    '        Me.dgdPicLocal.Columns.Item("SDWT").Visible = Me.smnuDisplaySDWT.Checked
    '        Me.dgdPicLocal.Columns.Item("GRT").Visible = Me.smnuDisplayGRT.Checked
    '        Me.dgdPicLocal.Columns.Item("NRT").Visible = Me.smnuDisplayNRT.Checked
    '        Me.dgdPicLocal.Columns.Item("LOA").Visible = Me.smnuDisplayLOA.Checked
    '        Me.dgdPicLocal.Columns.Item("BM").Visible = Me.smnuDisplayBM.Checked
    '        Me.dgdPicLocal.Columns.Item("DRAFT").Visible = Me.smnuDisplayDRAFT.Checked
    '        Me.dgdPicLocal.Columns.Item("TEL").Visible = Me.smnuDisplayTEL.Checked
    '        Me.dgdPicLocal.Columns.Item("FAX").Visible = Me.smnuDisplayFAX.Checked
    '        Me.dgdPicLocal.Columns.Item("MOBILE").Visible = Me.smnuDisplayMOBIL.Checked
    '        Me.dgdPicLocal.Columns.Item("EMAIL").Visible = Me.smnuDisplayEMAIL.Checked


    '        Me.dgdPicLocal.Columns.Item("CONTINUED").Visible = False
    '        Me.dgdPicLocal.Columns.Item("APPROVE").Visible = Me.smnuDisplayAPPROVE.Checked
    '        Me.dgdPicLocal.Columns.Item("UserId").Visible = Me.smnuDisplayUSERID.Checked
    '        Me.dgdPicLocal.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUPDATETIME.Checked
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    Private Sub QueryPicLocal(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPicLocal()
        Else
            strQuery = MakeQueryPicLocal(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "List")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPicLocal.DataSource = ds.Tables("List")
        If Me.dgdPicLocal.Enabled = False Then
            Me.dgdPicLocal.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdPicLocal.Rows.Count And Me.dgdPicLocal.Rows.Count > 0 Then
            Me.dgdPicLocal.Rows(location).Selected = True
            Me.dgdPicLocal.CurrentCell = Me.dgdPicLocal.Rows(location).Cells(1)
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdPicLocal.Columns.Item("PicName").ToolTipText = "Hiện có:" + CStr(Me.dgdPicLocal.RowCount()) + " PicLocals."
        End If
        If Me.dgdPicLocal.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Function MakeQueryPicLocal(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryPicLocal = strPicLocalSelect
        '        MakeQueryPicLocal = MakeQueryPicLocal & ", (SELECT count(*) FROM BillOfLading  WHERE PicLocal.PicLocalID = BillOfLading.PicLocalID) AS NumOfTransaction "
        MakeQueryPicLocal = MakeQueryPicLocal & " FROM PicLocal "
        MakeQueryPicLocal = MakeQueryPicLocal & "WHERE (PicLocalID = '" & DefaultValue & "') "

        MakeQueryPicLocal = MakeQueryPicLocal & "OR ("
        MakeQueryPicLocal = MakeQueryPicLocal & "Continued = 1 "
        MakeQueryPicLocal = MakeQueryPicLocal & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryPicLocal = MakeQueryPicLocal & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryPicLocal = MakeQueryPicLocal & strPicLocalOrder1
        ElseIf index = 15 Then ' 
            MakeQueryPicLocal = MakeQueryPicLocal & strPicLocalOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub frmListPicLocal_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmListPicLocal_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "List PicLocal "
        ElseIf mStatus = "Edit" Then
            Me.Text = " PicLocal-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "PicLocal-> Add."
        End If

    End Sub
    Private Sub smnuAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListPicLocal", "Add") Then
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mPicLocalId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdPicLocal.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.txtPicName.Text = Me.dgdPicLocal.Item("PicName", index).Value.ToString
        Me.txtDepartMent.Text = Me.dgdPicLocal.Item("DePartMent", index).Value.ToString
        'Me.txtVoyage.Text = Me.dgdPicLocal.Item("Voyage", index).Value.ToString
        Me.chkSchedule.Checked = Me.dgdPicLocal.Item("Schedule", index).Value.ToString

        Me.chkWebSite.Checked = Me.dgdPicLocal.Item("WebSite", index).Value.ToString

        Me.txtMobile.Text = Me.dgdPicLocal.Item("Mobile", index).Value.ToString
        'Me.txtNRT.Text = Me.dgdPicLocal.Item("NRT", index).Value.ToString
        Me.txtEmail.Text = Me.dgdPicLocal.Item("Email", index).Value.ToString
        Me.txtLocalNumber.Text = Me.dgdPicLocal.Item("LocalNumber", index).Value.ToString
        'Me.txtLOA.Text = Me.dgdPicLocal.Item("LOA", index).Value.ToString
        'Me.txtGRT.Text = Me.dgdPicLocal.Item("GRT", index).Value.ToString

        'Me.txtShippingLine.Text = Me.dgdPicLocal.Item("Shipping_Line", index).Value.ToString
        'Me.txtTELEX.Text = Me.dgdPicLocal.Item("TELEX", index).Value.ToString

        'Me.txtMobile.Text = Me.dgdPicLocal.Item("MOBILE", index).Value.ToString
        'Me.txtFax.Text = Me.dgdPicLocal.Item("Fax", index).Value.ToString
        'Me.txtEmail.Text = Me.dgdPicLocal.Item("EMAIL", index).Value.ToString
        'Me.txtDRAFT.Text = Me.dgdPicLocal.Item("DRAFT", index).Value.ToString
        'Me.txtClass.Text = Me.dgdPicLocal.Item("Class1", index).Value.ToString
        'Me.txtCallSign.Text = Me.dgdPicLocal.Item("Call_Sign", index).Value.ToString
        'Me.txtBUILD.Text = Me.dgdPicLocal.Item("BUILD", index).Value.ToString
        'Me.txtPortofRegister.Text = Me.dgdPicLocal.Item("PortOfRegister", index).Value.ToString
        'Me.txtShipOwner.Text = Me.dgdPicLocal.Item("ShipOwner", index).Value.ToString
        'Me.txtAddress.Text = Me.dgdPicLocal.Item("Address", index).Value.ToString
        'Me.txtTypeShip.Text = Me.dgdPicLocal.Item("TypeOfShip", index).Value.ToString
        'Me.txtPowerEngine.Text = Me.dgdPicLocal.Item("PowerOfEngine", index).Value.ToString
        'Me.txtAirDraft.Text = Me.dgdPicLocal.Item("AirDraft", index).Value.ToString
        'Me.txtLengthOver.Text = Me.dgdPicLocal.Item("LENGTHOVER", index).Value.ToString
        'Me.txtBreath.Text = Me.dgdPicLocal.Item("Breath", index).Value.ToString
        'Me.txtSpeed.Text = Me.dgdPicLocal.Item("Speed", index).Value.ToString
        'Me.txtDeadWeight.Text = Me.dgdPicLocal.Item("DeadWeight", index).Value.ToString
        'Me.txtGrossTonnage.Text = Me.dgdPicLocal.Item("GrossTonnage", index).Value.ToString
        'Me.txtNetTonnages.Text = Me.dgdPicLocal.Item("NetTonnage", index).Value.ToString


        ''''''''''''''''''''''''them 4-07-2007---------------------
        'Me.txtCASPCode.Text = Me.dgdPicLocal.Item("CASPCODE", index).Value.ToString
        'Me.txtOffical.Text = Me.dgdPicLocal.Item("OFFICAL", index).Value.ToString
        'Me.txtPlace.Text = Me.dgdPicLocal.Item("PLACE", index).Value.ToString
        'Me.txtIMONo.Text = Me.dgdPicLocal.Item("IMONO", index).Value.ToString
        'Me.txtManagermentName.Text = Me.dgdPicLocal.Item("NAMEMANAGERMENT", index).Value.ToString
        'Me.txtFlag.Text = Me.dgdPicLocal.Item("Flag", index).Value.ToString
        'Me.txtSUEZGT_NT.Text = Me.dgdPicLocal.Item("SUEZGT_NT", index).Value.ToString
        'Me.txtPanamaGT_NT.Text = Me.dgdPicLocal.Item("PANAMAGT_NT", index).Value.ToString
        'Me.txtCrane.Text = Me.dgdPicLocal.Item("CRANE", index).Value.ToString
        'Me.txtHatch_Hold.Text = Me.dgdPicLocal.Item("HATCH_HOLD", index).Value.ToString
        'Me.txtTeu_Feu.Text = Me.dgdPicLocal.Item("TEU_FEU", index).Value.ToString
        'Me.txtOndeck.Text = Me.dgdPicLocal.Item("OnDeck", index).Value.ToString
        'Me.txtInHold.Text = Me.dgdPicLocal.Item("InHold", index).Value.ToString
        'Me.txtDeepMoulDed.Text = Me.dgdPicLocal.Item("DeepMoulded", index).Value.ToString
        'Me.txtHOMO.Text = Me.dgdPicLocal.Item("HOMOTEU_NDW", index).Value.ToString
        'Me.txtREEFERPLUGS.Text = Me.dgdPicLocal.Item("REEFERPLUGS", index).Value.ToString
        'Me.txtMaxRefContainer.Text = Me.dgdPicLocal.Item("MaxREEFERCon", index).Value.ToString
        'Me.txtMaxStackLoad.Text = Me.dgdPicLocal.Item("MaxStackLoad", index).Value.ToString
        'Me.txtOnly20_40_45.Text = Me.dgdPicLocal.Item("Only20_40_45", index).Value.ToString
        'Me.txtMainEngineType.Text = Me.dgdPicLocal.Item("MainEngineType", index).Value.ToString
        'Me.txtportConsump.Text = Me.dgdPicLocal.Item("PortConsump", index).Value.ToString
        'Me.txtTankCapa.Text = Me.dgdPicLocal.Item("TankCapa", index).Value.ToString





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApprovePicLocal()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdPicLocal.CurrentRow.Index
        Dim strQueryPicLocalList As String
        If Not Me.dgdPicLocal.Item("Editable", index).Value Or Not UserRight("frmListPicLocal", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPicLocal(mFilter, , index)
        Else
            Dim rsPicLocalList As New ADODB.Recordset
            strQueryPicLocalList = "Select * from PicLocal where" + " PicLocalID= '" & Me.dgdPicLocal.Item("PicLocalID", index).Value.ToString & "'"
            rsPicLocalList.Open(strQueryPicLocalList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsPicLocalList.Fields("Approve").Value
            rsPicLocalList.Update("Approve", Approve)
            rsPicLocalList.Close()
            QueryPicLocal(mFilter, , )

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        strQuery = "Select * from PicLocal WHERE PicLocalID = '" & Me.dgdPicLocal.Item("PicLocalID", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, "Sorry, The PicLocal can not be removed.")
        '    Exit Sub
        'End If
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The PicLocal can not be removed. There are transactions that relate to this Booking.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdPicLocal.Item("Approve", index)) Then
            If Me.dgdPicLocal.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPicLocal.Item("Editable", index)) Then
            If Not Me.dgdPicLocal.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListPicLocal", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the PicLocal: " & Me.dgdPicLocal.Item("PicName", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                Dim rsPicLocalList As New ADODB.Recordset

                strQueryCommodityList = "Select * from PicLocal where" + " PicLocalID= '" & Me.dgdPicLocal.Item("PicLocalID", index).Value.ToString & "'"
                rsPicLocalList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsPicLocalList.Fields("continued").Value = 0
                rsPicLocalList.Update()

                rsPicLocalList.Requery()
                Me.dgdPicLocal.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdPicLocal.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsPicLocalList.Close()
                blnUpdated = True
            End If
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strPicLocalId As String
        'If mStatus = "Add" Then
        strPicLocalId = DefaultValue
        'If Me.txtPicLocalCode.Text = "" Then
        '    CheckData = False
        '    DisplayMessage(True, IIf(gLang = "E", "Code Not Allow Null Value", "Mã Không Đựơc Để Trống"))
        '    Exit Function
        'End If
        Dim strQueryCode As String
        Dim rsCode As New ADODB.Recordset
        strQueryCode = "SELECT PicName FROM PicLocal WHERE PicName='" & Me.txtPicName.Text & "' And Continued=1 And PicLocalID<>'" & mPicLocalId & "'"
        rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rsCode.EOF Then
            DisplayMessage(True, IIf(gLang = "E", "The PicName is already exist.", "Mã Tàu Đã Có"))
            rsCode.Close()
            CheckData = False
            Exit Function
        Else
            rsCode.Close()
        End If
        'End If
        'If Len(Me.txtPicLocalCode.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Code is invalid. Please check again."
        'End If
        'If Len(Me.TxtPicLocalName.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Name is invalid. Please check again."
        'End If



        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim strQuery, strPicLocalId As String
        Dim rsCode As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdPicLocal.Rows.Count > 0 Then
            index = Me.dgdPicLocal.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            Dim rs As New ADODB.Recordset

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM PicLocal "
            strQuery = strQuery & "WHERE PicLocalID = '" & mPicLocalId & "' AND PicLocalID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("PicLocalID").Value = NewId()
                End If
                strPicLocalId = .Fields("PicLocalID").Value
                'If mStatus = "Add" Then
                .Fields("PicName").Value = UCase(Trim(Me.txtPicName.Text))
                'End If
                .Fields("DePartMent").Value = UCase(Trim(Me.txtDepartMent.Text))
                '.Fields("VOYAGE").Value = UCase(Trim(Me.txtVoyage.Text))
                .Fields("Schedule").Value = IIf(Me.chkSchedule.Checked, 1, 0)

                .Fields("WebSite").Value = IIf(Me.chkWebSite.Checked, 1, 0)
                .Fields("Mobile").Value = UCase(Trim(Me.txtMobile.Text))

                .Fields("Email").Value = UCase(Trim(Me.txtEmail.Text))
                '.Fields("SHIPPING_LINE").Value = UCase(Trim(Me.txtShippingLine.Text))

                .Fields("LocalNumber").Value = UCase(Trim(Me.txtLocalNumber.Text))
                '.Fields("GRT").Value = UCase(Trim(Me.txtGRT.Text))
                '.Fields("NRT").Value = UCase(Trim(Me.txtNRT.Text))
                '.Fields("LOA").Value = UCase(Trim(Me.txtLOA.Text))
                '.Fields("CLASS").Value = UCase(Trim(Me.txtClass.Text))
                '.Fields("BM").Value = UCase(Trim(Me.txtBM.Text))
                '.Fields("DRAFT").Value = UCase(Trim(Me.txtDRAFT.Text))
                '.Fields("TEL").Value = UCase(Trim(Me.txtTell.Text))
                '.Fields("FAX").Value = UCase(Trim(Me.txtFax.Text))
                '.Fields("TELEX").Value = UCase(Trim(Me.txtTELEX.Text))
                '.Fields("MOBILE").Value = UCase(Trim(Me.txtMobile.Text))
                '.Fields("EMAIL").Value = UCase(Trim(Me.txtEmail.Text))
                '.Fields("TEL").Value = UCase(Trim(Me.txtTell.Text))
                '.Fields("FAX").Value = UCase(Trim(Me.txtFax.Text))
                '.Fields("TELEX").Value = UCase(Trim(Me.txtTELEX.Text))

                '.Fields("PortOfRegister").Value = UCase(Me.txtPortofRegister.Text.Trim)
                '.Fields("ShipOwner").Value = UCase(Me.txtShipOwner.Text.Trim)
                '.Fields("Address").Value = (Me.txtAddress.Text.Trim)
                '.Fields("TypeOfShip").Value = (Me.txtTypeShip.Text.Trim)
                '.Fields("PowerOfEngine").Value = (Me.txtPowerEngine.Text.Trim)
                '.Fields("AirDraft").Value = (Me.txtAirDraft.Text.Trim)
                '.Fields("LengthOver").Value = (Me.txtLengthOver.Text.Trim)
                '.Fields("Breath").Value = (Me.txtBreath.Text.Trim)
                '.Fields("Speed").Value = (Me.txtSpeed.Text.Trim)
                '.Fields("DeadWeight").Value = (Me.txtDeadWeight.Text.Trim)
                '.Fields("GrossTonnage").Value = (Me.txtGrossTonnage.Text.Trim)
                '.Fields("NetTonnage").Value = (Me.txtNetTonnages.Text.Trim)

                ''''''''''''''''''''''''''''''Them 04-7-2007
                '.Fields("CASPCODE").Value = Me.txtCASPCode.Text.Trim
                '.Fields("OFFICAL").Value = Me.txtOffical.Text.Trim
                '.Fields("PLACE").Value = Me.txtPlace.Text.Trim
                '.Fields("IMONO").Value = Me.txtIMONo.Text.Trim
                '.Fields("NAMEMANAGERMENT").Value = Me.txtManagermentName.Text.Trim
                '.Fields("Flag").Value = Me.txtFlag.Text.Trim
                '.Fields("SUEZGT_NT").Value = Me.txtSUEZGT_NT.Text.Trim
                '.Fields("PANAMAGT_NT").Value = Me.txtPanamaGT_NT.Text.Trim
                '.Fields("CRANE").Value = Me.txtCrane.Text.Trim
                '.Fields("HATCH_HOLD").Value = Me.txtHatch_Hold.Text.Trim
                '.Fields("TEU_FEU").Value = Me.txtTeu_Feu.Text.Trim
                '.Fields("OnDeck").Value = Me.txtOndeck.Text.Trim
                '.Fields("InHold").Value = Me.txtInHold.Text.Trim
                '.Fields("DeepMoulded").Value = Me.txtDeepMoulDed.Text.Trim
                '.Fields("HOMOTEU_NDW").Value = Me.txtHOMO.Text.Trim
                '.Fields("REEFERPLUGS").Value = Me.txtREEFERPLUGS.Text.Trim
                '.Fields("MaxREEFERCon").Value = Me.txtMaxRefContainer.Text.Trim
                '.Fields("MaxStackLoad").Value = Me.txtMaxStackLoad.Text.Trim
                '.Fields("Only20_40_45").Value = Me.txtOnly20_40_45.Text.Trim
                '.Fields("MainEngineType").Value = Me.txtMainEngineType.Text.Trim
                '.Fields("PortConsump").Value = Me.txtportConsump.Text.Trim
                '.Fields("TankCapa").Value = Me.txtTankCapa.Text.Trim

                .Update()
            End With
            rs.Close()
            Me.dgdPicLocal.Enabled = True
            If mStatus = "Edit" Then
                QueryPicLocal(, 1, index)
            Else
                QueryPicLocal(, 15, index)
            End If
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, "The Code :" & Me.txtPicName.Text & " have been added.")
        'Resume
    End Sub


    'Private Sub smnuDisplayNATIONALITY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNATIONALITY.Click
    '    Me.smnuDisplayNATIONALITY.Checked = Not Me.smnuDisplayNATIONALITY.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayCALL_SIGN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCALL_SIGN.Click
    '    Me.smnuDisplayCALL_SIGN.Checked = Not Me.smnuDisplayCALL_SIGN.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayBUILD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBUILD.Click
    '    Me.smnuDisplayBUILD.Checked = Not Me.smnuDisplayBUILD.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayCLASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCLASS.Click
    '    Me.smnuDisplayCLASS.Checked = Not Me.smnuDisplayCLASS.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayPUMP_CAPACITY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPUMP_CAPACITY.Click
    '    Me.smnuDisplayPUMP_CAPACITY.Checked = Not Me.smnuDisplayPUMP_CAPACITY.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplaySDWT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySDWT.Click
    '    Me.smnuDisplaySDWT.Checked = Not Me.smnuDisplaySDWT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayGRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayGRT.Click
    '    Me.smnuDisplayGRT.Checked = Not Me.smnuDisplayGRT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayNRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNRT.Click
    '    Me.smnuDisplayNRT.Checked = Not Me.smnuDisplayNRT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayLOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayLOA.Click
    '    Me.smnuDisplayLOA.Checked = Not Me.smnuDisplayLOA.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBM.Click
    '    Me.smnuDisplayBM.Checked = Not Me.smnuDisplayBM.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayDRAFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDRAFT.Click
    '    Me.smnuDisplayDRAFT.Checked = Not Me.smnuDisplayDRAFT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayTEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTEL.Click
    '    Me.smnuDisplayTEL.Checked = Not Me.smnuDisplayTEL.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayFAX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFAX.Click
    '    Me.smnuDisplayFAX.Checked = Not Me.smnuDisplayFAX.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayTELEX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTELEX.Click
    '    Me.smnuDisplayTELEX.Checked = Not Me.smnuDisplayTELEX.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayMOBIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMOBIL.Click
    '    Me.smnuDisplayMOBIL.Checked = Not Me.smnuDisplayMOBIL.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayEMAIL.Click
    '    Me.smnuDisplayEMAIL.Checked = Not Me.smnuDisplayEMAIL.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayAPPROVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayAPPROVE.Click
    '    Me.smnuDisplayAPPROVE.Checked = Not Me.smnuDisplayAPPROVE.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUSERID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUSERID.Click
    '    Me.smnuDisplayUSERID.Checked = Not Me.smnuDisplayUSERID.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUPDATETIME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUPDATETIME.Click
    '    Me.smnuDisplayUPDATETIME.Checked = Not Me.smnuDisplayUPDATETIME.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub smnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdPicLocal.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdPicLocal.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryPicLocal()
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.dgdPicLocal.Rows.Count > 0 Then
            index = Me.dgdPicLocal.CurrentRow.Index
        Else
            Exit Sub
        End If
        If index >= 0 Then
            Approve = Me.dgdPicLocal.Item("Approve", index).Value
            EditTable = Me.dgdPicLocal.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListPicLocal", "Edit") And Not Me.dgdPicLocal.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdPicLocal.Height = 306
                Me.dgdPicLocal.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mPicLocalId = Me.dgdPicLocal.Item("PicLocalID", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPicLocal_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPicLocal.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdPicLocal.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdPicLocal.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPicLocal.Columns(ColIndex).Name = "Approve" And Me.dgdPicLocal.CurrentCellAddress().Y = index Then
            Call ApprovePicLocal()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtPicLocal.Text)
    '        If Me.txtPicLocal.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtPicLocal.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdPicLocal)
    '            '    Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            Me.QueryPicLocal("AND ( PicName LIKE '" & strFilter & "') " & mFilter)
    '            '        Case "NAME"
    '            '            Me.QueryPicLocal("AND (PicLocal LIKE '" & strFilter & "' ) " & mFilter)
    '            '    End Select
    '            'Else
    '            '    QueryPicLocal(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryPicLocal("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdPicLocal.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdPicLocal, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

End Class