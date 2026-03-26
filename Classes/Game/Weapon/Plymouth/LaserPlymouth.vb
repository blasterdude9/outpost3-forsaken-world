''' <summary>Plymouth Laser — wider beam, more concussion damage, less precise.</summary>
Public Class LaserPlymouth
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.LASER
        _Ammo = -1
        _ConcussionDamage = 65
        _PenetrationDamage = 5
        _SplashRadius = 5.0   ' Slight splash from heat dispersion
        _ReloadTicks = 3
    End Sub
End Class
