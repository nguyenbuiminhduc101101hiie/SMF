Option Strict Off
Option Explicit On
Friend Class UserSetting
	
	Const constPrivate As String = "P"
	Const constMember As String = "M"
	Const constGlobal As String = "G"
	
	
	Public rsUserSetting As New ADODB.Recordset
	Public blnOpened As Boolean
	Private mMemberId, mUserId, mDataBaseId As String
	
	Const strUserSettingSelect As String = "Select " & "UserId , " & "ParmId, " & "Index1, " & "Index2, " & "NParm, " & "IParm, " & "CParm, " & "DParm " & "FROM UserSetting "
	
	
	Private Structure ParmTableType
		Dim ParmId As String
		Dim Index1 As Short
		Dim Index2 As Short
		Dim NParm As Double
		Dim IParm As Short
		Dim CParm As String
		Dim DParm As Date
		Dim Updated As Boolean
		Dim UserOpt As String
	End Structure
	
	Private ParmTable() As ParmTableType
	Private ParmTableSize, ParmTableSizeMax As Short
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		On Error GoTo Err_Renamed
		Dim i As Short
		Dim rs As New ADODB.Recordset
		'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(blnOpened) Then
			blnOpened = False
		End If
        rs.Open("SELECT db_Name() as DataBaseId,Current_User As Usr,Is_Member('CSCLAdmin') AS gIsCSCLAdmin, Is_Member('CSCLSuperUser') AS gIsCSCLSuperUser ", strconn, , , ADODB.CommandTypeEnum.adCmdText)
		mUserId = UCase(rs.Fields("Usr").Value)
		mDataBaseId = UCase(rs.Fields("DataBaseId").Value)
        gIsCSCLAdmin = UCase(mUserId) = "DBO"
        gIsCSCLSuperUser = False
        If gIsCSCLAdmin Then gIsCSCLSuperUser = True
		rs.Close()
        rs.Open("SELECT (db_name()) As DatabaseName", strconn, , , ADODB.CommandTypeEnum.adCmdText)
        mMemberId = UCase(rs.Fields("DatabaseName").Value)
        rs.Close()
        ParmTableSize = 0
        ParmTableSizeMax = 0
        ReDimParmTable()
        GetParmFromFile()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:Class_Initialize")
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()
        On Error GoTo Err_Renamed
        If Not gConnectionFailure Then SaveParm()
        SaveParmToFile()
        If blnOpened Then
            blnOpened = False
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:Class_Terminate")
        'Resume
        'Resume Next
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    Public Function GetNParm(ByVal argParmId As String, Optional ByVal argDefault As Double = 0, Optional ByVal argUserOpt As String = constPrivate, Optional ByRef argExactly As Boolean = False) As Object
        On Error GoTo Err_Renamed
        'UPGRADE_WARNING: Couldn't resolve default property of object GetParm(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetNParm = GetParm(argParmId, "NParm", 0, 0, argUserOpt, argExactly)
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(GetNParm) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object GetNParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            GetNParm = argDefault
            SetNParm(argParmId, CStr(argDefault), argUserOpt)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:")
    End Function

    Public Function GetIParm(ByVal argParmId As String, Optional ByVal argDefault As Short = 0, Optional ByVal argUserOpt As String = constPrivate, Optional ByRef argExactly As Boolean = False) As Object
        On Error GoTo Err_Renamed
        'UPGRADE_WARNING: Couldn't resolve default property of object GetParm(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetIParm = GetParm(argParmId, "IParm", 0, 0, argUserOpt, argExactly)
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(GetIParm) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object GetIParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            GetIParm = argDefault
            SetIParm(argParmId, CStr(argDefault), argUserOpt)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:GetIParm")
    End Function

    Public Function GetCParm(ByVal argParmId As String, Optional ByVal argDefault As String = "", Optional ByVal argUserOpt As String = constPrivate, Optional ByRef argExactly As Boolean = False) As Object
        On Error GoTo Err_Renamed
        'UPGRADE_WARNING: Couldn't resolve default property of object GetParm(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetCParm = GetParm(argParmId, "CParm", 0, 0, argUserOpt, argExactly)
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(GetCParm) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object GetCParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            GetCParm = argDefault
            SetCParm(argParmId, argDefault, argUserOpt)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:GetCParm")
    End Function

    Public Function GetDParm(ByVal argParmId As String, ByVal argDefault As Date, Optional ByVal argUserOpt As String = constPrivate, Optional ByRef argExactly As Boolean = False) As Object
        On Error GoTo Err_Renamed
        ' dem gia tri  xuong
        argDefault = "01/01/01"
        'UPGRADE_WARNING: Couldn't resolve default property of object GetParm(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetDParm = GetParm(argParmId, "DParm", 0, 0, argUserOpt, argExactly)
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'UPGRADE_WARNING: Couldn't resolve default property of object GetDParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If IsDBNull(GetDParm) Then GetDParm = CDate(argDefault)
        If Not IsDate(GetDParm) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object GetDParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            GetDParm = CDate(argDefault)
            SetDParm(argParmId, CStr(argDefault), argUserOpt)
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object GetDParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If DatePart(Microsoft.VisualBasic.DateInterval.Year, GetDParm) < 1900 Then GetDParm = CDate(argDefault)
        'GetDParm = CDate(argDefault)
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:GetDParm")
    End Function

    Public Function GetBParm(ByVal argParmId As String, Optional ByVal argDefault As Boolean = False, Optional ByVal argUserOpt As String = constPrivate, Optional ByRef argExactly As Boolean = False) As Object
        On Error GoTo Err_Renamed
        'UPGRADE_WARNING: Couldn't resolve default property of object GetParm(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object GetBParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetBParm = GetParm(argParmId, "IParm", 0, 0, argUserOpt, argExactly)
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(GetBParm) Then
            'UPGRADE_WARNING: Couldn't resolve default property of object GetBParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            GetBParm = argDefault
            SetBParm(argParmId, CStr(argDefault), argUserOpt)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:GetBParm")
    End Function

    Public Sub GetParmFromFile()
        On Error GoTo Err_Renamed
        Dim i As Short
        gTmpFile = "CSCLIOB_" & Trim(strServer.Replace("\", "")) & "_" & Trim(strDatabase) & "_" & strUserId & ".tmp"
        FileOpen(1, gTmpFile, OpenMode.Input)
        Do While Not EOF(1)
            If ParmTableSize = ParmTableSizeMax Then ReDimParmTable()
            i = ParmTableSize
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).ParmId)
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).Index1)
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).Index2)
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).CParm)
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).NParm)
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).IParm)
            Microsoft.VisualBasic.FileSystem.Input(1, ParmTable(i).DParm)
            ParmTableSize = ParmTableSize + 1
        Loop
        FileClose(1)
        Exit Sub
Err_Renamed:
        'DisplayMessage(True, Err.Description, "UserSetting:GetParmFromFile")
        'Resume
    End Sub

    Private Function GetParm(ByVal argParmId As String, ByVal argParmType As String, Optional ByVal argIndex1 As Short = 0, Optional ByVal argIndex2 As Short = 0, Optional ByVal argUserOpt As String = constPrivate, Optional ByRef argExactly As Boolean = False) As Object
        On Error GoTo Err_Renamed
        Dim i As Short
        Dim strParm As String
        Dim strUserId As String
        Select Case argUserOpt
            Case constPrivate : strUserId = mUserId
            Case constMember : strUserId = mMemberId
            Case constGlobal : strUserId = "Global"
        End Select
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        'UPGRADE_WARNING: Couldn't resolve default property of object GetParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        GetParm = System.DBNull.Value
        i = SearchParm(argParmId, argIndex1, argIndex2)
        If i < 0 Then
            GetUserSetting(argParmId, argIndex1, argIndex2, strUserId, argExactly)
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            If Not rsUserSetting.EOF Then 'And Not IsDBNull(rsUserSetting.Fields(argParmType).Value) Then
                strParm = rsUserSetting.Fields(argParmType).Value
                SetParm(argParmId, argIndex1, argIndex2, argParmType, strParm, rsUserSetting.Fields("UserId").Value <> strUserId, argUserOpt)
                'UPGRADE_WARNING: Couldn't resolve default property of object GetParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                GetParm = strParm
            End If
        Else
            Select Case argParmType
                Case "CParm"
                    'UPGRADE_WARNING: Couldn't resolve default property of object GetParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    GetParm = ParmTable(i).CParm
                Case "NParm"
                    'UPGRADE_WARNING: Couldn't resolve default property of object GetParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    GetParm = ParmTable(i).NParm
                Case "IParm"
                    'UPGRADE_WARNING: Couldn't resolve default property of object GetParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    GetParm = ParmTable(i).IParm
                Case "DParm"
                    'UPGRADE_WARNING: Couldn't resolve default property of object GetParm. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    GetParm = ParmTable(i).DParm
            End Select
        End If
        Exit Function
Err_Renamed:
        'DisplayMessage(True, Err.Description, "UserSetting:GetParm")
        'Resume
    End Function

    Public Sub SetNParm(ByVal argParmId As String, ByVal argValue As String, Optional ByVal argUserOpt As String = constPrivate)
        On Error GoTo Err_Renamed
        SetParm(argParmId, 0, 0, "NParm", argValue, True, argUserOpt)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetNParm")
    End Sub

    Public Sub SetIParm(ByVal argParmId As String, ByVal argValue As String, Optional ByVal argUserOpt As String = constPrivate)
        On Error GoTo Err_Renamed
        SetParm(argParmId, 0, 0, "IParm", argValue, True, argUserOpt)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetIParm")
    End Sub

    Public Sub SetCParm(ByVal argParmId As String, ByVal argValue As String, Optional ByVal argUserOpt As String = constPrivate)
        On Error GoTo Err_Renamed
        SetParm(argParmId, 0, 0, "CParm", argValue, True, argUserOpt)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetCParm")
    End Sub

    Public Sub SetDParm(ByVal argParmId As String, ByVal argValue As String, Optional ByVal argUserOpt As String = constPrivate)
        On Error GoTo Err_Renamed
        SetParm(argParmId, 0, 0, "DParm", argValue, True, argUserOpt)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetDParm")
    End Sub

    Public Sub SetBParm(ByVal argParmId As String, ByVal argValue As String, Optional ByVal argUserOpt As String = constPrivate)
        On Error GoTo Err_Renamed
        SetParm(argParmId, 0, 0, "IParm", IIf(CBool(argValue), 1, 0), True, argUserOpt)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetBParm")
    End Sub

    Public Sub SetParm(ByVal argParmId As String, ByVal argIndex1 As Short, ByVal argIndex2 As Short, ByVal argParmType As String, ByVal argValue As Object, Optional ByVal argUpdated As Boolean = True, Optional ByVal argUserOpt As String = constPrivate)
        On Error GoTo Err_Renamed
        Dim i As Short
        If argUpdated Then
            i = SearchParm(argParmId, argIndex1, argIndex2)
            If i = -1 Then
                i = AddParm(argParmId, argIndex1, argIndex2)
                ParmTable(i).Updated = argUpdated
                ParmTable(i).UserOpt = argUserOpt
            End If
        Else
            i = AddParm(argParmId, argIndex1, argIndex2)
        End If
        Select Case argParmType
            Case "CParm"
                'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If ParmTable(i).CParm <> argValue Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ParmTable(i).CParm = argValue
                    ParmTable(i).Updated = argUpdated
                    ParmTable(i).UserOpt = argUserOpt
                End If
            Case "NParm"
                'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If ParmTable(i).NParm <> argValue Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ParmTable(i).NParm = argValue
                    ParmTable(i).Updated = argUpdated
                    ParmTable(i).UserOpt = argUserOpt
                End If
            Case "IParm"
                'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If ParmTable(i).IParm <> argValue Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ParmTable(i).IParm = argValue
                    ParmTable(i).Updated = argUpdated
                    ParmTable(i).UserOpt = argUserOpt
                End If
            Case "DParm"
                'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If ParmTable(i).DParm <> argValue Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object argValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ParmTable(i).DParm = argValue
                    ParmTable(i).Updated = argUpdated
                    ParmTable(i).UserOpt = argUserOpt
                End If
        End Select
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetParm")
        'Resume
    End Sub

    Private Function SearchParm(ByVal argParmId As String, ByVal argIndex1 As Short, ByVal argIndex2 As Short) As Short
        On Error GoTo Err_Renamed
        Dim i As Short
        SearchParm = -1
        For i = 0 To ParmTableSize - 1
            If UCase(ParmTable(i).ParmId) = UCase(argParmId) And ParmTable(i).Index1 = argIndex1 And ParmTable(i).Index2 = argIndex2 Then
                SearchParm = i
                Exit For
            End If
        Next i
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SearchParm")
    End Function

    Private Function AddParm(ByVal argParmId As String, ByVal argIndex1 As Short, ByVal argIndex2 As Short) As Short
        On Error GoTo Err_Renamed
        Dim i As Short
        If ParmTableSize + 1 >= ParmTableSizeMax Then ReDimParmTable()
        ParmTable(ParmTableSize).ParmId = argParmId
        ParmTable(ParmTableSize).Index1 = argIndex1
        ParmTable(ParmTableSize).Index2 = argIndex2
        AddParm = ParmTableSize
        ParmTableSize = ParmTableSize + 1
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:AddParm")
    End Function

    Private Sub ReDimParmTable()
        On Error GoTo Err_Renamed
        Dim i As Short
        Dim temp() As ParmTableType
        ReDim temp(ParmTableSizeMax)
        If ParmTableSize > 1 Then
            For i = 0 To ParmTableSize
                'UPGRADE_WARNING: Couldn't resolve default property of object temp(i). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                temp(i) = ParmTable(i)
            Next i
        End If
        ParmTableSizeMax = ParmTableSizeMax + 100
        ReDim ParmTable(ParmTableSizeMax)
        If ParmTableSize > 1 Then
            For i = 0 To ParmTableSize
                'UPGRADE_WARNING: Couldn't resolve default property of object ParmTable(i). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ParmTable(i) = temp(i)
            Next i
        End If
        For i = ParmTableSize To ParmTableSizeMax - 1
            ParmTable(i).Updated = False
            ParmTable(i).UserOpt = constPrivate
        Next i
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:ReDimParmTable")
        'Resume
    End Sub

    Public Sub GetUserSetting(Optional ByVal argParmId As String = " ", Optional ByVal argIndex1 As Short = 0, Optional ByVal argIndex2 As Short = 0, Optional ByRef argUserId As String = "DBO", Optional ByRef argExactly As Boolean = False)
        On Error GoTo Err_Renamed
        Dim i, j As Short
        Dim strQuery As String
        Dim blnNone As Boolean
        If blnOpened Then
            If rsUserSetting.State = ADODB.ObjectStateEnum.adStateOpen Then rsUserSetting.Close()
            'rsUserSetting.Close()
            blnOpened = False
        End If
        strQuery = strUserSettingSelect & " WHERE UserId = '" & argUserId & "' "
        strQuery = strQuery & " and DatabaseId = '" & mDataBaseId & "' "
        If InStr(argParmId, "%") > 0 Then
            strQuery = strQuery & " and ParmId like '" & argParmId & "' "
        Else
            strQuery = strQuery & " and ParmId = '" & argParmId & "' "
        End If
        strQuery = strQuery & " and Index1 = " & argIndex1 & " "
        strQuery = strQuery & " and Index2 = " & argIndex2 & " "

        strQuery = strQuery & "ORDER BY UserId, ParmId "
        'Debug.Print strQuery
        ' dang thu open bang StrConn 
        rsUserSetting.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'rsUserSetting.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'Debug.Print(strQuery)
        blnNone = rsUserSetting.EOF
        If blnNone And argUserId <> "DBO" And Not argExactly Then
            rsUserSetting.Close()
            GetUserSetting(argParmId, argIndex1, argIndex2, "DBO")
        End If
        blnOpened = True
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:GetUserSetting")
        'Resume
    End Sub
	
	Public Sub SaveParm()
		On Error GoTo Err_Renamed
		Dim i As Short
		Dim strUserId As String
		For i = 0 To ParmTableSize - 1
			Select Case ParmTable(i).UserOpt
				Case constPrivate : strUserId = mUserId
				Case constMember : strUserId = mMemberId
				Case constGlobal : strUserId = "Global"
			End Select
            If ParmTable(i).Updated And (gIsCSCLAdmin Or gIsCSCLSuperUser Or ParmTable(i).UserOpt <> constMember) And (gIsCSCLAdmin Or ParmTable(i).UserOpt <> constGlobal) Then
                GetUserSetting(ParmTable(i).ParmId, ParmTable(i).Index1, ParmTable(i).Index2, strUserId, True)
                If rsUserSetting.EOF Then
                    rsUserSetting.AddNew()
                End If
                rsUserSetting.Fields("UserId").Value = strUserId
                rsUserSetting.Fields("ParmId").Value = ParmTable(i).ParmId
                rsUserSetting.Fields("Index1").Value = ParmTable(i).Index1
                rsUserSetting.Fields("Index2").Value = ParmTable(i).Index2
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If Not IsDBNull(ParmTable(i).CParm) Then rsUserSetting.Fields("CParm").Value = IIf(ParmTable(i).CParm = "" Or Len(ParmTable(i).CParm) = 0, System.DBNull.Value, ParmTable(i).CParm)
                If IsNumeric(ParmTable(i).NParm) Then rsUserSetting.Fields("NParm").Value = ParmTable(i).NParm
                If IsNumeric(ParmTable(i).IParm) Then rsUserSetting.Fields("IParm").Value = ParmTable(i).IParm
                If IsDate(ParmTable(i).DParm) Then rsUserSetting.Fields("DParm").Value = ParmTable(i).DParm
                'Debug.Print ParmTable(i).ParmId
                rsUserSetting.Update()
            End If
		Next i
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "UserSetting:SaveParm")
		'Resume
	End Sub
	
	Public Sub SaveParmToFile()
		On Error GoTo Err_Renamed
		Dim i As Short
		FileOpen(1, gTmpFile, OpenMode.Output)
		For i = 0 To ParmTableSize - 1
			If ParmTable(i).UserOpt = constPrivate Then
				WriteLine(1, ParmTable(i).ParmId, ParmTable(i).Index1, ParmTable(i).Index2, IIf(ParmTable(i).CParm = "" Or Len(ParmTable(i).CParm) = 0, "", ParmTable(i).CParm), IIf(IsNumeric(ParmTable(i).NParm), ParmTable(i).NParm, 0), IIf(IsNumeric(ParmTable(i).IParm), ParmTable(i).IParm, 0), IIf(IsDate(ParmTable(i).DParm), ParmTable(i).DParm, ""))
			End If
		Next i
		FileClose(1)
		Exit Sub
Err_Renamed: 
		DisplayMessage(True, Err.Description, "UserSetting:SaveParmToFile")
		'Resume
    End Sub
    Public Sub SetDataGridColumnWidth(ByVal argControlId As String, ByVal argFormId As String)
        On Error GoTo Err_Renamed
        Dim Frm As System.Windows.Forms.Form
        Dim ctl As Object
        Dim i, w As Short
        For Each Frm In My.Application.OpenForms
            If Frm.Name = argFormId Then
                Frm.Visible = True
                For Each ctl In Frm.Controls
                    'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If ctl.name = argControlId Then
                        'If TypeOf ctl Is AxMSDataGridLib.AxDataGrid Then
                        i = 0
                        'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Columns. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                        Do While Not IsDBNull(GetParm(argFormId & "." & argControlId & ".width", "NParm", i)) And i < ctl.Columns.Count
                            'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Columns. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object GetParm(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            ctl.Columns.Item(i).Width = GetParm(argFormId & "." & argControlId & ".width", "NParm", i)
                            i = i + 1
                        Loop
                        'End If
                        Exit For
                    End If
        Next ctl
                Exit For
            End If
        Next Frm
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SetDataGridColumnWidth")
        'Resume
    End Sub

    Public Sub SaveDataGridColumnWidth(ByVal argControlId As String, ByVal argFormId As String)
        On Error GoTo Err_Renamed
        Dim strFind As String
        Dim i, j As Short
        Dim Frm As System.Windows.Forms.Form
        Dim ctl As Object
        For Each Frm In My.Application.OpenForms
            If Frm.Name = argFormId Then
                For Each ctl In Frm.Controls
                    'UPGRADE_WARNING: Couldn't resolve default property of object ctl.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If ctl.name = argControlId Then
                        If TypeOf ctl Is DataGridView Then
                            'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Columns. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            For i = 0 To ctl.Columns.Count - 1
                                'UPGRADE_WARNING: Couldn't resolve default property of object ctl.Columns. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                SetParm(argFormId & "." & argControlId & ".width", i, 0, "NParm", System.Math.Round(ctl.Columns.Item(i).Width, 0), True)
                            Next i
                        End If
                        Exit For
                    End If
                Next ctl
                Exit For
            End If
        Next Frm
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "UserSetting:SaveDataGridColumnWidth")
    End Sub

End Class