Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System
Namespace _DCubeNoGimbalLock

    Class Math3D

        Const PIOVER180 As Double = Math.PI / 180.0

        Public Class Vector3D
            Public x As Single
            Public y As Single
            Public z As Single

            Public Sub New(ByVal _x As Integer, ByVal _y As Integer, ByVal _z As Integer)
                x = _x
                y = _y
                z = _z
            End Sub

            Public Sub New(ByVal _x As Double, ByVal _y As Double, ByVal _z As Double)
                x = CSng(_x)
                y = CSng(_y)
                z = CSng(_z)
            End Sub

            Public Sub New(ByVal _x As Single, ByVal _y As Single, ByVal _z As Single)
                x = _x
                y = _y
                z = _z
            End Sub

            Public Sub New()
            End Sub

            Public Overrides Function ToString() As String
                Return "(" & x.ToString() & ", " & y.ToString() & ", " & z.ToString() & ")"
            End Function
        End Class

        Friend Class Camera
            Public position As New Vector3D()
        End Class

        Public Class Cube

            'Cube face, has four points, 3D and 2D
            Friend Class Face
                Implements IComparable

                Public Enum Side
                    Front
                    Back
                    Left
                    Right
                    Top
                    Bottom
                End Enum

                Public Corners2D As PointF()
                Public Corners3D As Vector3D()
                Public Center As Vector3D
                Public CubeSide As Side

                Public Sub New()
                End Sub

                Public Function CompareTo(ByVal otherFace As Face) As Integer
                    Return CInt(Math.Truncate(Me.Center.z - otherFace.Center.z))
                    'In order of which is closest to the screen
                End Function

                Public Function CompareTo1(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

                End Function
            End Class

            Public width As Integer = 0
            Public height As Integer = 0
            Public depth As Integer = 0

            Private xRotation As Single = 0.0F
            Private yRotation As Single = 0.0F
            Private zRotation As Single = 0.0F

            Private m_drawWires As Boolean = True
            Private m_fillFront As Boolean
            Private m_fillBack As Boolean
            Private m_fillLeft As Boolean
            Private m_fillRight As Boolean
            Private m_fillTop As Boolean
            Private m_fillBottom As Boolean

            Private cubeOrigin As Vector3D

            Private faces As Face()

            Public Property RotateX() As Single
                Get
                    Return xRotation
                End Get
                Set(ByVal value As Single)
                    'rotate the difference between this rotation and last rotation
                    RotateCubeX(value - xRotation)
                    xRotation = value
                End Set
            End Property

            Public Property RotateY() As Single
                Get
                    Return yRotation
                End Get
                Set(ByVal value As Single)
                    RotateCubeY(value - yRotation)
                    yRotation = value
                End Set
            End Property

            Public Property RotateZ() As Single
                Get
                    Return zRotation
                End Get
                Set(ByVal value As Single)
                    RotateCubeZ(value - zRotation)
                    zRotation = value
                End Set
            End Property

            Public Property DrawWires() As Boolean
                Get
                    Return m_drawWires
                End Get
                Set(ByVal value As Boolean)
                    m_drawWires = value
                End Set
            End Property
            Public Property FillFront() As Boolean
                Get
                    Return m_fillFront
                End Get
                Set(ByVal value As Boolean)
                    m_fillFront = value
                End Set
            End Property
            Public Property FillBack() As Boolean
                Get
                    Return m_fillBack
                End Get
                Set(ByVal value As Boolean)
                    m_fillBack = value
                End Set
            End Property
            Public Property FillLeft() As Boolean
                Get
                    Return m_fillLeft
                End Get
                Set(ByVal value As Boolean)
                    m_fillLeft = value
                End Set
            End Property
            Public Property FillRight() As Boolean
                Get
                    Return m_fillRight
                End Get
                Set(ByVal value As Boolean)
                    m_fillRight = value
                End Set
            End Property
            Public Property FillTop() As Boolean
                Get
                    Return m_fillTop
                End Get
                Set(ByVal value As Boolean)
                    m_fillTop = value
                End Set
            End Property
            Public Property FillBottom() As Boolean
                Get
                    Return m_fillBottom
                End Get
                Set(ByVal value As Boolean)
                    m_fillBottom = value
                End Set
            End Property


#Region "Initializers"
            Public Sub New(ByVal side As Integer)
                width = side
                height = side
                depth = side
                cubeOrigin = New Math3D.Vector3D(width \ 2, height \ 2, depth \ 2)
                InitializeCube()
            End Sub

            Public Sub New(ByVal side As Integer, ByVal origin As Vector3D)
                width = side
                height = side
                depth = side
                cubeOrigin = origin

                InitializeCube()
            End Sub

            Public Sub New(ByVal Width__1 As Integer, ByVal Height__2 As Integer, ByVal Depth__3 As Integer)
                width = Width__1
                height = Height__2
                depth = Depth__3
                cubeOrigin = New Math3D.Vector3D(width \ 2, height \ 2, depth \ 2)

                InitializeCube()
            End Sub

            Public Sub New(ByVal Width__1 As Integer, ByVal Height__2 As Integer, ByVal Depth__3 As Integer, ByVal origin As Vector3D)
                width = Width__1
                height = Height__2
                depth = Depth__3
                cubeOrigin = origin

                InitializeCube()
            End Sub
#End Region

            Private Sub InitializeCube()
                'Fill in the cube

                faces = New Face(5) {}
                'cube has 6 faces
                'Front Face --------------------------------------------
                faces(0) = New Face()
                faces(0).CubeSide = Face.Side.Front
                faces(0).Corners3D = New Vector3D(3) {}
                faces(0).Corners3D(0) = New Vector3D(0, 0, 0)
                faces(0).Corners3D(1) = New Vector3D(0, height, 0)
                faces(0).Corners3D(2) = New Vector3D(width, height, 0)
                faces(0).Corners3D(3) = New Vector3D(width, 0, 0)
                faces(0).Center = New Vector3D(width \ 2, height \ 2, 0)
                ' -------------------------------------------------------

                'Back Face --------------------------------------------
                faces(1) = New Face()
                faces(1).CubeSide = Face.Side.Back
                faces(1).Corners3D = New Vector3D(3) {}
                faces(1).Corners3D(0) = New Vector3D(0, 0, depth)
                faces(1).Corners3D(1) = New Vector3D(0, height, depth)
                faces(1).Corners3D(2) = New Vector3D(width, height, depth)
                faces(1).Corners3D(3) = New Vector3D(width, 0, depth)
                faces(1).Center = New Vector3D(width \ 2, height \ 2, depth)
                ' -------------------------------------------------------

                'Left Face --------------------------------------------
                faces(2) = New Face()
                faces(2).CubeSide = Face.Side.Left
                faces(2).Corners3D = New Vector3D(3) {}
                faces(2).Corners3D(0) = New Vector3D(0, 0, 0)
                faces(2).Corners3D(1) = New Vector3D(0, 0, depth)
                faces(2).Corners3D(2) = New Vector3D(0, height, depth)
                faces(2).Corners3D(3) = New Vector3D(0, height, 0)
                faces(2).Center = New Vector3D(0, height \ 2, depth \ 2)
                ' -------------------------------------------------------

                'Right Face --------------------------------------------
                faces(3) = New Face()
                faces(3).CubeSide = Face.Side.Right
                faces(3).Corners3D = New Vector3D(3) {}
                faces(3).Corners3D(0) = New Vector3D(width, 0, 0)
                faces(3).Corners3D(1) = New Vector3D(width, 0, depth)
                faces(3).Corners3D(2) = New Vector3D(width, height, depth)
                faces(3).Corners3D(3) = New Vector3D(width, height, 0)
                faces(3).Center = New Vector3D(width, height \ 2, depth \ 2)
                ' -------------------------------------------------------

                'Top Face --------------------------------------------
                faces(4) = New Face()
                faces(4).CubeSide = Face.Side.Top
                faces(4).Corners3D = New Vector3D(3) {}
                faces(4).Corners3D(0) = New Vector3D(0, 0, 0)
                faces(4).Corners3D(1) = New Vector3D(0, 0, depth)
                faces(4).Corners3D(2) = New Vector3D(width, 0, depth)
                faces(4).Corners3D(3) = New Vector3D(width, 0, 0)
                faces(4).Center = New Vector3D(width \ 2, 0, depth \ 2)
                ' -------------------------------------------------------

                'Bottom Face --------------------------------------------
                faces(5) = New Face()
                faces(5).CubeSide = Face.Side.Bottom
                faces(5).Corners3D = New Vector3D(3) {}
                faces(5).Corners3D(0) = New Vector3D(0, height, 0)
                faces(5).Corners3D(1) = New Vector3D(0, height, depth)
                faces(5).Corners3D(2) = New Vector3D(width, height, depth)
                faces(5).Corners3D(3) = New Vector3D(width, height, 0)
                faces(5).Center = New Vector3D(width \ 2, height, depth \ 2)
                ' -------------------------------------------------------
            End Sub

            'Calculates the 2D points of each face
            Private Sub Update2DPoints(ByVal drawOrigin As Point)
                'Update the 2D points of all the faces
                For i As Integer = 0 To faces.Length - 1
                    Update2DPoints(drawOrigin, i)
                Next
            End Sub

            Private Sub Update2DPoints(ByVal drawOrigin As Point, ByVal faceIndex As Integer)
                'Calculates the projected coordinates of the 3D points in a cube face
                Dim point2D As PointF() = New PointF(3) {}
                Dim zoom As Single = CSng(Screen.PrimaryScreen.Bounds.Width) / 1.5F
                Dim tmpOrigin As New Point(0, 0)

                'Convert 3D Points to 2D
                Dim vec As Math3D.Vector3D
                For i As Integer = 0 To point2D.Length - 1
                    vec = faces(faceIndex).Corners3D(i)
                    point2D(i) = Get2D(vec, drawOrigin)
                Next

                'Update face
                faces(faceIndex).Corners2D = point2D
            End Sub

            'Rotating methods, has to translate the cube to the rotation point (center), rotate, and translate back

            Private Sub RotateCubeX(ByVal deltaX As Single)
                For i As Integer = 0 To faces.Length - 1
                    'Apply rotation
                    '------Rotate points
                    Dim point0 As New Vector3D(0, 0, 0)
                    faces(i).Corners3D = Math3D.Translate(faces(i).Corners3D, cubeOrigin, point0)
                    'Move corner to origin
                    faces(i).Corners3D = Math3D.RotateX(faces(i).Corners3D, deltaX)
                    faces(i).Corners3D = Math3D.Translate(faces(i).Corners3D, point0, cubeOrigin)
                    'Move back
                    '-------Rotate center
                    faces(i).Center = Math3D.Translate(faces(i).Center, cubeOrigin, point0)
                    faces(i).Center = Math3D.RotateX(faces(i).Center, deltaX)
                    faces(i).Center = Math3D.Translate(faces(i).Center, point0, cubeOrigin)
                Next
            End Sub

            Private Sub RotateCubeY(ByVal deltaY As Single)
                For i As Integer = 0 To faces.Length - 1
                    'Apply rotation
                    '------Rotate points
                    Dim point0 As New Vector3D(0, 0, 0)
                    faces(i).Corners3D = Math3D.Translate(faces(i).Corners3D, cubeOrigin, point0)
                    'Move corner to origin
                    faces(i).Corners3D = Math3D.RotateY(faces(i).Corners3D, deltaY)
                    faces(i).Corners3D = Math3D.Translate(faces(i).Corners3D, point0, cubeOrigin)
                    'Move back
                    '-------Rotate center
                    faces(i).Center = Math3D.Translate(faces(i).Center, cubeOrigin, point0)
                    faces(i).Center = Math3D.RotateY(faces(i).Center, deltaY)
                    faces(i).Center = Math3D.Translate(faces(i).Center, point0, cubeOrigin)
                Next
            End Sub

            Private Sub RotateCubeZ(ByVal deltaZ As Single)
                For i As Integer = 0 To faces.Length - 1
                    'Apply rotation
                    '------Rotate points
                    Dim point0 As New Vector3D(0, 0, 0)
                    faces(i).Corners3D = Math3D.Translate(faces(i).Corners3D, cubeOrigin, point0)
                    'Move corner to origin
                    faces(i).Corners3D = Math3D.RotateZ(faces(i).Corners3D, deltaZ)
                    faces(i).Corners3D = Math3D.Translate(faces(i).Corners3D, point0, cubeOrigin)
                    'Move back
                    '-------Rotate center
                    faces(i).Center = Math3D.Translate(faces(i).Center, cubeOrigin, point0)
                    faces(i).Center = Math3D.RotateZ(faces(i).Center, deltaZ)
                    faces(i).Center = Math3D.Translate(faces(i).Center, point0, cubeOrigin)
                Next
            End Sub

            Public Function DrawCube(ByVal drawOrigin As Point) As Bitmap
                'Get the corresponding 2D
                Update2DPoints(drawOrigin)

                'Get the bounds of the final bitmap
                Dim bounds As Rectangle = getDrawingBounds()
                bounds.Width += drawOrigin.X
                bounds.Height += drawOrigin.Y

                Dim finalBmp As New Bitmap(bounds.Width, bounds.Height)
                Dim g As Graphics = Graphics.FromImage(finalBmp)

                g.SmoothingMode = SmoothingMode.AntiAlias

                Array.Sort(faces)
                'sort faces from closets to farthest
                'message();
                For i As Integer = faces.Length - 1 To 0 Step -1
                    'draw faces from back to front
                    Select Case faces(i).CubeSide
                        Case Face.Side.Front
                            If m_fillFront Then
                                g.FillPolygon(Brushes.Gray, GetFrontFace())
                            End If
                            Exit Select
                        Case Face.Side.Back
                            If m_fillBack Then
                                g.FillPolygon(Brushes.DarkGray, GetBackFace())
                            End If
                            Exit Select
                        Case Face.Side.Left
                            If m_fillLeft Then
                                g.FillPolygon(Brushes.Gray, GetLeftFace())
                            End If
                            Exit Select
                        Case Face.Side.Right
                            If m_fillRight Then
                                g.FillPolygon(Brushes.DarkGray, GetRightFace())
                            End If
                            Exit Select
                        Case Face.Side.Top
                            If m_fillTop Then
                                g.FillPolygon(Brushes.Gray, GetTopFace())
                            End If
                            Exit Select
                        Case Face.Side.Bottom
                            If m_fillBottom Then
                                g.FillPolygon(Brushes.DarkGray, GetBottomFace())
                            End If
                            Exit Select
                        Case Else
                            Exit Select
                    End Select

                    If m_drawWires Then
                        g.DrawLine(Pens.Black, faces(i).Corners2D(0), faces(i).Corners2D(1))
                        g.DrawLine(Pens.Black, faces(i).Corners2D(1), faces(i).Corners2D(2))
                        g.DrawLine(Pens.Black, faces(i).Corners2D(2), faces(i).Corners2D(3))
                        g.DrawLine(Pens.Black, faces(i).Corners2D(3), faces(i).Corners2D(0))
                    End If
                Next

                g.Dispose()

                Return finalBmp
            End Function

            'Converts 3D points to 2D points
            Private Function Get2D(ByVal vec As Vector3D, ByVal drawOrigin As Point) As PointF
                Dim point2D As PointF = Get2D(vec)
                Return New PointF(point2D.X + drawOrigin.X, point2D.Y + drawOrigin.Y)
            End Function

            Private Function Get2D(ByVal vec As Vector3D) As PointF
                Dim returnPoint As New PointF()

                Dim zoom As Single = CSng(Screen.PrimaryScreen.Bounds.Width) / 1.5F
                Dim tempCam As New Camera()

                tempCam.position.x = cubeOrigin.x
                tempCam.position.y = cubeOrigin.y
                tempCam.position.z = (cubeOrigin.x * zoom) / cubeOrigin.x

                Dim zValue As Single = -vec.z - tempCam.position.z

                returnPoint.X = (tempCam.position.x - vec.x) / zValue * zoom
                returnPoint.Y = (tempCam.position.y - vec.y) / zValue * zoom

                Return returnPoint
            End Function

            Public Function GetFrontFace() As PointF()
                'Returns the four points corresponding to the front face
                'Get the corresponding 2D
                Return getFace(Face.Side.Front).Corners2D
            End Function

            Public Function GetBackFace() As PointF()
                Return getFace(Face.Side.Back).Corners2D
            End Function

            Public Function GetRightFace() As PointF()
                Return getFace(Face.Side.Right).Corners2D
            End Function

            Public Function GetLeftFace() As PointF()
                Return getFace(Face.Side.Left).Corners2D
            End Function

            Public Function GetTopFace() As PointF()
                Return getFace(Face.Side.Top).Corners2D
            End Function

            Public Function GetBottomFace() As PointF()
                Return getFace(Face.Side.Bottom).Corners2D
            End Function

            Private Function getFace(ByVal side As Face.Side) As Face
                'Find the correct side
                'Since faces are sorted in order of closest to farthest
                'They won't always be in the same index
                For i As Integer = 0 To faces.Length - 1
                    If faces(i).CubeSide = side Then
                        Return faces(i)
                    End If
                Next

                Return Nothing
                'not found
            End Function

            Private Function getDrawingBounds() As Rectangle
                'Find the farthest most points to calculate the size of the returning bitmap
                Dim left As Single = Single.MaxValue
                Dim right As Single = Single.MinValue
                Dim top As Single = Single.MaxValue
                Dim bottom As Single = Single.MinValue

                For i As Integer = 0 To faces.Length - 1
                    For j As Integer = 0 To faces(i).Corners2D.Length - 1
                        If faces(i).Corners2D(j).X < left Then
                            left = faces(i).Corners2D(j).X
                        End If
                        If faces(i).Corners2D(j).X > right Then
                            right = faces(i).Corners2D(j).X
                        End If
                        If faces(i).Corners2D(j).Y < top Then
                            top = faces(i).Corners2D(j).Y
                        End If
                        If faces(i).Corners2D(j).Y > bottom Then
                            bottom = faces(i).Corners2D(j).Y
                        End If
                    Next
                Next

                Return New Rectangle(0, 0, CInt(Math.Truncate(Math.Round(right - left))), CInt(Math.Truncate(Math.Round(bottom - top))))
            End Function
        End Class

        Public Shared Function RotateX(ByVal point3D As Vector3D, ByVal degrees As Single) As Vector3D
            '[ a  b  c ] [ x ]   [ x*a + y*b + z*c ]
            '[ d  e  f ] [ y ] = [ x*d + y*e + z*f ]
            '[ g  h  i ] [ z ]   [ x*g + y*h + z*i ]

            '[ 1    0        0   ]
            '[ 0   cos(x)  sin(x)]
            '[ 0   -sin(x) cos(x)]

            Dim cDegrees As Double = degrees * PIOVER180
            Dim cosDegrees As Double = Math.Cos(cDegrees)
            Dim sinDegrees As Double = Math.Sin(cDegrees)

            Dim y As Double = (point3D.y * cosDegrees) + (point3D.z * sinDegrees)
            Dim z As Double = (point3D.y * -sinDegrees) + (point3D.z * cosDegrees)

            Return New Vector3D(point3D.x, y, z)
        End Function

        Public Shared Function RotateY(ByVal point3D As Vector3D, ByVal degrees As Single) As Vector3D
            '[ cos(x)   0    sin(x)]
            '[   0      1      0   ]
            '[-sin(x)   0    cos(x)]

            Dim cDegrees As Double = degrees * PIOVER180
            Dim cosDegrees As Double = Math.Cos(cDegrees)
            Dim sinDegrees As Double = Math.Sin(cDegrees)

            Dim x As Double = (point3D.x * cosDegrees) + (point3D.z * sinDegrees)
            Dim z As Double = (point3D.x * -sinDegrees) + (point3D.z * cosDegrees)

            Return New Vector3D(x, point3D.y, z)
        End Function

        Public Shared Function RotateZ(ByVal point3D As Vector3D, ByVal degrees As Single) As Vector3D
            '[ cos(x)  sin(x) 0]
            '[ -sin(x) cos(x) 0]
            '[    0     0     1]

            Dim cDegrees As Double = degrees * PIOVER180
            Dim cosDegrees As Double = Math.Cos(cDegrees)
            Dim sinDegrees As Double = Math.Sin(cDegrees)

            Dim x As Double = (point3D.x * cosDegrees) + (point3D.y * sinDegrees)
            Dim y As Double = (point3D.x * -sinDegrees) + (point3D.y * cosDegrees)

            Return New Vector3D(x, y, point3D.z)
        End Function

        Public Shared Function Translate(ByVal points3D As Vector3D, ByVal oldOrigin As Vector3D, ByVal newOrigin As Vector3D) As Vector3D
            Dim difference As New Vector3D(newOrigin.x - oldOrigin.x, newOrigin.y - oldOrigin.y, newOrigin.z - oldOrigin.z)
            points3D.x += difference.x
            points3D.y += difference.y
            points3D.z += difference.z
            Return points3D
        End Function

        Public Shared Function RotateX(ByVal points3D As Vector3D(), ByVal degrees As Single) As Vector3D()
            For i As Integer = 0 To points3D.Length - 1
                points3D(i) = RotateX(DirectCast(points3D(i), Vector3D), degrees)
            Next
            Return points3D
        End Function

        Public Shared Function RotateY(ByVal points3D As Vector3D(), ByVal degrees As Single) As Vector3D()
            For i As Integer = 0 To points3D.Length - 1
                points3D(i) = RotateY(DirectCast(points3D(i), Vector3D), degrees)
            Next
            Return points3D
        End Function

        Public Shared Function RotateZ(ByVal points3D As Vector3D(), ByVal degrees As Single) As Vector3D()
            For i As Integer = 0 To points3D.Length - 1
                points3D(i) = RotateZ(DirectCast(points3D(i), Vector3D), degrees)
            Next
            Return points3D
        End Function

        Public Shared Function Translate(ByVal points3D As Vector3D(), ByVal oldOrigin As Vector3D, ByVal newOrigin As Vector3D) As Vector3D()
            For i As Integer = 0 To points3D.Length - 1
                points3D(i) = Translate(points3D(i), oldOrigin, newOrigin)
            Next
            Return points3D
        End Function
    End Class
End Namespace