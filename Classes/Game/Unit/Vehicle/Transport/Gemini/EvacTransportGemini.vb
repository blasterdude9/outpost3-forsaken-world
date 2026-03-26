Imports IrrlichtNETCP

''' <summary>
''' Gemini Evacuation Transport — carries colonists to safety.
''' Win condition: evacuate enough colonists before the colony fails.
''' </summary>
Public Class EvacTransportGemini
    Inherits Vehicle

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        MyBase.New(owner)
        _Name = "Evacuation Transport"
        _Type = VehicleType.TRANSPORT
        _MaxHP = 400
        _HP = 400
        _Armor = ArmorType.MEDIUMLIGHT
        _Speed = 5.5
        _TurnRate = 7.0
        _CargoCapacity = 20    ' 20 colonists per transport
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "GeminiEvacTransport.3ds"

        End Get
    End Property
End Class
