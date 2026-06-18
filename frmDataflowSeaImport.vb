Public Class frmDataflowSeaImport


    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                If LoginSucceeded = True Then
                    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '     VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                If LoginSucceeded = True Then
                    Dim form As New frmListSale  'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '     VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel20_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                If LoginSucceeded = True Then
                    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '     VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            'VB6.ShowForm(frmQuotationTico, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            'VB6.ShowForm(frmQuotationTico, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmContainerOutBoundNotify
                form.MdiParent = frmMain
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Try
            Try
                'VB6.ShowForm(frmQuotationTico, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmQuotationInbound
                    form.MdiParent = frmMain
                    form.Show()
                End If


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDataflowSeaExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Try

            '---
            gFLC = "F"
            gSC = "C"
            '----
            gNhom = "AGENCY-IMPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            'Dim frm As New frmInputBillInbound
            'frm.Show()

            If LoginSucceeded = True Then
                Dim form As New frmInputBillInbound 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If

            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            '    Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try
    End Sub

    Private Sub OvalShape8_Click(sender As Object, e As EventArgs) Handles OvalShape8.Click
        'CreativeBillOfLading()
        Try
            gFLC = "F"
            gSC = "C"
            '----
            gNhom = "AGENCY-EXPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            'Dim frm As New frmInputOutbound
            'frm.Show()
            If LoginSucceeded = True Then
                Dim form As New frmInputOutbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If


            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked

    End Sub

    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmDailyContainerReport_Inbound_Sea_Air 'frmQuotationTic
                    form.MdiParent = frmMain
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub OvalShape7_Click(sender As Object, e As EventArgs) Handles OvalShape7.Click

    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub OvalShape9_Click(sender As Object, e As EventArgs) Handles OvalShape9.Click, OvalShape11.Click, OvalShape13.Click, OvalShape16.Click

    End Sub

    Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        On Error GoTo Err_Renamed
        If LoginSucceeded = True Then
            Dim form As New frmTaxInvoice 'frmInbound 'frmQuotationTico
            form.MdiParent = frmMain
            form.Show()
        End If
        ' VB6.ShowForm(frmTaxInvoice, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LinkLabel22_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel22.LinkClicked
        Try
            Try

                If LoginSucceeded = True Then
                    Dim form As New frmAgentReport 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If

                'VB6.ShowForm(frmAgentReport, VB6.FormShowConstants.Modeless, Me) 'frmWeeklyReport
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel23_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel23.LinkClicked
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmCongNoGMD 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmCongNoGMD, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel24_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel24.LinkClicked
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmCongnoNCC 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmCongnoNCC, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel25_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel25.LinkClicked
        Try

            If LoginSucceeded = True Then
                Dim form As New frmSOAGeneral 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If


            ' VB6.ShowForm(frmSOAGeneral, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel26_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel26.LinkClicked
        Try
            If LoginSucceeded Then
                '  VB6.ShowForm(frmReportOversea, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportOversea 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel27_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel27.LinkClicked
        Try
            If LoginSucceeded Then
                '  VB6.ShowForm(frmReportOversea, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportOversea_mbl 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel28_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel28.LinkClicked
        Try
            If LoginSucceeded Then

                If LoginSucceeded = True Then
                    Dim form As New frmSaleProfitBonus 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If


                '  VB6.ShowForm(frmSaleProfitBonus, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel29_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel29.LinkClicked
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportSales 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmReportChitietthuchi_soc_Phi 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmReportChitietthuchi_soc_Phi, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel31_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel31.LinkClicked
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmreportChiTietThuChi 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If

                    ' VB6.ShowForm(frmreportChiTietThuChi, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel32_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked
        Try

            If LoginSucceeded = True Then
                Dim form As New frmReportChitietthuchi_container 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel33_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel33.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmReportChitietthuchi_soc 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If

                '  VB6.ShowForm(frmReportChitietthuchi_soc, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel34_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel34.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmSalesReportChart 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmSalesReportChart, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel35_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel35.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBaocaosanluongtheotuyen 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If

                ' VB6.ShowForm(frmBaocaosanluongtheotuyen, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel38_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel38.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBangketamung 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmBangketamung, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel39_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel39.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBossApprove 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '   VB6.ShowForm(frmBossApprove, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel40_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel40.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmCheckPayment 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '   VB6.ShowForm(frmCheckPayment, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel41_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel41.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmMISA 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '  VB6.ShowForm(frmMISA, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel43_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel43.LinkClicked
        Try
            If LoginSucceeded = True Then
                Dim form As New frmSmartPro 'frmQuotationTic
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel20_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        Try
            'If LoginSucceeded Then
            '    If LoginSucceeded = True Then
            '        Dim form As New frmDebit 'frmInbound 'frmQuotationTico
            '          form.MdiParent = frmMain
            '        form.Show()
            '    End If
            '    ' VB6.ShowForm(frmDebit, VB6.FormShowConstants.Modeless, Me)
            'End If
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmExportLemon 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '  VB6.ShowForm(frmMISA, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel44_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel44.LinkClicked
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBravo 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            ' VB6.ShowForm(frmBravo, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel45_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel45.LinkClicked
        Try
            If LoginSucceeded = True Then
                Dim form As New frmSAP 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            '   VB6.ShowForm(frmSAP, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel46_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel46.LinkClicked
        Try
            '  VB6.ShowForm(frmLogisticsContractPrice, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmLogisticsContractPrice 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel47_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel47.LinkClicked
        Try
            If LoginSucceeded = True Then
                Dim form As New frmLogisticsContractCost 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            ' VB6.ShowForm(frmLogisticsContractCost, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LinkLabel48_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel48.LinkClicked
        Try
            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                If LoginSucceeded = True Then
                    Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '     VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel50_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel50.LinkClicked
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmListContainerArrival 'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                'VB6.ShowForm(frmListContainerSOC, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel51_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel51.LinkClicked
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmFullToConsignee 'frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    ' VB6.ShowForm(frmFullToConsignee, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel52_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel52.LinkClicked
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmEmptyToDepot 'frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                    '  VB6.ShowForm(frmEmptyToDepot, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel53_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel53.LinkClicked
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmEmptytoShipper  'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel54_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel54.LinkClicked
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmFullToAtQuay   'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel55_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel55.LinkClicked
        Try
            Try
                If LoginSucceeded Then
                    ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                    If LoginSucceeded = True Then
                        Dim form As New frmEmptyToAtQuay   'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel56_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel56.LinkClicked
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmOnboard   'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel57_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel57.LinkClicked
        Try
            If LoginSucceeded = True Then
                Dim form As New frmInventory_Tico 'frmInbound 'frmQuotationTico
                form.MdiParent = frmMain
                form.Show()
            End If
            ' VB6.ShowForm(frmInventory_Tico, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel59_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel59.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmRef_ChiphiPhanbo 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

    End Sub

    Private Sub OvalShape4_Click(sender As Object, e As EventArgs) Handles OvalShape4.Click

    End Sub

    Private Sub LinkLabel58_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel58.LinkClicked
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmDischargeList  'frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmPhieutamungxangdau, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked

    End Sub

    Private Sub LinkLabel21_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel21.LinkClicked

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub OvalShape14_Click(sender As Object, e As EventArgs) Handles OvalShape14.Click

    End Sub

    Private Sub OvalShape10_Click(sender As Object, e As EventArgs) Handles OvalShape10.Click

    End Sub

    Private Sub LinkLabel60_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel60.LinkClicked
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub
End Class