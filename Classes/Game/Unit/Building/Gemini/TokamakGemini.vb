Imports IrrlichtNETCP

''' <summary>
''' Gemini Tokamak — standard output, no rare metal required.
''' Gemini uses slightly older but proven reactor design.
''' </summary>
Public Class TokamakGemini
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _WorkersRequired = 5
        _ScientistsRequired = 2
        _BuildPointsRequired = 3000
        _TubeRequired = True
        _CommonMetalCost = 2200
        _RareMetalCost = 400
        _ProductionLevel = 90
        _DeteriorateRate = 2
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiTokamak.3ds"
        End Get
    End Property
End Class
