''' <summary>Eden Thor's Hammer. Top-tier orbital strike weapon. Requires advanced lab and satellite.</summary>
Public Class ThorsHammerEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.THORS_HAMMER
        _Range = 25  ' Very long range
        _CooldownMarks = 20
        _BaseDamage = New DamageVector(500, 200)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get : Return "Thor's Hammer" : End Get
    End Property
End Class
