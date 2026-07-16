Imports Excel

Public Class frmImportSeaImportJob

    Private Const StartRow As Integer = 5
    Private Const DefaultBranch As String = "SGN"
    Private Const DefaultGsc As String = "C"

    Private Sub frmImportSeaImportJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtSheetName.Items.Clear()
        Me.lblNote.Text = "Du lieu import bat dau tu dong 5 trong file Excel template."
    End Sub

    Private Sub cmdBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowser.Click
        Try
            If Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Me.txtFileName.Text = Me.OpenFileDialog1.FileName
                LoadSheetNames(Me.txtFileName.Text.Trim, "UPLOAD-SUA")
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
        ImportSeaImportData()
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

    Private Sub ImportSeaImportData()
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

                Dim mot As String = GetCellText(ws, "C", rowIndex)
                Dim gflc As String = MapMotToGflc(mot)
                If gflc = "" Then
                    skipped += 1
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong xac dinh duoc gFLC tu cot C.")
                    Continue For
                End If

                Dim polFull As String = GetCellText(ws, "N", rowIndex)
                Dim podFull As String = GetCellText(ws, "O", rowIndex)
                Dim refNo As String = GenerateRefNumber(gflc, DefaultGsc, polFull, podFull)
                If refNo = "" Then
                    skipped += 1
                    errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tao duoc Ref.")
                    Continue For
                End If

                Dim blibId As String = ""
                If Not InsertInboundRecord(ws, rowIndex, refNo, gflc, DefaultGsc, sttBase + imported, blibId, errors) Then
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
            Dim ds As DataSet = ReadDataSet("select count(*) as dem from inbound")
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
            Dim ds As DataSet = ReadDataSet("SELECT TOP 1 BLIB_ID FROM inbound WHERE hbl ='" & SqlSafe(hbl) & "' and continued=1")
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

    Private Function MapMotToGflc(ByVal mot As String) As String
        Dim value As String = UCase(mot.Trim())
        If value = "" Then
            Return ""
        End If
        If value.StartsWith("LCL") Or value = "L" Then
            Return "L"
        End If
        If value.StartsWith("FCL") Or value = "F" Then
            Return "F"
        End If
        If value.StartsWith("CON") Or value = "C" Then
            Return "C"
        End If
        Return value.Substring(0, 1)
    End Function

    Private Function GenerateRefNumber(ByVal gflc As String, ByVal gsc As String, ByVal polFull As String, ByVal podFull As String) As String
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

            Dim nam As String = CDate(Getdate()).Year.ToString.Replace("20", "")
            Dim cboCode As String = gflc & "I"
            Dim pol As String = ""
            Dim pod As String = ""

            Try
                If polFull.Trim().Length > 2 Then
                    pol = polFull.Trim().Remove(0, 2)
                Else
                    pol = polFull.Trim()
                End If
            Catch ex As Exception
                pol = polFull.Trim()
            End Try

            Try
                If podFull.Trim().Length > 2 Then
                    pod = podFull.Trim().Remove(0, 2)
                Else
                    pod = podFull.Trim()
                End If
            Catch ex As Exception
                pod = podFull.Trim()
            End Try

            Dim so As String = ""
            If gflc = "F" And gsc = "C" And gNhom = "AGENCY-IMPORT" Then
                so = GetBookingNumberFromDB_new("ref_FC_AGENCYIMPORT")
            ElseIf gflc = "L" And gsc = "C" And gNhom = "AGENCY-IMPORT" Then
                so = GetBookingNumberFromDB_new("ref_LC_AGENCYIMPORT")
            ElseIf gflc = "C" And gsc = "C" And gNhom = "AGENCY-IMPORT" Then
                so = GetBookingNumberFromDB_new("ref_CC_AGENCYIMPORT")
            ElseIf gflc = "F" And gsc = "S" And gNhom = "AGENCY-IMPORT" Then
                so = GetBookingNumberFromDB_new("ref_FS_AGENCYIMPORT")
            End If

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

            Return cboCode & pol & pod & nam & thangsosanh & sokhong & so
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return ""
        End Try
    End Function

    Private Function InsertInboundRecord(ByVal ws As _Worksheet, ByVal rowIndex As Integer, ByVal refNo As String, ByVal gflc As String, ByVal gsc As String, ByVal stt As Integer, ByRef blibId As String, ByVal errors As System.Text.StringBuilder) As Boolean
        Dim rs As New ADODB.Recordset
        Try
            Dim shortname As String = GetCellText(ws, "B", rowIndex)
            Dim customerId As String = GetCustomerIdByShortname(shortname)
            If customerId = "" Then
                errors.AppendLine("Dong " & rowIndex.ToString() & ": Khong tim thay customer voi shortname '" & shortname & "'.")
                Return False
            End If

            rs.Open("SELECT TOP 1 * FROM inbound", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.AddNew()

            blibId = NewId()
            rs.Fields("BLIB_ID").Value = blibId
            rs.Fields("ref").Value = refNo
            rs.Fields("hbl").Value = GetCellText(ws, "J", rowIndex)

            Dim mbl As String = GetCellText(ws, "I", rowIndex)
            If mbl <> "" Then
                rs.Fields("Mbl").Value = mbl
            End If

            rs.Fields("gFLC").Value = gflc
            rs.Fields("gSC").Value = gsc
            rs.Fields("CY_CFS_ITEM").Value = GetCellText(ws, "D", rowIndex)
            rs.Fields("pic_report").Value = GetCellText(ws, "E", rowIndex)
            rs.Fields("lot").Value = UCase(GetCellText(ws, "F", rowIndex))
            rs.Fields("shipper").Value = GetCellText(ws, "G", rowIndex)
            rs.Fields("consignee").Value = GetCellText(ws, "H", rowIndex)
            rs.Fields("AgencyName").Value = GetCellText(ws, "A", rowIndex)

            Dim soKienK As String = ""
            Dim pkgTypeK As String = ""
            ParsePackageInfo(GetCellText(ws, "K", rowIndex), soKienK, pkgTypeK)
            Try
                rs.Fields("tongSoKienLoaiKien").Value = soKienK
            Catch ex As Exception
            End Try
            Try
                rs.Fields("loaikien").Value = pkgTypeK
            Catch ex As Exception
            End Try

            Dim polCode As String = GetCellText(ws, "N", rowIndex)
            Dim podCode As String = GetCellText(ws, "O", rowIndex)
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
            Try
                rs.Fields("cangGiaohang").Value = polName
            Catch ex As Exception
            End Try
            Try
                rs.Fields("cangDoHang").Value = podName
            Catch ex As Exception
            End Try
            Try
                rs.Fields("diadiemgiaohang").Value = podName
            Catch ex As Exception
            End Try
            Try
                rs.Fields("cangXephang").Value = polName & "_" & polName
            Catch ex As Exception
            End Try

            rs.Fields("vessel").Value = GetCellText(ws, "V", rowIndex)
            rs.Fields("voyage").Value = GetCellText(ws, "W", rowIndex)
            rs.Fields("shippingline").Value = GetCellText(ws, "X", rowIndex)
            rs.Fields("kho").Value = GetCellText(ws, "Y", rowIndex)
            rs.Fields("remarks").Value = GetCellText(ws, "Z", rowIndex)
            rs.Fields("DESCRIPTION").Value = GetCellText(ws, "AA", rowIndex)
            rs.Fields("closeFile").Value = (UCase(GetCellText(ws, "AB", rowIndex)) = "TRUE")
            rs.Fields("status").Value = GetCellText(ws, "AC", rowIndex)

            If gsc = "C" Then
                rs.Fields("nvocc").Value = False
            Else
                rs.Fields("nvocc").Value = True
            End If

            If gflc = "F" Then
                rs.Fields("FCL").Value = True
            ElseIf gflc = "L" Then
                rs.Fields("LCL").Value = True
            ElseIf gflc = "C" Then
                rs.Fields("consol").Value = True
            End If

            rs.Fields("air").Value = False

            Try
                rs.Fields("customerid_showtc").Value = "{" & customerId.Replace("{", "").Replace("}", "") & "}"
            Catch ex As Exception
                rs.Fields("customerid_showTC").Value = "{" & customerId.Replace("{", "").Replace("}", "") & "}"
            End Try

            SetDateField(rs, "cargo_ready", GetCellDate(ws, "P", rowIndex))
            SetDateField(rs, "closing", GetCellDate(ws, "Q", rowIndex))
            Dim sailingDateInsert As Date? = GetCellDate(ws, "R", rowIndex)
            SetDateField(rs, "SAILINGDATE", sailingDateInsert)
            SetDateField(rs, "ngayPhatHanhVanDon", sailingDateInsert)
            SetDateField(rs, "ngayphathanhvandongoc", sailingDateInsert)
            SetDateField(rs, "ngaykhoihanh", sailingDateInsert)

            Dim etaDate As Date? = GetCellDate(ws, "S", rowIndex)
            If etaDate.HasValue Then
                SetDateField(rs, "ETA", etaDate)
                Try
                    rs.Fields("eta").Value = ddMMMyyyy(etaDate.Value)
                    rs.Fields("datereport").Value = ddMMMyyyy(etaDate.Value)
                    rs.Fields("InvoiceRequestDate").Value = ddMMMyyyy(etaDate.Value)
                Catch ex As Exception
                End Try
            End If

            rs.Fields("stt").Value = stt
            rs.Fields("branch").Value = DefaultBranch
            rs.Fields("nodebit").Value = "DN-" & refNo
            rs.Fields("nocredit").Value = "CN-" & refNo

            Try
                rs.Fields("NHOM").Value = gNhom
            Catch ex As Exception
                Try
                    rs.Fields("nhom").Value = gNhom
                Catch
                End Try
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
            rs.Open("SELECT TOP 1 * FROM inbound WHERE BLIB_ID='" & SqlSafe(blibId) & "' and continued=1", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
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

            Dim mot As String = GetCellText(ws, "C", rowIndex)
            Dim gflc As String = MapMotToGflc(mot)
            If gflc <> "" Then
                rs.Fields("gFLC").Value = gflc
                Try
                    rs.Fields("FCL").Value = (gflc = "F")
                    rs.Fields("LCL").Value = (gflc = "L")
                    rs.Fields("consol").Value = (gflc = "C")
                Catch ex As Exception
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

            Dim pkgTextK As String = GetCellText(ws, "K", rowIndex)
            If pkgTextK <> "" Then
                Dim soKienKUpd As String = ""
                Dim pkgTypeKUpd As String = ""
                ParsePackageInfo(pkgTextK, soKienKUpd, pkgTypeKUpd)
                SetFieldIfHasText(rs, "tongSoKienLoaiKien", soKienKUpd)
                SetFieldIfHasText(rs, "loaikien", pkgTypeKUpd)
            End If

            Dim polCode As String = GetCellText(ws, "N", rowIndex)
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
                Try
                    rs.Fields("cangGiaohang").Value = polName
                Catch ex As Exception
                End Try
                Try
                    rs.Fields("cangXephang").Value = polName & "_" & polName
                Catch ex As Exception
                End Try
            End If

            Dim podCode As String = GetCellText(ws, "O", rowIndex)
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
                Try
                    rs.Fields("cangDoHang").Value = podName
                Catch ex As Exception
                End Try
                Try
                    rs.Fields("diadiemgiaohang").Value = podName
                Catch ex As Exception
                End Try
            End If

            SetFieldIfHasText(rs, "vessel", GetCellText(ws, "V", rowIndex))
            SetFieldIfHasText(rs, "voyage", GetCellText(ws, "W", rowIndex))
            SetFieldIfHasText(rs, "shippingline", GetCellText(ws, "X", rowIndex))
            SetFieldIfHasText(rs, "kho", GetCellText(ws, "Y", rowIndex))
            SetFieldIfHasText(rs, "remarks", GetCellText(ws, "Z", rowIndex))
            SetFieldIfHasText(rs, "DESCRIPTION", GetCellText(ws, "AA", rowIndex))

            Dim closeFileText As String = GetCellText(ws, "AB", rowIndex)
            If closeFileText <> "" Then
                rs.Fields("closeFile").Value = (UCase(closeFileText) = "TRUE")
            End If

            SetFieldIfHasText(rs, "status", GetCellText(ws, "AC", rowIndex))

            Dim cargoReady As Date? = GetCellDate(ws, "P", rowIndex)
            If cargoReady.HasValue Then
                SetDateField(rs, "cargo_ready", cargoReady)
            End If

            Dim closingDate As Date? = GetCellDate(ws, "Q", rowIndex)
            If closingDate.HasValue Then
                SetDateField(rs, "closing", closingDate)
            End If

            Dim sailingDate As Date? = GetCellDate(ws, "R", rowIndex)
            If sailingDate.HasValue Then
                SetDateField(rs, "SAILINGDATE", sailingDate)
                SetDateField(rs, "ngayPhatHanhVanDon", sailingDate)
                SetDateField(rs, "ngayphathanhvandongoc", sailingDate)
                SetDateField(rs, "ngaykhoihanh", sailingDate)
            End If

            Dim etaDate As Date? = GetCellDate(ws, "S", rowIndex)
            If etaDate.HasValue Then
                SetDateField(rs, "ETA", etaDate)
                Try
                    rs.Fields("eta").Value = ddMMMyyyy(etaDate.Value)
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
            Dim containerNo As String = GetCellText(ws, "T", rowIndex)
            Dim seal As String = GetCellText(ws, "U", rowIndex)

            If pkgText = "" AndAlso soKg = "" AndAlso soKhoi = "" AndAlso containerNo = "" AndAlso seal = "" Then
                Return True
            End If

            rs.Open("SELECT TOP 1 * FROM containerrepair WHERE inboundContainersID='" & SqlSafe(blibId) & "' OR inboundID='" & SqlSafe(blibId) & "'", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
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
            If containerNo <> "" Then
                rs.Fields("containerno").Value = containerNo
            End If
            If seal <> "" Then
                rs.Fields("seal").Value = seal
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
            rs.Fields("inboundContainersID").Value = blibId
            rs.Fields("inboundID").Value = getID(blibId)
            rs.Fields("sokien").Value = soKien
            rs.Fields("type").Value = pkgType
            rs.Fields("sokg").Value = GetCellText(ws, "L", rowIndex)
            rs.Fields("sokhoi").Value = GetCellText(ws, "M", rowIndex)
            rs.Fields("containerno").Value = GetCellText(ws, "T", rowIndex)
            rs.Fields("seal").Value = GetCellText(ws, "U", rowIndex)

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
