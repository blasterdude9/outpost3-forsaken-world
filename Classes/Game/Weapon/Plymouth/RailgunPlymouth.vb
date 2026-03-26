''' <summary>Plymouth Railgun — slightly lower penetration than Eden's but faster reload.</summary>
Public Class RailgunPlymouth
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.RAILGUN
        _Ammo = 50
        _MaxAmmo = 50
        _ConcussionDamage = 25
        _PenetrationDamage = 100
        _SplashRadius = 0
        _ReloadTicks = 6
    End Sub
End Class
