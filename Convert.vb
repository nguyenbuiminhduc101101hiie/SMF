Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module Convert
    Public gBaseCurrency As String = "đồng"
    Function Num2Text(ByVal s As String, Optional ByVal Local As Boolean = False) As String
        'Optional ByVal Local As Boolean = False 'Nam Kỳ Reading
        'Optional ByVal Local As Boolean = True 'Bắc Kỳ Reading
        Dim DS As Char = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim GS As Char = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator
        Dim fDS As Boolean = False
        Dim fDecAdd As Boolean = False
        Dim so() As String = {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"}
        Dim hang() As String = {"", "ngàn", "triệu", "tỷ"}
        If Local Then
            hang(1) = "nghìn"
        End If
        Dim i, j, cntDS, donvi, chuc, tram As Integer
        Dim str As String
        str = ""
        s = s.Replace(GS, "")
        If s.Substring(s.Length - 1, 1) = DS Then s = s.Substring(0, s.Length - 1)

        i = s.Length
        While s.Substring(0, 1) = "0"
            s = s.Substring(1, s.Length - 1)
        End While
        If s.Substring(0, 1) = DS Then s = "0" & s
        cntDS = 0
        If InStr(s, DS) Then
            For i = 0 To s.Length - 1 Step 1
                If s.Substring(i, 1) = DS Then
                    cntDS += 1
                End If
            Next
        End If
        If cntDS > 1 Then Return ""
        If cntDS > 0 Then
            While s.Substring(s.Length - 1, 1) = "0"
                s = s.Substring(0, s.Length - 1)
            End While
        End If
        If s.Substring(s.Length - 1, 1) = DS Then s = s.Substring(0, s.Length - 1)

        i = s.Length - 1
        If i = 0 Then
            str = ""
        Else
            j = 0
            Do While i >= 0
                If s.Substring(i, 1) = DS Then
                    fDS = True
                    i -= 1
                    GoTo DecimalAdd
                Else
                    donvi = Int(s.Substring(i, 1))
                    i -= 1
                End If

                If i > -1 Then
                    If s.Substring(i, 1) = DS Then
                        i -= 1
                        chuc = -1
                        tram = -1
                        fDS = True
                        GoTo NumberRead
                    Else
                        chuc = Int(s.Substring(i, 1))
                    End If
                Else
                    chuc = -1
                End If
                i -= 1

                If i > -1 Then
                    If s.Substring(i, 1) = DS Then
                        i -= 1
                        tram = -1
                        fDS = True
                        GoTo NumberRead
                    Else
                        tram = Int(s.Substring(i, 1))
                    End If
                Else
                    tram = -1
                End If
                i -= 1
NumberRead:
                If donvi > 0 Or chuc > 0 Or tram > 0 Or j = 3 Then str = hang(j) & " " & str
                j += 1

                If j > 3 Then j = 1

                If donvi = 1 And chuc > 1 Then
                    str = "mốt" & " " & str
                ElseIf donvi = 4 And chuc > 1 Then
                    If Local Then
                        str = "tư" & " " & str
                    Else
                        str = so(donvi) & " " & str
                    End If
                ElseIf donvi = 5 Then
                    If chuc > 0 Then
                        str = "lăm" & " " & str
                    Else
                        str = so(donvi) & " " & str
                    End If
                Else
                    If donvi <> 0 Then str = so(donvi) & " " & str
                End If

                If chuc < 0 Then
                    If Not fDS Then Exit Do
                Else
                    If chuc = 0 And donvi > 0 Then
                        str = "lẻ" & " " & str
                    ElseIf chuc = 1 Then
                        str = "mười" & " " & str
                    ElseIf chuc > 1 Then
                        str = so(chuc) & " " & "mươi" & " " & str
                    End If
                End If
                If tram < 0 Then
                    If Not fDS Then Exit Do
                Else
                    If tram > 0 Or chuc > 0 Or donvi > 0 Then
                        str = so(tram) & " " & "trăm" & " " & str
                    End If
                End If
DecimalAdd:
                If fDS Then
                    str = "phảy " & str
                    j = 0
                    fDS = False
                    fDecAdd = True
                End If
            Loop
        End If

        If str.Length > 0 Then
            str = str.Trim
            str = str.Replace("  ", " ")
            str = UCase(str.Substring(0, 1)) & str.Substring(1, str.Length - 1)
            Return str
        Else
            Return ""
        End If
    End Function
    Public Function VNumberToWord(ByVal argNumber As Double, Optional ByVal argCurrency As String = "đồng") As String
        On Error GoTo Err_Renamed
        Dim strNumber, X As String
        Dim i As Short
        Dim blnNegative As Boolean
        If argCurrency = "VND" Then
            argCurrency = "đồng"
        ElseIf argCurrency = "USD" Then
            argCurrency = "Dollar Mỹ"
        Else
            ' lay chi tiet currency
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from currency where currency= '" & argCurrency & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                argCurrency = ds.Tables(0).Rows(0).Item("details").ToString()
            Else
                argCurrency = argCurrency
            End If

        End If


        VNumberToWord = ""
        strNumber = "  " & VB6.Format(argNumber, "####.00")
        i = InStr(strNumber, "-")
        If i > 0 Then
            blnNegative = True
            strNumber = Left(strNumber, i - 1) & Right(strNumber, Len(strNumber) - i)
        Else
            blnNegative = False
        End If

        For i = Len(strNumber) To 3 Step -1
            X = Mid(strNumber, i, 1)
            Select Case (Len(strNumber) - i) Mod 3
                Case 0
                    If Mid(strNumber, i, 1) <> "0" Or Mid(strNumber, i - 1, 1) <> "0" Or (Mid(strNumber, i - 2) <> "0" And i > 0) Or Len(strNumber) - i = 3 Then
                        Select Case Len(strNumber) - i
                            Case 0
                                If Mid(strNumber, i, 1) <> "0" Or Mid(strNumber, i - 1, 1) <> "0" Then
                                    VNumberToWord = IIf(argCurrency = gBaseCurrency, "xu ", "") & VNumberToWord
                                Else
                                    VNumberToWord = "chẵn " & VNumberToWord
                                End If
                            Case 3
                                'VNumberToWord = "ñoàng " & VNumberToWord
                                VNumberToWord = argCurrency & " " & VNumberToWord
                            Case 6, 15
                                If Mid(strNumber, i - 2, 3) <> "000" Then
                                    VNumberToWord = "ngàn , " & VNumberToWord
                                End If
                            Case 9, 18
                                If Mid(strNumber, i - 2, 3) <> "000" Then
                                    VNumberToWord = "triệu , " & VNumberToWord
                                End If
                            Case 12, 21
                                If Mid(strNumber, i - 2, 3) <> "000" Then
                                    VNumberToWord = "tỷ , " & VNumberToWord
                                End If
                        End Select
                    End If
                    If Mid(strNumber, i, 1) = "1" And InStr(" 01", Mid(strNumber, i - 1, 1)) = 0 Then
                        VNumberToWord = "mốt " & VNumberToWord
                    ElseIf Mid(strNumber, i, 1) = "5" And InStr(" 0", Mid(strNumber, i - 1, 1)) = 0 Then
                        VNumberToWord = "lăm " & VNumberToWord
                    ElseIf Mid(strNumber, i, 1) <> "0" Then
                        VNumberToWord = VNumberToWord2(Mid(strNumber, i, 1)) & VNumberToWord
                    End If
                Case 1
                    If Mid(strNumber, i, 1) <> "0" Then
                        If Mid(strNumber, i, 1) = "1" Then
                            VNumberToWord = "mười " & VNumberToWord
                        Else
                            VNumberToWord = VNumberToWord2(Mid(strNumber, i, 1)) & "mươi " & VNumberToWord
                        End If
                    End If
                Case 2
                    If InStr("0,.", Mid(strNumber, i, 1)) = 0 Then
                        VNumberToWord = VNumberToWord2(Mid(strNumber, i, 1)) & "trăm " & VNumberToWord
                    End If
            End Select
        Next
        If blnNegative Then VNumberToWord = "âm " & VNumberToWord
        VNumberToWord = UCase(Left(VNumberToWord, 1)) & Right(VNumberToWord, Len(VNumberToWord) - 1)
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
	
	Public Function VNumberToWord2(ByVal argNumber As String) As String
		On Error GoTo Err_Renamed
		VNumberToWord2 = ""
		Select Case argNumber
			Case CStr(0)
                VNumberToWord2 = "không "
			Case CStr(1)
                VNumberToWord2 = "một "
			Case CStr(2)
				VNumberToWord2 = "hai "
			Case CStr(3)
				VNumberToWord2 = "ba "
			Case CStr(4)
                VNumberToWord2 = "bốn "
			Case CStr(5)
                VNumberToWord2 = "năm "
			Case CStr(6)
                VNumberToWord2 = "sáu "
			Case CStr(7)
                VNumberToWord2 = "bảy "
			Case CStr(8)
                VNumberToWord2 = "tám "
			Case CStr(9)
				VNumberToWord2 = "chín "
		End Select
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description)
	End Function
	
	
	Public Function ENumberToWord(ByVal argNumber As Double, Optional ByVal argCurrency As String = "US Dollar") As String
		On Error GoTo Err_Renamed
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim strDecimal, strNumber, str_Renamed As String
		Dim l, i As Short
		str_Renamed = ""
		strNumber = VB6.Format(argNumber, "####.00")
		strDecimal = Right(strNumber, 2)
		strNumber = Left(strNumber, Len(strNumber) - 3)
		i = InStr(strNumber, "-")
		If i > 0 Then
			str_Renamed = "minus "
			strNumber = Left(strNumber, i - 1) & Right(strNumber, Len(strNumber) - i)
		End If
		l = Len(strNumber)
		If l > 0 Then
			i = IIf(l > 9, l - 9, 0)
			str_Renamed = str_Renamed & ENumberToWord_Millions(Left(strNumber, i), "billion ") & ENumberToWord_Millions(Right(strNumber, 9), " ")
		Else
			str_Renamed = ""
		End If
        str_Renamed = CStr(str_Renamed & " " + IIf(strDecimal = "00", " only.", "and cent(s) " & ENumberToWord_Units(strDecimal, ".")))
		i = 1
		While i < Len(str_Renamed) - 1
			If Mid(str_Renamed, i, 2) = "  " Then
				str_Renamed = Left(str_Renamed, i) & Right(str_Renamed, Len(str_Renamed) - i - 1)
			ElseIf Mid(str_Renamed, i, 2) = " ," Then 
				str_Renamed = Left(str_Renamed, i - 1) & Right(str_Renamed, Len(str_Renamed) - i)
			Else
				i = i + 1
			End If
		End While
		i = 1
		While i < Len(str_Renamed) - 1
			If Mid(str_Renamed, i, 15) = "billion million" Then
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 15)
			ElseIf Mid(str_Renamed, i, 16) = "billion thousand" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 16)
			ElseIf Mid(str_Renamed, i, 19) = "billion hundred and" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 19)
			ElseIf Mid(str_Renamed, i, 16) = "million thousand" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 16)
			ElseIf Mid(str_Renamed, i, 19) = "million hundred and" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 19)
			ElseIf Mid(str_Renamed, i, 20) = "thousand hundred and" Then 
				str_Renamed = Left(str_Renamed, i + 8) & Right(str_Renamed, Len(str_Renamed) - i - 20)
			ElseIf Mid(str_Renamed, i, 19) = "hundred and billion" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 11)
			ElseIf Mid(str_Renamed, i, 19) = "hundred and million" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 11)
			ElseIf Mid(str_Renamed, i, 20) = "hundred and thousand" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 11)
			ElseIf Mid(str_Renamed, i, 16) = "hundred and only" Then 
				str_Renamed = Left(str_Renamed, i + 7) & Right(str_Renamed, Len(str_Renamed) - i - 11)
			ElseIf Mid(str_Renamed, i, 12) = "hundred and," Then 
				str_Renamed = Left(str_Renamed, i + 6) & "," & Right(str_Renamed, Len(str_Renamed) - i - 11)
			Else
				i = i + 1
			End If
		End While
		ENumberToWord = argCurrency & " " & str_Renamed
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description)
	End Function
	
	Private Function ENumberToWord_Millions(ByRef argNumber As String, Optional ByRef argSuffix As String = "") As String
		On Error GoTo Err_Renamed
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim l, i As Short
		Dim str_Renamed As String
		l = Len(argNumber)
		If l > 0 Then
			i = IIf(l > 6, l - 6, 0)
			str_Renamed = str_Renamed & ENumberToWord_Thousands(Left(argNumber, i), "million ") & ENumberToWord_Thousands(Right(argNumber, 6), " ")
			ENumberToWord_Millions = IIf(Len(str_Renamed) > 0, str_Renamed & argSuffix, "")
		Else
			ENumberToWord_Millions = ""
		End If
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description)
	End Function
	
	Private Function ENumberToWord_Thousands(ByRef argNumber As String, Optional ByRef argSuffix As String = "") As String
		On Error GoTo Err_Renamed
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim l, i As Short
		Dim str_Renamed As String
		l = Len(argNumber)
		If l > 0 Then
			i = IIf(l > 3, l - 3, 0)
			str_Renamed = str_Renamed & ENumberToWord_Hundreds(Left(argNumber, i), "thousand ") & ENumberToWord_Hundreds(Right(argNumber, 3), " ")
			ENumberToWord_Thousands = IIf(Len(str_Renamed) > 0, str_Renamed & " " & argSuffix, "")
		Else
			ENumberToWord_Thousands = ""
		End If
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description)
	End Function
	
	Private Function ENumberToWord_Hundreds(ByRef argNumber As String, Optional ByRef argSuffix As String = "") As String
		On Error GoTo Err_Renamed
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim l, i As Short
		Dim str_Renamed As String
		l = Len(argNumber)
		If l > 0 Then
			i = IIf(l > 2, l - 2, 0)
			str_Renamed = str_Renamed & ENumberToWord_Units(Left(argNumber, i), "hundred and ") & ENumberToWord_Units(Right(argNumber, 2))
			ENumberToWord_Hundreds = IIf(Len(str_Renamed) > 0, str_Renamed & " " & argSuffix, "")
		Else
			ENumberToWord_Hundreds = ""
		End If
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description)
	End Function
	
	Private Function ENumberToWord_Units(ByRef argNumber As String, Optional ByRef argSuffix As String = "") As String
		On Error GoTo Err_Renamed
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim i, j As Short
		Dim str_Renamed As String
		If argNumber <> "" Then
			i = CShort(argNumber)
            If i < 20 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object Switch(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                str_Renamed = VB.Switch(i = 0, "", i = 1, "one", i = 2, "two", i = 3, "three", i = 4, "four", i = 5, "five", i = 6, "six", i = 7, "seven", i = 8, "eight", i = 9, "nine", i = 10, "ten", i = 11, "eleven", i = 12, "twelve", i = 13, "thirteen", i = 14, "fourteen", i = 15, "fifteen", i = 16, "sixteen", i = 17, "seventeen", i = 18, "eighteen", i = 19, "nineteen")
            Else
                j = CShort(Left(argNumber, 1))
                'UPGRADE_WARNING: Couldn't resolve default property of object Switch(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                str_Renamed = VB.Switch(j = 2, "twenty", j = 3, "thirty", j = 4, "forty", j = 5, "fifty", j = 6, "sixty", j = 7, "seventy", j = 8, "eighty", j = 9, "ninety") + " " + ENumberToWord_Units(Right(argNumber, 1))
            End If
			ENumberToWord_Units = str_Renamed & " " & argSuffix
		Else
			ENumberToWord_Units = ""
		End If
		Exit Function
Err_Renamed: 
		DisplayMessage(True, Err.Description)
		'Resume
	End Function
End Module