Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptSupplyEmptyContainerLCL

    Sub QueryBooking(ByRef oTable As DataTable)
        On Error GoTo Err
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        'không cần điều kiện continued=1 vì muốn xem bất kỳ booking nào cũng đựơc chứ không nhất thiết là booking mà continued=1 (Booking Restore)
        Dim strQuery As String = "Select * from (ContainerOutboundNotify_sale inner join CUSTOMER On CUSTOMER.CUSTOMER_ID=ContainerOutboundNotify_sale.Customer_ID)  Where ContainerOutboundNotifyID='" & gBookingID & "' " 'And (ContainerOutboundNotify.Continued=1 Or BC='CL')"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(otable) Then
            otable.Clear()
        End If
        Adapter.Fill(ds, "Booking")
        otable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err:

    End Sub

    Sub QueryVessel(ByRef oTable As DataTable)
        On Error GoTo Err
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        Dim strQuery As String = "Select Vessel.Vessel +' '+ Voyno as Vessel,ETD  "
        strQuery &= " from ((ContainerOutboundNotify inner join SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID) "
        strQuery &= " Inner Join Vessel on Vessel.Vessel_ID=SailingSchedule.Vessel_ID ) "
        strQuery &= " Where ContainerOutboundNotify.ContainerOutboundNotifyID='" & gBookingID & "' "
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTable) Then
            oTable.Clear()
        End If
        Adapter.Fill(ds, "Booking")
        oTable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err:
    End Sub
    Function ReplaceDate(ByVal s As String) As String
        Dim Temp As String
        Try
            If S = "" Then
                Return s
            End If
            Temp = ""
            Temp = Strings.Replace(s, "12:00:00 AM", "")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Return Temp
    End Function



    Private Sub frmRptSupplyEmptyContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Text = "Print Booking - Ship Order"

        'If Me.chkrequest.Checked = True Then
        '    printViewRequest()
        'Else
        printView()
        'End If
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub cmdPrintData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmRptDataSupplyContainerNotify.Show()


    End Sub

    Private Sub cmdrefesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefesh.Click
        'If Me.chkrequest.Checked = True Then
        '    printViewRequest()
        'Else
        printView()
        'End If

    End Sub
    Public Sub printView()
        Try


            Dim dt As New DataTable
            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            'If Me.chkrequest.Checked = True Then
            strReportName = "ReportBookingNOteLCL"
            ' Else
            'strReportName = "ReportBookingRequest"
            'End If

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------
            Dim ds As New DataSet
            Dim sql As String
            sql = "select * from containeroutboundnotify_sale left join customer on  containeroutboundnotify_sale.customer_id=customer.customer_id where ContainerOutboundNotifyID='" & gBookingID & "' "
            ds = ReadDataSet(sql)

            Dim show As Object
            Dim tam As String
            Dim tam1() As String

            Try

                show = rpt.ReportDefinition.ReportObjects("txtto")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("company").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtattn")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("attn").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtfrom")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_from").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtref")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("bookingno").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtdate")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_date").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtcustomer")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("company").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtvessel")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("vessel").ToString + " / " + ds.Tables(0).Rows(0).Item("voyno").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtcarrier")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("carrier").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtetd")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("etd").ToString.Replace("12:00:00 AM", ""), Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txteta")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("eta").ToString.Replace("12:00:00 AM", ""), Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtclosing")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_Closing").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtclosingDelivery")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_Closingdelivery").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtquanlity")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoFCL_Quality").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try


            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtcommodity")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_Commodity").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtwcp")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_WeightCBMPKG").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtpor")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_POR").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtpol")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_POl").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtpot")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_POt").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try


            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtpod")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_POd").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtpaymentterm")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hano_Payment").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtremarksfcl")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("remarksFCL").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtconsolidator")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoLCL_Consolidator").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try


            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtcfswh")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoLCL_CFSWH").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try


            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtadd")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoLCL_Add").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtVNACC")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoLCL_VNACCSCODE").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try



            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtWHPIC")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoLCL_WHPIC").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("txtBookingPIC")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("hanoLCL_BookingPIC").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try

            Try
                tam = ""
                show = rpt.ReportDefinition.ReportObjects("TXTREMARKSLCL")
                '------ xuong hang
                tam = ""
                tam1 = Strings.Split(ds.Tables(0).Rows(0).Item("remarkslcl").ToString, Chr(13))
                For CountA As Integer = 0 To tam1.Length - 1
                    tam &= tam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = tam1(CountA).Length To show.Width \ 10
                        tam &= " "
                    Next
                Next
                show.Text = tam
                '----------------

            Catch ex As Exception

            End Try
            'QueryBooking(dt)
            'rpt.ReportDefinition.ReportObjects("TXTxPREPAID").ObjectFormat.EnableSuppress = True
            'rpt.ReportDefinition.ReportObjects("TXTxCOLLECT").ObjectFormat.EnableSuppress = True
            ''-----------------------------------
            'rpt.ReportDefinition.ReportObjects("TXTxPREPAID_").ObjectFormat.EnableSuppress = True
            'rpt.ReportDefinition.ReportObjects("TXTxCOLLECT_").ObjectFormat.EnableSuppress = True
            'If dt.Rows.Count > 0 Then
            '    '-------
            '    Dim shipper, consignee, notify, SHIPPINGMARKS, DESCRIPTION, SCPECIALREMARKS, PAYMENTTERMS, TYPEOFMOVING, CARRIER, quantity, gw, volumn, transhipmentPort, POL, ref, TitleSend, DateSend, BookingNo, Company, NguoiDaiDien, MWMP, MWL, ContactUs, DiaChi, Tel, Fax, GP20, GP40, HC40, HC45, RF20, RF40, RH40, Special, soluongcontloai As TextObject
            '    'If UCase(dt.Rows(0).Item("PAYMENTTERM").ToString) = "PREPAID" Then
            '    '    rpt.ReportDefinition.ReportObjects("TXTxPREPAID").ObjectFormat.EnableSuppress = False
            '    '    rpt.ReportDefinition.ReportObjects("TXTxPREPAID_").ObjectFormat.EnableSuppress = False

            '    'End If

            '    'If UCase(dt.Rows(0).Item("PAYMENTTERM").ToString) = "COLLECT" Then
            '    '    rpt.ReportDefinition.ReportObjects("TXTxCOLLECT").ObjectFormat.EnableSuppress = False

            '    '    rpt.ReportDefinition.ReportObjects("TXTxCOLLECT_").ObjectFormat.EnableSuppress = False
            '    'End If
            '    BookingNo = rpt.ReportDefinition.ReportObjects("BookingNO")
            '    BookingNo.Text = dt.Rows(0).Item("BookingNo").ToString
            '    Try
            '        SHIPPINGMARKS = rpt.ReportDefinition.ReportObjects("txtshippingmarks")
            '        SHIPPINGMARKS.Text = dt.Rows(0).Item("shippingmarks").ToString
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        shipper = rpt.ReportDefinition.ReportObjects("txtshipper")
            '        shipper.Text = dt.Rows(0).Item("shipper").ToString
            '    Catch ex As Exception

            '    End Try

            '    Try
            '        consignee = rpt.ReportDefinition.ReportObjects("txtconsignee")
            '        consignee.Text = dt.Rows(0).Item("consignee").ToString
            '    Catch ex As Exception

            '    End Try

            '    Try
            '        notify = rpt.ReportDefinition.ReportObjects("txtnotify")
            '        notify.Text = dt.Rows(0).Item("notify").ToString
            '    Catch ex As Exception

            '    End Try



            '    Try
            '        SHIPPINGMARKS = rpt.ReportDefinition.ReportObjects("TXTSHIPPINGMARKS")
            '        SHIPPINGMARKS.Text = dt.Rows(0).Item("SHIPPINGMARKS").ToString
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        DESCRIPTION = rpt.ReportDefinition.ReportObjects("TXTDESCRIPTION")
            '        DESCRIPTION.Text = dt.Rows(0).Item("descriptionofgood").ToString
            '    Catch ex As Exception

            '    End Try
            '    'Try
            '    '    volumn = rpt.ReportDefinition.ReportObjects("txtvolumn")
            '    '    volumn.Text = dt.Rows(0).Item("volume").ToString
            '    'Catch ex As Exception

            '    'End Try
            '    SCPECIALREMARKS = rpt.ReportDefinition.ReportObjects("SCPECAILREMARKS")
            '    SCPECIALREMARKS.Text = dt.Rows(0).Item("SPECIALREMARKS").ToString

            '    PAYMENTTERMS = rpt.ReportDefinition.ReportObjects("PAYMENTTERMS")
            '    PAYMENTTERMS.Text = dt.Rows(0).Item("PAYMENTTERM").ToString


            '    CARRIER = rpt.ReportDefinition.ReportObjects("CARRIER")
            '    CARRIER.Text = dt.Rows(0).Item("SHIPPINGLINE").ToString


            '    TYPEOFMOVING = rpt.ReportDefinition.ReportObjects("TYPEOFMOVING")
            '    TYPEOFMOVING.Text = dt.Rows(0).Item("spencialequipment").ToString

            '    Dim slc As String

            '    quantity = rpt.ReportDefinition.ReportObjects("SoLuongContLoai")
            '    slc = dt.Rows(0).Item("quantity").ToString + "x" + dt.Rows(0).Item("type").ToString + "; " + dt.Rows(0).Item("quantity1").ToString + "x" + dt.Rows(0).Item("type1").ToString + "; " + dt.Rows(0).Item("quantity2").ToString + "x" + dt.Rows(0).Item("type2").ToString
            '    quantity.Text = slc.Replace("; x", "")


            '    gw = rpt.ReportDefinition.ReportObjects("txtgw")
            '    gw.Text = dt.Rows(0).Item("gw").ToString

            '    volumn = rpt.ReportDefinition.ReportObjects("txtvolumn")
            '    volumn.Text = dt.Rows(0).Item("volumn").ToString

            '    ref = rpt.ReportDefinition.ReportObjects("txtref")
            '    ref.Text = dt.Rows(0).Item("fileno").ToString

            '    transhipmentPort = rpt.ReportDefinition.ReportObjects("txttranshipmentport")
            '    transhipmentPort.Text = dt.Rows(0).Item("Tranship").ToString

            '    Company = rpt.ReportDefinition.ReportObjects("Company")
            '    Company.Text = dt.Rows(0).Item("Company").ToString & " - " & dt.Rows(0).Item("Representative").ToString

            '    NguoiDaiDien = rpt.ReportDefinition.ReportObjects("DaiDien")
            '    NguoiDaiDien.Text = dt.Rows(0).Item("tRUCKcOMPANY").ToString

            '    DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
            '    DiaChi.Text = dt.Rows(0).Item("Address").ToString

            '    Tel = rpt.ReportDefinition.ReportObjects("Tel")
            '    Tel.Text = dt.Rows(0).Item("Tel").ToString

            '    Fax = rpt.ReportDefinition.ReportObjects("Fax")
            '    Fax.Text = dt.Rows(0).Item("Fax").ToString
            '    Dim sl As String = ""

            '    sl = IIf(dt.Rows(0).Item("SoLuong20GP").ToString = "0", "", dt.Rows(0).Item("SoLuong20GP").ToString + " x 20GP (" + dt.Rows(0).Item("w40GP").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong40GP").ToString = "0", "", dt.Rows(0).Item("SoLuong40GP").ToString + " x 40GP (" + dt.Rows(0).Item("w40GP").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong40HC").ToString = "0", "", dt.Rows(0).Item("SoLuong40HC").ToString + " x 40HC (" + dt.Rows(0).Item("w40HC").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong45HC").ToString = "0", "", dt.Rows(0).Item("SoLuong45HC").ToString + " x 45HC (" + dt.Rows(0).Item("w45HC").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong20RF").ToString = "0", "", dt.Rows(0).Item("SoLuong20RF").ToString + " x 20RF (" + dt.Rows(0).Item("w20RF").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong40RF").ToString = "0", "", dt.Rows(0).Item("SoLuong40RF").ToString + " x 40RF (" + dt.Rows(0).Item("w40RF").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong40RH").ToString = "0", "", dt.Rows(0).Item("SoLuong40RH").ToString + " x 40RH (" + dt.Rows(0).Item("w40RH").ToString + " KGS);")

            '    sl += IIf(dt.Rows(0).Item("SoLuong20OT").ToString = "0", "", dt.Rows(0).Item("SoLuong20OT").ToString + " x 20OT (" + dt.Rows(0).Item("w20OT").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong40OT").ToString = "0", "", dt.Rows(0).Item("SoLuong40OT").ToString + " x 40OT (" + dt.Rows(0).Item("w40OT").ToString + " KGS);")



            '    sl += IIf(dt.Rows(0).Item("SoLuong20FR").ToString = "0", "", dt.Rows(0).Item("SoLuong20FR").ToString + " x 20FR (" + dt.Rows(0).Item("w20FR").ToString + " KGS);")


            '    sl += IIf(dt.Rows(0).Item("SoLuong40FR").ToString = "0", "", dt.Rows(0).Item("SoLuong40FR").ToString + " x 40FR (" + dt.Rows(0).Item("w40FR").ToString + " KGS);")

            '    sl += IIf(dt.Rows(0).Item("soluongCBM").ToString = "0", "", dt.Rows(0).Item("SoLuongCBM").ToString + " x CBM (" + dt.Rows(0).Item("wCBM").ToString + " KGS);")

            '    'soluongcontloai = rpt.ReportDefinition.ReportObjects("SoLuongContLoai")
            '    'If sl.Length = 0 Then
            '    '    Dim frm As New frmThongbao
            '    '    frm.txtnoidung.Text = "Xin kiểm tra lại số lượng cont."
            '    '    frm.ShowDialog()
            '    'Else
            '    '    soluongcontloai.Text = "Số lượng/Loại cont : " + sl.Remove(sl.Length - 1, 1)
            '    'End If



            '    Dim NhietDoLanh, NoiLayContainer, PhuongAn, ThongGio, YeuCauHaRong, ThoiHanHaBai, ChuyenTai As TextObject


            '    NhietDoLanh = rpt.ReportDefinition.ReportObjects("NhietDo")
            '    NhietDoLanh.Text = dt.Rows(0).Item("Cold").ToString

            '    ThongGio = rpt.ReportDefinition.ReportObjects("ThongGio")
            '    ThongGio.Text = dt.Rows(0).Item("Ventilation").ToString

            '    NoiLayContainer = rpt.ReportDefinition.ReportObjects("NoiLayContainer")

            '    Dim MTPort As String
            '    MTPort = dt.Rows(0).Item("EmptyContainerPlace").ToString.Trim

            '    Dim PortKhongDau() As String = {"CAT LAI", "VINATRANS", "NEW PORT", "PHUC LONG", "PHUOC LONG"}
            '    Dim PortCoDau() As String = {"CÁT LÁI", "VINATRANS", "NEW PORT", "PHÚC LONG", "PHƯỚC LONG"}
            '    For i As Integer = 0 To PortKhongDau.Length - 1
            '        If UCase(MTPort) = UCase(PortKhongDau(i)) Then
            '            MTPort = PortCoDau(i)
            '        End If
            '    Next

            '    NoiLayContainer.Text = MTPort & " - NGÀY CẤP :" & ReplaceDate(dt.Rows(0).Item("ngaycapcont").ToString)

            '    PhuongAn = rpt.ReportDefinition.ReportObjects("PhuongAn")
            '    PhuongAn.Text = dt.Rows(0).Item("PackingWay").ToString

            '    Dim SCNO As TextObject
            '    SCNO = rpt.ReportDefinition.ReportObjects("SCNO")
            '    If dt.Rows(0).Item("ServiceContract").ToString <> "" Then
            '        SCNO.Text = "S/C: " & dt.Rows(0).Item("ServiceContract").ToString
            '    End If

            '    Dim Commondity As TextObject
            '    Commondity = rpt.ReportDefinition.ReportObjects("TXTCommodity")
            '    If dt.Rows(0).Item("Commondity").ToString <> "" Then
            '        Commondity.Text = " " & UCase(dt.Rows(0).Item("Commondity").ToString)
            '    End If


            '    YeuCauHaRong = rpt.ReportDefinition.ReportObjects("YeuCauHaRong")
            '    YeuCauHaRong.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

            '    Dim NoiHaBai As TextObject
            '    NoiHaBai = rpt.ReportDefinition.ReportObjects("NoiHaBai")
            '    NoiHaBai.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

            '    '-----------
            '    ThoiHanHaBai = rpt.ReportDefinition.ReportObjects("ThoiHanHaBai")
            '    Dim TempTHHB(), ResultTHHB, TEMP, TEMP1 As String
            '    If dt.Rows(0).Item("DateClosing1").ToString = "" Then
            '        TEMP = ""
            '    Else
            '        TEMP = ReplaceDate(dt.Rows(0).Item("DateClosing1").ToString)
            '    End If
            '    If dt.Rows(0).Item("DateClosing2").ToString = "" Then
            '        TEMP1 = ""
            '    Else
            '        TEMP1 = ReplaceDate(dt.Rows(0).Item("DateClosing2").ToString)
            '    End If

            '    ' ResultTHHB = "TRƯỚC " & dt.Rows(0).Item("Gio1").ToString.Trim & "H " & dt.Rows(0).Item("AMPM1").ToString.Trim & " CỦA NGÀY " & TEMP & " ĐỐI VỚI HÀNG THEO KHỐI" & Chr(13)
            '    ResultTHHB &= "BEFORE " + dt.Rows(0).Item("Gio2").ToString.Trim & "H " & dt.Rows(0).Item("AMPM2").ToString.Trim & "   " & TEMP1 & " "
            '    TempTHHB = Strings.Split(ResultTHHB, Chr(13))
            '    ResultTHHB = ""
            '    For j As Integer = 0 To TempTHHB.Length - 1
            '        ResultTHHB &= TempTHHB(j)
            '        For k As Integer = TempTHHB(j).Length To ThoiHanHaBai.Width \ 10
            '            ResultTHHB &= " "
            '        Next
            '    Next
            '    ThoiHanHaBai.Text = ResultTHHB
            '    Dim TXTTHOIHANCUOIBD As TextObject
            '    TXTTHOIHANCUOIBD = rpt.ReportDefinition.ReportObjects("TXTTHOIHANCUOIBD")
            '    TXTTHOIHANCUOIBD.Text = "Before " + dt.Rows(0).Item("GioBD").ToString & " " & dt.Rows(0).Item("AMPMBD").ToString & "   " & ReplaceDate(dt.Rows(0).Item("BD").ToString)
            '    '----------------
            '    ChuyenTai = rpt.ReportDefinition.ReportObjects("ChuyenTai")
            '    ChuyenTai.Text = dt.Rows(0).Item("Tranship").ToString

            '    Dim CangDoHang, DichCuoiCung, Remarks, NgayLam, NguoiGui As TextObject

            '    CangDoHang = rpt.ReportDefinition.ReportObjects("CangDoHang")
            '    CangDoHang.Text = dt.Rows(0).Item("PortOfUnLoading").ToString

            '    POL = rpt.ReportDefinition.ReportObjects("POL")
            '    POL.Text = dt.Rows(0).Item("PortOfLoading").ToString

            '    DichCuoiCung = rpt.ReportDefinition.ReportObjects("DichCuoiCung")
            '    DichCuoiCung.Text = dt.Rows(0).Item("Destination").ToString
            '    '-------------
            '    Dim TempPrei(), ResultrEMARKS As String
            '    'Remarks = rpt.ReportDefinition.ReportObjects("Remarks")
            '    ''Remarks.Text = dt.Rows(0).Item("Remarks").ToString

            '    'ResultrEMARKS = dt.Rows(0).Item("Remarks").ToString
            '    ''ResultPrei = Me.oTableBillOfLading.Rows(0).Item("PreightCharges").ToString
            '    'TempPrei = Strings.Split(ResultrEMARKS, Chr(13))
            '    'ResultrEMARKS = ""

            '    'For j As Integer = 0 To TempPrei.Length - 1

            '    '    ResultrEMARKS &= TempPrei(j)
            '    '    For k As Integer = TempPrei(j).Length To Remarks.Width \ 10
            '    '        ResultrEMARKS &= " "
            '    '    Next

            '    'Next
            '    'Remarks.Text = ResultrEMARKS
            '    Try
            '        Dim showattachlist As Object
            '        Dim notifytam As String
            '        Dim notifytam1() As String

            '        showattachlist = rpt.ReportDefinition.ReportObjects("Remarks")
            '        showattachlist.Text = dt.Rows(0).Item("Remarks").ToString

            '        '------ xuong hang
            '        notifytam = ""
            '        notifytam1 = Strings.Split(dt.Rows(0).Item("Remarks").ToString, Chr(13))
            '        For CountA As Integer = 0 To notifytam1.Length - 1
            '            notifytam &= notifytam1(CountA).Replace(Chr(10), " ")
            '            For CountSpacea As Integer = notifytam1(CountA).Length To showattachlist.Width \ 10
            '                notifytam &= " "
            '            Next
            '        Next
            '        showattachlist.Text = notifytam
            '        '----------------

            '    Catch ex As Exception

            '    End Try
            '    '-----------------
            '    Dim SaleCode As TextObject
            '    SaleCode = rpt.ReportDefinition.ReportObjects("SaleCode")
            '    SaleCode.Text = dt.Rows(0).Item("SaleCode").ToString
            '    MWMP = rpt.ReportDefinition.ReportObjects("MaxWMainPort")
            '    MWMP.Text = dt.Rows(0).Item("MaxWMainPort").ToString

            '    MWL = rpt.ReportDefinition.ReportObjects("MaxWLocal")
            '    MWL.Text = dt.Rows(0).Item("MaxWLocal").ToString

            '    ContactUs = rpt.ReportDefinition.ReportObjects("txtContactUs")
            '    ContactUs.Text = dt.Rows(0).Item("ContactUs").ToString

            '    NgayLam = rpt.ReportDefinition.ReportObjects("NgayLam")
            '    NgayLam.Text = ReplaceDate(dt.Rows(0).Item("BookingDate").ToString)

            '    NguoiGui = rpt.ReportDefinition.ReportObjects("NguoiGuiBooking")
            '    NguoiGui.Text = dt.Rows(0).Item("BookingPerson").ToString



            '    'rpt.ReportDefinition.ReportObjects("VAN").ObjectFormat.EnableSuppress = True
            '    'rpt.ReportDefinition.ReportObjects("HUNG").ObjectFormat.EnableSuppress = True
            '    'rpt.ReportDefinition.ReportObjects("HIEN").ObjectFormat.EnableSuppress = True
            '    'rpt.ReportDefinition.ReportObjects("HUONG").ObjectFormat.EnableSuppress = True

            '    'If UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "ĐẶNG HOÀNG VÂN" Then
            '    '    rpt.ReportDefinition.ReportObjects("VAN").ObjectFormat.EnableSuppress = False
            '    'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN ĐẮC HÙNG" Then
            '    '    rpt.ReportDefinition.ReportObjects("HUNG").ObjectFormat.EnableSuppress = False
            '    'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "PHAN THỊ THU HIỀN" Then
            '    '    rpt.ReportDefinition.ReportObjects("HIEN").ObjectFormat.EnableSuppress = False
            '    'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN THỊ THANH HƯƠNG" Then
            '    '    rpt.ReportDefinition.ReportObjects("HUONG").ObjectFormat.EnableSuppress = False
            '    'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "LƯƠNG THÚY PHƯƠNG" Then
            '    '    rpt.ReportDefinition.ReportObjects("PHUONG").ObjectFormat.EnableSuppress = False
            '    'End If


            '    TitleSend = rpt.ReportDefinition.ReportObjects("TitleSend")
            '    DateSend = rpt.ReportDefinition.ReportObjects("DateSend")

            '    If dt.Rows(0).Item("ThirdSendDate").ToString <> "" Then
            '        TitleSend.Text = "Third Send :"
            '        DateSend.Text = CDate(dt.Rows(0).Item("ThirdSendDate").ToString)
            '    ElseIf dt.Rows(0).Item("SecondSendDate").ToString <> "" Then
            '        TitleSend.Text = "Second Send :"
            '        DateSend.Text = CDate(dt.Rows(0).Item("SecondSendDate").ToString)
            '    ElseIf dt.Rows(0).Item("FirstSendDate").ToString <> "" Then
            '        TitleSend.Text = "First Send :"
            '        DateSend.Text = CDate(dt.Rows(0).Item("FirstSendDate").ToString)
            '    Else
            '        TitleSend.Text = ""
            '        DateSend.Text = ""
            '    End If

            '    Dim text As String = "YÊU CẦU QÚY CÔNG TY ĐỔI LỆNH CẤP CONTAINER TẠI : "
            '    Dim SupplyPlace As TextObject
            '    SupplyPlace = rpt.ReportDefinition.ReportObjects("SupplyPlace")
            '    If UCase(dt.Rows(0).Item("SupplyOrderPlace").ToString()) = "TERMINAL" Then
            '        SupplyPlace.Text = text & "CÁT LÁI"
            '    Else
            '        SupplyPlace.Text = text & " VP PHUONG NAM LOGISTICS"
            '    End If

            'End If
            ''QueryVessel(dt)
            'If dt.Rows.Count > 0 Then

            '    Dim XuatTrenTau, DiNgay, denNgay As TextObject

            '    XuatTrenTau = rpt.ReportDefinition.ReportObjects("XuatTrenTau")
            '    XuatTrenTau.Text = dt.Rows(0).Item("carrier").ToString + "  " + dt.Rows(0).Item("voyno").ToString

            '    DiNgay = rpt.ReportDefinition.ReportObjects("DiNgay")
            '    DiNgay.Text = CDate(dt.Rows(0).Item("ETD").ToString)
            '    denNgay = rpt.ReportDefinition.ReportObjects("denNgay")
            '    denNgay.Text = CDate(dt.Rows(0).Item("ETA").ToString)


            'End If
            Me.CrystalReportViewer1.ReportSource = rpt
            'Formatting paper
            Dim mymargins = rpt.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM
            rpt.PrintOptions.ApplyPageMargins(mymargins)
            If frmMain.mnuReportOrientationPortrait.Checked Then
                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            Else
                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            End If
            'rpt.Refresh()

            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Public Sub printViewRequest()
        Try



            Dim dt As New DataTable
            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            'If Me.chkrequest.Checked = True Then
            strReportName = "ReportBookingRequest"
            'Else
            ' strReportName = "ReportBookingRequest"
            'End If

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------
            QueryBooking(dt)
            rpt.ReportDefinition.ReportObjects("TXTxPREPAID").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("TXTxCOLLECT").ObjectFormat.EnableSuppress = True
            '-----------------------------------
            rpt.ReportDefinition.ReportObjects("TXTxPREPAID_").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("TXTxCOLLECT_").ObjectFormat.EnableSuppress = True
            If dt.Rows.Count > 0 Then
                '-------
                Dim SCPECIALREMARKS, PAYMENTTERMS, TYPEOFMOVING, CARRIER, quantity, gw, volumn, transhipmentPort, POL, ref, TitleSend, DateSend, BookingNo, Company, NguoiDaiDien, MWMP, MWL, ContactUs, DiaChi, Tel, Fax, GP20, GP40, HC40, HC45, RF20, RF40, RH40, Special, soluongcontloai As TextObject
                'If UCase(dt.Rows(0).Item("PAYMENTTERM").ToString) = "PREPAID" Then
                '    rpt.ReportDefinition.ReportObjects("TXTxPREPAID").ObjectFormat.EnableSuppress = False
                '    rpt.ReportDefinition.ReportObjects("TXTxPREPAID_").ObjectFormat.EnableSuppress = False

                'End If

                'If UCase(dt.Rows(0).Item("PAYMENTTERM").ToString) = "COLLECT" Then
                '    rpt.ReportDefinition.ReportObjects("TXTxCOLLECT").ObjectFormat.EnableSuppress = False

                '    rpt.ReportDefinition.ReportObjects("TXTxCOLLECT_").ObjectFormat.EnableSuppress = False
                'End If
                ' lay thong tin lcl infomation
                Dim no, pono, styleno, quantitylcl As Object
                Try
                    no = rpt.ReportDefinition.ReportObjects("txtconsignee")
                    no.Text = dt.Rows(0).Item("consignee").ToString
                Catch ex As Exception

                End Try
                Try
                    no = rpt.ReportDefinition.ReportObjects("txtcfswarehouse")
                    no.Text = dt.Rows(0).Item("placeofreceipt").ToString ' lay bien placeofreceipt lam kho
                Catch ex As Exception

                End Try
                Try
                    no = rpt.ReportDefinition.ReportObjects("txtserviceterm")
                    no.Text = dt.Rows(0).Item("serviceterm").ToString
                Catch ex As Exception

                End Try
                no = rpt.ReportDefinition.ReportObjects("no")
                no.Text = dt.Rows(0).Item("lcl_no1").ToString

                pono = rpt.ReportDefinition.ReportObjects("pono")
                pono.Text = dt.Rows(0).Item("lcl_po1").ToString

                styleno = rpt.ReportDefinition.ReportObjects("styleno")
                styleno.Text = dt.Rows(0).Item("lcl_style1").ToString
                Try
                    quantitylcl = rpt.ReportDefinition.ReportObjects("TXTCUTOFF")
                    quantitylcl.Text = dt.Rows(0).Item("bk_cutOfSI").ToString + "/" + dt.Rows(0).Item("bk_VGMcutOf").ToString
                Catch ex As Exception

                End Try
                Try
                    quantitylcl = rpt.ReportDefinition.ReportObjects("TXTPLACEOFSTUFFING")
                    quantitylcl.Text = dt.Rows(0).Item("bk_placeOfStuffing").ToString ' + "/" + dt.Rows(0).Item("bk_VGMcutOf").ToString
                Catch ex As Exception

                End Try
                Try
                    quantitylcl = rpt.ReportDefinition.ReportObjects("TXTSTUFFINGDATE")
                    quantitylcl.Text = dt.Rows(0).Item("bk_Stuffingdate").ToString ' + "/" + dt.Rows(0).Item("bk_VGMcutOf").ToString
                Catch ex As Exception

                End Try


                quantitylcl = rpt.ReportDefinition.ReportObjects("quantity")
                quantitylcl.Text = dt.Rows(0).Item("pkgs").ToString
                '-----------------------------------
                BookingNo = rpt.ReportDefinition.ReportObjects("BookingNO")
                BookingNo.Text = dt.Rows(0).Item("BookingNo").ToString

                SCPECIALREMARKS = rpt.ReportDefinition.ReportObjects("SCPECAILREMARKS")
                SCPECIALREMARKS.Text = dt.Rows(0).Item("SPECIALREMARKS").ToString

                PAYMENTTERMS = rpt.ReportDefinition.ReportObjects("PAYMENTTERMS")
                PAYMENTTERMS.Text = dt.Rows(0).Item("PAYMENTTERM").ToString


                CARRIER = rpt.ReportDefinition.ReportObjects("CARRIER")
                CARRIER.Text = dt.Rows(0).Item("SHIPPINGLINE").ToString


                TYPEOFMOVING = rpt.ReportDefinition.ReportObjects("TYPEOFMOVING")
                TYPEOFMOVING.Text = dt.Rows(0).Item("spencialequipment").ToString


                quantity = rpt.ReportDefinition.ReportObjects("SoLuongContLoai")
                quantity.Text = dt.Rows(0).Item("quantity").ToString + " " + IIf((dt.Rows(0).Item("type").ToString Like "*0*") Or (dt.Rows(0).Item("type").ToString Like "*5*"), " x ", " ") + dt.Rows(0).Item("type").ToString + "  " + dt.Rows(0).Item("quantity1").ToString + " " + IIf((dt.Rows(0).Item("type1").ToString Like "*0*") Or (dt.Rows(0).Item("type1").ToString Like "*5*"), " x ", " ") + dt.Rows(0).Item("type1").ToString + " " + dt.Rows(0).Item("quantity2").ToString + " " + IIf((dt.Rows(0).Item("type2").ToString Like "*0*") Or (dt.Rows(0).Item("type2").ToString Like "*5*"), " x ", " ") + dt.Rows(0).Item("type2").ToString



                gw = rpt.ReportDefinition.ReportObjects("txtgw")
                gw.Text = dt.Rows(0).Item("gw").ToString

                volumn = rpt.ReportDefinition.ReportObjects("txtvolumn")
                volumn.Text = dt.Rows(0).Item("volumn").ToString

                ref = rpt.ReportDefinition.ReportObjects("txtref")
                ref.Text = dt.Rows(0).Item("fileno").ToString

                transhipmentPort = rpt.ReportDefinition.ReportObjects("txttranshipmentport")
                transhipmentPort.Text = dt.Rows(0).Item("Tranship").ToString

                Company = rpt.ReportDefinition.ReportObjects("Company")
                Company.Text = dt.Rows(0).Item("Company").ToString '& " - " & dt.Rows(0).Item("Representative").ToString

                NguoiDaiDien = rpt.ReportDefinition.ReportObjects("DaiDien")
                NguoiDaiDien.Text = dt.Rows(0).Item("tRUCKcOMPANY").ToString

                DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
                DiaChi.Text = dt.Rows(0).Item("Address").ToString

                Tel = rpt.ReportDefinition.ReportObjects("Tel")
                Tel.Text = dt.Rows(0).Item("Tel").ToString

                Fax = rpt.ReportDefinition.ReportObjects("Fax")
                Fax.Text = dt.Rows(0).Item("Fax").ToString
                Dim sl As String = ""

                sl = IIf(dt.Rows(0).Item("SoLuong20GP").ToString = "0", "", dt.Rows(0).Item("SoLuong20GP").ToString + " x 20GP (" + dt.Rows(0).Item("w40GP").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong40GP").ToString = "0", "", dt.Rows(0).Item("SoLuong40GP").ToString + " x 40GP (" + dt.Rows(0).Item("w40GP").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong40HC").ToString = "0", "", dt.Rows(0).Item("SoLuong40HC").ToString + " x 40HC (" + dt.Rows(0).Item("w40HC").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong45HC").ToString = "0", "", dt.Rows(0).Item("SoLuong45HC").ToString + " x 45HC (" + dt.Rows(0).Item("w45HC").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong20RF").ToString = "0", "", dt.Rows(0).Item("SoLuong20RF").ToString + " x 20RF (" + dt.Rows(0).Item("w20RF").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong40RF").ToString = "0", "", dt.Rows(0).Item("SoLuong40RF").ToString + " x 40RF (" + dt.Rows(0).Item("w40RF").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong40RH").ToString = "0", "", dt.Rows(0).Item("SoLuong40RH").ToString + " x 40RH (" + dt.Rows(0).Item("w40RH").ToString + " KGS);")

                sl += IIf(dt.Rows(0).Item("SoLuong20OT").ToString = "0", "", dt.Rows(0).Item("SoLuong20OT").ToString + " x 20OT (" + dt.Rows(0).Item("w20OT").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong40OT").ToString = "0", "", dt.Rows(0).Item("SoLuong40OT").ToString + " x 40OT (" + dt.Rows(0).Item("w40OT").ToString + " KGS);")



                sl += IIf(dt.Rows(0).Item("SoLuong20FR").ToString = "0", "", dt.Rows(0).Item("SoLuong20FR").ToString + " x 20FR (" + dt.Rows(0).Item("w20FR").ToString + " KGS);")


                sl += IIf(dt.Rows(0).Item("SoLuong40FR").ToString = "0", "", dt.Rows(0).Item("SoLuong40FR").ToString + " x 40FR (" + dt.Rows(0).Item("w40FR").ToString + " KGS);")

                sl += IIf(dt.Rows(0).Item("soluongCBM").ToString = "0", "", dt.Rows(0).Item("SoLuongCBM").ToString + " x CBM (" + dt.Rows(0).Item("wCBM").ToString + " KGS);")

                'soluongcontloai = rpt.ReportDefinition.ReportObjects("SoLuongContLoai")
                'If sl.Length = 0 Then
                '    Dim frm As New frmThongbao
                '    frm.txtnoidung.Text = "Xin kiểm tra lại số lượng cont."
                '    frm.ShowDialog()
                'Else
                '    soluongcontloai.Text = "Số lượng/Loại cont : " + sl.Remove(sl.Length - 1, 1)
                'End If



                Dim NhietDoLanh, NoiLayContainer, PhuongAn, ThongGio, YeuCauHaRong, ThoiHanHaBai, ChuyenTai As TextObject


                NhietDoLanh = rpt.ReportDefinition.ReportObjects("NhietDo")
                NhietDoLanh.Text = dt.Rows(0).Item("Cold").ToString

                ThongGio = rpt.ReportDefinition.ReportObjects("ThongGio")
                ThongGio.Text = dt.Rows(0).Item("Ventilation").ToString

                NoiLayContainer = rpt.ReportDefinition.ReportObjects("NoiLayContainer")

                Dim MTPort As String
                MTPort = dt.Rows(0).Item("EmptyContainerPlace").ToString.Trim

                Dim PortKhongDau() As String = {"CAT LAI", "VINATRANS", "NEW PORT", "PHUC LONG", "PHUOC LONG"}
                Dim PortCoDau() As String = {"CÁT LÁI", "VINATRANS", "NEW PORT", "PHÚC LONG", "PHƯỚC LONG"}
                For i As Integer = 0 To PortKhongDau.Length - 1
                    If UCase(MTPort) = UCase(PortKhongDau(i)) Then
                        MTPort = PortCoDau(i)
                    End If
                Next

                NoiLayContainer.Text = MTPort & " - NGÀY CẤP :" & ReplaceDate(dt.Rows(0).Item("ngaycapcont").ToString)

                PhuongAn = rpt.ReportDefinition.ReportObjects("PhuongAn")
                PhuongAn.Text = dt.Rows(0).Item("PackingWay").ToString

                Dim SCNO As TextObject
                SCNO = rpt.ReportDefinition.ReportObjects("SCNO")
                If dt.Rows(0).Item("ServiceContract").ToString <> "" Then
                    SCNO.Text = "S/C: " & dt.Rows(0).Item("ServiceContract").ToString
                End If

                Dim Commondity As TextObject
                Commondity = rpt.ReportDefinition.ReportObjects("TXTCommodity")
                If dt.Rows(0).Item("Commondity").ToString <> "" Then
                    Commondity.Text = " " & UCase(dt.Rows(0).Item("Commondity").ToString)
                End If


                YeuCauHaRong = rpt.ReportDefinition.ReportObjects("YeuCauHaRong")
                YeuCauHaRong.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

                Dim NoiHaBai As TextObject
                NoiHaBai = rpt.ReportDefinition.ReportObjects("NoiHaBai")
                NoiHaBai.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

                '-----------
                ThoiHanHaBai = rpt.ReportDefinition.ReportObjects("ThoiHanHaBai")
                Dim TempTHHB(), ResultTHHB, TEMP, TEMP1 As String
                If Me.chkrequest.Checked = True Then
                    If dt.Rows(0).Item("DateClosing1").ToString = "" Then
                        TEMP1 = ""
                    Else
                        TEMP1 = ReplaceDate(dt.Rows(0).Item("DateClosing1").ToString)
                    End If
                Else
                    If dt.Rows(0).Item("DateClosing2").ToString = "" Then
                        TEMP1 = ""
                    Else
                        TEMP1 = ReplaceDate(dt.Rows(0).Item("DateClosing2").ToString)
                    End If
                End If



                ' ResultTHHB = "TRƯỚC " & dt.Rows(0).Item("Gio1").ToString.Trim & "H " & dt.Rows(0).Item("AMPM1").ToString.Trim & " CỦA NGÀY " & TEMP & " ĐỐI VỚI HÀNG THEO KHỐI" & Chr(13)
                ResultTHHB &= "BEFORE " + dt.Rows(0).Item("Gio1").ToString.Trim & "H " & dt.Rows(0).Item("AMPM1").ToString.Trim & "   " & TEMP1 & " "
                TempTHHB = Strings.Split(ResultTHHB, Chr(13))
                ResultTHHB = ""
                For j As Integer = 0 To TempTHHB.Length - 1
                    ResultTHHB &= TempTHHB(j)
                    For k As Integer = TempTHHB(j).Length To ThoiHanHaBai.Width \ 10
                        ResultTHHB &= " "
                    Next
                Next
                ThoiHanHaBai.Text = ResultTHHB
                Dim TXTTHOIHANCUOIBD As TextObject
                TXTTHOIHANCUOIBD = rpt.ReportDefinition.ReportObjects("TXTTHOIHANCUOIBD")
                TXTTHOIHANCUOIBD.Text = "Before " + dt.Rows(0).Item("GioBD").ToString & " " & dt.Rows(0).Item("AMPMBD").ToString & "   " & ReplaceDate(dt.Rows(0).Item("BD").ToString)
                '----------------
                ChuyenTai = rpt.ReportDefinition.ReportObjects("ChuyenTai")
                ChuyenTai.Text = dt.Rows(0).Item("Tranship").ToString

                Dim CangDoHang, DichCuoiCung, Remarks, NgayLam, NguoiGui As TextObject

                CangDoHang = rpt.ReportDefinition.ReportObjects("CangDoHang")
                CangDoHang.Text = dt.Rows(0).Item("PortOfUnLoading").ToString

                POL = rpt.ReportDefinition.ReportObjects("POL")
                POL.Text = dt.Rows(0).Item("PortOfLoading").ToString

                DichCuoiCung = rpt.ReportDefinition.ReportObjects("DichCuoiCung")
                DichCuoiCung.Text = dt.Rows(0).Item("Destination").ToString
                '-------------
                Dim TempPrei(), ResultrEMARKS As String
                'Remarks = rpt.ReportDefinition.ReportObjects("Remarks")
                ''Remarks.Text = dt.Rows(0).Item("Remarks").ToString

                'ResultrEMARKS = dt.Rows(0).Item("Remarks").ToString
                ''ResultPrei = Me.oTableBillOfLading.Rows(0).Item("PreightCharges").ToString
                'TempPrei = Strings.Split(ResultrEMARKS, Chr(13))
                'ResultrEMARKS = ""

                'For j As Integer = 0 To TempPrei.Length - 1

                '    ResultrEMARKS &= TempPrei(j)
                '    For k As Integer = TempPrei(j).Length To Remarks.Width \ 10
                '        ResultrEMARKS &= " "
                '    Next

                'Next
                'Remarks.Text = ResultrEMARKS
                Try
                    Dim showattachlist As Object
                    Dim notifytam As String
                    Dim notifytam1() As String

                    showattachlist = rpt.ReportDefinition.ReportObjects("Remarks")
                    showattachlist.Text = dt.Rows(0).Item("Remarks").ToString

                    '------ xuong hang
                    notifytam = ""
                    notifytam1 = Strings.Split(dt.Rows(0).Item("Remarks").ToString, Chr(13))
                    For CountA As Integer = 0 To notifytam1.Length - 1
                        notifytam &= notifytam1(CountA).Replace(Chr(10), " ")
                        For CountSpacea As Integer = notifytam1(CountA).Length To showattachlist.Width \ 10
                            notifytam &= " "
                        Next
                    Next
                    showattachlist.Text = notifytam
                    '----------------

                Catch ex As Exception

                End Try
                '-----------------
                Dim SaleCode As TextObject
                SaleCode = rpt.ReportDefinition.ReportObjects("SaleCode")
                SaleCode.Text = dt.Rows(0).Item("SaleCode").ToString
                MWMP = rpt.ReportDefinition.ReportObjects("MaxWMainPort")
                MWMP.Text = dt.Rows(0).Item("MaxWMainPort").ToString

                MWL = rpt.ReportDefinition.ReportObjects("MaxWLocal")
                MWL.Text = dt.Rows(0).Item("MaxWLocal").ToString

                ContactUs = rpt.ReportDefinition.ReportObjects("txtContactUs")
                ContactUs.Text = dt.Rows(0).Item("ContactUs").ToString

                NgayLam = rpt.ReportDefinition.ReportObjects("NgayLam")
                NgayLam.Text = ReplaceDate(dt.Rows(0).Item("BookingDate").ToString)

                NguoiGui = rpt.ReportDefinition.ReportObjects("NguoiGuiBooking")
                NguoiGui.Text = dt.Rows(0).Item("BookingPerson").ToString

                Try
                    NguoiGui = rpt.ReportDefinition.ReportObjects("txtshippingmarks")
                    NguoiGui.Text = dt.Rows(0).Item("shippingmarks").ToString
                Catch ex As Exception

                End Try

                'rpt.ReportDefinition.ReportObjects("VAN").ObjectFormat.EnableSuppress = True
                'rpt.ReportDefinition.ReportObjects("HUNG").ObjectFormat.EnableSuppress = True
                'rpt.ReportDefinition.ReportObjects("HIEN").ObjectFormat.EnableSuppress = True
                'rpt.ReportDefinition.ReportObjects("HUONG").ObjectFormat.EnableSuppress = True

                'If UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "ĐẶNG HOÀNG VÂN" Then
                '    rpt.ReportDefinition.ReportObjects("VAN").ObjectFormat.EnableSuppress = False
                'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN ĐẮC HÙNG" Then
                '    rpt.ReportDefinition.ReportObjects("HUNG").ObjectFormat.EnableSuppress = False
                'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "PHAN THỊ THU HIỀN" Then
                '    rpt.ReportDefinition.ReportObjects("HIEN").ObjectFormat.EnableSuppress = False
                'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN THỊ THANH HƯƠNG" Then
                '    rpt.ReportDefinition.ReportObjects("HUONG").ObjectFormat.EnableSuppress = False
                'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "LƯƠNG THÚY PHƯƠNG" Then
                '    rpt.ReportDefinition.ReportObjects("PHUONG").ObjectFormat.EnableSuppress = False
                'End If


                TitleSend = rpt.ReportDefinition.ReportObjects("TitleSend")
                DateSend = rpt.ReportDefinition.ReportObjects("DateSend")

                If dt.Rows(0).Item("ThirdSendDate").ToString <> "" Then
                    TitleSend.Text = "Third Send :"
                    DateSend.Text = CDate(dt.Rows(0).Item("ThirdSendDate").ToString)
                ElseIf dt.Rows(0).Item("SecondSendDate").ToString <> "" Then
                    TitleSend.Text = "Second Send :"
                    DateSend.Text = CDate(dt.Rows(0).Item("SecondSendDate").ToString)
                ElseIf dt.Rows(0).Item("FirstSendDate").ToString <> "" Then
                    TitleSend.Text = "First Send :"
                    DateSend.Text = CDate(dt.Rows(0).Item("FirstSendDate").ToString)
                Else
                    TitleSend.Text = ""
                    DateSend.Text = ""
                End If

                Dim text As String = "YÊU CẦU QÚY CÔNG TY ĐỔI LỆNH CẤP CONTAINER TẠI : "
                Dim SupplyPlace As TextObject
                SupplyPlace = rpt.ReportDefinition.ReportObjects("SupplyPlace")
                If UCase(dt.Rows(0).Item("SupplyOrderPlace").ToString()) = "TERMINAL" Then
                    SupplyPlace.Text = text & "CÁT LÁI"
                Else
                    SupplyPlace.Text = text & " VP PHUONG NAM LOGISTICS"
                End If

            End If
            'QueryVessel(dt)
            If dt.Rows.Count > 0 Then

                Dim XuatTrenTau, DiNgay, denNgay As TextObject

                XuatTrenTau = rpt.ReportDefinition.ReportObjects("XuatTrenTau")
                XuatTrenTau.Text = dt.Rows(0).Item("carrier").ToString + "  " + dt.Rows(0).Item("voyno").ToString

                DiNgay = rpt.ReportDefinition.ReportObjects("DiNgay")
                DiNgay.Text = CDate(dt.Rows(0).Item("ETD").ToString)
                denNgay = rpt.ReportDefinition.ReportObjects("denNgay")
                denNgay.Text = CDate(dt.Rows(0).Item("ETA").ToString)


            End If
            Me.CrystalReportViewer1.ReportSource = rpt
            'Formatting paper
            Dim mymargins = rpt.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM
            rpt.PrintOptions.ApplyPageMargins(mymargins)
            If frmMain.mnuReportOrientationPortrait.Checked Then
                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            Else
                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            End If
            'rpt.Refresh()

            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub

    Private Sub chkrequest_CheckedChanged(sender As Object, e As EventArgs) Handles chkrequest.CheckedChanged

    End Sub
End Class