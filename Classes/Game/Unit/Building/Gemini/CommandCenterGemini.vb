Imports IrrlichtNETCP
''' <summary>
''' Gemini Command Center. The Gemini faction is a split colony — half Eden tech, half Plymouth.
''' Their CC is faster to build but offers lower initial power output.
''' </summary>
Public Class CommandCenterGemini
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 4
        _ScientistsRequired = 1
        _BuildPointsRequired = 2400
        _CommonMetalCost = 2400
        _RareMetalCost = 0
        _TubeRequired = False
        _IsCommandCenter = True
        _ProductionLevel = 60
        _DeteriorateRate = 0
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiCommandCenter.3ds"
        End Get
    End Property
End Class
