Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace shadow
    <ToolboxItem(True)>
    Public Class ShadowLabel
        Inherits Label

        Private _drawGradient As Boolean = True
        Private _startColor As Color = Color.Black
        Private _endColor As Color = Color.Black
        Private _angle As Single = 0
        Private _drawShadow As Boolean = True
        Private _yOffset As Single = 1
        Private _xOffset As Single = 1
        Private _shadowColor As Color = Color.Red
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New(ByVal container As System.ComponentModel.IContainer)
            container.Add(Me)
            InitializeComponent()
        End Sub

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then

                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If

            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

            If _drawGradient = True Then
                Dim brush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(0, 0, Me.Width, Me.Height), _startColor, _endColor, _angle, True)
                e.Graphics.FillRectangle(brush, 0, 0, Me.Width, Me.Height)
            End If

            If _drawShadow = True Then e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(_shadowColor), _xOffset, _yOffset, StringFormat.GenericDefault)
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), 0 - 1, 0 + 2, StringFormat.GenericDefault)
        End Sub

        <Category("Gradient"), Description("Set to true to draw the gradient background"), DefaultValue(True)>
        Public Property DrawGradient As Boolean
            Get
                Return Me._drawGradient
            End Get
            Set(ByVal value As Boolean)
                Me._drawGradient = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Gradient"), Description("The start color of the gradient"), DefaultValue(GetType(Color), "Color.White")>
        Public Property StartColor As Color
            Get
                Return Me._startColor
            End Get
            Set(ByVal value As Color)
                Me._startColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Gradient"), Description("The end color of the gradient"), DefaultValue(GetType(Color), "Color.LightSkyBlue")>
        Public Property EndColor As Color
            Get
                Return Me._endColor
            End Get
            Set(ByVal value As Color)
                Me._endColor = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Gradient"), Description("The angle of the gradient"), DefaultValue(0)>
        Public Property Angle As Single
            Get
                Return Me._angle
            End Get
            Set(ByVal value As Single)
                Me._angle = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Drop Shadow"), Description("Set to true to draw the Drop Shadow"), DefaultValue(True)>
        Public Property DrawShadow As Boolean
            Get
                Return Me._drawShadow
            End Get
            Set(ByVal value As Boolean)
                Me._drawShadow = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Drop Shadow"), Description("The X Offset used to draw the shadow"), DefaultValue(1)>
        Public Property XOffset As Single
            Get
                Return Me._xOffset
            End Get
            Set(ByVal value As Single)
                Me._xOffset = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Drop Shadow"), Description("The Y Offset used to draw the shadow"), DefaultValue(1)>
        Public Property YOffset As Single
            Get
                Return Me._yOffset
            End Get
            Set(ByVal value As Single)
                Me._yOffset = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Drop Shadow"), Description("The color used to draw the shadow"), DefaultValue(GetType(System.Drawing.Color), "Color.Black")>
        Public Property ShadowColor As Color
            Get
                Return Me._shadowColor
            End Get
            Set(ByVal value As Color)
                Me._shadowColor = value
                Me.Invalidate()
            End Set
        End Property

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            Me.ForeColor = Color.LightSkyBlue
        End Sub
    End Class
End Namespace
