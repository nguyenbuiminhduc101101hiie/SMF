Option Strict Off
Option Explicit On
'UPGRADE_NOTE: Filter was upgraded to Filter_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module Filter_Renamed
	Private rsFilter As New ADODB.Recordset
	Private strQuery As String
	
	Public Function FilType(ByVal argTable As String, ByVal argField As String) As String
		On Error GoTo Err_Renamed
		strQuery = "SELECT Type FROM FilterList WHERE TableId = '" & argTable & "' and FieldId = '" & argField & "' "
        rsFilter.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		If rsFilter.EOF Then
			FilType = ""
		Else
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			FilType = IIf(IsDbNull(rsFilter.Fields("Type").Value), "", rsFilter.Fields("Type").Value)
		End If
		rsFilter.Close()
		Exit Function
Err_Renamed: 
        MsgBox(Err.Description)
	End Function
End Module