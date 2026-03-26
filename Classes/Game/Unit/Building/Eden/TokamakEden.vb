Imports IrrlichtNETCP

''' <summary>
''' Eden Tokamak Fusion Reactor. Primary power plant.
''' Produces 100 power per mark when fully staffed. Does not deteriorate.
''' </summary>
Public Class TokamakEden
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1600
        _CommonMetalCost = 1600
        _RareMetalCost = 500
        _TubeRequired = True
        _ProductionLevel = 100
        _DeteriorateRate = 0
        _ResourceWeight = 100   ' High priority - keep online
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenTokamak.3ds"
        End Get
    End Property
End Class
