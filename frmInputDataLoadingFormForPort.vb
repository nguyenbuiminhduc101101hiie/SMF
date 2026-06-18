Public Class frmInputDataLoadingFormForPort
    Dim Path As String
    Sub SetExcelValue()
        Dim app As Excel.Application
        Dim rscold As New ADODB.Recordset
        Dim sqlcold As String
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}

            app = New Excel.Application()
            'Else
            'app = Proc(0)x
            app.Visible = False
            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = Me.txtFileName.Text

            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(Me.txtSheetName.Text)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim BookingNo, ContainerNo, SealNo As String
            Dim CurRow As Integer = 1
            While 1
                If Not IsNothing(ws.Range("A" & CurRow).Value) Then
                    If UCase(ws.Range("A" & CurRow).Value) = "NUMBER" Then
                        If ws.Range("A" & CurRow + 1).Value = 1 Then
                            Exit While
                        Else
                            CurRow += 1
                        End If
                    Else
                        CurRow += 1
                    End If
                End If
                If CurRow > 20 Then
                    Exit While
                End If
            End While

            While Not IsNothing(ws.Range("B" & CurRow).Value)
                If IsNothing(ws.Range("B" & CurRow).Value) Then 'Booking no không đc rỗng
                    CurRow += 1
                    Continue While
                End If
                BookingNo = ws.Range("B" & CurRow).Value
                If IsNothing(ws.Range("F" & CurRow).Value) Then 'container no không đc rỗng
                    CurRow += 1
                    Continue While
                End If
                ContainerNo = ws.Range("F" & CurRow).Value
                SealNo = ws.Range("G" & CurRow).Value

                Dim rs As New ADODB.Recordset
                Dim strQuery As String
                strQuery = "select LoadingPlanForVessel.* "
                strQuery &= "from ((LoadingPlanForVessel LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=LoadingPlanForVessel.ContainerOutboundNotifyID)"
                strQuery &= " LEFT JOIN Container On Container.CTN_ID =LoadingPlanForVessel.CTN_ID)"
                strQuery &= " Where ContainerOutboundNotify.BookingNo='" & BookingNo.Trim & "' And Container_No='" & ContainerNo.Trim & "' and LoadingPlanForVessel.Continued=1 "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        CurRow += 1
                        rs.Close()
                        Continue While
                    End If
                    .Fields("Seal").Value = SealNo
                    .Fields("weight").Value = ws.Range("I" & CurRow).Value
                    .Fields("Cold").Value = ws.Range("J" & CurRow).Value
                    .Fields("Vent").Value = ws.Range("K" & CurRow).Value
                    .Fields("RETURNPLACE").Value = ws.Range("Q" & CurRow).Value
                    .Fields("ReturnDate").Value = ws.Range("R" & CurRow).Value
                    .Fields("PLACESUPPLYEMPTYCONTAINER").Value = ws.Range("E" & CurRow).Value
                    .Fields("DateOfSupplyEmptyContainer").Value = ws.Range("D" & CurRow).Value
                    .Fields("CustomClear").Value = ws.Range("T" & CurRow).Value
                    .Update()
                End With
                rs.Close()

                CurRow += 1
            End While
            MsgBox("Completed")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        SetExcelValue()
    End Sub

    Private Sub frmInputDataLoadingFormForPort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        On Error GoTo Err
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim FileName As String = Me.OpenFileDialog1.FileName
            Me.txtFileName.Text = FileName
        End If
        Exit Sub
Err:
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class