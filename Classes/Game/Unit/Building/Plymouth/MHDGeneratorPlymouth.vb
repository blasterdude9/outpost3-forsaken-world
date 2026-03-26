Imports IrrlichtNETCP
''' <summary>
''' Plymouth MHD Generator. Magnetohydrodynamic power plant. Higher output than Eden Tokamak
''' but deteriorates over time and requires scientists to maintain efficiency.
''' </summary>
Public Class MHDGeneratorPlymouth
    Inherits PowerPlantBuilding

    Public Sub New(ByVal position As Vector3D, ByRef owner As Player)
        _Status = BuildingStatus.NONE
        _PowerRequired = 0
        _WorkersRequired = 2
        _ScientistsRequired = 2
        _BuildPointsRequired = 1800
        _CommonMetalCost = 1800
        _RareMetalCost = 700
        _TubeRequired = True
        _ProductionLevel = 130
        _DeteriorateRate = 1   ' Loses 1 ProductionLevel per 10 marks
        _ResourceWeight = 100
        _Position = position
    End Sub

    Public Overrides ReadOnly Property MeshFilename() As String
        Get
            Return "PlymouthMHDGenerator.3ds"
        End Get
    End Property
End Class
