''' <summary>Microbe Spore Launcher weapon — fires blight spores that deal damage over time.</summary>
Public Class SporeLauncherWeapon
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.BLIGHT_PROJECTOR
        _Range = 8
        _CooldownMarks = 4
        _BaseDamage = New DamageVector(15, 5)
    End Sub
    Protected Overrides Function CalculateDamage(ByRef target As Unit) As DamageVector
        If TypeOf target Is Building Then
            DirectCast(target, Building).SetStatus(Building.BuildingStatus.DISABLED_BLIGHT)
        End If
        Return _BaseDamage
    End Function
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "Spore Launcher"
        End Get
    End Property
End Class
