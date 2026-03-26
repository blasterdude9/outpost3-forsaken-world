Imports IrrlichtNETCP
''' <summary>Eden Lynx. Fast, light scout/raider. Low armor, high speed. Usually mounts laser or microwave.</summary>
Public Class LynxEden
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "EdenLynx"
        _Turret = "Laser"
        _Speed = 3.0F
        _HP = 80 : _MaxHP = 80
        _Armor = ArmorType.VERYLIGHT
        _Name = "Lynx (Eden)"
        _Weapon = New LaserEden()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenLynxLaser.3ds"
        End Get
    End Property
End Class
