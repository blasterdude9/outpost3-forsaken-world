''' <summary>
''' Eden Railgun — highest penetration damage in the game.
''' Slow fire rate but punches through anything.
''' </summary>
Public Class RailgunEden
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.RAILGUN
        _Ammo = 40
        _MaxAmmo = 40
        _ConcussionDamage = 20
        _PenetrationDamage = 120
        _SplashRadius = 0
        _ReloadTicks = 8
    End Sub
End Class
