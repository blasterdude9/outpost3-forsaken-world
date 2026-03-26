Imports IrrlichtNETCP
''' <summary>Plymouth Panther. Carries Thor's Hammer rocket pod at full tech. Devastating vs structures.</summary>
Public Class PantherPlymouth
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "PlymouthPanther"
        _Turret = "Rocket"
        _Speed = 2.0F
        _HP = 160 : _MaxHP = 160
        _Armor = ArmorType.MEDIUM
        _Name = "Panther (Plymouth)"
        _Weapon = New RocketPlymouth()
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthPantherRocket.3ds"
        End Get
    End Property
End Class
