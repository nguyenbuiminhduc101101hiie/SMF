Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmPrintSOAGeneral


    Dim Vessel, VoyAge As String
    Public oTableCustomerInfo, oTableremarks As DataTable
    Public dsCustomerInfo As New DataSet

    Public oTableBillOfLading As DataTable
    Public dsBillOfLading As New DataSet
    '------------------
    Public oTableCargoInfo As DataTable
    Public dsCargoInfo As New DataSet
    Public flag As Integer
    Dim oTableCountContainerType As New DataTable

    Const strBillOfLadingSelect As String = "SELECT BillOfLadingIB.BLIB_Id as BillOfLadingId,BillOfLadingIB.BLIB_NO , " & _
" Vessel as OCeanVessel,VoyAge," & _
     "POR,REF, " & _
     "PoL,DEST,ICDPort, " & _
      "PoD, " & _
      "Del, " & _
      "DESCRIPTIONFORSHIPPER, DESCRIPTIONOFGOODS,MARKS,CY_CFS_ITEM," & _
        " BL_TYPE "

    Const strCargo As String = "Select Container.CONTAINER_NO,Seal,Container.CTN_SIZE_TYPE," & _
 "Amount,Kind,RECEIVEDATE,Note,Meas,MeasUnit,GROSSWEIGHT,GROSSUNIT "

    Const strCustomerInfo As String = "Select Shipper, " & _
   "" & _
       " " & _
       " " & _
   " " & _
       "" & _
       " " & _
       "Consignee, " & _
   " " & _
       "" & _
       " " & _
       "Notify  "


















    Sub PrintRpt()
        Try
            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String


            rptDoCument = New ReportDocument
            If Me.chkYamato.Checked = True Then
                strReportName = "rptSOAGeneralYamato"
            Else
                strReportName = "rptSOAGeneral"
            End If



            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'Formatting paper

            ' End If
            Dim name As String
            Dim T1() As String
            Dim T As String
            Dim showText As Object
            Dim sqlcus As String
            Dim dscus As New DataSet
            If gSOACus = "" Then
                Exit Sub
            End If
            sqlcus = "select * from customer where customer_id='" & gSOACus & "' "
            dscus = ReadDataSet(sqlcus)
            If dscus.Tables(0).Rows.Count > 0 Then
                showText = rptDoCument.ReportDefinition.ReportObjects("txtcustomer")
                T1 = Strings.Split(dscus.Tables(0).Rows(0).Item("company").ToString + Chr(13) + dscus.Tables(0).Rows(0).Item("attn").ToString, Chr(13))
                name = dscus.Tables(0).Rows(0).Item("company").ToString
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
            End If

            ' LAY SO LIEU
            Dim sqldebitcredit As String
            Dim dsdebitcredit As New DataSet
            Dim i As Integer
            Dim tongdebit As Double = 0
            Dim tongcredit As Double = 0

            sqldebitcredit = " select * from frmprintsoageneral "
            dsdebitcredit = ReadDataSet(sqldebitcredit)
            If dsdebitcredit.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsdebitcredit.Tables(0).Rows.Count - 1
                    Try
                        tongdebit += CDbl(dsdebitcredit.Tables(0).Rows(i).Item("debit").ToString)
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += CDbl(dsdebitcredit.Tables(0).Rows(i).Item("credit").ToString)
                    Catch ex As Exception

                    End Try

                Next

            End If
            Dim tencongty As String = getOptionValue("companyname", "all", "all", "name", "C")
            ' show
            Dim dueto As Object
            dueto = rptDoCument.ReportDefinition.ReportObjects("TXTDUETO")
            ' show tien te
            Dim tt As String
           

            If tongdebit - tongcredit > 0 Then
                dueto.text = "Thanh toán cho  " + tencongty + " : " + FormatNumber(tongdebit - tongcredit, 3) + " (" + gUSDVNDSoa + ")"
            ElseIf tongdebit - tongcredit < 0 Then
                dueto.text = "Thanh toán cho " + name + " : " + FormatNumber(IIf((tongdebit - tongcredit) < 0, (tongdebit - tongcredit) * (-1), (tongdebit - tongcredit)), 3) + " (" + gUSDVNDSoa + ")"

            End If

            ''=====================
            'T = ""
            'showText = rptDoCument.ReportDefinition.ReportObjects("lcr_nguoiDaiDien")
            'T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("lcr_nguoiDaiDien").ToString, Chr(13))
            'For CountA As Integer = 0 To T1.Length - 1
            '    T &= T1(CountA).Replace(Chr(10), "  ")
            '    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
            '        T &= " "
            '    Next
            'Next
            'showText.Text = T
            ''-----------------------
            '------
            Dim tentaikhoan As String
            Dim tk As Object
            tentaikhoan = getOptionValue("debit", "debit", "debit", Me.cbotk.Text, "C")
            tk = rptDoCument.ReportDefinition.ReportObjects("txttaikhoan")
            Dim tam1() As String
            Dim tam_ As String
            tam1 = Strings.Split(tentaikhoan, Chr(13))
            For CountA As Integer = 0 To tam1.Length - 1
                tam_ &= tam1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = tam1(CountA).Length To tk.Width \ 10
                    tam_ &= " "
                Next
            Next
            tk.Text = tam_
            '' ''------------------------------------------
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
            '--------------connect ko can login
            Dim connection As IConnectionInfo
            For Each connection In rptDoCument.DataSourceConnections

                'Select Case connection.ServerName

                '    Case strServer
                connection.SetConnection(strServer, strDatabase, strUserId, strPassword)
                '        ' connection.SetLogon(strUserId, strPassword)

                'End Select

            Next
            '------------
            'Set Database Logon to subreport

            Dim subreport As ReportDocument

            For Each subreport In rptDoCument.Subreports

                For Each connection In subreport.DataSourceConnections

                    'Select Case connection.ServerName

                    '    Case strServer

                    connection.SetConnection(strServer, strDatabase, strUserId, strPassword)

                    'End Select

                Next

            Next
            '----------------------------------------------------------------------------
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
            'rptDoCument.PrintOptions.PaperSize = PaperSize.PaperA4
            'If frmMain.mnuReportOrientationPortrait.Checked Then
            '    
            'Else
            'If Me.chkYamato.Checked = True Then
            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            'Else
            '    rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            'End If

            'End If
            rptDoCument.Refresh()

            'If frmInBoundRemarks.CountBill > 1 Then
            '    rptDoCument.PrintToPrinter(1, True, 1, 2)
            '    Me.Close()
            'End If
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()
            'Dim strMesg As String = "Print this Arrival Note! ?"
            'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            '    rptDoCument.Refresh()
            '    rptDoCument.PrintToPrinter(1, True, 1, 1)
            'End If


        Catch ex As Exception
            Me.Close()
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub
    Private Sub frmRptArrival_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.chkAttachDescription.Visible = False

        PrintRpt()
    End Sub






    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        PrintRpt()
    End Sub

End Class