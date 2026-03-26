''' <summary>Gemini Laser — balanced stats, dual-fire mode (fires twice per cycle).</summary>
Public Class LaserGemini
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.LASER
        _Ammo = -1
        _ConcussionDamage = 45
        _PenetrationDamage = 12
        _SplashRadius = 0
        _ReloadTicks = 2
    End Sub
End Class
