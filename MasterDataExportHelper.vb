Option Strict Off
Option Explicit On
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports Excel

Public Enum MasterDataShipmentKind
    AirImport = 0
    AirExport = 1
    SeaImport = 2
    SeaExport = 3
End Enum

Public Class MasterDataColumnInfo
    Public Key As String
    Public DisplayName As String
    Public DefaultColumnLetter As String
End Class

Public Class MasterDataExportContext
    Public Row As DataRow
    Public Kind As MasterDataShipmentKind
    Public ContainerRows As New List(Of DataRow)
    Public CompanyName As String = ""
    Public AgentName As String = ""
    Public BlibId As String = ""
    Public ContainerTypeText As String = ""
    Public ContainerQtyText As String = ""
    Public FreightTable As String = ""
    Public FreightIdColumn As String = ""
    Public IsAirFreightItem As Boolean
    Public ExportInUsd As Boolean
End Class

Public Module MasterDataExportHelper
    Public Const ExportColumnsParmId As String = "Frm_MasterData.ExportColumns"
    Public Const ConfigSeparator As String = "|"
    Public Const TemplateHeaderRow As Integer = 8
    Public Const TemplateHeaderBackupRow As Integer = 200
    Public Const DataStartRow As Integer = 11
    Public Const FirstTemplateColumnIndex As Integer = 2
    Public Const LastTemplateColumnIndex As Integer = 75

    Private templateHeaderCache As Dictionary(Of String, String)
    Private templateHeadersLoaded As Boolean = False

    Private ReadOnly AfItemId As String = "8D24860B-5B90-49B6-9C01-C3A244EEAA4C"
    Private ReadOnly OfItemId As String = "5512096C-87AB-42A3-A767-BBEF45F7B62A"
    Private ReadOnly BlfItemId As String = "720B337D-CCDB-4C3F-B80B-AC8832B1DB2F"

    Private ReadOnly DebitItemIds As New Dictionary(Of String, String) From {
        {"TRKO", "B70D388F-2C6E-4317-83CD-FCB03AF742B2"},
        {"ELF", "E4DE6E06-943E-4675-8F4B-C3E8999D9028"},
        {"HFO", "47448840-23BB-4811-9982-6B2CEB9DA31A"},
        {"THCO", "5D76C2E1-2990-4DE2-A3D9-716BDD14AE88"},
        {"CFSO", "75109072-2E25-4E0A-8C35-36FC8F368E22"},
        {"STUFF", "8A8E7068-2344-40E6-B24D-B19416A0F75D"},
        {"CDFO", "7A42FB16-CCFE-49F9-B1B2-4DDCA14FC5BC"},
        {"VGM", "9AEB4F22-CC2E-4F1C-B2C5-D8DCF123D33C"},
        {"BKF", "D777E578-776B-4EEB-82AD-1996DDF8823C"},
        {"TLXF", "9BEB8EBD-6CB3-4781-AB35-AF7B840EC35E"},
        {"GCO", "7FD2AC51-5610-4F36-973F-CBC78E58A5BA"},
        {"WHGC", "308B2D09-51CB-49B6-8380-867BD03AFD43"},
        {"PCO", "3371EA5F-3FFC-4F94-ADC7-CBED140FF843"},
        {"APTFO", "5470ACDA-C77D-402C-8597-E4DFAFDA0BB7"},
        {"SEALF", "14387A98-2388-4041-B3EF-F9331056769C"},
        {"INSFO", "CE6A6CF6-195A-4004-B026-A3A9548EAB93"},
        {"SFO", "B399D13B-5761-4CC2-A3ED-194AECE8E8B1"},
        {"COO", "F171285A-E7E7-49A2-AEFE-4E6608B94FA8"},
        {"DOCSCO", "7E542323-FE91-4A38-821F-6F0E0FB6EAD6"},
        {"CLF", "6FEF564B-E832-49B8-A3BB-9476857B1799"},
        {"DOF", "C7CECC14-DB38-45D8-AEE5-74C84F6D0E95"},
        {"CICD", "3A40F27A-F161-4E3E-92F4-A80BA390FF9C"},
        {"THCD", "E34A2550-0AE1-4FFE-812D-95524ECB7233"},
        {"CFSD", "691F4CB2-B983-4D49-A9AD-FE05F06F9680"},
        {"AMDF", "1CBEDCAA-FA9C-4A74-853D-1A81C157794F"},
        {"HFD", "6DFF5D30-2A49-47ED-9F64-FA62C2F42C26"},
        {"CDFD", "FD25EDF7-188C-45C3-A2B5-2B17B1B1116F"},
        {"TRKD", "4E2AA215-A1FC-41FF-8B5A-B25F3B4DC423"},
        {"SFD", "E90AE394-D278-4D73-9ABC-334CC9034096"},
        {"CSHT", "B5E0DD8A-A219-45DC-8BDC-29B7B848CA26"},
        {"LFD", "21AA77C4-AC31-4DE5-980C-7411FAC7BB52"},
        {"LOLO", "DC52C720-B53E-4298-B1BA-9899518201AD"},
        {"WHDO", "0866517F-1847-4130-AD68-1CB9D45C7B4A"},
        {"WHHF", "6EF590A5-33E6-4ED2-9F07-AE49EAB62F0C"},
        {"IMTAX", "E0D7F147-CA9B-4BB2-A11C-1D06FC322C1A"},
        {"BCQT", "5D8D6B7D-5C8B-4639-9617-D9BF445D99AC"}
    }

    Public Function GetAllColumnDefinitions() As List(Of MasterDataColumnInfo)
        Dim cols As New List(Of MasterDataColumnInfo)
        AddColumn(cols, "COMPANY", "Company", "B")
        AddColumn(cols, "LOT_SUFFIX", "Lot suffix", "C")
        AddColumn(cols, "WEEK", "Week", "D")
        AddColumn(cols, "MODE", "Mode (Air/Sea)", "E")
        AddColumn(cols, "CY_CFS_ITEM", "CY/CFS Item", "F")
        AddColumn(cols, "PIC_REPORT", "PIC", "G")
        AddColumn(cols, "LOT", "Lot", "H")
        AddColumn(cols, "SHIPPER", "Shipper", "I")
        AddColumn(cols, "CONSIGNEE", "Consignee", "J")
        AddColumn(cols, "MBL", "MBL", "K")
        AddColumn(cols, "HBL", "HBL", "L")
        AddColumn(cols, "QTY_PKG", "Qty/Package", "M")
        AddColumn(cols, "WEIGHT_KG", "Weight (KG)", "N")
        AddColumn(cols, "CHARGEABLE", "Chargeable", "O")
        AddColumn(cols, "CBM", "CBM", "P")
        AddColumn(cols, "COL_Q", "Col Q", "Q")
        AddColumn(cols, "COL_R", "Col R", "R")
        AddColumn(cols, "BRANCH", "Branch", "S")
        AddColumn(cols, "SHIPPINGLINE", "Shipping line", "T")
        AddColumn(cols, "POL", "POL", "U")
        AddColumn(cols, "POLCODE", "POL Code", "V")
        AddColumn(cols, "PODCODE", "POD Code", "W")
        AddColumn(cols, "COL_X", "Col X", "X")
        AddColumn(cols, "COL_Y", "Col Y", "Y")
        AddColumn(cols, "CARGO_READY", "Cargo ready", "Z")
        AddColumn(cols, "CLOSING", "Closing", "AA")
        AddColumn(cols, "ETA", "ETA", "AB")
        AddColumn(cols, "SAILINGDATE", "Sailing date", "AC")
        AddColumn(cols, "MBL_COPY", "MBL (copy)", "AD")
        AddColumn(cols, "VESSEL", "Vessel", "AE")
        AddColumn(cols, "VOYAGE", "Voyage", "AF")
        AddColumn(cols, "REMARKS", "Remarks", "AG")
        AddColumn(cols, "TRKO", "TRKO", "AH")
        AddColumn(cols, "ELF", "ELF", "AI")
        AddColumn(cols, "HFO", "HFO", "AJ")
        AddColumn(cols, "THCO", "THCO", "AK")
        AddColumn(cols, "CFSO", "CFSO", "AL")
        AddColumn(cols, "STUFF", "STUFF", "AM")
        AddColumn(cols, "CDFO", "CDFO", "AN")
        AddColumn(cols, "VGM", "VGM", "AO")
        AddColumn(cols, "BKF", "BKF", "AP")
        AddColumn(cols, "AWBF_BLF", "AWBF/BLF", "AQ")
        AddColumn(cols, "TLXF", "TLXF", "AR")
        AddColumn(cols, "GCO", "GCO", "AS")
        AddColumn(cols, "WHGC", "WHGC", "AT")
        AddColumn(cols, "PCO", "PCO", "AU")
        AddColumn(cols, "APTFO", "APTFO", "AV")
        AddColumn(cols, "SEALF", "SEALF", "AW")
        AddColumn(cols, "INSFO", "INSFO", "AX")
        AddColumn(cols, "SFO", "SFO", "AY")
        AddColumn(cols, "COO", "COO", "AZ")
        AddColumn(cols, "DOCSCO", "DOCSCO", "BA")
        AddColumn(cols, "AF_OF", "AF/OF", "BB")
        AddColumn(cols, "CLF", "CLF", "BC")
        AddColumn(cols, "DOF", "DOF", "BD")
        AddColumn(cols, "CICD", "CICD", "BE")
        AddColumn(cols, "THCD", "THCD", "BF")
        AddColumn(cols, "CFSD", "CFSD", "BG")
        AddColumn(cols, "AMDF", "AMDF", "BH")
        AddColumn(cols, "HFD", "HFD", "BI")
        AddColumn(cols, "CDFD", "CDFD", "BJ")
        AddColumn(cols, "TRKD", "TRKD", "BK")
        AddColumn(cols, "SFD", "SFD", "BL")
        AddColumn(cols, "CSHT", "CSHT", "BM")
        AddColumn(cols, "LFD", "LFD", "BN")
        AddColumn(cols, "LOLO", "LOLO", "BO")
        AddColumn(cols, "WHDO", "WHDO", "BP")
        AddColumn(cols, "WHHF", "WHHF", "BQ")
        AddColumn(cols, "IMTAX", "IMTAX", "BR")
        AddColumn(cols, "BCQT", "BCQT", "BS")
        AddColumn(cols, "TOTAL_FEE_NO_TAX", "Tong phi khong thue", "BT")
        AddColumn(cols, "TOTAL_FEE_WITH_TAX", "Tong phi co thue", "BU")
        AddColumn(cols, "TOTAL_TAX", "Tong thue", "BV")
        AddColumn(cols, "TOTAL_FEE_ALL", "Tong cac phi", "BW")
        Return cols
    End Function

    Private Sub AddColumn(cols As List(Of MasterDataColumnInfo), key As String, displayName As String, letter As String)
        cols.Add(New MasterDataColumnInfo With {
            .Key = key,
            .DisplayName = displayName,
            .DefaultColumnLetter = letter
        })
    End Sub

    Public Function GetDefaultColumnKeys() As List(Of String)
        Dim keys As New List(Of String)
        For Each col As MasterDataColumnInfo In GetAllColumnDefinitions()
            keys.Add(col.Key)
        Next
        Return keys
    End Function

    Public Function GetColumnDisplayName(key As String) As String
        EnsureTemplateHeadersLoaded()
        If templateHeaderCache IsNot Nothing AndAlso templateHeaderCache.ContainsKey(key) Then
            Return templateHeaderCache(key)
        End If

        For Each col As MasterDataColumnInfo In GetAllColumnDefinitions()
            If col.Key = key Then
                Return col.DisplayName
            End If
        Next
        Return key
    End Function

    Public Sub EnsureTemplateHeadersLoaded()
        If templateHeadersLoaded Then
            Return
        End If

        templateHeaderCache = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        templateHeadersLoaded = True

        Dim templatePath As String = Path.Combine(StartupPath, "MASTERDATA_TBS.xls")
        If Not File.Exists(templatePath) Then
            Return
        End If

        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Dim ws As _Worksheet = Nothing

        Try
            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False
            app.ScreenUpdating = False
            workbook = app.Workbooks.Open(templatePath)
            ws = workbook.Worksheets.Item(1)

            For Each col As MasterDataColumnInfo In GetAllColumnDefinitions()
                Dim cellText As String = ReadTemplateCellText(ws, col.DefaultColumnLetter, TemplateHeaderRow)
                If cellText.Length > 0 Then
                    templateHeaderCache(col.Key) = cellText
                End If
            Next
        Catch
        Finally
            ReleaseExcelWorksheet(ws, workbook, app)
        End Try
    End Sub

    Private Function ReadTemplateCellText(ws As _Worksheet, columnLetter As String, rowNumber As Integer) As String
        Try
            Dim cell As Range = ws.Range(columnLetter & rowNumber.ToString())
            Dim text As String = ""
            If cell.Text IsNot Nothing Then
                text = cell.Text.ToString()
            End If
            text = text.Replace(vbCr, " ").Replace(vbLf, " ").Trim()
            While text.Contains("  ")
                text = text.Replace("  ", " ")
            End While
            Return text
        Catch
            Return ""
        End Try
    End Function

    Private Sub ReleaseExcelWorksheet(ByRef ws As _Worksheet, ByRef workbook As _Workbook, ByRef app As Application)
        Try
            If ws IsNot Nothing Then
                Marshal.ReleaseComObject(ws)
                ws = Nothing
            End If
        Catch
        End Try

        Try
            If workbook IsNot Nothing Then
                workbook.Close(False)
                Marshal.ReleaseComObject(workbook)
                workbook = Nothing
            End If
        Catch
        End Try

        Try
            If app IsNot Nothing Then
                app.Quit()
                Marshal.ReleaseComObject(app)
                app = Nothing
            End If
        Catch
        End Try
    End Sub

    Public Function GetDefaultColumnLetter(key As String) As String
        For Each col As MasterDataColumnInfo In GetAllColumnDefinitions()
            If col.Key = key Then
                Return col.DefaultColumnLetter
            End If
        Next
        Return "A"
    End Function

    Public Function LoadUserColumnKeys() As List(Of String)
        Dim defaultKeys = GetDefaultColumnKeys()
        If objUserSetting Is Nothing Then
            Return defaultKeys
        End If

        Dim saved As String = ""
        Try
            saved = CStr(objUserSetting.GetCParm(ExportColumnsParmId, ""))
        Catch
            saved = ""
        End Try

        If saved Is Nothing OrElse saved.Trim().Length = 0 Then
            Return defaultKeys
        End If

        Dim validKeys As List(Of String) = GetDefaultColumnKeys()
        Dim rawKeys() As String = saved.Split(New String() {ConfigSeparator}, StringSplitOptions.RemoveEmptyEntries)
        Dim keys As New List(Of String)
        For Each k As String In rawKeys
            If validKeys.Contains(k) AndAlso Not keys.Contains(k) Then
                keys.Add(k)
            End If
        Next

        If keys.Count = 0 Then
            Return defaultKeys
        End If

        Return keys
    End Function

    Public Sub SaveUserColumnKeys(keys As List(Of String))
        If objUserSetting Is Nothing Then
            Return
        End If

        Dim value As String = String.Join(ConfigSeparator, keys.ToArray())
        objUserSetting.SetCParm(ExportColumnsParmId, value)
        Try
            objUserSetting.SaveParm()
        Catch
        End Try
    End Sub

    Public Function UsesTemplateLayout(selectedKeys As List(Of String)) As Boolean
        Dim defaultKeys = GetDefaultColumnKeys()
        If selectedKeys.Count <> defaultKeys.Count Then
            Return False
        End If

        For i As Integer = 0 To defaultKeys.Count - 1
            If Not String.Equals(selectedKeys(i), defaultKeys(i), StringComparison.OrdinalIgnoreCase) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function BuildExportContext(row As DataRow, kind As MasterDataShipmentKind, Optional exportInUsd As Boolean = False) As MasterDataExportContext
        Dim ctx As New MasterDataExportContext With {
            .Row = row,
            .Kind = kind,
            .ExportInUsd = exportInUsd,
            .BlibId = GetShipmentId(row, kind)
        }

        Select Case kind
            Case MasterDataShipmentKind.AirImport, MasterDataShipmentKind.SeaImport
                ctx.FreightTable = "inboundfreight"
                ctx.FreightIdColumn = "inboundid"
            Case Else
                ctx.FreightTable = "outboundfreight"
                ctx.FreightIdColumn = "outboundid"
        End Select

        ctx.IsAirFreightItem = (kind = MasterDataShipmentKind.AirImport OrElse kind = MasterDataShipmentKind.AirExport)

        Try
            Dim sqlCus As String = "select * from customer where customer_id ='" & row.Item("customerid_showTC").ToString() & "'"
            Dim dsCus As DataSet = ReadDataSet(sqlCus)
            If dsCus IsNot Nothing AndAlso dsCus.Tables.Count > 0 AndAlso dsCus.Tables(0).Rows.Count > 0 Then
                ctx.CompanyName = dsCus.Tables(0).Rows(0).Item("shortname").ToString()
            End If
        Catch
        End Try

        Try
            If row.Table.Columns.Contains("agentid") Then
                Dim agentId As String = row.Item("agentid").ToString().Trim()
                If agentId.Length > 0 Then
                    Dim sqlAgent As String = "select company from customer where customer_id ='" & agentId & "'"
                    Dim dsAgent As DataSet = ReadDataSet(sqlAgent)
                    If dsAgent IsNot Nothing AndAlso dsAgent.Tables.Count > 0 AndAlso dsAgent.Tables(0).Rows.Count > 0 Then
                        ctx.AgentName = dsAgent.Tables(0).Rows(0).Item("company").ToString()
                    End If
                End If
            End If
        Catch
        End Try

        Try
            Dim sqlCont As String = "select * from containerrepair where inboundid ='" & ctx.BlibId & "'"
            Dim dsCont As DataSet = ReadDataSet(sqlCont)
            If dsCont IsNot Nothing AndAlso dsCont.Tables.Count > 0 AndAlso dsCont.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In dsCont.Tables(0).Rows
                    ctx.ContainerRows.Add(dr)
                Next
            End If
        Catch
        End Try

        LoadContainerTypeSummary(ctx)

        Return ctx
    End Function

    Public Function GetFieldValue(key As String, ctx As MasterDataExportContext) As Object
        Dim row = ctx.Row

        Select Case key
            Case "COMPANY"
                Return ctx.CompanyName
            Case "LOT_SUFFIX"
                Dim lot As String = row.Item("lot").ToString()
                If lot.Length > 0 Then
                    Return lot.Substring(lot.Length - 1, 1)
                End If
                Return ""
            Case "WEEK"
                Return GetWeekNumber(row.Item("datereport").ToString())
            Case "MODE"
                Return GetModeText(ctx)
            Case "CY_CFS_ITEM"
                Return row.Item("CY_CFS_ITEM").ToString()
            Case "PIC_REPORT"
                Return row.Item("pic_report").ToString()
            Case "LOT"
                Return row.Item("lot").ToString()
            Case "SHIPPER"
                Return row.Item("shipper").ToString()
            Case "CONSIGNEE"
                Return row.Item("consignee").ToString()
            Case "MBL"
                Return row.Item("MBL").ToString()
            Case "HBL"
                Return row.Item("HBL").ToString()
            Case "QTY_PKG"
                Return GetContainerQtyText(ctx)
            Case "WEIGHT_KG"
                Return GetContainerField(ctx, "sokg")
            Case "CHARGEABLE"
                Return GetContainerField(ctx, "chargeable")
            Case "CBM"
                Return GetContainerField(ctx, "sokhoi")
            Case "COL_Q"
                Return ""
            Case "COL_X"
                Return row.Item("pol").ToString()
            Case "COL_Y"
                Return row.Item("pod").ToString()
            Case "COL_R"
                Return ctx.ContainerTypeText
            Case "BRANCH"
                Return ctx.ContainerQtyText
            Case "SHIPPINGLINE"
                Return row.Item("shippingline").ToString()
            Case "POL"
                Return ""
            Case "POLCODE"
                Return row.Item("polcode").ToString()
            Case "PODCODE"
                Return row.Item("podcode").ToString()
            Case "CARGO_READY"
                Return row.Item("cargo_ready").ToString()
            Case "CLOSING"
                Return row.Item("closing").ToString()
            Case "ETA"
                Return row.Item("SAILINGDATE").ToString()
            Case "SAILINGDATE"
                Return row.Item("eta").ToString()
            Case "MBL_COPY"
                Return GetContOrMblText(ctx)
            Case "VESSEL"
                Return row.Item("vessel").ToString()
            Case "VOYAGE"
                Return row.Item("voyage").ToString()
            Case "REMARKS"
                Return row.Item("remarks").ToString()
            Case "AWBF_BLF"
                Return FormatNumber(GetDebitAmount(ctx, BlfItemId), 2)
            Case "AF_OF"
                Dim itemId = If(ctx.IsAirFreightItem, AfItemId, OfItemId)
                Return FormatNumber(GetDebitAmount(ctx, itemId), 2)
            Case "TOTAL_FEE_NO_TAX"
                Return FormatNumber(GetFreightPreTaxTotal(ctx, "ISNULL(taxprice, 0) = 0"), 2)
            Case "TOTAL_FEE_WITH_TAX"
                Return FormatNumber(GetFreightPreTaxTotal(ctx, "ISNULL(taxprice, 0) <> 0"), 2)
            Case "TOTAL_TAX"
                Return FormatNumber(GetFreightTaxTotal(ctx, "ISNULL(taxprice, 0) <> 0"), 2)
            Case "TOTAL_FEE_ALL"
                Dim noTax = GetFreightPreTaxTotal(ctx, "ISNULL(taxprice, 0) = 0")
                Dim withTax = GetFreightPreTaxTotal(ctx, "ISNULL(taxprice, 0) <> 0")
                Dim tax = GetFreightTaxTotal(ctx, "ISNULL(taxprice, 0) <> 0")
                Return FormatNumber(noTax + withTax + tax, 2)
            Case Else
                If DebitItemIds.ContainsKey(key) Then
                    Return FormatNumber(GetDebitAmount(ctx, DebitItemIds(key)), 2)
                End If
                Return ""
        End Select
    End Function

    Private Function GetShipmentId(row As DataRow, kind As MasterDataShipmentKind) As String
        Dim idColumn As String = If(kind = MasterDataShipmentKind.AirExport OrElse kind = MasterDataShipmentKind.SeaExport, "blob_id", "blib_id")

        For Each col As DataColumn In row.Table.Columns
            If String.Equals(col.ColumnName, idColumn, StringComparison.OrdinalIgnoreCase) Then
                Return row.Item(col).ToString()
            End If
        Next

        Return ""
    End Function

    Private Sub LoadContainerTypeSummary(ctx As MasterDataExportContext)
        ctx.ContainerTypeText = ""
        ctx.ContainerQtyText = ""

        If ctx.BlibId.Trim().Length = 0 Then
            Return
        End If

        ' Chỉ lấy cột R/S cho Sea Import (inbound) và Sea Export (outbound) khi gflc = "F"
        If ctx.Kind <> MasterDataShipmentKind.SeaImport AndAlso ctx.Kind <> MasterDataShipmentKind.SeaExport Then
            Return
        End If

        If Not IsFclShipment(ctx) Then
            Return
        End If

        Dim sql As String = ""
        Select Case ctx.Kind
            Case MasterDataShipmentKind.SeaImport
                sql = "select containertype from containerrepair where inboundid ='" & ctx.BlibId & "'"
            Case MasterDataShipmentKind.SeaExport
                sql = "select containertype from containertype where outboundid ='" & ctx.BlibId & "'"
            Case Else
                Return
        End Select

        Try
            Dim ds As DataSet = ReadDataSet(sql)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return
            End If

            Dim typeOrder As New List(Of String)
            Dim typeCounts As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim containerType As String = dr.Item("containertype").ToString().Trim()
                If containerType.Length = 0 Then
                    Continue For
                End If

                If Not typeCounts.ContainsKey(containerType) Then
                    typeCounts(containerType) = 0
                    typeOrder.Add(containerType)
                End If
                typeCounts(containerType) += 1
            Next

            If typeOrder.Count = 0 Then
                Return
            End If

            ctx.ContainerTypeText = String.Join(",", typeOrder.ToArray())

            Dim qtyParts As New List(Of String)
            For Each containerType As String In typeOrder
                qtyParts.Add(typeCounts(containerType).ToString() & "x" & containerType)
            Next
            ctx.ContainerQtyText = String.Join(",", qtyParts.ToArray())
        Catch
        End Try
    End Sub

    Private Function IsFclShipment(ctx As MasterDataExportContext) As Boolean
        If ctx.Row Is Nothing Then
            Return False
        End If

        If Not ctx.Row.Table.Columns.Contains("gflc") Then
            Return False
        End If

        Return String.Equals(ctx.Row.Item("gflc").ToString().Trim(), "F", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function GetContOrMblText(ctx As MasterDataExportContext) As String
        If ctx.Kind = MasterDataShipmentKind.AirImport OrElse ctx.Kind = MasterDataShipmentKind.AirExport Then
            Return GetRowText(ctx.Row, "mbl", "MBL", "MBLMAWB")
        End If

        If ctx.BlibId.Trim().Length = 0 Then
            Return ""
        End If

        Dim sql As String = ""
        Select Case ctx.Kind
            Case MasterDataShipmentKind.SeaImport
                sql = "select containerno from containerrepair where inboundid ='" & ctx.BlibId & "'"
            Case MasterDataShipmentKind.SeaExport
                sql = "select containerno from containertype where outboundid ='" & ctx.BlibId & "'"
            Case Else
                Return ""
        End Select

        Try
            Dim ds As DataSet = ReadDataSet(sql)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return ""
            End If

            Dim containerNos As New List(Of String)
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim containerNo As String = dr.Item("containerno").ToString().Trim()
                If containerNo.Length = 0 Then
                    Continue For
                End If

                If Not containerNos.Contains(containerNo) Then
                    containerNos.Add(containerNo)
                End If
            Next

            If containerNos.Count = 0 Then
                Return ""
            End If

            Return String.Join(",", containerNos.ToArray())
        Catch
            Return ""
        End Try
    End Function

    Private Function GetRowText(row As DataRow, ParamArray columnNames() As String) As String
        For Each columnName As String In columnNames
            For Each col As DataColumn In row.Table.Columns
                If String.Equals(col.ColumnName, columnName, StringComparison.OrdinalIgnoreCase) Then
                    Return row.Item(col).ToString()
                End If
            Next
        Next

        Return ""
    End Function

    Private Function GetModeText(ctx As MasterDataExportContext) As String
        If ctx.Kind = MasterDataShipmentKind.AirImport OrElse ctx.Kind = MasterDataShipmentKind.AirExport Then
            Return "AIR"
        End If

        If ctx.Row.Table.Columns.Contains("gflc") Then
            Select Case ctx.Row.Item("gflc").ToString().Trim().ToUpper()
                Case "F"
                    Return "FCL"
                Case "L"
                    Return "LCL"
                Case "C"
                    Return "C"
            End Select
        End If

        Return ""
    End Function

    Private Function GetWeekNumber(dateText As String) As Integer
        Try
            Dim reportDate As DateTime = DateTime.ParseExact(dateText, "d-MMM-yyyy", CultureInfo.InvariantCulture)
            Return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(reportDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        Catch
            Return 0
        End Try
    End Function

    Private Function GetContainerQtyText(ctx As MasterDataExportContext) As String
        If ctx.ContainerRows Is Nothing OrElse ctx.ContainerRows.Count = 0 Then
            Return ""
        End If

        Dim qtyByType As New Dictionary(Of String, Double)(StringComparer.OrdinalIgnoreCase)
        Dim typeOrder As New List(Of String)

        For Each dr As DataRow In ctx.ContainerRows
            Dim typeText As String = dr.Item("type").ToString()
            If typeText.Length >= 2 Then
                typeText = typeText.Substring(0, 2)
            End If
            If typeText.Length = 0 Then
                Continue For
            End If

            Dim qty As Double = 0
            Try
                qty = CDbl(dr.Item("sokien").ToString())
            Catch ex As Exception
            End Try

            If Not qtyByType.ContainsKey(typeText) Then
                qtyByType(typeText) = 0
                typeOrder.Add(typeText)
            End If
            qtyByType(typeText) += qty
        Next

        If typeOrder.Count = 0 Then
            Return ""
        End If

        Dim parts As New List(Of String)
        For Each typeText As String In typeOrder
            Dim qtyVal As Double = qtyByType(typeText)
            If qtyVal = Math.Truncate(qtyVal) Then
                parts.Add(CInt(qtyVal).ToString() & " " & typeText)
            Else
                parts.Add(qtyVal.ToString() & " " & typeText)
            End If
        Next

        Return String.Join(", ", parts.ToArray())
    End Function

    Private Function GetContainerField(ctx As MasterDataExportContext, fieldName As String) As String
        If ctx.ContainerRows Is Nothing OrElse ctx.ContainerRows.Count = 0 Then
            Return ""
        End If

        Dim total As Double = 0
        Dim hasValue As Boolean = False

        For Each dr As DataRow In ctx.ContainerRows
            Try
                Dim valText As String = dr.Item(fieldName).ToString().Trim()
                If valText.Length > 0 Then
                    total += CDbl(valText)
                    hasValue = True
                End If
            Catch ex As Exception
            End Try
        Next

        If Not hasValue Then
            Return ""
        End If

        If total = Math.Truncate(total) Then
            Return CInt(total).ToString()
        End If

        Return total.ToString()
    End Function

    Private Function GetDebitAmount(ctx As MasterDataExportContext, itemId As String) As Double
        Return GetFreightAmountTotal(ctx, GetPreTaxAmountExpr(ctx), "itemid ='" & itemId & "'")
    End Function

    Private Function GetFreightPreTaxTotal(ctx As MasterDataExportContext, taxFilter As String) As Double
        Return GetFreightAmountTotal(ctx, GetPreTaxAmountExpr(ctx), taxFilter)
    End Function

    Private Function GetFreightTaxTotal(ctx As MasterDataExportContext, taxFilter As String) As Double
        Return GetFreightAmountTotal(ctx, GetTaxAmountExpr(ctx), taxFilter)
    End Function

    Private Function GetPreTaxAmountExpr(ctx As MasterDataExportContext) As String
        If ctx.ExportInUsd Then
            ' Quy đổi về USD: thanhtientruocthueVND là tiền VND, chia cho tigia (tỷ giá lưu theo currency của phí).
            ' Với phí currency = USD  : thanhtientruocthueVND = giá USD * tigia  -> /tigia ra USD.
            ' Với phí currency = VND  : tigia lưu tỷ giá USD->VND               -> /tigia ra USD.
            ' Guard tigia = 0/NULL để tránh chia cho 0.
            Return "CASE WHEN ISNULL(tigia, 0) = 0 THEN 0 ELSE thanhtientruocthueVND / tigia END"
        End If
        Return "thanhtientruocthueVND"
    End Function

    Private Function GetTaxAmountExpr(ctx As MasterDataExportContext) As String
        If ctx.ExportInUsd Then
            Return "CASE WHEN ISNULL(tigia, 0) = 0 THEN 0 ELSE tienthueVND / tigia END"
        End If
        Return "tienthueVND"
    End Function

    Private Function GetFreightAmountTotal(ctx As MasterDataExportContext, amountExpr As String, extraFilter As String) As Double
        If ctx.BlibId.Trim().Length = 0 OrElse ctx.FreightTable.Trim().Length = 0 Then
            Return 0
        End If

        Dim sql As String = "select ISNULL(sum(" & amountExpr & "), 0) as total from " &
            ctx.FreightTable & " where " & ctx.FreightIdColumn & " ='" & ctx.BlibId & "'"
        If extraFilter.Trim().Length > 0 Then
            sql &= " and " & extraFilter
        End If
        Return GetDebitTotal(sql)
    End Function

    Private Function GetDebitTotal(sql As String) As Double
        Try
            Dim ds As DataSet = ReadDataSet(sql)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return 0
            End If

            Dim val As Object = ds.Tables(0).Rows(0).Item("total")
            If val Is Nothing OrElse IsDBNull(val) Then
                Return 0
            End If

            Dim amount As Double
            If Double.TryParse(val.ToString(), amount) Then
                Return amount
            End If

            Return 0
        Catch
            Return 0
        End Try
    End Function

    Public Sub ApplyTemplateColumnLayout(ws As _Worksheet, selectedKeys As List(Of String))
        If UsesTemplateLayout(selectedKeys) Then
            Return
        End If

        Dim defaultKeys As List(Of String) = GetDefaultColumnKeys()

        Try
            ws.Range("B" & TemplateHeaderRow.ToString() & ":BW" & TemplateHeaderRow.ToString()).Copy(
                ws.Range("B" & TemplateHeaderBackupRow.ToString()))
        Catch
        End Try

        For i As Integer = 0 To selectedKeys.Count - 1
            Dim key As String = selectedKeys(i)
            Dim sourceCol As String = GetDefaultColumnLetter(key)
            Dim targetCol As String = GetExcelColumnName(FirstTemplateColumnIndex + i)

            Try
                ws.Range(sourceCol & TemplateHeaderBackupRow.ToString()).Copy(
                    ws.Range(targetCol & TemplateHeaderRow.ToString()))
            Catch
                ws.Range(targetCol & TemplateHeaderRow.ToString()).Value2 = GetColumnDisplayName(key)
            End Try
        Next

        Try
            ws.Range("B" & TemplateHeaderBackupRow.ToString() & ":BW" & TemplateHeaderBackupRow.ToString()).Clear()
        Catch
        End Try

        For colIdx As Integer = FirstTemplateColumnIndex + selectedKeys.Count To LastTemplateColumnIndex
            SetColumnHidden(ws, GetExcelColumnName(colIdx), True)
        Next

        Dim targetCols As New List(Of String)
        For i As Integer = 0 To selectedKeys.Count - 1
            targetCols.Add(GetExcelColumnName(FirstTemplateColumnIndex + i))
        Next

        For Each key As String In defaultKeys
            Dim originalCol As String = GetDefaultColumnLetter(key)
            If Not selectedKeys.Contains(key) Then
                If Not targetCols.Contains(originalCol) Then
                    SetColumnHidden(ws, originalCol, True)
                End If
            Else
                Dim newIndex As Integer = selectedKeys.IndexOf(key)
                Dim newCol As String = GetExcelColumnName(FirstTemplateColumnIndex + newIndex)
                If Not String.Equals(originalCol, newCol, StringComparison.OrdinalIgnoreCase) AndAlso Not targetCols.Contains(originalCol) Then
                    SetColumnHidden(ws, originalCol, True)
                End If
            End If
        Next
    End Sub

    Private Sub SetColumnHidden(ws As _Worksheet, columnLetter As String, hidden As Boolean)
        Try
            CType(ws.Columns(columnLetter), Range).EntireColumn.Hidden = hidden
        Catch
        End Try
    End Sub

    Public Sub WriteDataRow(ws As _Worksheet, rowIndex As Integer, selectedKeys As List(Of String), ctx As MasterDataExportContext, useTemplateLayout As Boolean)
        Try
            ws.Range("A" & rowIndex.ToString()).Value2 = ctx.AgentName
        Catch
        End Try

        For i As Integer = 0 To selectedKeys.Count - 1
            Dim value = GetFieldValue(selectedKeys(i), ctx)
            Dim targetCol As String

            If useTemplateLayout Then
                targetCol = GetDefaultColumnLetter(selectedKeys(i))
            Else
                targetCol = GetExcelColumnName(FirstTemplateColumnIndex + i)
            End If

            ws.Range(targetCol & rowIndex.ToString()).Value2 = value
        Next
    End Sub

    Public Function GetExcelColumnName(columnIndex As Integer) As String
        Dim index = columnIndex
        Dim name As String = ""

        While index > 0
            Dim remainder = (index - 1) Mod 26
            name = Chr(65 + remainder) & name
            index = (index - 1) \ 26
        End While

        Return name
    End Function

    Public Sub ExportDataSet(ws As _Worksheet, ByRef currentRow As Integer, ds As DataSet, kind As MasterDataShipmentKind, selectedKeys As List(Of String), useTemplateLayout As Boolean, exportInUsd As Boolean, progressLabel As String, advanceProgress As Action(Of String))
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then
            Return
        End If

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim ctx = BuildExportContext(ds.Tables(0).Rows(i), kind, exportInUsd)
            WriteDataRow(ws, currentRow, selectedKeys, ctx, useTemplateLayout)
            currentRow += 1
            If advanceProgress IsNot Nothing Then
                advanceProgress(progressLabel)
            End If
        Next
    End Sub
End Module
