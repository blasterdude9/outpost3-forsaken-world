Imports IrrlichtNETCP
''' <summary>
''' Evacuation Transport. Carries colonists off-planet when the game enters
''' evacuation-mode win condition. Can also transport workers between bases.
''' </summary>
Public Class EvacuationTransportEden
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "EdenTransport"
        _Turret = "None"
        _Speed = 2.2F
        _HP = 100 : _MaxHP = 100
        _Armor = ArmorType.LIGHT
        _CargoCapacity = 30
        _Name = "Evacuation Transport (Eden)"
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenEvacTransport.3ds"
        End Get
    End Property
End Class
