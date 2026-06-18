Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmReportCusSaleDetail
    Public oTable As New DataTable
    Public oTableSaleDetail As New DataTable
    Public oTableMarket As New DataTable

    Private Sub frmReportCusSaleDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try


        '    Dim rptDocument As New subReportSaleDetail
        '    ' ten Report
        '    'Dim strReportPath As String = Application.StartupPath & "\subReportSaleDetail.rpt"
        '    'If Not IO.File.Exists(strReportPath) Then
        '    '    DisplayMessage(True, "Không c?file Report:" & vbCrLf & strReportPath)
        '    '    Exit Sub
        '    'End If
        '    'rptDocument.Load(strReportPath)
        '    '----------


        '    rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4
        '    '-----------------------------
        '    Dim SaleName, SaleCode, CustomerCode, MainCode, VipCode, TaxCode, Company, BizName, Type, Industry, Email, Tel, Fax, Address, CustomerRemark, Remark, AccountPotantial, EnglishName, ATTN, Web, Nationality, Province, Country As TextObject

        '    If IsDBNull(oTable.Rows(0).Item("SaleName")) = False Then
        '        SaleName = rptDocument.ReportDefinition.ReportObjects("txtsalename")
        '        SaleName.Text = oTable.Rows(0).Item("SaleName")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Customer_Code")) = False Then
        '        CustomerCode = rptDocument.ReportDefinition.ReportObjects("txtcustomercode")
        '        CustomerCode.Text = oTable.Rows(0).Item("Customer_Code")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("MainCode")) = False Then
        '        MainCode = rptDocument.ReportDefinition.ReportObjects("txtmaincode")
        '        MainCode.Text = oTable.Rows(0).Item("MainCode")
        '    End If


        '    If IsDBNull(oTable.Rows(0).Item("VIPCode")) = False Then
        '        VipCode = rptDocument.ReportDefinition.ReportObjects("txtvipcode")
        '        VipCode.Text = oTable.Rows(0).Item("VIPCode")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("TaxCode")) = False Then
        '        TaxCode = rptDocument.ReportDefinition.ReportObjects("txttaxcode")
        '        TaxCode.Text = oTable.Rows(0).Item("TaxCode")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("COMPANY")) = False Then
        '        Company = rptDocument.ReportDefinition.ReportObjects("txtcompany")
        '        Company.Text = oTable.Rows(0).Item("COMPANY")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("BIZName")) = False Then
        '        BizName = rptDocument.ReportDefinition.ReportObjects("txtBizName")
        '        BizName.Text = oTable.Rows(0).Item("BIZName")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Type")) = False Then
        '        Type = rptDocument.ReportDefinition.ReportObjects("txtType")
        '        Type.Text = oTable.Rows(0).Item("Type")
        '    End If


        '    If IsDBNull(oTable.Rows(0).Item("Industry")) = False Then
        '        Industry = rptDocument.ReportDefinition.ReportObjects("txtIndustry")
        '        Industry.Text = oTable.Rows(0).Item("Industry")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Email")) = False Then
        '        Email = rptDocument.ReportDefinition.ReportObjects("txtEmail")
        '        Email.Text = oTable.Rows(0).Item("Email")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Tel")) = False Then
        '        Tel = rptDocument.ReportDefinition.ReportObjects("txtTel")
        '        Tel.Text = oTable.Rows(0).Item("Tel")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("FAX")) = False Then
        '        Fax = rptDocument.ReportDefinition.ReportObjects("txtFax")
        '        Fax.Text = oTable.Rows(0).Item("FAX")
        '    End If


        '    If IsDBNull(oTable.Rows(0).Item("Address")) = False Then
        '        Address = rptDocument.ReportDefinition.ReportObjects("txtAddress")
        '        Address.Text = oTable.Rows(0).Item("Address")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Remarks_Customer")) = False Then
        '        CustomerRemark = rptDocument.ReportDefinition.ReportObjects("txtCustomerRemark")
        '        CustomerRemark.Text = oTable.Rows(0).Item("Remarks_Customer")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Remarks_sale")) Then
        '        Remark = rptDocument.ReportDefinition.ReportObjects("txtRemark")
        '        Remark.Text = oTable.Rows(0).Item("Remarks_sale")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("AccountPotantial")) = False Then
        '        AccountPotantial = rptDocument.ReportDefinition.ReportObjects("txtAccountPotantial")
        '        AccountPotantial.Text = oTable.Rows(0).Item("AccountPotantial")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("EnglishName")) = False Then
        '        EnglishName = rptDocument.ReportDefinition.ReportObjects("txtEnglishName")
        '        EnglishName.Text = oTable.Rows(0).Item("EnglishName")
        '    End If




        '    If IsDBNull(oTable.Rows(0).Item("ATTN")) = False Then
        '        ATTN = rptDocument.ReportDefinition.ReportObjects("txtATTN")
        '        ATTN.Text = oTable.Rows(0).Item("ATTN")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Web")) = False Then
        '        Web = rptDocument.ReportDefinition.ReportObjects("txtWeb")
        '        Web.Text = oTable.Rows(0).Item("Web")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Nationality")) = False Then
        '        Nationality = rptDocument.ReportDefinition.ReportObjects("txtNationality")
        '        Nationality.Text = oTable.Rows(0).Item("Nationality")
        '    End If

        '    If IsDBNull(oTable.Rows(0).Item("Province")) = False Then
        '        Province = rptDocument.ReportDefinition.ReportObjects("txtProvince")
        '        Province.Text = oTable.Rows(0).Item("Province")
        '    End If


        '    If IsDBNull(oTable.Rows(0).Item("Country")) = False Then
        '        Country = rptDocument.ReportDefinition.ReportObjects("txtCountry")
        '        Country.Text = oTable.Rows(0).Item("Country")
        '    End If
        '    '----------------------------------

        '    rptDocument.SetDataSource(oTableSaleDetail)
        '    Me.rptCusSaleDetail.ReportSource = rptDocument

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub rptCusSaleDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptCusSaleDetail.Load

    End Sub
End Class