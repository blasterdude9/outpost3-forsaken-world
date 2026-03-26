''' <summary>Microbe Acid Cloud. Lobbed acid projectile. Leaves a hazard zone that damages units passing through.</summary>
Public Class AcidCloudMicrobe
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.ACID_CLOUD
        _Range = 6
        _CooldownMarks = 3
        _BaseDamage = New DamageVector(40, 20)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Acid Cloud"

        End Get
    End Property
End Class
