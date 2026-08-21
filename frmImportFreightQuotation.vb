Imports Excel

Public Class frmImportFreightQuotation

    Private Const MaxScanRows As Integer = 5000
    Private sheetCache As Object
    Private useSheetCache As Boolean
    Private mViewReady As Boolean

    Friend WithEvents tabCalc As System.Windows.Forms.TabPage
    Friend WithEvents txtEmanFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdEmanBrowser As System.Windows.Forms.Button
    Friend WithEvents lblEmanInfo As System.Windows.Forms.Label
    Friend WithEvents txtCalcPol As System.Windows.Forms.TextBox
    Friend WithEvents txtCalcPod As System.Windows.Forms.TextBox
    Friend WithEvents cboCalcTerm As System.Windows.Forms.ComboBox
    Friend WithEvents cboCalcMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtCalcContType As System.Windows.Forms.TextBox
    Friend WithEvents txtCalcContQty As System.Windows.Forms.TextBox
    Friend WithEvents txtCalcCbm As System.Windows.Forms.TextBox
    Friend WithEvents txtCalcKg As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalculate As System.Windows.Forms.Button
    Friend WithEvents dgdCalc As System.Windows.Forms.DataGridView
    Friend WithEvents lblCalc As System.Windows.Forms.Label
    Private OpenFileEman As System.Windows.Forms.OpenFileDialog

    Private Sub frmImportFreightQuotation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblNote.Text = "Chay SQL Create_FreightQuotation_Tables.sql truoc khi import. Form se import toan bo sheet da chon."
        Me.txtLog.Clear()
        Try
            SetDefaultGrid(Me.dgdData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Catch ex As Exception
        End Try
        If Me.cboTable.Items.Count > 0 Then
            Me.cboTable.SelectedIndex = 1
        End If
        LoadBatchCombo()
        SetupCalcTab()
        mViewReady = True
    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        Try
            If Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Me.txtFileName.Text = Me.OpenFileDialog1.FileName
                If Me.txtQuotationName.Text.Trim = "" Then
                    Me.txtQuotationName.Text = System.IO.Path.GetFileNameWithoutExtension(Me.txtFileName.Text)
                End If
                LoadSheetNames(Me.txtFileName.Text.Trim)
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        SetAllSheetsChecked(True)
    End Sub

    Private Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnselectAll.Click
        SetAllSheetsChecked(False)
    End Sub

    Private Sub SetAllSheetsChecked(ByVal checked As Boolean)
        For i As Integer = 0 To Me.lstSheets.Items.Count - 1
            Me.lstSheets.SetItemChecked(i, checked)
        Next
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If Me.txtFileName.Text.Trim = "" Then
            MsgBox("Chon file Excel truoc khi Import.")
            Return
        End If
        If Me.lstSheets.CheckedItems.Count = 0 Then
            MsgBox("Chon it nhat 1 sheet de import.")
            Return
        End If
        ImportAllSheets()
    End Sub

    Private Sub LoadSheetNames(ByVal filePath As String)
        Me.lstSheets.Items.Clear()
        If filePath = "" OrElse Not System.IO.File.Exists(filePath) Then
            Return
        End If

        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Try
            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False
            workbook = app.Workbooks.Open(filePath, ReadOnly:=True)

            For i As Integer = 1 To workbook.Worksheets.Count
                Dim ws As _Worksheet = CType(workbook.Worksheets(i), _Worksheet)
                Dim sheetName As String = ws.Name
                Dim idx As Integer = Me.lstSheets.Items.Add(sheetName)
                Dim key As String = NormalizeSheetKey(sheetName)
                Me.lstSheets.SetItemChecked(idx, IsKnownSheet(key))
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
            Next
        Catch ex As Exception
            DisplayMessage(True, "Khong doc duoc danh sach sheet: " & Err.Description)
        Finally
            If workbook IsNot Nothing Then
                workbook.Close(False)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook)
            End If
            If app IsNot Nothing Then
                app.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
            End If
        End Try
    End Sub

    Private Function NormalizeSheetKey(ByVal sheetName As String) As String
        If sheetName Is Nothing Then
            Return ""
        End If
        Return sheetName.Trim().ToUpperInvariant().Replace(" ", "").Replace("_", "-")
    End Function

    Private Function IsKnownSheet(ByVal key As String) As Boolean
        Select Case key
            Case "FCL-FOB", "FCLFOB", "FCL-EXW", "FCLEXW", "LCL-FOB", "LCLFOB", "LCL-EXW", "LCLEXW", "AIR-FOB", "AIRFOB", "AIR-EXW", "AIREXW"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Sub ImportAllSheets()
        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Dim totalImported As Integer = 0
        Dim totalSkipped As Integer = 0
        Dim batchId As String = NewGuidId()

        Me.cmdOK.Enabled = False
        Me.cmdCancel.Enabled = False
        Me.cmdBrowser.Enabled = False
        Me.txtLog.Clear()
        LogLine("Bat dau import: " & Me.txtFileName.Text)

        Try
            Dim missingTables As String = GetMissingFreightTables()
            If missingTables <> "" Then
                DisplayMessage(True, "Chua thay table tren database [" & strDatabase & "] (server [" & strServer & "]):" & vbCrLf & missingTables & vbCrLf & vbCrLf & "Hay chay SQL tren DUNG database ma chuong trinh dang login.")
                Return
            End If

            If Me.chkReplaceOld.Checked Then
                DeactivateOldBatches(System.IO.Path.GetFileName(Me.txtFileName.Text.Trim))
            End If

            If Not InsertBatch(batchId) Then
                DisplayMessage(True, "Khong tao duoc FreightQuotationBatch.")
                Return
            End If

            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False
            workbook = app.Workbooks.Open(Me.txtFileName.Text.Trim, ReadOnly:=True)

            Dim sheetTotal As Integer = Me.lstSheets.CheckedItems.Count
            Dim sheetIndex As Integer = 0
            For Each item As Object In Me.lstSheets.CheckedItems
                sheetIndex += 1
                Dim sheetName As String = item.ToString()
                Me.lblStatus.Text = "Sheet " & sheetIndex.ToString() & "/" & sheetTotal.ToString() & ": " & sheetName
                System.Windows.Forms.Application.DoEvents()

                Dim ws As _Worksheet = Nothing
                Try
                    ws = workbook.Worksheets(sheetName)
                Catch ex As Exception
                    LogLine("Bo qua sheet (khong mo duoc): " & sheetName)
                    Continue For
                End Try

                Dim imported As Integer = 0
                Dim skipped As Integer = 0
                Dim key As String = NormalizeSheetKey(sheetName)
                Select Case key
                    Case "FCL-FOB", "FCLFOB"
                        ImportSheetRows(ws, "FreightQuotation_FCLFOB", 5, "AM", New String() {"A", "F"}, AddressOf MapFclFob, imported, skipped)
                    Case "FCL-EXW", "FCLEXW"
                        ImportSheetRows(ws, "FreightQuotation_FCLEXW", 6, "BR", New String() {"A", "M"}, AddressOf MapFclExw, imported, skipped)
                    Case "LCL-FOB", "LCLFOB"
                        ImportSheetRows(ws, "FreightQuotation_LCLFOB", 6, "AW", New String() {"A", "G"}, AddressOf MapLclFob, imported, skipped)
                    Case "LCL-EXW", "LCLEXW"
                        ImportSheetRows(ws, "FreightQuotation_LCLEXW", 6, "CC", New String() {"A", "L"}, AddressOf MapLclExw, imported, skipped)
                    Case "AIR-FOB", "AIRFOB"
                        ImportSheetRows(ws, "FreightQuotation_AIRFOB", 6, "AJ", New String() {"A", "B"}, AddressOf MapAirFob, imported, skipped)
                    Case "AIR-EXW", "AIREXW"
                        ImportSheetRows(ws, "FreightQuotation_AIREXW", 6, "BS", New String() {"A", "J"}, AddressOf MapAirExw, imported, skipped)
                    Case Else
                        LogLine("Sheet khong dung mau tariff, bo qua: " & sheetName)
                        If ws IsNot Nothing Then
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
                        End If
                        Continue For
                End Select

                totalImported += imported
                totalSkipped += skipped
                LogLine(sheetName & ": them " & imported.ToString() & " dong, bo qua " & skipped.ToString() & " dong.")
                If ws IsNot Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
                End If
            Next

            Execute("UPDATE FreightQuotationBatch SET RowCountTotal = " & totalImported.ToString() & " WHERE BatchId = '" & SqlSafe(batchId) & "'")

            Dim message As String = "Import hoan tat." & vbCrLf &
                "BatchId: " & batchId & vbCrLf &
                "Them moi: " & totalImported.ToString() & vbCrLf &
                "Bo qua: " & totalSkipped.ToString()
            LogLine(message)
            DisplayMessage(False, message)
            LoadBatchCombo()
            SearchData()
        Catch ex As Exception
            LogLine("Loi: " & ex.Message)
            DisplayMessage(True, Err.Description)
        Finally
            If workbook IsNot Nothing Then
                workbook.Close(False)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook)
            End If
            If app IsNot Nothing Then
                app.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
            End If
            Me.lblStatus.Text = ""
            Me.prbImport.Value = 0
            Me.cmdOK.Enabled = True
            Me.cmdCancel.Enabled = True
            Me.cmdBrowser.Enabled = True
        End Try
    End Sub

    Private Delegate Sub MapRowHandler(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)

    Private Sub ImportSheetRows(ByVal ws As _Worksheet, ByVal tableName As String, ByVal startRow As Integer, ByVal lastCol As String, ByVal keyCols() As String, ByVal mapper As MapRowHandler, ByRef imported As Integer, ByRef skipped As Integer)
        imported = 0
        skipped = 0
        Dim lastRow As Integer = FindLastDataRow(ws, startRow, keyCols)
        If lastRow < startRow Then
            skipped = 0
            Return
        End If

        LoadSheetCache(ws, lastCol, lastRow)

        Dim rs As New ADODB.Recordset
        Try
            rs.Open("SELECT TOP 0 * FROM " & tableName, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            Me.prbImport.Minimum = 0
            Me.prbImport.Maximum = Math.Max(1, lastRow - startRow + 1)
            Me.prbImport.Value = 0

            Dim emptyStreak As Integer = 0
            For rowIndex As Integer = startRow To lastRow
                Me.prbImport.Value = rowIndex - startRow + 1
                Me.lblStatus.Text = tableName & " dong " & rowIndex.ToString() & "/" & lastRow.ToString()
                If (rowIndex - startRow) Mod 20 = 0 Then
                    System.Windows.Forms.Application.DoEvents()
                End If

                If IsEmptyKeyRow(ws, rowIndex, keyCols) Then
                    emptyStreak += 1
                    If emptyStreak >= 15 Then
                        Exit For
                    End If
                    skipped += 1
                    Continue For
                End If
                emptyStreak = 0

                Try
                    rs.AddNew()
                    mapper(rs, ws, rowIndex, CurrentBatchId)
                    rs.Update()
                    imported += 1
                Catch ex As Exception
                    skipped += 1
                    LogLine("Loi " & tableName & " dong " & rowIndex.ToString() & ": " & ex.Message)
                    Try
                        rs.CancelUpdate()
                    Catch
                    End Try
                End Try
            Next
        Finally
            ClearSheetCache()
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                    rs.Close()
                End If
            Catch
            End Try
        End Try
    End Sub

    Private Sub LoadSheetCache(ByVal ws As _Worksheet, ByVal lastCol As String, ByVal lastRow As Integer)
        Try
            sheetCache = ws.Range("A1:" & lastCol & lastRow.ToString()).Value2
            useSheetCache = True
        Catch ex As Exception
            sheetCache = Nothing
            useSheetCache = False
        End Try
    End Sub

    Private Sub ClearSheetCache()
        sheetCache = Nothing
        useSheetCache = False
    End Sub

    Private Function ColumnIndex(ByVal col As String) As Integer
        Dim n As Integer = 0
        For Each ch As Char In col.ToUpperInvariant()
            If ch >= "A"c AndAlso ch <= "Z"c Then
                n = n * 26 + (Asc(ch) - Asc("A"c) + 1)
            End If
        Next
        Return n
    End Function

    Private CurrentBatchId As String = ""

    Private Function InsertBatch(ByVal batchId As String) As Boolean
        Dim rs As New ADODB.Recordset
        Try
            CurrentBatchId = batchId
            rs.Open("SELECT TOP 0 * FROM FreightQuotationBatch", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.AddNew()
            rs.Fields("BatchId").Value = batchId
            SetText(rs, "QuotationName", Me.txtQuotationName.Text.Trim)
            SetText(rs, "FileName", System.IO.Path.GetFileName(Me.txtFileName.Text.Trim))
            SetText(rs, "FilePath", Me.txtFileName.Text.Trim)
            SetText(rs, "ValidMonth", Me.txtValidMonth.Text.Trim)
            SetText(rs, "UserCreate", strUserName)
            rs.Fields("CreatedDate").Value = DateTime.Now
            rs.Fields("RowCountTotal").Value = 0
            rs.Fields("Continued").Value = True
            rs.Update()
            rs.Close()
            Return True
        Catch ex As Exception
            LogLine("Loi tao batch: " & ex.Message)
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                    rs.Close()
                End If
            Catch
            End Try
            Return False
        End Try
    End Function

    Private Sub DeactivateOldBatches(ByVal fileName As String)
        Try
            Execute("UPDATE FreightQuotationBatch SET Continued = 0 WHERE Continued = 1 AND FileName = '" & SqlSafe(fileName) & "'")
            LogLine("Da vo hieu hoa batch cu cua file: " & fileName)
        Catch ex As Exception
            LogLine("Khong vo hieu hoa batch cu: " & ex.Message)
        End Try
    End Sub

    Private Function GetMissingFreightTables() As String
        Dim required() As String = New String() {
            "FreightQuotationBatch",
            "FreightQuotation_FCLFOB",
            "FreightQuotation_FCLEXW",
            "FreightQuotation_LCLFOB",
            "FreightQuotation_LCLEXW",
            "FreightQuotation_AIRFOB",
            "FreightQuotation_AIREXW"}
        Dim missing As New System.Text.StringBuilder()
        For Each tableName As String In required
            If Not TableExists(tableName) Then
                If missing.Length > 0 Then
                    missing.Append(", ")
                End If
                missing.Append(tableName)
            End If
        Next
        Return missing.ToString()
    End Function

    Private Function TableExists(ByVal tableName As String) As Boolean
        Try
            Dim sql As String = "SELECT COUNT(*) AS Cnt FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" & SqlSafe(tableName) & "'"
            Dim dt As System.Data.DataTable = ReadTable(sql)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return False
            End If
            Dim cnt As Integer = 0
            Integer.TryParse(dt.Rows(0)(0).ToString(), cnt)
            Return cnt > 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub MapFclFob(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)
        rs.Fields("Id").Value = NewGuidId()
        rs.Fields("BatchId").Value = batchId
        rs.Fields("ExcelRow").Value = rowIndex
        SetText(rs, "Agent", GetCellText(ws, "A", rowIndex))
        SetText(rs, "Carrier", GetCellText(ws, "B", rowIndex))
        SetText(rs, "CutOff", GetCellText(ws, "C", rowIndex))
        SetText(rs, "Frequency", GetCellText(ws, "D", rowIndex))
        SetText(rs, "TransitTime", GetCellText(ws, "E", rowIndex))
        SetText(rs, "PolCode", GetCellText(ws, "F", rowIndex))
        SetText(rs, "PolName", GetCellText(ws, "G", rowIndex))
        SetText(rs, "Pod", GetCellText(ws, "H", rowIndex))
        SetText(rs, "ContType", GetCellText(ws, "I", rowIndex))
        SetText(rs, "Term", GetCellText(ws, "J", rowIndex))
        SetText(rs, "Currency", GetCellText(ws, "K", rowIndex))
        SetNum(rs, "BuyTotal", GetCellDecimal(ws, "L", rowIndex))
        SetNum(rs, "BuyOF", GetCellDecimal(ws, "M", rowIndex))
        SetNum(rs, "BuyLccPod", GetCellDecimal(ws, "N", rowIndex))
        SetNum(rs, "BuyOF2", GetCellDecimal(ws, "O", rowIndex))
        SetNum(rs, "BuyOldT4", GetCellDecimal(ws, "P", rowIndex))
        SetNum(rs, "BuyTG", GetCellDecimal(ws, "Q", rowIndex))
        SetNum(rs, "BuyLSS", GetCellDecimal(ws, "R", rowIndex))
        SetNum(rs, "BuyDTHC", GetCellDecimal(ws, "S", rowIndex))
        SetNum(rs, "BuyDCIC", GetCellDecimal(ws, "T", rowIndex))
        SetNum(rs, "BuyCleaningFee", GetCellDecimal(ws, "U", rowIndex))
        SetNum(rs, "BuyDOFee", GetCellDecimal(ws, "V", rowIndex))
        SetText(rs, "AppliedMonth", GetCellText(ws, "W", rowIndex))
        SetText(rs, "ValidRate", GetCellText(ws, "X", rowIndex))
        SetText(rs, "BuyRemark", GetCellText(ws, "Y", rowIndex))
        SetNum(rs, "SellTotal", GetCellDecimal(ws, "AB", rowIndex))
        SetNum(rs, "SellOF", GetCellDecimal(ws, "AC", rowIndex))
        SetNum(rs, "SellTHC", GetCellDecimal(ws, "AD", rowIndex))
        SetNum(rs, "SellCFS", GetCellDecimal(ws, "AE", rowIndex))
        SetNum(rs, "SellCIC", GetCellDecimal(ws, "AF", rowIndex))
        SetNum(rs, "SellCleaningFee", GetCellDecimal(ws, "AG", rowIndex))
        SetNum(rs, "SellUnloading", GetCellDecimal(ws, "AH", rowIndex))
        SetNum(rs, "SellHandling", GetCellDecimal(ws, "AI", rowIndex))
        SetNum(rs, "SellDocFee", GetCellDecimal(ws, "AJ", rowIndex))
        SetNum(rs, "PNL", GetCellDecimal(ws, "AL", rowIndex))
        SetText(rs, "SellRemark", GetCellText(ws, "AM", rowIndex))
        rs.Fields("Continued").Value = True
    End Sub

    Private Sub MapFclExw(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)
        rs.Fields("Id").Value = NewGuidId()
        rs.Fields("BatchId").Value = batchId
        rs.Fields("ExcelRow").Value = rowIndex
        SetText(rs, "Agent", GetCellText(ws, "A", rowIndex))
        SetText(rs, "Shipp", GetCellText(ws, "B", rowIndex))
        SetText(rs, "Carrier", GetCellText(ws, "C", rowIndex))
        SetText(rs, "CutOff", GetCellText(ws, "D", rowIndex))
        SetText(rs, "Frequency", GetCellText(ws, "E", rowIndex))
        SetText(rs, "TransitTime", GetCellText(ws, "F", rowIndex))
        SetText(rs, "Country", GetCellText(ws, "G", rowIndex))
        SetText(rs, "Town", GetCellText(ws, "H", rowIndex))
        SetText(rs, "City", GetCellText(ws, "I", rowIndex))
        SetText(rs, "Province", GetCellText(ws, "J", rowIndex))
        SetText(rs, "PickupPlace", GetCellText(ws, "K", rowIndex))
        SetText(rs, "GateIn", GetCellText(ws, "L", rowIndex))
        SetText(rs, "PolCode", GetCellText(ws, "M", rowIndex))
        SetText(rs, "PolName", GetCellText(ws, "N", rowIndex))
        SetText(rs, "Pod", GetCellText(ws, "O", rowIndex))
        SetText(rs, "ContType", GetCellText(ws, "P", rowIndex))
        SetText(rs, "Term", GetCellText(ws, "Q", rowIndex))
        SetText(rs, "Currency", GetCellText(ws, "R", rowIndex))
        SetNum(rs, "BuyTotal", GetCellDecimal(ws, "S", rowIndex))
        SetNum(rs, "BuyTrucking", GetCellDecimal(ws, "T", rowIndex))
        SetNum(rs, "BuyOF", GetCellDecimal(ws, "U", rowIndex))
        SetNum(rs, "BuyTotalPol", GetCellDecimal(ws, "V", rowIndex))
        SetNum(rs, "BuyLTHC", GetCellDecimal(ws, "W", rowIndex))
        SetNum(rs, "BuySeal", GetCellDecimal(ws, "X", rowIndex))
        SetNum(rs, "BuyVGM", GetCellDecimal(ws, "Y", rowIndex))
        SetNum(rs, "BuyEIR", GetCellDecimal(ws, "Z", rowIndex))
        SetNum(rs, "BuyPortCharge", GetCellDecimal(ws, "AA", rowIndex))
        SetNum(rs, "BuyBookingFee", GetCellDecimal(ws, "AB", rowIndex))
        SetNum(rs, "BuyWGateCharge", GetCellDecimal(ws, "AC", rowIndex))
        SetNum(rs, "BuyStuffing", GetCellDecimal(ws, "AD", rowIndex))
        SetNum(rs, "BuyBL", GetCellDecimal(ws, "AE", rowIndex))
        SetNum(rs, "BuyTelexRelease", GetCellDecimal(ws, "AF", rowIndex))
        SetNum(rs, "BuyExportLicense", GetCellDecimal(ws, "AG", rowIndex))
        SetNum(rs, "BuyCustoms", GetCellDecimal(ws, "AH", rowIndex))
        SetNum(rs, "BuyOtherCharge", GetCellDecimal(ws, "AI", rowIndex))
        SetNum(rs, "BuyASM", GetCellDecimal(ws, "AJ", rowIndex))
        SetNum(rs, "BuyExwCharge", GetCellDecimal(ws, "AK", rowIndex))
        SetText(rs, "AppliedMonth", GetCellText(ws, "AL", rowIndex))
        SetText(rs, "ValidRate", GetCellText(ws, "AM", rowIndex))
        SetText(rs, "BuyRemark", GetCellText(ws, "AN", rowIndex))
        SetNum(rs, "BuyTotalPod", GetCellDecimal(ws, "AO", rowIndex))
        SetNum(rs, "BuyDTHC", GetCellDecimal(ws, "AP", rowIndex))
        SetNum(rs, "BuyDCIC", GetCellDecimal(ws, "AQ", rowIndex))
        SetNum(rs, "BuyCleaningFee", GetCellDecimal(ws, "AR", rowIndex))
        SetNum(rs, "BuyDOFee", GetCellDecimal(ws, "AS", rowIndex))
        SetNum(rs, "SellTotal", GetCellDecimal(ws, "AU", rowIndex))
        SetNum(rs, "SellHaulage", GetCellDecimal(ws, "AV", rowIndex))
        SetNum(rs, "SellTrucking", GetCellDecimal(ws, "AW", rowIndex))
        SetNum(rs, "SellTHC", GetCellDecimal(ws, "AX", rowIndex))
        SetNum(rs, "SellBL", GetCellDecimal(ws, "AY", rowIndex))
        SetNum(rs, "SellCustoms", GetCellDecimal(ws, "AZ", rowIndex))
        SetNum(rs, "SellStuffing", GetCellDecimal(ws, "BA", rowIndex))
        SetNum(rs, "SellExportLicense", GetCellDecimal(ws, "BB", rowIndex))
        SetNum(rs, "SellTLX", GetCellDecimal(ws, "BC", rowIndex))
        SetNum(rs, "SellVGM", GetCellDecimal(ws, "BD", rowIndex))
        SetNum(rs, "SellPortCharge", GetCellDecimal(ws, "BE", rowIndex))
        SetNum(rs, "SellGageCharge", GetCellDecimal(ws, "BF", rowIndex))
        SetNum(rs, "SellSeal", GetCellDecimal(ws, "BG", rowIndex))
        SetNum(rs, "SellBooking", GetCellDecimal(ws, "BH", rowIndex))
        SetNum(rs, "SellOF", GetCellDecimal(ws, "BI", rowIndex))
        SetNum(rs, "SellTHC2", GetCellDecimal(ws, "BJ", rowIndex))
        SetNum(rs, "SellCIC", GetCellDecimal(ws, "BK", rowIndex))
        SetNum(rs, "SellCleaningFee", GetCellDecimal(ws, "BL", rowIndex))
        SetNum(rs, "SellUnloading", GetCellDecimal(ws, "BM", rowIndex))
        SetNum(rs, "SellHandling", GetCellDecimal(ws, "BN", rowIndex))
        SetNum(rs, "SellDocFee", GetCellDecimal(ws, "BO", rowIndex))
        SetNum(rs, "PNL", GetCellDecimal(ws, "BQ", rowIndex))
        SetText(rs, "SellRemark", GetCellText(ws, "BR", rowIndex))
        rs.Fields("Continued").Value = True
    End Sub

    Private Sub MapLclFob(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)
        rs.Fields("Id").Value = NewGuidId()
        rs.Fields("BatchId").Value = batchId
        rs.Fields("ExcelRow").Value = rowIndex
        SetText(rs, "Agent", GetCellText(ws, "A", rowIndex))
        SetText(rs, "ShippingLine", GetCellText(ws, "B", rowIndex))
        SetText(rs, "CutOffDoc", GetCellText(ws, "C", rowIndex))
        SetText(rs, "CutOffCargo", GetCellText(ws, "D", rowIndex))
        SetText(rs, "Frequency", GetCellText(ws, "E", rowIndex))
        SetText(rs, "TransitTime", GetCellText(ws, "F", rowIndex))
        SetText(rs, "PolCode", GetCellText(ws, "G", rowIndex))
        SetText(rs, "PolName", GetCellText(ws, "H", rowIndex))
        SetText(rs, "Pod", GetCellText(ws, "I", rowIndex))
        SetText(rs, "CargoType", GetCellText(ws, "J", rowIndex))
        SetText(rs, "Term", GetCellText(ws, "K", rowIndex))
        SetText(rs, "Currency", GetCellText(ws, "L", rowIndex))
        SetText(rs, "LevelLimitVolume", GetCellText(ws, "M", rowIndex))
        SetNum(rs, "Qty", GetCellDecimal(ws, "N", rowIndex))
        SetNum(rs, "BuyTotalPod", GetCellDecimal(ws, "O", rowIndex))
        SetNum(rs, "BuyTotalOF", GetCellDecimal(ws, "P", rowIndex))
        SetNum(rs, "BuyLccPod", GetCellDecimal(ws, "Q", rowIndex))
        SetNum(rs, "BuyOF", GetCellDecimal(ws, "R", rowIndex))
        SetNum(rs, "BuyPSSRR", GetCellDecimal(ws, "S", rowIndex))
        SetNum(rs, "BuyLSS", GetCellDecimal(ws, "T", rowIndex))
        SetNum(rs, "BuyDTHC", GetCellDecimal(ws, "U", rowIndex))
        SetNum(rs, "BuyDCIC", GetCellDecimal(ws, "V", rowIndex))
        SetNum(rs, "BuyCFS", GetCellDecimal(ws, "W", rowIndex))
        SetNum(rs, "BuyDOFee", GetCellDecimal(ws, "X", rowIndex))
        SetText(rs, "AppliedMonth", GetCellText(ws, "Y", rowIndex))
        SetText(rs, "ValidRate", GetCellText(ws, "Z", rowIndex))
        SetText(rs, "BuyRemark", GetCellText(ws, "AA", rowIndex))
        SetNum(rs, "QtyLimit", GetCellDecimal(ws, "AB", rowIndex))
        SetNum(rs, "BuyDetailTotalPod", GetCellDecimal(ws, "AC", rowIndex))
        SetNum(rs, "BuyDetailTotalOF", GetCellDecimal(ws, "AD", rowIndex))
        SetNum(rs, "BuyDetailLccPod", GetCellDecimal(ws, "AE", rowIndex))
        SetNum(rs, "BuyDetailOF", GetCellDecimal(ws, "AF", rowIndex))
        SetNum(rs, "BuyDetailPSSRR", GetCellDecimal(ws, "AG", rowIndex))
        SetNum(rs, "BuyDetailLSS", GetCellDecimal(ws, "AH", rowIndex))
        SetNum(rs, "BuyDetailDTHC", GetCellDecimal(ws, "AI", rowIndex))
        SetNum(rs, "BuyDetailDCIC", GetCellDecimal(ws, "AJ", rowIndex))
        SetNum(rs, "BuyDetailCFS", GetCellDecimal(ws, "AK", rowIndex))
        SetNum(rs, "BuyDetailDOFee", GetCellDecimal(ws, "AL", rowIndex))
        SetNum(rs, "SellTotal", GetCellDecimal(ws, "AN", rowIndex))
        SetNum(rs, "SellOF", GetCellDecimal(ws, "AO", rowIndex))
        SetNum(rs, "SellTHC", GetCellDecimal(ws, "AP", rowIndex))
        SetNum(rs, "SellCFS", GetCellDecimal(ws, "AQ", rowIndex))
        SetNum(rs, "SellCIC", GetCellDecimal(ws, "AR", rowIndex))
        SetNum(rs, "SellCleaning", GetCellDecimal(ws, "AS", rowIndex))
        SetNum(rs, "SellUnloading", GetCellDecimal(ws, "AT", rowIndex))
        SetNum(rs, "SellHandling", GetCellDecimal(ws, "AU", rowIndex))
        SetNum(rs, "SellDO", GetCellDecimal(ws, "AV", rowIndex))
        SetNum(rs, "PNL", GetCellDecimal(ws, "AW", rowIndex))
        rs.Fields("Continued").Value = True
    End Sub

    Private Sub MapLclExw(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)
        rs.Fields("Id").Value = NewGuidId()
        rs.Fields("BatchId").Value = batchId
        rs.Fields("ExcelRow").Value = rowIndex
        SetText(rs, "Agent", GetCellText(ws, "A", rowIndex))
        SetText(rs, "Shipp", GetCellText(ws, "B", rowIndex))
        SetText(rs, "Country", GetCellText(ws, "C", rowIndex))
        SetText(rs, "Town", GetCellText(ws, "D", rowIndex))
        SetText(rs, "City", GetCellText(ws, "E", rowIndex))
        SetText(rs, "Province", GetCellText(ws, "F", rowIndex))
        SetText(rs, "PickupPlace", GetCellText(ws, "G", rowIndex))
        SetText(rs, "GateIn", GetCellText(ws, "H", rowIndex))
        SetText(rs, "CutOffCargo", GetCellText(ws, "I", rowIndex))
        SetText(rs, "Frequency", GetCellText(ws, "J", rowIndex))
        SetText(rs, "TransitTime", GetCellText(ws, "K", rowIndex))
        SetText(rs, "PolCode", GetCellText(ws, "L", rowIndex))
        SetText(rs, "PolName", GetCellText(ws, "M", rowIndex))
        SetText(rs, "Pod", GetCellText(ws, "N", rowIndex))
        SetText(rs, "CargoType", GetCellText(ws, "O", rowIndex))
        SetText(rs, "Term", GetCellText(ws, "P", rowIndex))
        SetText(rs, "LevelLimitVolume", GetCellText(ws, "Q", rowIndex))
        SetText(rs, "Currency", GetCellText(ws, "R", rowIndex))
        SetNum(rs, "BuyTrucking1T", GetCellDecimal(ws, "S", rowIndex))
        SetNum(rs, "BuyTrucking3T", GetCellDecimal(ws, "T", rowIndex))
        SetNum(rs, "BuyTrucking5T", GetCellDecimal(ws, "U", rowIndex))
        SetNum(rs, "BuyTrucking8T", GetCellDecimal(ws, "V", rowIndex))
        SetNum(rs, "BuyTrucking10T", GetCellDecimal(ws, "W", rowIndex))
        SetNum(rs, "BuyTotal", GetCellDecimal(ws, "X", rowIndex))
        SetNum(rs, "BuyOF", GetCellDecimal(ws, "Y", rowIndex))
        SetNum(rs, "BuyTotalPol", GetCellDecimal(ws, "Z", rowIndex))
        SetNum(rs, "BuyLTHC", GetCellDecimal(ws, "AA", rowIndex))
        SetNum(rs, "BuyLCFS", GetCellDecimal(ws, "AB", rowIndex))
        SetNum(rs, "BuyVGM", GetCellDecimal(ws, "AC", rowIndex))
        SetNum(rs, "BuyPortCharge", GetCellDecimal(ws, "AD", rowIndex))
        SetNum(rs, "BuyBookingFee", GetCellDecimal(ws, "AE", rowIndex))
        SetNum(rs, "BuyBL", GetCellDecimal(ws, "AF", rowIndex))
        SetNum(rs, "BuyExportLicense", GetCellDecimal(ws, "AG", rowIndex))
        SetNum(rs, "BuyCustoms", GetCellDecimal(ws, "AH", rowIndex))
        SetNum(rs, "BuyGateCharge", GetCellDecimal(ws, "AI", rowIndex))
        SetNum(rs, "BuyWGateCharge", GetCellDecimal(ws, "AJ", rowIndex))
        SetNum(rs, "BuyWharfageDrayage", GetCellDecimal(ws, "AK", rowIndex))
        SetNum(rs, "BuyStuffing", GetCellDecimal(ws, "AL", rowIndex))
        SetText(rs, "AppliedMonth", GetCellText(ws, "AM", rowIndex))
        SetText(rs, "ValidRate", GetCellText(ws, "AN", rowIndex))
        SetText(rs, "BuyRemark", GetCellText(ws, "AO", rowIndex))
        SetNum(rs, "BuyTotalPod", GetCellDecimal(ws, "AP", rowIndex))
        SetNum(rs, "BuyLSS", GetCellDecimal(ws, "AQ", rowIndex))
        SetNum(rs, "BuyDTHC", GetCellDecimal(ws, "AR", rowIndex))
        SetNum(rs, "BuyDCIC", GetCellDecimal(ws, "AS", rowIndex))
        SetNum(rs, "BuyCFS", GetCellDecimal(ws, "AT", rowIndex))
        SetNum(rs, "BuyDOFee", GetCellDecimal(ws, "AU", rowIndex))
        SetText(rs, "SellLevel", GetCellText(ws, "AV", rowIndex))
        SetNum(rs, "SellQty", GetCellDecimal(ws, "AW", rowIndex))
        SetNum(rs, "SellTotal", GetCellDecimal(ws, "AX", rowIndex))
        SetNum(rs, "SellTruckingTemp", GetCellDecimal(ws, "AY", rowIndex))
        SetNum(rs, "SellTruck1T", GetCellDecimal(ws, "BA", rowIndex))
        SetNum(rs, "SellTruck3T", GetCellDecimal(ws, "BB", rowIndex))
        SetNum(rs, "SellTruck5T", GetCellDecimal(ws, "BC", rowIndex))
        SetNum(rs, "SellTruck8T", GetCellDecimal(ws, "BD", rowIndex))
        SetNum(rs, "SellTotalPol", GetCellDecimal(ws, "BE", rowIndex))
        SetNum(rs, "SellBL", GetCellDecimal(ws, "BF", rowIndex))
        SetNum(rs, "SellCFS", GetCellDecimal(ws, "BG", rowIndex))
        SetNum(rs, "SellTHC", GetCellDecimal(ws, "BH", rowIndex))
        SetNum(rs, "SellEbsCic", GetCellDecimal(ws, "BI", rowIndex))
        SetNum(rs, "SellStuffing", GetCellDecimal(ws, "BJ", rowIndex))
        SetNum(rs, "SellCustoms", GetCellDecimal(ws, "BK", rowIndex))
        SetNum(rs, "SellGateCharge", GetCellDecimal(ws, "BL", rowIndex))
        SetNum(rs, "SellWGateCharge", GetCellDecimal(ws, "BM", rowIndex))
        SetNum(rs, "SellVGM", GetCellDecimal(ws, "BN", rowIndex))
        SetNum(rs, "SellExportLicense", GetCellDecimal(ws, "BO", rowIndex))
        SetNum(rs, "SellBookingFee", GetCellDecimal(ws, "BP", rowIndex))
        SetNum(rs, "SellPortCharge", GetCellDecimal(ws, "BQ", rowIndex))
        SetNum(rs, "SellOceanFreight", GetCellDecimal(ws, "BR", rowIndex))
        SetNum(rs, "SellTotalPod", GetCellDecimal(ws, "BS", rowIndex))
        SetNum(rs, "SellTHCPod", GetCellDecimal(ws, "BT", rowIndex))
        SetNum(rs, "SellCFSPod", GetCellDecimal(ws, "BU", rowIndex))
        SetNum(rs, "SellCIC", GetCellDecimal(ws, "BV", rowIndex))
        SetNum(rs, "SellCleaning", GetCellDecimal(ws, "BW", rowIndex))
        SetNum(rs, "SellUnloading", GetCellDecimal(ws, "BX", rowIndex))
        SetNum(rs, "SellHandling", GetCellDecimal(ws, "BY", rowIndex))
        SetNum(rs, "SellDO", GetCellDecimal(ws, "BZ", rowIndex))
        SetNum(rs, "PNL", GetCellDecimal(ws, "CB", rowIndex))
        SetText(rs, "SellRemark", GetCellText(ws, "CC", rowIndex))
        rs.Fields("Continued").Value = True
    End Sub

    Private Sub MapAirFob(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)
        rs.Fields("Id").Value = NewGuidId()
        rs.Fields("BatchId").Value = batchId
        rs.Fields("ExcelRow").Value = rowIndex
        SetText(rs, "CompanyName", GetCellText(ws, "A", rowIndex))
        SetText(rs, "Origin", GetCellText(ws, "B", rowIndex))
        SetText(rs, "Dest", GetCellText(ws, "C", rowIndex))
        SetText(rs, "Term", GetCellText(ws, "D", rowIndex))
        SetText(rs, "Agent", GetCellText(ws, "E", rowIndex))
        SetText(rs, "Airline", GetCellText(ws, "F", rowIndex))
        SetText(rs, "Currency", GetCellText(ws, "G", rowIndex))
        SetNum(rs, "Qty", GetCellDecimal(ws, "H", rowIndex))
        SetNum(rs, "BuyPlus45", GetCellDecimal(ws, "I", rowIndex))
        SetNum(rs, "BuyPlus100", GetCellDecimal(ws, "J", rowIndex))
        SetNum(rs, "BuyPlus300", GetCellDecimal(ws, "K", rowIndex))
        SetNum(rs, "BuyPlus500", GetCellDecimal(ws, "L", rowIndex))
        SetNum(rs, "BuyPlus1000", GetCellDecimal(ws, "M", rowIndex))
        SetNum(rs, "BuyFSC", GetCellDecimal(ws, "N", rowIndex))
        SetNum(rs, "BuySSC", GetCellDecimal(ws, "O", rowIndex))
        SetNum(rs, "BuyLocalDest", GetCellDecimal(ws, "P", rowIndex))
        SetNum(rs, "BuyAwbCgFee", GetCellDecimal(ws, "Q", rowIndex))
        SetText(rs, "Route", GetCellText(ws, "R", rowIndex))
        SetText(rs, "Frequency", GetCellText(ws, "S", rowIndex))
        SetText(rs, "TransitTime", GetCellText(ws, "T", rowIndex))
        SetText(rs, "ValidRate", GetCellText(ws, "U", rowIndex))
        SetText(rs, "BuyRemark", GetCellText(ws, "V", rowIndex))
        SetNum(rs, "BuyDO", GetCellDecimal(ws, "W", rowIndex))
        SetNum(rs, "SellPlus45", GetCellDecimal(ws, "X", rowIndex))
        SetNum(rs, "SellPlus100", GetCellDecimal(ws, "Y", rowIndex))
        SetNum(rs, "SellPlus300", GetCellDecimal(ws, "Z", rowIndex))
        SetNum(rs, "SellPlus500", GetCellDecimal(ws, "AA", rowIndex))
        SetNum(rs, "SellPlus1000", GetCellDecimal(ws, "AB", rowIndex))
        SetNum(rs, "SellDO", GetCellDecimal(ws, "AC", rowIndex))
        SetNum(rs, "Pnl45", GetCellDecimal(ws, "AE", rowIndex))
        SetNum(rs, "Pnl100", GetCellDecimal(ws, "AF", rowIndex))
        SetNum(rs, "Pnl300", GetCellDecimal(ws, "AG", rowIndex))
        SetNum(rs, "Pnl500", GetCellDecimal(ws, "AH", rowIndex))
        SetNum(rs, "Pnl1000", GetCellDecimal(ws, "AI", rowIndex))
        SetText(rs, "SellRemark", GetCellText(ws, "AJ", rowIndex))
        rs.Fields("Continued").Value = True
    End Sub

    Private Sub MapAirExw(ByVal rs As ADODB.Recordset, ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal batchId As String)
        rs.Fields("Id").Value = NewGuidId()
        rs.Fields("BatchId").Value = batchId
        rs.Fields("ExcelRow").Value = rowIndex
        SetText(rs, "CompanyName", GetCellText(ws, "A", rowIndex))
        SetText(rs, "Shipp", GetCellText(ws, "B", rowIndex))
        SetText(rs, "Country", GetCellText(ws, "C", rowIndex))
        SetText(rs, "Town", GetCellText(ws, "D", rowIndex))
        SetText(rs, "City", GetCellText(ws, "E", rowIndex))
        SetText(rs, "Province", GetCellText(ws, "F", rowIndex))
        SetText(rs, "PickupPlace", GetCellText(ws, "G", rowIndex))
        SetText(rs, "GateIn", GetCellText(ws, "H", rowIndex))
        SetText(rs, "Airline", GetCellText(ws, "I", rowIndex))
        SetText(rs, "PolCode", GetCellText(ws, "J", rowIndex))
        SetText(rs, "PolName", GetCellText(ws, "K", rowIndex))
        SetText(rs, "CargoType", GetCellText(ws, "L", rowIndex))
        SetText(rs, "Term", GetCellText(ws, "M", rowIndex))
        SetText(rs, "Currency", GetCellText(ws, "N", rowIndex))
        SetNum(rs, "Quantity", GetCellDecimal(ws, "O", rowIndex))
        SetNum(rs, "BuyTruck1Ton", GetCellDecimal(ws, "P", rowIndex))
        SetNum(rs, "BuyThcMin", GetCellDecimal(ws, "Q", rowIndex))
        SetNum(rs, "BuyTHC", GetCellDecimal(ws, "R", rowIndex))
        SetNum(rs, "BuyCfsMin", GetCellDecimal(ws, "S", rowIndex))
        SetNum(rs, "BuyCFS", GetCellDecimal(ws, "T", rowIndex))
        SetNum(rs, "BuyXRay", GetCellDecimal(ws, "U", rowIndex))
        SetNum(rs, "BuyExportLicense", GetCellDecimal(ws, "V", rowIndex))
        SetNum(rs, "BuyCustoms", GetCellDecimal(ws, "W", rowIndex))
        SetNum(rs, "BuyBillFee", GetCellDecimal(ws, "X", rowIndex))
        SetNum(rs, "BuyTollFee", GetCellDecimal(ws, "Y", rowIndex))
        SetNum(rs, "BuyENS", GetCellDecimal(ws, "Z", rowIndex))
        SetNum(rs, "BuyGateCharge", GetCellDecimal(ws, "AA", rowIndex))
        SetNum(rs, "BuyWGateCharge", GetCellDecimal(ws, "AB", rowIndex))
        SetNum(rs, "BuyHC", GetCellDecimal(ws, "AC", rowIndex))
        SetNum(rs, "BuyExwCharge", GetCellDecimal(ws, "AD", rowIndex))
        SetText(rs, "ValidRate", GetCellText(ws, "AE", rowIndex))
        SetText(rs, "BuyRemark", GetCellText(ws, "AF", rowIndex))
        SetNum(rs, "BuyAf45", GetCellDecimal(ws, "AG", rowIndex))
        SetNum(rs, "BuyAf100", GetCellDecimal(ws, "AH", rowIndex))
        SetNum(rs, "BuyAf300", GetCellDecimal(ws, "AI", rowIndex))
        SetNum(rs, "BuyAf500", GetCellDecimal(ws, "AJ", rowIndex))
        SetNum(rs, "BuyAf1000", GetCellDecimal(ws, "AK", rowIndex))
        SetNum(rs, "BuyDO", GetCellDecimal(ws, "AL", rowIndex))
        SetNum(rs, "SellTruckMin", GetCellDecimal(ws, "AN", rowIndex))
        SetNum(rs, "SellTruckRate", GetCellDecimal(ws, "AO", rowIndex))
        SetNum(rs, "SellThcMin", GetCellDecimal(ws, "AP", rowIndex))
        SetNum(rs, "SellThcKg", GetCellDecimal(ws, "AQ", rowIndex))
        SetNum(rs, "SellCfsMin", GetCellDecimal(ws, "AR", rowIndex))
        SetNum(rs, "SellCfsKg", GetCellDecimal(ws, "AS", rowIndex))
        SetNum(rs, "SellCustoms", GetCellDecimal(ws, "AT", rowIndex))
        SetNum(rs, "SellBL", GetCellDecimal(ws, "AU", rowIndex))
        SetNum(rs, "SellAMS", GetCellDecimal(ws, "AV", rowIndex))
        SetNum(rs, "SellExportLicense", GetCellDecimal(ws, "AW", rowIndex))
        SetNum(rs, "SellDocSurcharge", GetCellDecimal(ws, "AX", rowIndex))
        SetNum(rs, "SellTollFee", GetCellDecimal(ws, "AY", rowIndex))
        SetNum(rs, "SellGateCharge", GetCellDecimal(ws, "AZ", rowIndex))
        SetNum(rs, "SellWGateCharge", GetCellDecimal(ws, "BA", rowIndex))
        SetNum(rs, "SellAf45", GetCellDecimal(ws, "BB", rowIndex))
        SetNum(rs, "SellAf100", GetCellDecimal(ws, "BC", rowIndex))
        SetNum(rs, "SellAf300", GetCellDecimal(ws, "BD", rowIndex))
        SetNum(rs, "SellAf500", GetCellDecimal(ws, "BE", rowIndex))
        SetNum(rs, "SellAf1000", GetCellDecimal(ws, "BF", rowIndex))
        SetNum(rs, "SellDO", GetCellDecimal(ws, "BG", rowIndex))
        SetNum(rs, "BuyDetail45", GetCellDecimal(ws, "BI", rowIndex))
        SetNum(rs, "BuyDetail100", GetCellDecimal(ws, "BJ", rowIndex))
        SetNum(rs, "BuyDetail300", GetCellDecimal(ws, "BK", rowIndex))
        SetNum(rs, "SellDetail45", GetCellDecimal(ws, "BM", rowIndex))
        SetNum(rs, "SellDetail100", GetCellDecimal(ws, "BN", rowIndex))
        SetNum(rs, "SellDetail300", GetCellDecimal(ws, "BO", rowIndex))
        SetNum(rs, "Pnl45", GetCellDecimal(ws, "BQ", rowIndex))
        SetNum(rs, "Pnl100", GetCellDecimal(ws, "BR", rowIndex))
        SetNum(rs, "Pnl300", GetCellDecimal(ws, "BS", rowIndex))
        rs.Fields("Continued").Value = True
    End Sub

    Private Function FindLastDataRow(ByVal ws As _Worksheet, ByVal startRow As Integer, ByVal keyCols() As String) As Integer
        Dim lastRow As Integer = startRow - 1
        Try
            Dim col As String = keyCols(0)
            Dim colData As Object = ws.Range(col & startRow.ToString() & ":" & col & MaxScanRows.ToString()).Value2
            If TypeOf colData Is Object(,) Then
                Dim arr As Object(,) = CType(colData, Object(,))
                Dim emptyStreak As Integer = 0
                For i As Integer = 1 To arr.GetLength(0)
                    Dim v As Object = arr(i, 1)
                    Dim s As String = ""
                    If v IsNot Nothing AndAlso Not IsDBNull(v) Then
                        s = v.ToString().Trim()
                    End If
                    If s = "" OrElse s.StartsWith("#") Then
                        emptyStreak += 1
                        If emptyStreak >= 20 Then
                            Exit For
                        End If
                    Else
                        emptyStreak = 0
                        lastRow = startRow + i - 1
                    End If
                Next
                Return lastRow
            End If
        Catch ex As Exception
        End Try

        Dim emptyStreak2 As Integer = 0
        For rowIndex As Integer = startRow To MaxScanRows
            If IsEmptyKeyRow(ws, rowIndex, keyCols) Then
                emptyStreak2 += 1
                If emptyStreak2 >= 20 Then
                    Exit For
                End If
            Else
                emptyStreak2 = 0
                lastRow = rowIndex
            End If
        Next
        Return lastRow
    End Function

    Private Function IsEmptyKeyRow(ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal keyCols() As String) As Boolean
        For Each col As String In keyCols
            If GetCellText(ws, col, rowIndex) <> "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub SetText(ByVal rs As ADODB.Recordset, ByVal fieldName As String, ByVal value As String)
        If value Is Nothing OrElse value.Trim() = "" Then
            Return
        End If
        Try
            rs.Fields(fieldName).Value = value.Trim()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetNum(ByVal rs As ADODB.Recordset, ByVal fieldName As String, ByVal value As Object)
        If value Is Nothing OrElse IsDBNull(value) Then
            Return
        End If
        Try
            rs.Fields(fieldName).Value = value
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetCellRaw(ByVal ws As _Worksheet, ByVal col As String, ByVal rowIndex As Integer) As Object
        Try
            If useSheetCache AndAlso sheetCache IsNot Nothing AndAlso TypeOf sheetCache Is Object(,) Then
                Return CType(sheetCache, Object(,))(rowIndex, ColumnIndex(col))
            End If
            Return ws.Range(col & rowIndex.ToString()).Value2
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetCellText(ByVal ws As _Worksheet, ByVal col As String, ByVal rowIndex As Integer) As String
        Try
            Dim cellValue As Object = GetCellRaw(ws, col, rowIndex)
            If cellValue Is Nothing OrElse IsDBNull(cellValue) Then
                Return ""
            End If
            Dim s As String = cellValue.ToString().Trim()
            If s.StartsWith("#") Then
                Return ""
            End If
            Return s
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetCellDecimal(ByVal ws As _Worksheet, ByVal col As String, ByVal rowIndex As Integer) As Object
        Try
            Dim cellValue As Object = GetCellRaw(ws, col, rowIndex)
            If cellValue Is Nothing OrElse IsDBNull(cellValue) Then
                Return Nothing
            End If
            If TypeOf cellValue Is String Then
                Dim s As String = CStr(cellValue).Trim()
                If s = "" OrElse s.StartsWith("#") OrElse s = "-" Then
                    Return Nothing
                End If
                Dim d As Decimal
                If Decimal.TryParse(s, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, d) Then
                    Return d
                End If
                If Decimal.TryParse(s, d) Then
                    Return d
                End If
                Return Nothing
            End If
            If TypeOf cellValue Is Integer OrElse TypeOf cellValue Is Short Then
                Dim errCode As Integer = CInt(cellValue)
                If errCode >= 2000 AndAlso errCode <= 2050 Then
                    Return Nothing
                End If
            End If
            If IsNumeric(cellValue) Then
                Dim dbl As Double = CDbl(cellValue)
                If dbl <= -1000000000 Then
                    Return Nothing
                End If
                Return CDec(dbl)
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Function NewGuidId() As String
        Return System.Guid.NewGuid().ToString("B")
    End Function

    Private Function SqlSafe(ByVal value As String) As String
        If value Is Nothing Then
            Return ""
        End If
        Return value.Replace("'", "''")
    End Function

    Private Sub LogLine(ByVal text As String)
        Me.txtLog.AppendText(text & Environment.NewLine)
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub tabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged
        If Me.tabMain.SelectedTab Is Me.tabView Then
            LoadBatchCombo()
            SearchData()
        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        SearchData()
    End Sub

    Private Sub cboTable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTable.SelectedIndexChanged
        If Not mViewReady Then
            Return
        End If
        If Me.tabMain.SelectedTab Is Me.tabView Then
            SearchData()
        End If
    End Sub

    Private Sub chkActiveOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActiveOnly.CheckedChanged
        If Not mViewReady Then
            Return
        End If
        LoadBatchCombo()
    End Sub

    Private Sub FilterKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAgent.KeyDown, txtPol.KeyDown, txtPod.KeyDown, txtKeyword.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            e.SuppressKeyPress = True
            SearchData()
        End If
    End Sub

    Private Sub LoadBatchCombo()
        Try
            Dim keepId As String = ""
            If Me.cboBatch.SelectedValue IsNot Nothing Then
                keepId = Me.cboBatch.SelectedValue.ToString()
            End If

            Dim sql As String = "SELECT CAST(BatchId AS varchar(50)) AS BatchId, " &
                "ISNULL(QuotationName,'') + ' | ' + ISNULL(ValidMonth,'') + ' | ' + CONVERT(varchar(19), CreatedDate, 120) AS Display " &
                "FROM FreightQuotationBatch "
            If Me.chkActiveOnly.Checked Then
                sql &= "WHERE Continued = 1 "
            End If
            sql &= "ORDER BY CreatedDate DESC"

            Dim dt As System.Data.DataTable = ReadTable(sql)
            If dt Is Nothing Then
                dt = New System.Data.DataTable()
                dt.Columns.Add("BatchId")
                dt.Columns.Add("Display")
            End If

            Dim allRow As System.Data.DataRow = dt.NewRow()
            allRow("BatchId") = ""
            allRow("Display") = "(Tat ca batch)"
            dt.Rows.InsertAt(allRow, 0)

            Me.cboBatch.DisplayMember = "Display"
            Me.cboBatch.ValueMember = "BatchId"
            Me.cboBatch.DataSource = dt

            If keepId <> "" Then
                Me.cboBatch.SelectedValue = keepId
            End If
        Catch ex As Exception
            Me.cboBatch.DataSource = Nothing
            Me.cboBatch.Items.Clear()
            Me.cboBatch.Items.Add("(Tat ca batch)")
            Me.cboBatch.SelectedIndex = 0
        End Try
    End Sub

    Private Sub SearchData()
        Try
            Dim tableKey As String = ""
            If Me.cboTable.SelectedItem IsNot Nothing Then
                tableKey = Me.cboTable.SelectedItem.ToString()
            End If

            Dim sql As String = BuildSearchSql(tableKey)
            Dim dt As System.Data.DataTable = ReadTable(sql)
            If dt Is Nothing Then
                dt = New System.Data.DataTable()
            End If
            Me.dgdData.DataSource = dt
            HideViewColumns()
            Me.lblRowCount.Text = "So dong: " & dt.Rows.Count.ToString() & "  |  Bang: " & tableKey
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Function BuildSearchSql(ByVal tableKey As String) As String
        Dim batchId As String = GetSelectedBatchId()
        Dim agent As String = Me.txtAgent.Text.Trim()
        Dim pol As String = Me.txtPol.Text.Trim()
        Dim pod As String = Me.txtPod.Text.Trim()
        Dim keyword As String = Me.txtKeyword.Text.Trim()

        If tableKey = "Batch" Then
            Dim sqlB As String = "SELECT BatchId, QuotationName, FileName, ValidMonth, UserCreate, CreatedDate, RowCountTotal, Continued, Remark " &
                "FROM FreightQuotationBatch WHERE 1=1 "
            If Me.chkActiveOnly.Checked Then
                sqlB &= "AND Continued = 1 "
            End If
            If batchId <> "" Then
                sqlB &= "AND CAST(BatchId AS varchar(50)) = '" & SqlSafe(batchId.Replace("{", "").Replace("}", "")) & "' "
            End If
            If keyword <> "" Then
                sqlB &= "AND (QuotationName LIKE '%" & SqlSafe(keyword) & "%' OR FileName LIKE '%" & SqlSafe(keyword) & "%' OR ValidMonth LIKE '%" & SqlSafe(keyword) & "%') "
            End If
            sqlB &= "ORDER BY CreatedDate DESC"
            Return sqlB
        End If

        Dim tableName As String = GetTableName(tableKey)
        Dim sql As String = "SELECT r.*, b.QuotationName, b.ValidMonth, b.FileName, b.CreatedDate AS BatchDate " &
            "FROM " & tableName & " r " &
            "INNER JOIN FreightQuotationBatch b ON b.BatchId = r.BatchId " &
            "WHERE 1=1 "
        If Me.chkActiveOnly.Checked Then
            sql &= "AND b.Continued = 1 AND r.Continued = 1 "
        End If
        If batchId <> "" Then
            sql &= "AND CAST(r.BatchId AS varchar(50)) = '" & SqlSafe(batchId.Replace("{", "").Replace("}", "")) & "' "
        End If
        If agent <> "" Then
            If tableKey.StartsWith("AIR") Then
                sql &= "AND (ISNULL(r.Agent,'') LIKE '%" & SqlSafe(agent) & "%' OR ISNULL(r.CompanyName,'') LIKE '%" & SqlSafe(agent) & "%') "
            Else
                sql &= "AND ISNULL(r.Agent,'') LIKE '%" & SqlSafe(agent) & "%' "
            End If
        End If
        If pol <> "" Then
            If tableKey = "AIR-FOB" Then
                sql &= "AND ISNULL(r.Origin,'') LIKE '%" & SqlSafe(pol) & "%' "
            Else
                sql &= "AND ISNULL(r.PolCode,'') LIKE '%" & SqlSafe(pol) & "%' "
            End If
        End If
        If pod <> "" Then
            If tableKey = "AIR-FOB" Then
                sql &= "AND ISNULL(r.Dest,'') LIKE '%" & SqlSafe(pod) & "%' "
            ElseIf tableKey = "AIR-EXW" Then
                sql &= "AND ISNULL(r.PolCode,'') LIKE '%" & SqlSafe(pod) & "%' "
            Else
                sql &= "AND ISNULL(r.Pod,'') LIKE '%" & SqlSafe(pod) & "%' "
            End If
        End If
        If keyword <> "" Then
            Dim kw As String = SqlSafe(keyword)
            sql &= "AND ("
            sql &= "ISNULL(r.Agent,'') LIKE '%" & kw & "%' "
            sql &= "OR ISNULL(CONVERT(varchar(200), r.ExcelRow),'') LIKE '%" & kw & "%' "
            Select Case tableKey
                Case "FCL-FOB"
                    sql &= "OR ISNULL(r.Carrier,'') LIKE '%" & kw & "%' OR ISNULL(r.PolName,'') LIKE '%" & kw & "%' OR ISNULL(r.BuyRemark,'') LIKE '%" & kw & "%' OR ISNULL(r.SellRemark,'') LIKE '%" & kw & "%' "
                Case "FCL-EXW", "LCL-EXW"
                    sql &= "OR ISNULL(r.Shipp,'') LIKE '%" & kw & "%' OR ISNULL(r.City,'') LIKE '%" & kw & "%' OR ISNULL(r.PickupPlace,'') LIKE '%" & kw & "%' OR ISNULL(r.PolName,'') LIKE '%" & kw & "%' "
                Case "LCL-FOB"
                    sql &= "OR ISNULL(r.ShippingLine,'') LIKE '%" & kw & "%' OR ISNULL(r.PolName,'') LIKE '%" & kw & "%' OR ISNULL(r.LevelLimitVolume,'') LIKE '%" & kw & "%' "
                Case "AIR-FOB"
                    sql &= "OR ISNULL(r.Airline,'') LIKE '%" & kw & "%' OR ISNULL(r.Origin,'') LIKE '%" & kw & "%' OR ISNULL(r.Dest,'') LIKE '%" & kw & "%' OR ISNULL(r.CompanyName,'') LIKE '%" & kw & "%' "
                Case "AIR-EXW"
                    sql &= "OR ISNULL(r.Airline,'') LIKE '%" & kw & "%' OR ISNULL(r.City,'') LIKE '%" & kw & "%' OR ISNULL(r.PickupPlace,'') LIKE '%" & kw & "%' OR ISNULL(r.CompanyName,'') LIKE '%" & kw & "%' "
            End Select
            sql &= ") "
        End If
        sql &= "ORDER BY r.ExcelRow"
        Return sql
    End Function

    Private Function GetTableName(ByVal tableKey As String) As String
        Select Case tableKey
            Case "FCL-FOB"
                Return "FreightQuotation_FCLFOB"
            Case "FCL-EXW"
                Return "FreightQuotation_FCLEXW"
            Case "LCL-FOB"
                Return "FreightQuotation_LCLFOB"
            Case "LCL-EXW"
                Return "FreightQuotation_LCLEXW"
            Case "AIR-FOB"
                Return "FreightQuotation_AIRFOB"
            Case "AIR-EXW"
                Return "FreightQuotation_AIREXW"
            Case Else
                Return "FreightQuotationBatch"
        End Select
    End Function

    Private Function GetSelectedBatchId() As String
        Try
            If Me.cboBatch.SelectedValue Is Nothing Then
                Return ""
            End If
            If TypeOf Me.cboBatch.SelectedValue Is System.Data.DataRowView Then
                Return CType(Me.cboBatch.SelectedValue, System.Data.DataRowView)("BatchId").ToString()
            End If
            Return Me.cboBatch.SelectedValue.ToString()
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub HideViewColumns()
        Try
            Dim hideNames() As String = New String() {"Id", "BatchId"}
            For Each colName As String In hideNames
                If Me.dgdData.Columns.Contains(colName) Then
                    Me.dgdData.Columns(colName).Visible = False
                End If
            Next
            Me.dgdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetupCalcTab()
        If Me.tabCalc IsNot Nothing Then
            Return
        End If

        Me.tabCalc = New System.Windows.Forms.TabPage()
        Me.tabCalc.Text = "3. Tinh gia lo hang"
        Me.tabCalc.UseVisualStyleBackColor = True
        Me.tabCalc.Padding = New System.Windows.Forms.Padding(6)

        Dim lblFile As New System.Windows.Forms.Label()
        lblFile.Text = "File EManifest :"
        lblFile.ForeColor = System.Drawing.Color.Navy
        lblFile.Location = New System.Drawing.Point(8, 12)
        lblFile.AutoSize = True

        Me.txtEmanFile = New System.Windows.Forms.TextBox()
        Me.txtEmanFile.Location = New System.Drawing.Point(110, 8)
        Me.txtEmanFile.Size = New System.Drawing.Size(520, 21)

        Me.cmdEmanBrowser = New System.Windows.Forms.Button()
        Me.cmdEmanBrowser.Text = "Browser..."
        Me.cmdEmanBrowser.ForeColor = System.Drawing.Color.Maroon
        Me.cmdEmanBrowser.Location = New System.Drawing.Point(640, 6)
        Me.cmdEmanBrowser.Size = New System.Drawing.Size(90, 24)

        Me.lblEmanInfo = New System.Windows.Forms.Label()
        Me.lblEmanInfo.ForeColor = System.Drawing.Color.Maroon
        Me.lblEmanInfo.Location = New System.Drawing.Point(8, 36)
        Me.lblEmanInfo.Size = New System.Drawing.Size(1040, 18)
        Me.lblEmanInfo.Text = "Chon file EManifest de tu dien HBL, so cont, loai cont, KG, CBM. POL/POD neu file trong thi nhap tay."

        Dim y As Integer = 62
        Me.tabCalc.Controls.Add(MakeLabel("POL :", 8, y + 4))
        Me.txtCalcPol = MakeText(53, y, 80)
        Me.tabCalc.Controls.Add(MakeLabel("POD :", 145, y + 4))
        Me.txtCalcPod = MakeText(190, y, 80)
        Me.tabCalc.Controls.Add(MakeLabel("Term :", 280, y + 4))
        Me.cboCalcTerm = New System.Windows.Forms.ComboBox()
        Me.cboCalcTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalcTerm.Items.AddRange(New Object() {"FOB", "EXW"})
        Me.cboCalcTerm.Location = New System.Drawing.Point(325, y)
        Me.cboCalcTerm.Size = New System.Drawing.Size(70, 23)
        Me.cboCalcTerm.SelectedIndex = 0
        Me.tabCalc.Controls.Add(MakeLabel("Bang :", 405, y + 4))
        Me.cboCalcMode = New System.Windows.Forms.ComboBox()
        Me.cboCalcMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalcMode.Items.AddRange(New Object() {"FCL-FOB", "FCL-EXW", "LCL-FOB", "LCL-EXW", "AIR-FOB", "AIR-EXW"})
        Me.cboCalcMode.Location = New System.Drawing.Point(450, y)
        Me.cboCalcMode.Size = New System.Drawing.Size(100, 23)
        Me.cboCalcMode.SelectedIndex = 0

        y = 92
        Me.tabCalc.Controls.Add(MakeLabel("Cont :", 8, y + 4))
        Me.txtCalcContType = MakeText(53, y, 70)
        Me.txtCalcContType.Text = "20FT"
        Me.tabCalc.Controls.Add(MakeLabel("SL cont :", 130, y + 4))
        Me.txtCalcContQty = MakeText(190, y, 50)
        Me.txtCalcContQty.Text = "1"
        Me.tabCalc.Controls.Add(MakeLabel("CBM :", 250, y + 4))
        Me.txtCalcCbm = MakeText(295, y, 60)
        Me.txtCalcCbm.Text = "0"
        Me.tabCalc.Controls.Add(MakeLabel("KG :", 365, y + 4))
        Me.txtCalcKg = MakeText(400, y, 70)
        Me.txtCalcKg.Text = "0"

        Me.cmdCalculate = New System.Windows.Forms.Button()
        Me.cmdCalculate.Text = "Tinh gia"
        Me.cmdCalculate.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCalculate.Location = New System.Drawing.Point(490, y)
        Me.cmdCalculate.Size = New System.Drawing.Size(90, 24)

        Me.dgdCalc = New System.Windows.Forms.DataGridView()
        Me.dgdCalc.AllowUserToAddRows = False
        Me.dgdCalc.AllowUserToDeleteRows = False
        Me.dgdCalc.ReadOnly = True
        Me.dgdCalc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdCalc.RowHeadersWidth = 25
        Me.dgdCalc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdCalc.Location = New System.Drawing.Point(8, 128)
        Me.dgdCalc.Size = New System.Drawing.Size(1050, 450)

        Me.lblCalc = New System.Windows.Forms.Label()
        Me.lblCalc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCalc.ForeColor = System.Drawing.Color.Maroon
        Me.lblCalc.Location = New System.Drawing.Point(8, 585)
        Me.lblCalc.Size = New System.Drawing.Size(1050, 35)
        Me.lblCalc.Text = "FCL: Gia = BuyTotal/SellTotal x so cont. LCL: chon moc CBM roi lay total. AIR: chon moc KG."

        Me.tabCalc.Controls.Add(lblFile)
        Me.tabCalc.Controls.Add(Me.txtEmanFile)
        Me.tabCalc.Controls.Add(Me.cmdEmanBrowser)
        Me.tabCalc.Controls.Add(Me.lblEmanInfo)
        Me.tabCalc.Controls.Add(Me.txtCalcPol)
        Me.tabCalc.Controls.Add(Me.txtCalcPod)
        Me.tabCalc.Controls.Add(Me.cboCalcTerm)
        Me.tabCalc.Controls.Add(Me.cboCalcMode)
        Me.tabCalc.Controls.Add(Me.txtCalcContType)
        Me.tabCalc.Controls.Add(Me.txtCalcContQty)
        Me.tabCalc.Controls.Add(Me.txtCalcCbm)
        Me.tabCalc.Controls.Add(Me.txtCalcKg)
        Me.tabCalc.Controls.Add(Me.cmdCalculate)
        Me.tabCalc.Controls.Add(Me.dgdCalc)
        Me.tabCalc.Controls.Add(Me.lblCalc)

        Me.tabMain.TabPages.Add(Me.tabCalc)
        Try
            SetDefaultGrid(Me.dgdCalc, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Catch ex As Exception
        End Try

        Me.OpenFileEman = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileEman.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls"
        AddHandler Me.cboCalcTerm.SelectedIndexChanged, AddressOf cboCalcTerm_SelectedIndexChanged
    End Sub

    Private Sub cboCalcTerm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.cboCalcMode Is Nothing OrElse Me.cboCalcMode.SelectedIndex < 0 Then
            Return
        End If
        Dim current As String = Me.cboCalcMode.Text
        Dim dash As Integer = current.IndexOf("-"c)
        If dash <= 0 Then
            Return
        End If
        Dim nextMode As String = current.Substring(0, dash + 1) & Me.cboCalcTerm.Text
        Dim idx As Integer = Me.cboCalcMode.Items.IndexOf(nextMode)
        If idx >= 0 Then
            Me.cboCalcMode.SelectedIndex = idx
        End If
    End Sub

    Private Function MakeLabel(ByVal text As String, ByVal x As Integer, ByVal y As Integer) As System.Windows.Forms.Label
        Dim lbl As New System.Windows.Forms.Label()
        lbl.Text = text
        lbl.ForeColor = System.Drawing.Color.Navy
        lbl.Location = New System.Drawing.Point(x, y)
        lbl.AutoSize = True
        Return lbl
    End Function

    Private Function MakeText(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer) As System.Windows.Forms.TextBox
        Dim t As New System.Windows.Forms.TextBox()
        t.Location = New System.Drawing.Point(x, y)
        t.Size = New System.Drawing.Size(w, 21)
        Return t
    End Function

    Private Sub cmdEmanBrowser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEmanBrowser.Click
        Try
            If Me.OpenFileEman.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Me.txtEmanFile.Text = Me.OpenFileEman.FileName
                LoadEManifestFile(Me.txtEmanFile.Text.Trim)
            End If
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Sub cmdCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        CalculateShipment()
    End Sub

    Private Sub LoadEManifestFile(ByVal filePath As String)
        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Dim oldCache As Boolean = useSheetCache
        useSheetCache = False
        Try
            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False
            workbook = app.Workbooks.Open(filePath, ReadOnly:=True)
            Dim ws As _Worksheet = CType(workbook.Worksheets(1), _Worksheet)

            Dim hbl As String = ""
            Dim mbl As String = ""
            Dim remark As String = ""
            Dim cargoType As String = ""
            Dim pol As String = ""
            Dim pod As String = ""
            Dim kg As Decimal = 0
            Dim cbm As Decimal = 0
            Dim pkg As String = ""
            Dim contNo As String = ""
            Dim dataRow As Integer = 0
            Dim polGuessed As Boolean = False

            For r As Integer = 3 To 30
                Dim h2 As String = GetCellText(ws, "O", r).ToUpperInvariant()
                If h2.Contains("BILL") OrElse h2.Contains("VAN DON") Then
                    Continue For
                End If
                Dim stt As String = GetCellText(ws, "A", r)
                Dim maybeHbl As String = GetCellText(ws, "O", r)
                If IsNumeric(stt) AndAlso maybeHbl <> "" Then
                    dataRow = r
                    hbl = maybeHbl
                    mbl = GetCellText(ws, "Q", r)
                    remark = GetCellText(ws, "X", r)
                    cargoType = GetCellText(ws, "N", r)
                    pol = GetCellText(ws, "K", r)
                    pod = GetCellText(ws, "L", r)
                    If pod = "" Then
                        pod = GetCellText(ws, "J", r)
                    End If
                    pkg = GetCellText(ws, "T", r) & " " & GetCellText(ws, "U", r)
                    Decimal.TryParse(GetCellText(ws, "V", r).Replace(",", ""), kg)
                    Exit For
                End If
            Next

            For r As Integer = dataRow + 1 To dataRow + 15
                Dim hdr As String = GetCellText(ws, "C", r).ToUpperInvariant()
                If hdr.Contains("MO TA") OrElse hdr.Contains("DESCRIPTION") Then
                    Dim gw As Decimal = 0
                    Dim vol As Decimal = 0
                    Decimal.TryParse(GetCellText(ws, "D", r + 1).Replace(",", ""), gw)
                    Decimal.TryParse(GetCellText(ws, "E", r + 1).Replace(",", ""), vol)
                    If gw > 0 Then
                        kg = gw
                    End If
                    cbm = vol
                    contNo = GetCellText(ws, "F", r + 1)
                    Exit For
                End If
            Next

            Dim contQty As Integer = 1
            Dim contType As String = "20FT"
            ParseContainerFromRemark(remark, contQty, contType)

            If pol = "" Then
                pol = GuessPolFromHbl(hbl)
                polGuessed = (pol <> "")
            End If

            Me.txtCalcPol.Text = pol
            Me.txtCalcPod.Text = pod
            Me.txtCalcKg.Text = kg.ToString()
            Me.txtCalcCbm.Text = cbm.ToString()
            Me.txtCalcContQty.Text = contQty.ToString()
            Me.txtCalcContType.Text = contType

            Dim mode As String = "FCL-" & Me.cboCalcTerm.Text
            Dim remarkU As String = remark.ToUpperInvariant()
            If remarkU.Contains("CONT") OrElse remarkU.Contains("20") OrElse remarkU.Contains("40") Then
                mode = "FCL-" & Me.cboCalcTerm.Text
            ElseIf cbm > 0 Then
                mode = "LCL-" & Me.cboCalcTerm.Text
            ElseIf kg > 0 AndAlso remarkU.Contains("AIR") Then
                mode = "AIR-" & Me.cboCalcTerm.Text
            End If
            Dim idx As Integer = Me.cboCalcMode.Items.IndexOf(mode)
            If idx >= 0 Then
                Me.cboCalcMode.SelectedIndex = idx
            End If

            Me.lblEmanInfo.Text = "HBL: " & hbl & "  |  MBL: " & mbl & "  |  " & pkg &
                "  |  " & remark.Replace(Chr(10), " ").Replace(Chr(13), " ")
            If contNo <> "" Then
                Me.lblEmanInfo.Text &= "  |  Cont: " & contNo
            End If
            If cargoType <> "" Then
                Me.lblEmanInfo.Text &= "  |  " & cargoType
            End If
            If polGuessed Then
                Me.lblEmanInfo.Text &= "  |  POL doan tu HBL, kiem tra lai."
            End If
            If pol = "" OrElse pod = "" Then
                Me.lblEmanInfo.Text &= "  |  Thieu POL/POD, nhap tay roi bam Tinh gia."
            Else
                CalculateShipment()
            End If
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        Finally
            useSheetCache = oldCache
            If workbook IsNot Nothing Then
                workbook.Close(False)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook)
            End If
            If app IsNot Nothing Then
                app.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
            End If
        End Try
    End Sub

    Private Sub ParseContainerFromRemark(ByVal remark As String, ByRef qty As Integer, ByRef contType As String)
        qty = 1
        contType = "20FT"
        If remark Is Nothing Then
            Return
        End If
        Dim s As String = remark.ToUpperInvariant()
        Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s, "(\d+)\s*X\s*(\d+)\s*(DC|GP|HC|HQ|FT|RF|RH)")
        If m.Success Then
            Integer.TryParse(m.Groups(1).Value, qty)
            Dim size As String = m.Groups(2).Value
            Dim kind As String = m.Groups(3).Value
            If kind = "HC" OrElse kind = "HQ" Then
                contType = size & "HC"
            ElseIf kind = "RF" OrElse kind = "RH" Then
                contType = size & kind
            Else
                contType = size & "FT"
            End If
            Return
        End If
        If s.Contains("40HC") OrElse s.Contains("40HQ") Then
            contType = "40HC"
        ElseIf s.Contains("40") Then
            contType = "40FT"
        ElseIf s.Contains("20") Then
            contType = "20FT"
        End If
    End Sub

    Private Function GuessPolFromHbl(ByVal hbl As String) As String
        If hbl Is Nothing Then
            Return ""
        End If
        Dim u As String = hbl.ToUpperInvariant()
        If u.Contains("SIN") Then
            Return "SGSIN"
        End If
        If u.Contains("SHA") Then
            Return "CNSHA"
        End If
        If u.Contains("XMN") Then
            Return "CNXMN"
        End If
        If u.Contains("HKG") Then
            Return "HKHKG"
        End If
        Return ""
    End Function

    Private Sub CalculateShipment()
        Try
            Dim mode As String = Me.cboCalcMode.Text
            Dim pol As String = Me.txtCalcPol.Text.Trim()
            Dim pod As String = Me.txtCalcPod.Text.Trim()
            Dim term As String = Me.cboCalcTerm.Text.Trim()
            Dim contType As String = Me.txtCalcContType.Text.Trim()
            Dim contQty As Decimal = 1
            Dim cbm As Decimal = 0
            Dim kg As Decimal = 0
            Decimal.TryParse(Me.txtCalcContQty.Text.Trim(), contQty)
            Decimal.TryParse(Me.txtCalcCbm.Text.Trim(), cbm)
            Decimal.TryParse(Me.txtCalcKg.Text.Trim(), kg)
            If contQty <= 0 Then
                contQty = 1
            End If

            Dim tableName As String = GetTableName(mode)
            Dim sql As String = "SELECT r.*, b.QuotationName, b.ValidMonth " &
                "FROM " & tableName & " r " &
                "INNER JOIN FreightQuotationBatch b ON b.BatchId = r.BatchId " &
                "WHERE b.Continued = 1 AND r.Continued = 1 "
            If pol <> "" Then
                If mode = "AIR-FOB" Then
                    sql &= "AND ISNULL(r.Origin,'') LIKE '%" & SqlSafe(pol) & "%' "
                Else
                    sql &= "AND ISNULL(r.PolCode,'') LIKE '%" & SqlSafe(pol) & "%' "
                End If
            End If
            If pod <> "" Then
                If mode = "AIR-FOB" Then
                    sql &= "AND ISNULL(r.Dest,'') LIKE '%" & SqlSafe(pod) & "%' "
                ElseIf mode <> "AIR-EXW" Then
                    sql &= "AND ISNULL(r.Pod,'') LIKE '%" & SqlSafe(pod) & "%' "
                End If
            End If
            If term <> "" AndAlso mode.StartsWith("FCL") Then
                sql &= "AND ISNULL(r.Term,'') LIKE '%" & SqlSafe(term) & "%' "
            End If
            If mode.StartsWith("FCL") AndAlso contType <> "" Then
                Dim contKey As String = contType.ToUpperInvariant().Replace("DC", "FT").Replace("GP", "FT")
                sql &= "AND ISNULL(r.ContType,'') LIKE '%" & SqlSafe(contKey) & "%' "
            End If
            sql &= "ORDER BY ISNULL(r.SellTotal, 999999), ISNULL(r.BuyTotal, 999999)"

            Dim src As System.Data.DataTable = ReadTable(sql)
            If src Is Nothing Then
                src = New System.Data.DataTable()
            End If

            If mode.StartsWith("LCL") AndAlso cbm > 0 Then
                src = FilterLclByCbm(src, cbm)
            End If

            Dim result As New System.Data.DataTable()
            result.Columns.Add("Agent")
            result.Columns.Add("Carrier_Airline")
            result.Columns.Add("POL")
            result.Columns.Add("POD")
            result.Columns.Add("Type")
            result.Columns.Add("Term")
            result.Columns.Add("Currency")
            result.Columns.Add("BuyUnit", GetType(Decimal))
            result.Columns.Add("SellUnit", GetType(Decimal))
            result.Columns.Add("Qty", GetType(Decimal))
            result.Columns.Add("BuyAmount", GetType(Decimal))
            result.Columns.Add("SellAmount", GetType(Decimal))
            result.Columns.Add("PNL", GetType(Decimal))
            result.Columns.Add("Transit")
            result.Columns.Add("Quotation")

            Dim bestBuy As Decimal = 0
            Dim bestSell As Decimal = 0
            Dim first As Boolean = True

            For Each row As System.Data.DataRow In src.Rows
                Dim buyUnit As Decimal = GetRowDec(row, New String() {"BuyTotal", "BuyTotalPod", "BuyPlus45"})
                Dim sellUnit As Decimal = GetRowDec(row, New String() {"SellTotal", "SellPlus45"})
                If mode.StartsWith("AIR") Then
                    buyUnit = PickAirRate(row, kg, True)
                    sellUnit = PickAirRate(row, kg, False)
                End If

                Dim qty As Decimal = contQty
                If mode.StartsWith("LCL") Then
                    If cbm > 0 Then
                        qty = cbm
                    End If
                ElseIf mode.StartsWith("AIR") Then
                    qty = kg
                End If

                Dim buyAmt As Decimal = buyUnit * qty
                Dim sellAmt As Decimal = sellUnit * qty
                If mode.StartsWith("LCL") Then
                    Dim buyAllIn As Decimal = GetRowDec(row, New String() {"BuyTotalPod"})
                    Dim sellAllIn As Decimal = GetRowDec(row, New String() {"SellTotal"})
                    If buyAllIn > 0 Then
                        buyAmt = buyAllIn
                        buyUnit = buyAllIn
                        qty = 1
                    End If
                    If sellAllIn > 0 Then
                        sellAmt = sellAllIn
                        sellUnit = sellAllIn
                    End If
                End If

                Dim nr As System.Data.DataRow = result.NewRow()
                nr("Agent") = GetRowText(row, "Agent")
                If mode.StartsWith("AIR") Then
                    nr("Carrier_Airline") = GetRowText(row, "Airline")
                    nr("POL") = GetRowText(row, "Origin")
                    If nr("POL").ToString() = "" Then
                        nr("POL") = GetRowText(row, "PolCode")
                    End If
                    nr("POD") = GetRowText(row, "Dest")
                    nr("Type") = GetRowText(row, "CargoType")
                Else
                    nr("Carrier_Airline") = GetRowText(row, "Carrier")
                    If nr("Carrier_Airline").ToString() = "" Then
                        nr("Carrier_Airline") = GetRowText(row, "ShippingLine")
                    End If
                    nr("POL") = GetRowText(row, "PolCode")
                    nr("POD") = GetRowText(row, "Pod")
                    nr("Type") = GetRowText(row, "ContType")
                    If nr("Type").ToString() = "" Then
                        nr("Type") = GetRowText(row, "CargoType")
                    End If
                End If
                nr("Term") = GetRowText(row, "Term")
                nr("Currency") = GetRowText(row, "Currency")
                nr("BuyUnit") = buyUnit
                nr("SellUnit") = sellUnit
                nr("Qty") = qty
                nr("BuyAmount") = buyAmt
                nr("SellAmount") = sellAmt
                nr("PNL") = sellAmt - buyAmt
                nr("Transit") = GetRowText(row, "TransitTime")
                nr("Quotation") = GetRowText(row, "QuotationName")
                result.Rows.Add(nr)

                If first OrElse (sellAmt > 0 AndAlso sellAmt < bestSell) OrElse (bestSell = 0 AndAlso buyAmt < bestBuy) Then
                    bestBuy = buyAmt
                    bestSell = sellAmt
                    first = False
                End If
            Next

            Me.dgdCalc.DataSource = result
            Me.dgdCalc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
            Dim cur As String = "USD"
            If result.Rows.Count > 0 Then
                cur = result.Rows(0)("Currency").ToString()
            End If
            Me.lblCalc.Text = "Tim thay " & result.Rows.Count.ToString() & " dong tariff. " &
                "Gia ban tot nhat ~ " & bestSell.ToString("N2") & " " & cur &
                "  |  Gia mua tot nhat ~ " & bestBuy.ToString("N2") & " " & cur &
                "  |  PNL ~ " & (bestSell - bestBuy).ToString("N2")
            If result.Rows.Count = 0 Then
                Me.lblCalc.Text = "Khong khop tariff. Kiem tra POL/POD (file nay thuong de trong), Term, loai FCL/LCL, ContType 20FT/40FT."
            End If
        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try
    End Sub

    Private Function FilterLclByCbm(ByVal src As System.Data.DataTable, ByVal cbm As Decimal) As System.Data.DataTable
        If src.Columns.Contains("LevelLimitVolume") = False Then
            Return src
        End If
        Dim copy As System.Data.DataTable = src.Clone()
        For Each row As System.Data.DataRow In src.Rows
            If CbmInLevel(row("LevelLimitVolume").ToString(), cbm) Then
                copy.ImportRow(row)
            End If
        Next
        If copy.Rows.Count = 0 Then
            Return src
        End If
        Return copy
    End Function

    Private Function CbmInLevel(ByVal levelText As String, ByVal cbm As Decimal) As Boolean
        Dim s As String = levelText.ToUpperInvariant().Replace("CBM", "").Trim()
        If s.StartsWith("<") Then
            Dim maxv As Decimal = 0
            Decimal.TryParse(s.Replace("<", "").Trim(), maxv)
            Return cbm < maxv OrElse maxv = 0
        End If
        Dim parts() As String = s.Split("-"c)
        If parts.Length = 2 Then
            Dim minv As Decimal = 0
            Dim maxv As Decimal = 0
            Decimal.TryParse(parts(0).Trim(), minv)
            Decimal.TryParse(parts(1).Trim(), maxv)
            Return cbm >= minv AndAlso cbm <= maxv
        End If
        Return True
    End Function

    Private Function PickAirRate(ByVal row As System.Data.DataRow, ByVal kg As Decimal, ByVal isBuy As Boolean) As Decimal
        Dim cols() As String
        If row.Table.Columns.Contains("BuyAf45") Then
            If isBuy Then
                cols = New String() {"BuyAf1000", "BuyAf500", "BuyAf300", "BuyAf100", "BuyAf45"}
            Else
                cols = New String() {"SellAf1000", "SellAf500", "SellAf300", "SellAf100", "SellAf45"}
            End If
        Else
            If isBuy Then
                cols = New String() {"BuyPlus1000", "BuyPlus500", "BuyPlus300", "BuyPlus100", "BuyPlus45"}
            Else
                cols = New String() {"SellPlus1000", "SellPlus500", "SellPlus300", "SellPlus100", "SellPlus45"}
            End If
        End If
        Dim breaks() As Decimal = New Decimal() {1000D, 500D, 300D, 100D, 45D}
        For i As Integer = 0 To breaks.Length - 1
            If kg >= breaks(i) Then
                Dim v As Decimal = GetRowDec(row, New String() {cols(i)})
                If v > 0 Then
                    Return v
                End If
            End If
        Next
        Return GetRowDec(row, cols)
    End Function

    Private Function GetRowDec(ByVal row As System.Data.DataRow, ByVal names() As String) As Decimal
        For Each name As String In names
            If row.Table.Columns.Contains(name) AndAlso Not IsDBNull(row(name)) Then
                Dim d As Decimal = 0
                If Decimal.TryParse(row(name).ToString(), d) Then
                    Return d
                End If
            End If
        Next
        Return 0
    End Function

    Private Function GetRowText(ByVal row As System.Data.DataRow, ByVal name As String) As String
        If row.Table.Columns.Contains(name) AndAlso Not IsDBNull(row(name)) Then
            Return row(name).ToString()
        End If
        Return ""
    End Function

End Class
