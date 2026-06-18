Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmLoadinglist

    Private Sub frmDischargeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            QueryCombo()
        Catch ex As Exception

        End Try
    End Sub
    Sub QueryCombo()
        Try
            Dim id, value, strSQL As String


            id = "vessel"
            value = "vessel"
            Me.cboVessel.Items.Clear()
            strSQL = "Select distinct vessel From outbound  order by vessel   "
            loadDataToObject(Me.cboVessel, strSQL, id, value)




            Me.cbovoy.Items.Clear()
            id = "voyage"
            value = "voyage"
            strSQL = "Select distinct voyage From outbound  order by voyage   "
            loadDataToObject(Me.cbovoy, strSQL, id, value)
            '----------------------------------------------




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim app As Application
            Try

                Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                Dim path As String
                app = New Application()
                app.Visible = False

                Dim dsdata As New DataSet
                Dim workbooks As Workbooks
                workbooks = app.Workbooks
                Dim workbook As _Workbook


                path = StartupPath & "\dischargelist.xlsx"

                workbook = workbooks.Open(path)



                Dim sheets As Sheets
                sheets = workbook.Worksheets
                Dim ws As _Worksheet
                ws = sheets.Item(2)
                If ws Is Nothing Then
                    app.Quit()

                    Return
                End If
                Dim DongCongThuc As Integer = 9
                Dim DongHienTai As Integer = 11
                Dim donghientaiF As Integer = DongHienTai
                Dim BillId As String
                Dim n As Integer
                Dim dem As Integer = 0
                Dim BillNo As String = ""
                Dim market As String = ""
                ' lay ten khach hang
                Dim sqlC As String
                Dim cus, add, tel, fax, taxcode As String
                Dim dsC As New DataSet
                Dim j As Integer

                Dim tangP As Integer = 9
                Dim tang As Integer = 15
                Dim ds As New DataSet
                Dim sql, HBL As String
                Dim i As Integer = 0

                Dim stt As Integer = 1
                Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
                Dim kien As Double = 0
                Dim kg As Double = 0
                Dim khoi As Double = 0
                '-----------
                Dim sqlContainer As String
                Dim dsContainer As New DataSet

                '  sql = "select * from inbound where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "





                '  sql = "select * from " & gPrintInbound & " where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "







                ws.Range("c12").Value2 = Me.cboVessel.Text
                ws.Range("h12").Value2 = Me.DataGridView1.Item("etd", 0).Value
                ws.Range("k12").Value2 = Me.DataGridView1.Item("carrier", 0).Value
                If Me.DataGridView1.Rows.Count > 0 Then
                    ' hien thi thong tin co ban
                    For i = 0 To Me.DataGridView1.Rows.Count - 1

                        ws.Range("a" + tang.ToString).Value2 = Me.DataGridView1.Item("contno", i).Value

                        ws.Range("c" + tang.ToString).Value2 = Me.DataGridView1.Item("type", i).Value

                        ws.Range("d" + tang.ToString).Value2 = Me.DataGridView1.Item("sealno", i).Value



                        ws.Range("e" + tang.ToString).Value2 = Me.DataGridView1.Item("netweight", i).Value
                        ws.Range("f" + tang.ToString).Value2 = Me.DataGridView1.Item("grossweight", i).Value


                        ws.Range("g" + tang.ToString).Value2 = Me.DataGridView1.Item("PACKAGEDESCRIPTIONOFGOODS", i).Value
                        ws.Range("j" + tang.ToString).Value2 = Me.DataGridView1.Item("oprcode", i).Value
                        ws.Range("k" + tang.ToString).Value2 = Me.DataGridView1.Item("pol", i).Value
                        ws.Range("l" + tang.ToString).Value2 = Me.DataGridView1.Item("pod", i).Value

                        ws.Range("m" + tang.ToString).Value2 = Me.DataGridView1.Item("remarks", i).Value
                        ' ws.Range("i" + tang.ToString).Value2 = Me.DataGridView1.Item("blno", i).Value

                        ' ws.Range("h" + tang.ToString).Value2 = Me.DataGridView1.Item("DESTINATION", i).Value
                        tang += 1
                        ' stt += 1
                    Next
                End If
                ' sum
                ws.Range("k" + (tang + 3).ToString).Value2 = "Tp.HCM, ngày " + CDate(Getdate()).Day.ToString + " tháng " + CDate(Getdate()).Month.ToString + " năm " + CDate(Getdate()).Year.ToString
                ' Dim path As String = ""
                'path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + hbl + "_" & Now.Second & ".xlsx")
                'If path = "" Then
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" & Me.cboVessel.Text & "_" & Me.cbovoy.Text & Now.Second & ".xlsx"
                'End If
                '------------------------------
                Dim format1 As String
                '  path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + hbl + "_" & Now.Second & ".xlsx"
                'If app.Version = "11.0" Then
                '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
                'ElseIf (app.Version = "12.0") Then
                '    format1 = Excel.XlFileFormat.xlExcel7 ';   
                'End If
                ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

                workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
                DisplayMessage(True, "File name : " & path & " saved.")

            Catch ex As Exception
                MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
                MsgBox(Err.Description)
                Return
            Finally
                app.Quit()
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim i, currow As Integer
            Me.DataGridView1.Rows.Clear()
            If Me.CHKSOC.Checked = True Then
                sql = "select * from outbound left join containertype on outbound.BLOB_ID=containertype.outboundid where vessel='" & Me.cboVessel.Text.Trim & "' and voyage='" & Me.cbovoy.Text.Trim & "' and nvocc=1 "
            End If
            If Me.CHKCOC.Checked = True Then
                sql = "select * from outbound left join containertype on outbound.BLOB_ID=containertype.outboundid where vessel='" & Me.cboVessel.Text.Trim & "' and voyage='" & Me.cbovoy.Text.Trim & "' and nvocc=0 "
            End If
            If Me.chlallsoccoc.Checked = True Then
                sql = "select * from outbound left join containertype on outbound.BLOB_ID=containertype.outboundid where vessel='" & Me.cboVessel.Text.Trim & "' and voyage='" & Me.cbovoy.Text.Trim & "'"
            End If
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    ' Me.DataGridView1.Item("no", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                    Me.DataGridView1.Item("contno", currow).Value = ds.Tables(0).Rows(i).Item("containerno").ToString
                    Me.DataGridView1.Item("type", currow).Value = ds.Tables(0).Rows(i).Item("containertype").ToString
                    Me.DataGridView1.Item("sealno", currow).Value = ds.Tables(0).Rows(i).Item("seal").ToString
                    Try
                        Me.DataGridView1.Item("netweight", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("netweight").ToString, 0)

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("GROSSWEIGHT", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("sokg").ToString, 2)

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("PACKAGEDESCRIPTIONOFGOODS", currow).Value = ds.Tables(0).Rows(i).Item("DESCRIPTIONcontainer").ToString

                    Catch ex As Exception

                    End Try
                    Try
                        ' Me.DataGridView1.Item("blno", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("oprcode", currow).Value = ds.Tables(0).Rows(i).Item("oprcode").ToString

                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("POL", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("POD", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                    Catch ex As Exception

                    End Try
                    'Try
                    'Me.DataGridView1.Item("eta", currow).Value = ds.Tables(0).Rows(i).Item("eta").ToString

                    'Catch ex As Exception

                    'End Try

                    Try
                        Me.DataGridView1.Item("etd", currow).Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString

                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("carrier", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString

                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("remarks", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString

                    Catch ex As Exception

                    End Try


                Next

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboVessel_Leave(sender As Object, e As EventArgs) Handles cboVessel.Leave
        Try
            Dim id, value, strSQL As String






            Me.cbovoy.Items.Clear()
            id = "voyage"
            value = "voyage"
            strSQL = "Select distinct voyage From outbound where vessel='" & Me.cboVessel.Text & "'   order by voyage   "
            loadDataToObject(Me.cbovoy, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVessel.SelectedIndexChanged

    End Sub
End Class