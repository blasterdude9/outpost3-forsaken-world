Imports IrrlichtNETCP
''' <summary>
''' Microbe Bioreactor. Generates power from biological processes.
''' Self-repairing but has a small chance to spontaneously combust (blight event).
''' </summary>
Public Class BioreactorMicrobe
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 2
        _ScientistsRequired = 1
        _BuildPointsRequired = 1000
        _CommonMetalCost = 800
        _RareMetalCost = 400
        _TubeRequired = True
        _ProductionLevel = 90
        _DeteriorateRate = 0
        _SpontaneouslyExplodes = True   ' Blight risk
        _ResourceWeight = 100
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "MicrobeBioreactor.3ds"
        End Get
    End Property
End Class
