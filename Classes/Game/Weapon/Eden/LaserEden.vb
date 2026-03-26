''' <summary>Eden Laser. Pinpoint accuracy, no splash. Best vs single targets. Ignores armor moderately.</summary>
Public Class LaserEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.LASER
        _Range = 8
        _CooldownMarks = 1
        _BaseDamage = New DamageVector(30, 15)  ' 30 concussion, 15 penetration
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Laser"

        End Get
    End Property
End Class
