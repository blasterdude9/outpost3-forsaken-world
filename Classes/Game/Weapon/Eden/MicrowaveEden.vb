''' <summary>Eden Microwave Cannon — ignores armor, damages all unit types equally.</summary>
Public Class MicrowaveEden
    Inherits Weapon

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return ""
        End Get
    End Property

    Public Sub New()
        _Type = WeaponType.MICROWAVE
        _Ammo = -1
        _ConcussionDamage = 35
        _PenetrationDamage = 35    ' Equal split — microwave bypasses physical armor
        _SplashRadius = 0
        _ReloadTicks = 3
    End Sub

    Protected Overrides Function CalculateDamage() As Integer
        Return _PenetrationDamage  ' Microwave damage ignores concussion armor reduction
    End Function
End Class
