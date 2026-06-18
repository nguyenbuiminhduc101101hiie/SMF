Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Globalization
Imports System.Windows.Forms
Public Class frmSpecialFreightTariffMarket

    Dim mStatus As String
    Dim mFreightTariffID As String = DefaultValue
    Dim MarketID As String = DefaultValue
    Dim mFreightStatus As String
    Dim mSpecialFreightID As String


    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strMesg As String = ""
        Dim strQuery, strQueryDetailBillofLadingList As String
        Dim blnEmpty As Boolean
        Dim Approve As Boolean
        Approve = Me.dgdData.Item("Approve", index).Value
        If Not UserRight("frmSpecialFreightTariff", "Delete") Or Approve Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete a record Of the market : " & Me.cboMarketCode.Text
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillofLadingList = "Select * from FreightTariffSpecial where SpecialFreightTariffID='" & Me.dgdData.Item("FreightTariffID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillofLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()
                rs.Requery()
                Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub






    Sub QueryData(Optional ByVal AgrMarketCode As String = "", Optional ByVal agr As String = "")
        Try
            Dim SQL As String

            SQL = "Select SpecialFreightTariffID as FreightTariffID,[Date],DateExp,MarketCode as MarketCode,POL,POD,TariffREF,DateREF,ApproveDate,ApproveBy,ApproveREF,Customer,Commodity,FreightTariffSpecial.UserID,FreightTariffSpecial.UpdateTime,FreightTariffSpecial.Approve"
            SQL &= " From (FreightTariffSpecial Inner JOIN Market On FreightTariffSpecial.Market_ID=Market.Market_ID)"
            SQL &= " Where FreightTariffSpecial.Continued=1 And Market.MarketCode='" & AgrMarketCode & "' order by FreightTariffSpecial.updatetime desc "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdData.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdData)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub SetText()
        Try
            If UCase(mStatus) = "NORMAL" Then
                Me.Text = "Freight Tariff"
            ElseIf UCase(mStatus) = "EDIT" Then
                Me.Text = Me.cboMarketCode.Text & " -> Edit"
            Else
                Me.Text = Me.cboMarketCode.Text & " -> Add"
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub OkClick()
        Try
            If UCase(mStatus) = "EDIT" Or UCase(mStatus) = "ADD" Then


                MarketID = Me.cboMarketCode.SelectedValue.ToString

                If MarketID = "" Then
                    MsgBox("The Market Not in Database , Please Check Again")
                    Return
                End If
                Dim rs As New ADODB.Recordset
                Dim strQuery As String
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM FreightTariffSpecial "
                strQuery = strQuery & "WHERE  SpecialFreightTariffID= '" & mFreightTariffID & "' AND  Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        .AddNew()
                        .Fields("SpecialFreightTariffID").Value = NewId()
                        .Fields("Market_ID").Value = "{" & MarketID & "}"
                    End If
                    mFreightTariffID = .Fields("SpecialFreightTariffID").Value.ToString
                    .Fields("DateExp").Value = Me.dtpDateExp.Value.Date
                    .Fields("Date").Value = Me.dtpDate.Value.Date
                    .Fields("TariffRef").Value = Me.txtTariffREF.text
                    .Fields("DateREF").Value = Me.dtpDateREF.Text
                    .Fields("ApproveBy").Value = Me.txtApproveBy.Text
                    .Fields("ApproveDate").Value = Me.dtpApproveDate.Text
                    .Fields("ApproveREF").Value = Me.txtApproveREF.text
                    .Fields("Customer").Value = Me.txtCustomer.text
                    .Fields("Commodity").Value = Me.txtCommodity.text

                    .Fields("POL").Value = Me.cboPOL.Text
                    .Fields("POD").Value = Me.cboPOD.Text

                    .Update()
                End With
                rs.Close()
                mStatus = "Normal"
                '
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub CancelClick()
        Try
            VisibleFraUpdate(False)
            QueryData(Me.cboMarketCode.Text)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Public Sub ApproveTariff(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer


        ' Xác định vị trí row trong grid
        If Me.dgddata.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgddata.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Or RowIndex < 0 Then
            Return
        End If
        If Me.dgdData.Columns(ColIndex).Name = "Approve" And Me.dgdData.CurrentCellAddress().Y = index Then
            Dim Approve As Boolean
            Dim rs As New ADODB.Recordset
            'Dim me.dgddata As DataGridView = Me.TabControl1.SelectedTab.Controls.Item("dgd " & Me.TabControl1.SelectedTab.Text)

            ' Xác định vị trí row trong grid
            'Dim index As Integer = me.dgddata.CurrentRow.Index
            Dim strQueryDetailBillOfLadingList As String
            If Not UserRight("frmSpecialFreightTariff", "Approve") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
            Else
                strQueryDetailBillOfLadingList = "Select Top 1 * from FreightTariffSpecial where SpecialFreighttariffID= '" & Me.dgdData.Item("FreightTariffID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                Approve = Not rs.Fields("Approve").Value
                rs.Update("Approve", Approve)
                rs.Close()
            End If
            QueryData(Me.cboMarketCode.Text)

        End If



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Sub ReforMat()
        Try

            Me.dgdData.Width = Me.Width - 20
            If Me.fraupdate.Visible = True Then
                Me.dgdData.Height = Me.Height - Me.fraupdate.Top - Me.cboMarketCode.Height - Me.MenuStrip1.Height - 10
            Else
                Me.dgdData.Height = Me.Height - Me.dgdData.Top - Me.cboMarketCode.Height - Me.MenuStrip1.Height - 20
            End If
            Me.cmdCancel.Top = Me.TabControl1.Bottom + 5
            Me.cmdOk.Top = Me.cmdCancel.Top
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub VisibleFraUpdate(ByVal Value As Boolean)
        Try
            Me.fraupdate.Visible = Value
            ReforMat()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem.Click
        Try
            If UserRight("frmFreightTariff", "Add") Then
                mFreightTariffID = DefaultValue
                QueryFreight()
                mStatus = "Add"
                Me.txtTariffREF.Text = ""
                Me.txtRate.Text = ""
                VisibleFraUpdate(True)
                ReforMat()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub



    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Sub ReFreshData(ByVal index As Integer)
        Try


            Me.dtpDateExp.Text = Me.dgdData.Item("DateExp", index).Value
            Me.dtpDate.Text = Me.dgdData.Item("ApplyDate", index).Value
            Me.txtTariffREF.Text = Me.dgdData.Item("TariffREF", index).Value
            Me.dtpDateREF.Text = Me.dgdData.Item("DateREF", index).Value

            Me.dtpApproveDate.Text = Me.dgdData.Item("ApproveDate", index).Value
            Me.txtApproveBy.Text = Me.dgdData.Item("ApproveBy", index).Value
            Me.txtApproveREF.Text = Me.dgdData.Item("ApproveREF", index).Value
            Me.txtCustomer.Text = Me.dgdData.Item("customer", index).Value
            Me.txtCommodity.Text = Me.dgdData.Item("Commodity", index).Value

            Me.cboPOL.Text = Me.dgdData.Item("POL", index).Value
            Me.cboPOD.Text = Me.dgdData.Item("POD", index).Value


            'Me.txt20GP.Text = Me.dgddata.Item("GP20", index).Value
            'Me.txt40GP.Text = Me.dgddata.Item("GP40", index).Value
            'Me.txt40HC.Text = Me.dgddata.Item("HC40", index).Value
            'Me.txt20RF.Text = Me.dgdData.Item("RF20", index).Value
            'Me.txt40RF.Text = Me.dgdData.Item("RF40", index).Value
            'Me.txt40RH.Text = Me.dgdData.Item("RF40", index).Value
            'Me.txt45HC.Text = Me.dgdData.Item("HC45", index).Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            If Me.dgdData.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgddata.CurrentRow.Index
            If index < 0 Then
                Return
            End If
            Dim Approve As Boolean
            Approve = Me.dgdData.Item("Approve", index).Value
            If UserRight("frmFreightTariff", "Edit") And Not Approve Then
                mFreightTariffID = Me.dgdData.Item("FreightTariffID", index).Value.ToString

                ReFreshData(index)
                mStatus = "Edit"
                VisibleFraUpdate(True)
                QueryFreight()
            Else
                MsgBox("Sorry, the proccess requires an access rigth to carry out.")
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub



    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try

            Dim selectedRowCount As Integer = _
                  Me.dgdData.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount >= 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdData.SelectedRows(i).Index)
                Next i
            End If
            QueryData(Me.cboMarketCode.Text)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            Dim strQuery As String
            gNameForm = "frmSpecialFreightTariff"
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            Dim mFilter As String
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryData(Me.cboMarketCode.Text, "  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub


    Private Sub dgddata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdData.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub frmSpecialFreightTariffMarket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Label2.Text = "Unit :"
            VisibleFraUpdate(False)
            visibleFreight(False)
            mFreightTariffID = DefaultValue
            mStatus = "Normal"
            mFreightStatus = "Normal"
            mSpecialFreightID = DefaultValue
            SetDefaultGrid(Me.dgdData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            QueryMarketCode()
            QueryPort()
            Querycbotype()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryMarketCode()
        Try
            Dim SQL As String
            SQL = "Select Distinct MarketCode,Market_ID from Market Where Continued=1 Order by MarketCode"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboMarketCode.DisplayMember = "MarketCode"
            Me.cboMarketCode.ValueMember = "Market_ID"
            Me.cboMarketCode.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub Querycbotype()
        Try
            Dim SQL As String
            SQL = "Select * from containertype Where Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboType.DisplayMember = "container_type"
            Me.cboType.ValueMember = "containertypeid"
            Me.cboType.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryPort()
        Try
            Dim SQL As String = "select Port_Code,Port_ID From Port Where Continued=1 Order By Port_Code"
            Dim dt As DataTable
            dt = ReadTable(SQL)
            Dim dtPOL, dtPOD As DataTable
            dtPOL = dt
            dtPOD = dt.Copy()
            Me.cboPOL.DisplayMember = "Port_code"
            Me.cboPOL.ValueMember = "Port_ID"
            Me.cboPOL.DataSource = dtPOL

            Me.cboPOD.DisplayMember = "Port_code"
            Me.cboPOD.ValueMember = "Port_ID"
            Me.cboPOD.DataSource = dtPOD
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cboMarketCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarketCode.SelectedIndexChanged
        QueryData(Me.cboMarketCode.Text)

    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        OkClick()
        'VisibleFraUpdate(False)
        QueryData(Me.cboMarketCode.Text)
        'Me.TabControl1.SelectedIndex = 1
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        CancelClick()
    End Sub
    Sub visibleFreight(ByVal Value As Boolean)
        Try
            Me.cboType.Enabled = Value
            Me.txtRate.Enabled = Value
            Me.cmdOkFreight.Enabled = Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub CargoctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoctmnuAdd.Click
        Try
            mFreightStatus = "Add"
            mSpecialFreightID = DefaultValue
            visibleFreight(True)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancelFreight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelFreight.Click
        Try
            mSpecialFreightID = DefaultValue
            mFreightStatus = "Normal"
            visibleFreight(False)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub RefreshFreight(ByVal Index As Integer)
        Try
            Me.cboType.Text = Me.dgdFreight.Item("ContainerType", Index).Value.ToString
            Me.txtRate.Text = Me.dgdFreight.Item("Rate", Index).Value
            Me.txtunit.Text = Me.dgdFreight.Item("Unit", Index).Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub CargoctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoctmnuEdit.Click
        Try
            If Me.dgdFreight.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdFreight.CurrentRow.Index
            mSpecialFreightID = Me.dgdFreight.Item("SpecialFreightID", index).Value.ToString
            mFreightStatus = "Edit"
            RefreshFreight(index)
            visibleFreight(True)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function CheckData()
        Try
            Dim SQL As String
            SQL = "select Count(*) from SpecialFreight Where Continued=1 And SpecialFreightTariffID='" & mFreightTariffID & "' And ContainerType='" & Me.cboType.Text.Trim & "'"
            Dim dt As DataTable
            dt = ReadTable(SQL)
            If dt.Rows(0).Item(0) > 0 And mFreightStatus = "Add" Then
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return False
        End Try
    End Function
    Sub QueryFreight(Optional ByVal arg As String = "")
        Try
            Dim SQL As String
            SQL = "Select * From SpecialFreight Where Continued=1 and SpecialFreightTariffID='" & mFreightTariffID & "' " & arg
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdFreight.DataSource = dt
            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Columns(i).ColumnName.ToUpper Like "*ID*" Or dt.Columns(i).ColumnName.ToUpper Like "*EDITABLE*" Or dt.Columns(i).ColumnName.ToUpper Like "*CONTINUED*" Then
                    Me.dgdFreight.Columns(i).Visible = False
                End If
            Next
            InsertAutoNumberToGrid(Me.dgdFreight)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOkFreight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkFreight.Click
        Try
            If CheckData() Then
                OkClick()
                mFreightTariffID = mFreightTariffID.Replace("{", "").Replace("}", "")
                Dim rs As New ADODB.Recordset
                Dim strQuery As String
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM SpecialFreight "
                strQuery = strQuery & "WHERE  SpecialFreightID= '" & mSpecialFreightID & "' AND  Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If .EOF Then
                        .AddNew()
                        .Fields("SpecialFreightID").Value = NewId()
                        .Fields("SpecialFreightTariffID").Value = "{" & mFreightTariffID & "}"
                    End If
                    .Fields("containerType").Value = Me.cboType.Text
                    .Fields("Rate").Value = Me.txtRate.Text
                    .Fields("Unit").Value = Me.txtunit.Text
                    .Update()
                End With
                rs.Close()
                mFreightStatus = "Normal"
                visibleFreight(False)
                QueryFreight()
            Else
                MsgBox("Data Error,Please Check data again")
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub ApproveFreight(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer


        ' Xác định vị trí row trong grid
        If Me.dgdFreight.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdFreight.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Or RowIndex < 0 Then
            Return
        End If
        If Me.dgdFreight.Columns(ColIndex).Name = "ApproveF" And Me.dgdFreight.CurrentCellAddress().Y = index Then
            Dim Approve As Boolean
            Dim rs As New ADODB.Recordset
            'Dim me.dgddata As DataGridView = Me.TabControl1.SelectedTab.Controls.Item("dgd " & Me.TabControl1.SelectedTab.Text)

            ' Xác định vị trí row trong grid
            'Dim index As Integer = me.dgddata.CurrentRow.Index
            Dim strQueryDetailBillOfLadingList As String
            If Not UserRight("frmSpecialFreightTariff", "Approve") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
            Else
                strQueryDetailBillOfLadingList = "Select Top 1 * from SpecialFreight where SpecialFreightID= '" & Me.dgdFreight.Item("SpecialFreightID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                Approve = Not rs.Fields("Approve").Value
                rs.Update("Approve", Approve)
                rs.Close()
            End If
        End If
        QueryFreight()



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowFreight(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strMesg As String = ""
        Dim strQuery, strQueryDetailBillofLadingList As String
        Dim blnEmpty As Boolean
        Dim Approve As Boolean
        Approve = Me.dgdFreight.Item("ApproveF", index).Value
        If Not UserRight("frmSpecialFreightTariff", "Delete") Or Approve Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete a record Of the market : " & Me.cboMarketCode.Text
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillofLadingList = "Select * from SpecialFreight where SpecialFreightID='" & Me.dgdFreight.Item("SpecialFreightID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillofLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()
                rs.Requery()
                Me.dgdFreight.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdFreight.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub DeleteFreight()
        Try

            Dim selectedRowCount As Integer = _
                  Me.dgdFreight.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount >= 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRowFreight(Me.dgdFreight.SelectedRows(i).Index)
                Next i
            End If
            QueryFreight()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

    Private Sub dgdFreight_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdFreight.CellContentClick
        ApproveFreight(e)
    End Sub

    Private Sub dgdFreight_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdFreight.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdFreight)
    End Sub

    Private Sub CargoctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoctmnuDel.Click
        DeleteFreight()
    End Sub
End Class