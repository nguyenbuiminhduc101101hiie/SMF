Option Strict Off
Option Explicit On
Imports System.Windows.Forms

Partial Public Class frmTarifDetailInput
    Inherits Form

    Public HeaderId As String
    Public HeaderName As String = ""
    Public HeaderCustomer As String = ""
    Public HeaderType As String = ""
    Public IsSaved As Boolean = False

    Private oPendingDetails As DataTable

    Public Sub New(ByVal headerId As String, Optional ByVal headerName As String = "", Optional ByVal headerCustomer As String = "", Optional ByVal headerType As String = "")
        InitializeComponent()
        Me.HeaderId = headerId
        Me.HeaderName = headerName
        Me.HeaderCustomer = headerCustomer
        Me.HeaderType = headerType
    End Sub

    Private Sub frmTarifDetailInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitPendingTable()
        SetDefaultGrid(Me.dgdPending, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.lblHeaderInfo.Text = "Header: " & HeaderName & "  |  Customer: " & HeaderCustomer & "  |  Type: " & HeaderType
        LoadCombos()
        ClearInputFields()
    End Sub

    Private Sub InitPendingTable()
        oPendingDetails = New DataTable("PendingDetails")
        oPendingDetails.Columns.Add("itemid", GetType(String))
        oPendingDetails.Columns.Add("Item", GetType(String))
        oPendingDetails.Columns.Add("currency", GetType(String))
        oPendingDetails.Columns.Add("unit", GetType(String))
        oPendingDetails.Columns.Add("qty", GetType(String))
        oPendingDetails.Columns.Add("unitprice", GetType(Double))
        oPendingDetails.Columns.Add("totalamount", GetType(Double))
        oPendingDetails.Columns.Add("vat", GetType(Double))
        oPendingDetails.Columns.Add("unitprice_incvat", GetType(Double))
        oPendingDetails.Columns.Add("tigia", GetType(String))
        Me.dgdPending.DataSource = oPendingDetails
    End Sub

    Private Sub LoadCombos()
        Dim id As String = "charge_id"
        Dim value As String = "charge_code"
        Dim strSQL As String = "Select charge_id,charge_code + '/' + dvt  + '/' + charge as charge_code from charge where CONTINUED=1 Order by charge_code "
        loadDataToObject(Me.cboItem, strSQL, id, value)

        strSQL = "Select Currency from Currency"
        Dim tbl As DataSet = ReadDataSet(strSQL)
        Me.cboCurrency.Items.Clear()
        For i As Integer = 0 To tbl.Tables(0).Rows.Count - 1
            Me.cboCurrency.Items.Add(tbl.Tables(0).Rows(i).Item("Currency"))
        Next
        If Me.cboCurrency.Items.Count > 0 Then Me.cboCurrency.SelectedIndex = 0
    End Sub

    Private Sub CalcAmounts()
        Try
            Dim qty As Double = 0
            Dim unitPrice As Double = 0
            Dim vat As Double = 0
            Double.TryParse(Me.txtQty.Text, qty)
            Double.TryParse(Me.txtUnitPrice.Text, unitPrice)
            Double.TryParse(Me.txtVAT.Text, vat)
            Me.txtTotalAmount.Text = (qty * unitPrice).ToString()
            Me.txtUnitPriceIncVAT.Text = (unitPrice * (1 + vat / 100)).ToString()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ClearInputFields()
        Me.cboItem.Text = ""
        Me.txtUnit.Text = ""
        Me.txtQty.Text = ""
        Me.txtUnitPrice.Text = ""
        Me.txtTotalAmount.Text = ""
        Me.txtVAT.Text = ""
        Me.txtUnitPriceIncVAT.Text = ""
        Me.txtTigia.Text = ""
        If Me.cboCurrency.Items.Count > 0 Then Me.cboCurrency.SelectedIndex = 0
        Me.cboItem.Focus()
    End Sub

    Private Function ValidateInputRow() As Boolean
        If FindValueID(Me.cboItem, Me.cboItem.Text) = "" Then
            DisplayMessage(True, "Item ?")
            Me.cboItem.Focus()
            Return False
        End If
        If Me.cboCurrency.Text.Trim = "" Then
            DisplayMessage(True, "Currency ?")
            Return False
        End If
        Return True
    End Function

    Private Sub cmdAddRow_Click(sender As Object, e As EventArgs) Handles cmdAddRow.Click
        If Not ValidateInputRow() Then Exit Sub
        CalcAmounts()
        Dim row As DataRow = oPendingDetails.NewRow()
        row("itemid") = FindValueID(Me.cboItem, Me.cboItem.Text)
        row("Item") = Me.cboItem.Text
        row("currency") = Me.cboCurrency.Text
        row("unit") = Me.txtUnit.Text
        row("qty") = Me.txtQty.Text
        row("unitprice") = CDbl(Val(Me.txtUnitPrice.Text))
        row("totalamount") = CDbl(Val(Me.txtTotalAmount.Text))
        row("vat") = CDbl(Val(Me.txtVAT.Text))
        row("unitprice_incvat") = CDbl(Val(Me.txtUnitPriceIncVAT.Text))
        row("tigia") = Me.txtTigia.Text
        oPendingDetails.Rows.Add(row)
        ClearInputFields()
    End Sub

    Private Sub cmdRemoveRow_Click(sender As Object, e As EventArgs) Handles cmdRemoveRow.Click
        If Me.dgdPending.CurrentRow Is Nothing Then Exit Sub
        Dim idx As Integer = Me.dgdPending.CurrentRow.Index
        oPendingDetails.Rows.RemoveAt(idx)
    End Sub

    Private Sub cmdSaveAll_Click(sender As Object, e As EventArgs) Handles cmdSaveAll.Click
        On Error GoTo Err_Renamed
        If oPendingDetails.Rows.Count = 0 Then
            DisplayMessage(True, "No detail rows to save. Add at least one row.")
            Exit Sub
        End If
        Dim rs As New ADODB.Recordset
        Dim i As Integer
        For i = 0 To oPendingDetails.Rows.Count - 1
            rs.Open("SELECT TOP 1 * FROM Deatail_Tarif", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                .AddNew()
                .Fields("id").Value = NewId()
                .Fields("id_header").Value = getID(HeaderId)
                .Fields("itemid").Value = getID(oPendingDetails.Rows(i).Item("itemid").ToString())
                .Fields("currency").Value = oPendingDetails.Rows(i).Item("currency").ToString()
                .Fields("unit").Value = oPendingDetails.Rows(i).Item("unit").ToString()
                .Fields("qty").Value = oPendingDetails.Rows(i).Item("qty").ToString()
                .Fields("unitprice").Value = CDbl(oPendingDetails.Rows(i).Item("unitprice"))
                .Fields("totalamount").Value = CDbl(oPendingDetails.Rows(i).Item("totalamount"))
                .Fields("vat").Value = CDbl(oPendingDetails.Rows(i).Item("vat"))
                .Fields("unitprice_incvat").Value = CDbl(oPendingDetails.Rows(i).Item("unitprice_incvat"))
                .Fields("tigia").Value = oPendingDetails.Rows(i).Item("tigia").ToString()
                .Update()
            End With
            rs.Close()
        Next
        IsSaved = True
        Me.DialogResult = DialogResult.OK
        DisplayMessage(True, "Saved " & oPendingDetails.Rows.Count.ToString() & " detail(s). Ok!")
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        If oPendingDetails.Rows.Count > 0 Then
            If ConfirmMessage(True, "Close without saving pending details?") <> MsgBoxResult.Ok Then Exit Sub
        End If
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged, txtUnitPrice.TextChanged, txtVAT.TextChanged
        CalcAmounts()
    End Sub

    Private Sub dgdPending_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgdPending.DataBindingComplete
        Try
            If Me.dgdPending.Columns.Contains("itemid") Then Me.dgdPending.Columns("itemid").Visible = False
        Catch ex As Exception
        End Try
    End Sub

End Class
