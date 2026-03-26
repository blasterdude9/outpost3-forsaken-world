''' <summary>
''' Microbe Acid Cannon — very high penetration, ignores most armor.
''' Single target, no splash, slow reload.
''' </summary>
Public Class AcidCannonMicrobe
    Inherits Weapon

    Public Sub New()
        _Type = WeaponType.ACID
        _Ammo = 20
        _MaxAmmo = 20
        _ConcussionDamage = 10
        _PenetrationDamage = 90
        _SplashRadius = 0
        _ReloadTicks = 7
    End Sub

    Protected Overrides Function CalculateDamage() As Integer
        Return _PenetrationDamage  ' Acid bypasses armor entirely
    End Function
End Class
