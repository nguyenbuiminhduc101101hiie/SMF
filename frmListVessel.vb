Public Class frmListVessel
    Inherits System.Windows.Forms.Form

    Dim rsVesselList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mVesselId As String

    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strVesselSelect As String = "SELECT * " ' & _
    '   "VESSEL_ID, " & _
    '   "VESSEL_CODE, " & _
    '   "VESSEL , " & _
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


    Const strVesselOrder1 As String = _
           " ORDER BY VESSEL_CODE  Desc "
    Const strVesselOrder2 As String = _
        " ORDER BY UpdateTime Desc "

    Private Sub frmListVessel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            objUserSetting.SetCParm("frmListVessel.txtVesselCode", Me.txtVesselCode.Text)
            objUserSetting.SetCParm("frmListVessel.txtVesselName", Me.TxtVesselName.Text)
            objUserSetting.GetCParm("frmListVessel.txtNATIONALITY", Me.txtNATIONALITY.Text)
            'objUserSetting.GetCParm("frmListVessel.txtVoyage", Me.txtVoyage.Text)
            objUserSetting.GetCParm("frmListVessel.txtCallSign", Me.txtCallSign.Text)
            objUserSetting.GetCParm("frmListVessel.txtTELEX", Me.txtTELEX.Text)
            objUserSetting.GetCParm("frmListVessel.txtBUILD", Me.txtBUILD.Text)
            objUserSetting.GetCParm("frmListVessel.txtClass", Me.txtClass.Text)
            objUserSetting.GetCParm("frmListVessel.txtEmail", Me.txtEMAIL.Text)
            objUserSetting.GetCParm("frmListVessel.txtMOBILE", Me.txtMOBILE.Text)
            objUserSetting.GetCParm("frmListVessel.txtEMAIL", Me.txtEMAIL.Text)
            objUserSetting.GetCParm("frmListVessel.txtPUMP_CAPACITY", Me.txtPUMP_CAPACITY.Text)
            'objUserSetting.GetCParm("frmListVessel.txtGRT", Me.txtGRT.Text)
            'objUserSetting.GetCParm("frmListVessel.txtNRT", Me.txtNRT.Text)
            objUserSetting.GetCParm("frmListVessel.txtSDWT", Me.txtSDWT.Text)
            objUserSetting.GetCParm("frmListVessel.txtLOA", Me.txtLOA.Text)
            objUserSetting.GetCParm("frmListVessel.txtDRAFT", Me.txtDRAFT.Text)
            objUserSetting.GetCParm("frmListVessel.txtTEL", Me.txtBM.Text)
            objUserSetting.GetCParm("frmListVessel.txtFax", Me.txtFax.Text)
            'objUserSetting.GetCParm("frmListVessel.txtSHIPPING_LINE", Me.txtShippingLine.Text)


            objUserSetting.SetBParm("frmListVessel.smnuDisplayAPPROVE", Me.smnuDisplayAPPROVE.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayBM", Me.smnuDisplayBM.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayBUILD", Me.smnuDisplayBUILD.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayCALL_SIGN", Me.smnuDisplayCALL_SIGN.Checked)

            objUserSetting.SetBParm("frmListVessel.smnuDisplayCLASS", Me.smnuDisplayCLASS.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayDRAFT", Me.smnuDisplayDRAFT.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayEMAIL", Me.smnuDisplayEMAIL.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayFAX", Me.smnuDisplayFAX.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayGRT", Me.smnuDisplayGRT.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayLOA", Me.smnuDisplayLOA.Checked)

            objUserSetting.SetBParm("frmListVessel.smnuDisplayMOBIL", Me.smnuDisplayMOBIL.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayNATIONALITY", Me.smnuDisplayNATIONALITY.Checked)

            objUserSetting.SetBParm("frmListVessel.smnuDisplayNRT", Me.smnuDisplayNRT.Checked)

            'objUserSetting.SetBParm("frmListVessel.smnuDisplayVOYAGE", Me.smnuDisplayVOYAGE.Checked)

            objUserSetting.SetBParm("frmListVessel.smnuDisplayPUMP_CAPACITY", Me.smnuDisplayPUMP_CAPACITY.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplaySDWT", Me.smnuDisplaySDWT.Checked)

            objUserSetting.SetBParm("frmListVessel.smnuDisplayTEL", Me.smnuDisplayTEL.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayTELEX", Me.smnuDisplayTELEX.Checked)

            objUserSetting.SetBParm("frmListVessel.smnuDisplayUPDATETIME", Me.smnuDisplayUPDATETIME.Checked)
            objUserSetting.SetBParm("frmListVessel.smnuDisplayUSERID", Me.smnuDisplayUSERID.Checked)
            Me.cmdCancel_Click(sender, e)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try

    End Sub


    Private Sub frmListVessel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mVesselId = DefaultValue
        SetDefaultGrid(Me.dgdVessel, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.TabControl1.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdVessel)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'Me.cboFind.Text = objUserSetting.GetCParm("frmListVessel.cboFind", "NAME")
        mFilter = objUserSetting.GetCParm("frmListVessel.mFilter")
        Me.txtVesselCode.Text = objUserSetting.GetCParm("frmListVessel.txtVesselCode")
        Me.txtVesselName.Text = objUserSetting.GetCParm("frmListVessel.txtVesselName")
        Me.txtNATIONALITY.Text = objUserSetting.GetCParm("frmListVessel.txtNATIONALITY")
        'Me.txtVoyage.Text = objUserSetting.GetCParm("frmListVessel.txtVoyage")
        Me.txtCallSign.Text = objUserSetting.GetCParm("frmListVessel.txtCallSign")
        Me.txtTELEX.Text = objUserSetting.GetCParm("frmListVessel.txtTELEX")
        Me.txtBUILD.Text = objUserSetting.GetCParm("frmListVessel.txtBUILD")
        Me.txtClass.Text = objUserSetting.GetCParm("frmListVessel.txtClass")
        Me.txtEMAIL.Text = objUserSetting.GetCParm("frmListVessel.txtEmail")
        Me.txtMOBILE.Text = objUserSetting.GetCParm("frmListVessel.txtMOBILE")
        Me.txtEMAIL.Text = objUserSetting.GetCParm("frmListVessel.txtEMAIL")
        Me.txtPUMP_CAPACITY.Text = objUserSetting.GetCParm("frmListVessel.txtPUMP_CAPACITY")
        'Me.txtGRT.Text = objUserSetting.GetCParm("frmListVessel.txtGRT")
        'Me.txtNRT.Text = objUserSetting.GetCParm("frmListVessel.txtNRT")
        Me.txtSDWT.Text = objUserSetting.GetCParm("frmListVessel.txtSDWT")
        Me.txtLOA.Text = objUserSetting.GetCParm("frmListVessel.txtLOA")
        Me.txtDRAFT.Text = objUserSetting.GetCParm("frmListVessel.txtDRAFT")
        Me.txtBM.Text = objUserSetting.GetCParm("frmListVessel.txtTEL")
        Me.txtFax.Text = objUserSetting.GetCParm("frmListVessel.txtFax")
        'Me.txtShippingLine.Text = objUserSetting.GetCParm("frmListVessel.txtSHIPPING_LINE")
        If Me.txtVessel.Text <> "" Then
            QueryVessel("AND VESSEL LIKE '" & MakeFilter(Me.txtVessel.Text) & "' " & mFilter, , )
        Else
            QueryVessel(mFilter, , )
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If


        ' Me.smnuDisplayVOYAGE.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayVOYAGE")
        'Me.smnuDisplayNATIONALITY.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayNATIONALITY")
        'Me.smnuDisplayCALL_SIGN.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayCALL_SIGN")
        'Me.smnuDisplayBUILD.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayBUILD")
        'Me.smnuDisplayCLASS.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayCLASS")
        'Me.smnuDisplayPUMP_CAPACITY.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayPUMP_CAPACITY")
        'Me.smnuDisplaySDWT.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplaySDWT")
        'Me.smnuDisplayGRT.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayGRT")
        'Me.smnuDisplayNRT.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayNRT")
        'Me.smnuDisplayLOA.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayLOA")
        'Me.smnuDisplayBM.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayBM")
        'Me.smnuDisplayDRAFT.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayDRAFT")
        'Me.smnuDisplayTEL.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayTEL")
        'Me.smnuDisplayFAX.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayFAX")
        'Me.smnuDisplayTELEX.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayTELEX")
        'Me.smnuDisplayMOBIL.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayMOBIL")
        'Me.smnuDisplayEMAIL.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayEMAIL")
        'Me.smnuDisplayAPPROVE.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayAPPROVE")

        'Me.smnuDisplayUSERID.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayUserId")
        'Me.smnuDisplayUPDATETIME.Checked = objUserSetting.GetBParm("frmListVessel.smnuDisplayUpdateTime")
        UpdateFrame()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        SetWidth()
        Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
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
        'If (Me.Height < IIf(Tabcontrol1.Visible, 540, 540)) Then
        '    Me.Height = IIf(Tabcontrol1.Visible, 540, 540)
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
        Me.dgdVessel.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            Me.dgdVessel.Height = Me.Height - cmdOK.Height - 10 - 60 - IIf(TabControl1.Visible, TabControl1.Height + 35, 40) '> 7000
        Else
            Me.dgdVessel.Height = Me.Height - cmdOK.Height - 10 - 110 - IIf(TabControl1.Visible, TabControl1.Height + 5, 40) ' < 7000
        End If
        TabControl1.Width = (Me.Width - 30)
        TabControl1.Top = Me.dgdVessel.Height + Me.dgdVessel.Top '+ 100
        'cmdCancel.Top = Me.TabControl1.Bottom + 10
        'Me.cmdOK.Top = Me.cmdCancel.Top
        'cmdCancel.Left = Me.TabControl1.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        cmdFind.Left = Me.txtVessel.Left + Me.txtVessel.Width + 10
        Me.txtVessel.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Public Sub SetWidth()
        '-------cot 1

        'Me.txtVessel.Width = Me.Width - 300
        'Me.TxtVesselName.Width = Me.fraUpdate.Width - Me.TxtVesselName.Left - Me.lblTELEX.Width - Me.txtTELEX.Width - 120
        'Me.lblTELEX.Left = Me.TxtVesselName.Right + 10
        'Me.txtTELEX.Left = Me.lblTELEX.Right + 3

        'Me.txtNATIONALITY.Width = Me.txtNATIONALITY.Right - Me.txtNATIONALITY.Left

        'Me.lblCALLSIGN.Left = Me.TxtVesselName.Right - Me.txtCallSign.Width - 3 - Me.lblCALLSIGN.Width

        'Me.txtCallSign.Left = Me.TxtVesselName.Right - Me.txtCallSign.Width
        'Me.txtCallSign.Width = Me.txtCallSign.Right - Me.txtCallSign.Left

        'Me.LBLCLASS.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLCLASS.Width
        'Me.txtClass.Left = Me.txtCallSign.Left

        'Me.lblMOBILE.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblMOBILE.Width
        'Me.txtMOBILE.Left = Me.txtTELEX.Left

        'Me.LBLGRT.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLGRT.Width
        'Me.txtGRT.Left = Me.txtClass.Left


        'Me.LBLEMAIL.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.LBLEMAIL.Width
        'Me.txtEMAIL.Left = Me.txtTELEX.Left

        'Me.lblTell.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblTell.Width
        'Me.txtTell.Left = Me.txtTELEX.Left

        'Me.LBLSDWT.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLSDWT.Width
        'Me.txtSDWT.Left = Me.txtCallSign.Left

        'Me.lbldraft.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.lbldraft.Width
        'Me.txtDRAFT.Left = Me.txtCallSign.Left

        'Me.lblShippingLine.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.lblShippingLine.Width
        'Me.txtShippingLine.Left = Me.txtCallSign.Left

        'Me.lblFAX.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblFAX.Width
        'Me.txtFax.Left = Me.txtTELEX.Left

        '----

    End Sub
    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        Me.dgdVessel.Columns.Item("VESSEL_ID").Visible = False
       
        'Me.dgdVessel.Columns.Item("Voyage").Visible = Me.smnuDisplayVOYAGE.Checked
        'Me.dgdVessel.Columns.Item("Nationality").Visible = Me.smnuDisplayNATIONALITY.Checked
        'Me.dgdVessel.Columns.Item("Call_Sign").Visible = Me.smnuDisplayCALL_SIGN.Checked
        'Me.dgdVessel.Columns.Item("Build").Visible = Me.smnuDisplayBUILD.Checked
        'Me.dgdVessel.Columns.Item("Class1").Visible = Me.smnuDisplayCLASS.Checked
        'Me.dgdVessel.Columns.Item("Pump_Capacity").Visible = Me.smnuDisplayPUMP_CAPACITY.Checked
        'Me.dgdVessel.Columns.Item("SDWT").Visible = Me.smnuDisplaySDWT.Checked
        'Me.dgdVessel.Columns.Item("GRT").Visible = Me.smnuDisplayGRT.Checked
        'Me.dgdVessel.Columns.Item("NRT").Visible = Me.smnuDisplayNRT.Checked
        'Me.dgdVessel.Columns.Item("LOA").Visible = Me.smnuDisplayLOA.Checked
        'Me.dgdVessel.Columns.Item("BM").Visible = Me.smnuDisplayBM.Checked
        'Me.dgdVessel.Columns.Item("DRAFT").Visible = Me.smnuDisplayDRAFT.Checked
        'Me.dgdVessel.Columns.Item("TEL").Visible = Me.smnuDisplayTEL.Checked
        'Me.dgdVessel.Columns.Item("FAX").Visible = Me.smnuDisplayFAX.Checked
        'Me.dgdVessel.Columns.Item("MOBILE").Visible = Me.smnuDisplayMOBIL.Checked
        'Me.dgdVessel.Columns.Item("EMAIL").Visible = Me.smnuDisplayEMAIL.Checked


        'Me.dgdVessel.Columns.Item("CONTINUED").Visible = False
        'Me.dgdVessel.Columns.Item("APPROVE").Visible = Me.smnuDisplayAPPROVE.Checked
        'Me.dgdVessel.Columns.Item("UserId").Visible = Me.smnuDisplayUSERID.Checked
        'Me.dgdVessel.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUPDATETIME.Checked
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub QueryVessel(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryVessel()
        Else
            strQuery = MakeQueryVessel(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "List")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdVessel.DataSource = ds.Tables("List")
        If Me.dgdVessel.Enabled = False Then
            Me.dgdVessel.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdVessel.Rows.Count And Me.dgdVessel.Rows.Count > 0 Then
            Me.dgdVessel.Rows(location).Selected = True
            Me.dgdVessel.CurrentCell = Me.dgdVessel.Rows(location).Cells(1)
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdVessel.Columns.Item("VESSEL_CODE").ToolTipText = "Hiện có:" + CStr(Me.dgdVessel.RowCount()) + " Vessels."
        End If
        If Me.dgdVessel.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Function MakeQueryVessel(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryVessel = strVesselSelect
        '        MakeQueryVessel = MakeQueryVessel & ", (SELECT count(*) FROM BillOfLading  WHERE VESSEL.VESSEL_ID = BillOfLading.VESSEL_ID) AS NumOfTransaction "
        MakeQueryVessel = MakeQueryVessel & " FROM VESSEL "
        MakeQueryVessel = MakeQueryVessel & "WHERE (VESSEL_ID = '" & DefaultValue & "') "

        MakeQueryVessel = MakeQueryVessel & "OR ("
        MakeQueryVessel = MakeQueryVessel & "Continued = 1 "
        MakeQueryVessel = MakeQueryVessel & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryVessel = MakeQueryVessel & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryVessel = MakeQueryVessel & strVesselOrder1
        ElseIf index = 15 Then ' 
            MakeQueryVessel = MakeQueryVessel & strVesselOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub frmListVessel_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmListVessel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
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
            Me.Text = "List Vessel "
        ElseIf mStatus = "Edit" Then
            Me.Text = " Vessel-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Vessel-> Add."
        End If

    End Sub
    Private Sub smnuAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListVessel", "Add") Then
            Me.TabControl1.Visible = True
            ReFormat()
            SetMenu((False))
            mVesselId = DefaultValue
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
        Me.TabControl1.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdVessel.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.txtVesselCode.Text = Me.dgdVessel.Item("Vessel_Code", index).Value.ToString
        Me.TxtVesselName.Text = Me.dgdVessel.Item("Vessel", index).Value.ToString
        'Me.txtVoyage.Text = Me.dgdVessel.Item("Voyage", index).Value.ToString
        Me.txtNATIONALITY.Text = Me.dgdVessel.Item("NATIONALITY", index).Value.ToString

        Me.txtPUMP_CAPACITY.Text = Me.dgdVessel.Item("PUMP_CAPACITY", index).Value.ToString

        Me.txtSDWT.Text = Me.dgdVessel.Item("SDWT", index).Value.ToString
        'Me.txtNRT.Text = Me.dgdVessel.Item("NRT", index).Value.ToString
        Me.txtBM.Text = Me.dgdVessel.Item("BM", index).Value.ToString
        Me.txtTell.Text = Me.dgdVessel.Item("Tel", index).Value.ToString
        Me.txtLOA.Text = Me.dgdVessel.Item("LOA", index).Value.ToString
        'Me.txtGRT.Text = Me.dgdVessel.Item("GRT", index).Value.ToString

        'Me.txtShippingLine.Text = Me.dgdVessel.Item("Shipping_Line", index).Value.ToString
        Me.txtTELEX.Text = Me.dgdVessel.Item("TELEX", index).Value.ToString

        Me.txtMOBILE.Text = Me.dgdVessel.Item("MOBILE", index).Value.ToString
        Me.txtFax.Text = Me.dgdVessel.Item("Fax", index).Value.ToString
        Me.txtEMAIL.Text = Me.dgdVessel.Item("EMAIL", index).Value.ToString
        Me.txtDRAFT.Text = Me.dgdVessel.Item("DRAFT", index).Value.ToString
        Me.txtClass.Text = Me.dgdVessel.Item("Class1", index).Value.ToString
        Me.txtCallSign.Text = Me.dgdVessel.Item("Call_Sign", index).Value.ToString
        Me.txtBUILD.Text = Me.dgdVessel.Item("BUILD", index).Value.ToString
        Me.txtPortofRegister.Text = Me.dgdVessel.Item("PortOfRegister", index).Value.ToString
        Me.txtShipOwner.Text = Me.dgdVessel.Item("ShipOwner", index).Value.ToString
        Me.txtAddress.Text = Me.dgdVessel.Item("Address", index).Value.ToString
        Me.txtTypeShip.Text = Me.dgdVessel.Item("TypeOfShip", index).Value.ToString
        Me.txtPowerEngine.Text = Me.dgdVessel.Item("PowerOfEngine", index).Value.ToString
        Me.txtAirDraft.Text = Me.dgdVessel.Item("AirDraft", index).Value.ToString
        Me.txtLengthOver.Text = Me.dgdVessel.Item("LENGTHOVER", index).Value.ToString
        Me.txtBreath.Text = Me.dgdVessel.Item("Breath", index).Value.ToString
        Me.txtSpeed.Text = Me.dgdVessel.Item("Speed", index).Value.ToString
        Me.txtDeadWeight.Text = Me.dgdVessel.Item("DeadWeight", index).Value.ToString
        Me.txtGrossTonnage.Text = Me.dgdVessel.Item("GrossTonnage", index).Value.ToString
        Me.txtNetTonnages.Text = Me.dgdVessel.Item("NetTonnage", index).Value.ToString


        ''''''''''''''''''''''''them 4-07-2007---------------------
        Me.txtCASPCode.Text = Me.dgdVessel.Item("CASPCODE", index).Value.ToString
        Me.txtOffical.Text = Me.dgdVessel.Item("OFFICAL", index).Value.ToString
        Me.txtPlace.Text = Me.dgdVessel.Item("PLACE", index).Value.ToString
        Me.txtIMONo.Text = Me.dgdVessel.Item("IMONO", index).Value.ToString
        Me.txtManagermentName.Text = Me.dgdVessel.Item("NAMEMANAGERMENT", index).Value.ToString
        Me.txtFlag.Text = Me.dgdVessel.Item("Flag", index).Value.ToString
        Me.txtSUEZGT_NT.Text = Me.dgdVessel.Item("SUEZGT_NT", index).Value.ToString
        Me.txtPanamaGT_NT.Text = Me.dgdVessel.Item("PANAMAGT_NT", index).Value.ToString
        Me.txtCrane.Text = Me.dgdVessel.Item("CRANE", index).Value.ToString
        Me.txtHatch_Hold.Text = Me.dgdVessel.Item("HATCH_HOLD", index).Value.ToString
        Me.txtTeu_Feu.Text = Me.dgdVessel.Item("TEU_FEU", index).Value.ToString
        Me.txtOndeck.Text = Me.dgdVessel.Item("OnDeck", index).Value.ToString
        Me.txtInHold.Text = Me.dgdVessel.Item("InHold", index).Value.ToString
        Me.txtDeepMoulDed.Text = Me.dgdVessel.Item("DeepMoulded", index).Value.ToString
        Me.txtHOMO.Text = Me.dgdVessel.Item("HOMOTEU_NDW", index).Value.ToString
        Me.txtREEFERPLUGS.Text = Me.dgdVessel.Item("REEFERPLUGS", index).Value.ToString
        Me.txtMaxRefContainer.Text = Me.dgdVessel.Item("MaxREEFERCon", index).Value.ToString
        Me.txtMaxStackLoad.Text = Me.dgdVessel.Item("MaxStackLoad", index).Value.ToString
        Me.txtOnly20_40_45.Text = Me.dgdVessel.Item("Only20_40_45", index).Value.ToString
        Me.txtMainEngineType.Text = Me.dgdVessel.Item("MainEngineType", index).Value.ToString
        Me.txtportConsump.Text = Me.dgdVessel.Item("PortConsump", index).Value.ToString
        Me.txtTankCapa.Text = Me.dgdVessel.Item("TankCapa", index).Value.ToString
        '-------------port of call
        Me.txtPortOfLoading.Text = Me.dgdVessel.Item("portofloading", index).Value.ToString
        Me.txtCountryCode.Text = Me.dgdVessel.Item("CountryCode", index).Value.ToString
        Me.txtAreaCode.Text = Me.dgdVessel.Item("AreaCode", index).Value.ToString




        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveVessel()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdVessel.CurrentRow.Index
        Dim strQueryVesselList As String
        If Not Me.dgdVessel.Item("Editable", index).Value Or Not UserRight("frmListVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryVessel(mFilter, , index)
        Else
            Dim rsVesselList As New ADODB.Recordset
            strQueryVesselList = "Select * from Vessel where" + " Vessel_Id= '" & Me.dgdVessel.Item("Vessel_ID", index).Value.ToString & "'"
            rsVesselList.Open(strQueryVesselList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsVesselList.Fields("Approve").Value
            rsVesselList.Update("Approve", Approve)
            rsVesselList.Close()
            QueryVessel(mFilter, , )

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
        strQuery = "Select count(*) cnt from NOTIFYVESSEL WHERE Vessel_Id = '" & Me.dgdVessel.Item("Vessel_Id", index).Value.ToString & "'  "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)

        rs.Close()
        strQuery = "Select * from Vessel WHERE Vessel_Id = '" & Me.dgdVessel.Item("Vessel_Id", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, "Sorry, The Vessel can not be removed.")
            Exit Sub
        End If
        If Not blnEmpty Then
            DisplayMessage(True, "The Vessel can not be removed. There are transactions that relate to this Booking.")
            Exit Sub
        End If
        If Not IsNothing(Me.dgdVessel.Item("Approve", index)) Then
            If Me.dgdVessel.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdVessel.Item("Editable", index)) Then
            If Not Me.dgdVessel.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Vessel: " & Me.dgdVessel.Item("Vessel_Code", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                Dim rsVesselList As New ADODB.Recordset

                strQueryCommodityList = "Select * from Vessel where" + " Vessel_Id= '" & Me.dgdVessel.Item("Vessel_ID", index).Value.ToString & "'"
                rsVesselList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsVesselList.Fields("continued").Value = 0
                rsVesselList.Update()

                rsVesselList.Requery()
                Me.dgdVessel.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdVessel.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsVesselList.Close()
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
        Dim strVesselId As String
        'If mStatus = "Add" Then
        strVesselId = DefaultValue
        If Me.txtVesselCode.Text = "" Then
            CheckData = False
            DisplayMessage(True, IIf(gLang = "E", "Code Not Allow Null Value", "Mã Không Đựơc Để Trống"))
            Exit Function
        End If
        Dim strQueryCode As String
        Dim rsCode As New ADODB.Recordset
        strQueryCode = "SELECT VESSEL_CODE FROM VESSEL WHERE VESSEL_CODE='" & Me.txtVesselCode.Text & "' And Continued=1 And Vessel_ID<>'" & mVesselId & "'"
        rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rsCode.EOF Then
            DisplayMessage(True, IIf(gLang = "E", "The VESSEL_CODE is already exist.", "Mã Tàu Đã Có"))
            rsCode.Close()
            CheckData = False
            Exit Function
        Else
            rsCode.Close()
        End If
        'End If
        If Len(Me.txtVesselCode.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Code is invalid. Please check again."
        End If
        If Len(Me.TxtVesselName.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Name is invalid. Please check again."
        End If



        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim strQuery, strVesselId As String
        Dim rsCode As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdVessel.Rows.Count > 0 Then
            index = Me.dgdVessel.CurrentRow.Index
        End If
        'If Me.txtPortOfLoading.Text.Length = 0 Or Me.txtCountryCode.Text.Length = 0 Or Me.txtAreaCode.Text.Length = 0 Then
        '    DisplayMessage(True, "Please check Port of call .!")
        '    Return
        'End If
        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            Dim rs As New ADODB.Recordset

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM VESSEL "
            strQuery = strQuery & "WHERE VESSEL_ID = '" & mVesselId & "' AND VESSEL_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("VESSEL_ID").Value = NewId()
                End If
                strVesselId = .Fields("VESSEL_ID").Value
                'If mStatus = "Add" Then
                .Fields("VESSEL_CODE").Value = UCase(Trim(Me.txtVesselCode.Text))
                'End If
                .Fields("VESSEL").Value = UCase(Trim(Me.TxtVesselName.Text))
                '.Fields("VOYAGE").Value = UCase(Trim(Me.txtVoyage.Text))
                .Fields("NATIONALITY").Value = UCase(Trim(Me.txtNATIONALITY.Text))
                .Fields("CALL_SIGN").Value = UCase(Trim(Me.txtCallSign.Text))
                .Fields("BUILD").Value = UCase(Trim(Me.txtBUILD.Text))

                .Fields("PUMP_CAPACITY").Value = UCase(Trim(Me.txtPUMP_CAPACITY.Text))
                '.Fields("SHIPPING_LINE").Value = UCase(Trim(Me.txtShippingLine.Text))

                .Fields("SDWT").Value = UCase(Trim(Me.txtSDWT.Text))
                '.Fields("GRT").Value = UCase(Trim(Me.txtGRT.Text))
                '.Fields("NRT").Value = UCase(Trim(Me.txtNRT.Text))
                .Fields("LOA").Value = UCase(Trim(Me.txtLOA.Text))
                .Fields("CLASS").Value = UCase(Trim(Me.txtClass.Text))
                .Fields("BM").Value = UCase(Trim(Me.txtBM.Text))
                .Fields("DRAFT").Value = UCase(Trim(Me.txtDRAFT.Text))
                .Fields("TEL").Value = UCase(Trim(Me.txtTell.Text))
                .Fields("FAX").Value = UCase(Trim(Me.txtFax.Text))
                .Fields("TELEX").Value = UCase(Trim(Me.txtTELEX.Text))
                .Fields("MOBILE").Value = UCase(Trim(Me.txtMOBILE.Text))
                .Fields("EMAIL").Value = UCase(Trim(Me.txtEMAIL.Text))
                .Fields("TEL").Value = UCase(Trim(Me.txtTell.Text))
                .Fields("FAX").Value = UCase(Trim(Me.txtFax.Text))
                .Fields("TELEX").Value = UCase(Trim(Me.txtTELEX.Text))

                .Fields("PortOfRegister").Value = UCase(Me.txtPortofRegister.Text.Trim)
                .Fields("ShipOwner").Value = UCase(Me.txtShipOwner.Text.Trim)
                .Fields("Address").Value = (Me.txtAddress.Text.Trim)
                .Fields("TypeOfShip").Value = (Me.txtTypeShip.Text.Trim)
                .Fields("PowerOfEngine").Value = (Me.txtPowerEngine.Text.Trim)
                .Fields("AirDraft").Value = (Me.txtAirDraft.Text.Trim)
                .Fields("LengthOver").Value = (Me.txtLengthOver.Text.Trim)
                .Fields("Breath").Value = (Me.txtBreath.Text.Trim)
                .Fields("Speed").Value = (Me.txtSpeed.Text.Trim)
                .Fields("DeadWeight").Value = (Me.txtDeadWeight.Text.Trim)
                .Fields("GrossTonnage").Value = (Me.txtGrossTonnage.Text.Trim)
                .Fields("NetTonnage").Value = (Me.txtNetTonnages.Text.Trim)

                '''''''''''''''''''''''''''''Them 04-7-2007
                .Fields("CASPCODE").Value = Me.txtCASPCode.Text.Trim
                .Fields("OFFICAL").Value = Me.txtOffical.Text.Trim
                .Fields("PLACE").Value = Me.txtPlace.Text.Trim
                .Fields("IMONO").Value = Me.txtIMONo.Text.Trim
                .Fields("NAMEMANAGERMENT").Value = Me.txtManagermentName.Text.Trim
                .Fields("Flag").Value = Me.txtFlag.Text.Trim
                .Fields("SUEZGT_NT").Value = Me.txtSUEZGT_NT.Text.Trim
                .Fields("PANAMAGT_NT").Value = Me.txtPanamaGT_NT.Text.Trim
                .Fields("CRANE").Value = Me.txtCrane.Text.Trim
                .Fields("HATCH_HOLD").Value = Me.txtHatch_Hold.Text.Trim
                .Fields("TEU_FEU").Value = Me.txtTeu_Feu.Text.Trim
                .Fields("OnDeck").Value = Me.txtOndeck.Text.Trim
                .Fields("InHold").Value = Me.txtInHold.Text.Trim
                .Fields("DeepMoulded").Value = Me.txtDeepMoulDed.Text.Trim
                .Fields("HOMOTEU_NDW").Value = Me.txtHOMO.Text.Trim
                .Fields("REEFERPLUGS").Value = Me.txtREEFERPLUGS.Text.Trim
                .Fields("MaxREEFERCon").Value = Me.txtMaxRefContainer.Text.Trim
                .Fields("MaxStackLoad").Value = Me.txtMaxStackLoad.Text.Trim
                .Fields("Only20_40_45").Value = Me.txtOnly20_40_45.Text.Trim
                .Fields("MainEngineType").Value = Me.txtMainEngineType.Text.Trim
                .Fields("PortConsump").Value = Me.txtportConsump.Text.Trim
                .Fields("TankCapa").Value = Me.txtTankCapa.Text.Trim

                '----port of call
                .Fields("portofcall").Value = Me.txtPortOfLoading.Text.Trim
                .Fields("CountryCode").Value = Me.txtCountryCode.Text.Trim
                .Fields("AreaCode").Value = Me.txtAreaCode.Text.Trim

                '-------------------------
                .Update()
            End With
            rs.Close()
            Me.dgdVessel.Enabled = True
            If mStatus = "Edit" Then
                QueryVessel(, 1, index)
            Else
                QueryVessel(, 15, index)
            End If
            Me.TabControl1.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, "The Code :" & Me.txtVesselCode.Text & " have been added.")
        'Resume
    End Sub


    Private Sub smnuDisplayNATIONALITY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNATIONALITY.Click
        Me.smnuDisplayNATIONALITY.Checked = Not Me.smnuDisplayNATIONALITY.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCALL_SIGN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCALL_SIGN.Click
        Me.smnuDisplayCALL_SIGN.Checked = Not Me.smnuDisplayCALL_SIGN.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayBUILD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBUILD.Click
        Me.smnuDisplayBUILD.Checked = Not Me.smnuDisplayBUILD.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCLASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCLASS.Click
        Me.smnuDisplayCLASS.Checked = Not Me.smnuDisplayCLASS.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPUMP_CAPACITY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPUMP_CAPACITY.Click
        Me.smnuDisplayPUMP_CAPACITY.Checked = Not Me.smnuDisplayPUMP_CAPACITY.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplaySDWT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySDWT.Click
        Me.smnuDisplaySDWT.Checked = Not Me.smnuDisplaySDWT.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayGRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayGRT.Click
        Me.smnuDisplayGRT.Checked = Not Me.smnuDisplayGRT.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNRT.Click
        Me.smnuDisplayNRT.Checked = Not Me.smnuDisplayNRT.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayLOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayLOA.Click
        Me.smnuDisplayLOA.Checked = Not Me.smnuDisplayLOA.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBM.Click
        Me.smnuDisplayBM.Checked = Not Me.smnuDisplayBM.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayDRAFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDRAFT.Click
        Me.smnuDisplayDRAFT.Checked = Not Me.smnuDisplayDRAFT.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTEL.Click
        Me.smnuDisplayTEL.Checked = Not Me.smnuDisplayTEL.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayFAX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFAX.Click
        Me.smnuDisplayFAX.Checked = Not Me.smnuDisplayFAX.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTELEX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTELEX.Click
        Me.smnuDisplayTELEX.Checked = Not Me.smnuDisplayTELEX.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayMOBIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMOBIL.Click
        Me.smnuDisplayMOBIL.Checked = Not Me.smnuDisplayMOBIL.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayEMAIL.Click
        Me.smnuDisplayEMAIL.Checked = Not Me.smnuDisplayEMAIL.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayAPPROVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayAPPROVE.Click
        Me.smnuDisplayAPPROVE.Checked = Not Me.smnuDisplayAPPROVE.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUSERID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUSERID.Click
        Me.smnuDisplayUSERID.Checked = Not Me.smnuDisplayUSERID.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUPDATETIME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUPDATETIME.Click
        Me.smnuDisplayUPDATETIME.Checked = Not Me.smnuDisplayUPDATETIME.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdVessel.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdVessel.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryVessel()
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdVessel.CurrentRow.Index
        Else
            Exit Sub
        End If
        If index >= 0 Then
            Approve = Me.dgdVessel.Item("Approve", index).Value
            EditTable = Me.dgdVessel.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListVessel", "Edit") And Not Me.dgdVessel.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdVessel.Height = 306
                Me.dgdVessel.Enabled = False
                Me.TabControl1.Visible = True
                ReFormat()
                SetMenu((False))

                mVesselId = Me.dgdVessel.Item("Vessel_Id", index).Value.ToString
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

    Private Sub dgdVessel_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdVessel.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdVessel.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdVessel.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdVessel.Columns(ColIndex).Name = "Approve" And Me.dgdVessel.CurrentCellAddress().Y = index Then
            Call ApproveVessel()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtVessel.Text)
        If Me.txtVessel.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtVessel.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdVessel)
            '    Select Case cboFind.Text
            '        Case "CODE"
            '            Me.QueryVessel("AND ( VESSEL_CODE LIKE '" & strFilter & "') " & mFilter)
            '        Case "NAME"
            '            Me.QueryVessel("AND (VESSEL LIKE '" & strFilter & "' ) " & mFilter)
            '    End Select
            'Else
            '    QueryVessel(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryVessel("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdVessel.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdVessel, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSelect.Click
        If Me.dgdVessel.SelectedRows.Count > 0 Then
            Dim index As Integer = Me.dgdVessel.CurrentRow.Index
            gSearchID = Me.dgdVessel.Item("Vessel_ID", index).Value.ToString
            SearchCombo()
            Me.Close()
        End If
    End Sub

    Private Sub txtVessel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVessel.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        'Me.TabControl1.Visible = Me.fraUpdate.Visible
    End Sub

    
   
End Class