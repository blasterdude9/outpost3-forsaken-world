Imports IrrlichtNETCP
''' <summary>Eden Panther. Mid-tier balanced combat vehicle. Good all-rounder.</summary>
Public Class PantherEden
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "EdenPanther"
        _Turret = "RailGun"
        _Speed = 2.0F
        _HP = 150 : _MaxHP = 150
        _Armor = ArmorType.MEDIUMLIGHT
        _Name = "Panther (Eden)"
        _Weapon = New RailGunEden()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenPantherRailGun.3ds"
        End Get
    End Property
End Class
