''' <summary>
''' Microbe Blight Projector. On hit, seeds blight on the target tile.
''' Buildings hit by blight become DISABLED_BLIGHT. Vehicles take ongoing damage.
''' </summary>
Public Class BlightProjectorMicrobe
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.BLIGHT_PROJECTOR
        _Range = 7
        _CooldownMarks = 4
        _BaseDamage = New DamageVector(30, 10)
    End Sub
    Protected Overrides Function CalculateDamage(ByRef target As Unit) As DamageVector
        If TypeOf target Is Building Then
            DirectCast(target, Building).SetStatus(Building.BuildingStatus.DISABLED_BLIGHT)
        End If
        Return _BaseDamage
    End Function
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Blight Projector"

        End Get
    End Property
End Class
