''' <summary>Gemini EMP — longer disable duration but smaller splash than Eden's.</summary>
Public Class EMPGemini
    Inherits Weapon

    Public Const DISABLE_DURATION_TICKS As Integer = 30

    Public Sub New()
        _Type = WeaponType.EMP
        _Ammo = 12
        _MaxAmmo = 12
        _ConcussionDamage = 0
        _PenetrationDamage = 0
        _SplashRadius = 35.0
        _ReloadTicks = 12
    End Sub
End Class
