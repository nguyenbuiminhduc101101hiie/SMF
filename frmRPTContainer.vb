Public Class frmRPTContainer

    Dim oTableContainer As New DataTable
    Const strContainerSelect = "Select ContainerManagerMent.,CTN_SIZE_TYPE,Vessel_Inbound,VoyNo_Inbound," & _
    "Arrival_Date As ETAIB,BL_NO_Inbound,CargoIB.GROSSWEIGHT As WeightIB,CargoIB.MEAS As MeasIB" & _
    ",SoundContainer,ToBeInSpected,DamageContainer,FullImport,FullToConsignee,FullExport,EmptyToShipper,EmptyContainerReposit," & _
    "BL_NO_Outbound,Vessel_Outbound,VoyNo_Outbound,Cargo.GROSS As WeightOB,Cargo.CTN_CARGO_MEASUREMENT As MeasOB," & _
      "BillOflading.Load_Date As ETDOB, OceanVessel,OceanVoyno as OceanVesselVoyNo,OceanETD "
    Function MakeQueryContainer(Optional ByVal argCriteria As String = "") As String
        On Error GoTo Err_Renamed
        MakeQueryContainer = "  select container.Container_No,container.ctn_size_type,blh_no as BL_NO_Outbound,bookingNo, ETD as etdob "
        MakeQueryContainer = MakeQueryContainer & " From "
        MakeQueryContainer = MakeQueryContainer & "  BillOfLading_house  "
        MakeQueryContainer = MakeQueryContainer & " LEFT JOIN Cargo_house On cargo_house.blh_ID=billoflading_house.blh_ID  left join container on container.ctn_id=cargo_house.ctn_id left join containeroutboundnotify on containeroutboundnotify.containeroutboundNotifyID=billoflading_house.containeroutboundNotifyID  "
        MakeQueryContainer = MakeQueryContainer & " WHERE "
        MakeQueryContainer = MakeQueryContainer & " cargo_house.Continued = 1 And container.Container_No='" & Me.cboContainer_No.Text.Trim & "'"
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryContainer = MakeQueryContainer & argCriteria
        End If
        'ElseIf index = 15 Then ' 
        '    MakeQueryContainer = MakeQueryContainer & strContainerOutboundNotifyOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Sub QueryContainer(Optional ByVal argCriteria As String = "")
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryContainer()
        Else
            strQuery = MakeQueryContainer(argCriteria)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Not IsNothing(oTableContainer) Then
            oTableContainer.Clear()
        End If
        Adapter.Fill(oTableContainer)
        Me.dgdGeneral.DataSource = oTableContainer
        Me.Cursor = Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryContainerNo()
        On Error GoTo Err
        Dim strQuery As String
        strQuery = "Select Distinct Container_No From cargo_house inner join container on cargo_house.ctn_id=container.ctn_id  Where cargo_house.Continued=1 Order by Container_no ASC"
        Dim conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmdselect As New SqlClient.SqlCommand(strQuery, conn)
        conn.Open()
        Dim Adapter As New SqlClient.SqlDataAdapter(strQuery, conn)
        Dim dt As New DataTable
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(dt)

        For i As Integer = 0 To dt.Rows.Count - 1
            Me.cboContainer_No.Items.Add(dt.Rows(i).Item("Container_no").ToString)
        Next
        If dt.Rows.Count > 0 Then
            Me.cboContainer_No.SelectedIndex = 0
        End If
        Exit Sub
Err:
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(fraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(fraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        dgdGeneral.Width = (Me.Width - 20)
        dgdGeneral.Height = Me.Height - 70 - 40

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmRptGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        QueryContainerNo()
        QueryContainer()
        ReFormat()
        SetDefaultGrid(Me.dgdGeneral, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Exit Sub
Err:

    End Sub

    Private Sub cboContainer_No_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContainer_No.SelectedIndexChanged
        On Error GoTo Err
        QueryContainer()
        ReFormat()
        Exit Sub
Err:
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        On Error GoTo Err
        frmRptBookingGeneral.ShowDialog()
        Exit Sub

Err:
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If oTableContainer.Rows.Count > 0 Then
                ExportExecel(Me.dgdGeneral, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub
End Class