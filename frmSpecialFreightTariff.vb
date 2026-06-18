
Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Globalization

Imports System.Windows.Forms
Public Class frmSpecialFreightTariff
    Dim mStatus As String
    Dim mFreightTariffID As String = DefaultValue
    Dim MarketID As String = DefaultValue
    Dim dtpDate, txtPOl, txtPOD, txt20GP, txt40GP, txt40HC, txt45HC, txt20RF, txt40RF, txt40RH As String
    Function FindMarketID(ByVal MarketCode As String) As String
        Try
            Dim SQL As String
            SQL = "select Market_ID From market Where marketCode='" & MarketCode & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return "{" & dt.Rows(0).Item(0).ToString & "}"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub QueryData(Optional ByVal AgrMarketCode As String = "", Optional ByVal agr As String = "")
        Try
            Dim SQL As String
            Dim dgd As DataGridView
            SQL = "Select SpecialFreightTariffID as FreightTariffID,[Date],DateExp,MarketCode as MarketCode,POL,POD,TariffREF,DateREF,ApproveDate,ApproveBy,ApproveREF,Customer,Commodity,GP20,GP40,HC40,HC45,RF20,RF40,RH40, FreightTariffSpecial.UserID,FreightTariffSpecial.UpdateTime,FreightTariffSpecial.Approve"
            SQL &= " From (FreightTariffSpecial Inner JOIN Market On FreightTariffSpecial.Market_ID=Market.Market_ID)"
            SQL &= " Where FreightTariffSpecial.Continued=1 And Market.MarketCode='" & AgrMarketCode & "' "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Dim dgdView As New DataGridView
            dgdView = Me.TabControl1.TabPages("Tab" & AgrMarketCode).Controls.Item("dgd" & AgrMarketCode)

            dgdView.DataSource = dt


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub SetText()
        Try
            If UCase(mStatus) = "NORMAL" Then
                Me.Text = "Freight Tariff"
            ElseIf UCase(mStatus) = "EDIT" Then
                Me.Text = Me.TabControl1.SelectedTab.Text & " -> Edit"
            Else
                Me.Text = Me.TabControl1.SelectedTab.Text & " -> Add"
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub OkClick()
        Try
            If UCase(mStatus) = "EDIT" Or UCase(mStatus) = "ADD" Then

                Dim CurrentTab As TabPage = Me.TabControl1.SelectedTab
                Dim marketCode As String = CurrentTab.Text
                Dim Grp As GroupBox
                Grp = CurrentTab.Controls.Item(marketCode & "FraUpdate")
                MarketID = FindMarketID(Me.TabControl1.SelectedTab.Text)
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
                        .Fields("Market_ID").Value = MarketID
                    End If
                    .Fields("DateExp").Value = CDate(Grp.Controls.Item(marketCode & "dtpDateExp").Text)
                    .Fields("Date").Value = CDate(Grp.Controls.Item(marketCode & "dtpDate").Text)
                    .Fields("TariffRef").Value = Grp.Controls.Item(marketCode & "txtTariffREF").Text
                    .Fields("DateREF").Value = CDate(Grp.Controls.Item(marketCode & "dtpDateREF").Text)
                    .Fields("ApproveBy").Value = Grp.Controls.Item(marketCode & "txtApproveBy").Text
                    .Fields("ApproveDate").Value = CDate(Grp.Controls.Item(marketCode & "dtpapproveDate").Text)
                    .Fields("ApproveREF").Value = Grp.Controls.Item(marketCode & "txtApproveREF").Text
                    .Fields("Customer").Value = Grp.Controls.Item(marketCode & "txtCustomer").Text
                    .Fields("Commodity").Value = Grp.Controls.Item(marketCode & "txtCommodity").Text

                    .Fields("POL").Value = Grp.Controls.Item(marketCode & "txtPOL").Text
                    .Fields("POD").Value = Grp.Controls.Item(marketCode & "txtPOD").Text

                    Dim grpTariff As GroupBox
                    grpTariff = Grp.Controls.Item("grp" & marketCode & "Tariff")
                    .Fields("GP20").Value = grpTariff.Controls.Item(marketCode & "txt20GP").Text
                    .Fields("GP40").Value = grpTariff.Controls.Item(marketCode & "txt40GP").Text
                    .Fields("HC40").Value = grpTariff.Controls.Item(marketCode & "txt40HC").Text
                    .Fields("HC45").Value = grpTariff.Controls.Item(marketCode & "txt45HC").Text
                    .Fields("RF20").Value = grpTariff.Controls.Item(marketCode & "txt20RF").Text
                    .Fields("RF40").Value = grpTariff.Controls.Item(marketCode & "txt40RF").Text
                    .Fields("RH40").Value = grpTariff.Controls.Item(marketCode & "txt40RH").Text
                    .Update()
                End With
                rs.Close()
                mStatus = "Normal"
                VisibleFraUpdate(False)
                QueryDataAllGrid()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub CancelClick()
        Try
            VisibleAllFraUpdate(False)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Public Sub ApproveTariff(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        Dim Tempdgd As DataGridView = Me.TabControl1.SelectedTab.Controls.Item("dgd" & Me.TabControl1.SelectedTab.Text)

        ' Xác định vị trí row trong grid
        If Tempdgd.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Tempdgd.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Or RowIndex < 0 Then
            Return
        End If
        If Tempdgd.Columns(ColIndex).Name = Me.TabControl1.SelectedTab.Text & "Approve" And Tempdgd.CurrentCellAddress().Y = index Then
            Dim Approve As Boolean
            Dim rs As New ADODB.Recordset
            'Dim Tempdgd As DataGridView = Me.TabControl1.SelectedTab.Controls.Item("dgd " & Me.TabControl1.SelectedTab.Text)

            ' Xác định vị trí row trong grid
            'Dim index As Integer = Tempdgd.CurrentRow.Index
            Dim strQueryDetailBillOfLadingList As String
            If Not UserRight("frmSpecialFreightTariff", "Approve") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
            Else
                strQueryDetailBillOfLadingList = "Select Top 1 * from FreightTariffSpecial where SpecialFreighttariffID= '" & Tempdgd.Item(Me.TabControl1.SelectedTab.Text & "FreightTariffID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                Approve = Not rs.Fields("Approve").Value
                rs.Update("Approve", Approve)
                rs.Close()
            End If
        End If
        QueryData(Me.TabControl1.SelectedTab.Text)



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Sub VisibleFraUpdate(ByVal Value As Boolean)
        Try
            Dim grp As GroupBox
            Dim TemptabPage As TabPage
            TemptabPage = Me.TabControl1.SelectedTab
            grp = TemptabPage.Controls.Item(TemptabPage.Text & "Fraupdate")
            grp.Visible = Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub ReforMat()
        Try

            Dim CurrentTab As TabPage = Me.TabControl1.SelectedTab
            Dim TempDGD As DataGridView = CurrentTab.Controls.Item("dgd" & CurrentTab.Text)
            Dim Grp As GroupBox = CurrentTab.Controls(CurrentTab.Text & "Fraupdate")
            If Grp.Visible = True Then
                TempDGD.Dock = DockStyle.Top
            Else
                TempDGD.Dock = DockStyle.Fill
            End If


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub VisibleAllFraUpdate(ByVal Value As Boolean)
        Try
            For Each ctr As TabPage In Me.TabControl1.TabPages
                Dim Grp As GroupBox
                Grp = ctr.Controls.Item(ctr.Text & "FRAUPDATE")
                Grp.Visible = Value
                Dim TempTextBox As TextBox
                TempTextBox = Grp.Controls.Item(ctr.Text & "txtMarketCode")
                TempTextBox.Text = ctr.Text
            Next
            ReforMat()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryDataAllGrid() 'query dữ liệu cho toàn bộ lứơi 
        Try
            For Each ctr As TabPage In Me.TabControl1.TabPages
                Dim MarketCode As String = ctr.Text

                QueryData(MarketCode)

            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem.Click
        Try
            If UserRight("frmFreightTariff", "Add") Then
                mFreightTariffID = DefaultValue
                mStatus = "Add"
                VisibleFraUpdate(True)
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmFreightTarrif_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            QueryDataAllGrid()
            VisibleAllFraUpdate(False)

            mFreightTariffID = DefaultValue
            mStatus = "Normal"
            SetDefaultGrid(Me.dgdAFR, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdAUS, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdCAN, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdCHI, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdEUR, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdHKG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

            SetDefaultGrid(Me.dgdIND, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdITA, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

            SetDefaultGrid(Me.dgdMED, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdMID, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdSEA, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdSCA, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdEUS, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            SetDefaultGrid(Me.dgdWUS, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            '------


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            VisibleAllFraUpdate(False)
            mFreightTariffID = DefaultValue
            MarketID = FindMarketID(Me.TabControl1.SelectedTab.Text)
            mStatus = "Normal"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

#Region "cmdOk,And Cancel Click"

    Private Sub cmdWUSCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWUSCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdWUSOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWUSOk.Click
        OkClick()
    End Sub
    Private Sub cmdEUSCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEUSCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdEUSOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEUSOk.Click
        OkClick()
    End Sub
    Private Sub cmdSCACancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSCACancel.Click
        CancelClick()
    End Sub

    Private Sub cmdSCAOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSCAOk.Click
        OkClick()
    End Sub
    Private Sub cmdSEACancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSEACancel.Click
        CancelClick()
    End Sub

    Private Sub cmdSEAOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSEAOk.Click
        OkClick()
    End Sub

    Private Sub cmdMIDCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMIDCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdMIDOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMIDOk.Click
        OkClick()
    End Sub

    Private Sub cmdITACancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdITACancel.Click
        CancelClick()
    End Sub

    Private Sub cmdITAOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdITAOk.Click
        OkClick()
    End Sub
    Private Sub cmdINDCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdINDCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdINDOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdINDOk.Click
        OkClick()
    End Sub

    Private Sub cmdCANCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANCancel.Click
        CancelClick()
    End Sub


    Private Sub cmdCANOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCANOk.Click
        OkClick()
    End Sub
    Private Sub cmdAUSCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAUSCancel.Click
        CancelClick()
    End Sub


    Private Sub cmdAUSOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAUSOk.Click
        OkClick()
    End Sub
    Private Sub cmdCHICancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCHICancel.Click
        CancelClick()
    End Sub

    Private Sub cmdCHIOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCHIOk.Click
        OkClick()
    End Sub

    Private Sub cmdHKGCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHKGCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdHKGOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHKGOk.Click
        OkClick()
    End Sub

#End Region


    Sub ReFreshData(ByVal index As Integer)
        Try
            Dim CurrentTab As TabPage
            CurrentTab = Me.TabControl1.SelectedTab
            Dim MarketCode As String = CurrentTab.Text

            Dim Tempdgd As DataGridView = CurrentTab.Controls.Item("dgd" & CurrentTab.Text)
            Dim Grp As GroupBox
            Grp = CurrentTab.Controls.Item(MarketCode & "fraupdate")
            Grp.Controls.Item(MarketCode & "dtpDateExp").Text = Tempdgd.Item(MarketCode & "DateExp", index).Value
            Grp.Controls.Item(MarketCode & "dtpDate").Text = Tempdgd.Item(MarketCode & "Date", index).Value
            Grp.Controls.Item(MarketCode & "txtTariffREF").Text = Tempdgd.Item(MarketCode & "TariffREF", index).Value
            Grp.Controls.Item(MarketCode & "dtpDateREF").Text = Tempdgd.Item(MarketCode & "DateREF", index).Value

            Grp.Controls.Item(MarketCode & "dtpApproveDate").Text = Tempdgd.Item(MarketCode & "ApproveDate", index).Value
            Grp.Controls.Item(MarketCode & "txtApproveBy").Text = Tempdgd.Item(MarketCode & "ApproveBy", index).Value
            Grp.Controls.Item(MarketCode & "txtApproveREF").Text = Tempdgd.Item(MarketCode & "ApproveREF", index).Value
            Grp.Controls.Item(MarketCode & "txtCustomer").Text = Tempdgd.Item(MarketCode & "customer", index).Value
            Grp.Controls.Item(MarketCode & "txtCommodity").Text = Tempdgd.Item(MarketCode & "Commodity", index).Value

            Grp.Controls.Item(MarketCode & "txtPOL").Text = Tempdgd.Item(MarketCode & "POL", index).Value
            Grp.Controls.Item(MarketCode & "txtPOD").Text = Tempdgd.Item(MarketCode & "POD", index).Value

            Dim TempGrp As GroupBox
            TempGrp = Grp.Controls("grp" & MarketCode & "Tariff")
            TempGrp.Controls.Item(MarketCode & "txt20GP").Text = Tempdgd.Item(MarketCode & "GP20", index).Value
            TempGrp.Controls.Item(MarketCode & "txt40GP").Text = Tempdgd.Item(MarketCode & "GP40", index).Value
            TempGrp.Controls.Item(MarketCode & "txt40HC").Text = Tempdgd.Item(MarketCode & "HC40", index).Value
            TempGrp.Controls.Item(MarketCode & "txt20RF").Text = Tempdgd.Item(MarketCode & "RF20", index).Value
            TempGrp.Controls.Item(MarketCode & "txt40RF").Text = Tempdgd.Item(MarketCode & "RF40", index).Value
            TempGrp.Controls.Item(MarketCode & "txt40RH").Text = Tempdgd.Item(MarketCode & "RF40", index).Value
            TempGrp.Controls.Item(MarketCode & "txt45HC").Text = Tempdgd.Item(MarketCode & "HC45", index).Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim Tempdgd As DataGridView
            Dim MarketCode As String
            MarketCode = Me.TabControl1.SelectedTab.Text
            Tempdgd = Me.TabControl1.SelectedTab.Controls.Item("dgd" & MarketCode)
            If Tempdgd.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Tempdgd.CurrentRow.Index
            If index < 0 Then
                Return
            End If
            Dim Approve As Boolean
            Approve = Tempdgd.Item(MarketCode & "Approve", index).Value
            If UserRight("frmFreightTariff", "Edit") And Not Approve Then
                mFreightTariffID = Tempdgd.Item(MarketCode & "FreightTariffID", index).Value.ToString
                MarketID = FindMarketID(MarketCode)
                ReFreshData(index)
                mStatus = "Edit"
                VisibleFraUpdate(True)
            Else
                MsgBox("Sorry, the proccess requires an access rigth to carry out.")
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strMesg As String = ""
        Dim strQuery, strQueryDetailBillofLadingList As String
        Dim blnEmpty As Boolean

        Dim CurrentTab As TabPage = Me.TabControl1.SelectedTab
        Dim MarketCode As String = CurrentTab.Text
        Dim Tempdgd As DataGridView
        Tempdgd = CurrentTab.Controls.Item("dgd" & MarketCode)
        Dim Approve As Boolean = Tempdgd.Item(MarketCode & "Approve", index).Value
        If Not UserRight("frmSpecialFreightTariff", "Delete") Or Approve Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete a record Of the market : " & Tempdgd.Item(MarketCode & "MarketCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillofLadingList = "Select * from FreightTariffSpecial where SpecialFreightTariffID='" & Tempdgd.Item(MarketCode & "FreightTariffID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillofLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()
                rs.Requery()
                Tempdgd.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Tempdgd.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim Currenttab As TabPage = Me.TabControl1.SelectedTab
            Dim MarketCode As String = Currenttab.Text
            Dim Tempdgd As DataGridView = Currenttab.Controls.Item("dgd" & MarketCode)


            Dim selectedRowCount As Integer = _
                  Tempdgd.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount >= 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Tempdgd.SelectedRows(i).Index)
                Next i
            End If
            QueryData(Currenttab.Text)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub



    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            Dim mFilter As String
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryData(Me.TabControl1.SelectedTab.Text, "  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
#Region "Approve"

    Private Sub dgdEUR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdEUR.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdEUS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdEUS.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdAFR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdAFR.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdIND_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdIND.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdMED_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdMED.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdSEA_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSEA.CellContentClick
        ApproveTariff(e)
    End Sub


    Private Sub dgdCHI_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCHI.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdMID_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdMID.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdAUS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdAUS.CellContentClick
        ApproveTariff(e)
    End Sub


    Private Sub dgdCAN_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCAN.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdWUS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdWUS.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdHKG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdHKG.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdITA_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdITA.CellContentClick
        ApproveTariff(e)
    End Sub

    Private Sub dgdSCA_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSCA.CellContentClick
        ApproveTariff(e)
    End Sub
#End Region





    Private Sub AFRExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AFRExportEXCEL.Click
        Try
            If Me.dgdAFR.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdAFR, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub AUSExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUSExportEXCEL.Click
        Try
            If Me.dgdAUS.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdAUS, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub CANExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANExportEXCEL.Click
        Try
            If Me.dgdCAN.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdCAN, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub CHIExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHIExportEXCEL.Click
        Try
            If Me.dgdCHI.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdCHI, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ExportEXCELToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportEXCELToolStripMenuItem.Click
        Try
            If Me.dgdEUR.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdEUR, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub HKGExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HKGExportEXCEL.Click
        Try
            If Me.dgdHKG.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdHKG, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub INDExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INDExportEXCEL.Click
        Try
            If Me.dgdIND.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdIND, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub ITAExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITAExportEXCEL.Click
        Try
            If Me.dgdITA.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdITA, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub MEDExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDExportEXCEL.Click
        Try
            If Me.dgdMED.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdMED, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub MIDExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDExportEXCEL.Click
        Try
            If Me.dgdMID.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdMID, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub SEAExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEAExportEXCEL.Click
        Try
            If Me.dgdSEA.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdSEA, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub SCAExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCAExportEXCEL.Click
        Try
            If Me.dgdSCA.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdSCA, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub EUSExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EUSExportEXCEL.Click
        Try
            If Me.dgdEUS.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdEUS, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub WUSExportEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WUSExportEXCEL.Click
        Try
            If Me.dgdWUS.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdWUS, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

#Region "TSCode text Leave"

    Sub Check(ByVal TSCode As TextBox)
        Try
            If CheckTSCode(TSCode.Text) = False Then
                MsgBox("The Port :" & TSCode.Text & " not in database, please check again")
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub WUStxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WUStxtPOL.Leave
        Check(Me.WUStxtPOL)
    End Sub

    Private Sub WUStxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WUStxtPOD.Leave
        Check(WUStxtPOD)
    End Sub
    Private Sub EUStxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EUStxtPOL.Leave
        Check(Me.EUStxtPOL)

    End Sub

    Private Sub EUStxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EUStxtPOD.Leave
        Check(EUStxtPOD)
    End Sub

    Private Sub SCAtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCAtxtPOL.Leave
        Check(Me.SCAtxtPOL)

    End Sub

    Private Sub SCAtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCAtxtPOD.Leave
        Check(SCAtxtPOD)
    End Sub

    Private Sub SEAtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEAtxtPOL.Leave
        Check(Me.SEAtxtPOL)

    End Sub

    Private Sub SEAtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEAtxtPOD.Leave
        Check(SEAtxtPOD)
    End Sub
    Private Sub MIDtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDtxtPOL.Leave
        Check(Me.MIDtxtPOL)

    End Sub

    Private Sub MIDtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MIDtxtPOD.Leave
        Check(MIDtxtPOD)
    End Sub

    Private Sub MEDtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDtxtPOL.Leave
        Check(Me.MEDtxtPOL)

    End Sub

    Private Sub MEDtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDtxtPOD.Leave
        Check(MEDtxtPOD)
    End Sub

    Private Sub ITAtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITAtxtPOL.Leave
        Check(Me.ITAtxtPOL)

    End Sub

    Private Sub ITAtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITAtxtPOD.Leave
        Check(ITAtxtPOD)
    End Sub

    Private Sub INDtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INDtxtPOL.Leave
        Check(Me.INDtxtPOL)

    End Sub

    Private Sub INDtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INDtxtPOD.Leave
        Check(INDtxtPOD)
    End Sub

    Private Sub AUStxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUStxtPOL.Leave
        Check(Me.AUStxtPOL)

    End Sub

    Private Sub AUStxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AUStxtPOD.Leave
        Check(AUStxtPOD)
    End Sub

    Private Sub CANtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANtxtPOL.Leave
        Check(Me.CANtxtPOL)

    End Sub

    Private Sub CANtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CANtxtPOD.Leave
        Check(CANtxtPOD)
    End Sub

    Private Sub CHItxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHItxtPOL.Leave
        Check(Me.CHItxtPOL)

    End Sub
    Private Sub EURtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURtxtPOL.Leave
        Check(Me.EURtxtPOL)

    End Sub

    Private Sub EURtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EURtxtPOD.Leave
        Check(EURtxtPOD)
    End Sub

    Private Sub CHItxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHItxtPOD.Leave
        Check(CHItxtPOD)
    End Sub

    Private Sub HKGtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HKGtxtPOL.Leave
        Check(Me.HKGtxtPOL)

    End Sub

    Private Sub HKGtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HKGtxtPOD.Leave
        Check(HKGtxtPOD)
    End Sub


    Private Sub AFRtxtPOL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AFRtxtPOL.Leave
        Check(Me.AFRtxtPOL)
    End Sub

    Private Sub AFRtxtPOD_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AFRtxtPOD.Leave
        Check(AFRtxtPOD)
    End Sub

#End Region

    Private Sub cmdAFROk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAFROk.Click
        OkClick()
    End Sub

    Private Sub cmdAFRCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAFRCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdEUROk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEUROk.Click
        OkClick()
    End Sub

    Private Sub cmdEURCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEURCancel.Click
        CancelClick()
    End Sub

    Private Sub cmdMEDOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMEDOk.Click
        OkClick()
    End Sub

    Private Sub cmdMEDCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMEDCancel.Click
        CancelClick()
    End Sub

   
    Private Sub cmdWUSOk1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWUSOk1.Click
        OkClick()
    End Sub

    Private Sub ITAFraupdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITAFraupdate.Enter

    End Sub
End Class

