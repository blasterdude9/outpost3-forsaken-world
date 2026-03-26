''' <summary>Plymouth Laser — wider beam, more concussion damage, less precise.</summary>
Public Class LaserPlymouth
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.LASER
        _Range = 7
        _CooldownMarks = 2
        _BaseDamage = New DamageVector(65, 5)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Laser (Plymouth)"
        End Get
    End Property
End Class
