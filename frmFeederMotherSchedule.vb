Public Class frmFeederMotherSchedule

    Dim MotherSailingID As String = DefaultValue
    Dim oTableMotherTranShip As New DataTable
    Dim GetReviewGridCol, getFeederMotherGridCol As Integer
    Dim Save As Boolean 'kiểm tra xem dữ liệu đã lưu chưa Load ,Them hay Xoá thì =false khi click save thi =true
    'khi thoát mà save=flase thì hỏi
    Dim ColAdd As Boolean = False 'cho biết cột đã đc thêm vào lứơi hay chưa
    'Dim CountColAdd As Integer 'đếm số cột Thêm Vào Lứơi
    Dim PortCode As String = ""
    Sub QueryFeeder(Optional ByVal Service As String = "")
        Try
            Dim SQL As String
            If Me.cboFeederService.Text = "" Then
                SQL = "select Distinct SailingScheduleID,Vessel as FeederVessel,VoyNo as FeederVoyNo,Service as FeederService,ETA as FeederETA,ETD as FeederETD "
                SQL &= " From (SailingSchedule LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID)"
                SQL &= " Where SailingSchedule.Continued=1 And ETD between '" & Me.DateTimePicker1.Value & "' and '" & Me.DateTimePicker2.Value & "'   Order By Vessel,VoyNo"
            Else
                SQL = "select Distinct SailingScheduleID,Vessel as FeederVessel,VoyNo as FeederVoyNo,Service as FeederService,ETA as FeederETA,ETD as FeederETD "
                SQL &= " From (SailingSchedule LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID)"
                SQL &= " Where SailingSchedule.Continued=1 And Service='" & Service & "' and ETD between '" & Me.DateTimePicker1.Value & "' and '" & Me.DateTimePicker2.Value & "'   Order By Vessel,VoyNo"
            End If

            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdFeeder.DataSource = dt
            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Columns(i).ColumnName.ToUpper Like "*ID*" Then
                    Me.dgdFeeder.Columns(i).Visible = False
                End If
            Next
            InsertAutoNumberToGrid(Me.dgdFeeder)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryMother(Optional ByVal Service As String = "")
        Try
            Dim SQL As String
            If Me.cboMotherService.Text = "" Then
                SQL = "select Distinct MotherSailingScheduleID,Vessel as MotherVessel,MotherVesselNo as MotherVoyNo,Service as MotherService,OceanETD as MotherETD "
                SQL &= " From (MotherSailingSchedule LEFT JOIN Vessel On MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID)"
                SQL &= " Where MotherSailingSchedule.Continued=1  Order By Vessel,MotherVesselNo"
            Else
                SQL = "select Distinct MotherSailingScheduleID,Vessel as MotherVessel,MotherVesselNo as MotherVoyNo,Service as MotherService,OceanETD as MotherETD "
                SQL &= " From (MotherSailingSchedule LEFT JOIN Vessel On MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID)"
                SQL &= " Where MotherSailingSchedule.Continued=1 And Service='" & Service & "' Order By Vessel,MotherVesselNo"
            End If
           
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdMother.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdMother)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryMotherTranship()
        Try
            Dim SQL As String
            SQL = "Select distinct MotherSailingSchedule.MotherSailingScheduleID as MotherID,Port,Port_Code,MotherTranShip.ETA "
            SQL &= " From ((((FeeDerMotherSchedule INNER JOIN SailingSchedule On FeeDerMotherSchedule.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " INNER JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=FeeDerMotherSchedule.MotherSailingScheduleID)"
            SQL &= " INNER JOIN MothertranShip On MotherTranShip.MotherSailingScheduleID=MotherSailingSchedule.MotherSailingScheduleID)"
            SQL &= " INNER JOIN Port On MotherTranShip.PortID=Port.Port_ID )"
            SQL &= " Where MotherTranShip.Continued=1 And MotherSailingSchedule.Service='" & Me.cboMotherService.Text & "' and MotherSailingSchedule.Continued=1 "
            SQL &= " And SailingSchedule.ETD >='" & Me.DateTimePicker1.Value.Date & "' And SailingSchedule.ETD <='" & Me.DateTimePicker2.Value.Date & "'"
            SQL &= " Order By MotherSailingSchedule.MotherSailingScheduleID"
            oTableMotherTranShip = ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    'Sub QuerySelectMother()
    '    Try
    '        Dim SQL As String
    '        SQL = "select Distinct MotherSailingScheduleID as Value,Vessel + ' - ' + MotherVesselNo as Data "
    '        SQL &= " From (MotherSailingSchedule LEFT JOIN Vessel On MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID)"
    '        SQL &= " Where MotherSailingSchedule.Continued=1  Order By data"
    '        Dim dt As New DataTable
    '        dt = ReadTable(SQL)
    '        Me.cboSelectMother.DisplayMember = "data"
    '        Me.cboSelectMother.ValueMember = "Value"
    '        Me.cboSelectMother.DataSource = dt
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    Sub QueryMotherService()
        Try
            Dim SQL As String
            SQL = "Select Distinct Service From MotherSailingSchedule Where Continued=1 Order By Service"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboMotherService.DisplayMember = "Service"
            Me.cboMotherService.ValueMember = "Service"
            Me.cboMotherService.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryFeederService()
        Try
            Dim SQL As String
            SQL = "Select Distinct Service From SailingSchedule Where Continued=1 Order By Service"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboFeederService.DisplayMember = "Service"
            Me.cboFeederService.ValueMember = "Service"
            Me.cboFeederService.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub DelCol()
        Try
            If IsNothing(oTableMotherTranShip) Then
                Return
            End If
            PortCode = ""
            If oTableMotherTranShip.Rows.Count = 0 Or Me.dgdFeederMotherData.RowCount = 0 Then
                Return
            End If
            For i As Integer = 8 To Me.dgdFeederMotherData.Columns.Count - 1
                Dim ColName As String
                ColName = Me.dgdFeederMotherData.Columns(getFeederMotherGridCol).Name
                Me.dgdFeederMotherData.Columns.Remove(ColName)
                Dim ColNameReview As String
                ColNameReview = Me.dgdReview.Columns(GetReviewGridCol).Name
                Me.dgdReview.Columns.Remove(ColNameReview)
            Next
            Me.dgdFeederMotherData.Rows.Clear()
            ColAdd = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub AddCol(ByVal ID As String)
        Try
            If ColAdd = False Then
                QueryMotherTranship()
                Dim AddcolFeederMother, AddColReview As Boolean 'cho biết co thêm cột các lứơi tương ứng không

                For j As Integer = 0 To oTableMotherTranShip.Rows.Count - 1
                    AddcolFeederMother = True
                    AddColReview = True
                    For i As Integer = 0 To Me.dgdFeederMotherData.Columns.Count - 1
                        If Me.dgdFeederMotherData.Columns(i).HeaderText = oTableMotherTranShip.Rows(j).Item("Port").ToString Then
                            AddcolFeederMother = False
                            Exit For
                        End If
                    Next
                    If AddcolFeederMother Then 'nếu chưa có tên cột trùng thì thêm
                        Me.dgdFeederMotherData.Columns.Add("TranShipPort" & j, oTableMotherTranShip.Rows(j).Item("Port").ToString)
                    End If
                    For i As Integer = 0 To Me.dgdReview.Columns.Count - 1
                        If Me.dgdReview.Columns(i).HeaderText = oTableMotherTranShip.Rows(j).Item("Port_Code").ToString Then
                            AddColReview = False
                        End If
                    Next
                    If AddColReview Then 'nếu chưa có tên cột trùng thì thêm
                        Me.dgdReview.Columns.Add("TranShipPortReview" & j, oTableMotherTranShip.Rows(j).Item("Port_Code").ToString)
                        PortCode &= "   " & oTableMotherTranShip.Rows(j).Item("Port_Code").ToString & " - " & oTableMotherTranShip.Rows(j).Item("Port").ToString
                    End If
                Next
                ColAdd = True
            End If
            Me.txtPortCode.Text = PortCode ''thêm các port
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function QueryService() As DataTable
        Try
            Dim SQL As String
            SQL = "select * from ServiceFeeder where ServiceFeederCode='" & Me.cboMotherService.Text & "'  And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub QueryCatchData(ByVal Index As Integer)
        Try
            Dim MotherID As String
            'MotherID = Me.dgdMother.Item("MotherSailingScheduleID", Index).Value.ToString
            Dim SQL As String
            SQL = "select SailingSchedule.SailingScheduleID as FeederID,Feeder.Vessel as FeederVessel,VoyNo as FeederVoyNo,Mother.Vessel as MotherVessel,MotherVesselNo as MotherVoyNo,SailingSchedule.ETA as FeederETA, "
            SQL &= " MotherSailingSchedule.MotherSailingScheduleID,SailingSchedule.ETD as FeederETD,replace(MotherSailingSchedule.OceanETD,'12:00AM','') as MotherETD,MotherSailingSchedule.POL as POL"
            SQL &= " From ((((FeeDerMotherSchedule LEFT JOIN SailingSchedule On FeeDerMotherSchedule.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=FeeDerMotherSchedule.MotherSailingScheduleID)"
            SQL &= " LEFT JOIN Vessel as Feeder On Feeder.Vessel_ID=SailingSchedule.Vessel_ID )"
            SQL &= " LEFT JOIN Vessel as Mother On Mother.Vessel_ID=MotherSailingSchedule.MotherVesselID)"
            'SQL &= " Where FeeDerMotherSchedule.Continued=1 And FeeDerMotherSchedule.MotherSailingScheduleID='" & MotherID & "'"

            'SQL &= " Where FeeDerMotherSchedule.Continued=1 And MotherSailingSchedule.Service='" & Me.cboMotherService.Text & "' And SailingSchedule.Service='" & Me.cboFeederService.Text & "' "
            SQL &= " Where FeeDerMotherSchedule.Continued=1 And MotherSailingSchedule.Service='" & Me.cboMotherService.Text & "'  "
            SQL &= " And SailingSchedule.ETD between '" & Me.DateTimePicker1.Value.Date & "' And '" & Me.DateTimePicker2.Value.Date & "'  "
            Dim dt As New DataTable
            dt = ReadTable(SQL)

            If Me.dgdFeederMotherData.RowCount > 0 Then
                Me.dgdFeederMotherData.Rows.Clear()

            End If
            If Me.dgdReview.Rows.Count > 0 Then
                Me.dgdReview.Rows.Clear()
            End If
            If dt.Rows.Count > 0 Then
                QueryMotherTranship()
                AddCol(MotherID)
            End If

            For i As Integer = 0 To dt.Rows.Count - 1
                Me.dgdFeederMotherData.Rows.Add(1)

                Dim CurRow As Integer = Me.dgdFeederMotherData.RowCount - 1
                Me.dgdFeederMotherData.Item("MotherID", CurRow).Value = dt.Rows(i).Item("MotherSailingScheduleID").ToString
                Me.dgdFeederMotherData.Item("FeederID", CurRow).Value = dt.Rows(i).Item("FeederID").ToString
                Me.dgdFeederMotherData.Item("CatchFeederVessel", CurRow).Value = dt.Rows(i).Item("FeederVessel").ToString
                Me.dgdFeederMotherData.Item("CatchFeederVoyNo", CurRow).Value = dt.Rows(i).Item("FeederVoyNo").ToString
                Me.dgdFeederMotherData.Item("CatchFeederETA", CurRow).Value = Replace(dt.Rows(i).Item("FeederETA"), "12:00:00 AM", "")
                Me.dgdFeederMotherData.Item("CatchFeederETD", CurRow).Value = dt.Rows(i).Item("FeederETD")
                Me.dgdFeederMotherData.Item("CatchMotherVessel", CurRow).Value = dt.Rows(i).Item("MotherVessel").ToString
                Me.dgdFeederMotherData.Item("CatchMotherVoyNo", CurRow).Value = dt.Rows(i).Item("MotherVoyNo").ToString


                ''thêm dữ liệu vào bên lứơi review
                Me.dgdReview.Rows.Add(1)
                Me.dgdReview.Item("VesselName", CurRow).Value = dt.Rows(i).Item("FeederVessel").ToString
                Me.dgdReview.Item("VoyNo", CurRow).Value = dt.Rows(i).Item("FeederVoyNo").ToString
                Me.dgdReview.Item("ETDHCM", CurRow).Value = dt.Rows(i).Item("FeederETD").ToString
                Me.dgdReview.Item("CONNECTINGVESSEL", CurRow).Value = dt.Rows(i).Item("MotherVessel").ToString
                Me.dgdReview.Item("ConnectingVoyNo", CurRow).Value = dt.Rows(i).Item("MotherVoyNo").ToString
                Me.dgdReview.Item("ETDMother", CurRow).Value = dt.Rows(i).Item("MotherETD").ToString
                Me.dgdReview.Columns("ETDMother").HeaderText = "ETD   (" & dt.Rows(i).Item("POL").ToString & ")"

                For j As Integer = 0 To oTableMotherTranShip.Rows.Count - 1
                    'nếu cùng tàu mẹ mới xét tới port
                    If oTableMotherTranShip.Rows(j).Item("MotherID").ToString.Trim = dt.Rows(i).Item("MotherSailingScheduleID").ToString.Trim Then
                        For col As Integer = 0 To Me.dgdFeederMotherData.Columns.Count - 1
                            If Me.dgdFeederMotherData.Columns(col).HeaderText = oTableMotherTranShip.Rows(j).Item("Port").ToString Then
                                Me.dgdFeederMotherData.Item(col, i).Value = Replace(oTableMotherTranShip.Rows(j).Item("ETA"), "12:00:00 AM", "")
                                Exit For
                            End If
                        Next

                        For col As Integer = 0 To Me.dgdReview.Columns.Count - 1 ''nếu tên port giống nhau thì thêm ETA
                            If Me.dgdReview.Columns(col).HeaderText = oTableMotherTranShip.Rows(j).Item("Port_Code").ToString Then
                                Me.dgdReview.Item(col, i).Value = Replace(oTableMotherTranShip.Rows(j).Item("ETA"), "12:00:00 AM", "")
                                Exit For
                            End If
                        Next
                        'Me.dgdReview.Item("TranShipPortReview" & j, i).Value = oTableMotherTranShip.Rows(j).Item("ETA")
                    End If
                Next
            Next
            '---- so 0 thanh mau trang
            'Dim t, s As Integer
            'For t = 0 To Me.dgdFeederMotherData.RowCount - 1
            '    For s = 0 To Me.dgdFeederMotherData.ColumnCount - 1
            '        If Me.dgdFeederMotherData.Item(s, t).Value.ToString Like "*12:00:00 AM*" Then
            '            Me.dgdFeederMotherData.Item(s, t).Value = Replace(Me.dgdFeederMotherData.Item(s, t).Value, "12:00:00 AM", "")
            '        End If
            '    Next
            'Next
            ''thêm các pic
            SQL = "select * from PicLocal Where Continued=1 And Schedule=1"
            Dim Tempdt As DataTable
            Tempdt = New DataTable
            Tempdt = ReadTable(SQL)
            Dim strPicInfo As String = ""
            For pic As Integer = 0 To Tempdt.Rows.Count - 1
                strPicInfo &= Tempdt.Rows(pic).Item("PicName").ToString
                If (Tempdt.Rows(pic).Item("DePartMent").ToString.Trim) <> "" Then
                    strPicInfo &= " " & Tempdt.Rows(pic).Item("DePartMent").ToString
                End If
                strPicInfo &= " (HP." & Tempdt.Rows(pic).Item("Mobile").ToString
                strPicInfo &= " - Email:" & Tempdt.Rows(pic).Item("Email").ToString & " )"
                If Tempdt.Rows(pic).Item("LocalNumber").ToString.Trim <> "" Then
                    strPicInfo &= " Local Number :" & Tempdt.Rows(pic).Item("LocalNumber").ToString
                End If
                strPicInfo &= Chr(13) & Chr(10)
            Next

            Me.txtPICInfo.Text = strPicInfo

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmFeederMotherSchedule_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Save = False Then
                If MsgBox("Do you want save changed ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    cmdSave_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmFeederMotherSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Save = True
        QueryFeederService()
        'QuerySelectMother()
        QueryMotherService()
        Me.lblDate.Text = "Date : " & Now().Date
        GetReviewGridCol = Me.dgdReview.Columns.Count
        getFeederMotherGridCol = Me.dgdFeederMotherData.Columns.Count

        ' Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub dgdFeeder_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdFeeder.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdFeeder)
    End Sub

    Private Sub ctmAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmAdd.Click
        Try
            If Me.dgdFeeder.RowCount = 0 Or Me.dgdMother.RowCount = 0 Then
                Return
            End If
            Dim FeederCount, MotherCount As Integer
            FeederCount = Me.dgdFeeder.Rows.GetRowCount(DataGridViewElementStates.Selected)
            MotherCount = Me.dgdMother.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If MotherCount = 0 Or FeederCount = 0 Or MotherCount > 1 Then ''chưa chọn tàu mẹ hay tàu con
                MsgBox("You Have to Choose Some Feeder And 1 Mother,Thank")
                Return
            End If
            Dim FeederIndex, MotherIndex As Integer
            MotherIndex = Me.dgdMother.CurrentRow.Index
            MotherSailingID = Me.dgdMother.Item("MotherSailingScheduleID", MotherIndex).Value.ToString

            '''thêm cột cho lưới
            AddCol(MotherSailingID)

            For i As Integer = 0 To FeederCount - 1
                FeederIndex = Me.dgdFeeder.SelectedRows(i).Index 'lấy vị trí dòng chọn thứ i
                Me.dgdFeederMotherData.Rows.Add(1)
                Dim CurRow As Integer = Me.dgdFeederMotherData.RowCount - 1
                Me.dgdFeederMotherData.Item("FeederID", CurRow).Value = Me.dgdFeeder.Item("SailingScheduleID", FeederIndex).Value
                Me.dgdFeederMotherData.Item("CatchFeederVessel", CurRow).Value = Me.dgdFeeder.Item("FeederVessel", FeederIndex).Value
                Me.dgdFeederMotherData.Item("CatchFeederVoyNo", CurRow).Value = Me.dgdFeeder.Item("FeederVoyNo", FeederIndex).Value
                Me.dgdFeederMotherData.Item("CatchFeederETA", CurRow).Value = Me.dgdFeeder.Item("FeederETA", FeederIndex).Value
                Me.dgdFeederMotherData.Item("CatchFeederETD", CurRow).Value = Me.dgdFeeder.Item("FeederETD", FeederIndex).Value

                Me.dgdFeederMotherData.Item("MotherID", CurRow).Value = Me.dgdMother.Item("MotherSailingScheduleID", MotherIndex).Value
                Me.dgdFeederMotherData.Item("CatchMotherVessel", CurRow).Value = Me.dgdMother.Item("MotherVessel", MotherIndex).Value
                Me.dgdFeederMotherData.Item("CatchMotherVoyNo", CurRow).Value = Me.dgdMother.Item("MotherVoyNo", MotherIndex).Value
                'thêm giá trị cho các cột vừa thêm trên lứơi
                For j As Integer = 0 To oTableMotherTranShip.Rows.Count - 1
                    Me.dgdFeederMotherData.Item("TranShipPort" & j, CurRow).Value = oTableMotherTranShip.Rows(j).Item("ETA")
                Next
            Next
            Save = False
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            Dim rs As New ADODB.Recordset
            Dim SQL As String

            For i As Integer = 0 To Me.dgdFeederMotherData.RowCount - 1
                SQL = "select * from FeeDerMotherSchedule where SailingScheduleID='" & Me.dgdFeederMotherData("FeederID", i).Value.ToString & "' And  MotherSailingScheduleID='" & Me.dgdFeederMotherData.Item("MotherID", i).Value.ToString & "' And Continued=1"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("FeederMotherScheduleID").Value = NewId()
                        .Fields("SailingScheduleID").Value = "{" & Me.dgdFeederMotherData.Item("FeederID", i).Value.ToString & "}"
                        .Fields("MotherSailingScheduleID").Value = "{" & Me.dgdFeederMotherData.Item("MotherID", i).Value.ToString & "}"
                        .Update()
                    End If
                End With
                rs.Close()
            Next
            Save = True
            MsgBox("Data Saved!!")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            'If Me.dgdFeederMotherData.RowCount = 0 Then
            '    Return
            'End If
            'ExportExecel(Me.dgdFeederMotherData, Me)
            'Me.grpSelectMother.BringToFront()
            'Me.grpSelectMother.Visible = True
            Try
                If Me.dgdFeederMotherData.RowCount = 0 Then
                    Return
                End If
                ExportExecel(Me.dgdFeederMotherData, Me)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Me.dgdFeederMotherData.RowCount = 0 Or IsNothing(Me.dgdFeederMotherData.CurrentRow) Then
                Return
            End If
            'Dim CountRow As Integer = Me.dgdFeederMotherData.Rows.GetRowCount(DataGridViewElementStates.Selected)
            Dim SQL As String
            Dim rs As New ADODB.Recordset

            Dim i As Integer

            i = Me.dgdFeederMotherData.SelectedRows(0).Index
            SQL = "select * from FeeDerMotherSchedule where SailingScheduleID='" & Me.dgdFeederMotherData("FeederID", i).Value.ToString & "' And MotherSailingScheduleID='" & Me.dgdFeederMotherData.Item("MotherID", i).Value.ToString & "' And Continued=1"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                rs.Fields("Continued").Value = 0
                rs.Update()
            End If
            rs.Close()
            Save = False
            QueryCatchData(i)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

   

    Private Sub dgdMother_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdMother.RowStateChanged
        Try
          
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdFeederMotherData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdFeederMotherData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdFeederMotherData)
    End Sub

    Private Sub dgdFeederMotherData_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdFeederMotherData.RowsAdded
        InsertAutoNumberToGrid(Me.dgdFeederMotherData)
    End Sub

    Private Sub dgdFeederMotherData_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdFeederMotherData.RowsRemoved
        InsertAutoNumberToGrid(Me.dgdFeederMotherData)
    End Sub

    Private Sub cboFeederService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFeederService.SelectedIndexChanged
        QueryFeeder(Me.cboFeederService.Text.Trim)
    End Sub

    Private Sub cboMotherService_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMotherService.Leave
        QueryMother(Me.cboMotherService.Text.Trim)
        Dim SQL As String

        Sql = "select * From ServiceFeeder Where ServiceFeederCode='" & Me.cboMotherService.Text & "'  And Continued=1"


        Dim dt As New DataTable
        dt = ReadTable(Sql)
        If dt.Rows.Count > 0 Then
            Me.lblName.Text = "HO CHI MINH TO - " & dt.Rows(0).Item("ServiCeFeederName").ToString & " - " & Me.cboMotherService.Text
        End If

    End Sub

    Private Sub cboMotherService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMotherService.SelectedIndexChanged
        QueryMother(Me.cboMotherService.Text.Trim)
        Dim SQL As String
      
        SQL = "select * From ServiceFeeder Where ServiceFeederCode='" & Me.cboMotherService.Text & "'  And Continued=1"


        Dim dt As New DataTable
        dt = ReadTable(SQL)
        If dt.Rows.Count > 0 Then
            Me.lblName.Text = "HO CHI MINH TO - " & dt.Rows(0).Item("ServiCeFeederName").ToString & " - " & Me.cboMotherService.Text
        End If
    End Sub

    Private Sub cmdnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnew.Click
        DelCol()
    End Sub

    'Private Sub cmdSelectMotherCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.grpSelectMother.Visible = False
    'End Sub

    'Private Sub cmdSelectMotherOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.grpSelectMother.Visible = False
    '    Try
    '        DelCol()
    '        For SelectRow As Integer = 0 To Me.dgdSelectMother.RowCount - 1


    '            Dim MotherID As String
    '            MotherID = Me.dgdSelectMother.Item("SelectMotherSailingScheduleID", SelectRow).Value.ToString
    '            Dim SQL As String
    '            SQL = "select SailingSchedule.SailingScheduleID as FeederID,Feeder.Vessel as FeederVessel,VoyNo as FeederVoyNo,Mother.Vessel as MotherVessel,MotherVesselNo as MotherVoyNo,SailingSchedule.ETA as FeederETA, "
    '            SQL &= " MotherSailingSchedule.MotherSailingScheduleID,SailingSchedule.ETD as FeederETD"
    '            SQL &= " From ((((FeeDerMotherSchedule LEFT JOIN SailingSchedule On FeeDerMotherSchedule.SailingScheduleID=SailingSchedule.SailingScheduleID)"
    '            SQL &= " LEFT JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=FeeDerMotherSchedule.MotherSailingScheduleID)"
    '            SQL &= " LEFT JOIN Vessel as Feeder On Feeder.Vessel_ID=SailingSchedule.Vessel_ID )"
    '            SQL &= " LEFT JOIN Vessel as Mother On Mother.Vessel_ID=MotherSailingSchedule.MotherVesselID)"
    '            SQL &= " Where FeeDerMotherSchedule.Continued=1 And FeeDerMotherSchedule.MotherSailingScheduleID='" & MotherID & "'"
    '            Dim dt As New DataTable
    '            dt = ReadTable(SQL)

    '            'If Me.dgdFeederMotherData.RowCount > 0 Then
    '            '    Me.dgdFeederMotherData.Rows.Clear()
    '            'End If
    '            If dt.Rows.Count > 0 Then
    '                QueryMotherTranship()
    '            End If
    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                Me.dgdFeederMotherData.Rows.Add(1)
    '                Dim CurRow As Integer = Me.dgdFeederMotherData.RowCount - 1
    '                Me.dgdFeederMotherData.Item("MotherID", CurRow).Value = dt.Rows(i).Item("MotherSailingScheduleID").ToString
    '                Me.dgdFeederMotherData.Item("FeederID", CurRow).Value = dt.Rows(i).Item("FeederID").ToString
    '                Me.dgdFeederMotherData.Item("CatchFeederVessel", CurRow).Value = dt.Rows(i).Item("FeederVessel").ToString
    '                Me.dgdFeederMotherData.Item("CatchFeederVoyNo", CurRow).Value = dt.Rows(i).Item("FeederVoyNo").ToString
    '                Me.dgdFeederMotherData.Item("CatchFeederETA", CurRow).Value = dt.Rows(i).Item("FeederETA").ToString
    '                Me.dgdFeederMotherData.Item("CatchFeederETD", CurRow).Value = dt.Rows(i).Item("FeederETD").ToString
    '                Me.dgdFeederMotherData.Item("CatchMotherVessel", CurRow).Value = dt.Rows(i).Item("MotherVessel").ToString
    '                Me.dgdFeederMotherData.Item("CatchMotherVoyNo", CurRow).Value = dt.Rows(i).Item("MotherVoyNo").ToString
    '                For j As Integer = 0 To oTableMotherTranShip.Rows.Count - 1
    '                    Dim EsistCol As Boolean = False
    '                    For Colcount As Integer = 0 To Me.dgdFeederMotherData.ColumnCount - 1
    '                        'nếu Mother Vessel Có transit port đó thì mới thêm ETA Vào
    '                        If UCase(Me.dgdFeederMotherData.Columns(Colcount).HeaderText.Trim) = UCase(oTableMotherTranShip.Rows(j).Item("Port").ToString.Trim) Then
    '                            Me.dgdFeederMotherData.Item(Colcount, CurRow).Value = oTableMotherTranShip.Rows(j).Item("ETA")
    '                            EsistCol = True
    '                            Exit For
    '                        End If
    '                    Next 'kết thúc lập của các cột trong lứơi

    '                    If EsistCol = False Then 'nếu chưa có transit port này thì thêm
    '                        Me.dgdFeederMotherData.Columns.Add("TranShipPort" & Me.dgdFeederMotherData.Columns.Count, oTableMotherTranShip.Rows(j).Item("Port").ToString)
    '                        Me.dgdFeederMotherData.Item(Me.dgdFeederMotherData.Columns.Count - 1, CurRow).Value = oTableMotherTranShip.Rows(j).Item("ETA")
    '                    End If

    '                Next 'kết thúc vòng lập gán ETA
    '            Next 'kết thúc lập của vịêc gán dữ liệu cho Feedermotherdata

    '        Next 'kết thúc các dòng tàu mẹ đã chọn
    '        ExportExecel(Me.dgdFeederMotherData, Me)

    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    'Private Sub cmdSelectMotherAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.cboSelectMother.Text.Trim = "" Then
    '            Return
    '        End If
    '        Dim Temp() As String
    '        Temp = Strings.Split(Me.cboSelectMother.Text, " - ")
    '        Me.dgdSelectMother.Rows.Add(1)
    '        Dim Count As Integer = Me.dgdSelectMother.RowCount - 1
    '        Me.dgdSelectMother.Item("SelectMotherSailingScheduleID", Count).Value = Me.cboSelectMother.SelectedValue.ToString
    '        Me.dgdSelectMother.Item("SelectMotherVessel", Count).Value = Temp(0)
    '        Me.dgdSelectMother.Item("SelectMotherVoyNo", Count).Value = Temp(1)
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    Private Sub dgdMother_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdMother.CellContentClick
        InsertAutoNumberToGrid(Me.dgdMother)
    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        'Dim RowCount As Integer = Me.dgdMother.Rows.GetRowCount(DataGridViewElementStates.Selected)
        'If RowCount = 0 Then
        '    Return
        'End If
        DelCol()
        QueryCatchData(1)
    End Sub

    Private Sub cmdExportExcelSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcelSchedule.Click
        Dim app As New Excel.Application
        Try
            'Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP"}
            'Dim Path As String
            ''app = New Excel.Application()
            'app.Visible = True

            'Dim workbooks As Excel.Workbooks
            'workbooks = app.Workbooks
            'Dim workbook As Excel._Workbook

            'Path = StartupPath & "\Schedule.xls"

            'workbook = workbooks.Open(path)



            'Dim sheets As Excel.Sheets
            'sheets = workbook.Worksheets
            'Dim ws As Excel._Worksheet
            'ws = sheets.Item(1)
            'If ws Is Nothing Then
            '    app.Quit()

            '    Return
            'End If

            'ws.Range("A9").Value2 = Me.lblName.Text
            'ws.Range("F12").Value2 = Strings.Replace(Me.dgdReview.Columns(GetReviewGridCol - 1).HeaderText, "ETD", "")

            'Dim CurRow As Integer = 12
            'For i As Integer = Me.dgdReview.Columns.Count - GetReviewGridCol - 1 To 0 Step -1
            '    ws.Columns(7).Insert()
            '    ws.Range("G" & CurRow).Value2 = Me.dgdReview.Columns(i + GetReviewGridCol).HeaderText
            'Next

            'ws.Range(Alpha(6) & 11, Alpha(7 + Me.dgdReview.Columns.Count - GetReviewGridCol - 1) & 11).Merge()
            'Dim Arr(Me.dgdReview.Rows.Count, Me.dgdReview.Columns.Count)
            'ws.Rows(CurRow + 1).Insert(Me.dgdReview.Rows.Count)
            'Dim row As Integer
            'For row = 0 To Me.dgdReview.Rows.Count - 1
            '    For Col As Integer = 0 To Me.dgdReview.Columns.Count - 1
            '        Arr(row, Col) = Me.dgdReview.Item(Col, row).Value
            '    Next
            'Next
            'ws.Range("A" & CurRow + 1, Alpha(7 + Me.dgdReview.Columns.Count - GetReviewGridCol - 1) & CurRow + Me.dgdReview.Rows.Count).Value2 = Arr
            'ws.Range("B" & CurRow + row + 4).Value2 = Me.txtPortCode.Text
            'ws.Range("A" & CurRow + row + 4).Value2 = Me.txtPICInfo.Text
            'Path = "c:\Schedule " & Now.Date & ".xls"
            'workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            If Me.dgdFeederMotherData.RowCount > 0 Then
                ExportExecelschedule(Me.dgdFeederMotherData, Me, Me.lblName.Text, Me.txtPortCode.Text, Me.txtPICInfo.Text)
            End If
        Catch
            DisplayMessage(True, Err.Description)
            '        app.Quit()
        End Try
    End Sub

    Private Sub dgdFeeder_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdFeeder.CellContentClick
        InsertAutoNumberToGrid(Me.dgdFeeder)
    End Sub

    Private Sub dgdFeederMotherData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdFeederMotherData.CellContentClick
        InsertAutoNumberToGrid(Me.dgdFeederMotherData)
    End Sub
End Class