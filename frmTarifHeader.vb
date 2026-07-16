Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Drawing
Imports System.Windows.Forms

Partial Public Class frmTarifHeader
    Inherits System.Windows.Forms.Form

    Dim mHeaderId As String = DefaultValue
    Public blnUpdated As Boolean

    Private Sub frmTarifHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        blnUpdated = False
        mHeaderId = DefaultValue
        SetDefaultGrid(Me.dgdHeader, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdDetail, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.BackColor = gMaunen
        Me.pnlToolbar.BackColor = Color.White
        Me.pnlInfo.BackColor = Color.FromArgb(240, 248, 255)
        UpdateSelectionInfo()
        QueryHeaders()
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryHeaders()
        Try
            Dim strSQL As String
            strSQL = "Select h.id, h.Name, c.company + '-' + c.taxcode as Customer, h.Type, h.date, h.usercreate "
            strSQL &= "From Header_Tarif h "
            strSQL &= "Left Join customer c on h.customer_id = c.customer_id "
            strSQL &= "Order By h.date desc "
            Dim dt As DataTable = ReadTable(strSQL)
            Me.dgdHeader.DataSource = dt
            HideColumn(Me.dgdHeader, "id")
            ColorTypeColumn()
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Sub QueryDetails(Optional ByVal headerId As String = "")
        Try
            If headerId = "" Then headerId = mHeaderId
            If headerId = "" Or headerId = DefaultValue Then
                Me.dgdDetail.DataSource = Nothing
                Exit Sub
            End If
            Dim strSQL As String
            strSQL = "Select d.id, d.id_header, d.itemid, "
            strSQL &= "ch.charge_code + '/' + ch.dvt + '/' + ch.charge as Item, "
            strSQL &= "d.currency, d.unit, d.qty, d.unitprice, d.totalamount, d.vat, d.unitprice_incvat, d.tigia "
            strSQL &= "From Deatail_Tarif d "
            strSQL &= "Left Join charge ch on d.itemid = ch.charge_id "
            strSQL &= "Where d.id_header = '" & headerId & "' "
            strSQL &= "Order By ch.charge_code "
            Dim dt As DataTable = ReadTable(strSQL)
            Me.dgdDetail.DataSource = dt
            HideColumn(Me.dgdDetail, "id")
            HideColumn(Me.dgdDetail, "id_header")
            HideColumn(Me.dgdDetail, "itemid")
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Sub HideColumn(ByVal grid As DataGridView, ByVal colName As String)
        Try
            If grid.Columns.Contains(colName) Then grid.Columns(colName).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ColorTypeColumn()
        Try
            If Not Me.dgdHeader.Columns.Contains("Type") Then Exit Sub
            For Each row As DataGridViewRow In Me.dgdHeader.Rows
                If row.Cells("Type").Value IsNot Nothing Then
                    If row.Cells("Type").Value.ToString() = "Debit" Then
                        row.Cells("Type").Style.ForeColor = Color.DarkRed
                        row.Cells("Type").Style.Font = New Font(Me.dgdHeader.Font, FontStyle.Bold)
                    ElseIf row.Cells("Type").Value.ToString() = "Credit" Then
                        row.Cells("Type").Style.ForeColor = Color.DarkGreen
                        row.Cells("Type").Style.Font = New Font(Me.dgdHeader.Font, FontStyle.Bold)
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadSelectedHeader()
        Try
            If Me.dgdHeader.CurrentRow Is Nothing Then
                mHeaderId = DefaultValue
                UpdateSelectionInfo()
                Me.dgdDetail.DataSource = Nothing
                Exit Sub
            End If
            mHeaderId = Me.dgdHeader.CurrentRow.Cells("id").Value.ToString()
            UpdateSelectionInfo()
            QueryDetails(mHeaderId)
            UpdateDetailMenuState()
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Sub UpdateSelectionInfo()
        If mHeaderId = "" Or mHeaderId = DefaultValue Or Me.dgdHeader.CurrentRow Is Nothing Then
            Me.lblSelectedInfo.Text = "No header selected. Select a header to view details or add new details."
            Me.lblDetailTitle.Text = "Detail List (select a header above)"
            Me.smnuNewDetails.Enabled = False
            Me.smnuEditHeader.Enabled = False
            Me.smnuDeleteHeader.Enabled = False
            Me.smnuEditDetail.Enabled = False
            Me.smnuDeleteDetail.Enabled = False
        Else
            Dim name As String = Me.dgdHeader.CurrentRow.Cells("Name").Value.ToString()
            Dim customer As String = Me.dgdHeader.CurrentRow.Cells("Customer").Value.ToString()
            Dim typeVal As String = Me.dgdHeader.CurrentRow.Cells("Type").Value.ToString()
            Me.lblSelectedInfo.Text = "Selected: " & name & "  |  " & customer & "  |  Type: " & typeVal
            Me.lblDetailTitle.Text = "Detail List - " & name
            Me.smnuNewDetails.Enabled = True
            Me.smnuEditHeader.Enabled = True
            Me.smnuDeleteHeader.Enabled = True
            UpdateDetailMenuState()
        End If
    End Sub

    Sub UpdateDetailMenuState()
        Dim hasDetail As Boolean = Me.dgdDetail.CurrentRow IsNot Nothing AndAlso mHeaderId <> "" And mHeaderId <> DefaultValue
        Me.smnuEditDetail.Enabled = hasDetail
        Me.smnuDeleteDetail.Enabled = hasDetail
    End Sub

    Private Sub OpenNewHeader()
        Dim frm As New frmTarifHeaderInput(False)
        frm.StartPosition = FormStartPosition.CenterParent
        If frm.ShowDialog(Me) = DialogResult.OK And frm.IsSaved Then
            blnUpdated = True
            QueryHeaders()
            mHeaderId = frm.HeaderId
            SelectHeaderRow(mHeaderId)
            If ConfirmMessage(True, "Header saved. Do you want to add details now?") = MsgBoxResult.Ok Then
                OpenNewDetails()
            End If
        End If
    End Sub

    Private Sub OpenEditHeader()
        If mHeaderId = "" Or mHeaderId = DefaultValue Then
            DisplayMessage(True, "Select a header.")
            Exit Sub
        End If
        Dim frm As New frmTarifHeaderInput(True, mHeaderId)
        frm.StartPosition = FormStartPosition.CenterParent
        If frm.ShowDialog(Me) = DialogResult.OK And frm.IsSaved Then
            blnUpdated = True
            QueryHeaders()
            SelectHeaderRow(frm.HeaderId)
        End If
    End Sub

    Private Sub OpenNewDetails()
        If mHeaderId = "" Or mHeaderId = DefaultValue Then
            DisplayMessage(True, "Select a header first.")
            Exit Sub
        End If
        Dim headerName As String = ""
        Dim customer As String = ""
        Dim typeVal As String = ""
        If Me.dgdHeader.CurrentRow IsNot Nothing Then
            headerName = Me.dgdHeader.CurrentRow.Cells("Name").Value.ToString()
            customer = Me.dgdHeader.CurrentRow.Cells("Customer").Value.ToString()
            typeVal = Me.dgdHeader.CurrentRow.Cells("Type").Value.ToString()
        End If
        Dim frm As New frmTarifDetailInput(mHeaderId, headerName, customer, typeVal)
        frm.StartPosition = FormStartPosition.CenterParent
        If frm.ShowDialog(Me) = DialogResult.OK And frm.IsSaved Then
            blnUpdated = True
            QueryDetails(mHeaderId)
        End If
    End Sub

    Private Sub OpenEditDetail()
        If Me.dgdDetail.CurrentRow Is Nothing Then
            DisplayMessage(True, "Select a detail row.")
            Exit Sub
        End If
        Dim detailId As String = Me.dgdDetail.CurrentRow.Cells("id").Value.ToString()
        Dim frm As New frmTarifDetailEdit(detailId, mHeaderId)
        frm.StartPosition = FormStartPosition.CenterParent
        If frm.ShowDialog(Me) = DialogResult.OK And frm.IsSaved Then
            blnUpdated = True
            QueryDetails(mHeaderId)
        End If
    End Sub

    Private Sub SelectHeaderRow(ByVal headerId As String)
        Try
            For Each row As DataGridViewRow In Me.dgdHeader.Rows
                If row.Cells("id").Value.ToString() = headerId Then
                    row.Selected = True
                    Me.dgdHeader.CurrentCell = row.Cells(1)
                    LoadSelectedHeader()
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub smnuNewHeader_Click(sender As Object, e As EventArgs) Handles smnuNewHeader.Click
        OpenNewHeader()
    End Sub

    Public Sub smnuEditHeader_Click(sender As Object, e As EventArgs) Handles smnuEditHeader.Click
        OpenEditHeader()
    End Sub

    Public Sub smnuNewDetails_Click(sender As Object, e As EventArgs) Handles smnuNewDetails.Click
        OpenNewDetails()
    End Sub

    Public Sub smnuEditDetail_Click(sender As Object, e As EventArgs) Handles smnuEditDetail.Click
        OpenEditDetail()
    End Sub

    Public Sub smnuRefresh_Click(sender As Object, e As EventArgs) Handles smnuRefresh.Click
        QueryHeaders()
        If mHeaderId <> "" And mHeaderId <> DefaultValue Then
            QueryDetails(mHeaderId)
        End If
    End Sub

    Public Sub smnuDeleteHeader_Click(sender As Object, e As EventArgs) Handles smnuDeleteHeader.Click
        On Error GoTo Err_Renamed
        If Me.dgdHeader.CurrentRow Is Nothing Then Exit Sub
        Dim headerId As String = Me.dgdHeader.CurrentRow.Cells("id").Value.ToString()
        If ConfirmMessage(True, "Delete this header and all details?") <> MsgBoxResult.Ok Then Exit Sub
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM Deatail_Tarif WHERE id_header = '" & headerId & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        Do While Not rs.EOF
            rs.Delete()
            rs.MoveNext()
        Loop
        rs.Close()
        rs.Open("SELECT * FROM Header_Tarif WHERE id = '" & headerId & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then rs.Delete()
        rs.Close()
        mHeaderId = DefaultValue
        blnUpdated = True
        QueryHeaders()
        Me.dgdDetail.DataSource = Nothing
        UpdateSelectionInfo()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDeleteDetail_Click(sender As Object, e As EventArgs) Handles smnuDeleteDetail.Click
        On Error GoTo Err_Renamed
        If Me.dgdDetail.CurrentRow Is Nothing Then Exit Sub
        Dim detailId As String = Me.dgdDetail.CurrentRow.Cells("id").Value.ToString()
        If ConfirmMessage(True, "Delete this detail?") <> MsgBoxResult.Ok Then Exit Sub
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM Deatail_Tarif WHERE id = '" & detailId & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then rs.Delete()
        rs.Close()
        blnUpdated = True
        QueryDetails(mHeaderId)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuExit_Click(sender As Object, e As EventArgs) Handles smnuExit.Click
        Me.Close()
    End Sub

    Private Sub dgdHeader_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdHeader.CellClick
        If e.RowIndex < 0 Then Exit Sub
        LoadSelectedHeader()
    End Sub

    Private Sub dgdDetail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdDetail.CellClick
        If e.RowIndex < 0 Then Exit Sub
        UpdateDetailMenuState()
    End Sub

    Private Sub dgdDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdDetail.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenEditDetail()
    End Sub

    Private Sub dgdHeader_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgdHeader.DataBindingComplete
        ColorTypeColumn()
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err_Renamed
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        If Me.MdiParent IsNot Nothing Then
            Me.Top = 0
            Me.Left = 0
            Me.Width = Me.MdiParent.ClientSize.Width - 8
            Me.Height = Me.MdiParent.ClientSize.Height - 8
        Else
            Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
            Me.Left = 0
            Me.Height = frmMain.Height - 10 - Me.Top
            Me.Width = frmMain.Width - 10
        End If
        If Me.splitMain.Height > 200 Then
            Me.splitMain.SplitterDistance = CInt(Me.splitMain.Height * 0.38)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmTarifHeader_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ReFormat()
    End Sub

End Class
