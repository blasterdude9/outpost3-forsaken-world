Imports IrrlichtNETCP
''' <summary>Gemini Vehicle Factory. Can produce both Eden and Plymouth vehicle types.</summary>
Public Class VehicleFactoryGemini
    Inherits Building
    Implements IVehicleFactory

    Private Shared _supportedVehicles As String() = {
        "Lynx", "Panther", "Tiger", "Spider", "ATV", "Evacuation Transport", "Cargo Truck"
    }

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 22
        _WorkersRequired = 4
        _ScientistsRequired = 2
        _BuildPointsRequired = 2800
        _CommonMetalCost = 2800
        _RareMetalCost = 700
        _TubeRequired = True
        _ResourceWeight = 350
        _Position = position
    End Sub

    Public Function CanProduceVehicle(ByVal vehicleType As String) As Boolean Implements IVehicleFactory.CanProduceVehicle
        Return Array.IndexOf(_supportedVehicles, vehicleType) >= 0
    End Function
    Public Function GetBuildTime(ByVal vehicleType As String) As Integer Implements IVehicleFactory.GetBuildTime
        Return 600   ' Gemini is slightly slower (multi-type tooling overhead)
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiVehicleFactory.3ds"
        End Get
    End Property
End Class
