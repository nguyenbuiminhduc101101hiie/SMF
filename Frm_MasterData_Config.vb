Option Strict Off
Option Explicit On

Public Class Frm_MasterData_Config
    Private allColumns As List(Of MasterDataColumnInfo)
    Private selectedKeys As New List(Of String)

    Private Sub Frm_MasterData_Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureTemplateHeadersLoaded()
        allColumns = GetAllColumnDefinitions()
        selectedKeys = LoadUserColumnKeys()
        RefreshLists()
    End Sub

    Private Sub RefreshLists()
        lstSelected.Items.Clear()
        lstAvailable.Items.Clear()

        For Each key As String In selectedKeys
            lstSelected.Items.Add(New ColumnListItem(key, GetColumnDisplayName(key)))
        Next

        For Each col As MasterDataColumnInfo In allColumns
            If Not selectedKeys.Contains(col.Key) Then
                lstAvailable.Items.Add(New ColumnListItem(col.Key, GetColumnDisplayName(col.Key)))
            End If
        Next
    End Sub

    Private Function GetSelectedKeysFromList() As List(Of String)
        Dim keys As New List(Of String)
        For Each item As ColumnListItem In lstSelected.Items
            keys.Add(item.Key)
        Next
        Return keys
    End Function

    Private Sub MoveItems(fromList As ListBox, toList As ListBox)
        Dim itemsToMove As New List(Of ColumnListItem)
        For Each item As ColumnListItem In fromList.SelectedItems
            itemsToMove.Add(item)
        Next

        For Each item As ColumnListItem In itemsToMove
            fromList.Items.Remove(item)
            toList.Items.Add(item)
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        MoveItems(lstAvailable, lstSelected)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        MoveItems(lstSelected, lstAvailable)
    End Sub

    Private Sub btnAddAll_Click(sender As Object, e As EventArgs) Handles btnAddAll.Click
        lstAvailable.SelectedIndices.Clear()
        For i As Integer = 0 To lstAvailable.Items.Count - 1
            lstAvailable.SetSelected(i, True)
        Next
        MoveItems(lstAvailable, lstSelected)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        selectedKeys = GetDefaultColumnKeys()
        RefreshLists()
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        Dim index = lstSelected.SelectedIndex
        If index <= 0 Then
            Return
        End If

        Dim item = lstSelected.Items(index)
        lstSelected.Items.RemoveAt(index)
        lstSelected.Items.Insert(index - 1, item)
        lstSelected.SelectedIndex = index - 1
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        Dim index = lstSelected.SelectedIndex
        If index < 0 OrElse index >= lstSelected.Items.Count - 1 Then
            Return
        End If

        Dim item = lstSelected.Items(index)
        lstSelected.Items.RemoveAt(index)
        lstSelected.Items.Insert(index + 1, item)
        lstSelected.SelectedIndex = index + 1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim keys = GetSelectedKeysFromList()
        If keys.Count = 0 Then
            MessageBox.Show("Vui lòng chọn ít nhất một cột để export.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SaveUserColumnKeys(keys)
        MessageBox.Show("Đã lưu thiết lập cột theo tài khoản của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Class ColumnListItem
        Public Property Key As String
        Public Property DisplayName As String

        Public Sub New(key As String, displayName As String)
            Me.Key = key
            Me.DisplayName = displayName
        End Sub

        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class
End Class
