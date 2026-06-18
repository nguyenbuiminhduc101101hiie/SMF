Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmCusWeeklyreport
    Public oTable As New DataTable
    Public oTableweeklyreport As New DataTable



    Private Sub frmCusWeeklyreport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            'Dim rptDocument As New ReportCusRpt
            '' ten Report
            ''Dim strReportPath As String = Application.StartupPath & "\subReportSaleDetail.rpt"
            ''If Not IO.File.Exists(strReportPath) Then
            ''    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            ''    Exit Sub
            ''End If
            ''rptDocument.Load(strReportPath)
            ''----------


            'rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4
            ''-----------------------------
            'Dim SaleName, SaleCode, CustomerCode, MainCode, VipCode, TaxCode, Company, BizName, Type, Industry, Email, Tel, Fax, Address, CustomerRemark, Remark, AccountPotantial, EnglishName, ATTN, Web, Nationality, Province, Country As TextObject

            'If IsDBNull(oTable.Rows(0).Item("SaleName")) = False Then
            '    SaleName = rptDocument.ReportDefinition.ReportObjects("txtsalename")
            '    SaleName.Text = oTable.Rows(0).Item("SaleName")
            'End If

            'If IsDBNull(oTable.Rows(0).Item("Customer_Code")) = False Then
            '    CustomerCode = rptDocument.ReportDefinition.ReportObjects("txtcustomercode")
            '    CustomerCode.Text = oTable.Rows(0).Item("Customer_Code")
            'End If

            'If IsDBNull(oTable.Rows(0).Item("MainCode")) = False Then
            '    MainCode = rptDocument.ReportDefinition.ReportObjects("txtmaincode")
            '    MainCode.Text = oTable.Rows(0).Item("MainCode")
            'End If



            'If IsDBNull(oTable.Rows(0).Item("TaxCode")) = False Then
            '    TaxCode = rptDocument.ReportDefinition.ReportObjects("txttaxcode")
            '    TaxCode.Text = oTable.Rows(0).Item("TaxCode")
            'End If

            'If IsDBNull(oTable.Rows(0).Item("COMPANY")) = False Then
            '    Company = rptDocument.ReportDefinition.ReportObjects("txtcompany")
            '    Company.Text = oTable.Rows(0).Item("COMPANY")
            'End If




            'If IsDBNull(oTable.Rows(0).Item("Tel")) = False Then
            '    Tel = rptDocument.ReportDefinition.ReportObjects("txtTel")
            '    Tel.Text = oTable.Rows(0).Item("Tel")
            'End If

            'If IsDBNull(oTable.Rows(0).Item("FAX")) = False Then
            '    Fax = rptDocument.ReportDefinition.ReportObjects("txtFax")
            '    Fax.Text = oTable.Rows(0).Item("FAX")
            'End If


            'If IsDBNull(oTable.Rows(0).Item("Address")) = False Then
            '    Address = rptDocument.ReportDefinition.ReportObjects("txtAddress")
            '    Address.Text = oTable.Rows(0).Item("Address")
            'End If









            ''----------------------------------

            'rptDocument.SetDataSource(oTableweeklyreport)
            'Me.rptCusWeeklyReport.ReportSource = rptDocument

        Catch ex As Exception

        End Try
    End Sub
End Class