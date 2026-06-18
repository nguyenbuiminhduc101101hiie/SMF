Option Strict Off
Option Explicit On
Module UserRightForm
	Dim rsUserRightForm As New ADODB.Recordset
	
	Public Function URFFind(ByVal argUser As Object, ByVal argFormId As Object, Optional ByVal argIncludeDiscontinued As Boolean = False, Optional ByRef argUserRightFormId As String = "") As Boolean
		On Error GoTo Err_Renamed
		Dim strQuery As String
		'UPGRADE_WARNING: Couldn't resolve default property of object argFormId. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object argUser. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strQuery = "SELECT UserRightFormId FROM UserRightForm WHERE Usr = '" & argUser & "' and FormId = '" & argFormId & "' "
		'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If IsNothing(argIncludeDiscontinued) Then
			strQuery = strQuery & "and Discontinued = 0 "
		ElseIf Not argIncludeDiscontinued Then 
			strQuery = strQuery & "and Discontinued = 0 "
		End If
        rsUserRightForm.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		URFFind = Not rsUserRightForm.EOF
		'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(argUserRightFormId) And Not rsUserRightForm.EOF Then
            argUserRightFormId = rsUserRightForm.Fields("UserRightFormId").Value
        End If
		rsUserRightForm.Close()
		'Debug.Print strQuery
		Exit Function
Err_Renamed: 
        MsgBox(Err.Description)
	End Function
	
	Public Function URFDiscontinued(ByVal argUser As Object, ByVal argFormId As Object) As Boolean
		On Error GoTo Err_Renamed
		Dim strQuery As String
		'UPGRADE_WARNING: Couldn't resolve default property of object argFormId. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object argUser. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strQuery = "SELECT Discontinued FROM UserRightForm WHERE Usr = '" & argUser & "' and FormId = '" & argFormId & "' "
        rsUserRightForm.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rsUserRightForm.RecordCount = 0 Then
            URFDiscontinued = True
        Else
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            URFDiscontinued = IIf(IsDBNull(rsUserRightForm.Fields("Discontinued").Value), False, rsUserRightForm.Fields("Discontinued").Value)
        End If
        rsUserRightForm.Close()
        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
    End Function

    Public Function UserRight(ByVal argForm As String, ByVal argOperation As String) As Boolean
        On Error GoTo Err_Renamed
        Dim strQuery As String
        UserRight = True
        If rsUserRightForm.State = ADODB.ObjectStateEnum.adStateOpen Then rsUserRightForm.Close()
        strQuery = "SELECT " & "CASE '" & argOperation & "' " & "WHEN 'Add' THEN URAdd " & "WHEN 'Edit' THEN UREdit " & "WHEN 'Delete' THEN URDelete " & "WHEN 'View' THEN URView " & "WHEN 'Execute' THEN URExecute " & "WHEN 'Approve' THEN URApprove " & "ELSE 0 " & "END AS Rght " & "FROM UserRightForm " & "WHERE Usr = '" & strUserId & "' and FormId = '" & argForm & "' and Discontinued = 0"
        rsUserRightForm.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rsUserRightForm.EOF Then
            UserRight = False
        Else
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            UserRight = IIf(IsDBNull(rsUserRightForm.Fields("Rght").Value), False, rsUserRightForm.Fields("Rght").Value)
        End If
        rsUserRightForm.Close()
        'Debug.Print strQuery
        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
        'Resume
    End Function
End Module