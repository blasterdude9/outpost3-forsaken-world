''' <summary>
''' Microbe Plasma Vine — living weapon that wraps around targets.
''' Medium damage, medium splash, excellent vs buildings.
''' </summary>
Public Class PlasmaVineMicrobe
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.PLASMA
        _Ammo = 18
        _MaxAmmo = 18
        _ConcussionDamage = 40
        _PenetrationDamage = 40
        _SplashRadius = 15.0
        _ReloadTicks = 6
    End Sub
End Class
