''' <summary>Gemini Rail Gun. Standard rail gun, same stats as Eden variant.</summary>
Public Class RailGunGemini
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.RAIL_GUN
        _Range = 12
        _CooldownMarks = 3
        _BaseDamage = New DamageVector(20, 60)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Rail Gun (Gemini)"

        End Get
    End Property
End Class
