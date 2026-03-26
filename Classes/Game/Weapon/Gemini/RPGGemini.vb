''' <summary>Gemini RPG — larger splash than Eden variant.</summary>
Public Class RPGGemini
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.RPG
        _Range = 8
        _CooldownMarks = 3
        _BaseDamage = New DamageVector(75, 18)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "RPG (Gemini)"
        End Get
    End Property
End Class
