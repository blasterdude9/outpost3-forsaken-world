''' <summary>Eden RPG — splash damage weapon. Good against clusters of units.</summary>
Public Class RPGEden
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.RPG
        _Ammo = 24
        _MaxAmmo = 24
        _ConcussionDamage = 70
        _PenetrationDamage = 15
        _SplashRadius = 30.0
        _ReloadTicks = 5
    End Sub
End Class
