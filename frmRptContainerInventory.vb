Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmRptContainerInventory

    'Dim oTable As New DataTable
    Dim ds As New DataSet
    Dim CountContainerType As Integer = 11
    Dim CountStatus As Integer = 8
    Public PrintType As String
    ' Dim arrValue(,) As String
    'Dim ContainerType As String


    Private Sub QueryContainer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)

        '----------------
        strQuery = "select FinalICD as ICDport,CTN_SIZE_TYPE,SoundContainer=sum(SoundContainer),ToBeInSpected=sum(ToBeInSpected), "
        strQuery &= " DamageContainer=sum(DamageContainer),FullImport=sum(FullImport),FullToConsignee=sum(FullToConsignee),"
        strQuery &= " FullExport=sum(FullExport),EmptyToShipper=sum(EmptyToShipper),EmptyContainerReposit=sum(EmptyContainerReposit)"
        strQuery &= " from ContainerManagerment where continued=1 And  (DateofOnboard is NULL or DateofOnboard = '') group by FinalICD,CTN_SIZE_TYPE"
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)


        'If Me.oTable.Rows.Count > 0 Then
        '    Me.oTable.Rows.Clear()
        'End If
        If ds.Tables(0).Rows.Count > 0 Then
            ds.Tables(0).Rows.Clear()
        End If
        '----------------
        Adapter.Fill(ds.Tables(0))
        'oTable = ds.Tables(0)
        'oTable = ds.Tables(0)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub Title(ByVal WS As Excel.Worksheet, ByVal startRow As Integer, Optional ByVal startCol As Integer = 1)
        Try
            Dim ArrValue(12, 1) As Object
            ArrValue(0, 0) = "EQUIPMENT CONDITION"
            ArrValue(3, 0) = "SOUND"
            ArrValue(4, 0) = "TO BE INSPECTED"
            ArrValue(5, 0) = "DAMAGE"
            ArrValue(6, 0) = "FULL IMPORT AT QUAY"
            ArrValue(7, 0) = "FULL TO CNEE"
            ArrValue(8, 0) = "FULL EXPORT AT QUAY"
            ArrValue(9, 0) = "MT TO SHIPPER"
            ArrValue(10, 0) = "MT TO BE REPOSITONED"
            WS.Range(Alpha(startCol - 1) & startRow, Alpha(startCol) & startRow + 12).Value = ArrValue
            WS.Range(Alpha(startCol - 1) & startRow, Alpha(startCol - 1) & startRow + 2).MergeCells = 1
            WS.Range(Alpha(startCol - 1) & startRow).Cells.Font.Bold = 1
            WS.Range(Alpha(startCol - 1) & startRow).Cells.HorizontalAlignment = 3 'Align center Of horizon (Giữa theo chiều ngang)
            WS.Range(Alpha(startCol - 1) & startRow).Cells.VerticalAlignment = 2 'Giữa theo chiều Dọc
            WS.Range(Alpha(startCol - 1) & startRow).Cells.Columns.AutoFit()

            WS.Range(Alpha(startCol - 1) & startRow, Alpha(startCol - 1) & startRow + 10).Cells.BorderAround(1, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, 5)
            WS.Range(Alpha(startCol - 1) & startRow, Alpha(startCol - 1) & startRow + 10).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            'WS.Range(Alpha(startCol - 1) & startRow, Alpha(startCol - 1) & startRow + 10).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub Export1ICD(ByRef WS As Excel.Worksheet, ByVal ICD As String, ByVal startRow As Integer, Optional ByVal startCol As Integer = 1)

        Try
            
            Dim Type() As String = {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH", "20OT", "40OT", "20FR", "40FR"}
            Dim ArrValue(12, Type.Length + 1) As Object


            ArrValue(0, 0) = ICD
            ArrValue(1, 0) = "DRY" '4 loại
            ArrValue(1, 4) = "REEFER" '3loại
            ArrValue(1, 7) = "SPECIAL" '4 loại
            For i As Integer = 0 To Type.Length - 1
                ArrValue(2, i) = Type(i) 'bỏ tiê
            Next

            WS.Range(Alpha(startCol - 1) & startRow, Alpha(startCol + Type.Length - 1) & startRow + 11).Value = ArrValue
            startCol -= 1
            WS.Range(Alpha(startCol) & startRow, Alpha(startCol + Type.Length - 1) & startRow).MergeCells = 1 'Merge của ICD Port
            WS.Range(Alpha(startCol) & startRow).Cells.HorizontalAlignment = 3 'Align center Of horizon (Giữa theo chiều ngang)
            WS.Range(Alpha(startCol) & startRow).Cells.VerticalAlignment = 2 'Giữa theo chiều Dọc
            WS.Range(Alpha(startCol) & startRow).Cells.Columns.AutoFit()

            WS.Range(Alpha(startCol) & startRow + 1, Alpha(startCol + 3) & startRow + 1).MergeCells = 1 'Dry Container 4 loại từ cột 1-cột 3
            WS.Range(Alpha(startCol) & startRow + 1).Cells.HorizontalAlignment = 3 'Align center Of horizon (Giữa theo chiều ngang)
            WS.Range(Alpha(startCol) & startRow + 1).Cells.VerticalAlignment = 2 'Giữa theo chiều Dọc
            WS.Range(Alpha(startCol) & startRow + 1).Cells.Columns.AutoFit()

            WS.Range(Alpha(startCol + 4) & startRow + 1, Alpha(startCol + 6) & startRow + 1).MergeCells = 1 'REFER 3 loại  từ cột 4-cột 6
            WS.Range(Alpha(startCol + 4) & startRow + 1).Cells.HorizontalAlignment = 3 'Align center Of horizon (Giữa theo chiều ngang)
            WS.Range(Alpha(startCol + 4) & startRow + 1).Cells.VerticalAlignment = 2 'Giữa theo chiều Dọc
            WS.Range(Alpha(startCol + 4) & startRow + 1).Cells.Columns.AutoFit()

            WS.Range(Alpha(startCol + 7) & startRow + 1, Alpha(startCol + 10) & startRow + 1).MergeCells = 1 'Container đặc biệt Từ cột 7- cột 10
            WS.Range(Alpha(startCol + 7) & startRow + 1).Cells.HorizontalAlignment = 3 'Align center Of horizon (Giữa theo chiều ngang)
            WS.Range(Alpha(startCol + 7) & startRow + 1).Cells.VerticalAlignment = 2 'Giữa theo chiều Dọc
            WS.Range(Alpha(startCol + 7) & startRow + 1).Cells.Columns.AutoFit()



            WS.Range(Alpha(startCol) & startRow, Alpha(startCol + 10) & startRow + 10).Cells.BorderAround(1, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, 5)
            WS.Range(Alpha(startCol) & startRow, Alpha(startCol + 10) & startRow + 10).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            WS.Range(Alpha(startCol) & startRow, Alpha(startCol + 10) & startRow + 10).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
            For i As Integer = 0 To 50
                WS.Range(Alpha(i) & startRow + 2).Cells.Columns.AutoFit()
            Next


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub ExportExcelAutoICD()
        Dim App As New Excel.Application
        Try
            Dim Alpha() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN"}
            ''''''''''''''''0    1    2    3    4    5   6     7     8   9    10   11   12   13   14   15    16  17   18   19   20    21  22   23   24   25 
            'App = New exApplication()
            App.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = App.Workbooks
            Dim workbook As Excel._Workbook


            workbook = workbooks.Add()
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                App.Quit()
                Return
            End If
            Dim startRow, startCol As Integer
            startRow = 10 'dòng thứ 10 bắt đầu của tiêu đề
            startCol = 2 ' cột thứ 1 tương ứng là A

            Dim ArrValue(CountStatus + 1, CountContainerType + 1) As String
            Dim Start, Finish As Integer
            Start = 2
            Finish = Start + CountContainerType

            Dim StartRowOfData As Integer = startRow + 3 'Dòng bắt đầu của dữ liệu =dòng bắt đầu của tiêu đê(startRow) +3

            Dim ICDPORT As String = "" '= ds.Tables(0).Rows(0).Item("ICDport").ToString.Trim
            Dim CountICD As Integer = 0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i).Item("ICDport").ToString.Trim = "" Then
                    Continue For
                End If
                If ICDPORT <> ds.Tables(0).Rows(i).Item("ICDport").ToString.Trim Then
                    ICDPORT = ds.Tables(0).Rows(i).Item("ICDport").ToString.Trim
                    CountICD += 1
                End If
                If CountICD = 4 Or startCol = 2 Then 'lần chạy đầu tiên
                    If CountICD = 4 Then
                        CountICD = 1
                    End If
                    If startCol <> 2 Then
                        startRow += CountStatus + 4 'công 3 vì ngoài tám trạng thái còn 3 dòng tiêu đề (ICDPORT: CAT LAI..., Chủng loại cont: Dry REF... ,Chi Tiết Loại cont 20GP 40Gp....)và mỗ ICD cách nhau 1 dòng nên công 4
                        startCol = 2
                        StartRowOfData = startRow + 3
                        Start = startCol
                        Finish = Start + CountContainerType - 1
                    End If
                    Title(ws, startRow, 1)
                End If
                Export1ICD(ws, ds.Tables(0).Rows(i).Item("ICDport").ToString, startRow, startCol)
                For ArrRow As Integer = 0 To CountStatus
                    For ArrCol As Integer = 0 To CountContainerType
                        ArrValue(ArrRow, ArrCol) = ""
                    Next
                Next
                i += SetICD(Start, ArrValue, i, ds.Tables(0).Rows(i).Item("ICDPORT").ToString.Trim) - 1
                ws.Range(Alpha(Start - 1) & StartRowOfData, Alpha(Finish - 1) & StartRowOfData + CountStatus).Value2 = ArrValue
                startCol += CountContainerType
                Start = startCol
                Finish = Start + CountContainerType - 1
            Next

            ws.Range("D4").Value2 = frmContainerManagerMent.txtTo1.Text
            ws.Range("D5").Value2 = frmContainerManagerMent.txtTo2.Text
            ws.Range("D6").Value2 = frmContainerManagerMent.txtFrom.Text

            ws.Range("U4").Value2 = Now.Date
            ws.Range("U6").Value2 = "'" & frmContainerManagerMent.txtRptNo.Text
            MsgBox("Complete")

        Catch ex As Exception
        End Try

    End Sub
    Private Sub QueryContainerExcel(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)

        '----------------
        strQuery = "select FinalICD as ICDport,CTN_SIZE_TYPE,orderreport,F1=sum(SoundContainer),F2=sum(ToBeInSpected), "
        strQuery &= " F3=sum(DamageContainer),F4=sum(FullImport),F5=sum(FullToConsignee),"
        strQuery &= " F6=sum(FullExport),F7=sum(EmptyToShipper),F8=sum(EmptyContainerReposit)"
        strQuery &= " from ContainerManagerment,ScheduleCheck,terminal  "
        strQuery &= " where ContainerManagerment.continued=1 "
        strQuery &= " And (DateofOnboard is NULL or DateofOnboard = '') "
        strQuery &= " And ScheduleCheck.Checked=1 And VoyNo_Inbound=ScheduleCheck.VoyNo "
        strQuery &= " and finalICD=terminal.terminalname and OrderReport <> 0 and day(ScheduleCheck.ETA)=day(Arrival_Date) and month(ScheduleCheck.ETA)=Month(Arrival_Date) and year(ScheduleCheck.ETA)=year(Arrival_Date) "
        strQuery &= " group by orderreport,FinalICD,CTN_SIZE_TYPE Order by orderreport ASC "
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)


        'If Me.oTable.Rows.Count > 0 Then
        '    Me.oTable.Rows.Clear()
        'End If
        If ds.Tables(0).Rows.Count > 0 Then
            ds.Tables(0).Rows.Clear()
        End If
        '----------------
        Adapter.Fill(ds.Tables(0))
        'oTable = ds.Tables(0)
        'oTable = ds.Tables(0)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub QueryTotal(ByRef dt As DataSet)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)

        '----------------
        strQuery = "select CTN_SIZE_TYPE,F1=sum(SoundContainer),F2=sum(ToBeInSpected), "
        strQuery &= "F3=sum(DamageContainer),F4=sum(FullImport),F5=sum(FullToConsignee),"
        strQuery &= "F6=sum(FullExport),F7=sum(EmptyToShipper),F8=sum(EmptyContainerReposit)"
        strQuery &= "from ContainerManagerment where continued=1  And (DateofOnboard is NULL or DateofOnboard = '') group by CTN_SIZE_TYPE"
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        'If Not IsNothing(dt) Then
        '    dt.Clear()

        'End If
        dt.Tables.Clear()
        dt.Tables.Add()

        '----------------
        Adapter.Fill(dt.Tables(0))
        'oTable = ds.Tables(0)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub PrintRpt()
        On Error GoTo Err
        'Dim rpt As New 
        '-------------
        Dim rpt As New ReportDocument
        Dim strReportName As String
        Dim strQuery As String
        ' ten Report
        strReportName = "ReportContainerInventory"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rpt.Load(strReportPath)
        '--------------

        rpt.SetDataSource(ds.Tables(0))
        Dim To1, To2, From, ReportNo, rptdate As TextObject
        To1 = rpt.ReportDefinition.ReportObjects("To1")
        To1.Text = UCase(frmContainerManagerMent.txtTo1.Text)

        To2 = rpt.ReportDefinition.ReportObjects("To2")
        To2.Text = UCase(frmContainerManagerMent.txtTo2.Text)

        From = rpt.ReportDefinition.ReportObjects("From")
        From.Text = UCase(frmContainerManagerMent.txtFrom.Text)

        ReportNo = rpt.ReportDefinition.ReportObjects("ReportNo")
        ReportNo.Text = UCase(frmContainerManagerMent.txtRptNo.Text)

        rptdate = rpt.ReportDefinition.ReportObjects("ReportDate")
        rptdate.Text = Now().Date
        Dim dt As New DataSet
        QueryTotal(dt)
        For i As Integer = 1 To dt.Tables(0).Rows.Count

            Dim containertype As TextObject
            containertype = rpt.ReportDefinition.ReportObjects("container" & i)
            containertype.Text = dt.Tables(0).Rows(i - 1).Item("CTN_SIZE_TYPE").ToString

            Dim Sound As TextObject
            Sound = rpt.ReportDefinition.ReportObjects("Sound" & i)
            Sound.Text = dt.Tables(0).Rows(i - 1).Item("F1").ToString

            Dim Inspected As TextObject
            Inspected = rpt.ReportDefinition.ReportObjects("Inspected" & i)
            Inspected.Text = dt.Tables(0).Rows(i - 1).Item("F2").ToString

            Dim Damage As TextObject
            Damage = rpt.ReportDefinition.ReportObjects("Damage" & i)
            Damage.Text = dt.Tables(0).Rows(i - 1).Item("F3").ToString

            Dim FullAtQuay As TextObject
            FullAtQuay = rpt.ReportDefinition.ReportObjects("FullAtQuay" & i)
            FullAtQuay.Text = dt.Tables(0).Rows(i - 1).Item("F4").ToString

            Dim FullConsignee As TextObject
            FullConsignee = rpt.ReportDefinition.ReportObjects("FullConsignee" & i)
            FullConsignee.Text = dt.Tables(0).Rows(i - 1).Item("F5").ToString

            Dim FullExport As TextObject
            FullExport = rpt.ReportDefinition.ReportObjects("ExportAtQuay" & i)
            FullExport.Text = dt.Tables(0).Rows(i - 1).Item("F6").ToString

            Dim MTToShipper As TextObject
            MTToShipper = rpt.ReportDefinition.ReportObjects("MTToshipper" & i)
            MTToShipper.Text = dt.Tables(0).Rows(i - 1).Item("F7").ToString


            Dim repositioned As TextObject
            repositioned = rpt.ReportDefinition.ReportObjects("Repositioned" & i)
            repositioned.Text = dt.Tables(0).Rows(i - 1).Item("F8").ToString

        Next
        Dim mymargins = rpt.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rpt.PrintOptions.ApplyPageMargins(mymargins)
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        'Me.CrystalReportViewer1.ReportSource = rpt
        'Me.CrystalReportViewer1.Refresh()
        'Me.CrystalReportViewer1.Show()
        Exit Sub
Err:
        DisplayMessage(False, Err.Description)
    End Sub

    Public Sub ExportExcel()
        Dim path As String
        Dim App As New Excel.Application
        Try
            Dim Alpha() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN"}
            ''''''''''''''''0    1    2    3    4    5   6     7     8   9    10   11   12   13   14   15    16  17   18   19   20    21  22   23   24   25 
            'App = New exApplication()
            App.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = App.Workbooks
            Dim workbook As Excel._Workbook

            path = StartupPath & "\ContainerInventory.xls"
            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                App.Quit()
                Return
            End If

            Dim ArrValue(CountStatus + 1, CountContainerType + 1) As String
            
            Dim Start, Finish As Integer

            Dim RowStart As Integer
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
               
                For ArrRow As Integer = 0 To CountStatus
                    For ArrCol As Integer = 0 To CountContainerType
                        ArrValue(ArrRow, ArrCol) = ""
                    Next
                Next
                If UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "CAT LAI" Then
                    Start = 1
                    Finish = 11
                    RowStart = 13
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "NEW PORT" Then
                    Start = 12
                    Finish = 22
                    RowStart = 13
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "SONG THAN" Then
                    Start = 23
                    Finish = 33
                    RowStart = 13
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "PHUOC LONG" Then
                    Start = 1
                    Finish = 11
                    RowStart = 25
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "PHUC LONG" Then
                    Start = 12
                    Finish = 22
                    RowStart = 25
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "KHANH HOI" Then
                    Start = 23
                    Finish = 33
                    RowStart = 25
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "TRANSIMEX" Then
                    Start = 1
                    Finish = 11
                    RowStart = 37
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "BIEN HOA" Then
                    Start = 12
                    Finish = 22
                    RowStart = 37
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "LINH XUAN" Then
                    Start = 23
                    Finish = 33
                    RowStart = 37
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "VINATRANS" Then
                    Start = 1
                    Finish = 11
                    RowStart = 49
                ElseIf UCase(ds.Tables(0).Rows(i).Item("ICDport").ToString) = "Z1" Then
                    Start = 12
                    Finish = 22
                    RowStart = 49
                Else
                    Continue For
                End If
                i += SetICD(Start, ArrValue, i, ds.Tables(0).Rows(i).Item("ICDPORT").ToString.Trim) - 1
                ws.Range(Alpha(Start) & RowStart, Alpha(Finish) & RowStart + CountStatus).Value2 = ArrValue

            Next
            ws.Range("D4").Value2 = frmContainerManagerMent.txtTo1.Text
            ws.Range("D5").Value2 = frmContainerManagerMent.txtTo2.Text
            ws.Range("D6").Value2 = frmContainerManagerMent.txtFrom.Text

            ws.Range("U4").Value2 = Now.Date
            ws.Range("U6").Value2 = "'" & frmContainerManagerMent.txtRptNo.Text

            path = "c:\ContainerInvetory" & strUserId & Now.Second & ".xls"
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlExclusive, , , , )

        Catch ex As Exception
            If Err.Number = 1004 Then
                DisplayMessage(True, "file này đã có trong C:\ ")
            Else

                DisplayMessage(True, Err.Description)
            End If
        Finally
            App = Nothing
        End Try
    End Sub

    Public Function SetICD(ByVal start As Integer, ByVal Arrvalue(,) As String, ByVal CurRow As Integer, ByVal ICDPORT As String) As Integer
        Try

            'For CountRow As Integer = 0 To ds.Tables(0).Rows.Count - 1
            'ContainerType = ds.Tables(0).Rows(CountRow).Item("CTN_SIZE_TYPE").ToString
            Dim posCol As Integer
            Dim ContainerType As String
            Dim Count As Integer = 0
            'For ArrRow As Integer = 0 To 8
            '    For ArrCol As Integer = 0 To 8
            '        Arrvalue(ArrRow, ArrCol) = ""
            '    Next
            'Next
            For CountRow As Integer = 0 To ds.Tables(0).Rows.Count - 1

                If UCase(ds.Tables(0).Rows(CountRow).Item("ICDPORT").ToString.Trim) = ICDPORT Then
                   
                    posCol = start
                    Count += 1
                    ContainerType = ds.Tables(0).Rows(CountRow).Item("CTN_SIZE_TYPE").ToString.Trim
                    If ContainerType = "20GP" Then
                        posCol = 0
                    ElseIf ContainerType = "40GP" Then
                        posCol = 1
                    ElseIf ContainerType = "40HC" Then
                        posCol = 2
                    ElseIf ContainerType = "45HC" Then
                        posCol = 3
                    ElseIf ContainerType = "20RF" Then
                        posCol = 4
                    ElseIf ContainerType = "40RF" Then
                        posCol = 5
                    ElseIf ContainerType = "40RH" Then
                        posCol = 6
                    ElseIf ContainerType = "20OT" Then
                        posCol = 7
                    ElseIf ContainerType = "40OT" Then
                        posCol = 8
                    ElseIf ContainerType = "20FR" Then
                        posCol = 9
                    ElseIf ContainerType = "40FR" Then
                        posCol = 10
                    Else
                        Continue For
                    End If

                    For i As Integer = 0 To CountStatus - 1
                        Arrvalue(i, posCol) = IIf(ds.Tables(0).Rows(CountRow).Item("F" & i + 1).ToString = 0, "", ds.Tables(0).Rows(CountRow).Item("F" & i + 1).ToString)
                    Next
                End If

            Next

            Return Count
            'Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
   
    Private Sub frmRptContainerInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

           
           
            ds.Tables.Clear()
            ds.Tables.Add()

            If PrintType = "Report" Then
                'Me.grpInventory.Visible = False 'Ẩn Lứơi 
                'Me.CrystalReportViewer1.Visible = True 'hiển report
                QueryContainer()
                PrintRpt()
                PrintType = ""
            ElseIf PrintType = "Excel" Then
                QueryContainerExcel()
                If ds.Tables(0).Rows.Count = 0 Then
                    MsgBox("No data")
                    Return
                End If
                ExportExcelAutoICD()
                'ExportExcel()
                PrintType = ""
                Me.Close()
                'QueryData()
                'Me.grpInventory.Visible = True 'Hiện Lứơi
                'Me.CrystalReportViewer1.Visible = False 'Ẩn report
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    

  
    

   
End Class