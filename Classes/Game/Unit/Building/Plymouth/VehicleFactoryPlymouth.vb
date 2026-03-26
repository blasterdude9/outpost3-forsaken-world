Imports IrrlichtNETCP
''' <summary>Plymouth Vehicle Factory. Produces Plymouth-specific chassis.</summary>
Public Class VehicleFactoryPlymouth
    Inherits Building
    Implements IVehicleFactory

    Private Shared _supportedVehicles As String() = {
        "Lynx", "Panther", "Tiger", "ATV", "Evacuation Transport", "Cargo Truck"
    }

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 4
        _ScientistsRequired = 1
        _BuildPointsRequired = 2600
        _CommonMetalCost = 2500
        _RareMetalCost = 500
        _TubeRequired = True
        _ResourceWeight = 350
        _Position = position
    End Sub

    Public Function CanProduceVehicle(ByVal vehicleType As String) As Boolean Implements IVehicleFactory.CanProduceVehicle
        Return Array.IndexOf(_supportedVehicles, vehicleType) >= 0
    End Function
    Public Function GetBuildTime(ByVal vehicleType As String) As Integer Implements IVehicleFactory.GetBuildTime
        Select Case vehicleType
            Case "Lynx"     : Return 380
            Case "Panther"  : Return 680
            Case "Tiger"    : Return 1050
            Case "ATV"      : Return 500
            Case Else       : Return 500
        End Select
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthVehicleFactory.3ds"
        End Get
    End Property
End Class
