''' <summary>Gemini Laser — balanced stats, dual-fire mode.</summary>
Public Class LaserGemini
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.LASER
        _Range = 7
        _CooldownMarks = 1
        _BaseDamage = New DamageVector(45, 12)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Laser (Gemini)"
        End Get
    End Property
End Class
