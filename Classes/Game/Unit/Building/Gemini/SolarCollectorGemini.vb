Imports IrrlichtNETCP
''' <summary>
''' Gemini Solar Collector. Unique Gemini power plant — cheap, no rare metal needed,
''' but lower output than Tokamak or MHD. Best used in multiples.
''' </summary>
Public Class SolarCollectorGemini
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 1
        _ScientistsRequired = 0
        _BuildPointsRequired = 600
        _CommonMetalCost = 600
        _RareMetalCost = 0
        _TubeRequired = True
        _ProductionLevel = 40
        _DeteriorateRate = 0
        _ResourceWeight = 100
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "GeminiSolarCollector.3ds"
        End Get
    End Property
End Class
