Imports IrrlichtNETCP

Public Class RareOreSmelterMicrobe
    Inherits OreBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 15
        _WorkersRequired = 2
        _ScientistsRequired = 2
        _BuildPointsRequired = 1900
        _TubeRequired = True
        _CommonMetalCost = 1000
        _RareMetalCost = 100
        _RareOreOutput = 18
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get

            Return "MicrobeRareOreSmelter.3ds"

        End Get
    End Property
End Class
