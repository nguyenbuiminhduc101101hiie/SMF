Option Strict Off
Option Explicit On
Friend Class Profile
	
	Public rsProfile As New ADODB.Recordset
	
	Const strProfileSelect As String = "Select " & "ProfileId , " & "ControlId, " & "Caption, " & "FontName, " & "FontSize, " & "Alignment, " & "Visible " & "FROM Profile "
	
	Public Sub Profile(ByVal argProfileId As String, ByVal argFormId As String, ByVal argOption As String)
		'-- argOption = Put/Get --
		On Error GoTo Err_Renamed
		Dim i, j As Short
		Dim strQuery As String
		Dim Frm As System.Windows.Forms.Form
		'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If IsNothing(argOption) Or argOption = "" Then
			argOption = "Get"
		End If
		strQuery = strProfileSelect & " WHERE ProfileId = '" & argProfileId & "' and Left(ControlId," & Len(argFormId) & ")  ='" & argFormId & "'"
        rsProfile.Open(strQuery, CSCLEnv.CSCLConn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		For	Each Frm In My.Application.OpenForms
			If Frm.Name = argFormId Then
				Profile2(argProfileId, argOption, Frm, "")
				Exit For
			End If
		Next Frm
		rsProfile.MoveFirst()
		rsProfile.Close()
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "Profile:Profile")
	End Sub
	
	Private Sub Profile2(ByVal argProfileId As String, ByVal argOption As String, ByVal ctl As Object, ByVal ParentName As Object)
		On Error GoTo Err_Renamed
		Dim ctl2 As System.Windows.Forms.Control
		Dim strFind, strCtlType As String
		Dim i, j As Short
		
		'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strCtlType = Left(ctl.name, 3)
		'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strFind = "ControlId = '" & ParentName & ctl.name & "'"
		
		With rsProfile
			If .RecordCount > 0 Then
				.MoveFirst()
				.Find(strFind)
			End If
			If argOption = "Put" Then
				If .EOF Then
					If InStr("frm,fra,cmd,txt,dbc,mnu,smnu,opt,dgd,flex", strCtlType) Then
						.AddNew()
						.Fields("ProfileId").Value = argProfileId
						'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("ControlId").Value = ParentName & ctl.name
					End If
				End If
				If InStr("frm,fra,cmd,mnu,smnu,opt,dgd", strCtlType) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Caption. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Caption").Value = ctl.Caption
				End If
				If InStr("frm,fra,cmd,txt,dbc,opt,dgd,flex", strCtlType) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Font. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("FontName").Value = ctl.Font.name
				End If
				If InStr("frm,fra,cmd,txt,dbc,opt,dgd,flex", strCtlType) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Font. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("FontSize").Value = ctl.Font.Size
				End If
				If InStr("txt", strCtlType) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Alignment. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Alignment").Value = ctl.Alignment
				End If
				If InStr("frm,fra,cmd,txt,dbc,mnu,smn,opt,dgd,flex", strCtlType) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object ctl.visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Visible").Value = ctl.visible
				End If
			Else
				If Not .EOF Then
					If InStr("frm,fra,cmd,mnu,smnu,opt,dgd", strCtlType) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Caption. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Caption = "" & .Fields("Caption").Value
					End If
					If InStr("frm,fra,cmd,txt,dbc,opt,dgd,flex", strCtlType) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Font. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Font.name = "" & .Fields("FontName").Value
					End If
					If InStr("frm,fra,cmd,txt,dbc,opt,dgd,flex", strCtlType) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Font. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Font.Size = "" & .Fields("FontSize").Value
					End If
					If InStr("txt", strCtlType) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Alignment. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.Alignment = "" & .Fields("Alignment").Value
					End If
					If InStr("frm,fra,cmd,txt,dbc,opt,dgd,flex", strCtlType) Then
						'UPGRADE_WARNING: Couldn't resolve default property of object ctl.visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						ctl.visible = "" & .Fields("Visible").Value
					End If
				End If
			End If
		End With
		If InStr("frm,tab", strCtlType) > 0 Then
			For	Each ctl2 In ctl
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Profile2(argProfileId, argOption, ctl2, ParentName & ctl.name & ".")
			Next ctl2
		End If
		If strCtlType = "dgd" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Columns. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = 0 To ctl.Columns.Count - 1
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Columns. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Profile3(argProfileId, argOption, ctl.Columns.Item(i), ParentName & ctl.name & ".")
			Next 
		End If
		If strCtlType = "fle" Then
			'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Profile4(argProfileId, argOption, ctl, ParentName & ctl.name & ".")
		End If
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "Profile:Profile2")
	End Sub
	
	Private Sub Profile3(ByVal argProfileId As String, ByVal argOption As String, ByVal Item As Object, ByVal ParentName As Object)
		On Error GoTo Err_Renamed
		Dim strFind As String
		'UPGRADE_WARNING: Couldn't resolve default property of object Item.ColIndex. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strFind = "ControlId = '" & ParentName & "col" & Item.ColIndex & "'"
		With rsProfile
			If .RecordCount > 0 Then
				.MoveFirst()
				.Find(strFind)
			End If
			If argOption = "Put" Then
				If .EOF Then
					.AddNew()
					.Fields("ProfileId").Value = argProfileId
					'UPGRADE_WARNING: Couldn't resolve default property of object Item.ColIndex. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("ControlId").Value = ParentName & "col" & Item.ColIndex
				End If
				'UPGRADE_WARNING: Couldn't resolve default property of object Item.Caption. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Caption").Value = Item.Caption
				'UPGRADE_WARNING: Couldn't resolve default property of object Item.Alignment. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Alignment").Value = Item.Alignment
				'UPGRADE_WARNING: Couldn't resolve default property of object Item.visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Visible").Value = Item.visible
			Else
				If Not .EOF Then
					'UPGRADE_WARNING: Couldn't resolve default property of object Item.Caption. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Item.Caption = "" & .Fields("Caption").Value
					'UPGRADE_WARNING: Couldn't resolve default property of object Item.Alignment. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Item.Alignment = "" & .Fields("Alignment").Value
					'UPGRADE_WARNING: Couldn't resolve default property of object Item.visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Item.visible = "" & .Fields("Visible").Value
				End If
			End If
		End With
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "Profile:Profile3")
	End Sub
	
	Private Sub Profile4(ByVal argProfileId As String, ByVal argOption As String, ByRef argFlexGrid As Object, ByVal ParentName As Object)
		On Error GoTo Err_Renamed
		Dim strFind As String
		Dim i, j As Short
		'UPGRADE_WARNING: Couldn't resolve default property of object argFlexGrid.Bands. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For i = 0 To argFlexGrid.Bands - 1
			'UPGRADE_WARNING: Couldn't resolve default property of object argFlexGrid.Cols. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For j = 0 To argFlexGrid.Cols(i) - 1
				'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				strFind = "ControlId = '" & ParentName & "band" & i & ".col" & j & "'"
				With rsProfile
					If .RecordCount > 0 Then
						.MoveFirst()
						.Find(strFind)
					End If
					If argOption = "Put" Then
						If .EOF Then
							.AddNew()
							.Fields("ProfileId").Value = argProfileId
							'UPGRADE_WARNING: Couldn't resolve default property of object ParentName. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.Fields("ControlId").Value = ParentName & "band" & i & ".col" & j
						End If
						'UPGRADE_WARNING: Couldn't resolve default property of object argFlexGrid.ColHeaderCaption. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Caption").Value = argFlexGrid.ColHeaderCaption(i, j)
						'UPGRADE_WARNING: Couldn't resolve default property of object argFlexGrid.ColAlignmentBand. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Alignment").Value = argFlexGrid.ColAlignmentBand(i, j)
					Else
						If Not .EOF Then
							'UPGRADE_WARNING: Couldn't resolve default property of object argFlexGrid.ColHeaderCaption. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							argFlexGrid.ColHeaderCaption(i, j) = .Fields("Caption").Value
							'UPGRADE_WARNING: Couldn't resolve default property of object argFlexGrid.ColAlignmentBand. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							argFlexGrid.ColAlignmentBand(i, j) = .Fields("Alignment").Value
						End If
					End If
				End With
			Next j
		Next i
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "Profile:Profile4")
	End Sub
End Class