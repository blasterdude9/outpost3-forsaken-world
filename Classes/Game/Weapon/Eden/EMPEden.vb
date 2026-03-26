''' <summary>Eden EMP. Disables vehicles and buildings in a radius. Does minimal physical damage.</summary>
Public Class EMPEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.EMP
        _Range = 5
        _CooldownMarks = 6
        _BaseDamage = New DamageVector(5, 0)   ' Damage is minimal — effect is status: DISABLED_EMP
    End Sub
    Protected Overrides Function CalculateDamage(ByRef target As Unit) As DamageVector
        ' Apply EMP status to building targets
        If TypeOf target Is Building Then
            DirectCast(target, Building).SetStatus(Building.BuildingStatus.DISABLED_EMP)
        End If
        Return _BaseDamage
    End Function
    Public Overrides ReadOnly Property DisplayName() As String
        Get : Return "EMP" : End Get
    End Property
End Class
