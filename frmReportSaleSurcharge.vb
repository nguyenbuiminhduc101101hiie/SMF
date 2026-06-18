Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmReportSaleSurcharge
    Public mContainerOutBoundNotifyID As String
    Public mUserid As String
    Public mUpdateTime As String
    Public SailingID As String
    Public BookingID As String
    Public ALL As Boolean
    Public Sub PrintRpt(ByVal mID As String) 'Id của một booking 
        Try
            'Dim rpt As New 

            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            strReportName = "ReportSaleSurcharge"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------

            Dim tbl As DataSet
            Dim strSql As String = ""

            tbl = New DataSet
            strSql = "Select BookingNo,POL, POD_id, OPL_id, FDEST_id,commondity_id,canvasCode,SaleCode,CusName,ServiceContract,Surcharge.userid,Surcharge.updatetime  " & _
                    "From Surcharge " & _
                    "Where ContainerOutBoundNotifyID='" & mID & "' and Surcharge.continued=1 And Editable=1"
            tbl = ReadDataSet(strSql)
            If tbl.Tables(0).Rows.Count = 0 Then
                Return
            End If

            Dim BookingNo As TextObject
            Dim POD As TextObject
            Dim POL As TextObject
            Dim OPL As TextObject
            Dim FDEST As TextObject
            Dim Commondity As TextObject
            Dim CanvasCode As TextObject
            Dim SaleCode As TextObject
            Dim CusName As TextObject
            Dim ServiceContract As TextObject
            Dim userid As TextObject
            Dim updatetime As TextObject

            userid = rpt.ReportDefinition.ReportObjects("userid")
            userid.Text = tbl.Tables(0).Rows(0).Item("userid")

            updatetime = rpt.ReportDefinition.ReportObjects("updatetime")
            updatetime.Text = tbl.Tables(0).Rows(0).Item("Updatetime")

            BookingNo = rpt.ReportDefinition.ReportObjects("BookingNo")
            BookingNo.Text = tbl.Tables(0).Rows(0).Item("BookingNo")

            POD = rpt.ReportDefinition.ReportObjects("POD")
            POD.Text = tbl.Tables(0).Rows(0).Item("POD_ID")

            POL = rpt.ReportDefinition.ReportObjects("POL")
            POL.Text = tbl.Tables(0).Rows(0).Item("POL")

            OPL = rpt.ReportDefinition.ReportObjects("OPL")
            OPL.Text = tbl.Tables(0).Rows(0).Item("OPL_ID")

            FDEST = rpt.ReportDefinition.ReportObjects("FDEST")
            FDEST.Text = tbl.Tables(0).Rows(0).Item("FDEST_ID")

            Commondity = rpt.ReportDefinition.ReportObjects("Commondity")
            Commondity.Text = tbl.Tables(0).Rows(0).Item("Commondity_ID")

            CanvasCode = rpt.ReportDefinition.ReportObjects("CanvasCode")
            CanvasCode.Text = tbl.Tables(0).Rows(0).Item("CanvasCode")

            SaleCode = rpt.ReportDefinition.ReportObjects("SaleCode")
            SaleCode.Text = tbl.Tables(0).Rows(0).Item("SaleCode")

            CusName = rpt.ReportDefinition.ReportObjects("Cusname")
            CusName.Text = tbl.Tables(0).Rows(0).Item("CusName")

            ServiceContract = rpt.ReportDefinition.ReportObjects("ServiceContract")
            ServiceContract.Text = tbl.Tables(0).Rows(0).Item("ServiceContract")

            tbl = New DataSet
            tbl = ReadDataSet("Select chargeCode,charge,Unit,kind,FreightSale as Freight From FreightSale where continued=1 and ContainerOutBoundNotifyID='" & mID & "'")

            rpt.SetDataSource(tbl.Tables(0))
            If ALL = True Then
                rpt.PrintToPrinter(1, True, 1, 100)
                Return
            End If
            Me.rptSaleSurcharge.ReportSource = rpt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmReportSaleSurcharge_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strSQL As String
            strSQL = "Select Surcharge.BookingNo,Surcharge.ContainerOutboundNotifyID as mID "
            strSQL &= " From (Surcharge LEFT JOIN ContainerOutboundNotify On SurCharge.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strSQL &= "Where ContainerOutboundNotify.SailingScheduleID='" & SailingID & "' And Surcharge.Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            Me.cboOne.DisplayMember = "BookingNo"
            Me.cboOne.ValueMember = "mID"
            Me.cboOne.DataSource = dt
            Me.cboOne.SelectedValue = BookingID
            If dt.Rows.Count > 0 Then
                PrintRpt(Me.cboOne.SelectedValue.ToString.Trim)
            Else
                DisplayMessage(True, "have No Booking ")
                Me.Close()
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Sub

    Private Sub cboOne_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOne.SelectedIndexChanged
        Try
            PrintRpt(Me.cboOne.SelectedValue.ToString.Trim)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
End Class