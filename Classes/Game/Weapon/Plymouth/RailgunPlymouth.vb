''' <summary>Plymouth Railgun — slightly lower penetration than Eden's but faster reload.</summary>
Public Class RailgunPlymouth
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.RAIL_GUN
        _Range = 11
        _CooldownMarks = 2
        _BaseDamage = New DamageVector(25, 100)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Railgun (Plymouth)"
        End Get
    End Property
End Class
