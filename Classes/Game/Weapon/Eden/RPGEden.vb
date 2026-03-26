''' <summary>Eden RPG — splash damage weapon. Good against clusters of units.</summary>
Public Class RPGEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.RPG
        _Range = 7
        _CooldownMarks = 3
        _BaseDamage = New DamageVector(70, 15)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return "RPG"
        End Get
    End Property
End Class
