Imports IrrlichtNETCP

Public Class CommonOreSmelterMicrobe
    Inherits OreBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 10
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1500
        _TubeRequired = True
        _CommonMetalCost = 900
        _CommonOreOutput = 35   ' Lower output — Microbe prioritizes biology over mining
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "MicrobeCommonOreSmelter.3ds"

        End Get
    End Property
End Class
