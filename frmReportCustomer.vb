Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmReportCustomer

    Public oTable As New DataTable
    Public oTablePic As New DataTable
    Public oTableCommondity As New DataTable
    Public oTableMarket As New DataTable
    Public oTableDestination As New DataTable
    Public oTableSeason As New DataTable
    Public oTableSaleDetail As New DataTable
    Public oTableCusRpt As New DataTable

    Private Sub frmReportCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Try
        '    Dim rptDocument As New ReportCustomer

        '    rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4

        '    Dim CustomerCode As TextObject
        '    Dim Company As TextObject
        '    Dim BizName As TextObject
        '    Dim Tel As TextObject
        '    Dim Fax As TextObject
        '    Dim Mail As TextObject
        '    Dim SaleName As TextObject

        '    If IsDBNull(oTable.Rows(0).Item("Customer_Code")) = False Then
        '        CustomerCode = rptDocument.ReportDefinition.ReportObjects("CustomerCode")
        '        CustomerCode.Text = oTable.Rows(0).Item("Customer_Code")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("SaleName")) = False Then
        '        SaleName = rptDocument.ReportDefinition.ReportObjects("SaleName")
        '        SaleName.Text = oTable.Rows(0).Item("SaleName")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Company")) = False Then
        '        Company = rptDocument.ReportDefinition.ReportObjects("Company")
        '        Company.Text = oTable.Rows(0).Item("Company")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("BizName")) = False Then
        '        BizName = rptDocument.ReportDefinition.ReportObjects("BizName")
        '        BizName.Text = oTable.Rows(0).Item("BizName")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Tel")) Then
        '        Tel = rptDocument.ReportDefinition.ReportObjects("Tel")
        '        Tel.Text = oTable.Rows(0).Item("Tel")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Fax")) = False Then
        '        Fax = rptDocument.ReportDefinition.ReportObjects("Fax")
        '        Fax.Text = oTable.Rows(0).Item("Fax")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("EMail")) = False Then
        '        Mail = rptDocument.ReportDefinition.ReportObjects("Mail")
        '        Mail.Text = oTable.Rows(0).Item("EMail")
        '    End If

        '    Dim mySubReport As CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    Dim mySubreportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject

        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("subRptPic")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
        '    mySubReport.SetDataSource(oTablePic)

        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("SubRptSaleDetail")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
        '    mySubReport.SetDataSource(oTableSaleDetail)

        '    Dim Industry As TextObject
        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("subRptCommondity")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)

        '    If IsDBNull(oTable.Rows(0).Item("Industry")) = False Then
        '        Industry = mySubReport.ReportDefinition.ReportObjects("Industry")
        '        Industry.Text = oTable.Rows(0).Item("Industry")
        '    End If

        '    mySubReport.SetDataSource(oTableCommondity)

        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("subRptMarket")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
        '    mySubReport.SetDataSource(oTableMarket)

        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("subRptDestination")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
        '    mySubReport.SetDataSource(oTableDestination)

        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("subRptSeason")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
        '    mySubReport.SetDataSource(oTableSeason)

        '    mySubreportObject = rptDocument.ReportDefinition.ReportObjects("subCusRpt")
        '    mySubReport = mySubreportObject.OpenSubreport(mySubreportObject.SubreportName)
        '    mySubReport.SetDataSource(oTableCusRpt)

        '    Me.rptCustomer.ReportSource = rptDocument
        '    Me.rptCustomer.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
End Class