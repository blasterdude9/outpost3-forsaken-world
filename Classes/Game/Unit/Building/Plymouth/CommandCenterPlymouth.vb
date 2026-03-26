Imports IrrlichtNETCP
''' <summary>Plymouth Command Center. Less workers needed than Eden but requires rare metal.</summary>
Public Class CommandCenterPlymouth
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 3
        _ScientistsRequired = 2
        _BuildPointsRequired = 3000
        _CommonMetalCost = 2600
        _RareMetalCost = 200
        _TubeRequired = False
        _IsCommandCenter = True
        _ProductionLevel = 75
        _DeteriorateRate = 0
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthCommandCenter.3ds"
        End Get
    End Property
End Class
