''' <summary>Eden Starflare. Burst rocket pack. Fires a tight cluster of rockets.</summary>
Public Class StarflareEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.STARFLARE
        _Range = 10
        _CooldownMarks = 5
        _BaseDamage = New DamageVector(80, 20)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get : Return "Starflare" : End Get
    End Property
End Class
