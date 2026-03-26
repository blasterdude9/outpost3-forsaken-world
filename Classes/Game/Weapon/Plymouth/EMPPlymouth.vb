''' <summary>Plymouth EMP. Wider radius than Eden variant, longer cooldown.</summary>
Public Class EMPPlymouth
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.EMP
        _Range = 7
        _CooldownMarks = 8
        _BaseDamage = New DamageVector(5, 0)
    End Sub
    Protected Overrides Function CalculateDamage(ByRef target As Unit) As DamageVector
        If TypeOf target Is Building Then
            DirectCast(target, Building).SetStatus(Building.BuildingStatus.DISABLED_EMP)
        End If
        Return _BaseDamage
    End Function
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "EMP (Heavy)"

        End Get
    End Property
End Class
