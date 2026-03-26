''' <summary>Plymouth Rocket. Heavy unguided rocket. Best vs structures.</summary>
Public Class RocketPlymouth
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.ROCKET
        _Range = 9
        _CooldownMarks = 4
        _BaseDamage = New DamageVector(90, 30)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Rocket"

        End Get
    End Property
End Class
