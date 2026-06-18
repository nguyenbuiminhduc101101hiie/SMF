Imports System.Runtime.InteropServices
Public Class frmchartR

    ' Global Variables 
    Dim img As Bitmap
    'Dim WithEvents pd As PrintDocument

    'Returns the Form as a bitmap
    Function CaptureForm1() As Bitmap

        Dim g1 As Graphics = Me.CreateGraphics()
        Dim MyImage = New Bitmap(Me.ClientRectangle.Width, (Me.ClientRectangle.Height), g1)
        Dim g2 As Graphics = Graphics.FromImage(MyImage)
        Dim dc1 As IntPtr = g1.GetHdc()
        Dim dc2 As IntPtr = g2.GetHdc()
        BitBlt(dc2, 0, 0, Me.ClientRectangle.Width, (Me.ClientRectangle.Height), dc1, 0, 0, 13369376)
        g1.ReleaseHdc(dc1)
        g2.ReleaseHdc(dc2)
        'saves image to c drive just, u can comment it also
        MyImage.Save("c:\abc.bmp")
        Return MyImage
    End Function

    <DllImport("gdi32.DLL", EntryPoint:="BitBlt", _
    SetLastError:=True, CharSet:=CharSet.Unicode, _
    ExactSpelling:=True, _
    CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean

        ' Leave function empty - DLLImport attribute forwards calls to MoveFile to
        ' MoveFileW in KERNEL32.DLL.
    End Function


    Private Sub frmChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I, congDon As Integer
        Dim SQL As String
        Dim dtcountS As New DataTable
        ' lay tat ca cac hang tau
        Dim mServiceId As String



        AxMSChart1.RowCount = Pricing.dgdRatedetail.RowCount

        AxMSChart1.ColumnCount = 12 'Specify count of graphs to be 2

        'the loop
        For I = 1 To AxMSChart1.RowCount  'Here it is dynamically and will work in all cases of values for AxMSChart1.Row

            'Set that we want to edit the row "I"
            AxMSChart1.Row = I  'dt.Rows(I).Item("shippingline").ToString


            'Setting it's label to I
            AxMSChart1.RowLabel = Pricing.dgdRatedetail.Item("servicecode", I - 1).Value.ToString '+ "(" + CDate(Pricing.dgdRatedetail.Item("INDATE", I - 1).Value.ToString).Date.ToShortDateString + " -> " + Pricing.dgdRatedetail.Item("OUTDATE", I - 1).Value.ToString + ")"


            'Editing the first graph

            AxMSChart1.Column = 1 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("gp20", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 1
            AxMSChart1.ColumnLabel = "20GP"
            'AxMSChart1.RowCoun = 100




            AxMSChart1.Column = 2 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("gp40", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 2
            AxMSChart1.ColumnLabel = "40GP"

            AxMSChart1.Column = 3 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("hc40", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 3
            AxMSChart1.ColumnLabel = "40HC"

            AxMSChart1.Column = 4 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("hc45", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 4
            AxMSChart1.ColumnLabel = "45HC"

            AxMSChart1.Column = 5 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("rf20", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 5
            AxMSChart1.ColumnLabel = "20RF"


            AxMSChart1.Column = 6 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("rf40", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 6
            AxMSChart1.ColumnLabel = "40RF"


            AxMSChart1.Column = 7 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("rh40", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 7
            AxMSChart1.ColumnLabel = "40RH"

            AxMSChart1.Column = 8 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("ot20", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 8
            AxMSChart1.ColumnLabel = "20OT"


            AxMSChart1.Column = 9 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("ot40", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 9
            AxMSChart1.ColumnLabel = "40OT"


            AxMSChart1.Column = 10 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("fr20", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 10
            AxMSChart1.ColumnLabel = "20FR"

            AxMSChart1.Column = 11 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("fr40", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 11
            AxMSChart1.ColumnLabel = "40FR"



            AxMSChart1.Column = 12 'Set that I want to edit the second graph
            AxMSChart1.Data = Pricing.dgdRatedetail.Item("cbm", I - 1).Value.ToString
            AxMSChart1.ColumnLabelCount = 12
            AxMSChart1.ColumnLabel = "CBM"

            ''Editing the second Graph
            'AxMSChart1.Column = 2 'Set that I want to edit the second graph

            'AxMSChart1.Data = CInt(dt1.Rows(0).Item("counts").ToString)
        Next



    End Sub

    Private Sub AxMSChart1_ChartSelected(ByVal sender As System.Object, ByVal e As AxMSChart20Lib._DMSChartEvents_ChartSelectedEvent)

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click

        img = CaptureForm1()
        'pd = New PrintDocument
        pd.DefaultPageSettings.Landscape = True

        pd.Print()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    'this method will be called each time when pd.printpage event occurs



    Private Sub pd_PrintPage1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd.PrintPage
        Dim x As Integer = e.MarginBounds.X
        Dim y As Integer = e.MarginBounds.Y
        e.Graphics.DrawImage(img, x, y)
        e.HasMorePages = False
    End Sub
End Class