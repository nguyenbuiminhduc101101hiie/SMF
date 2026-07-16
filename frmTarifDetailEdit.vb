Option Strict Off
Option Explicit On
Imports System.Windows.Forms

Partial Public Class frmTarifDetailEdit
    Inherits Form

    Public DetailId As String
    Public IsSaved As Boolean = False
    Private mHeaderId As String

    Public Sub New(ByVal detailId As String, ByVal headerId As String)
        InitializeComponent()
        Me.DetailId = detailId
        mHeaderId = headerId
    End Sub

    Private Sub frmTarifDetailEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCombos()
        LoadDetail()
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
    End Sub

    Private Sub LoadDetail()
        Dim strSQL As String = "Select d.*, ch.charge_code + '/' + ch.dvt + '/' + ch.charge as ItemName " &
            "From Deatail_Tarif d Left Join charge ch on d.itemid = ch.charge_id Where d.id = '" & DetailId & "'"
        Dim dt As DataTable = ReadTable(strSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        Me.cboItem.Text = dt.Rows(0).Item("ItemName").ToString()
        Me.cboCurrency.Text = dt.Rows(0).Item("currency").ToString()
        Me.txtUnit.Text = dt.Rows(0).Item("unit").ToString()
        Me.txtQty.Text = dt.Rows(0).Item("qty").ToString()
        Me.txtUnitPrice.Text = dt.Rows(0).Item("unitprice").ToString()
        Me.txtTotalAmount.Text = dt.Rows(0).Item("totalamount").ToString()
        Me.txtVAT.Text = dt.Rows(0).Item("vat").ToString()
        Me.txtUnitPriceIncVAT.Text = dt.Rows(0).Item("unitprice_incvat").ToString()
        Me.txtTigia.Text = dt.Rows(0).Item("tigia").ToString()
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

    Private Function ValidateData() As Boolean
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

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        On Error GoTo Err_Renamed
        If Not ValidateData() Then Exit Sub
        CalcAmounts()
        Dim rs As New ADODB.Recordset
        rs.Open("SELECT * FROM Deatail_Tarif WHERE id = '" & DetailId & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            rs.Close()
            DisplayMessage(True, "Detail not found.")
            Exit Sub
        End If
        With rs
            .Fields("id_header").Value = getID(mHeaderId)
            .Fields("itemid").Value = getID(FindValueID(Me.cboItem, Me.cboItem.Text))
            .Fields("currency").Value = Trim(Me.cboCurrency.Text)
            .Fields("unit").Value = Trim(Me.txtUnit.Text)
            .Fields("qty").Value = Trim(Me.txtQty.Text)
            .Fields("unitprice").Value = CDbl(Val(Me.txtUnitPrice.Text))
            .Fields("totalamount").Value = CDbl(Val(Me.txtTotalAmount.Text))
            .Fields("vat").Value = CDbl(Val(Me.txtVAT.Text))
            .Fields("unitprice_incvat").Value = CDbl(Val(Me.txtUnitPriceIncVAT.Text))
            .Fields("tigia").Value = Trim(Me.txtTigia.Text)
            .Update()
        End With
        rs.Close()
        IsSaved = True
        Me.DialogResult = DialogResult.OK
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged, txtUnitPrice.TextChanged, txtVAT.TextChanged
        CalcAmounts()
    End Sub

End Class
