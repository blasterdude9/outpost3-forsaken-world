''' <summary>Plymouth RPG. Rocket-propelled grenade. Good splash, medium range.</summary>
Public Class RPGPlymouth
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.RPG
        _Range = 7
        _CooldownMarks = 2
        _BaseDamage = New DamageVector(50, 10)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "RPG"

        End Get
    End Property
End Class
