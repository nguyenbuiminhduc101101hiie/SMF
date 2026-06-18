Imports System.Data.OleDb

Module ProcessConnect

    Public Company As String
    Public ComAddress As String
    Public ComTelephone As String
    Public ComFax As String
    Public ComEmail As String

   

   

    Structure DEGREELEVEL
        Dim DegreeID As String
        Dim Degree As String
        Dim DegreeCode As String
    End Structure

    Public Function ReadDegree() As ArrayList
        Try
            Dim result As New ArrayList
            Dim deg As DEGREELEVEL = Nothing

            Dim CN As New OleDbConnection
            Dim dr As OleDbDataReader = Nothing
            Dim sql As String = "Select DegreeID,DegreeCode,Degree " & _
                                "From Degree " & _
                                "Where continued=1"
            OpenConnect(CN, dr, sql)
            While dr.Read
                deg.DegreeID = dr.GetGuid(0).ToString
                deg.DegreeCode = Trim(dr.GetString(1))
                deg.Degree = Trim(dr.GetString(2))
                result.Add(deg)
            End While

            CloseConnect(CN, dr)
            Return result
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Function OpenConnect(ByRef CN As OleDbConnection, ByRef rs As OleDbDataReader, ByVal sql As String) As Boolean
        CN.ConnectionString = stConnect
        Try
            CN.Open()
            Dim myCommand As New OleDbCommand(sql, CN)
            rs = myCommand.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Sub CloseConnect(ByRef CN As OleDbConnection, ByRef rs As OleDbDataReader)
        CN.Close()
        rs.Close()
    End Sub

    Public Function Get_ID(ByVal ID As String) As String
        Dim st As String = ""
        st = Strings.Left(ID, ID.Length - 1)
        st = Strings.Right(st, st.Length - 1)
        Return st
    End Function

    Function CheckUnique(ByVal Table As String, ByVal Column As String, ByVal condition As String) As Boolean
        Dim CN As New OleDbConnection
        Dim dr As OleDbDataReader = Nothing

        Dim sql As String = "Select Count(" & Column & ") " & _
                            "From " & Table & " " & _
                            "Where " & Column & "='" & condition & "' And continued<>0"
        Dim n As Integer
        OpenConnect(CN, dr, sql)
        While dr.Read
            n = dr.GetInt32(0)
        End While
        CloseConnect(CN, dr)
        If n = 0 Then
            Return True
        End If
        Return False
    End Function

   

    Public Function ReadTableDB(ByVal stSql As String) As DataTable
       
    End Function

   

    Public Function CheckFind(ByVal stFind As String) As Boolean
        Dim stTmp As String = stFind
        Dim f As Integer = stTmp.IndexOf("'"c)
        With stTmp
            f = f And .IndexOf("!"c) And .IndexOf("#"c)
            f = f And .IndexOf("%"c) And .IndexOf(""""c)
            f = f And .IndexOf("&"c)
        End With
        If f = -1 Then Return True
        Return False
    End Function

    Public Sub LoadCombo(ByVal combo As ComboBox)
        combo.Items.Clear()
        Dim tmp As String = ""
        For i As Integer = 2005 To 2050
            For j As Integer = 1 To 12
                If j < 10 Then
                    tmp = "0" & j.ToString
                Else
                    tmp = j.ToString
                End If
                combo.Items.Add(i.ToString & tmp)
            Next
        Next
        combo.SelectedIndex = 0
    End Sub

    

    Public Function getID(ByVal strID As String) As String
        Dim index As Integer = strID.IndexOf("{")
        If index <> -1 Then
            Return strID
        End If
        strID = "{" & strID & "}"
        Return strID
    End Function

    


    Public Function Execute(ByVal strSql As String) As Boolean
        Try
            Dim Ket_Noi As New OleDbConnection(stConnect)
            Ket_Noi.Open()
            Dim myComand As New OleDbCommand(strSql, Ket_Noi)
            myComand.ExecuteNonQuery()
            Ket_Noi.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function ExecuteDB(ByVal strSql As String) As Boolean
       
    End Function
End Module
