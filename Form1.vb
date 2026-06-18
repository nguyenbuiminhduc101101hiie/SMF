Imports System.Runtime.InteropServices
Public Class frmChart

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
        Dim I As Integer
        ' lay tat ca cac hang tau
        Dim SQL As String
        SQL = "select Distinct shippingline From service Where Continued=1"
        Dim dt As New DataTable
        Dim dt1 As New DataTable
        dt = ReadTable(SQL)
        If dt.Rows.Count = 0 Then
            Return
        End If

        'First Step
        AxMSChart1.RowCount = dt.Rows.Count

        'Specify count of rows to be 5
        ' tuong ung moi carrier ta lay so luong service

        AxMSChart1.ColumnCount = 1 'Specify count of graphs to be 2

        'the loop
        For I = 1 To AxMSChart1.RowCount  'Here it is dynamically and will work in all cases of values for AxMSChart1.Row
            SQL = "select count(*) as countS From service Where Continued=1 and shippingline= '" & dt.Rows(I - 1).Item("shippingline").ToString & "'"
            dt1 = ReadTable(SQL)
            If dt1.Rows.Count = 0 Then
                AxMSChart1.Row = 0

                Exit For
            End If

            'Set that we want to edit the row "I"
            AxMSChart1.Row = I  'dt.Rows(I).Item("shippingline").ToString


            'Setting it's label to I
            AxMSChart1.RowLabel = dt.Rows(I - 1).Item("shippingline").ToString


            'Editing the first graph

            AxMSChart1.Column = 1 'Set that I want to edit the second graph
            AxMSChart1.Data = CInt(dt1.Rows(0).Item("counts").ToString)
            AxMSChart1.ColumnLabel = dt.Rows(I - 1).Item("shippingline").ToString

            AxMSChart1.ColumnLabel = CInt(dt1.Rows(0).Item("counts").ToString).ToString
            ''Editing the second Graph
            'AxMSChart1.Column = 2 'Set that I want to edit the second graph

            'AxMSChart1.Data = CInt(dt1.Rows(0).Item("counts").ToString)
        Next



    End Sub

    Private Sub AxMSChart1_ChartSelected(ByVal sender As System.Object, ByVal e As AxMSChart20Lib._DMSChartEvents_ChartSelectedEvent)

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

        img = CaptureForm1()
        'pd = New PrintDocument
        pd.DefaultPageSettings.Landscape = True

        pd.Print()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
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