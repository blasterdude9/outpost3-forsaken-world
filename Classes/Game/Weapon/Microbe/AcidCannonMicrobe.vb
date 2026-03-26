''' <summary>Microbe Acid Cannon — very high penetration, ignores most armor.</summary>
Public Class AcidCannonMicrobe
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.ACID_CLOUD
        _Range = 6
        _CooldownMarks = 5
        _BaseDamage = New DamageVector(10, 90)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Acid Cannon"
        End Get
    End Property
End Class
