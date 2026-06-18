Imports System.IO
Public Class frmRegLicense

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        Dim t1, t2, t3, i As Integer
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtSFileName.Text = Me.OpenFileDialog1.FileName
        End If
        If Me.txtSFileName.Text = "" Then
            DisplayMessage(True, "Please input file path.")
            Me.txtSFileName.Focus()
            Exit Sub
        End If
        '---
        Dim Path2 As String = Application.StartupPath & "\" & "licensecl.txt"
        '' mahoa file
        Giai_Ma_file(Me.txtSFileName.Text.Trim, _pass, Path2)

        '----
        Dim fr As StreamReader
        fr = New StreamReader(Path2)
        Dim temp As String = fr.ReadLine()
        Dim temp2(), Key As String
        'UserLicense = fr.ReadLine()
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        temp = temp.Trim
        temp2 = Giai_Ma(temp).Split(";")
        Key = temp2(1)
        '-------
        t1 = Key.Trim.Length / 3
        For i = 0 To t1 - 1
            Me.TextBox1.Text += Key(i)
        Next
        t2 = Key.Trim.Length - t1
        t2 = t2 / 2
        For i = Me.TextBox1.Text.Trim.Length To Me.TextBox1.Text.Trim.Length + t2 - 1
            Me.TextBox2.Text += Key(i)
        Next
        t3 = Key.Trim.Length - t2 - t1
        For i = Me.TextBox1.Text.Trim.Length + Me.TextBox2.Text.Trim.Length To Key.Trim.Length - 1
            Me.TextBox3.Text += Key(i)
        Next
        '-------
        fr.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReg.Click
        'If Me.TextBox1.Text.Trim = Me.TextBox4.Text.Trim And Me.TextBox2.Text.Trim = Me.TextBox5.Text.Trim And Me.TextBox3.Text.Trim = Me.TextBox6.Text.Trim Then
        '    ' bung file vao thu muc app
        '    Dim Path2 As String = Application.StartupPath & "\" & "licenseuk.txt"
        '    System.IO.File.Copy(Me.txtSFileName.Text.Trim, Path2, True)
        '    DisplayMessage(True, "Reg. complete!")
        'Else
        '    DisplayMessage(True, "Please check Reg. No. again !")
        'End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class