Imports IrrlichtNETCP
''' <summary>Eden Vehicle Factory. Produces Lynx, Panther, Tiger, and Spider chassis.</summary>
Public Class VehicleFactoryEden
    Inherits Building
    Implements IVehicleFactory

    Private Shared _supportedVehicles As String() = {
        "Lynx", "Panther", "Tiger", "Spider", "Evacuation Transport", "Cargo Truck"
    }

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 4
        _ScientistsRequired = 1
        _BuildPointsRequired = 2400
        _CommonMetalCost = 2400
        _RareMetalCost = 600
        _TubeRequired = True
        _ResourceWeight = 350
        _Position = position
    End Sub

    Public Function CanProduceVehicle(ByVal vehicleType As String) As Boolean Implements IVehicleFactory.CanProduceVehicle
        Return Array.IndexOf(_supportedVehicles, vehicleType) >= 0
    End Function

    Public Function GetBuildTime(ByVal vehicleType As String) As Integer Implements IVehicleFactory.GetBuildTime
        Select Case vehicleType
            Case "Lynx"                  : Return 400
            Case "Panther"               : Return 700
            Case "Tiger"                 : Return 1100
            Case "Spider"                : Return 900
            Case "Evacuation Transport"  : Return 600
            Case "Cargo Truck"           : Return 300
            Case Else                    : Return 500
        End Select
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenVehicleFactory.3ds"
        End Get
    End Property
End Class
