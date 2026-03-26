Imports IrrlichtNETCP
''' <summary>Plymouth Lynx. Slightly heavier than Eden Lynx. Usually carries RPG.</summary>
Public Class LynxPlymouth
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "PlymouthLynx"
        _Turret = "RPG"
        _Speed = 2.5F
        _HP = 100 : _MaxHP = 100
        _Armor = ArmorType.LIGHT
        _Name = "Lynx (Plymouth)"
        _Weapon = New RPGPlymouth()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthLynxRPG.3ds"
        End Get
    End Property
End Class
