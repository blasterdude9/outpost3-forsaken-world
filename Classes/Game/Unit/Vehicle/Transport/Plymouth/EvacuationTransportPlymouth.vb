Imports IrrlichtNETCP
''' <summary>Plymouth Evacuation Transport. Higher cargo capacity, slower speed.</summary>
Public Class EvacuationTransportPlymouth
    Inherits Vehicle

    Public Sub New(ByRef owner As Player)
        _Chassis = "PlymouthTransport"
        _Turret = "None"
        _Speed = 1.8F
        _HP = 120 : _MaxHP = 120
        _Armor = ArmorType.MEDIUMLIGHT
        _CargoCapacity = 50
        _Name = "Evacuation Transport (Plymouth)"
        _Player = owner
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthEvacTransport.3ds"
        End Get
    End Property
End Class
