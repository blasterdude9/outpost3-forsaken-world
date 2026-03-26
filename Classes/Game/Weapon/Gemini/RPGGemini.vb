Public Class RPGGemini
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.RPG
        _Ammo = 28
        _MaxAmmo = 28
        _ConcussionDamage = 75
        _PenetrationDamage = 18
        _SplashRadius = 35.0
        _ReloadTicks = 5
    End Sub
End Class
