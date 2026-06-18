Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmPrintBiennhanhoso

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cmd1 As New ADODB.Command
            Dim i As Integer
            Dim sql, strQuery1 As String
            Dim ds As New DataSet
            'Dim cmd1 As New ADODB.Command
            If Me.ComboBox1.Text = "" Then
                DisplayMessage(True, "Ref./Job. ?")
                Me.ComboBox1.Focus()
                Exit Sub
            End If
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from inbienbangiaonhan"

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' sau khi xoa ta them vao

            sql = "select * from theodoilohanglogistics  where logisticsid='" & FindValueID(Me.ComboBox1, Me.ComboBox1.Text) & "' and intheodoi='True' " ' os=thu ho

            ' lay so lieu debitnote ghi vao tamdebit
            'thong so 
            'gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            'gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            ds = ReadDataSet(sql)
            'Dim i As Integer
            'Dim thanhtien1 As Double = 0

            'Dim strQuery1 As String
            Dim rs1 As New ADODB.Recordset
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    strQuery1 = "SELECT * "
                    strQuery1 = strQuery1 & "FROM inbienbangiaonhan "
                    rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()


                        ''-------------------------
                        ''-------------------------
                        '.Fields("stt").Value = (i + 1)
                        .Fields("id").Value = NewId()

                        .Fields("tenchungtu").Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                        .Fields("soinvoice").Value = ds.Tables(0).Rows(i).Item("soinvoice").ToString '+ " x " + ds.Tables(0).Rows(i).Item("containertype").ToString
                        '.Fields("thue").Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
                        '.Fields("donvi").Value = ds.Tables(0).Rows(i).Item("containertype").ToString
                        '.Fields("loaitiente").Value = ds.Tables(0).Rows(i).Item("currency").ToString
                        .Fields("bancopy").Value = ds.Tables(0).Rows(i).Item("bancopy").ToString
                        .Fields("banchinh").Value = ds.Tables(0).Rows(i).Item("bangoc").ToString
                        Try
                            .Fields("trigia").Value = ds.Tables(0).Rows(i).Item("trigia").ToString
                        Catch ex As Exception
                            .Fields("trigia").Value = "0"
                        End Try

                        '.Fields("ghichu").Value = ds.Tables(0).Rows(i).Item("note").ToString


                        .Update()
                    End With
                    rs1.Close()
                Next
            End If
            Dim strReportName As String
            strReportName = "ReportBiennhanbangiao"
            'End If
            Dim rptDoCument As ReportDocument





            '--------------------------------------
            rptDoCument = New ReportDocument
            '---------------------------------

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)

            ' CrystalReportViewer1.ReportSource = rptDoCument
            '------------- 
            Dim ngay As Object
            Dim ds1 As New DataSet
            Dim sql1 As String
            Dim bennhan As String
            sql1 = "select * from logistics where blob_id='" & FindValueID(Me.ComboBox1, Me.ComboBox1.Text) & "' "
            ds1 = ReadDataSet(sql1)
            If ds1.Tables(0).Rows.Count > 0 Then
                ngay = rptDoCument.ReportDefinition.ReportObjects("txtbennhan")
                ngay.text = ds1.Tables(0).Rows(0).Item("shipper").ToString
                ngay = rptDoCument.ReportDefinition.ReportObjects("so")
                ngay.text = ds1.Tables(0).Rows(0).Item("ref").ToString
            Else
            End If







            ngay = rptDoCument.ReportDefinition.ReportObjects("txtngay")
            ngay.text = CDate(Getdate()).Date



            rptDoCument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            For Each tbCurrent In rptDoCument.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = strServer
                    .UserID = strUserId
                    .Password = strPassword
                    .DatabaseName = strDatabase
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            Me.CrystalReportViewer1.ReportSource = rptDoCument

            rptDoCument.Refresh()

            'If frmInBoundRemarks.CountBill > 1 Then
            '    rptDoCument.PrintToPrinter(1, True, 1, 2)
            '    Me.Close()
            'End If
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPrintBiennhanhoso_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim id, value, strSQL, strQuery As String
            '-----------------------------------------------
            id = "blob_id"
            value = "ref"
            Me.ComboBox1.Items.Clear()
            strSQL = "Select distinct blob_id,ref,dateupdate From Logistics where Continued=1 order by dateUpdate desc "
            loadDataToObject(Me.ComboBox1, strSQL, id, value)
            '------------------------
        Catch ex As Exception

        End Try
    End Sub
End Class