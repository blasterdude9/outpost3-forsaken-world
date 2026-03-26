''' <summary>Eden Supernova. Superheavy plasma cannon. Massive area damage, very slow ROF.</summary>
Public Class SupernovaEden
    Inherits Weapon
    Public Sub New()
        _Type = WeaponType.SUPERNOVA
        _Range = 6
        _CooldownMarks = 8
        _BaseDamage = New DamageVector(200, 50)
    End Sub
    Public Overrides ReadOnly Property DisplayName() As String
        Get

            Return "Supernova"

        End Get
    End Property
End Class
