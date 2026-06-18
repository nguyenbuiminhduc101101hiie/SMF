Option Strict Off
Option Explicit On
Module uniqueidentifier
	
	Public Function NewId() As String
		On Error GoTo Err_Renamed
		Dim rs As New ADODB.Recordset
        rs.Open("Select NewId() as NewIdValue ", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		NewId = rs.Fields("NewIdValue").Value
		rs.Close()
		Exit Function
Err_Renamed: 
        MsgBox(Err.Description)
    End Function
    Public Function Getdate() As String
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset


        rs.Open("Select Getdate() as GetdateValue ", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Getdate = rs.Fields("GetdateValue").Value
        rs.Close()
        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
    End Function

    Public Function GetServerName() As String
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        rs.Open("Select @@servername as SeverName ", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        GetServerName = rs.Fields("SeverName").Value
        rs.Close()
        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
    End Function

End Module