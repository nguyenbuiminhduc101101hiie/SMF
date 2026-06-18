Option Strict Off
Option Explicit On
Friend Class clsUserRightForm
	
	Const strUserRightFormSelect As String = "SELECT " & "FormId, " & "URAdd, " & "UREdit, " & "URDelete, " & "URView, " & "URApprove " & "FROM UserRightForm UR "
	
	Private Structure OptionTableType
		'UPGRADE_NOTE: FormId was upgraded to FormId_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim FormId_Renamed As String
		Dim URAdd As Boolean
		Dim UREdit As Boolean
		Dim URDelete As Boolean
		Dim URView As Boolean
		Dim URApprove As Boolean
	End Structure
	
	Private OptionTable() As OptionTableType
	Private OptionTableSize As Short
    Private mDepartment As String
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		On Error GoTo Err_Renamed
		'UPGRADE_WARNING: Couldn't resolve default property of object objUserSetting.GetCParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        mDepartment = objUserSetting.GetCParm("clsUserRightForm.mDepartment")
        QueryUserRightForm(mDepartment)
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "clsUserRightForm:Class_Initialize")
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		On Error GoTo Err_Renamed
		'UPGRADE_WARNING: Couldn't resolve default property of object objUserSetting.SetCParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objUserSetting.SetCParm("clsUserRightForm.mBalanceSheet", mDepartment)
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "clsUserRightForm:Class_Terminate")
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
    Public Sub QueryUserRightForm(Optional ByVal argDepartment As String = "")
        On Error GoTo Err_Renamed
        Dim i As Short
        Dim rs As New ADODB.Recordset
        'UPGRADE_NOTE: IsMissing() was changed to IsNothing(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
        If IsNothing(argDepartment) Then argDepartment = "."
        i = InStr(argDepartment, ".")
        If i > 1 Then
            argDepartment = Left(argDepartment, i - 1)
        End If
        Dim strQuery As String
        strQuery = strUserRightFormSelect
        strQuery = strQuery & "WHERE Discontinued = 0 "
        strQuery = strQuery & "AND Usr = User_Name() "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.RecordCount > 0 Then
            With rs
                OptionTableSize = .RecordCount
                ReDim OptionTable(OptionTableSize)
                .MoveFirst()
                i = 0
                While Not .EOF
                    OptionTable(i).FormId_Renamed = .Fields("FormId").Value
                    OptionTable(i).URAdd = .Fields("URAdd").Value
                    OptionTable(i).UREdit = .Fields("UREdit").Value
                    OptionTable(i).URDelete = .Fields("URDelete").Value
                    OptionTable(i).URView = .Fields("URView").Value
                    OptionTable(i).URApprove = .Fields("URApprove").Value
                    i = i + 1
                    .MoveNext()
                End While
            End With
        End If
        rs.Close()
        mDepartment = argDepartment
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "clsUserRightForm:QueryUserRightForm")
    End Sub
	
	Public Function UserRightForm(ByVal argFormId As String, ByVal argOperation As String) As Boolean
		On Error GoTo Err_Renamed
		Dim i As Short
		UserRightForm = False
		For i = 0 To OptionTableSize - 1
			If argFormId = OptionTable(i).FormId_Renamed Then
				Select Case UCase(argOperation)
					Case "ADD"
						UserRightForm = OptionTable(i).URAdd
					Case "EDIT"
						UserRightForm = OptionTable(i).UREdit
					Case "DELETE"
						UserRightForm = OptionTable(i).URDelete
					Case "VIEW"
						UserRightForm = OptionTable(i).URView
					Case "APPROVE"
						UserRightForm = OptionTable(i).URApprove
				End Select
				Exit For
			End If
		Next i
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description, "clsUserRightForm:UserRightForm")
	End Function
End Class