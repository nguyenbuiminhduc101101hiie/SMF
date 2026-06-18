Imports System
Imports dotnetCHARTING.WinForms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Public Class frmChartingInbound
    Public bmp As Bitmap
    Public TranSit As Integer
    Dim Title As String = ""

    Dim Type() As String '= {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH"}

    Function QueryDataDay(Optional ByVal SelectField As String = "", Optional ByVal arg As String = "") As DataTable
        Try

            Dim SQL As String

            SQL = " Select " & SelectField & " "
            GetContainerType(Type, arg)
            For i As Integer = 0 To Type.Length - 1
                If Type(i) <> "" Then
                    SQL &= " Case Container_Type When '" & Type(i) & "' Then Count(Container_Type) else 0 End  as [" & Type(i) & "] ,"
                End If
            Next
            SQL = SQL.Trim
            SQL = SQL.Remove(SQL.Length - 1)
            SQL &= " From (CargoIB INNER JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID ) "
            SQL &= " Where CargoIB.Continued=1 And BillOfLadingIB.Continued=1 " & arg
            SQL &= " Group By BillOfLadingIB.ETA,Container_type "
            SQL &= " Order By BillOfLadingIB.ETA "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return (dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryDataMonth(Optional ByVal SelectField As String = "", Optional ByVal arg As String = "") As DataTable
        Try
            Dim SQL As String

            SQL = " Select " & SelectField & " "
            GetContainerType(Type, arg)
            For i As Integer = 0 To Type.Length - 1
                If Type(i) <> "" Then
                    SQL &= " Case Container_Type When '" & Type(i) & "' Then Count(Container_Type) else 0 End  as [" & Type(i) & "] ,"
                End If
            Next
            SQL = SQL.Trim
            SQL = SQL.Remove(SQL.Length - 1)
            SQL &= " From (CargoIB INNER JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID ) "
            SQL &= " Where CargoIB.Continued=1 And BillOfLadingIB.Continued=1 " & arg
            SQL &= " Group By Month(BillOfLadingIB.ETA),Container_type "
            SQL &= " Order By Month(BillOfLadingIB.ETA) "
            Dim dt As New DataTable
            dt = ReadTable(SQL)

            Return (dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub GetContainerType(ByRef type() As String, Optional ByVal arg As String = "")
        Try
            Dim SQl As String
            SQl = "Select Distinct Container_Type as Type "
            SQl &= " From (CargoIB INNER JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID ) "
            SQl &= " Where CargoIB.Continued=1 And BillOfLadingIB.Continued=1 " & arg
            SQl &= " Order By Container_Type "
            Dim dt As New DataTable
            dt = ReadTable(SQl)
            ReDim type(dt.Rows.Count)
            For i As Integer = 0 To dt.Rows.Count - 1
                type(i) = dt.Rows(i).Item("Type").ToString
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function QueryDataYear(Optional ByVal SelectField As String = "", Optional ByVal arg As String = "") As DataTable
        Try

            Dim SQL As String

            SQL = " Select " & SelectField & " "
            GetContainerType(Type, arg)
            For i As Integer = 0 To Type.Length - 1
                If Type(i) <> "" Then
                    SQL &= " Case Container_Type When '" & Type(i) & "' Then Count(Container_Type) else 0 End  as [" & Type(i) & "] ,"
                End If
            Next
            SQL = SQL.Remove(SQL.Length - 1)
            SQL &= " From (CargoIB INNER JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID ) "
            SQL &= " Where CargoIB.Continued=1 And BillOfLadingIB.Continued=1 " & arg
            SQL &= " Group By Year(BillOfLadingIB.ETA),Container_type "
            SQL &= " Order By Year(BillOfLadingIB.ETA) "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return (dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub okClick()
        Try
            Dim oTable As New DataTable
            Me.Cursor = Cursors.WaitCursor
            Dim Arg As String
            If Me.chkmonth.Checked = True Then
                Arg = " And  Convert(DateTime,BillOfLadingIB.ETA)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,BillOfLadingIB.ETA)-1<'" & Me.dtpToBookingDate.Value.Date & "' And Transit=" & TranSit & " "
                oTable = QueryDataMonth("Month(BillOfLadingIB.ETA) as [Date],", Arg)
            ElseIf Me.chkYear.Checked = True Then
                Arg = " And Convert(DateTime,BillOfLadingIB.ETA)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,BillOfLadingIB.ETA)-1<'" & Me.dtpToBookingDate.Value.Date & "' And Transit=" & TranSit & " "
                oTable = QueryDataYear("Year(BillOfLadingIB.ETA) as [Date],", Arg)
            Else
                Arg = " And Convert(DateTime,BillOfLadingIB.ETA)+ 1>'" & Me.dtpFrom.Value.Date & "' And Convert(DateTime,BillOfLadingIB.ETA)-1<'" & Me.dtpToBookingDate.Value.Date & "' And Transit=" & TranSit & " "
                oTable = QueryDataDay(" BillOfLadingIB.ETA  as [Date],", Arg)
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

            'GetContainerType(Type, Arg)
            For i As Integer = 0 To Type.Length - 1
                If Type(i) = "" Then
                    Continue For
                End If
                sr = New Series()
                sr.Name = Type(i)
                For j As Integer = 0 To oTable.Rows.Count - 1
                    Dim d As String
                    d = oTable.Rows(j).Item("Date").ToString().Replace("12:00:00 AM", "")
                    Dim sumContainer As Integer = 0 'oTable.Rows(j).Item(Type(i))
                    While (j < oTable.Rows.Count)
                        If d = oTable.Rows(j).Item("Date").ToString().Replace("12:00:00 AM", "") Then
                            sumContainer += oTable.Rows(j).Item(Type(i))
                        Else
                            Exit While
                        End If

                        j += 1
                    End While
                    el = New Element(d, sumContainer)
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
            ATotal.Label.Text = "Total Container "

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
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        TranSit = 0
        okClick()
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

    Private Sub frmChartingInbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TranSit = 0
    End Sub

    Private Sub frmChartingInbound_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If IsNothing(bmp) Then
            Return
        End If
        Me.picChart.Image = ChangeSize(bmp, Me.picChart.Width, Me.picChart.Height)
        Me.picChart.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub cmdViewTransitGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewTransitGraph.Click
        TranSit = 1
        okClick()
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