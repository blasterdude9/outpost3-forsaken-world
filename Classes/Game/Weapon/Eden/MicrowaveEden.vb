''' <summary>Eden Microwave Cannon — ignores armor, damages all unit types equally.</summary>
Public Class MicrowaveEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.MICROWAVE
        _Range = 6
        _CooldownMarks = 1
        _BaseDamage = New DamageVector(25, 25)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Microwave Cannon"
        End Get
    End Property
End Class
