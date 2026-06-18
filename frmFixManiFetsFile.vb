Public Class frmFixManiFetsFile
    Dim SourePath, DestPath As String


    Sub SetExcel()
        Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Me.Cursor = Cursors.WaitCursor
        Dim Path As String = Me.txtFileName.Text
        Dim SheetName As String = Me.txtSheetName.Text
        'If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Path = Me.OpenFileDialog1.FileName
        'Else
        '    Return
        'End If
        Dim App As New Excel.Application
        Try
            App.Visible = False
            Dim WorkBooks As Excel.Workbooks
            WorkBooks = App.Workbooks
            Dim WorkBook As Excel.Workbook
            WorkBook = WorkBooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = WorkBook.Sheets
            Dim ws As Excel._Worksheet
            'Dim CountSheet As Integer = 3
            'For i As Integer = 1 To CountSheet
            ws = sheets.Item(SheetName)
            Dim DongHienTai As Integer = 2
            Dim EndFile As Integer = 0
            While EndFile < 100
                Dim strTemp As String
                For Col As Integer = 0 To 10
                    If Not IsNothing(ws.Range(Alpha(Col) & DongHienTai).Value2) Then
                        EndFile = 0
                        Exit For
                    End If
                Next

                If Not IsNothing(ws.Range("E" & DongHienTai).Value2) Then

                    strTemp = ws.Range("E" & DongHienTai).Value2
                    strTemp = strTemp.Trim
                    If strTemp.Trim.Length > 0 Then
                        If Char.IsDigit(Strings.Left(strTemp, 1)) Then
                            Dim Temp() As String
                            strTemp = Strings.Replace(strTemp, "  ", " ")
                            Temp = Strings.Split(strTemp, " ")
                            If Temp.Length < 4 Then
                                DongHienTai += 1
                                Continue While
                            End If
                            If UCase(Temp(1)) Like "*X*" Then
                                If Temp(3) = "OCB" Or Temp(3) = "ODB" Then
                                    ws.Range("E" & DongHienTai).Value = Temp(0).Trim & " " & Temp(1).Trim & " " & Temp(2).Trim
                                Else
                                    ws.Range("E" & DongHienTai).Value2 = "" 'Temp(0).Trim & " " & Temp(1).Trim & " " & Temp(2).Trim
                                End If
                                ws.Range("H" & DongHienTai).Value = ""
                                ws.Range("I" & DongHienTai).Value = ""
                                ws.Range("H" & DongHienTai + 1).Value = ""
                                ws.Range("I" & DongHienTai + 1).Value = ""
                            End If
                        End If
                    End If
                Else
                    EndFile += 1
                End If
                'Me.Label4.Text = DongHienTai
                DongHienTai += 1
            End While
            'ext
            WorkBook.SaveAs(Me.txtDestPath.Text, , , , , , Excel.XlSaveAsAccessMode.xlNoChange, , , , )
            MsgBox("Complete")
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            App.Quit()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmFixManiFetsFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Label4.Visible = False
    End Sub

    Private Sub cmdBrowserSaveTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowserSaveTo.Click
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtDestPath.Text = Me.SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        On Error GoTo Err
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtFileName.Text = Me.OpenFileDialog1.FileName

        End If
        Exit Sub
Err:
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        SetExcel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class