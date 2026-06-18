Imports System
Imports dotnetCHARTING.WinForms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Public Class frmCharting
    Public bmp As Bitmap
    Dim Title As String = ""
    Function queryBookingDay(Optional ByVal SelectField As String = "", Optional ByVal arg As String = "") As DataTable
        Try
            Dim SQL As String
            SQL = " Select " & SelectField & " sum(Soluong20GP) as [20GP] ,Sum(SoLuong40GP) as [40GP],sum(SoLuong40HC) as [40HC],"
            SQL &= " Sum(SoLuong45HC) as [45HC],sum(SoLuong20RF) as [20RF],sum(SoLuong40RF) as [40RF], sum(SoLuong40RH) as [40RH],sum(Soluong20OT) as [20OT],sum(Soluong40OT) as [40OT],sum(Soluong20FR) as [20FR],sum(Soluong40FR) as [40FR] "
            SQL &= " From ContainerOutboundNotify "
            SQL &= arg
            SQL &= " Group By leavingdate "
            SQL &= " Order By leavingdate "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return (dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

   
    Function queryBookingMonth(Optional ByVal SelectField As String = "", Optional ByVal arg As String = "") As DataTable
        Try
            Dim SQL As String
            SQL = " Select " & SelectField & " sum(Soluong20GP) as [20GP] ,Sum(SoLuong40GP) as [40GP],sum(SoLuong40HC) as [40HC],"
            SQL &= " Sum(SoLuong45HC) as [45HC],sum(SoLuong20RF) as [20RF],sum(SoLuong40RF) as [40RF], sum(SoLuong40RH) as [40RH],sum(Soluong20OT) as [20OT],sum(Soluong40OT) as [40OT],sum(Soluong20FR) as [20FR],sum(Soluong40FR) as [40FR] "
            SQL &= " From ContainerOutboundNotify "
            SQL &= arg
            SQL &= " Group By Month(leavingdate) "
            SQL &= " Order By month(leavingdate) "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return (dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function queryBookingYear(Optional ByVal SelectField As String = "", Optional ByVal arg As String = "") As DataTable
        Try
            Dim SQL As String
            SQL = " Select " & SelectField & " sum(Soluong20GP) as [20GP] ,Sum(SoLuong40GP) as [40GP],sum(SoLuong40HC) as [40HC],"
            SQL &= " Sum(SoLuong45HC) as [45HC],sum(SoLuong20RF) as [20RF],sum(SoLuong40RF) as [40RF], sum(SoLuong40RH) as [40RH],sum(Soluong20OT) as [20OT],sum(Soluong40OT) as [40OT],sum(Soluong20FR) as [20FR],sum(Soluong40FR) as [40FR] "
            SQL &= " From ContainerOutboundNotify "
            SQL &= arg
            SQL &= " Group By Year(leavingdate) "
            SQL &= " Order By Year(leavingdate) "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return (dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim oTable As New DataTable
            Me.Cursor = Cursors.WaitCursor
            If Me.chkmonth.Checked = True Then
                oTable = queryBookingMonth("Month(leavingdate) as [Date],", " where Continued=1 And Convert(DateTime,leavingdate)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,leavingdate)-1<'" & Me.dtpToBookingDate.Value.Date & "'")
            ElseIf Me.chkYear.Checked = True Then
                oTable = queryBookingYear("Year(leavingdate) as [Date],", " where Continued=1 And Convert(DateTime,leavingdate)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,leavingdate)-1<'" & Me.dtpToBookingDate.Value.Date & "'")
            Else
                oTable = queryBookingDay("leavingdate as [Date],", " where Continued=1 And Convert(DateTime,leavingdate)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,leavingdate)-1<'" & Me.dtpToBookingDate.Value.Date & "'")
            End If


            Dim TempChart As Chart = New Chart()

            TempChart.Title = Title

            TempChart.TempDirectory = "temp"
            TempChart.Debug = True
            TempChart.XAxis.Label.Text = "Date"
            TempChart.YAxis.NumberPercision = 0
            TempChart.YAxis.Label.Text = "Container(s)"


            'Adding series programatically
            Dim sr As Series
            Dim el As Element
            Dim Type() As String = {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH", "20OT", "40OT", "20FR", "40FR"}
            For i As Integer = 0 To Type.Length - 1
                sr = New Series()
                sr.Name = Type(i)
                For j As Integer = 0 To oTable.Rows.Count - 1


                    el = New Element(oTable.Rows(j).Item("date"), oTable.Rows(j).Item(Type(i)))
                    sr.Elements.Add(el)
                    'el = New Element("3-1-2007", 20)
                    'sr.Elements.Add(el)
                    'el = New Element("20-1-2007", 13)
                    'sr.Elements.Add(el)
                    'el = New Element("31-12-2007", 5)
                    'sr.Elements.Add(el)

                Next
                TempChart.SeriesCollection.Add(sr)

            Next

            'sr = New Series()
            'sr.Name = "Houston"
            'el = New Element("Spring", 20)
            'sr.Elements.Add(el)
            'el = New Element("Summer", 32)
            'sr.Elements.Add(el)
            'el = New Element("Autumn", 18)
            'sr.Elements.Add(el)
            'el = New Element("Winter", 10)
            'sr.Elements.Add(el)
            'me.Chart1.SeriesCollection.Add(sr)

            'Add new calculatd series bound to a seperate axis
            TempChart.Series.Name = "Total"
            'TempChart.Series.Type = SeriesType.Line

            Dim ATotal As Axis
            ATotal = New Axis()
            ATotal.Orientation = Orientation.Right
            ATotal.Label.Text = "Total Container Booked"

            TempChart.Series.YAxis = ATotal
            TempChart.SeriesCollection.Add(Calculation.Sum)
            'Me.Chart1 = TempChart
            'Invalidate()
            bmp = ChangeSize(TempChart.GetChartBitmap(), Me.picChart.Width, Me.picChart.Height)
            Me.picChart.Image = bmp
            Me.picChart.BorderStyle = BorderStyle.Fixed3D
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Function ChangeSize(ByVal bmp As Bitmap, ByVal w As Integer, ByVal H As Integer)
        Try
            Dim g As Graphics
            Dim img As New Bitmap(w, H)
            g = Graphics.FromImage(img)
            g.DrawImage(bmp, 0, 0, w, H)
            g.Dispose()
            Return img
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub frmCharting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmCharting_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If IsNothing(bmp) Then
            Return
        End If
        Me.picChart.Image = ChangeSize(bmp, Me.picChart.Width, Me.picChart.Height)
        Me.picChart.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub cmdViewCancelBookingGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCancelBookingGraph.Click
        Try
            Dim oTable As New DataTable
            Me.Cursor = Cursors.WaitCursor
            If Me.chkmonth.Checked = True Then
                oTable = queryBookingMonth("Month(BookingDate) as [Date],", " where Continued=0 And BC='CL' And Convert(DateTime,BookingDate)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,BookingDate)-1<'" & Me.dtpToBookingDate.Value.Date & "'")
            ElseIf Me.chkYear.Checked = True Then
                oTable = queryBookingYear("Year(BookingDate) as [Date],", " where Continued=0 And BC='CL' And Convert(DateTime,BookingDate)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,BookingDate)-1<'" & Me.dtpToBookingDate.Value.Date & "'")
            Else
                oTable = queryBookingDay("BookingDate as [Date],", " where Continued=0 And BC='CL' And Convert(DateTime,BookingDate)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,BookingDate)-1<'" & Me.dtpToBookingDate.Value.Date & "'")
            End If


            Dim TempChart As Chart = New Chart()

            TempChart.Title = Title

            TempChart.TempDirectory = "temp"
            TempChart.Debug = True
            TempChart.XAxis.Label.Text = "Date"
            TempChart.YAxis.NumberPercision = 0
            TempChart.YAxis.Label.Text = "Container(s)"


            'Adding series programatically
            Dim sr As Series
            Dim el As Element
            Dim Type() As String = {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH"}
            For i As Integer = 0 To Type.Length - 1
                sr = New Series()
                sr.Name = Type(i)
                For j As Integer = 0 To oTable.Rows.Count - 1


                    el = New Element(oTable.Rows(j).Item("date"), oTable.Rows(j).Item(Type(i)))
                    sr.Elements.Add(el)
                    'el = New Element("3-1-2007", 20)
                    'sr.Elements.Add(el)
                    'el = New Element("20-1-2007", 13)
                    'sr.Elements.Add(el)
                    'el = New Element("31-12-2007", 5)
                    'sr.Elements.Add(el)

                Next
                TempChart.SeriesCollection.Add(sr)

            Next

            'sr = New Series()
            'sr.Name = "Houston"
            'el = New Element("Spring", 20)
            'sr.Elements.Add(el)
            'el = New Element("Summer", 32)
            'sr.Elements.Add(el)
            'el = New Element("Autumn", 18)
            'sr.Elements.Add(el)
            'el = New Element("Winter", 10)
            'sr.Elements.Add(el)
            'me.Chart1.SeriesCollection.Add(sr)

            'Add new calculatd series bound to a seperate axis
            TempChart.Series.Name = "Total"
            'TempChart.Series.Type = SeriesType.Line

            Dim ATotal As Axis
            ATotal = New Axis()
            ATotal.Orientation = Orientation.Right
            ATotal.Label.Text = "Total Container Booked"

            TempChart.Series.YAxis = ATotal
            TempChart.SeriesCollection.Add(Calculation.Sum)
            'Me.Chart1 = TempChart
            'Invalidate()
            bmp = ChangeSize(TempChart.GetChartBitmap(), Me.picChart.Width, Me.picChart.Height)
            Me.picChart.Image = bmp
            Me.picChart.BorderStyle = BorderStyle.Fixed3D
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cmdPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPreview.Click
        Try
            Dim doc As New PrintDocument
            AddHandler doc.PrintPage, New PrintPageEventHandler(AddressOf DrawingDoc)
            Me.PrintPreviewDialog1.Document = doc
            Me.PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub DrawingDoc(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Try
            e.Graphics.DrawImage(bmp, 0, 0)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdExportImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportImage.Click
        Try
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                bmp.Save(Me.SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Tiff)

            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class