Imports System.IO
Public Class frmCheckEDI

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.rtEDI1.Text = ""
            Me.rtEDI2.Text = ""

            If Me.txtEDi1.Text.Trim = "" Or Me.txtEDI2.Text.Trim = "" Then
                MsgBox("You Have to Insert a text Path ")
                Return
            End If
            If File.Exists(Me.txtEDi1.Text) = False Then
                MsgBox(Me.txtEDi1.Text & " Not Found")
                Return
            End If
            If File.Exists(Me.txtEDI2.Text) = False Then
                MsgBox(Me.txtEDI2.Text & " Not Found")
                Return
            End If
            Dim frEDI1 As New StreamReader(Me.txtEDi1.Text)
            Dim frEDI2 As New StreamReader(Me.txtEDI2.Text)
            Dim TempEDI1, TempEDI2 As String
            Dim rtEDI1Len, rtEDI2Len As Integer
            'txtEDi1.SelectionStart = txtEDi1.Text.Length
            'txtEDI2.SelectionStart = txtEDI2.Text.Length
            While Not (frEDI1.EndOfStream And frEDI2.EndOfStream)

                TempEDI1 = frEDI1.ReadLine().Trim
                TempEDI2 = frEDI2.ReadLine().Trim

                rtEDI1Len = Me.txtEDi1.Text.Length 'chiều dài trứơc khi thêm dòng mới
                rtEDI2Len = Me.txtEDI2.Text.Length 'chiều dài trứơc khi thêm dòng mới

                If LCase(TempEDI1) <> LCase(TempEDI2) Then

                  
                   

                    Dim EDI1, EDI2 As String
                    EDI1 = ""
                    EDI2 = ""
                    Dim Temp1(), Temp2() As String
                    Temp1 = Strings.Split(TempEDI1, ":")
                    Temp2 = Strings.Split(TempEDI2, ":")
                    Dim i As Integer = 0
                    While i < Temp1.Length And i < Temp2.Length
                        If LCase(Temp1(i)) <> LCase(Temp2(i)) Then

                            Me.rtEDI1.SelectionColor = Color.Green
                            Me.rtEDI1.SelectionBackColor = Color.Yellow
                            Me.rtEDI1.SelectionFont = New Font("Courier New", 15, FontStyle.Bold Or FontStyle.Italic)

                            Me.rtEDI2.SelectionColor = Color.Green
                            Me.rtEDI2.SelectionBackColor = Color.Yellow
                            Me.rtEDI2.SelectionFont = New Font("Courier New", 15, FontStyle.Bold Or FontStyle.Italic)
                        Else
                            Me.rtEDI1.SelectionColor = Color.Red
                            Me.rtEDI1.SelectionBackColor = Color.Transparent
                            Me.rtEDI1.SelectionFont = New Font("Courier New", 15, FontStyle.Bold)


                            Me.rtEDI2.SelectionColor = Color.Red
                            Me.rtEDI2.SelectionBackColor = Color.Transparent
                            Me.rtEDI2.SelectionFont = New Font("Courier New", 15, FontStyle.Bold)

                        End If
                        Me.rtEDI1.AppendText(":" & Temp1(i))
                        Me.rtEDI2.AppendText(":" & Temp2(i))
                        i += 1
                    End While
                    Me.rtEDI1.AppendText(System.Environment.NewLine)
                    Me.rtEDI2.AppendText(System.Environment.NewLine)
                Else
                    Me.rtEDI1.AppendText(TempEDI1 & System.Environment.NewLine)
                    Me.rtEDI2.AppendText(TempEDI2 & System.Environment.NewLine)
                End If


            End While
            frEDI1.Close()
            frEDI2.Close()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdBrowser1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser1.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtEDi1.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub cmdBrowser2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser2.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtEDI2.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub rtEDI1_VScroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtEDI1.VScroll
       

    End Sub
End Class