Imports Excel

Public Class frmImportAirImportJob

    Private Const StartRow As Integer = 5
    Private Const DefaultBranch As String = "SGN"
    Private Const DefaultTat As String = "S"

    Private Sub frmImportAirImportJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtSheetName.Items.Clear()
        Me.lblNote.Text = "Du lieu import bat dau tu dong 5 trong file Excel template."
    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        Try
            If Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Me.txtFileName.Text = Me.OpenFileDialog1.FileName
                LoadSheetNames(Me.txtFileName.Text.Trim, "UPLOAD-SỬA")
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If Me.txtFileName.Text.Trim = "" Then
            MsgBox("Nhap Browser chon file truoc khi Import.")
            Return
        End If
        If Me.txtSheetName.Text.Trim = "" Then
            MsgBox("Chon ten Sheet trong file da chon.")
            Return
        End If
        ImportAirImportData()
    End Sub

    Private Sub LoadSheetNames(ByVal filePath As String, ByVal preferredSheet As String)
        Me.txtSheetName.Items.Clear()
        Me.txtSheetName.SelectedIndex = -1

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

            Dim preferredIndex As Integer = -1
            For i As Integer = 1 To workbook.Worksheets.Count
                Dim ws As _Worksheet = CType(workbook.Worksheets(i), _Worksheet)
                Dim sheetName As String = ws.Name
                Me.txtSheetName.Items.Add(sheetName)
                If preferredIndex < 0 AndAlso String.Equals(sheetName, preferredSheet, StringComparison.OrdinalIgnoreCase) Then
                    preferredIndex = Me.txtSheetName.Items.Count - 1
                End If
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)
            Next

            If Me.txtSheetName.Items.Count > 0 Then
                If preferredIndex >= 0 Then
                    Me.txtSheetName.SelectedIndex = preferredIndex
                Else
                    Me.txtSheetName.SelectedIndex = 0
                End If
            End If
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

    Private Sub ImportAirImportData()
        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Dim imported As Integer = 0
        Dim updated As Integer = 0
        Dim skipped As Integer = 0
        Dim errors As New System.Text.StringBuilder()

        Me.cmdOK.Enabled = False
        Me.cmdCancel.Enabled = False
        Me.cmdBrowser.Enabled = False

        Try
            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False

            workbook = app.Workbooks.Open(Me.txtFileName.Text.Trim)
            Dim ws As _Worksheet = Nothing
            Try
                ws = workbook.Worksheets(Me.txtSheetName.Text.Trim)
            Catch ex As Exception
                DisplayMessage(True, "Ten Sheet khong hop le, vui long kiem tra lai.")
                Return
            End Try

            Dim lastRow As Integer = FindLastDataRow(ws)
            If lastRow < StartRow Then
                DisplayMessage(True, "Khong tim thay du lieu tu dong 5 trong file Excel.")
                Return
            End If

            Dim totalRows As Integer = lastRow - StartRow + 1
            Me.prbImport.Minimum = 0
            Me.prbImport.Maximum = totalRows
            Me.prbImport.Value = 0

            Dim sttBase As Integer = GetInboundSttBase()

            For rowIndex As Integer = StartRow To lastRow
                Me.prbImport.Value = rowIndex - StartRow + 1
                Me.lblStatus.Text = "Dang import dong " & rowIndex.ToString() & "/" & lastRow.ToString()
                System.Windows.Forms.Application.DoEvents()

                Dim hbl As String = GetCellText(ws, "J", rowIndex)
                If hbl = "" Then
                    skipped += 1
                    Continue For
                End If

                Dim existingBlibId As String = GetInboundBlibIdByHbl(hbl)
                If existingBlibId <> "" Then
                    If UpdateInboundRecord(ws, rowIndex, existingBlibId, errors) Then
                        UpdateContainerRecord(ws, rowIndex, existingBlibId, errors)
                        updated += 1
                    Else
                        skipped += 1
                    End If
                    Continue For
                End If

                Dim polCode As String = GetCellText(ws, "O", rowIndex)
                Dim podCode As String = GetCellText(ws, "P", rowIndex)
                Dim refNo As String = GenerateRefNumber(polCode, podCode)
                If refNo = "" Then
                    skipped += 1
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tao duoc Ref.")
                    Continue For
                End If

                Dim blibId As String = ""
                If Not InsertInboundRecord(ws, rowIndex, refNo, sttBase + imported, blibId, errors) Then
                    skipped += 1
                    Continue For
                End If

                If Not InsertContainerRecord(ws, rowIndex, blibId, errors) Then
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Tao inbound thanh cong nhung loi khi tao container.")
                End If

                imported += 1
            Next

            Dim message As String = "Import hoan tat." & vbCrLf &
                "Them moi: " & imported.ToString() & vbCrLf &
                "Cap nhat: " & updated.ToString() & vbCrLf &
                "Bo qua/Loi: " & skipped.ToString()
            If errors.Length > 0 Then
                message &= vbCrLf & vbCrLf & errors.ToString()
            End If
            DisplayMessage(False, message)
        Catch ex As Exception
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

    Private Function FindLastDataRow(ByVal ws As _Worksheet) As Integer
        Dim lastRow As Integer = StartRow
        For rowIndex As Integer = StartRow To 5000
            Dim hbl As String = GetCellText(ws, "J", rowIndex)
            Dim shortname As String = GetCellText(ws, "B", rowIndex)
            If hbl = "" AndAlso shortname = "" Then
                Exit For
            End If
            lastRow = rowIndex
        Next
        Return lastRow
    End Function

    Private Function GetInboundSttBase() As Integer
        Try
            Dim ds As DataSet = ReadDataSet("select count(*) as dem from inbound_OverseaAirImport")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item("dem").ToString())
            End If
        Catch ex As Exception
        End Try
        Return 0
    End Function

    Private Function HblExists(ByVal hbl As String) As Boolean
        Return GetInboundBlibIdByHbl(hbl) <> ""
    End Function

    Private Function GetInboundBlibIdByHbl(ByVal hbl As String) As String
        Try
            Dim ds As DataSet = ReadDataSet("SELECT TOP 1 BLIB_ID FROM inbound_OverseaAirImport WHERE hbl ='" & SqlSafe(hbl) & "' and continued=1")
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("BLIB_ID").ToString()
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Private Function GetCustomerIdByShortname(ByVal shortname As String) As String
        If shortname.Trim = "" Then
            Return ""
        End If
        Try
            Dim sql As String = "select top 1 customer_id from customer where shortname='" & SqlSafe(shortname.Trim) & "' and continued=1"
            Dim ds As DataSet = ReadDataSet(sql)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("customer_id").ToString()
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Private Function GetPortNameByCode(ByVal portCode As String) As String
        If portCode.Trim = "" Then
            Return ""
        End If
        Try
            Dim sql As String = "select top 1 port from port where port_code='" & SqlSafe(portCode.Trim) & "'"
            Dim ds As DataSet = ReadDataSet(sql)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0).Item("port").ToString()
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Private Function GenerateRefNumber(ByVal polCode As String, ByVal podCode As String) As String
        Try
            Dim thanghientai As String = CDate(Getdate()).Date.Month.ToString()
            Dim thangsosanh As String = ""
            Select Case UCase(thanghientai)
                Case "1" : thangsosanh = "01"
                Case "2" : thangsosanh = "02"
                Case "3" : thangsosanh = "03"
                Case "4" : thangsosanh = "04"
                Case "5" : thangsosanh = "05"
                Case "6" : thangsosanh = "06"
                Case "7" : thangsosanh = "07"
                Case "8" : thangsosanh = "08"
                Case "9" : thangsosanh = "09"
                Case "10" : thangsosanh = "10"
                Case "11" : thangsosanh = "11"
                Case "12" : thangsosanh = "12"
            End Select

            Dim nam As String = CDate(Getdate()).Year.ToString()
            Dim so As String = GetBookingNumberFromDB_new("ref_AirImport")
            If so = "" Then
                Return ""
            End If

            Dim sokhong As String = ""
            If CInt(so) < 10 Then
                sokhong = "000"
            ElseIf CInt(so) > 9 And CInt(so) < 100 Then
                sokhong = "00"
            ElseIf CInt(so) > 99 And CInt(so) < 1000 Then
                sokhong = "0"
            ElseIf CInt(so) > 999 And CInt(so) < 10000 Then
                sokhong = "0"
            End If

            Return DefaultBranch & DefaultTat & polCode.Trim() & podCode.Trim() & nam & thangsosanh & sokhong & so
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return ""
        End Try
    End Function

    Private Function InsertInboundRecord(ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal refNo As String, ByVal stt As Integer, ByRef blibId As String, ByVal errors As System.Text.StringBuilder) As Boolean
        Dim rs As New ADODB.Recordset
        Try
            Dim shortname As String = GetCellText(ws, "B", rowIndex)
            Dim customerId As String = GetCustomerIdByShortname(shortname)
            If customerId = "" Then
                errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay customer voi shortname '" & shortname & "'.")
                Return False
            End If

            rs.Open("SELECT TOP 1 * FROM inbound_OverseaAirImport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.AddNew()

            blibId = NewId()
            rs.Fields("BLIB_ID").Value = blibId
            rs.Fields("ref").Value = refNo
            rs.Fields("hbl").Value = GetCellText(ws, "J", rowIndex)

            Dim mbl As String = GetCellText(ws, "I", rowIndex)
            If mbl <> "" Then
                rs.Fields("Mbl").Value = mbl
            End If

            rs.Fields("CY_CFS_ITEM").Value = GetCellText(ws, "D", rowIndex)
            rs.Fields("pic_report").Value = GetCellText(ws, "E", rowIndex)
            rs.Fields("lot").Value = UCase(GetCellText(ws, "F", rowIndex))
            rs.Fields("shipper").Value = GetCellText(ws, "G", rowIndex)
            rs.Fields("consignee").Value = GetCellText(ws, "H", rowIndex)
            rs.Fields("AgencyName").Value = GetCellText(ws, "A", rowIndex)

            Dim polCode As String = GetCellText(ws, "O", rowIndex)
            Dim podCode As String = GetCellText(ws, "P", rowIndex)
            Dim polName As String = GetPortNameByCode(polCode)
            Dim podName As String = GetPortNameByCode(podCode)
            If polCode <> "" AndAlso polName = "" Then
                errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay port voi port_code '" & polCode & "' (POL).")
                Return False
            End If
            If podCode <> "" AndAlso podName = "" Then
                errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay port voi port_code '" & podCode & "' (POD).")
                Return False
            End If
            Try
                rs.Fields("polCode").Value = polCode
            Catch ex As Exception
            End Try
            Try
                rs.Fields("podCode").Value = podCode
            Catch ex As Exception
            End Try
            rs.Fields("pol").Value = polName
            rs.Fields("pod").Value = podName

            rs.Fields("vessel").Value = GetCellText(ws, "U", rowIndex)
            rs.Fields("shippingline").Value = GetCellText(ws, "V", rowIndex)
            rs.Fields("kho").Value = GetCellText(ws, "W", rowIndex)
            rs.Fields("remarks").Value = GetCellText(ws, "X", rowIndex)
            rs.Fields("closeFile").Value = (UCase(GetCellText(ws, "Y", rowIndex)) = "TRUE")
            rs.Fields("status").Value = GetCellText(ws, "Z", rowIndex)

            Try
                rs.Fields("customerid_showtc").Value = "{" & customerId.Replace("{", "").Replace("}", "") & "}"
            Catch ex As Exception
                rs.Fields("customerid_showTC").Value = "{" & customerId.Replace("{", "").Replace("}", "") & "}"
            End Try

            SetDateField(rs, "cargo_ready", GetCellDate(ws, "Q", rowIndex))
            SetDateField(rs, "closing", GetCellDate(ws, "R", rowIndex))

            Dim etdDate As Date? = GetCellDate(ws, "S", rowIndex)
            If etdDate.HasValue Then
                SetDateField(rs, "SAILINGDATE", etdDate)
            End If

            Dim etaDate As Date? = GetCellDate(ws, "T", rowIndex)
            If etaDate.HasValue Then
                SetDateField(rs, "ETA", etaDate)
                Try
                    rs.Fields("datereport").Value = ddMMMyyyy(etaDate.Value)
                    rs.Fields("InvoiceRequestDate").Value = ddMMMyyyy(etaDate.Value)
                Catch ex As Exception
                End Try
            End If

            rs.Fields("stt").Value = stt
            rs.Fields("branch").Value = DefaultBranch
            rs.Fields("air").Value = True
            rs.Fields("nodebit").Value = "DN-" & refNo
            rs.Fields("nocredit").Value = "CN-" & refNo

            Try
                rs.Fields("NHOM").Value = gNhom
            Catch ex As Exception
            End Try

            rs.Update()
            rs.Close()
            Return True
        Catch ex As Exception
            errors.AppendLine("Dong " & rowIndex.ToString() & ": " & ex.Message)
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                    rs.Close()
                End If
            Catch
            End Try
            Return False
        End Try
    End Function

    Private Function UpdateInboundRecord(ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal blibId As String, ByVal errors As System.Text.StringBuilder) As Boolean
        Dim rs As New ADODB.Recordset
        Try
            rs.Open("SELECT TOP 1 * FROM inbound_OverseaAirImport WHERE BLIB_ID='" & SqlSafe(blibId) & "' and continued=1", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay inbound de update.")
                rs.Close()
                Return False
            End If

            Dim shortname As String = GetCellText(ws, "B", rowIndex)
            If shortname <> "" Then
                Dim customerId As String = GetCustomerIdByShortname(shortname)
                If customerId = "" Then
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay customer voi shortname '" & shortname & "'.")
                    rs.Close()
                    Return False
                End If
                Try
                    rs.Fields("customerid_showtc").Value = "{" & customerId.Replace("{", "").Replace("}", "") & "}"
                Catch ex As Exception
                    rs.Fields("customerid_showTC").Value = "{" & customerId.Replace("{", "").Replace("}", "") & "}"
                End Try
            End If

            SetFieldIfHasText(rs, "AgencyName", GetCellText(ws, "A", rowIndex))
            SetFieldIfHasText(rs, "CY_CFS_ITEM", GetCellText(ws, "D", rowIndex))
            SetFieldIfHasText(rs, "pic_report", GetCellText(ws, "E", rowIndex))

            Dim lot As String = GetCellText(ws, "F", rowIndex)
            If lot <> "" Then
                rs.Fields("lot").Value = UCase(lot)
            End If

            SetFieldIfHasText(rs, "shipper", GetCellText(ws, "G", rowIndex))
            SetFieldIfHasText(rs, "consignee", GetCellText(ws, "H", rowIndex))
            SetFieldIfHasText(rs, "Mbl", GetCellText(ws, "I", rowIndex))

            Dim polCode As String = GetCellText(ws, "O", rowIndex)
            If polCode <> "" Then
                Dim polName As String = GetPortNameByCode(polCode)
                If polName = "" Then
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay port voi port_code '" & polCode & "' (POL).")
                    rs.Close()
                    Return False
                End If
                Try
                    rs.Fields("polCode").Value = polCode
                Catch ex As Exception
                End Try
                rs.Fields("pol").Value = polName
            End If

            Dim podCode As String = GetCellText(ws, "P", rowIndex)
            If podCode <> "" Then
                Dim podName As String = GetPortNameByCode(podCode)
                If podName = "" Then
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay port voi port_code '" & podCode & "' (POD).")
                    rs.Close()
                    Return False
                End If
                Try
                    rs.Fields("podCode").Value = podCode
                Catch ex As Exception
                End Try
                rs.Fields("pod").Value = podName
            End If

            SetFieldIfHasText(rs, "vessel", GetCellText(ws, "U", rowIndex))
            SetFieldIfHasText(rs, "shippingline", GetCellText(ws, "V", rowIndex))
            SetFieldIfHasText(rs, "kho", GetCellText(ws, "W", rowIndex))
            SetFieldIfHasText(rs, "remarks", GetCellText(ws, "X", rowIndex))

            Dim closeFileText As String = GetCellText(ws, "Y", rowIndex)
            If closeFileText <> "" Then
                rs.Fields("closeFile").Value = (UCase(closeFileText) = "TRUE")
            End If

            SetFieldIfHasText(rs, "status", GetCellText(ws, "Z", rowIndex))

            Dim cargoReady As Date? = GetCellDate(ws, "Q", rowIndex)
            If cargoReady.HasValue Then
                SetDateField(rs, "cargo_ready", cargoReady)
            End If

            Dim closingDate As Date? = GetCellDate(ws, "R", rowIndex)
            If closingDate.HasValue Then
                SetDateField(rs, "closing", closingDate)
            End If

            Dim etdDate As Date? = GetCellDate(ws, "S", rowIndex)
            If etdDate.HasValue Then
                SetDateField(rs, "SAILINGDATE", etdDate)
            End If

            Dim etaDate As Date? = GetCellDate(ws, "T", rowIndex)
            If etaDate.HasValue Then
                SetDateField(rs, "ETA", etaDate)
                Try
                    rs.Fields("datereport").Value = ddMMMyyyy(etaDate.Value)
                    rs.Fields("InvoiceRequestDate").Value = ddMMMyyyy(etaDate.Value)
                Catch ex As Exception
                End Try
            End If

            rs.Update()
            rs.Close()
            Return True
        Catch ex As Exception
            errors.AppendLine("Dong " & rowIndex.ToString() & " (update): " & ex.Message)
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                    rs.Close()
                End If
            Catch
            End Try
            Return False
        End Try
    End Function

    Private Function UpdateContainerRecord(ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal blibId As String, ByVal errors As System.Text.StringBuilder) As Boolean
        Dim rs As New ADODB.Recordset
        Try
            Dim pkgText As String = GetCellText(ws, "K", rowIndex)
            Dim soKg As String = GetCellText(ws, "L", rowIndex)
            Dim soKhoi As String = GetCellText(ws, "M", rowIndex)
            Dim kgAvailable As String = GetCellText(ws, "N", rowIndex)

            If pkgText = "" AndAlso soKg = "" AndAlso soKhoi = "" AndAlso kgAvailable = "" Then
                Return True
            End If

            Dim inboundId As String = getID(blibId)
            rs.Open("SELECT TOP 1 * FROM containerrepair WHERE inboundID='" & SqlSafe(inboundId) & "' OR inboundID='" & SqlSafe(blibId) & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                rs.Close()
                Return InsertContainerRecord(ws, rowIndex, blibId, errors)
            End If

            If pkgText <> "" Then
                Dim soKien As String = ""
                Dim pkgType As String = ""
                ParsePackageInfo(pkgText, soKien, pkgType)
                If soKien <> "" Then
                    rs.Fields("sokien").Value = soKien
                End If
                If pkgType <> "" Then
                    rs.Fields("type").Value = pkgType
                End If
            End If

            If soKg <> "" Then
                rs.Fields("sokg").Value = soKg
            End If
            If soKhoi <> "" Then
                rs.Fields("sokhoi").Value = soKhoi
            End If
            If kgAvailable <> "" Then
                Try
                    rs.Fields("kgavailable").Value = kgAvailable
                Catch ex As Exception
                    Try
                        rs.Fields("chargeable").Value = kgAvailable
                    Catch
                    End Try
                End Try
            End If

            rs.Update()
            rs.Close()
            Return True
        Catch ex As Exception
            errors.AppendLine("Dong " & rowIndex.ToString() & " (update container): " & ex.Message)
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                    rs.Close()
                End If
            Catch
            End Try
            Return False
        End Try
    End Function

    Private Sub SetFieldIfHasText(ByVal rs As ADODB.Recordset, ByVal fieldName As String, ByVal value As String)
        If value = "" Then
            Return
        End If
        Try
            rs.Fields(fieldName).Value = value
        Catch ex As Exception
        End Try
    End Sub

    Private Function InsertContainerRecord(ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal blibId As String, ByVal errors As System.Text.StringBuilder) As Boolean
        Dim rs As New ADODB.Recordset
        Try
            Dim pkgText As String = GetCellText(ws, "K", rowIndex)
            Dim soKien As String = ""
            Dim pkgType As String = ""
            ParsePackageInfo(pkgText, soKien, pkgType)

            rs.Open("SELECT TOP 1 * FROM containerrepair", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.AddNew()
            rs.Fields("inboundContainersID").Value = NewId()
            rs.Fields("inboundID").Value = getID(blibId)
            rs.Fields("sokien").Value = soKien
            rs.Fields("type").Value = pkgType
            rs.Fields("sokg").Value = GetCellText(ws, "L", rowIndex)
            rs.Fields("sokhoi").Value = GetCellText(ws, "M", rowIndex)

            Try
                rs.Fields("kgavailable").Value = GetCellText(ws, "N", rowIndex)
            Catch ex As Exception
                Try
                    rs.Fields("chargeable").Value = GetCellText(ws, "N", rowIndex)
                Catch
                End Try
            End Try

            rs.Update()
            rs.Close()
            Return True
        Catch ex As Exception
            errors.AppendLine("Dong " & rowIndex.ToString() & " (container): " & ex.Message)
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                    rs.Close()
                End If
            Catch
            End Try
            Return False
        End Try
    End Function

    Private Sub ParsePackageInfo(ByVal pkgText As String, ByRef soKien As String, ByRef pkgType As String)
        soKien = ""
        pkgType = ""
        If pkgText.Trim = "" Then
            Return
        End If

        Dim parts() As String = pkgText.Trim().Split(New Char() {" "c}, 2, StringSplitOptions.RemoveEmptyEntries)
        If parts.Length > 0 Then
            soKien = parts(0).Trim()
        End If
        If parts.Length > 1 Then
            pkgType = parts(1).Trim()
        End If
    End Sub

    Private Sub SetDateField(ByVal rs As ADODB.Recordset, ByVal fieldName As String, ByVal value As Date?)
        If Not value.HasValue Then
            Return
        End If
        Try
            rs.Fields(fieldName).Value = ddMMMyyyy(value.Value)
        Catch ex As Exception
            rs.Fields(fieldName).Value = value.Value
        End Try
    End Sub

    Private Function GetCellText(ByVal ws As _Worksheet, ByVal col As String, ByVal rowIndex As Integer) As String
        Try
            Dim cellValue As Object = ws.Range(col & rowIndex.ToString()).Value2
            If cellValue Is Nothing Then
                Return ""
            End If
            Return cellValue.ToString().Trim()
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function GetCellDate(ByVal ws As _Worksheet, ByVal col As String, ByVal rowIndex As Integer) As Date?
        Try
            Dim cellValue As Object = ws.Range(col & rowIndex.ToString()).Value2
            If cellValue Is Nothing Then
                Return Nothing
            End If
            If TypeOf cellValue Is Double Then
                Return Date.FromOADate(CDbl(cellValue))
            End If
            If IsDate(cellValue) Then
                Return CDate(cellValue)
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Private Function SqlSafe(ByVal value As String) As String
        Return value.Replace("'", "''")
    End Function

End Class
