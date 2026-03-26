''' <summary>Gemini Starflare. Wider spread than Eden variant, same damage.</summary>
Public Class StarflareGemini
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.STARFLARE
        _Range = 11
        _CooldownMarks = 5
        _BaseDamage = New DamageVector(85, 20)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get : Return "Starflare (Gemini)" : End Get
    End Property
End Class
