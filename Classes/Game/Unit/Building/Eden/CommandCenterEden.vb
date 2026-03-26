Imports IrrlichtNETCP

Public Class CommandCenterEden
    Inherits PowerPlantBuilding
    'Public Sub New()
    '    _Status = BuildingStatus.NONE
    '    _PowerRequired = 0
    '    _Power = 0
    '    _WorkersRequired = 4
    '    _Workers = 0
    '    _ScientistsRequired = 1
    '    _Scientists = 0
    '    _BuildPointsRequired = 2800
    '    _BuildPoints = 0
    '    _TubeRequired = False
    '    _Tube = False
    '    _CommonMetalCost = 2800
    '    _RareMetalCost = 0
    '    _IsCommandCenter = True
    'End Sub

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _Power = 0
        _WorkersRequired = 4
        _Workers = 0
        _ScientistsRequired = 1
        _Scientists = 0
        _BuildPointsRequired = 2800
        _BuildPoints = 0
        _TubeRequired = False
        _Tube = False
        _CommonMetalCost = 2800
        _RareMetalCost = 0
        _IsCommandCenter = True
        _ProductionLevel = 50
        _DeteriorateRate = 0
        _Position = position
    End Sub


    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "EdenCommandCenter.3ds"
        End Get
    End Property
End Class
