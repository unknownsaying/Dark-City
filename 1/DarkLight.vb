Public Class DarkLight
    Private _intensity As Integer
    Private _radius As Integer
    Private _flickerEnabled As Boolean
    Private _color As Color

    Public Property Intensity As Integer
        Get
            Return _intensity
        End Get
        Set(value As Integer)
            _intensity = Math.Max(0, Math.Min(100, value))
        End Set
    End Property

    Public Property Radius As Integer
        Get
            Return _radius
        End Get
        Set(value As Integer)
            _radius = Math.Max(10, Math.Min(500, value))
        End Set
    End Property

    Public Property FlickerEnabled As Boolean
    Public Property Color As Color

    Public Sub New()
        _intensity = 50
        _radius = 100
        _flickerEnabled = True
        _color = Color.White
    End Sub

    Public Sub AdjustLight(level As Integer, area As Integer)
        Intensity = level
        Radius = area
    End Sub

    Public Function CalculateFlicker() As Integer
        If FlickerEnabled Then
            Return _intensity + Rnd() * 10 - 5
        End If
        Return _intensity
    End Function
End Class