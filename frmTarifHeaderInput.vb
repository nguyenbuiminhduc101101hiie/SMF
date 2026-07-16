Option Strict Off
Option Explicit On
Imports System.Windows.Forms

Partial Public Class frmTarifHeaderInput
    Inherits Form

    Public HeaderId As String = DefaultValue
    Public IsSaved As Boolean = False
    Private mIsEdit As Boolean = False

    Public Sub New(Optional ByVal editMode As Boolean = False, Optional ByVal headerId As String = "")
        InitializeComponent()
        mIsEdit = editMode
        HeaderId = headerId
    End Sub

    Private Sub frmTarifHeaderInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cboType.Items.Clear()
        Me.cboType.Items.Add("Debit")
        Me.cboType.Items.Add("Credit")
        Me.cboType.DropDownStyle = ComboBoxStyle.DropDownList
        Me.dtpDate.Value = Today
        Me.txtUserCreate.Text = strUserId
        SearchCustomers()
        If mIsEdit And HeaderId <> "" And HeaderId <> DefaultValue Then
            Me.Text = "Edit Tarif Header"
            lblTitle.Text = "Edit Tarif Header"
            LoadHeader()
        Else
            Me.Text = "New Tarif Header"
            lblTitle.Text = "New Tarif Header"
            HeaderId = DefaultValue
            If Me.cboType.Items.Count > 0 Then Me.cboType.SelectedIndex = 0
        End If
    End Sub

    Private Sub SearchCustomers()
        Try
            Dim id As String = "customer_id"
            Dim value As String = "company"
            Dim keyword As String = Me.txtfindCustomer.Text.Trim().Replace("'", "''")
            Dim strSQL As String = "Select customer_id,shortname as company From customer where continued=1 "
            If keyword <> "" Then
                strSQL &= "and (company like '%" & keyword & "%' or taxcode like '%" & keyword & "%' or shortname like '%" & keyword & "%') "
            End If
            strSQL &= "order by company "
            loadDataToObject(Me.cboCustomer, strSQL, id, value)
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Sub cmdFindCustomer_Click(sender As Object, e As EventArgs) Handles cmdFindCustomer.Click
        SearchCustomers()
    End Sub

    Private Sub txtfindCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfindCustomer.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchCustomers()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub LoadHeader()
        Dim strSQL As String = "Select h.*, c.shortname as CustomerName From Header_Tarif h " &
            "Left Join customer c on h.customer_id = c.customer_id Where h.id = '" & HeaderId & "'"
        Dim dt As DataTable = ReadTable(strSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        Me.txtName.Text = dt.Rows(0).Item("Name").ToString()
        Me.txtfindCustomer.Text = dt.Rows(0).Item("CustomerName").ToString()
        SearchCustomers()
        Me.cboCustomer.Text = dt.Rows(0).Item("CustomerName").ToString()
        Me.cboType.Text = dt.Rows(0).Item("Type").ToString()
        If Not IsDBNull(dt.Rows(0).Item("date")) Then
            Me.dtpDate.Value = CDate(dt.Rows(0).Item("date"))
        End If
        Me.txtUserCreate.Text = dt.Rows(0).Item("usercreate").ToString()
    End Sub

    Private Function ValidateData() As Boolean
        If Me.txtName.Text.Trim = "" Then
            DisplayMessage(True, "Name ?")
            Me.txtName.Focus()
            Return False
        End If
        If IsDuplicateName() Then
            DisplayMessage(True, "Name already exists.")
            Me.txtName.Focus()
            Return False
        End If
        If FindValueID(Me.cboCustomer, Me.cboCustomer.Text) = "" Then
            DisplayMessage(True, "Customer ?")
            Me.cboCustomer.Focus()
            Return False
        End If
        If Me.cboType.Text = "" Then
            DisplayMessage(True, "Type ?")
            Return False
        End If
        Return True
    End Function

    Private Function IsDuplicateName() As Boolean
        Try
            Dim name As String = Me.txtName.Text.Trim().Replace("'", "''")
            Dim strSQL As String = "Select Count(*) as Cnt From Header_Tarif Where Name = '" & name & "'"
            If mIsEdit And HeaderId <> "" And HeaderId <> DefaultValue Then
                strSQL &= " And id <> '" & HeaderId & "'"
            End If
            Dim dt As DataTable = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Return CInt(dt.Rows(0).Item("Cnt")) > 0
            End If
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
        Return False
    End Function

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        On Error GoTo Err_Renamed
        If Not ValidateData() Then Exit Sub
        Dim rs As New ADODB.Recordset
        Dim strQuery As String = "SELECT * FROM Header_Tarif WHERE id = '" & HeaderId & "' AND id <> '" & DefaultValue & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        With rs
            If rs.EOF Then
                .AddNew()
                HeaderId = NewId()
                .Fields("id").Value = HeaderId
                .Fields("usercreate").Value = strUserId
            End If
            .Fields("Name").Value = Trim(Me.txtName.Text)
            .Fields("customer_id").Value = getID(FindValueID(Me.cboCustomer, Me.cboCustomer.Text))
            .Fields("date").Value = Me.dtpDate.Value.Date
            .Fields("Type").Value = Trim(Me.cboType.Text)
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

End Class
