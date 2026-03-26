Imports IrrlichtNETCP

''' <summary>
''' Plymouth Tokamak — slightly less efficient than Eden's but cheaper to build.
''' Plymouth sacrifices finesse for raw throughput.
''' </summary>
Public Class TokamakPlymouth
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 5
        _ScientistsRequired = 2
        _BuildPointsRequired = 2800
        _TubeRequired = True
        _CommonMetalCost = 1800
        _RareMetalCost = 600
        _ProductionLevel = 85    ' Slightly less efficient than Eden (100)
        _DeteriorateRate = 3
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthTokamak.3ds"
        End Get
    End Property
End Class
