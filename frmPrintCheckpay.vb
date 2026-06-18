Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmPrintCheckpay


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







    Private Sub QueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        'If IsNothing(argCriteria) Then
        strQuery = "Select * from quotationTico where quotationticoID='" & gPrintQuotationTICOID & "' "
        'Else
        '    strQuery = ""
        'End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableBillOfLading) Then
            oTableBillOfLading.Clear()
        End If
        Adapter.Fill(dsBillOfLading, "BillOfLadingList")
        oTableBillOfLading = dsBillOfLading.Tables(0)

        'If oTableBillOfLading.Rows.Count > 0 Then
        '    Vessel = oTableBillOfLading.Rows(0).Item("OceanVessel").ToString
        '    VoyAge = oTableBillOfLading.Rows(0).Item("VoyAge").ToString
        'End If
        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub











    Sub PrintRpt()
        Try
            Dim rptDoCument As New ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim ds As New DataSet
            Dim i As Integer
            Dim tong As Double = 0
            ' QueryBillOfLading()
            strReportName = "rptPrintCheckPay"


            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'If Me.chkDH.Checked = True Then
            '    rptDoCument.ReportDefinition.ReportObjects("logoDh").ObjectFormat.EnableSuppress = False
            '    rptDoCument.ReportDefinition.ReportObjects("logowm").ObjectFormat.EnableSuppress = True
            'Else
            '    rptDoCument.ReportDefinition.ReportObjects("logoDh").ObjectFormat.EnableSuppress = True
            '    rptDoCument.ReportDefinition.ReportObjects("logowm").ObjectFormat.EnableSuppress = False
            'End If
            '-----------------------------------------
            'bang 1===========================================================================================
          
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
            rptDoCument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            '-
        
         
            '----------------------------------------

            Dim T1() As String
            Dim T As String
            Dim showText As Object
            showText = rptDoCument.ReportDefinition.ReportObjects("txtdate")
            showText.text = CDate(Getdate())
            Try
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtno")
                T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("no").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                '------
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtden")
                T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("den").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                '------
                '------

            Catch ex As Exception

            End Try
            Try
                Dim refno As Object
                refno = rptDoCument.ReportDefinition.ReportObjects("txtissuedby")
                refno.text = UCase(strUserId)
            Catch ex As Exception

            End Try
         

            'Formatting paper
            'rptDoCument.SetDataSource(dsR.Tables(0))
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            Me.CrystalReportViewer1.Show()

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
            '    rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            'Else
            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
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
        If frmInBoundRemarks.CountBill > 1 Then

            Me.Hide()
        End If
        PrintRpt()
    End Sub







    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        PrintRpt()
    End Sub

End Class