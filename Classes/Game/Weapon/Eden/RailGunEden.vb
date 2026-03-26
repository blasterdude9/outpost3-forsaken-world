''' <summary>Eden Rail Gun. High penetration, long range. Excellent vs heavy armor.</summary>
Public Class RailGunEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.RAIL_GUN
        _Range = 12
        _CooldownMarks = 3
        _BaseDamage = New DamageVector(20, 60)  ' Low concussion, very high penetration
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get : Return "Rail Gun" : End Get
    End Property
End Class
