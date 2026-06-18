Public Class frmImportConnectingVessel

    Public Sub ConnectoExcel(ByVal File As String)
       

        Dim Dt, result, temp As New DataTable
        Dim app As Excel.Application
        Try
            Me.Cursor = Cursors.WaitCursor
            app = New Excel.Application()
            app.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            workbook = workbooks.Open(File)

            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetname.Text)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If


            '  Dim dem As Integer = 0
            Dim starRow As Integer = 6
            Dim CurRow As Integer = starRow
            Dim ContainerNo, BLNO As String
            Dim strQuery As String
            Dim TOTALROW As Integer = 0
            Dim TempCurRow As Integer = CurRow
            'While (Not IsNothing(ws.Range("B" & TempCurRow).Value) And Not IsNothing(ws.Range("C" & TempCurRow).Value))
            '    TOTALROW += 1
            '    TempCurRow += 1
            'End While
            Me.GroupBox1.Visible = True
            Me.prbExport.Style = ProgressBarStyle.Marquee
            While (Not IsNothing(ws.Range("A" & CurRow).Value))
                'If ws.Range("B" & CurRow).Value.ToString = "" Or ws.Range("C" & CurRow).Value.ToString = "" Then
                '    Return
                'End If
                Application.DoEvents()
                Me.Label7.Text = FormatNumber(((CurRow - starRow) / TOTALROW), 2) * 100 & " %"
                'ContainerNo = ws.Range("C" & CurRow).Value2
                'BLNO = ws.Range("B" & CurRow).Value2
                strQuery = "SELECT Top 1 * "
                strQuery = strQuery & " FROM customer " 'where Container_No='" & ContainerNo & "' And BL_NO='" & BLNO & "' and Continued=1"
                Dim rs As New ADODB.Recordset
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If rs.EOF Then ' chưa có trong CSDL
                With rs
                    .AddNew()
                
                    .Fields("customer_code").Value = ws.Range("a" & CurRow).Value2
                    .Fields("hancongno").Value = "0"
                    .Fields("district").Value = ws.Range("g" & CurRow).Value2
                    .Fields("taxcode").Value = ws.Range("c" & CurRow).Value2

                    .Fields("englishname").Value = ws.Range("j" & CurRow).Value2.ToString.Replace("-", "").Replace("'", "")
                    .Fields("company").Value = ws.Range("b" & CurRow).Value2.ToString.Replace("-", "").Replace("'", "")
                    .Fields("bizname").Value = ws.Range("b" & CurRow).Value2.ToString.Replace("-", "").Replace("'", "")
                    If Not IsNothing(ws.Range("d" & CurRow).Value2) Then
                        .Fields("address").Value = ws.Range("d" & CurRow).Value2
                    Else
                        .Fields("address").Value = ws.Range("k" & CurRow).Value2
                    End If

                    .Fields("tel").Value = ws.Range("h" & CurRow).Value2
                    .Fields("fax").Value = ws.Range("i" & CurRow).Value2

                    .Fields("remarks_customer").Value = ws.Range("f" & CurRow).Value2
                    .Fields("salename").Value = ws.Range("e" & CurRow).Value2
                    .Fields("phuphicourier").Value = ws.Range("n" & CurRow).Value2


                    .Update()
                End With
                'End If
                rs.Close()
                CurRow += 1
            End While
            Me.Text = "Import Connecting Vessel (Import Complete : " & Me.txtVessel.Text & " - VoyNo : " & Me.txtVoyNo.Text & ")"
            'Me.Label7.Text = "Complete"
           
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("Có thể file không co " & Me.txtSheetname.Text & ", hay sửa tên sheet Import thành Sheet1")
            Else
                MessageBox.Show(ex.Message())
            End If
        Finally
            Me.prbExport.Style = ProgressBarStyle.Blocks
            Me.GroupBox1.Visible = False
            app.Quit()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            If Me.txtFileName.Text.Trim = "" Then
                MsgBox("File name Cannot be Null, Please select a file")
                Return
            End If
            If Me.txtSheetname.Text.Trim = "" Then
                MsgBox("sheet name Cannot be Null, Please input a Sheet name")
                Return
            End If
            Me.Text = "Wait For Importing..."
            ConnectoExcel(Me.txtFileName.Text)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        Try
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.txtFileName.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmImportConnectingVessel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Import Connecting Vessel"
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class