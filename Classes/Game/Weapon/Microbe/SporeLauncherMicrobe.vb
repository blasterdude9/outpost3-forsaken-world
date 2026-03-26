''' <summary>
''' Microbe Spore Launcher — fires blight spores that deal damage over time.
''' Units hit by spores take DOT_DAMAGE per tick for DOT_DURATION ticks.
''' </summary>
Public Class SporeLauncherMicrobe
    Inherits Weapon

    Public Const DOT_DAMAGE As Integer = 8
    Public Const DOT_DURATION_TICKS As Integer = 8

    Public Sub New()
        _Type = WeaponType.SPORE
        _Ammo = 35
        _MaxAmmo = 35
        _ConcussionDamage = 15
        _PenetrationDamage = 5
        _SplashRadius = 20.0
        _ReloadTicks = 5
    End Sub
End Class
