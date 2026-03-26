Imports IrrlichtNETCP
''' <summary>
''' Microbe Arachnid Factory. Produces the Microbe faction's unique spider-legged vehicles.
''' Also produces standard wheeled vehicles with biological armor plating.
''' </summary>
Public Class ArachnidFactoryMicrobe
    Inherits Building
    Implements IVehicleFactory

    Private Shared _supportedVehicles As String() = {
        "Lynx", "Panther", "Tiger", "Arachnid Scout", "Arachnid Warrior",
        "Spore Launcher", "Evacuation Transport", "Cargo Truck"
    }

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 20
        _WorkersRequired = 3
        _ScientistsRequired = 2
        _BuildPointsRequired = 2200
        _CommonMetalCost = 1800
        _RareMetalCost = 800
        _TubeRequired = True
        _ResourceWeight = 350
        _Position = position
    End Sub

    Public Function CanProduceVehicle(ByVal vehicleType As String) As Boolean Implements IVehicleFactory.CanProduceVehicle
        Return Array.IndexOf(_supportedVehicles, vehicleType) >= 0
    End Function
    Public Function GetBuildTime(ByVal vehicleType As String) As Integer Implements IVehicleFactory.GetBuildTime
        Select Case vehicleType
            Case "Arachnid Scout"   : Return 600
            Case "Arachnid Warrior" : Return 1000
            Case "Spore Launcher"   : Return 1400
            Case "Lynx"             : Return 450
            Case Else               : Return 700
        End Select
    End Function

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeArachnidFactory.3ds"
        End Get
    End Property
End Class
