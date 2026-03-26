''' <summary>Gemini Microwave. Continuous beam that damages light armor rapidly but weak vs heavy.</summary>
Public Class MicrowaveGemini
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.MICROWAVE
        _Range = 6
        _CooldownMarks = 1
        _BaseDamage = New DamageVector(25, 5)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get : Return "Microwave" : End Get
    End Property
End Class
