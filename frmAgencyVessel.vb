Imports Excel
Public Class frmAgencyVessel


    Dim rsTerminalDepartureList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mTerminalDeparture_ID As String
    '------------------
    Public oTable As DataSet
    Public tblPort As New DataSet
    Public tblLoadingSummary As New DataSet
    Dim tblContainerPended As New DataSet
    Dim tblDischargeDetail As New DataSet
    Dim tblLoadingDetail As New DataSet
    Dim tblCargoSummary As New DataSet
    Dim tblCVTLoading As New DataSet
    Public ds As New DataSet

    Dim mLoadingSummary_ID As String
    Dim mContainerPended_ID As String
    Dim mDisCharheDetail_ID As String
    Dim mLoadingDetail_ID As String
    Dim mCargoSummary_ID As String
    Dim mCVTLoading_ID As String

    Dim mStatusLS As String 'Laoding Summary
    Dim mStatusCP As String 'Container Pended
    Dim mStatusDS As String 'Discharge Detail
    Dim mStatusLD As String 'Loading Detail
    Dim mStatusCS As String 'Cargo Summary
    Dim mStatusCVT As String

    Const strTerminalDepartureSelect As String = "SELECT " & _
        "TerminalDeparture.*, " & _
        "Vessel.Vessel, " & _
        "port.Port_Code "

    Function CheckSDate(ByVal st As String) As Boolean
        Try
            Dim M() As String = st.Split(" ")
            If M.Length <> 3 Then
                Return False
            End If
            If M(0).Trim.Length <> 4 Then
                Return False
            End If
            If M(1).Trim.Length <> 3 Then
                Return False
            End If
            If M(2).Trim.Length <> 7 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String
        CheckData = True
        Msg = ""

        If FindValueID(Me.cboPort, Me.cboPort.Text.Trim) = "" Then
            Msg &= "The Port is invalid."
        End If
        If FindValueID(Me.cboVessel, Me.cboVessel.Text.Trim) = "" Then
            Msg &= "The Vessel is invalid"
        End If

        If CheckSDate(Me.txtArrivalPilot_A.Text.Trim) = False Then
            Msg &= "The Arrival Pilot is invalid.(HHMM MMM DD,YYYY) "
        End If
        If CheckSDate(Me.txtPilotOnBoard_A.Text.Trim) = False Then
            Msg &= "The Pilot On Board Arrival is invalid. (HHMM MMM DD,YYYY)"
        End If
        If CheckSDate(Me.txtFirstLine.Text.Trim) = False Then
            Msg &= "The First Line is invalid.(HHMM MMM DD,YYYY)"
        End If
        If CheckSDate(Me.txtCommenced.Text.Trim) = False Then
            Msg &= "The Commenced is invalid.(HHMM MMM DD,YYYY) "
        End If

        If CheckSDate(Me.txtPilotOnBoard_D.Text.Trim) = False Then
            Msg &= "The Pilot On Board Departure is invalid. (HHMM MMM DD,YYYY)"
        End If
        If CheckSDate(Me.txtLastLine.Text.Trim) = False Then
            Msg &= "The Last Line is invalid.(HHMM MMM DD,YYYY)"
        End If
        If CheckSDate(Me.txtFineshed.Text.Trim) = False Then
            Msg &= "The Finished is invalid.(HHMM MMM DD,YYYY) "
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function CheckDataLS() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String

        Msg = ""

        If Me.chk20GP.Checked = True Then
            If IsNumeric(Me.txt20GP.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GP.Checked = True Then
            If IsNumeric(Me.txt40GP.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If Me.chk40HC.Checked = True Then
            If IsNumeric(Me.txt40HC.Text.Trim) = False Then
                Msg &= "The 40HC is invalid"
            End If
        End If

        If Me.chk20RF.Checked = True Then
            If IsNumeric(Me.txt20RF.Text.Trim) = False Then
                Msg &= "The 20RF is invalid"
            End If
        End If

        If Me.chk40RH.Checked = True Then
            If IsNumeric(Me.txt40RH.Text.Trim) = False Then
                Msg &= "The 40RH is invalid"
            End If
        End If

        If Me.chk45.Checked = True Then
            If IsNumeric(Me.txt45.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function CheckDataCVT() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String

        Msg = ""

        If FindValueID(Me.cboPortPODCVT, Me.cboPortPODCVT.Text.Trim) = "" Then
            Msg &= "The port of Discharge is invalid"
        End If

        If FindValueID(Me.cboDEST, Me.cboDEST.Text.Trim) = "" Then
            Msg &= "The Destination is invalid"
        End If

        If Me.chk20GPCVT.Checked = True Then
            If IsNumeric(Me.txt20GPCVT.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GPCVT.Checked = True Then
            If IsNumeric(Me.txt40GPCVT.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If Me.chk40HQCVT.Checked = True Then
            If IsNumeric(Me.txt40HQCVT.Text.Trim) = False Then
                Msg &= "The 40HQ is invalid"
            End If
        End If

        If Me.chk20RFCVT.Checked = True Then
            If IsNumeric(Me.txt20RFCVT.Text.Trim) = False Then
                Msg &= "The 20RF is invalid"
            End If
        End If

        If Me.chk40RHCVT.Checked = True Then
            If IsNumeric(Me.txt40RHCVT.Text.Trim) = False Then
                Msg &= "The 40RH is invalid"
            End If
        End If

        If Me.chk20ECVT.Checked = True Then
            If IsNumeric(Me.txt20ECVT.Text.Trim) = False Then
                Msg &= "The 20E is invalid"
            End If
        End If

        If Me.chk40ECVT.Checked = True Then
            If IsNumeric(Me.txt40ECVT.Text.Trim) = False Then
                Msg &= "The 40E is invalid"
            End If
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function CheckDataCS() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String

        Msg = ""

        If Me.chk20CG.Checked = True Then
            If IsNumeric(Me.txt20CG.Text.Trim) = False Then
                Msg &= "The 20 is invalid"
            End If
        End If

        If Me.chk40CG.Checked = True Then
            If IsNumeric(Me.txt40CG.Text.Trim) = False Then
                Msg &= "The 40 is invalid"
            End If
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function CheckDataCP() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String

        Msg = ""

        If Me.chk20GPLocal.Checked = True Then
            If IsNumeric(Me.txt20GPLocal.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GPLocal.Checked = True Then
            If IsNumeric(Me.txt40GPLocal.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If Me.chk20GPTrans.Checked = True Then
            If IsNumeric(Me.txt20GPTrans.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GPTrans.Checked = True Then
            If IsNumeric(Me.txt40GPTrans.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If FindValueID(Me.cboPortPODLocal, Me.cboPortPODLocal.Text.Trim) = "" Then
            Msg &= "The Port of Discharge Local is invalid"
        End If

        If FindValueID(Me.cboPortPODTrans, Me.cboPortPODTrans.Text.Trim) = "" Then
            Msg &= "The Port of Discharge Transfer is invalid"
        End If

        If FindValueID(Me.cboPortPORTrans, Me.cboPortPORTrans.Text.Trim) = "" Then
            Msg &= "The Port of Receive Transfer is invalid"
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function CheckDataDS() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String

        Msg = ""

        If FindValueID(Me.cboPortPOL, Me.cboPortPOL.Text.Trim) = "" Then
            Msg &= "The Port of Loading is invalid"
        End If

        If Me.chk20GPFullDis.Checked = True Then
            If IsNumeric(Me.txt20GPFullDis.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GPFullDis.Checked = True Then
            If IsNumeric(Me.txt40GPFullDis.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If Me.chk40HCFullDis.Checked = True Then
            If IsNumeric(Me.txt40HCFullDis.Text.Trim) = False Then
                Msg &= "The 40HC is invalid"
            End If
        End If

        If Me.chk20RFFullDis.Checked = True Then
            If IsNumeric(Me.txt20RFFullDis.Text.Trim) = False Then
                Msg &= "The 20RF is invalid"
            End If
        End If

        If Me.chk40RHFullDis.Checked = True Then
            If IsNumeric(Me.txt40RHFullDis.Text.Trim) = False Then
                Msg &= "The 40RH is invalid"
            End If
        End If

        If Me.chk45FullDis.Checked = True Then
            If IsNumeric(Me.txt45FullDis.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        If Me.chk20EmptyDis.Checked = True Then
            If IsNumeric(Me.txt20EmptyDis.Text.Trim) = False Then
                Msg &= "The 20 is invalid"
            End If
        End If

        If Me.chk40EmptyDis.Checked = True Then
            If IsNumeric(Me.txt40EmptyDis.Text.Trim) = False Then
                Msg &= "The 40 is invalid"
            End If
        End If

        If Me.chk45EmptyDis.Checked = True Then
            If IsNumeric(Me.txt45EmptyDis.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Function CheckDataLD() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String

        Msg = ""

        If FindValueID(Me.cboPortPOD, Me.cboPortPOD.Text.Trim) = "" Then
            Msg &= "The Port of Discharge is invalid"
        End If

        'Dim tbl As New DataSet
        'tbl = ReadDataSet("Select count(*)  as cnt From LoadingDetail Where Port_ID='" & FindValueID(Me.cboPortPOD, Me.cboPortPOD.Text.Trim) & "'")
        'If tbl.Tables(0).Rows(0).Item("cnt") = 2 And mStatusLD = "Add" Then
        '    Msg &= "Port đã tồn tại"
        'End If

        If Me.chk20GPSubFull.Checked = True Then
            If IsNumeric(Me.txt20GPSubFull.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GPSubFull.Checked = True Then
            If IsNumeric(Me.txt40GPSubFull.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If Me.chk40HCSubFull.Checked = True Then
            If IsNumeric(Me.txt40HCSubFull.Text.Trim) = False Then
                Msg &= "The 40HC is invalid"
            End If
        End If

        If Me.chk20RFSubFull.Checked = True Then
            If IsNumeric(Me.txt20RFSubFull.Text.Trim) = False Then
                Msg &= "The 20RF is invalid"
            End If
        End If

        If Me.chk40RHSubFull.Checked = True Then
            If IsNumeric(Me.txt40RHSubFull.Text.Trim) = False Then
                Msg &= "The 40RH is invalid"
            End If
        End If

        If Me.chk45SubFull.Checked = True Then
            If IsNumeric(Me.txt45SubFull.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        If Me.chk20subEmpTy.Checked = True Then
            If IsNumeric(Me.txt20SubEmpty.Text.Trim) = False Then
                Msg &= "The 20 is invalid"
            End If
        End If

        If Me.chk40SubEmpty.Checked = True Then
            If IsNumeric(Me.txt40SubEmpty.Text.Trim) = False Then
                Msg &= "The 40 is invalid"
            End If
        End If

        If Me.chk45SubEmpty.Checked = True Then
            If IsNumeric(Me.txt45SubEmpty.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        '--------
        If Me.chk20GPTSFull.Checked = True Then
            If IsNumeric(Me.txt20GPTSFull.Text.Trim) = False Then
                Msg &= "The 20GP is invalid"
            End If
        End If

        If Me.chk40GPTSFull.Checked = True Then
            If IsNumeric(Me.txt40GPTSFull.Text.Trim) = False Then
                Msg &= "The 40GP is invalid"
            End If
        End If

        If Me.chk40HCTSFull.Checked = True Then
            If IsNumeric(Me.txt40HCTSFull.Text.Trim) = False Then
                Msg &= "The 40HC is invalid"
            End If
        End If

        If Me.chk20RFTSFull.Checked = True Then
            If IsNumeric(Me.txt20RFTSFull.Text.Trim) = False Then
                Msg &= "The 20RF is invalid"
            End If
        End If

        If Me.chk40RHTSFull.Checked = True Then
            If IsNumeric(Me.txt40RHTSFull.Text.Trim) = False Then
                Msg &= "The 40RH is invalid"
            End If
        End If

        If Me.chk45TSFull.Checked = True Then
            If IsNumeric(Me.txt45TSFull.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        If Me.chk20TSEmpty.Checked = True Then
            If IsNumeric(Me.txt20TSEmpty.Text.Trim) = False Then
                Msg &= "The 20 is invalid"
            End If
        End If

        If Me.chk40TSEmpty.Checked = True Then
            If IsNumeric(Me.txt40TSEmpty.Text.Trim) = False Then
                Msg &= "The 40 is invalid"
            End If
        End If

        If Me.chkSlot20.Checked = True Then
            If IsNumeric(Me.txtSlot20.Text.Trim) = False Then
                Msg &= "The 20 is invalid"
            End If
        End If

        If Me.chkSlot45.Checked = True Then
            If IsNumeric(Me.txtSlot45.Text.Trim) = False Then
                Msg &= "The 20 is invalid"
            End If
        End If

        If Me.chk45TSEmpty.Checked = True Then
            If IsNumeric(Me.txt45TSEmpty.Text.Trim) = False Then
                Msg &= "The 45 is invalid"
            End If
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmAgencyVessel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mStatusLS = "Normal"
        mStatusCP = "Normal"
        mStatusDS = "Normal"
        mStatusLD = "Normal"
        mStatusCS = "Normal"
        mStatusCVT = "Normal"
        blnUpdated = False
        mTerminalDeparture_ID = DefaultValue
        mLoadingSummary_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "TerminalDeparture Code", "TerminalDeparture Code")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "TerminalDeparture", "TerminalDeparture")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmAgencyVessel.cboFind", "TerminalDeparture")
        mFilter = objUserSetting.GetCParm("frmAgencyVessel.mFilter")
        Me.txtArrivalPilot_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtArrivalPilot_A")
        Me.txtPilotOnBoard_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtPilotOnBoard_A")
        Me.txtPilotOnBoard_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtPilotOnBoard_D")
        Me.txtFirstLine.Text = objUserSetting.GetCParm("frmAgencyVessel.txtFirstLine")
        Me.txtLastLine.Text = objUserSetting.GetCParm("frmAgencyVessel.txtLastLine")
        Me.txtCommenced.Text = objUserSetting.GetCParm("frmAgencyVessel.txtCommenced")
        Me.txtFineshed.Text = objUserSetting.GetCParm("frmAgencyVessel.txtFineshed")
        Me.txtFO_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtFO_A")
        Me.txtFO_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtFO_D")
        Me.txtDO_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtDO_A")
        Me.txtDO_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtDO_D")
        Me.txtFreshWater_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtFreshWater_A")
        Me.txtFreshWater_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtFreshWater_D")
        Me.txtDraftAft_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtDraftAft_A")
        Me.txtDraftAft_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtDraftAft_D")
        Me.txtDraftFwd_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtDraftFwd_A")
        Me.txtDraftFwd_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtDraftFwd_D")
        Me.txtTTLEmptyCNTR_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTTLEmptyCNTR_A")
        Me.txtTTLEmptyCNTR_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTTLEmptyCNTR_D")
        Me.txtTTLFullCNTR_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTTLFullCNTR_A")
        Me.txtTTLFullCNTR_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTTLFullCNTR_D")
        Me.txtTTLGrossWeight_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTTLGrossWeight_A")
        Me.txtGrossWeight_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtGrossWeight_D")
        Me.txtTugsIn.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTugsIn")
        Me.txtTugsOut.Text = objUserSetting.GetCParm("frmAgencyVessel.txtTugsOut")
        Me.txtReMarks_A.Text = objUserSetting.GetCParm("frmAgencyVessel.txtReMarks_A")
        Me.txtRemarks_D.Text = objUserSetting.GetCParm("frmAgencyVessel.txtRemarks_D")
        Me.txtPortTime.Text = objUserSetting.GetCParm("frmAgencyVessel.")
        Me.txtOperationTime.Text = objUserSetting.GetCParm("frmAgencyVessel.txtOperationTime")
        Me.txtBerthedTime.Text = objUserSetting.GetCParm("frmAgencyVessel.txtBerthedTime")
        Me.txtCashToCaption.Text = objUserSetting.GetCParm("frmAgencyVessel.txtCashToCaption")
        Me.txtNextPortCall.Text = objUserSetting.GetCParm("frmAgencyVessel.txtNextPortCall")
        Me.txtETANextPort.Text = objUserSetting.GetCParm("frmAgencyVessel.txtETANextPort")
        Me.txtHatchCover.Text = objUserSetting.GetCParm("frmAgencyVessel.txtHatchCover")
        Me.txtGM.Text = objUserSetting.GetCParm("frmAgencyVessel.txtGM")

        'If Me.txtFind.Text <> "" Then
        '    QueryData()
        'Else
        '    QueryData(mFilter)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        Me.grp1.Enabled = False
        Me.dgdLoadingSummary.Enabled = True

        Me.grp2.Enabled = False
        Me.grp3.Enabled = False
        Me.cmdOKContainerPended.Enabled = False
        Me.dgdContainerPended.Enabled = True

        Me.grp4.Enabled = False
        Me.grp5.Enabled = False
        Me.cmdOKDischargeDetail.Enabled = False
        Me.dgdDischargeDetail.Enabled = True

        Me.grp6.Enabled = False
        Me.grp8.Enabled = False
        Me.cmdOKLoadingDetail.Enabled = False
        Me.dgdLoadingDetail.Enabled = True

        Me.cmdOKCVT.Enabled = False
        Me.dgdCVT.Enabled = True

        LoadCombo()
        QueryVessel()
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmAgencyVessel_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListVVIP_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        objUserSetting.SetCParm("frmAgencyVessel.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFind", Me.txtFind.Text)

        'objUserSetting.SetCParm("frmAgencyVessel.txtTerminalDepartureCODE", Me.txtTerminalDepartureCode.Text)

        objUserSetting.SetCParm("frmAgencyVessel.txtArrivalPilot_A", Me.txtArrivalPilot_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtPilotOnBoard_A", Me.txtPilotOnBoard_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtPilotOnBoard_D", Me.txtPilotOnBoard_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFirstLine", Me.txtFirstLine.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtLastLine", Me.txtLastLine.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtCommenced", Me.txtCommenced.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFineshed", Me.txtFineshed.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFO_A", Me.txtFO_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFO_D", Me.txtFO_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtDO_A", Me.txtDO_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtDO_D", Me.txtDO_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFreshWater_A", Me.txtFreshWater_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtFreshWater_D", Me.txtFreshWater_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtDraftAft_A", Me.txtDraftAft_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtDraftAft_D", Me.txtDraftAft_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtDraftFwd_A", Me.txtDraftFwd_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtDraftFwd_D", Me.txtDraftFwd_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTTLEmptyCNTR_A", Me.txtTTLEmptyCNTR_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTTLEmptyCNTR_D", Me.txtTTLEmptyCNTR_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTTLFullCNTR_A", Me.txtTTLFullCNTR_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTTLFullCNTR_D", Me.txtTTLFullCNTR_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTTLGrossWeight_A", Me.txtTTLGrossWeight_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtGrossWeight_D", Me.txtGrossWeight_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTugsIn", Me.txtTugsIn.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtTugsOut", Me.txtTugsOut.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtReMarks_A", Me.txtReMarks_A.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtRemarks_D", Me.txtRemarks_D.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtPortTime", Me.txtPortTime.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtOperationTime", Me.txtOperationTime.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtBerthedTime", Me.txtBerthedTime.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtCashToCaption", Me.txtCashToCaption.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtNextPortCall", Me.txtNextPortCall.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtETANextPort", Me.txtETANextPort.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtHatchCover", Me.txtHatchCover.Text)
        objUserSetting.SetCParm("frmAgencyVessel.txtGM", Me.txtGM.Text)


        objUserSetting.SetCParm("frmAgencyVessel.mFilter", mFilter)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Me.cmdCancelDeclaration_Click(eventSender, eventArgs)
        Me.cmdCancelForeign_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryTerminalDeparture(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryTerminalDeparture = strTerminalDepartureSelect
        MakeQueryTerminalDeparture = MakeQueryTerminalDeparture & " From (TerminalDeparture LEFT JOIN PORT ON port.Port_ID= TerminalDeparture.Port_ID) " & _
                                                                  " LEFT JOIN Vessel ON Vessel.Vessel_ID=TerminalDeparture.Vessel_ID "
        MakeQueryTerminalDeparture = MakeQueryTerminalDeparture & " WHERE TerminalDeparture.continued=1 and port.continued=1 and vessel.continued=1 "

        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryTerminalDeparture = MakeQueryTerminalDeparture & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryTerminalDeparture = MakeQueryTerminalDeparture & strTerminalDepartureOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryTerminalDeparture = MakeQueryTerminalDeparture & strTerminalDepartureOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeTerminalDeparture() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(TerminalDeparture_CODE) as CountNo from TerminalDeparture", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuInsert.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            Me.fraUpdate.Visible = True
            Me.dgdData.Enabled = False
            ReFormat()
            SetMenu((False))
            mTerminalDeparture_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)

            QueryLoadingSummary()
            QueryContainerPeneded()
            QueryDisChargeDetail()
            QueryLoadingDetail()
            QueryCargoSummary()
            QueryCVTLoading()
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveTerminalDeparture()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdData.CurrentRow.Index
        Dim strQueryTerminalDepartureList As String
        If Not Me.dgdData.Item("Editable", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryData(mFilter, , index)
        Else
            strQueryTerminalDepartureList = "Select * from TerminalDeparture where" + " TerminalDeparture_ID= '" & dgdData.Item("TerminalDeparture_ID", index).Value.ToString & "'"
            rsTerminalDepartureList.Open(strQueryTerminalDepartureList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsTerminalDepartureList.Fields("Approve").Value
            rsTerminalDepartureList.Update("Approve", Approve)
            rsTerminalDepartureList.Close()
        End If
        QueryData(mFilter, , index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveLoadingSummary()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdLoadingSummary.CurrentRow.Index
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdLoadingSummary.Item("EditableLS", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQuery = "Select * from LoadingSummary where" + " LoadingSummary_ID= '" & dgdLoadingSummary.Item("LoadingSummary_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryLoadingSummary()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveCargoSummary()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCargo.CurrentRow.Index
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdCargo.Item("EditableCG", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQuery = "Select * from DetailCargo where" + " DetailCargo_ID= '" & dgdCargo.Item("DetailCargo_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryCargoSummary()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveCVTLoading()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCVT.CurrentRow.Index
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdCVT.Item("EditableCVT", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQuery = "Select * from CVTLoading where" + " CVTLoading_ID= '" & dgdCVT.Item("CVTLoading_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryCVTLoading()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveContainerPended()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdContainerPended.CurrentRow.Index
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdContainerPended.Item("EditableCP", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQuery = "Select * from ContainerPended where" + " ContainerPended_ID= '" & dgdContainerPended.Item("ContainerPended_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryContainerPeneded()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveDischargeDetail()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDischargeDetail.CurrentRow.Index
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdDischargeDetail.Item("EditableDis", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQuery = "Select * from DischargeDetail where" + " DischargeDetail_ID= '" & dgdDischargeDetail.Item("DischargeDetail_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryDisChargeDetail()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveLoadingDetail()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdLoadingDetail.CurrentRow.Index
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdLoadingDetail.Item("EditableLD", index).Value Or Not UserRight("frmAgencyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            Dim tbl As New DataSet
            Dim st(1) As String
            st(0) = DefaultValue
            st(1) = DefaultValue
            tbl = ReadDataSet("Select LoadingDetail_ID From LoadingDetail Where Port_ID='" & Me.dgdLoadingDetail.Item("PortPOD_ID", index).Value.ToString & "'")
            If tbl.Tables(0).Rows.Count = 2 Then
                st(0) = tbl.Tables(0).Rows(0).Item("LoadingDetail_ID").ToString
                st(1) = tbl.Tables(0).Rows(1).Item("LoadingDetail_ID").ToString
            End If

            strQuery = "Select * from LoadingDetail where" + " LoadingDetail_ID= '" & st(0) & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()

            strQuery = "Select * from LoadingDetail where" + " LoadingDetail_ID= '" & st(1) & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryLoadingDetail()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE TerminalDeparture_ID = '" & Me.dgdPayableAt.Item("TerminalDeparture_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from TerminalDeparture WHERE TerminalDeparture_ID = '" & Me.dgdData.Item("TerminalDeparture_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The TerminalDeparture can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The TerminalDeparture can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdData.Item("Approve", index)) Then
            If Me.dgdData.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdData.Item("Editable", index)) Then
            If Not Me.dgdData.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the TerminalDeparture: " & Me.dgdData.Item("AgencyName", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from TerminalDeparture where" + " TerminalDeparture_ID= '" & Me.dgdData.Item("TerminalDeparture_ID", index).Value.ToString & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowLS(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE TerminalDeparture_ID = '" & Me.dgdPayableAt.Item("TerminalDeparture_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from LoadingSummary WHERE LoadingSummary_ID = '" & Me.dgdLoadingSummary.Item("LoadingSummary_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Loading Summary can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The TerminalDeparture can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdLoadingSummary.Item("ApproveLS", index)) Then
            If Me.dgdLoadingSummary.Item("ApproveLS", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdLoadingSummary.Item("EditableLS", index)) Then
            If Not Me.dgdLoadingSummary.Item("EditableLS", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Loading Summary: " & Me.dgdLoadingSummary.Item("_Operator", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from LoadingSummary where" + " LoadingSummary_ID= '" & Me.dgdLoadingSummary.Item("LoadingSummary_ID", index).Value.ToString & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Public Sub DeleteRowCS(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE TerminalDeparture_ID = '" & Me.dgdPayableAt.Item("TerminalDeparture_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from DetailCargo WHERE DetailCargo_ID = '" & Me.dgdCargo.Item("DetailCargo_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            'DisplayMessage(True, IIf(gLang = "E", "Sorry, The Loading Summary can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The TerminalDeparture can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdCargo.Item("ApproveCG", index)) Then
            If Me.dgdCargo.Item("ApproveCG", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdCargo.Item("EditableCG", index)) Then
            If Not Me.dgdCargo.Item("EditableCG", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Cargo Summary: " & Me.dgdCargo.Item("OperatorCG", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from DetailCargo where" + " DetailCargo_ID= '" & Me.dgdCargo.Item("DetailCargo_ID", index).Value.ToString & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowCVT(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE TerminalDeparture_ID = '" & Me.dgdPayableAt.Item("TerminalDeparture_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from CVTLoading WHERE CVTLoading_ID = '" & Me.dgdCVT.Item("CVTLoading_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            'DisplayMessage(True, IIf(gLang = "E", "Sorry, The Loading Summary can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The TerminalDeparture can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdCVT.Item("ApproveCVT", index)) Then
            If Me.dgdCVT.Item("ApproveCVT", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdCVT.Item("EditableCVT", index)) Then
            If Not Me.dgdCVT.Item("EditableCVT", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the CVT Loading Summary: " & Me.dgdCVT.Item("PortCodeCVT", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from CVTLoading where" + " CVTLoading_ID= '" & Me.dgdCVT.Item("CVTLoading_ID", index).Value.ToString & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowCP(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        strQuery = "Select * from ContainerPended WHERE ContainerPended_ID = '" & Me.dgdContainerPended.Item("ContainerPended_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Loading Summary can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If

        If Not IsNothing(Me.dgdContainerPended.Item("ApproveCP", index)) Then
            If Me.dgdContainerPended.Item("ApproveCP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdContainerPended.Item("EditableCP", index)) Then
            If Not Me.dgdContainerPended.Item("EditableCP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Contaner Pended: " & Me.dgdContainerPended.Item("PortCodeLocal", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from ContainerPended where" + " ContainerPended_ID= '" & Me.dgdContainerPended.Item("ContainerPended_ID", index).Value.ToString & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowDS(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        strQuery = "Select * from DischargeDetail WHERE DischargeDetail_ID = '" & Me.dgdDischargeDetail.Item("DischargeDetail_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Loading Summary can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If

        If Not IsNothing(Me.dgdDischargeDetail.Item("ApproveDis", index)) Then
            If Me.dgdDischargeDetail.Item("ApproveDis", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdDischargeDetail.Item("EditableDis", index)) Then
            If Not Me.dgdDischargeDetail.Item("EditableDis", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Discharge Detail: " & Me.dgdDischargeDetail.Item("PortCodeDis", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from DischargeDetail where" + " DischargeDetail_ID= '" & Me.dgdDischargeDetail.Item("DischargeDetail_ID", index).Value.ToString & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowLD(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        strQuery = "Select * from LoadingDetail WHERE LoadingDetail_ID = '" & Me.dgdLoadingDetail.Item("LoadingDetail_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            'DisplayMessage(True, IIf(gLang = "E", "Sorry, The Loading Summary can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If

        If Not IsNothing(Me.dgdLoadingDetail.Item("ApproveLD", index)) Then
            If Me.dgdLoadingDetail.Item("ApproveLD", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdLoadingDetail.Item("EditableLD", index)) Then
            If Not Me.dgdLoadingDetail.Item("EditableLD", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmAgencyVessel", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            Dim tbl As New DataSet
            Dim st(1) As String
            st(0) = DefaultValue
            st(1) = DefaultValue
            tbl = ReadDataSet("Select LoadingDetail_ID From LoadingDetail Where Port_ID='" & Me.dgdLoadingDetail.Item("PortPOD_ID", index).Value.ToString & "'")
            If tbl.Tables(0).Rows.Count = 2 Then
                st(0) = tbl.Tables(0).Rows(0).Item("LoadingDetail_ID").ToString
                st(1) = tbl.Tables(0).Rows(1).Item("LoadingDetail_ID").ToString
            End If

            strMesg = "Delete the Loading Detail: " & Me.dgdLoadingDetail.Item("LocalTrans", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from LoadingDetail where" + " LoadingDetail_ID= '" & st(0) & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()

                strQueryCommodityList = "Select * from LoadingDetail where" + " LoadingDetail_ID= '" & st(1) & "'"
                rsTerminalDepartureList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTerminalDepartureList.Fields("continued").Value = 0
                rsTerminalDepartureList.Update()
                rsTerminalDepartureList.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTerminalDepartureList.Close()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdData.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdData.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryData(mFilter)
    End Sub
#Region "ViewMenuStrip"

#End Region

#Region "Xuly"
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        If Me.dgdData.RowCount = 0 Then
            Return
        End If

        Dim index As Integer = Me.dgdData.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdData.Item("Approve", index).Value
            EditTable = Me.dgdData.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdData.Height = 306
                Me.dgdData.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mTerminalDeparture_ID = Me.dgdData.Item("TerminalDeparture_ID", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)

                QueryLoadingSummary()
                QueryContainerPeneded()
                QueryDisChargeDetail()
                QueryLoadingDetail()
                QueryCargoSummary()
                QueryCVTLoading()
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Agency Vessel"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Agency Vessel -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Agency Vessel -> Add."
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========Query==========

    Private Sub QueryData(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryTerminalDeparture()
        Else
            strQuery = MakeQueryTerminalDeparture(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "TerminalDepartureList")
        oTable = ds
        'hien thi ra grid 
        Me.dgdData.DataSource = ds.Tables("TerminalDepartureList")
        If Me.dgdData.Enabled = False Then
            Me.dgdData.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Tables(0).Rows.Count > 0 Then
            Me.dgdData.Columns.Item("AgencyName").ToolTipText = "Hiện có:" + CStr(Me.dgdData.RowCount()) + " TerminalDeparture."
        End If
        If Me.dgdData.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdData.Rows.Count And Me.dgdData.Rows.Count > 0 Then
            Me.dgdData.Rows(location).Selected = True
            Me.dgdData.CurrentCell = Me.dgdData.Rows(location).Cells(1)
        End If
        InsertAutoNumberToGrid(Me.dgdData)
        '--------------------
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        'Me.dgdTerminalDeparture.Columns.Item("TerminalDeparture_ID").Visible = False
        'Me.dgdTerminalDeparture.Columns.Item("TerminalDeparture").Visible = Me.smnuDisplayTerminalDeparture.Checked
        'Me.dgdTerminalDeparture.Columns.Item("Editable").Visible = False
        'Me.dgdTerminalDeparture.Columns.Item("Continued").Visible = False
        'Me.dgdTerminalDeparture.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdTerminalDeparture.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdTerminalDeparture.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        dgdData.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdData.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdData.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdData.Height + dgdData.Top

        Me.txtFind.Width = Me.Width - 300

        cmdFind.Left = Me.txtFind.Left + Me.txtFind.Width + 10
        txtFind.Width = Me.Width - 297

        Me.grpForeignVeseel.Left = Me.Width / 2 - Me.grpForeignVeseel.Width / 2
        Me.grpForeignVeseel.Top = Me.Height / 2 - Me.grpForeignVeseel.Height / 2

        Me.grpDeclaration.Left = Me.Width / 2 - Me.grpDeclaration.Width / 2
        Me.grpDeclaration.Top = Me.Height / 2 - Me.grpDeclaration.Height / 2

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdPayableAt_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdData.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdData.RowCount = 0 Then
            Return
        End If
        Dim index As Integer
        index = Me.dgdData.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdData.CurrentCellAddress.X = 43 And Me.dgdData.CurrentCellAddress().Y = index Then
            Call ApproveTerminalDeparture()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPayableAt_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryTerminalDeparture("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
        If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
            Me.cboFind.SelectedIndex = 0
            Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
        End If
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        Me.txtCode.Text = Me.dgdData.Item("Code", index).Value
        Me.txtAgencyName.Text = Me.dgdData.Item("AgencyName", index).Value
        Me.cboVessel.Text = FindIDValue(Me.cboVessel, Me.dgdData.Item("Vessel_ID", index).Value.ToString)
        Me.cboPort.Text = FindIDValue(Me.cboPort, Me.dgdData.Item("Port_ID", index).Value.ToString)
        Me.txtVoyage.Text = Me.dgdData.Item("Voyage", index).Value
        Me.txtWharfName.Text = Me.dgdData.Item("WharfName", index).Value
        Me.txtArrivalPilot_A.Text = Me.dgdData.Item("ArrivalPilot_A", index).Value
        Me.txtPilotOnBoard_A.Text = Me.dgdData.Item("PilotOnBoard_A", index).Value
        Me.txtPilotOnBoard_D.Text = Me.dgdData.Item("PilotOnBoard_D", index).Value
        Me.txtFirstLine.Text = Me.dgdData.Item("FirstLine", index).Value
        Me.txtLastLine.Text = Me.dgdData.Item("LastLine", index).Value
        Me.txtCommenced.Text = Me.dgdData.Item("Commenced", index).Value
        Me.txtFineshed.Text = Me.dgdData.Item("Finished", index).Value
        Me.txtFO_A.Text = Me.dgdData.Item("FO_A", index).Value
        Me.txtFO_D.Text = Me.dgdData.Item("FO_D", index).Value
        Me.txtDO_A.Text = Me.dgdData.Item("DO_A", index).Value
        Me.txtDO_D.Text = Me.dgdData.Item("DO_D", index).Value
        Me.txtFreshWater_A.Text = Me.dgdData.Item("FreshWater_A", index).Value
        Me.txtFreshWater_D.Text = Me.dgdData.Item("FreshWater_D", index).Value
        Me.txtDraftAft_A.Text = Me.dgdData.Item("DraftAft_A", index).Value
        Me.txtDraftAft_D.Text = Me.dgdData.Item("DraftAft_D", index).Value
        Me.txtDraftFwd_A.Text = Me.dgdData.Item("DraftFwd_A", index).Value
        Me.txtDraftFwd_D.Text = Me.dgdData.Item("DraftFwd_D", index).Value
        Me.txtTTLEmptyCNTR_A.Text = Me.dgdData.Item("TTLEmpty_A", index).Value
        Me.txtTTLEmptyCNTR_D.Text = Me.dgdData.Item("TTLEmpty_D", index).Value
        Me.txtTTLFullCNTR_A.Text = Me.dgdData.Item("TTLFull_A", index).Value
        Me.txtTTLFullCNTR_D.Text = Me.dgdData.Item("TTLFull_D", index).Value
        Me.txtTTLGrossWeight_A.Text = Me.dgdData.Item("TTLGross_A", index).Value
        Me.txtGrossWeight_D.Text = Me.dgdData.Item("TTLGross_D", index).Value
        Me.txtTugsIn.Text = Me.dgdData.Item("TugsIn", index).Value
        Me.txtTugsOut.Text = Me.dgdData.Item("TugsOut", index).Value
        Me.txtReMarks_A.Text = Me.dgdData.Item("ReMark_A", index).Value
        Me.txtRemarks_D.Text = Me.dgdData.Item("Remark_D", index).Value
        Me.txtPortTime.Text = Me.dgdData.Item("PortTime", index).Value
        Me.txtOperationTime.Text = Me.dgdData.Item("OperationTime", index).Value
        Me.txtBerthedTime.Text = Me.dgdData.Item("BerthedTime", index).Value
        Me.txtCashToCaption.Text = Me.dgdData.Item("CashToCaption", index).Value
        Me.txtNextPortCall.Text = Me.dgdData.Item("NextPortCall", index).Value
        Me.txtETANextPort.Text = Me.dgdData.Item("ETANextPort", index).Value
        Me.txtHatchCover.Text = Me.dgdData.Item("HatchCover", index).Value
        Me.txtGM.Text = Me.dgdData.Item("GM", index).Value

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataLS(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        Me.txtOperator.Text = Me.dgdLoadingSummary.Item("_Operator", index).Value
        If Me.dgdLoadingSummary.Item("FullEmpty", index).Value = "Full" Then
            Me.rdoFull.Checked = True
        Else
            Me.rdoEmpty.Checked = True
        End If

        If IsDBNull(Me.dgdLoadingSummary.Item("SL20GP", index).Value) = False Then
            Me.txt20GP.Text = Me.dgdLoadingSummary.Item("SL20GP", index).Value
            Me.chk20GP.Checked = True
        Else
            Me.chk20GP.Checked = False
        End If

        If IsDBNull(Me.dgdLoadingSummary.Item("SL40GP", index).Value) = False Then
            Me.txt40GP.Text = Me.dgdLoadingSummary.Item("SL40GP", index).Value
            Me.chk40GP.Checked = True
        Else
            Me.chk40GP.Checked = False
        End If

        If IsDBNull(Me.dgdLoadingSummary.Item("SL40HC", index).Value) = False Then
            Me.txt40HC.Text = Me.dgdLoadingSummary.Item("SL40HC", index).Value
            Me.chk40HC.Checked = True
        Else
            Me.chk40HC.Checked = False
        End If

        If IsDBNull(Me.dgdLoadingSummary.Item("SL20RF", index).Value) = False Then
            Me.txt20RF.Text = Me.dgdLoadingSummary.Item("SL20RF", index).Value
            Me.chk20RF.Checked = True
        Else
            Me.chk20RF.Checked = False
        End If

        If IsDBNull(Me.dgdLoadingSummary.Item("SL40RH", index).Value) = False Then
            Me.txt40RH.Text = Me.dgdLoadingSummary.Item("SL40RH", index).Value
            Me.chk40RH.Checked = True
        Else
            Me.chk40RH.Checked = False
        End If

        If IsDBNull(Me.dgdLoadingSummary.Item("SL45", index).Value) = False Then
            Me.txt45.Text = Me.dgdLoadingSummary.Item("SL45", index).Value
            Me.chk45.Checked = True
        Else
            Me.chk45.Checked = False
        End If
        Me.txtWeight.Text = Me.dgdLoadingSummary.Item("Weight", index).Value

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataCS(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        Me.txtOperatorCG.Text = Me.dgdCargo.Item("OperatorCG", index).Value
        If Me.dgdCargo.Item("Type", index).Value = "Danger" Then
            Me.rdoDanger.Checked = True
        Else
            Me.rdoSpecial.Checked = True
        End If

        If IsDBNull(Me.dgdCargo.Item("SL20", index).Value) = False Then
            Me.txt20CG.Text = Me.dgdCargo.Item("SL20", index).Value
            Me.chk20CG.Checked = True
        Else
            Me.chk20CG.Checked = False
            Me.txt20CG.Text = ""
        End If

        If IsDBNull(Me.dgdCargo.Item("SL40", index).Value) = False Then
            Me.txt40CG.Text = Me.dgdCargo.Item("SL40", index).Value
            Me.chk40CG.Checked = True
        Else
            Me.chk40CG.Checked = False
            Me.txt40CG.Text = ""
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataCP(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        Me.cboPortPODLocal.Text = Me.dgdContainerPended.Item("PortCodeLocal", index).Value

        If IsDBNull(Me.dgdContainerPended.Item("Local20GP", index).Value) = False Then
            Me.txt20GPLocal.Text = Me.dgdContainerPended.Item("Local20GP", index).Value
            Me.chk20GPLocal.Checked = True
        Else
            Me.chk20GPLocal.Checked = False
            Me.txt20GPLocal.Text = ""
        End If

        If IsDBNull(Me.dgdContainerPended.Item("Local40GP", index).Value) = False Then
            Me.txt40GPLocal.Text = Me.dgdContainerPended.Item("Local40GP", index).Value
            Me.chk40GPLocal.Checked = True
        Else
            Me.chk40GPLocal.Checked = False
            Me.txt40GPLocal.Text = ""
        End If

        If IsDBNull(Me.dgdContainerPended.Item("Transfer20GP", index).Value) = False Then
            Me.txt20GPTrans.Text = Me.dgdContainerPended.Item("Transfer20GP", index).Value
            Me.chk20GPTrans.Checked = True
        Else
            Me.chk20GPTrans.Checked = False
            Me.txt20GPTrans.Text = ""
        End If

        If IsDBNull(Me.dgdContainerPended.Item("Transfer40GP", index).Value) = False Then
            Me.txt40GPTrans.Text = Me.dgdContainerPended.Item("Transfer40GP", index).Value
            Me.chk40GPTrans.Checked = True
        Else
            Me.chk40GPTrans.Checked = False
            Me.txt40GPTrans.Text = ""
        End If

        Me.cboPortPORTrans.Text = Me.dgdContainerPended.Item("TransferPortCodePOR", index).Value
        Me.cboPortPODTrans.Text = Me.dgdContainerPended.Item("TransferPortCodePOD", index).Value

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataCVT(ByVal index As Integer)
        On Error GoTo Err_Renamed

        Me.cboPortPODCVT.Text = Me.dgdCVT.Item("PortCodeCVT", index).Value

        If IsDBNull(Me.dgdCVT.Item("SL20GPCVT", index).Value) = False Then
            Me.txt20GPCVT.Text = Me.dgdCVT.Item("SL20GPCVT", index).Value
            Me.chk20GPCVT.Checked = True
        Else
            Me.chk20GPCVT.Checked = False
            Me.txt20GPCVT.Text = ""
        End If

        If IsDBNull(Me.dgdCVT.Item("SL40GPCVT", index).Value) = False Then
            Me.txt40GPCVT.Text = Me.dgdCVT.Item("SL40GPCVT", index).Value
            Me.chk40GPCVT.Checked = True
        Else
            Me.chk40GPCVT.Checked = False
            Me.txt40GPCVT.Text = ""
        End If

        If IsDBNull(Me.dgdCVT.Item("SL40HQCVT", index).Value) = False Then
            Me.txt40HQCVT.Text = Me.dgdCVT.Item("SL40HQCVT", index).Value
            Me.chk40HQCVT.Checked = True
        Else
            Me.chk40HQCVT.Checked = False
            Me.txt40HQCVT.Text = ""
        End If

        If IsDBNull(Me.dgdCVT.Item("SL20RFCVT", index).Value) = False Then
            Me.txt20RFCVT.Text = Me.dgdCVT.Item("SL20RFCVT", index).Value
            Me.chk20RFCVT.Checked = True
        Else
            Me.chk20RFCVT.Checked = False
            Me.txt20RFCVT.Text = ""
        End If

        If IsDBNull(Me.dgdCVT.Item("SL40RHCVT", index).Value) = False Then
            Me.txt40RHCVT.Text = Me.dgdCVT.Item("SL40RHCVT", index).Value
            Me.chk40RHCVT.Checked = True
        Else
            Me.chk40RHCVT.Checked = False
            Me.txt40RHCVT.Text = ""
        End If

        If IsDBNull(Me.dgdCVT.Item("SL20ECVT", index).Value) = False Then
            Me.txt20ECVT.Text = Me.dgdCVT.Item("SL20ECVT", index).Value
            Me.chk20ECVT.Checked = True
        Else
            Me.chk20ECVT.Checked = False
            Me.txt20ECVT.Text = ""
        End If

        If IsDBNull(Me.dgdCVT.Item("SL40ECVT", index).Value) = False Then
            Me.txt40ECVT.Text = Me.dgdCVT.Item("SL40ECVT", index).Value
            Me.chk40ECVT.Checked = True
        Else
            Me.chk40ECVT.Checked = False
            Me.txt40ECVT.Text = ""
        End If

        Me.cboDEST.Text = Me.dgdCVT.Item("DEST", index).Value
        Me.txtTueCVT.Text = Me.dgdCVT.Item("Tue", index).Value
        Me.txtWeightCVT.Text = Me.dgdCVT.Item("WeightCVT", index).Value

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataDS(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        Me.cboPortPOL.Text = Me.dgdDischargeDetail.Item("PortCodeDis", index).Value

        If IsDBNull(Me.dgdDischargeDetail.Item("Full20GP", index).Value) = False Then
            Me.txt20GPFullDis.Text = Me.dgdDischargeDetail.Item("Full20GP", index).Value
            Me.chk20GPFullDis.Checked = True
        Else
            Me.chk20GPFullDis.Checked = False
            Me.txt20GPFullDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Full40GP", index).Value) = False Then
            Me.txt40GPFullDis.Text = Me.dgdDischargeDetail.Item("Full40GP", index).Value
            Me.chk40GPFullDis.Checked = True
        Else
            Me.chk40GPFullDis.Checked = False
            Me.txt40GPFullDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Full40HC", index).Value) = False Then
            Me.txt40HCFullDis.Text = Me.dgdDischargeDetail.Item("Full40HC", index).Value
            Me.chk40HCFullDis.Checked = True
        Else
            Me.chk40HCFullDis.Checked = False
            Me.txt40HCFullDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Full20RF", index).Value) = False Then
            Me.txt20RFFullDis.Text = Me.dgdDischargeDetail.Item("Full20RF", index).Value
            Me.chk20RFFullDis.Checked = True
        Else
            Me.chk20RFFullDis.Checked = False
            Me.txt20RFFullDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Full40RH", index).Value) = False Then
            Me.txt40RHFullDis.Text = Me.dgdDischargeDetail.Item("Full20RF", index).Value
            Me.chk40RHFullDis.Checked = True
        Else
            Me.chk40RHFullDis.Checked = False
            Me.txt40RHFullDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Full45", index).Value) = False Then
            Me.txt45FullDis.Text = Me.dgdDischargeDetail.Item("Full45", index).Value
            Me.chk45FullDis.Checked = True
        Else
            Me.chk45FullDis.Checked = False
            Me.txt45FullDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Empty20", index).Value) = False Then
            Me.txt20EmptyDis.Text = Me.dgdDischargeDetail.Item("Empty20", index).Value
            Me.chk20EmptyDis.Checked = True
        Else
            Me.chk20EmptyDis.Checked = False
            Me.txt20EmptyDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Empty40", index).Value) = False Then
            Me.txt40EmptyDis.Text = Me.dgdDischargeDetail.Item("Empty40", index).Value
            Me.chk40EmptyDis.Checked = True
        Else
            Me.chk40EmptyDis.Checked = False
            Me.txt40EmptyDis.Text = ""
        End If

        If IsDBNull(Me.dgdDischargeDetail.Item("Empty45", index).Value) = False Then
            Me.txt45EmptyDis.Text = Me.dgdDischargeDetail.Item("Empty45", index).Value
            Me.chk45EmptyDis.Checked = True
        Else
            Me.chk45EmptyDis.Checked = False
            Me.txt45EmptyDis.Text = ""
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataLD(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim _mID As String = Me.dgdLoadingDetail.Item("PortPOD_ID", index).Value.ToString

        Dim tbl As New DataSet
        tbl = ReadDataSet("Select * From LoadingDetail Where Port_ID='" & _mID & "'")
        If tbl.Tables(0).Rows.Count < 2 Then
            Return
        End If
        Me.cboPortPOD.Text = Me.dgdLoadingDetail.Item("PortCodePOD", index).Value

        '----------------------------
        If IsDBNull(tbl.Tables(0).Rows(0).Item("Full20GP")) = False Then
            Me.txt20GPSubFull.Text = tbl.Tables(0).Rows(0).Item("Full20GP")
            Me.chk20GPSubFull.Checked = True
        Else
            Me.chk20GPSubFull.Checked = False
            Me.txt20GPSubFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Full40GP")) = False Then
            Me.txt40GPSubFull.Text = tbl.Tables(0).Rows(0).Item("Full40GP")
            Me.chk40GPSubFull.Checked = True
        Else
            Me.chk40GPSubFull.Checked = False
            Me.txt40GPSubFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Full40HC")) = False Then
            Me.txt40HCSubFull.Text = tbl.Tables(0).Rows(0).Item("Full40HC")
            Me.chk40HCSubFull.Checked = True
        Else
            Me.chk40HCSubFull.Checked = False
            Me.txt40HCSubFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Full20RF")) = False Then
            Me.txt20RFSubFull.Text = tbl.Tables(0).Rows(0).Item("Full20RF")
            Me.chk20RFSubFull.Checked = True
        Else
            Me.chk20RFSubFull.Checked = False
            Me.txt20RFSubFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Full40RH")) = False Then
            Me.txt40RHSubFull.Text = tbl.Tables(0).Rows(0).Item("Full40RH")
            Me.chk40RHSubFull.Checked = True
        Else
            Me.chk40RHSubFull.Checked = False
            Me.txt40RHSubFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Full45")) = False Then
            Me.txt45SubFull.Text = tbl.Tables(0).Rows(0).Item("Full45")
            Me.chk45SubFull.Checked = True
        Else
            Me.chk45SubFull.Checked = False
            Me.txt45SubFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Empty20")) = False Then
            Me.txt20SubEmpty.Text = tbl.Tables(0).Rows(0).Item("Empty20")
            Me.chk20subEmpTy.Checked = True
        Else
            Me.chk20subEmpTy.Checked = False
            Me.txt20SubEmpty.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Empty40")) = False Then
            Me.txt40SubEmpty.Text = tbl.Tables(0).Rows(0).Item("Empty40")
            Me.chk40SubEmpty.Checked = True
        Else
            Me.chk40SubEmpty.Checked = False
            Me.txt40SubEmpty.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Empty45")) = False Then
            Me.txt45SubEmpty.Text = tbl.Tables(0).Rows(0).Item("Empty45")
            Me.chk45SubEmpty.Checked = True
        Else
            Me.chk45SubEmpty.Checked = False
            Me.txt45SubEmpty.Text = ""
        End If

        If tbl.Tables(0).Rows(0).Item("LocalTrans") = "SUB TTL" Then
            Me.rdoSubFull.Checked = True
        Else
            Me.rdoLocalFull.Checked = True
        End If
        Me.txtWeight.Text = tbl.Tables(0).Rows(0).Item("Weight")

        If IsDBNull(tbl.Tables(0).Rows(0).Item("Slot20")) = False Then
            Me.txtSlot20.Text = tbl.Tables(0).Rows(0).Item("Slot20")
            Me.chkSlot20.Checked = True
        Else
            Me.chkSlot20.Checked = False
            Me.txtSlot20.Text = ""
        End If


        If IsDBNull(tbl.Tables(0).Rows(0).Item("Slot40")) = False Then
            Me.txtSlot45.Text = tbl.Tables(0).Rows(0).Item("Slot40")
            Me.chkSlot45.Checked = True
        Else
            Me.chkSlot45.Checked = False
            Me.txtSlot45.Text = ""
        End If
        Me.txtCSCWeight.Text = tbl.Tables(0).Rows(0).Item("Weight")

        '---------------------------------

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Full20GP")) = False Then
            Me.txt20GPTSFull.Text = tbl.Tables(0).Rows(1).Item("Full20GP")
            Me.chk20GPTSFull.Checked = True
        Else
            Me.chk20GPTSFull.Checked = False
            Me.txt20GPTSFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Full40GP")) = False Then
            Me.txt40GPTSFull.Text = tbl.Tables(0).Rows(1).Item("Full40GP")
            Me.chk40GPTSFull.Checked = True
        Else
            Me.chk40GPTSFull.Checked = False
            Me.txt40GPTSFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Full40HC")) = False Then
            Me.txt40HCTSFull.Text = tbl.Tables(0).Rows(1).Item("Full40HC")
            Me.chk40HCTSFull.Checked = True
        Else
            Me.chk40HCTSFull.Checked = False
            Me.txt40HCTSFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Full20RF")) = False Then
            Me.txt20RFTSFull.Text = tbl.Tables(0).Rows(1).Item("Full20RF")
            Me.chk20RFTSFull.Checked = True
        Else
            Me.chk20RFTSFull.Checked = False
            Me.txt20RFTSFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Full40RH")) = False Then
            Me.txt40RHTSFull.Text = tbl.Tables(0).Rows(1).Item("Full40RH")
            Me.chk40RHTSFull.Checked = True
        Else
            Me.chk40RHTSFull.Checked = False
            Me.txt40RHTSFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Full45")) = False Then
            Me.txt45TSFull.Text = tbl.Tables(0).Rows(1).Item("Full45")
            Me.chk45TSFull.Checked = True
        Else
            Me.chk45TSFull.Checked = False
            Me.txt45TSFull.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Empty20")) = False Then
            Me.txt20TSEmpty.Text = tbl.Tables(0).Rows(1).Item("Empty20")
            Me.chk20TSEmpty.Checked = True
        Else
            Me.chk20TSEmpty.Checked = False
            Me.txt20TSEmpty.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Empty40")) = False Then
            Me.txt40TSEmpty.Text = tbl.Tables(0).Rows(1).Item("Empty40")
            Me.chk40TSEmpty.Checked = True
        Else
            Me.chk40TSEmpty.Checked = False
            Me.txt40TSEmpty.Text = ""
        End If

        If IsDBNull(tbl.Tables(0).Rows(1).Item("Empty40")) = False Then
            Me.txt45TSEmpty.Text = tbl.Tables(0).Rows(1).Item("Empty40")
            Me.chk45TSEmpty.Checked = True
        Else
            Me.chk45TSEmpty.Checked = False
            Me.txt45TSEmpty.Text = ""
        End If

        If tbl.Tables(0).Rows(0).Item("LocalTrans") = "SUB TTL" Then
            Me.rdoSubFull.Checked = True
        Else
            Me.rdoLocalFull.Checked = True
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmAgencyVessel_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strTerminalDeparture_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Tables(0).Rows.Count > 0) Then
            index = Me.dgdData.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            If mStatus = "Edit" Then
                CopyValues("TerminalDeparture", "TerminalDeparture_ID", mTerminalDeparture_ID)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM TerminalDeparture "
            strQuery = strQuery & "WHERE TerminalDeparture_ID = '" & mTerminalDeparture_ID & "' AND TerminalDeparture_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("TerminalDeparture_ID").Value = NewId()
                End If
                strTerminalDeparture_ID = .Fields("TerminalDeparture_ID").Value

                .Fields("AgencyName").Value = Me.txtAgencyName.Text.Trim
                .Fields("Vessel_ID").Value = "{" & FindValueID(Me.cboVessel, Me.cboVessel.Text.Trim) & "}"
                .Fields("Port_ID").Value = "{" & FindValueID(Me.cboPort, Me.cboPort.Text.Trim) & "}"
                .Fields("Voyage").Value = Me.txtVoyage.Text.Trim
                .Fields("WharfName").Value = Me.txtWharfName.Text.Trim
                .Fields("ArrivalPilot_A").Value = Me.txtArrivalPilot_A.Text.Trim
                .Fields("PilotOnboard_A").Value = Me.txtPilotOnBoard_A.Text.Trim
                .Fields("PilotOnBoard_D").Value = Me.txtPilotOnBoard_D.Text.Trim
                .Fields("FirstLine").Value = Me.txtFirstLine.Text.Trim
                .Fields("LastLine").Value = Me.txtLastLine.Text.Trim
                .Fields("Commenced").Value = Me.txtCommenced.Text.Trim
                .Fields("Finished").Value = Me.txtFineshed.Text.Trim
                .Fields("Code").Value = Me.txtCode.Text.Trim
                If IsNumeric(Me.txtFO_A.Text.Trim) = False Then
                    .Fields("FO_A").Value = "0.0"
                Else
                    .Fields("FO_A").Value = CDbl(Me.txtFO_A.Text.Trim)
                End If
                If IsNumeric(Me.txtFO_D.Text.Trim) = False Then
                    .Fields("FO_D").Value = "0.0"
                Else
                    .Fields("FO_D").Value = CDbl(Me.txtFO_D.Text.Trim)
                End If

                If IsNumeric(Me.txtDO_A.Text.Trim) = False Then
                    .Fields("DO_A").Value = "0.0"
                Else
                    .Fields("DO_A").Value = CDbl(Me.txtDO_A.Text.Trim)
                End If
                If IsNumeric(Me.txtDO_D.Text.Trim) = False Then
                    .Fields("DO_D").Value = "0.0"
                Else
                    .Fields("DO_D").Value = CDbl(Me.txtDO_D.Text.Trim)
                End If

                If IsNumeric(Me.txtFreshWater_A.Text.Trim) = False Then
                    .Fields("FreshWater_A").Value = "0.0"
                Else
                    .Fields("FreshWater_A").Value = CDbl(Me.txtFreshWater_A.Text.Trim)
                End If
                If IsNumeric(Me.txtFreshWater_D.Text.Trim) = False Then
                    .Fields("FreshWater_D").Value = "0.0"
                Else
                    .Fields("FreshWater_D").Value = CDbl(Me.txtFreshWater_D.Text.Trim)
                End If

                If IsNumeric(Me.txtDraftAft_A.Text.Trim) = False Then
                    .Fields("DraftAft_A").Value = "0.0"
                Else
                    .Fields("DraftAft_A").Value = CDbl(Me.txtDraftAft_A.Text.Trim)
                End If
                If IsNumeric(Me.txtDraftAft_D.Text.Trim) = False Then
                    .Fields("DraftAft_D").Value = "0.0"
                Else
                    .Fields("DraftAft_D").Value = CDbl(Me.txtDraftAft_D.Text.Trim)
                End If

                If IsNumeric(Me.txtDraftFwd_A.Text.Trim) = False Then
                    .Fields("DraftFwd_A").Value = "0.0"
                Else
                    .Fields("DraftFwd_A").Value = CDbl(Me.txtDraftFwd_A.Text.Trim)
                End If
                If IsNumeric(Me.txtDraftFwd_D.Text.Trim) = False Then
                    .Fields("DraftFwd_D").Value = "0.0"
                Else
                    .Fields("DraftFwd_D").Value = CDbl(Me.txtDraftFwd_D.Text.Trim)
                End If

                If IsNumeric(Me.txtTTLEmptyCNTR_A.Text.Trim) = False Then
                    .Fields("TTLEmpty_A").Value = "0.0"
                Else
                    .Fields("TTLEmpty_A").Value = CDbl(Me.txtTTLEmptyCNTR_A.Text.Trim)
                End If
                If IsNumeric(Me.txtTTLEmptyCNTR_D.Text.Trim) = False Then
                    .Fields("TTLEmpty_D").Value = "0.0"
                Else
                    .Fields("TTLEmpty_D").Value = CDbl(Me.txtTTLEmptyCNTR_D.Text.Trim)
                End If

                If IsNumeric(Me.txtTTLFullCNTR_A.Text.Trim) = False Then
                    .Fields("TTLFull_A").Value = "0.0"
                Else
                    .Fields("TTLFull_A").Value = CDbl(Me.txtTTLFullCNTR_A.Text.Trim)
                End If
                If IsNumeric(Me.txtTTLFullCNTR_D.Text.Trim) = False Then
                    .Fields("TTLFull_D").Value = "0.0"
                Else
                    .Fields("TTLFull_D").Value = CDbl(Me.txtTTLFullCNTR_D.Text.Trim)
                End If

                If IsNumeric(Me.txtTTLGrossWeight_A.Text.Trim) = False Then
                    .Fields("TTLGross_A").Value = "0.0"
                Else
                    .Fields("TTLGross_A").Value = CDbl(Me.txtTTLGrossWeight_A.Text.Trim)
                End If
                If IsNumeric(Me.txtGrossWeight_D.Text.Trim) = False Then
                    .Fields("TTLGross_D").Value = "0.0"
                Else
                    .Fields("TTLGross_D").Value = CDbl(Me.txtGrossWeight_D.Text.Trim)
                End If

                If IsNumeric(Me.txtTugsIn.Text.Trim) = False Then
                    .Fields("TugsIn").Value = "0.0"
                Else
                    .Fields("TugsIn").Value = CDbl(Me.txtTugsIn.Text.Trim)
                End If
                If IsNumeric(Me.txtTugsOut.Text.Trim) = False Then
                    .Fields("TugsOut").Value = "0.0"
                Else
                    .Fields("TugsOut").Value = CDbl(Me.txtTugsOut.Text.Trim)
                End If

                .Fields("Remark_A").Value = Me.txtReMarks_A.Text.Trim
                .Fields("Remark_D").Value = Me.txtRemarks_D.Text.Trim
                .Fields("PortTime").Value = Me.txtPortTime.Text.Trim
                .Fields("OperationTime").Value = Me.txtOperationTime.Text.Trim
                .Fields("BerthedTime").Value = Me.txtBerthedTime.Text.Trim
                .Fields("CashToCaption").Value = Me.txtCashToCaption.Text.Trim
                .Fields("NextPortCall").Value = Me.txtNextPortCall.Text.Trim
                .Fields("ETANextPort").Value = Me.txtETANextPort.Text.Trim
                .Fields("HatchCover").Value = Me.txtHatchCover.Text.Trim
                .Fields("GM").Value = Me.txtGM.Text.Trim

                .Update()

            End With
            rs.Close()
            Me.dgdData.Enabled = True

            QueryData(mFilter, , index)

            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
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
        Me.dgdData.Enabled = True
        Me.cmdCancelCargo_Click(sender, e)
        Me.cmdCancelContainerPended_Click(sender, e)
        Me.cmdCancelCVT_Click(sender, e)
        Me.cmdCancelDischagreDetail_Click(sender, e)
        Me.cmdCancelLD_Click(sender, e)
        Me.cmdCancelLoadingDetail_Click(sender, e)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub Queryport(ByRef Cbo As Object, Optional ByVal id As String = "Port_ID", Optional ByVal value As String = "Port_Code", Optional ByVal rang As String = "")
        Dim oItem As PDSAListItemString
        Dim intLoop As Integer
        Try
            Cbo.Items.Clear()
            For intLoop = 0 To tblPort.Tables(0).Rows.Count - 1
                oItem = New PDSAListItemString
                With tblPort.Tables(0).Rows(intLoop)
                    oItem.Value = Trim(.Item(value).ToString())
                    oItem.ID = .Item(id).ToString()
                End With
                Cbo.Items.Add(oItem)
            Next
            If tblPort.Tables(0).Rows.Count > 0 Then
                Cbo.SelectedIndex = 0
            End If
        Catch oExcept As Exception
            MessageBox.Show(oExcept.Message)
        End Try
    End Sub

    Public Sub LoadCombo()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        Dim cbo As Object
        id = "Port_ID"
        value = "Port_Code"
        strSQL = "Select * From Port where Continued=1 Order By Port_Code desc"
        tblPort = ReadDataSet(strSQL)

        cbo = Me.cboPort
        Queryport(cbo)
        cbo = Me.cboPortPOD
        Queryport(cbo)
        cbo = Me.cboPortPODCVT
        Queryport(cbo)
        cbo = Me.cboPortPODLocal
        Queryport(cbo)
        cbo = Me.cboPortPODTrans
        Queryport(cbo)
        cbo = Me.cboPortPOL
        Queryport(cbo)
        cbo = Me.cboPortPORTrans
        Queryport(cbo)
        cbo = Me.cboDEST
        Queryport(cbo)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub QueryVessel()
        Try
            Dim id, value, strSQL As String
            id = "Vessel_ID"
            value = "Vessel"
            strSQL = "Select * From Vessel where Continued=1 Order By Vessel desc"
            loadDataToObject(Me.cboVessel, strSQL, id, value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#Region "Check Box"
    Private Sub chk20GP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GP.CheckedChanged
        Try
            Me.txt20GP.Enabled = Me.chk20GP.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GP.CheckedChanged
        Try
            Me.txt40GP.Enabled = Me.chk40GP.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40HC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40HC.CheckedChanged
        Try
            Me.txt40HC.Enabled = Me.chk40HC.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20RF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20RF.CheckedChanged
        Try
            Me.txt20RF.Enabled = Me.chk20RF.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40RH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RH.CheckedChanged
        Try
            Me.txt40RH.Enabled = Me.chk40RH.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45.CheckedChanged
        Try
            Me.txt45.Enabled = Me.chk45.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20GPLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPLocal.CheckedChanged
        Try
            Me.txt20GPLocal.Enabled = Me.chk20GPLocal.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GPLocal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPLocal.CheckedChanged
        Try
            Me.txt40GPLocal.Enabled = Me.chk40GPLocal.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20GPTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPTrans.CheckedChanged
        Try
            Me.txt20GPTrans.Enabled = Me.chk20GPTrans.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GPTrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPTrans.CheckedChanged
        Try
            Me.txt40GPTrans.Enabled = Me.chk40GPTrans.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20GPFullDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPFullDis.CheckedChanged
        Try
            Me.txt20GPFullDis.Enabled = Me.chk20GPFullDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GPFullDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPFullDis.CheckedChanged
        Try
            Me.txt40GPFullDis.Enabled = Me.chk40GPFullDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40HCFullDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40HCFullDis.CheckedChanged
        Try
            Me.txt40HCFullDis.Enabled = Me.chk40HCFullDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20RFFullDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20RFFullDis.CheckedChanged
        Try
            Me.txt20RFFullDis.Enabled = Me.chk20RFFullDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40RHFullDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RHFullDis.CheckedChanged
        Try
            Me.txt40RHFullDis.Enabled = Me.chk40RHFullDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45FullDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45FullDis.CheckedChanged
        Try
            Me.txt45FullDis.Enabled = Me.chk45FullDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20EmptyDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20EmptyDis.CheckedChanged
        Try
            Me.txt20EmptyDis.Enabled = Me.chk20EmptyDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40EmptyDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40EmptyDis.CheckedChanged
        Try
            Me.txt40EmptyDis.Enabled = Me.chk40EmptyDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45EmptyDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45EmptyDis.CheckedChanged
        Try
            Me.txt45EmptyDis.Enabled = Me.chk45EmptyDis.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20GPSubFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPSubFull.CheckedChanged
        Try
            Me.txt20GPSubFull.Enabled = Me.chk20GPSubFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GPSubFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPSubFull.CheckedChanged
        Try
            Me.txt40GPSubFull.Enabled = Me.chk40GPSubFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40HCSubFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40HCSubFull.CheckedChanged
        Try
            Me.txt40HCSubFull.Enabled = Me.chk40HCSubFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20RFSubFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20RFSubFull.CheckedChanged
        Try
            Me.txt20RFSubFull.Enabled = Me.chk20RFSubFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40RHSubFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RHSubFull.CheckedChanged
        Try
            Me.txt40RHSubFull.Enabled = Me.chk40RHSubFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45SubFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45SubFull.CheckedChanged
        Try
            Me.txt45SubFull.Enabled = Me.chk45SubFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20GPTSFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20GPTSFull.CheckedChanged
        Try
            Me.txt20GPTSFull.Enabled = Me.chk20GPTSFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GPTSFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40GPTSFull.CheckedChanged
        Try
            Me.txt40GPTSFull.Enabled = Me.chk40GPTSFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40HCTSFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40HCTSFull.CheckedChanged
        Try
            Me.txt40HCTSFull.Enabled = Me.chk40HCTSFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20RFTSFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20RFTSFull.CheckedChanged
        Try
            Me.txt20RFTSFull.Enabled = Me.chk20RFTSFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40RHTSFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40RHTSFull.CheckedChanged
        Try
            Me.txt40RHTSFull.Enabled = Me.chk40RHTSFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45TSFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45TSFull.CheckedChanged
        Try
            Me.txt45TSFull.Enabled = Me.chk45TSFull.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20subEmpTy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20subEmpTy.CheckedChanged
        Try
            Me.txt20SubEmpty.Enabled = Me.chk20subEmpTy.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40SubEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk40SubEmpty.CheckedChanged
        Try
            Me.txt40SubEmpty.Enabled = Me.chk40SubEmpty.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45SubEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk45SubEmpty.CheckedChanged
        Try
            Me.txt45SubEmpty.Enabled = Me.chk40SubEmpty.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20TSEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk20TSEmpty.CheckedChanged
        Try
            Me.txt20TSEmpty.Enabled = Me.chk20TSEmpty.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40TSEmpty_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk40TSEmpty.CheckedChanged
        Try
            Me.txt40TSEmpty.Enabled = Me.chk40TSEmpty.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk45TSEmpty_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk45TSEmpty.CheckedChanged
        Try
            Me.txt45TSEmpty.Enabled = Me.chk45TSEmpty.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkSlot20_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSlot20.CheckedChanged
        Try
            Me.txtSlot20.Enabled = Me.chkSlot20.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkSlot45_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSlot45.CheckedChanged
        Try
            Me.txtSlot45.Enabled = Me.chkSlot45.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20CG_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk20CG.CheckedChanged
        Try
            Me.txt20CG.Enabled = Me.chk20CG.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40CG_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk40CG.CheckedChanged
        Try
            Me.txt40CG.Enabled = Me.chk40CG.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20ECVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk20ECVT.CheckedChanged
        Try
            Me.txt20ECVT.Enabled = Me.chk20ECVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20GPCVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk20GPCVT.CheckedChanged
        Try
            Me.txt20GPCVT.Enabled = Me.chk20GPCVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk20RFCVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk20RFCVT.CheckedChanged
        Try
            Me.txt20RFCVT.Enabled = Me.chk20RFCVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40ECVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk40ECVT.CheckedChanged
        Try
            Me.txt40ECVT.Enabled = Me.chk40ECVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40GPCVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk40GPCVT.CheckedChanged
        Try
            Me.txt40GPCVT.Enabled = Me.chk40GPCVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40HCCVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk40HQCVT.CheckedChanged
        Try
            Me.txt40HQCVT.Enabled = Me.chk40HQCVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chk40RHCVT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk40RHCVT.CheckedChanged
        Try
            Me.txt40RHCVT.Enabled = Me.chk40RHCVT.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Sub QueryLoadingSummary(Optional ByVal location As Integer = 0)
        Try
            Dim strSql As String = "Select " & _
                                   "ls.LoadingSummary_ID, " & _
                                   "ls.TerminalDeparture_ID, " & _
                                   "ls.Operator, " & _
                                   "ls.FullEmpty, " & _
                                   "ls.SL20GP, " & _
                                   "ls.SL40GP, " & _
                                   "ls.SL40HC, " & _
                                   "ls.SL20RF, " & _
                                   "ls.SL40RH, " & _
                                   "ls.SL45, " & _
                                   "ls.Weight, " & _
                                   "ls.editable, " & _
                                   "ls.continued, " & _
                                   "ls.approve, " & _
                                   "ls.userid, " & _
                                   "ls.updatetime " & _
                                   "From TerminalDeparture ter LEFT JOIN LoadingSummary ls ON ls.TerminalDeparture_ID=ter.TerminalDeparture_ID " & _
                                   "Where ter.continued=1 and ls.continued=1 and ter.TerminalDeparture_ID='" & mTerminalDeparture_ID & "'"
            tblLoadingSummary = ReadDataSet(strSql)
            Me.dgdLoadingSummary.DataSource = tblLoadingSummary.Tables(0)

            If location > 0 And location <= Me.dgdLoadingSummary.Rows.Count And Me.dgdLoadingSummary.Rows.Count > 0 Then
                Me.dgdLoadingSummary.Rows(location).Selected = True
                Me.dgdLoadingSummary.CurrentCell = Me.dgdLoadingSummary.Rows(location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdLoadingSummary)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryContainerPeneded(Optional ByVal Location As Integer = 0)
        Try
            Dim strSql As String = "Select " & _
                                   "ls.ContainerPended_ID, " & _
                                   "ls.TerminalDeparture_ID, " & _
                                   "pod1.Port_Code," & _
                                   "ls.Local20GP, " & _
                                   "ls.Local40GP, " & _
                                   "por.Port_Code as Port_Code_1, " & _
                                   "pod2.Port_Code as Port_Code_2, " & _
                                   "ls.Transfer20GP, " & _
                                   "ls.Transfer40GP, " & _
                                   "ls.editable, " & _
                                   "ls.continued, " & _
                                   "ls.approve, " & _
                                   "ls.userid, " & _
                                   "ls.updatetime " & _
                                   "From (((TerminalDeparture ter LEFT JOIN ContainerPended ls ON ls.TerminalDeparture_ID=ter.TerminalDeparture_ID) " & _
                                   "LEFT JOIN Port pod1 ON pod1.Port_ID=ls.LocalPortPOD_ID) " & _
                                   "LEFT JOIN Port por ON por.Port_ID=ls.TransferPortPOR_ID) " & _
                                   "LEFT JOIN Port pod2 ON pod2.Port_ID=ls.TransferPortPOD_ID " & _
                                   "Where ter.continued=1 and ls.continued=1 and ter.TerminalDeparture_ID='" & mTerminalDeparture_ID & "'"

            tblContainerPended = ReadDataSet(strSql)
            Me.dgdContainerPended.DataSource = tblContainerPended.Tables(0)

            If Location > 0 And Location <= Me.dgdContainerPended.Rows.Count And Me.dgdContainerPended.Rows.Count > 0 Then
                Me.dgdContainerPended.Rows(Location).Selected = True
                Me.dgdContainerPended.CurrentCell = Me.dgdContainerPended.Rows(Location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdContainerPended)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryDisChargeDetail(Optional ByVal Location As Integer = 0)
        Try
            Dim strSql As String = "Select " & _
                                   "ls.DischargeDetail_ID, " & _
                                   "ls.TerminalDeparture_ID, " & _
                                   "por.Port_Code," & _
                                   "ls.Full20GP, " & _
                                   "ls.Full40GP, " & _
                                   "ls.Full40HC, " & _
                                   "ls.Full20RF, " & _
                                   "ls.Full40RH, " & _
                                   "ls.Full45, " & _
                                   "ls.Empty20, " & _
                                   "ls.Empty40, " & _
                                   "ls.Empty45, " & _
                                   "ls.editable, " & _
                                   "ls.continued, " & _
                                   "ls.approve, " & _
                                   "ls.userid, " & _
                                   "ls.updatetime " & _
                                   "From ((TerminalDeparture ter LEFT JOIN DischargeDetail ls ON ls.TerminalDeparture_ID=ter.TerminalDeparture_ID) " & _
                                   "LEFT JOIN Port por ON por.Port_ID=ls.Port_ID) " & _
                                   "Where ter.continued=1 and ls.continued=1 and ter.TerminalDeparture_ID='" & mTerminalDeparture_ID & "'"

            tblDischargeDetail = ReadDataSet(strSql)
            Me.dgdDischargeDetail.DataSource = tblDischargeDetail.Tables(0)

            If Location > 0 And Location <= Me.dgdDischargeDetail.Rows.Count And Me.dgdDischargeDetail.Rows.Count > 0 Then
                Me.dgdDischargeDetail.Rows(Location).Selected = True
                Me.dgdDischargeDetail.CurrentCell = Me.dgdDischargeDetail.Rows(Location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdDischargeDetail)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryLoadingDetail(Optional ByVal Location As Integer = 0)
        Try
            Dim strSql As String = "Select " & _
                                   "ls.LoadingDetail_ID, " & _
                                   "ls.TerminalDeparture_ID, " & _
                                   "ls.LocalTrans, " & _
                                   "ls.Port_ID, " & _
                                   "por.Port_Code, " & _
                                   "ls.Full20GP, " & _
                                   "ls.Full40GP, " & _
                                   "ls.Full40HC, " & _
                                   "ls.Full20RF, " & _
                                   "ls.Full40RH, " & _
                                   "ls.Full45, " & _
                                   "ls.Empty20, " & _
                                   "ls.Empty40, " & _
                                   "ls.Empty45, " & _
                                   "ls.Weight, " & _
                                   "ls.Slot20, " & _
                                   "ls.Slot40, " & _
                                   "ls.editable, " & _
                                   "ls.continued, " & _
                                   "ls.approve, " & _
                                   "ls.userid, " & _
                                   "ls.updatetime " & _
                                   "From ((TerminalDeparture ter LEFT JOIN LoadingDetail ls ON ls.TerminalDeparture_ID=ter.TerminalDeparture_ID) " & _
                                   "LEFT JOIN Port por ON por.Port_ID=ls.Port_ID) " & _
                                   "Where ter.continued=1 and ls.continued=1 and ter.TerminalDeparture_ID='" & mTerminalDeparture_ID & "' " & _
                                   "Order by por.Port_Code,ls.LocalTrans"

            tblLoadingDetail = ReadDataSet(strSql)
            Me.dgdLoadingDetail.DataSource = tblLoadingDetail.Tables(0)

            If Location > 0 And Location <= Me.dgdLoadingDetail.Rows.Count And Me.dgdLoadingDetail.Rows.Count > 0 Then
                Me.dgdLoadingDetail.Rows(Location).Selected = True
                Me.dgdLoadingDetail.CurrentCell = Me.dgdLoadingDetail.Rows(Location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdLoadingDetail)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryCargoSummary(Optional ByVal Location As Integer = 0)
        Try
            Dim strSql As String = "Select " & _
                                   "ls.DetailCargo_ID, " & _
                                   "ls.TerminalDeparture_ID, " & _
                                   "ls.Operator, " & _
                                   "ls.SL20, " & _
                                   "ls.SL40, " & _
                                   "Case ls.Type when 1 then 'Danger' else 'Specail' end as Type, " & _
                                   "ls.editable, " & _
                                   "ls.continued, " & _
                                   "ls.approve, " & _
                                   "ls.userid, " & _
                                   "ls.updatetime " & _
                                   "From TerminalDeparture ter LEFT JOIN DetailCargo ls ON ls.TerminalDeparture_ID=ter.TerminalDeparture_ID " & _
                                   "Where ter.continued=1 and ls.continued=1 and ter.TerminalDeparture_ID='" & mTerminalDeparture_ID & "'"

            tblCargoSummary = ReadDataSet(strSql)
            Me.dgdCargo.DataSource = tblCargoSummary.Tables(0)

            If Location > 0 And Location <= Me.dgdCargo.Rows.Count And Me.dgdCargo.Rows.Count > 0 Then
                Me.dgdCargo.Rows(Location).Selected = True
                Me.dgdCargo.CurrentCell = Me.dgdCargo.Rows(Location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdCargo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryCVTLoading(Optional ByVal Location As Integer = 0)
        Try
            Dim strSql As String = "Select " & _
                                   "ls.CVTLoading_ID, " & _
                                   "ls.TerminalDeparture_ID, " & _
                                   "por.Port_Code, " & _
                                   "por1.Port_Code as PortDest, " & _
                                   "ls.Tue, " & _
                                   "ls.Weight, " & _
                                   "ls.SL20GP, " & _
                                   "ls.SL40GP, " & _
                                   "ls.SL40HQ, " & _
                                   "ls.SL20RF, " & _
                                   "ls.SL40RH, " & _
                                   "ls.SL20E, " & _
                                   "ls.SL40E, " & _
                                   "ls.editable, " & _
                                   "ls.continued, " & _
                                   "ls.approve, " & _
                                   "ls.userid, " & _
                                   "ls.updatetime " & _
                                   "From ((TerminalDeparture ter LEFT JOIN CVTLoading ls ON ls.TerminalDeparture_ID=ter.TerminalDeparture_ID) " & _
                                   "LEFT JOIN Port por ON por.Port_ID=ls.Port_ID) " & _
                                   "LEFT JOIN Port por1 ON por1.Port_ID=ls.PortDEST_ID " & _
                                   "Where ter.continued=1 and ls.continued=1 and ter.TerminalDeparture_ID='" & mTerminalDeparture_ID & "'"

            tblCVTLoading = ReadDataSet(strSql)
            Me.dgdCVT.DataSource = tblCVTLoading.Tables(0)

            If Location > 0 And Location <= Me.dgdCVT.Rows.Count And Me.dgdCVT.Rows.Count > 0 Then
                Me.dgdCVT.Rows(Location).Selected = True
                Me.dgdCVT.CurrentCell = Me.dgdCVT.Rows(Location).Cells(2)
            End If
            InsertAutoNumberToGrid(Me.dgdCVT)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub SetchkLS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20GP_CheckedChanged(sender, e)
        Me.chk40GP_CheckedChanged(sender, e)
        Me.chk40HC_CheckedChanged(sender, e)
        Me.chk20RF_CheckedChanged(sender, e)
        Me.chk40RH_CheckedChanged(sender, e)
        Me.chk45_CheckedChanged(sender, e)
    End Sub

    Private Sub cxtsmnuLSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuLSAdd.Click
        On Error GoTo Err_Renamed
        If mStatusLS = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            If mTerminalDeparture_ID = DefaultValue Then
                MsgBox("Please input Terminal")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            Me.grp1.Enabled = True
            Me.dgdLoadingSummary.Enabled = False
            mLoadingSummary_ID = DefaultValue
            mStatusLS = "Add"
            Me.chk20GP.Checked = False
            Me.chk40GP.Checked = False
            Me.chk40HC.Checked = False
            Me.chk20RF.Checked = False
            Me.chk40RH.Checked = False
            Me.chk45.Checked = False
            SetchkLS(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuLSEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuLSEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If tblLoadingSummary.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdLoadingSummary.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdLoadingSummary.Item("ApproveLS", index).Value
            EditTable = Me.dgdLoadingSummary.Item("EditableLS", index).Value
            If mStatusLS = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdLoadingSummary.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdLoadingSummary.Enabled = False
                Me.grp1.Enabled = True
                mLoadingSummary_ID = Me.dgdLoadingSummary.Item("LoadingSummary_ID", index).Value.ToString
                mStatusLS = "Edit"
                RefreshDataLS(index)
                SetchkLS(sender, e)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuLSDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuLSDelete.Click
        Dim selectedRowCount As Integer = _
              Me.dgdLoadingSummary.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowLS(Me.dgdLoadingSummary.SelectedRows(i).Index)
            Next i
        End If
        QueryLoadingSummary()
    End Sub

    Private Sub cmdOKLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKLD.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.tblLoadingSummary.Tables(0).Rows.Count > 0) Then
            index = Me.dgdLoadingSummary.CurrentRow.Index
        End If

        If CheckDataLS() And (mStatusLS = "Add" Or mStatusLS = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM LoadingSummary "
            strQuery = strQuery & "WHERE LoadingSummary_ID = '" & mLoadingSummary_ID & "' AND LoadingSummary_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("LoadingSummary_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"
                .Fields("Operator").Value = Me.txtOperator.Text.Trim
                If Me.rdoFull.Checked = True Then
                    .Fields("FullEmpty").Value = "Full"
                Else
                    .Fields("FullEmpty").Value = "Empty"
                End If

                If Me.chk20GP.Checked = True Then
                    .Fields("SL20GP").Value = CDbl(Me.txt20GP.Text.Trim)
                Else
                    .Fields("SL20GP").Value = Nothing
                End If

                If Me.chk40GP.Checked = True Then
                    .Fields("SL40GP").Value = CDbl(Me.txt40GP.Text.Trim)
                Else
                    .Fields("SL40GP").Value = Nothing
                End If

                If Me.chk40HC.Checked = True Then
                    .Fields("SL40HC").Value = CDbl(Me.txt40HC.Text.Trim)
                Else
                    .Fields("SL40HC").Value = Nothing
                End If

                If Me.chk20RF.Checked = True Then
                    .Fields("SL20RF").Value = CDbl(Me.txt20RF.Text.Trim)
                Else
                    .Fields("SL20RF").Value = Nothing
                End If

                If Me.chk40RH.Checked = True Then
                    .Fields("SL40RH").Value = CDbl(Me.txt40RH.Text.Trim)
                Else
                    .Fields("SL40RH").Value = Nothing
                End If

                If Me.chk45.Checked = True Then
                    .Fields("SL45").Value = CDbl(Me.txt45.Text.Trim)
                Else
                    .Fields("SL45").Value = Nothing
                End If

                If IsNumeric(Me.txtWeight.Text.Trim) = False Then
                    .Fields("Weight").Value = "0.0"
                Else
                    .Fields("Weight").Value = Me.txtWeight.Text.Trim
                End If

                .Update()

            End With
            rs.Close()
            Me.dgdLoadingSummary.Enabled = True

            QueryLoadingSummary(index)
            mStatusLS = "Normal"
            Me.grp1.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelLD.Click
        Try
            Me.dgdLoadingSummary.Enabled = True
            Me.grp1.Enabled = False
            mStatusLS = "Normal"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdLoadingSummary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdLoadingSummary.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdLoadingSummary.RowCount = 0 Then
            Return
        End If
        Dim index As Integer
        index = Me.dgdLoadingSummary.CurrentRow.Index
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdLoadingSummary.CurrentCellAddress.X = 13 And Me.dgdLoadingSummary.CurrentCellAddress().Y = index Then
            Call ApproveLoadingSummary()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub SetchkCP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20GPLocal_CheckedChanged(sender, e)
        Me.chk40GPLocal_CheckedChanged(sender, e)
        Me.chk20GPTrans_CheckedChanged(sender, e)
        Me.chk40GPTrans_CheckedChanged(sender, e)
    End Sub

    Sub SetchkDS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20GPFullDis_CheckedChanged(sender, e)
        Me.chk40GPFullDis_CheckedChanged(sender, e)
        Me.chk40RHFullDis_CheckedChanged(sender, e)
        Me.chk20RFFullDis_CheckedChanged(sender, e)
        Me.chk40HCFullDis_CheckedChanged(sender, e)
        Me.chk45FullDis_CheckedChanged(sender, e)
        Me.chk20EmptyDis_CheckedChanged(sender, e)
        Me.chk40EmptyDis_CheckedChanged(sender, e)
        Me.chk45EmptyDis_CheckedChanged(sender, e)
    End Sub

    Sub SetchkCVT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20GPCVT_CheckedChanged(sender, e)
        Me.chk40GPCVT_CheckedChanged(sender, e)
        Me.chk40HCCVT_CheckedChanged(sender, e)
        Me.chk20RFCVT_CheckedChanged(sender, e)
        Me.chk40RHCVT_CheckedChanged(sender, e)
        Me.chk20ECVT_CheckedChanged(sender, e)
        Me.chk40ECVT_CheckedChanged(sender, e)
    End Sub

    Sub SetchkLD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20GPSubFull_CheckedChanged(sender, e)
        Me.chk40GPSubFull_CheckedChanged(sender, e)
        Me.chk40RHSubFull_CheckedChanged(sender, e)
        Me.chk20RFSubFull_CheckedChanged(sender, e)
        Me.chk40HCSubFull_CheckedChanged(sender, e)
        Me.chk45SubFull_CheckedChanged(sender, e)

        Me.chk20GPTSFull_CheckedChanged(sender, e)
        Me.chk40GPTSFull_CheckedChanged(sender, e)
        Me.chk40RHTSFull_CheckedChanged(sender, e)
        Me.chk20RFTSFull_CheckedChanged(sender, e)
        Me.chk40HCTSFull_CheckedChanged(sender, e)
        Me.chk45TSFull_CheckedChanged(sender, e)

        Me.chk20subEmpTy_CheckedChanged(sender, e)
        Me.chk40SubEmpty_CheckedChanged(sender, e)
        Me.chk45SubEmpty_CheckedChanged(sender, e)

        Me.chk20TSEmpty_CheckedChanged(sender, e)
        Me.chk40TSEmpty_CheckedChanged(sender, e)
        Me.chk45TSEmpty_CheckedChanged(sender, e)

        Me.chkSlot20_CheckedChanged(sender, e)
        Me.chkSlot45_CheckedChanged(sender, e)

    End Sub

    Sub SetchkCS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.chk20CG_CheckedChanged(sender, e)
        Me.chk40CG_CheckedChanged(sender, e)
    End Sub

    Private Sub cxtsmnuCPAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuCPAdd.Click
        On Error GoTo Err_Renamed
        If mStatusCP = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            If mTerminalDeparture_ID = DefaultValue Then
                MsgBox("Please input Terminal")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            Me.grp2.Enabled = True
            Me.grp3.Enabled = True
            Me.cmdOKContainerPended.Enabled = True
            Me.dgdContainerPended.Enabled = False
            mContainerPended_ID = DefaultValue
            mStatusCP = "Add"
            Me.chk20GPLocal.Checked = False
            Me.chk40GPLocal.Checked = False
            Me.chk20GPTrans.Checked = False
            Me.chk40GPTrans.Checked = False
            SetchkCP(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuCPEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuCPEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If tblContainerPended.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdContainerPended.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdContainerPended.Item("ApproveCP", index).Value
            EditTable = Me.dgdContainerPended.Item("EditableCP", index).Value
            If mStatusCP = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdContainerPended.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdContainerPended.Enabled = False
                Me.grp2.Enabled = True
                Me.grp3.Enabled = True
                Me.cmdOKContainerPended.Enabled = True
                mContainerPended_ID = Me.dgdContainerPended.Item("ContainerPended_ID", index).Value.ToString
                mStatusCP = "Edit"
                RefreshDataCP(index)
                SetchkCP(sender, e)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuCPDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuCPDelete.Click
        Dim selectedRowCount As Integer = _
              Me.dgdContainerPended.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowCP(Me.dgdContainerPended.SelectedRows(i).Index)
            Next i
        End If
        QueryContainerPeneded()
    End Sub

    Private Sub cmdOKContainerPended_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKContainerPended.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.tblContainerPended.Tables(0).Rows.Count > 0) Then
            index = Me.dgdContainerPended.CurrentRow.Index
        End If

        If CheckDataCP() And (mStatusCP = "Add" Or mStatusCP = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM ContainerPended "
            strQuery = strQuery & "WHERE ContainerPended_ID = '" & mContainerPended_ID & "' AND ContainerPended_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("ContainerPended_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"

                If Me.chk20GPLocal.Checked = True Then
                    .Fields("Local20GP").Value = CDbl(Me.txt20GPLocal.Text.Trim)
                Else
                    .Fields("Local20GP").Value = Nothing
                End If

                If Me.chk40GPLocal.Checked = True Then
                    .Fields("Local40GP").Value = CDbl(Me.txt40GPLocal.Text.Trim)
                Else
                    .Fields("Local40GP").Value = Nothing
                End If

                If Me.chk20GPTrans.Checked = True Then
                    .Fields("Transfer20GP").Value = CDbl(Me.txt20GPTrans.Text.Trim)
                Else
                    .Fields("Transfer20GP").Value = Nothing
                End If

                If Me.chk40GPTrans.Checked = True Then
                    .Fields("Transfer40GP").Value = CDbl(Me.txt40GPTrans.Text.Trim)
                Else
                    .Fields("Transfer40GP").Value = Nothing
                End If

                .Fields("LocalPortPOD_ID").Value = "{" & FindValueID(Me.cboPortPODLocal, Me.cboPortPODLocal.Text.Trim) & "}"
                .Fields("TransferPortPOR_ID").Value = "{" & FindValueID(Me.cboPortPORTrans, Me.cboPortPORTrans.Text.Trim) & "}"
                .Fields("TransferPortPOD_ID").Value = "{" & FindValueID(Me.cboPortPODTrans, Me.cboPortPODTrans.Text.Trim) & "}"
                .Update()

            End With
            rs.Close()
            Me.dgdContainerPended.Enabled = True

            QueryContainerPeneded(index)
            mStatusCP = "Normal"
            Me.grp2.Enabled = False
            Me.grp3.Enabled = False
            Me.cmdOKContainerPended.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelContainerPended_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelContainerPended.Click
        Try
            Me.dgdContainerPended.Enabled = True
            Me.grp2.Enabled = False
            Me.grp3.Enabled = False
            Me.cmdOKContainerPended.Enabled = False
            mStatusCP = "Normal"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdContainerPended_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainerPended.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If Me.dgdContainerPended.RowCount = 0 Then
            Return
        End If
        index = Me.dgdContainerPended.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdContainerPended.CurrentCellAddress.X = 11 And Me.dgdContainerPended.CurrentCellAddress().Y = index Then
            Call ApproveContainerPended()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuAddDisCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuAddDisCharge.Click
        On Error GoTo Err_Renamed
        If mStatusDS = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            If mTerminalDeparture_ID = DefaultValue Then
                MsgBox("Please input Terminal")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            Me.grp4.Enabled = True
            Me.grp5.Enabled = True
            Me.cmdOKDischargeDetail.Enabled = True
            Me.dgdDischargeDetail.Enabled = False
            mDisCharheDetail_ID = DefaultValue
            mStatusDS = "Add"
            Me.chk20GPFullDis.Checked = False
            Me.chk40GPFullDis.Checked = False
            Me.chk40HCFullDis.Checked = False
            Me.chk20RFFullDis.Checked = False
            Me.chk40RHFullDis.Checked = False
            Me.chk45FullDis.Checked = False
            Me.chk20EmptyDis.Checked = False
            Me.chk40EmptyDis.Checked = False
            Me.chk45EmptyDis.Checked = False

            SetchkDS(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuEditDis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuEditDis.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If tblDischargeDetail.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdDischargeDetail.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdDischargeDetail.Item("ApproveDis", index).Value
            EditTable = Me.dgdDischargeDetail.Item("EditableDis", index).Value
            If mStatusDS = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdDischargeDetail.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdDischargeDetail.Enabled = False
                Me.grp4.Enabled = True
                Me.grp5.Enabled = True
                Me.cmdOKDischargeDetail.Enabled = True
                mDisCharheDetail_ID = Me.dgdDischargeDetail.Item("DischargeDetail_ID", index).Value.ToString
                mStatusDS = "Edit"
                RefreshDataDS(index)
                SetchkDS(sender, e)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuDelDis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuDelDis.Click
        Dim selectedRowCount As Integer = _
                      Me.dgdDischargeDetail.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowDS(Me.dgdDischargeDetail.SelectedRows(i).Index)
            Next i
        End If
        QueryDisChargeDetail()
    End Sub

    Private Sub cmdOKDischargeDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKDischargeDetail.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.tblDischargeDetail.Tables(0).Rows.Count > 0) Then
            index = Me.dgdDischargeDetail.CurrentRow.Index
        End If

        If CheckDataDS() And (mStatusDS = "Add" Or mStatusDS = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM DISCHARGEDETAIL "
            strQuery = strQuery & "WHERE DischargeDetail_ID = '" & mDisCharheDetail_ID & "' AND DischargeDetail_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("DischargeDetail_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"

                If Me.chk20GPFullDis.Checked = True Then
                    .Fields("Full20GP").Value = CDbl(Me.txt20GPFullDis.Text.Trim)
                Else
                    .Fields("Full20GP").Value = Nothing
                End If

                If Me.chk40GPFullDis.Checked = True Then
                    .Fields("Full40GP").Value = CDbl(Me.txt40GPFullDis.Text.Trim)
                Else
                    .Fields("Full40GP").Value = Nothing
                End If

                If Me.chk40HCFullDis.Checked = True Then
                    .Fields("Full40HC").Value = CDbl(Me.txt40HCFullDis.Text.Trim)
                Else
                    .Fields("Full40HC").Value = Nothing
                End If

                If Me.chk20RFFullDis.Checked = True Then
                    .Fields("Full20RF").Value = CDbl(Me.txt20RFFullDis.Text.Trim)
                Else
                    .Fields("Full20RF").Value = Nothing
                End If

                If Me.chk40RHFullDis.Checked = True Then
                    .Fields("Full40RH").Value = CDbl(Me.txt40RHFullDis.Text.Trim)
                Else
                    .Fields("Full40RH").Value = Nothing
                End If

                If Me.chk45FullDis.Checked = True Then
                    .Fields("Full45").Value = CDbl(Me.txt45FullDis.Text.Trim)
                Else
                    .Fields("Full45").Value = Nothing
                End If

                If Me.chk20EmptyDis.Checked = True Then
                    .Fields("Empty20").Value = CDbl(Me.txt20EmptyDis.Text.Trim)
                Else
                    .Fields("Empty20").Value = Nothing
                End If

                If Me.chk40EmptyDis.Checked = True Then
                    .Fields("Empty40").Value = CDbl(Me.txt40EmptyDis.Text.Trim)
                Else
                    .Fields("Empty40").Value = Nothing
                End If

                If Me.chk45EmptyDis.Checked = True Then
                    .Fields("Empty45").Value = CDbl(Me.txt45EmptyDis.Text.Trim)
                Else
                    .Fields("Empty45").Value = Nothing
                End If

                .Fields("Port_ID").Value = "{" & FindValueID(Me.cboPortPOL, Me.cboPortPOL.Text.Trim) & "}"
                .Update()

            End With
            rs.Close()
            Me.dgdDischargeDetail.Enabled = True

            QueryDisChargeDetail(index)
            mStatusDS = "Normal"
            Me.grp4.Enabled = False
            Me.grp5.Enabled = False
            Me.cmdOKDischargeDetail.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelDischagreDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelDischagreDetail.Click
        Try
            Me.dgdDischargeDetail.Enabled = True
            Me.grp4.Enabled = False
            Me.grp5.Enabled = False
            Me.cmdOKDischargeDetail.Enabled = False
            mStatusDS = "Normal"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdDischargeDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDischargeDetail.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdDischargeDetail.RowCount = 0 Then
            Return
        End If
        Dim index As Integer
        index = Me.dgdDischargeDetail.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdDischargeDetail.CurrentCellAddress.X = 14 And Me.dgdDischargeDetail.CurrentCellAddress().Y = index Then
            Call ApproveDischargeDetail()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuAddLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuAddLD.Click
        On Error GoTo Err_Renamed
        If mStatusLD = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            If mTerminalDeparture_ID = DefaultValue Then
                MsgBox("Please input Terminal")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            Me.grp6.Enabled = True
            Me.grp8.Enabled = True
            Me.cboPortPOD.Enabled = True
            Me.cmdOKLoadingDetail.Enabled = True
            Me.dgdLoadingDetail.Enabled = False
            mLoadingDetail_ID = DefaultValue
            mStatusLD = "Add"
            Me.chk20GPSubFull.Checked = False
            Me.chk40GPSubFull.Checked = False
            Me.chk40HCSubFull.Checked = False
            Me.chk20RFSubFull.Checked = False
            Me.chk40RHSubFull.Checked = False
            Me.chk45SubFull.Checked = False

            Me.chk20GPTSFull.Checked = False
            Me.chk40GPTSFull.Checked = False
            Me.chk40HCTSFull.Checked = False
            Me.chk20RFTSFull.Checked = False
            Me.chk40RHTSFull.Checked = False
            Me.chk45TSFull.Checked = False

            Me.chk20subEmpTy.Checked = False
            Me.chk40SubEmpty.Checked = False
            Me.chk45SubEmpty.Checked = False

            Me.chk20TSEmpty.Checked = False
            Me.chk40TSEmpty.Checked = False
            Me.chk45TSEmpty.Checked = False

            SetchkLD(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuEditLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuEditLD.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If tblLoadingDetail.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdLoadingDetail.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdLoadingDetail.Item("ApproveLD", index).Value
            EditTable = Me.dgdLoadingDetail.Item("EditableLD", index).Value
            If mStatusLD = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdLoadingDetail.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdLoadingDetail.Enabled = False
                Me.grp6.Enabled = True
                Me.grp8.Enabled = True
                Me.cmdOKLoadingDetail.Enabled = True
                mLoadingDetail_ID = Me.dgdLoadingDetail.Item("LoadingDetail_ID", index).Value.ToString
                mStatusLD = "Edit"
                RefreshDataLD(index)
                SetchkLD(sender, e)
                'Me.cboPortPOD.Enabled = False
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuDelLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuDelLD.Click
        Dim selectedRowCount As Integer = _
                       Me.dgdLoadingDetail.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowLD(Me.dgdLoadingDetail.SelectedRows(i).Index)
            Next i
        End If
        QueryLoadingDetail()
    End Sub

    Private Sub cmdOKLoadingDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKLoadingDetail.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.tblLoadingDetail.Tables(0).Rows.Count > 0) Then
            index = Me.dgdLoadingDetail.CurrentRow.Index
        End If

        If CheckDataLD() And (mStatusLD = "Add" Or mStatusLD = "Edit") Then

            Dim tbl As New DataSet
            Dim st(1) As String
            st(0) = DefaultValue
            st(1) = DefaultValue
            tbl = ReadDataSet("Select LoadingDetail_ID From LoadingDetail Where Port_ID='" & Me.dgdLoadingDetail.Item("PortPOD_ID", index).Value.ToString & "'") '& FindValueID(Me.cboPortPOD, Me.cboPortPOD.Text.Trim) & "'")
            If tbl.Tables(0).Rows.Count = 2 Then
                st(0) = tbl.Tables(0).Rows(0).Item("LoadingDetail_ID").ToString
                st(1) = tbl.Tables(0).Rows(1).Item("LoadingDetail_ID").ToString
            End If

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM LoadingDetail "
            strQuery = strQuery & "WHERE LoadingDetail_ID = '" & st(0) & "' AND LoadingDetail_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("LoadingDetail_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"

                If Me.rdoSubFull.Checked = True Then
                    .Fields("LocalTrans").Value = "SUB TTL"
                Else
                    .Fields("LocalTrans").Value = "LOCAL"
                End If

                If Me.chk20GPSubFull.Checked = True Then
                    .Fields("Full20GP").Value = CDbl(Me.txt20GPSubFull.Text.Trim)
                Else
                    .Fields("Full20GP").Value = Nothing
                End If

                If Me.chk40GPSubFull.Checked = True Then
                    .Fields("Full40GP").Value = CDbl(Me.txt40GPSubFull.Text.Trim)
                Else
                    .Fields("Full40GP").Value = Nothing
                End If

                If Me.chk40HCSubFull.Checked = True Then
                    .Fields("Full40HC").Value = CDbl(Me.txt40HCSubFull.Text.Trim)
                Else
                    .Fields("Full40HC").Value = Nothing
                End If

                If Me.chk20RFSubFull.Checked = True Then
                    .Fields("Full20RF").Value = CDbl(Me.txt20RFSubFull.Text.Trim)
                Else
                    .Fields("Full20RF").Value = Nothing
                End If

                If Me.chk40RHSubFull.Checked = True Then
                    .Fields("Full40RH").Value = CDbl(Me.txt40RHSubFull.Text.Trim)
                Else
                    .Fields("Full40RH").Value = Nothing
                End If

                If Me.chk45SubFull.Checked = True Then
                    .Fields("Full45").Value = CDbl(Me.txt45SubFull.Text.Trim)
                Else
                    .Fields("Full45").Value = Nothing
                End If

                If Me.chk20subEmpTy.Checked = True Then
                    .Fields("Empty20").Value = CDbl(Me.txt20SubEmpty.Text.Trim)
                Else
                    .Fields("Empty20").Value = Nothing
                End If

                If Me.chk40SubEmpty.Checked = True Then
                    .Fields("Empty40").Value = CDbl(Me.txt40SubEmpty.Text.Trim)
                Else
                    .Fields("Empty40").Value = Nothing
                End If

                If Me.chk45SubEmpty.Checked = True Then
                    .Fields("Empty45").Value = CDbl(Me.txt45SubEmpty.Text.Trim)
                Else
                    .Fields("Empty45").Value = Nothing
                End If

                If Me.chkSlot20.Checked = True Then
                    .Fields("Slot20").Value = CDbl(Me.txtSlot20.Text.Trim)
                Else
                    .Fields("Slot20").Value = Nothing
                End If

                If Me.chkSlot45.Checked = True Then
                    .Fields("Slot40").Value = CDbl(Me.txtSlot45.Text.Trim)
                Else
                    .Fields("Slot40").Value = Nothing
                End If
                If IsNumeric(Me.txtCSCWeight.Text.Trim) = True Then
                    .Fields("Weight").Value = CDbl(Me.txtCSCWeight.Text.Trim)
                Else
                    .Fields("Weight").Value = 0.0
                End If

                .Fields("Port_ID").Value = "{" & FindValueID(Me.cboPortPOD, Me.cboPortPOD.Text.Trim) & "}"
                .Update()

            End With
            rs.Close()

            '------------------
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM LoadingDetail "
            strQuery = strQuery & "WHERE LoadingDetail_ID = '" & st(1) & "' AND LoadingDetail_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("LoadingDetail_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"


                .Fields("LocalTrans").Value = "T/S"

                If Me.chk20GPTSFull.Checked = True Then
                    .Fields("Full20GP").Value = CDbl(Me.txt20GPTSFull.Text.Trim)
                Else
                    .Fields("Full20GP").Value = Nothing
                End If

                If Me.chk40GPTSFull.Checked = True Then
                    .Fields("Full40GP").Value = CDbl(Me.txt40GPTSFull.Text.Trim)
                Else
                    .Fields("Full40GP").Value = Nothing
                End If

                If Me.chk40HCTSFull.Checked = True Then
                    .Fields("Full40HC").Value = CDbl(Me.txt40HCTSFull.Text.Trim)
                Else
                    .Fields("Full40HC").Value = Nothing
                End If

                If Me.chk20RFTSFull.Checked = True Then
                    .Fields("Full20RF").Value = CDbl(Me.txt20RFTSFull.Text.Trim)
                Else
                    .Fields("Full20RF").Value = Nothing
                End If

                If Me.chk40RHTSFull.Checked = True Then
                    .Fields("Full40RH").Value = CDbl(Me.txt40RHTSFull.Text.Trim)
                Else
                    .Fields("Full40RH").Value = Nothing
                End If

                If Me.chk45TSFull.Checked = True Then
                    .Fields("Full45").Value = CDbl(Me.txt45TSFull.Text.Trim)
                Else
                    .Fields("Full45").Value = Nothing
                End If

                If Me.chk20TSEmpty.Checked = True Then
                    .Fields("Empty20").Value = CDbl(Me.txt20TSEmpty.Text.Trim)
                Else
                    .Fields("Empty20").Value = Nothing
                End If

                If Me.chk40TSEmpty.Checked = True Then
                    .Fields("Empty40").Value = CDbl(Me.txt40TSEmpty.Text.Trim)
                Else
                    .Fields("Empty40").Value = Nothing
                End If

                If Me.chk45TSEmpty.Checked = True Then
                    .Fields("Empty45").Value = CDbl(Me.txt45TSEmpty.Text.Trim)
                Else
                    .Fields("Empty45").Value = Nothing
                End If

                If Me.chkSlot20.Checked = True Then
                    .Fields("Slot20").Value = CDbl(Me.txtSlot20.Text.Trim)
                Else
                    .Fields("Slot20").Value = Nothing
                End If

                If Me.chkSlot45.Checked = True Then
                    .Fields("Slot40").Value = CDbl(Me.txtSlot45.Text.Trim)
                Else
                    .Fields("Slot40").Value = Nothing
                End If
                If IsNumeric(Me.txtCSCWeight.Text.Trim) = True Then
                    .Fields("Weight").Value = CDbl(Me.txtCSCWeight.Text.Trim)
                Else
                    .Fields("Weight").Value = 0.0
                End If

                .Fields("Port_ID").Value = "{" & FindValueID(Me.cboPortPOD, Me.cboPortPOD.Text.Trim) & "}"
                .Update()

            End With
            rs.Close()

            Me.dgdLoadingDetail.Enabled = True

            QueryLoadingDetail(index)
            mStatusLD = "Normal"
            Me.grp6.Enabled = False
            Me.grp8.Enabled = False
            Me.cmdOKLoadingDetail.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelLoadingDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelLoadingDetail.Click
        Try
            Me.dgdLoadingDetail.Enabled = True
            Me.grp6.Enabled = False
            Me.grp8.Enabled = False
            Me.cmdOKLoadingDetail.Enabled = False
            mStatusLD = "Normal"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdLoadingDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdLoadingDetail.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdLoadingDetail.RowCount = 0 Then
            Return
        End If
        Dim index As Integer
        index = Me.dgdLoadingDetail.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdLoadingDetail.CurrentCellAddress.X = 20 And Me.dgdLoadingDetail.CurrentCellAddress().Y = index Then
            Call ApproveLoadingDetail()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuAddCargoSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuAddCargoSum.Click
        On Error GoTo Err_Renamed
        If mStatusCS = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            If mTerminalDeparture_ID = DefaultValue Then
                MsgBox("Please input Terminal")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            Me.dgdCargo.Enabled = False
            Me.cmdOKCargo.Enabled = True
            mCargoSummary_ID = DefaultValue
            mStatusCS = "Add"
            Me.chk20CG.Checked = False
            Me.chk40CG.Checked = False
            SetchkCS(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuEditCargoSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuEditCargoSum.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If tblCargoSummary.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCargo.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdCargo.Item("ApproveCG", index).Value
            EditTable = Me.dgdCargo.Item("EditableCG", index).Value
            If mStatusCS = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdCargo.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdCargo.Enabled = False
                Me.cmdOKCargo.Enabled = True
                mCargoSummary_ID = Me.dgdCargo.Item("DetailCargo_ID", index).Value.ToString
                mStatusCS = "Edit"
                RefreshDataCS(index)
                SetchkCS(sender, e)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuDelCargoSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuDelCargoSum.Click
        Dim selectedRowCount As Integer = _
                      Me.dgdCargo.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowCS(Me.dgdCargo.SelectedRows(i).Index)
            Next i
        End If
        QueryCargoSummary()
    End Sub

    Private Sub cmdOKCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKCargo.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.tblCargoSummary.Tables(0).Rows.Count > 0) Then
            index = Me.dgdCargo.CurrentRow.Index
        End If

        If CheckDataCS() And (mStatusCS = "Add" Or mStatusCS = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM DETAILCARGO "
            strQuery = strQuery & "WHERE DetailCargo_ID = '" & mCargoSummary_ID & "' AND DetailCargo_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("DetailCargo_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"
                .Fields("Operator").Value = Me.txtOperatorCG.Text.Trim
                If Me.rdoDanger.Checked = True Then
                    .Fields("Type").Value = 1
                Else
                    .Fields("Type").Value = 0
                End If

                If Me.chk20CG.Checked = True Then
                    .Fields("SL20").Value = CDbl(Me.txt20CG.Text.Trim)
                Else
                    .Fields("SL20").Value = Nothing
                End If

                If Me.chk40CG.Checked = True Then
                    .Fields("SL40").Value = CDbl(Me.txt40CG.Text.Trim)
                Else
                    .Fields("SL40").Value = Nothing
                End If

                .Update()

            End With
            rs.Close()
            Me.dgdCargo.Enabled = True

            QueryCargoSummary(index)
            mStatusCS = "Normal"
            Me.cmdOKCargo.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelCargo.Click
        Try
            Me.dgdCargo.Enabled = True
            Me.cmdOKCargo.Enabled = False
            mStatusCS = "Normal"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdCargo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCargo.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCargo.RowCount = 0 Then
            Return
        End If
        Dim index As Integer
        index = Me.dgdCargo.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdCargo.CurrentCellAddress.X = 8 And Me.dgdCargo.CurrentCellAddress().Y = index Then
            Call ApproveCargoSummary()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtAddCVTLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtAddCVTLoading.Click
        On Error GoTo Err_Renamed
        If mStatusCVT = "Normal" And UserRight("frmAgencyVessel", "Add") Then
            If mTerminalDeparture_ID = DefaultValue Then
                MsgBox("Please input Terminal")
                Me.fraUpdate.SelectedIndex = 0
                Return
            End If
            Me.cmdOKCVT.Enabled = True
            Me.dgdCVT.Enabled = False
            mCVTLoading_ID = DefaultValue
            mStatusCVT = "Add"
            Me.chk20GPCVT.Checked = False
            Me.chk40GPCVT.Checked = False
            Me.chk40HQCVT.Checked = False
            Me.chk20RFCVT.Checked = False
            Me.chk40RHCVT.Checked = False
            Me.chk20ECVT.Checked = False
            Me.chk40ECVT.Checked = False
            SetchkCVT(sender, e)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtEditCVTLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtEditCVTLoading.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If tblCVTLoading.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCVT.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdCVT.Item("ApproveCVT", index).Value
            EditTable = Me.dgdCVT.Item("EditableCVT", index).Value
            If mStatusCVT = "Normal" And Not Approve And EditTable And UserRight("frmAgencyVessel", "Edit") And Not Me.dgdCVT.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdCVT.Enabled = False
                Me.cmdOKCVT.Enabled = True
                mCVTLoading_ID = Me.dgdCVT.Item("CVTLoading_ID", index).Value.ToString
                mStatusCVT = "Edit"
                RefreshDataCVT(index)
                SetchkCVT(sender, e)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtDelCVTLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtDelCVTLoading.Click
        Dim selectedRowCount As Integer = _
                      Me.dgdCVT.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowCVT(Me.dgdCVT.SelectedRows(i).Index)
            Next i
        End If
        QueryCVTLoading()
    End Sub

    Private Sub cmdOKCVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKCVT.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.tblCVTLoading.Tables(0).Rows.Count > 0) Then
            index = Me.dgdCVT.CurrentRow.Index
        End If

        If CheckDataCVT() And (mStatusCVT = "Add" Or mStatusCVT = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CVTLoading "
            strQuery = strQuery & "WHERE CVTLoading_ID = '" & mCVTLoading_ID & "' AND CVTLoading_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CVTLoading_ID").Value = NewId()
                End If

                .Fields("TerminalDeparture_ID").Value = "{" & mTerminalDeparture_ID & "}"

                .Fields("Port_ID").Value = "{" & FindValueID(Me.cboPortPODCVT, Me.cboPortPODCVT.Text.Trim) & "}"
                .Fields("PortDEST_ID").Value = "{" & FindValueID(Me.cboDEST, Me.cboDEST.Text.Trim) & "}"

                If IsNumeric(Me.txtTueCVT.Text.Trim) = True Then
                    .Fields("Tue").Value = CDbl(Me.txtTueCVT.Text.Trim)
                Else
                    .Fields("Tue").Value = 0.0
                End If

                If IsNumeric(Me.txtWeightCVT.Text.Trim) = True Then
                    .Fields("Weight").Value = CDbl(Me.txtWeightCVT.Text.Trim)
                Else
                    .Fields("Weight").Value = 0.0
                End If

                If Me.chk20GPCVT.Checked = True Then
                    .Fields("SL20GP").Value = CDbl(Me.txt20GPCVT.Text.Trim)
                Else
                    .Fields("SL20GP").Value = Nothing
                End If

                If Me.chk40GPCVT.Checked = True Then
                    .Fields("SL40GP").Value = CDbl(Me.txt40GPCVT.Text.Trim)
                Else
                    .Fields("SL40GP").Value = Nothing
                End If

                If Me.chk40HQCVT.Checked = True Then
                    .Fields("SL40HQ").Value = CDbl(Me.txt40HQCVT.Text.Trim)
                Else
                    .Fields("SL40HQ").Value = Nothing
                End If

                If Me.chk20RFCVT.Checked = True Then
                    .Fields("SL20RF").Value = CDbl(Me.txt20RFCVT.Text.Trim)
                Else
                    .Fields("SL20RF").Value = Nothing
                End If

                If Me.chk40RHCVT.Checked = True Then
                    .Fields("SL40RH").Value = CDbl(Me.txt40RHCVT.Text.Trim)
                Else
                    .Fields("SL40RH").Value = Nothing
                End If

                If Me.chk20ECVT.Checked = True Then
                    .Fields("SL20E").Value = CDbl(Me.txt20ECVT.Text.Trim)
                Else
                    .Fields("SL20E").Value = Nothing
                End If

                If Me.chk40ECVT.Checked = True Then
                    .Fields("SL40E").Value = CDbl(Me.txt40ECVT.Text.Trim)
                Else
                    .Fields("SL40E").Value = Nothing
                End If

                .Update()

            End With
            rs.Close()
            Me.dgdCVT.Enabled = True

            QueryCVTLoading(index)
            mStatusCVT = "Normal"
            Me.cmdOKCVT.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelCVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelCVT.Click
        Try
            Me.dgdCVT.Enabled = True
            Me.cmdOKCVT.Enabled = False
            mStatusCVT = "Normal"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdCVT_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCVT.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCVT.RowCount = 0 Then
            Return
        End If
        Dim index As Integer
        index = Me.dgdCVT.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdCVT.CurrentCellAddress.X = 15 And Me.dgdCVT.CurrentCellAddress().Y = index Then
            Call ApproveCVTLoading()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryData("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtsmnuSVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSVessel.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboVessel.Name
            Dim frm As New frmListVessel
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuSPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSPort.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPort.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuSPortPODLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSPortPODLocal.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPortPODLocal.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPORLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPORLocal.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPortPORTrans.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPODTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPODTrans.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPortPODTrans.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPOL.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPortPOL.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPOD.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPortPOD.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPODCVT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPODCVT.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPortPODCVT.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportStandar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportStandar.Click
        Try
            If Me.dgdData.RowCount > 0 Then
                ExportExecel(Me.dgdData, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtsmnuSDEST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSDEST.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboDEST.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportForm.Click
        Try
            If Me.dgdData.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdData.CurrentRow.Index
            mTerminalDeparture_ID = Me.dgdData.Item("TerminalDeparture_ID", index).Value.ToString

            Dim app As Application
            app = New Application()
            'app.Visible = True
            Me.Cursor = Cursors.WaitCursor
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook
            Dim path As String = StartupPath & "\TDR & LOADING SUMMARY.xls"
            '& "\InbounCommission.xls"
            workbook = workbooks.Open(path)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item("TDR")
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim f As Integer

            ws.Range("D4").Value = Me.dgdData.Item("Vessel", index).Value
            ws.Range("D5").Value = Me.dgdData.Item("PortCode", index).Value
            ws.Range("J4").Value = Me.dgdData.Item("Voyage", index).Value
            ws.Range("J5").Value = Me.dgdData.Item("WharfName", index).Value
            ws.Range("D7").Value = Me.dgdData.Item("ArrivalPilot_A", index).Value

            ws.Range("D8").Value = Me.dgdData.Item("PilotOnboard_A", index).Value
            ws.Range("D9").Value = Me.dgdData.Item("FirstLine", index).Value
            ws.Range("D10").Value = Me.dgdData.Item("Commenced", index).Value
            ws.Range("D11").Value = Me.dgdData.Item("FO_A", index).Value
            ws.Range("D12").Value = Me.dgdData.Item("DO_A", index).Value
            ws.Range("D13").Value = Me.dgdData.Item("FreshWater_A", index).Value
            ws.Range("D14").Value = Me.dgdData.Item("DraftFwd_A", index).Value
            ws.Range("D15").Value = Me.dgdData.Item("DraftAft_A", index).Value
            ws.Range("D16").Value = Me.dgdData.Item("TTLFull_A", index).Value
            ws.Range("D17").Value = Me.dgdData.Item("TTLEmpty_A", index).Value
            ws.Range("D18").Value = Me.dgdData.Item("TTLGross_A", index).Value
            ws.Range("D19").Value = Me.dgdData.Item("TugsIn", index).Value
            ws.Range("B20").Value = Me.dgdData.Item("Remark_A", index).Value

            ws.Range("J8").Value = Me.dgdData.Item("PilotOnboard_D", index).Value
            ws.Range("J9").Value = Me.dgdData.Item("LastLine", index).Value
            ws.Range("J10").Value = Me.dgdData.Item("Finished", index).Value
            ws.Range("J11").Value = Me.dgdData.Item("FO_D", index).Value
            ws.Range("J12").Value = Me.dgdData.Item("DO_D", index).Value
            ws.Range("J13").Value = Me.dgdData.Item("FreshWater_D", index).Value
            ws.Range("J14").Value = Me.dgdData.Item("DraftFwd_D", index).Value
            ws.Range("J15").Value = Me.dgdData.Item("DraftAft_D", index).Value
            ws.Range("J16").Value = Me.dgdData.Item("TTLFull_D", index).Value
            ws.Range("J17").Value = Me.dgdData.Item("TTLEmpty_D", index).Value
            ws.Range("J18").Value = Me.dgdData.Item("TTLGross_D", index).Value
            ws.Range("J19").Value = Me.dgdData.Item("TugsOut", index).Value
            ws.Range("H20").Value = Me.dgdData.Item("Remark_D", index).Value

            ws.Range("D21").Value = Me.dgdData.Item("PortTime", index).Value
            ws.Range("D22").Value = Me.dgdData.Item("BerthedTime", index).Value
            ws.Range("D23").Value = Me.dgdData.Item("OperationTime", index).Value
            ws.Range("D24").Value = Me.dgdData.Item("CashToCaption", index).Value
            ws.Range("J21").Value = Me.dgdData.Item("NextPortCall", index).Value
            ws.Range("J22").Value = Me.dgdData.Item("ETANextPort", index).Value
            ws.Range("J23").Value = Me.dgdData.Item("HatchCover", index).Value
            ws.Range("J24").Value = Me.dgdData.Item("GM", index).Value
            '-----------------------
            'Loading Summary Operator
            QueryLoadingSummary()
            Dim nRow As Integer = 28
            Dim _nRow As Integer = 28
            Dim i As Integer = 0
            f = 0
            For i = 0 To tblLoadingSummary.Tables(0).Rows.Count - 1
                ws.Range("A" & nRow, "B" & nRow).Cells.Merge()
                ws.Range("A" & nRow).Value = Me.dgdLoadingSummary.Item("_Operator", i).Value
                ws.Range("C" & nRow).Value = Me.dgdLoadingSummary.Item("FullEmpty", i).Value
                ws.Range("D" & nRow).Value = Me.dgdLoadingSummary.Item("SL20GP", i).Value
                ws.Range("E" & nRow).Value = Me.dgdLoadingSummary.Item("SL40GP", i).Value
                ws.Range("F" & nRow).Value = Me.dgdLoadingSummary.Item("SL40HC", i).Value
                ws.Range("G" & nRow).Value = Me.dgdLoadingSummary.Item("SL20RF", i).Value
                ws.Range("H" & nRow).Value = Me.dgdLoadingSummary.Item("SL40RH", i).Value
                ws.Range("I" & nRow).Value = Me.dgdLoadingSummary.Item("SL45", i).Value
                ws.Range("K" & nRow).Value = Me.dgdLoadingSummary.Item("Weight", i).Value
                ws.Range("J" & nRow).Value = "=D" & nRow & "+G" & nRow & "+2*(E" & nRow & "+F" & nRow & "+H" & nRow & ")+2.25*I" & nRow
                nRow += 1
                ws.Range("A" & nRow).Cells.Insert(3)
                f = 1
            Next
            If f = 1 Then
                ws.Range("A" & nRow).Cells.Delete(3)

                ws.Range("D" & nRow).Value = "=Sum(D28:" & "D" & nRow - 1 & ")"
                ws.Range("E" & nRow).Value = "=Sum(E28:" & "E" & nRow - 1 & ")"
                ws.Range("F" & nRow).Value = "=Sum(F28:" & "F" & nRow - 1 & ")"
                ws.Range("G" & nRow).Value = "=Sum(G28:" & "G" & nRow - 1 & ")"
                ws.Range("H" & nRow).Value = "=Sum(H28:" & "H" & nRow - 1 & ")"
                ws.Range("I" & nRow).Value = "=Sum(I28:" & "I" & nRow - 1 & ")"
                ws.Range("J" & nRow).Value = "=Sum(J28:" & "J" & nRow - 1 & ")"
                ws.Range("K" & nRow).Value = "=Sum(K28:" & "K" & nRow - 1 & ")"
            End If

            '------------------------------
            'Message Of CSC  Containers Pended
            QueryContainerPeneded()
            _nRow = nRow + 7
            nRow = _nRow
            f = 0
            For i = 0 To tblContainerPended.Tables(0).Rows.Count - 1
                ws.Range("B" & nRow).Value = Me.dgdContainerPended.Item("PortCodeLocal", index).Value
                ws.Range("C" & nRow).Value = Me.dgdContainerPended.Item("Local20GP", index).Value
                ws.Range("D" & nRow).Value = Me.dgdContainerPended.Item("Local40GP", index).Value
                ws.Range("F" & nRow).Value = Me.dgdContainerPended.Item("TransferPortCodePOR", index).Value
                ws.Range("G" & nRow).Value = Me.dgdContainerPended.Item("TransferPortCodePOD", index).Value
                ws.Range("H" & nRow).Value = Me.dgdContainerPended.Item("Transfer20GP", index).Value
                ws.Range("I" & nRow).Value = Me.dgdContainerPended.Item("Transfer40GP", index).Value
                ws.Range("E" & nRow).Value = "=C" & nRow & "+2*D" & nRow
                ws.Range("J" & nRow).Value = "=H" & nRow & "+2*I" & nRow
                nRow += 1
                ws.Range("A" & nRow).Cells.Insert(3)
                f = 1
            Next
            If f = 1 Then
                ws.Range("A" & nRow).Cells.Delete(3)
                ws.Range("E" & nRow).Value = "=Sum(E" & _nRow & ":E" & nRow - 1 & ")"
                ws.Range("J" & nRow).Value = "=Sum(E" & _nRow & ":E" & nRow - 1 & ") + Sum(J" & _nRow & ":J" & nRow - 1 & ") "
            End If


            '-------------------------------------
            ' qua Sheet moi
            ws = sheets.Item("csc-2")

            'Discharging Details
            QueryDisChargeDetail()
            _nRow = 8
            nRow = _nRow
            f = 0
            For i = 0 To tblDischargeDetail.Tables(0).Rows.Count - 1
                ws.Range("A" & nRow, "B" & nRow).Cells.Merge()
                ws.Range("A" & nRow).Value = Me.dgdDischargeDetail.Item("PortCodeDis", i).Value
                ws.Range("C" & nRow).Value = Me.dgdDischargeDetail.Item("Full20GP", i).Value
                ws.Range("D" & nRow).Value = Me.dgdDischargeDetail.Item("Full40GP", i).Value
                ws.Range("E" & nRow).Value = Me.dgdDischargeDetail.Item("Full40HC", i).Value
                ws.Range("F" & nRow).Value = Me.dgdDischargeDetail.Item("Full20RF", i).Value
                ws.Range("G" & nRow).Value = Me.dgdDischargeDetail.Item("Full40RH", i).Value
                ws.Range("H" & nRow).Value = Me.dgdDischargeDetail.Item("Full45", i).Value
                ws.Range("J" & nRow).Value = Me.dgdDischargeDetail.Item("Empty20", i).Value
                ws.Range("K" & nRow).Value = Me.dgdDischargeDetail.Item("Empty40", i).Value
                ws.Range("L" & nRow).Value = Me.dgdDischargeDetail.Item("Empty45", i).Value
                ws.Range("I" & nRow).Value = "=C" & nRow & "+F" & nRow & "+2*(D" & nRow & "+E" & nRow & "+G" & nRow & ")+2.25*H" & nRow
                ws.Range("M" & nRow).Value = "=J" & nRow & "+2*K" & nRow & "+2.25*L" & nRow
                nRow += 1
                ws.Range("A" & nRow).Cells.Insert(3)
                f = 1
            Next
            If f = 1 Then
                ws.Range("A" & nRow).Cells.Delete(3)
                ws.Range("C" & nRow).Value = "=Sum(C" & _nRow & ":C" & nRow - 1 & ")"
                ws.Range("D" & nRow).Value = "=Sum(D" & _nRow & ":D" & nRow - 1 & ")"
                ws.Range("E" & nRow).Value = "=Sum(E" & _nRow & ":E" & nRow - 1 & ")"
                ws.Range("F" & nRow).Value = "=Sum(F" & _nRow & ":F" & nRow - 1 & ")"
                ws.Range("G" & nRow).Value = "=Sum(G" & _nRow & ":G" & nRow - 1 & ")"
                ws.Range("H" & nRow).Value = "=Sum(H" & _nRow & ":H" & nRow - 1 & ")"
                ws.Range("I" & nRow).Value = "=C" & nRow & "+F" & nRow & "+2*(D" & nRow & "+E" & nRow & "+G" & nRow & ")+2.25*H" & nRow
                ws.Range("J" & nRow).Value = "=Sum(J" & _nRow & ":J" & nRow - 1 & ")"
                ws.Range("K" & nRow).Value = "=Sum(K" & _nRow & ":K" & nRow - 1 & ")"
                ws.Range("L" & nRow).Value = "=Sum(L" & _nRow & ":L" & nRow - 1 & ")"
                ws.Range("M" & nRow).Value = "=Sum(M" & _nRow & ":M" & nRow - 1 & ")"
            End If


            '-------------------------------
            'Loading Details
            QueryLoadingDetail()
            _nRow = nRow + 7
            nRow = _nRow
            f = 0
            For i = 0 To tblLoadingDetail.Tables(0).Rows.Count - 1 Step +2
                ws.Range("A" & nRow).Value = Me.dgdLoadingDetail.Item("LocalTrans", i).Value
                'ws.Range("B" & nRow).Value = Me.dgdLoadingDetail.Item("PortCodePOD", i).Value
                ws.Range("C" & nRow).Value = Me.dgdLoadingDetail.Item("Full20GPLD", i).Value
                ws.Range("D" & nRow).Value = Me.dgdLoadingDetail.Item("Full40GPLD", i).Value
                ws.Range("E" & nRow).Value = Me.dgdLoadingDetail.Item("Full40HCLD", i).Value
                ws.Range("F" & nRow).Value = Me.dgdLoadingDetail.Item("Full20RFLD", i).Value
                ws.Range("G" & nRow).Value = Me.dgdLoadingDetail.Item("Full40RHLD", i).Value
                ws.Range("H" & nRow).Value = Me.dgdLoadingDetail.Item("Full45LD", i).Value
                ws.Range("J" & nRow).Value = Me.dgdLoadingDetail.Item("Empty20LD", i).Value
                ws.Range("K" & nRow).Value = Me.dgdLoadingDetail.Item("Empty40LD", i).Value
                ws.Range("L" & nRow).Value = Me.dgdLoadingDetail.Item("Empty45LD", i).Value
                'ws.Range("N" & nRow).Value = Me.dgdLoadingDetail.Item("WeightLD", i).Value
                'ws.Range("O" & nRow).Value = Me.dgdLoadingDetail.Item("Slot20", i).Value
                'ws.Range("P" & nRow).Value = Me.dgdLoadingDetail.Item("Slot40", i).Value
                ws.Range("I" & nRow).Value = "=C" & nRow & "+F" & nRow & "+2*(D" & nRow & "+E" & nRow & "+G" & nRow & ")+2.25*H" & nRow
                ws.Range("M" & nRow).Value = "=J" & nRow & "+2*K" & nRow & "+2.25*L" & nRow
                nRow += 1
                ws.Range("A" & nRow).Cells.Insert(3)

                ws.Range("A" & nRow).Value = Me.dgdLoadingDetail.Item("LocalTrans", i + 1).Value
                ws.Range("B" & nRow - 1, "B" & nRow).Cells.Merge()
                ws.Range("B" & nRow - 1).Value = Me.dgdLoadingDetail.Item("PortCodePOD", i).Value
                ws.Range("C" & nRow).Value = Me.dgdLoadingDetail.Item("Full20GPLD", i + 1).Value
                ws.Range("D" & nRow).Value = Me.dgdLoadingDetail.Item("Full40GPLD", i + 1).Value
                ws.Range("E" & nRow).Value = Me.dgdLoadingDetail.Item("Full40HCLD", i + 1).Value
                ws.Range("F" & nRow).Value = Me.dgdLoadingDetail.Item("Full20RFLD", i + 1).Value
                ws.Range("G" & nRow).Value = Me.dgdLoadingDetail.Item("Full40RHLD", i + 1).Value
                ws.Range("H" & nRow).Value = Me.dgdLoadingDetail.Item("Full45LD", i + 1).Value
                ws.Range("J" & nRow).Value = Me.dgdLoadingDetail.Item("Empty20LD", i + 1).Value
                ws.Range("K" & nRow).Value = Me.dgdLoadingDetail.Item("Empty40LD", i + 1).Value
                ws.Range("L" & nRow).Value = Me.dgdLoadingDetail.Item("Empty45LD", i + 1).Value

                ws.Range("N" & nRow - 1, "N" & nRow).Cells.Merge()
                ws.Range("N" & nRow - 1).Value = Me.dgdLoadingDetail.Item("WeightLD", i).Value

                ws.Range("O" & nRow - 1, "O" & nRow).Cells.Merge()
                ws.Range("O" & nRow - 1).Value = Me.dgdLoadingDetail.Item("Slot20", i).Value

                ws.Range("P" & nRow - 1, "P" & nRow).Cells.Merge()
                ws.Range("P" & nRow - 1).Value = Me.dgdLoadingDetail.Item("Slot40", i).Value

                ws.Range("I" & nRow).Value = "=C" & nRow & "+F" & nRow & "+2*(D" & nRow & "+E" & nRow & "+G" & nRow & ")+2.25*H" & nRow
                ws.Range("M" & nRow).Value = "=J" & nRow & "+2*K" & nRow & "+2.25*L" & nRow
                ws.Range("A" & nRow - 1, "P" & nRow).Cells.BorderAround(, XlBorderWeight.xlMedium)
                ws.Range("A" & nRow - 1, "A" & nRow).Cells.BorderAround(, XlBorderWeight.xlThin)
                ws.Range("A" & nRow - 1, "A" & nRow).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1

                ws.Range("C" & nRow - 1, "I" & nRow).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                ws.Range("C" & nRow - 1, "I" & nRow).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1

                ws.Range("J" & nRow - 1, "M" & nRow).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                ws.Range("J" & nRow - 1, "M" & nRow).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1

                nRow += 1
                ws.Range("A" & nRow).Cells.Insert(3)
                f = 1
            Next
            If f = 1 Then
                ws.Range("A" & nRow).Cells.Delete(3)
                ws.Range("C" & nRow).Value = "=Sum(C" & _nRow & ":C" & nRow - 1 & ")"
                ws.Range("D" & nRow).Value = "=Sum(D" & _nRow & ":D" & nRow - 1 & ")"
                ws.Range("E" & nRow).Value = "=Sum(E" & _nRow & ":E" & nRow - 1 & ")"
                ws.Range("F" & nRow).Value = "=Sum(F" & _nRow & ":F" & nRow - 1 & ")"
                ws.Range("G" & nRow).Value = "=Sum(G" & _nRow & ":G" & nRow - 1 & ")"
                ws.Range("H" & nRow).Value = "=Sum(H" & _nRow & ":H" & nRow - 1 & ")"
                ws.Range("I" & nRow).Value = "=Sum(I" & _nRow & ":I" & nRow - 1 & ")"
                ws.Range("J" & nRow).Value = "=Sum(J" & _nRow & ":J" & nRow - 1 & ")"
                ws.Range("K" & nRow).Value = "=Sum(K" & _nRow & ":K" & nRow - 1 & ")"
                ws.Range("L" & nRow).Value = "=Sum(L" & _nRow & ":L" & nRow - 1 & ")"
                ws.Range("M" & nRow).Value = "=Sum(M" & _nRow & ":M" & nRow - 1 & ")"
                ws.Range("N" & nRow).Value = "=Sum(N" & _nRow & ":N" & nRow - 1 & ")"
                ws.Range("O" & nRow).Value = "=Sum(O" & _nRow & ":O" & nRow - 1 & ")"
                ws.Range("P" & nRow).Value = "=Sum(P" & _nRow & ":P" & nRow - 1 & ")"
            End If

            '-----------------------------
            'Danger - Special Cargo Summary
            QueryCargoSummary()
            _nRow = nRow + 5
            nRow = _nRow
            f = 0
            For i = 0 To tblCargoSummary.Tables(0).Rows.Count - 1
                If Me.dgdCargo.Item("Type", i).Value = "Danger" Then
                    ws.Range("A" & nRow, "B" & nRow).Cells.Merge()
                    ws.Range("A" & nRow).Value = Me.dgdCargo.Item("OperatorCG", i).Value
                    ws.Range("C" & nRow).Value = Me.dgdCargo.Item("SL20", i).Value
                    ws.Range("D" & nRow).Value = Me.dgdCargo.Item("SL40", i).Value
                    nRow += 1
                    ws.Range("A" & nRow).Cells.Insert(3)
                    f = 1
                End If
            Next
            If f = 1 Then
                ws.Range("A" & nRow).Cells.Delete(3)
                ws.Range("C" & nRow).Value = "=Sum(C" & _nRow & ":C" & nRow - 1 & ")"
                ws.Range("D" & nRow).Value = "=Sum(D" & _nRow & ":D" & nRow - 1 & ")"
            End If

            _nRow = IIf(f = 0, nRow + 5, nRow + 4)
            nRow = _nRow
            f = 0
            For i = 0 To tblCargoSummary.Tables(0).Rows.Count - 1
                If Me.dgdCargo.Item("Type", i).Value <> "Danger" Then
                    ws.Range("A" & nRow, "B" & nRow).Cells.Merge()
                    ws.Range("A" & nRow).Value = Me.dgdCargo.Item("OperatorCG", i).Value
                    ws.Range("C" & nRow).Value = Me.dgdCargo.Item("SL20", i).Value
                    ws.Range("D" & nRow).Value = Me.dgdCargo.Item("SL40", i).Value
                    nRow += 1
                    ws.Range("A" & nRow).Cells.Insert(3)
                    f = 1
                End If
            Next
            If f = 1 Then
                ws.Range("A" & nRow).Cells.Delete(3)
                ws.Range("C" & nRow).Value = "=Sum(C" & _nRow & ":C" & nRow - 1 & ")"
                ws.Range("D" & nRow).Value = "=Sum(D" & _nRow & ":D" & nRow - 1 & ")"
            End If

            '--------------------------
            ' qua Sheet moi
            ws = sheets.Item("SMR(CSC)")
            'CVT Loading
            QueryCVTLoading()
            _nRow = 4
            nRow = _nRow
            f = 0
            For i = 0 To tblCVTLoading.Tables(0).Rows.Count - 1
                ws.Range("E" & nRow).Value = Me.dgdCVT.Item("PortCodeCVT", i).Value
                ws.Range("F" & nRow).Value = Me.dgdCVT.Item("DEST", i).Value
                ws.Range("G" & nRow).Value = Me.dgdCVT.Item("TUE", i).Value
                ws.Range("H" & nRow).Value = Me.dgdCVT.Item("WeightCVT", i).Value
                ws.Range("I" & nRow).Value = Me.dgdCVT.Item("SL20GPCVT", i).Value
                ws.Range("J" & nRow).Value = Me.dgdCVT.Item("SL40GPCVT", i).Value
                ws.Range("K" & nRow).Value = Me.dgdCVT.Item("SL40HQCVT", i).Value
                ws.Range("L" & nRow).Value = Me.dgdCVT.Item("SL20RFCVT", i).Value
                ws.Range("M" & nRow).Value = Me.dgdCVT.Item("SL40RHCVT", i).Value
                ws.Range("N" & nRow).Value = Me.dgdCVT.Item("SL20ECVT", i).Value
                ws.Range("O" & nRow).Value = Me.dgdCVT.Item("SL40ECVT", i).Value

                nRow += 1
                ws.Range("A" & nRow).Cells.Insert(3)
                f = 1
            Next
            If f = 1 Then ws.Range("A" & nRow).Cells.Delete(3)
            If tblCVTLoading.Tables(0).Rows.Count > 1 Then
                ws.Range("A" & _nRow, "O" & nRow - 1).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            End If
            If f = 1 Then
                ws.Range("A" & _nRow, "O" & nRow - 1).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                ws.Range("A" & nRow, "O" & nRow).Cells.BorderAround(, XlBorderWeight.xlMedium)
                ws.Range("G" & nRow).Value = "=Sum(G" & _nRow & ":G" & nRow - 1 & ")"
                ws.Range("H" & nRow).Value = "=Sum(H" & _nRow & ":H" & nRow - 1 & ")"
                ws.Range("I" & nRow).Value = "=Sum(I" & _nRow & ":I" & nRow - 1 & ")"
                ws.Range("J" & nRow).Value = "=Sum(J" & _nRow & ":J" & nRow - 1 & ")"
                ws.Range("K" & nRow).Value = "=Sum(K" & _nRow & ":K" & nRow - 1 & ")"
                ws.Range("L" & nRow).Value = "=Sum(L" & _nRow & ":L" & nRow - 1 & ")"
                ws.Range("M" & nRow).Value = "=Sum(M" & _nRow & ":M" & nRow - 1 & ")"
                ws.Range("N" & nRow).Value = "=Sum(N" & _nRow & ":N" & nRow - 1 & ")"
                ws.Range("O" & nRow).Value = "=Sum(O" & _nRow & ":O" & nRow - 1 & ")"
            End If



            '================= Complete ====================
            Dim d As Date = CDate(Getdate())
            path = "c:\" & "TDR & LOADING SUMMARY" & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
            path = ProccessString(path)
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            Me.Cursor = Cursors.Default

            MsgBox("Complete")
            app.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDeclartion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeclartion.Click
        Try
            If mStatus = "Add" Then
                MsgBox("Chỉ thực hiện khi Edit")
                Return
            End If
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer
            If (Me.dgdData.RowCount > 0) Then
                index = Me.dgdData.CurrentRow.Index
            End If

            If mStatus = "Edit" Then
                Me.grpDeclaration.Visible = True
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM TerminalDeparture "
                strQuery = strQuery & "WHERE TerminalDeparture_ID = '" & mTerminalDeparture_ID & "' AND TerminalDeparture_ID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    Me.txtPortofArrival.Text = .Fields("PortOfArrival").Value
                    Me.txtPortArrivedfrom.Text = .Fields("PortArrivedFrom").Value
                    Me.txtDateArrival.Text = .Fields("DateArrival").Value
                    Me.txtMasterName.Text = .Fields("masterName").Value
                    Me.txtBrief.Text = .Fields("BreifParticular").Value
                    Me.txtQuantityCargo.Text = .Fields("QuantityCargo").Value
                    Me.txtQuantityDanger.Text = .Fields("QuantityDanger").Value
                    Me.txtPosPort.Text = .Fields("PosPort").Value
                    Me.txtOtherConcer.Text = .Fields("OtherConcer").Value
                    Me.txtRemarks.Text = .Fields("Remarks").Value
                End With
                rs.Close()
                Me.fraUpdate.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkEstimated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEstimated.CheckedChanged
        Try
            Me.dtpEstimated.Enabled = Me.chkEstimated.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkLastTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLastTime.CheckedChanged
        Try
            Me.dtpLastTime.Enabled = Me.chkLastTime.Checked
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdOKForeign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKForeign.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer
            If (Me.oTable.Tables(0).Rows.Count > 0) Then
                index = Me.dgdData.CurrentRow.Index
            End If

            If mStatus = "Edit" Then
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM TerminalDeparture "
                strQuery = strQuery & "WHERE TerminalDeparture_ID = '" & mTerminalDeparture_ID & "' AND TerminalDeparture_ID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    .Fields("Port").Value = Me.txtPort.Text.Trim
                    .Fields("Fore").Value = Me.txtFore.Text.Trim
                    .Fields("After").Value = Me.txtAfter.Text.Trim
                    .Fields("KindOfCargo").Value = Me.txtKindOfcargo.Text.Trim
                    .Fields("Quantity").Value = Me.txtQuantity.Text.Trim
                    .Fields("NumCrew").Value = Me.txtNumCrew.Text.Trim
                    .Fields("NumPassenger").Value = Me.txtNumPassenger.Text.Trim
                    .Fields("LastPortCall").Value = Me.txtLastPortCall.Text.Trim
                    .Fields("ActualDisplace").Value = Me.txtActualDisplace.Text.Trim
                    .Fields("PurposePort").Value = Me.txtPurpose.Text.Trim
                    .Fields("Gui").Value = Me.txtGui.Text.Trim
                    .Fields("_To").Value = Me.txtTo.Text.Trim
                    If Me.chkEstimated.Checked = False Then
                        .Fields("EstimatedTime").Value = Nothing
                    Else
                        .Fields("EstimatedTime").Value = Me.dtpEstimated.Value.Date
                    End If
                    If Me.chkLastTime.Checked = False Then
                        .Fields("LastTimeArrival").Value = Nothing
                    Else
                        .Fields("LastTimeArrival").Value = Me.dtpLastTime.Value.Date
                    End If
                    .Update()
                End With
                rs.Close()
                Me.fraUpdate.Enabled = True
                Me.grpForeignVeseel.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelForeign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelForeign.Click
        Try
            Me.fraUpdate.Enabled = True
            Me.grpForeignVeseel.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdForeignVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForeignVessel.Click
        Try
            If mStatus = "Add" Then
                MsgBox("Chỉ thực hiện khi Edit")
                Return
            End If
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer
            If (Me.dgdData.RowCount > 0) Then
                index = Me.dgdData.CurrentRow.Index
            End If

            If mStatus = "Edit" Then
                Me.grpForeignVeseel.Visible = True
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM TerminalDeparture "
                strQuery = strQuery & "WHERE TerminalDeparture_ID = '" & mTerminalDeparture_ID & "' AND TerminalDeparture_ID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    Me.txtFore.Text = .Fields("Fore").Value
                    Me.txtAfter.Text = .Fields("After").Value
                    Me.txtKindOfcargo.Text = .Fields("KindOfCargo").Value
                    Me.txtQuantity.Text = .Fields("Quantity").Value
                    Me.txtNumCrew.Text = .Fields("NumCrew").Value
                    Me.txtNumPassenger.Text = .Fields("NumPassenger").Value
                    Me.txtLastPortCall.Text = .Fields("LastPortCall").Value
                    Me.txtActualDisplace.Text = .Fields("ActualDisplace").Value
                    Me.txtPurpose.Text = .Fields("PurposePort").Value
                    Me.txtTo.Text = .Fields("_To").Value
                    Me.txtGui.Text = .Fields("Gui").Value
                    Me.txtPort.Text = .Fields("Port").Value
                    If IsDBNull(.Fields("EstimatedTime").Value) = True Then
                        Me.chkEstimated.Checked = False
                    Else
                        Me.chkEstimated.Checked = True
                        Me.dtpEstimated.Value = .Fields("EstimatedTime").Value
                    End If
                    If IsDBNull(.Fields("LastTimeArrival").Value) = True Then
                        Me.chkLastTime.Checked = False
                    Else
                        Me.chkLastTime.Checked = True
                        Me.dtpLastTime.Value = .Fields("LastTimeArrival").Value
                    End If
                    Me.chkEstimated_CheckedChanged(sender, e)
                    Me.chkLastTime_CheckedChanged(sender, e)
                End With
                rs.Close()
                Me.fraUpdate.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuForeignVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuForeignVessel.Click
        Try
            Dim frm As New frmReportForeignVessel
            If Me.dgdData.Rows.Count = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdData.CurrentRow.Index
            mTerminalDeparture_ID = Me.dgdData.Item("TerminalDeparture_ID", index).Value.ToString
            frm.mForeignID = mTerminalDeparture_ID
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDeclaration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeclaration.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer
            If (Me.oTable.Tables(0).Rows.Count > 0) Then
                index = Me.dgdData.CurrentRow.Index
            End If

            If mStatus = "Edit" Then
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM TerminalDeparture "
                strQuery = strQuery & "WHERE TerminalDeparture_ID = '" & mTerminalDeparture_ID & "' AND TerminalDeparture_ID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    .Fields("PortOfArrival").Value = Me.txtPortofArrival.Text.Trim
                    .Fields("PortArrivedFrom").Value = Me.txtPortArrivedfrom.Text.Trim
                    .Fields("DateArrival").Value = Me.txtDateArrival.Text.Trim
                    .Fields("masterName").Value = Me.txtMasterName.Text.Trim
                    .Fields("BreifParticular").Value = Me.txtBrief.Text.Trim
                    .Fields("QuantityCargo").Value = Me.txtQuantityCargo.Text.Trim
                    .Fields("QuantityDanger").Value = Me.txtQuantityDanger.Text.Trim
                    .Fields("PosPort").Value = Me.txtPosPort.Text.Trim
                    .Fields("OtherConcer").Value = Me.txtOtherConcer.Text.Trim
                    .Fields("Remarks").Value = Me.txtRemarks.Text.Trim
                    .Update()
                End With
                rs.Close()
                Me.fraUpdate.Enabled = True
                Me.grpDeclaration.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelDeclaration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelDeclaration.Click
        Me.fraUpdate.Enabled = True
        Me.grpDeclaration.Visible = False
    End Sub

    Private Sub SmnuReportDeclarationArrival_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmnuReportDeclarationArrival.Click
        Try
            Dim frm As New frmReportDeclarationArrival
            If Me.dgdData.SelectedRows.Count = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdData.CurrentRow.Index
            mTerminalDeparture_ID = Me.dgdData.Item("TerminalDeparture_ID", index).Value.ToString
            frm.mTerminalID = mTerminalDeparture_ID
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class