Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmPrintBill
    Dim flag As Integer
    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Try
            print()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub print()
        Try
            Dim sql As String
            Dim ds As New DataSet
            '

            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String


            rptDoCument = New ReportDocument
            'If Me.chkDraft.Checked = True Then
            '    strReportName = "rptprinthbl_draft"
            '    'Else
            '    '    strReportName = "rptprinthbl"
            'End If
            sql = "select * from outbound left join containertype on outbound.blob_id=containertype.outboundid where blob_id='" & gOutboundID & "'  order by convert(datetime,containertype.dateupdate) desc " ' os=thu ho
            ds = ReadDataSet(sql)
            'Dim i As Integer



            Dim ktmarks() As String
            Dim ktdescription() As String
            Dim sodongcont As Integer = 0
            Dim sodongmarks As Integer = 0
            Dim sodongdescription As Integer = 0

            If ds.Tables(0).Rows.Count > 0 Then
                ' DEM SO DONG SHIPPING MẢKS
                ktmarks = ds.Tables(0).Rows(0).Item("shippingmarks").ToString().Split(Chr(13))
                ktdescription = ds.Tables(0).Rows(0).Item("description").ToString().Split(Chr(13))

                sodongcont = ds.Tables(0).Rows.Count
                sodongmarks = ktmarks.Length
                sodongdescription = ktdescription.Length

            End If

            If sodongcont + sodongmarks > 25 Then
                strReportName = "rptprinthbl_draft_att"
                Me.chkatt.Checked = True
            Else
                If sodongdescription > 20 Then
                    strReportName = "rptprinthbl_draft_att"
                    Me.chkatt.Checked = True
                Else
                    strReportName = "rptprinthbl_draft"
                    Me.chkatt.Checked = False

                End If

            End If

            '------------------------------------
            'If Me.chkatt.Checked = True Then
            '    strReportName = "rptprinthbl_draft_att"
            'Else
            '    strReportName = "rptprinthbl_draft"
            'End If




            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)

            'gOutboundID
            ' xoa temp
            '--------------------
            Dim tongkg As Double = 0
            Dim tongkhoi As Double = 0
            '----------------------------
            Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from tempprintHBL  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' them
            sql = "select * from outbound left join containertype on outbound.blob_id=containertype.outboundid where blob_id='" & gOutboundID & "'  order by containertype,containerno " ' os=thu ho
            ds = ReadDataSet(sql)
            Dim i As Integer
            Dim thanhtien1 As Double = 0

            Dim strQuery1 As String
            Dim rs1 As New ADODB.Recordset
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        ' thanhtien1 += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

                    Catch ex As Exception

                    End Try
                    strQuery1 = "SELECT * "
                    strQuery1 = strQuery1 & "FROM tempprintHBL "
                    rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        ''-------------------------
                        .Fields("socont").Value = ds.Tables(0).Rows(i).Item("containerno").ToString + "/ " + ds.Tables(0).Rows(i).Item("containerTYPE").ToString + " /" + ds.Tables(0).Rows(i).Item("seal").ToString


                        Try
                            .Fields("sokien").Value = ds.Tables(0).Rows(i).Item("sokien").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("mota").Value = ds.Tables(0).Rows(i).Item("descriptionContainer").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("LOAIKIEN").Value = ds.Tables(0).Rows(i).Item("type").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("sokgs").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("sokg").ToString), 3) ' + " " + ds.Tables(0).Rows(i).Item("dvgw").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            tongkg += CDbl(ds.Tables(0).Rows(i).Item("sokg").ToString)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("sokhoi").Value = FormatNumber(ds.Tables(0).Rows(i).Item("sokhoi").ToString, 3) 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try

                        Try
                            tongkhoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi").ToString)
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("netweight").Value = ds.Tables(0).Rows(i).Item("netweight").ToString + " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("dateupdate_").Value = i.ToString  '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("stt").Value = i + 1  '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("say").Value = ds.Tables(0).Rows(i).Item("saycontainer").ToString '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("containertype").Value = ds.Tables(0).Rows(i).Item("containertype").ToString
                        Catch ex As Exception

                        End Try
                        .Update()
                    End With
                    rs1.Close()
                Next
            End If

            '----------------------------
            ' them cac so lieu string
            Dim T1() As String
            Dim T As String
            Dim showText As Object
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ''=====================
                ' them shipping mark vao so cont
                strQuery1 = "SELECT * "
                strQuery1 = strQuery1 & "FROM tempprintHBL "
                rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs1

                    .AddNew()

                    .Fields("id").Value = NewId()
                    ''-------------------------
                    ''-------------------------
                    .Fields("socont").Value = ds.Tables(0).Rows(0).Item("shippingmarks").ToString '"" 'ds.Tables(0).Rows(i).Item("containerno").ToString + "/ " + ds.Tables(0).Rows(i).Item("containerTYPE").ToString + " /" + ds.Tables(0).Rows(i).Item("seal").ToString

                    .Fields("stt").Value = i + 1

                    Try
                        .Fields("say").Value = ds.Tables(0).Rows(0).Item("saycontainer").ToString '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                    Catch ex As Exception

                    End Try
                    .Update()
                End With
                rs1.Close()

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtbill")
                'T1 = Strings.Split(ds.Tables(0).Rows(0).Item("mblmawb").ToString, Chr(13))
                'For CountA As Integer = 0 To T1.Length - 1
                '    T &= T1(CountA).Replace(Chr(10), "  ")
                '    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                '        T &= " "
                '    Next
                'Next
                showText.Text = ds.Tables(0).Rows(0).Item("mblmawb").ToString


                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtshipper")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("shipper").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtconsignee")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("consignee").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================

                ''=====================
                Try
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtfeeder")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("feeder").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                Catch ex As Exception

                End Try



                ''=====================

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtnotify")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("notify").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtPOR")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("POR").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                Try
                    ''=====================
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txthbls")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("hbls").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                Catch ex As Exception

                End Try
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtPOL")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("POL").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtPOD")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("POD").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                If UCase(strUserId) Like "*TRUCK*" Then
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtVESSEL")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("VESSEL").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = "TRUCK(" + T + ")"
                Else
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtVESSEL")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("VESSEL").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                End If




                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtVOY")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("VOYAGE").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = "V." + T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdel")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("del").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdest")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("dest").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdaily")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("AgencyName").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtsay")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("saycontainer").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtcycy")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("CY_CFS_ITEM").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================


                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtfreightAndCharges")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("FreightAmount").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtprepaid")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("prepaid").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtcollect")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("collect").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtpayableat")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("FreightPayableAt").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtplaceanddate")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("placeanddate").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtNoOfBill")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("NumberOfOriginal").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtshippingmarks")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("shippingmarks").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                If Me.chkdescriptionall.Checked = True Then
                    rptDoCument.ReportDefinition.ReportObjects("txtdescription").ObjectFormat.EnableSuppress = False
                    '  rptDoCument.ReportDefinition.ReportObjects("mota1").ObjectFormat.EnableSuppress = True
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtdescription")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("description").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                Else
                    rptDoCument.ReportDefinition.ReportObjects("txtdescription").ObjectFormat.EnableSuppress = True
                    ' rptDoCument.ReportDefinition.ReportObjects("mota1").ObjectFormat.EnableSuppress = False
                End If
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtonboard")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("onboarddate").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                ''=====================
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtshow")

                showText.Text = Me.cboBillType.Text
                ''=====================
            End If
            Try
                showText = rptDoCument.ReportDefinition.ReportObjects("txttongkg")

                showText.Text = FormatNumber(tongkg, 3)


                showText = rptDoCument.ReportDefinition.ReportObjects("txttongkhoi")

                showText.Text = FormatNumber(tongkhoi, 3)
            Catch ex As Exception

            End Try


            Try
                If Me.chkSign.Checked = True Then
                    rptDoCument.ReportDefinition.ReportObjects("picture1").ObjectFormat.EnableSuppress = False

                Else
                    rptDoCument.ReportDefinition.ReportObjects("picture1").ObjectFormat.EnableSuppress = True

                End If
            Catch ex As Exception

            End Try


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
            '------------
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            'Formatting paper

            If flag = 1 Then
                mymargins = rptDoCument.PrintOptions.PageMargins
                mymargins.topMargin = gTopM
                mymargins.bottomMargin = gBottomM
                mymargins.leftMargin = gLeftM
                mymargins.rightMargin = gRightM
                'rptDoCument.PrintOptions.ApplyPageMargins(mymargins)
            End If

            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

            rptDoCument.Refresh()


            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub print_att()
        Try
            Dim sql As String
            Dim ds As New DataSet
            '

            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String
            Dim tongkg As Double = 0
            Dim tongkhoi As Double = 0

            rptDoCument = New ReportDocument
            'If Me.chkDraft.Checked = True Then
            '    strReportName = "rptprinthbl_draft"
            '    'Else
            '    '    strReportName = "rptprinthbl"
            'End If
            ' If Me.chkatt.Checked = True Then
            strReportName = "rptprinthbl_draft_att"
            If Me.chkatt.Checked = True Then

                strReportName = "rptprinthbl_draft_att_2"

            End If

            ' Else
            ' strReportName = "rptprinthbl_draft"
            'End If




            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)

            'gOutboundID
            ' xoa temp
            '--------------------

            Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from tempprintHBL  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' them
            sql = "select * from outbound left join containertype on outbound.blob_id=containertype.outboundid where blob_id='" & gOutboundID & "'  order by containertype,containerno " ' os=thu ho
            ds = ReadDataSet(sql)
            Dim i As Integer
            Dim thanhtien1 As Double = 0

            Dim strQuery1 As String
            Dim rs1 As New ADODB.Recordset
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        ' thanhtien1 += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

                    Catch ex As Exception

                    End Try
                    strQuery1 = "SELECT * "
                    strQuery1 = strQuery1 & "FROM tempprintHBL "
                    rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        ''-------------------------
                        .Fields("socont").Value = ds.Tables(0).Rows(i).Item("containerno").ToString + "/ " + ds.Tables(0).Rows(i).Item("containerTYPE").ToString + " /" + ds.Tables(0).Rows(i).Item("seal").ToString


                        Try
                            .Fields("sokien").Value = ds.Tables(0).Rows(i).Item("sokien").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("mota").Value = ds.Tables(0).Rows(i).Item("descriptionContainer").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("LOAIKIEN").Value = ds.Tables(0).Rows(i).Item("type").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("sokgs").Value = CDbl(ds.Tables(0).Rows(i).Item("sokg").ToString) ' + " " + ds.Tables(0).Rows(i).Item("dvgw").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("sokhoi").Value = ds.Tables(0).Rows(i).Item("sokhoi").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("netweight").Value = ds.Tables(0).Rows(i).Item("netweight").ToString + " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("dateupdate_").Value = i.ToString  '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("stt").Value = i + 1  '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("say").Value = ds.Tables(0).Rows(i).Item("saycontainer").ToString '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                        Catch ex As Exception

                        End Try

                        Try
                            tongkg += CDbl(ds.Tables(0).Rows(i).Item("sokg").ToString)
                        Catch ex As Exception

                        End Try


                        Try
                            tongkhoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi").ToString)
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("containertype").Value = ds.Tables(0).Rows(i).Item("containertype").ToString
                        Catch ex As Exception

                        End Try

                        .Update()
                    End With
                    rs1.Close()
                Next
            End If

            '----------------------------
            ' them cac so lieu string
            Dim T1() As String
            Dim T As String
            Dim showText As Object
            sql = "select * from outbound where blob_id='" & gOutboundID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ''=====================
                ' them shipping mark vao so cont
                strQuery1 = "SELECT * "
                strQuery1 = strQuery1 & "FROM tempprintHBL "
                rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs1

                    .AddNew()

                    .Fields("id").Value = NewId()
                    ''-------------------------
                    ''-------------------------
                    .Fields("socont").Value = ds.Tables(0).Rows(0).Item("shippingmarks").ToString '"" 'ds.Tables(0).Rows(i).Item("containerno").ToString + "/ " + ds.Tables(0).Rows(i).Item("containerTYPE").ToString + " /" + ds.Tables(0).Rows(i).Item("seal").ToString

                    .Fields("stt").Value = i + 1

                    Try
                        .Fields("say").Value = ds.Tables(0).Rows(0).Item("saycontainer").ToString '+ " " + ds.Tables(0).Rows(i).Item("dvnw").ToString

                    Catch ex As Exception

                    End Try
                    .Update()
                End With
                rs1.Close()

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtbill")
                'T1 = Strings.Split(ds.Tables(0).Rows(0).Item("mblmawb").ToString, Chr(13))
                'For CountA As Integer = 0 To T1.Length - 1
                '    T &= T1(CountA).Replace(Chr(10), "  ")
                '    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                '        T &= " "
                '    Next
                'Next
                showText.Text = ds.Tables(0).Rows(0).Item("mblmawb").ToString


                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtshipper")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("shipper").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtconsignee")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("consignee").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================

                ''=====================
                Try
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtfeeder")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("feeder").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                Catch ex As Exception

                End Try



                ''=====================

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtnotify")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("notify").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtPOR")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("POR").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                Try
                    ''=====================
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txthbls")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("hbls").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                Catch ex As Exception

                End Try
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtPOL")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("POL").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtPOD")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("POD").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtVESSEL")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("VESSEL").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T



                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtVOY")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("VOYAGE").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = "V." + T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdel")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("del").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdest")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("dest").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdaily")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("AgencyName").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtsay")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("saycontainer").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                Try
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtsay_")
                    showText.text = ds.Tables(0).Rows(0).Item("saycontainer").ToString
                Catch ex As Exception

                End Try

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtcycy")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("CY_CFS_ITEM").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================


                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtfreightAndCharges")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("FreightAmount").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtprepaid")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("prepaid").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtcollect")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("collect").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtpayableat")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("FreightPayableAt").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtplaceanddate")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("placeanddate").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtNoOfBill")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("NumberOfOriginal").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtshippingmarks")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("shippingmarks").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
            
                Try
                    If tongkg > 0 Then
                        showText = rptDoCument.ReportDefinition.ReportObjects("txttongkg")

                        showText.Text = FormatNumber(tongkg.ToString, 3)
                    End If


                    If tongkhoi > 0 Then
                        showText = rptDoCument.ReportDefinition.ReportObjects("txttongkhoi")

                        showText.Text = FormatNumber(tongkhoi.ToString, 3)
                    End If

                Catch ex As Exception

                End Try

                ''=====================
                If Me.chkdescriptionall.Checked = True Then
                    rptDoCument.ReportDefinition.ReportObjects("txtdescription").ObjectFormat.EnableSuppress = False
                    '  rptDoCument.ReportDefinition.ReportObjects("mota1").ObjectFormat.EnableSuppress = True
                    T = ""
                    showText = rptDoCument.ReportDefinition.ReportObjects("txtdescription")
                    T1 = Strings.Split(ds.Tables(0).Rows(0).Item("description").ToString, Chr(13))
                    For CountA As Integer = 0 To T1.Length - 1
                        T &= T1(CountA).Replace(Chr(10), "  ")
                        For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                            T &= " "
                        Next
                    Next
                    showText.Text = T
                Else
                    rptDoCument.ReportDefinition.ReportObjects("txtdescription").ObjectFormat.EnableSuppress = True
                    ' rptDoCument.ReportDefinition.ReportObjects("mota1").ObjectFormat.EnableSuppress = False
                End If
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtonboard")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("onboarddate").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''=====================
                ''=====================
                ''=====================
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtshow")

                showText.Text = Me.cboBillType.Text
                ''=====================
            End If
            Try
                If Me.chkSign.Checked = True Then
                    rptDoCument.ReportDefinition.ReportObjects("picture1").ObjectFormat.EnableSuppress = False

                Else
                    rptDoCument.ReportDefinition.ReportObjects("picture1").ObjectFormat.EnableSuppress = True

                End If
            Catch ex As Exception

            End Try


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
            '------------
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            'Formatting paper

            If flag = 1 Then
                mymargins = rptDoCument.PrintOptions.PageMargins
                mymargins.topMargin = gTopM
                mymargins.bottomMargin = gBottomM
                mymargins.leftMargin = gLeftM
                mymargins.rightMargin = gRightM
                'rptDoCument.PrintOptions.ApplyPageMargins(mymargins)
            End If

            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

            rptDoCument.Refresh()


            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub frmPrintBill_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            print()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            print_att()
        Catch ex As Exception

        End Try
    End Sub
End Class