''' <summary>Plymouth Thor's Hammer variant. Slightly more concussion damage, same range.</summary>
Public Class ThorsHammerPlymouth
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.THORS_HAMMER
        _Range = 25
        _CooldownMarks = 20
        _BaseDamage = New DamageVector(550, 150)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Thor's Hammer (Plymouth)"

        End Get
    End Property
End Class
