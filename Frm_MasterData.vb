Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports Excel

Public Class Frm_MasterData
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Dim ws As _Worksheet = Nothing
        Dim workPath As String = Nothing
        Dim outputPath As String = Nothing

        Try

            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text

            outputPath = OpenDlg("MASTERDATA_TBS_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xls")
            If String.IsNullOrEmpty(outputPath) Then
                Return
            End If

            Button1.Enabled = False
            lblProgress.Text = "Đang tải dữ liệu..."
            System.Windows.Forms.Application.DoEvents()

            Dim sql_airimp As String = " select * from inbound_OverseaAirImport where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_airimp As DataSet = ReadDataSet(sql_airimp)

            Dim sql_airexp As String = " select * from Outbound_OverseaAirExport where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_airexp As DataSet = ReadDataSet(sql_airexp)

            Dim sql_seaimp As String = " select * from inbound where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_seaimp As DataSet = ReadDataSet(sql_seaimp)

            Dim sql_seaexp As String = " select * from outbound where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_seaexp As DataSet = ReadDataSet(sql_seaexp)

            Dim totalRows As Integer = GetRowCount(ds_airimp) + GetRowCount(ds_airexp) + GetRowCount(ds_seaimp) + GetRowCount(ds_seaexp)
            BeginExportProgress(totalRows + 2)

            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim templatePath As String = Path.Combine(StartupPath, "MASTERDATA_TBS.xls")
            workPath = Path.Combine(Path.GetTempPath(), "MASTERDATA_TBS_" & Guid.NewGuid().ToString("N") & ".xls")
            File.Copy(templatePath, workPath, True)

            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False
            app.ScreenUpdating = False
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks

            workbook = workbooks.Open(workPath)
            Dim DongHienTai As Integer = 11

            AdvanceExportProgress("Đang mở file Excel...")

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            ws = sheets.Item(1) ' 1 la debit

            If ws Is Nothing Then
                Return
            End If

            For i As Integer = 0 To GetRowCount(ds_airimp) - 1
                ws.Range("S" + DongHienTai.ToString).Value2 = "TBSL"

                Try
                    Dim sql_cus As String = "select * from customer where customer_id ='" & ds_airimp.Tables(0).Rows(i).Item("customerid_showTC").ToString & "'"
                    Dim ds_cus As DataSet = ReadDataSet(sql_cus)
                    If (ds_cus.Tables(0).Rows.Count > 0) Then
                        ws.Range("B" + DongHienTai.ToString).Value2 = ds_cus.Tables(0).Rows(0).Item("Company").ToString
                    End If
                Catch ex As Exception

                End Try

                Dim lot As String = ds_airimp.Tables(0).Rows(i).Item("lot").ToString()

                If lot.Length > 0 Then
                    ws.Range("C" & DongHienTai.ToString()).Value2 = lot.Substring(lot.Length - 1, 1)
                End If

                Dim dateText As String = ds_airimp.Tables(0).Rows(i).Item("datereport").ToString()

                Dim reportDate As DateTime = DateTime.ParseExact(
                    dateText,
                    "d-MMM-yyyy",
                    CultureInfo.InvariantCulture
                )

                Dim weekNo As Integer = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                    reportDate,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday
                )

                ws.Range("D" & DongHienTai.ToString()).Value2 = weekNo
                ws.Range("E" & DongHienTai.ToString()).Value2 = "Air"
                ws.Range("F" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("CY_CFS_ITEM").ToString()
                ws.Range("G" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("pic_report").ToString()
                ws.Range("H" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("lot").ToString()
                ws.Range("I" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("shipper").ToString()
                ws.Range("J" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("consignee").ToString()
                ws.Range("K" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("MBL").ToString()
                ws.Range("L" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("HBL").ToString()

                Dim sql_cont As String = "select * from containerrepair where inboundid ='" & ds_airimp.Tables(0).Rows(i).Item("Blib_id").ToString() & "'"
                Dim ds_cont As DataSet = ReadDataSet(sql_cont)
                If (ds_cont.Tables(0).Rows.Count > 0) Then
                    Dim typeText As String = ds_cont.Tables(0).Rows(0).Item("type").ToString()

                    If typeText.Length >= 2 Then
                        typeText = typeText.Substring(0, 2)
                    End If

                    ws.Range("M" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokien").ToString() & " " & typeText
                    ws.Range("N" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokg").ToString()
                    ws.Range("O" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("chargeable").ToString()
                    ws.Range("P" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokhoi").ToString()
                    ws.Range("Q" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("R" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("S" & DongHienTai.ToString()).Value2 = "" 'hang air khong co

                End If


                ws.Range("T" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("shippingline").ToString()
                ws.Range("U" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("pol").ToString()
                ws.Range("V" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("polcode").ToString()
                ws.Range("W" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("podcode").ToString()
                ws.Range("X" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Y" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Z" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("cargo_ready").ToString()
                ws.Range("AA" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("closing").ToString()
                ws.Range("AB" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("eta").ToString()
                ws.Range("AC" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("SAILINGDATE").ToString()
                ws.Range("AD" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("mbl").ToString()
                ws.Range("AE" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("vessel").ToString()
                ws.Range("AF" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("voyage").ToString()
                ws.Range("AG" & DongHienTai.ToString()).Value2 = ds_airimp.Tables(0).Rows(i).Item("remarks").ToString()
                Dim sql_debit As String = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B70D388F-2C6E-4317-83CD-FCB03AF742B2'" 'TRKO
                ws.Range("AH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E4DE6E06-943E-4675-8F4B-C3E8999D9028'" 'ELF
                ws.Range("AI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)


                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='47448840-23BB-4811-9982-6B2CEB9DA31A'" 'HFO
                ws.Range("AJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D76C2E1-2990-4DE2-A3D9-716BDD14AE88'" 'THCO
                ws.Range("AK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='75109072-2E25-4E0A-8C35-36FC8F368E22'" 'CFSO
                ws.Range("AL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='8A8E7068-2344-40E6-B24D-B19416A0F75D'" 'STUFF
                ws.Range("AM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7A42FB16-CCFE-49F9-B1B2-4DDCA14FC5BC'" 'CDFO
                ws.Range("AN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9AEB4F22-CC2E-4F1C-B2C5-D8DCF123D33C'" 'VGM
                ws.Range("AO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='D777E578-776B-4EEB-82AD-1996DDF8823C'" 'BKF
                ws.Range("AP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD21CED4-FB6E-4FE0-955A-051E597C7222'" 'AWBF/ BLF
                ws.Range("AQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9BEB8EBD-6CB3-4781-AB35-AF7B840EC35E'" 'TLXF
                ws.Range("AR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7FD2AC51-5610-4F36-973F-CBC78E58A5BA'" 'GCO
                ws.Range("AS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='308B2D09-51CB-49B6-8380-867BD03AFD43'" 'WHGC
                ws.Range("AT" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3371EA5F-3FFC-4F94-ADC7-CBED140FF843'" 'PCO
                ws.Range("AU" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5470ACDA-C77D-402C-8597-E4DFAFDA0BB7'" 'APTFO
                ws.Range("AV" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='14387A98-2388-4041-B3EF-F9331056769C'" 'SEALF
                ws.Range("AW" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='CE6A6CF6-195A-4004-B026-A3A9548EAB93'" 'INSFO
                ws.Range("AX" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B399D13B-5761-4CC2-A3ED-194AECE8E8B1'" 'SFO
                ws.Range("AY" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='F171285A-E7E7-49A2-AEFE-4E6608B94FA8'" 'COO
                ws.Range("AZ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7E542323-FE91-4A38-821F-6F0E0FB6EAD6'" 'DOCSCO
                ws.Range("BA" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='8D24860B-5B90-49B6-9C01-C3A244EEAA4C'" 'AF (Air)/OF(Sea)
                ws.Range("BB" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6FEF564B-E832-49B8-A3BB-9476857B1799'" 'CLF
                ws.Range("BC" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='C7CECC14-DB38-45D8-AEE5-74C84F6D0E95'" 'DOF
                ws.Range("BD" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3A40F27A-F161-4E3E-92F4-A80BA390FF9C'" 'CICD
                ws.Range("BE" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E34A2550-0AE1-4FFE-812D-95524ECB7233'" 'THCD
                ws.Range("BF" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='691F4CB2-B983-4D49-A9AD-FE05F06F9680'" 'CFSD
                ws.Range("BG" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='1CBEDCAA-FA9C-4A74-853D-1A81C157794F'" 'AMDF
                ws.Range("BH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6DFF5D30-2A49-47ED-9F64-FA62C2F42C26'" 'HFD
                ws.Range("BI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD25EDF7-188C-45C3-A2B5-2B17B1B1116F'" ' CDFD
                ws.Range("BJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='4E2AA215-A1FC-41FF-8B5A-B25F3B4DC423'" 'TRKD
                ws.Range("BK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E90AE394-D278-4D73-9ABC-334CC9034096'" 'SFD
                ws.Range("BL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B5E0DD8A-A219-45DC-8BDC-29B7B848CA26'" 'CSHT
                ws.Range("BM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='21AA77C4-AC31-4DE5-980C-7411FAC7BB52'" 'LFD
                ws.Range("BN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='DC52C720-B53E-4298-B1BA-9899518201AD'" 'LOLO
                ws.Range("BO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='0866517F-1847-4130-AD68-1CB9D45C7B4A'" 'WHDO
                ws.Range("BP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6EF590A5-33E6-4ED2-9F07-AE49EAB62F0C'" 'WHHF
                ws.Range("BQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E0D7F147-CA9B-4BB2-A11C-1D06FC322C1A'" 'IMTAX
                ws.Range("BR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_airimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D8D6B7D-5C8B-4639-9617-D9BF445D99AC'" 'BCQT
                ws.Range("BS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)
                DongHienTai += 1
                AdvanceExportProgress("Đang xuất Air Import...")

            Next
            '---------Air Exp-------

            For i As Integer = 0 To GetRowCount(ds_airexp) - 1
                ws.Range("S" + DongHienTai.ToString).Value2 = "TBSL"

                Try
                    Dim sql_cus As String = "select * from customer where customer_id ='" & ds_airexp.Tables(0).Rows(i).Item("customerid_showTC").ToString & "'"
                    Dim ds_cus As DataSet = ReadDataSet(sql_cus)
                    If (ds_cus.Tables(0).Rows.Count > 0) Then
                        ws.Range("B" + DongHienTai.ToString).Value2 = ds_cus.Tables(0).Rows(0).Item("Company").ToString
                    End If
                Catch ex As Exception

                End Try

                Dim lot As String = ds_airexp.Tables(0).Rows(i).Item("lot").ToString()

                If lot.Length > 0 Then
                    ws.Range("C" & DongHienTai.ToString()).Value2 = lot.Substring(lot.Length - 1, 1)
                End If

                Dim dateText As String = ds_airexp.Tables(0).Rows(i).Item("datereport").ToString()

                Dim reportDate As DateTime = DateTime.ParseExact(
                    dateText,
                    "d-MMM-yyyy",
                    CultureInfo.InvariantCulture
                )

                Dim weekNo As Integer = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                    reportDate,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday
                )

                ws.Range("D" & DongHienTai.ToString()).Value2 = weekNo
                ws.Range("E" & DongHienTai.ToString()).Value2 = "Air"
                ws.Range("F" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("CY_CFS_ITEM").ToString()
                ws.Range("G" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("pic_report").ToString()
                ws.Range("H" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("lot").ToString()
                ws.Range("I" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("shipper").ToString()
                ws.Range("J" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("consignee").ToString()
                ws.Range("K" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("MBL").ToString()
                ws.Range("L" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("HBL").ToString()

                Dim sql_cont As String = "select * from containerrepair where inboundid ='" & ds_airexp.Tables(0).Rows(i).Item("Blib_id").ToString() & "'"
                Dim ds_cont As DataSet = ReadDataSet(sql_cont)
                If (ds_cont.Tables(0).Rows.Count > 0) Then
                    Dim typeText As String = ds_cont.Tables(0).Rows(0).Item("type").ToString()

                    If typeText.Length >= 2 Then
                        typeText = typeText.Substring(0, 2)
                    End If

                    ws.Range("M" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokien").ToString() & " " & typeText
                    ws.Range("N" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokg").ToString()
                    ws.Range("O" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("chargeable").ToString()
                    ws.Range("P" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokhoi").ToString()
                    ws.Range("Q" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("R" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("S" & DongHienTai.ToString()).Value2 = "" 'hang air khong co

                End If


                ws.Range("T" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("shippingline").ToString()
                ws.Range("U" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("pol").ToString()
                ws.Range("V" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("polcode").ToString()
                ws.Range("W" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("podcode").ToString()
                ws.Range("X" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Y" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Z" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("cargo_ready").ToString()
                ws.Range("AA" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("closing").ToString()
                ws.Range("AB" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("eta").ToString()
                ws.Range("AC" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("SAILINGDATE").ToString()
                ws.Range("AD" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("mbl").ToString()
                ws.Range("AE" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("vessel").ToString()
                ws.Range("AF" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("voyage").ToString()
                ws.Range("AG" & DongHienTai.ToString()).Value2 = ds_airexp.Tables(0).Rows(i).Item("remarks").ToString()
                Dim sql_debit As String = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B70D388F-2C6E-4317-83CD-FCB03AF742B2'"
                ws.Range("AH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E4DE6E06-943E-4675-8F4B-C3E8999D9028'" 'ELF
                ws.Range("AI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)


                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='47448840-23BB-4811-9982-6B2CEB9DA31A'" 'HFO
                ws.Range("AJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D76C2E1-2990-4DE2-A3D9-716BDD14AE88'" 'THCO
                ws.Range("AK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='75109072-2E25-4E0A-8C35-36FC8F368E22'" 'CFSO
                ws.Range("AL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='8A8E7068-2344-40E6-B24D-B19416A0F75D'" 'STUFF
                ws.Range("AM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7A42FB16-CCFE-49F9-B1B2-4DDCA14FC5BC'" 'CDFO
                ws.Range("AN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9AEB4F22-CC2E-4F1C-B2C5-D8DCF123D33C'" 'VGM
                ws.Range("AO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='D777E578-776B-4EEB-82AD-1996DDF8823C'" 'BKF
                ws.Range("AP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD21CED4-FB6E-4FE0-955A-051E597C7222'" 'AWBF/ BLF
                ws.Range("AQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9BEB8EBD-6CB3-4781-AB35-AF7B840EC35E'" 'TLXF
                ws.Range("AR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7FD2AC51-5610-4F36-973F-CBC78E58A5BA'" 'GCO
                ws.Range("AS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='308B2D09-51CB-49B6-8380-867BD03AFD43'" 'WHGC
                ws.Range("AT" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3371EA5F-3FFC-4F94-ADC7-CBED140FF843'" 'PCO
                ws.Range("AU" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5470ACDA-C77D-402C-8597-E4DFAFDA0BB7'" 'APTFO
                ws.Range("AV" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='14387A98-2388-4041-B3EF-F9331056769C'" 'SEALF
                ws.Range("AW" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='CE6A6CF6-195A-4004-B026-A3A9548EAB93'" 'INSFO
                ws.Range("AX" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B399D13B-5761-4CC2-A3ED-194AECE8E8B1'" 'SFO
                ws.Range("AY" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='F171285A-E7E7-49A2-AEFE-4E6608B94FA8'" 'COO
                ws.Range("AZ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7E542323-FE91-4A38-821F-6F0E0FB6EAD6'" 'DOCSCO
                ws.Range("BA" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='8D24860B-5B90-49B6-9C01-C3A244EEAA4C'" 'AF (Air)/OF(Sea)
                ws.Range("BB" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6FEF564B-E832-49B8-A3BB-9476857B1799'" 'CLF
                ws.Range("BC" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='C7CECC14-DB38-45D8-AEE5-74C84F6D0E95'" 'DOF
                ws.Range("BD" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3A40F27A-F161-4E3E-92F4-A80BA390FF9C'" 'CICD
                ws.Range("BE" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E34A2550-0AE1-4FFE-812D-95524ECB7233'" 'THCD
                ws.Range("BF" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='691F4CB2-B983-4D49-A9AD-FE05F06F9680'" 'CFSD
                ws.Range("BG" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='1CBEDCAA-FA9C-4A74-853D-1A81C157794F'" 'AMDF
                ws.Range("BH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6DFF5D30-2A49-47ED-9F64-FA62C2F42C26'" 'HFD
                ws.Range("BI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD25EDF7-188C-45C3-A2B5-2B17B1B1116F'" ' CDFD
                ws.Range("BJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='4E2AA215-A1FC-41FF-8B5A-B25F3B4DC423'" 'TRKD
                ws.Range("BK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E90AE394-D278-4D73-9ABC-334CC9034096'" 'SFD
                ws.Range("BL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B5E0DD8A-A219-45DC-8BDC-29B7B848CA26'" 'CSHT
                ws.Range("BM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='21AA77C4-AC31-4DE5-980C-7411FAC7BB52'" 'LFD
                ws.Range("BN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='DC52C720-B53E-4298-B1BA-9899518201AD'" 'LOLO
                ws.Range("BO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='0866517F-1847-4130-AD68-1CB9D45C7B4A'" 'WHDO
                ws.Range("BP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6EF590A5-33E6-4ED2-9F07-AE49EAB62F0C'" 'WHHF
                ws.Range("BQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E0D7F147-CA9B-4BB2-A11C-1D06FC322C1A'" 'IMTAX
                ws.Range("BR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_airexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D8D6B7D-5C8B-4639-9617-D9BF445D99AC'" 'BCQT
                ws.Range("BS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)
                DongHienTai += 1
                AdvanceExportProgress("Đang xuất Air Export...")

            Next

            '---------Sea imp-------

            For i As Integer = 0 To GetRowCount(ds_seaimp) - 1
                ws.Range("S" + DongHienTai.ToString).Value2 = "TBSL"

                Try
                    Dim sql_cus As String = "select * from customer where customer_id ='" & ds_seaimp.Tables(0).Rows(i).Item("customerid_showTC").ToString & "'"
                    Dim ds_cus As DataSet = ReadDataSet(sql_cus)
                    If (ds_cus.Tables(0).Rows.Count > 0) Then
                        ws.Range("B" + DongHienTai.ToString).Value2 = ds_cus.Tables(0).Rows(0).Item("Company").ToString
                    End If
                Catch ex As Exception

                End Try

                Dim lot As String = ds_seaimp.Tables(0).Rows(i).Item("lot").ToString()

                If lot.Length > 0 Then
                    ws.Range("C" & DongHienTai.ToString()).Value2 = lot.Substring(lot.Length - 1, 1)
                End If

                Dim dateText As String = ds_seaimp.Tables(0).Rows(i).Item("datereport").ToString()

                Dim reportDate As DateTime = DateTime.ParseExact(
                    dateText,
                    "d-MMM-yyyy",
                    CultureInfo.InvariantCulture
                )

                Dim weekNo As Integer = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                    reportDate,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday
                )

                ws.Range("D" & DongHienTai.ToString()).Value2 = weekNo
                ws.Range("E" & DongHienTai.ToString()).Value2 = "Sea"
                ws.Range("F" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("CY_CFS_ITEM").ToString()
                ws.Range("G" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("pic_report").ToString()
                ws.Range("H" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("lot").ToString()
                ws.Range("I" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("shipper").ToString()
                ws.Range("J" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("consignee").ToString()
                ws.Range("K" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("MBL").ToString()
                ws.Range("L" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("HBL").ToString()

                Dim sql_cont As String = "select * from containerrepair where inboundid ='" & ds_seaimp.Tables(0).Rows(i).Item("Blib_id").ToString() & "'"
                Dim ds_cont As DataSet = ReadDataSet(sql_cont)
                If (ds_cont.Tables(0).Rows.Count > 0) Then
                    Dim typeText As String = ds_cont.Tables(0).Rows(0).Item("type").ToString()

                    If typeText.Length >= 2 Then
                        typeText = typeText.Substring(0, 2)
                    End If

                    ws.Range("M" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokien").ToString() & " " & typeText
                    ws.Range("N" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokg").ToString()
                    ws.Range("O" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("chargeable").ToString()
                    ws.Range("P" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokhoi").ToString()
                    ws.Range("Q" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("R" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("S" & DongHienTai.ToString()).Value2 = "" 'hang air khong co

                End If


                ws.Range("T" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("shippingline").ToString()
                ws.Range("U" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("pol").ToString()
                ws.Range("V" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("polcode").ToString()
                ws.Range("W" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("podcode").ToString()
                ws.Range("X" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Y" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Z" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("cargo_ready").ToString()
                ws.Range("AA" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("closing").ToString()
                ws.Range("AB" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("eta").ToString()
                ws.Range("AC" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("SAILINGDATE").ToString()
                ws.Range("AD" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("mbl").ToString()
                ws.Range("AE" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("vessel").ToString()
                ws.Range("AF" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("voyage").ToString()
                ws.Range("AG" & DongHienTai.ToString()).Value2 = ds_seaimp.Tables(0).Rows(i).Item("remarks").ToString()
                Dim sql_debit As String = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B70D388F-2C6E-4317-83CD-FCB03AF742B2'"
                ws.Range("AH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E4DE6E06-943E-4675-8F4B-C3E8999D9028'" 'ELF
                ws.Range("AI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)


                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='47448840-23BB-4811-9982-6B2CEB9DA31A'" 'HFO
                ws.Range("AJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D76C2E1-2990-4DE2-A3D9-716BDD14AE88'" 'THCO
                ws.Range("AK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='75109072-2E25-4E0A-8C35-36FC8F368E22'" 'CFSO
                ws.Range("AL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='8A8E7068-2344-40E6-B24D-B19416A0F75D'" 'STUFF
                ws.Range("AM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7A42FB16-CCFE-49F9-B1B2-4DDCA14FC5BC'" 'CDFO
                ws.Range("AN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9AEB4F22-CC2E-4F1C-B2C5-D8DCF123D33C'" 'VGM
                ws.Range("AO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='D777E578-776B-4EEB-82AD-1996DDF8823C'" 'BKF
                ws.Range("AP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD21CED4-FB6E-4FE0-955A-051E597C7222'" 'AWBF/ BLF
                ws.Range("AQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9BEB8EBD-6CB3-4781-AB35-AF7B840EC35E'" 'TLXF
                ws.Range("AR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7FD2AC51-5610-4F36-973F-CBC78E58A5BA'" 'GCO
                ws.Range("AS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='308B2D09-51CB-49B6-8380-867BD03AFD43'" 'WHGC
                ws.Range("AT" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3371EA5F-3FFC-4F94-ADC7-CBED140FF843'" 'PCO
                ws.Range("AU" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5470ACDA-C77D-402C-8597-E4DFAFDA0BB7'" 'APTFO
                ws.Range("AV" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='14387A98-2388-4041-B3EF-F9331056769C'" 'SEALF
                ws.Range("AW" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='CE6A6CF6-195A-4004-B026-A3A9548EAB93'" 'INSFO
                ws.Range("AX" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B399D13B-5761-4CC2-A3ED-194AECE8E8B1'" 'SFO
                ws.Range("AY" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='F171285A-E7E7-49A2-AEFE-4E6608B94FA8'" 'COO
                ws.Range("AZ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7E542323-FE91-4A38-821F-6F0E0FB6EAD6'" 'DOCSCO
                ws.Range("BA" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5512096C-87AB-42A3-A767-BBEF45F7B62A'" 'AF (Air)/OF(Sea)
                ws.Range("BB" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6FEF564B-E832-49B8-A3BB-9476857B1799'" 'CLF
                ws.Range("BC" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='C7CECC14-DB38-45D8-AEE5-74C84F6D0E95'" 'DOF
                ws.Range("BD" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3A40F27A-F161-4E3E-92F4-A80BA390FF9C'" 'CICD
                ws.Range("BE" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E34A2550-0AE1-4FFE-812D-95524ECB7233'" 'THCD
                ws.Range("BF" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='691F4CB2-B983-4D49-A9AD-FE05F06F9680'" 'CFSD
                ws.Range("BG" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='1CBEDCAA-FA9C-4A74-853D-1A81C157794F'" 'AMDF
                ws.Range("BH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6DFF5D30-2A49-47ED-9F64-FA62C2F42C26'" 'HFD
                ws.Range("BI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD25EDF7-188C-45C3-A2B5-2B17B1B1116F'" ' CDFD
                ws.Range("BJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='4E2AA215-A1FC-41FF-8B5A-B25F3B4DC423'" 'TRKD
                ws.Range("BK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E90AE394-D278-4D73-9ABC-334CC9034096'" 'SFD
                ws.Range("BL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B5E0DD8A-A219-45DC-8BDC-29B7B848CA26'" 'CSHT
                ws.Range("BM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='21AA77C4-AC31-4DE5-980C-7411FAC7BB52'" 'LFD
                ws.Range("BN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='DC52C720-B53E-4298-B1BA-9899518201AD'" 'LOLO
                ws.Range("BO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='0866517F-1847-4130-AD68-1CB9D45C7B4A'" 'WHDO
                ws.Range("BP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6EF590A5-33E6-4ED2-9F07-AE49EAB62F0C'" 'WHHF
                ws.Range("BQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E0D7F147-CA9B-4BB2-A11C-1D06FC322C1A'" 'IMTAX
                ws.Range("BR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from inboundfreight where Inboundfreightid ='" & ds_seaimp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D8D6B7D-5C8B-4639-9617-D9BF445D99AC'" 'BCQT
                ws.Range("BS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)
                DongHienTai += 1
                AdvanceExportProgress("Đang xuất Sea Import...")

            Next

            '---------Sea Exp-------

            For i As Integer = 0 To GetRowCount(ds_seaexp) - 1
                ws.Range("S" + DongHienTai.ToString).Value2 = "TBSL"

                Try
                    Dim sql_cus As String = "select * from customer where customer_id ='" & ds_seaexp.Tables(0).Rows(i).Item("customerid_showTC").ToString & "'"
                    Dim ds_cus As DataSet = ReadDataSet(sql_cus)
                    If (ds_cus.Tables(0).Rows.Count > 0) Then
                        ws.Range("B" + DongHienTai.ToString).Value2 = ds_cus.Tables(0).Rows(0).Item("Company").ToString
                    End If
                Catch ex As Exception

                End Try

                Dim lot As String = ds_seaexp.Tables(0).Rows(i).Item("lot").ToString()

                If lot.Length > 0 Then
                    ws.Range("C" & DongHienTai.ToString()).Value2 = lot.Substring(lot.Length - 1, 1)
                End If

                Dim dateText As String = ds_seaexp.Tables(0).Rows(i).Item("datereport").ToString()

                Dim reportDate As DateTime = DateTime.ParseExact(
                    dateText,
                    "d-MMM-yyyy",
                    CultureInfo.InvariantCulture
                )

                Dim weekNo As Integer = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                    reportDate,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday
                )

                ws.Range("D" & DongHienTai.ToString()).Value2 = weekNo
                ws.Range("E" & DongHienTai.ToString()).Value2 = "Sea"
                ws.Range("F" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("CY_CFS_ITEM").ToString()
                ws.Range("G" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("pic_report").ToString()
                ws.Range("H" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("lot").ToString()
                ws.Range("I" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("shipper").ToString()
                ws.Range("J" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("consignee").ToString()
                ws.Range("K" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("MBL").ToString()
                ws.Range("L" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("HBL").ToString()

                Dim sql_cont As String = "select * from containerrepair where inboundid ='" & ds_seaexp.Tables(0).Rows(i).Item("Blib_id").ToString() & "'"
                Dim ds_cont As DataSet = ReadDataSet(sql_cont)
                If (ds_cont.Tables(0).Rows.Count > 0) Then
                    Dim typeText As String = ds_cont.Tables(0).Rows(0).Item("type").ToString()

                    If typeText.Length >= 2 Then
                        typeText = typeText.Substring(0, 2)
                    End If

                    ws.Range("M" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokien").ToString() & " " & typeText
                    ws.Range("N" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokg").ToString()
                    ws.Range("O" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("chargeable").ToString()
                    ws.Range("P" & DongHienTai.ToString()).Value2 = ds_cont.Tables(0).Rows(0).Item("sokhoi").ToString()
                    ws.Range("Q" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("R" & DongHienTai.ToString()).Value2 = "" 'hang air khong co
                    ws.Range("S" & DongHienTai.ToString()).Value2 = "" 'hang air khong co

                End If


                ws.Range("T" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("shippingline").ToString()
                ws.Range("U" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("pol").ToString()
                ws.Range("V" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("polcode").ToString()
                ws.Range("W" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("podcode").ToString()
                ws.Range("X" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Y" & DongHienTai.ToString()).Value2 = ""
                ws.Range("Z" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("cargo_ready").ToString()
                ws.Range("AA" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("closing").ToString()
                ws.Range("AB" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("eta").ToString()
                ws.Range("AC" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("SAILINGDATE").ToString()
                ws.Range("AD" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("mbl").ToString()
                ws.Range("AE" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("vessel").ToString()
                ws.Range("AF" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("voyage").ToString()
                ws.Range("AG" & DongHienTai.ToString()).Value2 = ds_seaexp.Tables(0).Rows(i).Item("remarks").ToString()
                Dim sql_debit As String = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B70D388F-2C6E-4317-83CD-FCB03AF742B2'"
                ws.Range("AH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E4DE6E06-943E-4675-8F4B-C3E8999D9028'" 'ELF
                ws.Range("AI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)


                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='47448840-23BB-4811-9982-6B2CEB9DA31A'" 'HFO
                ws.Range("AJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D76C2E1-2990-4DE2-A3D9-716BDD14AE88'" 'THCO
                ws.Range("AK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='75109072-2E25-4E0A-8C35-36FC8F368E22'" 'CFSO
                ws.Range("AL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='8A8E7068-2344-40E6-B24D-B19416A0F75D'" 'STUFF
                ws.Range("AM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7A42FB16-CCFE-49F9-B1B2-4DDCA14FC5BC'" 'CDFO
                ws.Range("AN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9AEB4F22-CC2E-4F1C-B2C5-D8DCF123D33C'" 'VGM
                ws.Range("AO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='D777E578-776B-4EEB-82AD-1996DDF8823C'" 'BKF
                ws.Range("AP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD21CED4-FB6E-4FE0-955A-051E597C7222'" 'AWBF/ BLF
                ws.Range("AQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='9BEB8EBD-6CB3-4781-AB35-AF7B840EC35E'" 'TLXF
                ws.Range("AR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7FD2AC51-5610-4F36-973F-CBC78E58A5BA'" 'GCO
                ws.Range("AS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='308B2D09-51CB-49B6-8380-867BD03AFD43'" 'WHGC
                ws.Range("AT" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3371EA5F-3FFC-4F94-ADC7-CBED140FF843'" 'PCO
                ws.Range("AU" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5470ACDA-C77D-402C-8597-E4DFAFDA0BB7'" 'APTFO
                ws.Range("AV" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='14387A98-2388-4041-B3EF-F9331056769C'" 'SEALF
                ws.Range("AW" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='CE6A6CF6-195A-4004-B026-A3A9548EAB93'" 'INSFO
                ws.Range("AX" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B399D13B-5761-4CC2-A3ED-194AECE8E8B1'" 'SFO
                ws.Range("AY" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='F171285A-E7E7-49A2-AEFE-4E6608B94FA8'" 'COO
                ws.Range("AZ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='7E542323-FE91-4A38-821F-6F0E0FB6EAD6'" 'DOCSCO
                ws.Range("BA" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5512096C-87AB-42A3-A767-BBEF45F7B62A'" 'AF (Air)/OF(Sea)
                ws.Range("BB" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6FEF564B-E832-49B8-A3BB-9476857B1799'" 'CLF
                ws.Range("BC" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='C7CECC14-DB38-45D8-AEE5-74C84F6D0E95'" 'DOF
                ws.Range("BD" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='3A40F27A-F161-4E3E-92F4-A80BA390FF9C'" 'CICD
                ws.Range("BE" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E34A2550-0AE1-4FFE-812D-95524ECB7233'" 'THCD
                ws.Range("BF" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='691F4CB2-B983-4D49-A9AD-FE05F06F9680'" 'CFSD
                ws.Range("BG" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='1CBEDCAA-FA9C-4A74-853D-1A81C157794F'" 'AMDF
                ws.Range("BH" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6DFF5D30-2A49-47ED-9F64-FA62C2F42C26'" 'HFD
                ws.Range("BI" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='FD25EDF7-188C-45C3-A2B5-2B17B1B1116F'" ' CDFD
                ws.Range("BJ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='4E2AA215-A1FC-41FF-8B5A-B25F3B4DC423'" 'TRKD
                ws.Range("BK" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E90AE394-D278-4D73-9ABC-334CC9034096'" 'SFD
                ws.Range("BL" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='B5E0DD8A-A219-45DC-8BDC-29B7B848CA26'" 'CSHT
                ws.Range("BM" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='21AA77C4-AC31-4DE5-980C-7411FAC7BB52'" 'LFD
                ws.Range("BN" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='DC52C720-B53E-4298-B1BA-9899518201AD'" 'LOLO
                ws.Range("BO" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='0866517F-1847-4130-AD68-1CB9D45C7B4A'" 'WHDO
                ws.Range("BP" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='6EF590A5-33E6-4ED2-9F07-AE49EAB62F0C'" 'WHHF
                ws.Range("BQ" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='E0D7F147-CA9B-4BB2-A11C-1D06FC322C1A'" 'IMTAX
                ws.Range("BR" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)

                sql_debit = "select ISNULL(sum(thanhtientruocthueVND), 0) as total from outboundfreight where outboundfreightid ='" & ds_seaexp.Tables(0).Rows(i).Item("blib_id").ToString() & "' and itemid ='5D8D6B7D-5C8B-4639-9617-D9BF445D99AC'" 'BCQT
                ws.Range("BS" & DongHienTai.ToString()).Value2 = FormatNumber(GetDebitTotal(sql_debit), 2)
                DongHienTai += 1
                AdvanceExportProgress("Đang xuất Sea Export...")

            Next

            AdvanceExportProgress("Đang lưu file Excel...")
            workbook.SaveAs(outputPath)

            MessageBox.Show("Xuất Excel thành công!" & vbCrLf & outputPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Xuất Excel thất bại: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            EndExportProgress()
            ReleaseExcel(ws, workbook, app)
            If workPath IsNot Nothing AndAlso File.Exists(workPath) Then
                Try
                    File.Delete(workPath)
                Catch
                End Try
            End If
        End Try

    End Sub

    Private progressCurrent As Integer = 0
    Private progressTotal As Integer = 0

    Private Sub BeginExportProgress(total As Integer)
        progressCurrent = 0
        progressTotal = Math.Max(total, 1)
        prbExport.Minimum = 0
        prbExport.Maximum = progressTotal
        prbExport.Value = 0
        prbExport.Visible = True
    End Sub

    Private Sub AdvanceExportProgress(status As String)
        progressCurrent += 1
        If progressCurrent > progressTotal Then
            progressCurrent = progressTotal
        End If
        prbExport.Value = progressCurrent
        Dim percent As Integer = CInt(progressCurrent * 100 / progressTotal)
        lblProgress.Text = status & " (" & progressCurrent & "/" & progressTotal & " - " & percent & "%)"
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub EndExportProgress()
        prbExport.Visible = False
        prbExport.Value = 0
        lblProgress.Text = ""
        Button1.Enabled = True
    End Sub

    Private Sub ReleaseExcel(ByRef ws As _Worksheet, ByRef workbook As _Workbook, ByRef app As Application)
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

        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub

    Private Function GetRowCount(ds As DataSet) As Integer
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then
            Return 0
        End If

        Return ds.Tables(0).Rows.Count
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
End Class