''' <summary>Microbe Plasma Vine — medium damage, good vs buildings.</summary>
Public Class PlasmaVineMicrobe
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.BLIGHT_PROJECTOR
        _Range = 5
        _CooldownMarks = 4
        _BaseDamage = New DamageVector(40, 40)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Plasma Vine"
        End Get
    End Property
End Class
